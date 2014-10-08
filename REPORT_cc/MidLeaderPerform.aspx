<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MidLeaderPerform.aspx.cs" Inherits="REPORT_cc_MidLeaderPerform"   MasterPageFile="~/Other/MasterPage.master" %>

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
            width: 13%;
        }
        .auto-style14 {
            width: 10%;
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
                    <legend> 中干绩效考核查询
                    </legend>
                     <asp:Label ID="label_year" runat="server" Visible="false"/>
                    <asp:Label ID="label_month" runat="server" Visible="false"/>
    <table style="width: 100%;">
         
            <tr>
          <%--  --%>
                 <td style="width: 20%;" align="right">
                              
                            </td>
                 <td align="right" class="auto-style13">
                <asp:Label ID="Label2" runat="server" Text="年份："></asp:Label>
        
        </td>
         <td style="width: 15%;" >
                <asp:DropDownList ID="DropDownList_Year" runat="server" Height="22px" Width="127px">
                                </asp:DropDownList>
            </td>
                <td align="right" class="auto-style14">
                              
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
                    AllowPaging="true" AllowSorting="True"  PageSize="30"
                    Width="100%"  Font-Strikeout="False" GridLines="None"
                    EnableModelValidation="True" ShowFooter="false" OnPageIndexChanging="Gridview_OAInfo_PageIndexChanging"
                   >
             <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
           
                    <Columns>
                       <asp:BoundField DataField="工号" HeaderText="工号" 
                            SortExpression="工号" />
                        <asp:BoundField DataField="姓名" HeaderText="姓名" 
                            SortExpression="姓名" />
                        <asp:BoundField DataField="部门" HeaderText="部门" 
                            SortExpression="部门" />
                        <asp:BoundField DataField="岗位" HeaderText="岗位" SortExpression="岗位">
                         
                        </asp:BoundField>
                        <asp:BoundField DataField="一月得分" HeaderText="一月得分" SortExpression="一月得分">
                        </asp:BoundField>
                         <asp:BoundField DataField="二月得分" HeaderText="二月得分" SortExpression="二月得分">
                        </asp:BoundField>
                          <asp:BoundField DataField="三月得分" HeaderText="三月得分" SortExpression="三月得分">
                        </asp:BoundField>
                        <asp:BoundField DataField="四月得分" HeaderText="四月得分" SortExpression="四月得分">
                        </asp:BoundField>
                        <asp:BoundField DataField="五月得分" HeaderText="五月得分" SortExpression="五月得分">
                        </asp:BoundField>
                        <asp:BoundField DataField="六月得分" HeaderText="六月得分" SortExpression="六月得分">
                        </asp:BoundField>
                        <asp:BoundField DataField="七月得分" HeaderText="七月得分" SortExpression="七月得分">
                        </asp:BoundField>
                         <asp:BoundField DataField="八月得分" HeaderText="八月得分" SortExpression="八月得分">
                        </asp:BoundField>
                        <asp:BoundField DataField="九月得分" HeaderText="九月得分" SortExpression="九月得分">
                        </asp:BoundField>
                        <asp:BoundField DataField="十月得分" HeaderText="十月得分" SortExpression="十月得分">
                        </asp:BoundField>
                        <asp:BoundField DataField="十一月得分" HeaderText="十一月得分" SortExpression="十一月得分">
                        </asp:BoundField>
                        <asp:BoundField DataField="十二月得分" HeaderText="十二月得分" SortExpression="十二月得分">
                        </asp:BoundField>
                         <asp:BoundField DataField="全年总分" HeaderText="全年总分" SortExpression="全年总分">
                        </asp:BoundField>
                         <asp:BoundField DataField="次数" HeaderText="次数" SortExpression="次数">
                        </asp:BoundField>
                         <asp:BoundField DataField="全年平均分" HeaderText="全年平均分" SortExpression="全年平均分" >
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


