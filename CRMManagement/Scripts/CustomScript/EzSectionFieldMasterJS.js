$("Document").ready(function () {

    /*  alert('santosh Test entry');*/

});

function SubmitFormSave() {

    var isRequired = 0;
    var isHidden = 0;
    var isApplicableForTable = 0;// = $("#isApplicableForTable").val()||0;

    var checkbox = document.getElementById("isRequired");
    if (checkbox.checked) {
        isRequired = 1;
    } else {
        console.log("Checkbox is not checked");
    }

    var checkbox = document.getElementById("isHidden");
    if (checkbox.checked) {
        isHidden = 1;
    } else {
        console.log("Checkbox is not checked");
    }

    var Header = {
        SectionFieldCode: $("#SectionFieldCode").val(),
        SectionCode: $("#SectionCode").val(),
        Sno: $("#Sno").val(),
        DBFieldName: $("#DBFieldName").val(),
        DBFieldDataType: $("#DBFieldDataType").val(),
        MVCControlType: $("#MVCControlType").val(),
        LableName: $("#LableName").val(),
        TableName: $("#TableName").val(),
        dropdownValueColumn: $("#dropdownValueColumn").val(),
        dropdownTextColumn: $("#dropdownTextColumn").val(),
        isRequired: isRequired,
        isHidden: isHidden
    };

    var userRequest = {
        SectionId: $("#gblSectionId").val(),
        companyCode: $("#gblcompanyCode").val(),
        FYear: $("#gblFYear").val(),
        UserName: $("#gblUserName").val()
    };

    // Combine Order Header and Detail data
    var ezSectionFieldMasterVM = {
        ezSectionFieldMaster: Header,
        userRequest: userRequest
    };

    var oprType = $("#gbloprTypeId").val();

    if (oprType == "Create") {
        // AJAX request to send data to the controller
        $.ajax({
            url: '/EzSectionFieldMaster/Create',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(ezSectionFieldMasterVM),
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
            url: '/EzSectionFieldMaster/Edit',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(ezSectionFieldMasterVM),
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
            url: '/EzSectionFieldMaster/Delete',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(ezSectionFieldMasterVM),
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
