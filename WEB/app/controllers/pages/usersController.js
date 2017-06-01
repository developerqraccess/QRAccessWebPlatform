'use strict';
app.controller('usersController', ['$scope', 'usersService', function ($scope, usersService) {

    debugger;
    $scope.usuarios = [];


    usersService.getUsers().then(function (results) {
        $scope.usuarios = results.data;
        $('[data-toggle="tooltip"]').tooltip();
    }, function (error) {
    });



}]);
