$(document).ready(function () {
    $(".modal-edit-button").click(function (e) {
        $("#myModal").modal();


        var date = $(this).closest('tr').find('#DOB_HTML_ID').text().trim();
        var newDate = new Date(date).toLocaleDateString('fr-CA');
        

        $('#MODAL_ID').attr("value", $(this).closest('tr').attr("id").replace("PersonID-", ""));
        $('#FirstName_MODAL_ID').attr("value", ($(this).closest('tr').find('#FirstName_HTML_ID').text().trim()));
        $('#LastName_MODAL_ID').attr("value", ($(this).closest('tr').find('#LastName_HTML_ID').text().trim()));
        $('#Gender_MODAL_ID').val(($(this).closest('tr').find('#Gender_HTML_ID').text().trim()));
        $('#DOB_MODAL_ID').val(newDate);
        $('#MaritalStatus_MODAL_ID').val($(this).closest('tr').find('#MaritalStatus_HTML_ID').text().trim());
        $('#EmailAddress_MODAL_ID').attr("value", ($(this).closest('tr').find('#EmailAddress_HTML_ID').text().trim()));
        $('#StreetAddressLine1_MODAL_ID').attr("value", ($(this).closest('tr').find('#StreetAddressLine1_HTML_ID').text().trim()));
        $('#StreetAddressLine2_MODAL_ID').attr("value", ($(this).closest('tr').find('#StreetAddressLine2_HTML_ID').text().trim()));
        $('#City_MODAL_ID').attr("value", ($(this).closest('tr').find('#City_HTML_ID').text().trim()));
        $('#Zip_MODAL_ID').attr("value", ($(this).closest('tr').find('#Zip_HTML_ID').text().trim()));
        $('#PhoneNumber_MODAL_ID').attr("value", ($(this).closest('tr').find('#PhoneNumber_HTML_ID').text().trim()));
        $('#State_MODAL_ID').val($(this).closest('tr').find('#State_HTML_ID').text().trim());
       


    });
});