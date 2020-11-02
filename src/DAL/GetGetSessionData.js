import $ from 'jquery';

function GetGetSessionData(url,futureUrl, sessionId,resultHandler,comp){
    var futureId;
      $.ajax({
        type: "POST",
        contentType: "application/json",
        url: url,
        data: sessionId,
        dataType: "json"
     }).done(function( data ) {
      futureId = data.Id.Id;
      var futureData ={"Id": futureId};
      FutureRequest(futureUrl,futureData,resultHandler,comp);
    });
}
function FutureRequest(futureUrl,futureData,resultHandler,comp){
    var transfer = JSON.stringify(futureData);
    $.post(futureUrl,futureData).done(function( data2 ) {
      resultHandler(comp,data2.results);
    });
}
export default GetGetSessionData;