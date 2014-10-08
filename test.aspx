<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Chart ID="Chart1" runat="server" OnLoad="Chart1_Load" Width="750px" BackImageAlignment="Center"  BorderlineWidth="20" Palette="None" PaletteCustomColors="DeepSkyBlue; YellowGreen; Gold; 255, 128, 0; Crimson">
            <series>
                <asp:Series ChartType="Line" IsValueShownAsLabel="True" Name="2013" LabelForeColor="DimGray"  MarkerBorderColor="SkyBlue" MarkerSize="8" MarkerStyle="Circle" Font="微软雅黑, 8.25pt" Legend="Legend1">
                </asp:Series>
                <asp:Series ChartArea="ChartArea1" ChartType="Line" IsValueShownAsLabel="True" Name="2014" LabelForeColor="DimGray" MarkerSize="8" MarkerStyle="Circle" Font="微软雅黑, 8.25pt" Legend="Legend1">
                </asp:Series>
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1" BackImageTransparentColor="Gainsboro">
                    <AxisY LineColor="DimGray" IsLabelAutoFit="False" Title="产量" TitleFont="微软雅黑, 12px" TitleForeColor="DimGray">
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
                <asp:Title Font="微软雅黑, 20px" ForeColor="64, 64, 64" Name="Title1" Text="XXX产量对比趋势图">
                </asp:Title>
            </Titles>
        </asp:Chart>
    
    </div>
    </form>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
</body>
</html>
