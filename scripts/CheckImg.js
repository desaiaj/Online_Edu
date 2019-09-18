$(document).ready(function () {
    //alert("cal");
    $("#SelectImg").change(function () {
         checkImg();
        //alert("cccc");
    });
});

function RemoveImg()
{
    $('ProfileImg').src='';

}

function checkImg() {
   // debugger
    var pic = $('#SelectImg').val();
    var f = document.getElementById("SelectImg");

    if (f.files && f.files[0]) {
        var size = parseFloat(f.files[0].size / 1024);
        if (size > 2048) {
            alert("Image Size Should be Less Then 2MB");
            f.value = null;
        }
    }

    $.ajax({
        url: link,
        async: false,
        contentType: 'application/html; charset=utf-8',
        dataType: "json", 
        data: {
            DocumentName: pic
        },
    })
    .success(function (result) {
        //debugger
        if (result) {
            
            //alert("y");
            //$('#ProfileImage').src=result;
        }
        else {
            $("#ErrMsg").css("display", "block");
            alert("Image Type Should be jpeg, jpg, png");
        }
    })
    .error(function (xhr, textStatus, errorThrown) {
        if (xhr.status == "590" || xhr.status == "403")
            return false;
        else
            alert("Wrong");
    });
};