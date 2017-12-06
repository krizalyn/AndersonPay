(function () {
    'use strict';

    angular
        .module('App')
        .controller('InvoiceController', InvoiceController);

    InvoiceController.$inject = ['$window', 'InvoiceService','ClientService'];

    function InvoiceController($window, InvoiceService, ClientService) {
        var vm = this;

        //object
        vm.InvoiceServices = {
            TypeOfService: null,
            Description: '',
            Rate: 0,
            Quantity: 0,
            subtotalholder:0,
            tax: 0,
            totaltax: 0

            
        }
        //array for invoice
        vm.Invoices;
        //read
        vm.ReadForClients = ReadForClients;
        //vm.ReadForTypeOfService = ReadForTypeOfService;
        vm.GoToUpdatePage = GoToUpdatePage;

        vm.Initialise = Initialise;
        vm.Clients;
        vm.Delete = Delete;

        //array
        vm.Invoice = [];
        vm.TypeOfServices = [];
        //function create
        vm.CreateInvoiceService = CreateInvoiceService;
        //function delete
        vm.deleteRow = deleteRow;
        //function compute subtotal
        vm.Subtotal = Subtotal;
        //function compute Total
        vm.Total = Total;
        //function others
        vm.InitialiseTypeOfService = InitialiseTypeOfService;


        function GoToUpdatePage(invoiceId) {
            $window.location.href = '../Invoice/Update/' + invoiceId;
        }

        function Initialise() {
            Read();
            ReadForClients();
            //ReadForTypeOfService();
        }

        function Read() {
            InvoiceService.Read()
                .then(function (response) {
                    vm.Invoices = response.data;
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

        function Delete(invoice) {
            InvoiceService.Delete(invoice)
                .then(function (response) {
                    Read();
                })
                .catch(function (data, status) {


                });
        }
        function ReadForClients() {
            ClientService.Read()
                .then(function (response) {
                    vm.Clients = response.data;
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
        //create row and column for computation of subtotal
        function CreateInvoiceService() {
            var invoiceService = angular.copy(vm.InvoiceServices);
            vm.Invoice.push(invoiceService);
        }

        function InitialiseTypeOfService(typeOfServices) {
            InvoiceService.List()
                .then(function (response) {
                    vm.TypeOfService = response.data;
                })
        }

        //compute subtotal
        function Subtotal(invoiceService) {

            return (invoiceService.Quantity * invoiceService.Rate);
        }

        //compute Total
        function Total() {
            var total = 0;
            angular.forEach(vm.Invoice, function (invoiceService) {
                total += Subtotal(invoiceService);
            });
            return total;

        }

        //delete row of computation on adding service
        function deleteRow(index) {
            vm.Invoice.splice(index, 1);

        }
        ////read for Type Of Service
        //function ReadForTypeOfService() {
        //    TypeOfServiceService.Read()
        //        .then(function (response) {
        //            vm.TypeOfServices = response.data;
        //        })
        //        .catch(function (data, status) {
        //            new PNotify({
        //                title: status,
        //                text: data,
        //                type: 'error',
        //                hide: true,
        //                addclass: "stack-bottomright"
        //            });

        //        });
        //}
    }
})();