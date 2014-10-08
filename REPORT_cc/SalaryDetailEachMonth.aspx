<%@ Page Title="每月薪资汇总表" MasterPageFile="~/Other/MasterPage.master" Language="C#" AutoEventWireup="true" CodeFile="SalaryDetailEachMonth.aspx.cs" Inherits="REPORT_cc_SalaryDetailEachMonth" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script language="javascript" type="text/javascript">
    </script>

    <asp:UpdatePanel ID="UpdatePanel_Search" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Search" runat="server">
                <fieldset>
                    <legend>检索栏</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 13%; height: 15px;" align="center">
                                <asp:Label ID="Label1" runat="server" Text="工号："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 15px;">
                                <asp:TextBox ID="textno" runat="server" Width="155px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label6" runat="server" Text="姓名："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                 <asp:TextBox ID="textname" runat="server" Width="155px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label5" runat="server" Text="部门："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="textdep" runat="server" Width="155px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 13%" align="center">
                                <asp:Label ID="Label7" runat="server" Text="岗位："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                 <asp:TextBox ID="textpost" runat="server" Width="155px"></asp:TextBox>
                            </td>
                            <td style="width: 13%; height: 15px;" align="center">
                                <asp:Label ID="Label3" runat="server" Text="年份："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 15px;">
                                <asp:TextBox ID="textyear" runat="server" Width="155px" onkeyup="this.value=this.value.replace(/[^0-9]/g,'')" 
                                     onafterpaste="this.value=this.value.replace(/[^[0-9]/g,'')" MaxLength="4"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label4" runat="server" Text="月份："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                 <asp:TextBox ID="textmon" runat="server" Width="155px" onkeyup="this.value=this.value.replace(/[^0-9]/g,'')" 
                                     onafterpaste="this.value=this.value.replace(/[^[0-9]/g,'')" MaxLength="2"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                        <td align="right" colspan="2">
                            <asp:Button ID="BtnSearch" runat="server" CssClass="Button02" Height="24px" Text="检索"
                                Width="70px" OnClick="BtnSearch_Click" />
                        </td>
                        <td align="center" colspan="2">
                            <asp:Button ID="BtnPrint" runat="server" CssClass="Button02" Height="24px" Text="打印报表" Width="90px" OnClick="BtnPrint_Click" ToolTip="点击此处,跳转打印页面。"/>
                        </td>
                        <td align="left" colspan="2">
                            <asp:Button ID="BtnReset" runat="server" CssClass="Button02" Height="24px" Text="重置"
                                Visible="true" Width="70px" OnClick="BtnReset_Click"/>
                        </td>
                    </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

<asp:UpdatePanel ID="UpdatePanel_Grid" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Grid" runat="server">
                <fieldset>
                    <legend>
                    <asp:Label ID="Label11" runat="server"></asp:Label>年
                    <asp:Label ID="Label12" runat="server"></asp:Label>月
                    <asp:Label ID="Label13" runat="server"></asp:Label>(
                    <asp:Label ID="Label14" runat="server"></asp:Label>)薪资汇总表</legend>
                    <div id="grid" style="overflow:auto; width:100%">
                    <asp:GridView ID="Grid_Detail" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="GridViewStyle" Width="200%" 
                        AllowPaging="true"  GridLines="None" OnPageIndexChanging="Grid_Detail_PageIndexChanging" PageSize="10">
                        <RowStyle CssClass="GridViewRowStyle"/>
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead"/>
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                        <asp:TemplateField HeaderText="序号" >
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1%>
                            </ItemTemplate>
                            <ItemStyle />
                        </asp:TemplateField>
                        <asp:BoundField DataField="SDBT_NO" HeaderText="工号" SortExpression="SDBT_NO">
                            <ItemStyle/>
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_Name" HeaderText="姓名" SortExpression="SDBT_Name">
                            <ItemStyle/>
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_Dep"  HeaderText="部门" SortExpression="SDBT_Dep">
                            <ItemStyle/>
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_Post"  HeaderText="岗位" SortExpression="SDBT_Post">
                            <ItemStyle/>
                        </asp:BoundField>
                        <asp:BoundField DataField="HRDD_EntryDate"  HeaderText="入职日期" SortExpression="HRDD_EntryDate" DataFormatString="{0:yyyy-MM-dd}">
                            <ItemStyle/>
                        </asp:BoundField>
                        <asp:BoundField DataField="EndDate"  HeaderText="截止日期" SortExpression="EndDate">
                            <ItemStyle/>
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_WorkLength"  HeaderText="工龄" SortExpression="SDBT_WorkLength">
                            <ItemStyle/>
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_TimeCount"  HeaderText="工时" SortExpression="SDBT_TimeCount">
                            <ItemStyle/>
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_TWage"  HeaderText="计时工资" SortExpression="SDBT_TWage">
                            <ItemStyle/>
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_PWage"  HeaderText="计件工资" SortExpression="SDBT_PWage">
                            <ItemStyle/>
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_Basic"  HeaderText="基本工资" SortExpression="SDBT_Basic">
                            <ItemStyle/>
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_FullTime"  HeaderText="全勤工资" SortExpression="SDBT_FullTime">
                            <ItemStyle/>
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_Perform"  HeaderText="绩效工资" SortExpression="SDBT_Perform">
                            <ItemStyle/>
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_OverTime"  HeaderText="加班工资" SortExpression="SDBT_OverTime">
                            <ItemStyle/>
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_WorkAge"  HeaderText="工龄工资" SortExpression="SDBT_WorkAge">
                            <ItemStyle/>
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_MidSchedule"  HeaderText="中班补助" SortExpression="SDBT_MidSchedule">
                            <ItemStyle/>
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_NightSchedule"  HeaderText="夜班补助" SortExpression="SDBT_NightSchedule">
                            <ItemStyle/>
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_TeamLeader"  HeaderText="小组长补助" SortExpression="SDBT_TeamLeader">
                            <ItemStyle/>
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_LastMonth"  HeaderText="补上月" SortExpression="SDBT_LastMonth">
                            <ItemStyle/>
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_KouMo"  HeaderText="扣膜补贴" SortExpression="SDBT_KouMo">
                            <ItemStyle/>
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_HighTep"  HeaderText="高温补贴" SortExpression="SDBT_HighTep">
                            <ItemStyle/>
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_Insurance"  HeaderText="劳保补贴" SortExpression="SDBT_Insurance">
                            <ItemStyle/>
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_OtherSubsidies"  HeaderText="其他补助" SortExpression="SDBT_OtherSubsidies">
                            <ItemStyle/>
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_PaidVacation"  HeaderText="有薪假" SortExpression="SDBT_PaidVacation">
                            <ItemStyle/>
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_OtherPaid"  HeaderText="其他应发款项" SortExpression="SDBT_OtherPaid">
                            <ItemStyle/>
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_AttendancePaidCut"  HeaderText="出勤扣款" SortExpression="SDBT_AttendancePaidCut">
                            <ItemStyle/>
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_PerfromPaidCut"  HeaderText="绩效扣款" SortExpression="SDBT_PerfromPaidCut">
                            <ItemStyle/>
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_PassPercentPaidCut"  HeaderText="合格率扣款" SortExpression="SDBT_PassPercentPaidCut">
                            <ItemStyle/>
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_BadPaidCut"  HeaderText="压塑压坏扣款" SortExpression="SDBT_BadPaidCut">
                            <ItemStyle/>
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_OtherPaidCut"  HeaderText="其他应发款项扣款" SortExpression="SDBT_OtherPaidCut">
                            <ItemStyle/>
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_EndowmentInsurance"  HeaderText="养老保险" SortExpression="SDBT_EndowmentInsurance">
                            <ItemStyle/>
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_MedicalInsurance"  HeaderText="医疗保险" SortExpression="SDBT_MedicalInsurance">
                            <ItemStyle/>
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_UnemployedInsurance"  HeaderText="失业保险" SortExpression="SDBT_UnemployedInsurance">
                            <ItemStyle/>
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_InjuryInsurance"  HeaderText="工伤保险" SortExpression="SDBT_InjuryInsurance">
                            <ItemStyle/>
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_MaternityInsurance"  HeaderText="生育保险" SortExpression="SDBT_MaternityInsurance">
                            <ItemStyle/>
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_InsuranceTotal"  HeaderText="保险合计" SortExpression="SDBT_InsuranceTotal">
                            <ItemStyle/>
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_HousingFund"  HeaderText="住房公积金" SortExpression="SDBT_HousingFund">
                            <ItemStyle/>
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_InsuranceAndFund"  HeaderText="险金合计" SortExpression="SDBT_InsuranceAndFund">
                            <ItemStyle/>
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_OtherCut"  HeaderText="其他应扣款项扣款" SortExpression="SDBT_OtherCut">
                            <ItemStyle/>
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_IndividualTax"  HeaderText="个人所得税" SortExpression="SDBT_IndividualTax">
                            <ItemStyle/>
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_AccruedWages"  HeaderText="应发工资" SortExpression="SDBT_AccruedWages">
                            <ItemStyle/>
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_RealWages"  HeaderText="实发工资" SortExpression="SDBT_RealWages">
                            <ItemStyle/>
                        </asp:BoundField>
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
                            <asp:Label ID="Label16" runat="server" Text="没有找到相关记录" ></asp:Label>
                        </EmptyDataTemplate>
                        <EditRowStyle BackColor="white" />
                    </asp:GridView>
                    <br/>
                    </div>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

    

</asp:Content>

