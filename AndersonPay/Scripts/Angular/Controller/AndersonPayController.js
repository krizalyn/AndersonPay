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
            total: 0,
            WithholdingTax: 0
            
        }
        //array
        vm.InvoiceServices = [];
        vm.TypeOfServices = [];
        

        //function create
        vm.CreateInvoiceService = CreateInvoiceService;
        //function delete
        vm.deleteRow = deleteRow;
        //function others
        vm.Initialise = Initialise;
        


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

        vm.total = function () {
            var total = 0;
            angular.forEach(vm.InvoiceService.InvoiceServices, function (invoiceService) {
                total += invoiceService.Rate * invoiceService.Quantity;
            })

            return total;
        }

        vm.getTaxTotal = function(WithholdingTax, total)
            { 
                var result = ((WithholdingTax/total)*100 + total)
                return Math.round(result, 2);
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