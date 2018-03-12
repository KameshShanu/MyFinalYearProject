/// <reference path="jquery-1.10.2.js" />
/// <reference path="jquery-1.10.2.min.js" />
/// <reference path="jquery-1.10.2.intellisense.js" />
/* The dragging code for '.draggable' from the demo above
 * applies to this demo as well so it doesn't have to be repeated. */

// enable draggables to be dropped into this

var packageId = 0;
var TripData = {};
TripData.Customer = {};
var packageIds = [];

function GetDriverData(id) {

    $('#error_driver_select').text('');
    var url = "/Trips/LoadDriverDataByNo/";
    $.ajax({
        url: url,
        data: { driverId: id },
        cache: false,
        type: "GET",
        success: function (data) {
            if (data != null) {
                $('label[for=empNo]').html(data.EmpNumber);
                $('label[for=DLNumber]').html(data.DLNumber);
                $('label[for=nic]').html(data.NIC);
                $('label[for=contact]').html(data.PhoneNumber1);
                TripData.DriverId = id;
                TripData.DriverName = data.FirstName + " " + data.LastName;
            }
        },
        error: function (reponse) {
            console.log("error : " + reponse);
        }
    });
};
function GetVehicleData(id) {

    $('#error_vehicle_select').text('');
    $("#rightbar").hide();
    var url = "/Trips/LoadVehicleDataByNo/";
    $.ajax({
        url: url,
        data: { vehiId: id },
        cache: false,
        type: "GET",
        success: function (data) {
            if (data != null) {
                SyncGPS();//handled by backend
                $('label[for=vehiType]').html(data.VehicleType);
                $('label[for=vehiMake]').html(data.VehicleMake);
                $('label[for=vehiModel]').html(data.VehicleModel);
                $('label[for=meterReading]').html(data.CurrentMeterReading);
                TripData.MeterReadingOut = data.CurrentMeterReading;
                TripData.VehicleId = data.VehicleId;
                TripData.VehicleNumber = data.VehicleNumber;
                $('#vehitypeHidden').val(data.VehicleType);
                //if (data.VehicleType.toUpperCase() === 'VAN' || data.VehicleType.toUpperCase() === 'BUS') {
                //    TripData.IsCustomPackage = true;
                //    $("#newPackDiv").html('')
                //    loadCustomPack_bus_van();
                //}
                //else {
                //    loadCustomPackage($('#PassengerType :selected').text());
                //    TripData.IsCustomPackage = false;
                //}
            }
        },
        error: function (reponse) {
            console.log("error : " + reponse);
        }
    });
};

function getVehicleAllModel(vehi) {
    var url = "/Trips/LoadVehicleModels/";
    $.ajax({
        url: url,
        data: { vehi: vehi },
        cache: false,
        type: "GET",
        success: function (data) {
            if (data != null) {
                $('label[for=Model]').html(data.VehicleModel);
            }
        },
        error: function (reponse) {
            console.log("error : " + reponse);
        }
    });
}


function getPackages() {
    var url = "/Trips/LoadPackages/";
    var procemessage = "<option value='0'> Please wait...</option>";
    $('.packageClass').html(procemessage).show();
    $.ajax({
        url: url,
        //data: { data: id },
        cache: false,
        type: "GET",
        success: function (data) {
            if (data.length > 0) {
                var markup = "<option value='0'> Select a Package</option>";
                $('.packageClass').html(markup).show();
                for (var x = 0; x < data.length; x++) {
                    markup += "<option value=" + data[x].Value + ">" + data[x].Text + "</option>";
                }
                $('.packageClass').html(markup).show();
            }
            else {
                $('.packageClass').html("");
            }
        },
        error: function (reponse) {
            console.log("error : " + reponse);
        }
    });
}

function getPackagesForNewElements(elemId) {
    var url = "/Trips/LoadPackages/";
    var procemessage = "<option value='0'> Please wait...</option>";
    $('#' + elemId).html(procemessage).show();
    $.ajax({
        url: url,
        //data: { data: id },
        cache: false,
        type: "GET",
        success: function (data) {
            if (data.length > 0) {
                var markup = "<option value='0'> Select a Package</option>";
                $('#' + elemId).html(markup).show();
                for (var x = 0; x < data.length; x++) {
                    markup += "<option value=" + data[x].Value + ">" + data[x].Text + "</option>";
                }
                $('#' + elemId).html(markup).show();
            }
            else {
                $('#' + elemId).html("");
            }
        },
        error: function (reponse) {
            console.log("error : " + reponse);
        }
    });
}

function onPackageChange(elemId) {
    if ($('#' + elemId).val() === '0') {

    } else {
        if ($.inArray($('#' + elemId).val(), packageIds) != -1) {
            $('#' + elemId).val(0);
        } else {
            packageIds.push($('#' + elemId).val());
            $('#' + elemId).attr("disabled", true);
        }
    }
}

var selectorId = 3;

function generateDropDowns() {
    var newPackageSelector = '<div class="row checkbox-highlight remove-padding remove-margin col-md-6"><div id="packageName' + selectorId + '">'
                        + '<div class="col-md-8" id="packageDropDiv' + selectorId + '">'
                            + '<select id="PackageId' + selectorId + '" onchange="onPackageChange(this.id);" name="PackageId" class="dropdown-toggle form-control packageClass"></select>' + '<div class="btn btn-danger btn-raised btn-sm" id="' + selectorId + '" onclick="onMinusClick(this.id)">Remove <span class="glyphicon glyphicon-trash"></span></div>'
                        + '</div>'
                        + '</div>';
    $('#CustomPackagesDiv').append(newPackageSelector);
    getPackagesForNewElements("PackageId" + selectorId);
    selectorId++;
}

function onMinusClick(elemId) {
    if ($.inArray($('#PackageId' + elemId).val(), packageIds) != -1) {
        var index = packageIds.indexOf($('#PackageId' + elemId).val());
        packageIds.splice(index, 1);

        $('#packageName' + elemId).remove();
        $('#packageDropDiv' + elemId).remove();
        $('#' + elemId).remove();
    } else {
        $('#packageName' + elemId).remove();
        $('#packageDropDiv' + elemId).remove();
        $('#' + elemId).remove();
    }
}

function onSubmit() {

    if (validateCreateForm() != true) {
        event.preventDefault();
    }
    else {
        $('#generateVoucher').attr("disabled", true);
        TripData.GuestName = $('#GuestName').val();
        TripData.RoomNumber = $('#RoomNumber').val();
        TripData.Hotel = $('#Hotel').val();
        TripData.PassengerType = $('#PassengerType :selected').text();
        TripData.PassengerTypeList = $('#PassengerTypeList :selected').text();
        TripData.PaymentType = $('#PaymentType :selected').text();
        TripData.Customer.PhoneNumber = $('#PhoneNumber').val();
        TripData.PackageIds = packageIds;
        if ($('#customPackageAmountHidden').val() != 0) {
            TripData.CustomPackageAmount = $('#customPackageAmount').val();
            TripData.IsCustomPackage = true;
            TripData.PackageCost = $('#customPackageAmount').val();
            TripData.Amount = $('#customPackageAmount').val();
        }

        var url = "/Trips/Create/";
        $.ajax({
            xhr: function () {
                var xhr = new window.XMLHttpRequest();
                xhr.upload.addEventListener("progress", function (evt) {
                    if (evt.lengthComputable) {
                        var percentComplete = evt.loaded / evt.total;
                        console.log(percentComplete);
                        $('.progress').css({
                            width: percentComplete * 65 + '%'
                        });
                    }
                }, false);
                return xhr;
            },
            url: url,
            data: { TripData: TripData },
            cache: false,
            type: "POST",
            success: function (data) {
                $('.progress').css({
                    width: 1 * 100 + '%'
                });
                $('#validationError').text('');
                if (data.message != "") {
                    $('.progress').css({
                        width: 1 * 0 + '%'
                    });
                    //$('#validationError').text(data.message);
                    $('#validationError').focus();
                    $('#generateVoucher').attr("disabled", false);
                    // show notification modal after create voucher.
                    $('#notificationModalBody').text(data.message);
                    $('#notificationModal').modal('show');
                } else {
                    GetVoucherPrint(data.VoucherNumber);
                }
            },
            error: function (reponse) {
                $('.progress').css({
                    width: 1 * 0 + '%'
                });
                $('#validationError').text("Error in voucher save");
                $('#validationError').focus();
                $('#generateVoucher').attr("disabled", false);
            }
        });
    }
}
function GetVoucherPrint(voucherNo) {

    var url = "/Trips/GetVoucherData/";
    $.ajax({
        url: url,
        data: { voucherNo: voucherNo },
        cache: false,
        type: "POST",
        success: function (data) {
            VoucherPrint(data);
        },
        error: function (reponse) {
            $('#generateVoucher').attr("disabled", false);
        }
    });
}
function VoucherPrint(data) {
    if (data.GuestName == null) {
        data.GuestName = "";
    }
    if (data.RoomNumber == null) {
        data.RoomNumber = "";
    }
    var mywindow = window.open('', 'Voucher', 'height=400,width=800');
    mywindow.document.write('<html><head><title>Voucher</title>');
    mywindow.document.write('</head><body >');
    mywindow.document.write('<div style="position: absolute; left:558px;top:6px;font-size:small"">' + data.VoucherNumber + '</div>');
    mywindow.document.write('<div style="position: absolute; left:558px;top:53px;font-size:small"">' + data.VehicleNo + '</div>');
    mywindow.document.write('<div style="position: absolute; left:558px;top:80px;font-size:small"">' + data.DriverName + '</div>');
    mywindow.document.write('<div style="position: absolute; left:130px;top:120px;font-size:small"">' + data.GuestName + '</div>');
    mywindow.document.write('<div style="position: absolute; left:130px;top:154px;font-size:small"">' + data.DispatchedHotel + '</div>');
    mywindow.document.write('<div style="position: absolute; left:130px;top:172px;font-size:small"">' + data.RoomNumber + '</div>');
    mywindow.document.write('<div style="position: absolute; left:423px;top:154px;font-size:small"">' + data.MeterReadingOut + '</div>');
    mywindow.document.write('<div style="position: absolute; left:615px;top:154px;font-size:10px"">' + data.TimeOut + '</div>');
    var y = 200;
    for (x = 0; x < data.PackagesList.length; x++) {
        mywindow.document.write('<div style="position: absolute; left:130px;top:' + y + 'px;font-size:small"">' + data.PackagesList[x].PreDefineTripName + '</div>');
        y = y + 15;
    }
    mywindow.document.write('</body></html>');

    mywindow.print();
    mywindow.close();

    //return true;
    window.location.href = "/Trips/Index/";
}

function getBataRates() {
    var BataId = $("#BataId").val();
    var url = "/Trips/LoadBataRates/";
    var procemessage = "<option value='0'> Please wait...</option>";
    $('.bataCss').html(procemessage).show();
    $.ajax({
        url: url,
        //data: { data: id },
        cache: false,
        type: "GET",
        success: function (data) {
            if (data.length > 0) {
                var markup = "<option value='0'></option>";
                $('.bataCss').html(markup).show();
                for (var x = 0; x < data.length; x++) {
                    markup += "<option value=" + data[x].Value + ">" + data[x].Text + "</option>";
                }
                $('.bataCss').html(markup).show();
                if (BataId > 0) {
                    $("#BataRateId").val(BataId);
                }
            }
            else {
                $('.bataCss').html("");
            }
        },
        error: function (reponse) {
            console.log("error : " + reponse);
        }
    });
}
function getBataRateAmount(id) {
    var url = "/BataRate/LoadBataAmountById/";
    $.ajax({
        url: url,
        data: { bataId: id },
        cache: false,
        type: "GET",
        success: function (data) {
            if (data != null) {
                $('label[for=bataAmount]').html(data);
            }
            else {
                $('label[for=bataAmount]').html('');
            }
        },
        error: function (reponse) {
            $('label[for=bataAmount]').html('');
            console.log("error : " + reponse);
        }
    });
};

function getAllDrivers(value) {
    var url = "/Reports/LoadDrivers/";
    var procemessage = "<option value='0'> Please wait...</option>";
    $('.driverClass').html(procemessage).show();
    $.ajax({
        url: url,
        //data: { data: id },
        cache: false,
        type: "GET",
        success: function (data) {
            if (data.length > 0) {
                var markup = "<option value='0'>All Drivers</option>";
                $('.driverClass').html(markup).show();
                for (var x = 0; x < data.length; x++) {
                    markup += "<option value=" + data[x].Value + ">" + data[x].Text + "</option>";
                }
                $('.driverClass').html(markup).show();
            }
            else {
                $('.driverClass').html("");
            }
            if (value != '')
                $("#DriverId").val(value);
        },
        error: function (reponse) {
            console.log("error : " + reponse);
        }
    });
}

function getAllVehicles(value) {
    var url = "/Reports/LoadVehicles/";
    var procemessage = "<option value='0'> Please wait...</option>";
    $('.vehicleClass').html(procemessage).show();
    $.ajax({
        url: url,
        //data: { data: id },
        cache: false,
        type: "GET",
        success: function (data) {
            if (data.length > 0) {
                var markup = "<option value='0'>All Vehicles</option>";
                $('.vehicleClass').html(markup).show();
                for (var x = 0; x < data.length; x++) {
                    markup += "<option value=" + data[x].Value + ">" + data[x].Text + "</option>";
                }
                $('.vehicleClass').html(markup).show();
            }
            else {
                $('.vehicleClass').html("");
            }
            if (value != '')
                $("#VehicleId").val(value);
        },
        error: function (reponse) {
            console.log("error : " + reponse);
        }
    });
}

function getAllDispatchers(value) {
    var url = "/Reports/LoadDispatchers/";
    var procemessage = "<option value='0'> Please wait...</option>";
    $('.dispatcherClass').html(procemessage).show();
    $.ajax({
        url: url,
        //data: { data: id },
        cache: false,
        type: "GET",
        success: function (data) {
            if (data.length > 0) {
                var markup = "<option value='All Dispatchers'>All Dispatchers</option>";
                $('.dispatcherClass').html(markup).show();
                for (var x = 0; x < data.length; x++) {
                    markup += "<option value=" + JSON.stringify(data[x].Text) + ">" + data[x].Text + "</option>";
                }
                $('.dispatcherClass').html(markup).show();
            }
            else {
                $('.dispatcherClass').html("");
            }
            if (value != '')
                $("#Dispatcher").val(value);
        },
        error: function (reponse) {
            console.log("error : " + reponse);
        }
    });
}

function SyncGPS() {
    $('span[for=gap_meter_reading_status]').text('');
    $('label[for=meter_reading_gps]').text(0);
    var vehiNum = $('#Vehicle :selected').text();
    $("#loadingbarimg").show();
    $("#rightbar").hide();
    $("#wrongbar").hide();
    $('.meterValueError').text('');
    var url = "/Trips/SyncGps/";
    $.ajax({
        url: url,
        data: { vehiNum: vehiNum },
        cache: false,
        type: "GET",
        success: function (data) {
            $("#loadingbarimg").hide();
            if (data.meter_reading == '' || data.meter_reading == null) {
                $('span[for=gap_meter_reading_status]').text(data.error);
                $('label[for=meter_reading_gps]').text(0);
                $("#wrongbar").show();
            }
            else {
                $('label[for=meter_reading_gps]').text(data.meter_reading);
                $('#meterInTxtCommon').val(data.meter_reading);
                $('#gap_meter_reading').val($('label[for=meter_reading_gps]').text() - $('label[for=meterReading]').text());//create page
                $('label[for=trip_mileage]').html($.trim($('#meterInTxtCommon').val() - $('#meterReadingOut').val()));
                $("#rightbar").show();
            }
        },
        error: function (reponse) {
            $('span[for=gap_meter_reading_status]').text('Error In Gps Signal');
            $('label[for=meter_reading_gps]').text(0);
            $("#wrongbar").show();
        }
    });
}

function getGuestTypelist(id) {
    var url = "/Trips/LoadGuestTypes/";
    var procemessage = "<option value='0'> Please wait...</option>";
    $.ajax({
        url: url,
        data: { data: id },
        cache: false,
        type: "GET",
        success: function (data) {
            var markup;
            for (var x = 0; x < data.length; x++) {
                markup += "<option value=" + data[x].Value + ">" + data[x].Text + "</option>";
            }
            $("#PassengerTypeList").html(markup);

        },
        error: function (reponse) {
            console.log("error : " + reponse);
        }
    });
};

function loadCustomPackage(value) {
    packageIds = [];
    var vehiType = $('#vehitypeHidden').val();
    var markup1 = '<div class="row margin-bottom-10">'
               + '<div class="col-md-10">'
                   + '<div class="checkbox2" id="checkbox2">'
                        + '<input type="checkbox" class="packageCheck" onclick="handleClick(this)"name="packageCheck" id="packageCheck" value="1">  Custom Package'
                + '</div>'
              + '</div>'
          + '</div>'
         + '<div class="customPackages_div" id="customPackages_div"></div>';;

    var markup2 = '<div class="row margin-bottom-10 radioDiv">'
                  + '<div class="col-md-2"></div>'
                     + '<div class="col-md-4">'
                       + '<div class="checkbox1" id="checkbox1">'
                         + '<input type="radio" class="PackageRadio1" name="PackageRadio" id="PackageRadio1" value="0" checked=""  onchange="LoadCustomPackageDivNew(this.value)">  Package </Br>'
                     + '</div>'
                 + '<div class="checkbox2" id="checkbox2">'
                    + '<input type="radio" class="PackageRadio2" name="PackageRadio" id="PackageRadio2" value="1" onchange="LoadCustomPackageDivNew(this.value)" >  Custom Package'
                      + '</div>'
                     + '</div>'
                 + '</div>'
                + '<div class="CustomPackagesDiv" id="CustomPackagesDiv"></div>';

    if (value.toUpperCase() === 'GUEST') {
        if (vehiType.toUpperCase() === 'CAR' || vehiType.toUpperCase() === 'SUV') {
            $(".newPackDiv").html('');
            $(".newPackDiv").append(markup2);
            LoadCustomPackageDivNew(0);
        }
    }
    else if (value.toUpperCase() === 'STAFF') {
        if (vehiType.toUpperCase() === 'CAR' || vehiType.toUpperCase() === 'SUV') {
            $(".newPackDiv").html('');
            $(".newPackDiv").append(markup1);
        }
    }
}
function LoadCustomPackageDivNew(id) {
    var markup;
    if (id == 1) {
        $('.CustomPackagesDiv').html('');
        markup = '<div class="row checkbox-highlight remove-padding remove-margin col-md-6"><div class="form-group">'
                      + '<div id="packageName1"><label class="control-label col-md-6">Custom Package Amount</label></div>'
                            + '<div class="col-md-9">'
                                  + ' <input type="number" class="form-control customPackageAmount" name="customPackageAmount" id="customPackageAmount">'
                            + '</div>'
                      + '</div>'
                     + '</div></div>';

        $('.CustomPackagesDiv').append(markup).show();
        TripData.IsCustomPackage = true;
    }
    else {
        $('.CustomPackagesDiv').html('');
        var markup2 = '<div class="col-md-2"></div><div class="form-group"><div class="col-md-4"> <div class="btn btn-info btn-raised" onclick="generateDropDowns()"><span class="btn-sm">ADD NEW PACKAGE</span> <span class="glyphicon glyphicon-plus"></span></div></div></div><br /><br /><br />';
        $('.CustomPackagesDiv').append(markup2).show();
        TripData.IsCustomPackage = false;
    }
    getPackages();
}
function handleClick(cb) {
    $('#customPackages_div').html('');
    markup = '<div class="row checkbox-highlight remove-padding remove-margin col-md-6"><div class="form-group">'
                    + '<div id="packageName1"><label class="control-label col-md-6">Custom Package Amount</label></div>'
                          + '<div class="col-md-9">'
                                + ' <input type="number" class="form-control customPackageAmount" name="customPackageAmount" id="customPackageAmount">'
                          + '</div>'
                    + '</div>'
                   + '</div>';
    if (cb.checked == true) {
        $('.customPackages_div').append(markup).show();
        TripData.IsCustomPackage = true;
    }
    else {
        $('#customPackages_div').html('');
        TripData.IsCustomPackage = false;
    }
}

function loadCustomPack_bus_van() {
    packageIds = [];
    $('#newPackDiv').html('');
    markup = '<div class="row checkbox-highlight remove-padding remove-margin col-md-6"><div class="form-group">'
                  + '<div id="packageName1"><label class="control-label col-md-6">Custom Package Amount</label></div>'
                        + '<div class="col-md-9">'
                              + ' <input type="number" class="form-control customPackageAmount" name="customPackageAmount" id="customPackageAmount">'
                        + '</div>'
                  + '</div>'
                 + '</div></div>';
    $('#newPackDiv').append(markup).show();
}


//$(document).ready(function () {
//    var url_vehi = "/Trips/LoadVehicles/";
//    var reload_vehi = function () {
//        $.ajax({
//            dataType: 'json',
//            type: 'GET',
//            url: url_vehi,
//            cache: false,
//            success: function (response) {
//                var ddl = $(".vehicle_select");
//                $.each(response, function (i, item) {
//                    $("<option></option>", {
//                        value: item.Value,
//                        text: item.Text.replace('-', ' ')
//                    }).appendTo(ddl)
//                });
//                //GetVehicleData(response[0].Value);
//                $('.vehicle_select').chosen();
//                $(".vehicle_select").trigger("liszt:updated");
//                setTimeout(function () {
//                    $('.vehicle_select option').remove();
//                    reload_vehi();
//                }, 300000);
//            },
//            error: function (jqXHR, exception) {

//            }
//        });
//    };
//    reload_vehi();
//});

//$(document).ready(function () {
//    var url_driver = "/Trips/LoadDrivers/";
//    var reload_driver = function () {
//        $.ajax({
//            dataType: 'json',
//            type: 'GET',
//            url: url_driver,
//            cache: false,
//            success: function (response) {
//                var ddl = $(".driver_select");
//                $.each(response, function (i, item) {
//                    $("<option></option>", {
//                        value: item.Value,
//                        text: item.Text
//                    }).appendTo(ddl)
//                });
//                //GetDriverData(response[0].Value);
//                $('.driver_select').chosen();
//                $(".driver_select").trigger("liszt:updated");
//                setTimeout(function () {
//                    $('.driver_select option').remove();
//                    reload_driver();
//                }, 300000);
//            },
//            error: function (jqXHR, exception) {

//            }
//        });
//    };
//    reload_driver();
//});
$(document).ready(function () {
    $('.vehicle_select').chosen();
    $('.driver_select').chosen();
    $("form").submit(function (event) {
        if (validateCreateForm() != true) {
            event.preventDefault();
        }
    });
});
$(document).on('keyup', '#customPackageAmount', function () {
    $('#customPackageAmountHidden').val($('#customPackageAmount').val());
});

function validateCreateForm() {

    $("#error_vehicle_select").text('');
    $("#error_driver_select").text('');
    var validated = true;

    var vehicle_select = $('#Vehicle :selected').val();
    var driver_select = $('#Driver :selected').val();
    if (vehicle_select === '0') {
        $('#error_vehicle_select').text('Please select a vehicle');
        validated = false;
    }
    else if (driver_select === '0') {
        $('#error_driver_select').text('Please select a driver');
        validated = false;
    }

    return validated;
}