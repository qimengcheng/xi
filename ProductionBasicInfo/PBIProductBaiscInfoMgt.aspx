<%@ Page Language="C#" MasterPageFile="~/Other/MasterPage.master" EnableEventValidation="false"
    AutoEventWireup="true" CodeFile="PBIProductBaiscInfoMgt.aspx.cs" Inherits="ProductionBasicInfo_PBIProductBaiscInfoMgt"
    Title="产品基础信息管理" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Label ID="Label_Grid1_Color" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="Label_sort" runat="server"></asp:Label>
    <asp:Label ID="Label_Grid1_State" runat="server" Text="默认数据源" Visible="False"></asp:Label>
    <asp:Label ID="Label_Search" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="label_pagestate" runat="server" Visible="False"></asp:Label>
    <asp:UpdatePanel ID="UpdatePanel_Search" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Search" runat="server" Visible="true">
                <fieldset>
                    <legend>产品系列查询</legend>
                    <table style="width: 100%;">
                        <tr style="width: 100%;">
                            <td style="width: 10%;">
                                产品系列：
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
                                    Text="新增产品系列" Width="90px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_AddPS" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_AddPS" runat="server" Visible="false">
                <fieldset>
                    <legend>产品系列新增</legend>
                    <table style="width: 100%;">
                        <tr style="width: 100%;">
                            <td style="width: 10%;">
                                产品系列：
                            </td>
                            <td style="width: 21%;">
                                <asp:TextBox ID="txt_PS" runat="server" Width="200px" MaxLength="30"></asp:TextBox>
                            </td>
                            <td style="width: 15%;">
                                
                            </td>
                            <td style="width: 15%;" align="center">
                                <asp:Button ID="Btn_Submit" runat="server" Text="提交" Width="70px" Height="24px" CssClass="Button02"
                                    OnClick="Btn_Submit_Click" />
                            </td>
                            <td style="width: 15%;" align="center">
                            <asp:Button ID="Btn_Cancel" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_Cancel_Click"
                                    Text="重置" Width="70px" />
                            </td>
                            <td style="width: 35%;" align="center">
                                <asp:Button ID="Btn_Close_PS" runat="server" CssClass="Button02" Height="24px" OnClick="Button_Close_PSSearch_Click"
                                    Text="关闭" Width="70px" />
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
                    <legend>产品系列表<asp:Label ID="Lab_State" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle" Font-Strikeout="False" GridLines="None"
                        PageSize="5" CellPadding="0" UseAccessibleHeader="False" AllowPaging="True" OnRowCommand="GridView1_RowCommand"
                        OnPageIndexChanging="GridView1_PageIndexChanging" OnRowEditing="Gridview_PS_Editing"
                        OnRowCancelingEdit="Gridview_PS_CancelingEdit" AllowSorting="True" OnRowCreated="GridView1_RowCreated"
                        OnSorting="GridView1_Sorting" OnRowUpdating="Gridview_PS_Updating" OnRowDataBound="GridView1_RowDataBound"
                        Width="100%" DataKeyNames="PS_ID" OnDataBound="GridView1_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="PS_ID" HeaderText="产品系列ID" SortExpression="PS_ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="PS_Name" SortExpression="PS_Name" HeaderText="产品系列"></asp:BoundField>
                            <asp:CommandField ShowEditButton="True" EditText="编辑" UpdateText="更新" CancelText="关闭">
                                <ItemStyle Width="10%" />
                            </asp:CommandField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete1" runat="server" CommandArgument='<%# Eval("PS_ID") %>'
                                        CommandName="Delete1" OnClientClick="return confirm('您确认删除该记录吗?')">删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="CheckProType" runat="server" CommandArgument='<%# Eval("PS_ID")+","+Eval("PS_Name") %>'
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
                            <td style="width: 21%;">
                                <asp:TextBox ID="Txt_PT_Search" runat="server" Width="200px" MaxLength="30"></asp:TextBox>
                            </td>
                            <td style="width: 15%;" align="center">
                                <asp:Button ID="Button3" runat="server" Text="检索" Width="70px" Height="24px" CssClass="Button02"
                                    OnClick="Btn_SearchPT_Click" />
                            </td>
                            <td style="width: 15%;" align="center">
                                <asp:Button ID="Button2" runat="server" CssClass="Button02" Height="24px" OnClick="Button_CancelPT_Click"
                                    Text="重置" Width="70px" />
                            </td>
                            <td style="width: 15%;" align="center">
                                <asp:Button ID="Btn_AddPT" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_AddPT_Click"
                                    Text="新增产品型号" Width="90px" />
                            </td>
                            <td style="width: 35%;" align="center">
                                <asp:Button ID="Btn_Close" runat="server" CssClass="Button02" Height="24px" OnClick="Button_Close_PT_Click"
                                    Text="关闭" Width="70px" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle" Font-Strikeout="False" GridLines="None"
                        PageSize="5" CellPadding="0" UseAccessibleHeader="False" AllowPaging="True" OnRowCommand="GridView2_RowCommand"
                        OnPageIndexChanging="GridView2_PageIndexChanging" OnRowEditing="Gridview_PT_Editing"
                        OnRowCancelingEdit="Gridview_PT_CancelingEdit" AllowSorting="True" OnRowCreated="GridView2_RowCreated"
                        OnSorting="GridView2_Sorting" OnRowUpdating="Gridview_PT_Updating" OnRowDataBound="GridView2_RowDataBound"
                        Width="100%" DataKeyNames="PT_ID" EmptyDataText="无相关记录!" OnDataBound="GridView2_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="PT_ID" HeaderText="产品型号ID" SortExpression="PT_ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="PT_Name" SortExpression="PT_Name" HeaderText="产品型号"></asp:BoundField>
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
                            <asp:BoundField DataField="PT_Man" SortExpression="PT_Man" HeaderText="制定人"></asp:BoundField>
                            <asp:BoundField DataField="PT_Time" SortExpression="PT_Time" HeaderText="制定时间" DataFormatString="{0:yyyy-MM-dd HH:mm}">
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Edit_PT" runat="server" CommandArgument='<%# Eval("PT_Name")+","+Eval("PT_Special")+","+Eval("PR_ID")+","+Eval("BOM_ID")+","+Eval("PT_ID") %>'
                                        CommandName="Edit_PT">编辑</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete_PT" runat="server" CommandArgument='<%# Eval("PT_ID") %>'
                                        CommandName="Delete_PT" OnClientClick="return confirm('您确认删除该记录吗?')">删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Check_Parameter" runat="server" CommandArgument='<%# Eval("PR_ID")+","+Eval("PT_Name")+","+Eval("PT_ID") %>'
                                        CommandName="Check_Parameter">工艺参数</asp:LinkButton>
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
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_AddPT" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_AddPT" runat="server" Visible="false">
                <fieldset>
                    <legend>&nbsp;<asp:Label ID="Label_submitState" runat="server"></asp:Label>
                        &nbsp;<asp:Label ID="Label_PT_ID" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="Label_PRID" runat="server" Visible="False"></asp:Label>
                        产品型号</legend>
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 9%">
                                产品型号:
                            </td>
                            <td style="width: 12.5%">
                                <asp:TextBox ID="Txt_PT" runat="server" Width="125px" MaxLength="30"></asp:TextBox>
                            </td>
                            <td style="width: 17%">
                                &nbsp; 是否属于特殊产品：
                            </td>
                            <td style="width: 12.5%">
                                <asp:DropDownList ID="DropDownList_Special" runat="server" Width="70px">
                                    <asp:ListItem Value="否" Text="否"></asp:ListItem>
                                    <asp:ListItem Value="是" Text="是"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="width: 16%">
                                BOM（物料清单）：
                            </td>
                            <td style="width: 12.5%;">
                                <asp:DropDownList ID="DropDownList_BOM" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 10%;">
                                工艺路线：
                            </td>
                            <td style="width: 12.5%;" align="right">
                                <asp:DropDownList ID="DropDownList_PR" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 9%">
                                <asp:Label ID="Label_ptname" runat="server" Visible="False"></asp:Label>
                            </td>
                            <td align="left">
                            </td>
                            <td align="center">
                                <asp:Button ID="Btn_AddPT_Submit" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Btn_AddPTSubmit_Click" Text="提交" Width="70px" />
                            </td>
                            <td>
                            </td>
                            <td align="center">
                                <asp:Button ID="Btn_CancelPT" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_CancelPT_Click"
                                    Text="关闭" Width="70px" />
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_Parameter" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Parameter" runat="server" Visible="false">
                <fieldset>
                    <legend>产品&nbsp;
                        <asp:Label ID="Label_PTP" runat="server"></asp:Label>&nbsp;工艺参数表 </legend>
                    
                    <asp:GridView ID="GridView_Parameter" runat="server" AutoGenerateColumns="false" Font-Strikeout="False" GridLines="None"
                        CssClass="GridViewStyle" PageSize="5" CellPadding="0" UseAccessibleHeader="False"
                        AllowPaging="True" OnRowCommand="GridView_Parameter_RowCommand" OnPageIndexChanging="GridView_Parameter_PageIndexChanging"
                        AllowSorting="True" OnRowCreated="GridView_Parameter_RowCreated" OnSorting="GridView_Parameter_Sorting"
                        OnRowDataBound="GridView_Parameter_RowDataBound" Width="100%" DataKeyNames="PBC_ID"
                        EmptyDataText="无相关记录!" OnDataBound="GridView_Parameter_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="PBC_ID" HeaderText="工序ID" SortExpression="PBC_ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="PRD_Order" SortExpression="PRD_Order" HeaderText="工序排序">
                            </asp:BoundField>
                            <asp:BoundField DataField="PBC_Name" SortExpression="PBC_Name" HeaderText="工序名称">
                            </asp:BoundField>
                            <asp:BoundField DataField="PRD_Doc" SortExpression="PRD_Doc" HeaderText="相关文件"></asp:BoundField>
                            <asp:BoundField DataField="PRD_Way" SortExpression="PRD_Way" HeaderText="管控方式"></asp:BoundField>
                            <asp:BoundField DataField="PRD_Note" SortExpression="PRD_Note" HeaderText="备注"></asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Check_PT_Parameter" runat="server" CommandArgument='<%# Eval("PBC_ID")+","+Eval("PBC_Name") %>'
                                        CommandName="Check_PT_Parameter">查看工艺参数</asp:LinkButton>
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
                    <table width="100%">
                        <tr>
                            <td align="center">
                                <asp:Button ID="Btn_Close_Parameter" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Btn_Close_Parameter_Click" Text="关闭" Width="70px" />
                            </td>
                        </tr>
                    </table>
                    </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_CheckParameter" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_CheckParameter" runat="server" Visible="false">
                <fieldset>
                    <legend>查看产品<asp:Label ID="Label_PT2" runat="server"></asp:Label>
                        工艺参数<asp:Label ID="Label_PBCID" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <table style="width: 100%;">
                        <tr style="width: 100%;">
                            <td style="width: 19%;">
                                工艺参数:
                            </td>
                            <td style="width: 50%;">
                                <asp:TextBox ID="Txt_parameter" runat="server" Width="500px" MaxLength="100"></asp:TextBox>
                            </td>
                            <td style="width: 12.5%;" align="right">
                               
                            </td>
                        </tr>
                        <tr style="width: 100%;">
                            <td style="width: 19%;">
                                合格率标准（0至1之间的小数）：
                            </td>
                            <td style="width: 12.5%;">
                                <asp:TextBox ID="Txt_PassRate" Style="ime-mode: disabled" runat="server" Width="500px"
                                    
                                    onKeyPress="if (event.keyCode!=46 && event.keyCode!=45 && (event.keyCode<48 || event.keyCode>57)) event.returnValue=false" 
                                    MaxLength="100"></asp:TextBox>
                            </td>
                            <td style="width: 12.5%;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr style="width: 100%;">
                            <td style="width: 19%;">
                                备注：(100字以内)
                            </td>
                            <td style="width: 12.5%;">
                                <asp:TextBox ID="TextBox_Note" runat="server" Width="500px" MaxLength="100"></asp:TextBox>
                            </td>
                            <td style="width: 12.5%;">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%;">
                        <tr>
                            <td align="center" style="width: 160px">
                                &nbsp;
                            </td>
                            <td align="center" style="width: 195px">
                                <asp:Button ID="Btn_I_parameter" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Btn_I_parameter_Click" Text="提交" Width="70px" />
                            </td>
                            <td align="center" style="width: 195px">
                                 <asp:Button ID="Btn_Close_CheckParameter" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_Close_CheckParameter_Click" Text="关闭" Width="70px" />
                            </td>
                            <td>
                                &nbsp;
                                <asp:Button ID="Btn_U_parameter" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Btn_U_parameter_Click" Text="修改参数" Width="70px" Visible="False" />
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
