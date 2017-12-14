(function () {
    'use strict';

    angular
        .module('App')
        .controller('TypeOfServiceController', TypeOfServiceController);

    TypeOfServiceController.$inject = ['$window', 'TypeOfServiceService'];

    function TypeOfServiceController($window, TypeOfServiceService) {
        var vm = this;
        
        vm.TypeOfServices;

        vm.GoToUpdatePage = GoToUpdatePage;
        vm.Initialise = Initialise;

        vm.Delete = Delete;


        function GoToUpdatePage(typeOfServiceId) {
            $window.location.href = '../TypeOfService/Update/' + typeOfServiceId;
        }

        function Initialise() {
            Read();
        }

        function Read() {
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

        function Delete(typeOfService) {
            TypeOfServiceService.Delete(typeOfService)
                .then(function (response) {
                    Read();
                })
                .catch(function (data, status) {
                });
        }

    }
})();