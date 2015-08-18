function User(data) {
    var self = this;
    self.userID = ko.observable();
    self.notes = ko.observableArray([]);

    if (data) {
        self.initialize(data);
    }
}

User.prototype.initialize = function(data) {
    var self = this;
    self.userID(data.UserID);
    var mappedNotes = $.map(data.Notes, function(item) { return new Note(item); });
    self.notes(mappedNotes);
};

User.prototype.addNote = function (type) {
    var self = this;
    window.isLoading(true);
    $.ajax({
        url: "api/Notes/",
        type: "POST",
        data: {
            Title: "",
            Text: "",
            Type: type,
            UserID: self.userID(),
            TaskItems: []
        },
        success: function (response) {
            var note = new Note(response.Data);
            self.notes.push(note);
            window.isLoading(false);
        }
    });
};

User.prototype.deleteNote = function (note) {
    var self = this;
    window.isLoading(true);
    $.ajax({
        url: "api/Notes/" + note.noteID(),
        type: "DELETE",
        success: function () {
            self.user().notes.remove(note);
            window.isLoading(false);
        }
    });
};