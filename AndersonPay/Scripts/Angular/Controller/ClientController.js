(function () {
    'use strict';

    angular
        .module('App')
        .controller('ClientController', ClientController);

    ClientController.$inject = ['$window', 'ClientService', 'CurrencyService'];

    function ClientController($window, ClientService, CurrencyService) {
        var vm = this;

        vm.Client;

        vm.Clients;

        vm.GoToUpdatePage = GoToUpdatePage;

        vm.Initialise = Initialise;

        vm.Delete = Delete;

        vm.ClientId;

        vm.selectedName;

        vm.ReadForCurrency = ReadForCurrency;
        vm.Currency;
        
        function TryF() {
            console.log(vm.Currency);
        }

        function GoToUpdatePage(clientId) {
            $window.location.href = '../Client/Update/' + clientId;
        }

        function Initialise(name, currencyId) {
            vm.selectedName = name;
            console.log(vm.selectedName);
            vm.CurrencyId = currencyId;

            Read();
            ReadForCurrency();
        }

        function Read() {
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

        function Delete(client) {
            ClientService.Delete(client)
                .then(function (response) {
                    Read();
                })
                .catch(function (data, status) {
                });
        }

        function ReadForCurrency() {
            CurrencyService.Read()
                .then(function (response) {
                    vm.Currency = response.data;
                    var currency = $filter('filter')(vm.Currency, { CurrencyId: vm.CurrencyId })[0];
                    if (currency)
                        vm.Currency = currency;
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