//Ajax används för att stanna kvar på sidan och ladda om en lite del

$("#btnInfo").click(function () {

    var idNameList = document.getElementById("Select1");
    var selectedName = idNameList.options[idNameList.selectedIndex].text;
    $.ajax({
        url: "/index/info/" + selectedName,
        type: "GET",
        data: null,
        success: function (result) {
            console.log(result);
            $("#divResultDetails").html(result);
        }
    }),


        $.ajax({
            url: "/index/map/" + idNameList,
            type: "GET",
            data: null,
            success: function (result) {
                console.log(result);
                $("#divResultMap").html(result);
            }
        });
});
$("btnSearch").click(function () {

    var idName = document.getElementById("textBoxCraterName").value;
    $.ajax({
        url: "/index/info/" + idName,
        type: "GET",
        data: null,
        success: function (result) {
            console.log(result);
            $("#divResultDetails").html(result);
        }
    }),

        $.ajax({
            url: "/index/map/" + idName,
            type: "GET",
            data: null,
            success: function (result) {
                console.log(result);
                $("#divResultMap").html(result);
            }
        });

});