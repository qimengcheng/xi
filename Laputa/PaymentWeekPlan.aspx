<%@ Page Title="" Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true" EnableEventValidation = "false" CodeFile="PaymentWeekPlan.aspx.cs" Inherits="Laputa_PaymentWeekPlan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%--    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>--%>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:Panel ID="Panel1" runat="server">
                <fieldset>
                    <legend> 付款周计划检索
             
                
                    </legend>
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 21px" > 年: </td>
                            <td style="width: 66px" >
                                <asp:DropDownList ID="DropDownList1" runat="server">
                                    <asp:ListItem Value="999">所有年份</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="width: 22px" > &nbsp;月:</td>
                            <td style="width: 63px" >
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
                            <td style="width: 29px" > 
                                周:</td>
                            <td style="width: 45px">
                                <asp:DropDownList ID="DropDownList6" runat="server">
                                    <asp:ListItem Value="999">所有周次</asp:ListItem>
                                    <asp:ListItem>1</asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>3</asp:ListItem>
                                    <asp:ListItem>4</asp:ListItem>
                                    <asp:ListItem>5</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="width: 45px">制定人:</td>
                            <td style="width: 125px">
                                <asp:TextBox ID="TextBox1" runat="server" Width="90%"></asp:TextBox>
                            </td>
                            <td style="width: 127px">
                                <asp:Button ID="Search" runat="server" CssClass="Button02" OnClick="Search_Click" Text=" 检索 " Width="66px" />
                                <asp:Label ID="plantype" runat="server" Text="Label" Visible="False"></asp:Label>
                            </td>
                            <td >
                                <asp:Button ID="NewMonthPlan" runat="server" CssClass="Button02" OnClick="NewMonthPlan_Click" Text=" 新增付款周计划" Width="107px" />
                                <asp:Label ID="WeekPlanID" runat="server" Text="MonthPlanID" Visible="False"></asp:Label>
                            </td>
                            <td>
                                <asp:Button ID="reset" runat="server" CssClass="Button02" OnClick="reset_Click" Text=" 重置" Width="66px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
<%--      </ContentTemplate>
    </asp:UpdatePanel>--%>

    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel2" runat="server">
                <fieldset>
                    <legend>付款周计划主表</legend>
                    <asp:GridView ID="GridView1" runat="server" CssClass="GridViewStyle"  AllowPaging="True" AutoGenerateColumns="False"
                                  GridLines="None" EmptyDataText=" 没有相关记录 " OnRowCommand="GridView1_RowCommand"  OnPageIndexChanging="GridView1_PageIndexChanging" EnableModelValidation="True" OnRowDataBound="GridView1_RowDataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="PaymentWP_ID" HeaderText="PaymentWP_ID" Visible="false"  />
                            <asp:BoundField DataField="PaymentWP_Year" HeaderText="年" Visible="true"  />
                            <asp:BoundField DataField="PaymentWP_Month" HeaderText="月" Visible="true"  />
                             <asp:BoundField DataField="PaymentWP_Week" HeaderText="周" Visible="true"  />
                            <asp:BoundField DataField="PaymentWP_TotalMoney" HeaderText="计划付款总额" Visible="true"  />
                            <asp:BoundField DataField="PaymentWP_ActualPay" HeaderText="实付" Visible="true"  />
                            <asp:BoundField DataField="PaymentWP_Startdate" HeaderText="计划开始日期" DataFormatString="{0:yyyy-MM-dd }" />
                            <asp:BoundField DataField="PaymentWP_Enddate" HeaderText="计划结束日期" DataFormatString="{0:yyyy-MM-dd }" />
                            <asp:BoundField DataField="PaymentWP_Man" HeaderText="计划制定人" Visible="true"  />
                            <asp:BoundField DataField="PaymentWP_Time" HeaderText="制定时间" Visible="true" DataFormatString="{0:yyyy-MM-dd HH:mm}"   />
                             <asp:BoundField DataField="PaymentWP_State" HeaderText="状态" Visible="true"  />
                            <asp:BoundField DataField="PaymentWP_Note" HeaderText="备注" Visible="true"  />
                               <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Del" runat="server" OnClientClick="return confirm('您确认删除该记录吗?')" CommandArgument='<%# Eval("PaymentWP_ID") %>' CommandName="Del">删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Details" runat="server" CommandArgument='<%# Eval("PaymentWP_ID") %>' CommandName="Details">详细</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Make" runat="server" CommandArgument='<%# Eval("PaymentWP_ID") %>' CommandName="Make">制定</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                              <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Pay" runat="server" CommandArgument='<%# Eval("PaymentWP_ID") %>' CommandName="Pay">付款</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                           
                        </Columns>
                        <PagerTemplate>
                            <table style="width: 100%">
                                <tr>
                                    <td style="text-align: right">
                                        第<asp:Label ID="lblPageIndex" runat="server" Text='<%# ((GridView) Container.Parent.Parent).PageIndex + 1 %>' />
                                        页 共 <asp:Label ID="lblPageCount" runat="server" Text='<%# ((GridView) Container.Parent.Parent).PageCount %>' />
                                        页
                                        <asp:LinkButton ID="btnFirst" runat="server" CausesValidation="False" CommandArgument="First"
                                                        CommandName="Page" Text="首页 " />
                                        <asp:LinkButton ID="btnPrev" runat="server" CausesValidation="False" CommandArgument="Prev"
                                                        CommandName="Page" Text="上一页 " />
                                        <asp:LinkButton ID="btnNext" runat="server" CausesValidation="False" CommandArgument="Next"
                                                        CommandName="Page" Text="下一页 " />
                                        <asp:LinkButton ID="btnLast" runat="server" CausesValidation="False" CommandArgument="Last"
                                                        CommandName="Page" Text="尾页 " />
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
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel3" runat="server" Visible="False">
                <fieldset>
                    <legend>付款月计划详细</legend>
                    <asp:GridView ID="GridView2" runat="server" CssClass="GridViewStyle"  AllowPaging="True" AutoGenerateColumns="False" PageSize="10"
                                  GridLines="None" EmptyDataText=" 没有相关记录 " OnRowCommand="GridView2_RowCommand"  OnPageIndexChanging="GridView2_PageIndexChanging" EnableModelValidation="True">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="PaymentWPDetail_ID" HeaderText="PaymentWPDetail_ID" Visible="false"  />
                            <asp:BoundField DataField="PaymentWP_Year" HeaderText="年" Visible="true"  />
                            <asp:BoundField DataField="PaymentWP_Month" HeaderText="月" Visible="true"  />
                            <asp:BoundField DataField="PaymentWP_Week" HeaderText="周" Visible="true"  />
                            <asp:BoundField DataField="PMSI_SupplyName" HeaderText="供应商名称" Visible="true"  />
                            <asp:BoundField DataField="PMSI_Material" HeaderText="物料名称" Visible="true"  />
                            <asp:BoundField DataField="PMPO_PayWay" HeaderText="付款方式" Visible="true"  />
                            <asp:BoundField DataField="DuePay" HeaderText="剩余到期款" Visible="true"  />
                            <asp:BoundField DataField="PlanPay" HeaderText="计划付款" Visible="true"  />

                               <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Del" runat="server" CommandArgument='<%# Eval("PaymentWPDetail_ID") %>' CommandName="Del">删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                           
                        </Columns>
                        <PagerTemplate>
                            <table style="width: 100%">
                                <tr>
                                    <td style="text-align: right">
                                        第<asp:Label ID="lblPageIndex" runat="server" Text='<%# ((GridView) Container.Parent.Parent).PageIndex + 1 %>' />
                                        页 共 <asp:Label ID="lblPageCount" runat="server" Text='<%# ((GridView) Container.Parent.Parent).PageCount %>' />
                                        页
                                        <asp:LinkButton ID="btnFirst" runat="server" CausesValidation="False" CommandArgument="First"
                                                        CommandName="Page" Text="首页 " />
                                        <asp:LinkButton ID="btnPrev" runat="server" CausesValidation="False" CommandArgument="Prev"
                                                        CommandName="Page" Text="上一页 " />
                                        <asp:LinkButton ID="btnNext" runat="server" CausesValidation="False" CommandArgument="Next"
                                                        CommandName="Page" Text="下一页 " />
                                        <asp:LinkButton ID="btnLast" runat="server" CausesValidation="False" CommandArgument="Last"
                                                        CommandName="Page" Text="尾页 " />
                                        <asp:TextBox ID="textbox" runat="server" Width="20px"></asp:TextBox>
                                        <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                                        CommandName="Page" Text="GO" /><!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
                                    </td>
                                </tr>
                            </table>
                        </PagerTemplate>
                    </asp:GridView>
                    <table style="text-align: left; width: 100%;">
          
                        <tr>
                            <td style="width: 40px">&nbsp;</td>
                            <td style="width: 71px"></td>
                            <td style="width: 66px">&nbsp;&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;&nbsp;</td>
                            <td style="width: 69px"></td>
                            <td style="width: 115px">
                                <asp:Button ID="Button5" runat="server" CssClass="Button02" OnClick="Close_PayPlanDetail_Click" Text=" 关闭" Width="66px" />
                            </td>
                            <td>&nbsp;</td>
                            <td style="width: 205px">&nbsp;</td>
                            <td>
                                <br />
                            </td>
                        </tr>
          
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
 
    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel4" runat="server" Visible="False">
                <fieldset>
                    <legend>新增付款月计划
                    </legend>
                    <table style="width: 100%">
                        <tr>
                            <td  > &nbsp;</td>
                            <td >年: </td>
                            <td   >
                                <asp:DropDownList ID="DropDownList4" runat="server">
                        
                                </asp:DropDownList>
                            </td>
                            <td  > &nbsp;月:</td>
                            <td style="width: 45px"   >
                                <asp:DropDownList ID="DropDownList5" runat="server">
                        
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
                            <td>周:</td>
                            <td>
                                <asp:DropDownList ID="DropDownList7" runat="server">
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
                            <td  > 
                                计划开始日期:</td>
                            <td style="width: 136px"  >
                                <asp:TextBox ID="TextBox3" runat="server"  onfocus="new WdatePicker(this,'%Y-%M-%D' ,true)"
                                             DataFormatString="{0:yyyy-MM-dd}"
                                    ></asp:TextBox>
                            </td>
                            <td >
                                计划结束日期:</td>
                            <td style="width: 205px"  >
                                <asp:TextBox ID="TextBox4" runat="server"  onfocus="new WdatePicker(this,'%Y-%M-%D' ,true)"
                                             DataFormatString="{0:yyyy-MM-dd}"
                                    ></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
            
                        <tr>
                            <td>备注:<br /> (不超过100个字)</td>
                            <td colspan="10">
                                <asp:TextBox ID="TextBox2" runat="server" Height="150px" Width="90%" TextMode="MultiLine"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>
                                <asp:Button ID="NewMainSummit" runat="server" CssClass="Button02" OnClick="NewMainSummit_Click" Text=" 提交" Width="66px" />
                            </td>
                            <td>&nbsp;</td>
                            <td style="width: 45px">
                                &nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td style="width: 136px">
                                <asp:Button ID="Close_Add" runat="server" CssClass="Button02" OnClick="Close_Add_Click" Text=" 关闭" Width="66px" />
                            </td>
                            <td>&nbsp;</td>
                            <td style="width: 205px">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>

            
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel5" runat="server" Visible="False">
                <fieldset>
                    <legend>待付款详情</legend>
                    <asp:GridView ID="GridView3" runat="server" CssClass="GridViewStyle"  AllowPaging="True" AutoGenerateColumns="False" PageSize="2" DataKeyNames="PMSI_ID,PMPO_PayWay"
                                  GridLines="None" EmptyDataText=" 没有相关记录 " OnRowCommand="GridView3_RowCommand"  OnPageIndexChanging="GridView3_PageIndexChanging" EnableModelValidation="True" OnRowDataBound="GridView3_RowDataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="PMSI_ID" HeaderText="PMSI_ID" Visible="True"  >
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PMSI_SupplyName" HeaderText="供应商名称" Visible="true"  />
                            <asp:BoundField DataField="PMSI_Material" HeaderText="物料名称" Visible="true"  />
                            <asp:BoundField DataField="PMPO_PayWay" HeaderText="付款方式" Visible="true"  />
                            <asp:BoundField DataField="ShouldPay" HeaderText="总欠款" />
                            <asp:BoundField DataField="DuePay" HeaderText="剩余到期款" Visible="true"  />
                            <asp:TemplateField HeaderText="计划付款金额">
                               <ItemTemplate>
                                  <asp:TextBox ID="PlanPay" runat="server"  onkeyup="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{4,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{4})[0-9]*/, '$1');" 
                              onafterpaste="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{4,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{4})[0-9]*/, '$1');"
></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="PlanPay" HeaderText="月计划付款数" Visible="true"  />
                            <asp:BoundField DataField="TotalWeekPay" HeaderText="当月已计划付款数" Visible="true"  />

                           
                        </Columns>
                        <PagerTemplate>
                            <table style="width:100%">
                                <tr>
                                    <td style="text-align: right">
                                        第<asp:Label ID="lblPageIndex" runat="server" Text='<%# ((GridView) Container.Parent.Parent).PageIndex + 1 %>' />
                                        页 共 <asp:Label ID="lblPageCount" runat="server" Text='<%# ((GridView) Container.Parent.Parent).PageCount %>' />
                                        页
                                        <asp:LinkButton ID="btnFirst" runat="server" CausesValidation="False" CommandArgument="First"
                                                        CommandName="Page" Text="首页 " />
                                        <asp:LinkButton ID="btnPrev" runat="server" CausesValidation="False" CommandArgument="Prev"
                                                        CommandName="Page" Text="上一页 " />
                                        <asp:LinkButton ID="btnNext" runat="server" CausesValidation="False" CommandArgument="Next"
                                                        CommandName="Page" Text="下一页 " />
                                        <asp:LinkButton ID="btnLast" runat="server" CausesValidation="False" CommandArgument="Last"
                                                        CommandName="Page" Text="尾页 " />
                                        <asp:TextBox ID="textbox" runat="server" Width="20px"></asp:TextBox>
                                        <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                                        CommandName="Page" Text="GO" /><!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
                                    </td>
                                </tr>
                            </table>
                        </PagerTemplate>
                    </asp:GridView>
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 107px" >预计预付款项</td>
                            <td style="width: 71px"   >
                                <asp:TextBox ID="TextBox5" runat="server" onkeyup="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{4,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{4})[0-9]*/, '$1');" 
                              onafterpaste="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{4,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{4})[0-9]*/, '$1');" ></asp:TextBox>
                            </td>
                            <td style="width: 66px">&nbsp;</td>
                            <td   >
                                <asp:Label ID="year" runat="server" Text="Label" Visible="False"></asp:Label>
                                <asp:Label ID="month" runat="server" Text="Label" Visible="False"></asp:Label>
                                <asp:Label ID="week" runat="server" Text="Label" Visible="False"></asp:Label>
                            </td>
                            <td  > &nbsp;</td>
                            <td style="width: 69px"  > &nbsp;</td>
                            <td style="width: 115px"  >
                                &nbsp;</td>
                            <td  > 
                                &nbsp;</td>
                            <td style="width: 205px"  >
                                &nbsp;</td>
                            <td >
                                &nbsp;</td>
                        </tr>
            
            
                        <tr>
                            <td style="width: 107px">&nbsp;</td>
                            <td style="width: 71px"></td>
                            <td style="width: 66px">&nbsp;&nbsp;</td>
                            <td>
                                <asp:Button ID="NewDetailSummit" runat="server" CssClass="Button02" OnClick="NewDetailSummit_Click" Text=" 提交付款周计划" Width="104px" />
                            </td>
                            <td>&nbsp;&nbsp;</td>
                            <td style="width: 69px"></td>
                            <td style="width: 115px">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td style="width: 205px">
                                <asp:Button ID="Button2" runat="server" CssClass="Button02" OnClick="Close_DetailAdd_Click" Text=" 关闭" Width="66px" />
                            </td>
                            <td></td>
                        </tr>
            
            
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel6" runat="server" Visible="False">
                <fieldset>
                    <legend>采购付款</legend>
                    <asp:GridView ID="GridView4" runat="server" CssClass="GridViewStyle"  AllowPaging="True" AutoGenerateColumns="False" PageSize="2" DataKeyNames="PMSI_ID,PMPO_PayWay"
                                  GridLines="None" EmptyDataText=" 没有相关记录 " OnRowCommand="GridView3_RowCommand"  OnPageIndexChanging="GridView4_PageIndexChanging" EnableModelValidation="True" OnRowDataBound="GridView4_RowDataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="PMSI_ID" HeaderText="PMSI_ID" Visible="True"  >
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                            </asp:BoundField>
                              <asp:BoundField DataField="PaymentWPDetail_ID" HeaderText="PaymentWPDetail_ID" Visible="false"  />
                            <asp:BoundField DataField="PaymentWP_Year" HeaderText="年" Visible="true"  />
                            <asp:BoundField DataField="PaymentWP_Month" HeaderText="月" Visible="true"  />
                            <asp:BoundField DataField="PaymentWP_Week" HeaderText="周" Visible="true"  />
                            <asp:BoundField DataField="PMSI_SupplyName" HeaderText="供应商名称" Visible="true"  />
                            <asp:BoundField DataField="PMSI_Material" HeaderText="物料名称" Visible="true"  />
                            <asp:BoundField DataField="PMPO_PayWay" HeaderText="付款方式" Visible="true"  />
                            <asp:BoundField DataField="DuePay" HeaderText="剩余到期款" Visible="true"  />
                            <asp:BoundField DataField="PlanPay" HeaderText="计划付款" Visible="true"  />
                            <asp:TemplateField HeaderText="实际付款金额">
                               <ItemTemplate>
                                  <asp:TextBox ID="ActualPay" runat="server"  onkeyup="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{4,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{4})[0-9]*/, '$1');" 
                              onafterpaste="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{4,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{4})[0-9]*/, '$1');"
></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>


                           
                        </Columns>
                        <PagerTemplate>
                            <table style="width: 100%">
                                <tr>
                                    <td style="text-align: right">
                                        第<asp:Label ID="lblPageIndex" runat="server" Text='<%# ((GridView) Container.Parent.Parent).PageIndex + 1 %>' />
                                        页 共 <asp:Label ID="lblPageCount" runat="server" Text='<%# ((GridView) Container.Parent.Parent).PageCount %>' />
                                        页
                                        <asp:LinkButton ID="btnFirst" runat="server" CausesValidation="False" CommandArgument="First"
                                                        CommandName="Page" Text="首页 " />
                                        <asp:LinkButton ID="btnPrev" runat="server" CausesValidation="False" CommandArgument="Prev"
                                                        CommandName="Page" Text="上一页 " />
                                        <asp:LinkButton ID="btnNext" runat="server" CausesValidation="False" CommandArgument="Next"
                                                        CommandName="Page" Text="下一页 " />
                                        <asp:LinkButton ID="btnLast" runat="server" CausesValidation="False" CommandArgument="Last"
                                                        CommandName="Page" Text="尾页 " />
                                        <asp:TextBox ID="textbox" runat="server" Width="20px"></asp:TextBox>
                                        <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                                        CommandName="Page" Text="GO" /><!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
                                    </td>
                                </tr>
                            </table>
                        </PagerTemplate>
                    </asp:GridView>
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 40px" >&nbsp;</td>
                            <td colspan="8"   >
                                &nbsp;</td>
                            <td >
                                &nbsp;</td>
                        </tr>
            
            
                        <tr>
                            <td style="width: 40px">&nbsp;</td>
                            <td style="width: 71px"></td>
                            <td style="width: 66px">&nbsp;&nbsp;</td>
                            <td>
                                <asp:Button ID="Pay" runat="server" CssClass="Button02" OnClick="Pay_Click" Text=" 提交付款" Width="99px" />
                            </td>
                            <td>&nbsp;&nbsp;</td>
                            <td style="width: 69px"></td>
                            <td style="width: 115px">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td style="width: 205px">
                                <asp:Button ID="Button3" runat="server" CssClass="Button02" OnClick="Close_Pay_Click" Text=" 关闭" Width="66px" />
                            </td>
                            <td></td>
                        </tr>
            
            
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel7" runat="server" Visible="False">
                <fieldset>
                    <legend>采购付款详情</legend>
                    <asp:GridView ID="GridView5" runat="server" CssClass="GridViewStyle"  AllowPaging="True" AutoGenerateColumns="False" PageSize="2" 
                                  GridLines="None" EmptyDataText=" 没有相关记录 " OnPageIndexChanging="GridView5_PageIndexChanging" >
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="PaymentInfo_Year" HeaderText="年" Visible="True"  >
                            </asp:BoundField>
                              <asp:BoundField DataField="PaymentInfo_Month" HeaderText="月"  />
                            <asp:BoundField DataField="PaymentInfo_Week" HeaderText="周" Visible="true"  />
                            <asp:BoundField DataField="PMSI_SupplyName" HeaderText="供应商名称" Visible="true"  />
                            <asp:BoundField DataField="PMPO_PayWay" HeaderText="付款方式" Visible="true"  />
                            <asp:BoundField HeaderText="实际付款金额" DataField="Pay"/>


                           
                        </Columns>
                        <PagerTemplate>
                            <table style="width: 100%">
                                <tr>
                                    <td style="text-align: right">
                                        第<asp:Label ID="lblPageIndex" runat="server" Text='<%# ((GridView) Container.Parent.Parent).PageIndex + 1 %>' />
                                        页 共 <asp:Label ID="lblPageCount" runat="server" Text='<%# ((GridView) Container.Parent.Parent).PageCount %>' />
                                        页
                                        <asp:LinkButton ID="btnFirst" runat="server" CausesValidation="False" CommandArgument="First"
                                                        CommandName="Page" Text="首页 " />
                                        <asp:LinkButton ID="btnPrev" runat="server" CausesValidation="False" CommandArgument="Prev"
                                                        CommandName="Page" Text="上一页 " />
                                        <asp:LinkButton ID="btnNext" runat="server" CausesValidation="False" CommandArgument="Next"
                                                        CommandName="Page" Text="下一页 " />
                                        <asp:LinkButton ID="btnLast" runat="server" CausesValidation="False" CommandArgument="Last"
                                                        CommandName="Page" Text="尾页 " />
                                        <asp:TextBox ID="textbox" runat="server" Width="20px"></asp:TextBox>
                                        <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                                        CommandName="Page" Text="GO" /><!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
                                    </td>
                                </tr>
                            </table>
                        </PagerTemplate>
                    </asp:GridView>
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 40px" >&nbsp;</td>
                            <td style="width: 71px"   >
                                </td>
                            <td style="width: 66px" >
                                &nbsp;&nbsp;</td>
                            <td>&nbsp;</td>
                            <td >
                                &nbsp;&nbsp;</td>
                            <td style="width: 69px"></td>
                            <td style="width: 115px">
                                <asp:Button ID="Button4" runat="server" CssClass="Button02" OnClick="Close_PayDetail_Click" Text=" 关闭" Width="66px" />
                            </td>
                            <td>&nbsp;</td>
                            <td style="width: 205px">&nbsp;</td>
                            <td></td>
                        </tr>
            
            
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>