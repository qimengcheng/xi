<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WOError_Statistics.aspx.cs" Inherits="PurchasingMgt_WOError_Statistics"  MasterPageFile="~/Other/MasterPage.master" %>

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
                    <legend> 异常统计查询
                    </legend>
                     <asp:Label ID="label_Num" runat="server" Visible="false"/>
    <table style="width: 100%;">
         
            <tr>
          
                 <td align="right" class="auto-style12">
                                异常处理部门：
                            </td>
                            <td style="width: 15%;">
                              
                              <asp:TextBox ID="TextBox6" runat="server" ></asp:TextBox>
                            </td>
               
                 <td align="right" class="auto-style12">
                               随工单号：
                            </td>
                            <td class="auto-style13">
                              <asp:TextBox ID="TextBox2" runat="server" ></asp:TextBox>
                            </td>
                  <td style="width: 15%;" align="right">
                               异常工序：
                            </td>
                            <td style="width: 15%;">
                              
                              <asp:TextBox ID="TextBox3" runat="server" ></asp:TextBox>
                            </td>
        </tr>
     <tr>
          <td align="right" class="auto-style12">
                                异常大类：
                            </td>
                            <td style="width: 15%;">
                              <asp:TextBox ID="TextBox4" runat="server" ></asp:TextBox>
                            </td>
          <td align="right" class="auto-style12">
                                异常选项：
                            </td>
                            <td class="auto-style13">
                              <asp:TextBox ID="TextBox5" runat="server" ></asp:TextBox>
                            </td>
         
         </tr>
        <tr>
                <td align="right" style="width: 10%;">
                <asp:Label ID="Label1" runat="server" Text="入库时间："></asp:Label>
        
        </td>
         <td colspan="3">
            <asp:TextBox ID="TextBox_SPTime2" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D ',true)"  ></asp:TextBox>
       
                &nbsp;
       
                <asp:Label ID="Label" runat="server" Text="至"></asp:Label>
            
                &nbsp;
            
                <asp:TextBox ID="TextBox_SPTime3" runat="server" 
                    onfocus="new WdatePicker(this,'%Y-%M-%D ',true)"  ></asp:TextBox>
            </td>
            </tr><tr>
              <td align="right" class="auto-style13">
                <asp:Label ID="Label3" runat="server" Text="投产时间："></asp:Label>
        
        </td>
         <td colspan="3">
            <asp:TextBox ID="TextBox7" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D ',true)"  ></asp:TextBox>
       
                &nbsp;
       
                <asp:Label ID="Label4" runat="server" Text="至"></asp:Label>
            
                &nbsp;
            
                <asp:TextBox ID="TextBox8" runat="server" 
                    onfocus="new WdatePicker(this,'%Y-%M-%D ',true)"  ></asp:TextBox>
            </td>
        </tr>
        <tr>
              <td align="right" class="auto-style13">
                <asp:Label ID="Label2" runat="server" Text="异常开始时间："></asp:Label>
        
        </td>
         <td colspan="3">
            <asp:TextBox ID="TextBox1" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D ',true)"  ></asp:TextBox>
       
                &nbsp;
       
                <asp:Label ID="Label5" runat="server" Text="至"></asp:Label>
            
                &nbsp;
            
                <asp:TextBox ID="TextBox9" runat="server" 
                    onfocus="new WdatePicker(this,'%Y-%M-%D ',true)"  ></asp:TextBox>
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
                    AllowPaging="false" AllowSorting="True" DataKeyNames="WOE_Time" 
                    Width="100%"  Font-Strikeout="False" GridLines="None"
                    EnableModelValidation="True" ShowFooter="false"
                   >
             <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
           
                    <Columns>
                       
                        <asp:BoundField DataField="WOE_Time" HeaderText="异常开始时间" 
                            SortExpression="WOE_Time"  DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"/>
                        <asp:BoundField DataField="WO_Num" HeaderText="随工单" SortExpression="WO_Num">
                         
                        </asp:BoundField>
                        <asp:BoundField DataField="WO_FirstInNum" HeaderText="投入数" SortExpression="WO_FirstInNum">
                        </asp:BoundField>
                         <asp:BoundField DataField="WO_ProduceTime" HeaderText="投产时间" SortExpression="WO_ProduceTime"  DataFormatString="{0:yyyy-MM-dd HH:mm:ss}">
                        </asp:BoundField>
                         <asp:BoundField DataField="PBC_Name" HeaderText="异常工序" SortExpression="PBC_Name">
                        </asp:BoundField>
                         <asp:BoundField DataField="EPO_Name" HeaderText="异常大类" SortExpression="EPO_Name"  >
                        </asp:BoundField>
                         <asp:BoundField DataField="EPOD_Name" HeaderText="异常选项" SortExpression="EPOD_Name" >
                        </asp:BoundField>
                         <asp:BoundField DataField="WOE_Dep" HeaderText="异常处理部门" SortExpression="WOE_Dep" >
                        </asp:BoundField>
                         <asp:BoundField DataField="WOE_Measure" HeaderText="异常处理措施" SortExpression="WOE_Measure">
                        </asp:BoundField>
                         <asp:BoundField DataField="Result" HeaderText="异常结果" SortExpression="Result">
                        </asp:BoundField>
                         <asp:BoundField DataField="DelayTime" HeaderText="滞留时间" SortExpression="DelayTime">
                        </asp:BoundField>
                         <asp:BoundField DataField="WOD_WNum" HeaderText="废品数" SortExpression="WOD_WNum">
                        </asp:BoundField>
                         <asp:BoundField DataField="IMISM_InStoreTime" HeaderText="入库时间" SortExpression="IMISM_InStoreTime"  DataFormatString="{0:yyyy-MM-dd HH:mm:ss}">
                        </asp:BoundField>
                         <asp:BoundField DataField="WO_Note" HeaderText="随工单备注" SortExpression="WO_Note">
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


