 <%@ Page Language="C#" AutoEventWireup="true" CodeFile="PMEquipment.aspx.cs" Inherits="ProjectManagement_PMEquipment" MasterPageFile="~/Other/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script> 
    <asp:UpdatePanel ID="UpdatePanel_PMEquipmentSearch" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_PMEquipmentSearch" runat="server" Visible="true">
                <fieldset>
                    <legend> 检索条件</legend>
    <table style="width: 100%;">
        
         <asp:Label ID="label_QA" runat="server" Visible="False"></asp:Label>
           <asp:Label ID="label_pagestate" runat="server" Visible="False"></asp:Label>
        <tr>
        <td style="width: 15%" align="right">
                <asp:Label ID="Label1" runat="server" Text="设备名称："></asp:Label>
            </td>
            <td style="width: 15%" align="left">
                <asp:TextBox ID="EquipmentName" runat="server"> </asp:TextBox>
            </td>
            <td style="width: 12%" align="right">
                <asp:Label ID="Label2" runat="server" Text="规格型号："></asp:Label>
            </td>
            <td style="width: 15%" align="left">
                <asp:TextBox ID="TextBox1" runat="server"> </asp:TextBox>
            </td>
          
            <td style="width: 12%" align="right">
                <asp:Label ID="Label3" runat="server" Text="申请单号："></asp:Label>
            </td>
               <td align="left">
                <asp:TextBox ID="TextBox2" runat="server"> </asp:TextBox>
            </td>
            </tr>
            <tr>
            <td align="right">
                <asp:Label ID="Label4" runat="server" Text="申请部门："></asp:Label>
            </td>
            
            <td align="left">
                <asp:TextBox runat="server" ID="Depart"> </asp:TextBox>
            </td> 
            <td align="right">
                <asp:Label ID="Label5" runat="server" Text="需要时间："></asp:Label>
            </td>
            
           <td>
       <asp:TextBox ID="TextBox_SPTime2" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D ',true)"  ></asp:TextBox>
       </td>
       <td align="right">
                <asp:Label ID="Label6" runat="server" Text="至："></asp:Label>
            </td>
            <td>
       <asp:TextBox ID="TextBox_SPTime3" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D %h-%m-%s',true)"  ></asp:TextBox>
       </td>     
        </tr>
         <tr>
         <td align="right">
                <asp:Label ID="Label87" runat="server" Text="申请单状态："></asp:Label>
            </td>
            
            <td align="left">
                <asp:DropDownList ID="DropDownList2" runat="server" Width="128px" >
                     <asp:ListItem>请选择</asp:ListItem>
                    <asp:ListItem>提交申请制定</asp:ListItem>
                    <asp:ListItem>部门部长审核通过</asp:ListItem>
                   <asp:ListItem>部门部长审核驳回</asp:ListItem>
                   <asp:ListItem>相关部门审核中</asp:ListItem>
                    <asp:ListItem>相关部门审核通过</asp:ListItem>
                   <asp:ListItem>相关部门审核驳回</asp:ListItem>
                   <asp:ListItem>技术副总审核通过</asp:ListItem>
                   <asp:ListItem>技术副总审核驳回</asp:ListItem>
                   <asp:ListItem>总经理审核通过</asp:ListItem>
                   <asp:ListItem>总经理审核驳回</asp:ListItem>
                   <asp:ListItem>财务总监审核通过</asp:ListItem>
                   <asp:ListItem>财务总监审核驳回</asp:ListItem>
                   <asp:ListItem>已提交采购订单</asp:ListItem>
                   <asp:ListItem>已调试</asp:ListItem>
                   <asp:ListItem>相关部门验收审核中</asp:ListItem>
                   <asp:ListItem>相关部门验收审核通过</asp:ListItem>
                   <asp:ListItem>相关部门验收审核驳回</asp:ListItem>
                </asp:DropDownList>
            </td> 
        </tr>
        <tr>
        
            <td colspan="2" align="center">
                <asp:Button ID="Button1" runat="server" Text="检索" CssClass="Button02" Height="24px" OnClick="Button1_Sh"
                    Width="70px" />
            </td>
          
            <td colspan="2" align="center">
                
                <asp:Button ID="Button3" runat="server" Text="新增" CssClass="Button02" Height="24px" OnClick="Button3_New" Visible="true"
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
 
      <asp:UpdatePanel ID="UpdatePanel_PMEquipmentApply" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <asp:Panel ID="Panel_PMEquipmentApply" runat="server" Visible="true">
            <fieldset>
                <legend>设备采购申请单</legend>
                <asp:Label ID="label_PMEA_ID" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="label_Fiona" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="label_Unit" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="label_SelectPart" runat="server" Visible="False"></asp:Label>
                <asp:GridView ID="Gridview1"  runat="server" AutoGenerateColumns="False"
                    CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"
                    Font-Strikeout="False" GridLines="None" 
                    OnRowCommand="Gridview1_RowCommand"   OnRowEditing="Gridview1_RowEditing" OnRowUpdating="Gridview1_RowUpdating"
                    AllowPaging="True" AllowSorting="True" OnRowCancelingEdit="Gridview1_RowCancelingEdit"
                    DataKeyNames="PMEA_ID,IMMBD_MaterialID"   OnPageIndexChanging="Gridview1_PageIndexChanging" 
                    Width="100%" ondatabound="Gridview1_DataBound" onrowdatabound="Gridview1_RowDataBound" 
                     >
                    <%--    //隔行变色--%>
           
           
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
           
           
                    <PagerStyle CssClass="GridViewPagerStyle" />
  
           
              <AlternatingRowStyle />
           
           
                    <Columns>
                        <asp:BoundField DataField="PMEA_ID" HeaderText="设备采购申请ID" SortExpression="PMEA_ID" 
                            Visible="False"  ReadOnly="true">
                        </asp:BoundField>
                      
                        <asp:BoundField DataField="PMEA_EquipmentApplyNum" HeaderText="申请单号" 
                            SortExpression="PMEA_EquipmentApplyNum"  ReadOnly="true">
                             
                            </asp:BoundField>
                        <asp:BoundField DataField="IMMBD_MaterialName" HeaderText="设备名称" 
                            SortExpression="IMMBD_MaterialName" ReadOnly="true">
                          
                        </asp:BoundField>
                        <asp:BoundField DataField="PMEA_ApplyDepert" HeaderText="申请部门" 
                            SortExpression="PMEA_ApplyDepert" ReadOnly="true">
                         
                        </asp:BoundField>
                         <asp:BoundField DataField="PMEA_Model" HeaderText="规格型号" 
                            SortExpression="PMEA_Model"  ReadOnly="true">
                        </asp:BoundField>
                         <asp:BoundField DataField="PMEA_Num" HeaderText="数量" 
                            SortExpression="PMEA_Num" ReadOnly="true">
                        </asp:BoundField>
                        <asp:BoundField DataField="PMEA_InstallLocation" HeaderText="安装位置" 
                            SortExpression="PMEA_InstallLocation" ReadOnly="true">
                        </asp:BoundField>
                        <asp:BoundField DataField="PMEA_NeedTime" HeaderText="需要时间" 
                              SortExpression="PMEA_NeedTime" DataFormatString="{0:yyyy-MM-dd}" ReadOnly="true">
                        </asp:BoundField>
                        <asp:BoundField DataField="PMEA_BuyReason" HeaderText="购置原因" 
                            SortExpression="PMEA_BuyReason" ReadOnly="true">
                        </asp:BoundField>
                        <asp:BoundField DataField="PMEA_TechRequire" HeaderText="工艺要求" 
                            SortExpression="PMEA_TechRequire" ReadOnly="true">
                        </asp:BoundField>
                        <asp:BoundField DataField="PMEA_EquipmentPrice" HeaderText="单价" 
                            SortExpression="PMEA_EquipmentPrice"  />
                        <asp:BoundField DataField="PMEA_ApplyState" HeaderText="申请单状态" 
                            SortExpression="PMEA_ApplyState" ReadOnly="true">
 
                        </asp:BoundField>
                        
                       <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="Lbtoon" runat="server" CommandName="Niguo" 
                                    CommandArgument='<%#Eval("PMEA_ID")%>'>编辑</asp:LinkButton>
                                   
                            </ItemTemplate>
                            
                        </asp:TemplateField>
                         <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="btLook2" runat="server" CommandName="Delete1" 
                                    CommandArgument='<%#Eval("PMEA_ID")%>'>申请审核</asp:LinkButton>
                                    
                            </ItemTemplate>
                            
                        </asp:TemplateField>
                       <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="btLk1" runat="server" CommandName="Approve" 
                                    CommandArgument='<%#Eval("PMEA_ID")%>'>采购</asp:LinkButton>
                                 
                            </ItemTemplate>
                             
                        </asp:TemplateField>
                        <asp:TemplateField>
                        <ItemTemplate >
                                <asp:LinkButton ID="btLk2" runat="server" CommandName="Coutersign" 
                                    CommandArgument='<%#Eval("PMEA_ID")%>'>调试</asp:LinkButton>
                                 
                            </ItemTemplate>
                           
                        </asp:TemplateField>
                        <asp:TemplateField>
                        <ItemTemplate >
                                <asp:LinkButton ID="bLk1" runat="server" CommandName="Check1" 
                                    CommandArgument='<%#Eval("PMEA_ID")%>'>验收审核</asp:LinkButton>
                                 
                            </ItemTemplate>
                            
                        </asp:TemplateField>
                        <asp:TemplateField>
                        <ItemTemplate >
                                <asp:LinkButton ID="bLk2" runat="server" CommandName="Check2" 
                                    CommandArgument='<%#Eval("PMEA_ID")%>'>财务</asp:LinkButton>
                                 
                            </ItemTemplate>
                             
                        </asp:TemplateField>
                         <asp:TemplateField>
                        <ItemTemplate >
                                <asp:LinkButton ID="bLkL" runat="server" CommandName="Clear" 
                                    CommandArgument='<%#Eval("PMEA_ID")%>'>查看申请审核意见</asp:LinkButton>
                                 
                            </ItemTemplate>
                             
                        </asp:TemplateField>
                         <asp:TemplateField>
                        <ItemTemplate >
                                <asp:LinkButton ID="LKB" runat="server" CommandName="Leo" 
                                    CommandArgument='<%#Eval("PMEA_ID")%>'>查看验收审核意见</asp:LinkButton>
                                 
                            </ItemTemplate>
                             
                        </asp:TemplateField>
                        <asp:BoundField DataField="IMMBD_MaterialID" HeaderText="物料ID" SortExpression="IMMBD_MaterialID" 
                            Visible="False">
                        </asp:BoundField>
                         <asp:TemplateField>
                        <ItemTemplate >
                                <asp:LinkButton ID="Ausa" runat="server" CommandName="Ausaa" 
                                    CommandArgument='<%#Eval("PMEA_ID")%>'>选择审核部门</asp:LinkButton>
                                 
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                        <ItemTemplate >
                                <asp:LinkButton ID="Alsa" runat="server" CommandName="Alsaa" 
                                    CommandArgument='<%#Eval("PMEA_ID")%>'>选择验收审核部门</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:CommandField ShowEditButton="True" EditText="单价" UpdateText="确定" CancelText="取消">
                                <ItemStyle Width="100px" />
                            </asp:CommandField>
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
   
     <asp:UpdatePanel ID="UpdatePanel_New" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_New" runat="server" Visible="false">
                <fieldset>
                    <legend>  <asp:Label ID="label7" runat="server" Visible="true"></asp:Label></legend>
   <asp:Label ID="label_RTX" runat="server" Visible="false"></asp:Label>
    <table style="width: 100%;">
        <tr>
        <td style="width: 6%" align="right">
                <asp:Label ID="Label8" runat="server" Text="设备名称："></asp:Label>
            </td>
            <td style="width: 10%" align="left">
                
                <asp:TextBox ID="TextBox3" runat="server" Enabled="false"> </asp:TextBox>
           <asp:Label ID="Label124" runat="server" Text="*" ForeColor="Red"></asp:Label> 
            </td>
            <td style="width: 4%; height: 20px;" align="left">
                <asp:Button ID="Button28" runat="server" CssClass="Button02" Height="24px" 
                        OnClick="Button_Material" Text="选择..." Width="50px" />
            </td>
           
            <td style="width: 5%" align="right">
                <asp:Label ID="Label9" runat="server" Text="规格型号："></asp:Label>
            </td>
            <td style="width: 11%" align="left">
                <asp:TextBox ID="TextBox4" runat="server" Enabled="false" > </asp:TextBox>
                <asp:Label ID="Label125" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
          
            <td style="width: 5%" align="right">
                <asp:Label ID="Label10" runat="server" Text="数量："></asp:Label>
            </td>
               <td style="width: 12%" align="left">
                <asp:TextBox ID="TextBox5" runat="server" onkeyup="this.value=this.value.replace(/[^0-9.]/g,'')"
                                    onafterpaste="this.value=this.value.replace(/[^0-9.]/g,'')"> </asp:TextBox>
           <asp:Label ID="Label126" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            </tr>
            <tr>
            <td style="width: 6%" align="right">
                <asp:Label ID="Label11" runat="server" Text="申请部门："></asp:Label>
            </td>
            
            <td style="width: 10%" align="left">
                 <asp:DropDownList ID="DDLMark" runat="server" ToolTip="单击选择" Enabled="false"
                    
                     Width="128px" >
                                </asp:DropDownList>
                                <asp:Label ID="Label127" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td> 
            <td style="width: 4%; height: 20px;" align="center">
            </td>
            <td style="width: 5%" align="right">
                <asp:Label ID="Label12" runat="server" Text="需要时间："></asp:Label>
            </td>
            
           <td style="width: 11%">
       <asp:TextBox ID="TextBox7" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D ',true)"  ></asp:TextBox>
       <asp:Label ID="Label128" runat="server" Text="*" ForeColor="Red"></asp:Label>
       </td>
       <td style="width: 5%" align="right">
                <asp:Label ID="Label13" runat="server" Text="安装位置："></asp:Label>
            </td>
           <td style="width: 12%" align="left">
                <asp:TextBox ID="TextBox6" runat="server"> </asp:TextBox>
            </td>     
        </tr>
         <tr>
            <td style="width: 6%" align="right">
                <asp:Label ID="Label14" runat="server" Text="购置原因："></asp:Label>
                <br/>
                <asp:Label ID="Label_XZ2" runat="server" Text="(200字以内)"></asp:Label>
            </td>
            
            <td style="width: 17%" align="left"colspan="7">
                <asp:TextBox runat="server" ID="TextBox8" Height="81px" Width="90%" MaxLength="200" TextMode="MultiLine" 
                 onkeyup="this.value = this.value.substring(0, 200)" onafterpaste="this.value = this.value.substring(0, 200)"
                          ></asp:TextBox>
                          <asp:Label ID="Label129" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td> 
            </tr>
             <tr>
            <td style="width: 6%" align="right">
                <asp:Label ID="Label15" runat="server" Text="工艺及技术特性要求："></asp:Label>
                <br/>
                <asp:Label ID="Label16" runat="server" Text="(2000字以内)"></asp:Label>
            </td>
            
            <td style="width: 17%" align="left"colspan="7">
                <asp:TextBox runat="server" ID="TextBox9" Height="81px" Width="90%" MaxLength="2000" TextMode="MultiLine" 
                 onkeyup="this.value = this.value.substring(0, 2000)" onafterpaste="this.value = this.value.substring(0, 2000)"
                          ></asp:TextBox>
                          <asp:Label ID="Label130" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td> 
            </tr>
        
        <tr>
       
            <td colspan="3" align="right">
                
                <asp:Button ID="Button5" runat="server" Text="提交" CssClass="Button02" Height="24px" OnClick="Button_Rocky" Visible="true"
                    Width="70px" />
            </td>
            <td style="width: 5%" align="right">
                &nbsp;</td>
               <td style="width: 11%" align="right">
               <asp:Button ID="Button6" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="Button_Mel" Visible="true"
                    Width="70px" /></td></td>
            <td style="width: 15%" align="left" colspan="3">
        </tr>
    </table>
     </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
     <asp:UpdatePanel ID="UpdatePanel_Org" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <asp:Panel ID="Panel_Org" runat="server" Visible="false">
            <fieldset>
                <legend>部门查询</legend>
                 <asp:Label ID="Label_PMSCAC_ID" runat="server" Visible="false" ></asp:Label>
                <table style="width: 100%;">
       
        <tr>
        <td style="width: 17%; height: 20px;" align="right">
             
            </td>
             
            <td style="width: 12%; height: 20px;" align="right">
            <asp:Label ID="Label138" runat="server" Text="部门名称："></asp:Label>
            </td>
               <td style="width: 15%; height: 20px;" align="left">
                <asp:TextBox ID="TextBox40" runat="server"></asp:TextBox>
            </td> 
            <td style="width: 17%; height: 20px;" align="right">
             
            </td>
            </tr>
            <tr>
            
                <td  align="center" colspan="3">
                    <asp:Button ID="Button39" runat="server" CssClass="Button02" Height="24px" 
                        OnClick="Button1_Kil" Text="检索" Width="80px" />
                        </td>
                        <td colspan="3" align="center">
                    <asp:Button ID="Button40" runat="server" Text="重置" CssClass="Button02" Height="24px" OnClick="Button_CoMl"
                    Width="80px" />
                </td>
              
                </tr>
       
    </table>
                <asp:GridView ID="Gridview5"  runat="server" AutoGenerateColumns="False"
                    CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"
                    Font-Strikeout="False" GridLines="None" PageSize="10" 
                    AllowPaging="True" AllowSorting="True" DataKeyNames="BDOS_Code"   OnPageIndexChanging="Gridview5_PageIndexChanging" 
                    Width="100%" 
                    EnableModelValidation="True" >
                    <%--    //隔行变色--%>
           
           
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
           
           
                    <PagerStyle CssClass="GridViewPagerStyle" />
           
           
              <AlternatingRowStyle />
           
           
                    <Columns>
                   <asp:TemplateField >
                            <ItemTemplate >
                                <asp:CheckBox ID="CheckMarkup" runat="server"></asp:CheckBox>
                               
                            </ItemTemplate>
                            <ItemStyle />
                        </asp:TemplateField>
                        
                        <asp:BoundField DataField="BDOS_Code" HeaderText="部门ID" 
                            SortExpression="BDOS_Code" Visible="False">
                        <ItemStyle   />
                        </asp:BoundField>
                        <asp:BoundField DataField="BDOS_Name" HeaderText="部门名称" 
                            SortExpression="BDOS_Name" />
                       
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
                    
                <asp:Button ID="Button41" runat="server" Text="提交" CssClass="Button02" Height="24px" OnClick="Button_ComSPPP"
                    Width="70px" />
            </td>
           <td style="width: 20%" align="center">
                &nbsp;</td>
                    
                   <td style="width: 20%" align="center">
                &nbsp;</td> 
             <td width="30%" align="left">
               
                <asp:Button ID="Button42" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="Button_CancelSPPP"
                    Width="70px" />
            </td>
            
                </tr>
                </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
      <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <asp:Panel ID="Panel16" runat="server" Visible="false">
            <fieldset>
                <legend>设备查询</legend>
                 <asp:Label ID="label_Material" runat="server" Visible="false"></asp:Label>
                 <asp:Label ID="label_Model" runat="server" Visible="false"></asp:Label>
                 <table style="width: 100%;">
       
        <tr>
        <td colspan="1" >
             
            </td>
        <td colspan="1" align="right">
                <asp:Label ID="Label151" runat="server" Text="设备名称："></asp:Label>
            </td>
            <td colspan="1" align="left">
                <asp:TextBox ID="TextBox38" runat="server"> </asp:TextBox>
            </td>
            <td colspan="1" align="right">
                <asp:Label ID="Label152" runat="server" Text="规格型号："></asp:Label>
            </td>
            <td colspan="1" align="left">
                <asp:TextBox ID="TextBox39" runat="server"> </asp:TextBox>
            </td>
           
            <td colspan="1" >
            
            </td>
           
            </tr>
            <tr>
            
                <td  align="center" colspan="3">
                    <asp:Button ID="Button37" runat="server" CssClass="Button02" Height="24px" 
                        OnClick="Button1_KiM1" Text="检索" Width="80px" />
                        </td>
                        <td colspan="3" align="center">
                    <asp:Button ID="Button38" runat="server" Text="重置" CssClass="Button02" Height="24px" OnClick="Button_CoM1"
                    Width="80px" />
                </td>
              
                </tr>
       
    </table>

                <asp:GridView ID="Gridview2"  runat="server" AutoGenerateColumns="False"
                    CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"
                    Font-Strikeout="False" GridLines="None" PageSize="10" 
                    AllowPaging="True" AllowSorting="True" DataKeyNames="IMMBD_MaterialID"   OnPageIndexChanging="Gridview_Material_PageIndexChanging" 
                    Width="100%" 
                    EnableModelValidation="True" 
                    onrowdatabound="Gridview_Material_RowDataBound" ondatabound="Gridview2_DataBound" 
                    >
                    <%--    //隔行变色--%>
           
           
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
           
           
                    <PagerStyle CssClass="GridViewPagerStyle" />
           
           
              <AlternatingRowStyle />
           
           
                    <Columns>
                   <asp:TemplateField >
                            <ItemTemplate >
                                <asp:RadioButton ID="RadioButtonMarkup" runat="server"></asp:RadioButton>
                               
  
                            </ItemTemplate>
                            <ItemStyle />
                        </asp:TemplateField>
                        
                        <asp:BoundField DataField="IMMBD_MaterialID" HeaderText="物料ID" 
                            SortExpression="IMMBD_MaterialID" Visible="False">
                        <ItemStyle  />
                        </asp:BoundField>
                       
                        <asp:BoundField DataField="IMMBD_MaterialName" HeaderText="设备名称" 
                            SortExpression="IMMBD_MaterialName" />
                        <asp:BoundField DataField="IMMBD_SpecificationModel" HeaderText="规格型号" 
                            SortExpression="IMMBD_SpecificationModel" />
                       
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
                    
                <asp:Button ID="Button29" runat="server" Text="提交" CssClass="Button02" Height="24px" OnClick="Button_ComSP"
                    Width="70px" />
            </td>
           <td style="width: 26%" align="left">
                &nbsp;</td>
                    
                    
             <td width="30%" align="left">
               
                <asp:Button ID="Button30" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="Button_CancelSP"
                    Width="70px" />
            </td>
            
                </tr>
                </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    
      <asp:UpdatePanel ID="UpdatePanel_Sign" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <asp:Panel ID="Panel_Sign" runat="server" Visible="false">
            <fieldset>
                <legend><asp:Label ID="label_Selected" runat="server" Visible="false" ></asp:Label></legend>
                <asp:Label ID="label_PMEAC_ID" runat="server" Visible="false" ></asp:Label>
                <asp:GridView ID="Gridview6"  runat="server" AutoGenerateColumns="False"
                    CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"
                    Font-Strikeout="False" GridLines="None" PageSize="5" 
                    OnRowCommand="Gridview6_RowCommand"  
                    AllowPaging="True" AllowSorting="True" 
                    DataKeyNames="PMEAC_ID"   OnPageIndexChanging="Gridview_6_PageIndexChanging" 
                    Width="100%" 
                    EnableModelValidation="True" OnRowDataBound="Gridview6_RowDataBound"  
                     >
                    <%--    //隔行变色--%>
           
           
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
           
           
                    <PagerStyle CssClass="GridViewPagerStyle" />
  
           
              <AlternatingRowStyle />
           
           
                    <Columns>
                        <asp:BoundField DataField="PMEAC_ID" HeaderText="设备采购申请审核ID" SortExpression="PMEAC_ID" 
                            Visible="False">
                        </asp:BoundField>
                       
                        <asp:BoundField DataField="PMEAC_SignPartment" HeaderText="审核部门" 
                            SortExpression="PMEAC_SignPartment" >
                             
                            </asp:BoundField>
                        <asp:BoundField DataField="PMEAC_SignResult" HeaderText="审核结果" 
                            SortExpression="PMEAC_SignResult">
                          
                        </asp:BoundField>
                        <asp:BoundField DataField="PMEAC_SignOpinion" HeaderText="审核意见" 
                            SortExpression="PMEAC_SignOpinion">
                         
                        </asp:BoundField>
                         <asp:BoundField DataField="PMEAC_SignMan" HeaderText="审核人" 
                            SortExpression="PMEAC_SignMan">
                            
                        </asp:BoundField>
                        <asp:BoundField DataField="PMEAC_SignTime" HeaderText="审核时间" 
                            SortExpression="PMEAC_SignTime">
                            
                        </asp:BoundField>
                       <%-- <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="tLook1" runat="server" CommandName="Modify1" 
                                    CommandArgument='<%#Eval("PMSCA_CertificApplyNum")%>'>编辑</asp:LinkButton>
                                 
                            </ItemTemplate>
                             
                        </asp:TemplateField>--%>
                         <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="Mylo" runat="server" CommandName="Myloo" 
                                    CommandArgument='<%#Eval("PMEAC_ID")%>'>查看</asp:LinkButton>
                                   
                            </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="Myllo" runat="server" CommandName="Mylloo" 
                                    CommandArgument='<%#Eval("PMEAC_ID")%>'>审核</asp:LinkButton>
                                   
                            </ItemTemplate>
                            </asp:TemplateField>
                         <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="Miko" runat="server" CommandName="Miko" OnClientClick="return confirm('您确认删除该记录吗?')" 
                                    CommandArgument='<%#Eval("PMEAC_ID")%>'>删除</asp:LinkButton>
                                   
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

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
       <asp:Panel ID="Panel7" runat="server" Visible="false" Enabled ="true" >
                <fieldset>
                    <legend>  <asp:Label ID="label47" runat="server" Visible="true"></asp:Label></legend>
                     <asp:Label ID="label_RTX1" runat="server" Visible="false"></asp:Label>
   <asp:Label ID="label_RTX2" runat="server" Visible="false"></asp:Label>
    <table style="width: 100%;">
       <asp:Label ID="label_Department" runat="server" Visible="false"></asp:Label>
      <tr>
       <td style="width: 15%; height: 20px;" align="right">
                 <asp:Label ID="label18" runat="server" Visible="false" Text="设备名称："></asp:Label>
               </td>
      <td style="width: 15%; height: 20px;" align="left">
                <asp:Label ID="label_EquipmentName" runat="server" Visible="false"></asp:Label>
               </td>
               <td style="width: 15%; height: 20px;" align="right">
                 <asp:Label ID="label19" runat="server" Visible="false" Text="数量："></asp:Label>
               </td>
               <td style="width: 15%; height: 20px;" align="left">
                <asp:Label ID="label_EquipmentNum" runat="server" Visible="false"></asp:Label>
               </td>
               <td style="width: 15%; height: 20px;" align="right">
                 <asp:Label ID="label20" runat="server" Visible="false" Text="单价："></asp:Label>
               </td>
      <td style="width: 15%; height: 20px;" align="left">
                <asp:Label ID="label_EquipmentPrice" runat="server" Visible="false"></asp:Label>
               </td>
               <td style="width: 15%; height: 20px;" align="right">
                 <asp:Label ID="label21" runat="server" Visible="false" Text="总价："></asp:Label>
               </td>
     </td>
      <td style="width: 15%; height: 20px;" align="left">
                <asp:Label ID="label_EquipmentMoney" runat="server" Visible="false"></asp:Label>
               </td>
     </td>

      </tr>
        <tr>
        <td style="width: 15%; height: 20px;" align="right">
               &nbsp;</td>
            <td style="width: 12%; height: 20px;" align="left">
                <asp:Label ID="label48" runat="server" Visible="false"></asp:Label></td>
            <td style="width: 15%; height: 20px;" align="right">
               <asp:Label ID="Label49" runat="server" Text="审核人：" Visible="false"></asp:Label>
            </td>
           <td style="width: 15%; height: 20px;" align="left">
                <asp:Label ID="label51" runat="server" Visible="false"></asp:Label></td>
            <td style="width: 15%; height: 20px;" align="right">
                &nbsp;</td>
           <td style="width: 15%; height: 20px;" align="left">
                <asp:Label ID="label52" runat="server" Visible="false"></asp:Label></td> 
            <td style="width: 15%; height: 20px;" align="right">
                &nbsp;</td>
               <td style="width: 15%; height: 20px;" align="right">
                   &nbsp;</td> 
            </tr>
            <tr>
             <td style="width: 15%" align="right">
                <asp:Label ID="label53" runat="server"  Visible="true" Text="审核意见："></asp:Label>
                <br/>
                <asp:Label ID="label54" runat="server" text="(200字以内)" Visible="true"></asp:Label>
            </td>
            
            <td style="width: 17%" align="left"colspan="7" >
                <asp:TextBox runat="server" ID="TextBox14" Height="81px" Width="90%" Visible="true" Enabled ="false" MaxLength="200" TextMode="MultiLine" 
                onkeyup="this.value = this.value.substring(0, 200)" onafterpaste="this.value = this.value.substring(0, 200)"></asp:TextBox>
                 <asp:Label ID="Label131" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            </tr>
    </table>
     </fieldset>
       </asp:Panel>
       <asp:Panel ID="Panel8" runat="server" Visible="false"  >
               
    <table style="width: 100%;">
     <tr>
            <td  style="width: 15%">
                        &nbsp;</td>
                         
                <td style="width: 15%" align="center" colspan="2">
                    <asp:Button ID="Button4" runat="server" CssClass="Button02" Height="24px" Enabled="true"
                        OnClick="Button_Riol" Text="通过" Width="70px" />
                        </td>
                        <td  style="width: 15%">
                        &nbsp;</td>
                        <td style="width: 15%" align="center" colspan="2">
                    <asp:Button ID="Button7" runat="server" CssClass="Button02" Height="24px" Enabled="true"
                        OnClick="Button_Dule" Text="驳回" Width="70px" />
                        </td>
                        <td  style="width: 15%">
                        &nbsp;</td>
                        <td style="width: 15%" align="center" colspan="2">
                    <asp:Button ID="Button8" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="Button_Duck"
                    Width="70px" />
                </td>
                <td  style="width: 15%">
                        &nbsp;</td>
                </tr>
                                 <tr>
                <td  align="center" colspan="10">
               <asp:Button ID="Button22" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="ButtonLo" Visible="false"
                    Width="70px" /></td>
                </tr>
    </table>
    
       </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

   
      
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
       <asp:Panel ID="Panel1" runat="server" Visible="false" Enabled ="true" >
                <fieldset>
                    <legend>  技术副总审核</legend>
                    <asp:Label ID="label_RTX3" runat="server" Visible="false"></asp:Label>
    <table style="width: 100%;">
       
        <tr>
        <td style="width: 15%; height: 20px;" align="right">
               &nbsp;</td>
            <td style="width: 12%; height: 20px;" align="left">
                <asp:Label ID="label36" runat="server" Visible="true"></asp:Label></td>
            <td style="width: 15%; height: 20px;" align="right">
               <asp:Label ID="Label37" runat="server" Text="审核人：" Visible="false"></asp:Label>
            </td>
           <td style="width: 15%; height: 20px;" align="left">
                <asp:Label ID="label38" runat="server" Visible="true"></asp:Label></td>
            <td style="width: 15%; height: 20px;" align="right">
                &nbsp;</td>
           <td style="width: 15%; height: 20px;" align="left">
                <asp:Label ID="label39" runat="server" Visible="true"></asp:Label></td> 
            <td style="width: 15%; height: 20px;" align="right">
                &nbsp;</td>
               <td style="width: 15%; height: 20px;" align="right">
                   &nbsp;</td> 
            </tr>
            <tr>
             <td style="width: 15%" align="right">
                <asp:Label ID="label40" runat="server"  Visible="true" Text="审核意见："></asp:Label>
                <br/>
                <asp:Label ID="label41" runat="server" text="(200字以内)" Visible="true"></asp:Label>
            </td>
            
            <td style="width: 17%" align="left"colspan="7" >
                <asp:TextBox runat="server" ID="TextBox10" Height="81px" Width="90%" Visible="true" Enabled ="true" MaxLength="200" TextMode="MultiLine" 
                onkeyup="this.value = this.value.substring(0, 200)" onafterpaste="this.value = this.value.substring(0, 200)"></asp:TextBox>
             <asp:Label ID="Label133" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            </tr>
    </table>
     </fieldset>
       </asp:Panel>
       <asp:Panel ID="Panel6" runat="server" Visible="false"  >
                
    <table style="width: 100%;">
     <tr>
            <td  style="width: 15%">
                        &nbsp;</td>
                         
                <td style="width: 15%" align="center" colspan="2">
                    
                        </td>
                        <td  style="width: 15%">
                        <asp:Button ID="Button9" runat="server" CssClass="Button02" Height="24px" Enabled="true"
                        OnClick="Button_Han" Text="通过" Width="70px" />
                        &nbsp;</td>
                        <td style="width: 15%" align="center" colspan="2">
                    <asp:Button ID="Button10" runat="server" CssClass="Button02" Height="24px" Enabled="true"
                        OnClick="Button_Truse" Text="驳回" Width="70px" />
                        </td>
                        <td  style="width: 15%">
                        &nbsp;</td>
                        <td style="width: 15%" align="center" colspan="2">
                    <asp:Button ID="Button11" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="Button_Truly"
                    Width="70px" />
                </td>

                <td  style="width: 15%">
                        &nbsp;</td>
                </tr>
                 <tr>
                <td  align="center" colspan="10">
               <asp:Button ID="Button23" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="Buttonli" Visible="false"
                    Width="70px" /></td>
                </tr>

    </table>
    
       </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
 
    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
       <asp:Panel ID="Panel9" runat="server" Visible="false" Enabled ="true" >
                <fieldset>
                    <legend> 总经理审核</legend>
                     <asp:Label ID="label_RTX4" runat="server" Visible="false"></asp:Label>
    <table style="width: 100%;">
       
        <tr>
        <td style="width: 15%; height: 20px;" align="right">
               &nbsp;</td>
            <td style="width: 12%; height: 20px;" align="left">
                <asp:Label ID="label43" runat="server" Visible="false"></asp:Label></td>
            <td style="width: 15%; height: 20px;" align="right">
               <asp:Label ID="Label44" runat="server" Text="审核人：" Visible="false"></asp:Label>
            </td>
           <td style="width: 15%; height: 20px;" align="left">
                <asp:Label ID="label45" runat="server" Visible="false"></asp:Label></td>
            <td style="width: 15%; height: 20px;" align="right">
                &nbsp;</td>
           <td style="width: 15%; height: 20px;" align="left">
                <asp:Label ID="label46" runat="server" Visible="false"></asp:Label></td> 
            <td style="width: 15%; height: 20px;" align="right">
                &nbsp;</td>
               <td style="width: 15%; height: 20px;" align="right">
                   &nbsp;</td> 
            </tr>
            <tr>
             <td style="width: 15%" align="right">
                <asp:Label ID="label55" runat="server"  Visible="true" Text="审核意见："></asp:Label>
                <br/>
                <asp:Label ID="label56" runat="server" text="(200字以内)" Visible="true"></asp:Label>
            </td>
            
            <td style="width: 17%" align="left"colspan="7" >
                <asp:TextBox runat="server" ID="TextBox11" Height="81px" Width="90%" Visible="true" Enabled ="true" MaxLength="200" TextMode="MultiLine" 
                onkeyup="this.value = this.value.substring(0, 200)" onafterpaste="this.value = this.value.substring(0, 200)"></asp:TextBox>
             <asp:Label ID="Label134" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            </tr>
    </table>
     </fieldset>
       </asp:Panel>
       <asp:Panel ID="Panel10" runat="server" Visible="false"  >
            
    <table style="width: 100%;">
     <tr>
            <td  style="width: 15%">
                        &nbsp;</td>
                         
                <td style="width: 15%" align="center" colspan="2">
                    <asp:Button ID="Button12" runat="server" CssClass="Button02" Height="24px" Enabled="true"
                        OnClick="Button_Meky" Text="通过" Width="70px" />
                        </td>
                        <td  style="width: 15%">
                        &nbsp;</td>
                        <td style="width: 15%" align="center" colspan="2">
                    <asp:Button ID="Button13" runat="server" CssClass="Button02" Height="24px" Enabled="true"
                        OnClick="Button_Melory" Text="驳回" Width="70px" />
                        </td>
                        <td  style="width: 15%">
                        &nbsp;</td>
                        <td style="width: 15%" align="center" colspan="2">
                    <asp:Button ID="Button14" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="Button_Meco"
                    Width="70px" />
                </td>
                <td  style="width: 15%">
                        &nbsp;</td>
                </tr>
                 <tr>
                <td  align="center" colspan="10">
               <asp:Button ID="Button33" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="ButtonM" Visible="false"
                    Width="70px" /></td>
                </tr>
    </table>
  
       </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
   
     <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel11" runat="server" Visible="false">
                <fieldset>
                    <legend> <asp:Label ID="label62" runat="server" Visible="true"></asp:Label></legend>
     <asp:Label ID="label_RTX5" runat="server" Visible="false"></asp:Label>
    <table style="width: 100%;">
        
         <asp:Label ID="label_SupplyID" runat="server" Visible="False"></asp:Label>
           
        <tr>
        <td style="width: 7%" align="right">
                <asp:Label ID="Label42" runat="server" Text="供应商名称："></asp:Label>
            </td>
            <td style="width: 12%" align="left">
                <asp:TextBox ID="TextBox16" runat="server"> </asp:TextBox>
                 <asp:Label ID="Label135" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 6%; height: 20px;" align="left">
               <asp:Button ID="Button25" runat="server" CssClass="Button02" Height="24px" 
                        OnClick="Button_Supply" Text="选择..." Width="50px" />
            </td>
            <td style="width: 7%" align="right">
                <asp:Label ID="Label57" runat="server" Text="单价："></asp:Label>
            </td>
            <td style="width: 11%" align="left">
                <asp:TextBox ID="TextBox17" runat="server"  Enabled="false"   > </asp:TextBox>
                                     <asp:Label ID="Label136" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
          
            <td style="width: 8%" align="right">
                <asp:Label ID="Label58" runat="server" Text="付款方式："></asp:Label>
            </td>
               <td style="width: 12%" align="left">
               <asp:DropDownList ID="DropDownList1" runat="server"  Width="130px">
                    <asp:ListItem>请选择</asp:ListItem>
                    <asp:ListItem>现货现款</asp:ListItem>
                    <asp:ListItem>先货后款</asp:ListItem>
                    <asp:ListItem>预付款</asp:ListItem>
                </asp:DropDownList>
                 <asp:Label ID="Label137" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            </tr>
            <tr>
            <td style="width: 7%" align="right">
                <asp:Label ID="Label59" runat="server" Text="账期："></asp:Label>
            </td>
            
            <td style="width: 12%" align="left">
                <asp:TextBox runat="server" ID="TextBox19" Enabled="false" ></asp:TextBox>                   
            </td> 
             <td style="width: 6%; height: 20px;" align="center">
            </td>
            <td style="width: 7%" align="right">
                <asp:Label ID="Label60" runat="server" Text="预计到货期："></asp:Label>
            </td>
            
           <td style="width: 11%">
       <asp:TextBox ID="TextBox20" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D ',true)"  ></asp:TextBox>
        <asp:Label ID="Label139" runat="server" Text="*" ForeColor="Red"></asp:Label>
       </td>
       <td style="width: 8%" align="right">
                <asp:Label ID="Label61" runat="server" Text="付款提醒时间："></asp:Label>
            </td>
            <td>
       <asp:TextBox ID="TextBox21" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D ',true)"  ></asp:TextBox>
        <asp:Label ID="Label140" runat="server" Text="*" ForeColor="Red"></asp:Label>
       </td>     
        </tr>
        <tr>
            <td style="width: 7%" align="right">
                <asp:Label ID="Label63" runat="server" Text="数量："></asp:Label>
            </td>
            
            <td style="width: 12%" align="left">
                <asp:TextBox runat="server" ID="TextBox18" onkeyup="this.value=this.value.replace(/[^0-9.]/g,'')"
                                    onafterpaste="this.value=this.value.replace(/[^0-9.]/g,'')"> </asp:TextBox>
                                     <asp:Label ID="Label141" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td> 
            <td style="width: 6%; height: 20px;" align="center">
            </td>
            </tr>
            <tr>
             <td style="width: 7%" align="right">
                <asp:Label ID="Label64" runat="server" Text="备注："></asp:Label>
                 <br/>
                <asp:Label ID="label153" runat="server" text="(200字以内)" Visible="true"></asp:Label>
            </td>
            
            <td style="width: 17%" align="left" colspan="7">
                <asp:TextBox runat="server" ID="TextBox22"  Height="81px" Width="90%" Visible="true" Enabled ="true" MaxLength="200" TextMode="MultiLine" 
                onkeyup="this.value = this.value.substring(0, 200)" onafterpaste="this.value = this.value.substring(0, 200)"></asp:TextBox>
             <asp:Label ID="Label142" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            </tr>
        
        <tr>
        
            <td colspan="1" align="center" style="width: 7%">
            </td>
          
            <td colspan="3" align="center">
                
                <asp:Button ID="Button16" runat="server" Text="提交" CssClass="Button02" Height="24px" OnClick="Button_Neo" Visible="true"
                    Width="70px" />
            </td>
           <td style="width: 11%" align="right">
                &nbsp;</td>
            <td style="width: 15%" align="left" colspan="2">
               <asp:Button ID="Button17" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="Button3_Raco" Visible="true"
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
      <asp:UpdatePanel ID="UpdatePanel_Supply" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <asp:Panel ID="Panel_Supply" runat="server" Visible="false">
            <fieldset>
                <legend>供应商查询</legend>
                <table style="width: 100%;">
       
        <tr>
        <td style="width: 12%; height: 20px;" align="right">
             
            </td>
        <td style="width: 12%; height: 20px;" align="right">
                <asp:Label ID="Label88" runat="server" Text="供应商编码："></asp:Label>
            </td>
            <td style="width: 12%; height: 20px;" align="left">
                <asp:TextBox ID="TextBox36" runat="server"> </asp:TextBox>
            </td>
            
           
            <td style="width: 12%; height: 20px;" align="left">
            
            </td>
           
            <td style="width: 12%; height: 20px;" align="right">
            <asp:Label ID="Label89" runat="server" Text="供应商名称："></asp:Label>
            </td>
               <td style="width: 15%; height: 20px;" align="left">
                <asp:TextBox ID="TextBox37" runat="server"></asp:TextBox>
            </td> 
            </tr>
            <tr>
            
                <td  align="center" colspan="3">
                    <asp:Button ID="Button35" runat="server" CssClass="Button02" Height="24px" 
                        OnClick="Button1_KiMi" Text="检索" Width="80px" />
                        </td>
                        <td colspan="3" align="center">
                    <asp:Button ID="Button36" runat="server" Text="重置" CssClass="Button02" Height="24px" OnClick="Button_CoMi"
                    Width="80px" />
                </td>
              
                </tr>
       
    </table>
                <asp:GridView ID="Gridview_PMSupply"  runat="server" AutoGenerateColumns="False"
                    CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"
                    Font-Strikeout="False" GridLines="None" PageSize="5" 
                    AllowPaging="True" AllowSorting="True" DataKeyNames="PMSI_ID"   OnPageIndexChanging="Gridview_PMSupply_PageIndexChanging" 
                    Width="100%" 
                    onrowdatabound="Gridview_PMSupply_RowDataBound" ondatabound="Gridview_PMSupply_DataBound" 
                    >
                    <%--    //隔行变色--%>
           
           
              <AlternatingRowStyle />
           
           
            <PagerStyle  ForeColor="Black" 
                 HorizontalAlign="Center" CssClass="GridViewPagerStyle" />
           
           
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
           
           
                    <Columns>
                   <asp:TemplateField >
                            <ItemTemplate >
                                <asp:RadioButton ID="RadioButtonMarkup" runat="server"></asp:RadioButton>
                               
  
                            </ItemTemplate>
                            <ItemStyle/>
                        </asp:TemplateField>
                        
                        <asp:BoundField DataField="PMSI_ID" HeaderText="供应商ID" 
                            SortExpression="PMSI_ID" Visible="False">
                        <ItemStyle />
                        </asp:BoundField>
                       
                        <asp:BoundField DataField="PMSI_SupplyNum" HeaderText="供应商编码" 
                            SortExpression="PMSI_SupplyNum" />
                        <asp:BoundField DataField="PMSI_SupplyName" HeaderText="供应商名称" 
                            SortExpression="PMSI_SupplyName" />
                       
                        <asp:BoundField DataField="PMSI_PaymentTime" HeaderText="账期" 
                            SortExpression="PMSI_PaymentTime" />
                       
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
                <td width="34%" align="right" >
                    
                <asp:Button ID="Button26" runat="server" Text="提交" CssClass="Button02" Height="24px" OnClick="Button_ComSPP"
                    Width="70px" />
            </td>
           <td style="width: 20%" align="center">
                &nbsp;</td>
                    
                   <td style="width: 20%" align="right">
                <asp:Button ID="Button27" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="Button_CancelSPP"
                    Width="70px" /></td> 
             <td width="30%" align="left">
               
                
            </td>
            
                </tr>
                </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    
     <asp:UpdatePanel ID="UpdatePanel9" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <asp:Panel ID="Panel17" runat="server" Visible="false">
            <fieldset>
                <legend><asp:Label ID="label17" runat="server" Visible="true"></asp:Label></legend>
                <asp:Label ID="label_PMECA_ID" runat="server" Visible="False"></asp:Label>
                <asp:GridView ID="Gridview3"  runat="server" AutoGenerateColumns="False"
                    CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"
                    Font-Strikeout="False" GridLines="None" PageSize="5" 
                   
                    AllowPaging="True" AllowSorting="True" 
                    DataKeyNames="PMECA_ID"   OnPageIndexChanging="Gridview3_PageIndexChanging" 
                    Width="100%" 
                    EnableModelValidation="True" ondatabound="Gridview3_DataBound" 
                     >
                    <%--    //隔行变色--%>
           
           
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
           
           
                    <PagerStyle CssClass="GridViewPagerStyle" />
  
           
              <AlternatingRowStyle />
           
           
                    <Columns>
                        <asp:BoundField DataField="PMECA_ID" HeaderText="设备验收ID" SortExpression="PMECA_ID" 
                            Visible="False">
                        </asp:BoundField>
                      
                        <asp:BoundField DataField="PMECA_MainTechnologyPara" HeaderText="主要技术参数" 
                            SortExpression="PMECA_MainTechnologyPara" >
                             
                            </asp:BoundField>
                        <asp:BoundField DataField="PMECA_AddOn" HeaderText="随机附件资料及数量" 
                            SortExpression="PMECA_AddOn">
                          
                        </asp:BoundField>
                        <asp:BoundField DataField="PMECA_MECheck" HeaderText="机械电气部分检查" 
                            SortExpression="PMECA_MECheck">
                         
                        </asp:BoundField>
                         <asp:BoundField DataField="PMECA_NullDebugInfo" HeaderText="设备空载调试信息" 
                            SortExpression="PMECA_NullDebugInfo">
                        </asp:BoundField>
                         <asp:BoundField DataField="PMECA_OnDebugInfo" HeaderText="设备负载调试信息" 
                            SortExpression="PMECA_OnDebugInfo">
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="PMECA_DebugConclusion" HeaderText="设备调试结论" 
                            SortExpression="PMECA_DebugConclusion">
                        </asp:BoundField>
                        <asp:BoundField DataField="PMECA_OnDebugTime" HeaderText="设备负载调试时间" 
                            SortExpression="PMECA_OnDebugTime">
                        </asp:BoundField>
                      <%-- <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="Lbloon" runat="server" CommandName="Nigo" 
                                    CommandArgument='<%#Eval("PMECA_ID")%>'>审核</asp:LinkButton>
                                   
                            </ItemTemplate>
                            
                        </asp:TemplateField>
                         <asp:TemplateField>
                        <ItemTemplate >
                                <asp:LinkButton ID="LKBN" runat="server" CommandName="Luis" 
                                    CommandArgument='<%#Eval("PMECA_ID")%>'>查看验收审核意见</asp:LinkButton>
                                 
                            </ItemTemplate>
                             
                        </asp:TemplateField>--%>
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
                <td width="34%" align="center" >
                    
                <asp:Button ID="Button31" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="Button_CS"
                    Width="70px" />
            </td>
           
            
                </tr>
                </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
  
    <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel12" runat="server" Visible="false">
                <fieldset>
                    <legend>  <asp:Label ID="label65" runat="server" Visible="true"></asp:Label></legend>
    <asp:Label ID="label_RTX6" runat="server" Visible="false"></asp:Label>
    <table style="width: 100%;">
        <tr>
        <td style="width: 15%" align="right">
                <asp:Label ID="Label66" runat="server" Text="生产厂家："></asp:Label>
            </td>
            <td style="width: 12%" align="left">
                <asp:TextBox ID="TextBox23" runat="server" Enabled="false" > </asp:TextBox>
            </td>
            <td style="width: 15%" align="right">
                <asp:Label ID="Label67" runat="server" Text="设备负载调试时间："></asp:Label>
            </td>
            <td style="width: 21%" align="left">
                <asp:TextBox ID="TextBox24" runat="server" onkeyup="this.value=this.value.replace(/[^0-9.]/g,'')"
                                    onafterpaste="this.value=this.value.replace(/[^0-9.]/g,'')"> </asp:TextBox>
                <asp:Label ID="Label90" runat="server" Text="小时"></asp:Label>
                 <asp:Label ID="Label143" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
          
            <td style="width: 15%" align="right">
                <asp:Label ID="Label68" runat="server" Text="购入调入部门："></asp:Label>
            </td>
               <td style="width: 12%" align="left">
                <asp:TextBox ID="TextBoxDDL3" runat="server" Enabled="false"> </asp:TextBox>
            </td>
            </tr>
         <tr>
            <td style="width: 15%" align="right">
                <asp:Label ID="Label72" runat="server" Text="主要技术参数："></asp:Label>
                <br/>
                <asp:Label ID="Label73" runat="server" Text="(200字以内)"></asp:Label>
            </td>
            
            <td style="width: 17%" align="left"colspan="7">
                <asp:TextBox runat="server" ID="TextBox28" Height="81px" Width="90%" MaxLength="200" TextMode="MultiLine" 
                 onkeyup="this.value = this.value.substring(0, 200)" onafterpaste="this.value = this.value.substring(0, 200)"
                          ></asp:TextBox>
                           <asp:Label ID="Label144" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td> 
            </tr>
             <tr>
            <td style="width: 15%" align="right">
                <asp:Label ID="Label74" runat="server" Text="随机附件资料及数量："></asp:Label>
                <br/>
                <asp:Label ID="Label75" runat="server" Text="(200字以内)"></asp:Label>
            </td>
            
            <td style="width: 17%" align="left"colspan="7">
                <asp:TextBox runat="server" ID="TextBox29" Height="81px" Width="90%" MaxLength="200" TextMode="MultiLine" 
                 onkeyup="this.value = this.value.substring(0, 200)" onafterpaste="this.value = this.value.substring(0, 200)"
                          ></asp:TextBox>
                           <asp:Label ID="Label145" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td> 
            </tr>
            <tr>
            <td style="width: 15%" align="right">
                <asp:Label ID="Label69" runat="server" Text="机械电气部分检查："></asp:Label>
                <br/>
                <asp:Label ID="Label70" runat="server" Text="(200字以内)"></asp:Label>
            </td>
            
            <td style="width: 17%" align="left"colspan="7">
                <asp:TextBox runat="server" ID="TextBox25" Height="81px" Width="90%" MaxLength="200" TextMode="MultiLine" 
                 onkeyup="this.value = this.value.substring(0, 200)" onafterpaste="this.value = this.value.substring(0, 200)"
                          ></asp:TextBox>
                           <asp:Label ID="Label146" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td> 
            </tr>
            <tr>
            <td style="width: 15%" align="right">
                <asp:Label ID="Label71" runat="server" Text="设备空载调试信息："></asp:Label>
                <br/>
                <asp:Label ID="Label76" runat="server" Text="(200字以内)"></asp:Label>
            </td>
            
            <td style="width: 17%" align="left"colspan="7">
                <asp:TextBox runat="server" ID="TextBox26" Height="81px" Width="90%" MaxLength="200" TextMode="MultiLine" 
                 onkeyup="this.value = this.value.substring(0, 200)" onafterpaste="this.value = this.value.substring(0, 200)"
                          ></asp:TextBox>
                           <asp:Label ID="Label147" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td> 
            </tr>
            <tr>
            <td style="width: 15%" align="right">
                <asp:Label ID="Label77" runat="server" Text="设备负载调试信息："></asp:Label>
                <br/>
                <asp:Label ID="Label78" runat="server" Text="(200字以内)"></asp:Label>
            </td>
            
            <td style="width: 17%" align="left"colspan="7">
                <asp:TextBox runat="server" ID="TextBox27" Height="81px" Width="90%" MaxLength="200" TextMode="MultiLine" 
                 onkeyup="this.value = this.value.substring(0, 200)" onafterpaste="this.value = this.value.substring(0, 200)"
                          ></asp:TextBox>
                           <asp:Label ID="Label148" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td> 
            </tr>
            <tr>
            <td style="width: 15%" align="right">
                <asp:Label ID="Label79" runat="server" Text="设备调试结论："></asp:Label>
                <br/>
                <asp:Label ID="Label80" runat="server" Text="(200字以内)"></asp:Label>
            </td>
            
            <td style="width: 17%" align="left"colspan="7">
                <asp:TextBox runat="server" ID="TextBox30" Height="81px" Width="90%" MaxLength="200" TextMode="MultiLine" 
                 onkeyup="this.value = this.value.substring(0, 200)" onafterpaste="this.value = this.value.substring(0, 200)"
                          ></asp:TextBox>
                           <asp:Label ID="Label149" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td> 
            </tr>
        
        <tr>
        <td colspan="1" align="center">
        </td>
            <td colspan="2" align="center">
                
                <asp:Button ID="Button15" runat="server" Text="提交" CssClass="Button02" Height="24px" OnClick="Button_Lisa" Visible="true"
                    Width="70px" />
            </td>
            <td colspan="1" align="center" style="width: 21%">
        </td>
            <td style="width: 15%" align="left" colspan="2">
               <asp:Button ID="Button18" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="Button_Bos" Visible="true"
                    Width="70px" /></td>
        </tr>
    </table>
     </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
 
     <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
        <ContentTemplate>      
        <asp:Panel ID="Panel18" runat="server" Visible="false" 
                style="margin-bottom: 0px">
       <fieldset>
                    <legend>  <asp:Label ID="label81" runat="server" Visible="true"></asp:Label></legend>
                     <asp:Label ID="label_RTX7" runat="server" Visible="false"></asp:Label>
      <asp:Label ID="label_RTX_P" runat="server" Visible="false"></asp:Label>

    <table style="width: 100%;">
       
        <tr>
        <td style="width: 12%; height: 20px;" align="right">
               &nbsp;</td>
            <td style="width: 12%; height: 20px;" align="right">
                <asp:CheckBox ID="Markup" runat="server"></asp:CheckBox></td>
            <td style="width: 15%; height: 20px;" align="left">
               <asp:Label ID="Label83" runat="server" Text="随机备件清单" Visible="true"></asp:Label>
            </td>
           <td style="width: 15%; height: 20px;" align="right">
                <asp:CheckBox ID="CheckBox1" runat="server"></asp:CheckBox></td>
            <td style="width: 15%; height: 20px;" align="left">
                <asp:Label ID="Label82" runat="server" Text="长时间负载运行正常" Visible="true"></asp:Label></td>
           <td style="width: 15%; height: 20px;" align="right">
                <asp:CheckBox ID="CheckBox2" runat="server"></asp:CheckBox></td> 
            <td style="width: 15%; height: 20px;" align="left">
                <asp:Label ID="Label84" runat="server" Text="设备运转正常" Visible="true"></asp:Label></td>
               
            </tr>
            <tr>
            <td style="height: 20px;" align="right">
               &nbsp;</td>
            <td style="width: 15%; height: 20px;" align="right">
                <asp:CheckBox ID="CheckBox3" runat="server"></asp:CheckBox></td> 
            <td style="width: 15%; height: 20px;" align="left">
                <asp:Label ID="Label85" runat="server" Text="满足技术参数要求" Visible="true"></asp:Label></td>
               
            </tr>
        <tr>
        <td style="width: 15%; height: 20px;" align="right">
               &nbsp;</td>
        <td style="width: 15%; height: 20px;" align="center">
               <asp:Label ID="label86" runat="server" Visible="true"></asp:Label></td>
            
            <td style="width: 15%; height: 20px;" align="right">
               <asp:Label ID="Label98" runat="server" Text="审核人：" Visible="true"></asp:Label>
            </td>
           <td style="width: 15%; height: 20px;" align="left">
                <asp:Label ID="label99" runat="server" Visible="true"></asp:Label></td>
            <td style="width: 15%; height: 20px;" align="right">
                &nbsp;</td>
           <td style="width: 15%; height: 20px;" align="left">
                <asp:Label ID="label100" runat="server" Visible="true"></asp:Label></td> 
            <td style="width: 15%; height: 20px;" align="right">
                &nbsp;</td>
               <td style="width: 15%; height: 20px;" align="right">
                   &nbsp;</td> 
            </tr>
            <tr>
             <td align="right">
                <asp:Label ID="label101" runat="server"  Visible="true" Text="审核意见："></asp:Label>
                <br/>
                <asp:Label ID="label102" runat="server" text="(200字以内)" Visible="true"></asp:Label>
            </td>
            
            <td style="width: 17%" align="left"colspan="7" >
                <asp:TextBox runat="server" ID="TextBox31" Height="81px" Width="90%" Visible="true" Enabled ="false" MaxLength="200" TextMode="MultiLine" 
                onkeyup="this.value = this.value.substring(0, 200)" onafterpaste="this.value = this.value.substring(0, 200)"></asp:TextBox>
            </td>
            </tr>
        </tr>
    </table>
     </fieldset>
       </asp:Panel>

      
      
       <asp:Panel ID="Panel14" runat="server" Visible="false"  >
                
    <table style="width: 100%;">
     <tr>
            <td  style="width: 15%">
                        &nbsp;</td>
                         
                <td style="width: 15%" align="center" colspan="2">
                    <asp:Button ID="Button19" runat="server" CssClass="Button02" Height="24px" Enabled="true"
                        OnClick="Button_Pasen" Text="通过" Width="70px" />
                        </td>
                        <td  style="width: 15%">
                        &nbsp;</td>
                        <td style="width: 15%" align="center" colspan="2">
                    <asp:Button ID="Button20" runat="server" CssClass="Button02" Height="24px" Enabled="true"
                        OnClick="Button_Bobo" Text="驳回" Width="70px" />
                        </td>
                        <td  style="width: 15%">
                        &nbsp;</td>
                        <td style="width: 15%" align="center" colspan="2">
                    <asp:Button ID="Button21" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="Button_Cali"
                    Width="70px" />
                </td>
                <td  style="width: 15%">
                        &nbsp;</td>
                </tr>
                 <tr>
                <td  align="center" colspan="10">
               <asp:Button ID="Button34" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="ButtonL" Visible="false"
                    Width="70px" /></td>
                </tr>
    </table>
   
       </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    
     <asp:UpdatePanel ID="UpdatePanel_EquipmentCost" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <asp:Panel ID="Panel_EquipmentCost" runat="server" Visible="false">
            <fieldset>
                <legend><asp:Label ID="Label_EC" runat="server" Visible="true"></asp:Label></legend>
                <asp:GridView ID="Gridview4"  runat="server" AutoGenerateColumns="False"
                    CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"
                    Font-Strikeout="False" GridLines="None" PageSize="5" 
                    AllowPaging="True" AllowSorting="True" DataKeyNames="EMSAUS_UseAmount"   OnPageIndexChanging="Gridview4_PageIndexChanging" 
                    Width="100%" 
                    EnableModelValidation="True">
                    <%--    //隔行变色--%>
           
            <PagerStyle 
                 HorizontalAlign="Center" CssClass="GridViewPagerStyle" />
           
           
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
            <AlternatingRowStyle />
           
                    <Columns>
                        <asp:BoundField DataField="EMSAUS_UseAmount" HeaderText="故障维修与保养所用备件数量" 
                            SortExpression="EMSAUS_UseAmount">
                      
                        </asp:BoundField>
                       <asp:BoundField DataField="EquipmentCost" HeaderText="金额" 
                            SortExpression="EquipmentCost">
                        </asp:BoundField>
                       
                    </Columns>
               <EmptyDataTemplate>
              <asp:Label ID="Label50" runat="server" Text="无相关记录！"></asp:Label>
             </EmptyDataTemplate>
                    <FooterStyle CssClass="GridViewFooterStyle" />
                    <HeaderStyle CssClass="GridviewHead" 
                        HorizontalAlign="Center" />
           
           
                    <PagerStyle ForeColor="Black"   CssClass="GridViewPagerStyle" />
           
           
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
                        <td  align="center">
                <asp:Button ID="Button32" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="ButtonCClose"
                    Width="70px" />
            </td>
                        </tr>
                     </table>
                </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    </asp:Content>

