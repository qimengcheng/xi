<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PMPaymentBill.aspx.cs" Inherits="ProjectManagement_PMPaymentBill"   MasterPageFile="~/Other/MasterPage.master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <style type="text/css">
        .hidden
        {
            display: none;
        }
        .style2
        {
            width: 15%;
        }
        .style3
        {
            width: 12%;
        }
        .style4
        {
            height: 20px;
            width: 40px;
        }
        .style5
        {
            width: 268435328px;
        }
    </style>
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script> 
    <asp:UpdatePanel ID="UpdatePanel_SPayBillSearch" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_SPayBillSearch" runat="server" Visible="true">
                <fieldset>
                    <legend> 检索条件</legend>
                    <asp:Label ID="labelcondition" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="label_pagestate" runat="server" Visible="False"></asp:Label>
    <table style="width: 100%;">  
         <asp:Label ID="label_Supply" runat="server" Visible="False"></asp:Label>
        <tr>
        <td style="width: 15%" align="right">
                <asp:Label ID="Label1" runat="server" Text="供应商名称："></asp:Label>
            </td>
             
            <td style="width: 12%" align="left">
                <asp:TextBox ID="TextBox_Factory" runat="server" Enabled="false"> </asp:TextBox>
            </td>
            <td style="width: 10%; height: 20px;" align="left">
                <asp:Button ID="Button20" runat="server" CssClass="Button02" Height="24px" 
                        OnClick="Button_SSearch" Text="选择..." Width="50px" />
                        </td>
            <td style="width: 12%" align="right">
                <asp:Label ID="Label2" runat="server" Text="贷款总额大于："></asp:Label>
            </td>
            
            <td style="width: 12%" align="left">
               <asp:TextBox ID="TextBox1" runat="server"> </asp:TextBox>
            </td>

            <td style="width: 15%" align="right">
                <asp:Label ID="Label3" runat="server" Text="应付款总额大于："></asp:Label>
            </td>
               <td style="width: 15%; height: 20px;" align="left">
                <asp:TextBox ID="TextBox2" runat="server"> </asp:TextBox>
            </td>
            </tr>
          
        <tr>
        <td style="width: 15%" align="left">
                &nbsp;</td>
            <td colspan="2" align="left">
                <asp:Button ID="Button1" runat="server" Text="检索" CssClass="Button02" Height="24px" OnClick="Button_Sh2"
                    Width="70px" />
            </td>
          
            <td colspan="2" align="left">
                
                <asp:Button ID="Button3" runat="server" Text="新增" CssClass="Button02" Height="24px" OnClick="Button_New" Visible="true"
                    Width="70px" />
            </td>
            <td style="width: 15%" align="left" colspan="2">
               <asp:Button ID="Button2" runat="server" Text="重置" CssClass="Button02" Height="24px" OnClick="Button_Reset1" Visible="true"
                    Width="70px" /></td>
        </tr>
    </table>
     </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    
    <asp:UpdatePanel ID="UpdatePanel_PayBill" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <asp:Panel ID="Panel_PayBill" runat="server" Visible="true">
            <fieldset>
                <legend>采购付款开票表</legend>
                
                     <asp:Button ID="Button8" runat="server" CssClass="Button02" Height="24px" 
                    OnClick="Button_Pay" Text="付款" Width="70px" />
                 <asp:Label ID="label_PayBillID" runat="server" Visible="false"></asp:Label>
                <asp:GridView ID="Gridview1"  runat="server" AutoGenerateColumns="False"
                    CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"
                    Font-Strikeout="False" GridLines="None" PageSize="10" 
                    OnRowCommand="Gridview1_RowCommand"  
                    AllowPaging="True" AllowSorting="True" 
                    DataKeyNames="PMPB_ID,PMSI_ID"   OnPageIndexChanging="Gridview1_PageIndexChanging" 
                    Width="100%" 
                    EnableModelValidation="True" ondatabound="Gridview1_DataBound" 
                     >
                    <%--    //隔行变色--%>
           
           
              <AlternatingRowStyle />
           
           
            <PagerStyle ForeColor="Black" 
                 HorizontalAlign="Center" CssClass="GridViewPagerStyle" />
           
           
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
           
           
                    <Columns>
                    <asp:BoundField DataField="PMPB_ID" HeaderText="采购付款开票ID" SortExpression="PMPB_ID" 
                            Visible="False">
                        </asp:BoundField>
                        <asp:BoundField DataField="PMSI_ID" HeaderText="供应商ID" SortExpression="PMSI_ID" 
                           Visible="False" >
                        </asp:BoundField>
                       
                        <asp:BoundField DataField="PMSI_SupplyName" HeaderText="供应商名称" 
                            SortExpression="PMSI_SupplyName" >
                             
                            </asp:BoundField>
                        <asp:BoundField DataField="PMPB_TotalDebt" HeaderText="欠款总额" 
                            SortExpression="PMPB_TotalDebt">
                          
                        </asp:BoundField>
                        <asp:BoundField DataField="PMPB_Due" HeaderText="应付款总额" 
                            SortExpression="PMPB_Due">
                         
                        </asp:BoundField>
                         <asp:BoundField DataField="PMPB_TotalBill" HeaderText="开票总额" 
                            SortExpression="PMPB_TotalBill">
                            
                        </asp:BoundField>
                        <asp:BoundField DataField="PMPB_TotalPaided" HeaderText="已付款" 
                            SortExpression="PMPB_TotalPaided">
                            </asp:BoundField>
                       
                       <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="btLk1" runat="server" CommandName="Paid" 
                                    CommandArgument='<%#Eval("PMPB_ID")%>'>付款详细</asp:LinkButton>
                                 
                            </ItemTemplate>
                             
                        </asp:TemplateField>
                        <%--<asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="btLLk1" runat="server" CommandName="Payment" 
                                    CommandArgument='<%#Eval("PMPB_ID")%>'>付款</asp:LinkButton>
                                 
                            </ItemTemplate>
                             
                        </asp:TemplateField>--%>

                    </Columns>
               <EmptyDataTemplate>
              <asp:Label ID="Label50" runat="server" Text="无相关记录！"></asp:Label>
             </EmptyDataTemplate>
                    <FooterStyle CssClass="GridViewFooterStyle" />
                    <HeaderStyle CssClass="GridViewHead" 
                        HorizontalAlign="Center" />
           
           
                    <PagerStyle CssClass="GridViewPagerStyle" />
  
           
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
                 <table width="100%">
                <tr>
                   <td style="width: 20%" align="center">
                &nbsp;</td> 
             <td width="30%" align="left">
               
                 &nbsp;</td>
            
                </tr>
                </table>
                </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel2" runat="server" Visible="false">
                <fieldset>
                    <legend> 付款</legend>
                    
    <table style="width: 100%;">  
        <tr>
        <td style="width: 15%" align="left">
                &nbsp;</td>
               
        <td style="width: 15%" align="right">
                <asp:Label ID="Label26" runat="server" Text="采购订单号："></asp:Label>
            </td>
             
            <td style="width: 12%" align="left">
                <asp:TextBox ID="TextBox11" runat="server" Enabled="true"> </asp:TextBox>
            </td>
            </tr>
          
        <tr>
        <td style="width: 15%" align="left">
                &nbsp;</td>
            <td colspan="1" align="left">
                <asp:Button ID="Button12" runat="server" Text="检索" CssClass="Button02" Height="24px" OnClick="Button_Search"
                    Width="70px" />
            </td>
             <td colspan="2" align="left">
                <asp:Button ID="Button4" runat="server" Text="重置" CssClass="Button02" Height="24px" OnClick="Button_Ret"
                    Width="70px" />
            </td>
            <td style="width: 15%" align="left" colspan="2">
               <asp:Button ID="Button24" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="Button_Cl" Visible="true"
                    Width="70px" /></td>
        </tr>
    </table>
     </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

     <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <asp:Panel ID="Panel3" runat="server" Visible="false">
            <fieldset>
                <legend>采购订单表</legend>
                 <asp:Label ID="label_PurchaseOrderID" runat="server" Visible="false"></asp:Label>
                <asp:GridView ID="Gridview7"  runat="server" AutoGenerateColumns="False"
                    CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"
                    Font-Strikeout="False" GridLines="None" PageSize="10" 
                    OnRowCommand="Gridview7_RowCommand"  
                    AllowPaging="True" AllowSorting="True" 
                    DataKeyNames="PMPO_PurchaseOrderID"   OnPageIndexChanging="Gridview7_PageIndexChanging" 
                    Width="100%" 
                    EnableModelValidation="True" ondatabound="Gridview7_DataBound" 
                     >
                    <%--    //隔行变色--%>
           
           
              <AlternatingRowStyle />
           
           
            <PagerStyle ForeColor="Black" 
                 HorizontalAlign="Center" CssClass="GridViewPagerStyle" />
           
           
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
           
           
                     <Columns>
                              <asp:BoundField DataField="PMPO_PurchaseOrderID" HeaderText="采购订单ID" 
                            SortExpression="PMPO_PurchaseOrderID" Visible="False">
                        <ItemStyle Width="100px" />
                        </asp:BoundField>
                       
                        <asp:BoundField DataField="PMPO_PurchaseOrderNum" HeaderText="采购订单号" 
                            SortExpression="PMPO_PurchaseOrderNum" />
                        <asp:BoundField DataField="PMPO_PlanArrTime" HeaderText="预到货期" DataFormatString="{0:yyyy-MM-dd}"
                            SortExpression="PMPO_PlanArrTime" />
                       <asp:BoundField DataField="PMPO_PayWay" HeaderText="付款方式" 
                            SortExpression="PMPO_PayWay" />
                            <asp:BoundField DataField="PMPO_PaymentTime" HeaderText="账期" 
                            SortExpression="PMPO_PaymentTime" />
                            <asp:BoundField DataField="PMPO_TotalMoney" HeaderText="总额" 
                            SortExpression="PMPO_TotalMoney" />
                        <asp:BoundField DataField="PMPO_ResidueMoney" FooterText="剩余付款" 
                            HeaderText="剩余付款" SortExpression="PMPO_ResidueMoney" />
                           <%-- <asp:TemplateField>
                            <ItemTemplate>
                                    <asp:LinkButton ID="btnLook1" runat="server" CommandName="Check1" CommandArgument='<%#Eval("PMPO_PurchaseOrderID")%>'>查看</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField>
                            <ItemTemplate>
                                    <asp:LinkButton ID="btnMakey" runat="server" CommandName="Foin" CommandArgument='<%#Eval("PMPO_PurchaseOrderID")%>'>付款</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:BoundField DataField="PMSI_ID" HeaderText="供应商ID" 
                            SortExpression="PMSI_ID" >
                        <FooterStyle CssClass="hidden" />
                                <HeaderStyle CssClass="hidden" />
                                <ItemStyle CssClass="hidden" />
                            </asp:BoundField>
                        </Columns>
               <EmptyDataTemplate>
              <asp:Label ID="Label50" runat="server" Text="无相关记录！"></asp:Label>
             </EmptyDataTemplate>
                    <FooterStyle CssClass="GridViewFooterStyle" />
                    <HeaderStyle CssClass="GridViewHead" 
                        HorizontalAlign="Center" />
           
           
                    <PagerStyle CssClass="GridViewPagerStyle" />
  
           
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
                </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

     
    <asp:UpdatePanel ID="UpdatePanel_NewPayBill" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_NewPayBill" runat="server" Visible="false">
                <fieldset>
                    <legend> 新增采购付款开票表</legend>
                    <asp:Label ID="label8" runat="server" Visible="false"></asp:Label>
    <table style="width: 100%;">
            <tr>
              <td align="left" style="width: 25%">
                        &nbsp;</td>
                       
             <td style="width: 15%; height: 20px;" align="right">
                <asp:Label ID="Label12" runat="server" Text="供应商名称："></asp:Label>
                </td>
            <td style="width: 15%; height: 20px;" align="right">
 <asp:TextBox ID="TextBox6" runat="server" Enabled="false" > </asp:TextBox>
            </td>
            <td align="left" class="style4">
                <asp:Button ID="Button13" runat="server" CssClass="Button02" Height="24px" 
                        OnClick="Button_rady" Text="选择..." Width="50px" /></td>

            </tr>
              
            <tr>
            
                <td  align="right" colspan="2">
                    <asp:Button ID="Button14" runat="server" CssClass="Button02" Height="24px" 
                        OnClick="Button_Rocky" Text="提交" Width="70px" />
                        </td>
                        <td></td>
                        <td align="left">
                    <asp:Button ID="Button15" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="Button_Tim"
                    Width="70px" />
                </td>
                
                </tr> 
        </tr>
    </table>
     </fieldset>
       </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    
      <script type="text/javascript">
          var last = null;
          function judge(obj) {
              if (last == null) {
                  last = obj.id;
              }
              else {
                  var lo = document.getElementById(last);
                  lo.checked = false;
                  last = obj.id;

              }
              obj.checked = "checked";
          }
    </script>  
      <asp:UpdatePanel ID="UpdatePanel_Supply" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <asp:Panel ID="Panel_Supply" runat="server" Visible="false">
            <fieldset>
                <legend>供应商查询</legend>
                 <asp:Label ID="label_SupplyID" runat="server" Visible="false"></asp:Label>
               <table style="width: 100%;">
       
        <tr>
        <td style="width: 12%; height: 20px;" align="right">
             
            </td>
        <td style="width: 12%; height: 20px;" align="right">
                <asp:Label ID="Label36" runat="server" Text="供应商编码："></asp:Label>
            </td>
            <td style="width: 12%; height: 20px;" align="left">
                <asp:TextBox ID="TextBox4" runat="server"> </asp:TextBox>
            </td>
            
           
            <td style="width: 12%; height: 20px;" align="left">
            
            </td>
           
            <td style="width: 12%; height: 20px;" align="right">
            <asp:Label ID="Label38" runat="server" Text="供应商名称："></asp:Label>
            </td>
               <td style="width: 15%; height: 20px;" align="left">
                <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
            </td> 
            </tr>
            <tr>
            
                <td  align="center" colspan="3">
                    <asp:Button ID="Button5" runat="server" CssClass="Button02" Height="24px" 
                        OnClick="Button1_KiMi" Text="检索" Width="80px" />
                        </td>
                        <td colspan="3" align="center">
                    <asp:Button ID="Button7" runat="server" Text="重置" CssClass="Button02" Height="24px" OnClick="Button_CoMi"
                    Width="80px" />
                </td>
              
                </tr>
       
    </table>
                <asp:GridView ID="Gridview_PMSupply"  runat="server" AutoGenerateColumns="False"
                    CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"
                    Font-Strikeout="False" GridLines="None" PageSize="5" 
                    AllowPaging="True" AllowSorting="True" DataKeyNames="PMSI_ID"   OnPageIndexChanging="Gridview_PMSupply_PageIndexChanging" 
                    Width="100%" 
                    EnableModelValidation="True" 
                    onrowdatabound="Gridview_PMSupply_RowDataBound1" 
                    ondatabound="Gridview_PMSupply_DataBound"  >
                    <%--    //隔行变色--%>
           
           
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
           
           
                    <PagerStyle CssClass="GridViewPagerStyle" />
           
           
              <AlternatingRowStyle />
           
           
                    <Columns>
                   <asp:TemplateField >
                            <ItemTemplate >
                                <asp:RadioButton ID="RadioButtonMarkup" runat="server"></asp:RadioButton>
                               
  
                            </ItemTemplate>
                            <ItemStyle/>
                        </asp:TemplateField>
                        
                        <asp:BoundField DataField="PMSI_ID" HeaderText="供应商ID" 
                            SortExpression="PMSI_ID" Visible="False">
                        <ItemStyle/>
                        </asp:BoundField>
                       
                        <asp:BoundField DataField="PMSI_SupplyNum" HeaderText="供应商编码" 
                            SortExpression="PMSI_SupplyNum" />
                        <asp:BoundField DataField="PMSI_SupplyName" HeaderText="供应商名称" 
                            SortExpression="PMSI_SupplyName" />
                       
                    </Columns>
               <EmptyDataTemplate>
              <asp:Label ID="Label50" runat="server" Text="无相关记录！"></asp:Label>
             </EmptyDataTemplate>
                    <FooterStyle CssClass="GridViewFooterStyle" />
                    <HeaderStyle CssClass="GridViewHead" 
                        HorizontalAlign="Center" />
           
           
            <PagerStyle  ForeColor="Black" 
                 HorizontalAlign="Center" CssClass="GridViewPagerStyle" />
           
           
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
               
                <table width="100%">
                <tr>
                <td width="34%" align="right" >
                    
                <asp:Button ID="Button18" runat="server" Text="提交" CssClass="Button02" Height="24px" OnClick="Button_ComSP"
                    Width="70px" />
            </td>
           <td style="width: 20%" align="center">
                &nbsp;</td>
                    
                   <td style="width: 20%" align="center">
                &nbsp;</td> 
             <td width="30%" align="left">
               
                <asp:Button ID="Button19" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="Button_Cancel5"
                    Width="70px" />
            </td>
            
                </tr>
                </table>
                </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
     
    <asp:UpdatePanel ID="UpdatePanel_Pay" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <asp:Panel ID="Panel_Pay" runat="server" Visible="false">
            <fieldset>
                <legend><asp:Label ID="label5" runat="server" Visible="true" ></asp:Label></legend>
                <asp:Label ID="label_PayID" runat="server" Visible="false" ></asp:Label>
                <asp:Label ID="label_Pay" runat="server" Visible="false" ></asp:Label>
                <asp:GridView ID="Gridview2"  runat="server" AutoGenerateColumns="False"
                    CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"
                    Font-Strikeout="False" GridLines="None" PageSize="10" 
                    OnRowCommand="Gridview2_RowCommand"  
                    AllowPaging="True" AllowSorting="True" 
                    DataKeyNames="PMPD_ID"   OnPageIndexChanging="Gridview2_PageIndexChanging" 
                    Width="100%" 
                    EnableModelValidation="True" ondatabound="Gridview2_DataBound"   >
                    <%--    //隔行变色--%>
           
           
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
           
           
                    <PagerStyle CssClass="GridViewPagerStyle" />
  
           
              <AlternatingRowStyle />
           
           
                    <Columns>
                    <asp:BoundField DataField="PMPD_ID" HeaderText="采购付款ID" SortExpression="PMPD_ID" 
                            Visible="False">
                        </asp:BoundField>
                        <asp:BoundField DataField="PMPD_Pay" HeaderText="付款金额" SortExpression="PMPD_Pay" 
                           >
                        </asp:BoundField>
                       
                        <asp:BoundField DataField="PMPD_PayWay" HeaderText="付款方式" 
                            SortExpression="PMPD_PayWay" >
                             
                            </asp:BoundField>
                        <asp:BoundField DataField="PMPD_PayTime" HeaderText="付款日期" 
                            SortExpression="PMPD_PayTime">
                          
                        </asp:BoundField>
                        <asp:BoundField DataField="PMPD_Man" HeaderText="录入人" 
                            SortExpression="PMPD_Man">
                         
                        </asp:BoundField>
                        <asp:BoundField DataField="PMPD_Time" HeaderText="录入时间" 
                            SortExpression="PMPD_Time">
                         
                        </asp:BoundField>
                        <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="MLook1" runat="server" CommandName="Morise" 
                                    CommandArgument='<%#Eval("PMPD_ID")%>'>编辑</asp:LinkButton>
                                 
                            </ItemTemplate>
                             
                        </asp:TemplateField>
                         
                    </Columns>
               <EmptyDataTemplate>
              <asp:Label ID="Label50" runat="server" Text="无相关记录！"></asp:Label>
             </EmptyDataTemplate>
                    <FooterStyle CssClass="GridViewFooterStyle" />
                    <HeaderStyle CssClass="GridViewHead" 
                        HorizontalAlign="Center" />
           
           
            <PagerStyle ForeColor="Black" 
                 HorizontalAlign="Center" CssClass="GridViewPagerStyle" />
           
           
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
                 <table width="100%">
                <tr>
               
 
                   <td style="width: 20%" align="center">
                   <asp:Button ID="Button6" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="Button_CPay"
                    Width="70px" />
                </td> 
                </tr>
                </table>
                </fieldset>
                </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdatePanel_NewPay" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_NewPay" runat="server" Visible="false">
                <fieldset>
                    <legend> <asp:Label ID="label7" runat="server" Visible="true"></asp:Label></legend>

                    <asp:Label ID="label_PayMoney" runat="server" Visible="false"></asp:Label>
    <table style="width: 100%;">
       
        <tr>
        <td style="width: 12%; height: 20px;" align="right">
                <asp:Label ID="Label10" runat="server" Text="付款金额："></asp:Label>
            </td>
            <td style="width: 12%; height: 20px;" align="left">
                <asp:TextBox ID="TextBox3" runat="server" onkeyup="this.value=this.value.replace(/[^0-9]/g,'')"
                                    onafterpaste="this.value=this.value.replace(/[^0-9]/g,'')"> </asp:TextBox>
            </td>
            
           <td style="width: 12%; height: 20px;" align="right">
                <asp:Label ID="Label11" runat="server" Text="付款方式："></asp:Label>
            </td>
            <td style="width: 12%; height: 20px;" align="left">
             <asp:DropDownList ID="DropDownList1" runat="server"  Width="125px">
                     <asp:ListItem>请选择</asp:ListItem>     
                      <asp:ListItem>现金</asp:ListItem>  
                       <asp:ListItem>支票</asp:ListItem>
                       <asp:ListItem>其它</asp:ListItem>   
                </asp:DropDownList>
            </td>
           
            <td style="width: 12%; height: 20px;" align="right">
            <asp:Label ID="Label20" runat="server" Text="付款日期："></asp:Label>
            </td>
               <td style="width: 15%; height: 20px;" align="left">
                <asp:TextBox ID="TextBox5" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D ',true)"  ></asp:TextBox>
            </td> 
            </tr>

                 <tr>
            
                <td  align="center" colspan="4">
                    <asp:Button ID="Button21" runat="server" CssClass="Button02" Height="24px" 
                        OnClick="Button_Kity" Text="提交" Width="70px" />
                        </td>
                        <td colspan="4" align="center">
                    <asp:Button ID="Button22" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="Button_Sena"
                    Width="70px" />
                </td>
                <td>
                    
                </td>
                </tr>
                </table>
     </fieldset>
       </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
     
</asp:Content>