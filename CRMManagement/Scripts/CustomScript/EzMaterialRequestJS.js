$("Document").ready(function () {

    /*  alert('santosh Test entry');*/

});

function SubmitFormSave() {
    var ezSectionMaster = {
        Description: $("#Description").val(),
        isApplicableForTable: $("#isApplicableForTable").val(),
        isApplicableForTable: $("#WorkflowFk").val()
    };

    var userRequest = {
        SectionId: $("#gblSectionId").val(),
        UserName: $("#gblUserName").val()
    };

    // Combine Order Header and Detail data
    var EzSectionMasterVM = {
        ezSectionMaster: ezSectionMaster,
        userRequest: userRequest
    };


    // AJAX request to send data to the controller
    $.ajax({
        url: '/SectionMaster/Create',
        method: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(EzSectionMasterVM),
        async: false,
        success: function (response) {
            //callIndexView(response);
            alert(SaveSuccessMessage);
            window.location.href = response.redirectUrl;
        },
        error: function (error) {
            // Handle error if needed
            alert(SaveErrorMessage);
        }
    });


}

function tool_bar(expression) {

    var create = $("#gblcreateRecord").val();
    var edit = $("#gbleditRecord").val();
    var delete1 = $("#gbldeleteRecord").val();
    var save = $("#gblsaveRecord").val();
    if (validate_User_Right(expression, create, edit, delete1, save) == false) {
        alert(NoRightsMessage);
        return;
    }

    switch (expression) {
        case "Create":
            alert(expression);
            break;
        case "Edit":
            // code to be executed if expression matches value2
            alert(expression);
            break;
        case "Delete":
            // code to be executed if expression matches value2
            alert(expression);
            break;
        case "Save":
            SubmitFormSave();
            break;
        case "Clear":
            // code to be executed if expression matches value2
            alert(expression);
            break;
        case "Close":
            // code to be executed if expression matches value2
            alert(expression);
            break;

        default:
        // code to be executed if none of the cases match the expression
    }


}