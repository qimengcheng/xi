<%@ Page Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true"
    CodeFile="EMEquipType.aspx.cs" Inherits="EquipMgt_EMEquipType" Title="设备类型管理" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <%--设备类型检索--%>
    <asp:UpdatePanel ID="UpdatePanel_Search" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <fieldset>
                <legend>设备类型检索</legend>
                <table style="width: 100%;">
                    <tr style="height: 16px;">
                        <td style="width: 21%" align="right">
                            <asp:Label ID="Lbltype" runat="server" Text="设备类型："></asp:Label>
                        </td>
                        <td style="width: 31%" align="left">
                            <asp:TextBox ID="Txtname" runat="server" Width="150px" Height="20px" MaxLength="10"></asp:TextBox>
                        </td>
                        <td style="width: 13%;">
                            <asp:Button ID="Btn_Search" runat="server" Text="检索" Width="70px" CssClass="Button02"
                                OnClick="Btn_Search_Click" Height="24px" />
                        </td>
                        <td style="width: 15%;">
                            <asp:Button ID="Btn_New" runat="server" Text="新增设备类型" Width="90px" CssClass="Button02"
                                OnClick="Btn_New_Click" Height="24px" />
                        </td>
                        <td>
                            <asp:Button ID="Btn_Clear" runat="server" CssClass="Button02" Text="重置" Width="70px"
                                OnClick="Btn_Clear_Click" Height="24px" />
                        </td>
                    </tr>
                </table>
            </fieldset>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--设备类型信息表--%>
    <asp:UpdatePanel ID="UpdatePanel_TypeItem" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <fieldset>
                <legend>设备类型信息表</legend>
                <asp:GridView ID="Grid_EquipType" runat="server" DataKeyNames="ETT_ID" AllowSorting="True"
                    AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                    AllowPaging="True" PageSize="10" Font-Strikeout="False" UseAccessibleHeader="False"
                    OnPageIndexChanging="Grid_EquipType_PageIndexChanging" OnRowCommand="Grid_EquipType_RowCommand"
                    OnRowCancelingEdit="Grid_EquipType_RowCancelingEdit" OnRowEditing="Grid_EquipType_RowEditing"
                    OnRowUpdating="Grid_EquipType_RowUpdating" OnRowDataBound="Grid_EquipType_RowDataBound"
                    GridLines="None">
                    <RowStyle CssClass="GridViewRowStyle" />
                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                    <HeaderStyle CssClass="GridViewHead" />
                    <FooterStyle CssClass="GridViewFooterStyle" />
                    <Columns>
                        <asp:BoundField DataField="ETT_ID" HeaderText="设备类型ID" ReadOnly="True" SortExpression="ETT_ID"
                            Visible="False">
                            <ItemStyle Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ETT_Type" HeaderText="设备类型" SortExpression="ETT_Type">
                            <ItemStyle Width="30%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ETT_IsDeleted" HeaderText="是否删除" ReadOnly="True" SortExpression="ETT_IsDeleted"
                            Visible="False">
                            <ItemStyle Width="10%" />
                        </asp:BoundField>
                        <asp:CommandField ShowEditButton="True" EditText="编辑" UpdateText="更新" CancelText="关闭">
                            <ItemStyle Width="10%" />
                        </asp:CommandField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtnDelete_Type" runat="server" CommandName="Delete_Type" OnClientClick="return confirm('您确认删除该记录吗?')"
                                    CommandArgument='<%#Eval("ETT_ID")%>'>删除
                                </asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle Width="10%" />
                        </asp:TemplateField>
                        <%--            <asp:CommandField ShowDeleteButton="True"  />
            <asp:CommandField ShowEditButton="True" />--%>
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
                                    <asp:TextBox ID="textbox" runat="server" Width="20px"></asp:TextBox>
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
            </fieldset>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--弹出框新建模具信息--%>
    <asp:UpdatePanel ID="UpdatePanel_NewType" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_NewType" runat="server" Visible="false">
                <fieldset>
                    <legend>新增设备类别</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 40%;" align="right">
                                <asp:Label ID="Lbl_NewType" runat="server" Text="设备类型："></asp:Label>
                            </td>
                            <td style="width: 60%;" align="left" colspan="2">
                                <asp:TextBox ID="TxtAddType" runat="server" Width="150px" Height="20px" MaxLength="10"></asp:TextBox>
                            <asp:Label ID="Label14" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                    ControlToValidate="TxtAddType" ValidationGroup="addtypevalidation"></asp:RequiredFieldValidator>--%>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Button ID="BtnOK_NewType" runat="server" Text="提交" Width="70px" CssClass="Button02"
                                    OnClick="BtnOK_NewType_Click" ValidationGroup="addtypevalidation" 
                                    Height="24px" />
                            </td>
                            <td style="width: 15%;">
                            </td>
                            <td align="left">
                                <asp:Button ID="BtnCancel_Info_FailureMode" runat="server" Text="关闭" CssClass="Button02"
                                    Width="70px" OnClick="BtnCancel_Info_FailureMode_Click" Height="24px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
