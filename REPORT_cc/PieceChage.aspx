﻿<%@ Page Title="计件工价变动表" MasterPageFile="~/Other/MasterPage.master" Language="C#" AutoEventWireup="true" CodeFile="PieceChage.aspx.cs" Inherits="REPORT_cc_PieceChage" %>

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
                    <legend>计件信息检索栏</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 13%; height: 15px;" align="center">
                                <asp:Label ID="Label1" runat="server" Text="工序："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 15px;">
                                <asp:TextBox ID="textgongxu" runat="server" Width="155px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label6" runat="server" Text="计件系列："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                 <asp:TextBox ID="textxilie" runat="server" Width="155px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label2" runat="server" Text="计件项目："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="textxiangmu" runat="server" Width="155px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 13%; height: 15px;" align="center">
                                <asp:Label ID="Label3" runat="server" Text="执行日期："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 15px;">
                                <asp:TextBox ID="laststar" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',false)"
                                        DataFormatString="{0:yyyy-MM-dd}" Width="155px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label4" runat="server" Text="到"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                 <asp:TextBox ID="lastend" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',false)"
                                        DataFormatString="{0:yyyy-MM-dd}" Width="155px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                            </td>
                            <td>
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
                    <legend>计件工价变动表</legend>
                    <asp:GridView ID="Grid_Detail" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="GridViewStyle" Width="100%" 
                        AllowPaging="true"  GridLines="None" onrowcreated="Grid_Detail_RowCreated" OnPageIndexChanging="Grid_Detail_PageIndexChanging" PageSize="20">
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
                        <asp:BoundField DataField="PBC_Name" SortExpression="PBC_Name">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="SPS_Name" SortExpression="SPS_Name">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="SPI_Name" SortExpression="SPI_Name">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="now" SortExpression="now">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="SPICR_FormerPrice" SortExpression="SPICR_FormerPrice">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="SPICR_NewPrice" SortExpression="SPICR_NewPrice">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="chae" SortExpression="chae">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="bilv" SortExpression="bilv">
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
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

    

</asp:Content>

