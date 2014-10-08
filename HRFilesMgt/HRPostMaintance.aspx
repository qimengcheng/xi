<%@ Page Title="人事岗位维护页面" Language="C#" MasterPageFile="~/Other/MasterPage.master"
    AutoEventWireup="true" CodeFile="HRPostMaintance.aspx.cs" Inherits="HRFilesMgt_HRPostMaintance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script language="javascript" type="text/javascript">

        function ValidtorTime(start, end) {
            var idstart = "ctl00_ContentPlaceHolder1_" + start;
            var idend = "ctl00_ContentPlaceHolder1_" + end;
            var d1 = new Date(document.getElementById(idstart).value.replace(/\-/g, "\/"));
            var d2 = new Date(document.getElementById(idend).value.replace(/\-/g, "\/"));
            if (d1 > d2) {
                return false;
            }
            return true;
        }


        function annotation(name) {
            var id = "ctl00_ContentPlaceHolder1_" + name;
            var label = document.getElementById(id);
            label.style.visibility = 'visible';
            return false;
        }
        function leave(name) {
            var id = "ctl00_ContentPlaceHolder1_" + name;
            var label = document.getElementById(id);
            label.style.visibility = 'hidden';
            return false;
        }

        function isdigit(name) {
            var id = "ctl00_ContentPlaceHolder1_" + name;
            var s = document.getElementById(id).value;
            var r, re;
            re = /\d*/i; //\d表示数字,*表示匹配多个数字
            r = s.match(re);
            return (r == s) ? true : false;
        }

    </script>
    <asp:UpdatePanel ID="UpdatePanel_Search" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Search" runat="server">
                <fieldset>
                    <legend>人事岗位检索栏</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label2" runat="server" CssClass="STYLE2" Text="部门:"></asp:Label>
                                <asp:Label ID="LblRecordIsSearch" runat="server" Text="检索前" Visible="false"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:DropDownList ID="DdlDep" runat="server" ToolTip="单击选择">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="LblPost" runat="server" CssClass="STYLE2" Text="岗位:"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtPost" runat="server" Width="155px"></asp:TextBox>
                            </td>
                            <td style="height: 16px;">
                            </td>
                            <td style="width: 10%">
                            </td>
                        </tr>
                        <tr>
                            <td align="right" colspan="2">
                                <asp:Button ID="BtnSearch" runat="server" CssClass="Button02" Height="24px" OnClick="BtnSearch_Click"
                                    Text="检索" Width="70px" CausesValidation="False" />
                            </td>
                            <td align="center" colspan="2">
                                <asp:Button ID="BtnNew" runat="server" CssClass="Button02" Height="24px" OnClick="BtnNew_Click"
                                    Text="新增岗位" Width="70px" CausesValidation="False" />
                            </td>
                            <td align="left" colspan="2">
                                <asp:Button ID="BtnReset" runat="server" CssClass="Button02" Height="24px" OnClick="BtnReset_Click"
                                    Text="重置" Visible="true" Width="70px" CausesValidation="False" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_Post" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Post" runat="server">
                <fieldset>
                    <legend>人事岗位列表</legend>
                    <asp:GridView ID="Grid_Post" runat="server" DataKeyNames="HRP_ID" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" Width="100%" AllowPaging="True"
                        PageSize="10" GridLines="None" UseAccessibleHeader="False" OnPageIndexChanging="Grid_Post_PageIndexChanging"
                        OnRowCommand="Grid_Post_RowCommand" OnRowCreated="Grid_Post_RowCreated" 
                        OnSorting="Grid_Post_Sorting" ondatabound="Grid_Post_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="HRP_ID" HeaderText="岗位ID" SortExpression="BDOS_Name" Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="BDOS_Name" HeaderText="部门" SortExpression="BDOS_Name">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="BDOS_Code" HeaderText="部门ID" SortExpression="BDOS_Code"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="HRP_Post" HeaderText="岗位" SortExpression="HRP_Post">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnEdit_Post" runat="server" CommandArgument='<%#Eval("HRP_ID")%>'
                                        CommandName="Edit_Post" OnClientClick="false">编辑</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnDelete_Post" runat="server" CommandName="Delete_Post" OnClientClick="return confirm('您确认删除该记录吗?')"
                                        CommandArgument='<%#Eval("HRP_ID")%>'>删除</asp:LinkButton>
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
    <asp:UpdatePanel ID="UpdatePanel_NewPost" runat="server" UpdateMode="Conditional">
        <%--<Triggers>
            <asp:AsyncPostBackTrigger ControlID="Btn_NEW_NETItem" />
        </Triggers>--%>
        <ContentTemplate>
            <asp:Panel ID="Panel_NewPost" runat="server" Visible="false">
                <fieldset>
                    <legend>人事岗位维护</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label1" runat="server" CssClass="STYLE2" Text="部门:"></asp:Label>
                                <asp:Label ID="LblState" runat="server" Text="Label" Visible="False"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:DropDownList ID="DdlNewDep" runat="server" ToolTip="单击选择">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ErrorMessage="*" ValidationGroup="Post" ControlToValidate="DdlNewDep"></asp:RequiredFieldValidator>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label3" runat="server" CssClass="STYLE2" Text="岗位:"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtNewPost" runat="server" Width="155px" MaxLength="10"
                                        onfocus="annotation('Label47');" onblur="javascript:leave('Label47');"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ErrorMessage="*" ValidationGroup="Post" ControlToValidate="TxtNewPost"></asp:RequiredFieldValidator>
                            </td>
                            <td style="width: 10%">
                            <asp:Label ID="Label47" runat="server" ForeColor="#999999" Text="10字以内" Style="visibility: hidden;"></asp:Label>
                            </td>
                            <td style="width: 10%">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" align="center">
                                <asp:Button ID="BtnSubmit" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    Width="70px" OnClick="BtnSubmit_Click" ValidationGroup="Post"/>
                            </td>
                            <td colspan="3" align="center">
                                <asp:Button ID="BtnCancel" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    Visible="true" Width="70px" OnClick="BtnCancel_Click" 
                                    CausesValidation="False" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
