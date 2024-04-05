$("Document").ready(function () {

 //Image preview on file input change

    //$('#fileInput').change(function () {
    //    readURL(this);
    //});

});


// Function to read and display the selected image
function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#imgPreview').attr('src', e.target.result).show();
        };

        reader.readAsDataURL(input.files[0]);
    }
}

// Submit the form using AJAX
$('#uploadForm').submit(function (e) {
    e.preventDefault();

    var formData = new FormData(this);

    $.ajax({
        url: $(this).attr('action'),
        type: 'POST',
        data: formData,
        processData: false,
        contentType: false,
        success: function (data) {
            if (data.error) {
                alert(data.error);
            } else {
                // Clear file input and hide image preview after successful upload
                $('#fileInput').val('');
                $('#imgPreview').hide();

                // Reload the file list or update the view as needed
                // For simplicity, you can reload the entire page
                location.reload();
            }
        }
    });
});


function SubmitFormSave() {

    var fileInput = document.getElementById('fileAttachment');
    var file = fileInput.files[0];

    var CmpyCode = $("#gblcompanyCode").val();
    var RefNo = $("#DocumentAttachment_RefNo").val();
    var DocCode = $("#DocumentAttachment_DocCode").val();
    var IssueDate = $("#DocumentAttachment_IssueDate").val();
    var ExpiryDate = $("#DocumentAttachment_ExpiryDate").val();
    var Specification = $("#DocumentAttachment_Specification").val();
    
    if (file) {

        var formData = new FormData();
        formData.append('file', file);
        formData.append('CmpyCode', CmpyCode);
        formData.append('RefNo', RefNo);
        formData.append('DocCode', DocCode);
        formData.append('IssueDate', IssueDate);
        formData.append('ExpiryDate', ExpiryDate);
        formData.append('Specification', Specification);
        formData.append('SectionId', $("#gblSectionId").val());
        formData.append('userName', $("#gblUserName").val());
    
    var userRequest = {
        SectionId: $("#gblSectionId").val(),
        companyCode: $("#gblcompanyCode").val(),
        FYear: $("#gblFYear").val(),
        UserName: $("#gblUserName").val()
        };

   

    var oprType = $("#gbloprTypeId").val();

    if (oprType == "Create") {
        // AJAX request to send data to the controller
        $.ajax({
            url: '/DocumentAttachment/Create', // Update the URL according to your controller action
            type: 'POST',
            data: formData,
            processData: false,
            contentType: false,
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
            url: '/DocumentAttachment/Edit',
            method: 'POST',
            contentType: 'application/json',
            data: formData,
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
            url: '/DocumentAttachment/Delete',
            method: 'POST',
            data: formData,//JSON.stringify(DocumentAttachmentVM)
            async: false,
            processData: false,
            contentType: false,
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
    } else {
        alert("No file selected");
    }
}

function AttachFile() {
    var fileInput = document.getElementById('fileAttachment');
    var file = fileInput.files[0];

    var CmpyCode = $("#gblcompanyCode").val();
    var RefNo = $("#DocumentAttachment_RefNo").val();
    var DocCode = $("#DocumentAttachmentMaster_DocCode").val();
    var DocDescription = $("#DocumentAttachmentMaster_DocDescription").val();
    var IssueDate = $("#DocumentAttachment_IssueDate").val();
    var ExpiryDate = $("#DocumentAttachment_ExpiryDate").val();
    var Specification = $("#DocumentAttachment_Specification").val();



    if (file) {

        var formData = new FormData();
        formData.append('file', file);
        formData.append('CmpyCode', CmpyCode);
        formData.append('RefNo', RefNo);
        formData.append('DocCode', DocCode);
        formData.append('DocDescription', DocDescription);
        formData.append('IssueDate', IssueDate);
        formData.append('ExpiryDate', ExpiryDate);
        formData.append('Specification', Specification);

        $.ajax({
            url: '/DocumentAttachment/Create', // Update the URL according to your controller action
            type: 'POST',
            data: formData,
            processData: false,
            contentType: false,
            success: function (response) {
                if (response.success) {
                    // Handle success message
                    alert(response.message);
                } else {
                    // Handle error message
                    alert(response.message);
                }
            },
            error: function (error) {
                // Handle error response from the server
                alert("Error uploading file:", error.statusText);
            }
        });
    } else {
        alert("No file selected");
    }
}