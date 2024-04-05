
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
    var amenities = $("input[name='SelectedValues']:checked").map(function () {
        return $(this).val();
    }).get();
    var postovariousportals = $("input[name='SelectedValues']:checked").map(function () {
        return $(this).val();
    }).get();
    var Header = {
        CmpyCode: $("#gblcompanyCode").val(),
        Code: $("#CRMListingPageInfoMaster_Code").val(),
        PropertyName: $("#CRMListingPageInfoMaster_PropertyName").val(),
        ProjectName: $("#CRMListingPageInfoMaster_ProjectName").val(),
        PropertyUse: $("input[name='CRMListingPageInfoMaster.PropertyUse']:checked").val(),
        PropertyType: $("input[name='CRMListingPageInfoMaster.PropertyType']:checked").val(),
        BedsBath: $("#CRMListingPageInfoMaster_BedsBath").val(),
        PropertySize: $("#CRMListingPageInfoMaster_PropertySize").val(),
        PropertyLocation: $("#CRMListingPageInfoMaster_PropertyLocation").val(),
        Street: $("#CRMListingPageInfoMaster_Street").val(),
        City: $("#CRMListingPageInfoMaster_City").val(),
        State: $("#CRMListingPageInfoMaster_State").val(),
        Country: $("#CRMListingPageInfoMaster_Country").val(),
        Amenities: amenities,
        Notes: $("#CRMListingPageInfoMaster_Notes").val(),
        CustomAttributes: $("#CRMListingPageInfoMaster_CustomAttributes").val(),
        ListingType: $("input[name='CRMListingPageInfoMaster.ListingType']:checked").val(),
        RentalPrice: parseFloat($("#CRMListingPageInfoMaster_RentalPrice").val()),
        RentalPriceType: $("input[name='CRMListingPageInfoMaster.RentalPriceType']:checked").val(),
        SalePrice: parseFloat($("#CRMListingPageInfoMaster_SalePrice").val()),
        PostToPortal: $("#CRMListingPageInfoMaster_PostToPortal").val(),
        PostToVariousPortals: postovariousportals,
        SaleRepContactID: $("#CRMListingPageInfoMaster_SaleRepContactID").val(),
        SalesRepEmail: $("#CRMListingPageInfoMaster_SalesRepEmail").val(),
        URL: $("#CRMListingPageInfoMaster_URL").val(),
    };

    var userRequest = {
        SectionId: $("#gblSectionId").val(),
        companyCode: $("#gblcompanyCode").val(),
        FYear: $("#gblFYear").val(),
        UserName: $("#gblUserName").val()
    };



    // Combine Order Header and Detail data
    var CRMListingPageInfoMasterVM = {
        CRMListingPageInfoMaster: Header,
        userRequest: userRequest,

    };

    var oprType = $("#gbloprTypeId").val();

    if (oprType == "Create") {
        // AJAX request to send data to the controller
        $.ajax({
            url: '/CRMListingPageInfoMaster/Create',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(CRMListingPageInfoMasterVM),
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
            url: '/CRMListingPageInfoMaster/Edit',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(CRMListingPageInfoMasterVM),
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
            url: '/CRMListingPageInfoMaster/Delete',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(CRMListingPageInfoMasterVM),
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
