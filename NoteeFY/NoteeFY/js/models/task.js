function Task(data) {
    var self = this;
    self.text = ko.observable(data.Text);
    self.isDone = ko.observable(data.IsDone);
    self.taskID = ko.observable(data.TaskItemID);
    self.noteID = ko.observable(data.NoteID);
    self.isEditTask = ko.observable(false);

    self.shortText = ko.computed(function () {
        if (!self.text()) {
            return '';
        }

        if (self.text().length > 15 && self.isEditTask() === false) {
            return self.text().substring(0, 15) + "...";
        }        
        else {
            return self.text();
        }
    });

    self.updateTask = function() {
        window.isLoading(true);
        $.ajax({
            url: "api/TaskItems/" + self.taskID(),
            type: "POST",
            data: {
                TaskItemID: self.taskID(),
                Text: self.text(),
                IsDone: self.isDone(),
                NoteID: self.noteID()
            },
            complete: function() {
                window.isLoading(false);
            }
        });
        self.isEditTask(false);
    };
}