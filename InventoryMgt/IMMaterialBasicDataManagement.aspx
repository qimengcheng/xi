<%@ Page Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true"
    CodeFile="IMMaterialBasicDataManagement.aspx.cs" Inherits="InventoryMgt_IMMaterialBasicDataManagement"
    Title="物料基础信息管理" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/JS/ShortM.js" />
        </Scripts>--%>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script language="javascript" type="text/javascript">

        function ValidtorTime(start, end) {
            var idstart = "ctl00_ContentPlaceHolder1_" + start;
            var idend = "ctl00_ContentPlaceHolder1_" + end;
            var d1 = new Date(document.getElementById(idstart).value.replace(/\-/g, "\/"));
            var d2 = new Date(document.getElementById(idend).value.replace(/\-/g, "\/"));
            if (d1 > d2) {
                return false;
            }
            return true;
        }


        function annotation(name) {
            var id = "ctl00_ContentPlaceHolder1_" + name;
            var label = document.getElementById(id);
            label.style.visibility = 'visible';
            return false;
        }
        function leave(name) {
            var id = "ctl00_ContentPlaceHolder1_" + name;
            var label = document.getElementById(id);
            label.style.visibility = 'hidden';
            return false;
        }

        function isdigit(name) {
            var id = "ctl00_ContentPlaceHolder1_" + name;
            var s = document.getElementById(id).value;
            var r, re;
            re = /\d*/i; //\d表示数字,*表示匹配多个数字
            r = s.match(re);
            return (r == s) ? true : false;
        }

    </script>
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
    <%--检索栏--%>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" Visible="true">
                <fieldset>
                    <legend>物料类型名称检索</legend>
                    <table style="width: 100%;">

                        <tr>
                            <td style="width: 15%" align="center">
                                <asp:Label ID="Label24" runat="server" Text="物料类别名称："></asp:Label>
                            </td>
                                  <td style="width: 20%" align="left">
                                <asp:TextBox runat="server" ID="TextBox2"> </asp:TextBox>
                            </td>
                            <td style="width: 20%"  align="center">
                                <asp:Button ID="Button10" runat="server" Text="检索" CssClass="Button02" Height="24px"
                                    OnClick="SelectMaterialType" Width="80px" />
                            </td>
                                <td style="width: 20%" align="center">
                                <asp:Button ID="Button11" runat="server" Text="物料明细检索" CssClass="Button02" Height="24px"
                                    OnClick="SelectMatBasicData_open" Width="110px" />
                            </td>
                            <td style="width: 25%" align="center">
                                 
                                <asp:Button ID="Button12" runat="server" Text="新建物料类别" CssClass="Button02" Height="24px"
                                    OnClick="NewMatType" Width="110px" />
                 
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_Search" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Search" runat="server" Visible="false">
                <fieldset>
                    <legend>物料名称检索</legend>
                    <table style="width: 100%;">
                        <asp:Label ID="label_mattype" runat="server" Visible="False"></asp:Label>
                            <asp:Label ID="label_Mattypesource" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="label_mattypeid" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="labelcodition" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="label1_PanelMatBasicState" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="label1_BasicID" runat="server" Visible="False"></asp:Label>
                        <tr>
                            <td style="width: 15%" align="center">
                                <asp:Label ID="Label" runat="server" Text="物料类别："></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:DropDownList ID="DropDownList1" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 15%" align="center">
                                <asp:Label ID="Label15" runat="server" Text="物料名称："></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:TextBox runat="server" ID="MatName"> </asp:TextBox>
                            </td>
                            <td style="width: 15%" align="center">
                                <asp:Label ID="Label5" runat="server" Text="规格型号："></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:TextBox runat="server" ID="Model"> </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 15%" align="center">
                                <asp:Label ID="Label10" runat="server" Text="存放时间（天）："></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:TextBox runat="server" ID="StockDay"> </asp:TextBox><br />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="请输入整数"
                                    ControlToValidate="StockDay" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                            </td>
                            <td style="width: 15%" align="center">
                                <asp:Label ID="Label12" runat="server" Text="安全库存量(不大于)："></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:TextBox runat="server" ID="SafeStock"> </asp:TextBox><br />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="只能输入两位小数"
                                    ControlToValidate="SafeStock" ValidationExpression="^[0-9]+(.[0-9]{2})?$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="right">
                                <asp:Button ID="Button1" runat="server" Text="检索" CssClass="Button02" Height="24px"
                                    OnClick="SelectMatBasicData" Width="80px" />
                            </td>
                         
                            <td colspan="2" align="center">
                                <asp:Button ID="Button3" runat="server" Text="重置" CssClass="Button02" Height="24px"
                                    OnClick="Clear" Visible="true" Width="80px" />
                                       <td colspan="2" align="left">
                                <asp:Button ID="Button2" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="ColseMaterialBasicSearch" Width="80px" />
                            </td>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

    <!-- 产品列表开始-->
    <asp:UpdatePanel ID="UpdatePanel_MatType" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_MatType" runat="server" Visible="true">
                <fieldset>
                    <legend>物料类型列表</legend>
                    <asp:GridView ID="Gridview_MatType" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle"
                        CellPadding="0" UseAccessibleHeader="False" PageSize="10" 
                        AllowPaging="True" AllowSorting="True"
                        DataKeyNames="IMMt_MaterialTypeID" OnRowCommand="Gridview_MatType_RowCommand"
                        OnPageIndexChanging="Gridview_MatTypeID_PageIndexChanging" Width="100%"
                        OnRowCancelingEdit="Gridview_MatType_RowCancelingEdit" 
                        OnRowEditing="Gridview_MatType_RowEditing" GridLines="None"
                        OnRowUpdating="Gridview_MatType_RowUpdating" 
                        ondatabound="Gridview_MatType_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="IMMt_MaterialTypeID" HeaderText="物料类型ID" ReadOnly="True"
                                SortExpression="IMMt_MaterialTypeID" Visible="False">
                                <ItemStyle  />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMT_MaterialType" HeaderText="物料类型名称" SortExpression="IMMT_MaterialType">
                                <ItemStyle/>
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMT_Statement" HeaderText="说明" SortExpression="IMMT_Statement">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnLook1" runat="server" CommandName="Look1" OnClientClick="false"
                                        CommandArgument='<%#Eval("IMMt_MaterialTypeID")%>'>查看具体物料名称</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnEdit1" runat="server" CommandName="Edit1" OnClientClick="false"
                                    CommandArgument='<%#Eval("IMMt_MaterialTypeID")%>'>编辑</asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle Width="30px" />
                        </asp:TemplateField>--%>
                            <asp:CommandField ShowEditButton="True" EditText="编辑" UpdateText="更新" CancelText="取消">
                                <ItemStyle  />
                            </asp:CommandField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnDelete1" runat="server" CommandName="Delete1" OnClientClick="return confirm('您确认删除该记录吗?')"
                                        CommandArgument='<%#Eval("IMMt_MaterialTypeID")%>'>删除</asp:LinkButton>
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
                            <asp:Label ID="Label50" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                   
                    </asp:GridView>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <!-- 产品列表结束-->
    <!--物料名称明细表开始-->
    <asp:UpdatePanel ID="UpdatePanel_MaterBasicData" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_MaterBasicData" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="Label17" runat="server" Visible="true" Text=""></asp:Label>物料名称明细
                        <asp:Label ID="Label_BasicData_Source" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <asp:Button ID="Button8" runat="server" Text="新建物料名称明细" CssClass="Button02" Height="24px"
                                    OnClick="CreateMatBasicData " Width="110px" />
                    <asp:GridView ID="GridView_MaterialBasicData" runat="server" AutoGenerateColumns="false"
                        CssClass="GridViewStyle" PageSize="10" CellPadding="0" UseAccessibleHeader="False"
                        AllowPaging="True" OnRowCommand="GridView_MatBasicData_RowCommand" OnPageIndexChanging="GridView_MatBasicData_PageIndexChanging"
                        AllowSorting="True" OnRowCreated="GridView_MatType_RowCreated" GridLines="None"
                        Width="100%" DataKeyNames="IMMBD_MaterialID" 
                        ondatabound="GridView_MaterialBasicData_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="IMMBD_MaterialID" HeaderText="物料名称ID" SortExpression="IMMBD_MaterialID"
                                Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="IMMBD_MaterialTypeID" HeaderText="物料类型ID" SortExpression="IMMBD_MaterialTypeID"
                                Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="IMMBD_MaterialName" HeaderText="物料名称" SortExpression="IMMBD_MaterialName">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_SpecificationModel" SortExpression="IMMBD_SpecificationModel"
                                HeaderText="规格型号"></asp:BoundField>
                            <asp:BoundField DataField="IMMBD_MaterialCode" SortExpression="IMMBD_MaterialCode"
                                HeaderText="物料编码"></asp:BoundField>
                            <asp:BoundField DataField="IMMBD_IsHarmful" SortExpression="IMMBD_IsHarmful" HeaderText="是否有害">
                            </asp:BoundField>
                            <asp:BoundField DataField="UnitName" SortExpression="UnitName"
                                HeaderText="单位"></asp:BoundField>
                            <asp:BoundField DataField="IMMBD_SafeStock" SortExpression="IMMBD_SafeStock" HeaderText="安全库存">
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_StorageDay" SortExpression="IMMBD_StorageDay" HeaderText="存储期限">
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_Comment" SortExpression="IMMBD_Comment" HeaderText="备注">
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_CharacterPara" SortExpression="IMMBD_CharacterPara"
                                HeaderText="参数"></asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Edit2" runat="server" CommandArgument='<%# Eval("IMMBD_MaterialID") %>'
                                        CommandName="Edit2">编辑</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete2" runat="server" CommandArgument='<%# Eval("IMMBD_MaterialID") %>'
                                        CommandName="Delete2" OnClientClick="return confirm('您确认删除该记录吗?')">删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right" colspan="2">
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
                                        <asp:TextBox ID="textbox" runat="server" Width="20px"></asp:TextBox>
                                        <%--<asp:textbox id="txtNewPageIndex" runat="server" width="20px" text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />--%>
                                        <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                            CommandName="Page" Text="GO" />
                                        <!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
                                    </td>
                                </tr>
                            </table>
                            </tr> </table>
                        </PagerTemplate>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label16" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <table width="100%">
                        <tr>
                            <td align="center">
                                <asp:Button ID="Button9" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="CanelMatBasicData" Width="80px" />
                            </td>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--  物料名称详细表结束--%>
    <%--新建物料类型开始--%>
    <asp:UpdatePanel ID="UpdatePanel_MatTypeNew" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_MatTypeNew" runat="server" Visible="False">
                <fieldset>
                    <legend>新建物料类型</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 15%" align="center">
                                <asp:Label ID="Label1" runat="server" Text="物料类别："></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:TextBox runat="server" ID="TextBox_NewTypeName"> </asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label2" runat="server" Text="说明：(100字内)"></asp:Label>
                            </td>
                            <td style="width: 45%" align="left">
                                <textarea id="TextArea1" cols="60" rows="3" runat="server" onkeyup="this.value = this.value.slice(0, 100)"></textarea>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="right">
                                <asp:Button ID="Button4" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    OnClick="ConfirmMatTypeNew " Width="80px" />
                            </td>
                            <td colspan="2" align="center">
                                <asp:Button ID="Button5" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="CanelMatTye" Width="80px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <%--新建物料类型结束--%>
    <%--新建物料名称开始--%>
    <asp:UpdatePanel ID="UpdatePanel_MatBasicDataNew" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_MatBasicDataNew" runat="server" Visible="False">
                <fieldset>
                    <legend><asp:Label ID="Label19" runat="server" Text="新建"></asp:Label>物料名称</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label3" runat="server" Text="物料类别："></asp:Label>
                            </td>
                            <td style="width: 22%" align="left">
                                <asp:DropDownList ID="DropDownList2" runat="server" >
                                </asp:DropDownList>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label4" runat="server" Text="物料名称："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox_matnamenew"> </asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label6" runat="server" Text="规格型号："></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:TextBox runat="server" ID="TextBox_matmodelnew"> </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label7" runat="server" Text="安全库存："></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:TextBox runat="server" ID="TextBox_safenew" Width="85px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="请输入两位小数"
                                    ControlToValidate="TextBox_safenew" ValidationExpression="^[0-9]+(.[0-9]{2})?$"></asp:RegularExpressionValidator>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label8" runat="server" Text="基本单位："></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DropDownList4" runat="server" AutoPostBack="True" 
                                    onselectedindexchanged="DropDownList4_SelectedIndexChanged" >
                                </asp:DropDownList>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label9" runat="server"  Text="存储期限（天）："></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:TextBox runat="server" ID="TextBox3" Width="85px"> </asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="请输入整数"
                                    ControlToValidate="TextBox3" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label11" runat="server" Text="是否有害："></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:DropDownList ID="DropDownList3" runat="server">
                                    <asp:ListItem>否</asp:ListItem>
                                    <asp:ListItem>是</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>转换比例（现单位/原单位）</td>
                              <td align="left">
                                <asp:TextBox runat="server" ID="TextBox14" onkeyup="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{2,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{2})[0-9]*/, '$1');" 
                              onafterpaste="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{2,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{2})[0-9]*/, '$1');"></asp:TextBox>
                            </td>
                             <td style="width: 10%" align="center">
                                <asp:Label ID="Label20" runat="server" Text="物料代码："></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:TextBox runat="server" ID="TextBox5"> </asp:TextBox>
                            </td>
                        </tr>
                               <tr id="Cone">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label21" runat="server" Text="每套片数："></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                               <asp:TextBox runat="server" ID="TextBox8" onkeyup="this.value=this.value.replace(/[^\d]/g,'')"></asp:TextBox>
                            </td>
                            <td>利用率：</td>
                              <td align="left">
                                <asp:TextBox runat="server" ID="TextBox6" onkeyup="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{2,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{2})[0-9]*/, '$1');" 
                              onafterpaste="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{2,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{2})[0-9]*/, '$1');"></asp:TextBox>
                            </td>
                             <td style="width: 10%" align="center">
                                <asp:Label ID="Label22" runat="server" Text="单位重量：" onkeyup="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{2,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{2})[0-9]*/, '$1');" 
                              onafterpaste="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{2,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{2})[0-9]*/, '$1');"></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:TextBox runat="server" ID="TextBox7"> </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label13" runat="server" Text="参数特性："></asp:Label>
                            </td>
                            <td style="width: 20%" align="left" colspan="5">
                                <asp:TextBox runat="server" ID="TextBox1" Width="99%" MaxLength="100" onfocus="annotation('Label47');"
                                    onblur="javascript:leave('Label47');" Height="35px"></asp:TextBox>
                                <asp:Label ID="Label47" runat="server" ForeColor="#999999" Text="100字以内" Style="visibility: hidden;"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label14" runat="server" Text="备注："></asp:Label>
                            </td>
                            <td style="width: 20%" align="left" colspan="5">
                                <asp:TextBox runat="server" ID="TextBox4" Width="99%" Height="35px" onfocus="annotation('Label18');"
                                    onblur="javascript:leave('Label18');" MaxLength="100"></asp:TextBox>
                                <asp:Label ID="Label18" runat="server" ForeColor="#999999" Text="100字以内" Style="visibility: hidden;"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center">
                                <asp:Button ID="Button6" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    OnClick="ConfirmMatBasicDataNew " Width="80px" />
                            </td>
                            <td colspan="2" align="left">
                                <asp:Button ID="Button7" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="CanelMatBasicDataNew" Width="80px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--新建物料名称结束--%>
</asp:Content>
