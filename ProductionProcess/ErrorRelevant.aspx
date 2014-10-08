<%@ Page Title="" Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true"
    CodeFile="ErrorRelevant.aspx.cs" Inherits="ProductionProcess_ErrorRelevant" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel_Search" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Search" runat="server" Visible="true">
                <fieldset>
                    <legend>随工单检索 <asp:Label ID="label_pagestate" runat="server" Visible="False"/></legend>
                    <table style="width: 100%; height: 23px;">
                        <tr style="width: 100%;">
                            <td style="width: 13%;" align="center">
                                &nbsp;随工单号：
                            </td>
                            <td style="width: 8%;" align="left">
                                <asp:TextBox ID="TextBox_wonum" runat="server" Width="100px"></asp:TextBox>
                            </td>
                            <td style="width: 6%;" align="center">
                                类型：
                            </td>
                            <td style="width: 9%;">
                                <asp:DropDownList ID="DropDownList_WO_Type" runat="server">
                                    <asp:ListItem Value="">请选择</asp:ListItem>
                                    <asp:ListItem>正常</asp:ListItem>
                                    <asp:ListItem>实验</asp:ListItem>
                                    <asp:ListItem>检验</asp:ListItem>
                                    <asp:ListItem>返工</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="center" style="width: 11%;">
                                型号
                            </td>
                            <td align="left" style="width: 70px;">
                                <asp:TextBox ID="TextBox_pt" runat="server" Width="100px"></asp:TextBox>
                            </td>
                            <td style="width: 16%;" align="center">
                                开始时间：
                            </td>
                            <td style="width: 15%;" align="left">
                                <asp:TextBox ID="TextBox_WO_Time1" Width="100px" runat="server"  
                                    onfocus="new WdatePicker(this,'%Y-%M-%D',true)"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 3%;">
                                至
                            </td>
                            <td align="left" style="width: 15%;">
                                <asp:TextBox ID="TextBox_WO_Time2" Width="100px" runat="server"  
                                    onfocus="new WdatePicker(this,'%Y-%M-%D',true)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="width: 100%;">
                            <td style="width: 13%;" align="center">
                                &nbsp;所在工序：
                            </td>
                            <td style="width: 8%;" align="left">
                                <asp:TextBox ID="TextBox_PBC" runat="server" Width="100px"></asp:TextBox>
                            </td>
                            <td style="width: 9%" align="center">
                                &nbsp;档次：
                            </td>
                            <td style="width: 9%" align="left">
                                <asp:DropDownList ID="DropDownList_level" runat="server">
                                    <asp:ListItem Value="">请选择</asp:ListItem>
                                    <asp:ListItem>A档</asp:ListItem>
                                    <asp:ListItem>B档</asp:ListItem>
                                    <asp:ListItem>C档</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="width: 11%;" align="center">
                                芯片代码：
                            </td>
                            <td style="width: 10%;" align="left">
                                <asp:TextBox ID="TextBox_chipnum" runat="server" Width="100px"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 7%;">
                                &nbsp;
                            </td>
                            <td align="left" style="width: 15%;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr style="width: 100%;">
                            <td style="width: 13%;" align="center">
                                订单号：
                            </td>
                            <td style="width: 8%;" align="left">
                                <asp:TextBox ID="TextBox_OrderNum" runat="server" Width="100px"></asp:TextBox>
                            </td>
                            <td style="width: 9%" align="center">
                                状态：
                            </td>
                            <td style="width: 9%" align="left">
                                <asp:DropDownList ID="DropDownList_WoState" runat="server">
                                    <asp:ListItem Value="">请选择</asp:ListItem>
                                    <asp:ListItem>已生成</asp:ListItem>
                                    <asp:ListItem>已打印</asp:ListItem>
                                    <asp:ListItem>已分单</asp:ListItem>
                                    <asp:ListItem>工序开启</asp:ListItem>
                                    <asp:ListItem>工序完工</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="width: 11%;" align="center">
                                周期码：
                            </td>
                            <td style="width: 10%;" align="left">
                                <asp:TextBox ID="TextBox_WOSN" runat="server" Width="100px"></asp:TextBox>
                            </td>
                            <td align="right" style="width: 7%;">
                                &nbsp;
                            </td>
                            <td align="left" style="width: 15%;">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td style="width: 204px">
                            </td>
                            <td style="width: 95px">
                                
                              
                            </td>
                            <td style="width: 97px" class="style1">
                            <asp:Button ID="Btn_Search" runat="server" Text="检索" Width="70px" Height="24px" CssClass="Button02"
                                    OnClick="Btn_Search_Click" />
                            </td>
                            <td>
                              

                            </td>
                            <td style="width: 70px">
                                 
                            </td>
                            <td>
                                <asp:Button ID="Button_Cancel" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_Cancel_Click" Text="重置" Width="70px" />
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
                    <legend>随工单信息表
                        <asp:Label ID="label_GridPageState" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <asp:GridView ID="GridView_WOmain" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        PageSize="5" CellPadding="0" UseAccessibleHeader="False" AllowPaging="True" OnRowCommand="GridView_WOmain_RowCommand"
                        OnPageIndexChanging="GridView_WOmain_PageIndexChanging" AllowSorting="True" OnSorting="GridView_WOmain_Sorting"
                        OnRowDataBound="GridView_WOmain_RowDataBound" Width="100%" DataKeyNames="WO_ID"
                        EmptyDataText="无相关记录!" GridLines="None" OnDataBound="GridView_WOmain_DataBound"
                        OnLoad="GridView_WOmain_Load">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="WO_ID" SortExpression="WO_ID" HeaderText="随工单信息ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="WOD_ID" SortExpression="WOD_ID" HeaderText="随工单详细ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="WO_Num" SortExpression="WO_Num" HeaderText="随工单号" ReadOnly="true">
                            </asp:BoundField>
                            <asp:BoundField DataField="WO_Type" SortExpression="WO_Type" HeaderText="类型" ReadOnly="true">
                            </asp:BoundField>
                            <asp:BoundField DataField="WO_State" SortExpression="WO_State" HeaderText="状态" ReadOnly="true">
                            </asp:BoundField>
                            <asp:BoundField DataField="WO_OrderNum" SortExpression="WO_OrderNum" HeaderText="订单号"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WO_ProType" SortExpression="WO_ProType" HeaderText="产品型号"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WO_SN" SortExpression="WO_SN" HeaderText="周期码" ReadOnly="true">
                            </asp:BoundField>
                            <asp:BoundField DataField="WO_Level" SortExpression="WO_Level" HeaderText="档次" ReadOnly="true">
                            </asp:BoundField>
                            <asp:BoundField DataField="WO_ChipNum" SortExpression="WO_ChipNum" HeaderText="芯片代码"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="PBC_Name" SortExpression="PBC_Name" HeaderText="工序" ReadOnly="true">
                            </asp:BoundField>
                            <asp:BoundField DataField="WOD_StaTime" SortExpression="WOD_StaTime" HeaderText="开始时间"
                                ReadOnly="true" DataFormatString="{0:yyyy-MM-dd HH:mm}"></asp:BoundField>
                            <asp:BoundField DataField="WOD_Error" SortExpression="WOD_Error" HeaderText="是否异常"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WOD_OverTime" SortExpression="WOD_OverTime" HeaderText="是否超时"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WO_PNum" SortExpression="WO_PNum" HeaderText="计划数量" ReadOnly="true">
                            </asp:BoundField>
                            <asp:BoundField DataField="WO_Note" SortExpression="WO_Note" HeaderText="备注" ReadOnly="true">
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="ErrorInfo" runat="server" CommandArgument='<%#Eval("WO_ID") +","+ Eval("WOD_ID") %>'
                                        CommandName="ErrorInfo">异常信息</asp:LinkButton>
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
    <asp:UpdatePanel ID="UpdatePanel_ErrorList" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_ErrorList" runat="server" Visible="false">
                <fieldset>
                    <legend>异常信息表
                        <asp:Label ID="label_wodid" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <asp:GridView ID="GridView_Error" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        CellPadding="0" UseAccessibleHeader="False" AllowPaging="false" Width="100%"
                        DataKeyNames="WOE_ID" EmptyDataText="无相关记录!" GridLines="None" OnDataBound="GridView_Error_DataBound"
                        OnRowCommand="GridView_Error_RowCommand">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="WOE_ID" SortExpression="WOE_ID" HeaderText="异常信息ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="EPO_Name" SortExpression="EPO_Name" HeaderText="异常选项"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WOE_Detail" SortExpression="WOE_Detail" HeaderText="描述"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WOE_State" SortExpression="WOE_State" HeaderText="状态"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WOE_QOption" SortExpression="WOE_QOption" HeaderText="质量选项"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WOE_Type" SortExpression="WOE_Type" HeaderText="类型" ReadOnly="true">
                            </asp:BoundField>
                            <asp:BoundField DataField="WOE_Dep" SortExpression="WOE_Dep" HeaderText="处理部门" ReadOnly="true">
                            </asp:BoundField>
                            <asp:BoundField DataField="WOE_NeedMQC" SortExpression="WOE_NeedMQC" HeaderText="需材料检验"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WOE_Measure" SortExpression="WOE_Measure" HeaderText="临时措施"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WOE_People" SortExpression="WOE_People" HeaderText="申报人"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WOE_Time" SortExpression="WOE_Time" HeaderText="申报时间" DataFormatString="{0:yyyy-MM-dd HH:mm}"
                                ReadOnly="true"></asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="cailiao" runat="server" CommandArgument='<%#Eval("WOE_ID")%>'
                                        CommandName="cailiao">材料检验</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="chuli" runat="server" CommandArgument='<%#Eval("WOE_ID")%>' CommandName="chuli">处理</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="genzhong" runat="server" CommandArgument='<%#Eval("WOE_ID")%>'
                                        CommandName="genzhong">跟踪</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="sh" runat="server" CommandArgument='<%#Eval("WOE_ID")+","+ Eval("WOE_QOption")%>'
                                        CommandName="sh">审核</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="cs" runat="server" CommandArgument='<%#Eval("WOE_ID")+","+ Eval("WOE_QOption")%>'
                                        CommandName="cs">会签</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="recover" runat="server" CommandArgument='<%#Eval("WOE_ID")+","+ Eval("WOE_State")%>'
                                        CommandName="recover">结案</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Rework" runat="server" CommandArgument='<%#Eval("WOE_ID")+","+ Eval("WOE_State")%>'
                                        CommandName="Rework">返工</asp:LinkButton>
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
    <asp:UpdatePanel ID="UpdatePanel_M" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_M" runat="server" Visible="False">
                <fieldset>
                    <legend>材料检验
                        <asp:Label ID="label_M_WOEID" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 89px">
                                材料检验人：
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox_MM" runat="server" Enabled="False"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 89px">
                                材料检验时间：
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox_MT" runat="server" Enabled="False"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 89px">
                                材料检验结果 ：
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox_MR" runat="server" Width="568px"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%;">
                        <tr>
                            <td>
                            </td>
                            <td align="center">
                                <asp:Button ID="Btn_M_Confirm" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_M_Confirm_Click"
                                    Text="确定" Width="70px" />
                            </td>
                            <td align="center">
                                <asp:Button ID="Btn_M_Cancel" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_M_Cancel_click"
                                    Text="关闭" Width="70px" />
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_Error" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Error" runat="server" Visible="False">
                <fieldset>
                    <legend>异常处理
                        <asp:Label ID="label_ED_WOEID" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 89px">
                                处理人：
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox_DealMan" runat="server" Enabled="False"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 89px">
                                处理时间：
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox_DealTime" runat="server" Enabled="False" DataFormatString="{0:yyyy-MM-dd HH:mm}"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 89px">
                                原因分析：
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox_ReaAnalysis" runat="server" Width="568px"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 89px">
                                产品处理：
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox_ProDeal" runat="server" Width="568px"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 89px">
                                长期对策：
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox_LongTimeMeasure" runat="server" Width="568px"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%;">
                        <tr>
                            <td>
                            </td>
                            <td align="center">
                                <asp:Button ID="Btn_ErrorDealer_Confirm" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Btn_ErrorDealer_Confirm_Click" Text="确定" Width="70px" />
                            </td>
                            <td align="center">
                                <asp:Button ID="Btn_ErrorDealer_Cancel" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Btn_ErrorDealer_Cancel_Click" Text="关闭" Width="70px" />
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_Track" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Track" runat="server" Visible="False">
                <fieldset>
                    <legend>异常跟踪
                        <asp:Label ID="label_Track_WOEID" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 89px">
                                跟踪人：
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox_TrackMan" runat="server" Enabled="False"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 89px">
                                跟踪时间：
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox_TrackTime" runat="server" DataFormatString="{0:yyyy-MM-dd HH:mm}"
                                    Enabled="False"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 89px">
                                跟踪结果：
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox_TrackResult" runat="server" Width="568px"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%;">
                        <tr>
                            <td>
                            </td>
                            <td align="center">
                                <asp:Button ID="Btn_ErrorTrack_Confirm" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Btn_ErrorTrack_Confirm_Click" Text="确定" Width="70px" />
                            </td>
                            <td align="center">
                                <asp:Button ID="Btn_ErrorTrack_Cancel" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Btn_ErrorTrack_Cancel_Click" Text="关闭" Width="70px" />
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_C" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_C" runat="server" Visible="False">
                <fieldset>
                    <legend>异常会签表
                        <asp:Label ID="label_CS_WOEID" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        CellPadding="0" UseAccessibleHeader="False" AllowPaging="false" OnRowCommand="GridView_WOmain_RowCommand"
                        OnPageIndexChanging="GridView_WOmain_PageIndexChanging" AllowSorting="True" OnSorting="GridView_WOmain_Sorting"
                        OnRowDataBound="GridView_WOmain_RowDataBound" Width="100%" DataKeyNames="WO_ID"
                        EmptyDataText="无相关记录!" GridLines="None" OnDataBound="GridView_WOmain_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="WO_ID" SortExpression="WO_ID" HeaderText="随工单信息ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="WO_Num" SortExpression="WO_Num" HeaderText="会签部门" ReadOnly="true">
                            </asp:BoundField>
                            <asp:BoundField DataField="WO_Type" SortExpression="WO_Type" HeaderText="会签状态" ReadOnly="true">
                            </asp:BoundField>
                            <asp:BoundField DataField="WO_State" SortExpression="WO_State" HeaderText="会签结果"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="SMSO_ComOrderNum" SortExpression="SMSO_ComOrderNum" HeaderText="会签意见"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WO_ProType" SortExpression="WO_ProType" HeaderText="会签人"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WO_SN" SortExpression="WO_SN" HeaderText="会签时间" ReadOnly="true">
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="BasicInfo" runat="server" CommandArgument='<%#Eval("WO_ID") +","+ Eval("WO_ProType") %>'
                                        CommandName="BasicInfo">会签</asp:LinkButton>
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
    <asp:UpdatePanel ID="UpdatePanel_Recover" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Recover" runat="server" Visible="False">
                <fieldset>
                    <legend>异常结案
                        <asp:Label ID="label_Recover_WOEID" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 89px">
                                结案人：
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox_WOE_DoneMan" runat="server" Enabled="False"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 89px">
                                结案时间：
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox_WOE_DoneTime" runat="server" Enabled="False" DataFormatString="{0:yyyy-MM-dd HH:mm}"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 89px">
                                QC判定：
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox_WOE_QCResult" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 89px">
                                结案结果：
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox_WOE_DoneResult" runat="server" Width="568px"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 89px">
                                异常恢复：
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownList_Recovery" runat="server">
                                    <asp:ListItem>请选择</asp:ListItem>
                                    <asp:ListItem>是</asp:ListItem>
                                    <asp:ListItem>否</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%;">
                        <tr>
                            <td>
                            </td>
                            <td align="center">
                                <asp:Button ID="Btn_ErrorRecover_Confirm" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Btn_ErrorRecover_Confirm_Click" Text="确定" Width="70px" />
                            </td>
                            <td align="center">
                                <asp:Button ID="Btn_ErrorRecover_Cancel" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Btn_ErrorRecover_Cancel_Click" Text="关闭" Width="70px" />
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_Review" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Review" runat="server" Visible="False">
                <fieldset>
                    <legend>异常审核
                        <asp:Label ID="label_SH_WOEID" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 89px">
                                审核人：
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox_ReviewMan" runat="server" Enabled="False"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 89px">
                                审核时间：
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox_ReviewTime" runat="server" Enabled="False" DataFormatString="{0:yyyy-MM-dd HH:mm}"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 89px">
                                审核结果：
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownList_RResult" runat="server">
                                    <asp:ListItem>请选择</asp:ListItem>
                                    <asp:ListItem>通过</asp:ListItem>
                                    <asp:ListItem>不通过</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 89px">
                                审核意见：
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox_ReviewSuggestion" runat="server" Width="568px"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%;">
                        <tr>
                            <td>
                            </td>
                            <td align="center">
                                <asp:Button ID="Button1" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_Review_Confirm_Click"
                                    Text="确定" Width="70px" />
                            </td>
                            <td align="center">
                                <asp:Button ID="Button2" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_Review_Cancel_Click"
                                    Text="关闭" Width="70px" />
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_ReWork" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_ReWork" runat="server" Visible="False">
                <fieldset>
                    <legend>异常返工
                        <asp:Label ID="label_ReWork_WOEID" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 89px">
                                返工申请人：
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox_ReworkAppMan" runat="server" Enabled="False"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 89px">
                                返工申请时间：
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox_ReWorkTime" runat="server" Enabled="False" DataFormatString="{0:yyyy-MM-dd HH:mm}"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 89px">
                                返工原因选项：
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownList_ReworkOption" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 89px">
                                返工工序：
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownList_PBC" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 89px">
                                预计返工日期：
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox_ReWorkDate" runat="server" 
                                    DataFormatString="{0:yyyy-MM-dd HH:mm}"  
                                    onfocus="new WdatePicker(this,'%Y-%M-%D',false)"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 89px">
                                返工数量：
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox_ReworkNum" runat="server"  onkeyup="this.value=this.value.replace(/\D/g,'')"
                                    onafterpaste="this.value=this.value.replace(/\D/g,'')" MaxLength="8"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 89px">
                                返工描述：
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox_ReworkDetail" runat="server" Width="568px"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%;">
                        <tr>
                            <td>
                            </td>
                            <td align="center">
                                <asp:Button ID="Button3" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_Rework_Confirm_Click"
                                    Text="确定" Width="70px" />
                            </td>
                            <td align="center">
                                <asp:Button ID="Button4" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_Rework_Cancel_Click"
                                    Text="关闭" Width="70px" />
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
