<%@ Page Title="备件领用统计表" Language="C#" MasterPageFile="~/Other/MasterPage.master"
    AutoEventWireup="true" CodeFile="Spare.aspx.cs" Inherits="REPORT_cc_Spare" %>

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
                    <legend>备件领用检索栏</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 10%; height: 15px;" align="center">
                                <asp:Label ID="Label1" runat="server" Text="备件名称："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 15px;">
                                <asp:TextBox ID="sparename" runat="server" Width="155px"></asp:TextBox>
                            </td>
                            <td style="width: 10%; height: 15px;" align="center">
                                <asp:Label ID="Label3" runat="server" Text="备件型号："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 15px;">
                                <asp:TextBox ID="sparemodel" runat="server" Width="155px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label6" runat="server" Text="使用设备编号："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="equipno" runat="server" Width="155px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                    <asp:Label ID="Label111" runat="server" Text="统计时间："></asp:Label>
                                </td>
                                </td>
                                <td>
                                    <asp:TextBox ID="startime" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',false)"
                                        DataFormatString="{0:yyyy-MM-dd}" Width="155px"></asp:TextBox>
                                </td>
                                <td align="center">
                                    <asp:Label ID="Label112" runat="server" Text="至"></asp:Label>
                                </td>
                                <td >
                                    <asp:TextBox ID="endtime" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',false)"
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
                    <legend>备件领用统计列表</legend>
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
                            <asp:BoundField DataField="IMMBD_MaterialName" HeaderText="备件名称" SortExpression="IMMBD_MaterialName">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_MaterialCode" HeaderText="备件型号" SortExpression="IMMBD_MaterialCode">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="EMSAUS_UseAmount" HeaderText="领取数量" SortExpression="EMSAUS_UseAmount">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="EI_No" HeaderText="使用设备编号" SortExpression="EI_No">
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
