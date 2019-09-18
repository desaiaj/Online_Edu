$(document).ready(function () {
    $('#btnSearch').click(function () {
        SearchComplaint();
    });
});

function SearchComplaint() {
   // debugger
    var id = $('#txtComplaintID').val();
    var Status = $('#Status').val();

    $.ajax({
        url: GetSearch,
        async: false,
        contentType: 'application/html; charset=utf-8',
        dataType: 'html',
        data: {
            ID:id,
            status: Status
        },
    })
    .success(function (result) {
        //debugger
        if (result != null) {
            $('#ComplaintDetail').html(null);
            $('#ComplaintDetail').html(result);
            //alert("y");
        }
        else {
            alert("Error Occured");
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