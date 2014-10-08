<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SalesOrder.aspx.cs" Inherits="SalesMgt_SalesOrder"
    MasterPageFile="~/Other/MasterPage.master" Title="销售订单管理" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/JS/ShortM.js" />
        </Scripts>--%>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
    <%-- label存放--%>
    <asp:Label ID="label_condition" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="label_condition1" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="label_source" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="label_OrderID" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="label_OrderDetailID" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="label_CustomID" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="label_History" runat="server" Visible="False"></asp:Label>
    <%--检索开始--%>
    <asp:UpdatePanel ID="UpdatePanel_Search" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Search" runat="server" Visible="true">
                <fieldset>
                    <legend>检索条件</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 15%" align="right">
                                客户名称：
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="TextBox3" Width="98px"></asp:TextBox>
                            </td>
                            <td style="width: 12%" align="right">
                                公司订单号：
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="TextBox4" Width="98px"></asp:TextBox>
                            </td>
                            <td style="width: 12%" align="right">
                                客户订单号：
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="TextBox5" Width="98px"></asp:TextBox>
                            </td>
                            <td style="width: 12%" align="right">
                                产品型号：
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="TextBox6" Width="98px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                业务员：
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="TextBox7" Width="98px"></asp:TextBox>
                            </td>
                            <td align="right">
                                区域：
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="TextBox8" Width="98px"></asp:TextBox>
                            </td>
                            <td align="right">
                                特殊产品：
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DropDownList3" runat="server">
                                    <asp:ListItem>选择是否</asp:ListItem>
                                    <asp:ListItem>是</asp:ListItem>
                                    <asp:ListItem>否</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="right">
                                订单状态：
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DropDownList4" runat="server">
                                    <asp:ListItem>选择订单状态</asp:ListItem>
                                    <asp:ListItem>已新建</asp:ListItem>
                                    <asp:ListItem>正常</asp:ListItem>
                                    <asp:ListItem>已发货</asp:ListItem>
                                    <asp:ListItem>冻结</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:DropDownList ID="DropDownList2" runat="server">
                                    <asp:ListItem>选择日期类型</asp:ListItem>
                                    <asp:ListItem>下单日期</asp:ListItem>
                                    <asp:ListItem>交货期</asp:ListItem>
                                    <asp:ListItem>预交货期</asp:ListItem>
                                </asp:DropDownList>
                                从
                            </td>
                            <td align="left" colspan="3">
                                <asp:TextBox runat="server" ID="TextBox1" onfocus="new WdatePicker(this,'%Y-%M-%D ',true)"
                                    DataFormatString="{0:yyyy-MM-dd}" Width="98px"  ></asp:TextBox>
                                到
                                <asp:TextBox runat="server" ID="TextBox2" onfocus="new WdatePicker(this,'%Y-%M-%D ',true)"
                                    DataFormatString="{0:yyyy-MM-dd}" Width="98px"  ></asp:TextBox>
                            </td>
                            <td align="right">
                                订单类型：
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DropDownList5" runat="server">
                                    <asp:ListItem>选择订单类型</asp:ListItem>
                                    <asp:ListItem>正常订单</asp:ListItem>
                                    <asp:ListItem>代工订单</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="right">
                                付款方式：
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DropDownList1" runat="server">
                                    <asp:ListItem>选择付款方式</asp:ListItem>
                                    <asp:ListItem>现款现货</asp:ListItem>
                                    <asp:ListItem>账期</asp:ListItem>
                                    <asp:ListItem>货到付款</asp:ListItem>
                                    <asp:ListItem>预付款</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" >
                            </td>
                            <td align="left">
                                <asp:Button ID="Button3" runat="server" Text="检索" CssClass="Button02" Height="24px"
                                    OnClick="SearchOrder" Width="70px" />
                            </td>
                            <td colspan="2" align="center">
                                <asp:Button ID="Button2" runat="server" Text="新建订单" CssClass="Button02" Height="24px"
                                    OnClick="CreateOrdered" Width="90px" />
                            </td>
                            <td colspan="3" align="left">
                                <asp:Button ID="Button1" runat="server" Text="重置" CssClass="Button02" Height="24px"
                                    OnClick="ClearOrder" Width="70px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <!-- 订单列表开始-->
    <asp:UpdatePanel ID="UpdatePanel_Order" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Order" runat="server" Visible="true">
                <fieldset>
                    <legend>订单表</legend>
                    <asp:GridView ID="GridView_Order" runat="server" AllowPaging="True" PageSize="10"
                        AutoGenerateColumns="False" CellPadding="0" CssClass="GridViewStyle" DataKeyNames="SMSO_ID"
                        AllowSorting="True" OnRowCommand="GridView_Order_RowCommand" Width="100%" OnPageIndexChanging="GridView_Order_PageIndexChanging"
                        OnRowCancelingEdit="GridView_Order_RowCancelingEdit" 
                        OnRowEditing="GridView_Order_RowEditing" GridLines="None"
                        OnRowUpdating="GridView_Order_RowUpdating" 
                        OnRowCreated="GridView_Order_RowCreated" ondatabound="GridView_Order_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="SMSO_ID" HeaderText="订单ID" Visible="false" />
                            <asp:BoundField DataField="SMSO_ComOrderNum" HeaderText="公司订单号" ReadOnly="True" />
                            <asp:BoundField DataField="SMSO_CusOrderNum" HeaderText="客户订单号">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCIF_Name" HeaderText="客户名称" ReadOnly="True" />
                            <asp:BoundField DataField="CRMRBI_Name" HeaderText="区域" ReadOnly="True" />
                            <asp:BoundField DataField="SMSO_SalesMan" HeaderText="业务员" ReadOnly="True" />
                            <asp:TemplateField SortExpression="SMSO_OrderType" HeaderText="订单类型">
                                <ItemTemplate>
                                    <asp:Label ID="lable_2" runat="server" Text='<%# Eval("SMSO_OrderType")%>' CausesValidation="false"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <%--  <asp:HiddenField ID="HDFID" runat="server" Value='<%# Eval("SMSO_OrderType") %>' />--%>
                                    <asp:DropDownList ID="DropDownList15" runat="server" CausesValidation="false">
                                        <asp:ListItem>选择订单类型</asp:ListItem>
                                        <asp:ListItem>正常订单</asp:ListItem>
                                        <asp:ListItem>代工订单</asp:ListItem>
                                    </asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="SMSO_OrderState" HeaderText="订单状态" ReadOnly="True" />
                            <asp:BoundField DataField="SMSO_PlaceOrderTime" HeaderText="下单日期" DataFormatString="{0:yyyy-MM-dd}"
                                ReadOnly="True" />
                            <asp:BoundField DataField="SMSO_TotalMoney" HeaderText="总金额" ReadOnly="True" />
                            <asp:BoundField DataField="SMSO_InCountPayment" HeaderText="结算金额" ReadOnly="True" />
                            <asp:BoundField DataField="SMSO_InputPep" HeaderText="录入人" ReadOnly="True" />
                            <asp:BoundField DataField="SMSO_DetailCir" HeaderText="备注" HeaderStyle-Width="50px" />
                            <asp:CommandField ShowEditButton="True" EditText="编辑" UpdateText="更新" CancelText="取消"
                                CausesValidation="false">
                              
                            </asp:CommandField>
                            <asp:TemplateField>

                                <ItemTemplate >
                                    <asp:LinkButton ID="Look1" runat="server" CommandName="Look1" OnClientClick="false" CausesValidation="false"
                                        CommandArgument='<%#Eval("SMSO_ID")%>'>详细</asp:LinkButton>
                                      </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete1" runat="server" CommandName="Delete1" OnClientClick="return confirm('您确认删除该记录吗? 删除订单前请先删除订单详细表内容')" CausesValidation="false"
                                        CommandArgument='<%#Eval("SMSO_ID")%>'>删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第<asp:Label ID="lblPageIndex" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>' />
                                        页 共<asp:Label ID="lblPageCount" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />
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
                    </asp:GridView>
            </asp:Panel>
        </ContentTemplate>
        
    </asp:UpdatePanel>
    <!-- 订单详细表开始-->
    <asp:UpdatePanel ID="UpdatePanel_OrderDetail" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_OrderDetail" runat="server" Visible="false">
                <fieldset>
                <asp:Button ID="Button15" runat="server" Text="新增产品型号" CssClass="Button02" Height="24px"
                                    OnClick="NewProductType" Width="90px" />
                    <legend>订单详细表</legend>
                    <asp:GridView ID="GridView_OrderDetail" runat="server" AllowPaging="True" PageSize="10"
                        AutoGenerateColumns="False" CellPadding="0" CssClass="GridViewStyle" DataKeyNames="SMSOD_ID,SMSOD_OrderAdvanceDelTime"
                        Width="100%" AllowSorting="True" OnRowCommand="GridView_OrderDetail_RowCommand" GridLines="None"
                        OnPageIndexChanging="GridView_OrderDetail_PageIndexChanging" OnRowCancelingEdit="GridView_OrderDetail_RowCancelingEdit"
                        OnRowEditing="GridView_OrderDetail_RowEditing" OnRowUpdating="GridView_OrderDetail_RowUpdating"
                        OnDataBound="GridView_OrderDetail_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="SMSOD_ID" HeaderText="订单详细ID" Visible="false" />
                            <asp:BoundField DataField="PS_Name" HeaderText="产品系列" ReadOnly="true" />
                            <asp:BoundField DataField="PT_Name" HeaderText="产品型号" ReadOnly="true" />
                                                        <asp:TemplateField SortExpression="SMSOD_Mount" HeaderText="数量" HeaderStyle-Width="40px">
                                <ItemTemplate>
                                    <asp:Label ID="label_Mount" runat="server" Text='<%# Eval("SMSOD_Mount")%>'></asp:Label>
                                      
                                </ItemTemplate>
                                <EditItemTemplate   >
                                    <%--  <asp:HiddenField ID="HDFID" runat="server" Value='<%# Eval("SMSO_OrderType") %>' />--%>
                                  <asp:TextBox runat="server" ID="TextBox20" onkeyup="this.value=this.value.replace(/[^\d]/g,'')" Text='<%# Eval("SMSOD_Mount")%>' Width="40px"></asp:TextBox>
                           
                                     </EditItemTemplate>
                                <HeaderStyle Width="40px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="SMSOD_UnitPrice" HeaderText="单价" ReadOnly="true" />
                            <asp:BoundField DataField="SMSOD_TotalMoney" HeaderText="总金额" ReadOnly="true" />
                            <asp:BoundField DataField="SMSOD_SettlePrice" HeaderText="结账单价" Visible="false" ReadOnly="true" />
                            <asp:BoundField DataField="SMSOD_PayTime" HeaderText="账期" Visible="false" ReadOnly="true" />
                            <asp:TemplateField SortExpression="SMSO_OrderType" HeaderText="付款方式">
                                <ItemTemplate>
                                    <asp:Label ID="lable_paymethon" runat="server" Text='<%# Eval("SMSOD_PayMethon")%>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <%--  <asp:HiddenField ID="HDFID" runat="server" Value='<%# Eval("SMSO_OrderType") %>' />--%>
                                    <asp:DropDownList ID="DropDownList111" runat="server" CausesValidation="false">
                                        <asp:ListItem>现款现货</asp:ListItem>
                                        <asp:ListItem>账期</asp:ListItem>
                                        <asp:ListItem>货到付款</asp:ListItem>
                                        <asp:ListItem>预付款</asp:ListItem>
                                    </asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField SortExpression="SMSOD_SpecialProduct" HeaderText="是否特殊产品" HeaderStyle-Width="40px">
                                <ItemTemplate>
                                    <asp:Label ID="lable_specialproduct" runat="server" Text='<%# Eval("SMSOD_SpecialProduct")%>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <%--  <asp:HiddenField ID="HDFID" runat="server" Value='<%# Eval("SMSO_OrderType") %>' />--%>
                                    <asp:DropDownList ID="DropDownList11" runat="server" CausesValidation="false">
                                        <asp:ListItem>否</asp:ListItem>
                                        <asp:ListItem>是</asp:ListItem>
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <HeaderStyle Width="40px" />
                            </asp:TemplateField>
                            <asp:TemplateField SortExpression="SMSOD_OrderDelTime" HeaderText="交货期" HeaderStyle-Width="40px">
                                <ItemTemplate>
                                    <asp:Label ID="lable_deltime" runat="server" Text='<%# DateTime.Parse(Eval("SMSOD_OrderDelTime").ToString()).ToShortDateString()%>'></asp:Label>
                                </ItemTemplate>
                                <%--Eval("SMSOD_OrderDelTime"--%>
                                <EditItemTemplate>
                                    <%--  <asp:HiddenField ID="HDFID" runat="server" Value='<%# Eval("SMSO_OrderType") %>' />--%>
                                    <asp:TextBox runat="server" ID="TextBox1" onfocus="new WdatePicker(this,'%Y-%M-%D ',true)"
                                        Text='<%#DateTime.Parse(Eval("SMSOD_OrderDelTime").ToString()).ToShortDateString()%>'
                                        DataFormatString="{0:yyyy-MM-dd}" Width="70px"  CausesValidation="false"></asp:TextBox>
                                </EditItemTemplate>
                                <HeaderStyle Width="40px" />
                            </asp:TemplateField>
                            <asp:TemplateField SortExpression="SMSOD_OrderAdvanceDelTime" HeaderText="预交货期" HeaderStyle-Width="40px">
                                <ItemTemplate>
                                    <asp:Label ID="lable_smsodorderadv" runat="server" Text='<%# DateTime.Parse(Eval("SMSOD_OrderAdvanceDelTime").ToString()).ToShortDateString()%>'
                                       ></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <%--  <asp:HiddenField ID="HDFID" runat="server" Value='<%# Eval("SMSO_OrderType") %>' />--%>
                                    <asp:TextBox runat="server" ID="TextBox111" onfocus="new WdatePicker(this,'%Y-%M-%D ',true)"
                                        Text='<%# DateTime.Parse(Eval("SMSOD_OrderAdvanceDelTime").ToString()).ToShortDateString()%>'
                                        DataFormatString="{0:yyyy-MM-dd}" Width="70px"  CausesValidation="false"></asp:TextBox>
                                </EditItemTemplate>
                                <HeaderStyle Width="40px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="SMSOD_OrderAdvDelTimeChNum" HeaderText="预交货期修改次数" HeaderStyle-Width="40px"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="SMSOD_DelAlertTime" HeaderText="提前提醒天数" HeaderStyle-Width="40px">
                                <ControlStyle Width="40px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMSOD_DelCondition" HeaderText="发货情况" ReadOnly="true">
                            </asp:BoundField>
                                <asp:BoundField DataField="SMSOD_DelMount" HeaderText="已发货数量" ReadOnly="true">
                            </asp:BoundField>
                            <asp:BoundField DataField="SMSOD_AllowSpecDel" HeaderText="是否允许特殊发货" Visible="false"
                                HeaderStyle-Width="40px" ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="SMSOD_MCode" HeaderText="物料编号">
                                <ControlStyle Width="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMSOD_CustomerProModel" HeaderText="客户产品型号" HeaderStyle-Width="50px" >
                                <ControlStyle Width="50px" />
                                <HeaderStyle Width="40px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="SMSOD_Man" HeaderText="发货完结录入人" ReadOnly="true">
                            </asp:BoundField>
                            <asp:CommandField ShowEditButton="True" EditText="编辑" UpdateText="更新" CancelText="取消" Visible="false"
                                CausesValidation="false">
                                <ItemStyle Width="60px" />
                            </asp:CommandField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete2" runat="server" CommandName="Delete2" OnClientClick="return confirm('您确认删除该记录吗')" 
                                        CausesValidation="false" CommandArgument='<%#Eval("SMSOD_ID")%>'>删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="true">
                                <HeaderStyle Width="40px" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="History" runat="server" CommandName="History" CausesValidation="false"
                                        CommandArgument='<%#Eval("SMSOD_ID")%>'>查看预交货期修改历史</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Over1" runat="server" CommandName="Over1" OnClientClick="return confirm('您确认确认该订单详细为完结吗? 完结状态下的订单不会再发货计划中被检索到！')" CausesValidation="false"
                                        CommandArgument='<%#Eval("SMSOD_ID")%>'>发货完结</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField >
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="OutM" runat="server" CommandName="OutM"  CausesValidation="false"
                                        CommandArgument='<%#Eval("SMSOD_ID")%>'>查看出库记录</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                             
                        </Columns>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label16" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第<asp:Label ID="lblPageIndex" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>' />
                                        页 共<asp:Label ID="lblPageCount" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />
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
                    </asp:GridView>
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 50%" align="center">
                                <asp:Button ID="Button6" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    OnClick="NewOrderDetail" Width="70px" />
                            </td>
                            <td  align="center">
                                <asp:Button ID="Button7" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="CloseOrderDetail" Width="70px" />
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
        <asp:UpdatePanel ID="UpdatePanel_OutD" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_OutD" runat="server" Visible="false">
           <asp:Label ID="label26" runat="server" Visible="False"></asp:Label>
          
              <asp:Label ID="label_Sort" runat="server" Visible="False"></asp:Label>
                <fieldset>
                    <legend><asp:Label ID="label21" runat="server" Visible="true"></asp:Label>的出库单记录</legend>
                 
                    <asp:GridView ID="Gridview_OutD" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle"
                        CellPadding="0" UseAccessibleHeader="False" 
                        AllowPaging="True" AllowSorting="True" Font-Strikeout="False" GridLines="None"
                        DataKeyNames="IMOHD_ID" 
                        Width="100%" ondatabound="Gridview_OutD_DataBound"    >
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
<%--                            <asp:TemplateField>
                                <ItemStyle Width="5%" />
                                <ItemTemplate>
                               <asp:CheckBox ID="CheckBox2" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            
                            <asp:BoundField DataField="IMOHD_ID" HeaderText="出库单详细表ID" ReadOnly="True" SortExpression="IMOHD_ID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="IMOHM_OutHouseNum" HeaderText="出库单号" ReadOnly="True"
                                SortExpression="IMOHM_OutHouseNum" Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                              <asp:BoundField DataField="Name" HeaderText="物料名称" ReadOnly="True"
                                SortExpression="Name" Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                              <asp:BoundField DataField="Model" HeaderText="规格型号" ReadOnly="True"
                                SortExpression="Model" Visible="true">
                                <ItemStyle  />
                            </asp:BoundField>
                             <asp:BoundField DataField="IMOHD_Num" HeaderText="数量" SortExpression="IMOHD_Num">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="unit" HeaderText="单位" SortExpression="unit">
                                <ItemStyle  />
                            </asp:BoundField>
                              <asp:BoundField DataField="IMID_BatchNum" HeaderText="批号" SortExpression="IMID_BatchNum">
                                <ItemStyle />
                            </asp:BoundField>
                               <asp:BoundField DataField="IMID_QA" HeaderText="检验结果" SortExpression="IMID_QA"  >
                                <ItemStyle />
                            </asp:BoundField> 
                             <asp:BoundField DataField="IMID_DownLevelPara" HeaderText="降档参数" SortExpression="IMID_DownLevelPara">
                                <ItemStyle />
                            </asp:BoundField> 
                             <asp:BoundField DataField="IMOHM_OuthouseTime" HeaderText="制定时间" ReadOnly="True" DataFormatString="{0:yyyy-MM-dd HH:mm}"
                                SortExpression="IMOHM_OuthouseTime" Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                                <asp:BoundField DataField="IMOHM_TakeAwayMan" HeaderText="确认人" ReadOnly="True"
                                SortExpression="IMOHM_TakeAwayMan" Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                              <asp:BoundField DataField="IMOHM_TakeAwayMakeSureTime" HeaderText="确认出库时间" ReadOnly="True"
                                SortExpression="IMOHM_TakeAwayMakeSureTime" Visible="true" DataFormatString="{0:yyyy-MM-dd HH:mm}">
                                <ItemStyle />
                            </asp:BoundField>

                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第<asp:Label ID="lblPageIndex" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>' />
                                        页 共<asp:Label ID="lblPageCount" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />
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
                            <asp:Label ID="Label50" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                    </asp:GridView>   
                    <table width="100%">
                     <tr>
                      
                         <td  align="center">
                          <asp:Button ID="Button27" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="CloseOutD" Width="70px" />
                        </td>
                     </tr>
                    </table>           
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--新增订单开始--%>
    <asp:UpdatePanel ID="UpdatePanel_NewOrder" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_NewOrder" runat="server" Visible="false">
                <fieldset>
                    <legend>新增订单</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 10%" align="center">
                                客户名称：
                            </td>
                            <td style="width: 15%" align="center">
                                <asp:TextBox runat="server" ID="TextBox9" Text="请选择..." Width="65%" Height="20px" Enabled="false"></asp:TextBox>
                                <asp:Button ID="Button11" runat="server" Text="选择" CssClass="Button02" Height="20px"
                                    OnClick="SelectCustom" Width="25%" />
                            </td>
                            <td style="width: 10%" align="center">
                                客户订单号：
                            </td>
                            <td style="width: 15%" align="center">
                                <asp:TextBox runat="server" ID="TextBox10" Width="98px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                业务员：
                            </td>
                            <td style="width: 15%" align="center">
                                <asp:TextBox runat="server" ID="TextBox11" Width="98px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                订单类型：
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:DropDownList ID="DropDownList6" runat="server">
                                    <asp:ListItem>选择订单类型</asp:ListItem>
                                    <asp:ListItem>普通订单</asp:ListItem>
                                    <asp:ListItem>代工订单</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%" align="center">
                                备注：<br />(50字内)</td>
                            <td style="width: 15%" align="left" colspan="7">
                                <asp:TextBox runat="server" ID="TextBox13" Width="97%" TextMode="MultiLine" onkeyup="this.value = this.value.slice(0, 50)"
                                    MaxLength="50"></asp:TextBox>
                            </td>
                            <tr>
                                <td colspan="2">
                                </td>
                                <td colspan="2" align="center">
                                    <asp:Button ID="Button8" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                        OnClick="ConfirmNewOrder" Width="70px" />
                                </td>
                                <td colspan="2" align="center">
                                    <asp:Button ID="Button9" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                        OnClick="CanelNewOrder" Width="70px" />
                                </td>
                                <td colspan="2">
                                </td>
                            </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--查找客户名称--%>
    <asp:UpdatePanel ID="UpdatePanel_Customer" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Customer" runat="server" Visible="false">
                <fieldset>
                    <legend>选择客户</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 7%" align="center">
                                客户名称：
                            </td>
                            <td style="width: 15%" align="center">
                                <asp:TextBox runat="server" ID="TextBox12" Width="98%"></asp:TextBox>
                            </td>
                            <td style="width: 7%" align="center">
                                区域：
                            </td>
                            <td style="width: 15%" align="center">
                                <asp:TextBox runat="server" ID="TextBox14" Width="98%"></asp:TextBox>
                            </td>
                            <td style="width: 15%" align="center">
                                <asp:Button ID="Button10" runat="server" Text="检索" CssClass="Button02" Height="24px"
                                    OnClick="SearchCustom" Width="70px" />
                            </td>
                    </table>
                </fieldset>
            </asp:Panel>
            <asp:Panel ID="Panel1" runat="server" Visible="false">
                <fieldset>
                    <legend>客户表</legend>
                    <asp:GridView ID="GridView_Custom" runat="server" AllowPaging="True" PageSize="10"
                        AutoGenerateColumns="False" CellPadding="0" CssClass="GridViewStyle" DataKeyNames="CRMCIF_ID" GridLines="None"
                        AllowSorting="True" OnPageIndexChanging="GridView_Custom_PageIndexChanging" Width="100%">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:TemplateField HeaderStyle-Width="5%">
                                <ItemStyle />
                                <ItemTemplate>
                                    <asp:RadioButton ID="RadioButton1" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="CRMCIF_ID" HeaderText="客户ID" Visible="false" />
                            <asp:BoundField DataField="CRMCIF_Name" HeaderText="客户名称" />
                            <asp:BoundField DataField="CRMRBI_Name" HeaderText="区域" />
                            <asp:BoundField DataField="CRMCIF_Address" HeaderText="地址" />
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第<asp:Label ID="lblPageIndex" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>' />
                                        页 共<asp:Label ID="lblPageCount" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />
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
                    </asp:GridView>
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 25%">
                            </td>
                            <td style="width: 25%" align="center">
                                <asp:Button ID="Button13" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    OnClick="CustomOK" Width="70px" />
                            </td>
                            <td style="width: 25%" align="center">
                                <asp:Button ID="Button16" runat="server" Text="取消" CssClass="Button02" Height="24px"
                                    OnClick="CustomNotOK" Width="70px" />
                            </td>
                            <td style="width: 25%">
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <!-- 产品型号列表开始-->
    <asp:UpdatePanel ID="UpdatePanel_Product" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel2" runat="server" Visible="false">
                <fieldset>
                    <legend>产品型号检索</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 7%" align="center">
                                <asp:Label ID="Label10" runat="server" Text="产品系列："></asp:Label>
                            </td>
                            <td style="width: 10%" align="left">
                                <asp:TextBox ID="TextBox_Series" runat="server" Width="98%"></asp:TextBox>
                            </td>
                            <td style="width: 7%" align="center">
                                <asp:Label ID="Label11" runat="server" Text="产品型号："></asp:Label>
                            </td>
                            <td style="width: 10%" align="left">
                                <asp:TextBox ID="TextBox_ProductName" runat="server" Width="98%"></asp:TextBox>
                            </td>
                            </td>
                            <td style="width: 15%" align="center">
                                <asp:Button ID="Button14" runat="server" Text="检索" CssClass="Button02" Height="24px"
                                    OnClick="SelectProType" Width="70px" />
                                   <asp:Button ID="Button5" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="SelectProType1" Width="70px" />
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
            <asp:Panel ID="Panel_Product" runat="server" Visible="false">
                <fieldset>
                    <legend>产品型号表</legend>
                    <asp:GridView ID="GridView_ProType" runat="server" AllowPaging="True" PageSize="10" Width="100%"
                        AutoGenerateColumns="False" CellPadding="0" CssClass="GridViewStyle" DataKeyNames="PT_ID" GridLines="None"
                        AllowSorting="True" OnRowDataBound="GridView_ProType_RowDataBound" OnPageIndexChanging="GridView_ProType_PageIndexChanging">
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
                            <asp:BoundField DataField="PT_ID" HeaderText="产品型号ID" Visible="false" />
                           
                            <asp:BoundField DataField="PS_Name" HeaderText="产品系列" ItemStyle-Width="30%" />
                             <asp:BoundField DataField="PT_Name" HeaderText="产品型号" ItemStyle-Width="30%" />
                             <asp:BoundField DataField="PT_Note" HeaderText="产品备注" ItemStyle-Width="30%" />
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第<asp:Label ID="lblPageIndex" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>' />
                                        页 共<asp:Label ID="lblPageCount" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />
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
                    </asp:GridView>
                    <table style="width: 100%; text-align: center;" class="STYLE2">
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:CheckBox ID="Cbx2_SelectAll" runat="server" Text="全选" AutoPostBack="true" OnCheckedChanged="Cbx2_SelectAll_CheckedChanged" />
                                <asp:Button ID="ButtonPro" runat="server" CssClass="Button02" Text="提交" OnClick="ButtonProType_Click" Height="24px" Width="70px" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <!--预交货期修改列表开始-->
    <asp:UpdatePanel ID="UpdatePanel_AdvanceDel" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_AdvanceDel" runat="server" Visible="false">
                <fieldset>
                    <legend>预交货期修改历史表</legend>
                    <asp:GridView ID="GridView_AdvanceDel" runat="server" AllowPaging="True" PageSize="10"
                        AutoGenerateColumns="False" CellPadding="0" CssClass="GridViewStyle" DataKeyNames="SMDTCH_ID"
                        AllowSorting="True" Width="100%"  Font-Strikeout="False" GridLines="None" OnPageIndexChanging="GridView_AdvanceDel_PageIndexChanging" >
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="SMDTCH_ID" HeaderText="修改历史ID" Visible="false" />
                            <asp:BoundField DataField="SMDTCH_AfterChangeDelTime" HeaderText="修改后预交货期"  DataFormatString="{0:yyyy-MM-dd}" >
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMDTCH_ChangePep" HeaderText="修改人" ReadOnly="True" />
                            <asp:BoundField DataField="SMDTCH_ChangeTime" HeaderText="修改日期" ReadOnly="True"  DataFormatString="{0:yyyy-MM-dd}" />
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第<asp:Label ID="lblPageIndex" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>' />
                                        页 共<asp:Label ID="lblPageCount" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />
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
                    </asp:GridView>
                    <table style="width: 100%; text-align: center;" class="STYLE2">
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="Button4" runat="server" CssClass="Button02" Text="关 闭" OnClick="CloseHistory" Height="24px" Width="70px" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
