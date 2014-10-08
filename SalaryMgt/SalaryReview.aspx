<%@ Page Title="薪资个人查看" Language="C#" MasterPageFile="~/Other/MasterPage.master"
    AutoEventWireup="true" CodeFile="SalaryReview.aspx.cs" Inherits="SalaryMgt_SalaryReview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server">
                <fieldset>
                    <legend>检索栏</legend>
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
                                <asp:Label ID="LblSearchYear" runat="server" CssClass="STYLE2" Text="年份：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TxtSearchYear" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="LblSearchMonth" runat="server" CssClass="STYLE2" Text="月份：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TxtSearchMonth" runat="server" Width="130px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center">
                                <asp:Label ID="LblRecordIsSearch" runat="server" Text="检索前" Visible="false"></asp:Label>
                                <asp:Button ID="BtnSearchEmployee" runat="server" CssClass="Button02" Height="24px"
                                    Text="检索" Width="70px" OnClick="BtnSearchEmployee_Click" />
                            </td>
                            <td colspan="4" align="center">
                                <asp:Button ID="BtnResetEmployee" runat="server" CssClass="Button02" Height="24px"
                                    Width="70px" Text="重置" OnClick="BtnResetEmployee_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel2" runat="server">
                <fieldset>
                    <legend>员工工资列表</legend>
                    <asp:GridView ID="GridView1" runat="server" DataKeyNames="HRDD_ID" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" Width="100%" AllowPaging="True"
                        PageSize="10" GridLines="None" OnPageIndexChanging="GridView1_PageIndexChanging"
                        OnRowCommand="GridView1_RowCommand">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="SDBT_ID" HeaderText="工资详情ID" SortExpression="SDBT_ID"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="HRDD_ID" HeaderText="员工ID" SortExpression="HRDD_ID" Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="HRDD_StaffNO" HeaderText="员工编号" SortExpression="HRDD_StaffNO">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="HRDD_Name" HeaderText="员工姓名" SortExpression="HRDD_Name">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMC_Year" HeaderText="年份" SortExpression="SMC_Year">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMC_Month" HeaderText="月份" SortExpression="SMC_Month">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SDBT_RealWages" HeaderText="工资总额" SortExpression="SDBT_RealWages">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SDBT_WorkLength" HeaderText="工龄" SortExpression="SDBT_WorkLength"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SDBT_TimeCount" HeaderText="工时" SortExpression="SDBT_TimeCount"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SDBT_TWage" HeaderText="计时工资" SortExpression="SDBT_TWage"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SDBT_PWage" HeaderText="计件工资" SortExpression="SDBT_PWage"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SDBT_Basic" HeaderText="基本工资" SortExpression="SDBT_Basic"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SDBT_FullTime" HeaderText="全勤工资" SortExpression="SDBT_FullTime"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SDBT_Perform" HeaderText="绩效工资" SortExpression="SDBT_Perform"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SDBT_OverTime" HeaderText="加班工资" SortExpression="SDBT_OverTime"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SDBT_WorkAge" HeaderText="工龄工资" SortExpression="SDBT_WorkAge"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SDBT_MidSchedule" HeaderText="中班补贴" SortExpression="SDBT_MidSchedule"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SDBT_NightSchedule" HeaderText="夜班补贴" SortExpression="SDBT_NightSchedule"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SDBT_TeamLeader" HeaderText="小组长补助" SortExpression="SDBT_TeamLeader"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SDBT_LastMonth" HeaderText="补上月" SortExpression="SDBT_LastMonth"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SDBT_KouMo" HeaderText="扣膜补贴" SortExpression="SDBT_KouMo"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SDBT_HighTep" HeaderText="高温补贴" SortExpression="SDBT_HighTep"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SDBT_Insurance" HeaderText="劳保补贴" SortExpression="SDBT_Insurance"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SDBT_OtherSubsidies" HeaderText="其他补助" SortExpression="SDBT_OtherSubsidies"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SDBT_PaidVacation" HeaderText="有薪假" SortExpression="SDBT_PaidVacation"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SDBT_OtherPaid" HeaderText="其他应发款项" SortExpression="SDBT_OtherPaid"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SDBT_AttendancePaidCut" HeaderText="出勤扣款" SortExpression="SDBT_AttendancePaidCut"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SDBT_PerfromPaidCut" HeaderText="绩效扣款" SortExpression="SDBT_PerfromPaidCut"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SDBT_PassPercentPaidCut" HeaderText="合格率扣款" SortExpression="SDBT_PassPercentPaidCut"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SDBT_BadPaidCut" HeaderText="压塑压坏扣款" SortExpression="SDBT_BadPaidCut"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SDBT_OtherPaidCut" HeaderText="其他应发款项扣款" SortExpression="SDBT_OtherPaidCut"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SDBT_EndowmentInsurance" HeaderText="养老保险" SortExpression="SDBT_EndowmentInsurance"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SDBT_MedicalInsurance" HeaderText="医疗保险" SortExpression="SDBT_MedicalInsurance"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SDBT_UnemployedInsurance" HeaderText="失业保险" SortExpression="SDBT_UnemployedInsurance"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SDBT_InjuryInsurance" HeaderText="工伤保险" SortExpression="SDBT_InjuryInsurance"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SDBT_MaternityInsurance" HeaderText="生育保险" SortExpression="SDBT_MaternityInsurance"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SDBT_InsuranceTotal" HeaderText="保险合计" SortExpression="SDBT_InsuranceTotal"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SDBT_HousingFund" HeaderText="住房公积金" SortExpression="SDBT_HousingFund"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SDBT_InsuranceAndFund" HeaderText="险金合计" SortExpression="SDBT_InsuranceAndFund"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SDBT_OtherCut" HeaderText="其他应扣款项扣款" SortExpression="SDBT_OtherCut"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SDBT_IndividualTax" HeaderText="个人所得税" SortExpression="SDBT_IndividualTax"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SDBT_AccruedWages" HeaderText="应发工资" SortExpression="SDBT_AccruedWages"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                           
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnSearchDetail" runat="server" 
                                        CommandName="SearchDetail" OnClientClick="false" CommandArgument='<%#Eval("SDBT_ID")+","+Eval("HRDD_ID")+","+Eval("HRDD_StaffNO")+","+Eval("HRDD_Name")+","+Eval("SMC_Year")+","+Eval("SMC_Month")+","+Eval("SDBT_Dep")+","+Eval("SDBT_Post")+","+Eval("SDBT_WorkLength")+","+Eval("SDBT_TimeCount")+","+Eval("SDBT_TWage")+","+Eval("SDBT_PWage")+","+Eval("SDBT_Basic")
                                        +","+Eval("SDBT_FullTime")+","+Eval("SDBT_Perform")+","+Eval("SDBT_OverTime")+","+Eval("SDBT_WorkAge")+","+Eval("SDBT_MidSchedule")+","+Eval("SDBT_NightSchedule")+","+Eval("SDBT_TeamLeader")+","+Eval("SDBT_LastMonth")+","+Eval("SDBT_KouMo")+","+Eval("SDBT_HighTep")+","+Eval("SDBT_Insurance")+","+Eval("SDBT_OtherSubsidies")
                                        +","+Eval("SDBT_PaidVacation")+","+Eval("SDBT_OtherPaid")+","+Eval("SDBT_AttendancePaidCut")+","+Eval("SDBT_PerfromPaidCut")+","+Eval("SDBT_PassPercentPaidCut")+","+Eval("SDBT_BadPaidCut")+","+Eval("SDBT_OtherPaidCut")+","+Eval("SDBT_EndowmentInsurance")+","+Eval("SDBT_MedicalInsurance")+","+Eval("SDBT_UnemployedInsurance")+","+Eval("SDBT_InjuryInsurance")+","+Eval("SDBT_MaternityInsurance")
                                        +","+Eval("SDBT_InsuranceTotal")+","+Eval("SDBT_HousingFund")+","+Eval("SDBT_InsuranceAndFund")+","+Eval("SDBT_OtherCut")+","+Eval("SDBT_IndividualTax")+","+Eval("SDBT_AccruedWages")+","+Eval("SDBT_RealWages")%>'>查看明细</asp:LinkButton>
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
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel3" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="Label10" runat="server" Text=""></asp:Label><asp:Label ID="Label47"
                            runat="server" Text="" Visible="false"></asp:Label></legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label1" runat="server" CssClass="STYLE2" Text="工龄：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TextBox1" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label2" runat="server" CssClass="STYLE2" Text="工时：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TextBox2" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label3" runat="server" CssClass="STYLE2" Text="计时工资：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TextBox3" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label6" runat="server" CssClass="STYLE2" Text="计件工资：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TextBox4" runat="server" Width="130px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label7" runat="server" CssClass="STYLE2" Text="基本工资：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TextBox5" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label8" runat="server" CssClass="STYLE2" Text="全勤工资：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TextBox6" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label9" runat="server" CssClass="STYLE2" Text="绩效工资：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TextBox7" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label11" runat="server" CssClass="STYLE2" Text="加班工资：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TextBox8" runat="server" Width="130px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label12" runat="server" CssClass="STYLE2" Text="工龄工资：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TextBox9" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label13" runat="server" CssClass="STYLE2" Text="中班补贴：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TextBox10" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label14" runat="server" CssClass="STYLE2" Text="夜班补贴：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TextBox11" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label15" runat="server" CssClass="STYLE2" Text="小组长补助：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TextBox12" runat="server" Width="130px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label17" runat="server" CssClass="STYLE2" Text="补上月：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TextBox13" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label18" runat="server" CssClass="STYLE2" Text="扣膜补贴：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TextBox14" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label19" runat="server" CssClass="STYLE2" Text="高温补贴：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TextBox15" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label20" runat="server" CssClass="STYLE2" Text="劳保补贴：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TextBox16" runat="server" Width="130px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label21" runat="server" CssClass="STYLE2" Text="其他补助：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TextBox17" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label22" runat="server" CssClass="STYLE2" Text="有薪假：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TextBox18" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label23" runat="server" CssClass="STYLE2" Text="其他应发款：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TextBox19" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label24" runat="server" CssClass="STYLE2" Text="出勤扣款：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TextBox20" runat="server" Width="130px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label25" runat="server" CssClass="STYLE2" Text="绩效扣款：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TextBox21" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label26" runat="server" CssClass="STYLE2" Text="合格率扣款：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TextBox22" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label27" runat="server" CssClass="STYLE2" Text="压塑压坏扣款：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TextBox23" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label28" runat="server" CssClass="STYLE2" Text="其他应发款项扣款：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TextBox24" runat="server" Width="130px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label29" runat="server" CssClass="STYLE2" Text="养老保险：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TextBox25" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label30" runat="server" CssClass="STYLE2" Text="医疗保险：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TextBox26" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label31" runat="server" CssClass="STYLE2" Text="失业保险：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TextBox27" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label32" runat="server" CssClass="STYLE2" Text="工伤保险：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TextBox28" runat="server" Width="130px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label33" runat="server" CssClass="STYLE2" Text="生育保险：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TextBox29" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label34" runat="server" CssClass="STYLE2" Text="保险合计：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TextBox30" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label35" runat="server" CssClass="STYLE2" Text="住房公积金：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TextBox31" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label36" runat="server" CssClass="STYLE2" Text="险金合计：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TextBox32" runat="server" Width="130px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label37" runat="server" CssClass="STYLE2" Text="其他应扣款项扣款：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TextBox33" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label38" runat="server" CssClass="STYLE2" Text="个人所得税：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TextBox34" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label39" runat="server" CssClass="STYLE2" Text="应发工资：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TextBox35" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label40" runat="server" CssClass="STYLE2" Text="实发工资：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TextBox36" runat="server" Width="130px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 100%" align="center">
                                <asp:Button ID="BtnClose" runat="server" CssClass="Button02" Height="24px" Text="关闭"
                                    Width="70px" OnClick="BtnClose_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
