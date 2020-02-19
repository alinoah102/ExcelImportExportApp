
var jsonData;
var row;
var newDate

var PersonID;
var FirstName;
var LastName;
var Gender; 
var DateOfBirth; 
var MaritalStatus;
var EmailAddress;
var StreetAddressLine1;
var StreetAddressLine2;
var City;
var PhoneNumber;
var State; 
var Zip;

var PersonID_MODAL_BOX;
var FirstName_MODAL_BOX;
var LastName_MODAL_BOX;
var Gender_MODAL_BOX;
var DateOfBirth_MODAL_BOX;
var MaritalStatus_MODAL_BOX;
var EmailAddress_MODAL_BOX;
var StreetAddressLine1_MODAL_BOX;
var StreetAddressLine2_MODAL_BOX;
var City_MODAL_BOX;
var PhoneNumber_MODAL_BOX;
var State_MODAL_BOX; 
var Zip_MODAL_BOX;
 

    $(".modal-edit-button").click(function (e) {
        $("#myModal").modal();


        var date = $(this).closest('tr').find('#DOB_HTML_ID').text().trim();
        newDate = new Date(date).toLocaleDateString('fr-CA');
        row = $(this).closest('tr');

        PersonID = $(row).attr("id");
        FirstName = $(row).find('#FirstName_HTML_ID');
        LastName = $(row).find('#LastName_HTML_ID');
        Gender = $(row).find('#Gender_HTML_ID');
        DateOfBirth = $(row).find('#DOB_HTML_ID');
        MaritalStatus = $(row).find('#MaritalStatus_HTML_ID');
        EmailAddress = $(row).find('#EmailAddress_HTML_ID');
        StreetAddressLine1 = $(row).find('#StreetAddressLine1_HTML_ID');
        StreetAddressLine2 = $(row).find('#StreetAddressLine2_HTML_ID');
        City = $(row).find('#City_HTML_ID');
        PhoneNumber = $(row).find('#PhoneNumber_HTML_ID');
        State = $(row).find('#State_HTML_ID');


        PersonID_MODAL_BOX = $('#MODAL_ID');
        FirstName_MODAL_BOX = $('#FirstName_MODAL_ID');
        LastName_MODAL_BOX = $('#LastName_MODAL_ID');
        Gender_MODAL_BOX = $('#Gender_MODAL_ID');
        DateOfBirth_MODAL_BOX = $('#DOB_MODAL_ID'); 
        MaritalStatus_MODAL_BOX = $('#MaritalStatus_MODAL_ID');
        EmailAddress_MODAL_BOX = $('#EmailAddress_MODAL_ID');
        StreetAddressLine1_MODAL_BOX = $('#StreetAddressLine1_MODAL_ID');
        StreetAddressLine2_MODAL_BOX = $('#StreetAddressLine2_MODAL_ID');
        City_MODAL_BOX = $('#City_MODAL_ID');
        Zip_MODAL_BOX = $('#Zip_MODAL_ID');
        PhoneNumber_MODAL_BOX = $('#PhoneNumber_MODAL_ID');
        State_MODAL_BOX = $('#State_MODAL_ID');


        $(PersonID_MODAL_BOX).val(PersonID.replace("PersonID-", ""));
        $(FirstName_MODAL_BOX).val(FirstName.text().trim());
        $(LastName_MODAL_BOX).attr("value", ($(this).closest('tr').find('#LastName_HTML_ID').text().trim()));
        $(Gender_MODAL_BOX).val(($(this).closest('tr').find('#Gender_HTML_ID').text().trim()));
        $(DateOfBirth_MODAL_BOX).val(newDate);
        $(MaritalStatus_MODAL_BOX).val($(this).closest('tr').find('#MaritalStatus_HTML_ID').text().trim());
        $(EmailAddress_MODAL_BOX).attr("value", ($(this).closest('tr').find('#EmailAddress_HTML_ID').text().trim()));
        $(StreetAddressLine1_MODAL_BOX).attr("value", ($(this).closest('tr').find('#StreetAddressLine1_HTML_ID').text().trim()));
        $(StreetAddressLine2_MODAL_BOX).attr("value", ($(this).closest('tr').find('#StreetAddressLine2_HTML_ID').text().trim()));
        $(City_MODAL_BOX).attr("value", ($(this).closest('tr').find('#City_HTML_ID').text().trim()));
        $(Zip_MODAL_BOX).attr("value", ($(this).closest('tr').find('#Zip_HTML_ID').text().trim()));
        $(PhoneNumber_MODAL_BOX).attr("value", ($(this).closest('tr').find('#PhoneNumber_HTML_ID').text().trim()));
        $(State_MODAL_BOX).val($(this).closest('tr').find('#State_HTML_ID').text().trim());




    });

$("#SearchMain").click(function (e) {
    $('.collapse').collapse('hide');
    e.preventDefault();
});


$("#update").click(function () {



    var newModel = {
        PersonID: $(PersonID_MODAL_BOX).prop("value"),
        FirstName: $(FirstName_MODAL_BOX).prop("value"),
        LastName: $(LastName_MODAL_BOX).prop("value"),
        Gender: $(Gender_MODAL_BOX).prop("value"),
        DateOfBirth: newDate,
        MaritalStatus: $(MaritalStatus_MODAL_BOX).prop("value"),
        EmailAddress: $(EmailAddress_MODAL_BOX).prop("value"),
        StreetAddressLine1: $(StreetAddressLine1_MODAL_BOX).prop("value"),
        StreetAddressLine2: $(StreetAddressLine2_MODAL_BOX).prop("value"),
        City: $(City_MODAL_BOX).prop("value"),
        Zip: $(Zip_MODAL_BOX).prop("value"),
        PhoneNumber: $(PhoneNumber_MODAL_BOX).prop("value"),
        State: $(State_MODAL_BOX).prop("value")
    };

    jsonData = JSON.stringify(newModel);

    $.ajax({
        type: "POST",
        url: '/Account/UpdatePerson',
        data: { json: jsonData },
        datatype: "text",
        success: function (response) {
            if (response.success) {

                $(row).fadeOut(250).fadeIn(250);

                $(PersonID).text($(PersonID_MODAL_BOX).prop("value"));
                $(FirstName).text($(FirstName_MODAL_BOX).prop("value"));
                $(LastName).text($(LastName_MODAL_BOX).prop("value"));
                $(Gender).text($(Gender_MODAL_BOX).prop("value"));
                $(DateOfBirth).text(newDate);
                $(MaritalStatus).text($(MaritalStatus_MODAL_BOX).prop("value"));
                $(EmailAddress).text($(EmailAddress_MODAL_BOX).prop("value"));
                $(StreetAddressLine1).text($(StreetAddressLine1_MODAL_BOX).prop("value"));
                $(StreetAddressLine2).text($(StreetAddressLine2_MODAL_BOX).prop("value"));
                $(City).text($(City_MODAL_BOX).prop("value"));
                $(PhoneNumber).text($(PhoneNumber_MODAL_BOX).prop("value"));
                $(State).text($(State_MODAL_BOX).prop("value"));
                $(Zip).text($(Zip_MODAL_BOX).prop("value"));


                // alert("made it");
            } else {
                // DoSomethingElse()
                alert("didnt make it")
            }
        },
        error: function (response) {
            alert("error!");  // 
        }
    });

});
    $("#export").click(function () {

        var newModel = {
            PersonID: $(PersonID_MODAL_BOX).prop("value"),
            FirstName: $(FirstName_MODAL_BOX).prop("value"),
            LastName: $(LastName_MODAL_BOX).prop("value"),
            Gender: $(Gender_MODAL_BOX).prop("value"),
            DateOfBirth: newDate,
            MaritalStatus: $(MaritalStatus_MODAL_BOX).prop("value"),
            EmailAddress: $(EmailAddress_MODAL_BOX).prop("value"),
            StreetAddressLine1: $(StreetAddressLine1_MODAL_BOX).prop("value"),
            StreetAddressLine2: $(StreetAddressLine2_MODAL_BOX).prop("value"),
            City: $(City_MODAL_BOX).prop("value"),
            Zip: $(Zip_MODAL_BOX).prop("value"),
            PhoneNumber: $(PhoneNumber_MODAL_BOX).prop("value"),
            State: $(State_MODAL_BOX).prop("value")
        };

        jsonData = JSON.stringify(newModel);

        $.ajax({
            type: "POST",
            url: '/Account/ExportPerson',
            data: { json: jsonData },
            datatype: "text",
            success: function (response) {
                if (response.success) {

                    $(row).css('background-color', 'green');
                    $(row).fadeOut(250).fadeIn(250);


                    // alert("made it");
                } else {
                    // DoSomethingElse()
                    alert("didnt make it")
                }
            },
            error: function (response) {
                alert("error!");  // 
            }
        });
    });

