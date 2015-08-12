function Note(data) {
    //Data
    var self = this;

    self.title = ko.observable(data.Title);
    self.text = ko.observable(data.Text);
    self.type = ko.observable(data.Type);
    self.userID = ko.observable(data.UserID);
    self.noteID = ko.observable(data.NoteID);
    self.modificationDate = ko.observable(data.modificationDate);

    self.tasks = ko.observableArray([]);
    self.currentTask = ko.observable("");
    self.selectedTask = ko.observable();

    self.isEditTitle = ko.observable(false);
    self.isEditText = ko.observable(false);

    //Functions
    self.lostFocusText = function() {
        self.setEditText(false);
        self.update();
    };

    self.lostFocusTitle = function () {
        self.setEditTitle(false);
        self.update();
    };

    self.setEditTitle = function (state) {
        self.isEditTitle(state);
    };

    self.setEditText = function (state) {
        self.isEditText(state);
    };

    self.addTask = function () {
        var task = new Task(self.currentTask(), false);
        self.tasks.push(task);
        self.selectedTask(task);
        self.currentTask("");
    };

    self.removeTask = function(task) {
        self.tasks.remove(task);
    };

    self.update = function () {
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
            }
        });
    };

    var mappedTasks = $.map(data.TaskItems, function (item) { return new Task(item.Text, item.IsDone) });
    self.tasks(mappedTasks);


}