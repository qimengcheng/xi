<%@ Page Title="人员流失工龄年报表" MasterPageFile="~/Other/MasterPage.master" Language="C#" AutoEventWireup="true" CodeFile="QuitWorkAge.aspx.cs" Inherits="REPORT_cc_QuitWorkAge" %>

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
                    <legend>人员流失工龄年报表</legend>
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
                        <asp:BoundField DataField="试用期内1" SortExpression="试用期内1">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="三至六月1" SortExpression="三至六月1">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="六月至一年1" SortExpression="六月至一年1">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="一至二年1" SortExpression="一至二年1">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="二至五年1" SortExpression="二至五年1">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="五至十年1" SortExpression="五至十年1">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="十年以上1" SortExpression="十年以上1">
                            <ItemStyle />
                        </asp:BoundField>                        
                        <asp:BoundField DataField="试用期内2" SortExpression="试用期内2">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="三至六月2" SortExpression="三至六月2">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="六月至一年2" SortExpression="六月至一年2">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="一至二年2" SortExpression="一至二年2">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="二至五年2" SortExpression="二至五年2">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="五至十年2" SortExpression="五至十年2">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="十年以上2" SortExpression="十年以上2">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="试用期内3" SortExpression="试用期内3">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="三至六月3" SortExpression="三至六月3">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="六月至一年3" SortExpression="六月至一年3">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="一至二年3" SortExpression="一至二年3">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="二至五年3" SortExpression="二至五年3">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="五至十年3" SortExpression="五至十年3">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="十年以上3" SortExpression="十年以上3">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="试用期内4" SortExpression="试用期内4">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="三至六月4" SortExpression="三至六月4">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="六月至一年4" SortExpression="六月至一年4">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="一至二年4" SortExpression="一至二年4">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="二至五年4" SortExpression="二至五年4">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="五至十年4" SortExpression="五至十年4">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="十年以上4" SortExpression="十年以上4">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="试用期内5" SortExpression="试用期内5">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="三至六月5" SortExpression="三至六月5">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="六月至一年5" SortExpression="六月至一年5">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="一至二年5" SortExpression="一至二年5">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="二至五年5" SortExpression="二至五年5">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="五至十年5" SortExpression="五至十年5">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="十年以上5" SortExpression="十年以上5">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="试用期内6" SortExpression="试用期内6">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="三至六月6" SortExpression="三至六月6">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="六月至一年6" SortExpression="六月至一年6">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="一至二年6" SortExpression="一至二年6">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="二至五年6" SortExpression="二至五年6">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="五至十年6" SortExpression="五至十年6">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="十年以上6" SortExpression="十年以上6">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="试用期内7" SortExpression="试用期内7">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="三至六月7" SortExpression="三至六月7">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="六月至一年7" SortExpression="六月至一年7">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="一至二年7" SortExpression="一至二年7">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="二至五年7" SortExpression="二至五年7">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="五至十年7" SortExpression="五至十年7">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="十年以上7" SortExpression="十年以上7">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="试用期内8" SortExpression="试用期内8">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="三至六月8" SortExpression="三至六月8">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="六月至一年8" SortExpression="六月至一年8">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="一至二年8" SortExpression="一至二年8">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="二至五年8" SortExpression="二至五年8">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="五至十年8" SortExpression="五至十年8">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="十年以上8" SortExpression="十年以上8">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="试用期内9" SortExpression="试用期内9">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="三至六月9" SortExpression="三至六月9">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="六月至一年9" SortExpression="六月至一年9">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="一至二年9" SortExpression="一至二年9">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="二至五年9" SortExpression="二至五年9">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="五至十年9" SortExpression="五至十年9">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="十年以上9" SortExpression="十年以上9">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="试用期内10" SortExpression="试用期内10">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="三至六月10" SortExpression="三至六月10">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="六月至一年10" SortExpression="六月至一年10">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="一至二年10" SortExpression="一至二年10">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="二至五年10" SortExpression="二至五年10">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="五至十年10" SortExpression="五至十年10">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="十年以上10" SortExpression="十年以上10">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="试用期内11" SortExpression="试用期内11">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="三至六月11" SortExpression="三至六月11">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="六月至一年11" SortExpression="六月至一年11">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="一至二年11" SortExpression="一至二年11">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="二至五年11" SortExpression="二至五年11">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="五至十年11" SortExpression="五至十年11">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="十年以上11" SortExpression="十年以上11">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="试用期内12" SortExpression="试用期内12">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="三至六月12" SortExpression="三至六月12">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="六月至一年12" SortExpression="六月至一年12">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="一至二年12" SortExpression="一至二年12">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="二至五年12" SortExpression="二至五年12">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="五至十年12" SortExpression="五至十年12">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="十年以上12" SortExpression="十年以上12">
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