<%@ Page Title = "总经理审核" Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true" CodeFile="HRPerfManagerCheck.aspx.cs" Inherits="HRPerfMgt_HRPerfManagerCheck" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
    <script language="javascript" type="text/javascript">
        function onlyNumber(obj) {
            obj.value = obj.value.replace(/[^\d?]/g, "");
        }
    </script>
    <style type="text/css">
        .hidden
        {
            display: none;
        }
        .style1
        {
            width: 268435456px;
        }
        .style2
        {
            width: 268435392px;
        }
    </style>
    <%--已经审核过的年份和月份--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
      
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" Visible="true">
                <fieldset>
                    <legend>
                        <asp:Label ID="Label7" runat="server" Text=""></asp:Label>&nbsp 审核的年份和月份详情</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 10%" align="center" colspan="2">
                                <asp:Label ID="Label18" runat="server" Text="检索前" Visible="false"></asp:Label>
                                <asp:Label ID="Label15" runat="server" CssClass="STYLE2" Text="年份：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:DropDownList ID="DropDownList2" runat="server" ToolTip="单击选择" AutoPostBack="true" Width="70px">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label17" runat="server" CssClass="STYLE2" Text="月份：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:DropDownList ID="DropDownList3" runat="server" ToolTip="单击选择" Width="70px">
                                </asp:DropDownList>
                            </td>
                            
                             <td align="center">
                                <asp:Button ID="Button3" runat="server" CssClass="Button02" Height="24px"
                                    Text="检索" Width="70px" OnClick="BtnSearchPanel1_Click"/>
                                 <asp:Label ID="LabelA_State" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Label ID="LabelA_Person" runat="server" Text="" Visible="false"></asp:Label>
                               <asp:Label ID="LabelYear" runat="server" Text="" Visible="false"></asp:Label>
                               
                                                              
                            </td>
                            <td >
                                <asp:Label ID="LabelMonth" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Button ID="Button5" runat="server" CssClass="Button02" Height="24px"
                                    Text="重置" Width="70px" OnClick="BtnResetPanel1_Click"/>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="8">
                                <fieldset>
                                    <legend>年份和月份列表<asp:Label ID="Label10" runat="server" Text="" Visible="false"></asp:Label></legend>
                                    <asp:GridView ID="GridView1" runat="server" DataKeyNames="HRP_Year"  AllowSorting="True"
                                        AutoGenerateColumns="False" CssClass="GridViewStyle" Width="100%" AllowPaging="True"
                                        PageSize="5" GridLines="None" OnRowCommand="GridView1_RowCommand" OnPageIndexChanging="GridView1_PageIndexChanging"
                                        >
                                        <RowStyle CssClass="GridViewRowStyle" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                        <HeaderStyle CssClass="GridViewHead" />
                                        <FooterStyle CssClass="GridViewFooterStyle" />
                                        <Columns>
                                        
                                            <asp:BoundField DataField="HRP_Year" HeaderText="年份" SortExpression="HRP_Year">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRP_Month" HeaderText="月份" SortExpression="HRP_Month">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRP_M_State" HeaderText="审核状态" SortExpression="HRP_C_State">
                                                <ItemStyle />
                                            </asp:BoundField>
                                             <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbtnEdit1" runat="server" CommandArgument='<%#Eval("HRP_Year")%>'
                                                        CommandName="EditPanel1" OnClientClick="false">绩效审核</asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbtnEdit2" runat="server" CommandArgument='<%#Eval("HRP_Year")%>'
                                                        CommandName="EditPanel1_View" OnClientClick="false">查看该月审核情况</asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerTemplate>
                                            <table width="100%">
                                                <tr>
                                                    <td style="text-align: right">
                                                        第&nbsp<asp:Label ID="lblPageIndex" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                                        页 共&nbsp<asp:Label ID="lblPageCount" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageCount  %>" />
                                                        页
                                                        <asp:LinkButton ID="btnFirst" runat="server" CausesValidation="False" CommandArgument="First"
                                                            CommandName="Page" Text="首页" />
                                                        <asp:LinkButton ID="btnPrev" runat="server" CausesValidation="False" CommandArgument="Prev"
                                                            CommandName="Page" Text="上一页" />
                                                        <asp:LinkButton ID="btnNext" runat="server" CausesValidation="False" CommandArgument="Next"
                                                            CommandName="Page" Text="下一页" />
                                                        <asp:LinkButton ID="btnLast" runat="server" CausesValidation="False" CommandArgument="Last"
                                                            CommandName="Page" Text="尾页" />
                                                        <asp:TextBox ID="textbox1" runat="server" Width="20px"></asp:TextBox>
                                                        <%--<asp:textbox id="txtNewPageIndex" runat="server" width="20px" text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />--%>
                                                        <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                                            CommandName="Page" Text="GO" />
                                                        <!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
                                                    </td>
                                                </tr>
                                            </table>
                                        </PagerTemplate>
                                        <EmptyDataTemplate>
                                            <asp:Label ID="Label16" runat="server" Text="没有找到相关记录"></asp:Label>
                                        </EmptyDataTemplate>
                                        <EditRowStyle BackColor="white" />
                                    </asp:GridView>
                                </fieldset>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--要进行审核的人列表--%>
    <asp:UpdatePanel ID="UpdatePanel_SearchEmployee" runat="server" UpdateMode="Conditional">
        
        <ContentTemplate>
            <asp:Panel ID="Panel_SearchEmployee" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="LblTheSet2" runat="server" Text=""></asp:Label>&nbsp 检索条件</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                        <td style="width: 15%" align="right"></td>
                            <td style="width: 15%" align="right">
                                <asp:Label ID="LblStateForGrid_Type" runat="server" Text="检索前" Visible="false"></asp:Label>
                                <asp:Label ID="Label11" runat="server" CssClass="STYLE2" Text="工号：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TxtSearchStaffNO" runat="server" Width="130px"></asp:TextBox>
                                
                            </td>
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label12" runat="server" CssClass="STYLE2" Text="姓名：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TxtSearchName" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td></td>
                        </tr>
                        
                     
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Label ID="Label5" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Label ID="Label6" runat="server" Text="" Visible="false"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Button ID="BtnSearchEmployee" runat="server" CssClass="Button02" Height="24px"
                                    Text="检索" Width="70px" OnClick="BtnSearchEmployee_Click" />
                            </td>
                            <td colspan="2" align="center">
                                <asp:Button ID="Button1" runat="server" CssClass="Button02" Height="24px" OnClick="BtnReset_Click"
                                    Text="重置" Visible="true" Width="70px" CausesValidation="False" />
                            </td>
                            <td >
                                <asp:Button ID="Button4" runat="server" CssClass="Button02" Height="24px" Text="关闭"
                                    Visible="true" Width="70px" OnClick="BtncloseSearchEmployee_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="8">
                                <fieldset>
                                    <legend>员工信息列表</legend>
                                    <asp:GridView ID="Grid_Detail" runat="server" DataKeyNames="HRPD_ID" AllowSorting="True"
                                        AutoGenerateColumns="False" CssClass="GridViewStyle" Width="100%" AllowPaging="True"
                                        PageSize="5" GridLines="None" OnRowCommand="Grid_Detail_RowCommand" OnPageIndexChanging="Grid_Detail_PageIndexChanging"
                                        >
                                        <RowStyle CssClass="GridViewRowStyle" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                        <HeaderStyle CssClass="GridViewHead" />
                                        <FooterStyle CssClass="GridViewFooterStyle" />
                                        <Columns>
                                            <asp:BoundField DataField="HRPD_ID" HeaderText="绩效考核详情ID" SortExpression="HRPD_ID"
                                                Visible="false">
                                                <ItemStyle />
                                            </asp:BoundField>
   
                                            <asp:BoundField DataField="HRDD_StaffNO" HeaderText="工号" SortExpression="HRDD_StaffNO">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRDD_Name" HeaderText="姓名" SortExpression="HRDD_Name">
                                                <ItemStyle />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="HRP_Post" HeaderText="岗位" SortExpression="HRP_Post">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRPD_FinalScore" HeaderText="自评分" SortExpression="HRPD_FinalScore">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRPD_C_FinalScore" HeaderText="人事部审核后得分" SortExpression="HRPD_C_FinalScore">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            
                                        
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbtnEdit1" runat="server" CommandArgument='<%#Eval("HRPD_ID")%>'
                                                        CommandName="Edit1" OnClientClick="false">录入得分</asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerTemplate>
                                            <table width="100%">
                                                <tr>
                                                    <td style="text-align: right">
                                                        第&nbsp<asp:Label ID="lblPageIndex" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                                        页 共&nbsp<asp:Label ID="lblPageCount" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageCount  %>" />
                                                        页
                                                        <asp:LinkButton ID="btnFirst" runat="server" CausesValidation="False" CommandArgument="First"
                                                            CommandName="Page" Text="首页" />
                                                        <asp:LinkButton ID="btnPrev" runat="server" CausesValidation="False" CommandArgument="Prev"
                                                            CommandName="Page" Text="上一页" />
                                                        <asp:LinkButton ID="btnNext" runat="server" CausesValidation="False" CommandArgument="Next"
                                                            CommandName="Page" Text="下一页" />
                                                        <asp:LinkButton ID="btnLast" runat="server" CausesValidation="False" CommandArgument="Last"
                                                            CommandName="Page" Text="尾页" />
                                                        <asp:TextBox ID="textbox999" runat="server" Width="20px"></asp:TextBox>
                                                        <%--<asp:textbox id="txtNewPageIndex" runat="server" width="20px" text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />--%>
                                                        <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                                            CommandName="Page" Text="GO" />
                                                        <!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
                                                    </td>
                                                </tr>
                                            </table>
                                        </PagerTemplate>
                                        <EmptyDataTemplate>
                                            <asp:Label ID="Label16" runat="server" Text="没有找到相关记录"></asp:Label>
                                        </EmptyDataTemplate>
                                        <EditRowStyle BackColor="white" />
                                    </asp:GridView>
                                </fieldset>
                            </td>
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
                    <legend>录入考核信息</legend>
                    <table style="width: 100%;">
                        <tr>
                        <td style="width: 15%; height: 15px;" align="center">
                        <asp:Label ID="LabelDetail" runat="server" Text="" Visible="false"></asp:Label>
                        </td>
                            <td style="width: 10%; height: 15px;" align="right">
                                <asp:Label ID="Label3" runat="server" CssClass="STYLE2" Text="员工编号："></asp:Label>                            
                                
                            </td>
                            <td style="width: 15%; height: 15px;">
                                <asp:TextBox ID="TxtItem1" runat="server" Width="120px" Enabled="False"></asp:TextBox>
                            </td>
                            <td style="width: 15%; height: 15px;" align="right">
                                <asp:Label ID="Label4" runat="server"  Text="姓名："></asp:Label>
                            </td>
                            <td style="width: 15%; height: 15px;">
                                <asp:TextBox ID="TxtItem2" runat="server" Width="120px" Enabled="False"></asp:TextBox>
                            </td>
                            <td ></td>
                        </tr>            
                       <tr style="height: 16px;">
                            <td></td>
                            <td align="right">
                                <asp:Label ID="LblSStartTime" runat="server" Text="审核时间："></asp:Label>
                            </td>
                            <td  align="left">
                                <asp:TextBox ID="TxtCheckTime" runat="server" Width="120px" Enabled="false"  onfocus="new  WdatePicker(this,'%Y-%M-%D %h:%m:%s',true)"></asp:TextBox>
                                
                            </td>
                            <td  align="right">
                                
                                <asp:Label ID="LblSPerson" runat="server"  Text="得分："></asp:Label>
                            </td>
                            <td  align="left" >
                                <asp:TextBox ID="CheckPerson" runat="server" Width="120px" maxlength="2"
                                onkeyup="this.value=this.value.replace(/[^\d?]/g,'')" 
                                onafterpaste="this.value=this.value.replace(/[^\d?]/g,'')"></asp:TextBox>
                                
                            </td>
                            <td  align="left">
                                <asp:Label ID="Label34" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    
                    <table style="width: 100%;">
                        <tr>
                            <td align="center" style="width: 50%;">
                                <asp:Button ID="BtnOK" runat="server" CssClass="Button02" Height="24px" Text="提交"
                                    Width="70px" ValidationGroup="Input" OnClick="BtnOK_Click" />
                            </td>
                            <td align="center" style="width: 50%;">
                                <asp:Button ID="Btnclose" runat="server" CssClass="Button02" Height="24px" Text="关闭"
                                    Visible="true" Width="70px" OnClick="Btnclose_Click" />
                            </td>
                        </tr>
                    </table>

                </fieldset>
            </asp:Panel>
       </ContentTemplate>
    </asp:UpdatePanel>

    <%--查看要考核人的信息模块--%>
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
        
        <ContentTemplate>
            <asp:Panel ID="Panel3" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="Label20" runat="server" Text=""></asp:Label>&nbsp 检索条件</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 10%" align="center">
                            <asp:Label ID="Label22" runat="server" Text="检索前" Visible="false"></asp:Label>
                                <asp:Label ID="Label25" runat="server" CssClass="STYLE2" Text="工号：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TextBox1" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label26" runat="server" CssClass="STYLE2" Text="姓名：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TextBox2" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td align="center">
                                <asp:Button ID="Button10" runat="server" CssClass="Button02" Height="24px"
                                    Text="检索" Width="70px" OnClick="BtnSearchGridView3_Click" />
                            </td>
                            <td>
                                <asp:Button ID="Button11" runat="server" CssClass="Button02" Height="24px" OnClick="BtnResetGridView3_Click"
                                    Text="重置" Visible="true" Width="70px" CausesValidation="False" />
                            </td>
                           
                        </tr>
                     
                      
                        <tr>
                            <td colspan="8">
                                <fieldset>
                                    <legend>员工信息列表</legend>
                                    <asp:GridView ID="GridView3" runat="server" DataKeyNames="HRPD_ID" AllowSorting="True"
                                        AutoGenerateColumns="False" CssClass="GridViewStyle" Width="100%" AllowPaging="True"
                                        PageSize="5" GridLines="None"  OnPageIndexChanging="GridView3_PageIndexChanging">
                                        <RowStyle CssClass="GridViewRowStyle" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                        <HeaderStyle CssClass="GridViewHead" />
                                        <FooterStyle CssClass="GridViewFooterStyle" />
                                        <Columns>
                                            <asp:BoundField DataField="HRPD_ID" HeaderText="绩效考核详情ID" SortExpression="HRPD_ID">
                                               <FooterStyle CssClass="hidden" />
                                                <HeaderStyle CssClass="hidden" />
                                                <ItemStyle CssClass="hidden" />
                                            </asp:BoundField>
                                            
                                            <asp:BoundField DataField="HRDD_StaffNO" HeaderText="工号" SortExpression="HRDD_StaffNO">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRDD_Name" HeaderText="姓名" SortExpression="HRDD_Name">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRP_Post" HeaderText="岗位" SortExpression="HRP_Post">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRPD_FinalScore" HeaderText="自评分" SortExpression="HRPD_FinalScore">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRPD_C_FinalScore" HeaderText="人事部审核后得分" SortExpression="HRPD_C_FinalScore">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRPD_M_Score" HeaderText="总经理打分" SortExpression="HRPD_M_Score">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            
                                        </Columns>
                                        <PagerTemplate>
                                            <table width="100%">
                                                <tr>
                                                    <td style="text-align: right">
                                                        第&nbsp<asp:Label ID="lblPageIndex" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                                        页 共&nbsp<asp:Label ID="lblPageCount" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageCount  %>" />
                                                        页
                                                        <asp:LinkButton ID="btnFirst" runat="server" CausesValidation="False" CommandArgument="First"
                                                            CommandName="Page" Text="首页" />
                                                        <asp:LinkButton ID="btnPrev" runat="server" CausesValidation="False" CommandArgument="Prev"
                                                            CommandName="Page" Text="上一页" />
                                                        <asp:LinkButton ID="btnNext" runat="server" CausesValidation="False" CommandArgument="Next"
                                                            CommandName="Page" Text="下一页" />
                                                        <asp:LinkButton ID="btnLast" runat="server" CausesValidation="False" CommandArgument="Last"
                                                            CommandName="Page" Text="尾页" />
                                                        <asp:TextBox ID="textbox33" runat="server" Width="20px"></asp:TextBox>
                                                        <%--<asp:textbox id="txtNewPageIndex" runat="server" width="20px" text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />--%>
                                                        <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                                            CommandName="Page" Text="GO" />
                                                        <!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
                                                    </td>
                                                </tr>
                                            </table>
                                        </PagerTemplate>
                                        <EmptyDataTemplate>
                                            <asp:Label ID="Label16" runat="server" Text="没有找到相关记录"></asp:Label>
                                        </EmptyDataTemplate>
                                        <EditRowStyle BackColor="white" />
                                    </asp:GridView>
                                </fieldset>
                            </td>
                        </tr>
                        <tr>
                             <td align="center" colspan="6">
                                <asp:Button ID="Button9" runat="server" CssClass="Button02" Height="24px" Text="关闭"
                                    Visible="true" Width="70px" OnClick="BtncloseGridView3_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
