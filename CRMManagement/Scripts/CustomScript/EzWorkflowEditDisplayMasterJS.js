$("Document").ready(function () {

    /*  alert('santosh Test entry');*/

});

function SubmitFormSave() {

    var isVisibleChk = $("#isVisible").prop('checked') ? 1 : 0;
    var isPrimaryKeyChk = $("#isPrimaryKey").prop('checked') ? 1 : 0;

    var Header = {
        SectionEditCode: $("#SectionEditCode").val(),
        WorkflowCode: $("#WorkflowCode").val(),
        TableName: $("#TableName").val(),
        ColumnValue: $("#ColumnValue").val(),
        ColumnCaption: $("#ColumnCaption").val(),
        isVisible: isVisibleChk,//$("#isVisible").val(),
        isPrimaryKey: isPrimaryKeyChk,
        Sno: $("#Sno").val()
    };

    var userRequest = {
        SectionId: $("#gblSectionId").val(),
        companyCode: $("#gblcompanyCode").val(),
        FYear: $("#gblFYear").val(),
        UserName: $("#gblUserName").val()
    };

    // Combine Order Header and Detail data
    var ezWorkflowEditDisplayMasterVM = {
        ezWorkflowEditDisplayMaster: Header,
        userRequest: userRequest
    };

    var oprType = $("#gbloprTypeId").val();

    if (oprType == "Create") {
        // AJAX request to send data to the controller
        $.ajax({
            url: '/EzWorkflowEditDisplayMaster/Create',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(ezWorkflowEditDisplayMasterVM),
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
    else if (oprType == "Edit") {
        // AJAX request to send data to the controller
        $.ajax({
            url: '/EzWorkflowEditDisplayMaster/Edit',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(ezWorkflowEditDisplayMasterVM),
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
    else if (oprType == "Delete") {
        // AJAX request to send data to the controller
        $.ajax({
            url: '/EzWorkflowEditDisplayMaster/Delete',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(ezWorkflowEditDisplayMasterVM),
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

}
