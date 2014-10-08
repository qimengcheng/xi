<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SalaryDetailEachMonthPrint.aspx.cs" Inherits="REPORT_cc_SalaryDetailEachMonthPrint"  Title="每月薪资汇总表打印"  EnableEventValidation="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="Stylesheet" href="../css/style.css" />
      <script type="text/javascript" src="../JS/jquery-1.10.2.min.js"></script>
     <script type="text/javascript">
         $(document).ready(
          function () {
              $("th").css("border-left", "1px solid black");
              $(".cg tr td:first-child").css("border-left", "none");
              $(".cg th:first-child").css("border-left", "none");
          });
     </script>
             <style type="text/css">
      
         .table_border
         {
             border-collapse: collapse;
             border-bottom: 1px #DDD solid;
             border-left: 1px #DDD solid;
             border-color: black;
             width: 100%;
         }
         .table_border td
         {
             border-collapse: collapse;
             border-top: 1px #DDD solid;
             border-right: 1px #DDD solid;
             border-color: black;
         }
      
         .cg {
             border: none;
         }
         .cg td
         {
             border-left: 1px solid black;
             border-collapse: collapse;
             border-right : 0px solid red;
             border-spacing: 0;
         }

        
       
   
        
         .auto-style2 {
             height: 55px;
         }
         .auto-style3 {
             height: 17px;
         }
         .auto-style4 {
             height: 40px;
         }
                 .auto-style5 {
                     width: 821px;
                 }
                 </style>
             </head>
             <script type="text/javascript" language="Javascript">
                 function preview() {
                     bdhtml = window.document.body.innerHTML;
                     sprnstr = "<!--startprint-->";
                     eprnstr = "<!--endprint-->";
                     prnhtml = bdhtml.substr(bdhtml.indexOf(sprnstr) + 17);
                     prnhtml = prnhtml.substring(0, prnhtml.indexOf(eprnstr));
                     window.document.body.innerHTML = prnhtml;
                     window.print();
                 }
             </script>
<body style="text-align: center; width: 1024px; margin: 0 auto; background-color: #FFFFFF;
    background-image: none">
    <form id="form1" runat="server" width="1024px">
    <!--startprint-->
    <p style="font-size: 25px;">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/share.jpg" Height="39px" Width="67px" />
            <asp:Label ID="Label6" runat="server" Text="乐山希尔电子 — " Font-Size="25px"></asp:Label>
                    <asp:Label ID="Label13" runat="server" Font-Size="25px"></asp:Label>
                    <asp:Label ID="Label8" runat="server" Font-Size="25px" Text="("></asp:Label>
                    <asp:Label ID="Label14" runat="server" Font-Size="25px"></asp:Label>
                    <asp:Label ID="Label9" runat="server" Font-Size="25px" Text=")薪资汇总表"></asp:Label>
    </p>
    <div style="text-align: left;">
            <table border="0" cellspacing="1" width="100%" style="text-align: center">
                <tr>
                    <td align="center" valign="top">
                        <asp:Label ID="Label1" runat="server" Text="统计时间：" Font-Size="15px"></asp:Label>
                        &nbsp;
                        <asp:Label ID="Labelyear" runat="server" Text="Labelyear" Font-Size="15px"></asp:Label>
                        &nbsp;
                        <asp:Label ID="Label2" runat="server" Text="年" Font-Size="15px"></asp:Label>
                        &nbsp;
                        <asp:Label ID="Labelmonth" runat="server" Text="Labelmonth" Font-Size="15px"></asp:Label>
                        &nbsp;
                        <asp:Label ID="Label7" runat="server" Text="月" Font-Size="15px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center" valign="top" height="13px"></td>
                </tr>
                <tr>
                    <td >
                        <asp:GridView ID="Grid_Detail" runat="server" CssClass="GridViewStyle" Width="100%" AutoGenerateColumns="False" GridLines="None">
                        <RowStyle CssClass="GridViewRowStyle"/>
                        <HeaderStyle CssClass="GridViewHead" Font-Bold="True" Font-Size="15px" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                          <asp:TemplateField HeaderText="序号" >
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1%>
                            </ItemTemplate>
                            <ItemStyle />
                        </asp:TemplateField>
                        <asp:BoundField DataField="SDBT_NO" HeaderText="工号" SortExpression="SDBT_NO">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_Name" HeaderText="姓名" SortExpression="SDBT_Name">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_Dep"  HeaderText="部门" SortExpression="SDBT_Dep">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_Post"  HeaderText="岗位" SortExpression="SDBT_Post">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="HRDD_EntryDate"  HeaderText="入职日期" SortExpression="HRDD_EntryDate">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="EndDate"  HeaderText="截止日期" SortExpression="EndDate">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_WorkLength"  HeaderText="工龄" SortExpression="SDBT_WorkLength">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_TimeCount"  HeaderText="工时" SortExpression="SDBT_TimeCount">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_TWage"  HeaderText="计时工资" SortExpression="SDBT_TWage">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_PWage"  HeaderText="计件工资" SortExpression="SDBT_PWage">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_Basic"  HeaderText="基本工资" SortExpression="SDBT_Basic">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_FullTime"  HeaderText="全勤工资" SortExpression="SDBT_FullTime">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_Perform"  HeaderText="绩效工资" SortExpression="SDBT_Perform">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_OverTime"  HeaderText="加班工资" SortExpression="SDBT_OverTime">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_WorkAge"  HeaderText="工龄工资" SortExpression="SDBT_WorkAge">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_MidSchedule"  HeaderText="中班补助" SortExpression="SDBT_MidSchedule">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_NightSchedule"  HeaderText="夜班补助" SortExpression="SDBT_NightSchedule">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_TeamLeader"  HeaderText="小组长补助" SortExpression="SDBT_TeamLeader">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_LastMonth"  HeaderText="补上月" SortExpression="SDBT_LastMonth">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_KouMo"  HeaderText="扣膜补贴" SortExpression="SDBT_KouMo">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_HighTep"  HeaderText="高温补贴" SortExpression="SDBT_HighTep">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_Insurance"  HeaderText="劳保补贴" SortExpression="SDBT_Insurance">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_OtherSubsidies"  HeaderText="其他补助" SortExpression="SDBT_OtherSubsidies">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_PaidVacation"  HeaderText="有薪假" SortExpression="SDBT_PaidVacation">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_OtherPaid"  HeaderText="其他应发款项" SortExpression="SDBT_OtherPaid">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_AttendancePaidCut"  HeaderText="出勤扣款" SortExpression="SDBT_AttendancePaidCut">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_PerfromPaidCut"  HeaderText="绩效扣款" SortExpression="SDBT_PerfromPaidCut">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_PassPercentPaidCut"  HeaderText="合格率扣款" SortExpression="SDBT_PassPercentPaidCut">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_BadPaidCut"  HeaderText="压塑压坏扣款" SortExpression="SDBT_BadPaidCut">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_OtherPaidCut"  HeaderText="其他应发款项扣款" SortExpression="SDBT_OtherPaidCut">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_EndowmentInsurance"  HeaderText="养老保险" SortExpression="SDBT_EndowmentInsurance">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_MedicalInsurance"  HeaderText="医疗保险" SortExpression="SDBT_MedicalInsurance">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_UnemployedInsurance"  HeaderText="失业保险" SortExpression="SDBT_UnemployedInsurance">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_InjuryInsurance"  HeaderText="工伤保险" SortExpression="SDBT_InjuryInsurance">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_MaternityInsurance"  HeaderText="生育保险" SortExpression="SDBT_MaternityInsurance">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_InsuranceTotal"  HeaderText="保险合计" SortExpression="SDBT_InsuranceTotal">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_HousingFund"  HeaderText="住房公积金" SortExpression="SDBT_HousingFund">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_InsuranceAndFund"  HeaderText="险金合计" SortExpression="SDBT_InsuranceAndFund">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_OtherCut"  HeaderText="其他应扣款项扣款" SortExpression="SDBT_OtherCut">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_IndividualTax"  HeaderText="个人所得税" SortExpression="SDBT_IndividualTax">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_AccruedWages"  HeaderText="应发工资" SortExpression="SDBT_AccruedWages">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="SDBT_RealWages"  HeaderText="实发工资" SortExpression="SDBT_RealWages">
                            <ItemStyle />
                        </asp:BoundField>
                        </Columns>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label16" runat="server" Text="没有找到相关记录"></asp:Label>
                        </EmptyDataTemplate>
                    </asp:GridView>
                   </td>
               </tr>
         </table>
    </div>
    <br />
    <div style="text-align: left; width: 100%; font-size: small;">
        <table style="width: 100%;border: 0">
                <tr>
                    <td align="right"  style="width: 42%;">
                        <asp:Label ID="Label3" runat="server" Text="打印人："></asp:Label>
                        <asp:Label ID="Labelpeople" runat="server" Text="Labelpeople"></asp:Label>
                    </td>
                    <td style="width: 15%;"></td>
                    <td >
                        <asp:Label ID="Label4" runat="server" Text="打印时间："></asp:Label>
                        <asp:Label ID="Labeltime" runat="server" Text="Labeltime"></asp:Label>
                    </td>
                </tr>
            </table>
    </div>
   <br />
    <!--endprint-->
    <div style="text-align: left; width: 100%; font-size: small;">
        <table style="width: 100%;border: 0">
        <tr>
            <td style="width: 40%;" align="right">
                <asp:Button ID="Button1" runat="server" OnClientClick="preview()" CssClass="Button02"
                    Text="打印" Width="70px" />
            </td>
            <td style="width: 20%;" align="center">
                <asp:Button ID="Button2" runat="server" CssClass="Button02"
                    Text="导出Excel" Width="70px" onclick="Button2_Click" />
            </td>
            <td>
                <asp:Button ID="Button3" runat="server" CssClass="Button02" OnClick="Button3_Click"
                    Text="返回" Width="70px" />
            </td>
        </tr>
    </table>
    </div>


    </form>
</body>