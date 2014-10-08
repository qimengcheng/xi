<%@ Page  Language="C#" AutoEventWireup="true" CodeFile="PMPRMProject.aspx.cs" Inherits="ProjectManagement_PMPRMProject" MasterPageFile="~/Other/MasterPage.master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script> 
    <style type="text/css">
        .hidden
        {
            display: none;
        }
    </style>
    <asp:UpdatePanel ID="UpdatePanel_ProjectSearch" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_ProjectSearch" runat="server" Visible="true">
                <fieldset>
                    <legend> 项目查询
                    <asp:Label ID="label_pagestate" runat="server" Visible="False"/>
                    </legend>
    <table style="width: 100%;">
         <asp:Label ID="label_supplytype" runat="server" Visible="False"></asp:Label>
         <asp:Label ID="label_supplytypeid" runat="server" Visible="False"></asp:Label>
             <asp:Label ID="labelcodition" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="label_PName" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="label_PNum" runat="server" Visible="False"></asp:Label>
             <asp:Label ID="label1_BasicID" runat="server" Visible="False"></asp:Label>
              <asp:Label ID="label_XG" runat="server" Visible="False"/>
              <asp:Label ID="label_XF" runat="server" Visible="False"/>
        <tr>
        <td style="width: 15%" align="right">
                <asp:Label ID="Label1" runat="server" Text="产品型号："></asp:Label>
            </td>
            <td style="width: 12%" align="left" colspan="4">
                <asp:TextBox runat="server" ID="TextBox1" Width="578px" Enabled="false" ></asp:TextBox>
            </td>
            
                      <td style="width: 14%" align="center">
                          <asp:Button ID="Button15" runat="server" CssClass="Button02" Height="24px" 
                              OnClick="Button1_Fid" Text="选择..." Width="50px" />
            </td> 
            
            </tr>
            <tr>
            <td style="width: 15%" align="right">
                <asp:Label ID="Label15" runat="server" Text="项目名称："></asp:Label>
            </td>
            <td style="width: 15%" align="left">
                <asp:TextBox runat="server" ID="ProjectName"> </asp:TextBox>
            </td>
            
            <td style="width: 15%" align="right">
                <asp:Label ID="Label5" runat="server" Text="项目编号："></asp:Label>
            </td>
            
            <td style="width: 17%" align="left">
                <asp:TextBox runat="server" ID="ProjectNum"> </asp:TextBox>
            </td> 
            
            <td style="width: 15%" align="right">
                <asp:Label ID="Label9" runat="server" Text="项目状态："></asp:Label>
            </td>
           <td style="width: 14%" align="left">
                <asp:DropDownList ID="DropDownList4" runat="server" >
                     <asp:ListItem>请选择</asp:ListItem>
                    <asp:ListItem>已提交</asp:ListItem>
                    <asp:ListItem>技术副总初审通过</asp:ListItem>
                     <asp:ListItem>技术副总初审驳回</asp:ListItem>
                    <asp:ListItem>材料已提交</asp:ListItem>
                    <asp:ListItem>财务部审核通过</asp:ListItem>
                     <asp:ListItem>财务部审核驳回</asp:ListItem>
                   <asp:ListItem>总经理审核通过</asp:ListItem>
                   <asp:ListItem>总经理审核驳回</asp:ListItem>
                    <asp:ListItem>计划书已提交</asp:ListItem>
                    <asp:ListItem>技术副总审核通过</asp:ListItem>
                     <asp:ListItem>技术副总审核驳回</asp:ListItem>
                   <asp:ListItem>进度设置完成</asp:ListItem>
                   <asp:ListItem>进行中</asp:ListItem>
                   <asp:ListItem>进度延期</asp:ListItem>
                   <asp:ListItem>已完成</asp:ListItem>
                     <asp:ListItem>验收报告已提交</asp:ListItem>
                     <asp:ListItem>责任部门验收审核通过</asp:ListItem>
                     <asp:ListItem>责任部门验收审核驳回</asp:ListItem>
                    <asp:ListItem>验收会签中</asp:ListItem>
                    <asp:ListItem>验收会签通过</asp:ListItem>
                    <asp:ListItem>验收会签驳回</asp:ListItem>
                    <asp:ListItem>技术副总批准通过</asp:ListItem>
                    <asp:ListItem>技术副总驳回批准</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
        <td style="width: 15%" align="right">
                <asp:Label ID="Label" runat="server" Text="项目类型："></asp:Label>
            </td>
            <td style="width: 15%" align="left">
                <asp:DropDownList ID="DropDownList1" runat="server" Width="131px" >
                     <asp:ListItem>请选择</asp:ListItem>
                    <asp:ListItem>工艺改进</asp:ListItem>
                    <asp:ListItem>设备改进</asp:ListItem>
                   <asp:ListItem>新产品开发</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="right">
                <asp:Button ID="Button1" runat="server" Text="检索" CssClass="Button02" Height="24px" OnClick="Button1_Sh"
                    Width="70px" />
               
            </td>
            <td colspan="2" align="center">
               
                <asp:Button ID="Button2" runat="server" Text="新增" CssClass="Button02" Height="24px" OnClick="Button2_Nw"
                    Width="70px" Visble="true" />
            </td>
            <td colspan="2" align="left">
               
                <asp:Button ID="Button3" runat="server" Text="重置" CssClass="Button02" Height="24px" OnClick="Button3_Reset" Visible="true"
                    Width="70px" />
            </td>
            <td style="width: 25%" >
                &nbsp;</td>
        </tr>
    </table>
     </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_ProjectInfo" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <asp:Panel ID="Panel_ProjectInfo" runat="server" Visible="true">
            <fieldset>
                <legend>项目列表</legend>
                <asp:GridView ID="Gridview_ProjectInfo"  runat="server" AutoGenerateColumns="False"
                    CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False" 
                    OnRowCommand="Gridview_ProjectInfo_RowCommand"  
                    AllowPaging="True" AllowSorting="True" DataKeyNames="PRMP_ID"   OnPageIndexChanging="Gridview_ProjectInfo_PageIndexChanging" 
                    Width="100%"  Font-Strikeout="False" GridLines="None"
                    EnableModelValidation="True" ondatabound="Gridview_ProjectInfo_DataBound1" onrowdatabound="Gridview_ProjectInfo_RowDataBound" 
                   >
           
           
             <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
           
           
           
           
                    <Columns>
                        <asp:BoundField DataField="PRMP_ID" HeaderText="项目ID" SortExpression="PRMP_ID" 
                            Visible="False">
                            <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRMP_ProjectNum" HeaderText="项目编号" 
                            SortExpression="PRMP_ProjectNum" />
                        <asp:BoundField DataField="PRMP_ProjectName" HeaderText="项目名称" SortExpression="PRMP_ProjectName">
                         
                        </asp:BoundField>
                        <asp:BoundField DataField="PRMP_ProductMode" HeaderText="产品型号" SortExpression="PRMP_ProductMode">
                        </asp:BoundField>
                         <asp:BoundField DataField="PRMP_ProjectType" HeaderText="项目类型" SortExpression="PRMP_ProjectType">
                        </asp:BoundField>
                        <asp:BoundField DataField="PRMP_Sample" HeaderText="是否有样品" SortExpression="PRMP_Sample">
                        <ItemStyle Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRMP_ImproveAim" HeaderText="改进目的" SortExpression="PRMP_ImproveAim">
                        </asp:BoundField>
                        <asp:BoundField DataField="PRMP_ImproveRequest" HeaderText="改进要求" SortExpression="PRMP_ImproveRequest">
                        </asp:BoundField>
                        <asp:BoundField DataField="PRMP_ProjectStates" HeaderText="项目状态" SortExpression="PRMP_ProjectStates">
                        </asp:BoundField>
                        <asp:TemplateField>
                         <ItemTemplate >
                                <asp:LinkButton ID="bLook1" runat="server" CommandName="Change" 
                                    CommandArgument='<%#Eval("PRMP_ID ")%>'>修改</asp:LinkButton>
                                   
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="btnLook1" runat="server" CommandName="Check1" 
                                    CommandArgument='<%#Eval("PRMP_ID")%>'>技术副总审核</asp:LinkButton>
                                   
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="BnLook2" runat="server" CommandName="CFOCheck" 
                                    CommandArgument='<%#Eval("PRMP_ID")%>'>财务部审核</asp:LinkButton>
                                   
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="btnLook2" runat="server" CommandName="Check2" 
                                    CommandArgument='<%#Eval("PRMP_ID")%>'>总经理审核</asp:LinkButton>
                                   
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="CLook2" runat="server" CommandName="CLook" 
                                    CommandArgument='<%#Eval("PRMP_ID")%>'>查看审核意见</asp:LinkButton>
                                   
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="CDelete" runat="server" CommandName="Delete2" 
                                   OnClientClick="return confirm('您确认删除该记录吗?')"  CommandArgument='<%#Eval("PRMP_ID")%>'>删除</asp:LinkButton>
                                   
                            </ItemTemplate>
                        </asp:TemplateField>

                         <asp:TemplateField>
                        <ItemTemplate >
                        <asp:LinkButton ID="DownL" runat="server" CommandName="DownLL"   CommandArgument='<%#Eval("PRMP_ID")%>' >查看附件</asp:LinkButton>
                         </ItemTemplate>
                        </asp:TemplateField>
                          <asp:TemplateField>
                        <ItemTemplate >
                        <asp:LinkButton ID="DNL" runat="server" CommandName="DNL"   CommandArgument='<%#Eval("PRMP_ID")%>' >上传计划书</asp:LinkButton>
                         </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField>
                        <ItemTemplate >
                        <asp:LinkButton ID="Report" runat="server" CommandName="Report"   CommandArgument='<%#Eval("PRMP_ID")%>' >上传验收报告</asp:LinkButton>
                         </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                        <ItemTemplate >
                        <asp:LinkButton ID="YCheck" runat="server" CommandName="YCheck"   CommandArgument='<%#Eval("PRMP_ID")%>' >验收审核</asp:LinkButton>
                         </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                        <ItemTemplate >
                        <asp:LinkButton ID="YCountersign" runat="server" CommandName="YCountersign"   CommandArgument='<%#Eval("PRMP_ID")%>' >验收会签</asp:LinkButton>
                         </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                        <ItemTemplate >
                        <asp:LinkButton ID="YSelect" runat="server" CommandName="YSelect"   CommandArgument='<%#Eval("PRMP_ID")%>' >选择验收部门</asp:LinkButton>
                         </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                        <ItemTemplate >
                        <asp:LinkButton ID="Design" runat="server" CommandName="Design"   CommandArgument='<%#Eval("PRMP_ID")%>' >项目批准</asp:LinkButton>
                         </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                        <ItemTemplate >
                        <asp:LinkButton ID="Mater" runat="server" CommandName="Mater"   CommandArgument='<%#Eval("PRMP_ID")%>' >上传材料</asp:LinkButton>
                         </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                        <ItemTemplate >
                        <asp:LinkButton ID="CheckAccept" runat="server" CommandName="CheckAccept"   CommandArgument='<%#Eval("PRMP_ID")%>' >查看验收意见</asp:LinkButton>
                         </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField>
                        <ItemTemplate >
                        <asp:LinkButton ID="CheckPlan" runat="server" CommandName="CheckPlan"   CommandArgument='<%#Eval("PRMP_ID")%>' >查看计划书审核意见</asp:LinkButton>
                         </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="PRMP_SupplyDepartment" HeaderText="申请部门" SortExpression="PRMP_SupplyDepartment"  >
                        <FooterStyle CssClass="hidden" />
                                <HeaderStyle CssClass="hidden" />
                                <ItemStyle CssClass="hidden" />
                                </asp:BoundField>
                         <asp:BoundField DataField="PRMP_ResponDepart" HeaderText="责任部门" SortExpression="PRMP_ResponDepart"  >
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
 
      <asp:UpdatePanel ID="UpdatePanel_NewProjectInfo" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_NewProjectInfo" runat="server" Visible="False">
                <fieldset>
                    <legend> 
                     <asp:Label ID="label_Change" runat="server" Visible="true"></asp:Label>
                    </legend>
                    <asp:Label ID="label_RTX" runat="server" Visible="false"></asp:Label>
                  
                     <table style="width: 100%">
    <tr>
         <td style="width: 10%" align="center">
                <asp:Label ID="Label3" runat="server" Text="产品型号："></asp:Label>
            </td>
            
               <td align="left" colspan="5">
                <asp:TextBox runat="server" ID="TextBox3"  Enabled="false" Width="550px" 
                       Height="43px"></asp:TextBox>
          <asp:Label ID="Label24" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td   style="width: 19%" align="left">
                <asp:Button ID="Button12" runat="server" Text="选择..." CssClass="Button02" Height="24px" OnClick="Button1_Find"
                    Width="50px" />
            </td>
   
    
           
             
                </tr>
               <tr>
                    <td align="center" style="width: 10%">
                        <asp:Label ID="Label13" runat="server" Text="项目名称："></asp:Label>
                    </td>
                    <td align="left" style="width: 19%">
                        <asp:TextBox ID="TextBox2" runat="server" Enabled="True" Height="22px"></asp:TextBox>
                   <asp:Label ID="Label27" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </td>
                <td style="width: 10%" align="center" >
                <asp:Label ID="Label2" runat="server" Text="是否有样品："></asp:Label>
            </td>
            <td style="width: 19%" align="left" >
                 <asp:DropDownList ID="DropDownList2" runat="server"   Width="121px" 
                     Height="22px">
                     <asp:ListItem>请选择</asp:ListItem>
                     <asp:ListItem>是</asp:ListItem>
                     <asp:ListItem>否</asp:ListItem>
                 </asp:DropDownList>
                 <asp:Label ID="Label26" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                 <td style="width: 10%" align="center">
                <asp:Label ID="Label11" runat="server" Text="项目类型："></asp:Label>
            </td>
            <td style="width: 19%" align="left">
        <asp:DropDownList ID="DropDownList3" runat="server" Width="121px" Height="22px">
                <asp:ListItem>请选择</asp:ListItem>
                <asp:ListItem>新产品开发</asp:ListItem>
                <asp:ListItem>工艺改进</asp:ListItem>
                <asp:ListItem>设备改进</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="Label25" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            <td  align="left" colspan="1">
                <asp:Button ID="Button27" runat="server" Text="上传附件" CssClass="Button02" Height="24px" OnClick="Button_Aline"
                    Width="90px" />
            </td>
              </tr>
              <tr>
                    <td align="center" >
                        <asp:Label ID="Label4" runat="server" Text="改进目的："></asp:Label>
                        <br/>
                         <asp:Label ID="Label16" runat="server" Text="(200字以内)"></asp:Label>
                    </td>
                    <td align="left"  colspan="7">
                        <asp:TextBox ID="TextBox4" runat="server" Enabled="True" Height="98px"  
                            MaxLength="200" TextMode="MultiLine"   
                         onkeyup="this.value = this.value.substring(0, 200)" onafterpaste="this.value = this.value.substring(0, 200)"
                           width="93%" ></asp:TextBox>
                           <asp:Label ID="Label28" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td align="center"  >
                        <asp:Label ID="Label6" runat="server" Text="改进要求："></asp:Label>
                         <br/>
                         <asp:Label ID="Label17" runat="server" Text="(200字以内)"></asp:Label>
                    </td>
                    <td align="left"  colspan="7">
                        <asp:TextBox ID="TextBox5" runat="server" Enabled="True" Height="98px" 
                            width="93%"  MaxLength="200" TextMode="MultiLine"   
                         onkeyup="this.value = this.value.substring(0, 200)" onafterpaste="this.value = this.value.substring(0, 200)"
                            ></asp:TextBox>
                            <asp:Label ID="Label29" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                 <td align="center" colspan="1">
                 </td>
                    <td align="center" colspan="2">
                        <asp:Button ID="Button6" runat="server" CssClass="Button02" Height="24px" 
                            OnClick="ConfirmProject " Text="提交" Width="70px" /></td>
                      <td align="center" colspan="3">   
                      <asp:Button ID="Button7" runat="server" CssClass="Button02" Height="24px" 
                            OnClick="CanelProject" Text="关闭" Width="70px" />
</td>
<td align="center" colspan="2">
                 </td>
                </tr>
                </tr>
    </table>
     </fieldset>
     </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>   
     <asp:UpdatePanel ID="UpdatePanel_ProductMode" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <asp:Panel ID="Panel_ProductMode" runat="server" Visible="false">
            <fieldset>
                <legend>
                产品型号查询
                </legend>
                 <table style="width: 100%;">
       
        <tr>
       
        <td colspan="3" align="right">
                <asp:Label ID="Label47" runat="server" Text="产品型号："></asp:Label>
            </td>
            <td colspan="1" align="left">
                <asp:TextBox ID="TextBox16" runat="server"> </asp:TextBox>
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
                <asp:GridView ID="Gridview_ProductMode"  runat="server" AutoGenerateColumns="False"
                    CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"
                     PageSize="10" 
                    AllowPaging="True" AllowSorting="True" DataKeyNames="PT_Name"   OnPageIndexChanging="Gridview_ProductMode_PageIndexChanging" 
                    Width="100%"  Font-Strikeout="False" GridLines="None"
                    EnableModelValidation="True" 
                    >
                    <%--    //隔行变色--%>
           
           
             
           
           
           
           
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
           
           
                    <Columns>
                   <asp:TemplateField >
                            <ItemTemplate >
                                <asp:CheckBox ID="RadioButtonMarkup" runat="server"></asp:CheckBox>
                               
  
                            </ItemTemplate>
                            <ItemStyle/>
                        </asp:TemplateField>
                        
                        <asp:BoundField DataField="PT_ID" HeaderText="产品型号ID" SortExpression="PT_ID" 
                            Visible="False" />
                        
                        <asp:BoundField DataField="PT_Name" HeaderText="产品型号" 
                            SortExpression="PT_Name">
                        <ItemStyle  />
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
               
                <table width="100%">
                <tr>
                <td width="40%" align="right" >
                    
                <asp:Button ID="Button13" runat="server" Text="提交" CssClass="Button02" Height="24px" OnClick="Button_Product"
                    Width="70px" />
            </td>
           <td style="width: 20%" align="center">
                &nbsp;</td>
                    
                   
             <td width="30%" align="left">
               
                <asp:Button ID="Button14" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="Button_CancelProduct"
                    Width="70px" />
            </td>
            <td style="width: 100%" >
                </td>
                <td style="width: 100%" >
                </td>
                </tr>
                </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br/>

 <div id="Div1" >
     <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
       
        <ContentTemplate>
             
                <fieldset>
                    <legend> 附件上传</legend>
                     <asp:Label ID="label_AccNum" runat="server"  Visible="false"></asp:Label>
                     <asp:Label ID="label_AccName" runat="server"  Visible="false"></asp:Label>
                      <asp:Label ID="label_Coutersign" runat="server"  Visible="false"></asp:Label>
                      <asp:Label ID="Label_FilePath" runat="server"  Visible="false"></asp:Label>
                      <asp:Label ID="LabelQ_SaveDirectory" runat="server"  Visible="false"></asp:Label>
    <table style="width: 100%;">
    <tr style="height: 16px;">
    <td style="width: 16%" align="right">
                <asp:Label ID="Label51" runat="server" Text="附件编号："></asp:Label>
            </td>
             <td style="width: 20%" align="left">
                <asp:TextBox runat="server" ID="TextBox18" Enabled ="true" > </asp:TextBox>
                <asp:Label ID="Label52" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            
             <td align="right" style="width: 10%">
                <asp:Label ID="Label53" runat="server" Text="附件名称："></asp:Label>
            </td>
             <td style="width: 20%" align="left">
                <asp:TextBox runat="server" ID="TextBox19" Enabled ="true" > </asp:TextBox>
                <asp:Label ID="Label54" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
    <td style="width: 8%" align="right">
                <asp:Label ID="Label55" runat="server" Text="上传文件："></asp:Label>
               
                </td>
                 <td style="width: 17%" align="left">
                     <asp:FileUpload ID="FileUpload1" runat="server" Width="140px" />
                   <asp:Label ID="Label56" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            
            </tr>
            <tr>
            <td  align="center" colspan="1">
            </td>
             <td  align="center" colspan="2">
                <asp:Button ID="Button28" runat="server" Text="提交" CssClass="Button02" Height="24px" OnClick="Button1_Fox"
                    Width="90px" />
            </td>
             <td  align="center" colspan="2">
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
               <asp:Label ID="label_AccID" runat="server" Visible="false"></asp:Label>
     <asp:GridView ID="Gridview2"  runat="server" AutoGenerateColumns="False"
                    CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"
                    Font-Strikeout="False" GridLines="None" PageSize="5" 
                    OnRowCommand="Gridview2_RowCommand"  
                    AllowPaging="True" AllowSorting="True" DataKeyNames="PRMPA_ID"   OnPageIndexChanging="Gridview2_PageIndexChanging" 
                    Width="100%"  >
                    <%--    //隔行变色--%>
           
           
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
           
           
                    <PagerStyle CssClass="GridViewPagerStyle" />
           
           
              <AlternatingRowStyle />
           
           
                    <Columns>
                        <asp:BoundField DataField="PRMPA_ID" HeaderText="附件ID" 
                            SortExpression="PRMPA_ID" Visible="False">
                          
                        </asp:BoundField>
                       
                        <asp:BoundField DataField="PRMPA_AccName" HeaderText="附件名称" 
                            SortExpression="PRMPA_AccName" />
                       
                        <asp:BoundField DataField="PRMPA_AccNum" HeaderText="附件编号" 
                            SortExpression="PRMPA_AccNum">
                        </asp:BoundField>
                        <asp:BoundField DataField="PRMPA_AccState" HeaderText="附件类型" 
                            SortExpression="PRMPA_AccState" />
                        <asp:BoundField DataField="PRMPA_AccPath" HeaderText="认证结果" 
                            SortExpression="PRMPA_AccPath" Visible="false"/>
                       <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="btnLook3" runat="server" CommandName="Edit1" 
                                    CommandArgument='<%#Eval("PRMPA_ID")%>'>编辑</asp:LinkButton>
                                   
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="btnLook4" runat="server" CommandName="Cancel1" OnClientClick="return confirm('您确认删除该记录吗?')" 
                                    CommandArgument='<%#Eval("PRMPA_ID")+","+Eval("PRMPA_AccPath")%>'>删除</asp:LinkButton>
                                   
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                        <ItemTemplate >
                        <asp:HyperLink ID="Down" runat="server"   CommandArgument='<%#Eval("PRMPA_AccPath")%>'  NavigateUrl='<%#"~/"+Eval("PRMPA_AccPath")+"?path={0}"%>'>查看附件</asp:HyperLink>
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
               
                    <td style="width: 20%" align="center">
                   
                    &nbsp;</td>
                   
           <td width="30%" align="left">
               <asp:Button ID="Button18" runat="server" CssClass="Button02" Height="24px" 
                    OnClick="Button2_Cancel1" Text="关闭" Width="70px" />     
            </td>
            </tr>
              </table>  
            </fieldset>
            
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
      <asp:UpdatePanel ID="UpdatePanel1_Check" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1_Check" runat="server" Visible="False">
                <fieldset>
                    <legend> 
                    <asp:Label ID="label_DMCheck" runat="server" Visible="true"></asp:Label>
                    </legend>
                     <asp:Label ID="label_Design" runat="server" Visible="false"></asp:Label>
    <table style="width: 100%;">
   
                    <tr>
                        <td align="center" style="width: 7%">
                            <asp:Label ID="Label7" runat="server" Text="技术副总审核"></asp:Label>
                        </td>
                        <td align="left" style="width: 15%">
                            <asp:Label ID="label_PRMP_DesignMangCheckResult" runat="server" Visible="False"></asp:Label>
                        </td>
                        <td align="right" style="width: 13%">
                            <asp:Label ID="Label10" runat="server" Text="审核人：" Visible="false"></asp:Label>
                        </td>
                        <td align="left" style="width: 15%">
                            <asp:Label ID="label_PRMP_DesignMangName" runat="server" Visible="False"></asp:Label>
                        </td>
                        <td align="center" style="width: 15%">
                            <asp:Label ID="label1_PanelSupply" runat="server" Visible="False"></asp:Label>
                        </td>
                        
        </tr>
        <tr>
            <td align="center" style="width: 7%" >
                <asp:Label ID="Label12" runat="server" Text="审核意见："></asp:Label>
               
                <asp:Label ID="Label18" runat="server" Text="（200字以内）">
                 </asp:Label>
            </td>
            <td align="left" colspan="4" >
                <asp:TextBox ID="TextBox8" runat="server" Enabled="True" Height="58px" MaxLength="200" TextMode="MultiLine"   
                 onkeyup="this.value = this.value.substring(0, 200)" onafterpaste="this.value = this.value.substring(0, 200)"
                    Width="90%"></asp:TextBox>
                   <asp:Label ID="Label30" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            
        </tr>
        <tr>
            <td align="center" style="width: 7%" >
            </td>
            <td align="center">
                <asp:Button ID="Button8" runat="server" CssClass="Button02" Height="24px" 
                    OnClick="DesignMangPass " Text="通过" Width="70px" />
            </td>
            <td align="center" colspan="2">
                <asp:Button ID="Button10" runat="server" CssClass="Button02" Height="24px" 
                    OnClick="DesignMangReject " Text="驳回" Width="70px" />
            </td>
            <td align="center">
                <asp:Button ID="Button9" runat="server" CssClass="Button02" Height="24px" 
                    OnClick="DesignMangCanel" Text="关闭" Width="70px" />
            </td>
            
        </tr>

        <tr>
                        <td align="center" style="width: 7%">
                            <asp:Label ID="Label32" runat="server" Text="财务部审核"></asp:Label>
                        </td>
                        <td align="left" style="width: 15%">
                            <asp:Label ID="label33" runat="server" Visible="False"></asp:Label>
                        </td>
                        <td align="right" style="width: 13%">
                            <asp:Label ID="Label34" runat="server" Text="审核人：" Visible="false"></asp:Label>
                        </td>
                        <td align="left" style="width: 15%">
                            <asp:Label ID="label35" runat="server" Visible="False"></asp:Label>
                        </td>
                        <td align="center" style="width: 15%">
                            <asp:Label ID="label36" runat="server" Visible="False"></asp:Label>
                        </td>
                        
        </tr>
        <tr>
            <td align="center" style="width: 7%" >
                <asp:Label ID="Label37" runat="server" Text="审核意见："></asp:Label>
               
                <asp:Label ID="Label38" runat="server" Text="（200字以内）">
                 </asp:Label>
            </td>
            <td align="left" colspan="4" >
                <asp:TextBox ID="TextBox6" runat="server" Enabled="True" Height="58px" MaxLength="200" TextMode="MultiLine"   
                 onkeyup="this.value = this.value.substring(0, 200)" onafterpaste="this.value = this.value.substring(0, 200)"
                    Width="90%"></asp:TextBox>
                   <asp:Label ID="Label39" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            
        </tr>
        <tr>
            <td align="center" style="width: 7%" >
            </td>
            <td align="center">
                <asp:Button ID="Button17" runat="server" CssClass="Button02" Height="24px" 
                    OnClick="CFOPass " Text="通过" Width="70px" />
            </td>
            <td align="center" colspan="2">
                <asp:Button ID="Button19" runat="server" CssClass="Button02" Height="24px" 
                    OnClick="CFOReject " Text="驳回" Width="70px" />
            </td>
            <td align="center">
                <asp:Button ID="Button20" runat="server" CssClass="Button02" Height="24px" 
                    OnClick="CFOCanel" Text="关闭" Width="70px" />
            </td>
            
        </tr>
        <tr>
            <td align="center" style="width: 7%" >
                <asp:Label ID="Label8" runat="server" Text="总经理审核"></asp:Label>
            </td>
            <td align="left" >
                            <asp:Label ID="label20" runat="server" Visible="False"></asp:Label>
                        </td>
                         <td align="right" >
                            <asp:Label ID="Label21" runat="server" Text="审核人：" Visible="false"></asp:Label>
                        </td>
                        <td align="left" >
                            <asp:Label ID="label22" runat="server" Visible="False"></asp:Label>
                        </td>
                        <td align="center" >
                            <asp:Label ID="label23" runat="server" Visible="False"></asp:Label>
                        </td>
        </tr>
        <tr>
            <td align="center" style="width: 7%" >
                <asp:Label ID="Label14" runat="server" Text="审核意见："></asp:Label>
                 
                <asp:Label ID="Label19" runat="server" Text="（200字以内）">
                 </asp:Label>
            </td>
            <td align="left" colspan="4" >
                <asp:TextBox ID="TextBox9" runat="server" Enabled="True" Height="58px" MaxLength="200"  TextMode="MultiLine"   
                 onkeyup="this.value = this.value.substring(0, 200)" onafterpaste="this.value = this.value.substring(0, 200)"
                    Width="90%"></asp:TextBox>
                    <asp:Label ID="Label31" runat="server" Text="*" ForeColor="Red"></asp:Label>
                   
            </td>
        </tr>
        <tr>
            <td align="center" style="width: 7%" >
            </td>
            <td align="center" >
                <asp:Button ID="Button4" runat="server" CssClass="Button02" Height="24px" 
                    OnClick="GeneralMangPass " Text="通过" Width="70px" />
                <td align="center" colspan="2">
                    <asp:Button ID="Button5" runat="server" CssClass="Button02" Height="24px" 
                        OnClick="GeneralMangReject " Text="驳回" Width="70px" />
                </td>
                <td align="center">
                    <asp:Button ID="Button11" runat="server" CssClass="Button02" Height="24px" 
                        OnClick="GeneralMangCanel" Text="关闭" Width="70px" />
                </td>
                
            </td>
        </tr>
        <tr>
         <td align="center" colspan="5">
                <asp:Button ID="Button16" runat="server" CssClass="Button02" Height="24px" 
                    OnClick="Close " Text="关闭" Width="70px" Visible="False"/>
    </tr>
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
    <asp:UpdatePanel ID="UpdatePanel_Sign" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <asp:Panel ID="Panel_Sign" runat="server" Visible="false">
            <fieldset>
                <legend>项目验收会签表</legend>
                <asp:GridView ID="Gridview4"  runat="server" AutoGenerateColumns="False"
                    CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"
                    Font-Strikeout="False" GridLines="None" PageSize="5" 
                    OnRowCommand="Gridview4_RowCommand"  
                    AllowPaging="True" AllowSorting="True" 
                    DataKeyNames="PRMPC_ID"   OnPageIndexChanging="Gridview_4_PageIndexChanging" 
                    Width="100%" 
                    EnableModelValidation="True"  ondatabound="Gridview4_DataBound" OnRowDataBound="Gridview4_RowDataBound" 
                     >
                    <%--    //隔行变色--%>
           
           
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
           
           
                    <PagerStyle CssClass="GridViewPagerStyle" />
  
           
              <AlternatingRowStyle />
           
           
                    <Columns>
                        <asp:BoundField DataField="PRMPC_ID" HeaderText="会签ID" SortExpression="PRMPC_ID" 
                            Visible="False">
                        </asp:BoundField>
                       
                        <asp:BoundField DataField="PRMPC_SignPartment" HeaderText="会签部门" 
                            SortExpression="PRMPC_SignPartment" >
                             
                            </asp:BoundField>
                        <asp:BoundField DataField="PRMPC_SignResult" HeaderText="会签结果" 
                            SortExpression="PRMPC_SignResult">
                          
                        </asp:BoundField>
                        <asp:BoundField DataField="PRMPC_SignOpinion" HeaderText="会签意见" 
                            SortExpression="PRMPC_SignOpinion">
                         
                        </asp:BoundField>
                         <asp:BoundField DataField="PRMPC_SignMan" HeaderText="会签人" 
                            SortExpression="PRMPC_SignMan">
                            
                        </asp:BoundField>
                        <asp:BoundField DataField="PRMPC_SignTime" HeaderText="会签时间" 
                            SortExpression="PRMPC_SignTime">
                            
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
                                    CommandArgument='<%#Eval("PRMPC_ID")%>'>查看</asp:LinkButton>
                                   
                            </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="Myllo" runat="server" CommandName="Mylloo" 
                                    CommandArgument='<%#Eval("PRMPC_ID")%>'>会签</asp:LinkButton>
                                   
                            </ItemTemplate>
                            </asp:TemplateField>
                         <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="Miko" runat="server" CommandName="Miko" OnClientClick="return confirm('您确认删除该记录吗?')" 
                                    CommandArgument='<%#Eval("PRMPC_ID")%>'>删除</asp:LinkButton>
                                   
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
         <asp:Panel ID="Panel1" runat="server" Visible="false" Enabled ="true" >
                <fieldset>
                    <legend>  <asp:Label ID="label46" runat="server" Visible="true"></asp:Label></legend>
    
    <table style="width: 100%;">
       
        <tr>
            <td align="right" style="width: 15%; height: 20px;">
                &nbsp;</td>
            <td align="left" style="width: 12%; height: 20px;">
                <asp:Label ID="label49" runat="server" Visible="false"></asp:Label>
            </td>
            <td align="right" style="width: 15%; height: 20px;">
                <asp:Label ID="Label57" runat="server" Text="审核人：" Visible="false"></asp:Label>
            </td>
            <td align="left" style="width: 15%; height: 20px;">
                <asp:Label ID="label58" runat="server" Visible="false"></asp:Label>
            </td>
            <td align="right" style="width: 15%; height: 20px;">
                &nbsp;</td>
            <td align="left" style="width: 15%; height: 20px;">
                <asp:Label ID="label59" runat="server" Visible="false"></asp:Label>
            </td>
            <td align="right" style="width: 15%; height: 20px;">
                &nbsp;</td>
            <td align="right" style="width: 15%; height: 20px;">
                &nbsp;</td>
            <tr>
             <td style="width: 15%" align="center">
                <asp:Label ID="label61" runat="server"  Visible="true" Text="审核意见："></asp:Label>
                <br/>
                <asp:Label ID="label62" runat="server" text="(200字以内)" Visible="true"></asp:Label>
            </td>
            
            <td style="width: 17%" align="left"colspan="7" >
                <asp:TextBox runat="server" ID="TextBox7" Height="81px" Width="90%" Visible="true" Enabled ="true" MaxLength="200" TextMode="MultiLine"
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
        
    </table>
     </fieldset>
       </asp:Panel>
       <asp:Panel ID="Panel4" runat="server" Visible="false" Enabled ="true" >
                <fieldset>
                    <legend>  <asp:Label ID="label40" runat="server" Visible="true"></asp:Label></legend>
    <asp:Label ID="label_RTX1" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="labelCheckState" runat="server" Visible="false"></asp:Label>
    <table style="width: 100%;">
       
        <tr>
            <td align="right" style="width: 15%; height: 20px;">
                &nbsp;</td>
            <td align="left" style="width: 12%; height: 20px;">
                <asp:Label ID="label41" runat="server" Visible="false"></asp:Label>
            </td>
            <td align="right" style="width: 15%; height: 20px;">
                <asp:Label ID="Label42" runat="server" Text="会签人：" Visible="false"></asp:Label>
            </td>
            <td align="left" style="width: 15%; height: 20px;">
                <asp:Label ID="label43" runat="server" Visible="false"></asp:Label>
            </td>
            <td align="right" style="width: 15%; height: 20px;">
                &nbsp;</td>
            <td align="left" style="width: 15%; height: 20px;">
                <asp:Label ID="label44" runat="server" Visible="false"></asp:Label>
            </td>
            <td align="right" style="width: 15%; height: 20px;">
                &nbsp;</td>
            <td align="right" style="width: 15%; height: 20px;">
                &nbsp;</td>
            <tr>
             <td style="width: 15%" align="center">
                <asp:Label ID="label45" runat="server"  Visible="true" Text="会签意见："></asp:Label>
                <br/>
                <asp:Label ID="labelXZ3" runat="server" text="(200字以内)" Visible="true"></asp:Label>
            </td>
            
            <td style="width: 17%" align="left"colspan="7" >
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
    </table>
     </fieldset>
       </asp:Panel>
     <asp:Panel ID="Panel2" runat="server" Visible="false" Enabled ="true" >
               
    <table style="width: 100%;">
     <tr>
            <td  style="width: 15%">
                        &nbsp;</td>
                         
                <td style="width: 15%" align="center" colspan="2">
                    <asp:Button ID="Button22" runat="server" CssClass="Button02" Height="24px" Enabled="true"
                        OnClick="ButtonPass" Text="通过" Width="70px" />
                        </td>
                        <td  style="width: 15%" align="center">
                        
                    <asp:Button ID="Button23" runat="server" CssClass="Button02" Height="24px" Enabled="true"
                        OnClick="ButtonUnpass" Text="驳回" Width="70px" /></td>
                        <td style="width: 15%" align="center" colspan="2">
                        <asp:Button ID="Button24" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="ButtonClose"
                    Width="70px" />
                        </td>
                        <td  style="width: 15%">
                        &nbsp;</td>
                </tr>
                <tr>
                <td style="width: 15%" align="center" colspan="8">
                        <asp:Button ID="Button30" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="Button_CClose"
                    Width="70px" />
                        </td>
                </tr>
    </table>
    
       </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

    </asp:Content>
