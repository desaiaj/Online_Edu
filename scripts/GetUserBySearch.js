$(document).ready(function () {
    $('#btnSearch').click(function () {
        SearchUsers();
    });
});

function SearchUsers() {
    //debugger
    var UName   = $('#UName').val();
    var Email  = $('#Email').val();
    var Mobile = $('#Mobile').val();
    var Status = $('#Status').val();

    $.ajax({
        url: GetSearch,
        async: false,
        contentType: 'application/html; charset=utf-8',
        dataType: 'html',
        data: {
            Name : UName,
            Email : Email, 
            Mobile : Mobile,
            Status : Status
        },
    })
    .success(function (result) {
        //debugger
        if (result != null) {
            $('#UsersData').html(null);
            $('#UsersData').html(result);
            //alert("y");
        }
        else {
            alert("Error");
        }
    })
    .error(function (xhr, textStatus, errorThrown) {
        if (xhr.status == "590" || xhr.status == "403")
            return false;
        else
        { }
        //alert("Wrong");
    });
}