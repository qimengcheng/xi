<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PMSupplyCertific.aspx.cs" Inherits="ProjectManagement_PMSupplyCertific" MasterPageFile="~/Other/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    &nbsp;<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script> 
    <asp:UpdatePanel ID="UpdatePanel_SupplyCertificSearch" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_SupplyCertificSearch" runat="server" Visible="true">
                <fieldset>
                    <legend> 检索条件</legend>
                     <asp:Label ID="label_RTX_P" runat="server" Visible="False"></asp:Label>
    <table style="width: 100%;">
        
         <asp:Label ID="label_QA" runat="server" Visible="False"></asp:Label>
             <asp:Label ID="label_PD" runat="server" Visible="False"></asp:Label>
             <asp:Label ID="label1_ED" runat="server" Visible="False"></asp:Label>
             <asp:Label ID="label1_Condition" runat="server" Visible="False"></asp:Label>
             <asp:Label ID="label_CertificApplyNum" runat="server" Visible="False"></asp:Label>
             <asp:Label ID="label_SupplyID" runat="server" Visible="False"></asp:Label>
             <asp:Label ID="label_PM" runat="server" Visible="False"></asp:Label>
             <asp:Label ID="label_SN" runat="server" Visible="False"></asp:Label>
             <asp:Label ID="label_WN" runat="server" Visible="False"></asp:Label>
             <asp:Label ID="label_XinOXiu" runat="server" Visible="False"></asp:Label>
             <asp:Label ID="label_PMSCI_ID" runat="server" Visible="False"></asp:Label>
             <asp:Label ID="label_Result" runat="server" Visible="False"></asp:Label>
              <asp:Label ID="label_QAHQ" runat="server" Visible="False"></asp:Label>
              <asp:Label ID="label_EDHQ" runat="server" Visible="False"></asp:Label>
              <asp:Label ID="label_PDHQ" runat="server" Visible="False"></asp:Label>
              <asp:Label ID="label_Supply" runat="server" Visible="False"></asp:Label>
        <tr>
        <td style="width: 15%" align="right">
                <asp:Label ID="Label1" runat="server" Text="申请部门："></asp:Label>
            </td>
            <td style="width: 12%" align="left">
                <asp:TextBox ID="PMSCA_ApplyDepart" runat="server"> </asp:TextBox>
            </td>
            <td style="width: 15%" align="right">
                <asp:Label ID="Label2" runat="server" Text="供应商："></asp:Label>
            </td>
            <td style="width: 12%" align="left">
                <asp:TextBox ID="TextBox1" runat="server" Enabled="false"> </asp:TextBox>
            </td>
            <td style="width: 14%; height: 20px;" align="left">
               <asp:Button ID="Button16" runat="server" CssClass="Button02" Height="24px" 
                        OnClick="Button_Supply" Text="选择..." Width="50px" />
            </td>
            <td style="width: 15%" align="right">
                <asp:Label ID="Label3" runat="server" Text="状态："></asp:Label>
            </td>
               <td style="width: 15%; height: 20px;" align="left">
               <asp:DropDownList ID="DropDownList3" runat="server"  Width="125px">
                     <asp:ListItem>请选择</asp:ListItem>
                    <asp:ListItem>已提交</asp:ListItem>
                    <asp:ListItem>认证中</asp:ListItem>
                   <asp:ListItem>认证完成</asp:ListItem>
                   <asp:ListItem>会签中</asp:ListItem>
                   <asp:ListItem>会签通过</asp:ListItem>
                   <asp:ListItem>会签驳回</asp:ListItem>
                   <asp:ListItem>技术副总审核通过</asp:ListItem>
                   <asp:ListItem>技术副总审核驳回</asp:ListItem>
                   <asp:ListItem>总经理审核通过</asp:ListItem>
                   <asp:ListItem>总经理审核驳回</asp:ListItem>
                </asp:DropDownList>
            </td>
            </tr>
            <tr>
            <td style="width: 15%" align="right">
                <asp:Label ID="Label4" runat="server" Text="物料名称："></asp:Label>
            </td>
            
            <td style="width: 17%" align="left">
                <asp:TextBox runat="server" ID="PMSCA_MaterialName"> </asp:TextBox>
            </td> 
            <td style="width: 15%" align="right">
                <asp:Label ID="Label5" runat="server" Text="申请目的："></asp:Label>
            </td>
            
            <td style="width: 17%" align="left" colspan="4">
                <asp:TextBox runat="server" ID="TextBox3" Width="487px"></asp:TextBox>
            </td> 
                 
        </tr>
        
        <tr>
        <td style="width: 15%" align="left">
                &nbsp;</td>
            <td colspan="2" align="center">
                <asp:Button ID="Button1" runat="server" Text="检索" CssClass="Button02" Height="24px" OnClick="Button1_Sh"
                    Width="70px" />
            </td>
          
            <td colspan="2" align="center">
                
                <asp:Button ID="Button3" runat="server" Text="新增" CssClass="Button02" Height="24px" OnClick="Button3_New" Visible="true"
                    Width="70px" />
            </td>
            <td style="width: 15%" align="center" colspan="2">
               <asp:Button ID="Button2" runat="server" Text="重置" CssClass="Button02" Height="24px" OnClick="Button3_Reset" Visible="true"
                    Width="70px" /></td>
        </tr>
    </table>
     </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
 
        <asp:UpdatePanel ID="UpdatePanel2_Approve" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <asp:Panel ID="Panel2_Approve" runat="server" Visible="true">
            <fieldset>
                <legend>认证申请表</legend>
                <asp:GridView ID="Gridview1"  runat="server" AutoGenerateColumns="False"
                    CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"
                    Font-Strikeout="False" GridLines="None" PageSize="5" 
                    OnRowCommand="Gridview1_RowCommand"  
                    AllowPaging="True" AllowSorting="True" 
                    DataKeyNames="PMSCA_CertificApplyNum"   OnPageIndexChanging="Gridview_Project_PageIndexChanging" 
                    Width="100%" 
                    EnableModelValidation="True" onrowdatabound="Gridview1_RowDataBound" ondatabound="Gridview1_DataBound" 
                     >
                    <%--    //隔行变色--%>
           
           
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
           
           
                    <PagerStyle CssClass="GridViewPagerStyle" />
  
           
              <AlternatingRowStyle />
           
           
                    <Columns>
                        <asp:BoundField DataField="PMSCA_CertificApplyNum" HeaderText="申请单号" SortExpression="PMSCA_CertificApplyNum" 
                            Visible="False">
                        </asp:BoundField>
                       
                        <asp:BoundField DataField="PMSCA_ApplyDepart" HeaderText="申请部门" 
                            SortExpression="PMSCA_ApplyDepart" >
                             
                            </asp:BoundField>
                        <asp:BoundField DataField="PMSI_SupplyName" HeaderText="供应商名称" 
                            SortExpression="PMSI_SupplyName">
                          
                        </asp:BoundField>
                        <asp:BoundField DataField="PMSCA_MaterialName" HeaderText="物料名称" 
                            SortExpression="PMSCA_MaterialName">
                         
                        </asp:BoundField>
                         <asp:BoundField DataField="PMSCA_ApplyAim" HeaderText="申请目的" 
                            SortExpression="PMSCA_ApplyAim">
                            
                        </asp:BoundField>
                        <asp:BoundField DataField="PMSCA_State" HeaderText="申请单状态" 
                            SortExpression="PMSCA_State">
                            
                        </asp:BoundField>
                        <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="tLook1" runat="server" CommandName="Modify1" 
                                    CommandArgument='<%#Eval("PMSCA_CertificApplyNum")%>'>编辑</asp:LinkButton>
                                 
                            </ItemTemplate>
                             
                        </asp:TemplateField>
                         <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="btLook2" runat="server" CommandName="Delete1" OnClientClick="return confirm('您确认删除该记录吗?')" 
                                    CommandArgument='<%#Eval("PMSCA_CertificApplyNum")%>'>删除</asp:LinkButton>
                                   
                            </ItemTemplate>
                            
                        </asp:TemplateField>
                       <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="btLk1" runat="server" CommandName="Approve" 
                                    CommandArgument='<%#Eval("PMSCA_CertificApplyNum")%>'>认证</asp:LinkButton>
                                 
                            </ItemTemplate>
                             
                        </asp:TemplateField>
                        <asp:TemplateField>
                        <ItemTemplate >
                                <asp:LinkButton ID="btLk2" runat="server" CommandName="Coutersign" 
                                    CommandArgument='<%#Eval("PMSCA_CertificApplyNum")%>'>会签</asp:LinkButton>
                                 
                            </ItemTemplate>
                           
                        </asp:TemplateField>
                        <asp:TemplateField>
                        <ItemTemplate >
                                <asp:LinkButton ID="bLk1" runat="server" CommandName="Check1" 
                                    CommandArgument='<%#Eval("PMSCA_CertificApplyNum")%>'>技术副总审核</asp:LinkButton>
                                 
                            </ItemTemplate>
                            
                        </asp:TemplateField>
                        <asp:TemplateField>
                        <ItemTemplate >
                                <asp:LinkButton ID="bLk2" runat="server" CommandName="Check2" 
                                    CommandArgument='<%#Eval("PMSCA_CertificApplyNum")%>'>总经理审核</asp:LinkButton>
                                 
                            </ItemTemplate>
                             
                        </asp:TemplateField>

                        <asp:TemplateField>
                        <ItemTemplate >
                                <asp:LinkButton ID="Lory" runat="server" CommandName="Checkk" 
                                    CommandArgument='<%#Eval("PMSCA_CertificApplyNum")%>'>选择会签部门</asp:LinkButton>
                                 
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                        <ItemTemplate >
                                <asp:LinkButton ID="Lorry" runat="server" CommandName="Mkk" 
                                    CommandArgument='<%#Eval("PMSCA_CertificApplyNum")%>'>查看会签意见</asp:LinkButton>
                                 
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
 <%--<asp:UpdatePanel ID="UpdatePanel_SOrg" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_SOrg" runat="server" Visible="false">
                <fieldset>
                    <legend> <asp:Label ID="label59" runat="server" Visible="true"></asp:Label></legend>
   <asp:Label ID="label61" runat="server" Visible="false"></asp:Label>
    <table style="width: 100%;">
     <tr>
             <td style="width: 29%; height: 20px;" align="right">
            <asp:Label ID="Label57" runat="server" Text="审核部门："></asp:Label>
            </td>
               <td colspan="6" align="left">
                <asp:TextBox ID="TextBox20" runat="server" Enabled="false" Width="580px" 
                       Height="37px" ></asp:TextBox>
                 <asp:Label ID="Label58" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td> 
            <td style="width: 15%; height: 20px;" align="left">
                <asp:Button ID="Button30" runat="server" CssClass="Button02" Height="24px" 
                        OnClick="Button_OrgSearch" Text="选择..." Width="50px" /></td>
            </tr>
    </table>
     </fieldset>
       </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>--%>
    <asp:UpdatePanel ID="UpdatePanel_Spl_New" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel__Spl_New" runat="server" Visible="false">
                <fieldset>
                    <legend> <asp:Label ID="label_New" runat="server" Visible="true"></asp:Label></legend>
   <asp:Label ID="label_RTX" runat="server" Visible="false"></asp:Label>
    <table style="width: 100%;">
       
        <tr>
        <td style="width: 21%; height: 20px;" align="right">
                <asp:Label ID="Label8" runat="server" Text="物料名称："></asp:Label>
            </td>
            <td style="width: 19%; height: 20px;" align="left">
                <asp:TextBox ID="TextBox4" runat="server" Enabled="false" > </asp:TextBox>
                 <asp:Label ID="Label43" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
             <td align="center">
                                <asp:Button ID="Button19" runat="server" Text="选择..." CssClass="Button02" Height="24px"
                                    OnClick="Button_SelectM" Width="80px" />
                            </td>
           <td style="width: 13%; height: 20px;" align="right">
                <asp:Label ID="Label10" runat="server" Text="申请部门："></asp:Label>
                </td>
            <td style="width: 18%; height: 20px;" align="left">
               <asp:DropDownList ID="DDLMark" runat="server" ToolTip="单击选择" 
                    
                     Width="128px" >
                                </asp:DropDownList>
                                 <asp:Label ID="Label44" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
           
            <td style="width: 10%; height: 20px;" align="right">
            <asp:Label ID="Label7" runat="server" Text="供应商："></asp:Label>
            </td>
               <td style="width: 21%; height: 20px;" align="left">
                <asp:TextBox ID="TextBox6" runat="server" Enabled="false" > </asp:TextBox>
                 <asp:Label ID="Label45" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td> 
            <td style="width: 15%; height: 20px;" align="left">
                <asp:Button ID="Button4" runat="server" CssClass="Button02" Height="24px" 
                        OnClick="Button_SupplySearch" Text="选择..." Width="50px" /></td>
            </tr>
           
            <tr>
            <td style="width: 21%" align="right">
                <asp:Label ID="Label11" runat="server" Text="申请目的："></asp:Label>
                <br/>
                <asp:Label ID="Label_XZ2" runat="server" Text="(200字以内)"></asp:Label>
            </td>
            
            <td style="width: 17%" align="left"colspan="7">
                <asp:TextBox runat="server" ID="TextBox7" Height="81px" Width="97%" MaxLength="200" TextMode="MultiLine"
                 onkeyup="this.value = this.value.substring(0, 200)" onafterpaste="this.value = this.value.substring(0, 200)"
                          ></asp:TextBox>
                           <asp:Label ID="Label46" runat="server" Text="*" ForeColor="Red"></asp:Label>
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
            <asp:Label ID="Label60" runat="server" Text="部门名称："></asp:Label>
            </td>
               <td style="width: 15%; height: 20px;" align="left">
                <asp:TextBox ID="TextBox22" runat="server"></asp:TextBox>
            </td> 
            <td style="width: 17%; height: 20px;" align="right">
             
            </td>
            </tr>
            <tr>
            
                <td  align="center" colspan="3">
                    <asp:Button ID="Button31" runat="server" CssClass="Button02" Height="24px" 
                        OnClick="Button1_Kil" Text="检索" Width="80px" />
                        </td>
                        <td colspan="3" align="center">
                    <asp:Button ID="Button32" runat="server" Text="重置" CssClass="Button02" Height="24px" OnClick="Button_CoMl"
                    Width="80px" />
                </td>
              
                </tr>
       
    </table>
                <asp:GridView ID="Gridview3"  runat="server" AutoGenerateColumns="False"
                    CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"
                    Font-Strikeout="False" GridLines="None" PageSize="10" 
                    AllowPaging="True" AllowSorting="True" DataKeyNames="BDOS_Code"   OnPageIndexChanging="Gridview3_PageIndexChanging" 
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
                    
                <asp:Button ID="Button33" runat="server" Text="提交" CssClass="Button02" Height="24px" OnClick="Button_ComSPP"
                    Width="70px" />
            </td>
           <td style="width: 20%" align="center">
                &nbsp;</td>
                    
                   <td style="width: 20%" align="center">
                &nbsp;</td> 
             <td width="30%" align="left">
               
                <asp:Button ID="Button34" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="Button_CancelSPP"
                    Width="70px" />
            </td>
            
                </tr>
                </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    

    <asp:UpdatePanel ID="UpdatePanel_Material" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Material" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="label38" runat="server" Visible="true" Text="物料表"></asp:Label>
                    </legend>
                    <table style="width: 100%;">
       
        <tr>
        <td colspan="1" >
             
            </td>
        <td colspan="1" align="right">
                <asp:Label ID="Label39" runat="server" Text="物料名称："></asp:Label>
            </td>
            <td colspan="1" align="left">
                <asp:TextBox ID="TextBox16" runat="server"> </asp:TextBox>
            </td>
            <td colspan="1" align="right">
                <asp:Label ID="Label40" runat="server" Text="规格型号："></asp:Label>
            </td>
            <td colspan="1" align="left">
                <asp:TextBox ID="TextBox17" runat="server"> </asp:TextBox>
            </td>
           
            <td colspan="1" >
            
            </td>
           
            </tr>
            <tr>
            
                <td  align="center" colspan="3">
                    <asp:Button ID="Button25" runat="server" CssClass="Button02" Height="24px" 
                        OnClick="Button1_KiM" Text="检索" Width="80px" />
                        </td>
                        <td colspan="3" align="center">
                    <asp:Button ID="Button26" runat="server" Text="重置" CssClass="Button02" Height="24px" OnClick="Button_CoM"
                    Width="80px" />
                </td>
              
                </tr>
       
    </table>
                    <asp:GridView ID="Gridview5" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle"
                        CellPadding="0" UseAccessibleHeader="False" BorderColor="#C0DE98" PageSize="10"
                        AllowPaging="True" AllowSorting="True" DataKeyNames="IMMBD_MaterialID"
                        OnPageIndexChanging="Gridview5_PageIndexChanging" Width="100%" EnableModelValidation="True"
                        OnRowDataBound="Gridview5_RowDataBound">
                        <%--    //隔行变色--%>
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <PagerStyle CssClass="GridViewPagerStyle" />
                        <AlternatingRowStyle />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:RadioButton ID="RadioButtonMarkup" runat="server" GroupName="GN"></asp:RadioButton>
                                </ItemTemplate>
                                <ItemStyle Width="100px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="IMMBD_MaterialName" HeaderText="物料名称" SortExpression="IMMBD_MaterialName">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_SpecificationModel" HeaderText="规格型号" SortExpression="IMMBD_SpecificationModel">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_MaterialID" HeaderText="物料ID" SortExpression="IMMBD_MaterialID"
                                Visible="False" />
                            
                        </Columns>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label50" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <PagerStyle ForeColor="Black" HorizontalAlign="Center" CssClass="GridViewPagerStyle" />
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第<asp:Label ID="lblPageIndex" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>' />
                                        页 共<asp:Label ID="lblPageCount" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />
                                        页
                                        <asp:LinkButton ID="btnFirst" runat="server" CausesValidation="False" CommandArgument="First"
                                            CommandName="Page" Text="首页" />
                                        <asp:LinkButton ID="btnPrev" runat="server" CausesValidation="False" CommandArgument="Prev"
                                            CommandName="Page" Text="上一页" />
                                        <asp:LinkButton ID="btnNext" runat="server" CausesValidation="False" CommandArgument="Next"
                                            CommandName="Page" Text="下一页" />
                                        <asp:LinkButton ID="btnLast" runat="server" CausesValidation="False" CommandArgument="Last"
                                            CommandName="Page" Text="尾页" />
                                        <asp:TextBox ID="textbox" runat="server" Width="20px"></asp:TextBox>
                                        <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                            CommandName="Page" Text="GO" /><!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
                                    </td>
                                </tr>
                            </table>
                        </PagerTemplate>
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                    </asp:GridView>
                    <table width="100%">
                        <tr>
                            <td width="34%" align="right">
                                <asp:Button ID="Button20" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    OnClick="Button_Com1" Width="80px" />
                                </td>
                            <td style="width: 20%" align="center">
                                &nbsp;
                            </td>
                            <td width="30%" align="left">
                                <asp:Button ID="Button21" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="Button_Cancel1" Width="80px" />
                            </td>
                           
                        </tr>
                </fieldset>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
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
                <asp:Label ID="Label41" runat="server" Text="供应商编码："></asp:Label>
            </td>
            <td style="width: 12%; height: 20px;" align="left">
                <asp:TextBox ID="TextBox2" runat="server"> </asp:TextBox>
            </td>
            
           
            <td style="width: 12%; height: 20px;" align="left">
            
            </td>
           
            <td style="width: 12%; height: 20px;" align="right">
            <asp:Label ID="Label42" runat="server" Text="供应商名称："></asp:Label>
            </td>
               <td style="width: 15%; height: 20px;" align="left">
                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            </td> 
            </tr>
            <tr>
            
                <td  align="center" colspan="3">
                    <asp:Button ID="Button17" runat="server" CssClass="Button02" Height="24px" 
                        OnClick="Button1_KiMi" Text="检索" Width="80px" />
                        </td>
                        <td colspan="3" align="center">
                    <asp:Button ID="Button18" runat="server" Text="重置" CssClass="Button02" Height="24px" OnClick="Button_CoMi"
                    Width="80px" />
                </td>
              
                </tr>
       
    </table>
                <asp:GridView ID="Gridview_PMSupply"  runat="server" AutoGenerateColumns="False"
                    CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"
                    Font-Strikeout="False" GridLines="None" PageSize="10" 
                    AllowPaging="True" AllowSorting="True" DataKeyNames="PMSI_ID"   OnPageIndexChanging="Gridview_PMSupply_PageIndexChanging" 
                    Width="100%" 
                    EnableModelValidation="True" 
                    onrowdatabound="Gridview_PMSupply_RowDataBound" onrowcreated="Gridview_PMSupply_RowCreated" 
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
                        
                        <asp:BoundField DataField="PMSI_ID" HeaderText="供应商ID" 
                            SortExpression="PMSI_ID" Visible="False">
                        <ItemStyle   />
                        </asp:BoundField>
                       
                        <asp:BoundField DataField="PMSI_SupplyNum" HeaderText="供应商编码" 
                            SortExpression="PMSI_SupplyNum" />
                        <asp:BoundField DataField="PMSI_SupplyName" HeaderText="供应商名称" 
                            SortExpression="PMSI_SupplyName" />
                       
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
                    
                <asp:Button ID="Button6" runat="server" Text="提交" CssClass="Button02" Height="24px" OnClick="Button_ComSP"
                    Width="70px" />
            </td>
           <td style="width: 20%" align="center">
                &nbsp;</td>
                    
                   <td style="width: 20%" align="center">
                &nbsp;</td> 
             <td width="30%" align="left">
               
                <asp:Button ID="Button7" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="Button_CancelSP"
                    Width="70px" />
            </td>
            
                </tr>
                </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    
     <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" Visible="false">
                <fieldset>
                    <legend> 
                    <asp:Label ID="label_WH" runat="server" Visible="true"></asp:Label>
                    </legend>
    <table style="width: 100%;">
       
        <tr>
        <td style="width: 12%; height: 20px;" align="right">
                <asp:Label ID="Label6" runat="server" Text="测试部门："></asp:Label>
            </td>
            <td style="width: 19%; height: 20px;" align="left">
                <asp:TextBox ID="TextBox8" runat="server" Enabled ="false"> </asp:TextBox>
            </td>
           
           <td style="width: 15%; height: 20px;" align="right">
                <asp:Label ID="Label9" runat="server" Text="认证进度："></asp:Label>
                </td>
            <td style="width: 19%; height: 20px;" align="left">
               <asp:DropDownList ID="DropDownList1" runat="server"  Width="130px" >
                     <asp:ListItem>请选择</asp:ListItem>
                    <asp:ListItem>小件</asp:ListItem>
                    <asp:ListItem>小批量</asp:ListItem>
                   <asp:ListItem>中批量</asp:ListItem>
                   <asp:ListItem>大批量</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="Label47" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
          
            <td style="width: 15%; height: 20px;" align="right">
            <asp:Label ID="Label13" runat="server" Text="认证结果："></asp:Label>
            </td>
               <td style=" height: 20px;" align="left">
                  <asp:DropDownList ID="DropDownList2" runat="server"  Width="121px">
                     <asp:ListItem>请选择</asp:ListItem>
                    <asp:ListItem>合格</asp:ListItem>
                    <asp:ListItem>普通</asp:ListItem>
                   <asp:ListItem>不合格</asp:ListItem>
                
                </asp:DropDownList>
                <asp:Label ID="Label48" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td> 
            </tr>
            <tr>
             
            <td   align="right" style="width: 12%">
                <asp:Label ID="Label12" runat="server" Text="规格型号："></asp:Label>
            </td>
            
            <td   align="left" style="width: 19%">
                <asp:TextBox runat="server" ID="TextBox9" ></asp:TextBox>
                <asp:Label ID="Label49" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td> 
             <td  align="center" colspan="1">
                <asp:Button ID="Button27" runat="server" Text="上传附件" CssClass="Button02" Height="24px" OnClick="Button_Aline"
                    Width="90px" />
            </td>
</tr>
<tr>
<td align="right" style="width: 12%">
                <asp:Label ID="Label14" runat="server" Text="备注："></asp:Label>
                <br/>
                <asp:Label ID="label153" runat="server" text="(200字以内)" Visible="true"></asp:Label>
            </td>
            
            <td   align="left" colspan="5">
                <asp:TextBox runat="server" ID="TextBox11"  Height="81px" Width="90%" Visible="true" Enabled ="true" MaxLength="200" TextMode="MultiLine" 
                onkeyup="this.value = this.value.substring(0, 200)" onafterpaste="this.value = this.value.substring(0, 200)"></asp:TextBox>
             <asp:Label ID="Label142" runat="server" Text="*" ForeColor="Red"></asp:Label>
               

            </td>
</tr>
            <tr>
            <td style="width: 12%"  >
                        &nbsp;</td>
                <td  align="center" colspan="2">
                    <asp:Button ID="Button9" runat="server" CssClass="Button02" Height="24px" 
                        OnClick="Button1_ComWH" Text="提交" Width="70px" />
                        </td>
                        <td colspan="2"  align="center" >
                    <asp:Button ID="Button10" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="Button_CancelWH"
                    Width="70px" />
                </td>
                 <td  >
                        &nbsp;</td>
                </tr>
             
        </tr>
    </table>
     </fieldset>
       </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
  
   <div id="Div1" >
     <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
       
        <ContentTemplate>
             
                <fieldset>
                    <legend> 附件上传</legend>
                     <asp:Label ID="label_AccNum" runat="server"  Visible="false"></asp:Label>
                     <asp:Label ID="label_AccName" runat="server"  Visible="false"></asp:Label>
                      <asp:Label ID="label_AccPath" runat="server"  Visible="false"></asp:Label>
                      <asp:Label ID="Label_FilePath" runat="server"  Visible="false"></asp:Label>
                      <asp:Label ID="LabelQ_SaveDirectory" runat="server"  Visible="false"></asp:Label>
    <table style="width: 100%;">
    <tr style="height: 16px;">
    <td style="width: 6%; height: 17px;" align="right">
                <asp:Label ID="Label51" runat="server" Text="附件编号："></asp:Label>
            </td>
             <td style="width: 11%; height: 17px;" align="left">
                <asp:TextBox runat="server" ID="TextBox18" Enabled ="true" > </asp:TextBox>
                <asp:Label ID="Label52" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
           
             <td align="right" style="width: 6%; height: 17px;">
                <asp:Label ID="Label53" runat="server" Text="附件名称："></asp:Label>
            </td>
             <td style="width: 11%; height: 17px;" align="left">
                <asp:TextBox runat="server" ID="TextBox19" Enabled ="true" > </asp:TextBox>
                <asp:Label ID="Label54" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
    <td style="width: 6%; height: 17px;" align="right">
                <asp:Label ID="Label55" runat="server" Text="上传文件："></asp:Label>
               
                </td>
                 <td style="width: 17%" align="left">
                     <asp:FileUpload ID="FileUpload1" runat="server" Width="189px" />
                   <asp:Label ID="Label56" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            
            </tr>
            <tr>
                
            <td  align="right" colspan="1" style="width: 6%">
            </td>
             <td  align="right" colspan="2">
                
                <asp:Button ID="Button28" runat="server" Text="提交" CssClass="Button02" Height="24px" OnClick="Button1_Fox"
                    Width="90px" />
            </td>
             <td  align="right" colspan="2">
                
                <asp:Button ID="Button29" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="Button1_Emi"
                    Width="90px" />
            </td>
            </tr>
     </table>
     </fieldset>
        </ContentTemplate>
     
<Triggers>
    <asp:PostBackTrigger ControlID="Button28" />
        </Triggers>
        <%--<Triggers>
            <asp:AsyncPostBackTrigger ControlID="Button_TijiaoWeihu" EventName="Click" />
        </Triggers>--%>
        </asp:UpdatePanel>
  </div>


     <asp:UpdatePanel ID="UpdatePanel_Preserve" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <asp:Panel ID="Panel_Preserve" runat="server" Visible="false">
            <fieldset>
                <legend>
                <asp:Label ID="label_WHB" runat="server" Visible="true"></asp:Label>
                </legend>
                <asp:Label ID="label_RTX3" runat="server" Visible="true"></asp:Label>
     <asp:GridView ID="Gridview2"  runat="server" AutoGenerateColumns="False"
                    CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"
                    Font-Strikeout="False" GridLines="None" PageSize="5" 
                    OnRowCommand="Gridview_Preserve_RowCommand"  
                    AllowPaging="True" AllowSorting="True" DataKeyNames="PMSCI_ID"   OnPageIndexChanging="Gridview_Preserve_PageIndexChanging" 
                    Width="100%" ondatabound="Gridview2_DataBound" 
                    onrowdatabound="Gridview2_RowDataBound">
                    <%--    //隔行变色--%>
           
           
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
           
           
                    <PagerStyle CssClass="GridViewPagerStyle" />
           
           
              <AlternatingRowStyle />
           
           
                    <Columns>
                        <asp:BoundField DataField="PMSCI_ID" HeaderText="认证编号" 
                            SortExpression="PMSCI_ID" Visible="False">
                          
                        </asp:BoundField>
                       
                        <asp:BoundField DataField="PMSCI_Model" HeaderText="规格型号" 
                            SortExpression="PMSCI_Model" />
                       
                        <asp:BoundField DataField="PMSCI_CheckDepertment" HeaderText="测试部门" 
                            SortExpression="PMSCI_CheckDepertment">
                        </asp:BoundField>
                        <asp:BoundField DataField="PMSCI_CertificSchedule" HeaderText="认证进度" 
                            SortExpression="PMSCI_CertificSchedule" />
                        <asp:BoundField DataField="PMSCI_CertificResult" HeaderText="认证结果" 
                            SortExpression="PMSCI_CertificResult" />
                        <asp:BoundField DataField="PMSCI_Remark" HeaderText="备注" 
                            SortExpression="PMSCI_Remark" />
                        <asp:BoundField DataField="PMSCI_Accessory" HeaderText="是否有附件" 
                            SortExpression="PMSCI_Accessory" />
                        <asp:BoundField DataField="PMSCI_AccNum" HeaderText="附件编号" 
                            SortExpression="PMSCI_AccNum" />
                        <asp:BoundField DataField="PMSCI_AccName" HeaderText="附件名称" 
                            SortExpression="PMSCI_AccName" />
                       <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="btnLook3" runat="server" CommandName="Edit1" 
                                    CommandArgument='<%#Eval("PMSCI_ID")%>'>编辑</asp:LinkButton>
                                   
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="btnLook4" runat="server" CommandName="Cancel1" OnClientClick="return confirm('您确认删除该记录吗?')" 
                                    CommandArgument='<%#Eval("PMSCI_ID")+","+Eval("PMSCI_AccPath")%>'>删除</asp:LinkButton>
                                   
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                        <ItemTemplate >
                        <asp:HyperLink ID="DownL" runat="server"   CommandArgument='<%#Eval("PMSCI_AccPath")%>'  NavigateUrl='<%#"~/"+Eval("PMSCI_AccPath")+"?path={0}"%>'>查看附件</asp:HyperLink>
                         </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="PMSCI_AccPath" HeaderText="附件相对路径" 
                            SortExpression="PMSCI_AccPath" Visible="False" />
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
               <td width="31%" align="right" >
                  
              <asp:Button ID="Button11" runat="server" Text="提交" CssClass="Button02" Height="24px" OnClick="Button_CF" Visible="true" 
                    Width="70px" />
                    </td>
                    <td style="width: 20%" align="center">
                   
                    &nbsp;</td>
                   
           <td width="30%" align="left">
               <asp:Button ID="Button12" runat="server" CssClass="Button02" Height="24px" 
                    OnClick="Button2_Cancel1" Text="关闭" Width="70px" />     
            </td>
            </tr>
              </table>  
            </fieldset>
            
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%-- <asp:UpdatePanel ID="UpdatePanel_Check" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Check" runat="server" Visible="false">
                <fieldset>
                    <legend>  <asp:Label ID="label_Check" runat="server" Visible="False"></asp:Label></legend>
    <table style="width: 100%;">
       
        <tr>
        <td style="width: 22%; height: 20px;" align="center">
               <asp:Label ID="Label16" runat="server" Text="技术副总审核" Visible="False"></asp:Label>
               </td>
            <td style="width: 12%; height: 20px;" align="left">
                <asp:Label ID="label_PRMP_DesignMangCheckResult" runat="server" Visible="False"></asp:Label></td>
            <td style="width: 15%; height: 20px;" align="right">
               <asp:Label ID="Label17" runat="server" Text="审核人：" Visible="false"></asp:Label>
            </td>
           <td style="width: 15%; height: 20px;" align="left">
                <asp:Label ID="label_PRMP_DesignMangName" runat="server" Visible="False"></asp:Label></td>
            <td style="width: 15%; height: 20px;" align="right">
                &nbsp;</td>
           <td style="width: 15%; height: 20px;" align="left">
                <asp:Label ID="label_Time" runat="server" Visible="False"></asp:Label></td> 
            <td style="width: 15%; height: 20px;" align="right">
                &nbsp;</td>
               <td style="width: 15%; height: 20px;" align="right">
                   &nbsp;</td> 
            </tr>
            <tr>
             <td  align="center">
                <asp:Label ID="label15" runat="server" Text="技术副总审核意见：" Visible="false"></asp:Label>
                <br/>
                 <asp:Label ID="label_XZ" runat="server" Text="(200字以内)" ></asp:Label>
            </td>
            
            <td  align="left"colspan="7" >
                <asp:TextBox runat="server" ID="TextBox10" Height="81px" Width="90%" Visible="False" MaxLength="200" TextMode="MultiLine"
                onkeyup="this.value = this.value.substring(0, 200)" onafterpaste="this.value = this.value.substring(0, 200)"></asp:TextBox>
            </td>
            </tr>
            <tr>
            <td  align="center">
                <asp:Label ID="label_Opinion" runat="server" Visible="False" Text = "总经理审核意见：" ></asp:Label>
                <br/>
                 <asp:Label ID="label_XZ1" runat="server" Text="(200字以内)" Visible="false"></asp:Label>
            </td>
            
            <td  align="left"colspan="7">
                <asp:TextBox runat="server" ID="TextBox14" Height="81px" Width="90%" MaxLength="200" TextMode="MultiLine"
                onkeyup="this.value = this.value.substring(0, 200)" onafterpaste="this.value = this.value.substring(0, 200)"></asp:TextBox>
            </td> 
            <tr>
           <td align="left"  >
                        &nbsp;</td>
                <td align="left" >
                    <asp:Button ID="Button13" runat="server" CssClass="Button02" Height="24px" 
                        OnClick="Button1_ComF" Text="通过" Width="70px" />
                        </td>
                        <td style="width: 12%" align="right" >
                    <asp:Button ID="Button15" runat="server" CssClass="Button02" Height="24px" 
                        OnClick="Button1_BH" Text="驳回" Width="70px" />
                        </td>
                        <td style="width: 25%" align="center" colspan="2">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button14" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="Button_CancelF"
                    Width="70px" />
                </td>
               
                </tr>             
    </table>
     </fieldset>
       </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>--%>
    
       <asp:UpdatePanel ID="UpdatePanel_Sign" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <asp:Panel ID="Panel_Sign" runat="server" Visible="false">
            <fieldset>
                <legend>认证申请会签表</legend>
                <asp:GridView ID="Gridview4"  runat="server" AutoGenerateColumns="False"
                    CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"
                    Font-Strikeout="False" GridLines="None" PageSize="5" 
                    OnRowCommand="Gridview4_RowCommand"  
                    AllowPaging="True" AllowSorting="True" 
                    DataKeyNames="PMSCAC_ID"   OnPageIndexChanging="Gridview_4_PageIndexChanging" 
                    Width="100%" 
                    EnableModelValidation="True"  ondatabound="Gridview4_DataBound" OnRowDataBound="Gridview4_RowDataBound" 
                     >
                    <%--    //隔行变色--%>
           
           
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
           
           
                    <PagerStyle CssClass="GridViewPagerStyle" />
  
           
              <AlternatingRowStyle />
           
           
                    <Columns>
                        <asp:BoundField DataField="PMSCAC_ID" HeaderText="认证会签ID" SortExpression="PMSCA_CertificApplyNum" 
                            Visible="False">
                        </asp:BoundField>
                       
                        <asp:BoundField DataField="PMSCAC_SignPartment" HeaderText="会签部门" 
                            SortExpression="PMSCAC_SignPartment" >
                             
                            </asp:BoundField>
                        <asp:BoundField DataField="PMSCAC_SignResult" HeaderText="会签结果" 
                            SortExpression="PMSCAC_SignResult">
                          
                        </asp:BoundField>
                        <asp:BoundField DataField="PMSCAC_SignOpinion" HeaderText="会签意见" 
                            SortExpression="PMSCAC_SignOpinion">
                         
                        </asp:BoundField>
                         <asp:BoundField DataField="PMSCAC_SignMan" HeaderText="会签人" 
                            SortExpression="PMSCAC_SignMan">
                            
                        </asp:BoundField>
                        <asp:BoundField DataField="PMSCAC_SignTime" HeaderText="会签时间" 
                            SortExpression="PMSCAC_SignTime">
                            
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
                                    CommandArgument='<%#Eval("PMSCAC_ID")%>'>查看</asp:LinkButton>
                                   
                            </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="Myllo" runat="server" CommandName="Mylloo" 
                                    CommandArgument='<%#Eval("PMSCAC_ID")%>'>会签</asp:LinkButton>
                                   
                            </ItemTemplate>
                            </asp:TemplateField>
                        <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="Reco" runat="server" CommandName="Reco" OnClientClick="return confirm('您确认删除该记录吗?')" 
                                    CommandArgument='<%#Eval("PMSCAC_ID")%>'>删除</asp:LinkButton>
                                   
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
               <asp:Button ID="Button37" runat="server" CssClass="Button02" Height="24px" 
                    OnClick="Button_Ccl" Text="关闭" Width="70px" />     
            </td>
            </tr>
              </table>  

                </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

     <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
       <asp:Panel ID="Panel4" runat="server" Visible="false" Enabled ="true" >
                <fieldset>
                    <legend>  <asp:Label ID="label30" runat="server" Visible="true"></asp:Label></legend>
    <asp:Label ID="label_RTX1" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="label_RTX2" runat="server" Visible="false"></asp:Label>
    <table style="width: 100%;">
       
        <tr>
            <td align="right" style="width: 15%; height: 20px;">
                &nbsp;</td>
            <td align="left" style="width: 12%; height: 20px;">
                <asp:Label ID="label31" runat="server" Visible="false"></asp:Label>
            </td>
            <td align="right" style="width: 15%; height: 20px;">
                <asp:Label ID="Label32" runat="server" Text="会签人：" Visible="false"></asp:Label>
            </td>
            <td align="left" style="width: 15%; height: 20px;">
                <asp:Label ID="label33" runat="server" Visible="false"></asp:Label>
            </td>
            <td align="right" style="width: 15%; height: 20px;">
                &nbsp;</td>
            <td align="left" style="width: 15%; height: 20px;">
                <asp:Label ID="label34" runat="server" Visible="false"></asp:Label>
            </td>
            <td align="right" style="width: 15%; height: 20px;">
                &nbsp;</td>
            <td align="right" style="width: 15%; height: 20px;">
                &nbsp;</td>
            <tr>
             <td  align="center">
                <asp:Label ID="label35" runat="server"  Visible="true"></asp:Label>
                <br/>
                <asp:Label ID="labelXZ3" runat="server" text="(200字以内)" Visible="true"></asp:Label>
            </td>
            
            <td  align="left"colspan="7" >
                <asp:TextBox runat="server" ID="TextBox15" Height="81px" Width="90%" Visible="true" Enabled ="true" MaxLength="200" TextMode="MultiLine"
                onkeyup="this.value = this.value.substring(0, 200)" onafterpaste="this.value = this.value.substring(0, 200)"></asp:TextBox>
            </td>
            </tr>
           
           
             
   <%-- </table>--%>
   <%--  </fieldset>
       </asp:Panel>
       <asp:Panel ID="Panel5" runat="server" Visible="false"  >
                <fieldset>
                    <legend>  </legend>--%>
    <%--<table style="width: 100%;">--%>
     <tr>
            <td  style="width: 15%">
                        &nbsp;</td>
                         
                <td style="width: 15%" align="center" colspan="2">
                    <asp:Button ID="Button22" runat="server" CssClass="Button02" Height="24px" Enabled="true"
                        OnClick="Button1_ComFED" Text="通过" Width="70px" />
                        </td>
                        <td  style="width: 15%" align="center">
                        
                    <asp:Button ID="Button23" runat="server" CssClass="Button02" Height="24px" Enabled="true"
                        OnClick="Button1_BHED" Text="驳回" Width="70px" /></td>
                        <td style="width: 15%" align="center" colspan="2">
                        <asp:Button ID="Button24" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="Button_CancelFED"
                    Width="70px" />
                        </td>
                        <td  style="width: 15%">
                        &nbsp;</td>
                        <td style="width: 15%" align="center" colspan="2">
                    
                </td>
                <td  style="width: 15%">
                        &nbsp;</td>
                </tr>
                <tr>
                <td style="width: 15%" align="center" colspan="8">
                        <asp:Button ID="Button30" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="Button_CancelFEDD"
                    Width="70px" />
                        </td>
                </tr>
    </table>
     </fieldset>
       </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

     <asp:UpdatePanel ID="UpdatePanel_Check" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Check" runat="server" Visible="false">
                <fieldset>
                    <legend>  <asp:Label ID="label_Check" runat="server" Visible="False"></asp:Label></legend>
    <table style="width: 100%;">
       
        <tr>
        <td style="width: 15%; height: 20px;" align="center">
               <asp:Label ID="Label16" runat="server" Text="技术副总审核" Visible="False"></asp:Label>
               </td>
            <td style="width: 12%; height: 20px;" align="left">
                <asp:Label ID="label_PRMP_DesignMangCheckResult" runat="server" Visible="False"></asp:Label></td>
            <td style="width: 15%; height: 20px;" align="right">
               <asp:Label ID="Label17" runat="server" Text="审核人：" Visible="false"></asp:Label>
            </td>
           <td style="width: 15%; height: 20px;" align="left">
                <asp:Label ID="label_PRMP_DesignMangName" runat="server" Visible="False"></asp:Label></td>
            <td style="width: 15%; height: 20px;" align="right">
                &nbsp;</td>
           <td style="width: 15%; height: 20px;" align="left">
                <asp:Label ID="label_Time" runat="server" Visible="False"></asp:Label></td> 
            <td style="width: 15%; height: 20px;" align="right">
                &nbsp;</td>
               <td style="width: 15%; height: 20px;" align="right">
                   &nbsp;</td> 
            </tr>
            <tr>
             <td  align="center">
                <asp:Label ID="label15" runat="server" Text="审核意见：" Visible="false"></asp:Label>
                <br/>
                 <asp:Label ID="label_XZ" runat="server" Text="(200字以内)" ></asp:Label>
            </td>
            
            <td  align="left"colspan="7" >
                <asp:TextBox runat="server" ID="TextBox10" Height="81px" Width="90%" Visible="False" MaxLength="200" TextMode="MultiLine"
                onkeyup="this.value = this.value.substring(0, 200)" onafterpaste="this.value = this.value.substring(0, 200)"></asp:TextBox>
            </td>
            </tr>
             <tr>
        <td style="width: 15%; height: 20px;" align="center">
               
               </td>
            <td style="width: 12%; height: 20px;" align="left">
                <asp:Label ID="label19" runat="server" Visible="False"></asp:Label></td>
            <td style="width: 15%; height: 20px;" align="right">
               <asp:Label ID="Label20" runat="server" Text="审核人：" Visible="false"></asp:Label>
            </td>
           <td style="width: 15%; height: 20px;" align="left">
                <asp:Label ID="label21" runat="server" Visible="False"></asp:Label></td>
            <td style="width: 15%; height: 20px;" align="right">
                &nbsp;</td>
           <td style="width: 15%; height: 20px;" align="left">
                <asp:Label ID="label22" runat="server" Visible="False"></asp:Label></td> 
            <td style="width: 15%; height: 20px;" align="right">
                &nbsp;</td>
               <td style="width: 15%; height: 20px;" align="right">
                   &nbsp;</td> 
            </tr>
            <tr>
            <td  align="center">
                <asp:Label ID="label_Opinion" runat="server" Visible="False" Text = "总经理审核意见：" ></asp:Label>
                <br/>
                 <asp:Label ID="label_XZ1" runat="server" Text="(200字以内)" Visible="false"></asp:Label>
            </td>
            
            <td  align="left"colspan="7">
                <asp:TextBox runat="server" ID="TextBox14" Height="81px" Width="90%" MaxLength="200" TextMode="MultiLine"
                onkeyup="this.value = this.value.substring(0, 200)" onafterpaste="this.value = this.value.substring(0, 200)"></asp:TextBox>
            </td> 
            <tr>
           <td align="left"  >
                        &nbsp;</td>
                <td align="left" >
                    <asp:Button ID="Button13" runat="server" CssClass="Button02" Height="24px" 
                        OnClick="Button1_ComF" Text="通过" Width="70px" />
                        </td>
                        <td style="width: 12%" align="right" >
                    <asp:Button ID="Button15" runat="server" CssClass="Button02" Height="24px" 
                        OnClick="Button1_BH" Text="驳回" Width="70px" />
                        </td>
                        <td style="width: 25%" align="center" colspan="2">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button14" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="Button_CancelF"
                    Width="70px" />
                </td>
               
                </tr>   
                
                <tr>
                <td style="width: 15%" align="center" colspan="8">
                        <asp:Button ID="Button35" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="Button_Closes"
                    Width="70px" />
                        </td>
                </tr>          
    </table>
     </fieldset>
       </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    </asp:Content>