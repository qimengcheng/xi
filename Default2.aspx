<%@ Page Title="" Language="C#" MasterPageFile="~/other/MasterPage.master" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Chart ID="Chart1" runat="server" OnLoad="Chart1_Load" Width="600px" BackImageAlignment="Center" BorderlineWidth="20" Palette="None" PaletteCustomColors="DeepSkyBlue; YellowGreen; Gold; 255, 128, 0; Crimson" CssClass="Button02">
        <series>
            <asp:Series ChartType="Line" IsValueShownAsLabel="True" Name="Series1" LabelForeColor="DimGray" MarkerBorderColor="SkyBlue" MarkerSize="8" MarkerStyle="Circle">
            </asp:Series>
            <asp:Series ChartArea="ChartArea1" ChartType="Line" IsValueShownAsLabel="True" Name="Series2" LabelForeColor="DimGray" MarkerSize="8" MarkerStyle="Circle">
            </asp:Series>
        </series>
        <chartareas>
            <asp:ChartArea Name="ChartArea1" BackImageTransparentColor="Gainsboro">
                <AxisY LineColor="DimGray">
                    <MajorGrid LineColor="DimGray" LineDashStyle="Dash" />
                    <MajorTickMark LineColor="" />
                </AxisY>
                <AxisX LineColor="DimGray">
                    <MajorGrid LineColor="DimGray" LineDashStyle="Dash" />
                </AxisX>
            </asp:ChartArea>
        </chartareas>
    </asp:Chart>
</asp:Content>

