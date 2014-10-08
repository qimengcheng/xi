<%@ Page Title="产品测试参数管理" Language="C#" MasterPageFile="~/Other/MasterPage.master"
    AutoEventWireup="true" CodeFile="PBPTIPS.aspx.cs" Inherits="ProductionBasicInfo_PBPTIPS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel_Search" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Search" runat="server" Visible="true">
                <fieldset>
                    <legend>测试参数类别查询<asp:Label ID="label_pagestate" runat="server" Visible="False"></asp:Label></legend>
                    <table style="width: 100%;">
                        <tr style="width: 100%;">
                            <td style="width: 11%;">
                                测试参数类别：
                            </td>
                            <td align="left" style="width: 469px">
                                <asp:TextBox ID="Txt_search" runat="server" Width="80%"></asp:TextBox>
                            </td>
                            <td style="width: 14%;" align="right">
                                <asp:Button ID="Btn_Search" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_Search_Click"
                                    Text="检索" Width="70px" />
                            </td>
                            <td style="width: 16%;" align="center">
                                <asp:Button ID="Button_Cancel" runat="server" CssClass="Button02" Height="24px" OnClick="Button_Cancel_Click"
                                    Text="重置" Width="70px" />
                            </td>
                            <td style="width: 9%;" align="right">
                                <asp:Button ID="Button3" runat="server" CssClass="Button02" Height="24px" OnClick="Button_ADD1_Click"
                                    Text="新增测试参数类别" Width="120px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_AddPS" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_AddPS" runat="server" Visible="false">
                <fieldset>
                    <legend>测试参数类别新增</legend>
                    <table style="width: 100%;">
                        <tr style="width: 100%;">
                            <td style="width: 11%;">
                                测试参数类别：
                            </td>
                            <td align="left" style="width: 919px">
                                <asp:TextBox ID="TextBox1" runat="server" Width="77%"></asp:TextBox>
                                <asp:Label ID="Label17" runat="server" ForeColor="Red" Text="*"></asp:Label>
                            </td>
                            <td style="width: 16%;" align="center">
                                <asp:Button ID="Button1" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_confirmAdd1_Click"
                                    Text="确定" Width="70px" />
                            </td>
                            <td align="left" style="width: 18%;">
                                <asp:Button ID="Button2" runat="server" CssClass="Button02" Height="24px" OnClick="Button_Cancel_Click"
                                    Text="取消" Width="70px" />
                            </td>
                            <td style="width: 9%;" align="center">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_PS" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel2" runat="server" Visible="true">
                <fieldset>
                    <legend>测试参数类别表<asp:Label ID="Lab_State" runat="server" Visible="False" /><asp:Label
                        ID="Label3" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        Font-Strikeout="False" GridLines="None" PageSize="10" CellPadding="0" UseAccessibleHeader="False"
                        AllowPaging="True" OnRowCommand="GridView1_RowCommand" OnPageIndexChanging="GridView1_PageIndexChanging"
                        OnRowEditing="Gridview_PS_Editing" OnRowCancelingEdit="Gridview_PS_CancelingEdit"
                        AllowSorting="True" OnRowUpdating="Gridview_PS_Updating" Width="100%" DataKeyNames="IPSM_ID">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="IPSM_ID" HeaderText="测试参数主表ID" SortExpression="IPSM_ID"
                                Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="IPSM_Type" SortExpression="IPSM_Type" HeaderText="测试参数类别">
                            </asp:BoundField>
                            <asp:CommandField ShowEditButton="True" EditText="编辑" UpdateText="更新" CancelText="关闭">
                                <ItemStyle Width="10%" />
                            </asp:CommandField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete1" runat="server" CommandArgument='<%# Eval("IPSM_ID") %>'
                                        CommandName="Delete1" OnClientClick="return confirm('您确认删除该记录吗?')">删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="CheckProType" runat="server" CommandArgument='<%# Eval("IPSM_ID")+","+Eval("IPSM_Type") %>'
                                        CommandName="CheckProType">查看所属详细项目</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第 &nbsp;<asp:Label ID="lblPageIndex" runat="server" Text="<%#  ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                        页 共 &nbsp;<asp:Label ID="lblPageCount" runat="server" Text="<%#  ((GridView)Container.Parent.Parent).PageCount  %>" />
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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="Label2" runat="server" Text="Label" Visible="False"></asp:Label>详细项目表<asp:Label
                            ID="Label_MID" runat="server" Visible="False" Text="00000000-0000-0000-0000-000000000000"></asp:Label>
                    </legend>
                    <table style="width: 100%;">
                        <tr style="width: 100%;">
                            <td style="width: 8%;">
                                <asp:Label ID="Label18" runat="server" Visible="False"></asp:Label>
                            </td>
                            <td style="width: 14%;" align="left">
                                &nbsp;
                            </td>
                            <td style="width: 8%;">
                                &nbsp;
                            </td>
                            <td style="width: 16%;" align="left">
                                <asp:Button ID="Button5" runat="server" CssClass="Button02" Height="24px" OnClick="Button_Add2_Click"
                                    Text="新增详细项目" Width="100px" />
                            </td>
                            <td style="width: 9%;" align="right">
                                <asp:Button ID="Button7" runat="server" CssClass="Button02" Height="24px" OnClick="Button_Cancel7_Click"
                                    Text="关闭" Width="70px" />
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        Font-Strikeout="False" GridLines="None" PageSize="10" CellPadding="0" UseAccessibleHeader="False"
                        AllowPaging="false" OnRowCommand="GridView2_RowCommand" OnRowEditing="Gridview2_Editing"
                        OnRowCancelingEdit="Gridview2_CancelingEdit" AllowSorting="True" OnRowUpdating="Gridview2_Updating"
                        Width="100%" DataKeyNames="IPSD_ID" OnDataBound="GridView2_DataBound" 
                        onrowdatabound="GridView2_RowDataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="IPSD_ID" HeaderText="详细项目ID" SortExpression="IPSD_ID"
                                Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="IPSD_Type" SortExpression="IPSD_Type" HeaderText="所属详细项目">
                            </asp:BoundField>
                            <asp:CommandField ShowEditButton="True" EditText="编辑" UpdateText="更新" CancelText="关闭">
                                <ItemStyle Width="10%" />
                            </asp:CommandField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete1" runat="server" CommandArgument='<%# Eval("IPSD_ID") %>'
                                        CommandName="Delete1" OnClientClick="return confirm('您确认删除该记录吗?')">删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第 &nbsp;<asp:Label ID="lblPageIndex" runat="server" Text="<%#  ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                        页 共 &nbsp;<asp:Label ID="lblPageCount" runat="server" Text="<%#  ((GridView)Container.Parent.Parent).PageCount  %>" />
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
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel3" runat="server" Visible="false">
                <fieldset>
                    <legend>新增详细项目</legend>
                    <table style="width: 100%;">
                        <tr style="width: 100%;">
                            <td style="width: 8%;">
                                所属详细项目：
                            </td>
                            <td align="left" colspan="3">
                                <asp:TextBox ID="TextBox2" runat="server" Width="95%"></asp:TextBox>
                            </td>
                            <td style="width: 9%;" align="center">
                                &nbsp;
                            </td>
                        </tr>
                        <tr style="width: 100%;">
                            <td style="width: 8%;">
                                &nbsp;
                            </td>
                            <td align="center" style="width: 14%;">
                                <asp:Button ID="Button4" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_Confirm2_Click"
                                    Text="确定" Width="70px" />
                            </td>
                            <td style="width: 8%;">
                                &nbsp;
                            </td>
                            <td align="left" style="width: 16%;">
                                <asp:Button ID="Button6" runat="server" CssClass="Button02" Height="24px" OnClick="Button_Cancel2_Click"
                                    Text="取消" Width="70px" />
                            </td>
                            <td align="center" style="width: 9%;">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
