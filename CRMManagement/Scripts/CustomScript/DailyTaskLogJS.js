$("Document").ready(function () {

    /*  alert('santosh Test entry');*/

});

function SubmitFormSave() {
    var Header = {
        CmpyCode: $("#gblcompanyCode").val(),
        Code: $("#Code").val(),
        Date: $("#Date").val(),
        TopicCode: $("#TopicCode").val(),
        InternsId: $("#InternsId").val(),
        TaskDescription: $("#TaskDescription").val(),
        TaskStatus: $("#TaskStatus").val(),
        Remark: $("#Remark").val(),
        Rating: $("#Rating").val(),
        Programs: $("#Programs").val()

    };

    var userRequest = {
        SectionId: $("#gblSectionId").val(),
        companyCode: $("#gblcompanyCode").val(),
        FYear: $("#gblFYear").val(),
        UserName: $("#gblUserName").val()
    };

    // Combine Order Header and Detail data
    var DailyTaskLogVM = {
        ezDailyTaskLog: Header,
        userRequest: userRequest
    };

    var oprType = $("#gbloprTypeId").val();

    if (oprType == "Create") {
        // AJAX request to send data to the controller
        $.ajax({
            url: '/DailyTaskLog/Create',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(DailyTaskLogVM),
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
            url: '/DailyTaskLog/Edit',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(DailyTaskLogVM),
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
            url: '/DailyTaskLog/Delete',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(DailyTaskLogVM),
            async: false,
            success: function (response) {
                //callIndexView(response);
                alert(DeleteSuccessMessage);
                window.location.href = response.redirectUrl;
            },
            error: function (error) {
                // Handle error if needed
                alert(SaveErrorMessage);
            }
        });
    }

}
