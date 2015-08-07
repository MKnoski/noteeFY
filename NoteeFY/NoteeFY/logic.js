function User(data)
{
    this.userID = ko.observable(data.UserID);
}


function LoginViewModel()
{
    //Data
    var self = this;
    self.userIDInput = ko.observable("");
    self.users = ko.observableArray([]);
    self.canLogIn = ko.observable(false);
    self.logged = ko.observable(false);

    //Functions

    self.logIn = function() 
    {
        var users = self.users();
        var insertedID = self.userIDInput();
        var found = false;

        for (i = 0; i < users.length && found == false; i++)
        {
            if (users[i].userID() == insertedID) found = true;
        }

        if (found)
        {
            alert("Znalazl");
        }
        else
        {
            alert("Nie znalazl")
        }
        
    }

    //Handler for Enter key
    self.onEnter = function(d, e)
    {
        if (self.userIDInput() != "")
        {
            e.keyCode === 13 && self.logIn(); //tutaj dodac zadanie
            return true;
        }
        else
        {
            e.keyCode === 13;
            return true;
        }
    };

    //Startup Loading
    $.getJSON("api/Users", function (allData)
    {
        var mappedUsers = $.map(allData, function (item) { return new User(item) });
        self.users(mappedUsers);
    });
   
}

ko.applyBindings(new LoginViewModel());


//alert("hello");