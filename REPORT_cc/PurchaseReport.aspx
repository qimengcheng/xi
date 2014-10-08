<%@ Page Title="" Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true" CodeFile="PurchaseReport.aspx.cs" Inherits="Laputa_PurchaseReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>

            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:Panel ID="Panel1" runat="server">
                <fieldset>
                    <legend> 采购信息检索
             
                
                    </legend>
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 21px">年: </td>
                            <td style="width: 66px">
                                <asp:DropDownList ID="DropDownList1" runat="server">
                                    <asp:ListItem Value="999">所有年份</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="width: 22px">&nbsp;月:</td>
                            <td style="width: 63px">
                                <asp:DropDownList ID="DropDownList2" runat="server">
                                    <asp:ListItem Value="999">所有月份</asp:ListItem>
                                    <asp:ListItem>1</asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>3</asp:ListItem>
                                    <asp:ListItem>4</asp:ListItem>
                                    <asp:ListItem>5</asp:ListItem>
                                    <asp:ListItem>6</asp:ListItem>
                                    <asp:ListItem>7</asp:ListItem>
                                    <asp:ListItem>8</asp:ListItem>
                                    <asp:ListItem>9</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                    <asp:ListItem>11</asp:ListItem>
                                    <asp:ListItem>12</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="width: 73px" > &nbsp;</td>
                            <td style="width: 110px" >
                                <asp:Button ID="Search" runat="server" CssClass="Button02" OnClick="Search_Click" Text=" 检索 " Width="66px" />
                            </td>
                            <td style="width: 22px" > &nbsp;</td>
                            <td style="width: 63px" >
                                <asp:Button ID="Button4" runat="server" CssClass="Button02" OnClick="print" Text="打印报表" Width="70px" />
                            </td>
                            <td style="width: 45px" > 
                                &nbsp;</td>
                            <td style="width: 125px">
                                <asp:Button ID="reset" runat="server" CssClass="Button02" OnClick="reset_Click" Text=" 重置" Width="66px" />
                            </td>
                            <td style="width: 127px">
                                &nbsp;</td>
                            <td >
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

   

 

    <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel5" runat="server" Visible="False">
                <fieldset>
                    <legend>采购详情</legend>
                    <asp:GridView ID="GridView3" runat="server" CssClass="GridViewStyle"  AllowPaging="True" AutoGenerateColumns="True" 
                                  GridLines="None" EmptyDataText=" 没有相关记录 "  OnPageIndexChanging="GridView3_PageIndexChanging" OnRowDataBound="GridView3_RowDataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                           
                           


                           
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第<asp:Label ID="lblPageIndex" runat="server" Text='<%# ((GridView) Container.Parent.Parent).PageIndex + 1 %>' />
                                        页 共 <asp:Label ID="lblPageCount" runat="server" Text='<%# ((GridView) Container.Parent.Parent).PageCount %>' />
                                        页
                                        <asp:LinkButton ID="btnFirst" runat="server" CausesValidation="False" CommandArgument="First"
                                                        CommandName="Page" Text="首页 " />
                                        <asp:LinkButton ID="btnPrev" runat="server" CausesValidation="False" CommandArgument="Prev"
                                                        CommandName="Page" Text="上一页 " />
                                        <asp:LinkButton ID="btnNext" runat="server" CausesValidation="False" CommandArgument="Next"
                                                        CommandName="Page" Text="下一页 " />
                                        <asp:LinkButton ID="btnLast" runat="server" CausesValidation="False" CommandArgument="Last"
                                                        CommandName="Page" Text="尾页 " />
                                        <asp:TextBox ID="textbox" runat="server" Width="20px"></asp:TextBox>
                                        <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                                        CommandName="Page" Text="GO" /><!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
                                    </td>
                                </tr>
                            </table>
                        </PagerTemplate>
                    </asp:GridView>
                    </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel runat="server" ID="UpdatePanel2">
        <ContentTemplate>
             <asp:Panel runat="server" ID="panelGraph" Visible="True" >
        <fieldset>
            <legend>趋势图</legend>
            <div style="text-align: center">
        <asp:Chart ID="Chart1" runat="server" OnLoad="Chart1_Load" Width="750px" BackImageAlignment="Center"  BorderlineWidth="20" Palette="None"  PaletteCustomColors="DeepSkyBlue; YellowGreen; Gold; DeepSkyBlue; YellowGreen; Gold" Height="300px" >
            <series>
                <asp:Series ChartType="Line" IsValueShownAsLabel="True" Name="采购金额" LabelForeColor="DimGray"  MarkerBorderColor="SkyBlue" MarkerSize="8" MarkerStyle="Circle" Font="微软雅黑, 8.25pt" Legend="Legend1">
                </asp:Series>
               
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1" BackImageTransparentColor="Gainsboro">
                    <AxisY LineColor="DimGray" IsLabelAutoFit="False" Title="采购金额(元)" TitleFont="微软雅黑, 12px" TitleForeColor="DimGray">
                        <MajorGrid LineColor="DarkGray" LineDashStyle="Dash" />
                        <MajorTickMark LineColor="" />
                        <LabelStyle Font="微软雅黑, 8.25pt" ForeColor="DimGray" />
                    </AxisY>
                    <AxisX LineColor="DimGray" IsLabelAutoFit="False" Title="月" TitleFont="微软雅黑, 12px" TitleForeColor="DimGray">
                        <MajorGrid LineColor="DarkGray" LineDashStyle="Dash" />
                        <LabelStyle Font="微软雅黑, 8.25pt" ForeColor="DimGray" />
                    </AxisX>
                    <AxisX2 TitleFont="微软雅黑, 8.25pt">
                    </AxisX2>
                    <AxisY2 TitleFont="微软雅黑, 8.25pt">
                    </AxisY2>
                </asp:ChartArea>
              
            </chartareas>
          
            <Legends>
                <asp:Legend Font="微软雅黑, 8.25pt" ForeColor="DimGray" IsTextAutoFit="False" Name="Legend1" TitleFont="微软雅黑, 8.25pt, style=Bold" TitleForeColor="DimGray" TitleSeparatorColor="BlanchedAlmond">
                </asp:Legend>
            </Legends>
            <Titles>
                <asp:Title Font="微软雅黑, 20px" ForeColor="64, 64, 64" Name="Title1" Text="采购金额对比趋势图">
                </asp:Title>
            </Titles>
        </asp:Chart>
    </div>
    </fieldset>
    </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>