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
            Delete: Delete,
            List: List
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

        function Delete(invoiceId) {
            return $http({
                method: 'DELETE',
                url: '/Invoice/Delete/' + invoiceId,
                //data: $.param(invoiceId),
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function List() {
            return $http({
                method: 'POST',
                url: '../AndersonPay/TypeOfServices',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }
        
        function PDF(InvoiceId)
        {
            return $http({
                method: 'POST',
                url: '/Invoice/Read',
                data: $.param(InvoiceId),
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }
    }
})();