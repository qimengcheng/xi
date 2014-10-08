<%@ Page Title="" Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true"
 EnableEventValidation="false"   CodeFile="OEMOrderTrack.aspx.cs" Inherits="WorkOrderSalary_OEMOrderTrack" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" Visible="true">
                <fieldset>
                    <legend>加工订单检索 </legend>
                    <table style="width: 100%;">
                        <tr style="width: 100%;">
                            <td align="center" style="width: 11%;">
                                订单号：
                            </td>
                            <td align="left" class="auto-style3" style="width: 4%;">
                                <asp:TextBox ID="TextBox_order" runat="server" Width="100px"></asp:TextBox>
                            </td>
                            <td align="left" style="width: 16%;">
                                接单日期：
                            </td>
                            <td align="left" style="width: 5%;">
                                <asp:TextBox ID="TextBox_orderTime1" runat="server" Width="100px" onfocus="new WdatePicker(this,'%Y-%M-%D',false)"></asp:TextBox>
                            </td>
                            <td align="left" class="auto-style3" style="width: 1%;">
                                至
                            </td>
                            <td align="left" class="auto-style3" style="width: 6%;">
                                <asp:TextBox ID="TextBox_orderTime2" runat="server" Width="100px" onfocus="new WdatePicker(this,'%Y-%M-%D',false)"></asp:TextBox>
                            </td>
                            <td align="left" class="auto-style3" style="width: 16%;">
                                &nbsp;
                            </td>
                            <td align="left" class="auto-style3" style="width: 13%;">
                                &nbsp;
                            </td>
                            <td align="left" style="width: 60px;">
                                &nbsp;
                            </td>
                            <td align="left" class="auto-style3" style="width: 16%;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr style="width: 100%;">
                            <td align="center" style="width: 11%;">
                                芯片批号：
                            </td>
                            <td align="left" class="auto-style3" style="width: 4%;">
                                <asp:TextBox ID="TextBox_chip" Width="100px" runat="server"></asp:TextBox>
                            </td>
                            <td align="left" style="width: 16%;">
                                预计生产日期：
                            </td>
                            <td align="left" style="width: 5%;">
                                <asp:TextBox ID="TextBox_planproduction_Time1" Width="100px" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',false)"></asp:TextBox>
                            </td>
                            <td align="left" class="auto-style3" style="width: 1%;">
                                至
                            </td>
                            <td align="left" class="auto-style3" style="width: 6%;">
                                <asp:TextBox ID="TextBox_planproduction_Time2" runat="server" Width="100px" onfocus="new WdatePicker(this,'%Y-%M-%D',false)"></asp:TextBox>
                            </td>
                            <td align="left" class="auto-style3" style="width: 16%;">
                                实际生产日期：
                            </td>
                            <td align="left" class="auto-style3" style="width: 13%;">
                                <asp:TextBox ID="TextBox_realproduction_Time1" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',false)"
                                    Width="100px"></asp:TextBox>
                            </td>
                            <td align="left" style="width: 60px;">
                                至
                            </td>
                            <td align="left" class="auto-style3" style="width: 16%;">
                                <asp:TextBox ID="TextBox_realproduction_Time2" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',false)"
                                    Width="100px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="width: 100%;">
                            <td align="center" style="width: 11%;">
                                产品型号：
                            </td>
                            <td align="left" class="auto-style3" style="width: 4%;">
                                <asp:TextBox ID="TextBox_pt" Width="100px" runat="server"></asp:TextBox>
                            </td>
                            <td align="left" style="width: 16%;">
                                预计交货日期：
                            </td>
                            <td align="left" style="width: 5%;">
                                <asp:TextBox ID="TextBox_yujijiaohuo_Time1" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',false)"
                                    Width="100px"></asp:TextBox>
                            </td>
                            <td align="left" class="auto-style3" style="width: 1%;">
                                至
                            </td>
                            <td align="left" class="auto-style3" style="width: 6%;">
                                <asp:TextBox ID="TextBox_yujijiaohuo_Time2" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',false)"
                                    Width="100px"></asp:TextBox>
                            </td>
                            <td align="left" class="auto-style3" style="width: 16%;">
                                实际交货日期：
                            </td>
                            <td align="left" class="auto-style3" style="width: 13%;">
                                <asp:TextBox ID="TextBox_shijijiaohuo_Time1" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',false)"
                                    Width="100px"></asp:TextBox>
                            </td>
                            <td align="left" style="width: 60px;">
                                至
                            </td>
                            <td align="left" class="auto-style3" style="width: 16%;">
                                <asp:TextBox ID="TextBox_shijijiaohuo_Time2" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',false)"
                                    Width="100px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td align="center" style="width: 264px">
                                <asp:Button ID="Button1" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_Search_Click"
                                    Text="检索" Width="80px" />
                            </td>
                            <td style="width: 169px" align="center">
                                <asp:Button ID="btnDetailExcel" runat="server" CssClass="Button02" 
                                    Height="24px" OnClick="btnDetailExcel_Click" Text="导出Excel" Width="70px" />
                            </td>
                            <td align="center">
                                <asp:Button ID="Button2" runat="server" CssClass="Button02" Height="24px" 
                                    OnClick="Button_Cancel_Click" Text="重置" Width="80px" />
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
    <Triggers>
       <asp:PostBackTrigger ControlID="btnDetailExcel" />
       </Triggers>
        <ContentTemplate>
            <asp:Panel ID="Panel_WOmain" runat="server" Visible="true">
                <fieldset>
                    <legend>加工订单主表<asp:Label ID="label1" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <asp:Label ID="label_pagestate" runat="server" Visible="False" />
                    <asp:Label ID="label_RTX" runat="server" Visible="False" />
                    <asp:Label ID="label_CursNum" runat="server" Visible="False"></asp:Label>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        PageSize="10" CellPadding="0" UseAccessibleHeader="False" AllowPaging="True"
                        OnRowCommand="GridView_WOmain_RowCommand" OnPageIndexChanging="GridView_WOmain_PageIndexChanging"
                        AllowSorting="True" Width="100%" DataKeyNames="SMSO_ID" EmptyDataText="无相关记录!"
                        GridLines="None" OnDataBound="GridView1_DataBound" OnRowDataBound="GridView1_RowDataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="SMSO_ID" SortExpression="SMSO_ID" HeaderText="订单ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="SMSOD_ID" SortExpression="SMSOD_ID" HeaderText="订单详细ID"
                                Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="OEMOT_ID" SortExpression="OEMOT_ID" HeaderText="加工订单ID"
                                Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="SMSO_CusOrderNum" SortExpression="SMSO_CusOrderNum" HeaderText="订单号">
                            </asp:BoundField>
                            <asp:BoundField DataField="OEMOT_State" SortExpression="OEMOT_State" HeaderText="状态">
                            </asp:BoundField>
                            <asp:BoundField DataField="SMSO_PlaceOrderTime" SortExpression="SMSO_PlaceOrderTime"
                                HeaderText="接单日期" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundField>
                            <asp:BoundField DataField="PT_Name" SortExpression="PT_Name" HeaderText="产品型号"></asp:BoundField>
                            <asp:BoundField DataField="SMSOD_ChipBatchNum" SortExpression="SMSOD_ChipBatchNum"
                                HeaderText="芯片批号" Visible="False"></asp:BoundField>
                            <asp:BoundField DataField="SMSOD_Mount" SortExpression="SMSOD_Mount" HeaderText="订单数量">
                            </asp:BoundField>
                            <asp:BoundField DataField="OEMOT_PDate" SortExpression="OEMOT_PDate" HeaderText="预生产日期"
                                DataFormatString="{0:yyyy-MM-dd}"></asp:BoundField>
                            <asp:BoundField DataField="OEMOT_RPDate" SortExpression="OEMOT_RPDate" HeaderText="实生产日期"
                                DataFormatString="{0:yyyy-MM-dd}"></asp:BoundField>
                            <asp:BoundField DataField="OEMOT_PInTime" SortExpression="OEMOT_PInTime" HeaderText="预交货期"
                                DataFormatString="{0:yyyy-MM-dd}"></asp:BoundField>
                            <asp:BoundField DataField="OEMOT_RDeliverytDate" SortExpression="OEMOT_RDeliverytDate"
                                HeaderText="实交货期" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundField>
                            <asp:BoundField DataField="OEMOT_SNum" SortExpression="OEMOT_SNum" HeaderText="周期码">
                            </asp:BoundField>
                            <asp:BoundField DataField="ZPNum" SortExpression="ZPNum" HeaderText="投产数"></asp:BoundField>
                            <asp:BoundField DataField="InNum" SortExpression="InNum" HeaderText="发货数"></asp:BoundField>
                            <asp:BoundField DataField="HGL" SortExpression="HGL" HeaderText="合格率"></asp:BoundField>
                            <asp:BoundField DataField="OEMOT_Note" SortExpression="OEMOT_Note" HeaderText="备注">
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="MakeOrder" runat="server" CommandName="MakeOrder" CommandArgument='<%#Eval("SMSOD_ID")+","+ Eval("OEMOT_ID")+","+ Eval("OEMOT_PDate","{0:yyyy-MM-dd}")+","+ Eval("OEMOT_RPDate","{0:yyyy-MM-dd}")+","+ Eval("OEMOT_RDeliverytDate","{0:yyyy-MM-dd}")+","+ Eval("OEMOT_Note")+","+Eval("OEMOT_SNum")+","+Eval("OEMOT_PInTime","{0:yyyy-MM-dd}")+","+Eval("SMSO_CusOrderNum") %>'>制定</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="sign" runat="server" CommandArgument='<%#Eval("SMSO_ID") +","+ Eval("OEMOT_ID")+","+Eval("SMSO_CusOrderNum")%>'
                                        CommandName="sign">会签</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Lsign" runat="server" CommandArgument='<%#Eval("SMSO_ID") +","+ Eval("OEMOT_ID")+","+Eval("SMSO_CusOrderNum")%>'
                                        CommandName="sign">查看会签</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="detail" runat="server" CommandArgument='<%#Eval("SMSO_CusOrderNum") +","+ Eval("PT_Name")%>'
                                        CommandName="detail">详情</asp:LinkButton>
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
            <asp:Panel ID="Panel2" runat="server" Visible="False">
                <fieldset>
                    <legend>
                        <asp:Label ID="Label_SMSOD_ID" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="Label_OEMOT_ID" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="label_makeoredit" runat="server"></asp:Label>
                        &nbsp;加工订单生产相关信息 </legend>
                    <table width="100%">
                        <tr style="width: 100%;">
                            <td align="right" style="width: 19%; height: 22px;">
                                预计生产日期：
                            </td>
                            <td align="left" style="width: 19%; height: 22px;">
                                <asp:TextBox ID="TextBox5" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',false)"
                                    Width="90%"></asp:TextBox>
                                <asp:Label ID="Label19" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                            <td align="right" class="auto-style3" style="width: 13%; height: 22px;">
                                实际生产日期：
                            </td>
                            <td align="left" class="auto-style3" style="width: 20%; height: 22px;">
                                <asp:TextBox ID="TextBox7" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',false)"
                                    Width="90%"></asp:TextBox>
                            </td>
                            <td align="left" class="auto-style3" style="width: 8%; height: 22px;">
                                &nbsp;
                            </td>
                            <td align="left" class="auto-style3" style="width: 23%; height: 22px;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="auto-style3" style="width: 19%; height: 22px;">
                                预交货日期：
                            </td>
                            <td align="left" class="auto-style3" style="width: 19%; height: 22px;">
                                <asp:TextBox ID="TextBox3" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',false)"
                                    Width="90%"></asp:TextBox>
                                <asp:Label ID="Label21" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                            <td align="right" class="style2" style="width: 13%">
                                实际交货日期：
                            </td>
                            <td align="left" class="style3" style="width: 20%">
                                <asp:TextBox ID="TextBox12" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',false)"
                                    Width="90%"></asp:TextBox>
                             <%--   <asp:Label ID="Label22" runat="server" ForeColor="Red" Text="*"></asp:Label>--%>
                            </td>
                            <td align="right" class="style3" style="width: 8%">
                                <asp:Label ID="Label16" runat="server" Text="周期码："></asp:Label>
                            </td>
                            <td align="left" class="style3" style="width: 23%">
                                <asp:TextBox ID="TextBox8" runat="server" Width="90%"></asp:TextBox>
                                <asp:Label ID="Label18" runat="server" ForeColor="Red" Text="*"></asp:Label>
                            </td>
                        </tr>
                        <tr style="width: 100%;">
                            <td align="right" style="width: 19%; height: 22px;">
                                备注：<br>
                                (200字以内)
                            </td>
                            <td align="left" colspan="7">
                                <asp:TextBox runat="server" ID="TextBox11" Enabled="True" Height="75px" Width="638px"
                                    MaxLength="200" TextMode="MultiLine" onkeyup="this.value = this.value.substring(0, 200)"
                                    onafterpaste="this.value = this.value.substring(0, 200)"></asp:TextBox>
                            </td>
                            <td align="center" class="auto-style3" style="width: 16%; height: 22px;">
                                &nbsp;
                            </td>
                            <td align="left" class="auto-style3" style="width: 13%; height: 22px;">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td align="center" style="width: 264px">
                                <asp:Button ID="Button3" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_makeOrder_Click"
                                    Text="提交" Width="80px" />
                            </td>
                            <td style="width: 169px">
                                <asp:Button ID="Button4" runat="server" CssClass="Button02" Height="24px" OnClick="Button_makeOrderCancel_Click"
                                    Text="关闭" Width="80px" />
                            </td>
                            <td>
                                &nbsp;
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
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel3" runat="server" Visible="False">
                <fieldset>
                    <legend>
                        <asp:Label ID="Label2" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="Label3" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="label4" runat="server"></asp:Label>
                        加工订单会签</legend>
                    <table style="width: 100%;">
                        <tr style="width: 100%;">
                            <td align="right" style="width: 100%">
                                工程部能否提供制程作业指导书：
                            </td>
                            <td align="left" style="width: 78px">
                                <asp:DropDownList ID="DropDownList1" runat="server" Enabled="False">
                                    <asp:ListItem>是</asp:ListItem>
                                    <asp:ListItem>否</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="auto-style3" style="width: 630px; height: 22px;">
                                &nbsp;
                            </td>
                            <td align="right" class="auto-style3" style="width: 78px; height: 22px;">
                                &nbsp; 会签人：
                            </td>
                            <td align="left" class="auto-style3" style="width: 286px; height: 22px;">
                                <asp:Label ID="label13" runat="server"></asp:Label>
                            </td>
                            <td align="right" class="auto-style3" style="width: 11%; height: 22px;">
                                会签时间：
                            </td>
                            <td align="left" class="auto-style3" style="width: 13%; height: 22px;">
                                <asp:Label ID="label14" runat="server"></asp:Label>
                            </td>
                            <td align="left" class="auto-style3" style="width: 13%; height: 22px;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 630px">
                                不能的原因：<br>
                                (200字以内)
                            </td>
                            <td align="left" colspan="5">
                                <asp:TextBox runat="server" ID="TextBox1" Enabled="false" Height="75px" Width="638px"
                                    MaxLength="200" TextMode="MultiLine" onkeyup="this.value = this.value.substring(0, 200)"
                                    onafterpaste="this.value = this.value.substring(0, 200)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="width: 100%;">
                            <td align="right" style="width: 630px">
                                技术部能否提供工艺文件：
                            </td>
                            <td align="left" style="width: 78px">
                                <asp:DropDownList ID="DropDownList6" runat="server" Enabled="False">
                                    <asp:ListItem>是</asp:ListItem>
                                    <asp:ListItem>否</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="auto-style3" style="width: 630px; height: 22px;">
                                &nbsp;
                            </td>
                            <td align="right" class="auto-style3" style="width: 78px; height: 22px;">
                                &nbsp; 会签人：
                            </td>
                            <td align="left" class="auto-style3" style="width: 286px; height: 22px;">
                                <asp:Label ID="label15" runat="server"></asp:Label>
                            </td>
                            <td align="right" class="auto-style3" style="width: 11%; height: 22px;">
                                会签时间：
                            </td>
                            <td align="left" class="auto-style3" style="width: 13%; height: 22px;">
                                <asp:Label ID="label17" runat="server"></asp:Label>
                            </td>
                            <td align="left" class="auto-style3" style="width: 13%; height: 22px;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 630px" class="auto-style5">
                                不能的原因：<br>
                                (200字以内)
                            </td>
                            <td align="left" style="width: 670px" colspan="5">
                                <asp:TextBox runat="server" ID="TextBox2" Enabled="false" Height="75px" Width="638px"
                                    MaxLength="200" TextMode="MultiLine" onkeyup="this.value = this.value.substring(0, 200)"
                                    onafterpaste="this.value = this.value.substring(0, 200)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="width: 100%;">
                            <td align="right" style="width: 630px">
                                品保部能否满足品质需要：
                            </td>
                            <td align="left" style="width: 78px">
                                <asp:DropDownList ID="DropDownList2" runat="server" Enabled="False">
                                    <asp:ListItem>是</asp:ListItem>
                                    <asp:ListItem>否</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="auto-style3" style="width: 630px; height: 22px;">
                                &nbsp;
                            </td>
                            <td align="right" class="auto-style3" style="width: 78px; height: 22px;">
                                &nbsp; 会签人：
                            </td>
                            <td align="left" class="auto-style3" style="width: 286px; height: 22px;">
                                <asp:Label ID="label5" runat="server"></asp:Label>
                            </td>
                            <td align="right" class="auto-style3" style="width: 11%; height: 22px;">
                                会签时间：
                            </td>
                            <td align="left" class="auto-style3" style="width: 13%; height: 22px;">
                                <asp:Label ID="label6" runat="server"></asp:Label>
                            </td>
                            <td align="left" class="auto-style3" style="width: 13%; height: 22px;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 630px">
                                不能的原因：<br>
                                (200字以内)
                            </td>
                            <td align="left" style="width: 670px" colspan="5">
                                <asp:TextBox runat="server" ID="TextBox4" Enabled="false" Height="75px" Width="638px"
                                    MaxLength="200" TextMode="MultiLine" onkeyup="this.value = this.value.substring(0, 200)"
                                    onafterpaste="this.value = this.value.substring(0, 200)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="width: 100%;">
                            <td align="right" style="width: 630px">
                                生产部能否满足入库日期要求：
                            </td>
                            <td align="left" style="width: 78px">
                                <asp:DropDownList ID="DropDownList3" runat="server" Enabled="False">
                                    <asp:ListItem>是</asp:ListItem>
                                    <asp:ListItem>否</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="auto-style3" style="width: 630px; height: 22px;">
                                &nbsp;
                            </td>
                            <td align="right" class="auto-style3" style="width: 78px; height: 22px;">
                                &nbsp; 会签人：
                            </td>
                            <td align="left" class="auto-style3" style="width: 286px; height: 22px;">
                                <asp:Label ID="label7" runat="server"></asp:Label>
                            </td>
                            <td align="right" class="auto-style3" style="width: 11%; height: 22px;">
                                会签时间：
                            </td>
                            <td align="left" class="auto-style3" style="width: 13%; height: 22px;">
                                <asp:Label ID="label8" runat="server"></asp:Label>
                            </td>
                            <td align="left" class="auto-style3" style="width: 13%; height: 22px;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 630px">
                                不能的原因：<br>
                                (200字以内)
                            </td>
                            <td align="left" style="width: 670px" colspan="5">
                                <asp:TextBox runat="server" ID="TextBox6" Enabled="false" Height="75px" Width="638px"
                                    MaxLength="200" TextMode="MultiLine" onkeyup="this.value = this.value.substring(0, 200)"
                                    onafterpaste="this.value = this.value.substring(0, 200)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="width: 100%;">
                            <td align="right" style="width: 630px">
                                采购部能否满足材料供应：
                            </td>
                            <td align="left" style="width: 78px">
                                <asp:DropDownList ID="DropDownList4" runat="server" Enabled="False">
                                    <asp:ListItem>是</asp:ListItem>
                                    <asp:ListItem>否</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="auto-style3" style="width: 630px; height: 22px;">
                                &nbsp;
                            </td>
                            <td align="right" class="auto-style3" style="width: 78px; height: 22px;">
                                &nbsp; 会签人：
                            </td>
                            <td align="left" class="auto-style3" style="width: 286px; height: 22px;">
                                <asp:Label ID="label9" runat="server"></asp:Label>
                            </td>
                            <td align="right" class="auto-style3" style="width: 11%; height: 22px;">
                                会签时间：
                            </td>
                            <td align="left" class="auto-style3" style="width: 13%; height: 22px;">
                                <asp:Label ID="label10" runat="server"></asp:Label>
                            </td>
                            <td align="left" class="auto-style3" style="width: 13%; height: 22px;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 630px">
                                不能的原因：<br>
                                (200字以内)
                            </td>
                            <td align="left" style="width: 670px" colspan="5">
                                <asp:TextBox runat="server" ID="TextBox9" Enabled="false" Height="75px" Width="638px"
                                    MaxLength="200" TextMode="MultiLine" onkeyup="this.value = this.value.substring(0, 200)"
                                    onafterpaste="this.value = this.value.substring(0, 200)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="width: 100%;">
                            <td align="center" style="width: 630px">
                                销售部：能否按期交货
                            </td>
                            <td align="left" style="width: 78px">
                                <asp:DropDownList ID="DropDownList5" runat="server" Enabled="False">
                                    <asp:ListItem>是</asp:ListItem>
                                    <asp:ListItem>否</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="auto-style3" style="width: 630px; height: 22px;">
                                &nbsp;
                            </td>
                            <td align="right" class="auto-style3" style="width: 78px; height: 22px;">
                                &nbsp; 会签人：
                            </td>
                            <td align="left" class="auto-style3" style="width: 286px; height: 22px;">
                                <asp:Label ID="label11" runat="server"></asp:Label>
                            </td>
                            <td align="right" class="auto-style3" style="width: 11%; height: 22px;">
                                会签时间：
                            </td>
                            <td align="left" class="auto-style3" style="width: 13%; height: 22px;">
                                <asp:Label ID="label12" runat="server"></asp:Label>
                            </td>
                            <td align="left" class="auto-style3" style="width: 13%; height: 22px;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 630px">
                                不能的原因：<br>
                                (200字以内)
                            </td>
                            <td align="left" style="width: 670px" colspan="5">
                                <asp:TextBox runat="server" ID="TextBox10" Enabled="false" Height="75px" Width="638px"
                                    MaxLength="200" TextMode="MultiLine" onkeyup="this.value = this.value.substring(0, 200)"
                                    onafterpaste="this.value = this.value.substring(0, 200)"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td align="center" style="width: 264px">
                                <asp:Button ID="Button5" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_Intake"
                                    Text="提交" Width="80px" Visible="False" />
                            </td>
                            <td style="width: 169px" align="right">
                                <asp:Button ID="Button6" runat="server" CssClass="Button02" Height="24px" OnClick="Button_Meky"
                                    Text="关闭" Width="80px" />
                            </td>
                            <td>
                                &nbsp;
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
    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel4" runat="server" Visible="true">
                <fieldset>
                    <legend>&nbsp;订单号：
                        <asp:Label ID="label_Order" runat="server"></asp:Label>
                        &nbsp;产品型号:
                        <asp:Label ID="label_WO_ProType" runat="server"></asp:Label>
                        所属随工单表</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td class="auto-style3" style="width: 61px">
                                随工单号：
                            </td>
                            <td style="width: 128px">
                                <asp:TextBox ID="TextBox20" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 41px">
                                工序：
                            </td>
                            <td style="width: 132px">
                                <asp:TextBox ID="TextBox21" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 85px">
                                <asp:Button ID="Btn_WOTrack" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_WOTrack_Click"
                                    Text="检索" Width="80px" />
                            </td>
                            <td align="center" class="auto-style3" style="width: 128px">
                                <asp:Button ID="Btn_RetWO" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_RetWO_Click"
                                    Text="重置" Width="80px" />
                            </td>
                            <td align="right">
                                <asp:Button ID="Btn_WOTrack_Close" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Btn_WOTrack_Close_Click" Text="关闭" Width="80px" />
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle"
                        PageSize="10" CellPadding="0" UseAccessibleHeader="False" AllowPaging="True"
                        AllowSorting="True" Width="100%" DataKeyNames="WO_ID" EmptyDataText="无相关记录!"
                        GridLines="None" OnDataBound="GridView2_DataBound" OnPageIndexChanging="GridView2_PageIndexChanging"
                        EnableModelValidation="True" onrowcommand="GridView2_RowCommand" OnRowDataBound="GridView2_RowDataBound">
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
                                ReadOnly="true" Visible="False"></asp:BoundField>
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
                            <asp:BoundField DataField="hgl" SortExpression="hgl" HeaderText="合格率(%)" ReadOnly="true">
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="BasicInfo" runat="server" CommandArgument='<%#Eval("WO_ID")+","+ Eval("WO_Num")%>' CommandName="BasicInfo">详情</asp:LinkButton>
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
    <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel5" runat="server" Visible="false">
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
                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        CellPadding="0" UseAccessibleHeader="False" AllowPaging="false" 
                        Width="100%" DataKeyNames="WOD_ID" EmptyDataText="无相关记录!" OnDataBound="GridView3_DataBound"
                     >
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
