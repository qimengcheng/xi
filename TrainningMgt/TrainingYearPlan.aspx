<%@ Page Title="培训年度计划维护" Language="C#" MasterPageFile="~/Other/MasterPage.master"
    AutoEventWireup="true" CodeFile="TrainingYearPlan.aspx.cs" Inherits="TrainningMgt_TrainingYearPlan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <style type="text/css">
        .hidden
        {
            display: none;
        }
    </style>
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server">
                <fieldset>
                    <legend>培训年度计划检索栏</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label2" runat="server" CssClass="STYLE2" Text="年份："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:DropDownList ID="DdlSYears" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label1" runat="server" CssClass="STYLE2" Text="年度计划状态："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:DropDownList ID="DdlState" runat="server">
                                    <asp:ListItem>请选择</asp:ListItem>
                                    <asp:ListItem>待提交</asp:ListItem>
                                    <asp:ListItem>已提交</asp:ListItem>
                                    <asp:ListItem>已完成</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label13" runat="server" CssClass="STYLE2" Text="制定人："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtSPerson" runat="server" Width="130px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="LblStartTime" runat="server" CssClass="STYLE2" Text="制定时间："></asp:Label>
                            </td>
                            <td style="height: 20%;" align="left" colspan="3">
                                <asp:TextBox ID="TxtStartTime" runat="server" Width="130px"  onfocus="new  WdatePicker(this,'%Y-%M-%D %h:%m:%s',true)"></asp:TextBox>
                                <asp:Label ID="LblEndTime" runat="server" CssClass="STYLE2" Text="至"></asp:Label>
                                <asp:TextBox ID="TxtEndTime" runat="server" Width="130px"  onfocus="new  WdatePicker(this,'%Y-%M-%D %h:%m:%s',true)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td align="right" colspan="2">
                                <asp:Label ID="LblRecordIsSearch" runat="server" Text="检索前" Visible="false"></asp:Label>
                                <asp:Button ID="BtnSearch" runat="server" CssClass="Button02" Height="24px" Text="检索"
                                    Width="70px" OnClick="BtnSearch_Click" />
                            </td>
                            <td align="center" colspan="2">
                                <asp:Button ID="BtnNew" runat="server" CssClass="Button02" Height="24px" Text="新增年度计划"
                                    Width="91px" TabIndex="1" OnClick="BtnNew_Click" />
                            </td>
                            <td align="left" colspan="2">
                                <asp:Button ID="BtnReset" runat="server" CssClass="Button02" Height="24px" Text="重置"
                                    Visible="true" Width="70px" TabIndex="2" OnClick="BtnReset_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel2" runat="server">
                <fieldset>
                    <legend>年度计划列表</legend>
                    <asp:GridView ID="Grid_YrarPlan" runat="server" DataKeyNames="TYPM_ID" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                        AllowPaging="True" PageSize="10" Font-Strikeout="False" GridLines="None" UseAccessibleHeader="False"
                        OnDataBound="Grid_YrarPlan_DataBound" OnPageIndexChanging="Grid_YrarPlan_PageIndexChanging"
                        OnRowCommand="Grid_YrarPlan_RowCommand">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="TYPM_ID" HeaderText="年计划ID" SortExpression="TYPM_ID" Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="TYPM_Year" HeaderText="年份" SortExpression="TYPM_Year">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="TYPM_State" HeaderText="年度计划状态" SortExpression="TYPM_State">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="TYPM_Maker" HeaderText="计划制定人" SortExpression="TYPM_Maker">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="TYPM_Time" HeaderText="制定时间" SortExpression="TYPM_Time">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnLookDetail" runat="server" CommandName="LookDetail" OnClientClick="false"
                                        CommandArgument='<%#Eval("TYPM_ID")%>'>查看详情</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnEditDetail" runat="server" CommandName="EditDetail" OnClientClick="false"
                                        CommandArgument='<%#Eval("TYPM_ID")%>'>编辑培训项目</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnSubmitYearPlan" runat="server" CommandName="SubmitYearPlan"
                                        OnClientClick="false" CommandArgument='<%#Eval("TYPM_ID")%>'>提交年度计划</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnDeleteYearPlan" runat="server" CommandName="DeleteYearPlan"
                                        OnClientClick="return confirm('您确认删除该记录吗?')" CommandArgument='<%#Eval("TYPM_ID")%>'>删除</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
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
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
        <%--<Triggers>
            <asp:AsyncPostBackTrigger ControlID="Btn_NEW_NETItem" />
        </Triggers>--%>
        <ContentTemplate>
            <asp:Panel ID="Panel3" runat="server" Visible="false">
                <fieldset>
                    <legend>培训年度计划<asp:Label ID="LblAddOrEdit" runat="server" Text=""></asp:Label></legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label3" runat="server" CssClass="STYLE2" Text="年份："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:DropDownList ID="DdlAYears" runat="server" CausesValidation="True">
                                </asp:DropDownList>
                                <asp:Label ID="Label18" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                    ControlToValidate="DdlAYears" ValidationGroup="YearDetail"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label4" runat="server" CssClass="STYLE2" Text="制定人："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtPerson" runat="server" Width="130px" Enabled="False" MaxLength="10"></asp:TextBox>
                                <asp:Label ID="Label19" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                    ControlToValidate="TxtPerson" ValidationGroup="YearDetail"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label5" runat="server" CssClass="STYLE2" Text="制定时间："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtTime" runat="server" Width="130px" Enabled="False"></asp:TextBox>
                                <asp:Label ID="Label20" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                    ControlToValidate="TxtTime" ValidationGroup="YearDetail"></asp:RequiredFieldValidator>--%>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td colspan="2" align="right">
                                <asp:Button ID="BtnSubmit1" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    Width="70px" ValidationGroup="YearDetail" OnClick="BtnSubmit1_Click" />
                            </td>
                            <td colspan="2" align="right">
                            </td>
                            <td colspan="2" align="left">
                                <asp:Button ID="BtnCacel1" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    Visible="true" Width="70px" OnClick="BtnCacel1_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
        <%--<Triggers>
            <asp:AsyncPostBackTrigger ControlID="Btn_NEW_NETItem" />
        </Triggers>--%>
        <ContentTemplate>
            <asp:Panel ID="Panel4" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="Label14" runat="server" Text=""></asp:Label>年度计划中的项目列表<asp:Label ID="Label17"
                            runat="server" Text=""></asp:Label></legend>
                    <table style="width: 100%;">
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label15" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Button ID="BtnSubmit" runat="server" Text="新增培训项目" CssClass="Button02" Height="24px"
                                    Width="90px" OnClick="BtnSubmit_Click" />
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView_Item" runat="server" DataKeyNames="TID_ID" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                        AllowPaging="True" PageSize="20" Font-Strikeout="False" GridLines="None" UseAccessibleHeader="False"
                        OnDataBound="GridView_Item_DataBound" OnPageIndexChanging="GridView_Item_PageIndexChanging"
                        OnRowCommand="GridView_Item_RowCommand">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="TID_ID" HeaderText="培训项目明细ID" SortExpression="TID_ID"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="TID_Month" HeaderText="月份" SortExpression="TID_Month">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="TID_TLesson" HeaderText="培训内容" SortExpression="TID_TLesson">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="TID_Target" HeaderText="培训对象" SortExpression="TID_Target">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="TTT_Type" HeaderText="培训类型" SortExpression="TTT_Type">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="TTT_TypeID" HeaderText="培训类型id" SortExpression="TTT_TypeID">
                                <FooterStyle CssClass="hidden" />
                                <HeaderStyle CssClass="hidden" />
                                <ItemStyle CssClass="hidden" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BDOS_Code" HeaderText="部门ID" SortExpression="BDOS_Code">
                                <FooterStyle CssClass="hidden" />
                                <HeaderStyle CssClass="hidden" />
                                <ItemStyle CssClass="hidden" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BDOS_Name" HeaderText="负责部门" SortExpression="BDOS_Name">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnEditItemInPlan" runat="server" CommandName="EditItemInPlan1"
                                        OnClientClick="false" CommandArgument='<%#Eval("TID_ID")%>'>编辑</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnDeleteItemInPlan" runat="server" CommandName="DeleteItemInPlan1"
                                        OnClientClick="return confirm('您确认删除该记录吗?')" CommandArgument='<%#Eval("TID_ID")%>'>删除</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
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
                                        <%--<asp:textbox id="txtNewPageIndex" runat="server" width="20px" text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />--%>
                                        <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                            CommandName="Page" Text="GO" />
                                        <!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
                                    </td>
                                </tr>
                            </table>
                        </PagerTemplate>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label16" runat="server" Text="没有找到相关记录，请添加培训项目"></asp:Label>
                        </EmptyDataTemplate>
                        <EditRowStyle BackColor="white" />
                    </asp:GridView>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td align="center">
                                <asp:Button ID="BtnCancel" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    Visible="true" Width="70px" OnClick="BtnCancel_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel5" runat="server" Visible="false">
                <fieldset>
                    <legend>培训项目<asp:Label ID="Label12" runat="server" Text=""></asp:Label></legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label6" runat="server" CssClass="STYLE2" Text="月份:"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:DropDownList ID="DdlMonth" runat="server">
                                </asp:DropDownList>
                                <asp:Label ID="Label21" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                                    ControlToValidate="DdlMonth" ValidationGroup="Item"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label7" runat="server" CssClass="STYLE2" Text="培训内容:"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtTrainingItem" runat="server" Width="130px" MaxLength="20"></asp:TextBox>
                                <asp:Label ID="Label22" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*"
                                    ControlToValidate="TxtTrainingItem" ValidationGroup="Item"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label9" runat="server" CssClass="STYLE2" Text="培训对象:"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtTarget" runat="server" Width="130px" MaxLength="20"></asp:TextBox>
                                <asp:Label ID="Label23" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*"
                                    ControlToValidate="TxtTarget" ValidationGroup="Item"></asp:RequiredFieldValidator>--%>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label10" runat="server" CssClass="STYLE2" Text="培训类型:"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:DropDownList ID="DdlType" runat="server">
                                </asp:DropDownList>
                                <asp:Label ID="Label24" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*"
                                    ControlToValidate="DdlType" ValidationGroup="Item"></asp:RequiredFieldValidator>--%>

                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label11" runat="server" CssClass="STYLE2" Text="负责部门:"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:DropDownList ID="DdlDep" runat="server">
                                </asp:DropDownList>
                                <asp:Label ID="Label25" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*"
                                    ControlToValidate="DdlDep" ValidationGroup="Item"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td style="width: 10%" align="center">
                            </td>
                            <td style="width: 20%">
                        </tr>
                        <tr style="height: 16px;">
                            <td colspan="3" align="center">
                                <asp:Label ID="Label8" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Button ID="BtnSubmit2" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    Width="70px" OnClick="BtnSubmit2_Click" ValidationGroup="Item" />
                            </td>
                            <td colspan="3" align="center">
                                <asp:Button ID="BtnCacel2" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    Visible="true" Width="70px" OnClick="BtnCacel2_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
