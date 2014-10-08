<%@ Page Title="计时项目维护" Language="C#" MasterPageFile="~/Other/MasterPage.master"
    AutoEventWireup="true" CodeFile="SalaryTimeItemMaintanance.aspx.cs" Inherits="SalaryMgt_SalaryTimeItemMaintanance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="Lab_Status" runat="server" Visible="false"></asp:Label>
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
        function mouseInput(key) {
            var inputbutton = document.getElementsByTagName(input);
        }
    </script>
    <asp:UpdatePanel ID="UpdatePanel_TimeItemSecrch" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_TimeItemSecrch" runat="server">
                <fieldset>
                    <legend>计时项目检索栏</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="LblSCraft" runat="server" CssClass="STYLE2" Text="工序："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 20%;" align="left">
                                <asp:TextBox ID="TxtSCraft" runat="server" Width="120px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="LblSName" runat="server" CssClass="STYLE2" Text="计时名称："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 20%;" align="left">
                                <asp:TextBox ID="TxtSName" runat="server" Width="120px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="LblSUnitPrice" runat="server" CssClass="STYLE2" Text="单价(元/H)："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 20%;" align="left">
                                <asp:TextBox ID="TxtSUnitPrice" runat="server" Width="120px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="right" colspan="2">
                                <asp:Label ID="LblRecordIsSearch" runat="server" Text="检索前" Visible="false"></asp:Label>
                                <asp:Button ID="Btn_Search_TimeItem" runat="server" CssClass="Button02" Height="24px"
                                    Text="检索" Width="70px" OnClick="Btn_Search_TimeItem_Click" />
                            </td>
                            <td style="width: 20%" align="center" colspan="2">
                                <asp:Button ID="Btn_New_TimeItem" runat="server" CssClass="Button02" Height="24px"
                                    Text="新增计时项目" Width="90px" OnClick="Btn_New_TimeItem_Click" />
                            </td>
                            <td style="height: 20%" align="left" colspan="2">
                                <asp:Button ID="Btn_Reset" runat="server" CssClass="Button02" Height="24px" Width="70px"
                                    Text="重置" OnClick="Btn_Reset_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_TimeItemGrid" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_TimeItemGrid" runat="server">
                <fieldset>
                    <legend>计时项目详情表</legend>
                    <asp:GridView ID="Grid_TimeItem" runat="server" DataKeyNames="STI_ID" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                        AllowPaging="True" PageSize="10" Font-Strikeout="False" UseAccessibleHeader="False"
                        GridLines="None" OnDataBound="Grid_TimeItem_DataBound" OnPageIndexChanging="Grid_TimeItem_PageIndexChanging"
                        OnRowCommand="Grid_TimeItem_RowCommand">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="STI_ID" HeaderText="计时项目ID" SortExpression="STI_ID" Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="PBC_Name" HeaderText="工序名称" SortExpression="PBC_Name">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="STI_Name" HeaderText="计时名称" SortExpression="STI_Name">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="STI_UnitPrice" HeaderText="现执行单价(元/H)" SortExpression="STI_UnitPrice">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="STI_IsDeleted" HeaderText="是否删除" SortExpression="STI_IsDeleted"
                                ReadOnly="True" Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnMaintance_TimeItem" runat="server" CommandArgument='<%#Eval("STI_ID")%>'
                                        CommandName="Maintance_TimeItem" OnClientClick="false">编辑</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnDelete_TimeItem" runat="server" CommandName="Delete_TimeItem"
                                        OnClientClick="return confirm('您确认删除该记录吗?')" CommandArgument='<%#Eval("STI_ID")%>'>删除</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnMaintance_TimeItemHistory" runat="server" CommandArgument='<%#Eval("STI_ID")+","+Eval("PBC_Name")+","+Eval("STI_Name")%>'
                                        CommandName="Maintance_TimeItemHistory" OnClientClick="false">查看历史单价</asp:LinkButton>
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
    <asp:UpdatePanel ID="UpdatePanel_Maintanace" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Maintanace" runat="server" Visible="false">
                <fieldset>
                    <legend>计时项目<asp:Label ID="LblAddOrEdit" runat="server" Text=""></asp:Label></legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 10%; height: 20%;" align="center">
                                <asp:Label ID="LblCraft" runat="server" CssClass="STYLE2" Text="工序："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 20%;" align="left">
                                <asp:DropDownList ID="DdlCraft" runat="server" ToolTip="单击选择">
                                </asp:DropDownList>
                                <asp:Label ID="Label14" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                    ValidationGroup="TimeItem" ControlToValidate="DdlCraft"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td style="width: 10%; height: 20%;" align="center">
                                <asp:Label ID="LblName" runat="server" CssClass="STYLE2" Text="计时名称："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 20%;" align="left">
                                <asp:TextBox ID="TxtName" runat="server" Width="120px" onfocus="annotation('Label47');"
                                    onblur="javascript:leave('Label47');" MaxLength="20"></asp:TextBox>
                                <asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                    ValidationGroup="TimeItem" ControlToValidate="TxtName"></asp:RequiredFieldValidator>
                                <asp:Label ID="Label47" runat="server" ForeColor="#999999" Text="20字内" Style="visibility: hidden;"></asp:Label>--%>
                            </td>
                            <td style="width: 10%; height: 20%;" align="center">
                                <asp:Label ID="LblUnitPrice" runat="server" CssClass="STYLE2" Text="单价(元/H)："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 20%;" align="left">
                                <asp:TextBox ID="TxtUnitPrice" runat="server" Width="100px" onkeyup="this.value=this.value.replace(/[^\d.]/g,'')"
                                    onafterpaste="this.value=this.value.replace(/[^\d.]/g,'')" MaxLength="16"></asp:TextBox>
                                <asp:Label ID="Label2" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                    ValidationGroup="TimeItem" ControlToValidate="TxtUnitPrice"></asp:RequiredFieldValidator>--%>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="格式有误"
                                    ValidationGroup="TimeItem" ControlToValidate="TxtUnitPrice" ValidationExpression="^(?!0+(?:\.0+)?$)(?:[1-9]\d*|0)(?:\.\d{1,2})?$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%; height: 20%;" align="center">
                                <asp:Label ID="LabelExecDate" runat="server" CssClass="STYLE2" Text="开始执行日期:"></asp:Label>
                            </td>
                            <td style="width: 20%; height: 20%;" align="left">
                                <asp:TextBox ID="TextBox_Execdate" Width="100px" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',false)"></asp:TextBox>
                            </td>
                            <td style="width: 10%; height: 20%;" align="center">
                            </td>
                            <td style="width: 20%; height: 20%;" align="left">
                                <asp:CheckBox ID="CbIsRecord" runat="server" Text="是否存入历史单价" />
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center" colspan="3">
                                <asp:Label ID="LblRecordSTI_ID" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Label ID="LblRecordFormerPrice" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Button ID="BtnSubmit" runat="server" CssClass="Button02" Height="24px" Text="提交"
                                    Width="70px" ValidationGroup="TimeItem" OnClick="BtnSubmit_Click" />
                            </td>
                            <td style="width: 20%" align="center" colspan="3">
                                <asp:Button ID="BtnCancel" runat="server" CssClass="Button02" Height="24px" Width="70px"
                                    Text="关闭" OnClick="BtnCancel_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_TimeItemHistoryGridView" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_TimItemHistory" runat="server" Visible="false">
                <fieldset>
                    <legend>工序(<asp:Label ID="CraftName" runat="server" Text=""></asp:Label>)&nbsp; 计时名称(<asp:Label
                        ID="TimeName" runat="server" Text=""></asp:Label>)历史计时工价<asp:Label ID="guidText"
                            runat="server" Text="" Visible="false"></asp:Label></legend>
                    <asp:GridView ID="GridView_TimeItemHistory" runat="server" DataKeyNames="STI_ID"
                        AllowSorting="True" AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0"
                        Width="100%" AllowPaging="True" PageSize="5" Font-Strikeout="False" UseAccessibleHeader="False"
                        GridLines="None" OnPageIndexChanging="GridView_TimeItemHistory_PageIndexChanging">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="STICR_ID" HeaderText="历史计时工价ID" SortExpression="STICR_ID"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="STICR_FormerPrice" HeaderText="原计时工价" SortExpression="STICR_FormerPrice">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="STICR_NewPrice" HeaderText="现计时工价" SortExpression="STICR_NewPrice">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="STICR_OpTime" HeaderText="工价修改操作时间" SortExpression="STICR_OpTime">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="STICR_OpPerson" HeaderText="工价修改操作人员" SortExpression="STICR_OpPerson">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="STICR_ExecDate" HeaderText="工价开始执行日期" SortExpression="STICR_ExecDate"
                                ReadOnly="True">
                                <ItemStyle />
                            </asp:BoundField>
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
                <table style="width: 100%;">
                    <tr>
                        <td align="center">
                            <asp:Button ID="btnHistoryClose" runat="server" CssClass="Button02" Height="24px"
                                Width="70px" Text="关闭" OnClick="btnHistoryClose_Click" align="center" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
