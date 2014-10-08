<%@ Page Title="新员工培训结果查看" Language="C#" MasterPageFile="~/Other/MasterPage.master"
    AutoEventWireup="true" CodeFile="NewEmpResuls.aspx.cs" Inherits="TrainningMgt_NewEmpResuls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
    <style type="text/css">
        .hidden
        {
            display: none;
        }
    </style>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server">
                <fieldset>
                    <legend>新员工培训信息检索栏</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="LblCourse" runat="server" CssClass="STYLE2" Text="姓名:"></asp:Label>
                            </td>
                            <td style="height: 15%">
                                <asp:TextBox ID="TxtSName" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label3" runat="server" CssClass="STYLE2" Text="性别:"></asp:Label>
                            </td>
                            <td style="width: 15%">
                                <asp:TextBox ID="TextBox1" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label4" runat="server" CssClass="STYLE2" Text="报到日期:"></asp:Label>
                            </td>
                            <td style="width: 15%">
                                <asp:TextBox ID="TxtSStartTime" runat="server" Width="130px" onfocus="new  WdatePicker(this,'%Y-%M-%D',false)"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="LblEndTime" runat="server" CssClass="STYLE2" Text="至"></asp:Label>
                            </td>
                            <td style="width: 15%">
                                <asp:TextBox ID="TxtSEndTime" runat="server" Width="130px" onfocus="new  WdatePicker(this,'%Y-%M-%D',false)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td align="center" colspan="4">
                                <asp:Label ID="LblRecordIsSearch" runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="LblCondition1" runat="server" Visible="false"></asp:Label>
                                <asp:Button ID="BtnSearch" runat="server" CssClass="Button02" Height="24px" Text="检索"
                                    Width="70px" OnClick="BtnSearch_Click" />
                            </td>
                            <td align="center" colspan="4">
                                <asp:Button ID="BtnReset" runat="server" CssClass="Button02" Height="24px" Text="重置"
                                    Width="70px" OnClick="BtnReset_Click" />
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
                    <legend>新员工培训结果列表</legend>
                    <asp:GridView ID="GridView_Info" runat="server" DataKeyNames="NETPCT_ID" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                        AllowPaging="True" PageSize="10" Font-Strikeout="False" UseAccessibleHeader="False"
                        GridLines="None" OnDataBound="GridView_Info_DataBound" OnPageIndexChanging="GridView_Info_PageIndexChanging"
                        OnRowCommand="GridView_Info_RowCommand">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="NETPCT_ID" HeaderText="新员工选择ID" ReadOnly="True" SortExpression="NETPCT_ID"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="NETPCT_Name" HeaderText="姓名" SortExpression="NETPCT_Name">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="NETPCT_Sex" HeaderText="姓别" SortExpression="NETPCT_Sex">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="NETPCT_Date" HeaderText="报到日期" SortExpression="NETPCT_Date"
                                HtmlEncode="False" DataFormatString="{0:yy-MM-dd}">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="NETIMT_Time" HeaderText="参与培训的时间" SortExpression="NETIMT_Time">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="NETPCT_FResult" HeaderText="最终是否合格" SortExpression="NETPCT_FResult">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnDetailInfo" runat="server" CommandArgument='<%#Eval("NETPCT_ID")%>'
                                        CommandName="DetailInfo" OnClientClick="false">查看培训详情</asp:LinkButton>
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
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel3" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>新员工培训详情列表<asp:Label ID="Label2"
                            runat="server" Text="" Visible="false"></asp:Label></legend>
                    <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                        CssClass="GridViewStyle" CellPadding="0" Width="100%" AllowPaging="True" PageSize="20"
                        Font-Strikeout="False" UseAccessibleHeader="False" GridLines="None" OnDataBound="GridView1_DataBound"
                        OnPageIndexChanging="GridView1_PageIndexChanging">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="NETI_TraningCourse" HeaderText="培训内容" SortExpression="NETI_TraningCourse">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="NETI_TraningType" HeaderText="培训类型" SortExpression="NETI_TraningType">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="NETI_CreditHours" HeaderText="学时" SortExpression="NETI_CreditHours">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="NETICT_STime" HeaderText="培训开始时间" SortExpression="NETICT_STime">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="NETICT_ETime" HeaderText="培训结束时间" SortExpression="NETICT_ETime">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="NETICT_Place" HeaderText="授课地点" SortExpression="NETICT_Place">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="NETEIRD_IsQualified" HeaderText="是否合格" SortExpression="NETEIRD_IsQualified">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="NETEIRD_Remark" HeaderText="备注" SortExpression="NETEIRD_Remark">
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
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
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
