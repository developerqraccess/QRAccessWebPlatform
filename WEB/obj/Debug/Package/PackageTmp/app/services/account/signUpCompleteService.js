'use strict';
app.factory('signUpCompleteService', ['$http','$q', '$injector', 'localStorageService', 'ngAuthSettings', function ($http,$q, $injector, localStorageService, ngAuthSettings ) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;

    var serviceFactory = {};

    var _getUserInformation = function (tkn) {
        return $http.get(serviceBase + 'api/SignUpComplete/GetUserInfo/' + tkn).then(function (results) {
            return results;
        });
    };

    var _setUserInformation = function (user) {
        return $http.post(serviceBase + 'api/SignUpComplete/SetUserInfo', user).then(function (results) {
            return results;
        });
    };

    var _setAccountInformation = function (account) {
        return $http.post(serviceBase + 'api/SignUpComplete/SetAccountInfo', account).then(function (results) {
            return results;
        });
    };

    var _saveRegistration = function (registration) {
        $http = $http || $injector.get('$http');
        return $http.post(serviceBase + 'api/account/register', registration).then(function (response) {
            return response;
        });
    };

    serviceFactory.getUserInformation = _getUserInformation;
    serviceFactory.setUserInformation = _setUserInformation;
    serviceFactory.setAccountInformation = _setAccountInformation;
    serviceFactory.saveRegistration = _saveRegistration;

    return serviceFactory;

}]);