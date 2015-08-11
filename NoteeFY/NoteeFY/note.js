function Task(data) {
    //Data
    var self = this;
    self.text = ko.observable(data.Text);
    self.isDone = ko.observable(data.IsDone);
}

function Note(data) {
    //Data
    var self = this;
    self.title = ko.observable(data.Title);
    self.text = ko.observable(data.Text);
    self.type = ko.observable(data.Type);
    self.tasks = ko.observableArray([]);

    self.isEditTitle = ko.observable(false);
    self.isEditText = ko.observable(false);

    self.setEditTitle = function (state) {
        self.isEditTitle(state);
    };

    self.setEditText = function (state) {
        self.isEditText(state);
    };

    var mappedTasks = $.map(data.TaskItemsDTO, function (item) { return new Task(item) });
    self.tasks(mappedTasks);
    

}