﻿<<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SalaryCountIn12MonthsPrint.aspx.cs" Inherits="REPORT_cc_SalaryCountIn12MonthsPrint"  Title="年度薪资分析表打印"  EnableEventValidation="false"%>

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
            <asp:Label ID="Label6" runat="server" Text="乐山希尔电子 — 年度薪资分析表" Font-Size="25px"></asp:Label>
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
                        <asp:BoundField DataField="工时1" SortExpression="工时1">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="人数1" SortExpression="人数1">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="计件工资1" SortExpression="计件工资1">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="计时工资1" SortExpression="计时工资1">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="总应发工资1" SortExpression="总应发工资1">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="工时2" SortExpression="工时2">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="人数2" SortExpression="人数2">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="计件工资2" SortExpression="计件工资2">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="计时工资2" SortExpression="计时工资2">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="总应发工资2" SortExpression="总应发工资2">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="工时3" SortExpression="工时3">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="人数3" SortExpression="人数3">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="计件工资3" SortExpression="计件工资3">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="计时工资3" SortExpression="计时工资3">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="总应发工资3" SortExpression="总应发工资3">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="工时4" SortExpression="工时4">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="人数4" SortExpression="人数4">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="计件工资4" SortExpression="计件工资4">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="计时工资4" SortExpression="计时工资4">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="总应发工资4" SortExpression="总应发工资4">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="工时5" SortExpression="工时5">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="人数5" SortExpression="人数5">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="计件工资5" SortExpression="计件工资5">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="计时工资5" SortExpression="计时工资5">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="总应发工资5" SortExpression="总应发工资5">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="工时6" SortExpression="工时6">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="人数6" SortExpression="人数6">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="计件工资6" SortExpression="计件工资6">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="计时工资6" SortExpression="计时工资6">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="总应发工资6" SortExpression="总应发工资6">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="工时7" SortExpression="工时7">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="人数7" SortExpression="人数7">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="计件工资7" SortExpression="计件工资7">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="计时工资7" SortExpression="计时工资7">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="总应发工资7" SortExpression="总应发工资7">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="工时8" SortExpression="工时8">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="人数8" SortExpression="人数8">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="计件工资8" SortExpression="计件工资8">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="计时工资8" SortExpression="计时工资8">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="总应发工资8" SortExpression="总应发工资8">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="工时9" SortExpression="工时9">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="人数9" SortExpression="人数9">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="计件工资9" SortExpression="计件工资9">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="计时工资9" SortExpression="计时工资9">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="总应发工资9" SortExpression="总应发工资9">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="工时10" SortExpression="工时10">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="人数10" SortExpression="人数10">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="计件工资10" SortExpression="计件工资10">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="计时工资10" SortExpression="计时工资10">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="总应发工资10" SortExpression="总应发工资10">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="工时11" SortExpression="工时11">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="人数11" SortExpression="人数11">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="计件工资11" SortExpression="计件工资11">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="计时工资11" SortExpression="计时工资11">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="总应发工资11" SortExpression="总应发工资11">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="工时12" SortExpression="工时12">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="人数12" SortExpression="人数12">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="计件工资12" SortExpression="计件工资12">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="计时工资12" SortExpression="计时工资12">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="总应发工资12" SortExpression="总应发工资12">
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