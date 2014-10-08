<%@ Page Title="实验数据统计表" Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true" CodeFile="ExpTest.aspx.cs" Inherits="REPORT_cc_ExpTest" %>

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
                    <legend>实验申请检索栏</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 13%; height: 15px;" align="center">
                                <asp:Label ID="Label4" runat="server" Text="产品标识："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 15px;">
                                <asp:TextBox ID="TextProIdentify" runat="server" Width="155px"></asp:TextBox>
                            </td>
                            <td style="width: 10%; height: 15px;" align="center">
                                <asp:Label ID="Label2" runat="server" Text="样品类型："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 15px;">
                                <asp:DropDownList ID="DropDownList1" runat="server" Height="20px" Width="150px"></asp:DropDownList>
                            </td>
                            <td style="width: 10%; height: 15px;" align="center">
                                <asp:Label ID="Label1" runat="server" Text="申请部门："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 15px;">
                                <asp:DropDownList ID="DropDownList2" runat="server" Height="20px" Width="150px"></asp:DropDownList>
                            </td>

                        </tr>
                        <tr>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label5" runat="server" Text="紧急程度："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:DropDownList ID="DropDownList3" runat="server" Height="20px" Width="150px">
                                    <asp:ListItem Value="" Text="请选择"></asp:ListItem>
                                    <asp:ListItem Value="一般" Text="一般"></asp:ListItem>
                                    <asp:ListItem Value="紧急" Text="紧急"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label6" runat="server" Text="实验项目："></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TextExpItem" runat="server" Width="155px"></asp:TextBox>
                            </td>
                            <td style="width: 10%; height: 15px;" align="center">
                                <asp:Label ID="Label3" runat="server" Text="判定："></asp:Label>
                            </td>
                            <td style="width: 20%; height: 15px;">
                                <asp:DropDownList ID="DropDownList4" runat="server" Height="20px" Width="150px">
                                    <asp:ListItem Value="" Text="请选择"></asp:ListItem>
                                    <asp:ListItem Value="合格" Text="合格"></asp:ListItem>
                                    <asp:ListItem Value="不合格" Text="不合格"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr style="height: 16px;">
                            <td style="width: 10%" align="center">
                                    <asp:Label ID="Label111" runat="server" Text="申请时间："></asp:Label>
                                </td>
                                </td>
                                <td>
                                    <asp:TextBox ID="startime" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',false)"
                                        DataFormatString="{0:yyyy-MM-dd}" Width="155px"></asp:TextBox>
                                </td>
                                <td align="center">
                                    <asp:Label ID="Label112" runat="server" Text="至"></asp:Label>
                                </td>
                                <td >
                                    <asp:TextBox ID="endtime" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',false)"
                                        DataFormatString="{0:yyyy-MM-dd}" Width="155px"></asp:TextBox>
                                </td>
                                <td></td>
                                <td></td>
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
                    <legend>实验数据统计表</legend>
                    <asp:GridView ID="Grid_Detail" runat="server" AllowSorting="True" PageSize="20" AutoGenerateColumns="False" CssClass="GridViewStyle" Width="100%" 
                        AllowPaging="true"  GridLines="None" OnPageIndexChanging="Grid_Detail_PageIndexChanging" OnDataBound="Grid_Detail_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:TemplateField HeaderText="序号">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ETA_ExpAppNO" HeaderText="申请单号" SortExpression="ETA_ExpAppNO">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="ETA_AppTime" HeaderText="申请时间" SortExpression="ETA_AppTime">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="ETA_ProIdentify" HeaderText="产品标识" SortExpression="ETA_ProIdentify">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="EST_SampleType" HeaderText="样品类型" SortExpression="EST_SampleType">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="ETA_AppDep" HeaderText="申请部门" SortExpression="ETA_AppDep">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="ETA_EmergDegree" HeaderText="紧急程度" SortExpression="ETA_EmergDegree">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="EI_ExpItem" HeaderText="测试项目" SortExpression="EI_ExpItem">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="EIR_ItemAmount" HeaderText="测试数量" SortExpression="EIR_ItemAmount">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="EIR_ItemAcceptance" HeaderText="合格数量" SortExpression="EIR_ItemAcceptance">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="EIR_ItemRes" HeaderText="判定" SortExpression="EIR_ItemRes">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="EIR_Remaks" HeaderText="备注" SortExpression="EIR_Remaks">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="ETA_ResInstruction" HeaderText="结果说明" SortExpression="ETA_ResInstruction">
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
                                        <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                            CommandName="Page" Text="GO" />
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

</asp:Content>
