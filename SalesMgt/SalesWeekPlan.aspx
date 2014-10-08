<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SalesWeekPlan.aspx.cs" Inherits="SalesMgt_SalesWeekPlan"
    MasterPageFile="~/Other/MasterPage.master" Title="销售周计划" %>

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
    <asp:Label ID="label_condition" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="label_department" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="label_signcondition" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="label_weekID" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="label_detailcondition" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="label_way" runat="server" Visible="False"></asp:Label>
    <asp:UpdatePanel ID="UpdatePanel_Search" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Search" runat="server" Visible="true">
                <fieldset>
                    <legend>检索条件</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 12%" align="right">
                                <asp:Label ID="Label" runat="server" Text="年份："></asp:Label>
                            </td>
                            <td style="width: 18%" align="left">
                                <asp:DropDownList ID="DropDownList1" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 15%" align="right">
                                <asp:Label ID="Label15" runat="server" Text="周次："></asp:Label>            
                            </td>
                            <td style="width: 10%" align="left">
                                <asp:DropDownList ID="DropDownList2" runat="server">
                                </asp:DropDownList>
                            </td> 
                             <td style="width: 12%" align="right">  
                                状态：
                            </td>
                            <td align="left">
                             <asp:DropDownList ID="DropDownList3" runat="server">
                                    <asp:ListItem>已新建</asp:ListItem>
                                    <asp:ListItem>已提交</asp:ListItem>
                                    <asp:ListItem>会签中</asp:ListItem>
                                    <asp:ListItem>会签通过</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 13%" align="right">
                                <asp:Label ID="Label5" runat="server" Text="起始时间从："></asp:Label>
                            </td>
                            <td align="left" colspan="2">
                                
                                <asp:TextBox runat="server" ID="TextBox1" onfocus="new WdatePicker(this,'%Y-%M-%D' ,true)"
                                    DataFormatString="{0:yyyy-MM-dd}" Width="110px"  ></asp:TextBox>
                                到
                                <asp:TextBox runat="server" ID="TextBox2" onfocus="new WdatePicker(this,'%Y-%M-%D' ,true)"
                                    DataFormatString="{0:yyyy-MM-dd}" Width="110px"  ></asp:TextBox>
                            </td>
                            <td></td>
                            <td align="right">
                                <asp:Label ID="Label2" runat="server" Text="结束时间从："></asp:Label>
                            </td>
                            <td align="left" colspan="3">
                                <asp:TextBox runat="server" ID="TextBox3" onfocus="new WdatePicker(this,'%Y-%M-%D' ,true)"
                                    DataFormatString="{0:yyyy-MM-dd}" Width="110px"  ></asp:TextBox>
                                到
                                <asp:TextBox runat="server" ID="TextBox4" onfocus="new WdatePicker(this,'%Y-%M-%D' ,true)"
                                    DataFormatString="{0:yyyy-MM-dd}" Width="110px"  ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" colspan="2">
                                <asp:Button ID="Button2" runat="server" Text="检索" CssClass="Button02" Height="24px"
                                    OnClick="SearchWeekPlan" Width="70px" />
                            </td>
                            <td align="center" colspan="2">
                                <asp:Button ID="Button3" runat="server" Text="新增周计划" CssClass="Button02" Height="24px"
                                    OnClick="CreateWeekPlan" Width="90px" />
                            </td>
                            <td align="left" colspan="2">
                                <asp:Button ID="Button1" runat="server" Text="重置" CssClass="Button02" Height="24px"
                                    OnClick="ClearWeekPlan" Width="70px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--检索结束--%>
    <%--周计划主表开始--%>
    <asp:UpdatePanel ID="UpdatePanel_WeekPlan" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_WeekPlan" runat="server" Visible="false">
                <fieldset>
                    <legend>销售周计划主表</legend>
                    <asp:GridView ID="Gridview_WeekPlan" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle"
                        CellPadding="0" UseAccessibleHeader="False" 
                        PageSize="10" GridLines="None"
                        AllowPaging="True" AllowSorting="True" DataKeyNames="SMSWPM_ID" OnRowCommand="Gridview_WeekPlan_RowCommand"
                        OnPageIndexChanging="Gridview_WeekPlan_PageIndexChanging" Width="100%" 
                        OnRowDataBound="Gridview_WeekPlan_RowDataBound" 
                        ondatabound="Gridview_WeekPlan_DataBound">
                        <%--    //隔行变色--%>
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="SMSWPM_ID" HeaderText="周计划详细ID" SortExpression="SMSWPM_ID"
                                Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="SMSWPM_Year" HeaderText="年份" SortExpression="SMSWPM_Year">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMSWPM_Week" HeaderText="周次" SortExpression="SMSWPM_Week">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMSWPM_StartTime" HeaderText="起始时间" SortExpression="SMSWPM_StartTime"
                                DataFormatString="{0:yyyy-MM-dd }">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMSWPM_EndTime" HeaderText="结束时间" SortExpression="SMSWPM_EndTime"
                                DataFormatString="{0:yyyy-MM-dd }">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMSWPM_MakeTime" HeaderText="制定时间" SortExpression="SMSWPM_MakeTime" DataFormatString="{0:yyyy-MM-dd HH:mm}">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMSWPM_State" HeaderText="状态" SortExpression="SMSWPM_State">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMSWPM_Remark" HeaderText="备注" SortExpression="SMSWPM_Remark">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Edit1" runat="server" CommandName="Edit1" CommandArgument='<%#Eval("SMSWPM_ID")%>'>编辑</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Look1" runat="server" CommandName="Look1" CommandArgument='<%#Eval("SMSWPM_ID")%>'>查看</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Sign1" runat="server" CommandName="Sign1" CommandArgument='<%#Eval("SMSWPM_ID")%>'>会签</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete1" runat="server" CommandName="Delete1" OnClientClick="return confirm('您确认删除该记录吗?')"
                                        CommandArgument='<%#Eval("SMSWPM_ID")%>'>删除</asp:LinkButton>
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
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--周计划主表结束--%>
    <%--周计划详细表开始--%>
    <asp:UpdatePanel ID="UpdatePanel_WeekPlanDetail" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
                   <asp:Label ID="Label4" runat="server" Visible="false"></asp:Label>    
            <asp:Panel ID="Panel_WeekPlanDetail" runat="server" Visible="false">
                <fieldset>
                <table>
                <tr>
                    <td style="width: 20%" align="center">
                        <asp:Button ID="Button8" runat="server" Text="查看每日安排" CssClass="Button02" Height="24px"
                            OnClick="LookEveryDay" Width="90px" />
                    </td>
                    <td style="width: 5%"></td>
                    <td>
                        <asp:Button ID="Button12" runat="server" Text="新增产品型号" CssClass="Button02" Height="24px"
                                            OnClick="AddProductModell" Width="90px" />
                    </td>
                     <td style="width: 15%" align="right">
                                <asp:Label ID="Label1" runat="server" Text="产品系列："></asp:Label>            
                            </td>
                            <td style="width: 10%" align="left">
                                <asp:DropDownList ID="DropDownList6" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList6_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td> 
                </tr>
                </table>
                    <legend>
                        <asp:Label ID="label20" runat="server" Visible="true"></asp:Label>销售周计划详细表</legend>
                    <asp:GridView ID="Gridview_WeekPlanDetail" runat="server" AutoGenerateColumns="False"
                        CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False" 
                        PageSize="30" AllowPaging="True" AllowSorting="True" 
                        DataKeyNames="SMSWPD_ID" GridLines="None"
                        OnRowCommand="Gridview_WeekPlanDetail_RowCommand" OnPageIndexChanging="Gridview_WeekPlanDetail_PageIndexChanging"
                        Width="100%" ondatabound="Gridview_WeekPlanDetail_DataBound" 
                        onrowdatabound="Gridview_WeekPlanDetail_RowDataBound">
                        <%--    //隔行变色--%>
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="SMSWPD_ID" HeaderText="周计划详细ID" SortExpression="SMSWPD_ID"
                                Visible="false"></asp:BoundField>
                            
                            <asp:BoundField DataField="PT_Name" HeaderText="产品名称" SortExpression="PT_Name">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="PT_Note" HeaderText="产品备注" SortExpression="PT_Note">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMSWPD_ThisWeekTotalOrderNum" HeaderText="交付订单数量" SortExpression="SMSWPD_ThisWeekTotalOrderNum">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMSWPD_ThisWeekDelNum" HeaderText="发货计划总数" SortExpression="SMSWPD_ThisWeekDelNum">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="发货计划总数" HeaderStyle-Font-Bold="true" Visible="true">
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBox_TotalNum" runat="server" Width="95%" Text='<%#Eval("SMSWPD_ThisWeekDelNum")%>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="SMSWPD_Storge" HeaderText="库存" SortExpression="SMSWPD_Storge">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMSWPD_OnProductionNum" HeaderText="在制品量" SortExpression="SMSWPD_OnProductionNum">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMSWPD_CofirmNum" HeaderText="可保证量" SortExpression="SMSWPD_CofirmNum">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMSWPD_Propity" HeaderText="优先级" SortExpression="SMSWPD_Propity">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="优先级" HeaderStyle-Font-Bold="true" Visible="true">
                                <ItemTemplate>
                                    <asp:DropDownList ID="DropDownList_youxianji" runat="server" Width="95%" SelectedValue='<%#Eval("SMSWPD_Propity")%>'>
                                        <asp:ListItem>选择优先级</asp:ListItem>
                                        <asp:ListItem>最高优先级</asp:ListItem>
                                        <asp:ListItem>一般优先级</asp:ListItem>
                                        <asp:ListItem>普通</asp:ListItem>
                                        <asp:ListItem>可滞后</asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="SMSWPD_Remark" HeaderText="备注" SortExpression="SMSWPD_Remark">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="备注" HeaderStyle-Font-Bold="true" Visible="false">
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBox_beizhu" runat="server" Width="95%"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="mount" HeaderText="月计划总量" SortExpression="mount">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="mount1" HeaderText="本月已投产量" SortExpression="mount1">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete2" runat="server" CommandName="Delete2" OnClientClick="return confirm('您确认删除该记录吗?')"
                                        CommandArgument='<%#Eval("SMSWPD_ID")%>'>删除</asp:LinkButton>
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
                            <td style="width: 20%" align="right">
                                <asp:Button ID="Button6" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    OnClick="ConfirmNewWeekPlanDetail" Width="70px" />
                            </td>
                            <td style="width: 20%" align="center">
                                <asp:Button ID="Button7" runat="server" Text="保存" CssClass="Button02" Height="24px"
                                    OnClick="SaveNewWeekPlanDetail" Width="70px" />
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:Button ID="Button11" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="CloseWeekPlanDetail" Width="70px" />
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
            <asp:Panel ID="Panel2" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="label21" runat="server" Visible="true"></asp:Label>销售周计划每日安排</legend>
                    <asp:GridView ID="Gridview_Day" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle"
                        CellPadding="0" UseAccessibleHeader="False"  PageSize="30" GridLines="None"
                        AllowPaging="True" AllowSorting="True" DataKeyNames="SMSWPD_ID" Width="100%">
                        <%--    //隔行变色--%>
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="SMSWPD_ID" HeaderText="周计划详细ID" SortExpression="SMSWPD_ID"
                                Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="PS_Name" HeaderText="产品系列" SortExpression="PS_Name">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="PT_Name" HeaderText="产品名称" SortExpression="PT_Name">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMSWPD_ThisWeekDelNum" HeaderText="发货计划总数" SortExpression="SMSWPD_ThisWeekDelNum">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMSWPD_Day1Plan" HeaderText="第一天计划量" SortExpression="SMSWPD_Day1Plan">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="第一天计划量" HeaderStyle-Font-Bold="true" Visible="false">
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBox_1" runat="server" Width="95%" Text='<%#Eval("SMSWPD_Day1Plan")%>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="SMSWPD_Day2Plan" HeaderText="第二天计划量" SortExpression="SMSWPD_Day2Plan">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="第二天计划量" HeaderStyle-Font-Bold="true" Visible="false">
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBox_2" runat="server" Width="95%" Text='<%#Eval("SMSWPD_Day2Plan")%>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="SMSWPD_Day3Plan" HeaderText="第三天计划量" SortExpression="SMSWPD_Day3Plan">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="第三天计划量" HeaderStyle-Font-Bold="true" Visible="false">
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBox_3" runat="server" Width="95%" Text='<%#Eval("SMSWPD_Day3Plan")%>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="SMSWPD_Day4Plan" HeaderText="第四天计划量" SortExpression="SMSWPD_Day4Plan">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="第四天计划量" HeaderStyle-Font-Bold="true" Visible="false">
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBox_4" runat="server" Width="95%" Text='<%#Eval("SMSWPD_Day4Plan")%>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="SMSWPD_Day5Plan" HeaderText="第五天计划量" SortExpression="SMSWPD_Day5Plan">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="第五天计划量" HeaderStyle-Font-Bold="true" Visible="false">
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBox_5" runat="server" Width="95%" Text='<%#Eval("SMSWPD_Day5Plan")%>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="SMSWPD_Day6Plan" HeaderText="第六天计划量" SortExpression="SMSWPD_Day6Plan">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="第六天计划量" HeaderStyle-Font-Bold="true" Visible="false">
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBox_6" runat="server" Width="95%" Text='<%#Eval("SMSWPD_Day6Plan")%>'></asp:TextBox>
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
                            <td style="width: 25%" align="center">
                            </td>
                            <td style="width: 25%" align="center">
                                <asp:Button ID="Button15" runat="server" Text="保存" CssClass="Button02" Height="24px"
                                    OnClick="SaveDayPlanDetail" Width="80px" />
                            </td>
                            <td style="width: 25%" align="center">
                                <asp:Button ID="Button9" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="CloseDayPlanDetail" Width="80px" />
                            </td>
                            <td style="width: 25%" align="center">
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--周计划主表结束--%>
    <%--    新增周计划栏开始--%>
    <asp:UpdatePanel ID="UpdatePanel_NewWeekPlan" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_NewWeekPlan" runat="server" Visible="false">
                <fieldset>
                    <legend>新建销售周计划</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 16%" align="right">
                                <asp:Label ID="Label3" runat="server" Text="对应月计划："></asp:Label>
                            </td>
                            <td style="width: 13%" align="left">
                                <asp:DropDownList ID="DropDownList4" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 13%" align="right">
                              年份：
                            </td>
                            <td style="width: 10%" align="left">
                                <asp:DropDownList ID="DropDownList5" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 13%" align="right">周次：
                            <td align="left">
                                <asp:DropDownList ID="DropDownList7" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label8" runat="server" Text="起始日期："></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="TextBox_Start" onfocus="new WdatePicker(this,'%Y-%M-%D' ,true)"
                                    DataFormatString="{0:yyyy-MM-dd}" Width="90px"  ></asp:TextBox>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label9" runat="server" Text="结束日期： "></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="TextBox_End" onfocus="new WdatePicker(this,'%Y-%M-%D ',true)"
                                    DataFormatString="{0:yyyy-MM-dd}" Width="98px"  ></asp:TextBox>
                            </td>
                            <td align="right">
                                预交货期从
                            </td>
                            <td align="left" colspan="2">
                                <asp:TextBox runat="server" ID="TextBox5" onfocus="new WdatePicker(this,'%Y-%M-%D ',true)"
                                    DataFormatString="{0:yyyy-MM-dd}" Width="80px"  ></asp:TextBox>到
                                <asp:TextBox runat="server" ID="TextBox6" onfocus="new WdatePicker(this,'%Y-%M-%D ',true)"
                                    DataFormatString="{0:yyyy-MM-dd}" Width="80px"  ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2"></td>
                            <td  align="center" >
                                <asp:Button ID="Button4" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    OnClick="ConfirmNewWeekPlan" Width="70px" />
                            </td>
                            <td colspan="2" align="right">
                                <asp:Button ID="Button5" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="CloseNewWeekPlan" Width="70px" />
                            </td>
                            <td  align="left" >
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--新增周计划结束--%>
    <%--   会签开始--%>
    <asp:UpdatePanel ID="UpdatePanel_Sign" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Sign" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="label22" runat="server" Visible="true"></asp:Label>会签栏</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 13%">
                                <asp:Label ID="label_shegnchanbu" runat="server" Visible="True"></asp:Label>
                            </td>
                            <td style="width: 13%">
                                销售部长:
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TB_shengchanman" runat="server" Width="100%" ReadOnly="true" Enabled="False"></asp:TextBox>
                            </td>
                            <td style="width: 15%" align="right">
                                会签时间:
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TB_shengchantime" runat="server" Width="98%" ReadOnly="true" DataFormatString="{0:yyyy-MM-dd HH:mm}"
                                    Enabled="False"></asp:TextBox>
                            </td>
                            <td style="width: 15%">
                            </td>
                            <td >
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="LB1000" runat="server" ForeColor="#999999" Text="200字以内" Style="visibility: hidden;"></asp:Label>
                            </td>
                            <td>
                                销售部长会签意见:
                            </td>
                            <td colspan="7">
                                <asp:TextBox ID="TB_shengchanyijian" runat="server" Height="80px" MaxLength="200"
                                    onfocus="annotation('Label18');" onblur="javascript:leave('Label18');" TextMode="MultiLine"
                                    Width="99%" Enabled="False"></asp:TextBox>
                                <asp:Label ID="Label18" runat="server" ForeColor="#999999" Text="200字以内" Style="visibility: hidden;"></asp:Label>
                            </td>
                        </tr>
                      <%--  <tr>
                            <td>
                                <asp:Label ID="label_gongchengbu" runat="server" Visible="True"></asp:Label>
                            </td>
                            <td>
                                主管经理:
                            </td>
                            <td >
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
                                主管经理会签意见:
                            </td>
                            <td colspan="7">
                                <asp:TextBox ID="TB_gongchengyijian" runat="server" Height="80px" MaxLength="200"
                                    onfocus="annotation('Label13');" onblur="javascript:leave('Label13');" TextMode="MultiLine"
                                    Width="99%" Enabled="False"></asp:TextBox>
                                <asp:Label ID="Label13" runat="server" ForeColor="#999999" Text="200字以内" Style="visibility: hidden;"></asp:Label>
                            </td>
                        </tr>--%>
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
                                <asp:TextBox ID="TB_shebeiyijian" runat="server" Height="80px" MaxLength="200" onfocus="annotation('Label14');"
                                    onblur="javascript:leave('Label14');" TextMode="MultiLine" Width="99%" Enabled="False"></asp:TextBox>
                                <asp:Label ID="Label14" runat="server" ForeColor="#999999" Text="200字以内" Style="visibility: hidden;"></asp:Label>
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
                                <asp:Label ID="Label6" runat="server" ForeColor="#999999" Text="200字以内" Style="visibility: hidden;"></asp:Label>
                            </td>
                            <td>
                                生产二部会签意见:
                            </td>
                            <td colspan="7">
                                <asp:TextBox ID="TB_pinbaoyijian" runat="server" Height="80px" MaxLength="200" onfocus="annotation('Label17');"
                                    onblur="javascript:leave('Label17');" TextMode="MultiLine" Width="99%" Enabled="False"></asp:TextBox>
                                <asp:Label ID="Label17" runat="server" ForeColor="#999999" Text="200字以内" Style="visibility: hidden;"></asp:Label>
                            </td>
                        </tr>
                  <%--      <tr>
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
                                <asp:Label ID="Label7" runat="server" ForeColor="#999999" Text="200字以内" Style="visibility: hidden;"></asp:Label>
                            </td>
                            <td>
                                财务部会签意见:
                            </td>
                            <td colspan="7">
                                <asp:TextBox ID="TB_caiwuyijian" runat="server" Height="80px" MaxLength="200" onfocus="annotation('Label19');"
                                    onblur="javascript:leave('Label19');" TextMode="MultiLine" Width="99%" Enabled="False"></asp:TextBox>
                                <asp:Label ID="Label19" runat="server" ForeColor="#999999" Text="200字以内" Style="visibility: hidden;"></asp:Label>
                            </td>
                        </tr>--%>
                        <table style="width: 100%">
                            <tr>
                                <td style="width: 33%; text-align: right">
                                    <asp:Button ID="BT_TKOK" runat="server" CssClass="Button02" OnClick="BT_TKOK_Click"
                                        Text="通过" Width="70px" />
                                    <%--    OnClientClick="$find('gvEdit').hide();"--%>
                                </td>
                                <td style="width: 34%; text-align: center">
                                    <asp:Button ID="BT_TKNotOK" runat="server" CssClass="Button02" OnClick="BT_TKNotOK_Click"
                                        Text="驳回" Width="70px" />
                                </td>
                                <td style="width: 33%; text-align: left">
                                    <asp:Button ID="BT_TKCancel" runat="server" CssClass="Button02" OnClick="BT_TKCanel_Click"
                                        Text="关闭" Width="70px" />
                                </td>
                        </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--    会签结束--%>
    <!-- 产品型号列表开始-->
    <asp:UpdatePanel ID="UpdatePanel_Product" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" Visible="false">
                <fieldset>
                    <legend>产品型号检索</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 8%" align="center">
                                <asp:Label ID="Label11" runat="server" Text="产品系列："></asp:Label>
                            </td>
                            <td style="width: 10%" align="left">
                                <asp:TextBox ID="TextBox_Series" runat="server" Width="98%"></asp:TextBox>
                            </td>
                            <td style="width: 8%" align="center">
                                <asp:Label ID="Label12" runat="server" Text="产品型号："></asp:Label>
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
                                <asp:Button ID="Button10" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="CloseProType" Width="80px" />
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
            <asp:Panel ID="Panel_Product" runat="server" Visible="false">
                <fieldset>
                    <legend>产品型号表</legend>
                    <asp:GridView ID="GridView_ProType" runat="server" AllowPaging="True" PageSize="10"
                        AutoGenerateColumns="False" CellPadding="0" CssClass="GridViewStyle" DataKeyNames="PT_ID" GridLines="None"
                        AllowSorting="True" OnRowDataBound="GridView_ProType_RowDataBound" OnPageIndexChanging="GridView_ProType_PageIndexChanging">
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
                                <asp:Button ID="ButtonPro" runat="server" CssClass="Button02" Text="提 交" OnClick="ButtonProType_Click" Width="70px" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--   产品型号结束--%>
</asp:Content>
