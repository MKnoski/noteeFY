function Note(data) {
    //Data
    var self = this;
    self.title = ko.observable(data.Title);
    self.text = ko.observable(data.Text);
    self.isEditTitle = ko.observable(false);
    self.isEditText = ko.observable(false);

    self.setEditTitle = function (state) {
        self.isEditTitle(state);
    };

    self.setEditText = function (state) {
        self.isEditText(state);
    };

}