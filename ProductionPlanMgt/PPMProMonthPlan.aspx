<%@ Page Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="PPMProMonthPlan.aspx.cs" Inherits="ProductionPlanMgt_PPMProMonthPlan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel_Search" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Search" runat="server" Visible="true">
                <fieldset>
                    <legend>月计划检索<asp:Label ID="label_pagestate" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <table style="width: 100%; height: 23px;">
                        <tr style="width: 100%;">
                            <td style="width: 11%;">
                                年份：
                            </td>
                            <td style="width: 8%;">
                                <asp:DropDownList ID="DropDownList_Year" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 8%;">
                                月份：
                            </td>
                            <td style="width: 5%;">
                                <asp:DropDownList ID="DropDownList_Month" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td align="left" style="width: 15%;">
                                销售计划制定人：
                            </td>
                            <td align="left" style="width: 70px;">
                                <asp:TextBox ID="TextBox_SPman" runat="server" Width="50px"></asp:TextBox>
                            </td>
                            <td style="width: 17%;" align="right">
                                销售计划制定时间：
                            </td>
                            <td style="width: 15%;" align="right">
                                <asp:TextBox ID="TextBox_SPTime1" runat="server"  onfocus="new WdatePicker(this,'%Y-%M-%D %h:%m:%s',true)"
                                    Width="115px"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 3%;">
                                至
                            </td>
                            <td align="left" style="width: 15%;">
                                <asp:TextBox ID="TextBox_SPTime2" runat="server"  onfocus="new WdatePicker(this,'%Y-%M-%D %h:%m:%s',true)"
                                    Width="115px"></asp:TextBox>
                            </td>
                        </tr>
                        <%--    </table>
                    <table>--%>
                        <tr style="width: 100%;">
                            <td style="width: 11%;">
                                计划状态：
                            </td>
                            <td style="width: 8%;" align="left">
                                <asp:DropDownList ID="DropDownList_PState" runat="server">
                                    <asp:ListItem>所有状态</asp:ListItem>
                                    <asp:ListItem>未建立</asp:ListItem>
                                    <asp:ListItem>已建立</asp:ListItem>
                                    <asp:ListItem>已提交</asp:ListItem>
                                    <asp:ListItem>审核通过</asp:ListItem>
                                    <asp:ListItem>审核驳回</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="left" style="width: 8%;">
                            </td>
                            <td align="left" style="width: 5%;">
                            </td>
                            <td style="width: 15%">
                                生产计划制定人：
                            </td>
                            <td style="width: 70px">
                                <asp:TextBox ID="TextBox_PPMan" runat="server" Width="50px"></asp:TextBox>
                            </td>
                            <td style="width: 17%;" align="right">
                                生产计划制定时间：
                            </td>
                            <td style="width: 15%;" align="right">
                                <asp:TextBox ID="TextBox_PPTime1" runat="server"  onfocus="new WdatePicker(this,'%Y-%M-%D',true)"
                                    Width="115px"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 3%;">
                                至
                            </td>
                            <td align="left" style="width: 15%;">
                                <asp:TextBox ID="TextBox_PPTime2" runat="server"  onfocus="new WdatePicker(this,'%Y-%M-%D',true)"
                                    Width="115px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td style="width: 340px">
                            </td>
                            <td >
                                <asp:Button ID="Btn_Search" runat="server" Text="检索" Width="70px" Height="24px" CssClass="Button02"
                                    OnClick="Btn_Search_Click" />
                            </td>
                            <td style="width: 37px">
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
                    <legend>生产月计划主表
                        <asp:Label ID="Label_Grid2_Color" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="label_GridPageState" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="label_Condition" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        PageSize="5" CellPadding="0" UseAccessibleHeader="False" AllowPaging="True" OnRowCommand="GridView2_RowCommand"
                        OnPageIndexChanging="GridView2_PageIndexChanging" OnRowEditing="Gridview2_Editing"
                        OnRowCancelingEdit="Gridview2_CancelingEdit" AllowSorting="True" OnRowCreated="GridView2_RowCreated"
                        OnSorting="GridView2_Sorting" OnRowUpdating="Gridview2_Updating" OnRowDataBound="GridView2_RowDataBound"
                        Width="100%" DataKeyNames="SMSMPM_ID,PMP_ID" EmptyDataText="无相关记录!" GridLines="None"
                        OnDataBound="GridView2_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="SMSMPM_ID" SortExpression="SMSMPM_ID" HeaderText="月计划ID"
                                Visible="false">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PMP_ID" SortExpression="PMP_ID" HeaderText="生产月计划ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="SMSMPM_Year" SortExpression="SMSMPM_Year" HeaderText="年份"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="SMSMPM_Month" SortExpression="SMSMPM_Month" HeaderText="月份"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="PMP_State" SortExpression="PMP_State" HeaderText="状态"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="SMSMPM_MakeMan" SortExpression="SMSMPM_MakeMan" HeaderText="销售计划制定人"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="SMSMPM_MakeTime" SortExpression="SMSMPM_MakeTime" HeaderText="销售计划制定时间"
                                ReadOnly="true" DataFormatString="{0:yyyy-MM-dd HH:mm}"></asp:BoundField>
                            <asp:TemplateField SortExpression="PMP_STime" HeaderText="计划开始日期">
                                <ItemTemplate>
                                    <asp:Label ID="lable_1" runat="server" Text='<%# Eval("PMP_STime","{0:yyyy-MM-dd}") %>'
                                        DataFormatString="{0:yyyy-MM-dd}"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_1" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D ',false)"
                                         Text='<%# Eval("PMP_STime","{0:yyyy-MM-dd}") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField SortExpression="PMP_ETime" HeaderText="计划结束日期">
                                <ItemTemplate>
                                    <asp:Label ID="lable_2" runat="server" Text='<%# Eval("PMP_ETime","{0:yyyy-MM-dd}")%>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_2" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D ',false)"
                                         Text='<%# Eval("PMP_ETime","{0:yyyy-MM-dd}") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="PMP_Man" SortExpression="PMP_Man" HeaderText="制定人" ReadOnly="true">
                            </asp:BoundField>
                            <asp:BoundField DataField="PMP_Time" SortExpression="PMP_Time" HeaderText="制定时间"
                                DataFormatString="{0:yy-MM-dd HH:mm}" ReadOnly="true"></asp:BoundField>
                            <asp:CommandField ShowEditButton="True" EditText="制定" UpdateText="更新" CancelText="关闭">
                            </asp:CommandField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Detail" runat="server" CommandArgument='<%#Eval("PMP_ID") +","+ Eval("SMSMPM_ID")+","+ Eval("PMP_State")+","+Eval("SMSMPM_Year")+","+Eval("SMSMPM_Month") %>'
                                        CommandName="Detail">原计划详细</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Review" runat="server" CommandArgument='<%# Eval("PMP_ID") +","+Eval("SMSMPM_Year")+","+Eval("SMSMPM_Month")+","+ Eval("PMP_State")%>'
                                        CommandName="Review">审核查看</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="AddPlan" runat="server" CommandArgument='<%#Eval("PMP_ID") +","+ Eval("SMSMPM_ID")+","+Eval("SMSMPM_Year")+","+Eval("SMSMPM_Month") %>'
                                        CommandName="AddPlan">新增的计划</asp:LinkButton>
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
                        <asp:Label ID="Label_time1" runat="server" />原生产月计划详细表<asp:Label ID="Label_SMSMPM_ID"
                            runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="Lable_PMPID2" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="label_PMPState" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="label_PMPState2" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="Label_searchCondition" runat="server" Visible="False"></asp:Label>
                    </legend>
        <table id="searchTable" style="width: 100%; height: 23px;">
            <tr style="width: 100%;">
                <td style="width: 20%;">
                </td>
                <td style="width: 10%;">
                    系列：
                </td>
                <td style="width:120px;">
                    <asp:TextBox ID="txtSeries" runat="server" Width="100px"></asp:TextBox>
                </td>
                <td style="width: 10%;">
                    型号：
                </td>
                <td style="width:120px;">
                    <asp:TextBox ID="txtType" runat="server" Width="100px"></asp:TextBox>
                </td>
                <td style="width: 20%;">
                </td>
            </tr>
        </table>
    <table style="width: 100%;">
            <tr style="width:100%">
                <td style="width: 4%"></td>
                <td style="width: 20%">
                    <asp:Button ID="btnDetailSearch" runat="server" CssClass="Button02" Height="24px" OnClick="btnDetailSearch_Click" Text="检索" Width="70px" />
                </td>
                <td style="width: 5%"></td>
                <td style="width: 13%">
                    <asp:Button ID="btnDetailExcel" runat="server" CssClass="Button02" Height="24px" OnClick="btnDetailExcel_Click" Text="导出Excel" Width="70px" />
                </td>
                <td style="width: 5%"></td>
                <td style="width: 14%">
                    <asp:Button ID="btnDetailReset" runat="server" CssClass="Button02" Height="24px" Text="重置" Width="70px" OnClick="btnDetailReset_Click" />
                </td>
                <td style="width: 15%">
                    <asp:Button ID="btnDetailReset0" runat="server" CssClass="Button02" 
                        Height="24px" OnClick="btnDetailReset0_Click" Text="一键复制参考计划" Width="143px"
                        OnClientClick="return confirm('警告！这样操作的结果将是把当月所有投产计划置为参考计划，如果您已经制定了投产计划，以上操作将会覆盖您的计划，如果您仍将继续，请自行承担数据丢失的风险！仍要确定？')" />
                </td>
            </tr>
    </table>
                    <asp:GridView ID="GridView_D" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        PageSize="5" CellPadding="0" UseAccessibleHeader="False" AllowPaging="false"
                        OnRowCommand="GridView_D_RowCommand" OnPageIndexChanging="GridView_D_PageIndexChanging"
                        OnRowEditing="GridView_D_Editing" OnRowCancelingEdit="GridView_D_CancelingEdit"
                        AllowSorting="True" OnRowCreated="GridView_D_RowCreated" OnSorting="GridView_D_Sorting"
                         OnRowDataBound="GridView_D_RowDataBound"
                        Width="100%" DataKeyNames="SMSMPD_ID,SMSMPM_ID,TotalNum,WIP,PMPNumRef" EmptyDataText="无相关记录!" GridLines="None"
                        OnDataBound="GridView_D_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="SMSMPD_ID" SortExpression="SMSMPD_ID" HeaderText="销售月详细计划ID"
                                Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="SMSMPM_ID" SortExpression="SMSMPM_ID" HeaderText="销售月计划ID"
                                Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="PS_Name" SortExpression="PS_Name" HeaderText="系列" ReadOnly="true">
                            </asp:BoundField>
                           <asp:TemplateField SortExpression="PT_Name" HeaderText="型号">
							  <ItemTemplate>
                                    <asp:Label ID="lable_1" runat="server" Text='<%# Eval("PT_Name") %>'
                                     ToolTip='<%# Eval("PT_Code") %>'  Width="100px"></asp:Label>
                                </ItemTemplate>
						  </asp:TemplateField>
                            <asp:BoundField DataField="SMSMPD_ProductRequst" SortExpression="SMSMPD_ProductRequst"
                                HeaderText="要求" ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="SMSMPD_OrderNum" SortExpression="SMSMPD_OrderNum" HeaderText="订单量"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="SMSMPD_PlanAmount" SortExpression="SMSMPD_PlanAmount"
                                HeaderText="销售计划" ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="TotalNum"  HeaderText="库存量"
                                ReadOnly="True"></asp:BoundField>
                             <asp:BoundField DataField="WIP"  HeaderText="在制品量"
                                ReadOnly="True"></asp:BoundField>
                             <asp:BoundField DataField="SMSMPD_PMPNum" SortExpression="SMSMPD_PMPNum" HeaderText="投产计划"
                                ReadOnly="true"></asp:BoundField>
                             <asp:TemplateField HeaderText="投产计划" HeaderStyle-Font-Bold="true" Visible="true">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPlan" runat="server" Width="60px" Text='<%#Eval("SMSMPD_PMPNum")%>'></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle Font-Bold="True" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="PMPNumRef" SortExpression="PMPNumRef" HeaderText="参考投产"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="SMSMPD_Remark" SortExpression="SMSMPD_Remark" HeaderText="销售备注"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="SMSMPD_PMPNote" SortExpression="SMSMPD_PMPNote" HeaderText="生产备注"
                                ReadOnly="true"></asp:BoundField>
                            <asp:TemplateField HeaderText="生产备注" HeaderStyle-Font-Bold="true" Visible="true">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtNote" runat="server" Width="99%" Text='<%#Eval("SMSMPD_PMPNote")%>'></asp:TextBox>
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
                            <td width="10%">
                            </td>
                            <td align="center" width="20%">
                                <asp:Button ID="Button_Subold" runat="server" CssClass="Button02" Height="24px" OnClick="Button_Subold_click"
                                    Text="提交" Width="70px" OnClientClick="return confirm('确定提交生产月计划吗？提交后不能更改！提交的同时会把当前库存数、在制品数、参考投产数一并保存！')" />
                            </td>
                            <td align="center" width="20%">
                                <asp:Button ID="Button_Save" runat="server" CssClass="Button02" Height="24px" 
                                    Text="保存" Width="90px" onclick="Button_Save_Click" />
                            </td>
                            <td align="center" width="20%">
                                <asp:Button ID="Btn_Close_Detail" runat="server" CssClass="Button02" Height="24px" OnClientClick="hidden()"
                                    OnClick="Btn_Close_Detail_Click" Text="关闭" Width="70px" />
                            </td>
                            <td align="center" width="20%">
                                <asp:Button ID="Button_addpt" runat="server" CssClass="Button02" Height="24px" OnClick="AddProductModell"
                                    Text="新增产品型号" Width="90px" />
                            </td>
                            <td width="10%">
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_New" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_New" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="Label_time2" runat="server"></asp:Label>
                        生产月新增计划详细表<asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="Label2" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="Label_Result" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <asp:GridView ID="GridView_New" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        PageSize="2" CellPadding="0" UseAccessibleHeader="False" AllowPaging="false"
                        OnRowCommand="GridView_New_RowCommand" OnPageIndexChanging="GridView_New_PageIndexChanging"
                        OnRowEditing="GridView_New_Editing" OnRowCancelingEdit="GridView_New_CancelingEdit"
                        AllowSorting="True" OnRowCreated="GridView_New_RowCreated" OnSorting="GridView_New_Sorting"
                        OnRowUpdating="GridView_New_Updating" OnRowDataBound="GridView_New_RowDataBound"
                        Width="100%" DataKeyNames="SMSMPD_ID,SMSMPM_ID" EmptyDataText="无相关记录!" GridLines="None"
                        OnDataBound="GridView_New_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="SMSMPD_ID" SortExpression="SMSMPD_ID" HeaderText="销售月详细计划ID"
                                Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="SMSMPM_ID" SortExpression="SMSMPM_ID" HeaderText="销售月计划ID"
                                Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="PS_Name" SortExpression="PS_Name" HeaderText="系列" ReadOnly="true">
                            </asp:BoundField>
                            <asp:TemplateField SortExpression="PT_Name" HeaderText="型号">
							  <ItemTemplate>
                                    <asp:Label ID="lable_1" runat="server" Text='<%# Eval("PT_Name") %>'
                                     ToolTip='<%# Eval("PT_Code") %>'  ></asp:Label>
                              </ItemTemplate>
							</asp:TemplateField>
                            <asp:BoundField DataField="SMSMPD_PMPNewResult" SortExpression="SMSMPD_PMPNewResult"
                                HeaderText="状态" ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="SMSMPD_ProductRequst" SortExpression="SMSMPD_ProductRequst"
                                HeaderText="要求" ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="SMSMPD_OrderNum" SortExpression="SMSMPD_OrderNum" HeaderText="订单量"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="SMSMPD_PlanAmount" SortExpression="SMSMPD_PlanAmount"
                                HeaderText="销售计划" ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="SMSMPD_PMPNum" SortExpression="SMSMPD_PMPNum" HeaderText="投产计划">
                            </asp:BoundField>
                            <asp:BoundField DataField="SMSMPD_Remark" SortExpression="SMSMPD_Remark" HeaderText="销售备注"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="SMSMPD_PMPNote" SortExpression="SMSMPD_PMPNote" HeaderText="生产备注">
                            </asp:BoundField>
                            <asp:BoundField ReadOnly="true" DataField="SMSMPD_NewMakeMan" SortExpression="SMSMPD_NewMakeMan" HeaderText="新增人">
                            </asp:BoundField>
                             <asp:BoundField  ReadOnly="true" DataField="SMSMPD_NewMakeTime" SortExpression="SMSMPD_NewMakeTime"  DataFormatString="{0:yy-MM-dd HH:mm}" HeaderText="新增日期">
                            </asp:BoundField>
                            <asp:CommandField ShowEditButton="True" EditText="制定" UpdateText="更新" CancelText="关闭">
                            </asp:CommandField>
                            <asp:TemplateField Visible="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Review" runat="server" CommandArgument='<%# Eval("SMSMPD_ID")+","+Eval("PT_Name")+","+Eval("SMSMPD_PMPNewResult")%>'
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
                    <table width="100%">
                        <tr>
                            <td style="width: 10px">
                            </td>
                            <td align="right">
                                <asp:Button ID="Button_Subnew" runat="server" CssClass="Button02" Height="24px" OnClick="Button_Subnew_click"
                                    OnClientClick="return confirm('确定提交生产新增计划吗？提交后不能更改！')" Text="提交" Width="70px" />
                            </td>
                            <td align="center">
                                &nbsp;<asp:Button ID="Button1" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_Close_New_Click"
                                    Text="关闭" Width="70px" />
                                &nbsp;
                            </td>
                            <td align="left">
                                <asp:Button ID="Button_addpt2" runat="server" CssClass="Button02" Height="24px" OnClick="AddProductModell_New"
                                    Text="新增产品型号" Width="90px" />
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
                            <td style="width: 10%" align="right">
                                <asp:Button ID="Button14" runat="server" Text="检索" CssClass="Button02" Height="24px"
                                    OnClick="SelectProType" Width="70px" />
                            </td>
                            <td style="width: 10%" align="right">
                                
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
            <asp:Panel ID="Panel_Product" runat="server" Visible="false">
                <fieldset>
                    <legend>产品型号表(<asp:Label ID="Label_PT_NewOrOld" runat="server" Visible="False"></asp:Label><asp:Label
                        ID="Label_newold" runat="server"></asp:Label>) </legend>
                    <asp:GridView ID="GridView_ProType" runat="server" AllowPaging="True" PageSize="20"
                        Width="100%" AutoGenerateColumns="False" CellPadding="0" CssClass="GridViewStyle"
                        DataKeyNames="PT_ID" AllowSorting="True" 
                        OnPageIndexChanging="GridView_ProType_PageIndexChanging" GridLines="None"
                        OnRowDataBound="GridView_ProType_RowDataBound">
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemStyle Width="5%" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox2" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="PT_ID" HeaderText="产品型号ID" Visible="false" />
                            <asp:BoundField DataField="PS_Name" HeaderText="产品系列" ItemStyle-Width="45%" >
                            <ItemStyle Width="45%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PT_Name" HeaderText="产品型号" ItemStyle-Width="45%" >
                            <ItemStyle Width="45%" />
                            </asp:BoundField>
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
                    </asp:GridView>
                    <table style="width: 100%; text-align: center;" class="STYLE2">
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:CheckBox ID="Cbx2_SelectAll" runat="server" Text="全选" AutoPostBack="true" OnCheckedChanged="Cbx2_SelectAll_CheckedChanged" />
                                <asp:Button ID="ButtonPro" runat="server" Height="24px" CssClass="Button02" Text="提 交"
                                    OnClick="ButtonProType_Click" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%; text-align: center;" class="STYLE2">
                        <tr>
                            <td align="center">
                            <asp:Button ID="Button_ClosePT" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Btn_Close_PT_Click" Text="关闭" Width="70px" />
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
                        计划 部长审核栏<asp:Label ID="Label_PMPID" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="PMPCID" runat="server" Visible="False">PMPCID</asp:Label>
                    </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 15%">
                                &nbsp;</td>
                            <td style="width: 15%">
                                &nbsp;</td>
                            <td style="width: 20%">
                                
                            </td>
                            <td style="width: 20%" align="right">
                                &nbsp;</td>
                            <td style="width: 20%">
                                &nbsp;</td>
                            <td style="width: 15%">
                            </td>
                            <td style="width: 10%">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 15%">
                                审核意见:
                                <br />
                                (200字以内)
                            </td>
                            <td colspan="7">
                                <asp:TextBox ID="TB_shengchanyijian" runat="server" Height="88px" MaxLength="200"
                              TextMode="MultiLine"
                                    Width="99%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="9">
                                <table style="width: 100%">
                                    <tr>
                                        <td style="width: 33%; text-align: right">
                                            <asp:Button ID="BT_TKOK" runat="server" CssClass="Button02" OnClick="BT_TKOK_Click"
                                                Text="通过" Width="70px" OnClientClick="return confirm('确定审核通过吗？提交后不能更改！') " />
                                            <%--    OnClientClick="$find('gvEdit').hide();"--%>
                                        </td>
                                        <td style="width: 34%; text-align: center">
                                            <asp:Button ID="BT_TKNotOK" runat="server" CssClass="Button02" OnClick="BT_TKNotOK_Click"
                                                Text="驳回" Width="70px" OnClientClick="return confirm('确定审核驳回吗？提交后不能更改！')" />
                                        </td>
                                        <td style="width: 33%; text-align: left">
                                            <asp:Button ID="BT_TKCancel" runat="server" CssClass="Button02" OnClick="BT_TKCanel_Click"
                                                Text="关闭" Width="70px" />
                                        </td>
                                    </tr>
                                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:Panel ID="Panel2" runat="server">
        <fieldset>
            <legend>审核信息表 </legend>
            <asp:Button ID="CloseAudit" runat="server" CssClass="Button02" OnClick="CloseAudit_Click" Text="关闭" Width="70px" />
            <asp:GridView ID="GridView1" runat="server" CssClass="GridViewStyle" AutoGenerateColumns="False" 
                        GridLines="None" EmptyDataText="没有相关记录" OnRowCommand="GridView1_RowCommand"
                         DataKeyNames="PMPC_ID"  EnableModelValidation="True" OnRowDataBound="GridView1_RowDataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="PMPC_ID" HeaderText="会签ID" Visible="false"  />
                            <asp:BoundField DataField="BDOS_Name" HeaderText="会签部门" Visible="true" SortExpression="PMP_ID" />
                            <asp:BoundField DataField="PMPC_People" HeaderText="会签人" Visible="true" SortExpression="SMSMPM_Year" />
                          <asp:BoundField DataField="PMPC_Time" HeaderText="会签时间" Visible="true" SortExpression="SMSMPM_MakeTime" />
                            <asp:BoundField DataField="PMPC_Result" HeaderText="审核结果" Visible="true"  SortExpression="PMP_STime" />
                            <asp:BoundField DataField="PMPC_Suggestion" HeaderText="意见" Visible="true" SortExpression="PMP_ETime" />
                            


                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Detail" runat="server" CommandArgument='<%# Eval("PMPC_ID") %>' CommandName="Details">审核</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            
                        </Columns>
                 
                    </asp:GridView>
        <table style="width:100%;text-align:left;">
           
        </table>
            </fieldset>
    </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
