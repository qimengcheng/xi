<%@ Page Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true"
    CodeFile="MeasApplianceMgt.aspx.cs" Inherits="MeasApplianceMgt_MeasApplianceMgt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
    <script language="javascript" type="text/javascript">
        function onlynumanddot(obj) {
            obj.value = obj.value.replace(/[^\d.]/g, "");
        }
    </script>
    <asp:UpdatePanel ID="UpdatePanel_Search" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Search" runat="server">
                <fieldset>
                    <legend>检索条件</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 10%; height: 20px;" align="center">
                                <asp:Label ID="Label1" runat="server" CssClass="STYLE2" Text="设备名称:"></asp:Label>
                            </td>
                            <td style="width: 20%; height: 20px;">
                                <asp:TextBox ID="TxtEquipName" runat="server" Width="155px"></asp:TextBox>
                            </td>
                            <td style="width: 10%; height: 20px;" align="center">
                                <asp:Label ID="Label2" runat="server" CssClass="STYLE2" Text="出厂编号:"></asp:Label>
                            </td>
                            <td style="width: 20%; height: 20px;">
                                <asp:TextBox ID="TxtManuCode" runat="server" Width="155px"></asp:TextBox>
                            </td>
                            <td style="width: 10%; height: 20px;" align="center">
                                <asp:Label ID="Label3" runat="server" CssClass="STYLE2" Text="设备位置:"></asp:Label>
                            </td>
                            <td style="width: 20%; height: 20px;">
                                <asp:TextBox ID="TxtLocation" runat="server" Width="155px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%; height: 20px;" align="center">
                                <asp:Label ID="Label38" runat="server" CssClass="STYLE2" Text="设备编号:"></asp:Label>
                            </td>
                            <td style="width: 20%; height: 20px;">
                                <asp:TextBox ID="TextBox13" runat="server" Width="155px"></asp:TextBox>
                            </td>
                            <td style="width: 10%; height: 20px;" align="center">
                                <asp:Label ID="Label39" runat="server" CssClass="STYLE2" Text="制造厂家:"></asp:Label>
                            </td>
                            <td style="width: 20%; height: 20px;">
                                <asp:TextBox ID="TextBox14" runat="server" Width="155px"></asp:TextBox>
                            </td>
                            <td style="width: 10%; height: 20px;" align="center">
                                <asp:Label ID="Label41" runat="server" CssClass="STYLE2" Text="是否报废:"></asp:Label>
                            </td>
                            <td style="width: 20%; height: 20px;">
                                 <asp:DropDownList ID="DropDownList2" runat="server">
                                    <asp:ListItem Text="请选择" Value=""></asp:ListItem>
                                    <asp:ListItem Text="否" Value="否"></asp:ListItem>
                                    <asp:ListItem Text="是" Value="是"></asp:ListItem>
                                 </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" colspan="2">
                                <asp:Button ID="BtnSearch" runat="server" CssClass="Button02" Height="24px" Text="检索"
                                    Width="70px" OnClick="BtnSearch_Click" />
                            </td>
                            <td align="center" colspan="2">
                                <asp:Button ID="BtnNew" runat="server" CssClass="Button02" Height="24px" Text="新增"
                                    Width="70px" OnClick="BtnNew_Click" />
                            </td>
                            <td align="left" colspan="2">
                                <asp:Button ID="BtnCancel" runat="server" CssClass="Button02" Height="24px" Text="重置"
                                    Visible="true" Width="70px" OnClick="BtnCancel_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_Grid" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Grid" runat="server">
                <fieldset>
                    <legend>计量器具检验列表</legend>
                    <asp:GridView ID="Grid_MeasAppliance" runat="server" DataKeyNames="MAM_EquipID" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                        AllowPaging="True" PageSize="20" GridLines="None" UseAccessibleHeader="False"
                        OnDataBound="Grid_MeasAppliance_DataBound" OnRowCommand="Grid_MeasAppliance_RowCommand"
                        OnPageIndexChanging="Grid_MeasAppliance_PageIndexChanging" >
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="MAM_EquipID" HeaderText="计量设备ID" SortExpression="MAM_EquipID"
                                Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="MAM_EquipName" HeaderText="设备名称" SortExpression="MAM_EquipName">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="MAM_EquipType" HeaderText="设备编号" SortExpression="MAM_EquipType">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="MAM_ManuName" HeaderText="制造厂家" SortExpression="MAM_ManuName">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="MAM_ManuCode" HeaderText="出厂编号" SortExpression="MAM_ManuCode">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="MAM_Location" HeaderText="设备位置" SortExpression="MAM_Location">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="MAM_OAccuracy" HeaderText="厂家精度" SortExpression="MAM_OAccuracy">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="MAM_IAccuracy" HeaderText="精度要求" SortExpression="MAM_IAccuracy">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="MAM_Period" HeaderText="检验周期（月）" SortExpression="MAM_Period">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="MAD_TestTime" HeaderText="上次检验日期" SortExpression="MAD_TestTime" Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="MAM_ToBeTestDate" HeaderText="检定日期" SortExpression="MAM_ToBeTestDate">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="MAM_RemindDays" HeaderText="检验提醒天数（天）" SortExpression="MAM_RemindDays">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="MAM_ToDate" HeaderText="送达日期" SortExpression="MAM_ToDate">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="MAM_Isunused" HeaderText="是否报废" SortExpression="MAM_Isunused">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnEdit" runat="server" CommandArgument='<%#Eval("MAM_EquipID")%>'
                                        CommandName="Edit_Inf" OnClientClick="false">编辑</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnDelete_Inf" runat="server" CommandName="Delete_Inf" OnClientClick="return confirm('您确认删除该记录吗?')"
                                        CommandArgument='<%#Eval("MAM_EquipID")%>'>删除</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnLook_TestResult" runat="server" CommandArgument='<%#Eval("MAM_EquipID")%>'
                                        CommandName="Look_TestResult" OnClientClick="false">检验历史</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnTestResult" runat="server" CommandArgument='<%#Eval("MAM_EquipID")%>'
                                        CommandName="TestResult" OnClientClick="false">检验结果录入</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第<asp:Label ID="lblPageIndex" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                        页 共<asp:Label ID="lblPageCount" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageCount  %>" />
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
    <asp:UpdatePanel ID="UpdatePanel_New" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_New" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="Label24" runat="server" Text=""></asp:Label><asp:Label ID="Label4"
                            runat="server" Text=""></asp:Label></legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 15%; height: 15px;" align="center">
                                <asp:Label ID="Label5" runat="server" CssClass="STYLE2" Text="设备名称:"></asp:Label>
                            </td>
                            <td style="width: 20%; height: 15px;">
                                <asp:TextBox ID="TextBox1" runat="server" Width="120px" MaxLength="25"></asp:TextBox>
                                <asp:Label ID="Label12" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                    ControlToValidate="TextBox1" ValidationGroup="Detail"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td style="width: 10%; height: 15px;" align="center">
                                <asp:Label ID="Label34" runat="server" CssClass="STYLE2" Text="设备编号:"></asp:Label>
                            </td>
                            <td style="width: 20%; height: 15px;">
                                <asp:TextBox ID="TextBox11" runat="server" Width="120px" MaxLength="25"></asp:TextBox>
                                <asp:Label ID="Label35" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                            <td style="width: 10%; height: 15px;" align="center">
                                <asp:Label ID="Label6" runat="server" CssClass="STYLE2" Text="出厂编号:"></asp:Label>
                            </td>
                            <td >
                                <asp:TextBox ID="TextBox2" runat="server" Width="120px" MaxLength="25" ></asp:TextBox>
                                <asp:Label ID="Label15" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                    ControlToValidate="TextBox2" ValidationGroup="Detail"></asp:RequiredFieldValidator>--%>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Label ID="Label36" runat="server" CssClass="STYLE2" Text="制造厂家:"></asp:Label>
                            </td>
                            <td >
                                <asp:TextBox ID="TextBox12" runat="server" Width="120px" MaxLength="25"></asp:TextBox>
                                <asp:Label ID="Label37" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                            <td style="height: 15px;" align="center">
                                <asp:Label ID="Label8" runat="server" CssClass="STYLE2" Text="送达日期:"></asp:Label>
                            </td>
                            <td style=" height: 15px;">
                                <asp:TextBox ID="TextBox4" runat="server" Width="120px"  onfocus="new  WdatePicker(this,'%Y-%M-%D',true)"></asp:TextBox>
                                <asp:Label ID="Label26" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                                    ControlToValidate="TextBox4" ValidationGroup="Detail"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td style="height: 15px;" align="center">
                                <asp:Label ID="Label7" runat="server" CssClass="STYLE2" Text="设备位置:"></asp:Label>
                            </td>
                            <td style="height: 15px;">
                                <asp:TextBox ID="TextBox3" runat="server" Width="120px" MaxLength="20"></asp:TextBox>
                                <asp:Label ID="Label25" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                    ControlToValidate="TextBox3" ValidationGroup="Detail"></asp:RequiredFieldValidator>--%>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Label ID="Label9" runat="server" CssClass="STYLE2" Text="厂家精度:"></asp:Label>
                            </td>
                            <td >
                                <asp:TextBox ID="TextBox5" runat="server" Width="120px" 
                                    onkeyup="this.value = this.value.substring(0, 50)" onafterpaste="this.value = this.value.substring(0, 50)"></asp:TextBox>
                                <asp:Label ID="Label27" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*"
                                    ControlToValidate="TextBox5" ValidationGroup="Detail"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td align="center">
                                <asp:Label ID="Label10" runat="server" CssClass="STYLE2" Text="精度要求:"></asp:Label>
                            </td>
                            <td >
                                <asp:TextBox ID="TextBox6" runat="server" Width="120px" 
                                    onkeyup="this.value = this.value.substring(0, 50)" onafterpaste="this.value = this.value.substring(0, 50)"></asp:TextBox>
                                <asp:Label ID="Label28" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                                <td align="center">
                                    <asp:Label ID="Label11" runat="server" CssClass="STYLE2" Text="检验周期(月):"></asp:Label>
                                </td>
                                <td >
                                    <asp:TextBox ID="TextBox7" runat="server" Width="120px" MaxLength="8" onkeyup="this.value=this.value.replace(/[^\d.]/g,'')"
                                        onafterpaste="this.value=this.value.replace(/[^\d.]/g,'')"></asp:TextBox>
                                    <asp:Label ID="Label29" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*"
                                        ControlToValidate="TextBox7" ValidationGroup="Detail"></asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                            <tr>
                                <td  align="center">
                                    <asp:Label ID="Label13" runat="server" CssClass="STYLE2" Text="检定日期:"></asp:Label>
                                </td>
                                <td >
                                    <asp:TextBox ID="TextBox8" runat="server" Width="120px"  onfocus="new  WdatePicker(this,'%Y-%M-%D',true)"></asp:TextBox>
                                    <asp:Label ID="Label30" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*"
                                        ControlToValidate="TextBox8" ValidationGroup="Detail"></asp:RequiredFieldValidator>--%>
                                </td>
                                <td align="center">
                                    <asp:Label ID="Label14" runat="server" CssClass="STYLE2" Text="提醒天数(天):"></asp:Label>
                                </td>
                                <td >
                                    <asp:TextBox ID="TextBox9" runat="server" Width="120px" MaxLength="8" onkeyup="this.value=this.value.replace(/[^\d.]/g,'')"
                                        onafterpaste="this.value=this.value.replace(/[^\d.]/g,'')"></asp:TextBox>
                                    <asp:Label ID="Label31" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*"
                                        ControlToValidate="TextBox9" ValidationGroup="Detail"></asp:RequiredFieldValidator>--%>
                                </td>
                                <td align="center">
                                    <asp:Label ID="Label40" runat="server" CssClass="STYLE2" Text="是否报废:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownList1" runat="server">
                                        <asp:ListItem Text="请选择" Value=""></asp:ListItem>
                                        <asp:ListItem Text="否" Value="否"></asp:ListItem>
                                        <asp:ListItem Text="是" Value="是"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:Label ID="Label42" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td align="right">
                                    <asp:Button ID="BtnOK" runat="server" CssClass="Button02" Height="24px" Text="提交"
                                        Width="70px" OnClick="BtnOK_Click" ValidationGroup="Detail" />
                                </td>
                                <td align="center" colspan="2">
                                    &nbsp;
                                </td>
                                <td align="left" colspan="3">
                                    <asp:Button ID="BtnCancel1" runat="server" CssClass="Button02" Height="24px" Text="关闭"
                                        Visible="true" Width="70px" OnClick="BtnCancel1_Click" />
                                </td>
                            </tr>
                        </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_History" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_History" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="ASP_Label_Show_History" runat="server"></asp:Label>
                    </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td colspan="6">
                                <asp:GridView ID="Grid_History" runat="server" DataKeyNames="MAD_DetailID" AllowSorting="True"
                                    AutoGenerateColumns="False" CssClass="GridViewStyle" Width="100%" AllowPaging="True"
                                    PageSize="10" GridLines="None" OnDataBound="Grid_History_DataBound" OnRowCommand="Grid_History_RowCommand"
                                    OnPageIndexChanging="Grid_History_PageIndexChanging">
                                    <RowStyle CssClass="GridViewRowStyle" />
                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                    <HeaderStyle CssClass="GridViewHead" />
                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                    <Columns>
                                        <asp:BoundField DataField="MAD_DetailID" HeaderText="计量检验详情ID" SortExpression="MAD_DetailID"
                                            Visible="false">
                                            <ItemStyle />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="MAD_TestNo" HeaderText="检验单号" SortExpression="MAD_TestNo">
                                            <ItemStyle />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="MAD_TestTime" HeaderText="检验日期" SortExpression="MAD_TestTime">
                                            <ItemStyle />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="MAD_TestPer" HeaderText="检验人" SortExpression="MAD_TestPer">
                                            <ItemStyle />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="MAD_Result" HeaderText="检验结果" SortExpression="MAD_Result">
                                            <ItemStyle />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="MAD_Remarks" HeaderText="备注" SortExpression="MAD_Remarks">
                                            <ItemStyle />
                                        </asp:BoundField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbtnEdit_Detail" runat="server" CommandArgument='<%#Eval("MAD_DetailID")%>'
                                                    CommandName="Edit_Detail" OnClientClick="false">编辑</asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbtnDelete_Detail" runat="server" CommandName="Delete_Detail"
                                                    OnClientClick="return confirm('您确认删除该记录吗?')" CommandArgument='<%#Eval("MAD_DetailID")%>'>删除</asp:LinkButton>
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
                                                    <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                                        CommandName="Page" Text="GO" />
                                                    <!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
                                                </td>
                                            </tr>
                                        </table>
                                    </PagerTemplate>
                                    <EmptyDataTemplate>
                                        <asp:Label ID="Label17" runat="server" Text="没有找到相关记录"></asp:Label>
                                    </EmptyDataTemplate>
                                    <EditRowStyle BackColor="white" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="6">
                                <asp:Button ID="BtnHistoryClose" runat="server" CssClass="Button02" Height="24px"
                                    Text="关闭" Width="70px" OnClick="BtnHistoryClose_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_Result" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Result" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="ASP_Lable_Result" runat="server"></asp:Label>
                        <asp:Label ID="Label23" runat="server" Text=""></asp:Label>
                    </legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label18" runat="server" CssClass="STYLE2" Text="检验单号:"></asp:Label>
                            </td>
                            <td style="width: 18%">
                                <asp:TextBox ID="TxtNo" runat="server" Width="130px" MaxLength="25" onkeyup="this.value=this.value.replace(/[^0-9a-zA-Z]/g,'')"
                                    onafterpaste="this.value=this.value.replace(/[^0-9a-zA-Z]/g,'')"></asp:TextBox>
                                <asp:Label ID="Label32" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*"
                                    ControlToValidate="TxtNo" ValidationGroup="Detail"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label19" runat="server" CssClass="STYLE2" Text="检验人:"></asp:Label>
                            </td>
                            <td style="width: 18%">
                                <asp:TextBox ID="TxtPer" runat="server" Width="130px" MaxLength="10" Enabled="false"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*"
                                    ControlToValidate="TxtPer" ValidationGroup="Detail"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label20" runat="server" CssClass="STYLE2" Text="检验时间:"></asp:Label>
                            </td>
                            <td style="width: 18%">
                                <asp:TextBox ID="TextTime" runat="server" Width="130px" Enabled="false"
                                    onfocus="new  WdatePicker(this,'%Y-%M-%D',true)" DataFormatString="{0:yyyy-MM-dd}"></asp:TextBox>
                                <asp:Label ID="Label33" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*"
                                    ControlToValidate="TextTime" ValidationGroup="Detail"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label21" runat="server" CssClass="STYLE2" Text="检验结果:"></asp:Label>
                            </td>
                            <td >
                                <asp:DropDownList ID="DdlTextResult" runat="server" ToolTip="单击选择">
                                    <asp:ListItem>合格</asp:ListItem>
                                    <asp:ListItem>不合格</asp:ListItem>
                                </asp:DropDownList>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*"
                                    ControlToValidate="TextResult" ValidationGroup="Detail"></asp:RequiredFieldValidator>--%>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%; height: 15px;" align="center">
                                <asp:Label ID="Label22" runat="server" CssClass="STYLE2" Text="备注:<br/>(200字内)"></asp:Label>
                            </td>
                            <td colspan="8">
                                <asp:TextBox ID="TextBox10" runat="server" Width="90%" Height="70px" TextMode="MultiLine"
                                    onkeyup="this.value = this.value.substring(0, 200)" onafterpaste="this.value = this.value.substring(0, 200)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4" style="width: 10%">
                                <asp:Button ID="ButtonSubmit" runat="server" CssClass="Button02" Height="24px" Text="提交"
                                    Width="70px" OnClick="ButtonSubmit_Click" ValidationGroup="Detail" />
                            </td>
                            <td align="center" colspan="3">
                                <asp:Button ID="ButtonCancel2" runat="server" CssClass="Button02" Height="24px" Text="关闭"
                                    Width="70px" OnClick="ButtonCancel2_Click" />
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
