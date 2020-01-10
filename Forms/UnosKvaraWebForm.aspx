<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UnosKvaraWebForm.aspx.cs" Inherits="WebApplicationFPIS.Forms.UnosKvaraWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 318px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="Panel1" runat="server" CssClass="auto-style1">
                <asp:Menu ID="Menu1" runat="server" BackColor="#F7F6F3" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="X-Large" ForeColor="#7C6F57" StaticSubMenuIndent="10px">
                    <DynamicHoverStyle BackColor="#7C6F57" ForeColor="White" />
                    <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                    <DynamicMenuStyle BackColor="#F7F6F3" />
                    <DynamicSelectedStyle BackColor="#5D7B9D" />
                    <Items>
                        <asp:MenuItem Text="Kvar" Value="Kvar">
                            <asp:MenuItem NavigateUrl="~/Forms/UnosKvaraWebForm.aspx" Text="Unos" Value="Unos"></asp:MenuItem>
                            <asp:MenuItem NavigateUrl="~/Forms/IzmenaKvaraWebForm.aspx" Text="Izmena" Value="Izmena"></asp:MenuItem>
                        </asp:MenuItem>
                    </Items>
                    <StaticHoverStyle BackColor="#7C6F57" ForeColor="White" />
                    <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                    <StaticSelectedStyle BackColor="#5D7B9D" />
                </asp:Menu>
                <br />
                UNOS KVARA<br />
                <asp:TextBox ID="TextBoxObavestenje" runat="server" ReadOnly="True" Width="350px" Font-Bold="True" ForeColor="#FF0066"></asp:TextBox>
                <br />
                Šifra kvara:
                <asp:TextBox ID="TextBoxSifraKvara" runat="server" BackColor="#CCCCCC" ReadOnly="True"></asp:TextBox>
                <br />
               Šifra gosta:
                <asp:TextBox ID="TextBoxSifraGosta" runat="server" TextMode="Number"></asp:TextBox>
                &nbsp;<asp:Button ID="ButtonPonadjiGosta" runat="server" Text="Pronađi gosta" OnClick="ButtonPonadjiGosta_Click" />
                <br />
                Ime gosta:
                <asp:TextBox ID="TextBoxImeGosta" runat="server" BackColor="#CCCCCC" ReadOnly="True"></asp:TextBox>
                <br />
                Prezime gosta:
                <asp:TextBox ID="TextBoxPrezimeGosta" runat="server" BackColor="#CCCCCC" ReadOnly="True"></asp:TextBox>
                <br />
                Datum kvara:
                <asp:TextBox ID="TextBoxDatumKvara" runat="server" TextMode="Date"></asp:TextBox>
                <br />
                Broj sobe:
                <asp:DropDownList ID="DropDownListBrojSobe" runat="server">
                </asp:DropDownList>
                <br />
                Opis kvara:
                <asp:TextBox ID="TextBoxOpisKvara" runat="server" TextMode="MultiLine"></asp:TextBox>
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="ButtonZapamti" runat="server" Text="Zapamti" OnClick="ButtonZapamti_Click" Width="115px" />
                <br />
            </asp:Panel>
        </div>
    </form>
</body>
</html>
