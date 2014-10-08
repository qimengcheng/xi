<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderDeliver.aspx.cs" Inherits="PurchasingMgt_OrderDeliver" MasterPageFile="~/Other/MasterPage.master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script> 
    <style type="text/css">
        .hidden
        {
            display: none;
        }
        .auto-style7 {
            width: 268435456px;
        }
        .auto-style10 {
            width: 18%;
        }
        .auto-style11 {
            width: 17%;
        }
        .auto-style12 {
        width: 14%;
    }
        </style>
    <script language="Javascript">
        function preview() {
            bdhtml = window.document.body.innerHTML;
            sprnstr = "<!--startprint-->";
            eprnstr = "<!--endprint-->";
            prnhtml = bdhtml.substr(bdhtml.indexOf(sprnstr) + 17);
            prnhtml = prnhtml.substring(0, prnhtml.indexOf(eprnstr));
            window.document.body.innerHTML = prnhtml;
            window.print();
        }
</script>
  
            <asp:Panel ID="Panel_OASearch" runat="server" Visible="true">
                <fieldset>
                    <legend> 销售发货单查询
                    </legend>
                     <asp:Label ID="label_Num" runat="server" Visible="false"/>
    <table style="width: 100%;">
         
            <tr>
          
                <td style="width: 15%;" align="right">
                     <asp:Label ID="Label2" runat="server" Text="产品型号："></asp:Label>
               </td>
         <td class="auto-style11">
                <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
            </td>
               
                 <td align="right" class="auto-style12">
                               客户订单号：
                            </td>
                            <td style="width: 15%;">
                              <asp:TextBox ID="TextBox2" runat="server" ></asp:TextBox>
                            </td>
                  <td style="width: 15%;" align="right">
                               客户名称：
                            </td>
                            <td style="width: 15%;">
                              <asp:TextBox ID="TextBox3" runat="server" ></asp:TextBox>
                            </td>
        </tr>
     <tr>
          <td align="right" class="auto-style12">
                                公司订单号：
                            </td>
                            <td style="width: 15%;">
                              <asp:TextBox ID="TextBox4" runat="server" ></asp:TextBox>
                            </td>
                <td align="right" style="width: 10%;">
                <asp:Label ID="Label1" runat="server" Text="发货日期："></asp:Label>
        
        </td>
         <td colspan="3">
           
                <asp:TextBox ID="TextBox_SPTime2" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D ',true)"  ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="right">
                <asp:Button ID="Button1" runat="server" Text="检索" CssClass="Button02" Height="24px" OnClick="Button1_Sh"
                    Width="70px" />
               
            </td>
            <td align="center" class="auto-style10" colspan="2">
                <asp:Button ID="Button2" runat="server"  CssClass ="Button02"
        Text="打印报表" Width="58px" OnClick="Button2_Click1"  ToolTip="点击此处,跳转打印页面。" />
                   </td>
           
            <td colspan="2" align="left">
               
                <asp:Button ID="Button3" runat="server" Text="重置" CssClass="Button02" Height="24px" OnClick="Button3_Reset" Visible="true"
                    Width="70px" />
            </td>
           
        </tr>
    </table>
     </fieldset>
            </asp:Panel>


         <!--startprint-->
        <asp:Panel ID="Panel_OAInfo" runat="server" Visible="false">
            <fieldset>
                <legend> </legend>
                

               <table style="width: 100%;">
       
        <tr>
       
        <td colspan="6" align="center">
                <asp:Label ID="label_Title" runat="server" Visible="true" />
            </td>
           
            </tr>
           
    </table>    
                  <asp:GridView ID="Gridview_OAInfo"  runat="server" AutoGenerateColumns="False"
                    CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False" 
                     onrowdatabound="Gridview_OAInfo_RowDataBound"
                    AllowPaging="false" AllowSorting="True" DataKeyNames="PT_Name" 
                    Width="100%"  Font-Strikeout="False" GridLines="None"
                    EnableModelValidation="True" ShowFooter="True"
                   >
             <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
           
                    <Columns>
                       
                        <asp:BoundField DataField="SMSO_ComOrderNum" HeaderText="公司订单号" 
                            SortExpression="SMSO_ComOrderNum" />
                        <asp:BoundField DataField="SMSO_CusOrderNum" HeaderText="客户订单号" SortExpression="SMSO_CusOrderNum">
                         
                        </asp:BoundField>
                        <asp:BoundField DataField="CRMCIF_Name" HeaderText="客户名称" SortExpression="CRMCIF_Name">
                        </asp:BoundField>
                         <asp:BoundField DataField="PT_Name" HeaderText="产品型号" SortExpression="PT_Name">
                        </asp:BoundField>
                         <asp:BoundField DataField="unit" HeaderText="计量单位" SortExpression="unit">
                        </asp:BoundField>
                         <asp:BoundField DataField="SMOD_Num" HeaderText="数量" SortExpression="SMOD_Num">
                        </asp:BoundField>
                         <asp:BoundField DataField="SMSOD_UnitPrice" HeaderText="单价" SortExpression="SMSOD_UnitPrice">
                        </asp:BoundField>
                         <asp:BoundField DataField="SMOD_Time" HeaderText="发货日期" SortExpression="SMOD_Time"  DataFormatString="{0:yyyy-MM-dd }">
                        </asp:BoundField>
                         <asp:BoundField DataField="SMSOD_MCode" HeaderText="物料编码" SortExpression="SMSOD_MCode">
                        </asp:BoundField>
                         <asp:BoundField DataField="SMSOD_PayMethon" HeaderText="付款方式" SortExpression="SMSOD_PayMethon">
                        </asp:BoundField>
            
                         <asp:BoundField DataField="CRMCIF_Address" HeaderText="发货地址" SortExpression="CRMCIF_Address">
                        </asp:BoundField>
                         <asp:BoundField DataField="SMOD_TransModel" HeaderText="发运方式" SortExpression="SMOD_TransModel">
                        </asp:BoundField>
                        <asp:BoundField DataField="PT_Note" HeaderText="产品备注" SortExpression="PT_Note">
                        </asp:BoundField>
                        <asp:BoundField DataField="SMSO_DetailCir" HeaderText="备注" SortExpression="SMSO_DetailCir">
                        </asp:BoundField>
                         <asp:BoundField DataField="totalmoney" HeaderText="金额" SortExpression="totalmoney">
                        </asp:BoundField>
                    </Columns>
               <EmptyDataTemplate>
              <asp:Label ID="Label50" runat="server" Text="无相关记录！"></asp:Label>
             </EmptyDataTemplate>
                    <FooterStyle CssClass="GridViewFooterStyle" />
                    <HeaderStyle CssClass="GridViewHead"
                        HorizontalAlign="Center" />
           
           
                            <PagerTemplate>
                   <table width="100%">
                    <tr>
                   <td style="text-align:right">
                       第<asp:Label id="lblPageIndex" runat="server" text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>' />
                       页 共<asp:Label id="lblPageCount" runat="server" text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />
                       页 
                    <asp:linkbutton id="btnFirst" runat="server" causesvalidation="False" commandargument="First" commandname="Page" text="首页" />
                  <asp:linkbutton id="btnPrev" runat="server" causesvalidation="False" commandargument="Prev" commandname="Page" text="上一页" />
                     <asp:linkbutton id="btnNext" runat="server" causesvalidation="False" commandargument="Next" commandname="Page" text="下一页" />                          
                      <asp:linkbutton id="btnLast" runat="server" causesvalidation="False" commandargument="Last" commandname="Page" text="尾页" />  
                       <asp:TextBox ID="textbox" runat="server" width="20px"></asp:TextBox>                                          
                       <asp:linkbutton id="btnGo" runat="server" causesvalidation="False" commandargument="-1" commandname="Page" text="GO" /><!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
                         </td>
                        </tr>
                     </table>
            </PagerTemplate>

                    <RowStyle CssClass="GridViewRowStyle" />
                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                      
                </asp:GridView>
                
                <table style="width: 100%;">
       
       <%-- <tr>
       <td colspan="6" align="right" class="auto-style8">
                <asp:Label ID="Label47" runat="server" Text="合计数量："></asp:Label>
            </td>
        <td  align="left" style="width: 10%;">
                <asp:Label ID="label_Num" runat="server" Visible="TRUE" />
            </td>
           
            </tr>--%>
           <tr>
               
   <td align="center" colspan="2">
    <asp:Button ID="Button4" runat="server" CssClass="Button02" OnClick="Button2_Click"
        Text="关闭" Width="55px" />
       </td>

           </tr>
    </table>
</fieldset>
                </asp:Panel>
    <!--endprint-->
     </asp:Content>
