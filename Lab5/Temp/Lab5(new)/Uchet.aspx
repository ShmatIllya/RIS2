<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Uchet.aspx.cs" Inherits="Lab5_new_.Uchet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="flex-direction:column">
            <label>Сколько миль прошла машина?:</label>
            <input type="text" runat="server" id="milesPassed" />
            <br />
            <asp:Button runat="server" ID="btnCar" Text="Как сильно моей машине нужен ремонт?" OnClick="btnCar_Click" />
            <br />
            <br />
            <label>Результат:</label>
            <asp:Label runat="server" ID="lblResult" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
