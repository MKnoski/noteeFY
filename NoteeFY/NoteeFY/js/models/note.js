function Note(data) {
    var self = this;

    self.title = ko.observable();
    self.text = ko.observable();
    self.type = ko.observable(0);
    self.userID = ko.observable();
    self.noteID = ko.observable();
    self.modificationDate = ko.observable();

    self.tasks = ko.observableArray([]);
    self.currentTask = ko.observable("");
    self.selectedTask = ko.observable();

    self.isEditTitle = ko.observable(false);
    self.isEditText = ko.observable(false);

    if (data) {
        self.initialize(data);
    }
}

// METHODS

Note.prototype.initialize = function (data) {
    var self = this;
    self.title (data.Title);
    self.text (data.Text);
    self.type (data.Type);
    self.userID (data.UserID);
    self.noteID (data.NoteID);
    self.modificationDate(data.ModificationDate.substring(11, 19));

    var mappedTasks = $.map(data.TaskItems, function (item) { return new Task(item) });
    self.tasks(mappedTasks);
}

Note.prototype.lostFocusText = function () {
        var self = this;
        self.setEditText(false);
        self.updateNote();
    };

Note.prototype.lostFocusTitle = function () {
        var self = this;
        self.setEditTitle(false);
        self.updateNote();
    };

Note.prototype.setEditTitle = function (state) {
        var self = this;
        self.isEditTitle(state);
    };

Note.prototype.setEditText = function (state) {
        var self = this;
        self.isEditText(state);
    };

Note.prototype.addTask = function () {
    var self = this;
    window.isLoading(true);
    $.ajax({
        url: "api/TaskItems/",
        type: "POST",
        data: {
            Text: self.currentTask,
            IsDone: false,
            NoteID: self.noteID
        },
        success: function (response) {
            var task = new Task(response.Data);
            self.tasks.push(task);
            self.selectedTask(task);
            self.currentTask("");
            self.modificationDate(new Date().toLocaleString().substring(11, 19));
            window.isLoading(false);
        }
    });
};

Note.prototype.deleteTask = function (task) {
    var self = this;
    window.isLoading(true);
    $.ajax({
        url: "api/TaskItems/" + task.taskID(),
        type: "DELETE",
        success: function () {
            self.tasks.remove(task);
            self.modificationDate(new Date().toLocaleString().substring(11, 19));
            window.isLoading(false);
        }
    });
};

Note.prototype.updateNote = function() {
    var self = this;
    window.isLoading(true);
    $.ajax({
        url: "api/Notes/" + self.noteID(),
        type: "POST",
        data: {
            NoteID: self.noteID(),
            Title: self.title(),
            Text: self.text(),
            Type: self.type(),
            UserID: self.userID(),
            TaskItems: []
        },
        success: function(response) {
            self.modificationDate(response.Data.ModificationDate.substring(11, 19));
            window.isLoading(false);
        }
    });
};

Note.prototype.goOnBottom = function(task) {
    var temp = jQuery.extend(true, {}, task);
    var self = this;

    if (task.isDone()) {
        self.tasks.destroy(task);
        self.tasks.push(temp);
    } else {
        self.tasks.destroy(task);
        self.tasks.unshift(temp);
    }
};