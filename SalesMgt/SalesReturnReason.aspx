<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SalesReturnReason.aspx.cs" Inherits="SalesMgt_SalesReturnReason"  MasterPageFile="~/Other/MasterPage.master" Title="销售退货管理" %>
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
            <asp:Panel ID="Panel_OrderDeliverSearch" runat="server" Visible="true">
                <asp:Label ID="label_OrderDeliverSearch" runat="server" Visible="False"></asp:Label>
                <fieldset>
                    <legend>退货原因检索条件</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label" runat="server" Text="退货原因名称："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox1"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                     <asp:Button ID="Button1" runat="server" Text="检索" CssClass="Button02" Height="24px"
                                    OnClick="SearchReason" Width="70px" />
                            </td>
                            <td style="width: 15%" align="left">
                                     <asp:Button ID="Button4" runat="server" Text="新增" CssClass="Button02" Height="24px"
                                    OnClick="NewReason" Width="70px" />
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
            <asp:Panel ID="Panel_OrderDeliver" runat="server" Visible="true">
                <asp:Label ID="label11" runat="server" Visible="false"></asp:Label>
                <fieldset>
                    <legend>退货原因表</legend>
                    <asp:GridView ID="Gridview_OrderDeliver" runat="server" AutoGenerateColumns="False"
                        CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"  
                        PageSize="10" AllowPaging="True" AllowSorting="True" DataKeyNames="SMRR_ID,SMRR_Name,SMRR_Note" GridLines="None"
                        Width="100%" OnPageIndexChanging="Gridview_OrderDeliver_PageIndexChanging" OnRowCommand="Gridview_OrderDeliver_RowCommand" OnRowDataBound="Gridview_OrderDeliver_RowDataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <%--    //隔行变色--%>
                        <Columns>
                            <asp:BoundField DataField="SMRR_ID" HeaderText="发货单ID" ReadOnly="True" SortExpression="SMRR_ID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMRR_Name" HeaderText="退货原因名称" ReadOnly="True" SortExpression="SMRR_Name"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMRR_Note" HeaderText="详细描述" ReadOnly="True" SortExpression="SMRR_Note">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Edit1" runat="server" CommandName="Edit1" 
                                        CommandArgument='<%#Eval("SMRR_ID")%>'>修改</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete1" runat="server" CommandName="Delete1" OnClientClick="return confirm('你确认删除吗？')"
                                        CommandArgument='<%#Eval("SMRR_ID")%>'>删除</asp:LinkButton>
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
                            <td style="width: 20%" align="center">
                                <asp:Label ID="Label6" runat="server" Text="退货原因名称（50字内）："></asp:Label>
                            </td>
                            <td style="width: 70%" align="left">
                                <asp:TextBox runat="server" ID="TextBox6" MaxLength="50" Width="544px"></asp:TextBox> <asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                           <td></td>
                           
                        </tr>
                    
                        <tr>
                            <td  align="center">
                                <asp:Label ID="Label7" runat="server" Text="退换货原因(200字内)："></asp:Label>
                            </td>
                            <td  colspan="2" align="left">
                                <asp:TextBox runat="server" ID="TextBox7" Enabled="true"  Width="90%" 
                                    Height="37px" MaxLength="200" TextMode="MultiLine" onkeyup="this.value = this.value.slice(0, 200)"></asp:TextBox><asp:Label ID="Label2" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        </table>
                        <table width="100%">
                        <tr>
                            <td style="width:50%"  align="center">
                                <asp:Button ID="Button2" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    OnClick="Tijiao" Width="70px" />
                              <td style="width:50%"  align="center">
                             <asp:Button ID="Button3" runat="server" CssClass="Button02" Height="24px" 
                        OnClick="CloseTijiao" Text="关闭" Width="70px" /></td>
                               
                            </td>
                        </tr>
                    </table>
                  
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
  
    </asp:Content>