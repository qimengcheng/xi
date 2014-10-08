<%@ Page Title="安排培训计划" Language="C#" MasterPageFile="~/Other/MasterPage.master"
    AutoEventWireup="true" CodeFile="TrainningMonthPlan.aspx.cs" Inherits="TrainningMgt_TrainningMonthPlan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <style type="text/css">
        .hidden
        {
            display: none;
        }
        .style1
        {
            width: 10%;
            height: 16px;
        }
        .style2
        {
            width: 20%;
            height: 16px;
        }
    </style>
    <script type="text/javascript">
        var last = null;
        function judge1(obj) {
            if (last == null) {
                last = obj.id;
            }
            else {
                var lo = document.getElementById(last);
                lo.checked = false;
                last = obj.id;

            }
            obj.checked = "checked";
        }
    </script>
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server">
                <fieldset>
                    <legend>检索栏</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label2" runat="server" CssClass="STYLE2" Text="年份："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:DropDownList ID="DdlSYears" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label1" runat="server" CssClass="STYLE2" Text="月份："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:DropDownList ID="DdlSMonth" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label13" runat="server" CssClass="STYLE2" Text="培训类型："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:DropDownList ID="DdlSMonthPlanType" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="LblStartTime" runat="server" CssClass="STYLE2" Text="培训项目："></asp:Label>
                            </td>
                            <td style="height: 20%;" align="left">
                                <asp:TextBox ID="TxtSItem" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label9" runat="server" CssClass="STYLE2" Text="培训对象："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtSTarget" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label3" runat="server" CssClass="STYLE2" Text="培训地点："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtSPlace" runat="server" Width="130px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" class="style1">
                                <asp:Label ID="Label4" runat="server" CssClass="STYLE2" Text="培训学时："></asp:Label>
                            </td>
                            <td class="style2">
                                <asp:TextBox ID="TxtSHours" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td align="center" class="style1">
                                <asp:Label ID="Label5" runat="server" CssClass="STYLE2" Text="培训讲师："></asp:Label>
                            </td>
                            <td class="style2">
                                <asp:TextBox ID="TxtSTeacher" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td align="center" class="style1">
                                <asp:Label ID="Label53" runat="server" CssClass="STYLE2" Text="状态："></asp:Label>
                            </td>
                            <td class="style2">
                                <asp:DropDownList ID="DropDownList3" runat="server">
                                    <asp:ListItem>请选择</asp:ListItem>
                                    <asp:ListItem>待完善</asp:ListItem>
                                    <asp:ListItem>已提交</asp:ListItem>
                                    <asp:ListItem>已完成</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label54" runat="server" CssClass="STYLE2" Text="成绩录入人："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TextBox8" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label55" runat="server" CssClass="STYLE2" Text="培训时间："></asp:Label>
                            </td>
                            <td style="width: 20%" colspan="3">
                                <asp:TextBox ID="TextBox11" runat="server" Width="130px" onfocus="new  WdatePicker(this,'%Y-%M-%D',false)"></asp:TextBox>至<asp:TextBox
                                    ID="TextBox12" runat="server" Width="130px" onfocus="new  WdatePicker(this,'%Y-%M-%D',false)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label57" runat="server" CssClass="STYLE2" Text="是否年计划外："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:DropDownList ID="DropDownList6" runat="server">
                                    <asp:ListItem>请选择</asp:ListItem>
                                    <asp:ListItem>是</asp:ListItem>
                                    <asp:ListItem>否</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td align="right" colspan="2">
                                <asp:Label ID="LblRecordIsSearch" runat="server" Text="检索前" Visible="false"></asp:Label>
                                <asp:Button ID="BtnSearch" runat="server" CssClass="Button02" Height="24px" Text="检索"
                                    Width="70px" OnClick="BtnSearch_Click" />
                            </td>
                            <td align="center" colspan="2">
                                <asp:Button ID="BtnNew" runat="server" CssClass="Button02" Height="24px" Text="插入年计划外的项目"
                                    Width="130px" OnClick="BtnNew_Click1" />
                            </td>
                            <td align="left" colspan="2">
                                <asp:Button ID="BtnReset" runat="server" CssClass="Button02" Height="24px" Text="重置"
                                    Visible="true" Width="70px" TabIndex="2" OnClick="BtnReset_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel2" runat="server">
                <fieldset>
                    <legend>培训项目详情列表<asp:Label ID="Label_ttdid" runat="server" Visible="False"></asp:Label></legend>
                    <asp:GridView ID="GridTrainingItemDetail" runat="server" DataKeyNames="TID_ID,TID_ResourceRoute"
                        AllowSorting="True" AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0"
                        Width="100%" AllowPaging="True" PageSize="10" Font-Strikeout="False" GridLines="None"
                        UseAccessibleHeader="False" OnDataBound="GridTrainingItemDetail_DataBound" OnPageIndexChanging="GridTrainingItemDetail_PageIndexChanging"
                        OnRowCommand="GridTrainingItemDetail_RowCommand" OnRowDataBound="GridTrainingItemDetail_RowDataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="TID_ID" HeaderText="培训项目明细ID" SortExpression="TID_ID"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="TYPM_ID" HeaderText="年计划ID" SortExpression="TYPM_ID">
                                <FooterStyle CssClass="hidden" />
                                <HeaderStyle CssClass="hidden" />
                                <ItemStyle CssClass="hidden" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TYPM_Year" HeaderText="年份" SortExpression="TYPM_Year">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="TID_Month" HeaderText="月份" SortExpression="TID_Month">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="TTT_Type" HeaderText="培训类型" SortExpression="TTT_Type">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="TID_TLesson" HeaderText="培训项目" SortExpression="TID_TLesson">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="TID_Target" HeaderText="培训对象" SortExpression="TID_Target">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="TID_Teacher" HeaderText="讲师" SortExpression="TID_Teacher">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="TID_State" HeaderText="状态" SortExpression="TID_State">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="TID_PTime" HeaderText="培训开始时间" SortExpression="TID_PTime">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="TID_ActTime" HeaderText="培训结束时间" SortExpression="TID_ActTime">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="TID_Place" HeaderText="培训地点" SortExpression="TID_Place">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="TID_CreditHours" HeaderText="培训学时" SortExpression="TID_CreditHours">
                               <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="UMUI_UserName" HeaderText="成绩录入人" SortExpression="UMUI_UserName">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="TID_InputTime" HeaderText="成绩录入时间" SortExpression="TID_InputTime">
                                <FooterStyle CssClass="hidden" />
                                <HeaderStyle CssClass="hidden" />
                                <ItemStyle CssClass="hidden" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BDOS_Name" HeaderText="负责部门" SortExpression="BDOS_Name">
                                <FooterStyle CssClass="hidden" />
                                <HeaderStyle CssClass="hidden" />
                                <ItemStyle CssClass="hidden" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TID_IsCha" HeaderText="是否是年计划外的项目" SortExpression="TID_IsCha">
                                <%-- <FooterStyle CssClass="hidden" />
                                <HeaderStyle CssClass="hidden" />
                                <ItemStyle CssClass="hidden" />--%>
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnLookDetail" runat="server" CommandName="LookDetail" OnClientClick="false"
                                        CommandArgument='<%#Eval("TID_ID")+"^"+Eval("TYPM_ID")+"^"+Eval("TYPM_Year")+"^"+Eval("TID_Month")+"^"+Eval("TYPM_Year")+"^"+Eval("TTT_Type")+"^"+Eval("TID_TLesson")+"^"+Eval("TID_Target")+"^"+Eval("TID_Teacher")+"^"+Eval("TID_State")+"^"+Eval("TID_PTime")+"^"+Eval("TID_ActTime")+"^"+Eval("TID_Place")+"^"+Eval("TID_CreditHours")+"^"+Eval("UMUI_UserName")+"^"+Eval("TID_InputTime")+"^"+Eval("BDOS_Name")+"^"+Eval("TID_IsCha")%>'>查看详情</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnEditDetail" runat="server" CommandName="EditDetail" OnClientClick="false"
                                        CommandArgument='<%#Eval("TID_ID")+"^"+Eval("TYPM_ID")+"^"+Eval("TYPM_Year")+"^"+Eval("TID_Month")+"^"+Eval("TYPM_Year")+"^"+Eval("TTT_Type")+"^"+Eval("TID_TLesson")+"^"+Eval("TID_Target")+"^"+Eval("TID_Teacher")+"^"+Eval("TID_State")+"^"+Eval("TID_PTime")+"^"+Eval("TID_ActTime")+"^"+Eval("TID_Place")+"^"+Eval("TID_CreditHours")+"^"+Eval("UMUI_UserName")+"^"+Eval("TID_InputTime")+"^"+Eval("BDOS_Name")+"^"+Eval("TID_IsCha")%>'>完善</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnLookPerson" runat="server" CommandName="LookPerson" OnClientClick="false"
                                        CommandArgument='<%#Eval("TID_ID")%>'>查看培训员工</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnEditPerson" runat="server" CommandName="EditPerson" OnClientClick="false"
                                        CommandArgument='<%#Eval("TID_ID")%>'>编辑培训员工</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnSubimt" runat="server" CommandName="lbtnSubimt" OnClientClick="false"
                                        CommandArgument='<%#Eval("TID_ID")+"^"+Eval("TYPM_ID")+"^"+Eval("TYPM_Year")+"^"+Eval("TID_Month")+"^"+Eval("TYPM_Year")+"^"+Eval("TTT_Type")+"^"+Eval("TID_TLesson")+"^"+Eval("TID_Target")+"^"+Eval("TID_Teacher")+"^"+Eval("TID_State")+"^"+Eval("TID_PTime")+"^"+Eval("TID_ActTime")+"^"+Eval("TID_Place")+"^"+Eval("TID_CreditHours")+"^"+Eval("UMUI_UserName")+"^"+Eval("TID_InputTime")+"^"+Eval("BDOS_Name")+"^"+Eval("TID_IsCha")%>'>提交</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnDeleteDetail" runat="server" CommandName="DeleteDetail" OnClientClick="return confirm('您确认删除该记录吗?')"
                                        CommandArgument='<%#Eval("TID_ID")%>'>删除</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnScore" runat="server" CommandName="lbtnScore" OnClientClick="false"
                                        CommandArgument='<%#Eval("TID_ID")+"^"+Eval("TYPM_ID")+"^"+Eval("TYPM_Year")+"^"+Eval("TID_Month")+"^"+Eval("TYPM_Year")+"^"+Eval("TTT_Type")+"^"+Eval("TID_TLesson")+"^"+Eval("TID_Target")+"^"+Eval("TID_Teacher")+"^"+Eval("TID_State")+"^"+Eval("TID_PTime")+"^"+Eval("TID_ActTime")+"^"+Eval("TID_Place")+"^"+Eval("TID_CreditHours")+"^"+Eval("UMUI_UserName")+"^"+Eval("TID_InputTime")+"^"+Eval("BDOS_Name")+"^"+Eval("TID_IsCha")%>'>录入培训记录</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Up2" runat="server" CommandArgument='<%#Eval("TID_ID")+","+Eval("TID_ResourceRoute")%>'
                                        CommandName="Up2" OnClientClick="false">上传课件</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <%--<asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HyperLink ID="Down2" runat="server"  NavigateUrl='<%#"~/"+Eval("TID_ResourceRoute")+"?path={0}"%>' >下载课件</asp:HyperLink >
                                </ItemTemplate>
                                <ItemStyle/>
                            </asp:TemplateField>--%>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HyperLink ID="Down2" runat="server" NavigateUrl='<%#"~/"+Eval("TID_ResourceRoute")+"?path={0}"%>'>下载课件</asp:HyperLink>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <%--<asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Down2" runat="server" CommandName="Down2" 
                                        CommandArgument='<%#Eval("TID_ResourceRoute")%>'>下载课件</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>--%>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="EditDownload" runat="server" CommandName="EditDownload" OnClientClick="false"
                                        CommandArgument='<%#Eval("TID_ID")%>'>编辑课件</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete2" runat="server" CommandName="Delete2" OnClientClick="return confirm('您确认删除该次培训的课件吗?')"
                                        CommandArgument='<%#Eval("TID_ID")+","+Eval("TID_ResourceRoute")%>'>删除课件</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:BoundField DataField="TID_ResourceRoute" HeaderText="课件路径" ReadOnly="True" SortExpression="TID_ResourceRoute"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnLookResult" runat="server" CommandName="LookResult" OnClientClick="false"
                                        CommandArgument='<%#Eval("TID_ID")%>'>查看培训结果</asp:LinkButton>
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
                            <asp:Label ID="Label16" runat="server" Text="没有找到相关记录"></asp:Label>
                        </EmptyDataTemplate>
                        <EditRowStyle BackColor="white" />
                    </asp:GridView>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel3" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="Label18" runat="server" Text=""></asp:Label></legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label6" runat="server" CssClass="STYLE2" Text="年份："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:DropDownList ID="DdlInsertYear" runat="server">
                                </asp:DropDownList>
                                <asp:TextBox ID="TextBoxYear" Visible="false" runat="server" Width="130px" Enabled="False"></asp:TextBox>
                                <asp:Label ID="Label37" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DdlInsertYear"
                                    ErrorMessage="*" ValidationGroup="Info"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label7" runat="server" CssClass="STYLE2" Text="月份："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:DropDownList ID="DropDownList2" runat="server">
                                </asp:DropDownList>
                                <asp:Label ID="Label39" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DropDownList2"
                                    ErrorMessage="*" ValidationGroup="Info"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label8" runat="server" CssClass="STYLE2" Text="培训类型："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:DropDownList ID="DropDownListType" runat="server">
                                </asp:DropDownList>
                                <asp:Label ID="Label40" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DropDownListType"
                                    ErrorMessage="*" ValidationGroup="Info"></asp:RequiredFieldValidator>--%>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label10" runat="server" CssClass="STYLE2" Text="培训项目："></asp:Label>
                            </td>
                            <td style="height: 20%;" align="left">
                                <asp:TextBox ID="TextBox1" runat="server" Width="130px"></asp:TextBox>
                                <asp:Label ID="Label41" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox1"
                                    ErrorMessage="*" ValidationGroup="Info"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label11" runat="server" CssClass="STYLE2" Text="培训对象："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TextBox2" runat="server" Width="130px"></asp:TextBox>
                                <asp:Label ID="Label42" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox2"
                                    ErrorMessage="*" ValidationGroup="Info"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label33" runat="server" CssClass="STYLE2" Text="负责部门："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:DropDownList ID="DdlDep" runat="server">
                                </asp:DropDownList>
                                <asp:Label ID="Label43" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="DdlDep"
                                    ErrorMessage="*" ValidationGroup="Info"></asp:RequiredFieldValidator>--%>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label14" runat="server" CssClass="STYLE2" Text="培训学时："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TextBox4" runat="server" Width="130px" onkeyup="this.value=this.value.replace(/[^\d.]/g,'')"
                                    onafterpaste="this.value=this.value.replace(/[^\d.]/g,'')"></asp:TextBox>
                                <asp:Label ID="Label44" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBox4"
                                    ErrorMessage="*" ValidationGroup="Info"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label15" runat="server" CssClass="STYLE2" Text="培训讲师："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TextBox5" runat="server" Width="130px"></asp:TextBox>
                                <asp:Label ID="Label45" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TextBox5"
                                    ErrorMessage="*" ValidationGroup="Info"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label12" runat="server" CssClass="STYLE2" Text="培训地点："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TextBox3" runat="server" Width="130px"></asp:TextBox>
                                <asp:Label ID="Label47" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="TextBox3"
                                    ErrorMessage="*" ValidationGroup="Info"></asp:RequiredFieldValidator>--%>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label19" runat="server" CssClass="STYLE2" Text="培训开始时间："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TextBox6" runat="server" Width="130px" onfocus="new  WdatePicker(this,'%Y-%M-%D %h:%m:%s',true)"></asp:TextBox>
                                <asp:Label ID="Label46" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TextBox6"
                                    ErrorMessage="*" ValidationGroup="Info"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label20" runat="server" CssClass="STYLE2" Text="培训结束时间："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TextBox7" runat="server" Width="130px" onfocus="new  WdatePicker(this,'%Y-%M-%D %h:%m:%s',true)"></asp:TextBox>
                                <asp:Label ID="Label56" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <asp:Button ID="Button1" Visible="false" runat="server" CssClass="Button02" Height="24px"
                                    Width="40px" Text="选择..." OnClick="Button1_Click" />
                                <asp:Label ID="Label48" Visible="false" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="TextBox7"
                                    ErrorMessage="*" ValidationGroup="Info"></asp:RequiredFieldValidator>--%>
                            </td>
                            </td>
                            <td style="width: 10%" align="center">
                            </td>
                            <td style="width: 20%">
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td align="right" colspan="2">
                                <asp:Label ID="Label17" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Button ID="Button3" runat="server" CssClass="Button02" Height="24px" Text="保存"
                                    Width="70px" OnClick="Button3_Click" ValidationGroup="Info" />
                            </td>
                            <td align="center" colspan="2">
                                <asp:Label ID="LblRecordPeopleID" runat="server" Text="" Visible="false"></asp:Label>
                            </td>
                            <td align="left" colspan="2">
                                <asp:Button ID="Button4" runat="server" CssClass="Button02" Height="24px" Text="关闭"
                                    Visible="true" Width="70px" TabIndex="2" OnClick="Button4_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel4" runat="server" Visible="false">
                <fieldset>
                    <legend>指定培训结果的录入人</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label21" runat="server" CssClass="STYLE2" Text="账号："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtAddStaffNO" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label22" runat="server" CssClass="STYLE2" Text="姓名："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtAddName" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label23" runat="server" CssClass="STYLE2" Text="部门："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:DropDownList ID="DropDownList4" runat="server" ToolTip="单击选择" AutoPostBack="true">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="right" colspan="2">
                                <asp:Label ID="LblRecordID1" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Label ID="Label24" runat="server" Text="检索前" Visible="false"></asp:Label>
                                <asp:Button ID="BtnSearchPeopleOut" runat="server" CssClass="Button02" Height="24px"
                                    Text="检索" Width="70px" OnClick="BtnSearchPeopleOut_Click" />
                            </td>
                            <td colspan="2">
                            </td>
                            <td align="left" colspan="2">
                                <asp:Button ID="BtnResetPeopleOut" runat="server" CssClass="Button02" Height="24px"
                                    Width="70px" Text="重置" OnClick="BtnResetPeopleOut_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <fieldset>
                                    <legend>成绩录入人列表</legend>
                                    <asp:GridView ID="GridView_Teacher" runat="server" DataKeyNames="UMUI_UserID" AllowSorting="True"
                                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                                        AllowPaging="True" PageSize="10" Font-Strikeout="False" UseAccessibleHeader="False"
                                        GridLines="None" OnPageIndexChanging="GridView_Teacher_PageIndexChanging" OnRowDataBound="GridView_Teacher_RowDataBound">
                                        <RowStyle CssClass="GridViewRowStyle" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                        <HeaderStyle CssClass="GridViewHead" />
                                        <FooterStyle CssClass="GridViewFooterStyle" />
                                        <Columns>
                                            <asp:BoundField DataField="UMUI_UserID" HeaderText="账号" SortExpression="UMUI_UserID">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="UMUI_UserName" HeaderText="姓名" SortExpression="UMUI_UserName">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="BDOS_Name" HeaderText="部门" SortExpression="BDOS_Name">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:RadioButton ID="RadioButtonMarkup" runat="server" />
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerTemplate>
                                            <table width="100%">
                                                <tr>
                                                    <td style="text-align: right">
                                                        第&nbsp<asp:Label ID="lblPageIndex" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>' />
                                                        页 共&nbsp<asp:Label ID="lblPageCount" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />
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
                                            <asp:Label ID="Label16" runat="server" Text="找不到该员工，请核实其是否有培训成绩录入的权限" Font-Strikeout="True"></asp:Label>
                                        </EmptyDataTemplate>
                                        <EditRowStyle BackColor="white" />
                                    </asp:GridView>
                                </fieldset>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="right" colspan="2">
                                <asp:Button ID="Button2" runat="server" CssClass="Button02" Height="24px" Text="提交"
                                    Width="70px" OnClick="Button2_Click" />
                            </td>
                            <td style="width: 10%" align="right" colspan="2">
                            </td>
                            <td align="left" colspan="2">
                                <asp:Button ID="BtnAddSubmit" runat="server" CssClass="Button02" Height="24px" Text="关闭"
                                    Width="70px" OnClick="BtnAddSubmit_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_SearchEmployee" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="DdlSearchDep" />
        </Triggers>
        <ContentTemplate>
            <asp:Panel ID="Panel_SearchEmployee" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="LblTheSet2" runat="server" Text="" Visible="false"></asp:Label>&nbsp
                        员工信息栏</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label29" runat="server" CssClass="STYLE2" Text="工号：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TxtSearchStaffNO" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label30" runat="server" CssClass="STYLE2" Text="姓名：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TxtSearchName" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label31" runat="server" CssClass="STYLE2" Text="部门：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:DropDownList ID="DdlSearchDep" runat="server" ToolTip="单击选择" AutoPostBack="true"
                                    OnSelectedIndexChanged="DdlSearchDep_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label32" runat="server" CssClass="STYLE2" Text="岗位：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:DropDownList ID="DdlSearchPost" runat="server" ToolTip="单击选择">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" align="right">
                                <asp:Label ID="LblBindTID_ID" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Button ID="BtnSearchEmployee" runat="server" CssClass="Button02" Height="24px"
                                    Text="检索" Width="70px" OnClick="BtnSearchEmployee_Click" />
                            </td>
                            <td colspan="2" align="center">
                                <asp:Button ID="BtnAddEmployee" runat="server" CssClass="Button02" Height="24px"
                                    Width="70px" Text="新增员工" OnClick="BtnAddEmployee_Click" />
                            </td>
                            <td colspan="3" align="left">
                                <asp:Button ID="BtnResetEmployee" runat="server" CssClass="Button02" Height="24px"
                                    Width="70px" Text="重置" OnClick="BtnResetEmployee_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="8">
                                <fieldset>
                                    <legend>属于该次培训的员工列表</legend>
                                    <asp:GridView ID="Grid_Detail" runat="server" DataKeyNames="TEER_ID" AllowSorting="True"
                                        AutoGenerateColumns="False" CssClass="GridViewStyle" Width="100%" AllowPaging="True"
                                        PageSize="10" GridLines="None" OnPageIndexChanging="Grid_Detail_PageIndexChanging"
                                        OnRowCommand="Grid_Detail_RowCommand">
                                        <RowStyle CssClass="GridViewRowStyle" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                        <HeaderStyle CssClass="GridViewHead" />
                                        <FooterStyle CssClass="GridViewFooterStyle" />
                                        <Columns>
                                            <asp:BoundField DataField="TEER_ID" HeaderText="培训记录ID" SortExpression="TEER_ID"
                                                Visible="false">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRDD_StaffNO" HeaderText="工号" SortExpression="HRDD_StaffNO">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRDD_Name" HeaderText="姓名" SortExpression="HRDD_Name">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="BDOS_Name" HeaderText="部门" SortExpression="BDOS_Name">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRP_Post" HeaderText="岗位" SortExpression="HRP_Post">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbtnDelete_Detail" runat="server" CommandName="Delete_Detail"
                                                        OnClientClick="return confirm('您确认删除该记录吗?')" CommandArgument='<%#Eval("TEER_ID")%>'>删除</asp:LinkButton>
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
                                            <asp:Label ID="Label16" runat="server" Text="没有找到相关记录"></asp:Label>
                                        </EmptyDataTemplate>
                                        <EditRowStyle BackColor="white" />
                                    </asp:GridView>
                                </fieldset>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="8" align="center">
                                <asp:Button ID="BtnCancel2" runat="server" Width="70px" Text="关闭" CssClass="Button02"
                                    OnClick="BtnCancel2_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_AddEmployee" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="DdlAddDep" />
        </Triggers>
        <ContentTemplate>
            <asp:Panel ID="Panel_AddEmployee" runat="server" Visible="false">
                <fieldset>
                    <legend>员工新增栏</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label25" runat="server" CssClass="STYLE2" Text="工号：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TextBox9" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label26" runat="server" CssClass="STYLE2" Text="姓名：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TextBox10" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label27" runat="server" CssClass="STYLE2" Text="部门：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:DropDownList ID="DdlAddDep" runat="server" ToolTip="单击选择" AutoPostBack="true"
                                    OnSelectedIndexChanged="DdlAddDep_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label28" runat="server" CssClass="STYLE2" Text="岗位：" Enabled="False"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:DropDownList ID="DdlAddPost" runat="server" ToolTip="单击选择">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center">
                                <asp:Label ID="Label34" runat="server" Text="检索前" Visible="false"></asp:Label>
                                <asp:Button ID="BtnAddSearch" runat="server" CssClass="Button02" Height="24px" Text="检索"
                                    Width="70px" OnClick="BtnAddSearch_Click" />
                            </td>
                            <td colspan="4" align="center">
                                <asp:Button ID="BtnAddReset" runat="server" CssClass="Button02" Height="24px" Width="70px"
                                    Text="重置" OnClick="BtnAddReset_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="8">
                                <fieldset>
                                    <legend>员工列表</legend>
                                    <asp:GridView ID="GridViewAdd" runat="server" DataKeyNames="HRDD_ID" AllowSorting="True"
                                        AutoGenerateColumns="False" CssClass="GridViewStyle" Width="100%" AllowPaging="True"
                                        PageSize="10" GridLines="None" OnPageIndexChanging="GridViewAdd_PageIndexChanging">
                                        <RowStyle CssClass="GridViewRowStyle" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                        <HeaderStyle CssClass="GridViewHead" />
                                        <FooterStyle CssClass="GridViewFooterStyle" />
                                        <Columns>
                                            <asp:BoundField DataField="HRDD_ID" HeaderText="人事档案ID" SortExpression="HRDD_ID">
                                                <FooterStyle CssClass="hidden" />
                                                <HeaderStyle CssClass="hidden" />
                                                <ItemStyle CssClass="hidden" />
                                            </asp:BoundField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="HRDD_StaffNO" HeaderText="工号" SortExpression="HRDD_StaffNO">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRDD_Name" HeaderText="姓名" SortExpression="HRDD_Name">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="BDOS_Name" HeaderText="部门" SortExpression="BDOS_Name">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRP_Post" HeaderText="岗位" SortExpression="HRP_Post">
                                                <ItemStyle />
                                            </asp:BoundField>
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
                                            <asp:Label ID="Label16" runat="server" Text="没有找到相关记录"></asp:Label>
                                        </EmptyDataTemplate>
                                        <EditRowStyle BackColor="white" />
                                    </asp:GridView>
                                </fieldset>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td colspan="2" align="right">
                                <asp:CheckBox ID="Cbx_SelectAll" runat="server" Text="当前页全选" AutoPostBack="true" OnCheckedChanged="Cbx_SelectAll_CheckedChanged" />
                            </td>
                            <td colspan="2" align="center">
                                <asp:CheckBox ID="Cbx_SelectAllCancel" runat="server" Text="当前页全不选" AutoPostBack="true"
                                    OnCheckedChanged="Cbx_SelectAllCancel_CheckedChanged" />
                            </td>
                            <td colspan="2" align="left">
                                <asp:CheckBox ID="Cbx_SelectOpposite" runat="server" Text="当前页反选" AutoPostBack="true"
                                    OnCheckedChanged="Cbx_SelectOpposite_CheckedChanged" />
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center">
                                <asp:Button ID="Button5" runat="server" CssClass="Button02" Height="24px" Text="提交"
                                    Width="70px" OnClick="Button5_Click" />
                            </td>
                            <td colspan="4" align="center">
                                <asp:Button ID="BtnAddCancel" runat="server" CssClass="Button02" Height="24px" Width="70px"
                                    Text="关闭" OnClick="BtnAddCancel_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel5" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="Label58" runat="server" Text=""></asp:Label>培训结果录入栏<asp:Label ID="LblRecordTID_ID"
                            runat="server" Text="" Visible="false"></asp:Label></legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 100%;">
                                <fieldset>
                                    <legend>参与培训的员工列表</legend>
                                    <asp:GridView ID="GridView_People" runat="server" DataKeyNames="TEER_ID" AllowSorting="True"
                                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                                        AllowPaging="False" Font-Strikeout="False" UseAccessibleHeader="False" GridLines="None">
                                        <RowStyle CssClass="GridViewRowStyle" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                        <HeaderStyle CssClass="GridViewHead" />
                                        <FooterStyle CssClass="GridViewFooterStyle" />
                                        <Columns>
                                            <asp:BoundField DataField="TEER_ID" HeaderText="培训记录ID" ReadOnly="True" SortExpression="TEER_ID">
                                                <FooterStyle CssClass="hidden" />
                                                <HeaderStyle CssClass="hidden" />
                                                <ItemStyle CssClass="hidden" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRDD_StaffNO" HeaderText="工号" SortExpression="HRDD_StaffNO">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRDD_Name" HeaderText="姓名" SortExpression="HRDD_Name">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="培训结果">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="DropDownList1" runat="server">
                                                        <asp:ListItem>通过</asp:ListItem>
                                                        <asp:ListItem>不通过</asp:ListItem>
                                                        <asp:ListItem>缺席</asp:ListItem>
                                                        <asp:ListItem>请假</asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="备注(50字以内)">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="TxtRemarks" runat="server" Width="100%" MaxLength="50"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle />
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerTemplate>
                                            <table width="100%">
                                                <tr>
                                                    <td style="text-align: right">
                                                        第&nbsp<asp:Label ID="lblPageIndex" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>' />
                                                        页 共&nbsp<asp:Label ID="lblPageCount" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />
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
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%;">
                        <tr>
                            <td align="right">
                                <asp:Button ID="BtnOK" runat="server" CssClass="Button02" Height="24px" Text="提交"
                                    Width="70px" ValidationGroup="Input" OnClick="BtnOK_Click" />
                            </td>
                            <td align="center">
                                &nbsp;
                            </td>
                            <td align="left">
                                <asp:Button ID="Btnclose" runat="server" CssClass="Button02" Height="24px" Text="关闭"
                                    Visible="true" Width="70px" OnClick="Btnclose_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div id="Panel99">
        <asp:UpdatePanel ID="UpdatePanel_upload" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <fieldset>
                    <legend>上传培训课件</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 17%" align="right">
                                <asp:Label ID="Label35" runat="server" Text="培训课件名称："></asp:Label>
                            </td>
                            <td style="width: 18%">
                                <asp:TextBox ID="reportno" runat="server" Width="130px" Height="20px" MaxLength="20"></asp:TextBox>
                                <asp:Label ID="Label51" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="*"
                                    ControlToValidate="reportno" ValidationGroup="loadvalidation"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label38" runat="server" Text="上传附件："></asp:Label>
                            </td>
                            <td style="width: 18%">
                                <asp:FileUpload ID="FileUpload1" runat="server" Width="375px" Height="20px" />
                                <asp:Label ID="Label52" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                            <td style="width: 10%">
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="*"
                                    ControlToValidate="FileUpload1" ValidationGroup="loadvalidation"></asp:RequiredFieldValidator>--%>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td align="right" colspan="2">
                                <asp:Button ID="ok_upload" runat="server" Text="提交" Width="70px" CssClass="Button02"
                                    Height="24px" OnClick="ok_upload_Click" ValidationGroup="loadvalidation" />
                            </td>
                            <td align="center" colspan="3">
                                <asp:Button ID="cancel_upload" runat="server" Text="关闭" Width="70px" CssClass="Button02"
                                    Height="24px" OnClick="cancel_upload_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="ok_upload" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel6" runat="server" Visible="false">
                <fieldset>
                    <legend>培训结果列表</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 100%;">
                                <asp:GridView ID="GridViewResult" runat="server" AllowPaging="False" AllowSorting="True"
                                    AutoGenerateColumns="False" CellPadding="0" CssClass="GridViewStyle" DataKeyNames="TEER_ID"
                                    Font-Strikeout="False" GridLines="None" UseAccessibleHeader="False" Width="100%">
                                    <RowStyle CssClass="GridViewRowStyle" />
                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                    <HeaderStyle CssClass="GridViewHead" />
                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                    <Columns>
                                        <asp:BoundField DataField="TEER_ID" HeaderText="培训记录ID" ReadOnly="True" SortExpression="TEER_ID">
                                            <FooterStyle CssClass="hidden" />
                                            <HeaderStyle CssClass="hidden" />
                                            <ItemStyle CssClass="hidden" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="HRDD_StaffNO" HeaderText="工号" SortExpression="HRDD_StaffNO">
                                            <ItemStyle />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="HRDD_Name" HeaderText="姓名" SortExpression="HRDD_Name">
                                            <ItemStyle />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="TEER_Result" HeaderText="培训结果" SortExpression="TEER_Result">
                                            <ItemStyle />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="TEER_Remark" HeaderText="备注" SortExpression="TEER_Remark">
                                            <ItemStyle />
                                        </asp:BoundField>
                                    </Columns>
                                    <PagerTemplate>
                                        <table width="100%">
                                            <tr>
                                                <td style="text-align: right">
                                                    第&nbsp;<asp:Label ID="lblPageIndex" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                                    页 共&nbsp;<asp:Label ID="lblPageCount" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageCount  %>" />
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
                                                    <!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
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
                        <tr>
                            <td align="center" style="width: 100%;">
                                <asp:Label ID="Label36" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Button ID="Button7" runat="server" CssClass="Button02" Height="24px" Text="关闭"
                                    Visible="true" Width="70px" OnClick="Button7_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
