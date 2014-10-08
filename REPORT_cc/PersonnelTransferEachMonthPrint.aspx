<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup ="true" CodeFile="PersonnelTransferEachMonthPrint.aspx.cs" Inherits="REPORT_cc_PersonnelTransferEachMonthPrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type"  content="text/html; charset=utf-8" />
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
<body id="Body1" style="text-align: center; width: 1024px; margin: 0 auto; background-color: #FFFFFF;
    background-image: none" runat="server">
    <form id="form1" runat="server" width="1024px" >
    <!--startprint-->
    <p style="font-size: 25px;">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/share.jpg" Height="39px" Width="67px" />
            <asp:Label ID="Label6" runat="server" Text="乐山希尔电子 —人事流动月报表" Font-Size="25px"></asp:Label>
           <asp:Label ID="label_Num" runat="server" Visible="false"/>
         </p>
    <div style="text-align: left;">
            <table border="0" cellspacing="1" width="100%" style="text-align: center">
                <tr>
                    <td align="center" valign="top">
                        <asp:Label ID="Label1" runat="server" Text="统计时间：" Font-Size="15px" Visible="false"></asp:Label>
                        &nbsp;
                        <asp:Label ID="Label5" runat="server" Text="从" Font-Size="15px" Visible="false"></asp:Label>
                        &nbsp;
                        <asp:Label ID="Labelstart" runat="server" Text="Labelstart" Font-Size="15px" Visible="false"></asp:Label>
                        &nbsp;
                        <asp:Label ID="Label2" runat="server" Text="至" Font-Size="15px" Visible="false"></asp:Label>
                        &nbsp;
                        <asp:Label ID="Labelend" runat="server" Text="Labelend" Font-Size="15px" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center" valign="top" height="13px"></td>
                </tr>
                <tr>
                    <td >
                        <asp:GridView ID="Gridview_OAInfo" runat="server" CssClass="GridViewStyle" Width="100%" AutoGenerateColumns="False" GridLines="None" 
                            OnRowDataBound="Gridview_OAInfo_RowDataBound1"  ShowFooter="false">
                        <RowStyle CssClass="GridViewRowStyle"/>
                        <HeaderStyle CssClass="GridViewHead" Font-Bold="True" Font-Size="15px" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                        <asp:TemplateField HeaderText="序号">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1%>
                            </ItemTemplate>
                           </asp:TemplateField>
                      
                        <asp:BoundField DataField="部门" HeaderText="部门" 
                            SortExpression="部门" />
                        <asp:BoundField DataField="岗位" HeaderText="岗位" SortExpression="岗位">
                         
                        </asp:BoundField>
                        <asp:BoundField DataField="月初人数" HeaderText="月初人数" SortExpression="月初人数">
                        </asp:BoundField>
                         <asp:BoundField DataField="本月人数" HeaderText="本月人数" SortExpression="本月人数">
                        </asp:BoundField>
                         <asp:BoundField DataField="本月新进人数" HeaderText="本月新进人数" SortExpression="本月新进人数">
                        </asp:BoundField>
                         <asp:BoundField DataField="本月离职人数" HeaderText="本月离职人数" SortExpression="本月离职人数">
                        </asp:BoundField>
                         <asp:BoundField DataField="本月调入人数" HeaderText="本月调入人数" SortExpression="本月调入人数">
                        </asp:BoundField>
                         <asp:BoundField DataField="本月调离人数" HeaderText="本月调离人数" SortExpression="本月调离人数" >
                        </asp:BoundField>
                         <asp:BoundField DataField="离职率" HeaderText="离职率" SortExpression="离职率">
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
    <asp:Button ID="Button1" runat="server" OnClientClick="preview()" CssClass="Button02"
        Text="打印" Width="70px" OnClick="Button1_Click" />
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:Button ID="Button3" runat="server" CssClass="Button02" OnClick="Button_Excel"
        Text="导出Excel" Width="70px" />

    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button2" runat="server" CssClass="Button02" OnClick="Button1_Click"
        Text="返回" Width="70px" />


    </form>
</body>
</html>



