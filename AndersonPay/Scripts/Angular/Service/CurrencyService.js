(function () {
    'use strict';

    angular
        .module('App')
        .factory('CurrencyService', CurrencyService);

    CurrencyService.$inject = ['$http'];

    function CurrencyService($http) {
        return {
            Read: Read
        }

        function Read(id) {
            return $http({
                method: 'POST',
                url: '/Currency/Read/' + id,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }
    }
})();