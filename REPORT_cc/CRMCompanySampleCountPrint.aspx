<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeFile="CRMCompanySampleCountPrint.aspx.cs" Inherits="PurchasingMgt_CRMCompanySampleCountPrint" %>

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
<body style="text-align: center; width: 1024px; margin: 0 auto; background-color: #FFFFFF;
    background-image: none">
    <form id="form1" runat="server" width="1024px" >
    <!--startprint-->
    <p style="font-size: 25px;">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/share.jpg" Height="39px" Width="67px" />
            <asp:Label ID="Label6" runat="server" Text="乐山希尔电子 — 项目完成情况汇总统计表" Font-Size="25px"></asp:Label>
           <asp:Label ID="label_Num" runat="server" Visible="false"/>
         </p>
    <div style="text-align: left;">
            <table border="0" cellspacing="1" width="100%" style="text-align: center">
                <tr>
                    <td align="center" valign="top">
                        <asp:Label ID="Label1" runat="server" Text="统计时间：" Font-Size="15px"></asp:Label>
                        &nbsp;
                        <asp:Label ID="Label5" runat="server" Text="从" Font-Size="15px"></asp:Label>
                        &nbsp;
                        <asp:Label ID="Labelstart" runat="server" Text="Labelstart" Font-Size="15px"></asp:Label>
                        &nbsp;
                        <asp:Label ID="Label2" runat="server" Text="至" Font-Size="15px"></asp:Label>
                        &nbsp;
                        <asp:Label ID="Labelend" runat="server" Text="Labelend" Font-Size="15px"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td >
                        <asp:GridView ID="Gridview_OAInfo" runat="server" CssClass="GridViewStyle" Width="100%" AutoGenerateColumns="False" GridLines="None" 
                            ShowFooter="true" OnRowDataBound="Gridview_OAInfo_RowDataBound1">
                        <RowStyle CssClass="GridViewRowStyle"/>
                        <HeaderStyle CssClass="GridViewHead" Font-Bold="True" Font-Size="15px" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                        <asp:TemplateField HeaderText="序号">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1%>
                            </ItemTemplate>
                        </asp:TemplateField>
                             <asp:BoundField DataField="PT_Name" HeaderText="产品型号" 
                            SortExpression="PT_Name" />
                        <asp:BoundField DataField="Client_Name" HeaderText="客户名称" SortExpression="Client_Name">
                         
                        </asp:BoundField>
                        <asp:BoundField DataField="CRMCS_MakeMan" HeaderText="销售员" SortExpression="CRMCS_MakeMan">
                        </asp:BoundField>
                         <asp:BoundField DataField="ProductNum" HeaderText="数量" SortExpression="ProductNum">
                        </asp:BoundField>
                             <asp:BoundField DataField="CRMCSS_Time" HeaderText="发送日期 " SortExpression="CRMCSS_Time" DataFormatString="{0:yyyy-MM-dd}">
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
        Text="打印" Width="70px" OnClick="Button_Click" />
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:Button ID="Button3" runat="server" CssClass="Button02" OnClick="Button_Excel"
        Text="导出Excel" Width="70px" />

    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button2" runat="server" CssClass="Button02" OnClick="Button1_Click"
        Text="返回" Width="70px" />


    </form>
</body>
</html>


