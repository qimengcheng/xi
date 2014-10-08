<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintCSUser.aspx.cs" Inherits="ProductionProcess_PrintCSUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="Stylesheet" href="../css/style.css" />
    <style type="text/css">
        table
        {
            border: 1px solid #BABABA;
            border-collapse: collapse;
        }
        td
        {
            border: 1px dotted #BABABA;
            height: 30px;
        }
        /*tr{border:1px solid rgb(221, 221, 221)}*/
        .auto-style4
        {
            width: 271px;
        }
        
        .auto-style5
        {
            width: 234px;
        }
        .style1
        {
            width: 342px;
        }
        .style2
        {
            width: 20px;
        }
        .style3
        {
            width: 22px;
        }
    </style>
</head>
<script language="Javascript">
    function preview() {
        bdhtml = window.document.body.innerHTML;
        sprnstr = "<!--startprint-->";
        eprnstr = "<!--endprint-->";
        prnhtml = bdhtml.substr(bdhtml.indexOf(sprnstr) + 17);
        prnhtml = prnhtml.substring(0, prnhtml.indexOf(eprnstr));
        window.document.body.innerHTML = prnhtml;
        window.print();
    }
</script>
<body style="text-align: center; width: 1024px; margin: 0 auto; background-color: #FFFFFF;
    background-image: none">
    <form id="form1" runat="server" width="1024px">
    <!--startprint-->
    <p style="font-size: 30px;">
        客户端操作员口令条码打印</p>
    <div>
        <table style="width: 100%;">
            <tr>
                <td align="center" class="style1">
                    &nbsp;
                    <asp:Label ID="num1" runat="server" Font-Italic="False" Font-Names="C39HrP36DmTt"
                        Font-Overline="False" Font-Size="100pt" Font-Underline="False" Text="123456"></asp:Label>
                    <br />
                </td>
                <td class="style2">
                    &nbsp;
                </td>
                <td class="style1">
                    &nbsp;
                    <asp:Label ID="num2" runat="server" Font-Italic="False" Font-Names="C39HrP36DmTt"
                        Font-Overline="False" Font-Size="100pt" Font-Underline="False" Text="123456"></asp:Label>
                </td>
                <td class="style3">
                    &nbsp;
                </td>
                <td class="style1">
                    &nbsp;
                    <asp:Label ID="num3" runat="server" Font-Italic="False" Font-Names="C39HrP36DmTt"
                        Font-Overline="False" Font-Size="100pt" Font-Underline="False" Text="123456"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;
                    <asp:Label ID="Name1" runat="server" Font-Italic="False" Font-Overline="False" Font-Size="35pt"
                        Font-Underline="False" Text="123456"></asp:Label>
                </td>
                <td class="style2">
                    &nbsp;
                </td>
                <td>
                    <asp:Label ID="Name2" runat="server" Font-Italic="False" Font-Overline="False" Font-Size="35pt"
                        Font-Underline="False" Text="123456"></asp:Label>
                </td>
                <td class="style3">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                    <asp:Label ID="Name3" runat="server" Font-Italic="False" Font-Overline="False" Font-Size="35pt"
                        Font-Underline="False" Text="123456"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;
                </td>
                <td class="style2">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td class="style3">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;
                    <asp:Label ID="num4" runat="server" Font-Italic="False" Font-Names="C39HrP36DmTt"
                        Font-Overline="False" Font-Size="100pt" Font-Underline="False" Text="123456"></asp:Label>
                </td>
                <td class="style2">
                    &nbsp;
                </td>
                <td>
                    <asp:Label ID="num5" runat="server" Font-Italic="False" Font-Names="C39HrP36DmTt"
                        Font-Overline="False" Font-Size="100pt" Font-Underline="False" Text="123456"></asp:Label>
                </td>
                <td class="style3">
                    &nbsp;
                </td>
                <td>
                    <asp:Label ID="num6" runat="server" Font-Italic="False" Font-Names="C39HrP36DmTt"
                        Font-Overline="False" Font-Size="100pt" Font-Underline="False" Text="123456"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label ID="Name4" runat="server" Font-Italic="False" Font-Overline="False" Font-Size="35pt"
                        Font-Underline="False" Text="123456"></asp:Label>
                </td>
                <td class="style2">
                    &nbsp;
                </td>
                <td>
                    <asp:Label ID="Name5" runat="server" Font-Italic="False" Font-Overline="False" Font-Size="35pt"
                        Font-Underline="False" Text="123456"></asp:Label>
                </td>
                <td class="style3">
                    &nbsp;
                </td>
                <td>
                    <asp:Label ID="Name6" runat="server" Font-Italic="False" Font-Overline="False" Font-Size="35pt"
                        Font-Underline="False" Text="123456"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;
                </td>
                <td class="style2">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td class="style3">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label ID="num7" runat="server" Font-Italic="False" Font-Names="C39HrP36DmTt"
                        Font-Overline="False" Font-Size="100pt" Font-Underline="False" Text="123456"></asp:Label>
                </td>
                <td class="style2">
                    &nbsp;
                </td>
                <td>
                    <asp:Label ID="num8" runat="server" Font-Italic="False" Font-Names="C39HrP36DmTt"
                        Font-Overline="False" Font-Size="100pt" Font-Underline="False" Text="123456"></asp:Label>
                </td>
                <td class="style3">
                    &nbsp;
                </td>
                <td>
                    <asp:Label ID="num9" runat="server" Font-Italic="False" Font-Names="C39HrP36DmTt"
                        Font-Overline="False" Font-Size="100pt" Font-Underline="False" Text="123456"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label ID="Name7" runat="server" Font-Italic="False" Font-Overline="False" Font-Size="35pt"
                        Font-Underline="False" Text="123456"></asp:Label>
                </td>
                <td class="style2">
                    &nbsp;
                </td>
                <td>
                    <asp:Label ID="Name8" runat="server" Font-Italic="False" Font-Overline="False" Font-Size="35pt"
                        Font-Underline="False" Text="123456"></asp:Label>
                </td>
                <td class="style3">
                    &nbsp;
                </td>
                <td>
                    <asp:Label ID="Name9" runat="server" Font-Italic="False" Font-Overline="False" Font-Size="35pt"
                        Font-Underline="False" Text="123456"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;
                </td>
                <td class="style2">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td class="style3">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <!--endprint-->
    <asp:Button ID="Button1" runat="server" OnClientClick="preview()" CssClass="Button02"
        Text="打印" Width="58px" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button2" runat="server" CssClass="Button02" OnClick="Button2_Click"
        Text="返回" Width="55px" />
    </form>
</body>
</html>
