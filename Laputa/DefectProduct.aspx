<%@ Page Title="" Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true" CodeFile="DefectProduct.aspx.cs" Inherits="Laputa_DefectProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
    <asp:Label ID="state" runat="server" Text="state" Visible="False"></asp:Label>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:Panel ID="Panel1" runat="server">
        <fieldset>
            <legend>问题产品检索 
                
            </legend>
        <table style="width:100%;text-align:left;">
            <tr>
                <td style="width: 82px" align="right">产品型号：</td>
                <td style="width:15%">
                    <asp:TextBox ID="TextBox1" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td style="width: 73px" align="right">所在工序：</td>
                <td style="width:15%">
                    <asp:TextBox ID="TextBox2" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td style="width: 84px" align="right">提交人：</td>
                <td style="width:15%">
                    <asp:TextBox ID="TextBox3" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 82px" align="right">&nbsp;提交时间从：</td>
                <td style="width: 15%">
                    <asp:TextBox ID="TextBox5" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"
                                    DataFormatString="{0:yyyy-MM-dd}" Width="100%"></asp:TextBox>
                </td>
                <td style="width: 73px" align="right">到：</td>
                <td style="width:15%">
                    <asp:TextBox ID="TextBox6" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D' ,true)"
                                    DataFormatString="{0:yyyy-MM-dd}" Width="100%"></asp:TextBox>
                </td>
                <td style="width: 84px">&nbsp;</td>
                <td style="width:15%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 82px" align="right">问题类型：</td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server">
                          <asp:ListItem Value="所有原因">所有原因</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 73px" align="right">状态：</td>
                <td>
                    <asp:DropDownList ID="DropDownList2" runat="server">
                        <asp:ListItem>所有类型</asp:ListItem>
                        <asp:ListItem>等待选择相关随工单</asp:ListItem>
                        <asp:ListItem>已提交</asp:ListItem>
                        <asp:ListItem>审核通过</asp:ListItem>
                        <asp:ListItem>审核驳回</asp:ListItem>
                        <asp:ListItem>已处理</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 84px">&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td >
                    &nbsp;</td>
                <td align="center">
                    <asp:Button ID="Button1" runat="server" CssClass="Button02" Text="检索" Width="70px" OnClick="Button1_Click" />
                </td>
                <td colspan="2" align="center">
                    <asp:Button ID="AddDefectProduct" runat="server" CssClass="Button02" OnClick="AddDefectProduct_Click" Text="新增" Width="70px" />
                </td>
                <td>
                    <asp:Button id="Reset" class="Button02" type="reset" value="重置" aria-atomic="False"  Width="70px" runat="server" OnClick="Reset_Click" Text="重置" />
                </td>
                <td >&nbsp;</td>
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
            <legend>问题产品表 </legend>
           
            
        <table style="width:100%;text-align:left;">
           
            <tr>
                <td>
                    
                    <asp:Label ID="PPID" runat="server" Text="PPID" Visible="False"></asp:Label>
                </td>
            </tr>
           
        </table>
             <asp:GridView ID="GridView1" runat="server" CssClass="GridViewStyle"  AllowPaging="True" PageSize="5" AutoGenerateColumns="False" 
                        GridLines="None" EmptyDataText="没有相关记录" OnRowCommand="GridView1_RowCommand"
                         DataKeyNames="PP_ID"  OnPageIndexChanging="GridView1_PageIndexChanging" EnableModelValidation="True" OnRowDataBound="GridView1_RowDataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
               
                        <Columns>
                            <asp:BoundField DataField="PP_ID" HeaderText="问题产品ID" Visible="True" SortExpression="SMSMPM_ID" >
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PT_Name" HeaderText="产品型号" Visible="true" SortExpression="PMP_ID" />
                            <asp:BoundField DataField="PBC_Name" HeaderText="所在工序" Visible="true" SortExpression="SMSMPM_Year" />
                            <asp:BoundField DataField="PP_Num" HeaderText="数量" Visible="true" SortExpression="SMSMPM_Year" />
                            <asp:BoundField DataField="PP_ProDetail" HeaderText="问题描述" Visible="true" SortExpression="SMSMPM_Month" />
                            <asp:BoundField DataField="PP_State" HeaderText="状态" Visible="true" SortExpression="SMSMPM_MakeMan" />
                            <asp:BoundField DataField="PP_Man" HeaderText="提交人" Visible="true" SortExpression="SMSMPM_MakeTime" />
                            <asp:BoundField DataField="PP_Time" HeaderText="提交时间" Visible="true" DataFormatString="{0:yyyy-MM-dd HH:mm}" SortExpression="PMP_STime" />
                            <asp:BoundField DataField="PP_TrackResult" HeaderText="处理跟踪结果" Visible="true" SortExpression="PMP_ETime" />
                            <asp:BoundField DataField="PO_Name" HeaderText="问题类型" Visible="true" SortExpression="PMP_Man" />

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Detail" runat="server" CommandArgument='<%# Eval("PP_ID") %>' CommandName="setorder">补填相关随工单</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton42" runat="server" CommandArgument='<%# Eval("PP_ID") %>' CommandName="getorder">查看相关随工单</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton43" runat="server" CommandArgument='<%# Eval("PP_ID") %>' CommandName="setview">填写处理意见</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton44" runat="server" CommandArgument='<%# Eval("PP_ID") %>' CommandName="getview">查看处理意见</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton45" runat="server" CommandArgument='<%# Eval("PP_ID") %>' CommandName="track">填写跟踪结果</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton40" runat="server" CommandArgument='<%# Eval("PP_ID") %>' CommandName="audit" Visible="False">审核</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton46" runat="server" CommandArgument='<%# Eval("PP_ID") %>' CommandName="mod" >编辑</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                             <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton47" runat="server" CommandArgument='<%# Eval("PP_ID") %>' CommandName="del" OnClientClick="return confirm('您确认删除该记录吗?')">删除</asp:LinkButton>
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
            </fieldset>
    </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:Panel ID="Panel3" runat="server">
        <fieldset>
            <legend>
                <asp:Label ID="switchlabel" runat="server" Text="新增"></asp:Label>
                问题产品
            </legend>
        <table style="width:100%;text-align:left;">
            <tr>
                <td style="width: 102px" >产品型号:</td>
                <td style="width:25%">
                    <asp:Label ID="Label1" runat="server" Text="未选择"></asp:Label>
                    <asp:Button ID="ChooseType" runat="server" CssClass="Button02" OnClick="ChooseType_Click" Text="选择产品型号" Width="90px" />
                    <asp:Label ID="typeid" runat="server" Text="typeid" Visible="False"></asp:Label>
                </td>
                <td style="width: 91px" >工序:</td>
                <td style="width:25%">
                    <asp:Label ID="Label3" runat="server" Text="未选择"></asp:Label>
                    <asp:Button ID="ChooseCra" runat="server" CssClass="Button02" OnClick="ChooseCra_Click" Text="选择工序" Width="90px" />
                    <asp:Label ID="craid" runat="server" Text="craid" Visible="False"></asp:Label>
                </td>
                <td style="width: 150px" >数量:</td>
                <td style="width:21%">
                    <asp:TextBox ID="TextBox9" runat="server" Width="100%"  onkeyup="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{2,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{2})[0-9]*/, '$1');" 
                              onafterpaste="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{2,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{2})[0-9]*/, '$1');"
>
                        
                    </asp:TextBox>
                </td>
                <td style="width:15%">
                    <asp:Label ID="Label37" runat="server" ForeColor="red" Text="*"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 102px; height: 37px;">问题类型:</td>
                <td style="width: 25%; height: 37px;">
                    <asp:Label ID="Label5" runat="server" Text="未选择"></asp:Label>
                    <asp:Button ID="ChooseDefectType" runat="server" CssClass="Button02" OnClick="ChooseDefectType_Click" Text="选择问题类型" Width="90px" />
                    <asp:Label ID="poid" runat="server" Text="poid" Visible="False"></asp:Label>
                </td>
                <td style="width: 91px; height: 37px;">选择处理部门:</td>
                <td style="width:25%; height: 37px;">
                    <asp:Label ID="Label27" runat="server" Text="未选择"></asp:Label>
                </td>
                <td style="width: 150px; height: 37px;">
                    <asp:Button ID="ChooseDepartment" runat="server" CssClass="Button02" OnClick="ChooseDepartment_Click" Text="选择处理部门" Width="90px" />
                </td>
                <td style="width:21%; height: 37px;">
                    <asp:Label ID="depid" runat="server" Text="depid" Visible="False"></asp:Label>
                </td>
                <td style="width:15%; height: 37px;"></td>
            </tr>
            <tr>
                <td style="width: 102px; height: 21px;">问题描述:</td>
                <td colspan="4" style="height: 21px;">
                    <asp:TextBox ID="TextBox11" runat="server"  TextMode="MultiLine" Width="100%" MaxLength="200"></asp:TextBox>
                </td>
                <td style="width:21%; height: 21px;">
                    <asp:Label ID="Label38" runat="server" ForeColor="red" Text="*"></asp:Label>
                    (不超过200个字)</td>
                <td style="width:15%; height: 21px;"></td>
            </tr>
            <tr>
                <td style="width: 102px" >
                    <asp:Button ID="AddDefectType" runat="server" CssClass="Button02" OnClick="AddDefectType_Click" Text="新增问题类型" Width="90px" />
                </td>
                <td style="width: 25%">
                    &nbsp;</td>
                <td colspan="2" >
                    <asp:Button ID="ChooseWorkOrder" runat="server" CssClass="Button02" OnClick="ChooseWorkOrder_Click" Text="确认以上信息并选择相关随工单" Width="202px" ValidationGroup="A"></asp:Button>
                </td>
                <td style="width: 150px" >
                    <asp:Button ID="CloseAddDefectProduct" runat="server" CssClass="Button02" OnClick="CloseAddDefectProduct_Click" Text="关闭" Width="70px" CausesValidation="False" />
                </td>
                <td style="width: 21%">
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
            </fieldset>
    </asp:Panel>
         </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
                <asp:Panel ID="Panel4" runat="server">
                    <fieldset><legend>
             <asp:Label ID="Label7" runat="server" Text="Label" Visible="False"></asp:Label>
             <asp:Label ID="Label8" runat="server" Text="Label" Visible="False"></asp:Label>
             <asp:Label ID="Label9" runat="server" Text="Label" Visible="False"></asp:Label>
             </legend>
             <table style="width: 100%; height:24px;">
                 <tr>
                     <td style="width: 20%" align="right">产品型号：</td>
                     <td style="width: 20%">
                         <asp:TextBox ID="TextBox21" runat="server" Width="171px"></asp:TextBox>
                     </td>
                     <td align="center">
                         <asp:Button ID="SearchType" runat="server" CssClass="Button02" OnClick="SearchType_Click" Text="检索" Width="70px" />
                         
                     </td>
                     <td>
                        <asp:Button ID="CloseSearchType" runat="server" CssClass="Button02" OnClick="CloseSearchType_Click" Text="关闭" Width="70px" /></td>
                     <td>
                         &nbsp;</td>
                 </tr>
             </table>
            <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                 CssClass="GridViewStyle" DataKeyNames="PT_ID" EmptyDataText="没有相关记录，请搜索。"
                 GridLines="None" OnPageIndexChanging="GridView2_PageIndexChanging" OnRowCommand="GridView2_RowCommand"
                 PageSize="5">
                <RowStyle CssClass="GridViewRowStyle" />
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle CssClass="GridViewHead" />
                <FooterStyle CssClass="GridViewFooterStyle" />
                <Columns>
                    
                            <asp:BoundField DataField="PT_ID" HeaderText="产品ID" Visible="false"/>
                            <asp:BoundField DataField="PT_Name" HeaderText="产品型号" Visible="true" />
                            

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="Modify" runat="server" CommandArgument='<%# Eval("PT_ID") %>' CommandName="Choose">选择</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerTemplate>
                    <table width="100%">
                        <tr>
                            <td style="text-align: right">第<asp:Label ID="Label10" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                页 共<asp:Label ID="Label11" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageCount  %>" />
                                页 
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandArgument="First" CommandName="Page" Text="首页" />
                                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandArgument="Prev" CommandName="Page" Text="上一页" />
                                <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandArgument="Next" CommandName="Page" Text="下一页" />
                                <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" CommandArgument="Last" CommandName="Page" Text="尾页" />
                                <asp:TextBox ID="textbox4" runat="server" Width="20px"></asp:TextBox>
                                <asp:LinkButton ID="LinkButton5" runat="server" CausesValidation="False" CommandArgument="-1" CommandName="Page" Text="GO" />
                                <!-- here set the CommandArgument of the Go Button to '-1' as the flag --></td>
                        </tr>
                    </table>
                </PagerTemplate>
            </asp:GridView>
         </fieldset>
                </asp:Panel>

         </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
 <asp:Panel ID="Panel5" runat="server">
         <fieldset><legend>
             选择工序</legend>
             <table style="width: 100%; height: 24px;">
                 <tr>
                     <td style="width: 20%" align="right">工序名称：</td>
                     <td style="width: 20%">
                         <asp:TextBox ID="TextBox18" runat="server" Width="171px"></asp:TextBox>
                     </td>
                     <td align="center">
                         <asp:Button ID="SearhCra" runat="server" CssClass="Button02" OnClick="SearhCra_Click" Text="检索" Width="70px" />
                      </td>
                     <td>   
                         <asp:Button ID="CloseSearchCra" runat="server" CssClass="Button02" OnClick="CloseSearchCra_Click" Text="关闭" Width="70px" />
                         
                     </td>
                 </tr>
             </table>
            <asp:GridView ID="GridView6" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="GridViewStyle" DataKeyNames="PBC_ID" EmptyDataText="没有相关记录，请搜索。" GridLines="None" OnPageIndexChanging="GridView6_PageIndexChanging" OnRowCommand="GridView6_RowCommand" PageSize="5">
                <RowStyle CssClass="GridViewRowStyle" />
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle CssClass="GridViewHead" />
                <FooterStyle CssClass="GridViewFooterStyle" />
                <Columns>
                    <asp:BoundField DataField="PBC_ID" HeaderText="工序ID" SortExpression="SMSMPM_ID" Visible="false" />
                    <asp:BoundField DataField="PBC_Name" HeaderText="工序名称" SortExpression="PMP_ID" Visible="true" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton24" runat="server" CommandArgument='<%# Eval("PBC_ID") %>' CommandName="Choose">选择</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerTemplate>
                    <table width="100%">
                        <tr>
                            <td style="text-align: right">第<asp:Label ID="Label29" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                页 共<asp:Label ID="Label30" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageCount  %>" />
                                页 
                                <asp:LinkButton ID="LinkButton25" runat="server" CausesValidation="False" CommandArgument="First" CommandName="Page" Text="首页" />
                                <asp:LinkButton ID="LinkButton26" runat="server" CausesValidation="False" CommandArgument="Prev" CommandName="Page" Text="上一页" />
                                <asp:LinkButton ID="LinkButton27" runat="server" CausesValidation="False" CommandArgument="Next" CommandName="Page" Text="下一页" />
                                <asp:LinkButton ID="LinkButton28" runat="server" CausesValidation="False" CommandArgument="Last" CommandName="Page" Text="尾页" />
                                <asp:TextBox ID="textbox23" runat="server" Width="20px"></asp:TextBox>
                                <asp:LinkButton ID="LinkButton29" runat="server" CausesValidation="False" CommandArgument="-1" CommandName="Page" Text="GO" />
                                <!-- here set the CommandArgument of the Go Button to '-1' as the flag --></td>
                        </tr>
                    </table>
                </PagerTemplate>
            </asp:GridView>
         </fieldset>
            </asp:Panel>
   </ContentTemplate>
    </asp:UpdatePanel>

        <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
 <asp:Panel ID="Panel6" runat="server">
         <fieldset><legend>
             选择处理部门</legend>
             <table style="width: 100%; height: 24px;">
                 <tr>
                     <td style="width: 62px">处理部门：</td>
                     <td style="width: 190px">
                         <asp:TextBox ID="TextBox8" runat="server" Width="171px"></asp:TextBox>
                     </td>
                     <td>
                         <asp:Button ID="SearchDepartment" runat="server" CssClass="Button02" OnClick="SearchDepartment_Click" Text="检索" Width="70px" />
                         
                     </td>
                     <td>
                         <asp:Button ID="SummitDepartment" runat="server" CssClass="Button02" OnClick="SummitDepartment_Click" Text="提交" Width="70px" />
                     </td>
                     <td>
                         <asp:Button ID="resetchoose" runat="server" CssClass="Button02" OnClick="resetchoose_Click" Text="重置" Width="70px" />
                     </td>
                     <td>
                         <asp:Button ID="CloseSearchDepartment" runat="server" CssClass="Button02" OnClick="CloseSearchDepartment_Click" Text="关闭" Width="70px" />
                     </td>
                 </tr>
             </table>
            <asp:GridView ID="GridView3" runat="server"
                 AutoGenerateColumns="False" CssClass="GridViewStyle" DataKeyNames="BDOS_Code"
                 EmptyDataText="没有相关记录，请搜索。" GridLines="None" 
               OnRowCommand="GridView3_RowCommand" EnableModelValidation="True">
                <RowStyle CssClass="GridViewRowStyle" />
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle CssClass="GridViewHead" />
                <FooterStyle CssClass="GridViewFooterStyle" />
                <Columns>
                    
                    <asp:TemplateField>
                    
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:BoundField DataField="BDOS_Code" HeaderText="部门代码" SortExpression="SMSMPM_ID" Visible="True" >
                    <ControlStyle CssClass="hide" />
                    <FooterStyle CssClass="hide" />
                    <HeaderStyle CssClass="hide" />
                    <ItemStyle CssClass="hide" />
                    </asp:BoundField>
                    <asp:BoundField DataField="BDOS_Name" HeaderText="部门名称" SortExpression="PMP_ID" Visible="true" />
                    
                </Columns>
                <PagerTemplate>
                    <table width="100%">
                        <tr>
                            <td style="text-align: right">第<asp:Label ID="Label12" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                页 共<asp:Label ID="Label13" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageCount  %>" />
                                页 
                                <asp:LinkButton ID="LinkButton7" runat="server" CausesValidation="False" CommandArgument="First" CommandName="Page" Text="首页" />
                                <asp:LinkButton ID="LinkButton8" runat="server" CausesValidation="False" CommandArgument="Prev" CommandName="Page" Text="上一页" />
                                <asp:LinkButton ID="LinkButton9" runat="server" CausesValidation="False" CommandArgument="Next" CommandName="Page" Text="下一页" />
                                <asp:LinkButton ID="LinkButton10" runat="server" CausesValidation="False" CommandArgument="Last" CommandName="Page" Text="尾页" />
                                <asp:TextBox ID="textbox10" runat="server" Width="20px"></asp:TextBox>
                                <asp:LinkButton ID="LinkButton11" runat="server" CausesValidation="False" CommandArgument="-1" CommandName="Page" Text="GO" />
                                <!-- here set the CommandArgument of the Go Button to '-1' as the flag --></td>
                        </tr>
                    </table>
                </PagerTemplate>
            </asp:GridView>
         </fieldset>
            </asp:Panel>
   </ContentTemplate>
    </asp:UpdatePanel>
  
        <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
 <asp:Panel ID="Panel7" runat="server">
         <fieldset><legend>
             选择问题类型</legend>
             <table style="width: 100%; height: 24px;">
                 <tr>
                     <td style="width: 20%" align="right">问题类型：</td>
                     <td style="width: 20%">
                         <asp:TextBox ID="TextBox24" runat="server" Width="171px"></asp:TextBox>
                     </td>
                     <td align="center">
                         <asp:Button ID="Button4" runat="server" CssClass="Button02" OnClick="SearchCra_Click" Text="检索" Width="70px" />
                      </td>
                     <td>   
                         <asp:Button ID="CloseSearchDefectType" runat="server" CssClass="Button02" OnClick="CloseSearchDefectType_Click" Text="关闭" Width="70px" />
                         
                     </td>
                 </tr>
             </table>
            <asp:GridView ID="GridView7" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                 CssClass="GridViewStyle" DataKeyNames="PO_ID" EmptyDataText="没有相关记录，请搜索。"
                 GridLines="None" OnPageIndexChanging="GridView7_PageIndexChanging" OnRowCommand="GridView7_RowCommand" PageSize="5">
                <RowStyle CssClass="GridViewRowStyle" />
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle CssClass="GridViewHead" />
                <FooterStyle CssClass="GridViewFooterStyle" />
                <Columns>
                    <asp:BoundField DataField="PO_ID" HeaderText="问题类型ID" SortExpression="SMSMPM_ID" Visible="false" />
                    <asp:BoundField DataField="PO_Name" HeaderText="问题类型名称" SortExpression="PMP_ID" Visible="true" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton30" runat="server" CommandArgument='<%# Eval("PO_ID") %>' CommandName="Choose">选择</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerTemplate>
                    <table width="100%">
                        <tr>
                            <td style="text-align: right">第<asp:Label ID="Label34" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                页 共<asp:Label ID="Label35" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageCount  %>" />
                                页 
                                <asp:LinkButton ID="LinkButton31" runat="server" CausesValidation="False" CommandArgument="First" CommandName="Page" Text="首页" />
                                <asp:LinkButton ID="LinkButton32" runat="server" CausesValidation="False" CommandArgument="Prev" CommandName="Page" Text="上一页" />
                                <asp:LinkButton ID="LinkButton33" runat="server" CausesValidation="False" CommandArgument="Next" CommandName="Page" Text="下一页" />
                                <asp:LinkButton ID="LinkButton34" runat="server" CausesValidation="False" CommandArgument="Last" CommandName="Page" Text="尾页" />
                                <asp:TextBox ID="textbox25" runat="server" Width="20px"></asp:TextBox>
                                <asp:LinkButton ID="LinkButton35" runat="server" CausesValidation="False" CommandArgument="-1" CommandName="Page" Text="GO" />
                                <!-- here set the CommandArgument of the Go Button to '-1' as the flag --></td>
                        </tr>
                    </table>
                </PagerTemplate>
            </asp:GridView>
         </fieldset>
            </asp:Panel>
   </ContentTemplate>
    </asp:UpdatePanel>

 
    <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:Panel ID="Panel8" runat="server">
        <fieldset>
            <legend>新增问题类型
            </legend>
        <table style="width:100%;text-align:left;">
            <tr>
                <td style="width: 69px; height: 21px;">问题类型：</td>
                <td style="height: 21px;">
                    <asp:TextBox ID="TextBox31" runat="server" MaxLength="15" Width="100%"></asp:TextBox>
                </td>
                <td style="height: 21px;">(少于15个汉字)</td>
                <td style="height: 21px;">
                </td>
                <td style="height: 21px;"></td>
            </tr>
            <tr>
                <td style="width: 69px" >&nbsp;</td>
                <td align="right">
                    <asp:Button ID="AddDefectTypeSummit" runat="server" CssClass="Button02" OnClick="AddDefectTypeSummit_Click" Text="提交" Width="70px" />
                </td>
                <td align="center">
                    <asp:Button ID="CloseAddDefectType" runat="server" CssClass="Button02" OnClick="CloseAddDefectType_Click" Text="关闭" Width="70px" /></td>
                <td >
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
            </fieldset>
    </asp:Panel>
         </ContentTemplate>
    </asp:UpdatePanel>



 

    <asp:UpdatePanel ID="UpdatePanel9" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
<asp:Panel ID="Panel9" runat="server">
                    <fieldset><legend>
                        已选择的随工单</legend>
            
            <asp:GridView ID="GridView4" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="GridViewStyle" 
                DataKeyNames="WO_ID" EmptyDataText="没有相关记录，请搜索。" GridLines="None" OnPageIndexChanging="GridView4_PageIndexChanging" OnRowCommand="GridView4_RowCommand" PageSize="5">
                <RowStyle CssClass="GridViewRowStyle" />
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle CssClass="GridViewHead" />
                <FooterStyle CssClass="GridViewFooterStyle" />
                <Columns>
                     <asp:BoundField DataField="WO_ID" HeaderText="随工单号" SortExpression="SMSMPM_ID" Visible="False" />
                    <asp:BoundField DataField="WO_Num" HeaderText="随工单号" SortExpression="SMSMPM_ID" Visible="true" />
                    <asp:BoundField DataField="WO_ProType" HeaderText="产品型号" SortExpression="PMP_ID" Visible="true" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton12" runat="server" CommandArgument='<%# Eval("WO_ID") %>' CommandName="shanchu">删除</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerTemplate>
                    <table width="100%">
                        <tr>
                            <td style="text-align: right">第<asp:Label ID="Label20" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                页 共<asp:Label ID="Label21" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageCount  %>" />
                                页 
                                <asp:LinkButton ID="LinkButton13" runat="server" CausesValidation="False" CommandArgument="First" CommandName="Page" Text="首页" />
                                <asp:LinkButton ID="LinkButton14" runat="server" CausesValidation="False" CommandArgument="Prev" CommandName="Page" Text="上一页" />
                                <asp:LinkButton ID="LinkButton15" runat="server" CausesValidation="False" CommandArgument="Next" CommandName="Page" Text="下一页" />
                                <asp:LinkButton ID="LinkButton16" runat="server" CausesValidation="False" CommandArgument="Last" CommandName="Page" Text="尾页" />
                                <asp:TextBox ID="textbox19" runat="server" Width="20px"></asp:TextBox>
                                <asp:LinkButton ID="LinkButton17" runat="server" CausesValidation="False" CommandArgument="-1" CommandName="Page" Text="GO" />
                                <!-- here set the CommandArgument of the Go Button to '-1' as the flag --></td>
                        </tr>
                    </table>
                </PagerTemplate>
            </asp:GridView>
                         <table style="width: 100%; height: 24px;">
                 <tr>
                     <td style="width: 62px">
                         &nbsp;</td>
                     <td style="width: 190px">
                         &nbsp;</td>
                     <td>
                         <asp:Button ID="SummitWorkOrder" runat="server" CssClass="Button02" OnClick="SummitWorkOrder_Click" Text="提交" Width="66px" />
                     </td>
                 </tr>
             </table>
         </fieldset>
                </asp:Panel>
         </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel10" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
<asp:Panel ID="Panel10" runat="server">
                    <fieldset><legend>
                        选择随工单号</legend>
             <table style="width: 100%; height: 24px;">
                 <tr>
                     <td style="width: 20%" align="right">随工单号：</td>
                     <td style="width: 20%">
                         <asp:TextBox ID="TextBox20" runat="server" Width="171px"></asp:TextBox>
                     </td>
                     <td align="center">
                         <asp:Button ID="SearchWorkOrder" runat="server" CssClass="Button02" OnClick="SearchWorkOrder_Click" Text="检索" Width="70px" />
                      </td>
                     <td>   
                         <asp:Button ID="CloseWorkOrder" runat="server" CssClass="Button02" OnClick="CloseWorkOrder_Click" Text="关闭" Width="70px" />
                         
                     </td>
                 </tr>
             </table>
            <asp:GridView ID="GridView5" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="GridViewStyle" 
                DataKeyNames="WO_ID" EmptyDataText="没有相关记录，请搜索。" GridLines="None" OnPageIndexChanging="GridView5_PageIndexChanging" OnRowCommand="GridView5_RowCommand" PageSize="5">
                <RowStyle CssClass="GridViewRowStyle" />
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle CssClass="GridViewHead" />
                <FooterStyle CssClass="GridViewFooterStyle" />
                <Columns>
                    <asp:BoundField DataField="WO_ID" HeaderText="随工单ID" SortExpression="SMSMPM_ID" Visible="False" />
                    <asp:BoundField DataField="WO_Num" HeaderText="随工单号" SortExpression="SMSMPM_ID" Visible="true" />
                    <asp:BoundField DataField="WO_ProType" HeaderText="产品型号" SortExpression="PMP_ID" Visible="true" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton18" runat="server" CommandArgument='<%# Eval("WO_ID") %>' CommandName="Choose">选择</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerTemplate>
                    <table width="100%">
                        <tr>
                            <td style="text-align: right">第<asp:Label ID="Label25" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                页 共<asp:Label ID="Label26" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageCount  %>" />
                                页 
                                <asp:LinkButton ID="LinkButton19" runat="server" CausesValidation="False" CommandArgument="First" CommandName="Page" Text="首页" />
                                <asp:LinkButton ID="LinkButton20" runat="server" CausesValidation="False" CommandArgument="Prev" CommandName="Page" Text="上一页" />
                                <asp:LinkButton ID="LinkButton21" runat="server" CausesValidation="False" CommandArgument="Next" CommandName="Page" Text="下一页" />
                                <asp:LinkButton ID="LinkButton22" runat="server" CausesValidation="False" CommandArgument="Last" CommandName="Page" Text="尾页" />
                                <asp:TextBox ID="textbox22" runat="server" Width="20px"></asp:TextBox>
                                <asp:LinkButton ID="LinkButton23" runat="server" CausesValidation="False" CommandArgument="-1" CommandName="Page" Text="GO" />
                                <!-- here set the CommandArgument of the Go Button to '-1' as the flag --></td>
                        </tr>
                    </table>
                </PagerTemplate>
            </asp:GridView>
         </fieldset>
                </asp:Panel>
         </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel11" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
<asp:Panel ID="Panel11" runat="server">
                    <fieldset><legend>
                        处理意见</legend>
             <table style="width: 100%;">
                 <tr>
                     <td style="width: 62px">选择部门</td>
                     <td colspan="3">
                         <asp:DropDownList ID="DropDownList3" runat="server">
                         </asp:DropDownList>
                     </td>
                     <td>&nbsp;</td>
                 </tr>
                 <tr>
                     <td style="width: 62px">处理意见：</td>
                     <td colspan="3">
                         <asp:TextBox ID="TextBox12" runat="server" Height="60px" TextMode="MultiLine" Width="600px"></asp:TextBox>
                     </td>
                     <td>(不超过200个字)</td>
                 </tr>
                 <tr>
                     <td style="width: 62px">&nbsp;</td>
                     <td style="width: 190px" align="center">
                         <asp:Button ID="SummitView" runat="server" CssClass="Button02" OnClick="SummitView_Click" Text="提交" Width="70px" />
                     </td>
                     <td style="width: 190px">&nbsp;</td>
                     <td>
                         <asp:Button ID="CloseProcessSuggestion" runat="server" CssClass="Button02" OnClick="CloseProcessSuggestion_Click" Text="关闭" Width="70px" />
                     </td>
                     <td>&nbsp;</td>
                 </tr>
             </table>
         </fieldset>
                </asp:Panel>
         </ContentTemplate>
    </asp:UpdatePanel>
    
    <asp:UpdatePanel ID="UpdatePanel12" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
<asp:Panel ID="Panel12" runat="server">
                    <fieldset><legend>
                        相关随工单号</legend>
                        
            <asp:GridView ID="GridView9" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="GridViewStyle" 
                DataKeyNames="WO_ID" EmptyDataText="没有相关记录，请搜索。" GridLines="None" OnPageIndexChanging="GridView9_PageIndexChanging" PageSize="5">
                <RowStyle CssClass="GridViewRowStyle" />
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle CssClass="GridViewHead" />
                <FooterStyle CssClass="GridViewFooterStyle" />
                <Columns>
                       <asp:BoundField DataField="WO_ID" HeaderText="随工单号" SortExpression="SMSMPM_ID" Visible="False" />
                    <asp:BoundField DataField="WO_Num" HeaderText="随工单号" SortExpression="SMSMPM_ID" Visible="true" />
                    <asp:BoundField DataField="WO_ProType" HeaderText="产品型号" SortExpression="PMP_ID" Visible="true" />
                   
                </Columns>
                <PagerTemplate>
                    <table width="100%">
                        <tr>
                            <td style="text-align: right">第<asp:Label ID="Label2" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                页 共<asp:Label ID="Label4" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageCount  %>" />
                                页 
                                <asp:LinkButton ID="LinkButton49" runat="server" CausesValidation="False" CommandArgument="First" CommandName="Page" Text="首页" />
                                <asp:LinkButton ID="LinkButton50" runat="server" CausesValidation="False" CommandArgument="Prev" CommandName="Page" Text="上一页" />
                                <asp:LinkButton ID="LinkButton51" runat="server" CausesValidation="False" CommandArgument="Next" CommandName="Page" Text="下一页" />
                                <asp:LinkButton ID="LinkButton52" runat="server" CausesValidation="False" CommandArgument="Last" CommandName="Page" Text="尾页" />
                                <asp:TextBox ID="textbox14" runat="server" Width="20px"></asp:TextBox>
                                <asp:LinkButton ID="LinkButton53" runat="server" CausesValidation="False" CommandArgument="-1" CommandName="Page" Text="GO" />
                                <!-- here set the CommandArgument of the Go Button to '-1' as the flag --></td>
                        </tr>
                    </table>
                    <table style="width: 100%; ">
                    <tr>
                    <td align="center">
                    <asp:Button ID="CloseWorkOrderView" runat="server" CssClass="Button02" OnClick="CloseWorkOrderView_Click" Text="关闭" Width="70px" />
                    </td>
                    </tr>
                    </table>
                </PagerTemplate>
            </asp:GridView>
         </fieldset>
                </asp:Panel>
         </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdatePanel13" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
<asp:Panel ID="Panel13" runat="server">
                    <fieldset><legend>
                        填写跟踪结果</legend>
             <table style="width: 100%; height: 48px;">
                 <tr>
                     <td style="width: 62px">跟踪结果：</td>
                     <td colspan="3">
                         <asp:TextBox ID="TextBox7" runat="server" Width="600px" Height="60px" TextMode="MultiLine"></asp:TextBox>
                     </td>
                     <td>(不超过30个字)</td>
                 </tr>
                 <tr>
                     <td style="width: 62px">&nbsp;</td>
                     <td style="width: 190px" align="center">
                         <asp:Button ID="SummitResult" runat="server" CssClass="Button02" OnClick="SummitResault_Click" Text="提交" Width="70px" />
                     </td>
                     <td style="width: 190px">&nbsp;</td>
                     <td>
                         <asp:Button ID="CloseTrack" runat="server" CssClass="Button02" OnClick="CloseTrack_Click" Text="关闭" Width="70px" />
                     </td>
                     <td>&nbsp;</td>
                 </tr>
             </table>
         </fieldset>
                </asp:Panel>
         </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel14" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
<asp:Panel ID="Panel14" runat="server">
                    <fieldset><legend>
                        查看处理意见并审核</legend>
            <asp:GridView ID="GridView8" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="GridViewStyle" 
                DataKeyNames="BDOS_Name" EmptyDataText="没有相关记录，请搜索。" GridLines="None" OnPageIndexChanging="GridView8_PageIndexChanging" PageSize="5">
                <RowStyle CssClass="GridViewRowStyle" />
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle CssClass="GridViewHead" />
                <FooterStyle CssClass="GridViewFooterStyle" />
                <Columns>
                       <asp:BoundField DataField="BDOS_Name" HeaderText="部门" SortExpression="SMSMPM_ID" Visible="True" />
                    <asp:BoundField DataField="PPDS_Suggestion" HeaderText="处理意见" SortExpression="SMSMPM_ID" Visible="true" />
                    <asp:BoundField DataField="PPDS_SMan" HeaderText="建议人" SortExpression="SMSMPM_ID" Visible="True" />
                    <asp:BoundField DataField="PPDS_Time" HeaderText="建议时间" SortExpression="SMSMPM_ID" Visible="True" />
                    
                   
                </Columns>
                <PagerTemplate>
                    <table width="100%">
                        <tr>
                            <td style="text-align: right">第<asp:Label ID="Label6" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                页 共<asp:Label ID="Label14" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageCount  %>" />
                                页 
                                <asp:LinkButton ID="LinkButton6" runat="server" CausesValidation="False" CommandArgument="First" CommandName="Page" Text="首页" />
                                <asp:LinkButton ID="LinkButton36" runat="server" CausesValidation="False" CommandArgument="Prev" CommandName="Page" Text="上一页" />
                                <asp:LinkButton ID="LinkButton37" runat="server" CausesValidation="False" CommandArgument="Next" CommandName="Page" Text="下一页" />
                                <asp:LinkButton ID="LinkButton38" runat="server" CausesValidation="False" CommandArgument="Last" CommandName="Page" Text="尾页" />
                                <asp:TextBox ID="textbox13" runat="server" Width="20px"></asp:TextBox>
                                <asp:LinkButton ID="LinkButton39" runat="server" CausesValidation="False" CommandArgument="-1" CommandName="Page" Text="GO" />
                                <!-- here set the CommandArgument of the Go Button to '-1' as the flag --></td>
                        </tr>
                    </table>
                </PagerTemplate>
            </asp:GridView>
                        <table style="width:100%;">
                            <tr>
                            <td style="width: 180px"></td>
                                <td style="width: 186px">
                                    <asp:Button ID="SummitAuditPass" runat="server" CssClass="Button02" OnClick="SummitAuditPass_Click" Text="通过" Width="70px" />
                                </td>
                                <td style="width: 179px">
                                    <asp:Button ID="SummitAuditReject" runat="server" CssClass="Button02" OnClick="SummitAuditReject_Click" Text="驳回" Width="70px" />
                                </td>
                                <td>
                                    <asp:Button ID="CloseAudit" runat="server" CssClass="Button02" OnClick="CloseAudit_Click" Text="关闭" Width="70px" />
                                </td>
                            </tr>
                        </table>
         </fieldset>
                </asp:Panel>
         </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel15" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
<asp:Panel ID="Panel15" runat="server">
                    <fieldset><legend>
                        查看处理意见</legend>
            <asp:GridView ID="GridView10" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="GridViewStyle" 
                DataKeyNames="BDOS_Name" EmptyDataText="没有相关记录，请搜索。" GridLines="None" OnPageIndexChanging="GridView10_PageIndexChanging" PageSize="5">
                <RowStyle CssClass="GridViewRowStyle" />
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle CssClass="GridViewHead" />
                <FooterStyle CssClass="GridViewFooterStyle" />
                <Columns>
                       <asp:BoundField DataField="BDOS_Name" HeaderText="部门" SortExpression="SMSMPM_ID" Visible="True" />
                    <asp:BoundField DataField="PPDS_Suggestion" HeaderText="处理意见" SortExpression="SMSMPM_ID"  Visible="true" />
                     <asp:BoundField DataField="PPDS_SMan" HeaderText="建议人" SortExpression="SMSMPM_ID" Visible="True" />
                    <asp:BoundField DataField="PPDS_Time" HeaderText="建议时间" SortExpression="SMSMPM_ID" Visible="True" />
                    
                   
                </Columns>
                <PagerTemplate>
                    <table width="100%">
                        <tr>
                            <td style="text-align: right">第<asp:Label ID="Label15" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                页 共<asp:Label ID="Label16" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageCount  %>" />
                                页 
                                <asp:LinkButton ID="LinkButton41" runat="server" CausesValidation="False" CommandArgument="First" CommandName="Page" Text="首页" />
                                <asp:LinkButton ID="LinkButton48" runat="server" CausesValidation="False" CommandArgument="Prev" CommandName="Page" Text="上一页" />
                                <asp:LinkButton ID="LinkButton54" runat="server" CausesValidation="False" CommandArgument="Next" CommandName="Page" Text="下一页" />
                                <asp:LinkButton ID="LinkButton55" runat="server" CausesValidation="False" CommandArgument="Last" CommandName="Page" Text="尾页" />
                                <asp:TextBox ID="textbox15" runat="server" Width="20px"></asp:TextBox>
                                <asp:LinkButton ID="LinkButton56" runat="server" CausesValidation="False" CommandArgument="-1" CommandName="Page" Text="GO" />
                                <!-- here set the CommandArgument of the Go Button to '-1' as the flag --></td>
                        </tr>
                    </table>
                </PagerTemplate>
            </asp:GridView>
                        <table style="width:100%;">
                            <tr>
                                <td align="center">
                                    <asp:Button ID="CloseLookView" runat="server" CssClass="Button02" OnClick="CloseLookView_Click" Text="关闭" Width="66px" />
                                </td>
                            </tr>
                        </table>
         </fieldset>
                </asp:Panel>
         </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

