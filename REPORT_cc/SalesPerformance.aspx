<%@ Page Title="销售业绩一览表" Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true" CodeFile="SalesPerformance.aspx.cs" Inherits="REPORT_cc_SalesPerformance" %>

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
                    <legend>检索栏</legend>
                    <table style="width: 100%;">
                    <tr style="height: 16px;">
                                <td align="center" style="width:13%;">
                                </td>
                                <td style="width:15%;">
                                </td>
                                <td align="center" style="width:15%;">
                                    <asp:DropDownList ID="DropDownList1" runat="server" Height="20px" >
                                        <asp:ListItem Text="区域名称" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="客户名称" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="业务员" Value="3"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:Label ID="Label3" runat="server" Text="："></asp:Label>
                                </td>
                                <td style="width:20%;">
                                    <asp:TextBox ID="TextBox2" runat="server" Width="155px"></asp:TextBox>
                                </td>
                                <td align="center" style="width:10%;">
                                </td>
                                <td style="width:20%;">
                                </td>
                        </tr>
                        <tr>
                             <td >
                             </td>
                        <td align="center" colspan="2">
                            <asp:Button ID="BtnSearch" runat="server" CssClass="Button02" Height="24px" Text="检索"
                                Width="70px" OnClick="BtnSearch_Click" />
                        </td>
                        <td align="left" colspan="2">
                            <asp:Button ID="BtnPrint" runat="server" CssClass="Button02" Height="24px" Text="打印报表" Width="90px" OnClick="BtnPrint_Click" ToolTip="点击此处,跳转打印页面。"/>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="BtnReset" runat="server" CssClass="Button02" Height="24px" Text="重置"
                                    Visible="true" Width="70px" OnClick="BtnReset_Click"/></td>
                        <td align="left" >
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
                    <legend>销售业绩一览表</legend>
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
                            <asp:BoundField DataField="CRMRBI_Name" HeaderText="区域名称" SortExpression="CRMRBI_Name">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCIF_Name" HeaderText="客户名称" SortExpression="CRMCIF_Name">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCIF_SalesMan" HeaderText="业务员" SortExpression="CRMCIF_SalesMan">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="totalzonge" HeaderText="客户总额" SortExpression="totalzonge">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="totaldaoqi" HeaderText="到期贷款" SortExpression="totaldaoqi">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="totalchaoqi1" HeaderText="超期1个月" SortExpression="totalchaoqi1">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="totalchaoqi2" HeaderText="超期2个月" SortExpression="totalchaoqi2">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="totalchaoqi3" HeaderText="超期3个月" SortExpression="totalchaoqi3">
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
