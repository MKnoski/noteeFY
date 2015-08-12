function Note(data, noteID, userID) {
    var self = this;

    self.title = ko.observable();
    self.text = ko.observable();
    self.type = ko.observable(0);
    self.userID = ko.observable(userID);
    self.noteID = ko.observable(noteID);
    self.modificationDate = ko.observable();

    self.tasks = ko.observableArray([]);
    self.currentTask = ko.observable();
    self.selectedTask = ko.observable();

    self.isEditTitle = ko.observable(false);
    self.isEditText = ko.observable(false);

    if (data) {
        self.initialize(data);
    }
}




Note.prototype.initialize = function (data) {
    var self = this;
    self.title (data.Title);
    self.text (data.Text);
    self.type (data.Type);
    self.userID (data.UserID);
    self.noteID (data.NoteID);
    self.modificationDate(data.ModificationDate.substring(11, 19));

    var mappedTasks = $.map(data.TaskItems, function (item) { return new Task(item.Text, item.IsDone) });
    self.tasks(mappedTasks);
}

Note.prototype.lostFocusText = function () {
        var self = this;
        self.setEditText(false);
        self.update();
    };

Note.prototype.lostFocusTitle = function () {
        var self = this;
        self.setEditTitle(false);
        self.update();
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
        var task = new Task(self.currentTask(), false);
        self.tasks.push(task);
        self.selectedTask(task);
        self.currentTask("");
    };

Note.prototype.removeTask = function (task) {
    var self = this;
    self.tasks.remove(task);
    };

Note.prototype.update = function () {
        var self = this;
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
            success: function (response) {

                self.modificationDate(response.Data.ModificationDate.substring(11, 19));

            }
        });

    };