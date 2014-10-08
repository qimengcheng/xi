<%@ Page Title="新员工培训结果追踪与查看" Language="C#" MasterPageFile="~/Other/MasterPage.master"
    AutoEventWireup="true" CodeFile="NewEmpResultLook.aspx.cs" Inherits="TrainningMgt_NewEmpResultLook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server">
                <fieldset>
                    <legend>新员工培训项目栏</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%; height: 15px;" align="center">
                                <asp:Label ID="Label22" runat="server" CssClass="STYLE2" Text="工号："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 15px;">
                                <asp:TextBox ID="TxtSStaffNO" runat="server" Width="130px" Enabled="false"></asp:TextBox>
                            </td>
                            <td style="width: 10%; height: 15px;" align="center">
                                <asp:Label ID="Label3" runat="server" CssClass="STYLE2" Text="姓名："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 15px;">
                                <asp:TextBox ID="TxtSName" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%; height: 15px;" align="center">
                                <asp:Label ID="Label5" runat="server" CssClass="STYLE2" Text="主讲人："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 15px;">
                                <asp:TextBox ID="TxtSTeacher" runat="server" Width="130px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="LblSPerson" runat="server" CssClass="STYLE2" Text="培训组织人："></asp:Label>
                            </td>
                            <td style="width: 15%; height: 20%;" align="left">
                                <asp:TextBox ID="TxtSPerson" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="LblSStartTime" runat="server" CssClass="STYLE2" Text="组织时间："></asp:Label>
                            </td>
                            <td style="width: 15%; height: 20%;" align="left" colspan="2">
                                <asp:TextBox ID="TxtSStartTime" runat="server" Width="130px"  onfocus="new  WdatePicker(this,'%Y-%M-%D %h:%m:%s',true)"></asp:TextBox>
                                <asp:Label ID="LblEndTime" runat="server" CssClass="STYLE2" Text="至"></asp:Label>
                                <asp:TextBox ID="TxtSEndTime" runat="server" Width="130px"  onfocus="new  WdatePicker(this,'%Y-%M-%D %h:%m:%s',true)"></asp:TextBox>
                            </td>
                            <td style="width: 15%; height: 20%;" align="left">
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td align="right" colspan="2">
                                <asp:Label ID="LblRecordIsSearch" runat="server" Visible="false"></asp:Label>
                                <asp:Button ID="BtnSearch" runat="server" CssClass="Button02" Height="24px" Text="检索"
                                    Width="80px" />
                            </td>
                            <td align="center">
                            </td>
                            <td align="center" colspan="3">
                                <asp:Button ID="BtnReset" runat="server" CssClass="Button02" Height="24px" Text="重置"
                                    Width="80px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
                <fieldset>
                    <legend>新员工培训信息列表</legend>
                    <asp:GridView ID="GridView_Info" runat="server" DataKeyNames="NETICT_ID" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                        AllowPaging="True" PageSize="3" Font-Strikeout="False" UseAccessibleHeader="False"
                        GridLines="None">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="NETICT_ID" HeaderText="新员工培训项目选择ID" ReadOnly="True" SortExpression="NETICT_ID"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="NETI_TraningCourse" HeaderText="工号" SortExpression="NETI_TraningCourse">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="NETI_TraningType" HeaderText="姓名" SortExpression="NETI_TraningType">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="NETI_TraningCourse" HeaderText="主讲人" SortExpression="NETI_TraningCourse">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="NETIMT_Person" HeaderText="培训组织人" SortExpression="NETIMT_Person">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="NETIMT_Time" HeaderText="组织时间" SortExpression="NETIMT_Time">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="NETI_CreditHours" HeaderText="是否合格" SortExpression="NETI_CreditHours">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="NETEIRD_Remark" HeaderText="备注" SortExpression="NETEIRD_Remark">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnInputScore" runat="server" CommandArgument='<%#Eval("NETICT_ID")%>'
                                        CommandName="EditInputScore" OnClientClick="false">查看详情</asp:LinkButton>
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
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel2" runat="server">
           
                <fieldset>
                    <legend><asp:Label ID="LblRecordName" runat="server" Text=""></asp:Label> 培训详情</legend>
                    <asp:GridView ID="GridView1" runat="server" DataKeyNames="NETEIRD_ID" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                        AllowPaging="True" PageSize="3" Font-Strikeout="False" UseAccessibleHeader="False"
                        GridLines="None">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="NETEIRD_ID" HeaderText="培训结果明细ID" ReadOnly="True" SortExpression="NETEIRD_ID"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="NETI_TraningCourse" HeaderText="培训课程" SortExpression="NETI_TraningCourse">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="NETI_TraningType" HeaderText="培训类别" SortExpression="NETI_TraningType">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="BDOS_Name" HeaderText="授课部门" SortExpression="BDOS_Name">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="NETI_CreditHours" HeaderText="培训学时" SortExpression="NETI_CreditHours">
                                <ItemStyle />
                            </asp:BoundField>
                            
                            <asp:BoundField DataField="NETICT_STime" HeaderText="培训开始时间" SortExpression="NETICT_STime">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="NETICT_ETime" HeaderText="培训结束时间" SortExpression="NETICT_ETime">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="NETICT_Place" HeaderText="培训地点" SortExpression="NETICT_Place">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="NETICT_Person" HeaderText="主讲安排人" SortExpression="NETICT_Person">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="NETICT_Time" HeaderText="安排时间" SortExpression="NETICT_Time">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="NETEIRD_IsQualified" HeaderText="是否合格" SortExpression="NETEIRD_IsQualified">
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
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
