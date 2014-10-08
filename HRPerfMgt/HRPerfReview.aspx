<%@ Page Title="" Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true"
    CodeFile="HRPerfReview.aspx.cs" Inherits="HRPerfMgt_HRPerfReview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
    <style type="text/css">
        .hidden
        {
            display: none;
        }
    </style>
    <asp:UpdatePanel ID="UpdatePanel_SearchEmployee" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_SearchEmployee" runat="server" Visible="true">
                <fieldset>
                    <legend>
                        <asp:Label ID="LblTheSet2" runat="server" Text=""></asp:Label>&nbsp 检索条件</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label11" runat="server" CssClass="STYLE2" Text="员工编号：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:TextBox ID="TxtSearchStaffNO" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label12" runat="server" CssClass="STYLE2" Text="姓名：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:TextBox ID="TxtSearchName" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label7" runat="server" CssClass="STYLE2" Text="年份：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:DropDownList ID="DropDownList3" runat="server" ToolTip="单击选择" AutoPostBack="true">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label8" runat="server" CssClass="STYLE2" Text="月份：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:DropDownList ID="DropDownList4" runat="server" ToolTip="单击选择">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td align="center" style="width: 10%">
                                <asp:Label ID="Label13" runat="server" CssClass="STYLE2" Enabled="False" Text="部门："></asp:Label>
                            </td>
                            <td align="left" style="width: 15%">
                                <asp:DropDownList ID="DdlSearchDep" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DdlSearchDep_SelectedIndexChanged"
                                    ToolTip="单击选择">
                                </asp:DropDownList>
                            </td>
                            <td align="center" style="width: 10%">
                                <asp:Label ID="Label14" runat="server"  Enabled="False" Text="岗位："></asp:Label>
                            </td>
                            <td align="left" style="width: 15%">
                                <asp:DropDownList ID="DdlSearchPost" runat="server" ToolTip="单击选择">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Label ID="LblStateForGrid_Type" runat="server" Text="检索前" Visible="false"></asp:Label>
                                <asp:Label ID="Label2" runat="server" Text="" Visible="false"></asp:Label>
                            </td>
                            <td align="left" colspan="2">
                                <asp:Button ID="BtnSearchEmployee" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="BtnSearchEmployee_Click" Text="检索" Width="70px" />
                            </td>
                            <td>
                            </td>
                            <td align="left" colspan="3">
                                <asp:Button ID="Button1" runat="server" CausesValidation="False" CssClass="Button02"
                                    Height="24px" OnClick="BtnReset_Click" Text="重置" Visible="true" Width="70px" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="8">
                                <fieldset>
                                    <legend>员工信息列表</legend>
                                    <asp:GridView ID="Grid_Detail" runat="server" AllowPaging="True" AllowSorting="True"
                                        AutoGenerateColumns="False" CssClass="GridViewStyle" DataKeyNames="HRPD_ID" GridLines="None"
                                        OnDataBound="Grid_Detail_DataBound" OnPageIndexChanging="Grid_Detail_PageIndexChanging"
                                        OnRowCommand="Grid_Detail_RowCommand" PageSize="5" Width="100%">
                                        <RowStyle CssClass="GridViewRowStyle" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                        <HeaderStyle CssClass="GridViewHead" />
                                        <FooterStyle CssClass="GridViewFooterStyle" />
                                        <Columns>
                                            <asp:BoundField DataField="HRPD_ID" HeaderText="绩效考核详情ID" SortExpression="HRPD_ID"
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
                                            <asp:BoundField DataField="HRPD_Year" HeaderText="考核年份" SortExpression="HRPD_Year">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRPD_Month" HeaderText="考核月份" SortExpression="HRPD_Month">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRPD_FinalScore" HeaderText="录入得分" SortExpression="HRPD_FinalScore">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRPD_C_FinalScore" HeaderText="审核得分" SortExpression="HRPD_C_FinalScore">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRPD_M_Score_Result" HeaderText="总经理给分" SortExpression="HRPD_M_Score_Result">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="RESULT" HeaderText="最终得分" SortExpression="RESULT">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbtnEdit1" runat="server" CommandArgument='<%#Eval("HRPD_ID")%>'
                                                        CommandName="Edit1" OnClientClick="false">项目得分明细</asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerTemplate>
                                            <table width="100%">
                                                <tr>
                                                    <td style="text-align: right">
                                                        第&nbsp;<asp:Label ID="lblPageIndex" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                                        页 共&nbsp;<asp:Label ID="lblPageCount" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageCount  %>" />
                                                        页
                                                        <asp:LinkButton ID="btnFirst" runat="server" CausesValidation="False" CommandArgument="First"
                                                            CommandName="Page" Text="首页" />
                                                        <asp:LinkButton ID="btnPrev" runat="server" CausesValidation="False" CommandArgument="Prev"
                                                            CommandName="Page" Text="上一页" />
                                                        <asp:LinkButton ID="btnNext" runat="server" CausesValidation="False" CommandArgument="Next"
                                                            CommandName="Page" Text="下一页" />
                                                        <asp:LinkButton ID="btnLast" runat="server" CausesValidation="False" CommandArgument="Last"
                                                            CommandName="Page" Text="尾页" />
                                                        <asp:TextBox ID="textbox1" runat="server" Width="20px"></asp:TextBox>
                                                        <%--<asp:textbox id="txtNewPageIndex" runat="server" width="20px" text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />--%>
                                                        <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                                            CommandName="Page" Text="GO" />
                                                        <!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
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
                            </td>
                        </tr>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel2" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="Label1" runat="server" CssClass="STYLE2" Text="考核项目得分详情："></asp:Label></legend>
                    <asp:GridView ID="GridView2" runat="server" AllowSorting="True" DataKeyNames="HRPIS_ItemID"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" Width="100%" AllowPaging="True"
                        GridLines="None" OnPageIndexChanging="GridView2_PageIndexChanging" OnDataBound="GridView2_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="HRPIS_ItemID" HeaderText="考核项目ID" ReadOnly="True" SortExpression="HRPIS_ItemID"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="HRPI_Items" HeaderText="考核项目" SortExpression="HRPI_Items">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="HRPI_Contents" HeaderText="考核内容" SortExpression="HRPI_Contents">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="HRPI_StanScore" HeaderText="标准得分" SortExpression="HRPI_StanScore">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="HRPIS_ItemFScore" HeaderText="该项目得分" SortExpression="HRPIS_ItemFScore">
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
                                        <asp:TextBox ID="textbox2" runat="server" Width="20px"></asp:TextBox>
                                        <%--<asp:textbox id="txtNewPageIndex" runat="server" width="20px" text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />--%>
                                        <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                            CommandName="Page" Text="GO" />
                                        <!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
                                    </td>
                                </tr>
                            </table>
                        </PagerTemplate>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label16" runat="server" Text="没有找到相关记录"></asp:Label>
                        </EmptyDataTemplate>
                        <EditRowStyle BackColor="white" />
                    </asp:GridView>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td align="center" colspan="1">
                                <asp:Button ID="Btnclose" runat="server" CssClass="Button02" Height="24px" Text="关闭"
                                    Visible="true" Width="70px" OnClick="Btnclose_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
