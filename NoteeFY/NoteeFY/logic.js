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

function Note(data) {
    //Data
    var self = this;
    self.title = ko.observable(data.Title);
    self.text = ko.observable(data.Text);
    self.isEdit = ko.observable(false);

    self.setEdit = function (state) {
        self.isEdit(state);
    };

}

function AppViewModel() {
    //Data
    var self = this;
    self.userIDInput = ko.observable("");
    self.user = ko.observable(new User());
    //self.users = ko.observableArray([]);
    self.canLogIn = ko.observable(false);
    self.logged = ko.observable(false);

//Functions

    self.logIn = function () {
        $.getJSON("api/Users/"+self.userIDInput(), function (allData) {
            var mappedUser = new User(allData);
            //self.users(mappedUser);
            self.user(mappedUser);

            self.logged(true);
        });
    }

    //Handler for Enter key
    self.onEnter = function (d, e) {
        if (self.userIDInput() != "") {
            e.keyCode === 13 && self.logIn(); 
            return true;
        }
        else {
            e.keyCode === 13;
            return true;
        }
    };

}

ko.applyBindings(new AppViewModel());