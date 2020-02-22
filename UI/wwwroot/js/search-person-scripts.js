
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




$(".delete-row-icon").click(function (e) {
    

    PersonID = $(row).attr("id");

    if (PersonID == null) {
        feedbackTemplate("You Must Select A Row To Delete", "warning")
    }

});


$("#myTable tr").click(function (e) {
   
    var selected = $(this).hasClass("row-highlight");
    $("#myTable tr").removeClass("row-highlight");
    if (!selected) {
        $(this).addClass("row-highlight");
    }

    row = $(this);
       

});


 

    $(".modal-edit-button").click(function (e) {
        $("#myModal").modal();


        if (row == null) {
           
            feedbackTemplate("You Must Select A Row Before Edit Attempt", "info")
            
        }

        var date = $(row).find('#DOB_HTML_ID').text().trim();
        newDate = new Date(date).toLocaleDateString('fr-CA');
        //row = $(this).closest('tr');

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

        if(PersonID != null)
            $(PersonID_MODAL_BOX).val(PersonID.replace("PersonID-", ""));
        $(FirstName_MODAL_BOX).val(FirstName.text().trim());
        $(LastName_MODAL_BOX).attr("value", ($(row).find('#LastName_HTML_ID').text().trim()));
        $(Gender_MODAL_BOX).val(($(row).find('#Gender_HTML_ID').text().trim()));
        $(DateOfBirth_MODAL_BOX).val(newDate);
        $(MaritalStatus_MODAL_BOX).val($(row).find('#MaritalStatus_HTML_ID').text().trim());
        $(EmailAddress_MODAL_BOX).attr("value", ($(row).find('#EmailAddress_HTML_ID').text().trim()));
        $(StreetAddressLine1_MODAL_BOX).attr("value", ($(row).find('#StreetAddressLine1_HTML_ID').text().trim()));
        $(StreetAddressLine2_MODAL_BOX).attr("value", ($(row).find('#StreetAddressLine2_HTML_ID').text().trim()));
        $(City_MODAL_BOX).attr("value", ($(row).find('#City_HTML_ID').text().trim()));
        $(Zip_MODAL_BOX).attr("value", ($(row).find('#Zip_HTML_ID').text().trim()));
        $(PhoneNumber_MODAL_BOX).attr("value", ($(row).find('#PhoneNumber_HTML_ID').text().trim()));
        $(State_MODAL_BOX).val($(row).find('#State_HTML_ID').text().trim());




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

                //$(row).fadeOut(250).fadeIn(250);

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

                var myRow = $(row);

                myRow.addClass('update-row-success');

                setTimeout(function () {
                    myRow.removeClass('update-row-success');
                }, 200);

                myRow.removeClass('row-highlight');

                feedbackTemplate(response.responseText, "success")
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

                   
                        feedbackTemplate(response.responseText, "success")
                    
                  

                }
                else {
                    // DoSomethingElse()
                    alert("didnt make it")
                }
            } ,
            error: function (response) {
                alert("error!");  // 
            }
        });


    });

   

        $("#YesDelete").click(function () {

            jsonData = PersonID.replace("PersonID-", "");

            $.ajax({
                type: "POST",
                url: '/Account/DeletePerson',
                data: { json: jsonData },
                datatype: "text",
                success: function (response) {
                    if (response.success) {

                        var myRow = $(row);

                        myRow.addClass('delete-row-success');

                        $(".delete-row-success").fadeOut(400, function () {
                            $(myRow).remove();
                        });

                        feedbackTemplate(response.responseText, "success");
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


$(".result-message-box").fadeOut(15000, function () {
    $(".result-message-box").remove();
});


$("#addPersonModalButton").click(function () {

    var date = $('#DOB_MODAL_ID_NEW_PERSON').val();
   


    var newModel = {
        PersonID: $("#PersonID_MODAL_ID_NEW_PERSON").prop("value"),
        FirstName: $("#FirstName_MODAL_ID_NEW_PERSON").prop("value"),
        LastName: $("#LastName_MODAL_ID_NEW_PERSON").prop("value"),
        Gender: $("#Gender_MODAL_ID_NEW_PERSON").prop("value"),
        DateOfBirth: date,
        MaritalStatus: $("#MaritalStatus_MODAL_ID_NEW_PERSON").prop("value"),
        EmailAddress: $("#EmailAddress_MODAL_ID_NEW_PERSON").prop("value"),
        StreetAddressLine1: $("#StreetAddressLine1_MODAL_ID_NEW_PERSON").prop("value"),
        StreetAddressLine2: $("#StreetAddressLine2_MODAL_ID_NEW_PERSON").prop("value"),
        City: $("#City_MODAL_ID_NEW_PERSON").prop("value"),
        Zip: $("#Zip_MODAL_ID_NEW_PERSON").prop("value"),
        PhoneNumber: $("#PhoneNumber_MODAL_ID_NEW_PERSON").prop("value"),
        State: $("#State_MODAL_ID_NEW_PERSON").prop("value")
    };

    jsonData = JSON.stringify(newModel);

    $.ajax({
        type: "POST",
        url: '/Account/AddPerson',
        data: { json: jsonData },
        datatype: "text",
        success: function (response) {
            if (response.success) {

                feedbackTemplate(response.responseText, "success");

            }
            else {
                // DoSomethingElse()
                alert("didnt make it")
            }
        },
        error: function (response) {
            alert("error!");  // 

        }
    });


})


function feedbackTemplate(message,  noticeType) {

    var template = `

             <div class="toast" data-delay="10000" role="alert" aria-live="assertive" aria-atomic="true">
              <div class="toast-header">
                <img  class="rounded mr-2" >
                <strong class="mr-auto">Message</strong>
                <small class="text-muted">1 second ago</small>
                <button type="button" class="ml-2 mb-1 close" data-dismiss="toast" aria-label="Close">
                  <span aria-hidden="true">&times;</span>
                </button>
              </div>
              <div class="toast-body">
                    <div class="notice notice-${noticeType} result-message-box">
                    <strong>Notice</strong> ${message}
                </div>
               
              </div>
            </div>
            `

    $("#FeedbackTemplate").append(template);

    $('.toast').toast('show');
}


$("#ExportIcon").click(function () {


    var table = $('#myTable').tableToJSON();

    var array;
    a = new Array();
    b = new Object();

    for (var item in table) {
        var newModel = {
            FirstName: table[item]["First Name"],
            LastName: table[item]["Last Name"],
            Gender: table[item]["Gender"],
            DateOfBirth: table[item]["Date Of Birth"],
            MaritalStatus: table[item]["Marital Status"],
            EmailAddress: table[item]["Email Address"],
            StreetAddressLine1: table[item]["Address Line 1"],
            StreetAddressLine2: table[item]["Address Line 2"],
            City: table[item]["City"],
            Zip: table[item]["Zip"],
            PhoneNumber: table[item]["Phone Number"],
            State: table[item]["State"]
        };

        a[item] = newModel;
    }

    jsonData = JSON.stringify(a);

    $.ajax({
        type: "POST",
        url: '/Account/ExportPersonList',
        data: { json: jsonData },
        datatype: "text",
        success: function (response) {
            if (response.success) {


                feedbackTemplate(response.responseText, "success")



            }
            else {
                // DoSomethingElse()
                alert("didnt make it")
            }
        },
        error: function (response) {
            alert("error!");  // 
        }
    });


});
