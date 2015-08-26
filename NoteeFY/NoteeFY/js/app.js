var NoteeFy = {};
function AppViewModel() {
    var self = this;
    self.userID = ko.observable("");
    self.user = ko.observable(new User());
    self.notification = ko.observable("/images/saved.png");
    window.isLoading = ko.observable(false);
    self.isLoading = ko.computed(function () {
        return window.isLoading();
    });
    
    window.isLoading(true);

    $.getJSON("api/Users", function (allData) {
        var mappedUser = new User(allData);
        self.user(mappedUser);
    }).success(function () {
        window.isLoading(true);
        $('.notepad').masonry({
            itemSelector: '.single-note',
            gutter: 5
        });
        imagesLoaded(document.querySelector('.notepad'), function () {
            NoteeFy.refreshLayout();
            window.isLoading(false);
        });
        NoteeFy.refreshTextarea();
        NoteeFy.refreshLayout();
    }).complete(function () {
    }).error(function () {
    });

    NoteeFy.changeNotificationStatus = function (status) {
        if (status === 0) {
            self.notification("/images/saved.png");
        }
        if (status === 1) {
            self.notification("/images/saving.gif");
        }
    }
}

NoteeFy.refreshLayout = function () {
    $('.notepad').masonry('layout');
}

NoteeFy.refreshTextarea = function () {
    autosize($('textarea'));
}

ko.applyBindings(new AppViewModel());