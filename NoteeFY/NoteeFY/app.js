function AppViewModel() {
    //Data
    var self = this;
    self.userID = ko.observable("");
    self.user = ko.observable(new User());
    self.loginError = ko.observable("");
    self.logged = ko.observable(false);

//Functions

    self.logIn = function ()
    {
        $.getJSON("api/Users/" + self.userID(), function (allData)
        {
            var mappedUser = new User(allData);
            self.user(mappedUser);
            self.logged(true);
        }).error(function () { self.loginError("Nie ma uzytkownika o podanym ID "); });
    }

    //Handler for Enter key
    self.onEnter = function (d, e) {
        if (self.userID() != "") {
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