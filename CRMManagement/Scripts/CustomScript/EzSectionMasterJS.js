$("Document").ready(function () {

    /*  alert('santosh Test entry');*/
    

});

function SubmitFormSave() {

    var isApplicableForTable = 0;// = $("#isApplicableForTable").val()||0;
    
    var checkbox = document.getElementById("isApplicableForTable");
    if (checkbox.checked) {
        isApplicableForTable = 1;
    } else {
        console.log("Checkbox is not checked");
    }
   
    var Header = {
        SectionCode: $("#SectionCode").val(),
        WorkflowCode: $("#WorkflowCode").val(),
        Description: $("#Description").val(),
        isApplicableForTable: isApplicableForTable
        
    };

    var userRequest = {
        SectionId: $("#gblSectionId").val(),
        companyCode: $("#gblcompanyCode").val(),
        FYear: $("#gblFYear").val(),
        UserName: $("#gblUserName").val()
    };

    // Combine Order Header and Detail data
    var EzSectionMasterVM = {
        ezSectionMaster: Header,
        userRequest: userRequest
    };

    var oprType = $("#gbloprTypeId").val();

    if (oprType == "Create") {
        // AJAX request to send data to the controller
        $.ajax({
            url: '/EzSectionMaster/Create',
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
    else if (oprType == "Edit") {
        // AJAX request to send data to the controller
        $.ajax({
            url: '/EzSectionMaster/Edit',
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
    else if (oprType == "Delete") {
        // AJAX request to send data to the controller
        $.ajax({
            url: '/EzSectionMaster/Delete',
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

}
