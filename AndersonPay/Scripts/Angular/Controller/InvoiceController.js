(function () {
    'use strict';

    angular
        .module('App')
        .controller('InvoiceController', InvoiceController);

    InvoiceController.$inject = ['$filter', '$window', 'InvoiceService', 'ClientService', 'TypeOfServiceService', 'ServiceService', 'CompanyAddressService'];

    function InvoiceController($filter, $window, InvoiceService, ClientService, TypeOfServiceService, ServiceService, CompanyAddressService) {
        var vm = this;

        vm.ClientId;
        vm.Address;

        //object
        vm.Service = {
            TypeOfService: null,
            Description: '',
            Rate: 0,
            Quantity: 1,
            subtotalholder: 0,
            tax: 0,
            totaltax: 0,
            clientWithholdingTax: 0
        }
        
        vm.TryS = 123;
        vm.AmountDueValue = 0;
        vm.WithholdingTaxValue;

        //array
        vm.Invoices = [];
        vm.TypeOfServices = [];
        vm.Services = [];

        //read
        vm.ReadForClients = ReadForClients;
        vm.ReadForTypeOfService = ReadForTypeOfService;
        vm.GoToUpdatePage = GoToUpdatePage;
        vm.PDF = PDF;

        vm.Initialise = Initialise;
        vm.InitialiseCrud = InitialiseCrud;
        vm.Clients;
        vm.Delete = Delete;

        //function create
        vm.CreateInvoiceService = CreateInvoiceService;
        //function delete
        vm.deleteRow = deleteRow;
        //function compute subtotal
        vm.Subtotal = Subtotal;
        //function compute Total
        vm.TotalSales = TotalSales;
        //function compute SalesTax
        vm.SalesTax = SalesTax;
        //function compute withholdingTax
        vm.WithholdingTax = WithholdingTax;
        //compute Amount Due
        vm.AmountDue = AmountDue;
        //function others
        vm.InitialiseTypeOfService = InitialiseTypeOfService;
        vm.TryF = TryF;

        vm.PDF = PDF;

        function GoToUpdatePage(invoiceId) {
            $window.location.href = '../Invoice/Update/' + invoiceId;
        }

        function TryF(taxu) {
            console.log(vm.Services);
            vm.TryS = 10;
        }

        function Initialise(invoiceId) {
            Read();
        }

        function InitialiseCrud(clientId, invoiceId, address) {
            vm.ClientId = clientId;
            ReadForClients();
            vm.AmountDueValue = 21;
            ReadForService(invoiceId);
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

        function Delete(invoiceId) {
            InvoiceService.Delete(invoiceId)
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
                    var client = $filter('filter')(vm.Clients, { ClientId: vm.ClientId })[0];
                    if (client)
                        vm.Client = client;
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
            if (!service.Quantity)
                service.Quantity = 0;

            if (!service.Quantity)
                service.Quantity = 0;

            return (service.Quantity * service.Rate);
        }

        //compute Total
        function TotalSales() {
            var total = 0.00;
            angular.forEach(vm.Services, function (service) {
                total += Subtotal(service);
            });
            return total;
        }

        //compute Sales Tax
        function SalesTax() {
            var salesTax = 0.00;

            salesTax += 12 * TotalSales() / 100;

            return salesTax;
        }

        //compute Withholding Tax
        function WithholdingTax(whTax) {
            if (whTax != undefined && whTax != NaN)
                return whTax * TotalSales() / 100;
            else
                return 0;
        }

        //compute Amount Due
        function AmountDue(whTax) {
            if (whTax != undefined && whTax != NaN)
                return TotalSales() + SalesTax() - WithholdingTax(whTax);
            else
                return 0;
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
                    angular.forEach(vm.Services, function (service) {
                        service.TypeOfService = $filter('filter')(vm.TypeOfServices, { TypeOfServiceId: service.TypeOfServiceId })[0];
                    });
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

        //PFD get data
        function PDF(invoiceId)
        {
            $window.location.href = '../Invoice/InvoiceSummary/' + invoiceId;
            //$window.href = '..("InvoiceSummary", "Invoice")';
            //$window.location.href = '@Url.Action("InvoiceSummary", "Invoice")';
        }

        function ReadForService(invoiceId) {
            ServiceService.Read(invoiceId)
                .then(function (response) {
                    vm.Services = response.data;
                    ReadForTypeOfService();
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

        function genPDF() {
            var pdf = new jsPDF('p', 'pt', 'letter');

            pdf.cellInitialize();
            pdf.setFontSize(10);
            pdf.fromHTML($('img.logo').get(0), 400, 30, { 'width': 500 });       // 20 yung default x-y
            pdf.fromHTML($('img.logo').get(0), 400, 30, { 'width': 500 });       // 20 yung default x-y
            pdf.fromHTML($('.include').get(0), 400, 30, { 'width': 500 });       // 20 yung default x-y
            pdf.fromHTML($('.include2').get(0), 50, 140, { 'width': 500 });      // 20 yung default x-y
            pdf.fromHTML($('.pdfCientName').get(0), 400, 115, { 'width': 500 });       // 20 yung default x-y


            $.each($('#tableData tr'), function (i, row) {
                $.each($(row).find("td, th"), function (j, cell) {
                    var txt = $(cell).text().trim() || " ";
                    var width = (j == 4) ? 20 : 260; //make 4th column smaller
                    var height = (j == 4) ? 3 : 20;
                    pdf.cell(50, 215, width, height, txt, i); // 50 original
                });
            });
            pdf.save('@Model.Name-@Model.SINo@Model.InvoiceId' + '.pdf');
        }
    }
})();