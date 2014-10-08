<%@ Page Title="新员工培训项目维护" Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true"
    CodeFile="NETItemMaintenance.aspx.cs" Inherits="TrainningMgt_NETItemMaintenance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel2" runat="server">
                <fieldset>
                    <legend>新员工培训检索栏</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="LblItem" runat="server" CssClass="STYLE2" Text="培训课程"></asp:Label>
                                <asp:Label ID="LblState" runat="server" Visible="false"></asp:Label>
                            </td>
                            <td style="height: 20%">
                                <asp:TextBox ID="TxtCourse" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="LblCourse" runat="server" CssClass="STYLE2" Text="培训类型"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtType" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="LblDep" runat="server" CssClass="STYLE2" Text="授课部门"></asp:Label>
                            </td>
                            <td style="height: 20%">
                                <asp:TextBox ID="TxtDep" runat="server" Width="130px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" colspan="2">
                                <asp:Label ID="Info_EMFM_Code" runat="server" Text="Info_EMFM_Code" Visible="False"></asp:Label>
                                <asp:Button ID="Btn_Search_NETItem" runat="server" CssClass="Button02" Height="24px"
                                    Text="检索" OnClick="Btn_Search_NETItem_Click" Width="70px" />
                            </td>
                            <td align="center" colspan="2"><asp:Label ID="LblIsSearch" runat="server" Visible="false" Text="检索前"></asp:Label>
                                <asp:Button ID="Btn_NEW_NETItem" runat="server" CssClass="Button02" Height="24px"
                                    Text="新增培训项目" Width="90px" OnClick="Btn_NEW_NETItem_Click" />
                            </td>
                            <td align="left" colspan="2">
                                <asp:Button ID="Btn_Clear" runat="server" CssClass="Button02" Height="24px" Width="70px"
                                    Text="重置" OnClick="Btn_Clear_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server">
                <fieldset>
                    <legend>新员工培训项目列表</legend>
                    <asp:GridView ID="Grid_NETrainingItem" runat="server" DataKeyNames="NETI_ID" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                        AllowPaging="True" PageSize="10" Font-Strikeout="False" UseAccessibleHeader="False"
                        GridLines="None" OnPageIndexChanging="Grid_NETrainingItem_PageIndexChanging"
                        OnSorting="Grid_NETrainingItem_Sorting" OnRowCommand="Grid_NETrainingItem_RowCommand"
                         OnRowCreated="Grid_NETrainingItem_RowCreated" 
                        ondatabound="Grid_NETrainingItem_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="NETI_ID" HeaderText="新员工培训项目ID" ReadOnly="True" SortExpression="NETI_ID"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="NETI_TraningCourse" HeaderText="培训课程" SortExpression="NETI_TraningCourse">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="NETI_TraningType" HeaderText="培训类别" SortExpression="NETI_TraningType">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="BDOS_Name" HeaderText="授课部门" SortExpression="BDOS_Name">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="NETI_CreditHours" HeaderText="培训学时" SortExpression="NETI_CreditHours">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="NETI_IsDeleted" HeaderText="是否删除" SortExpression="NETI_IsDeleted"
                                ReadOnly="True" Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnEdit_TraningCourses" runat="server" CommandArgument='<%#Eval("NETI_ID")%>'
                                        CommandName="Edt_TraningCourse" OnClientClick="false">编辑</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnDelete_TraningCourses" runat="server" CommandName="Delete_TraningCourse"
                                        OnClientClick="return confirm('您确认删除该记录吗?')" CommandArgument='<%#Eval("NETI_ID")%>'>删除</asp:LinkButton>
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
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_NewItem" runat="server" UpdateMode="Conditional">
        <%--<Triggers>
            <asp:AsyncPostBackTrigger ControlID="Btn_NEW_NETItem" />
        </Triggers>--%>
        <ContentTemplate>
            <asp:Panel ID="Panel_NewItem" runat="server" Visible="false">
                <fieldset>
                    <legend>培训项目维护</legend>
                    <table width="100%">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label31" runat="server" Text="培训课程"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtAddCourse" runat="server" Width="128px"></asp:TextBox>
                                <asp:Label ID="Label2" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ErrorMessage="*" ControlToValidate="TxtAddCourse" 
                                    ValidationGroup="NewTrainning"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label32" runat="server" Text="培训类别"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:DropDownList ID="DdlstAddType" runat="server" ToolTip="单击选择">
                                    <asp:ListItem>岗前培训</asp:ListItem>
                                    <asp:ListItem>在岗培训</asp:ListItem>
                                    <asp:ListItem>其他培训</asp:ListItem>
                                </asp:DropDownList>
                                <asp:Label ID="Label3" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ErrorMessage="*" ControlToValidate="DdlstAddType" ValidationGroup="NewTrainning"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="授课部门" runat="server" Text="授课部门"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:DropDownList ID="DdlstAddDep" runat="server" ToolTip="单击选择">
                                </asp:DropDownList>
                                <asp:Label ID="Label4" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                    ErrorMessage="*" ControlToValidate="DdlstAddDep" ValidationGroup="NewTrainning"></asp:RequiredFieldValidator>--%>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label1" runat="server" Text="培训学时(H)"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtAddHours" runat="server" Width="128px" onkeyup="this.value=this.value.replace(/[^\d.]/g,'')"
                                 onafterpaste="this.value=this.value.replace(/[^\d.]/g,'')"></asp:TextBox>
                                <asp:Label ID="Label5" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                    ErrorMessage="*" ControlToValidate="TxtAddHours" ValidationGroup="NewTrainning"></asp:RequiredFieldValidator>--%>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" align="center">
                                <asp:Button ID="BtnOK_NETItem" runat="server" Width="70px" Text="提交" CssClass="Button02" Height="24px"
                                    OnClick="BtnOK_NETItem_Click" ValidationGroup="NewTrainning" />
                            </td>
                            <td colspan="3" align="center">
                                <asp:Button ID="BtnCancel_Info_FailureMode" runat="server" Width="70px" Text="关闭" Height="24px"
                                    CssClass="Button02" OnClick="BtnCancel_Info_FailureMode_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
