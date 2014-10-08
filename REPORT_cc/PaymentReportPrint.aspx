<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/REPORT_cc/PaymentReportPrint.aspx.cs" Inherits="Laputa_PaymentReport" 
    EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../css/style.css" rel="stylesheet" />
        <script type="text/javascript"  src="../My97DatePicker/WdatePicker.js"></script>
    <style type="text/css">
        .auto-style4 {
            width: 84px;
        }
        .auto-style10 {
            width: 56px;
        }
        .auto-style11 {
            width: 131px;
        }
        .auto-style12 {
            width: 76px;
        }
        .auto-style13 {
            width: 153px;
        }
        .auto-style14 {
            width: 54px;
        }
        .auto-style15 {
            width: 183px;
        }
        .auto-style16 {
            width: 172px;
        }
        .auto-style17 {
            width: 36px;
        }
        .auto-style19 {
            width: 250px;
        }
        .auto-style22 {
            width: 106px;
        }
        .auto-style24 {
            width: 77px;
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
<body>
    <form id="form1" runat="server">
    <div>
            <asp:Panel ID="Panel1" runat="server" Visible="False">
                <fieldset>
                    <legend> 付款月计划检索
             
                
                    </legend>
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 73px" > 供应商名称:</td>
                            <td style="width: 110px" >
                                <asp:TextBox ID="TextBox1" runat="server" Width="90%"></asp:TextBox>
                            </td>
                            <td style="width: 22px" > &nbsp;</td>
                            <td style="width: 63px" >
                                <asp:Button ID="Search" runat="server" CssClass="Button02" OnClick="Search_Click" Text=" 检索 " Width="66px" />
                            </td>
                            <td style="width: 45px" > 
                                &nbsp;</td>
                            <td style="width: 125px">
                                <asp:Button ID="Button4" runat="server" CssClass="Button02" OnClick="print" Text="打印报表" Width="70px" />
                            </td>
                            <td style="width: 127px">
                                <asp:Button ID="reset" runat="server" CssClass="Button02" OnClick="reset_Click" Text=" 重置" Width="66px" />
                            </td>
                            <td >
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
    </div>
        <div>
            <asp:Panel ID="Panel2" runat="server" Visible="False">
         
            </asp:Panel>
        </div>
        <div>
                <!--startprint-->
            <h1>
                <asp:Image ID="Image1" runat="server" Height="39px" ImageUrl="~/images/share.jpg" Width="68px" />
                乐山希尔电子- 到期货款信息报表</h1>
            <asp:Panel ID="Panel3" runat="server" Visible="True">
                <table style="width: 100%">
                    <tr>
                        <td class="auto-style19">&nbsp;</td>
                        <td class="auto-style4">统计时间:</td>
                        <td class="auto-style24">
                            &nbsp;</td>
                        <td class="auto-style17">到现在</td>
                        <td class="auto-style22">
                            &nbsp;</td>
                        <td>&nbsp;</td>
                        <td></td>
                    </tr>
                </table>
         <fieldset><legend>
             到期货款信息报表</legend>
             
           <asp:GridView ID="GridView3" runat="server" CssClass="GridViewStyle"  AllowPaging="True" AutoGenerateColumns="False" PageSize="10" DataKeyNames="PMSI_ID,PMPO_PayWay"
                                  GridLines="None" EmptyDataText=" 没有相关记录 "  OnPageIndexChanging="GridView3_PageIndexChanging" EnableModelValidation="True" OnRowDataBound="GridView3_RowDataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="PMSI_ID" HeaderText="PMSI_ID" Visible="True"  >
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PMSI_SupplyName" HeaderText="供应商名称" Visible="true"  />
                            <asp:BoundField DataField="PMSI_Material" HeaderText="物料名称" Visible="true"  />
                            <asp:BoundField DataField="PMPO_PayWay" HeaderText="付款方式" Visible="true"  />
                            <asp:BoundField DataField="TotalDebt" HeaderText="总欠款" />
                            <asp:BoundField DataField="AlreadyPay" HeaderText="已付款" Visible="true"  />
                           


                           
                            <asp:BoundField DataField="PayRate" HeaderText="付款率" />
                           


                           


                           
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第<asp:Label ID="lblPageIndex" runat="server" Text='<%# ((GridView) Container.Parent.Parent).PageIndex + 1 %>' />
                                        页 共 <asp:Label ID="lblPageCount" runat="server" Text='<%# ((GridView) Container.Parent.Parent).PageCount %>' />
                                        页
                                        <asp:LinkButton ID="btnFirst" runat="server" CausesValidation="False" CommandArgument="First"
                                                        CommandName="Page" Text="首页 " />
                                        <asp:LinkButton ID="btnPrev" runat="server" CausesValidation="False" CommandArgument="Prev"
                                                        CommandName="Page" Text="上一页 " />
                                        <asp:LinkButton ID="btnNext" runat="server" CausesValidation="False" CommandArgument="Next"
                                                        CommandName="Page" Text="下一页 " />
                                        <asp:LinkButton ID="btnLast" runat="server" CausesValidation="False" CommandArgument="Last"
                                                        CommandName="Page" Text="尾页 " />
                                        <asp:TextBox ID="textbox" runat="server" Width="20px"></asp:TextBox>
                                        <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                                        CommandName="Page" Text="GO" /><!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
                                    </td>
                                </tr>
                            </table>
                        </PagerTemplate>
                    </asp:GridView>
         </fieldset>
            </asp:Panel>
            <div>
                <table style="width: 100%">
                    <tr>
                        <td class="auto-style15"></td>

                        <td class="auto-style14">&nbsp;</td>

                        <td class="auto-style10">打印人:</td>

                        <td class="auto-style11">
                            <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                        </td>

                        <td class="auto-style12">打印时间:</td>

                        <td class="auto-style13">
                            <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                        </td>

                        <td class="auto-style16">&nbsp;</td>

                        <td>&nbsp;</td>

                    </tr>
                    </table>
                <!--endprint-->
                    <table style="width: 100%">
                    <tr>
                        <td class="auto-style15">&nbsp;</td>

                        <td class="auto-style14">
                                <asp:Button ID="Button2" runat="server" CssClass="Button02" Height="24px" Text="打印" OnClientClick="preview()"   Width="70px" />
                            </td>

                        <td class="auto-style10">&nbsp;</td>

                        <td class="auto-style11">
                            &nbsp;</td>

                        <td class="auto-style12">
                                <asp:Button ID="ToExcel" runat="server" CssClass="Button02" Height="24px" OnClick="ToExcel_Click" Text="导出Excel" Width="70px" />
                            </td>

                        <td class="auto-style13">
                            &nbsp;</td>

                        <td class="auto-style16">
                                <asp:Button ID="back" runat="server" CssClass="Button02" Height="24px" OnClick="back_Click" Text="返回"   Width="70px" />
                            </td>

                        <td>&nbsp;</td>

                    </tr>
                </table>
            </div>
                
        </div>
    </form>
</body>
</html>


 

   

