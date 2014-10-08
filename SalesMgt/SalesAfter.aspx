<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SalesAfter.aspx.cs" Inherits="SalesMgt_SalesAfter" MasterPageFile="~/Other/MasterPage.master" Title="销售退货管理" %>

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
    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel5" runat="server" Visible="false">
                <asp:Label ID="label21" runat="server" Visible="False"></asp:Label>
                <fieldset>
                    <legend>检索条件</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 20%" align="center">
                                <asp:Label ID="Label22" runat="server" Text="投诉类别名称："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox13"></asp:TextBox>
                            </td>
                            <td style="width: 30%" align="right">
                                <asp:Button ID="Button7" runat="server" Text="检索" CssClass="Button02" Height="24px"
                                    OnClick="SearchTousuSort" Width="70px" />
                            </td>
                            <td style="width: 25%" align="center">
                                <asp:Button ID="Button8" runat="server" Text="新建类别" CssClass="Button02" Height="24px"
                                    OnClick="NewTousuSort" Width="90px" />
                            </td>
                        </tr>


                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--投诉类别表--%>
    <asp:UpdatePanel ID="UpdatePanel_TousuSort" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_TousuSort" runat="server" Visible="false">
                <asp:Label ID="label19" runat="server" Visible="false"></asp:Label>
                <fieldset>
                    <legend>投诉类别表</legend>
                    <asp:GridView ID="Gridview_TousuSort" runat="server" AutoGenerateColumns="False"
                        CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"
                        PageSize="10" AllowPaging="True" AllowSorting="True" DataKeyNames="CRMCS_ID" GridLines="None"
                        Width="100%" OnPageIndexChanging="Gridview_TousuSort_PageIndexChanging" OnRowCommand="Gridview_TousuSort_RowCommand">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <%--    //隔行变色--%>
                        <Columns>
                            <asp:BoundField DataField="CRMCS_ID" HeaderText="投诉类别ID" ReadOnly="True" SortExpression="CRMCS_ID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCS_Name" HeaderText="类别名称" ReadOnly="false" SortExpression="CRMCS_Name"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCS_Detail" HeaderText="现象描述" ReadOnly="false" SortExpression="CRMCS_Detail">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCS_Man" HeaderText="制定人" ReadOnly="True" SortExpression="CRMCS_Man"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCS_Time" HeaderText="制定时间" SortExpression="CRMCS_Time" DataFormatString="{0:yyyy-MM-dd}">
                                <ItemStyle />
                            </asp:BoundField>

                            <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Edit1" runat="server" CommandName="Edit1" OnClientClick="false"
                                        CommandArgument='<%#Eval("CRMCS_ID")%>'>编辑</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete1" runat="server" CommandName="Delete1" OnClientClick="return confirm('您确认正确收货吗?')"
                                        CommandArgument='<%#Eval("CRMCS_ID")%>'>删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">第<asp:Label ID="lblPageIndex" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>' />
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
                                    <td style="width: 100%"></td>
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
    <%-- 新建投诉类别--%>
    <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel6" runat="server" Visible="false">
                <asp:Label ID="label1" runat="server" Visible="False"></asp:Label>
                <fieldset>
                    <legend>
                        <asp:Label ID="label17" runat="server" Visible="False"></asp:Label>投诉类别</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 15%" align="center">
                                <asp:Label ID="Label5" runat="server" Text="类别名称："></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="TextBox1"></asp:TextBox>
                            </td>

                        </tr>

                        <tr>
                            <td align="center">
                                <asp:Label ID="Label23" runat="server" Text="现象描述：<br/>(200字内)"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="TextBox2" Enabled="true" Width="90%"
                                    Height="37px" MaxLength="200" TextMode="MultiLine" onkeyup="this.value = this.value.slice(0, 200)"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <table width="100%">
                        <tr>
                            <td style="width: 50%" align="center">
                                <asp:Button ID="Button1" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    OnClick="ConfirmNewTousuSort" Width="70px" />
                            </td>
                            <td style="width: 50%" align="center">
                                <asp:Button ID="Button9" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="CloseTousuSort" Text="关闭" Width="70px" />
                            </td>
                        </tr>
                    </table>

                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%-- 检索--%>
    <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel7" runat="server" Visible="false">
                <asp:Label ID="label2" runat="server" Visible="False"></asp:Label>
                <fieldset>
                    <legend>检索条件</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 20%" align="center">
                                <asp:Label ID="Label4" runat="server" Text="售后类别名称："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox3"></asp:TextBox>
                            </td>
                            <td style="width: 30%" align="right">
                                <asp:Button ID="Button10" runat="server" Text="检索" CssClass="Button02" Height="24px"
                                    OnClick="SearchShouhouSort" Width="70px" />
                            </td>
                            <td style="width: 25%" align="center">
                                <asp:Button ID="Button11" runat="server" Text="新建类别" CssClass="Button02" Height="24px"
                                    OnClick="NewShouhouSort" Width="90px" />
                            </td>
                        </tr>


                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--投诉类别表--%>
    <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel8" runat="server" Visible="false">
                <asp:Label ID="label24" runat="server" Visible="false"></asp:Label>
                <fieldset>
                    <legend>售后类别表</legend>
                    <asp:GridView ID="Gridview1" runat="server" AutoGenerateColumns="False"
                        CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"
                        PageSize="10" AllowPaging="True" AllowSorting="True" DataKeyNames="CRMASS_ID" GridLines="None"
                        Width="100%" OnPageIndexChanging="Gridview_ShouhouSort_PageIndexChanging" OnRowCommand="Gridview_ShouhouSort_RowCommand">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <%--    //隔行变色--%>
                        <Columns>
                            <asp:BoundField DataField="CRMASS_ID" HeaderText="售后类别ID" ReadOnly="True" SortExpression="CRMASS_ID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMASS_Name" HeaderText="类别名称" ReadOnly="false" SortExpression="CRMASS_Name"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMASS_Detail" HeaderText="现象描述" ReadOnly="false" SortExpression="CRMASS_Detail">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMASS_Man" HeaderText="制定人" ReadOnly="True" SortExpression="CRMASS_Man"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMASS_Time" HeaderText="制定时间" SortExpression="CRMASS_Time" DataFormatString="{0:yyyy-MM-dd}">
                                <ItemStyle />
                            </asp:BoundField>

                            <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Edit2" runat="server" CommandName="Edit2" OnClientClick="false"
                                        CommandArgument='<%#Eval("CRMASS_ID")%>'>编辑</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete2" runat="server" CommandName="Delete2" OnClientClick="return confirm('您确认删除此条目吗?')"
                                        CommandArgument='<%#Eval("CRMASS_ID")%>'>删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">第<asp:Label ID="lblPageIndex" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>' />
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
                                    <td style="width: 100%"></td>
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
    <%-- 新建投诉类别--%>
    <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel9" runat="server" Visible="false">
                <asp:Label ID="label25" runat="server" Visible="False"></asp:Label>
                <fieldset>
                    <legend>
                        <asp:Label ID="label20" runat="server" Visible="true"></asp:Label>售后类别</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 15%" align="center">
                                <asp:Label ID="Label26" runat="server" Text="类别名称："></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="TextBox4"></asp:TextBox>
                            </td>

                        </tr>

                        <tr>
                            <td align="center">
                                <asp:Label ID="Label27" runat="server" Text="现象描述：<br/>(200字内)"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="TextBox5" Enabled="true" Width="90%"
                                    Height="37px" MaxLength="200" TextMode="MultiLine" onkeyup="this.value = this.value.slice(0, 200)"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <table width="100%">
                        <tr>
                            <td style="width: 50%" align="center">
                                <asp:Button ID="Button12" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    OnClick="ConfirmNewShouhouSort" Width="70px" />
                            </td>
                            <td style="width: 50%" align="center">
                                <asp:Button ID="Button13" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="CloseShouhouSort" Text="关闭" Width="70px" />
                            </td>
                        </tr>
                    </table>

                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--调拨主表--%>
    <%-- 检索--%>
    <asp:UpdatePanel ID="UpdatePanel9" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel10" runat="server" Visible="false">
                <asp:Label ID="label28" runat="server" Visible="False"></asp:Label>
                <fieldset>
                    <legend>客诉主表检索条件</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label29" runat="server" Text="客户名称："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox15"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label30" runat="server" Text="售后类别："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:DropDownList ID="DropDownList3" runat="server">
                                </asp:DropDownList>

                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label31" runat="server" Text="投诉类别："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Label ID="Label32" runat="server" Text="投诉时间从"></asp:Label>
                            </td>
                            <td align="left" colspan="3">

                                <asp:TextBox runat="server" ID="TextBox18" onfocus="new WdatePicker(this,'%Y-%M-%D' ,true)"
                                    DataFormatString="{0:yyyy-MM-dd}" Width="42%"></asp:TextBox>
                                到
                                <asp:TextBox runat="server" ID="TextBox19" onfocus="new WdatePicker(this,'%Y-%M-%D' ,true)"
                                    DataFormatString="{0:yyyy-MM-dd}" Width="42%"></asp:TextBox>
                            </td>
                          <td style="width: 10%" align="center">
                                <asp:Label ID="Label71" runat="server" Text="状态："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:DropDownList ID="DropDownList7" runat="server">
                                    <asp:ListItem>请选择</asp:ListItem>
                                    <asp:ListItem>已提交</asp:ListItem>
                                    <asp:ListItem>已分析</asp:ListItem>
                                    <asp:ListItem>审核通过</asp:ListItem>
                                    <asp:ListItem>审核驳回</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2"></td>
                            <td align="left">
                                <asp:Button ID="Button14" runat="server" Text="检索" CssClass="Button02" Height="24px"
                                    OnClick="SearchReturn" Width="70px" />
                            </td>
                            <td align="right">
                                <asp:Button ID="Button15" runat="server" Text="新建客诉主表" CssClass="Button02" Height="24px"
                                    OnClick="NewKesu" Width="90px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_Main" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Main" runat="server" Visible="false">
                <asp:Label ID="label11" runat="server" Visible="false"></asp:Label>
                <fieldset>
                    <legend>客诉主表</legend>
                    <asp:GridView ID="Gridview_OrderDeliver" runat="server" AutoGenerateColumns="False"
                        CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"
                        PageSize="10" AllowPaging="True" AllowSorting="True"
                        DataKeyNames="CRMCCM_ID" GridLines="None"
                        Width="100%" OnPageIndexChanging="Gridview_OrderDeliver_PageIndexChanging"
                        OnRowCommand="Gridview_OrderDeliver_RowCommand"
                        OnRowDataBound="Gridview_OrderDeliver_RowDataBound" OnDataBound="Gridview_OrderDeliver_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <%--    //隔行变色--%>
                        <Columns>
                            <asp:BoundField DataField="CRMCCM_ID" HeaderText="服务编号" ReadOnly="True" SortExpression="CRMCCM_ID"
                                Visible="false
                                ">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCIF_Name" HeaderText="客户名称" ReadOnly="True" SortExpression="CRMCIF_Name"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCS_Name" HeaderText="投诉类别" ReadOnly="True" SortExpression="CRMCS_Name"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMASS_Name" HeaderText="售后类别" ReadOnly="True" SortExpression="CRMASS_Name">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCCM_State" HeaderText="状态" SortExpression="CRMCCM_State">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCCM_InputMan" HeaderText="录入人" SortExpression="CRMCCM_InputMan">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCCM_InputTime" HeaderText="录入时间" SortExpression="CRMCCM_InputTime" DataFormatString="{0:yyyy-MM-dd}">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCCM_RequireFinishTime" HeaderText="要求天数" SortExpression="CRMCCM_RequireFinishTime">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCCM_Remark" HeaderText="备注" ReadOnly="True"
                                SortExpression="CRMCCM_Remark">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCCM_Upload" HeaderText="是否上传" ReadOnly="True"
                                SortExpression="CRMCCM_Upload">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCCM_CheckMan" HeaderText="审核人" SortExpression="CRMCCM_CheckMan">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCCM_CheckResult" HeaderText="审核结果" ReadOnly="True" SortExpression="CRMCCM_CheckResult">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCCM_CheckTime" HeaderText="审核日期" SortExpression="CRMCCM_CheckTime">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Detail1" runat="server" CommandName="Detail1" OnClientClick="false"
                                        CommandArgument='<%#Eval("CRMCCM_ID")%>'>详细</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="NewD" runat="server" CommandName="NewD" OnClientClick="false"
                                        CommandArgument='<%#Eval("CRMCCM_ID")%>'>新增详细</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete3" runat="server" CommandName="Delete3" OnClientClick="return confirm('您确认删除该记录吗?')"
                                        CommandArgument='<%#Eval("CRMCCM_ID")%>'>删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Up1" runat="server" CommandName="Up1" OnClientClick="false"
                                        CommandArgument='<%#Eval("CRMCCM_ID")%>'>上传文件</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Down1" runat="server" CommandName="Down1" OnClientClick="false"
                                        CommandArgument='<%#Eval("CRMCCM_ID")%>'>下载文件</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Check1" runat="server" CommandName="Check1" OnClientClick="false"
                                        CommandArgument='<%#Eval("CRMCCM_ID")%>'>审核</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">第<asp:Label ID="lblPageIndex" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>' />
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
    <%-- 新建客诉主表--%>
    <asp:UpdatePanel ID="UpdatePanel_NewKesu" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" Visible="false"
                Style="margin-bottom: 0px">
                <asp:Label ID="label35" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="label44" runat="server" Visible="False"></asp:Label>
                <fieldset>
                    <legend>新建客诉主表</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label36" runat="server" Text="客户名称："></asp:Label>
                            </td>
                            <td style="width: 18%" align="left">
                                <asp:TextBox runat="server" ID="TextBox16" Enabled="false"></asp:TextBox>
                                <asp:Button ID="Button18" runat="server"
                                    Text="选择…" CssClass="Button02" Height="20px"
                                    OnClick="SearchCustom1" Width="50px" />

                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label37" runat="server" Text="投诉类别："></asp:Label>
                            </td>
                            <td style="width: 10%" align="left">
                                <asp:DropDownList ID="DropDownList4" runat="server">
                                </asp:DropDownList>

                            </td>

                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label39" runat="server" Text="要求完成天数："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox20" onkeyup="this.value=this.value.replace(/[^\d]/g,'')"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label40" runat="server" Text="备注：<br/>（200字内）"></asp:Label>
                            </td>
                            <td colspan="5" align="left">
                                <asp:TextBox runat="server" ID="TextBox21" Enabled="true" Width="90%"
                                    Height="37px" MaxLength="200" TextMode="MultiLine" onkeyup="this.value = this.value.slice(0, 200)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" align="center">
                                <asp:Button ID="Button16" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    OnClick="ConfirmNewKesuMain" Width="70px" />
                            </td>
                            <td colspan="3" align="center">
                                <asp:Button ID="Button17" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="CloseNewKesuMain" Width="70px" />
                            </td>
                        </tr>

                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%-- 检索--%>
    <asp:UpdatePanel ID="UpdatePanel_SearchCus" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1_SearchCus" runat="server" Visible="false">
                <asp:Label ID="label6" runat="server" Visible="False"></asp:Label>
                <fieldset>
                    <legend>检索条件</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 20%" align="center">
                                <asp:Label ID="Label12" runat="server" Text="客户名称："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox6"></asp:TextBox>
                            </td>
                            <td style="width: 30%" align="right">
                                <asp:Button ID="Button22" runat="server" Text="检索" CssClass="Button02" Height="24px"
                                    OnClick="SearchCustomer" Width="70px" />
                            </td>
                            <td style="width: 25%" align="center">
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
                        Width="100%" OnPageIndexChanging="Gridview2_PageIndexChanging" OnRowCommand="Gridview2_RowCommand">
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
                                <ItemStyle Width="45%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCIF_Address" HeaderText="地址" ReadOnly="True" SortExpression="CRMCIF_Address"
                                Visible="true">
                                <ItemStyle Width="45%" />
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
                                    <td style="text-align: right">第<asp:Label ID="lblPageIndex" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>' />
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

    <asp:UpdatePanel ID="UpdatePanel_Detail" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1_Detail" runat="server" Visible="false">
                <asp:Label ID="label34" runat="server" Visible="false"></asp:Label>
                   <asp:Label ID="label70" runat="server" Visible="false"></asp:Label>
                <fieldset>
                    <legend>客诉详细表</legend>
                    <asp:GridView ID="Gridview_Detail" runat="server" AutoGenerateColumns="False"
                        CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"
                        PageSize="10" AllowPaging="True" AllowSorting="True"
                        DataKeyNames="CRMCCD_ID" GridLines="None"
                        Width="100%" OnPageIndexChanging="Gridview_Detail_PageIndexChanging"
                        OnRowCommand="Gridview_Detail_RowCommand" 
                        OnDataBound="Gridview_Detail_DataBound" OnRowDataBound="Gridview_Detail_RowDataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <%--    //隔行变色--%>
                        <Columns>
                            <asp:BoundField DataField="CRMCCD_ID" HeaderText="客诉详细ID" ReadOnly="True" SortExpression="CRMCCD_ID"
                                Visible="false">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMSO_ComOrderNum" HeaderText="公司订单号" ReadOnly="True" SortExpression="SMSO_ComOrderNum"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMSO_CusOrderNum" HeaderText="客户订单号" ReadOnly="True" SortExpression="SMSO_CusOrderNum"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="PT_Name" HeaderText="产品型号" ReadOnly="True" SortExpression="PT_Name"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCCD_BatchNum" HeaderText="批号" ReadOnly="True" SortExpression="CRMCCD_BatchNum">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCCD_OfferNum" HeaderText="供货数量" ReadOnly="True" SortExpression="CRMCCD_OfferNum"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCCD_LoseEfficacyNum" HeaderText="失效数量" SortExpression="CRMCCD_LoseEfficacyNum">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCCD_LoseEfficacyRate" HeaderText="失效比例" SortExpression="CRMCCD_LoseEfficacyRate">
                                <ItemStyle />
                            </asp:BoundField>

                            <asp:BoundField DataField="CRMCCD_LoseEfficacyCondition" HeaderText="失效现象" SortExpression="CRMCCD_LoseEfficacyCondition">
                                <ItemStyle />
                            </asp:BoundField>

                            <asp:BoundField DataField="CRMCCD_Return" HeaderText="是否有样品返回" SortExpression="CRMCCD_Return" ItemStyle-Width="40px">
                                <ItemStyle />

                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCCD_AnalysisResult" HeaderText="分析结果" SortExpression="CRMCCD_AnalysisResult">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete4" runat="server" CommandName="Delete4" OnClientClick="return confirm('您确认删除该记录吗?')"
                                        CommandArgument='<%#Eval("CRMCCD_ID")%>'>删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Fenxi" runat="server" CommandName="Fenxi" OnClientClick="false"
                                        CommandArgument='<%#Eval("CRMCCD_ID")%>'>录入分析结果</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="UP1" runat="server" CommandName="UP1" OnClientClick="false"
                                        CommandArgument='<%#Eval("CRMCCD_ID")%>'>上传分析报告</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HyperLink ID="Down2" runat="server" NavigateUrl='<%#"~/"+Eval("CRMCCD_AsscessPath")+"?path={0}"%>'>下载分析报告</asp:HyperLink>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="TrackLook" runat="server" CommandName="TrackLook" OnClientClick="false"
                                        CommandArgument='<%#Eval("CRMCCD_ID")%>'>查看追踪记录</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="TrackEdit" runat="server" CommandName="TrackEdit" OnClientClick="false"
                                        CommandArgument='<%#Eval("CRMCCD_ID")%>'>录入追踪记录</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">第<asp:Label ID="lblPageIndex" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>' />
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
    <div id="Panel99">
        <asp:UpdatePanel ID="UpdatePanel_upload" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <fieldset>
                    <legend>上传分析报告</legend>
                    <table style="width: 100%;">
                        <asp:Label ID="Label46" runat="server" Visible="false"></asp:Label>
                        <tr style="height: 16px;">
                            <td align="right" style="width: 25%"></td>
                            <td align="center">
                                <asp:Label ID="Label48" runat="server" Text="上传附件： "></asp:Label>

                                <asp:FileUpload ID="FileUpload1" runat="server" Width="281px" Height="20px" />
                                <asp:Label ID="Label45" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                            <td align="right" style="width: 25%"></td>
                        </tr>
                        <tr style="height: 16px;">
                            <td align="right" align="right">
                                <asp:Button ID="ok_upload" runat="server" Text="提交" Width="70px" CssClass="Button02" OnClick="ok_upload_Click" ValidationGroup="loadvalidation" />
                            </td>
                            <td style="height: 16px;" align="center"></td>
                            <td align="left">
                                <asp:Button ID="cancel_upload" runat="server" Text="关闭" Width="70px" CssClass="Button02" OnClick="cancel_upload_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="ok_upload" />
            </Triggers>
        </asp:UpdatePanel>
    </div>

    <asp:UpdatePanel ID="UpdatePanel_Tuihuanhuo" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel111" runat="server" Visible="false">
                <asp:Label ID="label3" runat="server" Visible="False"></asp:Label>
                <fieldset>
                    <legend>录入分析结果</legend>
                    <table style="width: 100%;">
                        <tr>

                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label38" runat="server" Text="售后类别："></asp:Label>
                            </td>
                            <td style="width: 30%" align="left">
                                <asp:DropDownList ID="DropDownList5" runat="server"></asp:DropDownList>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label72" runat="server" Text="上传路径："></asp:Label>
                            </td>
                            <td style="width: 50%" align="left">
                            
                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click1" > 选择路径……</asp:LinkButton> <asp:Label ID="Label73" runat="server" Text="……"></asp:Label>
                                </td>
                            
                        </tr>
                        <tr>
                            <td style="width: 20%" align="center">
                                <asp:Label ID="Label7" runat="server" Text="分析结果：<br/>(200字内)"></asp:Label>
                            </td>
                            <td colspan="3" align="left">
                                <asp:TextBox runat="server" ID="TextBox7" Enabled="true" Width="90%"
                                    Height="37px" MaxLength="200" TextMode="MultiLine" onkeyup="this.value = this.value.slice(0, 200)"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <table width="100%">
                        <tr>
                            <td style="width: 50%" align="center">
                                <asp:Button ID="Button2" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    OnClick="ComfirmTuihuanhuo" Width="70px" />
                            </td>
                            <td style="width: 50%" align="center">
                                <asp:Button ID="Button3" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="CloseTuihuanhuo" Text="关闭" Width="70px" />
                            </td>
                        </tr>
                    </table>

                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%-- 审核--%>
    <asp:UpdatePanel ID="UpdatePanel_ADDCheck" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_ADDCheck" runat="server" Visible="false">
                <fieldset>
                    <asp:Label ID="Label33" runat="server" Visible="false"></asp:Label>
                    <legend>审核栏</legend>
                    <table style="width: 100%;">
                        <tr>

                            <td style="width: 15%">审核人:
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TextBox_AddMan" runat="server" Width="100%" ReadOnly="true" Enabled="False"></asp:TextBox>
                            </td>
                            <td style="width: 20%" align="right">审核时间:
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TextBox_Addtime" runat="server" Width="98%" ReadOnly="true" DataFormatString="{0:yyyy-MM-dd HH:mm}"
                                    Enabled="False"></asp:TextBox>
                            </td>
                            <td style="width: 15%"></td>
                            <td style="width: 10%"></td>
                        </tr>
                        <tr>

                            <td>审核意见:<br />
                                （200字内）
                            </td>
                            <td colspan="7">
                                <asp:TextBox ID="TextBox_AddOpinion" runat="server" Height="80px" MaxLength="200"
                                    onblur="javascript:leave('LB1000');" onfocus="annotation('LB1000');" TextMode="MultiLine"
                                    Width="99%"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 33%; text-align: right">
                                <asp:Button ID="Button19" runat="server" CssClass="Button02" OnClick="Check_OK" Height="24px"
                                    Text="通过" Width="70px" />
                                <%--    OnClientClick="$find('gvEdit').hide();"--%>
                            </td>
                            <td style="width: 34%; text-align: center">
                                <asp:Button ID="Button20" runat="server" CssClass="Button02" OnClick="Check_NotOK" Height="24px"
                                    Text="驳回" Width="70px" />
                            </td>
                            <td style="width: 33%; text-align: left">
                                <asp:Button ID="Button21" runat="server" CssClass="Button02" OnClick="Check_Canel" Height="24px"
                                    Text="关闭" Width="70px" />
                            </td>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel2" runat="server" Visible="false">
                <asp:Label ID="label8" runat="server" Visible="False"></asp:Label><asp:Label ID="label43" runat="server" Visible="False"></asp:Label>
                <fieldset>
                    <legend>新建客诉详细</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 13%" align="center">
                                <asp:Label ID="Label9" runat="server" Text="公司订单号：" Enabled="false"></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:TextBox runat="server" ID="TextBox8"></asp:TextBox><asp:Button ID="Button202" runat="server" Text="选择…" CssClass="Button02" Height="20px"
                                    OnClick="SearchOrder" Width="50px" />
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label10" runat="server" Text="批号："></asp:Label>
                            </td>
                            <td style="width: 13%" align="left">
                                <asp:TextBox runat="server" ID="TextBox9"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label13" runat="server" Text="供货数量："></asp:Label>  
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox10" onkeyup="this.value=this.value.replace(/[^\d]/g,'')"></asp:TextBox>
                                  
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label14" runat="server" Text="失效数量："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox11" onkeyup="this.value=this.value.replace(/[^\d]/g,'')"></asp:TextBox>  
                            </td>
                            <td style="width: 12%" align="center">是否有样品返回：</td>
                            <td style="width: 15%" align="left">
                                <asp:DropDownList ID="DropDownList6" runat="server">
                                    <asp:ListItem>否</asp:ListItem>
                                    <asp:ListItem>是</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="width: 10%" align="center">&nbsp;</td>
                            <td style="width: 15%" align="left">&nbsp;</td>
                        </tr>
                        <tr>
                            <td>

                                <asp:Label ID="Label51" runat="server" Text="现象描述：<br />(200字内)"></asp:Label>


                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="TextBox22" runat="server" Enabled="true" Height="37px"
                                    MaxLength="200" onkeyup="this.value = this.value.slice(0, 200)"
                                    TextMode="MultiLine" Width="90%"></asp:TextBox></td>
                        </tr>
                        <tr>

                            <td colspan="6" align="center">

                                  <asp:Label ID="Label69" runat="server" Text="所有项都必须填写！" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" align="center">
                                <asp:Button ID="Button4" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    OnClick="ConfirmNewKesuDetail" Width="70px" />
                            </td>
                            <td colspan="3" align="center">
                                <asp:Button ID="Button24" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="CloseNewKesuDetail" Width="70px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
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
                                <asp:Label ID="Label18" runat="server" Text="客户名称："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox12"></asp:TextBox>
                            </td>
                            <td style="width: 20%" align="center">
                                <asp:Label ID="Label42" runat="server" Text="订单号："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox23"></asp:TextBox>
                            </td>
                            <td style="width: 30%" align="center">
                                <asp:Button ID="Button27" runat="server" Text="检索" CssClass="Button02" Height="24px"
                                    OnClick="SearchSMOrder" Width="70px" />
                            </td>
                            <td style="width: 25%" align="center">
                                <asp:Button ID="Button28" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="CloseSMorder" Width="70px" />
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
                    <legend>订单表</legend>
                    <asp:GridView ID="Gridview_Order" runat="server" AutoGenerateColumns="False"
                        CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"
                        PageSize="10" AllowPaging="True" AllowSorting="True" DataKeyNames="SMSOD_ID" GridLines="None"
                        Width="100%" OnPageIndexChanging="Gridview_Order_PageIndexChanging"
                        OnRowCommand="Gridview_Order_RowCommand">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <%--    //隔行变色--%>
                        <Columns>
                            <asp:BoundField DataField="SMSOD_ID" HeaderText="订单ID" ReadOnly="True" SortExpression="SMSOD_ID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>

                            <asp:BoundField DataField="SMSO_ComOrderNum" HeaderText="订单号" ReadOnly="True" SortExpression="SMSO_ComOrderNum"
                                Visible="true">
                                <ItemStyle Width="30%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCIF_Name" HeaderText="客户名称" ReadOnly="True" SortExpression="CRMCIF_Name"
                                Visible="true">
                                <ItemStyle Width="30%" />
                            </asp:BoundField>

                            <asp:BoundField DataField="PT_Name" HeaderText="产品型号" ReadOnly="True" SortExpression="PT_Name"
                                Visible="true">
                                <ItemStyle Width="30%" />
                            </asp:BoundField>
                            <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Check2" runat="server" CommandName="Check2" OnClientClick="false"
                                        CommandArgument='<%#Eval("SMSOD_ID")%>'>选择</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">第<asp:Label ID="lblPageIndex" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>' />
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
            <asp:Panel ID="Panel4" runat="server" Visible="true">
                <asp:Label ID="label47" runat="server" Visible="False"></asp:Label>
                <fieldset>
                    <legend>检索条件</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 20%" align="center">
                                <asp:Label ID="Label49" runat="server" Text="客诉追踪环节名称："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox14"></asp:TextBox>
                            </td>
                            <td style="width: 30%" align="right">
                                <asp:Button ID="Button5" runat="server" Text="检索" CssClass="Button02" Height="24px"
                                    OnClick="SearchNode" Width="70px" />
                            </td>
                            <td style="width: 25%" align="center">
                                <asp:Button ID="Button6" runat="server" Text="新建客诉处理环节" CssClass="Button02" Height="24px"
                                    OnClick="NewNode" Width="111px" />
                            </td>
                        </tr>


                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--投诉类别表--%>
    <asp:UpdatePanel ID="UpdatePanel11" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel12" runat="server" Visible="true">
                <asp:Label ID="label52" runat="server" Visible="false"></asp:Label>
                <fieldset>
                    <legend>客诉追踪环节基础表</legend>
                    <asp:GridView ID="Gridview3" runat="server" AutoGenerateColumns="False"
                        CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"
                        PageSize="10" AllowPaging="True" AllowSorting="True" DataKeyNames="CRMCTN_ID" GridLines="None"
                        Width="100%" OnPageIndexChanging="Gridview3_PageIndexChanging" OnRowCommand="Gridview3_RowCommand" OnDataBound="Gridview3_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <%--    //隔行变色--%>
                        <Columns>
                            <asp:BoundField DataField="CRMCTN_ID" HeaderText="投诉类别ID" ReadOnly="True" SortExpression="CRMCTN_ID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCTN_Name" HeaderText="追踪环节名称" ReadOnly="false" SortExpression="CRMCTN_Name"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCTN_Note" HeaderText="具体工作描述" ReadOnly="false" SortExpression="CRMCTN_Note">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Edit1" runat="server" CommandName="Edit1" OnClientClick="false"
                                        CommandArgument='<%#Eval("CRMCTN_ID")%>'>编辑</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete1" runat="server" CommandName="Delete1" OnClientClick="return confirm('您确认正确收货吗?')"
                                        CommandArgument='<%#Eval("CRMCTN_ID")%>'>删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">第<asp:Label ID="lblPageIndex" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>' />
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
                                    <td style="width: 100%"></td>
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
      <asp:UpdatePanel ID="UpdatePanel15" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel15" runat="server" Visible="false">
                <asp:Label ID="label62" runat="server" Visible="False"></asp:Label>
                <fieldset>
                    <legend>  <asp:Label ID="label65" runat="server" Visible="true"></asp:Label>客诉追踪环节基础信息</legend>
                    <table style="width: 100%;">
                        <tr>

                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label63" runat="server" Text="追踪环节名称（50字内）："></asp:Label>
                            </td>
                            <td style="width: 80%" align="left">
                               
                                <asp:TextBox runat="server" ID="TextBox25" Enabled="true" Width="90%"
                                    Height="37px" MaxLength="200" TextMode="MultiLine" onkeyup="this.value = this.value.slice(0, 100)"></asp:TextBox>
                            </td>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%" align="center">
                                <asp:Label ID="Label64" runat="server" Text="工作内容：<br/>(200字内)"></asp:Label>
                            </td>
                            <td style="width: 80%" align="left">
                                <asp:TextBox runat="server" ID="TextBox24" Enabled="true" Width="90%"
                                    Height="37px" MaxLength="200" TextMode="MultiLine" onkeyup="this.value = this.value.slice(0, 200)"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <table width="100%">
                        <tr>
                            <td style="width: 50%" align="center">
                                <asp:Button ID="Button32" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    OnClick="ComfirmNode" Width="70px" />
                            </td>
                            <td style="width: 50%" align="center">
                                <asp:Button ID="Button33" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="CloseNode" Text="关闭" Width="70px" />
                            </td>
                        </tr>
                    </table>

                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

     <%--投诉类别表--%>
    <asp:UpdatePanel ID="UpdatePanel13" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel14" runat="server" Visible="false">
                <asp:Label ID="label57" runat="server" Visible="false"></asp:Label>
                <fieldset>
                    <legend>  <asp:Label ID="label58" runat="server" Visible="false"></asp:Label>客诉追踪记录</legend>
                    <asp:GridView ID="Gridview4" runat="server" AutoGenerateColumns="False"
                        CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"
                        PageSize="10" AllowPaging="True" AllowSorting="True" DataKeyNames="CRMCCT_ID" GridLines="None"
                        Width="100%" OnPageIndexChanging="Gridview4_PageIndexChanging" OnRowCommand="Gridview4_RowCommand" OnDataBound="Gridview4_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <%--    //隔行变色--%>
                        <Columns>
                            <asp:BoundField DataField="CRMCCT_ID" HeaderText="投诉类别ID" ReadOnly="True" SortExpression="CRMCCT_ID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCTN_Name" HeaderText="追踪环节名称" ReadOnly="false" SortExpression="CRMCTN_Name"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                             <asp:BoundField DataField="CRMCTN_Note" HeaderText="规定工作内容" ReadOnly="false" SortExpression="CRMCTN_Note"
                                Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCCT_Reason" HeaderText="本次工作目的" ReadOnly="false" SortExpression="CRMCCT_Reason">
                                <ItemStyle />
                            </asp:BoundField>
                               <asp:BoundField DataField="CRMCCT_Remark" HeaderText="本次具体工作内容" ReadOnly="false" SortExpression="CRMCCT_Remark">
                                <ItemStyle />
                            </asp:BoundField>
                             <asp:BoundField DataField="CRMCCT_Upload" HeaderText="是否有附件" ReadOnly="false" SortExpression="CRMCCT_Upload">
                                <ItemStyle />
                            </asp:BoundField>
                             <asp:BoundField DataField="CRMCCT_Man" HeaderText="录入人" ReadOnly="false" SortExpression="CRMCCT_Man">
                                <ItemStyle />
                            </asp:BoundField>
                             <asp:BoundField DataField="CRMCCT_Time" HeaderText="录入时间" ReadOnly="false" SortExpression="CRMCCT_Time" DataFormatString="{0:yyyy-MM-dd}">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Edit1" runat="server" CommandName="Edit1" OnClientClick="false"
                                        CommandArgument='<%#Eval("CRMCCT_ID")%>'>编辑</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
   <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HyperLink ID="Down3" runat="server" NavigateUrl='<%#"~/"+Eval("CRMCCT_Path")+"?path={0}"%>'>下载分析报告</asp:HyperLink>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">第<asp:Label ID="lblPageIndex" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>' />
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
                                    <td style="width: 100%"></td>
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
   
     <asp:UpdatePanel ID="UpdatePanel12" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel13" runat="server" Visible="false">
                <asp:Label ID="label53" runat="server" Visible="False"></asp:Label>
                <fieldset>
                    <legend>
                        <asp:Label ID="label59" runat="server" Visible="true"></asp:Label>
                        追踪结果</legend>
                    <table style="width: 100%;">
                        <tr>

                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label54" runat="server" Text="追踪环节："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
                            </td>
                             <td style="width: 10%" align="center">
                                <asp:Label ID="Label67" runat="server" Text="文件路径："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:Label ID="Label68" runat="server" ></asp:Label>
                            </td>
                        </tr>
                          <tr>
                            <td style="width: 20%" align="center">
                                <asp:Label ID="Label66" runat="server" Text="目的：<br/>(200字内)"></asp:Label>
                            </td>
                            <td style="width: 80%" colspan="3">
                                <asp:TextBox runat="server" ID="TextBox26" Enabled="true" Width="90%"
                                    Height="37px" MaxLength="200" TextMode="MultiLine" onkeyup="this.value = this.value.slice(0, 200)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%" align="center">
                                <asp:Label ID="Label55" runat="server" Text="具体内容：<br/>(200字内)"></asp:Label>
                            </td>
                            <td style="width: 80%" align="left" colspan="3">
                                <asp:TextBox runat="server" ID="TextBox17" Enabled="true" Width="90%"
                                    Height="37px" MaxLength="200" TextMode="MultiLine" onkeyup="this.value = this.value.slice(0, 200)"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <table width="100%">
                        <tr>
                            <td style="width: 30%" align="center">
                                <asp:Button ID="Button25" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    OnClick="ConfirmTrack" Width="70px" />
                            </td>
                             <td style="width: 40%" align="center">
                                <asp:Button ID="Button29" runat="server" Text="上传附件" CssClass="Button02" Height="24px"
                                    OnClick="OpenUploadTrack" Width="70px" />
                            </td>
                            <td style="width: 30%" align="center">
                                <asp:Button ID="Button26" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="CloseTrack" Text="关闭" Width="70px" />
                            </td>
                        </tr>
                    </table>

                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
       <div id="panel98">
        <asp:UpdatePanel ID="UpdatePanel14" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <fieldset>
                    <legend>上传追踪结果</legend>
                    <table style="width: 100%;">
                        <asp:Label ID="Label56" runat="server" Visible="false"></asp:Label>
                        <tr style="height: 16px;">
                            <td align="right" style="width: 25%"></td>
                            <td align="center">
                                <asp:Label ID="Label60" runat="server" Text="上传附件： "></asp:Label>

                                <asp:FileUpload ID="FileUpload2" runat="server" Width="281px" Height="20px" />
                                <asp:Label ID="Label61" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                            <td align="right" style="width: 25%"></td>
                        </tr>
                        <tr style="height: 16px;">
                            <td align="right" align="right">
                                <asp:Button ID="Button30" runat="server" Text="提交" Width="70px" CssClass="Button02" OnClick="ok_upload_Click1" ValidationGroup="loadvalidation" />
                            </td>
                            <td style="height: 16px;" align="center"></td>
                            <td align="left">
                                <asp:Button ID="Button31" runat="server" Text="关闭" Width="70px" CssClass="Button02" OnClick="cancel_upload_Click1" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="Button30" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>
