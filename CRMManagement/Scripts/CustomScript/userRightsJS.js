$("Document").ready(function () {

  

});


function validate_User_Right(expression, gblcreateRecord, gbleditRecord, gbldeleteRecord, saveRecord) {
    var blnFlag = false;
    /*alert('Hey, I am in');*/
    switch (expression) {
        case "Create":
            if (gblcreateRecord == "1") {
                blnFlag = true;
            }
            break;
        case "Edit":
            // code to be executed if expression matches value2
            if (gbleditRecord == "1") {
                blnFlag = true;
            }
            break;
        case "Delete":
            // code to be executed if expression matches value2
            if (gbldeleteRecord == "1") {
                blnFlag = true;
            }
            break;
        case "Save":
            if (saveRecord == "1") {
                blnFlag = true;
            }
            break;

        default:
        // code to be executed if none of the cases match the expression
    }
    /*alert(blnFlag);*/
    return (blnFlag);
}