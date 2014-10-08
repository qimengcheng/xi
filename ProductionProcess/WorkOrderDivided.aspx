<%@ Page Title="" Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true"
    CodeFile="WorkOrderDivided.aspx.cs" Inherits="ProductionProcess_WorkOrderDivided" %>

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
                                    <asp:ListItem>技术</asp:ListItem>
                                    <asp:ListItem>OEM</asp:ListItem>
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
                                    <asp:ListItem>已合单</asp:ListItem>
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
                    <table width="100%">
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
                        Width="100%" DataKeyNames="WO_ID,WO_Type,WO_ProType,WO_Num,WOD_QNum,WO_State,WO_PT_ID"
                        EmptyDataText="无相关记录!" GridLines="None" OnDataBound="GridView_WOmain_DataBound">
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
                            <asp:BoundField DataField="WO_ID" SortExpression="WO_ID" HeaderText="随工单信息ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="WOD_ID" SortExpression="WOD_ID" HeaderText="随工单详细ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="WO_Num" SortExpression="WO_Num" HeaderText="随工单号" ReadOnly="true">
                            </asp:BoundField>
                            <asp:BoundField DataField="WO_FirstInNum" SortExpression="WO_FirstInNum" HeaderText="总投入数"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WO_Type" SortExpression="WO_Type" HeaderText="类型" ReadOnly="true">
                            </asp:BoundField>
                            <asp:BoundField DataField="PBC_Name" SortExpression="PBC_Name" HeaderText="工序" ReadOnly="true">
                            </asp:BoundField>
                            <asp:BoundField DataField="WO_State" SortExpression="WO_State" HeaderText="状态" ReadOnly="true">
                            </asp:BoundField>
                            <asp:BoundField DataField="WO_OrderNum" SortExpression="WO_OrderNum" HeaderText="订单号"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WO_ProType" SortExpression="WO_ProType" HeaderText="产品型号"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WO_SN" SortExpression="WO_SN" HeaderText="周期码" ReadOnly="true">
                            </asp:BoundField>
                            <asp:BoundField DataField="WOD_InTime" SortExpression="WOD_InTime" HeaderText="开始时间"
                                ReadOnly="true" DataFormatString="{0:yyyy-MM-dd HH:mm}"></asp:BoundField>
                            <asp:BoundField DataField="WOD_Error" SortExpression="WOD_Error" HeaderText="异常"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WOD_OverTime" SortExpression="WOD_OverTime" HeaderText="超时"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WO_Note" SortExpression="WO_Note" HeaderText="备注" ReadOnly="true">
                            </asp:BoundField>
                            <asp:BoundField DataField="pihao" SortExpression="pihao" HeaderText="材料批号" ReadOnly="true">
                            </asp:BoundField>
                            <asp:BoundField DataField="WOD_QNum" SortExpression="WOD_QNum" HeaderText="合格数" ReadOnly="true">
                            </asp:BoundField>
                            <asp:BoundField DataField="WO_PT_ID" SortExpression="WO_PT_ID" HeaderText="产品型号ID"
                                ReadOnly="true" Visible="False"></asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="BasicInfo" runat="server" CommandArgument='<%#Eval("WO_ID") +","+ Eval("WO_Num")+","+ Eval("WO_ProType") +","+ Eval("WO_PT_ID")%>'
                                        CommandName="BasicInfo">详情</asp:LinkButton>
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
                    <table width="100%">
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
                                    Text="添加至合单" Width="104px" />
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
            <asp:Panel ID="Panel2" runat="server" Visible="false">
                <fieldset>
                 <asp:UpdateProgress ID="UpdateProgress3" runat="server">
                        <ProgressTemplate>
                            <div align="center">
                                
                                <img src="..\images\loading2.gif" alt="Wait" />请勿重复操作！
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 84px">
                                已选随工单：
                            </td>
                            <td style="width: 567px">
                                <asp:TextBox ID="TextBox8" runat="server" Enabled="False" Height="98px" TextMode="MultiLine"
                                    Width="93%"></asp:TextBox>
                                <asp:Label ID="Label18" runat="server" ForeColor="Red" Text="*"></asp:Label>
                            </td>
                            <td style="width: 136px" align="right">
                                <asp:Button ID="Button16" runat="server" CssClass="Button02" Height="24px" OnClick="Button16_Click"
                                    Text="重置" Width="70px" />
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 84px">
                                合单类型：
                            </td>
                            <td style="width: 104px">
                                <asp:DropDownList ID="DropDownList5" runat="server">
                                    <asp:ListItem Value="QA-">品保常规合单</asp:ListItem>
                                    <asp:ListItem Value="QA-E">品保加工合单</asp:ListItem>
                                    <asp:ListItem Value="QA-M">品保模块合单</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="left" style="width: 60px">
                                数量总计：
                            </td>
                            <td align="left" style="width: 136px">
                                <asp:TextBox ID="TextBox5" runat="server" Enabled="False">0</asp:TextBox>
                            </td>
                            <td align="left" style="width: 51px">
                                周期码：
                            </td>
                            <td align="left" style="width: 145px">
                                <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                                <asp:Label ID="Label17" runat="server" ForeColor="Red" Text="*"></asp:Label>
                            </td>
                            <td align="left" style="width: 59px">
                                批号：
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                <asp:Label ID="Label6" runat="server" ForeColor="Red" Text="*"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 84px">
                                月第一天：
                            </td>
                            <td style="width: 104px">
                                <asp:DropDownList ID="DropDownList8" runat="server">
                                    <asp:ListItem>26</asp:ListItem>
                                    <asp:ListItem>25</asp:ListItem>
                                    <asp:ListItem>24</asp:ListItem>
                                    <asp:ListItem>23</asp:ListItem>
                                    <asp:ListItem>22</asp:ListItem>
                                    <asp:ListItem>27</asp:ListItem>
                                    <asp:ListItem>28</asp:ListItem>
                                    <asp:ListItem>29</asp:ListItem>
                                    <asp:ListItem>30</asp:ListItem>
                                    <asp:ListItem>31</asp:ListItem>
                                    <asp:ListItem>1</asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>3</asp:ListItem>
                                    <asp:ListItem>4</asp:ListItem>
                                    <asp:ListItem>5</asp:ListItem>
                                    <asp:ListItem>6</asp:ListItem>
                                    <asp:ListItem>7</asp:ListItem>
                                    <asp:ListItem>8</asp:ListItem>
                                    <asp:ListItem>9</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                    <asp:ListItem>11</asp:ListItem>
                                    <asp:ListItem>12</asp:ListItem>
                                    <asp:ListItem>13</asp:ListItem>
                                    <asp:ListItem>14</asp:ListItem>
                                    <asp:ListItem>15</asp:ListItem>
                                    <asp:ListItem>16</asp:ListItem>
                                    <asp:ListItem>17</asp:ListItem>
                                    <asp:ListItem>18</asp:ListItem>
                                    <asp:ListItem>19</asp:ListItem>
                                    <asp:ListItem>20</asp:ListItem>
                                    <asp:ListItem>21</asp:ListItem>
                                    <asp:ListItem>22</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="left" style="width: 60px">
                                &nbsp;
                            </td>
                            <td align="left" style="width: 136px">
                                &nbsp;
                            </td>
                            <td align="left" style="width: 51px">
                                &nbsp;
                            </td>
                            <td align="left" style="width: 145px">
                                &nbsp;
                            </td>
                            <td align="left" style="width: 59px">
                                &nbsp;
                            </td>
                            <td align="left">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 84px">
                                请按顺序插入
                            </td>
                            <td colspan="6">
                                <asp:DropDownList ID="DropDownList9" runat="server">
                                </asp:DropDownList>
                                <asp:Button ID="Button18" runat="server" CssClass="Button02" Height="24px" OnClick="Button18_Click"
                                    Text="添加" Width="70px" />
                            </td>
                            <td align="left">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 84px">
                                合单后的工序：
                            </td>
                            <td colspan="6">
                                <asp:TextBox ID="TextBox9" runat="server" Enabled="False" Height="98px" TextMode="MultiLine"
                                    Width="93%"></asp:TextBox>
                                <asp:Label ID="Label19" runat="server" ForeColor="Red" Text="*"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Button ID="Button17" runat="server" CssClass="Button02" Height="24px" OnClick="Button17_Click"
                                    Text="重置工序" Width="70px" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 84px">
                                &nbsp;
                            </td>
                            <td style="width: 104px">
                                &nbsp;
                            </td>
                            <td align="right" style="width: 60px">
                                &nbsp;
                            </td>
                            <td align="right" style="width: 136px">
                                <asp:Button ID="Button_Cancel1" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_Cancel1_Click" Text="确认合单" Width="70px" />
                            </td>
                            <td align="right" style="width: 51px">
                                &nbsp;
                            </td>
                            <td align="right" style="width: 145px">
                                <asp:Button ID="Button_Cancel2" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_Cancel12_Click" Text="关闭" Width="70px" />
                            </td>
                            <td align="right" style="width: 59px">
                                &nbsp;
                            </td>
                            <td align="right">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <legend>随工单合单
                        <asp:Label ID="label5" runat="server" Visible="False" Text="00000000-0000-0000-0000-000000000000"></asp:Label>
                        <asp:Label ID="label_hedanID" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="label_hedanhao" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="label_hedanxinghao" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="label_Hedangongxu" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="WO_PT_ID" runat="server" Visible="False"></asp:Label>
                    </legend>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" Visible="false">
                <fieldset>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 62px">
                                &nbsp;
                            </td>
                            <td style="width: 43px">
                                &nbsp;
                            </td>
                            <td align="left" style="width: 66px">
                                &nbsp;
                            </td>
                            <td align="left" style="width: 121px">
                                &nbsp;
                            </td>
                            <td align="left">
                                &nbsp;
                            </td>
                            <td align="right">
                                &nbsp;
                            </td>
                            <td align="right">
                                <asp:Button ID="Button_Cancel0" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_Cancel0_Click" Text="关闭" Width="70px" />
                            </td>
                        </tr>
                    </table>
                    <legend>随工单 &nbsp;<asp:Label ID="label_WONum" runat="server"></asp:Label>&nbsp; 详细表
                        <asp:Label ID="label_WO_ID" runat="server" Visible="False" Text="00000000-0000-0000-0000-000000000000"></asp:Label>
                        <asp:Label ID="label_PType" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="label_PTypeID" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        CellPadding="0" UseAccessibleHeader="False" AllowPaging="false" Width="100%"
                        DataKeyNames="WOD_ID,WOD_Class,WOD_InNum,WOD_PBCOrder" EmptyDataText="无相关记录!"
                        OnDataBound="GridView1_DataBound" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand"
                        OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing"
                        OnRowUpdating="GridView1_RowUpdating">
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
                                    <asp:LinkButton ID="Dividing" runat="server" CommandArgument='<%#Eval("WOD_ID") +","+ Eval("PBC_Name")+","+ Eval("PBC_ID")%>'
                                        CommandName="Dividing" Enabled="False" ForeColor="Gray">分单</asp:LinkButton>
                                    <%-- Style='<%# "color:" + (Eval("WOD_InTime").ToString() == "" ? "Black": "Gray" ) %>'--%>
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
    <asp:UpdatePanel ID="UpdatePanel_Divide" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Divide" runat="server" Visible="false">
                <fieldset>
                    <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                        <ProgressTemplate>
                            <div align="center">
                                
                                <img src="..\images\loading2.gif" alt="Wait" />请勿重复操作！
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <legend>对随工单<asp:Label ID="label_WONum0" runat="server" ForeColor="Red"></asp:Label>
                        &nbsp;<asp:Label ID="label_PBCDivide" runat="server" ForeColor="Red"></asp:Label>
                        工序分单&nbsp;
                        <asp:Label ID="Label_WODID" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="Labe_WOID" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="Labe_Protype" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="Label_AddOrderNum" runat="server" Text="00000000-0000-0000-0000-000000000000"
                            Visible="False"></asp:Label>
                    </legend>
                    <table width="100%">
                        <tr>
                            <td style="width: 150px" align="center">
                                母单号：
                            </td>
                            <td style="width: 180px" align="left">
                                <asp:TextBox ID="TextBox_WOMotherNum" runat="server" Width="100px" Enabled="False"></asp:TextBox>
                                <asp:Label ID="label_PBCDivide0" runat="server" ForeColor="Red">*</asp:Label>
                            </td>
                            <td style="width: 206px" align="right">
                                &nbsp;
                            </td>
                            <td align="right" class="auto-style3" style="width: 96px">
                                &nbsp;
                            </td>
                            <td align="right" class="auto-style3" style="width: 124px">
                                &nbsp;
                            </td>
                            <td align="left" style="width: 109px">
                                &nbsp;
                            </td>
                            <td style="width: 106px" align="center">
                                &nbsp;
                            </td>
                            <td align="right" style="width: 106px">
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="width: 150px">
                                产品型号：
                            </td>
                            <td align="left" class="auto-style3" style="width: 180px">
                                <asp:TextBox ID="TextBox_WOMotherNum0" runat="server" Enabled="False" Width="100px"></asp:TextBox>
                                <asp:Label ID="label_PBCDivide1" runat="server" ForeColor="Red">*</asp:Label>
                            </td>
                            <td align="left" style="width: 206px">
                                <asp:Button ID="Btn_Search0" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_Search0_Click"
                                    Text="选择..." Width="50px" />
                            </td>
                            <td align="right" class="auto-style3" style="width: 96px">
                                <asp:Label ID="Label_PTID" runat="server" Visible="False"></asp:Label>
                            </td>
                            <td align="right" class="auto-style3" style="width: 124px">
                                &nbsp;
                            </td>
                            <td align="left" style="width: 109px">
                            </td>
                            <td align="center" style="width: 106px">
                                &nbsp;
                            </td>
                            <td align="right" style="width: 106px">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="width: 150px">
                                订单号：
                            </td>
                            <td align="left" class="auto-style3" style="width: 180px">
                                <asp:TextBox ID="TextBox_WOMotherNum1" runat="server" Enabled="False" Width="100px"></asp:TextBox>
                            </td>
                            <td align="left" style="width: 206px">
                                <asp:Button ID="Btn_Search1" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_Search1_Click"
                                    Text="选择..." Width="50px" />
                                <asp:Label ID="label_PBCDivide5" runat="server" ForeColor="Red">加工订单必填</asp:Label>
                            </td>
                            <td align="left" style="width: 96px">
                                &nbsp;
                            </td>
                            <td align="right" class="auto-style3" style="width: 124px">
                                <asp:Label ID="Label_ChipType" runat="server" Visible="False"></asp:Label>
                            </td>
                            <td align="left" style="width: 109px">
                                &nbsp;
                            </td>
                            <td align="center" style="width: 106px">
                                &nbsp;
                            </td>
                            <td align="right" style="width: 106px">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="width: 150px">
                                周期码：
                            </td>
                            <td align="left" class="auto-style3" style="width: 180px">
                                <asp:TextBox ID="TextBox_WOMotherNum2" runat="server" Width="100px"></asp:TextBox>
                            </td>
                            <td align="left" style="width: 206px">
                                <asp:Label ID="label3" runat="server" ForeColor="Red">加工订单必填</asp:Label>
                            </td>
                            <td align="justify" style="width: 96px">
                                &nbsp;
                            </td>
                            <td align="right" class="auto-style3" style="width: 124px">
                                <asp:Label ID="Label_PTCodeMeaning" runat="server" Visible="False"></asp:Label>
                            </td>
                            <td align="left" style="width: 109px">
                                &nbsp;
                            </td>
                            <td align="center" style="width: 106px">
                                &nbsp;
                            </td>
                            <td align="right" style="width: 106px">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="width: 150px">
                                母单总可分出数：
                            </td>
                            <td align="left" style="width: 180px">
                                <asp:Label ID="Label_yuannum" runat="server"></asp:Label>
                            </td>
                            <td align="right" class="auto-style3" style="width: 206px">
                                &nbsp;
                            </td>
                            <td align="right" class="auto-style3" style="width: 96px">
                                &nbsp;
                            </td>
                            <td align="right" class="auto-style3" style="width: 124px">
                                &nbsp;
                            </td>
                            <td align="left" style="width: 109px">
                                &nbsp;
                            </td>
                            <td align="center" style="width: 106px">
                                &nbsp;
                            </td>
                            <td align="right" style="width: 106px">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="width: 150px">
                                分出数量：
                            </td>
                            <td align="left" style="width: 180px">
                                <asp:TextBox ID="TextBox_InputNum" runat="server" MaxLength="8" onafterpaste="this.value=this.value.replace(/\D/g,'')"
                                    onkeyup="this.value=this.value.replace(/\D/g,'')" Width="100px"></asp:TextBox>
                                <asp:Label ID="label_PBCDivide3" runat="server" ForeColor="Red">*</asp:Label>
                            </td>
                            <td align="right" class="auto-style3" style="width: 206px">
                                &nbsp;
                            </td>
                            <td align="right" class="auto-style3" style="width: 96px">
                                &nbsp;
                            </td>
                            <td align="right" class="auto-style3" style="width: 124px">
                                <asp:Label ID="Label_Note" runat="server" Visible="False"></asp:Label>
                            </td>
                            <td align="left" style="width: 109px">
                                &nbsp;
                            </td>
                            <td align="center" style="width: 106px">
                                &nbsp;
                            </td>
                            <td align="right" style="width: 106px">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="width: 150px">
                                子单备注：
                            </td>
                            <td align="left" colspan="7">
                                <asp:TextBox ID="TextBox4" runat="server" Enabled="True" Height="98px" MaxLength="200"
                                    onafterpaste="this.value = this.value.substring(0, 1000)" onkeyup="this.value = this.value.substring(0, 500)"
                                    TextMode="MultiLine" Width="93%"></asp:TextBox>
                                <asp:Label ID="label_PBCDivide4" runat="server" ForeColor="Red">*</asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table width="100%">
                        <tr>
                            <td align="center">
                                &nbsp;
                            </td>
                            <td align="center">
                                <asp:Button ID="Btn_Dividing" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_Dividing_Click"
                                    Text="分单" Width="70px" />
                            </td>
                            <td align="center">
                                <asp:Button ID="Button_CloseDividing" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_CloseDividing_Click" Text="关闭" Width="70px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_Product" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Product_Search" runat="server" Visible="false">
                <fieldset>
                    <legend>产品型号检索</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 7%" align="center">
                                <asp:Label ID="Label10" runat="server" Text="产品系列："></asp:Label>
                            </td>
                            <td style="width: 7%" align="left">
                                <asp:TextBox ID="TextBox_Series" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 7%" align="center">
                                <asp:Label ID="Label11" runat="server" Text="产品型号："></asp:Label>
                            </td>
                            <td style="width: 7%" align="left">
                                <asp:TextBox ID="TextBox_ProductName" runat="server"></asp:TextBox>
                            </td>
                            <td align="left" style="width: 7%">
                                产品编码：
                            </td>
                            <td style="width: 10%" align="left">
                                <asp:TextBox ID="TextBox_ProductName0" runat="server"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 7%">
                                编码含义：
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:TextBox ID="TextBox_ProductName1" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="width: 7%">
                            </td>
                            <td align="left" style="width: 7%">
                            </td>
                            <td align="center" style="width: 6%">
                                &nbsp;
                            </td>
                            <td align="center" style="width: 7%">
                                <asp:Button ID="Button14" runat="server" CssClass="Button02" Height="24px" OnClick="SelectProType"
                                    Text="检索" Width="70px" />
                            </td>
                            <td align="center" style="width: 6%">
                                &nbsp;
                            </td>
                            <td align="center" style="width: 10%">
                                <asp:Button ID="Button15" runat="server" CssClass="Button02" Height="24px" OnClick="Button15_Click"
                                    Text="重置" Width="70px" />
                            </td>
                            <td align="center" style="width: 6%">
                            </td>
                            <td align="center" style="width: 10%">
                                <asp:Button ID="Button_ClosePT" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Btn_Close_PT_Click" Text="关闭" Width="70px" />
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
            <asp:Panel ID="Panel_Product" runat="server" Visible="false">
                <fieldset>
                    <legend>产品型号表<asp:Label ID="Label_PT_NewOrOld" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <asp:GridView ID="GridView_ProType" runat="server" AllowPaging="True" PageSize="15"
                        Width="100%" AutoGenerateColumns="False" CellPadding="0" CssClass="GridViewStyle"
                        DataKeyNames="PT_ID" AllowSorting="True" OnPageIndexChanging="GridView_ProType_PageIndexChanging"
                        OnRowDataBound="GridView_ProType_RowDataBound" OnRowCommand="GridView_ProType_RowCommand"
                        OnDataBound="GridView_ProType_DataBound" GridLines="None">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="PT_ID" HeaderText="产品型号ID" Visible="false" />
                            <asp:BoundField DataField="PS_Name" HeaderText="产品系列" />
                            <asp:BoundField DataField="PT_Name" HeaderText="产品型号" />
                            <asp:BoundField DataField="PT_Code" HeaderText="产品编码" />
                            <asp:BoundField DataField="PT_CodeMeanning" HeaderText="代码含义" />
                            <asp:BoundField DataField="ChipType" HeaderText="标准芯片大小" />
                            <asp:BoundField DataField="PT_Note" HeaderText="备注" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="SelectPT" runat="server" CommandArgument='<%#Eval("PT_ID") +","+ Eval("PT_Name")+","+ Eval("PT_CodeMeanning")+","+ Eval("ChipType")+","+ Eval("PS_Name")%>'
                                        CommandName="SelectPT">选择</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
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
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_SelectOrder" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_SelectOrder" runat="server" Visible="false">
                <fieldset>
                    <legend>选择订单号</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 7%" align="center">
                                <asp:Label ID="Label1" runat="server" Text="客户订单号："></asp:Label>
                            </td>
                            <td style="width: 10%" align="left">
                                <asp:TextBox ID="TextBox_CustOrder" runat="server" Width="98%"></asp:TextBox>
                            </td>
                            <td style="width: 7%" align="center">
                                <asp:Label ID="Label2" runat="server" Text="公司订单号："></asp:Label>
                            </td>
                            <td style="width: 10%" align="left">
                                <asp:TextBox ID="TextBox_ComOrderNum" runat="server" Width="107%"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Button ID="Button_SearchOrder" runat="server" Text="检索" CssClass="Button02"
                                    Height="24px" OnClick="Button_SearchOrder_Click" Width="70px" />
                                <td style="width: 10%" align="center">
                                    <asp:Button ID="Button_Close_SearchOrder" runat="server" CssClass="Button02" Height="24px"
                                        OnClick="Btn_Close_SearchOrder_Click" Text="关闭" Width="70px" />
                                </td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView_Order" runat="server" AllowPaging="True" PageSize="10"
                        Width="100%" AutoGenerateColumns="False" CellPadding="0" CssClass="GridViewStyle"
                        DataKeyNames="SMSO_ID" AllowSorting="True" OnPageIndexChanging="GridView_Order_PageIndexChanging"
                        OnRowDataBound="GridView_Order_RowDataBound" OnRowCommand="GridView_Order_RowCommand"
                        GridLines="None">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="SMSO_ID" HeaderText="订单ID" Visible="false" />
                            <asp:BoundField DataField="SMSO_CusOrderNum" HeaderText="客户订单号" />
                            <asp:BoundField DataField="SMSO_ComOrderNum" HeaderText="公司订单号" />
                            <asp:BoundField DataField="SMSO_PlaceOrderTime" HeaderText="下单日期" DataFormatString="{0:yyyy-MM-dd HH:mm}" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Select_Order" runat="server" CommandArgument='<%#Eval("SMSO_ID") +","+ Eval("SMSO_CusOrderNum")+","+ Eval("SMSO_ComOrderNum") +","+ Eval("SMSO_PlaceOrderTime","{0:yyyy-MM-dd HH:mm}")%>'
                                        CommandName="Select_Order">选择</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
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
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
