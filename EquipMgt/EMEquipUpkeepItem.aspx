<%@ Page Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true"
    CodeFile="EMEquipUpkeepItem.aspx.cs" Inherits="EquipMgt_EMEquipUpkeepItem" Title="设备保养项目管理" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
    <%--设备保养项目检索--%>
    <asp:UpdatePanel ID="UpdatePanel_Search" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Search" runat="server">
                <fieldset>
                    <legend>设备保养项目检索</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 17%" align="right">
                                <asp:Label ID="Lbltype" runat="server" Text="设备名称："></asp:Label>
                            </td>
                            <td style="width: 18%">
                                <asp:TextBox ID="Textname" runat="server" Width="130px" Height="20px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label1" runat="server" Text="保养项目："></asp:Label>
                            </td>
                            <td style="width: 18%">
                                <asp:TextBox ID="Textitems" runat="server" Width="130px" Height="20px"></asp:TextBox>
                            </td>
                            <td style="width: 12%" align="right">
                                <asp:Label ID="Label2" runat="server" Text="保养周期(月)："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Textperiod" runat="server" Width="130px" Height="20px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td align="right" colspan="2">
                                <asp:Button ID="Btn_Search" runat="server" Text="检索" Width="70px" CssClass="Button02"
                                    OnClick="Btn_Search_Click" Height="24px" />
                            </td>
                            <td style="height: 16px;" align="center" colspan="2">
                                <asp:Button ID="Btn_New" runat="server" Text="新增保养项目" Width="90px" CssClass="Button02"
                                    OnClick="Btn_New_Click" Height="24px" />
                            </td>
                            <td align="left" colspan="2">
                                <asp:Button ID="Btn_Clear" runat="server" CssClass="Button02" Text="重置" Width="70px"
                                    OnClick="Btn_Clear_Click" Height="24px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--设备保养项目信息表--%>
    <asp:UpdatePanel ID="UpdatePanel_Item" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Item" runat="server">
                <fieldset>
                    <legend>设备保养项目信息表</legend>
                    <asp:Label ID="Label_euiid" runat="server" Visible="False"></asp:Label>
                    <asp:GridView ID="Grid_EquipUpkeepItem" runat="server" DataKeyNames="EUI_ID,EN_ID"
                        AllowSorting="True" AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0"
                        Width="100%" AllowPaging="True" PageSize="10" Font-Strikeout="False" UseAccessibleHeader="False"
                        OnPageIndexChanging="Grid_EquipUpkeepItem_PageIndexChanging" OnRowCommand="Grid_EquipUpkeepItem_RowCommand"
                        OnRowDataBound="Grid_EquipUpkeepItem_RowDataBound" GridLines="None" OnRowCancelingEdit="Grid_EquipUpkeepItem_RowCancelingEdit"
                        OnRowEditing="Grid_EquipUpkeepItem_RowEditing" OnRowUpdating="Grid_EquipUpkeepItem_RowUpdating">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="EUI_ID" HeaderText="保养项目ID" ReadOnly="True" SortExpression="EUI_ID"
                                Visible="False">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="EN_ID" HeaderText="设备名称ID" ReadOnly="True" SortExpression="EN_ID"
                                Visible="False">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="EN_EquipName" HeaderText="设备名称" ReadOnly="True" SortExpression="EN_EquipName">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="EUI_Items" HeaderText="保养项目" SortExpression="EUI_Items">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="EUI_Period" HeaderText="保养周期(月)" SortExpression="EUI_Period">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="EUI_IsDeleted" HeaderText="是否删除" ReadOnly="True" SortExpression="EUI_IsDeleted"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:CommandField ShowEditButton="True" EditText="编辑" UpdateText="更新" CancelText="关闭">
                                <ItemStyle Width="10%" />
                            </asp:CommandField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete_Item" runat="server" CommandName="Delete_Item" OnClientClick="return confirm('您确认删除该记录吗?')"
                                        CommandArgument='<%#Eval("EUI_ID")%>'>删除</asp:LinkButton>
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
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--增加保养项目时,首先选择设备名称--%>
    <asp:UpdatePanel ID="UpdatePanel_searchname" runat="server">
        <ContentTemplate>
            <asp:Panel ID="Panel_searchname" runat="server" Visible="false">
                <fieldset>
                    <legend>选择设备名称</legend>
                    <asp:Label ID="Label_nid" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="Label_nname" runat="server" Visible="False"></asp:Label>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 29%" align="right">
                                <asp:Label ID="Label10" runat="server" Text="设备名称："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="Textnameadd" runat="server" Width="130px" Height="20px"></asp:TextBox>
                            </td>
                            <td style="width: 13%">
                                <asp:Button ID="Search_name" runat="server" Text="检索" Width="70px" CssClass="Button02"
                                    OnClick="Search_name_Click" Height="24px" />
                            </td>
                            <td style="width: 13%">
                                <asp:Button ID="Clear_name" runat="server" CssClass="Button02" OnClick="Clear_name_Click"
                                    Text="重置" Width="70px" Height="24px" />
                            </td>
                            <td style="width: 45%">
                                <asp:Button ID="Close_name" runat="server" CssClass="Button02" OnClick="Close_name_Click"
                                    Text="关闭" Width="70px" Height="24px" />
                            </td>
                        </tr>
                    </table>
                    <%-- 设备名称列表--%>
                    <asp:GridView ID="Grid_EquipName" runat="server" DataKeyNames="EN_ID" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                        AllowPaging="True" PageSize="5" Font-Strikeout="False" UseAccessibleHeader="False"
                        OnPageIndexChanging="Grid_EquipName_PageIndexChanging" OnRowCommand="Grid_EquipName_RowCommand"
                        OnRowDataBound="Grid_EquipName_RowDataBound" GridLines="None">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="EN_ID" HeaderText="设备名称ID" ReadOnly="True" SortExpression="EN_ID"
                                Visible="False">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="EN_EquipName" HeaderText="设备名称" SortExpression="EN_EquipName">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Add_Info" runat="server" CommandName="Add_Info" OnClientClick="false"
                                        CommandArgument='<%#Eval("EN_ID")+","+Eval("EN_EquipName")%>'>新增保养项目</asp:LinkButton>
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
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--新增设备保养项目--%>
    <asp:UpdatePanel ID="UpdatePanel_New" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_New" runat="server" Visible="false">
                <fieldset>
                    <legend>新增设备保养项目</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 18%" align="right">
                                <asp:Label ID="Label3" runat="server" Text="设备名称："></asp:Label>
                            </td>
                            <td style="width: 18%">
                                <asp:TextBox ID="Textaddname" runat="server" Width="130px" Height="20px" Enabled="false"></asp:TextBox>
                            </td>
                            
                            
                            <td style="width: 20%" align="right">
                                <asp:Label ID="Label5" runat="server" Text="保养周期(月)："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Textaddperiod" runat="server" Width="130px" Height="20px" MaxLength="16"
                                    onkeyup="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{2,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{2})[0-9]*/, '$1');" 
                              onafterpaste="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{2,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{2})[0-9]*/, '$1');" ></asp:TextBox>
                                <asp:Label ID="Label6" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                    ControlToValidate="Textaddperiod" ValidationGroup="addvalidation"></asp:RequiredFieldValidator>--%>
                                    <%--onkeyup="this.value=this.value.replace(/[^0-9]/g,'')" onafterpaste="this.value=this.value.replace(/[^[0-9]/g,'')"--%>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label4" runat="server" Text="保养项目："></asp:Label>
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="Textadditem" runat="server" Width="550px" Height="20px" MaxLength="50"></asp:TextBox>
                                <asp:Label ID="Label14" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                    ControlToValidate="Textadditem" ValidationGroup="addvalidation"></asp:RequiredFieldValidator>--%>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 30px;" align="right" colspan="2">
                                <asp:Button ID="BtnOK_New" runat="server" Text="提交" Width="70px" CssClass="Button02"
                                    OnClick="BtnOK_New_Click" ValidationGroup="addvalidation" onkeyup="this.value=this.value.replace(/[^0-9]/g,'')"
                                    onafterpaste="this.value=this.value.replace(/[^[0-9]/g,'')" 
                                    Height="24px" />
                            </td>
                            <td></td>
                            <td style="height: 30px;" >
                            <asp:Button ID="BtnCancel_New" runat="server" Text="关闭" CssClass="Button02" Width="70px"
                                    OnClick="BtnCancel_New_Click" Height="24px" />
                            </td>
                            
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
