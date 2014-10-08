<%@ Page Title="" Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true"
    CodeFile="materialsheet.aspx.cs" Inherits="ProductionProcess_materialsheet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel_Search" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Search" runat="server" Visible="true">
                <fieldset>
                    <legend>随工单信息
                        <asp:Label ID="Label_woid" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td align="right">
                                <asp:Button ID="Button1" runat="server" Text="返回" Width="80px" Height="24px" CssClass="Button02"
                                    OnClick="Btn_Return_Click" />
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%;">
                        <tr style="width: 100%;">
                            <td style="width: 9%;" align="center">
                                &nbsp;随工单号：
                            </td>
                            <td style="width: 8%;" align="left">
                                <asp:TextBox ID="TextBox_WO_Num" runat="server" Width="100px" Enabled="False"></asp:TextBox>
                            </td>
                            <td style="width: 9%" align="center">
                                订单号：
                            </td>
                            <td style="width: 9%" align="left">
                                <asp:TextBox ID="TextBox_OrderNum" runat="server" Width="100px" Enabled="False"></asp:TextBox>
                            </td>
                            <td style="width: 9%;" align="center">
                                产品型号：
                            </td>
                            <td style="width: 10%;" align="left">
                                <asp:TextBox ID="TextBox_WO_ProType" runat="server" Width="100px" Enabled="False"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 7%;">
                                计划数量：
                            </td>
                            <td align="left" style="width: 15%;">
                                <asp:TextBox ID="TextBox_pnum" runat="server" Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="width: 100%;">
                            <td style="width: 9%;" align="center">
                                &nbsp;档次要求：
                            </td>
                            <td style="width: 8%;" align="left">
                                <asp:TextBox ID="TextBox_level" runat="server" Width="100px" Enabled="False"></asp:TextBox>
                            </td>
                            <td style="width: 9%" align="center">
                                随工单类型：
                            </td>
                            <td style="width: 9%" align="left">
                                <asp:TextBox ID="TextBox_WOType" runat="server" Enabled="False" Width="100px"></asp:TextBox>
                            </td>
                            <td style="width: 9%;" align="center">
                                生成人：
                            </td>
                            <td style="width: 10%;" align="left">
                                <asp:TextBox ID="TextBox_People" runat="server" Width="100px" Enabled="False"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 7%;">
                                生成时间：
                            </td>
                            <td align="left" style="width: 15%;">
                                <asp:TextBox ID="TextBox_Time" runat="server" Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_basic" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_basic" runat="server">
                <fieldset>
                    <legend>&nbsp;领料信息表 </legend>
                    <table width="100%">
                        <tr>
                            <td align="right">
                                <asp:Button ID="Btn_LL" runat="server" Text="分工站生成领料单" Width="114px" Height="24px"
                                    CssClass="Button02" OnClick="Btn_LL_Click" />
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView_LL" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        CellPadding="0" UseAccessibleHeader="False" OnRowCommand="GridView_LL_RowCommand"
                        Width="100%" DataKeyNames="BD_ID" EmptyDataText="无相关记录!" GridLines="None" OnDataBound="GridView_LL_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="BD_ID" SortExpression="BD_ID" HeaderText="BOM详细ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_MaterialID" SortExpression="IMMBD_MaterialID" HeaderText="物料ID"
                                Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="IMMBD_MaterialName" SortExpression="IMMBD_MaterialName"
                                HeaderText="物料名称"></asp:BoundField>
                            <asp:BoundField DataField="PBC_Name" SortExpression="PBC_Name" HeaderText="领料工序">
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_SpecificationModel" SortExpression="IMMBD_SpecificationModel"
                                HeaderText="规格型号"></asp:BoundField>
                            <asp:BoundField DataField="BD_MUse" SortExpression="BD_MUse" HeaderText="标准用量" ReadOnly="true">
                            </asp:BoundField>
                            <asp:BoundField DataField="BD_MRUse" SortExpression="BD_MRUse" HeaderText="实际用量"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="UnitName" SortExpression="UnitName" HeaderText="计量单位"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="StoreUse" HeaderText="库存用量" SortExpression="SMSMPM_MakeMan"
                                Visible="true" ReadOnly="true" />
                            <asp:BoundField DataField="StoreUnitName" HeaderText="库存单位" SortExpression="SMSMPM_MakeTime"
                                Visible="true" ReadOnly="true" />
                            <asp:BoundField DataField="BDMate" HeaderText="替用物料" SortExpression="BDMate" Visible="true"
                                ReadOnly="true" />
                            <asp:BoundField DataField="BD_IsFuse" HeaderText="组合物料" NullDisplayText="否" SortExpression="BD_IsFuse"
                                ReadOnly="true" />
                            <asp:BoundField DataField="BD_FuseID" HeaderText="组合代号" NullDisplayText="无" SortExpression="BD_FuseID"
                                ReadOnly="true" />
                            <asp:BoundField DataField="suggestNum" SortExpression="suggestNum" HeaderText="参考领料量"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="kucun" SortExpression="kucun" HeaderText="库存可用量" ReadOnly="true">
                            </asp:BoundField>
                            <asp:BoundField DataField="BD_Note" SortExpression="BD_Note" HeaderText="备注" ReadOnly="true">
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
    <asp:UpdatePanel ID="UpdatePane_GXLL" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_GXLL" runat="server" Visible="false">
                <fieldset>
                    <legend>分工序领料单列表 </legend>
                    <table width="100%">
                        <tr>
                            <td align="right">
                                <asp:Button ID="Button_CloseGXLL" runat="server" Text="关闭" Width="114px" Height="24px"
                                    CssClass="Button02" OnClick="Button_CloseGXLL_Click" />
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView_GXLL" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        CellPadding="0" UseAccessibleHeader="False" OnRowCommand="GridView_GXLL_RowCommand"
                        Width="100%" DataKeyNames="IMRM_RequisitionID" EmptyDataText="无相关记录!" GridLines="None"
                        OnDataBound="GridView_GXLL_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="IMRM_RequisitionID" SortExpression="IMRM_RequisitionID"
                                HeaderText="l领料单ID" Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="IMRM_RequisitionNum" SortExpression="IMRM_RequisitionNum"
                                HeaderText="领料单号"></asp:BoundField>
                            <asp:BoundField DataField="IMRM_WorkStation" SortExpression="IMRM_WorkStation" HeaderText="领料工序">
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="CheckDetail" runat="server" CommandArgument='<%#Eval("IMRM_RequisitionID")+","+ Eval("IMRM_WorkStation")  %>'
                                        CommandName="CheckDetail">查看详情</asp:LinkButton>
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
    <asp:UpdatePanel ID="UpdatePanel_Detail" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Detail" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="Label_PBC" runat="server"></asp:Label>
                        <asp:Label ID="label_pbcname" runat="server"></asp:Label>
                        工序 领料单详细表
                        <asp:Label ID="Label_IMRM_RequisitionID" runat="server" Visible="False"></asp:Label>
                    </legend>
                    <table width="100%">
                        <tr>
                            <td align="right">
                                <asp:Button ID="Button_CloseDetail" runat="server" Text="关闭" Width="114px" Height="24px"
                                    CssClass="Button02" OnClick="Button_CloseDetail_Click" />
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView_Detail" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        CellPadding="0" UseAccessibleHeader="False" OnRowCommand="GridView_Detail_RowCommand"
                        Width="100%" DataKeyNames="IMMBD_MaterialID,suggestNum,IMRD_ID" EmptyDataText="无相关记录!"
                        GridLines="None" OnDataBound="GridView_Detail_DataBound" OnRowCancelingEdit="GridView_Detail_RowCancelingEdit"
                        OnRowEditing="GridView_Detail_RowEditing" OnRowUpdating="GridView_Detail_RowUpdating"
                        OnRowDataBound="GridView_Detail_RowDataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="IMMBD_MaterialID" SortExpression="IMMBD_MaterialID" HeaderText="物料ID"
                                ReadOnly="true" Visible="False"></asp:BoundField>
                            <asp:BoundField DataField="IMRD_ID" SortExpression="IMRD_ID" HeaderText="领料详细ID"
                                Visible="false" ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="IMMBD_MaterialName" SortExpression="IMMBD_MaterialName"
                                HeaderText="物料名称" ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="IMMBD_SpecificationModel" SortExpression="IMMBD_SpecificationModel"
                                HeaderText="规格型号" ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="BD_MUse" SortExpression="BD_MUse" HeaderText="标准用量" ReadOnly="true">
                            </asp:BoundField>
                            <asp:BoundField DataField="BD_MRUse" SortExpression="BD_MRUse" HeaderText="实际用量"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="UnitName" SortExpression="UnitName" HeaderText="计量单位"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="StoreUse" HeaderText="库存用量" SortExpression="SMSMPM_MakeMan"
                                Visible="true" ReadOnly="true" />
                            <asp:BoundField DataField="StoreUnitName" HeaderText="库存单位" SortExpression="SMSMPM_MakeTime"
                                Visible="true" ReadOnly="true" />
                            <asp:BoundField DataField="BDMate" HeaderText="替用物料" SortExpression="BDMate" Visible="true"
                                ReadOnly="true" />
                            <asp:BoundField DataField="BD_IsFuse" HeaderText="组合物料" NullDisplayText="否" SortExpression="BD_IsFuse"
                                ReadOnly="true" />
                            <asp:BoundField DataField="BD_FuseID" HeaderText="组合代号" NullDisplayText="无" SortExpression="BD_FuseID"
                                ReadOnly="true" />
                            <asp:BoundField DataField="suggestNum" SortExpression="suggestNum" HeaderText="参考领料量"
                                ReadOnly="true"></asp:BoundField>
                            <asp:BoundField DataField="kucun" SortExpression="kucun" HeaderText="库存可用量" ReadOnly="true">
                            </asp:BoundField>
                            <asp:BoundField DataField="BD_Note" SortExpression="BD_Note" HeaderText="备注" ReadOnly="true">
                            </asp:BoundField>
                            <asp:BoundField DataField="IMRD_ActualNum" SortExpression="IMRD_ActualNum" HeaderText="计划领料量">
                            </asp:BoundField>
                            <asp:CommandField ShowEditButton="True" EditText="编辑" UpdateText="更新" CancelText="取消">
                            </asp:CommandField>
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
</asp:Content>
