﻿$(document).ready(function () {

});

$(function () {
    $(".date").datepicker({
        autoclose: true,
        todayHighlight: true
    }).datepicker('update', new Date());;
});