$(document).ready(function () {
    $('#checkAll').prop('disabled', true);
});

//Check all checkboxes when header checkbox clicked.
$(function () {
    $("#checkAll").click(function () {
        if ($("#checkAll").is(':checked')) {
            $("input[type=checkbox]").each(function () {
                $(this).prop("checked", true);
            });

        } else {
            $("input[type=checkbox]").each(function () {
                $(this).prop("checked", false);
            });
        }
    });
});

//Vehicle number dropdown onchange ajax call
$("#VehicleNumber").change(function () {

    $('.tbtr').nextAll('tr').remove();
    $('#maintenanceDataTable .tbtr').after('<tr><td colspan="5" align="center" id="spinnerContainer"></td></tr>');
    $('#spinnerContainer').jmspinner();

    var selectedValue = $("#VehicleNumber").val();

    if (selectedValue != "") {
        $.ajax({
            url: "/VehicleMaintenance/GetMaintenanceDataByVehicleId",
            data: { vehicleId: selectedValue },
            cache: false,
            type: "GET",
            success: function (response) {
                $('#checkAll').prop('disabled', false);
                $('.tbtr').nextAll('tr').remove();
                $('#spinnerContainer').jmspinner(false);
                if (response.IsDataAvailable) {
                    for (var i = 0; i <= response.maintenanceData.length; i++) {
                        $('#maintenanceDataTable .tbtr').after('<tr><td> <input type="checkbox" name="vehiclemaintancesToDelete" id="vehiclemaintancesToDelete" value="' + response.maintenanceData[i].VehicleMaintenanceId + '" /></td><td>' + new Date(parseInt(response.maintenanceData[i].MaintenanceDate.substr(6))).toLocaleDateString() + '</td><td>' + response.maintenanceData[i].MaintenanceDescription + '</td><td>' + parseFloat(response.maintenanceData[i].Cost).toFixed(2) + '</td><td><a class="editbtn btn btn-default btn-raised" href="/VehicleMaintenance/Edit/' + response.maintenanceData[i].VehicleMaintenanceId + '">Edit<div class="ripple-container"></div></a></td></tr>');
                    }
                } else {
                    $('#checkAll').prop('disabled', true);
                    $('#maintenanceDataTable .tbtr').after('<tr><td colspan="5" align="center" style="color:red">' + response.Message + ' ' + $("#VehicleNumber option:selected").text() + '</td></tr>');
                }
            },
            error: function (reponse) {
                $('.tbtr').nextAll('tr').remove();
                $('#checkAll').prop('disabled', true);
                $('#spinnerContainer').jmspinner(false);
                $('#maintenanceDataTable .tbtr').after('<tr><td colspan="5" align="center" style="color:red">Error occured while fetching maintenance data. Please try again.</td></tr>');
            }
        });
    } else {
        $('#checkAll').prop('disabled', true);
        $('.tbtr').nextAll('tr').remove();
        $('#spinnerContainer').jmspinner(false);
    }
});

// Uncheck All Checkboxes
function uncheckAll() {
    $("input[type='checkbox']:checked").prop("checked", false)
}
$('#clearcheckbox').on('click', uncheckAll)