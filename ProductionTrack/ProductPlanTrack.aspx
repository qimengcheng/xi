<%@ Page Title="" Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true" CodeFile="ProductPlanTrack.aspx.cs" Inherits="Laputa_ProductPlanTrack" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
         <ContentTemplate>
         <asp:Panel ID="Panel1" runat="server">
        <fieldset>
            <legend>生产计划检索</legend>
            <table style="width: 100%; width: auto">
                <tr>
                    <td style="width: 24px">从:</td>
                    <td style="width: 103px">
                        <asp:TextBox ID="TextBox1" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D' ,true)"
                                    DataFormatString="{0:yyyy-MM-dd}" ></asp:TextBox>
                    </td>
                    <td style="width: 22px">到:</td>
                    <td style="width: 108px">
                        <asp:TextBox ID="TextBox2" onfocus="new WdatePicker(this,'%Y-%M-%D' ,true)"
                                    DataFormatString="{0:yyyy-MM-dd}" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="MainSearch" runat="server"  CssClass="Button02" OnClick="MainSearch_Click" Text="检索" Width="61px" />
                    </td>
                    <td>
                        <asp:Label ID="syear" runat="server" Text="syear" Visible="False"></asp:Label>
                        <asp:Label ID="smonth" runat="server" Text="smonth" Visible="False"></asp:Label>
                        <asp:Label ID="sweek" runat="server" Text="sweek" Visible="False"></asp:Label>
                        <asp:Label ID="sstate" runat="server" Text="sstate" Visible="False"></asp:Label>
                    </td>
                </tr>
            </table>

        </fieldset>
    </asp:Panel>
             </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:Panel ID="Panel2" runat="server">
        <fieldset>
            <legend>生产计划跟踪表 </legend>
            <asp:GridView ID="GridView1" runat="server" CssClass="GridViewStyle"  AllowPaging="True" PageSize="5" AutoGenerateColumns="False" 
                        GridLines="None" EmptyDataText="没有相关记录" OnRowCommand="GridView1_RowCommand"
                         DataKeyNames="PWP_ID"  OnPageIndexChanging="GridView1_PageIndexChanging" EnableModelValidation="True">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="PWP_ID" HeaderText="PWP_ID" Visible="false" SortExpression="SMSMPM_ID" />
                            <asp:BoundField DataField="SMSWPM_Year" HeaderText="年" Visible="true" SortExpression="PMP_ID" />
                            <asp:BoundField DataField="SMSMPM_Month" HeaderText="月" Visible="true" SortExpression="SMSMPM_Year" />
                            <asp:BoundField DataField="SMSWPM_Week" HeaderText="周" Visible="true" SortExpression="SMSMPM_Year" />
                            <asp:BoundField DataField="PWP_STime" HeaderText="计划开始日期" DataFormatString="{0:yyyy-MM-dd}" Visible="true" SortExpression="SMSMPM_Month" />
                            <asp:BoundField DataField="PWP_ETime" HeaderText="计划结束日期" DataFormatString="{0:yyyy-MM-dd}" Visible="true" SortExpression="SMSMPM_MakeMan" />
                            <asp:BoundField DataField="PlanNum" HeaderText="计划量" Visible="true" SortExpression="SMSMPM_MakeTime" />
                            <asp:BoundField DataField="ProducingNum" HeaderText="完成量" Visible="true"  SortExpression="PMP_STime" />
                            <asp:BoundField DataField="FinishRate" HeaderText="完成率" Visible="true" SortExpression="PMP_ETime" />
                            

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Detail" runat="server" CommandArgument='<%# Eval("PWP_ID") %>' CommandName="Details">生产跟踪</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            
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
                    </asp:GridView>
        <table style="width:100%;text-align:left;">
           
        </table>
            </fieldset>
    </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:Panel ID="Panel5" runat="server">
        <fieldset>
            <legend>生产计划系列跟踪表 </legend>
            <asp:GridView ID="GridView4" runat="server" CssClass="GridViewStyle"  AllowPaging="True" PageSize="5" AutoGenerateColumns="False" 
                        GridLines="None" EmptyDataText="没有相关记录" OnRowCommand="GridView1_RowCommand"
                         DataKeyNames="PWP_ID"  OnPageIndexChanging="GridView1_PageIndexChanging" EnableModelValidation="True">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="PWP_ID" HeaderText="PWP_ID" Visible="false" SortExpression="SMSMPM_ID" />
                            <asp:BoundField DataField="SMSWPM_Year" HeaderText="年" Visible="true" SortExpression="PMP_ID" />
                            <asp:BoundField DataField="SMSMPM_Month" HeaderText="月" Visible="true" SortExpression="SMSMPM_Year" />
                            <asp:BoundField DataField="SMSWPM_Week" HeaderText="周" Visible="true" SortExpression="SMSMPM_Year" />
                            <asp:BoundField DataField="PS_ID" HeaderText="PS_ID" Visible="true" SortExpression="PMP_ID" >
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PS_Name" HeaderText="系列" Visible="true" SortExpression="SMSMPM_Year" />
                            <asp:BoundField DataField="PWP_STime" HeaderText="计划开始日期" DataFormatString="{0:yyyy-MM-dd}" Visible="true" SortExpression="SMSMPM_Month" />
                            <asp:BoundField DataField="PWP_ETime" HeaderText="计划结束日期" DataFormatString="{0:yyyy-MM-dd}" Visible="true" SortExpression="SMSMPM_MakeMan" />
                            <asp:BoundField DataField="PlanNum" HeaderText="计划量" Visible="true" SortExpression="SMSMPM_MakeTime" />
                            <asp:BoundField DataField="ProducingNum" HeaderText="完成量" Visible="true"  SortExpression="PMP_STime" />
                            <asp:BoundField DataField="FinishRate" HeaderText="完成率" Visible="true" SortExpression="PMP_ETime" />
                            

                      
                            
                            
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第<asp:Label ID="Label5" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>' />
                                        页 共<asp:Label ID="Label6" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />
                                        页
                                        <asp:LinkButton ID="LinkButton7" runat="server" CausesValidation="False" CommandArgument="First"
                                            CommandName="Page" Text="首页" />
                                        <asp:LinkButton ID="LinkButton13" runat="server" CausesValidation="False" CommandArgument="Prev"
                                            CommandName="Page" Text="上一页" />
                                        <asp:LinkButton ID="LinkButton14" runat="server" CausesValidation="False" CommandArgument="Next"
                                            CommandName="Page" Text="下一页" />
                                        <asp:LinkButton ID="LinkButton15" runat="server" CausesValidation="False" CommandArgument="Last"
                                            CommandName="Page" Text="尾页" />
                                        <asp:TextBox ID="textbox5" runat="server" Width="20px"></asp:TextBox>
                                        <asp:LinkButton ID="LinkButton16" runat="server" CausesValidation="False" CommandArgument="-1"
                                            CommandName="Page" Text="GO" /><!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
                                    </td>
                                </tr>
                            </table>
                        </PagerTemplate>
                    </asp:GridView>
        <table style="width:100%;text-align:left;">
           
        </table>
            </fieldset>
    </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
      <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:Panel ID="Panel3" runat="server">
        <fieldset>
            <legend>生产计划大型号跟踪表 </legend>
            <asp:GridView ID="GridView2" runat="server" CssClass="GridViewStyle"  AllowPaging="True" PageSize="5" AutoGenerateColumns="False" 
                        GridLines="None" EmptyDataText="没有相关记录" OnRowCommand="GridView1_RowCommand"
                         DataKeyNames="PWP_ID"  OnPageIndexChanging="GridView1_PageIndexChanging" EnableModelValidation="True">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="PWP_ID" HeaderText="PWP_ID" Visible="false" SortExpression="SMSMPM_ID" />
                            <asp:BoundField DataField="SMSWPM_Year" HeaderText="年" Visible="true" SortExpression="PMP_ID" />
                            <asp:BoundField DataField="SMSMPM_Month" HeaderText="月" Visible="true" SortExpression="SMSMPM_Year" />
                            <asp:BoundField DataField="SMSWPM_Week" HeaderText="周" Visible="true" SortExpression="SMSMPM_Year" />
                            <asp:BoundField DataField="PS_ID" HeaderText="PS_ID" Visible="true" SortExpression="PMP_ID" >
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PS_Name" HeaderText="系列" Visible="true" SortExpression="SMSMPM_Year" />
                            <asp:BoundField DataField="PMS_ID" HeaderText="大型号ID" Visible="true" SortExpression="SMSMPM_Year" >
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PMS_Name" HeaderText="大型号" Visible="true" SortExpression="SMSMPM_Month" />
                            <asp:BoundField DataField="PWP_STime" HeaderText="计划开始日期" DataFormatString="{0:yyyy-MM-dd}" Visible="true" SortExpression="SMSMPM_Month" />
                            <asp:BoundField DataField="PWP_ETime" HeaderText="计划结束日期" DataFormatString="{0:yyyy-MM-dd}" Visible="true" SortExpression="SMSMPM_MakeMan" />
                            <asp:BoundField DataField="PlanNum" HeaderText="计划量" Visible="true" SortExpression="SMSMPM_MakeTime" />
                            <asp:BoundField DataField="ProducingNum" HeaderText="完成量" Visible="true"  SortExpression="PMP_STime" />
                            <asp:BoundField DataField="FinishRate" HeaderText="完成率" Visible="true" SortExpression="PMP_ETime" />
                            

                      
                            
                            
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第<asp:Label ID="Label1" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>' />
                                        页 共<asp:Label ID="Label2" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />
                                        页
                                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandArgument="First"
                                            CommandName="Page" Text="首页" />
                                        <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandArgument="Prev"
                                            CommandName="Page" Text="上一页" />
                                        <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" CommandArgument="Next"
                                            CommandName="Page" Text="下一页" />
                                        <asp:LinkButton ID="LinkButton5" runat="server" CausesValidation="False" CommandArgument="Last"
                                            CommandName="Page" Text="尾页" />
                                        <asp:TextBox ID="textbox3" runat="server" Width="20px"></asp:TextBox>
                                        <asp:LinkButton ID="LinkButton6" runat="server" CausesValidation="False" CommandArgument="-1"
                                            CommandName="Page" Text="GO" /><!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
                                    </td>
                                </tr>
                            </table>
                        </PagerTemplate>
                    </asp:GridView>
        <table style="width:100%;text-align:left;">
           
        </table>
            </fieldset>
    </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
      <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:Panel ID="Panel4" runat="server">
        <fieldset>
            <legend>生产计划型号跟踪表 </legend>
            <asp:GridView ID="GridView3" runat="server" CssClass="GridViewStyle"  AllowPaging="True" PageSize="5" AutoGenerateColumns="False" 
                        GridLines="None" EmptyDataText="没有相关记录" OnRowCommand="GridView1_RowCommand"
                         DataKeyNames="PWP_ID"  OnPageIndexChanging="GridView1_PageIndexChanging" EnableModelValidation="True">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="PWP_ID" HeaderText="PWP_ID" Visible="false" SortExpression="SMSMPM_ID" />
                            <asp:BoundField DataField="SMSWPM_Year" HeaderText="年" Visible="true" SortExpression="PMP_ID" />
                            <asp:BoundField DataField="SMSMPM_Month" HeaderText="月" Visible="true" SortExpression="SMSMPM_Year" />
                            <asp:BoundField DataField="SMSWPM_Week" HeaderText="周" Visible="true" SortExpression="SMSMPM_Year" />
                            <asp:BoundField DataField="PT_Name" HeaderText="型号" Visible="true" SortExpression="SMSMPM_Month" />
                            <asp:BoundField DataField="PS_ID" HeaderText="PS_ID" Visible="true" SortExpression="PMP_ID" >
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PS_Name" HeaderText="系列" Visible="true" SortExpression="SMSMPM_Year" />
                            <asp:BoundField DataField="PMS_ID" HeaderText="大型号ID" Visible="true" SortExpression="SMSMPM_Year" >
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PMS_Name" HeaderText="大型号" Visible="true" SortExpression="SMSMPM_Month" />
                            <asp:BoundField DataField="PWP_STime" HeaderText="计划开始日期" DataFormatString="{0:yyyy-MM-dd}" Visible="true" SortExpression="SMSMPM_Month" />
                            <asp:BoundField DataField="PWP_ETime" HeaderText="计划结束日期" DataFormatString="{0:yyyy-MM-dd}" Visible="true" SortExpression="SMSMPM_MakeMan" />
                            <asp:BoundField DataField="PlanNum" HeaderText="计划量" Visible="true" SortExpression="SMSMPM_MakeTime" />
                            <asp:BoundField DataField="ProducingNum" HeaderText="完成量" Visible="true"  SortExpression="PMP_STime" />
                            <asp:BoundField DataField="FinishRate" HeaderText="完成率" Visible="true" SortExpression="PMP_ETime" />
                            

                            
                            
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第<asp:Label ID="Label3" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>' />
                                        页 共<asp:Label ID="Label4" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />
                                        页
                                        <asp:LinkButton ID="LinkButton8" runat="server" CausesValidation="False" CommandArgument="First"
                                            CommandName="Page" Text="首页" />
                                        <asp:LinkButton ID="LinkButton9" runat="server" CausesValidation="False" CommandArgument="Prev"
                                            CommandName="Page" Text="上一页" />
                                        <asp:LinkButton ID="LinkButton10" runat="server" CausesValidation="False" CommandArgument="Next"
                                            CommandName="Page" Text="下一页" />
                                        <asp:LinkButton ID="LinkButton11" runat="server" CausesValidation="False" CommandArgument="Last"
                                            CommandName="Page" Text="尾页" />
                                        <asp:TextBox ID="textbox4" runat="server" Width="20px"></asp:TextBox>
                                        <asp:LinkButton ID="LinkButton12" runat="server" CausesValidation="False" CommandArgument="-1"
                                            CommandName="Page" Text="GO" /><!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
                                    </td>
                                </tr>
                            </table>
                        </PagerTemplate>
                    </asp:GridView>
        <table style="width:100%;text-align:left;">
           
        </table>
            </fieldset>
    </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

