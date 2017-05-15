'use strict';
app.controller('frameController', ['$scope', '$location', 'authService', function ($scope, $location, authService) {
    $('#side-menu').metisMenu();

    $scope.logOut = function () {
        authService.logOut();
        $location.path('/login'); 
    }

    $scope.authentication = authService.authentication;
}]);