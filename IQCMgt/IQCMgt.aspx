<%@ Page Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true"
    CodeFile="IQCMgt.aspx.cs" Inherits="IQCMgt_IQCMgt"  EnableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script language="javascript" type="text/javascript">

        function ValidtorTime(start, end) {
            var idstart = "ctl00_ContentPlaceHolder1_" + start;
            var idend = "ctl00_ContentPlaceHolder1_" + end;
            var d1 = new Date(document.getElementById(idstart).value.replace(/\-/g, "\/"));
            var d2 = new Date(document.getElementById(idend).value.replace(/\-/g, "\/"));
            if (d1 > d2) {
                return false;
            }
            return true;
        }

        function onlynumanddot(obj) {
            obj.value = obj.value.replace(/[^\d.]/g, "");
        }

        function annotation(name) {
            var id = "ctl00_ContentPlaceHolder1_" + name;
            var label = document.getElementById(id);
            label.style.visibility = 'visible';
            return false;
        }
        function leave(name) {
            var id = "ctl00_ContentPlaceHolder1_" + name;
            var label = document.getElementById(id);
            label.style.visibility = 'hidden';
            return false;
        }

        function isdigit(name) {
            var id = "ctl00_ContentPlaceHolder1_" + name;
            var s = document.getElementById(id).value;
            var r, re;
            re = /\d*/i; //\d表示数字,*表示匹配多个数字
            r = s.match(re);
            return (r == s) ? true : false;
        }
    </script>
    <asp:UpdatePanel ID="UpdatePanel_SearchMaterial" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_SearchMaterial" runat="server">
                   <asp:Label ID="cond1l" runat="server" Visible="false"></asp:Label>
                 <asp:Label ID="PTl" runat="server" Visible="false"></asp:Label>
                 <asp:Label ID="PSl" runat="server" Visible="false"></asp:Label>
                <fieldset>
                    <legend>物料检索栏</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 7%" align="right">
                                <asp:Label ID="Label1" runat="server" CssClass="STYLE2" Text="物料名称："></asp:Label>
                            </td>
                            <td style="width: 15%">
                                <asp:TextBox ID="TxtMaterialName" runat="server" Width="155px" MaxLength="50"></asp:TextBox>
                            </td>
                            <td style="width: 7%" align="right">
                                <asp:Label ID="Label10" runat="server" CssClass="STYLE2" Text="规格型号："></asp:Label>
                            </td>
                            <td style="width: 15%">
                                <asp:TextBox ID="TxtMaterialCode" runat="server" Width="155px" MaxLength="50"></asp:TextBox>
                            </td>
                            <td style="width: 7%" align="right">
                                <asp:Label ID="Label12" runat="server" CssClass="STYLE2" Text="供货单位："></asp:Label>
                            </td>
                            <td style="width: 15%">
                                <asp:TextBox ID="TxtSupplyName" runat="server" Width="155px" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 7px;">
                            <td style="width: 10%" align="right">
                                <asp:Label ID="LblPost" runat="server" CssClass="STYLE2" Text="到货时间：" ></asp:Label>
                            </td>
                            <td style="width: 17%">
                                <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
                                <asp:TextBox ID="TxtArriveTime1" runat="server" Width="155px" 
                                    onfocus="new WdatePicker(this,'%Y-%M-%D',true)"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label6" runat="server" CssClass="STYLE2" Text="到"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
                                <asp:TextBox ID="TxtArriveTime2" runat="server" Width="155px" 
                                    onfocus="new WdatePicker(this,'%Y-%M-%D',true)"></asp:TextBox>
                            </td>
                             <td style="width: 7%" align="right">
                                <asp:Label ID="Label30" runat="server" CssClass="STYLE2" Text="批号："></asp:Label>
                            </td>
                            <td style="width: 15%">
                                <asp:TextBox ID="TextBox1" runat="server" Width="155px" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%;" align="center">
                        <tr>
                            <td style="width: 15%">
                            </td>
                            <td align="center" style="width: 35%">
                                <asp:Button ID="BtnSearchMaterial" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="BtnSearchMaterial_Click" Text="检索" Width="70px" />
                            </td>
                            <td align="center" style="width: 35%">
                                <asp:Button ID="BtnResetMaterial" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="BtnResetMaterial_Click" Text="重置" Width="70px" />
                            </td>
                            <td style="width: 15%">
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_GridMaterial" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_GridMaterial" runat="server">
                <fieldset>
                    <legend>待检物料信息表</legend>
                    <asp:GridView ID="Grid_Material" runat="server" DataKeyNames="IMISD_ID" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                        Visible="true" GridLines="None" AllowPaging="True" PageSize="10" UseAccessibleHeader="False"
                        OnPageIndexChanging="Grid_Material_PageIndexChanging" OnRowCommand="Grid_Material_RowCommand"
                        OnDataBound="Grid_Material_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="IMISD_ID" HeaderText="入库单明细表ID" ReadOnly="True" SortExpression="IMISD_ID"
                                Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="IMMBD_MaterialID" HeaderText="物料ID" ReadOnly="True" SortExpression="IMMBD_MaterialID"
                                Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="IMISM_InStoreNum" SortExpression="IMISM_InStoreNum" HeaderText="入库单号">
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMT_MaterialType" SortExpression="IMMT_MaterialType"
                                HeaderText="物料类别"></asp:BoundField>
                            <asp:BoundField DataField="IMMBD_MaterialName" SortExpression="IMMBD_MaterialName"
                                HeaderText="物料名称"></asp:BoundField>
                            <asp:BoundField DataField="IMMBD_MaterialCode" SortExpression="IMMBD_MaterialCode"
                                HeaderText="物料编码"></asp:BoundField>
                             
                            <asp:BoundField DataField="IMMBD_SpecificationModel" SortExpression="IMMBD_SpecificationModel"
                                HeaderText="规格型号"></asp:BoundField>
                            <asp:BoundField DataField="IMISD_BatchNum" SortExpression="IMISD_BatchNum"
                                HeaderText="批号"></asp:BoundField>
                            <asp:BoundField DataField="PMSI_SupplyName" SortExpression="PMSI_SupplyName" HeaderText="供货单位">
                            </asp:BoundField>
                            <asp:BoundField DataField="IMIDS_ActualArrNum" SortExpression="IMIDS_ActualArrNum"
                                HeaderText="到货数量"></asp:BoundField>
                            <asp:BoundField DataField="UnitName" SortExpression="UnitName" HeaderText="单位"></asp:BoundField>
                            <asp:BoundField DataField="IMISM_InStoreTime" SortExpression="IMISM_InStoreTime"
                                HeaderText="到货日期"  DataFormatString="{0:yyyy-MM-dd HH:mm}"></asp:BoundField>
                             <asp:BoundField DataField="IMIDS_WONum" SortExpression="IMIDS_WONum"
                                HeaderText="认证单数量"></asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnNew_CertMessage" runat="server" CommandArgument='<%#Eval("IMISD_ID")%>'
                                        CommandName="New_CertMessage" OnClientClick="false">新增认证信息</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnView_CertDetail" runat="server" CommandName="View_CertDetail"
                                        OnClientClick="false" CommandArgument='<%#Eval("IMISD_ID")%>'>查看认证详情</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnNew_Test" runat="server" CommandArgument='<%#Eval("IMISD_ID") +","+ Eval("IMMBD_MaterialName") +","+ Eval("IMMBD_MaterialID") %>'
                                        CommandName="New_Test" OnClientClick="false">录入检验结果</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第&nbsp;<asp:Label ID="lblPageIndex" runat="server" align="center" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>' />
                                        页 共&nbsp;<asp:Label ID="lblPageCount" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />
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
                            <asp:Label ID="Label16" runat="server" Text="没有找到相关记录"></asp:Label>
                        </EmptyDataTemplate>
                        <EditRowStyle BackColor="white" />
                    </asp:GridView>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
       <asp:UpdatePanel ID="UpdatePanel_AddWorkOrder" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_AddWorkOrder" runat="server" Visible="false">
                  <asp:Label ID="Label28" runat="server" Visible="False"></asp:Label>
                  <asp:Label ID="Label29" runat="server" Visible="False"></asp:Label>
                <fieldset>
                    <legend>新增随工单 </legend>
                    <table style="width: 100%; height: 23px;">
                        <tr style="width: 100%;">
                            <td style="width: 14%;" align="center">
                                随工单类型：
                            </td>
                            <td style="width: 8%;">
                                <asp:DropDownList ID="DropDownList_Add_WO_Type" runat="server" Enabled="false">
                                       <asp:ListItem Value="QA-">检验</asp:ListItem>
                                    <asp:ListItem Value="">正常</asp:ListItem>
                                    <asp:ListItem Value="EN-">实验</asp:ListItem>
                                 
                                </asp:DropDownList>
                                <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="*"></asp:Label>
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
                                <asp:Label ID="Label4" runat="server" ForeColor="Red" Text="*"></asp:Label>
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
                                <asp:Label ID="Label5" runat="server" ForeColor="Red" Text="*"></asp:Label>
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
                                <asp:Label ID="Label20" runat="server" ForeColor="Red" Text="*"></asp:Label>
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
  
    <asp:UpdatePanel ID="UpdatePanel_Product" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Product_Search" runat="server" Visible="false">
                <fieldset>
                    <legend>产品型号检索</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label7" runat="server" Text="产品系列："></asp:Label>
                            </td>
                            <td style="width: 40%" align="left">
                                <asp:TextBox ID="TextBox_Series" runat="server" Width="155px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label11" runat="server" Text="产品型号："></asp:Label>
                            </td>
                            <td style="width: 40%" align="left">
                                <asp:TextBox ID="TextBox_ProductName" runat="server" Width="155px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 90%;" align="center">
                        <tr>
                            <td align="right">
                                <asp:Button ID="Button14" runat="server" Text="检索" CssClass="Button02" Height="24px"
                                    OnClick="SelectProType" Width="70px" />
                            </td>
                            <td align="center">
                                <asp:Button ID="Button1" runat="server" Text="重置" CssClass="Button02" Height="24px"
                                    OnClick="Reset1" Width="70px" />
                            </td>
                            <td align="left">
                                <asp:Button ID="Button_ClosePT" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Btn_Close_PT_Click" Text="关闭" Width="70px" />
                            <%--    <asp:Button ID="Button4" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Excel1" Text="导出Excel" Width="70px"  />--%>
                            </td>
                        </tr>
                        <tr>
                            
                            <td align="left" colspan="3">
                                  <asp:Label ID="Label27" runat="server" ForeColor="Red" Text="操作提示：如果已经添加产品型号为认证产品型号，但在此页面无法找到，请联系生产部填入该产品型号的对应随工单编码！"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%;">
                        <asp:GridView ID="GridView_ProType" runat="server" AllowPaging="True" PageSize="5"
                            Width="100%" AutoGenerateColumns="False" CellPadding="0" CssClass="GridViewStyle"
                            DataKeyNames="PT_ID" AllowSorting="True" OnPageIndexChanging="GridView_ProType_PageIndexChanging"
                            OnRowDataBound="GridView_ProType_RowDataBound" OnRowCommand="GridView_ProType_RowCommand">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle  cssclass="GridViewHead"/>
                        <FooterStyle CssClass="GridViewFooterStyle" />
                            <Columns>
                                <asp:BoundField DataField="PT_ID" HeaderText="产品型号ID" Visible="false" />
                                <asp:BoundField DataField="PS_Name" HeaderText="产品系列" ItemStyle-Width="30%" />
                                <asp:BoundField DataField="PT_Name" HeaderText="产品型号" ItemStyle-Width="30%" />
                                   <asp:BoundField DataField="PT_Note" HeaderText="产品备注" ItemStyle-Width="30%" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="SelectPT" runat="server" CommandArgument='<%#Eval("PT_ID") +","+ Eval("PT_Name") %>'
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
                    </table>
                </fieldset>
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
                                <asp:Label ID="Label25" runat="server" Text="客户订单号："></asp:Label>
                            </td>
                            <td style="width: 10%" align="left">
                                <asp:TextBox ID="TextBox_CustOrder" runat="server" Width="98%"></asp:TextBox>
                            </td>
                            <td style="width: 7%" align="center">
                                <asp:Label ID="Label26" runat="server" Text="公司订单号："></asp:Label>
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
    <asp:UpdatePanel ID="UpdatePanel_NewExpApp" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_NewExpApp" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="LblExpApp" runat="server" CssClass="STYLE2" Text=""></asp:Label>
                           <asp:Label ID="Label32" runat="server"  Visible="false"></asp:Label>
                         <asp:Label ID="Label31" runat="server"  Visible="false"></asp:Label>
                        <asp:Label ID="Label33" runat="server"  Visible="false"></asp:Label>
                    </legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 13%" align="right">
                                <asp:Label ID="Label8" runat="server" CssClass="STYLE2" Text="物料类别："></asp:Label>
                            </td>
                            <td style="width: 17%" align="left">
                                <asp:TextBox ID="TxtNewMaterialType" runat="server" Width="130px" MaxLength="25"
                                    Enabled="false" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label9" runat="server" CssClass="STYLE2" Text="物料名称："></asp:Label>
                            </td>
                            <td style="width: 14%" align="left">
                                <asp:TextBox ID="TxtNewMaterialName" runat="server" Width="130px" MaxLength="50"
                                    Enabled="false" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label13" runat="server" CssClass="STYLE2" Text="规格型号："></asp:Label>
                            </td>
                            <td style="width: 17%" align="left">
                                <asp:TextBox ID="TxtNewMode" runat="server" Width="130px" MaxLength="50" Enabled="false"
                                    ReadOnly="True"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label22" runat="server" CssClass="STYLE2" Text="物料编码："></asp:Label>
                            </td>
                            <td style="width: 17%" align="left">
                                <asp:TextBox ID="TxtNewMaterialCode" runat="server" Width="130px" MaxLength="50"
                                    Enabled="false" ReadOnly="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label14" runat="server" CssClass="STYLE2" Text="供货单位："></asp:Label>
                            </td>
                            <td style="width: 17%" align="left">
                                <asp:TextBox ID="TxtNewSupplyName" runat="server" Width="130px" Enabled="false" MaxLength="50"
                                    ReadOnly="True"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label15" runat="server" CssClass="STYLE2" Text="到货数量："></asp:Label>
                            </td>
                            <td style="width: 17%" align="left">
                                <asp:TextBox ID="TxtActualNum" runat="server" Width="130px" Enabled="false" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label17" runat="server" CssClass="STYLE2" Text="单位："></asp:Label>
                            </td>
                            <td style="width: 17%" align="left">
                                <asp:TextBox ID="TxtNewUnit" runat="server" Width="130px" Enabled="false" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label18" runat="server" CssClass="STYLE2" Text="到货日期："></asp:Label>
                            </td>
                            <td style="width: 17%" align="left">
                                <asp:TextBox ID="TxtNewArrivalTime" runat="server" Width="130px" Enabled="false"
                                    ReadOnly="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label19" runat="server" CssClass="STYLE2" Text="抽检数："></asp:Label>
                            </td>
                            <td style="width: 17%" align="left">
                                <asp:TextBox ID="TxtNewNum" Width="125px" runat="server" onkeyup="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{4,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{4})[0-9]*/, '$1');" 
                              onafterpaste="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{4,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{4})[0-9]*/, '$1');" MaxLength="8"></asp:TextBox>
                                <asp:Label ID="Label23" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                          <td align="right" style="width: 13%;">
                                预判结果：
                            </td>
                            <td align="left" style="width: 20%">
                                <asp:DropDownList ID="Ddl_AuRe" runat="server"  ToolTip="单击选择"  >
                                    <asp:ListItem  >请选择</asp:ListItem>
                                       <asp:ListItem >精选</asp:ListItem>
                                       <asp:ListItem >普通</asp:ListItem>
                                    <asp:ListItem >合格</asp:ListItem>
                                    <asp:ListItem >降档</asp:ListItem>
                                    <asp:ListItem >让步接收</asp:ListItem>
                                      <asp:ListItem >二次检验</asp:ListItem>
                                    <asp:ListItem >不合格</asp:ListItem>
                                </asp:DropDownList>
                            <td style="width: 10%" align="right">
                            </td>
                            <td style="width: 17%" align="left">
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label3" runat="server" CssClass="STYLE2" Text="说明："></asp:Label>
                                <br>
                                <asp:Label ID="Label100" runat="server" CssClass="STYLE2" Text="(100字以内)"></asp:Label>
                            </td>
                            <td colspan="7" align="left">
                                <asp:TextBox ID="TxtNewNote" runat="server" Width="100%" MaxLength="100" TextMode="MultiLine"
                                    onkeyup="this.value = this.value.substring(0, 100)"
                                    onafterpaste="this.value = this.value.substring(0, 100)"></asp:TextBox>
                            </td>
                            <td colspan="2" align="left">
                            </td>
                        </tr>
                           <tr style="height: 16px;">
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label34" runat="server" CssClass="STYLE2" Text="实验记录："></asp:Label>
                                <br>
                                <asp:Label ID="Label35" runat="server" CssClass="STYLE2" Text="(200字以内)"></asp:Label>
                            </td>
                            <td colspan="7" align="left">
                                <asp:TextBox ID="TextBox2" runat="server" Width="100%" MaxLength="100" TextMode="MultiLine"
                                    onkeyup="this.value = this.value.substring(0, 200)"
                                    onafterpaste="this.value = this.value.substring(0, 200)"></asp:TextBox>
                            </td>
                            <td colspan="2" align="left">
                            </td>
                        </tr>
                         <tr >
                            <td style="width: 80%" colspan="8" >
                                   
                                         <asp:GridView ID="GridView2" runat="server"  AllowSorting="True"
                                    AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                                    Visible="true" GridLines="None" AllowPaging="True" Font-Strikeout="False" UseAccessibleHeader="False" EmptyDataText="没有QA项目">
                                    <RowStyle CssClass="GridViewRowStyle" />
                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                    <HeaderStyle CssClass="GridViewHead" />
                                    <FooterStyle CssClass="GridViewFooterStyle" />
                <Columns>
                
                   
                  
                    <asp:BoundField HeaderText="随工单号"  DataField="WO_Num" />
                    <asp:BoundField HeaderText="QA项目名称" Visible="true"   DataField="BPT_Name"/>
                        <asp:BoundField HeaderText="QA项目数量" Visible="true"   DataField="WOBP_Num"/>

                </Columns>
            </asp:GridView>
                            </td>
                        </tr>
                        <tr style="height: 26px;">
                            <td style="width: 80%" colspan="8">
                                <asp:GridView ID="Grid_ETTestItem" runat="server" DataKeyNames="IQCIT_ID" AllowSorting="True"
                                    AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                                    Visible="true" GridLines="None" AllowPaging="True" Font-Strikeout="False" UseAccessibleHeader="False"
                                    OnPageIndexChanging="Grid_ETTestItem_PageIndexChanging" OnRowCommand="Grid_ETTestItem_RowCommand"
                                    OnDataBound="Grid_ETTestItem_DataBound" PageSize="5">
                                    <RowStyle CssClass="GridViewRowStyle" />
                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                    <HeaderStyle CssClass="GridViewHead" />
                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                    <Columns>
                                        <asp:BoundField DataField="IQCIT_ID" HeaderText="检验项目ID" ReadOnly="True" SortExpression="IQCIT_ID"
                                            Visible="false"></asp:BoundField>
                                        <asp:BoundField DataField="IMMBD_MaterialID" HeaderText="物料基础数据ID" ReadOnly="True"
                                            SortExpression="IMMBD_MaterialID" Visible="false"></asp:BoundField>
                                        <asp:BoundField DataField="IQCIT_Items" SortExpression="IQCIT_Items" HeaderText="检验项目"
                                            ReadOnly="True"></asp:BoundField>
                                        <asp:BoundField DataField="IQCIT_NeedValue" SortExpression="IQCIT_NeedValue" HeaderText="是否录入对应值"
                                            ReadOnly="True"></asp:BoundField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbtnEdit_ItemAmount" runat="server" CommandArgument='<%#Eval("IQCIT_ID")%>'
                                                    CommandName="Edit_ItemAmount" OnClientClick="false">录入检验值</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerTemplate>
                                        <table width="100%">
                                            <tr>
                                                <td style="text-align: right">
                                                    第&nbsp;<asp:Label ID="lblPageIndex" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>' />
                                                    页 共&nbsp;<asp:Label ID="lblPageCount" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />
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
                                        <asp:Label ID="Label16" runat="server" Text="没有找到相关记录"></asp:Label>
                                    </EmptyDataTemplate>
                                    <EditRowStyle BackColor="white" />
                                </asp:GridView>
                            </td>
                        </tr>
                       
                    </table>
                    <table style="width: 90%;" align="center">
                        <tr style="height: 16px;">
                             <td colspan="2" align="center">
                                <asp:Button ID="Button2" runat="server" Text="提交" CssClass="Button02" ValidationGroup="Edit"
                                    Height="24px" Width="70px" OnClick="BtnTijiao_Click" />
                            </td>
                            <%--<td colspan="2" align="right">
                                <asp:Button ID="BtnSave" runat="server" Text="检验合格" CssClass="Button02" ValidationGroup="Edit"
                                    Height="24px" Width="70px" OnClick="BtnSave_Click" />
                            </td>
                            <td colspan="2" align="center">
                                <asp:Button ID="BtnSubmit" runat="server" Text="待审核" CssClass="Button02" ValidationGroup="Edit"
                                    Height="24px" Width="70px" OnClick="BtnSubmit_Click" />
                            </td>--%>
                            <td colspan="2" align="center">
                                <asp:Button ID="BtnClose" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    Width="70px" OnClick="BtnClose_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_Standard" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Standard" runat="server" Visible="false">
                <fieldset>
                    <legend>检验标准 </legend>
                        
                    <asp:GridView ID="Grid_Standard" runat="server" DataKeyNames="IQCST_ID" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                        Visible="true" GridLines="None" AllowPaging="True" PageSize="5" UseAccessibleHeader="False"
                        OnPageIndexChanging="Grid_Standard_PageIndexChanging" OnDataBound="Grid_Standard_DataBound"
                        OnRowUpdating="Grid_Standard_Updating" OnRowEditing="Grid_Standard_Editing" OnRowCancelingEdit="Grid_Standard_CancelingEdit"
                        OnRowDataBound="Grid_Standard_RowDataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="IQCST_ID" HeaderText="检验值ID" ReadOnly="True" SortExpression="IQCST_ID"
                                Visible="false">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IQCIT_Standard" SortExpression="IQCIT_Standard" HeaderText="检验标准"
                                ReadOnly="True"></asp:BoundField>
                            <asp:BoundField DataField="IQCIT_Remarks" SortExpression="IQCIT_Remarks" HeaderText="备注"
                                ReadOnly="True"></asp:BoundField>
                            <asp:BoundField DataField="QCSV_Value" SortExpression="QCSV_Value" HeaderText="对应值">
                            </asp:BoundField>
                            <asp:BoundField DataField="QCSV_Result" SortExpression="QCSV_Result" HeaderText="检验结果">
                            </asp:BoundField>
                            <asp:CommandField ShowEditButton="True" EditText="录入检验值" UpdateText="更新" CancelText="取消">
                                <ItemStyle Width="10%" />
                            </asp:CommandField>
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第&nbsp;<asp:Label ID="lblPageIndex" runat="server" align="center" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>' />
                                        页 共&nbsp;<asp:Label ID="lblPageCount" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />
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
                            <asp:Label ID="Label16" runat="server" Text="没有找到相关记录"></asp:Label>
                        </EmptyDataTemplate>
                        <EditRowStyle BackColor="white" />
                    </asp:GridView>
                    <table style="width: 100%">
                        <tr style="width: 100%; height: 16px;">
                            <td style="width: 100%" align="center">
                                <asp:Button ID="Btn_Close" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    Width="70px" OnClick="Btn_Close_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
     <asp:UpdatePanel ID="UpdatePanel_WOmain" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_WOmain" runat="server" Visible="false">
                  <table style="width: 100%;">
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td align="right">
                                <asp:Button ID="Button3" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_Cancel10_Click" Text="关闭" Width="70px" />
                            </td>
                        </tr>
                    </table>
                <fieldset>
                    <legend>随工单信息表(工序已开)
                        <asp:Label ID="label_GridPageState" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <asp:GridView ID="GridView_WOmain" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                      CellPadding="0" UseAccessibleHeader="False" 
                        OnRowCommand="GridView_WOmain_RowCommand" 
                       OnRowDataBound="GridView_WOmain_RowDataBound"
                        Width="100%" DataKeyNames="WO_ID" EmptyDataText="无相关记录!" GridLines="None" OnDataBound="GridView_WOmain_DataBound">
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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" Visible="false">
                <fieldset>
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
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
                    </legend>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        CellPadding="0" UseAccessibleHeader="False" AllowPaging="false"
                        Width="100%" DataKeyNames="WOD_ID" EmptyDataText="无相关记录!" 
                        OnDataBound="GridView1_DataBound" 
                       >
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="WOD_ID" SortExpression="WOD_ID" HeaderText="随工单详细ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="WOD_PBCOrder" SortExpression="WOD_PBCOrder" HeaderText="顺序"
                                ></asp:BoundField>
                            <asp:BoundField DataField="PBC_ID" SortExpression="PBC_ID" HeaderText="工序" ReadOnly="true"
                                Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="PBC_Name" SortExpression="PBC_Name" HeaderText="工序" ReadOnly="true">
                            </asp:BoundField>
                            <asp:BoundField DataField="WOD_Class" SortExpression="WOD_Class" HeaderText="班次"
                               ></asp:BoundField>
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
                            <asp:BoundField DataField="WOD_WNum" SortExpression="WOD_WNum" HeaderText="废品"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WOD_Error" SortExpression="WOD_Error" HeaderText="异常"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="WOD_OverTime" SortExpression="WOD_OverTime" HeaderText="超时"
                                ReadOnly="true"></asp:BoundField>
                           
                                                 
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
