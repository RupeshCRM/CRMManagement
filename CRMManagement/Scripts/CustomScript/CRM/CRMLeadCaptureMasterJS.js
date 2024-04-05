
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
        CmpyCode: $("#gblcompanyCode").val(),
        Code: $("#CRMLeadCaptureMaster_Code").val(),
        LeadID: $("#CRMLeadCaptureMaster_LeadID").val(),
        LeadName: $("#CRMLeadCaptureMaster_LeadName").val(),
        Dates: $("#CRMLeadCaptureMaster_Dates").val(),
        CreatedBy: $("#CRMLeadCaptureMaster_CreatedBy").val(),
        ContactType: $("input[name='CRMLeadCaptureMaster.ContactType']:checked").val(),
        Salutation: $("#CRMLeadCaptureMaster_Salutation").val(),
        FirstName: $("#CRMLeadCaptureMaster_FirstName").val(),
        LastName: $("#CRMLeadCaptureMaster_LastName").val(),
        MiddleName: $("#CRMLeadCaptureMaster_MiddleName").val(),
        MarriedStatus: $("input[name='CRMLeadCaptureMaster.MarriedStatus']:checked").val(),
        ProfessionCode: $("#CRMLeadCaptureMaster_ProfessionCode").val(),
        DesignationType: $("#CRMLeadCaptureMaster_DesignationType").val(),
        TeliPhone: $("#CRMLeadCaptureMaster_TeliPhone").val(),
        CellPhone: $("#CRMLeadCaptureMaster_CellPhone").val(),
        EmailID1: $("#CRMLeadCaptureMaster_EmailID1").val(),
        EmailID2: $("#CRMLeadCaptureMaster_EmailID2").val(),
        Income: parseFloat($("#CRMLeadCaptureMaster_Income").val()),
        IncomeType: $("input[name='CRMLeadCaptureMaster.IncomeType']:checked").val(),
        Hobbies: $("#CRMLeadCaptureMaster_Hobbies").val(),
        EmploymentType: $("#CRMLeadCaptureMaster_EmploymentType").val(),
        CompanyName: $("#CRMLeadCaptureMaster_CompanyName").val(),
        MainPhoneNumber: $("#CRMLeadCaptureMaster_MainPhoneNumber").val(),
        MainFaxNumber: $("#CRMLeadCaptureMaster_MainFaxNumber").val(),
        MainEmail: $("#CRMLeadCaptureMaster_MainEmail").val(),
        URL: $("#CRMLeadCaptureMaster_URL").val(),
        Industry: $("#CRMLeadCaptureMaster_Industry").val(),
        YearlyTurnover: $("#CRMLeadCaptureMaster_YearlyTurnover").val(),
        NumberOfEmployees: $("#CRMLeadCaptureMaster_NumberOfEmployees").val(),
        AccountType: $("input[name='CRMLeadCaptureMaster.AccountType']:checked").val(),
        LeadGenrationType: $("input[name='CRMLeadCaptureMaster.LeadGenrationType']:checked").val(),
        LeadSourceOutbound: $("#CRMLeadCaptureMaster_LeadSourceOutbound").val(),
        LeadSourceInbound: $("#CRMLeadCaptureMaster_LeadSourceInbound").val(),
        LeadSubSource: $("#CRMLeadCaptureMaster_LeadSubSource").val(),
        PSDescription: $("#CRMLeadCaptureMaster_PSDescription").val(),
        ApproximateDealValue: parseFloat($("#CRMLeadCaptureMaster_ApproximateDealValue").val()),
        ApproximateDealClouserDate: $("#CRMLeadCaptureMaster_ApproximateDealClouserDate").val(),
        SubStage: $("#CRMLeadCaptureMaster_SubStage").val(),
        PipelineName: $("#CRMLeadCaptureMaster_PipelineName").val(),
        DealSubStage: $("#CRMLeadCaptureMaster_DealSubStage").val(),

    };

    var userRequest = {
        SectionId: $("#gblSectionId").val(),
        companyCode: $("#gblcompanyCode").val(),
        FYear: $("#gblFYear").val(),
        UserName: $("#gblUserName").val()
    };



    // Combine Order Header and Detail data
    var CRMLeadCaptureMasterVM = {
        CRMLeadCaptureMaster: Header,
        userRequest: userRequest,

    };

    var oprType = $("#gbloprTypeId").val();

    if (oprType == "Create") {
        // AJAX request to send data to the controller
        $.ajax({
            url: '/CRMLeadCaptureMaster/Create',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(CRMLeadCaptureMasterVM),
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
            url: '/CRMLeadCaptureMaster/Edit',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(CRMLeadCaptureMasterVM),
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
            url: '/CRMLeadCaptureMaster/Delete',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(CRMLeadCaptureMasterVM),
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
