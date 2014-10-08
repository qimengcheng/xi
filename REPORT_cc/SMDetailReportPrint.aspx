<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SMDetailReportPrint.aspx.cs" Inherits="REPORT_cc_SMDetailReportPrint" Title="客户明细账打印" EnableEventValidation="false"%>

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
            <asp:Label ID="Label6" runat="server" Text="乐山希尔电子 —"  Font-Size="25px"></asp:Label>
            <asp:Label ID="LabelName" runat="server" Font-Size="25px"></asp:Label>
            <asp:Label ID="Label13" runat="server" Text="明细账" Font-Size="25px"></asp:Label>
    </p>
    <div style="text-align: left;">
            <table border="0" cellspacing="1" width="100%" style="text-align: center">
                <tr>
                    <td align="center" valign="top" style="width:50%"  colspan="3">
                        <asp:Label ID="Label1" runat="server" Text="发货时间：" Font-Size="15px"></asp:Label>
                        &nbsp;
                        <asp:Label ID="Label5" runat="server" Text="从" Font-Size="15px"></asp:Label>
                        &nbsp;
                        <asp:Label ID="Labelstart" runat="server" Text="Labelstart" Font-Size="15px"></asp:Label>
                        &nbsp;
                        <asp:Label ID="Label2" runat="server" Text="至" Font-Size="15px"></asp:Label>
                        &nbsp;
                        <asp:Label ID="Labelend" runat="server" Text="Labelend" Font-Size="15px"></asp:Label>
                    </td>
                    <td align="center" valign="top"  colspan="3">
                        <asp:Label ID="Label7" runat="server" Text="回款时间：" Font-Size="15px"></asp:Label>
                        &nbsp;
                        <asp:Label ID="Label8" runat="server" Text="从" Font-Size="15px"></asp:Label>
                        &nbsp;
                        <asp:Label ID="Label9" runat="server" Text="Label9" Font-Size="15px"></asp:Label>
                        &nbsp;
                        <asp:Label ID="Label10" runat="server" Text="至" Font-Size="15px"></asp:Label>
                        &nbsp;
                        <asp:Label ID="Label11" runat="server" Text="Label11" Font-Size="15px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center" valign="top" height="13px" colspan="6"></td>
                </tr>
                <tr>
                    <td style="width:20%;"></td>
                    <td style="width:20%;" align="right"><asp:Label ID="Label12" runat="server" Text="应收帐款：" Font-Size="15px"></asp:Label></td>
                    <td style="width:10%;" align="left"><asp:Label ID="Labelpay" runat="server" Text="" Font-Size="15px"></asp:Label></td>
                    <td style="width:10%;" align="right"><asp:Label ID="Label14" runat="server" Text="账期：" Font-Size="15px"></asp:Label></td>
                    <td style="width:10%;" align="left"><asp:Label ID="Labeltime11" runat="server" Text="" Font-Size="15px"></asp:Label></td>
                    <td ></td>
                </tr>
                <tr>
                    <td colspan="6">
                        <asp:GridView ID="Grid_Detail" runat="server" CssClass="GridViewStyle" Width="100%" AutoGenerateColumns="False" GridLines="None"
                        onrowcreated="Grid_Detail_RowCreated" onrowdatabound="Grid_Detail_RowDataBound" OnDataBound="Grid_Detail_DataBound" DataKeyNames="SMOD_ID">
                        <RowStyle CssClass="GridViewRowStyle"/>
                        <HeaderStyle CssClass="GridViewHead" Font-Bold="True" Font-Size="15px" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                        <asp:BoundField DataField="SMOD_ID" HeaderText="发货ID" SortExpression="SMOD_ID" Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMOD_Time" HeaderText="发货时间" SortExpression="SMOD_Time">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCIF_Name" HeaderText="客户名称" SortExpression="CRMCIF_Name">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="PT_Name" HeaderText="产品型号" SortExpression="PT_Name">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="PT_Note" HeaderText="产品备注" SortExpression="PT_Note">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMOD_Num" HeaderText="送货数量" SortExpression="SMOD_Num">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMOD_ReturnNum" HeaderText="退货数量" SortExpression="SMOD_ReturnNum">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMSOD_UnitPrice" HeaderText="订单单价" SortExpression="SMSOD_UnitPrice">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="TotalOrderMoney" HeaderText="发货总额" SortExpression="TotalOrderMoney">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMOD_PayMoney" HeaderText="已付款金额" SortExpression="SMOD_PayMoney">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField> 
                                 <ItemTemplate> 
                                        <asp:GridView ID="GridView3" runat="server"  Width="100%" AutoGenerateColumns="False" ShowHeader="false" Height="100%" 
                                        CssClass="GridViewStyle" GridLines="None">
                                            <RowStyle CssClass="GridViewRowStyle"/>
                                                <Columns> 
                                                    <asp:BoundField DataField="SMCB_BillTime" HeaderText="开票日期"> 
                                                        <ItemStyle width="25%"/>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="SMCB_BillNum" HeaderText="开票数量"> 
                                                        <ItemStyle width="25%"/>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="SMCB_BillPrice" HeaderText="开票单价">   
                                                        <ItemStyle width="25%"/>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="TotalBillMoney" HeaderText="金额">   
                                                        <ItemStyle width="25%"/>
                                                    </asp:BoundField>    
                                                </Columns> 
                                        </asp:GridView>              
                                   </ItemTemplate> 
                                   <ItemStyle/>
                             </asp:TemplateField>
                             <asp:TemplateField> 
                                 <ItemTemplate>              
                                   </ItemTemplate> 
                                   <ItemStyle />
                             </asp:TemplateField>
                             <asp:TemplateField> 
                                 <ItemTemplate>              
                                   </ItemTemplate> 
                                   <ItemStyle/>
                             </asp:TemplateField>
                             <asp:TemplateField> 
                                 <ItemTemplate>              
                                   </ItemTemplate> 
                                   <ItemStyle/>
                             </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label16" runat="server" Text="没有找到相关记录"></asp:Label>
                        </EmptyDataTemplate>
                    </asp:GridView>
                   </td>
               </tr>
               <tr>
                    <td align="center" valign="top" height="13px" colspan="6"></td>
                </tr>
                <tr>
                    <td colspan="6">
                        <asp:GridView ID="GridView1" runat="server" CssClass="GridViewStyle" Width="100%" AutoGenerateColumns="False" GridLines="None">
                        <RowStyle CssClass="GridViewRowStyle"/>
                        <HeaderStyle CssClass="GridViewHead" Font-Bold="True" Font-Size="15px" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                        <asp:BoundField DataField="SMCP_PaymentTime" HeaderText="回款时间" SortExpression="SMCP_PaymentTime">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMCP_PaymentMoney" HeaderText="回款金额" SortExpression="SMCP_PaymentMoney">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMCP_Remark" HeaderText="备注" SortExpression="SMCP_Remark">
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
   
    <!--endprint-->
    <div style="text-align: left; width: 100%; font-size: small;">
        <table style="width: 100%;border: 0">
        <tr>
            <td style="width: 30%;" align="right">
                <asp:Button ID="Button1" runat="server" OnClientClick="preview()" CssClass="Button02"
                    Text="打印" Width="70px" />
            </td>
            <td style="width: 20%;" align="right">
                <asp:Button ID="Button2" runat="server" CssClass="Button02"
                    Text="明细账导出Excel" Width="110px" onclick="Button2_Click" />
            </td>
            <td style="width: 20%;" align="left">
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button4" runat="server" CssClass="Button02"
                    Text="借方回款导出Excel" Width="110px" onclick="Button4_Click" />
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
