var storeApi = {
    GetPost: function (postId, elementId, loadFunction) {
        var client = new XMLHttpRequest();
        client.onload = function (response) {
            if (loadFunction) {
                loadFunction(elementId, JSON.parse(this.responseText));
            }
        }
        client.open('GET', '/Home/GZPost/' + postId.toString(), true);
        client.send();
    }
}

function printDate(value) {
    var dateValue = new Date(value);
    var dateDay = dateValue.getDate();
    var dateMonth = dateValue.getMonth() + 1;
    return ((dateDay < 10) ? '0' + dateDay : dateDay) + '.' +
           ((dateMonth < 10) ? '0' + dateMonth : dateMonth) + '.' +
           dateValue.getFullYear();
}