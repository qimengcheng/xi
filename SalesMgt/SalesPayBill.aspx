<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SalesPayBill.aspx.cs" Inherits="SalesMgt_SalesPayBill"  MasterPageFile="~/Other/MasterPage.master" Title="销售汇款开票" %>

<script runat="server">
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
    <script language="javascript" type="text/javascript">

        function ValidtorTime(start, end) {
            var idstart = "ctl00_ContentPlaceHolder1_" + start;
            var idend = "ctl00_ContentPlaceHolder1_" + end;
            var d1 = new Date(document.getElementById(idstart).value.replace(/\-/g, "\/"));
            var d2 = new Date(document.getElementById(idend).value.replace(/\-/g, "\/"));
            if (d1 > d2) {
                return false;
            }
            return true;
        }
       

        function annotation(name) {
            var id = "ctl00_ContentPlaceHolder1_" + name;
            var label = document.getElementById(id);
            label.style.visibility = 'visible';
            return false;
        }
        function leave(name) {
            var id = "ctl00_ContentPlaceHolder1_" + name;
            var label = document.getElementById(id);
            label.style.visibility = 'hidden';
            return false;
        }

        function isdigit(name) {
            var id = "ctl00_ContentPlaceHolder1_" + name;
            var s = document.getElementById(id).value;
            var r, re;
            re = /\d*/i; //\d表示数字,*表示匹配多个数字
            r = s.match(re);
            return (r == s) ? true : false;
        }
    </script>
    <script type="text/javascript">

        function MaxLength(field, maxlimit) {
            var j = field.value.replace(/[^\x00-\xff]/g, "**").length;

            var tempString = field.value;
            var tt = "";
            if (j > maxlimit) {
                for (var i = 0; i < maxlimit; i++) {
                    if (tt.replace(/[^\x00-\xff]/g, "**").length < maxlimit)
                        tt = tempString.substr(0, i + 1);
                    else
                        break;
                }
                if (tt.replace(/[^\x00-\xff]/g, "**").length > maxlimit)
                    tt = tt.substr(0, tt.length - 1);
                field.value = tt;
            }
            else {
                ;
            }
        }
  
</script>
    <script type="text/javascript">
        function setRadio(nowRadio) {
            var myForm, objRadio;
            myForm = document.forms[0];
            ///alert(myForm);
            for (var i = 0; i < myForm.length; i++) {
                if (myForm.elements[i].type == "radio") {
                    objRadio = myForm.elements[i];
                    ///alert(objRadio.name);
                    if (objRadio != nowRadio && objRadio.name.indexOf("Gridview_MatType") > -1 && objRadio.name.indexOf("RadioButton1") > -1) {

                        if (objRadio.checked) {
                            objRadio.checked = false;
                        }

                    }
                }
            }
        }

    </script>
    <script type="text/javascript">
        function setRadio1(nowRadio) {
            var myForm, objRadio;
            myForm = document.forms[0];
            ///alert(myForm);
            for (var i = 0; i < myForm.length; i++) {
                if (myForm.elements[i].type == "radio") {
                    objRadio = myForm.elements[i];
                    ///alert(objRadio.name);
                    if (objRadio != nowRadio && objRadio.name.indexOf("Gridview_PT") > -1 && objRadio.name.indexOf("RadioButton2") > -1) {

                        if (objRadio.checked) {
                            objRadio.checked = false;
                        }

                    }
                }
            }
        }
    </script>
    <%--    // 弹出窗口的js--%>
    <script language="javascript" type="text/javascript">
        function test1() {
            var aa = window.confirm("单击“确定”继续。单击“取消”停止。");
            if (aa) {
                window.alert("你选了确定！");
            }
            else window.alert("你选了取消！");
        }
    </script>
       <%-- 检索--%>
    <asp:UpdatePanel ID="UpdatePanel_SearchMain" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_SearchMain" runat="server" Visible="true">
                <asp:Label ID="label21" runat="server" Visible="False"></asp:Label>
                <fieldset>
                    <legend>检索条件</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 12%" align="center">
                                <asp:Label ID="Label22" runat="server" Text="客户名称："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox13"></asp:TextBox>
                            </td>
                            <td style="width: 13%" align="center">
                                <asp:Label ID="Label45" runat="server" Text="发货时间从："></asp:Label>
                            </td>
                            <td style="width: 10%" align="left">
                                <%--<asp:TextBox runat="server" ID="TextBox14" onkeyup="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{2,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{2})[0-9]*/, '$1');" 
                              onafterpaste="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{2,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{2})[0-9]*/, '$1');"></asp:TextBox>--%>
                                      <asp:TextBox runat="server" ID="TextBox14" onfocus="new WdatePicker(this,'%Y-%M-%D ',true)"
                                    DataFormatString="{0:yyyy-MM-dd}"  ></asp:TextBox>
                            </td>
                            <td style="width: 15%" align="center">
                                <asp:Label ID="Label46" runat="server" Text="到"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <%--<asp:TextBox runat="server" ID="TextBox17" 
                                   onkeyup="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{2,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{2})[0-9]*/, '$1');" 
                              onafterpaste="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{2,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{2})[0-9]*/, '$1');" ></asp:TextBox>--%>
                                 <asp:TextBox runat="server" ID="TextBox17" onfocus="new WdatePicker(this,'%Y-%M-%D ',true)"
                                    DataFormatString="{0:yyyy-MM-dd}"  ></asp:TextBox>
                            </td>
                               </tr>

                       <tr>
                            <td><asp:CheckBox ID="CheckBox3" runat="server"  Text="未开票发货单" /></td>
                        <td><asp:CheckBox ID="CheckBox4" runat="server"  Text="未付款发货单" /></td>
                            </tr>
                            <tr>
                          
                         
                               <td colspan="2"  align="center">
                                <asp:Button ID="Button7" runat="server" Text="检索" CssClass="Button02" Height="24px"
                                    OnClick="SearchDeliver" Width="70px" />
                            </td>

                                <td colspan="2"  align="center">
                                <asp:Button ID="Button3" runat="server" Text="重置" CssClass="Button02" Height="24px"
                                    OnClick="ResetDeliver" Width="90px" /></td>
                         <td colspan="2"  align="center">
                                <asp:Button ID="Button9" runat="server" Text="新增回款" CssClass="Button02" Height="24px"
                                    OnClick="OpenNewPay" Width="70px" />
                            </td>
                        </tr>
                     
                    
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
       <%--投诉类别表--%>
    <asp:UpdatePanel ID="UpdatePanel_Main" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel__Main" runat="server" Visible="True">
                <asp:Label ID="label19" runat="server" Visible="false"></asp:Label>
               
                <fieldset>
                     <table style="width:100%">
                    <tr>
                        <td><asp:CheckBox ID="CheckBox2" runat="server"  Text="发货单精简信息" AutoPostBack="True" OnCheckedChanged="CheckBox2_CheckedChanged"/></td>
                        <td><asp:CheckBox ID="CheckBox5" runat="server"  Text="发货单完整信息" AutoPostBack="True" OnCheckedChanged="CheckBox5_CheckedChanged"/></td>
                         <td><asp:CheckBox ID="CheckBox6" runat="server"  Text="显示开票填写框" AutoPostBack="True" OnCheckedChanged="CheckBox6_CheckedChanged"/></td>
                    </tr>
                        <tr>
                            <td colspan="2"><asp:Label ID="label7" runat="server" Visible="true" Text="开票价格、开票数量、开票单号必须同时填写，否则不予生成开票记录!" ForeColor="Red"></asp:Label></td>
                        </tr>
                </table>
                    <legend>   <asp:Label ID="label37" runat="server" Visible="true"></asp:Label>客户发货单</legend>
                    <asp:GridView ID="Gridview_Main" runat="server" AutoGenerateColumns="False"
                        CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False" 
                        PageSize="20" AllowPaging="True" AllowSorting="false" 
                        DataKeyNames="SMOD_ID" GridLines="None"
                        Width="100%" OnPageIndexChanging="Gridview_Main_PageIndexChanging" 
                        OnRowCommand="Gridview_Main_RowCommand"  OnDataBound="Gridview_Main_DataBound"
                       >
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <%--    //隔行变色--%>
                        <Columns>
                         <asp:BoundField DataField="SMOD_ID" HeaderText="发货单ID" ReadOnly="True" SortExpression="SMOD_ID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCIF_Name" HeaderText="客户名称" ReadOnly="True" SortExpression="CRMCIF_Name"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMSO_ComOrderNum" HeaderText="订单号" ReadOnly="True" SortExpression="SMSO_ComOrderNum">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="PT_Name" HeaderText="产品型号" ReadOnly="True" SortExpression="PT_Name"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="PT_Note" HeaderText="产品备注" SortExpression="PT_Note">
                                <ItemStyle />
                            </asp:BoundField>
                              <asp:BoundField DataField="SMSOD_UnitPrice" HeaderText="单价" SortExpression="SMSOD_UnitPrice">
                                <ItemStyle />
                            </asp:BoundField>
                               <asp:BoundField DataField="SMOD_Num" HeaderText="发货数量" SortExpression="SMOD_Num">
                                <ItemStyle />
                            </asp:BoundField>
                                <asp:BoundField DataField="SMOD_ReturnNum" HeaderText="退货数量" SortExpression="SMOD_ReturnNum">
                                <ItemStyle />
                            </asp:BoundField>
                             
                             <asp:BoundField DataField="IMOHM_OutHouseNum" HeaderText="出库单号" ReadOnly="True" 
                                SortExpression="IMOHM_OutHouseNum">
                                <ItemStyle />
                            </asp:BoundField>
                               <asp:BoundField DataField="totalmoney" HeaderText="总额" ReadOnly="True" 
                                SortExpression="totalmoney">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMOD_BillMoney" HeaderText="已开票金额" ReadOnly="True" 
                                SortExpression="SMOD_BillMoney">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMOD_BillOver" HeaderText="开票完结" ReadOnly="True" 
                                SortExpression="SMOD_BillOver">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMOD_PayMoney" HeaderText="已付款金额" ReadOnly="True" 
                                SortExpression="SMOD_PayMoney">
                                <ItemStyle />
                            </asp:BoundField>

                               <asp:TemplateField HeaderText="开票价格" HeaderStyle-Font-Bold="true" Visible="true">
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" Width="80px" onkeyup="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{4,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{4})[0-9]*/, '$1');" 
                              onafterpaste="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{4,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{4})[0-9]*/, '$1');"></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle Font-Bold="True" />
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="开票数量" HeaderStyle-Font-Bold="true" Visible="true">
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBox4" runat="server" Width="80px" onkeyup="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{4,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{4})[0-9]*/, '$1');" 
                              onafterpaste="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{4,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{4})[0-9]*/, '$1');"></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle Font-Bold="True" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="开票单号" HeaderStyle-Font-Bold="true" Visible="true">
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBox5" runat="server" Width="80px"  MaxLength="100"></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle Font-Bold="True" />
                            </asp:TemplateField>
                                   
                            <asp:TemplateField Visible="true" HeaderText="备注">
                                <ItemTemplate>
                                  <asp:TextBox ID="TextBox6" runat="server" Width="100px" MaxLength="200"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField> 
                            <asp:TemplateField HeaderText="部分开票" HeaderStyle-Font-Bold="true" Visible="true">
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" Text="是" />
                                </ItemTemplate>
                                <HeaderStyle Font-Bold="True" />
                            </asp:TemplateField>
                             <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Bill" runat="server" CommandName="Bill" OnClientClick="false"
                                        CommandArgument='<%#Eval("SMOD_ID")%>'>开票详细</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Pay" runat="server" CommandName="Pay" OnClientClick="false"
                                        CommandArgument='<%#Eval("SMOD_ID")%>'>付款详细</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:BoundField DataField="SMOD_Time" HeaderText="发货时间" ReadOnly="True" 
                                SortExpression="SMOD_Time" DataFormatString="{0:yyyy-MM-dd}">
                                <ItemStyle />
                            </asp:BoundField>
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
                           <table width="100%">
                           <tr>
                            <td style="width:100%"></td>
                           </tr></table>
                        </PagerTemplate>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label50" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                        <AlternatingRowStyle />
                    </asp:GridView>
                        <table style="width:100%">
                        <tr>
                              <td colspan="3"  align="center">
                                <asp:Button ID="Button4" runat="server" Text="提交当前页" CssClass="Button02" Height="24px"
                                    OnClick="ConfirmBill" Width="90px" />
                            </td>
                                <td colspan="3"  align="center">
                                <asp:Button ID="Button5" runat="server" Text="重置" CssClass="Button02" Height="24px"
                                    OnClick="ResetBill" Width="90px" /></td></td>
                        </tr>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
   
       <%-- 新建客诉主表--%>

       <asp:UpdatePanel ID="UpdatePanel_Bill" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Bill" runat="server" Visible="false">
                <asp:Label ID="label5" runat="server" Visible="false"></asp:Label>
                <fieldset>
                    <legend><asp:Label ID="label31" runat="server" Visible="true"></asp:Label>开票详细表</legend>
                    <asp:GridView ID="Gridview_Bill" runat="server" AutoGenerateColumns="False"
                        CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False" 
                        PageSize="10" AllowPaging="True" AllowSorting="True" 
                        DataKeyNames="SMCB_ID" GridLines="None"
                        Width="100%" 
                        ondatabound="Gridview_Bill_DataBound" >
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <%--    //隔行变色--%>
                        <Columns>
                            <asp:BoundField DataField="SMCB_ID" HeaderText="售后类别ID" ReadOnly="True" SortExpression="SMCB_ID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            
                                
                              <asp:BoundField DataField="SMCB_BillPrice" HeaderText="开票单价" ReadOnly="false" SortExpression="SMCB_BillPrice"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                              <asp:BoundField DataField="SMCB_BillMount" HeaderText="数量" ReadOnly="false" SortExpression="SMCB_BillMount"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                      
                            <asp:BoundField DataField="SMCB_BillNum" HeaderText="开票单号" ReadOnly="false" SortExpression="SMCB_BillNum">
                                <ItemStyle />
                            </asp:BoundField>
                                   <asp:BoundField DataField="SMCB_BillTime" HeaderText="开票时间" SortExpression="SMCB_BillTime"   DataFormatString="{0:yyyy-MM-dd}">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMCB_MakeMan" HeaderText="录入人" ReadOnly="false" SortExpression="SMCB_MakeMan"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMCB_Remark" HeaderText="备注" ReadOnly="false" SortExpression="SMCB_Remark">
                                <ItemStyle />
                            </asp:BoundField>

                     
                        
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Edit2" runat="server" CommandName="Edit2" OnClientClick="false"
                                        CommandArgument='<%#Eval("SMCB_ID")%>'>编辑</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField> 
                              <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete2" runat="server" CommandName="Delete2" OnClientClick="return confirm('您确认删除此条目吗?')"
                                        CommandArgument='<%#Eval("SMCB_ID")%>'>删除</asp:LinkButton>
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
                           <table width="100%">
                           <tr>
                            <td style="width:100%"></td>
                           </tr></table>
                        </PagerTemplate>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label50" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                        <AlternatingRowStyle />
                    </asp:GridView>
                          <table style="width:100%">
                        <tr>
                              <td colspan="3"  align="center">
                                <asp:Button ID="Button6" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="CloseBillDetail" Width="90px" />
                            </td>
                           
                        </tr>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
      <asp:UpdatePanel ID="UpdatePanel_Pay" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Pay" runat="server" Visible="false">
                <asp:Label ID="label24" runat="server" Visible="false"></asp:Label>
                <fieldset>
                    <legend><asp:Label ID="label30" runat="server" Visible="true"></asp:Label>回款详细表</legend>
                    <asp:GridView ID="Gridview_Apply" runat="server" AutoGenerateColumns="False"
                        CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False" 
                        PageSize="10" AllowPaging="True" AllowSorting="false" 
                        DataKeyNames="SMCP_ID" GridLines="None"
                        Width="100%" 
                        ondatabound="Gridview_Apply_DataBound1" >
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <%--    //隔行变色--%>
                        <Columns>
                            <asp:BoundField DataField="SMCP_ID" HeaderText="售后类别ID" ReadOnly="True" SortExpression="SMCP_ID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="SMCP_PaymentMoney" HeaderText="付款金额" ReadOnly="false" SortExpression="SMCP_PaymentMoney"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMCP_PaymentTime" HeaderText="付款时间" ReadOnly="false" SortExpression="SMCP_PaymentTime"  DataFormatString="{0:yyyy-MM-dd}">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMCP_MakeMan" HeaderText="录入人" ReadOnly="false" SortExpression="SMCP_MakeMan"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMCP_Remark" HeaderText="备注" ReadOnly="false" SortExpression="SMCP_Remark">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Edit2" runat="server" CommandName="Edit2" OnClientClick="false"
                                        CommandArgument='<%#Eval("SMCP_ID")%>'>编辑</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete2" runat="server" CommandName="Delete2" OnClientClick="return confirm('您确认删除此条目吗?')"
                                        CommandArgument='<%#Eval("SMCP_ID")%>'>删除</asp:LinkButton>
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
                           <table width="100%">
                           <tr>
                            <td style="width:100%"></td>
                           </tr></table>
                        </PagerTemplate>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label50" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                        <AlternatingRowStyle />
                    </asp:GridView>
                     <table style="width:100%">
                        <tr>
                              <td colspan="3"  align="center">
                                <asp:Button ID="Button8" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="ClosePayDetail" Width="90px" />
                            </td>
                           
                        </tr>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
      <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" Visible="false" 
                style="margin-bottom: 0px">
                <asp:Label ID="label1" runat="server" Visible="False"></asp:Label>  <asp:Label ID="label44" runat="server" Visible="False"></asp:Label>
                <fieldset>
                    <legend><asp:Label ID="label2" runat="server" Visible="true"></asp:Label>回款</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 15%" align="center">
                                <asp:Label ID="Label36" runat="server" Text="客户名称："></asp:Label>
                            </td>
                            <td style="width: 30%" align="left">
                                <asp:TextBox runat="server" ID="TextBox16" Enabled="false"></asp:TextBox>                                <asp:Button ID="Button18" runat="server" 
    Text="选择…" CssClass="Button02" Height="20px"
                                    OnClick="SearchCustom_Pay" Width="70px" />
                            
                                <asp:Label ID="Label53" runat="server" ForeColor="Red" Text="*"></asp:Label>
                            
                            </td>
                            <td style="width: 20%" align="center">
                                <asp:Label ID="Label3" runat="server" Text="回款金额："></asp:Label>
                            </td>
                             
                            <td align="left">
                                <asp:TextBox runat="server" ID="TextBox2" onkeyup="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{4,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{4})[0-9]*/, '$1');" 
                              onafterpaste="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{4,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{4})[0-9]*/, '$1');" ></asp:TextBox>
                                <asp:Label ID="Label52" runat="server" ForeColor="Red" Text="*"></asp:Label>
                            </td>
                           
                        </tr>
                        <tr>
                              <td align="center">
                                <asp:Label ID="Label4" runat="server" Text="备注：<br/>（200字内）"></asp:Label>
                            </td>
                           <td colspan="3">
                                <asp:TextBox ID="TextBox4" runat="server" Height="80px" MaxLength="200"
                                    onkeyup="this.value = this.value.slice(0, 200)" TextMode="MultiLine"
                                    Width="99%"></asp:TextBox>
                            </td>
                             
                        </tr>
                          <tr>
                            <td colspan="2"  align="center">
                                <asp:Button ID="Button1" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    OnClick="ConfirmNewPay" Width="70px" />
                            </td>
                             <td colspan="2"  align="center">
                                <asp:Button ID="Button2" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="CloseNewPay" Width="70px" />
                            </td>
                        </tr>
                      
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
     <asp:UpdatePanel ID="UpdatePanel_SearchCus" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1_SearchCus" runat="server" Visible="false">
                <asp:Label ID="label6" runat="server" Visible="False"></asp:Label>
                <fieldset>
                    <legend>客户检索条件</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 20%" align="center">
                                <asp:Label ID="Label12" runat="server" Text="客户名称："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox6"></asp:TextBox>
                            </td>
                            <td style="width:30%"  align="right">
                                <asp:Button ID="Button22" runat="server" Text="检索" CssClass="Button02" Height="24px"
                                    OnClick="SearchCustomer" Width="70px" />
                            </td>
                              <td style="width:25%"  align="center">
                               <asp:Button ID="Button23" runat="server" Text="取消" CssClass="Button02" Height="24px"
                                    OnClick="CloseSearchCustomer" Width="70px" />
                            </td>
                        </tr>
                     
                    
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
      <asp:UpdatePanel ID="UpdatePanel_Custom" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1_Custom" runat="server" Visible="false">
                <asp:Label ID="label41" runat="server" Visible="false"></asp:Label>
                <fieldset>
                    <legend>客户表</legend>
                    <asp:GridView ID="Gridview2" runat="server" AutoGenerateColumns="False"
                        CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False" 
                        PageSize="10" AllowPaging="True" AllowSorting="True" 
                        DataKeyNames="CRMCIF_ID" GridLines="None"
                        Width="100%" OnPageIndexChanging="Gridview2_PageIndexChanging" onrowcommand="Gridview2_RowCommand" 
                         >
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <%--    //隔行变色--%>
                        <Columns>
                            <asp:BoundField DataField="CRMCIF_ID" HeaderText="客户ID" ReadOnly="True" SortExpression="CRMCIF_ID"
                                Visible="false">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                             
                             <asp:BoundField DataField="CRMCIF_Name" HeaderText="客户名称" ReadOnly="True" SortExpression="CRMCIF_Name"
                                Visible="true">
                                <ItemStyle Width="45%"/>
                            </asp:BoundField>
                     <asp:BoundField DataField="CRMCIF_Address" HeaderText="地址" ReadOnly="True" SortExpression="CRMCIF_Address"
                                Visible="true">
                                <ItemStyle Width="45%"/>
                            </asp:BoundField>
                       
                         <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Check2" runat="server" CommandName="Check2" OnClientClick="false"
                                        CommandArgument='<%#Eval("CRMCIF_ID")%>'>选择</asp:LinkButton>
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
                        <EmptyDataTemplate>
                            <asp:Label ID="Label50" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                        <AlternatingRowStyle />
                    </asp:GridView>
               
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    </asp:Content>