﻿///<reference path="~/Content/scripts/angular/angular.js"/>
(function (ng) {
    'use strict';

    ng.module('devday.retro').controller('joinGameCtrl', function ($scope, $state, hubService, retroGame) {
        $scope.isLoading = false;

        function init() {
            $scope.isLoading = true;
            hubService.initialize().then(function (data) {
                $scope.isLoading = false;
                hubService.Join($scope.name);
            }, onError);
        };

        $scope.joinGame = function() {
            console.log($scope.name);
            retroGame.save({}, { "name": $scope.name }, function (success) {
                console.log("Hub id: " + success.id);
                $state.go("retro-game", { id: success.id });
            });
            
        };

        var onError = function (errorMessage) {
            $scope.isLoading = false;
            //toastr.error(errorMessage, "Error");
        };
    });
})(angular)