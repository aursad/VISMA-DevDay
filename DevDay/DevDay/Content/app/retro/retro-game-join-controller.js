///<reference path="~/Content/scripts/angular/angular.js"/>
(function (ng) {
    'use strict';

    ng.module('devday.retro').controller('joinGameCtrl', function ($scope, $state, hubService) {
        // Model
        $scope.columns = [];
        $scope.onLine = [];
        $scope.isLoading = false;
        $scope.test = "aaa";

        function init() {
            $scope.isLoading = true;
            hubService.initialize().then(function (data) {
                $scope.isLoading = false;
                hubService.Join($scope.name);
            }, onError);
        };

        $scope.joinGame = function() {
            console.log($scope.name);
            init();
            $state.go("retro-game");
        };

        $scope.refreshOnlineList = function refreshOnlineList() {
            $scope.isLoading = true;
            hubService.getTest().then(function (success) {
                $scope.onLine = success;
            });
        };

        // Listen to the 'refreshBoard' event and refresh the board as a result
        $scope.$parent.$on("refreshBoard", function (e) {
            $scope.refreshBoard();
            //toastr.success("Board updated successfully", "Success");
        });

        var onError = function (errorMessage) {
            $scope.isLoading = false;
            //toastr.error(errorMessage, "Error");
        };
    });
})(angular)