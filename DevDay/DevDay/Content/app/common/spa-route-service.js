(function (ng) {
    'use strict';

    ng.module('common')
        .factory('spaRouteService', [
            '$location', '$window', '$state', function ($location, $window, $state) {


                String.prototype.indexOfInsensitive = function (arg1, arg2) {
                    return this.toLowerCase().indexOf(arg1.toLowerCase(), arg2);
                };


                return {
                    route: function (options) {
                        var currentPath = $location.path().toLowerCase();

                        var defaultPath = '/';

                        if (options && options.defaultPath) {
                            defaultPath = options.defaultPath;
                        }

                        var parentPath = $state.$current.parent !== undefined ? $state.$current.parent.url.sourcePath : defaultPath;

                        if (currentPath.indexOfInsensitive(parentPath) === -1) {
                            $window.location = currentPath;
                        } else {
                            $location.path(parentPath);
                        }
                    }
                };

            }
        ]);


}(angular));
