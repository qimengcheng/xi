<%@ Page Title="培训类型维护" Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true"
    CodeFile="TrainingTypeMaintenance.aspx.cs" Inherits="TrainningMgt_TrainingTypeMaintenance" %>

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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server">
                <fieldset>
                    <legend>培训类型检索栏</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label2" runat="server" CssClass="STYLE2" Text="培训类型："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtSType" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                            </td>
                            <td style="width: 20%">
                            </td>
                            <td style="height: 16px;">
                            </td>
                            <td style="width: 10%">
                            </td>
                        </tr>
                        <tr>
                            <td align="right" colspan="2">
                                <asp:Label ID="LblRecordIsSearch" runat="server" Text="检索前" Visible="false"></asp:Label>
                                <asp:Button ID="BtnSearch" runat="server" CssClass="Button02" Height="24px"
                                    Text="检索" Width="70px" onclick="BtnSearch_Click" />
                            </td>
                            <td align="center" colspan="2">
                            <asp:Button ID="BtnNew" runat="server" CssClass="Button02" Height="24px"
                                    Text="新增培训类型" Width="90px" TabIndex="1" onclick="BtnNew_Click" />
                            
                                
                            </td>
                            <td align="left" colspan="2">
                                <asp:Button ID="BtnReset" runat="server" CssClass="Button02" Height="24px"
                                    Text="重置" Visible="true" Width="70px" TabIndex="2" 
                                    onclick="BtnReset_Click" />
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
                    <legend>培训类型列表</legend>
                    <asp:GridView ID="Grid_Type" runat="server" DataKeyNames="TTT_TypeID" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                        AllowPaging="True" PageSize="10" Font-Strikeout="False" GridLines="None" 
                        UseAccessibleHeader="False" ondatabound="Grid_Type_DataBound" 
                        onpageindexchanging="Grid_Type_PageIndexChanging" onrowcommand="Grid_Type_RowCommand"
                        >
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="TTT_TypeID" HeaderText="培训类型ID" SortExpression="TTT_TypeID"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="TTT_Type" HeaderText="培训类型" SortExpression="TTT_Type">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnEdit_Type" runat="server" CommandName="Edit_Type" OnClientClick="false"
                                        CommandArgument='<%#Eval("TTT_TypeID")%>'>编辑</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnDelete_Type" runat="server" CommandName="Delete_Type" OnClientClick="return confirm('您确认删除该记录吗?')"
                                        CommandArgument='<%#Eval("TTT_TypeID")%>'>删除</asp:LinkButton>
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
        <%--<Triggers>
            <asp:AsyncPostBackTrigger ControlID="Btn_NEW_NETItem" />
        </Triggers>--%>
        <ContentTemplate>
            <asp:Panel ID="Panel3" runat="server" Visible="false">
                <fieldset>
                    <legend>培训类型<asp:Label ID="Label3" runat="server" Text=""></asp:Label></legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label1" runat="server" CssClass="STYLE2" Text="培训类型："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtNewType" runat="server" Width="155px" MaxLength="10" ></asp:TextBox>
                                <asp:Label ID="Label4" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                    ValidationGroup="Type" ControlToValidate="TxtNewType"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td style="width: 10%" align="center">
                            </td>
                            <td style="width: 20%">
                                <asp:Label ID="Label17" runat="server" Text="" Visible="false"></asp:Label>
                            </td>
                            <td style="width: 10%">
                            </td>
                            <td style="width: 10%">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" align="center">
                                <asp:Button ID="BtnSubmit" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    Width="70px" ValidationGroup="Type" onclick="BtnSubmit_Click" />
                            </td>
                            <td colspan="3" align="center">
                                <asp:Button ID="BtnCancel" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    Visible="true" Width="70px" onclick="BtnCancel_Click"  />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
