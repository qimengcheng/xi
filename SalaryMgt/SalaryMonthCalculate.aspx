<%@ Page Title="薪资月度结算" Language="C#" MasterPageFile="~/Other/MasterPage.master"
    AutoEventWireup="true" CodeFile="SalaryMonthCalculate.aspx.cs" Inherits="SalaryMgt_SalaryMonthCalculate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
    <script language="javascript" type="text/javascript">
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel6" runat="server">
                <fieldset>
                    <legend>检索栏</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label26" runat="server" CssClass="STYLE2" Text="开始日期："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 20%;" align="left">
                                <asp:TextBox ID="TextBox6" runat="server" Width="130px" onfocus="new  WdatePicker(this,'%Y-%M-%D',false)"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label27" runat="server" CssClass="STYLE2" Text="截止日期："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 20%;" align="left">
                                <asp:TextBox ID="TextBox7" runat="server" Width="130px" onfocus="new  WdatePicker(this,'%Y-%M-%D',false)"></asp:TextBox>
                            </td>
                            <td style="width: 20%">
                                <asp:Label ID="Label28" runat="server" Text="年份："></asp:Label>
                                <asp:DropDownList ID="DropDownList4" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 20%">
                                <asp:Label ID="Label29" runat="server" Text="月份："></asp:Label>
                                <asp:DropDownList ID="DropDownList5" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td align="center">
                                <asp:Label ID="Label25" runat="server" Text="状态："></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownList7" runat="server">
                                    <asp:ListItem>请选择</asp:ListItem>
                                    <asp:ListItem>待提交</asp:ListItem>
                                    <asp:ListItem>待审核</asp:ListItem>
                                    <asp:ListItem>已完成</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" align="right" style="height: 15px">
                                <asp:Label ID="someinput" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Label ID="LblRecordIsSearch" runat="server" Text="检索前" Visible="false"></asp:Label>
                                <asp:Button ID="BtnSearch" runat="server" CssClass="Button02" Height="24px" Text="检索"
                                    Width="70px" OnClick="BtnSearch_Click" />
                            </td>
                            <td align="center" style="height: 15px">
                                <asp:Button ID="Button1" runat="server" CssClass="Button02" Height="24px" Text="新增月度结算"
                                    Width="110px" OnClick="Button1_Click" />
                            </td>
                            <td colspan="2" align="left" style="height: 15px">
                                <asp:Button ID="BtnReset" runat="server" CssClass="Button02" Height="24px" Text="重置"
                                    Width="70px" OnClick="BtnReset_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel2" runat="server">
                <fieldset>
                    <legend>月度工资列表</legend>
                    <asp:GridView ID="GridView1" runat="server" AllowSorting="True" DataKeyNames="SMC_ID"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" Width="100%" AllowPaging="True"
                        PageSize="5" GridLines="None" OnPageIndexChanging="GridView1_PageIndexChanging"
                        OnRowCommand="GridView1_RowCommand">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="SMC_ID" HeaderText="薪资月度结算ID" SortExpression="SMC_ID"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMC_Year" HeaderText="年份" SortExpression="SMC_Year">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMC_Month" HeaderText="月份" SortExpression="SMC_Month">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMC_TotalWage" HeaderText="工资总额" SortExpression="SMC_TotalWage"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMC_StartDate" HeaderText="结算开始日期" SortExpression="SMC_StartDate"
                                DataFormatString="{0:yyyy-MM-dd}">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMC_EndDate" HeaderText="结算截止日期" SortExpression="SMC_EndDate"
                                DataFormatString="{0:yyyy-MM-dd}">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMC_State" HeaderText="状态" SortExpression="SMC_State">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMC_AuRes" HeaderText="审核状态" SortExpression="SMC_AuRes">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMC_Auditor" HeaderText="审核人" SortExpression="SMC_Auditor"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMC_AuTime" HeaderText="审核时间" SortExpression="SMC_AuTime"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMC_AuSugg" HeaderText="审核意见" SortExpression="SMC_AuSugg"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMC_Person" HeaderText="结算人" SortExpression="SMC_Person">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMC_Time" HeaderText="结算时间" SortExpression="SMC_Time">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="ChoosePeople" runat="server" CommandName="ChoosePeople" CommandArgument='<%#Eval("SMC_ID")+","+Eval("SMC_Year")+","+Eval("SMC_Month")+","+Eval("SMC_TotalWage")+","+Eval("SMC_StartDate")+","+Eval("SMC_EndDate")+","+Eval("SMC_AuRes")+","+Eval("SMC_State")+","+Eval("SMC_Auditor")+","+Eval("SMC_AuTime")+","+Eval("SMC_AuSugg")+","+Eval("SMC_Person")+","+Eval("SMC_Time")%>'
                                        OnClientClick="false">筛选员工</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="AutoCal" runat="server" CommandName="AutoCal" OnClientClick="false"
                                        CommandArgument='<%#Eval("SMC_ID")+","+Eval("SMC_Year")+","+Eval("SMC_Month")+","+Eval("SMC_TotalWage")+","+Eval("SMC_StartDate")+","+Eval("SMC_EndDate")+","+Eval("SMC_AuRes")+","+Eval("SMC_State")+","+Eval("SMC_Auditor")+","+Eval("SMC_AuTime")+","+Eval("SMC_AuSugg")+","+Eval("SMC_Person")+","+Eval("SMC_Time")%>'>初步结算</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="ExcelOperation" runat="server" CommandName="Excel" OnClientClick="false"
                                        CommandArgument='<%#Eval("SMC_ID")+","+Eval("SMC_Year")+","+Eval("SMC_Month")+","+Eval("SMC_TotalWage")+","+Eval("SMC_StartDate")+","+Eval("SMC_EndDate")+","+Eval("SMC_AuRes")+","+Eval("SMC_State")+","+Eval("SMC_Auditor")+","+Eval("SMC_AuTime")+","+Eval("SMC_AuSugg")+","+Eval("SMC_Person")+","+Eval("SMC_Time")%>'>Excel结算</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="EditDetail1" runat="server" CommandName="EditDetail1" OnClientClick="false"
                                        CommandArgument='<%#Eval("SMC_ID")+","+Eval("SMC_Year")+","+Eval("SMC_Month")+","+Eval("SMC_TotalWage")+","+Eval("SMC_StartDate")+","+Eval("SMC_EndDate")+","+Eval("SMC_AuRes")+","+Eval("SMC_State")+","+Eval("SMC_Auditor")+","+Eval("SMC_AuTime")+","+Eval("SMC_AuSugg")+","+Eval("SMC_Person")+","+Eval("SMC_Time")%>'>最终结算</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnLookWageDetail" runat="server" CommandName="LookWageDetail"
                                        CommandArgument='<%#Eval("SMC_ID")+","+Eval("SMC_Year")+","+Eval("SMC_Month")+","+Eval("SMC_TotalWage")+","+Eval("SMC_StartDate")+","+Eval("SMC_EndDate")+","+Eval("SMC_AuRes")+","+Eval("SMC_State")+","+Eval("SMC_Auditor")+","+Eval("SMC_AuTime")+","+Eval("SMC_AuSugg")+","+Eval("SMC_Person")+","+Eval("SMC_Time")%>'
                                        OnClientClick="false">查看初步结算</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnFinalWageDetail" runat="server" CommandName="FinalWageDetail"
                                        CommandArgument='<%#Eval("SMC_ID")+","+Eval("SMC_Year")+","+Eval("SMC_Month")+","+Eval("SMC_TotalWage")+","+Eval("SMC_StartDate")+","+Eval("SMC_EndDate")+","+Eval("SMC_AuRes")+","+Eval("SMC_State")+","+Eval("SMC_Auditor")+","+Eval("SMC_AuTime")+","+Eval("SMC_AuSugg")+","+Eval("SMC_Person")+","+Eval("SMC_Time")%>'
                                        OnClientClick="false">EXCEL详情</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="TongJi" runat="server" CommandName="TongJi" CommandArgument='<%#Eval("SMC_ID")+","+Eval("SMC_Year")+","+Eval("SMC_Month")+","+Eval("SMC_TotalWage")+","+Eval("SMC_StartDate")+","+Eval("SMC_EndDate")+","+Eval("SMC_AuRes")+","+Eval("SMC_State")+","+Eval("SMC_Auditor")+","+Eval("SMC_AuTime")+","+Eval("SMC_AuSugg")+","+Eval("SMC_Person")+","+Eval("SMC_Time")%>'
                                        OnClientClick="false">多维统计</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnSubmit" runat="server" CommandName="submitForShenhe" CommandArgument='<%#Eval("SMC_ID")+","+Eval("SMC_Year")+","+Eval("SMC_Month")+","+Eval("SMC_TotalWage")+","+Eval("SMC_StartDate")+","+Eval("SMC_EndDate")+","+Eval("SMC_AuRes")+","+Eval("SMC_State")+","+Eval("SMC_Auditor")+","+Eval("SMC_AuTime")+","+Eval("SMC_AuSugg")+","+Eval("SMC_Person")+","+Eval("SMC_Time")%>'
                                        OnClientClick="false">提交审核</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnLookDetail" runat="server" CommandName="LookDetail" CommandArgument='<%#Eval("SMC_ID")+","+Eval("SMC_Year")+","+Eval("SMC_Month")+","+Eval("SMC_TotalWage")+","+Eval("SMC_StartDate")+","+Eval("SMC_EndDate")+","+Eval("SMC_AuRes")+","+Eval("SMC_State")+","+Eval("SMC_Auditor")+","+Eval("SMC_AuTime")+","+Eval("SMC_AuSugg")+","+Eval("SMC_Person")+","+Eval("SMC_Time")%>'
                                        OnClientClick="false">查看审核</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnShenHe" runat="server" CommandName="ShenHe" CommandArgument='<%#Eval("SMC_ID")+","+Eval("SMC_Year")+","+Eval("SMC_Month")+","+Eval("SMC_TotalWage")+","+Eval("SMC_StartDate")+","+Eval("SMC_EndDate")+","+Eval("SMC_AuRes")+","+Eval("SMC_State")+","+Eval("SMC_Auditor")+","+Eval("SMC_AuTime")+","+Eval("SMC_AuSugg")+","+Eval("SMC_Person")+","+Eval("SMC_Time")%>'
                                        OnClientClick="false">审核</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnDelete_Set" runat="server" CommandName="Delete_Set" OnClientClick="return confirm('您确认删除该记录吗?')"
                                        CommandArgument='<%#Eval("SMC_ID")+","+Eval("SMC_Year")+","+Eval("SMC_Month")+","+Eval("SMC_TotalWage")+","+Eval("SMC_StartDate")+","+Eval("SMC_EndDate")+","+Eval("SMC_AuRes")+","+Eval("SMC_State")+","+Eval("SMC_Auditor")+","+Eval("SMC_AuTime")+","+Eval("SMC_AuSugg")+","+Eval("SMC_Person")+","+Eval("SMC_Time")%>'>删除</asp:LinkButton>
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
                                        <asp:TextBox ID="textbox" runat="server" Width="20px"></asp:TextBox>
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
            </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="GridView1" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" Visible="false">
                <fieldset>
                    <legend>月度工资结算选择栏&nbsp<asp:Label ID="Label19" runat="server" Text="<请确保需要进行计算的员工已拥有账套并且已经给出了绩效成绩!>"
                        ForeColor="Red"></asp:Label></legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="LblDate" runat="server" CssClass="STYLE2" Text="开始日期："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 20%;" align="left">
                                <asp:TextBox ID="TxtStartDate" runat="server" Width="130px" onfocus="new  WdatePicker(this,'%Y-%M-%D',false)"></asp:TextBox>
                                <asp:Label ID="Label31" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label1" runat="server" CssClass="STYLE2" Text="截止日期："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 20%;" align="left">
                                <asp:TextBox ID="TextBox1" runat="server" Width="130px" onfocus="new  WdatePicker(this,'%Y-%M-%D',false)"></asp:TextBox>
                                <asp:Label ID="Label32" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:Label ID="Label17" runat="server" Text="选择年份："></asp:Label>
                                <asp:DropDownList ID="DropDownList1" runat="server">
                                </asp:DropDownList>
                                <asp:Label ID="Label33" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:Label ID="Label18" runat="server" Text="选择月份："></asp:Label>
                                <asp:DropDownList ID="DropDownList2" runat="server">
                                </asp:DropDownList>
                                <asp:Label ID="Label34" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td align="center">
                            </td>
                            <td align="center">
                                <asp:Button ID="Button3" runat="server" CssClass="Button02" Height="24px" Text="检索账套外员工"
                                    Width="100px" OnClick="Button3_Click" />
                            </td>
                            <td style="width: 20%; height: 20%;" colspan="2" align="center">
                                <asp:Button ID="Button4" runat="server" CssClass="Button02" Height="24px" Text="检索未打绩效成绩员工"
                                    Width="140px" OnClick="Button4_Click" />
                            </td>
                            <td align="left">
                                <asp:Button ID="BtnMonthCalculate" runat="server" CssClass="Button02" Height="24px"
                                    Text="提交" Width="70px" OnClick="BtnMonthCalculate_Click" />
                            </td>
                            <td align="left">
                                <asp:Button ID="Button2" runat="server" CssClass="Button02" Height="24px" Text="关闭"
                                    Width="70px" OnClick="Button2_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel10" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:PostBackTrigger ControlID="ButtonToExcel" />
            <asp:PostBackTrigger ControlID="ButtonFromExcel" />
        </Triggers>
        <ContentTemplate>
            <asp:Panel ID="Panel10" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="Label68" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="Label66" runat="server" Text=""></asp:Label>年<asp:Label ID="Label67"
                            runat="server" Text=""></asp:Label>月工资表操作</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 20%" align="center">
                                <asp:Label ID="Label73" runat="server" Visible="False"></asp:Label>
                                <asp:Button ID="ButtonToExcel" runat="server" CssClass="Button02" Height="24px" Text="EXCEL导出"
                                    Width="70px" OnClick="ButtonToExcel_Click" />
                            </td>
                            <td style="width: 40%" align="center">
                                <asp:FileUpload ID="FileUpload" runat="server" />
                                <asp:Button ID="ButtonFromExcel" runat="server" CssClass="Button02" Height="24px"
                                    Text="EXCEL导入" Width="70px" OnClick="ButtonFromExcel_Click" />
                            </td>
                            <td style="width: 20%" align="center">
                                <asp:Button ID="ButtonDeleteSalary" runat="server" CssClass="Button02" Height="24px"
                                    Width="130px" Text="删除" OnClick="ButtonDeleteSalary_Click" />
                            </td>
                            <td style="width: 20%" align="center">
                                <asp:Button ID="Button20" runat="server" Width="70px" Text="关闭" Height="24px" CssClass="Button02"
                                    OnClick="Button20_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%" colspan="4" align="center">
                                <asp:Label ID="LblMessage" runat="server" Visible="False" ForeColor="#FF0066"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel8" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="LblYear" runat="server" Text=""></asp:Label>年<asp:Label ID="LblMonth"
                            runat="server" Text=""></asp:Label>月，于<asp:Label ID="LblTime" runat="server" Text=""></asp:Label>进行结算&nbsp
                        员工信息栏</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label49" runat="server" CssClass="STYLE2" Text="工号：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TextBox15" runat="server" Width="110px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label50" runat="server" CssClass="STYLE2" Text="姓名：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TextBox16" runat="server" Width="110px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label51" runat="server" CssClass="STYLE2" Text="部门：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TextBox17" runat="server" Width="110px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label52" runat="server" CssClass="STYLE2" Text="岗位：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TextBox18" runat="server" Width="110px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" align="right">
                                <asp:Label ID="LblIsSearch" runat="server" Text="检索前" Visible="false"></asp:Label>
                                <asp:Label ID="Label53" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Label ID="conditionpeople" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Button ID="Button10" runat="server" CssClass="Button02" Height="24px" Text="检索"
                                    Width="70px" OnClick="Button10_Click" />
                            </td>
                            <td colspan="2" align="center">
                                <asp:Button ID="Button13" runat="server" CssClass="Button02" Height="24px" Text="新增员工"
                                    Width="70px" OnClick="Button13_Click" />
                            </td>
                            <td colspan="3" align="left">
                                <asp:Button ID="Button11" runat="server" CssClass="Button02" Height="24px" Width="70px"
                                    Text="重置" OnClick="Button11_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="8">
                                <fieldset>
                                    <legend>当次待结算的员工列表</legend>
                                    <asp:GridView ID="GridView5" runat="server" DataKeyNames="HRDD_ID" AllowSorting="True"
                                        AutoGenerateColumns="False" CssClass="GridViewStyle" Width="100%" AllowPaging="True"
                                        PageSize="20" GridLines="None" OnPageIndexChanging="GridView5_PageIndexChanging"
                                        OnRowCommand="GridView5_RowCommand">
                                        <RowStyle CssClass="GridViewRowStyle" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                        <HeaderStyle CssClass="GridViewHead" />
                                        <FooterStyle CssClass="GridViewFooterStyle" />
                                        <Columns>
                                            <asp:BoundField DataField="SDBT_ID" HeaderText="详情ID" SortExpression="SDBT_ID" Visible="false">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRDD_ID" HeaderText="人事档案ID" SortExpression="HRDD_ID"
                                                Visible="false">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRDD_StaffNO" HeaderText="工号" SortExpression="HRDD_StaffNO">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRDD_Name" HeaderText="姓名" SortExpression="HRDD_Name">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SDBT_Dep" HeaderText="部门" SortExpression="SDBT_Dep">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SDBT_Post" HeaderText="岗位" SortExpression="SDBT_Post">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbtnDelete_Detail" runat="server" CommandName="Delete_Detail"
                                                        OnClientClick="return confirm('您确认删除该记录吗?')" CommandArgument='<%#Eval("SDBT_ID")%>'>删除</asp:LinkButton>
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
                                                        <asp:TextBox ID="textbox" runat="server" Width="20px"></asp:TextBox>
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
                            <td colspan="8" align="center">
                                <asp:Button ID="Button12" runat="server" Width="70px" Text="关闭" Height="24px" CssClass="Button02"
                                    OnClick="Button12_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel9" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel9" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="Label54" runat="server" Text=""></asp:Label>年<asp:Label ID="Label64"
                            runat="server" Text=""></asp:Label>月，于<asp:Label ID="Label65" runat="server" Text=""></asp:Label>结算&nbsp
                        员工新增</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label55" runat="server" CssClass="STYLE2" Text="工号：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TextBox19" runat="server" Width="110px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label56" runat="server" CssClass="STYLE2" Text="姓名：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TextBox20" runat="server" Width="110px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label57" runat="server" CssClass="STYLE2" Text="部门：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TextBox21" runat="server" Width="110px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label58" runat="server" CssClass="STYLE2" Text="岗位：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TextBox22" runat="server" Width="110px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label61" runat="server" CssClass="STYLE2" Text="是否离职："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:DropDownList ID="DropDownList6" runat="server">
                                    <asp:ListItem>全部</asp:ListItem>
                                    <asp:ListItem>是</asp:ListItem>
                                    <asp:ListItem>否</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label62" runat="server" CssClass="STYLE2" Text="离职从："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 20%;" align="left">
                                <asp:TextBox ID="TextBox23" runat="server" Width="110px" onfocus="new  WdatePicker(this,'%Y-%M-%D',false)"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label63" runat="server" CssClass="STYLE2" Text="至："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 20%;" align="left">
                                <asp:TextBox ID="TextBox24" runat="server" Width="110px" onfocus="new  WdatePicker(this,'%Y-%M-%D',false)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" align="right">
                                <asp:Label ID="Label59" runat="server" Text="检索前" Visible="false"></asp:Label>
                                <asp:Label ID="Label60" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Label ID="LblCondition" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Button ID="Button14" runat="server" CssClass="Button02" Height="24px" Text="检索"
                                    Width="70px" OnClick="Button14_Click" />
                            </td>
                            <td colspan="2" align="center">
                            </td>
                            <td colspan="3" align="left">
                                <asp:Button ID="Button16" runat="server" CssClass="Button02" Height="24px" Width="70px"
                                    Text="重置" OnClick="Button16_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="8">
                                <fieldset>
                                    <legend>未参与当月结算的员工列表</legend>
                                    <asp:GridView ID="GridView6" runat="server" DataKeyNames="HRDD_ID" AllowSorting="True"
                                        AutoGenerateColumns="False" CssClass="GridViewStyle" Width="100%" AllowPaging="True"
                                        PageSize="20" GridLines="None" OnPageIndexChanging="GridView6_PageIndexChanging"
                                        OnRowCommand="GridView6_RowCommand">
                                        <RowStyle CssClass="GridViewRowStyle" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                        <HeaderStyle CssClass="GridViewHead" />
                                        <FooterStyle CssClass="GridViewFooterStyle" />
                                        <Columns>
                                            <asp:BoundField DataField="HRDD_ID" HeaderText="人事档案ID" SortExpression="HRDD_ID"
                                                Visible="false">
                                                <ItemStyle />
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
                                            <asp:BoundField DataField="HRDD_QuitTime" HeaderText="离职时间" SortExpression="HRDD_QuitTime">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <%--<asp:LinkButton ID="ChoosePeople" runat="server" CommandName="ChoosePeople" CommandArgument='<%#Eval("SMC_ID")+","+Eval("SMC_Year")+","+Eval("SMC_Month")+","+Eval("SMC_TotalWage")+","+Eval("SMC_StartDate")+","+Eval("SMC_EndDate")+","+Eval("SMC_AuRes")+","+Eval("SMC_State")+","+Eval("SMC_Auditor")+","+Eval("SMC_AuTime")+","+Eval("SMC_AuSugg")+","+Eval("SMC_Person")+","+Eval("SMC_Time")%>'
                                        OnClientClick="false">筛选员工</asp:LinkButton>--%>
                                                    <asp:LinkButton ID="lbtnAddPerson" runat="server" CommandName="AddPerson" OnClientClick="false"
                                                        CommandArgument='<%#Eval("HRDD_ID")+","+Eval("BDOS_Name")+","+Eval("HRP_Post")%>'>选择</asp:LinkButton>
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
                                                        <asp:TextBox ID="textbox" runat="server" Width="20px"></asp:TextBox>
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
                            <td colspan="8" align="center">
                                <asp:Button ID="Button17" runat="server" Width="70px" Text="关闭" Height="24px" CssClass="Button02"
                                    OnClick="Button17_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_SearchEmployee" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_SearchEmployee" runat="server" Visible="false">
                <fieldset>
                    <legend>账套外的员工信息栏</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label35" runat="server" CssClass="STYLE2" Text="工号：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TxtSearchStaffNO" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label36" runat="server" CssClass="STYLE2" Text="姓名：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TxtSearchName" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                            </td>
                            <td style="width: 15%" align="left">
                            </td>
                            <td style="width: 10%" align="center">
                            </td>
                            <td style="width: 15%" align="left">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" align="right">
                                <asp:Label ID="LblBindSAS_ASID" runat="server" Text="检索前" Visible="false"></asp:Label>
                                <asp:Button ID="BtnSearchEmployee" runat="server" CssClass="Button02" Height="24px"
                                    Text="检索" Width="70px" OnClick="BtnSearchEmployee_Click" />
                            </td>
                            <td colspan="2" align="center">
                            </td>
                            <td colspan="3" align="left">
                                <asp:Button ID="BtnResetEmployee" runat="server" CssClass="Button02" Height="24px"
                                    Width="70px" Text="重置" OnClick="BtnResetEmployee_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="8">
                                <fieldset>
                                    <legend>账套外的员工的列表</legend>
                                    <asp:GridView ID="Grid_Detail" runat="server" DataKeyNames="HRDD_ID" AllowSorting="True"
                                        AutoGenerateColumns="False" CssClass="GridViewStyle" Width="100%" AllowPaging="True"
                                        PageSize="5" GridLines="None" OnPageIndexChanging="Grid_Detail_PageIndexChanging">
                                        <RowStyle CssClass="GridViewRowStyle" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                        <HeaderStyle CssClass="GridViewHead" />
                                        <FooterStyle CssClass="GridViewFooterStyle" />
                                        <Columns>
                                            <asp:BoundField DataField="HRDD_ID" HeaderText="人事档案ID" SortExpression="HRDD_ID"
                                                Visible="false">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRDD_StaffNO" HeaderText="工号" SortExpression="HRDD_StaffNO">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRDD_Name" HeaderText="姓名" SortExpression="HRDD_Name">
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
                                                        <asp:TextBox ID="textbox" runat="server" Width="20px"></asp:TextBox>
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
                            <td colspan="8" align="center">
                                <asp:Button ID="BtnClosePanel_SearchEmployee" runat="server" Width="70px" Text="关闭"
                                    Height="24px" CssClass="Button02" OnClick="BtnClosePanel_SearchEmployee_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel7" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="Label40" runat="server" Text=""></asp:Label><asp:Label ID="Label41"
                            runat="server" Text=""></asp:Label>账套中的未出绩效成绩的员工信息栏</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label37" runat="server" CssClass="STYLE2" Text="工号："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TextBox8" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label38" runat="server" CssClass="STYLE2" Text="姓名："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TextBox9" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label42" runat="server" CssClass="STYLE2" Text="考核类型："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TextBox10" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label43" runat="server" CssClass="STYLE2" Text="考核人："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TextBox11" runat="server" Width="130px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label44" runat="server" CssClass="STYLE2" Text="审核人："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TextBox12" runat="server" Width="130px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" align="right">
                                <asp:Label ID="Label39" runat="server" Text="检索前" Visible="false"></asp:Label>
                                <asp:Button ID="Button5" runat="server" CssClass="Button02" Height="24px" Text="检索"
                                    Width="70px" OnClick="Button5_Click" />
                            </td>
                            <td colspan="2" align="center">
                            </td>
                            <td colspan="3" align="left">
                                <asp:Button ID="Button6" runat="server" CssClass="Button02" Height="24px" Width="70px"
                                    Text="重置" OnClick="Button6_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="8">
                                <fieldset>
                                    <legend>当月没有绩效成绩的员工列表</legend>
                                    <asp:GridView ID="GridView4" runat="server" DataKeyNames="HRDD_ID" AllowSorting="True"
                                        AutoGenerateColumns="False" CssClass="GridViewStyle" Width="100%" AllowPaging="True"
                                        PageSize="5" GridLines="None" OnPageIndexChanging="GridView4_PageIndexChanging">
                                        <RowStyle CssClass="GridViewRowStyle" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                        <HeaderStyle CssClass="GridViewHead" />
                                        <FooterStyle CssClass="GridViewFooterStyle" />
                                        <Columns>
                                            <asp:BoundField DataField="HRDD_ID" HeaderText="人事档案ID" SortExpression="HRDD_ID"
                                                Visible="false">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRDD_StaffNO" HeaderText="工号" SortExpression="HRDD_StaffNO">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRDD_Name" HeaderText="姓名" SortExpression="HRDD_Name">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRPAT_PType" HeaderText="绩效考核类型" SortExpression="HRPAT_PType">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRPAT_AAPerson" HeaderText="考核人" SortExpression="HRPAT_AAPerson">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRPAT_CCPerson" HeaderText="审核人" SortExpression="HRPAT_CCPerson">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRPD_M_Score" HeaderText="是否需要总经理打分" SortExpression="HRPD_M_Score">
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
                                                        <asp:TextBox ID="textbox" runat="server" Width="20px"></asp:TextBox>
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
                            <td colspan="8" align="center">
                                <asp:Button ID="Button7" runat="server" Width="70px" Text="关闭" Height="24px" CssClass="Button02"
                                    OnClick="Button7_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel3" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="Label4" runat="server" Text=""></asp:Label>年<asp:Label ID="Label5"
                            runat="server" Text=""></asp:Label>月 系统初步结算结果</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 10%; height: 16px;" align="center">
                                <asp:Label ID="Label45" runat="server" CssClass="STYLE2" Text="工号：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%; height: 16px;" align="left">
                                <asp:TextBox ID="TextBox13" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%; height: 16px;" align="center">
                                <asp:Label ID="Label47" runat="server" CssClass="STYLE2" Text="姓名：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%; height: 16px;" align="left">
                                <asp:TextBox ID="TextBox14" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%; height: 16px;" align="center">
                            </td>
                            <td style="width: 15%; height: 16px;" align="left">
                            </td>
                            <td style="width: 10%; height: 16px;" align="center">
                            </td>
                            <td style="width: 15%; height: 16px;" align="left">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" align="right">
                                <asp:Label ID="Label48" runat="server" Text="检索前" Visible="false"></asp:Label>
                                <asp:Button ID="Button8" runat="server" CssClass="Button02" Height="24px" Text="检索"
                                    Width="70px" OnClick="Button8_Click" />
                            </td>
                            <td colspan="3" align="right">
                                <asp:Button ID="Button9" runat="server" CssClass="Button02" Height="24px" Width="70px"
                                    Text="重置" OnClick="Button9_Click" />
                            </td>
                        </tr>
                    </table>
                    <fieldset>
                        <legend>当月员工薪资列表</legend>
                        <asp:GridView ID="GridView2" runat="server" DataKeyNames="HRDD_ID" AllowSorting="True"
                            AutoGenerateColumns="False" CssClass="GridViewStyle" Width="100%" AllowPaging="True"
                            PageSize="20" GridLines="None" OnPageIndexChanging="GridView2_PageIndexChanging"
                            OnRowCommand="GridView2_RowCommand">
                            <RowStyle CssClass="GridViewRowStyle" />
                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                            <HeaderStyle CssClass="GridViewHead" />
                            <FooterStyle CssClass="GridViewFooterStyle" />
                            <Columns>
                                <asp:BoundField DataField="HRDD_ID" HeaderText="人员ID" SortExpression="HRDD_ID" Visible="false">
                                    <ItemStyle />
                                </asp:BoundField>
                                <asp:BoundField DataField="HRDD_StaffNO" HeaderText="员工编号" SortExpression="HRDD_StaffNO">
                                    <ItemStyle />
                                </asp:BoundField>
                                <asp:BoundField DataField="HRDD_Name" HeaderText="员工姓名" SortExpression="HRDD_Name">
                                    <ItemStyle />
                                </asp:BoundField>
                                <asp:BoundField DataField="MonthWageForEachPerson" HeaderText="工资总额" SortExpression="MonthWageForEachPerson">
                                    <ItemStyle />
                                </asp:BoundField>
                                <%--<asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnEditDetail2" runat="server" CommandArgument='<%#Eval("HRDD_ID")%>'
                                        CommandName="EditDetail2"  OnClientClick="false">编辑详情</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnSearchDetail" runat="server" CommandArgument='<%#Eval("HRDD_ID")%>'
                                        CommandName="SearchDetail"  OnClientClick="false">查看详情</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>--%>
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
                                            <asp:TextBox ID="textbox" runat="server" Width="20px"></asp:TextBox>
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
                    <table width="100%">
                        <tr>
                            <td colspan="6" align="center">
                                <asp:Label ID="Label30" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Button ID="BtnClosePanel3" runat="server" Width="70px" Text="关闭" Height="24px"
                                    CssClass="Button02" OnClick="BtnClosePanel3_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel4" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="Label9" runat="server" Text=""></asp:Label>&nbsp工资项目列表<asp:Label ID="Label10"
                            runat="server" Text="" Visible="false"></asp:Label></legend>
                    <asp:GridView ID="GridView3" runat="server" DataKeyNames="SEWD_ID" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                        AllowPaging="True" PageSize="20" Font-Strikeout="False" UseAccessibleHeader="False"
                        GridLines="None" OnPageIndexChanging="GridView3_PageIndexChanging" OnRowCommand="GridView3_RowCommand">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="SEWD_ID" HeaderText="工资详情ID" ReadOnly="True" SortExpression="SEWD_ID"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SEWD_Item" HeaderText="工资项目" SortExpression="SEWD_Item">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SEWD_ItemWage" HeaderText="本月值" SortExpression="SEWD_ItemWage">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnEdit_Item" runat="server" CommandArgument='<%#Eval("SEWD_ID")%>'
                                        CommandName="Edit_Item" OnClientClick="false">编辑</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第&nbsp<asp:Label ID="lblPageIndex" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>' />
                                        页 共&nbsp<asp:Label ID="lblPageCount" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />
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
                        <EmptyDataTemplate>
                            <asp:Label ID="Label16" runat="server" Text="没有找到相关记录"></asp:Label>
                        </EmptyDataTemplate>
                        <EditRowStyle BackColor="white" />
                    </asp:GridView>
                    <table width="100%">
                        <tr>
                            <td colspan="6" align="center">
                                <asp:Button ID="BtnClosePanel4" runat="server" Width="70px" Text="关闭" CssClass="Button02"
                                    Height="24px" OnClick="BtnClosePanel4_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel5" runat="server" Visible="false">
                <fieldset>
                    <legend>工资项目月度值编辑</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td colspan="6" align="center">
                                <asp:Label ID="Label13" runat="server" Text="您的操作可能引起其他工资项的变动，请谨慎！" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label14" runat="server" CssClass="STYLE2" Text="工资项目："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 20%;" align="left">
                                <asp:TextBox ID="TextBox3" runat="server" Width="130px" Enabled="false"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label15" runat="server" CssClass="STYLE2" Text="本月值："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 20%;" align="left">
                                <asp:TextBox ID="TextBox4" runat="server" Width="130px" MaxLength="16" onkeyup="this.value=this.value.replace(/[^-?\d+((\.)\d{1,2})?$]/g,'')"
                                    onafterpaste="this.value=this.value.replace(/[^-?\d+((\.)\d{1,2})?$]/g,'')"></asp:TextBox>
                                <asp:Label ID="Label20" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*"
                                    ControlToValidate="TextBox4" ValidationGroup="Shen"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:Label ID="Label12" runat="server" CssClass="STYLE2" Text="最多只保留两位小数" ForeColor="Red"></asp:Label>
                            </td>
                            <td style="width: 10%" align="center">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="right">
                                <asp:Label ID="Label21" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Button ID="ButtonSubmitForEdit" runat="server" Text="提交" CssClass="Button02"
                                    Height="24px" Width="70px" ValidationGroup="Shen" OnClick="ButtonSubmitForEdit_Click" />
                            </td>
                            <td colspan="2" align="center">
                            </td>
                            <td colspan="2" align="left">
                                <asp:Button ID="ButtonCancelForEdit" runat="server" Text="关闭" CssClass="Button02"
                                    Height="24px" Visible="true" Width="70px" OnClick="ButtonCancelForEdit_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanelDetail" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="PanelDetail" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="Label75" runat="server" Text=""></asp:Label>年<asp:Label ID="Label76"
                            runat="server" Text=""></asp:Label>月&nbsp 月度工资EXCEL详情</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label80" runat="server" Text="选择查看的列:"></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox39" runat="server" Text="工龄" />
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox40" runat="server" Text="工时" />
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox41" runat="server" Text="计时工资" />
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox42" runat="server" Text="计件工资" />
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 20%" align="left">
                                <asp:Label ID="Label81" runat="server" Text="" Visible="false"></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox43" runat="server" Text="基本工资" />
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox44" runat="server" Text="全勤工资" />
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox45" runat="server" Text="绩效工资" />
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox46" runat="server" Text="加班工资" />
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 20%" align="left">
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox47" runat="server" Text="工龄工资" />
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox48" runat="server" Text="中班补贴" />
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox49" runat="server" Text="夜班补贴" />
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox50" runat="server" Text="小组长补助" />
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 20%" align="left">
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox51" runat="server" Text="补上月" />
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox52" runat="server" Text="扣膜补贴" />
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox53" runat="server" Text="高温补贴" />
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox54" runat="server" Text="劳保补贴" />
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 20%" align="left">
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox55" runat="server" Text="其他补助" />
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox56" runat="server" Text="有薪假" />
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox57" runat="server" Text="其他应发款项" />
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox58" runat="server" Text="出勤扣款" />
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 20%" align="left">
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox59" runat="server" Text="绩效扣款" />
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox60" runat="server" Text="合格率扣款" />
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox61" runat="server" Text="压塑压坏扣款" />
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox62" runat="server" Text="其他应发款项扣款" />
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 20%" align="left">
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox63" runat="server" Text="养老保险" />
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox64" runat="server" Text="医疗保险" />
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox65" runat="server" Text="失业保险" />
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox66" runat="server" Text="工伤保险" />
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 20%" align="left">
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox67" runat="server" Text="生育保险" />
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox68" runat="server" Text="保险合计" />
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox69" runat="server" Text="住房公积金" />
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox70" runat="server" Text="险金合计" />
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 20%" align="left">
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox71" runat="server" Text="其他应扣款项扣款" />
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox72" runat="server" Text="个人所得税" />
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox73" runat="server" Text="应发工资" />
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox74" runat="server" Text="实发工资" />
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 20%" align="left">
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox75" runat="server" Text="计时+计件" />
                            </td>
                            <td style="width: 20%" align="left">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5">
                                <fieldset>
                                    <legend>检索栏</legend>
                                    <table border="0" cellspacing="1" width="100%" style="text-align: center">
                                        <tr style="height: 16px;">
                                            <td style="width: 10%" align="center">
                                                <asp:Label ID="Label79" runat="server" CssClass="STYLE2" Text="工号："></asp:Label>
                                            </td>
                                            <td style="width: 20%; height: 20%;" align="left">
                                                <asp:TextBox ID="TextBox25" runat="server" Width="130px"></asp:TextBox>
                                            </td>
                                            <td style="width: 10%" align="center">
                                                <asp:Label ID="Label77" runat="server" CssClass="STYLE2" Text="姓名："></asp:Label>
                                            </td>
                                            <td style="width: 20%; height: 20%;" align="left">
                                                <asp:TextBox ID="TextBox26" runat="server" Width="130px"></asp:TextBox>
                                            </td>
                                            <td style="width: 10%" align="center">
                                                <asp:Label ID="Label84" runat="server" Text="部门："></asp:Label>
                                            </td>
                                            <td style="width: 20%; height: 20%;" align="left">
                                                <asp:TextBox ID="TextBox27" runat="server" Width="130px"></asp:TextBox>
                                            </td>
                                            <td style="width: 10%" align="center">
                                                <asp:Label ID="Label85" runat="server" Text="岗位："></asp:Label>
                                            </td>
                                            <td style="width: 20%; height: 20%;" align="left">
                                                <asp:TextBox ID="TextBox28" runat="server" Width="130px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="center" style="height: 15px">
                                                <asp:Label ID="LabelIsSearch" runat="server" Text="检索前" Visible="false"></asp:Label>
                                                <asp:Label ID="LblRecordCondition" runat="server" Text="" Visible="false"></asp:Label>
                                                <asp:Button ID="Button18" runat="server" CssClass="Button02" Height="24px" Text="检索"
                                                    Width="70px" OnClick="Button18_Click" />
                                            </td>
                                            <td colspan="4" align="center" style="height: 15px">
                                                <asp:Button ID="Button19" runat="server" CssClass="Button02" Height="24px" Text="重置"
                                                    Width="70px" OnClick="Button19_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </fieldset>
                            </td>
                        </tr>
                    </table>
                    <fieldset>
                        <legend>EXCEL薪资详情表</legend>
                        <div style="overflow-x: scroll; width: 100%" id="Div1">
                            <asp:GridView ID="GridView8" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle"
                                Width="100%" AllowPaging="True" PageSize="20" GridLines="None" OnPageIndexChanging="GridView8_PageIndexChanging">
                                <RowStyle CssClass="GridViewRowStyle" />
                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                <HeaderStyle CssClass="GridViewHead" />
                                <FooterStyle CssClass="GridViewFooterStyle" />
                                <Columns>
                                    <asp:BoundField DataField="SDBT_NO" HeaderText="工号" SortExpression="SDBT_NO">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_Name" HeaderText="姓名" SortExpression="SDBT_Name">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_Dep" HeaderText="部门" SortExpression="SDBT_Dep">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_Post" HeaderText="岗位" SortExpression="SDBT_Post">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_WorkLength" HeaderText="工龄" SortExpression="SDBT_WorkLength">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_TimeCount" HeaderText="工时" SortExpression="SDBT_TimeCount">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_TWage" HeaderText="计时工资" SortExpression="SDBT_TWage">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_PWage" HeaderText="计件工资" SortExpression="SDBT_PWage">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_Basic" HeaderText="基本工资" SortExpression="SDBT_Basic">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_FullTime" HeaderText="全勤工资" SortExpression="SDBT_FullTime">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_Perform" HeaderText="绩效工资" SortExpression="SDBT_Perform">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_OverTime" HeaderText="加班工资" SortExpression="SDBT_OverTime">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_WorkAge" HeaderText="工龄工资" SortExpression="SDBT_WorkAge">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_MidSchedule" HeaderText="中班补贴" SortExpression="SDBT_MidSchedule">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_NightSchedule" HeaderText="夜班补贴" SortExpression="SDBT_NightSchedule">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_TeamLeader" HeaderText="小组长补助" SortExpression="SDBT_TeamLeader">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_LastMonth" HeaderText="补上月" SortExpression="SDBT_LastMonth">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_KouMo" HeaderText="扣膜补贴" SortExpression="SDBT_KouMo">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_HighTep" HeaderText="高温补贴" SortExpression="SDBT_HighTep">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_Insurance" HeaderText="劳保补贴" SortExpression="SDBT_Insurance">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_OtherSubsidies" HeaderText="其他补助" SortExpression="SDBT_OtherSubsidies">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_PaidVacation" HeaderText="有薪假" SortExpression="SDBT_PaidVacation">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_OtherPaid" HeaderText="其他应发款项" SortExpression="SDBT_OtherPaid">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_AttendancePaidCut" HeaderText="出勤扣款" SortExpression="SDBT_AttendancePaidCut">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_PerfromPaidCut" HeaderText="绩效扣款" SortExpression="SDBT_PerfromPaidCut">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_PassPercentPaidCut" HeaderText="合格率扣款" SortExpression="SDBT_PassPercentPaidCut">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_BadPaidCut" HeaderText="压塑压坏扣款" SortExpression="SDBT_BadPaidCut">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_OtherPaidCut" HeaderText="其他应发款项扣款" SortExpression="SDBT_OtherPaidCut">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_EndowmentInsurance" HeaderText="养老保险" SortExpression="SDBT_EndowmentInsurance">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_MedicalInsurance" HeaderText="医疗保险" SortExpression="SDBT_MedicalInsurance">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_UnemployedInsurance" HeaderText="失业保险" SortExpression="SDBT_UnemployedInsurance">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_InjuryInsurance" HeaderText="工伤保险" SortExpression="SDBT_InjuryInsurance">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_MaternityInsurance" HeaderText="生育保险" SortExpression="SDBT_MaternityInsurance">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_InsuranceTotal" HeaderText="保险合计" SortExpression="SDBT_InsuranceTotal">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_HousingFund" HeaderText="住房公积金" SortExpression="SDBT_HousingFund">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_InsuranceAndFund" HeaderText="险金合计" SortExpression="SDBT_InsuranceAndFund">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_OtherCut" HeaderText="其他应扣款项扣款" SortExpression="SDBT_OtherCut">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_IndividualTax" HeaderText="个人所得税" SortExpression="SDBT_IndividualTax">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_AccruedWages" HeaderText="应发工资" SortExpression="SDBT_AccruedWages">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_RealWages" HeaderText="实发工资" SortExpression="SDBT_RealWages">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TimeandPiece" HeaderText="计时+计件" SortExpression="TimeandPiece">
                                        <ItemStyle />
                                    </asp:BoundField>
                                </Columns>
                                <PagerTemplate>
                                    <table width="100%">
                                        <tr>
                                            <td style="text-align: right">
                                                第&nbsp<asp:Label ID="lblPageIndex" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>' />
                                                页 共&nbsp<asp:Label ID="lblPageCount" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />
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
                                <EmptyDataTemplate>
                                    <asp:Label ID="Label16" runat="server" Text="没有找到相关记录"></asp:Label>
                                </EmptyDataTemplate>
                                <EditRowStyle BackColor="white" />
                            </asp:GridView>
                        </div>
                    </fieldset>
                    <table width="100%">
                        <tr>
                            <td align="center">
                                <asp:Button ID="Button22" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    Visible="true" Width="70px" OnClick="Button22_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePaneltongji" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1tongji" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="Label69" runat="server" Text=""></asp:Label>年<asp:Label ID="Label70"
                            runat="server" Text=""></asp:Label>月&nbsp月度工资多维统计<asp:Label ID="Label78" runat="server"
                                Text="<请选择统计对象并单击按钮选择统计的方式>" ForeColor="#FF0066"></asp:Label></legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 20%; height: 20%;" align="center">
                                <asp:Label ID="Label72" runat="server" Text="统计检索方式:"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                    ControlToValidate="TextBox2" ValidationGroup="ShenHe"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td style="width: 20%" align="center">
                                <asp:Button ID="BtnType" runat="server" Text="员工类型" CssClass="Button02" Height="24px"
                                    Width="70px" OnClick="BtnType_Click" />
                            </td>
                            <td style="width: 20%" align="center">
                                <asp:Button ID="BtnDep" runat="server" Text="部门" CssClass="Button02" Height="24px"
                                    Width="70px" OnClick="BtnDep_Click" />
                            </td>
                            <td style="width: 20%" align="right">
                                <asp:Button ID="BtnPost" runat="server" Text="岗位" CssClass="Button02" Height="24px"
                                    Width="70px" OnClick="BtnPost_Click" />
                                <asp:Label ID="Label82" runat="server" Text="检索岗位:"></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:TextBox ID="TextBox29" runat="server" Width="130px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 20%" align="center">
                                <asp:Label ID="Label71" runat="server" Text="统计对象:"></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox1" runat="server" Text="工龄" />
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox2" runat="server" Text="工时" />
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox3" runat="server" Text="计时工资" />
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox4" runat="server" Text="计件工资" />
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 20%" align="left">
                                <asp:Label ID="Label74" runat="server" Text="" Visible="false"></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox5" runat="server" Text="基本工资" />
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox6" runat="server" Text="全勤工资" />
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox7" runat="server" Text="绩效工资" />
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox8" runat="server" Text="加班工资" />
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 20%" align="left">
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox9" runat="server" Text="工龄工资" />
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox10" runat="server" Text="中班补贴" />
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox11" runat="server" Text="夜班补贴" />
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox12" runat="server" Text="小组长补助" />
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 20%" align="left">
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox13" runat="server" Text="补上月" />
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox14" runat="server" Text="扣膜补贴" />
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox15" runat="server" Text="高温补贴" />
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox16" runat="server" Text="劳保补贴" />
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 20%" align="left">
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox17" runat="server" Text="其他补助" />
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox18" runat="server" Text="有薪假" />
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox19" runat="server" Text="其他应发款项" />
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox20" runat="server" Text="出勤扣款" />
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 20%" align="left">
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox21" runat="server" Text="绩效扣款" />
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox22" runat="server" Text="合格率扣款" />
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox23" runat="server" Text="压塑压坏扣款" />
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox24" runat="server" Text="其他应发款项扣款" />
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 20%" align="left">
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox25" runat="server" Text="养老保险" />
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox26" runat="server" Text="医疗保险" />
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox27" runat="server" Text="失业保险" />
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox28" runat="server" Text="工伤保险" />
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 20%" align="left">
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox29" runat="server" Text="生育保险" />
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox30" runat="server" Text="保险合计" />
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox31" runat="server" Text="住房公积金" />
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox32" runat="server" Text="险金合计" />
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 20%" align="left">
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox33" runat="server" Text="其他应扣款项扣款" />
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox34" runat="server" Text="个人所得税" />
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox35" runat="server" Text="应发工资" />
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox36" runat="server" Text="实发工资" />
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 20%" align="left">
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox37" runat="server" Text="计时+计件" />
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:CheckBox ID="CheckBox38" runat="server" Text="人数" />
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 20%" align="center">
                            </td>
                        </tr>
                    </table>
                    <fieldset>
                        <legend>薪资统计表</legend>
                        <div style="overflow-x: scroll; width: 100%" id="dvBody">
                            <asp:GridView ID="GridView7" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle"
                                Width="100%" AllowPaging="False" GridLines="None">
                                <RowStyle CssClass="GridViewRowStyle" />
                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                <HeaderStyle CssClass="GridViewHead" />
                                <FooterStyle CssClass="GridViewFooterStyle" />
                                <Columns>
                                    <asp:BoundField DataField="theType" HeaderText="统计方式" SortExpression="theType">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_WorkLength" HeaderText="工龄" SortExpression="SDBT_WorkLength">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_WorkLength" HeaderText="工时" SortExpression="SDBT_WorkLength">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_TWage" HeaderText="计时工资" SortExpression="SDBT_TWage">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_PWage" HeaderText="计件工资" SortExpression="SDBT_PWage">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_Basic" HeaderText="基本工资" SortExpression="SDBT_Basic">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_FullTime" HeaderText="全勤工资" SortExpression="SDBT_FullTime">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_Perform" HeaderText="绩效工资" SortExpression="SDBT_Perform">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_OverTime" HeaderText="加班工资" SortExpression="SDBT_OverTime">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_WorkAge" HeaderText="工龄工资" SortExpression="SDBT_WorkAge">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_MidSchedule" HeaderText="中班补贴" SortExpression="SDBT_MidSchedule">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_NightSchedule" HeaderText="夜班补贴" SortExpression="SDBT_NightSchedule">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_TeamLeader" HeaderText="小组长补助" SortExpression="SDBT_TeamLeader">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_LastMonth" HeaderText="补上月" SortExpression="SDBT_LastMonth">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_KouMo" HeaderText="扣膜补贴" SortExpression="SDBT_KouMo">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_HighTep" HeaderText="高温补贴" SortExpression="SDBT_HighTep">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_Insurance" HeaderText="劳保补贴" SortExpression="SDBT_Insurance">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_OtherSubsidies" HeaderText="其他补助" SortExpression="SDBT_OtherSubsidies">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_PaidVacation" HeaderText="有薪假" SortExpression="SDBT_PaidVacation">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_OtherPaid" HeaderText="其他应发款项" SortExpression="SDBT_OtherPaid">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_AttendancePaidCut" HeaderText="出勤扣款" SortExpression="SDBT_AttendancePaidCut">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_PerfromPaidCut" HeaderText="绩效扣款" SortExpression="SDBT_PerfromPaidCut">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_PassPercentPaidCut" HeaderText="合格率扣款" SortExpression="SDBT_PassPercentPaidCut">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_BadPaidCut" HeaderText="压塑压坏扣款" SortExpression="SDBT_BadPaidCut">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_OtherPaidCut" HeaderText="其他应发款项扣款" SortExpression="SDBT_OtherPaidCut">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_EndowmentInsurance" HeaderText="养老保险" SortExpression="SDBT_EndowmentInsurance">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_MedicalInsurance" HeaderText="医疗保险" SortExpression="SDBT_MedicalInsurance">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_UnemployedInsurance" HeaderText="失业保险" SortExpression="SDBT_UnemployedInsurance">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_InjuryInsurance" HeaderText="工伤保险" SortExpression="SDBT_InjuryInsurance">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_MaternityInsurance" HeaderText="生育保险" SortExpression="SDBT_MaternityInsurance">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_InsuranceTotal" HeaderText="保险合计" SortExpression="SDBT_InsuranceTotal">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_HousingFund" HeaderText="住房公积金" SortExpression="SDBT_HousingFund">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_InsuranceAndFund" HeaderText="险金合计" SortExpression="SDBT_InsuranceAndFund">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_OtherCut" HeaderText="其他应扣款项扣款" SortExpression="SDBT_OtherCut">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_IndividualTax" HeaderText="个人所得税" SortExpression="SDBT_IndividualTax">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_AccruedWages" HeaderText="应发工资" SortExpression="SDBT_AccruedWages">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SDBT_RealWages" HeaderText="实发工资" SortExpression="SDBT_RealWages">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TimeandPiece" HeaderText="计时+计件" SortExpression="TimeandPiece">
                                        <ItemStyle />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="peoplecount" HeaderText="人数" SortExpression="peoplecount">
                                        <ItemStyle />
                                    </asp:BoundField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <asp:Label ID="Label16" runat="server" Text="没有找到相关记录"></asp:Label>
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                    </fieldset>
                    <table style="width: 100%;">
                        <tr>
                            <td align="center">
                                <asp:Button ID="Button15" Visible="true" runat="server" Text="关闭" CssClass="Button02"
                                    Height="24px" Width="70px" OnClick="Button15_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanelShenHe" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="PanelShenHe" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="Label6" runat="server" Text=""></asp:Label>年<asp:Label ID="Label11"
                            runat="server" Text=""></asp:Label>月&nbsp月度工资审核</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label2" runat="server" CssClass="STYLE2" Text="审核人："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 20%;" align="left">
                                <asp:TextBox ID="TextBox2" runat="server" Width="130px" MaxLength="10" Enabled="false"></asp:TextBox>
                                <asp:Label ID="Label22" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                    ControlToValidate="TextBox2" ValidationGroup="ShenHe"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label3" runat="server" CssClass="STYLE2" Text="审核时间："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 20%;" align="left">
                                <asp:TextBox ID="TxtETime" runat="server" Width="130px" onfocus="new  WdatePicker(this,'%Y-%M-%D %h:%m:%s',true)"
                                    Enabled="false"></asp:TextBox>
                                <asp:Label ID="Label23" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                    ControlToValidate="TxtETime" ValidationGroup="ShenHe"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label7" runat="server" CssClass="STYLE2" Text="审核结果："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 20%;" align="left">
                                <asp:DropDownList ID="DropDownList3" runat="server" ToolTip="单击选择">
                                    <asp:ListItem>通过</asp:ListItem>
                                    <asp:ListItem>不通过</asp:ListItem>
                                </asp:DropDownList>
                                <asp:TextBox ID="TextBox5" runat="server" Width="130px" MaxLength="10" Enabled="false"
                                    Visible="false"></asp:TextBox>
                                <asp:Label ID="Label24" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                    ControlToValidate="DropDownList3" ValidationGroup="ShenHe"></asp:RequiredFieldValidator>--%>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label46" runat="server" CssClass="STYLE2" Text="审核意见:<br/>(200字内)"></asp:Label>
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="TxtRemarks" runat="server" Width="630px" Height="80px" TextMode="MultiLine"
                                    MaxLength="200" onkeyup="this.value = this.value.substring(0, 200)" onafterpaste="this.value = this.value.substring(0, 200)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="right">
                                <asp:Label ID="Label8" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Button ID="BtnSubmitChange" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    Width="70px" ValidationGroup="ShenHe" OnClick="BtnSubmitChange_Click" />
                            </td>
                            <td colspan="2" align="center">
                                <asp:Button ID="BtnClose" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    Visible="true" Width="70px" OnClick="BtnClose_Click" />
                            </td>
                            <td colspan="2" align="left">
                                <asp:Button ID="BtnCancelChange" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    Visible="true" Width="70px" OnClick="BtnCancelChange_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
