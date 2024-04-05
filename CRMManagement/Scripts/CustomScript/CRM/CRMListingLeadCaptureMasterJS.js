
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
        Code: $("#CRMListingLeadCaptureMaster_Code").val(), 
        LeadStatus: $("input[name='CRMListingLeadCaptureMaster.LeadStatus']:checked").val(), 
        LeadID: $("#CRMListingLeadCaptureMaster_LeadID").val(), 
        LeadName: $("#CRMListingLeadCaptureMaster_LeadName").val(),
        Dates: $("#CRMListingLeadCaptureMaster_Dates").val(),
        CreatedBy: $("#CRMListingLeadCaptureMaster_CreatedBy").val(),
        ContactType: $("input[name='CRMListingLeadCaptureMaster.ContactType']:checked").val(), 
        Salutation: $("#CRMListingLeadCaptureMaster_Salutation").val(),
        FirstName: $("#CRMListingLeadCaptureMaster_FirstName").val(),
        LastName: $("#CRMListingLeadCaptureMaster_LastName").val(),
        MiddleName: $("#CRMListingLeadCaptureMaster_MiddleName").val(),
        MarriedStatus: $("input[name='CRMListingLeadCaptureMaster.MarriedStatus']:checked").val(),
        ProfessionCode: $("#CRMListingLeadCaptureMaster_ProfessionCode").val(),
        DesignationType: $("#CRMListingLeadCaptureMaster_DesignationType").val(),
        TelePhone: $("#CRMListingLeadCaptureMaster_TelePhone").val(),
        CellPhone: $("#CRMListingLeadCaptureMaster_CellPhone").val(),
        EmailID1: $("#CRMListingLeadCaptureMaster_EmailID1").val(),
        EmailID2: $("#CRMListingLeadCaptureMaster_EmailID2").val(),
        Income: parseFloat($("#CRMListingLeadCaptureMaster_Income").val()),
        IncomeType: $("input[name='CRMListingLeadCaptureMaster.IncomeType']:checked").val(),
        Hobbies: $("#CRMListingLeadCaptureMaster_Hobbies").val(),
        EmploymentType: $("#CRMListingLeadCaptureMaster_EmploymentType").val(),
        CompanyName: $("#CRMListingLeadCaptureMaster_CompanyName").val(),
        MainPhoneNumber: $("#CRMListingLeadCaptureMaster_MainPhoneNumber").val(),
        MainFaxNumber: $("#CRMListingLeadCaptureMaster_MainFaxNumber").val(),
        MainEmailID: $("#CRMListingLeadCaptureMaster_MainEmailID").val(),
        URL: $("#CRMListingLeadCaptureMaster_URL").val(),
        Industry: $("#CRMListingLeadCaptureMaster_Industry").val(),
        YearlyTurnover: parseFloat($("#CRMListingLeadCaptureMaster_YearlyTurnover").val()),
        NumberOfEmployees: $("#CRMListingLeadCaptureMaster_NumberOfEmployees").val(),
        PSDescription: $("#CRMListingLeadCaptureMaster_PSDescription").val(),
        AccountType: $("input[name='CRMListingLeadCaptureMaster.AccountType']:checked").val(),
        LeadGeneration: $("input[name='CRMListingLeadCaptureMaster.LeadGeneration']:checked").val(),
        LeadSourceOutBound: $("#CRMListingLeadCaptureMaster_LeadSourceOutBound").val(),
        LeadSourceInBound: $("#CRMListingLeadCaptureMaster_LeadSourceInBound").val(),
        LeadSubSource: $("#CRMListingLeadCaptureMaster_LeadSubSource").val(),
        PropertyName: $("#CRMListingLeadCaptureMaster_PropertyName").val(),
        ProjectName: $("#CRMListingLeadCaptureMaster_ProjectName").val(),
        PropertyUse: $("input[name='CRMListingLeadCaptureMaster.PropertyUse']:checked").val(),
        PropertyType: $("input[name='CRMListingLeadCaptureMaster.PropertyType']:checked").val(),
        BedsBath: $("#CRMListingLeadCaptureMaster_BedsBath").val(),
            PropertySize: $("#CRMListingLeadCaptureMaster_PropertySize").val(),
            PropertyLocation: $("#CRMListingLeadCaptureMaster_PropertyLocation").val(),
            Street: $("#CRMListingLeadCaptureMaster_Street").val(),
            City: $("#CRMListingLeadCaptureMaster_City").val(),
            State: $("#CRMListingLeadCaptureMaster_State").val(),
            Country: $("#CRMListingLeadCaptureMaster_Country").val(),
            Amenities: $("#CRMListingLeadCaptureMaster_Amenities").val(),
            Notes: $("#CRMListingLeadCaptureMaster_Notes").val(),
            CustomAttribute: $("#CRMListingLeadCaptureMaster_CustomAttribute").val(),
            ListingType: $("input[name='CRMListingLeadCaptureMaster.ListingType']:checked").val(),
            RentalPrice: $("#CRMListingLeadCaptureMaster_RentalPrice").val(),
            RentalPriceType: $("input[name='CRMListingLeadCaptureMaster.RentalPriceType']:checked").val(),
            SalePrice: $("#CRMListingLeadCaptureMaster_SalePrice").val(),
            ListingConfirmed: $("#CRMListingLeadCaptureMaster_ListingConfirmed").val(),
            DateConfirmed: $("#CRMListingLeadCaptureMaster_DateConfirmed").val()

    };

    var userRequest = {
        SectionId: $("#gblSectionId").val(),
        companyCode: $("#gblcompanyCode").val(),
        FYear: $("#gblFYear").val(),
        UserName: $("#gblUserName").val()
    };



    // Combine Order Header and Detail data
    var CRMListingLeadCaptureMasterVM = {
        CRMListingLeadCaptureMaster: Header,
        userRequest: userRequest,

    };

    var oprType = $("#gbloprTypeId").val();

    if (oprType == "Create") {
        // AJAX request to send data to the controller
        $.ajax({
            url: '/CRMListingLeadCaptureMaster/Create',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(CRMListingLeadCaptureMasterVM),
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
            url: '/CRMListingLeadCaptureMaster/Edit',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(CRMListingLeadCaptureMasterVM),
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
            url: '/CRMListingLeadCaptureMaster/Delete',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(CRMListingLeadCaptureMasterVM),
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
