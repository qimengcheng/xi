<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SalesPrice.aspx.cs" Inherits="SalesMgt_SalesPrice"  MasterPageFile="~/Other/MasterPage.master" Title="价格账期" %>
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
    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel5" runat="server" Visible="true">
                <asp:Label ID="label21" runat="server" Visible="False"></asp:Label>
                <fieldset>
                    <legend>检索条件</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 20%" align="center">
                                <asp:Label ID="Label22" runat="server" Text="客户名称："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox13"></asp:TextBox>
                            </td>
                            <td style="width: 20%" align="center">
                                <asp:Label ID="Label45" runat="server" Text="产品型号："></asp:Label>
                            </td>
                            <td style="width: 10%" align="left">
                                <asp:TextBox runat="server" ID="TextBox14"></asp:TextBox>
                            </td>
                            <td style="width: 20%" align="center">
                                <asp:Label ID="Label46" runat="server" Text="账期（天）："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox17" 
                                    onkeyup="this.value=this.value.replace(/[^\d]/g,'')"></asp:TextBox>
                            </td>
                            </tr>
                            <tr>
                            <td colspan="2"></td>
                            <td align="left">
                                <asp:Button ID="Button7" runat="server" Text="检索" CssClass="Button02" Height="24px"
                                    OnClick="SearchJiaZhang" Width="70px" />
                            </td>
                            <td></td>
                              <td colspan="2"  align="left">
                               <asp:Button ID="Button8" runat="server" Text="新建价格账期" CssClass="Button02" Height="24px"
                                    OnClick="NewJiaZhang" Width="90px" />
                            </td>
                        </tr>
                     
                    
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
       <%--投诉类别表--%>
    <asp:UpdatePanel ID="UpdatePanel_JiaZhang" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel__JiaZhang" runat="server" Visible="true">
                <asp:Label ID="label19" runat="server" Visible="false"></asp:Label>
                <fieldset>
                    <legend>价格账期表</legend>
                    <asp:GridView ID="Gridview_JiaZhang" runat="server" AutoGenerateColumns="False"
                        CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"  
                        PageSize="10" AllowPaging="True" AllowSorting="True" 
                        DataKeyNames="CRMCPM_ID" GridLines="None"
                        Width="100%" OnPageIndexChanging="Gridview_JiaZhang_PageIndexChanging" 
                        OnRowCommand="Gridview_JiaZhang_RowCommand" OnDataBound="Gridview_JiaZhang_DataBound1" 
                        >
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <%--    //隔行变色--%>
                        <Columns>
                            <asp:BoundField DataField="CRMCPM_ID" HeaderText="价格账期ID" ReadOnly="True" SortExpression="CRMCPM_ID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCIF_Name" HeaderText="客户名称" ReadOnly="false" SortExpression="CRMCIF_Name"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCIF_Address" HeaderText="客户地址" ReadOnly="false" SortExpression="CRMCIF_Address">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="PT_Name" HeaderText="产品名称" ReadOnly="True" SortExpression="PT_Name"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="PT_Note" HeaderText="产品备注" ReadOnly="True" SortExpression="PT_Note"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCPM_P" HeaderText="单价" ReadOnly="True" SortExpression="CRMCPM_P"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCPM_PaymentDay" HeaderText="账期" ReadOnly="True" SortExpression="CRMCPM_PaymentDay"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCPM_MakeTime" HeaderText="制定时间" SortExpression="CRMCPM_MakeTime"   DataFormatString="{0:yyyy-MM-dd}">
                                <ItemStyle />
                            </asp:BoundField>
                             <asp:BoundField DataField="CRMCPM_MakeMan" HeaderText="制定人" ReadOnly="True" SortExpression="CRMCPM_MakeMan"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Apply1" runat="server" CommandName="Apply1" OnClientClick="false"
                                        CommandArgument='<%#Eval("CRMCPM_ID")%>'>修改价格</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete1" runat="server" CommandName="Delete1" OnClientClick="return confirm('您确认删除吗?')"
                                        CommandArgument='<%#Eval("CRMCPM_ID")%>'>删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                                <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="ChangeHistory" runat="server" CommandName="ChangeHistory" 
                                        CommandArgument='<%#Eval("CRMCPM_ID")%>'>查看修改记录</asp:LinkButton>
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
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
     <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel2" runat="server" Visible="false">
                <asp:Label ID="label9" runat="server" Visible="false"></asp:Label>
                  
                <fieldset>
                    <legend>价格账期修改历史记录表</legend>
                    <table style="width:100%">
                   <tr>
                       <td align="right"><asp:Button ID="Button3" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="CloseHistory" Width="70px" /></td>
                   </tr>
               </table>
                    <asp:GridView ID="Gridview1" runat="server" AutoGenerateColumns="False"
                        CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"  
                        PageSize="10" AllowPaging="True" AllowSorting="True" 
                        DataKeyNames="SMPCH_ID" GridLines="None"
                        Width="100%" OnPageIndexChanging="Gridview1_PageIndexChanging" OnDataBound="Gridview1_DataBound1" 
                       >
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <%--    //隔行变色--%>
                        <Columns>
                            <asp:BoundField DataField="SMPCH_ID" HeaderText="价格账期ID" ReadOnly="True" SortExpression="SMPCH_ID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMPCH_Model" HeaderText="修改方式" ReadOnly="false" SortExpression="SMPCH_Model"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMPCH_Money" HeaderText="改后价格" ReadOnly="false" SortExpression="SMPCH_Money">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMPCH_Day" HeaderText="改后账期" ReadOnly="True" SortExpression="SMPCH_Day"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMPCH_Man" HeaderText="修改人" ReadOnly="True" SortExpression="SMPCH_Man"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                          
                            <asp:BoundField DataField="SMPCH_Time" HeaderText="修改时间" SortExpression="SMPCH_Time"   DataFormatString="{0:yyyy-MM-dd}">
                                <ItemStyle />
                            </asp:BoundField>
                                  <asp:BoundField DataField="SMPCH_Reason" HeaderText="修改原因" SortExpression="SMPCH_Reason"  >
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
                            <td style="width:100%" align="center">   <asp:Button ID="Button16" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="CloseHistory" Width="70px" /></td>
                           </tr></table>
                        </PagerTemplate>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label50" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                        <AlternatingRowStyle />
                    </asp:GridView>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
      <%-- 新建客诉主表--%>
    <asp:UpdatePanel ID="UpdatePanel_NewJiazhagn" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_NewJiazhagn" runat="server" Visible="false" 
                style="margin-bottom: 0px">
                <asp:Label ID="label35" runat="server" Visible="False"></asp:Label>  <asp:Label ID="label44" runat="server" Visible="False"></asp:Label>
                <fieldset>
                    <legend>新建价格账期</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label36" runat="server" Text="客户名称："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox16" Enabled="false"></asp:TextBox>                                
                                <asp:Button ID="Button18" runat="server" 
                                Text="选择…" CssClass="Button02" Height="20px"
                                    OnClick="SearchCustom1" Width="50px" />
                            
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label1" runat="server" Text="产品名称："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox1" Enabled="false"></asp:TextBox>                                
                                <asp:Button ID="Button1" runat="server" 
                                    Text="选择…" CssClass="Button02" Height="20px"
                                    OnClick="SearchPT" Width="50px" />
                            
                            </td>
                           
                        </tr>
                        <tr>
                              <td style="width: 10%" align="center">
                                <asp:Label ID="Label39" runat="server" Text="账期(天)："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox20" onkeyup="this.value=this.value.replace(/[^\d]/g,'')"></asp:TextBox>
                            </td>
                              <td style="width: 10%" align="center">
                                <asp:Label ID="Label2" runat="server" Text="价格："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox2" onkeyup="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{4,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{4})[0-9]*/, '$1');" 
                              onafterpaste="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{4,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{4})[0-9]*/, '$1');" ></asp:TextBox>
                            </td>
                        </tr>
                          <tr>
                            <td colspan="2"  align="center">
                                <asp:Button ID="Button16" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    OnClick="ConfirmNewJiaZhang" Width="70px" />
                            </td>
                             <td colspan="2"  align="center">
                                <asp:Button ID="Button17" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="CloseNewJiaZhang" Width="70px" />
                            </td>
                        </tr>
                      
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
       <%--投诉类别表--%>
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel4" runat="server" Visible="false">
                <asp:Label ID="label53" runat="server" Visible="False"></asp:Label>
                <fieldset>
                    <legend>价格账期修改申请检索条件</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 20%" align="center">
                                <asp:Label ID="Label54" runat="server" Text="客户名称："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox28"></asp:TextBox>
                            </td>
                            <td style="width: 20%" align="center">
                                <asp:Label ID="Label55" runat="server" Text="产品型号："></asp:Label>
                            </td>
                            <td style="width: 10%" align="left">
                                <asp:TextBox runat="server" ID="TextBox29"></asp:TextBox>
                            </td>
                      
                            </tr>
                        <tr>

                                  <td style="width: 20%" align="center">
                                申请人：</td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox30"></asp:TextBox>
                            </td>  <td style="width: 20%" align="center">
                                申请单状态：</td>
                            <td style="width: 15%" align="left">
                                <asp:DropDownList ID="DropDownList1" runat="server">
                                    <asp:ListItem>选择状态</asp:ListItem>
                                    <asp:ListItem>已提交</asp:ListItem>
                                    <asp:ListItem>审核通过</asp:ListItem>
                                    <asp:ListItem>审核驳回</asp:ListItem>
                                    <asp:ListItem>待审批</asp:ListItem>
                                    <asp:ListItem>审批通过</asp:ListItem>
                                    <asp:ListItem>审批驳回</asp:ListItem>
                                </asp:DropDownList>
                           
                            </td>

                        </tr>
                            <tr>
                            <td colspan="2"  align="center">
                                <asp:Button ID="Button25" runat="server" Text="检索" CssClass="Button02" Height="24px"
                                    OnClick="SearchApply" Width="70px" />
                            </td>
                              <td colspan="2"  align="center">
                               <asp:Button ID="Button26" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="CloseApply" Width="70px" />
                            </td>
                        </tr>
                     
                    
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdatePanel_Apply" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Apply" runat="server" Visible="false">
                <asp:Label ID="label24" runat="server" Visible="false"></asp:Label>
             
                               
                            
                <fieldset>
                    <legend>价格账期修改申请</legend>
                    <asp:GridView ID="Gridview_Apply" runat="server" AutoGenerateColumns="False"
                        CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"  
                        PageSize="10" AllowPaging="True" AllowSorting="True" 
                        DataKeyNames="CRMCPCA_ID" GridLines="None"
                        Width="100%" OnPageIndexChanging="Gridview_Apply_PageIndexChanging" 
                        OnRowCommand="Gridview_Apply_RowCommand" ondatabound="Gridview_Apply_DataBound" 
                        onrowdatabound="Gridview_Apply_RowDataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <%--    //隔行变色--%>
                        <Columns>
                            <asp:BoundField DataField="CRMCPCA_ID" HeaderText="售后类别ID" ReadOnly="True" SortExpression="CRMCPCA_ID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="CRMCIF_Name" HeaderText="客户名称" ReadOnly="false" SortExpression="CRMCIF_Name"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="PT_Name" HeaderText="产品型号" ReadOnly="false" SortExpression="PT_Name">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCPCA_ChangePrice" HeaderText="预修改价格" ReadOnly="false" SortExpression="CRMCPCA_ChangePrice"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCPCA_ChangePaymentTime" HeaderText="预修改账期" ReadOnly="false" SortExpression="CRMCPCA_ChangePaymentTime">
                                <ItemStyle />
                            </asp:BoundField>
                             <asp:BoundField DataField="CRMCPCA_ApplyChangeReson" HeaderText="申请原因" ReadOnly="false" SortExpression="CRMCPCA_ApplyChangeReson">
                                <ItemStyle />
                            </asp:BoundField>
                             <asp:BoundField DataField="CRMCPCA_State" HeaderText="状态" ReadOnly="false" SortExpression="CRMCPCA_State">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCPCA_ApplyManName" HeaderText="申请人" ReadOnly="True" SortExpression="CRMCPCA_ApplyManName"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCPCA_ApplyChangeTime" HeaderText="申请时间" SortExpression="CRMCPCA_ApplyChangeTime"   DataFormatString="{0:yyyy-MM-dd}">
                                <ItemStyle />
                            </asp:BoundField>
                             <asp:BoundField DataField="CRMCPCA_CheckMan" HeaderText="审核人" ReadOnly="True" SortExpression="CRMCPCA_CheckMan"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                               <asp:BoundField DataField="CRMCPCA_CheckOpinion" HeaderText="审核意见" ReadOnly="True" SortExpression="CRMCPCA_CheckOpinion"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                          <asp:BoundField DataField="CRMCPCA_CheckTime" HeaderText="审核时间" SortExpression="CRMCPCA_CheckTime"   DataFormatString="{0:yyyy-MM-dd}">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCPCA_CMan" HeaderText="审批人" ReadOnly="True" SortExpression="CRMCPCA_CMan"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                               <asp:BoundField DataField="CRMCPCA_COpinion" HeaderText="审批意见" ReadOnly="True" SortExpression="CRMCPCA_COpinion"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                               <asp:BoundField DataField="CRMCPCA_CTime" HeaderText="审批时间" SortExpression="CRMCPCA_CTime"   DataFormatString="{0:yyyy-MM-dd}">
                                <ItemStyle />
                            </asp:BoundField>
                           
                          
                              <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="check2" runat="server" CommandName="Check2" OnClientClick="false"
                                        CommandArgument='<%#Eval("CRMCPCA_ID")%>'>审核</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="shenpi" runat="server" CommandName="shenpi" OnClientClick="false"
                                        CommandArgument='<%#Eval("CRMCPCA_ID")%>'>审批</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Edit2" runat="server" CommandName="Edit2" OnClientClick="false"
                                        CommandArgument='<%#Eval("CRMCPCA_ID")%>'>编辑</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete2" runat="server" CommandName="Delete2" OnClientClick="return confirm('您确认删除此条目吗?')"
                                        CommandArgument='<%#Eval("CRMCPCA_ID")%>'>删除</asp:LinkButton>
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
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
      <%-- 审核--%>
          <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" Visible="false">
                <fieldset>
                <asp:Label ID="Label3" runat="server"  Visible="false"></asp:Label>
                    <legend><asp:Label ID="Label7" runat="server"  Visible="true"></asp:Label> <asp:Label ID="label8" runat="server" Visible="true"></asp:Label>价格账期</legend>
                    <table style="width: 100%;">
                         <tr>
                              <td style="width: 20%" align="center">
                                <asp:Label ID="Label4" runat="server" Text="预修改账期(天)："></asp:Label>
                            </td>
                            <td style="width: 25%" align="left">
                                <asp:TextBox runat="server" ID="TextBox3" onkeyup="this.value=this.value.replace(/[^\d]/g,'')"></asp:TextBox>
                            </td>
                              <td style="width: 20%" align="center">
                                <asp:Label ID="Label5" runat="server" Text="预修改价格："></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="TextBox4" onkeyup="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{4,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{4})[0-9]*/, '$1');" 
                              onafterpaste="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{4,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{4})[0-9]*/, '$1');"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                          
                            <td>
                                修改原因：<br/>（200字内）
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="TextBox5" runat="server" Height="80px" MaxLength="200"
                                    onblur="javascript:leave('LB1000');" onfocus="annotation('LB1000');" TextMode="MultiLine"
                                    Width="99%"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 33%; text-align: right">
                                <asp:Button ID="Button2" runat="server" CssClass="Button02" OnClick="NewApplyOK" Height="24px"
                                    Text="提交" Width="80px" />
                                <%--    OnClientClick="$find('gvEdit').hide();"--%>
                            </td>
                            <td style="width: 34%; text-align: center">
                               
                            </td>
                            <td style="width: 33%; text-align: left">
                                <asp:Button ID="Button4" runat="server" CssClass="Button02" OnClick="NewApplyCanel" Height="24px"
                                    Text="关闭" Width="80px" />
                            </td>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
        <%-- 检索--%>
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
                               <asp:Button ID="Button23" runat="server" Text="关闭" CssClass="Button02" Height="24px"
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
       <asp:UpdatePanel ID="UpdatePanel10" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel11" runat="server" Visible="false">
                <asp:Label ID="label15" runat="server" Visible="False"></asp:Label>
                <fieldset>
                    <legend>检索条件</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 20%" align="center">
                                <asp:Label ID="Label18" runat="server" Text="产品名称："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox12"></asp:TextBox>
                            </td>
                             
                            <td style="width:30%"  align="center">
                                <asp:Button ID="Button27" runat="server" Text="检索" CssClass="Button02" Height="24px"
                                    OnClick="SearchPT" Width="70px" />
                            </td>
                              <td style="width:25%"  align="center">
                               <asp:Button ID="Button28" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="ClosePT" Width="70px" />
                            </td>
                        </tr>
                     
                    
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--调拨主表--%>
    <asp:UpdatePanel ID="UpdatePanel_PT" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_PT" runat="server" Visible="false">
                <asp:Label ID="label16" runat="server" Visible="false"></asp:Label>
                <fieldset>
                    <legend>产品型号表</legend>
                    <asp:GridView ID="Gridview_PT" runat="server" AutoGenerateColumns="False"
                        CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"  
                        PageSize="10" AllowPaging="True" AllowSorting="True" DataKeyNames="PT_ID" GridLines="None"
                        Width="100%" OnPageIndexChanging="Gridview_PT_PageIndexChanging" 
                        OnRowCommand="Gridview_PT_RowCommand" 
                       >
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <%--    //隔行变色--%>
                        <Columns>
                            <asp:BoundField DataField="PT_ID" HeaderText="产品id" ReadOnly="True" SortExpression="PT_ID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            
                            <asp:BoundField DataField="PT_Name" HeaderText="产品型号" ReadOnly="True" SortExpression="PT_Name"
                                Visible="true">
                                <ItemStyle Width="30%"/>
                            </asp:BoundField>    
                           
                                  <asp:BoundField DataField="PT_Note" HeaderText="产品备注" ReadOnly="True" SortExpression="PT_Note"
                                Visible="true">
                                <ItemStyle Width="30%"/>
                            </asp:BoundField>    
                            <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Check2" runat="server" CommandName="Check2" OnClientClick="false"
                                        CommandArgument='<%#Eval("PT_ID")%>'>选择</asp:LinkButton>
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

     <%-- 审核--%>
     <asp:UpdatePanel ID="UpdatePanel_ADDCheck" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_ADDCheck" runat="server" Visible="false">
                <fieldset>
                <asp:Label ID="Label33" runat="server"  Visible="false"></asp:Label>
                       <asp:Label ID="Label11" runat="server"  Visible="false"></asp:Label>
                    <legend>审核栏</legend>
                    <table style="width: 100%;">
                        <tr>
                         
                            <td style="width: 20%">
                                审核人:
                            </td>
                            <td style="width: 25%">
                                <asp:TextBox ID="TextBox_AddMan" runat="server"  ReadOnly="true" Enabled="False"></asp:TextBox>
                            </td>
                            <td style="width: 20%" align="right">
                                审核时间:
                            </td>
                            <td >
                                <asp:TextBox ID="TextBox_Addtime" runat="server" ReadOnly="true" DataFormatString="{0:yyyy-MM-dd HH:mm}"
                                    Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                          
                            <td>
                                审核意见:<br/>（200字内）
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="TextBox_AddOpinion" runat="server" Height="80px" MaxLength="200"
                                    onblur="javascript:leave('LB1000');" onfocus="annotation('LB1000');" TextMode="MultiLine"
                                    Width="99%"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%; height: 35px;">
                        <tr>
                            <td style="width: 33%; text-align: right">
                                <asp:Button ID="Button19" runat="server" CssClass="Button02" OnClick="Check_OK"
                                    Text="通过" Width="80px" />
                                <%--    OnClientClick="$find('gvEdit').hide();"--%>
                            </td>
                            <td style="width: 34%; text-align: center">
                                <asp:Button ID="Button20" runat="server" CssClass="Button02" OnClick="Check_NotOK"
                                    Text="驳回" Width="80px" />
                            </td>
                            <td style="width: 33%; text-align: left">
                                <asp:Button ID="Button21" runat="server" CssClass="Button02" OnClick="Check_Canel"
                                    Text="关闭" Width="80px" />
                            </td>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
     <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel3" runat="server" Visible="false">
                <fieldset>
                <asp:Label ID="Label10" runat="server"  Visible="false"></asp:Label>
                       <asp:Label ID="Label13" runat="server"  Visible="false"></asp:Label>
                    <legend>审批栏</legend>
                    <table style="width: 100%;">
                        <tr>
                         
                            <td style="width: 20%">
                                审批人:
                            </td>
                            <td style="width: 25%">
                                <asp:TextBox ID="TextBox7" runat="server"  ReadOnly="true" Enabled="False"></asp:TextBox>
                            </td>
                            <td style="width: 20%" align="right">
                                审批时间:
                            </td>
                            <td >
                                <asp:TextBox ID="TextBox8" runat="server" ReadOnly="true" DataFormatString="{0:yyyy-MM-dd HH:mm}"
                                    Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                          
                            <td>
                                审批意见:<br/>（200字内）
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="TextBox9" runat="server" Height="80px" MaxLength="200"
                                    onblur="javascript:leave('LB1000');" onfocus="annotation('LB1000');" TextMode="MultiLine"
                                    Width="99%"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%; height: 35px;">
                        <tr>
                            <td style="width: 33%; text-align: right">
                                <asp:Button ID="Button5" runat="server" CssClass="Button02" OnClick="Check_OK1"
                                    Text="通过" Width="80px" />
                                <%--    OnClientClick="$find('gvEdit').hide();"--%>
                            </td>
                            <td style="width: 34%; text-align: center">
                                <asp:Button ID="Button6" runat="server" CssClass="Button02" OnClick="Check_NotOK1"
                                    Text="驳回" Width="80px" />
                            </td>
                            <td style="width: 33%; text-align: left">
                                <asp:Button ID="Button9" runat="server" CssClass="Button02" OnClick="Check_Canel1"
                                    Text="关闭" Width="80px" />
                            </td>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    </asp:Content>