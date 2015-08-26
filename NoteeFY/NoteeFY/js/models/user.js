function User(data) {
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
    var mappedNotes = $.map(data.Notes, function (item) { return new Note(item); });
    self.notes(mappedNotes);
};

User.prototype.addNote = function (type) {
    var self = this;
    NoteeFy.changeNotificationStatus(1);
    $.ajax({
        url: "api/Notes/",
        type: "POST",
        data: {
            Title: "",
            Text: "",
            Color: "#FBEA6E",
            Type: type,
            UserID: self.userID(),
            ImageUrl: "",
            TaskItems: []
        },
        complete: function () {
            NoteeFy.changeNotificationStatus(0);
        },
        success: function (response) {
            var note = new Note(response.Data);
            self.notes.push(note);
            var allNotes = document.getElementsByClassName("single-note");
            var singleNoteToAdd = allNotes[allNotes.length - 1];
            $('.notepad').masonry('prepended', singleNoteToAdd);
            NoteeFy.refreshTextarea();
            NoteeFy.refreshLayout();
        }
    });
};

User.prototype.deleteNote = function (note, event) {
    var self = this;
    bootbox.confirm("Czy na pewno chcesz usunać notatkę?",
        function (result) {
            if (result === true) {
                NoteeFy.changeNotificationStatus(1);
                $.ajax({
                    url: "api/Notes/" + note.noteID(),
                    type: "DELETE",
                    complete: function () {
                        NoteeFy.changeNotificationStatus(0);
                    },
                    success: function () {
                        self.user().notes.remove(note);
                        var singleNoteToRemove = event.currentTarget.parentElement.parentElement;
                        $('.notepad').masonry('remove', singleNoteToRemove).masonry('layout');
                    }
                });
            }
        });
};

