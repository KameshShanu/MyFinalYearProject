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

    $("#VehicleType").change(function () {
        if ($('#VehicleType option:selected').val() == "Other") {
            $("#divVehicleType").show();
        }
        else
        {
            $("#divVehicleType").hide();
        }
    });
});

function nextTab(elem) {
    $(elem).next().find('a[data-toggle="tab"]').click();
}
function prevTab(elem) {
    $(elem).prev().find('a[data-toggle="tab"]').click();
}

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
});
$(".LicenseExpDate").change(function () {
    if ($(".LicenseExpDate").val() != '') {
        $(".errLicenseExpDate").hide();
    }
});
$(".InsuranceExp").change(function () {
    if ($(".InsuranceExp").val() != '') {
        $(".errInsuranceExp").hide();
    }
});
$(".GoodsExp").change(function () {
    if ($(".GoodsExp").val() != '') {
        $(".errGoodsExp").hide();
    }
});
$(".FirstRegistration").change(function () {
    if ($(".FirstRegistration").val() != '') {
        $(".errFirstRegistration").hide();
    }
});
$(".FireReportExp").change(function () {
    if ($(".FireReportExp").val() != '') {
        $(".errFireReportExp").hide();
    }
});
$(".CalibrationReportExp").change(function () {
    if ($(".CalibrationReportExp").val() != '') {
        $(".errCalibrationReportExp").hide();
    }
});
$(".EmissionTestExp").change(function () {
    if ($(".EmissionTestExp").val() != '') {
        $(".errEmissionTestExp").hide();
    }
});
$(".VehicleFitnessExp").change(function () {
    if ($(".VehicleFitnessExp").val() != '') {
        $(".errVehicleFitnessExp").hide();
    }
});

$("form").validate({
    rules: {
        VehicleType: {
            required: {
                depends: function (element) {
                    return $("#VehicleType").val() == "";
                }
            }
        },
        FuelType: {
            required: {
                depends: function (element) {
                    return $("#FuelType").val() == "";
                }
            }
        },
        OwnershipStatus: {
            required: {
                depends: function (element) {
                    return $("#OwnershipStatus").val() == "";
                }
            }
        },
        messages: {
            VehicleType: {
                required: "The Vehicle Type field is required.",
            },
            FuelType: {
                required: "The Fuel Type field is required.",
            },
            OwnershipStatus: {
                required: "The Ownership Status field is required.",
            },

        }
    }
});
document.getElementById('InitialMeterReading').addEventListener('keydown', function (e) {
    var key = e.keyCode ? e.keyCode : e.which;

    if (!([8, 9, 13, 27, 46, 110, 190].indexOf(key) !== -1 ||
         (key == 65 && (e.ctrlKey || e.metaKey)) ||
         (key >= 35 && key <= 40) ||
         (key >= 48 && key <= 57 && !(e.shiftKey || e.altKey)) ||
         (key >= 96 && key <= 105)
       )) e.preventDefault();
});

//Clear Dangerous License Expiry Date
function ClearDangerousLicenseExpDate() {
    $('#datepicker-DangerousLicenseExpDate').data('datepicker').setDate(null);
}