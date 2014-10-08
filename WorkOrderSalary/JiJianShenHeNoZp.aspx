<%@ Page Title="" Language="C#" MasterPageFile="~/other/MasterPage.master" AutoEventWireup="true"
    CodeFile="JiJianShenHeNoZp.aspx.cs" Inherits="WorkOrderSalary_JiJianShenHeNoZp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel_Search" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Search" runat="server" Visible="true">
                <fieldset>
                    <legend>计时项目审核表检索
                        <asp:Label ID="label_pagestate" runat="server" Text="Label" Visible="False"></asp:Label></legend>
                    <table style="width: 100%;">
                        <tr style="width: 100%;">
                            <td align="center" style="width: 11%;">
                                计件项目：
                            </td>
                            <td align="left" class="auto-style3" style="width: 16%;">
                                <asp:TextBox ID="TextBox_xiangmu" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 10%;" align="center">
                                工序：
                            </td>
                            <td align="center" style="width: 10%;">
                                <asp:TextBox ID="TextBox_tibaoren" runat="server"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 13%;">
                                所属日期：
                            </td>
                            <td align="center" style="width: 13%;">
                                <asp:TextBox ID="TextBox_WO_Time1" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"></asp:TextBox>
                            </td>
                            <td style="width: 3%;" align="left">
                                至
                            </td>
                            <td align="left" style="width: 17%;">
                                <asp:TextBox ID="TextBox_WO_Time2" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="width: 100%;">
                            <td align="center" style="width: 11%;">
                                状态：
                            </td>
                            <td align="left" class="auto-style3" style="width: 16%;">
                                <asp:DropDownList ID="DropDownList1" runat="server">
                                    <asp:ListItem>请选择</asp:ListItem>
                                    <asp:ListItem>财务待审</asp:ListItem>
                                    <asp:ListItem>财务通过</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="center" style="width: 10%;">
                                审核人：
                            </td>
                            <td align="center" style="width: 10%;">
                                <asp:TextBox ID="TextBox_chushengren" runat="server"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 13%;">
                                审核时间：
                            </td>
                            <td align="center" style="width: 13%;">
                                <asp:TextBox ID="TextBox_tibaoshijian1" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"></asp:TextBox>
                            </td>
                            <td align="left" style="width: 3%;">
                                至
                            </td>
                            <td align="left" style="width: 17%;">
                                <asp:TextBox ID="TextBox_tibaoshijian2" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%;">
                        <tr style="width: 100%;">
                            <td align="center" style="width: 13%;">
                                &nbsp;
                            </td>
                            <td align="left" style="width: 22%;">
                                &nbsp;
                            </td>
                            <td align="center" style="width: 15%;">
                                <asp:Button ID="Btn_Search" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_Search_Click"
                                    Text="检索" Width="70px" />
                            </td>
                            <td align="center" style="width: 14%;">
                                &nbsp;
                            </td>
                            <td align="center" style="width: 11%;">
                                <asp:Button ID="Button_Cancel" runat="server" CssClass="Button02" Height="24px" OnClick="Button_Cancel_Click"
                                    Text="重置" Width="70px" />
                            </td>
                            <td align="left" class="auto-style3" style="width: 127px">
                                &nbsp;
                            </td>
                            <td align="left" style="width: 28px;">
                                &nbsp;
                            </td>
                            <td align="right" style="width: 16%;">
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
                    <legend>计件项目审核表<asp:Label ID="label_GridPageState" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <asp:GridView ID="GridView_WOmain" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        PageSize="30" CellPadding="0" UseAccessibleHeader="False" AllowPaging="True"
                        OnRowCommand="GridView_WOmain_RowCommand" OnPageIndexChanging="GridView_WOmain_PageIndexChanging"
                        AllowSorting="True" Width="100%" DataKeyNames="PA_State,PieceItem_ID,d1,PA_ID,PBC_Name,SPI_Name,PA_RMan,PA_RTime,PA_RResult,PA_Suggestion"
                        EmptyDataText="无相关记录!" GridLines="None" OnDataBound="GridView_WOmain_DataBound"
                        OnRowDataBound="GridView_WOmain_RowDataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox2" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="PieceItem_ID" SortExpression="PieceItem_ID" HeaderText="计件项目ID"
                                Visible="False"></asp:BoundField>
                            <asp:BoundField DataField="PA_ID" SortExpression="PA_ID" HeaderText="计件项目审核ID" Visible="False">
                            </asp:BoundField>
                            <asp:BoundField DataField="d1" SortExpression="d1" HeaderText="日期" DataFormatString="{0:yyyy-MM-dd}">
                            </asp:BoundField>
                            <asp:BoundField DataField="PBC_Name" SortExpression="PBC_Name" HeaderText="工序"></asp:BoundField>
                            <asp:BoundField DataField="SPI_Name" SortExpression="SPI_Name" HeaderText="计件项目">
                            </asp:BoundField>
                            <asp:BoundField DataField="totalnum" SortExpression="totalnum" HeaderText="总数"></asp:BoundField>
                            <asp:BoundField DataField="PA_State" SortExpression="PA_State" HeaderText="状态"></asp:BoundField>
                            <asp:BoundField DataField="PA_RMan" SortExpression="PA_RMan" HeaderText="审核人"></asp:BoundField>
                            <asp:BoundField DataField="PA_RTime" SortExpression="PA_RTime" HeaderText="审核时间"
                                DataFormatString="{0:yy-MM-dd HH:mm}"></asp:BoundField>
                            <asp:BoundField DataField="PA_RResult" SortExpression="PA_RResult" HeaderText="审核结果">
                            </asp:BoundField>
                            <asp:BoundField DataField="PA_Suggestion" SortExpression="PA_Suggestion" HeaderText="审核意见">
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Detail12" runat="server" CommandName="Detail12">详情</asp:LinkButton>
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
                    <table id="t123" runat="server" width="100%">
                        <tr>
                            <td style="width: 310px;">
                            </td>
                            <td style="width: 26px">
                                <asp:CheckBox ID="CheckBox2" runat="server" Text="全选" Width="83px" AutoPostBack="True"
                                    OnCheckedChanged="CheckBoxAll2_CheckedChanged" />
                            </td>
                            <td style="width: 38px">
                                <asp:CheckBox ID="Checkfanxuan2" runat="server" Text="反选" Width="141px" AutoPostBack="True"
                                    OnCheckedChanged="Checkfanxuan2_CheckedChanged" />
                            </td>
                            <td style="width: 93px">
                                <asp:Button ID="Button_AddPTToSeries" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_AddPTToSeries_Click" Text="批量审核" Width="70px" />
                            </td>
                            <td style="width: 320px;">
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
                    <legend>
                        <asp:Label ID="label_Date" runat="server"></asp:Label>
                        &nbsp;
                        <asp:Label ID="Label_SPI_Name" runat="server"></asp:Label>
                        计件项目详情
                        <asp:Label ID="Label_SPI_ID" runat="server" Visible="False" />
                    </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 138px">
                                随工单号：
                            </td>
                            <td style="width: 100px">
                                <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 106px" align="right">
                                工号：
                            </td>
                            <td style="width: 58px">
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 51px">
                                姓名：
                            </td>
                            <td align="center">
                                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 155px">
                                &nbsp;
                            </td>
                            <td align="center" style="width: 155px">
                                &nbsp;
                            </td>
                            <td align="right">
                                <asp:Button ID="Button3" runat="server" CssClass="Button02" Height="24px" Text="关闭"
                                    Width="70px" OnClick="Button3_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 138px">
                                &nbsp;
                            </td>
                            <td style="width: 100px">
                                &nbsp;
                            </td>
                            <td style="width: 106px">
                                <asp:Button ID="Button1" runat="server" CssClass="Button02" Height="24px" OnClick="Button1_Click"
                                    Text="检索" Width="70px" />
                            </td>
                            <td style="width: 58px">
                                &nbsp;
                            </td>
                            <td style="width: 51px">
                                <asp:Button ID="Button2" runat="server" CssClass="Button02" Height="24px" OnClick="Button2_Click"
                                    Text="重置" Width="70px" />
                            </td>
                            <td align="center">
                                &nbsp;
                            </td>
                            <td align="center" style="width: 155px">
                                &nbsp;
                            </td>
                            <td align="center" style="width: 155px">
                                &nbsp;
                            </td>
                            <td align="right">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        PageSize="30" CellPadding="0" UseAccessibleHeader="False" AllowPaging="True"
                        OnPageIndexChanging="GridView_AddProject_PageIndexChanging" AllowSorting="True"
                        Width="100%" DataKeyNames="OI_ID" EmptyDataText="无相关记录!" GridLines="None" OnRowCommand="GridView_AddProject_RowCommand">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="OI_ID" HeaderText="详细ID" Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="WO_Num" HeaderText="随工单号"></asp:BoundField>
                            <asp:BoundField DataField="HRDD_StaffNO" HeaderText="工号"></asp:BoundField>
                            <asp:BoundField DataField="HRDD_Name" HeaderText="姓名"></asp:BoundField>
                            <asp:BoundField DataField="OI_ProNum" HeaderText="产量"></asp:BoundField>
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
                </fieldset>
            </asp:Panel>
            <asp:Panel ID="Panel3" runat="server" Visible="False">
                <fieldset>
                    <legend>财务审核详细&nbsp;<asp:Label ID="Label22" runat="server"></asp:Label></legend>
                    <asp:Label ID="Label13" runat="server" Text="所选提待审项目：" Visible="False"></asp:Label>
                    <asp:Label ID="Label14" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="Label21" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="Label_PLID" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="Label_type" runat="server" Visible="False"></asp:Label>
                    <table style="width: 100%;">
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td align="right">
                                <asp:Button ID="Button_AddPeople_close0" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_AddPeople_close0_Click" Text="关闭审核页面" Width="90px" />
                            </td>
                        </tr>
                    </table>
                    <table width="100%">
                        <tr id="pl0" runat="server">
                            <td style="width: 126px" align="right">
                                财务审核人：
                            </td>
                            <td style="width: 94px">
                                <asp:Label ID="Label41" runat="server"></asp:Label>
                            </td>
                            <td style="width: 89px" align="right">
                                财务审核时间：
                            </td>
                            <td style="width: 123px" align="left">
                                <asp:Label ID="Label42" runat="server"></asp:Label>
                            </td>
                            <td style="width: 196px">
                            </td>
                            <td>
                                财务审核结果：<asp:Label ID="label52" runat="server" ForeColor="Red" Visible="true"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%">
                        <tr>
                            <td align="right" style="width: 15%">
                                <asp:Label ID="Label44" runat="server" Text="财务审核意见：</br>(400字以内)"></asp:Label>
                            </td>
                            <td align="left" colspan="7">
                                <asp:TextBox ID="TextBox7" runat="server" Enabled="True" Height="98px" MaxLength="200"
                                    TextMode="MultiLine" onkeyup="this.value = this.value.substring(0, 400)" onafterpaste="this.value = this.value.substring(0, 1000)"
                                    Width="93%"></asp:TextBox>
                                <asp:Label ID="Label45" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="1">
                            </td>
                            <td align="center" colspan="2">
                                <asp:Button ID="pbtg" runat="server" CssClass="Button02" Height="24px" OnClick="pbtg_Click"
                                    Text="通过" Width="70px" />
                            </td>
                            <td align="center" colspan="3">
                                <asp:Button ID="pbbh" runat="server" CssClass="Button02" Height="24px" OnClick="pbbh_Click"
                                    Text="不通过" Width="70px" />
                            </td>
                            <td align="center" colspan="2">
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
