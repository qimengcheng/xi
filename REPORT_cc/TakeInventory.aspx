<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TakeInventory.aspx.cs" Inherits="REPORT_cc_TakeInventory"  MasterPageFile="~/Other/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <style type="text/css">
        .hidden
        {
            display: none;
        }
        .auto-style7 {
            width: 14%;
        }
        .auto-style12 {
            width: 52%;
        }
    </style>
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script> 
    <asp:UpdatePanel ID="UpdatePanel_TISearch" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_TISearch" runat="server" Visible="true">
                <fieldset>
                    <legend> 检索条件</legend>
    <table style="width: 100%;">
        
         <asp:Label ID="label_QA" runat="server" Visible="False"></asp:Label>
           <asp:Label ID="label_pagestate" runat="server" Visible="False"></asp:Label>
        <tr>
        <td style="width: 15%" align="right">
                <asp:Label ID="Label1" runat="server" Text="盘存人："></asp:Label>
            </td>
            <td style="width: 15%" align="left">
                <asp:TextBox ID="TakeInventory" runat="server"> </asp:TextBox>
            </td>
             
            <td align="right">
                <asp:Label ID="Label5" runat="server" Text="盘存时间："></asp:Label>
            </td>
            
           <td style="width: 139px">
       <asp:TextBox ID="TextBox_SPTime2" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D ',true)"  ></asp:TextBox>
       </td>
       <td align="right">
                <asp:Label ID="Label6" runat="server" Text="至："></asp:Label>
            </td>
            <td>
       <asp:TextBox ID="TextBox_SPTime3" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"  ></asp:TextBox>
       </td>     
        </tr>
         
        <tr>
        
            <td colspan="2" align="center">
                <asp:Button ID="Button1" runat="server" Text="检索" CssClass="Button02" Height="24px" OnClick="Button1_Sh"
                    Width="70px" />
            </td>
          
            <td colspan="2" align="center">
                
                <asp:Button ID="Button3" runat="server" Text="新增盘存" CssClass="Button02" Height="24px" OnClick="Button3_New" Visible="true"
                    Width="70px" />
            </td>
            <td align="center" colspan="2">
               <asp:Button ID="Button2" runat="server" Text="重置" CssClass="Button02" Height="24px" OnClick="Button2_Reset" Visible="true"
                    Width="70px" /></td>
        </tr>
    </table>
     </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
 
     <asp:UpdatePanel ID="UpdatePanel_TakeInventory" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <asp:Panel ID="Panel_TakeInventory" runat="server" Visible="true">
            <fieldset>
                <legend>盘存记录表</legend>
                <asp:Label ID="label_TI_ID" runat="server" Visible="False"></asp:Label>
                
                <asp:GridView ID="Gridview1"  runat="server" AutoGenerateColumns="False"
                    CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"
                    Font-Strikeout="False" GridLines="None"  PageSize="30"
                    OnRowCommand="Gridview1_RowCommand"  
                    AllowPaging="True" AllowSorting="True" 
                    DataKeyNames="TI_ID"   OnPageIndexChanging="Gridview1_PageIndexChanging" 
                    Width="100%" ondatabound="Gridview1_DataBound" 
                     >
                    <%--    //隔行变色--%>
           
           
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
           
           
                    <PagerStyle CssClass="GridViewPagerStyle" />
  
           
              <AlternatingRowStyle />
           
           
                    <Columns>
                        <asp:BoundField DataField="TI_ID" HeaderText="盘存ID" SortExpression="TI_ID" 
                            Visible="true"  ReadOnly="true">
                             <FooterStyle CssClass="hidden" />
                                <HeaderStyle CssClass="hidden" />
                                <ItemStyle CssClass="hidden" />
                        </asp:BoundField>
                      <asp:BoundField DataField="TI_Num" HeaderText="盘存编号" 
                            SortExpression="TI_Num"   />

                        <asp:BoundField DataField="TI_Man" HeaderText="盘存人" 
                            SortExpression="TI_Man"  >
                             
                            </asp:BoundField>
                       
                        <asp:BoundField DataField="TI_Time" HeaderText="盘存时间" 
                              SortExpression="TI_Time" DataFormatString="{0:yyyy-MM-dd}" ReadOnly="true">
                        </asp:BoundField>
                        <asp:BoundField DataField="TI_ReMark" HeaderText="备注" 
                            SortExpression="TI_ReMark"  >
                        </asp:BoundField>
                        
                        
                       <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="Lbtoon" runat="server" CommandName="Niguo" 
                                    CommandArgument='<%#Eval("TI_ID")%>'>编辑</asp:LinkButton>
                                   
                            </ItemTemplate>
                            
                        </asp:TemplateField>
                         <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="btLook2" runat="server" CommandName="Delete1"  OnClientClick="return confirm('您确认删除该记录吗?')" 
                                    CommandArgument='<%#Eval("TI_ID")%>'>删除</asp:LinkButton>
                                    
                            </ItemTemplate>
                            
                        </asp:TemplateField>
                       <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="btLk1" runat="server" CommandName="Approve" 
                                    CommandArgument='<%#Eval("TI_ID")%>'>详情</asp:LinkButton>
                                 
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
                </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

     <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel3" runat="server" Visible="false">
                <fieldset>
                    <legend> <asp:Label ID="label12" runat="server" Visible="true"></asp:Label></legend>
    <table style="width: 100%;">
        
         <asp:Label ID="label8" runat="server" Visible="False"></asp:Label>
           <asp:Label ID="label10" runat="server" Visible="False"></asp:Label>
        <tr>
        <td align="right"style="width: 30%;">
                <asp:Label ID="Label11" runat="server" Text="备注："></asp:Label>
             <br/>
                <asp:Label ID="label54" runat="server" text="(200字以内)" Visible="true"></asp:Label>
        </td>
            <td style="width: 80%"align="left">
                <asp:TextBox ID="TextBox3" runat="server" Height="116px" Width="656px" MaxLength="200" TextMode="MultiLine" 
                onkeyup="this.value = this.value.substring(0, 200)" onafterpaste="this.value = this.value.substring(0, 200)"></asp:TextBox>
            </td>
             
           <td style="width: 15%" align="right">
               </td>
       
        </tr>
         
        <tr>
        
            <td align="center" class="auto-style12" >
               
            </td>
          
            
            <td align="center" style="width: 50%">
                 <asp:Button ID="Button9" runat="server" Text="提交" CssClass="Button02" Height="24px" OnClick="Button_TJ"
                    Width="70px" />

                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

               <asp:Button ID="Button7" runat="server" Text="取消" CssClass="Button02" Height="24px" OnClick="Button_JL" Visible="true"
                    Width="70px" /></td>
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
                    <legend> 详细信息检索条件</legend>
    <table style="width: 100%;">
        
         <asp:Label ID="label2" runat="server" Visible="False"></asp:Label>
           <asp:Label ID="label3" runat="server" Visible="False"></asp:Label>
        <tr>
        <td style="width: 15%" align="right">
                <asp:Label ID="Label4" runat="server" Text="大类型号："></asp:Label>
            </td>
            <td style="width: 15%" align="left">
                <asp:TextBox ID="TextBox1" runat="server"> </asp:TextBox>
            </td>
             
            <td align="right">
                <asp:Label ID="Label7" runat="server" Text="工序："></asp:Label>
            </td>
            
           <td style="width: 139px">
       <asp:TextBox ID="TextBox2" runat="server"   ></asp:TextBox>
       </td>
       
        </tr>
         
        <tr>
        
            <td colspan="2" align="center">
                <asp:Button ID="Button4" runat="server" Text="检索" CssClass="Button02" Height="24px" OnClick="Button_Sh"
                    Width="70px" />
            </td>
          
            <td colspan="2" align="center">  
                  <asp:Button ID="Button8" runat="server" Text="打印报表" CssClass="Button02" Height="24px" OnClick="Button_ClickDY"
                    Width="70px" />
            </td>
            <td align="center" colspan="2">
               <asp:Button ID="Button6" runat="server" Text="重置" CssClass="Button02" Height="24px" OnClick="Button_Reset" Visible="true"
                    Width="70px" /></td>
        </tr>
    </table>
     </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
 
    


     <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <asp:Panel ID="Panel2" runat="server" Visible="false">
            <fieldset>
                <legend> <asp:Label ID="label9" runat="server" Visible="true"></asp:Label></legend>
               
                
                <asp:GridView ID="Gridview2"  runat="server" AutoGenerateColumns="False"
                    CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"
                    Font-Strikeout="False" GridLines="None"  PageSize="30"
                    
                    AllowPaging="True" AllowSorting="True" 
                    DataKeyNames="TID_ID"   OnPageIndexChanging="Gridview2_PageIndexChanging" 
                    Width="100%" ondatabound="Gridview2_DataBound" 
                     >
                    <%--    //隔行变色--%>
           
           
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
           
           
                    <PagerStyle CssClass="GridViewPagerStyle" />
  
           
              <AlternatingRowStyle />
           
           
                    <Columns>
                        <asp:BoundField DataField="TID_ID" HeaderText="盘存详情ID" SortExpression="TID_ID" 
                            Visible="False"  ReadOnly="true">
                        </asp:BoundField>
                      <asp:BoundField DataField="TID_StyleName" HeaderText="大类型号" 
                            SortExpression="TID_StyleName"   />

                        <asp:BoundField DataField="TID_ProName" HeaderText="工序" 
                            SortExpression="TID_ProName"  >
                             
                            </asp:BoundField>
                       
                        <asp:BoundField DataField="TID_Num" HeaderText="总数" 
                              SortExpression="TID_Num" ReadOnly="true">
                        </asp:BoundField>
                        <asp:BoundField DataField="TID_WO_Num" HeaderText="随工单号" 
                            SortExpression="TID_WO_Num"  >
                        </asp:BoundField>
                        
                        
                      
                       
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
                   
                    &nbsp;</td>
                   
           <td width="30%" align="left">
               <asp:Button ID="Button43" runat="server" CssClass="Button02" Height="24px" 
                    OnClick="Button_Ccl" Text="关闭" Width="70px" />     
            </td>
            </tr>
              </table>  
                </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

    </asp:Content>