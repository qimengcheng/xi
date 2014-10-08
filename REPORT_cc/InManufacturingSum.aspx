<%@ Page Title="" Language="C#" MasterPageFile="~/other/MasterPage.master" AutoEventWireup="true" CodeFile="InManufacturingSum.aspx.cs" Inherits="REPORT_cc_InManufacturingSum"  EnableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/JS/ShortM.js" />
        </Scripts>--%>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

       <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" Visible="true">
                <asp:Label ID="Label5" runat="server"  Visible="false"></asp:Label>
                <fieldset>
                    <legend>在制品数量统计导出</legend>
                    <table style="width: 100%;" align="center">
                        <tr>
                            <td style="width: 20%">
                            </td>
                            <td align="center" style="width: 30%">
                                <asp:Button ID="BtnToExcel" runat="server" CssClass="Button02" Height="24px"
                                     Text="正常产品导出" Width="90px" OnClick="BtnToExcel_Click" />
                            </td>
                            <td align="center" style="width: 30%">
                                <asp:Button ID="BtnToExcelOver" runat="server" CssClass="Button02" Height="24px"
                                     Text="超期产品导出" Width="90px" OnClick="BtnToExcelOver_Click"/>
                            </td>
                            <td style="width: 20%">
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="BtnToExcel" />
            <asp:PostBackTrigger ControlID="BtnToExcelOver" />
        </Triggers>
    </asp:UpdatePanel>
 
    <asp:UpdatePanel ID="UpdatePanel_IQCSum" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_IQCSum" runat="server">
                <fieldset>
                    <legend>在制品数量统计</legend>
                    <asp:GridView ID="Grid1" runat="server" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                        Visible="true" GridLines="None" AllowPaging="True" PageSize="10" UseAccessibleHeader="False">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="WO_ProType" SortExpression="WO_ProType" HeaderText="产品型号"></asp:BoundField>
                            <asp:BoundField DataField="PT_Number" SortExpression="PT_Number" HeaderText="在制品量"></asp:BoundField>
                        </Columns>

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

