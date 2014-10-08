<%@ Page Title="订单完成情况统计表" Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true" CodeFile="SalesOrder.aspx.cs" Inherits="REPORT_cc_SalesOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script language="javascript" type="text/javascript">
    </script>
    <asp:UpdatePanel ID="UpdatePanel_Search" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Search" runat="server">
                <fieldset>
                    <legend>销售订单检索栏</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 13%" align="center">
                                <asp:Label ID="Label2" runat="server" Text="客户订单号："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TextBox3" runat="server" Width="155px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label1" runat="server" Text="客户名称："></asp:Label>
                            </td>
                            <td style="width: 20%" colspan="3">
                                <asp:TextBox ID="TextBox1" runat="server" Width="430px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 13%; height: 15px;" align="center">
                                <asp:Label ID="Label6" runat="server" Text="公司订单号："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 15px;">
                                <asp:TextBox ID="TextBox2" runat="server" Width="155px"></asp:TextBox>
                            </td>
                            <td style="width: 10%; height: 15px;" align="center">
                                <asp:Label ID="Label3" runat="server" Text="产品型号："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 15px;">
                                <asp:TextBox ID="TextBox4" runat="server" Width="155px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label4" runat="server" Text="发货情况："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TextBox5" runat="server" Width="155px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                    <asp:Label ID="Label111" runat="server" Text="下单时间："></asp:Label>
                                </td>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox6" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',false)"
                                        DataFormatString="{0:yyyy-MM-dd}" Width="155px"></asp:TextBox>
                                </td>
                                <td align="center">
                                    <asp:Label ID="Label112" runat="server" Text="至"></asp:Label>
                                </td>
                                <td >
                                    <asp:TextBox ID="TextBox7" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',false)"
                                        DataFormatString="{0:yyyy-MM-dd}" Width="155px"></asp:TextBox>
                                </td>
                                <td></td>
                                <td></td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                    <asp:Label ID="Label5" runat="server" Text="交货时间："></asp:Label>
                                </td>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox8" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',false)"
                                        DataFormatString="{0:yyyy-MM-dd}" Width="155px"></asp:TextBox>
                                </td>
                                <td align="center">
                                    <asp:Label ID="Label7" runat="server" Text="至"></asp:Label>
                                </td>
                                <td >
                                    <asp:TextBox ID="TextBox9" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',false)"
                                        DataFormatString="{0:yyyy-MM-dd}" Width="155px"></asp:TextBox>
                                </td>
                                <td></td>
                                <td></td>
                        </tr>
                        <tr>
                        <td align="right" colspan="2">
                            <asp:Button ID="BtnSearch" runat="server" CssClass="Button02" Height="24px" Text="检索"
                                Width="70px" OnClick="BtnSearch_Click" />
                        </td>
                        <td align="center" colspan="2">
                            <asp:Button ID="BtnPrint" runat="server" CssClass="Button02" Height="24px" Text="打印报表" Width="90px" OnClick="BtnPrint_Click" ToolTip="点击此处,跳转打印页面。"/>
                        </td>
                        <td align="left" colspan="2">
                            <asp:Button ID="BtnReset" runat="server" CssClass="Button02" Height="24px" Text="重置"
                                Visible="true" Width="70px" OnClick="BtnReset_Click"/>
                        </td>
                    </tr>
                    </table>
                        
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

<asp:UpdatePanel ID="UpdatePanel_Grid" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Grid" runat="server">
                <fieldset>
                    <legend>订单完成情况统计表</legend>
                    <asp:GridView ID="Grid_Detail" runat="server" AllowSorting="True" PageSize="20" AutoGenerateColumns="False" CssClass="GridViewStyle" Width="100%" 
                        AllowPaging="true"  GridLines="None" OnPageIndexChanging="Grid_Detail_PageIndexChanging">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                        <asp:TemplateField HeaderText="序号">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1%>
                            </ItemTemplate>
                        </asp:TemplateField>
                            <asp:BoundField DataField="SMSO_ComOrderNum" HeaderText="公司订单号" SortExpression="SMSO_ComOrderNum">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMSO_CusOrderNum" HeaderText="客户订单号" SortExpression="SMSO_CusOrderNum">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCIF_Name" HeaderText="客户名称" SortExpression="CRMCIF_Name">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCIF_SalesMan" HeaderText="业务员" SortExpression="CRMCIF_SalesMan">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="PT_Name" HeaderText="产品型号" SortExpression="PT_Name">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="PT_Note" HeaderText="产品备注" SortExpression="PT_Note">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMSOD_UnitPrice" HeaderText="单价" SortExpression="SMSOD_UnitPrice">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMSOD_Mount" HeaderText="订单数量" SortExpression="SMSOD_Mount">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMSOD_DelMount" HeaderText="发货数量" SortExpression="SMSOD_DelMount">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="OrderMoney" HeaderText="发货总金额" SortExpression="OrderMoney">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMSO_PlaceOrderTime" HeaderText="下单日期" SortExpression="SMSO_PlaceOrderTime">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMSOD_DelCondition" HeaderText="发货情况" SortExpression="SMSOD_DelCondition">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMOD_Time" HeaderText="交货日期" SortExpression="SMOD_Time">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMOD_SalesReturn" HeaderText="退货" SortExpression="SMOD_SalesReturn">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMOD_Exchange" HeaderText="换货" SortExpression="SMOD_Exchange">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMRC_ReturnNum" HeaderText="退货数量" SortExpression="SMRC_ReturnNum">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMRC_MakeTime" HeaderText="退货时间" SortExpression="SMRC_MakeTime">
                                <ItemStyle />
                            </asp:BoundField>
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第&nbsp<asp:Label ID="lblPageIndex" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                        页 共&nbsp<asp:Label ID="lblPageCount" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageCount  %>" />
                                        页
                                        <asp:LinkButton ID="btnFirst" runat="server" CausesValidation="False" CommandArgument="First"
                                            CommandName="Page" Text="首页" />
                                        <asp:LinkButton ID="btnPrev" runat="server" CausesValidation="False" CommandArgument="Prev"
                                            CommandName="Page" Text="上一页" />
                                        <asp:LinkButton ID="btnNext" runat="server" CausesValidation="False" CommandArgument="Next"
                                            CommandName="Page" Text="下一页" />
                                        <asp:LinkButton ID="btnLast" runat="server" CausesValidation="False" CommandArgument="Last"
                                            CommandName="Page" Text="尾页" />
                                        <asp:TextBox ID="textbox" runat="server" Width="20px"></asp:TextBox>
                                        <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                            CommandName="Page" Text="GO" />
                                    </td>
                                </tr>
                            </table>
                        </PagerTemplate>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label16" runat="server" Text="没有找到相关记录"></asp:Label>
                        </EmptyDataTemplate>
                        <EditRowStyle BackColor="white" />
                    </asp:GridView>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>



</asp:Content>
