<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CRMOutsideSample.aspx.cs" Inherits="ProjectManagement_CRMOutsideSample"  MasterPageFile="~/Other/MasterPage.master" %>
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
    <asp:UpdatePanel ID="UpdatePanel_OutsideSampleSearch" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_OutsideSampleSearch" runat="server" Visible="true">
                <fieldset>
                    <legend> 检索条件</legend>
    <table style="width: 100%;">  
         <asp:Label ID="label_QA" runat="server" Visible="False"></asp:Label>
        <tr>
        <td style="width: 17%" align="right">
                <asp:Label ID="Label1" runat="server" Text="生产厂家："></asp:Label>
            </td>
            <td style="width: 15%" align="left">
                <asp:TextBox ID="TextBox_Factory" runat="server"> </asp:TextBox>
            </td>
            <td style="width: 12%" align="right">
                <asp:Label ID="Label2" runat="server" Text="样品编号："></asp:Label>
            </td>
            <td style="width: 15%" align="left">
               <asp:TextBox ID="TextBox1" runat="server"> </asp:TextBox>
            </td>

            <td style="width: 12%" align="right">
                <asp:Label ID="Label3" runat="server" Text="状态："></asp:Label>
            </td>
               <td style=" height: 20px;" align="left">
               <asp:DropDownList ID="DropDownList3" runat="server"  Width="125px">
                     <asp:ListItem>请选择</asp:ListItem>     
                </asp:DropDownList>
            </td>
            </tr>
            <tr>
            <td  align="right">
                <asp:Label ID="Label4" runat="server" Text="是否提供对比报告："></asp:Label>
            </td>
            
            <td align="left">
                 <asp:DropDownList ID="DropDownList1" runat="server"  Width="125px">
                     <asp:ListItem>请选择</asp:ListItem>
                    <asp:ListItem>是</asp:ListItem>
                    <asp:ListItem>否</asp:ListItem> 
                </asp:DropDownList>
            </td> 
            <td align="right">
                <asp:Label ID="Label5" runat="server" Text="申请时间："></asp:Label>
            </td>
                <td align="left" colspan="3">
                <asp:TextBox ID="TextBox_Time1" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D ',true)"  ></asp:TextBox>
            
                    &nbsp;
            
               <asp:Label ID="Label7" runat="server" Text="至"></asp:Label>
            
                    &nbsp;
            
                <asp:TextBox ID="TextBox_Time2" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D ',true)"  ></asp:TextBox>
            </td>   
        </tr>
        <tr>
        <td  align="left">
                &nbsp;</td>
            <td colspan="2" align="left">
                <asp:Button ID="Button1" runat="server" Text="检索" CssClass="Button02" Height="24px" OnClick="Button1_Sh"
                    Width="70px" />
            </td>
          
            <td colspan="2" align="left">
                
                <asp:Button ID="Button3" runat="server" Text="新增" CssClass="Button02" Height="24px" OnClick="Button3_New" Visible="true"
                    Width="70px" />
            </td>
            <td  align="left" colspan="2">
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
                <legend>外来样品表</legend>
                 <asp:Label ID="label_Alert" runat="server" Visible="false"></asp:Label>
                <asp:GridView ID="Gridview1"  runat="server" AutoGenerateColumns="False"
                    CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"
                     PageSize="5"  Font-Strikeout="False" GridLines="None"
                    OnRowCommand="Gridview1_RowCommand"  
                    AllowPaging="True" AllowSorting="True" 
                    DataKeyNames="CRMOS_ID,CRMOS_Remark,CRMOS_AnalysisResult"   OnPageIndexChanging="Gridview_Project_PageIndexChanging" 
                    Width="100%" 
                    EnableModelValidation="True" onrow="Gridview1_RowDataBound" OnDataBound="Gridview1_DataBound" OnRowDataBound="Gridview1_RowDataBound1" 
                     >
                    <%--    //隔行变色--%>
           
           
              <AlternatingRowStyle />
           
           
           
           
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
           
           
                    <Columns>
                    <asp:BoundField DataField="CRMOS_ID" HeaderText="外送样品ID" SortExpression="CRMOS_ID" 
                            Visible="False">
                        </asp:BoundField>
                        <asp:BoundField DataField="CRMOS_SampleNum" HeaderText="样品编号" SortExpression="CRMOS_SampleNum" 
                           >
                        </asp:BoundField>
                       
                        <asp:BoundField DataField="CRMOS_Factory" HeaderText="生产厂家" 
                            SortExpression="CRMOS_Factory" >
                             
                            </asp:BoundField>
                        <asp:BoundField DataField="CRMOS_Time" HeaderText="申请时间" 
                            SortExpression="CRMOS_Time" DataFormatString="{0:yyyy-MM-dd}">
                          
                        </asp:BoundField>
                         <asp:BoundField DataField="CRMOS_ApplyMan" HeaderText="申请人" 
                            SortExpression="CRMOS_ApplyMan">
                          
                        </asp:BoundField>
                        <asp:BoundField DataField="CRMOS_AlertDay" HeaderText="提醒天数" 
                            SortExpression="CRMOS_AlertDay">
                         
                        </asp:BoundField>
                         <asp:BoundField DataField="CRMOS_AnalysisReport" HeaderText="要求报告" 
                            SortExpression="CRMOS_AnalysisReport">
                            
                        </asp:BoundField>
                        <asp:BoundField DataField="CRMOS_Num" HeaderText="样品数量" 
                            SortExpression="CRMOS_Num">
                            </asp:BoundField>
                           <asp:BoundField DataField="CRMOS_Remark" HeaderText="备注" 
                            SortExpression="CRMOS_Remark"> 
                        </asp:BoundField>
                        <asp:BoundField DataField="CRMOS_State" HeaderText="状态" 
                            SortExpression="CRMOS_State"> 
                        </asp:BoundField>
                               <asp:BoundField DataField="BDOS_Name" HeaderText="负责部门" 
                            SortExpression="BDOS_Name"> 
                        </asp:BoundField> <asp:BoundField DataField="CRMOS_CheckNote" HeaderText="审核意见" 
                            SortExpression="CRMOS_CheckNote"> 
                        </asp:BoundField>
                        <asp:BoundField DataField="CRMOS_CheckTime" HeaderText="下达时间" 
                            SortExpression="CRMOS_CheckTime" DataFormatString="{0:yyyy-MM-dd}"> 
                                </asp:BoundField>
                               <asp:BoundField DataField="CRMOS_AnalysisMan" HeaderText="分析人" 
                            SortExpression="CRMOS_AnalysisMan"> 
                        </asp:BoundField>
                               <asp:BoundField DataField="CRMOS_AnalysisResult" HeaderText="分析结论" 
                            SortExpression="CRMOS_AnalysisResult"> 
                        </asp:BoundField>
                         <asp:BoundField DataField="CRMOS_Upload" HeaderText="分析报告" 
                            SortExpression="CRMOS_Upload"> 
                        </asp:BoundField>
                        <asp:BoundField DataField="CRMOS_AnalysisTime" HeaderText="分析时间" 
                            SortExpression="CRMOS_AnalysisTime" DataFormatString="{0:yyyy-MM-dd}"> 
                        </asp:BoundField>
                        <asp:TemplateField Visible="false">
                            <ItemTemplate >
                                <asp:LinkButton ID="tLook1" runat="server" CommandName="Modify1" 
                                    CommandArgument='<%#Eval("CRMOS_ID")%>'>编辑</asp:LinkButton>
                                 
                            </ItemTemplate>
                             
                        </asp:TemplateField>
                         <asp:TemplateField Visible="false">
                            <ItemTemplate >
                                <asp:LinkButton ID="btLook2" runat="server" CommandName="Delete1" OnClientClick="return confirm('您确认删除该记录吗?')"
                                    CommandArgument='<%#Eval("CRMOS_ID")%>'>删除</asp:LinkButton>
                                   
                            </ItemTemplate>
                            
                        </asp:TemplateField>
                         <asp:TemplateField Visible="false">
                            <ItemTemplate >
                                <asp:LinkButton ID="Check1" runat="server" CommandName="Check1" 
                                    CommandArgument='<%#Eval("CRMOS_ID")%>'>审核</asp:LinkButton>
                            </ItemTemplate>                      
                        </asp:TemplateField>
                       <asp:TemplateField Visible="false">
                            <ItemTemplate >
                                <asp:LinkButton ID="btLk1" runat="server" CommandName="Analysis" 
                                    CommandArgument='<%#Eval("CRMOS_ID")%>'>分析</asp:LinkButton>
                                 
                            </ItemTemplate>
                             
                        </asp:TemplateField>
                                                    <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="UP1" runat="server" CommandName="UP1" OnClientClick="false"
                                        CommandArgument='<%#Eval("CRMOS_ID")%>'>上传分析报告</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:HyperLink ID="Down2" runat="server" NavigateUrl='<%#"~/"+Eval("CRMOS_Path")+"?path={0}"%>'>下载分析报告</asp:HyperLink>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                        
                        <asp:BoundField DataField="Time" HeaderText="现在时间" SortExpression="Time" 
                            Visible="true" >
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
        <td style="width: 17%; height: 20px;" align="right">
                <asp:Label ID="Label8" runat="server" Text="数量："></asp:Label>
            </td>
            <td style="width: 12%; height: 20px;" align="left">
                <asp:TextBox ID="TextBox4" runat="server" onkeyup="this.value=this.value.replace(/[^0-9]/g,'')"
                                    onafterpaste="this.value=this.value.replace(/[^0-9]/g,'')"> </asp:TextBox>
                                    <asp:Label ID="Label14" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            
           <td style="width: 15%; height: 20px;" align="right">
                <asp:Label ID="Label12" runat="server" Text="提醒天数："></asp:Label>
            </td>
            <td style="width: 12%; height: 20px;" align="left">
                <asp:TextBox ID="TextBox2" runat="server"  onkeyup="this.value=this.value.replace(/[^0-9]/g,'')"
                                    onafterpaste="this.value=this.value.replace(/[^0-9]/g,'')"> </asp:TextBox>
                <asp:Label ID="Label13" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
           
            <td style="width: 15%; height: 20px;" align="right">
            <asp:Label ID="Label6" runat="server" Text="供应商："></asp:Label>
            </td>
               <td style="width: 15%; height: 20px;" align="right">
                <asp:TextBox ID="TextBox6" runat="server"> </asp:TextBox>
                <asp:Label ID="Label15" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td> 
            <td style="width: 15%; height: 20px;" align="left">
                <asp:Button ID="Button4" runat="server" CssClass="Button02" Height="24px" 
                        OnClick="Button_SupplySearch" Text="选择..." Width="50px"  Visible="false"/></td>
            </tr>
            <tr>
            
             <td style="width: 15%; height: 20px;" align="right">
                <asp:Label ID="Label9" runat="server" Text="是否提供对比报告："></asp:Label>
                </td>
            <td style="width: 15%; height: 20px;" align="right">
                    <asp:DropDownList ID="DropDownList4" runat="server"  Width="125px">
                     <asp:ListItem>请选择</asp:ListItem>     
                      <asp:ListItem>是</asp:ListItem>  
                       <asp:ListItem>否</asp:ListItem>  
                </asp:DropDownList>
                <asp:Label ID="Label16" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            </tr>
            <tr>
            <td style="width: 15%" align=right>
                <asp:Label ID="Label11" runat="server" Text="备注："></asp:Label>
                <br/>
                <asp:Label ID="Label_XZ2" runat="server" Text="(200字以内)"></asp:Label>
            </td>
            
            <td style="width: 17%" align="left"colspan="7">
                <asp:TextBox runat="server" ID="TextBox7" Height="81px" Width="90%" MaxLength="200" TextMode="MultiLine"
                 onkeyup="this.value = this.value.substring(0, 200)" onafterpaste="this.value = this.value.substring(0, 200)"
                          ></asp:TextBox>
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
                    <legend>外来样品审核及负责部门指派</asp:Label></legend>
                    <asp:Label ID="label19" runat="server" Visible="false"></asp:Label>
                     <asp:Label ID="label18" runat="server" Visible="false"></asp:Label>
    <table style="width: 100%;">
       
    
            <tr>
            
             <td style="width: 15%; height: 20px;" align="right">
                <asp:Label ID="Label26" runat="server" Text="负责部门："></asp:Label>
                </td>
            <td style="width: 75%; height: 20px;" align="left">
                    <asp:DropDownList ID="DropDownList2" runat="server"  >
                    
                </asp:DropDownList>
                <asp:Label ID="Label27" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            </tr>
            <tr>
            <td style="width: 15%" align=right>
                <asp:Label ID="Label28" runat="server" Text="备注："></asp:Label>
                <br/>
                <asp:Label ID="Label29" runat="server" Text="(200字以内)"></asp:Label>
            </td>
            
            <td style="width: 17%" align="left"colspan="7">
                <asp:TextBox runat="server" ID="TextBox9" Height="81px" Width="90%" MaxLength="200" TextMode="MultiLine"
                 onkeyup="this.value = this.value.substring(0, 200)" onafterpaste="this.value = this.value.substring(0, 200)"
                          ></asp:TextBox>
            </td> 
            </tr>
        </table>
                    <table width="100%">
            <tr>
            
                <td  width="30%" align="center">
                    <asp:Button ID="Button10" runat="server" CssClass="Button02" Height="24px" 
                        OnClick="Check_OK" Text="审核通过" Width="70px" />
                        </td>
                  <td width="40%" align="center">
                    <asp:Button ID="Button9" runat="server" Text="审核驳回" CssClass="Button02" Height="24px" OnClick="Check_NOK"
                    Width="70px" />
                </td>
                        <td width="30%" align="center">
                    <asp:Button ID="Button11" runat="server" Text="取消" CssClass="Button02" Height="24px" OnClick="Check_Canel"
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
      <asp:UpdatePanel ID="UpdatePanel_Supply" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <asp:Panel ID="Panel_Supply" runat="server" Visible="false">
            <fieldset>
                <legend>供应商查询</legend>
                 <asp:Label ID="label_SupplyID" runat="server" Visible="false"></asp:Label>
               <table style="width: 100%;">
       
        <tr>
        <td style="width: 12%; height: 20px;" align="right">
             
            </td>
        <td style="width: 12%; height: 20px;" align="right">
                <asp:Label ID="Label10" runat="server" Text="供应商编码："></asp:Label>
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
                <asp:GridView ID="Gridview_PMSupply"  runat="server" AutoGenerateColumns="False"
                    CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"
                    PageSize="2" 
                    AllowPaging="True" AllowSorting="True" DataKeyNames="PMSI_SupplyName"   OnPageIndexChanging="Gridview_PMSupply_PageIndexChanging" 
                    Width="100%"  Font-Strikeout="False" GridLines="None"
                    EnableModelValidation="True" 
                    onrowdatabound="Gridview_PMSupply_RowDataBound"
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
 
    <asp:UpdatePanel ID="UpdatePanel_Check" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Check" runat="server" Visible="false">
                <fieldset>
                    <legend>  <asp:Label ID="label_Result" runat="server" Visible="true"></asp:Label></legend>
    <table style="width: 100%;">
       
       
           
            <tr>
            <td style="width: 15%" align="center">
                <asp:Label ID="label_Opinion" runat="server" Visible="true" Text = "分析结论：" ></asp:Label>
                <br/>
                 <asp:Label ID="label_XZ1" runat="server" Text="(200字以内)" Visible="true"></asp:Label>
            </td>
            
            <td align="left"colspan="2">
                <asp:TextBox runat="server" ID="TextBox14" Height="81px" Width="90%" MaxLength="200" TextMode="MultiLine"
                onkeyup="this.value = this.value.substring(0, 200)" onafterpaste="this.value = this.value.substring(0, 200)"></asp:TextBox>
            <asp:Label ID="Label17" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td> 
            <tr>
           <td align="center">
           </td>
                <td style="width: 20%" align="right">
                    <asp:Button ID="Button13" runat="server" CssClass="Button02" Height="24px" 
                        OnClick="Button1_ComF" Text="提交" Width="70px" />
                        </td>
                        
                        <td align="center">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button14" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="Button_CancelF"
                    Width="70px" />
                </td>
             
        </tr>
    </table>
     </fieldset>
       </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
     <div id="Panel99">
        <asp:UpdatePanel ID="UpdatePanel_upload" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <fieldset>
                    <legend>上传分析报告</legend>
                    <table style="width: 100%;">
                        <asp:Label ID="Label46" runat="server" Visible="false"></asp:Label>
                        <tr style="height: 16px;">
                            <td align="right" style="width: 25%"></td>
                            <td align="center">
                                <asp:Label ID="Label48" runat="server" Text="上传附件： "></asp:Label>

                                <asp:FileUpload ID="FileUpload1" runat="server" Width="281px" Height="20px" />
                                <asp:Label ID="Label45" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                            <td align="right" style="width: 25%"></td>
                        </tr>
                        <tr style="height: 16px;">
                            <td align="right" align="right">
                                <asp:Button ID="ok_upload" runat="server" Text="提交" Width="70px" CssClass="Button02" OnClick="ok_upload_Click" ValidationGroup="loadvalidation" />
                            </td>
                            <td style="height: 16px;" align="center"></td>
                            <td align="left">
                                <asp:Button ID="cancel_upload" runat="server" Text="关闭" Width="70px" CssClass="Button02" OnClick="cancel_upload_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="ok_upload" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
      </asp:Content>
