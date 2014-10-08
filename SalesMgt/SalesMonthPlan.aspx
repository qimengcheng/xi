<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SalesMonthPlan.aspx.cs" Inherits="SalesMgt_SalesMonthPlan"
    MasterPageFile="~/Other/MasterPage.master" Title="销售月计划" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/JS/ShortM.js" />
        </Scripts>--%>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
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
    <%--检索栏--%>
    <asp:Label ID="label_condition" runat="server" Visible="False"></asp:Label>
      <asp:Label ID="label_mainsource" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="label_mainid" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="label_CheckOrSign" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="label_department" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="label_signcondition" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="label_way" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="label_wayadd" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="label_key" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="label_detailID" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="label_grid" runat="server" Visible="False"></asp:Label>
    <asp:UpdatePanel ID="UpdatePanel_Search" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Search" runat="server" Visible="true">
                <fieldset>
                    <legend>检索条件</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 7%" align="center">
                                <asp:Label ID="Label" runat="server" Text="年份："></asp:Label>
                            </td>
                            <td style="width: 10%" align="left">
                                <asp:DropDownList ID="DropDownList1" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 7%" align="center">
                                <asp:Label ID="Label15" runat="server" Text="月份："></asp:Label>
                            </td>
                            <td style="width: 10%" align="left">
                                <asp:DropDownList ID="DropDownList4" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 7%" align="center">
                                <asp:Label ID="Label5" runat="server" Text="状态："></asp:Label>
                            </td>
                            <td style="width: 10%" align="left">
                                <asp:DropDownList ID="DropDownList5" runat="server">
                                    <asp:ListItem>已提交</asp:ListItem>
                                    <asp:ListItem>审核通过</asp:ListItem>
                                    <asp:ListItem>审核驳回</asp:ListItem>
                                   
                                </asp:DropDownList>
                            </td>
                            <td style="width: 15%" align="center">
                                <asp:Button ID="Button1" runat="server" Text="检索" CssClass="Button02" Height="24px"
                                    OnClick="SearchMonthPlan" Width="70px" />
                            </td>
                            <td style="width: 15%" align="center">
                                <asp:Button ID="Button2" runat="server" Text="新建月计划" CssClass="Button02" Height="24px"
                                    OnClick="CreateMonthPlan" Width="90px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

    <!-- 月计划列表开始-->
    <asp:UpdatePanel ID="UpdatePanel_MonthPlan" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_MonthPlan" runat="server" Visible="true">
                <fieldset>
                    <legend>销售月计划主表</legend>
                    <asp:GridView ID="Gridview_MonthPlan" runat="server" AutoGenerateColumns="False"
                        CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False" 
                        PageSize="5" AllowPaging="True" AllowSorting="True" DataKeyNames="SMSMPM_ID"
                        GridLines="None" OnRowCommand="Gridview_MonthPlan_RowCommand" OnPageIndexChanging="Gridview_MonthPlan_PageIndexChanging"
                        Width="100%" OnRowDataBound="Gridview_MonthPlan_RowDataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <%--    //隔行变色--%>
                        <Columns>
                            <asp:BoundField DataField="SMSMPM_ID" HeaderText="销售月计划ID" ReadOnly="True" SortExpression="SMSMPM_ID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMSMPM_Year" HeaderText="年份" SortExpression="SMSMPM_Year">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMSMPM_Month" HeaderText="月份" SortExpression="SMSMPM_Month">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMSMPM_State" HeaderText="状态" SortExpression="SMSMPM_State">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMSMPM_MakeMan" HeaderText="制定人" SortExpression="SMSMPM_MakeMan">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMSMPM_MakeTime" HeaderText="制定时间" SortExpression="SMSMPM_MakeTime"
                                DataFormatString="{0:yyyy-MM-dd HH:mm}">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Look1" runat="server" CommandName="Look1" OnClientClick="false"
                                        CommandArgument='<%#Eval("SMSMPM_ID")%>'>查看原始销售月计划详细</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Look2" runat="server" CommandName="Look2" OnClientClick="false"
                                        CommandArgument='<%#Eval("SMSMPM_ID")%>'>查看新增销售月计划详细</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Edit1" runat="server" CommandName="Edit1" OnClientClick="false"
                                        CommandArgument='<%#Eval("SMSMPM_ID")%>'>编辑详细</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Add1" runat="server" CommandName="Add1" OnClientClick="false"
                                        CommandArgument='<%#Eval("SMSMPM_ID")%>'>新增详细</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Sign1" runat="server" CommandName="Sign1" OnClientClick="false"
                                        CommandArgument='<%#Eval("SMSMPM_ID")%>'>会签</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Check1" runat="server" CommandName="Check1" OnClientClick="false"
                                        CommandArgument='<%#Eval("SMSMPM_ID")%>'>审核</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Track1" runat="server" CommandName="Track1" OnClientClick="false"
                                        CommandArgument='<%#Eval("SMSMPM_ID")%>'>跟踪</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnDelete1" runat="server" CommandName="Delete1" OnClientClick="return confirm('您确认删除该记录吗?')"
                                        CommandArgument='<%#Eval("SMSMPM_ID")%>'>删除</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Width="30px" />
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
                        <AlternatingRowStyle />
                    </asp:GridView>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--    新增月计划--%>
    <br />
    <asp:UpdatePanel ID="UpdatePanel_NewMonthPlan" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_NewMonthPlan" runat="server" Visible="false">
                <fieldset>
                    <legend>新建销售月计划</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 18%" align="center">
                                <asp:Label ID="Label1" runat="server" Text="年份："></asp:Label>
                            </td>
                            <td style="width: 7%" align="left">
                                <asp:DropDownList ID="DropDownList2" runat="server">
                                </asp:DropDownList><asp:Label ID="label25" Text="*" runat="server" Visible="true" ForeColor="Red"></asp:Label>
                            </td>
                            <td style="width: 18%" align="center">
                                <asp:Label ID="Label2" runat="server" Text="月份："></asp:Label>
                            </td>
                            <td style="width: 7%" align="left">
                                <asp:DropDownList ID="DropDownList3" runat="server">
                                </asp:DropDownList><asp:Label ID="label26" Text="*" runat="server" Visible="true" ForeColor="Red"></asp:Label>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label3" runat="server" Text="状态："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:DropDownList ID="DropDownList6" runat="server" Enabled="False">
                                    <asp:ListItem>已新建</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="width: 15%" align="center">
                                <asp:Label ID="Label4" runat="server" Text="制定人："></asp:Label>
                            </td>
                            <td style="width: 10%" align="left">
                                <asp:TextBox runat="server" ID="MakeMan" Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label6" runat="server" Text="第一周起始日期："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox1" onfocus="new WdatePicker(this,'%Y-%M-%D' ,true)"
                                    DataFormatString="{0:yyyy-MM-dd}" Width="90px"></asp:TextBox><asp:Label ID="label27" Text="*" runat="server" Visible="true" ForeColor="Red"></asp:Label>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label7" runat="server" Text="第一周结束日期： "></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox2" onfocus="new WdatePicker(this,'%Y-%M-%D ',true)"
                                    DataFormatString="{0:yyyy-MM-dd}" Width="98px" ></asp:TextBox><asp:Label ID="label28" Text="*" runat="server" Visible="true" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 15%" align="right" colspan="3">
                                <asp:Button ID="Button3" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    OnClick="NewMonthPlan" Width="70px" />
                            </td>
                            <td style="width: 15%" align="center" colspan="4">
                                <asp:Button ID="Button4" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="CloseMonthPlan" Width="70px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <!-- 新增月计划结束-->
    <!-- 月计划详细列表开始-->
    <asp:UpdatePanel ID="UpdatePanel_MonthPlanDetail" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_MonthPlanDetail" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="label20" runat="server" Visible="true"></asp:Label>原始销售月计划详细表</legend>
                      <asp:Button ID="Button10" runat="server" Text="新增产品型号" CssClass="Button02" Height="24px" Visible="false"
                                    OnClick="AddProductModell" Width="90px" />   <asp:Label ID="label23" Text="请注意月计划中的基本单位是千个" runat="server" Visible="true" ForeColor="Red"></asp:Label>
                    <asp:GridView ID="Gridview_MonthPlanDetail" runat="server" AutoGenerateColumns="False"
                        CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False" 
                        GridLines="None" PageSize="20" AllowPaging="True" AllowSorting="True" DataKeyNames="detailID"
                        OnRowCommand="Gridview_MonthPlanDetail_RowCommand" OnPageIndexChanging="Gridview_MonthPlanDetail_PageIndexChanging"
                        Width="100%" ondatabound="Gridview_MonthPlanDetail_DataBound">
                        <%--    //隔行变色--%>
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="detailID" HeaderText="月计划详细ID" SortExpression="detailID"
                                Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="ps_name" HeaderText="产品系列" SortExpression="ps_name">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="pt_name" HeaderText="产品名称" SortExpression="pt_name">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="PT_Note" HeaderText="产品备注" SortExpression="PT_Note">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="lastmonthamount" HeaderText="上月计划量" SortExpression="lastmonthamount">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="lastactual" HeaderText="上月实际量" SortExpression="lastactual">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="ordernum" HeaderText="订单总量" SortExpression="ordernum">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="planamount" HeaderText="本月计划量" SortExpression="planamount">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="本月计划量" HeaderStyle-Font-Bold="true" Visible="true">
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" Width="80px" Text='<%#Eval("planamount")%>'></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle Font-Bold="True" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="request" HeaderText="产品要求" SortExpression="request">
                                <ItemStyle />
                                <HeaderStyle Width="100px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="产品要求" HeaderStyle-Font-Bold="true" Visible="true">
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBox5" runat="server" Width="99%" Text='<%#Eval("request")%>'></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle Font-Bold="True" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="remark" HeaderText="备注" SortExpression="remark">
                                <ItemStyle />
                                <HeaderStyle Width="100px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="备注" HeaderStyle-Font-Bold="true" Visible="true">
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBox6" runat="server" Width="99%" Text='<%#Eval("remark")%>'></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle Font-Bold="True" />
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete3" runat="server" CommandName="Delete2" OnClientClick="return confirm('您确认删除该记录吗?')"
                                        CommandArgument='<%#Eval("detailID")%>'>删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
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
                                        <asp:TextBox ID="textbox" runat="server" Width="20px"></asp:TextBox>
                                        <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                            CommandName="Page" Text="GO" /><!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
                                    </td>
                                </tr>
                            </table>
                        </PagerTemplate>
                    </asp:GridView>
                    <table width="100%">
                        <tr>
                            <td style="width: 25%" align=right>
                                <asp:Button ID="Button8" runat="server" Text="提交" CssClass="Button02" Height="24px" Visible="false"
                                    OnClick="NewMonthPlanDetail" Width="70px" />
                            </td>
                            <td style="width: 25%" align="center">
                                <asp:Button ID="Button15" runat="server" Text="保存" CssClass="Button02" Height="24px" Visible="false"
                                    OnClick="SaveMonthPlanDetail" Width="70px" />
                            </td>
                            <td style="width: 25%" align="left">
                                <asp:Button ID="Button9" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="CloseMonthPlanDetail" Width="70px" />
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%-- 月计划详细新增表--%>
    <asp:UpdatePanel ID="UpdatePanel_MonthPlanDetail_Add" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_MonthPlanDetail_Add" runat="server" Visible="false">
                <fieldset>
                <asp:Button ID="Button13" runat="server" Text="新增产品型号" CssClass="Button02" Height="24px" Visible="false"
                                        OnClick="AddProductModell1" Width="90px" /> <asp:Label ID="label24" Text="请注意月计划中的基本单位是千个" runat="server" Visible="true" ForeColor="Red"></asp:Label>
                    <legend>
                        <asp:Label ID="label21" runat="server" Visible="True"></asp:Label>新增销售月计划详细表</legend>
                    <asp:GridView ID="Gridview_MonthPlanDetailAdd" runat="server" AutoGenerateColumns="False"
                        CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False" 
                        GridLines="None" PageSize="20" AllowPaging="True" AllowSorting="True" DataKeyNames="detailID"
                        OnRowCommand="Gridview_MonthPlanDetail_Add_RowCommand" OnPageIndexChanging="Gridview_MonthPlanDetail_Add_PageIndexChanging"
                        Width="100%" ondatabound="Gridview_MonthPlanDetailAdd_DataBound" OnRowDataBound="Gridview_MonthPlanDetailAdd_RowDataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <%--    //隔行变色--%>
                        <Columns>
                            <asp:BoundField DataField="detailID" HeaderText="月计划详细ID" SortExpression="detailID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ps_name" HeaderText="产品系列" SortExpression="ps_name">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="pt_name" HeaderText="产品名称" SortExpression="pt_name">
                                <ItemStyle />
                            </asp:BoundField>
                               <asp:BoundField DataField="PT_Note" HeaderText="产品备注" SortExpression="PT_Note">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="lastmonthamount" HeaderText="上月计划量" SortExpression="lastmonthamount">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="lastactual" HeaderText="上月实际量" SortExpression="lastactual">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="ordernum" HeaderText="订单总量" SortExpression="ordernum">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="planamount" HeaderText="新增计划量" SortExpression="planamount">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="新增计划量" HeaderStyle-Font-Bold="true" Visible="false">
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBox4" runat="server" Width="80px" Text='<%#Eval("planamount")%>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="request" HeaderText="产品要求" SortExpression="request">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="产品要求" HeaderStyle-Font-Bold="true" Visible="false">
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBox7" runat="server" Width="99%" Text='<%#Eval("request")%>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="remark" HeaderText="备注" SortExpression="remark">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="备注" HeaderStyle-Font-Bold="true" Visible="false">
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBox8" runat="server" Width="99%" Text='<%#Eval("remark")%>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="checkresult" HeaderText="审核状态" SortExpression="checkresult">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete3" runat="server" CommandName="Delete3" OnClientClick="return confirm('您确认删除该记录吗?')"
                                        CommandArgument='<%#Eval("detailID")%>'>删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Check3" runat="server" CommandName="Check3" CommandArgument='<%#Eval("detailID")%>'>审核</asp:LinkButton>
                                </ItemTemplate>
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
                        <AlternatingRowStyle />
                    </asp:GridView>
                    <table width="100%">
                        <tr>
                            <td style="width: 25%" align="right">
                                <asp:Button ID="Button11" runat="server" Text="提交" CssClass="Button02" Height="24px" Visible="false"
                                    OnClick="NewMonthPlanDetail_Add" Width="70px" />
                            </td>
                            <td style="width: 25%" align="center">
                                <asp:Button ID="Button16" runat="server" Text="保存" CssClass="Button02" Height="24px" Visible="false"
                                    OnClick="SaveMonthPlanDetail_Add" Width="70px" />
                                <td style="width: 25%" align="left">
                                    <asp:Button ID="Button12" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                        OnClick="CloseMonthPlanDetail_Add" Width="70px" />
                                </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <!-- 产品型号列表开始-->
    <asp:UpdatePanel ID="UpdatePanel_Product" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" Visible="false">
                <fieldset>
                    <legend>产品型号检索</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 7%" align="center">
                                <asp:Label ID="Label10" runat="server" Text="产品系列："></asp:Label>
                            </td>
                            <td style="width: 10%" align="left">
                                <asp:TextBox ID="TextBox_Series" runat="server" Width="98%"></asp:TextBox>
                            </td>
                            <td style="width: 7%" align="center">
                                <asp:Label ID="Label11" runat="server" Text="产品型号："></asp:Label>
                            </td>
                            <td style="width: 10%" align="left">
                                <asp:TextBox ID="TextBox_ProductName" runat="server" Width="98%"></asp:TextBox>
                            </td>
                            </td>
                            <td style="width: 15%" align="center">
                                <asp:Button ID="Button14" runat="server" Text="检索" CssClass="Button02" Height="24px"
                                    OnClick="SelectProType" Width="70px" />
                            </td>
                               <td style="width: 15%" align="center">
                                <asp:Button ID="Button5" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="CloseProType" Width="80px" />
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
            <asp:Panel ID="Panel_Product" runat="server" Visible="false">
                <fieldset>
                    <legend>产品型号表</legend>
                    <asp:GridView ID="GridView_ProType" runat="server" AllowPaging="True" PageSize="10"
                        AutoGenerateColumns="False" CellPadding="0" CssClass="GridViewStyle" DataKeyNames="PT_ID"
                        GridLines="None" AllowSorting="True" OnRowDataBound="GridView_ProType_RowDataBound"
                        OnPageIndexChanging="GridView_ProType_PageIndexChanging">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemStyle Width="5%" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox2" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="PT_ID" HeaderText="产品型号ID" Visible="false" />
                            <asp:BoundField DataField="PT_Name" HeaderText="产品型号" ItemStyle-Width="30%" />
                                 <asp:BoundField DataField="PT_Note" HeaderText="备注" ItemStyle-Width="30%" />
                            <asp:BoundField DataField="PS_Name" HeaderText="产品系列" ItemStyle-Width="30%" />
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
                            <asp:Label ID="Label16" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <table style="width: 100%; text-align: center;" class="STYLE2">
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:CheckBox ID="Cbx2_SelectAll" runat="server" Text="全选" AutoPostBack="true" OnCheckedChanged="Cbx2_SelectAll_CheckedChanged" />
                                <asp:Button ID="ButtonPro" runat="server" CssClass="Button02" Text="提 交" OnClick="ButtonProType_Click" Width="70px" Height="24px"/>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--    会签部分--%>
    <asp:UpdatePanel ID="UpdatePanel_Sign" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Sign" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="label22" runat="server" Visible="true"></asp:Label>会签栏</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 15%">
                                <asp:Label ID="label_shegnchanbu" runat="server" Visible="True"></asp:Label>
                            </td>
                            <td style="width: 12%">
                                部长:
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TB_shengchanman" runat="server" Width="100%" ReadOnly="true" Enabled="False"></asp:TextBox>
                            </td>
                            <td style="width: 13%" align="right">
                                会签时间:
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TB_shengchantime" runat="server" Width="98%" ReadOnly="true" DataFormatString="{0:yyyy-MM-dd HH:mm}"
                                    Enabled="False"></asp:TextBox>
                            </td>
                            <td ></td>
                            <td ></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="LB1000" runat="server" ForeColor="#999999" Text="200字以内" Style="visibility: hidden;"></asp:Label>
                            </td>
                            <td>
                                会签意见:
                            </td>
                            <td colspan="7">
                                <asp:TextBox ID="TB_shengchanyijian" runat="server" Height="80px" MaxLength="200"
                                    onfocus="annotation('Label47');" onblur="javascript:leave('Label47');" TextMode="MultiLine"
                                    Width="99%" Enabled="False"></asp:TextBox>
                                <asp:Label ID="Label47" runat="server" ForeColor="#999999" Text="200字以内" Style="visibility: hidden;"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="label_gongchengbu" runat="server" Visible="True"></asp:Label>
                            </td>
                            <td>
                                主管经理:
                            </td>
                            <td style="width: 15%">
                                <asp:TextBox ID="TB_gongchengman" runat="server" Width="100%" ReadOnly="true" Enabled="False"></asp:TextBox>
                            </td>
                            <td align="right">
                                会签时间:
                            </td>
                            <td>
                                <asp:TextBox ID="TB_gongchengtime" runat="server" Width="98%" ReadOnly="true" Enabled="False"
                                    DataFormatString="{0:yyyy-MM-dd HH:mm}"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="LB1001" runat="server" ForeColor="#999999" Text="200字以内" Style="visibility: hidden;"></asp:Label>
                            </td>
                            <td>
                                会签意见:
                            </td>
                            <td colspan="7">
                                <asp:TextBox ID="TB_gongchengyijian" runat="server" Height="80px" MaxLength="200"
                                    onfocus="annotation('Label14');" onblur="javascript:leave('Label14');" TextMode="MultiLine"
                                    Width="99%" Enabled="False"></asp:TextBox>
                                <asp:Label ID="Label14" runat="server" ForeColor="#999999" Text="200字以内" Style="visibility: hidden;"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="label_shebeibu" runat="server" Visible="True"></asp:Label>
                            </td>
                            <td>
                                生产一部会签人:
                            </td>
                            <td >
                                <asp:TextBox ID="TB_shebeiman" runat="server" Width="100%" ReadOnly="true" Enabled="False"></asp:TextBox>
                            </td>
                            <td align="right">
                                会签时间:
                            </td>
                            <td>
                                <asp:TextBox ID="TB_shebeitime" runat="server" Width="98%" ReadOnly="true" Enabled="False"
                                    DataFormatString="{0:yyyy-MM-dd HH:mm}"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="LB1002" runat="server" ForeColor="#999999" Text="100字以内" Style="visibility: hidden;"></asp:Label>
                            </td>
                            <td>
                                生产一部会签意见:
                            </td>
                            <td colspan="7">
                                <asp:TextBox ID="TB_shebeiyijian" runat="server" Height="80px" MaxLength="200" onfocus="annotation('Label17');"
                                    onblur="javascript:leave('Label17');" TextMode="MultiLine" Width="99%" Enabled="False"></asp:TextBox>
                                <asp:Label ID="Label17" runat="server" ForeColor="#999999" Text="200字以内" Style="visibility: hidden;"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td >
                                <asp:Label ID="label_pinbaobu" runat="server" Visible="True"></asp:Label>
                            </td>
                            <td >
                                生产二部会签人:
                            </td>
                            <td >
                                <asp:TextBox ID="TB_pinbaoman" runat="server" Width="100%" ReadOnly="true" Enabled="False"></asp:TextBox>
                            </td>
                            <td align="right">
                                会签时间:
                            </td>
                            <td >
                                <asp:TextBox ID="TB_pinbaotime" runat="server" Width="98%" ReadOnly="true" DataFormatString="{0:yyyy-MM-dd HH:mm}"
                                    Enabled="False"></asp:TextBox>
                            </td>
                            <td >
                            </td>
                            <td >
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label8" runat="server" ForeColor="#999999" Text="200字以内" Style="visibility: hidden;"></asp:Label>
                            </td>
                            <td>
                                生产二部会签意见:
                            </td>
                            <td colspan="7">
                                <asp:TextBox ID="TB_pinbaoyijian" runat="server" Height="80px" MaxLength="200" onfocus="annotation('Label18');"
                                    onblur="javascript:leave('Label18');" TextMode="MultiLine" Width="99%" Enabled="False"></asp:TextBox>
                                <asp:Label ID="Label18" runat="server" ForeColor="#999999" Text="200字以内" Style="visibility: hidden;"></asp:Label>
                            </td>
                        </tr>
                     <%--   <tr>
                            <td >
                                <asp:Label ID="label_caiwubu" runat="server" Visible="True"></asp:Label>
                            </td>
                            <td >
                                财务部会签人:
                            </td>
                            <td >
                                <asp:TextBox ID="TB_caiwuman" runat="server" Width="100%" ReadOnly="true" Enabled="False"></asp:TextBox>
                            </td>
                            <td align="right">
                                会签时间:
                            </td>
                            <td >
                                <asp:TextBox ID="TB_caiwutime" runat="server" Width="98%" ReadOnly="true" DataFormatString="{0:yyyy-MM-dd HH:mm}"
                                    Enabled="False"></asp:TextBox>
                            </td>
                            <td >
                            </td>
                            <td >
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label9" runat="server" ForeColor="#999999" Text="200字以内" Style="visibility: hidden;"></asp:Label>
                            </td>
                            <td>
                                财务部会签意见:
                            </td>
                            <td colspan="7">
                                <asp:TextBox ID="TB_caiwuyijian" runat="server" Height="80px" MaxLength="200" onfocus="annotation('Label19');"
                                    onblur="javascript:leave('Label19');" TextMode="MultiLine" Width="99%" Enabled="False"></asp:TextBox>
                                <asp:Label ID="Label19" runat="server" ForeColor="#999999" Text="100字以内" Style="visibility: hidden;"></asp:Label>
                            </td>
                        </tr>--%>
                        <tr>
                            <td>
                                <asp:Label ID="label_lingdao" runat="server" Visible="True"></asp:Label>
                            </td>
                            <td>
                                审核领导:
                            </td>
                            <td >
                                <asp:TextBox ID="TB_lingdao" runat="server" Width="100%" ReadOnly="true" Enabled="False"></asp:TextBox>
                            </td>
                            <td align="right">
                                审核时间:
                            </td>
                            <td>
                                <asp:TextBox ID="TB_lingdaotime" runat="server" Width="98%" ReadOnly="true" Enabled="False"
                                    DataFormatString="{0:yyyy-MM-dd HH:mm}"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="LB1004" runat="server" ForeColor="#999999" Text="100字以内" Style="visibility: hidden;"></asp:Label>
                            </td>
                            <td>
                                审核意见:
                            </td>
                            <td colspan="7">
                                <asp:TextBox ID="TB_lingdaoyijian" runat="server" Height="80px" MaxLength="200" onblur="javascript:leave('LB1004');"
                                    onfocus="annotation('LB1004');" TextMode="MultiLine" Width="99%" Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="9">
                        </tr>
                        <table style="width: 100%">
                            <tr>
                                <td style="width: 33%; text-align: right">
                                    <asp:Button ID="BT_TKOK" runat="server" CssClass="Button02" OnClick="BT_TKOK_Click" Height="24px"
                                        Text="通过" Width="70px" />
                                    <%--    OnClientClick="$find('gvEdit').hide();"--%>
                                </td>
                                <td style="width: 34%; text-align: center">
                                    <asp:Button ID="BT_TKNotOK" runat="server" CssClass="Button02" OnClick="BT_TKNotOK_Click" Height="24px"
                                        Text="驳回" Width="70px" />
                                </td>
                                <td style="width: 33%; text-align: left">
                                    <asp:Button ID="BT_TKCancel" runat="server" CssClass="Button02" OnClick="BT_TKCanel_Click" Height="24px"
                                        Text="关闭" Width="70px" />
                                </td>
                        </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_ADDCheck" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_ADDCheck" runat="server" Visible="false">
                <fieldset>
                    <legend>新增计划会签栏</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 15%">
                                <asp:Label ID="label12" runat="server" Visible="True"></asp:Label>
                            </td>
                            <td style="width: 12%">
                                审核人:
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TextBox_AddMan" runat="server" Width="100%" ReadOnly="true" Enabled="False"></asp:TextBox>
                            </td>
                            <td style="width: 13%" align="right">
                                审核时间:
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TextBox_Addtime" runat="server" Width="98%" ReadOnly="true" DataFormatString="{0:yyyy-MM-dd HH:mm}"
                                    Enabled="False"></asp:TextBox>
                            </td>
                            <td style="width: 15%">
                            </td>
                            <td style="width: 10%">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label13" runat="server" ForeColor="#999999" Text="200字以内" Style="visibility: hidden;"></asp:Label>
                            </td>
                            <td>
                                审核意见:
                            </td>
                            <td colspan="7">
                                <asp:TextBox ID="TextBox_AddOpinion" runat="server" Height="80px" MaxLength="200"
                                    onblur="javascript:leave('LB1000');" onfocus="annotation('LB1000');" TextMode="MultiLine"
                                    Width="99%"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 33%; text-align: right">
                                <asp:Button ID="Button17" runat="server" CssClass="Button02" OnClick="BT_ADD_TKOK_Click" Height="24px"
                                    Text="通过" Width="70px" />
                                <%--    OnClientClick="$find('gvEdit').hide();"--%>
                            </td>
                            <td style="width: 34%; text-align: center">
                                <asp:Button ID="Button18" runat="server" CssClass="Button02" OnClick="BT_ADD_TKNotOK_Click" Height="24px"
                                    Text="驳回" Width="70px" />
                            </td>
                            <td style="width: 33%; text-align: left">
                                <asp:Button ID="Button19" runat="server" CssClass="Button02" OnClick="BT_ADD_TKCanel_Click" Height="24px"
                                    Text="关闭" Width="70px" />
                            </td>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
