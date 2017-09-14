
$(function() {

    // Select2 select
    // ------------------------------

    // Basic
    $('.select').select2();

    //
    // Select with icons
    //

    // Format icon
    function iconFormat(icon) {
        var originalOption = icon.element;
        if (!icon.id) { return icon.text; }
        var $icon = "<i class='icon-" + $(icon.element).data('icon') + "'></i>" + icon.text;

        return $icon;
    }


    // Initialize with options
    $(".select-icons").select2({
        templateResult: iconFormat,
        minimumResultsForSearch: Infinity,
        templateSelection: iconFormat,
        escapeMarkup: function(m) { return m; }
    });

    // File input
    $(".file-styled").uniform({
        fileButtonClass: 'btn bg-slate-400'
    });
    
});


$(function () {


    // Checkboxes/radios in addons
    // ------------------------------

    // Switchery
    if (Array.prototype.forEach) {
        var elems = Array.prototype.slice.call(document.querySelectorAll('.switchery'));
        elems.forEach(function (html) {
            var switchery = new Switchery(html);
        });
    }
    else {
        var elems = document.querySelectorAll('.switchery');
        for (var i = 0; i < elems.length; i++) {
            var switchery = new Switchery(elems[i]);
        }
    }


    // Styled checkboxes/radios
    $(".styled, .multiselect-container input").uniform({
        radioClass: 'choice'
    });

    // Update uniform when select between styled and unstyled
    $('.input-group-addon input[type=radio]').on('click', function () {
        $.uniform.update("[name=addon-radio]");
    });




    // Touchspin spinners
    // ------------------------------

    $(".touchspin-rate").TouchSpin({
        min: 0,
        max: 1000000,
        step: 1,
        decimals: 2,
        postfix: '<i class="icon-price-tags"></i>'
    });


    $(".touchspin-quantity").TouchSpin({
        min: 0,
        max: 100000,
        step: 1,
        postfix: '<i class="icon-stack3"></i>'
    });

    $(".touchspin-latefee").TouchSpin({
        min: 0,
        max: 100,
        step: 1,
        postfix: '<i class="icon-percent"></i>'
    });





    // Addons
    // ------------------------------

    // Default
    $(".touchspin-addon-default").TouchSpin({
        prefix: '<i class="icon-accessibility"></i>',
        postfix: '<i class="icon-paragraph-justify2"></i>'
    });

    // Primary
    $(".touchspin-addon-primary").TouchSpin({
        prefix_extraclass: 'input-group-addon-primary',
        postfix_extraclass: 'input-group-addon-primary',
        prefix: '<i class="icon-accessibility"></i>',
        postfix: '<i class="icon-paragraph-justify2"></i>'
    });

    // Danger
    $(".touchspin-addon-danger").TouchSpin({
        prefix_extraclass: 'input-group-addon-danger',
        postfix_extraclass: 'input-group-addon-danger',
        prefix: '<i class="icon-accessibility"></i>',
        postfix: '<i class="icon-paragraph-justify2"></i>'
    });

    // Success
    $(".touchspin-addon-success").TouchSpin({
        prefix_extraclass: 'input-group-addon-success',
        postfix_extraclass: 'input-group-addon-success',
        prefix: '<i class="icon-accessibility"></i>',
        postfix: '<i class="icon-paragraph-justify2"></i>'
    });

    // Warning
    $(".touchspin-addon-warning").TouchSpin({
        prefix_extraclass: 'input-group-addon-warning',
        postfix_extraclass: 'input-group-addon-warning',
        prefix: '<i class="icon-accessibility"></i>',
        postfix: '<i class="icon-paragraph-justify2"></i>'
    });

    // Info
    $(".touchspin-addon-info").TouchSpin({
        prefix_extraclass: 'input-group-addon-info',
        postfix_extraclass: 'input-group-addon-info',
        prefix: '<i class="icon-accessibility"></i>',
        postfix: '<i class="icon-paragraph-justify2"></i>'
    });


    // Default
    $(".touchspin-button-default").TouchSpin({
        prefix: '<i class="icon-accessibility"></i>',
        postfix: '<i class="icon-paragraph-justify2"></i>',
        buttondown_class: "btn btn-default",
        buttonup_class: "btn btn-default"
    });

    // Primary
    $(".touchspin-button-primary").TouchSpin({
        prefix: '<i class="icon-accessibility"></i>',
        postfix: '<i class="icon-paragraph-justify2"></i>',
        buttondown_class: "btn btn-primary",
        buttonup_class: "btn btn-primary"
    });

    // Danger
    $(".touchspin-button-danger").TouchSpin({
        prefix: '<i class="icon-accessibility"></i>',
        postfix: '<i class="icon-paragraph-justify2"></i>',
        buttondown_class: "btn btn-danger",
        buttonup_class: "btn btn-danger"
    });

    // Success
    $(".touchspin-button-success").TouchSpin({
        prefix: '<i class="icon-accessibility"></i>',
        postfix: '<i class="icon-paragraph-justify2"></i>',
        buttondown_class: "btn btn-success",
        buttonup_class: "btn btn-success"
    });

    // Warning
    $(".touchspin-button-warning").TouchSpin({
        prefix: '<i class="icon-accessibility"></i>',
        postfix: '<i class="icon-paragraph-justify2"></i>',
        buttondown_class: "btn btn-warning",
        buttonup_class: "btn btn-warning"
    });

    // Info
    $(".touchspin-button-info").TouchSpin({
        prefix: '<i class="icon-accessibility"></i>',
        postfix: '<i class="icon-paragraph-justify2"></i>',
        buttondown_class: "btn btn-info",
        buttonup_class: "btn btn-info"
    });



});
(function () {
    'use strict';

    angular
        .module('App')
        .controller('AndersonPayController', AndersonPayController);

    AndersonPayController.$inject = [];

    function AndersonPayController() {
        var vm = this;
        //object
        vm.InvoiceService = {
            TypeOfService: null,
            Description: '',
            Rate: 0,
            Quantity: 0
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
            vm.TypeOfServices = angular.fromJson(typeOfServices);
        }

        function deleteRow(index) {
            vm.InvoiceServices.splice(index, 1);
          
        }

  
        
    }

})();


//MASTER WAS HERE HAKHAK !!!
