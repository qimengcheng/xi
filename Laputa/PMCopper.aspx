<%@ Page Title="" Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true" CodeFile="PMCopper.aspx.cs" Inherits="Laputa_PMCopper" %>




<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" Visible="true">
                <fieldset>
                    <legend> 检索条件
                    </legend>
    <table style="width: 100%;">  
        <tr>
        <td style="width: 15%" align="right">
                <asp:Label ID="Label1" runat="server" Text="供应商名称:"></asp:Label>
            </td>
            <td style="width: 12%" align="left">
                <asp:TextBox ID="TextBox_Factory" runat="server"> </asp:TextBox>
            </td>
            <td style="width: 15%;text-align: right">
                <asp:Label ID="Label2" runat="server" Text="供应商编号:"></asp:Label>
            </td>
            <td style="width: 12%" align="left">
               <asp:TextBox ID="TextBox1" runat="server"> </asp:TextBox>
            </td>

            <td style="width: 15%" align="right">
                <asp:Label ID="Label3" runat="server" Text="铜材规格:"></asp:Label>
            </td>
               <td style="width: 15%; height: 20px;" align="left">
                <asp:TextBox ID="TextBox2" runat="server"> </asp:TextBox>
            </td>
            </tr>
            <tr>
            <td style="width: 15%" align="right">
                <asp:Label ID="Label5" runat="server" Text="时间:"></asp:Label>
            </td>
                <td style="width: 12%" align="left" colspan="3">
                <asp:TextBox ID="TextBox_Time1" runat="server"  onfocus="new WdatePicker(this,'%Y-%M-%D' ,true)" DataFormatString="{0:yyyy-MM-dd}" ></asp:TextBox>
            
                    &nbsp;
            
               <asp:Label ID="Label7" runat="server" Text="至"></asp:Label>
            
                    &nbsp;
            
                <asp:TextBox ID="TextBox_Time2" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D' ,true)" DataFormatString="{0:yyyy-MM-dd}" ></asp:TextBox>
            </td>   
        </tr>
       
        <tr>
        <td style="width: 15%" align="left">
                &nbsp;</td>
            <td colspan="2" align="left">
                <asp:Button ID="MainSearch" runat="server" Text="检索" CssClass="Button02" Height="24px" OnClick="MainSearch_Click"
                    Width="70px" />
            </td>
          
            <td colspan="2" align="left">
                
                <asp:Button ID="Button3" runat="server" Text="新增" CssClass="Button02" Height="24px" OnClick="Button3_New" Visible="true"
                    Width="70px" />
            </td>
            <td style="width: 15%" align="left" colspan="2">
               <asp:Button ID="Button2" runat="server" Text="重置" CssClass="Button02" Height="24px" OnClick="Reset" Visible="true"
                    Width="70px" /></td>
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
            <legend>铜材代工表 </legend>
            <asp:GridView ID="GridView1" runat="server" CssClass="GridViewStyle"  AllowPaging="True" PageSize="5" AutoGenerateColumns="False" 
                        GridLines="None" EmptyDataText="没有相关记录" OnRowCommand="GridView1_RowCommand"
                         DataKeyNames="PMCF_ID"  OnPageIndexChanging="GridView1_PageIndexChanging" EnableModelValidation="True" OnRowDataBound="GridView1_RowDataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="PMCF_ID" HeaderText="铜材代工ID" Visible="false" SortExpression="SMSMPM_ID" />
                            <asp:BoundField DataField="IMMBD_MaterialName" HeaderText="材料名称" Visible="true" SortExpression="PMP_ID" />
                            <asp:BoundField DataField="PMSI_SupplyName" HeaderText="供应商名称" Visible="true" SortExpression="SMSMPM_Year" />
                                 <asp:BoundField DataField="IMMBD_SpecificationModel" HeaderText="规格" Visible="true" SortExpression="SMSMPM_Year" />
                                 <asp:BoundField DataField="PMCF_BatchNum" HeaderText="批号" Visible="true" SortExpression="SMSMPM_Year" />
                            <asp:BoundField DataField="PMCF_PurchaseNum" HeaderText="采购数量" Visible="true" SortExpression="SMSMPM_Year" />
                                 <asp:BoundField DataField="PMCF_DueReturn" HeaderText="应退" Visible="true" />
                                 <asp:BoundField DataField="PMCF_ActualReturn" HeaderText="实退预算" />
                            <asp:BoundField DataField="PMCF_NGReturn" HeaderText="退正料" />
                            <asp:BoundField DataField="PMCF_Time" HeaderText="时间" Visible="true" DataFormatString="{0:yyyy-MM-dd}" SortExpression="PMCF_Time" />
                         
                            <asp:BoundField DataField="PMSI_ID" HeaderText="供应商ID" SortExpression="PMSI_ID" >
                         
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                            </asp:BoundField>
                         
                            <asp:BoundField DataField="PMCF_MaterialID" HeaderText="物料ID">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PMCF_Rate" HeaderText="利用率">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                            </asp:BoundField>
                         
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="OEM" runat="server" CommandArgument='<%# Eval("PMCF_ID") %>' CommandName="OEM">代工信息</asp:LinkButton>
                                </ItemTemplate>
                                  </asp:TemplateField>
                                <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton6" runat="server" CommandArgument='<%# Eval("PMCF_ID") %>' CommandName="Return">退废料</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>    
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="NG" runat="server" CommandArgument='<%# Eval("PMCF_ID") %>' CommandName="NG">退正料</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Modi" runat="server" CommandArgument='<%# Eval("PMCF_ID") %>' CommandName="Modi">编辑</asp:LinkButton>
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
    
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
        <ContentTemplate>   
            <asp:Panel ID="Panel3" runat="server" Visible="false">
                <fieldset>
                    <legend> 
                        <asp:Label ID="Label4" runat="server" Text="新增"></asp:Label>
                        铜材</legend>
    <table style="width: 100%;">
   
        <tr>
        <td style="width: 6%; height: 20px;" align="right">
            规格:</td>
            <td style="width: 22%; height: 20px;" align="left">
                <asp:Label ID="Type" runat="server" Text="请选择规格"></asp:Label>
                <asp:Button ID="Materialpiker" runat="server" CssClass="Button02" Height="24px" OnClick="Materialpiker_Click" Text="选择规格" Width="75px" />
            </td>
            
           <td style="width: 10%; height: 20px;" align="right">
                购买数量(Kg)</td>
            <td style="width: 22%; height: 20px;" align="left">
                <asp:TextBox ID="TextBox3" runat="server" 
 onkeyup="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{2,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{2})[0-9]*/, '$1');" 
                              onafterpaste="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{2,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{2})[0-9]*/, '$1');"
Width="80%"></asp:TextBox>
                                    <asp:Label ID="Label39" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
           
            <td style="width: 10%; height: 20px;" align="right">
            <asp:Label ID="Label6" runat="server" Text="供应商:"></asp:Label>
            </td>
               <td style="width: 15%; height: 20px;" align="right" colspan="2">
                   <asp:Label ID="ProviderName" runat="server" Text="请选择供应商"></asp:Label>
            </td> 
            <td style="width: 15%; height: 20px;" align="left">
                <asp:Button ID="ChooseProvider" runat="server" CssClass="Button02" Height="24px" 
                        OnClick="ProviderSearch" Text="选择供应商" Width="75px" /></td>
            </tr>
            <tr>
                <td align="right" style="width: 6%; height: 20px;">批号:</td>
                <td align="left" style="width: 22%; height: 20px;">
                    <asp:TextBox ID="TextBox6" runat="server" Width="80%"></asp:TextBox>
                    <asp:Label ID="Label41" runat="server" ForeColor="Red" Text="*"></asp:Label>
                </td>
                <td align="right" style="width: 10%; height: 20px;">日期:</td>
                <td align="left" style="width: 22%; height: 20px;">
                    <asp:TextBox ID="TextBox46" runat="server"  onfocus="new WdatePicker(this,'%Y-%M-%D' ,true)"
                                    DataFormatString="{0:yyyy-MM-dd}"
 Width="80%"></asp:TextBox>
                    <asp:Label ID="Label45" runat="server" ForeColor="Red" Text="*"></asp:Label>
                </td>
                <td align="right" style="width: 10%; height: 20px;">
                    <asp:Label ID="LabelUsage" runat="server" Text="利用率%:"></asp:Label>
                </td>
                <td align="right" style="width: 15%; height: 20px;" colspan="2">
                    <asp:TextBox ID="TextBox47" runat="server" onafterpaste="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{2,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{2})[0-9]*/, '$1');" onkeyup="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{2,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{2})[0-9]*/, '$1');" Width="80%"></asp:TextBox>
                </td>
                <td align="left" style="width: 15%; height: 20px;">&nbsp;</td>
        </tr>
            <tr>
            
             <td align="center" colspan="4">
                 <asp:Button ID="SummitOri" runat="server" CssClass="Button02" Height="24px" OnClick="SummitOri_Click" Text="提交" Width="70px" />
                 <asp:Label ID="Mid" runat="server" Text="mid" Visible="False"></asp:Label>
                </td>
            <td align="center" colspan="2">
                <asp:Button ID="Button8" runat="server" CssClass="Button02" Height="24px" OnClick="Button_Cancel" Text="关闭" Width="70px" />
            </td>
                <td align="center">
                    <asp:Label ID="CopperRate" runat="server" Text="CopperRate" Visible="False"></asp:Label>
                </td>
                <td align="center">
                    <asp:Label ID="ProviderID" runat="server" Text="ProviderID" Visible="False"></asp:Label>
                </td>
                <td>&nbsp;&nbsp; </td>
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
             <asp:Label ID="Label9" runat="server" Text="Label" Visible="False"></asp:Label>
             <asp:Label ID="Label10" runat="server" Text="Label" Visible="False"></asp:Label>
             </legend>
             <table style="width: 100%; height: 48px;">
                 <tr>
                     <td style="width: 72px">供应商编码：</td>
                     <td style="width: 190px">
                         <asp:TextBox ID="TextBox41" runat="server" Width="171px"></asp:TextBox>
                     </td>
                     <td style="width: 89px">供应商名称：</td>
                     <td style="width: 190px">
                         <asp:TextBox ID="TextBox42" runat="server" Width="171px"></asp:TextBox>
                     </td>
                     <td>
                         <asp:Button ID="SearchProvider" runat="server" CssClass="Button02" OnClick="SearchProvider_Click" Text="检索" Width="66px" />
                         <asp:Button ID="CloseProviderSearch" runat="server" CssClass="Button02" OnClick="CloseProviderSearch_Click" Text="关闭" Width="66px" />
                     </td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
                 </tr>
             </table>
            <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                 CssClass="GridViewStyle" DataKeyNames="PMSI_ID" EmptyDataText="没有相关记录，请搜索。"
                 GridLines="None" OnPageIndexChanging="GridView2_PageIndexChanging" OnRowCommand="GridView2_RowCommand"
                 PageSize="10">
                <RowStyle CssClass="GridViewRowStyle" />
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle CssClass="GridViewHead" />
                <FooterStyle CssClass="GridViewFooterStyle" />
                <Columns>
                    
                            <asp:BoundField DataField="PMSI_ID" HeaderText="产品ID" Visible="false"/>
                            <asp:BoundField DataField="PMSI_SupplyNum" HeaderText="供应商编码" Visible="true" />
                            <asp:BoundField DataField="PMSI_SupplyName" HeaderText="供应商名称" Visible="true" />
                            

                    <asp:TemplateField>
                        <ItemTemplate>  
                            <asp:LinkButton ID="choose" runat="server" CommandArgument='<%# Eval("PMSI_ID") %>' CommandName="Choose">选择</asp:LinkButton>
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
        <fieldset>
            
            <legend>铜材退料表
&nbsp;</legend>
            <asp:Label ID="CopperID" runat="server" Text="CopperID" Visible="False"></asp:Label>
            <asp:Button ID="NewReturn" runat="server" CssClass="Button02" Height="24px" OnClick="NewReturn_Click" Text="新增" Visible="true" Width="70px" />
            <asp:Button ID="CloseReturn" runat="server" CssClass="Button02" Height="24px" OnClick="CloseReturn_Click" Text="关闭" Visible="true" Width="70px" />
            <asp:GridView ID="GridView3" runat="server" CssClass="GridViewStyle"  AllowPaging="True" PageSize="15" AutoGenerateColumns="False" 
                        GridLines="None" EmptyDataText="没有相关记录" OnRowCommand="GridView1_RowCommand"
                         DataKeyNames="PMCR_ID"  OnPageIndexChanging="GridView1_PageIndexChanging" EnableModelValidation="True">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="PMCR_ID" HeaderText="铜材退料ID" Visible="false" SortExpression="PMCR_ID" />
                            <asp:BoundField DataField="PMCF_ID" HeaderText="铜材代工ID" Visible="true" SortExpression="PMCF_ID" >
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PMCR_Time" HeaderText="退料时间" Visible="true"  DataFormatString="{0:yyyy-MM-dd}" SortExpression="PMCR_Time" />
                            <asp:BoundField DataField="PMCR_Num" HeaderText="重量" Visible="true" SortExpression="PMCR_Num" />
                            <asp:BoundField DataField="PMSI_SupplyName" HeaderText="去向" />
                            <asp:BoundField DataField="PMCR_Remark" HeaderText="备注" Visible="true" SortExpression="PMCR_Remark" />
                            <asp:BoundField DataField="PMCR_Man" HeaderText="录入人" Visible="true" SortExpression="PMCR_Man" />


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
    <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
        <ContentTemplate>   
            <asp:Panel ID="Panel6" runat="server" Visible="false">
                <fieldset>
                    <legend> 新增铜材退料</legend>
    <table style="width: 100%;">
   
        <tr>
            
           <td style="width: 10%; height: 22px;" align="right">
                退货数量(Kg):</td>
            <td style="width: 17%; height: 22px;" align="left">
                <asp:TextBox ID="TextBox9" runat="server" 
 onkeyup="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{2,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{2})[0-9]*/, '$1');" 
                              onafterpaste="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{2,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{2})[0-9]*/, '$1');"
Width="80%"></asp:TextBox>
                                    <asp:Label ID="Label14" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
           
            <td style="width: 7%; height: 22px;" align="right">
                退货日期:</td>
               <td align="right" style="width: 18%; height: 22px;">
                   <asp:TextBox ID="TextBox44" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D' ,true)" DataFormatString="{0:yyyy-MM-dd}" Width="80%"></asp:TextBox>
                   <asp:Label ID="Label43" runat="server" ForeColor="Red" Text="*"></asp:Label>
            </td>
            <td align="right" style="width: 10%; height: 22px;">退货去向:</td>
               <td style="width: 15%; height: 22px;" align="right" colspan="2">
                   <asp:Label ID="Label16" runat="server" Text="请选择供应商"></asp:Label>
            </td> 
            <td style="width: 15%; height: 22px;" align="left">
                <asp:Button ID="providerpiker" runat="server" CssClass="Button02" Height="24px" 
                        OnClick="ProviderSearch" Text="选择供应商" Width="75px" /></td>
            <td align="left" style="width: 15%; height: 22px;"></td>
            </tr>
            <tr>
                <td align="right" style="width: 10%; height: 20px;">备注：<br /> (不超过200个字)</td>
                <td align="left" colspan="7" style="height: 20px;">
                    <asp:TextBox ID="TextBox43" runat="server" Height="80px" TextMode="MultiLine" Width="520px"></asp:TextBox>
                </td>
                <td align="left" style="width: 15%; height: 20px;">&nbsp;</td>
        </tr>
            <tr>
            
             <td align="center" colspan="2">
                 <asp:Button ID="SummitReturn" runat="server" CssClass="Button02" Height="24px" OnClick="SummitReturn_Click" Text="提交" Width="70px" />
                </td>
            <td align="center" colspan="4">
                <asp:Label ID="Label20" runat="server" Text="ProviderID" Visible="False"></asp:Label>
            </td>
                <td align="center" colspan="2">
                    <asp:Button ID="Button5" runat="server" CssClass="Button02" Height="24px" OnClick="Button_Cancel" Text="关闭" Width="70px" />
                </td>
                <td align="center">&nbsp;</td>
            </tr>
             
        </tr>
    </table>
     </fieldset>
       </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
     <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:Panel ID="Panel7" runat="server">
        <fieldset>
         
            <legend>铜材退正料表 &nbsp;</legend>
               <asp:Button ID="NewCopperNG" runat="server" CssClass="Button02" Height="24px" OnClick="NewCopperNG_Click" Text="新增" Visible="true" Width="70px" />
            <asp:Button ID="CloseReturnNG" runat="server" CssClass="Button02" Height="24px" OnClick="CloseReturnNG_Click" Text="关闭" Visible="true" Width="70px" />
            <asp:GridView ID="GridView4" runat="server" CssClass="GridViewStyle"  AllowPaging="True" PageSize="15" AutoGenerateColumns="False" 
                        GridLines="None" EmptyDataText="没有相关记录" OnRowCommand="GridView1_RowCommand"
                         DataKeyNames="PMCI_ID"  OnPageIndexChanging="GridView1_PageIndexChanging" EnableModelValidation="True">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="PMCI_ID" HeaderText="铜材退费料ID" Visible="false" SortExpression="PMCI_ID" />
                            <asp:BoundField DataField="PMCF_ID" HeaderText="铜材代工ID" Visible="true" SortExpression="PMCF_ID" >
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PMCI_Time" HeaderText="退料时间" Visible="true" DataFormatString="{0:yyyy-MM-dd}" SortExpression="PMCI_Time" />
                            <asp:BoundField DataField="PMCI_ProductNum" HeaderText="重量" Visible="true" SortExpression="PMCI_ProductNum" />
                            <asp:BoundField DataField="PMSI_SupplyName" HeaderText="去向" />
                            <asp:BoundField DataField="PMCI_Remark" HeaderText="备注" Visible="true" SortExpression="PMCI_Remark" />
                            <asp:BoundField DataField="PMCI_Man" HeaderText="录入人" Visible="true" SortExpression="PMCI_Man" />


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
    <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional">
        <ContentTemplate>   
            <asp:Panel ID="Panel8" runat="server" Visible="false">
                <fieldset>
                    <legend> 新增铜材正料退料</legend>
    <table style="width: 100%;">
   
        <tr>
            
           <td style="width: 10%; height: 20px;" align="right">
                退货数量(Kg):</td>
            <td style="width: 17%; height: 20px;" align="left">
                <asp:TextBox ID="TextBox8" runat="server" 
 onkeyup="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{2,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{2})[0-9]*/, '$1');" 
                              onafterpaste="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{2,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{2})[0-9]*/, '$1');"
Width="80%"></asp:TextBox>
                                    <asp:Label ID="Label13" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
           
            <td align="left" style="width: 8%; height: 20px;">退货日期:</td>
            <td align="left" style="width: 17%; height: 20px;">
                <asp:TextBox ID="TextBox45" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D' ,true)" DataFormatString="{0:yyyy-MM-dd}" Width="80%"></asp:TextBox>
                <asp:Label ID="Label44" runat="server" ForeColor="Red" Text="*"></asp:Label>
            </td>
           
            <td style="width: 10%; height: 20px;" align="right">
                退货去向:</td>
               <td style="width: 15%; height: 20px;" align="right" colspan="2">
                   <asp:Label ID="Label15" runat="server" Text="请选择供应商"></asp:Label>
            </td> 
            <td style="width: 15%; height: 20px;" align="left">
                <asp:Button ID="Button4" runat="server" CssClass="Button02" Height="24px" 
                        OnClick="ProviderSearch" Text="选择供应商" Width="75px" /></td>
            <td align="left" style="width: 15%; height: 20px;">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width: 10%; height: 20px;">备注：<br /> (不超过200个字)</td>
                <td align="left" colspan="7" style="height: 20px;">
                    <asp:TextBox ID="TextBox10" runat="server" Height="80px" TextMode="MultiLine" Width="520px"></asp:TextBox>
                </td>
                <td align="left" style="width: 15%; height: 20px;">&nbsp;</td>
        </tr>
            <tr>
            
             <td align="center" colspan="2" style="height: 28px">
                 <asp:Button ID="SummitReturnNG" runat="server" CssClass="Button02" Height="24px" OnClick="SummitReturnNG_Click" Text="提交" Width="70px" />
                </td>
                <td align="center" style="width: 8%; height: 28px"></td>
                <td align="center" style="height: 28px"></td>
            <td align="center" colspan="2" style="height: 28px">
                <asp:Label ID="Label17" runat="server" Text="ProviderID" Visible="False"></asp:Label>
            </td>
                <td align="center" colspan="2" style="height: 28px">
                    <asp:Button ID="Button7" runat="server" CssClass="Button02" Height="24px" OnClick="Button_Cancel" Text="关闭" Width="70px" />
                </td>
                <td align="center" style="height: 28px"></td>
            </tr>
             
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
             <asp:Label ID="Label8" runat="server" Text="Label" Visible="False"></asp:Label>
             <asp:Label ID="Label12" runat="server" Text="Label" Visible="False"></asp:Label>
             <asp:Label ID="Label18" runat="server" Text="Label" Visible="False"></asp:Label>
             </legend>
             <table style="width: 100%; height: 48px;">
                 <tr>
                     <td style="width: 72px">铜材规格：</td>
                     <td style="width: 190px">
                         <asp:TextBox ID="TextBox5" runat="server" Width="171px"></asp:TextBox>
                     </td>
                     <td style="width: 89px">
                         <asp:Button ID="SearhType" runat="server" CssClass="Button02" OnClick="SearhType_Click" Text="检索" Width="66px" />
                     </td>
                     <td style="width: 190px">
                         <asp:Button ID="CloseType" runat="server" CssClass="Button02" OnClick="CloseType_Click" Text="关闭" Width="66px" />
                     </td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
                 </tr>
             </table>
            <asp:GridView ID="GridView5" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                 CssClass="GridViewStyle" DataKeyNames="IMMBD_MaterialID" EmptyDataText="没有相关记录，请搜索。"
                 GridLines="None" OnPageIndexChanging="GridView5_PageIndexChanging" OnRowCommand="GridView5_RowCommand" EnableModelValidation="True">
                <RowStyle CssClass="GridViewRowStyle" />
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle CssClass="GridViewHead" />
                <FooterStyle CssClass="GridViewFooterStyle" />
                <Columns>
                    
                            <asp:BoundField DataField="IMMBD_MaterialID" HeaderText="铜材物料ID" Visible="False" />
                           <asp:BoundField DataField="IMMBD_SpecificationModel" HeaderText="铜材规格" Visible="true" />
                            <asp:BoundField DataField="IMMBD_UsagePercent" HeaderText="铜材利用率" Visible="true" />
                    <asp:BoundField DataField="IMMBD_Usage" HeaderText="铜材利用率" Visible="true" >
                        
                        
                           
                            

                           <HeaderStyle CssClass="hide" />
                           <ItemStyle CssClass="hide" />
                           </asp:BoundField>
                        
                        
                           
                            

                    <asp:TemplateField>
                        <ItemTemplate>  
                            <asp:LinkButton ID="choose" runat="server" CommandArgument='<%# Eval("IMMBD_MaterialID") %>' CommandName="Choose">选择</asp:LinkButton>
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
<asp:UpdatePanel ID="UpdatePanel10" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
                <asp:Panel ID="Panel10" runat="server">
                    <fieldset><legend>
                        代工信息表</legend>
                         <asp:Button ID="CloseOEM" runat="server" CssClass="Button02" Height="24px" OnClick="CloseOEM_Click" Text="关闭" Visible="true" Width="70px" />
            
            <asp:GridView ID="GridView6" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                 CssClass="GridViewStyle" DataKeyNames="IMMBD_MaterialName" EmptyDataText="没有相关记录，请搜索。"
                 GridLines="None" OnPageIndexChanging="GridView5_PageIndexChanging" OnRowCommand="GridView5_RowCommand" EnableModelValidation="True">
                <RowStyle CssClass="GridViewRowStyle" />
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle CssClass="GridViewHead" />
                <FooterStyle CssClass="GridViewFooterStyle" />
                <Columns>
                    
                            <asp:BoundField DataField="IMMBD_MaterialName" HeaderText="产品名称" Visible="False" />
                           <asp:BoundField DataField="IMMBD_SpecificationModel" HeaderText="产品规格" Visible="true" />
                            <asp:BoundField DataField="IMISM_InStoreTime" HeaderText="送货时间" />
                            <asp:BoundField DataField="IMIDS_ActualArrNum" HeaderText="送货数量(套)" Visible="true" />
                    <asp:BoundField DataField="SubNum" HeaderText="每套片数" Visible="true" >
                        
                        
                           
                            

                           <HeaderStyle CssClass="hide" />
                           <ItemStyle CssClass="hide" />
                           </asp:BoundField>
                        
                        
                           
                            

                            <asp:BoundField HeaderText="送货数量(片)" DataField="SKUamount" />
                            <asp:BoundField HeaderText="单片重量(g)" DataField="weightg" />
                            <asp:BoundField HeaderText="送货重量(Kg)" DataField="weightKg" />
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
</asp:Content>

