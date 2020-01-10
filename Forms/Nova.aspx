<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Nova.aspx.cs" Inherits="WebApplicationFPIS.Forms.Nova" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             UNOS KVARA<br />
                <asp:TextBox ID="TextBoxObavestenje" runat="server" ReadOnly="True" Width="350px" Font-Bold="True" ForeColor="#FF0066"></asp:TextBox>
                <br />
                Šifra kvara:
                <asp:TextBox ID="TextBoxSifraKvara" runat="server" BackColor="#CCCCCC"></asp:TextBox>
                <br />
              OpisKvara
           <asp:TextBox ID="TextBoxOpisKvara" runat="server" TextMode="MultiLine"></asp:TextBox>

             <br />
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="ButtonZapamti" runat="server" Text="Zapamti" OnClick="ButtonZapamti_Click" Width="115px" />
        </div>
    </form>
</body>
</html>
