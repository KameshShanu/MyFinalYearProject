$(document).ready(function () {
    if ($('#VehicleType option:selected').val() == "Other") {
        $("#divVehicleType").show();
    }
    else {
        $("#divVehicleType").hide();
    }

    $("#VehicleType").change(function () {
        if ($('#VehicleType option:selected').val() == "Other") {
            $("#divVehicleType").show();
        }
        else {
            $("#divVehicleType").hide();
        }
    });
});

$(function () {
    $(".reg-date").datepicker({
        autoclose: true,
        todayHighlight: true,
        endDate: "today"
    }).datepicker('update');
    $(".exp-date").datepicker({
        autoclose: true,
        todayHighlight: true,
        startDate: "today"
    }).datepicker('update');
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

