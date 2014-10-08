<%@ Page Title="" Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true"
    CodeFile="TimeSalary.aspx.cs" Inherits="WorkOrderSalary_TimeSalary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel_Search" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Search" runat="server" Visible="true">
                <fieldset>
                    <legend>提报日期检索<asp:Label ID="label_pagestate" runat="server" Visible="False"></asp:Label> </legend>
                    <table style="width: 100%; height: 23px;">
                        <tr style="width: 100%;">
                            <td style="width: 10%;" align="center">
                                &nbsp; 日期：
                            </td>
                            <td align="center" style="width: 15%;">
                                <asp:TextBox ID="TextBox_Date1" runat="server"  onfocus="new WdatePicker(this,'%Y-%M-%D',true)"
                                    Width="100%"></asp:TextBox>
                            </td>
                            <td style="width: 4%;" align="center">
                                至
                            </td>
                            <td align="center" style="width: 15%;">
                                <asp:TextBox ID="TextBox_Date2" runat="server"  onfocus="new WdatePicker(this,'%Y-%M-%D',true)"
                                    Width="100%"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 26%;">
                                &nbsp;
                            </td>
                            <td align="right" style="width: 70px;">
                                <asp:Button ID="Btn_Search" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_Search_Click"
                                    Text="检索" Width="70px" />
                            </td>
                            <td style="width: 16%;" align="right">
                                <asp:Button ID="Button_AddDate" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_AddDate_Click" Text="新增提报日期" Width="90px" />
                            </td>
                            <td align="right" style="width: 16%;">
                                <asp:Button ID="Button_Cancel" runat="server" CssClass="Button02" Height="24px" OnClick="Button_Cancel_Click"
                                    Text="重置" Width="70px" />
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
                    <legend>提报日期新增 </legend>
                    <table style="width: 100%; height: 23px;">
                        <tr style="width: 100%;">
                            <td style="width: 9%;" align="center">
                                日期：
                            </td>
                            <td style="width: 17%;" align="left">
                                <asp:TextBox ID="TextBox_Date_Add" runat="server" Width="100%"  onfocus="new WdatePicker(this,'%Y-%M-%D',true)"></asp:TextBox>
                            </td>
                            <td style="width: 15%;" align="center">
                                <asp:Button ID="Button_ADD" runat="server" CssClass="Button02" Height="24px" OnClick="Button_ADD_Click"
                                    Text="新增" Width="70px" />
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
                    <legend>提报日期表
                        <asp:Label ID="label_GridPageState" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <asp:GridView ID="GridView_WOmain" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        PageSize="10" CellPadding="0" UseAccessibleHeader="False" AllowPaging="True" OnRowCommand="GridView_WOmain_RowCommand"
                        OnPageIndexChanging="GridView_WOmain_PageIndexChanging" AllowSorting="True" Width="100%"
                        DataKeyNames="TSD_ID" EmptyDataText="无相关记录!" GridLines="None">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="TSD_ID" SortExpression="TSD_ID" HeaderText="提报日期ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="TSD_Date" SortExpression="TSD_Date" HeaderText="提报日期"
                                DataFormatString="{0:yyyy-MM-dd}" ItemStyle-Width="45%"></asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete123" runat="server" CommandName="Delete123" CommandArgument='<%#Eval("TSD_ID") +","+ Eval("TSD_Date") %>'
                                        OnClientClick="return confirm('将会删除该提报日期，确定吗？')">删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Craft" runat="server" CommandArgument='<%#Eval("TSD_ID") +","+ Eval("TSD_Date","{0:yyyy-MM-dd}")%>'
                                        CommandName="Craft">计时项目</asp:LinkButton>
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
    <asp:UpdatePanel ID="UpdatePanel_Craft" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Craft" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="label_Date" runat="server"></asp:Label>
                        计时项目表
                        <asp:Label ID="label_TSD_ID" runat="server" Visible="False" Text="00000000-0000-0000-0000-000000000000">      </asp:Label>
                    </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 40px">
                                工序：
                            </td>
                            <td class="auto-style3" style="width: 100px">
                                <asp:TextBox ID="TextBox_Tibao_Craft" runat="server" Width="100px"></asp:TextBox>
                            </td>
                            <td style="width: 82px">
                                计时项目：
                            </td>
                            <td style="width: 106px">
                                <asp:TextBox ID="TextBox_Tibao_Project" Width="100px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 58px">
                                提报人：
                            </td>
                            <td style="width: 51px">
                                <asp:TextBox ID="TextBox_Tibao_Man" Width="100px" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 54px">
                                &nbsp;
                            </td>
                            <td style="width: 62px">
                                &nbsp;
                            </td>
                            <td align="right">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 40px">
                            </td>
                            <td class="auto-style3" style="width: 100px">
                                &nbsp;
                            </td>
                            <td style="width: 82px">
                                &nbsp;
                            </td>
                            <td style="width: 106px" align="center">
                                <asp:Button ID="Btn_Tibao_Search" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Btn_Tibao_Search_Click" Text="检索" Width="70px" />
                            </td>
                            <td style="width: 58px">
                                &nbsp;
                            </td>
                            <td style="width: 51px" align="center">
                                <asp:Button ID="Button_AddProject" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_AddProject_Click" Text="新增计时项目" Width="90px" />
                            </td>
                            <td style="width: 54px">
                            </td>
                            <td style="width: 62px">
                                <asp:Button ID="Button_Tibao_Cancel" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_Tibao_Cancel_Click" Text="重置" Width="70px" />
                            </td>
                            <td align="right">
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView_Craft" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        PageSize="10" CellPadding="0" UseAccessibleHeader="False" AllowPaging="True" OnRowCommand="GridView_Craft_RowCommand"
                        OnPageIndexChanging="GridView_Craft_PageIndexChanging" AllowSorting="True" Width="100%"
                        DataKeyNames="TSDD_ID" EmptyDataText="无相关记录!" GridLines="None">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="TSDD_ID" SortExpression="TSDD_ID" HeaderText="计时提报日期详细表ID"
                                Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="STI_ID" SortExpression="STI_ID" HeaderText="计时项目ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="PBC_Name" SortExpression="PBC_Name" HeaderText="工序"></asp:BoundField>
                            <asp:BoundField DataField="STI_Name" SortExpression="STI_Name" HeaderText="计时项目">
                            </asp:BoundField>
                            <asp:BoundField DataField="TSDD_Man" SortExpression="TSDD_Man" HeaderText="制定人">
                            </asp:BoundField>
                            <asp:BoundField DataField="TSDD_Time" SortExpression="TSDD_Time" HeaderText="制定时间"
                                DataFormatString="{0:yyyy-MM-dd HH:mm}"></asp:BoundField>
                            <asp:BoundField DataField="TSDD_State" SortExpression="TSDD_State" HeaderText="提报状态">
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete123" runat="server" CommandName="Delete123" CommandArgument='<%#Eval("TSDD_ID")+","+ Eval("TSDD_State") %>'
                                        OnClientClick="return confirm('将会删除该计时项目，该计时项目的详细信息也会一并删除，确定吗？')">删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="CheckDetail" runat="server" CommandArgument='<%#Eval("TSDD_ID") +","+ Eval("STI_Name")+","+ Eval("STI_ID")+","+ Eval("TSDD_State")%>'
                                        CommandName="CheckDetail">提报详细信息</asp:LinkButton>
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
                                <asp:Button ID="Button_Close" runat="server" CssClass="Button02" Height="24px" OnClick="Button_Close_Click"
                                    Text="关闭" Width="70px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_AddProject" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_AddProject" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="label_Date2" runat="server"></asp:Label>
                        待选计时项目表
                        <asp:Label ID="Label_TSDD_State" runat="server" Visible="False">      </asp:Label>
                    </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 40px">
                                工序：
                            </td>
                            <td class="auto-style3" style="width: 100px">
                                <asp:TextBox ID="TextBox_AddProject_Craft" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 82px" align="right">
                                计时项目：
                            </td>
                            <td style="width: 106px">
                                <asp:TextBox ID="TextBox_AddProject_Project" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 58px">
                                &nbsp;
                            </td>
                            <td style="width: 51px">
                                <asp:Button ID="Button_AddProject_Search" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_AddProject_Search_Click" Text="检索" Width="70px" />
                            </td>
                            <td align="center">
                            </td>
                            <td align="center" style="width: 155px">
                                <asp:Button ID="ButtonButton_AddProject_Cancel" runat="server" CssClass="Button02"
                                    Height="24px" OnClick="ButtonButton_AddProject_Cancel_Click" Text="重置" Width="70px" />
                            </td>
                            <td align="right">
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView_AddProject" runat="server" AutoGenerateColumns="false"
                        CssClass="GridViewStyle" PageSize="10" CellPadding="0" UseAccessibleHeader="False"
                        AllowPaging="True" OnPageIndexChanging="GridView_AddProject_PageIndexChanging"
                        AllowSorting="True" Width="100%" DataKeyNames="STI_ID" EmptyDataText="无相关记录!"
                        GridLines="None">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:TemplateField HeaderText="选择">
                                <ItemStyle Width="5%" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="STI_ID" SortExpression="STI_ID" HeaderText="计时项目ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="PBC_Name" SortExpression="PBC_Name" HeaderText="工序" ItemStyle-Width="45%">
                            </asp:BoundField>
                            <asp:BoundField DataField="STI_Name" SortExpression="STI_Name" HeaderText="计时项目"
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
                            <td style="width: 320px">
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
                                <asp:Button ID="Button_CheckboxAddProject" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_CheckboxAddProject_Click" Text="新增" Width="70px" />
                            </td>
                            <td style="width: 320px">
                            </td>
                        </tr>
                    </table>
                    <table width="100%">
                        <tr>
                            <td align="center">
                                <asp:Button ID="Button4" runat="server" CssClass="Button02" Height="24px" OnClick="Button_Close_Click"
                                    Text="关闭" Width="70px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_Detail" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Detail" runat="server" Visible="False">
                <fieldset>
                    <legend>
                        <asp:Label ID="label_Date3" runat="server"></asp:Label>
                        计时项目明细表
                        <asp:Label ID="label_TSDD_ID" runat="server" Visible="False" Text="00000000-0000-0000-0000-000000000000"></asp:Label>
                        <asp:Label ID="Label_STI_ID" runat="server" Visible="False" Text="00000000-0000-0000-0000-000000000000"></asp:Label>
                    </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 63px">
                                工号：
                            </td>
                            <td class="auto-style3" style="width: 100px">
                                <asp:TextBox ID="TextBox_NO" runat="server" Width="100px"></asp:TextBox>
                            </td>
                            <td style="width: 58px" align="right">
                                姓名：
                            </td>
                            <td style="width: 123px">
                                <asp:TextBox ID="TextBox_Name" runat="server" Width="100px"></asp:TextBox>
                            </td>
                            <td style="width: 58px">
                                &nbsp;
                            </td>
                            <td style="width: 51px">
                                <asp:Button ID="Button_SearchDetail" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_SearchDetail_Click" Text="检索" Width="70px" />
                            </td>
                            <td align="center" style="width: 97px">
                                <asp:Button ID="Button_Addman" runat="server" CssClass="Button02" Height="24px" OnClick="Button_Addman_Click"
                                    Text="新增员工" Width="70px" />
                            </td>
                            <td align="left" style="width: 171px">
                                <asp:Button ID="Button_ResetDetail" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_ResetDetail_Click" Text="重置" Width="70px" />
                            </td>
                            <td align="right" style="width: 155px">
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView_Detail" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        PageSize="10" CellPadding="0" UseAccessibleHeader="False" AllowPaging="True" OnRowCommand="GridView_Detail_RowCommand"
                        OnPageIndexChanging="GridView_Detail_PageIndexChanging" AllowSorting="True" Width="100%"
                        DataKeyNames="OT_ID" EmptyDataText="无相关记录!" GridLines="None" OnRowCancelingEdit="GridView_Detail_RowCancelingEdit"
                        OnRowEditing="GridView_Detail_RowEditing" OnRowUpdating="GridView_Detail_RowUpdating"
                        OnRowDataBound="GridView_Detail_RowDataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="OT_ID" SortExpression="OT_ID" HeaderText="计时信息ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="HRDD_StaffNO" SortExpression="HRDD_StaffNO" HeaderText="工号"
                                ReadOnly="True"></asp:BoundField>
                            <asp:BoundField DataField="HRDD_Name" SortExpression="HRDD_Name" HeaderText="姓名"
                                ReadOnly="True"></asp:BoundField>
                            <asp:BoundField DataField="OT_Time" SortExpression="OT_Time" HeaderText="计时时间"></asp:BoundField>
                            <asp:BoundField DataField="num" SortExpression="num" HeaderText="数量"></asp:BoundField>
                            <asp:CommandField ShowEditButton="True" EditText="制定" UpdateText="更新" CancelText="关闭">
                            </asp:CommandField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="DeleteDetail" runat="server" CommandName="DeleteDetail" CommandArgument='<%#Eval("OT_ID") %>'
                                        OnClientClick="return confirm('将会删除该详细信息，确定吗？')">删除</asp:LinkButton>
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
                    <table width="100%">
                        <tr>
                            <td style="width: 320px">
                            </td>
                            <td align="left">
                                <asp:Button ID="Button_Submit" OnClientClick="return confirm('提交后将无法修改，确定吗？')" runat="server"
                                    CssClass="Button02" Height="24px" OnClick="Button_Submit_Click" Text="提交" Width="70px" />
                            </td>
                            <td align="right">
                                <asp:Button ID="Button_CloseDetail" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_CloseDetail_Click" Text="关闭" Width="70px" />
                            </td>
                            <td style="width: 320px">
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_AddPeople" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_AddPeople" runat="server" Visible="False">
                <fieldset>
                    <legend>
                        <asp:Label ID="label1" runat="server"></asp:Label>
                        新增员工
                        <asp:Label ID="label2" runat="server" Visible="False" Text="00000000-0000-0000-0000-000000000000"></asp:Label>
                    </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 63px">
                                工号：
                            </td>
                            <td class="auto-style3" style="width: 100px">
                                <asp:TextBox ID="TextBox1" runat="server" Width="100px"></asp:TextBox>
                            </td>
                            <td style="width: 58px" align="right">
                                姓名：
                            </td>
                            <td style="width: 123px">
                                <asp:TextBox ID="TextBox2" runat="server" Width="100px"></asp:TextBox>
                            </td>
                            <td style="width: 58px">
                                &nbsp;
                            </td>
                            <td style="width: 51px">
                                <asp:Button ID="Button_AddPeopleSearch" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_AddPeopleSearch_Click" Text="检索" Width="70px" />
                            </td>
                            <td align="center" style="width: 97px">
                            </td>
                            <td align="center" style="width: 171px">
                                <asp:Button ID="Button_AddPeopleCancel" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_AddPeopleCancel_Click" Text="重置" Width="70px" />
                            </td>
                            <td align="right" style="width: 155px">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView_People" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        PageSize="10" CellPadding="0" UseAccessibleHeader="False" AllowPaging="True" OnPageIndexChanging="GridView_People_PageIndexChanging"
                        AllowSorting="True" Width="100%" DataKeyNames="HRDD_ID" EmptyDataText="无相关记录!"
                        GridLines="None">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:TemplateField HeaderText="选择">
                                <ItemStyle Width="5%" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="HRDD_ID" SortExpression="HRDD_ID" HeaderText="人事档案ID"
                                Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="HRDD_StaffNO" SortExpression="HRDD_StaffNO" HeaderText="工号"
                                ItemStyle-Width="45%" ReadOnly="True"></asp:BoundField>
                            <asp:BoundField DataField="HRDD_Name" SortExpression="HRDD_Name" HeaderText="姓名"
                                ItemStyle-Width="45%" ReadOnly="True"></asp:BoundField>
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
                            <td style="width: 320px">
                            </td>
                            <td style="width: 26px">
                                <asp:CheckBox ID="CheckBoxAll2" runat="server" Text="全选" Width="54px" AutoPostBack="True"
                                    OnCheckedChanged="CheckBoxAll2_CheckedChanged" />
                            </td>
                            <td style="width: 38px">
                                <asp:CheckBox ID="Checkfanxuan2" runat="server" Text="反选" Width="141px" AutoPostBack="True"
                                    OnCheckedChanged="Checkfanxuan2_CheckedChanged" />
                            </td>
                            <td style="width: 93px">
                                <asp:Button ID="Button_CheckboxAddProject2" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_CheckboxAddProject2_Click" Text="新增" Width="70px" />
                            </td>
                            <td style="width: 320px">
                            </td>
                        </tr>
                    </table>
                    <table width="100%">
                        <tr>
                            <td align="center">
                                <asp:Button ID="Button_AddPeople_close" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_AddPeople_close_Click" Text="关闭" Width="70px" />
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
