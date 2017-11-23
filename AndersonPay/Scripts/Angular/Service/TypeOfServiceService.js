(function () {
    'use strict';

    angular
        .module('App')
        .factory('TypeOfServiceService', TypeOfServiceService);

    TypeOfServiceService.$inject = ['$http'];

    function TypeOfServiceService($http) {
        return {
            Read: Read,
            ReadTypeOfServiceForTypeOfServiceinee: ReadTypeOfServiceForTypeOfServiceinee,
            ReadTypeOfServiceForPosition: ReadTypeOfServiceForPosition,
            Delete: Delete
        }

        function Read() {
            return $http({
                method: 'POST',
                url: '/TypeOfService/Read',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function ReadTypeOfServiceForTypeOfServiceinee(typeOfServiceineeId) {
            return $http({
                method: 'POST',
                url: '/TypeOfService/ReadTypeOfServiceForTypeOfServiceinee/' + typeOfServiceineeId,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function ReadTypeOfServiceForPosition(positionId) {
            return $http({
                method: 'POST',
                url: '/TypeOfService/ReadTypeOfServiceForPosition/' + positionId,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }


        function Delete(typeOfService) {
            return $http({
                method: 'DELETE',
                url: '/TypeOfService/Delete',
                data: $.param(typeOfService),
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }
    }
})();