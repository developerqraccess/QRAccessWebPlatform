'use strict';
app.controller('usersController', ['$scope', 'usersService', 'DTOptionsBuilder', 'DTColumnBuilder', function ($scope, usersService, DTOptionsBuilder, DTColumnBuilder) {

    $scope.usuarios = [];
    $scope.permisos = [];
    $scope.permiso = {};


    $scope.dtColumns = [
            //DTColumnBuilder.newColumn("CustomerID", "Customer ID"),
            //DTColumnBuilder.newColumn("CompanyName", "Company Name"),
            //DTColumnBuilder.newColumn("ContactName", "Contact Name"),
            //DTColumnBuilder.newColumn("Phone", "Phone"),
            //DTColumnBuilder.newColumn("City", "City")
    ]

    usersService.getUsers().then(function (results) {
       
        $scope.usuarios = results.data;
        $('[data-toggle="tooltip"]').tooltip();
    }, function (error) {
    });


    
    $scope.getPermisos = function (element) {
        usersService.getPermisionsUsers(element).then(
            function (results) {
                $scope.permisos =results.data;
                toastr.success('Permisos Cargados correctamente');
              },
            function (error) {
                toastr.error(error.data.message);
            }
        );
    };


    $scope.UpdatePermisos = function (element) {
        usersService.putPermisions(element).then(
            function (results) {
                $('#uModal').modal('hide');
                toastr.success('Permiso modificado correctamente');
            },
            function (error) {
                toastr.error('Se ha generado un error al modificar el Permiso');
            }
        );
    };


    $scope.dtOptions = DTOptionsBuilder.newOptions().withOption()
       .withPaginationType('full_numbers')
       .withDisplayLength(10);


    $scope.ShowUModal = function (element) {
        $scope.permiso = null;
        $scope.permiso = element;
    };

}]);
