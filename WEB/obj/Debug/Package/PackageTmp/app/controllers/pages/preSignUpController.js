/// <reference path="E:\SourceCode\QRAccessColombia\Web\QRAccessWebPlatform\WEB\assets/js/index.js" />
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
    $scope.tipousuarios = [];
    $scope.usuarios = [];



    preSignUpService.typeAccount().then(function (results) {
        $scope.tipousuarios = results.data;
    })

    preSignUpService.getUsers().then(function (results) {
        $scope.usuarios = results.data;
        $('[data-toggle="tooltip"]').tooltip();
    }, function (error) {
    });



    $scope.AddUser = function (element, tipo) {
        
        preSignUpService.setUser(element, tipo.id).then(
            function (results) {
                $('#aModal').modal('hide');
                $scope.usuarios.push(results.data[0]);
                toastr.success('Propietario registrado correctamente');
                $scope.defaultUser = null;
            },
            function (error) {
                toastr.error(error.data.message);
            }
        );
    };

    $scope.UpdateUser = function (element) {
        preSignUpService.putUser(element).then(
            function (results) {
                $('#uModal').modal('hide');
                toastr.success('Propietario modificado correctamente');
            },
            function (error) {
                toastr.error('Se ha generado un error al modificar el propietario');
            }
        );
    };

    $scope.DeleteUser = function (element) {
        preSignUpService.deleteUser(element).then(
            function (results) {
                var index = $scope.usuarios.indexOf(element);
                $scope.usuarios.splice(index, 1);
                $('#dModal').modal('hide');
                toastr.success('Propietario eliminado correctamente');
            },
            function (error) {
                toastr.error('Se ha generado un error al eliminar el propietario');
            }
        );
    };

    $scope.ShowUModal = function (element) {
        $scope.usuario = null;
        $scope.usuario = element;
    };

}]);

