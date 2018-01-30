(function () {
    'use strict';

    angular
        .module('App')
        .factory('TaxTypeService', TaxTypeService);

    TaxTypeService.$inject = ['$http'];

    function TaxTypeService($http) {
        return {
            Read: Read,
            ReadTaxTypeServiceinee: ReadTaxTypeServiceinee,
            ReadTaxTypeForPosition: ReadTaxTypeForPosition
        }

        function Read() {
            return $http({
                method: 'POST',
                url: '/TaxType/Read',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function ReadTaxTypeServiceinee(currencyineeId) {
            return $http({
                method: 'POST',
                url: '/TaxType/ReadTaxTypeServiceinee/' + taxTypeineeId,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function ReadTaxTypeForPosition(positionId) {
            return $http({
                method: 'POST',
                url: '/TaxType/ReadTaxTypeForPosition/' + positionId,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }
    }
})();