<%@ Page Title="年度中层管理干部绩效考核统计表" MasterPageFile="~/Other/MasterPage.master" Language="C#" AutoEventWireup="true" CodeFile="PerformceDetail.aspx.cs" Inherits="REPORT_cc_PerformceDetail" %>

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
                            <td style="width: 13%" align="center">
                                <asp:Label ID="Label4" runat="server" Text="统计年份："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="textyear" runat="server" Width="155px" onkeyup="this.value=this.value.replace(/[^0-9]/g,'')" 
                                     onafterpaste="this.value=this.value.replace(/[^[0-9]/g,'')" MaxLength="4"></asp:TextBox>
                            </td>
                            <td style="width: 10%; height: 15px;" align="center">
                                <asp:Label ID="Label2" runat="server" Text="工号："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 15px;">
                                <asp:TextBox ID="textno" runat="server" Width="155px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label3" runat="server" Text="姓名："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                 <asp:TextBox ID="textname" runat="server" Width="155px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 13%; height: 15px;" align="center">
                                <asp:Label ID="Label5" runat="server" Text="部门："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 15px;">
                                <asp:TextBox ID="textdep" runat="server" Width="155px"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label7" runat="server" Text="岗位："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                 <asp:TextBox ID="textpost" runat="server" Width="155px"></asp:TextBox>
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
                    <legend>中干绩效考核统计表</legend>
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
                        <asp:BoundField DataField="HRDD_StaffNO"  SortExpression="HRDD_StaffNO">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="HRDD_Name" SortExpression="HRDD_Name">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="BDOS_Name" SortExpression="BDOS_Name">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="HRP_Post" SortExpression="HRP_Post">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="result1" SortExpression="result1">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="result2" SortExpression="result2">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="result3" SortExpression="result3">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="result4" SortExpression="result4">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="result5" SortExpression="result5">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="result6" SortExpression="result6">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="result7" SortExpression="result7">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="result8" SortExpression="result8">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="result9" SortExpression="result9">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="result10" SortExpression="result10">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="result11" SortExpression="result11">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="result12" SortExpression="result12">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="avgresult" SortExpression="avgresult">
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

