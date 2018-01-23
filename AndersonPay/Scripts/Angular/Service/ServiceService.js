(function () {
    'use strict';

    angular
        .module('App')
        .factory('ServiceService', ServiceService);

    ServiceService.$inject = ['$http'];

    function ServiceService($http) {
        return {
            Read: Read
        }

        function Read(id) {
            return $http({
                method: 'POST',
                url: '/Service/Read/' + id,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }
    }
})();