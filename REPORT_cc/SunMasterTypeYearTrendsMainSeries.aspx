<%@ Page Title="" Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true" CodeFile="SunMasterTypeYearTrendsMainSeries.aspx.cs" Inherits="Laputa_SunMasterTypeYearTrendsMainSeries" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >


            <asp:Panel ID="Panel_Search" runat="server" Visible="true" >
                <fieldset>
                    <legend>产品合格率(按大型号统计)</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 10%; height: 22px;" align="center">
                                年份:</td>
                            <td align="left" class="auto-style9" style="width: 129px; height: 22px;">
                                <asp:DropDownList ID="DropDownList1" runat="server">
                              
                                </asp:DropDownList>
                            </td>
                            <td style="width: 4%; height: 22px;" align="center">
                                </td>
                            <td align="left" class="auto-style6" style="width: 238px; height: 22px;">
                                &nbsp;</td>
                            <td align="center" class="auto-style7" style="width: 61px; height: 22px;">
                                </td>
                            <td style="width: 15%; height: 22px;" align="left">
                                <asp:Label ID="mid" runat="server" Text="mid" Visible="False"></asp:Label>
                                </td>
                            <td align="left" class="auto-style8" style="height: 22px"></td>
                            <td style="width: 13%; height: 22px;" align="center">
                                </td>
                            <td style="width: 12%; height: 22px;" align="left">
                                </td>
                        </tr>
                        <tr>
                            <td style="width: 10%" align="center">
                                &nbsp;</td>
                            <td align="left" class="auto-style9" style="width: 129px">
                                <asp:Button ID="Button1" runat="server" CssClass="Button02" Height="24px" OnClick="SearchInStoreMain" Text="检索" Width="70px" />
                            </td>
                            <td align="center" style="width: 4%">
                                &nbsp;</td>
                            <td align="left" class="auto-style6" style="width: 238px">
                                <asp:Button ID="Button4" runat="server" CssClass="Button02" Height="24px" OnClick="print" Text="打印报表"  Width="70px" />
                            </td>
                            <td align="center" class="auto-style7" style="width: 61px">
                                <asp:Button ID="Reset" runat="server" CssClass="Button02" Height="24px" OnClick="Reset_Click" Text="重置" Width="70px" />
                            </td>
                            <td align="left" style="width: 15%">
                                &nbsp;</td>
                            <td align="left" class="auto-style8">&nbsp;</td>
                            <td align="center" style="width: 13%">&nbsp;</td>
                            <td align="left" style="width: 12%">&nbsp;</td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>

        
            <asp:Panel ID="Panel2" runat="server" Visible="False">
         <fieldset><legend>
             选择物料</legend>
             
             <table style="width: 100%">
                 <tr>
                     <td style="width: 63px">
                         
                         物料名称：</td>
                     <td style="width: 167px">
                         <asp:TextBox ID="TextBox21" runat="server" Width="171px"></asp:TextBox>
                     </td>
                     <td style="width: 49px">型号：</td>
                     <td style="width: 190px">
                         <asp:TextBox ID="TextBox22" runat="server" Width="171px"></asp:TextBox>
                     </td>
                     <td>
                         <asp:Button ID="Button37" runat="server" CssClass="Button02" OnClick="Button37_Click" Text="检索" UseSubmitBehavior="true" Width="66px" />
                     </td>
                     <td>&nbsp;</td>
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
       
                <!--startprint-->
            <asp:Panel ID="Panel3" runat="server" Visible="False">
         <fieldset><legend>
             型号合格率</legend>
             
            <asp:GridView ID="GridView2" runat="server" AllowPaging="True" CssClass="GridViewStyle"  EmptyDataText="没有相关记录，请搜索。" GridLines="None" OnPageIndexChanging="GridView2_PageIndexChanging" OnRowCommand="GridView2_RowCommand" PageSize="20" OnRowDataBound="GridView2_RowDataBound">
                <RowStyle CssClass="GridViewRowStyle" />
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle CssClass="GridViewHead" />
                <Columns>
                     <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Gra" runat="server" CommandArgument='<%# Eval("大型号") %>' CommandName="Gra">查看该大型号趋势图</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                </Columns>
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
           
    <asp:Panel runat="server" ID="panelGraph" Visible="False" >
        <fieldset>
            <legend>趋势图</legend>
            <div style="text-align: center">
        <asp:Chart ID="Chart1" runat="server" OnLoad="Chart1_Load" Width="750px" BackImageAlignment="Center"  BorderlineWidth="20" Palette="None"  PaletteCustomColors="DeepSkyBlue; YellowGreen; Gold; DeepSkyBlue; YellowGreen; Gold" Height="600px" >
            <series>
                <asp:Series ChartType="Line" IsValueShownAsLabel="True" Name="塑封桥" LabelForeColor="DimGray"  MarkerBorderColor="SkyBlue" MarkerSize="8" MarkerStyle="Circle" Font="微软雅黑, 8.25pt" Legend="Legend1">
                </asp:Series>
              <%--  <asp:Series  ChartType="Line" IsValueShownAsLabel="True" Name="压塑桥" LabelForeColor="DimGray" MarkerSize="8" MarkerStyle="Circle" Font="微软雅黑, 8.25pt" Legend="Legend1">
                </asp:Series>
                  <asp:Series  ChartType="Line" IsValueShownAsLabel="True" Name="模块部产品" LabelForeColor="DimGray" MarkerSize="8" MarkerStyle="Circle" Font="微软雅黑, 8.25pt" Legend="Legend1">
                </asp:Series>--%>
                  <asp:Series ChartArea="ChartArea2" ChartType="Column" IsValueShownAsLabel="True" Name="塑封合格率" LabelForeColor="DimGray"   MarkerSize="8" MarkerStyle="Circle" Font="微软雅黑, 8.25pt" Legend="Legend1">
                </asp:Series>
               <%-- <asp:Series ChartArea="ChartArea2" ChartType="Column" IsValueShownAsLabel="True" Name="压塑合格率" LabelForeColor="DimGray" MarkerSize="8" MarkerStyle="Circle" Font="微软雅黑, 8.25pt" Legend="Legend1">
                </asp:Series>
                   <asp:Series ChartArea="ChartArea2" ChartType="Column" IsValueShownAsLabel="True" Name="模块部产品合格率" LabelForeColor="DimGray" MarkerSize="8" MarkerStyle="Circle" Font="微软雅黑, 8.25pt" Legend="Legend1">
                </asp:Series>--%>
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
                <!--endprint-->
        
        
            <asp:Panel ID="Panel1" runat="server" Visible="False">
         <fieldset><legend>
             选择型号</legend>

                <table style="width: 100%">
                 <tr>
                     <td style="width: 63px">
                         
                         型号名称：</td>
                     <td style="width: 167px">
                         <asp:TextBox ID="TextBox1" runat="server" Width="171px"></asp:TextBox>
                     </td>
                     <td style="width: 49px" aria-autocomplete="none">编码：</td>
                     <td style="width: 190px">
                         <asp:TextBox ID="TextBox2" runat="server" Width="171px"></asp:TextBox>
                     </td>
                     <td>
                         <asp:Button ID="Button2" runat="server" CssClass="Button02" OnClick="searchprotype_Click" Text="检索" Width="66px" UseSubmitBehavior="true" />
                     </td>
                     <td>&nbsp;</td>
                     <td>&nbsp;</td>
                 </tr>
             </table>
            <asp:GridView ID="GridView3" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="GridViewStyle"  EmptyDataText="没有相关记录，请搜索。" GridLines="None" OnPageIndexChanging="GridView3_PageIndexChanging" OnRowCommand="GridView3_RowCommand" PageSize="15" EnableModelValidation="True">
                <RowStyle CssClass="GridViewRowStyle" />
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle CssClass="GridViewHead" />
                <FooterStyle CssClass="GridViewFooterStyle" />
                <Columns>
                    
                            <asp:BoundField DataField="PT_ID" HeaderText="PT_ID" Visible="false" />
                            <asp:BoundField DataField="PT_Name" HeaderText="型号名称" Visible="true" SortExpression="SMSMPM_Year" />
                            <asp:BoundField DataField="PT_SpecialNeed" HeaderText="特殊要求" Visible="true" SortExpression="SMSMPM_Month" />

                            <asp:BoundField DataField="PT_Note" HeaderText="备注" />

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="Modify" runat="server" CommandArgument='<%# Eval("PT_ID") %>' CommandName="Choose">选择</asp:LinkButton>
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
      
</asp:Content>

