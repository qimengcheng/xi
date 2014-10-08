<%@ Page Title="" Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true"
    CodeFile="ProcessRouteMgt.aspx.cs" Inherits="CraftMgt_ProcessRouteMgt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel_Search" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Search" runat="server" Visible="true">
                <fieldset>
                    <legend>工艺路线检索
                        <asp:Label ID="label_GridPageState" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="label_pagestate" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <table style="width: 100%; height: 23px;">
                        <tr style="width: 100%;">
                            <td style="width: 17%;" align="right">
                                工艺文件名称：
                            </td>
                            <td style="width: 15%;">
                                <asp:TextBox ID="TextBox_PRName" runat="server" Width="81px"></asp:TextBox>
                            </td>
                            <td align="right" style="width: 15%;">
                                受控文件编号：
                            </td>
                            <td align="right" style="width: 6px;">
                                <asp:TextBox ID="TextBox_DocSN" runat="server" Width="81px"></asp:TextBox>
                            </td>
                            <td style="width: 15%;" align="right">
                                制定时间：
                            </td>
                            <td style="width: 15%;" align="right">
                                <asp:TextBox ID="TextBox_ApplyTime1" runat="server" onfocus="new  WdatePicker(this,'%Y-%M-%D %h:%m',true)"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 3%;">
                                至
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TextBox_ApplyTime2" runat="server" onfocus="new  WdatePicker(this,'%Y-%M-%D %h:%m',true)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="width: 100%;">
                            <td style="width: 12%;" align="right">
                                申请单编号：
                            </td>
                            <td align="left" style="width: 15%;">
                                <asp:TextBox ID="TextBox_ApplySN" runat="server" Width="81px"></asp:TextBox>
                            </td>
                            <td style="width: 11%" align="right">
                                文件类型：
                            </td>
                            <td style="width: 6px" align="right">
                                <asp:TextBox ID="TextBox_DocType" runat="server" Width="81px"></asp:TextBox>
                            </td>
                            <td style="width: 17%;" align="right">
                                制定人：
                            </td>
                            <td style="width: 15%;" align="right">
                                <asp:TextBox ID="TextBox_AppMan" runat="server"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 3%;">
                                &nbsp;
                            </td>
                            <td align="left" style="width: 15%;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr style="width: 100%;">
                            <td style="width: 12%;" align="right">
                                版本号：
                            </td>
                            <td align="left" style="width: 15%;">
                                <asp:TextBox ID="TextBox_VersionNum" runat="server" Width="81px"></asp:TextBox>
                            </td>
                            <td style="width: 11%" align="right">
                                更改类型：
                            </td>
                            <td style="width: 6px" align="right">
                                <asp:TextBox ID="TextBox_ChagenType" runat="server" Width="81px"></asp:TextBox>
                            </td>
                            <td style="width: 17%;" align="right">
                                状态：
                            </td>
                            <td style="width: 15%;" align="left">
                                <asp:TextBox ID="TextBox_State" runat="server"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 3%;">
                                &nbsp;
                            </td>
                            <td align="left" style="width: 15%;">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 50%" align="center">
                                <asp:Button ID="Btn_Search" runat="server" Text="检索" Width="80px" Height="24px" CssClass="Button02"
                                    OnClick="Btn_Search_Click" />
                            </td>
                            <td align="center">
                                <asp:Button ID="Button_Cancel" runat="server" CssClass="Button02" Height="24px" OnClick="Button_Cancel_Click"
                                    Text="重置" Width="80px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_Doc" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Doc" runat="server" Visible="true">
                <fieldset>
                    <legend>工艺路线（流程）文件列表 </legend>
                    <asp:GridView ID="GridView_Doc" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        PageSize="10" CellPadding="0" UseAccessibleHeader="False" AllowPaging="True"
                        OnRowCommand="GridView_Doc_RowCommand" OnPageIndexChanging="GridView_Doc_PageIndexChanging"
                        AllowSorting="True" OnSorting="GridView_Doc_Sorting" OnRowDataBound="GridView_Doc_RowDataBound"
                        Width="100%" DataKeyNames="CDA_ID" EmptyDataText="无相关记录!" GridLines="None" OnDataBound="GridView_Doc_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="CDA_ID" SortExpression="CDA_ID" HeaderText="文件ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="CDA_DocName" SortExpression="CDA_DocName" HeaderText="工艺文件名称"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="CDA_DocNO" SortExpression="CDA_DocNO" HeaderText="受控文件编号"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="CDA_AppNO" SortExpression="CDA_AppNO" HeaderText="申请单编号"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="CDA_EditionNO" SortExpression="CDA_EditionNO" HeaderText="版本号"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="CDA_DocType" SortExpression="CDA_DocType" HeaderText="文件类型"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="CDA_ChangedType" SortExpression="CDA_ChangedType" HeaderText="更改类型"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="CDA_AppState" SortExpression="CDA_AppState" HeaderText="状态"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="CDA_AppPer" SortExpression="CDA_AppPer" HeaderText="制定人"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="CDA_AppTime" SortExpression="CDA_AppTime" HeaderText="制定时间"
                                DataFormatString="{0:yyyy-MM-dd HH:mm}" ReadOnly="true"></asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Detail" runat="server" CommandArgument='<%#Eval("CDA_ID") +","+ Eval("CDA_AppState") %>'
                                        CommandName="Detail">详细</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Review" runat="server" CommandArgument='<%#Eval("CDA_ID") %>'
                                        CommandName="Review">会签</asp:LinkButton>
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
                                        <%--<asp:textbox id="txtNewPageIndex" runat="server" width="20px" text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />--%>
                                        <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                            CommandName="Page" Text="GO" />
                                        <!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
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
    <asp:UpdatePanel ID="UpdatePanel_PR" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_PR" runat="server" Visible="False">
                <fieldset>
                    <legend>工艺路线列表
                        <asp:Label ID="label_cdaid" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="Label_CDAstate" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:Button ID="Button_AddPR" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_AddPR_Click"
                                    Text="新增工艺路线" Width="80px" />
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView_PR" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        PageSize="10" CellPadding="0" UseAccessibleHeader="False" AllowPaging="True"
                        OnRowCommand="GridView_PR_RowCommand" OnPageIndexChanging="GridView_PR_PageIndexChanging"
                        OnRowEditing="GridView_PR_Editing" OnRowCancelingEdit="GridView_PR_CancelingEdit"
                        AllowSorting="True" OnSorting="GridView_PR_Sorting" OnRowUpdating="GridView_PR_Updating"
                        OnRowDataBound="GridView_PR_RowDataBound" Width="100%" DataKeyNames="PR_ID" EmptyDataText="无相关记录!"
                        GridLines="None" OnDataBound="GridView_PR_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="PR_ID" SortExpression="PR_ID" HeaderText="工艺路线ID" Visible="False">
                            </asp:BoundField>
                            <asp:BoundField DataField="PR_Name" SortExpression="PR_Name" HeaderText="工艺路线名称"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="PR_Special" SortExpression="PR_Special" HeaderText="是否属于特殊工艺路线"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="PR_WritePeople" SortExpression="PR_WritePeople" HeaderText="制定人"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="PR_WriteTime" SortExpression="PR_WriteTime" HeaderText="制定时间"
                                DataFormatString="{0:yyyy-MM-dd HH:mm}" ReadOnly="true"></asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Edit_PR" runat="server" CommandArgument='<%#Eval("PR_ID")+","+ Eval("PR_Name")+","+ Eval("PR_Special") %>'
                                        CommandName="Edit_PR">编辑</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete_PR" runat="server" CommandArgument='<%# Eval("PR_ID") %>'
                                        CommandName="Delete_PR" OnClientClick="return confirm('您确认删除该记录吗?')">删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="CraftMgt000" runat="server" CommandArgument='<%#Eval("PR_ID")+","+ Eval("PR_Name") %>'
                                        CommandName="CraftMgt000">工序管理</asp:LinkButton>
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
                                        <%--<asp:textbox id="txtNewPageIndex" runat="server" width="20px" text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />--%>
                                        <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                            CommandName="Page" Text="GO" />
                                        <!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
                                    </td>
                                </tr>
                            </table>
                        </PagerTemplate>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label16" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <table style="width: 100%">
                        <tr>
                            <td align="center">
                                <asp:Button ID="Button_ClosePR" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Btn_ClosePR_Click" Text="关闭" Width="80px" />
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_AddOrEditPR" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_AddOrEditPR" runat="server" Visible="False">
                <fieldset>
                    <legend>
                        <asp:Label ID="label_AddOrEdit" runat="server"></asp:Label>
                        &nbsp;<asp:Label ID="Label_PRName" runat="server"></asp:Label>
                        &nbsp;工艺路线 </legend>
                    <table style="width: 100%; height: 23px;">
                        <tr style="width: 100%;">
                            <td style="width: 12%;">
                                工艺路线名称：
                            </td>
                            <td style="width: 15%;">
                                <asp:TextBox ID="TextBox_AddOrEditPRName" runat="server" MaxLength="25"></asp:TextBox>
                            </td>
                            <td align="right" style="width: 19%;">
                                是否属于特殊工艺路线：
                            </td>
                            <td align="left" style="width: 6px;">
                                <asp:DropDownList ID="DropDownList_Special" runat="server">
                                    <asp:ListItem>是</asp:ListItem>
                                    <asp:ListItem>否</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td style="width: 204px">
                            </td>
                            <td style="width: 95px">
                                <asp:Button ID="Button_Submit_PR" runat="server" Text="提交" Width="80px" Height="24px"
                                    CssClass="Button02" OnClick="Button_Submit_PR_Click" />
                                &nbsp;
                            </td>
                            <td style="width: 97px" class="style1">
                            </td>
                            <td>
                                &nbsp;<asp:Button ID="Button_CancelPR" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_CancelPR_Click" Text="关闭" Width="80px" />
                                &nbsp;
                            </td>
                            <td style="width: 37px">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_CraftMgt" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_CraftMgt" runat="server" Visible="False">
                <fieldset>
                    <legend>
                        <asp:Label ID="Label_prnamecheck" runat="server"></asp:Label>
                        所属工序管理列表
                        <asp:Label ID="Label_PRID" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <table width="100%">
                        <tr>
                            <td style="width: 89px">
                                <asp:Button ID="Button_AddCraft" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Btn_AddCraft_Click" Text="新增工序" Width="80px" />
                            </td>
                            <td style="width: 198px">
                                <asp:Label ID="Label1" runat="server" Text=" 复制已有工艺路线中的工序："></asp:Label> 
                            </td>
                            <td style="width: 72px">
                                <asp:DropDownList ID="DropDownList1" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Button ID="Button_copy" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_copy_Click"
                                    Text="复制插入" Width="80px" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView_CraftMgt" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        PageSize="2" CellPadding="0" UseAccessibleHeader="False" AllowPaging="false"
                        OnRowCommand="GridView_CraftMgt_RowCommand" OnPageIndexChanging="GridView_CraftMgt_PageIndexChanging"
                        OnRowEditing="GridView_CraftMgt_Editing" OnRowCancelingEdit="GridView_CraftMgt_CancelingEdit"
                        AllowSorting="True" OnSorting="GridView_CraftMgt_Sorting" OnRowUpdating="GridView_CraftMgt_Updating"
                        OnRowDataBound="GridView_CraftMgt_RowDataBound" Width="100%" DataKeyNames="PRD_ID,PBC_ID"
                        EmptyDataText="无相关记录!" GridLines="None" OnDataBound="GridView_CraftMgt_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="PRD_ID" SortExpression="PRD_ID" HeaderText="工艺路线详细ID"
                                Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="PBC_ID" SortExpression="PBC_ID" HeaderText="工序ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="PRD_Order" SortExpression="PRD_Order" HeaderText="排序">
                            </asp:BoundField>
                            <asp:BoundField DataField="PBC_Name" SortExpression="PBC_Name" HeaderText="工序名称"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="PRD_Doc" SortExpression="PRD_Doc" HeaderText="相关文件"></asp:BoundField>
                            <asp:BoundField DataField="PRD_Way" SortExpression="PRD_Way" HeaderText="管控方式"></asp:BoundField>
                            <asp:BoundField DataField="PRD_Note" SortExpression="PRD_Note" HeaderText="备注"></asp:BoundField>
                            <asp:CommandField ShowEditButton="True" EditText="编辑" UpdateText="更新" CancelText="取消">
                                <ItemStyle Width="10%" />
                            </asp:CommandField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete_CraftMgt" runat="server" CommandArgument='<%# Eval("PRD_ID") %>'
                                        CommandName="Delete_CraftMgt" OnClientClick="return confirm('您确认删除该记录吗?')">删除</asp:LinkButton>
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
                                        <%--<asp:textbox id="txtNewPageIndex" runat="server" width="20px" text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />--%>
                                        <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                            CommandName="Page" Text="GO" />
                                        <!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
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
                            <td align="center">
                                <asp:Button ID="Button_CloseCraftMgt" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Btn_CloseCraftMgt_Click" Text="关闭" Width="80px" />
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_Craft" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Craft" runat="server" Visible="false">
                <fieldset>
                    <legend>工序列表</legend>
                    <asp:GridView ID="GridView_Craft" runat="server" AllowPaging="True" PageSize="20"
                        Width="100%" AutoGenerateColumns="False" CellPadding="0" CssClass="GridViewStyle"
                        GridLines="None" DataKeyNames="PBC_ID" AllowSorting="True" OnPageIndexChanging="GridView_Craft_PageIndexChanging"
                        OnRowDataBound="GridView_Craft_RowDataBound" OnDataBound="GridView_Craft_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemStyle Width="5%" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox2" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="PBC_ID" HeaderText="工序ID" Visible="false" />
                            <asp:BoundField DataField="PBC_Name" HeaderText="工序名称" ItemStyle-Width="45%" />
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
                    </asp:GridView>
                    <table style="width: 100%; text-align: center;">
                        <tr>
                            <td>
                                <asp:CheckBox ID="Cbx2_SelectAll" runat="server" Text="全选" AutoPostBack="true" OnCheckedChanged="Cbx2_SelectAll_CheckedChanged" />
                                &nbsp;
                                <asp:Button ID="Button_Craft" runat="server" CssClass="Button02" Text="提 交" OnClick="Button_Craft_Click"
                                    Width="80px" Height="24px" />
                            </td>
                            <td align="left">
                                <asp:Button ID="Btn_CloseCraft" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Btn_CloseCraft_Click" Text="关闭" Width="80px" />
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
