'use strict';
app.factory('bitacoraService', ['$http', 'ngAuthSettings', function ($http, ngAuthSettings) {


    var serviceBase = ngAuthSettings.apiServiceBaseUri;

    var bitacoraServiceFactory = {};

    var _getListBitacora = function () {

        return $http.get(serviceBase + 'api/Bitacora/Get').then(function (results) {
            return results;
        });
    };


   
    bitacoraServiceFactory.getListBitacora = _getListBitacora;
   

    return bitacoraServiceFactory;
}]);