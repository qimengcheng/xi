<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PMPurchaseOrder.aspx.cs" Inherits="ProjectManagement_PMPurchaseOrder"  MasterPageFile="~/Other/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
        <style type="text/css">
        .hidden
        {
            display: none;
        }
            .auto-style7 {
                width: 15%;
            }
            .auto-style8 {
                width: 11%;
            }
            .auto-style9 {
                height: 20px;
                width: 18%;
            }
            .auto-style10 {
                width: 18%;
            }
            .auto-style11 {
                width: 13%;
            }
            .auto-style14 {
                height: 20px;
                width: 15%;
            }
           
        .hidden
        {
            display: none;
        }
   
    </style>

    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script> 
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" Visible="true">
                <fieldset>
                    <legend><asp:Label ID="label_Apply" runat="server" Visible="true" text="检索条件"></asp:Label>
                    </legend>
                    <asp:Label ID="labelSupply" runat="server" Visible="false" ></asp:Label>
                    <asp:Label ID="labelcondition" runat="server" Visible="false" ></asp:Label>
                    <asp:Label ID="labelSupplySelect" runat="server" Visible="false" ></asp:Label>
                    <asp:Label ID="labelPurchaseOrderID" runat="server" Visible="false" ></asp:Label>
                    <table style="width: 100%;">
                        <tr>
                             <td style="width: 15%" align="right">
                                <asp:Label ID="Label3" runat="server" Text="申请单状态："></asp:Label>
                            </td>
                           <td style="width: 20%" align="left">
                <asp:DropDownList ID="DropDownList4" runat="server"  Width="130px">
                    <asp:ListItem>请选择</asp:ListItem>
                    <asp:ListItem>未制定</asp:ListItem>
                    <asp:ListItem>已提交</asp:ListItem>
                    <asp:ListItem>其他</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="width: 15%" align="right">
                                <asp:Label ID="Label2" runat="server" Text="是否结款："></asp:Label>
                            </td>
                           <td style="width: 20%" align="left">
                <asp:DropDownList ID="DropDownList3" runat="server"  Width="130px">
                    <asp:ListItem>请选择</asp:ListItem>
                    <asp:ListItem>是</asp:ListItem>
                    <asp:ListItem>否</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td align="right" style="width: 10%">
                                <asp:Label ID="Label15" runat="server" Text="采购订单号："></asp:Label>
                            </td>
                            <td align="left" style="width: 20%">
                                <asp:TextBox ID="PurchaseOrderID" runat="server" > </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 15%" align="right">
                                <asp:Label ID="Label16" runat="server" Text="付款方式："></asp:Label>
                            </td>
                           <td style="width: 20%" align="left">
                <asp:DropDownList ID="DropDownList1" runat="server"  Width="130px">
                    <asp:ListItem>请选择</asp:ListItem>
                    <asp:ListItem>先货后款</asp:ListItem>
                   <asp:ListItem>货到付款</asp:ListItem>
                   <asp:ListItem>预付款</asp:ListItem>
                <asp:ListItem>现金预付款</asp:ListItem>
                </asp:DropDownList>
            </td>
                            
                           <td style="width: 15%" align="right">
                                <asp:Label ID="Label1" runat="server" Text="到货状态："></asp:Label>
                            </td>
                           <td style="width: 20%" align="left">
                <asp:DropDownList ID="DropDownList2" runat="server"  Width="130px">
                    <asp:ListItem>请选择</asp:ListItem>
                    <asp:ListItem>未到货</asp:ListItem>
                    <asp:ListItem>部分到货</asp:ListItem>
                    <asp:ListItem>已到货</asp:ListItem>

                </asp:DropDownList>
            </td>
             <td style="width: 15%" align="right">
                                <asp:Label ID="Label13" runat="server" Text="供应商名称："></asp:Label>
                            </td>
                            <td style="width: 12%; height: 20px;" align="left">
                                <asp:TextBox ID="TextBox3" runat="server"> </asp:TextBox>
                            </td>
                            <td align="left">
                                <asp:Button ID="Button3" runat="server" Text="选择..." CssClass="Button02" Height="24px"
                                    OnClick="Button_Select2" Width="50px" />
                            </td>
            <tr>
            
              <td style="width: 15%" align="right">
                                <asp:Label ID="Label28" runat="server" Text="制定时间："></asp:Label>
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="TextBox_SPTime2" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D ',true)"
                                     ></asp:TextBox>
                            
                                &nbsp;
                            
                                <asp:Label ID="Label" runat="server" Text="至"></asp:Label>
                            
                                &nbsp;
                            
                                <asp:TextBox ID="TextBox_SPTime3" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D ',true)"
                                     ></asp:TextBox>
                            </td>
           
            </tr>
                        </tr>
                        
                        <tr>
                            <td style="width: 15%" align="left">
                                &nbsp;
                            </td>
                            <td colspan="2" align="center">
                                &nbsp;&nbsp;&nbsp;
                                <asp:Button ID="Button7" runat="server" Text="检索" CssClass="Button02" Height="24px"
                                    OnClick="Button_Sh2" Width="70px" />
                            </td>
                            <td align="left">
                                 <asp:Button ID="Button1" runat="server" Text="新增" CssClass="Button02" Height="24px"
                                    OnClick="Button_New" Visible="true" Width="70px" />
                            </td>
                            <td style="width: 15%"  colspan="2">
                                &nbsp;&nbsp;
                                <asp:Button ID="Button9" runat="server" Text="重置" CssClass="Button02" Height="24px"
                                    OnClick="Button_Reset1" Visible="true" Width="70px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    
    <asp:UpdatePanel ID="UpdatePanel_PMPurchaseOrder" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_PMPurchaseOrder" runat="server" Visible="true">
                <fieldset>
                    <legend>
                        <asp:Label ID="label4" runat="server" Visible="true" Text="采购订单表"></asp:Label>
                    </legend>
                    <asp:GridView ID="Gridview3" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle"
                        CellPadding="0" UseAccessibleHeader="False" Font-Strikeout="False" GridLines="None" PageSize="10"
                        AllowPaging="True" AllowSorting="True" DataKeyNames="PMPO_PurchaseOrderID" OnPageIndexChanging="Gridview3_PageIndexChanging"
                        Width="100%" EnableModelValidation="True" 
                         onrowcommand="Gridview3_RowCommand" 
                        onrowdatabound="Gridview3_RowDataBound">
                        <%--    //隔行变色--%>
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <PagerStyle CssClass="GridViewPagerStyle" />
                        <AlternatingRowStyle />
                        <Columns>
                            <asp:BoundField DataField="PMPO_PurchaseOrderID" HeaderText="采购订单ID" 
                                SortExpression="PMPO_PurchaseOrderID" Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PMSI_ID" HeaderText="供应商编号" 
                                SortExpression="PMSI_ID" >
                            <FooterStyle CssClass="hidden" />
                                <HeaderStyle CssClass="hidden" />
                                <ItemStyle CssClass="hidden" />
                                </asp:BoundField>
                            <asp:BoundField DataField="PMPO_PurchaseOrderNum" HeaderText="采购订单号" 
                                SortExpression="PMPO_PurchaseOrderNum" />
                            <asp:BoundField DataField="PMSI_SupplyName" HeaderText="供应商名称" 
                                SortExpression="PMSI_SupplyName" />
                            <asp:BoundField DataField="PMPO_ArriverCondition" HeaderText="到货情况" 
                                SortExpression="PMPO_ArriverCondition" Visible="False" />
                            <asp:BoundField DataField="PMPO_MakeTime" HeaderText="制定时间" 
                                SortExpression="PMPO_MakeTime" />
                            <asp:BoundField DataField="PMPO_MakeMan" HeaderText="制定人" 
                                SortExpression="PMPO_MakeMan" Visible="False" />
                            <asp:BoundField DataField="PMPO_PlanArrTime" HeaderText="预计到货日期" 
                                SortExpression="PMPO_PlanArrTime" DataFormatString="{0:yyyy-MM-dd}"
                              />
                            <asp:BoundField DataField="PMPO_PayWay" HeaderText="付款方式" 
                                SortExpression="PMPO_PayWay" />
                                <asp:BoundField DataField="PMPO_AdvancePayNum" HeaderText="预付款金额" 
                                SortExpression="PMPO_AdvancePayNum" />
                            <asp:BoundField DataField="PMPO_PaymentTime" HeaderText="账期" 
                                SortExpression="PMPO_PaymentTime" />
                            <asp:BoundField DataField="PMPO_BillNum" HeaderText="开票单号" 
                                SortExpression="PMPO_BillNum" Visible="False" />
                            <asp:BoundField DataField="PMPO_BillTime" HeaderText="开票日期" 
                                SortExpression="PMPO_BillTime" Visible="False" />
                            <asp:BoundField DataField="PMPO_TotalMoney" HeaderText="总额" 
                                SortExpression="PMPO_TotalMoney" />
                            <asp:BoundField DataField="PMPO_ResidueMoney" HeaderText="剩余付款" 
                                SortExpression="PMPO_ResidueMoney" Visible="False" />
                            <asp:BoundField DataField="PMPO_AlreadyPay" HeaderText="是否结款" 
                                SortExpression="PMPO_AlreadyPay" Visible="False" />
                            <asp:BoundField DataField="PMPO_CountInPayables" HeaderText="是否算入应付款" 
                                SortExpression="PMPO_CountInPayables" Visible="False" />
                            <asp:BoundField DataField="PMPO_State" HeaderText="状态" 
                                SortExpression="PMPO_State" />
                            <asp:TemplateField>
                            <ItemTemplate>
                                    <asp:LinkButton ID="btnLook1" runat="server" CommandName="Check1" CommandArgument='<%#Eval("PMPO_PurchaseOrderID")%>'>查看</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                            <ItemTemplate>
                                    <asp:LinkButton ID="btnMakey" runat="server" CommandName="Makey" CommandArgument='<%#Eval("PMPO_PurchaseOrderID")%>'>制定</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label50" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <PagerStyle ForeColor="Black" HorizontalAlign="Center" CssClass="GridViewPagerStyle" />
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
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                    </asp:GridView>
                    <table width="100%">
                        
                        </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
  
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel3" runat="server" Visible="false">
                <fieldset>
                    <legend><asp:Label ID="Label7" runat="server" Text="新增采购订单"></asp:Label></legend>
                    <asp:Label ID="Label_MakeTime" runat="server" Visible="false"></asp:Label>
                    <table style="width: 100%;">
                        <tr>
                            <td align="right" class="auto-style8">
                                <asp:Label ID="Label8" runat="server" Text="供应商名称："></asp:Label>
                            </td>
                            <td align="left" class="auto-style9">
                                <asp:TextBox ID="TextBox1" runat="server" Enabled="false" > </asp:TextBox>
                           <asp:Label ID="Label20" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                            <td align="left" style="width: 7%;">
                                <asp:Button ID="Button4" runat="server" Text="选择..." CssClass="Button02" Height="24px"
                                    OnClick="Button_Select3" Width="50px" />
                            </td>
                            <td style="width: 10%" align="right">
                                <asp:Label ID="Label9" runat="server" Text="付款方式："></asp:Label>
                            </td>
                            <td align="left" class="auto-style10">
                                <asp:DropDownList ID="DropDownList6" runat="server" Width="130px" 
                                    onselectedindexchanged="DropDownList6_SelectedIndexChanged" 
                                    AutoPostBack="True">
                                    <asp:ListItem>请选择</asp:ListItem>
                                    <asp:ListItem>先货后款</asp:ListItem>
                                    <asp:ListItem>货到付款</asp:ListItem>
                                    <asp:ListItem>预付款</asp:ListItem>
                                    <asp:ListItem>现金预付款</asp:ListItem>
                                </asp:DropDownList>
                                <asp:Label ID="Label26" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                             <td style="width: 10%" align="right">
                                <asp:Label ID="Label10" runat="server" Text="账期："></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TextBox2" runat="server" Enabled="false" > </asp:TextBox>
                            </td>
                           
                        </tr>
                        <tr>

                            <td align="right" class="auto-style8">
                                <asp:Label ID="Label11" runat="server" Text="预到货期："></asp:Label>
                            </td>
                            <td class="auto-style10">
                                <asp:TextBox ID="TextBox5" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D ',true)"
                                     ></asp:TextBox>
                                     <asp:Label ID="Label29" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                            <td align="center">
                            </td>
                             <td align="right" style="width: 10%">
                                <asp:Label ID="Label27" runat="server" Text="预付款金额：" Visible="false" ></asp:Label>
                            </td>
                            <td align="left" style="width: 20%">
                               <asp:TextBox ID="TextBox14" runat="server"   Visible="false" onkeyup="this.value=this.value.replace(/[^0-9.]/g,'')"
                                    onafterpaste="this.value=this.value.replace(/[^0-9.]/g,'')"> </asp:TextBox>
                                     <asp:Label ID="Label35" runat="server" Text="*" ForeColor="Red" Visible="false"></asp:Label>
                               
                            </td>
                        </tr>
                        
                        <tr>
                            <td align="left" class="auto-style8">
                                &nbsp;
                            </td>
                             <td align="left" class="auto-style10">
                                &nbsp;
                            </td>
                            <td  colspan="2" align="left">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="Button5" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    OnClick="Button_Create" Width="70px" />
                            </td>
                            <td colspan="2" align="right">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="Button6" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="Button_Reset4" Visible="true" Width="70px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
   
    <script type="text/javascript">
        var last = null;
        function judge(obj) {
            if (last == null) {
                last = obj.id;
            }
            else {
                var lo = document.getElementById(last);
                lo.checked = false;
                last = obj.id;

            }
            obj.checked = "checked";
        }
    </script>
    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel4" runat="server" Visible="false">
                <fieldset>
                    <legend>供应商查询</legend>
                    <asp:Label ID="LabelSupplyID" runat="server" Visible="false"></asp:Label>
                    <table style="width: 100%;">
       
        <tr>
        <td style="width: 12%; height: 20px;" align="right">
             
            </td>
        <td style="width: 12%; height: 20px;" align="right">
                <asp:Label ID="Label36" runat="server" Text="供应商编码："></asp:Label>
            </td>
            <td style="width: 12%; height: 20px;" align="left">
                <asp:TextBox ID="TextBox7" runat="server"> </asp:TextBox>
            </td>
            
           
            <td style="width: 12%; height: 20px;" align="left">
            
            </td>
           
            <td style="width: 12%; height: 20px;" align="right">
            <asp:Label ID="Label38" runat="server" Text="供应商名称："></asp:Label>
            </td>
               <td style="width: 15%; height: 20px;" align="left">
                <asp:TextBox ID="TextBox13" runat="server"></asp:TextBox>
            </td> 
            </tr>
            <tr>
            
                <td  align="center" colspan="3">
                    <asp:Button ID="Button18" runat="server" CssClass="Button02" Height="24px" 
                        OnClick="Button1_KiMi" Text="检索" Width="80px" />
                        </td>
                        <td colspan="3" align="center">
                    <asp:Button ID="Button19" runat="server" Text="重置" CssClass="Button02" Height="24px" OnClick="Button_CoMi"
                    Width="80px" />
                </td>
              
                </tr>
       
    </table>
                    <asp:GridView ID="Gridview2" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle"
                        CellPadding="0" UseAccessibleHeader="False" Font-Strikeout="False" 
                        GridLines="None" PageSize="5"
                        AllowPaging="True" AllowSorting="True" 
                        DataKeyNames="PMSI_SupplyName,PMSI_ID" OnPageIndexChanging="Gridview_PMSupply_PageIndexChanging"
                        Width="100%" OnRowDataBound="Gridview_PMSupply_RowDataBound">
                        <%--    //隔行变色--%>
                        <AlternatingRowStyle />
                        <PagerStyle ForeColor="Black" HorizontalAlign="Center" CssClass="GridViewPagerStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:RadioButton ID="RadioButtonMarkup" runat="server"></asp:RadioButton>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:BoundField DataField="PMSI_ID" HeaderText="供应商ID" SortExpression="PMSI_ID" Visible="False">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="PMSI_SupplyNum" HeaderText="供应商编码" SortExpression="PMSI_SupplyNum" />
                            <asp:BoundField DataField="PMSI_SupplyName" HeaderText="供应商名称" SortExpression="PMSI_SupplyName" />
                            <asp:BoundField DataField="PMSI_PaymentTime" HeaderText="账期" 
                                SortExpression="PMSI_PaymentTime" />
                        </Columns>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label50" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <HeaderStyle CssClass="GridViewHead" HorizontalAlign="Center" />
                        <PagerStyle CssClass="GridViewPagerStyle" />
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
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                    </asp:GridView>
                    <table width="100%">
                        <tr>
                            <td width="34%" align="right">
                                <asp:Button ID="Button10" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    OnClick="Button_ComSP" Width="70px" />
                            </td>
                            <td style="width: 20%" align="center">
                                &nbsp;
                            </td>

                            <td width="30%" align="left">
                                <asp:Button ID="Button13" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="Button_Cancel5" Width="70px" />
                            </td>
                        </tr>
                </fieldset>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
     
     <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel2" runat="server" Visible="false">
                <fieldset>
                    <legend><asp:Label ID="Label6" runat="server" ></asp:Label></legend>
                    <table style="width: 100%;">
                        <tr>
                            <td align="right" class="auto-style11">
                                <asp:Label ID="Label14" runat="server" Text="物料名称："></asp:Label>
                            </td>
                            <td align="left" class="auto-style9">
                                <asp:TextBox ID="TextBox4" runat="server" Enabled="false" > </asp:TextBox>
                           <asp:Label ID="Label30" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Button ID="Button8" runat="server" Text="选择..." CssClass="Button02" Height="24px"
                                    OnClick="Button_SelectM" Width="50px" />
                            </td>
                            <td style="width: 12%" align="right">
                                <asp:Label ID="Label12" runat="server" Text="单位："></asp:Label>
                            </td>
                            <td align="left" class="auto-style14">
                                <asp:TextBox ID="TextBox8" runat="server" Enabled="false" > </asp:TextBox>
                            </td>
                             <td style="width: 15%" align="right">
                                <asp:Label ID="Label17" runat="server" Text="规格型号："></asp:Label>
                            </td>
                            <td style="width: 12%; height: 20px;" align="left">
                                <asp:Label ID="TextBox9" runat="server" ></asp:Label>
                              <%--  <asp:TextBox ID="TextBox9" runat="server" Enabled="false" > </asp:TextBox>--%>
                            </td>
                            
                        </tr>
                        <tr>
                        <td align="right" class="auto-style11">
                                <asp:Label ID="Label19" runat="server" Text="数量："></asp:Label>
                            </td>
                            <td align="left" class="auto-style9">
                                <asp:TextBox ID="TextBox6" runat="server" onkeyup="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{4,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{4})[0-9]*/, '$1');" 
                              onafterpaste="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{4,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{4})[0-9]*/, '$1');"> </asp:TextBox>
                           <asp:Label ID="Label31" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                            <td style="width: 15%" align="center">
                                &nbsp;
                            </td>
                            
                            <td style="width: 15%" align="right">
                                <asp:Label ID="Label21" runat="server" Text="单价："></asp:Label>
                            </td>
                            <td align="left" class="auto-style14">
                                <asp:TextBox ID="TextBox10" runat="server" onkeyup="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{4,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{4})[0-9]*/, '$1');" 
                              onafterpaste="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{4,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{4})[0-9]*/, '$1');"> </asp:TextBox>
                           <asp:Label ID="Label32" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                        <td align="right" class="auto-style11">
                                <asp:Label ID="Label22" runat="server" Text="产品要求："></asp:Label>
                                <br/>
                         <asp:Label ID="Label24" runat="server" Text="(1000字以内)"></asp:Label>
                            </td>
                            <td colspan="6" align="left">
                                <asp:TextBox ID="TextBox11" runat="server" Height="48px" Width="96%" MaxLength="200" TextMode="MultiLine"   
                         ></asp:TextBox>
                           <asp:Label ID="Label33" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                        <td align="right" class="auto-style11">
                                <asp:Label ID="Label23" runat="server" Text="备注："></asp:Label>
                                <br/>
                         <asp:Label ID="Label25" runat="server" Text="(200字以内)"></asp:Label>
                            </td>
                            <td colspan="6" align="left">
                                <asp:TextBox ID="TextBox12" runat="server" Height="48px" Width="96%" 
                                    MaxLength="200" TextMode="MultiLine"   
                       ></asp:TextBox>
                            <asp:Label ID="Label34" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        
                        <tr>
                            <td align="left" class="auto-style11"></td>
                             <td align="left" class="auto-style10"></td>
                            <td  colspan="1" >
                              <asp:Button ID="Button2" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    OnClick="Button_Comfirm" Width="70px" />
                            </td>
                            <td align="center"></td>
                            <td colspan="2">
                                <asp:Button ID="Button12" runat="server" Text="重置" CssClass="Button02" Height="24px"
                                    OnClick="Button_Reset5" Visible="true" Width="70px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
     
    <asp:UpdatePanel ID="UpdatePanel_Material" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Material" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="label18" runat="server" Visible="true" Text="物料表"></asp:Label>
                    </legend>
                     <table style="width: 100%;">
       
        <tr>
        <td colspan="1" >
             
            </td>
        <td colspan="1" align="right">
                <asp:Label ID="Label39" runat="server" Text="物料名称："></asp:Label>
            </td>
            <td colspan="1" align="left">
                <asp:TextBox ID="TextBox16" runat="server"> </asp:TextBox>
            </td>
            <td colspan="1" align="right">
                <asp:Label ID="Label40" runat="server" Text="规格型号："></asp:Label>
            </td>
            <td colspan="1" align="left">
                <asp:TextBox ID="TextBox17" runat="server"> </asp:TextBox>
            </td>
           
            <td colspan="1" >
            
            </td>
           
            </tr>
            <tr>
            
                <td  align="center" colspan="3">
                    <asp:Button ID="Button25" runat="server" CssClass="Button02" Height="24px" 
                        OnClick="Button1_KiM" Text="检索" Width="80px" />
                        </td>
                        <td colspan="3" align="center">
                    <asp:Button ID="Button26" runat="server" Text="重置" CssClass="Button02" Height="24px" OnClick="Button_CoM"
                    Width="80px" />
                </td>
              
                </tr>
       
    </table>
                    <asp:GridView ID="Gridview5" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle"
                        CellPadding="0" UseAccessibleHeader="False" Font-Strikeout="False" GridLines="None" PageSize="10"
                        AllowPaging="True" AllowSorting="True" DataKeyNames="IMMBD_MaterialID,IMUC_ID"
                        OnPageIndexChanging="Gridview5_PageIndexChanging" Width="100%" EnableModelValidation="True"
                        OnRowDataBound="Gridview5_RowDataBound">
                        <%--    //隔行变色--%>
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <PagerStyle CssClass="GridViewPagerStyle" />
                        <AlternatingRowStyle />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:RadioButton ID="RadioButtonMarkup" runat="server" GroupName="GN"></asp:RadioButton>
                                </ItemTemplate>
                                <ItemStyle Width="100px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="IMMBD_MaterialName" HeaderText="物料名称" SortExpression="IMMBD_MaterialName">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_SpecificationModel" HeaderText="规格型号" SortExpression="IMMBD_SpecificationModel">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_MaterialID" HeaderText="物料ID" SortExpression="IMMBD_MaterialID"
                                Visible="False" />
                            <asp:BoundField DataField="UnitName" HeaderText="单位" SortExpression="UnitName" Visible="true" />
                            <asp:BoundField DataField="IMUC_ID" HeaderText="物料单位ID" SortExpression="IMUC_ID"
                                Visible="False" />
                        </Columns>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label50" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <PagerStyle ForeColor="Black" HorizontalAlign="Center" CssClass="GridViewPagerStyle" />
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
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                    </asp:GridView>
                    <table width="100%">
                        <tr>
                            <td width="34%" align="right">
                                <asp:Button ID="Button15" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    OnClick="Button_Com1" Width="70px" />
                                </td>
                            <td style="width: 20%" align="center">
                                &nbsp;
                            </td>
                            <td width="30%" align="left">
                                <asp:Button ID="Button16" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="Button_Cancel1" Width="70px" />
                            </td>
                           
                        </tr>
                </fieldset>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
     
    <asp:UpdatePanel ID="UpdatePanel_PMPurchaseOrderDetail" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_PMPurchaseOrderDetail" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="label5" runat="server" Visible="true"></asp:Label>
                    </legend>
                     <asp:Label ID="label_MaterialID" runat="server" Visible="false"></asp:Label>
                     <asp:Label ID="label_IMUC_ID" runat="server" Visible="false"></asp:Label>
                     <asp:Label ID="labelMark" runat="server" Visible="false"></asp:Label>
                     <asp:Label ID="label_ZS" runat="server" Visible="false"></asp:Label>
                     <asp:Label ID="label_ActuallNum" runat="server" Visible="false"></asp:Label>
                     <asp:Label ID="label_TotalMoney" runat="server" Visible="false"></asp:Label>
                    <asp:GridView ID="Gridview1" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle"
                        CellPadding="0" UseAccessibleHeader="False" Font-Strikeout="False" GridLines="None" PageSize="10"
                        AllowPaging="True" AllowSorting="True" 
                        DataKeyNames="PMPOD_PurchaseDetailID,IMMBD_MaterialID,IMUC_ID" OnPageIndexChanging="Gridview1_PageIndexChanging"
                        Width="100%" EnableModelValidation="True" 
                        onrowcommand="Gridview1_RowCommand" OnDataBound="Gridview1_DataBound">
                        <%--    //隔行变色--%>
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <PagerStyle CssClass="GridViewPagerStyle" />
                        <AlternatingRowStyle />
                        <Columns>
                            <asp:BoundField DataField="PMPOD_PurchaseDetailID" HeaderText="采购订单详细表ID" 
                                SortExpression="PMPOD_PurchaseDetailID" Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_MaterialName" HeaderText="物料名称" SortExpression="IMMBD_MaterialName" />
                            <asp:BoundField DataField="IMMBD_SpecificationModel" HeaderText="规格型号" SortExpression="IMMBD_SpecificationModel" />
                            <asp:BoundField DataField="PMPOD_Price" HeaderText="单价" 
                                SortExpression="PMPOD_Price" />
                            <asp:BoundField DataField="PMPOD_Num" HeaderText="数量" 
                                SortExpression="PMPOD_Num" />
                            <asp:BoundField DataField="UnitName" HeaderText="单位" SortExpression="UnitName" />
                            <asp:BoundField DataField="PMPOD_ProductRequest" HeaderText="产品要求" 
                                SortExpression="PMPOD_ProductRequest" />
                            <asp:BoundField DataField="PMPOD_Remark" HeaderText="备注" 
                                SortExpression="PMPOD_Remark" />
                            <asp:BoundField DataField="PMPOD_ActuallNum" HeaderText="实际到货数量" 
                                SortExpression="PMPOD_ActuallNum">
                                
                                </asp:BoundField>
                            <asp:TemplateField>
                            <ItemTemplate>
                                    <asp:LinkButton ID="ButtonChange" runat="server" CommandName="ButtonChange" CommandArgument='<%#Eval("PMPOD_PurchaseDetailID")%>'>编辑</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                            <ItemTemplate>
                                    <asp:LinkButton ID="ButtonDelete" runat="server" CommandName="ButtonDelete" OnClientClick="return confirm('您确认删除该记录吗?')" CommandArgument='<%#Eval("PMPOD_PurchaseDetailID")%>'>删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="IMMBD_MaterialID" HeaderText="物料ID" 
                                SortExpression="IMMBD_MaterialID" Visible="False" />
                            <asp:BoundField DataField="IMUC_ID" HeaderText="物料单位ID" 
                                SortExpression="IMUC_ID" Visible="False" />
                            <asp:BoundField DataField="PMPOD_TotalMoney" HeaderText="总额" 
                                SortExpression="PMPOD_TotalMoney"  >
                                <FooterStyle CssClass="hidden" />
                                <HeaderStyle CssClass="hidden" />
                                <ItemStyle CssClass="hidden" />
                                </asp:BoundField>
                        </Columns>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label50" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <PagerStyle ForeColor="Black" HorizontalAlign="Center" CssClass="GridViewPagerStyle" />
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
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                    </asp:GridView>
                    <table width="100%">
                        <tr>
                        <td align="right" style="width: 34%">
                                <asp:Button ID="Button14" runat="server" CssClass="Button02" Height="24px" OnClick="ButtonMark"
                                    Text="提交" Width="70px" />
                                </td>
                            <td align="center" style="width: 20%">
                                <asp:Button ID="Button11" runat="server" CssClass="Button02" Height="24px" OnClick="ButtonClose"
                                    Text="关闭" Width="70px" />
                                &nbsp;
                            </td>
                            <td align="left" style="width: 30%">
                                <asp:Button ID="Button17" runat="server" CssClass="Button02" Height="24px" OnClick="ButtonCancel"
                                    Text="关闭" Width="70px" />
                                &nbsp;
                            </td>
                        </tr>
                        </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
 
    </asp:Content>
