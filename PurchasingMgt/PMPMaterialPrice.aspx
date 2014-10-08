<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PMPMaterialPrice.aspx.cs" Inherits="PurchasingMgt_PMPMaterialPrice" MasterPageFile="~/Other/MasterPage.master"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <style type="text/css">
        .hidden
        {
            display: none;
        }
    </style>
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
    <asp:UpdatePanel ID="UpdatePanel_SupplySearch" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_SupplySearch" runat="server" Visible="true">
                <fieldset>
                    <legend>检索条件</legend>
                    <asp:Label ID="labelcodition" runat="server" Visible="false"></asp:Label>
                 <asp:Label ID="label_Title" runat="server" Visible="false"></asp:Label>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 15%" align="right">
                                <asp:Label ID="Label2" runat="server" Text="年份："></asp:Label>
                            </td>
                            <td style="width: 12%; height: 20px;" align="left">
                                <asp:DropDownList ID="DropDownList1" runat="server" Width="130px">
                                </asp:DropDownList>
                            </td>
                            
                            <td style="width: 15%" align="right">
                                <asp:Label ID="Label3" runat="server" Text="月份："></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:DropDownList ID="DropDownList11" runat="server" Width="130px">
                                   
                                </asp:DropDownList>
                            </td>
                            
                        </tr>
                        
                        <tr>
                            
                            <td colspan="2" align="center">
                                <asp:Button ID="Button1" runat="server" Text="检索" CssClass="Button02" Height="24px"
                                    OnClick="Button_Sh1" Width="70px" />
                            </td>
                            <%--<td width="10%" align="right">
                 <asp:Button ID="Button21" runat="server" Text="采购订单" CssClass="Button02" Height="24px"
                                    OnClick="Button_Ring" Width="90px" />
                            </td>--%>
                            <td style="width: 15%" align="center" colspan="3">
                                <asp:Button ID="Button2" runat="server" Text="重置" CssClass="Button02" Height="24px"
                                    OnClick="Button_Reset" Visible="true" Width="70px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdatePanelApplyDetailSummary" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="PanelApplyDetailSummary" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="label12" runat="server" Visible="true" Text="当月计划内的物料"></asp:Label>
                    </legend>
                    <asp:Label ID="label_IMMBD_MaterialID" runat="server" Visible="true" ForeColor="Red"></asp:Label>
               
                    <asp:GridView ID="Gridview1" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle"
                        CellPadding="0" UseAccessibleHeader="False" Font-Strikeout="False" GridLines="None" PageSize="10"
                      
                        AllowPaging="True" AllowSorting="True" DataKeyNames="IMMBD_MaterialID"
                        OnPageIndexChanging="Gridview1_PageIndexChanging" Width="100%" EnableModelValidation="True"
                       >
                        <%--    //隔行变色--%>
                        <AlternatingRowStyle />
                        <PagerStyle ForeColor="Black" HorizontalAlign="Center" CssClass="GridViewPagerStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <Columns>
                            <asp:BoundField DataField="IMMBD_MaterialID" HeaderText="物料ID" SortExpression="IMMBD_MaterialID"
                                Visible="False" />
                          <asp:BoundField DataField="IMMBD_MaterialName" HeaderText="物料名称" ReadOnly="True"
                                SortExpression="IMMBD_MaterialName" />
                             <asp:BoundField DataField="IMMBD_MaterialCode" HeaderText="物料编码" ReadOnly="True"
                                SortExpression="IMMBD_MaterialCode" />
                            <asp:BoundField DataField="IMMBD_SpecificationModel" HeaderText="规格型号" ReadOnly="True"
                                SortExpression="IMMBD_SpecificationModel" />
                            
                            <asp:BoundField DataField="IMMBD_Price" HeaderText="物料价格" ReadOnly="True" SortExpression="IMMBD_Price" />
                            <asp:BoundField DataField="UnitName" HeaderText="单位" ReadOnly="True" SortExpression="UnitName" />
                            <asp:TemplateField  HeaderText="物料价格录入" HeaderStyle-Font-Bold="true" Visible="true">
                                <ItemTemplate>
                                   <asp:TextBox ID="TextBox3" runat="server" Width="80px" Text='<%#Eval("IMMBD_Price")%>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:BoundField DataField="IMUC_ID" HeaderText="物料单位ID">
                                <FooterStyle CssClass="hidden" />
                                <HeaderStyle CssClass="hidden" />
                                <ItemStyle CssClass="hidden" />
                            </asp:BoundField>
                            <asp:CommandField ShowEditButton="True" EditText="单价" UpdateText="确定" CancelText="取消">
                                <ItemStyle Width="10%" />
                            </asp:CommandField>--%>
                        </Columns>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label50" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <PagerStyle CssClass="GridViewPagerStyle" />
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
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                    </asp:GridView>
                    <table width="100%">
                        <tr>
                            <td width="40%" align="right">
                                <asp:Button ID="Button13" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    OnClick="Button_Com2" Width="70px" />
                            </td>
                            <td style="width: 20%" align="center">
                                &nbsp;
                            </td>
                            <td width="30%" align="left">
                                &nbsp;&nbsp;
                                <asp:Button ID="Button14" runat="server" Text="重置" CssClass="Button02" Height="24px"
                                    OnClick="Button_Cancel2" Width="70px" />
                            </td>
                            <td style="width: 100%">
                            </td>
                            <td style="width: 100%">
                            </td>
                        </tr>
                        </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

   </asp:Content>
