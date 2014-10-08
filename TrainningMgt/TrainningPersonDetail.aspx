<%@ Page Title="" Language="C#" MasterPageFile="~/other/MasterPage.master" AutoEventWireup="true"
    CodeFile="TrainningPersonDetail.aspx.cs" Inherits="TrainningMgt_TrainningPersonDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                                <asp:Label ID="Label2" runat="server" CssClass="STYLE2" Text="年份："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtSYear" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label1" runat="server" CssClass="STYLE2" Text="月份："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtSMonth" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label13" runat="server" CssClass="STYLE2" Text="培训类型："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtSType" runat="server" Width="130px"></asp:TextBox>
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
                                <asp:Label ID="Label5" runat="server" CssClass="STYLE2" Text="培训讲师："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtSTeacher" runat="server" Width="130px"></asp:TextBox>
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
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label6" runat="server" CssClass="STYLE2" Text="员工工号："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtNO" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label7" runat="server" CssClass="STYLE2" Text="员工姓名："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TxtName" runat="server" Width="130px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label55" runat="server" CssClass="STYLE2" Text="培训时间："></asp:Label>
                            </td>
                            <td style="width: 20%" colspan="3">
                                <asp:TextBox ID="TextBox11" runat="server" Width="130px" onfocus="new  WdatePicker(this,'%Y-%M-%D',false)"></asp:TextBox>至<asp:TextBox
                                    ID="TextBox12" runat="server" Width="130px" onfocus="new  WdatePicker(this,'%Y-%M-%D',false)"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                            </td>
                            <td style="width: 20%">
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td align="right" colspan="2">
                                <asp:Label ID="LblRecordIsSearch" runat="server" Text="检索前" Visible="false"></asp:Label>
                                <asp:Label ID="LblCondition" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Button ID="BtnSearch" runat="server" CssClass="Button02" Height="24px" Text="检索"
                                    Width="70px" OnClick="BtnSearch_Click" />
                            </td>
                            <td align="center" colspan="2">
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
                    <legend>培训详情</legend>
                    <asp:GridView ID="GridView_People" runat="server" PageSize="20" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                        AllowPaging="True" Font-Strikeout="False" UseAccessibleHeader="False" GridLines="None"
                        OnPageIndexChanging="GridView_People_PageIndexChanging" 
                        ondatabound="GridView_People_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="HRDD_StaffNO" HeaderText="工号" SortExpression="HRDD_StaffNO">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="HRDD_Name" HeaderText="姓名" SortExpression="HRDD_Name">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="TYPM_Year" HeaderText="年份" SortExpression="TYPM_Year">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="TID_Month" HeaderText="月份" SortExpression="TID_Month">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="TID_TLesson" HeaderText="培训项目" SortExpression="TID_TLesson">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="TTT_Type" HeaderText="培训类型" SortExpression="TTT_Type">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="TID_Teacher" HeaderText="讲师" SortExpression="TID_Teacher">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="TID_Place" HeaderText="地点" SortExpression="TID_Place">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="TID_CreditHours" HeaderText="学时" SortExpression="TID_CreditHours">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="TID_PTime" HeaderText="开始时间" SortExpression="TID_PTime">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="TID_ActTime" HeaderText="结束时间" SortExpression="TID_ActTime">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="TEER_Result" HeaderText="结果" SortExpression="TEER_Result">
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
                </td> </tr> </table> </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
