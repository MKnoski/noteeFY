function Task(Text, IsDone) {
    //Data
    var self = this;
    self.text = ko.observable(Text);
    self.isDone = ko.observable(IsDone);
}

function Note(data) {
    //Data
    var self = this;

    self.title = ko.observable(data.Title);
    self.text = ko.observable(data.Text);
    self.type = ko.observable(data.Type);

    self.tasks = ko.observableArray([]);
    self.currentTask = ko.observable("");
    self.selectedTask = ko.observable();

    self.isEditTitle = ko.observable(false);
    self.isEditText = ko.observable(false);

    //Functions
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
         self.tasks.remove(task)
    };

    var mappedTasks = $.map(data.TaskItems, function (item) { return new Task(item.Text, item.IsDone) });
    self.tasks(mappedTasks);


}