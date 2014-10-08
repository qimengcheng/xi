<%@ Page Title="" Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true" CodeFile="HSFElement.aspx.cs" Inherits="Laputa_HSFElement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            
            <asp:Panel ID="Panel1" runat="server">
                <fieldset>
                    <legend>
            
                        有毒物质检索
                    </legend>
                    <table style="width: 100%" >
                        <tr>
                            <td style="width: 69px" >物质名称：</td>
                            <td style="width: 112px" >
                                <asp:TextBox ID="TextBox1" runat="server" Width="100%"></asp:TextBox>
                            </td>
                            <td style="width: 112px">&nbsp;</td>
                            <td style="width: 156px" >
                                <asp:Button ID="Search" runat="server" CssClass="Button02" OnClick="Search_Click" Text="检索" Width="66px" />
                            </td>
                            <td style="width: 140px" >
                                <asp:Button ID="Add" runat="server" CssClass="Button02" OnClick="Add_Click" Text="新增有毒成分" Width="96px" />
                            </td>
                            <td >&nbsp;</td>
             
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
                    <legend>有毒物质基础数据</legend>
                    <asp:GridView ID="GridView1" runat="server" CssClass="GridViewStyle"  AllowPaging="True" AutoGenerateColumns="False"
                                  GridLines="None" EmptyDataText=" 没有相关记录 " OnRowCommand="GridView1_RowCommand"  OnPageIndexChanging="GridView1_PageIndexChanging" EnableModelValidation="True" Height="16px" OnRowDataBound="GridView1_RowDataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="HSFElement_ID" HeaderText="HSFElementID" Visible="false"  />
                            <asp:BoundField DataField="HSFElement_Name" HeaderText="物质名称" Visible="true"  />
                            <asp:BoundField DataField="HSFElement_Standard" HeaderText="管控标准" Visible="true"  />
                            <asp:BoundField DataField="HSFElement_Object" HeaderText="管控范围" Visible="true"  />
                            <asp:BoundField DataField="HSFElement_Man" HeaderText="录入人" Visible="true"  />
                            <asp:BoundField DataField="HSFElement_Time" HeaderText="录入时间" DataFormatString="{0:yyyy-MM-dd HH:mm}" Visible="true"  />
                            <asp:BoundField DataField="HSFElement_Note" HeaderText="备注" Visible="true"  />


                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Modify" runat="server" CommandArgument='<%# Eval("HSFElement_ID") %>' CommandName="Modify">编辑</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>    
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Del" runat="server" OnClientClick=" return confirm('您确认删除该记录吗?') " CommandArgument='<%# Eval("HSFElement_ID") %>' CommandName="Del">删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                           
                           
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第<asp:Label ID="lblPageIndex" runat="server" Text='<%# ((GridView) Container.Parent.Parent).PageIndex + 1 %>' />
                                        页 共 <asp:Label ID="lblPageCount" runat="server" Text='<%# ((GridView) Container.Parent.Parent).PageCount %>' />
                                        页
                                        <asp:LinkButton ID="btnFirst" runat="server" CausesValidation="False" CommandArgument="First"
                                                        CommandName="Page" Text="首页 " />
                                        <asp:LinkButton ID="btnPrev" runat="server" CausesValidation="False" CommandArgument="Prev"
                                                        CommandName="Page" Text="上一页 " />
                                        <asp:LinkButton ID="btnNext" runat="server" CausesValidation="False" CommandArgument="Next"
                                                        CommandName="Page" Text="下一页 " />
                                        <asp:LinkButton ID="btnLast" runat="server" CausesValidation="False" CommandArgument="Last"
                                                        CommandName="Page" Text="尾页 " />
                                        <asp:TextBox ID="textbox" runat="server" Width="20px"></asp:TextBox>
                                        <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                                        CommandName="Page" Text="GO" /><!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
                                    </td>
                                </tr>
                            </table>
                        </PagerTemplate>
                    </asp:GridView>
        
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
 
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel3" runat="server" Visible="False">
                <fieldset>
                    <legend>
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                        有毒物质</legend>
                    <table style="text-align: left; width: 100%;">
                        <tr>
                            <td style="width: 95px" >有毒物质名称:</td>
                            <td style="width: 15%">
                                <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 67px" >管控标准:</td>
                            <td style="width: 70px">
                                <asp:DropDownList ID="DropDownList4" runat="server">
                                    <asp:ListItem Value="&lt;">小于</asp:ListItem>
                                    <asp:ListItem Value="&gt;">大于</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="width: 15%">
                                <asp:TextBox ID="TextBox12" runat="server" Width="100%"></asp:TextBox>
                            </td>
                            <td >(ppm)</td>
                            <td style="width: 15%">
                                <asp:Label ID="ElementID" runat="server" Text="ElelementID" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 95px">管控范围:<br /> (不大于1000个字)</td>
                            <td colspan="5">
                                <asp:TextBox ID="TextBox13" runat="server"  Width="100%" Height="100px" MaxLength="100" TextMode="MultiLine"></asp:TextBox>
                            </td>
                            <td style="width: 15%">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 95px" >备注:<br /> (不大于200个字)</td>
                            <td colspan="5">
                                <asp:TextBox ID="TextBox14" runat="server" TabIndex="200" TextMode="MultiLine" Width="100%"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 95px" >&nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td style="width: 67px" >
                                <asp:Button ID="Summit" runat="server" class="Button02" Text="提交" OnClick="Summit_Click" Width="59px" />
                            </td>
                            <td style="width: 70px">&nbsp;</td>
                            <td>
                                &nbsp;<asp:Button ID="close" runat="server"  class="Button02" Text="关闭" Width="66px" OnClick="close_Click" />
                            </td>
                            <td >&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>