<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SaleAnalysisPrint.aspx.cs" Inherits="REPORT_cc_SaleAnalysisPrint"  Title="销售分析表打印"  EnableEventValidation="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="Stylesheet" href="../css/style.css" />
      <script type="text/javascript" src="../JS/jquery-1.10.2.min.js"></script>
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
    <p style="font-size: 25px;">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/share.jpg" Height="39px" Width="67px" />
            <asp:Label ID="Label6" runat="server" Text="乐山希尔电子 — 销售分析表" Font-Size="25px"></asp:Label>
    </p>
    <div style="text-align: left;">
            <table border="0" cellspacing="1" width="100%" style="text-align: center">
                <tr>
                    <td align="center" valign="top">
                        <asp:Label ID="Label1" runat="server" Text="统计年份：" Font-Size="15px"></asp:Label>
                        &nbsp;
                        <asp:Label ID="Labelyear" runat="server" Text="Labelyear" Font-Size="15px"></asp:Label>
                        &nbsp;
                        <asp:Label ID="Label2" runat="server" Text="年" Font-Size="15px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center" valign="top" height="13px"></td>
                </tr>
                <tr>
                    <td >
                        <asp:GridView ID="Grid_Detail" runat="server" CssClass="GridViewStyle" Width="100%" AutoGenerateColumns="False" GridLines="None"
                        onrowcreated="Grid_Detail_RowCreated" >
                        <RowStyle CssClass="GridViewRowStyle"/>
                        <HeaderStyle CssClass="GridViewHead" Font-Bold="True" Font-Size="15px" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                           <asp:TemplateField HeaderText="序号" HeaderStyle-Width="5%">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1%>
                            </ItemTemplate>
                            <ItemStyle />
                        </asp:TemplateField>
                        <asp:BoundField DataField="CRMCIF_Name" HeaderText="客户名称" SortExpression="CRMCIF_Name">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="daoqi" HeaderText="到期应收货款" SortExpression="daoqi">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="chaoqi1" HeaderText="超期货款" SortExpression="chaoqi1">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="FaMonth1" SortExpression="FaMonth1">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="HuiMonth1" SortExpression="HuiMonth1">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="FaMonth2" SortExpression="FaMonth2">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="HuiMonth2" SortExpression="HuiMonth2">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="FaMonth3" SortExpression="FaMonth3">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="HuiMonth3" SortExpression="HuiMonth3">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="FaMonth4" SortExpression="FaMonth4">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="HuiMonth4" SortExpression="HuiMonth4">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="FaMonth5" SortExpression="FaMonth5">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="HuiMonth5" SortExpression="HuiMonth5">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="FaMonth6" SortExpression="FaMonth6">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="HuiMonth6" SortExpression="HuiMonth6">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="FaMonth7" SortExpression="FaMonth7">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="HuiMonth7" SortExpression="HuiMonth7">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="FaMonth8" SortExpression="FaMonth8">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="HuiMonth8" SortExpression="HuiMonth8">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="FaMonth9" SortExpression="FaMonth9">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="HuiMonth9" SortExpression="HuiMonth9">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="FaMonth10" SortExpression="FaMonth10">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="HuiMonth10" SortExpression="HuiMonth10">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="FaMonth11" SortExpression="FaMonth11">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="HuiMonth11" SortExpression="HuiMonth11">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="FaMonth12" SortExpression="FaMonth12">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="HuiMonth12" SortExpression="HuiMonth12">
                            <ItemStyle />
                        </asp:BoundField>
                        </Columns>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label16" runat="server" Text="没有找到相关记录"></asp:Label>
                        </EmptyDataTemplate>
                    </asp:GridView>
                   </td>
               </tr>
         </table>
    </div>
    <br />
    <div style="text-align: left; width: 100%; font-size: small;">
        <table style="width: 100%;border: 0">
                <tr>
                    <td align="right"  style="width: 42%;">
                        <asp:Label ID="Label3" runat="server" Text="打印人："></asp:Label>
                        <asp:Label ID="Labelpeople" runat="server" Text="Labelpeople"></asp:Label>
                    </td>
                    <td style="width: 15%;"></td>
                    <td >
                        <asp:Label ID="Label4" runat="server" Text="打印时间："></asp:Label>
                        <asp:Label ID="Labeltime" runat="server" Text="Labeltime"></asp:Label>
                    </td>
                </tr>
            </table>
    </div>
   <br />
    <!--endprint-->
    <div style="text-align: left; width: 100%; font-size: small;">
        <table style="width: 100%;border: 0">
        <tr>
            <td style="width: 40%;" align="right">
                <asp:Button ID="Button1" runat="server" OnClientClick="preview()" CssClass="Button02"
                    Text="打印" Width="70px" />
            </td>
            <td style="width: 20%;" align="center">
                <asp:Button ID="Button2" runat="server" CssClass="Button02"
                    Text="导出Excel" Width="70px" onclick="Button2_Click" />
            </td>
            <td>
                <asp:Button ID="Button3" runat="server" CssClass="Button02" OnClick="Button3_Click"
                    Text="返回" Width="70px" />
            </td>
        </tr>
    </table>
    </div>


    </form>
</body>