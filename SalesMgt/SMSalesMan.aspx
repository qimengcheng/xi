<%@ Page Title="" Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true"
    CodeFile="SMSalesMan.aspx.cs" Inherits="SalesMgt_SalesMan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
      <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" Visible="false">
                <fieldset>
                    <legend>业务员类别查询</legend>
                    <table style="width: 100%;">
                        <tr style="width: 100%;">
                            <td style="width:20%"></td>
                            <td style="width: 11%;" align="right">
                                类别名称：
                            </td>
                            <td style="width: 14%;" align="left">
                                <asp:TextBox ID="TextBox1" runat="server" Width="100px"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 18%;" align="left">
                                <asp:Button ID="Button2" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_SearchSort_Click"
                                    Text="检索" Width="70px" />
                            </td>
                        <td align="center" style="width: 18%;" align="left">
                                <asp:Button ID="Button3" runat="server" CssClass="Button02" Height="24px" OnClick="Btn_NewSort_Click"
                                    Text="新建" Width="70px" />
                            </td>
                        </tr>
               
                    </table>
                  
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel2" runat="server" Visible="false">
                <fieldset>
                    <legend>业务员类别表<asp:Label ID="Label17" runat="server" Visible="false"></asp:Label>
                    </legend>
          
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        Font-Strikeout="False" GridLines="None" PageSize="10" CellPadding="0" UseAccessibleHeader="False"
                        AllowPaging="True" OnRowCommand="GridView1_RowCommand" OnPageIndexChanging="GridView1_PageIndexChanging"
                        AllowSorting="True" Width="100%" DataKeyNames="SMSMS_ID,SMSMS_Note"
                        EmptyDataText="无相关记录!" OnDataBound="GridView2_DataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="SMSMS_ID" HeaderText="产品型号ID" SortExpression="SMSMS_ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="SMSMS_Name" HeaderText="类别名称" SortExpression="SMSMS_Name" >
                            </asp:BoundField>
                                 <asp:BoundField DataField="SMSMS_Note" HeaderText="备注" SortExpression="SMSMS_Note" >
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Edit1" runat="server" CommandArgument='<%# Eval("SMSMS_ID")%>'
                                        CommandName="Edit1">编辑</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete1" runat="server" CommandArgument='<%# Eval("SMSMS_ID")%>' OnClientClick="return confirm('确定删除吗？')"
                                        CommandName="Delete1">删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Look1" runat="server" CommandArgument='<%# Eval("SMSMS_ID")%>'
                                        CommandName="Look1">查看具体业务员</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                     
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第 &nbsp;<asp:Label ID="lblPageIndex" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                        页 共 &nbsp;<asp:Label ID="lblPageCount" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageCount  %>" />
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
                                        <%--<asp:textbox id="txtNewPageIndex" runat="server" width="20px" text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />--%>
                                        <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                            CommandName="Page" Text="GO" />
                                        <!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
                                    </td>
                                </tr>
                            </table>
                        </PagerTemplate>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label16" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                    </asp:GridView>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
   
   
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel3" runat="server" Visible="false">
                <fieldset>
                    <legend><asp:Label ID="Label2" runat="server" ></asp:Label><asp:Label ID="Label3" runat="server" Visible="false" ></asp:Label>业务员类别
                 
                    </legend>
                 <table style="width:100%">
                        <tr style="width: 100%;">
                            
                            <td style="width: 21%" align="right">
                                类别名称:
                            </td>
                            <td style="width: 50%" align="left">
                                <asp:TextBox ID="TextBox2" runat="server" ></asp:TextBox>
                            </td>
                          <td style="width: 25%" align="left">
                                 <asp:Button ID="Button4" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="ConfirmSort" Text="提交" Width="70px" />
                              &nbsp;&nbsp;
                               <asp:Button ID="Button5" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="CloseSort" Text="关闭" Width="70px" />
                            </td>
                        </tr>
                     <tr>
                               <td style="width: 21%" align="right">
                                备注（200字内）:
                            </td>
                           <td align="left" colspan="2">
                                <asp:TextBox runat="server" ID="TextBox3" Enabled="true" Width="90%"
                                    Height="37px" MaxLength="200" TextMode="MultiLine" onkeyup="this.value = this.value.slice(0, 200)"></asp:TextBox>
                            </td>
                     </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_Search" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Search" runat="server" Visible="false">
                <fieldset>
                    <legend>业务员查询</legend>
                    <table style="width: 100%;">
                        <tr style="width: 100%;">
                            <td style="width:20%"></td>
                            <td style="width: 11%;" align="right">
                                姓名：
                            </td>
                            <td style="width: 14%;" align="left">
                                <asp:TextBox ID="Txt_search" runat="server" Width="100px"></asp:TextBox>
                            </td>
                            <td align="center" style="width: 18%;" align="left">
                                <asp:Button ID="Btn_Search" runat="server" CssClass="Button02" Height="24px" OnClick="SearchMan"
                                    Text="检索" Width="70px" />
                            </td>
                        <td align="center" style="width: 18%;" align="left">
                                <asp:Button ID="Button1" runat="server" CssClass="Button02" Height="24px" OnClick="NewMan"
                                    Text="新建" Width="70px" />
                            </td>
                        </tr>
               
                    </table>
                  
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_PT" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_PT" runat="server" Visible="false">
                <fieldset>
                     <asp:Button ID="Button6" runat="server" CssClass="Button02" Height="24px" OnClick="ClosePT" Visible="false"
                                    Text="关闭" Width="70px" />
                    <legend><asp:Label ID="Label4" runat="server" Visible="true"></asp:Label>业务员表<asp:Label ID="Label18" runat="server" Visible="false"></asp:Label>
                    </legend>
          
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        Font-Strikeout="False" GridLines="None" PageSize="20" CellPadding="0" UseAccessibleHeader="False"
                        AllowPaging="True" OnRowCommand="GridView2_RowCommand" OnPageIndexChanging="GridView2_PageIndexChanging"
                        AllowSorting="True" Width="100%" DataKeyNames="SMSM_ID"
                        EmptyDataText="无相关记录!">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="SMSM_ID" HeaderText="产品型号ID" SortExpression="SMSM_ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="SMSM_Name" HeaderText="姓名" SortExpression="SMSM_Name" >
                            </asp:BoundField>
                           <asp:BoundField DataField="SMSMS_Name" HeaderText="类别" SortExpression="SMSMS_Name" >
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Edit123" runat="server" CommandArgument='<%# Eval("SMSM_ID")%>'
                                        CommandName="Edit2">编辑</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Edit1" runat="server" CommandArgument='<%# Eval("SMSM_ID")%>'
                                        CommandName="Delete2">删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        
                     
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第 &nbsp;<asp:Label ID="lblPageIndex" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                        页 共 &nbsp;<asp:Label ID="lblPageCount" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageCount  %>" />
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
                                        <%--<asp:textbox id="txtNewPageIndex" runat="server" width="20px" text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />--%>
                                        <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                            CommandName="Page" Text="GO" />
                                        <!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
                                    </td>
                                </tr>
                            </table>
                        </PagerTemplate>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label16" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                    </asp:GridView>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
   
   
    <asp:UpdatePanel ID="UpdatePanel_CheckParameter" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_CheckParameter" runat="server" Visible="false">
                <fieldset>
                    <legend><asp:Label ID="Label1" runat="server" ></asp:Label>姓名
                 
                     
                        <asp:Label ID="Label19" runat="server"  Visible="false"></asp:Label>
                 
                    </legend>
                 <table style="width:100%">
                        <tr style="width: 100%;">
                              <td style="width: 10%" align="right">
                                客户类别:
                            </td>
                            <td style="width: 20%" align="center">
                                <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
                            </td>
                            <td style="width: 14%" align="right">
                                姓名:
                            </td>
                            <td style="width: 29%" align="center">
                                <asp:TextBox ID="Txt_parameter" runat="server" ></asp:TextBox>
                            </td>
                          <td style="width: 25%" align="left">
                                 <asp:Button ID="Btn_I_parameter" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Btn_I_parameter_Click" Text="提交" Width="70px" />
                              &nbsp;&nbsp;
                               <asp:Button ID="Btn_Close_CheckParameter" runat="server" CssClass="Button02" Height="24px"
                                    OnClick="Button_Close_CheckParameter_Click" Text="关闭" Width="70px" />
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
