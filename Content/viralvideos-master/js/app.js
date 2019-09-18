/// <reference path="../../../Views/Homes/index.cshtml" />
/// <reference path="../../../Views/Homes/tpl/item.html" />
/// <reference path="../../../Views/Homes/tpl/item.html" />
/// <reference path="../../../Views/Homes/index.cshtml" />
function tplawesome(e,t){res=e;for(var n=0;n<t.length;n++){res=res.replace(/\{\{(.*?)\}\}/g,function(e,r){return t[n][r]})}return res}

$(function() {
    $("form").on("submit", function(e) {
       e.preventDefault();
       // prepare the request
       var request = gapi.client.youtube.search.list({
            part: "snippet",
            type: "video",
            q: encodeURIComponent($("#search").val()).replace(/%20/g, "+"),
            maxResults: 7,
            order: "viewCount",
            publishedAfter: "2012-01-01T00:00:00Z"
       }); 
       // execute the request
       request.execute(function (response) {
           //debugger
          var results = response.result;
          $("#results").html("");
          $.each(results.items, function(index, item) {
              $.get("SearchVideoTutorials/res", function (data) {
                $("#results").append(tplawesome(data, [{"title":item.snippet.title, "videoid":item.id.videoId}]));
            });
          });
          resetVideoHeight();
       });
    });
    
    $(window).on("resize", resetVideoHeight);
});

function resetVideoHeight() {
    $(".video").css("height", $("#results").width() * 9/16);
}

function init() {
    gapi.client.setApiKey("AIzaSyDKa2B__L8sVBFHMzttdlfWxCkkPrr9QO0");
    gapi.client.load("youtube", "v3", function() {
        // yt api is ready
    });
}
