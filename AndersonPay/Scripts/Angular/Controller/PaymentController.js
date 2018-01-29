(function () {
    'use strict';

    angular
        .module('App')
        .controller('PaymentController', PaymentController);

    PaymentController.$inject = ['$window', 'PaymentService'];

    function PaymentController($window, PaymentService) {
        var vm = this;

        vm.Payments;

        vm.GoToUpdatePage = GoToUpdatePage;
        vm.Initialise = Initialise;

        vm.Delete = Delete;

        function GoToUpdatePage(paymentId) {
            $window.location.href = '../Payment/Update/' + paymentId;
        }

        function Initialise() {

            Read();
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

    }
})();