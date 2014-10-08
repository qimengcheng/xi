<%@ Page Title="计件项目维护" Language="C#" MasterPageFile="~/Other/MasterPage.master"
    AutoEventWireup="true" CodeFile="SalaryPieceworkItemMaintanance.aspx.cs" Inherits="SalaryMgt_SalaryPieceworkItemMaintanance" %>

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
    </script>
    <asp:UpdatePanel ID="UpdatePanel_PieceworkItemSecrch" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_PieceworkItemSecrch" runat="server">
                <fieldset>
                    <legend>计件项目检索栏</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="LblSCraft" runat="server" CssClass="STYLE2" Text="工序："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 20%;" align="left">
                                <asp:TextBox ID="TxtSCraft" runat="server" Width="120px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="LblSProType" runat="server" CssClass="STYLE2" Text="计件系列："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 20%;" align="left">
                                <asp:TextBox ID="TxtSProType" runat="server" Width="120px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label3" runat="server" CssClass="STYLE2" Text="计件项目名称："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 20%;" align="left">
                                <asp:TextBox ID="TxtItemName" runat="server" Width="120px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="LblSUnitPrice" runat="server" CssClass="STYLE2" Text="单价(元/只)："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 20%;" align="left">
                                <asp:TextBox ID="TxtSUnitPrice" runat="server" Width="120px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="right" colspan="2">
                                <asp:Label ID="LblRecordIsSearch" runat="server" Text="检索前" Visible="false"></asp:Label>
                                <asp:Button ID="Btn_Search_PieceworkItem" runat="server" CssClass="Button02" Height="24px"
                                    Text="检索" Width="70px" OnClick="Btn_Search_PieceworkItem_Click" />
                            </td>
                            <td style="width: 20%" align="center" colspan="2">
                                <asp:Button ID="Btn_New_PieceworkItem" runat="server" CssClass="Button02" Height="24px"
                                    Text="新增计件项目" Width="90px" OnClick="Btn_New_PieceworkItem_Click" />
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
    <asp:UpdatePanel ID="UpdatePanel_PieceworkItemGrid" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_PieceworkItemGrid" runat="server">
                <fieldset>
                    <legend>计件项目列表</legend>
                    <asp:GridView ID="Grid_PieceworkItem" runat="server" DataKeyNames="SPI_ID" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                        AllowPaging="True" PageSize="10" Font-Strikeout="False" UseAccessibleHeader="False"
                        GridLines="None" OnDataBound="Grid_PieceworkItem_DataBound" OnPageIndexChanging="Grid_PieceworkItem_PageIndexChanging"
                        OnRowCommand="Grid_PieceworkItem_RowCommand">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="SPI_ID" HeaderText="计件项目ID" SortExpression="SPI_ID" Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="PBC_ID" HeaderText="工序ID" SortExpression="PBC_ID" Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SPS_ID" HeaderText="薪资计件系列ID" SortExpression="SPS_ID"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="PBC_Name" HeaderText="工序名称" SortExpression="PBC_Name">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SPS_Name" HeaderText="计件系列" SortExpression="SPS_Name">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SPI_Name" HeaderText="计件项目名称" SortExpression="SPI_Name">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SPI_UnitPrice" HeaderText="单价(元/只)" SortExpression="SPI_UnitPrice">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnMaintance_PieceworkItem" runat="server" CommandArgument='<%#Eval("SPI_ID")+","+Eval("PBC_ID")+","+Eval("SPS_ID")+","+Eval("PBC_Name")+","+Eval("SPS_Name")+","+Eval("SPI_Name")+","+Eval("SPI_UnitPrice")%>'
                                        CommandName="Maintance_PieceworkItem" OnClientClick="false">编辑</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnDelete_PieceworkItem" runat="server" CommandName="Delete_PieceworkItem"
                                        OnClientClick="return confirm('您确认删除该记录吗?')" CommandArgument='<%#Eval("SPI_ID")%>'>删除</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnMaintance_TimeItemHistory" runat="server" CommandArgument='<%#Eval("SPI_ID")+","+Eval("PBC_ID")+","+Eval("SPS_ID")+","+Eval("PBC_Name")+","+Eval("SPS_Name")+","+Eval("SPI_Name")+","+Eval("SPI_UnitPrice")%>'
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
    <asp:UpdatePanel ID="UpdatePanel_PieceworkItem" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_PieceworkItem" runat="server" Visible="false">
                <fieldset>
                    <legend>计件项目<asp:Label ID="LblAddOrEdit" runat="server" Text=""></asp:Label></legend>
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
                                    ValidationGroup="PieceworkItem" ControlToValidate="DdlCraft"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td style="width: 10%; height: 20%;" align="center">
                                <asp:Label ID="LblProType" runat="server" CssClass="STYLE2" Text="计件系列："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 20%;" align="left">
                                <asp:TextBox ID="TxtProType" runat="server" Width="120px" Enabled="false"></asp:TextBox>
                                <asp:Button ID="BtnChoose" runat="server" CssClass="Button02" Height="24px" Text="选择..."
                                    Width="40px" OnClick="BtnChoose_Click" />
                                <asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                    ValidationGroup="PieceworkItem" ControlToValidate="TxtProType"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label4" runat="server" CssClass="STYLE2" Text="计件项目名称："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 20%;" align="left">
                                <asp:TextBox ID="TxtItemNameEdit" runat="server" Width="120px"></asp:TextBox>
                                <asp:Label ID="Label5" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%; height: 20%;" align="center">
                                <asp:Label ID="LblUnitPrice" runat="server" CssClass="STYLE2" Text="单价(元/只)："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 20%;" align="left">
                                <asp:TextBox ID="TxtUnitPrice" runat="server" Width="100px" onkeyup="this.value=this.value.replace(/[^\d.]/g,'')"
                                    onafterpaste="this.value=this.value.replace(/[^\d.]/g,'')" MaxLength="16"></asp:TextBox>
                                <asp:Label ID="Label2" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                    ValidationGroup="PieceworkItem" ControlToValidate="TxtUnitPrice"></asp:RequiredFieldValidator>--%>
                                <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="格式有误"
                                    ValidationGroup="PieceworkItem" ControlToValidate="TxtUnitPrice" ValidationExpression="^(?!0+(?:\.0+)?$)(?:[1-9]\d*|0)(?:\.\d{1,2})?$"></asp:RegularExpressionValidator>--%>
                            </td>
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
                                <asp:Label ID="LblRecordSPI_ID" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Button ID="BtnSubmit" runat="server" CssClass="Button02" Height="24px" Text="提交"
                                    Width="70px" ValidationGroup="PieceworkItem" OnClick="BtnSubmit_Click" />
                                <asp:Label ID="LblRecordProTypeID" runat="server" Text="" Visible="false"></asp:Label>
                            </td>
                            <td style="width: 20%" align="center" colspan="3">
                                <asp:Label ID="LblRecordFormerPrice" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Button ID="BtnCancel" runat="server" CssClass="Button02" Height="24px" Width="70px"
                                    Text="关闭" OnClick="BtnCancel_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_ProTypeChoose" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_ProTypeChoose" runat="server" Visible="false">
                <fieldset>
                    <legend>计件系列检索栏</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="LblCProType" runat="server" CssClass="STYLE2" Text="计件系列:"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtCProType" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="LblRecordIsCSearch" runat="server" Text="检索前" Visible="false"></asp:Label>
                                <asp:Button ID="BtnCSearch" runat="server" CssClass="Button02" Height="24px" Text="检索"
                                    Width="70px" OnClick="BtnCSearch_Click" />
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Button ID="BtnCReset" runat="server" CssClass="Button02" Height="24px" Width="70px"
                                    Text="重置" OnClick="BtnCReset_Click1" />
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Button ID="BtnCCancel" runat="server" CssClass="Button02" Height="24px" Width="70px"
                                    Text="关闭" OnClick="BtnCCancel_Click1" />
                            </td>
                        </tr>
                    </table>
                    <fieldset>
                        <legend>计件系列选择列表</legend>
                        <asp:GridView ID="GridView__ProTypeChoose" runat="server" DataKeyNames="SPS_ID" AllowSorting="True"
                            AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                            AllowPaging="True" PageSize="10" Font-Strikeout="False" UseAccessibleHeader="False"
                            GridLines="None" OnPageIndexChanging="GridView__ProTypeChoose_PageIndexChanging"
                            OnRowCommand="GridView__ProTypeChoose_RowCommand">
                            <RowStyle CssClass="GridViewRowStyle" />
                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                            <HeaderStyle CssClass="GridViewHead" />
                            <FooterStyle CssClass="GridViewFooterStyle" />
                            <Columns>
                                <asp:BoundField DataField="SPS_ID" HeaderText="ID" SortExpression="SPS_ID" Visible="false">
                                    <ItemStyle />
                                </asp:BoundField>
                                <asp:BoundField DataField="SPS_Name" HeaderText="计件系列" SortExpression="SPS_Name">
                                    <ItemStyle />
                                </asp:BoundField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtnMaintance_Choose" runat="server" CommandArgument='<%#Eval("SPS_ID")%>'
                                            CommandName="Maintance_Choose" OnClientClick="false">选择</asp:LinkButton>
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
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
     <asp:UpdatePanel ID="UpdatePanel_TimeItemHistoryGridView" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_TimItemHistory" runat="server" Visible="false">
                <fieldset>
                    <legend>系列(<asp:Label ID="CraftName" runat="server" Text="" ></asp:Label>)&nbsp; 计件项目名称(<asp:Label ID="TimeName" runat="server" Text="" ></asp:Label>)历史计件工价<asp:Label ID="guidText" runat="server" Text="" Visible="false"></asp:Label></legend>
                                            
                <asp:GridView ID="GridView_TimeItemHistory" runat="server" 
                     AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                        AllowPaging="True" PageSize="5" Font-Strikeout="False" UseAccessibleHeader="False"
                        GridLines="None" 
                    onpageindexchanging="GridView_TimeItemHistory_PageIndexChanging" >
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="SPICR_ID" HeaderText="历史计时工价ID" SortExpression="SPICR_ID" Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SPICR_FormerPrice" HeaderText="原计件工价" SortExpression="SPICR_FormerPrice">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SPICR_NewPrice" HeaderText="现计件工价" SortExpression="SPICR_NewPrice">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SPICR_OpTime" HeaderText="工价修改操作时间" SortExpression="SPICR_OpTime">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SPICR_OpPerson" HeaderText="工价修改操作人员" SortExpression="SPICR_OpPerson">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SPICR_ExecDate" HeaderText="工价开始执行日期" SortExpression="SPICR_ExecDate"
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
                    <asp:Button ID="btnHistoryClose" runat="server" CssClass="Button02" Height="24px" Width="70px"
                        Text="关闭" align="center" onclick="btnHistoryClose_Click"/>
                    </td>
                    </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
