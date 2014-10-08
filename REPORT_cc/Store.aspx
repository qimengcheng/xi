<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Store.aspx.cs" Inherits="REPORT_cc_Store" 
MasterPageFile="~/Other/MasterPage.master" Title="发货计划汇总" EnableEventValidation = "false"%>

<script runat="server">

   
</script>

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
   
     <%--库存检索开始--%>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
           <Triggers>
            <asp:PostBackTrigger ControlID="Button23" />
        </Triggers>
        <ContentTemplate>
            <asp:Panel ID="Panel_kucun" runat="server" Visible="true">
                <fieldset>
                    <legend>库存物料检索</legend>
                    <table style="width: 100%;">
                        <asp:Label ID="label38" runat="server" Visible="False"></asp:Label>
                           <asp:Label ID="label_OutHouseMID" runat="server" Visible="False"></asp:Label>
                           <asp:Label ID="label2" runat="server" Visible="False"></asp:Label>
                        <tr>
                            <td style="width: 15%" align="center">
                                <asp:Label ID="Label40" runat="server" Text="物料分类："></asp:Label>
                            </td>
                            <td style="width: 14%" align="left">
                                      <asp:DropDownList ID="DropDownList1" runat="server" 
                                          onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                                          AutoPostBack="True">
                                    <asp:ListItem>基础物料</asp:ListItem>
                                    <asp:ListItem>公司产品</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                             
                            </td>
                            <td style="width: 15%" align="center">
                                <asp:Label ID="Label41" runat="server" Text="物料名称："></asp:Label>
                            </td>
                            <td style="width:15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox3"> </asp:TextBox>
                            </td>
                            <td style="width: 15%" align="center">
                                <asp:Label ID="Label42" runat="server" Text="规格型号："></asp:Label>
                            </td>
                            <td style="width: 15%" align="left">
                                <asp:TextBox runat="server" ID="TextBox4"> </asp:TextBox>
                            </td>
                        </tr>
                           <tr>
                            <td style="width: 15%" align="left">
                               明细账时间从：
                            </td>
                            <td  style="width: 14%" align="left">
                                 <asp:TextBox runat="server" ID="TextBox20" onfocus="new WdatePicker(this,'%Y-%M-%D ',true)"
                                    DataFormatString="{0:yyyy-MM-dd}"  CssClass="Wdate" ></asp:TextBox>
                             <td>到</td>   
                            </td>
                                <td  align="left">
                                 <asp:TextBox runat="server" ID="TextBox1" onfocus="new WdatePicker(this,'%Y-%M-%D ',true)"
                                    DataFormatString="{0:yyyy-MM-dd}"  CssClass="Wdate" ></asp:TextBox>
                                
                            </td>
                               <td align="center" bgcolor="skyblue">
                                   <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">明细账单独检索</asp:LinkButton>

                               </td>
                        </tr>
                        <tr>
                            <td colspan="3" align="center">
                                <asp:Button ID="Button22" runat="server" Text="检索" CssClass="Button02" Height="24px"
                                    OnClick="SelectMat" Width="80px" />
                            </td>
                            <td colspan="3" align="left">
                                <asp:Button ID="Button23" runat="server" Text="导出库存主表" CssClass="Button02" Height="24px"
                                    OnClick="Excel1" Width="80px" />
                            </td>
                            </td>
                        </tr>
                     
                    </table>
                </fieldset>
            </asp:Panel>
            <asp:Panel ID="Panel_kucun1" runat="server" Visible="true">
                <fieldset>
                 <asp:Label ID="label_SourceSort" runat="server" Visible="False"></asp:Label>
                    <legend>库存列表</legend>
                    <asp:GridView ID="Gridview_Pur" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle"
                        CellPadding="0" UseAccessibleHeader="False" PageSize="10" 
                        AllowPaging="True" AllowSorting="True" Font-Strikeout="False" GridLines="None"
                      
                        Width="100%" onrowcommand="Gridview_Pur_RowCommand" OnPageIndexChanging="Gridview_Pur_PageIndexChanging"  DataKeyNames="ID">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            
                          
                           
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
                                        CommandArgument='<%#Eval("ID")%>'>查看</asp:LinkButton>
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
         <%--库存详细表开始--%>
    <asp:UpdatePanel ID="UpdatePanel_KucunD" runat="server" UpdateMode="Conditional">
            <Triggers>
            <asp:PostBackTrigger ControlID="Button1" />
        </Triggers>
        <ContentTemplate>
      
        
                <!--startprint-->
            <asp:Panel ID="Panel3" runat="server" Visible="False">
         <fieldset><legend>
               <asp:Label ID="Label3" runat="server" Visible="true"></asp:Label> 物料明细账</legend>
             <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label>
            <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="GridViewStyle"  EmptyDataText="没有相关记录，请搜索。" GridLines="None" OnPageIndexChanging="GridView2_PageIndexChanging" PageSize="15" EnableModelValidation="True">
                <RowStyle CssClass="GridViewRowStyle" />
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle CssClass="GridViewHead" />
                <FooterStyle CssClass="GridViewFooterStyle" />
                <Columns>
                    
                            <asp:BoundField DataField="iotime" HeaderText="时间" DataFormatString="{0:yyyy-MM-dd }" />
                            <asp:BoundField DataField="insort" HeaderText="入库类型" />
                            <asp:BoundField DataField="outsort" HeaderText="出库类型" />
                            <asp:BoundField DataField="batchnum" HeaderText="批号" />
                            <asp:BoundField DataField="name" HeaderText="材料名称" Visible="true"  />
                            <asp:BoundField DataField="model" HeaderText="规格型号" Visible="true"  />
                            <asp:BoundField DataField="innum" HeaderText="入库数量" />
                    <asp:BoundField DataField="outnum" HeaderText="出库数量" />
                             <asp:BoundField DataField="chou" HeaderText="抽检数量" />
                            <asp:BoundField DataField="unit" HeaderText="单位" />
                            <asp:BoundField DataField="kufang" HeaderText="库房" />
                    <asp:BoundField DataField="quyu" HeaderText="库房区域" />
                            <asp:BoundField DataField="man" HeaderText="操作人" />
                            <asp:BoundField DataField="yue" HeaderText="操作后余额" />
                </Columns>
                <PagerTemplate>
                    <table width="100%">
                        <tr>
                            <td style="text-align: right">第<asp:Label ID="lblPageIndex" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                页 共<asp:Label ID="lblPageCount" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageCount  %>" />
                                页 
                                <asp:LinkButton ID="btnFirst" runat="server" CausesValidation="False" CommandArgument="First" CommandName="Page" Text="首页" />
                                <asp:LinkButton ID="btnPrev" runat="server" CausesValidation="False" CommandArgument="Prev" CommandName="Page" Text="上一页" />
                                <asp:LinkButton ID="btnNext" runat="server" CausesValidation="False" CommandArgument="Next" CommandName="Page" Text="下一页" />
                                <asp:LinkButton ID="btnLast" runat="server" CausesValidation="False" CommandArgument="Last" CommandName="Page" Text="尾页" />
                                <asp:TextBox ID="textbox" runat="server" Width="20px"></asp:TextBox>
                                <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1" CommandName="Page" Text="GO" />
                                <!-- here set the CommandArgument of the Go Button to '-1' as the flag --></td>
                        </tr>
                    </table>
                </PagerTemplate>
            </asp:GridView>
                    <table width="100%">
                     <tr>
                        
                         <td style="width:50%" align="center">
                          <asp:Button ID="Button1" runat="server" Text="导出Excel" CssClass="Button02" Height="24px"
                                    OnClick="Excel2" Width="80px" />
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
   </asp:Content>