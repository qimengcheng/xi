<%@ Page Title="" Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true"
    CodeFile="ZhuangPeiJiJian.aspx.cs" Inherits="WorkOrderSalary_ZhuangPeiJiJian" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" Visible="true">
                <fieldset>
                    <legend>装配计件日期检索
                        <asp:Label ID="label_pagestate" runat="server" Visible="False"></asp:Label></legend>
                    <table style="width: 100%;">
                        <tr style="width: 100%;">
                            <td align="center" style="width: 15%;">
                                计算日期：
                            </td>
                            <td align="left" class="auto-style3" style="width: 16%;">
                                <asp:TextBox ID="TextBox_calculate_Time1" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 33px;">
                                至
                            </td>
                            <td align="left" style="width: 16%;">
                                <asp:TextBox ID="TextBox_calculate_Time2" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"></asp:TextBox>
                            </td>
                            <td style="width: 333px" align="right">
                                <asp:Button ID="Button1" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_Search_Click"
                                    Text="检索" Width="80px" />
                            </td>
                            <td style="width: 287px" align="left">
                                <asp:Button ID="Button2" runat="server" CssClass="Button02" Height="24px" OnClick="Button_Cancel_Click"
                                    Text="重置" Width="80px" />
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="Button_Add" runat="server" CssClass="Button02" Height="24px" OnClick="Button_Add_Click"
                                    Text="新建装配计件日期" Width="120px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_Add" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Add" runat="server" Visible="false">
                <fieldset>
                    <legend>新增装配计件日期 </legend>
                    <table style="width: 100%;">
                        <tr style="width: 100%;">
                            <td style="width: 8%;">
                                计算日期：
                            </td>
                            <td align="left" style="width: 21%;">
                                <asp:TextBox ID="TextBox_calculate_Time_Add" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',false)"></asp:TextBox>
                                *
                            </td>
                            <td align="center" style="width: 12%;">
                            </td>
                            <td align="right" style="width: 10%;">
                                <asp:Button ID="Button_Add_Submit" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_Add_Submit_Click" Text="确定" Width="80px" />
                            </td>
                            <td align="left" style="width: 11%;">
                                <asp:Button ID="Button_Add_Cancel" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_Add_Cancel_Click" Text="取消" Width="80px" />
                            </td>
                            <td align="left" class="auto-style3" style="width: 16%;">
                            </td>
                            <td align="center" style="width: 33px;">
                            </td>
                            <td align="left" style="width: 16%;">
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_WOmain" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_WOmain" runat="server" Visible="true">
                <fieldset>
                    <legend>装配计件日期表<asp:Label ID="label1" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        PageSize="10" CellPadding="0" UseAccessibleHeader="False" AllowPaging="True"
                        OnRowCommand="GridView_WOmain_RowCommand" OnPageIndexChanging="GridView_WOmain_PageIndexChanging"
                        AllowSorting="True" Width="100%" DataKeyNames="APD_ID" EmptyDataText="无相关记录!"
                        GridLines="None">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="APD_ID" SortExpression="APD_ID" HeaderText="装配日期ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="APD_Date" SortExpression="APD_Date" HeaderText="日期" DataFormatString="{0:yyyy-MM-dd}">
                            </asp:BoundField>
                            <asp:BoundField DataField="APD_Man" SortExpression="APD_Man" HeaderText="制定人"></asp:BoundField>
                            <asp:BoundField DataField="APD_Time" SortExpression="APD_Time" HeaderText="制定时间"
                                DataFormatString="{0:yyyy-MM-dd HH:mm}"></asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="DeleteWTP" runat="server" CommandName="DeleteWTP" CommandArgument='<%#Eval("APD_ID") %>'
                                        OnClientClick="return confirm('将会删除装配计件日期，确定吗？')">删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="CheckPiece" runat="server" CommandArgument='<%#Eval("APD_ID") +","+ Eval("APD_ID")%>'
                                        CommandName="CheckPiece">工价系列</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第 &nbsp;<asp:Label ID="lblPageIndex" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                        页 共 &nbsp;<asp:Label ID="lblPageCount" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageCount  %>" />
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
                                            CommandName="Page" Text="GO" />
                                    </td>
                                </tr>
                            </table>
                        </PagerTemplate>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label16" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                    </asp:GridView>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_Search" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Search" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="label_APD_ID" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="label_Sname" runat="server" Visible="False"></asp:Label>
                        工价系列 </legend>
                    <table style="width: 100%; height: 23px;">
                        <tr style="width: 100%;">
                            <td style="width: 13%;" align="center">
                                工价系列：
                            </td>
                            <td style="width: 17%;" align="left">
                                <asp:TextBox ID="TextBox_Seriesname" runat="server" Width="100%"></asp:TextBox>
                            </td>
                            <td style="width: 11%;" align="center">
                                &nbsp;
                            </td>
                            <td align="center" style="width: 11%;">
                                <asp:Button ID="Btn_Search" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_SearchGongjia_Click"
                                    Text="检索" Width="80px" />
                            </td>
                            <td style="width: 10%;" align="center">
                                <asp:Button ID="Button_Cancel" runat="server" CssClass="Button02" Height="24px" OnClick="Button_CancelGongjia_Click"
                                    Text="重置" Width="80px" />
                            </td>
                            <td align="center" style="width: 11%;">
                            </td>
                            <td align="left" style="width: 70px;">
                            </td>
                            <td style="width: 16%;" align="right">
                                <asp:Button ID="Button_Cancel0" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_GuanBiGongjia_Click" Text="关闭" Width="80px" />
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView_Xilie" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        PageSize="10" CellPadding="0" UseAccessibleHeader="False" AllowPaging="True"
                        OnRowCommand="GridView_Xilie_RowCommand" OnPageIndexChanging="GridView_Xilie_PageIndexChanging"
                        AllowSorting="True" Width="100%" DataKeyNames="LCS_ID" EmptyDataText="无相关记录!"
                        GridLines="None">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="LCS_ID" SortExpression="LCS_ID" HeaderText="随工单信息ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="LCS_Name" SortExpression="LCS_Name" HeaderText="工价系列">
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="ptmgt" runat="server" CommandArgument='<%#Eval("LCS_ID") +","+ Eval("LCS_Name")%>'
                                        CommandName="ptmgt">工价系统所属计件信息详情</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第 &nbsp;<asp:Label ID="lblPageIndex" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                        页 共 &nbsp;<asp:Label ID="lblPageCount" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageCount  %>" />
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
                                            CommandName="Page" Text="GO" />
                                    </td>
                                </tr>
                            </table>
                        </PagerTemplate>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label16" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                    </asp:GridView>
            </asp:Panel>
            </fieldset>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_Detail" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <asp:Panel ID="Panel_Detail" runat="server" Visible="False">
                <fieldset>
                    <legend>
                        <asp:Label ID="label_Xilie2" runat="server"></asp:Label>
                        工价系列所属计件信息详情表
                        <asp:Label ID="label_XilieID" runat="server" Visible="False" Text="00000000-0000-0000-0000-000000000000"></asp:Label>
                        <asp:Label ID="Label_STI_ID" runat="server" Visible="False" Text="00000000-0000-0000-0000-000000000000"></asp:Label>
                    </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 63px">
                                工号：
                            </td>
                            <td class="auto-style3" style="width: 100px">
                                <asp:TextBox ID="TextBox_NO" runat="server" Width="100px"></asp:TextBox>
                            </td>
                            <td style="width: 58px" align="right">
                                姓名：
                            </td>
                            <td style="width: 123px">
                                <asp:TextBox ID="TextBox_Name" runat="server" Width="100px"></asp:TextBox>
                            </td>
                            <td style="width: 87px">
                                <asp:Button ID="Button_SearchDetail" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_SearchDetail_Click" Text="检索" Width="80px" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td align="left" style="width: 171px">
                                <asp:Button ID="Button_ResetDetail" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_ResetDetail_Click" Text="重置" Width="80px" />
                            </td>
                            <td align="right" style="width: 155px">
                                <asp:Button ID="Button_Addman" runat="server" CssClass="Button02" Height="24px" OnClick="Button_Addman_Click"
                                    Text="添加员工" Width="80px" />
                            </td>
                        </tr>
                    </table>
                    <table id="pl" runat="server" width="100%">
                        <tr>
                            <td style="width: 163px">
                                <asp:Label ID="Label4" runat="server" Text="批量选择时间：" ForeColor="Red"></asp:Label>
                            </td>
                            <td style="width: 100px">
                                <asp:TextBox ID="TextBox_Name0" runat="server" Width="100px"></asp:TextBox>
                            </td>
                            <td align="right" style="width: 58px">
                                <asp:Button ID="Button_Addman0" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_Addman0_Click" Text="批量制定本页员工时间" Width="150px" />
                            </td>
                            <td style="width: 233px">
                                <asp:Label ID="Label5" runat="server" Text="批量选择计件类型：" ForeColor="Red"></asp:Label>
                            </td>
                            <td style="width: 146px">
                                <asp:DropDownList ID="DropDownList12" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList12_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td align="center" style="width: 97px">
                                &nbsp;
                            </td>
                            <td align="center" style="width: 171px">
                                &nbsp;
                            </td>
                            <td align="right" style="width: 155px">
                                &nbsp;
                            </td>
                            <td align="right">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView_Detail" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        PageSize="30" CellPadding="0" UseAccessibleHeader="False" OnRowCommand="GridView_Detail_RowCommand"
                        OnPageIndexChanging="GridView_Detail_PageIndexChanging" AllowSorting="True" Width="100%"
                        DataKeyNames="ATM_ID" EmptyDataText="无相关记录!" GridLines="None" OnRowCancelingEdit="GridView_Detail_RowCancelingEdit"
                        OnRowEditing="GridView_Detail_RowEditing" OnRowDataBound="GridView_Detail_RowDataBound"
                        OnRowUpdating="GridView_Detail_RowUpdating">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemStyle Width="5%" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox2" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ATM_ID" SortExpression="ATM_ID" HeaderText="装配组员维护ID"
                                Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="HRDD_StaffNO" SortExpression="HRDD_StaffNO" HeaderText="工号"
                                ReadOnly="True"></asp:BoundField>
                            <asp:BoundField DataField="HRDD_Name" SortExpression="HRDD_Name" HeaderText="姓名"
                                ReadOnly="True"></asp:BoundField>
                            <asp:TemplateField HeaderText="计件类型" SortExpression="SPI_Name" Visible="true">
                                <ItemTemplate>
                                    <asp:Label ID="Ll6" runat="server" Text='<%#Eval("SPI_Name")%>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Font-Bold="True" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="计件类型" SortExpression="SPI_Name" Visible="true">
                                <ItemTemplate>
                                    <asp:DropDownList ID="Dltype1111111111" runat="server">
                                    </asp:DropDownList>
                                </ItemTemplate>
                                <HeaderStyle Font-Bold="True" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="ATM_LaborHour" SortExpression="ATM_LaborHour" HeaderText="日计时">
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="日计时" SortExpression="ATM_LaborHour" Visible="true">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPlan" runat="server" Width="85%" Text='<%#Eval("ATM_LaborHour")%>'></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle Font-Bold="True" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="rate" SortExpression="rate" HeaderText="生产比例" ReadOnly="True">
                            </asp:BoundField>
                            <asp:BoundField DataField="ATM_Num" SortExpression="ATM_Num" HeaderText="计件数" ReadOnly="True">
                            </asp:BoundField>
                            <asp:CommandField ShowEditButton="True" EditText="制定" UpdateText="更新" CancelText="取消"
                                Visible="False"></asp:CommandField>
                            <asp:TemplateField Visible="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="DeleteDetail12345" runat="server" CommandName="DeleteDetail12345"
                                        CommandArgument='<%#Eval("ATM_ID") %>' OnClientClick="return confirm('将会删除该信息，确定吗？')">删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第 &nbsp;<asp:Label ID="lblPageIndex" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                        页 共 &nbsp;<asp:Label ID="lblPageCount" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageCount  %>" />
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
                                            CommandName="Page" Text="GO" />
                                    </td>
                                </tr>
                            </table>
                        </PagerTemplate>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label16" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <table id="pl2" runat="server" width="100%">
                        <tr>
                            <td style="width: 171px;">
                                <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBoxAll2_CheckedChanged"
                                    Text="全选" Width="83px" />
                                <asp:CheckBox ID="CheckBox3" runat="server" AutoPostBack="True" OnCheckedChanged="Checkfanxuan2_CheckedChanged"
                                    Text="反选" Width="84px" />
                            </td>
                            <td style="width: 26px">
                                <asp:Button ID="Button_AddPTToSeries" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_AddPTToSeries_Click" Text="删除" Width="70px" />
                            </td>
                            <td style="width: 38px">
                                &nbsp;
                            </td>
                            <td style="width: 93px">
                                &nbsp;
                            </td>
                            <td style="width: 320px;">
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 147px">
                                该系列下所有员工总工时：
                            </td>
                            <td style="width: 60px">
                                <asp:TextBox ID="TextBox_TotalNum" runat="server" ForeColor="Red" Width="45px" Enabled="False"
                                    Style="text-align: right">0</asp:TextBox>
                            </td>
                            <td style="width: 163px">
                                该系列下所有员工总计件数：
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox_TotalNum0" runat="server" Enabled="False" ForeColor="Red"
                                    Style="text-align: right" Width="60px">0</asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%;">
                        <tr>
                            <td align="center" style="width: 285px">
                                <asp:Button ID="Button_Submit" runat="server" CssClass="Button02" Height="24px" OnClick="Button_Submit_Click"
                                    OnClientClick="return confirm('提交后将无法修改，确定吗？')" Text="提交" Width="80px" Visible="False" />
                            </td>
                            <td align="center" style="width: 263px">
                                <asp:Button ID="Button_Sava" runat="server" CssClass="Button02" Height="24px" OnClick="Button_save_Click"
                                    OnClientClick="return confirm('系统将会按照比例自动算得装配员工该日的计件数，最终结果可在计时计件核算页面查看，确定吗？')"
                                    Text="保存" Width="80px" />
                            </td>
                            <td align="center">
                                <asp:Button ID="Button_CloseDetail" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_CloseDetail_Click" Text="关闭" Width="80px" />
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_AddPeople" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_AddPeople" runat="server" Visible="False">
                <fieldset>
                    <legend>
                        <asp:Label ID="label2" runat="server"></asp:Label>
                        添加员工
                        <asp:Label ID="label3" runat="server" Visible="False" Text="00000000-0000-0000-0000-000000000000"></asp:Label>
                    </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 63px">
                                工号：
                            </td>
                            <td class="auto-style3" style="width: 100px">
                                <asp:TextBox ID="TextBox1" runat="server" Width="100px"></asp:TextBox>
                            </td>
                            <td style="width: 58px" align="right">
                                姓名：
                            </td>
                            <td style="width: 123px">
                                <asp:TextBox ID="TextBox2" runat="server" Width="100px"></asp:TextBox>
                            </td>
                            <td style="width: 58px">
                                &nbsp;
                            </td>
                            <td style="width: 51px">
                                &nbsp;
                            </td>
                            <td align="center" style="width: 97px">
                                选择班组：
                            </td>
                            <td align="left" style="width: 171px">
                                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td align="right" style="width: 155px">
                                &nbsp;
                            </td>
                            <td align="right">
                                <asp:Button ID="Button_AddPeople_close" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_AddPeople_close_Click" Text="关闭" Width="80px" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 63px">
                                &nbsp;
                            </td>
                            <td class="auto-style3" style="width: 100px">
                                &nbsp;
                            </td>
                            <td align="right" style="width: 58px">
                                &nbsp;
                            </td>
                            <td style="width: 123px">
                                <asp:Button ID="Button_AddPeopleSearch" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_AddPeopleSearch_Click" Text="检索" Width="80px" />
                            </td>
                            <td style="width: 58px">
                                &nbsp;
                            </td>
                            <td style="width: 51px">
                                &nbsp;
                            </td>
                            <td align="center" style="width: 97px">
                                &nbsp;
                            </td>
                            <td align="center" style="width: 171px">
                                <asp:Button ID="Button_AddPeopleCancel" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_AddPeopleCancel_Click" Text="重置" Width="80px" />
                            </td>
                            <td align="right" style="width: 155px">
                                &nbsp;
                            </td>
                            <td align="right">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView_People" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        PageSize="20" CellPadding="0" UseAccessibleHeader="False" AllowPaging="True"
                        OnPageIndexChanging="GridView_People_PageIndexChanging" AllowSorting="True" Width="100%"
                        DataKeyNames="HRDD_ID" EmptyDataText="无相关记录!" GridLines="None">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:TemplateField HeaderText="选择">
                                <ItemStyle Width="5%" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="HRDD_ID" SortExpression="HRDD_ID" HeaderText="人事档案ID"
                                Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="工号" SortExpression="工号" HeaderText="工号" ItemStyle-Width="45%"
                                ReadOnly="True"></asp:BoundField>
                            <asp:BoundField DataField="姓名" SortExpression="姓名" HeaderText="姓名" ItemStyle-Width="45%"
                                ReadOnly="True"></asp:BoundField>
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第 &nbsp;<asp:Label ID="lblPageIndex" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                        页 共 &nbsp;<asp:Label ID="lblPageCount" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageCount  %>" />
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
                                            CommandName="Page" Text="GO" />
                                    </td>
                                </tr>
                            </table>
                        </PagerTemplate>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label16" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <table width="100%">
                        <tr>
                            <td style="width: 26px">
                                <asp:CheckBox ID="CheckBoxAll2" runat="server" Text="全选" Width="54px" AutoPostBack="True"
                                    OnCheckedChanged="CheckBoxAll12_CheckedChanged" />
                            </td>
                            <td style="width: 38px">
                                <asp:CheckBox ID="Checkfanxuan2" runat="server" Text="反选" Width="141px" AutoPostBack="True"
                                    OnCheckedChanged="Checkfanxuan12_CheckedChanged" />
                            </td>
                            <td style="width: 93px">
                                <asp:Button ID="Button_CheckboxAddProject2" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_CheckboxAddProject2_Click" Text="添加" Width="80px" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
