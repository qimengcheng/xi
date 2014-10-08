<%@ Page Title="财务部在制品统计表" Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true" CodeFile="WIP_CWTJ.aspx.cs" Inherits="REPORT_cc_WIP_CWTJ" EnableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script language="javascript" type="text/javascript">
    </script>
    <asp:UpdatePanel ID="UpdatePanel_Search" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Search" runat="server">
                <fieldset>
                    <legend>在制品统计检索栏</legend>
                    <table style="width: 100%;">
                    <tr style="height: 16px;">
                            <td style="width: 13%; height: 15px;" align="center">
                                <asp:Label ID="Label5" runat="server" Text="统计人："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 15px;">
                                <asp:TextBox ID="TextBox1" runat="server" Width="155px"></asp:TextBox>
                            </td>
                            <td align="center" style="width:10%;">
                                <asp:Label ID="Label2" runat="server" Text="统计时间："></asp:Label>
                            </td>
                            <td style="width:20%;">
                                <asp:TextBox ID="startime" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',false)"
                                    DataFormatString="{0:yyyy-MM-dd}" Width="155px"></asp:TextBox>
                            </td>
                            <td align="center" style="width:10%;">
                                    <asp:Label ID="Label111" runat="server" Text="至"></asp:Label>
                            </td>
                            <td style="width:20%;">
                                <asp:TextBox ID="endtime" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',false)"
                                    DataFormatString="{0:yyyy-MM-dd}" Width="155px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                         <td align="right" colspan="2">
                            <asp:Button ID="BtnSearch0" runat="server" CssClass="Button02" Height="24px" Text="检索"
                                Width="70px" OnClick="BtnSearch0_Click" />
                        </td>
                        <td align="center" colspan="2">
                            <asp:Button ID="BtnReset0" runat="server" CssClass="Button02" Height="24px" Text="重置"
                                Visible="true" Width="70px" OnClick="BtnReset0_Click"/>
                        </td>
                        <td align="left" colspan="2">
                            <asp:Button ID="BtnNew0" runat="server" CssClass="Button02" Height="24px" Text="新增统计记录" Width="90px" OnClick="BtnNew0_Click"/>
                        </td>
                    </tr>
                    </table>
                        
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdatePanel_Grid" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Grid" runat="server">
                <fieldset>
                    <legend>在制品统计信息表</legend>
                    <asp:GridView ID="Grid_Detail0" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="GridViewStyle" Width="100%" 
                        AllowPaging="true"  GridLines="None" OnPageIndexChanging="Grid_Detail0_PageIndexChanging" PageSize="10" DataKeyNames="CWPC_ID" 
                        OnRowCommand="Grid_Detail0_RowCommand" OnRowCancelingEdit="Grid_Detail0_RowCancelingEdit" OnRowEditing="Grid_Detail0_RowEditing" 
                        OnRowUpdating="Grid_Detail0_RowUpdating">
                        <RowStyle CssClass="GridViewRowStyle"/>
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead"/>
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="CWPC_ID" SortExpression="CWPC_ID" HeaderText="盘存ID" Visible="false"  ReadOnly="True" >
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CWPC_Man" SortExpression="CWPC_Man" HeaderText="统计人"  ReadOnly="True" >
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CWPC_Time" SortExpression="CWPC_Time"  HeaderText="统计时间"  ReadOnly="True" >
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CWPC_Note" SortExpression="CWPC_Note" HeaderText="备注" >
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Look" runat="server" CommandArgument='<%#Eval("CWPC_ID")%>' CommandName="Look" OnClientClick="false">详情</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle/>
                            </asp:TemplateField>
                            <asp:CommandField ShowEditButton="True" EditText="编辑" UpdateText="更新" CancelText="取消">
                                <ItemStyle />
                            </asp:CommandField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete00" runat="server" CommandName="Delete00" OnClientClick="return confirm('您确认删除该记录吗?')"
                                        CommandArgument='<%#Eval("CWPC_ID")%>'>删除</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
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
                                        <asp:TextBox ID="textbox0" runat="server" Width="20px"></asp:TextBox>
                                        <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                            CommandName="Page" Text="GO" /><!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
                                    </td>
                                </tr>
                            </table>
                        </PagerTemplate>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label16" runat="server" Text="没有找到相关记录" ></asp:Label>
                        </EmptyDataTemplate>
                        <EditRowStyle BackColor="white" />
                    </asp:GridView>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" Visible="false">
                <fieldset>
                    <legend>财务部在制品统计表</legend>
                    <table style="width: 100%;">
                    <asp:Label ID="Label777" runat="server" Text="" Visible="false"></asp:Label>
                    <tr style="height: 16px;">
                            <td style="width: 13%; height: 15px;" align="center">
                            </td>
                            <td style="width: 10%; height: 15px;" align="center">
                                <asp:Label ID="Label1" runat="server" Text="工序："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 15px;">
                                <asp:DropDownList ID="DropDownList1" runat="server" Width="155px"></asp:DropDownList>
                            </td>
                            <td style="width: 10%; height: 15px;" align="center">
                                <asp:Label ID="Label6" runat="server" Text="大类型号："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 15px;">
                                <asp:DropDownList ID="DropDownList2" runat="server" Width="155px"></asp:DropDownList>
                            </td>
                            <td style="width: 10%" align="center"></td>
                        </tr>
                        <tr>
                             <td align="right" colspan="2">
                                 <asp:Button ID="BtnSearch" runat="server" CssClass="Button02" Height="24px" 
                                     OnClick="BtnSearch_Click" Text="检索" Width="70px" />
                             </td>
                             <td align="center" colspan="2">
                                 <asp:Button ID="BtnPrint" runat="server" CssClass="Button02" Height="24px" Text="打印报表" Width="90px" OnClick="BtnPrint_Click" ToolTip="点击此处,跳转打印页面。"/>
                             </td>
                             <td align="left" colspan="2">
                                 <asp:Button ID="BtnReset" runat="server" CssClass="Button02" Height="24px" 
                                     OnClick="BtnReset_Click" Text="重置" Visible="true" Width="70px" />
                             </td>
                    </tr>
                     <tr>
                     <td colspan="6">
                     <asp:GridView ID="Grid_Detail" runat="server" AllowSorting="True" 
                             AutoGenerateColumns="False" CssClass="GridViewStyle" Width="100%" 
                        AllowPaging="true"  GridLines="None" 
                             OnPageIndexChanging="Grid_Detail_PageIndexChanging" PageSize="10" >
                        <RowStyle CssClass="GridViewRowStyle"/>
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead"/>
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:TemplateField HeaderText="序号">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="CWPCD_ID" SortExpression="CWPCD_ID" HeaderText="CWPCD_ID" Visible="false">
                                <ItemStyle />
                            </asp:BoundField>                            
                            <asp:BoundField DataField="CWPC_ID" SortExpression="CWPC_ID" HeaderText="CWPC_ID" Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CWPCD_WONum" SortExpression="CWPCD_WONum" HeaderText="随工单号" >
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CWPCD_DXH" SortExpression="CWPCD_DXH"  HeaderText="大类型号" >
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CWPCD_XH" SortExpression="CWPCD_XH"  HeaderText="产品型号" >
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CWPCD_SM" SortExpression="CWPCD_SM"  HeaderText="型号说明" >
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CWPCD_Chip" SortExpression="CWPCD_Chip"  HeaderText="芯片大小" >
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CWPCD_ZP" SortExpression="CWPCD_ZP"  HeaderText="装配投入数量" >
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CWPCD_BCGX" SortExpression="CWPCD_BCGX"  HeaderText="本次统计工序" >
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CWPCD_BCHGS" SortExpression="CWPCD_BCHGS"  HeaderText="本次统计合格数" >
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CWPCD_SCGX" SortExpression="CWPCD_SCGX"  HeaderText="上次统计工序" >
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CWPCD_SCHGS" SortExpression="CWPCD_SCHGS"  HeaderText="上次统计合格数" >
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
                                        <asp:TextBox ID="textbox2" runat="server" Width="20px"></asp:TextBox>
                                        <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                            CommandName="Page" Text="GO" /><!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
                                    </td>
                                </tr>
                            </table>
                        </PagerTemplate>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label16" runat="server" Text="没有找到相关记录" ></asp:Label>
                        </EmptyDataTemplate>
                        <EditRowStyle BackColor="white" />
                    </asp:GridView>
                    </td>
                     </tr>
                        <tr>
                            <td colspan="6" align="center">
                            <asp:Button ID="BtnClose" runat="server" Text="关闭" CssClass="Button02" Width="70px" OnClick="BtnClose_Click" Height="24px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdatePanel_NewCDDep" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_NewCDDep" runat="server" Visible="false">
                <fieldset>
                    <legend>新增统计记录</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 20%" align="right">
                                <asp:Label ID="Label8" runat="server" Text="备注："></asp:Label>
                            </td>
                            <td style="width: 50%;height: 15px;" align="left">
                                <asp:TextBox ID="newCDdep" runat="server" Width="300px" Height="20px" MaxLength="10"></asp:TextBox>
                                <%--<asp:Label ID="Label18" runat="server" Text="*" ForeColor="Red"></asp:Label>--%>
                            </td>
                            <td align="left">
                                <asp:Button ID="BtnCancel_NewCDDep" runat="server" Text="统计" CssClass="Button02"
                                    Width="70px" OnClick="BtnCancel_NewCDDep_Click" Height="24px" />
                            </td>
                            <td align="left">
                                <asp:Button ID="BtnClose0" runat="server" Text="关闭" CssClass="Button02" Width="70px" OnClick="BtnClose0_Click" Height="24px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
