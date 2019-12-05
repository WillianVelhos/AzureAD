var locationApp = angular.module('locationApp', ['ngRoute', 'AdalAngular']);

locationApp.config(['$locationProvider', '$httpProvider', 'adalAuthenticationServiceProvider', function ($locationProvider, $httpProvider, adalProvider) {

    var endpoints = {
        "https://localhost:44363/": "https://localhost:44363/",
    };

    $locationProvider.html5Mode(true).hashPrefix('!');

    adalProvider.init(
        {
            instance: 'https://login.microsoft.com/',
            tenant: "willianAD.onmicrosoft.com",
            clientId: "0afdb332-4bff-4f23-9f47-dd1f20d29e6c",
            endpoints: endpoints
        }, $httpProvider);

}]);

var locationController = locationApp.controller('locationController', [
    '$scope', '$http', 'adalAuthenticationService', function ($scope, $http, adalService) {

        $scope.getLocation = function () {
            $http.get('http://localhost:53506/api/location?teste=adssadasd').then(function (location) {
                $scope.city = location.data;
            });
        }

        $scope.login = function () {
            adalService.login()
        }

        $scope.logout = function () {
            adalService.logout()
        }

    }]);