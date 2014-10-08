<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PRMProjectMaintenance.aspx.cs" Inherits="ProjectManagement_PRMProjectMaintenance"  MasterPageFile="~/Other/MasterPage.master"%>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script> 
    <asp:UpdatePanel ID="UpdatePanel_ProjectSearch" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_ProjectSearch" runat="server" Visible="true">
                <fieldset>
                    <legend> 项目查询</legend>
                    <asp:Label ID="Label_FilePath" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="Label_Pname" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="Label_SchduleID" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="labelcondition" runat="server" Visible="false"></asp:Label>
    <table style="width: 100%;">
         <asp:Label ID="label_projectstate" runat="server" Visible="False"></asp:Label>
          <asp:Label ID="label_pagestate" runat="server" Visible="False"></asp:Label>
         <asp:Label ID="label_projectid" runat="server" Visible="False"></asp:Label>
             <asp:Label ID="labelcodition" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="label16" runat="server" Visible="False"></asp:Label>
             <asp:Label ID="label1_BasicID" runat="server" Visible="False"></asp:Label>
             <asp:Label ID="label_PRMP_ID" runat="server" Visible="False"></asp:Label>
             <asp:Label ID="LabelQ_SaveDirectory" runat="server" Visible="False"></asp:Label>
        <tr>
        <td style="width: 15%" align="right">
                <asp:Label ID="Label1" runat="server" Text="产品型号："></asp:Label>
            </td>
            <td style="width: 12%" align="left">
                <asp:TextBox runat="server" ID="TextBox1"> </asp:TextBox>
            </td>
            <td style="width: 15%" align="right">
                <asp:Label ID="Label" runat="server" Text="项目类型："></asp:Label>
            </td>
            <td style="width: 15%" align="left">
                <asp:DropDownList ID="DropDownList1" runat="server" Width="121px" >
                     <asp:ListItem>请选择</asp:ListItem>
                    <asp:ListItem>工艺改进</asp:ListItem>
                    <asp:ListItem>设备改进</asp:ListItem>
                   <asp:ListItem>新产品开发</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="width: 15%" align="right">
                <asp:Label ID="Label15" runat="server" Text="项目名称："></asp:Label>
            </td>
            <td style="width: 17%" align="left">
                <asp:TextBox runat="server" ID="ProjectName"> </asp:TextBox>
            </td>
            </tr>
            <tr>
            <td style="width: 15%" align="right">
                <asp:Label ID="Label5" runat="server" Text="项目编号："></asp:Label>
            </td>
            
            <td style="width: 17%" align="left">
                <asp:TextBox runat="server" ID="PRMP_ID"> </asp:TextBox>
            </td> <td style="width: 15%" align="right">
                <asp:Label ID="Label9" runat="server" Text="是否有样品："></asp:Label>
            </td>
           <td style="width: 15%" align="left">
                <asp:DropDownList ID="DropDownList4" runat="server" Width="121px">
                     <asp:ListItem>请选择</asp:ListItem>
                    <asp:ListItem>是</asp:ListItem>
                    <asp:ListItem>否</asp:ListItem>
                   
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                <asp:Button ID="Button1" runat="server" Text="检索" CssClass="Button02" Height="24px" OnClick="Button1_Sh"
                    Width="70px" />
            </td>
           
            <td colspan="3" align="center">
                
                <asp:Button ID="Button3" runat="server" Text="重置" CssClass="Button02" Height="24px" OnClick="Button1_Reset" Visible="true"
                    Width="70px" />
            </td>
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
                    PageSize="10" 
                    OnRowCommand="Gridview_ProjectInfo_RowCommand"  
                    AllowPaging="True" AllowSorting="True" DataKeyNames="PRMP_ID"   OnPageIndexChanging="Gridview_ProjectInfo_PageIndexChanging" 
                    Width="100%" GridLines="None" 
                    EnableModelValidation="True" 
                    onrowdatabound="Gridview_ProjectInfo_RowDataBound" 
                    ondatabound="Gridview_ProjectInfo_DataBound">
                    <%--    //隔行变色--%>  <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
           
           
             
           
           
         <%--   <PagerStyle  ForeColor="Black" 
                 HorizontalAlign="Center" CssClass="GridViewPagerStyle" />
           
           
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
           --%>
           
                    <Columns>
                        <asp:BoundField DataField="PRMP_ProjectNum" HeaderText="项目编号" SortExpression="PRMP_ProjectNum" 
                            Visible="True">
                            
                        </asp:BoundField>
                        <asp:BoundField DataField="PRMP_ProjectName" HeaderText="项目名称" SortExpression="PRMP_ProjectName">
                            
                        </asp:BoundField>
                        <asp:BoundField DataField="PRMP_ProductMode" HeaderText="产品型号" SortExpression="PRMP_ProductMode">
                            
                        </asp:BoundField>
                         <asp:BoundField DataField="PRMP_ProjectType" HeaderText="项目类型" SortExpression="PRMP_ProjectType">
                           
                        </asp:BoundField>
                        <asp:BoundField DataField="PRMP_Sample" HeaderText="是否有样品" SortExpression="PRMP_Sample">
                           
                        </asp:BoundField>
                        <asp:BoundField DataField="PRMP_ImproveAim" HeaderText="改进目的" SortExpression="PRMP_ImproveAim">
                           
                        </asp:BoundField>
                        <asp:BoundField DataField="PRMP_ImproveRequest" HeaderText="改进要求" SortExpression="PRMP_ImproveRequest">
                          
                        </asp:BoundField>
                        <asp:BoundField DataField="PRMP_ProjectStates" HeaderText="项目状态" SortExpression="PRMP_ProjectStates">
                           
                        </asp:BoundField>
                        <asp:BoundField DataField="PRMP_ResponDepart" HeaderText="责任部门"  SortExpression="PRMP_ResponDepart">
                       
                         </asp:BoundField>
                        <asp:BoundField DataField="PRMP_ID" HeaderText="项目ID" SortExpression="PRMP_ID" 
                            Visible="false">
                            
                        </asp:BoundField>
                        <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="btnLook1" runat="server" CommandName="Check1" 
                                    CommandArgument='<%#Eval("PRMP_ID")%>'>进度维护</asp:LinkButton>
                            </ItemTemplate>
                             
                        </asp:TemplateField>
                          <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="btnLkk" runat="server" CommandName="LookP" 
                                    CommandArgument='<%#Eval("PRMP_ID")%>'>查看进度</asp:LinkButton>
                            </ItemTemplate>
                             
                        </asp:TemplateField>
                    </Columns>
               <EmptyDataTemplate>
              <asp:Label ID="Label50" runat="server" Text="无相关记录！"></asp:Label>
             </EmptyDataTemplate>
                 <%--<FooterStyle CssClass="GridViewFooterStyle" />
                    <HeaderStyle CssClass="GridviewHead"
                        HorizontalAlign="Center" />--%>
          
           
                   <%-- <PagerStyle CssClass="GridViewPagerStyle" />--%>
         
           
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
                </fieldset>
                </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    
      <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <asp:Panel ID="Panel2" runat="server" Visible="false">
            <fieldset>
                <legend>进度明细表</legend>
                
                <asp:GridView ID="Gridview2"  runat="server" AutoGenerateColumns="False"
                    CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"
                    PageSize="5" 
                   Font-Strikeout="False" GridLines="None"
                    AllowPaging="True" AllowSorting="True" DataKeyNames="PRMPS_ID"   OnPageIndexChanging="Gridview_PS_PageIndexChanging" 
                    Width="100%" 
                    EnableModelValidation="True" onrowcommand="Gridview2_RowCommand" 
                    ondatabound="Gridview2_DataBound">
                    <%--    //隔行变色--%>
           
           
              <%--<AlternatingRowStyle />--%>
           
           
            <%--<PagerStyle 
                 HorizontalAlign="Center" CssClass="GridViewPagerStyle" />--%>
           
           
                    <%--<AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />--%>
                    <Columns>
                        <asp:BoundField DataField="PRMPS_ID" HeaderText="项目进度ID" SortExpression="PRMPS_ID" 
                            Visible="false">
                            <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRMPS_ScheduleName" HeaderText="项目进度" SortExpression="PRMPS_ScheduleName">
                            <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRMPS_Num" HeaderText="进度序号" SortExpression="PRMPS_Num">
                            <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRMPS_ScheduleTime" HeaderText="进度时间" 
                            SortExpression="PRMPS_ScheduleTime" />
                        <asp:BoundField DataField="PRMPS_ScheduleContent" HeaderText="进度内容" 
                            SortExpression="PRMPS_ScheduleContent" />
                        <asp:BoundField DataField="PRMPS_ScheduleFinish" HeaderText="是否完成" SortExpression="PRMPS_ScheduleFinish">
                            <ItemStyle  />
                        </asp:BoundField>
                         <asp:BoundField DataField="PRMPS_ProcessCondition" HeaderText="进展情况" SortExpression="PRMPS_ProcessCondition">
                            <ItemStyle  />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRMPS_WorkOrderNum" HeaderText="涉及随工单号" SortExpression="PRMPS_WorkOrderNum">
                            <ItemStyle  />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRMPS_Accessory" HeaderText="是否有附件" SortExpression="PRMPS_Accessory">
                            <ItemStyle  />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRMPS_ScheduleRelay" HeaderText="是否延期" 
                            SortExpression="PRMPS_ScheduleRelay" />
                            <asp:BoundField DataField="PRMPS_RelayDay" HeaderText="延期天数" 
                            SortExpression="PRMPS_RelayDay" />
                            <asp:BoundField DataField="PRMPS_RelayReason" HeaderText="延期原因" 
                            SortExpression="PRMPS_RelayReason" />
                        <asp:BoundField DataField="PRMPS_AccNum" HeaderText="附件编号" SortExpression="PRMPS_AccNum">
                            <ItemStyle  />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRMPS_AccName" HeaderText="附件名称" SortExpression="PRMPS_AccName">
                            <ItemStyle  />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRMPS_AccessoryPath" HeaderText="附件相对路径" SortExpression="PRMPS_AccessoryPath"  Visible="false" ReadOnly="True" >
                            <ItemStyle  />
                        </asp:BoundField>
                        <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="BTLay" runat="server" CommandName="Lay" 
                                    CommandArgument='<%#Eval("PRMPS_ID")%>'>延期</asp:LinkButton>
                                   
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="BTProtect" runat="server" CommandName="Protect" 
                                    CommandArgument='<%#Eval("PRMPS_ID")%>'>维护</asp:LinkButton>
                                   
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField >
                            <ItemTemplate >
                               <asp:HyperLink ID="Down2" runat="server"  CommandArgument='<%#Eval("PRMPS_AccessoryPath")%>'   NavigateUrl='<%#"~/"+Eval("PRMPS_AccessoryPath")+"?path={0}"%>' >附件证明查看</asp:HyperLink >
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="BTFollow" runat="server" CommandName="Follow" 
                                    CommandArgument='<%#Eval("PRMPS_ID")%>'>随工单跟踪</asp:LinkButton>
                                   
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                    </Columns>
               <EmptyDataTemplate>
              <asp:Label ID="Label50" runat="server" Text="无相关记录！"></asp:Label>
             </EmptyDataTemplate>
                    <%--<FooterStyle CssClass="GridViewFooterStyle" />--%>
                    <%--<HeaderStyle CssClass="GridViewHead" 
                        HorizontalAlign="Center" />--%>
           
           
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
                        </tr> </table>
                         </PagerTemplate>

                    <RowStyle CssClass="GridViewRowStyle" />
                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                </asp:GridView>
                       
                        <table width="100%">
                        <tr>
                        <td  align="center">
                <asp:Button ID="Button22" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="ButtonPClose"
                    Width="70px" />
            </td>
                        </tr>
                     </table>
           </fieldset>
                </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

     <asp:UpdatePanel ID="UpdatePanel_Pschedule" runat="server" UpdateMode="Conditional">
       
        <ContentTemplate>
              <asp:Panel ID="Panel_Pschedule" runat="server" Visible="false">  
                <fieldset>
                    <legend> 进度维护</legend>
                    
    <table style="width: 100%;">
         
        <tr>
        <td  align="right" colspan="1">
             <asp:Label ID="Label3" runat="server" Text="项目编号："></asp:Label>
            </td>
            <td colspan="1"align="left">
                <asp:TextBox runat="server" ID="TextBox7" Enabled ="false" 
                onkeyup="this.value=this.value.replace(/[^0-9]/g,'')"
                                    onafterpaste="this.value=this.value.replace(/[^0-9]/g,'')"> </asp:TextBox>
            </td>
            <td colspan="1" align="right">
                <asp:Label ID="Label4" runat="server" Text="项目名称："></asp:Label>
            </td>
             <td colspan="1" align="left">
                <asp:TextBox runat="server" ID="TextBox8" Enabled ="false" > </asp:TextBox>
            </td>
            <td colspan="1" align="right">
                <asp:Label ID="Label6" runat="server" Text="项目进度："></asp:Label>
            </td>
            <td colspan="1" align="left">
                <asp:TextBox runat="server" ID="TextBox9" Enabled ="false" > </asp:TextBox>
            </td>
            </tr>
            <tr>
            <td align="right" colspan="1">
                <asp:Label ID="Label13" runat="server" Text="该项目进度是否完成："></asp:Label>
            </td>
            
            <td colspan="1" align="left">
        <asp:DropDownList ID="DropDownList3" runat="server" Height="16px" Width="125px" >
                <asp:ListItem>请选择</asp:ListItem>
                <asp:ListItem>是</asp:ListItem>
                <asp:ListItem>否</asp:ListItem>
               
                </asp:DropDownList>
                 <asp:Label ID="Label26" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
             <td  align="left" colspan="1">
                <asp:Button ID="Button4" runat="server" Text="上传附件" CssClass="Button02" Height="24px" OnClick="Button_Aline"
                    Width="90px" />
            </td>
          </tr>
            <tr>
            <td align="right" colspan="1"> 
                <asp:Label ID="Label7" runat="server" Text="随工单选择："></asp:Label>
                </td>
             <td colspan="3">                                                
                 <asp:TextBox ID="TextBox10" runat="server" Height="80px" Width="570px" 
                     Enabled ="false" ></asp:TextBox>
                <asp:Label ID="Label27" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
               
                
            <td  align="left" colspan="2">
                <asp:Button ID="Button7" runat="server" Text="选择随工单" CssClass="Button02" Height="24px" OnClick="Button1_FD"
                    Width="90px" />
            </td>
            </tr>
            
            <tr>
             <td align="right" colspan="1">
                <asp:Label ID="Label12" runat="server" Text="进展情况："></asp:Label>
               <br/>
                         <asp:Label ID="Label19" runat="server" Text="(200字以内)"></asp:Label>
                </td>
                <td  align="left"  colspan="6">
                <asp:TextBox runat="server" ID="TextBox11" Height="72px" Width="720px" 
                        MaxLength="200" TextMode="MultiLine"   
                         onkeyup="this.value = this.value.substring(0, 200)" 
                        onafterpaste="this.value = this.value.substring(0, 200)"></asp:TextBox>
                         <asp:Label ID="Label28" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="right">
                <asp:Button ID="Button_TijiaoWeihu" runat="server" Text="提交" CssClass="Button02" Height="24px" OnClick="Button1_TJWH"  
                    Width="70px" />
            </td>
            <td colspan="2" align="left">
            </td>
            <td colspan="2" align="left">
                
                <asp:Button ID="Button6" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="Button_Cancel" Visible="true"
                    Width="70px" />
            </td>
        </tr>
    </table>
     </fieldset>
      </asp:Panel>
        </ContentTemplate>
     
<%--<Triggers>
    <asp:PostBackTrigger ControlID="Button_TijiaoWeihu" />
        </Triggers>--%>
        <%--<Triggers>
            <asp:AsyncPostBackTrigger ControlID="Button_TijiaoWeihu" EventName="Click" />
        </Triggers>--%>
    </asp:UpdatePanel>
    <div id="Panel4" >
     <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
       
        <ContentTemplate>
             
                <fieldset>
                    <legend> 附件上传</legend>
                     <asp:Label ID="label_AccNum" runat="server"  Visible="false"></asp:Label>
                     <asp:Label ID="label_AccName" runat="server"  Visible="false"></asp:Label>
    <table style="width: 100%;">
    <tr style="height: 16px;">
    <td style="width: 16%" align="right">
                <asp:Label ID="Label17" runat="server" Text="附件编号："></asp:Label>
            </td>
             <td style="width: 17%" align="left">
                <asp:TextBox runat="server" ID="TextBox14" Enabled ="true" > </asp:TextBox>
                <asp:Label ID="Label29" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
           
             <td align="right" style="width: 17%">
                <asp:Label ID="Label18" runat="server" Text="附件名称："></asp:Label>
            </td>
             <td style="width: 17%" align="left">
                <asp:TextBox runat="server" ID="TextBox15" Enabled ="true" > </asp:TextBox>
                <asp:Label ID="Label30" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
    <td style="width: 17%" align="right">
                <asp:Label ID="Label14" runat="server" Text="上传文件："></asp:Label>
               
                </td>
                 <td style="width: 17%" align="left">
                     <asp:FileUpload ID="FileUpload1" runat="server" />
                   <asp:Label ID="Label31" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            
            </tr>
            <tr>
            <td  align="center" colspan="1">
            </td>
             <td  align="center" colspan="2">
                <asp:Button ID="Button13" runat="server" Text="提交" CssClass="Button02" Height="24px" OnClick="Button1_Fox"
                    Width="90px" />
            </td>
             <td  align="center" colspan="2">
                <asp:Button ID="Button14" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="Button1_Emi"
                    Width="90px" />
            </td>
            </tr>
     </table>
     </fieldset>
        </ContentTemplate>
     
<Triggers>
    <asp:PostBackTrigger ControlID="Button13" />
        </Triggers>
        <%--<Triggers>
            <asp:AsyncPostBackTrigger ControlID="Button_TijiaoWeihu" EventName="Click" />
        </Triggers>--%>
        </asp:UpdatePanel>
  </div>


      <asp:UpdatePanel ID="UpdatePanel_Postpone" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Postpone" runat="server" Visible="False">
                <fieldset>
                    <legend> 延期设置</legend>
    <table style="width: 100%;">
         
        <tr>
        <td style="width: 15%" align="right">
                <asp:Label ID="Label11" runat="server" Text="项目编号："></asp:Label>
            </td>
            <td style="width: 12%" align="left">
                <asp:TextBox runat="server" ID="TextBox4" Enabled ="false" > </asp:TextBox>
            </td>
            <td style="width: 15%" align="right">
                <asp:Label ID="Label8" runat="server" Text="项目名称："></asp:Label>
            </td>
             <td style="width: 12%" align="left">
                <asp:TextBox runat="server" ID="TextBox2" Enabled ="false" > </asp:TextBox>
            </td>
            <td style="width: 15%" align="right">
                <asp:Label ID="Label10" runat="server" Text="项目进度："></asp:Label>
            </td>
            <td style="width: 17%" align="left">
                <asp:TextBox runat="server" ID="TextBox3" Enabled="false" > </asp:TextBox>
            </td>
            </tr>
            <tr>
            <td style="width: 15%" align="right">
                <asp:Label ID="Label51" runat="server" Text="延期天数："></asp:Label>
               
                </td>
                <td style="width: 17%" align="left">
                <asp:TextBox runat="server" ID="TextBox5"
                onkeyup="this.value=this.value.replace(/[^0-9]/g,'')"
                                    onafterpaste="this.value=this.value.replace(/[^0-9]/g,'')"> </asp:TextBox>
            <asp:Label ID="Label23" runat="server" Text="*" ForeColor="Red"></asp:Label>

            </td>
        </tr>
        <tr>
             <td style="width: 15%" align="right">
                <asp:Label ID="Label2" runat="server" Text="延期原因："></asp:Label>
                <br/>
                         <asp:Label ID="Label24" runat="server" Text="(200字以内)"></asp:Label>
                </td>
                <td style="width: 17%" align="left"  colspan="5">
                <asp:TextBox runat="server" ID="TextBox6" Height="66px" Width="690px" 
                        MaxLength="200" TextMode="MultiLine"   
                         onkeyup="this.value = this.value.substring(0, 200)" 
                        onafterpaste="this.value = this.value.substring(0, 200)"></asp:TextBox>
            <asp:Label ID="Label25" runat="server" Text="*" ForeColor="Red"></asp:Label>

            </td>
            
        </tr>
        <tr>
            <td colspan="2" align="right">
                <asp:Button ID="Button2" runat="server" Text="提交" CssClass="Button02" Height="24px" OnClick="Button2_Sh"
                    Width="70px" />
            </td>
            <td colspan="2" align="left">
            </td>
            <td colspan="2" align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button5" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="Button2_Cancel" Visible="true"
                    Width="70px" />
            </td>
        </tr>
    </table>
     </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
  
   
   <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel3" runat="server" Visible="False">
                <fieldset>
                    <legend> 随工单选择</legend>
    <table style="width: 100%;">
        
        <tr>
        <td style="width: 15%" align="right">
                <asp:Label ID="Label20" runat="server" Text="产品型号："></asp:Label>
            </td>
            <td style="width: 12%" align="left">
                <asp:TextBox runat="server" ID="TextBox12"> </asp:TextBox>
            </td>
            
            
            <td style="width: 15%" align="center">
                <asp:Label ID="Label21" runat="server" Text="时间从："></asp:Label>
            </td>
       <td>
       <asp:TextBox ID="TextBox_SPTime2" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D ',true)"  ></asp:TextBox>
       </td>

       <td style="width: 15%" align="center">
                <asp:Label ID="Label22" runat="server" Text="到："></asp:Label>
            </td>
       <td>
       <asp:TextBox ID="TextBox13" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D ',true)"  ></asp:TextBox>
       </td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                <asp:Button ID="Button8" runat="server" Text="检索" CssClass="Button02" Height="24px" OnClick="Button1_Fd"
                    Width="70px" />
            </td>
           
            <td colspan="5" align="center">
               
                <asp:Button ID="Button10" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="Button3_CC" Visible="true"
                    Width="70px" />
            </td>
        </tr>
    </table>
     </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

     <asp:UpdatePanel ID="UpdatePanel_WorkOrder" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <asp:Panel ID="Panel_WorkOrder" runat="server" Visible="false">
            <fieldset>
                <legend>随工单表</legend>
                <asp:GridView ID="Gridview_WorkOrder"  runat="server" AutoGenerateColumns="False"
                    CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"
                     PageSize="5" 
                    AllowPaging="True" AllowSorting="True" DataKeyNames="WO_Num"   OnPageIndexChanging="Gridview_WorkOrder_PageIndexChanging" 
                    Width="100%"  Font-Strikeout="False" GridLines="None"
                    EnableModelValidation="True" ondatabound="Gridview_WorkOrder_DataBound">
                    <%--    //隔行变色--%>
           
           <%-- <PagerStyle 
                 HorizontalAlign="Center" CssClass="GridViewPagerStyle" />--%>
           
           
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
            <AlternatingRowStyle />
           
                    <Columns>
                   <asp:TemplateField >
                            <ItemTemplate >
                               <asp:CheckBox ID="CheckBox1" runat="server" />   
                            </ItemTemplate>
                            <ItemStyle />
                        </asp:TemplateField>
                        <asp:BoundField DataField="WO_Num" HeaderText="随工单号" 
                            SortExpression="WO_Num">
                        <ItemStyle  />
                        </asp:BoundField>
                       <asp:BoundField DataField="WO_ProType" HeaderText="产品型号" 
                            SortExpression="WO_ProType">
                        <ItemStyle  />
                        </asp:BoundField>
                         <asp:BoundField DataField="WO_Time" HeaderText="时间" 
                            SortExpression="WO_Time">
                        <ItemStyle />
                        </asp:BoundField>
                    </Columns>
               <EmptyDataTemplate>
              <asp:Label ID="Label50" runat="server" Text="无相关记录！"></asp:Label>
             </EmptyDataTemplate>
                    <FooterStyle CssClass="GridViewFooterStyle" />
                    <HeaderStyle CssClass="GridviewHead" 
                        HorizontalAlign="Center" />
           
           
                  <%--  <PagerStyle ForeColor="Black"   CssClass="GridViewPagerStyle" />--%>
           
           
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
                <td width="40%" align="center" >
                    
                <asp:Button ID="Button9" runat="server" Text="提交" CssClass="Button02" Height="24px" OnClick="Button1_Com"
                    Width="70px" />
            </td>
           <td style="width: 20%" align="center">
                &nbsp;</td>
                    
                   
             <td width="30%" align="left">
               
                <asp:Button ID="Button11" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="Button1_Cancel"
                    Width="70px" />
            </td> 
                </tr>
                </fieldset>
                </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
   
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <asp:Panel ID="Panel1" runat="server" Visible="false">
            <fieldset>
                <legend>随工单表</legend>
                <asp:GridView ID="Gridview1"  runat="server" AutoGenerateColumns="False"
                    CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"
                    PageSize="10" 
                    AllowPaging="True" AllowSorting="True" DataKeyNames="WO_Num"   OnPageIndexChanging="Gridview1_PageIndexChanging" 
                    Width="100%"  Font-Strikeout="False" GridLines="None"
                    EnableModelValidation="True" ondatabound="Gridview1_DataBound">
                    <%--    //隔行变色--%>
           
            <%--<PagerStyle 
                 HorizontalAlign="Center" CssClass="GridViewPagerStyle" />--%>
           
           
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
            <AlternatingRowStyle />
           
                    <Columns>
                        <asp:BoundField DataField="WO_Num" HeaderText="随工单号" 
                            SortExpression="WO_Num">
                      
                        </asp:BoundField>
                       <asp:BoundField DataField="WO_ProType" HeaderText="产品型号" 
                            SortExpression="WO_ProType">
                        
                        </asp:BoundField>
                         <asp:BoundField DataField="WO_Time" HeaderText="时间" 
                            SortExpression="WO_Time">
                       
                        </asp:BoundField>
                        <asp:BoundField DataField="WO_State" HeaderText="随工单状态" 
                            SortExpression="WO_State">
                        </asp:BoundField>
                        <asp:BoundField DataField="WOD_InNum" HeaderText="投入数量" 
                            SortExpression="WOD_InNum">
                        </asp:BoundField>
                        <asp:BoundField DataField="WOD_QNum" HeaderText="合格数量" 
                            SortExpression="WOD_QNum">
                        </asp:BoundField>
                        <asp:BoundField DataField="WOD_WNum" HeaderText="废品总量" 
                            SortExpression="WOD_WNum">
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

                    <RowStyle CssClass="GridViewRowStyle" />
                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                </asp:GridView>
                <table width="100%">
                        <tr>
                        <td  align="center">
                <asp:Button ID="Button12" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="ButtonCClose"
                    Width="70px" />
            </td>
                        </tr>
                     </table>
                     </fieldset>
                </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    

    </asp:Content>
    