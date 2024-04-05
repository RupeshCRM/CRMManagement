
function FormsButtonOptions(oprType) {

    var Id = $("#gblSectionId").val();
    var UserName = $("#gblUserName").val();


    if (oprType == "Create" || oprType == "Clear") {
        // AJAX request to send data to the controller
        $.ajax({
            url: '/EzModuleMaster/Clear',
            method: 'GET',
            contentType: 'application/json',
            data: { SectionId: Id, UserName: UserName },
            async: false,
            success: function (response) {
                window.location.href = response.redirectUrl;
            },
            error: function (error) {
                // Handle error if needed
                alert(SaveErrorMessage);
            }
        });
    }
    else if (oprType == "Close") {
        // AJAX request to send data to the controller
        $.ajax({
            url: '/EzModuleMaster/Close',
            method: 'GET',
            contentType: 'application/json',
            data: { SectionId: Id, UserName: UserName },
            async: false,
            success: function (response) {
                window.location.href = response.redirectUrl;
            },
            error: function (error) {
                // Handle error if needed
                alert(SaveErrorMessage);
            }
        });
    }


}

function tool_bar(expression) {

    var create = $("#gblcreateRecord").val();
    var edit = $("#gbleditRecord").val();
    var delete1 = $("#gbldeleteRecord").val();
    var save = $("#gblsaveRecord").val();



    if (expression != 'Close' && expression != 'Clear') {

        if (validate_User_Right(expression, create, edit, delete1, save) == false) {
            alert(NoRightsMessage);
            return;
        }
    }


    switch (expression) {
        case "Create":
            FormsButtonOptions('Create');
            break;
        case "Edit":
            // code to be executed if expression matches value2
            if (confirm(BeforeSaveConfirmationMessage) == true) {
                SubmitFormSave();
            }

            break;
        case "Delete":
            // code to be executed if expression matches value2
            if (confirm(DeleteConfirmationMessage) == true) {
                SubmitFormSave();
            }
            break;
        case "Save":
            if (confirm(BeforeSaveConfirmationMessage) == true) {
                SubmitFormSave();
            }
            break;
        case "Clear":
            // code to be executed if expression matches value2
            if (confirm(ClearConfirmationMessage) == true) {
                FormsButtonOptions('Clear');
            }
            break;
        case "Close":
            // code to be executed if expression matches value2
            if (confirm(CloseConfirmationMessage) == true) {
                FormsButtonOptions('Close');
            }
            break;

        default:
            FormsButtonOptions('Close');
        // code to be executed if none of the cases match the expression
    }


}