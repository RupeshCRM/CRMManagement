function SubmitFormSave(HistoryType) {
    var dataDetail = [];
    var intSno = 1;
    var strActivityDescription = "";
    if (HistoryType == 'Task') {
        strActivityDescription = $("#txtNewActivity").val();
    }
    if (HistoryType == 'Activity') {
        strActivityDescription = $("#txtNewTask").val();
    }

    var Header = {
        CmpyCode: $("#CmpyCode").val(),
        EntryType: HistoryType,
        HistoryRef: '',
        ReferenceNo: '',
        ActivityType: 'Call',
        ActivityDescription: strActivityDescription,
        UserName: $("#gblUserName").val()
    };

    var userRequest = {
        SectionId: $("#gblSectionId").val(),
        companyCode: $("#gblcompanyCode").val(),
        FYear: $("#gblFYear").val(),
        UserName: $("#gblUserName").val()
    };



    // Combine Order Header and Detail data
    var CRMHistoryDetailVM = {
        CRMHistoryDetail: Header,
        userRequest: userRequest,
    };


    $.ajax({
        url: '/UserLandingPage/NewHistory',
        method: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(CRMHistoryDetailVM),
        async: false,
        success: function(response) {
            //callIndexView(response);
            alert(SaveSuccessMessage);
            //window.location.href = response.redirectUrl;
        },
        error: function(error) {
            // Handle error if needed
            alert(SaveErrorMessage);
        }
    });

    /*    var oprType = $("#gbloprTypeId").val();*/
    //if (oprType == "Create") {
    //    // AJAX request to send data to the controller
    //    $.ajax({
    //        url: '/CRMLeadUpdateSection/Create',
    //        method: 'POST',
    //        contentType: 'application/json',
    //        data: JSON.stringify(CRMLeadUpdateSectionVM),
    //        async: false,
    //        success: function (response) {
    //            //callIndexView(response);
    //            alert(SaveSuccessMessage);
    //            window.location.href = response.redirectUrl;
    //        },
    //        error: function (error) {
    //            // Handle error if needed
    //            alert(SaveErrorMessage);
    //        }
    //    });
    //}
    //else if (oprType == "Edit") {
    //    // AJAX request to send data to the controller
    //    $.ajax({
    //        url: '/CRMLeadUpdateSection/Edit',
    //        method: 'POST',
    //        contentType: 'application/json',
    //        data: JSON.stringify(CRMLeadUpdateSectionVM),
    //        async: false,
    //        success: function (response) {
    //            //callIndexView(response);
    //            alert(SaveSuccessMessage);
    //            window.location.href = response.redirectUrl;
    //        },
    //        error: function (error) {
    //            // Handle error if needed
    //            alert(SaveErrorMessage);
    //        }
    //    });
    //}
    //else if (oprType == "Delete") {
    //    // AJAX request to send data to the controller
    //    $.ajax({
    //        url: '/CRMLeadUpdateSection/Delete',
    //        method: 'POST',
    //        contentType: 'application/json',
    //        data: JSON.stringify(CRMLeadUpdateSectionVM),
    //        async: false,
    //        success: function (response) {
    //            //callIndexView(response);
    //            alert(DeleteSuccessMessage);
    //            window.location.href = response.redirectUrl;
    //        },
    //        error: function (error) {
    //            // Handle error if needed
    //            alert(SaveErrorMessage);
    //        }
    //    });
    //}
}
