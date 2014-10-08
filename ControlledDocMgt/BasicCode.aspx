<%@ Page Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true" CodeFile="BasicCode.aspx.cs" Inherits="ControlledDocMgt_BasicCode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:Label ID="Lab_Status" runat="server" Visible="false"></asp:Label>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <fieldset>
                <legend>部门代号维护</legend>
                <%--部门代号检索--%>
                <asp:UpdatePanel ID="UpdatePanel_SearchBDOS" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <%--<fieldset>
                            <legend>检索</legend>--%>
                            <table style="width: 100%;">
                                <tr style="height: 16px;">
                                    <td style="width: 20%" align="right">
                                        <asp:Label ID="Lbltype" runat="server" Text="部门："></asp:Label>
                                    </td>
                                    <td style="width: 20%" align="left">
                                        <asp:DropDownList ID="DropDownList1" runat="server" Height="20px" Width="150px">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 22%" align="right">
                                        <asp:Label ID="Label1" runat="server" Text="部门代号："></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="TextBDOScode" runat="server" Width="150px" Height="20px" MaxLength="20"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:Button ID="Btn_SearchBDOS" runat="server" Text="检索" Width="70px" CssClass="Button02"
                                            OnClick="Btn_SearchBDOS_Click" />
                                    </td>
                                    <td>
                                        <asp:Button ID="Btn_NewBDOS" runat="server" Text="新增部门代号" Width="90px" CssClass="Button02"
                                            OnClick="Btn_NewBDOS_Click" />
                                    </td>
                                    <td>
                                        <asp:Button ID="Btn_ClearBDOS" runat="server" CssClass="Button02" Text="重置" Width="70px"
                                            OnClick="Btn_ClearBDOS_Click" />
                                    </td>
                                </tr>
                            </table>
                        <%--</fieldset>--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <%--部门及代号列表--%>
                <asp:UpdatePanel ID="UpdatePanel_BDOS" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel_BDOS" runat="server">
                            <%--<fieldset>
                                <legend>列表</legend>--%>
                                <asp:GridView ID="Grid_BDOS" runat="server" DataKeyNames="BDOS_Code" AllowSorting="True"
                                    AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                                    AllowPaging="True" PageSize="5" Font-Strikeout="False" UseAccessibleHeader="False"
                                    OnPageIndexChanging="Grid_BDOS_PageIndexChanging" OnRowCommand="Grid_BDOS_RowCommand"
                                    OnRowDataBound="Grid_BDOS_RowDataBound" GridLines="None" OnRowCancelingEdit="Grid_BDOS_RowCancelingEdit"
                                    OnRowEditing="Grid_BDOS_RowEditing" OnRowUpdating="Grid_BDOS_RowUpdating">
                                    <RowStyle CssClass="GridViewRowStyle" />
                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                    <HeaderStyle CssClass="GridViewHead" />
                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                    <Columns>
                                        <asp:BoundField DataField="BDOS_Code" HeaderText="组织机构ID" ReadOnly="True" SortExpression="BDOS_Code"
                                            Visible="False">
                                            <ItemStyle />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="BDOS_Name" HeaderText="部门" ReadOnly="True" SortExpression="BDOS_Name">
                                            <ItemStyle />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="BDOS_DepCode" HeaderText="部门代号" SortExpression="BDOS_DepCode">
                                            <ItemStyle />
                                        </asp:BoundField>
                                        <%--<asp:BoundField DataField="BDOS_No" HeaderText="编号随机码起点" SortExpression="BDOS_No">
                                            <ItemStyle />
                                        </asp:BoundField>--%>
                                        <asp:TemplateField SortExpression="BDOS_No" HeaderText="自动编号起始位">
                                            <ItemTemplate>
                                                <asp:Label ID="BDOS_No" runat="server" Text='<%# Eval("BDOS_No") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="BDOS_No" runat="server" onkeyup="this.value=this.value.replace(/[^0-9]/g,'')" 
                                                 onafterpaste="this.value=this.value.replace(/[^[0-9]/g,'')" MaxLength="10" 
                                                    Text='<%# Eval("BDOS_No") %>' ></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemStyle/>
                                        </asp:TemplateField>
                                        <asp:CommandField ShowEditButton="True" EditText="编辑" UpdateText="更新" CancelText="取消">
                                            <ItemStyle />
                                        </asp:CommandField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="Delete_BDOS" runat="server" CommandName="Delete_BDOS" OnClientClick="return confirm('您确认删除该记录吗?')"
                                                    CommandArgument='<%#Eval("BDOS_Code")%>'>删除</asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle />
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerTemplate>
                                        <table width="100%">
                                            <tr>
                                                <td style="text-align: right">
                                                    第<asp:Label ID="lblPageIndex" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>' />
                                                    页 共<asp:Label ID="lblPageCount" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />
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
                                                    <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                                        CommandName="Page" Text="GO" /><!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
                                                </td>
                                            </tr>
                                        </table>
                                    </PagerTemplate>
                                    <EmptyDataTemplate>
                                        <asp:Label ID="Label16" runat="server" Text="没有找到相关记录"></asp:Label>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            <%--</fieldset>--%>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <%--新增部门代号--%>
                <asp:UpdatePanel ID="UpdatePanel_NewBDOS" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel_NewBDOS" runat="server" Visible="false">
                            <fieldset>
                                <legend>新增部门代号</legend>
                                <table style="width: 100%;">
                                    <tr style="height: 16px;">
                                        <td style="width: 10%" align="right">
                                            <asp:Label ID="Label2" runat="server" Text="部门："></asp:Label>
                                        </td>
                                        <td style="width: 22%" align="left">
                                            <asp:DropDownList ID="DropDownList2" runat="server" Height="20px" Width="150px">
                                            </asp:DropDownList>
                                            <asp:Label ID="Label14" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                                ControlToValidate="DropDownList2" ValidationGroup="addvalidation_NewBDOS"></asp:RequiredFieldValidator>--%>
                                        </td>
                                        <td style="width: 10%" align="right">
                                            <asp:Label ID="Label3" runat="server" Text="部门代号："></asp:Label>
                                        </td>
                                        <td align="left" style="width: 22%">
                                            <asp:TextBox ID="newBDOScode" runat="server" Width="150px" Height="20px" MaxLength="20"></asp:TextBox>
                                            <asp:Label ID="Label15" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                           <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                                ControlToValidate="newBDOScode" ValidationGroup="addvalidation_NewBDOS"></asp:RequiredFieldValidator>--%>
                                        </td>
                                        <td style="width: 15%" align="right">
                                            <asp:Label ID="Label4" runat="server" Text="自动编号起始位："></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="TextBox4" runat="server" Width="150px" Height="20px" MaxLength="10" 
                                onkeyup="this.value=this.value.replace(/[^0-9]/g,'')" onafterpaste="this.value=this.value.replace(/[^[0-9]/g,'')" ></asp:TextBox>
                                            <asp:Label ID="Label7" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 30px;" align="right" colspan="2">
                                            <%--<asp:Button ID="BtnOK_NewBDOS" runat="server" Text="提交" Width="70px" CssClass="Button02"
                                                OnClick="BtnOK_NewBDOS_Click" ValidationGroup="addvalidation_NewBDOS" />--%>
                                                <asp:Button ID="BtnOK_NewBDOS" runat="server" Text="提交" Width="70px" CssClass="Button02"
                                                OnClick="BtnOK_NewBDOS_Click" />
                                        </td>
                                        <td style="height: 30px;" align="right" colspan="2">
                                        </td>
                                        <td style="height: 30px;" align="left">
                                            <asp:Button ID="BtnCancel_NewBDOS" runat="server" Text="关闭" CssClass="Button02" Width="70px"
                                                OnClick="BtnCancel_NewBDOS_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </fieldset>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <fieldset>
                <legend>文件发放号维护</legend>
                <%--文件发放号检索--%>
                <asp:UpdatePanel ID="UpdatePanel_SearchCDDep" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <%--<fieldset>
                            <legend>检索</legend>--%>
                            <table style="width: 100%;">
                                <tr style="height: 16px;">
                                    <%--<td style="width: 14%" align="right">
                                        <asp:Label ID="Label4" runat="server" Text="部门："></asp:Label>
                                    </td>
                                    <td style="width: 18%" align="left">
                                        <asp:DropDownList ID="DropDownList3" runat="server" Height="20px" Width="150px">
                                        </asp:DropDownList>
                                    </td>--%>
                                    <td style="width: 20%" align="right">
                                        <asp:Label ID="Label5" runat="server" Text="岗位："></asp:Label>
                                    </td>
                                    <td style="width: 20%" align="left">
                                        <asp:TextBox ID="TextDep" runat="server" Width="150px" Height="20px" MaxLength="10"></asp:TextBox>
                                    </td>
                                    <td style="width: 22%" align="right">
                                        <asp:Label ID="Label6" runat="server" Text="分发号："></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="TextCode" runat="server" Width="150px" Height="20px" MaxLength="20"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="left">
                                        <asp:Button ID="Btn_SearchCDDep" runat="server" Text="检索" Width="70px" CssClass="Button02"
                                            OnClick="Btn_SearchCDDep_Click" />
                                    </td>
                                    <td >
                                        <asp:Button ID="Btn_NewCDDep" runat="server" Text="新增文件发放号" Width="110px" CssClass="Button02"
                                            OnClick="Btn_NewCDDep_Click" />
                                    </td>
                                    <td>
                                        <asp:Button ID="Btn_ClearCDDep" runat="server" CssClass="Button02" Text="重置" Width="70px"
                                            OnClick="Btn_ClearCDDep_Click" />
                                    </td>
                                </tr>
                            </table>
                        <%--</fieldset>--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <%--岗位分发代号列表--%>
                <asp:UpdatePanel ID="UpdatePanel_CDDep" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel_CDDep" runat="server">
                            <%--<fieldset>
                                <legend>列表</legend>--%>
                                <asp:GridView ID="Grid_CDDep" runat="server" DataKeyNames="CDDDCT_ID" AllowSorting="True"
                                    AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                                    AllowPaging="True" PageSize="5" Font-Strikeout="False" UseAccessibleHeader="False"
                                    OnPageIndexChanging="Grid_CDDep_PageIndexChanging" OnRowCommand="Grid_CDDep_RowCommand"
                                    OnRowDataBound="Grid_CDDep_RowDataBound" GridLines="None" OnRowCancelingEdit="Grid_CDDep_RowCancelingEdit"
                                    OnRowEditing="Grid_CDDep_RowEditing" OnRowUpdating="Grid_CDDep_RowUpdating">
                                    <RowStyle CssClass="GridViewRowStyle" />
                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                    <HeaderStyle CssClass="GridViewHead" />
                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                    <Columns>
                                        <asp:BoundField DataField="CDDDCT_ID" HeaderText="岗位分发号代号ID" ReadOnly="True" SortExpression="CDDDCT_ID"
                                            Visible="False">
                                            <ItemStyle />
                                        </asp:BoundField>
                                        <%--<asp:BoundField DataField="BDOS_Name" HeaderText="部门" ReadOnly="True" SortExpression="BDOS_Name">
                                            <ItemStyle />
                                        </asp:BoundField>--%>
                                        <asp:BoundField DataField="CDDDCT_Dep" HeaderText="岗位" SortExpression="CDDDCT_Dep" ReadOnly="True" >
                                            <ItemStyle />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CDDDCT_Code" HeaderText="分发号" SortExpression="CDDDCT_Code">
                                            <ItemStyle />
                                        </asp:BoundField>
                                        <asp:CommandField ShowEditButton="True" EditText="编辑" UpdateText="更新" CancelText="取消">
                                            <ItemStyle />
                                        </asp:CommandField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="Delete_CDDep" runat="server" CommandName="Delete_CDDep" OnClientClick="return confirm('您确认删除该记录吗?')"
                                                    CommandArgument='<%#Eval("CDDDCT_ID")%>'>删除</asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle />
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerTemplate>
                                        <table width="100%">
                                            <tr>
                                                <td style="text-align: right">
                                                    第<asp:Label ID="lblPageIndex" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>' />
                                                    页 共<asp:Label ID="lblPageCount" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />
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
                                </asp:GridView>
                            <%--</fieldset>--%>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <%--新增文件发放号--%>
                <asp:UpdatePanel ID="UpdatePanel_NewCDDep" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel_NewCDDep" runat="server" Visible="false">
                            <fieldset>
                                <legend>新增文件发放号</legend>
                                <table style="width: 100%;">
                                    <tr style="height: 16px;">
                                        <%--<td style="width: 12%" align="right">
                                            <asp:Label ID="Label7" runat="server" Text="部门："></asp:Label>
                                        </td>
                                        <td style="width: 22%" align="left">
                                            <asp:DropDownList ID="DropDownList4" runat="server" Height="20px" Width="150px">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                                ControlToValidate="DropDownList4" ValidationGroup="addvalidation_NewCDDep"></asp:RequiredFieldValidator>
                                        </td>--%>
                                        <td style="width: 20%" align="right">
                                            <asp:Label ID="Label8" runat="server" Text="岗位："></asp:Label>
                                        </td>
                                        <td style="width: 22%" align="left">
                                            <asp:TextBox ID="newCDdep" runat="server" Width="150px" Height="20px" MaxLength="10"></asp:TextBox>
                                            <asp:Label ID="Label18" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                                                ControlToValidate="newCDdep" ValidationGroup="addvalidation_NewCDDep"></asp:RequiredFieldValidator>--%>
                                        </td>
                                        <td style="width: 14%" align="right">
                                            <asp:Label ID="Label9" runat="server" Text="分发号："></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="newCDcode" runat="server" Width="150px" Height="20px" MaxLength="20"></asp:TextBox>
                                            <asp:Label ID="Label19" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*"
                                                ControlToValidate="newCDcode" ValidationGroup="addvalidation_NewCDDep"></asp:RequiredFieldValidator>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td style="height: 30px;" align="center" colspan="2">
                                            <%--<asp:Button ID="BtnOK_NewCDDep" runat="server" Text="提交" Width="70px" CssClass="Button02"
                                                OnClick="BtnOK_NewCDDep_Click" ValidationGroup="addvalidation_NewCDDep" />--%>
                                             <asp:Button ID="BtnOK_NewCDDep" runat="server" Text="提交" Width="70px" CssClass="Button02"
                                                OnClick="BtnOK_NewCDDep_Click"/>
                                        </td>
                                        <td >
                                            <asp:Button ID="BtnCancel_NewCDDep" runat="server" Text="关闭" CssClass="Button02"
                                                Width="70px" OnClick="BtnCancel_NewCDDep_Click" />
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </fieldset>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <fieldset>
                <legend>第三层次文件类别代号维护</legend>
                <%--第三层次文件类别代号检索--%>
                <asp:UpdatePanel ID="UpdatePanel_SearchThird" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <%--<fieldset>
                            <legend>检索</legend>--%>
                            <table style="width: 100%;">
                                <tr style="height: 16px;">
                                    <td style="width: 20%" align="right">
                                        <asp:Label ID="Label10" runat="server" Text="文件类别："></asp:Label>
                                    </td>
                                    <td style="width: 20%" align="left">
                                        <asp:TextBox ID="TextType" runat="server" Width="150px" Height="20px" MaxLength="20"></asp:TextBox>
                                    </td>
                                    <td style="width: 22%" align="right">
                                        <asp:Label ID="Label11" runat="server" Text="文件类别代号："></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="TextDocCode" runat="server" Width="150px" Height="20px" MaxLength="20"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:Button ID="Btn_SearchThird" runat="server" Text="检索" Width="70px" CssClass="Button02"
                                            OnClick="Btn_SearchThird_Click" />
                                    </td>
                                    <td>
                                        <asp:Button ID="Btn_NewThird" runat="server" Text="新增文件类别代号" Width="110px" CssClass="Button02"
                                            OnClick="Btn_NewThird_Click" />
                                    </td>
                                    <td  >
                                        <asp:Button ID="Btn_ClearThird" runat="server" CssClass="Button02" Text="重置" Width="70px"
                                            OnClick="Btn_ClearThird_Click" />
                                    </td>
                                </tr>
                            </table>
                        <%--</fieldset>--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <%--第三层次文件类别代号列表--%>
                <asp:UpdatePanel ID="UpdatePanel_Third" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel_Third" runat="server">
                           <%-- <fieldset>
                                <legend>列表</legend>--%>
                                <asp:GridView ID="Grid_Third" runat="server" DataKeyNames="CDTLC_ID" AllowSorting="True"
                                    AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                                    AllowPaging="True" PageSize="5" Font-Strikeout="False" UseAccessibleHeader="False"
                                    OnPageIndexChanging="Grid_Third_PageIndexChanging" OnRowCommand="Grid_Third_RowCommand"
                                    OnRowDataBound="Grid_Third_RowDataBound" GridLines="None" OnRowCancelingEdit="Grid_Third_RowCancelingEdit"
                                    OnRowEditing="Grid_Third_RowEditing" OnRowUpdating="Grid_Third_RowUpdating">
                                    <RowStyle CssClass="GridViewRowStyle" />
                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                    <HeaderStyle CssClass="GridViewHead" />
                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                    <Columns>
                                        <asp:BoundField DataField="CDTLC_ID" HeaderText="第三层次受控文件代号ID" ReadOnly="True" SortExpression="CDTLC_ID"
                                            Visible="False">
                                            <ItemStyle />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CDTLC_DocType" HeaderText="文件类别" SortExpression="CDTLC_DocType" ReadOnly="true">
                                            <ItemStyle />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CDTLC_Code" HeaderText="文件类别代号" SortExpression="CDTLC_Code">
                                            <ItemStyle />
                                        </asp:BoundField>
                                        <asp:CommandField ShowEditButton="True" EditText="编辑" UpdateText="更新" CancelText="取消">
                                            <ItemStyle />
                                        </asp:CommandField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="Delete_Third" runat="server" CommandName="Delete_Third" OnClientClick="return confirm('您确认删除该记录吗?')"
                                                    CommandArgument='<%#Eval("CDTLC_ID")%>'>删除</asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle />
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerTemplate>
                                        <table width="100%">
                                            <tr>
                                                <td style="text-align: right">
                                                    第<asp:Label ID="lblPageIndex" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>' />
                                                    页 共<asp:Label ID="lblPageCount" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />
                                                    页
                                                    <asp:LinkButton ID="btnFirst" runat="server" CausesValidation="False" CommandArgument="First"
                                                        CommandName="Page" Text="首页" />
                                                    <asp:LinkButton ID="btnPrev" runat="server" CausesValidation="False" CommandArgument="Prev"
                                                        CommandName="Page" Text="上一页" />
                                                    <asp:LinkButton ID="btnNext" runat="server" CausesValidation="False" CommandArgument="Next"
                                                        CommandName="Page" Text="下一页" />
                                                    <asp:LinkButton ID="btnLast" runat="server" CausesValidation="False" CommandArgument="Last"
                                                        CommandName="Page" Text="尾页" />
                                                    <asp:TextBox ID="textbox3" runat="server" Width="20px"></asp:TextBox>
                                                    <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                                        CommandName="Page" Text="GO" /><!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
                                                </td>
                                            </tr>
                                        </table>
                                    </PagerTemplate>
                                    <EmptyDataTemplate>
                                        <asp:Label ID="Label16" runat="server" Text="没有找到相关记录"></asp:Label>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            <%--</fieldset>--%>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <%--新增第三层次文件类别代号--%>
                <asp:UpdatePanel ID="UpdatePanel_NewThird" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel_NewThird" runat="server" Visible="false">
                            <fieldset>
                                <legend>新增文件类别代号</legend>
                                <table style="width: 100%;">
                                    <tr style="height: 16px;">
                                        <td style="width: 20%" align="right">
                                            <asp:Label ID="Label12" runat="server" Text="文件类别："></asp:Label>
                                        </td>
                                        <td style="width: 22%" align="left">
                                            <asp:TextBox ID="newType" runat="server" Width="150px" Height="20px" MaxLength="20"></asp:TextBox>
                                            <asp:Label ID="Label20" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*"
                                                ControlToValidate="newType" ValidationGroup="addvalidation_NewThird"></asp:RequiredFieldValidator>--%>
                                        </td>
                                        <td style="width: 14%" align="right">
                                            <asp:Label ID="Label13" runat="server" Text="文件类别代号："></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="newDocCode" runat="server" Width="150px" Height="20px" MaxLength="20"></asp:TextBox>
                                            <asp:Label ID="Label21" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*"
                                                ControlToValidate="newDocCode" ValidationGroup="addvalidation_NewThird"></asp:RequiredFieldValidator>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 30px;" align="right" colspan="2">
                                            <asp:Button ID="BtnOK_NewThird" runat="server" Text="提交" Width="70px" CssClass="Button02"
                                                OnClick="BtnOK_NewThird_Click" ValidationGroup="addvalidation_NewThird" />
                                            <%--<asp:Button ID="BtnOK_NewThird" runat="server" Text="提交" Width="70px" CssClass="Button02"
                                                OnClick="BtnOK_NewThird_Click"/>--%>
                                        </td>
                                        <td style="height: 30px;" align="right">
                                        </td>
                                        <td style="height: 30px;" align="left">
                                            <asp:Button ID="BtnCancel_NewThird" runat="server" Text="关闭" CssClass="Button02"
                                                Width="70px" OnClick="BtnCancel_NewThird_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </fieldset>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
