$("Document").ready(function () {


    //new DataTable('#TableUSERWORKFLOWRIGHTS', {
    //    order: [[0, 'Asc']],
    //    paging: false,  // Disable pagination
    //    searching: true,  // Enable global search
    //    initComplete: function () {
    //        this.api().columns().every(function () {
    //            this.column().search('', true, false);
    //        });
    //    }
    //});

/*     Image preview on file input change*/
    $('#fileInput').change(function () {
        readURL(this);
    });


});



function SubmitFormSave() {
    var dataDetail = [];
    var fileInput = document.getElementById('fileInput');
    var file = fileInput.files[0];
    var intSno = 1;
    var Header = {
        CmpyCode: $("#gblcompanyCode").val(),
        Code: $("#CRMUserMaster_Code").val(),
        EmployeeID: $("#CRMUserMaster_EmployeeID").val(),
        Salutation: $("#CRMUserMaster_Salutation").val(),
        FirstName: $("#CRMUserMaster_FirstName").val(),
        LastName: $("#CRMUserMaster_LastName").val(),
        MiddleName: $("#CRMUserMaster_MiddleName").val(),
        CategoryID: $("#CRMUserMaster_CategoryID").val(),
        ReportingTo: $("#CRMUserMaster_ReportingTo").val(),
        UserName: $("#CRMUserMaster_UserName").val(),
        Password: $("#CRMUserMaster_Password").val(),
        Mobile: $("#CRMUserMaster_Mobile").val(),
        EmailID: $("#CRMUserMaster_EmailID").val(),
        Street: $("#CRMUserMaster_Street").val(),
        City: $("#CRMUserMaster_City").val(),
        State: $("#CRMUserMaster_State").val(),
        Country: $("#CRMUserMaster_Country").val(),
        Photo: $("#CRMUserMaster_Photo").val(),
        TargetType: $("input[name='CRMUserMaster.TargetType']:checked").val(),
        /*TargetType: $("#CRMUserMaster_TargetType").val(),*/
        TargetValue: parseFloat($("#CRMUserMaster_TargetValue").val()),
        TargetCalculatedType: $("input[name='CRMUserMaster.TargetCalculatedType']:checked").val(),
        TargetCalculated: parseFloat($("#CRMUserMaster_TargetCalculated").val()),
        /*CommissionType: $("#CRMUserMaster_CommissionType").val(),*/
        CommissionType:$("input[name='CRMUserMaster.CommissionType']:checked").val(),
        CommissionTypeValue: parseFloat($("#CRMUserMaster_CommissionTypeValue").val()),
        StartAccrualFromDate: $("#CRMUserMaster_StartAccrualFromDate").val(),
        AccruedAmountToDate: parseFloat($("#CRMUserMaster_AccruedAmountToDate").val()),
        PaidToDate: parseFloat($("#CRMUserMaster_PaidToDate").val()),
        Balance: parseFloat($("#CRMUserMaster_Balance").val()),
        Notes: $("#CRMUserMaster_Notes").val()
       
    };

    var userRequest = {
        SectionId: $("#gblSectionId").val(),
        companyCode: $("#gblcompanyCode").val(),
        FYear: $("#gblFYear").val(),
        UserName: $("#gblUserName").val()
    };



    // Combine Order Header and Detail data
    var CRMUserMasterVM = {
        CRMUserMaster: Header,
        userRequest: userRequest,

    };

    var oprType = $("#gbloprTypeId").val();

    if (oprType == "Create") {
        // AJAX request to send data to the controller
        $.ajax({
            url: '/CRMUserMaster/Create',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(CRMUserMasterVM),
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
            url: '/CRMUserMaster/Edit',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(CRMUserMasterVM),
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
            url: '/CRMUserMaster/Delete',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(CRMUserMasterVM),
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
function uploadFile() {
    var fileInput = document.getElementById('fileInput');
    var file = fileInput.files[0];
    var CmpyCode = $("#gblcompanyCode").val();
    var Code = $("#CRMUserMaster_Code").val();
        
    if (file) {
        var formData = new FormData();
        formData.append('file', file);
        formData.append('CmpyCode', CmpyCode);
        formData.append('Code', Code);
        $.ajax({
            url: '/CRMUserMaster/UploadFile1', // Update the URL according to your controller action
            type: 'POST',
            data:  formData,
            processData: false,
            contentType: false,
            success: function (response) {
                if (response.success) {
                    // Handle success message
                   alert(response.message);
                } else {
                    // Handle error message
                    alert(response.message);
                }
            },
            error: function (error) {
                // Handle error response from the server
               alert("Error uploading file:", error.statusText);
            }
        });
    } else {
        alert("No file selected");
    }
}



//// Submit the form using AJAX
//function uploadForm(e) {
//  /*  e.preventDefault();*/

//    var formData = new FormData(this);

//    $.ajax({
//        url: '/CRMUserMaster/UploadFile',
//        type: 'POST',
//        data: formData,
//        processData: false,
//        contentType: false,
//        success: function (data) {
//            if (data.error) {
//                alert(data.error);
//            } else {
//                // Clear file input and hide image preview after successful upload
//                $('#fileInput').val('');
//                $('#imgPreview').hide();

//                // Reload the file list or update the view as needed
//                // For simplicity, you can reload the entire page
//                location.reload();
//            }
//        }
//    });
//}
