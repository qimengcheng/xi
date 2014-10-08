<%@ Page Title="" Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true"
    CodeFile="WorkOrderCreate.aspx.cs" Inherits="ProductionProcess_WorkOrderCreate" %>

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
                            <td style="width: 11%;" align="center">
                                随工单类型：
                            </td>
                            <td style="width: 11%;">
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
                            <td align="center" style="width: 12%;">
                                随工单生成人：
                            </td>
                            <td align="left" style="width: 70px;">
                                <asp:TextBox ID="TextBox_WO_People" runat="server" Width="100px"></asp:TextBox>
                            </td>
                            <td style="width: 16%;" align="center">
                                随工单生成时间：
                            </td>
                            <td style="width: 15%;" align="left">
                                <asp:TextBox ID="TextBox_WO_Time1" Width="115px" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 3%;">
                                至
                            </td>
                            <td align="left" style="width: 15%;">
                                <asp:TextBox ID="TextBox_WO_Time2" Width="115px" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="width: 100%;">
                            <td style="width: 9%;" align="center">
                                随工状态：
                            </td>
                            <td style="width: 8%;" align="left">
                                <asp:DropDownList ID="DropDownList_WoState" runat="server">
                                    <asp:ListItem Value="">请选择</asp:ListItem>
                                    <asp:ListItem>已建立</asp:ListItem>
                                    <asp:ListItem>待入库</asp:ListItem>
                                    <asp:ListItem>工序开启</asp:ListItem>
                                    <asp:ListItem>工序完工</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="width: 9%" align="center">
                                产品型号：
                            </td>
                            <td style="width: 9%" align="left">
                                <asp:TextBox ID="TextBox_WO_ProType" runat="server" Width="100px"></asp:TextBox>
                            </td>
                            <td style="width: 9%;" align="center">
                                &nbsp;订单号：
                            </td>
                            <td style="width: 10%;" align="left">
                                <asp:TextBox ID="TextBox_OrderNum" runat="server" Width="100px"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 7%;">
                                &nbsp;
                            </td>
                            <td align="left" style="width: 15%;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr style="width: 100%;">
                            <td style="width: 9%;" align="center">
                                随工单号：
                            </td>
                            <td style="width: 8%;" align="left">
                                <asp:TextBox ID="TextBox_WO_Num" runat="server" Width="100px"></asp:TextBox>
                            </td>
                            <td style="width: 9%" align="center">
                                芯片大小：
                            </td>
                            <td style="width: 9%" align="left">
                                <asp:TextBox ID="TextBox_chipnum" runat="server" Width="100px"></asp:TextBox>
                            </td>
                            <td style="width: 9%;" align="center">
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
                                <asp:Button ID="Btn_Search" runat="server" Text="检索" Width="70px" Height="24px" CssClass="Button02"
                                    OnClick="Btn_Search_Click" />
                                &nbsp;
                            </td>
                            <td style="width: 97px" class="style1">
                            </td>
                            <td>
                                <asp:Button ID="Btn_AddWO" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_AddWO_Click"
                                    Text="新增随工单" Width="70px" />
                            </td>
                            <td style="width: 169px">
                                &nbsp;
                            </td>
                            <td>
                                <asp:Button ID="Button_Cancel" runat="server" CssClass="Button02" Height="24px" OnClick="Button_Cancel_Click"
                                    Text="重置" Width="70px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_AddWorkOrder" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_AddWorkOrder" runat="server" Visible="false">
                <fieldset>
                    <legend>新增随工单 </legend>
                    <table style="width: 100%; height: 23px;">
                        <tr style="width: 100%;">
                            <td style="width: 14%;" align="center">
                                随工单类型：
                            </td>
                            <td style="width: 8%;">
                                <asp:DropDownList ID="DropDownList_Add_WO_Type" runat="server">
                                    <asp:ListItem Value="">正常</asp:ListItem>
                                    <asp:ListItem Value="EN-">实验</asp:ListItem>
                                    <asp:ListItem Value="OEM-">OEM</asp:ListItem>
                                    <asp:ListItem Value="T-">技术</asp:ListItem>
                                    <asp:ListItem Value="QA-">检验</asp:ListItem>
                                    <asp:ListItem Value="Y-">样品</asp:ListItem>
                                </asp:DropDownList>
                                <asp:Label ID="Label23" runat="server" ForeColor="Red" Text="*"></asp:Label>
                            </td>
                            <td align="center" style="width: 10%;">
                                产品型号：
                            </td>
                            <td align="left" style="width: 10%">
                                <asp:TextBox ID="TextBox_AddPT" runat="server" Enabled="False"></asp:TextBox>
                            </td>
                            <td style="width: 6%;" align="left">
                                <asp:Button ID="Btn_SelectPT" runat="server" Text="选择..." Width="35px" Height="24px"
                                    CssClass="Button02" OnClick="Btn_SelectPT_Click" />
                                <asp:Label ID="Label17" runat="server" ForeColor="Red" Text="*"></asp:Label>
                            </td>
                            <td style="width: 11%;" align="center">
                                芯片码：
                            </td>
                            <td style="width: 7%;" align="left">
                                <asp:DropDownList ID="DropDownList1" runat="server">
                                    <asp:ListItem>A</asp:ListItem>
                                    <asp:ListItem>J</asp:ListItem>
                                </asp:DropDownList>
                                <asp:Label ID="Label21" runat="server" ForeColor="Red" Text="*"></asp:Label>
                            </td>
                            <td align="left" style="width: 10%;">
                                桥壳码：
                            </td>
                            <td align="left" style="width: 9%;">
                                <asp:DropDownList ID="DropDownList2" runat="server">
                                    <asp:ListItem Value="">请选择</asp:ListItem>
                                    <asp:ListItem>B</asp:ListItem>
                                    <asp:ListItem>C</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="width: 9%;" align="center">
                                引脚码：
                            </td>
                            <td style="width: 10%;" align="left">
                                <asp:DropDownList ID="DropDownList3" runat="server">
                                    <asp:ListItem Value="">请选择</asp:ListItem>
                                    <asp:ListItem>Y</asp:ListItem>
                                    <asp:ListItem>J</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr style="width: 100%;">
                            <td style="width: 14%;" align="center">
                                计划数量：
                            </td>
                            <td style="width: 6%;" align="left">
                                <asp:TextBox ID="TextBox_Add_PNum" runat="server" MaxLength="8" onafterpaste="this.value=this.value.replace(/\D/g,'')"
                                    onkeyup="this.value=this.value.replace(/\D/g,'')" Width="50px"></asp:TextBox>
                                <asp:Label ID="Label18" runat="server" ForeColor="Red" Text="*"></asp:Label>
                            </td>
                            <td style="width: 10%;" align="center">
                                订单号：
                            </td>
                            <td style="width: 10%;" align="left">
                                <asp:TextBox ID="TextBox_Add_Order" runat="server" Enabled="False"></asp:TextBox>
                            </td>
                            <td style="width: 5%;" align="left">
                                <asp:Button ID="Button_SelectOrder" runat="server" Text="选择..." Width="35px" Height="24px"
                                    CssClass="Button02" OnClick="Btn_SelectOrder_Click" />
                            </td>
                            <td style="width: 11%" align="center">
                                月第一天设定
                            </td>
                            <td style="width: 6%" align="left">
                                <asp:DropDownList ID="DropDownList4" runat="server">
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
                                <asp:Label ID="Label22" runat="server" ForeColor="Red" Text="*"></asp:Label>
                            </td>
                            <td align="left" colspan="4">
                                印字附加码：
                                <asp:DropDownList ID="DropDownList5" runat="server">
                                    <asp:ListItem Value="">请选择</asp:ListItem>
                                    <asp:ListItem>H</asp:ListItem>
                                    <asp:ListItem>A</asp:ListItem>
                                    <asp:ListItem>B</asp:ListItem>
                                    <asp:ListItem>C</asp:ListItem>
                                    <asp:ListItem>D</asp:ListItem>
                                    <asp:ListItem>E</asp:ListItem>
                                    <asp:ListItem>F</asp:ListItem>
                                    <asp:ListItem>G</asp:ListItem>
                                    <asp:ListItem>I</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="DropDownList6" runat="server">
                                    <asp:ListItem Value="">请选择</asp:ListItem>
                                    <asp:ListItem>H</asp:ListItem>
                                    <asp:ListItem>A</asp:ListItem>
                                    <asp:ListItem>B</asp:ListItem>
                                    <asp:ListItem>C</asp:ListItem>
                                    <asp:ListItem>D</asp:ListItem>
                                    <asp:ListItem>E</asp:ListItem>
                                    <asp:ListItem>F</asp:ListItem>
                                    <asp:ListItem>G</asp:ListItem>
                                    <asp:ListItem>I</asp:ListItem>
                                </asp:DropDownList>
                                <asp:Label ID="Label_OT" runat="server" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="width: 14%;">
                                备注：(100字内)
                            </td>
                            <td align="left" colspan="6">
                                <asp:TextBox ID="TextBox_AddNote" runat="server" Width="100%"></asp:TextBox>
                            </td>
                            <td align="left" style="width: 10%">
                                周期码：
                            </td>
                            <td align="left" style="width: 9%">
                                <asp:TextBox ID="TextBox_Add_SN" runat="server" MaxLength="8" Width="100%"></asp:TextBox>
                            </td>
                            <td style="width: 9%">
                                <asp:Label ID="Label24" runat="server" ForeColor="Red" Text="选填"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label_PS" runat="server" Visible="False"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td style="width: 204px">
                                <asp:Label ID="Label_AddOrderNum" runat="server" Visible="False"></asp:Label>
                                <asp:Label ID="Label_PTID" runat="server" Visible="False"></asp:Label>
                            </td>
                            <td style="width: 95px">
                                <asp:Label ID="Label_ChipType" runat="server" Visible="False"></asp:Label>
                            </td>
                            <td style="width: 97px" class="style1">
                                <asp:Button ID="Button_Submit_Add" runat="server" Text="提交" Width="70px" Height="24px"
                                    CssClass="Button02" OnClick="Btn_Submit_Add_Click" />
                            </td>
                            <td>
                            </td>
                            <td style="width: 37px">
                                <asp:Label ID="Label_PTCodeMeaning" runat="server" Visible="False"></asp:Label>
                            </td>
                            <td>
                                <asp:Button ID="Button_CancelAdd" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_CancelAdd_Click" Text="关闭" Width="70px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_EditWorkOrder" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_EditWorkOrder" runat="server" Visible="false">
                <fieldset>
                    <legend>编辑随工单
                        <asp:Label ID="Label_EditWOID" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="Label_EditWONum" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="Label_EditPTID" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <table style="width: 100%; height: 23px;">
                        <tr style="width: 100%;">
                            <td style="width: 20%;" align="center">
                                随工单号：
                            </td>
                            <td style="width: 10%;">
                                <asp:TextBox ID="TextBox_EditNum" runat="server"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 20%;">
                                产品型号：
                            </td>
                            <td align="left" style="width: 10%">
                                <asp:TextBox ID="TextBox_EditProType" runat="server" Enabled="False"></asp:TextBox>
                            </td>
                            <td style="width: 10%;" align="left">
                                <asp:Button ID="Btn_SelectProType" runat="server" Text="选择..." Width="35px" Height="24px"
                                    CssClass="Button02" OnClick="Btn_SelectProType_Click" />
                                <asp:Label ID="Label_Red" runat="server" ForeColor="Red" Text="*"></asp:Label>
                            </td>
                            <td style="width: 15%;" align="center">
                                订单号：
                            </td>
                            <td style="width: 10%;" align="left">
                                <asp:TextBox ID="TextBox_EditOrderNum" runat="server" Enabled="False"></asp:TextBox>
                            </td>
                            <td style="width: 5%;" align="left">
                                <asp:Button ID="Button_SelectOrderNum" runat="server" Text="选择..." Width="35px" Height="24px"
                                    CssClass="Button02" OnClick="Button_SelectOrderNum_Click" />
                            </td>
                        </tr>
                        <tr style="width: 100%;">
                            <td align="center" style="width: 20%;">
                                备注：(100字内)
                            </td>
                            <td align="left" colspan="4">
                                <asp:TextBox ID="TextBox_EditNote" runat="server" Width="100%"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 15%">
                                周期码：
                            </td>
                            <td align="left" style="width: 9%">
                                <asp:TextBox ID="TextBox_EditSN" runat="server" MaxLength="8" Width="100%"></asp:TextBox>
                            </td>
                            <td style="width: 9%">
                                <asp:Label ID="Label4" runat="server" ForeColor="Red" Text="选填"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%">
                        <tr style="width: 100%">
                            <td style="width: 30%" class="style1">
                                <asp:Label ID="Label_EditPS" runat="server" Visible="False"></asp:Label>
                                <asp:Label ID="Label_EditOrderNum" runat="server" Visible="False"></asp:Label>
                            </td>
                            <td style="width: 20%" class="style1">
                                <asp:Button ID="Button_EditSubmit" runat="server" Text="提交" Width="70px" Height="24px"
                                    CssClass="Button02" OnClick="Button_EditSubmit_Click" />
                            </td>
                            <td style="width: 20%" class="style1">
                                <asp:Button ID="Button_EditCancel" runat="server" CssClass="Button02" Height="24px"
                                    Text="关闭" Width="70px" OnClick="Button_EditCancel_Click" />
                            </td>
                            <td style="width: 30%" class="style1">
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
                                <asp:TextBox ID="TextBox_ComOrderNum" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                周期码：<td align="center">
                                    <asp:TextBox ID="TextBox_ComOrderNum0" runat="server"></asp:TextBox>
                                </td>
                        </tr>
                        <tr>
                            <td align="center" style="width: 7%">
                                &nbsp;
                            </td>
                            <td align="left" style="width: 10%">
                                &nbsp;
                            </td>
                            <td align="center" style="width: 7%">
                                <asp:Button ID="Button_SearchOrder" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_SearchOrder_Click" Text="检索" Width="70px" />
                            </td>
                            <td align="left" style="width: 10%">
                                &nbsp;
                            </td>
                            <td align="center" style="width: 10%">
                                <asp:Button ID="Button_Close_SearchOrder" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Btn_Close_SearchOrder_Click" Text="关闭" Width="70px" />
                                <td align="center" style="width: 10%">
                                    &nbsp;
                                </td>
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView_Order" runat="server" AllowPaging="True" PageSize="10"
                        Width="100%" AutoGenerateColumns="False" CellPadding="0" CssClass="GridViewStyle"
                        DataKeyNames="SMSO_ID,OEMOT_SNum" AllowSorting="True" OnPageIndexChanging="GridView_Order_PageIndexChanging"
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
                            <asp:BoundField DataField="OEMOT_SNum" HeaderText="周期码" />
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
                        Width="100%" DataKeyNames="WO_ID" EmptyDataText="无相关记录!" GridLines="None" OnDataBound="GridView_WOmain_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="WO_ID" SortExpression="WO_ID" HeaderText="随工单信息ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="WO_Num" SortExpression="WO_Num" HeaderText="随工单号" ReadOnly="true">
                            </asp:BoundField>
                            <asp:BoundField DataField="WO_Type" SortExpression="WO_Type" HeaderText="类型" ReadOnly="true">
                            </asp:BoundField>
                            <asp:BoundField DataField="WO_ProType" SortExpression="WO_ProType" HeaderText="型号"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WO_PT_Code" SortExpression="WO_PT_Code" HeaderText="产品详情"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WO_State" SortExpression="WO_State" HeaderText="状态" ReadOnly="true">
                            </asp:BoundField>
                            <asp:BoundField DataField="SMSO_CusOrderNum" SortExpression="SMSO_CusOrderNum" HeaderText="订单号"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WO_SN" SortExpression="WO_SN" HeaderText="周期码" ReadOnly="true">
                            </asp:BoundField>
                            <asp:BoundField DataField="WO_PrintWord" SortExpression="WO_PrintWord" HeaderText="印字附加码"
                                Visible="false" ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WO_Level" SortExpression="WO_Level" HeaderText="档次" ReadOnly="true"
                                Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="WO_PT_ChipType" SortExpression="WO_PT_ChipType" HeaderText="标准芯片"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WO_PNum" SortExpression="WO_PNum" HeaderText="计划数量" ReadOnly="true">
                            </asp:BoundField>
                            <asp:BoundField DataField="WO_Note" SortExpression="WO_Note" HeaderText="备注" ReadOnly="true">
                            </asp:BoundField>
                            <asp:BoundField DataField="WO_People" SortExpression="WO_People" HeaderText="生成人"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WO_Time" SortExpression="WO_Time" HeaderText="生成时间" DataFormatString="{0:yyyy-MM-dd HH:mm}"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="SMSO_PlaceOrderTime" SortExpression="SMSO_PlaceOrderTime"
                                HeaderText="下单日期" Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="PS_Name" SortExpression="PS_Name" HeaderText="产品系列" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="CB" SortExpression="CB" HeaderText="芯片代码" Visible="false">
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Deleted" runat="server" CommandArgument='<%#Eval("WO_ID") %>'
                                        OnClientClick="return confirm('将会删除该随工单，确定吗？')" CommandName="Deleted">删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="BasicInfo" runat="server" CommandArgument='<%#Eval("WO_ID") +","+ Eval("WO_ProType")+","+ Eval("WO_Type") %>'
                                        CommandName="BasicInfo">基础信息</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="editWorkWorder" runat="server" CommandArgument='<%#Eval("WO_ID") +","+ Eval("WO_Num") +","+ Eval("WO_ProType")+","+ Eval("SMSO_CusOrderNum")+","+ Eval("WO_Note")+","+ Eval("WO_SN")+","+ Eval("WO_PT_ID")+","+ Eval("SMSO_ID") %>'
                                        CommandName="editWorkWorder">编辑</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="materialsheet" runat="server" CommandArgument='<%#Eval("WO_ID") +","+ Eval("WO_Num") +","+ Eval("SMSO_CusOrderNum") +","+ Eval("WO_ProType") +","+ Eval("WO_PNum") +","+ Eval("WO_Level")+","+ Eval("WO_Type") +","+ Eval("WO_People") +","+ Eval("WO_Time","{0:yyyy-MM-dd HH:mm}")  %>'
                                        CommandName="materialsheet">领料</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="printpreview" runat="server" CommandArgument='<%#Eval("WO_ID") +","+ Eval("WO_Num") +","+ Eval("WO_Type")+","+ Eval("SMSO_CusOrderNum")+","+ Eval("SMSO_PlaceOrderTime","{0:yyyy-MM-dd HH:mm}")+","+ Eval("PS_Name")+","+ Eval("WO_SN")+","+ Eval("CB")+","+ Eval("WO_ProType") %>'
                                        CommandName="printpreview">打印</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="WO_PT_ID" SortExpression="WO_PT_ID" HeaderText="产品型号ID"
                                Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="SMSO_ID" SortExpression="SMSO_ID" HeaderText="订单ID" Visible="false">
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
                        CellPadding="0" UseAccessibleHeader="False" OnRowCommand="GridView_bom_RowCommand"
                        OnPageIndexChanging="GridView_bom_PageIndexChanging" AllowSorting="True" OnSorting="GridView_bom_Sorting"
                        OnRowDataBound="GridView_bom_RowDataBound" Width="100%" DataKeyNames="BD_ID"
                        EmptyDataText="无相关记录!" GridLines="None" OnDataBound="GridView_bom_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="BD_ID" HeaderText="BOM详细ID" SortExpression="BD_ID" Visible="false" />
                            <asp:BoundField DataField="IMMBD_MaterialName" HeaderText="物料名称" SortExpression="IMMBD_MaterialName"
                                Visible="true" />
                            <asp:BoundField DataField="IMMBD_SpecificationModel" HeaderText="规格型号" SortExpression="IMMBD_SpecificationModel"
                                Visible="true" />
                            <asp:BoundField DataField="PBC_Name" HeaderText="工序名称" SortExpression="SMSMPM_Year"
                                Visible="true" />
                            <asp:BoundField DataField="BD_MUse" HeaderText="标准用量" SortExpression="SMSMPM_Month"
                                Visible="true" />
                            <asp:BoundField DataField="BD_MRUse" HeaderText="实际用量" SortExpression="SMSMPM_MakeMan"
                                Visible="true" />
                            <asp:BoundField DataField="UnitName" HeaderText="计量单位" SortExpression="SMSMPM_MakeTime"
                                Visible="true" />
                            <asp:BoundField DataField="StoreUse" HeaderText="库存用量" SortExpression="SMSMPM_MakeMan"
                                Visible="true" />
                            <asp:BoundField DataField="StoreUnitName" HeaderText="库存单位" SortExpression="SMSMPM_MakeTime"
                                Visible="true" />
                            <asp:BoundField DataField="BD_Note" HeaderText="备注" SortExpression="PMP_STime" Visible="true" />
                            <asp:BoundField DataField="BDMate" HeaderText="替用物料" SortExpression="BDMate" Visible="true" />
                            <asp:BoundField DataField="IMMBD_MaterialID" HeaderText="物料ID" SortExpression="IMMBD_MaterialID"
                                Visible="true">
                                <HeaderStyle CssClass="hide" />
                                <ItemStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PBC_ID" HeaderText="工序ID" SortExpression="PCB_ID" Visible="true">
                                <HeaderStyle CssClass="hide" />
                                <ItemStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BD_IsFuse" HeaderText="组合物料" NullDisplayText="否" SortExpression="BD_IsFuse" />
                            <asp:BoundField DataField="BD_FuseID" HeaderText="组合代号" NullDisplayText="无" SortExpression="BD_FuseID" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Batch_Num" runat="server" CommandArgument='<%#Eval("BD_ID") +","+ Eval("IMMBD_MaterialID") %>'
                                        CommandName="Batch_Num">批号信息</asp:LinkButton>
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
                    <asp:Label ID="Label_pr" runat="server" Text="工艺路线(流程)"></asp:Label><br />
                    <asp:Label ID="Label20" runat="server" ForeColor="Red"></asp:Label>
                    <asp:GridView ID="GridView_Pr" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        CellPadding="0" UseAccessibleHeader="False" AllowPaging="false" OnRowCommand="GridView_Pr_RowCommand"
                        OnPageIndexChanging="GridView_Pr_PageIndexChanging" AllowSorting="True" OnSorting="GridView_Pr_Sorting"
                        OnRowDataBound="GridView_Pr_RowDataBound" Width="100%" DataKeyNames="PRD_ID"
                        EmptyDataText="无相关记录!" GridLines="None" OnDataBound="GridView_Pr_DataBound">
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
                            <td height="50px">
                                <asp:Label ID="Label_TestParameter" runat="server" Text="产品测试参数: "></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox_TestParameter" runat="server" Width="700px" Enabled="False"
                                    Height="48px" TextMode="MultiLine"></asp:TextBox>
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
    <asp:UpdatePanel ID="UpdatePanel_Batch" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Batch" runat="server" Visible="False">
                <fieldset>
                    <legend>材料批号信息
                        <asp:Label ID="Label_iMMBD_MaterialID" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 15%" align="left">
                                <asp:Button ID="Button_ChooseBatch" runat="server" Text="新增批号" CssClass="Button02"
                                    Height="24px" OnClick="Button_ChooseBatch_Click" Width="70px" />
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView_Batch" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        PageSize="5" CellPadding="0" UseAccessibleHeader="False" AllowPaging="True" OnRowCommand="GridView_Batch_RowCommand"
                        OnPageIndexChanging="GridView_Batch_PageIndexChanging" AllowSorting="True" OnRowDataBound="GridView_Batch_RowDataBound"
                        Width="100%" DataKeyNames="WOMBN_ID" EmptyDataText="无相关记录!" GridLines="None"
                        OnDataBound="GridView_Batch_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="WOMBN_ID" SortExpression="WOMBN_ID" HeaderText="批号信息ID"
                                Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="WOMBN_BN" SortExpression="WOMBN_BN" HeaderText="物料批号"
                                ReadOnly="true"></asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="deleteBatch" runat="server" CommandArgument='<%#Eval("WOMBN_ID") +","+ Eval("WOMBN_BN") %>'
                                        OnClientClick="return confirm('您确认删除该批号吗?')" CommandName="deleteBatch">删除</asp:LinkButton>
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
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 15%" align="center">
                                <asp:Button ID="Button_Close_ChoseBatch" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Btn_Close_ChooseBatch_Click" Text="关闭" Width="70px" />
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_MBatch" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_MBatch" runat="server" Visible="False">
                <fieldset>
                    <legend>库存材料批号信息 </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 7%" align="center">
                                <asp:Label ID="Label3" runat="server" Text="物料批号："></asp:Label>
                            </td>
                            <td style="width: 10%" align="left">
                                <asp:TextBox ID="TextBox_MBatch" runat="server" Width="98%"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Button ID="Button_SearchBatch" runat="server" Text="检索" CssClass="Button02"
                                    Height="24px" OnClick="Button_SearchBatch_Click" Width="70px" />
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Button ID="Btn_Close_ChooseMBatch" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Btn_Close_ChooseMBatch_Click" Text="关闭" Width="70px" />
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView_BasicBatch" runat="server" AutoGenerateColumns="false"
                        CssClass="GridViewStyle" PageSize="10" CellPadding="0" UseAccessibleHeader="False"
                        AllowPaging="True" OnRowCommand="GridView_BasicBatch_RowCommand" OnPageIndexChanging="GridView_BasicBatch_PageIndexChanging"
                        AllowSorting="True" OnRowDataBound="GridView_BasicBatch_RowDataBound" Width="100%"
                        DataKeyNames="IMID_ID" EmptyDataText="无相关记录!" GridLines="None" OnDataBound="GridView_BasicBatch_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="IMID_ID" SortExpression="IMID_ID" HeaderText="库存ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="IMID_BatchNum" SortExpression="IMID_BatchNum" HeaderText="物料批号"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="IMMBD_MaterialName" SortExpression="IMMBD_MaterialName"
                                HeaderText="物料名称" ReadOnly="true" Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="IMID_InHouseTime" SortExpression="IMID_InHouseTime" HeaderText="入库时间"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="PMSI_SupplyName" SortExpression="PMSI_SupplyName" HeaderText="供应商名称"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="IMID_Num" SortExpression="IMID_Num" HeaderText="库存数量"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="IMID_QA" SortExpression="IMID_QA" HeaderText="品保判定结果"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="IMID_DownLevel" SortExpression="IMID_DownLevel" HeaderText="是否降档"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="IMID_DownLevelPara" SortExpression="IMID_DownLevelPara"
                                HeaderText="降档参数" ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="IMID_Over" SortExpression="IMID_Over" HeaderText="是否报废"
                                ReadOnly="true"></asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="ChoseBatchToWO" runat="server" CommandArgument='<%#Eval("IMID_ID") +","+ Eval("IMID_BatchNum") +","+ Eval("IMMBD_MaterialName") %>'
                                        CommandName="ChoseBatchToWO">选择</asp:LinkButton>
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
