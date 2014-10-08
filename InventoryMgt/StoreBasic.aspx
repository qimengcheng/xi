<%@ Page Title="" Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true" CodeFile="StoreBasic.aspx.cs" Inherits="InventoryMgt_StoreBasic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    <asp:UpdatePanel ID="UpdatePanel_StoreSearch" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false" >
        <ContentTemplate>
            <asp:Panel ID="Panel_StoreSearch" runat="server" Visible="true">
            <fieldset>
     <legend>出入库类别查询</legend>
     <table style="width: 100%;">
     <tr style="width: 100%;">
     <td style="width: 10%;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;出入库类别：</td>
     <td style="width: 13%;">
         <asp:DropDownList ID="DropDownList_StoreIn" runat="server" Width="90px" 
             Height="19px">
                                    <asp:ListItem Value="出入库类别" Text="出入库类别"></asp:ListItem>
                                    <asp:ListItem Value="入库类别" Text="入库类别"></asp:ListItem>
                                    <asp:ListItem Value="出库类别" Text="出库类别"></asp:ListItem>
                                </asp:DropDownList>
         </td>
     <td style="width: 8%;">&nbsp;&nbsp;&nbsp;<asp:Button ID="Btn_StoreSearch" runat="server" 
             CssClass="Button02" Height="24px" Text="检索" Width="70px" 
             onclick="Btn_StoreSearch_Click" />
         </td>
     <td style="width: 10%;" align="center">
         <asp:Button ID="Button_StoreIn" runat="server" CssClass="Button02" 
             Height="24px" onclick="Button_StoreIn_Click" Text="新增入库类别" Width="90px"/>
         </td>
     <td style="width: 10%;" align="center">
         <asp:Button ID="Button_StoreOut" runat="server" CssClass="Button02" 
             Height="24px" onclick="Button_StoreOut_Click" Text="新增出库类别" Width="90px" />
         </td>
     <td style="width: 20%;">
         &nbsp;&nbsp;
         <asp:Button ID="Button_StoreCancel" runat="server" CssClass="Button02" 
             Height="24px" Visible="false" onclick="Button_StoreCancel_Click" Text="重置" Width="70px" />
         </td>
     </tr>
     </table>
     </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
  

 <asp:UpdatePanel ID="UpdatePanel_IMSSBD" runat="server" UpdateMode="Conditional" >
        <ContentTemplate>
            <asp:Panel ID="Panel_IMSSBD" runat="server" Visible="true">
                <fieldset>
                    <legend>出入库类别查询表
                    </legend>
                    <asp:GridView ID="GridView_IMSSBD" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        PageSize="10" CellPadding="0" UseAccessibleHeader="False" AllowPaging="True" Font-Strikeout="False" GridLines="None"
                        Width="100%" DataKeyNames="IMSSBD_ID" OnPageIndexChanging="GridView_IMSSBD_PageIndexChanging" OnRowCommand="GridView_IMSSBD_RowCommand" OnRowDataBound="GridView_IMSSBD_RowDataBound"
                         OnRowUpdating="GridView_IMSSBD_RowUpdating" OnRowEditing="GridView_IMSSBD_RowEditing" OnRowCancelingEdit="GridView_IMSSBD_RowCancelingEdit" >
                         <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                        <asp:BoundField DataField="IMSSBD_ID" HeaderText="出入库类别ID" SortExpression="IMSSBD_ID" Visible="false" ReadOnly="true" >
                            </asp:BoundField>
                        <asp:BoundField DataField="IMSSBD_Sort" SortExpression="IMSSBD_Sort" HeaderText="出入库类别" ReadOnly="true"></asp:BoundField>
                        <asp:BoundField DataField="IMSSBD_Name" SortExpression="IMSSBD_Name" HeaderText="类别名称" ReadOnly="true"></asp:BoundField>
                        <asp:TemplateField HeaderText="具体描述" >
                        <ItemTemplate>
                        <asp:Label ID="detail" runat="server" Text='<%#(Eval("IMSSBD_Detail").ToString()).Length>10 ?((Eval("IMSSBD_Detail")).ToString()).Substring(0,10)+"...":Eval("IMSSBD_Detail")%>' ToolTip='<%#Eval("IMSSBD_Detail")%>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="True" EditText="编辑" UpdateText="更新" CancelText="取消">
                                <ItemStyle Width="10%" />
                            </asp:CommandField>
                        <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="dele" runat="server" CommandArgument='<%# Eval("IMSSBD_ID") %>'
                                        CommandName="dele" OnClientClick="return confirm('您确认删除该记录吗?')">删除</asp:LinkButton>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="IMSSBD_Detail" SortExpression="IMSSBD_Detail" HeaderText="编辑描述" Visible="false"></asp:BoundField>
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第 &nbsp;<asp:Label ID="lblPageIndex" runat="server" Text="<%#  ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                        页 共 &nbsp;<asp:Label ID="lblPageCount" runat="server" Text="<%#  ((GridView)Container.Parent.Parent).PageCount  %>" />
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
                    </fieldset>
                      </fieldset>
                     </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_IMStore" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_IMStore" runat="server" Visible="true">
    <fieldset>
     <legend>库房查询表</legend>
     <asp:Button ID="Btn_NewStore" runat="server" CssClass="Button02" Height="24px" 
             onclick="Btn_NewStore_Click" Text="新增库房" Width="90px" />
       <asp:GridView ID="GridView_IMStore" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        PageSize="10" CellPadding="0" UseAccessibleHeader="False" AllowPaging="True"  Font-Strikeout="False" GridLines="None"
                        Width="100%" DataKeyNames="IMS_StoreID" OnPageIndexChanging="GridView_IMStore_PageIndexChanging"  OnRowDataBound="GridView_IMStore_RowDataBound"
                         OnRowUpdating="GridView_IMStore_RowUpdating" OnRowEditing="GridView_IMStore_RowEditing" OnRowCommand="GridView_IMStore_RowCommand" OnRowCancelingEdit="GridView_IMStore_RowCancelingEdit">
                         <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                        <asp:BoundField DataField="IMS_StoreID" HeaderText="库房ID" SortExpression="IMS_StoreID" Visible="false">
                            </asp:BoundField>
                        <asp:BoundField DataField="IMS_StoreName" SortExpression="IMS_StoreName" HeaderText="库房名称" ReadOnly="true" ></asp:BoundField>
                        <asp:BoundField DataField="IMS_ResponDepart" SortExpression="IMS_ResponDepart" HeaderText="管理部门" ></asp:BoundField>
                        <asp:BoundField DataField="IMS_ResponMan" SortExpression="IMS_ResponMan" HeaderText="管理人员" ></asp:BoundField>
                               <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="bianji" runat="server" CommandArgument='<%# Eval("IMS_StoreID") %>'
                                        CommandName="bianji" >编辑</asp:LinkButton>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="dele" runat="server" CommandArgument='<%# Eval("IMS_StoreID") %>'
                                        CommandName="dele" OnClientClick="return confirm('您确认删除该记录吗?')">删除</asp:LinkButton>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="SET" runat="server" CommandArgument='<%# Eval("IMS_StoreID") %>'
                                        CommandName="SET" >设置区域</asp:LinkButton>
                                </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="SEE" runat="server" CommandArgument='<%# Eval("IMS_StoreID") %>'
                                        CommandName="SEE" >查看区域</asp:LinkButton>
                                </ItemTemplate>
                        </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第 &nbsp;<asp:Label ID="lblPageIndex" runat="server" Text="<%#  ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                        页 共 &nbsp;<asp:Label ID="lblPageCount" runat="server" Text="<%#  ((GridView)Container.Parent.Parent).PageCount  %>" />
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

     </fieldset>
        </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
   
<asp:UpdatePanel ID="UpdatePanel_AddIn" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="False">
        <ContentTemplate>
            <asp:Panel ID="Panel_AddIn" runat="server" Visible="false">
    <fieldset>
     <legend>新增入库类别</legend>
      <table style="width: 100%;">
     <tr>
     <td style="width: 15%; height: 21px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;类别名称：</td>
     <td style="width: 20%;"><asp:TextBox ID="TextBox_INname" runat="server" Width="80%"></asp:TextBox></td>
     <td></td>
     </tr>
     <tr>
     <td >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;具体描述：</td>
     <td  colspan="2"><asp:TextBox ID="TextBox_INDetail" runat="server" Width="90%" Height="60px"></asp:TextBox></td>
     </tr>
     <tr>
    <td></td>
     <td align="right"><asp:Button ID="Btn_NewIn" runat="server" 
             CssClass="Button02" Height="24px" Text="提交" Width="70px" 
             onclick="Btn_NewIn_Click" /></td>
     <td align="center"><asp:Button ID="Btn_NewInCancel" runat="server" 
             CssClass="Button02" Height="24px" Text="关闭" Width="70px" 
             onclick="Btn_NewInCancel_Click" /></td>
    
     </tr>
     </table>
     </fieldset>
     </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

<asp:UpdatePanel ID="UpdatePanel_AddOut" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="False">
        <ContentTemplate>
            <asp:Panel ID="Panel_AddOut" runat="server" Visible="false">
    <fieldset>
     <legend>新增出库类别</legend>
      <table style="width: 100%;">
     <tr style="width: 100%;">
     <td style="width: 15%; height: 21px;">&nbsp;&nbsp;&nbsp;&nbsp; 类别名称：</td>
     <td style="width: 20%; height: 21px;"><asp:TextBox ID="TextBox_OutName" runat="server" Width="80%"></asp:TextBox></td>
     <td></td>
     </tr>
     <tr>
     <td >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;具体描述：</td>
     <td colspan="2"><asp:TextBox ID="TextBox_OutDetail" runat="server" Width="90%" Height="60px"></asp:TextBox></td>
     </tr>

     <tr style="width: 100%;">
     <td colspan="2" align="right">
         <asp:Button ID="Btn_NewOut" runat="server" CssClass="Button02" Height="24px" 
             onclick="Btn_NewOut_Click" Text="提交" Width="70px" />
         </td>
     <td colspan="2" align="center"><asp:Button ID="Btn_NewOutCancel" runat="server" 
             CssClass="Button02" Height="24px" Text="关闭" Width="70px" 
             onclick="Btn_NewOutCancel_Click" /></td>
     </tr>
     </table>
     </fieldset>
     </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
<asp:UpdatePanel ID="UpdatePanel_EditStore" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="False">
        <ContentTemplate>
            <asp:Panel ID="Panel_EditStore" runat="server" Visible="false">
            <fieldset>
            <legend>新建/修改库房</legend>
             <table style="width: 100%;">
     <tr style="width: 100%;">
     <td style="width: 10%; height: 21px;" align="center">库房名称：</td>
     <td style="width: 10%; height: 21px;"><asp:TextBox ID="TextBox_Store" runat="server" Width="100%"></asp:TextBox></td>
    
     <td style="width: 10%; height: 21px;"></td>
     <td style="width: 15%; height: 21px;"></td>
     <td style="width: 20%; height: 21px;"></td>
     </tr>
     <tr style="width: 100%;">
     <td style="width: 7%;" align="center">管理人员：</td>
     <td style="width: 10%;"><asp:TextBox ID="TextBox_StoreManger" runat="server" Width="100%" ReadOnly="true" Enabled="false"></asp:TextBox></td>
     
     <td style="width: 10%;" align="center">管理部门：</td>
     <td style="width: 15%;">
         <asp:TextBox ID="TextBox_StoreManger0" runat="server" Width="93%" 
             ReadOnly="true" Enabled="false" ></asp:TextBox>
         </td>
     <td style="width: 20%;"> 
         <asp:Button ID="Btn_FindMan" runat="server" CssClass="Button02" Height="24px" 
             onclick="Btn_FindMan_Click" Text="查询管理人员" Width="90px" />
         </td>
     </tr>
     <tr style="width: 100%;">
     <td colspan="2" align="right">
         <asp:Button ID="Btn_EditStore" runat="server" CssClass="Button02" Height="24px" 
             onclick="Btn_EditStore_Click" Text="提交" Width="70px" />
         </td>
     <td style="width: 1%;">&nbsp;</td>
     <td colspan="3" align="center">
         <asp:Button ID="Btn_EditCancel" runat="server" CssClass="Button02" 
             Height="24px" onclick="Btn_EditCancel_Click" Text="关闭" Width="70px" />
         </td>
     </tr>
     </table>
            
            
            </fieldset>

            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
  
<asp:UpdatePanel ID="UpdatePanel_findMan" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="False">
        <ContentTemplate>
            <asp:Panel ID="Panel_findMan" runat="server" Visible="false">
            <fieldset>
            <legend>查询人员</legend>
                <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label>
            <table style="width: 100%;">
     <tr style="width: 100%;">
     <td style="width: 10%;" align="right">部门：</td>
     <td style="width: 3%;"><asp:DropDownList ID="DropDownList_Depart" runat="server" Width="80px" AutoPostBack="true" DataTextField="BDOS_Name" DataValueField="BDOS_Name" AppendDataBoundItems="true" >
                                    <asp:ListItem Value="请选择" Text="请选择"></asp:ListItem>
                                </asp:DropDownList></td>
     <td style="width: 5%;" align="right">人员：</td>
     <td style="width: 7%;"><asp:TextBox ID="TextBox_DptMan" runat="server" Width="97%"></asp:TextBox></td>
     <td style="width: 1%;"></td>
         
     <td style="width: 20%;"><asp:Button ID="Btn_DeprtMan" runat="server" 
             CssClass="Button02" Height="24px" Text="检索" Width="70px" 
             onclick="Btn_DeprtMan_Click" /></td>
     </tr>
     </table>
    <asp:GridView ID="GridView_Depart" runat="server" AllowPaging="True" PageSize="10"
                        Width="100%" AutoGenerateColumns="False" CellPadding="0" CssClass="GridViewStyle" Font-Strikeout="False" GridLines="None"
                        DataKeyNames="UMUI_UserID" AllowSorting="True" OnPageIndexChanging = "GridView_Depart_PageIndexChanging" OnRowCommand = "GridView_Depart_RowCommand" OnRowDataBound="GridView_Depart_RowDataBound"  >
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <%--<HeaderStyle CssClass="GridviewHead" BorderStyle="Double" BorderWidth="1px" Height="26px"
                            HorizontalAlign="Center" />--%>
                        <Columns>
                            <asp:TemplateField Visible="false" >
                                <ItemStyle Width="5%" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox2" runat="server" onclick="return false;" />
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:BoundField DataField="UMUI_UserID" HeaderText="人员ID" Visible="false" />
                            <asp:BoundField DataField="BDOS_Name" HeaderText="部门"  />
                            <asp:BoundField DataField="UMUI_UserName" HeaderText="人员"  />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Add1" runat="server"
                                        CommandName="Add1" OnClientClick="return confirm('您确认添加该用户吗?')" CommandArgument='<%# Eval("UMUI_UserID") %>' >添加</asp:LinkButton>
                                </ItemTemplate>
                        </asp:TemplateField>
                            </Columns>
                            <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第 &nbsp;<asp:Label ID="lblPageIndex" runat="server" Text="<%#  ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                        页 共 &nbsp;<asp:Label ID="lblPageCount" runat="server" Text="<%#  ((GridView)Container.Parent.Parent).PageCount  %>" />
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

                             <table style="width: 100%;">
                             
                             <tr style="width: 100%;">
                             <td style="width: 14%;"></td>
                             <td style="width: 10%;"><asp:Button ID="Btn_confirm" runat="server" 
                                     CssClass="Button02" Height="24px" Text="提交" Width="70px" 
                                     onclick="Btn_confirm_Click" Visible="false" /></td>
                             <td style="width: 10%;"><asp:Button ID="Btn_cancel" runat="server" 
                                     CssClass="Button02" Height="24px" Text="关闭" Width="70px" 
                                     onclick="Btn_cancel_Click" /></td>
                             <td style="width: 25%;">
                                 <asp:Button ID="Btn_renewl0" runat="server" CssClass="Button02" Height="24px" 
                                      Text="重新添加" Width="90px" onclick="Btn_renewl0_Click" />
                                 </td>
                             </tr>
                             </table>

            </fieldset>
            </asp:Panel>
        </ContentTemplate>

    </asp:UpdatePanel>
<asp:UpdatePanel ID="UpdatePanel_areal" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="False">
        <ContentTemplate>
            <asp:Panel ID="Panel_areal" runat="server" Visible="false">
            <fieldset>
            <legend>区域信息表</legend>
            <asp:Button ID="Btn_new_areal" runat="server" CssClass="Button02" Height="24px" 
                                Text="添加新区域" Width="90px" onclick="Btn_new_areal_Click" />
             <asp:GridView ID="GridView_areal" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        PageSize="10" CellPadding="0" UseAccessibleHeader="False" AllowPaging="True"  Font-Strikeout="False" GridLines="None"
                        Width="100%" DataKeyNames="IMSA_AreaID" OnRowUpdating="GridView_areal_RowUpdating" 
                        OnRowEditing="GridView_areal_RowEditing" OnPageIndexChanging = "GridView_areal_PageIndexChanging" OnRowCommand="GridView_areal_RowCommand" OnRowCancelingEdit="GridView_areal_RowCancelingEdit" OnRowDataBound="GridView_areal_RowDataBound" >
                         <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                        <asp:BoundField DataField="IMSA_AreaID" HeaderText="区域id" SortExpression="IMSA_AreaID" Visible="false">
                            </asp:BoundField>
                        <asp:BoundField DataField="IMS_StoreName" HeaderText="库房名称" SortExpression="IMS_StoreName" Visible="true" ReadOnly="true">
                            </asp:BoundField>
                        <asp:BoundField DataField="IMSA_AreaName" SortExpression="IMSA_AreaName" HeaderText="区域名称" ></asp:BoundField>
                        <asp:BoundField DataField="IMSA_Remark" SortExpression="IMSA_Remark" HeaderText="备注" ></asp:BoundField>
                       <asp:CommandField ShowEditButton="True" EditText="编辑" UpdateText="更新" CancelText="取消">
                                <ItemStyle Width="10%" />
                            </asp:CommandField>
                        <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete3" runat="server" CommandArgument='<%# Eval("IMSA_AreaID") %>'
                                        CommandName="Delete3" OnClientClick="return confirm('您确认删除该记录吗?')">删除</asp:LinkButton>
                                </ItemTemplate>
                        </asp:TemplateField>
                        
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第 &nbsp;<asp:Label ID="lblPageIndex" runat="server" Text="<%#  ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                        页 共 &nbsp;<asp:Label ID="lblPageCount" runat="server" Text="<%#  ((GridView)Container.Parent.Parent).PageCount  %>" />
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
                            <asp:Label ID="Label16" runat="server" Text="该库房无相关区域，请添加或查询其他库房！"></asp:Label>
                        </EmptyDataTemplate>
                        </asp:GridView>
          <%--</fieldset>              
     </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>--%>
                       
                     <asp:UpdatePanel ID="UpdatePanel_arealedit" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="False">
        <ContentTemplate>
            <asp:Panel ID="Panel_arealedit" runat="server" Visible="false">  
                       
                        <table style="width: 100%;">
                        <tr style="width: 100%;">
     <td align="center">
         <asp:Button ID="Btn_cancel0" runat="server" CssClass="Button02" Height="24px" 
             onclick="Btn_cancel0_Click" Text="关闭" Width="70px" />
                            </td>
     </tr>
                        </table>


     </fieldset>              
     </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

     </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_newareal" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="False">
        <ContentTemplate>
            <asp:Panel ID="Panel_newareal" runat="server" Visible="false">
            <fieldset>
            <legend>添加新区域信息</legend>
            <table style="width:100%;">
            <tr style="width:100%;">
           <td style="width:4%; height: 21px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;库房名称：</td> 
           <td style="width:10%; height: 21px;">
               <asp:TextBox ID="TextBox_StoreNAME" runat="server" Width="100%" Readonly="true" Enabled="false" ></asp:TextBox>
                </td>
            <td style="width:6%; height: 21px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 区域名称：</td>
            <td style="width:10%; height: 21px;">
                <asp:TextBox ID="TextBox_ArealName" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr style="width:100%;">
           <td style="width:4%;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 备注：</td> 
           <td colspan="3">
               <asp:TextBox ID="TextBox_ArealDetail" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr style="width:100%;">
           <td style="width:4%; height: 32px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>  
           <td style="width:4%; height: 32px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button 
                   ID="Btn_confirm_areal" runat="server" CssClass="Button02" Height="24px" 
                    Text="提交" Width="70px" onclick="Btn_confirm_areal_Click" />
                </td>
            <td style="width:6%; height: 32px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
            <td style="width:4%; height: 32px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Btn_cancel1" 
                    runat="server" CssClass="Button02" Height="24px" onclick="Btn_cancel_areal" 
                    Text="关闭" Width="70px" />
                &nbsp;&nbsp;&nbsp;&nbsp;</td>
            <td style="width:4%; height: 32px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
            </tr>
            </table>
            </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>


<script language="javascript">
    var _oldColor;
    function SetNewColor(source) {

    }
    function SetOldColor(source) {
    }
    </script>



</asp:Content>
