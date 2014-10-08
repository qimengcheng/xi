<%@ Page Title="" Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true"
    CodeFile="WorkOrderCombine.aspx.cs" Inherits="ProductionProcess_WorkOrderCombine" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel_Search" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Search" runat="server" Visible="true">
                <fieldset>
                    <legend>随工单检索 </legend>
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
                            <td style="width: 70px">
                            </td>
                            <td>
                                <asp:Button ID="Button_Cancel" runat="server" CssClass="Button02" Height="24px" OnClick="Button_Cancel_Click"
                                    Text="重置" Width="70px" />
                            </td>
                            <td>
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
                    <legend>随工单信息表
                        <asp:Label ID="label_GridPageState" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <asp:GridView ID="GridView_WOmain" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        PageSize="10" CellPadding="0" UseAccessibleHeader="False" AllowPaging="True" OnRowCommand="GridView_WOmain_RowCommand"
                        OnPageIndexChanging="GridView_WOmain_PageIndexChanging" AllowSorting="True" OnSorting="GridView_WOmain_Sorting"
                        OnRowDataBound="GridView_WOmain_RowDataBound" Width="100%" DataKeyNames="WO_ID,WO_Num,WO_ProType,WO_ChipNum,WO_PNum,WO_State,WO_OrderNum,WO_Level"
                        EmptyDataText="无相关记录!" GridLines="None" OnDataBound="GridView_WOmain_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:TemplateField HeaderText="选择">
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
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
                            <asp:BoundField DataField="WOD_InNum" SortExpression="WOD_InNum" HeaderText="投入数量"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WO_Note" SortExpression="WO_Note" HeaderText="备注" ReadOnly="true">
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
                    <table width="100%">
                        <tr>
                            <td style="width: 370px">
                            </td>
                            <td style="width: 26px">
                                <asp:CheckBox ID="CheckBoxAll" runat="server" Text="全选" Width="54px" AutoPostBack="True"
                                    OnCheckedChanged="CheckBoxAll_CheckedChanged" />
                            </td>
                            <td style="width: 38px">
                                <asp:CheckBox ID="CheckBoxfanxuan" runat="server" Text="反选" Width="141px" AutoPostBack="True"
                                    OnCheckedChanged="Checkfanxuan_CheckedChanged" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <table width="100%">
                        <tr>
                            <td align="center">
                                <asp:Button ID="Btn_Combing" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_Combing_Click"
                                    Text="合单" Width="70px" />
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_Combine" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Combine" runat="server" Visible="false">
                <fieldset>
                    <legend>随工单合单
                        <asp:Label ID="Label_WODID" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="Labe_WOID" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="Labe_Protype" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <table width="100%">
                        <tr>
                            <td align="left" style="width: 125px">
                                合单类型：
                            </td>
                            <td align="left" style="width: 44px">
                                <asp:DropDownList ID="DropDownList1" runat="server">
                                    <asp:ListItem>认证合单</asp:ListItem>
                                    <asp:ListItem>一般合单</asp:ListItem>
                                    <asp:ListItem>工程合单</asp:ListItem>
                                    <asp:ListItem>异常合单</asp:ListItem>
                                    <asp:ListItem>其它合单</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="width: 100px" align="left">
                                选中的随工单号:
                            </td>
                            <td align="right" colspan="3">
                                <asp:TextBox ID="TextBox_WoNumChecked" runat="server" Width="100%" Enabled="False"></asp:TextBox>
                            </td>
                            <td style="width: 77px" align="left" class="auto-style3">
                                &nbsp;档次：
                            </td>
                            <td align="left" class="auto-style3" style="width: 96px">
                                <asp:DropDownList ID="DropDownList_level_Combine" runat="server">
                                    <asp:ListItem Value="">请选择</asp:ListItem>
                                    <asp:ListItem>A档</asp:ListItem>
                                    <asp:ListItem>B档</asp:ListItem>
                                    <asp:ListItem>C档</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 125px">
                                合单后的随工单号：
                            </td>
                            <td align="left" style="width: 44px">
                                <asp:TextBox ID="TextBox_Newwonum" runat="server" Width="100px"></asp:TextBox>
                            </td>
                            <td align="left" class="auto-style3" style="width: 100px">
                                合单后的周期码：
                            </td>
                            <td align="left" class="auto-style3" style="width: 117px">
                                <asp:TextBox ID="TextBox_SN_Combine" runat="server" Width="100px"></asp:TextBox>
                            </td>
                            <td align="left" style="width: 85px">
                                芯片代码：
                            </td>
                            <td align="left" style="width: 112px">
                                <asp:TextBox ID="TextBox_ChipNum_Conbine" runat="server" Enabled="False" Width="100%"></asp:TextBox>
                            </td>
                            <td align="left" style="width: 77px">
                                &nbsp;产品型号：
                            </td>
                            <td align="right" class="auto-style3" style="width: 105px">
                                <asp:TextBox ID="TextBox_PT_Combine" runat="server" Enabled="False" Width="100%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 125px">
                                计划数量：
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox_PNum_Conbine" runat="server" onkeyup="this.value=this.value.replace(/\D/g,'')"
                                    onafterpaste="this.value=this.value.replace(/\D/g,'')" MaxLength="8" Width="100px"></asp:TextBox>
                            </td>
                            <td align="left" style="width: 100px">
                                原所属订单号：
                            </td>
                            <td align="right" colspan="3">
                                <asp:TextBox ID="TextBox_OrderCombine" runat="server" Enabled="False" Width="100%"></asp:TextBox>
                            </td>
                            <td style="width: 77px">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 125px">
                                备注：
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="TextBox_Note_Combine" runat="server" Width="491px"></asp:TextBox>
                            </td>
                            <td style="width: 77px">
                            </td>
                            <td>
                                <asp:Label ID="Label17" runat="server" Text="Label" Visible="False"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table width="100%">
                        <tr>
                            <td style="width: 67px">
                            </td>
                            <td align="center" style="width: 344px">
                                <asp:Button ID="Btn_CombingConfirm" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Btn_CombingConfirm_Click" Text="合单" Width="70px" />
                            </td>
                            <td align="center">
                                <asp:Button ID="Button_CloseCombing" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_CloseCombing_Click" Text="关闭" Width="70px" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
