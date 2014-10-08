<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PMSupplyMaterial.aspx.cs" Inherits="ProjectManagement_PMSupplyMaterial"  MasterPageFile="~/Other/MasterPage.master"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script> 
     <asp:UpdatePanel ID="UpdatePanel_SupplyRule" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_SupplyRule" runat="server" Visible="false">
                <fieldset>
                    <legend>采购规则
                   
                    </legend>
                     <asp:Label ID="label_Setting" runat="server" Visible="false"></asp:Label>
    <table style="width: 100%;">
    
            <tr>
          
            
            <td  align="center">
            <asp:Label ID="TextBox1" runat="server" Width="90%" ForeColor="mediumblue" Font-Bold="true" a></asp:Label>
               <%-- <asp:TextBox runat="server" ID="TextBox1" Height="81px" Width="90%" MaxLength="200" TextMode="MultiLine" Enabled="false">
                </asp:TextBox>--%>
            </td> 
        </tr>
    </table>
     </fieldset>
       </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
     
    <asp:UpdatePanel ID="UpdatePanel_SupplySearch" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_SupplySearch" runat="server" Visible="true">
                <fieldset>
                    <legend> 检索条件</legend>
                    <asp:Label ID="labelcodition" runat="server" Visible="false"></asp:Label>
                     <asp:Label ID="label_Department" runat="server" Visible="false"></asp:Label>
                     <asp:Label ID="label_MaterialID" runat="server" Visible="false"></asp:Label>
                     <asp:Label ID="label_PMPAM_ID" runat="server" Visible="false"></asp:Label>
                     <asp:Label ID="label_Role" runat="server" Visible="false"></asp:Label>
                     <asp:Label ID="label_pagestate" runat="server" Visible="false"></asp:Label>
                     <asp:Label ID="label_IMUC_ID" runat="server" Visible="false"></asp:Label>
    <table style="width: 100%;">
        
         
        <tr>
            <td style="width: 15%" align="right">
                <asp:Label ID="Label2" runat="server" Text="部门："></asp:Label>
            </td>
           <td style="width: 12%; height: 20px;" align="left">
                <asp:TextBox ID="TextBox2" runat="server"> </asp:TextBox>
            </td>
      <td  style="width: 7%" align="left">
                <asp:Button ID="Button4" runat="server" Text="选择..." CssClass="Button02" Height="24px" OnClick="Button_Select1"
                    Width="50px" />
            </td>
             <td style="width: 10%" align="right">
                <asp:Label ID="Label3" runat="server" Text="状态："></asp:Label>
            </td>
             <td style="width: 12%" align="left">
                <asp:DropDownList ID="DropDownList2" runat="server"  Width="130px">
                    <asp:ListItem>请选择</asp:ListItem>
                    <asp:ListItem>未制定</asp:ListItem>
                    <asp:ListItem>制定中</asp:ListItem>
                    <asp:ListItem>已提交</asp:ListItem>
                    <asp:ListItem>部门主管审核通过</asp:ListItem>
                    <asp:ListItem>部门主管审核驳回</asp:ListItem>
                    <asp:ListItem>人事部审核通过</asp:ListItem>
                    <asp:ListItem>人事部审核驳回</asp:ListItem>
                    <asp:ListItem>部门副总审核通过</asp:ListItem>
                    <asp:ListItem>部门副总审核驳回</asp:ListItem>
                    <asp:ListItem>财务主管审核通过</asp:ListItem>
                    <asp:ListItem>财务主管审核驳回</asp:ListItem>
                    <asp:ListItem>技术副总审核通过</asp:ListItem>
                    <asp:ListItem>技术副总审核驳回</asp:ListItem>
                    <asp:ListItem>财务总监审核通过</asp:ListItem>
                    <asp:ListItem>财务总监审核驳回</asp:ListItem>
                </asp:DropDownList>
            </td>
              <td align="right" style="width: 10%">
                    <asp:Label ID="Label8" runat="server" Text="申请单号："></asp:Label>
                </td>
                <td align="left" >
                    <asp:TextBox ID="SupplyID" runat="server"> </asp:TextBox>
                </td>

            </tr>
           <tr>
            <td  align="right">
                <asp:Label ID="Label10" runat="server" Text="申请人："></asp:Label>
            </td>
           <td style="  height: 20px;" align="left">
                <asp:TextBox ID="TextBox10" runat="server"> </asp:TextBox>
            </td>
             <td style=" align="right">
                
            </td>
            <td  align="right">
                <asp:Label ID="Label28" runat="server" Text="申请时间："></asp:Label>
            </td>
       <td>
       <asp:TextBox ID="TextBox_SPTime2" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D ',true)"  ></asp:TextBox>
       </td>
            <td  align="center">
                <asp:Label ID="Label" runat="server" Text="至："></asp:Label>
            </td>
            <td  align="left">
                <asp:TextBox ID="TextBox_SPTime3" runat="server" 
                    onfocus="new WdatePicker(this,'%Y-%M-%D ',true)"  ></asp:TextBox>
            </td>
           </tr>
        
        <tr>
         <td   align="left">
                &nbsp;</td>
            <td colspan="2" align="center">
                <asp:Button ID="Button1" runat="server" Text="检索" CssClass="Button02" Height="24px" OnClick="Button_Sh1"
                    Width="70px" />
            </td>
          
            <td colspan="2" align="center">
                
                <asp:Button ID="Button3" runat="server" Text="新增" CssClass="Button02" Height="24px" OnClick="Button_New" Visible="true"
                    Width="70px" />
            </td>
            <td  align="center" colspan="2">
               <asp:Button ID="Button2" runat="server" Text="重置" CssClass="Button02" Height="24px" OnClick="Button_Reset" Visible="true"
                    Width="70px" /></td>
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
     <asp:UpdatePanel ID="UpdatePanel_Organization" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <asp:Panel ID="Panel_Organization" runat="server" Visible="false">
            <fieldset>
                <legend>
                <asp:Label ID="label_arrange" runat="server" Visible="true"></asp:Label>
                </legend>
                <asp:GridView ID="Gridview_Organization"  runat="server" AutoGenerateColumns="False"
                    CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"
                    Font-Strikeout="False" GridLines="None" PageSize="10" 
                    AllowPaging="True" AllowSorting="True" DataKeyNames="BDOS_Name "   OnPageIndexChanging="Gridview_Organization_PageIndexChanging" 
                    Width="100%" 
                    EnableModelValidation="True" 
                    onrowdatabound="Gridview_Organization_RowDataBound">
                    <%--    //隔行变色--%>
           
           
              <AlternatingRowStyle />
           
           
            <PagerStyle  ForeColor="Black" 
                 HorizontalAlign="Center" CssClass="GridViewPagerStyle" />
           
           
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
           
           
                    <Columns>
                   <asp:TemplateField >
                            <ItemTemplate >
                                <asp:RadioButton ID="RadioButtonMarkup" runat="server" GroupName="GN"></asp:RadioButton>
                               
  
                            </ItemTemplate>
                            <ItemStyle   />
                        </asp:TemplateField>
                        
                        <asp:BoundField DataField="BDOS_Name" HeaderText="部门名称" 
                            SortExpression="BDOS_Name">
                        <ItemStyle  />
                        </asp:BoundField>
                       
                    </Columns>
               <EmptyDataTemplate>
              <asp:Label ID="Label50" runat="server" Text="无相关记录！"></asp:Label>
             </EmptyDataTemplate>
                    <FooterStyle CssClass="GridViewFooterStyle" />
                     <HeaderStyle CssClass="GridViewHead" />
           
           
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
                <td style="width:15%" align="center">
                &nbsp;</td>
                <td width="20%" align="right" >
                    
                <asp:Button ID="Button5" runat="server" Text="提交" CssClass="Button02" Height="24px" OnClick="Button_Com1"
                    Width="70px" />
            </td>
           <td style="width: 20%" align="center">
                &nbsp;</td>
                    
                   
             <td width="20%" align="left">
               
                <asp:Button ID="Button6" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="Button_Cancel1"
                    Width="70px" />
            </td>
            <td style="width:15%" align="center">
                &nbsp;</td>
               
                </tr>
                </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
     
      <asp:UpdatePanel ID="UpdatePanel_PMPurchaseApplyMain" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <asp:Panel ID="Panel_PMPurchaseApplyMain" runat="server" Visible="true">
            <fieldset>
                <legend>采购申请制定单</legend>
                <asp:GridView ID="Gridview2"  runat="server" AutoGenerateColumns="False"
                    CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"
                    Font-Strikeout="False" GridLines="None" PageSize="10" 
                    OnRowCommand="Gridview_Project_RowCommand"  
                    AllowPaging="True" AllowSorting="True" DataKeyNames="PMPAM_ID"   OnPageIndexChanging="Gridview_Project_PageIndexChanging" 
                    Width="100%" 
                    EnableModelValidation="True" onrowdatabound="Gridview2_RowDataBound"  
                     >
                    <%--    //隔行变色--%>

           
                    <FooterStyle CssClass="GridViewFooterStyle" />
                    <HeaderStyle CssClass="GridviewHead"
                        HorizontalAlign="Center" />
           
           
              <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
            
           
           
                    <Columns>
                        <asp:BoundField DataField="PMPAM_ID" HeaderText="采购申请ID " SortExpression="PMPAM_ID" 
                            Visible="False">
                           
                        </asp:BoundField>
                        <asp:BoundField DataField="PMPAM_ApplyNum" HeaderText="申请单号" 
                            SortExpression="PMPAM_ApplyNum" >
                            </asp:BoundField>
                        <asp:BoundField DataField="PMPAM_State" HeaderText="状态" SortExpression="PMPAM_State">
                    
                        </asp:BoundField>
                        <asp:BoundField DataField="PMPAM_Department" HeaderText="部门" SortExpression="PMPAM_Department">
                        </asp:BoundField>
                         <asp:BoundField DataField="PMPAM_ApplyMan" HeaderText="申请人" SortExpression="PMPAM_ApplyMan">
                        </asp:BoundField>

                        <asp:BoundField DataField="PMPAM_ApplyTime" HeaderText="申请时间" 
                            SortExpression="PMPAM_ApplyTime" DataFormatString="{0:yyyy-MM-dd}"/>
                        <asp:BoundField DataField="PMPAM_EmergencyPur" HeaderText="是否紧急采购" 
                            SortExpression="PMPAM_EmergencyPur" />

                        <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="btnLook1" runat="server" CommandName="Check1" 
                                    CommandArgument='<%#Eval("PMPAM_ID")%>'>查看</asp:LinkButton>
                                 
                            </ItemTemplate>
                            
                        </asp:TemplateField>
                         <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="btnLook2" runat="server" CommandName="Check2" 
                                    CommandArgument='<%#Eval("PMPAM_ID")%>'>审核</asp:LinkButton>
                                   
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                         <ItemTemplate >
                                <asp:LinkButton ID="btnLook3" runat="server" CommandName="Check3" 
                                    CommandArgument='<%#Eval("PMPAM_ID")%>'>制定</asp:LinkButton>
                                   
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                        <ItemTemplate >
                                <asp:LinkButton ID="btnLook4" runat="server" CommandName="Delete1" OnClientClick="return confirm('您确认删除该记录吗?')"
                                    CommandArgument='<%#Eval("PMPAM_ID")%>'>删除</asp:LinkButton>
                                   
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                        <ItemTemplate >
                                <asp:LinkButton ID="btnLok4" runat="server" CommandName="Confirm" 
                                    CommandArgument='<%#Eval("PMPAM_ID")%>'>确认为紧急订单</asp:LinkButton>
                                   
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField>
                        <ItemTemplate >
                                <asp:LinkButton ID="btnLok5" runat="server" CommandName="LConfirm" 
                                    CommandArgument='<%#Eval("PMPAM_ID")%>'>查看审核意见</asp:LinkButton>
                                   
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
               <EmptyDataTemplate>
              <asp:Label ID="Label50" runat="server" Text="无相关记录！"></asp:Label>
             </EmptyDataTemplate>

           
                        <FooterStyle CssClass="GridViewFooterStyle" />

           
                        <HeaderStyle CssClass="GridViewHead" />
           
           
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
                </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
 
     <asp:UpdatePanel ID="UpdatePanel_PurchaseApply" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_PurchaseApply" runat="server" Visible="false">
                <fieldset>
                    <legend>
                    <asp:Label ID="label1" runat="server" Visible="true" ></asp:Label>
                    </legend>
    <table style="width: 100%;">
       
        <tr>
          <td style="width: 15%" align="right">
                <asp:Label ID="Label7" runat="server" Text="部门："></asp:Label>
            </td>
           <td style="width: 19%; height: 20px;" align="left">
                <asp:TextBox ID="TextBox3" runat="server" Enabled="false" > </asp:TextBox>
            </td>
            <td style="width: 10%" align="right">
                <asp:Label ID="Label15" runat="server" Text="单位："></asp:Label>
            </td>
            <td style="width: 18%" align="left">
                <asp:TextBox ID="Unit" runat="server" Enabled="false"> </asp:TextBox>
            </td>
            <td style="width: 10%; height: 20px;" align="right">
            <asp:Label ID="Label5" runat="server" Text="数量："></asp:Label>
            </td>
               <td style=" height: 20px;" align="left">
                <asp:TextBox ID="TextBox4" runat="server"
                onkeyup="this.value=this.value.replace(/[^0-9.]/g,'')"
                onafterpaste="this.value=this.value.replace(/[^0-9.]/g,'')"> </asp:TextBox>
            <asp:Label ID="Label11" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td> 
            </tr>
            <tr>
          <td  align="right">
                <asp:Label ID="Label29" runat="server" Text="需要时间："></asp:Label>
            </td>
       <td style="width: 19%">
       <asp:TextBox ID="TextBox11" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D ',true)"  ></asp:TextBox>
       <asp:Label ID="Label32" runat="server" Text="*" ForeColor="Red"></asp:Label>
       </td>
                 <td style="width: 10%; height: 20px;" align="right">
            <asp:Label ID="Label34" runat="server" Text="参考价格："></asp:Label>
            </td>
               <td style=" height: 20px;" align="left">
                <asp:TextBox ID="TextBox12" runat="server"
                onkeyup="this.value=this.value.replace(/[^0-9.]/g,'')"
                onafterpaste="this.value=this.value.replace(/[^0-9.]/g,'')"> </asp:TextBox>
            <asp:Label ID="Label35" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td> 
              <td align="right">
                <asp:Label ID="Label4" runat="server" Text="物料名称："></asp:Label>
            </td>
           <td style="height: 20px; width: 18%;" align="left">
                <asp:TextBox ID="TextBox5" runat="server" Enabled="false"> </asp:TextBox>
            <asp:Label ID="Label43" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
      <td  align="left">
                <asp:Button ID="Button10" runat="server" Text="选择..." CssClass="Button02" Height="24px" OnClick="Button_Select3"
                    Width="50px" />
            </td>
            
            </tr>
            <tr>
            <td  align="right">
                <asp:Label ID="Label6" runat="server" Text="特性要求："></asp:Label>
                <br/>
                <asp:Label ID="Labe7" runat="server" Text="(200字以内)"></asp:Label>
            </td>
            
            <td  align="left"colspan="7">
                <asp:TextBox runat="server" ID="TextBox6" Height="81px" Width="90%" MaxLength="200" TextMode="MultiLine"   
                 onkeyup="this.value = this.value.substring(0, 200)" onafterpaste="this.value = this.value.substring(0, 200)"
                ></asp:TextBox>
                <asp:Label ID="Label33" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td> 
            </tr>
             <tr>
            <td  align="right">
                <asp:Label ID="Label57" runat="server" Text="备注："></asp:Label>
                <br/>
                <asp:Label ID="Label58" runat="server" Text="(200字以内)"></asp:Label>
            </td>
            
            <td  align="left"colspan="7">
                <asp:TextBox runat="server" ID="TextBox18" Height="81px" Width="90%" MaxLength="200" TextMode="MultiLine"   
                 onkeyup="this.value = this.value.substring(0, 200)" onafterpaste="this.value = this.value.substring(0, 200)"
                ></asp:TextBox>
            </td> 
            </tr>
            <tr>
            <td  align="center">
                   
                    &nbsp;</td>
                <td  align="center" colspan="2">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button7" runat="server" CssClass="Button02" Height="24px" 
                        OnClick="Button_Com2" Text="提交" Width="70px" />
                        </td>
                        <td colspan="2" align="center">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button8" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="Button_Cancel2"
                    Width="70px" />
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
     <asp:UpdatePanel ID="UpdatePanel_Material" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <asp:Panel ID="Panel_Material" runat="server" Visible="false">
            <fieldset>
                <legend>
                <asp:Label ID="label9" runat="server" Visible="true" Text="物料表" ></asp:Label>
                </legend>
                 <table style="width: 100%;">
       
        <tr>
        <td colspan="1" >
             
            </td>
             <td colspan="1" >
             
            </td>
        <td colspan="1" align="right">
                <asp:Label ID="Label39" runat="server" Text="物料名称："></asp:Label>
            </td>
            <td colspan="1" align="left">
                <asp:TextBox ID="TextBox16" runat="server"> </asp:TextBox>
            </td>
            <td colspan="1" align="right">
                <asp:Label ID="Label56" runat="server" Text="规格型号："></asp:Label>
            </td>
            <td colspan="1" align="left">
                <asp:TextBox ID="TextBox17" runat="server"> </asp:TextBox>
            </td>
           
            <td colspan="1" >
            
            </td>
           
            </tr>
            <tr>
            
                <td  align="center" colspan="4">
                    <asp:Button ID="Button25" runat="server" CssClass="Button02" Height="24px" 
                        OnClick="Button1_KiM" Text="检索" Width="80px" />
                        </td>
                        <td colspan="3" align="center">
                    <asp:Button ID="Button26" runat="server" Text="重置" CssClass="Button02" Height="24px" OnClick="Button_CoM"
                    Width="80px" />
                </td>
              
                </tr>
       
    </table>
                <asp:GridView ID="Gridview1"  runat="server" AutoGenerateColumns="False"
                    CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"
                    Font-Strikeout="False" GridLines="None" PageSize="10" 
                    AllowPaging="True" AllowSorting="True" DataKeyNames="IMMBD_MaterialID,IMUC_ID"   OnPageIndexChanging="Gridview1_PageIndexChanging" 
                    Width="100%" 
                    EnableModelValidation="True" 
                    onrowdatabound="Gridview1_RowDataBound">
                    <%--    //隔行变色--%>
           
           
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
           
           
                    <PagerStyle CssClass="GridViewPagerStyle" />
           
           
              <AlternatingRowStyle />
           
           
                    <Columns>
                   <asp:TemplateField >
                            <ItemTemplate >
                                <asp:RadioButton ID="RadioButtonMarkup" runat="server" GroupName="GN"></asp:RadioButton>
                               
  
                            </ItemTemplate>
                            <ItemStyle  />
                        </asp:TemplateField>
                        
                        <asp:BoundField DataField="IMMBD_MaterialName" HeaderText="物料名称" 
                            SortExpression="IMMBD_MaterialName">
                        <ItemStyle />
                        </asp:BoundField>
                       
                        <asp:BoundField DataField="IMMBD_MaterialID" HeaderText="物料ID" 
                            SortExpression="IMMBD_MaterialID" Visible="False" />
                       
                        <asp:BoundField DataField="IMMBD_SpecificationModel" HeaderText="规格型号" 
                            SortExpression="IMMBD_SpecificationModel" Visible="true" />
                       
                        <asp:BoundField DataField="IMUC_ID" HeaderText="物料单位ID" 
                            SortExpression="IMUC_ID" Visible="False" />
                       
                        <asp:BoundField DataField="UnitName" HeaderText="单位" 
                            SortExpression="UnitName" Visible="true" />
                    </Columns>
               <EmptyDataTemplate>
              <asp:Label ID="Label50" runat="server" Text="无相关记录！"></asp:Label>
             </EmptyDataTemplate>
                    <FooterStyle CssClass="GridViewFooterStyle" />
                     <HeaderStyle CssClass="GridViewHead" />
           
           
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
                <td width="40%" align="right" >
                    
                <asp:Button ID="Button11" runat="server" Text="提交" CssClass="Button02" Height="24px" OnClick="Button_Com3"
                    Width="70px" />
                    &nbsp;&nbsp;&nbsp;
            </td>
           <td style="width: 20%" align="center">
                &nbsp;</td>
                    
                   
             <td width="30%" align="left">
               
                 &nbsp;
               
                <asp:Button ID="Button12" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="Button_Cancel3"
                    Width="70px" />
            </td>
             <td width="20%" align="center">
                &nbsp;</td>
                
                </tr>
                </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
     
     <asp:UpdatePanel ID="UpdatePanel_ApplyDetail" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <asp:Panel ID="Panel_ApplyDetail" runat="server" Visible="false" 
                style="margin-top: 1px">
            <fieldset>
                <legend>
                <asp:Label ID="label12" runat="server" Visible="true" ></asp:Label>
                </legend>
                 <asp:Label ID="label_RTX" runat="server" Visible="false" ></asp:Label>
                <asp:GridView ID="Gridview3"  runat="server" AutoGenerateColumns="False"
                    CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"
                    Font-Strikeout="False" GridLines="None" 
                    AllowPaging="True" AllowSorting="True" DataKeyNames="PMPAD_ID"   OnPageIndexChanging="Gridview3_PageIndexChanging" 
                    Width="100%" 
                    ondatabound="Gridview3_DataBound" onrowcommand="Gridview3_RowCommand" OnRowDataBound="Gridview3_RowDataBound">
                    <%--    //隔行变色--%>
           
           
              <AlternatingRowStyle />
           
           
            <PagerStyle  ForeColor="Black" 
                 HorizontalAlign="Center" CssClass="GridViewPagerStyle" />
           
           
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
           
           
                    <Columns>
                        
                        <asp:BoundField DataField="IMMT_MaterialType" HeaderText="物料类别" 
                            SortExpression="IMMT_MaterialType">
                        <ItemStyle Width="100px" />
                        </asp:BoundField>
                       
                        <asp:BoundField DataField="IMMBD_SpecificationModel" HeaderText="规格型号" 
                            SortExpression="IMMBD_SpecificationModel" />
                        <asp:BoundField DataField="IMMBD_MaterialName" HeaderText="物料名称" 
                            SortExpression="IMMBD_MaterialName" />
                        <asp:BoundField DataField="PMPAD_Num" HeaderText="数量" 
                            SortExpression="PMPAD_Num" />
                        <asp:BoundField DataField="UnitName" HeaderText="单位" 
                            SortExpression="UnitName" />
                        <asp:BoundField DataField="PMPAD_Require" HeaderText="特性要求" 
                            SortExpression="PMPAD_Require" />
                        <asp:BoundField DataField="PMPAM_ApplyMan" HeaderText="申请人" 
                            SortExpression="PMPAM_ApplyMan" />
                       
                        <asp:BoundField DataField="PMPAD_NeedTime" HeaderText="需要时间" 
                            SortExpression="PMPAD_NeedTime" DataFormatString="{0:yyyy-MM-dd}" />
                       
                        <asp:BoundField DataField="PMPAD_PriceIndication" HeaderText="参考价格" SortExpression="PMPAD_PriceIndication" />
                        <asp:BoundField DataField="PMPAD_Remark" HeaderText="备注" SortExpression="PMPAD_Remark" />
                        <asp:TemplateField>
                         <ItemTemplate >
                                <asp:LinkButton ID="btnLk1" runat="server" CommandName="Look1" OnClientClick="return confirm('您确认删除该记录吗?')"
                                    CommandArgument='<%#Eval("PMPAD_ID")%>'>删除</asp:LinkButton>
                                 
                            </ItemTemplate>
                        </asp:TemplateField>
                       <asp:TemplateField>
                         <ItemTemplate >
                                <asp:LinkButton ID="btnLk2" runat="server" CommandName="Look2" 
                                    CommandArgument='<%#Eval("PMPO_PurchaseOrderID")%>'>查看采购进度</asp:LinkButton>
                                 
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="PMPAD_ID" HeaderText="申请单详细ID" 
                            SortExpression="PMPAD_ID" Visible="False" />
                       <asp:BoundField DataField="PMPO_PurchaseOrderID" HeaderText="采购订单ID" 
                            SortExpression="PMPO_PurchaseOrderID" Visible="False" />
                        <asp:BoundField DataField="PMPAD_QuMan" HeaderText="去除人"  />
                        <asp:BoundField DataField="PMPAD_QuTime" HeaderText="去除时间" DataFormatString="{0:yyyy-MM-dd}" />
                         <asp:TemplateField Visible="false">
                         <ItemTemplate >
                                <asp:LinkButton ID="Qu2" runat="server" CommandName="Qu2" 
                                    CommandArgument='<%#Eval("PMPAD_ID")%>'>单条去除</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
               <EmptyDataTemplate>
              <asp:Label ID="Label50" runat="server" Text="无相关记录！"></asp:Label>
             </EmptyDataTemplate>
                    <FooterStyle CssClass="GridViewFooterStyle" />
                     <HeaderStyle CssClass="GridViewHead" />
           
           
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
                <td width="40%" align="right" >
                    
                <asp:Button ID="Button13" runat="server" Text="提交" CssClass="Button02" Height="24px" OnClick="Button_Com4"
                    Width="70px" />
                    &nbsp;&nbsp;
            </td>

           <td style="width: 20%" align="center">
           <asp:Button ID="Button9" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="Button_Close" Visible="false" 
                    Width="70px" />
                &nbsp;</td>
                    
                   
             <td width="30%" align="left">
               
                 &nbsp;&nbsp;
               
                <asp:Button ID="Button14" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="Button_Cancel4"
                    Width="70px" />
            </td>
            <td style="width: 100%" >
                </td>
                <td style="width: 100%" >
                </td>
                </tr>
                </table>
                </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
      <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <asp:Panel ID="Panel1" runat="server" Visible="false" 
                style="margin-top: 1px">
            <fieldset>
                <legend>
                <asp:Label ID="label59" runat="server" Visible="true" ></asp:Label>
                </legend>
                 
                <asp:GridView ID="Gridview4"  runat="server" AutoGenerateColumns="False"
                    CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"
                    Font-Strikeout="False" GridLines="None" 
                    AllowPaging="True" AllowSorting="True" DataKeyNames="PMPO_PurchaseOrderNum"  
                    Width="100%" >
                    <%--    //隔行变色--%>
           
           
              <AlternatingRowStyle />
           
           
            <PagerStyle  ForeColor="Black" 
                 HorizontalAlign="Center" CssClass="GridViewPagerStyle" />
           
           
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
           
           
                    <Columns>
                        
                        <asp:BoundField DataField="PMPO_PurchaseOrderNum" HeaderText="采购订单号" 
                            SortExpression="PMPO_PurchaseOrderNum">
                        
                        </asp:BoundField>
                       
                        <asp:BoundField DataField="PMPO_ArriverCondition" HeaderText="到货情况" 
                            SortExpression="PMPO_ArriverCondition" />
                        <asp:BoundField DataField="PMPO_PlanArrTime" HeaderText="预到货日期" 
                            SortExpression="PMPO_PlanArrTime" />
                        <asp:BoundField DataField="PMPO_State" HeaderText="采购订单状态" 
                            SortExpression="PMPO_State" />
                        
                        
                    </Columns>
               <EmptyDataTemplate>
              <asp:Label ID="Label50" runat="server" Text="无相关记录！"></asp:Label>
             </EmptyDataTemplate>
                    <FooterStyle CssClass="GridViewFooterStyle" />
                     <HeaderStyle CssClass="GridViewHead" />
           
           
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
                <td width="40%" align="right" >
                    &nbsp;&nbsp;
            </td>

           <td style="width: 20%" align="center">
           <asp:Button ID="Button17" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="Button_JD" Visible="true" 
                    Width="70px" />
                &nbsp;</td>
                    
                   
             <td width="30%" align="left">
               
                 &nbsp;&nbsp;
               
                
            </td>
            <td style="width: 100%" >
                </td>
                <td style="width: 100%" >
                </td>
                </tr>
                </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

      <asp:UpdatePanel ID="UpdatePanel1_Check" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1_Check" runat="server" Visible="False">
                <fieldset>
                    <legend> 
                    <asp:Label ID="label_DPCheck" runat="server" Visible="true"></asp:Label>
                    </legend>
                     <asp:Label ID="label_RTX1" runat="server" Visible="false"></asp:Label>
                     <asp:Label ID="label_RTX_P" runat="server" Visible="false"></asp:Label>
    <table style="width: 100%;">
   
   
                    <tr>
                        <td align="center" colspan="1">
                            <asp:Label ID="Label13" runat="server" Text="部门主管审核" Visible="False"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="label_DPCheckResult" runat="server" Visible="False"></asp:Label>
                        </td>
                        <td align="right" colspan="1">
                            <asp:Label ID="Label14" runat="server" Text="审核人：" Visible="false"></asp:Label>
                        </td>
                        <td align="left" colspan="1">
                            <asp:Label ID="label_DPCheckName" runat="server" Visible="False"></asp:Label>
                        </td>
                        <td align="center" colspan="1">
                            <asp:Label ID="label1_DPCheckTime" runat="server" Visible="False"></asp:Label>
                        </td>
                        <td align="center" colspan="1">
                        </td>
                        <td align="center" colspan="1">
                        </td>
                        <td align="center" colspan="1">
                        </td>
        </tr>

        <tr>
            <td align="center" colspan="1">
                <asp:Label ID="Label16" runat="server" Text="审核意见：<br/>（200字以内）" Visible="False"></asp:Label>
              <%--  <br />
                <asp:Label ID="Label20" runat="server" Text="（200字以内）" Visible="False">
                 </asp:Label>--%>
            </td>
            <td align="left" colspan="6" style="width: 17%">
                <asp:TextBox ID="TextBox8" runat="server" Enabled="True" Height="58px" MaxLength="200" TextMode="MultiLine"   
                 onkeyup="this.value = this.value.substring(0, 200)" onafterpaste="this.value = this.value.substring(0, 200)" Visible="False"
                    Width="665px"></asp:TextBox>
            </td>
        </tr>
         <tr>
                        <td align="center" colspan="1">
                            <asp:Label ID="Label20" runat="server" Text="人事部审核" Visible="False"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="label51" runat="server" Visible="False"></asp:Label>
                        </td>
                        <td align="right" colspan="1">
                            <asp:Label ID="Label52" runat="server" Text="审核人：" Visible="false"></asp:Label>
                        </td>
                        <td align="left" colspan="1">
                            <asp:Label ID="label53" runat="server" Visible="False"></asp:Label>
                        </td>
                        <td align="center" colspan="1">
                            <asp:Label ID="label54" runat="server" Visible="False"></asp:Label>
                        </td>
                        <td align="center" colspan="1">
                        </td>
                        <td align="center" colspan="1">
                        </td>
                        <td align="center" colspan="1">
                        </td>
        </tr>

        <tr>
            <td align="center" colspan="1">
                <asp:Label ID="Label55" runat="server" Text="审核意见：<br/>（200字以内）" Visible="False"></asp:Label>
              <%--  <br />
                <asp:Label ID="Label20" runat="server" Text="（200字以内）" Visible="False">
                 </asp:Label>--%>
            </td>
            <td align="left" colspan="6" style="width: 17%">
                <asp:TextBox ID="TextBox15" runat="server" Enabled="True" Height="58px" MaxLength="200" TextMode="MultiLine"   
                 onkeyup="this.value = this.value.substring(0, 200)" onafterpaste="this.value = this.value.substring(0, 200)" Visible="False"
                    Width="665px"></asp:TextBox>
            </td>
        </tr>
     <tr>
            <td align="center" colspan="1">
                <asp:Label ID="Label36" runat="server" Text="部门副总审核" Visible="False"></asp:Label>
            </td>
            <td align="left">
                            <asp:Label ID="label37" runat="server" Visible="False"></asp:Label>
                        </td>
                        <td align="right" colspan="1">
                            <asp:Label ID="Label38" runat="server" Text="审核人：" Visible="false"></asp:Label>
                        </td>
                        <td align="left" colspan="1">
                            <asp:Label ID="label40" runat="server" Visible="False"></asp:Label>
                        </td>
                        <td align="center" colspan="1">
                            <asp:Label ID="label41" runat="server" Visible="False"></asp:Label>
                        </td>
        </tr>
        <tr>
            <td align="center" colspan="1">
                <asp:Label ID="Label42" runat="server" Text="审核意见：<br/>（200字以内）" Visible="False"></asp:Label>
                  <%--<br />--%>
               <%-- <asp:Label ID="Label19" runat="server" Text="（200字以内）" Visible="False">
                 </asp:Label>--%>
            </td>
            <td align="left" colspan="6" style="width: 17%">
                <asp:TextBox ID="TextBox13" runat="server" Enabled="True" Height="58px" 
                    MaxLength="200"  TextMode="MultiLine"   Visible="False"
                 onkeyup="this.value = this.value.substring(0, 200)" onafterpaste="this.value = this.value.substring(0, 200)"
                    Width="665px" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="1">
                <asp:Label ID="Label17" runat="server" Text="财务主管审核" Visible="False"></asp:Label>
            </td>
            <td align="left">
                            <asp:Label ID="label24" runat="server" Visible="False"></asp:Label>
                        </td>
                        <td align="right" colspan="1">
                            <asp:Label ID="Label25" runat="server" Text="审核人：" Visible="false"></asp:Label>
                        </td>
                        <td align="left" colspan="1">
                            <asp:Label ID="label26" runat="server" Visible="False"></asp:Label>
                        </td>
                        <td align="center" colspan="1">
                            <asp:Label ID="label27" runat="server" Visible="False"></asp:Label>
                        </td>
        </tr>
        <tr>
            <td align="center" colspan="1">
                <asp:Label ID="Label18" runat="server" Text="审核意见：<br/>（200字以内）" Visible="False"></asp:Label>
                  <%--<br />--%>
               <%-- <asp:Label ID="Label19" runat="server" Text="（200字以内）" Visible="False">
                 </asp:Label>--%>
            </td>
            <td align="left" colspan="6" style="width: 17%">
                <asp:TextBox ID="TextBox9" runat="server" Enabled="True" Height="58px" 
                    MaxLength="200"  TextMode="MultiLine"   Visible="False"
                 onkeyup="this.value = this.value.substring(0, 200)" onafterpaste="this.value = this.value.substring(0, 200)"
                    Width="665px" ></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td align="center" colspan="1">
                <asp:Label ID="Label44" runat="server" Text="技术副总审核" Visible="False"></asp:Label>
            </td>
            <td align="left">
                            <asp:Label ID="label45" runat="server" Visible="False"></asp:Label>
                        </td>
                        <td align="right" colspan="1">
                            <asp:Label ID="Label46" runat="server" Text="审核人：" Visible="false"></asp:Label>
                        </td>
                        <td align="left" colspan="1">
                            <asp:Label ID="label47" runat="server" Visible="False"></asp:Label>
                        </td>
                        <td align="center" colspan="1">
                            <asp:Label ID="label48" runat="server" Visible="False"></asp:Label>
                        </td>
        </tr>
        <tr>
            <td align="center" colspan="1">
                <asp:Label ID="Label49" runat="server" Text="审核意见：<br/>（200字以内）" Visible="False"></asp:Label>
                  <%--<br />--%>
               <%-- <asp:Label ID="Label19" runat="server" Text="（200字以内）" Visible="False">
                 </asp:Label>--%>
            </td>
            <td align="left" colspan="6" style="width: 17%">
                <asp:TextBox ID="TextBox14" runat="server" Enabled="True" Height="58px" 
                    MaxLength="200"  TextMode="MultiLine"   Visible="False"
                 onkeyup="this.value = this.value.substring(0, 200)" onafterpaste="this.value = this.value.substring(0, 200)"
                    Width="665px" ></asp:TextBox>
            </td>
        </tr>
           <tr>
            <td align="center" colspan="1">
                <asp:Label ID="Label21" runat="server" Text="财务总监审核" Visible="False"></asp:Label>
            </td>
            <td align="left" colspan="1">
                            <asp:Label ID="label19" runat="server" Visible="False"></asp:Label>
                        </td>
                        <td align="right" colspan="1">
                            <asp:Label ID="Label23" runat="server" Text="审核人：" Visible="false"></asp:Label>
                        </td>
                        <td align="left" colspan="1">
                            <asp:Label ID="label30" runat="server" Visible="False"></asp:Label>
                        </td>
                        <td align="center" colspan="1">
                            <asp:Label ID="label31" runat="server" Visible="False"></asp:Label>
                        </td>
        </tr>
        <tr>
            <td align="center" colspan="1">
                <asp:Label ID="Label22" runat="server" Text="审核意见：<br/>（200字以内）" Visible="False"></asp:Label>
                 <%-- <br />--%>
                <%--<asp:Label ID="Label23" runat="server" Text="（200字以内）" Visible="False">
                 </asp:Label>--%>
            </td>
            <td align="left" colspan="6" style="width: 17%">
                <asp:TextBox ID="TextBox7" runat="server" Enabled="True" Height="58px" MaxLength="200"  TextMode="MultiLine"   
               
                    Width="665px" Visible="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="1">
            </td>
            <td align="center" colspan="1">
                <asp:Button ID="Button19" runat="server" CssClass="Button02" Height="24px" 
                    OnClick="Pass " Text="通过" Width="70px" />
                <td align="center" >
                    <asp:Button ID="Button20" runat="server" CssClass="Button02" Height="24px" 
                        OnClick="Reject " Text="驳回" Width="70px" />
                </td>
                <td align="center" colspan="2">
                    <asp:Button ID="Button21" runat="server" CssClass="Button02" Height="24px" 
                        OnClick="Canel" Text="关闭" Width="70px" />
                </td>
                
            </td>
        </tr>
        <tr>
        <td colspan="7" align="center">
               
                <asp:Button ID="Button15" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="Button_CL"
                    Width="70px" />
            </td>
    </tr>
    </table>
     </fieldset>
     </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
     </asp:Content>
