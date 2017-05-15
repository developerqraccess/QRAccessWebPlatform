
var app = angular.module('app', ['ngRoute', 'LocalStorageModule', 'angular-loading-bar']);

app.config(function ($locationProvider, $routeProvider) {

    $locationProvider.hashPrefix('');

    $routeProvider.when("/login", {
        controller: "loginController",
        templateUrl: "/app/views/account/login.html"
    });

    $routeProvider.when("/dashboard", {
        controller: "dashboardController",
        templateUrl: "/app/views/main/dashboard.html"
    });

    $routeProvider.when("/signup", {
        controller: "signUpController",
        templateUrl: "/app/views/pages/signUp.html"
    });

    $routeProvider.when("/orders", {
        controller: "ordersController",
        templateUrl: "/app/views/pages/orders.html"
    });

    $routeProvider.otherwise({ redirectTo: "/login" });

});

app.constant('ngAuthSettings', {
    apiServiceBaseUri: 'http://localhost:26264/',
    clientId: 'ngAuthApp'
});

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});

app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);


