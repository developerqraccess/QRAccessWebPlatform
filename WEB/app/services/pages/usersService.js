'use strict';
app.factory('usersService', ['$http', 'ngAuthSettings', function ($http, ngAuthSettings) {

    
    var serviceBase = ngAuthSettings.apiServiceBaseUri;

    var usersServiceFactory = {};

    var _getusers = function () {

        return $http.get(serviceBase + 'api/PreSignup/GetAll').then(function (results) {
            return results;
        });
    };


    var _getPermisionsUsers = function (user)
    {
        return $http.post(serviceBase + 'api/Permisions/GetPermisionsUser', user).then(function (results) {
            return results;
        });

    }



    var _PutPermisions = function (permiso) {
        return $http.post(serviceBase + 'api/Permisions/Put', permiso).then(function (results) {
            return results;
        });
    }

    usersServiceFactory.getUsers = _getusers;
    usersServiceFactory.getPermisionsUsers = _getPermisionsUsers;
    usersServiceFactory.putPermisions = _PutPermisions;

    return usersServiceFactory;
}]);