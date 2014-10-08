<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QuitWorkAgePrint.aspx.cs" Inherits="REPORT_cc_QuitWorkAgePrint"  Title="人员流失工龄年报表打印"  EnableEventValidation="false"%>

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
            <asp:Label ID="Label6" runat="server" Text="乐山希尔电子 — 人员流失工龄年报表" Font-Size="25px"></asp:Label>
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
                        <asp:BoundField DataField="部门" HeaderText="部门" SortExpression="部门">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="岗位" HeaderText="岗位" SortExpression="岗位">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="试用期内1" SortExpression="试用期内1">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="三至六月1" SortExpression="三至六月1">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="六月至一年1" SortExpression="六月至一年1">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="一至二年1" SortExpression="一至二年1">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="二至五年1" SortExpression="二至五年1">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="五至十年1" SortExpression="五至十年1">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="十年以上1" SortExpression="十年以上1">
                            <ItemStyle />
                        </asp:BoundField>                        
                        <asp:BoundField DataField="试用期内2" SortExpression="试用期内2">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="三至六月2" SortExpression="三至六月2">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="六月至一年2" SortExpression="六月至一年2">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="一至二年2" SortExpression="一至二年2">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="二至五年2" SortExpression="二至五年2">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="五至十年2" SortExpression="五至十年2">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="十年以上2" SortExpression="十年以上2">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="试用期内3" SortExpression="试用期内3">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="三至六月3" SortExpression="三至六月3">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="六月至一年3" SortExpression="六月至一年3">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="一至二年3" SortExpression="一至二年3">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="二至五年3" SortExpression="二至五年3">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="五至十年3" SortExpression="五至十年3">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="十年以上3" SortExpression="十年以上3">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="试用期内4" SortExpression="试用期内4">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="三至六月4" SortExpression="三至六月4">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="六月至一年4" SortExpression="六月至一年4">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="一至二年4" SortExpression="一至二年4">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="二至五年4" SortExpression="二至五年4">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="五至十年4" SortExpression="五至十年4">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="十年以上4" SortExpression="十年以上4">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="试用期内5" SortExpression="试用期内5">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="三至六月5" SortExpression="三至六月5">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="六月至一年5" SortExpression="六月至一年5">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="一至二年5" SortExpression="一至二年5">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="二至五年5" SortExpression="二至五年5">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="五至十年5" SortExpression="五至十年5">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="十年以上5" SortExpression="十年以上5">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="试用期内6" SortExpression="试用期内6">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="三至六月6" SortExpression="三至六月6">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="六月至一年6" SortExpression="六月至一年6">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="一至二年6" SortExpression="一至二年6">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="二至五年6" SortExpression="二至五年6">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="五至十年6" SortExpression="五至十年6">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="十年以上6" SortExpression="十年以上6">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="试用期内7" SortExpression="试用期内7">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="三至六月7" SortExpression="三至六月7">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="六月至一年7" SortExpression="六月至一年7">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="一至二年7" SortExpression="一至二年7">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="二至五年7" SortExpression="二至五年7">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="五至十年7" SortExpression="五至十年7">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="十年以上7" SortExpression="十年以上7">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="试用期内8" SortExpression="试用期内8">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="三至六月8" SortExpression="三至六月8">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="六月至一年8" SortExpression="六月至一年8">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="一至二年8" SortExpression="一至二年8">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="二至五年8" SortExpression="二至五年8">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="五至十年8" SortExpression="五至十年8">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="十年以上8" SortExpression="十年以上8">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="试用期内9" SortExpression="试用期内9">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="三至六月9" SortExpression="三至六月9">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="六月至一年9" SortExpression="六月至一年9">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="一至二年9" SortExpression="一至二年9">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="二至五年9" SortExpression="二至五年9">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="五至十年9" SortExpression="五至十年9">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="十年以上9" SortExpression="十年以上9">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="试用期内10" SortExpression="试用期内10">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="三至六月10" SortExpression="三至六月10">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="六月至一年10" SortExpression="六月至一年10">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="一至二年10" SortExpression="一至二年10">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="二至五年10" SortExpression="二至五年10">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="五至十年10" SortExpression="五至十年10">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="十年以上10" SortExpression="十年以上10">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="试用期内11" SortExpression="试用期内11">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="三至六月11" SortExpression="三至六月11">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="六月至一年11" SortExpression="六月至一年11">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="一至二年11" SortExpression="一至二年11">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="二至五年11" SortExpression="二至五年11">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="五至十年11" SortExpression="五至十年11">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="十年以上11" SortExpression="十年以上11">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="试用期内12" SortExpression="试用期内12">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="三至六月12" SortExpression="三至六月12">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="六月至一年12" SortExpression="六月至一年12">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="一至二年12" SortExpression="一至二年12">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="二至五年12" SortExpression="二至五年12">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="五至十年12" SortExpression="五至十年12">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="十年以上12" SortExpression="十年以上12">
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