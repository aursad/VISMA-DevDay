///<reference path="~/Content/scripts/angular/angular.js"/>
/// <reference path="~/Content/scripts/angular-ui/angular-ui-router.js" />

(function (ng) {

    'use strict';
    ng.module('devday.retro')
    .config(['$locationProvider', '$stateProvider', '$urlRouterProvider', '$httpProvider', 'interceptionProvider', function ($locationProvider, $stateProvider, $urlRouterProvider, $httpProvider, interceptionProvider) {

        $locationProvider.html5Mode(true);

        interceptionProvider.setInterceptors($httpProvider);

        $urlRouterProvider.otherwise(function ($injector) {
            $injector.invoke([
                'spaRouteService', function (spaRouteService) {
                    spaRouteService.route({ defaultPath: '/administration/employee' });
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
            .state("employee", {
                url: "/administration/employee",
                //"abstract": true,
                //templateUrl: "sidebar"
                template: "<div ui-view></div>"
            })
    }]);

})(angular)