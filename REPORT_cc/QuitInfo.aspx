<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QuitInfo.aspx.cs" Inherits="PurchasingMgt_QuitInfo" MasterPageFile="~/Other/MasterPage.master" %>

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
                    <legend> 离职信息查询
                    </legend>
                     <asp:Label ID="label_Num" runat="server" Visible="false"/>
    <table style="width: 100%;">
         
            <tr>
          
                <td style="width: 15%;" align="right">
                     <asp:Label ID="Label2" runat="server" Text="工号："></asp:Label>
               </td>
         <td class="auto-style11">
                <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
            </td>
               
                 <td align="right" class="auto-style12">
                               姓名：
                            </td>
                            <td class="auto-style13">
                              <asp:TextBox ID="TextBox2" runat="server" ></asp:TextBox>
                            </td>
                  <td style="width: 15%;" align="right">
                               部门：
                            </td>
                            <td style="width: 15%;">
                              
                              <asp:TextBox ID="TextBox3" runat="server" ></asp:TextBox>
                            </td>
        </tr>
     <tr>
          <td align="right" class="auto-style12">
                                岗位：
                            </td>
                            <td style="width: 15%;">
                              <asp:TextBox ID="TextBox4" runat="server" ></asp:TextBox>
                            </td>
          <td align="right" class="auto-style12">
                                离职原因：
                            </td>
                            <td class="auto-style13">
                              <asp:TextBox ID="TextBox5" runat="server" ></asp:TextBox>
                            </td>
          <td align="right" class="auto-style12">
                                离职方式：
                            </td>
                            <td style="width: 15%;">
                              
                              <asp:TextBox ID="TextBox6" runat="server" ></asp:TextBox>
                            </td>
         </tr>
        <tr>
                <td align="right" style="width: 10%;">
                <asp:Label ID="Label1" runat="server" Text="离职日期："></asp:Label>
        
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
                <asp:Label ID="Label3" runat="server" Text="入职日期："></asp:Label>
        
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
                    AllowPaging="false" AllowSorting="True" DataKeyNames="HRDD_Name" 
                    Width="100%"  Font-Strikeout="False" GridLines="None"
                    EnableModelValidation="True" ShowFooter="false"
                   >
             <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
           
                    <Columns>
                       
                        <asp:BoundField DataField="HRDD_StaffNO" HeaderText="工号" 
                            SortExpression="HRDD_StaffNO" />
                        <asp:BoundField DataField="HRDD_Name" HeaderText="姓名" SortExpression="HRDD_Name">
                         
                        </asp:BoundField>
                        <asp:BoundField DataField="HRDD_Sex" HeaderText="性别" SortExpression="HRDD_Sex">
                        </asp:BoundField>
                         <asp:BoundField DataField="BDOS_Name" HeaderText="部门" SortExpression="BDOS_Name">
                        </asp:BoundField>
                         <asp:BoundField DataField="HRP_Post" HeaderText="职务" SortExpression="HRP_Post">
                        </asp:BoundField>
                         <asp:BoundField DataField="HRDD_EntryDate" HeaderText="入职日期" SortExpression="HRDD_EntryDate"  DataFormatString="{0:yyyy-MM-dd }">
                        </asp:BoundField>
                         <asp:BoundField DataField="HRDD_QuitTime" HeaderText="离职日期" SortExpression="HRDD_QuitTime"  DataFormatString="{0:yyyy-MM-dd }">
                        </asp:BoundField>
                         <asp:BoundField DataField="HRDD_QuitRes" HeaderText="离职原因" SortExpression="HRDD_QuitRes"  >
                        </asp:BoundField>
                         <asp:BoundField DataField="HRDD_QuitMan" HeaderText="离职方式" SortExpression="HRDD_QuitMan">
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

