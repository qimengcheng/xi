<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PMPPRMProjectSchedule.aspx.cs" Inherits="ProjectManagement_PMPPRMProjectSchedule" MasterPageFile="~/Other/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script> 
    <asp:UpdatePanel ID="UpdatePanel_ProjectSearch" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_ProjectSearch" runat="server" Visible="true">
                <fieldset>
                    <legend> 项目查询
                    <asp:Label ID="label_pagestate" runat="server" Visible="False"/>
                    </legend>
                    <asp:Label ID="label_RTX" runat="server" Visible="False"/>
    <table style="width: 100%;">
         <asp:Label ID="label_supplytype" runat="server" Visible="False"></asp:Label>
         <asp:Label ID="label_supplytypeid" runat="server" Visible="False"></asp:Label>
             <asp:Label ID="labelcodition" runat="server" Visible="False"></asp:Label>
             <asp:Label ID="label1_PanelSupply" runat="server" Visible="False"></asp:Label>
             <asp:Label ID="label1_BasicID" runat="server" Visible="False"></asp:Label>
              <asp:Label ID="label_PNum" runat="server" Visible="False"></asp:Label>
               <asp:Label ID="label_PName" runat="server" Visible="False"></asp:Label>
        <tr>
        <td style="width: 15%" align="right">
                <asp:Label ID="Label15" runat="server" Text="项目名称："></asp:Label>
            </td>
            <td style="width: 12%" align="left">
                <asp:TextBox ID="ProjectName" runat="server"> </asp:TextBox>
            </td>
            <td style="width: 15%" align="right">
                <asp:Label ID="Label" runat="server" Text="项目类型："></asp:Label>
            </td>
            <td style="width: 15%" align="left">
                <asp:DropDownList ID="DropDownList1" runat="server"  Width="121px">
                     <asp:ListItem>请选择</asp:ListItem>
                    <asp:ListItem>工艺改进</asp:ListItem>
                    <asp:ListItem>设备改进</asp:ListItem>
                   <asp:ListItem>新产品开发</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="width: 15%" align="right">
                <asp:Label ID="Label9" runat="server" Text="项目状态："></asp:Label>
            </td>
            <td style="width: 17%" align="left">
                <asp:DropDownList ID="DropDownList4" runat="server" Width="121px">
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
                <asp:Label ID="Label5" runat="server" Text="项目编号："></asp:Label>
            </td>
            
            <td style="width: 17%" align="left">
                <asp:TextBox runat="server" ID="ProjectNum" > </asp:TextBox>
            </td> <td style="width: 15%" align="center">
                    &nbsp;</td>
           <td style="width: 15%" align="left">
                &nbsp;</td>
                  <td style="width: 15%" align="left">
                &nbsp;</td>
                  <td style="width: 15%" align="left">
                &nbsp;</td>
        </tr>
        
        <tr>
        <td style="width: 15%" align="left">
                &nbsp;</td>
            <td colspan="2" align="center">
                <asp:Button ID="Button1" runat="server" Text="检索" CssClass="Button02" Height="24px" OnClick="Button1_Sh"
                    Width="70px" />
            </td>
          
            <td colspan="2" align="center">
                
                <asp:Button ID="Button3" runat="server" Text="重置" CssClass="Button02" Height="24px" OnClick="Button3_Reset" Visible="true"
                    Width="70px" />
            </td>
            <td style="width: 15%" align="left">
                &nbsp;</td>
        </tr>
    </table>
     </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
  
        <asp:UpdatePanel ID="UpdatePanel2_Project" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <asp:Panel ID="Panel2_Project" runat="server" Visible="true">
            <fieldset>
                <legend>项目列表</legend>
                <asp:GridView ID="Gridview2"  runat="server" AutoGenerateColumns="False"
                    CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"
                    PageSize="10" 
                    OnRowCommand="Gridview_Project_RowCommand"  
                    AllowPaging="True" AllowSorting="True" DataKeyNames="PRMP_ID"   OnPageIndexChanging="Gridview_Project_PageIndexChanging" 
                    Width="100%"  Font-Strikeout="False" GridLines="None"
                    EnableModelValidation="True" onrowdatabound="Gridview2_RowDataBound" ondatabound="Gridview2_DataBound1"  
                     >
                    <%--    //隔行变色--%>

           
            
           
           
                    <Columns>
                        <asp:BoundField DataField="PRMP_ID" HeaderText="项目ID " SortExpression="PRMP_ID" 
                            Visible="False">
                            <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRMP_ProjectNum" HeaderText="项目编号" 
                            SortExpression="PRMP_ProjectNum" >
                            </asp:BoundField>
                        <asp:BoundField DataField="PRMP_ProjectName" HeaderText="项目名称" SortExpression="PRMP_ProjectName">
                    
                        </asp:BoundField>
                        <asp:BoundField DataField="PRMP_ProductMode" HeaderText="产品型号" SortExpression="PRMP_ProductMode">
                        </asp:BoundField>
                         <asp:BoundField DataField="PRMP_ProjectType" HeaderText="项目类型" SortExpression="PRMP_ProjectType">
                        </asp:BoundField>
                        <asp:BoundField DataField="PRMP_Sample" HeaderText="是否有样品" SortExpression="PRMP_Sample">
                            <ItemStyle  Width="50px"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="PRMP_ImproveAim" HeaderText="改进目的" SortExpression="PRMP_ImproveAim">
                        </asp:BoundField>
                        <asp:BoundField DataField="PRMP_ImproveRequest" HeaderText="改进要求" SortExpression="PRMP_ImproveRequest">
                        </asp:BoundField>
                        <asp:BoundField DataField="PRMP_ProjectStates" HeaderText="项目状态" SortExpression="PRMP_ProjectStates">
                        </asp:BoundField>
                        <asp:BoundField DataField="PRMP_ResponDepart" HeaderText="责任部门" 
                            SortExpression="PRMP_ResponDepart" Visible="True">
                        </asp:BoundField>
                        <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="btnLook1" runat="server" CommandName="Check1" 
                                    CommandArgument='<%#Eval("PRMP_ID")%>'>安排部门</asp:LinkButton>
                                 
                            </ItemTemplate>
                            
                        </asp:TemplateField>
                         <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="btnLook2" runat="server" CommandName="Check2" 
                                    CommandArgument='<%#Eval("PRMP_ID")%>'>设置进度</asp:LinkButton>
                                   
                            </ItemTemplate>
                            
                        </asp:TemplateField>
                       <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="btnLk1" runat="server" CommandName="Look1" 
                                    CommandArgument='<%#Eval("PRMP_ID")%>'>查看进度</asp:LinkButton>
                                 
                            </ItemTemplate>
                             
                        </asp:TemplateField>
                    </Columns>
               <EmptyDataTemplate>
              <asp:Label ID="Label50" runat="server" Text="无相关记录！"></asp:Label>
             </EmptyDataTemplate>
                    <FooterStyle CssClass="GridViewFooterStyle" />
                    <HeaderStyle CssClass="GridviewHead"
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
              <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                    <RowStyle CssClass="GridViewRowStyle" />
                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                </asp:GridView>
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
                        <td colspan="3" align="left">
                    <asp:Button ID="Button32" runat="server" Text="重置" CssClass="Button02" Height="24px" OnClick="Button_CoMl"
                    Width="80px" />
                </td>
              
                </tr>
       
    </table>

                <asp:GridView ID="Gridview_Organization"  runat="server" AutoGenerateColumns="False"
                    CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"
                    Font-Strikeout="False" GridLines="None" PageSize="5" 
                    AllowPaging="True" AllowSorting="True" DataKeyNames="BDOS_Name "   OnPageIndexChanging="Gridview_Partment_PageIndexChanging" 
                    Width="100%"  EnableModelValidation="True" 
                    onrowdatabound="Gridview_Organization_RowDataBound">
                    <%--    //隔行变色--%>
    <%--<PagerStyle  ForeColor="Black" 
                 HorizontalAlign="Center" CssClass="GridViewPagerStyle" />--%>
           
                    <Columns>
                   <asp:TemplateField >
                            <ItemTemplate >
                                <asp:RadioButton ID="RadioButtonMarkup" runat="server" GroupName="GN"></asp:RadioButton>
                               
  
                            </ItemTemplate>
                            <ItemStyle  />
                        </asp:TemplateField>
                        
                        <asp:BoundField DataField="BDOS_Name" HeaderText="部门名称" 
                            SortExpression="BDOS_Name">
                        <ItemStyle />
                        </asp:BoundField>
                       
                    </Columns>
               <EmptyDataTemplate>
              <asp:Label ID="Label50" runat="server" Text="无相关记录！"></asp:Label>
             </EmptyDataTemplate>
                 <FooterStyle CssClass="GridViewFooterStyle" />
                    <HeaderStyle CssClass="GridviewHead"
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
             <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                    <RowStyle CssClass="GridViewRowStyle" />
                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                </asp:GridView>
               
                <table width="100%">
                <tr>
                <td width="40%" align="right" >
                    
                <asp:Button ID="Button2" runat="server" Text="提交" CssClass="Button02" Height="24px" OnClick="Button1_Com"
                    Width="70px" />
            </td>
           <td style="width: 20%" align="center">
                &nbsp;</td>
                    
                   
             <td width="30%" align="center">
               
                <asp:Button ID="Button4" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="Button1_Cancel"
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
   
     <asp:UpdatePanel ID="UpdatePanel_ProjectSchedule" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_ProjectSchedule" runat="server" Visible="false">
                <fieldset>
                    <legend>
                    <asp:Label ID="label_Setting" runat="server" Visible="true"></asp:Label>
                    </legend>
    <table style="width: 100%;">
       
        <tr>
        <td style="width: 15%; height: 20px;" align="right">
                <asp:Label ID="Label7" runat="server" Text="进度名称："></asp:Label>
            </td>
            <td style="width: 17%; height: 20px;" align="left">
                <asp:TextBox ID="TextBox1" runat="server" Width="118px"></asp:TextBox>
                <asp:Label ID="Label14" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            
           <td style="width: 15%; height: 20px;" align="right">
                <asp:Label ID="Label10" runat="server" Text="进度时间："></asp:Label>
                </td>
            <td style="width: 20%; height: 20px;" align="left">
                <asp:TextBox ID="TextBox3" runat="server"
                onkeyup="this.value=this.value.replace(/[^0-9]/g,'')"
                                    onafterpaste="this.value=this.value.replace(/[^0-9]/g,'')"> </asp:TextBox>
                                    <asp:Label ID="Label4" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    <asp:Label ID="Label1" runat="server" Text="天"></asp:Label>
            </td>
           
            <td style="width: 15%; height: 20px;" align="right">
            <asp:Label ID="Label2" runat="server" Text="进度序号："></asp:Label>
            </td>
               <td style="width: 17%; height: 20px;" align="left">
                <asp:TextBox ID="TextBox4" runat="server"
                onkeyup="this.value=this.value.replace(/[^0-9]/g,'')"
                                    onafterpaste="this.value=this.value.replace(/[^0-9]/g,'')" 
                       Width="115px"></asp:TextBox>
                                    <asp:Label ID="Label6" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td> 
            </tr>
            <tr>
            <td style="width: 15%" align="right">
                <asp:Label ID="Label11" runat="server" Text="进度内容："></asp:Label>
                <br/>
                <asp:Label ID="Label3" runat="server" Text="(200字以内)"></asp:Label>
            </td>
            
            <td style="width: 22%" align="left"colspan="7">
                <asp:TextBox runat="server" ID="TextBox2" Height="81px" Width="96%" 
                    MaxLength="200" TextMode="MultiLine"   
                 onkeyup="this.value = this.value.substring(0, 200)" onafterpaste="this.value = this.value.substring(0, 200)"
                ></asp:TextBox>
                <asp:Label ID="Label8" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td> 
            </tr>
            <tr>
            <td style="width: 15%" align="center">
                    
                    &nbsp;</td>
                <td style="width: 15%" align="center" colspan="3">
                    <asp:Button ID="Button5" runat="server" CssClass="Button02" Height="24px" 
                        OnClick="Button1_Com1" Text="提交" Width="70px" />
                        </td>
                        <td colspan="3">
                    <asp:Button ID="Button8" runat="server" Text="重置" CssClass="Button02" Height="24px" OnClick="Button_Cancel"
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
   
     <asp:UpdatePanel ID="UpdatePanel_PSchedule" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <asp:Panel ID="Panel_PSchedule" runat="server" Visible="false">
            <fieldset>
                <legend>
                 <asp:Label ID="label_JDB" runat="server" Visible="true"></asp:Label>
                </legend>
     <asp:GridView ID="Gridview1"  runat="server" AutoGenerateColumns="False"
                    CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"
                    PageSize="5" 
                    OnRowCommand="Gridview_ProjectSchedule_RowCommand"  
                    AllowPaging="True" AllowSorting="True" DataKeyNames="PRMPS_ID"   OnPageIndexChanging="Gridview_ProjectSchedule_PageIndexChanging" 
                    Width="100%"  Font-Strikeout="False" GridLines="None"
                    EnableModelValidation="True" ondatabound="Gridview1_DataBound">
                    <%--    //隔行变色--%>
           
           
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
           
           
                    <%--<PagerStyle CssClass="GridViewPagerStyle" />--%>
           
           
              <AlternatingRowStyle />
           
           
                    <Columns>
                        <asp:BoundField DataField="PRMPS_ID" HeaderText="进度ID" 
                            SortExpression="PRMPS_ID" Visible="False">
                            <ItemStyle Width="100px" />
                        </asp:BoundField>
                       
                        <asp:BoundField DataField="PRMPS_Num" HeaderText="进度编号" 
                            SortExpression="PRMPS_Num" />
                       
                        <asp:BoundField DataField="PRMPS_ScheduleName" HeaderText="进度名称" 
                            SortExpression="PRMPS_ScheduleName">
                        </asp:BoundField>
                        <asp:BoundField DataField="PRMPS_ScheduleTime" HeaderText="进度时间" 
                            SortExpression="PRMPS_ScheduleTime" />
                        <asp:BoundField DataField="PRMPS_ScheduleContent" HeaderText="进度内容" 
                            SortExpression="PRMPS_ScheduleContent" />
                       <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="btnLook3" runat="server" CommandName="Edit1" 
                                    CommandArgument='<%#Eval("PRMPS_ID")%>'>编辑</asp:LinkButton>
                                   
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="btnLook4" runat="server" CommandName="Cancel1" 
                                 OnClientClick="return confirm('您确认删除该记录吗?')"    CommandArgument='<%#Eval("PRMPS_ID")%>'>删除</asp:LinkButton>
                                   
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
                <tr>
               <td width="35%" align="right" >
                  
              <asp:Button ID="Button6" runat="server" Text="提交" CssClass="Button02" Height="24px" OnClick="Button_CF" Visible="true" 
                    Width="70px" />
                    </td>
                    <td style="width: 20%" align="center">
                   
                    &nbsp;</td>
                   
           <td width="30%" align="left">
               <asp:Button ID="Button7" runat="server" CssClass="Button02" Height="24px" 
                    OnClick="Button2_Cancel1" Text="关闭" Width="70px" />     
            </td>
            </tr>
                 <tr>
               <td  align="center" colspan="3">
                  
              <asp:Button ID="Button9" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="Button_Leon" Visible="false" 
                    Width="70px" />
                    </td>
                    </tr>
            </fieldset>
            </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>