<%@ Page Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true"
    CodeFile="HSFMaterialCIMgt.aspx.cs" Inherits="HSFMgt_HSFMaterialCIMgt" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel_SearchMaterial" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_SearchMaterial" runat="server">
                <fieldset>
                    <legend>物料检索栏</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 5%" align="center">
                                <asp:Label ID="Label7" runat="server" CssClass="STYLE2" Text="物料类型"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtMaType" runat="server" Width="155px"></asp:TextBox>
                            </td>
                            <td style="width: 5%" align="center">
                                <asp:Label ID="Label1" runat="server" CssClass="STYLE2" Text="物料名称"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtMaName" runat="server" Width="155px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td  >
                            </td>
                            <td  align="center">
                            <asp:Button ID="BtnSearchMa" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="BtnSearchMa_Click" Text="检索" Width="80px" />
                            </td>
                            <td  >
                                
                            </td>
                            <td align="left" >
                                <asp:Button ID="BtnResetMa" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="BtnResetMa_Click" Text="重置" Visible="true" Width="80px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_GridMa" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_GridMa" runat="server" >
                <fieldset>
                    <legend>物料列表</legend>
                    <asp:GridView ID="Grid_Material" runat="server" DataKeyNames="IMMBD_MaterialID" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" 
                        Width="100%" Visible="true" GridLines="None"
                        AllowPaging="True" PageSize="10" UseAccessibleHeader="False"
                        OnPageIndexChanging="Grid_Material_PageIndexChanging"
                        OnRowCommand="Grid_Material_RowCommand" 
                        EnableViewState="False" 
                        ondatabound="Grid_Material_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle  cssclass="GridViewHead"/>
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <%--<PagerStyle CssClass="GridViewPagerStyle" />--%>
                        <Columns>
                            <asp:BoundField DataField="IMMBD_MaterialID" HeaderText="物料ID" ReadOnly="True" SortExpression="IMMBD_MaterialID"
                                Visible="false">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>                         
                            <asp:BoundField DataField="IMMT_MaterialType" SortExpression="IMMT_MaterialType" HeaderText="物料类型">
                                <HeaderStyle Width="30%" />
                                <ItemStyle Width="30%" />
                            </asp:BoundField>                      
                            <asp:BoundField DataField="IMMBD_MaterialName" SortExpression="IMMBD_MaterialName" HeaderText="物料名称">
                                <HeaderStyle Width="30%" />
                                <ItemStyle Width="30%" />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnEdit_Items" runat="server" CommandArgument='<%#Eval("IMMBD_MaterialID")%>'
                                        CommandName="Edt_Items" OnClientClick="false">管制项目维护</asp:LinkButton>
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
    <asp:UpdatePanel ID="UpdatePanel_SearchCI" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_SearchCI" runat="server" Visible="false">
                <fieldset>
                    <legend>管制项目检索栏</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 7%" align="center">
                                <asp:Label ID="Label8" runat="server" CssClass="STYLE2" Text="项目名称"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtItemName" runat="server" Width="200px"></asp:TextBox>
                            </td>
                            <td style="width: 7%" align="center">
                                <asp:Label ID="Label9" runat="server" CssClass="STYLE2" Text="管制对象范围"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtStandard" runat="server" Width="200px"></asp:TextBox>
                                <asp:Label ID="LblSearchCond" runat="server" CssClass="STYLE2" Text="" Visible="false"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%;">
                        <tr>
                            <td align="right" style="width: 25%">
                                <asp:Button ID="BtnSearchItem" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="BtnSearchItem_Click" Text="检索项目" Width="80px" />
                            </td>
                            <td align="right" style="width: 25%">
                                <asp:Button ID="BtnSearchAll" runat="server" CssClass="Button02" Height="24px" OnClick="BtnSearchAll_Click"
                                    Text="检索所有" Width="80px" />
                            </td>
                            <td align="right" style="width: 25%">
                                <asp:Button ID="BtnResetItem" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="BtnResetItem_Click" Text="重置" Visible="true" Width="80px" />
                            </td>
                            <td align="right" style="width: 25%">
                                <asp:Button ID="BtnCls_Item" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="BtnCls_Item_Click" Text="取消" Visible="true" Width="80px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_GridItem" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_GridItem" runat="server" >
                <fieldset>
                    <legend>
                        <asp:Label ID="LblGridItem" runat="server" CssClass="STYLE2" Text=""></asp:Label>
                    </legend>
                    <asp:GridView ID="Grid_Item" runat="server" DataKeyNames="HSFCI_ItemID" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" 
                        Width="100%" Visible="true" GridLines="None"
                        AllowPaging="True" PageSize="10" UseAccessibleHeader="False"
                        OnPageIndexChanging="Grid_Item_PageIndexChanging"
                        OnRowCommand="Grid_Item_RowCommand"
                        ondatabound="Grid_Item_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle  cssclass="GridViewHead"/>
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <%--<PagerStyle CssClass="GridViewPagerStyle" />--%>
                        <Columns>
                            <asp:BoundField DataField="HSFCI_ItemID" HeaderText="管制项目ID" ReadOnly="True" SortExpression="HSFCI_ItemID"
                                Visible="false">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>                              
                            <asp:BoundField DataField="IMMBD_MaterialName" SortExpression="IMMBD_MaterialName" HeaderText="物料名称">
                                <HeaderStyle Width="10%" />
                                <ItemStyle Width="10%" />
                            </asp:BoundField>                
                            <asp:BoundField DataField="HSFCI_ItemName" SortExpression="HSFCI_ItemName" HeaderText="项目名称">
                                <HeaderStyle Width="10%" />
                                <ItemStyle Width="10%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="HSFCI_Standard" SortExpression="HSFCI_Standard" HeaderText="管制标准">
                                <HeaderStyle Width="20%" />
                                <ItemStyle Width="20%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="HSFCI_Boundary" SortExpression="HSFCI_Boundary" HeaderText="管制对象范围">
                                <HeaderStyle Width="15%" />
                                <ItemStyle Width="15%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="HSFCI_Period" SortExpression="HSFCI_Period" HeaderText="管制周期">
                                <HeaderStyle Width="10%" />
                                <ItemStyle Width="10%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="HSFCI_RemindDay" SortExpression="HSFCI_RemindDay" HeaderText="提前报警时限">
                                <HeaderStyle Width="10%" />
                                <ItemStyle Width="10%" />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnDelete_Item" runat="server" CommandName="Delete_Item"
                                        OnClientClick="false" CommandArgument='<%#Eval("HSFCI_ItemID")%>'>删除</asp:LinkButton>
                                </ItemTemplate>                                
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnChoose_Item" runat="server" CommandArgument='<%#Eval("HSFCI_ItemID")%>'
                                        CommandName="Chs_Item" OnClientClick="false">选择</asp:LinkButton>
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
    
 </asp:Content>