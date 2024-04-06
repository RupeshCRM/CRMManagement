$(document).ready(function () {
    // Event delegation for double click on table rows
    $(document).on("dblclick", "#example1 tr", function () {
        // Handle the double click event on table rows
        // Access specific row data, etc.
        var rowData = $(this).find("td").map(function () {
            return $(this).text();
        }).get();
        // Split rowData into an array of strings
        var rowDataArray = rowData.map(function (item) {
            return item.split(','); // Assuming ',' as delimiter, change as needed
        });

        // Example: Log rowDataArray
        console.log("rowDataArray:", rowDataArray);

        // Example: Access individual elements in rowDataArray
        var firstColumnArray = rowDataArray[0];
        var secondColumnArray = rowDataArray[1]; // Assuming there's a second column

        // Example: Log individual elements in rowDataArray
        console.log("First Column Array:", firstColumnArray);
        console.log("Second Column Array:", secondColumnArray);
        $("#idActivityText").val(firstColumnArray);
       
    });
    // Trigger a specific event on the table
    $("#example1").trigger("dblclick");
});

function RefreshDetail(Id) {
    $.ajax({
        url: '/UserLandingPage/RefreshDetail',
        method: 'GET',
        contentType: 'application/json',
        data: { Id: Id },
        async: false,
        success: function (result) {

            $('#partialViewContainer').html(result);
            $('#IdCurrentWorkflow').val(Id);
        },
        error: function (error) {
            // Handle error if needed
            alert(SaveErrorMessage);
        }
    });
}



function SubmitFormSave(HistoryType) {
    var dataDetail = [];
    var intSno = 1;
    var strActivityDescription = "";
    if (HistoryType == 'Task') {
        strActivityDescription = $("#txtNewTask").val();
    }
    if (HistoryType == 'Activity') {
        strActivityDescription = $("#txtNewActivity").val();
    }
    
    var Header = {
        CmpyCode: $("#CmpyCode").val(),
        EntryType: HistoryType,
        DocReferenceNo: $("#IdCurrentWorkflow").val(),
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
        success: function (response) {
            //callIndexView(response);
           /* alert(SaveSuccessMessage);*/
            //window.location.href = response.redirectUrl;
        },
        error: function (error) {
            // Handle error if needed
            /*alert(SaveErrorMessage);*/
        }
    });


 
    $("#txtNewTask").val('');
    $("#txtNewActivity").val('');
  
}
