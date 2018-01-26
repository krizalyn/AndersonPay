(function () {
    'use strict';

    angular
        .module('App')
        .controller('PaymentController', PaymentController);

    PaymentController.$inject = ['$window', 'PaymentService', 'InvoiceService'];

    function PaymentController($window, PaymentService, InvoiceService) {
        var vm = this;

        vm.Payments;
        vm.Invoices;

        vm.InvoiceId;

        vm.GoToUpdatePage = GoToUpdatePage;
        vm.Initialise = Initialise;

        vm.Delete = Delete;

        vm.ReadForInvoice = ReadForInvoice;

        function GoToUpdatePage(paymentId) {
            $window.location.href = '../Payment/Update/' + paymentId;
        }

        function Initialise() {

            Read();
            ReadForInvoice();
        }

        function Read() {
            PaymentService.Read()
                .then(function (response) {
                    vm.Payments = response.data;
                })
                .catch(function (data, status) {
                    new PNotify({
                        title: status,
                        text: data,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });

                });
        }

        function Delete(payment) {
            PaymentService.Delete(payment)
                .then(function (response) {
                    Read();
                })
                .catch(function (data, status) {

                });
        }

        function ReadForInvoice() {
            InvoiceService.Read()
                .then(function (response) {
                    vm.Invoices = response.data;
                    var invoice = $filter('filter')(vm.Invoices, { InvoiceId: vm.InvoiceId })[0];
                    if (invoice)
                        vm.Invoice = invoice;
                })
                .catch(function (data, status) {
                    new PNotify({
                        title: status,
                        text: data,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });

                });
        }
    }
})();