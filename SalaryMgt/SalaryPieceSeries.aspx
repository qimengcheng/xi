<%@ Page Title="计件系列维护" Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true"
    CodeFile="SalaryPieceSeries.aspx.cs" Inherits="SalaryMgt_SalaryPieceSeries" %>

<script runat="server">
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel_Search" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Search" runat="server" Visible="true">
                <asp:Label ID="Label_Grid1_Color" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="Label_sort" runat="server"></asp:Label>
                <asp:Label ID="Label_Grid1_State" runat="server" Text="默认数据源" Visible="False"></asp:Label>
                <asp:Label ID="Label_Search" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="label_pagestate" runat="server" Visible="False"></asp:Label>
                <fieldset>
                    <legend>计件系列查询</legend>
                    <table style="width: 100%;">
                        <tr style="width: 100%;">
                            <td style="width: 10%;">
                                计件系列：
                            </td>
                            <td style="width: 21%;">
                                <asp:TextBox ID="Txt_search" runat="server" Width="200px"></asp:TextBox>
                            </td>
                            <td style="width: 15%;">
                            </td>
                            <td style="width: 15%;" align="center">
                                <asp:Button ID="Btn_Search" runat="server" Text="检索" Width="70px" Height="24px" CssClass="Button02"
                                    OnClick="Btn_Search_Click" />
                            </td>
                            <td style="width: 15%;" align="center">
                                <asp:Button ID="Button_Cancel" runat="server" CssClass="Button02" Height="24px" OnClick="Button_Cancel_Click"
                                    Text="重置" Width="70px" />
                            </td>
                            <td style="width: 35%;" align="center">
                                <asp:Button ID="Button_Add" runat="server" CssClass="Button02" Height="24px" OnClick="Button_Add_Click"
                                    Text="新增计件系列" Width="90px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    
    <asp:UpdatePanel ID="UpdatePanel_PS" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel2" runat="server" Visible="true">
                <fieldset>
                    <legend>计件系列表<asp:Label ID="Lab_State" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        Font-Strikeout="False" GridLines="None" PageSize="10" CellPadding="0" UseAccessibleHeader="False"
                        AllowPaging="True" OnRowCommand="GridView1_RowCommand" OnPageIndexChanging="GridView1_PageIndexChanging"
                        OnRowEditing="Gridview_PS_Editing" OnRowCancelingEdit="Gridview_PS_CancelingEdit"
                        AllowSorting="True" OnRowCreated="GridView1_RowCreated" OnSorting="GridView1_Sorting"
                        OnRowUpdating="Gridview_PS_Updating" OnRowDataBound="GridView1_RowDataBound"
                        Width="100%" DataKeyNames="SPS_ID" OnDataBound="GridView1_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="SPS_ID" HeaderText="薪资计件系列ID" SortExpression="SPS_ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="SPS_Name" SortExpression="SPS_Name" HeaderText="计件系列名称"></asp:BoundField>
                            <asp:CommandField ShowEditButton="True" EditText="编辑" UpdateText="更新" CancelText="关闭">
                                <ItemStyle />
                            </asp:CommandField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete1" runat="server" CommandArgument='<%# Eval("SPS_ID") %>'
                                        CommandName="Delete1" OnClientClick="return confirm('您确认删除该记录吗?')">删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="CheckProType" runat="server" CommandArgument='<%# Eval("SPS_ID")+","+Eval("SPS_Name") %>'
                                        CommandName="CheckProType">查看所属产品型号</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第 &nbsp;<asp:Label ID="lblPageIndex" runat="server" Text="<%#  ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                        页 共 &nbsp;<asp:Label ID="lblPageCount" runat="server" Text="<%#  ((GridView)Container.Parent.Parent).PageCount  %>" />
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

    <asp:UpdatePanel ID="UpdatePanel_AddPS" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_AddPS" runat="server" Visible="false">
                <fieldset>
                    <legend>计件系列新增</legend>
                    <table style="width: 100%;">
                        <tr style="width: 100%;">
                            <td style="width: 15%;">
                            </td>
                            <td style="width: 10%;">
                                计件系列：
                            </td>
                            <td style="width: 25%;">
                                <asp:TextBox ID="txt_PS" runat="server" Width="150px" MaxLength="30"></asp:TextBox>
                                <asp:Label ID="Label14" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                            <td style="width: 10%;">
                            </td>
                            <td style="width: 15%;" align="center">
                                <asp:Button ID="Btn_Submit" runat="server" Text="提交" Width="70px" Height="24px" CssClass="Button02"
                                    OnClick="Btn_Submit_Click" />
                            </td>
                            <td style="width: 15%;" align="center">
                                <asp:Button ID="Btn_Close_PS" runat="server" CssClass="Button02" Height="24px" OnClick="Button_Close_PSSearch_Click"
                                    Text="关闭" Width="70px" />
                            </td>
                            <td style="width: 35%;" align="center">
                                <%--<asp:Button ID="Btn_Cancel" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_Cancel_Click"
                                    Text="重置" Width="70px" />--%>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdatePanel_PT" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_PT" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="Label_PsName" runat="server"></asp:Label>
                        产品型号表<asp:Label ID="Label_PS" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="Label_PT" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <table style="width: 100%;">
                        <tr style="width: 100%;">
                            <td style="width: 10%;">
                                产品型号：
                            </td>
                            <td style="width: 16%;">
                                <asp:TextBox ID="Txt_PT_Search" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 15%;" align="center">
                                产品编码：
                            </td>
                            <td align="center" style="width: 15%;">
                                <asp:TextBox ID="Txt_PT_Search0" runat="server"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 15%;">
                                <asp:Button ID="Button3" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_SearchPT_Click"
                                    Text="检索" Width="70px" />
                            </td>
                            <td style="width: 15%;" align="center">
                                <asp:Button ID="Button2" runat="server" CssClass="Button02" Height="24px" OnClick="Button_CancelPT_Click"
                                    Text="重置" Width="70px" />
                            </td>
                            <td style="width: 15%;" align="center">
                                <asp:Button ID="Btn_AddPT" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_AddPT_Click"
                                    Text="新增产品型号" Width="90px" />
                            </td>
                            <td style="width: 35%;" align="right">
                              
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        Font-Strikeout="False" GridLines="None" PageSize="10" CellPadding="0" UseAccessibleHeader="False"
                        AllowPaging="True" OnPageIndexChanging="GridView2_PageIndexChanging" AllowSorting="True"
                        Width="100%" DataKeyNames="PT_ID" EmptyDataText="无相关记录!" OnDataBound="GridView2_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemStyle />
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="PT_ID" HeaderText="产品型号ID" SortExpression="PT_ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="PT_Name" SortExpression="PT_Name" HeaderText="产品型号"></asp:BoundField>
                            <asp:BoundField DataField="PT_Code" SortExpression="PT_Code" HeaderText="产品编码"></asp:BoundField>
                            <asp:BoundField DataField="PT_Special" SortExpression="PT_Special" HeaderText="是否属于特殊产品">
                            </asp:BoundField>
                            <asp:BoundField DataField="BOM_Name" SortExpression="BOM_Name" HeaderText="BOM名称">
                            </asp:BoundField>
                            <asp:BoundField DataField="BOM_ID" SortExpression="BOM_ID" HeaderText="BOMID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="PR_Name" SortExpression="PR_Name" HeaderText="工艺路线名称">
                            </asp:BoundField>
                            <asp:BoundField DataField="PR_ID" SortExpression="PR_ID" HeaderText="工艺路线ID" Visible="false">
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
                    <table width="100%">
                        <tr>
                            <td style="width: 25%;" align="center">
                                <asp:CheckBox ID="CheckBoxAll" runat="server" Text="全选" Width="80px" AutoPostBack="True"
                                    OnCheckedChanged="CheckBoxAll_CheckedChanged" Style="margin-left: 0px" />
                                <asp:CheckBox ID="CheckBoxfanxuan" runat="server" Text="反选" Width="60px" AutoPostBack="True"
                                    OnCheckedChanged="Checkfanxuan_CheckedChanged" />
                            </td>
                            <td align="center" style="width: 30%;">
                                <asp:Button ID="Btn_deleting" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_deleting_Click"
                                    Text="删除" Width="70px" />
                            </td>
                            <td >
                                <asp:Button ID="Button_CloseS" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_CloseS_Click"
                                    Text="关闭" Width="70px" />
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
                    <legend>新增产品型号</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 15%" align="center">
                                产品型号：
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TextBox_Series" runat="server" Width="98%"></asp:TextBox>
                            </td>
                            <td style="width: 15%" align="center">
                                产品编码：
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TextBox_ProductName" runat="server" Width="98%"></asp:TextBox>
                            </td>
                            <td style="width: 20%" align="center">
                                <asp:Button ID="Button14" runat="server" CssClass="Button02" Height="24px" OnClick="SelectProType"
                                    Text="检索" Width="70px" />
                                &nbsp;
                            </td>
                            <td align="left" >
                                <asp:Button ID="Button15" runat="server" CssClass="Button02" Height="24px" OnClick="Button15_Click"
                                    Text="重置" Width="70px" />
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView_ProType" runat="server" AllowPaging="True" PageSize="10"
                        Width="100%" AutoGenerateColumns="False" CellPadding="0" CssClass="GridViewStyle"
                        GridLines="None" DataKeyNames="PT_ID" AllowSorting="True" OnPageIndexChanging="GridView_ProType_PageIndexChanging">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemStyle Width="5%"/>
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox2" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="PT_ID" HeaderText="产品型号ID" Visible="false" />
                            <asp:BoundField DataField="PT_Name" HeaderText="产品型号" ItemStyle-Width="30%" />
                            <asp:BoundField DataField="PT_Code" HeaderText="产品编码" ItemStyle-Width="30%" />
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
                            <td style="width: 25%;" align="center">
                                <asp:CheckBox ID="CheckBox2" runat="server" Text="全选" Width="83px" AutoPostBack="True"
                                    OnCheckedChanged="CheckBoxAll2_CheckedChanged" />
                                <asp:CheckBox ID="Checkfanxuan2" runat="server" Text="反选" Width="60px" AutoPostBack="True"
                                    OnCheckedChanged="Checkfanxuan2_CheckedChanged" />
                            </td>
                            <td style="width: 30%;" align="center">
                                <asp:Button ID="Button_AddPTToSeries" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_AddPTToSeries_Click" Text="提交" Width="70px" />
                            </td>
                            <td >
                                <asp:Button ID="Button_ClosePT" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Btn_Close_PT_Click" Text="关闭" Width="70px" />
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

