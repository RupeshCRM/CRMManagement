
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
        Code: $("#CRMContactDatabaseMaster_Code").val(),
        ContactID: $("#CRMContactDatabaseMaster_ContactID").val(),
        ContactType: $("input[name='CRMContactDatabaseMaster.ContactType']:checked").val(),
        Salutation: $("#CRMContactDatabaseMaster_Salutation").val(),
        FirstName: $("#CRMContactDatabaseMaster_FirstName").val(),
        LastName: $("#CRMContactDatabaseMaster_LastName").val(),
        MiddleName: $("#CRMContactDatabaseMaster_MiddleName").val(),
        MarriedStatus: $("input[name='CRMContactDatabaseMaster.MarriedStatus']:checked").val(),
        ProfessionCode: $("#CRMContactDatabaseMaster_ProfessionCode").val(),
        Designation: $("#CRMContactDatabaseMaster_Designation").val(),
        TeliPhone: $("#CRMContactDatabaseMaster_TeliPhone").val(),
        CellPhone: $("#CRMContactDatabaseMaster_CellPhone").val(),
        EmailID1: $("#CRMContactDatabaseMaster_EmailID1").val(),
        EmailID2: $("#CRMContactDatabaseMaster_EmailID2").val(),
        Income: parseFloat($("#CRMContactDatabaseMaster_Income").val()),
        IncomeType: $("input[name='CRMContactDatabaseMaster.IncomeType']:checked").val(),
        Hobbies: $("#CRMContactDatabaseMaster_Hobbies").val(),
        EmploymentType: $("#CRMContactDatabaseMaster_EmploymentType").val(),
        CompanyName: $("#CRMContactDatabaseMaster_CompanyName").val(),
        MainPhoneNumber: $("#CRMContactDatabaseMaster_MainPhoneNumber").val(),
        MainFaxNumber: $("#CRMContactDatabaseMaster_MainFaxNumber").val(),
        MainEmail: $("#CRMContactDatabaseMaster_MainEmail").val(),
        URL: $("#CRMContactDatabaseMaster_URL").val(),
        Industry: $("#CRMContactDatabaseMaster_Industry").val(),
        YearlyTurnover: $("#CRMContactDatabaseMaster_YearlyTurnover").val(),
        NumberOfEmployees: $("#CRMContactDatabaseMaster_NumberOfEmployees").val(),
        ContactSubType: $("input[name='CRMContactDatabaseMaster.ContactSubType']:checked").val(),
        AccountType: $("#CRMContactDatabaseMaster_AccountType").val(),
        PropertyName: $("#CRMContactDatabaseMaster_PropertyName").val(),
        ProjectName: $("#CRMContactDatabaseMaster_ProjectName").val(),
        PropertyUse: $("input[name='CRMContactDatabaseMaster.PropertyUse']:checked").val(),
        PropertyType: $("input[name='CRMContactDatabaseMaster.PropertyType']:checked").val(),
        BedsBath: $("#CRMContactDatabaseMaster_BedsBath").val(),
        PropertySize: $("#CRMContactDatabaseMaster_PropertySize").val(),
        PropertyLocation: $("#CRMContactDatabaseMaster_PropertyLocation").val(),
        street: $("#CRMContactDatabaseMaster_street").val(),
        City: $("#CRMContactDatabaseMaster_City").val(),
        State: $("#CRMContactDatabaseMaster_State").val(),
        Country: $("#CRMContactDatabaseMaster_Country").val(),
        Amenities: $("#CRMContactDatabaseMaster_Amenities").val(),
        PSDescription: $("#CRMContactDatabaseMaster_PSDescription").val(),
    };

    var userRequest = {
        SectionId: $("#gblSectionId").val(),
        companyCode: $("#gblcompanyCode").val(),
        FYear: $("#gblFYear").val(),
        UserName: $("#gblUserName").val()
    };



    // Combine Order Header and Detail data
    var CRMContactDatabaseMasterVM = {
        CRMContactDatabaseMaster: Header,
        userRequest: userRequest,

    };

    var oprType = $("#gbloprTypeId").val();

    if (oprType == "Create") {
        // AJAX request to send data to the controller
        $.ajax({
            url: '/CRMContactDatabaseMaster/Create',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(CRMContactDatabaseMasterVM),
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
            url: '/CRMContactDatabaseMaster/Edit',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(CRMContactDatabaseMasterVM),
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
            url: '/CRMContactDatabaseMaster/Delete',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(CRMContactDatabaseMasterVM),
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
