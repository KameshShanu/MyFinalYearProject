$(document).ready(function () {
    //Initialize tooltips
    $('.nav-tabs > li a[title]').tooltip();
    //Wizard
    $('a[data-toggle="tab"]').on('show.bs.tab', function (e) {
        var $target = $(e.target);
        if ($target.parent().hasClass('disabled')) {
            return false;
        }
    });

    $(".next-step").click(function (e) {
        var $active = $('.wizard .nav-tabs li.active');
        $active.next().removeClass('disabled');
        nextTab($active);
    });
    $(".prev-step").click(function (e) {
        var $active = $('.wizard .nav-tabs li.active');
        prevTab($active);
    });
});

function nextTab(elem) {
    $(elem).next().find('a[data-toggle="tab"]').click();
}
function prevTab(elem) {
    $(elem).prev().find('a[data-toggle="tab"]').click();
}
$(":file").filestyle({ input: false, buttonName: "btn-primary btn-raised", size: "sm" });

// DatePicker funtion
$(function () {
    $(".reg-date").datepicker({
        autoclose: true,
        todayHighlight: true,
        endDate: "today"
    });
    $(".exp-date").datepicker({
        autoclose: true,
        todayHighlight: true,
        startDate: "today"
    });
    $(".birth-date").datepicker({
        autoclose: true,
        todayHighlight: true,
        endDate: "today"
    });
});

$(".StartDate").change(function () {
    if ($(".StartDate").val() != '') {
        $(".errStartDate").hide();
    }
});
$(".dateofbirth").change(function () {
    if ($(".dateofbirth").val() != '') {
        $(".errdateofbirth").hide();
    }
});
$(".DateOfExpiry").change(function () {
    if ($(".DateOfExpiry").val() != '') {
        $(".errDateOfExpiry").hide();
    }
});
$(".DefensiveLicenseExpiry").change(function () {
    if ($(".DefensiveLicenseExpiry").val() != '') {
        $(".errDefensiveLicenseExpiry").hide();
    }
});
$(".PoliceReportExpiry").change(function () {
    if ($(".PoliceReportExpiry").val() != '') {
        $(".errPoliceReportExpiry").hide();
    }
});

// Perform period of work calculation
$("#startDateOfWork").change(function () {
    $('.date1').val(null);
    var selectedDate = $(this).val();
    var selectedDate1 = new Date(selectedDate);
    var currentDate = new Date();
    var diff = currentDate - selectedDate1;
    var years = Math.floor(diff / 31536000000);
    var months = Math.floor((diff % 31536000000) / 2628000000);
    var days = Math.floor(((diff % 31536000000) % 2628000000) / 86400000);
    $('.date1').val(years + " year(s) " + months + " month(s) and " + days + " day(s)");
});
