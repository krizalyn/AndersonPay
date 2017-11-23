(function () {
    'use strict';

    angular
        .module('App')
        .factory('InvoiceService', InvoiceService);

    InvoiceService.$inject = ['$http'];

    function InvoiceService($http) {
        return {
            Read: Read,
            ReadInvoiceForInvoiceinee: ReadInvoiceForInvoiceinee,
            ReadInvoiceForPosition: ReadInvoiceForPosition,
            Delete: Delete
        }

        function Read() {
            return $http({
                method: 'POST',
                url: '/Invoice/Read',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function ReadInvoiceForInvoiceinee(invoiceineeId) {
            return $http({
                method: 'POST',
                url: '/Invoice/ReadInvoiceForInvoiceinee/' + invoiceineeId,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function ReadInvoiceForPosition(positionId) {
            return $http({
                method: 'POST',
                url: '/Invoice/ReadInvoiceForPosition/' + positionId,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }


        function Delete(invoice) {
            return $http({
                method: 'DELETE',
                url: '/Invoice/Delete',
                data: $.param(invoice),
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }
    }
})();