<%@ Page Title="薪资账套维护" Language="C#" MasterPageFile="~/Other/MasterPage.master"
    AutoEventWireup="true" CodeFile="SalaryAccountSetMaintanance.aspx.cs" Inherits="SalaryMgt_SalaryAccountSetMaintanance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <style type="text/css">
        .hidden
        {
            display: none;
        }
    </style>
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

        function listboxSelect() {
            var lb = document.getElementById("ctl00_ContentPlaceHolder1_LbCanBeUsedItem");
            var targetLabel = document.getElementById("ctl00_ContentPlaceHolder1_TxtFormulaEdit");
            var forvalue = targetLabel.value;
            var index = lb.selectedIndex;
            targetLabel.value = forvalue + lb.options[index].value;
        }
        function mouseInput(name) {
            var id = "ctl00_ContentPlaceHolder1_" + name;
            var inputbutton = document.getElementById(id);
            var targetLabel = document.getElementById("ctl00_ContentPlaceHolder1_TxtFormulaEdit");
            var forvalue = targetLabel.value;
            targetLabel.value = forvalue + inputbutton.value;
        }  
    </script>
    <asp:UpdatePanel ID="UpdatePanel_SetSecrch" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_SetSecrch" runat="server">
                <fieldset>
                    <legend>薪资账套检索栏</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="LblASNameSearch" runat="server" CssClass="STYLE2" Text="账套名："></asp:Label>
                                <asp:Label ID="LblStateForGrid_Set" runat="server" Text="检索前" Visible="false"></asp:Label>
                            </td>
                            <td style="width: 20%; height: 20%;" align="left">
                                <asp:TextBox ID="TxtASNameSearch" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label18" runat="server" CssClass="STYLE2" Text="账套类型："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 20%;" align="left">
                                <asp:DropDownList ID="DropDownList3" runat="server" ToolTip="单击选择">
                                    <asp:ListItem>请选择</asp:ListItem>
                                    <asp:ListItem>产线员工</asp:ListItem>
                                    <asp:ListItem>行政人员</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="width: 20%" align="center">
                                <asp:Button ID="Btn_Search_Set" runat="server" CssClass="Button02" Height="24px"
                                    Text="检索" Width="70px" OnClick="Btn_Search_Set_Click" />
                            </td>
                            <td style="width: 20%" align="center">
                                <asp:Button ID="Btn_New_Set" runat="server" CssClass="Button02" Height="24px" Text="新增账套"
                                    Width="70px" OnClick="Btn_New_Set_Click" />
                            </td>
                            <td style="height: 20%" align="center">
                                <asp:Button ID="Btn_Reset" runat="server" CssClass="Button02" Height="24px" Width="70px"
                                    Text="重置" OnClick="Btn_Reset_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_SetGrid" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_SetGrid" runat="server">
                <fieldset>
                    <legend>薪资账套列表</legend>
                    <asp:GridView ID="Grid_Set" runat="server" DataKeyNames="SAS_ASID" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                        AllowPaging="True" PageSize="10" Font-Strikeout="False" UseAccessibleHeader="False"
                        GridLines="None" OnRowCommand="Grid_Set_RowCommand" OnRowEditing="Grid_Set_RowEditing"
                        OnRowCancelingEdit="Grid_Set_RowCancelingEdit" OnRowUpdating="Grid_Set_RowUpdating"
                        OnPageIndexChanging="Grid_Set_PageIndexChanging" OnDataBound="Grid_Set_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="SAS_ASID" HeaderText="账套ID" SortExpression="SAS_ASID"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SAS_ASName" HeaderText="账套名" SortExpression="SAS_ASName">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SAS_Type" HeaderText="账套类型" SortExpression="SAS_Type">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SAS_IsDeleted" HeaderText="是否删除" SortExpression="SAS_IsDeleted"
                                ReadOnly="True" Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnTheEdit" runat="server" CommandArgument='<%#Eval("SAS_ASID")+","+Eval("SAS_ASName")+","+Eval("SAS_Type")%>'
                                        CommandName="TheEdit" OnClientClick="false">编辑</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <%--<asp:CommandField ShowEditButton="True" EditText="编辑" UpdateText="更新" CancelText="取消">
                                <ItemStyle Width="10%" />
                            </asp:CommandField>--%>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnDelete_Set" runat="server" CommandName="Delete_Set" OnClientClick="return confirm('您确认删除该记录吗?')"
                                        CommandArgument='<%#Eval("SAS_ASID")%>'>删除</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnMaintance_SalaryItem" runat="server" CommandArgument='<%#Eval("SAS_ASID")%>'
                                        CommandName="Maintance_SalaryItem" OnClientClick="false">维护工资项目</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnMaintance_Employee" runat="server" CommandArgument='<%#Eval("SAS_ASID")%>'
                                        CommandName="Maintance_Employee" OnClientClick="false">维护属于该账套的员工</asp:LinkButton>
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
                        <EditRowStyle BackColor="white" />
                    </asp:GridView>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_NewSet" runat="server" UpdateMode="Conditional">
        <%--<Triggers>
            <asp:AsyncPostBackTrigger ControlID="Btn_NEW_NETItem" />
        </Triggers>--%>
        <ContentTemplate>
            <asp:Panel ID="Panel_NewSet" runat="server" Visible="false">
                <fieldset>
                    <legend><asp:Label ID="Label20" runat="server" ></asp:Label>账套</legend>
                    
                    <table width="100%">
                        <tr style="height: 16px;">
                            <td style="width: 10%; height: 20%;" align="center">
                                <asp:Label ID="Label8" runat="server" CssClass="STYLE2" Text="账套名："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 20%;" align="center">
                                <asp:TextBox ID="TxtASNameNew" runat="server" Width="130px" MaxLength="20"></asp:TextBox>
                                <asp:Label ID="Label49" runat="server" ForeColor="Red" Text="*"></asp:Label>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label19" runat="server" CssClass="STYLE2" Text="账套类型："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 20%;" align="left">
                                <asp:DropDownList ID="DropDownList1" runat="server" ToolTip="单击选择">
                                    <asp:ListItem>产线员工</asp:ListItem>
                                    <asp:ListItem>行政人员</asp:ListItem>
                                </asp:DropDownList>
                                <asp:Label ID="Label50" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                <asp:Label ID="LblRecordID" runat="server" Text="" Visible="false"></asp:Label>
                            </td>
                            <td style="width: 20%; height: 20%;" align="center">
                                <asp:Button ID="BtnOK_NewSet" runat="server" Width="70px" Text="提交" CssClass="Button02"
                                    Height="24px" OnClick="BtnOK_NewSet_Click" />
                            </td>
                            <td style="width: 20%; height: 20%;" align="center">
                                <asp:Button ID="BtnCancel_NewSet" runat="server" Width="70px" Text="关闭" CssClass="Button02"
                                    Height="24px" OnClick="BtnCancel_NewSet_Click" />
                            </td>
                            
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_SalaryItemMaintanance" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_SalaryItemMaintanance" runat="server" Visible="false">
                <fieldset>
                    <legend>工资项目维护栏</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label48" runat="server" CssClass="STYLE2" Text="账套名：" Enabled="False"></asp:Label>
                                <asp:Label ID="LblRecordSAS_ASID" runat="server" Text="" Visible="false"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtASName" runat="server" Width="130px" Enabled="False"></asp:TextBox>
                                <td style="width: 10%">
                                </td>
                                <td style="width: 20%" align="center">
                                    <asp:Button ID="BtnNewItem" runat="server" CssClass="Button02" Height="24px" Visible="false" Text="新增工资项目"
                                        Width="90px" OnClick="BtnNewItem_Click" />
                                </td>
                                <td style="width: 20%; height: 20%;" align="center">
                                </td>
                                <td style="height: 20%" align="center">
                                </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <fieldset>
                                    <legend>
                                        <asp:Label ID="LblTheSet" runat="server" Text="该账套"></asp:Label>&nbsp工资项目列表</legend>
                                    <asp:GridView ID="GridView1" runat="server" DataKeyNames="SIT_ItemID" AllowSorting="True"
                                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                                        AllowPaging="True" PageSize="10" Font-Strikeout="False" UseAccessibleHeader="False"
                                        GridLines="None" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand"
                                        OnDataBound="GridView1_DataBound">
                                        <RowStyle CssClass="GridViewRowStyle" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                        <HeaderStyle CssClass="GridViewHead" />
                                        <FooterStyle CssClass="GridViewFooterStyle" />
                                        <Columns>
                                            <asp:BoundField DataField="SIT_ItemID" HeaderText="工资项目ID" ReadOnly="True" SortExpression="SIT_ItemID"
                                                Visible="false">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SIT_Items" HeaderText="工资项目" SortExpression="SIT_Items">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SIT_InitialValue" HeaderText="初始值" SortExpression="SIT_InitialValue">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SIT_Formula" HeaderText="计算公式" SortExpression="SIT_Formula">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbtnEdit_Item" runat="server" CommandArgument='<%#Eval("SIT_ItemID")%>'
                                                        CommandName="Edit_Item" OnClientClick="false">编辑</asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbtnDelete_Item" runat="server" CommandName="Delete_Item" OnClientClick="return confirm('您确认删除该记录吗?')"
                                                        CommandArgument='<%#Eval("SIT_ItemID")%>'>删除</asp:LinkButton>
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
                                        <EditRowStyle BackColor="white" />
                                    </asp:GridView>
                                </fieldset>
                            </td>
                        </tr>
                        </tr>
                        <tr>
                            <td colspan="6" align="center">
                                <asp:Button ID="BtnClosePanel_SalaryItemMaintanance" runat="server" Width="70px"
                                    Height="24px" Text="关闭" CssClass="Button02" OnClick="BtnClosePanel_SalaryItemMaintanance_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_ItemMaintanance" runat="server" UpdateMode="Conditional">
        <%--<Triggers>
            <asp:AsyncPostBackTrigger ControlID="Btn_NEW_NETItem" />
        </Triggers>--%>
        <ContentTemplate>
            <asp:Panel ID="Panel_ItemMaintanance" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="LblRecordSetForMaint" runat="server" Text=""></asp:Label>&nbsp 工资项目<asp:Label
                            ID="LblRecordItem" runat="server" Text=""></asp:Label></legend>
                    <table width="100%">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label31" runat="server" Text="工资项目："></asp:Label>
                                <asp:Label ID="LblRecordSIT_ItemID" runat="server" Text="" Visible="false"></asp:Label>
                            </td>
                            <td class="style2">
                                <asp:TextBox ID="TxtSalaryItem" runat="server" Width="110px" Enabled="false" MaxLength="10"></asp:TextBox>
                                <asp:Button ID="BtnSelect" runat="server" Width="45px" Height="20px" Text="选择..."
                                    CssClass="Button02" Visible="false" OnClick="BtnSelect_Click" />
                                <asp:Label ID="Label15" runat="server" ForeColor="Red" Text="*"></asp:Label>&nbsp
                                <asp:Label ID="Label21" runat="server" ForeColor="Red" Visible="false" Text="项目名称不能有+-*/#"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtSalaryItem"
                                    ErrorMessage="*" ValidationGroup="Item"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label32" runat="server" Text="初始值："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtInitialValue" runat="server" MaxLength="16" onkeyup="this.value=this.value.replace(/[^-?\d+((\.)\d{1,2})?$]/g,'')"
                                    onafterpaste="this.value=this.value.replace(/[^-?\d+((\.)\d{1,2})?$]/g,'')" Width="110px"></asp:TextBox>
                                <asp:Label ID="Label17" runat="server" ForeColor="Red" Text="*"></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:Label ID="Label14" runat="server" CssClass="STYLE2" Text="最多只保留两位小数" ForeColor="Red"></asp:Label>
                            </td>
                            <td style="width: 10%" align="center">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="计算公式" runat="server"  Text="计算公式："></asp:Label>
                            </td>
                            <td style="width: 90%" colspan="5">
                                <asp:TextBox ID="TxtFormula" runat="server" Width="600px" Enabled="false" MaxLength="200"></asp:TextBox>
                                <asp:Button ID="BtnEditFormula" runat="server" Width="60px" Height="20px" Text="编辑公式..."
                                    CssClass="Button02" Visible="false" OnClick="BtnEditFormula_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="right">
                                <asp:Button ID="BtnSubmit_ItemMaintanance" runat="server" Width="70px" Text="提交"
                                    Height="24px" CssClass="Button02" OnClick="BtnSubmit_ItemMaintanance_Click" ValidationGroup="Item" />
                            </td>
                            <td>
                                <asp:Label ID="LbLblRecordSIT_ItemID2" runat="server" Text="" Visible="false"></asp:Label>
                            </td>
                            <td colspan="2" align="left">
                                <asp:Button ID="BtnCancel_ItemMaintanancee" runat="server" Width="70px" Text="关闭"
                                    Height="24px" CssClass="Button02" OnClick="BtnCancel_ItemMaintanancee_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_ItemGridSelect" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_ItemGridSelect" runat="server" Visible="false">
                <fieldset>
                    <legend>您当前是为&nbsp<asp:Label ID="LblRecordSetForMaintForSelect" runat="server" Text=""></asp:Label>&nbsp
                        选择工资项目</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label1" runat="server" CssClass="STYLE2" Text="工资项目："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TextBox1" runat="server" Width="130px"></asp:TextBox>
                                <td style="width: 10%">
                                    <asp:Label ID="LblRecordIsSearch3" runat="server" Text="检索前" Visible="false"></asp:Label>
                                </td>
                                <td style="width: 20%" align="center">
                                    <asp:Button ID="BtnItemSearch" runat="server" CssClass="Button02" Height="24px" Text="检索"
                                        Width="70px" OnClick="BtnItemSearch_Click" />
                                </td>
                                <td style="width: 20%" align="center">
                                    <asp:Button ID="BtnItemReset" runat="server" CssClass="Button02" Height="24px" Width="70px"
                                        Text="重置" OnClick="BtnItemReset_Click" />
                                    <td style="height: 20%" align="center">
                                    </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <fieldset>
                                    <legend>工资项目列表</legend>
                                    <asp:GridView ID="GridView_SalaryItemAll" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                        CssClass="GridViewStyle" CellPadding="0" Width="100%" AllowPaging="True" PageSize="10"
                                        Font-Strikeout="False" UseAccessibleHeader="False" GridLines="None" OnPageIndexChanging="GridView_SalaryItemAll_PageIndexChanging"
                                        OnRowCommand="GridView_SalaryItemAll_RowCommand" OnDataBound="GridView_SalaryItemAll_DataBound">
                                        <RowStyle CssClass="GridViewRowStyle" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                        <HeaderStyle CssClass="GridViewHead" />
                                        <FooterStyle CssClass="GridViewFooterStyle" />
                                        <Columns>
                                            <asp:BoundField DataField="SIT_Items" HeaderText="工资项目" SortExpression="SIT_Items">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbtnSelect" runat="server" CommandArgument='<%#Eval("SIT_Items")%>'
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
                                        <EditRowStyle BackColor="white" />
                                    </asp:GridView>
                                </fieldset>
                            </td>
                        </tr>
                        </tr>
                        <tr>
                            <td colspan="6" align="center">
                                <asp:Button ID="BtnCancelItem" runat="server" Width="70px" Text="关闭" CssClass="Button02"
                                    Height="24px" OnClick="BtnCancelItem_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_EditFormula" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_EditFormula" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="LblRecordItemForFormulate" runat="server" Text=""></asp:Label>&nbsp
                        公式编辑器</legend>
                    <table width="100%">
                        <tr>
                            <td style="width: 12.5%; height: 20%;" align="center">
                                <asp:Label ID="Label2" runat="server" CssClass="STYLE2" Text="公式："></asp:Label>
                                <br />
                                <asp:Label ID="Label13" runat="server" Text="（200字符内）"></asp:Label>
                            </td>
                            <td colspan="7" style="height: 20%">
                                <asp:TextBox ID="TxtFormulaEdit" runat="server" Width="700px" TextMode="MultiLine"
                                    Enabled="False" onkeyup="this.value = this.value.substring(0, 200)" onafterpaste="this.value = this.value.substring(0, 200)"
                                    Height="40px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 12.5%; height: 20%;" align="center">
                                <asp:Label ID="Label3" runat="server" CssClass="STYLE2" Text="可选字段："></asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:ListBox ID="LbCanBeUsedItem" runat="server" Height="100px" Width="195px"></asp:ListBox>
                               
                            </td>
                            <td align="left" colspan="4">
                                <table align="center">
                                    <tr>
                                        <td colspan="2">
                                            <asp:Button runat="server" ID="left" Text="(" Style="width: 42px" OnClientClick="mouseInput('left')" />
                                        </td>
                                        <td colspan="2">
                                            <asp:Button runat="server" ID="right" Text=")" Style="width: 42px" OnClientClick="mouseInput('right')" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button runat="server" ID="btn7" Text="7" Style="width: 20px" OnClientClick="mouseInput('btn7')" />
                                        </td>
                                        <td>
                                            <asp:Button runat="server" ID="btn8" Text="8" Style="width: 20px" OnClientClick="mouseInput('btn8')" />
                                        </td>
                                        <td>
                                            <asp:Button runat="server" ID="btn9" Text="9" Style="width: 20px" OnClientClick="mouseInput('btn9')" />
                                        </td>
                                        <td>
                                            <asp:Button runat="server" ID="divide" Text="/" Style="width: 20px" OnClientClick="mouseInput('divide')" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button runat="server" ID="btn4" Text="4" Style="width: 20px" OnClientClick="mouseInput('btn4')" />
                                        </td>
                                        <td>
                                            <asp:Button runat="server" ID="btn5" Text="5" Style="width: 20px" OnClientClick="mouseInput('btn5')" />
                                        </td>
                                        <td>
                                            <asp:Button runat="server" ID="btn6" Text="6" Style="width: 20px" OnClientClick="mouseInput('btn6')" />
                                        </td>
                                        <td>
                                            <asp:Button runat="server" ID="chengfa" Text="*" Style="width: 20px" OnClientClick="mouseInput('chengfa')" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button runat="server" ID="btn1" Text="1" Style="width: 20px" OnClientClick="mouseInput('btn1')" />
                                        </td>
                                        <td>
                                            <asp:Button runat="server" ID="btn2" Text="2" Style="width: 20px" OnClientClick="mouseInput('btn2')" />
                                        </td>
                                        <td>
                                            <asp:Button runat="server" ID="btn3" Text="3" Style="width: 20px" OnClientClick="mouseInput('btn3')" />
                                        </td>
                                        <td>
                                            <asp:Button runat="server" ID="minus" Text="-" Style="width: 20px" OnClientClick="mouseInput('minus')" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Button runat="server" ID="btn0" Text="0" Style="width: 42px" OnClientClick="mouseInput('btn0')" />
                                        </td>
                                        <td>
                                            <asp:Button runat="server" ID="dot" Text="." Style="width: 20px" OnClientClick="mouseInput('dot')" />
                                        </td>
                                        <td>
                                            <asp:Button runat="server" ID="plus" Text="+" Style="width: 20px" OnClientClick="mouseInput('plus')" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="width: 12.5%; height: 20%;">
                            </td>
                            <td align="center" style="width: 12.5%; height: 20%;">
                                &nbsp;
                                <asp:Label ID="LblRecordIsCheckOK" runat="server" Text="false" Visible="false"></asp:Label>
                            </td>
                            <td align="center" class="style3">
                                <asp:Button ID="Button2" runat="server" CssClass="Button02" Text="校验公式" Width="70px"
                                    Height="24px" OnClick="Button2_Click" />
                            </td>
                            <td align="center" style="width: 12.5%; height: 20%;">
                                <asp:Button ID="Button3" runat="server" CssClass="Button02" Text="重置" Width="70px"
                                    Height="24px" OnClick="Button3_Click" />
                            </td>
                            <td align="center" style="width: 12.5%; height: 20%;">
                                <asp:Button ID="Button5" runat="server" CssClass="Button02" Text="提交" Width="70px"
                                    Height="24px" OnClick="Button5_Click" />
                            </td>
                            <td align="center" style="width: 12.5%; height: 20%;">
                                <asp:Button ID="Button6" runat="server" CssClass="Button02" Text="关闭" Width="70px"
                                    Height="24px" OnClick="Button6_Click" />
                            </td>
                            <td align="center" style="width: 12.5%; height: 20%;">
                            </td>
                            <td align="center" style="width: 12.5%; height: 20%">
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
                        <asp:Label ID="LblTheSet2" runat="server" Text="LblTheSet2"></asp:Label>&nbsp 员工信息栏</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label4" runat="server" CssClass="STYLE2" Text="工号：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TxtSearchStaffNO" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label5" runat="server" CssClass="STYLE2" Text="姓名：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TxtSearchName" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label6" runat="server" CssClass="STYLE2" Text="部门：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:DropDownList ID="DdlSearchDep" runat="server" ToolTip="单击选择" AutoPostBack="true"
                                    OnSelectedIndexChanged="DdlSearchDep_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label7" runat="server" CssClass="STYLE2" Text="岗位：" Enabled="False"></asp:Label>
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
                                    Width="70px" Text="新增员工" OnClick="BtnAddEmployee_Click" />
                            </td>
                            <td colspan="3" align="left">
                                <asp:Button ID="BtnResetEmployee" runat="server" CssClass="Button02" Height="24px"
                                    Width="70px" Text="重置" OnClick="BtnResetEmployee_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="8">
                                <fieldset>
                                    <legend>属于该账套的员工列表</legend>
                                    <asp:GridView ID="Grid_Detail" runat="server" DataKeyNames="HRDD_ID" AllowSorting="True"
                                        AutoGenerateColumns="False" CssClass="GridViewStyle" Width="100%" AllowPaging="True"
                                        PageSize="20" GridLines="None" OnRowCommand="Grid_Detail_RowCommand" OnPageIndexChanging="Grid_Detail_PageIndexChanging"
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
                            </td>
                        </tr>
                        <tr>
                            <td colspan="8" align="center">
                                <asp:Button ID="BtnClosePanel_SearchEmployee" runat="server" Width="70px" Text="关闭"
                                    Height="24px" CssClass="Button02" OnClick="BtnClosePanel_SearchEmployee_Click" />
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
                                <asp:Label ID="Label9" runat="server" CssClass="STYLE2" Text="工号：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TxtAddStaffNO" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label10" runat="server" CssClass="STYLE2" Text="姓名：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TxtAddName" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label11" runat="server" CssClass="STYLE2" Text="部门：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:DropDownList ID="DdlAddDep" runat="server" ToolTip="单击选择" AutoPostBack="true"
                                    OnSelectedIndexChanged="DdlAddDep_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label12" runat="server" CssClass="STYLE2" Text="岗位：" Enabled="False"></asp:Label>
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
                                        PageSize="20" GridLines="None" OnPageIndexChanging="GridViewAdd_PageIndexChanging"
                                        EnableModelValidation="True" OnDataBound="GridViewAdd_DataBound">
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
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td colspan="2" align="right">
                                <asp:CheckBox ID="Cbx_SelectAll" runat="server" Text="全选" AutoPostBack="true" OnCheckedChanged="Cbx_SelectAll_CheckedChanged" />
                            </td>
                            <td colspan="2" align="center">
                                <asp:CheckBox ID="Cbx_SelectAllCancel" runat="server" Text="全不选" AutoPostBack="true"
                                    OnCheckedChanged="Cbx_SelectAllCancel_CheckedChanged" />
                            </td>
                            <td colspan="2" align="left">
                                <asp:CheckBox ID="Cbx_SelectOpposite" runat="server" Text="反选" AutoPostBack="true"
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
    <script type="text/javascript">
       
    </script>
</asp:Content>
