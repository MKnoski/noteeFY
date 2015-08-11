function User(data) {
    var self = this;
    self.userID = ko.observable();
    self.notes = ko.observableArray([]);

    if (!data) {
        return;
    }

    self.userID(data.UserID);
    var mappedNotes = $.map(data.NotesDTO, function (item) { return new Note(item) });
    self.notes(mappedNotes);
}