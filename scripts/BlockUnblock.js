$(document).ready(function () {   
});


function BlockUsers(event) {
   // debugger
    var status = event.name;
    var UserID = event.id;
    $.ajax({
        url: link,
        async: false,
        contentType: 'application/json; charset=utf-8',        
        dataType: 'json',
        data: {
            UserID: UserID,
            status:status
        },
    })
  .success(function (result) {
      if (result == true) {
          event.innerHtml("UnBlock");
      }
      else {
          alert("Operation Failed");
      }
  })
  .error(function (xhr, textStatus, errorThrown) {
      if (xhr.status == "590" || xhr.status == "403")
          return false;
      else
          alert("Wrong");
  }
  );
};

