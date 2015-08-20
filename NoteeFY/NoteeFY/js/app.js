function AppViewModel() {
    var self = this;

    self.user = ko.observable(new User());
    window.isLoading = ko.observable(false);
    self.isLoading = ko.computed(function () {
        return window.isLoading();
    });
    
    window.isLoading(true);

    $.getJSON("api/Users", function (allData) {
        var mappedUser = new User(allData);
        self.user(mappedUser);
    }).success(function () {
    }).complete(function () {
        window.isLoading(false);
    }).error(function () {
    });

}

ko.applyBindings(new AppViewModel());