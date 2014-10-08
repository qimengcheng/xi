<%@ Page Title="" Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true"
    CodeFile="PTCodeBasic.aspx.cs" Inherits="ProductionBasicInfo_PTCodeBasic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script type="text/javascript" language="javascript">
        function XN_CheckAllCnText(str) {
            var reg = /[\u4E00-\u9FA5]/g
            if (reg.test(str)) { alert("含有汉字"); }
            else { alert("不含有汉字"); }
        } 
</script> 
    <asp:UpdatePanel ID="UpdatePanel_PT" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_PT" runat="server">
                <fieldset>
                    <legend>成品编码属性表<asp:Label ID="label_pagestate" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        Font-Strikeout="False" GridLines="None" CellPadding="0" UseAccessibleHeader="False"
                        OnRowCommand="GridView2_RowCommand" Width="100%" EmptyDataText="无相关记录!">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="PTCB_ID" HeaderText="编码ID" Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="PTCB_Section" HeaderText="序号"></asp:BoundField>
                            <asp:BoundField DataField="PTCB_Code" HeaderText="位置"></asp:BoundField>
                            <asp:BoundField DataField="PTCB_Detail" HeaderText="属性名称"></asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete_PT" runat="server" CommandArgument='<%# Eval("PTCB_Section")+","+Eval("PTCB_Detail") %>'
                                        CommandName="Delete_PT">详细信息</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第 &nbsp;<asp:Label ID="lblPageIndex" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                        页 共 &nbsp;<asp:Label ID="lblPageCount" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageCount  %>" />
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
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" Visible="False">
                <fieldset>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 72px">
                                固定代码：
                            </td>
                            <td style="width: 131px">
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 87px">
                                <asp:Button ID="Button_Add0" runat="server" CssClass="Button02" Height="24px" OnClick="Button_s_Click"
                                    Text="检索" Width="67px" />
                            </td>
                            <td style="width: 100px; font-weight: 700;">
                                <asp:Button ID="Button_Add1" runat="server" CssClass="Button02" Height="24px" OnClick="Button_r_Click"
                                    Text="重置" Width="70px" />
                            </td>
                            <td style="width: 434px">
                                <asp:Button ID="Button_Add" runat="server" CssClass="Button02" Height="24px" 
                                    OnClick="Button_Add_Click" Text="新增详情" Width="90px" />
                            </td>
                            <td align="right">
                                <asp:Button ID="Button_Add2" runat="server" CssClass="Button02" Height="24px" 
                                    OnClick="Button_c_Click" Text="关闭" Width="90px" />
                            </td>
                        </tr>
                    </table>
                    <legend>
                        <asp:Label ID="Label17" runat="server" Text="Label"></asp:Label>
                        编码属性详情表<asp:Label ID="Label18" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        Font-Strikeout="False" GridLines="None" CellPadding="0" UseAccessibleHeader="False"
                        OnRowCommand="GridView1_RowCommand" Width="100%" EmptyDataText="无相关记录!" 
                        onpageindexchanging="GridView1_PageIndexChanging" AllowPaging="True">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="PTCB_ID" HeaderText="编码ID" Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="PTCB_Code" HeaderText="固定代码"></asp:BoundField>
                            <asp:BoundField DataField="PTCB_Detail" HeaderText="代码含义"></asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete1" runat="server" CommandArgument='<%# Eval("PTCB_ID")+","+Eval("PTCB_ID") %>'
                                        OnClientClick="return confirm('您确认删除该记录吗?')" CommandName="Delete1">删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Edit_PT" runat="server" CommandArgument='<%# Eval("PTCB_ID")+","+Eval("PTCB_Code")+","+Eval("PTCB_Detail") %>'
                                        CommandName="Edit_PT">编辑</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第 &nbsp;<asp:Label ID="lblPageIndex" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                        页 共 &nbsp;<asp:Label ID="lblPageCount" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageCount  %>" />
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
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel2" runat="server" Visible="False">
                <fieldset>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 113px">
                                固定代码：
                            </td>
                            <td style="width: 161px">
                                <asp:TextBox ID="TextBox2" runat="server" ></asp:TextBox>
                                <asp:Label ID="Label20" runat="server" ForeColor="Red" Text="*"></asp:Label>
                            </td>
                            <td style="width: 84px">
                                代码含义：
                            </td>
                            <td style="width: 147px;">
                                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                <asp:Label ID="Label21" runat="server" ForeColor="Red" Text="*"></asp:Label>
                            </td>
                            <td style="width: 96px">
                                <asp:Button ID="Button1" runat="server" CssClass="Button02" Height="24px" OnClick="Button_submit_Click"  
                                    Text="确定" Width="67px" />
                            </td>
                            <td style="width: 434px">
                                <asp:Button ID="Button2" runat="server" CssClass="Button02" Height="24px" 
                                    OnClick="Button_c2_Click" Text="取消" Width="70px" />
                            </td>
                            <td align="right">
                            </td>
                        </tr>
                    </table>
                    <legend>
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>详情</legend>  <asp:Label ID="Label2" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="Label19" runat="server" Visible="False"></asp:Label>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
