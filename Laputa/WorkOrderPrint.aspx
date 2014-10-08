<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WorkOrderPrint.aspx.cs" Inherits="Laputa_WorkOrderPrint" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
        生产流程单</p>
    <div style="text-align: left;">
        <fieldset>
            <legend>随工单信息<asp:Label ID="Label_WO_Type" runat="server" Visible="False"></asp:Label>
            </legend>
            <table cellpadding="0" cellspacing="0" style="width: 100%;" class="table">
                <tr>
                    <td class="auto-style5">
                        随工单号:<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        芯片代码:<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        档次:<asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        周期码:<asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        订单号:<asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        随工单类型:<asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        打印人:<asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        打印时间:<asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        产品型号:<asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        环氧规格:<asp:Label ID="Label10" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        压塑模具:<asp:Label ID="Label11" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        芯片型号:<asp:Label ID="Label12" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6" style="text-align: center" colspan="2">
                        条码:&nbsp;
                        <asp:Label ID="wonum2" runat="server" Text="123456" Font-Italic="False" Font-Names="C39HrP36DmTt"
                            Font-Overline="False" Font-Size="80pt" Font-Underline="False"></asp:Label>
                        <br />
                    </td>
                    <td class="auto-style7" colspan="2">
                        备注:<asp:TextBox ID="TextBox1" runat="server" Height="84px" TextMode="MultiLine" Width="479px"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
    <div>
        <fieldset>
            <legend>测试参数</legend>
            <table style="width: 100%">
                <tr>
                    <td>
                        <asp:Label ID="Label13" runat="server" Text="Label"></asp:Label>
                        <asp:Label ID="wonum" runat="server" Text="123456" Visible="False"></asp:Label>
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
    <div style="text-align: left; width: 1024px">
        <fieldset>
            <legend>材料信息 </legend>
            <asp:GridView ID="GridView1" runat="server" CssClass="GridViewStyle" Style="width: 100%"
                AutoGenerateColumns="False" EnableModelValidation="True">
                <RowStyle CssClass="GridViewRowStyle" />
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle CssClass="GridViewHead" />
                <FooterStyle CssClass="GridViewFooterStyle" />
                <Columns>
                    <asp:BoundField DataField="IMMBD_MaterialName" HeaderText="材料名称" Visible="true" />
                    <asp:BoundField DataField="WOMBN_BN" HeaderText="初次批号" Visible="true" />
                    <asp:BoundField HeaderText="本次批号" />
                </Columns>
            </asp:GridView>
        </fieldset>
    </div>
    <div>
        <fieldset>
            <legend>统计信息</legend>
            <asp:GridView ID="GridView3" runat="server" CssClass="GridViewStyle" AutoGenerateColumns="False"
                EnableModelValidation="True">
                <RowStyle CssClass="GridViewRowStyle" />
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle CssClass="GridViewHead" />
                <FooterStyle CssClass="GridViewFooterStyle" />
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="工序名称" Visible="False" />
                    <asp:BoundField HeaderText="日期" />
                    <asp:BoundField HeaderText="管理员" />
                    <asp:BoundField HeaderText="投入数" />
                    <asp:BoundField HeaderText="合格数" />
                    <asp:BoundField HeaderText="合格率" />
                    <asp:BoundField HeaderText="待处理品" />
                    <asp:BoundField HeaderText="百分率" />
                    <asp:BoundField HeaderText="不合格品" />
                    <asp:BoundField HeaderText="百分率" />
                    <asp:BoundField HeaderText="物料平衡" />
                </Columns>
            </asp:GridView>
        </fieldset>
    </div>
    <div style="text-align: left; width: 1024px">
        <fieldset>
            <legend>工序信息 </legend>
            <asp:Label ID="Label20" runat="server" ForeColor="Red"></asp:Label>
            <asp:GridView ID="GridView2" runat="server" CssClass="GridViewStyle" Style="width: 100%"
                AutoGenerateColumns="False" EnableModelValidation="True" OnRowDataBound="GridView2_RowDataBound">
                <RowStyle CssClass="GridViewRowStyle" />
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle CssClass="GridViewHead" />
                <FooterStyle CssClass="GridViewFooterStyle" />
                <Columns>
                    <asp:BoundField DataField="PBC_Name" HeaderText="工序" Visible="true" />
                    <asp:BoundField DataField="PRD_RenZhengOrder" HeaderText="认证工序排序" Visible="false" />
                    <asp:BoundField DataField="PRD_RouteOrder" SortExpression="PRD_RouteOrder" HeaderText="认证路线排序"
                        Visible="False"></asp:BoundField>
                    <asp:BoundField HeaderText="班次" />
                    <asp:BoundField HeaderText="作业员" Visible="true" />
                    <asp:BoundField HeaderText="设备" />
                    <asp:BoundField HeaderText="进站时间" />
                    <asp:BoundField HeaderText="出站时间" />
                    <asp:BoundField HeaderText="投入数量" />
                    <asp:BoundField HeaderText="合格数量" />
                    <asp:BoundField HeaderText="合格率" />
                    <asp:BoundField HeaderText="不良品类型及数量" />
                    <asp:BoundField HeaderText="废品总数" />
                </Columns>
            </asp:GridView>
        </fieldset>
    </div>
    <!--endprint-->
    <asp:Button runat="server" OnClientClick="preview()" CssClass="Button02" Text="打印"
        Width="58px" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" CssClass="Button02" OnClick="Button1_Click"
        Text="返回" Width="55px" />
    </form>
</body>
</html>
