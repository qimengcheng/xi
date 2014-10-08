<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SMSCWOPrint.aspx.cs" Inherits="ProductionProcess_SMSCWOPrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="Stylesheet" href="../css/style.css" />
      <script type="text/javascript" src="../JS/jquery-1.10.2.min.js"></script>
    <style type="text/css">
       .style1
        {
            width: 97px;
        }
        .style8
        {
            height: 40px;
            width: 118px;
        }
        .style9
        {
            width: 105px;
        }
    </style>
     <script type="text/javascript">
         $(document).ready(
          function () {
              $("th").css("border-left", "1px solid black");
              $(".cg tr td:first-child").css("border-left", "none");
              $(".cg th:first-child").css("border-left", "none");
          });
     </script>
             <style type="text/css">
      
         .table_border
         {
             border-collapse: collapse;
             border-bottom: 1px #DDD solid;
             border-left: 1px #DDD solid;
             border-color: black;
             width: 100%;
         }
         .table_border td
         {
             border-collapse: collapse;
             border-top: 1px #DDD solid;
             border-right: 1px #DDD solid;
             border-color: black;
         }
      
         .style12
         {
             width: 101px;
         }
         .cg {
             border: none;
         }
         .cg td
         {
             border-left: 1px solid black;
             border-collapse: collapse;
             border-right : 0px solid red;
             border-spacing: 0;
         }

        
       
   
        
         .style13
         {
             width: 114px;
         }
         .auto-style2 {
             height: 55px;
         }
         .auto-style3 {
             height: 17px;
         }
         .auto-style4 {
             height: 40px;
         }
                 .auto-style5 {
                     width: 821px;
                 }
                 .auto-style6 {
                     height: 22px;
                 }
                 .auto-style7 {
                     height: 21px;
                 }
         </style>
             </head>
             <script type="text/javascript" language="Javascript">
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
    <p style="font-size: 18px;">
        乐山希尔电子 <asp:Label ID="Label2" runat="server" > </asp:Label> 生产流程单
    </p>
    <table style="width:100%">
        <tr style="width:100%">
            <td style="width:30%"> </td>
            <td align="center" style="width:20%">
                打印人：<asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
            </td>
            <td align="center" style="width:20%">
                打印时间：<asp:Label ID="Label26" runat="server" Text="Label"></asp:Label>
            </td>
            <td style="width:30%"> </td>
       </tr>
    </table>
    <div style="text-align: left;">
       
        <fieldset>
            <legend>随工单信息<asp:Label ID="Label_WO_Type" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="Label21" runat="server" Text="Label" Visible="False"></asp:Label>
            </legend>
            <table border="0" cellspacing="1" width="100%" style="text-align: center">
                <tr>
                    <td align="center" valign="top" class="auto-style2" rowspan="2" >
                        <asp:Label ID="wonum3" runat="server" Font-Italic="False" Font-Names="C39HrP36DmTt"
                            Font-Overline="False" Font-Size="60pt" Font-Underline="False" Text="123456"></asp:Label>
                    </td>
                    <td align="center" valign="top" class="auto-style3" >
                        产品型号
                    </td>
                    <td align="center" valign="top" class="auto-style3" >
                        计划数量</td>
                    <td align="center" valign="top" class="auto-style3" >
                        印字附加码</td>
                    <td align="center" valign="top" class="auto-style3" >
                        订单编号
                    </td>
                    <td align="center" valign="top" class="auto-style3">
                        交货日期
                    </td>
                    <td align="center" valign="top" class="auto-style3">
                        &nbsp;&nbsp; 订单日期
                    </td>
                    <td align="center" valign="top" class="auto-style3">
                        周期码</td>
                </tr>
                <tr>
                    <td align="center" valign="top" class="auto-style4" >
                        <asp:Label ID="Label22" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td align="center" valign="top" class="auto-style4" >
                        <asp:Label ID="Label32" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td align="center" valign="top" class="auto-style4" >
                        <asp:Label ID="Label31" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td align="center" valign="top" class="auto-style4" >
                        <asp:Label ID="Label23" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td align="center" valign="top" class="auto-style4">
                        &nbsp;
                        <asp:Label ID="Label30" runat="server" Text="Label" Visible="False"></asp:Label>
                    </td>
                    <td align="center" valign="top" class="auto-style4">
                        &nbsp;
                        <asp:Label ID="Label27" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td align="center" valign="top" class="auto-style4">
                        <asp:Label ID="Label24" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td  colspan="8">
                        <asp:GridView ID="GridViewBatchNum" runat="server" class="table_border" AutoGenerateColumns="True"
                EnableModelValidation="True" >
                <RowStyle CssClass="GridViewRowStyle" />
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle CssClass="GridViewHead" />
                <FooterStyle CssClass="GridViewFooterStyle" />
                <Columns>
                    
                </Columns>
            </asp:GridView>
                    </td>
                </tr>
                </table>

        </fieldset>
    </div>
    <div style="text-align: left">
        <fieldset>
            <legend>产品基本信息</legend>
            <table style="width: 100%;border: none">
                <tr>
                    <td>
                        <asp:Label ID="Label13" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
    <div style="text-align: left">
        <fieldset>
            <legend>产品测试参数</legend>
            <div style="height:36px">
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                   </div>
        </fieldset>
    </div>
    <div style="text-align: left; width: 1024px; font-size: small;">
        <fieldset>
            <legend>工序信息 </legend>
            <asp:Label ID="Label20" runat="server" ForeColor="Red"></asp:Label>
            <asp:GridView ID="GridView2" runat="server" Style="width: 100%" class="table_border"
                AutoGenerateColumns="False" OnRowDataBound="GridView2_RowDataBound" BorderStyle="Solid"
                CaptionAlign="Top" HorizontalAlign="Center" CellPadding="0" CellSpacing="0">
                <RowStyle CssClass="GridViewRowStyle" HorizontalAlign="Center" VerticalAlign="Top"
                    Font-Size="Small" />
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle CssClass="GridViewHead" HorizontalAlign="Center" VerticalAlign="Top" />
                <FooterStyle CssClass="GridViewFooterStyle" />
                <Columns>
                    <asp:BoundField DataField="PBC_Name" HeaderText="工序" Visible="true">
                        <ItemStyle Height="30pt" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:BoundField DataField="PRD_RenZhengOrder" HeaderText="认证工序排序" Visible="false" />
                    <asp:BoundField DataField="PRD_RouteOrder" SortExpression="PRD_RouteOrder" HeaderText="认证路线排序"
                        Visible="False"></asp:BoundField>
                    <asp:BoundField HeaderText="班次" />
                    <asp:BoundField HeaderText="作业员" Visible="true" />
                    <asp:BoundField HeaderText="设备" ItemStyle-Width="45pt" />
                    <asp:BoundField HeaderText="进站时间" />
                    <asp:BoundField HeaderText="出站时间" />
                    <asp:BoundField HeaderText="投入数量" />
                    <asp:BoundField HeaderText="合格数量" />
                    <asp:BoundField HeaderText="合格率" />
                    <asp:TemplateField HeaderText="不良品类型及数量">
                        <ItemTemplate >
                            <asp:GridView ID="gridviewc" 
                                runat="server" AutoGenerateColumns="True" EmptyDataText="无" CssClass="cg" CellSpacing="0" BorderWidth="0"
                                CellPadding="0"  GridLines="None"  BackColor="White" Width="100%" CaptionAlign="NotSet">
                                  <RowStyle CssClass="GridViewRowStyle" HorizontalAlign="Center" VerticalAlign="Top" 
                    Font-Size="Small" />
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle CssClass="GridViewHead" HorizontalAlign="Center" VerticalAlign="Top" />
                <FooterStyle CssClass="GridViewFooterStyle" />
                                <Columns>
                             
                                </Columns>
                            </asp:GridView>
                        </ItemTemplate>
                        <ItemStyle VerticalAlign="Top" />
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="废品总数" ItemStyle-Width="38pt" />
                    <asp:BoundField DataField="PBC_ID" HeaderText="PCBID">
                        <HeaderStyle CssClass="hide" />
                        <ItemStyle CssClass="hide" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </fieldset>
    </div>
    <div style="text-align: left; width: 1024px; font-size: small;">
        <fieldset>
            <legend>统计信息</legend>
            <asp:GridView ID="GridView3" runat="server" class="table_border" AutoGenerateColumns="False"
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
    <div style="text-align: left; width: 100%; font-size: small;">
        <fieldset>
            <legend>备注</legend>
            <table style="width: 100%;border: 0">
                <tr>
                    <td style="width:80%" rowspan ="4">
                        <asp:TextBox ID="TextBox1" runat="server" Height="50px" style="font-size:12px;"  TextMode="MultiLine" Width="98%"></asp:TextBox>
                    </td>
                    <td style="width:20%" >
                        <asp:Image ID="TempImage" runat="server" Height="50px" Width="98%" />
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
   
    <!--endprint-->
    <asp:Button ID="Button1" runat="server" OnClientClick="preview()" CssClass="Button02"
        Text="打印" Width="58px" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button2" runat="server" CssClass="Button02" OnClick="Button1_Click"
        Text="返回" Width="55px" />
    </form>
</body>
</html>
