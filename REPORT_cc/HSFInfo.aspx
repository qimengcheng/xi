<%@ Page Title="" Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true" CodeFile="HSFInfo.aspx.cs" Inherits="Laputa_HSFInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
    <script type="text/javascript">
        $(document).ready(
            function() {

                $(".cg tr td:first-child").css("border-left", "none");
                $(".cg th:first-child").css("border-left", "none");
                $(".cg1 tr td:first-child").css("border-left", "none");
                $(".cg1 th:first-child").css("border-left", "none");
                $(".cg1 td").css("border-bottom", "none");
                $(".cg td").css("border-bottom", "none");
                $(".cg2 tr td:first-child").css("border-left", "none");
                $(".cg2 th:first-child").css("border-left", "none");
                $(".GridViewStyle th").css("min-width", "50px");
                $(".cg th").css("min-width", "60px");
                $(".cg1 th:first-child").css("min-width", "160px");
                $(".cg2 th").css("min-width", "130px");
                
            });
    </script>

    <asp:Panel ID="Panel_Search" runat="server" Visible="true" >
        <fieldset>
            <legend>产品合格率(按材料批号统计)</legend>
            <table style="width: 100%;">
                <tr>
                    <td style="width: 67px">
                        材料名称：</td>
                    <td style="width: 158px">
                        <asp:TextBox ID="TextBox23" runat="server" Width="90%"></asp:TextBox>
                    </td>
                    <td style="width: 76px">
                        供应商：</td>
                    <td style="width: 171px">
                        <asp:TextBox ID="TextBox24" runat="server" Width="90%"></asp:TextBox>
                    </td>
                    <td align="center" class="auto-style7" style="width: 61px">
                    </td>
                    <td style="width: 15%" align="left">
                        <asp:Label ID="mid" runat="server" Text="mid" Visible="False"></asp:Label>
                    </td>
                    <td align="left" class="auto-style8">&nbsp;</td>
                    <td style="width: 13%" align="center">
                        &nbsp;</td>
                    <td style="width: 12%" align="left">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 10%" align="center">
                        &nbsp;</td>
                    <td align="left" class="auto-style9" style="width: 129px">
                        <asp:Button ID="Button1" runat="server" CssClass="Button02" Height="24px" OnClick="SearchInStoreMain" Text="检索" Width="70px" />
                    </td>
                    <td align="center" style="width: 76px">
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
                            <td style="text-align: right">第<asp:Label ID="lblPageIndex" runat="server" Text="<%# ((GridView) Container.Parent.Parent).PageIndex + 1 %>" />
                                页 共<asp:Label ID="lblPageCount" runat="server" Text="<%# ((GridView) Container.Parent.Parent).PageCount %>" />
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
    <asp:Panel ID="Panel3"  runat="server"  Visible="False" ScrollBars="Horizontal" Width="860px">
        <fieldset><legend>
                      有毒物质</legend>
             
            <asp:GridView ID="GridView2" runat="server" AllowPaging="True" CssClass="GridViewStyle"  EmptyDataText="没有相关记录，请搜索。" GridLines="None"  DataKeyNames="HSF_ID" OnPageIndexChanging="GridView2_PageIndexChanging" PageSize="15" AutoGenerateColumns="False" OnRowDataBound="GridView2_RowDataBound">
                <RowStyle CssClass="GridViewRowStyle" />
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle CssClass="GridViewHead" />
                <Columns>
                 <asp:BoundField DataField="HSF_ID" HeaderText="HSF_ID" >
                      <HeaderStyle CssClass="hide" />
                      <ItemStyle CssClass="hide" />
                      </asp:BoundField>
                    <asp:BoundField DataField="HSF_ID" HeaderText="HSFID" Visible="false" SortExpression="SMSMPM_ID" />
                    <asp:BoundField DataField="HSF_MaterialName" HeaderText="材料名称" Visible="true" SortExpression="PMP_ID" />
                    <asp:BoundField DataField="HSF_Provider" HeaderText="供应商" Visible="true" SortExpression="SMSMPM_Year" >
                    <ItemStyle Width="20px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="HSF_Texture" HeaderText="材质" Visible="true" SortExpression="SMSMPM_Year" >
                            <ItemStyle Width="20px" />
                        </asp:BoundField>
                    <asp:BoundField DataField="HSF_Level" HeaderText="风险等级" Visible="true" SortExpression="SMSMPM_Month" >
                           <ItemStyle Width="20px" />
                        </asp:BoundField>
                    <asp:BoundField DataField="HSF_Note" HeaderText="备注" Visible="true" SortExpression="SMSMPM_MakeMan" >
                           <ItemStyle Width="20px" />
                        </asp:BoundField>
                    
                    <asp:TemplateField HeaderText="ROHS">
                        <ItemTemplate >
                            <asp:GridView ID="rohs" 
                                          runat="server" AutoGenerateColumns="False" EmptyDataText="无" CssClass="cg1" CellSpacing="0" BorderWidth="0"
                                          CellPadding="0"  GridLines="None"  BackColor="White" Width="100%" CaptionAlign="NotSet"
                                OnRowDataBound="ROHS_RowDataBound">
                                <RowStyle CssClass="GridViewRowStyle" HorizontalAlign="Center" VerticalAlign="Top" 
                                          Font-Size="Small" />
                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                <HeaderStyle CssClass="GridViewHead" HorizontalAlign="Center" VerticalAlign="Top" />
                                <FooterStyle CssClass="GridViewFooterStyle" />
                                <Columns>
                              <asp:BoundField DataField="HSFReport_Num" HeaderText="报告号"  >
                                     <ItemStyle Width="20px" />
                        </asp:BoundField>
                    <asp:BoundField DataField="HSFReport_Organization" HeaderText="测试机构" Visible="true" >
                           <ItemStyle Width="20px" />
                        </asp:BoundField>
                    <asp:BoundField DataField="HSFReport_Type" HeaderText="报告类型" Visible="true" >
                           <ItemStyle Width="20px" />
                        </asp:BoundField>
                                    <asp:TemplateField HeaderText="ROHS项目及含量">
                        <ItemTemplate >
                            <asp:GridView ID="rohsdetail" 
                                          runat="server" AutoGenerateColumns="True" EmptyDataText="无" CssClass="cg" CellSpacing="0" BorderWidth="0" 
                                          CellPadding="0"  GridLines="None"  BackColor="White" Width="100%" CaptionAlign="NotSet">
                                <RowStyle CssClass="GridViewRowStyle" HorizontalAlign="Center" VerticalAlign="Top" 
                                          Font-Size="Small" />
                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                <HeaderStyle CssClass="GridViewHead" HorizontalAlign="Center" VerticalAlign="Top" />
                                <FooterStyle CssClass="GridViewFooterStyle" />
                                <Columns>
                             
                                </Columns>
                            </asp:GridView>
                        </ItemTemplate>
                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="REACH">
                        <ItemTemplate >
                            <asp:GridView ID="reach" 
                                          runat="server" AutoGenerateColumns="False" EmptyDataText="无" CssClass="cg2" CellSpacing="0" BorderWidth="0"  OnRowDataBound="REACH_RowDataBound"
                                          CellPadding="0"  GridLines="None"  BackColor="White" Width="100%" CaptionAlign="NotSet">
                                <RowStyle CssClass="GridViewRowStyle" HorizontalAlign="Center" VerticalAlign="Top" 
                                          Font-Size="Small" />
                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                <HeaderStyle CssClass="GridViewHead" HorizontalAlign="Center" VerticalAlign="Top" />
                                <FooterStyle CssClass="GridViewFooterStyle" />
                                <Columns>
                             <asp:BoundField DataField="HSFReport_Num" HeaderText="报告号"  />
                    <asp:BoundField DataField="HSFReport_Organization" HeaderText="测试机构" Visible="true" />
                    <asp:BoundField DataField="HSFReport_Type" HeaderText="报告类型" Visible="true" />
                                    <asp:TemplateField HeaderText="REACH项目及含量">
                        <ItemTemplate >
                            <asp:GridView ID="reachdetail" 
                                          runat="server" AutoGenerateColumns="True" EmptyDataText="无" CssClass="cg" CellSpacing="0" BorderWidth="0"
                                          CellPadding="0"  GridLines="None"  BackColor="White" Width="100%" CaptionAlign="NotSet">
                                <RowStyle CssClass="GridViewRowStyle" HorizontalAlign="Center" VerticalAlign="Top" 
                                          Font-Size="Small" />
                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                <HeaderStyle CssClass="GridViewHead" HorizontalAlign="Center" VerticalAlign="Top" />
                                <FooterStyle CssClass="GridViewFooterStyle" />
                                <Columns>
                             
                                </Columns>
                            </asp:GridView>
                        </ItemTemplate>
                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="卤素">
                        <ItemTemplate >
                            <asp:GridView ID="cl" 
                                          runat="server" AutoGenerateColumns="False" EmptyDataText="无" CssClass="cg1" CellSpacing="0" BorderWidth="0"  OnRowDataBound="CL_RowDataBound"
                                          CellPadding="0"  GridLines="None"  BackColor="White" Width="100%" CaptionAlign="NotSet">
                                <RowStyle CssClass="GridViewRowStyle" HorizontalAlign="Center" VerticalAlign="Top" 
                                          Font-Size="Small" />
                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                <HeaderStyle CssClass="GridViewHead" HorizontalAlign="Center" VerticalAlign="Top" />
                                <FooterStyle CssClass="GridViewFooterStyle" />
                                <Columns>
                             <asp:BoundField DataField="HSFReport_Num" HeaderText="报告号"  />
                    <asp:BoundField DataField="HSFReport_Organization" HeaderText="测试机构" Visible="true" />
                    <asp:BoundField DataField="HSFReport_Type" HeaderText="报告类型" Visible="true" />
                                    <asp:TemplateField HeaderText="卤素名称及含量">
                        <ItemTemplate >
                            <asp:GridView ID="cldetail" 
                                          runat="server" AutoGenerateColumns="True" EmptyDataText="无" CssClass="cg" CellSpacing="0" BorderWidth="0"
                                          CellPadding="0"  GridLines="None"  BackColor="White" Width="100%" CaptionAlign="NotSet">
                                <RowStyle CssClass="GridViewRowStyle" HorizontalAlign="Center" VerticalAlign="Top" 
                                          Font-Size="Small" />
                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                <HeaderStyle CssClass="GridViewHead" HorizontalAlign="Center" VerticalAlign="Top" />
                                <FooterStyle CssClass="GridViewFooterStyle" />
                                <Columns>
                             
                                </Columns>
                            </asp:GridView>
                        </ItemTemplate>
                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="六溴环十二烷">
                        <ItemTemplate >
                            <asp:GridView ID="br" 
                                          runat="server" AutoGenerateColumns="False" EmptyDataText="无" CssClass="cg" CellSpacing="0" BorderWidth="0"  OnRowDataBound="BR_RowDataBound"
                                          CellPadding="0"  GridLines="None"  BackColor="White" Width="100%" CaptionAlign="NotSet">
                                <RowStyle CssClass="GridViewRowStyle" HorizontalAlign="Center" VerticalAlign="Top" 
                                          Font-Size="Small" />
                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                <HeaderStyle CssClass="GridViewHead" HorizontalAlign="Center" VerticalAlign="Top" />
                                <FooterStyle CssClass="GridViewFooterStyle" />
                                <Columns>
                             <asp:BoundField DataField="HSFReport_Num" HeaderText="报告号"  />
                    <asp:BoundField DataField="HSFReport_Organization" HeaderText="测试机构" Visible="true" />
                    <asp:BoundField DataField="HSFReport_Type" HeaderText="报告类型" Visible="true" />
                                    <asp:TemplateField HeaderText="六溴环十二烷含量">
                        <ItemTemplate >
                            <asp:GridView ID="brdetail" 
                                          runat="server" AutoGenerateColumns="True" EmptyDataText="无" CssClass="cg2" CellSpacing="0" BorderWidth="0"
                                          CellPadding="0"  GridLines="None"  BackColor="White" Width="100%" CaptionAlign="NotSet">
                                <RowStyle CssClass="GridViewRowStyle" HorizontalAlign="Center" VerticalAlign="Top" 
                                          Font-Size="Small" />
                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                <HeaderStyle CssClass="GridViewHead" HorizontalAlign="Center" VerticalAlign="Top" />
                                <FooterStyle CssClass="GridViewFooterStyle" />
                                <Columns>
                             
                                </Columns>
                            </asp:GridView>
                        </ItemTemplate>
                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="鄰苯二甲酸酯类3项">
                        <ItemTemplate >
                            <asp:GridView ID="c" 
                                          runat="server" AutoGenerateColumns="False" EmptyDataText="无" CssClass="cg1" CellSpacing="0" BorderWidth="0" OnRowDataBound="C_RowDataBound"
                                          CellPadding="0"  GridLines="None"  BackColor="White" Width="100%" CaptionAlign="NotSet">
                                <RowStyle CssClass="GridViewRowStyle" HorizontalAlign="Center" VerticalAlign="Top" 
                                          Font-Size="Small" />
                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                <HeaderStyle CssClass="GridViewHead" HorizontalAlign="Center" VerticalAlign="Top" />
                                <FooterStyle CssClass="GridViewFooterStyle" />
                                <Columns>
                             <asp:BoundField DataField="HSFReport_Num" HeaderText="报告号"  />
                    <asp:BoundField DataField="HSFReport_Organization" HeaderText="测试机构" Visible="true" />
                    <asp:BoundField DataField="HSFReport_Type" HeaderText="报告类型" Visible="true" />
                                    <asp:TemplateField HeaderText="鄰苯二甲酸酯类项目及含量">
                        <ItemTemplate >
                            <asp:GridView ID="cdetail" 
                                          runat="server" AutoGenerateColumns="True" EmptyDataText="无" CssClass="cg2" CellSpacing="0" BorderWidth="0"
                                          CellPadding="0"  GridLines="None"  BackColor="White" Width="100%" CaptionAlign="NotSet">
                                <RowStyle CssClass="GridViewRowStyle" HorizontalAlign="Center" VerticalAlign="Top" 
                                          Font-Size="Small" />
                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                <HeaderStyle CssClass="GridViewHead" HorizontalAlign="Center" VerticalAlign="Top" />
                                <FooterStyle CssClass="GridViewFooterStyle" />
                                <Columns>
                             
                                </Columns>
                            </asp:GridView>
                        </ItemTemplate>
                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ItemTemplate>
                    </asp:TemplateField>
                    

          
                </Columns>
                <FooterStyle CssClass="GridViewFooterStyle" />
                <PagerTemplate>
                    <table width="100%">
                        <tr>
                            <td style="text-align: right">第<asp:Label ID="lblPageIndex" runat="server" Text="<%# ((GridView) Container.Parent.Parent).PageIndex + 1 %>" />
                                页 共<asp:Label ID="lblPageCount" runat="server" Text="<%# ((GridView) Container.Parent.Parent).PageCount %>" />
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
                            <td style="text-align: right">第<asp:Label ID="lblPageIndex" runat="server" Text="<%# ((GridView) Container.Parent.Parent).PageIndex + 1 %>" />
                                页 共<asp:Label ID="lblPageCount" runat="server" Text="<%# ((GridView) Container.Parent.Parent).PageCount %>" />
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