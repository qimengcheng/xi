<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PMPApplyRule.aspx.cs" Inherits="PMP_PMPApplyRule" MasterPageFile="~/Other/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script> 
     <asp:UpdatePanel ID="UpdatePanel_PMPApplyRuleSearch" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_PMPApplyRuleSearch" runat="server" Visible="true">
                <fieldset>
                    <legend> 采购规则制定历史查询</legend>
    <table style="width: 100%;">
         <asp:Label ID="label_supplytype" runat="server" Visible="False"></asp:Label>
         <asp:Label ID="label_supplytypeid" runat="server" Visible="False"></asp:Label>
             <asp:Label ID="labelcodition" runat="server" Visible="False"></asp:Label>
             <asp:Label ID="label1_PanelSupply" runat="server" Visible="False"></asp:Label>
             <asp:Label ID="label1_BasicID" runat="server" Visible="False"></asp:Label>
             <asp:Label ID="label_Rule" runat="server" Visible="False"></asp:Label>
              <asp:Label ID="label_RuleID" runat="server" Visible="False"></asp:Label>
        <tr>
        <td style="width: 8%" align="right">
                <asp:Label ID="Label1" runat="server" Text="修改日期："></asp:Label>
        
        </td>
        <td colspan="2">
           
                <asp:TextBox ID="TextBox_SPTime2" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D ',true)"  ></asp:TextBox>
       
                &nbsp;
       
                <asp:Label ID="Label" runat="server" Text="至"></asp:Label>
            
                &nbsp;
            
                <asp:TextBox ID="TextBox_SPTime3" runat="server" 
                    onfocus="new WdatePicker(this,'%Y-%M-%D ',true)"  ></asp:TextBox>
            </td>
            <td style="width: 6%" align="right">
                <asp:Label ID="Label5" runat="server" Text="修改人："></asp:Label>
            </td>
            <td style="width: 15%" align="left">
                <asp:TextBox ID="ChangeMan" runat="server"> </asp:TextBox>
            </td>
        </tr>
        <tr>
        <td align="right">
                <asp:Label ID="Label2" runat="server" Text="是否正在使用："></asp:Label>
            </td>
            <td style="width: 8%" align="left">
                <asp:DropDownList ID="DDList1" runat="server"  Width="130px">           
                    <asp:ListItem>是</asp:ListItem>
                    <asp:ListItem>否</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="width: 12%" align="left"></td>
            <td  align="left"></td>
            <td align="left"></td>
        </tr>
        <tr>
            <td colspan="2" align="right">
                <asp:Button ID="Button1" runat="server" Text="检索" CssClass="Button02" Height="24px" OnClick="Button1_Sh"
                    Width="70px" />
            </td>
            <td colspan="2" align="center">
                <asp:Button ID="Button2" runat="server" Text="新增" CssClass="Button02" Height="24px" OnClick="Button2_Nw"
                    Width="70px" />
            </td>
            <td colspan="2" align="left">
                <asp:Button ID="Button3" runat="server" Text="重置" CssClass="Button02" Height="24px" OnClick="Button3_Reset" Visible="true"
                    Width="70px" />
            </td>
        </tr>
    </table>
     </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdatePanel_PMPApplyRuleInfo" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <asp:Panel ID="Panel_PMPApplyRuleInfo" runat="server" Visible="true">
            <fieldset>
                <legend>采购规则制定历史</legend>
                <asp:GridView ID="Gridview_PMPApplyRuleInfo"  runat="server" AutoGenerateColumns="False"
                    CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"  
                    Font-Strikeout="False" GridLines="None" PageSize="2" OnRowCommand="Gridview_PMPApplyRule_RowCommand" 
                    AllowPaging="True" AllowSorting="True" DataKeyNames="PMPAR_ID"   OnPageIndexChanging="Gridview_PMPApplyRule_PageIndexChanging" 
                    Width="100%" EnableModelValidation="True" 
                    ondatabound="Gridview_PMPApplyRuleInfo_DataBound" >
                    <%--    //隔行变色--%>
           
           
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                    <PagerStyle CssClass="GridViewPagerStyle" />
              <AlternatingRowStyle />
                    <Columns>
                        <asp:BoundField DataField="PMPAR_ID" HeaderText="采购申请规则ID" ReadOnly="True"
                            SortExpression="PMPAR_ID" Visible="False">
                            
                        </asp:BoundField>
                        <asp:BoundField DataField="PMPAR_Time" HeaderText="修改日期" 
                            SortExpression="PMPAR_Time" DataFormatString="{0:yyyy-MM-dd}">
                           
                        </asp:BoundField>
                        <asp:BoundField DataField="PMPAR_Man" HeaderText="修改人" 
                            SortExpression="PMPAR_Man">
                            <ItemStyle  />
                        </asp:BoundField>
                         <asp:BoundField DataField="PMPAR_Rule" HeaderText="采购规则" 
                            SortExpression="PMPAR_Rule">
                            <ItemStyle  />
                        </asp:BoundField>
                       
                        <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="btnDelete1" runat="server" CommandName="Delete1" OnClientClick="return confirm('您确认删除该记录吗?')" 
                                    CommandArgument='<%#Eval("PMPAR_ID")%>'>删除</asp:LinkButton>
                                   
                            </ItemTemplate>
                            <ItemStyle />
                        </asp:TemplateField>
                         <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnEdit1" runat="server" CommandName="Edit1" OnClientClick="false"
                                    CommandArgument='<%#Eval("PMPAR_ID")%>'>编辑</asp:LinkButton>
                            </ItemTemplate>
                            
                        </asp:TemplateField>
                         <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnLook1" runat="server" CommandName="Look1" OnClientClick="false"
                                    CommandArgument='<%#Eval("PMPAR_ID")%>'>查看</asp:LinkButton>
                            </ItemTemplate>
                           
                        </asp:TemplateField>
                    </Columns>
               <EmptyDataTemplate>
              <asp:Label ID="Label50" runat="server" Text="无相关记录！"></asp:Label>
             </EmptyDataTemplate>
                    <FooterStyle CssClass="GridViewFooterStyle" />
                    <HeaderStyle CssClass="GridViewHead"  
                        HorizontalAlign="Center" />
           
           
            <PagerStyle 
                 HorizontalAlign="Center" CssClass="GridViewPagerStyle" />
                            <PagerTemplate>
                   <table width="100%">
                    <tr>
                   <td style="text-align:right">
                       第<asp:Label id="lblPageIndex" runat="server" text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>' />
                       页 共<asp:Label id="lblPageCount" runat="server" text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />
                       页 
                    <asp:linkbutton id="btnFirst" runat="server" causesvalidation="False" commandargument="First" commandname="Page" text="首页" />
                  <asp:linkbutton id="btnPrev" runat="server" causesvalidation="False" commandargument="Prev" commandname="Page" text="上一页" />
                     <asp:linkbutton id="btnNext" runat="server" causesvalidation="False" commandargument="Next" commandname="Page" text="下一页" />                          
                      <asp:linkbutton id="btnLast" runat="server" causesvalidation="False" commandargument="Last" commandname="Page" text="尾页" />  
                       <asp:TextBox ID="textbox" runat="server" width="20px"></asp:TextBox>                                          
                       <asp:linkbutton id="btnGo" runat="server" causesvalidation="False" commandargument="-1" commandname="Page" text="GO" /><!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
                         </td>
                        </tr>
                     </table>
            </PagerTemplate>
           
           
                    <RowStyle CssClass="GridViewRowStyle" />
                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                </asp:GridView>
                </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
 
    <asp:UpdatePanel ID="UpdatePanel_PMPAR_RuleInfo" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_PMPAR_RuleInfo" runat="server" Visible="False">
                <fieldset>
                    <legend> 采购规则制定</legend>
    <table style="width: 100%;">
    
    <tr>
         <td align="right"  colspan="1">
                <asp:Label ID="Label3" runat="server" Text="采购规则：">
                </asp:Label><br />
                <asp:Label ID="Label4" runat="server" Text="（200字以内）">
                </asp:Label>
            </td>
            
               <td style="width: 100%" align="left" colspan="2">
                <asp:TextBox runat="server" ID="TextBox2" Width="90%" Enabled="True" 
                   MaxLength="200" TextMode="MultiLine"    Height="106px" 
                   onkeyup="this.value = this.value.substring(0, 200)" onafterpaste="this.value = this.value.substring(0, 200)"></asp:TextBox>
                    <asp:Label ID="Label133" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
            </tr>
           
     
    <tr>
    <td style="width: 12%" >
                
            </td>
            <td align="center" style="width: 30%">
                <asp:Button ID="Button6" runat="server" Text="提交" CssClass="Button02" Height="24px" OnClick="ConfirmRuleInfo "
                    Width="70px" />
            </td>
            <td align="center">
                <asp:Button ID="Button7" runat="server" Text="关闭" CssClass="Button02" 
                    Height="24px" OnClick="CanelRuleInfo"
                    Width="70px" />
            </td>
            </tr>
            <tr>
             <td align="center" colspan="3">
                <asp:Button ID="Button4" runat="server" Text="关闭" CssClass="Button02" 
                    Height="24px" OnClick="CanelRule"
                    Width="70px" />
            </td>
            </tr>
    </table>
     </fieldset>
     </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    </asp:Content>
