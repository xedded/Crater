//Ajax används för att stanna kvar på sidan och ladda om en lite del

$("#btnInfo").click(function () {

    var idName = document.getElementById("#textBoxCraterName").value;
    $.ajax({
        url: "/index/info/" + idName,
        type: "GET",
        data: null,
        success: function (result) {
            console.log(result);
            $("#divResultDetails").html(result);
        }
    });
});