<%@ Page Title="" Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true"
    CodeFile="ErrorNew.aspx.cs" Inherits="ProductionProcess_ErrorNew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel_Search" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Search" runat="server" Visible="true">
                <fieldset>
                    <legend>随工单检索
                        <asp:Label ID="label_pagestate" runat="server" Visible="False"></asp:Label></legend>
                    <table style="width: 100%; height: 23px;">
                        <tr style="width: 100%;">
                            <td style="width: 13%;" align="center">&nbsp;随工单号：
                            </td>
                            <td style="width: 8%;" align="left">
                                <asp:TextBox ID="TextBox_wonum" runat="server" Width="100px"></asp:TextBox>
                            </td>
                            <td style="width: 6%;" align="center">类型：
                            </td>
                            <td style="width: 9%;">
                                <asp:DropDownList ID="DropDownList_WO_Type" runat="server">
                                    <asp:ListItem Value="">请选择</asp:ListItem>
                                    <asp:ListItem>正常</asp:ListItem>
                                    <asp:ListItem>实验</asp:ListItem>
                                    <asp:ListItem>技术</asp:ListItem>
                                    <asp:ListItem>检验</asp:ListItem>
                                    <asp:ListItem>返工</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="center" style="width: 11%;">型号
                            </td>
                            <td align="left" style="width: 70px;">
                                <asp:TextBox ID="TextBox_pt" runat="server" Width="100px"></asp:TextBox>
                            </td>
                            <td style="width: 16%;" align="center">开始时间：
                            </td>
                            <td style="width: 15%;" align="left">
                                <asp:TextBox ID="TextBox_WO_Time1" Width="100px" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D %h:%m',true)"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 3%;">至
                            </td>
                            <td align="left" style="width: 15%;">
                                <asp:TextBox ID="TextBox_WO_Time2" Width="100px" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D %h:%m',true)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="width: 100%;">
                            <td style="width: 13%;" align="center">&nbsp;所在工序：
                            </td>
                            <td style="width: 8%;" align="left">
                                <asp:TextBox ID="TextBox_PBC" runat="server" Width="100px"></asp:TextBox>
                            </td>
                            <td style="width: 9%" align="center">&nbsp;状态：
                            </td>
                            <td style="width: 9%" align="left">
                                <asp:DropDownList ID="DropDownList_WoState" runat="server">
                                    <asp:ListItem Value="">请选择</asp:ListItem>
                                    <asp:ListItem>已建立</asp:ListItem>
                                    <asp:ListItem>待入库</asp:ListItem>
                                    <asp:ListItem>已分单</asp:ListItem>
                                    <asp:ListItem>工序已开启</asp:ListItem>
                                    <asp:ListItem>工序已完工</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="width: 11%;" align="center">&nbsp;周期码：
                            </td>
                            <td style="width: 10%;" align="left">
                                <asp:TextBox ID="TextBox_WOSN" runat="server" Width="100px"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 7%;">工序：
                            </td>
                            <td align="left" style="width: 15%;">
                                <asp:DropDownList ID="DropDownList3" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td align="center">至
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownList4" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr style="width: 100%;">
                            <td style="width: 13%;" align="center">订单号：
                            </td>
                            <td style="width: 8%;" align="left">
                                <asp:TextBox ID="TextBox_OrderNum" runat="server" Width="100px"></asp:TextBox>
                            </td>
                            <td style="width: 9%" align="center">&nbsp;异常：
                            </td>
                            <td style="width: 9%" align="left">
                                <asp:DropDownList ID="DropDownList1" runat="server">
                                    <asp:ListItem>请选择</asp:ListItem>
                                    <asp:ListItem>是</asp:ListItem>
                                    <asp:ListItem>否</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="width: 11%;" align="center">超时：
                            </td>
                            <td style="width: 10%;" align="left">
                                <asp:DropDownList ID="DropDownList2" runat="server">
                                    <asp:ListItem>请选择</asp:ListItem>
                                    <asp:ListItem>否</asp:ListItem>
                                    <asp:ListItem>是</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="center" style="width: 7%;">材料批号：
                            </td>
                            <td align="left" style="width: 15%;">
                                <asp:TextBox ID="TextBox_WOSN0" runat="server" Width="100px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <table width="100%">
                        <tr>
                            <td style="width: 204px"></td>
                            <td style="width: 95px"></td>
                            <td style="width: 97px" class="style1">
                                <asp:Button ID="Btn_Search" runat="server" Text="检索" Width="70px" Height="24px" CssClass="Button02"
                                    OnClick="Btn_Search_Click" />
                            </td>
                            <td style="width: 70px"></td>
                            <td>
                                <asp:Button ID="Button_Cancel" runat="server" CssClass="Button02" Height="24px" OnClick="Button_Cancel_Click"
                                    Text="重置" Width="70px" />
                            </td>
                            <td>&nbsp;
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
                     <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                        <ProgressTemplate>
                            <div align="center">
                                <img src="..\images\loading1.gif" alt="Wait" />
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <asp:GridView ID="GridView_WOmain" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        PageSize="10" CellPadding="0" UseAccessibleHeader="False" AllowPaging="True"
                        OnRowCommand="GridView_WOmain_RowCommand" OnPageIndexChanging="GridView_WOmain_PageIndexChanging"
                        OnRowDataBound="GridView_WOmain_RowDataBound" Width="100%" DataKeyNames="WO_ID"
                        EmptyDataText="无相关记录!" GridLines="None" OnDataBound="GridView_WOmain_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="WO_ID" SortExpression="WO_ID" HeaderText="随工单信息ID" Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="WOD_ID" SortExpression="WOD_ID" HeaderText="随工单详细ID" Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="WO_Num" SortExpression="WO_Num" HeaderText="随工单号" ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WO_FirstInNum" SortExpression="WO_FirstInNum" HeaderText="总投入数"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WO_Type" SortExpression="WO_Type" HeaderText="类型" ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="PBC_Name" SortExpression="PBC_Name" HeaderText="工序" ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WO_State" SortExpression="WO_State" HeaderText="状态" ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WO_OrderNum" SortExpression="WO_OrderNum" HeaderText="订单号"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WO_ProType" SortExpression="WO_ProType" HeaderText="产品型号"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WO_SN" SortExpression="WO_SN" HeaderText="周期码" ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WOD_InTime" SortExpression="WOD_InTime" HeaderText="开始时间"
                                ReadOnly="true" DataFormatString="{0:yyyy-MM-dd HH:mm}"></asp:BoundField>
                            <asp:BoundField DataField="WOD_Error" SortExpression="WOD_Error" HeaderText="异常"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WOD_OverTime" SortExpression="WOD_OverTime" HeaderText="超时"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WO_Note" SortExpression="WO_Note" HeaderText="备注" ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="pihao" SortExpression="pihao" HeaderText="材料批号" ReadOnly="true"></asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="BasicInfo" runat="server" CommandArgument='<%#Eval("WO_ID") +","+ Eval("WO_Num") %>'
                                        CommandName="BasicInfo">详情</asp:LinkButton>
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
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" Visible="false">
                <fieldset>
                    <table style="width: 100%;">
                        <tr>
                            <td>&nbsp;
                            </td>
                            <td>&nbsp;
                            </td>
                            <td align="right">
                                <asp:Button ID="Button_Cancel0" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_Cancel0_Click" Text="关闭" Width="70px" />
                            </td>
                        </tr>
                    </table>
                    <legend>随工单 &nbsp;<asp:Label ID="label_WONum" runat="server"></asp:Label>&nbsp; 详细表
                        <asp:Label ID="label_WO_ID" runat="server" Visible="False" Text="00000000-0000-0000-0000-000000000000"></asp:Label>
                    </legend>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        CellPadding="0" UseAccessibleHeader="False" AllowPaging="false" OnRowCommand="GridView1_RowCommand"
                        Width="100%" DataKeyNames="WOD_ID" EmptyDataText="无相关记录!" OnDataBound="GridView1_DataBound"
                        OnRowDataBound="GridView1_RowDataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="WOD_ID" SortExpression="WOD_ID" HeaderText="随工单详细ID" Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="WOD_PBCOrder" SortExpression="WOD_PBCOrder" HeaderText="顺序"></asp:BoundField>
                            <asp:BoundField DataField="PBC_ID" SortExpression="PBC_ID" HeaderText="工序" ReadOnly="true"
                                Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="PBC_Name" SortExpression="PBC_Name" HeaderText="工序" ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WOD_Class" SortExpression="WOD_Class" HeaderText="班次"></asp:BoundField>
                            <asp:BoundField DataField="equip" SortExpression="equip" HeaderText="设备" ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WOD_InTime" SortExpression="WOD_InTime" HeaderText="进站时间"
                                DataFormatString="{0:yyyy-MM-dd HH:mm}" ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WOD_OutTime" SortExpression="WOD_OutTime" HeaderText="出站时间"
                                DataFormatString="{0:yyyy-MM-dd HH:mm}" ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WOD_InNum" SortExpression="WOD_InNum" HeaderText="投入数"></asp:BoundField>
                            <asp:BoundField DataField="WOD_QNum" SortExpression="WOD_QNum" HeaderText="合格数" ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="QRATE" SortExpression="QRATE" HeaderText="合格率" ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="bad" SortExpression="bad" HeaderText="不良品" ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WOD_WNum" SortExpression="WOD_WNum" HeaderText="废品" ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WOD_Error" SortExpression="WOD_Error" HeaderText="异常"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WOD_OverTime" SortExpression="WOD_OverTime" HeaderText="超时"
                                ReadOnly="true"></asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="ycsb" runat="server" CommandArgument='<%#Eval("WOD_ID") +","+ Eval("PBC_Name") %>'
                                        CommandName="ycsb">异常申报</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="ycck" runat="server" CommandArgument='<%#Eval("WOD_ID") +","+ Eval("PBC_Name") %>'
                                        CommandName="ycck">异常查看</asp:LinkButton>
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
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_ErrorList" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_ErrorList" runat="server" Visible="false">
                <fieldset>
                    <legend>异常信息表
                        <asp:Label ID="label_wodid" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="label_PBCForList" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td>&nbsp;
                            </td>
                            <td>&nbsp;
                            </td>
                            <td align="right">
                                <asp:Button ID="Button_Cancel1" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_Cancel1_Click" Text="关闭" Width="70px" />
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView_Error" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        CellPadding="0" UseAccessibleHeader="False" AllowPaging="false" Width="100%"
                        DataKeyNames="WOE_ID,WOE_DealMan,WOE_Dep,WOE_Measure,WOE_DealTime,WOE_SCHQMan,WOE_SCHQTime,WOE_SCHQDept,WOE_SCHQResult,WOE_SCHQSuggestion,WOE_PBHQMan,WOE_PBHQtime,WOE_PBHQResult,WOE_PBHQSuggestion,WOE_GCHQMan,WOE_GCHQtime,WOE_GCHQResult,WOE_GCHQSuggestion,WOE_TrackMan,WOE_TrackResult,WOE_TrackSuggestion,WOE_TrackDep,WOE_TrackTime" EmptyDataText="无相关记录!"
                        GridLines="None" OnDataBound="GridView_Error_DataBound" OnRowCommand="GridView_Error_RowCommand" OnRowDataBound="GridView_Error_RowDataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="WOE_ID" SortExpression="WOE_ID" HeaderText="异常信息ID" Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="EPO_Name" SortExpression="EPO_Name" HeaderText="异常类别"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="EPOD_Name" SortExpression="EPOD_Name" HeaderText="异常详细项目"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WOE_Detail" SortExpression="WOE_Detail" HeaderText="描述"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WOE_State" SortExpression="WOE_State" HeaderText="状态"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WOE_People" SortExpression="WOE_People" HeaderText="申报人"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WOE_ApplyDepartMent" SortExpression="WOE_ApplyDepartMent"
                                HeaderText="申请部门" ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WOE_Time" SortExpression="WOE_Time" HeaderText="申报时间"
                                DataFormatString="{0:yyyy-MM-dd HH:mm}" ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WOE_Time" SortExpression="WOE_Time" HeaderText="生产部完成时间"
                                DataFormatString="{0:yyyy-MM-dd HH:mm}" ReadOnly="true" Visible="False"></asp:BoundField>
                            <asp:BoundField DataField="WOE_DealMan" SortExpression="WOE_DealMan" HeaderText="处理人"
                                ReadOnly="true" Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="WOE_Dep" SortExpression="WOE_Dep" HeaderText="处理部门" ReadOnly="true"
                                Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="WOE_Measure" SortExpression="WOE_Measure" HeaderText="处理措施"
                                ReadOnly="true" Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="WOE_DealTime" SortExpression="WOE_DealTime" HeaderText="处理时间"
                                DataFormatString="{0:yyyy-MM-dd HH:mm}" ReadOnly="true" Visible="false"></asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="pbyccl" runat="server" CommandArgument='<%#Eval("WOE_ID")+","+ Eval("EPO_Name")+","+ Eval("EPOD_Name")+","+ Eval("WOE_People")+","+ Eval("WOE_ApplyDepartMent")+","+ Eval("WOE_Time","{0:yyyy-MM-dd HH:mm}")+","+ Eval("WOE_Detail")+","+ Eval("WOE_DealTime","{0:yyyy-MM-dd HH:mm}") %>'
                                        ForeColor="Gray" CommandName="pbyccl">品保异常处理</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="gcyccl" runat="server" CommandArgument='<%#Eval("WOE_ID")+","+ Eval("EPO_Name")+","+ Eval("EPOD_Name")+","+ Eval("WOE_People")+","+ Eval("WOE_ApplyDepartMent")+","+ Eval("WOE_Time","{0:yyyy-MM-dd HH:mm}")+","+ Eval("WOE_Detail")+","+ Eval("WOE_DealTime","{0:yyyy-MM-dd HH:mm}") %>'
                                        ForeColor="Gray" CommandName="gcyccl">工程异常处理</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="scyccl" runat="server" CommandArgument='<%#Eval("WOE_ID")+","+ Eval("EPO_Name")+","+ Eval("EPOD_Name")+","+ Eval("WOE_People")+","+ Eval("WOE_ApplyDepartMent")+","+ Eval("WOE_Time","{0:yyyy-MM-dd HH:mm}")+","+ Eval("WOE_Detail")+","+ Eval("WOE_DealTime","{0:yyyy-MM-dd HH:mm}")%>'
                                        ForeColor="Gray" CommandName="scyccl">生产异常处理</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="schq" runat="server" CommandArgument='<%#Eval("WOE_ID")+","+ Eval("EPO_Name")+","+ Eval("EPOD_Name")+","+ Eval("WOE_People")+","+ Eval("WOE_ApplyDepartMent")+","+ Eval("WOE_Time","{0:yyyy-MM-dd HH:mm}")+","+ Eval("WOE_Detail")+","+ Eval("WOE_DealTime","{0:yyyy-MM-dd HH:mm}")%>'
                                        ForeColor="Gray" CommandName="schq">生产会签</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="pbhq" runat="server" CommandArgument='<%#Eval("WOE_ID")+","+ Eval("EPO_Name")+","+ Eval("EPOD_Name")+","+ Eval("WOE_People")+","+ Eval("WOE_ApplyDepartMent")+","+ Eval("WOE_Time","{0:yyyy-MM-dd HH:mm}")+","+ Eval("WOE_Detail")+","+ Eval("WOE_DealTime","{0:yyyy-MM-dd HH:mm}")%>'
                                        ForeColor="Gray" CommandName="pbhq">品保会签</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="gchq" runat="server" CommandArgument='<%#Eval("WOE_ID")+","+ Eval("EPO_Name")+","+ Eval("EPOD_Name")+","+ Eval("WOE_People")+","+ Eval("WOE_ApplyDepartMent")+","+ Eval("WOE_Time","{0:yyyy-MM-dd HH:mm}")+","+ Eval("WOE_Detail")+","+ Eval("WOE_DealTime","{0:yyyy-MM-dd HH:mm}")%>'
                                        ForeColor="Gray" CommandName="gchq">工程会签</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="gzja" runat="server" CommandArgument='<%#Eval("WOE_ID")+","+ Eval("EPO_Name")+","+ Eval("EPOD_Name")+","+ Eval("WOE_People")+","+ Eval("WOE_ApplyDepartMent")+","+ Eval("WOE_Time","{0:yyyy-MM-dd HH:mm}")+","+ Eval("WOE_Detail")+","+ Eval("WOE_DealTime","{0:yyyy-MM-dd HH:mm}")%>'
                                        ForeColor="Gray" CommandName="gzja">主导部门跟踪结案</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="ckyc" runat="server" CommandArgument='<%#Eval("WOE_ID")+","+ Eval("EPO_Name")+","+ Eval("EPOD_Name")+","+ Eval("WOE_People")+","+ Eval("WOE_ApplyDepartMent")+","+ Eval("WOE_Time","{0:yyyy-MM-dd HH:mm}")+","+ Eval("WOE_Detail")+","+ Eval("WOE_DealTime","{0:yyyy-MM-dd HH:mm}")%>'
                                        CommandName="ckyc">查看异常信息</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="WOE_SCHQMan" SortExpression="WOE_SCHQMan" HeaderText="生产会签人"
                                ReadOnly="true" Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="WOE_SCHQDept" SortExpression="WOE_SCHQDept" HeaderText="生产会签部门" ReadOnly="true"
                                Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="WOE_SCHQResult" SortExpression="WOE_SCHQResult" HeaderText="生产会签结果"
                                ReadOnly="true" Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="WOE_SCHQSuggestion" SortExpression="WOE_SCHQSuggestion" HeaderText="生产会签意见"
                                ReadOnly="true" Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="WOE_SCHQTime" SortExpression="WOE_SCHQTime" HeaderText="生产会签时间"
                                DataFormatString="{0:yyyy-MM-dd HH:mm}" ReadOnly="true" Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="WOE_PBHQMan" SortExpression="WOE_PBHQMan" HeaderText="品保会签人"
                                ReadOnly="true" Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="WOE_PBHQtime" SortExpression="WOE_PBHQtime" HeaderText="品保会签时间" ReadOnly="true"
                                DataFormatString="{0:yyyy-MM-dd HH:mm}" Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="WOE_PBHQResult" SortExpression="WOE_PBHQResult" HeaderText="品保会签结果"
                                ReadOnly="true" Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="WOE_PBHQSuggestion" SortExpression="WOE_PBHQSuggestion" HeaderText="品保会签意见"
                                ReadOnly="true" Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="WOE_GCHQMan" SortExpression="WOE_GCHQMan" HeaderText="工程会签人"
                                ReadOnly="true" Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="WOE_GCHQResult" SortExpression="WOE_GCHQResult" HeaderText="工程会签结果" ReadOnly="true"
                                Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="WOE_GCHQSuggestion" SortExpression="WOE_GCHQSuggestion" HeaderText="工程会签意见"
                                ReadOnly="true" Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="WOE_GCHQtime" SortExpression="WOE_GCHQtime" HeaderText="工程会签时间"
                                DataFormatString="{0:yyyy-MM-dd HH:mm}" ReadOnly="true" Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="WOE_TrackMan" SortExpression="WOE_TrackMan" HeaderText="跟踪人"
                                ReadOnly="true" Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="WOE_TrackResult" SortExpression="WOE_TrackResult" HeaderText="跟踪结果" ReadOnly="true"
                                Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="WOE_TrackSuggestion" SortExpression="WOE_TrackSuggestion" HeaderText="跟踪意见"
                                ReadOnly="true" Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="WOE_TrackDep" SortExpression="WOE_TrackDep" HeaderText="跟踪部门"
                                ReadOnly="true" Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="WOE_TrackTime" SortExpression="WOE_TrackTime" HeaderText="跟踪时间"
                                DataFormatString="{0:yyyy-MM-dd HH:mm}" ReadOnly="true" Visible="false"></asp:BoundField>

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
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_NewProjectInfo" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_NewProjectInfo" runat="server" Visible="False">
                <fieldset>
                    <legend>随工单：<asp:Label ID="label_ApplyWO" runat="server" Visible="true" ForeColor="Red"></asp:Label>
                        &nbsp;<asp:Label ID="label_ApplyPBC" runat="server" Visible="true" ForeColor="Red"></asp:Label>
                        &nbsp;工序 异常<asp:Label ID="label_Change" runat="server" Visible="true"></asp:Label>信息
                        <asp:Label ID="label_applywodid" runat="server" Visible="false"></asp:Label>
                        &nbsp;</legend>
                    <asp:Label ID="label_RTX" runat="server" Visible="false"></asp:Label>
                    <table width="100%">
                        <tr>
                            <td style="width: 126px" align="right">异常申报人：
                            </td>
                            <td style="width: 94px">
                                <asp:Label ID="Label29" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td style="width: 68px" align="right">申报时间：
                            </td>
                            <td style="width: 123px" align="left">
                                <asp:Label ID="Label30" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td style="width: 196px">申报部门：
                                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td>&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 126px">异常类别：
                            </td>
                            <td style="width: 94px">
                                <asp:DropDownList ID="DropDownList5" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList5_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 68px">
                                <asp:DropDownList ID="DropDownList7" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList7_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 123px">工序下所属异常项目：
                            </td>
                            <td style="width: 196px">
                                <asp:DropDownList ID="DropDownList6" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>&nbsp;
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%">
                        <tr>
                            <td align="right" style="width: 15%">
                                <asp:Label ID="Label5" runat="server" Text="异常描述：</br>(500字以内)"></asp:Label>
                            </td>
                            <td align="left" colspan="7">
                                <asp:TextBox ID="TextBox4" runat="server" Enabled="True" Height="98px" MaxLength="200"
                                    TextMode="MultiLine" onkeyup="this.value = this.value.substring(0, 500)" onafterpaste="this.value = this.value.substring(0, 1000)"
                                    Width="93%"></asp:TextBox>
                                <asp:Label ID="Label28" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="1"></td>
                            <td align="center" colspan="2">
                                <asp:Button ID="Button6" runat="server" CssClass="Button02" Height="24px" OnClick="ConfirmProject_Click"
                                    Text="提交" Width="70px" />
                            </td>
                            <td align="center" colspan="3">
                                <asp:Button ID="Button7" runat="server" CssClass="Button02" Height="24px" OnClick="CanelProject"
                                    Text="关闭" Width="70px" />
                            </td>
                            <td align="center" colspan="2"></td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel2" runat="server" Visible="False">
                <fieldset>
                    <legend>
                        <asp:Label ID="label31" runat="server" ForeColor="Red"></asp:Label>&nbsp;随工单：<asp:Label
                            ID="label2" runat="server" ForeColor="Red"></asp:Label>
                        &nbsp;&nbsp;<asp:Label ID="label3" runat="server" ForeColor="Red"></asp:Label>
                        &nbsp;工序的异常处理信息&nbsp;<asp:Label ID="Label_ChuLiWOE_ID" runat="server" Visible="false"></asp:Label></legend>
                    <table width="100%">
                        <tr>
                            <td style="width: 126px" align="right">处理人：
                            </td>
                            <td style="width: 94px">
                                <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td style="width: 68px" align="right">处理时间：
                            </td>
                            <td style="width: 123px" align="left">
                                <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td style="width: 196px">处理部门：
                                <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td>&nbsp;
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%">
                        <tr>
                            <td align="right" style="width: 15%">
                                <asp:Label ID="Label11" runat="server" Text="处理措施：</br>(500字以内)"></asp:Label>
                            </td>
                            <td align="left" colspan="3">
                                <asp:TextBox ID="TextBox1" runat="server" Enabled="True" Height="98px" MaxLength="500"
                                    TextMode="MultiLine" onkeyup="this.value = this.value.substring(0, 500)" onafterpaste="this.value = this.value.substring(0, 1000)"
                                    Width="93%"></asp:TextBox>
                                <asp:Label ID="Label12" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr id="fg1" runat="server">
                            <td align="right" style="width: 15%">添加工序：
                            </td>
                            <td align="left" colspan="3">
                                <asp:DropDownList ID="DropDownList8" runat="server">
                                </asp:DropDownList>
                                至随工单<asp:Label ID="label32" runat="server" ForeColor="Red"></asp:Label>
                                <asp:DropDownList ID="DropDownList9" runat="server">
                                </asp:DropDownList>
                                工序之后 ；是否计工资<asp:DropDownList ID="DropDownList10" runat="server">
                                    <asp:ListItem Value="0">是</asp:ListItem>
                                    <asp:ListItem Value="1">否</asp:ListItem>
                                </asp:DropDownList>
                                <asp:Button ID="Button8" runat="server" CssClass="Button02" Height="24px" OnClick="Button8_Click"
                                    Text="添加" Width="70px" />
                            </td>
                        </tr>
                        <tr id="fg2" runat="server">
                            <td align="right" style="width: 15%">删除工序：
                            </td>
                            <td align="left" colspan="3">随工单<asp:Label ID="label33" runat="server" ForeColor="Red"></asp:Label>
                                <asp:DropDownList ID="DropDownList11" runat="server">
                                </asp:DropDownList>
                                工序<asp:Button ID="Button9" runat="server" CssClass="Button02" Height="24px" OnClick="btn9_Click"
                                    Text="删除" Width="70px" />
                            </td>
                        </tr>
                        <tr id="fg3" runat="server">
                            <td align="right" style="width: 15%">随工单工序<br />
                                增删记录
                            </td>
                            <td align="left" colspan="3">
                                <asp:TextBox ID="TextBox5" runat="server" Enabled="False" Height="98px" MaxLength="500"
                                    onafterpaste="this.value = this.value.substring(0, 1000)" onkeyup="this.value = this.value.substring(0, 500)"
                                    TextMode="MultiLine" Width="93%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="1"></td>
                            <td align="center">
                                <asp:Button ID="Button1" runat="server" CssClass="Button02" Height="24px" OnClick="btn1_Click"
                                    Text="提交" Width="70px" />
                            </td>
                            <td align="center">
                                <asp:Button ID="Button2" runat="server" CssClass="Button02" Height="24px" Text="关闭"
                                    Width="70px" OnClick="Button2_Click" />
                            </td>
                            <td align="center"></td>
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
                    <legend>随工单：<asp:Label ID="label4" runat="server" Visible="true" ForeColor="Red"></asp:Label>
                        &nbsp;<asp:Label ID="label6" runat="server" Visible="true" ForeColor="Red"></asp:Label>
                        &nbsp;工序会签 
                        <asp:Label ID="Label_WOEID" runat="server" Visible="False"></asp:Label>
                        &nbsp;</legend>
                    <asp:Label ID="label14" runat="server" Visible="false"></asp:Label>
                    <table width="100%">
                        <tr>
                            <td style="width: 126px" align="right">生产会签人：
                            </td>
                            <td style="width: 94px">
                                <asp:Label ID="Label15" runat="server"></asp:Label>
                            </td>
                            <td style="width: 89px" align="right">生产会签时间：
                            </td>
                            <td style="width: 123px" align="left">
                                <asp:Label ID="Label17" runat="server"></asp:Label>
                            </td>
                            <td style="width: 196px">生产会签部门：
                                <asp:Label ID="Label18" runat="server"></asp:Label>
                            </td>
                            <td>会签结果：<asp:Label ID="label51" runat="server" ForeColor="Red" Visible="true"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%">
                        <tr>
                            <td align="right" style="width: 15%">
                                <asp:Label ID="Label19" runat="server" Text="生产会签意见：</br>(500字以内)"></asp:Label>
                            </td>
                            <td align="left" colspan="7">
                                <asp:TextBox ID="TextBox2" runat="server" Enabled="True" Height="98px" MaxLength="200"
                                    TextMode="MultiLine" onkeyup="this.value = this.value.substring(0, 500)" onafterpaste="this.value = this.value.substring(0, 1000)"
                                    Width="93%"></asp:TextBox>
                                <asp:Label ID="Label20" runat="server" Text="*" ForeColor="Red"></asp:Label>
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
                            <td style="width: 126px" align="right">品保会签人：
                            </td>
                            <td style="width: 94px">
                                <asp:Label ID="Label41" runat="server"></asp:Label>
                            </td>
                            <td style="width: 89px" align="right">品保会签时间：
                            </td>
                            <td style="width: 123px" align="left">
                                <asp:Label ID="Label42" runat="server"></asp:Label>
                            </td>
                            <td style="width: 196px"></td>
                            <td>&nbsp;会签结果：<asp:Label ID="label52" runat="server" ForeColor="Red" Visible="true"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%">
                        <tr>
                            <td align="right" style="width: 15%">
                                <asp:Label ID="Label44" runat="server" Text="品保会签意见：</br>(500字以内)"></asp:Label>
                            </td>
                            <td align="left" colspan="7">
                                <asp:TextBox ID="TextBox7" runat="server" Enabled="True" Height="98px" MaxLength="200"
                                    TextMode="MultiLine" onkeyup="this.value = this.value.substring(0, 500)" onafterpaste="this.value = this.value.substring(0, 1000)"
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
                    <table width="100%">
                        <tr>
                            <td style="width: 126px" align="right">工程会签人：
                            </td>
                            <td style="width: 94px">
                                <asp:Label ID="Label46" runat="server"></asp:Label>
                            </td>
                            <td style="width: 89px" align="right">工程会签时间：
                            </td>
                            <td style="width: 123px" align="left">
                                <asp:Label ID="Label47" runat="server"></asp:Label>
                            </td>
                            <td style="width: 196px">&nbsp;</td>
                            <td>会签结果：<asp:Label ID="label53" runat="server" ForeColor="Red" Visible="true"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%">
                        <tr>
                            <td align="right" style="width: 15%">
                                <asp:Label ID="Label49" runat="server" Text="工程会签意见：</br>(500字以内)"></asp:Label>
                            </td>
                            <td align="left" colspan="3">
                                <asp:TextBox ID="TextBox8" runat="server" Enabled="True" Height="98px" MaxLength="200"
                                    TextMode="MultiLine" onkeyup="this.value = this.value.substring(0, 500)" onafterpaste="this.value = this.value.substring(0, 1000)"
                                    Width="93%"></asp:TextBox>
                                <asp:Label ID="Label50" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="1"></td>
                            <td align="center">
                                <asp:Button ID="gctg" runat="server" CssClass="Button02" Height="24px" OnClick="gctg_Click"
                                    Text="通过" Width="70px" />
                            </td>
                            <td align="center">
                                <asp:Button ID="gcbh" runat="server" CssClass="Button02" Height="24px" OnClick="gcbh_Click"
                                    Text="不通过" Width="70px" />
                            </td>
                            <td align="center"></td>
                        </tr>
                        <tr>
                            <td align="center" colspan="1">&nbsp;</td>
                            <td align="right" style="width: 349px">
                                <asp:Button ID="Button17" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button17_Click" Text="关闭" Width="70px" />
                            </td>
                            <td align="center">&nbsp;</td>
                            <td align="center">&nbsp;</td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel4" runat="server" Visible="False">
                <fieldset>
                    <legend>随工单：<asp:Label ID="label7" runat="server" Visible="true" ForeColor="Red"></asp:Label>
                        &nbsp;<asp:Label ID="label13" runat="server" Visible="true" ForeColor="Red"></asp:Label>
                        &nbsp;工序 异常跟踪结案信息 &nbsp;  
                        <asp:Label ID="label_WOE_ID_GZJA" runat="server" Visible="false"></asp:Label></legend>

                    <table width="100%">
                        <tr>
                            <td style="width: 126px" align="right">跟踪人：
                            </td>
                            <td style="width: 94px">
                                <asp:Label ID="Label24" runat="server"></asp:Label>
                            </td>
                            <td style="width: 68px" align="right">跟踪时间：
                            </td>
                            <td style="width: 123px" align="left">
                                <asp:Label ID="Label25" runat="server"></asp:Label>
                            </td>
                            <td style="width: 196px">跟踪部门：
                                <asp:Label ID="Label26" runat="server"></asp:Label>
                            </td>
                            <td>&nbsp;结案结果： 
                                <asp:Label ID="Label54" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>

                    </table>
                    <table style="width: 100%">
                        <tr>
                            <td align="right" style="width: 15%">
                                <asp:Label ID="Label27" runat="server" Text="异常跟踪：</br>(500字以内)"></asp:Label>
                            </td>
                            <td align="left" colspan="3">
                                <asp:TextBox ID="TextBox3" runat="server" Enabled="True" Height="98px" MaxLength="200"
                                    TextMode="MultiLine" onkeyup="this.value = this.value.substring(0, 500)" onafterpaste="this.value = this.value.substring(0, 1000)"
                                    Width="93%"></asp:TextBox>
                                <asp:Label ID="Label34" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="1"></td>
                            <td align="center">
                                <asp:Button ID="Button3" runat="server" CssClass="Button02" Height="24px" OnClick="Button3_Click"
                                    Text="结案通过" Width="70px" />
                            </td>
                            <td align="center">
                                <asp:Button ID="Button4" runat="server" CssClass="Button02" Height="24px" OnClick="Button4_Click"
                                    Text="结案不通过" Width="70px" />
                            </td>
                            <td align="center"></td>
                        </tr>
                    </table>
                    <table width="100%">
                        <tr>
                            <td align="center" colspan="1">&nbsp;</td>
                            <td align="center" style="width: 19px">&nbsp;</td>
                            <td align="center">
                                <asp:Button ID="Button18" runat="server" CssClass="Button02" Height="24px" OnClick="Button18_Click" Text="关闭" Width="70px" />
                            </td>
                            <td align="center">&nbsp;</td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
