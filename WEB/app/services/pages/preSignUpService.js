'use strict';
app.factory('preSignUpService', ['$http', 'ngAuthSettings', function ($http, ngAuthSettings) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;

    var serviceFactory = {};

    var _getUsers = function () {

        return $http.get(serviceBase + 'api/PreSignup').then(function (results) {
            return results;
        });
    };
    var _setUser = function (user) {
        return $http.post(serviceBase + 'api/PreSignup', user).then(function (results) {
            return results;
        });

    };

    var _PutUser = function (user) {
        return $http.put(serviceBase + 'api/PreSignup', user).then(function (results) {
            return results;
        });
    }

    var _DeleteUser = function (id) {
        return $http.delete(serviceBase + 'api/PreSignup', { 'id': id }).then(function (results) {
            return results;
        });
    }

    serviceFactory.getUsers = _getUsers;
    serviceFactory.setUser = _setUser;
    serviceFactory.putUser = _PutUser;
    serviceFactory.deleteUser = _DeleteUser;

    return serviceFactory;
}]);