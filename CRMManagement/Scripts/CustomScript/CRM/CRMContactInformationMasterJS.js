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
        ContactPerson: $("#ContactPerson").val(),
        Designation: $("#Designation").val(),
        MaritalStatus: $("#MaritalStatus").val(),
        TeliPhone: $("#TeliPhone").val(),
        FaxNumber: $("#FaxNumber").val(),
        EmailID: $("#EmailID").val(),
        Notes: $("#Notes").val(),
        Reminders: $("#Reminders").val(),
    };

    var userRequest = {
        SectionId: $("#gblSectionId").val(),
        companyCode: $("#gblcompanyCode").val(),
        FYear: $("#gblFYear").val(),
        UserName: $("#gblUserName").val()
    };



    // Combine Order Header and Detail data
    var CRMContactInformationMasterVM = {
        CRMContactInformationMaster: Header,
        userRequest: userRequest,

    };

    var oprType = $("#gbloprTypeId").val();

    if (oprType == "Create") {
        // AJAX request to send data to the controller
        $.ajax({
            url: '/CRMContactInformationMaster/Create',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(CRMContactInformationMasterVM),
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
            url: '/CRMContactInformationMaster/Edit',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(CRMContactInformationMasterVM),
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
            data: JSON.stringify(CRMContactInformationMasterVM),
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
