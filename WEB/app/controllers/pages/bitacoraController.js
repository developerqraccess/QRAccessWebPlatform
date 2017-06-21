'use strict';
app.controller('bitacoraController', ['$scope', 'bitacoraService', 'DTOptionsBuilder', 'DTColumnBuilder', function ($scope, bitacoraService, DTOptionsBuilder, DTColumnBuilder) {

    $scope.bitacoras = [];
  


    $scope.dtColumns = []

    bitacoraService.getListBitacora().then(function (results) {
        
        $scope.bitacoras = results.data;
        $('[data-toggle="tooltip"]').tooltip();
     }, function (error) {
    });



    $scope.dtOptions = DTOptionsBuilder.newOptions().withOption()
       .withPaginationType('full_numbers')
       .withDisplayLength(10);


   
}]);
