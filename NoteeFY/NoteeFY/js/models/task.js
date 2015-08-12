function Task(Text, IsDone) {
    //Data
    var self = this;
    self.text = ko.observable(Text);
    self.isDone = ko.observable(IsDone);
}