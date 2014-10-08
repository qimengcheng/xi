<%@ Page Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true"
    CodeFile="ETExpAppSubmit.aspx.cs" Inherits="ExperimentTest_ETExpAppSubmit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel_SearchSubmit" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_SearchSubmit" runat="server">
                <fieldset>
                    <legend>实验申请单检索栏</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label2" runat="server" CssClass="STYLE2" Text="产品标识:"></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:TextBox ID="TxtProIdentify" runat="server" Width="155px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="right">
                                <asp:Label ID="LblPost" runat="server" CssClass="STYLE2" Text="申请时间:"></asp:Label>
                            </td>
                            <td style="width: 20%" align="left" colspan="3">
                                <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
                                <asp:TextBox ID="TxtAppTime1" runat="server" 
                                    onfocus="new WdatePicker(this,'%Y-%M-%D 00:00:00',true)"></asp:TextBox>
                            <%--</td>
                            <td style="width: 10%" align="center">--%>
                                &nbsp;&nbsp;&nbsp;
                                <asp:Label ID="Label4" runat="server" CssClass="STYLE2" Text="到"></asp:Label>
                            <%--</td>
                            <td style="width: 20%" align="left">--%>
                                &nbsp;&nbsp;&nbsp;<%--</td>
                            <td style="width: 20%" align="left">--%><%--</td>
                            <td style="width: 20%" align="left">--%><script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script><asp:TextBox ID="TxtAppTime2" runat="server" 
                                    onfocus="new WdatePicker(this,'%Y-%M-%D 00:00:00',true)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label53" runat="server" CssClass="STYLE2" Text="实验申请单号:"></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:TextBox ID="textExpAppNO" runat="server" Width="155px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label54" runat="server" CssClass="STYLE2" Text="样品类型:"></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
                                <asp:DropDownList ID="DropDownList1" runat="server" ToolTip="单击选择">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label55" runat="server" CssClass="STYLE2" Text="申请部门："></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:DropDownList ID="DropDownList2" runat="server" ToolTip="单击选择">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label5" runat="server" CssClass="STYLE2" Text="申请单状态:"></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:DropDownList ID="DdlAppStatus" runat="server" ToolTip="单击选择">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label6" runat="server" CssClass="STYLE2" Text="紧急程度:"></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:DropDownList ID="DdlEmergDegree" runat="server" ToolTip="单击选择">
                                    <asp:ListItem Value="0" Selected="True">请选择</asp:ListItem>
                                    <asp:ListItem Value="1">一般</asp:ListItem>
                                    <asp:ListItem Value="2">紧急</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                        <table style="width:100%" align="center">
                        <tr>
                            <td align="right" style="width:35%">
                                <asp:Button ID="BtnSearchExpApp" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="BtnSearch_Click" Text="检索" Width="70px" />
                            </td>
                            <td align="center" style="width:30%">
                                <asp:Button ID="BtnNewExpApp" runat="server" CssClass="Button02" Height="24px" OnClick="BtnNew_Click"
                                    Text="新增" Width="70px" />
                            </td>
                            <td align="left" >
                                <asp:Button ID="BtnResetExpApp" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="BtnReset_Click" Text="重置" Visible="true" Width="70px" />
                            </td>
                        </tr>
                        </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--<br />--%>
    <asp:UpdatePanel ID="UpdatePanel_ExpApp" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_ExpApp" runat="server">
                <fieldset>
                    <legend>实验申请列表 </legend>
                    <asp:Label ID="Labelp1" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="Labelp2" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="Labeldep" runat="server" Visible="False"></asp:Label>
                    <asp:GridView ID="Grid_ExpApp" runat="server" DataKeyNames="ETA_ExpID" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                        AllowPaging="True" PageSize="5" Font-Strikeout="False" GridLines="None" UseAccessibleHeader="False"
                        OnPageIndexChanging="Grid_ExpApp_PageIndexChanging" 
                        OnRowCommand="Grid_ExpApp_RowCommand" EnableViewState="False" 
                        OnDataBound="Grid_ExpApp_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="ETA_ExpID" HeaderText="试验申请ID" SortExpression="ETA_ExpID"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="ETA_ExpAppNO" HeaderText="实验申请单号" SortExpression="ETA_ExpAppNO"
                                Visible="true">
                                <HeaderStyle Width="10%" />
                                <ItemStyle Width="10%" />
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="ETA_AppStatus" HeaderText="申请单状态" SortExpression="ETA_AppStatus"
                                Visible="true">
                                <HeaderStyle Width="8%" />
                                <ItemStyle Width="8%" />
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="ETA_ProIdentify" HeaderText="产品标识" SortExpression="ETA_ProIdentify"
                                Visible="true">
                                <HeaderStyle Width="8%" />
                                <ItemStyle Width="8%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="EST_SampleType" HeaderText="样品类型" SortExpression="EST_SampleType"
                                Visible="true">
                                <HeaderStyle Width="8%" />
                                <ItemStyle Width="8%" />
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="ETA_SamNum" HeaderText="样品数量" SortExpression="ETA_SamNum"
                                Visible="true">
                                <HeaderStyle Width="6%" />
                                <ItemStyle Width="6%" />
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="ETA_EmergDegree" HeaderText="紧急程度" SortExpression="ETA_EmergDegree"
                                Visible="true">
                                <HeaderStyle Width="6%" />
                                <ItemStyle Width="6%" />
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="ETA_AppDep" HeaderText="申请部门" SortExpression="ETA_AppDep" >
                            </asp:BoundField>
                            <asp:BoundField DataField="ETA_AppPer" HeaderText="申请人" SortExpression="ETA_AppPer"
                                Visible="true">
                                <HeaderStyle Width="8%" />
                                <ItemStyle Width="8%" />
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="ETA_AppTime" HeaderText="申请时间" SortExpression="ETA_AppTime"
                                Visible="true">
                                <HeaderStyle Width="10%" />
                                <ItemStyle Width="10%" />
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="ETA_AuRes" HeaderText="审核结果" SortExpression="ETA_AuRes"
                                Visible="true">
                                <HeaderStyle Width="6%" />
                                <ItemStyle Width="6%" />
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="ETA_ExpRes" HeaderText="实验结果" SortExpression="ETA_ExpRes"
                                Visible="true">
                                <HeaderStyle Width="6%" />
                                <ItemStyle Width="6%" />
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnView_ExpApp" runat="server" CommandArgument='<%#Eval("ETA_ExpID")%>'
                                        CommandName="View_ExpApp" OnClientClick="false">查看详情</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnEdit_ExpApp" runat="server" CommandArgument='<%#Eval("ETA_ExpID")%>'
                                        CommandName="Edit_ExpApp" OnClientClick="false">编辑</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnSelect_Item" runat="server" CommandArgument='<%#Eval("ETA_ExpID")%>'
                                        CommandName="Select_Item" OnClientClick="false">选择项目</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnDelete_ExpApp" runat="server" CommandName="Delete_ExpApp"
                                        OnClientClick="return confirm('您确认删除该记录吗?')" CommandArgument='<%#Eval("ETA_ExpID")%>'>删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtn_AppAu" runat="server" CommandArgument='<%#Eval("ETA_ExpID")%>'
                                        CommandName="AppAu" OnClientClick="false">审核</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtn_AppAck" runat="server" CommandArgument='<%#Eval("ETA_ExpID")%>'
                                        CommandName="AppAck" OnClientClick="false">接收</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtn_AppRes" runat="server" CommandArgument='<%#Eval("ETA_ExpID")%>'
                                        CommandName="AppRes" OnClientClick="false">录入</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtn_AppArl" runat="server" CommandArgument='<%#Eval("ETA_ExpID")%>'
                                        CommandName="AppArl" OnClientClick="false">审批</asp:LinkButton>
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
    <asp:UpdatePanel ID="UpdatePanel_NewExpApp" runat="server" UpdateMode="Conditional">
        <%--<Triggers>
            <asp:AsyncPostBackTrigger ControlID="Btn_NEW_NETItem" />
        </Triggers>--%>
        <ContentTemplate>
            <asp:Panel ID="Panel_NewExpApp" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="LblExpApp" runat="server" CssClass="STYLE2" Text=""></asp:Label>
                    </legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label1" runat="server" CssClass="STYLE2" Text="产品标识:"></asp:Label>
                                <asp:Label ID="LblState" runat="server" Text="Label" Visible="False"></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:TextBox ID="TxtNewProIdentify" runat="server" Width="150px" MaxLength="20">
                                </asp:TextBox><asp:Label ID="Label22" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label3" runat="server" CssClass="STYLE2" Text="样品总数:"></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:TextBox ID="TxtNewSamNum" runat="server" Width="150px" onkeyup="this.value=this.value.replace(/\D/g,'')"
                                    onafterpaste="this.value=this.value.replace(/\D/g,'')"  MaxLength="12"></asp:TextBox>
                                <asp:Label ID="Label23" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label7" runat="server" CssClass="STYLE2" Text="单位:"></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:TextBox ID="TxtNewUnits" runat="server" Width="150px" MaxLength="5"></asp:TextBox>
                                <asp:Label ID="Label44" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label8" runat="server" CssClass="STYLE2" Text="申请人:"></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:TextBox ID="TxtNewAppPer" runat="server" Width="150px" Enabled="false" MaxLength="10"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label11" runat="server" CssClass="STYLE2" Text="申请部门:"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:DropDownList ID="DdlAppDep" runat="server" ToolTip="单击选择">
                                </asp:DropDownList>
                                <asp:Label ID="Label47" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label9" runat="server" CssClass="STYLE2" Text="紧急程度:"></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:DropDownList ID="DdlNewEmergDegree" runat="server" ToolTip="单击选择">
                                    <asp:ListItem Value="0" Selected="True">请选择</asp:ListItem>
                                    <asp:ListItem Value="1">一般</asp:ListItem>
                                    <asp:ListItem Value="2">紧急</asp:ListItem>
                                </asp:DropDownList>
                                <asp:Label ID="Label48" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label12" runat="server" CssClass="STYLE2" Text="样品类型:"></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:DropDownList ID="DdlSampleType" runat="server" ToolTip="单击选择">
                                </asp:DropDownList>
                                <asp:Label ID="Label49" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <asp:Label ID="Lbl_ETA_ExpID" runat="server" CssClass="STYLE2" Text="" Visible="false"></asp:Label>
                            </td>
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label10" runat="server" CssClass="STYLE2" Text="申请单编号:"></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:TextBox ID="TxtExpAppNO" runat="server" Width="150px" Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label14" runat="server" CssClass="STYLE2" Text="申请备注:"></asp:Label>
                                <br>
                                <asp:Label ID="Label39" runat="server" CssClass="STYLE2" Text="(200字以内)"></asp:Label>
                            </td>
                            <td style="width: 20%" colspan="5" align="left">
                                <asp:TextBox ID="TxtRemaks" runat="server" Width="95%" MaxLength="200" Style="overflow: hidden;"
                                    Height="56px" TextMode="MultiLine" onkeyup="this.value = this.value.substring(0, 200)" 
                                    onafterpaste="this.value = this.value.substring(0, 200)"></asp:TextBox>
                                <br />
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td colspan="2" align="right">
                                <asp:Button ID="BtnSave" runat="server" Text="保存" CssClass="Button02" Height="24px"
                                    Width="70px" OnClick="BtnSave_Click" />
                            </td>
                            <td colspan="2" align="center">
                                <%--<asp:Button ID="BtnSubmit" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    Width="70px"  OnClick="BtnSubmit_Click" />--%>
                            </td>
                            <td colspan="2" align="left">
                                <asp:Button ID="BtnClose" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    Visible="true" Width="70px" OnClick="BtnClose_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_ItemResEdit" runat="server" UpdateMode="Conditional">
        <%--<Triggers>
            <asp:AsyncPostBackTrigger ControlID="Btn_NEW_NETItem" />
        </Triggers>--%>
        <ContentTemplate>
            <asp:Panel ID="Panel_ItemResEdit" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="LblItemResEdit" runat="server" CssClass="STYLE2" Text=""></asp:Label></legend>
                    <table style="width: 100%;">
                    <tr >
                    <td colspan="6">
                    <asp:GridView ID="Grid_ETTestItem" runat="server" DataKeyNames="EIR_ResDetailID" AllowSorting="True"
                                    AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                                    Visible="true" GridLines="None" AllowPaging="True" Font-Strikeout="False" UseAccessibleHeader="False"
                                    OnPageIndexChanging="Grid_ETTestItem_PageIndexChanging"
                                    OnRowCommand="Grid_ETTestItem_RowCommand"  OnRowUpdating="Grid_ETTestItem_Updating"
                                    OnRowEditing="Grid_ETTestItem_Editing"    onrowdatabound="Grid_ETTestItem_RowDataBound"
                                    OnRowCancelingEdit="Grid_ETTestItem_CancelingEdit" 
                                    OnDataBound="Grid_ETTestItem_DataBound" PageSize="5">
                                    <RowStyle CssClass="GridViewRowStyle" />
                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                    <HeaderStyle CssClass="GridViewHead" />
                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                    <Columns>
                                        <asp:BoundField DataField="EI_ExpItemID" HeaderText="实验项目ID" ReadOnly="True" SortExpression="EI_ExpItemID"
                                            Visible="false">
                                            <ItemStyle />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ETA_ExpID" HeaderText="实验测试申请ID" ReadOnly="True" SortExpression="ETA_ExpID"
                                            Visible="false"></asp:BoundField>
                                        <asp:BoundField DataField="EIR_ResDetailID" HeaderText="实验项目结果ID" ReadOnly="True"
                                            SortExpression="EIR_ResDetailID" Visible="false"></asp:BoundField>
                                        <asp:BoundField DataField="EI_ExpItem" SortExpression="EI_ExpItem" HeaderText="测试项目"
                                            ReadOnly="True">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="EI_ExpCondtition" SortExpression="EI_ExpCondtition" HeaderText="测试条件"
                                            ReadOnly="True">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="EI_ExpMethold" SortExpression="EI_ExpMethold" HeaderText="实验方法"
                                            ReadOnly="True">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="EIR_ItemAmount" SortExpression="EIR_ItemAmount" HeaderText="测试数量" >
                                        </asp:BoundField>
                                        <asp:BoundField DataField="EIR_ItemAcceptance" SortExpression="EIR_ItemAcceptance"
                                            HeaderText="合格数量">
                                        </asp:BoundField>
                                       <%-- <asp:BoundField DataField="EIR_ItemRes" SortExpression="EIR_ItemRes" HeaderText="判定">
                                        </asp:BoundField>--%>
                                        <asp:TemplateField SortExpression="EIR_ItemRes" HeaderText="判定">
                                            <ItemTemplate>
                                                <asp:Label ID="EIR_ItemRes1" runat="server" Text='<%# Eval("EIR_ItemRes") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:HiddenField ID="HF1" runat="server" Value='<%# Eval("EIR_ItemRes") %>' />
                                                <asp:DropDownList ID="DropDownList5" runat="server" Height="20px">
                                                    <asp:ListItem Text="合格" Value="合格"></asp:ListItem>
                                                    <asp:ListItem Text="不合格" Value="不合格"></asp:ListItem>
                                                </asp:DropDownList>
                                            </EditItemTemplate>
                                            <ItemStyle/>
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="EIR_Remaks" SortExpression="EIR_Remaks" HeaderText="备注">
                                        </asp:BoundField>
                            <asp:CommandField ShowEditButton="True" EditText="编辑" UpdateText="提交" CancelText="取消">
                            </asp:CommandField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbtnDelete_ExpItem" runat="server" CommandName="Delete_ExpItem"
                                                    OnClientClick="return confirm('您确认删除该记录吗?')" CommandArgument='<%#Eval("EIR_ResDetailID")%>'>删除</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerTemplate>
                                        <table width="100%">
                                            <tr>
                                                <td style="text-align: right">
                                                    第&nbsp;<asp:Label ID="lblPageIndex" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>' />
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
                                </td>
                    </tr>
                        <tr >
                            <td width="5%">
                                <asp:Label ID="LblItemRes" runat="server" CssClass="STYLE2" Text="Amount" Visible="false"></asp:Label>
                            </td>
                            <td width="30%" align="right">
                                <asp:Button ID="BtnItemResSubmit" runat="server" Text="完成实验申请" 
                                    CssClass="Button02" Height="24px"
                                    Width="110px" OnClick="BtnItemResSubmit_Click" />
                                    <asp:Button ID="Btn_ItemResSubmit1" runat="server" Text="录入最终结果" 
                                    CssClass="Button02" Height="24px"
                                    Width="110px" OnClick="Btn_ItemResSubmit1_Click" />
                            </td>
                            <td width="30%" align="center">
                               
                            </td>
                            <td width="30%" align="left">
                                <asp:Button ID="BtnItemResCancel" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    Visible="true" Width="70px" OnClick="BtnItemResCancel_Click" />
                            </td>
                            <td  width="5%">
                                <asp:Label ID="LblLuruRes_ID" runat="server" CssClass="STYLE2" Text="" Visible="false"></asp:Label>
                                <asp:Label ID="LblSelect_ID" runat="server" CssClass="STYLE2" Text="" Visible="false"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_ViewExp" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_ViewExp" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="Lbl_ViewExp" runat="server" CssClass="STYLE2" Text=""></asp:Label>
                    </legend>
                    <table style="width: 100%;">        
                        <tr>
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label29" runat="server" CssClass="STYLE2" Text="审核人:" Visible="true"></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:TextBox ID="TxtAuditor" runat="server" Width="150px" Visible="true" Enabled="False"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label30" runat="server" CssClass="STYLE2" Text="审核时间:" Visible="true"></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:TextBox ID="TxtAuTime" runat="server" Width="150px" Visible="true" Enabled="False"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label31" runat="server" CssClass="STYLE2" Text="审核结果:" Visible="true"></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:TextBox ID="TxtAuRes" runat="server" Width="150px" Visible="true" Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label32" runat="server" CssClass="STYLE2" Text="审核意见:" Visible="true"></asp:Label>
                                <br>
                                <asp:Label ID="Label41" runat="server" CssClass="STYLE2" Text="(200字以内)" Visible="true"></asp:Label>
                            </td>
                            <td style="width: 80%" colspan="5" align="left">
                                <asp:TextBox ID="TxtAuSugg1" runat="server" Width="95%" MaxLength="200" Visible="true"
                                    Style="overflow: hidden;" TextMode="MultiLine" Height="56px" Enabled="False" onkeyup="this.value = this.value.substring(0, 200)" 
                                    onafterpaste="this.value = this.value.substring(0, 200)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label33" runat="server" CssClass="STYLE2" Text="接收人:" Visible="true"></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:TextBox ID="TxtAckPer" runat="server" Width="150px" Visible="true" Enabled="False"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label34" runat="server" CssClass="STYLE2" Text="接收时间:" Visible="true"></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:TextBox ID="TxtAckTime" runat="server" Width="150px" Visible="true" Enabled="False"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label35" runat="server" CssClass="STYLE2" Text="预计完成时间:" Visible="true"></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:TextBox ID="TxtEstimateT1" runat="server" Width="150px" Visible="true" Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label26" runat="server" CssClass="STYLE2" Text="实验人:" Visible="true"></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:TextBox ID="TxtExpPer" runat="server" Width="150px" MaxLength="10" Visible="true" Enabled="False"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label27" runat="server" CssClass="STYLE2" Text="实验结果:" Visible="true"></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:TextBox ID="TxtExpRes" runat="server" Width="150px" MaxLength="10" Visible="true" Enabled="False"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label36" runat="server" CssClass="STYLE2" Text="完成时间:" Visible="true"></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:TextBox ID="TxtActFinishT" runat="server" Width="150px" Visible="true" Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label28" runat="server" CssClass="STYLE2" Text="结果说明:" Visible="true"></asp:Label>
                                <br>
                                <asp:Label ID="Label42" runat="server" CssClass="STYLE2" Text="(200字以内)"></asp:Label>
                            </td>
                            <td style="width: 80%" colspan="5" align="left">
                                <asp:TextBox ID="TxtResInstruction" runat="server" Width="95%"  Visible="true" Enabled="False" MaxLength="200" Style="overflow: hidden;"
                                    TextMode="MultiLine" Height="56px"  onkeyup="this.value = this.value.substring(0, 200)" 
                                    onafterpaste="this.value = this.value.substring(0, 200)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label37" runat="server" CssClass="STYLE2" Text="审批人:" Visible="true"></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:TextBox ID="TxtApprover" runat="server" Width="150px" Visible="true" Enabled="False"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label38" runat="server" CssClass="STYLE2" Text="审批时间:" Visible="true"></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:TextBox ID="TxtApprovalT1" runat="server" Width="150px" Visible="true" Enabled="False"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label52" runat="server" CssClass="STYLE2" Text="审批结果:" Visible="true"></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:TextBox ID="TxtApprovalRes1" runat="server" Width="150px" Visible="true" Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label40" runat="server" CssClass="STYLE2" Text="审批意见:" Visible="true"></asp:Label>
                                <br>
                                <asp:Label ID="Label43" runat="server" CssClass="STYLE2" Text="(200字以内)" Visible="true"></asp:Label>
                            </td>
                            <td style="width: 80%" colspan="5" align="left">
                                <asp:TextBox ID="TxtApprovalSugg1" runat="server" Width="95%" MaxLength="200" Visible="true"
                                    Style="overflow: hidden;" TextMode="MultiLine" Height="56px" Enabled="False" onkeyup="this.value = this.value.substring(0, 200)" 
                                    onafterpaste="this.value = this.value.substring(0, 200)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 16px;">                            
                            <td colspan="6" align="center">
                            <asp:Button ID="Btn_CloseView" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    Visible="true" Width="70px" OnClick="Btn_CloseView_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_LastRes" runat="server" UpdateMode="Conditional">
        <%--<Triggers>
            <asp:AsyncPostBackTrigger ControlID="Btn_NEW_NETItem" />
        </Triggers>--%>
        <ContentTemplate>
            <asp:Panel ID="Panel_LastRes" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="Lbl_LastRes" runat="server" CssClass="STYLE2" Text=""></asp:Label></legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label19" runat="server" CssClass="STYLE2" Text="实验结果:"></asp:Label>
                            </td>
                            <td style="width: 30%" align="left">
                                <asp:TextBox ID="Txt_ExpRes" runat="server" Width="90%" MaxLength="10" ></asp:TextBox>
                                <asp:Label ID="Label50" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                            <td style="width: 5%" align="left">
                            </td>
                            <td style="width: 30%" align="left">
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label13" runat="server" CssClass="STYLE2" Text="结果说明:" Visible="true"></asp:Label>
                                <br>
                                <asp:Label ID="Label21" runat="server" CssClass="STYLE2" Text="(200字以内)"></asp:Label>
                            </td>
                            <td style="width: 80%" colspan="3" align="left">
                                <asp:TextBox ID="Txt_ResInstruction" runat="server" Width="95%"  Visible="true" MaxLength="200" Style="overflow: hidden;"
                                    TextMode="MultiLine" Height="56px"  onkeyup="this.value = this.value.substring(0, 200)" 
                                    onafterpaste="this.value = this.value.substring(0, 200)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td style="width: 20%" align="right">
                                <asp:Button ID="Btn_LastResSubmit" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    Width="70px" OnClick="Btn_LastResSubmit_Click" />
                            </td>
                            <td align="center" style="width: 30%">
                            </td>
                            <td align="left" style="width: 30%">
                                <asp:Button ID="Btn_LastResClose" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    Width="70px" OnClick="Btn_LastResClose_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_AppAu" runat="server" UpdateMode="Conditional">
        <%--<Triggers>
            <asp:AsyncPostBackTrigger ControlID="Btn_NEW_NETItem" />
        </Triggers>--%>
        <ContentTemplate>
            <asp:Panel ID="Panel_AppAu" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="LblAppAu" runat="server" CssClass="STYLE2" Text=""></asp:Label></legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label20" runat="server" CssClass="STYLE2" Text="审核意见:"></asp:Label>
                                <br>
                                <asp:Label ID="Label45" runat="server" CssClass="STYLE2" Text="(200字以内)"></asp:Label>
                            </td>
                            <td style="width: 90%" colspan="3" align="left">
                                <asp:TextBox ID="TxtAuSugg" runat="server" Width="95%" MaxLength="200" Style="overflow: hidden;"
                                    TextMode="MultiLine" Height="56px"  onkeyup="this.value = this.value.substring(0, 200)" 
                                    onafterpaste="this.value = this.value.substring(0, 200)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td style="width: 20%" align="right">
                                <asp:Button ID="BtnAuPass" runat="server" Text="通过" CssClass="Button02" Height="24px"
                                    Width="70px" OnClick="BtnAuPass_Click" />
                            </td>
                            <td align="center" style="width: 40%">
                                <asp:Button ID="BtnAuReject" runat="server" Text="驳回" CssClass="Button02" Height="24px"
                                    Width="70px" OnClick="BtnAuReject_Click" />
                            </td>
                            <td align="left" style="width: 30%">
                                <asp:Button ID="BtnAuCancle" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    Width="70px" OnClick="BtnAuCancle_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    
    <asp:UpdatePanel ID="UpdatePanel_AppAck" runat="server" UpdateMode="Conditional">
        <%--<Triggers>
            <asp:AsyncPostBackTrigger ControlID="Btn_NEW_NETItem" />
        </Triggers>--%>
        <ContentTemplate>
            <asp:Panel ID="Panel_AppAck" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="LblAppAck" runat="server" CssClass="STYLE2" Text=""></asp:Label></legend>
                    <table style="width: 100%;">
                        <tr >
                            <td style="width: 20%" align="right">
                                <asp:Label ID="Label24" runat="server" Text="预计完成时间:"></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
                                <asp:TextBox ID="TxtEstimateT" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"></asp:TextBox>
                                <asp:Label ID="Label51" runat="server" ForeColor="Red" Text="*"></asp:Label>
                            </td>
                            <td style="width: 30%" align="center">
                                <asp:Button ID="BtnAppAck" runat="server" Text="接收" CssClass="Button02" Height="24px"
                                    Width="70px" OnClick="BtnAppAck_Click" />
                            </td>
                            <td align="left" style="width: 30%">
                                <asp:Button ID="BtnAckCancel" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    Width="70px" OnClick="BtnAckCancel_Click" />
                            </td>
                        </tr>
                        
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    
    <asp:UpdatePanel ID="UpdatePanel_AppArl" runat="server" UpdateMode="Conditional">
        <%--<Triggers>
            <asp:AsyncPostBackTrigger ControlID="Btn_NEW_NETItem" />
        </Triggers>--%>
        <ContentTemplate>
            <asp:Panel ID="Panel_AppArl" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="LblAppArl" runat="server" CssClass="STYLE2" Text=""></asp:Label></legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label25" runat="server" CssClass="STYLE2" Text="审批意见:"></asp:Label>
                                <br>
                                <asp:Label ID="Label46" runat="server" CssClass="STYLE2" Text="(200字以内)"></asp:Label>
                            </td>
                            <td style="width: 90%" colspan="3" align="left">
                                <asp:TextBox ID="TxtApprovalSugg" runat="server" Width="95%" MaxLength="200" Style="overflow: hidden;"
                                    TextMode="MultiLine" Height="56px" onkeyup="this.value = this.value.substring(0, 200)" 
                                    onafterpaste="this.value = this.value.substring(0, 200)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td style="width: 20%" align="right">
                                <asp:Button ID="BtnArlSubmit" runat="server" Text="通过" CssClass="Button02" Height="24px"
                                    Width="70px" OnClick="BtnArlSubmit_Click" />
                            </td>
                            <td align="center" style="width: 40%">
                            <asp:Button ID="BtnArReject" runat="server" Text="驳回" CssClass="Button02" Height="24px"
                                    Width="70px" OnClick="BtnArReject_Click" />
                            </td>
                            <td align="left" style="width: 30%">
                                <asp:Button ID="BtnArlCancel" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    Width="70px" OnClick="BtnArlCancel_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    
    <asp:UpdatePanel ID="UpdatePanel_SearchItem" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_SearchItem" runat="server" Visible="false">
                <fieldset>
                    <legend>检索实验项目</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 9%" align="right">
                                <asp:Label ID="Label15" runat="server" CssClass="STYLE2" Text="测试项目:"></asp:Label>
                            </td>
                            <td style="width: 18%" align="left">
                                <asp:TextBox ID="TxtSearchItem" runat="server" Width="90%"></asp:TextBox>
                            </td>
                            <td style="width: 9%" align="right">
                                <asp:Label ID="Label17" runat="server" CssClass="STYLE2" Text="测试条件:"></asp:Label>
                            </td>
                            <td style="width: 18%" align="left">
                                <asp:TextBox ID="TxtSearchCondition" runat="server" Width="90%"></asp:TextBox>
                            </td>
                            <td style="width: 9%" align="right">
                                <asp:Label ID="Label18" runat="server" CssClass="STYLE2" Text="测试方法:"></asp:Label>
                            </td>
                            <td style="width: 18%" align="left">
                                <asp:TextBox ID="TxtSearchMethod" runat="server" Width="90%"></asp:TextBox>
                            </td>
                            <td style="width: 9%">
                                <asp:Button ID="BtnSearchItem" runat="server" CssClass="Button02" Height="24px" OnClick="BtnSearchItem_Click"
                                    Text="检索" Width="70px" />
                            </td>
                        </tr>
                        <tr>
                        <td style="width: 100%" colspan="7">
                                <asp:GridView ID="GridView_SelectItem" runat="server" DataKeyNames="EI_ExpItemID"
                                    AllowSorting="True" AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0"
                                    Width="100%" Visible="true" GridLines="None" AllowPaging="True" PageSize="5"
                                    Font-Strikeout="False" UseAccessibleHeader="False" 
                                    OnPageIndexChanging="Grid_SelectItem_PageIndexChanging" OnRowCommand="Grid_SelectItem_RowCommand"
                                    OnDataBound="GridView_SelectItem_DataBound">
                                    <RowStyle CssClass="GridViewRowStyle" />
                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                    <HeaderStyle CssClass="GridViewHead" />
                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                    <Columns>
                                        <asp:BoundField DataField="EI_ExpItemID" HeaderText="实验项目ID" ReadOnly="True" SortExpression="EI_ExpItemID"
                                            Visible="false">
                                            <ItemStyle />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="EI_ExpItem" SortExpression="EI_ExpItem" HeaderText="测试项目">
                                            <HeaderStyle />
                                            <ItemStyle/>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="EI_ExpCondtition" SortExpression="EI_ExpCondtition" HeaderText="测试条件">
                                            <HeaderStyle />
                                            <ItemStyle />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="EI_ExpMethold" SortExpression="EI_ExpMethold" HeaderText="实验方法">
                                            <HeaderStyle />
                                            <ItemStyle />
                                        </asp:BoundField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbtnChoose_Item" runat="server" CommandArgument='<%#Eval("EI_ExpItemID")%>'
                                                    CommandName="Choose_Item" OnClientClick="false">选择</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerTemplate>
                                        <table width="100%">
                                            <tr>
                                                <td style="text-align: right">
                                                    第&nbsp;<asp:Label ID="lblPageIndex" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>' />
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
                                <table style="width: 100%; text-align: center;" class="STYLE2">
                                    <tr>
                                        <td align="center">
                                            <asp:Button ID="BtnCloseItem" runat="server" CssClass="Button02" Text="关闭" OnClick="BtnCloseItem_Click"
                                                Width="70px" Height="24px"/>
                                        </td>
                                </table>
                                </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
