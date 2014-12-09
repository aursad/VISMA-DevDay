///<reference path="~/Content/scripts/angular/angular.js"/>

(function (ng) {
    'use strict';

    ng.module('devday.retro')
        .factory('personResource', [
            '$resource', function ($resource) {
                return $resource('/api/Person/:id', { id: "@id" }, {});
            }
        ]);
})(angular)