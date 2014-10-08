<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReturnPayPlan.aspx.cs" Inherits="PurchasingMgt_ReturnPayPlan"  MasterPageFile="~/Other/MasterPage.master" %>

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
                    <legend> 回款计划查询
                    </legend>
                     <asp:Label ID="label_Num" runat="server" Visible="false"/>
    <table style="width: 100%;">
         
            <tr>
          <td style="width: 10%;" align="right">
                     <asp:Label ID="Label2" runat="server" Text="片区："></asp:Label>
               </td>
         <td style="width: 15%;" >
                <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
            </td>
               
                 <td align="right" class="auto-style13">
                               业务员：
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

                 
                  <asp:GridView ID="Gridview_OAInfo"  runat="server" AutoGenerateColumns="false"
                    CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False" 
                     onrowdatabound="Gridview_OAInfo_RowDataBound"
                    AllowPaging="false" AllowSorting="True" DataKeyNames="CRMCIF_ID" 
                    Style="width: 100%"  Font-Strikeout="False" GridLines="None"
                    EnableModelValidation="True" ShowFooter="true"
                   >
             <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
           
                    <Columns>
                         <asp:BoundField DataField="CRMRBI_Name" HeaderText="片区" 
                            SortExpression="CRMRBI_Name"  >
                            
                                </asp:BoundField>
                        <asp:BoundField DataField="CRMCIF_SalesMan" HeaderText="业务员" 
                            SortExpression="CRMCIF_SalesMan" />
                        <asp:BoundField DataField="paytime" HeaderText="回款周期" SortExpression="paytime">
                         
                        </asp:BoundField>
                       
                         <asp:BoundField DataField="CRMCIF_Name" HeaderText="客户名称" SortExpression="CRMCIF_Name">
                        </asp:BoundField>
                        <asp:BoundField DataField="daoqi" HeaderText="到期货款" SortExpression="daoqi"/>
                        <asp:BoundField DataField="money1" HeaderText="实际回款" SortExpression="money1"/>
                        <asp:BoundField DataField="kaipiao" HeaderText="未开票金额" SortExpression="kaipiao"/>
                        <asp:BoundField DataField="chaoqi1" HeaderText="超期1个月" SortExpression="chaoqi1"/>
                        <asp:BoundField DataField="chaoqi2" HeaderText="超期2个月" SortExpression="chaoqi2"/>                                                               
                        <asp:BoundField DataField="chaoqi3" HeaderText="超期3个月" SortExpression="chaoqi3"/> 
                        <asp:BoundField DataField="ReturnRate" HeaderText="当月回款率" SortExpression="ReturnRate"/>
                        <asp:BoundField DataField="TimeNow" HeaderText="截止日期" SortExpression="TimeNow"  DataFormatString="{0:yyyy-MM-dd HH:mm:ss }"/>
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

