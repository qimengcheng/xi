<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IMOutStore.aspx.cs" Inherits="InventoryMgt_IMOutStore"
    MasterPageFile="~/Other/MasterPage.master" Title="库存管理" %>

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
    


      <%--出库单主表开始--%>
    <asp:UpdatePanel ID="UpdatePanel_OutStore" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_OutStore" runat="server" Visible="true">
                <fieldset>
                    <legend>出库单检索</legend>
                    <table style="width: 100%;">
                        <asp:Label ID="label13" runat="server" Visible="False"></asp:Label> 
                        <tr>
                            <td style="width: 11%" align="center">
                                <asp:Label ID="Label16" runat="server" Text="出库单类型："></asp:Label>
                            </td>
                            <td style="width: 10%" align="left">
                                <asp:DropDownList ID="DropDownList4" runat="server" >
                                </asp:DropDownList>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label17" runat="server" Text="出库单号："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox8"> </asp:TextBox>
                            </td>
                            <td style="width: 15%" align="center">
                                <asp:Label ID="Label18" runat="server" Text="出库单状态："></asp:Label>
                            </td>
                            <td style="width: 55%" align="left">
                                  <asp:DropDownList ID="DropDownList5" runat="server" >
                                      <asp:ListItem>选择状态</asp:ListItem>
                                      <asp:ListItem>待提交</asp:ListItem>
                                      <asp:ListItem>待确认</asp:ListItem>
                                      <asp:ListItem>已完成</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                         <tr>
                            <td  align="center">
                                <asp:Label ID="Label19" runat="server" Text="领取人："></asp:Label>
                            </td>
                            <td  align="left">
                                 <asp:TextBox runat="server" ID="TextBox13"> </asp:TextBox>
                            </td>
                            <td  align="center">
                                <asp:Label ID="Label20" runat="server" Text="出库单位："></asp:Label>
                            </td>
                            <td  align="left">
                                <asp:TextBox runat="server" ID="TextBox9"> </asp:TextBox>
                            </td>
                            
                       
                            <td align="center">
                                <asp:Label ID="Label14" runat="server" Text="出库时间："></asp:Label>
                            </td>
                            <td  align="left" >
                               从 <asp:TextBox runat="server" ID="TextBox10" onfocus="new WdatePicker(this,'%Y-%M-%D' ,true)"
                                    DataFormatString="{0:yyyy-MM-dd}" CssClass="Wdate" Width="40%"></asp:TextBox>
                                    到
                                     <asp:TextBox runat="server" ID="TextBox12" onfocus="new WdatePicker(this,'%Y-%M-%D' ,true)"
                                    DataFormatString="{0:yyyy-MM-dd}" CssClass="Wdate" Width="40%"></asp:TextBox>
                            </td>
                           
                        </tr>
                        <tr>
                         <td colspan="3" align="right">
                                <asp:Button ID="Button15" runat="server" Text="新增出库单" CssClass="Button02" Height="24px"
                                    OnClick="NewOutM" Width="90px" />
                            </td>
                            <td colspan="2" align="center">
                                <asp:Button ID="Button13" runat="server" Text="检索" CssClass="Button02" Height="24px"
                                    OnClick="SelectOutM" Width="80px" />
                            </td>
                            <td  align="left">
                                <asp:Button ID="Button14" runat="server" Text="重置" CssClass="Button02" Height="24px"
                                    OnClick="ColseOutM" Width="80px" />
                            </td>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            <%--</asp:Panel>
            <asp:Panel ID="Panel5" runat="server" Visible="true">--%>
                <fieldset>
                    <legend>出库单主表</legend>
                    <asp:GridView ID="Gridview_OutM" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle"
                        CellPadding="0" UseAccessibleHeader="False" PageSize="10" 
                        AllowPaging="True" AllowSorting="True" Font-Strikeout="False" GridLines="None"
                        DataKeyNames="IMOHM_ID,IMSSBD_ID,IMS_StoreID" OnPageIndexChanging="Gridview_OutM_PageIndexChanging"
                        Width="100%" onrowcommand="Gridview_OutM_RowCommand" 
                        onrowdatabound="Gridview_OutM_RowDataBound" >
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
<%--                            <asp:TemplateField>
                                <ItemStyle Width="5%" />
                                <ItemTemplate>
                               <asp:CheckBox ID="CheckBox2" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            
                            <asp:BoundField DataField="IMOHM_ID" HeaderText="出库单主表ID" ReadOnly="True" SortExpression="IMOHM_ID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMSSBD_ID" HeaderText="出库类别ID" ReadOnly="True"
                                SortExpression="IMSSBD_ID" Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                              <asp:BoundField DataField="IMS_StoreID" HeaderText="出库库房ID" ReadOnly="True"
                                SortExpression="IMS_StoreID" Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                              <asp:BoundField DataField="IMOHM_OutHouseNum" HeaderText="出库单号" ReadOnly="True"
                                SortExpression="IMOHM_OutHouseNum" Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                              <asp:BoundField DataField="IMSSBD_Name" HeaderText="出库类别" ReadOnly="True"
                                SortExpression="IMSSBD_Name" Visible="true">
                                <ItemStyle  />
                            </asp:BoundField>
                             <asp:BoundField DataField="IMS_StoreName" HeaderText="出库库房" SortExpression="IMS_StoreName">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMOHM_State" HeaderText="状态" SortExpression="IMOHM_State">
                                <ItemStyle  />
                            </asp:BoundField>
                              <asp:BoundField DataField="IMOHM_MakeMan" HeaderText="制定人" SortExpression="IMOHM_MakeMan">
                                <ItemStyle />
                            </asp:BoundField>
                               <asp:BoundField DataField="IMOHM_OuthouseTime" HeaderText="制定时间" SortExpression="IMOHM_OuthouseTime"  DataFormatString="{0:yyyy-MM-dd}">
                                <ItemStyle />
                            </asp:BoundField> 
                             <asp:BoundField DataField="IMOHM_OutHouseCompany" HeaderText="出库对象" SortExpression="IMOHM_OutHouseCompany">
                                <ItemStyle />
                            </asp:BoundField> 
                             <asp:BoundField DataField="IMOHM_TakeAwayMan" HeaderText="领取人" SortExpression="IMOHM_TakeAwayMan">
                                <ItemStyle />
                            </asp:BoundField>    
                               <asp:BoundField DataField="IMOHM_TakeAwayMakeSureTime" HeaderText="领取时间" SortExpression="IMOHM_TakeAwayMakeSureTime"  DataFormatString="{0:yyyy-MM-dd}">
                                <ItemStyle />
                            </asp:BoundField>    
                                <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Look2" runat="server" CommandName="Look2" OnClientClick="false"
                                        CommandArgument='<%#Eval("IMOHM_ID")%>'>查看</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                                <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Edit2" runat="server" CommandName="Edit2" OnClientClick="false"
                                        CommandArgument='<%#Eval("IMOHM_ID")%>'>编辑</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                                <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete2" runat="server" CommandName="Delete2" OnClientClick="return confirm('您确认删除该记录吗?')"
                                        CommandArgument='<%#Eval("IMOHM_ID")%>'>删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Out2" runat="server" CommandName="Out2" OnClientClick="return confirm('请输入你的用户名和密码')"
                                        CommandArgument='<%#Eval("IMOHM_ID")%>'>确认出库</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Model2" runat="server" CommandName="Model2" 
                                        CommandArgument='<%#Eval("IMOHM_ID")%>'>填写物流</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="PrintDetail" runat="server" CommandName="PrintDetail" 
                                        CommandArgument='<%#Eval("IMOHM_ID") +","+ Eval("IMSSBD_Name") +","+ Eval("IMS_StoreName")+","+ Eval("IMOHM_OutHouseCompany")+","+ Eval("IMOHM_MakeMan")+","+ Eval("IMOHM_OuthouseTime")+","+ Eval("IMOHM_TakeAwayMan")+","+ Eval("IMOHM_TakeAwayMakeSureTime")+","+ Eval("IMOHM_OutHouseNum")%>'>打印出库单</asp:LinkButton>
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
                    </asp:GridView>              
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--库存检索结束--%>
    <%-- 新建出库单开始--%>
    <asp:UpdatePanel ID="UpdatePanel_NewOutM" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_NewOutM" runat="server" Visible="false">
                <fieldset>
                    <legend>新建出库单</legend>
                      <asp:Label ID="Label45" runat="server"  Visible="false"></asp:Label>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label23" runat="server" Text="出库类别："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                 
                                <asp:DropDownList ID="DropDownList6" runat="server" >   
                                </asp:DropDownList>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label24" runat="server" Text="出库库房："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                               <asp:DropDownList ID="DropDownList7" runat="server" >   
                                </asp:DropDownList>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label25" runat="server" Text="出库对象："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                               <asp:TextBox runat="server" ID="TextBox14" ></asp:TextBox>
                            
                            </td>
                          
                        </tr>
                        <tr>
                            <td colspan="2" align="right">
                                <asp:Button ID="Button16" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    OnClick="ConfirmNewOutM" Width="80px" />
                            </td>
                            <td colspan="2" align="left">
                                
                            </td>
                             <td colspan="2" align="left">
                                <asp:Button ID="Button17" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="CanelNewOutM" Width="80px" />
                            </td>                           
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
   <%-- 出库单新建完毕--%>
     <%-- 新建出库单开始--%>
    <asp:UpdatePanel ID="UpdatePanel_XiaoshouOut" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_XiaoshouOut" runat="server" Visible="false">
                <fieldset>
                    <legend>销售出库单-填写物流方式</legend>
                      <asp:Label ID="Label46" runat="server" Visible="false" ></asp:Label>
                    <table style="width: 100%;">

                         <tr>
                            <td style="width: 20%" align="center">
                                <asp:Label ID="Label51" runat="server" Text="物流方式："></asp:Label>
                            </td>
                            <td style="width: 25%" align="left">
                                 
                              <asp:TextBox runat="server" ID="TextBox24" ></asp:TextBox>
                            </td>
                            <td style="width: 20%" align="center">
                                <asp:Label ID="Label52" runat="server" Text="物流单号："></asp:Label>
                            </td>
                            <td style="width: 25%" align="left">
                                <asp:TextBox runat="server" ID="TextBox23" ></asp:TextBox>
                            </td>
                           
                          
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="Button34" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    OnClick="ConfirmXiaoshou" Width="80px" />
                            </td>
                          
                             <td colspan="2" align="center">
                                <asp:Button ID="Button35" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="CanelXiaoshou" Width="80px" />
                            </td>                           
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
   <%-- 确认出库开始--%>
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" Visible="false">
                <fieldset>
                 <asp:Label ID="Label31" runat="server"  Visible="false"></asp:Label>
                    <legend>确认出库</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 20%" align="center">
                                <asp:Label ID="Label29" runat="server" Text="工号："></asp:Label>
                            </td>
                            <td style="width: 25%" align="left">
                             <asp:TextBox runat="server" ID="TextBox16"  ></asp:TextBox>
                            </td>
                            <td style="width: 20%" align="center">
                                <asp:Label ID="Label30" runat="server" Text="密码："></asp:Label>
                            </td>
                            <td style="width: 25%" align="left">
                            <asp:TextBox runat="server" ID="TextBox17"  TextMode="Password"></asp:TextBox>
                            </td>
                          
                        </tr>
                         <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="Button25" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    OnClick="ConfirmMan" Width="80px" />
                            </td>
                         
                             <td colspan="2" align="center">
                                <asp:Button ID="Button26" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="CanelMan" Width="80px" />
                            </td>                           
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
   <%-- 出库单新建完毕--%>
      <%--出库单主表开始--%>
    <asp:UpdatePanel ID="UpdatePanel_OutD" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_OutD" runat="server" Visible="false">
           <asp:Label ID="label26" runat="server" Visible="False"></asp:Label>
          
              <asp:Label ID="label_Sort" runat="server" Visible="False"></asp:Label>
                <fieldset>
                    <legend><asp:Label ID="label21" runat="server" Visible="true"></asp:Label>的出库单详细表</legend>
                    <asp:Button ID="Button18" runat="server" Text="添加物料" CssClass="Button02" Height="24px"
                                    OnClick="KucunSearch" Width="90px" />
                    <asp:GridView ID="Gridview_OutD" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle"
                        CellPadding="0" UseAccessibleHeader="False" PageSize="10" 
                        AllowPaging="True" AllowSorting="True" Font-Strikeout="False" GridLines="None"
                        DataKeyNames="IMOHD_ID" OnPageIndexChanging="Gridview_OutD_PageIndexChanging"
                        Width="100%" ondatabound="Gridview_OutD_DataBound" OnRowCommand="Gridview_OutD_RowCommand"   >
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
<%--                            <asp:TemplateField>
                                <ItemStyle Width="5%" />
                                <ItemTemplate>
                               <asp:CheckBox ID="CheckBox2" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            
                            <asp:BoundField DataField="IMOHD_ID" HeaderText="出库单详细表ID" ReadOnly="True" SortExpression="IMOHD_ID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMRD_ID" HeaderText="领料单详细ID" ReadOnly="True"
                                SortExpression="IMRD_ID" Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                              <asp:BoundField DataField="IMID_ID" HeaderText="库存详细物料ID" ReadOnly="True"
                                SortExpression="IMID_ID" Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                              <asp:BoundField DataField="IMOHM_ID" HeaderText="出库主表ID" ReadOnly="True"
                                SortExpression="IMOHM_ID" Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                              <asp:BoundField DataField="Name" HeaderText="物料名称" ReadOnly="True"
                                SortExpression="Name" Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                              <asp:BoundField DataField="Model" HeaderText="规格型号" ReadOnly="True"
                                SortExpression="Model" Visible="true">
                                <ItemStyle  />
                            </asp:BoundField>
                             <asp:BoundField DataField="IMOHD_Num" HeaderText="数量" SortExpression="IMOHD_Num">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="unit" HeaderText="单位" SortExpression="unit">
                                <ItemStyle  />
                            </asp:BoundField>
                              <asp:BoundField DataField="IMID_BatchNum" HeaderText="批号" SortExpression="IMID_BatchNum">
                                <ItemStyle />
                            </asp:BoundField>
                               <asp:BoundField DataField="IMID_QA" HeaderText="检验结果" SortExpression="IMID_QA"  >
                                <ItemStyle />
                            </asp:BoundField> 
                             <asp:BoundField DataField="IMID_DownLevelPara" HeaderText="降档参数" SortExpression="IMID_DownLevelPara">
                                <ItemStyle />
                            </asp:BoundField> 
                                <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete3" runat="server" CommandName="Delete3" OnClientClick="false"
                                        CommandArgument='<%#Eval("IMOHD_ID")%>'>删除</asp:LinkButton>
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
                    </asp:GridView>   
                    <table width="100%">
                     <tr>
                         <td style="width:30%" align="center">
                          <asp:Button ID="Button19" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    OnClick="ConfirmOutD" Width="70px" />
                        </td>
                         <td style="width:30%" align="center">
                          <asp:Button ID="Button27" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="CloseOutD" Width="70px" />
                        </td>
                     </tr>
                    </table>           
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--出库单详细结束--%>
        <%-- 领料单检索--%>
    <asp:UpdatePanel ID="UpdatePanel_LingliaoSearch" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_LingliaoSearch" runat="server" Visible="true">
             <asp:Label ID="label_lingliaocondition" runat="server" Visible="False"></asp:Label>
                <fieldset>
                    <legend>领料单检索条件</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label" runat="server" Text="领料单号："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox1"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label15" runat="server" Text="领料人："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox11"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label5" runat="server" Text="领料单状态："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                               
                                <asp:DropDownList ID="DropDownList2" runat="server">
                                    <asp:ListItem>选择状态</asp:ListItem>
                                    <asp:ListItem>待提交</asp:ListItem>
                                    <asp:ListItem>已提交</asp:ListItem>
                                    <asp:ListItem>待审核</asp:ListItem>
                                    <asp:ListItem>已审核</asp:ListItem>
                                    <asp:ListItem>已领料</asp:ListItem>
                                    <asp:ListItem>已审核</asp:ListItem>
                                    <asp:ListItem>审核驳回</asp:ListItem>
                                </asp:DropDownList>
                            
                            </td>
                          
                        </tr>
                        <tr>
                           
                           
                           
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label4" runat="server" Text="领料时间从："></asp:Label>
                            </td>
                            <td align="left" colspan="3">
                                
                                <asp:TextBox runat="server" ID="TextBox5" onfocus="new WdatePicker(this,'%Y-%M-%D' ,true)"
                                    DataFormatString="{0:yyyy-MM-dd}" CssClass="Wdate" Width="43%"></asp:TextBox>
                                到
                                <asp:TextBox runat="server" ID="TextBox6" onfocus="new WdatePicker(this,'%Y-%M-%D' ,true)"
                                    DataFormatString="{0:yyyy-MM-dd}" CssClass="Wdate" Width="43%"></asp:TextBox>
                            </td>
                             <td style="width: 10%" align="center">
                                <asp:Label ID="Label59" runat="server" Text="领料部门："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox26"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="right">
                                <asp:Button ID="Button1" runat="server" Text="新建领料单" CssClass="Button02" Height="24px"
                                    OnClick="NewhLingliao" Width="90px" />
                            </td>
                            <td colspan="2" align="left">
                                
                            </td>
                             <td colspan="2" align="left">
                                <asp:Button ID="Button3" runat="server" Text="检索" CssClass="Button02" Height="24px"
                                    OnClick="SearchLingliao" Width="70px" />
                            </td>
                            
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
  
    <%--领料单主表--%>
     <asp:UpdatePanel ID="UpdatePanel_lingliaoMain" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_lingliaoMain" runat="server" Visible="true">  
                  <asp:Label ID="label_lingliaoMainID" runat="server" Visible="true"></asp:Label>
                <fieldset>
                    <legend>领料单主表</legend>
                    <asp:GridView ID="Gridview_lingliaoMain" runat="server" AutoGenerateColumns="False"
                        CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False" 
                        PageSize="10" AllowPaging="True" AllowSorting="True" DataKeyNames="IMRM_RequisitionID,WO_ID,IMS_StoreID"
                        GridLines="None" Width="100%" OnPageIndexChanging="Gridview_lingliaoMain_PageIndexChanging"
                        OnRowCommand="Gridview_lingliaoMain_RowCommand" 
                        onrowdatabound="Gridview_lingliaoMain_RowDataBound" >
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <%--    //隔行变色--%>
                        <Columns>
                         <asp:TemplateField Visible="false">
                                <ItemStyle Width="5%" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="IMRM_RequisitionID" HeaderText="领料单ID" ReadOnly="True" SortExpression="IMRM_RequisitionID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>

                            <asp:BoundField DataField="WO_ID" HeaderText="随工单ID" ReadOnly="True" SortExpression="WO_ID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMS_StoreID" HeaderText="库房ID" ReadOnly="True" SortExpression="IMS_StoreID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMRM_RequisitionNum" HeaderText="领料单号" ReadOnly="True" SortExpression="IMRM_RequisitionNum">
                                <ItemStyle />
                            </asp:BoundField>
                              <asp:BoundField DataField="IMRM_RequisitionSort" HeaderText="类型" SortExpression="IMRM_RequisitionSort">
                                <ItemStyle />
                            </asp:BoundField>
                             <asp:BoundField DataField="IMRM_RequisitionState" HeaderText="状态" SortExpression="IMRM_RequisitionState">
                                <ItemStyle />
                            </asp:BoundField>
                             <asp:BoundField DataField="IMRM_Depart" HeaderText="部门" ReadOnly="True"
                                SortExpression="IMRM_Depart">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMRM_Man" HeaderText="制定人" ReadOnly="True" SortExpression="IMRM_Man">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMRM_RequisitionTime" HeaderText="制定时间" ReadOnly="True" SortExpression="IMRM_RequisitionTime"   DataFormatString="{0:yyyy-MM-dd }">
                                <ItemStyle />
                            </asp:BoundField>
                           
                            <asp:BoundField DataField="IMRM_WorkStation" HeaderText="工位" ReadOnly="True" SortExpression="IMRM_WorkStation" >
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Look1" runat="server" CommandName="Look1" OnClientClick="false"
                                        CommandArgument='<%#Eval("IMRM_RequisitionID")%>'>查看</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete1" runat="server" CommandName="Delete1" OnClientClick="return confirm('您确认删除该记录吗?')"
                                        CommandArgument='<%#Eval("IMRM_RequisitionID")%>'>删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                               <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Edit1" runat="server" CommandName="Edit1" OnClientClick="false"
                                        CommandArgument='<%#Eval("IMRM_RequisitionID")%>'>编辑</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                               <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Check1" runat="server" CommandName="Check1" OnClientClick="false"
                                        CommandArgument='<%#Eval("IMRM_RequisitionID")%>'>审核</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                               <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Check1_Look" runat="server" CommandName="Check1_Look" OnClientClick="false"
                                        CommandArgument='<%#Eval("IMRM_RequisitionID")%>'>查看审核</asp:LinkButton>
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
          
            <table id="table1" runat="server" width="95%" >
                <tr>
                     <td style="width: 30%" align="center">
                  <asp:Button ID="Button11" runat="server" Text="加入汇总计算" CssClass="Button02" Height="24px"
                                    OnClick="InsertLingliao" Width="90px" />      已选<asp:Label ID="Label12" runat="server" Text=""></asp:Label>个领料单
                    </td>
                    <td style="width: 30%" align="center">
                  <asp:Button ID="Button2" runat="server" Text="查看汇总结果" CssClass="Button02" Height="24px"
                                    OnClick="SumLingliao" Width="90px" />
                    </td>
                    <td style="width: 30%" align="center">
                  <asp:Button ID="Button4" runat="server" Text="插入出库单" CssClass="Button02" Height="24px"
                                    OnClick="ConventhLingliao" Width="90px" />
                    </td>
                </tr>
            
            </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
   <%-- 领料单主表完毕--%>
     <%-- 新建领料单检索--%>
    <asp:UpdatePanel ID="UpdatePanel_NewLingliao" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_NewLingliao" runat="server" Visible="false">
             <asp:Label ID="label6" runat="server" Visible="False"></asp:Label>
         
                <fieldset>
                    <legend>新建领料单</legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label7" runat="server" Text="领料人："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox2" Enabled="false"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label8" runat="server" Text="领料部门："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox7" Enabled="false"></asp:TextBox>
                            </td>
                            <td style="width: 10%" align="center">
                                <asp:Label ID="Label9" runat="server" Text="库房："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                               
                                <asp:DropDownList ID="DropDownList3" runat="server" >   
                                </asp:DropDownList>
                            
                            </td>
                          
                        </tr>
                        <tr>
                            <td colspan="2" align="right">
                                <asp:Button ID="Button7" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    OnClick="NewhLingliaoMain" Width="70px" />
                            </td>
                            <td colspan="2" align="left">
                                
                            </td>
                             <td colspan="2" align="left">
                                <asp:Button ID="Button9" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="CanelhLingliaoMain" Width="70px" />
                            </td>                           
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
   <%-- 领料单新建完毕--%>
       <%--领料单审核部分--%>
    <asp:UpdatePanel ID="UpdatePanel_Sign" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Sign" runat="server" Visible="false">
                <fieldset>
                    <legend>
                        <asp:Label ID="label22" runat="server" Visible="true"></asp:Label>领料单审核栏</legend> <asp:Label ID="label10" runat="server" Visible="false"></asp:Label>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 15%">
                            
                            </td>
                            <td style="width: 15%">
                                审核人:
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TB_shengchanman" runat="server" Width="100%" ReadOnly="true" Enabled="False"></asp:TextBox>
                            </td>
                            <td style="width: 20%" align="right">
                                审核时间:
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="TB_shengchantime" runat="server" Width="98%" ReadOnly="true" DataFormatString="{0:yyyy-MM-dd HH:mm}"
                                    Enabled="False"></asp:TextBox>
                            </td>
                            <td style="width: 15%">
                            </td>
                            <td style="width: 10%">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="LB1004" runat="server" ForeColor="#999999" Text="100字以内" Style="visibility: hidden;"></asp:Label>
                            </td>
                            <td>
                                审核意见:
                            </td>
                            <td colspan="7">
                                <asp:TextBox ID="TB_lingdaoyijian" runat="server" Height="80px" MaxLength="200" onblur="javascript:leave('LB1004');"
                                    onfocus="annotation('LB1004');" TextMode="MultiLine" Width="99%" onkeyup="this.value = this.value.slice(0, 150)" ></asp:TextBox>
                            </td>
                        </tr>
                     
                        <table style="width: 100%">
                            <tr>
                                <td style="width: 33%; text-align: right">
                                    <asp:Button ID="BT_TKOK" runat="server" CssClass="Button02" OnClick="BT_TKOK_Click" Height="24px"
                                        Text="通过" Width="80px" />
                                    <%--    OnClientClick="$find('gvEdit').hide();"--%>
                                </td>
                                <td style="width: 34%; text-align: center">
                                    <asp:Button ID="BT_TKNotOK" runat="server" CssClass="Button02" OnClick="BT_TKNotOK_Click" Height="24px"
                                        Text="驳回" Width="80px" />
                                </td>
                                <td style="width: 33%; text-align: left">
                                    <asp:Button ID="BT_TKCancel" runat="server" CssClass="Button02" OnClick="BT_TKCanel_Click" Height="24px"
                                        Text="关闭" Width="80px" />
                                </td>
                        </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--领料单详细表--%>
     <asp:UpdatePanel ID="UpdatePanel_LingliaoD" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_lingliaoD" runat="server" Visible="true">  
                  <asp:Label ID="label2" runat="server" Visible="False"></asp:Label>
                <fieldset>
                    <legend><asp:Label ID="label11" runat="server" Visible="true"></asp:Label>领料单详细表</legend>
                    <asp:Button ID="Button10" runat="server" Text="选择物料" CssClass="Button02" Height="24px"
                                    OnClick="SelectKucun" Width="80px" />
                    <asp:GridView ID="Gridview_LingliaoD" runat="server" AutoGenerateColumns="False"
                        CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False" BorderColor="#C0DE98"
                        PageSize="10" AllowPaging="True" AllowSorting="True" DataKeyNames="IMRD_ID"
                        GridLines="None" Width="100%" OnPageIndexChanging="Gridview_LingliaoD_PageIndexChanging"

                          OnRowCancelingEdit="Gridview_LingliaoD_RowCancelingEdit" OnRowDeleting="Gridview_LingliaoD_RowDeleting"
                        OnRowEditing="Gridview_LingliaoD_RowEditing" 
                        OnRowUpdating="Gridview_LingliaoD_RowUpdating" 
                        ondatabound="Gridview_LingliaoD_DataBound" 
                      >
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <%--    //隔行变色--%>
                        <Columns>
                            <asp:BoundField DataField="IMRD_ID" HeaderText="领料单详细ID" ReadOnly="True" SortExpression="IMRD_ID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>

                            <asp:BoundField DataField="IMRM_RequisitionID" HeaderText="领料单ID" ReadOnly="True" SortExpression="IMRM_RequisitionID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMIM_ID" HeaderText="库存ID" ReadOnly="True" SortExpression="IMIM_ID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_MaterialName" HeaderText="物料名称" ReadOnly="True" SortExpression="IMMBD_MaterialName">
                                <ItemStyle />
                            </asp:BoundField>
                           <asp:BoundField DataField="PT_Name" HeaderText="产品名称" ReadOnly="True" SortExpression="PT_Name">
                                <ItemStyle />
                            </asp:BoundField>
                              <asp:BoundField DataField="IMMBD_SpecificationModel" HeaderText="规格型号" ReadOnly="True" SortExpression="IMMBD_SpecificationModel">
                                <ItemStyle />
                            </asp:BoundField>
                             <asp:BoundField DataField="IMRD_StandardNum" HeaderText="标准用量" ReadOnly="True" SortExpression="IMRD_StandardNum">
                                <ItemStyle />
                            </asp:BoundField>
                             <asp:BoundField DataField="IMRD_ActualNum" HeaderText="实际用量" 
                                SortExpression="IMRD_ActualNum">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMRD_WorkOrderNum" HeaderText="随工单号" ReadOnly="True" SortExpression="IMRD_WorkOrderNum">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMRD_Remark" HeaderText="备注"  SortExpression="IMRD_Remark"   >
                                <ItemStyle  Width="20%"/>
                            </asp:BoundField>                     
                          <asp:CommandField ShowEditButton="True" EditText="编辑" UpdateText="更新" CancelText="取消" />
                            <asp:CommandField ShowDeleteButton="True" DeleteText="删除"  />
                              <asp:BoundField DataField="Unit" HeaderText="单位"  SortExpression="Unit"   >
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
                        <AlternatingRowStyle />
                    </asp:GridView>
                    <table width="100%">
                        <tr>
                            <td style="width: 30%" align="center">
                                <asp:Button ID="Button5" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    OnClick="ConfirmLingliaoD" Width="80px" />
                            </td>
                            <td style="width: 30%" align="center">
                                <asp:Button ID="Button6" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="CanelLingliaoD" Width="80px" />
                            </td>
                        </tr>
                    </table>

            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
   <%-- 领料单详细表完毕--%>
      <%--领料单汇总详细表--%>
     <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel2" runat="server" Visible="false">  
                  <asp:Label ID="label3" runat="server" Visible="False"></asp:Label>
                <fieldset>
                    <legend>领料单详细汇总表</legend>
                    <asp:GridView ID="Gridview1" runat="server" AutoGenerateColumns="False"
                        CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False" 
                        PageSize="10" AllowPaging="True" AllowSorting="True" DataKeyNames="IMIM_ID"
                        GridLines="None" Width="100%" 
                        OnPageIndexChanging="Gridview_LingliaoSum_PageIndexChanging" 
                        onrowcommand="Gridview1_RowCommand" >
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <%--    //隔行变色--%>
                        <Columns>
                            <asp:BoundField DataField="IMIM_ID" HeaderText="库存ID" ReadOnly="True" SortExpression="IMIM_ID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Name" HeaderText="物料名称" ReadOnly="True" SortExpression="Name">
                                <ItemStyle />
                            </asp:BoundField>
                         
                              <asp:BoundField DataField="Model" HeaderText="规格型号" SortExpression="Model">
                                <ItemStyle />
                            </asp:BoundField>
                             <asp:BoundField DataField="SN" HeaderText="标准总用量" SortExpression="SN">
                                <ItemStyle />
                            </asp:BoundField>
                             <asp:BoundField DataField="AN" HeaderText="实际总用量" ReadOnly="True"
                                SortExpression="AN">
                                <ItemStyle />
                            </asp:BoundField>
                               <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Select1" runat="server" CommandName="Select1" 
                                        CommandArgument='<%#Eval("IMIM_ID")%>'>选择库存明细</asp:LinkButton>
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
                         <table width="100%">
                        <tr>
                            <td style="width: 50%" align="center">
                                <asp:Button ID="Button12" runat="server" Text="清零" CssClass="Button02" Height="24px"
                                    OnClick="ZeroLingliaoSum" Width="80px" />
                            </td>
                            <td style="width: 50%" align="center">
                                <asp:Button ID="Button8" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="CanelLingliaoSum" Width="80px" />
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
   <%-- 领料单详细表完毕--%>
   
     <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel4" runat="server" Visible="false">
                <asp:Label ID="Label44" runat="server"  Visible="false"></asp:Label>
                <asp:Label ID="Label47" runat="server"  Visible="false"></asp:Label>
                <fieldset>
                    <legend>发货计划检索条件</legend>
                    <table style="width: 100%;">
                        <tr>
                       
                            <td style="width: 15%" align="center">
                               发货计划日期：
                            </td>
                            <td align="center" style="width: 20%">
                                 <asp:TextBox runat="server" ID="TextBox20" onfocus="new WdatePicker(this,'%Y-%M-%D ',true)"
                                    DataFormatString="{0:yyyy-MM-dd}" Width="98px" CssClass="Wdate" ></asp:TextBox>
                            </td>
                             <td style="width: 15%" align="center">
                               客户名称：
                            </td>
                            <td align="center" style="width: 20%">
                                 <asp:TextBox runat="server" ID="TextBox22"  Width="98px" ></asp:TextBox>
                            </td>
                            <td  align="left">
                                <asp:Button ID="Button31" runat="server" Text="检索" CssClass="Button02" Height="24px"
                                    OnClick="SearchDeliverPlan" Width="80px" />
                                
                            </td>
                            <td  align="left">
                                <asp:Button ID="Button32" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="CloseDeliverPlan" Width="80px" />
                                
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
   <%-- 发货计划表--%>
     <asp:UpdatePanel ID="UpdatePanel_OrderDeliverPlan" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_OrderDeliverPlan" runat="server" Visible="false">
                <fieldset>
                    <legend>发货计划表</legend>
                    <asp:GridView ID="GridView_OrderDeliverPlan" runat="server" AllowPaging="True" PageSize="20"
                        AutoGenerateColumns="False" CellPadding="0" CssClass="GridViewStyle" DataKeyNames="SMDP_ID,SMSOD_ID,PT_ID"
                        AllowSorting="True" 
                        Width="100%"  GridLines="None"
                        OnPageIndexChanging="GridView_OrderDeliverPlan_PageIndexChanging" 
                        onrowcommand="GridView_OrderDeliverPlan_RowCommand" >
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                        <asp:TemplateField Visible="false">
                                <ItemStyle Width="5%" />
                                <ItemTemplate>
                               <asp:CheckBox ID="CheckBox2" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="SMDP_ID" HeaderText="发货计划ID" Visible="false" />
                            <asp:BoundField DataField="PT_ID" HeaderText="PTID" Visible="false" />
                               <asp:BoundField DataField="SMSOD_ID" HeaderText="订单详细ID" Visible="false" />
                              <asp:BoundField DataField="SMDP_Time" HeaderText="计划日期" ReadOnly="True"  DataFormatString="{0:yyyy-MM-dd}"/>
                            <asp:BoundField DataField="CRMCIF_Name" HeaderText="客户名称" ReadOnly="True" />
                            <asp:BoundField DataField="SMSO_ComOrderNum" HeaderText="订单号" ReadOnly="True"/>  
                            <asp:BoundField DataField="SMSOD_OrderDelTime" HeaderText="订单交货期" ReadOnly="True" DataFormatString="{0:yyyy-MM-dd }" />
                             <asp:BoundField DataField="SMSOD_OrderAdvanceDelTime" HeaderText="预交货期" ReadOnly="True" DataFormatString="{0:yyyy-MM-dd}"/>
                            <asp:BoundField DataField="PT_Name" HeaderText="产品型号" ReadOnly="True" />
                             <asp:BoundField DataField="SMSOD_Mount" HeaderText="订单数量" ReadOnly="true" />
                            <asp:BoundField DataField="SMDP_Num" HeaderText="数量" />
                            <asp:BoundField DataField="SMDP_MakeTime" HeaderText="制定时间" ReadOnly="True" DataFormatString="{0:yyyy-MM-dd HH:mm}"/>
                            <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Select2" runat="server" CommandName="Select2" OnClientClick="false" 
                                        CommandArgument='<%#Eval("SMDP_ID")%>'>选择库存详细</asp:LinkButton> 
                                         
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
                            <asp:Label ID="Label16" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <table width="100%">
                    <tr><td>操作提示：1.每次使用“生成出库单”按钮，只可以勾选同一客户的订单进行统一出库</td>   </tr>
                    <tr><td>&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    2.如果你要发送的订单不在发货计划单内，请返回发货计划制定页面添加</td>   </tr>
                     <tr><td>&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </table>
                        <table width="100%"> <tr>
                        <td style="width:35%" align="center">
                                                           <asp:CheckBox ID="Cbx2_SelectAll" runat="server" Text="全选" AutoPostBack="true" OnCheckedChanged="Cbx2_SelectAll_CheckedChanged"  Visible="false"/>
                                  <%--  <asp:Button ID="Button32" runat="server" Text="选择对应库存" CssClass="Button02" Height="24px"
                                    OnClick="NewSalseOutMain" Width="80px" />--%>
                                    <asp:Button ID="Button33" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    OnClick="ConfirmSalseOutDetail" Width="80px" Visible="true" /></td>
                                    
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
       <%--库存检索开始--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_kucun" runat="server" Visible="true">
                <fieldset>
                    <legend>库存物料检索</legend>
                    <table style="width: 100%;">
                        <asp:Label ID="label38" runat="server" Visible="False"></asp:Label>
                           <asp:Label ID="label_OutHouseMID" runat="server" Visible="False"></asp:Label>
                           <asp:Label ID="label1" runat="server" Visible="False"></asp:Label>
                        <tr>
                            <td style="width: 15%" align="center">
                                <asp:Label ID="Label40" runat="server" Text="物料类型："></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                      <asp:DropDownList ID="DropDownList1" runat="server" 
                                          onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                                          AutoPostBack="True">
                                    <asp:ListItem>基础物料</asp:ListItem>
                                    <asp:ListItem>公司产品</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="width: 15%" align="center">
                                <asp:Label ID="Label41" runat="server" Text="物料名称："></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:TextBox runat="server" ID="TextBox3"> </asp:TextBox>
                            </td>
                            <td style="width: 15%" align="center">
                                <asp:Label ID="Label42" runat="server" Text="规格型号："></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:TextBox runat="server" ID="TextBox4"> </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" align="center">
                                <asp:Button ID="Button22" runat="server" Text="检索" CssClass="Button02" Height="24px"
                                    OnClick="SelectMat" Width="80px" />
                            </td>
                            <td colspan="3" align="center">
                                <asp:Button ID="Button23" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="ColseMat" Width="80px" />
                            </td>
                            </td>
                        </tr>
                    </table>
                </fieldset>
           <%-- </asp:Panel>
            <asp:Panel ID="Panel_kucun1" runat="server" Visible="true">--%>
                <fieldset>
                 <asp:Label ID="label_SourceSort" runat="server" Visible="False"></asp:Label>
                    <legend>库存列表</legend>
                    <asp:GridView ID="Gridview_Pur" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle"
                        CellPadding="0" UseAccessibleHeader="False" PageSize="10" 
                        AllowPaging="True" AllowSorting="True" Font-Strikeout="False" GridLines="None"
                        DataKeyNames="IMIM_ID,IMMBD_MaterialID,PT_ID" OnPageIndexChanging="Gridview_Pur_PageIndexChanging"
                        Width="100%" onrowcommand="Gridview_Pur_RowCommand" >
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
                            
                            <asp:BoundField DataField="IMIM_ID" HeaderText="库存主表ID" ReadOnly="True" SortExpression="IMIM_ID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMMBD_MaterialID" HeaderText="物料ID" ReadOnly="True"
                                SortExpression="IMMBD_MaterialID" Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                              <asp:BoundField DataField="PT_ID" HeaderText="产品ID" ReadOnly="True"
                                SortExpression="PT_ID" Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                              <asp:BoundField DataField="Name" HeaderText="物料名称" ReadOnly="True"
                                SortExpression="Name" Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                              <asp:BoundField DataField="Model" HeaderText="规格型号" ReadOnly="True"
                                SortExpression="Model" Visible="true">
                                <ItemStyle  />
                            </asp:BoundField>
                             <asp:BoundField DataField="IMIM_Level" HeaderText="档次" SortExpression="IMIM_Level">
                                <ItemStyle />
                            </asp:BoundField>
                              <asp:BoundField DataField="Unit" HeaderText="单位" ReadOnly="True"
                                SortExpression="Unit" Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMIM_TotalNum" HeaderText="总数量" SortExpression="IMIM_TotalNum">
                                <ItemStyle  />
                            </asp:BoundField>
                              <asp:BoundField DataField="IMIM_ActualArrangeNum" HeaderText="已分配数量" SortExpression="IMIM_ActualArrangeNum">
                                <ItemStyle />
                            </asp:BoundField>  
                                         <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Look5" runat="server" CommandName="Look5" OnClientClick="false"
                                        CommandArgument='<%#Eval("IMIM_ID")%>'>查看</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>              
                                      <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Choose5" runat="server" CommandName="Choose5" OnClientClick="false"
                                        CommandArgument='<%#Eval("IMIM_ID")%>'>选择明细</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Pandian5" runat="server" CommandName="Pandian5" OnClientClick="false"
                                        CommandArgument='<%#Eval("IMIM_ID")%>'>进行盘点</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LookPandian5" runat="server" CommandName="LookPandian5" OnClientClick="false"
                                        CommandArgument='<%#Eval("IMIM_ID")%>'>查看盘点</asp:LinkButton>
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
                    </asp:GridView>
                    <table width="100%">
                        <tr>
                            <td style="width: 95%" align="center">
                                <asp:Button ID="Button24" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    OnClick="InsertIMIM" Width="80px" />
                            </td>
                           <%-- <td style="width: 50%" align="center">
                                <asp:Button ID="Button25" runat="server" Text="取消" CssClass="Button02" Height="24px"
                                    OnClick="CanelIMIM" Width="80px" />
                            </td>--%>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Button10" EventName="Click"/>
        </Triggers>
    </asp:UpdatePanel>
    <%--库存检索结束--%>
         <%--库存详细表开始--%>
    <asp:UpdatePanel ID="UpdatePanel_KucunD" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_KucunD" runat="server" Visible="false">
           <asp:Label ID="label27" runat="server" Visible="False"></asp:Label>
           <asp:Label ID="label54" runat="server" Visible="False"></asp:Label>
              
                <fieldset> 
                     <table>
                        <tr>
                            <td style="width: 30%"> </td>
                           <td style="width: 20%" align="center">
                                <asp:Label ID="Label57" runat="server" Text="批号："></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:TextBox runat="server" ID="TextBox21"> </asp:TextBox>
                            </td>
                              <td style="width: 95%" align="center">
                                <asp:Button ID="Button38" runat="server" Text="检索" CssClass="Button02" Height="24px"
                                    OnClick="Select_BatchNum" Width="80px" />
                            </td>
                        </tr>

                </table>
                    <legend><asp:Label ID="label28" runat="server" Visible="true"></asp:Label>的库存详细表</legend>
                    <asp:GridView ID="Gridview_Kucun" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle"
                        CellPadding="0" UseAccessibleHeader="False" PageSize="10" 
                        AllowPaging="True" AllowSorting="True" GridLines="None"
                        DataKeyNames="IMID_ID" OnPageIndexChanging="Gridview_KucunD_PageIndexChanging"
                        Width="100%" ondatabound="Gridview_Kucun_DataBound" 
                        onrowdatabound="Gridview_Kucun_RowDataBound"  >
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemStyle Width="3%" />
                                <ItemTemplate>
                               <asp:CheckBox ID="CheckBox2" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:BoundField DataField="IMID_ID" HeaderText="库存详细ID" ReadOnly="True" SortExpression="IMID_ID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PMSI_SupplyName" HeaderText="供应商" ReadOnly="True"
                                SortExpression="PMSI_SupplyName" >
                                <ItemStyle/>
                            </asp:BoundField>
                           
                              <asp:BoundField DataField="IMS_StoreName" HeaderText="库房" ReadOnly="True"
                                SortExpression="IMS_StoreName" Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                              <asp:BoundField DataField="IMSA_AreaName" HeaderText="库存区域" ReadOnly="True"
                                SortExpression="IMSA_AreaName" Visible="true">
                                <ItemStyle  />
                            </asp:BoundField>
                             <asp:BoundField DataField="IMID_Num" HeaderText="数量" SortExpression="IMID_Num">
                                <ItemStyle />
                            </asp:BoundField>
                              <asp:BoundField DataField="IMID_BatchNum" HeaderText="批号" SortExpression="IMID_BatchNum">
                                <ItemStyle />
                            </asp:BoundField>
                             <asp:BoundField DataField="IMID_InHouseTime" HeaderText="入库时间" SortExpression="IMID_InHouseTime" DataFormatString="{0:yyyy-MM-dd}">
                                <ItemStyle />
                            </asp:BoundField>
                               <asp:BoundField DataField="IMID_QA" HeaderText="检验结果" SortExpression="IMID_QA"  >
                                <ItemStyle />
                            </asp:BoundField> 
                             <asp:BoundField DataField="IMID_DownLevel" HeaderText="是否降档" SortExpression="IMID_DownLevel"  >
                                <ItemStyle />
                            </asp:BoundField> 
                             <asp:BoundField DataField="IMID_DownLevelPara" HeaderText="降档参数" SortExpression="IMID_DownLevelPara">
                                <ItemStyle />
                            </asp:BoundField> 
                                <asp:TemplateField Visible="true" HeaderText="出库数量">
                                <ItemTemplate >
                                     <asp:TextBox runat="server" ID="TextBox8" Width="95px" Enabled="true"   onkeyup="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{3,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{3})[0-9]*/, '$1');" 
                              onafterpaste="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{3,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{3})[0-9]*/, '$1');"> </asp:TextBox>
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
                    </asp:GridView>   
                    <table width="100%">
                     <tr>
                        <td style="width:50%" align="center">
                          <asp:Button ID="Button20" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    OnClick="ConfirmStoreD" Width="80px" />
                        </td>
                         <td style="width:50%" align="center">
                          <asp:Button ID="Button21" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="CloseStoreD" Width="80px" />
                        </td>
                     </tr>
                    </table>           
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--库存详细结束--%>
       <%--用于销售出库库存详细表开始--%>
    <asp:UpdatePanel ID="UpdatePanel_XiaoshouKucun" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_XiaoshouKucun" runat="server" Visible="false">
           <asp:Label ID="label55" runat="server" Visible="False"></asp:Label>
           <asp:Label ID="label48" runat="server" Visible="False"></asp:Label>
             <asp:Label ID="label49" runat="server" Visible="False"></asp:Label>
             <asp:Label ID="label53" runat="server" Visible="False"></asp:Label>
                <fieldset>
                           <table>
                        <tr>
                            <td style="width: 30%"> </td>
                           <td style="width: 20%" align="center">
                                <asp:Label ID="Label58" runat="server" Text="批号："></asp:Label>
                            </td>
                            <td style="width: 20%" align="left">
                                <asp:TextBox runat="server" ID="TextBox25"> </asp:TextBox>
                            </td>
                              <td style="width: 95%" align="center">
                                <asp:Button ID="Button39" runat="server" Text="检索" CssClass="Button02" Height="24px"
                                    OnClick="Select_BatchNum1" Width="80px" />
                            </td>
                        </tr>

                </table>
                    <legend><asp:Label ID="label56" runat="server" Visible="true"></asp:Label>的库存详细表</legend>
                    <asp:GridView ID="Gridview2" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle"
                        CellPadding="0" UseAccessibleHeader="False" PageSize="10" 
                        AllowPaging="True" AllowSorting="True" Font-Strikeout="False" GridLines="None"
                        DataKeyNames="IMID_ID" OnPageIndexChanging="Gridview_KucunD1_PageIndexChanging"
                        Width="100%"   >
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemStyle Width="3%" />
                                <ItemTemplate>
                               <asp:CheckBox ID="CheckBox2" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:BoundField DataField="IMID_ID" HeaderText="库存详细ID" ReadOnly="True" SortExpression="IMID_ID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PT_Name" HeaderText="产品型号" ReadOnly="True"
                                SortExpression="PT_Name" >
                                <ItemStyle/>
                            </asp:BoundField>
                           
                              <asp:BoundField DataField="IMS_StoreName" HeaderText="库房" ReadOnly="True"
                                SortExpression="IMS_StoreName" Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                              <asp:BoundField DataField="IMSA_AreaName" HeaderText="库存区域" ReadOnly="True"
                                SortExpression="IMSA_AreaName" Visible="true">
                                <ItemStyle  />
                            </asp:BoundField>
                             <asp:BoundField DataField="IMID_Num" HeaderText="数量" SortExpression="IMID_Num">
                                <ItemStyle />
                            </asp:BoundField>
                              <asp:BoundField DataField="IMID_BatchNum" HeaderText="批号" SortExpression="IMID_BatchNum">
                                <ItemStyle />
                            </asp:BoundField>
                             <asp:BoundField DataField="IMID_InHouseTime" HeaderText="入库时间" SortExpression="IMID_InHouseTime" DataFormatString="{0:yyyy-MM-dd}">
                                <ItemStyle />
                            </asp:BoundField>
                                <asp:TemplateField Visible="true" HeaderText="出库数量">
                                <ItemTemplate >
                                     <asp:TextBox runat="server" ID="TextBox8" Width="95px" Enabled="true"  onkeyup="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{3,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{3})[0-9]*/, '$1');" 
                              onafterpaste="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{3,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{3})[0-9]*/, '$1');"> </asp:TextBox>
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
                    </asp:GridView>   
                    <table width="100%">
                     <tr>
                        <td style="width:30%" align="center">
                          <asp:Button ID="Button36" runat="server" Text="提交" CssClass="Button02" Height="24px"
                                    OnClick="ConfirmStoreD1" Width="80px" />
                        </td>
                       
                         <td style="width:30%" align="center">
                          <asp:Button ID="Button37" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="CloseStoreD1" Width="80px" />
                        </td>
                     </tr>
                    </table>           
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--用于销售出库的库存详细结束--%>

       <%--库存盘点开始--%>
    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel3" runat="server" Visible="false">
                <fieldset>
                    <legend>库存盘点结果检索</legend>
                    <table style="width: 100%;">
                        <asp:Label ID="label32" runat="server" Visible="False"></asp:Label>
                           <asp:Label ID="label33" runat="server" Visible="False"></asp:Label>
                        <tr>
                            <td style="width: 15%" align="center">
                                <asp:Label ID="Label35" runat="server" Text="年份："></asp:Label>
                            </td>
                            <td style="width: 10%" align="left">
                                     <asp:TextBox ID="TextBox18" runat="server"></asp:TextBox>
                            </td>
                             <td style="width: 15%" align="center">
                                <asp:Label ID="Label34" runat="server" Text="月份："></asp:Label>
                            </td>
                            <td style="width: 10%" align="left">
                                   <asp:TextBox ID="TextBox19" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 15%" align="center">
                                <asp:Label ID="Label36" runat="server" Text="周次："></asp:Label>
                            </td>
                            <td style="width: 10%" align="left">
                                
                                <asp:TextBox ID="TextBox15" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 15%" align="center">
                                <asp:Label ID="Label37" runat="server" Text="盘点结果："></asp:Label>
                            </td>
                            <td style="width: 10%" align="left">
                                <asp:DropDownList ID="DropDownList10" runat="server">
                                  <asp:ListItem>选择结果</asp:ListItem>
                                    <asp:ListItem>账实相符</asp:ListItem>
                                    <asp:ListItem>盘亏</asp:ListItem>
                                    <asp:ListItem>盘盈</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center">
                                <asp:Button ID="Button28" runat="server" Text="检索" CssClass="Button02" Height="24px"
                                    OnClick="SelectPandian" Width="80px" />
                            </td>
                            <td colspan="4" align="center">
                                <asp:Button ID="Button29" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="ColsePandian" Width="80px" />
                            </td>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
            <asp:Panel ID="Panel5" runat="server" Visible="false">
                <fieldset>
                 <asp:Label ID="label39" runat="server" Visible="False"></asp:Label>
                    <legend>库存盘点列表</legend>
                    <asp:Label ID="label43" runat="server" Visible="false" Text="为保证数据准确，进行盘点时请避免进行出入库操作。系统读取的账面数量为实时数据。"
                      ForeColor="Red" ></asp:Label>
                    <asp:GridView ID="GridviewPandian" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle"
                        CellPadding="0" UseAccessibleHeader="False" PageSize="10" 
                        AllowPaging="True" AllowSorting="True" Font-Strikeout="False" GridLines="None"
                        DataKeyNames="IMC_ID" OnPageIndexChanging="Gridview_Pandian_PageIndexChanging"
                        Width="100%" onrowcommand="Gridview_Pandian_RowCommand" 
                        onrowcancelingedit="GridviewPandian_RowCancelingEdit" 
                        onrowediting="GridviewPandian_RowEditing" 
                        onrowupdating="GridviewPandian_RowUpdating" 
                        onrowdatabound="GridviewPandian_RowDataBound" >
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="IMC_ID" HeaderText="盘点ID" ReadOnly="True" SortExpression="IMC_ID"
                                Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMIM_ID" HeaderText="库存ID" ReadOnly="True"
                                SortExpression="IMIM_ID" Visible="False">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                                                        <asp:BoundField DataField="IMC_Year"  ReadOnly="true" HeaderText="年份" SortExpression="IMC_Year">
                                <ItemStyle  />
                            </asp:BoundField>
                              <asp:BoundField DataField="IMC_Month" HeaderText="月份"  ReadOnly="true" SortExpression="IMC_Month">
                                <ItemStyle />
                            </asp:BoundField>  
                             <asp:BoundField DataField="IMC_Week" HeaderText="周次"  ReadOnly="true" SortExpression="IMC_Week">
                                <ItemStyle />
                            </asp:BoundField>  
                              <asp:BoundField DataField="IMC_CountResult" HeaderText="盘点结果" ReadOnly="True"
                                SortExpression="IMC_CountResult" Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                              <asp:BoundField DataField="IMC_AccountTotalNum" HeaderText="账面数量" ReadOnly="True"
                                SortExpression="IMC_AccountTotalNum" Visible="true">
                                <ItemStyle  />
                            </asp:BoundField>
                             <asp:BoundField DataField="IMC_ActualTotalNum" HeaderText="实际数量"  SortExpression="IMC_ActualTotalNum">
                                <ItemStyle />
                            </asp:BoundField>
                              <asp:BoundField DataField="IMC_CountMan" HeaderText="盘点人" ReadOnly="True"
                                SortExpression="IMC_CountMan" Visible="true">
                                <ItemStyle />
                            </asp:BoundField>
                             <asp:BoundField DataField="IMC_CountTime" HeaderText="盘点时间" ReadOnly="True"
                                SortExpression="IMC_CountTime" Visible="true">
                                <ItemStyle />
                            </asp:BoundField>

                                          <asp:CommandField ShowEditButton="True" EditText="输入盘点结果" UpdateText="更新" CancelText="取消" />       
                                      <asp:TemplateField Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete6" runat="server" CommandName="Delete6" OnClientClick="false"
                                        CommandArgument='<%#Eval("IMC_ID")%>'>删除</asp:LinkButton>
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
                    </asp:GridView>
                    <table width="100%">
                        <tr>
                            <td style="width: 95%" align="center">
                                <asp:Button ID="Button30" runat="server" Text="关闭" CssClass="Button02" Height="24px"
                                    OnClick="ColsePandianD" Width="80px" />
                            </td>
                           
                           <%-- <td style="width: 50%" align="center">
                                <asp:Button ID="Button25" runat="server" Text="取消" CssClass="Button02" Height="24px"
                                    OnClick="CanelIMIM" Width="80px" />
                            </td>--%>
                        </tr>
                    </table>
                     </fieldset>
            </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Button10" EventName="Click"/>
        </Triggers>
    </asp:UpdatePanel>
    <%--库存检索结束--%>
</asp:Content>
