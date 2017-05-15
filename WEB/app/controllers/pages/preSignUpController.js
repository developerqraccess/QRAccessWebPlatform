'use strict';
app.controller('preSignUpController', ['$scope', 'preSignUpService', function ($scope , preSignUpService) {

    $scope.defaultUser = {
        Id : null,
        Cedula: null,
        Nombre: null,
        Apellidos: null,
        FechaNacimiento: null,
        Correo: null,
        Direccion: null,
        Movil: null,
        Telefono: null
    };

    $scope.usuario = {};

    $scope.usuarios = [];

    preSignUpService.getUsers().then(function (results) {
        $scope.usuarios = results.data;
        $('[data-toggle="tooltip"]').tooltip();
    }, function (error) {
    });

    $scope.AddUser = function (element) {

        preSignUpService.setUser(element).then(
            function (results) {
                alert(results.data[0]);
            },
            function (error) {

            }
        );
    };

    $scope.UpdateUser = function (element) {
        preSignUpService.putUser(element).then(
            function (results) {

            },
            function (error) {

            }
        );
    };

    $scope.DeleteUser = function (id) {
        preSignUpService.deleteUser(id).then(
            function (results) {
                alert('OK');
            },
            function (error) {

            }
        );
    };

    $scope.ShowUModal = function (element) {
        $scope.usuario = null;
        $scope.usuario = element;
    };

}]);

