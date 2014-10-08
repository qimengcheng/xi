<%@ Page Title="绩效管理基础信息维护" Language="C#" MasterPageFile="~/Other/MasterPage.master"
    AutoEventWireup="true" CodeFile="HRPDetailMgt.aspx.cs" Inherits="HRPerMgt_HRPDetailMgt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script language="javascript" type="text/javascript">
        function onlyNumber(obj) {
            obj.value = obj.value.replace(/[^\d{1,2}]/g, "");
        }
    </script>
    <style type="text/css">
        .hidden
        {
            display: none;
        }
    </style>
    <asp:UpdatePanel ID="UpdatePanel_Search" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Search" runat="server">
                <fieldset>
                    <legend>绩效考核类型检索栏</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 15%" align="center">
                                <asp:Label ID="Label2" runat="server" CssClass="STYLE2" Text="考核类型:"></asp:Label>
                                <asp:Label ID="LblStateForGrid_Type" runat="server" Text="检索前" Visible="false"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtType" runat="server" Width="155px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                            </td>
                            <td style="width: 15%">
                            <asp:Button ID="BtnSearch" runat="server" CssClass="Button02" Height="24px" OnClick="BtnSearch_Click"
                                    Text="检索" Width="70px" CausesValidation="False" />
                            </td>
                            <td style="width: 15%">
                            <asp:Button ID="BtnNew" runat="server" CssClass="Button02" Height="24px" OnClick="BtnNew_Click"
                                    Text="新增考核类型" Width="90px" TabIndex="1" CausesValidation="False" />
                            </td>
                            <td >
                            <asp:Button ID="BtnReset" runat="server" CssClass="Button02" Height="24px" OnClick="BtnReset_Click"
                                    Text="重置" Visible="true" Width="70px" TabIndex="2" CausesValidation="False" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" colspan="3">
                                <asp:Label ID="Label50" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Label ID="Label27" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Label ID="Label28" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Label ID="Label29" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Label ID="Label30" runat="server" Text="" Visible="false"></asp:Label>
                                
                            </td>
                            <td align="center">
                                <asp:Label ID="Label31" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Label ID="Label32" runat="server" Text="" Visible="false"></asp:Label>
                            </td>
                            <td align="left" colspan="2">
                                <asp:Label ID="Label44" runat="server" Text="" Visible="false"></asp:Label>
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
                    <legend>考核类型列表</legend>
                    <asp:GridView ID="Grid_Type" runat="server" DataKeyNames="HRPAT_ID" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                        AllowPaging="True" PageSize="5" Font-Strikeout="False" GridLines="None" UseAccessibleHeader="False"
                        OnRowCancelingEdit="Grid_Type_RowCancelingEdit" OnRowCommand="Grid_Type_RowCommand"
                        OnRowEditing="Grid_Type_RowEditing" OnRowUpdating="Grid_Type_RowUpdating" OnPageIndexChanging="Grid_Type_PageIndexChanging">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="HRPAT_ID" HeaderText="考核类型ID" SortExpression="HRPAT_ID"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="HRPAT_PType" HeaderText="考核类型" SortExpression="HRPAT_PType">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="HRPAT_AAPerson" HeaderText="考核人" SortExpression="HRPAT_AAPerson">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="HRPAT_CCPerson" HeaderText="审核人" SortExpression="HRPAT_CCPerson">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="HRPAT_M_State" HeaderText="是否经理审核" SortExpression="HRPAT_M_State">
                                <FooterStyle CssClass="hidden" />
                                <HeaderStyle CssClass="hidden" />
                                <ItemStyle CssClass="hidden" />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnEdit1" runat="server" CommandArgument='<%#Eval("HRPAT_ID")%>'
                                        CommandName="Edit1" OnClientClick="false">维护考核项目</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnEdit2" runat="server" CommandArgument='<%#Eval("HRPAT_ID")%>'
                                        CommandName="Edit2" OnClientClick="false">维护该考核类型员工</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnEdit3" runat="server" CommandArgument='<%#Eval("HRPAT_ID")%>'
                                        CommandName="Edit3" OnClientClick="false">编辑</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnDelete_Type" runat="server" CommandName="Delete_Type" OnClientClick="return confirm('您确认删除该记录吗?')"
                                        CommandArgument='<%#Eval("HRPAT_ID")%>'>删除</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第<asp:Label ID="lblPageIndex" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                        页 共<asp:Label ID="lblPageCount" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageCount  %>" />
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
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_NewType" runat="server" UpdateMode="Conditional">
        <%--<Triggers>
            <asp:AsyncPostBackTrigger ControlID="Btn_NEW_NETItem" />
        </Triggers>--%>
        <ContentTemplate>
            <asp:Panel ID="Panel_NewType" runat="server" Visible="false">
                <fieldset>
                    <legend>考核类型维护</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 10%; height: 16px;" align="center">
                                <asp:Label ID="Label1" runat="server" CssClass="STYLE2" Text="考核类型:"></asp:Label>
                            </td>
                            <td style="width: 30%; height: 16px;">
                                <asp:TextBox ID="TxtNewType" runat="server" Width="155px" MaxLength="10"></asp:TextBox>
                                <asp:Label ID="Label34" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                            <td align="center" style="width: 15%; height: 16px;">
                                
                                <asp:Label ID="Label26" runat="server" CssClass="STYLE2" Text="是否需要经理考核："></asp:Label>
                            </td>
                            <td>
                                
                                <asp:DropDownList ID="DropDownList1" runat="server" ToolTip="点击选择">
                                    <asp:ListItem>否</asp:ListItem>
                                    <asp:ListItem>是</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Label ID="Label21" runat="server" CssClass="STYLE2" Text="考核人:"></asp:Label>
                            </td>
                            <td >
                                <asp:TextBox ID="TxtAperson" runat="server" Width="155px" MaxLength="10" Enabled="false"></asp:TextBox>
                                <asp:Label ID="Label39" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <asp:Button ID="BtnSelect" runat="server" Width="50px" Height="20px" Text="选择..."
                                    CssClass="Button02" OnClick="BtnSelect1_Click" />
                            </td>
                            <td  align="center">
                                <asp:Label ID="Label22" runat="server" CssClass="STYLE2" Text="审核人:"></asp:Label>
                            </td>
                            <td style="width: 30%; height: 20px;">
                                <asp:TextBox ID="TxtCperson" runat="server" Width="155px" MaxLength="10" Enabled="false"></asp:TextBox>
                                <asp:Label ID="Label40" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <asp:Button ID="Button3" runat="server" Width="50px" Height="20px" Text="选择..." CssClass="Button02"
                                    OnClick="BtnSelect2_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="BtnSubmit" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    Width="70px" OnClick="BtnSubmit_Click" />
                            </td>
                            <td>
                                <asp:Label ID="LbLblRecordSIT_ItemID2" runat="server" Text="" Visible="false"></asp:Label>
                            </td>
                            <td colspan="3" align="left">
                                <asp:Button ID="BtnCancel" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    Visible="true" Width="70px" OnClick="BtnCancel_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel4" runat="server" Visible="false">
                <fieldset>
                    <legend>考核人或者审核人选择栏</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label23" runat="server" CssClass="STYLE2" Text="账号："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TextBox2" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label24" runat="server" CssClass="STYLE2" Text="姓名："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TextBox3" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label25" runat="server" CssClass="STYLE2" Text="部门："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TextBox4" runat="server" Width="130px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                        <td style="width: 10%" align="right" colspan="2">
                                <asp:Label ID="Label41" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Label ID="Label42" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Label ID="Label43" runat="server" Text="检索前" Visible="false"></asp:Label>
                            </td>
                        </tr>
                        <tr >
                            <td style="width: 10%" align="right" colspan="2">
                                <asp:Button ID="BtnSearchPeopleOut" runat="server" CssClass="Button02" Height="24px"
                                    Text="检索" Width="70px" OnClick="BtnSearchPeopleOut_Click" />
                            </td>
                            <td>
                            </td>
                            <td >
                                <asp:Button ID="BtnResetPeopleOut" runat="server" CssClass="Button02" Height="24px"
                                    Width="70px" Text="重置" OnClick="BtnResetPeopleOut_Click" />
                            </td>
                            <td  >
                            <asp:Button ID="Button4" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    Visible="true" Width="70px" OnClick="Button4_Click" />
                            </td>
                            
                        </tr>
                        <tr>
                            <td colspan="6">
                                <fieldset>
                                    <legend>人员列表</legend>
                                    <asp:GridView ID="GridView_Teacher" runat="server" DataKeyNames="UMUI_UserID" AllowSorting="True"
                                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                                        AllowPaging="True" PageSize="5" Font-Strikeout="False" UseAccessibleHeader="False"
                                        GridLines="None" OnPageIndexChanging="GridView_Teacher_PageIndexChanging" OnRowCommand="GridView_SalaryItemAll_RowCommand"
                                        OnRowDataBound="GridView_Teacher_RowDataBound">
                                        <RowStyle CssClass="GridViewRowStyle" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                        <HeaderStyle CssClass="GridViewHead" />
                                        <FooterStyle CssClass="GridViewFooterStyle" />
                                        <Columns>
                                            <asp:BoundField DataField="UMUI_UserID" HeaderText="账号" SortExpression="UMUI_UserID">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="UMUI_UserName" HeaderText="姓名" SortExpression="UMUI_UserName">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="BDOS_Name" HeaderText="部门" SortExpression="BDOS_Name">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbtnSelect" runat="server" CommandArgument='<%#Eval("UMUI_UserID")%>'
                                                        CommandName="Select" OnClientClick="false">选择</asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerTemplate>
                                            <table width="100%">
                                                <tr>
                                                    <td style="text-align: right">
                                                        第&nbsp<asp:Label ID="lblPageIndex" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>' />
                                                        页 共&nbsp<asp:Label ID="lblPageCount" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />
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
                                                        <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                                            CommandName="Page" Text="GO" /><!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
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
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="right" colspan="2">
                            </td>
                            <td>
                            </td>
                            <td align="center" colspan="3">
                            </td>
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
                    <legend>维护考核项目</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 10%; height: 15px;" align="center">
                                <asp:Label ID="Label3" runat="server" CssClass="STYLE2" Text="考核项目:"></asp:Label>
                                <asp:Label ID="LblRecordIsSearch" runat="server" Text="检索前" Visible="false"></asp:Label>
                            </td>
                            <td style="width: 20%; height: 15px;">
                                <asp:TextBox ID="TxtItem1" runat="server" Width="155px"></asp:TextBox>
                            </td>
                            <td style="width: 10%; height: 15px;" align="center">
                                <asp:Label ID="Label4" runat="server" CssClass="STYLE2" Text="考核内容:"></asp:Label>
                            </td>
                            <td style="width: 20%; height: 15px;">
                                <asp:TextBox ID="TxtItem2" runat="server" Width="155px"></asp:TextBox>
                            </td>
                            <td style="width: 10%; height: 15px;" align="center">
                                <asp:Label ID="Label5" runat="server" CssClass="STYLE2" Text="考核标准:"></asp:Label>
                            </td>
                            <td style="width: 20%; height: 15px;">
                                <asp:TextBox ID="TxtItem3" runat="server" Width="155px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" colspan="2">
                                <asp:Label ID="Label48" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Label ID="Label49" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Label ID="LabelForSum" runat="server" Text="翻页前" Visible="false"></asp:Label>
                                <asp:Button ID="ButtonItem1" runat="server" CssClass="Button02" Height="24px" Text="检索"
                                    Width="70px" OnClick="ItemBtnSearch_Click" CausesValidation="False" />
                            </td>
                            <td align="center" colspan="2">
                                <asp:Button ID="ButtonItem2" runat="server" CssClass="Button02" Height="24px" Text="新增考核项目"
                                    Width="91px" OnClick="ItemBtnNew_Click" CausesValidation="False" />
                            </td>
                            <td align="left" colspan="2">
                                <asp:Button ID="ButtonItem3" runat="server" CssClass="Button02" Height="24px" Text="重置"
                                    Visible="true" Width="70px" OnClick="BtnReset_Item" CausesValidation="False" />
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView2" runat="server" AllowSorting="True" DataKeyNames="HRPI_ItemID"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                        AllowPaging="True" PageSize="5" Font-Strikeout="False" GridLines="None" UseAccessibleHeader="False"
                        OnRowCancelingEdit="Grid_Type_RowCancelingEdit" OnRowCommand="Grid_Type_RowCommand"
                        OnRowEditing="Grid_Type_RowEditing" OnDataBound="Grid_Type_RowDataBound_Item"
                        OnRowUpdating="Grid_Type_RowUpdating_Item" OnPageIndexChanging="Grid_Type_PageIndexChangingItem">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="HRPI_ItemID" HeaderText="考核项目ID" SortExpression="HRPI_ItemID"
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
                            <asp:BoundField DataField="HRPI_AssStandard" HeaderText="考核标准" SortExpression="HRPI_AssStandard">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="HRPI_Remarks" HeaderText="备注" SortExpression="HRPI_Remarks">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnEdit_Post" runat="server" CommandArgument='<%#Eval("HRPI_ItemID")%>'
                                        CommandName="Edit_Post" OnClientClick="false">编辑</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnDelete_Type" runat="server" CommandName="Delete_Type_Item"
                                        OnClientClick="return confirm('您确认删除该记录吗?')" CommandArgument='<%#Eval("HRPI_ItemID")%>'>删除</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第<asp:Label ID="lblPageIndex" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                        页 共<asp:Label ID="lblPageCount" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageCount  %>" />
                                        页
                                        <asp:LinkButton ID="btnFirst" runat="server" CausesValidation="False" CommandArgument="First"
                                            CommandName="Page" Text="首页" />
                                        <asp:LinkButton ID="btnPrev" runat="server" CausesValidation="False" CommandArgument="Prev"
                                            CommandName="Page" Text="上一页" />
                                        <asp:LinkButton ID="btnNext" runat="server" CausesValidation="False" CommandArgument="Next"
                                            CommandName="Page" Text="下一页" />
                                        <asp:LinkButton ID="btnLast" runat="server" CausesValidation="False" CommandArgument="Last"
                                            CommandName="Page" Text="尾页" />
                                        <asp:TextBox ID="textboxItem" runat="server" Width="20px"></asp:TextBox>
                                        <%--<asp:textbox id="txtNewPageIndex" runat="server" width="20px" text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />--%>
                                        <asp:LinkButton ID="btnItemGo" runat="server" CausesValidation="False" CommandArgument="-1"
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
                        <tr align="center">
                            <td style="width: 15%; height: 15px;" align="center">
                                <asp:Label ID="Label20" runat="server" CssClass="STYLE2" Text="标准得分总和："></asp:Label>
                            </td>
                            <td style="width: 10%; height: 15px;">
                                <asp:TextBox ID="TextBox1" runat="server" Width="50px" Enabled="False"></asp:TextBox>
                            </td>
                            <td style="width: 50%; height: 15px;" align="center">
                                <asp:Button ID="BtnCancelItem" runat="server" Width="70px" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="BtnCancelItem_Click" />
                            </td>
                            <td >
                            </td>
                        </tr>
                    </table>
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
                    <legend>考核项目<asp:Label ID="LblState" runat="server" Text="" Visible="False"></asp:Label></legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 15%; height: 16px;" align="center">
                                <asp:Label ID="Label6" runat="server" CssClass="STYLE2" Text="考核项目:"></asp:Label>
                            </td>
                            <td style="width: 10%; height: 16px;">
                                <asp:TextBox ID="TextBox_newItem1" runat="server" Width="155px" MaxLength="50"></asp:TextBox>
                                <asp:Label ID="Label35" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                            <td style="width: 15%; height: 16px;" align="center">
                                <asp:Label ID="Label10" runat="server" CssClass="STYLE2" Text="标准得分:"></asp:Label>
                            </td>
                            <td style="width: 20%; height: 16px;">
                                <asp:TextBox ID="TextBox_newItem3" runat="server" Width="155px" MaxLength="3" onkeyup="this.value=this.value.replace(/[^\d{1,2}]/g,'')"
                                    onafterpaste="this.value=this.value.replace(/[^\d{1,2}]/g,'')"></asp:TextBox>
                                
                            </td>
                            <td>
                                <asp:Label ID="Label36" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 15%; height: 16px;" align="center">
                                <asp:Label ID="Label7" runat="server" CssClass="STYLE2" Text="考核内容:"></asp:Label>
                            </td>
                            <td style="width: 10%; height: 16px;">
                                <asp:TextBox ID="TextBox_newItem2" runat="server" Width="450px" MaxLength="100"></asp:TextBox>
                                
                            </td>
                            <td>
                                <asp:Label ID="Label37" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 15%; height: 16px;" align="center">
                                <asp:Label ID="Label8" runat="server" CssClass="STYLE2" Text="考核标准:"></asp:Label>
                            </td>
                            <td style="width: 10%; height: 16px;">
                                <asp:TextBox ID="TextBox_newItem4" runat="server" Width="450px" MaxLength="100"></asp:TextBox>
                                
                            </td>
                            <td>
                                <asp:Label ID="Label38" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label9" runat="server" CssClass="STYLE2" Text="检索前" Visible="false"></asp:Label>
                                <asp:Label ID="Label33" runat="server" CssClass="STYLE2" Text="备注(200字以内)"></asp:Label>
                            </td>
                            <td colspan="4">
                                <asp:TextBox ID="TextBox_newItem5" runat="server" Width="600px" Height="70px" TextMode="MultiLine"
                                    onkeyup="this.value = this.value.substring(0, 200)" onafterpaste="this.value = this.value.substring(0, 200)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="Button1" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    Width="70px" OnClick="BtnSubmit_Item" />
                            </td>
                            <td colspan="3" align="left">
                                <asp:Button ID="Button2" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    Visible="true" Width="70px" OnClick="BtnCancel_Item" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdatePanel_SearchEmployee" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="DdlSearchDep" />
        </Triggers>
        <ContentTemplate>
            <asp:Panel ID="Panel_SearchEmployee" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="LblTheSet2" runat="server" Text=""></asp:Label>员工信息栏</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label11" runat="server" CssClass="STYLE2" Text="工号：" Enabled="False"></asp:Label>
                                <asp:Label ID="LabelForSearchEmployee" runat="server" Text="检索前" Visible="false"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TxtSearchStaffNO" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label12" runat="server" CssClass="STYLE2" Text="姓名：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TxtSearchName" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label13" runat="server" CssClass="STYLE2" Text="部门：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:DropDownList ID="DdlSearchDep" runat="server" ToolTip="单击选择" AutoPostBack="true"
                                    OnSelectedIndexChanged="DdlSearchDep_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label14" runat="server" CssClass="STYLE2" Text="岗位：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:DropDownList ID="DdlSearchPost" runat="server" ToolTip="单击选择">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" align="right">
                                <asp:Label ID="LblBindSAS_ASID" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Button ID="BtnSearchEmployee" runat="server" CssClass="Button02" Height="24px"
                                    Text="检索" Width="70px" OnClick="BtnSearchEmployee_Click" />
                            </td>
                            <td colspan="2" align="center">
                                <asp:Button ID="BtnAddEmployee" runat="server" CssClass="Button02" Height="24px"
                                    Width="90px" Text="新增员工" OnClick="BtnAddEmployee_Click" />
                            </td>
                            <td colspan="3" align="left">
                                <asp:Button ID="BtnResetEmployee" runat="server" CssClass="Button02" Height="24px"
                                    Width="70px" Text="重置" OnClick="BtnResetEmployee_Click" />
                            </td>
                        </tr>
                    </table>
                
    <asp:UpdatePanel ID="UpdatePanel_Grid_Detail" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="DdlSearchDep" />
        </Triggers>
        <ContentTemplate>
            <asp:Panel ID="Panel_Grid_Detail" runat="server" Visible="false">
                
                    <table style="width: 100%;">
                        <tr>
                            <td colspan="8">
                                <fieldset>
                                    <legend>属于该考核类型的员工列表</legend>
                                    <asp:GridView ID="Grid_Detail" runat="server" DataKeyNames="HRDD_ID" AllowSorting="True"
                                        AutoGenerateColumns="False" CssClass="GridViewStyle" Width="100%" AllowPaging="True"
                                        PageSize="5" GridLines="None" OnRowCommand="Grid_Detail_RowCommand" OnPageIndexChanging="Grid_Detail_PageIndexChanging"
                                        OnDataBound="Grid_Detail_DataBound">
                                        <RowStyle CssClass="GridViewRowStyle" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                        <HeaderStyle CssClass="GridViewHead" />
                                        <FooterStyle CssClass="GridViewFooterStyle" />
                                        <Columns>
                                            <asp:BoundField DataField="HRDD_ID" HeaderText="人事档案ID" SortExpression="HRDD_ID"
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
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbtnDelete_Detail" runat="server" CommandName="Delete_Detail"
                                                        OnClientClick="return confirm('您确认删除该记录吗?')" CommandArgument='<%#Eval("HRDD_ID")%>'>删除</asp:LinkButton>
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
                                                        <asp:TextBox ID="textbox5" runat="server" Width="20px"></asp:TextBox>
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
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
                <table style="width: 100%;">
                    <tr >
                        <td align="center">
                            <asp:Button ID="Button_Cancel_Employee" runat="server" Width="70px" Text="关闭" CssClass="Button02" Height="24px"
                                OnClick="BtnCancelEmployee_Click" />
                        </td>
                    </tr>
                </table>
    </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_AddEmployee" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="DdlAddDep" />
        </Triggers>
        <ContentTemplate>
            <asp:Panel ID="Panel_AddEmployee" runat="server" Visible="false">
                <fieldset>
                    <legend>员工新增栏</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label15" runat="server" CssClass="STYLE2" Text="工号：" Enabled="False"></asp:Label>
                                <asp:Label ID="LabelForAddEmployee" runat="server" Text="检索前" Visible="false"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TxtAddStaffNO" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label17" runat="server" CssClass="STYLE2" Text="姓名：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TxtAddName" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label18" runat="server" CssClass="STYLE2" Text="部门：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:DropDownList ID="DdlAddDep" runat="server" ToolTip="单击选择" AutoPostBack="true"
                                    OnSelectedIndexChanged="DdlAddDep_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label19" runat="server" CssClass="STYLE2" Text="岗位：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:DropDownList ID="DdlAddPost" runat="server" ToolTip="单击选择">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center">
                                <asp:Button ID="BtnAddSearch" runat="server" CssClass="Button02" Height="24px" Text="检索"
                                    Width="70px" OnClick="BtnAddSearch_Click" />
                            </td>
                            <td colspan="4" align="center">
                                <asp:Button ID="BtnAddReset" runat="server" CssClass="Button02" Height="24px" Width="70px"
                                    Text="重置" OnClick="BtnAddReset_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="8">
                                <fieldset>
                                    <legend>员工列表</legend>
                                    <asp:GridView ID="GridViewAdd" runat="server" DataKeyNames="HRDD_ID" AllowSorting="True"
                                        AutoGenerateColumns="False" CssClass="GridViewStyle" Width="100%" AllowPaging="True"
                                        PageSize="40" GridLines="None" OnPageIndexChanging="GridViewAdd_PageIndexChanging"
                                        EnableModelValidation="True">
                                        <RowStyle CssClass="GridViewRowStyle" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                        <HeaderStyle CssClass="GridViewHead" />
                                        <FooterStyle CssClass="GridViewFooterStyle" />
                                        <Columns>
                                            <asp:BoundField DataField="HRDD_ID" HeaderText="人事档案ID" SortExpression="HRDD_ID">
                                                <FooterStyle CssClass="hidden" />
                                                <HeaderStyle CssClass="hidden" />
                                                <ItemStyle CssClass="hidden" />
                                            </asp:BoundField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
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
                                                        <asp:TextBox ID="textbox6" runat="server" Width="20px"></asp:TextBox>
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
                        <tr>
                            <td>
                            </td>
                            <td colspan="2" align="right">
                                <asp:CheckBox ID="Cbx_SelectAll" runat="server" Text="当前页全选" AutoPostBack="true" OnCheckedChanged="Cbx_SelectAll_CheckedChanged" />
                            </td>
                            <td colspan="2" align="center">
                                <asp:CheckBox ID="Cbx_SelectAllCancel" runat="server" Text="当前页全不选" AutoPostBack="true"
                                    OnCheckedChanged="Cbx_SelectAllCancel_CheckedChanged" />
                            </td>
                            <td colspan="2" align="left">
                                <asp:CheckBox ID="Cbx_SelectOpposite" runat="server" Text="当前页反选" AutoPostBack="true"
                                    OnCheckedChanged="Cbx_SelectOpposite_CheckedChanged" />
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center">
                                <asp:Button ID="BtnAddSubmit" runat="server" CssClass="Button02" Height="24px" Text="提交"
                                    Width="70px" OnClick="BtnAddSubmit_Click" />
                            </td>
                            <td colspan="4" align="center">
                                <asp:Button ID="BtnAddCancel" runat="server" CssClass="Button02" Height="24px" Width="70px"
                                    Text="关闭" OnClick="BtnAddCancel_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
