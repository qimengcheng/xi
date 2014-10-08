<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CopperInStore.aspx.cs" Inherits="Laputa.CopperInStore"
    MasterPageFile="~/Other/MasterPage.master" Title="入库管理" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--   退货订单开始--%>
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
    <%--采购订单结束--%>
<script language="javascript" type="text/javascript">
    function test1() {
        var aa = window.confirm("单击“确定”继续。单击“取消”停止。");
        if (aa) {
            window.alert("你选了确定！");
        }
        else window.alert("你选了取消！");
    }
</script>
    <%--   采购订单开始--%>
    <asp:Label ID="label_condition" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="label_conditiondetail" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="label_kufang" runat="server" Visible="False"></asp:Label>
    <asp:UpdatePanel ID="UpdatePanel_Search" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Search" runat="server" Visible="true">
                <fieldset>
                    <legend>入库单检索条件</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label" runat="server" Text="入库单号："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox1"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label15" runat="server" Text="入库库房："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox11"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label5" runat="server" Text="入库类别："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox2"></asp:TextBox>
                            </td>
                            <td style="width: 13%" align="center">
                                <asp:Label ID="Label1" runat="server" Text="入库单状态："></asp:Label>
                            </td>
                            <td style="width: 12%" align="left">
                                <asp:DropDownList ID="DropDownList1" runat="server">
                                    <asp:ListItem>选择状态</asp:ListItem>
                                    <asp:ListItem>待提交</asp:ListItem>
                                    <asp:ListItem>待检验</asp:ListItem>
                                    <asp:ListItem>合格入库</asp:ListItem>
                                    <asp:ListItem>拒绝入库</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label2" runat="server" Text="入库单位："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox3"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label3" runat="server" Text="责任人："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox4"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label4" runat="server" Text="入库时间从："></asp:Label>
                            </td>
                            <td align="left" colspan="3">
                                
                                <asp:TextBox runat="server" ID="TextBox5" onfocus="new WdatePicker(this,'%Y-%M-%D' ,true)"
                                    DataFormatString="{0:yyyy-MM-dd}" CssClass="Wdate"></asp:TextBox>
                                到
                                <asp:TextBox runat="server" ID="TextBox6" onfocus="new WdatePicker(this,'%Y-%M-%D' ,true)"
                                    DataFormatString="{0:yyyy-MM-dd}" CssClass="Wdate"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" align="center">
                                <asp:Button ID="Button1" runat="server" Text="检索" CssClass="Button02" Height="24px"
                                    OnClick="SearchInStoreMain" Width="70px" />
                            </td>
                            <td colspan="2" align="center">
                                <asp:Button ID="Button3" runat="server" Text="检索入库单详细" CssClass="Button02" Height="24px"
                                    OnClick="OpenInstoreDetail" Width="110px" />
                            </td>
                            <td colspan="3" align="center">
                                <asp:Button ID="Button2" runat="server" Text="新增入库单" CssClass="Button02" Height="24px"
                                    OnClick="CreateInStoreMain" Width="90px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_SearchDetail" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_SearchDetail" runat="server" Visible="false">
                <fieldset>
                    <legend>入库单详细检索条件</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label6" runat="server" Text="物品名称："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox7"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label7" runat="server" Text="规格型号："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox8"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                批号：
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox9"></asp:TextBox>
                            </td>
                            <td style="width: 13%" align="center">
                                <asp:Label ID="Label9" runat="server" Text="是否降档："></asp:Label>
                            </td>
                            <td style="width: 12%" align="left">
                                <asp:DropDownList ID="DropDownList2" runat="server">
                                    <asp:ListItem>选择是否</asp:ListItem>
                                    <asp:ListItem>是</asp:ListItem>
                                    <asp:ListItem>否</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center">
                                <asp:Button ID="Button4" runat="server" Text="检索" CssClass="Button02" Height="24px"
                                    OnClick="SearchInStoreDetail" Width="70px" />
                            </td>
                            <td colspan="4" align="center">
                                <asp:Button ID="Button5" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="ColseInStoreDetail" Width="70px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_InStoreMain" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_InStoreMain" runat="server" Visible="true">
                <fieldset>
                    <asp:Label ID="Label43" runat="server"  Visible="false"></asp:Label>
                    <legend>入库单主表</legend>
                    <asp:GridView ID="Gridview_INStoreMain" runat="server" AutoGenerateColumns="False"
                        CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False" 
                        PageSize="10" AllowPaging="True" AllowSorting="True" DataKeyNames="IMISM_ID,IMSSBD_ID,IMS_StoreID"
                        GridLines="None" Width="100%" OnPageIndexChanging="Gridview_INStoreMain_PageIndexChanging"
                        OnRowCancelingEdit="Gridview_INStoreMain_RowCancelingEdit" OnRowDeleting="Gridview_INStoreMain_RowDeleting"
                        OnRowEditing="Gridview_INStoreMain_RowEditing" OnRowUpdating="Gridview_INStoreMain_RowUpdating"
                        OnRowCommand="Gridview_INStoreMain_RowCommand" 
                        OnDataBound="Gridview_INStoreMain_DataBound" 
                        onrowdatabound="Gridview_INStoreMain_RowDataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <%--    //隔行变色--%>
                        <Columns>
                            <asp:BoundField DataField="IMISM_ID" HeaderText="入库单主表ID" ReadOnly="True" SortExpression="IMISM_ID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMSSBD_ID" HeaderText="入库类别ID" ReadOnly="True" SortExpression="IMSSBD_ID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMS_StoreID" HeaderText="库房ID" ReadOnly="True" SortExpression="IMS_StoreID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMISM_InStoreNum" HeaderText="入库单号" ReadOnly="True" SortExpression="IMISM_InStoreNum">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMSSBD_Name" HeaderText="入库类别" ReadOnly="True" SortExpression="IMSSBD_Name">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMS_StoreName" HeaderText="入库库房" ReadOnly="True" SortExpression="IMS_StoreName">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMISM_InStoreState" HeaderText="入库单状态" ReadOnly="True"
                                SortExpression="IMISM_InStoreState">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMISM_InStoreCompany" HeaderText="入库单位" SortExpression="IMISM_InStoreCompany">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMISM_ResponMan" HeaderText="责任人" SortExpression="IMISM_ResponMan">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMISM_InStoreTime" HeaderText="入库时间" ReadOnly="True" SortExpression="IMISM_InStoreTime"
                                DataFormatString="{0:yyyy-MM-dd HH:mm}">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMISM_MakeMan" HeaderText="录入人" ReadOnly="True" SortExpression="IMISM_MakeMan">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Look1" runat="server" CommandName="Look1" OnClientClick="false"
                                        CommandArgument='<%#Eval("IMISM_ID")%>'>查看</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ShowEditButton="True" EditText="编辑" UpdateText="更新" CancelText="取消" />
                            <asp:CommandField ShowDeleteButton="True" DeleteText="删除" />
                            <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Edit1" runat="server" CommandName="Edit1" OnClientClick="false"
                                        CommandArgument='<%#Eval("IMISM_ID")%>'>编辑详细</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="PrintDetail" runat="server" CommandName="PrintDetail" OnClientClick="false"
                                       CommandArgument='<%#Eval("IMISM_ID") +","+ Eval("IMISM_InStoreNum") +","+ Eval("IMSSBD_Name")+","+ Eval("IMS_StoreName")+","+ Eval("IMISM_InStoreCompany")+","+ Eval("IMISM_ResponMan")+","+ Eval("IMISM_InStoreTime")+","+ Eval("IMISM_MakeMan")%>'>打印入库单</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="SendRTX1" runat="server" CommandName="SendRTX1" OnClientClick="false"
                                        CommandArgument='<%#Eval("IMISM_ID")%>'>发送检验信息</asp:LinkButton>
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
    <%--采购订单结束--%>
    <asp:UpdatePanel ID="UpdatePanel_NewInStoreMain" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_NewInStoreMain" runat="server" Visible="false">
                <fieldset>
                    <legend>新增入库单</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 13%" align="center">
                                <asp:Label ID="Label12" runat="server" Text="入库类别："></asp:Label>
                            </td>
                            <td style="width: 12%" align="left">
                                <asp:DropDownList ID="DropDownList3" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label8" runat="server" Text="入库库房："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:DropDownList ID="DropDownList4" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label10" runat="server" Text="来源单位："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox12" MaxLength="50"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label11" runat="server" Text="责任人："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox13" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center">
                                <asp:Button ID="Button6" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    OnClick="ConfirmNewInStoreMain" Width="70px" />
                            </td>
                            <td colspan="4" align="center">
                                <asp:Button ID="Button7" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="CanelNewInStoreMain" Width="70px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%-- 弹出框选择--%>
    <asp:UpdatePanel ID="UpdatePanel_InstoreDetail" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_InstoreDetail" runat="server" Visible="false" Width="100%">
                <fieldset>
                    <asp:Label ID="Label34" runat="server" Visible="false" readonly="true"></asp:Label>
                     <asp:Label ID="Label53" runat="server" Visible="false" readonly="true"></asp:Label>
                    <legend>
                        <asp:Label ID="Label13" runat="server" Text=""></asp:Label>入库单详细表</legend>
                        <asp:Button ID="Button8" runat="server" Text="新增" CssClass="Button02" Height="24px"
                                    OnClick="NewSource" Width="70px" />
                    <asp:GridView ID="Gridviewl_InstoreDetail" runat="server" AutoGenerateColumns="False"
                        CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False" 
                        PageSize="10" AllowPaging="True" AllowSorting="True" DataKeyNames="IMISD_ID,PT_ID,IMMBD_MaterialID,IMISM_ID,IMSA_AreaID"
                        GridLines="None" Width="100%" OnRowCommand="Gridviewl_InstoreDetail_RowCommand"
                        OnPageIndexChanging="Gridviewl_InstoreDetail_PageIndexChanging" 
                        OnDataBound="Gridviewl_InstoreDetail_DataBound" 
                        onrowdatabound="Gridviewl_InstoreDetail_RowDataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <%--    //隔行变色--%>
                        <Columns>
                            <asp:BoundField DataField="IMISD_ID" HeaderText="详细表ID" ReadOnly="True" SortExpression="IMISD_ID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PT_ID" HeaderText="产品ID" ReadOnly="True" SortExpression="PT_ID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_MaterialID" HeaderText="物料ID" ReadOnly="True" SortExpression="IMMBD_MaterialID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMISM_ID" HeaderText="主表ID" ReadOnly="True" SortExpression="IMISM_ID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Name" HeaderText="物料名称" ReadOnly="True" SortExpression="Name">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="Model" HeaderText="规格型号" ReadOnly="True" SortExpression="Model" HtmlEncode="false">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMISD_BatchNum" HeaderText="批号" ReadOnly="True" SortExpression="IMISD_BatchNum">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMIDS_Level" HeaderText="档次" ReadOnly="True" SortExpression="IMIDS_Level">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="Unit" HeaderText="单位" SortExpression="Unit">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMISD_ShouldArrNum" HeaderText="应到数量" SortExpression="IMISD_ShouldArrNum">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMIDS_ActualArrNum" HeaderText="实到数量" SortExpression="IMIDS_ActualArrNum">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMIDS_PerWeight" HeaderText="单位重量" ReadOnly="True" SortExpression="IMIDS_PerWeight">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMIDS_TotalWeight" HeaderText="总重量" ReadOnly="True" SortExpression="IMIDS_TotalWeight">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMSA_AreaName" HeaderText="预入库区域" ReadOnly="True"
                                SortExpression="IMSA_AreaName">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMIDS_QA" HeaderText="品保结果" ReadOnly="True" SortExpression="IMIDS_QA">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMIDS_DownLevel" HeaderText="是否降档" ReadOnly="True" SortExpression="IMIDS_DownLevel">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMIDS_DownLevelPara" HeaderText="降档参数" ReadOnly="True"
                                SortExpression="IMIDS_DownLevelPara">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Edit2" runat="server" CommandName="Edit2" OnClientClick="false"
                                        CommandArgument='<%#Eval("IMISD_ID")%>'>编辑</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete2" runat="server" CommandName="Delete2" OnClientClick="return confirm('您确认删除该记录吗?')"
                                        CommandArgument='<%#Eval("IMISD_ID")%>'>删除</asp:LinkButton>
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
                    <table style="width: 100%;">
                        <tr>
                            <td width="30%" align="right">
                                <asp:Button ID="Button10" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    OnClick="ConfirmDetail" Width="70px" />
                            </td>
                            <td width="30%" align="center">
                                
                            </td>
                            <td width="30%" align="left">
                                <asp:Button ID="Button9" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="CloseDetail" Width="70px" />
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--   采购订单开始--%>
    <asp:UpdatePanel ID="UpdatePanel_NewDetail" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_NewDetail" runat="server" Visible="false">
             <asp:Label ID="Label54" runat="server"   Visible="false"></asp:Label>
               <asp:Label ID="Label55" runat="server"  Visible="false"></asp:Label>
                <asp:Label ID="Label56" runat="server"  Visible="false"></asp:Label>
                 <asp:Label ID="Label57" runat="server"  Visible="false"></asp:Label>
                <fieldset>
                    <legend>
                        <asp:Label runat="server" ID="Label_NEW_OLD"></asp:Label><asp:Label runat="server"
                            ID="Label29"></asp:Label></legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 8%" align="center">
                               
                                物料名称:</td>
                            <td style="width: 16%" align="left">
                            
                                    <asp:Label ID="TextBox15" runat="server" BackColor="SkyBlue" Enabled="False" Text="请选择物料"></asp:Label>
                            
                                    <asp:Button ID="Button21" runat="server" Text="选择物料" CssClass="Button02" Height="18px"
                                    OnClick="SelectType" Width="55px" />
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label16" runat="server" Text="规格型号：" Enabled="false"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox16" MaxLength="50" Enabled="false"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label17" runat="server" Text="批号："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox17" MaxLength="50"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label18" runat="server" Text="档次："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox18" MaxLength="50" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 8%" align="center">
                                <asp:Label ID="Label19" runat="server" Text="入库类别："></asp:Label>
                            </td>
                            <td style="width: 16%" align="left">
                                <asp:TextBox runat="server" ID="TextBox20" MaxLength="50" Enabled="false"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label20" runat="server" Text="计量单位：" Enabled="false"></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox19" Enabled="false"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label21" runat="server" Text="应到数量："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox21" MaxLength="50" onkeyup="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{2,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{2})[0-9]*/, '$1');" 
                              onafterpaste="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{2,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{2})[0-9]*/, '$1');"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label22" runat="server" Text="实到数量："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox22" MaxLength="50" onkeyup="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{2,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{2})[0-9]*/, '$1');" 
                              onafterpaste="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{2,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{2})[0-9]*/, '$1');"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 8%; height: 21px;" align="center">
                                铜材信息:</td>
                            <td style="width: 16%; height: 21px;" align="left">
                                <asp:Label ID="CopperText" runat="server" Text="请选择铜材信息"></asp:Label>
                            </td>
                            <td style="width: 10%; height: 21px;" align="center">
                                <asp:Button ID="Button34" runat="server" CssClass="Button02" Height="18px" OnClick="SelectCopper" Text="选择铜材信息" Width="76px" />
                            </td>
                            <td style="width: 15%; height: 21px;" align="left">
                                &nbsp;</td>
                            <td style="width: 10%; height: 21px;" align="center">
                                <asp:Label ID="Label25" runat="server" Text="预入库区域："></asp:Label>
                            </td>
                            <td style="width: 15%; height: 21px;" align="left">
                                  <asp:DropDownList runat="server" ID="DropDownList6" >
                                </asp:DropDownList>
                            </td>
                            <td style="width: 10%; height: 21px;" align="center">
                                <asp:Label ID="Label26" runat="server" Text="是否降档："></asp:Label>
                            </td>
                            <td style="width: 15%; height: 21px;" align="left">
                                <asp:DropDownList runat="server" ID="DropDownList5" Enabled="false">
                                   
                                   <asp:ListItem>否</asp:ListItem> <asp:ListItem>是</asp:ListItem>
                                    
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="width: 8%">
                                <asp:Label ID="CopperID" runat="server" Text="CopperID" Visible="False"></asp:Label>
                            </td>
                            <td colspan="3" align="left">
                                &nbsp;</td>
                            <td align="center">
                                &nbsp;</td>
                            <td colspan="3" align="left">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center">
                                <asp:Button ID="Button11" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    OnClick="ConfirmNewInStoreDetail" Width="70px" />
                            </td>
                            <td colspan="4" align="center">
                                <asp:Button ID="Button12" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="CanelNewInStoreDetail" Width="70px" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--采购订单结束--%>

<div style="display:none;border:1px solid;width:165px;height:150px;" id="win">
<table align="center" width=100% cellspacing="0" cellpadding="0">
<tr>
<td colspan=2 align="right" style="background:blue"><span style="color:red" onclick="closeWin()">X</span></td>
</tr>
<tr>
<td>请选择要插入的物料类型</td>
<td height="60px">
<select>
<option>产品</option>
<option>材料</option>
</select>
</td></tr>
</table>
</div>
    <%--   退货订单开始--%>
    <asp:UpdatePanel ID="UpdatePanel_MatType" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_MatType" runat="server" Visible="false">
                <fieldset>
                    <legend>物料名称检索</legend>
                    <table style="width: 100%;">
                        <asp:Label ID="label_mattype" runat="server" Visible="False"></asp:Label>
                        
                        <tr>
                            <td style="width: 15%" align="center">
                                <asp:Label ID="Label30" runat="server" Text="物料类别："></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:DropDownList ID="DropDownList7" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 15%" align="center">
                                <asp:Label ID="Label31" runat="server" Text="物料名称："></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:TextBox runat="server" ID="MatName"> </asp:TextBox>
                            </td>
                            <td style="width: 15%" align="center">
                                <asp:Label ID="Label32" runat="server" Text="规格型号："></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:TextBox runat="server" ID="Model"> </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" align="center">
                                <asp:Button ID="Button13" runat="server" Text="检索" CssClass="Button02" Height="24px"
                                    OnClick="SelectMatBasicData" Width="70px" />
                            </td>
                            <td colspan="3" align="center">
                                <asp:Button ID="Button15" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="ColseMaterialBasicSearch" Width="70px" />
                            </td>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
            <asp:Panel ID="Panel2" runat="server" Visible="false">
                <fieldset>
                    <legend>物料列表</legend>
                    <asp:GridView ID="Gridview_MatType" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle"
                        CellPadding="0" UseAccessibleHeader="False" PageSize="10" 
                        AllowPaging="True" AllowSorting="True" Font-Strikeout="False" GridLines="None"
                        DataKeyNames="IMMBD_MaterialID,IMMt_MaterialTypeID" OnPageIndexChanging="Gridview_MatTypeID_PageIndexChanging"
                        Width="100%" onrowdatabound="Gridview_MatType_RowDataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemStyle Width="5%" />
                                <ItemTemplate>
                                    <asp:RadioButton ID="RadioButton1" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:BoundField DataField="IMMBD_MaterialID" HeaderText="物料ID" ReadOnly="True" SortExpression="IMMBD_MaterialID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMt_MaterialTypeID" HeaderText="物料类型ID" ReadOnly="True"
                                SortExpression="IMMt_MaterialTypeID" Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMT_MaterialType" HeaderText="物料类型" SortExpression="IMMT_MaterialType">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_MaterialName" HeaderText="物料名称" SortExpression="IMMBD_MaterialName">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_SpecificationModel" HeaderText="规格型号" SortExpression="IMMBD_SpecificationModel">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_MaterialCode" HeaderText="物料编码" SortExpression="IMMBD_MaterialCode">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="UnitName" HeaderText="单位" SortExpression="UnitName">
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
                        </PagerTemplate>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label50" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <table width="100%">
                        <tr>
                            <td style="width: 50%" align="center">
                                <asp:Button ID="Button14" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    OnClick="InsertMaterial" Width="70px" />
                            </td>
                            <td style="width: 50%" align="center">
                                <asp:Button ID="Button16" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="CanelMaterial" Width="70px" />
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--采购订单结束--%><%--   采购订单开始--%>
    <asp:UpdatePanel ID="UpdatePanelCopper" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
           
            <asp:Panel ID="Panel1" runat="server" Visible="true">
                <fieldset>
                    <legend> 检索条件
                    </legend>
    <table style="width: 100%;">  
        <tr>
        <td style="width: 15%" align="right">
                <asp:Label ID="Label14" runat="server" Text="供应商名称:"></asp:Label>
            </td>
            <td style="width: 12%" align="left">
                <asp:TextBox ID="TextBox_Factory" runat="server"> </asp:TextBox>
            </td>
            <td style="width: 15%;text-align: right">
                <asp:Label ID="Label23" runat="server" Text="供应商编号:"></asp:Label>
            </td>
            <td style="width: 12%" align="left">
               <asp:TextBox ID="TextBox10" runat="server"> </asp:TextBox>
            </td>

            <td style="width: 15%" align="right">
                <asp:Label ID="Label24" runat="server" Text="铜材规格:"></asp:Label>
            </td>
               <td style="width: 15%; height: 20px;" align="left">
                <asp:TextBox ID="TextBox23" runat="server"> </asp:TextBox>
            </td>
            </tr>
            <tr>
            <td style="width: 15%" align="right">
                <asp:Label ID="Label27" runat="server" Text="时间:"></asp:Label>
            </td>
                <td style="width: 12%" align="left" colspan="3">
                <asp:TextBox ID="TextBox_Time1" runat="server"  onfocus="new WdatePicker(this,'%Y-%M-%D' ,true)" DataFormatString="{0:yyyy-MM-dd}" ></asp:TextBox>
            
                    &nbsp;
            
               <asp:Label ID="Label28" runat="server" Text="至"></asp:Label>
            
                    &nbsp;
            
                <asp:TextBox ID="TextBox_Time2" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D' ,true)" DataFormatString="{0:yyyy-MM-dd}" ></asp:TextBox>
            </td>   
        </tr>
       
        <tr>
        <td style="width: 15%" align="left">
                &nbsp;</td>
            <td colspan="2" align="left">
                <asp:Button ID="MainSearch" runat="server" Text="检索" CssClass="Button02" Height="24px" OnClick="CopperSearch_Click"
                    Width="70px" />
            </td>
          
            <td colspan="2" align="left">
                
             
                <asp:Button ID="Button35" runat="server" CssClass="Button02" Height="24px" OnClick="CloseCopper" Text="关闭" Width="70px" />
                
             
            </td>
            <td style="width: 15%" align="left" colspan="2">
               <asp:Button ID="Button18" runat="server" Text="重置" CssClass="Button02" Height="24px" OnClick="Reset" Visible="true"
                    Width="70px" /></td>
        </tr>
    </table>
     </fieldset>
           
       
        <fieldset>
            <legend>铜材代工表 </legend>
            <asp:GridView ID="GridView1" runat="server" CssClass="GridViewStyle"  AllowPaging="True" PageSize="5" AutoGenerateColumns="False" 
                        GridLines="None" EmptyDataText="没有相关记录" OnRowCommand="GridView1_RowCommand"
                         DataKeyNames="PMCF_ID"  OnPageIndexChanging="GridView1_PageIndexChanging" EnableModelValidation="True">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="PMCF_ID" HeaderText="铜材代工ID" Visible="false" SortExpression="SMSMPM_ID" />
                            <asp:BoundField DataField="IMMBD_MaterialName" HeaderText="材料名称" Visible="true" SortExpression="PMP_ID" />
                            <asp:BoundField DataField="PMSI_SupplyName" HeaderText="供应商名称" Visible="true" SortExpression="SMSMPM_Year" />
                                 <asp:BoundField DataField="IMMBD_SpecificationModel" HeaderText="规格" Visible="true" SortExpression="SMSMPM_Year" />
                                 <asp:BoundField DataField="PMCF_BatchNum" HeaderText="批号" Visible="true" SortExpression="SMSMPM_Year" />
                            <asp:BoundField DataField="PMCF_PurchaseNum" HeaderText="采购数量" Visible="true" SortExpression="SMSMPM_Year" />
                            <asp:BoundField DataField="PMCF_Time" HeaderText="时间" Visible="true" DataFormatString="{0:yyyy-MM-dd}" SortExpression="PMCF_Time" />
                         
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Choose" runat="server" CommandArgument='<%# Eval("PMCF_ID") %>' CommandName="Choose">选择</asp:LinkButton>
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
    <%--采购订单结束--%>

<%-- 弹出框选择--%>
            
             <%--   采购订单开始--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel4" runat="server" Visible="false">
                <fieldset>
                    <legend>采购订单检索</legend>
                    <table style="width: 100%;">
                        <asp:Label ID="label38" runat="server" Visible="False"></asp:Label>
                        
                        <tr>
                            <td style="width: 15%" align="center">
                                <asp:Label ID="Label40" runat="server" Text="采购订单号："></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                    <asp:TextBox runat="server" ID="TextBox28"> </asp:TextBox>
                            </td>
                            <td style="width: 15%" align="center">
                                <asp:Label ID="Label41" runat="server" Text="供应商名称："></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:TextBox runat="server" ID="TextBox14"> </asp:TextBox>
                            </td>
                            <td style="width: 15%" align="center">
                                <asp:Label ID="Label42" runat="server" Text="物料名称："></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:TextBox runat="server" ID="TextBox27"> </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" align="center">
                                <asp:Button ID="Button22" runat="server" Text="检索" CssClass="Button02" Height="24px"
                                    OnClick="SelectPur" Width="70px" />
                            </td>
                            <td colspan="3" align="center">
                                <asp:Button ID="Button23" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="ColsePur" Width="70px" />
                            </td>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
            <asp:Panel ID="Panel5" runat="server" Visible="false">
                <fieldset>
                    <legend>采购订单列表</legend>
                    <asp:GridView ID="Gridview_Pur" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle"
                        CellPadding="0" UseAccessibleHeader="False" PageSize="10" 
                        AllowPaging="True" AllowSorting="True" Font-Strikeout="False" GridLines="None"
                        DataKeyNames="PMPOD_PurchaseDetailID,IMMBD_MaterialID,PMSI_ID,PMPO_PurchaseOrderID" OnPageIndexChanging="Gridview_Pur_PageIndexChanging"
                        Width="100%" >
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemStyle Width="5%" />
                                <ItemTemplate>
                               <asp:CheckBox ID="CheckBox2" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:BoundField DataField="PMPOD_PurchaseDetailID" HeaderText="采购订单详细ID" ReadOnly="True" SortExpression="PMPOD_PurchaseDetailID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_MaterialID" HeaderText="物料类型ID" ReadOnly="True"
                                SortExpression="IMMBD_MaterialID" Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                              <asp:BoundField DataField="PMSI_ID" HeaderText="供应商ID" ReadOnly="True"
                                SortExpression="PMSI_ID" Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                              <asp:BoundField DataField="PMPO_PurchaseOrderID" HeaderText="主表ID" ReadOnly="True"
                                SortExpression="PMPO_PurchaseOrderID" Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PMPO_PurchaseOrderNum" HeaderText="采购订单号" SortExpression="PMPO_PurchaseOrderNum">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                              <asp:BoundField DataField="PMSI_SupplyName" HeaderText="供应商" SortExpression="PMSI_SupplyName">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_MaterialName" HeaderText="物料名称" SortExpression="IMMBD_MaterialName">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_SpecificationModel" HeaderText="规格型号" SortExpression="IMMBD_SpecificationModel">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_MaterialCode" HeaderText="物料编码" SortExpression="IMMBD_MaterialCode">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="PMPO_MakeTime" HeaderText="下单日期" SortExpression="PMPO_MakeTime" DataFormatString="{0:yyyy-MM-dd}">
                                <ItemStyle />
                            </asp:BoundField>
                             <asp:BoundField DataField="PMPOD_Num" HeaderText="应到数量" SortExpression="PMPOD_Num">
                                <ItemStyle />
                            </asp:BoundField>   
                            <asp:BoundField DataField="UnitName" HeaderText="单位" SortExpression="UnitName">
                                <ItemStyle />
                            </asp:BoundField>
                               <asp:BoundField DataField="PMPOD_Num" HeaderText="产品要求" SortExpression="PMPOD_Num">
                                <ItemStyle/>
                            </asp:BoundField>
                               <asp:BoundField DataField="PMPOD_Num" HeaderText="备注" SortExpression="PMPOD_Num">
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
                        </PagerTemplate>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label50" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <table width="100%">
                        <tr>
                            <td style="width: 50%" align="center">
                                <asp:Button ID="Button24" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    OnClick="InsertPurchase" Width="70px" />
                            </td>
                            <td style="width: 50%" align="center">
                                <asp:Button ID="Button25" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="CanelPurchase" Width="70px" />
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--采购订单结束--%>
                 <%--   退货订单开始--%>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel6" runat="server" Visible="false">
                <fieldset>
                    <legend>退货单检索</legend>
                    <table style="width: 100%;">
                        <asp:Label ID="label44" runat="server" Visible="False"></asp:Label>
                        
                        <tr>
                            <td style="width: 15%" align="center">
                                <asp:Label ID="Label45" runat="server" Text="退货单号："></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                    <asp:TextBox runat="server" ID="TextBox29"> </asp:TextBox>
                            </td>
                            <td style="width: 15%" align="center">
                                <asp:Label ID="Label46" runat="server" Text="客户名称："></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:TextBox runat="server" ID="TextBox30"> </asp:TextBox>
                            </td>
                            <td style="width: 15%" align="center">
                                <asp:Label ID="Label47" runat="server" Text="产品型号："></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:TextBox runat="server" ID="TextBox31"> </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" align="center">
                                <asp:Button ID="Button26" runat="server" Text="检索" CssClass="Button02" Height="24px"
                                    OnClick="SelectReturn" Width="80px" />
                            </td>
                            <td colspan="3" align="center">
                                <asp:Button ID="Button27" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="ColseReturn" Width="80px" />
                            </td>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
            <asp:Panel ID="Panel7" runat="server" Visible="false">
                <fieldset>
                    <legend>退货单单列表</legend>
                    <asp:GridView ID="Gridview_Return" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle"
                        CellPadding="0" UseAccessibleHeader="False" PageSize="10" 
                        AllowPaging="True" AllowSorting="True" Font-Strikeout="False" GridLines="None"
                        DataKeyNames="PT_ID,SMRC_ID" OnPageIndexChanging="Gridview_Return_PageIndexChanging"
                        Width="100%" >
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemStyle Width="5%" />
                                <ItemTemplate>
                               <asp:CheckBox ID="CheckBox2" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:BoundField DataField="PT_ID" HeaderText="产品ID" ReadOnly="True" SortExpression="PT_ID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMRC_ID" HeaderText="退货单ID" ReadOnly="True"
                                SortExpression="SMRC_ID" Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PT_Name" HeaderText="产品名称" SortExpression="PT_Name">
                                <ItemStyle />
                                 </asp:BoundField>
                            <asp:BoundField DataField="SMRC_ReturnOrderNum" HeaderText="退货单号" SortExpression="SMRC_ReturnOrderNum">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                              <asp:BoundField DataField="SMRC_MakeTime" HeaderText="退货单制定时间" SortExpression="SMRC_MakeTime" DataFormatString="{0:yyyy-MM-dd }">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMOD_Time" HeaderText="发货时间" SortExpression="SMOD_Time"  DataFormatString="{0:yyyy-MM-dd }">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCIF_Name" HeaderText="客户名称" SortExpression="CRMCIF_Name">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMSO_ComOrderNum" HeaderText="公司订单号" SortExpression="SMSO_ComOrderNum">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMSO_CusOrderNum" HeaderText="客户订单号" SortExpression="SMSO_CusOrderNum" >
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
                        </PagerTemplate>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label50" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <table width="100%">
                        <tr>
                            <td style="width: 50%" align="center">
                                <asp:Button ID="Button28" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    OnClick="InsertReturn" Width="70px" />
                            </td>
                            <td style="width: 50%" align="center">
                                <asp:Button ID="Button29" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="CanelReturnD" Width="70px" />
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--采购订单结束--%>
                 <%--   采购订单开始--%>
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel8" runat="server" Visible="false">
                <fieldset>
                    <legend>随工单检索</legend>
                    <table style="width: 100%;">
                        <asp:Label ID="label48" runat="server" Visible="False"></asp:Label>
                        
                        <tr>
                            <td style="width: 15%" align="center">
                                <asp:Label ID="Label49" runat="server" Text="随工单号："></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                    <asp:TextBox runat="server" ID="TextBox32"> </asp:TextBox>
                            </td>
                            <td style="width: 15%" align="center">
                                <asp:Label ID="Label51" runat="server" Text="产品型号："></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:TextBox runat="server" ID="TextBox33"> </asp:TextBox>
                            </td>
                            <td style="width: 15%" align="center">
                                <asp:Label ID="Label52" runat="server" Text="随工单状态："></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:TextBox runat="server" ID="TextBox34" Enabled="false" Text="待入库"> </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" align="center">
                                <asp:Button ID="Button30" runat="server" Text="检索" CssClass="Button02" Height="24px"
                                    OnClick="SelectSuigongdan" Width="70px" />
                            </td>
                            <td colspan="3" align="center">
                                <asp:Button ID="Button31" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="ColseSuigongdan" Width="70px" />
                            </td>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
            <asp:Panel ID="Panel9" runat="server" Visible="false">
                <fieldset>
                    <legend>随工单列表</legend>
                    <asp:GridView ID="Gridview2" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle"
                        CellPadding="0" UseAccessibleHeader="False" PageSize="10" 
                        AllowPaging="True" AllowSorting="True" Font-Strikeout="False" GridLines="None"
                        DataKeyNames="PT_ID,WO_ID" OnPageIndexChanging="Gridview_Suigongdan_PageIndexChanging"
                        Width="100%" >
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemStyle Width="5%" />
                                <ItemTemplate>
                               <asp:CheckBox ID="CheckBox2" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:BoundField DataField="WO_ID" HeaderText="woid" ReadOnly="True" SortExpression="WO_ID"
                                Visible="False">
                                <ItemStyle />
                            </asp:BoundField>
                                <asp:BoundField DataField="PT_ID" HeaderText="ptid" ReadOnly="True" SortExpression="PT_ID"
                                Visible="False">
                                <ItemStyle/>
                            </asp:BoundField>
                            <asp:BoundField DataField="WO_Num" HeaderText="随工单号" ReadOnly="True"
                                SortExpression="WO_Num" Visible="true">
                                <ItemStyle  />
                            </asp:BoundField>
                              <asp:BoundField DataField="PT_Name" HeaderText="产品型号" ReadOnly="True"
                                SortExpression="PT_Name" Visible="true">
                                <ItemStyle  />
                            </asp:BoundField>
                              <asp:BoundField DataField="WO_Level" HeaderText="档次" ReadOnly="True"
                                SortExpression="WO_Level" Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="WO_SN" HeaderText="周期码" SortExpression="WO_SN">
                                <ItemStyle  />
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
                        </PagerTemplate>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label50" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <table width="100%">
                        <tr>
                            <td style="width: 50%" align="center">
                                <asp:Button ID="Button32" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    OnClick="InsertSuigongdan" Width="70px" />
                            </td>
                            <td style="width: 50%" align="center">
                                <asp:Button ID="Button33" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="CanelSuigongdanD" Width="70px" />
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--采购订单结束--%>
</asp:Content>
