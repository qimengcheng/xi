<%@ Page Title="销售分析表" MasterPageFile="~/Other/MasterPage.master" Language="C#" AutoEventWireup="true" CodeFile="SaleAnalysis.aspx.cs" Inherits="REPORT_cc_SaleAnalysis" %>

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
                    <legend>销售信息检索栏</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 17%; height: 15px;" align="center">
                            </td>
                            <td style="width: 10%; height: 15px;" align="center">
                                <asp:Label ID="Label1" runat="server" Text="统计年份："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 15px;">
                                <asp:TextBox ID="textyear" runat="server" Width="155px" onkeyup="this.value=this.value.replace(/[^0-9]/g,'')" 
                                     onafterpaste="this.value=this.value.replace(/[^[0-9]/g,'')" MaxLength="4"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label6" runat="server" Text="客户名称："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                 <asp:TextBox ID="textname" runat="server" Width="155px"></asp:TextBox>
                            </td>
                            <td style="height: 15px;" align="center">
                            </td>
                        </tr>
                        <tr>
                        <td align="right" colspan="2">
                            <asp:Button ID="BtnSearch" runat="server" CssClass="Button02" Height="24px" Text="检索"
                                Width="70px" OnClick="BtnSearch_Click" />
                        </td>
                        <td align="center" colspan="2">
                            <asp:Button ID="BtnPrint" runat="server" CssClass="Button02" Height="24px" Text="打印报表" Width="90px" OnClick="BtnPrint_Click" ToolTip="点击此处,跳转打印页面。"/>
                        </td>
                        <td align="left" colspan="2">
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
            <asp:Panel ID="Panel_Grid" runat="server">
                <fieldset>
                    <legend>销售分析表</legend>
                    <div id="grid" style="overflow:auto; width:100%;" >
                    <asp:GridView ID="Grid_Detail" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="GridViewStyle" Width="200%" 
                        AllowPaging="false"  GridLines="None" onrowcreated="Grid_Detail_RowCreated" OnPageIndexChanging="Grid_Detail_PageIndexChanging" PageSize="10">
                        <RowStyle CssClass="GridViewRowStyle"/>
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead"/>
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                        <asp:TemplateField HeaderText="序号" >
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1%>
                            </ItemTemplate>
                            <ItemStyle />
                        </asp:TemplateField>
                        <asp:BoundField DataField="CRMCIF_Name" HeaderText="客户名称" SortExpression="CRMCIF_Name">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="daoqi" HeaderText="到期应收货款" SortExpression="daoqi">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="chaoqi1" HeaderText="超期货款" SortExpression="chaoqi1">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="FaMonth1" SortExpression="FaMonth1">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="HuiMonth1" SortExpression="HuiMonth1">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="FaMonth2" SortExpression="FaMonth2">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="HuiMonth2" SortExpression="HuiMonth2">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="FaMonth3" SortExpression="FaMonth3">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="HuiMonth3" SortExpression="HuiMonth3">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="FaMonth4" SortExpression="FaMonth4">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="HuiMonth4" SortExpression="HuiMonth4">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="FaMonth5" SortExpression="FaMonth5">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="HuiMonth5" SortExpression="HuiMonth5">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="FaMonth6" SortExpression="FaMonth6">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="HuiMonth6" SortExpression="HuiMonth6">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="FaMonth7" SortExpression="FaMonth7">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="HuiMonth7" SortExpression="HuiMonth7">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="FaMonth8" SortExpression="FaMonth8">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="HuiMonth8" SortExpression="HuiMonth8">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="FaMonth9" SortExpression="FaMonth9">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="HuiMonth9" SortExpression="HuiMonth9">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="FaMonth10" SortExpression="FaMonth10">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="HuiMonth10" SortExpression="HuiMonth10">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="FaMonth11" SortExpression="FaMonth11">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="HuiMonth11" SortExpression="HuiMonth11">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="FaMonth12" SortExpression="FaMonth12">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="HuiMonth12" SortExpression="HuiMonth12">
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

