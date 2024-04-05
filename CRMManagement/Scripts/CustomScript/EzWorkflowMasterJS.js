$("Document").ready(function () {

    /*  alert('santosh Test entry');*/

});

function SubmitFormSave() {
    var Header = {
        WorkflowCode:$("#WorkflowCode").val(),
        ModuleCode:$("#ModuleCode").val(),
        Description:$("#Description").val(),
        disTableName: $("#disTableName").val(),
        ControllerName: $("#ControllerName").val(),
        isVisible : $("#isVisible").prop('checked') ? 1 : 0
    };

    var userRequest = {
        SectionId: $("#gblSectionId").val(),
        companyCode: $("#gblcompanyCode").val(),
        FYear: $("#gblFYear").val(),
        UserName: $("#gblUserName").val()
    };

    // Combine Order Header and Detail data
    var ezWorkflowMasterVM = {
        ezWorkflowMaster:Header,
        userRequest:userRequest
    };

    var oprType = $("#gbloprTypeId").val();

    if (oprType == "Create") {
        // AJAX request to send data to the controller
        $.ajax({
            url: '/EzWorkflowMaster/Create',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(ezWorkflowMasterVM),
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
            url: '/EzWorkflowMaster/Edit',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(ezWorkflowMasterVM),
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
            url: '/EzWorkflowMaster/Delete',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(ezWorkflowMasterVM),
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
