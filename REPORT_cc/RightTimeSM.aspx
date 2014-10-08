<%@ Page Language="C#"  AutoEventWireup="true" CodeFile="RightTimeSM.aspx.cs" Inherits="PurchasingMgt_RightTimeSM"   MasterPageFile="~/Other/MasterPage.master"%>

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
        .auto-style12 {
        width: 14%;
    }
        .auto-style13 {
            width: 12%;
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
                    <legend> 订单库存在制品一览表查询
                    </legend>
                     <asp:Label ID="label_Num" runat="server" Visible="false"/>
    <table style="width: 100%;">
         
            <tr>
          <td align="right" style="width: 8%;">
                               &nbsp;</td>
                 <td align="right" class="auto-style12">
                                产品名称：
                            </td>
                            <td style="width: 15%;">
                              
                              <asp:TextBox ID="TextBox6" runat="server" ></asp:TextBox>
                            </td>
               
                 
                            
                  <td style="width: 15%;" align="right">
                               产品备注：
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
                    EnableModelValidation="True" ShowFooter="false" OnRowCommand="Gridview_OAInfo_RowCommand"
                   >
             <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
           
                    <Columns>
                       
                        <asp:BoundField DataField="OrderSum" HeaderText="订单总数" 
                            SortExpression="OrderSum" />
                        <asp:BoundField DataField="PT_Name" HeaderText="产品名称" SortExpression="PT_Name"  >
                        </asp:BoundField>
                        <asp:BoundField DataField="KucunSum" HeaderText="及时库存数" SortExpression="KucunSum">
                         
                        </asp:BoundField>
                        <asp:BoundField DataField="Zaizhipin" HeaderText="在制品数" SortExpression="Zaizhipin">
                        </asp:BoundField>
                         <asp:BoundField DataField="manzu" HeaderText="物料是否满足" SortExpression="manzu" >
                        </asp:BoundField>
                         <asp:BoundField DataField="touchan" HeaderText="应投产数" SortExpression="touchan">
                        </asp:BoundField>
                         
                         <asp:BoundField DataField="PT_Note" HeaderText="产品备注" SortExpression="PT_Note" >
                        </asp:BoundField>
                         <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="Lbtoon" runat="server" CommandName="Niguo" 
                                    CommandArgument='<%#Eval("PT_Name")%>'>详细</asp:LinkButton>
                                   
                            </ItemTemplate>
                            
                        </asp:TemplateField>
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


           <asp:Panel ID="Panel1" runat="server" Visible="false">
            <fieldset>
                <legend><asp:Label ID="label1" runat="server" Visible="true" /> </legend>
                

               <table style="width: 100%;">
       
        <tr>
       
        <td colspan="6" align="center">
                
            </td>
           
            </tr>
           
    </table>    
                  <asp:GridView ID="Gridview1"  runat="server" AutoGenerateColumns="False"
                    CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False" 
                     
                    AllowPaging="false" AllowSorting="True" DataKeyNames="Name" 
                    Width="100%"  Font-Strikeout="False" GridLines="None"
                    EnableModelValidation="True" ShowFooter="false"
                   >
             <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
           
                    <Columns>
                       
                        <asp:BoundField DataField="Name" HeaderText="物料名称" 
                            SortExpression="Name" />
                        <asp:BoundField DataField="Model" HeaderText="规格型号" SortExpression="Model"  >
                        </asp:BoundField>
                        <asp:BoundField DataField="Unit" HeaderText="单位" SortExpression="Unit">
                         
                        </asp:BoundField>
                        <asp:BoundField DataField="total" HeaderText="物料理论总数" SortExpression="total">
                        </asp:BoundField>
                         <asp:BoundField DataField="zhuangtai" HeaderText="库存能否满足" SortExpression="zhuangtai" >
                        </asp:BoundField>
                         <asp:BoundField DataField="queshi" HeaderText="缺失数" SortExpression="queshi">
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
    <asp:Button ID="Button5" runat="server" CssClass="Button02" OnClick="ButtonClose"
        Text="关闭" Width="55px" />
       </td>

           </tr>
    </table>
</fieldset>
                </asp:Panel>

     </asp:Content>
