<%@ Page Title="" Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true"
    CodeFile="WorkingTeam.aspx.cs" Inherits="WorkOrderSalary_WorkingTeam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel_Search" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Search" runat="server" Visible="true">
                <fieldset>
                    <legend>班组信息检索 <asp:Label ID="label_pagestate" runat="server" Visible="False"></asp:Label> </legend>
                    <table style="width: 100%;">
                        <tr style="width: 100%;">
                            <td style="width: 13%;" align="center">
                                &nbsp;班组名称：
                            </td>
                            <td style="width: 17%;" align="left">
                                <asp:TextBox ID="TextBox_Teamname" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 7%;" align="center">
                                制定人：
                            </td>
                            <td style="width: 14%;" align="center">
                                <asp:TextBox ID="TextBox_makepeople" runat="server" Width="100%"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 11%;">
                                &nbsp; 制定时间：
                            </td>
                            <td align="left" class="auto-style3" style="width: 16%;">
                                <asp:TextBox ID="TextBox_WO_Time1" runat="server"  onfocus="new WdatePicker(this,'%Y-%M-%D',true)"
                                    Width="100%"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 28px;">
                                至
                            </td>
                            <td style="width: 16%;" align="left">
                                <asp:TextBox ID="TextBox_WO_Time2" runat="server"  onfocus="new WdatePicker(this,'%Y-%M-%D',true)"
                                    Width="100%"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%;">
                        <tr style="width: 100%;">
                            <td align="center" style="width: 13%;">
                                &nbsp;
                            </td>
                            <td align="left" style="width: 17%;">
                                &nbsp;
                            </td>
                            <td align="center" style="width: 15%;">
                                <asp:Button ID="Btn_Search" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_Search_Click"
                                    Text="检索" Width="70px" />
                            </td>
                            <td align="center" style="width: 14%;">
                                <asp:Button ID="Button_AddTeam" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_AddTeam_Click" Text="新增班组" Width="70px" />
                            </td>
                            <td align="center" style="width: 11%;">
                                <asp:Button ID="Button_Cancel" runat="server" CssClass="Button02" Height="24px" OnClick="Button_Cancel_Click"
                                    Text="重置" Width="70px" />
                            </td>
                            <td align="left" class="auto-style3" style="width: 127px">
                                &nbsp;
                            </td>
                            <td align="left" style="width: 28px;">
                                &nbsp;
                            </td>
                            <td align="right" style="width: 16%;">
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_add" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_add" runat="server" Visible="False">
                <fieldset>
                    <legend>新增班组 </legend>
                    <table style="width: 100%;">
                        <tr style="width: 100%;">
                            <td style="width: 13%;" align="center">
                                &nbsp;班组名称：
                            </td>
                            <td style="width: 17%;" align="left">
                                <asp:TextBox ID="TextBox_wtname_Add" runat="server" Width="100%"></asp:TextBox>
                            </td>
                            <td style="width: 15%;" align="center">
                                &nbsp;<asp:Button ID="Button_ADD" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_ADD_Click" Text="新增" Width="70px" />
                            </td>
                            <td style="width: 14%;" align="center">
                                <asp:Button ID="Button_CancelAdd" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_CancelAdd_Click" Text="关闭" Width="70px" />
                            </td>
                            <td align="center" style="width: 11%;">
                                &nbsp;
                            </td>
                            <td align="left" style="width: 70px;">
                                &nbsp;
                            </td>
                            <td style="width: 16%;" align="center">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_WOmain" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_WOmain" runat="server" Visible="true">
                <fieldset>
                    <legend>班组信息表
                        <asp:Label ID="label_GridPageState" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="label_Sname" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <asp:GridView ID="GridView_WOmain" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        PageSize="10" CellPadding="0" UseAccessibleHeader="False" OnRowCommand="GridView_WOmain_RowCommand"
                        OnPageIndexChanging="GridView_WOmain_PageIndexChanging" 
                        AllowSorting="True" Width="100%"
                        DataKeyNames="WT_ID" EmptyDataText="无相关记录!" GridLines="None" OnRowCancelingEdit="GridView_WOmain_RowCancelingEdit"
                        OnRowEditing="GridView_WOmain_RowEditing" 
                        OnRowUpdating="GridView_WOmain_RowUpdating">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="WT_ID" SortExpression="WT_ID" HeaderText="班组信息ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="WT_Name" SortExpression="WT_Name" HeaderText="班组名称"></asp:BoundField>
                            <asp:BoundField DataField="WT_People" SortExpression="WT_People" HeaderText="制定人"
                                ReadOnly="True"></asp:BoundField>
                            <asp:BoundField DataField="WT_Date" SortExpression="WT_Date" HeaderText="制定时间" DataFormatString="{0:yyyy-MM-dd HH:mm}"
                                ReadOnly="True"></asp:BoundField>
                            <asp:CommandField ShowEditButton="True" EditText="编辑" UpdateText="更新" CancelText="关闭">
                            </asp:CommandField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete12" runat="server" CommandName="Delete12" CommandArgument='<%#Eval("WT_ID") %>'
                                        OnClientClick="return confirm('将会删除班组信息，确定吗？')">删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="membermgt" runat="server" CommandArgument='<%#Eval("WT_ID") +","+ Eval("WT_Name")%>'
                                        CommandName="membermgt">组员管理</asp:LinkButton>
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
    <asp:UpdatePanel ID="UpdatePanel_Member" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Member" runat="server" Visible="False">
                <fieldset>
                    <legend>
                        <asp:Label ID="label_S" runat="server"></asp:Label>组员管理表
                        <asp:Label ID="label_SID" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td align="left">
                                <asp:Button ID="Button_ChosePT" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_ChosePT_Click" Text="新增员工" Width="70px" />
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView_member" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        PageSize="10" CellPadding="0" UseAccessibleHeader="False" AllowPaging="True" OnPageIndexChanging="GridView_member_PageIndexChanging"
                        AllowSorting="True" Width="100%" DataKeyNames="WTDL_ID" EmptyDataText="无相关记录!"
                        GridLines="None">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemStyle Width="5%" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="WTDL_ID" SortExpression="WTDL_ID" HeaderText="班组详细ID"
                                Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="HRDD_ID" SortExpression="HRDD_ID" HeaderText="人事档案ID"
                                Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="HRDD_StaffNO" SortExpression="HRDD_StaffNO" HeaderText="工号"
                                ItemStyle-Width="45%"></asp:BoundField>
                            <asp:BoundField DataField="HRDD_Name" SortExpression="HRDD_Name" HeaderText="姓名"
                                ItemStyle-Width="45%"></asp:BoundField>
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
                    <table width="100%">
                        <tr>
                            <td style="width: 320px;">
                            </td>
                            <td style="width: 26px">
                                <asp:CheckBox ID="CheckBoxAll" runat="server" Text="全选" Width="54px" AutoPostBack="True"
                                    OnCheckedChanged="CheckBoxAll_CheckedChanged" />
                            </td>
                            <td style="width: 38px">
                                <asp:CheckBox ID="CheckBoxfanxuan" runat="server" Text="反选" Width="141px" AutoPostBack="True"
                                    OnCheckedChanged="Checkfanxuan_CheckedChanged" />
                            </td>
                            <td style="width: 93px">
                                <asp:Button ID="Btn_deleting" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_deleting_Click"
                                    Text="删除" Width="70px" OnClientClick="return confirm('将会删除所选组员，确定吗？')" />
                            </td>
                            <td style="width: 320px;">
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%;">
                        <tr>
                            <td align="center">
                                <asp:Button ID="Button_CloseTeam" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_CloseTeam_Click" Text="关闭" Width="70px" />
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_People" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_People" runat="server" Visible="false">
                <fieldset>
                    <legend>员工信息检索</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 7%" align="center">
                                <asp:Label ID="Label10" runat="server" Text="工号："></asp:Label>
                            </td>
                            <td style="width: 10%" align="left">
                                <asp:TextBox ID="TextBox_NO" runat="server" Width="98%"></asp:TextBox>
                            </td>
                            <td style="width: 7%" align="center">
                                <asp:Label ID="Label11" runat="server" Text="姓名："></asp:Label>
                            </td>
                            <td style="width: 10%" align="left">
                                <asp:TextBox ID="TextBox_Name" runat="server" Width="98%"></asp:TextBox>
                            </td>
                            <td style="width: 15%" align="center">
                                <asp:Button ID="Button_SearchPeople" runat="server" Text="检索" CssClass="Button02"
                                    Height="24px" OnClick="Button_SearchPeople_click" Width="70px" />
                               
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView_people" runat="server" AllowPaging="True" PageSize="20"
                        Width="100%" AutoGenerateColumns="False" CellPadding="0" CssClass="GridViewStyle"
                        GridLines="None" DataKeyNames="HRDD_ID" AllowSorting="True" 
                        OnPageIndexChanging="GridView_people_PageIndexChanging" 
                        ondatabinding="GridView_people_DataBinding" 
                        onrowdatabound="GridView_people_RowDataBound">
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridviewHead" BorderStyle="Double" BorderWidth="1px" Height="26px"
                            HorizontalAlign="Center" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemStyle Width="5%" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox2" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="HRDD_ID" HeaderText="人事档案ID" Visible="false" />
                            <asp:BoundField DataField="HRDD_StaffNO" HeaderText="工号" ItemStyle-Width="45%" />
                            <asp:BoundField DataField="HRDD_Name" HeaderText="姓名" ItemStyle-Width="45%" />
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第 &nbsp;<asp:Label ID="lblPageIndex" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>' />
                                        页 共 &nbsp;<asp:Label ID="lblPageCount" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />
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
                                            CommandName="Page" Text="GO" /><!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
                                    </td>
                                </tr>
                            </table>
                        </PagerTemplate>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label16" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                        <AlternatingRowStyle />
                    </asp:GridView>
                    <table width="100%">
                        <tr>
                            <td style="width: 320px;">
                            </td>
                            <td style="width: 26px">
                                <asp:CheckBox ID="CheckBox2" runat="server" Text="全选" Width="54px" AutoPostBack="True"
                                    OnCheckedChanged="CheckBoxAll2_CheckedChanged" />
                            </td>
                            <td style="width: 38px">
                                <asp:CheckBox ID="Checkfanxuan2" runat="server" Text="反选" Width="141px" AutoPostBack="True"
                                    OnCheckedChanged="Checkfanxuan2_CheckedChanged" />
                            </td>
                            <td style="width: 93px">
                                <asp:Button ID="Button_AddPTToSeries" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_AddPTToSeries_Click" Text="新增" Width="70px" />
                            </td>
                            <td style="width: 320px;">
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%;">
                        <tr>
                            <td align="center">
                                 <asp:Button ID="Button_ClosePeople" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_ClosePeople_Click" Text="关闭" Width="70px" />
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
