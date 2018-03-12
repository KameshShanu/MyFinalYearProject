var status1;
var status2;
var marker;
var markup_tb;

$(function () {
    $('.date').datetimepicker({
        ignoreReadonly: true
    });
});


$(function () {
    $('input[id="ReportDto_StartDate"]').datetimepicker({
        defaultDate: new Date()
    }).on('dp.change', function (event) {
        var currentDate = moment(new Date()).format("YYYY/MM/DD");
        var newDate = moment(event.date).format("YYYY/MM/DD");
        if (newDate > currentDate) {
            $('.errorStart').text('Please select a date before today');
            status1 = 1;
        }
        else {
            $('.errorStart').text('');
            status1 = null;
        }
    });
});
$(function () {
    $('input[id="ReportDto_EndDate"]').datetimepicker({
        defaultDate: new Date()
    }).on('dp.change', function (event) {
        var currentDate = moment(new Date()).format("YYYY/MM/DD");
        var newDate = moment(event.date).format("YYYY/MM/DD");
        if (newDate > currentDate) {
            $('.errorEnd').text('Please select a date before today');
            status2 = 1;
        }
        else {
            $('.errorEnd').text('');
            status2 = null;
        }
    });
});

$("form").submit(function (event) {
    var EndDate = $('#ReportDto_EndDate').val();
    var StartDate = $('#ReportDto_StartDate').val();
    if (StartDate == '') {
        $('.errorStart').text('Please select start date');
        $('.errorEnd').text('');
        event.preventDefault();
    }
    else if (EndDate == '') {
        $('.errorEnd').text('Please select end date');
        $('.errorStart').text('');
        event.preventDefault();
    }
    else if (status1 == 1) {
        $('.errorStart').text('Please select a valid date');
        $('.errorEnd').text('');
        event.preventDefault();
    }
    else if (status2 == 1) {
        $('.errorEnd').text('Please select a valid date');
        $('.errorStart').text('');
        event.preventDefault();
    }
    else if (+EndDate < +StartDate) {
        $('.errorEnd').text('Please select a valid date');
        $('.errorStart').text('');
        event.preventDefault();
    }
    else {
        $('.errorStart').text('');
        $('.errorEnd').text('');
    }
});


function getSettlementCategoryReport(value) {
    var category = $("#hidden_payment_category").val();
    var corporate = $('#hidden_corporate_name').val();
    $('#settlement_category_div').empty();
    $('#corporate_div').empty();
    if (value.toUpperCase() === 'CREDIT') {

        var html_markup = '<div class="form-group">'
                            + ' <div class="col-md-7 panel">'
                              + '<span class="label label-success">Settlement Category</span>'
                                   + '<select id="ReportDto_PaymentCategory" name="ReportDto.PaymentCategory"onchange="javascript: getCorporatesReport(this.value);" onload="javascript: getCorporatesReport(this.value);" class="form-control"></select>'
                               + '</div>'
                                + '</div><br />';
        $('#settlement_category_div').append(html_markup);

        var url = "/Reports/LoadSettlementCategory/";
        $.ajax({
            url: url,
            // data: { data: id },
            cache: false,
            type: "GET",
            success: function (data) {
                if (data.length > 0) {
                    var markup;
                    for (var x = 0; x < data.length; x++) {
                        markup += "<option value=" + JSON.stringify(data[x].Value) + ">" + data[x].Text + "</option>";
                    }
                    $('#ReportDto_PaymentCategory').html(markup).show();
                    if (category != '') {
                        $('#ReportDto_PaymentCategory').val(category);
                        getCorporatesReport(category)
                    }
                }
            },
            error: function (reponse) {
                console.log("error : " + reponse);
            }
        });
    }
}
function getCorporatesReport(value) {
    var corporate = $('#hidden_corporate_name').val();
    $('#corporate_div').empty();
    if (value.toUpperCase() === 'DIRECT CREDIT CORPORATE') {
        var html_markup = '<div class="form-group">'
                             + ' <div class="col-md-7 panel">'
                                 + '<span class="label label-success">Corporate</span>'
                                    + '<select id="ReportDto_CorporateName" name="ReportDto.CorporateName" class="form-control"></select>'
                                 + '</div>'
                              + '</div><br />';
        $('#corporate_div').append(html_markup);

        var url = "/Reports/loadCorporateList/";
        $.ajax({
            url: url,
            // data: { data: id },
            cache: false,
            type: "GET",
            success: function (data) {
                if (data.length > 0) {
                    var markup;
                    for (var x = 0; x < data.length; x++) {
                        markup += "<option value=" + JSON.stringify(data[x].Value) + ">" + data[x].Text + "</option>";
                    }
                    $('#ReportDto_CorporateName').html(markup).show();
                    if (corporate != '') {
                        $('#ReportDto_CorporateName').val(corporate);
                    }
                }
            },
            error: function (reponse) {
                console.log("error : " + reponse);
            }
        });
    }
}