///<reference path="~/Content/scripts/angular/angular.js"/>
(function (ng) {
    'use strict';

    ng.module('devday.retro').controller('boardCtrl', function ($scope, retroService) {
        // Model
        $scope.columns = [];
        $scope.onLine = [];
        $scope.isLoading = false;

        function init() {
            $scope.isLoading = true;
            retroService.initialize().then(function (data) {
                $scope.isLoading = false;
                $scope.refreshOnlineList();
                retroService.Join();
            }, onError);
        };

        $scope.refreshOnlineList = function refreshOnlineList() {
            $scope.isLoading = true;
            retroService.getTest().then(function (success) {
                $scope.onLine = success;
            });
        };

        $scope.refreshBoard = function refreshBoard() {
            $scope.isLoading = true;
            retroService.getTest(function (success) {
                $scope.isLoading = false;
                $scope.columns = success;
                console.log(success);
            });
        };

        $scope.onDrop = function (data, targetColId) {
            retroService.canMoveTask(data.ColumnId, targetColId)
                .then(function (canMove) {
                    if (canMove) {
                        boardService.moveTask(data.Id, targetColId).then(function (taskMoved) {
                            $scope.isLoading = false;
                            boardService.sendRequest();
                        }, onError);
                        $scope.isLoading = true;
                    }

                }, onError);
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

        init();
    });
})(angular)