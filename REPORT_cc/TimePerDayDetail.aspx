﻿<%@ Page Title="" Language="C#" MasterPageFile="~/other/MasterPage.master" AutoEventWireup="true" CodeFile="TimePerDayDetail.aspx.cs" Inherits="REPORT_cc_TimePerDayDetail" %>

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
                    <legend>计时详情信息检索栏</legend>
                    <table style="width: 100%;">
                        <tr>
                        <td style="width: 10%" align="center">
                                <asp:Label ID="Label111" runat="server" Text="统计时间："></asp:Label>
                            </td>
                            </td>
                            <td>
                                <asp:TextBox ID="startime" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',false)"
                                    DataFormatString="{0:yyyy-MM-dd}" Width="155px"></asp:TextBox>
                            </td>
                            <td align="center">
                                <asp:Label ID="Label112" runat="server" Text="至"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="endtime" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',false)"
                                    DataFormatString="{0:yyyy-MM-dd}" Width="155px"></asp:TextBox>
                            </td>
                            
                            <td style="width: 10%; height: 15px;" align="center">
                                <asp:Label ID="Label3" runat="server" Text="计时项目名称："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 15px;">
                                <asp:TextBox ID="textno" runat="server" Width="155px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 13%; height: 15px;" align="center">
                                <asp:Label ID="Label1" runat="server" Text="工序："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 15px;">
                                <asp:TextBox ID="textname" runat="server" Width="155px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label6" runat="server" Text="随工单号："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="texttype" runat="server" Width="155px"></asp:TextBox>
                            </td>
                            <td style="width: 10%; height: 15px;" align="center">
                                <asp:Label ID="Label2" runat="server" Text="工号："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 15px;">
                                <asp:TextBox ID="TxtStaffNO" runat="server" Width="155px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 13%; height: 15px;" align="center">
                                <asp:Label ID="Label4" runat="server" Text="姓名："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 15px;">
                                <asp:TextBox ID="TxtStaffName" runat="server" Width="155px"></asp:TextBox>
                            </td>
                            <td style="width: 13%; height: 15px;" align="center">
                                <asp:Label ID="Label5" runat="server" Text="部门："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 15px;">
                                <asp:TextBox ID="TxtDep" runat="server" Width="155px"></asp:TextBox>
                            </td>
                            <td style="width: 13%; height: 15px;" align="center">
                                <asp:Label ID="Label7" runat="server" Text="岗位："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 15px;">
                                <asp:TextBox ID="TxtPost" runat="server" Width="155px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" colspan="2">
                                <asp:Label ID="LblRecordCondition" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Label ID="LblRecordIsSearch" runat="server" Text="检索前" Visible="false"></asp:Label>
                                <asp:Button ID="BtnSearch" runat="server" CssClass="Button02" Height="24px" Text="检索"
                                    Width="70px" onclick="BtnSearch_Click"  />
                            </td>
                            <td align="center" colspan="2">
                              <asp:Button ID="Button2" runat="server"  CssClass ="Button02"
        Text="打印报表" Width="58px" OnClick="Button2_Click1"  ToolTip="点击此处,跳转打印页面。" />
                            </td>
                            <td align="left" colspan="2">
                                <asp:Button ID="BtnReset" runat="server" CssClass="Button02" Height="24px" Text="重置"
                                    Visible="true" Width="70px" onclick="BtnReset_Click"  />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_Grid" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Grid" runat="server" Visible="false">
                <fieldset>
                    <legend>计时信息详情统计表</legend>
                    <asp:GridView ID="Grid_Detail" runat="server" AllowSorting="True" PageSize="20" AutoGenerateColumns="False"
                        CssClass="GridViewStyle" Width="100%" AllowPaging="true" GridLines="None" 
                        onpageindexchanging="Grid_Detail_PageIndexChanging">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:TemplateField HeaderText="序号">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="thedate" HeaderText="时间" SortExpression="thedate" DataFormatString="{0:yyyy-MM-dd}">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="PBC_Name" HeaderText="工序" SortExpression="PBC_Name">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="WO_Num" HeaderText="随工单号" SortExpression="WO_Num">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="WO_ProType" HeaderText="产品型号" SortExpression="WO_ProType">
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
                            <asp:BoundField DataField="STI_Name" HeaderText="计时项目名称" SortExpression="STI_Name">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="STI_UnitPrice" HeaderText="单价" SortExpression="STI_UnitPrice">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="TNFD_TimeLength" HeaderText="时长" SortExpression="TNFD_TimeLength">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="thenum" HeaderText="产量" SortExpression="thenum">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="MoneyDetail" HeaderText="工资" SortExpression="MoneyDetail">
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
                                        <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                            CommandName="Page" Text="GO" />
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
</asp:Content>


