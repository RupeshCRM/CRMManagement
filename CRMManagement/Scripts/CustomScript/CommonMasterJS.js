$("Document").ready(function () {

    /*  alert('santosh Test entry');*/

});

function SubmitFormSave() {
    var Header = {
        CmpyCode: $("#gblcompanyCode").val(),
        Code: $("#Code").val(),
        Description: $("#Description").val(),
        UniCodeName: $("#UniCodeName").val(),
        SubCode: $("#SubCode").val()  
    };

    var userRequest = {
        CompanyCode: $("#gblcompanyCode").val(),
        SectionId: $("#gblSectionId").val(),
        FYear: $("#gblFYear").val(),
        UserName: $("#gblUserName").val()
    };

    // Combine Order Header and Detail data
    var ezCommonMasterVM = {
        commonMaster: Header,
        userRequest: userRequest
    };

    var oprType = $("#gbloprTypeId").val();

    if (oprType == "Create") {
        // AJAX request to send data to the controller
        $.ajax({
            url: '/EzCommonMaster/Create',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(ezCommonMasterVM),
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
            url: '/EzCommonMaster/Edit',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(ezCommonMasterVM),
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
            url: '/EzCommonMaster/Delete',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(ezCommonMasterVM),
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
