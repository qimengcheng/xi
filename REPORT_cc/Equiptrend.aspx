<%@ Page Title="设备维修率和停机率统计表" MasterPageFile="~/Other/MasterPage.master" Language="C#" AutoEventWireup="true" CodeFile="Equiptrend.aspx.cs" Inherits="REPORT_cc_Equiptrend" %>

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
                    <legend>设备信息检索栏</legend>
                    <asp:LinkButton ID="Senior_DetailOPEN" runat="server" CommandName="Senior_DetailOPEN"  ForeColor="Blue" Font-Underline="True" 
                            onclick="Senior_DetailOPEN_Click" Text=">> 打开 统计基础数据维护" Visible="true" ></asp:LinkButton>
                        <asp:LinkButton ID="Senior_DetailCLOSE" runat="server" CommandName="Senior_DetailCLOSE"  ForeColor="Blue" Font-Underline="True" 
                            onclick="Senior_DetailCLOSE_Click" Text="<< 关闭 统计基础数据维护" Visible="false"></asp:LinkButton>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 13%; height: 15px;" align="center">
                            </td>
                            <td style="width: 13%; height: 15px;" align="center">
                                <asp:Label ID="Label1" runat="server" Text="统计年份："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 15px;">
                                <asp:TextBox ID="textyear" runat="server" Width="155px" onkeyup="this.value=this.value.replace(/[^0-9]/g,'')" 
                                     onafterpaste="this.value=this.value.replace(/[^[0-9]/g,'')" MaxLength="4"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label6" runat="server" Text="设备名称："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                 <asp:TextBox ID="textname" runat="server" Width="155px"></asp:TextBox>
                            </td>
                            <td style="width: 10%; height: 15px;" align="center">
                            </td>
                        </tr>
                        <tr>
                        <td align="right" colspan="2">
                            <asp:Button ID="BtnSearch" runat="server" CssClass="Button02" Height="24px" Text="检索"
                                Width="70px" OnClick="BtnSearch_Click" />
                        </td>
                        <td align="center" colspan="2">
                            <asp:Button ID="BtnPrint" runat="server" CssClass="Button02" Height="24px" Text="打印报表" Width="90px" OnClick="BtnPrint_Click" ToolTip="点击此处,跳转打印页面。"/>
                        </td>
                        <td align="left" colspan="2">
                            <asp:Button ID="BtnReset" runat="server" CssClass="Button02" Height="24px" Text="重置"
                                Visible="true" Width="70px" OnClick="BtnReset_Click"/>
                        </td>
                    </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

<asp:UpdatePanel ID="UpdatePanel_Grid" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
           <%-- <asp:Panel ID="Panel_Grid" runat="server" ScrollBars="Auto">--%>
            <asp:Panel ID="Panel_Grid" runat="server">
                <fieldset>
                    <legend>设备维修率和停机率统计表</legend>
                    <div id="grid" style="overflow:auto; width:100%">
                    <asp:GridView ID="Grid_Detail" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="GridViewStyle" Width="200%"
                        AllowPaging="true"  GridLines="None" onrowcreated="Grid_Detail_RowCreated" OnPageIndexChanging="Grid_Detail_PageIndexChanging" PageSize="20" 
                        OnRowCommand="Grid_Detail_RowCommand">
                        <RowStyle CssClass="GridViewRowStyle"/>
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead"/>
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="Gra" runat="server" CommandArgument='<%# Eval("EN_EquipName") %>' CommandName="Gra">查看趋势图</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="序号" HeaderStyle-Width="5%">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1%>
                            </ItemTemplate>
                            <ItemStyle />
                        </asp:TemplateField>
                        <asp:BoundField DataField="EN_EquipName" HeaderText="设备名称" SortExpression="EN_EquipName">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="1MPer" SortExpression="1MPer">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="1BPer" SortExpression="1BPer">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="2MPer" SortExpression="2MPer">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="2BPer" SortExpression="2BPer">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="3MPer" SortExpression="3MPer">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="3BPer" SortExpression="3BPer">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="4MPer" SortExpression="4MPer">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="4BPer" SortExpression="4BPer">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="5MPer" SortExpression="5MPer">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="5BPer" SortExpression="5BPer">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="6MPer" SortExpression="6MPer">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="6BPer" SortExpression="6BPer">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="7MPer" SortExpression="7MPer">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="7BPer" SortExpression="7BPer">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="8MPer" SortExpression="8MPer">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="8BPer" SortExpression="8BPer">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="9MPer" SortExpression="9MPer">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="9BPer" SortExpression="9BPer">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="10MPer" SortExpression="10MPer">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="10BPer" SortExpression="10BPer">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="11MPer" SortExpression="11MPer">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="11BPer" SortExpression="11BPer">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="12MPer" SortExpression="12MPer">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="12BPer" SortExpression="12BPer">
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
                            <asp:Label ID="Label16" runat="server" Text="没有找到相关记录" ></asp:Label>
                        </EmptyDataTemplate>
                        <EditRowStyle BackColor="white" />
                    </asp:GridView>
                    <br />
                    </div>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" Visible="false">
                <fieldset>
                    <legend>统计基础数据维护</legend>
                    <asp:Button ID="New_name" runat="server" Text="选择需统计的设备" Width="120px" CssClass="Button02" OnClick="New_name_Click" Height="24px" />
                    <asp:GridView ID="GridView1" runat="server" DataKeyNames="EN_ID" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" Width="100%" AllowPaging="True"
                        PageSize="10" GridLines="None" OnRowCommand="GridView1_RowCommand" OnPageIndexChanging="GridView1_PageIndexChanging"
                        OnRowDataBound="GridView1_RowDataBound" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing"
                        OnRowUpdating="GridView1_RowUpdating">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                        <asp:TemplateField HeaderText="序号">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1%>
                            </ItemTemplate>
                        </asp:TemplateField>
                            <asp:BoundField DataField="EN_ID" HeaderText="设备名称ID" SortExpression="EN_ID" Visible="false" ReadOnly="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="EN_EquipName" HeaderText="设备名称" SortExpression="EN_EquipName" ReadOnly="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="EN_OperationTime" HeaderText="待操作总时间(H)" SortExpression="EN_OperationTime">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:CommandField ShowEditButton="True" EditText="编辑" UpdateText="更新" CancelText="关闭">
                                <ItemStyle />
                            </asp:CommandField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete_Name" runat="server" CommandName="Delete_Name" OnClientClick="return confirm('您确认不统计该设备吗?')"
                                        CommandArgument='<%#Eval("EN_ID")%>'>取消统计</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第&nbsp<asp:Label ID="lblPageIndex" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                        页 共&nbsp<asp:Label ID="lblPageCount" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageCount  %>" />
                                        页
                                        <asp:LinkButton ID="btnFirst" runat="server" CausesValidation="False" CommandArgument="First"
                                            CommandName="Page" Text="首页" />
                                        <asp:LinkButton ID="btnPrev" runat="server" CausesValidation="False" CommandArgument="Prev"
                                            CommandName="Page" Text="上一页" />
                                        <asp:LinkButton ID="btnNext" runat="server" CausesValidation="False" CommandArgument="Next"
                                            CommandName="Page" Text="下一页" />
                                        <asp:LinkButton ID="btnLast" runat="server" CausesValidation="False" CommandArgument="Last"
                                            CommandName="Page" Text="尾页" />
                                        <asp:TextBox ID="textbox1" runat="server" Width="20px"></asp:TextBox>
                                        <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                            CommandName="Page" Text="GO" />
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

    <asp:UpdatePanel ID="UpdatePanel_Name" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Name" runat="server" Visible="false">
                <fieldset>
                    <legend>设备名称列表</legend>
                    <asp:GridView ID="Grid_EquipName" runat="server" DataKeyNames="EN_ID" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                        AllowPaging="True" PageSize="10" Font-Strikeout="False" UseAccessibleHeader="False"
                        OnPageIndexChanging="Grid_EquipName_PageIndexChanging" OnRowCommand="Grid_EquipName_RowCommand"
                        OnRowDataBound="Grid_EquipName_RowDataBound" GridLines="None">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="EN_ID" HeaderText="设备名称ID" ReadOnly="True" SortExpression="EN_ID"
                                Visible="False">
                                <ItemStyle/>
                            </asp:BoundField>
                            <asp:BoundField DataField="EN_EquipName" HeaderText="设备名称" SortExpression="EN_EquipName">
                                <ItemStyle/>
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnChoose_Item" runat="server" CommandArgument='<%#Eval("EN_ID")%>'
                                        CommandName="Choose_Item" OnClientClick="false">选择</asp:LinkButton>
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
                                        <asp:TextBox ID="textbox2" runat="server" Width="20px"></asp:TextBox>
                                        <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                            CommandName="Page" Text="GO" /><!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
                                    </td>
                                </tr>
                            </table>
                        </PagerTemplate>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label16" runat="server" Text="没有找到相关记录"></asp:Label>
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td align="center">
                                <asp:Button ID="Button1" runat="server" Text="关闭" Width="70px" CssClass="Button02" OnClick="Button1_Click" Height="24px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

<asp:UpdatePanel ID="UpdatepanelGraph" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:Panel runat="server" ID="panelGraph" Visible="false">
        <fieldset>
            <legend>维修率和停机率趋势图</legend>
            <div style="text-align: center">
        <asp:Chart ID="Chart1" runat="server" OnLoad="Chart1_Load" Width="750px" BackImageAlignment="Center"  BorderlineWidth="20" Palette="None" PaletteCustomColors="DeepSkyBlue; YellowGreen; Gold; 255, 128, 0; Crimson">
            <series>
                <asp:Series ChartType="Line" IsValueShownAsLabel="True" Name="维修率" LabelForeColor="DimGray"  MarkerBorderColor="SkyBlue" MarkerSize="8" MarkerStyle="Circle" Font="微软雅黑, 8.25pt" Legend="Legend1">
                </asp:Series>
                <asp:Series ChartArea="ChartArea1" ChartType="Line" IsValueShownAsLabel="True" Name="停机率" LabelForeColor="DimGray" MarkerSize="8" MarkerStyle="Circle" Font="微软雅黑, 8.25pt" Legend="Legend1">
                </asp:Series>
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1" BackImageTransparentColor="Gainsboro">
                    <AxisY LineColor="DimGray" IsLabelAutoFit="False" Title="比率(%)" TitleFont="微软雅黑, 12px" TitleForeColor="DimGray">
                        <MajorGrid LineColor="DarkGray" LineDashStyle="Dash" />
                        <MajorTickMark LineColor="" />
                        <LabelStyle Font="微软雅黑, 8.25pt" ForeColor="DimGray" />
                    </AxisY>
                    <AxisX LineColor="DimGray" IsLabelAutoFit="False" Title="" TitleFont="微软雅黑, 12px" TitleForeColor="DimGray">
                        <MajorGrid LineColor="DarkGray" LineDashStyle="Dash" />
                        <LabelStyle Font="微软雅黑, 8.25pt" ForeColor="DimGray" />
                    </AxisX>
                    <AxisX2 TitleFont="微软雅黑, 8.25pt">
                    </AxisX2>
                    <AxisY2 TitleFont="微软雅黑, 8.25pt">
                    </AxisY2>
                </asp:ChartArea>
            </chartareas>
            <Legends>
                <asp:Legend Font="微软雅黑, 8.25pt" ForeColor="DimGray" IsTextAutoFit="False" Name="Legend1" TitleFont="微软雅黑, 8.25pt, style=Bold" TitleForeColor="DimGray" TitleSeparatorColor="BlanchedAlmond">
                </asp:Legend>
            </Legends>
            <Titles>
                <asp:Title Font="微软雅黑, 20px" ForeColor="64, 64, 64" Name="Title1">
                </asp:Title>
            </Titles>
        </asp:Chart>
    </div>
    </fieldset>
    </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>



</asp:Content>

