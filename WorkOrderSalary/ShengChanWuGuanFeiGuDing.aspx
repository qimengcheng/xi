<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Other/MasterPage.master" CodeFile="ShengChanWuGuanFeiGuDing.aspx.cs" Inherits="WorkOrderSalary_ShengChanWuGuanFeiGuDing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel_Search" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Search" runat="server" Visible="true">
                <fieldset>
                    <legend>随工单无关非固定计时提报检索
                        <asp:Label ID="label_pagestate" runat="server" Text="Label" Visible="False"></asp:Label></legend>
                    <table style="width: 100%;">
                        <tr style="width: 100%;">
                            <td align="center" style="width: 11%;">计时项目：</td>
                            <td align="left" class="auto-style3" style="width: 16%;">
                                <asp:TextBox ID="TextBox_xiangmu" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 10%;" align="center">提报人：
                            </td>
                            <td align="center" style="width: 10%;">
                                <asp:TextBox ID="TextBox_tibaoren" runat="server"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 13%;">提报单日期： </td>
                            <td align="center" style="width: 13%;">
                                <asp:TextBox ID="TextBox_WO_Time1" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"></asp:TextBox>
                            </td>
                            <td style="width: 3%;" align="left">至</td>
                            <td align="left" style="width: 17%;">
                                <asp:TextBox ID="TextBox_WO_Time2" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="width: 100%;">
                            <td align="center" style="width: 11%;">初审部门：</td>
                            <td align="left" class="auto-style3" style="width: 16%;">
                                <asp:TextBox ID="TextBox_chusheng" runat="server"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 10%;">初审人：</td>
                            <td align="center" style="width: 10%;">
                                <asp:TextBox ID="TextBox_chushengren" runat="server"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 13%;">提报时间：</td>
                            <td align="center" style="width: 13%;">
                                <asp:TextBox ID="TextBox_tibaoshijian1" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"></asp:TextBox>
                            </td>
                            <td align="left" style="width: 3%;">至</td>
                            <td align="left" style="width: 17%;">
                                <asp:TextBox ID="TextBox_tibaoshijian2" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="width: 100%;">
                            <td align="center" style="width: 11%;">提报单号：</td>
                            <td align="left" class="auto-style3" style="width: 16%;">
                                <asp:TextBox ID="TextBox_NO" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 10%;">人事审核人：</td>
                            <td align="center" style="width: 10%;">
                                <asp:TextBox ID="TextBox_renshishenghe" runat="server"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 13%;">初审时间：</td>
                            <td align="center" style="width: 13%;">
                                <asp:TextBox ID="TextBox_chushengshijian1" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"></asp:TextBox>
                            </td>
                            <td align="left" style="width: 3%;">至</td>
                            <td align="left" style="width: 17%;">
                                <asp:TextBox ID="TextBox_chushengshijian2" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="width: 100%;">
                            <td align="center" style="width: 11%;">状态：</td>
                            <td align="left" class="auto-style3" style="width: 16%;">
                                <asp:DropDownList ID="DropDownList1" runat="server">
                                    <asp:ListItem>请选择</asp:ListItem>
                                    <asp:ListItem>待提交</asp:ListItem>
                                    <asp:ListItem>待初审</asp:ListItem>
                                    <asp:ListItem>人事待审</asp:ListItem>
                                    <asp:ListItem>财务待审</asp:ListItem>
                                    <asp:ListItem>财务通过</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="center" style="width: 10%;">财务审核人：</td>
                            <td align="center" style="width: 10%;">
                                <asp:TextBox ID="TextBox_caiwuren" runat="server"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 13%;">人事审核时间：</td>
                            <td align="center" style="width: 13%;">
                                <asp:TextBox ID="TextBox_renshishijian1" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"></asp:TextBox>
                            </td>
                            <td align="left" style="width: 3%;">至</td>
                            <td align="left" style="width: 17%;">
                                <asp:TextBox ID="TextBox_renshishijian2" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="width: 100%;">
                            <td align="center" style="width: 11%;">&nbsp;</td>
                            <td align="left" class="auto-style3" style="width: 16%;">&nbsp;</td>
                            <td align="center" style="width: 10%;">&nbsp;</td>
                            <td align="center" style="width: 10%;">&nbsp;</td>
                            <td align="center" style="width: 13%;">财务审核时间：</td>
                            <td align="center" style="width: 13%;">
                                <asp:TextBox ID="TextBox_caiwushijian1" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"></asp:TextBox>
                            </td>
                            <td align="left" style="width: 3%;">至</td>
                            <td align="left" style="width: 17%;">
                                <asp:TextBox ID="TextBox_caiwushijian2" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%;">
                        <tr style="width: 100%;">
                            <td align="center" style="width: 13%;">&nbsp;
                            </td>
                            <td align="left" style="width: 22%;">&nbsp;
                            </td>
                            <td align="center" style="width: 15%;">
                                <asp:Button ID="Btn_Search" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_Search_Click"
                                    Text="检索" Width="70px" />
                            </td>
                            <td align="center" style="width: 14%;">
                                <asp:Button ID="Button_AddTeam" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_AddTeam_Click" Text="新增提报单" Width="70px" />
                            </td>
                            <td align="center" style="width: 11%;">
                                <asp:Button ID="Button_Cancel" runat="server" CssClass="Button02" Height="24px" OnClick="Button_Cancel_Click"
                                    Text="重置" Width="70px" />
                            </td>
                            <td align="left" class="auto-style3" style="width: 127px">&nbsp;
                            </td>
                            <td align="left" style="width: 28px;">&nbsp;
                            </td>
                            <td align="right" style="width: 16%;"></td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_NewProjectInfo" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_NewProjectInfo" runat="server" Visible="False">
                <fieldset>
                    <legend>
                        <asp:Label ID="Label1" runat="server" Text="新增提报信息"></asp:Label><asp:Label ID="Label_TNUTID_EDIT" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <table style="width: 100%">
                        <tr>
                            <td align="left" style="width: 10%" height="20px">提报日期：</td>
                            <td align="left" style="width: 158px">
                                <asp:TextBox ID="TextBox_WO_Time12" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"></asp:TextBox>
                                <asp:Label ID="Label18" runat="server" ForeColor="Red" Text="*"></asp:Label>
                            </td>
                            <td align="right" style="width: 74px">计时项目：</td>
                            <td align="left" style="width: 221px">
                                <asp:TextBox ID="TextBox_makepeople7" runat="server" Enabled="False"></asp:TextBox>
                                <asp:Label ID="Label19" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                <asp:Button ID="Button8" runat="server" CssClass="Button02" Text="选择.." Width="52px" Height="20px" OnClick="Button8_Click" />
                            </td>
                            <td align="left">初审部门：<asp:DropDownList ID="DropDownList2" runat="server">
                            </asp:DropDownList>
                                <asp:Label ID="Label20" runat="server" ForeColor="Red" Text="*"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="Label17" runat="server" Visible="False"></asp:Label>
                            </td>
                            <td align="left">&nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 10%">&nbsp;</td>
                            <td align="left" style="width: 158px">&nbsp;</td>
                            <td align="left" style="width: 74px">&nbsp;</td>
                            <td align="left" style="width: 221px">
                                <asp:Button ID="Button6" runat="server" CssClass="Button02" Height="24px" Text="确定" Width="70px" OnClick="Button6_Click" />
                            </td>
                            <td align="left">&nbsp;</td>
                            <td align="left">
                                <asp:Button ID="Button7" runat="server" CssClass="Button02" Height="24px" OnClick="Button7_Click" Text="关闭" Width="70px" />
                            </td>
                            <td align="left">&nbsp;</td>
                        </tr>

                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_AddProject" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_AddProject" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="label_Date2" runat="server"></asp:Label>
                        待选计时项目表
                        <asp:Label ID="Label_TSDD_State" runat="server" Visible="False">      </asp:Label>
                    </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 40px">工序：
                            </td>
                            <td class="auto-style3" style="width: 100px">
                                <asp:TextBox ID="TextBox_AddProject_Craft" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 82px" align="right">计时项目：
                            </td>
                            <td style="width: 106px">
                                <asp:TextBox ID="TextBox_AddProject_Project" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 58px">&nbsp;
                            </td>
                            <td style="width: 51px">
                                <asp:Button ID="Button_AddProject_Search" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_AddProject_Search_Click" Text="检索" Width="70px" />
                            </td>
                            <td align="center"></td>
                            <td align="center" style="width: 155px">
                                <asp:Button ID="ButtonButton_AddProject_Cancel" runat="server" CssClass="Button02"
                                    Height="24px" OnClick="ButtonButton_AddProject_Cancel_Click" Text="重置" Width="70px" />
                            </td>
                            <td align="right"></td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView_AddProject" runat="server" AutoGenerateColumns="false"
                        CssClass="GridViewStyle" PageSize="10" CellPadding="0" UseAccessibleHeader="False"
                        AllowPaging="True" OnPageIndexChanging="GridView_AddProject_PageIndexChanging"
                        AllowSorting="True" Width="100%" DataKeyNames="STI_ID,STI_Name" EmptyDataText="无相关记录!"
                        GridLines="None" OnRowCommand="GridView_AddProject_RowCommand">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="STI_ID" HeaderText="计时项目ID" Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="PBC_Name" HeaderText="工序" ItemStyle-Width="40%"></asp:BoundField>
                            <asp:BoundField DataField="STI_Name" HeaderText="计时项目" ItemStyle-Width="40%"></asp:BoundField>
                            <asp:TemplateField ItemStyle-Width="20%">
                                <ItemTemplate>
                                    <asp:LinkButton ID="xz" runat="server" CommandArgument='<%#Eval("STI_ID") +","+ Eval("STI_Name")%>'
                                        CommandName="xz">选择</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">第 &nbsp;<asp:Label ID="lblPageIndex" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
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
                            <td align="center">
                                <asp:Button ID="Button4" runat="server" CssClass="Button02" Height="24px" OnClick="Button_Close_Click"
                                    Text="关闭" Width="70px" />
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
                    <legend>计时计件日核算表<asp:Label ID="label_GridPageState" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <asp:GridView ID="GridView_WOmain" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        PageSize="30" CellPadding="0" UseAccessibleHeader="False" AllowPaging="True" OnRowCommand="GridView_WOmain_RowCommand"
                        OnPageIndexChanging="GridView_WOmain_PageIndexChanging" AllowSorting="True" Width="100%"
                        DataKeyNames="TNUT_ID,TI_ID,TNUT_Date,STI_Name,BDOS_Name,TNUT_NO,TNUT_Auditor,TNUT_AuTime,TNUT_AuRes,TNUT_AuSuggs,TNUT_RSAuditor,TNUT_RSTime,TNUT_RSResult,TNUT_RSSuggs,TNUT_CWAuditor,TNUT_CWTime,TNUT_CWReult,TNUT_CWSuggs,TNUT_State" EmptyDataText="无相关记录!" GridLines="None" OnDataBound="GridView_WOmain_DataBound" OnRowDataBound="GridView_WOmain_RowDataBound">
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
                            <asp:BoundField DataField="TNUT_ID" SortExpression="TNUT_ID" HeaderText="提报ID" Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="TI_ID" SortExpression="TI_ID" HeaderText="计时项目ID" Visible="False"></asp:BoundField>
                            <asp:BoundField DataField="TNUT_NO" SortExpression="TNUT_NO" HeaderText="提报单号"></asp:BoundField>
                            <asp:BoundField DataField="TNUT_Date" SortExpression="TNUT_NO" HeaderText="所属日期" DataFormatString="{0:yy-MM-dd}"></asp:BoundField>
                            <asp:BoundField DataField="STI_Name" SortExpression="STI_Name" HeaderText="计时项目"></asp:BoundField>
                            <asp:BoundField DataField="TNUT_SubmitMan" SortExpression="TNUT_SubmitMan" HeaderText="提报人"></asp:BoundField>
                            <asp:BoundField DataField="TNUT_SubmitTime" SortExpression="TNUT_SubmitTime" HeaderText="提报时间" DataFormatString="{0:yy-MM-dd HH:mm}"></asp:BoundField>
                            <asp:BoundField DataField="TNUT_State" SortExpression="TNUT_State" HeaderText="状态"></asp:BoundField>
                            <asp:BoundField DataField="TNUT_Auditor" SortExpression="TNUT_Auditor" HeaderText="初审人"></asp:BoundField>
                            <asp:BoundField DataField="BDOS_Name" SortExpression="BDOS_Name" HeaderText="初审部门"></asp:BoundField>
                            <asp:BoundField DataField="TNUT_AuTime" SortExpression="TNUT_AuTime" HeaderText="初审时间" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundField>
                            <asp:BoundField DataField="TNUT_AuRes" SortExpression="TNUT_AuRes" HeaderText="初审结果"></asp:BoundField>
                            <asp:BoundField DataField="TNUT_AuSuggs" SortExpression="TNUT_AuSuggs" HeaderText="初审意见"></asp:BoundField>
                            <asp:BoundField DataField="TNUT_RSAuditor" SortExpression="TNUT_RSAuditor" HeaderText="人事审核人" Visible="False"></asp:BoundField>
                            <asp:BoundField DataField="TNUT_RSTime" SortExpression="TNUT_RSTime" HeaderText="人事审核时间" DataFormatString="{0:yyyy-MM-dd}" Visible="False"></asp:BoundField>
                            <asp:BoundField DataField="TNUT_RSResult" SortExpression="TNUT_RSResult" HeaderText="人事结果" Visible="False"></asp:BoundField>
                            <asp:BoundField DataField="TNUT_RSSuggs" SortExpression="TNUT_RSSuggs" HeaderText="人事意见" Visible="False"></asp:BoundField>
                            <asp:BoundField DataField="TNUT_CWAuditor" SortExpression="TNUT_CWAuditor" HeaderText="财务审核人" Visible="False"></asp:BoundField>
                            <asp:BoundField DataField="TNUT_CWTime" SortExpression="TNUT_CWTime" HeaderText="财务审核时间" DataFormatString="{0:yyyy-MM-dd}" Visible="False"></asp:BoundField>
                            <asp:BoundField DataField="TNUT_CWReult" SortExpression="TNUT_CWReult" HeaderText="财务结果" Visible="False"></asp:BoundField>
                            <asp:BoundField DataField="TNUT_CWSuggs" SortExpression="TNUT_CWSuggs" HeaderText="财务意见" Visible="False"></asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="EDIT123" runat="server" CommandName="EDIT123" CommandArgument='<%#Eval("TNUT_ID") %>'>编辑</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="DeleteWTP" runat="server" CommandName="DeleteWTP" CommandArgument='<%#Eval("TNUT_ID") %>'
                                        OnClientClick="return confirm('将会删除计时计件信息，确定吗？')">删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Detail123" runat="server" CommandName="Detail123" CommandArgument='<%#Eval("TNUT_ID") %>'>详情</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">第 &nbsp;<asp:Label ID="lblPageIndex" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
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
                            <td style="width: 310px;"></td>
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
                                    OnClick="Button_AddPTToSeries_Click" Text="初审审核" Width="70px" />
                            </td>
                            <td style="width: 320px;"></td>
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
                        <asp:Label ID="label2" runat="server"></asp:Label>
                        提报单详情表
                           <asp:Label ID="Label_TNUT_ID" runat="server" Visible="False" />
                    </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 65px">工号：
                            </td>
                            <td style="width: 100px">
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 82px" align="right">姓名：
                            </td>
                            <td style="width: 106px">
                                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 58px">&nbsp;
                            </td>
                            <td style="width: 51px">
                                <asp:Button ID="Button1" runat="server" CssClass="Button02" Height="24px"
                                    Width="70px" OnClick="Button1_Click" Text="检索" />
                            </td>
                            <td align="center"></td>
                            <td align="center" style="width: 155px">
                                <asp:Button ID="Button2" runat="server" CssClass="Button02"
                                    Height="24px" Text="重置" Width="70px" OnClick="Button2_Click" />
                            </td>
                            <td align="center" style="width: 155px">
                                <asp:Button ID="Button10" runat="server" CssClass="Button02" Height="24px" OnClick="Button10_Click" Text="添加员工" Width="70px" />
                            </td>
                            <td align="right">
                                <asp:Button ID="Button3" runat="server" CssClass="Button02" Height="24px" Text="关闭" Width="70px" OnClick="Button3_Click" />
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"
                        CssClass="GridViewStyle" PageSize="30" CellPadding="0" UseAccessibleHeader="False"
                        AllowPaging="True" OnPageIndexChanging="GridView_AddProject_PageIndexChanging"
                        AllowSorting="True" Width="100%" DataKeyNames="TNUD_ID" EmptyDataText="无相关记录!"
                        GridLines="None" OnRowCommand="GridView_AddProject_RowCommand">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemStyle Width="3%" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="TNUD_ID" HeaderText="详细ID" Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="HRDD_StaffNO" HeaderText="工号"></asp:BoundField>
                            <asp:BoundField DataField="HRDD_Name" HeaderText="姓名"></asp:BoundField>
                            <asp:BoundField DataField="TNUD_TimeLength" HeaderText="计时时长"></asp:BoundField>
                            <asp:TemplateField HeaderText="计时时长" SortExpression="TNUD_TimeLength" Visible="true">
                                <ItemTemplate>
                                    <asp:TextBox ID="txttime" runat="server" Width="85%" Text='<%#Eval("TNUD_TimeLength")%>'></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle Font-Bold="True" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="TNUD_Num" HeaderText="产量"></asp:BoundField>
                            <asp:TemplateField HeaderText="产量" SortExpression="TNUD_Num" Visible="true">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtnum" runat="server" Width="85%" Text='<%#Eval("TNUD_Num")%>'></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle Font-Bold="True" />
                            </asp:TemplateField>

                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">第 &nbsp;<asp:Label ID="lblPageIndex" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
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
                            <td style="width: 46px;">
                                <asp:CheckBox ID="CheckBoxAll" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBoxAll_CheckedChanged" Style="margin-left: 0px" Text="全选" Width="55px" />
                            </td>
                            <td style="width: 28px">
                                <asp:CheckBox ID="CheckBoxfanxuan" runat="server" AutoPostBack="True" OnCheckedChanged="Checkfanxuan_CheckedChanged" Text="反选" Width="103px" />
                            </td>
                            <td>
                                <asp:Button ID="Btn_deleting" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_deleting_Click" Text="删除" Width="70px" />
                            </td>
                            <td>
                                <asp:Button ID="Btn_deleting0" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_tj_Click" Text="提交" Width="70px" />
                            </td>
                            <td>
                                <asp:Button ID="Btn_deleting1" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_save_Click" Text="保存" Width="70px" />
                            </td>
                            <td>&nbsp;</td>
                            <td style="width: 320px;" align="right">&nbsp;</td>
                        </tr>
                    </table>

                </fieldset>
            </asp:Panel>
            <asp:Panel ID="Panel3" runat="server" Visible="False">
                <fieldset>
                    <legend>人事、财务审核详细&nbsp;<asp:Label ID="Label22" runat="server" ></asp:Label></legend>
                    <asp:Label ID="Label13" runat="server" Text="所选提待审报单：" Visible="False"></asp:Label>
                    <asp:Label ID="Label14" runat="server"  Visible="False"></asp:Label>
                    <asp:Label ID="Label21" runat="server"  Visible="False"></asp:Label>
                    <table style="width: 100%;">
                        <tr>
                            <td></td>
                            <td></td>
                            <td align="right">
                                <asp:Button ID="Button_AddPeople_close0" runat="server" CssClass="Button02" Height="24px" OnClick="Button_AddPeople_close0_Click" Text="关闭审核页面" Width="90px" />
                            </td>
                        </tr>

                    </table>

                    <table width="100%">
                        <tr>
                            <td style="width: 126px" align="right">初审审核人：
                            </td>
                            <td style="width: 94px">
                                <asp:Label ID="Label4" runat="server"></asp:Label>
                            </td>
                            <td style="width: 89px" align="right">初审审核时间：
                            </td>
                            <td style="width: 123px" align="left">
                                <asp:Label ID="Label6" runat="server"></asp:Label>
                            </td>
                            <td style="width: 196px">初审部门：<asp:Label ID="Label53" runat="server"></asp:Label>
                            </td>
                            <td>初审审核结果：<asp:Label ID="label7" runat="server" ForeColor="Red" Visible="true"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%">
                        <tr>
                            <td align="right" style="width: 15%">
                                <asp:Label ID="Label10" runat="server" Text="初审审核意见：</br>(400字符以内)"></asp:Label>
                            </td>
                            <td align="left" colspan="7">
                                <asp:TextBox ID="TextBox4" runat="server" Enabled="True" Height="98px" MaxLength="200"
                                    TextMode="MultiLine" onkeyup="this.value = this.value.substring(0, 400)" onafterpaste="this.value = this.value.substring(0, 1000)"
                                    Width="93%"></asp:TextBox>
                                <asp:Label ID="Label11" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="1"></td>
                            <td align="center" colspan="2">
                                <asp:Button ID="Button5" runat="server" CssClass="Button02" Height="24px" OnClick="cstg_Click"
                                    Text="通过" Width="70px" />
                            </td>
                            <td align="center" colspan="3">
                                <asp:Button ID="Button9" runat="server" CssClass="Button02" Height="24px" OnClick="csbh_Click"
                                    Text="不通过" Width="70px" />
                            </td>
                            <td align="center" colspan="2"></td>
                        </tr>
                    </table>
                    <table width="100%">
                        <tr>
                            <td style="width: 126px" align="right">人事审核人：
                            </td>
                            <td style="width: 94px">
                                <asp:Label ID="Label15" runat="server"></asp:Label>
                            </td>
                            <td style="width: 89px" align="right">人事审核时间：
                            </td>
                            <td style="width: 123px" align="left">
                                <asp:Label ID="Label5" runat="server"></asp:Label>
                            </td>
                            <td style="width: 196px">&nbsp;</td>
                            <td>人事审核结果：<asp:Label ID="label51" runat="server" ForeColor="Red" Visible="true"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%">
                        <tr>
                            <td align="right" style="width: 15%">
                                <asp:Label ID="Label8" runat="server" Text="人事审核意见：</br>(400字以内)"></asp:Label>
                            </td>
                            <td align="left" colspan="7">
                                <asp:TextBox ID="TextBox3" runat="server" Enabled="True" Height="98px" MaxLength="200"
                                    TextMode="MultiLine" onkeyup="this.value = this.value.substring(0, 400)" onafterpaste="this.value = this.value.substring(0, 1000)"
                                    Width="93%"></asp:TextBox>
                                <asp:Label ID="Label9" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="1"></td>
                            <td align="center" colspan="2">
                                <asp:Button ID="sctg" runat="server" CssClass="Button02" Height="24px" OnClick="sctg_Click"
                                    Text="通过" Width="70px" />
                            </td>
                            <td align="center" colspan="3">
                                <asp:Button ID="scbh" runat="server" CssClass="Button02" Height="24px" OnClick="scbh_Click"
                                    Text="不通过" Width="70px" />
                            </td>
                            <td align="center" colspan="2"></td>
                        </tr>
                    </table>
                    <table width="100%">
                        <tr>
                            <td style="width: 126px" align="right">财务审核人：
                            </td>
                            <td style="width: 94px">
                                <asp:Label ID="Label41" runat="server"></asp:Label>
                            </td>
                            <td style="width: 89px" align="right">财务审核时间：
                            </td>
                            <td style="width: 123px" align="left">
                                <asp:Label ID="Label42" runat="server"></asp:Label>
                            </td>
                            <td style="width: 196px"></td>
                            <td>财务审核结果：<asp:Label ID="label52" runat="server" ForeColor="Red" Visible="true"></asp:Label>
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
                            <td align="center" colspan="1"></td>
                            <td align="center" colspan="2">
                                <asp:Button ID="pbtg" runat="server" CssClass="Button02" Height="24px" OnClick="pbtg_Click"
                                    Text="通过" Width="70px" />
                            </td>
                            <td align="center" colspan="3">
                                <asp:Button ID="pbbh" runat="server" CssClass="Button02" Height="24px" OnClick="pbbh_Click"
                                    Text="不通过" Width="70px" />
                            </td>
                            <td align="center" colspan="2"></td>
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
                        <asp:Label ID="label3" runat="server"></asp:Label>
                        添加员工
                        <asp:Label ID="label12" runat="server" Visible="False" Text="00000000-0000-0000-0000-000000000000"></asp:Label>
                    </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 63px">工号：
                            </td>
                            <td class="auto-style3" style="width: 100px">
                                <asp:TextBox ID="TextBox5" runat="server" Width="100px"></asp:TextBox>
                            </td>
                            <td style="width: 58px" align="right">姓名：
                            </td>
                            <td style="width: 123px">
                                <asp:TextBox ID="TextBox6" runat="server" Width="100px"></asp:TextBox>
                            </td>
                            <td style="width: 58px">&nbsp;
                            </td>
                            <td style="width: 51px">&nbsp;</td>
                            <td align="center" style="width: 97px">选择班组：</td>
                            <td align="left" style="width: 171px">
                                <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
                                </asp:DropDownList>

                            </td>
                            <td align="right" style="width: 155px">&nbsp;
                            </td>
                            <td align="right">
                                <asp:Button ID="Button_AddPeople_close" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_AddPeople_close_Click" Text="关闭" Width="80px" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 63px">&nbsp;</td>
                            <td class="auto-style3" style="width: 100px">&nbsp;</td>
                            <td align="right" style="width: 58px">&nbsp;</td>
                            <td style="width: 123px">
                                <asp:Button ID="Button_AddPeopleSearch" runat="server" CssClass="Button02" Height="24px" OnClick="Button_AddPeopleSearch_Click" Text="检索" Width="80px" />
                            </td>
                            <td style="width: 58px">&nbsp;</td>
                            <td style="width: 51px">&nbsp;</td>
                            <td align="center" style="width: 97px">&nbsp;</td>
                            <td align="center" style="width: 171px">
                                <asp:Button ID="Button_AddPeopleCancel" runat="server" CssClass="Button02" Height="24px" OnClick="Button_AddPeopleCancel_Click" Text="重置" Width="80px" />
                            </td>
                            <td align="right" style="width: 155px">&nbsp;</td>
                            <td align="right">&nbsp;</td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView_People" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        PageSize="20" CellPadding="0" UseAccessibleHeader="False" AllowPaging="True" OnPageIndexChanging="GridView_People_PageIndexChanging"
                        AllowSorting="True" Width="100%" DataKeyNames="HRDD_ID" EmptyDataText="无相关记录!"
                        GridLines="None">
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
                            <asp:BoundField DataField="工号" SortExpression="工号" HeaderText="工号"
                                ItemStyle-Width="45%" ReadOnly="True"></asp:BoundField>
                            <asp:BoundField DataField="姓名" SortExpression="姓名" HeaderText="姓名"
                                ItemStyle-Width="45%" ReadOnly="True"></asp:BoundField>
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">第 &nbsp;<asp:Label ID="lblPageIndex" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
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
                                    OnCheckedChanged="CheckBoxAll2_NEW_CheckedChanged" />
                            </td>
                            <td style="width: 38px">
                                <asp:CheckBox ID="CheckBox3" runat="server" Text="反选" Width="141px" AutoPostBack="True"
                                    OnCheckedChanged="Checkfanxuan2_NEW_CheckedChanged" />
                            </td>
                            <td style="width: 93px">
                                <asp:Button ID="Button_CheckboxAddProject2" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_CheckboxAddProject2_Click" Text="添加" Width="80px" />
                            </td>
                            <td>&nbsp;
                            </td>
                            <td>&nbsp;
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
