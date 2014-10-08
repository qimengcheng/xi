<%@ Page Title="客户投诉汇总表" Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true" CodeFile="CustomerComplaint.aspx.cs" Inherits="REPORT_cc_CustomerComplaint" %>

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
                    <legend>客户投诉检索栏</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 13%; height: 15px;" align="center">
                                <asp:Label ID="Label1" runat="server" Text="客户名称："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 15px;">
                                <asp:TextBox ID="TextBox1" runat="server" Width="155px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label6" runat="server" Text="投诉类别："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:DropDownList ID="DropDownList2" runat="server" Width="155px"></asp:DropDownList>
                            </td>
                            <td style="width: 10%; height: 15px;" align="center">
                                <asp:Label ID="Label3" runat="server" Text="售后类别："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 15px;">
                                <asp:DropDownList ID="DropDownList1" runat="server" Width="155px"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                    <asp:Label ID="Label111" runat="server" Text="投诉时间："></asp:Label>
                                </td>
                                </td>
                                <td>
                                    <asp:TextBox ID="laststar" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',false)"
                                        DataFormatString="{0:yyyy-MM-dd}" Width="155px"></asp:TextBox>
                                </td>
                                <td align="center">
                                    <asp:Label ID="Label112" runat="server" Text="至"></asp:Label>
                                </td>
                                <td >
                                    <asp:TextBox ID="lastend" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',false)"
                                        DataFormatString="{0:yyyy-MM-dd}" Width="155px"></asp:TextBox>
                                </td>
                                <td></td>
                                <td></td>
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
                    <legend>客户投诉汇总表</legend>
                    <asp:GridView ID="Grid_Detail" runat="server" AllowSorting="True" PageSize="20" AutoGenerateColumns="False" CssClass="GridViewStyle" Width="100%" 
                        AllowPaging="true"  GridLines="None" OnPageIndexChanging="Grid_Detail_PageIndexChanging">
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
                            <asp:BoundField DataField="CRMCIF_Name" HeaderText="客户名称" SortExpression="CRMCIF_Name">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCS_Name" HeaderText="投诉类别" SortExpression="CRMCS_Name">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMASS_Name" HeaderText="售后类别" SortExpression="CRMASS_Name">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="PT_Name" HeaderText="产品型号" SortExpression="PT_Name">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="PT_Note" HeaderText="产品备注" SortExpression="PT_Note">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCCD_BatchNum" HeaderText="批号" SortExpression="CRMCCD_BatchNum">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCCM_Remark" HeaderText="客诉备注" SortExpression="CRMCCM_Remark">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCCD_AnalysisResult" HeaderText="分析结果" SortExpression="CRMCCD_AnalysisResult">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCCM_InputTime" HeaderText="投诉时间" SortExpression="CRMCCM_InputTime">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCCM_RequireFinishTime" HeaderText="要求完成天数" SortExpression="CRMCCM_RequireFinishTime">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCCM_CheckOpinion" HeaderText="审核意见" SortExpression="CRMCCM_CheckOpinion">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCCM_CheckTime" HeaderText="审核时间" SortExpression="CRMCCM_CheckTime">
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
