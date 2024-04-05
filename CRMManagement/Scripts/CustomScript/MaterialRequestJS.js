$("Document").ready(function () {

    alert('santosh Test entry');

});
function SubmitFormEdit() {
    var dataDetail = [];

    var MaterialRequestHeader = {
        CmpyCode: $("#CmpyCode").val(),
        MRCode: $("#MRCode").val(),
        Dates: $("#Dates").val(),
        LocCode: $("#LocCode").val(),
        Description: $("#Description").val(),
        EmpCode: $("#EmpCode").val(),
        PreparedBy: $("#PreparedBy").val(),
        ProjectCode: $("#ProjectCode").val(),
        ResourceType: $("#ResourceType").val()
    };
    $('#2').each(function () {
        var detail = {
            CmpyCode: $(this).find('td:eq(0) input').val(),
            MRCode: $(this).find('td:eq(1) input').val(),
            SNo: $(this).find('td:eq(2) input').val(),
            ItemCode: $(this).find('td:eq(3)').val(),
            Description: $(this).find('td:eq(4) input').val(),
            Specification: $(this).find('td:eq(5) input').val(),
            Unit: $(this).find('td:eq(6)').val(),
            Qty: $(this).find('td:eq(7) input').val(),
            QtyReceived: $(this).find('td:eq(8) input').val(),
            Dates: $(this).find('td:eq(9) input').val(),
            status: $(this).find('td:eq(10) input').val(),
            ApprovalYN: $(this).find('td:eq(11) input').val()
            // Add other properties as needed
        };
        dataDetail.push(detail);
    });

    // Combine Order Header and Detail data
    var MaterialRequestVM = {
        MaterialRequestDetail: dataDetail,
        MaterialRequest: MaterialRequestHeader
    };


    // AJAX request to send data to the controller
    $.ajax({
        url: '/MaterialRequest/Create',
        method: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(MaterialRequestVM),
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

function MaterialRequestHeader() {

    

    // Now you can use MaterialRequestHeader with the correct values
    console.log(MaterialRequestHeader);
    return (MaterialRequestHeader);
}
function MaterialRequestDetail() {
    var MaterialRequestDetail = {

    }
    return (MaterialRequestDetail);
}

function tool_bar(expression) {

    switch (expression) {
        case "Create":
            alert(expression);
            break;
        case "Edit":
            // code to be executed if expression matches value2
            alert(expression);
            break;
        case "Delete":
            // code to be executed if expression matches value2
            alert(expression);
            break;
        case "Save":
            SubmitFormEdit();
            
            // code to be executed if expression matches value2
            alert(expression);
            break;
        case "Clear":
            // code to be executed if expression matches value2
            alert(expression);
            break;
        case "Close":
            // code to be executed if expression matches value2
            alert(expression);
            break;
        
        default:
        // code to be executed if none of the cases match the expression
    }


}