<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PMCopperFoundry.aspx.cs" Inherits="ProjectManagement_PMCopperFoundry" MasterPageFile="~/Other/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
        <style type="text/css">
        .hidden
        {
            display: none;
        }
    </style>
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script> 
    <asp:UpdatePanel ID="UpdatePanel_CopperFoundrySearch" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_CopperFoundrySearch" runat="server" Visible="true">
                <fieldset>
                    <legend> 检索条件</legend>
    <table style="width: 100%;">  
         <asp:Label ID="label_QA" runat="server" Visible="False"></asp:Label>
        <tr>
        <td style="width: 15%" align="right">
                <asp:Label ID="Label1" runat="server" Text="供应商名称："></asp:Label>
            </td>
            <td style="width: 12%" align="left">
                <asp:TextBox ID="TextBox_Factory" runat="server"> </asp:TextBox>
            </td>
            <td style="width: 15%" align="right">
                <asp:Label ID="Label2" runat="server" Text="供应商编号："></asp:Label>
            </td>
            <td style="width: 12%" align="left">
               <asp:TextBox ID="TextBox1" runat="server"> </asp:TextBox>
            </td>

            <td style="width: 15%" align="right">
                <asp:Label ID="Label3" runat="server" Text="铜材名称："></asp:Label>
            </td>
               <td style="width: 15%; height: 20px;" align="left">
                <asp:TextBox ID="TextBox2" runat="server"> </asp:TextBox>
            </td>
            </tr>
            <tr>
            <td style="width: 15%" align="right">
                <asp:Label ID="Label5" runat="server" Text="时间："></asp:Label>
            </td>
                <td style="width: 12%" align="left" colspan="3">
                <asp:TextBox ID="TextBox_Time1" runat="server"  onfocus="new WdatePicker(this,'%Y-%M-%D %h:%m:%s',true)"  ></asp:TextBox>
            
                    &nbsp;
            
               <asp:Label ID="Label7" runat="server" Text="至"></asp:Label>
            
                    &nbsp;
            
                <asp:TextBox ID="TextBox_Time2" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D %h:%m:%s',true)"  ></asp:TextBox>
            </td>   
        </tr>
       
        <tr>
        <td style="width: 15%" align="left">
                &nbsp;</td>
            <td colspan="2" align="left">
                <asp:Button ID="Button1" runat="server" Text="检索" CssClass="Button02" Height="24px" OnClick="Button1_Sh"
                    Width="70px" />
            </td>
          
            <td colspan="2" align="left">
                
                <asp:Button ID="Button3" runat="server" Text="新增" CssClass="Button02" Height="24px" OnClick="Button3_New" Visible="true"
                    Width="70px" />
            </td>
            <td style="width: 15%" align="left" colspan="2">
               <asp:Button ID="Button2" runat="server" Text="重置" CssClass="Button02" Height="24px" OnClick="Button3_Reset" Visible="true"
                    Width="70px" /></td>
        </tr>
    </table>
     </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
   
    <asp:UpdatePanel ID="UpdatePanel_Copper" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <asp:Panel ID="Panel_Copper" runat="server" Visible="true">
            <fieldset>
                <legend>铜材代工表</legend>
                 <asp:Label ID="label_CopperID" runat="server" Visible="false"></asp:Label>
                <asp:GridView ID="Gridview1"  runat="server" AutoGenerateColumns="False"
                    CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"
                    Font-Strikeout="False" GridLines="None" PageSize="10" 
                    OnRowCommand="Gridview1_RowCommand"  
                    AllowPaging="True" AllowSorting="True" 
                    DataKeyNames="PMCF_ID"   OnPageIndexChanging="Gridview_Project_PageIndexChanging" 
                    Width="100%" 
                    EnableModelValidation="True" 
                     >
                    <%--    //隔行变色--%>
           
           
              <AlternatingRowStyle />
           
           <%--
            <PagerStyle ForeColor="Black" 
                 HorizontalAlign="Center" CssClass="GridViewPagerStyle" />--%>
           
           
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
           
           
                    <Columns>
                    <asp:BoundField DataField="PMCF_ID" HeaderText="铜材代工ID" SortExpression="PMCF_ID" 
                            Visible="False">
                        </asp:BoundField>
                        <asp:BoundField DataField="PMSI_SupplyNum" HeaderText="供应商编号" SortExpression="PMSI_SupplyNum" 
                           >
                        </asp:BoundField>
                       
                        <asp:BoundField DataField="PMSI_SupplyName" HeaderText="供应商名称" 
                            SortExpression="PMSI_SupplyName" >
                             
                            </asp:BoundField>
                        <asp:BoundField DataField="PMCF_MaterialName" HeaderText="铜材名称" 
                            SortExpression="PMCF_MaterialName">
                          
                        </asp:BoundField>
                        <asp:BoundField DataField="PMCF_ReturnTotalNum" HeaderText="退料总量" 
                            SortExpression="PMCF_ReturnTotalNum">
                         
                        </asp:BoundField>
                         <asp:BoundField DataField="PMCF_InTotalNum" HeaderText="正料总量" 
                            SortExpression="PMCF_InTotalNum">
                            
                        </asp:BoundField>
                        <asp:BoundField DataField="PMCF_NetMargin" HeaderText="角料净结存量" 
                            SortExpression="PMCF_NetMargin">
                            </asp:BoundField>
                           <asp:BoundField DataField="PMCF_Time" HeaderText="时间" 
                            SortExpression="PMCF_Time"> 
                        </asp:BoundField>
                        
                     
                        <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="tLook1" runat="server" CommandName="Mody" 
                                    CommandArgument='<%#Eval("PMCF_ID")%>'>编辑</asp:LinkButton>
                                 
                            </ItemTemplate>
                             
                        </asp:TemplateField>
                         <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="btLook2" runat="server" CommandName="CopperIn" 
                                    CommandArgument='<%#Eval("PMCF_ID")%>'>正料</asp:LinkButton>
                                   
                            </ItemTemplate>
                            
                        </asp:TemplateField>
                       <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="btLk1" runat="server" CommandName="Return" 
                                    CommandArgument='<%#Eval("PMCF_ID")%>'>退料</asp:LinkButton>
                                 
                            </ItemTemplate>
                             
                        </asp:TemplateField>
                        <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="btLLk1" runat="server" CommandName="ADD" 
                                    CommandArgument='<%#Eval("PMCF_ID")%>'>加工</asp:LinkButton>
                                 
                            </ItemTemplate>
                             
                        </asp:TemplateField>
                        <asp:BoundField DataField="PMSI_ID" HeaderText="供应商ID" SortExpression="PMSI_ID" 
                           >
                             <FooterStyle CssClass="hidden" />
                                <HeaderStyle CssClass="hidden" />
                                <ItemStyle CssClass="hidden" />
                        </asp:BoundField>
                    </Columns>
               <EmptyDataTemplate>
              <asp:Label ID="Label50" runat="server" Text="无相关记录！"></asp:Label>
             </EmptyDataTemplate>
                    <FooterStyle CssClass="GridViewFooterStyle" />
                    <HeaderStyle CssClass="GridViewHead" 
                        HorizontalAlign="Center" />
           
           
                  <%--  <PagerStyle CssClass="GridViewPagerStyle" />--%>
  
           
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

     <asp:UpdatePanel ID="UpdatePanel_CopperNew" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_CopperNew" runat="server" Visible="false">
                <fieldset>
                    <legend> <asp:Label ID="label_New" runat="server" Visible="true"></asp:Label></legend>
                    <asp:Label ID="label_SampleID" runat="server" Visible="false"></asp:Label>
    <table style="width: 100%;">
       
        <tr>
        <td style="width: 15%; height: 20px;" align="right">
                <asp:Label ID="Label8" runat="server" Text="铜材名称："></asp:Label>
            </td>
            <td style="width: 12%; height: 20px;" align="left">
                <asp:TextBox ID="TextBox4" runat="server"> </asp:TextBox>
                <asp:Label ID="Label37" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            
           <td style="width: 15%; height: 20px;" align="right">
                <asp:Label ID="Label12" runat="server" Text="退料总量(KG)："></asp:Label>
            </td>
            <td style="width: 12%; height: 20px;" align="left">
                <asp:TextBox ID="TextBox3" runat="server" onkeyup="this.value=this.value.replace(/[^0-9.]/g,'')"
                                    onafterpaste="this.value=this.value.replace(/[^0-9.]/g,'')"> </asp:TextBox>
                                    <asp:Label ID="Label39" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
           
            <td style="width: 15%; height: 20px;" align="right">
            <asp:Label ID="Label6" runat="server" Text="供应商："></asp:Label>
            </td>
               <td style="width: 15%; height: 20px;" align="right">
                <asp:TextBox ID="TextBox6" runat="server" Enabled="false"> </asp:TextBox>
                <asp:Label ID="Label40" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td> 
            <td style="width: 15%; height: 20px;" align="left">
                <asp:Button ID="Button4" runat="server" CssClass="Button02" Height="24px" 
                        OnClick="Button_SupplySearch" Text="选择..." Width="50px" /></td>
            </tr>
            <tr>
            
             <td style="width: 15%; height: 20px;" align="right">
                <asp:Label ID="Label9" runat="server" Text="正料总量(KG)："></asp:Label>
                </td>
            <td style="width: 15%; height: 20px;" align="right">
<asp:TextBox ID="TextBox5" runat="server" onkeyup="this.value=this.value.replace(/[^0-9.]/g,'')"
                                    onafterpaste="this.value=this.value.replace(/[^0-9.]/g,'')"> </asp:TextBox>
            <asp:Label ID="Label41" runat="server" Text="*" ForeColor="Red"></asp:Label>
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
                <asp:Label ID="Label11" runat="server" Text="供应商编码："></asp:Label>
            </td>
            <td style="width: 12%; height: 20px;" align="left">
                <asp:TextBox ID="TextBox23" runat="server"> </asp:TextBox>
            </td>
            
           
            <td style="width: 12%; height: 20px;" align="left">
            
            </td>
           
            <td style="width: 12%; height: 20px;" align="right">
            <asp:Label ID="Label38" runat="server" Text="供应商名称："></asp:Label>
            </td>
               <td style="width: 15%; height: 20px;" align="left">
                <asp:TextBox ID="TextBox24" runat="server"></asp:TextBox>
            </td> 
            </tr>
            <tr>
            
                <td  align="center" colspan="3">
                    <asp:Button ID="Button21" runat="server" CssClass="Button02" Height="24px" 
                        OnClick="Button1_KiMi" Text="检索" Width="80px" />
                        </td>
                        <td colspan="3" align="center">
                    <asp:Button ID="Button22" runat="server" Text="重置" CssClass="Button02" Height="24px" OnClick="Button_CoMi"
                    Width="80px" />
                </td>
              
                </tr>
       
    </table>
                 <asp:Label ID="label_SupplyID" runat="server" Visible="false"></asp:Label>
                <asp:GridView ID="Gridview_PMSupply"  runat="server" AutoGenerateColumns="False"
                    CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"
                    Font-Strikeout="False" GridLines="None" PageSize="5" 
                    AllowPaging="True" AllowSorting="True" DataKeyNames="PMSI_ID"   OnPageIndexChanging="Gridview_PMSupply_PageIndexChanging" 
                    Width="100%" 
                    EnableModelValidation="True" 
                    onrowdatabound="Gridview_PMSupply_RowDataBound"  >
                    <%--    //隔行变色--%>
           
           
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
           
           
                    <%--<PagerStyle CssClass="GridViewPagerStyle" />--%>
           
           
              <AlternatingRowStyle />
           
           
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
                       
                    </Columns>
               <EmptyDataTemplate>
              <asp:Label ID="Label50" runat="server" Text="无相关记录！"></asp:Label>
             </EmptyDataTemplate>
                    <FooterStyle CssClass="GridViewFooterStyle" />
                    <HeaderStyle CssClass="GridViewHead" 
                        HorizontalAlign="Center" />
           
           
            <%--<PagerStyle  ForeColor="Black" 
                 HorizontalAlign="Center" CssClass="GridViewPagerStyle" />--%>
           
           
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
 
    <asp:UpdatePanel ID="UpdatePanel_CopperIn" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <asp:Panel ID="Panel_CopperIn" runat="server" Visible="false">
            <fieldset>
                <legend>铜材正料表</legend>
                <asp:Button ID="Button9" runat="server" Text="新增" CssClass="Button02" Height="24px" OnClick="Button_lio"
                    Width="70px" />
                 <asp:Label ID="label_CopperInID" runat="server" Visible="false"></asp:Label>
                 <asp:Label ID="label_CopperIn" runat="server" Visible="false"></asp:Label>
                <asp:GridView ID="Gridview2"  runat="server" AutoGenerateColumns="False"
                    CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"
                    Font-Strikeout="False" GridLines="None" PageSize="5" 
                    OnRowCommand="Gridview2_RowCommand"  
                    AllowPaging="True" AllowSorting="True" 
                    DataKeyNames="PMCI_ID"   OnPageIndexChanging="Gridview2_PageIndexChanging" 
                    Width="100%" 
                    EnableModelValidation="True" >
                    <%--    //隔行变色--%>
           
           
              <AlternatingRowStyle />
           
           
            <%--<PagerStyle ForeColor="Black" 
                 HorizontalAlign="Center" CssClass="GridViewPagerStyle" />
           --%>
           
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
           
           
                    <Columns>
                    <asp:BoundField DataField="PMCI_ID" HeaderText="铜材正料ID" SortExpression="PMCI_ID" 
                            Visible="False">
                        </asp:BoundField>
                        <asp:BoundField DataField="PMCI_Model" HeaderText="规格" SortExpression="PMCI_Model" 
                           >
                        </asp:BoundField>
                        <asp:BoundField DataField="PMCI_ProductNum" HeaderText="成品数量" SortExpression="PMCI_ProductNum" 
                           >
                        </asp:BoundField>
                       
                        <asp:BoundField DataField="PMCI_ProPrice" HeaderText="加工单价" 
                            SortExpression="PMCI_ProPrice" >
                             
                            </asp:BoundField>
                        <asp:BoundField DataField="PMCI_BillTotalPrice" HeaderText="开票总额" 
                            SortExpression="PMCI_BillTotalPrice">
                          
                        </asp:BoundField>
                        <asp:BoundField DataField="PMCI_AccountRate" HeaderText="折扣率" 
                            SortExpression="PMCI_AccountRate">
                         
                        </asp:BoundField>
                         <asp:BoundField DataField="PMCI_ExpendNum" HeaderText="消耗角料数量" 
                            SortExpression="PMCI_ExpendNum">
                            
                        </asp:BoundField>
                        <asp:BoundField DataField="PMCI_BillNum" HeaderText="开票单号" 
                            SortExpression="PMCI_BillNum">
                            </asp:BoundField>
                           <asp:BoundField DataField="PMCI_Remark" HeaderText="备注" 
                            SortExpression="PMCI_Remark"> 
                        </asp:BoundField>
                        <asp:BoundField DataField="PMCI_Pay" HeaderText="是否已付款" 
                            SortExpression="PMCI_Pay"> 
                        </asp:BoundField>
                        <asp:BoundField DataField="PMCI_Time" HeaderText="时间" 
                            SortExpression="PMCI_Time"> 
                        </asp:BoundField>
                        <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="tLook1" runat="server" CommandName="Merry" 
                                    CommandArgument='<%#Eval("PMCI_ID")%>'>编辑</asp:LinkButton>
                                 
                            </ItemTemplate>
                             
                        </asp:TemplateField>
                         <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="btLook2" runat="server" CommandName="Denol" OnClientClick="return confirm('您确认删除该记录吗?')"
                                    CommandArgument='<%#Eval("PMCI_ID")%>'>删除</asp:LinkButton>
                                   
                            </ItemTemplate>
                            
                        </asp:TemplateField>  
                    </Columns>
               <EmptyDataTemplate>
              <asp:Label ID="Label50" runat="server" Text="无相关记录！"></asp:Label>
             </EmptyDataTemplate>
                    <FooterStyle CssClass="GridViewFooterStyle" />
                    <HeaderStyle CssClass="GridViewHead" 
                        HorizontalAlign="Center" />
           
           
                    <%--<PagerStyle CssClass="GridViewPagerStyle" />--%>
  
           
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
                <td align="center">
               
                <asp:Button ID="Button10" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="Button_Clio"
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
                <legend>铜材退料表</legend>
                <asp:Button ID="Button11" runat="server" Text="新增" CssClass="Button02" Height="24px" OnClick="Button_NewZy"
                    Width="70px" />
                 <asp:Label ID="label_CopperReturnID" runat="server" Visible="false"></asp:Label>
                 <asp:Label ID="label_CopperRT" runat="server" Visible="false"></asp:Label>
                <asp:GridView ID="Gridview3"  runat="server" AutoGenerateColumns="False"
                    CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"
                   Font-Strikeout="False" GridLines="None" PageSize="5" 
                    OnRowCommand="Gridview3_RowCommand"  
                    AllowPaging="True" AllowSorting="True" 
                    DataKeyNames="PMCR_ID"   OnPageIndexChanging="Gridview3_PageIndexChanging" 
                    Width="100%" 
                    EnableModelValidation="True"   >
                    <%--    //隔行变色--%>
           
           
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
           
           
                    <%--<PagerStyle CssClass="GridViewPagerStyle" />--%>
  
           
              <AlternatingRowStyle />
           
           
                    <Columns>
                    <asp:BoundField DataField="PMCR_ID" HeaderText="铜材退料ID" SortExpression="PMCR_ID" 
                            Visible="False">
                        </asp:BoundField>
                        <asp:BoundField DataField="PMCR_Num" HeaderText="数量" SortExpression="PMCR_Num" 
                           >
                        </asp:BoundField>
                       
                        <asp:BoundField DataField="PMCR_DeductRate" HeaderText="扣杂率" 
                            SortExpression="PMCR_DeductRate" >
                             
                            </asp:BoundField>
                        <asp:BoundField DataField="PMCR_DeductNum" HeaderText="扣杂数量" 
                            SortExpression="PMCR_DeductNum">
                          
                        </asp:BoundField>
                        <asp:BoundField DataField="PMCR_NetNum" HeaderText="净数量" 
                            SortExpression="PMCR_NetNum">
                         
                        </asp:BoundField>
                         <asp:BoundField DataField="PMCR_Remark" HeaderText="备注" 
                            SortExpression="PMCR_Remark">
                            
                        </asp:BoundField>
                        
                        <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="tLook1" runat="server" CommandName="Mole" 
                                    CommandArgument='<%#Eval("PMCR_ID")%>'>编辑</asp:LinkButton>
                                 
                            </ItemTemplate>
                             
                        </asp:TemplateField>
                         <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="btLook2" runat="server" CommandName="Dani" OnClientClick="return confirm('您确认删除该记录吗?')"
                                    CommandArgument='<%#Eval("PMCR_ID")%>'>删除</asp:LinkButton>
                                   
                            </ItemTemplate>
                            
                        </asp:TemplateField>  
                    </Columns>
               <EmptyDataTemplate>
              <asp:Label ID="Label50" runat="server" Text="无相关记录！"></asp:Label>
             </EmptyDataTemplate>
                    <FooterStyle CssClass="GridViewFooterStyle" />
                    <HeaderStyle CssClass="GridViewHead" 
                        HorizontalAlign="Center" />
           
           
           <%-- <PagerStyle ForeColor="Black" 
                 HorizontalAlign="Center" CssClass="GridViewPagerStyle" />--%>
           
           
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
                
             <td align="center">
               
                <asp:Button ID="Button12" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="Button_CNewZy"
                    Width="70px" />
            </td>
            
                </tr>
                </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
 
      <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <asp:Panel ID="Panel2" runat="server" Visible="false">
            <fieldset>
                <legend>铜材加工价格表</legend>
                <asp:Button ID="Button13" runat="server" Text="新增" CssClass="Button02" Height="24px" OnClick="Button_Price"
                    Width="70px" />
                 <asp:Label ID="label_CopperPriceID" runat="server" Visible="false"></asp:Label>
                 <asp:Label ID="label_CopperPrice" runat="server" Visible="false"></asp:Label>
                <asp:GridView ID="Gridview4"  runat="server" AutoGenerateColumns="False"
                    CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"
                    Font-Strikeout="False" GridLines="None" PageSize="5" 
                    OnRowCommand="Gridview4_RowCommand"  
                    AllowPaging="True" AllowSorting="True" 
                    DataKeyNames="PMCP_ID"   OnPageIndexChanging="Gridview4_PageIndexChanging" 
                    Width="100%" 
                    EnableModelValidation="True" 
                     >
                    <%--    //隔行变色--%>
           
           
              <AlternatingRowStyle />
           
           
            <%--<PagerStyle ForeColor="Black" 
                 HorizontalAlign="Center" CssClass="GridViewPagerStyle" />--%>
           
           
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
           
           
                    <Columns>
                    <asp:BoundField DataField="PMCP_ID" HeaderText="加工价格ID" SortExpression="PMCP_ID" 
                            Visible="False">
                        </asp:BoundField>
                        <asp:BoundField DataField="PMCP_CopperPrice" HeaderText="电解铜价格" SortExpression="PMCP_CopperPrice" 
                           >
                        </asp:BoundField>
                       
                        <asp:BoundField DataField="PMCP_CopperDiscountRate" HeaderText="电解铜折扣率" 
                            SortExpression="PMCP_CopperDiscountRate" >
                             
                            </asp:BoundField>
                        <asp:BoundField DataField="PMCP_ZnPrice" HeaderText="Zn价格" 
                            SortExpression="PMCP_ZnPrice">
                          
                        </asp:BoundField>
                        <asp:BoundField DataField="PMCP_ZnDiscountRate" HeaderText="Zn折扣率" 
                            SortExpression="PMCP_ZnDiscountRate">
                         
                        </asp:BoundField>
                         <asp:BoundField DataField="PMCP_ProcessCost" HeaderText="加工价格" 
                            SortExpression="PMCP_ProcessCost">
                            
                        </asp:BoundField>
                        <asp:BoundField DataField="PMCP_UnitPrice" HeaderText="总单价" 
                            SortExpression="PMCP_UnitPrice">
                            </asp:BoundField>
                           <asp:BoundField DataField="PMCP_NowPrice" HeaderText="是否使用当前价格" 
                            SortExpression="PMCP_NowPrice"> 
                        </asp:BoundField>
             <asp:BoundField DataField="PMCP_AccountRate" HeaderText="折扣率" 
                            SortExpression="PMCP_AccountRate"> 
                        </asp:BoundField>
                        <asp:BoundField DataField="PMCP_MakeTime" HeaderText="制定时间" 
                            SortExpression="PMCP_MakeTime"> 
                        </asp:BoundField>
                        <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="tLook1" runat="server" CommandName="Cody" 
                                    CommandArgument='<%#Eval("PMCP_ID")%>'>编辑</asp:LinkButton>
                                 
                            </ItemTemplate>
                             
                        </asp:TemplateField>
                         <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="btLook2" runat="server" CommandName="Boly" OnClientClick="return confirm('您确认删除该记录吗?')"
                                    CommandArgument='<%#Eval("PMCP_ID")%>'>删除</asp:LinkButton>
                                   
                            </ItemTemplate>
                            
                        </asp:TemplateField>  
                    </Columns>
               <EmptyDataTemplate>
              <asp:Label ID="Label50" runat="server" Text="无相关记录！"></asp:Label>
             </EmptyDataTemplate>
                    <FooterStyle CssClass="GridViewFooterStyle" />
                    <HeaderStyle CssClass="GridViewHead" 
                        HorizontalAlign="Center" />
           
           
                <%--    <PagerStyle CssClass="GridViewPagerStyle" />--%>
  
           
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
               
                <asp:Button ID="Button14" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="Button_CPrice"
                    Width="70px" />
            </td>
            
                </tr>
                </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
   
    <asp:UpdatePanel ID="UpdatePanel_CopperInNew" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_CopperInNew" runat="server" Visible="false">
                <fieldset>
                    <legend> <asp:Label ID="label13" runat="server" Visible="true"></asp:Label></legend>
                    <asp:Label ID="label14" runat="server" Visible="false"></asp:Label>
    <table style="width: 100%;">
       
        <tr>
        <td style="width: 15%; height: 20px;" align="right">
                <asp:Label ID="Label15" runat="server" Text="成品数量(KG)："></asp:Label>
            </td>
            <td style="width: 12%; height: 20px;" align="left">
                <asp:TextBox ID="TextBox7" runat="server" onkeyup="this.value=this.value.replace(/[^0-9.]/g,'')"
                                    onafterpaste="this.value=this.value.replace(/[^0-9.]/g,'')"> </asp:TextBox>
            <asp:Label ID="Label42" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            
           <td style="width: 15%; height: 20px;" align="right">
                <asp:Label ID="Label16" runat="server" Text="加工单价："></asp:Label>
            </td>
            <td style="width: 12%; height: 20px;" align="left">
                <asp:TextBox ID="TextBox8" runat="server"> </asp:TextBox>
                <asp:Label ID="Label43" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
           
            <td style="width: 15%; height: 20px;" align="right">
            <asp:Label ID="Label17" runat="server" Text="开票总额："></asp:Label>
            </td>
               <td style="width: 15%; height: 20px;" align="right">
                <asp:TextBox ID="TextBox9" runat="server" onkeyup="this.value=this.value.replace(/[^0-9.]/g,'')"
                                    onafterpaste="this.value=this.value.replace(/[^0-9.]/g,'')"> </asp:TextBox>
           <asp:Label ID="Label44" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td> 
            </tr>
            <tr>
            
             <td style="width: 15%; height: 20px;" align="right">
                <asp:Label ID="Label18" runat="server" Text="折扣率："></asp:Label>
                </td>
            <td style="width: 15%; height: 20px;" align="right">
 <asp:TextBox ID="TextBox11" runat="server" onkeyup="this.value=this.value.replace(/[^0-9.]/g,'')"
                                    onafterpaste="this.value=this.value.replace(/[^0-9.]/g,'')"> </asp:TextBox>
           <asp:Label ID="Label45" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>

             
             <td style="width: 15%; height: 20px;" align="right">
                <asp:Label ID="Label20" runat="server" Text="开票单号："></asp:Label>
                </td>
            <td style="width: 15%; height: 20px;" align="right">
 <asp:TextBox ID="TextBox12" runat="server"> </asp:TextBox>
 <asp:Label ID="Label46" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
              <td style="width: 15%; height: 20px;" align="right">
                <asp:Label ID="Label21" runat="server" Text="是否已付款："></asp:Label>
                </td>
            <td style="width: 15%; height: 20px;" align="right">
                               <asp:DropDownList ID="DropDownList4" runat="server"  Width="125px">
                     <asp:ListItem>请选择</asp:ListItem>     
                      <asp:ListItem>是</asp:ListItem>  
                       <asp:ListItem>否</asp:ListItem>  
                </asp:DropDownList>
                <asp:Label ID="Label47" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            </tr>
            <tr>
            <td style="width: 15%; height: 20px;" align="right">
                <asp:Label ID="Label4" runat="server" Text="规格："></asp:Label>
                </td>
            <td style="width: 15%; height: 20px;" align="right">
 <asp:TextBox ID="TextBox22" runat="server"> </asp:TextBox>
 <asp:Label ID="Label48" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            </tr>
            <tr>
            <td style="width: 15%" align="right">
                <asp:Label ID="Label19" runat="server" Text="备注："></asp:Label>
                <br/>
                <asp:Label ID="Label_XZ2" runat="server" Text="(200字以内)"></asp:Label>
            </td>
            
            <td style="width: 17%" align="left"colspan="7">
                <asp:TextBox runat="server" ID="TextBox10" Height="81px" Width="100%" MaxLength="200" TextMode="MultiLine"
                 onkeyup="this.value = this.value.substring(0, 200)" onafterpaste="this.value = this.value.substring(0, 200)"
                          ></asp:TextBox>
<asp:Label ID="Label49" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td> 
            </tr>
            <tr>
            
                <td  align="center" colspan="4">
                    <asp:Button ID="Button16" runat="server" CssClass="Button02" Height="24px" 
                        OnClick="Button_Rocky" Text="提交" Width="70px" />
                        </td>
                        <td colspan="4" align="center">
                    <asp:Button ID="Button17" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="Button_CRocky"
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

      <asp:UpdatePanel ID="UpdatePane_CopperReturn" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_CopperReturn" runat="server" Visible="false">
                <fieldset>
                    <legend> <asp:Label ID="label22" runat="server" Visible="true"></asp:Label></legend>
                    <asp:Label ID="label23" runat="server" Visible="false"></asp:Label>
    <table style="width: 100%;">
       
        <tr>
        <td style="width: 12%; height: 20px;" align="right">
                <asp:Label ID="Label24" runat="server" Text="数量(KG)："></asp:Label>
            </td>
            <td style="width: 12%; height: 20px;" align="left">
                <asp:TextBox ID="TextBox13" runat="server" onkeyup="this.value=this.value.replace(/[^0-9.]/g,'')"
                                    onafterpaste="this.value=this.value.replace(/[^0-9.]/g,'')"> </asp:TextBox>
           <asp:Label ID="Label51" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            
           <td style="width: 15%; height: 20px;" align="right">
                <asp:Label ID="Label25" runat="server" Text="扣杂率："></asp:Label>
            </td>
            <td style="width: 12%; height: 20px;" align="left">
                <asp:TextBox ID="TextBox14" runat="server" onkeyup="this.value=this.value.replace(/[^0-9.]/g,'')"
                                    onafterpaste="this.value=this.value.replace(/[^0-9.]/g,'')"> </asp:TextBox>
                <asp:Label ID="Label52" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td style="width: 12%; height: 20px;" align="left">
           <asp:Label ID="Label10" runat="server" Text="(‰)"></asp:Label>
           </td>
            </tr>
            
            <tr>
            <td align="right">
                <asp:Label ID="Label30" runat="server" Text="备注："></asp:Label>
                <br/>
                <asp:Label ID="Label31" runat="server" Text="(200字以内)"></asp:Label>
            </td>
            
            <td style="width: 17%" align="left"colspan="4">
                <asp:TextBox runat="server" ID="TextBox18" Height="81px" Width="90%" 
                    MaxLength="200" TextMode="MultiLine"
                 onkeyup="this.value = this.value.substring(0, 200)" onafterpaste="this.value = this.value.substring(0, 200)"
                          ></asp:TextBox>
                          <asp:Label ID="Label53" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td> 
            </tr>
            <tr>
            
                <td  align="center" colspan="3">
                    <asp:Button ID="Button15" runat="server" CssClass="Button02" Height="24px" 
                        OnClick="Button_Rois" Text="提交" Width="70px" />
                        </td>
                        <td colspan="4" align="center">
                    <asp:Button ID="Button18" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="Button_CRois"
                    Width="70px" />
                </td>
                </tr>
             
        </tr>
    </table>
     </fieldset>
       </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    
      <asp:UpdatePanel ID="UpdatePanel_CopperPrice" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_CopperPrice" runat="server" Visible="false">
                <fieldset>
                    <legend> <asp:Label ID="label27" runat="server" Visible="true"></asp:Label></legend>
                    <asp:Label ID="label28" runat="server" Visible="false"></asp:Label>
    <table style="width: 100%;">
       
        <tr>
        <td style="width: 15%; height: 20px;" align="right">
                <asp:Label ID="Label29" runat="server" Text="电解铜价格："></asp:Label>
            </td>
            <td style="width: 12%; height: 20px;" align="left">
                <asp:TextBox ID="TextBox16" runat="server" onkeyup="this.value=this.value.replace(/[^0-9.]/g,'')"
                                    onafterpaste="this.value=this.value.replace(/[^0-9.]/g,'')"> </asp:TextBox>
            <asp:Label ID="Label54" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            
           <td style="width: 15%; height: 20px;" align="right">
                <asp:Label ID="Label32" runat="server" Text="电解铜折扣率："></asp:Label>
            </td>
            <td style="width: 12%; height: 20px;" align="left">
                <asp:TextBox ID="TextBox17" runat="server" onkeyup="this.value=this.value.replace(/[^0-9.]/g,'')"
                                    onafterpaste="this.value=this.value.replace(/[^0-9.]/g,'')"> </asp:TextBox>
           <asp:Label ID="Label55" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
           
            <td style="width: 15%; height: 20px;" align="right">
            <asp:Label ID="Label33" runat="server" Text="Zn价格：" ></asp:Label>
            </td>
               <td style="width: 15%; height: 20px;" align="right">
                <asp:TextBox ID="TextBox19" runat="server" onkeyup="this.value=this.value.replace(/[^0-9.]/g,'')"
                                    onafterpaste="this.value=this.value.replace(/[^0-9.]/g,'')"> </asp:TextBox>
            <asp:Label ID="Label56" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td> 
            </tr>
            <tr>
            
             <td style="width: 15%; height: 20px;" align="right">
                <asp:Label ID="Label34" runat="server" Text="Zn折扣率："></asp:Label>
                </td>
            <td style="width: 15%; height: 20px;" align="right" >
 <asp:TextBox ID="TextBox20" runat="server" onkeyup="this.value=this.value.replace(/[^0-9.]/g,'')"
                                    onafterpaste="this.value=this.value.replace(/[^0-9.]/g,'')"> </asp:TextBox>
          <asp:Label ID="Label57" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>

             
             <td style="width: 15%; height: 20px;" align="right">
                <asp:Label ID="Label35" runat="server" Text="加工费："></asp:Label>
                </td>
            <td style="width: 15%; height: 20px;" align="right">
 <asp:TextBox ID="TextBox21" runat="server" onkeyup="this.value=this.value.replace(/[^0-9.]/g,'')"
                                    onafterpaste="this.value=this.value.replace(/[^0-9.]/g,'')"> </asp:TextBox>
           <asp:Label ID="Label58" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
              <td style="width: 15%; height: 20px;" align="right">
                <asp:Label ID="Label36" runat="server" Text="折扣率："></asp:Label>
                </td>
            <td style="width: 15%; height: 20px;" align="right">
              <asp:TextBox ID="TextBox15" runat="server" onkeyup="this.value=this.value.replace(/[^0-9.]/g,'')"
                                    onafterpaste="this.value=this.value.replace(/[^0-9.]/g,'')"> </asp:TextBox>
                                    <asp:Label ID="Label59" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            </tr>
            <tr>
             <td style="width: 15%; height: 20px;" align="right">
                <asp:Label ID="Label26" runat="server" Text="是否使用当前价格："></asp:Label>
                </td>
            <td style="width: 15%; height: 20px;" align="right">
                               <asp:DropDownList ID="DropDownList1" runat="server"  Width="125px">
                     <asp:ListItem>请选择</asp:ListItem>     
                      <asp:ListItem>是</asp:ListItem>  
                       <asp:ListItem>否</asp:ListItem>  
                </asp:DropDownList>
                <asp:Label ID="Label60" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            </tr>
            <tr>
            
                <td  align="center" colspan="4">
                    <asp:Button ID="Button19" runat="server" CssClass="Button02" Height="24px" 
                        OnClick="Button_Meky" Text="提交" Width="70px" />
                        </td>
                        <td colspan="4" align="left">
                    <asp:Button ID="Button20" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="Button_CMeky"
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
    
     </asp:Content>




