<%@ Page Title="" Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true"
    CodeFile="SalaryDayCalculate.aspx.cs" Inherits="WorkOrderSalary_SalaryDayCalculate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel_Search" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Search" runat="server" Visible="true">
                <fieldset>
                    <legend>计时计件日核算检索 <asp:Label ID="label_pagestate" runat="server" Visible="False"/></legend>
                    <table style="width: 100%;">
                        <%--         <tr style="width: 100%;">
                            <td style="width: 11%;">
                                工序：
                            </td>
                            <td style="width: 9%;">
                                <asp:DropDownList ID="DropDownList_PBC" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 11%;">
                                审核人：
                            </td>
                            <td style="width: 14%;">
                                <asp:TextBox ID="TextBox_Reviewpeople" runat="server" Width="100%"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 11%;">
                                
                            </td>
                            <td align="left" class="auto-style3" style="width: 16%;">
                                <asp:TextBox ID="TextBox_Review_Time1" runat="server" CssClass="Wdate" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"
                                    Width="100%" Visible="False"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 33px;">
                                &nbsp;</td>
                            <td style="width: 16%;" align="left">
                                <asp:TextBox ID="TextBox_Review_Time2" runat="server" CssClass="Wdate" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"
                                    Width="100%" Visible="False"></asp:TextBox>
                            </td>
                        </tr>--%>
                        <tr style="width: 100%;">
                            <td style="width: 11%;">
                                计时审核状态：
                            </td>
                            <td align="left" style="width: 9%;">
                                <asp:DropDownList ID="DropDownList_TimeState" runat="server">
                                    <asp:ListItem Value="">请选择</asp:ListItem>
                                    <asp:ListItem>待审核</asp:ListItem>
                                    <asp:ListItem>通过</asp:ListItem>
                                    <asp:ListItem>不通过</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="center" style="width: 11%;">
                                计件审核状态：
                            </td>
                            <td align="left" style="width: 14%;">
                                <asp:DropDownList ID="DropDownList_PieceState" runat="server">
                                    <asp:ListItem Value="">请选择</asp:ListItem>
                                    <asp:ListItem>待审核</asp:ListItem>
                                    <asp:ListItem>通过</asp:ListItem>
                                    <asp:ListItem>不通过</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="center" style="width: 11%;">
                                计算日期：
                            </td>
                            <td align="left" style="width: 16%;">
                                <asp:TextBox ID="TextBox_calculate_Time1" runat="server" CssClass="Wdate" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 57px;">
                                至
                            </td>
                            <td align="left" style="width: 16%;">
                                <asp:TextBox ID="TextBox_calculate_Time2" runat="server" CssClass="Wdate" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%;">
                        <tr style="width: 100%;">
                            <td align="center" style="width: 13%;">
                                &nbsp;
                            </td>
                            <td align="left" style="width: 17%;">
                                &nbsp;
                            </td>
                            <td align="center" style="width: 15%;">
                                <asp:Button ID="Btn_Search" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_Search_Click"
                                    Text="检索" Width="70px" />
                            </td>
                            <td align="center" style="width: 14%;">
                                <asp:Button ID="Button_Add" runat="server" CssClass="Button02" Height="24px" OnClick="Button_Add_Click"
                                    Text="新建计时计件主信息" Width="120px" />
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
    <asp:UpdatePanel ID="UpdatePanel_Add" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Add" runat="server" Visible="false">
                <fieldset>
                    <legend>计时计件日核算新增 </legend>
                    <table style="width: 100%;">
                        <tr style="width: 100%;">
                            <td style="width: 6%;">
                                日期：
                            </td>
                            <td align="left" style="width: 18%;">
                                <asp:TextBox ID="TextBox_calculate_Time_Add" runat="server" CssClass="Wdate" onfocus="new WdatePicker(this,'%Y-%M-%D',false)"
                                    Width="100%"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 9%;">
                                &nbsp;
                            </td>
                            <td align="left" style="width: 14%;">
                                <asp:Button ID="Button_Add_Submit" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_Add_Submit_Click" Text="确定" Width="70px" />
                            </td>
                            <td align="center" style="width: 11%;">
                                <asp:Button ID="Button_Add_Cancel" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_Add_Cancel_Click" Text="关闭" Width="70px" />
                            </td>
                            <td align="left" class="auto-style3" style="width: 16%;">
                                &nbsp;
                            </td>
                            <td align="center" style="width: 33px;">
                                &nbsp;
                            </td>
                            <td align="left" style="width: 16%;">
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
                    <legend>计时计件日核算表<asp:Label ID="label_GridPageState" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <asp:GridView ID="GridView_WOmain" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        PageSize="10" CellPadding="0" UseAccessibleHeader="False" AllowPaging="True" OnRowCommand="GridView_WOmain_RowCommand"
                        OnPageIndexChanging="GridView_WOmain_PageIndexChanging" AllowSorting="True" Width="100%"
                        DataKeyNames="WTP_ID" EmptyDataText="无相关记录!" GridLines="None">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="WTP_ID" SortExpression="WTP_ID" HeaderText="计时计件ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="WTP_Date" SortExpression="WTP_Date" HeaderText="日期" DataFormatString="{0:yyyy-MM-dd}">
                            </asp:BoundField>
                            <asp:BoundField DataField="WTP_PieceRState" SortExpression="WTP_PieceRState" HeaderText="生产计件审核">
                            </asp:BoundField>
                            <asp:BoundField DataField="SPSA_AuRes" SortExpression="SPSA_AuRes" HeaderText="人事计件审核">
                            </asp:BoundField>
                            <asp:BoundField DataField="WTP_TimeRState" SortExpression="WTP_TimeRState" HeaderText="生产计时审核">
                            </asp:BoundField>
                            <asp:BoundField DataField="STSA_AuRes" SortExpression="STSA_AuRes" HeaderText="人事计时审核">
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="DeleteWTP" runat="server" CommandName="DeleteWTP" CommandArgument='<%#Eval("WTP_ID")+","+ Eval("WTP_PieceRState")+","+ Eval("WTP_TimeRState") %>'
                                        OnClientClick="return confirm('将会删除计时计件信息，确定吗？')">删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="CheckPiece" runat="server" CommandArgument='<%#Eval("WTP_ID") +","+ Eval("WTP_Date","{0:yyyy-MM-dd}")+","+ Eval("WTP_PieceRState")+","+ Eval("SPSA_AuRes")%>'
                                        CommandName="CheckPiece">计件信息</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="CheckTime" runat="server" CommandArgument='<%#Eval("WTP_ID") +","+ Eval("WTP_Date","{0:yyyy-MM-dd}")+","+ Eval("WTP_TimeRState")+","+ Eval("STSA_AuRes")%>'
                                        CommandName="CheckTime">生产相关计时信息</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="CheckNoRelevantTime" runat="server" CommandArgument='<%#Eval("WTP_ID") +","+ Eval("WTP_Date","{0:yyyy-MM-dd}")+","+ Eval("WTP_TimeRState")+","+ Eval("STSA_AuRes")%>'
                                        CommandName="CheckNoRelevantTime">生产无关计时信息</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="ReviewPiece" runat="server" CommandArgument='<%#Eval("WTP_ID") +","+ Eval("WTP_Date","{0:yyyy-MM-dd}")%>'
                                        CommandName="ReviewPiece">计件审核</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="ReviewTime" runat="server" CommandArgument='<%#Eval("WTP_ID") +","+ Eval("WTP_Date","{0:yyyy-MM-dd}")%>'
                                        CommandName="ReviewTime">计时审核</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="HRReview" runat="server" CommandArgument='<%#Eval("WTP_ID") +","+ Eval("WTP_Date","{0:yyyy-MM-dd}")%>'
                                        CommandName="HRReview">财务审核信息查看</asp:LinkButton>
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
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="label1" runat="server"></asp:Label>
                        财务审核信息<asp:Label ID="label_WTPID_ForHR" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="Label_scjj" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="Label_scjs" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="Label_rsjj" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="Label_rsjs" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        PageSize="10" CellPadding="0" UseAccessibleHeader="False" Width="100%" DataKeyNames="WTP_ID"
                        EmptyDataText="无相关记录!" GridLines="None" OnDataBound="GridView1_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="WTP_ID" HeaderText="计时计件ID" Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="SPSA_Auditor" HeaderText="财务计件审核人"></asp:BoundField>
                            <asp:BoundField DataField="SPSA_AuTime" HeaderText="财务计件审核时间" DataFormatString="{0:yyyy-MM-dd HH:mm}">
                            </asp:BoundField>
                            <asp:BoundField DataField="SPSA_AuSugg" HeaderText="财务计件审核意见"></asp:BoundField>
                            <asp:BoundField DataField="STSA_Auditor" HeaderText="财务计时审核人"></asp:BoundField>
                            <asp:BoundField DataField="STSA_AuTime" HeaderText="财务计时审核时间" DataFormatString="{0:yyyy-MM-dd HH:mm}">
                            </asp:BoundField>
                            <asp:BoundField DataField="STSA_AuSugg" HeaderText="财务计时审核意见"></asp:BoundField>
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
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_Piece" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Piece" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="Label_Date" runat="server"></asp:Label>日计件统计表<asp:Label ID="Label_WTP_ID"
                            runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="label_GridPageState_Piece" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 61px">
                                产品型号：
                            </td>
                            <td style="width: 127px">
                                <asp:TextBox ID="TextBox_PT1" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 65px">
                                工价系列：
                            </td>
                            <td style="width: 126px">
                                <asp:TextBox ID="TextBox_PS1" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 44px">
                                工序：
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox_PBC1" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 61px">
                                &nbsp;姓名：
                            </td>
                            <td style="width: 127px">
                                <asp:TextBox ID="TextBox_Name1" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 65px">
                                工号：
                            </td>
                            <td style="width: 126px">
                                <asp:TextBox ID="TextBox_gonghao1" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 44px">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 61px">
                                &nbsp;
                            </td>
                            <td style="width: 127px">
                                &nbsp;
                            </td>
                            <td style="width: 65px">
                                &nbsp;
                            </td>
                            <td style="width: 126px">
                                <asp:Button ID="Btn_Search1" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_Search1_Click"
                                    Text="检索" Width="70px" />
                            </td>
                            <td style="width: 44px">
                                &nbsp;
                            </td>
                            <td>
                                <asp:Button ID="Button_Cancel1" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_Cancel1_Click" Text="重置" Width="70px" />
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView_Piece" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        PageSize="10" CellPadding="0" UseAccessibleHeader="False" AllowPaging="True" OnPageIndexChanging="GridView_Piece_PageIndexChanging"
                        AllowSorting="True" Width="100%" EmptyDataText="无相关记录!" GridLines="None" OnRowCancelingEdit="GridView_Piece_RowCancelingEdit"
                        OnRowEditing="GridView_Piece_RowEditing" OnRowUpdating="GridView_Piece_RowUpdating"
                        OnRowCommand="GridView_Piece_RowCommand">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="PBC_ID" SortExpression="PBC_ID" HeaderText="工序ID" ReadOnly="True"
                                Visible="False"></asp:BoundField>
                            <asp:BoundField DataField="HRDD_ID" SortExpression="HRDD_ID" HeaderText="员工ID" ReadOnly="True"
                                Visible="False"></asp:BoundField>
                            <asp:BoundField DataField="WO_ProType" SortExpression="WO_ProType" HeaderText="产品型号"
                                ReadOnly="True"></asp:BoundField>
                            <asp:BoundField DataField="LCS_Name" SortExpression="LCS_Name" HeaderText="工价系列"
                                ReadOnly="True"></asp:BoundField>
                            <asp:BoundField DataField="PBC_Name" SortExpression="PBC_Name" HeaderText="工序" ReadOnly="True">
                            </asp:BoundField>
                            <asp:BoundField DataField="HRDD_Name" SortExpression="HRDD_Name" HeaderText="姓名"
                                ReadOnly="True"></asp:BoundField>
                            <asp:BoundField DataField="HRDD_StaffNO" SortExpression="HRDD_StaffNO" HeaderText="工号"
                                ReadOnly="True"></asp:BoundField>
                            <asp:BoundField DataField="num" SortExpression="num" HeaderText="计件"></asp:BoundField>
                            <asp:CommandField ShowEditButton="True" EditText="编辑" UpdateText="更新" CancelText="取消"
                                Visible="False"></asp:CommandField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="EditPiece" runat="server" CommandArgument='<%#Eval("PBC_ID") +","+ Eval("HRDD_Name")+","+ Eval("PBC_Name")+","+ Eval("WO_ProType")+","+ Eval("HRDD_ID")%>'
                                        CommandName="EditPiece">查看所属随工单</asp:LinkButton>
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
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel2" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="label2" runat="server"></asp:Label>
                        计件信息所属随工单<asp:Label ID="label_PBCID" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        PageSize="10" CellPadding="0" UseAccessibleHeader="False" Width="100%" DataKeyNames="OI_ID"
                        EmptyDataText="无相关记录!" GridLines="None" OnDataBound="GridView1_DataBound" OnRowEditing="GridView2_RowEditing"
                        OnRowCancelingEdit="GridView2_RowCancelingEdit" OnRowDataBound="GridView2_RowDataBound"
                        OnRowUpdating="GridView2_RowUpdating">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="OI_ID" HeaderText="计件信息ID" Visible="false" ReadOnly="True">
                            </asp:BoundField>
                            <asp:BoundField DataField="WO_Num" HeaderText="随工单号" ReadOnly="True"></asp:BoundField>
                            <asp:BoundField DataField="WOD_InNum" HeaderText="投入数" ReadOnly="True"></asp:BoundField>
                            <asp:BoundField DataField="WOD_QNum" HeaderText="合格数" ReadOnly="True"></asp:BoundField>
                            <asp:BoundField DataField="WOD_InTime" HeaderText="进站时间" ReadOnly="True" DataFormatString="{0:yyyy-MM-dd HH:mm}">
                            </asp:BoundField>
                            <asp:BoundField DataField="WOD_OutTime" HeaderText="出站时间" ReadOnly="True" DataFormatString="{0:yyyy-MM-dd HH:mm}">
                            </asp:BoundField>
                            <asp:BoundField DataField="OI_ProNum" HeaderText="计件数量"></asp:BoundField>
                            <asp:CommandField ShowEditButton="True" EditText="编辑" UpdateText="更新" CancelText="取消">
                            </asp:CommandField>
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
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_Time" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Time" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="Label_Date2" runat="server"></asp:Label>
                        日计时统计表<asp:Label ID="Label_WTP_ID2" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="label_GridPageState_Piece2" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 61px">
                                产品型号：
                            </td>
                            <td style="width: 127px">
                                <asp:TextBox ID="TextBox_PT2" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 65px">
                                计时项目：
                            </td>
                            <td style="width: 126px">
                                <asp:TextBox ID="TextBox_Project" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 39px">
                                工序：
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox_PBC2" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 61px">
                                &nbsp;姓名：
                            </td>
                            <td style="width: 127px">
                                <asp:TextBox ID="TextBox_Name2" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 65px">
                                工号：
                            </td>
                            <td style="width: 126px">
                                <asp:TextBox ID="TextBox_gonghao2" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 39px">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 61px">
                            </td>
                            <td style="width: 127px">
                            </td>
                            <td style="width: 65px">
                            </td>
                            <td style="width: 126px">
                                <asp:Button ID="Button_search2" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Btn_Search2_Click" Text="检索" Width="70px" />
                            </td>
                            <td style="width: 39px">
                                &nbsp;
                            </td>
                            <td>
                                <asp:Button ID="Button_cancel2" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_Cancel2_Click" Text="重置" Width="70px" />
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView_Time" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        PageSize="10" CellPadding="0" UseAccessibleHeader="False" AllowPaging="True" OnPageIndexChanging="GridView_Time_PageIndexChanging"
                        AllowSorting="True" Width="100%" EmptyDataText="无相关记录!" GridLines="None" OnRowCancelingEdit="GridView_Time_RowCancelingEdit"
                        OnRowEditing="GridView_Time_RowEditing" OnRowUpdating="GridView_Time_RowUpdating"
                        OnRowCommand="GridView_Time_RowCommand">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="STI_ID" SortExpression="STI_ID" HeaderText="计时项目ID" ReadOnly="True"
                                Visible="False"></asp:BoundField>
                            <asp:BoundField DataField="HRDD_ID" SortExpression="HRDD_ID" HeaderText="员工ID" ReadOnly="True"
                                Visible="False"></asp:BoundField>
                            <asp:BoundField DataField="WO_ProType" SortExpression="WO_ProType" HeaderText="产品型号"
                                ReadOnly="True"></asp:BoundField>
                            <asp:BoundField DataField="PBC_Name" SortExpression="PBC_Name" HeaderText="工序" ReadOnly="True">
                            </asp:BoundField>
                            <asp:BoundField DataField="HRDD_Name" SortExpression="HRDD_Name" HeaderText="姓名"
                                ReadOnly="True"></asp:BoundField>
                            <asp:BoundField DataField="HRDD_StaffNO" SortExpression="HRDD_StaffNO" HeaderText="工号"
                                ReadOnly="True"></asp:BoundField>
                            <asp:BoundField DataField="STI_Name" SortExpression="STI_Name" HeaderText="计时项目"
                                ReadOnly="True"></asp:BoundField>
                            <asp:BoundField DataField="t" SortExpression="t" HeaderText="计时时长"></asp:BoundField>
                            <asp:BoundField DataField="tnum" SortExpression="tnum" HeaderText="数量"></asp:BoundField>
                            <asp:CommandField ShowEditButton="True" EditText="编辑" UpdateText="更新" CancelText="取消"
                                Visible="False"></asp:CommandField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="EditTime" runat="server" CommandArgument='<%#Eval("STI_ID") +","+ Eval("HRDD_Name")+","+ Eval("STI_Name")+","+ Eval("WO_ProType")+","+ Eval("HRDD_ID")%>'
                                        CommandName="EditTime">查看所属随工单</asp:LinkButton>
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
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel3" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="label4" runat="server"></asp:Label>
                        计时信息所属随工单<asp:Label ID="label5" runat="server" Visible="False">
                        </asp:Label><asp:Label ID="label_WOPT" runat="server" Visible="False">
                        </asp:Label><asp:Label ID="label_HRDDID1" runat="server" Visible="False">
                        </asp:Label>
                        <asp:Label ID="label_al0" runat="server" Visible="False">
                        </asp:Label>
                        <asp:Label ID="label_al3" runat="server" Visible="False">
                        </asp:Label>
                        <asp:Label ID="label_al4" runat="server" Visible="False">
                        </asp:Label>
                    </legend>
                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        PageSize="10" CellPadding="0" UseAccessibleHeader="False" Width="100%" DataKeyNames="OT_ID"
                        EmptyDataText="无相关记录!" GridLines="None" OnDataBound="GridView3_DataBound" OnRowEditing="GridView3_RowEditing"
                        OnRowCancelingEdit="GridView3_RowCancelingEdit" OnRowDataBound="GridView3_RowDataBound"
                        OnRowUpdating="GridView3_RowUpdating">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="OT_ID" SortExpression="OT_ID" HeaderText="计时信息ID" ReadOnly="True"
                                Visible="False"></asp:BoundField>
                            <asp:BoundField DataField="WOD_ID" HeaderText="随工单详细ID" Visible="false" ReadOnly="True">
                            </asp:BoundField>
                            <asp:BoundField DataField="WO_Num" HeaderText="随工单号" ReadOnly="True"></asp:BoundField>
                            <asp:BoundField DataField="WOD_InNum" HeaderText="投入数" ReadOnly="True"></asp:BoundField>
                            <asp:BoundField DataField="WOD_QNum" HeaderText="合格数" ReadOnly="True"></asp:BoundField>
                            <asp:BoundField DataField="WOD_InTime" HeaderText="进站时间" DataFormatString="{0:yyyy-MM-dd HH:mm}"
                                ReadOnly="True"></asp:BoundField>
                            <asp:BoundField DataField="WOD_OutTime" HeaderText="出站时间" DataFormatString="{0:yyyy-MM-dd HH:mm}"
                                ReadOnly="True"></asp:BoundField>
                            <asp:BoundField DataField="OT_Time" HeaderText="计时"></asp:BoundField>
                            <asp:BoundField DataField="OT_Num" HeaderText="数量"></asp:BoundField>
                            <asp:CommandField ShowEditButton="True" EditText="编辑" UpdateText="更新" CancelText="取消">
                            </asp:CommandField>
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
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_NoRelated" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_NoRelated" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="Label_Date3" runat="server"></asp:Label>
                        非生产相关日计时统计表<asp:Label ID="Label_WTP_ID3" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="label_GridPageState3" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 38px">
                                工序：
                            </td>
                            <td style="width: 126px">
                                <asp:TextBox ID="TextBox_PBC3" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 41px">
                                姓名：
                            </td>
                            <td style="width: 39px">
                                <asp:TextBox ID="TextBox_Name3" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 46px">
                                工号：
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox_gonghao3" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 76px">
                                &nbsp;计时项目：
                            </td>
                            <td style="width: 127px">
                                <asp:TextBox ID="TextBox_Project3" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 38px">
                            </td>
                            <td style="width: 127px">
                            </td>
                            <td style="width: 41px">
                            </td>
                            <td style="width: 126px">
                                <asp:Button ID="Button_search3" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_search3_Click" Text="检索" Width="70px" />
                            </td>
                            <td style="width: 46px">
                                &nbsp;
                            </td>
                            <td style="width: 39px" align="center">
                                <asp:Button ID="Button_Cancel3" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_Cancel3_Click" Text="重置" Width="70px" />
                            </td>
                            <td style="width: 76px">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView_NoRelated" runat="server" AutoGenerateColumns="false"
                        CssClass="GridViewStyle" PageSize="10" CellPadding="0" UseAccessibleHeader="False"
                        AllowPaging="True" OnPageIndexChanging="GridView_NoRelated_PageIndexChanging"
                        AllowSorting="True" Width="100%" EmptyDataText="无相关记录!" GridLines="None" OnRowCancelingEdit="GridView_NoRelated_RowCancelingEdit"
                        OnRowEditing="GridView_NoRelated_RowEditing" DataKeyNames="OT_ID" OnRowDataBound="GridView_NoRelated_RowDataBound"
                        OnRowUpdating="GridView_NoRelated_RowUpdating">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="OT_ID" SortExpression="OT_ID" HeaderText="计时信息ID" ReadOnly="True"
                                Visible="False"></asp:BoundField>
                            <asp:BoundField DataField="PBC_Name" SortExpression="PBC_Name" HeaderText="工序" ReadOnly="True">
                            </asp:BoundField>
                            <asp:BoundField DataField="HRDD_Name" SortExpression="HRDD_Name" HeaderText="姓名"
                                ReadOnly="True"></asp:BoundField>
                            <asp:BoundField DataField="HRDD_StaffNO" SortExpression="HRDD_StaffNO" HeaderText="工号"
                                ReadOnly="True"></asp:BoundField>
                            <asp:BoundField DataField="STI_Name" SortExpression="STI_Name" HeaderText="计时项目"
                                ReadOnly="True"></asp:BoundField>
                            <asp:BoundField DataField="otime" SortExpression="otime" HeaderText="计时时长"></asp:BoundField>
                            <asp:BoundField DataField="num" SortExpression="num" HeaderText="数量"></asp:BoundField>
                            <asp:CommandField ShowEditButton="True" EditText="编辑" UpdateText="更新" CancelText="取消">
                            </asp:CommandField>
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
    <asp:UpdatePanel ID="UpdatePanel_Sign" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Sign" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="Label_Date4" runat="server"></asp:Label>
                        <asp:Label ID="Label_TimeOrPiece" runat="server"></asp:Label>
                        <asp:Label ID="Label_WTP_ID4" runat="server" Visible="False"></asp:Label>
                        审核</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 12%">
                                审核人:
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TB_Reviewman" runat="server" Width="100%" ReadOnly="true" Enabled="False"></asp:TextBox>
                            </td>
                            <td style="width: 20%" align="right">
                                审核时间:
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TB_RevieTime" runat="server" Width="100%" ReadOnly="true" Enabled="False"
                                    DataFormatString="{0:yyyy-MM-dd HH24:mm}"></asp:TextBox>
                            </td>
                            <td style="width: 15%">
                            </td>
                            <td style="width: 10%">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 12%">
                                审核意见:
                                <br />
                                (200字以内)
                            </td>
                            <td colspan="7" align="left">
                                <asp:TextBox ID="TB_yijian" runat="server" Height="70px" MaxLength="200" onkeyup="this.value = this.value.substring(0, 200)"
                                    onafterpaste="this.value = this.value.substring(0, 200)" onblur="javascript:leave('LB1000');"
                                    onfocus="annotation('LB1000');" TextMode="MultiLine" Width="99%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="9">
                                <table style="width: 100%">
                                    <tr>
                                        <td style="width: 33%; text-align: right">
                                            <asp:Button ID="BT_TKOK" runat="server" CssClass="Button02" OnClick="BT_TKOK_Click"
                                                Text="通过" Width="70px" OnClientClick="return confirm('确定审核通过吗？') " />
                                            <%--    OnClientClick="$find('gvEdit').hide();"--%>
                                        </td>
                                        <td style="width: 34%; text-align: center">
                                            <asp:Button ID="BT_TKNotOK" runat="server" CssClass="Button02" OnClick="BT_TKNotOK_Click"
                                                Text="驳回" Width="70px" OnClientClick="return confirm('确定审核不通过吗？')" />
                                        </td>
                                        <td style="width: 33%; text-align: left">
                                            <asp:Button ID="BT_TKCancel" runat="server" CssClass="Button02" OnClick="BT_TKCanel_Click"
                                                Text="关闭" Width="70px" />
                                        </td>
                                    </tr>
                                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
