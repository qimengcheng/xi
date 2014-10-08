<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SalesReturn.aspx.cs" Inherits="SalesMgt_SalesReturn"  MasterPageFile="~/Other/MasterPage.master" Title="销售退货管理" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/JS/ShortM.js" />
        </Scripts>--%>
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
    <asp:UpdatePanel ID="UpdatePanel_OrderDeliverSearch" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_OrderDeliverSearch" runat="server" Visible="false">
                <asp:Label ID="label_OrderDeliverSearch" runat="server" Visible="False"></asp:Label>
                <fieldset>
                    <legend>发货单检索条件</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label" runat="server" Text="产品型号："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox1"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label5" runat="server" Text="出库单号："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox2"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label2" runat="server" Text="销售订单号："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox3"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                        <td align="center">  <asp:Label ID="Label4" runat="server" Text="客户名称："></asp:Label>
                        </td>
                        <td align="left"> <asp:TextBox runat="server" ID="TextBox4"></asp:TextBox></td>
                            <td style="width: 10%" align="center">
                              <asp:Label ID="Label1" runat="server" Text="发货时间："></asp:Label>
                            </td>
                            <td align="left" >
                              
                                <asp:TextBox runat="server" ID="TextBox5" onfocus="new WdatePicker(this,'%Y-%M-%D' ,true)"
                                    DataFormatString="{0:yyyy-MM-dd}"  ></asp:TextBox>
                               
                            </td>
                           
                        </tr>
                        <tr>
                            <td colspan="6"  align="center">
                                <asp:Button ID="Button1" runat="server" Text="检索" CssClass="Button02" Height="24px"
                                    OnClick="SearchOrderDeliver" Width="70px" />
                            </td>
                           
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--调拨主表--%>
    <asp:UpdatePanel ID="UpdatePanel_OrderDeliver" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_OrderDeliver" runat="server" Visible="false">
                <asp:Label ID="label11" runat="server" Visible="false"></asp:Label>
                <fieldset>
                    <legend>发货单</legend>
                    <asp:GridView ID="Gridview_OrderDeliver" runat="server" AutoGenerateColumns="False"
                        CssClass="GridViewStyle" CellPadding="0" 
                        PageSize="10" AllowPaging="True"  DataKeyNames="SMOD_ID" GridLines="None"
                        Width="100%" OnPageIndexChanging="Gridview_OrderDeliver_PageIndexChanging" OnRowCommand="Gridview_OrderDeliver_RowCommand">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <%--    //隔行变色--%>
                        <Columns>
                            <asp:BoundField DataField="SMOD_ID" HeaderText="发货单ID" ReadOnly="True" 
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCIF_Name" HeaderText="客户名称" ReadOnly="True" 
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMSO_ComOrderNum" HeaderText="订单号" ReadOnly="True">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="PT_Name" HeaderText="产品型号" ReadOnly="True"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMSOD_Mount" HeaderText="订单数量" >
                                <ItemStyle />
                            </asp:BoundField>
                              <asp:BoundField DataField="SMSOD_UnitPrice" HeaderText="单价">
                                <ItemStyle />
                            </asp:BoundField>
                                <asp:BoundField DataField="SMOD_CorrectReceive" HeaderText="正确收货">
                                <ItemStyle />
                            </asp:BoundField>
                                <asp:BoundField DataField="SMOD_SalesReturn" HeaderText="退货" >
                                <ItemStyle />
                            </asp:BoundField>
                                <asp:BoundField DataField="SMOD_Exchange" HeaderText="换货" >
                                <ItemStyle />
                            </asp:BoundField>
                             <asp:BoundField DataField="IMOHM_OutHouseNum" HeaderText="出库单号" ReadOnly="True" 
                               >
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMOHM_State" HeaderText="出库单状态" ReadOnly="True" 
                               >
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMOHD_Num" HeaderText="出库数量" >
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMOHM_TakeAwayMan" HeaderText="出库确认人" ReadOnly="True" >
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMOHM_TakeAwayMakeSureTime" HeaderText="确认日期"   DataFormatString="{0:yyyy-MM-dd}">
                                <ItemStyle />
                            </asp:BoundField>

                            <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Confirm1" runat="server" CommandName="Confirm1" OnClientClick="return confirm('您确认正确收货吗?')"
                                        CommandArgument='<%#Eval("SMOD_ID")%>'>确认收货</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Tui1" runat="server" CommandName="Tui1" OnClientClick="false"
                                        CommandArgument='<%#Eval("SMOD_ID")%>'>退货</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Huan1" runat="server" CommandName="Huan1" OnClientClick="false"
                                        CommandArgument='<%#Eval("SMOD_ID")%>'>换货</asp:LinkButton>
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
    <asp:UpdatePanel ID="UpdatePanel_Tuihuanhuo" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" Visible="false">
                <asp:Label ID="label3" runat="server" Visible="False"></asp:Label>
                <fieldset>
                    <legend><asp:Label ID="label12" runat="server" Visible="true"></asp:Label><asp:Label ID="label18" runat="server" Visible="true"></asp:Label></legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label6" runat="server" Text="退回数量："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox6" onkeyup="this.value=this.value.replace(/[^\d]/g,'')"></asp:TextBox> <asp:Label ID="Label21" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label19" runat="server" Text="退货原因："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList><asp:Label ID="Label22" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                    
                        <tr>
                            <td  align="center">
                                <asp:Label ID="Label7" runat="server" Text="具体描述(200字内)："></asp:Label>
                            </td>
                            <td  colspan="3" align="left">
                                <asp:TextBox runat="server" ID="TextBox7" Enabled="true"  Width="90%" 
                                    Height="37px" MaxLength="200" TextMode="MultiLine" onkeyup="this.value = this.value.slice(0, 200)"></asp:TextBox><asp:Label ID="Label23" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        </table>
                        <table width="100%">
                        <tr>
                            <td style="width:50%"  align="center">
                                <asp:Button ID="Button2" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    OnClick="ComfirmTuihuanhuo" Width="70px" />
                            </td>
                              <td style="width:50%"  align="center">
                                <asp:Button ID="Button3" runat="server" CssClass="Button02" Height="24px" 
                        OnClick="CloseTuihuanhuo" Text="关闭" Width="70px" />
                            </td>
                        </tr>
                    </table>
                  
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
         <%-- 检索--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel2" runat="server" Visible="false">
                <asp:Label ID="label8" runat="server" Visible="False"></asp:Label>
                <fieldset>
                    <legend>退货单检索条件</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label9" runat="server" Text="产品型号："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox8"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label10" runat="server" Text="退货单号："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox9"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label13" runat="server" Text="客户名称："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox10"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                        <td align="center">  <asp:Label ID="Label14" runat="server" Text="退货时间从"></asp:Label>
                        </td>
                        <td align="left" colspan="3">
                                
                                <asp:TextBox runat="server" ID="TextBox11" onfocus="new WdatePicker(this,'%Y-%M-%D' ,true)"
                                    DataFormatString="{0:yyyy-MM-dd}"  Width="42%"></asp:TextBox>
                                到
                                <asp:TextBox runat="server" ID="TextBox12" onfocus="new WdatePicker(this,'%Y-%M-%D' ,true)"
                                    DataFormatString="{0:yyyy-MM-dd}"  Width="42%"></asp:TextBox>
                            </td>
                             <td style="width: 10%" align="center">
                                <asp:Label ID="Label15" runat="server" Text="退换货方式："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:DropDownList ID="DropDownList1" runat="server">
                                    <asp:ListItem>选择退换货方式</asp:ListItem>
                                    <asp:ListItem>退货</asp:ListItem>
                                    <asp:ListItem>换货</asp:ListItem>
                                </asp:DropDownList> 
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6"  align="center">
                                <asp:Button ID="Button4" runat="server" Text="检索" CssClass="Button02" Height="24px"
                                    OnClick="SearchReturn" Width="70px" />
                            </td>
                           
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--调拨主表--%>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel3" runat="server" Visible="false">
                <asp:Label ID="label16" runat="server" Visible="false"></asp:Label>
                <fieldset>
                    <legend>退货单</legend>
                    <asp:GridView ID="Gridview_Return" runat="server" AutoGenerateColumns="False"
                        CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"  
                        PageSize="10" AllowPaging="True" AllowSorting="True" DataKeyNames="SMRC_ID" GridLines="None"
                        Width="100%" OnPageIndexChanging="Gridview_Return_PageIndexChanging" 
                        OnRowCommand="Gridview_Return_RowCommand" 
                        ondatabound="Gridview_Return_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <%--    //隔行变色--%>
                        <Columns>
                            <asp:BoundField DataField="SMRC_ID" HeaderText="退货单ID" ReadOnly="True" SortExpression="SMRC_ID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                              <asp:BoundField DataField="SMRC_ReturnOrderNum" HeaderText="退货单号" ReadOnly="True" SortExpression="SMRC_ReturnOrderNum"
                                Visible="true">
                                <ItemStyle />
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
                               <asp:BoundField DataField="SMRR_Name" HeaderText="退货原因" ReadOnly="True" SortExpression="SMRR_Name"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                                <asp:BoundField DataField="SMRC_ReturnReason" HeaderText="退货详情" ReadOnly="True" SortExpression="SMRC_ReturnReason"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                         
                            <asp:BoundField DataField="SMOD_Num" HeaderText="发货数量" SortExpression="SMOD_Num">
                                <ItemStyle />
                            </asp:BoundField>
                             <asp:BoundField DataField="SMRC_ReturnNum" HeaderText="退货数量" ReadOnly="True" 
                                SortExpression="SMRC_ReturnNum">
                                <ItemStyle />
                            </asp:BoundField>
                              <asp:BoundField DataField="SMRC_MakeMan" HeaderText="制定人" ReadOnly="True" 
                                SortExpression="SMRC_MakeMan">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMRC_MakeTime" HeaderText="制定日期" SortExpression="SMRC_MakeTime"   DataFormatString="{0:yyyy-MM-dd}">
                                <ItemStyle />
                            </asp:BoundField>
                                <asp:BoundField DataField="SMRC_ProcessResultMan" HeaderText="处理人" ReadOnly="True" 
                                SortExpression="SMRC_ProcessResultMan">
                                <ItemStyle />
                            </asp:BoundField>
                               <asp:BoundField DataField="SMRC_ProcessResult" HeaderText="处理结果" ReadOnly="True" 
                                SortExpression="SMRC_ProcessResult">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMRC_ProcessResultTime" HeaderText="处理时间" SortExpression="SMRC_ProcessResultTime"   DataFormatString="{0:yyyy-MM-dd}">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Result1" runat="server" CommandName="Result1" OnClientClick="false"
                                        CommandArgument='<%#Eval("SMRC_ID")%>'>填写处理结果</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>  
                          
                              <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete1" runat="server" CommandName="Delete1" OnClientClick="return confirm('您确认删除该记录吗?')"
                                        CommandArgument='<%#Eval("SMRC_ID")%>'>删除</asp:LinkButton>
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
      <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel4" runat="server" Visible="false">
                <asp:Label ID="label17" runat="server" Visible="False"></asp:Label>
                <fieldset>
                    <legend>处理结果填写</legend>
                    <table style="width: 100%;">
                    
                        <tr>
                            <td style="width:20%"  align="center">
                                <asp:Label ID="Label20" runat="server" Text="处理结果：<br/>(200字内)"></asp:Label>
                            </td>
                            <td style="width:70%" align="left">
                                <asp:TextBox runat="server" ID="TextBox14" Enabled="true"  Width="90%" 
                                    Height="37px" MaxLength="200" TextMode="MultiLine" onkeyup="this.value = this.value.slice(0, 200)"></asp:TextBox>
                            </td>
                        </tr>
                        </table>
                        <table width="100%">
                        <tr>
                            <td style="width:50%"  align="center">
                                <asp:Button ID="Button5" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    OnClick="ComfirmChuli" Width="90px" />
                            </td>
                              <td style="width:50%"  align="center">
                                <asp:Button ID="Button6" runat="server" CssClass="Button02" Height="24px" 
                        OnClick="CloseChuli" Text="关闭" Width="90px" />
                            </td>
                        </tr>
                    </table>
                  
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    </asp:Content>