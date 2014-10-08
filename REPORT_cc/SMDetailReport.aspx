<%@ Page Title="客户明细账" Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true" CodeFile="SMDetailReport.aspx.cs" Inherits="REPORT_cc_SMDetailReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script language="javascript" type="text/javascript">
    </script>

    <asp:UpdatePanel ID="UpdatePanel_Search" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Search" runat="server">
                <fieldset>
                    <legend>客户明细账检索栏</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 10%; height: 15px;" align="center">
                            </td>
                            <td style="width: 10%; height: 15px;" align="center">
                                <asp:Label ID="Label1" runat="server" Text="客户名称："></asp:Label>
                            </td>
                            <td colspan="3" style="width: 60%; height: 15px;">
                                <asp:TextBox ID="TextBox1" runat="server" Width="500px"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%; height: 15px;" align="center">
                            </td>
                            <td style="width: 10%" align="center">
                                    <asp:Label ID="Label111" runat="server" Text="发货时间："></asp:Label>
                                </td>
                                </td>
                                <td style="width: 20%; height: 15px;" >
                                    <asp:TextBox ID="TextBox2" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',false)"
                                        DataFormatString="{0:yyyy-MM-dd}" Width="155px"></asp:TextBox>
                                </td>
                                <td align="center" style="width: 5%">
                                    <asp:Label ID="Label112" runat="server" Text="至"></asp:Label>
                                </td>
                                <td >
                                    <asp:TextBox ID="TextBox3" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',false)"
                                        DataFormatString="{0:yyyy-MM-dd}" Width="155px"></asp:TextBox>
                                </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%; height: 15px;" align="center">
                            </td>
                            <td style="width: 10%" align="center">
                                    <asp:Label ID="Label5" runat="server" Text="回款时间："></asp:Label>
                                </td>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox4" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',false)"
                                        DataFormatString="{0:yyyy-MM-dd}" Width="155px"></asp:TextBox>
                                </td>
                                <td align="center">
                                    <asp:Label ID="Label7" runat="server" Text="至"></asp:Label>
                                </td>
                                <td >
                                    <asp:TextBox ID="TextBox5" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',false)"
                                        DataFormatString="{0:yyyy-MM-dd}" Width="155px"></asp:TextBox>
                                </td>
                                
                        </tr>
                        <tr>
                        <td>
                        </td>
                        <td align="center" colspan="2">
                            <asp:Button ID="BtnSearch" runat="server" CssClass="Button02" Height="24px" Text="检索"
                                Width="70px" OnClick="BtnSearch_Click" />
                        </td>
                        <td>
                        </td>
                        <td>
                            <asp:Button ID="BtnPrint" runat="server" CssClass="Button02" Height="24px" Text="打印报表" Width="90px" OnClick="BtnPrint_Click" ToolTip="点击此处,跳转打印页面。"/>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="BtnReset" runat="server" CssClass="Button02" Height="24px" 
                                OnClick="BtnReset_Click" Text="重置" Visible="true" Width="70px" />
                        </td>
                        <td align="left" >
                            &nbsp;</td>
                    </tr>
                    </table>
                        
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

<asp:UpdatePanel ID="UpdatePanel_Grid" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Grid" runat="server">
                <fieldset>
                    <legend>客户明细账</legend>
                    <table width="100%">
                        <tr>
                            <td style="width:20%;"></td>
                            <td style="width:20%;" align="right"><asp:Label ID="Label2" runat="server" Text="应收帐款：" Font-Size="15px" Visible="false"></asp:Label></td>
                            <td style="width:10%;" align="left"><asp:Label ID="Labelpay" runat="server" Text="" Font-Size="15px"></asp:Label></td>
                            <td style="width:10%;" align="right"><asp:Label ID="Label3" runat="server" Text="账期：" Font-Size="15px" Visible="false"></asp:Label></td>
                            <td style="width:10%;" align="left"><asp:Label ID="Labeltime" runat="server" Text="" Font-Size="15px"></asp:Label></td>
                            <td ></td>
                        </tr>
                    </table>
                    <asp:GridView ID="Grid_Detail" runat="server" AllowSorting="True" PageSize="10" AutoGenerateColumns="False" CssClass="GridViewStyle" Width="100%" 
                        AllowPaging="true"  GridLines="None" OnPageIndexChanging="Grid_Detail_PageIndexChanging" onrowcreated="Grid_Detail_RowCreated" 
                        onrowdatabound="Grid_Detail_RowDataBound" OnDataBound="Grid_Detail_DataBound" DataKeyNames="SMOD_ID">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="SMOD_ID" HeaderText="发货ID"  SortExpression="SMOD_ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="SMOD_Time" HeaderText="发货时间" SortExpression="SMOD_Time">
                                <ItemStyle/>
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCIF_Name" HeaderText="客户名称" SortExpression="CRMCIF_Name">
                                <ItemStyle/>
                            </asp:BoundField>
                            <asp:BoundField DataField="PT_Name" HeaderText="产品型号" SortExpression="PT_Name">
                                <ItemStyle/>
                            </asp:BoundField>
                            <asp:BoundField DataField="PT_Note" HeaderText="产品备注" SortExpression="PT_Note">
                                <ItemStyle/>
                            </asp:BoundField>
                            <asp:BoundField DataField="SMOD_Num" HeaderText="送货数量" SortExpression="SMOD_Num">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMOD_ReturnNum" HeaderText="退货数量" SortExpression="SMOD_ReturnNum">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMSOD_UnitPrice" HeaderText="订单单价" SortExpression="SMSOD_UnitPrice">
                                <ItemStyle/>
                            </asp:BoundField>
                            <asp:BoundField DataField="TotalOrderMoney" HeaderText="发货总额" SortExpression="TotalOrderMoney">
                                <ItemStyle/>
                            </asp:BoundField>
                            <asp:BoundField DataField="SMOD_PayMoney" HeaderText="已付款金额" SortExpression="SMOD_PayMoney">
                                <ItemStyle/>
                            </asp:BoundField>
                            <asp:TemplateField> 
                                 <ItemTemplate> 
                                     <asp:GridView ID="GridView3" runat="server"  Width="100%" AutoGenerateColumns="False" ShowHeader="false" Height="100%" 
                                            CssClass="GridViewStyle" GridLines="None" >
                                                <RowStyle CssClass="GridViewRowStyle"/>
                                                    <Columns> 
                                                        <asp:BoundField DataField="SMCB_BillTime" HeaderText="开票日期"> 
                                                            <ItemStyle width="25%"/>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="SMCB_BillNum" HeaderText="开票数量"> 
                                                            <ItemStyle width="25%"/>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="SMCB_BillPrice" HeaderText="开票单价">   
                                                            <ItemStyle width="25%"/>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="TotalBillMoney" HeaderText="金额">   
                                                            <ItemStyle width="25%"/>
                                                        </asp:BoundField>    
                                                    </Columns> 
                                            </asp:GridView>    
                                   </ItemTemplate> 
                                   <ItemStyle/>
                             </asp:TemplateField>
                             <asp:TemplateField> 
                                 <ItemTemplate>              
                                   </ItemTemplate> 
                                   <ItemStyle />
                             </asp:TemplateField>
                             <asp:TemplateField> 
                                 <ItemTemplate>              
                                   </ItemTemplate> 
                                   <ItemStyle/>
                             </asp:TemplateField>
                             <asp:TemplateField> 
                                 <ItemTemplate>              
                                   </ItemTemplate> 
                                   <ItemStyle/>
                             </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第&nbsp<asp:Label ID="lblPageIndex" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                        页 共&nbsp<asp:Label ID="lblPageCount" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageCount  %>" />
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
                        <EmptyDataTemplate>
                            <asp:Label ID="Label16" runat="server" Text="没有找到相关记录"></asp:Label>
                        </EmptyDataTemplate>
                        <EditRowStyle BackColor="white" />
                    </asp:GridView>
                    <br />
                    <asp:GridView ID="GridView1" runat="server" AllowSorting="True" PageSize="10" AutoGenerateColumns="False" CssClass="GridViewStyle" Width="100%" 
                        AllowPaging="true"  GridLines="None" OnPageIndexChanging="GridView1_PageIndexChanging" onrowcreated="GridView1_RowCreated">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="SMCP_PaymentTime" HeaderText="回款时间" SortExpression="SMCP_PaymentTime">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMCP_PaymentMoney" HeaderText="回款金额" SortExpression="SMCP_PaymentMoney">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMCP_Remark" HeaderText="备注" SortExpression="SMCP_Remark">
                                <ItemStyle />
                            </asp:BoundField>
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第&nbsp<asp:Label ID="lblPageIndex" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                        页 共&nbsp<asp:Label ID="lblPageCount" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageCount  %>" />
                                        页
                                        <asp:LinkButton ID="btnFirst" runat="server" CausesValidation="False" CommandArgument="First"
                                            CommandName="Page" Text="首页" />
                                        <asp:LinkButton ID="btnPrev" runat="server" CausesValidation="False" CommandArgument="Prev"
                                            CommandName="Page" Text="上一页" />
                                        <asp:LinkButton ID="btnNext" runat="server" CausesValidation="False" CommandArgument="Next"
                                            CommandName="Page" Text="下一页" />
                                        <asp:LinkButton ID="btnLast" runat="server" CausesValidation="False" CommandArgument="Last"
                                            CommandName="Page" Text="尾页" />
                                        <asp:TextBox ID="textbox1" runat="server" Width="20px"></asp:TextBox>
                                        <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                            CommandName="Page" Text="GO" />
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
