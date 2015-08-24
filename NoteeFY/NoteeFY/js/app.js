var NoteeFy = {};
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
    
    window.isLoading(true);

    $.getJSON("api/Users", function (allData) {
        var mappedUser = new User(allData);
        self.user(mappedUser);
        self.logged(true);
    }).success(function () {
        $('.notepad').masonry({
            // options
            itemSelector: '.single-note',
            gutter: 5
        });
        $('.note-content-textarea').autosize();
        $('.tasks-textarea').autosize();
        NoteeFy.refreshLayout();
    }).complete(function () {
        window.isLoading(false);
    }).error(function () {
    });

    NoteeFy.refreshLayout = function () {
        $('.notepad').masonry('layout');
    }
}

ko.applyBindings(new AppViewModel());