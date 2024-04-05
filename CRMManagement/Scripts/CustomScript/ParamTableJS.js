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
        Name: $("#Name").val(),
        Nos: $("#Nos").val(),
        Suffix: $("#Suffix").val(),
        FormatNo: $("#FormatNo").val(),
        RevisionNo: $("#RevisionNo").val(),
        DeptCode: $("#DeptCode").val(),
        Description: $("#Description").val(),
        TotalDigits: $("#TotalDigits").val(),
        FormatDate: $("#FormatDate").val(),
        RevisionDate: $("#RevisionDate").val(),
        DbAcc: $("#DbAcc").val(),
        CrAcc: $("#CrAcc").val(),
        DbAcc2: $("#DbAcc2").val(),
        CrAcc2: $("#CrAcc2").val(),
        DbAcc3: $("#DbAcc3").val(),
        CrAcc3: $("#CrAcc3").val(),
        DbAcc4: $("#DbAcc4").val(),
        CrAcc4: $("#CrAcc4").val(),
        Auto: $("#Auto").val(),
        Voucher: $("#Voucher").val(),
        UseProject: $("#UseProject").val(),
        UseDepartment: $("#UseDepartment").val(),
        UseYears: $("#UseYears").val(),
    };

    var userRequest = {
        SectionId: $("#gblSectionId").val(),
        companyCode: $("#gblcompanyCode").val(),
        FYear: $("#gblFYear").val(),
        UserName: $("#gblUserName").val()
    };

   

    // Combine Order Header and Detail data
    var ParamTableVM = {
        ParamTable: Header,
        userRequest: userRequest,
    
    };

    var oprType = $("#gbloprTypeId").val();

    if (oprType == "Create") {
        // AJAX request to send data to the controller
        $.ajax({
            url: '/ParamTable/Create',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(ParamTableVM),
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
            url: '/ParamTable/Edit',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(ParamTableVM),
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
            url: '/ParamTable/Delete',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(ParamTableVM),
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
