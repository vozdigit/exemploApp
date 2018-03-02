$(function () {

$.fn.editable.defaults.mode = 'popup';
    //modify buttons style
    $.fn.editableform.buttons =
            '<button type="submit" class="btn btn-primary btn-sm"><i class="fa fa-check"></i></button>' +
            '<button type="button" class="btn btn-secondary btn-sm m-l-5"><i class="fa fa-times"></i></button>';

    /*$.fn.editableform.template =
            '<form class="form-inline editableform">' +
            '<div class="control-group">' +
            '<div><div class="editable-input"></div><div class="editable-buttons"></div></div>' +
            '<div class="editable-error-block"></div>' +
            '</div>' +
            '</form>';*/

    //editables 
    $('#username').editable({
        type: 'text',
        pk: 1,
        name: 'username',
        title: 'Enter username'
    });

    $('#firstname').editable({
        validate: function (value) {
            if ($.trim(value) == '')
                return 'This field is required';
        }
    });

    $('#sex').editable({
        prepend: "not selected",
        source: [
            {value: 1, text: 'Male'},
            {value: 2, text: 'Female'}
        ],
        display: function (value, sourceData) {
            var colors = {"": "#98a6ad", 1: "#5fbeaa", 2: "#5d9cec"},
            elem = $.grep(sourceData, function (o) {
                return o.value == value;
            });

            if (elem.length) {
                $(this).text(elem[0].text).css("color", colors[value]);
            } else {
                $(this).empty();
            }
        }
    });

    $('#status').editable();

    $('#group').editable({
        showbuttons: false
    });

    $('#dob').editable();

    $('#comments').editable({
        showbuttons: 'bottom'
    });

    //inline


    $('#inline-username').editable({
        type: 'text',
        pk: 1,
        name: 'username',
        title: 'Enter username',
        mode: 'inline'
    });

    $('#inline-firstname').editable({
        validate: function (value) {
            if ($.trim(value) == '')
                return 'This field is required';
        },
        mode: 'inline'
    });

    $('#inline-sex').editable({
        prepend: "not selected",
        mode: 'inline',
        source: [
            {value: 1, text: 'Male'},
            {value: 2, text: 'Female'}
        ],
        display: function (value, sourceData) {
            var colors = {"": "#98a6ad", 1: "#5fbeaa", 2: "#5d9cec"},
            elem = $.grep(sourceData, function (o) {
                return o.value == value;
            });

            if (elem.length) {
                $(this).text(elem[0].text).css("color", colors[value]);
            } else {
                $(this).empty();
            }
        }
    });

    $('#inline-status').editable({mode: 'inline'});

    $('#inline-group').editable({
        showbuttons: false,
        mode: 'inline'
    });

    $('#inline-dob').editable({mode: 'inline'});

    $('#inline-comments').editable({
        showbuttons: 'bottom',
        mode: 'inline'
    });
    
});