$(document).ready(function () {
});

//Check customer exist by phone number, if so Retrive
function IsCustomerExist() {
    var phoneNumber = $('#PhoneNumber').val();
    var filter = /^([0-9-+]{10,})$/;
    if (!phoneNumber) {
        $('#PhoneNumberValidationMessage').text("Phone number is required.");        
    }
    else if (!filter.test(phoneNumber)) {
        $('#PhoneNumberValidationMessage').text("Please enter valid phone number.");
    }
    else {
        $('#PhoneNumberValidationMessage').text("");

        var url = "/Customer/IsCustomerExistByPhonenumber";
        $.ajax({
            url: url,
            type: 'GET',
            data: {
                phoneNumber: phoneNumber
            },
            success: function (result) {
                if (result.isExist) {
                    SetCustomerValues(result.customer);
                    ValidateCustomerInputs();
                }
                else {
                    ShowNotificationModal("No customer for this number.");
                    var customer = new Object();
                    customer.PhoneNumber = phoneNumber;
                    SetCustomerValues(customer);
                }
            },
            error: function (err) {
                //alert("error" + JSON.stringify(err));
                ShowNotificationModal("Internal Server Error.");
            }
        });
    }
}

//Save Customer a record
function CreateCustomer() {
    if (ValidateCustomerInputs()) {
        var data = GetCustomerObject();
        var url = "/Customer/Create";
        $.post(url, data)
             .done(function (result) {
                 ShowNotificationModal(result.message);
             })
            .fail(function () {
                ShowNotificationModal("Internal Server Error.");
            });
    }
}

//Update Customer a record
function UpdateCustomer() {
    if (ValidateCustomerInputs()) {
        var data = GetCustomerObject();
        var url = "/Customer/Edit";
        $.post(url, data)
             .done(function (result) {
                 ShowNotificationModal(result.message);
             })
            .fail(function () {
                ShowNotificationModal("Internal Server Error.");
            });
    }
}

//Return object of customer details from form values
function GetCustomerObject() {
    var customer = new Object();
    customer.FirstName = $('#FirstName').val();
    customer.LastName = $('#LastName').val();
    customer.PhoneNumber = $('#PhoneNumber').val();
    customer.Email = $('#Email').val();
    customer.Address = $('#Address').val();

    return customer;
}

//Set customer values of form 
function SetCustomerValues(customer) {
    $('#FirstName').val(customer.FirstName);
    $('#LastName').val(customer.LastName);
    $('#PhoneNumber').val(customer.PhoneNumber);
    $('#Email').val(customer.Email);
    $('#Address').val(customer.Address);
    $('#TripCount').val(customer.TripCount);
    $('#CustomerId').val(customer.CustomerId);
}

//Validate customer inputs
function ValidateCustomerInputs() {
    var isValid = true;

    var customer = GetCustomerObject();

    //Validate phone number
    var phoneNumberFilter = /^([0-9-+]{10,})$/;
    if (!customer.PhoneNumber) {
        $('#PhoneNumberValidationMessage').text("Phone number is required.");
        isValid = false;
    }
    else if (!phoneNumberFilter.test(customer.PhoneNumber)) {
        $('#PhoneNumberValidationMessage').text("Please enter valid phone number.");
        isValid = false;
    }
    else {
        $('#PhoneNumberValidationMessage').text("");
    }

    //Validate First Name
    if (!customer.FirstName) {
        $('#FirstNameValidationMessage').text("First name is required.");
        isValid = false;
    }
    else {
        $('#FirstNameValidationMessage').text("");
    }

    //Validate Last Name
    if (!customer.LastName) {
        $('#LastNameValidationMessage').text("Last name is required.");
        isValid = false;
    }
    else {
        $('#LastNameValidationMessage').text("");
    }

    //Validate email
    var emailFilter = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    // regular expresion that accepts unicode
    //var emailFilter = /^(([^<>()\[\]\.,;:\s@\"]+(\.[^<>()\[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i;
    if (!customer.Email) {
        $('#EmailValidationMessage').text("Email is required.");
        isValid = false;
    }
    else if (!emailFilter.test(customer.Email)) {
        $('#EmailValidationMessage').text("Please enter valid email.");
        isValid = false;
    }
    else {
        $('#EmailValidationMessage').text("");
    }

    //Validate Address
    if (!customer.Address) {
        $('#AddressValidationMessage').text("Address is required.");
        isValid = false;
    }
    else {
        $('#AddressValidationMessage').text("");
    }

    return isValid;
}


function ValidatePhoneNumber() {
    var customer = GetCustomerObject();
    var phoneNumberFilter = /^([0-9-+]{10,})$/;
    if (!customer.PhoneNumber) {
        $('#PhoneNumberValidationMessage').text("Phone number is required.");
    }
    else if (!phoneNumberFilter.test(customer.PhoneNumber)) {
        $('#PhoneNumberValidationMessage').text("Please enter valid phone number.");
    }
    else {
        $('#PhoneNumberValidationMessage').text("");
    }
}

function ValidateFirstName() {
    var customer = GetCustomerObject();
    if (!customer.FirstName) {
        $('#FirstNameValidationMessage').text("First name is required.");
        isValid = false;
    }
    else {
        $('#FirstNameValidationMessage').text("");
    }
}

function ValidateLastName() {
    var customer = GetCustomerObject();
    if (!customer.LastName) {
        $('#LastNameValidationMessage').text("Last name is required.");
        isValid = false;
    }
    else {
        $('#LastNameValidationMessage').text("");
    }
}

function ValidateEmail() {
    var customer = GetCustomerObject();
    var emailFilter = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    // regular expresion that accepts unicode
    //var emailFilter = /^(([^<>()\[\]\.,;:\s@\"]+(\.[^<>()\[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i;
    if (!customer.Email) {
        $('#EmailValidationMessage').text("Email is required.");        
    }
    else if (!emailFilter.test(customer.Email)) {
        $('#EmailValidationMessage').text("Please enter valid email.");        
    }
    else {
        $('#EmailValidationMessage').text("");
    }
}

function ValidateAddress() {
    var customer = GetCustomerObject();
    if (!customer.Address) {
        $('#AddressValidationMessage').text("Address is required.");
        isValid = false;
    }
    else {
        $('#AddressValidationMessage').text("");
    }
}

function ShowNotificationModal(message) {
    $('#notificationModalBody').text(message);
    $('#notificationModal').modal('show');
}