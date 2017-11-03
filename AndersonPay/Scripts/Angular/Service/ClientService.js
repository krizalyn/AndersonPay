(function () {
    'use strict';

    angular
        .module('App')
        .factory('ClientService', ClientService);

    ClientService.$inject = ['$http'];

    function ClientService($http) {
        return {
            Read: Read,
            ReadClientForClientinee: ReadClientForClientinee,
            ReadClientForPosition: ReadClientForPosition,
            Delete: Delete
        }

        function Read() {
            return $http({
                method: 'POST',
                url: '/Client/Read',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function ReadClientForClientinee(clientineeId) {
            return $http({
                method: 'POST',
                url: '/Client/ReadClientForClientinee/' + clientineeId,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function ReadClientForPosition(positionId) {
            return $http({
                method: 'POST',
                url: '/Client/ReadClientForPosition/' + positionId,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function Delete(client) {
            return $http({
                method: 'DELETE',
                url: '/Client/Delete',
                data: $.param(client),
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }
    }
})();