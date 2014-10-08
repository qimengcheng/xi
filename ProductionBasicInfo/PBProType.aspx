<%@ Page Title="" Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true"
    CodeFile="PBProType.aspx.cs" Inherits="ProductionBasicInfo_PBProType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel_Search" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Search" runat="server" Visible="true">
                <asp:Label ID="ptid" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="Label_Grid1_Color" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="Label_sort" runat="server"></asp:Label>
                <asp:Label ID="Label_Grid1_State" runat="server" Text="默认数据源" Visible="False"></asp:Label>
                <asp:Label ID="Label_Search" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="label_pagestate" runat="server" Visible="False"></asp:Label>
                <fieldset>
                    <legend>产品查询</legend>
                    <table style="width: 100%;">
                        <tr style="width: 100%;">
                            <td style="width: 11%;">
                                产品系列：
                            </td>
                            <td style="width: 14%;" align="left">
                                <asp:TextBox ID="Txt_search" runat="server" Width="100px"></asp:TextBox>
                            </td>
                            <td style="width: 8%;">
                                产品型号：
                            </td>
                            <td style="width: 16%;" align="left">
                                <asp:TextBox ID="Txt_search0" runat="server" Width="100px"></asp:TextBox>
                            </td>
                            <td style="width: 9%;" align="center">
                                所属BOM：
                            </td>
                            <td style="width: 16%;" align="left">
                                <asp:TextBox ID="TextBox1" runat="server" Width="100px"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 11%;">
                                所属工艺路线：
                            </td>
                            <td align="left" style="width: 35%;">
                                <asp:TextBox ID="TextBox2" runat="server" Width="100px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="width: 100%;">
                            <td style="width: 11%;">
                                是否特殊产品：
                            </td>
                            <td align="left" style="width: 14%;">
                                <asp:DropDownList ID="DropDownList1" runat="server">
                                    <asp:ListItem Value="">请选择</asp:ListItem>
                                    <asp:ListItem>否</asp:ListItem>
                                    <asp:ListItem>是</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="width: 8%;">
                                &nbsp;录入人：
                            </td>
                            <td align="left" style="width: 16%;">
                                <asp:TextBox ID="Txt_search1" runat="server" Width="100px"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 9%;">
                                录入时间：
                            </td>
                            <td align="left" style="width: 16%;">
                                <asp:TextBox ID="TextBox_WO_Time1" Width="100px" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"></asp:TextBox>
                            </td>
                            <td align="left" style="width: 11%;">
                                至
                            </td>
                            <td align="left" style="width: 35%;">
                                <asp:TextBox ID="TextBox_WO_Time2" Width="100px" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr style="width: 100%;">
                            <td style="width: 8%;">
                            </td>
                            <td style="width: 11%;">
                            </td>
                            <td style="width: 8%;">
                            </td>
                            <td align="center" style="width: 18%;">
                                <asp:Button ID="Btn_Search" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_Search_Click"
                                    Text="检索" Width="70px" />
                            </td>
                            <td align="center" style="width: 7%;">
                                <asp:Button ID="Button_Cancel" runat="server" CssClass="Button02" Height="24px" OnClick="Button_Cancel_Click"
                                    Text="重置" Width="70px" />
                            </td>
                            <td align="center" style="width: 35%;">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_PT" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_PT" runat="server">
                <fieldset>
                    <legend>产品型号表</legend>
                    <table style="width: 100%;">
                        <tr style="width: 100%;">
                            <td style="width: 10%;">
                            </td>
                            <td style="width: 21%;">
                            </td>
                            <td style="width: 15%;" align="center">
                            </td>
                            <td style="width: 15%;" align="center">
                            </td>
                            <td style="width: 15%;" align="center">
                            </td>
                            <td style="width: 35%;" align="right">
                                <asp:Button ID="Button_returnspecial" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_return" Text="返回" Width="90px" Visible="False" />
                                <asp:Button ID="Button_Add" runat="server" CssClass="Button02" Height="24px" OnClick="Button_Add_Click"
                                    Text="新增产品" Width="90px" />
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        Font-Strikeout="False" GridLines="None" PageSize="15" CellPadding="0" UseAccessibleHeader="False"
                        AllowPaging="True" OnRowCommand="GridView2_RowCommand" OnPageIndexChanging="GridView2_PageIndexChanging"
                        AllowSorting="True" OnSorting="GridView2_Sorting" Width="100%" DataKeyNames="PT_ID"
                        EmptyDataText="无相关记录!" OnDataBound="GridView2_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="PT_ID" HeaderText="产品型号ID" SortExpression="PT_ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="PS_ID" HeaderText="产品系列ID" SortExpression="PS_ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="PT_Name" SortExpression="PT_Name" HeaderText="产品型号"></asp:BoundField>
                            <asp:BoundField DataField="PT_Note" SortExpression="PT_Note" HeaderText="备注"></asp:BoundField>
                            <asp:BoundField DataField="PT_Parameters" HeaderText="产品测试参数" SortExpression="PT_Parameters">
                            </asp:BoundField>
                            <asp:BoundField DataField="PS_Name" SortExpression="PS_Name" HeaderText="产品系列"></asp:BoundField>
                            <asp:BoundField DataField="PT_Code" SortExpression="PT_Code" HeaderText="产品编码"></asp:BoundField>
                            <asp:BoundField DataField="PT_Special" SortExpression="PT_Special" HeaderText="特殊产品">
                            </asp:BoundField>
                            <asp:BoundField DataField="BOM_Name" SortExpression="BOM_Name" HeaderText="BOM名称">
                            </asp:BoundField>
                            <asp:BoundField DataField="BOM_ID" SortExpression="BOM_ID" HeaderText="BOMID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="PR_Name" SortExpression="PR_Name" HeaderText="工艺路线"></asp:BoundField>
                            <asp:BoundField DataField="PR_ID" SortExpression="PR_ID" HeaderText="工艺路线ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="PT_Man" SortExpression="PT_Man" HeaderText="制定人"></asp:BoundField>
                            <asp:BoundField DataField="PT_Time" SortExpression="PT_Time" HeaderText="制定时间" DataFormatString="{0:yyyy-MM-dd HH:mm}">
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Edit123" runat="server" CommandArgument='<%# Eval("PT_Name")+","+Eval("PT_Special")+","+Eval("PR_ID")+","+Eval("BOM_ID")+","+Eval("PT_ID") +","+Eval("PS_Name")+","+Eval("PS_ID")+","+Eval("PT_Parameters")+","+Eval("PT_Code")+","+Eval("PT_Note")%>'
                                        CommandName="Edit123">编辑</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete_PT" runat="server" CommandArgument='<%# Eval("PT_ID")+","+Eval("PT_Name") %>'
                                        CommandName="Delete_PT" OnClientClick="return confirm('您确认删除该记录吗?')">删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Check_Parameter" runat="server" CommandArgument='<%# Eval("BOM_ID")+","+Eval("PT_Name")+","+Eval("PT_ID") %>'
                                        CommandName="Check_Parameter">基础信息</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Check_RZ" runat="server" CommandArgument='<%# Eval("BOM_ID")+","+Eval("PT_Name")+","+Eval("PT_ID") %>'
                                        CommandName="Check_RZ">认证路线</asp:LinkButton>
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
                                        <%--<asp:textbox id="txtNewPageIndex" runat="server" width="20px" text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />--%>
                                        <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                            CommandName="Page" Text="GO" />
                                        <!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
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
    <asp:UpdatePanel ID="UpdatePanel_AddPT" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_AddPT" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="Label_submitState" runat="server"></asp:Label>
                        <asp:Label ID="Label_PT_ID" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="Label_PRID" runat="server" Visible="False"></asp:Label>
                        产品型号<asp:Label ID="Label_ptname" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="Label_code" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 87px">
                                产品型号:
                            </td>
                            <td style="width: 224px">
                                <asp:TextBox ID="Txt_PT" runat="server" MaxLength="30" Width="95%"></asp:TextBox>
                                <asp:Label ID="Label21" runat="server" ForeColor="Red" Text="*"></asp:Label>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%">
                        <tr>
                            <td align="left" colspan="2">
                                产品编码：
                            </td>
                            <td align="center">
                                &nbsp;
                            </td>
                            <td align="center">
                                &nbsp;
                            </td>
                            <td align="center">
                                &nbsp;
                            </td>
                            <td align="center">
                                &nbsp;
                            </td>
                            <td align="center">
                                &nbsp;
                            </td>
                            <td align="center">
                                &nbsp;
                            </td>
                            <td align="center">
                                &nbsp;
                            </td>
                            <td align="center">
                                &nbsp;
                            </td>
                            <td align="center">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                物料类别
                            </td>
                            <td align="center">
                                封装结构
                            </td>
                            <td align="center">
                                电流
                            </td>
                            <td align="center">
                                电压
                            </td>
                            <td align="center">
                                芯片厂家
                            </td>
                            <td align="center">
                                芯片大小
                            </td>
                            <td align="center">
                                引脚方式
                            </td>
                            <td align="center">
                                包装方式
                            </td>
                            <td align="center">
                                电性情况
                            </td>
                            <td align="center">
                                外观情况
                            </td>
                            <td align="center">
                                特殊码
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:DropDownList ID="DropDownList01" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList01_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownList02" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList02_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownList03" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList03_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownList04" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList04_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownList05" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList05_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownList06" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList06_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownList07" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList07_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownList08" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList08_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownList09" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList09_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownList10" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList10_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownList11" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList11_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 86px">
                                产品备注：
                            </td>
                            <td colspan="9">
                                <asp:TextBox ID="TextBox4" runat="server" Width="575px"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 86px">
                                所属系列：
                            </td>
                            <td style="width: 6px">
                                <asp:DropDownList ID="DropDownList2" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 6px">
                                <asp:Label ID="Label22" runat="server" ForeColor="Red" Text="*"></asp:Label>
                            </td>
                            <td style="width: 99px">
                                是否特殊产品：
                            </td>
                            <td style="width: 11px">
                                <asp:DropDownList ID="DropDownList_Special" runat="server">
                                    <asp:ListItem Text="否" Value="否"></asp:ListItem>
                                    <asp:ListItem Text="是" Value="是"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="width: 11px">
                                <asp:Label ID="Label23" runat="server" ForeColor="Red" Text="*"></asp:Label>
                            </td>
                            <td>
                                BOM：
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownList_BOM" runat="server" Height="16px">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="Label24" runat="server" ForeColor="Red" Text="*"></asp:Label>
                            </td>
                            <td>
                                &nbsp;工艺路线：
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownList_PR" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="Label25" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <table runat="server" id="cscs" width="100%">
                        <tr id="cs0">
                            <td style="width: 86px">
                                测试参数类别：
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownList12" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList12_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 99px">
                                详细项目：
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownList13" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td align="left">
                                <asp:Button ID="Btn_Search0" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_Add0_Click"
                                    Text="添加" Width="70px" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td align="right">
                                <asp:Button ID="Btn_copy" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_copy_Click"
                                    Text="复制其它型号测试参数" Width="150px" />
                            </td>
                        </tr>
                        <tr id="cs1">
                            <td style="width: 86px">
                                产品测试参数：
                            </td>
                            <td colspan="7">
                                <asp:TextBox ID="TextBox3" runat="server" Width="95%" Enabled="False"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridViewips" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        Font-Strikeout="False" GridLines="None" PageSize="15" CellPadding="0" UseAccessibleHeader="False"
                        AllowPaging="false" OnRowCommand="GridViewips_RowCommand" AllowSorting="True"
                        Width="100%" DataKeyNames="PTIPS_ID" EmptyDataText="无相关记录!">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="PTIPS_ID" HeaderText="产品型号ID" SortExpression="PTIPS_ID"
                                Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="IPSM_Type" SortExpression="IPSM_Type" HeaderText="测试参数类别">
                            </asp:BoundField>
                            <asp:BoundField DataField="IPSD_Type" SortExpression="IPSD_Type" HeaderText="详细">
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete_PTIPS" runat="server" CommandArgument='<%# Eval("PTIPS_ID") %>'
                                        CommandName="Delete_PTIPS" OnClientClick="return confirm('您确认删除该记录吗?')">删除</asp:LinkButton>
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
                                        <%--<asp:textbox id="txtNewPageIndex" runat="server" width="20px" text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />--%>
                                        <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                            CommandName="Page" Text="GO" />
                                        <!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
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
                            <td style="width: 52px">
                            </td>
                            <td align="left" style="width: 32px">
                            </td>
                            <td align="center">
                            </td>
                            <td align="center">
                            </td>
                            <td align="center" style="width: 130px">
                                <asp:Button ID="Btn_AddPT_Submit" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Btn_AddPTSubmit_Click" Text="提交" Width="70px" />
                            </td>
                            <td>
                            </td>
                            <td align="center" style="width: 161px">
                                <asp:Button ID="Btn_CancelPT" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_CancelPT_Click"
                                    Text="关闭" Width="70px" />
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" Visible="False">
                <fieldset>
                    <legend>待选产品型号表</legend>
                    <table style="width: 100%;">
                        <tr style="width: 100%;">
                            <td style="width: 10%;">
                                产品系列：
                            </td>
                            <td style="width: 21%;">
                                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 15%;" align="center">
                                产品型号：
                            </td>
                            <td style="width: 15%;" align="center">
                                <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 15%;" align="center">
                                <asp:Button ID="Btn_Search1" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_Search1_Click"
                                    Text="检索" Width="70px" />
                            </td>
                            <td style="width: 35%;" align="center">
                                <asp:Button ID="Btn_qx" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_qx_Click"
                                    Text="取消" Width="70px" />
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        Font-Strikeout="False" GridLines="None" PageSize="10" CellPadding="0" UseAccessibleHeader="False"
                        AllowPaging="True" OnRowCommand="GridView1_RowCommand" OnPageIndexChanging="GridView1_PageIndexChanging"
                        Width="100%" DataKeyNames="PT_ID" EmptyDataText="无相关记录!" OnDataBound="GridView1_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="PT_ID" HeaderText="产品型号ID" SortExpression="PT_ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="PS_ID" HeaderText="产品系列ID" SortExpression="PS_ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="PS_Name" SortExpression="PS_Name" HeaderText="产品系列"></asp:BoundField>
                            <asp:BoundField DataField="PT_Name" SortExpression="PT_Name" HeaderText="产品型号"></asp:BoundField>
                            <asp:BoundField DataField="PT_Note" SortExpression="PT_Note" HeaderText="备注"></asp:BoundField>
                            <asp:BoundField DataField="PT_Code" SortExpression="PT_Code" HeaderText="编码含义"></asp:BoundField>
                            <asp:BoundField DataField="PT_Parameters" SortExpression="PT_Parameters" HeaderText="测试参数">
                            </asp:BoundField>
                            <asp:BoundField DataField="PT_Special" SortExpression="PT_Special" HeaderText="是否特殊产品">
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="select1" runat="server" CommandArgument='<%# Eval("PT_ID")%>'
                                        CommandName="select1">选择</asp:LinkButton>
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
                                        <%--<asp:textbox id="txtNewPageIndex" runat="server" width="20px" text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />--%>
                                        <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                            CommandName="Page" Text="GO" />
                                        <!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
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
    <asp:UpdatePanel ID="UpdatePanel_basic" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_basic" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="Label_PT" runat="server">
                        </asp:Label>
                        <asp:Label ID="Label_WOID" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="Label_Type" runat="server" Visible="False"></asp:Label>
                        &nbsp;产品基础信息表 </legend>
                    <asp:Label ID="Label_Material" runat="server" Text="物料清单(BOM)"></asp:Label>
                    <asp:GridView ID="GridView_bom" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        CellPadding="0" UseAccessibleHeader="False" AllowSorting="True" Width="100%"
                        DataKeyNames="BD_ID" EmptyDataText="无相关记录!" GridLines="None" OnDataBound="GridView_bom_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="BD_ID" SortExpression="BD_ID" HeaderText="BOM详细ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_MaterialID" SortExpression="IMMBD_MaterialID" HeaderText="物料ID"
                                Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="IMMBD_MaterialName" SortExpression="IMMBD_MaterialName"
                                HeaderText="物料名称"></asp:BoundField>
                            <asp:BoundField DataField="IMMBD_SpecificationModel" SortExpression="IMMBD_SpecificationModel"
                                HeaderText="规格型号"></asp:BoundField>
                            <asp:BoundField DataField="UnitName" SortExpression="UnitName" HeaderText="用量单位">
                            </asp:BoundField>
                            <asp:BoundField DataField="BD_MUse" SortExpression="BD_MUse" HeaderText="标准用量"></asp:BoundField>
                            <asp:BoundField DataField="BD_MRUse" SortExpression="BD_MRUse" HeaderText="实际用量">
                            </asp:BoundField>
                            <asp:BoundField DataField="BD_Note" SortExpression="BD_Note" HeaderText="备注"></asp:BoundField>
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
                                        <%--<asp:textbox id="txtNewPageIndex" runat="server" width="20px" text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />--%>
                                        <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                            CommandName="Page" Text="GO" />
                                        <!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
                                    </td>
                                </tr>
                            </table>
                        </PagerTemplate>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label16" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <asp:Label ID="Label_pr" runat="server" Text="工艺路线(流程)"></asp:Label><br />
                    <asp:Label ID="Label20" runat="server" ForeColor="Red"></asp:Label>
                    <asp:GridView ID="GridView_Pr" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        CellPadding="0" UseAccessibleHeader="False" OnRowCommand="GridView_Pr_RowCommand"
                        AllowSorting="True" Width="100%" DataKeyNames="PRD_ID" EmptyDataText="无相关记录!"
                        GridLines="None" OnDataBound="GridView_Pr_DataBound" OnRowDataBound="GridView_Pr_RowDataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="PRD_ID" SortExpression="PRD_ID" HeaderText="工艺路线详细id"
                                Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="PBC_ID" SortExpression="PBC_ID" HeaderText="工序ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="PRD_Order" SortExpression="PRD_Order" HeaderText="排序">
                            </asp:BoundField>
                            <asp:BoundField DataField="PRD_RenZhengOrder" SortExpression="PRD_RenZhengOrder"
                                HeaderText="认证工序排序"></asp:BoundField>
                            <asp:BoundField DataField="PRD_RouteOrder" SortExpression="PRD_RouteOrder" HeaderText="认证路线排序">
                            </asp:BoundField>
                            <asp:BoundField DataField="PBC_Name" SortExpression="PBC_Name" HeaderText="工序名称">
                            </asp:BoundField>
                            <asp:BoundField DataField="PRD_Doc" SortExpression="PRD_Doc" HeaderText="相关文件"></asp:BoundField>
                            <asp:BoundField DataField="PRD_Way" SortExpression="PRD_Way" HeaderText="管控方式"></asp:BoundField>
                            <asp:BoundField DataField="PRD_Note" SortExpression="PRD_Note" HeaderText="备注"></asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Batch_Num" runat="server" CommandArgument='<%# Eval("PBC_ID")+","+Eval("PBC_Name") %>'
                                        CommandName="Batch_Num">工艺参数</asp:LinkButton>
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
                                        <%--<asp:textbox id="txtNewPageIndex" runat="server" width="20px" text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />--%>
                                        <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                            CommandName="Page" Text="GO" />
                                        <!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
                                    </td>
                                </tr>
                            </table>
                        </PagerTemplate>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label16" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="Label_TestParameter" runat="server" Text="产品测试参数: "></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox_TestParameter" runat="server" Width="660px" Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td align="center">
                                <asp:Button ID="Button_Close_ChoseBatch0" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Btn_Close_ChooseBatch0_Click" Text="关闭" Width="70px" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_CheckParameter" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_CheckParameter" runat="server" Visible="false">
                <fieldset>
                    <legend>查看产品<asp:Label ID="Label_PT2" runat="server"></asp:Label>
                        工艺参数<asp:Label ID="Label_PBCID" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <table style="width: 100%;">
                        <tr style="width: 100%;">
                            <td style="width: 22%;">
                                工艺参数:
                            </td>
                            <td style="width: 50%;">
                                <asp:TextBox ID="Txt_parameter" runat="server" Width="500px" MaxLength="100"></asp:TextBox>
                            </td>
                            <td style="width: 12.5%;" align="right">
                            </td>
                        </tr>
                        <tr style="width: 100%;">
                            <td style="width: 22%;">
                                合格率标准（0至1之间的小数）：
                            </td>
                            <td style="width: 12.5%;">
                                <asp:TextBox ID="Txt_PassRate" Style="ime-mode: disabled" runat="server" Width="500px"
                                    onKeyPress="if (event.keyCode!=46 && event.keyCode!=45 && (event.keyCode<48 || event.keyCode>57)) event.returnValue=false"
                                    MaxLength="100"></asp:TextBox>
                            </td>
                            <td style="width: 12.5%;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr style="width: 100%;">
                            <td style="width: 22%;">
                                备注：(100字以内)
                            </td>
                            <td style="width: 12.5%;">
                                <asp:TextBox ID="TextBox_Note" runat="server" Width="500px" MaxLength="100"></asp:TextBox>
                            </td>
                            <td style="width: 12.5%;">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%;">
                        <tr>
                            <td align="center" style="width: 160px">
                                &nbsp;
                            </td>
                            <td align="center" style="width: 195px">
                                <asp:Button ID="Btn_I_parameter" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Btn_I_parameter_Click" Text="提交" Width="70px" />
                            </td>
                            <td align="center" style="width: 195px">
                                <asp:Button ID="Btn_Close_CheckParameter" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_Close_CheckParameter_Click" Text="关闭" Width="70px" />
                            </td>
                            <td>
                                &nbsp;
                                <asp:Button ID="Btn_U_parameter" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Btn_U_parameter_Click" Text="修改参数" Width="70px" Visible="False" />
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
