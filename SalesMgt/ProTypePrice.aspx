<%@ Page Title="" Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true"
    CodeFile="ProTypePrice.aspx.cs" Inherits="SalesMgt_ProTypePrice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel_Search" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Search" runat="server" Visible="true">
                <asp:Label ID="Label_Grid1_Color" runat="server" Visible="false"></asp:Label>    
                <fieldset>
                    <legend>产品查询</legend>
                    <table style="width: 100%;">
                        <tr style="width: 100%;">
                            <td style="width: 11%;">
                                产品型号：
                            </td>
                            <td style="width: 14%;" align="left">
                                <asp:TextBox ID="Txt_search" runat="server" Width="100px"></asp:TextBox>
                            </td>
                            <td style="width: 8%;">
                                产品备注：
                            </td>
                            <td style="width: 16%;" align="left">
                                <asp:TextBox ID="Txt_search0" runat="server" Width="100px"></asp:TextBox>
                            </td>
                            <td style="width: 9%;" align="center">
                                产品编码：
                            </td>
                            <td style="width: 16%;" align="left">
                                <asp:TextBox ID="TextBox1" runat="server" Width="100px"></asp:TextBox>
                            </td>
                      
                        </tr>
               
                    </table>
                    <table>
                        <tr style="width: 100%;">
                            <td style="width: 8%;">
                            </td>
                            <td style="width: 11%;">
                            </td>
                            <td style="width: 8%;">
                            </td>
                            <td align="center" style="width: 18%;">
                                <asp:Button ID="Btn_Search" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_Search_Click"
                                    Text="检索" Width="70px" />
                            </td>
                            <td align="center" style="width: 7%;">
                                <asp:Button ID="Button_Cancel" runat="server" CssClass="Button02" Height="24px" OnClick="Button_Cancel_Click"
                                    Text="重置" Width="70px" />
                            </td>
                            <td align="center" style="width: 35%;">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_PT" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_PT" runat="server">
                <fieldset>
                    <legend>产品型号表</legend>
          
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        Font-Strikeout="False" GridLines="None" PageSize="5" CellPadding="0" UseAccessibleHeader="False"
                        AllowPaging="True" OnRowCommand="GridView2_RowCommand" OnPageIndexChanging="GridView2_PageIndexChanging"
                        AllowSorting="True" Width="100%" DataKeyNames="PT_ID"
                        EmptyDataText="无相关记录!" OnDataBound="GridView2_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="PT_ID" HeaderText="产品型号ID" SortExpression="PT_ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="PS_ID" HeaderText="产品系列ID" SortExpression="PS_ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="PT_Name" SortExpression="PT_Name" HeaderText="产品型号"></asp:BoundField>
                            <asp:BoundField DataField="PT_Note" SortExpression="PT_Note" HeaderText="产品备注"></asp:BoundField>
                            <asp:BoundField DataField="PT_Price" HeaderText="产品单价" SortExpression="PT_Price">
                            </asp:BoundField>
                              <asp:BoundField DataField="PT_PriceMan" HeaderText="单价录入人" SortExpression="PT_PriceMan">
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Edit123" runat="server" CommandArgument='<%# Eval("PT_ID")%>'
                                        CommandName="Edit123">编辑</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LookH" runat="server" CommandArgument='<%# Eval("PT_ID")%>'
                                        CommandName="LookH">查看修改历史</asp:LinkButton>
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
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
   
    <asp:UpdatePanel ID="UpdatePanel_basic" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_basic" runat="server" Visible="false">
                <fieldset>
                    <legend>

                        <asp:Label ID="Label_WOID" runat="server" Visible="true"></asp:Label>
                        &nbsp;产品底价修改记录 </legend>
                    <asp:Label ID="Label_Material" runat="server"  Visible="false"></asp:Label>
                    <asp:GridView ID="GridView_bom" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        CellPadding="0" UseAccessibleHeader="False" AllowSorting="True" Width="100%"
                        DataKeyNames="SMPTP_ID" EmptyDataText="无相关记录!" GridLines="None" >
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="SMPTP_ID" SortExpression="SMPTP_ID" HeaderText="BOM详细ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="SMPTP_NowPrice" SortExpression="SMPTP_NowPrice" HeaderText="修改价格"
                                Visible="true"></asp:BoundField>
                            <asp:BoundField DataField="SMPTP_Man" SortExpression="SMPTP_Man"
                                HeaderText="修改人"></asp:BoundField>
                            
                            <asp:BoundField DataField="SMPTP_Time" SortExpression="SMPTP_Time" HeaderText="时间"></asp:BoundField>
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
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_CheckParameter" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_CheckParameter" runat="server" Visible="false">
                <fieldset>
                    <legend>修改<asp:Label ID="Labelc" runat="server" Visible="true"></asp:Label>产品低价
                        <asp:Label ID="Label2" runat="server" Visible="False"></asp:Label>
                    </legend>
                 <table style="width:100%">
                        <tr style="width: 100%;">
                            <td style="width: 25%" align="right">
                                请输入<asp:Label ID="Label1" runat="server" Visible="true"></asp:Label>的底价:
                            </td>
                            <td style="width: 50%" align="center">
                                <asp:TextBox ID="Txt_parameter" runat="server" onkeyup="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{4,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{4})[0-9]*/, '$1');" 
                              onafterpaste="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{4,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{4})[0-9]*/, '$1');"></asp:TextBox>
                            </td>
                          <td style="width: 25%" align="left">
                                 <asp:Button ID="Btn_I_parameter" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Btn_I_parameter_Click" Text="提交" Width="70px" />
                              &nbsp;&nbsp;
                               <asp:Button ID="Btn_Close_CheckParameter" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_Close_CheckParameter_Click" Text="关闭" Width="70px" />
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
