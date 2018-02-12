<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="TestSite._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="Scripts/jquery-3.3.1.min.js"></script>
    <link type="text/css" href="css/site.css" rel="stylesheet"/>
</head>
<body>
    <fieldset title="Test Api Application">
        <legend>Test API Appliction</legend>
        <table>
            <tr>
                <td>Bearer's Name</td>
                <td>
                    <input type="text" name="bearer" id="bearer" placeholder="John Citizen" />
                </td>
                <td>
                    <div id="bearername"></div>
                </td>
            </tr>
            <tr>
                <td>Amount</td>
                <td>
                    <span class="currencyinput">
                        <input type="number" id="dollararea" name="currency" /></span>
                </td>
                <td>
                    <div id="inwords" style="max-width: 280px;"></div>
                </td>

            </tr>
            <tr>
                <td>Response</td>
                <td colspan="2">
                    <div id="responsearea" style="max-width: 450px;"></div>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: right">
                    <button type="button" class="btn btn-default" id="submitter">Submit</button>
                    <button type="button" class="btn" id="clear">Clear</button>
                </td>
            </tr>
        </table>
    </fieldset>
    <form id="form1" runat="server">
    </form>
    <script type="text/javascript">
        $("#submitter").click(function (event) {
            console.log("submitted");
            var dt = {
                "FullName": $("#bearer").val(),
                "Amount": $("#dollararea").val(),
            };
            console.log(dt);
            var dataType = 'application/json; charset=utf-8';
            var dts = JSON.stringify(dt);
            $.ajax({
                type: "POST",
                url: "http://localhost:2710/api/Default",
                data: dts,
                success: function (a) {
                    $("#responsearea").text(JSON.stringify(a));
                    $("#inwords").text(a.DollarWords);
                    $("#bearername").text(a.FullName);
                },
                error: function (e) {
                    alert(e);
                    debugger;

                },
                dataType: 'json',
                contentType: dataType


            });
        });
        $("#clear").click(function (evt) {
            console.log("clearer");
            evt.preventDefault();
            $("#bearer").val("");
            $("#dollararea").val("").focus();
        });
    </script>
</body>
</html>
