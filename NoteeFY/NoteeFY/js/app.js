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
        var list = $('.notepad');
        list.isotope({
            transformsEnabled: false,
            itemSelector: '.single-note',
            onLayout: function () {
                list.css('overflow', 'visible');
            }
        });
        list.sortable({
            cursor: 'move',
            start: function (event, ui) {
                ui.item.addClass('grabbing moving').removeClass('isotopey');
                ui.placeholder.addClass('starting').removeClass('moving').css({
                    top: ui.originalPosition.top,
                    left: ui.originalPosition.left
                });
                list.isotope('reloadItems');
            },
            change: function (event, ui) {
                ui.placeholder.removeClass('starting');
                list.isotope('reloadItems').isotope({
                    sortBy: 'original-order'
                });
            },
            beforeStop: function (event, ui) {
                ui.placeholder.after(ui.item);
            },
            stop: function (event, ui) {
                ui.item.removeClass('grabbing').addClass('isotopey');
                list.isotope('reloadItems').isotope({
                    sortBy: 'original-order'
                }, function () {
                    if (!ui.item.is('.grabbing')) {
                        ui.item.removeClass('moving');
                    }
                });
            }
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
    $('.notepad').isotope('reloadItems').isotope();
}

NoteeFy.refreshTextarea = function () {
    autosize($('textarea'));
}

ko.applyBindings(new AppViewModel());