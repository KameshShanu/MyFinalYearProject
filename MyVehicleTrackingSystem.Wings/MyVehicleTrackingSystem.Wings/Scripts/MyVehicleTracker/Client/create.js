$(document).ready(function () {
    $("#operationTypediv").hide();
    
    //Company Name
    $("#CompanyName").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/Client/AutocompleteName",
                type: "POST",
                dataType: "json",
                data: {
                    prefix: request.term
                },
                success: function (data) {
                    response($.map(data, function (item) {
                        return {
                            label: item.CompanyName,
                            value: item.CompanyName
                        };
                    }))
                },
                error: function () {
                }
            })
        },
        messages: {
            noResults: "",
            results: ""
        }
    });

    //Company Address
    $("#CompanyAddress").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/Client/AutocompleteAddress",
                type: "POST",
                dataType: "json",
                data: {
                    prefix: request.term
                },
                success: function (data) {
                    response($.map(data, function (item) {
                        return {
                            label: item.CompanyAddress,
                            value: item.CompanyAddress
                        };
                    }))
                },
                error: function () {
                }
            })
        },
        messages: {
            noResults: "",
            results: ""
        }
    });

    //Phone Number1
    $("#PhoneNumber1").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/Client/AutocompletePhoneNumber1",
                type: "POST",
                dataType: "json",
                data: {
                    prefix: request.term
                },
                success: function (data) {
                    response($.map(data, function (item) {
                        return {
                            label: item.PhoneNumber1,
                            value: item.PhoneNumber1
                        };
                    }))
                },
                error: function () {
                }
            })
        },
        messages: {
            noResults: "",
            results: ""
        }
    });

    //Phone Number2
    $("#PhoneNumber2").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/Client/AutocompletePhoneNumber2",
                type: "POST",
                dataType: "json",
                data: {
                    prefix: request.term
                },
                success: function (data) {
                    response($.map(data, function (item) {
                        return {
                            label: item.PhoneNumber2,
                            value: item.PhoneNumber2
                        };
                    }))
                },
                error: function () {
                }
            })
        },
        messages: {
            noResults: "",
            results: ""
        }
    });

    //VAT
    $("#VAT").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/Client/AutocompleteVAT",
                type: "POST",
                dataType: "json",
                data: {
                    prefix: request.term
                },
                success: function (data) {
                    response($.map(data, function (item) {
                        return {
                            label: item.VAT,
                            value: item.VAT
                        };
                    }))
                },
                error: function () {
                }
            })
        },
        messages: {
            noResults: "",
            results: ""
        }
    });

    //SVAT
    $("#SVAT").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/Client/AutocompleteSVAT",
                type: "POST",
                dataType: "json",
                data: {
                    prefix: request.term
                },
                success: function (data) {
                    response($.map(data, function (item) {
                        return {
                            label: item.SVAT,
                            value: item.SVAT
                        };
                    }))
                },
                error: function () {
                }
            })
        },
        messages: {
            noResults: "",
            results: ""
        }
    });

});

// Operation type check box click event
$(function () {
    $("#IsOperationType").click(function () {
        if ($(this).is(':checked')) {
            $("#operationTypediv").show();
        }
        else {
            $("#operationTypediv").hide();
            $("#OperationType").val("");
        }
    });
});
