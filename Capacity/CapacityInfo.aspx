<%@ Page Title="" Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true"
    CodeFile="CapacityInfo.aspx.cs" Inherits="Capacity_CapacityInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel_Search" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Search" runat="server" Visible="true">
                <fieldset>
                    <legend>产能核定信息检索<asp:Label ID="label_pagestate" runat="server" Visible="False"></asp:Label> </legend>
                    <table style="width: 100%; height: 23px;">
                        <tr style="width: 100%;">
                            <td style="width: 7%;" align="right">
                                核定人：
                            </td>
                            <td style="width: 14%;" align="center">
                                <asp:TextBox ID="TextBox_makepeople" runat="server" Width="100%"></asp:TextBox>
                            </td>
                            <td align="right" style="width: 16%;">
                                核定时间：
                            </td>
                            <td align="center" style="width: 91px;">
                                <asp:TextBox ID="TextBox_WO_Time1" runat="server"  onfocus="new  WdatePicker(this,'%Y-%M-%D %h:%m',true)"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;&nbsp; 至&nbsp;&nbsp; <asp:TextBox ID="TextBox_WO_Time2" runat="server"  onfocus="new  WdatePicker(this,'%Y-%M-%D %h:%m',true)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="width: 100%;">
                            <td style="width: 15%;" align="center">
                            </td>
                            <td align="center" style="width: 15%;">
                            </td>
                            <td style="width: 4%;" align="left">
                                <asp:Button ID="Btn_Search" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_Search_Click"
                                    Text="检索" Width="70px" />
                            </td>
                            <td align="left" style="width: 15%;">
                                <asp:Button ID="Button_Add" runat="server" CssClass="Button02" Height="24px" OnClick="Button_AddCS_Click"
                                    Text="新增产能信息" Width="90px" />
                            </td>
                            <td align="left" style="width: 70px;">
                                <asp:Button ID="Button_Cancel" runat="server" CssClass="Button02" Height="24px" OnClick="Button_Cancel_Click"
                                    Text="重置" Width="70px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    
    <asp:UpdatePanel ID="UpdatePanel_CS" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_CS" runat="server" Visible="true">
                <fieldset>
                    <legend>产能核定信息表
                        <asp:Label ID="label_GridPageState" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="label_CSN_Name" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <asp:GridView ID="GridView_CS" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        PageSize="10" CellPadding="0" UseAccessibleHeader="False" AllowPaging="True" OnRowCommand="GridView_CS_RowCommand"
                        OnPageIndexChanging="GridView_CS_PageIndexChanging" AllowSorting="True" Width="100%"
                        DataKeyNames="CI_ID" EmptyDataText="无相关记录!" GridLines="None" OnRowCancelingEdit="GridView_CS_RowCancelingEdit"
                        OnRowEditing="GridView_CS_RowEditing" OnRowUpdating="GridView_CS_RowUpdating">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="CI_ID" SortExpression="CI_ID" HeaderText="产能核定系列名称信息ID"
                                Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="CI_P" SortExpression="CI_P" HeaderText="核定人" ReadOnly="True">
                            </asp:BoundField>
                            <asp:BoundField DataField="CI_T" SortExpression="CI_T" HeaderText="核定时间" ReadOnly="True"
                                DataFormatString="{0:yyyy-MM-dd HH:mm}"></asp:BoundField>
                            <asp:BoundField DataField="CI_Note" SortExpression="CI_Note" HeaderText="核定说明"></asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete123" runat="server" CommandName="Delete123" CommandArgument='<%#Eval("CI_ID") %>'
                                        OnClientClick="return confirm('将会删除该产能核定系列，确定吗？')">删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ShowEditButton="True" EditText="编辑" UpdateText="更新" CancelText="关闭">
                            </asp:CommandField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Capacitymake" runat="server" CommandArgument='<%#Eval("CI_ID") +","+ Eval("CI_T","{0:yyyy-MM-dd HH:mm}")%>'
                                        CommandName="Capacitymake">产能核定制定</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Capacitycheck" runat="server" CommandArgument='<%#Eval("CI_ID") +","+ Eval("CI_P")%>'
                                        CommandName="Capacitycheck">产能核定结果查看</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第 &nbsp;<asp:Label ID="lblPageIndex" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                        页 共 &nbsp;<asp:Label ID="lblPageCount" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageCount  %>" />
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
                            <asp:Label ID="Label16" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                    </asp:GridView>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdatePanel_Add" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Add" runat="server" Visible="false">
                <fieldset>
                    <legend>新增产能核定信息 </legend>
                    <table style="width: 100%; height: 23px;">
                        <tr style="width: 100%;">
                            <td style="width: 17%;" align="center">
                                产能核定说明：
                            </td>
                            <td align="center" style="width: 65%;">
                                <asp:TextBox ID="TextBox_Note_Add" runat="server" Width="90%"></asp:TextBox>
                                <asp:Label ID="Label49" runat="server" ForeColor="Red" Text="*"></asp:Label>
                            </td>
                            <td align="center" style="width: 25%;">
                                <asp:Button ID="Button_Add_Confirm" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_Add_Confirm_Click" Text="新增" Width="70px" />
                            </td>
                            <td align="center">
                                <asp:Button ID="Button_Add_Cancel" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_Add_Cancel_Click" Text="关闭" Width="70px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdatePanel_PBC" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_PBC" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="Label_Date" runat="server"></asp:Label>工序产能核定表
                        <asp:Label ID="Label_CI_ID" runat="server" Visible="False"></asp:Label>
                    </legend>
                    
                    <asp:GridView ID="GridView_PBC" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        PageSize="10" CellPadding="0" UseAccessibleHeader="False" AllowPaging="True" OnRowCommand="GridView_PBC_RowCommand"
                        OnPageIndexChanging="GridView_PBC_PageIndexChanging" AllowSorting="True" Width="100%"
                        DataKeyNames="PBC_ID" EmptyDataText="无相关记录!" GridLines="None">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="PBC_ID" SortExpression="PBC_ID" HeaderText="工序ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="PBC_Name" SortExpression="PBC_Name" HeaderText="工序" ReadOnly="True">
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="CapacityPBC" runat="server" CommandArgument='<%#Eval("PBC_ID") +","+ Eval("PBC_Name")%>'
                                        CommandName="CapacityPBC">分工序核定</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第 &nbsp;<asp:Label ID="lblPageIndex" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                        页 共 &nbsp;<asp:Label ID="lblPageCount" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageCount  %>" />
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
                            <asp:Label ID="Label16" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <table style="width: 100%;">
                        <tr>
                            <td align="center">
                                <asp:Button ID="Button_ClosePBC" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_ClosePBC_Click" Text="关闭" Width="70px" />
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_PBCraftDetail" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_PBCraftDetail" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="Label_PBC_Name" runat="server"></asp:Label>&nbsp;分工序产能核定
                        <asp:Label ID="Label_PBC_ID" runat="server" Visible="False"></asp:Label>
                    </legend>
                    
                    <asp:GridView ID="GridView_PBCraftDetail" runat="server" AutoGenerateColumns="false"
                        CssClass="GridViewStyle" PageSize="10" CellPadding="0" UseAccessibleHeader="False"
                        AllowPaging="True" OnRowCommand="GridView_PBCraftDetail_RowCommand" OnPageIndexChanging="GridView_PBCraftDetail_PageIndexChanging"
                        AllowSorting="True" Width="100%" DataKeyNames="CDI_ID,CS_ID" EmptyDataText="无相关记录!"
                        GridLines="None" OnRowCancelingEdit="GridView_PBCraftDetail_RowCancelingEdit"
                        OnRowEditing="GridView_PBCraftDetail_RowEditing" OnRowUpdating="GridView_PBCraftDetail_RowUpdating">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="CDI_ID" SortExpression="CDI_ID" HeaderText="CDI_ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="CS_ID" SortExpression="CS_ID" HeaderText="CS_ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="CSN_Name" SortExpression="CSN_Name" HeaderText="系列名称"
                                ReadOnly="True"></asp:BoundField>
                            <asp:BoundField DataField="CS_MacC" SortExpression="CS_MacC" HeaderText="机器单位产能" ReadOnly="True">
                            </asp:BoundField>
                            <asp:BoundField DataField="CDI_MachineNum" SortExpression="CDI_MachineNum" HeaderText="机器数"></asp:BoundField>
                            <asp:BoundField DataField="CDI_MachineHours" SortExpression="CDI_MachineHours" HeaderText="机器时数"></asp:BoundField>
                            <asp:BoundField DataField="CDI_MachineTotal" SortExpression="CDI_MachineTotal" HeaderText="机器产能" ReadOnly="True">
                            </asp:BoundField>
                            <asp:BoundField DataField="CS_LaborC" SortExpression="CS_LaborC" HeaderText="人工单位产能" ReadOnly="True">
                            </asp:BoundField>
                            <asp:BoundField DataField="CDI_PeopleNum" SortExpression="CDI_PeopleNum" HeaderText="人工数" ></asp:BoundField>
                            <asp:BoundField DataField="CDI_PeopleHours" SortExpression="CDI_PeopleHours" HeaderText="人工时数"></asp:BoundField>
                            <asp:BoundField DataField="CDI_PeopleTotal" SortExpression="CDI_PeopleTotal" HeaderText="人工产能" ReadOnly="True">
                            </asp:BoundField>
                            <asp:BoundField DataField="CDI_Total" SortExpression="CDI_Total" HeaderText="总产能" ReadOnly="True">
                            </asp:BoundField>
                            <asp:CommandField ShowEditButton="True" EditText="核定" UpdateText="更新" CancelText="关闭">
                            </asp:CommandField>
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第 &nbsp;<asp:Label ID="lblPageIndex" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                        页 共 &nbsp;<asp:Label ID="lblPageCount" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageCount  %>" />
                                        页
                                        <asp:LinkButton ID="btnFirst" runat="server" CausesValidation="False" CommandArgument="First"
                                            CommandName="Page" Text="首页" />
                                        <asp:LinkButton ID="btnPrev" runat="server" CausesValidation="False" CommandArgument="Prev"
                                            CommandName="Page" Text="上一页" />
                                        <asp:LinkButton ID="btnNext" runat="server" CausesValidation="False" CommandArgument="Next"
                                            CommandName="Page" Text="下一页" />
                                        <asp:LinkButton ID="btnLast" runat="server" CausesValidation="False" CommandArgument="Last"
                                            CommandName="Page" Text="尾页" />
                                        <asp:TextBox ID="textbox33" runat="server" Width="20px"></asp:TextBox>
                                        <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                            CommandName="Page" Text="GO" />
                                    </td>
                                </tr>
                            </table>
                        </PagerTemplate>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label16" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <table style="width: 100%;">
                        <tr>
                            <td align="center">
                                <asp:Button ID="Button_PBCraftDetail" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_PBCraftDetail_Click" Text="关闭" Width="70px" />
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_ResultCheck" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_ResultCheck" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="Label_CIID2" runat="server" Visible="False"></asp:Label>产能核定结果查看 </legend>
                    
                    <asp:GridView ID="GridView_ResultCheck" runat="server" AutoGenerateColumns="false"
                        CssClass="GridViewStyle" PageSize="10" CellPadding="0" UseAccessibleHeader="False"
                        AllowPaging="false" OnPageIndexChanging="GridView_ResultCheck_PageIndexChanging"
                        AllowSorting="True" Width="100%" EmptyDataText="无相关记录!" GridLines="None">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="CSN_Name" SortExpression="CSN_Name" HeaderText="系列名称"
                                ReadOnly="True"></asp:BoundField>
                          <asp:BoundField DataField="PBC_Name" SortExpression="PBC_Name" HeaderText="瓶颈工序"
                                ReadOnly="True"></asp:BoundField>
                            <asp:BoundField DataField="CS_MacC" SortExpression="CS_MacC" HeaderText="机器单位产能" ReadOnly="True">
                            </asp:BoundField>
                            <asp:BoundField DataField="CDI_MachineNum" SortExpression="CDI_MachineNum" HeaderText="机器数"></asp:BoundField>
                            <asp:BoundField DataField="CDI_MachineHours" SortExpression="CDI_MachineHours" HeaderText="机器时数"></asp:BoundField>
                            <asp:BoundField DataField="CDI_MachineTotal" SortExpression="CDI_MachineTotal" HeaderText="机器产能" ReadOnly="True">
                            </asp:BoundField>
                            <asp:BoundField DataField="CS_LaborC" SortExpression="CS_LaborC" HeaderText="人工单位产能" ReadOnly="True">
                            </asp:BoundField>
                            <asp:BoundField DataField="CDI_PeopleNum" SortExpression="CDI_PeopleNum" HeaderText="人工数"></asp:BoundField>
                            <asp:BoundField DataField="CDI_PeopleHours" SortExpression="CDI_PeopleHours" HeaderText="人工时数"></asp:BoundField>
                            <asp:BoundField DataField="CDI_PeopleTotal" SortExpression="CDI_PeopleTotal" HeaderText="人工产能" ReadOnly="True">
                            </asp:BoundField>
                            <asp:BoundField DataField="CDI_Total" SortExpression="CDI_Total" HeaderText="总产能" ReadOnly="True">
                            </asp:BoundField>
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第 &nbsp;<asp:Label ID="lblPageIndex" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                        页 共 &nbsp;<asp:Label ID="lblPageCount" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageCount  %>" />
                                        页
                                        <asp:LinkButton ID="btnFirst" runat="server" CausesValidation="False" CommandArgument="First"
                                            CommandName="Page" Text="首页" />
                                        <asp:LinkButton ID="btnPrev" runat="server" CausesValidation="False" CommandArgument="Prev"
                                            CommandName="Page" Text="上一页" />
                                        <asp:LinkButton ID="btnNext" runat="server" CausesValidation="False" CommandArgument="Next"
                                            CommandName="Page" Text="下一页" />
                                        <asp:LinkButton ID="btnLast" runat="server" CausesValidation="False" CommandArgument="Last"
                                            CommandName="Page" Text="尾页" />
                                        <asp:TextBox ID="textbox44" runat="server" Width="20px"></asp:TextBox>
                                        <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                            CommandName="Page" Text="GO" />
                                    </td>
                                </tr>
                            </table>
                        </PagerTemplate>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label16" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <table style="width: 100%;">
                        <tr>
                            <td align="center">
                                <asp:Button ID="Button1" runat="server" CssClass="Button02" Height="24px" OnClick="Button_1_Click"
                                    Text="关闭" Width="70px" />
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
