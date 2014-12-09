(function(ng) {
    'use strict';

    ng.module('devday.retro').service('hubService', function($http, $q, $rootScope) {
        var proxy = null;

        var initialize = function() {

            var connection = jQuery.hubConnection();
            this.proxy = connection.createHubProxy('RetroHub');

            // Listen to the 'BoardUpdated' event that will be pushed from SignalR server
            this.proxy.on('BoardUpdated', function() {
                $rootScope.$emit("refreshBoard");
                console.log("refreshBoard");
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
            Join: joinedGame
        };
    });
})(angular)