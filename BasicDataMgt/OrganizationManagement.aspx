<%@ Page Title="" Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true" CodeFile="OrganizationManagement.aspx.cs" Inherits="Laputa_OrganizationManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
    <asp:Panel ID="Panel1" runat="server">
        <fieldset>
            <legend>组织机构检索
             
                
            </legend>
        <table style="width:100%;text-align:left;">
            <tr>
                <td style="width: 20%; height: 20px;" align="right">机构名称:</td>
                <td style="width:26%; height: 20px;">
                    <asp:TextBox ID="TextBox1" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td style="width: 17%; height: 20px;" align="right">机构级别:</td>
                <td style="height: 20px;">
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem Value="0">所有类型</asp:ListItem>
                        <asp:ListItem Value="1">一级机构</asp:ListItem>
                        <asp:ListItem Value="2">二级机构</asp:ListItem>
                        <asp:ListItem Value="3">三级机构</asp:ListItem>
                       
                    </asp:DropDownList>
                </td>
                
            </tr>
            <tr>
                <td style="width: 72px">&nbsp;</td>
                <td align="center">
                    <asp:Button ID="MainSearch" runat="server" CssClass="Button02" Text="检索" Width="70px" OnClick="MainSearch_Click" />
                </td>
                <td style="width: 73px">
                    <asp:Button ID="create" runat="server" CssClass="Button02" OnClick="create_Click" Text="新增" Width="70px"/>
                </td>
                <td>
                    &nbsp;<asp:Button ID="reset" runat="server" CssClass="Button02" OnClick="reset_Click" Text="重置" Width="70px" />
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
            <legend>组织机构表 </legend>
            
            <asp:GridView ID="GridView1" runat="server" CssClass="GridViewStyle"  AllowPaging="True" PageSize="20" AutoGenerateColumns="False" 
                        GridLines="None" EmptyDataText="没有相关记录" OnRowCommand="GridView1_RowCommand"
                         DataKeyNames="BDOS_Code"  OnPageIndexChanging="GridView1_PageIndexChanging" EnableModelValidation="True">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                          
                            <asp:BoundField DataField="BDOS_Code" HeaderText="组织机构代码" Visible="false" SortExpression="SMSMPM_ID" />
                            <asp:BoundField DataField="BDOS_Name" HeaderText="组织机构名称" Visible="true" SortExpression="PMP_ID" />
                            <asp:BoundField DataField="BDOS_Level" HeaderText="机构级别" Visible="true" SortExpression="SMSMPM_Year" />
                            <asp:BoundField DataField="BDOS_Father" HeaderText="受控文件编号" Visible="False" SortExpression="SMSMPM_Year" />
                            <asp:BoundField DataField="Father_Name" HeaderText="父机构" Visible="true" SortExpression="SMSMPM_Month" />
                           

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Detail" runat="server" CommandArgument='<%# Eval("BDOS_Code") %>' CommandName="child">查看下属机构</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton13" runat="server" CommandArgument='<%# Eval("BDOS_Code") %>' CommandName="mo">编辑</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton14" runat="server" OnClientClick="return confirm('您确认删除该记录吗?')" CommandArgument='<%# Eval("BDOS_Code") %>' CommandName="del">删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            
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

                    </asp:GridView>
        <table style="width:100%;text-align:left;">
           
        </table>
            </fieldset>
    </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:Panel ID="Panel3" runat="server">
        <fieldset>
            <legend>
                <asp:Label ID="OrName" runat="server" Text="父机构名称"></asp:Label>
                下属组织机构  
                <asp:Label ID="OrCode" runat="server" Text="父机构代码" Visible="False"></asp:Label>
            </legend>
            <asp:GridView ID="GridView2" runat="server" CssClass="GridViewStyle"  AllowPaging="True" PageSize="5" AutoGenerateColumns="False" 
                        GridLines="None" EmptyDataText="没有相关记录" OnRowCommand="GridView2_RowCommand"
                         DataKeyNames="BDOS_Code"  OnPageIndexChanging="GridView2_PageIndexChanging" EnableModelValidation="True">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                           <asp:BoundField DataField="BDOS_Code" HeaderText="组织机构代码" Visible="false" SortExpression="SMSMPM_ID" />
                            <asp:BoundField DataField="BDOS_Name" HeaderText="组织机构名称" Visible="true" SortExpression="PMP_ID" />
                            <asp:BoundField DataField="BDOS_Level" HeaderText="机构级别" Visible="true" SortExpression="SMSMPM_Year" />
                            <asp:BoundField DataField="BDOS_Father" HeaderText="受控文件编号" Visible="False" SortExpression="SMSMPM_Year" />
                            <asp:BoundField DataField="Father_Name" HeaderText="父机构"  DataFormatString="" Visible="true" SortExpression="SMSMPM_Month" />


                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("BDOS_Code") %>' CommandName="mo">编辑</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton15" runat="server" CommandArgument='<%# Eval("BDOS_Code") %>' OnClientClick="return confirm('您确认删除该记录吗?')" CommandName="del">删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第<asp:Label ID="Label1" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>' />
                                        页 共<asp:Label ID="Label2" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />
                                        页
                                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandArgument="First"
                                            CommandName="Page" Text="首页" />
                                        <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandArgument="Prev"
                                            CommandName="Page" Text="上一页" />
                                        <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" CommandArgument="Next"
                                            CommandName="Page" Text="下一页" />
                                        <asp:LinkButton ID="LinkButton5" runat="server" CausesValidation="False" CommandArgument="Last"
                                            CommandName="Page" Text="尾页" />
                                        <asp:TextBox ID="textbox2" runat="server" Width="20px"></asp:TextBox>
                                        <asp:LinkButton ID="LinkButton6" runat="server" CausesValidation="False" CommandArgument="-1"
                                            CommandName="Page" Text="GO" /><!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
                                    </td>
                                </tr>
                            </table>
                        </PagerTemplate>
                    </asp:GridView>
        <table style="width:100%;text-align:left;">
           <tr>
            <td align="center">
            <asp:Button ID="CloseC" runat="server" CssClass="Button02" OnClick="CloseC_Click" Text="关闭" Width="70px" />
            </td>
        </tr>
        </table>
            </fieldset>
    </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
     <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:Panel ID="Panel4" runat="server">
        <fieldset>
            <legend>
                <asp:Label ID="Label3" runat="server" Text="新增"></asp:Label>
                机构
             
                
             
                <asp:Label ID="code" runat="server" Text="code" Visible="False"></asp:Label>
             
                
            </legend>
        <table style="width:100%;text-align:left;">
            <tr>
                <td style="width: 12%; height: 20px;" align="right">机构名称:</td>
                <td style="width:15%; height: 20px;">
                    <asp:TextBox ID="TextBox3" runat="server" Width="100%" AutoPostBack="True" OnTextChanged="TextBox3_TextChanged"></asp:TextBox>
                    </td>
                <td style="width:3%; height: 20px;">
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/images/button/ok.gif" Visible="False" />
                </td>
                <td style="width:10%; height: 20px;" align="right">机构级别:</td>
                <td style="width:12%; height: 20px;">
                    <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                       <asp:ListItem Value="1">一级机构</asp:ListItem>
                        <asp:ListItem Value="2">二级机构</asp:ListItem>
                        <asp:ListItem Value="3">三级机构</asp:ListItem>
                       
                    </asp:DropDownList>
                </td>
                <td style="width:78px; height: 20px;" align="right">选择父机构：</td>
                <td style="width:15%; height: 20px;">
                    <asp:DropDownList ID="DropDownList3" runat="server">
                        <asp:ListItem Value="无">无</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width:15%; height: 20px;">&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 72px">
                    <asp:Label ID="Label4" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
                <td align="right">
                    <asp:Button ID="Summit" runat="server" CssClass="Button02" Text="提交" Width="66px" OnClick="Summit_Click" />
                </td>
                <td align="right" style="width: 3%">&nbsp;</td>
                <td style="width: 73px">
                    <asp:Label ID="flag" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
                <td align="right">
                    <asp:Button ID="CloseM" runat="server" CssClass="Button02" OnClick="CloseM_Click" Text="关闭" Width="66px" />
                </td>
                <td style="width: 78px">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
            </fieldset>
    </asp:Panel>
         </ContentTemplate>
    </asp:UpdatePanel>



</asp:Content>

