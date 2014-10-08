<%@ Page Title="新员工培训结果录入" Language="C#" MasterPageFile="~/Other/MasterPage.master"
    AutoEventWireup="true" CodeFile="NewEmpScoreInput.aspx.cs" Inherits="TrainningMgt_NewEmpScoreInput" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
    <style type="text/css">
        .hidden
        {
            display: none;
        }
    </style>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server">
                <fieldset>
                    <legend>新员工培训信息检索栏</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="LblItem" runat="server" CssClass="STYLE2" Text="培训课程:"></asp:Label>
                            </td>
                            <td style="height: 20%">
                                <asp:TextBox ID="TxtSCourse" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="LblCourse" runat="server" CssClass="STYLE2" Text="培训类型:"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtSType" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="LblDep" runat="server" CssClass="STYLE2" Text="授课部门:"></asp:Label>
                            </td>
                            <td style="height: 20%">
                                <asp:TextBox ID="TxtSDep" runat="server" Width="130px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="LblSPerson" runat="server" CssClass="STYLE2" Text="新建人："></asp:Label>
                            </td>
                            <td style="width: 15%; height: 20%;" align="left">
                                <asp:TextBox ID="TxtSPerson" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="LblSStartTime" runat="server" CssClass="STYLE2" Text="新建时间："></asp:Label>
                            </td>
                            <td style="width: 15%; height: 20%;" align="left" colspan="2">
                                <asp:TextBox ID="TxtSStartTime" runat="server" Width="130px" onfocus="new  WdatePicker(this,'%Y-%M-%D %h:%m:%s',true)"></asp:TextBox>
                                <asp:Label ID="LblEndTime" runat="server" CssClass="STYLE2" Text="至"></asp:Label>
                                <asp:TextBox ID="TxtSEndTime" runat="server" Width="130px" onfocus="new  WdatePicker(this,'%Y-%M-%D %h:%m:%s',true)"></asp:TextBox>
                            </td>
                            <td style="width: 15%; height: 20%;" align="left">
                                <asp:Label ID="Label5" runat="server" Text="状态："></asp:Label><asp:DropDownList ID="DropDownList2"
                                    runat="server">
                                    <asp:ListItem>请选择</asp:ListItem>
                                    <asp:ListItem>待提交</asp:ListItem>
                                    <asp:ListItem>待录入</asp:ListItem>
                                    <asp:ListItem>已完成</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td align="right" colspan="2">
                                <asp:Label ID="LblRecordIsSearch" runat="server" Visible="false"></asp:Label>
                                <asp:Button ID="BtnSearch" runat="server" CssClass="Button02" Height="24px" Text="检索"
                                    Width="70px" OnClick="BtnSearch_Click" />
                            </td>
                            <td align="center">
                            </td>
                            <td align="center" colspan="3">
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
                    <legend>新员工培训信息列表</legend>
                    <asp:GridView ID="GridView_Info" runat="server" DataKeyNames="NETICT_ID" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                        AllowPaging="True" PageSize="10" Font-Strikeout="False" UseAccessibleHeader="False"
                        GridLines="None" OnDataBound="GridView_Info_DataBound" OnPageIndexChanging="GridView_Info_PageIndexChanging"
                        OnRowCommand="GridView_Info_RowCommand">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="NETICT_ID" HeaderText="新员工培训项目选择ID" ReadOnly="True" SortExpression="NETICT_ID"
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
                            <asp:BoundField DataField="NETIMT_Person" HeaderText="新建人" SortExpression="NETIMT_Person">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="NETIMT_Time" HeaderText="新建时间" SortExpression="NETIMT_Time">
                                <ItemStyle />
                            </asp:BoundField>
                             <asp:BoundField DataField="NETICT_State" HeaderText="状态" SortExpression="NETICT_State">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnInputScore" runat="server" CommandArgument='<%#Eval("NETICT_ID")%>'
                                        CommandName="EditInputScore" OnClientClick="false">录入培训结果</asp:LinkButton>
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
    <asp:UpdatePanel ID="UpdatePane3" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel3" runat="server" Visible="false">
                <fieldset>
                    <legend>新员工培训结果录入栏</legend>
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 15%" align="center">
                                <asp:Label ID="LblRecordNETICT_ID" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Label ID="Label64" runat="server" CssClass="STYLE2" Text="培训开始时间："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtSTime" runat="server" Width="130px" onfocus="new  WdatePicker(this,'%Y-%M-%D %h:%m:%s',true)"></asp:TextBox>
                                <asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ErrorMessage="*" ControlToValidate="TxtSTime" ValidationGroup="Input"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label65" runat="server" CssClass="STYLE2" Text="培训结束时间："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtETime" runat="server" Width="130px" onfocus="new  WdatePicker(this,'%Y-%M-%D %h:%m:%s',true)"></asp:TextBox>
                                <asp:Label ID="Label3" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ErrorMessage="*" ControlToValidate="TxtETime" ValidationGroup="Input"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td style="width: 10%; height: 15px;" align="center">
                                <asp:Label ID="Label2" runat="server" CssClass="STYLE2" Text="授课地点："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TextBox1" runat="server" Width="130px" MaxLength="20"></asp:TextBox>
                                <asp:Label ID="Label4" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                    ErrorMessage="*" ControlToValidate="TextBox1" ValidationGroup="Input"></asp:RequiredFieldValidator>--%>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <fieldset>
                                    <legend>新员工培训的人员列表</legend>
                                    <asp:GridView ID="GridView_People" runat="server" DataKeyNames="NETPCT_ID" AllowSorting="True"
                                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                                        AllowPaging="False" Font-Strikeout="False" UseAccessibleHeader="False" GridLines="None">
                                        <RowStyle CssClass="GridViewRowStyle" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                        <HeaderStyle CssClass="GridViewHead" />
                                        <FooterStyle CssClass="GridViewFooterStyle" />
                                        <Columns>
                                            <asp:BoundField DataField="NETPCT_ID" HeaderText="培训人员选择ID" ReadOnly="True" SortExpression="NETPCT_ID">
                                                <FooterStyle CssClass="hidden" />
                                                <HeaderStyle CssClass="hidden" />
                                                <ItemStyle CssClass="hidden" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="NETPCT_Name" HeaderText="姓名" SortExpression="NETPCT_Name">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="NETPCT_Sex" HeaderText="姓别" SortExpression="NETPCT_Sex">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="NETPCT_Date" HeaderText="报到日期" SortExpression="NETPCT_Date"
                                                HtmlEncode="False" DataFormatString="{0:yy-MM-dd}">
                                                <ItemStyle />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="是否合格">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="DropDownList1" runat="server">
                                                        <asp:ListItem>是</asp:ListItem>
                                                        <asp:ListItem>否</asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="简单说明">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="TxtRemarks" runat="server" Width="100%" MaxLength="100"></asp:TextBox>
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
                        <tr>
                            <td align="right" colspan="2">
                                <asp:Button ID="BtnOK" runat="server" CssClass="Button02" Height="24px" Text="提交"
                                    Width="70px" ValidationGroup="Input" OnClick="BtnOK_Click" />
                            </td>
                            <td align="center" colspan="2">
                                &nbsp;
                            </td>
                            <td align="left" colspan="2">
                                <asp:Button ID="Btnclose" runat="server" CssClass="Button02" Height="24px" Text="关闭"
                                    Visible="true" Width="70px" OnClick="Btnclose_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
