<%@ Page Title="" Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true" CodeFile="CraftBasicInfoMgt.aspx.cs" Inherits="CraftMgt_CraftBasicInfoMgt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
        <asp:Label ID="Label_Grid1_State" runat="server" Text="默认数据源" Visible="False"></asp:Label>
    <asp:UpdatePanel ID="UpdatePanelUnitSearch" runat="server" 
        UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="PanelUnitSearch" runat="server">
                <fieldset>
                    <legend>用量单位检索</legend>
                    <table style="width:100%">
                        <tr>
                            <td style="width:20%" align="center">
                                <asp:Label ID="Label1" runat="server" Text="用量单位："></asp:Label>
                            </td>
                            <td style="width:30%" align="left">
                                <asp:TextBox ID="TextBoxUnit" runat="server" Width="200px"></asp:TextBox>
                            </td>
                            <td style="width:10%" align="left">  
                                <asp:Button ID="ButtonSearch" runat="server" Text="检索" CssClass="Button02"  Width="70px" 
                                    onclick="ButtonSearch_Click" Height="24px"/>
                            </td>
                            <td style="width:10%" align="left">  
                                <asp:Button ID="ButtonReset" runat="server" Text="重置" CssClass="Button02"   Width="70px"
                                    onclick="ButtonReset_Click" Height="24px"/>
                            </td>
                            <td align="left">
                             <asp:Button ID="ButtonNew" runat="server" Text="新增" CssClass="Button02"  Width="70px"
                                    onclick="ButtonNew_Click" Height="24px"/>   
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    
    <asp:UpdatePanel ID="UpdatePanelUnitNew" runat="server" 
        UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="PanelUnitNew" runat="server" Visible="false">
                <fieldset>
                    <legend>新增用量单位</legend>
                    <table style="width:100%">
                        <tr>
                            <td style="width:20%" align="center">
                                <asp:Label ID="Label2" runat="server" Text="用量单位："></asp:Label>
                            </td>
                            <td style="width:30%" align="left">
                                <asp:TextBox ID="TextBoxNew" runat="server" Width="200px"></asp:TextBox>
                                <asp:Label ID="Label14" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                            <td style="width:10%" align="left">
                                <asp:Button ID="ButtonSubmit" runat="server" Text="提交" CssClass="Button02"  Width="70px"
                                    onclick="ButtonSubmit_Click" Height="24px"/>
                            </td>
                            <td style="width:10%" align="left">
                                <asp:Button ID="ButtonCancel" runat="server" Text="重置" CssClass="Button02"  Width="70px"
                                    onclick="ButtonCancel_Click" Height="24px"/>
                            </td>
                            <td align="left">
                                <asp:Button ID="ButtonClose" runat="server" Text="关闭" CssClass="Button02"  Width="70px"
                                                                    onclick="ButtonClose_Click" Height="24px"/>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    
    <asp:UpdatePanel ID="UpdatePanelList" runat="server" 
        UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="PanelList" runat="server">
                <fieldset>
                    <legend>用量单位列表</legend>
                    <asp:Label ID="Message" ForeColor="Red" runat="server" />
                    <asp:GridView ID="GridViewUnit" runat="server" EnableModelValidation="True" CssClass="GridViewStyle"
                        AutoGenerateColumns="False" AllowPaging="True" Width="100%"  
                        DataKeyNames="UnitID"  GridLines="None"
                        AllowSorting="True" PageSize="50" EmptyDataText="无相关记录!" 
                        onpageindexchanging="GridViewUnit_PageIndexChanging" 
                        onrowcancelingedit="GridViewUnit_RowCancelingEdit" 
                        onrowcommand="GridViewUnit_RowCommand" onrowediting="GridViewUnit_RowEditing" 
                        onrowupdating="GridViewUnit_RowUpdating">
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <Columns>
                        <asp:BoundField DataField="UnitID" Visible="False" />
                        <asp:BoundField HeaderText="用量单位" DataField="UnitName">
                            <ItemStyle Width="10%" />
                            </asp:BoundField>
                            <asp:CommandField ShowEditButton="True" EditText="编辑" CancelText="取消" UpdateText="更新">
                            <ItemStyle Width="10%" />
                            </asp:CommandField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="DeleteUnit" runat="server" CommandArgument='<%# Eval("UnitID") %>'
                                        CommandName="DeleteUnit" OnClientClick="return confirm('您确认删除该记录吗?')">删除</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Width="10%" />
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
                                        <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                            CommandName="Page" Text="GO" />
                                    </td>
                                </tr>
                            </table>
                        </PagerTemplate>
                    </asp:GridView>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>  
</asp:Content>

