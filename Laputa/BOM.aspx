<%@ Page Title="" Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true" CodeFile="BOM.aspx.cs" Inherits="Laputa_BOM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
        
    <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
     <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:Panel ID="Panel1" runat="server">
        <fieldset>
            <legend>BOM文件检索
            </legend>
        <table style="width:100%;text-align:left;">
            <tr>
                <td style="width: 72px">文件名称：</td>
                <td style="width:15%">
                    <asp:TextBox ID="TextBox1" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td style="width: 73px">申请单编号：</td>
                <td style="width:15%">
                    <asp:TextBox ID="TextBox2" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td style="width: 84px">受控文件编号：</td>
                <td style="width:15%">
                    <asp:TextBox ID="TextBox3" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td style="width: 48px">&nbsp;</td>
                <td style="width:15%">
                    <asp:CheckBox ID="CheckBox1" runat="server" Text="包括过期文件" />
                </td>
            </tr>
            <tr>
                <td style="width: 72px">申请日期从：</td>
                <td style="width: 15%">
                    <asp:TextBox ID="TextBox5" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D' ,true)"
                                    DataFormatString="{0:yyyy-MM-dd}" Width="100%"></asp:TextBox>
                </td>
                <td style="width: 73px">到：</td>
                <td style="width:15%">
                    <asp:TextBox ID="TextBox6" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D' ,true)"
                                    DataFormatString="{0:yyyy-MM-dd}" Width="100%"></asp:TextBox>
                </td>
                <td style="width: 84px">版本号：</td>
                <td style="width:15%">
                    <asp:TextBox ID="TextBox4" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td style="width: 48px">&nbsp;</td>
                <td style="width:15%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 72px">更改类型：</td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem>所有类型</asp:ListItem>
                        <asp:ListItem>新增</asp:ListItem>
                        <asp:ListItem>修改</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 73px">状态：</td>
                <td>
                    <asp:TextBox ID="TextBox8" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td style="width: 84px">申请人：</td>
                <td>
                    <asp:TextBox ID="TextBox9" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td style="width: 48px">&nbsp;</td>
                <td>
                    <asp:Label ID="Labelstate" runat="server" Text="state" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 72px">&nbsp;</td>
                <td>
                    <asp:Button ID="Button1" runat="server" CssClass="Button02" Text="检索" Width="66px" UseSubmitBehavior="false" OnClick="Button1_Click" />
                </td>
                <td style="width: 73px">&nbsp;</td>
                <td>
                    <asp:Button ID="Button2" CssClass="Button02"  runat="server" OnClick="Reset_Click" Text="重置" Width="66px" UseSubmitBehavior="false"/>
                </td>
                <td style="width: 84px">&nbsp;</td>
                <td>
                    <asp:TextBox ID="TextBox7" runat="server" Visible="False" Width="100%"></asp:TextBox>
                </td>
                <td style="width: 48px">&nbsp;</td>
                <td>&nbsp;</td>
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
            <legend>BOM文件</legend>
            <asp:GridView ID="GridView1" runat="server" CssClass="GridViewStyle"  AllowPaging="True" PageSize="10" AutoGenerateColumns="False" 
                        GridLines="None" EmptyDataText="没有相关记录" OnRowCommand="GridView1_RowCommand"
                         DataKeyNames="CDA_ID"  OnPageIndexChanging="GridView1_PageIndexChanging" EnableModelValidation="True">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="CDA_ID" HeaderText="BOMID" Visible="false" SortExpression="SMSMPM_ID" />
                            <asp:BoundField DataField="CDA_DocName" HeaderText="BOM文件名称" Visible="true" SortExpression="PMP_ID" />
                            <asp:BoundField DataField="CDA_AppNO" HeaderText="申请单号" Visible="true" SortExpression="SMSMPM_Year" />
                            <asp:BoundField DataField="CDA_DocNO" HeaderText="受控文件编号" Visible="true" SortExpression="SMSMPM_Year" />
                            <asp:BoundField DataField="CDA_EditionNO" HeaderText="版本号" Visible="true" SortExpression="SMSMPM_Month" />
                            <asp:BoundField DataField="CDA_DocType" HeaderText="受控文件类型" Visible="true" SortExpression="SMSMPM_MakeMan" />
                            <asp:BoundField DataField="CDA_ChangedType" HeaderText="更改类型" Visible="true" SortExpression="SMSMPM_MakeTime" />
                            <asp:BoundField DataField="CDA_AppState" HeaderText="状态" Visible="true"  SortExpression="PMP_STime" />
                            <asp:BoundField DataField="CDA_AppPer" HeaderText="申请人" Visible="true" SortExpression="PMP_ETime" />
                            <asp:BoundField DataField="CDA_AppTime" HeaderText="申请时间" DataFormatString="{0:yyyy-MM-dd HH:mm}"  
                                Visible="true" SortExpression="PMP_Man" />
                            <asp:BoundField DataField="CDA_State" HeaderText="文件状态" Visible="true" SortExpression="PMP_ETime" />


                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Detail" runat="server" CommandArgument='<%# Eval("CDA_ID") %>' CommandName="Details">详细</asp:LinkButton>
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
    <asp:Panel ID="Panel3" runat="server">
        <fieldset>
            <legend>BOM</legend>
            <asp:Label ID="Label1" runat="server" Text="BOM_FID1" Visible="False"></asp:Label>
            BOM文件：<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            的相关信息<asp:Button ID="Button21" runat="server" CssClass="Button02" OnClick="Button21_Click" UseSubmitBehavior="false" Text="新增" Width="66px" />
            <asp:Button ID="Button22" runat="server" CssClass="Button02" OnClick="Butto22_Click" UseSubmitBehavior="false" Text="关闭" Width="66px" />
            
            <asp:GridView ID="GridView2" runat="server" CssClass="GridViewStyle"  AllowPaging="True" AutoGenerateColumns="False" 
                        GridLines="None" EmptyDataText="没有相关记录" OnRowCommand="GridView2_RowCommand" PageSize="10"
                         DataKeyNames="BOM_ID"  OnPageIndexChanging="GridView2_PageIndexChanging" EnableModelValidation="True" OnRowDeleting="GridView2_RowDeleting">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="BOM_ID" HeaderText="BOMID" Visible="false" SortExpression="SMSMPM_ID" />
                            <asp:BoundField DataField="BOM_Name" HeaderText="BOM名称" Visible="true" SortExpression="PMP_ID" />
                            <asp:BoundField DataField="BOM_SpecialBOM" HeaderText="是否为特殊BOM" Visible="true" SortExpression="SMSMPM_Year" />
                            <asp:BoundField DataField="BOM_WritePeople" HeaderText="制定人" Visible="true" SortExpression="SMSMPM_Year" />
                            <asp:BoundField DataField="BOM_WriteTime" HeaderText="制定时间" Visible="true" 
                               DataFormatString="{0:yyyy-MM-dd HH:mm}"  SortExpression="SMSMPM_Month" />
                            <asp:BoundField DataField="BOM_State" HeaderText="BOM状态" Visible="true" SortExpression="SMSMPM_Year" />


                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Modify" runat="server" CommandArgument='<%# Eval("BOM_ID") %>' CommandName="Modify">修改</asp:LinkButton>
                                </ItemTemplate>
                                </asp:TemplateField>

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Detail" runat="server" CommandArgument='<%# Eval("BOM_ID") %>' CommandName="Details">详细</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField >
                                <ItemTemplate>
                                    <asp:LinkButton ID="delete" runat="server" CausesValidation="False" CommandName="Delete" OnClientClick="return confirm('您确认删除该记录吗?')" CommandArgument='<%# Eval("BOM_ID") %>' Text="删除"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            
                           <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Copy" runat="server" CommandArgument='<%# Eval("BOM_ID") %>' CommandName="Copy">从其他BOM复制</asp:LinkButton>
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

    <asp:Panel ID="Panel31" runat="server">
        <fieldset><legend>
            <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label>
            BOM文件：<asp:Label ID="Label12" runat="server" Text="Label"></asp:Label>
            下的BOM<asp:Label ID="Label13" runat="server" Text="BOM_ID13" Visible="False"></asp:Label>
            </legend>
            <table style="width:100%;">
                <tr>
                    <td style="height: 21px">BOM名称</td>
                    <td style="height: 21px">
                        <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                        <asp:Label ID="Label535" runat="server" ForeColor="red" Text="*"></asp:Label>
                    </td>
                    <td style="height: 21px">是否为特殊BOM:</td>
                    <td style="height: 21px">
                        <asp:DropDownList ID="DropDownList2" runat="server">
                            <asp:ListItem>否</asp:ListItem>
                            <asp:ListItem>是</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="Button23" runat="server" CssClass="Button02" UseSubmitBehavior="false" OnClick="Button23_Click" Text="提交" Width="66px" />
                    </td>
                    <td>
                        <asp:Button ID="Button24" runat="server" CssClass="Button02" UseSubmitBehavior="false" OnClick="Button24_Click" Text="关闭" Width="66px" />
                    </td>
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
        <fieldset>
            <legend>BOM详细</legend>
            <asp:Label ID="Label3" runat="server" Text="BOM_ID3" Visible="False"></asp:Label>
            BOM:<asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
            的详细信息<asp:Button ID="Button31" runat="server" CssClass="Button02" UseSubmitBehavior="false"  OnClick="Button31_Click" Text="新增" Width="66px" CausesValidation="False" />
            <asp:Button ID="Button32" runat="server" CssClass="Button02" UseSubmitBehavior="false"  OnClick="Button32_Click" Text="关闭" Width="66px" CausesValidation="False" />
            <asp:GridView ID="GridView3" runat="server" AllowPaging="True" AutoGenerateColumns="False" 
                CssClass="GridViewStyle" DataKeyNames="BD_ID" EmptyDataText="没有相关记录,请新增。" 
                GridLines="None" OnPageIndexChanging="GridView3_PageIndexChanging" OnRowCommand="GridView3_RowCommand" EnableModelValidation="True" OnRowDeleting="GridView3_RowDeleting" OnRowDataBound="GridView3_RowDataBound">
                <RowStyle CssClass="GridViewRowStyle" />
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle CssClass="GridViewHead" />
                <FooterStyle CssClass="GridViewFooterStyle" />
                <Columns>
                    <asp:BoundField DataField="BD_ID" HeaderText="BOM详细ID" SortExpression="BD_ID" Visible="false" />
                    <asp:BoundField DataField="IMMBD_MaterialName" HeaderText="物料名称" SortExpression="IMMBD_MaterialName" Visible="true" />
                    <asp:BoundField DataField="IMMBD_SpecificationModel" HeaderText="规格型号" SortExpression="IMMBD_SpecificationModel" Visible="true" />
                    <asp:BoundField DataField="PBC_Name" HeaderText="工序名称" SortExpression="SMSMPM_Year" Visible="true" />
                    <asp:BoundField DataField="BD_MUse" HeaderText="标准用量" SortExpression="SMSMPM_Month" Visible="true" />
                    <asp:BoundField DataField="BD_MRUse" HeaderText="实际用量" SortExpression="SMSMPM_MakeMan" Visible="true" />
                    <asp:BoundField DataField="UnitName" HeaderText="计量单位" SortExpression="SMSMPM_MakeTime" Visible="true" />
                    <asp:BoundField DataField="StoreUse" HeaderText="库存用量" SortExpression="SMSMPM_MakeMan" Visible="true" />
                    <asp:BoundField DataField="StoreUnitName" HeaderText="库存单位" SortExpression="SMSMPM_MakeTime" Visible="true" />
                    <asp:BoundField DataField="BD_Note" HeaderText="备注" SortExpression="PMP_STime" Visible="true" />
                    <asp:BoundField DataField="BDMate" HeaderText="替用物料型号" SortExpression="PMP_STime" Visible="true" />
                    <asp:BoundField DataField="IMMBD_MaterialID" HeaderText="物料ID" SortExpression="IMMBD_MaterialID" Visible="true" >
                    <HeaderStyle CssClass="hide" />
                    <ItemStyle CssClass="hide" />
                    </asp:BoundField>
                    <asp:BoundField DataField="PBC_ID" HeaderText="工序ID" SortExpression="PCB_ID" Visible="true" >
                    <HeaderStyle CssClass="hide" />
                    <ItemStyle CssClass="hide" />
                    </asp:BoundField>
                    <asp:BoundField DataField="BD_IsFuse" HeaderText="组合物料" NullDisplayText="否" />
                    <asp:BoundField DataField="BD_FuseID" HeaderText="组合代号" NullDisplayText="无" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="Modify" runat="server" CommandArgument='<%# Eval("BD_ID") %>' CommandName="Modify">修改</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="AddMate" runat="server" CommandArgument='<%# Eval("BD_ID") %>' CommandName="AddMate">为该物料增加可替用物料</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="AddFuse" runat="server" CommandArgument='<%# Eval("BD_ID") %>' CommandName="AddFuse">为该物料添加组合成员</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" OnClientClick="return confirm('您确认删除该记录吗?')" CommandArgument='<%# Eval("BD_ID") %>' Text="删除"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="BDMate_ID" HeaderText="MateID" SortExpression="BDMate_ID" Visible="true" >
                    <HeaderStyle CssClass="hide" />
                    <ItemStyle CssClass="hide" />
                    </asp:BoundField>
                       <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="AddPercent" runat="server" CommandArgument='<%# Eval("BD_ID") %>' CommandName="AddPercent">分配比例</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:BoundField DataField="BD_Man" HeaderText="修改人" SortExpression="PMP_STime" Visible="true" />
                    <asp:BoundField DataField="BD_Time" HeaderText="修改时间" 
                        DataFormatString="{0:yyyy-MM-dd HH:mm}" SortExpression="PMP_STime" Visible="true" />    
                      <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="history" runat="server" CommandArgument='<%# Eval("BD_ID") %>' CommandName="history">历史</asp:LinkButton>
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
    <asp:Panel ID="Panel41" runat="server">
         <fieldset><legend>
             <asp:Label ID="Label31" runat="server" Text="Label"></asp:Label>
             BOM<asp:Label ID="Label32" runat="server" Text="Label"></asp:Label>
             的详细信息<asp:Label ID="Label33" runat="server" Text="BD_ID33" Visible="False"></asp:Label>
             </legend>
             <table style="width:858px">
                 <tr>
                     <td style="width: 66px">物料名称：</td>
                     <td style="width: 151px">
                         <asp:Label ID="Label36" runat="server" Text="请选择物料"></asp:Label>
                         <asp:Button ID="Button38" runat="server" CssClass="Button02" UseSubmitBehavior="false" OnClick="Button38_Click" Text="选择物料" />
                     </td>
                     <td style="width: 63px">规格型号：&nbsp; </td>
                     <td style="width: 150px">
                         <asp:Label ID="Label37" runat="server" Text="请选择物料"></asp:Label>
                     </td>
                     <td style="width: 73px">工序名称：</td>
                     <td style="width: 107px">
                         <asp:Label ID="Label34" runat="server" Text="Label" Visible="False"></asp:Label>
                         <asp:Label ID="Label35" runat="server" Text="请选择工序"></asp:Label>
                         <asp:Button ID="Button33" runat="server" CssClass="Button02" UseSubmitBehavior="false" OnClick="Button33_Click" Text="选择工序" Width="66px" />
                     </td>
                     <td style="width: 74px">
                         <asp:Label ID="FuseText" runat="server" Text="组合物料:"></asp:Label>
                     </td>
                     <td style="width: 46px">
                         <asp:DropDownList ID="DropDownList4" runat="server">
                             <asp:ListItem Value="否">否</asp:ListItem>
                             <asp:ListItem Value="是">是</asp:ListItem>
                         </asp:DropDownList>
                     </td>
                 </tr>
                 <tr>
                     <td style="width: 66px">标准用量：</td>
                     <td style="width: 151px" >
                         <asp:TextBox ID="TextBox14" style="ime-mode:disabled; margin-right: 0px;" runat="server" onkeyup="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{2,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{2})[0-9]*/, '$1');" 
                              onafterpaste="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{2,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{2})[0-9]*/, '$1');" OnTextChanged="TextBox14_TextChanged" Width="90%"></asp:TextBox>
                         <asp:Label ID="Label536" runat="server" ForeColor="red" Text="*"></asp:Label>
                     </td>
                     <td style="width: 63px" >实际用量：</td>
                     <td style="width: 150px" >
                         <asp:TextBox ID="TextBox15" style="ime-mode:disabled;" runat="server" onkeyup="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{2,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{2})[0-9]*/, '$1');" 
                              onafterpaste="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{2,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{2})[0-9]*/, '$1');" Width="90%"></asp:TextBox>
                         <asp:Label ID="Label537" runat="server" ForeColor="red" Text="*"></asp:Label>
                     </td>
                     <td style="width: 73px">计量单位：</td>
                     <td style="width: 107px">
                         <asp:DropDownList ID="DropDownList3" runat="server">
                         </asp:DropDownList>
                         <asp:Button ID="Button39" runat="server" CssClass="Button02" UseSubmitBehavior="false" OnClick="Button39_Click" Text="新增单位" Width="66px" />
                     </td>
                     <td style="width: 74px">
                         &nbsp;</td>
                     <td style="width: 46px">
                         <asp:Label ID="FuseID" runat="server" Text="FuseID" Visible="False"></asp:Label>
                     </td>
                 </tr>
                 <tr>
                     <td style="width: 66px" >备注：</td>
                     <td colspan="5">
                         <asp:TextBox ID="TextBox17" runat="server" Width="90%" MaxLength="15"></asp:TextBox>
                         <asp:Label ID="Label538" runat="server" ForeColor="red" Text="*"></asp:Label>
                     </td>
                     <td style="width: 74px" >
                         <asp:Label ID="MateID" runat="server" Text="MateID" Visible="False"></asp:Label>
                     </td>
                     <td style="width: 46px">&nbsp;</td>
                 </tr>
                 <tr>
                     <td style="width: 66px" >&nbsp;</td>
                     <td style="width: 151px" >
                         <asp:Button ID="Button34" runat="server" CssClass="Button02" UseSubmitBehavior="false" OnClick="Button34_Click" Text="提交" Width="66px" ValidationGroup="D" />
                     </td>
                     <td style="width: 63px" >
                         <asp:Label ID="Label38" runat="server" Text="MID38" Visible="False"></asp:Label>
                     </td>
                     <td style="width: 150px" >
                         <asp:Button ID="Button35" runat="server" CssClass="Button02" UseSubmitBehavior="false" OnClick="Button35_Click" Text="关闭" Width="66px" CausesValidation="False" />
                     </td>
                     <td colspan="2">
                         <asp:Button ID="UnitCheck" runat="server" CssClass="Button02" OnClick="UnitCheck_Click" Text="查看该材料的所有单位" UseSubmitBehavior="False" Width="150px" Visible="False" />
                     </td>
                     <td style="width: 74px">&nbsp;</td>
                     <td style="width: 46px">&nbsp;</td>
                 </tr>
             </table>
         </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
         <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:Panel ID="Panel5" runat="server">
            
    <asp:Panel ID="Panel51" runat="server">
         <fieldset><legend>
             <asp:Label ID="Label17" runat="server" Text="Label" Visible="False"></asp:Label>
             <asp:Label ID="Label18" runat="server" Text="Label" Visible="False"></asp:Label>
             <asp:Label ID="Label19" runat="server" Text="Label" Visible="False"></asp:Label>
             </legend>
             <table style="width: 100%; height: 48px;">
                 <tr>
                     <td style="width: 62px">工序名称：</td>
                     <td style="width: 190px">
                         <asp:TextBox ID="TextBox16" runat="server" Width="171px"></asp:TextBox>
                     </td>
                     <td>
                         <asp:Button ID="Button36" runat="server" CssClass="Button02" UseSubmitBehavior="true" OnClick="Button36_Click" Text="检索" Width="66px" />
                         
                     </td>
                 </tr>
             </table>
            <asp:GridView ID="GridView4" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="GridViewStyle" DataKeyNames="PBC_ID" EmptyDataText="没有相关记录，请搜索。" GridLines="None" PageSize="15" OnPageIndexChanging="GridView4_PageIndexChanging" OnRowCommand="GridView4_RowCommand">
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
                            <asp:LinkButton ID="Modify" runat="server" CommandArgument='<%# Eval("PBC_ID") %>' CommandName="Choose">选择</asp:LinkButton>
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
        <asp:Panel ID="Panel52" runat="server">
         <fieldset><legend>
             <asp:Label ID="Label5" runat="server" Text="Label" Visible="False"></asp:Label>
             <asp:Label ID="Label6" runat="server" Text="Label" Visible="False"></asp:Label>
             <asp:Label ID="Label7" runat="server" Text="Label" Visible="False"></asp:Label>
             </legend>
             <table style="width: 100%; height: 48px;">
                 <tr>
                     <td style="width: 62px">物料名称：</td>
                     <td style="width: 190px">
                         <asp:TextBox ID="TextBox21" runat="server" Width="171px"></asp:TextBox>
                     </td>
                     <td>
                         型号：</td>
                     <td>
                         <asp:TextBox ID="TextBox22" runat="server" Width="171px"></asp:TextBox>
                     </td>
                     <td>
                         <asp:Button ID="Button37" runat="server" CssClass="Button02" OnClick="Button37_Click" Text="检索" Width="66px" UseSubmitBehavior="true" />
                     </td>
                 </tr>
             </table>
            <asp:GridView ID="GridView5" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="GridViewStyle" DataKeyNames="IMMBD_MaterialID" EmptyDataText="没有相关记录，请搜索。" GridLines="None" OnPageIndexChanging="GridView5_PageIndexChanging" OnRowCommand="GridView5_RowCommand" PageSize="15">
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
        <asp:Panel ID="Panel53" runat="server">
         <fieldset><legend>
             新增单位<asp:Label ID="Label8" runat="server" Text="Label" Visible="False"></asp:Label>
             </legend>
             <table style="width: 100%; height: 48px;">
                 <tr>
                     <td style="width: 62px">单位名称：</td>
                     <td style="width: 190px">
                         <asp:TextBox ID="TextBox23" runat="server" Width="171px"></asp:TextBox>
                     </td>
                     <td style="width: 171px">
                         <asp:Button ID="Button531" runat="server" CssClass="Button02" UseSubmitBehavior="true" OnClick="Button531_Click" Text="检索" Width="66px" />
                     </td>
                     <td>
                         <asp:Button ID="CloseAddUnit" runat="server" CssClass="Button02" OnClick="CloseAddUnit_Click" Text="关闭" UseSubmitBehavior="true" Width="66px" />
                     </td>
                     <td>
                         &nbsp;</td>
                 </tr>
             </table>
            <asp:GridView ID="GridView6" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="GridViewStyle" DataKeyNames="UnitID" EmptyDataText="没有相关记录" GridLines="None" OnPageIndexChanging="GridView6_PageIndexChanging" OnRowCommand="GridView6_RowCommand" PageSize="15">
                <RowStyle CssClass="GridViewRowStyle" />
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle CssClass="GridViewHead" />
                <FooterStyle CssClass="GridViewFooterStyle" />
                <Columns>
                    
                            <asp:BoundField DataField="UnitID" HeaderText="单位ID" Visible="false"  />
                            <asp:BoundField DataField="UnitName" HeaderText="单位名称" Visible="true" SortExpression="UnitName" />
                           
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("UnitID") %>' CommandName="Choose">选择</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerTemplate>
                    <table width="100%">
                        <tr>
                            <td style="text-align: right">第<asp:Label ID="Label14" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                页 共<asp:Label ID="Label15" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageCount  %>" />
                                页 
                                <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandArgument="First" CommandName="Page" Text="首页" />
                                <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" CommandArgument="Prev" CommandName="Page" Text="上一页" />
                                <asp:LinkButton ID="LinkButton5" runat="server" CausesValidation="False" CommandArgument="Next" CommandName="Page" Text="下一页" />
                                <asp:LinkButton ID="LinkButton6" runat="server" CausesValidation="False" CommandArgument="Last" CommandName="Page" Text="尾页" />
                                <asp:TextBox ID="textbox13" runat="server" Width="20px"></asp:TextBox>
                                <asp:LinkButton ID="LinkButton7" runat="server" CausesValidation="False" CommandArgument="-1" CommandName="Page" Text="GO" />
                                <!-- here set the CommandArgument of the Go Button to '-1' as the flag --></td>
                        </tr>
                    </table>
                </PagerTemplate>
            </asp:GridView>
             <table style="width:100%;">
                 <tr>
                     <td style="width: 228px">默认单位名称:</td>
                     <td style="width: 314px">
                         <asp:Label ID="Label531" runat="server" Text="默认单位531"></asp:Label>
                         <asp:Label ID="Label532" runat="server" Text="默认单位ID532" Visible="False"></asp:Label>
                     </td>
                     <td>&nbsp;</td>
                 </tr>
                 <tr>
                     <td style="width: 228px">本次新增单位名称:</td>
                     <td style="width: 314px">
                         <asp:Label ID="Label533" runat="server" Text="新增单位533"></asp:Label>
                         <asp:Label ID="Label534" runat="server" Text="新增单位Id534" Visible="False"></asp:Label>
                     </td>
                     <td>
                         <asp:Button ID="Button532" runat="server" CssClass="Button02" UseSubmitBehavior="false" OnClick="Button532_Click" Text="提交" Width="66px" />
                     </td>
                 </tr>
                 <tr>
                     <td style="width: 228px">换算比例(1默认单位可换算多少新增单位):</td>
                     <td style="width: 314px">
                         <asp:TextBox ID="TextBox24" style="ime-mode:disabled;" runat="server" onkeyup="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{2,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{2})[0-9]*/, '$1');" 
                              onafterpaste="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{2,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{2})[0-9]*/, '$1');" ></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox24" ErrorMessage="*"  ValidationGroup="E"></asp:RequiredFieldValidator>
                     </td>
                     <td>&nbsp;</td>
                 </tr>
             </table>
             <br />
         </fieldset>
            </asp:Panel>
        <asp:Panel ID="Panel54" runat="server">
         <fieldset><legend>
             查看<asp:Label ID="Unit_Mname" runat="server" Text="Unit_Mname"></asp:Label>
             的所有单位</legend>
                                      <asp:Button ID="CloseUnitCheck" runat="server" CssClass="Button02" UseSubmitBehavior="true" OnClick="CloseUnitCheck_Click" Text="关闭" Width="66px" />
                     
            <asp:GridView ID="GridView9" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle" DataKeyNames="IMUC_ID" EmptyDataText="没有相关记录" GridLines="None" OnRowCommand="GridView9_RowCommand" OnRowDataBound="GridView9_RowDataBound" >
                <RowStyle CssClass="GridViewRowStyle" />
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle CssClass="GridViewHead" />
                <FooterStyle CssClass="GridViewFooterStyle" />
                <Columns>
               
                    <asp:BoundField DataField="IMUC_ID" HeaderText="单位换算ID" Visible="false"  />
                   <asp:BoundField DataField="UnitName" HeaderText="单位名称" Visible="true" SortExpression="UnitName" />
                    <asp:BoundField DataField="IMUC_Rate" HeaderText="与默认单位的换算比例" Visible="true" SortExpression="UnitName" />
                    <asp:BoundField DataField="IMUC_Default" HeaderText="是否为库存默认单位" Visible="true" SortExpression="UnitName" />
                           
                    <asp:TemplateField> 
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("IMUC_ID") %>' CommandName="Modify">修改</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>  
                
            </asp:GridView>
             <asp:Panel  ID="Panel55" runat="server" Visible="False">
             <table style="width:100%;">
                 <tr>
                     <td style="width: 228px">换算比例(1默认单位可换算多少本单位):</td>
                     <td style="width: 314px">
                         <asp:TextBox ID="TextBox18" runat="server" onafterpaste="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{2,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{2})[0-9]*/, '$1');" onkeyup="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{2,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{2})[0-9]*/, '$1');" style="ime-mode:disabled;"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox24" ErrorMessage="*" ValidationGroup="E"></asp:RequiredFieldValidator>
                     </td>
                     <td>
                         <asp:Button ID="SummitUnitModify" runat="server" CssClass="Button02" OnClick="SummitUnitModify_Click" Text="提交" UseSubmitBehavior="false" Width="66px" />
                         <asp:Label ID="UnitChangeID" runat="server" Text="UnitChangeID" Visible="False"></asp:Label>
                     </td>
                 </tr>
             </table>
                 </asp:Panel>
             <br />
         </fieldset>
            </asp:Panel>
        </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
     <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:Panel ID="Panel6" runat="server">
         <fieldset>检索BOM<legend>
             <asp:Label ID="Label9" runat="server" Text="Label" Visible="False"></asp:Label>
             <asp:Label ID="Label10" runat="server" Text="Label" Visible="False"></asp:Label>
             <asp:Label ID="Label16" runat="server" Text="Label" Visible="False"></asp:Label>
             </legend>
             <table style="width: 100%; height: 48px;">
                 <tr>
                     <td style="width: 96px; height: 46px;">BOM名称：</td>
                     <td style="width: 190px; height: 46px;">
                         <asp:TextBox ID="TextBox11" runat="server" Width="171px"></asp:TextBox>
                     </td>
                     <td style="height: 46px">
                         <asp:Button ID="searchBOM" runat="server" CssClass="Button02" UseSubmitBehavior="true" OnClick="SearchBom" Text="检索" Width="66px" />
                         
                     </td>
                 </tr>
             </table>
            <asp:GridView ID="GridView7" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="GridViewStyle" DataKeyNames="BOM_ID" EmptyDataText="没有相关记录，请搜索。" GridLines="None" OnPageIndexChanging="GridView4_PageIndexChanging" OnRowCommand="GridView7_RowCommand">
                <RowStyle CssClass="GridViewRowStyle" />
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle CssClass="GridViewHead" />
                <FooterStyle CssClass="GridViewFooterStyle" />
                <Columns>
                    <asp:BoundField DataField="BOM_ID" HeaderText="BOMID" SortExpression="SMSMPM_ID" Visible="false" />
                    <asp:BoundField DataField="BOM_Name" HeaderText="BOM名称" SortExpression="PMP_ID" Visible="true" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="Choose" runat="server" CommandArgument='<%# Eval("BOM_ID") %>' CommandName="Choose">选择</asp:LinkButton>
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
        </ContentTemplate>

     </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:Panel ID="Panel8" runat="server">
        <fieldset>
            <legend>填写物料比例 </legend> 
            <asp:GridView ID="GridView8" runat="server" CssClass="GridViewStyle"  AutoGenerateColumns="False" 
                        GridLines="None" EmptyDataText="没有相关记录" OnRowCommand="GridView1_RowCommand"
                         DataKeyNames="BD_ID"  EnableModelValidation="True">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                              <asp:BoundField DataField="BD_ID" HeaderText="BOM详细ID" SortExpression="BD_ID" >
                              <HeaderStyle CssClass="hide" />
                              <ItemStyle CssClass="hide" />
                              </asp:BoundField>
                    <asp:BoundField DataField="IMMBD_MaterialName" HeaderText="物料名称" SortExpression="IMMBD_MaterialName" Visible="true" />
                    <asp:BoundField DataField="IMMBD_SpecificationModel" HeaderText="规格型号" SortExpression="IMMBD_SpecificationModel" Visible="true" />
                    <asp:BoundField DataField="PBC_Name" HeaderText="工序名称" SortExpression="SMSMPM_Year" Visible="true" />
                    <asp:BoundField DataField="BD_MUse" HeaderText="标准用量" SortExpression="SMSMPM_Month" Visible="true" />
                    <asp:BoundField DataField="BD_MRUse" HeaderText="实际用量" SortExpression="SMSMPM_MakeMan" Visible="true" />
                    <asp:BoundField DataField="UnitName" HeaderText="计量单位" SortExpression="SMSMPM_MakeTime" Visible="true" />
                    <asp:BoundField DataField="BD_Note" HeaderText="备注" SortExpression="PMP_STime" Visible="true" />


                            <asp:TemplateField>
                            <ItemTemplate>
                                <asp:TextBox runat="server"   ID ="bl"></asp:TextBox>
                            </ItemTemplate>
                            <HeaderTemplate>
                                <asp:Label  ID="hsrq" runat ="server" Text="新物料比例"></asp:Label>
                            </HeaderTemplate>
                        </asp:TemplateField>
                            
                              <asp:BoundField DataField="BD_Percent" HeaderText="原物料比例" />
                            
                        </Columns>
                        
                    </asp:GridView>
        <table style="width:100%;text-align:left;">
            <tr><td style="width: 97px">&nbsp;</td>
                <td style="width: 191px">&nbsp;</td>
                <td style="width: 190px">
                    <asp:Button ID="SummitPercent" runat="server" CssClass="Button02" OnClick="SummitPercent_Click" Text="提交" UseSubmitBehavior="false" Width="66px" />
                </td>
                <td>
                    <asp:Button ID="ClosePercent" runat="server" CssClass="Button02" OnClick="ClosePercent_Click" Text="关闭" UseSubmitBehavior="false" Width="66px" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
            </fieldset>
    </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel10" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:Panel ID="Panel10" runat="server" Visible="False">
        <fieldset>  
            <legend>历史信息</legend>
            <asp:Button ID="closehistory" runat="server" CssClass="Button02" UseSubmitBehavior="false"  OnClick="closehistory_Click" Text="关闭" Width="66px" CausesValidation="False" />
            <asp:GridView ID="GridView10" runat="server" AutoGenerateColumns="False" 
                CssClass="GridViewStyle" DataKeyNames="BD_ID" EmptyDataText="还没有相关历史记录。" 
                GridLines="None"  EnableModelValidation="True"  >
                <RowStyle CssClass="GridViewRowStyle" />
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle CssClass="GridViewHead" />
                <FooterStyle CssClass="GridViewFooterStyle" />
                <Columns>
                    <asp:BoundField DataField="BD_ID" HeaderText="BOM详细ID" SortExpression="BD_ID" Visible="false" />
                    <asp:BoundField DataField="IMMBD_MaterialName" HeaderText="物料名称" SortExpression="IMMBD_MaterialName" Visible="true" />
                    <asp:BoundField DataField="IMMBD_SpecificationModel" HeaderText="规格型号" SortExpression="IMMBD_SpecificationModel" Visible="true" />
                    <asp:BoundField DataField="PBC_Name" HeaderText="工序名称" SortExpression="SMSMPM_Year" Visible="true" />
                    <asp:BoundField DataField="BD_MUse" HeaderText="标准用量" SortExpression="SMSMPM_Month" Visible="true" />
                    <asp:BoundField DataField="BD_MRUse" HeaderText="实际用量" SortExpression="SMSMPM_MakeMan" Visible="true" />
                    <asp:BoundField DataField="UnitName" HeaderText="计量单位" SortExpression="SMSMPM_MakeTime" Visible="true" />
                    <asp:BoundField DataField="StoreUse" HeaderText="库存用量" SortExpression="SMSMPM_MakeMan" Visible="true" />
                    <asp:BoundField DataField="StoreUnitName" HeaderText="库存单位" SortExpression="SMSMPM_MakeTime" Visible="true" />
                    <asp:BoundField DataField="BD_Note" HeaderText="备注" SortExpression="PMP_STime" Visible="true" />
                    <asp:BoundField DataField="BDMate" HeaderText="替用物料型号" SortExpression="PMP_STime" Visible="true" />
                    <asp:BoundField DataField="IMMBD_MaterialID" HeaderText="物料ID" SortExpression="IMMBD_MaterialID" Visible="true" >
                    <HeaderStyle CssClass="hide" />
                    <ItemStyle CssClass="hide" />
                    </asp:BoundField>
                    <asp:BoundField DataField="PBC_ID" HeaderText="工序ID" SortExpression="PCB_ID" Visible="true" >
                    <HeaderStyle CssClass="hide" />
                    <ItemStyle CssClass="hide" />
                    </asp:BoundField>
                    <asp:BoundField DataField="BD_IsFuse" HeaderText="组合物料" NullDisplayText="否" />
                    <asp:BoundField DataField="BD_FuseID" HeaderText="组合代号" NullDisplayText="无" />
                
                     <asp:BoundField DataField="BD_Man" HeaderText="修改人" SortExpression="PMP_STime" Visible="true" />
                    <asp:BoundField DataField="BD_Time" HeaderText="修改时间" 
                        DataFormatString="{0:yyyy-MM-dd HH:mm}" SortExpression="PMP_STime" Visible="true" />
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
    
        </ContentTemplate>
    </asp:UpdatePanel>
         
</asp:Content>

