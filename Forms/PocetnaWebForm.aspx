<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PocetnaWebForm.aspx.cs" Inherits="WebApplicationFPIS.Forms.PocetnaWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 298px;
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
                             <asp:MenuItem NavigateUrl="~/Forms/Nova.aspx" Text="Nova forma" Value="Izmena"></asp:MenuItem>

                        </asp:MenuItem>
                    </Items>
                    <StaticHoverStyle BackColor="#7C6F57" ForeColor="White" />
                    <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                    <StaticSelectedStyle BackColor="#5D7B9D" />
                </asp:Menu>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
