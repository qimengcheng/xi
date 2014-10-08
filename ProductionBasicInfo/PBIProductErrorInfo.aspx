<%@ Page Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true"
    CodeFile="PBIProductErrorInfo.aspx.cs" Inherits="ProductionBasicInfo_PBIProductErrorInfo"
    Title="异常现象选项维护" %>

<%--作者：bush2582--%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <!--用来查询异常选项系列的模块界面-->
    <asp:UpdatePanel ID="UpdatePanel_Search_ErrorInfo" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Search_ErrorInfo" runat="server" Visible="true">
                <fieldset>
                    <legend>异常现象选项检索</legend>
                    <div style="width: 100%; height: 10%">
                        <div id="DIV_Input_Search_text" style="float: left; width: 40%; height: 100%">
                            <div id="DIV_ShowInfo" style="float: left; width: 30%; height: 90%; margin-top: 1%">
                                异常现象选项:
                            </div>
                            <div id="DIV_Asp_Input_Search_text" style="float: right; width: 70%; height: 100%">
                                <asp:TextBox ID="Asp_Input_Search_text" runat="server" Style="width: 100%"></asp:TextBox>
                            </div>
                        </div>
                        <div id="DIV_Input_Btn_Search" style="float: left; width: 10%; margin-left: 10%">
                            <asp:Button ID="Asp_Input_Btn_Search" runat="server" Text="检索" CssClass="Button02"
                                Style="width: 100%; height: 90%" OnClick="Asp_Input_Btn_Search_Click" />
                        </div>
                        <div id="DIV_Input_Btn_Reset" style="float: left; width: 10%; margin-left: 8%">
                            <asp:Button ID="Asp_Input_Btn_Reset" runat="server" Text="重置" CssClass="Button02"
                                Style="width: 100%; height: 90%" OnClick="Asp_Input_Btn_Reset_Click" />
                        </div>
                        <div id="DIV_Input_Btn_AddNewErrorOption" style="float: right; width: 15%;">
                            <asp:Button ID="Asp_Input_AddNewErrorOption" runat="server" Text="新增异常原因" CssClass="Button02"
                                Style="width: 100%; height: 90%" OnClick="Asp_Input_AddNewErrorOption_Click" />
                        </div>
                    </div>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    
    <!--用来显示异常选项系列的模块界面-->
    <asp:UpdatePanel ID="UpdatePanel_List_ErrorOption" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_List_ErrorOption" runat="server" Visible="true">
                <fieldset>
                    <legend>异常选项列表</legend>
                    <div id="GridView" style="width: 100%;">
                        <asp:GridView ID="GridViewShowErrorOptionList" runat="server" Width="100%" EnableModelValidation="True"
                            CssClass="GridViewStyle" AutoGenerateColumns="False" AllowPaging="True" DataKeyNames="EPO_ID" GridLines="None"
                            EmptyDataText="无相关记录!" OnRowEditing="GridViewShowErrorOptionList_RowEditing"
                            OnRowUpdating="GridViewShowErrorOptionList_RowUpdating" OnRowCancelingEdit="GridViewShowErrorOptionList_RowCancelingEdit"
                            OnRowDeleting="GridViewShowErrorOptionList_RowDeleting" OnPageIndexChanging="GridViewShowErrorOptionList_PageIndexChanging"
                            OnRowCommand="GridViewShowErrorOptionList_RowCommand" OnDataBound="GridViewShowErrorOptionList_DataBound">
                             <RowStyle CssClass="GridViewRowStyle" />
                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                            <HeaderStyle CssClass="GridViewHead" />
                            <FooterStyle CssClass="GridViewFooterStyle" />
                            <Columns>
                                <asp:BoundField DataField="EPO_ID" HeaderText="异常选项ID" SortExpression="EPO_ID" Visible="false" />
                                <asp:BoundField DataField="EPO_Name" HeaderText="异常原因名称" />
                                <asp:BoundField DataField="EPO_WarnDays" HeaderText="预警天数" />
                                <asp:CommandField ShowEditButton="True" EditText="编辑" CancelText="取消" InsertText="插入"
                                    UpdateText="更新" />
                                <%--<asp:CommandField DeleteText="删除" ShowDeleteButton="True"  />--%>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                            Text="删除" OnClientClick="return confirm('您确认删除该记录吗?')"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="Check_Detail" runat="server" CommandArgument='<%# Eval("EPO_ID")+","+Eval("EPO_Name") %>'
                                            CommandName="Check_Detail">查看详细项目</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerTemplate>
                                <div id="DIV_Pager" style="width: 100%;">
                                    <div id="DIV_PagerIndex" style="width: 5%; margin-left: 60%; float: left">
                                        第<asp:Label ID="ASP_Label_PageIndex" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />页
                                    </div>
                                    <div id="DIV_PagerCount" style="width: 5%; float: left">
                                        共<asp:Label ID="ASP_Label_PageCount" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageCount  %>" />页
                                    </div>
                                    <div id="DIV_Pager_Frist" style="width: 5%; float: left">
                                        <asp:LinkButton ID="ASP_Label_PageFirst" runat="server" CausesValidation="False"
                                            CommandArgument="First" CommandName="PageFirst" Text="首页" />
                                    </div>
                                    <div id="DIV_Pager_Prev" style="width: 5%; float: left">
                                        <asp:LinkButton ID="ASP_Label_PagePrev" runat="server" CausesValidation="False" CommandArgument="Prev"
                                            CommandName="PagePrev" Text="上一页" />
                                    </div>
                                    <div id="DIV_Pager_Next" style="width: 5%; float: left">
                                        <asp:LinkButton ID="ASP_Label_PageNext" runat="server" CausesValidation="False" CommandArgument="Next"
                                            CommandName="PageNext" Text="下一页" />
                                    </div>
                                    <div id="DIV_Pager_Last" style="width: 5%; float: left">
                                        <asp:LinkButton ID="ASP_Label_PageLast" runat="server" CausesValidation="False" CommandArgument="Last"
                                            CommandName="PageLast" Text="尾页" />
                                    </div>
                                    <div id="DIV_Goto_Apage" style="width: 2%; float: left;">
                                        <asp:TextBox runat="server" Width="100%" ID="ASP_Pager_Text"></asp:TextBox>
                                    </div>
                                    <div id="DIV_JumpToPage" style="width: 2%; float: left; margin-left: 1%">
                                        <asp:LinkButton ID="ASP_Jump_blt" runat="server" CausesValidation="False" CommandArgument="Jump"
                                            CommandName="PageJump" Text="GO" />
                                    </div>
                                </div>
                            </PagerTemplate>
                            <PagerStyle BorderWidth="1px" ForeColor="Blue" HorizontalAlign="Center" CssClass="GridViewPagerStyle" />
                        </asp:GridView>
                    </div>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <!--用来新增异常选项系列的模块界面-->
    <asp:UpdatePanel ID="UpdatePanel_ADD_ErrorOption" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_ADD_ErrorOption" runat="server" Visible="false">
                <fieldset>
                    <legend>新增异常选项</legend>
                    <div id="DIV_ADD_ErrorOption" style="width: 100%; height: 10%">
                        <div id="DIV_ADD_ErrorOption_Name_ShowInfo" style="float: left; width: 8%; height: 100%;">
                            异常名称：
                        </div>
                        <div id="DIV_ADD_ErrorOption_Name_Text" style="float: left; width: 28%; height: 100%;
                            margin-left: 2%">
                            <asp:TextBox ID="Asp_ADD_ErrorOption_Name_Text" runat="server" Width="100%" Height="100%"></asp:TextBox>
                        </div>
                        <div id="Div7" style="float: left; width: 2%; height: 100%; margin-left: 1%">
                            <font color="red">*</font>
                        </div>
                        <div id="DIV_ADD_ErrorOption_WDay_ShowInfo" style="float: left; width: 10%; height: 100%;
                            margin-left: 2%;">
                            预警天数：
                        </div>
                        <div id="DIV_ADD_ErrorOption_WDay_Text" style="float: left; width: 12%; height: 100%;">
                            <asp:TextBox ID="Asp_ADD_ErrorOption_WDay_Text" runat="server" Width="100%" Height="100%"></asp:TextBox>
                        </div>
                        <div id="Div1" style="float: left; width: 2%; height: 100%; margin-left: 1%">
                            <font color="red">*</font>
                        </div>
                        <div id="DIV_ADD_ErrorOption_Btn" style="float: left; width: 8%; height: 100%; margin-left: 5%;">
                            <asp:Button ID="Asp_ADD_ErrorOption_Btn" Width="100%" Height="90%" Text="提交" CssClass="Button02"
                                runat="server" OnClick="Asp_ADD_ErrorOption_Btn_Click" />
                        </div>
                        <div id="DIV2" style="float: left; width: 8%; height: 100%; margin-left: 5%;">
                            <asp:Button ID="Button1" Width="100%" Height="90%" Text="关闭" CssClass="Button02"
                                runat="server" OnClick="Button1_Click" />
                        </div>
                    </div>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_Parameter" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Parameter" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="Label_PTP" runat="server"></asp:Label>异常现象选项详细
                        <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 183px">
                                检索工序所属异常选项详细项目：
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:Label ID="Label17" runat="server" Text="Label" Visible="False"></asp:Label>
                                <asp:Label ID="Label2" runat="server" Text="Label" Visible="False"></asp:Label>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <asp:Button ID="Btn_Close_Parameter0" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Btn_Close_Parameter0_Click" Text="新增异常现象详细" Width="130px" />
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView_Parameter" runat="server" AutoGenerateColumns="false"
                        Font-Strikeout="False" GridLines="None" CssClass="GridViewStyle" PageSize="10"
                        CellPadding="0" UseAccessibleHeader="False" AllowPaging="True" OnRowCommand="GridView_Parameter_RowCommand"
                        OnPageIndexChanging="GridView_Parameter_PageIndexChanging" AllowSorting="True"
                        Width="100%" DataKeyNames="EPOD_ID" EmptyDataText="无相关记录!" OnDataBound="GridView_Parameter_DataBound"
                        OnRowCancelingEdit="GridView_Parameter_RowCancelingEdit" OnRowEditing="GridView_Parameter_RowEditing"
                        OnRowUpdating="GridView_Parameter_RowUpdating">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="EPOD_ID" HeaderText="异常现象选项详细项目ID" SortExpression="EOPD_ID"
                                Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="EPOD_Name" SortExpression="EOPD_Name" HeaderText="异常现象选项详细项目">
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="所在工序">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lbl1" Text='<%#Eval("PBC_Name") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddl1" runat="server" DataSource='<%#GetDs2() %>' DataTextField="PBC_Name"
                                        DataValueField="PBC_ID">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ShowEditButton="True" EditText="编辑" UpdateText="更新" CancelText="关闭">
                            </asp:CommandField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="delete1" runat="server" CommandArgument='<%# Eval("EPOD_ID")+","+Eval("EPOD_Name") %>'
                                        OnClientClick="return confirm('您确认删除该记录吗?')" CommandName="delete1">删除</asp:LinkButton>
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
                                <asp:Button ID="Btn_Close_Parameter" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Btn_Close_Parameter_Click" Text="关闭" Width="70px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_AddPS" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_AddPS" runat="server" Visible="false">
                <fieldset>
                    <legend>异常现象详细项目新增</legend>
                    <table style="width: 100%;">
                        <tr style="width: 100%;">
                            <td style="width: 15%;">
                                详细项目名称：
                            </td>
                            <td style="width: 25%;">
                                <asp:TextBox ID="txt_PS" runat="server" Width="90%" MaxLength="30"></asp:TextBox>
                            <asp:Label ID="Label9" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                            <td style="width: 10%;">
                                所在工序：
                            </td>
                            <td style="width: 15%;">
                                <asp:DropDownList ID="DropDownList2" runat="server">
                                </asp:DropDownList>
                                <asp:Label ID="Label3" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                            <td style="width: 12%;" align="center">
                                <asp:Button ID="Btn_Submit" runat="server" Text="提交" Width="70px" Height="24px" CssClass="Button02"
                                    OnClick="Btn_Submit_Click" />
                            </td>
                            <td style="width: 12%;" align="center">
                                <asp:Button ID="Btn_Cancel" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_Cancel_Click"
                                    Text="重置" Width="70px" />
                            </td>
                            <td align="center">
                                <asp:Button ID="Btn_Close_PS" runat="server" CssClass="Button02" Height="24px" OnClick="Button_Close_PSSearch_Click"
                                    Text="关闭" Width="70px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
