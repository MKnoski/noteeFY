function AppViewModel() {
    var self = this;
    self.userID = ko.observable("");
    self.user = ko.observable(new User());
    self.loginError = ko.observable("");
    self.logged = ko.observable(false);
    window.isLoading = ko.observable(false);
    self.isLoading = ko.computed(function () {
        return window.isLoading();
    });

    self.logIn = function() {
        window.isLoading(true);
        $.getJSON("api/Users/" + self.userID(), function(allData) {
            var mappedUser = new User(allData);
            self.user(mappedUser);
            self.logged(true);
        }).success(function () {
            tasksTestAutoGrow();
        }).complete(function() {
            window.isLoading(false);
        }).error(function() {
        });
    };

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

function tasksTestAutoGrow() {
    var textareas = document.getElementsByClassName("tasks-textarea");
    for (var index = 0; index < textareas.length; index++) {
        autoGrow(textareas[index]);
    }
}

function autoGrow(element) {
    element.style.height = "5px";
    element.style.height = (element.scrollHeight) + "px";
}