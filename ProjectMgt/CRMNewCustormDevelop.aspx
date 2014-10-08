<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CRMNewCustormDevelop.aspx.cs" Inherits="ProjectManagement_CRMNewCustormDevelop"  MasterPageFile="~/Other/MasterPage.master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script> 
    <asp:UpdatePanel ID="UpdatePanel_OutsideSampleSearch" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_OutsideSampleSearch" runat="server" Visible="true">
                <fieldset>
                    <legend> 检索条件</legend>
    <table style="width: 100%;">  
         <asp:Label ID="label_QA" runat="server" Visible="False"></asp:Label>
        <tr>
        <td style="width: 15%" align="right">
                <asp:Label ID="Label1" runat="server" Text="区域："></asp:Label>
            </td>
            <td style="width: 12%" align="left">
                <asp:TextBox ID="TextBox_Factory" runat="server"> </asp:TextBox>
            </td>
            <td style="width: 12%" align="right">
                <asp:Label ID="Label2" runat="server" Text="客户名称："></asp:Label>
            </td>
            <td style="width: 12%" align="left">
               <asp:TextBox ID="TextBox1" runat="server"> </asp:TextBox>
            </td>

            <td style="width: 12%" align="right">
                <asp:Label ID="Label3" runat="server" Text="开发状态："></asp:Label>
            </td>
               <td style="height: 20px;" align="left">
               <asp:DropDownList ID="DropDownList3" runat="server"  Width="125px">
                     <asp:ListItem>请选择</asp:ListItem> 
                     <asp:ListItem>建立联系</asp:ListItem>
                     <asp:ListItem>提供样品</asp:ListItem>
                     <asp:ListItem>开发完成</asp:ListItem>    
                </asp:DropDownList>
            </td>
            </tr>
         
        <tr>
        <td align="left">
                &nbsp;</td>
            <td colspan="2" align="left">
                <asp:Button ID="Button1" runat="server" Text="检索" CssClass="Button02" Height="24px" OnClick="Button1_Sh"
                    Width="70px" />
            </td>
          
            <td colspan="2" align="left">
                
                <asp:Button ID="Button3" runat="server" Text="新增" CssClass="Button02" Height="24px" OnClick="Button3_New" Visible="true"
                    Width="70px" />
            </td>
            <td align="left" colspan="2">
               <asp:Button ID="Button2" runat="server" Text="重置" CssClass="Button02" Height="24px" OnClick="Button3_Reset" Visible="true"
                    Width="70px" /></td>
        </tr>
    </table>
     </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
 
    <asp:UpdatePanel ID="UpdatePanel_OutWeb" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <asp:Panel ID="Panel_OutWeb" runat="server" Visible="true">
            <fieldset>
                <legend>新客户开发表</legend>
                 <asp:Label ID="label_ManID" runat="server" Visible="false"></asp:Label>
                <asp:GridView ID="Gridview1"  runat="server" AutoGenerateColumns="False"
                    CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"
                    PageSize="5"   Font-Strikeout="False" GridLines="None"
                    OnRowCommand="Gridview1_RowCommand"  
                    AllowPaging="True" AllowSorting="True" 
                    DataKeyNames="CRMNCD_ID"   OnPageIndexChanging="Gridview_Project_PageIndexChanging" 
                    Width="100%" 
                    EnableModelValidation="True" 
                     >
                    <%--    //隔行变色--%>
           
           
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
           
           
                    <%--<PagerStyle CssClass="GridViewPagerStyle" />--%>
  
           
              <AlternatingRowStyle />
           
           
                    <Columns>
                    <asp:BoundField DataField="CRMNCD_ID" HeaderText="新客户开发进度ID" SortExpression="CRMNCD_ID" 
                            Visible="False">
                        </asp:BoundField>
                        <asp:BoundField DataField="CRMCIF_Name" HeaderText="客户名称" SortExpression="CRMCIF_Name" 
                           >
                        </asp:BoundField>
                       
                        <asp:BoundField DataField="CRMRBI_Name" HeaderText="区域名称" 
                            SortExpression="CRMRBI_Name" >
                             
                            </asp:BoundField>
                        <asp:BoundField DataField="CRMCSBD_Name" HeaderText="客户类别" 
                            SortExpression="CRMCSBD_Name">
                          
                        </asp:BoundField>
                        <asp:BoundField DataField="CRMNCD_DevelopState" HeaderText="开发状态" 
                            SortExpression="CRMNCD_DevelopState">
                         
                       </asp:BoundField>
                        <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="tLook1" runat="server" CommandName="Modify1" 
                                    CommandArgument='<%#Eval("CRMNCD_ID")%>'>编辑</asp:LinkButton>
                                 
                            </ItemTemplate>
                             
                        </asp:TemplateField>
                         <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="btLook2" runat="server" CommandName="Delete1" OnClientClick="return confirm('您确认删除该记录吗?')"
                                    CommandArgument='<%#Eval("CRMNCD_ID")%>'>删除</asp:LinkButton>
                                   
                            </ItemTemplate>
                            
                        </asp:TemplateField>
                       <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="btLk1" runat="server" CommandName="Analysis" 
                                    CommandArgument='<%#Eval("CRMNCD_ID")%>'>开发进度</asp:LinkButton>
                                 
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
                </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    
    <asp:UpdatePanel ID="UpdatePanel_SampleNew" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_SampleNew" runat="server" Visible="false">
                <fieldset>
                    <legend> <asp:Label ID="label_New" runat="server" Visible="true"></asp:Label></legend>
                    <asp:Label ID="label_SampleID" runat="server" Visible="false"></asp:Label>
    <table style="width: 100%;">
       
        <tr>
            <td style="width: 15%; height: 20px;" align="right">
            <asp:Label ID="Label6" runat="server" Text="客户名称："></asp:Label>
            </td>
               <td style="width: 15%; height: 20px;" align="right">
                <asp:TextBox ID="TextBox6" runat="server" Enabled="false"> </asp:TextBox>
                <asp:Label ID="Label27" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td> 
            <td style="width: 10%; height: 20px;" align="left">
                <asp:Button ID="Button4" runat="server" CssClass="Button02" Height="24px" 
                        OnClick="Button_SupplySearch" Text="选择..." Width="50px" /></td>

                        <td style="width: 10%; height: 20px;" align="right">
            <asp:Label ID="Label4" runat="server" Text="区域："></asp:Label>
            </td>
               <td style="width: 15%; height: 20px;" align="right">
                <asp:TextBox ID="TextBox2" runat="server" Enabled="false" > </asp:TextBox>
            </td> 
            <td style="width: 12%; height: 20px;" align="right">
            <asp:Label ID="Label5" runat="server" Text="客户类别："></asp:Label>
            </td>
               <td style=" height: 20px;" align="left">
                <asp:TextBox ID="TextBox3" runat="server" Enabled="false" > </asp:TextBox>
            </td> 
            </tr>
            <tr>
            
                <td  align="center" colspan="4">
                    <asp:Button ID="Button5" runat="server" CssClass="Button02" Height="24px" 
                        OnClick="Button1_Com1" Text="提交" Width="70px" />
                        </td>
                        <td colspan="4" align="center">
                    <asp:Button ID="Button8" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="Button_Cancel"
                    Width="70px" />
                </td>
                <td>
                    &nbsp;&nbsp;
                </td>
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
                <legend>客户查询</legend>
                 <asp:Label ID="label_SupplyID" runat="server" Visible="false"></asp:Label>
                <asp:GridView ID="Gridview_PMSupply"  runat="server" AutoGenerateColumns="False"
                    CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"
                    PageSize="5" 
                    AllowPaging="True" AllowSorting="True" DataKeyNames="CRMCIF_ID"   OnPageIndexChanging="Gridview_PMSupply_PageIndexChanging" 
                    Width="100%"  Font-Strikeout="False" GridLines="None"
                    EnableModelValidation="True" 
                    >
                    <%--    //隔行变色--%>
           
           
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
           
           
                    <%--<PagerStyle CssClass="GridViewPagerStyle" />--%>
           
           
              <AlternatingRowStyle />
           
           
                    <Columns>
                   <asp:TemplateField >
                            <ItemTemplate >
                                <asp:RadioButton ID="RadioButtonMarkup" runat="server"></asp:RadioButton>
                               
  
                            </ItemTemplate>
                            <ItemStyle />
                        </asp:TemplateField>
                        
                        <asp:BoundField DataField="CRMCIF_ID" HeaderText="客户ID" 
                            SortExpression="CRMCIF_ID" Visible="False">
                        <ItemStyle  />
                        </asp:BoundField>
                       
                        <asp:BoundField DataField="CRMCIF_Name" HeaderText="客户名称" 
                            SortExpression="CRMCIF_Name" />
                        <asp:BoundField DataField="CRMRBI_Name" HeaderText="区域名称" 
                            SortExpression="CRMRBI_Name" />
                       <asp:BoundField DataField="CRMCSBD_Name" HeaderText="客户类别" 
                            SortExpression="CRMCSBD_Name" />
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
               
                <table width="100%">
                <tr>
                <td width="34%" align="right" >
                    
                <asp:Button ID="Button6" runat="server" Text="提交" CssClass="Button02" Height="24px" OnClick="Button_ComSP"
                    Width="70px" />
            </td>
           <td style="width: 20%" align="center">
                &nbsp;</td>
                    
                   <td style="width: 20%" align="right">
                <asp:Button ID="Button7" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="Button_CancelSP"
                    Width="70px" />
                </td> 
             <td width="30%" align="left">
               
                
            </td>
            
                </tr>
                </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    
    <asp:UpdatePanel ID="UpdatePanel_NewProgram" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_NewProgram" runat="server" Visible="false">
                <fieldset>
                    <legend>  <asp:Label ID="label9" runat="server" Visible="true"></asp:Label></legend>
    <table style="width: 100%;">
        
        <tr>
          <td style="width: 6%" align="right">
                <asp:Label ID="Label10" runat="server" Text="开发状态："></asp:Label>
            </td>
               <td style="width: 20%; height: 20px;" align="left">
               <asp:DropDownList ID="DropDownList1" runat="server"  Width="125px">
                     <asp:ListItem>请选择</asp:ListItem> 
                     <asp:ListItem>建立联系</asp:ListItem>
                     <asp:ListItem>提供样品</asp:ListItem>
                     <asp:ListItem>开发完成</asp:ListItem>    
                </asp:DropDownList>
                <asp:Label ID="Label7" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td></td>
        </tr>
         <tr>
            <td align="right">
                <asp:Label ID="Label16" runat="server" Text="具体情况："></asp:Label>
                <br/>
                <asp:Label ID="Label_XZ2" runat="server" Text="(200字以内)"></asp:Label>
            </td>
            
            <td align="left"colspan="2">
                <asp:TextBox runat="server" ID="TextBox10" Height="81px" Width="90%" MaxLength="200" TextMode="MultiLine" 
                 onkeyup="this.value = this.value.substring(0, 200)" onafterpaste="this.value = this.value.substring(0, 200)"
                          ></asp:TextBox>
                          <asp:Label ID="Label11" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td> 
            </tr>
            
        
        <tr>
        <td align="right">
           
        </td>
            <td align="center">
                
                <asp:Button ID="Button11" runat="server" Text="提交" CssClass="Button02" Height="24px" OnClick="Button_Rocky" Visible="true"
                    Width="70px" />
            </td>
            <td style="width: 15%" align="left">
               <asp:Button ID="Button12" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="Button_Mel" Visible="true"
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
                <legend><asp:Label ID="label8" runat="server" Visible="true"></asp:Label></legend>
                 <asp:Label ID="label_ProgramID" runat="server" Visible="false"></asp:Label>
                <asp:GridView ID="Gridview2"  runat="server" AutoGenerateColumns="False"
                    CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"
                    PageSize="5" 
                    AllowPaging="True" AllowSorting="True" DataKeyNames="CRMNCD_ID"   
                    Width="100%"  Font-Strikeout="False" GridLines="None"
                    EnableModelValidation="True" 
                   
                    >
                    <%--    //隔行变色--%>
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                    <%--<PagerStyle CssClass="GridViewPagerStyle" />--%>
              <AlternatingRowStyle />
                    <Columns>
                        <asp:BoundField DataField="CRMNCD_ID" HeaderText="新客户开发进度ID" 
                            SortExpression="CRMNCD_ID" Visible="False">
                        <ItemStyle Width="100px" />
                        </asp:BoundField>
                       
                        <asp:BoundField DataField="CRMNCD_DevelopState" HeaderText="开发状态" 
                            SortExpression="CRMNCD_DevelopState" />
                        <asp:BoundField DataField="CRMNCD_DetailCondition" HeaderText="具体情况" 
                            SortExpression="CRMNCD_DetailCondition" />
                       <asp:BoundField DataField="CRMNCD_Time" HeaderText="时间" 
                            SortExpression="CRMNCD_Time" />
                             <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="LBLook1" runat="server" CommandName="Modify" 
                                    CommandArgument='<%#Eval("CRMNCD_ID")%>'>编辑</asp:LinkButton>
                                 
                            </ItemTemplate>
                             
                        </asp:TemplateField>
                         <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="LBLook2" runat="server" CommandName="Delete" OnClientClick="return confirm('您确认删除该记录吗?')"
                                    CommandArgument='<%#Eval("CRMNCD_ID")%>'>删除</asp:LinkButton>
                                   
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
               
                <table width="100%">
               
                </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
          </asp:Content>
