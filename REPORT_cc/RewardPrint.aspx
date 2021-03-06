﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RewardPrint.aspx.cs" Inherits="REPORT_cc_RewardPrint" Title="人员奖惩表打印" EnableEventValidation="false"%>

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
            <asp:Label ID="Label6" runat="server" Text="乐山希尔电子 — 人员奖惩表" Font-Size="25px"></asp:Label>
    </p>
    <div style="text-align: left;">
            <table border="0" cellspacing="1" width="100%" style="text-align: center">
                <tr>
                    <td align="center" valign="top" height="13px"></td>
                </tr>
                <tr>
                    <td >
                        <asp:GridView ID="Grid_Detail" runat="server" CssClass="GridViewStyle" Width="100%" AutoGenerateColumns="False" GridLines="None">
                        <RowStyle CssClass="GridViewRowStyle"/>
                        <HeaderStyle CssClass="GridViewHead" Font-Bold="True" Font-Size="15px" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                        <asp:TemplateField HeaderText="序号">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1%>
                            </ItemTemplate>
                        </asp:TemplateField>
                            <asp:BoundField DataField="HRDD_ID" HeaderText="人事档案ID" SortExpression="HRDD_ID"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="HRDD_StaffNO" HeaderText="工号" SortExpression="HRDD_StaffNO">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="HRDD_Name" HeaderText="姓名" SortExpression="HRDD_Name">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="BDOS_Name" HeaderText="部门" SortExpression="BDOS_Name">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="HRP_Post" HeaderText="岗位" SortExpression="HRP_Post">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="HRET_EmpType" HeaderText="员工类型" SortExpression="HRET_EmpType">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="HRRewards_ID" HeaderText="奖惩情况ID" ReadOnly="True" SortExpression="HRRewards_ID"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="HRRewards_Type" HeaderText="奖惩类型" SortExpression="HRRewards_Type">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="HRRewards_Money" HeaderText="奖惩金额" SortExpression="HRRewards_Money">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="HRRewards_Agree" HeaderText="批准人" SortExpression="HRRewards_Agree">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField SortExpression="HRRewards_Time" HeaderText="发生时间">
                                <ItemTemplate>
                                    <asp:Label ID="HRRewards_Time" runat="server" Text='<%# Eval("HRRewards_Time","{0:yyyy-MM-dd}") %>'
                                        DataFormatString="{0:yyyy-MM-dd}"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle/>
                            </asp:TemplateField>
                            <asp:TemplateField SortExpression="HRRewards_OkTime" HeaderText="生效时间">
                                <ItemTemplate>
                                    <asp:Label ID="HRRewards_OkTime" runat="server" Text='<%# Eval("HRRewards_OkTime","{0:yyyy-MM-dd}") %>'
                                        DataFormatString="{0:yyyy-MM-dd}"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle/>
                            </asp:TemplateField>
                            <asp:BoundField DataField="HRRewards_Content" HeaderText="奖惩内容" SortExpression="HRRewards_Content">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="HRRewards_Note" HeaderText="备注" SortExpression="HRRewards_Note">
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
