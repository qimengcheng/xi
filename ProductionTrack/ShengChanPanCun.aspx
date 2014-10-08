<%@ Page Title="" Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true"
    CodeFile="ShengChanPanCun.aspx.cs" Inherits="ProductionTrack_ShengChanPanCun" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel_Search" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Search" runat="server" Visible="true">
                <fieldset>
                    <legend>生产线材料盘存检索 </legend>
                    <table style="width: 100%;">
                        <tr style="width: 100%;">
                            <td style="width: 13%;">
                                生产部审核状态：
                            </td>
                            <td align="left" style="width: 9%;">
                                <asp:DropDownList ID="DropDownList_TimeState" runat="server">
                                    <asp:ListItem Value="">请选择</asp:ListItem>
                                    <asp:ListItem>待审核</asp:ListItem>
                                    <asp:ListItem>通过</asp:ListItem>
                                    <asp:ListItem>不通过</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="center" style="width: 13%;">
                                财务部会签状态：
                            </td>
                            <td align="left" style="width: 9%;">
                                <asp:DropDownList ID="DropDownList_PieceState" runat="server">
                                    <asp:ListItem Value="">请选择</asp:ListItem>
                                    <asp:ListItem>待审核</asp:ListItem>
                                    <asp:ListItem>通过</asp:ListItem>
                                    <asp:ListItem>不通过</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="left" style="width: 5%;">
                                工序：
                            </td>
                            <td align="left" style="width: 12%;">
                                <asp:TextBox ID="TextBox1" runat="server" Width="100px"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 8%;">
                                盘存日期：
                            </td>
                            <td align="center" class="auto-style3" style="width: 14%;">
                                <asp:TextBox ID="TextBox_calculate_Time1" runat="server" CssClass="Wdate" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"
                                    Width="100px
                                    "></asp:TextBox>
                            </td>
                            <td align="center" style="width: 22px;">
                                至
                            </td>
                            <td align="center" style="width: 16%;">
                                <asp:TextBox ID="TextBox_calculate_Time2" runat="server" CssClass="Wdate" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"
                                    Width="100px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%;">
                        <tr style="width: 100%;">
                            <td align="center" style="width: 13%;">
                                &nbsp;
                            </td>
                            <td align="left" style="width: 17%;">
                                &nbsp;</td>
                            <td align="center" style="width: 15%;">
                                <asp:Button ID="Btn_Search" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_Search_Click"
                                    Text="检索" Width="70px" />
                            </td>
                            <td align="center" style="width: 14%;">
                                <asp:Button ID="Button_Add" runat="server" CssClass="Button02" Height="24px" OnClick="Button_Add_Click"
                                    Text="新增材料盘存信息" Width="120px" />
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
                    <legend>生产线材料盘存新增 </legend>
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
                                工序：
                            </td>
                            <td align="left" style="width: 14%;">
                                <asp:DropDownList ID="DropDownList1" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td align="center" style="width: 11%;">
                                <asp:Button ID="Button_Add_Submit" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_Add_Submit_Click" Text="确定" Width="70px" />
                            </td>
                            <td align="left" class="auto-style3" style="width: 16%;">
                                &nbsp;
                                <asp:Button ID="Button_Add_Cancel" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_Add_Cancel_Click" Text="关闭" Width="70px" />
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
                    <legend>生产线材料盘存主表</legend>
                    <asp:GridView ID="GridView_WOmain" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        PageSize="5" CellPadding="0" UseAccessibleHeader="False" AllowPaging="True" OnRowCommand="GridView_WOmain_RowCommand"
                        OnPageIndexChanging="GridView_WOmain_PageIndexChanging" AllowSorting="True" Width="100%"
                        DataKeyNames="PMMI_ID" EmptyDataText="无相关记录!" GridLines="None">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="PMMI_ID" SortExpression="PMMI_ID" HeaderText="生产线盘存主表ID"
                                Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="PMMI_Date" SortExpression="PMMI_Date" HeaderText="日期"
                                DataFormatString="{0:yyyy-MM-dd}"></asp:BoundField>
                            <asp:BoundField DataField="PBC_Name" SortExpression="PBC_Name" HeaderText="工序"></asp:BoundField>
                            <asp:BoundField DataField="PMMI_Man" SortExpression="PMMI_Man" HeaderText="制定人">
                            </asp:BoundField>
                            <asp:BoundField DataField="PMMI_Time" SortExpression="PMMI_Time" HeaderText="制定时间"
                                DataFormatString="{0:yyyy-MM-dd HH:mm}"></asp:BoundField>
                            <asp:BoundField DataField="PMMI_RState" SortExpression="PMMI_RState" HeaderText="审核状态">
                            </asp:BoundField>
                            <asp:BoundField DataField="PMMI_FCState" SortExpression="PMMI_FCState" HeaderText="会签状态">
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete1" runat="server" CommandName="Delete1" CommandArgument='<%#Eval("PMMI_ID") %>'
                                        OnClientClick="return confirm('将会删除计时计件信息，确定吗？')">删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="detail123" runat="server" CommandArgument='<%#Eval("PMMI_ID") +","+ Eval("PMMI_Date","{0:yyyy-MM-dd}")+","+Eval("PBC_Name")%>'
                                        CommandName="detail123">详情</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Review123" runat="server" CommandArgument='<%#Eval("PMMI_ID") +","+ Eval("PMMI_Date","{0:yyyy-MM-dd}")+","+Eval("PBC_Name")%>'
                                        CommandName="Review123">审核</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="resign" runat="server" CommandArgument='<%#Eval("PMMI_ID") +","+ Eval("PMMI_Date","{0:yyyy-MM-dd}")+","+Eval("PBC_Name")%>'
                                        CommandName="resign">会签</asp:LinkButton>
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
</asp:Content>
