$("Document").ready(function () {


});


function SubmitFormSave() {
    var dataDetail = [];
    var intSno = 1;
    var Header = {
        CmpyCode: $("#CmpyCode").val(),
        Code: $("#Code").val(),
        Sno: $("#Sno").val(),
        LeadID: $("#LeadID").val(),
        ActionNotes: $("#ActionNotes").val(),
        SubStageID: $("#SubStageID").val(),
        DealDate: $("#DealDate").val(),
        NextActionID: $("#NextActionID").val(),
        NextActionDate: $("#NextActionDate").val(),
        AssignTo: $("#AssignTo").val()
    };

    var userRequest = {
        SectionId: $("#gblSectionId").val(),
        companyCode: $("#gblcompanyCode").val(),
        FYear: $("#gblFYear").val(),
        UserName: $("#gblUserName").val()
    };



    // Combine Order Header and Detail data
    var CRMLeadUpdateSectionVM = {
        CRMLeadUpdateSection: Header,
        userRequest: userRequest,

    };

    var oprType = $("#gbloprTypeId").val();

    if (oprType == "Create") {
        // AJAX request to send data to the controller
        $.ajax({
            url: '/CRMLeadUpdateSection/Create',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(CRMLeadUpdateSectionVM),
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
            url: '/CRMLeadUpdateSection/Edit',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(CRMLeadUpdateSectionVM),
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
            url: '/CRMLeadUpdateSection/Delete',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(CRMLeadUpdateSectionVM),
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
