///<reference path="~/Content/scripts/angular/angular.js"/>
/// <reference path="~/Content/scripts/angular-ui/angular-ui-router.js" />

(function (ng) {

    'use strict';
    ng.module('devday.retro')
    .config(['$locationProvider', '$stateProvider', '$urlRouterProvider', function ($locationProvider, $stateProvider, $urlRouterProvider) {

        $locationProvider.html5Mode(true);


        $urlRouterProvider.otherwise(function ($injector) {
            $injector.invoke([
                'spaRouteService', function (spaRouteService) {
                    spaRouteService.route({ defaultPath: '/retro' });
                }
            ]);
        });

        $urlRouterProvider.rule(function ($injector, $location) {
            var path = $location.path();
            if (path != '/' && path.slice(-1) === '/') {
                $location.replace().path(path.slice(0, -1));
            }
        });

        $stateProvider
            .state("retro", {
                url: "/retro",
                templateUrl: "game-join-template",
                controller: "joinGameCtrl"
            })
            .state("retro-join", {
                url: "/retro/join",
                controller: "joinGameCtrl",
                templateUrl: "game-join-template"
            })
            .state('retro-game', {
                url: '/retro/:id',
                controller: "boardCtrl",
                templateUrl: "game-template"
            });
    }]);

})(angular)