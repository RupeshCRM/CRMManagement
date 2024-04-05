$("Document").ready(function () {

    /*  alert('santosh Test entry');*/

});
     
function SubmitLogin() {
    
    // Combine Order Header and Detail data
    var AuthenticationVM = {
        CompanyName: $("#CompanyName").val(),
        CompanyYear: $("#CompanyYear").val(),
        UserName: $("#UserName").val(),
        Password: $("#Password").val()

    };

   
        // AJAX request to send data to the controller
        $.ajax({
            url: '/Authentication/Login',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(AuthenticationVM),
            async: false,
            success: function (response) {
                //var urlWithParams = response.redirectUrl;  // Assuming redirectUrl already contains the UserRequest parameter
                var currentDate;
                var responseData = JSON.parse(response);
                if (responseData.LoginSuccess) {
                    SubmitLoginSuccess(responseData.UserName, responseData.CompanyCode, responseData.FYear);
                }
                else {
                    alert('Invalid User Name and Password!');
                }
                //// Redirect to the new URL
                //window.location.href = urlWithParams;
           /*     window.location.href = response.redirectUrl;*/
            },
            error: function (error) {
                // Handle error if needed
                alert(SaveErrorMessage);
            }
        });
   
    

}

function SubmitLoginSuccess(strUserName,strCompanyCode,strFYear) {

    // Combine Order Header and Detail data
    var AuthenticationVM = {
        CompanyName: strCompanyCode,
        CompanyYear: strFYear,
        UserName: strUserName
 
    };


    // AJAX request to send data to the controller
    $.ajax({
        url: '/Authentication/LoginSuccess',
        method: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(AuthenticationVM),
        async: false,
        success: function (response) {
            window.location.href = response.redirectUrl;
        },
        error: function (error) {
            // Handle error if needed
            alert(SaveErrorMessage);
        }
    });



}
