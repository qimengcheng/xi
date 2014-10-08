<%@ Page Title="" Language="C#" MasterPageFile="~/other/MasterPage.master" AutoEventWireup="true"
    CodeFile="jjbl.aspx.cs" Inherits="WorkOrderSalary_jjbl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel_Search" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Search" runat="server" Visible="true">
                <fieldset>
                    <legend>计件补录检索
                        <asp:Label ID="label_pagestate" runat="server" Text="Label" Visible="False"></asp:Label></legend>
                    <table style="width: 100%;">
                        <tr style="width: 100%;">
                            <td align="center" style="width: 11%;">
                                补录单号：
                            </td>
                            <td align="left" class="auto-style3" style="width: 16%;">
                                <asp:TextBox ID="TextBox_xiangmu" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 10%;" align="center">
                                补录人：
                            </td>
                            <td align="center" style="width: 10%;">
                                <asp:TextBox ID="TextBox_tibaoren" runat="server"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 13%;">
                                补录时间：
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
                                    <asp:ListItem>已建立</asp:ListItem>
                                    <asp:ListItem>财务驳回</asp:ListItem>
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
                                <asp:Button ID="Button_Cancel0" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_Cancel0_Click" Text="新增补录单" Width="70px" />
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
                    <legend>新增补录单 </legend>
                    <table style="width: 100%;">
                        <tr style="width: 100%;">
                            <td align="center" style="width: 3%;">
                                补录备注：
                            </td>
                            <td align="left" class="auto-style3" style="width: 16%;">
                                <asp:TextBox ID="TextBox1" runat="server" Width="95%"></asp:TextBox>
                            </td>
                            <td style="width: 10%;" align="center">
                                &nbsp;
                            </td>
                            <td style="width: 3%;" align="left">
                                &nbsp;
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
                                <asp:Button ID="Button1" runat="server" CssClass="Button02" Height="24px" OnClick="Btn1_Click"
                                    Text="提交" Width="70px" />
                            </td>
                            <td align="center" style="width: 14%;">
                                &nbsp;
                            </td>
                            <td align="center" style="width: 11%;">
                                <asp:Button ID="Button2" runat="server" CssClass="Button02" Height="24px" OnClick="Button2_Click"
                                    Text="取消" Width="70px" />
                            </td>
                            <td align="left" class="auto-style3" style="width: 127px">
                                &nbsp;
                            </td>
                            <td align="left" style="width: 28px;">
                                &nbsp;
                            </td>
                            <td align="right" style="width: 16%;">
                                &nbsp;
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
                    <legend>计件补录审核表<asp:Label ID="label_GridPageState" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <asp:GridView ID="GridView_WOmain" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        PageSize="30" CellPadding="0" UseAccessibleHeader="False" AllowPaging="True"
                        OnRowCommand="GridView_WOmain_RowCommand" OnPageIndexChanging="GridView_WOmain_PageIndexChanging"
                        AllowSorting="True" Width="100%" DataKeyNames="JJBL_ID,JJBL_NO,JJBL_Man,JJBL_Time,JJBL_State,JJBL_ShMan,JJBL_ShTime,JJBL_ShRes,JJBL_ShSugg"
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
                            <asp:BoundField DataField="JJBL_ID" SortExpression="JJBL_ID" HeaderText="计件补录ID"
                                Visible="False"></asp:BoundField>
                            <asp:BoundField DataField="JJBL_NO" SortExpression="JJBL_NO" HeaderText="补录单号"></asp:BoundField>
                            <asp:BoundField DataField="JJBL_Man" SortExpression="JJBL_Man" HeaderText="补录人">
                            </asp:BoundField>
                            <asp:BoundField DataField="JJBL_Time" SortExpression="JJBL_Time" HeaderText="补录时间"
                                DataFormatString="{0:yy-MM-dd HH:mm}"></asp:BoundField>
                            <asp:BoundField DataField="JJBL_State" SortExpression="JJBL_State" HeaderText="状态">
                            </asp:BoundField>
                            <asp:BoundField DataField="JJBL_Note" SortExpression="JJBL_Note" HeaderText="备注">
                            </asp:BoundField>
                            <asp:BoundField DataField="JJBL_ShMan" SortExpression="JJBL_ShMan" HeaderText="审核人">
                            </asp:BoundField>
                            <asp:BoundField DataField="JJBL_ShTime" SortExpression="JJBL_ShTime" HeaderText="审核时间"
                                DataFormatString="{0:yy-MM-dd HH:mm}"></asp:BoundField>
                            <asp:BoundField DataField="JJBL_ShRes" SortExpression="JJBL_ShRes" HeaderText="审核结果">
                            </asp:BoundField>
                            <asp:BoundField DataField="JJBL_ShSugg" SortExpression="JJBL_ShSugg" HeaderText="审核意见">
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="dele" runat="server" CommandName="dele" OnClientClick="return confirm('将会删除该条计件补录信息，所属详细信息也会一并删除且不可恢复，确定吗？')">删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
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
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel2" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="label_Date" runat="server"></asp:Label>
                        &nbsp; 补录单详情
                        <asp:Label ID="Label_JJBL_ID" runat="server" Visible="False" />
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
                                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 76px">
                                姓名：
                            </td>
                            <td align="center">
                                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 155px">
                                &nbsp;
                            </td>
                            <td align="center" style="width: 155px">
                                &nbsp;
                            </td>
                            <td align="right">
                                <asp:Button ID="Button4" runat="server" CssClass="Button02" Height="24px" Text="关闭"
                                    Width="70px" OnClick="Button3_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 138px">
                                产品型号：
                            </td>
                            <td style="width: 100px">
                                <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                            </td>
                            <td align="right" style="width: 106px">
                                工序:：
                            </td>
                            <td style="width: 58px">
                                <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 76px">
                                计件项目：
                            </td>
                            <td align="center">
                                <asp:TextBox ID="TextBox15" runat="server"></asp:TextBox>
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
                        <tr>
                            <td style="width: 138px">
                                &nbsp;
                            </td>
                            <td style="width: 100px">
                                &nbsp;
                            </td>
                            <td style="width: 106px">
                                <asp:Button ID="Button5" runat="server" CssClass="Button02" Height="24px" OnClick="Button5_Click"
                                    Text="检索" Width="70px" />
                            </td>
                            <td style="width: 58px">
                                &nbsp;
                            </td>
                            <td style="width: 76px">
                                <asp:Button ID="Button6" runat="server" CssClass="Button02" Height="24px" OnClick="Button6_Click"
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
                                <asp:Button ID="Button7" runat="server" CssClass="Button02" Height="24px" OnClick="Button7_Click"
                                    Text="新增详情" Width="70px" />
                            </td>
                        </tr>
                    </table>
                    <table width="100%">
                        <tr>
                            <td style="width: 200px">
                                <asp:Label ID="Label5" runat="server" ForeColor="Red" Text="批量选择勾选项的计件类型："></asp:Label>
                            </td>
                            <td style="width: 100px">
                                <asp:DropDownList ID="DropDownList12" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList12_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 106px">
                                &nbsp;
                            </td>
                            <td style="width: 58px">
                                &nbsp;
                            </td>
                            <td style="width: 76px">
                                &nbsp;
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
                        Width="100%" DataKeyNames="补录ID" EmptyDataText="无相关记录!" GridLines="None" OnRowCommand="GridView_AddProject_RowCommand"
                        OnDataBound="GridView1_DataBound" OnRowDataBound="GridView1_RowDataBound">
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
                            <asp:BoundField DataField="补录ID" HeaderText="补录ID" Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="随工单号" HeaderText="随工单号"></asp:BoundField>
                            <asp:BoundField DataField="工号" HeaderText="工号"></asp:BoundField>
                            <asp:BoundField DataField="姓名" HeaderText="姓名"></asp:BoundField>
                            <asp:BoundField DataField="工序" HeaderText="工序"></asp:BoundField>
                            <asp:BoundField DataField="产品型号" HeaderText="产品型号"></asp:BoundField>
                            <asp:BoundField DataField="计件项目" HeaderText="计件类型"></asp:BoundField>
                            <asp:BoundField DataField="补录数" HeaderText="补录数"></asp:BoundField>
                            <asp:TemplateField HeaderText="补录数" SortExpression="补录数">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPlan" runat="server" Width="70px" Text='<%#Eval("补录数")%>'></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle Font-Bold="True" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="进站数" HeaderText="进站数"></asp:BoundField>
                            <asp:BoundField DataField="总分配数" HeaderText="总分配数"></asp:BoundField>
                            <asp:BoundField DataField="未分配数" HeaderText="未分配数"></asp:BoundField>
                            <asp:BoundField DataField="进站时间" HeaderText="进站时间" DataFormatString="{0:yy-MM-dd HH:mm}">
                            </asp:BoundField>
                            <asp:BoundField DataField="出站时间" HeaderText="出站时间" DataFormatString="{0:yy-MM-dd HH:mm}">
                            </asp:BoundField>
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
                    <table id="Table1" runat="server" width="100%">
                        <tr>
                            <td style="width: 310px;">
                            </td>
                            <td style="width: 26px">
                                <asp:CheckBox ID="CheckBox3" runat="server" Text="全选" Width="83px" AutoPostBack="True"
                                    OnCheckedChanged="CheckBoxAll3_CheckedChanged" />
                            </td>
                            <td style="width: 38px">
                                <asp:CheckBox ID="CheckBox4" runat="server" Text="反选" Width="141px" AutoPostBack="True"
                                    OnCheckedChanged="Checkfanxuan4_CheckedChanged" />
                            </td>
                            <td style="width: 93px">
                                <asp:Button ID="Button3" OnClientClick="return confirm('将会删除计件补录信息且不可恢复，仍要确定？')"
                                    runat="server" CssClass="Button02" Height="24px" OnClick="Btn3_Click" Text="删除"
                                    Width="70px" />
                            </td>
                            <td style="width: 320px;" align="center">
                                <asp:Button ID="Button15" runat="server" CssClass="Button02" Height="24px" OnClick="Btn15_Click"
                                    Text="保存" Width="70px" />
                            </td>
                            <td align="center" style="width: 320px;">
                                <asp:Button ID="Button16" runat="server" CssClass="Button02" Height="24px" OnClientClick="return confirm('严重警告！提交后不能更改，仍要确认？')"
                                    OnClick="Btn16_Click" Text="提交" Width="70px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
            <asp:Panel ID="Panel3" runat="server" Visible="False">
                <fieldset>
                    <legend>财务审核详细&nbsp;<asp:Label ID="Label22" runat="server"></asp:Label></legend>
                    <asp:Label ID="Label13" runat="server" Text="所选计件提报单号：" Visible="False"></asp:Label>
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
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel4" runat="server" Visible="false">
                <fieldset>
                    <legend>新增详情<asp:Label ID="Label_HRDD_ID" runat="server" Visible="False" Text="'00000000-0000-0000-0000-000000000000'"></asp:Label>
                        <asp:Label ID="Label_WOD_ID" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <table style="width: 100%;">
                        <tr style="width: 100%;">
                            <td align="center" style="width: 14%;">
                                员工：
                            </td>
                            <td align="left" style="width: 63%;">
                                <asp:Label ID="Label53" runat="server" Text="请选择（可多选）" ForeColor="Red"></asp:Label>
                            </td>
                            <td align="left" style="width: 72px">
                                <asp:Button ID="Button11" runat="server" CssClass="Button02" Height="24px" OnClick="Btn11_Click"
                                    Text="选择.." Width="70px" />
                            </td>
                            <td align="left" style="width: 96px">
                            </td>
                        </tr>
                        <tr style="width: 100%;">
                            <td align="center" style="width: 14%;">
                                随工单信息：
                            </td>
                            <td align="left" style="width: 63%;">
                                <asp:Label ID="Label54" runat="server" ForeColor="Red" Text="请选择（单选）"></asp:Label>
                            </td>
                            <td align="left" style="width: 72px">
                                <asp:Button ID="Button12" runat="server" CssClass="Button02" Height="24px" OnClick="Btn12_Click"
                                    Text="选择.." Width="70px" />
                            </td>
                            <td align="center" style="width: 96px">
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
                                <asp:Button ID="Button8" runat="server" CssClass="Button02" Height="24px" OnClick="Btn8_Click"
                                    Text="提交" Width="70px" />
                            </td>
                            <td align="center" style="width: 14%;">
                                &nbsp;
                            </td>
                            <td align="center" style="width: 11%;">
                                <asp:Button ID="Button9" runat="server" CssClass="Button02" Height="24px" OnClick="Button9_Click"
                                    Text="取消" Width="70px" />
                            </td>
                            <td align="left" class="auto-style3" style="width: 127px">
                                &nbsp;
                            </td>
                            <td align="left" style="width: 28px;">
                                &nbsp;
                            </td>
                            <td align="right" style="width: 16%;">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </fieldset>
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
                                <asp:TextBox ID="TextBox4" runat="server" Width="100px"></asp:TextBox>
                            </td>
                            <td style="width: 58px" align="right">
                                姓名：
                            </td>
                            <td style="width: 123px">
                                <asp:TextBox ID="TextBox5" runat="server" Width="100px"></asp:TextBox>
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
                                <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
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
                        PageSize="15" CellPadding="0" UseAccessibleHeader="False" AllowPaging="True"
                        OnPageIndexChanging="GridView_People_PageIndexChanging" AllowSorting="True" Width="100%"
                        DataKeyNames="HRDD_ID,工号,姓名" EmptyDataText="无相关记录!" GridLines="None">
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
                                <asp:CheckBox ID="CheckBox1" runat="server" Text="反选" Width="141px" AutoPostBack="True"
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
    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel5" runat="server" Visible="false">
                <fieldset>
                    <legend>随工单 &nbsp;<asp:Label ID="label_WONum" runat="server"></asp:Label>&nbsp; 详细表
                        <asp:Label ID="label_WO_ID" runat="server" Visible="False" Text="00000000-0000-0000-0000-000000000000"></asp:Label>
                    </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 138px">
                                随工单号：
                            </td>
                            <td style="width: 100px">
                                <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 106px" align="right">
                                &nbsp;产品型号：
                            </td>
                            <td style="width: 58px">
                                <asp:TextBox ID="TextBox13" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 51px">
                                工序:：
                            </td>
                            <td align="center">
                                <asp:TextBox ID="TextBox14" runat="server"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 155px">
                                &nbsp;
                            </td>
                            <td align="center" style="width: 155px">
                                &nbsp;
                            </td>
                            <td align="right">
                                <asp:Button ID="Button10" runat="server" CssClass="Button02" Height="24px" Text="关闭"
                                    Width="70px" OnClick="Button10_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 138px">
                                出站日期：
                            </td>
                            <td style="width: 100px">
                                <asp:TextBox ID="TextBox_tibaoshijian3" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 106px">
                                至
                            </td>
                            <td style="width: 58px">
                                <asp:TextBox ID="TextBox_tibaoshijian4" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"></asp:TextBox>
                            </td>
                            <td style="width: 51px">
                                &nbsp;
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
                        <tr>
                            <td style="width: 138px">
                                &nbsp;
                            </td>
                            <td style="width: 100px">
                                &nbsp;
                            </td>
                            <td style="width: 106px">
                                <asp:Button ID="Button13" runat="server" CssClass="Button02" Height="24px" OnClick="Button13_Click"
                                    Text="检索" Width="70px" />
                            </td>
                            <td style="width: 58px">
                                &nbsp;
                            </td>
                            <td style="width: 51px">
                                <asp:Button ID="Button14" runat="server" CssClass="Button02" Height="24px" OnClick="Button14_Click"
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
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        CellPadding="0" UseAccessibleHeader="False" AllowPaging="True" OnRowCommand="GridView2_RowCommand"
                        Width="100%" DataKeyNames="WOD_ID,随工单号,工序" EmptyDataText="无相关记录!" OnDataBound="GridView2_DataBound"
                        OnPageIndexChanging="GridView2_PageIndexChanging" PageSize="20">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="WOD_ID" SortExpression="WOD_ID" HeaderText="随工单详细ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="随工单号" SortExpression="随工单号" HeaderText="随工单号"></asp:BoundField>
                            <asp:BoundField DataField="产品型号" SortExpression="产品型号" HeaderText="产品型号"></asp:BoundField>
                            <asp:BoundField DataField="顺序" SortExpression="顺序" HeaderText="顺序"></asp:BoundField>
                            <asp:BoundField DataField="工序" SortExpression="工序" HeaderText="工序" ReadOnly="true">
                            </asp:BoundField>
                            <asp:BoundField DataField="班次" SortExpression="班次" HeaderText="班次"></asp:BoundField>
                            <asp:BoundField DataField="进站时间" SortExpression="进站时间" HeaderText="进站时间" DataFormatString="{0:yy-MM-dd HH:mm}"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="出站时间" SortExpression="出站时间" HeaderText="出站时间" DataFormatString="{0:yy-MM-dd HH:mm}"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="进站数" SortExpression="进站数" HeaderText="进站数"></asp:BoundField>
                            <asp:BoundField DataField="合格数" SortExpression="合格数" HeaderText="合格数" ReadOnly="true">
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="xz" runat="server" CommandName="xz" ForeColor="Blue">选择</asp:LinkButton>
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
</asp:Content>
