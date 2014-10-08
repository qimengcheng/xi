<%@ Page Title="人员流失率年报表" MasterPageFile="~/Other/MasterPage.master" Language="C#" AutoEventWireup="true" CodeFile="QuitCountPercent.aspx.cs" Inherits="REPORT_cc_QuitCountPercent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script language="javascript" type="text/javascript">
    </script>

    <asp:UpdatePanel ID="UpdatePanel_Search" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Search" runat="server">
                <fieldset>
                    <legend>检索栏</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 10%; height: 15px;" align="center">
                            </td>
                            <td style="width: 13%; height: 15px;" align="center">
                                <asp:Label ID="Label1" runat="server" Text="统计年份："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 15px;">
                                <asp:TextBox ID="textyear" runat="server" Width="155px" onkeyup="this.value=this.value.replace(/[^0-9]/g,'')" 
                                     onafterpaste="this.value=this.value.replace(/[^[0-9]/g,'')" MaxLength="4"></asp:TextBox>
                            </td>
                            <td style="width: 10%; height: 15px;" align="center">
                            </td>
                            <td style="width: 15%">
                                <asp:Button ID="BtnSearch" runat="server" CssClass="Button02" Height="24px" Text="检索"
                                    Width="70px" OnClick="BtnSearch_Click" />
                            </td>
                            <td style="width: 17%">
                                <asp:Button ID="BtnPrint" runat="server" CssClass="Button02" Height="24px" Text="打印报表" Width="90px" OnClick="BtnPrint_Click" ToolTip="点击此处,跳转打印页面。"/>
                            </td>
                            <td>
                                 <asp:Button ID="BtnReset" runat="server" CssClass="Button02" Height="24px" Text="重置"
                                    Visible="true" Width="70px" OnClick="BtnReset_Click"/>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

<asp:UpdatePanel ID="UpdatePanel_Grid" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
           <%-- <asp:Panel ID="Panel_Grid" runat="server" ScrollBars="Auto">--%>
            <asp:Panel ID="Panel_Grid" runat="server">
                <fieldset>
                    <legend>人员流失率年报表</legend>
                    <div id="grid" style="overflow:auto; width:100%">
                    <asp:GridView ID="Grid_Detail" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="GridViewStyle" Width="200%"
                        AllowPaging="true"  GridLines="None" onrowcreated="Grid_Detail_RowCreated" OnPageIndexChanging="Grid_Detail_PageIndexChanging" PageSize="10" 
                        >
                        <RowStyle CssClass="GridViewRowStyle"/>
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead"/>
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                        <asp:TemplateField HeaderText="序号" HeaderStyle-Width="5%">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1%>
                            </ItemTemplate>
                            <ItemStyle />
                        </asp:TemplateField>
                        <asp:BoundField DataField="部门" HeaderText="部门" SortExpression="部门">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="岗位" SortExpression="岗位">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="总人数1" SortExpression="总人数1">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="离职人数1" SortExpression="离职人数1">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="离职率1" SortExpression="离职率1">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="总人数2" SortExpression="总人数2">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="离职人数2" SortExpression="离职人数2">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="离职率2" SortExpression="离职率2">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="总人数3" SortExpression="总人数3">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="离职人数3" SortExpression="离职人数3">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="离职率3" SortExpression="离职率3">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="总人数4" SortExpression="总人数4">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="离职人数4" SortExpression="离职人数4">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="离职率4" SortExpression="离职率4">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="总人数5" SortExpression="总人数5">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="离职人数5" SortExpression="离职人数5">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="离职率5" SortExpression="离职率5">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="总人数6" SortExpression="总人数6">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="离职人数6" SortExpression="离职人数6">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="离职率6" SortExpression="离职率6">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="总人数7" SortExpression="总人数7">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="离职人数7" SortExpression="离职人数7">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="离职率7" SortExpression="离职率7">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="总人数8" SortExpression="总人数8">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="离职人数8" SortExpression="离职人数8">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="离职率8" SortExpression="离职率8">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="总人数9" SortExpression="总人数9">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="离职人数9" SortExpression="离职人数9">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="离职率9" SortExpression="离职率9">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="总人数10" SortExpression="总人数10">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="离职人数10" SortExpression="离职人数10">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="离职率10" SortExpression="离职率10">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="总人数11" SortExpression="总人数11">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="离职人数11" SortExpression="离职人数11">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="离职率11" SortExpression="离职率11">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="总人数12" SortExpression="总人数12">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="离职人数12" SortExpression="离职人数12">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="离职率12" SortExpression="离职率12">
                            <ItemStyle />
                        </asp:BoundField>
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第<asp:Label ID="lblPageIndex" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>' />
                                        页 共<asp:Label ID="lblPageCount" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />
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
                            <asp:Label ID="Label16" runat="server" Text="没有找到相关记录" ></asp:Label>
                        </EmptyDataTemplate>
                        <EditRowStyle BackColor="white" />
                    </asp:GridView>
                    <br />
                    </div>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>


 </asp:Content>