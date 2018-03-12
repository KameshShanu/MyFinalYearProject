var TripDataEdit = {};
var packageIdsEdit = [];
$(function () {
    $('.date').datetimepicker({
        ignoreReadonly: true,
        defaultDate: new Date()
    });
});
$(document).ready(function () {
    var currentMeterValue = $('#currentMeterVal').text();
    var vehi_type = $('#vehi_type_hidden').val().toLocaleUpperCase();
    var guest_type = $('#guest_type_hidden').val();
    var perKmForGuest;
    var waiterHourRateStaff;
    var packageCost;
    var extraKmAndPc;

    getBataRates();
    addtionalKmCalc();
    waitedHrCalc();
    getGuestTypeEdit("guest");
    SyncGPSEdit();

    var iscustom = Boolean($('input[id$=customPackageHidden]').val());
    var vehiHidden = $('.vehihidden').val();

    if ($('#BataId').val() != null)
        $('.bataCss').val($('#BataId').val());

    $(document).on('keyup', '#meterInTxt', function () {
        $('#noOfKm').val($("#meterInTxt").val());
        $("#fareData input[type='hidden']").each(function () {
            if ($(this).attr('data-guestType').toUpperCase() === 'STAFF' && vehi_type !== 'BUS' && vehi_type !== 'VAN') {
                var perKmForStaff = $(this).attr('value');
                packageCost = $("#meterInTxt").val() * perKmForStaff;
                $('#pcAmount').html(packageCost.toFixed(2));
                $('#error_package_amount').text('');
                $('#updateVoucherBtn').attr('disabled', 'disabled');
            }
        });
    });

    $(document).on('keyup', '#customPackageAmount', function () {
        $('#customPackageAmountEditHidden').val($('#customPackageAmount').val());
        packageCost = $("#customPackageAmount").val() * 1.00;
        $('.pcAmount').html(packageCost.toFixed(2));
        $('#error_package_amount').text('');
        $('#updateVoucherBtn').attr('disabled', 'disabled');
    });

});

function CalculateAmount() {

    $('#error_package_amount').text('');
    var packageCost = $('.pcAmount').html();
    var additionalKmCost = $('.extraKm').html();
    var waitedHourCost = $('.waitedHour').html();
    var paymentType = $('#PaymentType :selected').text();
    var paymentCat = $('#PaymentCategory :selected').val();
    var totalAmount = +packageCost + +additionalKmCost + +waitedHourCost;
    $('#lblTotAmount').html(totalAmount.toFixed(2));
    if (TripDataEdit.IsCustomPackage == false) {
        if (paymentCat == 'Hotel Billing Staff') {
            $('#updateVoucherBtn').attr("disabled", false);
        }
        else {
            if (packageIdsEdit.length <= 0) {
                $('#error_package_amount').text('Please select package(s)');
                $('#updateVoucherBtn').attr("disabled", true);
            }
            else {
                $('#updateVoucherBtn').attr("disabled", false);
            }
        }
    }
    else {
        if (packageCost == 0) {
            $('#error_package_amount').text('Package amount cannot be Zero');
            $('#updateVoucherBtn').attr("disabled", true);
        }
        else {
            $('#updateVoucherBtn').attr("disabled", false);
        }
    }
};

function deletePackage(packageIdd) {
    var packageId = $('#' + packageIdd).attr('data-pid');
    $('#updateVoucherBtn').attr('disabled', 'disabled');
    var url = "/Trips/DeletePackageById/";
    $.ajax({
        cache: false,
        url: url,
        type: "GET",
        dataType: "JSON",
        data: { packageId: packageId },
        traditional: true,
        success: function (result) {
            $('#' + packageIdd).remove();
            var packageCost = $('.pcAmount').html();
            var sumOfPc = +packageCost - +result;
            $('.pcAmount').html(sumOfPc.toFixed(2));
            $('#lblTotAmount').html(sumOfPc.toFixed(2));
            $('#minus' + packageId).html('');
            $('#error_package_amount').text('');
        },
        error: function (xhr, ajaxOptions, thrownError) {
            //alert('Package Deletion Failed');
        }
    });
}

function submitEdits() {
    var meterInVal = $('#meterInTxtCommon').val();
    if (validateEditForm() != true) {
        event.preventDefault();
    }
    else {
        if ($.isNumeric($.trim(meterInVal))) {
            $('#updateVoucherBtn').attr("disabled", true);
            TripDataEdit.TripId = $('#tripId').val();
            TripDataEdit.MeterReadingOut = $.trim($('#meterReadingOut').val());
            TripDataEdit.MeterReadingIn = $.trim($('#meterInTxtCommon').val());
            TripDataEdit.BataRateId = $('#BataRateId :selected').val();
            TripDataEdit.BataRate = $('#BataRateId :selected').text();
            TripDataEdit.GuestName = $('#GuestName').val();
            //TripDataEdit.PassengerTypeList = $('#PassengerTypeList :selected').text();
            TripDataEdit.TotalMilage = $('#totalMilage').val();
            TripDataEdit.AdditionalKM = $('#addtionalKmTxt').val();
            TripDataEdit.WaitedHrs = $('#waitedHourTxt').val();
            TripDataEdit.Hotel = $('#Hotel').val();
            TripDataEdit.RoomNumber = $('#RoomNumber').val();
            TripDataEdit.PaymentType = $('#PaymentType :selected').text();
            TripDataEdit.PaymentDateTime = $("#PaymentDateTime").val();
            TripDataEdit.Remarks = $('#remarks').val();
            TripDataEdit.Paid = $("input[name=Paid]:checked").val();
            TripDataEdit.VehicleId = $('#VehicleId').val();
            TripDataEdit.DriverId = $('#DriverId').val();
            TripDataEdit.VehicleNumber = $('#VehicleNumber').val();
            TripDataEdit.Amount = $('#lblTotAmount').text();
            TripDataEdit.PackageCost = $('#pcAmount').text();
            TripDataEdit.AdditionalKmCost = $('#lblAdditionKmCost').text();
            TripDataEdit.WaitingHourCost = $('#lblWaitedHourCost').text();
            TripDataEdit.PackageIds = packageIdsEdit;
            TripDataEdit.PassengerType = $('#PassengerType').val();
            TripDataEdit.CustomPackageAmount = $("#customPackageAmount").val();
            TripDataEdit.CorporateName = $('#CorporateName :selected').val();
            TripDataEdit.PaymentCategory = $('#PaymentCategory :selected').val();
            TripDataEdit.ReservationNo = $('#ReservationNo').val();

            var url = "/Trips/Edit/";
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
                type: 'POST',
                url: url,
                data: { model: TripDataEdit },
                cache: false,
                success: function (data) {
                    $('.progress').css({
                        width: 1 * 100 + '%'
                    });
                    if (data != "") {
                        $('#validationError').text(data);
                        $('#validationError').focus();
                        $('#updateVoucherBtn').attr("disabled", false);
                    }
                    else {
                        var url = '/Trips/Index';
                        window.location.href = url;
                    }
                },
                error: function (reponse) {
                    $('#validationError').text("Error in voucher save");
                    $('#validationError').focus();
                    $('#updateVoucherBtn').attr("disabled", false);
                }
            });
        } else {
            $('#meterInTxtError').text('This value must be a number');
        }
    }
}

function cancelVoucher() {
    $('#remarksTxtError').text('');
    if ($('#remarks').val() != "") {
        var url = "/Trips/RemoveVoucher/";
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
            data: {
                id: $('#tripId').val(),
                remarks: $('#remarks').val()
            },
            cache: false,
            type: "GET",
            success: function (data) {
                $('.progress').css({
                    width: 1 * 100 + '%'
                });
                if (data != "") {
                    $('#validationError').text(data);
                    $('#validationError').focus();
                    $('#updateVoucherBtn').attr("disabled", false);
                }
                else {
                    var url = '/Trips/Index';
                    window.location.href = url;
                }
            },
            error: function (reponse) {
                $('#validationError').text("Error in cancelling voucher");
                $('#validationError').focus();
                $('#updateVoucherBtn').attr("disabled", false);
            }
        });
    }
    else {
        $('#remarks').focus();
        $('#remarksTxtError').text('Please provide a remark');
    }
}

var selectorIdEdit = 5;
function generateDropDownsEdit() {
    var newPackageSelector = '<div align="center" class="row checkbox-highlight  remove-padding  remove-margin"><div id="packageDropDiv' + selectorIdEdit + '">'
                            + '<select id="PackageId' + selectorIdEdit + '" onchange="onPackageChangeEdit(this.id);" name="PackageId" class="dropdown-toggle form-control packageClass"></select>' + '<div class="btn btn-danger btn-raised btn-sm" id="' + selectorIdEdit + '" onclick="onMinusClickEdit(this.id)">Remove <span class="glyphicon glyphicon-trash"></span></div>'
                        + '</div></div>';
    $('.CustomPackagesDiv').append(newPackageSelector);
    getPackagesForNewElements("PackageId" + selectorIdEdit);
    selectorIdEdit++;
}

function onPackageChangeEdit(elemId) {
    $('#updateVoucherBtn').attr('disabled', 'disabled')
    if ($('#' + elemId).val() === '0') {

    } else {
        if ($.inArray($('#' + elemId).val(), packageIdsEdit) != -1) {
            $('#' + elemId).val(0);
        } else {
            packageIdsEdit.push($('#' + elemId).val());
            $('#' + elemId).attr("disabled", true);
        }
        var url = "/Trips/GetPackageFee/";
        $.ajax({
            url: url,
            data: { packageId: $('#' + elemId).val() },
            cache: false,
            type: "GET",
            success: function (data) {
                var packageCost = $('.pcAmount').html();
                var sumOfPc = +packageCost + +data;
                $('.pcAmount').html(sumOfPc.toFixed(2));
                $('#lblTotAmount').html(sumOfPc.toFixed(2));
                $('#error_package_amount').text('');
            },
            error: function (reponse) {
                console.log("error : " + reponse);
            }
        });

    }
}

function onMinusClickEdit(elemId) {

    if ($.inArray($('#PackageId' + elemId).val(), packageIdsEdit) != -1) {
        var selectedVal = $('#PackageId' + elemId).val();
        var index = packageIdsEdit.indexOf($('#PackageId' + elemId).val());
        packageIdsEdit.splice(index, 1);
        $('#packageDropDiv' + elemId).remove();
        $('#' + elemId).remove();

        var url = "/Trips/GetPackageFee/";
        $.ajax({
            url: url,
            data: { packageId: selectedVal },
            cache: false,
            type: "GET",
            success: function (data) {
                $('#updateVoucherBtn').attr('disabled', 'disabled');
                var packageCost = $('.pcAmount').html();
                var sumOfPc = +packageCost - +data;
                $('.pcAmount').html(sumOfPc.toFixed(2));
                $('#lblTotAmount').html(sumOfPc.toFixed(2));
                $('#error_package_amount').text('');
            },
            error: function (reponse) {
                console.log("error : " + JSON.stringify(reponse));
            }
        });

    } else {
        $('#packageDropDiv' + elemId).remove();
        $('#' + elemId).remove();
    }
};
//check box event

function handleClick(cb) {
    $('#updateVoucherBtn').attr("disabled", true);
    $('#error_package_amount').text('');
    $('.CustomPackagesDiv').html('');
    markup = '<div class="form-group">'
                  + '<div id="packageName1"><label class="control-label">Custom Package Amount</label></div>'
                        + '<div class="col-md-9">'
                              + ' <input type="number" class="form-control customPackageAmount" name="customPackageAmount" id="customPackageAmount">'
                        + '</div>'
                  + '</div>'
                 + '</div>';

    if (cb.checked == true) {
        $('.CustomPackagesDiv').append(markup).show();
        $("#meterInTxt").val('');
        $('#meterReadingDiv').hide();
        $('#distance_div').hide();
        $('.pcAmount').text('0.00');
        $('.extraKm').text('0.00');
        $('.totAmount').text('0.00');
        TripDataEdit.IsCustomPackage = true;
    }
    else {
        $("#meterInTxt").val('');
        $('.pcAmount').text('0.00');
        $('.extraKm').text('0.00');
        $('.totAmount').text('0.00');
        $('.CustomPackagesDiv').html('');
        $('#meterReadingDiv').show();
        $('#distance_div').show();
        TripDataEdit.IsCustomPackage = false;
    }
}
function LoadCustomPackageDiv(id) {
    $('#updateVoucherBtn').attr("disabled", true);
    $('#error_package_amount').text('');
    $('.pcAmount').text('0.00');
    $('.extraKm').text('0.00');
    $('.waitedHour').text('0.00');
    $('.totAmount').text('0.00');
    $('#addtionalKmTxt').val(0);
    $('#waitedHourTxt').val(0);
    var markup;
    if (id == 1) {
        $('.CustomPackagesDiv').html('');
        markup = '<div class="form-group">'
                      + '<div id="packageName1"><label class="control-label">Custom Package Amount</label></div>'
                            + '<div class="col-md-9">'
                                  + ' <input type="number" class="form-control customPackageAmount" name="customPackageAmount" id="customPackageAmount">'
                            + '</div>'
                      + '</div>'
                     + '</div>';

        $('.CustomPackagesDiv').append(markup).show();
        $('#addKmDiv').hide();
        $('#meterReadingDiv').hide();
        TripDataEdit.IsCustomPackage = true;
        packageIdsEdit = [];
    }
    else {
        $('.CustomPackagesDiv').html('');
        var markup2 = ' <div class="btn btn-info btn-raised" onclick="generateDropDownsEdit()"><span class="btn-sm">ADD NEW PACKAGE</span> <span class="glyphicon glyphicon-plus"></span></div> <br />';
        $('.CustomPackagesDiv').append(markup2).show();
        $('#waitedHourDiv').show();
        $('#addKmDiv').show();
        TripDataEdit.IsCustomPackage = false;
    }
    // getPackages(); changed
}


function getGuestTypeEdit(elemId) {
    $('#error_package_amount').text('');
    $('#updateVoucherBtn').attr('disabled', 'disabled');
    packageIdsEdit = [];
    var a = '<div class="row margin-bottom-10">'
               + '<div class="col-md-10">'
                   + '<div class="checkbox1" id="checkbox1">'
                        + '<input type="radio" class="PackageRadio1" name="PackageRadio" id="PackageRadio1" value="0" checked=""  onchange="LoadCustomPackageDiv(this.value)">  Package </Br>'
                + '</div>'
                  + '<div class="checkbox2" id="checkbox2">'
                   + '<input type="radio" class="PackageRadio2" name="PackageRadio" id="PackageRadio2" value="1" onchange="LoadCustomPackageDiv(this.value)" >  Custom Package'
               + '</div>'
              + '</div>'
          + '</div>'
       + '<div class="CustomPackagesDiv" id="CustomPackagesDiv"></div>';

    if (elemId == 0) {
        $('#add_km_waiting_div').html('');
        $('.newPackDivEdit').html('');
        $('.CustomPackagesDiv').html('');
        $('#waitedHourDiv').hide();
        $('.checkbox2').hide();
    }
    if (elemId.toUpperCase() === 'GUEST') {
        $('#guest_type_hidden').val('GUEST');
        $('#add_km_waiting_div').html('');
        $('.newPackDivEdit').html('');
        $('.checkbox2').hide();
        $('.CustomPackagesDiv').html('');
        $(".newPackDivEdit").append(a);
        LoadCustomPackageDiv(0);
        $("#meterInTxt").unbind();
        $('.pcAmount').text('0.00');
        $('.extraKm').text('0.00');
        $('.waitedHour').text('0.00');
        $('.totAmount').text('0.00');
        $("#meterReadingDiv").hide();
        $('.roomNumber').show();
        var markUp = ' <div class="col-xs-5" id="waitedHourDiv">'
                                        + '<div class="form-group">'
                                           + '<label class="control-label col-md-6">Waited Hours</label>'
                                             + '<div class="col-md-6">'
                                                 + '<input type="number" class="form-control" name="WaitedHrs" id="waitedHourTxt">'
                                             + '</div>'
                                       + '</div><br />'
                                    + '</div>'
                                    + '<div class="col-xs-5" id="addKmDiv">'
                                        + '<div class="form-group" id="addKMDiv">'
                                          + '<label class="control-label col-md-7">Additional KMs</label>'
                                            + '<div class="col-md-5">'
                                                + '<input type="number" class="form-control" name="AdditionalKM" id="addtionalKmTxt">'
                                            + '</div>'
                                        + '</div>'
                                    + '</div>';
        $('#add_km_waiting_div').append(markUp);
        $('#packageInfoDiv').show();
        $('#addtionalKmTxt').off();
        $('#waitedHourTxt').off();

        addtionalKmCalc();
        waitedHrCalc();

    } else if (elemId.toUpperCase() === 'STAFF') {
        $('#guest_type_hidden').val('STAFF');
        $('#add_km_waiting_div').html('');
        $(".newPackDivEdit").html('');

        var b = '<div class="row margin-bottom-10">'
        + '<div class="col-md-10">'
            + '<div class="checkbox2" id="checkbox2">'
                 + '<input type="checkbox" class="packageCheck" onclick="handleClick(this)"name="packageCheck" id="packageCheck" value="1">  Custom Package'
         + '</div>'
       + '</div>'
   + '</div>'
+ '<div class="CustomPackagesDiv" id="CustomPackagesDiv"></div>';

        var markUp = ' <div class="col-xs-5" id="waitedHourDiv">'
                                       + '<div class="form-group">'
                                           + '<label class="control-label col-md-6">Waited Hours</label>'
                                           + '<div class="col-md-6">'
                                           + '<input type="number" class="form-control" name="WaitedHrs" id="waitedHourTxt">'
                                           + '</div>'
                                       + '</div><br />'
                                   + '</div>'
                                      + '<div class="col-xs-5"  id="distance_div">'
                                       + '<div class="form-group" id="addKMDiv">'
                                           + '<label class="control-label col-md-7">Distance Travelled</label>'
                                           + '<div class="col-md-5">'
                                               + '<input type="number" class="form-control" name="meterInTxt" id="meterInTxt">'
                                               + '<label class="text-danger" id="meterInTxtError"></label>'
                                           + '</div>'
                                       + '</div>'
                                   + '</div>';
        $('#add_km_waiting_div').append(markUp);
        $(".newPackDivEdit").append(b);
        $('#waitedHourDiv').show();
        $("#meterReadingDiv").show();
        $('#addtionalKmTxt').off();
        $('#waitedHourTxt').off();
        $('.pcAmount').text('0.00');
        $('.extraKm').text('0.00');
        $('.waitedHour').text('0.00');
        $('.totAmount').text('0.00');
        waitedHrCalc();

    } else {
        $("#meterReadingDiv").hide();
    }
}

$('#meterInTxtCommon').on('input', function (e) {
    if ($(this).val() != 0) {
        $('#meterValueError').text('');
    }
    else {
        $('#meterValueError').text('Meter reading end cannot be Zero');
    }
    $('label[for=trip_mileage]').html($.trim($('#meterInTxtCommon').val() - $('#meterReadingOut').val()));
});


function addtionalKmCalc() {
    var vehi_type = $('#vehi_type_hidden').val().toLocaleUpperCase();
    var guest_type = $('#guest_type_hidden').val();

    $('#addtionalKmTxt').on('input', function (e) {
        $('#updateVoucherBtn').attr('disabled', 'disabled');
        var additionalKms = $(this).val();
        if (additionalKms % 1 != 0) {
            $('#lblAdditionKmCost').text('0.00');
            //$(this).val("");
        }
        else {
            $("#fareData input[type='hidden']").each(function () {
                if ($(this).attr('data-guestType').toUpperCase() === guest_type) {
                    if ($(this).attr('name').toUpperCase() === vehi_type) {
                        var perKmForGuestCar = $(this).attr('value');
                        var costForAddtionalKmsCar = additionalKms * perKmForGuestCar;
                        $('#lblAdditionKmCost').html(costForAddtionalKmsCar.toFixed(2));
                    }
                }
            });
        }
    });
}

function waitedHrCalc() {
    var vehi_type = $('#vehi_type_hidden').val().toLocaleUpperCase();;
    var guest_type = $('#guest_type_hidden').val();

    $('#waitedHourTxt').on('input', function (e) {
        $('#updateVoucherBtn').attr('disabled', 'disabled');
        var waitedHours = new Number($(this).val());
        if (waitedHours % 1 != 0) {
            $('#lblWaitedHourCost').text('0.00');
            //$(this).val("");
        } else {
            $("#fareData input[type='hidden']").each(function () {
                if ($(this).attr('data-guestType').toUpperCase() === guest_type) {
                    if ($(this).attr('name').toUpperCase() === vehi_type) {
                        var waitedHourRateGuestCar = $(this).attr('data-waitingCharge');
                        var costForWaitedHoursCar = waitedHours * waitedHourRateGuestCar;
                        $('#lblWaitedHourCost').html(costForWaitedHoursCar.toFixed(2));
                    }
                }
                if (guest_type === 'STAFF' && vehi_type !== 'BUS' && vehi_type !== 'VAN') {
                    if ($(this).attr('name').toUpperCase() === 'CAR/SUV') {
                        var waitedHourRateGuestCar = $(this).attr('data-waitingCharge');
                        var costForWaitedHoursCar = waitedHours * waitedHourRateGuestCar;
                        $('#lblWaitedHourCost').html(costForWaitedHoursCar.toFixed(2));
                    }
                }
            });
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
function get_guest_type_new(elemId) {
    if (elemId == 0) {
        $('#add_km_waiting_div').html('');
        $('.newPackDivEdit').html('');
        $('.CustomPackagesDiv').html('');
        $('#waitedHourDiv').hide();
    }
    else {
        $('#add_km_waiting_div').html('');
        $('.newPackDivEdit').html('');
        $('.CustomPackagesDiv').html('');
        $("#meterInTxt").unbind();
        $("#meterReadingDiv").hide();
        $('.roomNumber').show();
        var markUp = ' <div class="col-xs-5" id="waitedHourDiv">'
                                        + '<div class="form-group">'
                                           + '<label class="control-label col-md-6">Waited Hours</label>' + '<div class="col-md-6">'
                                             + '<div class="col-md-6">'
                                               + '<input type="number" class="form-control" name="WaitedHrs" id="waitedHourTxt">'
                                            + '</div>'
                                        + '</div><br />'
                                    + '</div>';
        $('#add_km_waiting_div').append(markUp);
        $('#packageInfoDiv').show();
        $('#addtionalKmTxt').off();
        $('#waitedHourTxt').off();

        addtionalKmCalc();
        waitedHrCalc();
    }
}
function SyncGPSEdit() {
    $('span[for=gap_meter_reading_status]').text('');
    $('#meterInTxtCommon').val(0);
    var vehiNum = $('#VehicleNumber').val();
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
                $('#meterValueError').text(data.error);
                $('label[for=meter_reading_gps]').text(0);
                $("#wrongbar").show();
            }
            else {
                $('label[for=meter_reading_gps]').text(data.meter_reading);
                $('#meterInTxtCommon').val(data.meter_reading);
                $('label[for=meter_reading_gap]').html($('#meterInTxtCommon').val() - $('label[for=meter_reading_gps]').text());//edit page   
                $('label[for=trip_mileage]').html($.trim($('#meterInTxtCommon').val() - $('#meterReadingOut').val()));
                $("#rightbar").show();
            }
        },
        error: function (reponse) {
            $("#loadingbarimg").hide();
            $('#meterValueError').text('Error retrieving meter reading');
            $('label[for=meter_reading_gps]').text(0);
            $("#wrongbar").show();
        }
    });
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
                var markup;
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

function getPackagesForNewElements(elemId) {
    var url = "/Trips/LoadPackages/";
    var procemessage = "<option value='0'> Please wait...</option>";
    $('#' + elemId).html(procemessage).show();
    var payment_type = $('#payment_type_hidden').val();

    $.ajax({
        url: url,
        data: { data: payment_type },
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
$(document).on('keyup', '#customPackageAmount', function () {
    $('#customPackageAmountHidden').val($('#customPackageAmount').val());
});
function getSettlementCategory(value) {
    $('#error_paymentCategory').text('');
    $('#error_corporateName').text('');
    $('#error_roomNumber').text('');
    $('#settlement_category_div').empty();
    $('#corporate_div').empty();
    getGuestTypeEdit("guest");//remove guest type 
    $('#payment_type_hidden').val('Revenue');
    if (value.toUpperCase() === 'CREDIT') {

        var html_markup = '<div class="form-group">'
                              + '<label class="control-label col-md-6">Settlement Category</label>'
                                  + '<div class="col-md-6">'
                                      + '<select id="PaymentCategory" name="PaymentCategory" onchange="javascript: getCorporates(this.value);" class="form-control"></select>'
                                      + '<span class="control-label" style="color:red" id="error_paymentCategory"></span>'
                                  + '</div>'
                                + '</div><br />';
        $('#settlement_category_div').append(html_markup);

        var url = "/Trips/LoadSettlementCategory/";
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
                    $('#PaymentCategory').html(markup).show();
                }
            },
            error: function (reponse) {
                console.log("error : " + reponse);
            }
        });
    }
    if (value.toUpperCase() === 'NON REVENUE') {
        $('#payment_type_hidden').val('Non Revenue');
    }
}
function getCorporates(value) {
    $('#error_paymentCategory').text('');
    $('#error_corporateName').text('');
    $('#error_roomNumber').text('');
    $('#corporate_div').empty();

    if (value.toUpperCase() === 'DIRECT CREDIT CORPORATE') {
        var html_markup = '<div class="form-group">'
                            + '<label class="control-label col-md-4">Corporate</label>'
                                + '<div class="col-md-8">'
                                    + '<select id="CorporateName" name="CorporateName" class="form-control"  onchange="javascript: onChangeCorporates(this.value);"></select>'
                                       + '<span class="control-label" style="color:red" id="error_corporateName"></span>'
                                 + '</div>'
                              + '</div><br />';
        $('#corporate_div').append(html_markup);

        var url = "/Trips/loadCorporateList/";
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
                    $('#CorporateName').html(markup).show();
                }
            },
            error: function (reponse) {
                console.log("error : " + reponse);
            }
        });
    }
    if (value.toUpperCase() === 'HOTEL BILLING STAFF') {
        getGuestTypeEdit("staff");
    }
    else {
        getGuestTypeEdit("guest");
    }
    if (value.toUpperCase() === 'NO SHOW') {
        var html_markup = '<div class="form-group">'
                           + '<label class="control-label col-md-6">Reservation No</label>'
                               + '<div class="col-md-6">'
                                   + '<input type="text" id="ReservationNo" name="ReservationNo" class="form-control"  />'
                                      + '<span class="field-validation-valid text-danger" style="color:red" id="error_reservationNo"></span>'
                                + '</div>'
                             + '</div><br />';
        $('#corporate_div').append(html_markup);
    }

}
function onChangeCorporates(value) {
    $('#error_paymentCategory').text('');
    $('#error_corporateName').text('');
    $('#error_roomNumber').text('');
}

function validateEditForm() {
    $("#error_vehicle_select").text('');
    $("#error_driver_select").text('');
    $('#meterValueError').text('');
    $('#error_paymentCategory').text('');
    $('#error_corporateName').text('');
    $('#error_reservationNo').text('');
    $('#error_roomNumber').text('');
    $('#error_guestName').text('');
    var validated = true;

    var vehicle_select = $('#Vehicle :selected').val();
    var driver_select = $('#Driver :selected').val();
    var meterInVal = $('#meterInTxtCommon').val();
    var payment_cat = $('#PaymentCategory :selected').val();
    var corporate_name = $('#CorporateName :selected').val();
    var reservation_num = $('#ReservationNo').val();
    var packageCost = $('.pcAmount').html();

    if (meterInVal == 0) {
        $('#meterValueError').text('Meter reading end cannot be Zero');
        $('#meterInTxtCommon').focus();
        validated = false;
    }
    else if (payment_cat == '0') {
        $('#error_paymentCategory').text('Select Payment Category');
        $('#PaymentCategory').focus();
        validated = false;
    }
    else if (payment_cat == 'No Show' && reservation_num === '' && payment_cat != undefined) {
        $('#error_reservationNo').text('Provide a reservation No');
        $('#ReservationNo').focus();
        validated = false;
    }
    else if (payment_cat == 'Hotel Billing Guest' && payment_cat != undefined) {
        if ($('#RoomNumber').val() == '') {
            $('#error_roomNumber').text('Please provide a room no');
            $('#RoomNumber').focus();
            validated = false;
        }
    }
    else if (payment_cat == 'Hotel Billing Staff') {
        if ($('#GuestName').val() == '') {
            $('#error_guestName').text('Please provide a name');
            $('#GuestName').focus();
            validated = false;
        }
    }
    else if (corporate_name == '0' && corporate_name != undefined) {
        $('#error_corporateName').text('Select Corporate');
        $('#CorporateName').focus();
        validated = false;
    }
    return validated;
}