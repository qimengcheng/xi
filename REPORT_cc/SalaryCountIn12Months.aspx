<%@ Page Title="年度薪资分析表" MasterPageFile="~/Other/MasterPage.master" Language="C#" AutoEventWireup="true" CodeFile="SalaryCountIn12Months.aspx.cs" Inherits="REPORT_cc_SalaryCountIn12Months" %>

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
                            <td style="width: 13%; height: 15px;" align="center">
                                <asp:Label ID="Label1" runat="server" Text="统计年份："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 15px;">
                                <asp:TextBox ID="textyear" runat="server" Width="155px" onkeyup="this.value=this.value.replace(/[^0-9]/g,'')" 
                                     onafterpaste="this.value=this.value.replace(/[^[0-9]/g,'')" MaxLength="4"></asp:TextBox>
                            </td>
                            <td style="width: 10%; height: 15px;" align="center">
                             <asp:Label ID="Label4" runat="server" CssClass="STYLE2" Text="部门："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 15px;">
                                 <asp:DropDownList ID="DdlSDep" runat="server" ToolTip="单击选择" AutoPostBack="true"
                                        OnSelectedIndexChanged="DdlSDep_SelectedIndexChanged">
                                    </asp:DropDownList>
                            </td>
                            <td style="width: 10%; height: 15px;" align="center">
                                <asp:Label ID="Label5" runat="server" CssClass="STYLE2" Text="岗位："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 15px;">
                                <asp:DropDownList ID="DdlSPost" runat="server" ToolTip="单击选择">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="right">
                                <asp:Button ID="BtnSearch" runat="server" CssClass="Button02" Height="24px" Text="检索"
                                    Width="70px" OnClick="BtnSearch_Click" />
                            </td>
                            <td  colspan="2" align="center">
                                <asp:Button ID="BtnPrint" runat="server" CssClass="Button02" Height="24px" Text="打印报表" Width="90px" OnClick="BtnPrint_Click" ToolTip="点击此处,跳转打印页面。"/>
                            </td>
                            <td  colspan="2">
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
                    <legend>年度薪资分析表</legend>
                    <div id="grid" style="overflow:auto; width:100%">
                    <asp:GridView ID="Grid_Detail" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="GridViewStyle" Width="400%"
                        AllowPaging="true"  GridLines="None" onrowcreated="Grid_Detail_RowCreated" OnPageIndexChanging="Grid_Detail_PageIndexChanging" PageSize="15" 
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
                        <asp:BoundField DataField="岗位" HeaderText="岗位" SortExpression="岗位">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="工时1" SortExpression="工时1">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="人数1" SortExpression="人数1">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="计件工资1" SortExpression="计件工资1">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="计时工资1" SortExpression="计时工资1">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="总应发工资1" SortExpression="总应发工资1">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="工时2" SortExpression="工时2">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="人数2" SortExpression="人数2">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="计件工资2" SortExpression="计件工资2">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="计时工资2" SortExpression="计时工资2">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="总应发工资2" SortExpression="总应发工资2">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="工时3" SortExpression="工时3">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="人数3" SortExpression="人数3">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="计件工资3" SortExpression="计件工资3">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="计时工资3" SortExpression="计时工资3">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="总应发工资3" SortExpression="总应发工资3">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="工时4" SortExpression="工时4">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="人数4" SortExpression="人数4">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="计件工资4" SortExpression="计件工资4">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="计时工资4" SortExpression="计时工资4">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="总应发工资4" SortExpression="总应发工资4">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="工时5" SortExpression="工时5">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="人数5" SortExpression="人数5">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="计件工资5" SortExpression="计件工资5">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="计时工资5" SortExpression="计时工资5">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="总应发工资5" SortExpression="总应发工资5">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="工时6" SortExpression="工时6">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="人数6" SortExpression="人数6">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="计件工资6" SortExpression="计件工资6">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="计时工资6" SortExpression="计时工资6">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="总应发工资6" SortExpression="总应发工资6">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="工时7" SortExpression="工时7">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="人数7" SortExpression="人数7">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="计件工资7" SortExpression="计件工资7">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="计时工资7" SortExpression="计时工资7">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="总应发工资7" SortExpression="总应发工资7">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="工时8" SortExpression="工时8">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="人数8" SortExpression="人数8">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="计件工资8" SortExpression="计件工资8">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="计时工资8" SortExpression="计时工资8">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="总应发工资8" SortExpression="总应发工资8">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="工时9" SortExpression="工时9">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="人数9" SortExpression="人数9">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="计件工资9" SortExpression="计件工资9">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="计时工资9" SortExpression="计时工资9">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="总应发工资9" SortExpression="总应发工资9">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="工时10" SortExpression="工时10">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="人数10" SortExpression="人数10">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="计件工资10" SortExpression="计件工资10">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="计时工资10" SortExpression="计时工资10">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="总应发工资10" SortExpression="总应发工资10">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="工时11" SortExpression="工时11">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="人数11" SortExpression="人数11">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="计件工资11" SortExpression="计件工资11">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="计时工资11" SortExpression="计时工资11">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="总应发工资11" SortExpression="总应发工资11">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="工时12" SortExpression="工时12">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="人数12" SortExpression="人数12">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="计件工资12" SortExpression="计件工资12">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="计时工资12" SortExpression="计时工资12">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="总应发工资12" SortExpression="总应发工资12">
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