$(function () {
    $.material.init();
});
$(document).ready(function () {
    //$('#HotelName').val(0);
    // $('#loginBtn').removeAttr('disabled');
});
function enableButton() {
    if ($('#Email').val() == null || $('#Email').val() == '') {
        $('#loginBtn').attr('disabled', 'disabled');
    } else {
        $('#loginBtn').removeAttr('disabled');
    }
}

//myInput && myInput.value