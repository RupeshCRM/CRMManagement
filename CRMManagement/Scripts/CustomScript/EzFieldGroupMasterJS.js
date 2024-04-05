$("Document").ready(function () {

    /*  alert('santosh Test entry');*/

});

function SubmitFormSave() {
    var Header = {
        Code: $("#Code").val(),
        Description: $("#Description").val()
        
    };

    var userRequest = {
        SectionId: $("#gblSectionId").val(),
        FYear: $("#gblFYear").val(),
        UserName: $("#gblUserName").val()
    };

    // Combine Order Header and Detail data
    var ezFieldGroupMasterVM = {
        ezFieldGroupMaster: Header,
        userRequest: userRequest
    };

    var oprType = $("#gbloprTypeId").val();

    if (oprType == "Create") {
        // AJAX request to send data to the controller
        $.ajax({
            url: '/EzFieldGroupMaster/Create',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(ezFieldGroupMasterVM),
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
            url: '/EzFieldGroupMaster/Edit',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(ezFieldGroupMasterVM),
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
            url: '/EzFieldGroupMaster/Delete',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(ezFieldGroupMasterVM),
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
