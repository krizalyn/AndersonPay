(function () {
    'use strict';

    angular
        .module('App')
        .controller('AndersonPayController', AndersonPayController);
    
    AndersonPayController.$inject = ['AndersonPayService'];

    function AndersonPayController(AndersonPayService) {
        var vm = this;
        //object
        vm.InvoiceService = {
            TypeOfService: null,
            Description: '',
            Rate: 0,
            Quantity: 0,
            subtotal: 0,
            subtotalholder:0,
            tax: 0,
            totaltax: 0

            
        }
        //array
        vm.InvoiceServices = [];
        vm.TypeOfServices = [];
        vm.Subtotal = 0;
        //vm.List = List;

        //function create
        vm.CreateInvoiceService = CreateInvoiceService;
        //function delete
        vm.deleteRow = deleteRow;
        //function others
        vm.Initialise = Initialise;
        //function compute subtotal
        //vm.getSubtotal = getSubtotal;


        function CreateInvoiceService() {
            var invoiceService = angular.copy(vm.InvoiceService);
            vm.InvoiceServices.push(invoiceService);
        }

        function Initialise(typeOfServices) {
            AndersonPayService.List()
            .then(function (response) {
                vm.TypeOfServices = response.data;
            })
          }

       vm.subtotal = function () {
            invoiceService.subtotal = 0;
            angular.forEach(vm.InvoiceService.InvoiceServices, function (invoiceService) {
                subtotal += invoiceService.Rate * invoiceService.Quantity;
            })

            return subtotal;
        }

       vm.subtotalholder = function(invoiceService)
       {
           if(invoiceService)
           {
               invoiceService.subtotalholder = invoiceService.Rate * invoiceService.Quantity;
               vm.Subtotal += invoiceService.Quantity;
               vm.Subtotalholder += invoiceService.subtotalholder;
           }
       }
       
        vm.totaltaxholder = function()
        {
            var totaltaxholder = 0;
            var taxholder = 100;
            angular.forEach(vm.InvoiceService.InvoiceServices, function (invoiceService)
            {
                totaltaxholder = (invoiceService.subtotalholder / taxholder) * invoiceService.tax;
            })
        }

        vm.totaltax = function()
        {
            var totaltax = 0;
            angular.forEach(vm.InvoiceService.InvoiceServices, function (invoiceService)
            {
                totaltax += invoiceService.subtotal + vm.totaltaxholder
            })
        }
        function deleteRow(index) {
            vm.InvoiceServices.splice(index, 1);

        }
    }

})();

(function () {
    'use strict';

    angular
    .module('App')
    .factory('AndersonPayService', AndersonPayService);

    AndersonPayService.$inject = ['$http'];
        
    function AndersonPayService($http) {
        return {
            List: List
        }

        function List() {
            return $http({
                method: 'POST',
                url: '../AndersonPay/TypeOfServices',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

    }
})();
//MASTER WAS HERE HAKHAK !!!