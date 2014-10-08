<%@ Page Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true"
    CodeFile="IQCCertificationMgt.aspx.cs" Inherits="IQCMgt_IQCCertificationMgt" %>

    <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
           <asp:Label ID="condSearch" runat="server" Visible="false" ></asp:Label>
    <asp:UpdatePanel ID="UpdatePanel_SearchProType" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_SearchProType" runat="server" >
                <fieldset>
                    <legend>产品型号检索栏</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label1" runat="server" CssClass="STYLE2" Text="产品系列："></asp:Label>
                            </td>
                            <td style="width: 40%" align="left">
                                <asp:TextBox ID="TxtProSeries" runat="server" Width="200px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label10" runat="server" CssClass="STYLE2" Text="产品型号："></asp:Label>
                            </td>
                            <td style="width: 40%" align="left">
                                <asp:TextBox ID="TxtProType" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="width:100%">
                            <td style="width: 10%;" align="right">
                                检索范围：
                            </td>                        
                            <td style="width: 40%;" align="left">
                                <asp:DropDownList ID="Ddl_RZ" runat="server" ToolTip="单击选择" Width="200px">
                                    <asp:ListItem Value="0" Selected="True">认证型号</asp:ListItem>
                                    <asp:ListItem Value="1">非认证型号</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 90%;" align="center">
                        <tr>
                            <td align="right" style="width: 40%">
                                <asp:Button ID="BtnSearchProType" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="BtnSearchProType_Click" Text="检索" Width="70px" />
                            </td>
                            <td style="width: 20%;"></td>
                            <td align="left" style="width: 40%">
                                <asp:Button ID="BtnResetProType" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="BtnResetProType_Click" Text="重置" Width="70px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_GridProType" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_GridProType" runat="server" >
                <fieldset>
                    <legend>
                        <asp:Label ID="LblGridProType" runat="server" CssClass="STYLE2" Text=""></asp:Label>
                    </legend>
                    <asp:GridView ID="Grid_ProType" runat="server" DataKeyNames="PT_ID" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" 
                        Width="100%" Visible="true" GridLines="None"
                        AllowPaging="True" PageSize="10" UseAccessibleHeader="False"
                        OnPageIndexChanging="Grid_ProType_PageIndexChanging"
                        OnRowCommand="Grid_ProType_RowCommand"
                        ondatabound="Grid_ProType_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle  cssclass="GridViewHead"/>
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="PT_ID" HeaderText="产品型号ID" ReadOnly="True" SortExpression="PT_ID" Visible="false">
                            </asp:BoundField>                              
                            <asp:BoundField DataField="PS_Name" SortExpression="PS_Name" HeaderText="产品系列">
                            </asp:BoundField>                
                            <asp:BoundField DataField="PT_Name" SortExpression="PT_Name" HeaderText="产品型号">
                            </asp:BoundField>
                                <asp:BoundField DataField="PT_Note" SortExpression="PT_Note" HeaderText="产品备注">
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnEdt_CFCraft" runat="server" CommandArgument='<%#Eval("PT_ID")%>'
                                        CommandName="Edt_CFCraft" OnClientClick="false">认证工序维护</asp:LinkButton>
                                </ItemTemplate>                               
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnEdt_CFRoute" runat="server" CommandArgument='<%#Eval("PT_ID")%>'
                                        CommandName="Edt_CFRoute" OnClientClick="false">认证工艺路线维护</asp:LinkButton>
                                </ItemTemplate>                               
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnDelete_ProType" runat="server" CommandName="Delete_ProType"
                                        OnClientClick="return confirm('您确认从认证产品型号中中删除该型号吗?')" CommandArgument='<%#Eval("PT_ID")%>'>删除认证型号</asp:LinkButton>
                                </ItemTemplate>                                
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnChoose_ProType" runat="server" CommandArgument='<%#Eval("PT_ID")%>'
                                        CommandName="Chs_ProType" OnClientClick="false" >选择认证型号</asp:LinkButton>
                                </ItemTemplate>                               
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第&nbsp;<asp:Label ID="lblPageIndex" runat="server" align="center" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>' />
                                        页 共&nbsp;<asp:Label ID="lblPageCount" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />
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
    <asp:UpdatePanel ID="UpdatePanel_GridCFCraft" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_GridCFCraft" runat="server" Visible="false" >
                <fieldset>
                    <legend><asp:Label ID="LblRZState" runat="server" Text=""></asp:Label>&nbsp;认证工序表</legend>                    
                                <asp:Button ID="Btn_NewCFCraft" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Btn_NewCFCraft_Click" Text="新增" Width="70px" />
                    <asp:GridView ID="Grid_CFCraft" runat="server" DataKeyNames="PRD_ID" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" 
                        Width="100%" Visible="true" GridLines="None"
                        AllowPaging="True" PageSize="10" UseAccessibleHeader="False"
                        OnPageIndexChanging="Grid_CFCraft_PageIndexChanging"
                        OnRowCommand="Grid_CFCraft_RowCommand"
                        ondatabound="Grid_CFCraft_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle  cssclass="GridViewHead"/>
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="PRD_ID" HeaderText="工艺路线详细表ID" ReadOnly="True" SortExpression="PRD_ID" Visible="false">
                            </asp:BoundField>                
                            <asp:BoundField DataField="PRD_Order" SortExpression="PRD_Order"  HeaderText="工序排序">
                            </asp:BoundField>
                            <asp:BoundField DataField="PBC_Name" SortExpression="PBC_Name"  HeaderText="工序名称">
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnDelete_CFCraft" runat="server" CommandName="Delete_CFCraft"
                                        OnClientClick="return confirm('您确认删除该工序吗?')" CommandArgument='<%#Eval("PRD_ID")%>'>删除认证工序</asp:LinkButton>
                                </ItemTemplate>                                
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第&nbsp;<asp:Label ID="lblPageIndex" runat="server" align="center" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>' />
                                        页 共&nbsp;<asp:Label ID="lblPageCount" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />
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
                        <tr>
                            <td align="right" style="width: 25%">
                            </td>
                            <td align="center" style="width: 10%">
                                <asp:Button ID="Btn_ClsCFCraft" runat="server" CssClass="Button02" 
                                    Height="24px" OnClick="Btn_ClsCFCraft_Click"
                                    Text="关闭" Width="70px" />
                            </td>
                            <td align="left" style="width: 25%">
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_CFRoute" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_CFRoute" runat="server" Visible="false" >
                <fieldset>
                    <legend><asp:Label ID="LblRTState" runat="server" Text=""></asp:Label>&nbsp;认证工艺路线表</legend>
                                <asp:Button ID="Btn_NewCFCFRoute" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Btn_NewCFCFRoute_Click" Text="新增" Width="70px" />
                    <asp:GridView ID="Grid_CFRoute" runat="server" DataKeyNames="PRD_ID" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" 
                        Width="100%" Visible="true" GridLines="None"
                        AllowPaging="True" PageSize="5" UseAccessibleHeader="False"
                        OnPageIndexChanging="Grid_CFRoute_PageIndexChanging"
                        OnRowCommand="Grid_CFRoute_RowCommand"
                        ondatabound="Grid_CFRoute_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle  cssclass="GridViewHead"/>
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="PRD_ID" HeaderText="工艺路线详细表ID" ReadOnly="True" SortExpression="PRD_ID" Visible="false">
                            </asp:BoundField>                
                            <asp:BoundField DataField="PRD_Order" SortExpression="PRD_Order"  HeaderText="工序排序">
                            </asp:BoundField>
                            <asp:BoundField DataField="PBC_Name" SortExpression="PBC_Name"  HeaderText="工序名称">
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnDelete_CFRoute" runat="server" CommandName="Delete_CFRoute"
                                        OnClientClick="return confirm('您确认删除该工序吗?')" CommandArgument='<%#Eval("PRD_ID")%>'>删除认证工艺路线工序</asp:LinkButton>
                                </ItemTemplate>                                
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第&nbsp;<asp:Label ID="lblPageIndex" runat="server" align="center" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>' />
                                        页 共&nbsp;<asp:Label ID="lblPageCount" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />
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
                        <tr>
                            <td align="right" style="width: 25%">
                            </td>
                            <td align="center" style="width: 10%">
                                <asp:Button ID="Btn_ClsCFCFRoute" runat="server" CssClass="Button02" 
                                    Height="24px" OnClick="Btn_ClsCFCFRoute_Click"
                                    Text="关闭" Width="70px" />
                            </td>
                            <td align="left" style="width: 25%">
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_SearchCraft" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_SearchCraft" runat="server" Visible="false">
                <fieldset>
                    <legend><asp:Label ID="LblSCState" runat="server" Text=""></asp:Label>&nbsp;实际工艺路线检索</legend>
                      <asp:Label ID="LblState" runat="server" CssClass="STYLE2" Text="" Visible="false"></asp:Label>
                                <asp:Label ID="LblGongxuState" runat="server" CssClass="STYLE2" Text="" Visible="false"></asp:Label>

                 <%--   <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label4" runat="server" CssClass="STYLE2" Text="工序排序：" ></asp:Label>
                            </td>
                            <td style="width: 40%" align="left">
                                <asp:TextBox ID="TxtOrder" runat="server" Width="155px"></asp:TextBox>
                              
                            </td>
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label5" runat="server" CssClass="STYLE2" Text="工序名称："></asp:Label>
                            </td>
                            <td style="width: 40%" align="left">
                                <asp:TextBox ID="TxtName" runat="server" Width="155px"></asp:TextBox>
                            </td>                            
                        </tr>
                    </table>
                    <table style="width: 90%;" align="center">
                        <tr style="height: 16px;">
                            <td align="right" >
                                <asp:Button ID="Btn_SearchCraft" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Btn_SearchCraft_Click" Text="检索" Width="70px" />
                            </td>
                            <td align="center" >
                                <asp:Button ID="Btn_ResetCraft" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Btn_ResetCraft_Click" Text="重置" Width="70px" />
                            </td>
                            <td align="left" >
                                <asp:Button ID="Btn_ClsCraft" runat="server" CssClass="Button02" Height="24px" 
                                OnClick="Btn_ClsCraft_Click"  Text="关闭" Width="70px" />
                        </tr>
                    </table>--%>
                    <table  style="width: 100%;">
                        <asp:GridView ID="Grid_Craft" runat="server" DataKeyNames="PRD_ID" 
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" 
                        Width="100%" Visible="true" GridLines="None"
                        UseAccessibleHeader="False"
                      
                        ondatabound="Grid_Craft_DataBound" OnRowUpdating="GridView_Craft_Updating"
                        OnRowEditing="GridView_Craft_Editing" 
                        OnRowCancelingEdit="GridView_Craft_CancelingEdit" 
                        onrowdatabound="Grid_Craft_RowDataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle  cssclass="GridViewHead"/>
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="PRD_ID" HeaderText="工艺路线详细表ID" ReadOnly="True" SortExpression="PRD_ID" Visible="false">
                            </asp:BoundField>                
                            <asp:BoundField DataField="PRD_RenZhengOrder" SortExpression="PRD_RenZhengOrder"  HeaderText="认证工序排序">
                            </asp:BoundField>
                            <asp:BoundField DataField="PRD_RouteOrder" SortExpression="PRD_RouteOrder"  HeaderText="认证工艺路线工序排序" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="PRD_Order" SortExpression="PRD_Order"  HeaderText="工序排序" ReadOnly="true">
                            </asp:BoundField>
                            <asp:BoundField DataField="PBC_Name" SortExpression="PBC_Name"  HeaderText="工序名称" ReadOnly="true">
                            </asp:BoundField>
                            <asp:CommandField ShowEditButton="True" EditText="编辑工序" UpdateText="提交" CancelText="取消">
                                <ItemStyle Width="10%" />
                            </asp:CommandField>
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第&nbsp;<asp:Label ID="lblPageIndex" runat="server" align="center" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>' />
                                        页 共&nbsp;<asp:Label ID="lblPageCount" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />
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
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
 </asp:Content>
