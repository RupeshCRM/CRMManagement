$("Document").ready(function () {


    new DataTable('#TableUSERWORKFLOWRIGHTS', {
        order: [[0, 'Asc']],
        paging: false,  // Disable pagination
        searching: true,  // Enable global search
        initComplete: function () {
            this.api().columns().every(function () {
                this.column().search('', true, false);
            });
        }
    });
});


function SubmitFormSave() {
    var dataDetail = [];
    var intSno = 1;
    var Header = {
        CmpyCode: $("#CmpyCode").val(),
        Code: $("#Code").val(),
        LeadName: $("#LeadName").val(),
        TaskName: $("#TaskName").val(),
        TaskDescription: $("#TaskDescription").val(),
        TaskAssign: $("#TaskAssign").val(),
        TaskAssignDate: $("#TaskAssignDate").val(),
        TaskCompletebyDate: $("#TaskCompletebyDate").val(),
        TaskStage: $("#TaskStage").val(),
    };

    var userRequest = {
        SectionId: $("#gblSectionId").val(),
        companyCode: $("#gblcompanyCode").val(),
        FYear: $("#gblFYear").val(),
        UserName: $("#gblUserName").val()
    };



    // Combine Order Header and Detail data
    var CRMTaskUpdateFormMasterVM = {
        CRMTaskUpdateFormMaster: Header,
        userRequest: userRequest,

    };

    var oprType = $("#gbloprTypeId").val();

    if (oprType == "Create") {
        // AJAX request to send data to the controller
        $.ajax({
            url: '/CRMTaskUpdateFormMaster/Create',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(CRMTaskUpdateFormMasterVM),
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
            url: '/CRMTaskUpdateFormMaster/Edit',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(CRMTaskUpdateFormMasterVM),
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
            url: '/ContactMaste/Delete',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(CRMTaskUpdateFormMasterVM),
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
