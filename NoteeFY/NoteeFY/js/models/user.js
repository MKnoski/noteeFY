function User(data) {
    // Data
    var self = this;
    self.userID = ko.observable();
    self.notes = ko.observableArray([]);

    if (data) {
        self.initialize(data);
    }
}




User.prototype.initialize = function (data) {
    var self = this;
    self.userID(data.UserID);
    var mappedNotes = $.map(data.Notes, function (item) { return new Note(item) });
    self.notes(mappedNotes);
}

User.prototype.addNote = function () {
    var self = this;

    $.ajax({
        url: "api/Notes/",
        type: "POST",
        data: {
            Title: "",
            Text: "",
            Type: 0,
            UserID: self.userID(),
            TaskItems: []
        },
        success: function (response) {
            var note = new Note(null, response.Data.NoteID, response.Data.UserID);
            self.notes.push(note);
        }
    });
};

User.prototype.deleteNote = function (note) {
    var self = this;
    self.user().notes.remove(note);

    $.ajax({
        url: "api/Notes/" + note.noteID(),
        type: "DELETE"
    });
};