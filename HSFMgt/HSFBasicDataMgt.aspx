<%@ Page Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true"
    CodeFile="HSFBasicDataMgt.aspx.cs" Inherits="HSFMgt_HSFBasicDataMgt" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel_SearchItems" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_SearchItems" runat="server">
                <fieldset>
                    <legend>管制项目检索栏</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label2" runat="server"   Text="项目名称"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtItemName" runat="server" Width="155px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="LblPost" runat="server"   Text="管制对象范围"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TextBoundary" runat="server" Width="155px"></asp:TextBox>
                            </td>
                            <td style="height: 16px;">
                                <asp:Label ID="LblState" runat="server" Visible="false"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" colspan="2">
                                <asp:Button ID="BtnSearchItems" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="BtnSearchItems_Click" Text="检索" Width="80px" />
                            </td>
                            <td align="center" colspan="2">
                                <asp:Button ID="BtnNewItems" runat="server" CssClass="Button02" Height="24px" OnClick="BtnNew_Click"
                                    Text="新增" Width="80px" />
                            </td>
                            <td align="left" colspan="2">
                                <asp:Button ID="BtnResetItems" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="BtnReset_Click" Text="重置" Visible="true" Width="80px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    
    <br />
    <asp:UpdatePanel ID="UpdatePanel_GridViewItem" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_GridViewItem" runat="server" >
                <fieldset>
                    <legend>管制项目列表</legend>
                    <asp:GridView ID="Grid_ControlItems" runat="server" DataKeyNames="HSFCI_ItemID" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" 
                        Width="100%" Visible="true" GridLines="None"
                        AllowPaging="True" PageSize="10" UseAccessibleHeader="False"
                        OnPageIndexChanging="Grid_ControlItems_PageIndexChanging" 
                        OnSorting="Grid_ControlItems_Sorting"
                        OnRowCommand="Grid_ControlItems_RowCommand" 
                        onrowdatabound="Grid_ControlItems_RowDataBound" 
                        onrowcreated="Grid_ControlItems_RowCreated" EnableViewState="False" 
                        ondatabound="Grid_ControlItems_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle  cssclass="GridViewHead"/>
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <%--<PagerStyle CssClass="GridViewPagerStyle" />--%>
                        <Columns>
                            <asp:BoundField DataField="HSFCI_ItemID" HeaderText="管制项目ID" ReadOnly="True" SortExpression="HSFCI_ItemID"
                                Visible="false">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>                         
                            <asp:BoundField DataField="HSFCI_ItemName" SortExpression="HSFCI_ItemName" HeaderText="项目名称">
                                <HeaderStyle Width="15%" />
                                <ItemStyle Width="15%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="HSFCI_Standard" SortExpression="HSFCI_Standard" HeaderText="管制标准">
                                <HeaderStyle Width="20%" />
                                <ItemStyle Width="20%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="HSFCI_Boundary" SortExpression="HSFCI_Boundary" HeaderText="管制对象范围">
                                <HeaderStyle Width="20%" />
                                <ItemStyle Width="20%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="HSFCI_Period" SortExpression="HSFCI_Period" HeaderText="管制周期">
                                <HeaderStyle Width="15%" />
                                <ItemStyle Width="15%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="HSFCI_RemindDay" SortExpression="HSFCI_RemindDay" HeaderText="提前报警时限">
                                <HeaderStyle Width="15%" />
                                <ItemStyle Width="15%" />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnEdit_ControlItem" runat="server" CommandArgument='<%#Eval("HSFCI_ItemID")%>'
                                        CommandName="Edt_ControlItem" OnClientClick="false">编辑</asp:LinkButton>
                                </ItemTemplate>                               
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnDelete_ControlItem" runat="server" CommandName="Delete_ControlItem"
                                        OnClientClick="return confirm('您确认删除该记录吗?')" CommandArgument='<%#Eval("HSFCI_ItemID")%>'>删除</asp:LinkButton>
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
    <br />
    <asp:UpdatePanel ID="UpdatePanel_NewControlItem" runat="server" UpdateMode="Conditional">
        <%--<Triggers>
            <asp:AsyncPostBackTrigger ControlID="Btn_NEW_NETItem" />
        </Triggers>--%>
        <ContentTemplate>
            <asp:Panel ID="Panel_NewControlItem" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="LblControlItem" runat="server"   Text=""></asp:Label>
                    </legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label1" runat="server"   Text="项目名称"></asp:Label>
                            </td>
                            <td colspan="2" style="width: 20%">
                                <asp:TextBox ID="TxtNewItemName" runat="server" Width="300px" MaxLength="20"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label4" runat="server"   Text="管制对象范围"></asp:Label>
                            </td>
                            <td colspan="2" style="width: 20%">
                                <asp:TextBox ID="TextNewBoundary" runat="server" Width="300px" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>                        
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label5" runat="server"   Text="管制周期(天)"></asp:Label>
                            </td>
                            <td colspan="2" style="width: 20%">
                                <asp:TextBox ID="TextNewPeriod" runat="server" Width="155px" MaxLength="5"></asp:TextBox>
                                <br />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Error:请输入数字"
                                    ControlToValidate="TextNewPeriod" ValidationExpression="^[0-9]*$">
                                </asp:RegularExpressionValidator>
                            </td>                            
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label6" runat="server"   Text="提前报警时限(天)"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TextNewRemindDay" runat="server" Width="155px" MaxLength="5"></asp:TextBox>
                                <br />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Error:请输入数字"
                                    ControlToValidate="TextNewRemindDay" ValidationExpression="^[0-9]*$">
                                </asp:RegularExpressionValidator>
                            </td>
                        </tr>   
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label3" runat="server"   Text="管制标准"></asp:Label>
                            </td>
                            <td colspan="5" style="width: 50%">
                                <asp:TextBox ID="TextNewStandard" runat="server" Width="500px" MaxLength="250"></asp:TextBox>
                                &nbsp;</td>
                        </tr>                        
                        <tr style="height: 16px;">
                            <td colspan="2" align="right">
                                <asp:Button ID="BtnSubmit" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    Width="80px" OnClientClick="false" OnClick="BtnSubmit_Click" />
                            </td>
                            <td colspan="2" align="right">
                                <asp:Button ID="BtnClose" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    Visible="true" Width="80px" OnClick="BtnClose_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <asp:UpdatePanel ID="UpdatePanel_RiskLevel" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_RiskLevel" runat="server">
                <fieldset>
                    <legend>风险等级检索栏</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label7" runat="server"   Text="风险等级"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtRiskLevel" runat="server" Width="155px"></asp:TextBox>
                            </td>
                            <td style="height: 16px;">
                                <asp:Label ID="LblRiskState" runat="server" Visible="false"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" colspan="2">
                                <asp:Button ID="BtnSearchRisk" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="BtnSearchRisk_Click" Text="检索" Width="80px" />
                            </td>
                            <td align="center" colspan="2">
                                <asp:Button ID="BtnNewRisk" runat="server" CssClass="Button02" Height="24px" OnClick="BtnNewRisk_Click"
                                    Text="新增" Width="80px" />
                            </td>
                            <td align="left" colspan="2">
                                <asp:Button ID="BtnResetRisk" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="BtnResetRisk_Click" Text="重置" Visible="true" Width="80px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_GridRisk" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_GridRisk" runat="server" >
                <fieldset>
                    <legend>风险等级列表</legend>
                    <asp:GridView ID="Grid_Risk" runat="server" DataKeyNames="HSFRL_RiskLevelID" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" 
                        Width="100%" Visible="true" GridLines="None"
                        AllowPaging="True" PageSize="5" UseAccessibleHeader="False"
                        OnPageIndexChanging="Grid_Risk_PageIndexChanging" 
                        OnSorting="Grid_Risk_Sorting"
                        OnRowCommand="Grid_Risk_RowCommand" 
                        onrowdatabound="Grid_Risk_RowDataBound" 
                        onrowcreated="Grid_Risk_RowCreated" EnableViewState="False" 
                        ondatabound="Grid_Risk_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle  cssclass="GridViewHead"/>
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <%--<PagerStyle CssClass="GridViewPagerStyle" />--%>
                        <Columns>
                            <asp:BoundField DataField="HSFRL_RiskLevelID" HeaderText="风险等级ID" ReadOnly="True" SortExpression="HSFRL_RiskLevelID"
                                Visible="false">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>                         
                            <asp:BoundField DataField="HSFRL_RiskLeve" SortExpression="HSFRL_RiskLeve" HeaderText="风险等级">
                                <HeaderStyle Width="50%" />
                                <ItemStyle Width="50%" />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnDelete_RiskLevel" runat="server" CommandName="Delete_RiskLevel"
                                        OnClientClick="return confirm('您确认删除该记录吗?')" CommandArgument='<%#Eval("HSFRL_RiskLevelID")%>'>删除</asp:LinkButton>
                                </ItemTemplate>                                
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnEdit_RiskLevel" runat="server" CommandArgument='<%#Eval("HSFRL_RiskLevelID")%>'
                                        CommandName="Edt_RiskLevel" OnClientClick="false">该风险等级下物料维护</asp:LinkButton>
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
    <asp:UpdatePanel ID="UpdatePanel_NewRisk" runat="server" UpdateMode="Conditional">
        <%--<Triggers>
            <asp:AsyncPostBackTrigger ControlID="Btn_NEW_NETItem" />
        </Triggers>--%>
        <ContentTemplate>
            <asp:Panel ID="Panel_NewRisk" runat="server" Visible="false">
                <fieldset>
                    <legend>新增风险等级</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label11" runat="server"   Text="风险等级"></asp:Label>
                            </td>
                            <td colspan="2" style="width: 20%">
                                <asp:TextBox ID="TxtNewRisk" runat="server" Width="300px" MaxLength="25"></asp:TextBox>
                            </td>
                        </tr>                     
                        <tr style="height: 16px;">
                            <td  align="right">
                                <asp:Button ID="BtnOK_NewRisk" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    Width="80px"  OnClick="BtnOK_NewRisk_Click" />
                            </td>
                            <td align="center">
                                <asp:Button ID="BtnCls_NewRisk" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    Visible="true" Width="80px" OnClick="BtnCls_NewRisk_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_SearchMaterial" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_SearchMaterial" runat="server" Visible="false">
                <fieldset>
                    <legend>物料检索栏</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label8" runat="server"   Text="物料类别"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtMaterialType" runat="server" Width="155px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label9" runat="server" Text="物料名称"></asp:Label>
                            </td>
                            <td style="width: 15%">
                                <asp:TextBox ID="TextMaterialName" runat="server" Width="155px"></asp:TextBox>
                                <asp:Label ID="LblSearchCond" runat="server"   Text="" Visible="false"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" colspan="2">
                                <asp:Button ID="BtnSearchMaterial" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="BtnSearchMaterial_Click" Text="检索物料" Width="80px" />
                            </td>
                            <td align="center" colspan="2">
                                <asp:Button ID="BtnSearchRest" runat="server" CssClass="Button02" Height="24px" OnClick="BtnSearchRest_Click"
                                    Text="检索所有" Width="80px" />
                            </td>
                            <td align="left" colspan="2">
                                <asp:Button ID="BtnResetM" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="BtnResetM_Click" Text="重置" Visible="true" Width="80px" />
                            </td>
                            <td align="center" colspan="2">
                                <asp:Button ID="BtnCls_Material" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="BtnCls_Material_Click" Text="取消" Visible="true" Width="80px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_GridMaterial" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_GridMaterial" runat="server" >
                <fieldset>
                    <legend>
                        <asp:Label ID="LblGridMaterial" runat="server"   Text=""></asp:Label>
                    </legend>
                    <asp:GridView ID="Grid_Material" runat="server" DataKeyNames="IMMBD_MaterialID" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" 
                        Width="100%" Visible="true" GridLines="None"
                        AllowPaging="True" PageSize="10" UseAccessibleHeader="False"
                        OnPageIndexChanging="Grid_Material_PageIndexChanging" 
                        OnSorting="Grid_Material_Sorting"
                        OnRowCommand="Grid_Material_RowCommand" 
                        onrowdatabound="Grid_Material_RowDataBound" 
                        onrowcreated="Grid_Material_RowCreated"
                        ondatabound="Grid_Material_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle  cssclass="GridViewHead"/>
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <%--<PagerStyle CssClass="GridViewPagerStyle" />--%>
                        <Columns>
                            <asp:BoundField DataField="IMMBD_MaterialID" HeaderText="物料ID" ReadOnly="True" SortExpression="IMMBD_MaterialID"
                                Visible="false">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>                         
                            <asp:BoundField DataField="IMMT_MaterialType" SortExpression="IMMT_MaterialType" HeaderText="物料类别">
                                <HeaderStyle Width="20%" />
                                <ItemStyle Width="20%" />
                            </asp:BoundField>                    
                            <asp:BoundField DataField="IMMBD_MaterialName" SortExpression="IMMBD_MaterialName" HeaderText="物料名称">
                                <HeaderStyle Width="20%" />
                                <ItemStyle Width="20%" />
                            </asp:BoundField>                    
                            <asp:BoundField DataField="HSFRL_RiskLeve" SortExpression="HSFRL_RiskLeve" HeaderText="风险等级">
                                <HeaderStyle Width="20%" />
                                <ItemStyle Width="20%" />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnDelete_Material" runat="server" CommandName="Delete_Material"
                                        OnClientClick="return confirm('您确认删除该记录吗?')" CommandArgument='<%#Eval("IMMBD_MaterialID")%>'>删除</asp:LinkButton>
                                </ItemTemplate>                                
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnChoose_Risk" runat="server" CommandArgument='<%#Eval("IMMBD_MaterialID")%>'
                                        CommandName="Chs_Risk" OnClientClick="return confirm('您确认更改风险等级吗?')">选择</asp:LinkButton>
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
    
 </asp:Content>