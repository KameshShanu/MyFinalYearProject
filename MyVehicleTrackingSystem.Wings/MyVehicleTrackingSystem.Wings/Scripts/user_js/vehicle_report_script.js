var status1 = null;
var status2 = null;
$(function () {
    $('.date').datetimepicker({
        ignoreReadonly: true,
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
