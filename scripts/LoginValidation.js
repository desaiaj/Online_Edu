$(document).ready(function () {
    $("#UserName").change(function () {
       // debugger
        if ($("#UserName").val() != "") {
            CheckUserNameForExisting();
        }
        else {
            $("#errorUserName2").css("display", "none");
            $("#errorUserName").css("display", "inline-block");
        }
    });
});

var flagIsUserName = false;
function CheckUserNameForExisting() {
    //debugger
    var lsUserName = $('#UserName').val();
    $.ajax({
        url: lsUserNameCheckUrl,
        async: false,
        contentType: 'application/html; charset=utf-8',
        type: 'GET',
        dataType: 'json',
        data: {
            lsUserName: lsUserName
        },
    })
  .success(function (result) {
      if (result == false) {
          //$("#btnSubmit").removeAttr("disabled", "disabled");
          //$("#btnSubmit").css("color", "#ffffff");
          $("#errorUserName2").css("display", "none");
          $("#errorUserName").css("display", "inline-block");
          flagIsUserName = true;
          
      }
      else {
          //$("#btnSubmit").attr("disabled", "disabled");
          $("#errorUserName2").css("display", "inline-block");
          $("#errorUserName").css("display", "none");
          $("#errorUserName2").html("Oops! Please Check User Name And Try Again");
          flagIsUserName = false;
      }
  })
  .error(function (xhr, textStatus, errorThrown) {
      if (xhr.status == "590" || xhr.status == "403")
          return false;
      else
          //alert(errorThrown);
          alert("Opps! Somthing Happen Wrong...!          Please Refresh Page(Ctr + F5) And Try Again");
          flagIsUserName = false;
  });
};


function formValidate() {
   // debugger
    $('#btnSubmit').attr('disabled', 'disabled');
    CheckUserNameForExisting();
    var form = $('#FrmLogin');
    form.validate();
    var flgIsValidForm = form.valid();

    if (flgIsValidForm && flagIsUserName) {

        $('#FrmLogin').submit();
        return true;
    }
    else {
        $('#btnSubmit').removeAttr('disabled', 'disabled');
        return false;
    }
};