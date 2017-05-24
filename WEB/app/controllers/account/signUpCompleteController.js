'use strict';
app.controller('signUpCompleteController', ['$scope', 'signUpCompleteService', '$location', '$timeout', function ($scope, signUpCompleteService, $location, $timeout) {
    
    $scope.token = $location.search().token;
    $scope.userAccount = {};
    $scope.usuario = {};
    $scope.cuenta ={};

    $scope.fases = {
        paso1 : false,
        paso2 : false,
        paso3 : false

    };

    $scope.savedSuccessfully = false;
    $scope.message = "";

    $scope.registration = {
        userName: "",
        password: "",
        confirmPassword: ""
    };

    signUpCompleteService.getUserInformation($scope.token).then(function (results) {
        $scope.userAccount = results.data[0];
        $scope.setUserValues($scope.userAccount);
        $scope.setAccountValues($scope.userAccount);

    }, function (error) {});

    $scope.GuardarUsuario = function (elem) {
        signUpCompleteService.setUserInformation(elem).then(function (results) {
            $scope.fases.paso1 = true;
        }, function (error) {});
    }

    $scope.GuardarCuenta = function (elem) {
        if ($scope.validarPasos()) {
            signUpCompleteService.setAccountInformation(elem).then(function (results) {
            }, function (error) {});

            $scope.registration.userName = elem.nombreUsuario;
            $scope.registration.password = elem.contrasena;
            $scope.registration.confirmPassword = elem.contrasena;

            $scope.AuthSignUp();

        }

    }

    $scope.AuthSignUp = function () {
        signUpCompleteService.saveRegistration($scope.registration).then(function (response) {
            $scope.savedSuccessfully = true;
            $scope.message = "User has been registered successfully, you will be redicted to login page in 2 seconds.";
            startTimer();
        },
         function (response) {
             var errors = [];
             for (var key in response.data.modelState) {
                 for (var i = 0; i < response.data.modelState[key].length; i++) {
                     errors.push(response.data.modelState[key][i]);
                 }
             }
             $scope.message = "Failed to register user due to:" + errors.join(' ');
         });
    }

    var startTimer = function () {
        var timer = $timeout(function () {
            $timeout.cancel(timer);
            $location.path('/login');
        }, 2000);
    }

    $scope.setUserValues = function (elem) {
        $scope.usuario.id = elem.idUsuario;
        $scope.usuario.cedula = elem.cedula;
        $scope.usuario.nombre = elem.nombre;
        $scope.usuario.apellidos = elem.apellidos;
        $scope.usuario.fechaNacimiento = elem.fechaNacimiento;
        $scope.usuario.correo = elem.correo;
        $scope.usuario.direccion = elem.direccion;
        $scope.usuario.movil = elem.movil;
        $scope.usuario.telefono = elem.telefono;
    }

    $scope.setAccountValues = function (elem) {
        $scope.cuenta.estado = elem.estado;
        $scope.cuenta.fechaRegistro = elem.fechaRegistro;
        $scope.cuenta.fechaVencimiento = elem.fechaVencimiento;
        $scope.cuenta.id  = elem.idCuenta;
        $scope.cuenta.idUsuario = elem.idUsuario;
        $scope.cuenta.nombreUsuario = elem.nombreUsuario
        $scope.cuenta.tipo = elem.tipo;
        $scope.cuenta.contrasena = null,
        $scope.cuenta.tokenActivacion = elem.tokenActivacion;
        $scope.cuenta.tokenVencimiento = elem.tokenVencimiento;
    }

    $scope.validarPasos = function () {
        if (!$scope.fases.paso1) {
            return false;
        }
        else if (!$scope.fases.paso2) {
            return false;
        }
        else {
            return true;
        }
    }

}]);

