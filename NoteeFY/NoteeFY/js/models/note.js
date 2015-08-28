function Note(data) {
    var self = this;

    self.title = ko.observable();
    self.text = ko.observable();
    self.type = ko.observable(0);
    self.userID = ko.observable();
    self.noteID = ko.observable();
    self.color = ko.observable();
    self.label = ko.observable();
    self.modificationDate = ko.observable();
    self.modificationDateFull = ko.observable();
    self.imageUrl = ko.observable();
    self.tasks = ko.observableArray([]);
    self.newTask = ko.observable("");

    self.isEditTitle = ko.observable(false);
    self.isLabelSet = ko.observable(false);
    self.isLocked = ko.observable(false);

    self.textAsHtml = ko.computed(function () {
        if (!self.text()) {
            return "";
        }
        return self.text().replace(/\n/g, "</br>");
    });

    if (data) {
        self.initialize(data);
    }
}

Note.prototype.initialize = function(data) {
    var self = this;
    self.title(data.Title);
    self.text(data.Text);
    self.type(data.Type);
    self.userID(data.UserID);
    self.noteID(data.NoteID);
    self.imageUrl(data.ImageUrl);
    self.color(data.Color);
    self.label(data.Label);
    self.isLocked(data.IsLocked);
    self.modificationDate(self.getModificationDate(data));
    self.modificationDateFull(self.getFullModificationDate(data));
    if (data.Label != null) {
        self.isLabelSet(true);
    }
    var mappedTasks = $.map(data.TaskItems, function(item) { return new Task(item); });
    self.tasks(mappedTasks);
};

Note.prototype.addTask = function () {
    var self = this;
    NoteeFy.changeNotificationStatus(1);
    $.ajax({
        url: "api/TaskItems/",
        type: "POST",
        data: {
            Text: self.newTask,
            IsDone: false,
            NoteID: self.noteID
        },
        success: function (response) {
            var task = new Task(response.Data);
            self.tasks.unshift(task);
            self.newTask("");
            self.modificationDate(self.getModificationDate());
            NoteeFy.refreshTextarea();
            NoteeFy.refreshLayout();
            NoteeFy.changeNotificationStatus(0);
        }
    });
};

Note.prototype.sendTask = function(data, event) {
    if (event.which === 13) {
        this.addTask();
    }
    return true;
}

Note.prototype.deleteTask = function (task) {
    var self = this;
    NoteeFy.changeNotificationStatus(1);
    $.ajax({
        url: "api/TaskItems/" + task.taskID(),
        type: "DELETE",
        success: function () {
            self.tasks.remove(task);
            self.modificationDate(self.getModificationDate());
            self.modificationDateFull(self.modificationDateFull());
            NoteeFy.refreshLayout();
            NoteeFy.changeNotificationStatus(0);
        }
    });
};

Note.prototype.updateNote = function() {
    var self = this;
    NoteeFy.changeNotificationStatus(1);
    $.ajax({
        url: "api/Notes/" + self.noteID(),
        type: "POST",
        data: {
            NoteID: self.noteID(),
            Title: self.title(),
            Text: self.text(),
            Type: self.type(),
            UserID: self.userID(),
            Color: self.color(),
            ImageUrl: self.imageUrl(),
            Label: self.label(),
            isLocked: self.isLocked(),
            TaskItems: []
        },
        success: function (response) {
            self.modificationDate(self.getModificationDate(response.Data));
            self.modificationDateFull(self.getFullModificationDate(response.Data));
        },
        complete: function () {
            NoteeFy.changeNotificationStatus(0);
            NoteeFy.refreshLayout();
        }
    });
};

Note.prototype.reorderTasks = function(task) {
    var temp = jQuery.extend(true, {}, task);
    var self = this;

    if (task.isDone()) {
        self.tasks.destroy(task);
        self.tasks.push(temp);
    } else {
        self.tasks.destroy(task);
        self.tasks.unshift(temp);
    }
    task.updateTask();
    NoteeFy.refreshTextarea();
};

Note.prototype.getModificationDate = function (data) {
    moment.locale('pl');
    if (data) {
        return moment(data.ModificationDate).format("l");
    } else {
        return moment(moment()).format("l");
    }
};

Note.prototype.getFullModificationDate = function (data) {
    moment.locale('pl');
    if (data) {
        return moment(data.ModificationDate).format("LLLL");
    } else {
        return moment(moment()).format("LLLL");
    }
};

Note.prototype.addColorPicker = function (note, event) {
    $(event.target).colpick({
        layout: 'hex',
        submit: 0,
        color: 'FBEA6E',
        onChange: function (hsb, hex) {
            note.color('#' + hex);
        },
        onHide: function () {
            note.updateNote();
        }
    }
    );
}

Note.prototype.addImage = function () {
    var self = this;
    bootbox.prompt({
        title: "Podaj link URL obrazka:",
        value: self.imageUrl(),
        callback: function (result) {
            if (result != null) {
                self.imageUrl(result);
                self.updateNote();
                NoteeFy.refreshLayout();
            }
        },
        buttons: {
            confirm: {
                label: "Dodaj obrazek"
            },
            cancel: {
                label: "Anuluj"
            }
        }
    });
}

Note.prototype.deleteImage = function() {
    var self = this;
    bootbox.confirm({
        message: "Czy na pewno chcesz usunać obrazek?",
        callback: function(result) {
            if (result === true) {
                self.imageUrl("");
                self.updateNote();
                NoteeFy.refreshLayout();
            }
        },
        buttons: {
            confirm: {
                label: "TAK"
            },
            cancel: {
                label: "NIE"
            }
        }
    });
}

Note.prototype.addLabel = function () {
    var self = this;
    $('.modal-button').on('click', function (event) {
        self.label($(this).text());
        self.updateNote();
        self.isLabelSet(true);
        $('.modal-button').off();
        $('.myModal').modal('hide');
    });
    $('.myModal').modal('show');
}

Note.prototype.deleteLabel = function() {
    var self = this;
    self.label("");
    self.updateNote();
    self.isLabelSet(false);
}

Note.prototype.lockNote = function (data, event) {
    var self = this;
    self.isLocked(true);
    self.updateNote();
}

Note.prototype.unlockNote = function (data, event) {
    var self = this;
    self.isLocked(false);
    self.updateNote();
}