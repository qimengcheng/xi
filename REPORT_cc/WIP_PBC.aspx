<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="WIP_PBC.aspx.cs" Inherits="PurchasingMgt_WIP_PBC"  MasterPageFile="~/Other/MasterPage.master"%>

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
                    <legend> 工序产量统计表
                    </legend>
                     <asp:Label ID="label_Num" runat="server" Visible="false"/>
    <table style="width: 100%;">
         
            
     <tr>
          <td align="right" class="auto-style12">
                               
                            </td>
                            <td style="width: 15%;">
                            
                            </td>
          
                          
         <td align="right" class="auto-style12">
                               产品型号：
                            </td>
                            <td style="width: 15%;">
                              <asp:TextBox ID="TextBox2" runat="server" ></asp:TextBox>
                            </td>
               
        </tr>
       
        <tr>
            <td colspan="2" align="right">
                <asp:Button ID="Button1" runat="server" Text="导出Excel" CssClass="Button02" Height="24px" OnClick="Button1_Sh"
                    Width="70px" />
               
            </td>
            <td align="center" class="auto-style10" colspan="2">
               
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
                    
                    AllowPaging="false" AllowSorting="True" DataKeyNames="TYPM_Year" 
                    Width="100%"  Font-Strikeout="False" GridLines="None"
                    EnableModelValidation="True" ShowFooter="false"
                   >
             <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
           
                    <Columns>
                       
                        <asp:BoundField DataField="TYPM_Year" HeaderText="年份" 
                            SortExpression="TYPM_Year" />
                        <asp:BoundField DataField="TID_Month" HeaderText="月份" SortExpression="TID_Month">
                         
                        </asp:BoundField>
                        <asp:BoundField DataField="TID_TLesson" HeaderText="培训项目" SortExpression="TID_TLesson">
                        </asp:BoundField>
                         <asp:BoundField DataField="TTT_Type" HeaderText="培训类型" SortExpression="TTT_Type">
                        </asp:BoundField>
                         <asp:BoundField DataField="TID_ActTime" HeaderText="实际培训时间" SortExpression="TID_ActTime">
                        </asp:BoundField>
                         <asp:BoundField DataField="TID_State" HeaderText="状态" SortExpression="TID_State">
                        </asp:BoundField>
                         <asp:BoundField DataField="TID_CreditHours" HeaderText="学时" SortExpression="TID_CreditHours">
                        </asp:BoundField>
                         <asp:BoundField DataField="TID_Teacher" HeaderText="讲师" SortExpression="TID_Teacher" >
                        </asp:BoundField>
                         <asp:BoundField DataField="TID_Place" HeaderText="地点" SortExpression="TID_Place">
                        </asp:BoundField>
                          <asp:BoundField DataField="应培训人数" HeaderText="应培训人数" SortExpression="应培训人数">
                        </asp:BoundField>
                         <asp:BoundField DataField="实际培训合格人数" HeaderText="实际培训合格人数" SortExpression="实际培训合格人数" >
                        </asp:BoundField>
                         <asp:BoundField DataField="通过率" HeaderText="通过率" SortExpression="通过率">
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

