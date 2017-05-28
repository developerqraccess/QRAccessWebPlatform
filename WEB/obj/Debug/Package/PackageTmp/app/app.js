
var app = angular.module('app', ['ui.router', 'LocalStorageModule', 'angular-loading-bar']);

app.config(function ($stateProvider, $urlRouterProvider) {
    $stateProvider
        .state('login', {
            url: '/login',
            views: {
                'main': {
                    templateUrl: 'app/views/account/login.html',
                    controller: 'loginController'
                }
            }
        })
        .state('register', {
            url: '/register',
            views: {
                'main': {
                    templateUrl: 'app/views/signup.html',
                    controller: 'signupController'
                }
            }
        })
        .state('signUpComplete', {
            url: '/signUpComplete',
            views: {
                'main': {
                    templateUrl: 'app/views/main/signUpComplete.html',
                    controller: 'signUpCompleteController'
                }
            }
        })
        .state('dashboard', {
            url: '/dashboard',
            views: {
                'header': {
                    templateUrl: 'app/views/main/frame.html',
                    controller: 'frameController'
                },
                'content': {
                    templateUrl: 'app/views/pages/dashboard.html',
                    controller: 'dashboardController'
                }
            }
        })
        .state('presignup', {
            url: '/presignup',
            views: {
                'header': {
                    templateUrl: 'app/views/main/frame.html',
                    controller: 'frameController'
                },
                'content': {
                    templateUrl: 'app/views/pages/signUp.html',
                    controller: 'preSignUpController'
                }
            }
        })
        .state('orders', {
            url: '/orders',
            views: {
                'header': {
                    templateUrl: 'app/views/main/frame.html',
                    controller: 'frameController'
                },
                'content': {
                    templateUrl: 'app/views/pages/orders.html',
                    controller: 'ordersController'
                }
            }
        })
        .state('profile', {
            url: '/profile',
            views: {
                'header': {
                    templateUrl: 'app/views/main/frame.html',
                    controller: 'frameController'
                },
                'content': {
                    templateUrl: 'app/views/main/profile.html',
                    controller: 'profileController'
                }
            }
        });

    $urlRouterProvider.otherwise('/login');
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