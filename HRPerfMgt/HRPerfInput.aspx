<%@ Page Title="绩效考核信息录入"  Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true" CodeFile="HRPerfInput.aspx.cs" Inherits="HRPerfMgt_HRPerfInput" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
    <script language="javascript" type="text/javascript">
        function onlyNumber(obj) {
            obj.value = obj.value.replace(/[^\d{1,2}]/g, "");
        }
    </script>
    <style type="text/css">
        .hidden
        {
            display: none;
        }
    </style>
    <%--已经考核的年份和月份 --%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="DdlSearchDep" />
        </Triggers>
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" Visible="true">
                <fieldset>
                    <legend>
                        <asp:Label ID="Label9" runat="server" Text=""></asp:Label>&nbsp 考核的年份和月份详情</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 10%" align="center" colspan="2">
                                <asp:Label ID="Label18" runat="server" Text="检索前" Visible="false"></asp:Label>
                                <asp:Label ID="Label15" runat="server" CssClass="STYLE2" Text="年份：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 10%" align="left">
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

                             <td style="width: 15%" >
                                <asp:Button ID="Button2" runat="server" CssClass="Button02" Height="24px"
                                    Text="检索" Width="70px" OnClick="BtnSearchPanel1_Click"/>
                               <asp:Label ID="LabelYear" runat="server" Text="" Visible="false"></asp:Label>
                               
                            </td>
                            <td style="width: 15%">
                                <asp:Button ID="Button3" runat="server" CssClass="Button02" Height="24px"
                                    Text="新增" Width="70px" OnClick="BtnNewPanel1_Click"/>
                                <asp:Label ID="LabelMonth" runat="server" Text="" Visible="false"></asp:Label>
                            </td>   
                            <td >
                                <asp:Button ID="Button4" runat="server" CssClass="Button02" Height="24px"
                                    Text="重置" Width="70px" OnClick="BtnResetPanel1_Click"/>
                            </td> 
                        </tr>
                        <tr>
                            <td colspan="8">
                                <fieldset>
                                    <legend>年份和月份列表<asp:Label ID="Label10" runat="server" Text="" Visible="false"></asp:Label></legend>
                                    <asp:GridView ID="GridView1" runat="server" DataKeyNames="HRPYear_ID"  AllowSorting="True"
                                        AutoGenerateColumns="False" CssClass="GridViewStyle" Width="100%" AllowPaging="True"
                                        PageSize="5" GridLines="None" OnRowCommand="GridView1_RowCommand" OnPageIndexChanging="GridView1_PageIndexChanging"
                                        >
                                        <RowStyle CssClass="GridViewRowStyle" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                        <HeaderStyle CssClass="GridViewHead" />
                                        <FooterStyle CssClass="GridViewFooterStyle" />
                                        <Columns>
                                            <asp:BoundField DataField="HRPYear_ID" HeaderText="已录入年份月份ID" SortExpression="HRPYear_ID">
                                               <FooterStyle CssClass="hidden" />
                                                <HeaderStyle CssClass="hidden" />
                                                <ItemStyle CssClass="hidden" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRP_Year" HeaderText="年份" SortExpression="HRP_Year">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRP_Month" HeaderText="月份" SortExpression="HRP_Month">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRP_A_State" HeaderText="录入状态" SortExpression="HRP_A_State">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRP_C_State" HeaderText="审核状态" SortExpression="HRP_C_State">
                                                <ItemStyle />
                                            </asp:BoundField>
                                             <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbtnEdit1" runat="server" CommandArgument='<%#Eval("HRPYear_ID")%>'
                                                        CommandName="EditPanel1" OnClientClick="false">绩效考核录入</asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbtnEdit2" runat="server" CommandArgument='<%#Eval("HRPYear_ID")%>'
                                                        CommandName="EditPanel1_View" OnClientClick="false">查看该月录入情况</asp:LinkButton>
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



    <%--新增的年份和月份的选择框--%>
    <asp:UpdatePanel ID="UpdatePanel_Time" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Time" runat="server" Visible="false">
                <fieldset>
                    <legend>请输入要新增的年份和月份</legend>
                    <table style="width:100%">
                        <tr>
                            <td style="width: 10%" align="center" colspan="2">
                                <asp:Label ID="Label7" runat="server" CssClass="STYLE2" Text="年份：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:DropDownList ID="DropDownListYear" runat="server" ToolTip="单击选择" AutoPostBack="true" Width="70px">
                                </asp:DropDownList>
                                <asp:Label ID="Label34" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label8" runat="server" CssClass="STYLE2" Text="月份：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:DropDownList ID="DropDownListMonth" runat="server" ToolTip="单击选择" Width="70px">
                                </asp:DropDownList>
                                <asp:Label ID="Label19" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                            <td colspan="3" align="left">
                                <asp:Button ID="Button1" runat="server" CssClass="Button02" Height="24px"
                                    Text="确认" Width="70px" OnClick="BtnSearchTime_Click"/>
                            </td> 
                            <td colspan="3" align="left">
                                <asp:Button ID="Button5" runat="server" CssClass="Button02" Height="24px"
                                    Text="关闭" Width="70px" OnClick="BtnCloseTime_Click"/>
                            </td>                           
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--录入考核信息对话框-搜索模块--%>
    <asp:UpdatePanel ID="UpdatePanel_SearchEmployee" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="DdlSearchDep" />
        </Triggers>
        <ContentTemplate>
            <asp:Panel ID="Panel_SearchEmployee" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="LblTheSet2" runat="server" Text=""></asp:Label>检索条件</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label1" runat="server" Text="考核类型：" Enabled="False"></asp:Label>
                                <asp:Label ID="LblStateForGrid_Type" runat="server" Text="检索前" Visible="false"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:DropDownList ID="DropDownList1" runat="server" ToolTip="单击选择">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label13" runat="server" CssClass="STYLE2" Text="部门：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:DropDownList ID="DdlSearchDep" runat="server" ToolTip="单击选择" AutoPostBack="true"
                                    OnSelectedIndexChanged="DdlSearchDep_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label14" runat="server" CssClass="STYLE2" Text="岗位：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:DropDownList ID="DdlSearchPost" runat="server" ToolTip="单击选择">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label11" runat="server" CssClass="STYLE2" Text="工号：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TxtSearchStaffNO" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label12" runat="server" CssClass="STYLE2" Text="姓名：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TxtSearchName" runat="server" Width="130px"></asp:TextBox>
                            </td>
                           
                        </tr>
                     
                        <tr>
                            <td colspan="2" align="right">
                                <asp:Label ID="Label2" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Label ID="Label5" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Label ID="Label6" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Button ID="BtnSearchEmployee" runat="server" CssClass="Button02" Height="24px"
                                    Text="检索" Width="70px" OnClick="BtnSearchEmployee_Click" />
                            </td>
                         
                            <td align="center" colspan="2">
                                <asp:Button ID="BtnReset" runat="server" CssClass="Button02" Height="24px" OnClick="BtnReset_Click"
                                    Text="重置" Visible="true" Width="70px" CausesValidation="False" />
                            </td>
                            <td colspan="2">
                                <asp:Button ID="Button6" runat="server" CssClass="Button02" Height="24px" Text="关闭"
                                    Visible="true" Width="70px" OnClick="BtncloseGrid_Detail_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="8">
                                <fieldset>
                                    <legend>员工信息列表</legend>
                                    <asp:GridView ID="Grid_Detail" runat="server" DataKeyNames="HRDD_ID" AllowSorting="True"
                                        AutoGenerateColumns="False" CssClass="GridViewStyle" Width="100%" AllowPaging="True"
                                        PageSize="5" GridLines="None" OnRowCommand="Grid_Detail_RowCommand" OnPageIndexChanging="Grid_Detail_PageIndexChanging"
                                        >
                                        <RowStyle CssClass="GridViewRowStyle" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                        <HeaderStyle CssClass="GridViewHead" />
                                        <FooterStyle CssClass="GridViewFooterStyle" />
                                        <Columns>
                                            <asp:BoundField DataField="HRDD_ID" HeaderText="人事档案ID" SortExpression="HRDD_ID">
                                               <FooterStyle CssClass="hidden" />
                                                <HeaderStyle CssClass="hidden" />
                                                <ItemStyle CssClass="hidden" />
                                            </asp:BoundField>
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
                                            <asp:BoundField DataField="BDOS_Name" HeaderText="部门" SortExpression="BDOS_Name">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRP_Post" HeaderText="岗位" SortExpression="HRP_Post">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRPAT_PType" HeaderText="考核类型" SortExpression="HRPAT_PType">
                                                <ItemStyle />
                                            </asp:BoundField>
                                           
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbtnEdit1" runat="server" CommandArgument='<%#Eval("HRDD_ID")%>'
                                                        CommandName="Edit1" OnClientClick="false">录入考核信息</asp:LinkButton>
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
    
    
    <%--给分模块--%>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel2" runat="server" Visible="false">
                <fieldset>
                    <legend>录入考核信息</legend>
                    <table style="width: 100%;">
                        <tr>
                           <td style="width: 15%; height: 15px;" align="center"></td>
                            <td style="width: 10%; height: 15px;" align="right">
                                <asp:Label ID="Label3" runat="server" Text="员工编号："></asp:Label>                            
                                <asp:Label ID="LabelDetail" runat="server" Text="" Visible="false"></asp:Label>
                            </td>
                            <td style="width: 15%; height: 15px;">
                                <asp:TextBox ID="TxtItem1" runat="server" Width="120px" Enabled="False"></asp:TextBox>
                            </td>
                            <td style="width: 15%; height: 15px;" align="right">
                                <asp:Label ID="Label4" runat="server" Text="姓名："></asp:Label>
                            </td>
                            <td style="width: 15%; height: 15px;">
                                <asp:TextBox ID="TxtItem2" runat="server" Width="120px" Enabled="False"></asp:TextBox>
                            </td>
                            <td ></td>
                            <tr style="height: 16px;">
                            <td style="width: 15%; height: 15px;" align="center"></td>
                            <td style="width: 10%; height: 15px;" align="right">
                                <asp:Label ID="LblSPerson" runat="server" Text="考核人："></asp:Label>
                            </td>
                            <td style="width: 15%; height: 20%;" align="left">
                                <asp:TextBox ID="CheckPerson" runat="server" Width="120px" Enabled="false"></asp:TextBox>
                            </td>
                            <td style="width: 15%" align="right">
                                <asp:Label ID="LblSStartTime" runat="server" Text="考核时间："></asp:Label>
                            </td>
                            <td style="width: 15%; height: 20%;" align="left" >
                                <asp:TextBox ID="TxtCheckTime" runat="server" Width="120px" Enabled="false" onfocus="new  WdatePicker(this,'%Y-%M-%D %h:%m:%s',true)"></asp:TextBox>
                            </td>
                            <td ></td>
                        </tr>
                        </tr>            
                       
                    </table>
                    <fieldset>
                    <legend>考核项目列表</legend>
                    <asp:GridView ID="GridView2" runat="server" AllowSorting="True" DataKeyNames="HRPI_ItemID"
                                        AutoGenerateColumns="False" CssClass="GridViewStyle" Width="100%"
                                         GridLines="None" OnRowCommand="Grid_Detail_RowCommand"
                                        OnDataBound="GridView2_DataBound" OnPageIndexChanging="GridView2_PageIndexChanging">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />

                        <Columns>
                            <asp:BoundField DataField="HRPI_ItemID" HeaderText="考核项目ID" ReadOnly="True" SortExpression="HRPI_ItemID">
                             <FooterStyle CssClass="hidden" />
                             <HeaderStyle CssClass="hidden" />
                             <ItemStyle CssClass="hidden" />
                            </asp:BoundField>
                            <asp:BoundField DataField="HRPI_Items" HeaderText="考核项目" SortExpression="HRPI_Items">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="HRPI_Contents" HeaderText="考核内容" SortExpression="HRPI_Contents">
                                <ItemStyle />
                            </asp:BoundField> 
                            <asp:BoundField DataField="HRPI_StanScore" HeaderText="标准得分" SortExpression="HRPI_StanScore">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="HRPI_AssStandard" HeaderText="考核标准" SortExpression="HRPI_AssStandard">
                                <ItemStyle />
                            </asp:BoundField> 
                            <asp:BoundField DataField="HRPI_Remarks" HeaderText="备注" SortExpression="HRPI_Remarks">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="该项目得分">
                              <ItemTemplate>
                                 <asp:TextBox ID="TxtRemarks" runat="server" Width="100%" MaxLength="2" onkeyup="this.value=this.value.replace(/[^\d{1,2}]/g,'')" onafterpaste="this.value=this.value.replace(/[^\d{1,2}]/g,'')"></asp:TextBox>
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
                                                        <asp:TextBox ID="textbox222" runat="server" Width="20px"></asp:TextBox>
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
                    <table style="width: 100%;">
                      
                        <tr>
                            <td ></td>
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
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="DdlSearchDep" />
        </Triggers>
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
                                            <asp:BoundField DataField="HRPD_AState" HeaderText="录入状态" SortExpression="HRPD_AState">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRPD_FinalScore" HeaderText="录入成绩" SortExpression="HRPD_FinalScore">
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
                                                        <asp:TextBox ID="textbox333" runat="server" Width="20px"></asp:TextBox>
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
