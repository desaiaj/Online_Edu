$(document).ready(function () {
    //alert("cal");
    $("#ChooseFile").change(function () {
        checkNotes();
        //alert("cccc");
    });
});


function checkNotes() {
    //debugger
    var FileName = $('#ChooseFile').val();
    var f = document.getElementById("ChooseFile");

    if (f.files && f.files[0]) {
        var size = parseFloat(f.files[0].size / 1024).toFixed(2);
        if (size > 5120) {
            alert("File Size must be less than 5MB");
            //alert("size"+size);
            return false;
        }
    }

    $.ajax({
        type: "POST",
        url: link,
        content: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        data: {
            DocumentName: FileName
        },
        success: function (result) {
            if (result == true) {
                alert("Successfull");
            }
            else {
                $("#ErrMsg").css("display", "block");
                alert("Some Error");
            }
        },
        error: function (xhr, textStatus, errorThrown) {
            if (xhr.status == "590" || xhr.status == "403")
                return false;
            else
                alert("Wrong");
        },
    });
}