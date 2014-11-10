(function(ng) {
    'use strict';

    ng.module('devday.retro').service('retroService', function($http, $q, $rootScope) {
        var proxy = null;

        var get = function() {
            return $http.get("/api/RetroGame").then(function(response) {
                return response.data;
            }, function(error) {
                return $q.reject(error.data.Message);
            });
        };

        var initialize = function() {

            var connection = jQuery.hubConnection();
            this.proxy = connection.createHubProxy('RetroHub');

            // Listen to the 'BoardUpdated' event that will be pushed from SignalR server
            this.proxy.on('BoardUpdated', function() {
                $rootScope.$emit("refreshBoard");
            });

            this.proxy.on('NewMember', function() {
                $rootScope.$emit("refreshOnlineList");
                console.log("newMember");
            });

            // Connecting to SignalR server        
            return connection.start()
                .then(function(connectionObj) {
                    return connectionObj;
                }, function(error) {
                    return error.message;
                });
        };

        // Call 'NotifyBoardUpdated' on SignalR server
        var sendRequest = function() {
            this.proxy.invoke('NotifyUpdated');
        };

        var joinedGame = function() {
            this.proxy.invoke("JoinGame");
        }

        return {
            initialize: initialize,
            sendRequest: sendRequest,
            Join: joinedGame,
            getTest: get
        };
    });
})(angular)