///<reference path="~/Content/scripts/angular/angular.js"/>

(function (ng) {
    'use strict';

    ng.module('devday.retro')
        .factory('retroGame', [
            '$resource', function ($resource) {
                return $resource('/api/RetroGame/:id', { id: "@id" }, {
                    update: { method: 'PUT' }
                });
            }
        ]);
})(angular)