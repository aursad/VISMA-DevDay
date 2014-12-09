///<reference path="~/Content/scripts/angular/angular.js"/>
(function (ng) {
    'use strict';

    ng.module('devday.retro').controller('boardCtrl', function ($scope, hubService, $stateParams, personResource, messageResource) {
        // Model
        $scope.columns = [];
        $scope.onLine = [];
        $scope.isLoading = false;
        $scope.retroId = $stateParams.id;

        function init() {
            $scope.isLoading = true;
            hubService.initialize().then(function (data) {
                $scope.isLoading = false;
                $scope.refreshOnlineList();
            }, onError);
        };

        $scope.refreshOnlineList = function refreshOnlineList() {
            $scope.isLoading = true;
            personResource.query({ id: $scope.retroId }, function (success) {
                $scope.isLoading = false;
                $scope.onLine = success;
                console.log(success);
            });
        };

        var loadMessages = function() {
            messageResource.get({ id: $scope.retroId }, function(success) {
                $scope.messages = success;
            });
        }

        $scope.refreshBoard = function refreshBoard() {
            $scope.isLoading = true;
/*            retroGame.get({ id: $scope.retroId }, function(success) {
                $scope.isLoading = false;
                $scope.columns = success;
                console.log(success);
            });*/
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

        $scope.refreshOnlineList();
        loadMessages();
    });
})(angular)