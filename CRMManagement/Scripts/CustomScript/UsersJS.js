$("Document").ready(function () {

    //$('#TableUSERWORKFLOWRIGHTS').DataTable({
    //    paging: false  // Disable pagination
    //});
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


//function SubmitFormEdit() {
//    var dataDetail = [];

//    var header = {
//        CmpyCode: $("#SummarizeTimeSheetHeaderImport_CmpyCode").val(),
//        Code: $("#SummarizeTimeSheetHeaderImport_Code").val(),
//        Dates: $("#SummarizeTimeSheetHeaderImport_Dates").val(),
//        MonthYear: $("#SummarizeTimeSheetHeaderImport_MonthYear").val(),
//        DepartmentCode: $("#SummarizeTimeSheetHeaderImport_DepartmentCode").val()
//    }
//    $('#tableBody tr').each(function () {
//        var detail = {
//            CmpyCode: $(this).find('td:eq(0) input').val(),
//            Code: $(this).find('td:eq(1) input').val(),
//            Sno: $(this).find('td:eq(2) input').val(),
//            EmpCode: $(this).find('td:eq(3) input').val(),
//            EmpName: $(this).find('td:eq(4) input').val(),
//            PressentDays: $(this).find('td:eq(5) input').val(),
//            ALDays: $(this).find('td:eq(6) input').val(),
//            AbsentDays: $(this).find('td:eq(7) input').val(),
//            LSTDays: $(this).find('td:eq(8) input').val(),
//            LWPDays: $(this).find('td:eq(9) input').val(),
//            HoldDays: $(this).find('td:eq(10) input').val(),
//            NOTHrs: $(this).find('td:eq(11) input').val(),
//            LoanDeduction: $(this).find('td:eq(12) input').val(),
//            MthAddition: $(this).find('td:eq(13) input').val(),
//            MthDeduction: $(this).find('td:eq(14) input').val(),
//            OthAddition: $(this).find('td:eq(15) input').val(),
//            MthLeaveSalary: $(this).find('td:eq(16) input').val(),
//            MthAirTkt: $(this).find('td:eq(17) input').val(),
//            LoanAmount: $(this).find('td:eq(18) input').val()
//            // Add other properties as needed
//        };
//        dataDetail.push(detail);
//    });

//    // Combine Order Header and Detail data
//    var summarizeTimeSheetImportVM = {
//        CmpyCode: $("#SummarizeTimeSheetHeaderImport_CmpyCode").val(),
//        BranchCode: $("#SummarizeTimeSheetHeaderImport_Code").val(),
//        MenuId: $("#MenuId").val(),
//        PrefixCode: $("#PrefixCode").val(),
//        Code: $("#SummarizeTimeSheetHeaderImport_Code").val(),
//        Dates: $("#SummarizeTimeSheetHeaderImport_Dates").val(),
//        MonthYear: $("#SummarizeTimeSheetHeaderImport_MonthYear").val(),
//        SummariseTimeSheetDetail: dataDetail,
//        SummarizeTimeSheetHeaderImport: header
//    };


//    // AJAX request to send data to the controller
//    $.ajax({
//        url: '/HRSummarizeTimeSheetImport/Edit',
//        method: 'POST',
//        contentType: 'application/json',
//        data: JSON.stringify(summarizeTimeSheetImportVM),
//        async: false,
//        success: function (response) {
//            //callIndexView(response);
//            //alert(response.redirectUrl);
//            window.location.href = response.redirectUrl;
//        },
//        error: function (error) {
//            // Handle error if needed
//        }
//    });


//}

//function SubmitFormCreate() {
//    var dataDetail = [];

//    var header = {
//        CmpyCode: $("#SummarizeTimeSheetHeaderImport_CmpyCode").val(),
//        Code: $("#SummarizeTimeSheetHeaderImport_Code").val(),
//        Dates: $("#SummarizeTimeSheetHeaderImport_Dates").val(),
//        MonthYear: $("#SummarizeTimeSheetHeaderImport_MonthYear").val(),
//        DepartmentCode: $("#SummarizeTimeSheetHeaderImport_DepartmentCode").val()
//    }
    
//    $('#tableBody tr').each(function () {
//        var detail = {

//            Code: $(this).find('td:eq(0) input').val(),
//            Sno: $(this).find('td:eq(1) input').val(),
//            CmpyCode: $(this).find('td:eq(2) input').val(),
//            EmpCode: $(this).find('td:eq(3) input').val(),
//            //EmpName: $(this).find('td:eq(4) input').val(),
//            PressentDays: $(this).find('td:eq(4) input').val(),
//            ALDays: $(this).find('td:eq(5) input').val(),
//            AbsentDays: $(this).find('td:eq(6) input').val(),
//            LSTDays: $(this).find('td:eq(7) input').val(),
//            LWPDays: $(this).find('td:eq(8) input').val(),
//            HoldDays: $(this).find('td:eq(9) input').val(),
//            NOTHrs: $(this).find('td:eq(10) input').val(),
//            LoanDeduction: $(this).find('td:eq(11) input').val(),
//            MthAddition: $(this).find('td:eq(12) input').val(),
//            MthDeduction: $(this).find('td:eq(13) input').val(),
//            OthAddition: $(this).find('td:eq(14) input').val(),
//            MthLeaveSalary: $(this).find('td:eq(15) input').val(),
//            MthAirTkt: $(this).find('td:eq(16) input').val(),
//            LoanAmount: $(this).find('td:eq(17) input').val()
//            // Add other properties as needed
//        };
//        dataDetail.push(detail);
//    });

//    // Combine Order Header and Detail data
//    var summarizeTimeSheetImportVM = {
//        CmpyCode: $("#SummarizeTimeSheetHeaderImport_CmpyCode").val(),
//        BranchCode: $("#SummarizeTimeSheetHeaderImport_Code").val(),
//        MenuId: $("#MenuId").val(),
//        PrefixCode: $("#PrefixCode").val(),
//        Code: $("#SummarizeTimeSheetHeaderImport_Code").val(),
//        Dates: $("#SummarizeTimeSheetHeaderImport_Dates").val(),
//        MonthYear: $("#SummarizeTimeSheetHeaderImport_MonthYear").val(),
//        SummariseTimeSheetDetail: dataDetail,
//        SummarizeTimeSheetHeaderImport: header
//    };


//    // AJAX request to send data to the controller
//    $.ajax({
//        url: '/HRSummarizeTimeSheetImport/Create',
//        method: 'POST',
//        contentType: 'application/json',
//        data: JSON.stringify(summarizeTimeSheetImportVM),
//        async: false,
//        success: function (response) {
//            //callIndexView(response);
//            //alert(response.redirectUrl);
//            window.location.href = response.redirectUrl;
//        },
//        error: function (error) {
//            // Handle error if needed
//        }
//    });

//}



function SubmitFormSave() {
    var dataDetail = [];
    var intSno = 1;
    var Header = {
        CmpyCode: $("#CmpyCode").val(),
        LoginUserName: $("#LoginUserName").val(),
        LoginPassword: $("#LoginPassword").val(),
        EmpCode: $("#EmpCode").val()
    };

    var userRequest = {
        SectionId: $("#gblSectionId").val(),
        companyCode: $("#gblcompanyCode").val(),
        FYear: $("#gblFYear").val(),
        UserName: $("#gblUserName").val()
    };

    $('#USERWORKFLOWRIGHTS tr').each(function () {
      

      
        var detail = {
            CmpyCode: $("#CmpyCode").val(),
            Sno: intSno,
            LoginUserName: $("#LoginUserName").val(),
            ModuleCode: $(this).find('td:eq(3) input').val(),
            ModuleDesc: $(this).find('td:eq(4) input').val(),
            WorkflowCode: $(this).find('td:eq(5) input').val(),
            WorkflowDesc: $(this).find('td:eq(6) input').val(),
            AllRights: $(this).find('td:eq(7) input').prop('checked') ? 1 : 0,
            CreateRights: $(this).find('td:eq(8) input').prop('checked') ? 1 : 0,
            EditRights: $(this).find('td:eq(9) input').prop('checked') ? 1 : 0,
            DeleteRights: $(this).find('td:eq(10) input').prop('checked') ? 1 : 0,
            SaveRights: $(this).find('td:eq(11) input').prop('checked') ? 1 : 0,
            PostRights: $(this).find('td:eq(12) input').prop('checked') ? 1 : 0,
            isHidden: $(this).find('td:eq(13) input').prop('checked') ? 1 : 0
        };
        intSno = intSno + 1;
        dataDetail.push(detail);
    });

    // Combine Order Header and Detail data
    var usersVM = {
        users: Header,
        userRequest: userRequest,
        userWorkflowRightsList: dataDetail
    };

    var oprType = $("#gbloprTypeId").val();

    if (oprType == "Create") {
        // AJAX request to send data to the controller
        $.ajax({
            url: '/Users/Create',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(usersVM),
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
            url: '/Users/Edit',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(usersVM),
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
            url: '/Users/Delete',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(usersVM),
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
