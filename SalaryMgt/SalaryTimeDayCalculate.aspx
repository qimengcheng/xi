﻿<%@ Page Title="计时工资日计算" Language="C#" MasterPageFile="~/Other/MasterPage.master"
    AutoEventWireup="true" CodeFile="SalaryTimeDayCalculate.aspx.cs" Inherits="SalaryMgt_SalaryTimeCalculate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server">
                <fieldset>
                    <legend>检索栏</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="LblDate" runat="server" CssClass="STYLE2" Text="日期："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 20%;" align="left">
                                <asp:TextBox ID="TxtSDate" runat="server" Width="130px" onfocus="new  WdatePicker(this,'%Y-%M-%D',false)"></asp:TextBox>
                            </td>

                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label13" runat="server" CssClass="STYLE2" Text="人事审核："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 20%;" align="left">
                                <asp:DropDownList ID="DropDownList3" runat="server" ToolTip="单击选择">
                                    <asp:ListItem>请选择</asp:ListItem>
                                    <asp:ListItem>待审核</asp:ListItem>
                                    <asp:ListItem>通过</asp:ListItem>
                                    <asp:ListItem>不通过</asp:ListItem>
                                </asp:DropDownList>
                            </td>

                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label14" runat="server" CssClass="STYLE2" Text="财务审核："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 20%;" align="left">
                                <asp:DropDownList ID="DropDownList5" runat="server" ToolTip="单击选择" AutoPostBack="true">
                                    <asp:ListItem>请选择</asp:ListItem>
                                    <asp:ListItem>待审核</asp:ListItem>
                                    <asp:ListItem>通过</asp:ListItem>
                                    <asp:ListItem>不通过</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td colspan="2" align="right">
                            <asp:Label ID="LblRecordIsSearch" runat="server" Text="检索前" Visible="false"></asp:Label>
                                <asp:Button ID="BtnSearch" runat="server" CssClass="Button02" Height="24px" Text="检索"
                                    Width="70px" OnClick="BtnSearch_Click" />
                            </td>
                            <td colspan="2"  align="center">
                            </td>
                            <td colspan="2"  align="left">
                                <asp:Button ID="BtnReset" runat="server" CssClass="Button02" Height="24px" Text="重置"
                                    Width="70px" OnClick="BtnReset_Click" />
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
                    <legend>计时工资日期列表</legend>
                    <asp:GridView ID="GridView1" runat="server" DataKeyNames="WTP_Date" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" Width="100%" AllowPaging="True"
                        PageSize="5" GridLines="None" OnPageIndexChanging="GridView1_PageIndexChanging"
                        OnRowCommand="GridView1_RowCommand">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="WTP_ID" HeaderText="计时计件ID" SortExpression="WTP_ID" Visible="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="WTP_Date" HeaderText="日期" SortExpression="WTP_Date">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="WTP_TimeTotal" HeaderText="计时总工资" SortExpression="WTP_TimeTotal">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="WTP_TimeRState" HeaderText="生产部核算" SortExpression="WTP_TimeRState">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="PT_AuRes" HeaderText="人事审核" SortExpression="PT_AuRes">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="STSA_AuRes" HeaderText="财务审核" SortExpression="STSA_AuRes">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnCalculate" runat="server" CommandArgument='<%#Eval("WTP_ID")+","+Eval("WTP_TimeTotal")+","+Eval("WTP_TimeRState")+","+Eval("STSA_AuRes")+","+Eval("PT_AuRes")+","+Eval("WTP_Date")%>'
                                        CommandName="Calculate" OnClientClick="false">人事审核</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnDetailForShenHe" runat="server" CommandArgument='<%#Eval("WTP_ID")%>'
                                        CommandName="DetailForShenHe" OnClientClick="false">查看当日明细</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnShenHe" runat="server" CommandArgument='<%#Eval("WTP_ID")+","+Eval("WTP_TimeTotal")+","+Eval("WTP_TimeRState")+","+Eval("STSA_AuRes")+","+Eval("PT_AuRes")%>'
                                        CommandName="ShenHe1ABC" OnClientClick="false">财务审核</asp:LinkButton>
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

    <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel6" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="Label15" runat="server" Text=""></asp:Label>计时工资审核</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label17" runat="server" CssClass="STYLE2" Text="审核人："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 20%;" align="left">
                                <asp:TextBox ID="TextBox2" runat="server" Width="130px" MaxLength="10" Enabled="false"></asp:TextBox>
                                <asp:Label ID="Label18" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                    ControlToValidate="TextBox1" ValidationGroup="ShenHe"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label19" runat="server" CssClass="STYLE2" Text="审核时间："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 20%;" align="left">
                                <asp:TextBox ID="TextBox3" runat="server" Width="130px" onfocus="new  WdatePicker(this,'%Y-%M-%D %h:%m:%s',true)"
                                    Enabled="false"></asp:TextBox>
                                <asp:Label ID="Label25" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                    ControlToValidate="TxtETime" ValidationGroup="ShenHe"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td style="width: 10%" align="center">
                                
                            </td>
                            <td style="width: 20%; height: 20%;" align="left">
                                
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label28" runat="server" CssClass="STYLE2" Text="审核意见:<br/>(200字内)"></asp:Label>
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="TextBox4" runat="server" Width="630px" Height="80px" TextMode="MultiLine"
                                    MaxLength="200" onkeyup="this.value = this.value.substring(0, 200)" onafterpaste="this.value = this.value.substring(0, 200)"></asp:TextBox>
                            <asp:Label ID="Label26" runat="server" Text="*" ForeColor="Red" Visible="false"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="right">
                                <asp:Label ID="Label29" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Button ID="BtnOK" runat="server" Text="通过并结算" CssClass="Button02" Height="24px"
                                    Width="90px" onclick="BtnOK_Click"  />
                            </td>
                            <td colspan="2" align="center">
                            <asp:Button ID="BtnNO" runat="server" Text="驳回" CssClass="Button02" Height="24px"
                                    Width="70px" onclick="BtnNO_Click"  />
                            </td>
                            <td colspan="2" align="left">
                                <asp:Button ID="BtnShutdown" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    Visible="true" Width="70px" onclick="BtnShutdown_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>


    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel3" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="Label4" runat="server" Text=""></asp:Label>的明细</legend>
                    <asp:GridView ID="GridView2" runat="server" DataKeyNames="WOD_OutTime" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" Width="100%" AllowPaging="True"
                        PageSize="20" GridLines="None" OnRowCommand="GridView2_RowCommand" OnPageIndexChanging="GridView2_PageIndexChanging">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="WOD_OutTime" HeaderText="日期" SortExpression="WOD_OutTime">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="PBC_Name" HeaderText="工序" SortExpression="PBC_Name">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="TotalMoney" HeaderText="计时总工资" SortExpression="TotalMoney">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnLook_Detail" runat="server" CommandArgument='<%#Eval("WOD_OutTime")%>'
                                        CommandName="Look_Detail" OnClientClick="false">查看详情</asp:LinkButton>
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
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td align="center">
                                <asp:Label ID="Label47" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Button ID="Button2" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    Width="70px" OnClick="Button2_Click" />
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
                    <legend>
                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label></legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label21" runat="server" CssClass="STYLE2" Text="工号："></asp:Label>
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
                                <asp:Label ID="Label23" runat="server" CssClass="STYLE2" Text="工序："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:DropDownList ID="DropDownList4" runat="server" ToolTip="单击选择" Enabled="false">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="LblStartTime" runat="server" CssClass="STYLE2" Text="与随工单相关："></asp:Label>
                            </td>
                            <td style="height: 20%;" align="left">
                                <asp:DropDownList ID="DropDownList1" runat="server" ToolTip="单击选择" AutoPostBack="true">
                                    <asp:ListItem>请选择</asp:ListItem>
                                    <asp:ListItem>是</asp:ListItem>
                                    <asp:ListItem>否</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label9" runat="server" CssClass="STYLE2" Text="计时项目："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtSTarget" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                            </td>
                            <td style="width: 20%">
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="right" colspan="2">
                                <asp:Label ID="Label24" runat="server" Text="检索前" Visible="false"></asp:Label>
                                <asp:Button ID="BtnSearchPeopleOut" runat="server" CssClass="Button02" Height="24px"
                                    Text="检索" Width="70px" OnClick="BtnSearchPeopleOut_Click" />
                            </td>
                            <td colspan="2">
                            </td>
                            <td align="left" colspan="2">
                                <asp:Button ID="BtnResetPeopleOut" runat="server" CssClass="Button02" Height="24px"
                                    Width="70px" Text="重置" OnClick="BtnResetPeopleOut_Click1" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <fieldset>
                                    <legend>
                                        <asp:Label ID="Label5" runat="server" Text=""></asp:Label><asp:Label ID="Label10"
                                            runat="server" Text=""></asp:Label>计时工资详情</legend>
                                    <asp:GridView ID="Grid_Detail" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                        CssClass="GridViewStyle" Width="100%" AllowPaging="True" PageSize="20" GridLines="None"
                                        OnPageIndexChanging="Grid_Detail_PageIndexChanging">
                                        <RowStyle CssClass="GridViewRowStyle" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                        <HeaderStyle CssClass="GridViewHead" />
                                        <FooterStyle CssClass="GridViewFooterStyle" />
                                        <Columns>
                                            <asp:BoundField DataField="WOD_OutTime" HeaderText="时间" SortExpression="WOD_OutTime">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRDD_StaffNO" HeaderText="工号" SortExpression="HRDD_StaffNO">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HRDD_Name" HeaderText="姓名" SortExpression="HRDD_Name">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="PBC_Name" HeaderText="工序" SortExpression="PBC_Name">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="OT_IsRelated" HeaderText="是否与随工单相关" SortExpression="OT_IsRelated">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="STI_Name" HeaderText="计时项目" SortExpression="STI_Name">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="STI_UnitPrice" HeaderText="单价" SortExpression="STI_UnitPrice">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="OT_Time" HeaderText="时长/H" SortExpression="OT_Time">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="OT_Num" HeaderText="数量" SortExpression="OT_Num">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="PresentMoney" HeaderText="计时工资" SortExpression="PresentMoney">
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
                            <td colspan="6" align="center">
                                <asp:Button ID="Button1" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    Width="70px" OnClick="Button1_Click" />
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    

    <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel5" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="Label6" runat="server" Text=""></asp:Label>计时工资审核</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label2" runat="server" CssClass="STYLE2" Text="审核人："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 20%;" align="left">
                                <asp:TextBox ID="TextBox1" runat="server" Width="130px" MaxLength="10" Enabled="false"></asp:TextBox>
                                <asp:Label ID="Label20" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                    ControlToValidate="TextBox1" ValidationGroup="ShenHe"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label3" runat="server" CssClass="STYLE2" Text="审核时间："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 20%;" align="left">
                                <asp:TextBox ID="TxtETime" runat="server" Width="130px" onfocus="new  WdatePicker(this,'%Y-%M-%D %h:%m:%s',true)"
                                    Enabled="false"></asp:TextBox>
                                <asp:Label ID="Label11" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                    ControlToValidate="TxtETime" ValidationGroup="ShenHe"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label7" runat="server" CssClass="STYLE2" Text="审核结果："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 20%;" align="left">
                                <asp:DropDownList ID="DropDownList2" runat="server" ToolTip="单击选择" AutoPostBack="true">
                                    <asp:ListItem>通过</asp:ListItem>
                                    <asp:ListItem>不通过</asp:ListItem>
                                </asp:DropDownList>
                                <asp:Label ID="Label12" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                    ControlToValidate="DropDownList2" ValidationGroup="ShenHe"></asp:RequiredFieldValidator>--%>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label46" runat="server" CssClass="STYLE2" Text="审核意见:<br/>(200字内)"></asp:Label>
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="TxtRemarks" runat="server" Width="630px" Height="80px" TextMode="MultiLine"
                                    MaxLength="200" onkeyup="this.value = this.value.substring(0, 200)" onafterpaste="this.value = this.value.substring(0, 200)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="right">
                                <asp:Label ID="Label8" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Button ID="BtnSubmitChange" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    Width="70px" OnClick="BtnSubmitChange_Click" ValidationGroup="ShenHe" />
                            </td>
                            <td colspan="2" align="center">
                            </td>
                            <td colspan="2" align="left">
                                <asp:Button ID="BtnCancelChange" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    Visible="true" Width="70px" OnClick="BtnCancelChange_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
