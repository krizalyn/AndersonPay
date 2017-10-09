
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

    // Styled form components
    // ------------------------------

    // Checkboxes, radios
    $(".styled").uniform({ radioClass: 'choice' });

    // File input
    $(".file-styled").uniform({
        fileButtonClass: 'action btn bg-pink-400'
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

    // Basic example
    $(".touchspin-basic").TouchSpin({
        postfix: '<i class="icon-stack3"></i>',
        min: 0,
        max: 1000
    });




    /*
    // Postfix
    $(".touchspin-postfix").TouchSpin({
        min: 0,
        max: 500,
        step: 0.1,
        decimals: 2,
        postfix: '%'
    });
    */

    // Prefix
    $(".touchspin-prefix").TouchSpin({
        min: 0,
        max: 100000000,
        step: 1,
        decimals: 2,
        prefix: 'P'
    });
    

    // Init with empty values
    $(".touchspin-empty").TouchSpin();


    // Disable mousewheel
    $(".touchspin-no-mousewheel").TouchSpin({
        mousewheel: false
    });


    // Incremental/decremental steps
    $(".touchspin-step").TouchSpin({
        step: 0
    });


    // Set value
    $(".touchspin-set-value").TouchSpin({
        initval: 40
    });


    // Inside button group
    $(".touchspin-button-group").TouchSpin({
        prefix: "pre",
        postfix: "post"
    });


    // Vertical spinners
    $(".touchspin-vertical").TouchSpin({
        verticalbuttons: true,
        verticalupclass: 'icon-arrow-up22',
        verticaldownclass: 'icon-arrow-down22'
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


    //
    // Buttons

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
