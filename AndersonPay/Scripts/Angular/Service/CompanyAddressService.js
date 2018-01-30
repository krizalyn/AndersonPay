(function () {
    'use strict';

    angular
        .module('App')
        .factory('CompanyAddressService', CompanyAddressService);

    CompanyAddressService.$inject = ['$http'];

    function CompanyAddressService($http) {
        return {
            Read: Read,
            ReadCompanyAddressServiceinee: ReadCompanyAddressServiceinee,
            ReadCompanyAddressForPosition: ReadCompanyAddressForPosition
        }

        function Read() {
            return $http({
                method: 'POST',
                url: '/CompanyAddress/Read',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function ReadCompanyAddressServiceinee(companyAddressineeId) {
            return $http({
                method: 'POST',
                url: '/CompanyAddress/ReadCompanyAddressServiceinee/' + companyAddressineeId,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function ReadCompanyAddressForPosition(positionId) {
            return $http({
                method: 'POST',
                url: '/CompanyAddress/ReadCompanyAddressForPosition/' + positionId,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }
    }
})();