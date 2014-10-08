<%@ Page Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true" CodeFile="OverTimeOption.aspx.cs" 
Inherits="ProductionBasicInfo_OverTimeOption" Title="超时原因选项维护"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
        <asp:Label ID="Label_Grid1_State" runat="server" Text="默认数据源" Visible="False"></asp:Label>
    <asp:UpdatePanel ID="UpdatePanelOverTimeSearch" runat="server" 
        UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="PanelOverTimeSearch" runat="server">
                <fieldset>
                    <legend>超时原因选项检索</legend>
                    <table style="width:100%">
                        <tr style="width: 100%;">
                            <td style="width:15%" align="center">
                                <asp:Label ID="Label1" runat="server" Text="超时原因选项："></asp:Label>
                            </td>
                            <td style="width:30%" align="left">
                                <asp:TextBox ID="TextBoxOverTime" runat="server" Width="200px"></asp:TextBox>
                            </td>
                            <td style="width:15%" align="center">
                                <asp:Button ID="ButtonSearch" runat="server" Text="检索" CssClass="Button02"  Width="70px"
                                    onclick="ButtonSearch_Click" />
                            </td>
                            <td style="width:15%" align="center">
                                <asp:Button ID="ButtonReset" runat="server" Text="重置" CssClass="Button02"  Width="70px"
                                    onclick="ButtonReset_Click" />
                            </td>
                             <td style="width:15%" align="center">
                                <asp:Button ID="ButtonNew" runat="server" Text="新增超时原因" CssClass="Button02"
                                    onclick="ButtonNew_Click" Width="90px" />
                            </td>
                            <td></td>
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
                    <legend>超时原因选项列表</legend>
                    <asp:Label ID="Message" ForeColor="Red" runat="server" Visible="false"/>
                    <asp:GridView ID="GridViewOverTime" runat="server" EnableModelValidation="True" CssClass="GridViewStyle"
                        onpageindexchanging="GridViewOverTime_PageIndexChanging" GridLines="None" 
                        AutoGenerateColumns="False" AllowPaging="True" Width="100%" 
                        onrowcancelingedit="GridViewOverTime_RowCancelingEdit" 
                        onrowediting="GridViewOverTime_RowEditing"  
                        onrowupdating="GridViewOverTime_RowUpdating" DataKeyNames="OTO_ID" 
                        onrowcommand="GridViewOverTime_RowCommand" AllowSorting="True" 
                        PageSize="5" EmptyDataText="无相关记录!">
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                        <asp:BoundField DataField="OTO_ID" Visible="False" />
                        <asp:BoundField HeaderText="超时原因选项" DataField="OTO_Name">
                            <ItemStyle/>
                            </asp:BoundField>
                            <asp:CommandField ShowEditButton="True">
                            <ItemStyle/>
                            </asp:CommandField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="DeleteOTO" runat="server" CommandArgument='<%# Eval("OTO_ID") %>'
                                        CommandName="DeleteOTO" OnClientClick="return confirm('您确认删除该记录吗?')">删除</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle/>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Check_Detail" runat="server" CommandArgument='<%# Eval("OTO_ID")+","+Eval("OTO_Name") %>'
                                        CommandName="Check_Detail">查看详细项目</asp:LinkButton>
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

    <asp:UpdatePanel ID="UpdatePanelOverTimeNew" runat="server"  UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="PanelOverTimeNew" runat="server" Visible="false">
                <fieldset>
                    <legend>超时原因选项新增</legend>
                    <table style="width:100%">
                        <tr>
                            <td style="width:15%" align="center">
                                <asp:Label ID="Label2" runat="server" Text="超时原因选项："></asp:Label>
                            </td>
                            <td style="width:30%" align="left">
                                <asp:TextBox ID="TextBoxNew" runat="server" Width="200px"></asp:TextBox>
                                <asp:Label ID="Label14" runat="server" Text="*" ForeColor="Red"></asp:Label>

                            </td>
                            <td style="width:15%" align="center">
                                <asp:Button ID="ButtonSubmit" runat="server" Text="提交" CssClass="Button02"  Width="70px"
                                    onclick="ButtonSubmit_Click" />
                             </td>
                            <td style="width:15%" align="center">
                                <asp:Button ID="ButtonCancel" runat="server" Text="重置" CssClass="Button02"  Width="70px"
                                    onclick="ButtonCancel_Click" />
                            </td>
                            <td style="width:15%" align="center">
                                <asp:Button ID="ButtonClose" runat="server" Text="关闭" CssClass="Button02"  Width="70px"
                                    onclick="ButtonClose_Click"/>
                            </td>
                            <td></td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    
<asp:UpdatePanel ID="UpdatePanel_Parameter" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Parameter" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="Label_PTP" runat="server"></asp:Label>超时原因选项详细
                        <asp:Label ID="Label3" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 183px">
                                检索工序所属超时选项详细项目：
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:Label ID="Label17" runat="server" Text="Label" Visible="False"></asp:Label>
                                <asp:Label ID="Label4" runat="server" Text="Label" Visible="False"></asp:Label>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <asp:Button ID="Btn_Close_Parameter0" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Btn_Close_Parameter0_Click" Text="新增超时原因详细" Width="130px" />
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView_Parameter" runat="server" AutoGenerateColumns="false"
                        Font-Strikeout="False" GridLines="None" CssClass="GridViewStyle" PageSize="10"
                        CellPadding="0" UseAccessibleHeader="False" AllowPaging="True" OnRowCommand="GridView_Parameter_RowCommand"
                        OnPageIndexChanging="GridView_Parameter_PageIndexChanging" AllowSorting="True"
                        Width="100%" DataKeyNames="OTOD_ID" EmptyDataText="无相关记录!" OnDataBound="GridView_Parameter_DataBound"
                        OnRowCancelingEdit="GridView_Parameter_RowCancelingEdit" OnRowEditing="GridView_Parameter_RowEditing"
                        OnRowUpdating="GridView_Parameter_RowUpdating">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="OTOD_ID" HeaderText="超时原因选项详细项目ID" SortExpression="OTOD_ID"
                                Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="OTOD_Name" SortExpression="OTOD_Name" HeaderText="超时原因选项详细项目">
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="所在工序">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lbl1" Text='<%#Eval("PBC_Name") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddl1" runat="server" DataSource='<%#GetDs2() %>' DataTextField="PBC_Name"
                                        DataValueField="PBC_ID">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ShowEditButton="True" EditText="编辑" UpdateText="更新" CancelText="关闭">
                            </asp:CommandField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="delete1" runat="server" CommandArgument='<%# Eval("OTOD_ID")+","+Eval("OTOD_Name") %>'
                                        OnClientClick="return confirm('您确认删除该记录吗?')" CommandName="delete1">删除</asp:LinkButton>
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
                    <table width="100%">
                        <tr>
                            <td align="center">
                                <asp:Button ID="Btn_Close_Parameter" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Btn_Close_Parameter_Click" Text="关闭" Width="70px" />
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
                    <legend>超时原因详细项目新增</legend>
                    <table style="width: 100%;">
                        <tr style="width: 100%;">
                            <td style="width: 15%;">
                                详细项目名称：
                            </td>
                            <td style="width: 25%;">
                                <asp:TextBox ID="txt_PS" runat="server" Width="90%" MaxLength="30"></asp:TextBox>
                            <asp:Label ID="Label9" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                            <td style="width: 10%;">
                                所在工序：
                            </td>
                            <td style="width: 15%;">
                                <asp:DropDownList ID="DropDownList2" runat="server">
                                </asp:DropDownList>
                                <asp:Label ID="Label5" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                            <td style="width: 12%;" align="center">
                                <asp:Button ID="Btn_Submit" runat="server" Text="提交" Width="70px" Height="24px" CssClass="Button02"
                                    OnClick="Btn_Submit_Click" />
                            </td>
                            <td style="width: 12%;" align="center">
                                <asp:Button ID="Btn_Cancel" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_Cancel_Click"
                                    Text="重置" Width="70px" />
                            </td>
                            <td align="center">
                                <asp:Button ID="Btn_Close_PS" runat="server" CssClass="Button02" Height="24px" OnClick="Button_Close_PSSearch_Click"
                                    Text="关闭" Width="70px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>



</asp:Content>

