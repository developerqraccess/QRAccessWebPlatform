'use strict';
app.controller('frameController', ['$scope', '$location', 'authService', function ($scope, $location, authService) {
    $('#side-menu').metisMenu();

    $scope.logOut = function () {
        authService.logOut();
        $location.path('/login'); 
    }

    $('#side-menu').metisMenu();
    if ($(window).width() < 768) {
        setTimeout(function () {
            $('.sidebar-nav').removeAttr('aria-expanded');
            $('.sidebar-nav').removeClass('in');
            $('.sidebar-nav').addClass('collapse');

        }, 100);
    }

    $scope.authentication = authService.authentication;
}]);