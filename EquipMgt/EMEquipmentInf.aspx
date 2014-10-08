<%@ Page Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true"
    CodeFile="EMEquipmentInf.aspx.cs" Inherits="EquipMgt_EMEquipmentInf" Title="设备台账管理" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>

    <asp:Label ID="Lab_Status" runat="server" Visible="False"></asp:Label>
    <%--设备台账检索--%>
    <asp:UpdatePanel ID="UpdatePanel_Search" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Search" runat="server" Visible="False">
                <fieldset>
                    <legend>设备台账检索</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 15%" align="right">
                                <asp:Label ID="Lbltype" runat="server" Text="设备类型："></asp:Label>
                            </td>
                            <td style="width: 18%">
                                <asp:DropDownList ID="DropDownList1" runat="server" Height="20px" Width="150px">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label1" runat="server" Text="设备名称："></asp:Label>
                            </td>
                            <td style="width: 18%">
                                <asp:TextBox ID="Textname" runat="server" Width="150px" Height="20px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label2" runat="server" Text="设备型号："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Textmodel" runat="server" Width="150px" Height="20px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td align="right">
                                <asp:Label ID="Label3" runat="server" Text="设备编号："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Textno" runat="server" Width="150px" Height="20px"></asp:TextBox>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label4" runat="server" Text="设备位置："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextLocation" runat="server" Width="150px" Height="20px"></asp:TextBox>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label5" runat="server" Text="供应商："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextProvidor" runat="server" Width="150px" Height="20px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td align="right">
                                <asp:Label ID="Label6" runat="server" Text="是否需要保养："></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownList2" runat="server" Height="20px" Width="150px">
                                    <asp:ListItem Text="请选择" Value=""></asp:ListItem>
                                    <asp:ListItem Text="是" Value="是"></asp:ListItem>
                                    <asp:ListItem Text="否" Value="否"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label7" runat="server" Text="验收日期："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextAcceptDate" runat="server" Width="150px" Height="20px" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"
                                    Text='<%# Eval("EI_AcceptDate","{0:yyyy-MM-dd}") %>' DataFormatString="{0:yyyy-MM-dd}"></asp:TextBox>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label8" runat="server" Text="设备状态："></asp:Label>
                            </td>
                            <td>
                                <%--<asp:TextBox ID="TextState" runat="server" Width="120px" Height="20px"></asp:TextBox>--%>
                                <asp:DropDownList ID="DropDownList7" runat="server" Height="20px" Width="150px">
                                    <asp:ListItem Text="请选择" Value=""></asp:ListItem>
                                    <asp:ListItem Text="正常" Value="正常"></asp:ListItem>
                                    <asp:ListItem Text="保养中" Value="保养中"></asp:ListItem>
                                    <asp:ListItem Text="厂内维修中" Value="厂内维修中"></asp:ListItem>
                                    <asp:ListItem Text="出厂维修中" Value="出厂维修中"></asp:ListItem>
                                    <asp:ListItem Text="报废锁定中" Value="报废锁定中"></asp:ListItem>
                                    <asp:ListItem Text="已报废" Value="已报废"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td colspan="2" align="right">
                                <asp:Button ID="Btn_Search" runat="server" Text="检索" Width="70px" CssClass="Button02"
                                    OnClick="Btn_Search_Click" />
                            </td>
                            <td style="height: 16px;" colspan="2" align="center">
                                <asp:Button ID="Btn_New" runat="server" Text="新增设备台账" Width="90px" CssClass="Button02"
                                    OnClick="Btn_New_Click" />
                            </td>
                            <td align="left" colspan="2">
                                <asp:Button ID="Btn_Clear" runat="server" CssClass="Button02" Text="重置" Width="70px"
                                    OnClick="Btn_Clear_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--设备台账信息表--%>
    <asp:UpdatePanel ID="UpdatePanel_InfoItem" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_InfoItem" runat="server" Visible="False">
                <fieldset>
                    <legend>设备台账信息表</legend>
                    <asp:Label ID="Label_eiid" runat="server" Visible="False"></asp:Label>
                    <asp:GridView ID="Grid_EquipInfo" runat="server" DataKeyNames="EI_ID" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                        AllowPaging="True" PageSize="10" Font-Strikeout="False" UseAccessibleHeader="False"
                        OnPageIndexChanging="Grid_EquipInfo_PageIndexChanging" OnRowCommand="Grid_EquipInfo_RowCommand"
                        OnRowDataBound="Grid_EquipInfo_RowDataBound" GridLines="None">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="ETT_ID" HeaderText="设备类型ID" ReadOnly="True" SortExpression="ETT_ID"
                                Visible="False">
                                <ItemStyle Width="5%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="EN_ID" HeaderText="设备名称ID" ReadOnly="True" SortExpression="EN_ID"
                                Visible="False">
                                <ItemStyle Width="5%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="EMT_ID" HeaderText="设备型号ID" ReadOnly="True" SortExpression="EMT_ID"
                                Visible="False">
                                <ItemStyle Width="5%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="EI_ID" HeaderText="设备台账ID" ReadOnly="True" SortExpression="EI_ID"
                                Visible="False">
                                <ItemStyle Width="5%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ETT_Type" HeaderText="设备类型" ReadOnly="True" SortExpression="ETT_Type">
                                <ItemStyle Width="8%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="EN_EquipName" HeaderText="设备名称" ReadOnly="True" SortExpression="EN_EquipName">
                                <ItemStyle Width="8%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="EMT_Type" HeaderText="设备型号" ReadOnly="True" SortExpression="EMT_Type">
                                <ItemStyle Width="10%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="EI_No" HeaderText="设备编号" SortExpression="EI_No">
                                <ItemStyle Width="10%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="EI_Location" HeaderText="设备位置" SortExpression="EI_Location">
                                <ItemStyle Width="10%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="EI_Providor" HeaderText="供应商" SortExpression="EI_Providor">
                                <ItemStyle Width="10%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="EI_IsToCare" HeaderText="是否需要保养" SortExpression="EI_IsToCare">
                                <ItemStyle Width="10%" />
                            </asp:BoundField>
                            <asp:TemplateField SortExpression="EI_AcceptDate" HeaderText="验收日期">
                                <ItemTemplate>
                                    <asp:Label ID="EI_AcceptDate" runat="server" Text='<%# Eval("EI_AcceptDate","{0:yyyy-MM-dd}") %>'
                                        DataFormatString="{0:yyyy-MM-dd}"></asp:Label>
                                </ItemTemplate>
                                <%--<EditItemTemplate>
                    <asp:TextBox ID="txt_1" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D %H:%m:%s ',false)"
                         Text='<%# Eval("EI_AcceptDate","{0:yyyy-MM-dd HH:mm:ss}") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                                <ItemStyle Width="10%" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="EI_State" HeaderText="设备状态" SortExpression="EI_State">
                                <ItemStyle Width="8%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="EI_IsDeleted" HeaderText="是否删除" SortExpression="EI_IsDeleted"
                                Visible="False">
                                <ItemStyle Width="5%" />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Edit_Info" runat="server" CommandArgument='<%#Eval("EI_ID")+","+Eval("ETT_Type")+","+Eval("EN_EquipName")+","+Eval("EMT_Type")+","+Eval("EI_No")
                +","+Eval("EI_Location")+","+Eval("EI_Providor")+","+Eval("EI_IsToCare")+","+Eval("EI_AcceptDate")+","+Eval("EI_State")%>'
                                        CommandName="Edit_Info" OnClientClick="false">编辑</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Width="5%" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete_Info" runat="server" CommandName="Delete_Info" OnClientClick="return confirm('您确认删除该记录吗?')"
                                        CommandArgument='<%#Eval("EI_ID")%>'>删除</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Width="5%" />
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
    <%--编辑台账--%>
    <asp:UpdatePanel ID="UpdatePanel_EditInfo" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_EditInfo" runat="server" Visible="False">
                <fieldset>
                    <legend>编辑设备台账</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 12%" align="right">
                                <asp:Label ID="Label22" runat="server" Text="设备类型："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:DropDownList ID="DropDownList5" runat="server" Height="20px" Width="150px">
                                </asp:DropDownList>
                                <asp:Label ID="Label32" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                    ControlToValidate="DropDownList5" ValidationGroup="editequivalidation"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label23" runat="server" Text="设备名称："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="EditTextname" runat="server" Width="150px" Height="20px" Enabled="False"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label24" runat="server" Text="设备型号："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="EditTextmodel" runat="server" Width="150px" Height="20px" Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td align="right">
                                <asp:Label ID="Label25" runat="server" Text="设备编号："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="EditTextno" runat="server" Width="150px" Height="20px" MaxLength="20"></asp:TextBox>
                                <asp:Label ID="Label33" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                    ControlToValidate="EditTextno" ValidationGroup="editequivalidation"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label26" runat="server" Text="设备位置："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="EditTextLocation" runat="server" Width="150px" Height="20px" MaxLength="20"></asp:TextBox>
                                <asp:Label ID="Label34" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*"
                                    ControlToValidate="EditTextLocation" ValidationGroup="editequivalidation"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label27" runat="server" Text="供应商："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="EditTextProvidor" runat="server" Width="150px" Height="20px" Enabled="false"></asp:TextBox>
                                <asp:Label ID="Label35" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*"
                                    ControlToValidate="EditTextProvidor" ValidationGroup="editequivalidation"></asp:RequiredFieldValidator>--%>
                                <asp:Button ID="Button_Supplyedit" runat="server" CssClass="Button02" OnClick="Button_Supplyedit_Click" Text="选择..." Width="50px" Height="24px"/>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td align="right">
                                <asp:Label ID="Label28" runat="server" Text="是否需要保养："></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownList6" runat="server" Height="20px" Width="150px">
                                    <%-- <asp:ListItem Text="请选择" Value=""></asp:ListItem>--%>
                                    <asp:ListItem Text="是" Value="是"></asp:ListItem>
                                    <asp:ListItem Text="否" Value="否"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:Label ID="Label36" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                    ControlToValidate="DropDownList6" ValidationGroup="editequivalidation"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label29" runat="server" Text="验收日期："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="EditAcceptDate" runat="server" Width="150px" Height="20px" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"
                                    Text='<%# Eval("EI_AcceptDate","{0:yyyy-MM-dd}") %>' DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:TextBox>
                                <asp:Label ID="Label37" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*"
                                    ControlToValidate="EditAcceptDate" ValidationGroup="editequivalidation"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label30" runat="server" Text="设备状态："></asp:Label>
                            </td>
                            <td>
                                <%--<asp:TextBox ID="EditTextState" runat="server" Width="120px" Height="20px"></asp:TextBox>--%>
                                <asp:DropDownList ID="DropDownList8" runat="server" Height="20px" Width="150px">
                                    <%--<asp:ListItem Text="请选择" Value=""></asp:ListItem>--%>
                                    <asp:ListItem Text="正常" Value="正常"></asp:ListItem>
                                    <asp:ListItem Text="已报废" Value="已报废"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:Label ID="Label38" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                                    ControlToValidate="DropDownList8" ValidationGroup="editequivalidation"></asp:RequiredFieldValidator>--%>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 30px;" align="right" colspan="2">
                                <asp:Button ID="BtnOK_EditInfo" runat="server" Text="提交" Width="70px" CssClass="Button02"
                                    ValidationGroup="editequivalidation" OnClick="BtnOK_EditInfo_Click" 
                                    Height="24px" />
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td style="height: 30px;" align="left" colspan="2">
                                <asp:Button ID="BtnCancel_EditInfo" runat="server" Text="关闭" CssClass="Button02"
                                    Width="70px" OnClick="BtnCancel_EditInfo_Click" Height="24px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--增加设备类型,首先选择设备名称和型号--%>
    <asp:UpdatePanel ID="UpdatePanel_searchname" runat="server">
        <ContentTemplate>
            <asp:Panel ID="Panel_searchname" runat="server" Visible="false">
                <fieldset>
                    <legend>选择设备名称和型号</legend>
                    <asp:Label ID="Label_nname" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="Label_mid" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="Label_mname" runat="server" Visible="False"></asp:Label>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 25%" align="right">
                                <asp:Label ID="Label10" runat="server" Text="设备名称："></asp:Label>
                            </td>
                            <td style="width: 19%">
                                <asp:TextBox ID="Textnameadd" runat="server" Width="150px" Height="20px"></asp:TextBox>
                            </td>
                            <td style="width: 19%" align="right">
                                <asp:Label ID="Label11" runat="server" Text="设备型号："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Textmodeladd" runat="server" Width="150px" Height="20px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="Search_namemodel" runat="server" Text="检索" Width="70px" CssClass="Button02"
                                    OnClick="Search_namemodel_Click" Height="24px" />
                            </td>
                            <td>
                                <asp:Button ID="Clear_namemodel" runat="server" CssClass="Button02" OnClick="Clear_namemodel_Click"
                                    Text="重置" Width="70px" Height="24px" />
                            </td>
                            <td>
                                <asp:Button ID="Close_namemodel" runat="server" CssClass="Button02" OnClick="Close_namemodel_Click"
                                    Text="关闭" Width="70px" Height="24px" />
                            </td>
                        </tr>
                    </table>
                    <%--   设备名称和型号列表--%>
                    <asp:GridView ID="Grid_EquipNameModel" runat="server" DataKeyNames="EMT_ID" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                        AllowPaging="True" PageSize="10" Font-Strikeout="False" UseAccessibleHeader="False"
                        OnPageIndexChanging="Grid_EquipNameModel_PageIndexChanging" OnRowCommand="Grid_EquipNameModel_RowCommand"
                        OnRowDataBound="Grid_EquipNameModel_RowDataBound" GridLines="None">
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
                            <asp:BoundField DataField="EMT_ID" HeaderText="设备型号ID" ReadOnly="True" SortExpression="EMT_ID"
                                Visible="False">
                                <ItemStyle Width="10%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="EN_EquipName" HeaderText="设备名称" SortExpression="EN_EquipName">
                                <ItemStyle Width="25%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="EMT_Type" HeaderText="设备型号" SortExpression="EMT_Type">
                                <ItemStyle Width="25%" />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Add_Info" runat="server" CommandName="Add_Info" OnClientClick="false"
                                        CommandArgument='<%#Eval("EN_ID")+","+Eval("EMT_ID")+","+Eval("EN_EquipName")+","+Eval("EMT_Type")%>'>新增设备台账</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Width="25%" />
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
    <%--在已选择的设备名称和型号下,增加设备台账--%>
    <asp:UpdatePanel ID="UpdatePanel_NewInfo" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_NewInfo" runat="server" Visible="False">
                <fieldset>
                    <legend>新增设备台账</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 12%" align="right">
                                <asp:Label ID="Label12" runat="server" Text="设备类型："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:DropDownList ID="DropDownList3" runat="server" Height="20px" Width="150px">
                                </asp:DropDownList>
                                <asp:Label ID="Label39" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*"
                                    ControlToValidate="DropDownList3" ValidationGroup="addequivalidation"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label13" runat="server" Text="设备名称："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="AddTextname" runat="server" Width="150px" Height="20px" Enabled="False"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label14" runat="server" Text="设备型号："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="AddTextmodel" runat="server" Width="150px" Height="20px" Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td align="right">
                                <asp:Label ID="Label15" runat="server" Text="设备编号："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="AddTextno" runat="server" Width="150px" Height="20px" MaxLength="20"></asp:TextBox>
                                <asp:Label ID="Label40" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*"
                                    ControlToValidate="AddTextno" ValidationGroup="addequivalidation"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label17" runat="server" Text="设备位置："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="AddTextLocation" runat="server" Width="150px" Height="20px" MaxLength="20"></asp:TextBox>
                                <asp:Label ID="Label41" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*"
                                    ControlToValidate="AddTextLocation" ValidationGroup="addequivalidation"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label18" runat="server" Text="供应商："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="AddTextProvidor" runat="server" Width="150px" Height="20px" Enabled="false"></asp:TextBox>
                                <asp:Label ID="Label42" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*"
                                    ControlToValidate="AddTextProvidor" ValidationGroup="addequivalidation"></asp:RequiredFieldValidator>--%>
                                <asp:Button ID="Button_Supplynew" runat="server" CssClass="Button02" OnClick="Button_Supplynew_Click" Text="选择..." Width="50px" Height="24px"/>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td align="right">
                                <asp:Label ID="Label19" runat="server" Text="是否需要保养："></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownList4" runat="server" Height="20px" Width="150px">
                                    <asp:ListItem Text="请选择" Value=""></asp:ListItem>
                                    <asp:ListItem Text="是" Value="是"></asp:ListItem>
                                    <asp:ListItem Text="否" Value="否"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:Label ID="Label43" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*"
                                    ControlToValidate="DropDownList4" ValidationGroup="addequivalidation"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label20" runat="server" Text="验收日期："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="AddAcceptDate" runat="server" Width="150px" Height="20px" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"
                                    Text='<%# Eval("EI_AcceptDate","{0:yyyy-MM-dd}") %>' DataFormatString="{0:yyyy-MM-dd}"></asp:TextBox>
                                <asp:Label ID="Label44" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*"
                                    ControlToValidate="AddAcceptDate" ValidationGroup="addequivalidation"></asp:RequiredFieldValidator>--%>
                            </td>
                            <%--<td style="width: 452px" align="right">
                                <asp:Label ID="Label21" runat="server" Text="设备状态："></asp:Label>
                            </td>
                            <td style="width: 522px">
                                <asp:TextBox ID="AddTextState" runat="server" Width="120px" Height="20px"></asp:TextBox>
                            </td>--%>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td style="height: 30px;" align="right">
                                <asp:Button ID="BtnOK_NewInfo" runat="server" Text="提交" Width="70px" CssClass="Button02"
                                    ValidationGroup="addequivalidation" OnClick="BtnOK_NewInfo_Click" 
                                    Height="24px" />
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td style="height: 30px;" align="left">
                                <asp:Button ID="BtnCancel_NewInfo" runat="server" Text="关闭" CssClass="Button02" Width="70px"
                                    OnClick="BtnCancel_NewInfo_Click" Height="24px" />
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdatePanel_Supply" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <asp:Panel ID="Panel_Supply" runat="server" Visible="false">
            <fieldset>
                <legend>供应商查询</legend>
                <asp:Label ID="Label31" runat="server" Visible="False"></asp:Label>
                <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 25%" align="right">
                                <asp:Label ID="Label9" runat="server" Text="供应商编码："></asp:Label>
                            </td>
                            <td style="width: 19%">
                                <asp:TextBox ID="TextBox1" runat="server" Width="150px" Height="20px"></asp:TextBox>
                            </td>
                            <td style="width: 19%" align="right">
                                <asp:Label ID="Label21" runat="server" Text="供应商名称："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox2" runat="server" Width="150px" Height="20px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="Search_Supply" runat="server" Text="检索" Width="70px" CssClass="Button02"
                                    OnClick="Search_Supply_Click" Height="24px" />
                            </td>
                            <td></td>
                            <td>
                                <asp:Button ID="Clear_Supply" runat="server" CssClass="Button02" OnClick="Clear_Supply_Click"
                                    Text="重置" Width="70px" Height="24px" />
                            </td>
                        </tr>
                    </table>
                <asp:GridView ID="Gridview_PMSupply" runat="server" DataKeyNames="PMSI_SupplyName" AllowSorting="True"
                    AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                    AllowPaging="True" PageSize="10" Font-Strikeout="False" UseAccessibleHeader="False"
                    OnPageIndexChanging="Gridview_PMSupply_PageIndexChanging" OnRowCommand="Gridview_PMSupply_RowCommand"
                    OnRowDataBound="Gridview_PMSupply_RowDataBound" GridLines="None">
                    <RowStyle CssClass="GridViewRowStyle" />
                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                    <HeaderStyle CssClass="GridViewHead" />
                    <FooterStyle CssClass="GridViewFooterStyle" />
                    <Columns>
                    <asp:TemplateField >
                        <ItemTemplate >
                            <asp:RadioButton ID="RadioButtonMarkup" runat="server"></asp:RadioButton>
                        </ItemTemplate>
                        <ItemStyle />
                    </asp:TemplateField>
                    <asp:BoundField DataField="PMSI_ID" HeaderText="供应商ID" SortExpression="PMSI_ID" Visible="False">
                        <ItemStyle />
                    </asp:BoundField>  
                    <asp:BoundField DataField="PMSI_SupplyNum" HeaderText="供应商编码"  SortExpression="PMSI_SupplyNum" />
                    <asp:BoundField DataField="PMSI_SupplyName" HeaderText="供应商名称"  SortExpression="PMSI_SupplyName" />
                    </Columns>
               <EmptyDataTemplate>
                     <asp:Label ID="Label50" runat="server" Text="无相关记录！"></asp:Label>
               </EmptyDataTemplate>
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
                                        <asp:TextBox ID="textbox00" runat="server" Width="20px"></asp:TextBox>
                                        <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                            CommandName="Page" Text="GO" /><!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
                                    </td>
                                </tr>
                            </table>
                        </PagerTemplate>
                   </asp:GridView>
             <table width="100%">
                <tr>
                <td width="50%" align="center" >
                    <asp:Button ID="Button_ComSP" runat="server" Text="提交" CssClass="Button02" 
                        OnClick="Button_ComSP_Click" Width="70px" Height="24px" />
                </td>
                <td align="center">
                    <asp:Button ID="Button_CancelSP" runat="server" Text="关闭" CssClass="Button02"  
                        OnClick="Button_CancelSP_Click" Width="70px" Height="24px" />
                 </td>
                 </tr>
            </table>
            </fieldset>
             </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>




</asp:Content>
