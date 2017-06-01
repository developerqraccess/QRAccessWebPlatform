'use strict';
app.factory('usersService', ['$http', 'ngAuthSettings', function ($http, ngAuthSettings) {

    debugger;
    var serviceBase = ngAuthSettings.apiServiceBaseUri;

    var usersServiceFactory = {};

    var _getusers = function () {

        return $http.get(serviceBase + 'api/PreSignup/GetAll').then(function (results) {
            return results;
        });
    };

    usersServiceFactory.getUsers = _getusers;

    return usersServiceFactory;
}]);