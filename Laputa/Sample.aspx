<%@ Page Title="" Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true" CodeFile="Sample.aspx.cs" Inherits="Laputa_Sample" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>

   
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Label ID="Labelstate" runat="server" Text="state" Visible="False"></asp:Label>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server">
                <fieldset>
                    <legend>样品检索
                    </legend>
                    <table style="width: 100%" >
                        <tr>
                            <td style="width: 60px" >客户名称：</td>
                            <td style="width: 160px" >
                                <asp:TextBox ID="TextBox1" runat="server" Width="100%"></asp:TextBox>
                            </td>
                            <td style="width: 60px" >申请人：</td>
                            <td style="width: 160px" >
                                <asp:TextBox ID="TextBox2" runat="server" Width="100%"></asp:TextBox>
                            </td>
                            <td style="width: 92px" >产品型号号：</td>
                            <td >
                                <asp:TextBox ID="TextBox3" runat="server" Width="100%"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 64px" >&nbsp;日期从：</td>
                            <td style="width: 160px" >
                                <asp:TextBox ID="TextBox5" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D' ,true)"
                                             DataFormatString="{0:yyyy-MM-dd}" Width="100%"></asp:TextBox>
                            </td>
                            <td style="width: 57px" >到：</td>
                            <td style="width: 160px" >
                                <asp:TextBox ID="TextBox6" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D' ,true)"
                                             DataFormatString="{0:yyyy-MM-dd}" Width="100%"></asp:TextBox>
                            </td>
                            <td style="width: 92px" >负责生产部门：</td>
                            <td >
                                <asp:TextBox ID="TextBox7" runat="server" Width="100%"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 64px" >状态：</td>
                            <td style="width: 169px" >
                                <asp:DropDownList ID="DropDownList1" runat="server">
                                    <asp:ListItem>所有状态</asp:ListItem>
                                    <asp:ListItem>已建立</asp:ListItem>
                                    <asp:ListItem>审核通过</asp:ListItem>
                                    <asp:ListItem>审批通过</asp:ListItem>
                                    <asp:ListItem>审核驳回</asp:ListItem>
                                    <asp:ListItem>审批驳回</asp:ListItem>
                                    <asp:ListItem>未生产</asp:ListItem>
                                    <asp:ListItem>已生产</asp:ListItem>
                                    <asp:ListItem>已接收</asp:ListItem>
                                    <asp:ListItem>已检验</asp:ListItem>
                                    <asp:ListItem>已发货</asp:ListItem>
                                     <asp:ListItem>已使用</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="width: 57px" >&nbsp;</td>
                            <td style="width: 162px" >
                                &nbsp;</td>
                            <td style="width: 92px">&nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 64px" >&nbsp;</td>
                            <td style="width: 169px" >
                                <asp:Button ID="Button1" runat="server" CssClass="Button02" Text="检索" Width="66px" OnClick="Button1_Click" />
                            </td>
                            <td style="width: 57px" >&nbsp;</td>
                            <td style="width: 162px" >
                                <asp:Button ID="Button11" runat="server" CssClass="Button02" OnClick="Button11_Click" Text="新增" Width="66px" />
                            </td>
                            <td style="width: 92px" >&nbsp; 
                                <asp:Label ID="ProDep" runat="server" Text="ProDep" Visible="False"></asp:Label>
                            </td>
                            <td>
                                <asp:Button ID="Buttonre" runat="server" CssClass="Button02" OnClick="Reset1_Click" Text="重置" Width="57px" />
                            </td>
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
                    <legend>公司样品表 </legend>
                    <asp:GridView ID="GridView1" runat="server" CssClass="GridViewStyle"  AllowPaging="True" PageSize="15" AutoGenerateColumns="False" 
                                  GridLines="None" EmptyDataText="没有相关记录" OnRowCommand="GridView1_RowCommand"
                                  DataKeyNames="CRMCS_ID"  OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound" EnableModelValidation="True" >
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="CRMCS_ID" HeaderText="样品表ID" Visible="false" />
                            <asp:BoundField DataField="CRMCS_Num" HeaderText="样品编号" Visible="true" SortExpression="PMP_ID" />
                            <asp:BoundField DataField="PT_Name" HeaderText="样品型号" Visible="true" SortExpression="SMSMPM_Year" />
                            <asp:BoundField DataField="CRMCS_ProductNum" HeaderText="样品数量" Visible="true" SortExpression="PMP_ID" />
                            <asp:BoundField DataField="Client_Name" HeaderText="客户名称" Visible="true" SortExpression="SMSMPM_Year" />
                             <asp:BoundField DataField="Client_Code" HeaderText="客户代码" Visible="true" SortExpression="SMSMPM_Year" />
                            <asp:BoundField DataField="CRMCS_MakeTime" HeaderText="创建时间" Visible="true" DataFormatString="{0:yyyy-MM-dd HH:mm}"  SortExpression="SMSMPM_Month" />
                            <asp:BoundField DataField="BDOS_Name" HeaderText="生产部门" Visible="true" SortExpression="SMSMPM_MakeTime" />
                            <asp:BoundField DataField="CRMCS_Remar" HeaderText="备注" Visible="true"  SortExpression="PMP_STime" />
                            <asp:BoundField DataField="CRMCS_State" HeaderText="状态" Visible="true" SortExpression="PMP_ETime" />
                            <asp:BoundField DataField="CRMCS_AuditNote" HeaderText="审核意见" Visible="true" SortExpression="PMP_ETime" />
                            <asp:BoundField DataField="CRMCS_SuperAuditNote" HeaderText="审批意见" Visible="true" SortExpression="PMP_ETime" />
                           


                            <asp:BoundField DataField="CRMCS_MakeMan" HeaderText="申请人" />
                            <asp:BoundField DataField="BDOS_Code" HeaderText="机构ID" Visible="true"  SortExpression="PMP_STime" >
                                <HeaderStyle CssClass="hide" />
                                <ItemStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PT_ID" HeaderText="型号ID" Visible="true" SortExpression="PMP_Man" >
                                <HeaderStyle CssClass="hide" />
                                <ItemStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCS_AppDep" HeaderText="申请部门" />
                           


                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="ed" runat="server" CommandArgument='<%# Eval("CRMCS_ID") %>' CommandName="ed">编辑</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="de" runat="server" OnClientClick=" return confirm('您确认删除该记录吗?') " CommandArgument='<%# Eval("CRMCS_ID") %>' CommandName="de">删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="see" runat="server" CommandArgument='<%# Eval("CRMCS_ID") %>' CommandName="see">查看进度</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="upd" runat="server" CommandArgument='<%# Eval("CRMCS_ID") %>' CommandName="upd">新增进度</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="audit" runat="server" CommandArgument='<%# Eval("CRMCS_ID") %>' CommandName="audit">审核</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="superaudit" runat="server" CommandArgument='<%# Eval("CRMCS_ID") %>' CommandName="superaudit">审批</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField>
                        <ItemTemplate>
                            <asp:HyperLink ID="DownLoad" runat="server" NavigateUrl='<%#"~/"+Eval("FileUrl")%>' >下载文件</asp:HyperLink >
                        </ItemTemplate>
                        <ItemStyle/>
                    </asp:TemplateField>
                              <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="shiyong" runat="server" CommandArgument='<%# Eval("CRMCS_ID") %>' CommandName="shiyong">录入使用情况</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第<asp:Label ID="lblPageIndex" runat="server" Text='<%# ((GridView) Container.Parent.Parent).PageIndex + 1 %>' />
                                        页 共<asp:Label ID="lblPageCount" runat="server" Text='<%# ((GridView) Container.Parent.Parent).PageCount %>' />
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
                    <table style="text-align: left; width: 100%;">
           
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="GridView1" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel3" runat="server">
                <fieldset>
                    <legend>进度详情表</legend>
                    <asp:Label ID="Label1" runat="server" Text="sampleid1" Visible="False"></asp:Label>
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                    号样品跟踪<asp:Button ID="Button22" runat="server" CssClass="Button02" OnClick="Butto22_Click" Text="关闭" Width="66px" />
            
                    <asp:GridView ID="GridView2" runat="server" CssClass="GridViewStyle"  AllowPaging="True" PageSize="5" AutoGenerateColumns="False" 
                                  GridLines="None" EmptyDataText="没有相关记录" OnRowCommand="GridView2_RowCommand"
                                  DataKeyNames="CRMCSS_ID"  OnPageIndexChanging="GridView2_PageIndexChanging" OnRowDataBound="GridView2_RowDataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="CRMCSS_ID" HeaderText="跟踪ID" Visible="false" SortExpression="SMSMPM_ID" />
                            <asp:BoundField DataField="CRMCS_Num" HeaderText="样品编号" Visible="true" SortExpression="PMP_ID" />
                            <asp:BoundField DataField="PT_Name" HeaderText="产品型号" Visible="true" SortExpression="SMSMPM_Year" />
                            
                            <asp:BoundField DataField="CRMCSS_ProcessName" HeaderText="状态" Visible="true" SortExpression="SMSMPM_Year" />
                            <asp:BoundField DataField="CRMCSS_Result" HeaderText="结果" Visible="true" SortExpression="SMSMPM_Year" />
                            <asp:BoundField DataField="CRMCSS_Note" HeaderText="备注" Visible="true" SortExpression="SMSMPM_Year" />
                            <asp:BoundField DataField="CRMCSS_Time" HeaderText="录入时间" DataFormatString="{0:yyyy-MM-dd HH:mm}" Visible="true" SortExpression="SMSMPM_Year" />
                            <asp:BoundField DataField="CRMCSS_ManName" HeaderText="录入人" Visible="true" SortExpression="SMSMPM_Month" />


                           

                            
                            
                            
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第<asp:Label ID="lblPageIndex" runat="server" Text='<%# ((GridView) Container.Parent.Parent).PageIndex + 1 %>' />
                                        页 共<asp:Label ID="lblPageCount" runat="server" Text='<%# ((GridView) Container.Parent.Parent).PageCount %>' />
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
                    <table style="text-align: left; width: 100%;">
           
                    </table>
                </fieldset>
            </asp:Panel>
            <asp:Panel ID="Panel31" runat="server">
                <fieldset><legend>
                              <asp:Label ID="Label31" runat="server" Text="Label"></asp:Label>
                              公司样品<asp:Label ID="Label33" runat="server" Text="SAMPLEID33" Visible="False"></asp:Label>
                              <asp:Label ID="Label13" runat="server" Text="sampleid13" Visible="False"></asp:Label>
                          </legend>
                    <table  style="width: 100%">
                        <tr>
                            <td style="width: 10%">生产部门： </td>
                            <td style="width: 33%">
                                <asp:Label ID="Label35" runat="server" Text="未选择生产部门"></asp:Label>
                                <asp:Button ID="Button38" runat="server" CssClass="Button02" OnClick="Button38_Click" Text="选择生产部门" Width="91px" CausesValidation="False" />
                                <asp:Label ID="Label34" runat="server" Text="bdid34" Visible="False"></asp:Label>
                            </td>
                                <td style="width: 10%">客户名称：</td>
                            <td style="width: 18%">
                                <asp:TextBox ID="clientname" runat="server"></asp:TextBox>
                                <asp:Label ID="Label536" runat="server" ForeColor="red" Text="*"></asp:Label>
                            </td>
                            <td style="width: 9%">客户代码：</td>
                            <td style="width: 40%">
                                <asp:TextBox ID="clientcode" runat="server"></asp:TextBox>
                                <asp:Label ID="Label537" runat="server" ForeColor="red" Text="*"></asp:Label>
                            </td>
                           <tr>
                               <td colspan="6"><asp:Label ID="Label27" runat="server" ForeColor="Red" Text="新建时先选择生产部门和填写客户名称和代码，编辑状态下可以编辑除产品型号外其他信息"></asp:Label></td>
                           </tr>
                         
                        </tr>
                       
                    
                        <tr >
                            <td style="text-align: left">产品型号：</td>
                            <td style="width: 33%" >
                                <asp:Label ID="Label36" runat="server" Text="未选择产品型号"></asp:Label>
                                <asp:Button ID="Button33" runat="server" CssClass="Button02" OnClick="Button33_Click" Text="选择产品型号" Width="87px"  />
                                <asp:Label ID="Label37" runat="server" Text="typeid37" Visible="False"></asp:Label>
                            </td>
                             <td style="text-align: left" >数量：</td>
                            <td colspan="3" >
                                <asp:TextBox ID="TextBox23" runat="server" CssClass="imeoff" onkeyup="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{2,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{2})[0-9]*/, '$1');" 
                                             onafterpaste="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{2,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{2})[0-9]*/, '$1');" ValidationGroup="D" AutoPostBack="True" OnTextChanged="TextBox23_TextChanged"></asp:TextBox>
                                <asp:Label ID="Label535" runat="server" ForeColor="red" Text="*"></asp:Label>
                            </td>
                        </tr>
                            <tr>
                            <td >备注：</td>
                            <td colspan="5">
                                <asp:TextBox ID="TextBox17" runat="server"  MaxLength="200" Height="58px" TextMode="MultiLine" Width="85%"></asp:TextBox>(不超过200个字)
                            </td>
                            
                        </tr>
                        <tr>
                           
                            <td colspan="2" align="center">
                                <asp:Button ID="Button34" runat="server" CssClass="Button02" OnClick="Button34_Click" Text="提交" Width="66px" ValidationGroup="D" />
                            </td>
                            
                            <td colspan="4" align="center">
                                <asp:Button ID="Button35" runat="server" CssClass="Button02" OnClick="Button35_Click" Text="关闭" Width="66px"  />
                            </td>
                            
                        </tr>
                    </table>

                </fieldset>
            </asp:Panel>
            
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            
            
                       
            
       
            <asp:Panel ID="Panel42" runat="server">
                <fieldset><legend>
                              <asp:Label ID="Label3" runat="server" Text="Label" Visible="False"></asp:Label>
                              <asp:Label ID="Label4" runat="server" Text="Label" Visible="False"></asp:Label>
                              <asp:Label ID="Label16" runat="server" Text="Label" Visible="False"></asp:Label>
                          </legend>
                    <table style="height: 48px; width: 100%;">
                        <tr>
                            <td style="width: 62px">随工单号：</td>
                            <td style="width: 190px">
                                <asp:TextBox ID="TextBox4" runat="server" Width="171px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="Button2" runat="server" CssClass="Button02" OnClick="Button2_Click" Text="检索" Width="66px" />
                         
                                <asp:Button ID="Button42" runat="server" CssClass="Button02" OnClick="Button42_Click" Text="关闭" Width="66px" />
                         
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="GridView3" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="GridViewStyle" 
                                  DataKeyNames="WO_Num" EmptyDataText="没有相关记录，请搜索。" GridLines="None" OnPageIndexChanging="GridView3_PageIndexChanging" OnRowCommand="GridView3_RowCommand" PageSize="5">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="WO_Num" HeaderText="随工单号" SortExpression="SMSMPM_ID" Visible="true" />
                            <asp:BoundField DataField="WO_ProType" HeaderText="产品型号" SortExpression="PMP_ID" Visible="true" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("WO_Num") %>' CommandName="Choose">选择</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">第<asp:Label ID="Label20" runat="server" Text="<%# ((GridView) Container.Parent.Parent).PageIndex + 1 %>" />
                                        页 共<asp:Label ID="Label21" runat="server" Text="<%# ((GridView) Container.Parent.Parent).PageCount %>" />
                                        页 
                                        <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandArgument="First" CommandName="Page" Text="首页" />
                                        <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" CommandArgument="Prev" CommandName="Page" Text="上一页" />
                                        <asp:LinkButton ID="LinkButton11" runat="server" CausesValidation="False" CommandArgument="Next" CommandName="Page" Text="下一页" />
                                        <asp:LinkButton ID="LinkButton12" runat="server" CausesValidation="False" CommandArgument="Last" CommandName="Page" Text="尾页" />
                                        <asp:TextBox ID="textbox9" runat="server" Width="20px"></asp:TextBox>
                                        <asp:LinkButton ID="LinkButton13" runat="server" CausesValidation="False" CommandArgument="-1" CommandName="Page" Text="GO" />
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

                <asp:Panel ID="Panel51" runat="server">
                    <fieldset><legend>
                                  <asp:Label ID="Label17" runat="server" Text="Label" Visible="False"></asp:Label>
                                  <asp:Label ID="Label18" runat="server" Text="Label" Visible="False"></asp:Label>
                                  <asp:Label ID="Label19" runat="server" Text="Label" Visible="False"></asp:Label>
                              </legend>
                        <table style="height: 48px; width: 100%;">
                            <tr>
                                <td style="width: 62px">生产部门：</td>
                                <td style="width: 190px">
                                    <asp:TextBox ID="TextBox16" runat="server" Width="171px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button ID="Button36" runat="server" CssClass="Button02" OnClick="Button36_Click" Text="检索" Width="66px" />
                         
                                    <asp:Button ID="Button48" runat="server" CssClass="Button02" OnClick="Button48_Click" Text="关闭" Width="66px" />
                         
                                </td>
                            </tr>
                        </table>
                        <asp:GridView ID="GridView4" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="GridViewStyle" 
                                      DataKeyNames="BDOS_Code" EmptyDataText="没有相关记录，请搜索。" GridLines="None" OnPageIndexChanging="GridView4_PageIndexChanging" OnRowCommand="GridView4_RowCommand" PageSize="10">
                            <RowStyle CssClass="GridViewRowStyle" />
                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                            <HeaderStyle CssClass="GridViewHead" />
                            <FooterStyle CssClass="GridViewFooterStyle" />
                            <Columns>
                                <asp:BoundField DataField="BDOS_Code" HeaderText="生产部门ID" SortExpression="SMSMPM_ID" Visible="false" />
                                <asp:BoundField DataField="BDOS_Name" HeaderText="生产部门" SortExpression="PMP_ID" Visible="true" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="cho" runat="server" CommandArgument='<%# Eval("BDOS_Code") %>' CommandName="Choose">选择</asp:LinkButton>
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
                <asp:Panel ID="Panel52" runat="server">
                    <fieldset><legend>
                                  <asp:Label ID="Label5" runat="server" Text="Label" Visible="False"></asp:Label>
                                  <asp:Label ID="Label6" runat="server" Text="Label" Visible="False"></asp:Label>
                                  <asp:Label ID="Label7" runat="server" Text="Label" Visible="False"></asp:Label>
                              </legend>
                        <table style="height: 48px; width: 100%;">
                            <tr>
                                <td style="width: 62px">产品型号：</td>
                                <td style="width: 190px">
                                    <asp:TextBox ID="TextBox21" runat="server" Width="171px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button ID="Button37" runat="server" CssClass="Button02" OnClick="Button37_Click" Text="检索" Width="66px" />
                                    <asp:Button ID="Button49" runat="server" CssClass="Button02" OnClick="Button49_Click" Text="关闭" Width="66px" />
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                        <asp:GridView ID="GridView5" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                      CssClass="GridViewStyle" DataKeyNames="PT_ID" EmptyDataText="没有相关记录，请搜索。"
                                      GridLines="None" OnPageIndexChanging="GridView5_PageIndexChanging" OnRowCommand="GridView5_RowCommand"
                                      PageSize="10">
                            <RowStyle CssClass="GridViewRowStyle" />
                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                            <HeaderStyle CssClass="GridViewHead" />
                            <FooterStyle CssClass="GridViewFooterStyle" />
                            <Columns>
                    
                                <asp:BoundField DataField="PT_ID" HeaderText="产品ID" Visible="false"/>
                                <asp:BoundField DataField="PT_Name" HeaderText="产品型号" Visible="true" />
                                 <asp:BoundField DataField="PT_Code" HeaderText="产品编码" Visible="true" />
                                <asp:BoundField DataField="PT_SpecialNeed" HeaderText="特殊要求" Visible="true" />
                                  <asp:BoundField DataField="PT_Note" HeaderText="产品备注" Visible="true" />
                                   <asp:TemplateField HeaderText="样品数量" HeaderStyle-Font-Bold="true" Visible="true">
                                <ItemTemplate>
                                    <asp:TextBox ID="TBNum" runat="server" Width="80px" onkeyup="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{2,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{2})[0-9]*/, '$1');" 
                                             onafterpaste="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{2,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{2})[0-9]*/, '$1');"></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle Font-Bold="True" />
                            </asp:TemplateField>
                                   <asp:TemplateField HeaderText="备注" HeaderStyle-Font-Bold="true" Visible="true" >
                                <ItemTemplate>
                                    <asp:TextBox ID="TBMark" runat="server" Width="200px" ></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle Font-Bold="True" />
                            </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="Modify" runat="server" CommandArgument='<%# Eval("PT_ID") %>' CommandName="Choose">提交</asp:LinkButton>
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
                <asp:Panel ID="Panel53" runat="server">
                    <fieldset><legend>
                                  <asp:Label ID="Label8" runat="server" Text="Label" Visible="False"></asp:Label>
                                  <asp:Label ID="Label9" runat="server" Text="Label" Visible="False"></asp:Label>
                                  <asp:Label ID="Label10" runat="server" Text="Label" Visible="False"></asp:Label>
                              </legend>
                        <table style="height: 48px; width: 100%;">
                            <tr>
                                <td style="width: 62px">客户名称：</td>
                                <td style="width: 190px">
                                    <asp:TextBox ID="TextBox24" runat="server" Width="171px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button ID="Button40" runat="server" CssClass="Button02" OnClick="Button40_Click" Text="检索" Width="66px" />
                                    <asp:Button ID="Button50" runat="server" CssClass="Button02" OnClick="Button50_Click" Text="关闭" Width="66px" />
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                        <asp:GridView ID="GridView6" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                      CssClass="GridViewStyle" DataKeyNames="CRMCIF_ID" EmptyDataText="没有相关记录，请搜索。"
                                      GridLines="None" OnPageIndexChanging="GridView6_PageIndexChanging"
                                      OnRowCommand="GridView6_RowCommand" PageSize="5">
                            <RowStyle CssClass="GridViewRowStyle" />
                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                            <HeaderStyle CssClass="GridViewHead" />
                            <FooterStyle CssClass="GridViewFooterStyle" />
                            <Columns>
                    
                                <asp:BoundField DataField="CRMCIF_ID" HeaderText="客户ID" Visible="false" SortExpression="IMMBD_MaterialID" />
                                <asp:BoundField DataField="CRMCIF_Name" HeaderText="客户名称" Visible="true" SortExpression="SMSMPM_Year" />

                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton5" runat="server" CommandArgument='<%# Eval("CRMCIF_ID") %>' CommandName="Choose">选择</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerTemplate>
                                <table width="100%">
                                    <tr>
                                        <td style="text-align: right">第<asp:Label ID="Label14" runat="server" Text="<%# ((GridView) Container.Parent.Parent).PageIndex + 1 %>" />
                                            页 共<asp:Label ID="Label15" runat="server" Text="<%# ((GridView) Container.Parent.Parent).PageCount %>" />
                                            页 
                                            <asp:LinkButton ID="LinkButton6" runat="server" CausesValidation="False" CommandArgument="First" CommandName="Page" Text="首页" />
                                            <asp:LinkButton ID="LinkButton7" runat="server" CausesValidation="False" CommandArgument="Prev" CommandName="Page" Text="上一页" />
                                            <asp:LinkButton ID="LinkButton8" runat="server" CausesValidation="False" CommandArgument="Next" CommandName="Page" Text="下一页" />
                                            <asp:LinkButton ID="LinkButton9" runat="server" CausesValidation="False" CommandArgument="Last" CommandName="Page" Text="尾页" />
                                            <asp:TextBox ID="textbox8" runat="server" Width="20px"></asp:TextBox>
                                            <asp:LinkButton ID="LinkButton10" runat="server" CausesValidation="False" CommandArgument="-1" CommandName="Page" Text="GO" />
                                            <!-- here set the CommandArgument of the Go Button to '-1' as the flag --></td>
                                    </tr>
                                </table>
                            </PagerTemplate>
                        </asp:GridView>
                    </fieldset>
                </asp:Panel>
                <asp:Panel ID="Panel54" runat="server">
                    <fieldset><legend>
                                  <asp:Label ID="Label22" runat="server" Text="Label" Visible="False"></asp:Label>
                                  <asp:Label ID="Label23" runat="server" Text="Label" Visible="False"></asp:Label>
                                  <asp:Label ID="Label24" runat="server" Text="Label" Visible="False"></asp:Label>
                              </legend>
                        <table style="height: 48px; width: 100%;">
                            <tr>
                                <td style="width: 62px">入库单号：</td>
                                <td style="width: 190px">
                                    <asp:TextBox ID="TextBox11" runat="server" Width="171px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button ID="Button3" runat="server" CssClass="Button02" OnClick="Button3_Click" Text="检索" Width="66px" />
                                    <asp:Button ID="Button4" runat="server" CssClass="Button02" OnClick="Button4_Click" Text="关闭" Width="66px" />
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                        <asp:GridView ID="GridView7" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                      CssClass="GridViewStyle" DataKeyNames="IMISM_InStoreNum" EmptyDataText="没有相关记录，请搜索。"
                                      GridLines="None" OnPageIndexChanging="GridView7_PageIndexChanging"
                                      OnRowCommand="GridView7_RowCommand" PageSize="5">
                            <RowStyle CssClass="GridViewRowStyle" />
                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                            <HeaderStyle CssClass="GridViewHead" />
                            <FooterStyle CssClass="GridViewFooterStyle" />
                            <Columns>
                    
                                <asp:BoundField DataField="IMISM_InStoreNum" HeaderText="入库单号" Visible="True" SortExpression="IMMBD_MaterialID" />
                          
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("IMISM_InStoreNum") %>' CommandName="Choose">选择</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerTemplate>
                                <table width="100%">
                                    <tr>
                                        <td style="text-align: right">第<asp:Label ID="Label25" runat="server" Text="<%# ((GridView) Container.Parent.Parent).PageIndex + 1 %>" />
                                            页 共<asp:Label ID="Label26" runat="server" Text="<%# ((GridView) Container.Parent.Parent).PageCount %>" />
                                            页 
                                            <asp:LinkButton ID="LinkButton14" runat="server" CausesValidation="False" CommandArgument="First" CommandName="Page" Text="首页" />
                                            <asp:LinkButton ID="LinkButton15" runat="server" CausesValidation="False" CommandArgument="Prev" CommandName="Page" Text="上一页" />
                                            <asp:LinkButton ID="LinkButton16" runat="server" CausesValidation="False" CommandArgument="Next" CommandName="Page" Text="下一页" />
                                            <asp:LinkButton ID="LinkButton17" runat="server" CausesValidation="False" CommandArgument="Last" CommandName="Page" Text="尾页" />
                                            <asp:TextBox ID="textbox12" runat="server" Width="20px"></asp:TextBox>
                                            <asp:LinkButton ID="LinkButton18" runat="server" CausesValidation="False" CommandArgument="-1" CommandName="Page" Text="GO" />
                                            <!-- here set the CommandArgument of the Go Button to '-1' as the flag --></td>
                                    </tr>
                                </table>
                            </PagerTemplate>
                        </asp:GridView>
                    </fieldset>
                </asp:Panel>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            

        
    
            <asp:Panel ID="Panel6" runat="server">
                <fieldset><legend>
                              样品进度<asp:Label ID="Label29" runat="server" Text="sampleid13" Visible="False"></asp:Label>
                              <asp:Label ID="Label30" runat="server" Text="cssid42" Visible="False"></asp:Label>
                          </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="height: 21px; width: 44px;">状态:</td>
                            <td style="height: 21px; width: 109px;">
                                <asp:DropDownList ID="DropDownList3" runat="server" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" AutoPostBack="True" >
                                    <asp:ListItem Value="未生产">未生产</asp:ListItem>
                                    <asp:ListItem Value="已生产">已生产</asp:ListItem>
                         
                                </asp:DropDownList>
                            </td>
                            <td style="height: 21px; width: 113px;">
                                <asp:Label ID="duedatelabel" runat="server" Text="预计生产完成时间:"></asp:Label>
                            </td>
                            <td style="height: 21px; width: 138px;">
                                <asp:TextBox ID="DueDate" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D' ,true)"
                                             DataFormatString="{0:yyyy-MM-dd}"></asp:TextBox>
                            </td>
                            <td style="height: 21px">
                                <asp:Label ID="Label32" runat="server" ForeColor="red" Text="*"></asp:Label>
                            </td>
                            <td style="height: 21px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="height: 21px; width: 44px;">备注:</td>
                            <td colspan="4" style="height: 21px; ">
                                <asp:TextBox ID="TextBox27" runat="server" Height="70px" TextMode="MultiLine" Width="542px"></asp:TextBox>
                            </td>
                            <td style="height: 21px">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 44px;">&nbsp;</td>
                            <td style="width: 109px;"></td>
                            <td style="width: 113px;">
                                &nbsp;<asp:Button ID="Summit_Product" runat="server" CssClass="Button02" OnClick="Summit_Product_Click" Text="提交" ValidationGroup="E" Width="66px" />
                            </td>
                            <td style="width: 138px;"></td>
                            <td>
                                &nbsp;<asp:Button ID="Button6" runat="server" CausesValidation="False" CssClass="Button02"  Text="关闭" Width="66px" OnClick="Button6_Click" />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            

        
    
            <asp:Panel ID="Panel7" runat="server">
                <fieldset><legend>
                              号样品已接收进度<asp:Label ID="Label40" runat="server" Text="sampleid13" Visible="False"></asp:Label>
                              <asp:Label ID="Label41" runat="server" Text="cssid42" Visible="False"></asp:Label>
                          </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="height: 21px; width: 38px;">状态:</td>
                            <td style="height: 21px; width: 75px;">
                                <asp:DropDownList ID="DropDownList4" runat="server" >
                                    <asp:ListItem Value="已接收">已接收</asp:ListItem>
                        
                                </asp:DropDownList>
                            </td>
                            <td style="height: 21px; width: 113px;">
                                是否上传</td>
                            <td style="height: 21px; width: 113px;">
                                <asp:DropDownList ID="DropDownList6" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList6_SelectedIndexChanged">
                                    <asp:ListItem>是</asp:ListItem>
                                    <asp:ListItem>否</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="height: 21px; width: 183px;">
                                <asp:FileUpload ID="FileUpload1" runat="server" />
                            </td>
                            <td style="height: 21px">&nbsp;</td>
                            <td style="height: 21px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="height: 21px; width: 38px;">备注:</td>
                            <td colspan="5" style="height: 21px;">
                                <asp:TextBox ID="TextBox25" runat="server" Width="542px" Height="70px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                            <td style="height: 21px">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 38px;">&nbsp;</td>
                            <td style="width: 75px;"></td>
                            <td style="width: 113px;">
                                &nbsp;<asp:Button ID="Summit_Get" runat="server" CssClass="Button02" OnClick="Summit_Get_Click" Text="提交" ValidationGroup="E" Width="66px" />
                            </td>
                            <td style="width: 113px;">
                                &nbsp;</td>
                            <td style="width: 183px;"></td>
                            <td>
                                &nbsp;<asp:Button ID="Button8" runat="server" CausesValidation="False" CssClass="Button02" Text="关闭" Width="66px" OnClick="Button8_Click" />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>    
       <Triggers>
            <asp:PostBackTrigger ControlID="Summit_Get" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            

        
    
            <asp:Panel ID="Panel8" runat="server">
                <fieldset><legend>
                              样品已检验进度<asp:Label ID="Label46" runat="server" Text="sampleid13" Visible="False"></asp:Label>
                              <asp:Label ID="Label47" runat="server" Text="cssid42" Visible="False"></asp:Label>
                          </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="height: 21px; width: 36px;">状态:</td>
                            <td style="height: 21px; width: 75px;">
                                <asp:DropDownList ID="DropDownList5" runat="server" >
                       
                                    <asp:ListItem>合格</asp:ListItem>
                                    <asp:ListItem>不合格</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="height: 21px; width: 113px;">
                                &nbsp;</td>
                            <td style="height: 21px; width: 183px;">
                                &nbsp;</td>
                            <td style="height: 21px">&nbsp;</td>
                            <td style="height: 21px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="height: 21px; width: 36px;">备注:</td>
                            <td colspan="4" style="height: 21px;">
                                <asp:TextBox ID="TextBox26" runat="server" Height="70px" Width="542px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                            <td style="height: 21px">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 36px;">&nbsp;</td>
                            <td style="width: 75px;"></td>
                            <td style="width: 113px;">
                                &nbsp;<asp:Button ID="Summit_Check" runat="server" CssClass="Button02" OnClick="Summit_Check_Click" Text="提交" ValidationGroup="E" Width="66px" />
                            </td>
                            <td style="width: 183px;"></td>
                            <td>
                                &nbsp;<asp:Button ID="Button10" runat="server" CausesValidation="False" CssClass="Button02" Text="关闭" Width="66px" OnClick="Button10_Click" />
                            </td>
                            <td>
                                &nbsp;</td>
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
                              样品审核<asp:Label ID="Label42" runat="server" Text="cssid42" Visible="False"></asp:Label>
                          </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="height: 21px; width: 36px;">备注:</td>
                            <td colspan="4" style="height: 21px;">
                                <asp:TextBox ID="TextBox10" runat="server" Height="70px" Width="542px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                            <td style="height: 21px">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 36px;">&nbsp;</td>
                            <td style="width: 48px;"></td>
                            <td style="width: 178px;">
                                &nbsp;<asp:Button ID="AuditPass" runat="server" CssClass="Button02" OnClick="AuditPass_Click" Text="审核通过" ValidationGroup="E" Width="66px" />
                            </td>
                            <td style="width: 183px;">
                                <asp:Button ID="AuditReject" runat="server" CssClass="Button02" OnClick="AuditReject_Click" Text="审核驳回" ValidationGroup="E" Width="66px" />
                            </td>
                            <td>
                                &nbsp;<asp:Button ID="AuditClose" runat="server" CausesValidation="False" CssClass="Button02" Text="关闭" Width="66px" OnClick="AuditClose_Click" />
                            </td>
                            <td>
                                &nbsp;</td>
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
                              样品审批<asp:Label ID="Label49" runat="server" Text="sampleid13" Visible="False"></asp:Label>
                              <asp:Label ID="Label50" runat="server" Text="cssid42" Visible="False"></asp:Label>
                          </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="height: 21px; width: 31px;">备注:</td>
                            <td colspan="4" style="height: 21px;">
                                <asp:TextBox ID="TextBox13" runat="server" Height="70px" Width="542px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                            <td style="height: 21px">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 31px;">&nbsp;</td>
                            <td style="width: 41px;"></td>
                            <td style="width: 187px;">
                                &nbsp;<asp:Button ID="SuperAuditPass" runat="server" CssClass="Button02" OnClick="SuperAuditPass_Click" Text="审批通过" ValidationGroup="E" Width="66px" />
                            </td>
                            <td style="width: 183px;">
                                <asp:Button ID="AuditReject0" runat="server" CssClass="Button02" OnClick="SuperAuditReject_Click" Text="审批驳回" ValidationGroup="E" Width="66px" />
                            </td>
                            <td>
                                &nbsp;<asp:Button ID="SuperAuditClose" runat="server" CausesValidation="False" CssClass="Button02" Text="关闭" Width="66px" OnClick="SuperAuditClose_Click" />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
      <asp:UpdatePanel ID="UpdatePanel11" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel11" runat="server" Visible="False">
                <fieldset>
                    <legend>公司样品表 </legend>
                    <asp:GridView ID="GridView8" runat="server" CssClass="GridViewStyle"   
                                  GridLines="None" EmptyDataText="没有相关记录"
                                  DataKeyNames="CRMCS_ID" EnableModelValidation="True" AutoGenerateColumns="False" >
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:TemplateField>
                                <EditItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="CRMCS_ID" HeaderText="样品表ID" Visible="false" />
                            <asp:BoundField DataField="CRMCS_Num" HeaderText="样品编号" Visible="true" SortExpression="PMP_ID" />
                            <asp:BoundField DataField="PT_Name" HeaderText="样品型号" Visible="true" SortExpression="SMSMPM_Year" />
                            <asp:BoundField DataField="CRMCS_ProductNum" HeaderText="样品数量" Visible="true" SortExpression="PMP_ID" />
                            <asp:BoundField DataField="Client_Name" HeaderText="客户名称" Visible="true" SortExpression="SMSMPM_Year" />
                            <asp:BoundField DataField="CRMCS_MakeTime" HeaderText="创建时间" Visible="true" DataFormatString="{0:yyyy-MM-dd HH:mm}" SortExpression="SMSMPM_Month" />
                            <asp:BoundField DataField="BDOS_Name" HeaderText="生产部门" Visible="true" SortExpression="SMSMPM_MakeTime" />
                            <asp:BoundField DataField="CRMCS_Remar" HeaderText="备注" Visible="true"  SortExpression="PMP_STime" />
                            <asp:BoundField DataField="CRMCS_State" HeaderText="状态" Visible="true" SortExpression="PMP_ETime" />
                            <asp:BoundField DataField="CRMCS_AuditNote" HeaderText="审核意见" Visible="true" SortExpression="PMP_ETime" />
                            <asp:BoundField DataField="CRMCS_SuperAuditNote" HeaderText="审批意见" Visible="true" SortExpression="PMP_ETime" />
                           


                            <asp:BoundField DataField="CRMCS_MakeMan" HeaderText="申请人" />
                            <asp:BoundField DataField="BDOS_Code" HeaderText="机构ID" Visible="true"  SortExpression="PMP_STime" >
                                <HeaderStyle CssClass="hide" />
                                <ItemStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PT_ID" HeaderText="型号ID" Visible="true" SortExpression="PMP_Man" >
                                <HeaderStyle CssClass="hide" />
                                <ItemStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCS_AppDep" HeaderText="申请部门" />
                           


                    
                        </Columns>
                        
                    </asp:GridView>
                    <table style="text-align: left; width: 100%;">
           
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="GridView1" />
        </Triggers>
    </asp:UpdatePanel>   <asp:UpdatePanel ID="UpdatePanel12" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            

        
    
            <asp:Panel ID="Panel12" runat="server" Visible="False">
                <fieldset><legend>
                              样品进度:已发货<asp:Label ID="Label11" runat="server" Text="sampleid13" Visible="False"></asp:Label>
                              <asp:Label ID="Label12" runat="server" Text="cssid42" Visible="False"></asp:Label>
                          </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="height: 21px; width: 35px;">备注:</td>
                            <td colspan="4" style="height: 21px;">
                                <asp:TextBox ID="TextBox14" runat="server" Height="70px" Width="100%" TextMode="MultiLine"></asp:TextBox>
                            </td>
                            <td style="height: 21px">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 35px;">&nbsp;</td>
                            <td style="width: 41px;"></td>
                            <td style="width: 187px;">
                                &nbsp;<asp:Button ID="SummitMail" runat="server" CssClass="Button02" OnClick="SummitMail_Click" Text="提交" Width="66px" />
                            </td>
                            <td style="width: 183px;">
                                &nbsp;</td>
                            <td>
                                &nbsp;<asp:Button ID="CloseMail" runat="server" CausesValidation="False" CssClass="Button02" Text="关闭" Width="66px" OnClick="CloseMail_Click" />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
     <asp:UpdatePanel ID="UpdatePanel13" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            

        
    
            <asp:Panel ID="Panel4" runat="server" Visible="False">
                <fieldset><legend>
                              样品进度:已使用<asp:Label ID="Label28" runat="server"  Visible="False"></asp:Label>
                              <asp:Label ID="Label38" runat="server"  Visible="False"></asp:Label>
                          </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="height: 21px; width: 35px;">备注:</td>
                            <td colspan="4" style="height: 21px;">
                                <asp:TextBox ID="TextBox15" runat="server" Height="70px" Width="100%" TextMode="MultiLine"></asp:TextBox>
                            </td>
                            <td style="height: 21px">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 35px;">&nbsp;</td>
                            <td style="width: 41px;"></td>
                            <td style="width: 187px;">
                                &nbsp;<asp:Button ID="Button5" runat="server" CssClass="Button02" OnClick="SummitMail_Click_shiyong" Text="提交" Width="66px" />
                            </td>
                            <td style="width: 183px;">
                                &nbsp;</td>
                            <td>
                                &nbsp;<asp:Button ID="Button7" runat="server" CausesValidation="False" CssClass="Button02" Text="关闭" Width="66px" OnClick="CloseMail_Click_shiyongguanbi" />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>