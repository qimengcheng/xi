<%@ Page Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true"
    CodeFile="EMEquipName_Model.aspx.cs" Inherits="EquipMgt_EMEquipName_Model" Title="设备名称及型号管理" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="Lab_Status" runat="server"  Visible="False"></asp:Label>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script type="text/javascript">
        var last = null;
        function judge1(obj) {
            if (last == null) {
                last = obj.id;
            }
            else {
                var lo = document.getElementById(last);
                lo.checked = false;
                last = obj.id;

            }
            obj.checked = "checked";
        }
    </script>
    <%--设备名称检索--%>
    <asp:UpdatePanel ID="UpdatePanel_Searchname" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Searchname" runat="server" Visible="true">
                <fieldset>
                    <legend>设备名称检索</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 22%" align="right">
                                <asp:Label ID="Lblname" runat="server" Text="设备名称："></asp:Label>
                            </td>
                            <td style="width: 28%">
                                <asp:TextBox ID="Txtname" runat="server" Width="150px" Height="20px"></asp:TextBox>
                            </td>
                            <td style="width: 13%">
                                <asp:Button ID="Search_name" runat="server" Text="检索" Width="70px" CssClass="Button02"
                                    OnClick="Search_name_Click" Height="24px" />
                            </td>
                            <td style="height: 16px; width: 13%;">
                                <asp:Button ID="New_name" runat="server" Text="新增设备名称" Width="90px" CssClass="Button02"
                                    OnClick="New_name_Click" Height="24px" />
                            </td>
                            <td>
                                <asp:Button ID="Clear_name" runat="server" CssClass="Button02" Text="重置" Width="70px"
                                    OnClick="Clear_name_Click" Height="24px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--设备名称列表--%>
    <asp:UpdatePanel ID="UpdatePanel_Name" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Name" runat="server" Visible="true">
                <fieldset>
                    <legend>设备名称列表</legend>
                    <asp:Label ID="Label_enid" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="Label_enname" runat="server" Visible="False"></asp:Label>
                    <asp:GridView ID="Grid_EquipName" runat="server" DataKeyNames="EN_ID" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                        AllowPaging="True" PageSize="10" Font-Strikeout="False" UseAccessibleHeader="False"
                        OnPageIndexChanging="Grid_EquipName_PageIndexChanging" OnRowCommand="Grid_EquipName_RowCommand"
                        OnRowCancelingEdit="Grid_EquipName_RowCancelingEdit" OnRowEditing="Grid_EquipName_RowEditing"
                        OnRowUpdating="Grid_EquipName_RowUpdating" OnRowDataBound="Grid_EquipName_RowDataBound"
                        GridLines="None">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="EN_ID" HeaderText="设备名称ID" ReadOnly="True" SortExpression="EN_ID"
                                Visible="False">
                                <ItemStyle Width="10%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="EN_EquipName" HeaderText="设备名称" SortExpression="EN_EquipName">
                                <ItemStyle Width="30%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="EN_IsDeleted" HeaderText="是否删除" ReadOnly="True" SortExpression="EN_IsDeleted"
                                Visible="False">
                                <ItemStyle Width="10%" />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Look_Model" runat="server" CommandName="Look_Model" OnClientClick="false"
                                        CommandArgument='<%#Eval("EN_ID")+","+Eval("EN_EquipName")%>'>查看型号</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Width="10%" />
                            </asp:TemplateField>
                            <asp:CommandField ShowEditButton="True" EditText="编辑" UpdateText="更新" CancelText="关闭">
                                <ItemStyle Width="10%" />
                            </asp:CommandField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete_Name" runat="server" CommandName="Delete_Name" OnClientClick="return confirm('您确认删除该记录吗?')"
                                        CommandArgument='<%#Eval("EN_ID")%>'>删除</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Width="10%" />
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
    <%--设备型号--%>
    <asp:UpdatePanel ID="UpdatePanel_Model" runat="server">
        <ContentTemplate>
            <asp:Panel ID="Panel_Model" runat="server" Visible="false">
                <fieldset>
                    <legend><asp:Label ID="Label_enname0" runat="server"></asp:Label>&nbsp;型号列表</legend>
                    <asp:Label ID="Label_mid" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="Label_mname" runat="server" Visible="False"></asp:Label>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <%--<td style="width: 8%" align="right">
                                <asp:Label ID="Labelname" runat="server" Text="设备名称："></asp:Label>
                            </td>
                            <td style="width: 8%">
                                <asp:TextBox ID="Txtname1" runat="server" Width="150px" Height="20px" Enabled="False"></asp:TextBox>
                            </td>--%>
                            <td style="width: 15%" align="right">
                                <asp:Label ID="Lblmodel" runat="server" Text="设备型号："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="Txtmodel" runat="server" Width="150px" Height="20px"></asp:TextBox>
                            </td>
                            <td style="width: 8%" align="center">
                                <asp:Button ID="Search_model" runat="server" Text="检索" Width="70px" CssClass="Button02"
                                    OnClick="Search_model_Click" Height="24px" />
                            </td>
                            <td style="width: 8%" align="center">
                                <asp:Button ID="Clear_model" runat="server" CssClass="Button02" OnClick="Clear_model_Click"
                                    Text="重置" Width="70px" Height="24px" />
                            </td>
                            <td style="width: 8%" align="center">
                                <asp:Button ID="New_model" runat="server" Text="新增设备型号" Width="90px" CssClass="Button02"
                                    OnClick="New_model_Click" Height="24px" />
                            </td>
                        </tr>
                    </table>
                    <%--设备型号列表--%>
                    <asp:GridView ID="Grid_EquipModel" runat="server" DataKeyNames="EMT_ID" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                        AllowPaging="True" PageSize="5" Font-Strikeout="False" UseAccessibleHeader="False"
                        OnPageIndexChanging="Grid_EquipModel_PageIndexChanging" OnRowCommand="Grid_EquipModel_RowCommand"
                        OnRowCancelingEdit="Grid_EquipModel_RowCancelingEdit" OnRowEditing="Grid_EquipModel_RowEditing"
                        OnRowUpdating="Grid_EquipModel_RowUpdating" OnRowDataBound="Grid_EquipModel_RowDataBound"
                        GridLines="None">
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
                            <asp:BoundField DataField="EMT_ID" HeaderText="设备型号ID" ReadOnly="True" SortExpression="EMT_ID"
                                Visible="False">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="EMT_Type" HeaderText="设备型号" SortExpression="EMT_Type">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_MaterialID" HeaderText="物料ID" SortExpression="IMMBD_MaterialID"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_MaterialName" HeaderText="对应的物料名称" ReadOnly="True"
                                SortExpression="IMMBD_MaterialName">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_SpecificationModel" HeaderText="对应的规格型号" ReadOnly="True"
                                SortExpression="IMMBD_SpecificationModel">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Look_Spare" runat="server" CommandName="Look_Spare" OnClientClick="false"
                                        CommandArgument='<%#Eval("EMT_ID")+","+Eval("EMT_Type")%>'>常用备件</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:CommandField ShowEditButton="True" EditText="编辑" UpdateText="更新" CancelText="关闭">
                                <ItemStyle />
                            </asp:CommandField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnDelete_Model" runat="server" CommandName="Delete_Model" OnClientClick="return confirm('您确认删除该记录吗?')"
                                        CommandArgument='<%#Eval("EMT_ID")%>'>删除</asp:LinkButton>
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
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td align="center">
                                <asp:Button ID="Close_model" runat="server" CssClass="Button02" OnClick="Close_model_Click"
                                    Text="关闭" Width="70px" Height="24px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--常用备件--%>
    <asp:UpdatePanel ID="UpdatePanel_Spare" runat="server">
        <ContentTemplate>
            <asp:Panel ID="Panel_Spare" runat="server" Visible="false">
                <fieldset>
                    <legend><asp:Label ID="Label_enname1" runat="server"></asp:Label><asp:Label ID="Label_mname1" runat="server"></asp:Label>
                        &nbsp;常用备件列表</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td align="right" style="width: 13%">
                                <asp:Label ID="Label3" runat="server" Text="物料名称："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TextMaterialName" runat="server" Width="150px" Height="20px"></asp:TextBox>
                            </td>
                            <td align="right" style="width: 12%">
                                <asp:Label ID="Label4" runat="server" Text="物料编码："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TextMaterialCode" runat="server" Width="150px" Height="20px"></asp:TextBox>
                            </td>
                            <td align="right" style="width: 12%">
                                <asp:Label ID="Label5" runat="server" Text="规格型号："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextSpecificationModel" runat="server" Width="150px" Height="20px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 16px;" align="right">
                            <td>
                            </td>
                            <td align="right">
                                <asp:Button ID="Search_spare" runat="server" Text="检索" Width="70px" CssClass="Button02"
                                    OnClick="Search_spare_Click" Height="24px" />
                            </td>
                            <td align="center" colspan="2">
                                <asp:Button ID="New_spare" runat="server" Text="新增常用备件" Width="90px" CssClass="Button02"
                                    OnClick="New_spare_Click" Height="24px" />
                            </td>
                            <td align="left">
                                <asp:Button ID="Clear_spare" runat="server" CssClass="Button02" OnClick="Clear_spare_Click"
                                    Text="重置" Width="70px" Height="24px" />
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                    <%--常用备件列表--%>
                    <asp:GridView ID="Grid_EquipSpare" runat="server" DataKeyNames="EFUS_ID" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                        AllowPaging="True" PageSize="5" Font-Strikeout="False" UseAccessibleHeader="False"
                        OnPageIndexChanging="Grid_EquipSpare_PageIndexChanging" OnRowCommand="Grid_EquipSpare_RowCommand"
                        OnRowDataBound="Grid_EquipSpare_RowDataBound" GridLines="None">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="EFUS_ID" HeaderText="常用备件ID" ReadOnly="True" SortExpression="EFUS_ID"
                                Visible="False">
                                <ItemStyle Width="10%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ETT_ID" HeaderText="设备型号ID" ReadOnly="True" SortExpression="ETT_ID"
                                Visible="False">
                                <ItemStyle Width="10%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_MaterialID" HeaderText="物料ID" SortExpression="IMMBD_MaterialID"
                                Visible="False">
                                <ItemStyle Width="10%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_MaterialName" HeaderText="物料名称" SortExpression="IMMBD_MaterialName">
                                <ItemStyle Width="10%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_MaterialCode" HeaderText="物料编码" SortExpression="IMMBD_MaterialCode">
                                <ItemStyle Width="10%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_SpecificationModel" HeaderText="规格型号" SortExpression="IMMBD_SpecificationModel">
                                <ItemStyle Width="10%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_SafeStock" HeaderText="安全库存" SortExpression="IMMBD_SafeStock">
                                <ItemStyle Width="10%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMIM_TotalNum" HeaderText="总数量" SortExpression="IMIM_TotalNum">
                                <ItemStyle Width="10%" />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnDelete_Spare" runat="server" CommandName="Delete_Spare" OnClientClick="return confirm('您确认删除该记录吗?')"
                                        CommandArgument='<%#Eval("EFUS_ID")%>'>删除</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Width="10%" />
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
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td align="center">
                                <asp:Button ID="Close_spare" runat="server" CssClass="Button02" OnClick="Close_spare_Click"
                                    Text="关闭" Width="70px" Height="24px" />
                            </td>
                        </tr>
                </fieldset>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--新增设备名称--%>
    <asp:UpdatePanel ID="UpdatePanel_NewName" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_NewName" runat="server" Visible="False">
                <fieldset>
                    <legend>新增设备名称</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="height: 30px; width: 40%;" align="right">
                                <asp:Label ID="Lbl_NewName" runat="server" Text="设备名称："></asp:Label>
                            </td>
                            <td style="height: 30px" align="left" colspan="2">
                                <asp:TextBox ID="NewName" runat="server" Width="150px" Height="20px" MaxLength="20"></asp:TextBox>
                                <asp:Label ID="Label17" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                    ControlToValidate="NewName" ValidationGroup="addnamevalidation"></asp:RequiredFieldValidator>--%>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 30px;" align="right">
                                <asp:Button ID="BtnOK_NewName" runat="server" Text="提交" Width="70px" CssClass="Button02"
                                    OnClick="BtnOK_NewName_Click" ValidationGroup="addnamevalidation" 
                                    Height="24px" />
                            </td>
                            <td style="height: 30px; width: 15%;">
                            </td>
                            <td align="left">
                                <asp:Button ID="BtnCancel_NewName" runat="server" Text="关闭" CssClass="Button02" Width="70px"
                                    OnClick="BtnCancel_NewName_Click" Height="24px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--新增设备型号--%>
    <asp:UpdatePanel ID="UpdatePanel_NewModel" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_NewModel" runat="server" Visible="False">
                <fieldset>
                    <legend>新增设备型号</legend>
                    <asp:Label ID="Label99" runat="server" Visible="False"></asp:Label>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td align="right" style="width: 21%">
                                <asp:Label ID="Label11" runat="server" Text="设备名称："></asp:Label>
                            </td>
                            <td align="left" style="width: 22%">
                                <asp:TextBox ID="TextBox1" runat="server" Width="150px" Height="20px" Enabled="False"></asp:TextBox>
                            </td>
                            <td align="right" style="width: 12%">
                                <asp:Label ID="Label1" runat="server" Text="设备型号："></asp:Label>
                            </td>
                            <td align="left" style="width: 44%">
                                <asp:TextBox ID="NewModel" runat="server" Width="150px" Height="20px" MaxLength="20"></asp:TextBox>
                                <asp:Label ID="Label18" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                    ControlToValidate="NewModel" ValidationGroup="addmodelvalidation"></asp:RequiredFieldValidator>--%>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td align="right">
                                <asp:Label ID="Label12" runat="server" Text="对应的物料名称："></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TextBox2" runat="server" Width="150px" Height="20px" Enabled="False"></asp:TextBox>
                                <asp:Label ID="Label19" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                                    ControlToValidate="TextBox2" ValidationGroup="addmodelvalidation"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label13" runat="server" Text="对应的规格型号："></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TextBox3" runat="server" Width="150px" Height="20px" Enabled="false"></asp:TextBox>
                                <asp:Label ID="Label20" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                    ControlToValidate="TextBox3" ValidationGroup="addmodelvalidation"></asp:RequiredFieldValidator>--%>
                                <asp:Button ID="Button1" runat="server" Text="选择物料信息" CssClass="Button02" Width="90px"
                                    OnClick="Button1_Click" Height="24px" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td style="height: 30px;" align="center">
                                <asp:Button ID="BtnOK_NewModel" runat="server" Text="提交" Width="70px" CssClass="Button02"
                                    OnClick="BtnOK_NewModel_Click" ValidationGroup="addmodelvalidation" 
                                    Height="24px" />
                            </td>
                            <td>
                            </td>
                            <td style="height: 30px;" align="left">
                                <asp:Button ID="BtnCancel_NewModel" runat="server" Text="关闭" CssClass="Button02"
                                    Width="70px" OnClick="BtnCancel_NewModel_Click" Height="24px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--新增备件--%>
    <%--新增备件检索--%>
    <asp:UpdatePanel ID="UpdatePanel_NewSpare" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_NewSpare" runat="server" Visible="False">
                <fieldset>
                    <legend>新增常用备件</legend>
                    <table style="width: 100%;">
                        <%--<tr style="height: 16px;">
                            <td style="width: 13%" align="right">
                                <asp:Label ID="Label6" runat="server" Text="设备名称：" Visible="false"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="addspareequipname" runat="server" Width="150px" Height="20px" Enabled="False" Visible="false"></asp:TextBox>
                            </td>
                            <td style="width: 12%" align="right">
                                <asp:Label ID="Label7" runat="server" Text="设备型号：" Visible="false"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="addspareequipmadel" runat="server" Width="150px" Height="20px" Enabled="False" Visible="false"></asp:TextBox>
                            </td>
                            <td style="width: 12%">
                            </td>
                            <td>
                            </td>
                        </tr>--%>
                        <tr>
                            <td style="width: 13%" align="right">
                                <asp:Label ID="Label8" runat="server" Text="物料名称："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="Textnewspname" runat="server" Width="150px" Height="20px"></asp:TextBox>
                            </td>
                            <td align="right" style="width: 12%">
                                <asp:Label ID="Label9" runat="server" Text="物料编码："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="Textnewspno" runat="server" Width="150px" Height="20px"></asp:TextBox>
                            </td>
                            <td align="right" style="width: 12%">
                                <asp:Label ID="Label10" runat="server" Text="规格型号："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Textnewspmodel" runat="server" Width="150px" Height="20px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 16px;" align="right">
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="Search_newspare" runat="server" Text="检索" Width="70px" CssClass="Button02"
                                    OnClick="Search_newspare_Click" Height="24px" />
                            </td>
                            <td align="center">
                            </td>
                            <td align="left" style="width: 9%">
                            </td>
                            <td align="left">
                                <asp:Button ID="Clear_newspare" runat="server" CssClass="Button02" OnClick="Clear_newspare_Click"
                                    Text="重置" Width="70px" Height="24px" />
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                    <%--备选备件列表--%>
                    <asp:GridView ID="Grid_NewEquipSpare" runat="server" DataKeyNames="IMMBD_MaterialID"
                        AllowSorting="True" AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0"
                        Width="100%" AllowPaging="True" PageSize="5" Font-Strikeout="False" UseAccessibleHeader="False"
                        OnPageIndexChanging="Grid_NewEquipSpare_PageIndexChanging" OnRowCommand="Grid_NewEquipSpare_RowCommand"
                        OnRowDataBound="Grid_NewEquipSpare_RowDataBound" GridLines="None">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:TemplateField HeaderText="选择">
                                <ItemTemplate>
                                    <asp:CheckBox ID="ckb" runat="server" />
                                </ItemTemplate>
                                <ItemStyle Width="5%" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="IMMBD_MaterialID" HeaderText="物料ID" ReadOnly="True" SortExpression="IMMBD_MaterialID"
                                Visible="False">
                                <ItemStyle Width="10%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_MaterialName" HeaderText="物料名称" ReadOnly="True"
                                SortExpression="IMMBD_MaterialName">
                                <ItemStyle Width="10%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_MaterialCode" HeaderText="物料编码" SortExpression="IMMBD_MaterialCode">
                                <ItemStyle Width="10%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_SpecificationModel" HeaderText="规格型号" SortExpression="IMMBD_SpecificationModel">
                                <ItemStyle Width="10%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_SafeStock" HeaderText="安全库存" SortExpression="IMMBD_SafeStock">
                                <ItemStyle Width="10%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMIM_TotalNum" HeaderText="总数量" SortExpression="IMIM_TotalNum">
                                <ItemStyle Width="10%" />
                            </asp:BoundField>
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
                    <table style="width: 100%;">
                        <tr>
                            <td style="height: 30px; width: 33%;" align="right">
                                <asp:Button ID="BtnOK_NewSpare" runat="server" Text="提交" Width="70px" CssClass="Button02"
                                    OnClick="BtnOK_NewSpare_Click" Height="24px" />
                            </td>
                            <td style="height: 30px" width="32%">
                            </td>
                            <td style="height: 30px" align="left">
                                <asp:Button ID="BtnCancel_NewSpare" runat="server" Text="关闭" CssClass="Button02"
                                    Width="70px" OnClick="BtnCancel_NewSpare_Click" Height="24px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--对应物料--%>
    <%--物料信息检索--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" Visible="False">
                <fieldset>
                    <legend>物料信息</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 13%" align="right">
                                <asp:Label ID="Label14" runat="server" Text="物料名称："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TextBox4" runat="server" Width="150px" Height="20px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label15" runat="server" Text="规格型号："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TextBox5" runat="server" Width="150px" Height="20px"></asp:TextBox>
                            </td>
                            <td style="width: 15%" align="right">
                                <asp:Button ID="Button2" runat="server" Text="检索" Width="70px" CssClass="Button02"
                                    OnClick="Button2_Click" Height="24px" />
                            </td>
                            <td align="center">
                                <asp:Button ID="Button3" runat="server" CssClass="Button02" OnClick="Button3_Click"
                                    Text="重置" Width="70px" Height="24px" />
                            </td>
                        </tr>
                    </table>
                    <%--物料信息列表--%>
                    <asp:GridView ID="GridView1" runat="server" DataKeyNames="IMMBD_MaterialID" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                        AllowPaging="True" PageSize="10" Font-Strikeout="False" UseAccessibleHeader="False"
                        OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand"
                        OnRowDataBound="GridView1_RowDataBound" GridLines="None">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:RadioButton ID="RadioButtonMarkup" runat="server" />
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:BoundField DataField="IMMBD_MaterialID" HeaderText="物料ID" ReadOnly="True" SortExpression="IMMBD_MaterialID"
                                Visible="False">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_MaterialName" HeaderText="物料名称" ReadOnly="True"
                                SortExpression="IMMBD_MaterialName">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_SpecificationModel" HeaderText="规格型号" SortExpression="IMMBD_SpecificationModel">
                                <ItemStyle />
                            </asp:BoundField>
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
                                        <asp:TextBox ID="textbox8" runat="server" Width="20px"></asp:TextBox>
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
                    <table style="width: 100%;">
                        <tr>
                            <td style="height: 30px; width: 33%;" align="right">
                                <asp:Button ID="Button4" runat="server" Text="提交" Width="70px" CssClass="Button02"
                                    OnClick="Button4_Click" Height="24px" />
                            </td>
                            <td style="height: 30px" width="32%">
                            </td>
                            <td style="height: 30px" align="left">
                                <asp:Button ID="Button5" runat="server" Text="关闭" CssClass="Button02" Width="70px"
                                    OnClick="Button5_Click" Height="24px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
