(function () {
    'use strict';

    angular
        .module('App')
        .controller('InvoiceController', InvoiceController);

    InvoiceController.$inject = ['$window', 'InvoiceService', 'ClientService', 'TypeOfServiceService'];

    function InvoiceController($window, InvoiceService, ClientService, TypeOfServiceService) {
        var vm = this;
        //object
        vm.Service = {
            TypeOfService: null,
            Description: '',
            Rate: 0,
            Quantity: 1,
            subtotalholder:0,
            tax: 0,
            totaltax: 0

            
        }
        //array
        vm.Invoices = [];
        vm.TypeOfServices = [];
        vm.Services = [];
        //read
        vm.ReadForClients = ReadForClients;
        vm.ReadForTypeOfService = ReadForTypeOfService;
        vm.GoToUpdatePage = GoToUpdatePage;

        vm.Initialise = Initialise;
        vm.Clients;
        vm.Delete = Delete;

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
        //function SINo
        vm.SINo = SINo;

        vm.SingleSelected;
        vm.TypeOfServiceServices = [];
        vm.TypeOfService;


        function GoToUpdatePage(invoiceId) {
            $window.location.href = '../Invoice/Update/' + invoiceId;
        }

        function Initialise() {
            Read();
            ReadForClients();
            ReadForTypeOfService();
            ReadCompanyBranch();

            ReadTypeOfService();

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
            var service = angular.copy(vm.Service);
            vm.Services.push(service);
        }

        function InitialiseTypeOfService(typeOfServices) {
            InvoiceService.List()
                .then(function (response) {
                    vm.TypeOfService = response.data;
                })
        }

        //compute subtotal
        function Subtotal(service) {

            return (service.Quantity * service.Rate);
        }

        //compute Total
        function Total() {
            var total = 0;
            angular.forEach(vm.Services, function (service) {
                total += Subtotal(service);
            });
            return total;

        }
        //Sales Tax
        function SalesTax() {
            var total = 0.00;

        }

        //delete row of computation on adding service
        function deleteRow(index) {
            vm.Services.splice(index, 1);

        }
        //read for Type Of Service
        function ReadForTypeOfService() {
            TypeOfServiceService.Read()
                .then(function (response) {
                    vm.TypeOfServices = response.data;
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
        //SIno
        function SINo(SINoCode)
        {
            var SINoCode = "";
            return SINoCode;
        }
        function CompanyBranch(BranchCode)
        {
            var BranchCode = "BCode";
            return BranchCode;
        }

        //Branch Location
        function ReadCompanyBranch()
        {
            vm.CompanyBranches = [
            { Address: "11/F Wynsum Corporate Plaza, #22 F. Ortigas Jr. Road Ortigas Center,Pasig City Philippines ", CompanyAddress: 'Wynsum', SINo: 'WNSM-', TIN: '0001' },
            { Address: "20/F Robinsons Cybergate Tower 3, Pioneer Street, Mandaluyong City, Pioneer St, Mandaluyong, Metro Manila", CompanyAddress: 'Cybergate 3', SINo: 'CG3-', TIN: '0002' },
            { Address: "Ecotower Building Unit 1504, 32nd Street corner 9th avenue Bonifacio Global City, Taguig City Philippines ", CompanyAddress: 'Ecotower', SINo: 'ECT-', TIN: '0003' },
            ];
        }
        //ReadTypeOfService
        function ReadTypeOfService() {
            vm.TypeOfServiceServices = [
            { TypeOfService: "Seat Leasing", Description: 'Seat Leasing Description' },
            { TypeOfService: "BPO Services", Description: 'BPO Services Description' },
            { TypeOfService: "Payroll", Description: 'Payroll Description' },
            ];
        }
    }
