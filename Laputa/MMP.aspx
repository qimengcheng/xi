<%@ Page Title="" Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true" CodeFile="MMP.aspx.cs" Inherits="Laputa_MMP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Label ID="labelstate" runat="server" Text="pstate" Visible="False"></asp:Label>
    <script type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
    
    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server">
        <fieldset>
            <legend>材料月计划检索</legend>
            <table style="width: 100%; width: auto">
                <tr>
                    <td style="width: 99px">年:
                   <asp:DropDownList ID="DropDownList1" runat="server">
                       <asp:ListItem Value="999">所有年份</asp:ListItem>
                   </asp:DropDownList>
                    </td>
                    <td style="width: 103px">月:
                   <asp:DropDownList ID="DropDownList2" runat="server">
                       <asp:ListItem Value="999">所有月份</asp:ListItem>
                       <asp:ListItem>1</asp:ListItem>
                       <asp:ListItem>2</asp:ListItem>
                       <asp:ListItem>3</asp:ListItem>
                       <asp:ListItem>4</asp:ListItem>
                       <asp:ListItem>5</asp:ListItem>
                       <asp:ListItem>6</asp:ListItem>
                       <asp:ListItem>7</asp:ListItem>
                       <asp:ListItem>8</asp:ListItem>
                       <asp:ListItem>9</asp:ListItem>
                       <asp:ListItem>10</asp:ListItem>
                       <asp:ListItem>11</asp:ListItem>
                       <asp:ListItem>12</asp:ListItem>
                   </asp:DropDownList>
                    </td>
                    <td style="width: 108px">状态
                   <asp:DropDownList ID="DropDownList3" runat="server">
                       <asp:ListItem Value="null">所有状态</asp:ListItem>
                       <asp:ListItem>未建立</asp:ListItem>                       
                       <asp:ListItem>已提交</asp:ListItem>
                       <asp:ListItem>会签中</asp:ListItem>
                       <asp:ListItem>审核通过</asp:ListItem>
                       <asp:ListItem>审核驳回</asp:ListItem>


                   </asp:DropDownList>

                    </td>
                    <td>
                        <asp:Label ID="Linenum" runat="server" Text="0" Visible="False"></asp:Label>
                    </td>
                    <td style="width: 63px">&nbsp;</td>
                    <td>
                        <asp:Button ID="Button1" runat="server" CssClass="Button02" OnClick="Button1_Click" Text="检索" Width="70px" />
                    </td>
                </tr>
            </table>

        </fieldset>
    </asp:Panel>
            <asp:Panel ID="Panel2" runat="server">
                <fieldset>
                    <legend>材料月计划            </legend>

                    <asp:GridView ID="GridView1" runat="server" CssClass="GridViewStyle"  AllowPaging="True" PageSize="10" AutoGenerateColumns="False" 
                        GridLines="None" EmptyDataText="没有相关记录" OnRowCommand="GridView1_RowCommand" OnRowCreated="GridView1_RowCreated"
                         DataKeyNames="SMSMPM_ID" OnRowDataBound="GridView1_RowDataBound" OnPageIndexChanging="GridView1_PageIndexChanging" EnableModelValidation="True">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="SMSMPM_ID" HeaderText="销售月计划ID" Visible="true" SortExpression="SMSMPM_ID" />
                            <asp:BoundField DataField="MMP_ID" HeaderText="材料月计划ID" Visible="true" SortExpression="PMP_ID" >
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMSMPM_Year" HeaderText="年份" Visible="true" SortExpression="SMSMPM_Year" />
                            <asp:BoundField DataField="SMSMPM_Month" HeaderText="月份" Visible="true" SortExpression="SMSMPM_Month" />
                            <asp:BoundField DataField="SMSMPM_MakeMan" HeaderText="销售计划制定人" Visible="true" SortExpression="SMSMPM_MakeMan" />
                            <asp:BoundField DataField="SMSMPM_MakeTime" HeaderText="销售计划制定时间" Visible="true" DataFormatString="{0:yyyy-MM-dd HH:mm}" SortExpression="SMSMPM_MakeTime" />
                            <asp:BoundField DataField="PMP_STime" HeaderText="计划开始日期" Visible="true"  DataFormatString="{0:yyyy-MM-dd}" SortExpression="PMP_STime" />
                            <asp:BoundField DataField="PMP_ETime" HeaderText="计划结束日期" Visible="true" DataFormatString="{0:yyyy-MM-dd}" SortExpression="PMP_ETime" />
                            <asp:BoundField DataField="PMP_Man" HeaderText="计划制定人" Visible="true" SortExpression="PMP_Man" />
                            <asp:BoundField DataField="MMP_State" HeaderText="计划状态" Visible="true" SortExpression="PMP_State" NullDisplayText="未建立" />
                            <asp:BoundField DataField="PMP_AddPlan" HeaderText="新增计划" Visible="true" SortExpression="PMP_State"/>

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Detail" runat="server" CommandArgument='<%# Eval("MMP_ID") %>' CommandName="Details">详细</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Make" runat="server" CommandArgument='<%# Eval("SMSMPM_ID") %>' CommandName="Make">制定</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Audit" runat="server" CommandArgument='<%# Eval("MMP_ID") %>' CommandName="Audit">审核</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Bonus" runat="server" CommandArgument='<%# Eval("SMSMPM_ID") %>' CommandName="Bonus">新增计划</asp:LinkButton>
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
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:Panel ID="Panel3" runat="server" Visible="false">
                <fieldset>
                               <legend>
                        <asp:Label ID="Label10" runat="server" Text="Label10"></asp:Label>
                        <asp:Label ID="Label11" runat="server" Text="Label11"></asp:Label>
                        年<asp:Label ID="Label12" runat="server" Text="Label12"></asp:Label>
                        月的材料月计划详细
                     
                                   <asp:Label ID="Label13" runat="server" Text="SalesID13" Visible="False"></asp:Label>
                                   <asp:Label ID="Label14" runat="server" Text="PMPID14" Visible="False"></asp:Label>
                    </legend>
                    <asp:Panel ID="Panel31"  runat="server">
                        <table>
                            <tr>
                                <td>开始日期:</td>
                                <td>
                        <asp:TextBox ID="TextBox6" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D' ,true)"
                                    DataFormatString="{0:yyyy-MM-dd}">

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                        </asp:TextBox>

                                </td>
                        <td>
                            <asp:Label ID="Label536" runat="server" ForeColor="red" Text="*"></asp:Label>
                            结束日期:</td>
                            <td>
                            <asp:TextBox ID="TextBox7" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D' ,true)"
                                    DataFormatString="{0:yyyy-MM-dd}"></asp:TextBox></td>
                        <td>
                            <asp:Label ID="Label537" runat="server" ForeColor="red" Text="*"></asp:Label>
                        </td>
                           </tr>

                        </table>
                   </asp:Panel>
                            <asp:GridView ID="GridView2" runat="server" CssClass="GridViewStyle"  AllowPaging="True" PageSize="20" AutoGenerateColumns="False" GridLines="None" EmptyDataText="请添加物料"
                         DataKeyNames="IMMBD_MaterialID" EnableModelValidation="True" OnPageIndexChanging="GridView2_PageIndexChanging" OnRowCommand="GridView2_RowCommand" OnRowDataBound="GridView2_RowDataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="IMMBD_MaterialID" HeaderText="物料ID" Visible="true" SortExpression="IMMBD_MaterialID" >
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_MaterialName" HeaderText="材料名称" Visible="true" SortExpression="SMSMPM_Year" />
                            <asp:BoundField DataField="IMMBD_SpecificationModel" HeaderText="材料型号" Visible="true" SortExpression="SMSMPM_Month" />
                            <asp:BoundField DataField="MMPD_Num" HeaderText="本次所需数量" Visible="true"  />                            
                            <asp:BoundField DataField="TotalNum" HeaderText="总库存" Visible="true"/>
                            <asp:BoundField DataField="AvailableNum" HeaderText="可用库存" Visible="true"/>
                             <asp:BoundField DataField="MonthNum" HeaderText="本月所需总数" Visible="true"/>
                            <asp:BoundField DataField="Pre" HeaderText="预扣除量" Visible="true"/>
                            <asp:BoundField DataField="Purchase" HeaderText="还需采购" Visible="true"/>
                            <asp:BoundField DataField="UnitName" HeaderText="单位" Visible="true"/>
                            <asp:BoundField DataField="MMPD_Note" HeaderText="备注" Visible="true" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("IMMBD_MaterialID") %>' CommandName="Source">查看来源</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("IMMBD_MaterialID") %>' CommandName="Modify">编辑数量</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                        <PagerStyle HorizontalAlign="Justify" />
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第<asp:Label ID="Label15" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>' />
                                        页 共<asp:Label ID="Label16" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />
                                        页
                                        <asp:LinkButton ID="LinkButton8" runat="server" CausesValidation="False" CommandArgument="First"
                                            CommandName="Page" Text="首页" />
                                        <asp:LinkButton ID="LinkButton9" runat="server" CausesValidation="False" CommandArgument="Prev"
                                            CommandName="Page" Text="上一页" />
                                        <asp:LinkButton ID="LinkButton10" runat="server" CausesValidation="False" CommandArgument="Next"
                                            CommandName="Page" Text="下一页" />
                                        <asp:LinkButton ID="LinkButton11" runat="server" CausesValidation="False" CommandArgument="Last"
                                            CommandName="Page" Text="尾页" />
                                        <asp:TextBox ID="textbox2" runat="server" Width="20px"></asp:TextBox>
                                        <asp:LinkButton ID="LinkButton12" runat="server" CausesValidation="False" CommandArgument="-1"
                                            CommandName="Page" Text="GO" /><!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
                                    </td>
                                </tr>
                            </table>
                        </PagerTemplate>
                    </asp:GridView>
                             <table style="width: 100%;">
                        <tr>
                            <td style="width: 50px">
                                <asp:Label ID="Label17" runat="server" Text="MID17" Visible="False"></asp:Label>
                            </td>
                            <td>
                                <asp:Button ID="Button4" runat="server" CssClass="Button02"  Text="提交材料月计划" OnClick="Button4_Click" CausesValidation="False" ValidationGroup="send" Width="96px" />
                            </td>

                        </tr>


                    </table>
                            </fieldset>
            </asp:Panel>

            <asp:Panel ID="Panel32" runat="server" Visible="false">
                <fieldset>
                    <legend>
                                                
                        材料：<asp:Label ID="Label20" runat="server" Text="MaterialName20"></asp:Label>
                        <asp:Label ID="Label21" runat="server" Text="MaterialType21"></asp:Label>
                        修改数量
                    </legend>
                     
                         <table style="width:100%;">
                             <tr>
                                 <td style="width: 99px">原数量：</td>
                                 <td style="width: 150px">
                                     <asp:Label ID="Label22" runat="server" Text="AutoNum22"></asp:Label>
                                 </td>
                                 <td>计划数量：</td>
                                 <td style="margin-left: 40px">
                                     <asp:TextBox ID="TextBox8" ValidationGroup="A" style="ime-mode:disabled;" runat="server" onkeyup="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{2,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{2})[0-9]*/, '$1');" 
                              onafterpaste="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{2,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{2})[0-9]*/, '$1');"></asp:TextBox>
                                     <asp:Label ID="Label538" runat="server" ForeColor="red" Text="*"></asp:Label>
                                 </td>
                             </tr>
                             <tr>
                                 <td style="width: 99px">备注：<br /> (不超过200个字)</td>
                                 <td colspan="3">
                                     <asp:TextBox ID="TextBoxNote" runat="server" Height="54px" TextMode="MultiLine" Width="610px"></asp:TextBox>
                                 </td>
                             </tr>
                             <tr>
                                 <td style="width: 99px">
                                     &nbsp;</td>
                                 <td style="width: 150px">
                                     <asp:Button ID="Button14" runat="server" CssClass="Button02" Text="提交" Width="67px" OnClick="Button14_Click" />
                                 </td>
                                 <td>&nbsp;</td>
                                 <td>
                                     <asp:Button ID="Button15" runat="server" CssClass="Button02" OnClick="Button15_Click" Text="关闭" Width="67px" />
                                 </td>
                             </tr>
                           
                         </table>
                        
                
                    </fieldset>
            </asp:Panel>

            <asp:Panel ID="Panel4" runat="server" Visible="false">
                <fieldset>
                    <legend>
                                                
                        材料：<asp:Label ID="Label30" runat="server" Text="MaterialName30"></asp:Label>
                        <asp:Label ID="Label31" runat="server" Text="MaterialType31"></asp:Label>
                        来源
                    </legend>
                    <asp:GridView ID="GridView3" runat="server" CssClass="GridViewStyle"  AllowPaging="True" PageSize="20" AutoGenerateColumns="False" GridLines="None" EmptyDataText="请添加物料"
                          EnableModelValidation="True" OnRowCancelingEdit="GridView3_RowCancelingEdit"   OnRowDataBound="GridView3_RowDataBound" OnPageIndexChanging="GridView3_PageIndexChanging">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="PT_Name" HeaderText="产品名称" Visible="true"  />
                            <asp:BoundField DataField="IMMBD_MaterialName" HeaderText="材料名称" Visible="true"  />
                            <asp:BoundField DataField="IMMBD_SpecificationModel" HeaderText="材料型号" Visible="true"  />
                            
                            <asp:BoundField DataField="PBC_Name" HeaderText="工序名称" Visible="true"  />
                            <asp:BoundField DataField="SMSMPD_PMPNum" HeaderText="计划产品数" Visible="true"  />
                            <asp:BoundField DataField="BD_MRUse" HeaderText="单位产品所需数量" Visible="true"  />
                            <asp:BoundField DataField="TotalNeedNum" HeaderText="所需总数量" Visible="true"  />
                            <asp:BoundField DataField="UnitName" HeaderText="单位" Visible="true"/>
                            <asp:BoundField DataField="BD_Percent" HeaderText="使用比例" Visible="true"/>
    <%--                        <asp:BoundField DataField="Preallocated" HeaderText="优化前产品数" Visible="true"/>
                            <asp:BoundField DataField="Allocated" HeaderText="优化后产品数" Visible="true"/>--%>


                        </Columns>
                        <PagerStyle HorizontalAlign="Justify" />
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第<asp:Label ID="Label13" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>' />
                                        页 共<asp:Label ID="Label14" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />
                                        页
                                        <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandArgument="First"
                                            CommandName="Page" Text="首页" />
                                        <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" CommandArgument="Prev"
                                            CommandName="Page" Text="上一页" />
                                        <asp:LinkButton ID="LinkButton5" runat="server" CausesValidation="False" CommandArgument="Next"
                                            CommandName="Page" Text="下一页" />
                                        <asp:LinkButton ID="LinkButton6" runat="server" CausesValidation="False" CommandArgument="Last"
                                            CommandName="Page" Text="尾页" />
                                        <asp:TextBox ID="textbox1" runat="server" Width="20px"></asp:TextBox>
                                        <asp:LinkButton ID="LinkButton7" runat="server" CausesValidation="False" CommandArgument="-1"
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


    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
        <ContentTemplate>
            <asp:Panel ID="Panel5" runat="server" Visible="false">
                <fieldset>
                    <legend>生产部材料月计划会签</legend>
                    
                    <table style="width:100%;">
                        <tr>
                            <td style="width: 59px">会签人：</td>
                            <td style="width: 94px"><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></td>
                            <td class="auto-style3" style="width: 68px">会签时间：</td>
                            <td style="width: 107px"><asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></td>
                            <td class="auto-style3" style="width: 65px">会签结果：</td>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        
                    </table>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 61px">会签意见</td>
                            <td class="auto-style3" style="width: 139px">
                                <asp:TextBox ID="TextBox3" runat="server" Height="164px" Width="766px" MaxLength="200"></asp:TextBox>
                            </td>
                            
                            
                            
                        </tr>
                        <tr>
                            <td style="width: 61px">&nbsp;</td>
                            <td class="auto-style3" style="width: 139px">
                                 <asp:Panel ID="P1" runat="server" Visible="false">
                                <table id="t1" style="width:100%;">
                                    <tr>
                                        <td>
                                            <asp:Button ID="Button10" runat="server" CssClass="Button02" OnClick="Button10_Click" Text="通过" Width="63px" />
                                        </td>
                                        <td>
                                            <asp:Button ID="Button5" runat="server" CssClass="Button02" OnClick="Button5_Click" Text="驳回" Width="63px" />
                                        </td>
                                        <td>
                                            <asp:Button ID="Button11" runat="server" CssClass="Button02" OnClick="Button11_Click" Text="取消" Width="63px" />
                                        </td>
                                    </tr>
                                   
                                </table>
                                     </asp:Panel>
                            </td>
                            
                            
                            
                        </tr>

                    </table>
                </fieldset>
            </asp:Panel>
            <asp:Panel ID="Panel6" runat="server" Visible="false">
                <fieldset>
                    <legend>财务部材料月计划会签</legend>
                    
                    <table style="width:100%;">
                        <tr>
                            <td style="width: 59px">会签人：</td>
                            <td style="width: 94px"><asp:Label ID="Label4" runat="server" Text="Label"></asp:Label></td>
                            <td class="auto-style3" style="width: 68px">会签时间：</td>
                            <td style="width: 107px"><asp:Label ID="Label5" runat="server" Text="Label"></asp:Label></td>
                            <td class="auto-style3" style="width: 65px">会签结果：</td>
                            <td>
                                <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        
                    </table>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 61px">会签意见</td>
                            <td class="auto-style3" style="width: 139px">
                                <asp:TextBox ID="TextBox4" runat="server" Height="164px" Width="766px" MaxLength="200"></asp:TextBox>
                            </td>
                            
                            
                            
                        </tr>
                        <tr>
                            <td style="width: 61px">&nbsp;</td>
                            <td class="auto-style3" style="width: 139px">
                                <asp:Panel ID="P2" runat="server" Visible="false">
                                <table style="width:100%;">
                                    <tr>
                                        <td>
                                            <asp:Button ID="Button6" runat="server" CssClass="Button02" OnClick="Button6_Click" Text="通过" Width="63px" />
                                        </td>
                                        <td>
                                            <asp:Button ID="Button7" runat="server" CssClass="Button02" OnClick="Button7_Click" Text="驳回" Width="63px" />
                                        </td>
                                        <td>
                                            <asp:Button ID="Button8" runat="server" CssClass="Button02" OnClick="Button8_Click" Text="取消" Width="63px" />
                                        </td>
                                    </tr>
                                   
                                </table>
                                    </asp:Panel>
                            </td>
                            
                            
                            
                        </tr>

                    </table>
                </fieldset>
            </asp:Panel>
            <asp:Panel ID="Panel7" runat="server" Visible="false">
                <fieldset>
                    <legend>总经理材料月计划会签</legend>
                    
                    <table   style="width:100%;">
                        <tr>
                            <td style="width: 59px">会签人：</td>
                            <td style="width: 94px"><asp:Label ID="Label7" runat="server" Text="Label"></asp:Label></td>
                            <td class="auto-style3" style="width: 68px">会签时间：</td>
                            <td style="width: 107px"><asp:Label ID="Label8" runat="server" Text="Label"></asp:Label></td>
                            <td class="auto-style3" style="width: 65px">会签结果</td>
                            <td>
                                <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        
                    </table>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 61px">会签意见</td>
                            <td class="auto-style3" style="width: 139px">
                                <asp:TextBox ID="TextBox5" runat="server" Height="164px" Width="766px" MaxLength="200"></asp:TextBox>
                            </td>
                            
                            
                            
                        </tr>
                        <tr>
                            <td style="width: 61px">&nbsp;</td>
                            <td class="auto-style3" style="width: 139px">
 <asp:Panel ID="P3" runat="server" Visible="false">

                                <table style="width:100%;">
                                    <tr>
                                        <td>
                                            <asp:Button ID="Button9" runat="server" CssClass="Button02" OnClick="Button9_Click" Text="通过" Width="63px" />
                                        </td>
                                        <td>
                                            <asp:Button ID="Button12" runat="server" CssClass="Button02" OnClick="Button12_Click" Text="驳回" Width="63px" />
                                        </td>
                                        <td>
                                            <asp:Button ID="Button13" runat="server" CssClass="Button02" OnClick="Button13_Click" Text="取消" Width="63px" />
                                        </td>
                                    </tr>
                                   
                                </table>
     </asp:Panel>
                            </td>
                            
                            
                            
                        </tr>

                    </table>
                </fieldset>
            </asp:Panel>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

