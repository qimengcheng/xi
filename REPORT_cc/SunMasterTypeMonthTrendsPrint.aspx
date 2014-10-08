<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SunMasterTypeMonthTrendsPrint.aspx.cs" Inherits="Laputa_SunMasterTypeMonthTrendsSeriesPrint " 
    EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../css/style.css" rel="stylesheet" />
        <script type="text/javascript"  src="../My97DatePicker/WdatePicker.js"></script>
    <style type="text/css">
        .auto-style1 {
            width: 67px;
        }
        .auto-style2 {
            width: 197px;
        }
        .auto-style3 {
            width: 45px;
        }
        .auto-style4 {
            width: 84px;
        }
        .auto-style6 {
            width: 11%;
        }
        .auto-style7 {
            width: 8%;
        }
        .auto-style8 {
            width: 2%;
        }
        .auto-style10 {
            width: 56px;
        }
        .auto-style11 {
            width: 131px;
        }
        .auto-style12 {
            width: 76px;
        }
        .auto-style13 {
            width: 153px;
        }
        .auto-style14 {
            width: 54px;
        }
        .auto-style15 {
            width: 183px;
        }
        .auto-style16 {
            width: 172px;
        }
        .auto-style17 {
            width: 36px;
        }
        .auto-style19 {
            width: 390px;
        }
        .auto-style22 {
            width: 106px;
        }
        .auto-style25 {
            width: 96px;
        }
        .auto-style26 {
            width: 102px;
        }
    </style>
</head>
    <script language="Javascript">
        function preview() {
            bdhtml = window.document.body.innerHTML;
            sprnstr = "<!--startprint-->";
            eprnstr = "<!--endprint-->";
            prnhtml = bdhtml.substr(bdhtml.indexOf(sprnstr) + 17);
            prnhtml = prnhtml.substring(0, prnhtml.indexOf(eprnstr));
            window.document.body.innerHTML = prnhtml;
            window.print();
        }
</script>
<body>
    <form id="form1" runat="server">
    <div>
            <asp:Panel ID="Panel_Search" runat="server" Visible="False">
                <fieldset>
                    <legend>出入库信息检索</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 10%" align="center">
                                物料型号：</td>
                            <td style="width: 15%" align="left">
                                <asp:Label ID="Label3" runat="server" Text="未选择物料型号"></asp:Label>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Button ID="ChooseMaterial" runat="server" CssClass="Button02" Height="24px" OnClick="ChooseMaterial_Click" Text="选择物料" Width="68px" />
                            </td>
                            <td align="left" class="auto-style6">
                                <asp:Label ID="mid" runat="server" Text="mid" Visible="False"></asp:Label>
                            </td>
                            <td align="center" class="auto-style7">
                                时间：</td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox ID="TextBox5" runat="server" CssClass="Wdate" DataFormatString="{0:yyyy-MM-dd}" onfocus="new WdatePicker(this,'%Y-%M-%D' ,true)"></asp:TextBox>
                                </td>
                            <td align="left" class="auto-style8">到</td>
                            <td style="width: 13%" align="center">
                                <asp:TextBox ID="TextBox6" runat="server" CssClass="Wdate" DataFormatString="{0:yyyy-MM-dd}" onfocus="new WdatePicker(this,'%Y-%M-%D' ,true)"></asp:TextBox>
                            </td>
                            <td style="width: 12%" align="left">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 10%" align="center">
                                &nbsp;</td>
                            <td style="width: 15%" align="left">
                                <asp:Button ID="Button1" runat="server" CssClass="Button02" Height="24px" OnClick="SearchInStoreMain" Text="检索" Width="70px" />
                            </td>
                            <td align="center" style="width: 10%">
                                &nbsp;</td>
                            <td align="left" class="auto-style6">
                                <asp:Label ID="DropDownList1" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td align="center" class="auto-style7">&nbsp;</td>
                            <td align="left" style="width: 15%">
                                &nbsp;</td>
                            <td align="left" class="auto-style8">&nbsp;</td>
                            <td align="center" style="width: 13%">&nbsp;</td>
                            <td align="left" style="width: 12%">&nbsp;</td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
    </div>
        <div>
            <asp:Panel ID="Panel2" runat="server" Visible="False">
         <fieldset><legend>
             选择物料</legend>
             <table style="width: 100%">
                 <tr>
                     <td class="auto-style1">物料名称：</td>
                     <td style="width: 190px">
                         <asp:TextBox ID="TextBox21" runat="server" Width="171px"></asp:TextBox>
                     </td>
                     <td class="auto-style3">
                         型号：</td>
                     <td class="auto-style2">
                         <asp:TextBox ID="TextBox22" runat="server" Width="171px"></asp:TextBox>
                     </td>
                     <td class="auto-style4">
                         <asp:Button ID="Button37" runat="server" CssClass="Button02" OnClick="Button37_Click" Text="检索" Width="66px" UseSubmitBehavior="true" />
                     </td>
                     <td>&nbsp;</td>
                 </tr>
             </table>
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="GridViewStyle" DataKeyNames="IMMBD_MaterialID" EmptyDataText="没有相关记录，请搜索。" GridLines="None" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand" PageSize="15">
                <RowStyle CssClass="GridViewRowStyle" />
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle CssClass="GridViewHead" />
                <FooterStyle CssClass="GridViewFooterStyle" />
                <Columns>
                    
                            <asp:BoundField DataField="IMMBD_MaterialID" HeaderText="物料ID" Visible="false" SortExpression="IMMBD_MaterialID" />
                            <asp:BoundField DataField="IMMBD_MaterialName" HeaderText="材料名称" Visible="true" SortExpression="SMSMPM_Year" />
                            <asp:BoundField DataField="IMMBD_SpecificationModel" HeaderText="材料型号" Visible="true" SortExpression="SMSMPM_Month" />

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="Modify" runat="server" CommandArgument='<%# Eval("IMMBD_MaterialID") %>' CommandName="Choose">选择</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerTemplate>
                    <table width="100%">
                        <tr>
                            <td style="text-align: right">第<asp:Label ID="lblPageIndex" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                页 共<asp:Label ID="lblPageCount" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageCount  %>" />
                                页 
                                <asp:LinkButton ID="btnFirst" runat="server" CausesValidation="False" CommandArgument="First" CommandName="Page" Text="首页" />
                                <asp:LinkButton ID="btnPrev" runat="server" CausesValidation="False" CommandArgument="Prev" CommandName="Page" Text="上一页" />
                                <asp:LinkButton ID="btnNext" runat="server" CausesValidation="False" CommandArgument="Next" CommandName="Page" Text="下一页" />
                                <asp:LinkButton ID="btnLast" runat="server" CausesValidation="False" CommandArgument="Last" CommandName="Page" Text="尾页" />
                                <asp:TextBox ID="textbox" runat="server" Width="20px"></asp:TextBox>
                                <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1" CommandName="Page" Text="GO" />
                                <!-- here set the CommandArgument of the Go Button to '-1' as the flag --></td>
                        </tr>
                    </table>
                </PagerTemplate>
            </asp:GridView>
         </fieldset>
            </asp:Panel>
        </div>
        <div>
                <!--startprint-->
            <h1>
                <asp:Image ID="Image1" runat="server" Height="39px" ImageUrl="~/images/share.jpg" Width="68px" />
                乐山希尔电子-塑封桥、浇灌桥和模块事业部产品产量和合格率报表</h1>
            <asp:Panel ID="Panel3" runat="server" Visible="True">
                <table style="width: 100%">
                    <tr>
                        <td class="auto-style19">&nbsp;</td>
                        <td class="auto-style26">统计时间:</td>
                        <td class="auto-style25">
                            <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
                            月</td>
                        <td class="auto-style17">&nbsp;</td>
                        <td class="auto-style22">
                            &nbsp;</td>
                        <td>&nbsp;</td>
                        <td></td>
                    </tr>
                </table>
         <fieldset><legend>
             型号合格率信息</legend>
             
            <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="True" CssClass="GridViewStyle"  EmptyDataText="没有相关记录，请搜索。" GridLines="None" OnPageIndexChanging="GridView2_PageIndexChanging" OnRowCommand="GridView2_RowCommand" PageSize="15" EnableModelValidation="True" OnRowDataBound="GridView2_RowDataBound">
                <RowStyle CssClass="GridViewRowStyle" />
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle CssClass="GridViewHead" />
                <FooterStyle CssClass="GridViewFooterStyle" />
                <PagerTemplate>
                    <table width="100%">
                        <tr>
                            <td style="text-align: right">第<asp:Label ID="lblPageIndex" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                页 共<asp:Label ID="lblPageCount" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageCount  %>" />
                                页 
                                <asp:LinkButton ID="btnFirst" runat="server" CausesValidation="False" CommandArgument="First" CommandName="Page" Text="首页" />
                                <asp:LinkButton ID="btnPrev" runat="server" CausesValidation="False" CommandArgument="Prev" CommandName="Page" Text="上一页" />
                                <asp:LinkButton ID="btnNext" runat="server" CausesValidation="False" CommandArgument="Next" CommandName="Page" Text="下一页" />
                                <asp:LinkButton ID="btnLast" runat="server" CausesValidation="False" CommandArgument="Last" CommandName="Page" Text="尾页" />
                                <asp:TextBox ID="textbox" runat="server" Width="20px"></asp:TextBox>
                                <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1" CommandName="Page" Text="GO" />
                                <!-- here set the CommandArgument of the Go Button to '-1' as the flag --></td>
                        </tr>
                    </table>
                </PagerTemplate>
            </asp:GridView>
         </fieldset>
            </asp:Panel>
            <asp:Panel runat="server" ID="panelGraph">
        <fieldset>
            <legend>趋势图</legend>
            <div style="text-align: center">
        <asp:Chart ID="Chart1" runat="server" OnLoad="Chart1_Load" Width="750px" BackImageAlignment="Center"  BorderlineWidth="20" Palette="None"  PaletteCustomColors="DeepSkyBlue; YellowGreen; Gold; DeepSkyBlue; YellowGreen; Gold" Height="600px" ImageLocation="" >
            <series>
                <asp:Series ChartType="Line" IsValueShownAsLabel="True" Name="塑封桥" LabelForeColor="DimGray"  MarkerBorderColor="SkyBlue" MarkerSize="8" MarkerStyle="Circle" Font="微软雅黑, 8.25pt" Legend="Legend1">
                </asp:Series>
                <asp:Series  ChartType="Line" IsValueShownAsLabel="True" Name="压塑桥" LabelForeColor="DimGray" MarkerSize="8" MarkerStyle="Circle" Font="微软雅黑, 8.25pt" Legend="Legend1">
                </asp:Series>
                  <asp:Series  ChartType="Line" IsValueShownAsLabel="True" Name="模块部产品" LabelForeColor="DimGray" MarkerSize="8" MarkerStyle="Circle" Font="微软雅黑, 8.25pt" Legend="Legend1">
                </asp:Series>
                  <asp:Series ChartArea="ChartArea2" ChartType="Column" IsValueShownAsLabel="True" Name="塑封合格率" LabelForeColor="DimGray"   MarkerSize="8" MarkerStyle="Circle" Font="微软雅黑, 8.25pt" Legend="Legend1">
                </asp:Series>
                <asp:Series ChartArea="ChartArea2" ChartType="Column" IsValueShownAsLabel="True" Name="压塑合格率" LabelForeColor="DimGray" MarkerSize="8" MarkerStyle="Circle" Font="微软雅黑, 8.25pt" Legend="Legend1">
                </asp:Series>
                   <asp:Series ChartArea="ChartArea2" ChartType="Column" IsValueShownAsLabel="True" Name="模块部产品合格率" LabelForeColor="DimGray" MarkerSize="8" MarkerStyle="Circle" Font="微软雅黑, 8.25pt" Legend="Legend1">
                </asp:Series>
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1" BackImageTransparentColor="Gainsboro">
                    <AxisY LineColor="DimGray" IsLabelAutoFit="False" Title="产量(台)" TitleFont="微软雅黑, 12px" TitleForeColor="DimGray">
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
                <asp:ChartArea BackImageTransparentColor="Gainsboro" Name="ChartArea2">
                    <AxisY IsLabelAutoFit="False" LineColor="DimGray" Title="合格率(%)" TitleFont="微软雅黑, 12px" TitleForeColor="DimGray">
                        <MajorGrid LineColor="DarkGray" LineDashStyle="Dash" />
                        <MajorTickMark LineColor="" />
                        <LabelStyle Font="微软雅黑, 8.25pt" ForeColor="DimGray" />
                    </AxisY>
                    <AxisX IsLabelAutoFit="False" LineColor="DimGray" Title="月" TitleFont="微软雅黑, 12px" TitleForeColor="DimGray">
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
                <asp:Title Font="微软雅黑, 20px" ForeColor="64, 64, 64" Name="Title1" Text="XXX产量对比趋势图">
                </asp:Title>
            </Titles>
        </asp:Chart>
    </div>
    </fieldset>
    </asp:Panel>

            <div>
                <table style="width: 100%">
                    <tr>
                        <td class="auto-style15"></td>

                        <td class="auto-style14">&nbsp;</td>

                        <td class="auto-style10">打印人:</td>

                        <td class="auto-style11">
                            <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                        </td>

                        <td class="auto-style12">打印时间:</td>

                        <td class="auto-style13">
                            <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                        </td>

                        <td class="auto-style16">&nbsp;</td>

                        <td>&nbsp;</td>

                    </tr>
                    </table>
                <!--endprint-->
                    <table style="width: 100%">
                    <tr>
                        <td class="auto-style15">&nbsp;</td>

                        <td class="auto-style14">
                                <asp:Button ID="Button4" runat="server" CssClass="Button02" Height="24px" OnClick="SearchInStoreMain" Text="打印" OnClientClick="preview()"   Width="70px" />
                            </td>

                        <td class="auto-style10">&nbsp;</td>

                        <td class="auto-style11">
                            &nbsp;</td>

                        <td class="auto-style12">
                                <asp:Button ID="ToExcel" runat="server" CssClass="Button02" Height="24px" OnClick="ToExcel_Click" Text="导出Excel" Width="70px" />
                            </td>

                        <td class="auto-style13">
                            &nbsp;</td>

                        <td class="auto-style16">
                                <asp:Button ID="back" runat="server" CssClass="Button02" Height="24px" OnClick="back_Click" Text="返回"   Width="70px" />
                            </td>

                        <td>&nbsp;</td>

                    </tr>
                </table>
            </div>
                
        </div>
    </form>
</body>
</html>
