<%@ Page Title="" Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="WorkOrderCheck.aspx.cs" Inherits="ProductionProcess_WorkOrderCheck" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel_Search" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnDetailExcel" />
        </Triggers>
        <ContentTemplate>
            <asp:Panel ID="Panel_Search" runat="server" Visible="true">
                <fieldset>
                    <legend>随工单检索
                        <asp:Label ID="Label_searchCondition" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="label_Condition" runat="server" Visible="False"></asp:Label>
                    </legend>
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
                                    <asp:ListItem>OEM</asp:ListItem>
                                    <asp:ListItem>技术</asp:ListItem>
                                    <asp:ListItem>检验</asp:ListItem>
                                    <asp:ListItem>样品</asp:ListItem>
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
                                <asp:TextBox ID="TextBox_WO_Time1" Width="100px" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D %h:%m',true)"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 3%;">
                                至
                            </td>
                            <td align="left" style="width: 15%;">
                                <asp:TextBox ID="TextBox_WO_Time2" Width="100px" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D %h:%m',true)"></asp:TextBox>
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
                                &nbsp;状态：
                            </td>
                            <td style="width: 9%" align="left">
                                <asp:DropDownList ID="DropDownList_WoState" runat="server">
                                    <asp:ListItem Value="">请选择</asp:ListItem>
                                    <asp:ListItem>已建立</asp:ListItem>
                                    <asp:ListItem>待入库</asp:ListItem>
                                    <asp:ListItem>已入库</asp:ListItem>
                                    <asp:ListItem>已分单</asp:ListItem>
                                    <asp:ListItem>工序已开启</asp:ListItem>
                                    <asp:ListItem>工序已完工</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="width: 11%;" align="center">
                                &nbsp;周期码：
                            </td>
                            <td style="width: 10%;" align="left">
                                <asp:TextBox ID="TextBox_WOSN" runat="server" Width="100px"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 7%;">
                                工序：
                            </td>
                            <td align="left" style="width: 15%;">
                                <asp:DropDownList ID="DropDownList3" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td align="center">
                                至
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownList4" runat="server">
                                </asp:DropDownList>
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
                                &nbsp;异常：
                            </td>
                            <td style="width: 9%" align="left">
                                <asp:DropDownList ID="DropDownList1" runat="server">
                                    <asp:ListItem>请选择</asp:ListItem>
                                    <asp:ListItem>否</asp:ListItem>
                                    <asp:ListItem>是</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="width: 11%;" align="center">
                                超时：
                            </td>
                            <td style="width: 10%;" align="left">
                                <asp:DropDownList ID="DropDownList2" runat="server">
                                    <asp:ListItem>请选择</asp:ListItem>
                                    <asp:ListItem>否</asp:ListItem>
                                    <asp:ListItem>是</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="center" style="width: 7%;">
                                材料批号：
                            </td>
                            <td align="left" style="width: 15%;">
                                <asp:TextBox ID="TextBox_WOSN0" runat="server" Width="100px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%">
                        <tr style="width: 100%">
                            <td style="width: 20%">
                            </td>
                            <td style="width: 20%">
                                <asp:Button ID="Btn_Search" runat="server" Text="检索" Width="70px" Height="24px" CssClass="Button02"
                                    OnClick="Btn_Search_Click" />
                            </td>
                            <td style="width: 20%">
                                <asp:Button ID="btnDetailExcel" runat="server" CssClass="Button02" Height="24px"
                                    Text="导出Excel" Width="70px" OnClick="btnDetailExcel_Click" />
                            </td>
                            <td style="width: 20%">
                                <asp:Button ID="Button_Cancel" runat="server" CssClass="Button02" Height="24px" OnClick="Button_Cancel_Click"
                                    Text="重置" Width="70px" />
                            </td>
                            <td style="width: 20%">
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
                    <contenttemplate>
                           <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                <ProgressTemplate>
                           
        <div align="center">
          <img src="..\images\loading1.gif" alt="Wait" />
        
        </div>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                    <asp:GridView ID="GridView_WOmain" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        PageSize="15" CellPadding="0" UseAccessibleHeader="False" AllowPaging="True"
                        OnRowCommand="GridView_WOmain_RowCommand" OnPageIndexChanging="GridView_WOmain_PageIndexChanging"
                        AllowSorting="True" OnSorting="GridView_WOmain_Sorting" OnRowDataBound="GridView_WOmain_RowDataBound"
                        Width="100%" DataKeyNames="WO_ID" EmptyDataText="无相关记录!" GridLines="None" OnDataBound="GridView_WOmain_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="WO_ID" SortExpression="WO_ID" HeaderText="随工单信息ID" Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="WOD_ID" SortExpression="WOD_ID" HeaderText="随工单详细ID" Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="WO_Num" SortExpression="WO_Num" HeaderText="随工单" ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="PBC_Name" SortExpression="PBC_Name" HeaderText="工序" ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WO_FirstInNum" SortExpression="WO_FirstInNum" HeaderText="总投入"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WOD_QNum" SortExpression="WOD_QNum" HeaderText="合格数" ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="QRATE" SortExpression="QRATE" HeaderText="合格率" ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WO_Type" SortExpression="WO_Type" HeaderText="类型" ReadOnly="true"></asp:BoundField>
                           
                            <asp:BoundField DataField="WOD_WOState" SortExpression="WOD_WOState" HeaderText="状态" ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WO_OrderNum" SortExpression="WO_OrderNum" HeaderText="订单号"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WO_ProType" SortExpression="WO_ProType" HeaderText="产品型号"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WO_SN" SortExpression="WO_SN" HeaderText="周期码" ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WOD_InTime" SortExpression="WOD_InTime" HeaderText="开始时间"
                                ReadOnly="true" DataFormatString="{0:MM-dd HH:mm}"></asp:BoundField>
                            <asp:BoundField DataField="WOD_Error" SortExpression="WOD_Error" HeaderText="异常"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WOD_OverTime" SortExpression="WOD_OverTime" HeaderText="超时"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WO_Note" SortExpression="WO_Note" HeaderText="备注" ReadOnly="true"></asp:BoundField>

                            <asp:BoundField DataField="pihao" SortExpression="pihao" HeaderText="材料" ReadOnly="true" ></asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="BasicInfo" runat="server" CommandArgument='<%#Eval("WO_ID") +","+ Eval("WO_Num") %>'
                                        CommandName="BasicInfo">详情</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="ph" runat="server" CommandArgument='<%#Eval("WO_ID") +","+ Eval("WO_Num") %>'
                                        CommandName="ph">批号</asp:LinkButton>
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
                    <legend>随工单 &nbsp;<asp:Label ID="label_WONum" runat="server"></asp:Label>&nbsp; 详细表
                        <asp:Label ID="label_WO_ID" runat="server" Visible="False" Text="00000000-0000-0000-0000-000000000000"></asp:Label>
                    </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <asp:Label ID="Label6" runat="server" Text="添加工序："></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownList8" runat="server">
                                </asp:DropDownList>
                                <asp:Label ID="Label7" runat="server" Text="至" />
                                <asp:DropDownList ID="DropDownList9" runat="server">
                                </asp:DropDownList>
                                <asp:Label ID="Label9" runat="server" Text="工序之后" />
                                <asp:Button ID="Button21" runat="server" CssClass="Button02" Height="24px" OnClick="Button21_Click"
                                    Text="添加" Width="70px" />
                            </td>
                            <td align="right">
                                <asp:Button ID="Button_Cancel0" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_Cancel0_Click" Text="关闭" Width="70px" />
                            </td>
                        </tr>
                        <tr id="fg1" runat="server">
                            <td align="left" style="width: 15%">
                                删除工序：
                            </td>
                            <td align="left" colspan="3">
                                <asp:DropDownList ID="DropDownList11" runat="server">
                                </asp:DropDownList>
                                工序&nbsp;
                                <asp:Button ID="Button24" runat="server" CssClass="Button02" Height="24px" OnClick="btn24_Click"
                                    Text="删除" Width="70px" />
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        CellPadding="0" UseAccessibleHeader="False" AllowPaging="false" OnRowCommand="GridView1_RowCommand"
                        Width="100%" DataKeyNames="WOD_ID" EmptyDataText="无相关记录!" OnDataBound="GridView1_DataBound"
                        OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing"
                        OnRowUpdating="GridView1_RowUpdating" OnRowDataBound="GridView1_RowDataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="WOD_ID" SortExpression="WOD_ID" HeaderText="随工单详细ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="WOD_PBCOrder" SortExpression="WOD_PBCOrder" HeaderText="顺序">
                            </asp:BoundField>
                            <asp:BoundField DataField="PBC_ID" SortExpression="PBC_ID" HeaderText="工序" ReadOnly="true"
                                Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="PBC_Name" SortExpression="PBC_Name" HeaderText="工序" ReadOnly="true">
                            </asp:BoundField>
                            <asp:BoundField DataField="WOD_Class" SortExpression="WOD_Class" HeaderText="班次">
                            </asp:BoundField>
                            <asp:BoundField DataField="equip" SortExpression="equip" HeaderText="设备" ReadOnly="true">
                            </asp:BoundField>
                            <asp:BoundField DataField="WOD_InTime" SortExpression="WOD_InTime" HeaderText="进站时间"
                                DataFormatString="{0:yyyy-MM-dd HH:mm}" ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WOD_OutTime" SortExpression="WOD_OutTime" HeaderText="出站时间"
                                DataFormatString="{0:yyyy-MM-dd HH:mm}" ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WOD_InNum" SortExpression="WOD_InNum" HeaderText="投入数">
                            </asp:BoundField>
                            <asp:BoundField DataField="WOD_QNum" SortExpression="WOD_QNum" HeaderText="合格数" ReadOnly="true">
                            </asp:BoundField>
                            <asp:BoundField DataField="QRATE" SortExpression="QRATE" HeaderText="合格率" ReadOnly="true">
                            </asp:BoundField>
                            <asp:BoundField DataField="bad" SortExpression="bad" HeaderText="不良品" ReadOnly="true">
                            </asp:BoundField>
                            <asp:BoundField DataField="WOD_WNum" SortExpression="WOD_WNum" HeaderText="废品" ReadOnly="true">
                            </asp:BoundField>
                            <asp:BoundField DataField="WOD_Error" SortExpression="WOD_Error" HeaderText="异常"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WOD_OverTime" SortExpression="WOD_OverTime" HeaderText="超时"
                                ReadOnly="true"></asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="zyy" runat="server" CommandArgument='<%#Eval("WOD_ID") +","+ Eval("PBC_Name")+","+ Eval("PBC_ID") %>'
                                        CommandName="zyy">人员</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="sb" runat="server" CommandArgument='<%#Eval("WOD_ID") +","+ Eval("PBC_ID")+","+ Eval("PBC_Name") %>'
                                        CommandName="sb">设备</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="blp" runat="server" CommandArgument='<%#Eval("WOD_ID") +","+ Eval("PBC_ID") %>'
                                        CommandName="blp">不良品</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ShowEditButton="True" EditText="编辑" UpdateText="更新" CancelText="关闭" />
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
            <asp:Panel ID="Panel3" runat="server" Visible="False">
                <fieldset>
                    <legend>随工单批号信息
                        <asp:Label ID="label2" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="label3" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 1402px">
                            </td>
                            <td>
                            </td>
                            <td align="right" style="width: 131px">
                                <asp:Button ID="Button5" runat="server" CssClass="Button02" Height="24px" OnClick="Button5_Click"
                                    Text="添加批号" Width="70px" />
                            </td>
                            <td align="right" style="width: 131px">
                            </td>
                            <td align="right">
                                <asp:Button ID="Button8" runat="server" CssClass="Button02" Height="24px" OnClick="Button8_Click"
                                    Text="关闭" Width="70px" />
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        CellPadding="0" UseAccessibleHeader="False" AllowPaging="False" Width="100%"
                        DataKeyNames="WOMBN_ID" EmptyDataText="无相关记录!" GridLines="None">
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
                            <asp:BoundField DataField="WOMBN_ID" SortExpression="WOMBN_ID" HeaderText="批号信息ID"
                                Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="物料名称" SortExpression="物料名称" HeaderText="物料名称" ReadOnly="true">
                            </asp:BoundField>
                            <asp:BoundField DataField="物料批号" SortExpression="物料批号" HeaderText="物料批号" ReadOnly="true">
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
                    <table width="100%" runat="server" id="Table2">
                        <tr>
                            <td style="width: 320px;">
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBox7" runat="server" Text="全选" Width="80px" AutoPostBack="True"
                                    OnCheckedChanged="CheckBoxAll7_CheckedChanged" Style="margin-left: 0px" />
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBox8" runat="server" Text="反选" Width="141px" AutoPostBack="True"
                                    OnCheckedChanged="Checkfanxuan8_CheckedChanged" />
                            </td>
                            <td>
                                <asp:Button ID="Button9" runat="server" CssClass="Button02" Height="24px" OnClick="Btn9_Click"
                                    Text="删除" Width="80px" />
                            </td>
                            <td style="width: 320px;">
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel4" runat="server" Visible="false">
                <fieldset>
                    <legend>待选批号</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 5%" align="center">
                                物料名称：
                            </td>
                            <td align="left" style="width: 9%">
                                <asp:TextBox ID="TextBox3" runat="server" Width="98%"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 7%">
                                <asp:Label ID="Label4" runat="server" Text="规格型号："></asp:Label>
                            </td>
                            <td style="width: 10%" align="left">
                                <asp:TextBox ID="TextBox1" runat="server" Width="98%"></asp:TextBox>
                            </td>
                            <td style="width: 7%" align="center">
                                <asp:Label ID="Label5" runat="server" Text="物料批号："></asp:Label>
                            </td>
                            <td style="width: 10%" align="left">
                                <asp:TextBox ID="TextBox2" runat="server" Width="98%"></asp:TextBox>
                            </td>
                            <td style="width: 15%" align="center">
                                <asp:Button ID="Button10" runat="server" Text="检索" CssClass="Button02" Height="24px"
                                    Width="70px" OnClick="Button10_Click" />
                                &nbsp;
                                <asp:Button ID="Button11" runat="server" CssClass="Button02" Height="24px" OnClick="Button11_Click"
                                    Text="重置" Width="70px" />
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView4" runat="server" AllowPaging="True" PageSize="10" Width="100%"
                        AutoGenerateColumns="False" CellPadding="0" CssClass="GridViewStyle" GridLines="None"
                        DataKeyNames="物料ID,物料批号" OnPageIndexChanging="GridView4_PageIndexChanging">
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridviewHead" BorderStyle="Double" BorderWidth="1px" Height="26px"
                            HorizontalAlign="Center" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemStyle Width="5%" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox2" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="物料ID" HeaderText="物料ID" Visible="false" />
                            <asp:BoundField DataField="物料名称" HeaderText="物料名称" />
                            <asp:BoundField DataField="规格型号" HeaderText="规格型号" />
                            <asp:BoundField DataField="物料批号" HeaderText="物料批号" />
                            <asp:BoundField DataField="入库时间" HeaderText="入库时间" />
                            <asp:BoundField DataField="认证结果" HeaderText="认证结果" />
                            <asp:BoundField DataField="是否降档" HeaderText="是否降档" />
                            <asp:BoundField DataField="降档参数" HeaderText="降档参数" />
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第 &nbsp;<asp:Label ID="lblPageIndex" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>' />
                                        页 共 &nbsp;<asp:Label ID="lblPageCount" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />
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
                            <asp:Label ID="Label16" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                        <AlternatingRowStyle />
                    </asp:GridView>
                    <table width="100%">
                        <tr>
                            <td style="width: 310px;">
                            </td>
                            <td style="width: 26px">
                                <asp:CheckBox ID="CheckBox9" runat="server" Text="全选" Width="83px" AutoPostBack="True"
                                    OnCheckedChanged="CheckBoxAll9_CheckedChanged" />
                            </td>
                            <td style="width: 38px">
                                <asp:CheckBox ID="CheckBox10" runat="server" Text="反选" Width="141px" AutoPostBack="True"
                                    OnCheckedChanged="Checkfanxuan10_CheckedChanged" />
                            </td>
                            <td style="width: 93px">
                                <asp:Button ID="Button12" runat="server" CssClass="Button02" Height="24px" OnClick="Button12_Click"
                                    Text="添加" Width="70px" />
                            </td>
                            <td style="width: 320px;">
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%;">
                        <tr>
                            <td align="center">
                                <asp:Button ID="Button13" runat="server" CssClass="Button02" Height="24px" OnClick="Btn13_Click"
                                    Text="关闭" Width="70px" />
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel5" runat="server" Visible="False">
                <fieldset>
                    <legend>随工单设备信息
                        <asp:Label ID="label_SheBeiwoid" runat="server" Visible="False" Text="00000000-0000-0000-0000-000000000000"></asp:Label>
                        <asp:Label ID="label_shebeipbcid" runat="server" Visible="False" Text="00000000-0000-0000-0000-000000000000" />
                        <asp:Label ID="label_SheBeipbcname" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 1402px">
                            </td>
                            <td>
                            </td>
                            <td align="right" style="width: 131px">
                                <asp:Button ID="Button17" runat="server" CssClass="Button02" Height="24px" OnClick="Button17_Click"
                                    Text="添加设备" Width="70px" />
                            </td>
                            <td align="right" style="width: 131px">
                            </td>
                            <td align="right">
                                <asp:Button ID="Button18" runat="server" CssClass="Button02" Height="24px" OnClick="Button18_Click"
                                    Text="关闭" Width="70px" />
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        CellPadding="0" UseAccessibleHeader="False" AllowPaging="False" Width="100%"
                        DataKeyNames="WOE_ID" EmptyDataText="无相关记录!" GridLines="None">
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
                            <asp:BoundField DataField="WOE_ID" SortExpression="WOE_ID" HeaderText="设备ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="设备" SortExpression="设备" HeaderText="设备" ReadOnly="true">
                            </asp:BoundField>
                            <asp:BoundField DataField="模具" SortExpression="模具" HeaderText="模具" ReadOnly="true">
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
                    <table width="100%" runat="server" id="Table3">
                        <tr>
                            <td style="width: 320px;">
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBox11" runat="server" Text="全选" Width="80px" AutoPostBack="True"
                                    OnCheckedChanged="CheckBoxAll11_CheckedChanged" Style="margin-left: 0px" />
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBox12" runat="server" Text="反选" Width="141px" AutoPostBack="True"
                                    OnCheckedChanged="Checkfanxuan12_CheckedChanged" />
                            </td>
                            <td>
                                <asp:Button ID="Button19" runat="server" CssClass="Button02" Height="24px" OnClick="Btn19_Click"
                                    Text="删除" Width="80px" />
                            </td>
                            <td style="width: 320px;">
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel6" runat="server" Visible="false">
                <fieldset>
                    <legend>待选设备</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 8%" align="center">
                                本工序设备：
                            </td>
                            <td align="left" style="width: 9%">
                                <asp:RadioButton ID="RadioButton1" runat="server" OnCheckedChanged="RadioButton1_CheckedChanged"
                                    AutoPostBack="True" Checked="True"></asp:RadioButton>
                            </td>
                            <td align="center" style="width: 7%">
                                所有设备
                            </td>
                            <td style="width: 10%" align="left">
                                <asp:RadioButton ID="RadioButton2" runat="server" OnCheckedChanged="RadioButton2_CheckedChanged"
                                    AutoPostBack="True" />
                            </td>
                            <td style="width: 7%" align="center">
                                &nbsp;
                            </td>
                            <td style="width: 10%" align="left">
                                &nbsp;
                            </td>
                            <td style="width: 15%" align="center">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="width: 8%">
                                设备：
                            </td>
                            <td align="left" style="width: 9%">
                                &nbsp;
                                <asp:DropDownList ID="DropDownList6" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td align="center" style="width: 7%">
                                <asp:Label ID="Label8" runat="server" Text="模具："></asp:Label>
                            </td>
                            <td align="left" style="width: 10%">
                                <asp:DropDownList ID="DropDownList7" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td align="center" style="width: 7%">
                                <asp:Button ID="Button20" runat="server" CssClass="Button02" Height="24px" Text="添加"
                                    Width="70px" OnClick="Button20_Click" />
                            </td>
                            <td align="left" style="width: 10%">
                                <asp:Button ID="Button23" runat="server" CssClass="Button02" Height="24px" Text="取消"
                                    Width="70px" OnClick="Button23_Click" />
                            </td>
                            <td align="center" style="width: 15%">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel7" runat="server" Visible="False">
                <fieldset>
                    <legend>随工单不良品信息
                        <asp:Label ID="label_bad_WODID" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="label_bad_PBCID" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 1402px">
                            </td>
                            <td>
                            </td>
                            <td align="right" style="width: 131px">
                            </td>
                            <td align="right" style="width: 131px">
                            </td>
                            <td align="right">
                                <asp:Button ID="Button22" runat="server" CssClass="Button02" Height="24px" OnClick="Button22_Click"
                                    Text="关闭" Width="70px" />
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        CellPadding="0" UseAccessibleHeader="False" AllowPaging="False" Width="100%"
                        DataKeyNames="WOBP_ID" EmptyDataText="无相关记录!" GridLines="None" OnRowCancelingEdit="GridView6_RowCancelingEdit"
                        OnRowEditing="GridView6_RowEditing" OnRowUpdating="GridView6_RowUpdating">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="WOBP_ID" SortExpression="WOBP_ID" HeaderText="WOBP_ID"
                                Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="不良品类别" HeaderText="不良品类别" ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="数量" HeaderText="数量"></asp:BoundField>
                            <asp:BoundField DataField="原因说明" HeaderText="原因说明"></asp:BoundField>
                            <asp:CommandField ShowEditButton="True" EditText="编辑" UpdateText="更新" CancelText="关闭" />
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
    <asp:UpdatePanel ID="UpdatePanel_People" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_People" runat="server" Visible="False">
                <fieldset>
                    <legend>随工单作业员信息表
                        <asp:Label ID="label_People_WODID" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="label_PBCName" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="label_PBC_ID_P" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 1402px">
                            </td>
                            <td style="width: 1402px" id="jjlx" runat="server">
                                批量选择计件类型：<asp:DropDownList ID="DropDownList12" runat="server" AutoPostBack="True"
                                    OnSelectedIndexChanged="DropDownList12_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td>
                            </td>
                            <td align="right" style="width: 131px">
                                <asp:Button ID="Button3" runat="server" CssClass="Button02" Height="24px" OnClick="Button3_Click"
                                    Text="添加员工" Width="70px" />
                            </td>
                            <td align="right" style="width: 131px">
                            </td>
                            <td align="right">
                                <asp:Button ID="Button1" runat="server" CssClass="Button02" Height="24px" OnClick="Button1_Click"
                                    Text="关闭" Width="70px" />
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView_People" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        CellPadding="0" UseAccessibleHeader="False" AllowPaging="False" Width="100%"
                        DataKeyNames="OI_ID" EmptyDataText="无相关记录!" GridLines="None" OnRowCommand="GridView_People_RowCommand"
                        OnRowCancelingEdit="GridView_People_RowCancelingEdit" OnRowEditing="GridView_People_RowEditing"
                        OnRowUpdating="GridView_People_RowUpdating">
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
                            <asp:BoundField DataField="OI_ID" SortExpression="OI_ID" HeaderText="作业员信息ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="工号" SortExpression="工号" HeaderText="工号" ReadOnly="true">
                            </asp:BoundField>
                            <asp:BoundField DataField="姓名" SortExpression="姓名" HeaderText="姓名" ReadOnly="true">
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="计件类型">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lbl1" Text='<%#Eval("计件类型") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="Dltype1111111111" runat="server" DataSource='<%#GetDs2() %>'
                                        DataTextField="计件类型" DataValueField="SPI_ID">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="计件数" SortExpression="计件数" HeaderText="计件数"></asp:BoundField>
                            <asp:CommandField ShowEditButton="True" EditText="编辑" UpdateText="更新" CancelText="关闭">
                            </asp:CommandField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="checktime" runat="server" CommandArgument='<%#Eval("OI_ID") +","+ Eval("工号") %>'
                                        CommandName="checktime">计时信息查看</asp:LinkButton>
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
                    <table width="100%" runat="server" id="t1">
                        <tr>
                            <td style="width: 320px;">
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBoxAll" runat="server" Text="全选" Width="80px" AutoPostBack="True"
                                    OnCheckedChanged="CheckBoxAll_CheckedChanged" Style="margin-left: 0px" />
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBoxfanxuan" runat="server" Text="反选" Width="141px" AutoPostBack="True"
                                    OnCheckedChanged="Checkfanxuan_CheckedChanged" />
                            </td>
                            <td>
                                <asp:Button ID="Btn_deleting" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_deleting_Click"
                                    Text="删除" Width="80px" />
                            </td>
                            <td style="width: 320px;">
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_Product" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Product" runat="server" Visible="false">
                <fieldset>
                    <legend>待选员工检索</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 3%" align="center">
                                班组：
                            </td>
                            <td align="left" style="width: 9%">
                                <asp:DropDownList ID="DropDownList5" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList5_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td align="center" style="width: 7%">
                                <asp:Label ID="Label10" runat="server" Text="工号："></asp:Label>
                            </td>
                            <td style="width: 10%" align="left">
                                <asp:TextBox ID="TextBox_Series" runat="server" Width="98%"></asp:TextBox>
                            </td>
                            <td style="width: 7%" align="center">
                                <asp:Label ID="Label11" runat="server" Text="姓名："></asp:Label>
                            </td>
                            <td style="width: 10%" align="left">
                                <asp:TextBox ID="TextBox_ProductName" runat="server" Width="98%"></asp:TextBox>
                            </td>
                            <td style="width: 15%" align="center">
                                <asp:Button ID="Button14" runat="server" Text="检索" CssClass="Button02" Height="24px"
                                    OnClick="SelectProType" Width="70px" />
                                &nbsp;
                                <asp:Button ID="Button15" runat="server" CssClass="Button02" Height="24px" OnClick="Button15_Click"
                                    Text="重置" Width="70px" />
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView_ProType" runat="server" AllowPaging="True" PageSize="10"
                        Width="100%" AutoGenerateColumns="False" CellPadding="0" CssClass="GridViewStyle"
                        GridLines="None" DataKeyNames="HRDD_ID" AllowSorting="True" OnPageIndexChanging="GridView_ProType_PageIndexChanging">
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridviewHead" BorderStyle="Double" BorderWidth="1px" Height="26px"
                            HorizontalAlign="Center" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemStyle Width="5%" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox2" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="HRDD_ID" HeaderText="人事档案ID" Visible="false" />
                            <asp:BoundField DataField="工号" HeaderText="工号" ItemStyle-Width="45%" />
                            <asp:BoundField DataField="姓名" HeaderText="姓名" ItemStyle-Width="45%" />
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第 &nbsp;<asp:Label ID="lblPageIndex" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>' />
                                        页 共 &nbsp;<asp:Label ID="lblPageCount" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />
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
                            <asp:Label ID="Label16" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                        <AlternatingRowStyle />
                    </asp:GridView>
                    <table width="100%">
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
                                    OnClick="Button_AddPTToSeries_Click" Text="添加" Width="70px" />
                            </td>
                            <td style="width: 320px;">
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%;">
                        <tr>
                            <td align="center">
                                <asp:Button ID="Button_ClosePT" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Btn_Close_PT_Click" Text="关闭" Width="70px" />
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_Time" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Time" runat="server" Visible="False">
                <fieldset>
                    <legend>作业员计时信息表
                        <asp:Label ID="label_OIID" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td align="right">
                                &nbsp;
                            </td>
                            <td align="right" style="width: 647px">
                                <asp:Button ID="Button16" runat="server" CssClass="Button02" Height="24px" OnClick="Button16_Click"
                                    Text="添加计时项目" Width="100px" />
                            </td>
                            <td align="right">
                                <asp:Button ID="Button2" runat="server" CssClass="Button02" Height="24px" OnClick="Button2_Click"
                                    Text="关闭" Width="70px" />
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView_Time" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        CellPadding="0" UseAccessibleHeader="False" AllowPaging="False" Width="100%"
                        DataKeyNames="OT_ID" EmptyDataText="无相关记录!" GridLines="None" OnRowCancelingEdit="GridView_Time_RowCancelingEdit"
                        OnRowEditing="GridView_Time_RowEditing" OnRowUpdating="GridView_Time_RowUpdating">
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
                            <asp:BoundField DataField="OT_ID" SortExpression="OT_ID" HeaderText="计时信息ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="计时项目" SortExpression="计时项目" HeaderText="计时项目" ReadOnly="true">
                            </asp:BoundField>
                            <asp:BoundField DataField="计时时长" SortExpression="计时时长" HeaderText="计时时长"></asp:BoundField>
                            <asp:BoundField DataField="OT_Num" SortExpression="OT_Num" HeaderText="数量"></asp:BoundField>
                            <asp:CommandField ShowEditButton="True" EditText="编辑" UpdateText="更新" CancelText="关闭" />
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
                    <table width="100%" runat="server" id="t2">
                        <tr>
                            <td style="width: 310px;">
                            </td>
                            <td style="width: 26px">
                                <asp:CheckBox ID="CheckBox3" runat="server" Text="全选" Width="83px" AutoPostBack="True"
                                    OnCheckedChanged="CheckBoxAll3_CheckedChanged" />
                            </td>
                            <td style="width: 38px">
                                <asp:CheckBox ID="CheckBox4" runat="server" Text="反选" Width="141px" AutoPostBack="True"
                                    OnCheckedChanged="Checkfanxuan3_CheckedChanged" />
                            </td>
                            <td style="width: 93px">
                                <asp:Button ID="Button4" runat="server" CssClass="Button02" Height="24px" OnClick="Button4_Click"
                                    Text="删除" Width="70px" />
                            </td>
                            <td style="width: 320px;">
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel2" runat="server" Visible="False">
                <fieldset>
                    <legend>待选计时项目
                        <asp:Label ID="label1" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td align="right">
                                &nbsp;
                            </td>
                            <td align="right" style="width: 647px">
                                &nbsp;
                            </td>
                            <td align="right">
                                <asp:Button ID="Button6" runat="server" CssClass="Button02" Height="24px" OnClick="Button6_Click"
                                    Text="关闭" Width="70px" />
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        CellPadding="0" UseAccessibleHeader="False" AllowPaging="False" Width="100%"
                        DataKeyNames="STI_ID" EmptyDataText="无相关记录!" GridLines="None">
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
                            <asp:BoundField DataField="STI_ID" SortExpression="STI_ID" HeaderText="计时项目ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="计时项目" SortExpression="计时项目" HeaderText="计时项目" ReadOnly="true">
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
                    <table width="100%" runat="server" id="Table1">
                        <tr>
                            <td style="width: 310px;">
                            </td>
                            <td style="width: 26px">
                                <asp:CheckBox ID="CheckBox5" runat="server" Text="全选" Width="83px" AutoPostBack="True"
                                    OnCheckedChanged="CheckBoxAll5_CheckedChanged" />
                            </td>
                            <td style="width: 38px">
                                <asp:CheckBox ID="CheckBox6" runat="server" Text="反选" Width="141px" AutoPostBack="True"
                                    OnCheckedChanged="Checkfanxuan6_CheckedChanged" />
                            </td>
                            <td style="width: 93px">
                                <asp:Button ID="Button7" runat="server" CssClass="Button02" Height="24px" OnClick="Button7_Click"
                                    Text="添加" Width="70px" />
                            </td>
                            <td style="width: 320px;">
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
