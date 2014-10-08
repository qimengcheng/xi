<%@ Page Title="" Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="PPMProWeekPlan.aspx.cs" Inherits="ProductionPlanMgt_PPMProWeekPlan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel_Search" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Search" runat="server" Visible="true">
                <fieldset>
                    <legend>周计划检索
                        <asp:Label ID="label_pagestate" runat="server" Visible="False"></asp:Label></legend>
                    <table style="width: 100%; height: 23px;">
                        <tr style="width: 100%;">
                            <td style="width: 10%;">
                                年份：
                            </td>
                            <td style="width: 8%;">
                                <asp:DropDownList ID="DropDownList_Year" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 7%;">
                                月份：
                            </td>
                            <td style="width: 5%;">
                                <asp:DropDownList ID="DropDownList_Month" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td align="left" style="width: 15%;">
                                生产计划制定人：
                            </td>
                            <td align="left" style="width: 70px;">
                                <asp:TextBox ID="TextBox_PPMan" runat="server" Width="63px"></asp:TextBox>
                            </td>
                            <td style="width: 17%;" align="right">
                                销售计划开始日期：
                            </td>
                            <td style="width: 15%;" align="right">
                                <asp:TextBox ID="TextBox_SPTime1" Width="115px" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 3%;">
                                至
                            </td>
                            <td align="left" style="width: 15%;">
                                <asp:TextBox ID="TextBox_SPTime2" Width="115px" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="width: 100%;">
                            <td style="width: 10%;">
                                计划状态：
                            </td>
                            <td style="width: 8%;" align="left">
                                <asp:DropDownList ID="DropDownList_PState" runat="server">
                                    <asp:ListItem>未建立</asp:ListItem>
                                    <asp:ListItem>已建立</asp:ListItem>
                                    <asp:ListItem>已提交</asp:ListItem>
                                    <asp:ListItem>审核通过</asp:ListItem>
                                    <asp:ListItem>审核驳回</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="left" style="width: 7%;">
                                周次
                            </td>
                            <td align="left" style="width: 5%;">
                                <asp:DropDownList ID="DropDownList_Week" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 15%">
                            </td>
                            <td style="width: 70px">
                                <asp:TextBox ID="TextBox_SPman" runat="server" Visible="False" Width="63px"></asp:TextBox>
                            </td>
                            <td style="width: 17%;" align="right">
                                生产计划开始日期：
                            </td>
                            <td style="width: 15%;" align="right">
                                <asp:TextBox ID="TextBox_PPTime1" Width="115px" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 3%;">
                                至
                            </td>
                            <td align="left" style="width: 15%;">
                                <asp:TextBox ID="TextBox_PPTime2" Width="115px" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td style="width: 340px">
                            </td>
                            <td>
                                <asp:Button ID="Btn_Search" runat="server" Text="检索" Width="70px" Height="24px" CssClass="Button02"
                                    OnClick="Btn_Search_Click" />
                            </td>
                            <td style="width: 70px">
                            </td>
                            <td>
                                <asp:Button ID="Button_Cancel" runat="server" CssClass="Button02" Height="24px" OnClick="Button_Cancel_Click"
                                    Text="重置" Width="70px" />
                            </td>
                            <td style="width: 320px">
                                <asp:Label ID="Proline" runat="server" Text="0" Visible="False"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_PPMain" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_PPMain" runat="server" Visible="true">
                <fieldset>
                    <legend>生产周计划主表
                        <asp:Label ID="label_GridPageState" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="label_pwpid_Detail" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="label_Condition" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <asp:GridView ID="GridView_WeekMain" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        PageSize="5" CellPadding="0" UseAccessibleHeader="False" AllowPaging="True" OnRowCommand="GridView_WeekMain_RowCommand"
                        OnPageIndexChanging="GridView_WeekMain_PageIndexChanging" OnRowEditing="GridView_WeekMain_Editing"
                        OnRowCancelingEdit="GridView_WeekMain_CancelingEdit" AllowSorting="True" OnRowCreated="GridView_WeekMain_RowCreated"
                        OnSorting="GridView_WeekMain_Sorting" OnRowUpdating="GridView_WeekMain_Updating"
                        OnRowDataBound="GridView_WeekMain_RowDataBound" Width="100%" DataKeyNames="SMSWPM_ID,PWP_ID,PWP_STime,PWP_ETime"
                        EmptyDataText="无相关记录!" GridLines="None" OnDataBound="GridView_WeekMain_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="SMSWPM_ID" SortExpression="SMSWPM_ID" HeaderText="周计划ID"
                                Visible="false">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PWP_ID" SortExpression="PWP_ID" HeaderText="生产周计划ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="SMSWPM_Year" SortExpression="SMSWPM_Year" HeaderText="年份"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="SMSMPM_Month" SortExpression="SMSMPM_Month" HeaderText="月份"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="SMSWPM_Week" SortExpression="SMSWPM_Week" HeaderText="周次"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="PWP_State" SortExpression="PWP_State" HeaderText="状态"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="SMSWPM_StartTime" SortExpression="SMSWPM_StartTime" HeaderText="销售开始日期"
                                ReadOnly="true" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundField>
                            <asp:BoundField DataField="SMSWPM_EndTime" SortExpression="SMSWPM_EndTime" HeaderText="销售结束日期"
                                ReadOnly="true" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundField>
                            <asp:TemplateField SortExpression="PWP_STime" HeaderText="生产开始日期">
                                <ItemTemplate>
                                    <asp:Label ID="lable_1" runat="server" Text='<%# Eval("PWP_STime","{0:yyyy-MM-dd}") %>'
                                        DataFormatString="{0:yyyy-MM-dd}"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_1" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D ',false)"
                                        Text='<%# Eval("PWP_STime","{0:yyyy-MM-dd}") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField SortExpression="PWP_ETime" HeaderText="生产结束日期">
                                <ItemTemplate>
                                    <asp:Label ID="lable_2" runat="server" Text='<%# Eval("PWP_ETime","{0:yyyy-MM-dd}")%>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_2" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D ',false)"
                                        Text='<%# Eval("PWP_ETime","{0:yyyy-MM-dd}") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="PWP_Man" SortExpression="PWP_Man" HeaderText="制定人" ReadOnly="true">
                            </asp:BoundField>
                            <asp:BoundField DataField="PWP_Time" SortExpression="PWP_Time" HeaderText="制定时间"
                                DataFormatString="{0:yyyy-MM-dd HH:mm}" ReadOnly="true"></asp:BoundField>
                            <asp:CommandField ShowEditButton="True" EditText="制定" UpdateText="更新" CancelText="关闭">
                            </asp:CommandField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Detail" runat="server" CommandArgument='<%#Eval("SMSWPM_ID")+","+ Eval("PWP_ID")+","+ Eval("PWP_State")+","+ Eval("SMSWPM_Year")+","+ Eval("SMSMPM_Month")+","+ Eval("SMSWPM_Week") %>'
                                        CommandName="Detail">详细</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Review" runat="server" CommandArgument='<%#Eval("PWP_ID") +","+ Eval("SMSWPM_ID")+","+ Eval("PWP_State")+","+ Eval("SMSWPM_Year")+","+ Eval("SMSMPM_Month")+","+ Eval("SMSWPM_Week") %>'
                                        CommandName="Review">审核查看</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第 &nbsp;<asp:Label ID="lblPageIndex" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                        页 共 &nbsp;<asp:Label ID="lblPageCount" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageCount  %>" />
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
                            <asp:Label ID="Label16" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                    </asp:GridView>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_D" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnDetailExcel" />
        </Triggers>
        <ContentTemplate>
            <asp:Panel ID="Panel_D" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="Label_time1" runat="server"></asp:Label>
                        生产周计划详细表<asp:Label ID="Label_pwpdetailstate" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="Label_searchCondition" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="Label_T1" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="Label_T2" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <table id="searchTable" style="width: 100%; height: 23px;">
                        <tr style="width: 100%;">
                            <td style="width: 20%;">
                            </td>
                            <td style="width: 10%;">
                                系列：
                            </td>
                            <td style="width: 120px;">
                                <asp:TextBox ID="txtSeries" runat="server" Width="100px"></asp:TextBox>
                            </td>
                            <td style="width: 10%;">
                                型号：
                            </td>
                            <td style="width: 120px;">
                                <asp:TextBox ID="txtType" runat="server" Width="100px"></asp:TextBox>
                            </td>
                            <td style="width: 20%;">
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%;">
                        <tr style="width: 100%">
                            <td style="width: 15%">
                            </td>
                            <td style="width: 20%">
                                <asp:Button ID="btnDetailSearch" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="btnDetailSearch_Click" Text="检索" Width="70px" />
                            </td>
                            <td style="width: 5%">
                            </td>
                            <td style="width: 20%">
                                <asp:Button ID="btnDetailExcel" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="btnDetailExcel_Click" Text="导出Excel" Width="70px" />
                            </td>
                            <td style="width: 5%">
                            </td>
                            <td style="width: 20%">
                                <asp:Button ID="btnDetailReset" runat="server" CssClass="Button02" Height="24px"
                                    Text="重置" Width="70px" OnClick="btnDetailReset_Click" />
                            </td>
                            <td style="width: 15%">
                                <asp:Button ID="btnDetailReset0" runat="server" CssClass="Button02" OnClientClick="return confirm('严重警告！这样操作的结果将是把该周所有投产计划置为参考计划，如果您已经制定了投产计划，以上操作将会覆盖您的计划，如果您仍将继续，请自行承担数据丢失的风险！仍要确定？')"
                                    Height="24px" OnClick="btnDetailReset0_Click" Text="一键复制参考计划至投产计划" Width="180px" />
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView_D" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        PageSize="2" CellPadding="0" UseAccessibleHeader="False" AllowPaging="false"
                        OnRowCommand="GridView_D_RowCommand" OnPageIndexChanging="GridView_D_PageIndexChanging"
                        OnRowEditing="GridView_D_Editing" OnRowCancelingEdit="GridView_D_CancelingEdit"
                        AllowSorting="True" OnRowCreated="GridView_D_RowCreated" OnSorting="GridView_D_Sorting"
                        OnRowDataBound="GridView_D_RowDataBound" Width="100%" DataKeyNames="PWPD_ID,SMSWPM_ID,PT_ID,TotalNum,WIP,PWPNumRef"
                        EmptyDataText="无相关记录!" GridLines="None" OnDataBound="GridView_D_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="PWPD_ID" SortExpression="PWPD_ID" HeaderText="生产周详细计划ID"
                                Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="SMSWPM_ID" SortExpression="SMSWPM_ID" HeaderText="销售周计划ID"
                                Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="PT_ID" SortExpression="PT_ID" HeaderText="型号ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="PS_Name" SortExpression="PS_Name" HeaderText="系列" ReadOnly="true">
                            </asp:BoundField>
                            <asp:TemplateField SortExpression="PT_Name" HeaderText="型号">
                                <ItemTemplate>
                                    <asp:Label ID="lable_1" runat="server" Text='<%# Eval("PT_Name") %>' ToolTip='<%# Eval("PT_Code") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="SMSWPD_ThisWeekTotalOrderNum" SortExpression="SMSWPD_ThisWeekTotalOrderNum"
                                HeaderText="周订单" ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="a1" SortExpression="a1" HeaderText="生产月" ReadOnly="true">
                            </asp:BoundField>
                            <asp:BoundField DataField="a2" SortExpression="a2" HeaderText="已安排" ReadOnly="true">
                            </asp:BoundField>
                            <asp:BoundField DataField="n" SortExpression="a3" HeaderText="未安排" ReadOnly="true">
                            </asp:BoundField>
                            <asp:BoundField DataField="SMSWPD_ThisWeekDelNum" SortExpression="SMSWPD_ThisWeekDelNum"
                                HeaderText="预计发货" ReadOnly="true" Visible="False"></asp:BoundField>
                            <asp:BoundField DataField="TotalNum" HeaderText="库存" ReadOnly="True"></asp:BoundField>
                            <asp:BoundField DataField="WIP" HeaderText="在制品" ReadOnly="True"></asp:BoundField>
                            <asp:BoundField DataField="PWPD_Plan" SortExpression="PWPD_Plan" HeaderText="投产计划"
                                ReadOnly="false"></asp:BoundField>
                            <asp:TemplateField HeaderText="投产计划" HeaderStyle-Font-Bold="true" Visible="true">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPlan" runat="server" Width="60px" Text='<%#Eval("PWPD_Plan")%>'></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle Font-Bold="True" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="PWPNumRef" SortExpression="PWPNumRef" HeaderText="参考"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="SMSWPD_Remark" SortExpression="SMSWPD_Remark" HeaderText="销售备注"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="PWPD_Note" SortExpression="PWPD_Note" HeaderText="生产备注"
                                ReadOnly="false"></asp:BoundField>
                            <asp:TemplateField HeaderText="生产备注" HeaderStyle-Font-Bold="true" Visible="true">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtNote" runat="server" Width="80px" Text='<%#Eval("PWPD_Note")%>'></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle Font-Bold="True" />
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第 &nbsp;<asp:Label ID="lblPageIndex" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                        页 共 &nbsp;<asp:Label ID="lblPageCount" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageCount  %>" />
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
                            <asp:Label ID="Label16" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <table width="100%">
                        <tr>
                            <td align="center" style="width: 250px">
                                <asp:Button ID="Button_checkProSeries" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_checkProSeries_click" Text="查看产能核定系列统计" Width="130px" />
                            </td>
                            <td align="center" style="width: 250px">
                                <asp:Button ID="Button_Subold" runat="server" CssClass="Button02" Height="24px" OnClick="Button_Subold_click"
                                    OnClientClick="return confirm('确定提交生产周计划吗？提交后不能更改,提交的同时会把当前库存数、在制品数、参考投产数一并保存！')" Text="提交" Width="70px" />
                            </td>
                            <td align="center" style="width: 250px">
                                <asp:Button ID="Button_Save" runat="server" CssClass="Button02" Height="24px" Text="保存"
                                    Width="70px" OnClick="Button_Save_Click" />
                            </td>
                            <td align="center" style="width: 250px">
                                <asp:Button ID="Btn_Close_Detail" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Btn_Close_Detail_Click" Text="关闭" Width="70px" />
                            </td>
                            <td align="center" style="width: 250px">
                                <asp:Button ID="Button_addpt" runat="server" CssClass="Button02" Height="24px" OnClick="AddProductModell"
                                    Text="新增产品型号" Width="90px" />
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_Day" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnDetailExcelDay" />
        </Triggers>
        <ContentTemplate>
            <asp:Panel ID="Panel_Day" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="Label_Time2" runat="server"></asp:Label>周的天计划详细表<asp:Label ID="label_smswpmid"
                            runat="server" Visible="False" ></asp:Label>
                        <asp:Label ID="Label_searchConditionDay" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <table style="width: 100%; height: 23px;">
                        <tr style="width: 100%;">
                            <td style="width: 6%;">
                                系列：
                            </td>
                            <td style="width: 10%;">
                                <asp:TextBox ID="txtSeriesDay" runat="server" Width="100px"></asp:TextBox>
                            </td>
                            <td style="width: 6%;">
                                型号：
                            </td>
                            <td style="width: 10%;">
                                <asp:TextBox ID="txtTypeDay" runat="server" Width="100px"></asp:TextBox>
                            </td>
                            <td style="width: 20%;" align="right">
                                <asp:DropDownList ID="DropDownList1" runat="server">
                                    <asp:ListItem Value="1">第一天</asp:ListItem>
                                    <asp:ListItem Value="2">第二天</asp:ListItem>
                                    <asp:ListItem Value="3">第三天</asp:ListItem>
                                    <asp:ListItem Value="4">第四天</asp:ListItem>
                                    <asp:ListItem Value="5">第五天</asp:ListItem>
                                    <asp:ListItem Value="6">第六天</asp:ListItem>
                                    <asp:ListItem Value="7">第七天</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="DropDownList2" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td align="left" style="width: 20%;">
                                <asp:Button ID="btnDetailResetDay0" runat="server" CssClass="Button02" Height="20px"
                                    OnClick="btnDetailResetDay0_Click" Text="单个制定" Width="70px" />
                            </td>
                            <td align="right" style="width: 20%;">
                                <asp:Button ID="btnDetailResetDay1" runat="server" CssClass="Button02" Height="20px"
                                    OnClick="btnDetailResetDay1_Click" Text="一键默认" Width="70px" />
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%;">
                        <tr style="width: 100%">
                            <td style="width: 15%">
                            </td>
                            <td style="width: 20%">
                                <asp:Button ID="btnDetailSearchDay" runat="server" CssClass="Button02" Height="24px"
                                    Text="检索" Width="70px" OnClick="btnDetailSearchDay_Click" />
                            </td>
                            <td style="width: 5%">
                            </td>
                            <td style="width: 20%">
                                <asp:Button ID="btnDetailExcelDay" runat="server" CssClass="Button02" Height="24px"
                                    Text="导出Excel" Width="70px" OnClick="btnDetailExcelDay_Click" />
                            </td>
                            <td style="width: 5%">
                            </td>
                            <td style="width: 20%">
                                <asp:Button ID="btnDetailResetDay" runat="server" CssClass="Button02" Height="24px"
                                    Text="重置" Width="70px" OnClick="btnDetailResetDay_Click" />
                            </td>
                            <td style="width: 15%">
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView_Day" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        CellPadding="0" UseAccessibleHeader="False" AllowPaging="false" OnRowCommand="GridView_Day_RowCommand"
                        OnPageIndexChanging="GridView_Day_PageIndexChanging" OnRowEditing="GridView_Day_Editing"
                        OnRowCancelingEdit="GridView_Day_CancelingEdit" AllowSorting="True" OnRowCreated="GridView_Day_RowCreated"
                        OnSorting="GridView_Day_Sorting" OnRowDataBound="GridView_Day_RowDataBound" Width="100%"
                        DataKeyNames="PWPD_ID,SMSWPM_ID,PT_ID" EmptyDataText="无相关记录!" GridLines="None"
                        OnDataBound="GridView_Day_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="PWPD_ID" SortExpression="PWPD_ID" HeaderText="生产周详细计划ID"
                                Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="SMSWPM_ID" SortExpression="SMSWPM_ID" HeaderText="销售周计划ID"
                                Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="PT_ID" SortExpression="PT_ID" HeaderText="型号ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="PS_Name" SortExpression="PS_Name" HeaderText="系列" ReadOnly="true">
                            </asp:BoundField>
                            <asp:TemplateField SortExpression="PT_Name" HeaderText="型号">
                                <ItemTemplate>
                                    <asp:Label ID="lable_1" runat="server" Text='<%# Eval("PT_Name") %>' ToolTip='<%# Eval("PT_Code") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="PWPD_Plan" SortExpression="PWPD_Plan" HeaderText="周投产计划"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="PWPD_D1" SortExpression="PWPD_D1" HeaderText="第1天计划">
                            </asp:BoundField>
                            <asp:TemplateField HeaderStyle-Font-Bold="true" Visible="true" HeaderText="第1天计划">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtD1" runat="server" Width="55px" Text='<%#Eval("PWPD_D1")%>'></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle Font-Bold="True" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="PWPD_D2" SortExpression="PWPD_D2" HeaderText="第2天计划">
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="第2天计划" HeaderStyle-Font-Bold="true" Visible="true">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtD2" runat="server" Width="55px" Text='<%#Eval("PWPD_D2")%>'></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle Font-Bold="True" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="PWPD_D3" SortExpression="PWPD_D3" HeaderText="第3天计划">
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="第3天计划" HeaderStyle-Font-Bold="true" Visible="true">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtD3" runat="server" Width="55px" Text='<%#Eval("PWPD_D3")%>'></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle Font-Bold="True" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="PWPD_D4" SortExpression="PWPD_D4" HeaderText="第4天计划">
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="第4天计划" HeaderStyle-Font-Bold="true" Visible="true">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtD4" runat="server" Width="55px" Text='<%#Eval("PWPD_D4")%>'></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle Font-Bold="True" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="PWPD_D5" SortExpression="PWPD_D5" HeaderText="第5天计划">
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="第5天计划" HeaderStyle-Font-Bold="true" Visible="true">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtD5" runat="server" Width="55px" Text='<%#Eval("PWPD_D5")%>'></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle Font-Bold="True" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="PWPD_D6" SortExpression="PWPD_D6" HeaderText="第6天计划">
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="第6天计划" HeaderStyle-Font-Bold="true" Visible="true">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtD6" runat="server" Width="55px" Text='<%#Eval("PWPD_D6")%>'></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle Font-Bold="True" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="PWPD_D7" SortExpression="PWPD_D7" HeaderText="第7天计划">
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="第7天计划" HeaderStyle-Font-Bold="true" Visible="true">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtD7" runat="server" Width="55px" Text='<%#Eval("PWPD_D7")%>'></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle Font-Bold="True" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="PWPD_Note" SortExpression="PWPD_Note" HeaderText="生产备注">
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="生产备注" HeaderStyle-Font-Bold="true" Visible="true">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtNoteDay" runat="server" Width="99%" Text='<%#Eval("PWPD_Note")%>'></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle Font-Bold="True" />
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第 &nbsp;<asp:Label ID="lblPageIndex" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                        页 共 &nbsp;<asp:Label ID="lblPageCount" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageCount  %>" />
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
                            <asp:Label ID="Label16" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <table width="100%">
                        <tr>
                            <td style="width: 30%">
                            </td>
                            <td align="center" style="width: 20%">
                                <asp:Button ID="Button_SaveDay" runat="server" CssClass="Button02" Height="24px"
                                    Text="保存" Width="70px" OnClick="Button_SaveDay_Click" />
                            </td>
                            <td align="center" style="width: 20%">
                                <asp:Button ID="Button1" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_Close_New_Click"
                                    Text="关闭" Width="70px" />
                            </td>
                            <td align="center" style="width: 30%">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_Product" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Product_Search" runat="server" Visible="false">
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
                            <td style="width: 10%" align="center">
                                <asp:Button ID="Button14" runat="server" Text="检索" CssClass="Button02" Height="24px"
                                    OnClick="SelectProType" Width="70px" />
                            </td>
                            <td style="width: 10%" align="center">
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
            <asp:Panel ID="Panel_Product" runat="server" Visible="false">
                <fieldset>
                    <legend>产品型号表<asp:Label ID="Label_PT_NewOrOld" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <asp:GridView ID="GridView_ProType" runat="server" AllowPaging="True" Width="100%"
                        AutoGenerateColumns="False" CellPadding="0" CssClass="GridViewStyle" DataKeyNames="PT_ID"
                        AllowSorting="True" OnPageIndexChanging="GridView_ProType_PageIndexChanging"
                        OnRowDataBound="GridView_ProType_RowDataBound">
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridviewHead" BorderStyle="Double" BorderWidth="1px" Height="26px"
                            HorizontalAlign="Center" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemStyle Width="5%" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox2" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="PT_ID" HeaderText="产品型号ID" Visible="false" />
                            <asp:BoundField DataField="PS_Name" HeaderText="产品系列" ItemStyle-Width="45%" />
                            <asp:TemplateField SortExpression="PT_Name" HeaderText="型号" ItemStyle-Width="45%">
                                <ItemTemplate>
                                    <asp:Label ID="lable_1" runat="server" Text='<%# Eval("PT_Name") %>' ToolTip='<%# Eval("code") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第 &nbsp;<asp:Label ID="lblPageIndex" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>' />
                                        页 共 &nbsp;<asp:Label ID="lblPageCount" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />
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
                        <AlternatingRowStyle />
                    </asp:GridView>
                    <table style="width: 100%; text-align: center;" class="STYLE2">
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:CheckBox ID="Cbx2_SelectAll" runat="server" Text="全选" AutoPostBack="true" OnCheckedChanged="Cbx2_SelectAll_CheckedChanged" />
                                <asp:Button ID="ButtonPro" runat="server" CssClass="Button02" Text="提 交" Height="24px"
                                    OnClick="ButtonProType_Click" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <table width="100%">
                        <tr>
                            <td style="width: 88px">
                            </td>
                            <td align="center" style="width: 288px">
                                &nbsp;
                            </td>
                            <td align="center" style="width: 114px">
                                <asp:Button ID="Button_ClosePT" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Btn_Close_PT_Click" Text="关闭" Width="70px" />
                            </td>
                            <td align="center" style="width: 287px">
                                &nbsp;&nbsp;
                            </td>
                            <td align="center">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_series" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_series" runat="server" Visible="false">
                <fieldset>
                    <legend>系列周计划汇总表</legend>
                    <asp:GridView ID="GridView_series" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        PageSize="2" CellPadding="0" UseAccessibleHeader="False" AllowPaging="false"
                        OnRowCommand="GridView_series_RowCommand" OnPageIndexChanging="GridView_series_PageIndexChanging"
                        OnRowEditing="GridView_series_Editing" OnRowCancelingEdit="GridView_series_CancelingEdit"
                        AllowSorting="True" OnRowCreated="GridView_series_RowCreated" OnSorting="GridView_series_Sorting"
                        OnRowUpdating="GridView_series_Updating" OnRowDataBound="GridView_series_RowDataBound"
                        Width="100%" DataKeyNames="PS_ID" EmptyDataText="无相关记录!" GridLines="None">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="PS_ID" SortExpression="PS_ID" HeaderText="产品系列ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="PS_Name" SortExpression="PS_Name" HeaderText="系列" ReadOnly="true">
                            </asp:BoundField>
                            <asp:BoundField DataField="weeknum" SortExpression="weeknum" HeaderText="周投产计划" ReadOnly="true">
                            </asp:BoundField>
                            <asp:BoundField DataField="CDI_Total" SortExpression="CDI_Total" HeaderText="产能核定值" ReadOnly="true">
                            </asp:BoundField>
                            <asp:BoundField DataField="warn" SortExpression="warn" HeaderText="产能是否报警" ReadOnly="true">
                            </asp:BoundField>
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第 &nbsp;<asp:Label ID="lblPageIndex" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                        页 共 &nbsp;<asp:Label ID="lblPageCount" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageCount  %>" />
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
                            <asp:Label ID="Label16" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <table width="100%">
                        <tr>
                            <td style="width: 88px">
                            </td>
                            <td align="center" style="width: 288px">
                                &nbsp;
                            </td>
                            <td align="center" style="width: 114px">
                                <asp:Button ID="Button_series" runat="server" CssClass="Button02" Height="24px" OnClick="Button_series_Click"
                                    Text="关闭" Width="70px" />
                            </td>
                            <td align="center" style="width: 287px">
                                &nbsp;&nbsp;
                            </td>
                            <td align="center">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_Sign" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Sign" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="Label_year" runat="server"></asp:Label>
                        <asp:Label ID="Label_Month" runat="server"></asp:Label>
                        &nbsp;<asp:Label ID="Label_week" runat="server"></asp:Label>
                        计划 部长审核栏<asp:Label ID="Label_PWPID" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="label_pwpstate" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 102px">
                                审核意见:
                                <br />
                                (200字以内)
                            </td>
                            <td style="width: 744px">
                                <asp:TextBox ID="TB_shengchanyijian" runat="server" Height="88px" MaxLength="200"
                                    TextMode="MultiLine" Width="90%"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <table style="width: 100%">
                                    <tr>
                                        <td style="width: 33%; text-align: right">
                                            <asp:Button ID="BT_TKOK" runat="server" CssClass="Button02" Height="24px" OnClick="BT_TKOK_Click"
                                                OnClientClick="return confirm('确定审核通过吗？提交后不能更改！') " Text="通过" Width="70px" />
                                            <%--    OnClientClick="$find('gvEdit').hide();"--%>
                                        </td>
                                        <td style="width: 34%; text-align: center">
                                            <asp:Label ID="PWPCID" runat="server" Text="PWPCID" Visible="False"></asp:Label>
                                            <asp:Button ID="BT_TKNotOK" runat="server" CssClass="Button02" Height="24px" OnClick="BT_TKNotOK_Click"
                                                OnClientClick="return confirm('确定审核驳回吗？提交后不能更改！')" Text="驳回" Width="70px" />
                                        </td>
                                        <td style="width: 33%; text-align: left">
                                            <asp:Button ID="BT_TKCancel" runat="server" CssClass="Button02" Height="24px" OnClick="BT_TKCanel_Click"
                                                Text="关闭" Width="70px" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel2" runat="server" Visible="False">
                <fieldset>
                    <legend>审核信息表 </legend>
                    <asp:Button ID="CloseAudit" runat="server" CssClass="Button02" Height="24px" OnClick="CloseAudit_Click"
                        Text="关闭" Width="70px" />
                    <asp:GridView ID="GridView1" runat="server" CssClass="GridViewStyle" AutoGenerateColumns="False"
                        GridLines="None" EmptyDataText="没有相关记录" OnRowCommand="GridView1_RowCommand" DataKeyNames="PWPC_ID"
                        EnableModelValidation="True" OnRowDataBound="GridView1_RowDataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="PWPC_ID" HeaderText="会签ID" Visible="false" />
                            <asp:BoundField DataField="BDOS_Name" HeaderText="会签部门" Visible="true" SortExpression="PMP_ID" />
                            <asp:BoundField DataField="PWPC_People" HeaderText="会签人" Visible="true" SortExpression="SMSMPM_Year" />
                            <asp:BoundField DataField="PWPC_Time" HeaderText="会签时间" Visible="true" SortExpression="SMSWPM_MakeTime" />
                            <asp:BoundField DataField="PWPC_Result" HeaderText="审核结果" Visible="true" SortExpression="PWP_STime" />
                            <asp:BoundField DataField="PWPC_Suggestion" HeaderText="意见" Visible="true" SortExpression="PMP_ETime" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Detail" runat="server" CommandArgument='<%# Eval("PWPC_ID") %>'
                                        CommandName="Details">审核</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <table style="width: 100%; text-align: left;">
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
