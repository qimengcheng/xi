<%@ Page Title="" Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true" CodeFile="PaymentBill.aspx.cs" Inherits="Laputa_PaymentBill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server">
                <fieldset>
                    <legend>开票检索
             
                
                    </legend>
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 88px" >供应商名称：</td>
                            <td style="width: 148px" >
                                <asp:TextBox ID="TextBox1" runat="server" Width="90%"></asp:TextBox>
                            </td>
                            <td style="width: 89px" >
                                待开票金额：</td>
                            <td style="width: 159px" >
                                <asp:TextBox ID="TextBox2" runat="server" Width="90%"></asp:TextBox>
                            </td>
                            <td >&nbsp;</td>
                            <td >
                                <asp:Label ID="Maxnum" runat="server" Text="Maxnum" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 88px" >&nbsp;</td>
                            <td style="width: 148px">
                                &nbsp;</td>
                            <td style="width: 89px" >
                                <asp:Button ID="Search" runat="server" CssClass="Button02" OnClick="Search_Click" Text="检索" Width="66px" />
                            </td>
                            <td style="width: 159px">
                                &nbsp;</td>
                            <td >
                                <asp:Button ID="Search0" runat="server" CssClass="Button02" OnClick="Search_Click" Text="重置" Width="60px" />
                                <asp:Label ID="PID" runat="server" Text="PID" Visible="False"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="PMBID" runat="server" Text="PMBID" Visible="False"></asp:Label>
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
                    <legend>供应商开票信息</legend>
                    <asp:GridView ID="GridView1" runat="server" CssClass="GridViewStyle"  AllowPaging="True" PageSize="10" AutoGenerateColumns="False"
                                  GridLines="None" EmptyDataText=" 没有相关记录 " OnRowCommand="GridView1_RowCommand"  
                                  DataKeyNames=""  OnPageIndexChanging="GridView1_PageIndexChanging" EnableModelValidation="True">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="PMSI_ID" HeaderText="PMSI_ID" Visible="False"  />
                            <asp:BoundField DataField="PMSI_SupplyName" HeaderText="供应商" Visible="True"  />
                            
                            <asp:BoundField DataField="MoneyToBill" HeaderText="总开票" Visible="true"  />
                            <asp:BoundField DataField="Billed" HeaderText="已开票" Visible="true"  />
                            <asp:BoundField DataField="NeedToBill" HeaderText="还需开票" Visible="true"  />


                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Auto" runat="server" CommandArgument='<%# Eval("PMSI_ID") %>' CommandName="Auto">自动开票</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                            
                            
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Details" runat="server" CommandArgument='<%# Eval("PMSI_ID") %>' CommandName="Details">查看发票</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                           
                           <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="NotBill" runat="server" CommandArgument='<%# Eval("PMSI_ID") %>' CommandName="NotBill">查看未开票采购单详细</asp:LinkButton>
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
                    <table style="text-align: left; width: 100%;">
          
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
 
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel3" runat="server" Visible="False">
                <fieldset>
                    <legend>自动开票
                    </legend>
                    <table style="text-align: left; width: 100%;">
                        <tr>
                            <td style="height: 21px; width: 55px;" >开票金额:</td>
                            <td style="height: 21px; width: 15%;">
                                <asp:TextBox ID="TextBox13" runat="server"   onkeyup="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{3,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{3})[0-9]*/, '$1');" 
                                             onafterpaste="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{3,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{3})[0-9]*/, '$1');" 
                                             Width="100%"></asp:TextBox>
                            </td>
                            <td style="height: 21px; width: 42px" >
                                (元)<asp:Label ID="Label535" runat="server" ForeColor="red" Text="*"></asp:Label>
                            </td>
                            <td style="height: 21px; width: 42px">发票号:</td>
                            <td style="height: 21px; width: 20%;">
                                <asp:TextBox ID="TextBox17" runat="server" Width="100%"></asp:TextBox>
                            </td>
                            <td style="height: 21px; width: 88px;" >
                                <asp:Label ID="Label536" runat="server" ForeColor="red" Text="*"></asp:Label>
                                选择时间段:</td>
                            <td style="height: 21px; width: 252px;">
                                             <asp:TextBox ID="TextBox4" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D' ,true)"
                                    DataFormatString="{0:yyyy-MM-dd}" Width="90%"></asp:TextBox>

                            </td>
                            <td style="height: 21px; width: 30px;">到</td>
                            <td style="height: 21px; width: 248px;">
                                    <asp:TextBox ID="TextBox9" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D' ,true)"
                                    DataFormatString="{0:yyyy-MM-dd}" Width="90%"></asp:TextBox>

                            </td>
                            <td style="height: 21px; width: 15px;">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 55px">备注:</td>
                            <td colspan="9">
                                <asp:TextBox ID="TextBox16" runat="server" Height="100px" Width="90%" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 55px">&nbsp;</td>
                            <td style="width: 15%">&nbsp;</td>
                            <td style="width: 42px">&nbsp;</td>
                            <td style="width: 42px">&nbsp;</td>
                            <td style="width: 20%">
                                <asp:Button ID="Auto_Bingo" runat="server" CssClass="Button02" OnClick="Auto_Bingo_Click" Text="自动开票" />
                            </td>
                            <td style="width: 88px">
                                <asp:Button ID="CloseAuto" runat="server" CssClass="Button02" OnClick="CloseAuto_Click" Text="关闭" Width="63px" />
                            </td>
                            <td style="width: 252px">&nbsp;</td>
                            <td style="width: 30px">&nbsp;</td>
                            <td style="width: 248px">&nbsp;</td>
                            <td style="width: 15%">&nbsp;</td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel4" runat="server" Visible="False">
                <fieldset>
                    <legend>供应商已开发票信息</legend>
                    <asp:GridView ID="GridView2" runat="server" CssClass="GridViewStyle"  AllowPaging="True" PageSize="10" AutoGenerateColumns="False"
                                  GridLines="None" EmptyDataText=" 没有相关记录 " OnRowCommand="GridView2_RowCommand"  
                                  DataKeyNames="PMB_ID"  OnPageIndexChanging="GridView2_PageIndexChanging" EnableModelValidation="True">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="PMB_ID" HeaderText="PMB_ID" Visible="False"  />
                            <asp:BoundField DataField="PMSI_SupplyName" HeaderText="供应商" Visible="True"  />
                            
                            <asp:BoundField DataField="PMB_TotalBill" HeaderText="开票金额" Visible="true"  />
                            <asp:BoundField DataField="PMB_BillNum" HeaderText="发票号码" Visible="true"  />
                            <asp:BoundField DataField="PMB_Note" HeaderText="备注" Visible="true"  />
                            <asp:BoundField DataField="PMB_ManName" HeaderText="开票人" Visible="true"  />
                            <asp:BoundField DataField="PMB_BillDate"  DataFormatString="{0:yyyy-MM-dd }" HeaderText="开票日期" Visible="true"  />


                            
                            
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Details" runat="server" CommandArgument='<%# Eval("PMB_ID") %>' CommandName="Details">查看相关采购信息</asp:LinkButton>
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
                    <table style="text-align: left; width: 100%;">
          
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
      <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel5" runat="server" Visible="False">
                <fieldset>
                    <legend>发票包含的采购单信息</legend>
                    <asp:GridView ID="GridView3" runat="server" CssClass="GridViewStyle"  AllowPaging="True" PageSize="10" AutoGenerateColumns="False"
                                  GridLines="None" EmptyDataText=" 没有相关记录 "  
                                  DataKeyNames="PMB_ID"  OnPageIndexChanging="GridView3_PageIndexChanging" EnableModelValidation="True">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="PMB_ID" HeaderText="PMB_ID" Visible="False"  />
                            <asp:BoundField DataField="PMSI_SupplyName" HeaderText="供应商" Visible="True"  />
                            <asp:BoundField DataField="PMPO_PurchaseOrderNum" HeaderText="采购单号" Visible="True"  />
                            <asp:BoundField DataField="IMMBD_MaterialName" HeaderText="采购物料名称" Visible="True"  />
                             <asp:BoundField DataField="IMMBD_SpecificationModel" HeaderText="采购物料型号" Visible="True"  />
                            <asp:BoundField DataField="BillAmount" HeaderText="开票金额" Visible="true"  />
                            <asp:BoundField DataField="PMB_BillNum" HeaderText="发票号码" Visible="true"  />
                          <asp:BoundField DataField="ToBill" HeaderText="应开发票" Visible="true"  />
                            <asp:BoundField DataField="PMPOD_BilledMoney" HeaderText=" 已开发票" Visible="true"  />

                          
                            
                            
                           <%-- <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Details" runat="server" CommandArgument='<%# Eval("PMBD_ID") %>' CommandName="Details">查看相关发票</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                           
                           
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
                    <table style="text-align: left; width: 100%;">
          
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel6" runat="server" Visible="False">
                <fieldset>
                    <legend>采购单</legend>
                    <asp:GridView ID="GridView4" runat="server" CssClass="GridViewStyle"  AllowPaging="True" AutoGenerateColumns="False"
                                  GridLines="None" EmptyDataText=" 没有相关记录 " OnRowCommand="GridView4_RowCommand"  
                                  DataKeyNames="PMPOD_PurchaseDetailID"  OnPageIndexChanging="GridView4_PageIndexChanging" EnableModelValidation="True" OnRowDataBound="GridView4_RowDataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="PMPOD_PurchaseDetailID" HeaderText="PMPOD_PurchaseDetailID" Visible="False"  />
                            <asp:BoundField DataField="PMSI_SupplyName" HeaderText="供应商" Visible="True"  />
                            <asp:BoundField DataField="PMPO_PurchaseOrderNum" HeaderText="采购单号" Visible="True"  />
                            <asp:BoundField DataField="PMPOD_MakeTime" DataFormatString="{0:yyyy-MM-dd HH:mm}"  HeaderText="采购时间" />
                            <asp:BoundField DataField="IMMBD_MaterialName" HeaderText="采购物料名称" Visible="True"  />
                             <asp:BoundField DataField="IMMBD_SpecificationModel" HeaderText="采购物料型号" Visible="True"  />
                            <asp:BoundField DataField="PMPOD_Num" HeaderText="数量" Visible="true"  />
                            <asp:BoundField DataField="PMPOD_Price" HeaderText="单价" Visible="true"  />
                           <asp:BoundField DataField="PMPOD_ActuallNum" HeaderText="实到数量" Visible="true"  />

                          
                            
                            
                           
                           
                           
                            <asp:BoundField DataField="ToBill" HeaderText="应开票" />
                            <asp:BoundField DataField="PMPOD_BilledMoney" HeaderText="已开票" />
                            <asp:BoundField DataField="PMPOD_IsNormal" HeaderText="是否开票" />
                           
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="swi" runat="server" CommandArgument='<%# Eval("PMPOD_PurchaseDetailID") %>' CommandName="swi">设为暂不开票</asp:LinkButton>
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
                    <table style="text-align: left; width: 100%;">
          
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>