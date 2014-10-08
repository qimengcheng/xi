<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BillApply.aspx.cs" Inherits="PurchasingMgt_BillApply" MasterPageFile="~/Other/MasterPage.master"  %>

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
        .auto-style13 {
            width: 9%;
        }
        .auto-style16 {
            width: 100px;
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
                    <legend> 开票申请查询
                    </legend>
                     <asp:Label ID="label_Num" runat="server" Visible="false"/>
    <table style="width: 100%;">
         
            <tr>
          <td style="width: 10%;" align="right">
                     <asp:Label ID="Label2" runat="server" Text="产品型号："></asp:Label>
               </td>
         <td style="width: 15%;" >
                <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
            </td>
               
                 <td align="right" class="auto-style13">
                               物料编码：
                            </td>
                            <td style="width: 15%;">
                              <asp:TextBox ID="TextBox4" runat="server" ></asp:TextBox>
                            </td>
                  <td style="width: 10%;" align="right">
                               客户名称：
                            </td>
                            <td style="width: 15%;">
                              <asp:TextBox ID="TextBox3" runat="server" ></asp:TextBox>
                            </td>
        </tr>
   
        <tr>
            <td colspan="2" align="right">
                <asp:Button ID="Button1" runat="server" Text="检索" CssClass="Button02" Height="24px" OnClick="Button1_Sh"
                    Width="70px" />
               
            </td>
            <td align="center"  colspan="2">
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
   

         
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
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

                 
                  <asp:GridView ID="Gridview_OAInfo"  runat="server" AutoGenerateColumns="false"
                    CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False" 
                     onrowdatabound="Gridview_OAInfo_RowDataBound" DataKeyNames="SMOD_ID"
                    AllowPaging="false" AllowSorting="True" 
                    Style="width: 100%"  Font-Strikeout="False" GridLines="None"
                    EnableModelValidation="True" ShowFooter="false"
                   >
             <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
           
                    <Columns>
                         <asp:TemplateField >
                            <ItemTemplate >
                                <asp:CheckBox ID="CheckMarkup" runat="server"></asp:CheckBox>
                               
                            </ItemTemplate>
                            <ItemStyle />
                        </asp:TemplateField>
                        <asp:BoundField DataField="SMOD_ID" HeaderText="开票申请ID" Visible="false" SortExpression="SMOD_ID">
                        </asp:BoundField>
                     <asp:BoundField DataField="CRMCIF_Name" HeaderText="客户名称" SortExpression="CRMCIF_Name">
                        </asp:BoundField>
                             <asp:BoundField DataField="PT_Name" HeaderText="产品型号" SortExpression="PT_Name">
                         
                        </asp:BoundField>
                              
                        <asp:BoundField DataField="SMSOD_MCode" HeaderText="物料编码" 
                            SortExpression="SMSOD_MCode" />
                      
                        <asp:BoundField DataField="SMSOD_UnitPrice" HeaderText="价格" SortExpression="SMSOD_UnitPrice"/>
                        <asp:BoundField DataField="BillNum" HeaderText="数量" SortExpression="BillNum"/>
                        <asp:BoundField DataField="totalmoney" HeaderText="金额" SortExpression="totalmoney"/>
                       
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
     
           <tr>
               
   <td align="center" colspan="2">
    <asp:Button ID="Button4" runat="server" CssClass="Button02" OnClick="Button2_Click"
        Text="提交" Width="55px" />
       </td>

           </tr>
    </table>
</fieldset>
                </asp:Panel>

    </ContentTemplate>
            </asp:UpdatePanel>

     <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
     <asp:Panel ID="Panel1" runat="server" Visible="false">
            <fieldset>
                <legend> </legend>
                

               <table style="width: 100%;">
       
        <tr>
        <td colspan="6" align="center">
                <asp:Label ID="label1" runat="server" Visible="false" />
            </td>
           
            </tr>
           
    </table>

                  <asp:GridView ID="Gridview1"  runat="server" AutoGenerateColumns="false"
                    CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False" 
                     DataKeyNames="SMOD_ID"
                    AllowPaging="false" AllowSorting="True" 
                    Style="width: 100%"  Font-Strikeout="False" GridLines="None"
                    EnableModelValidation="True" ShowFooter="false"
                   >
             <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
           
                    <Columns>
                         <asp:BoundField DataField="SMOD_ID" HeaderText="开票申请ID" Visible="false" SortExpression="SMOD_ID">
                        </asp:BoundField>
                     <asp:BoundField DataField="CRMCIF_Name" HeaderText="客户名称" SortExpression="CRMCIF_Name">
                        </asp:BoundField>
                             <asp:BoundField DataField="PT_Name" HeaderText="产品型号" SortExpression="PT_Name">
                         
                        </asp:BoundField>
                              
                        <asp:BoundField DataField="SMSOD_MCode" HeaderText="物料编码" 
                            SortExpression="SMSOD_MCode" />
                      
                        <asp:BoundField DataField="SMSOD_UnitPrice" HeaderText="价格" SortExpression="SMSOD_UnitPrice"/>
                        <asp:BoundField DataField="BillNum" HeaderText="数量" SortExpression="BillNum"/>
                        <asp:BoundField DataField="totalmoney" HeaderText="金额" SortExpression="totalmoney"/>
                       
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
    <asp:Button ID="Button5" runat="server" CssClass="Button02" OnClick="Button_Click"
        Text="全部删除" Width="55px" />
       </td>

           </tr>
    </table>
</fieldset>
                </asp:Panel>
</ContentTemplate>
            </asp:UpdatePanel>
        
     </asp:Content>
