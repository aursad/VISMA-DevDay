///<reference path="~/Content/scripts/angular/angular.js"/>

(function (ng) {
    'use strict';

    ng.module('devday.retro')
        .factory('messageResource', [
            '$resource', function ($resource) {
                return $resource('/api/Message/:id', { id: "@id" }, {});
            }
        ]);
})(angular)