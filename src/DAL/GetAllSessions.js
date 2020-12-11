import $ from "jquery";

function GetAllSessions(url, resultHandler, comp) {
    $.get(url, function (data) {
        resultHandler(comp, data);
    });
}

export default GetAllSessions;
