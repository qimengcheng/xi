<%@ Page Title="" Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true"
    CodeFile="CapacityBasic.aspx.cs" Inherits="Capacity_CapacityBasic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <script language="javascript" type="text/javascript">
        function listboxSelect() 
        {
            var lb = document.getElementById("ctl00_ContentPlaceHolder1_LbCanBeUsedItem");
            var targetLabel = document.getElementById("ctl00_ContentPlaceHolder1_TxtFormulaEdit");
            var forvalue = targetLabel.value;
            var index = lb.selectedIndex;
            targetLabel.value = forvalue + lb.options[index].value;
        }
        function mouseInput(name) 
        {
            var id = "ctl00_ContentPlaceHolder1_" + name;
            var inputbutton = document.getElementById(id);
            var targetLabel = document.getElementById("ctl00_ContentPlaceHolder1_TxtFormulaEdit");
            var forvalue = targetLabel.value;
            targetLabel.value = forvalue + inputbutton.value;
        } 

    </script>

    <asp:UpdatePanel ID="UpdatePanel_Search" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Search" runat="server" Visible="true">
                <fieldset>
                    <legend>产能核定系列检索
                        <asp:Label ID="label_pagestate" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <table style="width: 100%; height: 23px;">
                        <tr style="width: 100%;">
                            <td style="width: 12%;" align="center">
                            </td>
                            <td style="width: 15%;" align="center">
                                产能核定系列：
                            </td>
                            <td align="center" style="width: 17%;">
                                <asp:TextBox ID="TextBox_CS_Search" runat="server"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 10%;">
                                &nbsp;
                            </td>
                            <td align="right" style="width: 15%;">
                                <asp:Button ID="Btn_Search" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_Search_Click"
                                    Text="检索" Width="70px" />
                            </td>
                            <td style="width: 15%;" align="center">
                                <asp:Button ID="Button_Cancel" runat="server" CssClass="Button02" Height="24px" OnClick="Button_Cancel_Click"
                                    Text="重置" Width="70px" />
                            </td>
                            <td align="right" >
                                <asp:Button ID="Button_AddCS" runat="server" CssClass="Button02" Height="24px" OnClick="Button_AddCS_Click"
                                    Text="新增产能核定系列" Width="120px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    
    <asp:UpdatePanel ID="UpdatePanel_CS" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_CS" runat="server" Visible="true">
                <fieldset>
                    <legend>产能核定系列表
                        <asp:Label ID="label_GridPageState" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="label_CSN_Name" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <asp:GridView ID="GridView_CS" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        PageSize="10" CellPadding="0" UseAccessibleHeader="False" AllowPaging="True" OnRowCommand="GridView_CS_RowCommand"
                        OnPageIndexChanging="GridView_CS_PageIndexChanging" AllowSorting="True" Width="100%"
                        DataKeyNames="CSN_ID,CSN_Name" EmptyDataText="无相关记录!" GridLines="None" OnRowCancelingEdit="GridView_CS_RowCancelingEdit"
                        OnRowEditing="GridView_CS_RowEditing" OnRowUpdating="GridView_CS_RowUpdating">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="CSN_ID" SortExpression="CSN_ID" HeaderText="产能核定系列名称信息ID"
                                Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="CSN_Name" SortExpression="CSN_Name" HeaderText="产能核定系列名称">
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete123" runat="server" CommandName="Delete123" CommandArgument='<%#Eval("CSN_ID") %>'
                                        OnClientClick="return confirm('将会删除该产能核定系列，确定吗？')">删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ShowEditButton="True" EditText="编辑" UpdateText="更新" CancelText="关闭">
                            </asp:CommandField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="CapacityPT" runat="server" CommandArgument='<%#Eval("CSN_ID") +","+ Eval("CSN_Name")%>'
                                        CommandName="CapacityPT">所属产品型号</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="CapacityUnit" runat="server" CommandArgument='<%#Eval("CSN_ID") +","+ Eval("CSN_Name")%>'
                                        CommandName="CapacityUnit">单位产能管理</asp:LinkButton>
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
                                        <asp:LinkButton ID="btnGo" runat="server" CommandArgument="-1" CommandName="Page"
                                            Text="GO" CausesValidation="False" />
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

    <asp:UpdatePanel ID="UpdatePanel_Add" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Add" runat="server" Visible="false">
                <fieldset>
                    <legend>新增产能核定系列 </legend>
                    <table style="width: 100%; height: 23px;">
                        <tr style="width: 100%;">
                            <td style="width: 12%;" align="center">
                            </td>
                            <td style="width: 13%;" align="center">
                                产能核定系列：
                            </td>
                            <td align="center" style="width: 18%;">
                                <asp:TextBox ID="TextBox_CS_Add" runat="server"></asp:TextBox>
                                <asp:Label ID="Label49" runat="server" ForeColor="Red" Text="*"></asp:Label>
                            </td>
                            <td align="center" style="width: 10%;">
                                &nbsp;
                            </td>
                            <td align="center" style="width: 15%;">
                                <asp:Button ID="Button_Add_Confirm" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_Add_Confirm_Click" Text="新增" Width="70px" />
                            </td>
                            <td style="width: 15%;" align="center">
                                <asp:Button ID="Button_Add_Cancel" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_Add_Cancel_Click" Text="关闭" Width="70px" />
                            </td>
                            <td align="right" >
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdatePanel_PT" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_PT" runat="server" Visible="true">
                <fieldset>
                    <legend>
                        <asp:Label ID="label_CSN_Name2" runat="server"></asp:Label>
                        所属产品型号表
                        <asp:Label ID="label_CSN_ID" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 69px">
                                产品型号：
                            </td>
                            <td class="auto-style3" style="width: 135px">
                                <asp:TextBox ID="TextBox_PT" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 85px">
                            </td>
                            <td style="width: 200px" align="center">
                                <asp:Button ID="Button_SearchPT" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_SearchPT_Click" Text="检索" Width="70px" />
                            </td>
                            <td align="center" class="auto-style3" style="width: 200px">
                                <asp:Button ID="Button_ResetPT" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_ResetPT_Click" Text="重置" Width="70px" />
                            </td>
                            <td align="center">
                                <asp:Button ID="Button_AddPT" runat="server" CssClass="Button02" Height="24px" OnClick="Button_AddPT_Click"
                                    Text="添加产品型号" Width="90px" />
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView_PT" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        PageSize="10" CellPadding="0" UseAccessibleHeader="False" AllowPaging="True" OnRowCommand="GridView_PT_RowCommand"
                        OnPageIndexChanging="GridView_PT_PageIndexChanging" AllowSorting="True" Width="100%"
                        DataKeyNames="PT_ID,PT_Name" EmptyDataText="无相关记录!" GridLines="None">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="PT_ID" SortExpression="PT_ID" HeaderText="产品型号ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="PT_Name" SortExpression="PT_Name" HeaderText="产品型号"></asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="DeletePT" runat="server" CommandName="DeletePT" CommandArgument='<%#Eval("PT_ID") %>'
                                        OnClientClick="return confirm('将会删除该产能核定系列所属产品型号，确定吗？')">删除</asp:LinkButton>
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
                            <td style="width: 5%" align="center">
                                <asp:Button ID="Button_ClosePT" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_ClosePT_Click" Text="关闭" Width="70px" />
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
                    <legend>产品型号检索</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 5%" align="center">
                                产品系列:
                            </td>
                            <td style="width: 6%" align="left">
                                <asp:TextBox ID="TextBox_Series" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 5%" align="center">
                                产品型号:
                            </td>
                            <td style="width: 6%" align="left">
                                <asp:TextBox ID="TextBox_ProductName" runat="server"></asp:TextBox>
                            </td>
                            <td align="left" style="width: 5%">
                            </td>
                            <td align="center" style="width: 6%">
                                <asp:Button ID="Button_SearchProduct" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_SearchProduct_Click" Text="检索" Width="70px" />
                            </td>
                            <td style="width: 15%" align="center">
                                <asp:Button ID="Button_ResetProduct" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_ResetProduct_Click" Text="重置" Width="70px" />
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView_ProType" runat="server" AllowPaging="True" PageSize="10"
                        Width="100%" AutoGenerateColumns="False" CellPadding="0" CssClass="GridViewStyle"
                        GridLines="None" DataKeyNames="PT_ID" AllowSorting="True" OnPageIndexChanging="GridView_ProType_PageIndexChanging">
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemStyle Width="5%" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox2" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="PT_ID" HeaderText="产品型号ID" Visible="false" />
                            <asp:BoundField DataField="PS_Name" HeaderText="产品系列" ItemStyle-Width="45%" />
                            <asp:BoundField DataField="PT_Name" HeaderText="产品型号" ItemStyle-Width="45%" />
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
                            <td style="width: 2%">
                            </td>
                            <td style="width: 30%">
                                <asp:CheckBox ID="CheckBox2" runat="server" Text="全选" Width="54px" AutoPostBack="True"
                                    OnCheckedChanged="CheckBoxAll2_CheckedChanged" />
                                <asp:CheckBox ID="Checkfanxuan2" runat="server" Text="反选" Width="54px" AutoPostBack="True"
                                    OnCheckedChanged="Checkfanxuan2_CheckedChanged" />
                            </td>
                            <td style="width: 20%">
                                <asp:Button ID="Button_AddPTToSeries" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_AddPTToSeries_Click" Text="提交" Width="70px" />
                            </td>
                            <td>
                                <asp:Button ID="Button_CloseProduct" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_CloseProduct_Click" Text="关闭" Width="70px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_Basic" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Basic" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="label_CSN_Name3" runat="server"></asp:Label>
                        产能核定基础信息表<asp:Label ID="label_CSN_ID3" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 6%" align="center">
                                工序：
                            </td>
                            <td style="width: 6%" align="left">
                                <asp:TextBox ID="TextBox_PBC" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 5%" align="center">
                            </td>
                            <td style="width: 6%" align="left">
                            </td>
                            <td align="center" style="width: 20%">
                                <asp:Button ID="Button_BasicSearch" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_BasicSearch_Click" Text="检索" Width="70px" />
                            </td>
                            <td align="center" style="width: 20%">
                                <asp:Button ID="Button_Basic_Reset" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_Basic_Reset_Click" Text="重置" Width="70px" />
                            </td>
                            <td style="width: 20%" align="center">
                                <asp:Button ID="Button_AddBasic" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_AddBasic_Click" Text="添加基础信息" Width="90px" />
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView_Basic" runat="server" AllowPaging="True" PageSize="10"
                        Width="100%" AutoGenerateColumns="False" CellPadding="0" CssClass="GridViewStyle"
                        GridLines="None" DataKeyNames="CS_ID" AllowSorting="True" OnPageIndexChanging="GridView_Basic_PageIndexChanging"
                        OnRowCommand="GridView_Basic_RowCommand">
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <Columns>
                            <asp:BoundField DataField="CS_ID" HeaderText="产品基础信息ID" Visible="false" />
                            <asp:BoundField DataField="PBC_Name" HeaderText="工序" />
                            <asp:BoundField DataField="CS_LaborC" HeaderText="人工单位产能（件/人/小时）" />
                            <asp:BoundField DataField="CS_MacC" HeaderText="机器单位产能（件/台/小时）" />
                            <asp:BoundField DataField="CS_Formulate" HeaderText="计算公式" Visible="true"/>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Edit_Basic" runat="server" CommandName="Edit_Basic" CommandArgument='<%#Eval("CS_ID")+"?"+ Eval("PBC_Name")+"?"+ Eval("CS_LaborC")+"?"+ Eval("CS_MacC")+"?"+ Eval("CS_Formulate") %>'>编辑</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete_Basic" runat="server" CommandName="Delete_Basic" CommandArgument='<%#Eval("CS_ID") %>'
                                        OnClientClick="return confirm('将会删除该产能核定基础信息，确定吗？')">删除</asp:LinkButton>
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
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 5%" align="center">
                                <asp:Button ID="Button_CloseBasic" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_CloseBasic_Click" Text="关闭" Width="70px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="LabelAddOrEdit" runat="server"></asp:Label>&nbsp;<asp:Label ID="label_CSN_Name_ADD"
                            runat="server" Visible="true"></asp:Label>&nbsp;产能核定基础信息
                        <asp:Label ID="Label_ID" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 10%" align="right">
                                工序：
                            </td>
                            <td style="width: 15%">
                                <asp:DropDownList ID="DropDownList_PBC" runat="server">
                                </asp:DropDownList>
                                <asp:Label ID="Label15" runat="server" ForeColor="Red" Text="*"></asp:Label>
                            </td>
                            <td style="width: 22%" align="right">
                                人工单位产能（件/人/小时）：
                            </td>
                            <td style="width: 15%" class="auto-style3">
                                <asp:TextBox ID="TextBox1" runat="server" onkeyup="this.value=this.value.replace(/\D/g,'')"
                                    onafterpaste="this.value=this.value.replace(/\D/g,'')" Style="ime-mode: disabled"
                                    Width="100px"></asp:TextBox>
                                <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="*"></asp:Label>
                            </td>
                            <td style="width: 23%" align="right">
                                机器单位产能（件/台/小时）：
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox2" runat="server" onkeyup="this.value=this.value.replace(/\D/g,'')"
                                    onafterpaste="this.value=this.value.replace(/\D/g,'')" Style="ime-mode: disabled"
                                    Width="100px"></asp:TextBox>
                                <asp:Label ID="Label4" runat="server" ForeColor="Red" Text="*"></asp:Label>
                            </td>
                        </tr>
                        </table>
                        <asp:Panel ID="Panel2" runat="server">
                        <fieldset>
                            <legend>总产能公式编辑</legend>
                            <table>
                                <tr>
                                    <td style="width: 10%; height: 20%;" align="right">
                                        <asp:Label ID="Label2" runat="server" CssClass="STYLE2" Text="公式："></asp:Label>
                                        <%--<br />
                                        <asp:Label ID="Label13" runat="server" Text="（200字符内）"></asp:Label>--%>
                                    </td>
                                    <td colspan="3" style="height: 20%">
                                        <asp:TextBox ID="TxtFormulaEdit" runat="server" Width="600px" TextMode="MultiLine"
                                            Enabled="false" onkeyup="this.value = this.value.substring(0, 200)" onafterpaste="this.value = this.value.substring(0, 200)"
                                            Height="40px"></asp:TextBox>
                                        <asp:Label ID="Label5" runat="server" ForeColor="Red" Text="*"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    <asp:Label ID="LblRecordIsCheckOK" runat="server" Text="false" Visible="false"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:Button ID="Button2" runat="server" CssClass="Button02" Text="公式校验" Width="70px"
                                                Height="24px" OnClick="Button2_Click" />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="Button3" runat="server" CssClass="Button02" Text="公式重置" Width="70px"
                                                Height="24px" OnClick="Button3_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 20%;" align="right">
                                        <asp:Label ID="Label3" runat="server" Text="可选字段："></asp:Label>
                                    </td>
                                    <td style="width: 30%;">
                                        <asp:ListBox ID="LbCanBeUsedItem" runat="server" Height="125px" Width="180px">
                                            <asp:ListItem>人工单位产能</asp:ListItem>
                                            <asp:ListItem>人工数</asp:ListItem>
                                            <asp:ListItem>人工小时数</asp:ListItem>
                                            <asp:ListItem>人工总产能</asp:ListItem>
                                            <asp:ListItem>机器单位产能</asp:ListItem>
                                            <asp:ListItem>机器数</asp:ListItem>
                                            <asp:ListItem>机器小时数</asp:ListItem>
                                            <asp:ListItem>机器总产能</asp:ListItem>
                                        </asp:ListBox>
                                    </td>
                                    <td style="width: 25%;">
                                        <table align="center">
                                            <tr>
                                                <td>
                                                    <asp:Button runat="server" ID="Sum" Text="Sum" Style="width: 30px" OnClientClick="mouseInput('Sum')" ToolTip="求和"/>
                                                </td>
                                                <td>
                                                    <asp:Button runat="server" ID="Avg" Text="Avg" Style="width: 30px" OnClientClick="mouseInput('Avg')" ToolTip="求平均"/>
                                                </td>
                                                <td>
                                                    <asp:Button runat="server" ID="Max" Text="Max" Style="width: 30px" OnClientClick="mouseInput('Max')" ToolTip="求最大值"/>
                                                </td>
                                                <td>
                                                    <asp:Button runat="server" ID="Min" Text="Min" Style="width: 30px" OnClientClick="mouseInput('Min')" ToolTip="求最小值"/>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="center">
                                                    <asp:Button runat="server" ID="left" Text="(" Style="width: 60px" OnClientClick="mouseInput('left')" ToolTip="左括号"/>
                                                </td>
                                                <td colspan="2" align="center">
                                                    <asp:Button runat="server" ID="right" Text=")" Style="width: 60px" OnClientClick="mouseInput('right')" ToolTip="右括号"/>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Button runat="server" ID="btn7" Text="7" Style="width: 30px" OnClientClick="mouseInput('btn7')" ToolTip="7"/>
                                                </td>
                                                <td>
                                                    <asp:Button runat="server" ID="btn8" Text="8" Style="width: 30px" OnClientClick="mouseInput('btn8')" ToolTip="8"/>
                                                </td>
                                                <td>
                                                    <asp:Button runat="server" ID="btn9" Text="9" Style="width: 30px" OnClientClick="mouseInput('btn9')" ToolTip="9"/>
                                                </td>
                                                <td>
                                                    <asp:Button runat="server" ID="divide" Text="/" Style="width: 30px" OnClientClick="mouseInput('divide')" ToolTip="除号"/>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Button runat="server" ID="btn4" Text="4" Style="width: 30px" OnClientClick="mouseInput('btn4')" ToolTip="4"/>
                                                </td>
                                                <td>
                                                    <asp:Button runat="server" ID="btn5" Text="5" Style="width: 30px" OnClientClick="mouseInput('btn5')" ToolTip="5"/>
                                                </td>
                                                <td>
                                                    <asp:Button runat="server" ID="btn6" Text="6" Style="width: 30px" OnClientClick="mouseInput('btn6')" ToolTip="6"/>
                                                </td>
                                                <td>
                                                    <asp:Button runat="server" ID="chengfa" Text="*" Style="width: 30px" OnClientClick="mouseInput('chengfa')" ToolTip="乘号"/>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Button runat="server" ID="btn1" Text="1" Style="width: 30px" OnClientClick="mouseInput('btn1')" ToolTip="1"/>
                                                </td>
                                                <td>
                                                    <asp:Button runat="server" ID="btn2" Text="2" Style="width: 30px" OnClientClick="mouseInput('btn2')" ToolTip="2"/>
                                                </td>
                                                <td>
                                                    <asp:Button runat="server" ID="btn3" Text="3" Style="width: 30px" OnClientClick="mouseInput('btn3')" ToolTip="3"/>
                                                </td>
                                                <td>
                                                    <asp:Button runat="server" ID="minus" Text="-" Style="width: 30px" OnClientClick="mouseInput('minus')" ToolTip="减号"/>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Button runat="server" ID="comment" Text="," Style="width: 30px" OnClientClick="mouseInput('comment')" ToolTip="逗号"/>
                                                </td>
                                                <td>
                                                    <asp:Button runat="server" ID="btn0" Text="0" Style="width: 30px" OnClientClick="mouseInput('btn0')" ToolTip="0"/>
                                                </td>
                                                <td>
                                                    <asp:Button runat="server" ID="dot" Text="." Style="width: 30px" OnClientClick="mouseInput('dot')" ToolTip="小数点"/>
                                                </td>
                                                <td>
                                                    <asp:Button runat="server" ID="plus" Text="+" Style="width: 30px" OnClientClick="mouseInput('plus')" ToolTip="加号"/>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                    <asp:Label ID="Label6" runat="server" Text="公式示例：<br/>1、求和：Sum（人工总产能，机器总产能）<br/>2、求平均：Avg（人工总产能，机器总产能）<br/>3、求最大值：Max（人工总产能，机器总产能）<br/>4、求最小值：Min（人工总产能，机器总产能）<br/>5、普通公式：人工单位产能*人工数*人工小时数" ForeColor="Red" ></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </asp:Panel>
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td align="center">
                                <asp:Button ID="Button_AddBaiscInfo" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_AddBaiscInfo_Click" Text="提交" Width="70px" />
                            </td>
                            <td align="center">
                                <asp:Button ID="Button_CloseBasicInfo" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_CloseBasicInfo_Click" Text="关闭" Width="70px" />
                            </td>
                            <td>
                                &nbsp;
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
