<%@ Page Title="" Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true" CodeFile="ClienSort.aspx.cs" Inherits="Client_ClienSort" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

<asp:UpdatePanel ID="UpdatePanel_RegionBasicInfo1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false" >
        <ContentTemplate>
           <asp:Panel ID="Panel_RegionBasicInfo1" runat="server" Visible="true">
            <fieldset>         
            <legend>客户领域信息查询</legend>
                  <asp:Label ID="labelsource" runat="server" ></asp:Label>
            <table style="width: 100%;" >
            <tr style="width: 100%;">
            <td style="width: 20%;" align="right">领域名称：</td>
            <td style="width: 30%;">
                <asp:TextBox ID="TextBox_Regionname1" runat="server" Width="80%"></asp:TextBox>
                </td>
            <td style="width: 12%;">
                <asp:Button ID="Btn_RegionSearch" runat="server" CssClass="Button02" 
                    Height="24px" Text="检索" Width="70px" onclick="Btn_RegionSearch_Click" />
                </td>
            <td style="width:5%;">
                &nbsp;</td>
        
              
            <td style="width:5%;">
                &nbsp;</td>
            <td>
            <asp:Button ID="Btn_NewStore" runat="server" CssClass="Button02" Height="24px" 
                                        Text="新增客户领域" Width="90px" onclick="Btn_NewStore_Click" />
            </td>
            </tr>
            </table>
            </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
            <asp:UpdatePanel ID="UpdatePanel_RegionBasicInfo" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true" >
        <ContentTemplate>
           <asp:Panel ID="Panel_RegionBasicInfo" runat="server" Visible="true"> 
            <fieldset> 

            <legend>客户领域信息表</legend>
            <asp:GridView ID="GridView_Region" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        PageSize="5" CellPadding="0" UseAccessibleHeader="False" AllowPaging="True"
                        Width="100%" DataKeyNames="CRMCustomSortID" 
                    OnRowCommand="GridView_Region_RowCommand" OnPageIndexChanging="GridView_Region_PageIndexChanging" 
                        Font-Strikeout="False" GridLines="None" 
                    ondatabound="GridView_Region_DataBound">
                         <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                        <asp:BoundField DataField="CRMCustomSortID" HeaderText="区域基础数据ID" SortExpression="CRMRBI_ID" Visible="false" ReadOnly="true"></asp:BoundField>
                        <asp:BoundField DataField="CRMCustomSortName" SortExpression="CRMRBI_Name" HeaderText="领域名称" ReadOnly="true"></asp:BoundField>
                        <asp:BoundField DataField="CRMCustomSortNote" SortExpression="CRMRBI_Explain" HeaderText="说明" ReadOnly="true"></asp:BoundField>
                      <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Change" runat="server" CommandArgument='<%# Eval("CRMCustomSortID") %>'
                                        CommandName="Change">编辑</asp:LinkButton>
                                </ItemTemplate>
                        </asp:TemplateField>
                      <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="dele" runat="server" CommandArgument='<%# Eval("CRMCustomSortID") %>'
                                        CommandName="dele" OnClientClick="return confirm('您确认删除该记录吗?')">删除</asp:LinkButton>
                                </ItemTemplate>
                        </asp:TemplateField>
                       <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Detail" runat="server" CommandArgument='<%# Eval("CRMCustomSortID") %>'
                                        CommandName="Detail">查看对应客户</asp:LinkButton>
                                </ItemTemplate>
                        </asp:TemplateField>
                       
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第 &nbsp;<asp:Label ID="lblPageIndex" runat="server" Text="<%#  ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                        页 共 &nbsp;<asp:Label ID="lblPageCount" runat="server" Text="<%#  ((GridView)Container.Parent.Parent).PageCount  %>" />
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
                                        <%--<asp:textbox id="txtNewPageIndex" runat="server" width="20px" text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />--%>
                                        <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                            CommandName="Page" Text="GO" />
                                        <!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
                                    </td>
                                </tr>
                            </table>
                        </PagerTemplate>
                    
                         <EmptyDataTemplate>
                            <asp:Label ID="Label16" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                         </asp:GridView>
           </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
              
    <br />
    
 <asp:UpdatePanel ID="UpdatePanel_RegionPeople" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_RegionPeople" runat="server" Visible="false">
                   <asp:Label ID="Label16" runat="server" Visible="false" ></asp:Label>
            <fieldset>
            <legend>区域客户</legend>
            <asp:GridView ID="GridView1_RegionPeople" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        PageSize="5" CellPadding="0" UseAccessibleHeader="False" AllowPaging="True"
                        Width="100%" DataKeyNames="CRMCIF_ID" 
                        Font-Strikeout="False" GridLines="None"
                        OnPageIndexChanging="GridView_RegionPeople_PageIndexChanging"  >
                         <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
           <Columns>
           <asp:BoundField DataField="CRMCIF_ID" HeaderText="客户ID" SortExpression="CRMCIF_ID" Visible="false" ReadOnly="true"></asp:BoundField>
           <asp:BoundField DataField="CRMCIF_Name" SortExpression="CRMCIF_Name" HeaderText="区域客户" ReadOnly="true"></asp:BoundField>          
           
           </Columns>
           <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第 &nbsp;<asp:Label ID="lblPageIndex" runat="server" Text="<%#  ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                        页 共 &nbsp;<asp:Label ID="lblPageCount" runat="server" Text="<%#  ((GridView)Container.Parent.Parent).PageCount  %>" />
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
                                        <%--<asp:textbox id="txtNewPageIndex" runat="server" width="20px" text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />--%>
                                        <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                            CommandName="Page" Text="GO" />
                                        <!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
                                    </td>
                                </tr>
                            </table>
           </PagerTemplate>
                    
                         <EmptyDataTemplate>
                            <asp:Label ID="Label16" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>          
           </asp:GridView>
           <table style="width: 100%;">
                            <tr style="width: 100%;">
                                <td align="center" colspan="2">
                                    <asp:Button ID="Btn_return" runat="server" CssClass="Button02" Height="24px" 
                                        Text="关闭" Width="70px" onclick="Btn_return_Click" />
                                </td>
                            </tr>
            </table>
            </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_NewRegion" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false" >
        <ContentTemplate>
            <asp:Panel ID="Panel_NewRegion" runat="server" Visible="false">
            <fieldset>
            <legend>新增客户领域</legend>
            <table style="width: 100%;">
                     <tr >
                                <td style="width: 15%;" align="right">
                                    客户领域名称：</td>
                                <td style="width: 25%;" ><asp:TextBox ID="TextBox_Regionname" runat="server" ></asp:TextBox></td>
                                <td></td>
                    </tr>
                    <tr>
                                <td align="right" >说明：<br />（200字内）</td>
                                <td colspan="2"><asp:TextBox ID="TextBox_RegionDetail" runat="server" Width="90%" 
                                        Height="60px"></asp:TextBox></td>
                            </tr>
                        <tr >
                          <td></td>
                                <td align="right" >
                                    <asp:Button ID="Btn_NewRegion" runat="server" CssClass="Button02" Height="24px" 
                                        Text="提交" Width="70px" onclick="Btn_NewRegion_Click" />
                                </td>
                                <td align="center">
                                    <asp:Button ID="Btn_RegionCancel" runat="server" CssClass="Button02" Height="24px" 
                                        Text="关闭" Width="70px" onclick="Btn_RegionCancel_Click" />
                                </td>
                            </tr>
            </table>
            
            </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
   
<asp:UpdatePanel ID="UpdatePanel_ChangeRegion" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false" >
        <ContentTemplate>
            <asp:Panel ID="Panel_ChangeRegion" runat="server" Visible="false">
            <fieldset>
            <legend>编辑领域</legend>
                <asp:Label ID="label1" runat="server" Visible="false"></asp:Label>
            <table style="width: 100%;">
                     <tr >
                                <td style="width: 15%; height: 21px;" align="right">
                                    区域名称：</td>
                                <td style="width: 25%;"><asp:TextBox ID="TextBox_Changregion" runat="server" ></asp:TextBox></td>
                                <td></td>
                        </tr>
                        <tr>
                                <td align="right">说明：<br />（200字内）</td>
                                <td colspan="2" ><asp:TextBox ID="TextBox_ChangeDetail" runat="server" Width="90%" Height="60px"></asp:TextBox></td>
                            </tr>
                        <tr >
                        <td></td>
                                <td align="right">
                                    <asp:Button ID="Btn_ChangeRegionok" runat="server" CssClass="Button02" Height="24px" 
                                        Text="提交" Width="70px" onclick="Button1_Click" />
                                </td>
                                <td align="center">
                                    <asp:Button ID="Btn_cancelChangeRE" runat="server" CssClass="Button02" Height="24px" 
                                        Text="关闭" Width="70px" onclick="Btn_cancelChangeRE_Click" />
                                </td>
                            </tr>
            </table>
            
            </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
  
    <br />

</asp:Content>

