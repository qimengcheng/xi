<%@ Page Title="" Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true" CodeFile="ClientInfo.aspx.cs" Inherits="Client_ClientInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel_ClientInfo_Search" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false" >
        <ContentTemplate>
           <asp:Panel ID="Panel_ClientInfo_Search" runat="server" Visible="true">
           <fieldset>
           <legend>客户查询</legend>
           <table style="width: 100%;" >
            <tr style="width: 100%;">
            <td style="width: 4%;">客户名称：</td>
            <td style="width: 7%;"><asp:TextBox ID="TextBox_Clientname1" runat="server" Width="80%"></asp:TextBox></td>
            <td style="width: 4%;">区域名称：</td>
            <td style="width: 7%;">
                <asp:DropDownList ID="DropDownList_ClientRegion" runat="server" 
                    AppendDataBoundItems="true" AutoPostBack="true" DataTextField="CRMRBI_Name" 
                    DataValueField="CRMRBI_Name" Width="80px">
                    <asp:ListItem Text="请选择" Value="请选择"></asp:ListItem>
                </asp:DropDownList>
                </td>
            <td style="width: 4%;">客户类别：</td>
            <td style="width: 7%;"><asp:DropDownList ID="DropDownList_ClientSort" runat="server" Width="80px" AutoPostBack="true" DataTextField="CRMCSBD_Name" DataValueField="CRMCSBD_Name" AppendDataBoundItems="true" >
                                    <asp:ListItem Value="请选择" Text="请选择"></asp:ListItem>
                                </asp:DropDownList></td>
            <td style="width: 6%;">有无物料标签：</td>
            <td style="width: 7%;">
                <asp:DropDownList ID="DropDownList_IsLabel" runat="server" Width="91px" 
             Height="20px">
                                    <asp:ListItem Value="请选择" Text="请选择"></asp:ListItem>
                                    <asp:ListItem Value="有" Text="有"></asp:ListItem>
                                    <asp:ListItem Value="无" Text="无"></asp:ListItem>
                                </asp:DropDownList></td>
            </tr>
            </table>
            <table style="width: 100%;" >
            <tr style="width: 100%;">
            <td style="width: 25%;"></td>
            <td style="width: 15%;">
                <asp:Button ID="Btn_ClientSearch" runat="server" CssClass="Button02" 
                    Height="24px" Text="检索" Width="80px" onclick="Btn_ClientSearch_Click" /></td>
            <td style="width: 20%;" align="center">
            <asp:Button ID="Btn_NewClient" runat="server" CssClass="Button02" Height="24px" 
                        Text="新增" Width="80px" onclick="Btn_NewClient_Click"/>
            </td>
            <td style="width: 15%;" align="right"><asp:Button ID="Btn_ClientSearchCancel" runat="server" 
             CssClass="Button02" Height="24px" Text="重置" Width="80px" 
                    onclick="Btn_ClientSearchCancel_Click" /></td>
            <td ></td>
            </tr>
            </table>          
           </fieldset>
           </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_ClientInfo" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false" >
        <ContentTemplate>
           <asp:Panel ID="Panel_ClientInfo" runat="server" Visible="true">
           <fieldset>   
           <legend>客户信息表</legend>
                   <asp:Label ID="Label16" runat="server"  Visible="false"></asp:Label>
           <asp:GridView ID="GridView_Client" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        PageSize="10" CellPadding="0" UseAccessibleHeader="False" AllowPaging="True" GridLines="None"
                        Width="100%" DataKeyNames="CRMCIF_ID" OnRowCommand="GridView_Client_RowCommand" OnPageIndexChanging="GridView_Client_PageIndexChanging" >
                         <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                         <asp:BoundField DataField="CRMCIF_ID" HeaderText="客户ID" SortExpression="CRMCIF_ID" Visible="false" ReadOnly="true"></asp:BoundField>
                         <asp:BoundField DataField="CRMCIF_Name" SortExpression="CRMCIF_Name" HeaderText="客户名称" ReadOnly="true"></asp:BoundField>
                         <asp:BoundField DataField="CRMCSBD_Name" SortExpression="CRMCSBD_Name" HeaderText="客户类别" ReadOnly="true"></asp:BoundField>
                         <asp:BoundField DataField="CRMRBI_Name" SortExpression="CRMRBI_Name" HeaderText="区域名称" ReadOnly="true"></asp:BoundField>
                         <asp:TemplateField HeaderText="隐藏地址" Visible="false" >
                        <ItemTemplate>
                        <asp:Label ID="Adress1" runat="server" Text='<%#Eval("CRMCIF_Address")%>' ToolTip='<%#Eval("CRMCIF_Address")%>' Visible="false"></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="客户地址" >
                        <ItemTemplate>
                        <asp:Label ID="Adress" runat="server" Text='<%#(Eval("CRMCIF_Address").ToString()).Length>10 ?((Eval("CRMCIF_Address")).ToString()).Substring(0,10)+"...":Eval("CRMCIF_Address")%>' ToolTip='<%#Eval("CRMCIF_Address")%>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                         <asp:BoundField DataField="CRMCIF_BinTag" SortExpression="CRMCIF_BinTag" HeaderText="有无物料标签" ReadOnly="true"></asp:BoundField>
                         <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Change" runat="server" CommandArgument='<%# Eval("CRMCIF_ID") %>'
                                        CommandName="Change">编辑</asp:LinkButton>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="dele" runat="server" CommandArgument='<%# Eval("CRMCIF_ID") %>'
                                        CommandName="dele" OnClientClick="return confirm('您确认删除该记录吗?')" >删除</asp:LinkButton>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Phone" runat="server" CommandArgument='<%# Eval("CRMCIF_ID") %>'
                                        CommandName="Phone">联系方式</asp:LinkButton>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="Label" runat="server" CommandArgument='<%# Eval("CRMCIF_ID") %>'  
                                        CommandName="Label">物料标签</asp:LinkButton>
                                </ItemTemplate>
                        </asp:TemplateField>
                            <asp:BoundField DataField="CRMCIF_SalesMan" SortExpression="CRMCIF_SalesMan" HeaderText="业务员" ReadOnly="true"></asp:BoundField>
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
   
<asp:UpdatePanel ID="UpdatePanel_NewClient" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false" >
        <ContentTemplate>
           <asp:Panel ID="Panel_NewClient" runat="server" Visible="false">
           <fieldset>
           <legend>新增客户</legend>
           <table style="width: 100%;" >
            <tr style="width: 100%;">
            <td style="width: 4%;">客户名称：</td>
            <td style="width: 7%;"><asp:TextBox ID="TextBox_NewCliengName" runat="server" Width="80%"></asp:TextBox></td>
            <td style="width: 4%;">区域名称：</td>
            <td style="width: 7%;">
                <asp:DropDownList ID="DropDownList_NewClientRegion" runat="server" 
                    AppendDataBoundItems="true" AutoPostBack="true" DataTextField="CRMRBI_Name" 
                    DataValueField="CRMRBI_Name" Width="80px">
                    <asp:ListItem Text="请选择" Value="请选择"></asp:ListItem>
                </asp:DropDownList>
                </td>
            <td style="width: 4%;">客户类别：</td>
            <td style="width: 7%;"><asp:DropDownList ID="DropDownList_NewClientSort" runat="server" Width="80px" AutoPostBack="true" DataTextField="CRMCSBD_Name" DataValueField="CRMCSBD_Name" AppendDataBoundItems="true" >
                                    <asp:ListItem Value="请选择" Text="请选择"></asp:ListItem>
                                </asp:DropDownList></td>
            <td style="width: 6%;">有无物料标签：</td>
            <td style="width: 7%;"><asp:DropDownList ID="DropDownList_NewIsLabel" runat="server" Width="50px" 
             Height="19px">
                                    <asp:ListItem Value="有" Text="有"></asp:ListItem>
                                    <asp:ListItem Value="无" Text="无"></asp:ListItem>
                                </asp:DropDownList></td>
            </tr>
               <tr ><td style="width: 4%;">业务员：</td>
            <td style="width: 7%;">   <asp:DropDownList ID="DropDownList1" runat="server" 
                     Width="80px">
                
                </asp:DropDownList></td></tr>
            <tr style="width: 100%;">
            <td style="width: 4%;">客户地址：</td>
            <td colspan="7">
                <asp:TextBox ID="TextBox_NewClientAdress" runat="server" Width="90%" Height="81px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            </table>
        <table style="width: 100%;" >
            <tr style="width: 100%;">
            <td style="width: 4%;"></td>
            <td style="width: 5%;">
                <asp:Button ID="Btn_NewClientOk" runat="server" CssClass="Button02" 
                    Height="24px" Text="提交" Width="80px" onclick="Btn_NewClientOk_Click" /></td>
            <td style="width: 1%;"></td>
            <td style="width: 4%;"><asp:Button ID="Btn_NewClientCancel" runat="server" 
             CssClass="Button02" Height="24px" Text="关闭" Width="80px" 
                    onclick="Btn_NewClientCancel_Click" /></td>
            <td style="width: 4%;"></td>
            </tr>
            </table>       
           </fieldset>
           </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdatePanel_ChangeClient" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false" >
        <ContentTemplate>
           <asp:Panel ID="Panel_ChangeClient" runat="server" Visible="false">
           <fieldset>
           <legend>编辑客户</legend>
           <table style="width: 100%;" >
            <tr style="width: 100%;">
            <td style="width: 4%;">客户名称：</td>
            <td style="width: 7%;"><asp:TextBox ID="TextBox_ChanClientName" runat="server" Width="80%"></asp:TextBox></td>
            <td style="width: 4%;">区域名称：</td>
            <td style="width: 7%;">
                <asp:DropDownList ID="DropDownList_ChangeClientRegion" runat="server" 
                    AppendDataBoundItems="true" AutoPostBack="true" DataTextField="CRMRBI_Name" 
                    DataValueField="CRMRBI_Name" Width="80px">
                    <asp:ListItem Text="请选择" Value="请选择"></asp:ListItem>
                </asp:DropDownList>
                </td>
            <td style="width: 4%;">客户类别：</td>
            <td style="width: 7%;"><asp:DropDownList ID="DropDownList_ChanClientSort" runat="server" Width="80px" AutoPostBack="true" DataTextField="CRMCSBD_Name" DataValueField="CRMCSBD_Name" AppendDataBoundItems="true" >
                                    <asp:ListItem Value="请选择" Text="请选择"></asp:ListItem>
                                </asp:DropDownList></td>
            <td style="width: 6%;">有无物料标签：</td>
            <td style="width: 7%;"><asp:DropDownList ID="DropDownList_ChanIsLabel" runat="server" Width="50px" 
             Height="19px">
                                    <asp:ListItem Value="有" Text="有"></asp:ListItem>
                                    <asp:ListItem Value="无" Text="无"></asp:ListItem>
                                </asp:DropDownList></td>
            </tr>
               <tr ><td style="width: 4%;">业务员：</td>
            <td style="width: 7%;">   <asp:DropDownList ID="DropDownList2" runat="server" 
                     Width="80px">
                    
                </asp:DropDownList></td></tr>

            <tr style="width: 100%;">
            <td style="width: 4%;">客户地址：</td>
            <td colspan="7">
                <asp:TextBox ID="TextBox_ChanClientAdress" runat="server" Width="90%" Height="81px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            </table>
        <table style="width: 100%;" >
            <tr style="width: 100%;">
            <td style="width: 4%;"></td>
            <td style="width: 5%;">
                <asp:Button ID="Btn_ChanClientOk" runat="server" CssClass="Button02" 
                    Height="24px" Text="提交" Width="80px" onclick="Btn_ChanClientOk_Click" /></td>
            <td style="width: 1%;"></td>
            <td style="width: 4%;"><asp:Button ID="Btn_ChanClientCancel" runat="server" 
             CssClass="Button02" Height="24px" Text="关闭" Width="80px" 
                    onclick="Btn_ChanClientCancel_Click" /></td>
            <td style="width: 4%;"></td>
            </tr>
            </table>       
           </fieldset>
           </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdatePanel_ClientPhone" runat="server" UpdateMode="Conditional" >
        <ContentTemplate>
           <asp:Panel ID="Panel_ClientPhone" runat="server" Visible="false">
           <fieldset>
           <table style="width: 100%;"> 
                            <tr style="width: 100%;">
                                <td >
                                    <asp:Button ID="Btn_NewClientPhone" runat="server" CssClass="Button02" Height="24px" 
                                        Text="新增联系方式" Width="90px" onclick="Btn_NewClientPhone_Click"/>
                                </td>
                            </tr>
     </table>          
           <legend>客户联系方式表</legend>
           <asp:GridView ID="GridView_ClientPhone" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        PageSize="5" CellPadding="0" UseAccessibleHeader="False" AllowPaging="True" GridLines="None"
                        Width="100%" DataKeyNames="CRMCC_ID" OnRowCommand="GridView_Phone_RowCommand" OnPageIndexChanging="GridView_Phone_PageIndexChanging" OnRowDataBound="GridView_OrderDetail_RowDataBound" >
                         <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                        <asp:BoundField DataField="CRMCC_ID" HeaderText="联系人ID" SortExpression="CRMCC_ID" Visible="false" ReadOnly="true"></asp:BoundField>
                         <asp:BoundField DataField="CRMCC_Name" SortExpression="CRMCC_Name" HeaderText="客户名称" ReadOnly="true"></asp:BoundField>
                         <asp:BoundField DataField="CRMCC_Position" SortExpression="CRMCC_Position" HeaderText="职位" ReadOnly="true"></asp:BoundField>
                         <asp:BoundField DataField="CRMCC_PhoneNum" SortExpression="CRMCC_PhoneNum" HeaderText="电话" ReadOnly="true"></asp:BoundField>
                         <asp:BoundField DataField="CRMCC_TelePhoneNum" SortExpression="CRMCC_TelePhoneNum" HeaderText="手机" ReadOnly="true"></asp:BoundField>
                         <asp:BoundField DataField="CRMCC_FaxNum" SortExpression="CRMCC_FaxNum" HeaderText="传真" ReadOnly="true"></asp:BoundField>
                         <asp:BoundField DataField="CRMCC_Email" SortExpression="CRMCC_Email" HeaderText="邮箱" ReadOnly="true"></asp:BoundField>
                         <asp:BoundField DataField="CRMCC_QQ" SortExpression="CRMCC_QQ" HeaderText="QQ" ReadOnly="true"></asp:BoundField>
                             <asp:BoundField DataField="CRMCC_I" SortExpression="CRMCC_I" HeaderText="常用联系人" ReadOnly="true"></asp:BoundField>
                         <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Change" runat="server" CommandArgument='<%# Eval("CRMCC_ID") %>'
                                        CommandName="Change">编辑</asp:LinkButton>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                                <ItemTemplate>
                        <asp:LinkButton ID="dele11" runat="server" CommandArgument='<%# Eval("CRMCC_ID") %>'
                                        CommandName="dele11" OnClientClick="return confirm('您确认删除该记录吗?')">删除</asp:LinkButton>
                                </ItemTemplate>
                        </asp:TemplateField>
                              <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="dele111" runat="server" CommandArgument='<%# Eval("CRMCC_ID") %>'
                                        CommandName="Important1">设为/取消常用联系人</asp:LinkButton>
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
<table style="width: 100%;" >
            <tr style="width: 100%;">
            
            <td align="center"><asp:Button ID="Btn_NewClientPhoneCancel" runat="server" 
             CssClass="Button02" Height="24px" Text="关闭" Width="80px" 
                    onclick="Btn_NewClientPhoneCancel_Click" /></td>
            </tr>
            </table>
                        
           </fieldset>
           </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdatePanel_NewClientPhone" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false" >
        <ContentTemplate>
           <asp:Panel ID="Panel_NewClientPhone" runat="server" Visible="false">
           <fieldset>
           <legend>新增联系方式</legend>
           <table style="width: 100%;" >
            <tr style="width: 100%;">
            <td style="width: 10%;" align="right">姓名：</td>
            <td style="width: 15%;"><asp:TextBox ID="TextBox_NewPhoneName" runat="server" Width="100%" ></asp:TextBox></td>
            <td style="width:10%;" align="right">职位：</td>
            <td style="width: 15%;"><asp:TextBox ID="TextBox_NewPhonePosition" runat="server" Width="100%"></asp:TextBox></td>
            <td style="width: 10%;" align="right">电话：</td>
            <td style="width: 15%;">
                <asp:TextBox ID="TextBox_NewPhoneCall" runat="server" Width="100%"></asp:TextBox>
                </td>
            <td style="width: 10%;" align="right"> 手机：</td>
            <td style="width: 15%;">
                <asp:TextBox ID="TextBox_NewPhoneMobile" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr style="width: 100%;">
            <td style="width: 4%;" align="right">传真：</td>
            <td style="width: 7%;"><asp:TextBox ID="TextBox_NewPhoneFax" runat="server" Width="100%"></asp:TextBox></td>
            <td style="width: 4%;" align="right">邮箱：</td>
            <td style="width: 7%;"><asp:TextBox ID="TextBox_NewPhoneE_Mail" runat="server" Width="100%"></asp:TextBox></td>
            <td style="width: 4%;" align="right"> QQ：</td>
            <td style="width: 7%;">
                <asp:TextBox ID="TextBox_NewPhoneQQ" runat="server" Width="100%"></asp:TextBox>
                </td>
            <td style="width: 5%;">&nbsp;</td>
            <td style="width: 7%;">&nbsp;</td>
            </tr>
            <%--</table>
            <table style="width: 100%;" >--%>
            <tr style="width: 100%;">
            <td style="width: 4%;"></td>
            <td  colspan="4" align="center">
                <asp:Button ID="Btn_NewPhoneOk" runat="server" CssClass="Button02" 
                    Height="24px" Text="提交" Width="80px" onclick="Btn_NewPhoneOk_Click" /></td>
          
            <td  colspan="4" align="center"><asp:Button ID="Btn_NewPhongCancel" runat="server" 
             CssClass="Button02" Height="24px" Text="关闭" Width="80px" 
                    onclick="Btn_NewPhongCancel_Click" /></td>
            <td style="width: 4%;"></td>
            </tr>
            </table> 

            </fieldset>
           </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
     <asp:UpdatePanel ID="UpdatePanel_ChanClientPhone" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false" >
        <ContentTemplate>
           <asp:Panel ID="Panel_ChanClientPhone" runat="server" Visible="false">
           <fieldset>
           <legend>编辑联系方式</legend>
           <table style="width: 100%;" >
            <tr style="width: 100%;">
            <td style="width: 10%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 姓名：</td>
            <td style="width: 15%"><asp:TextBox ID="TextBox_ChanPhoneName" runat="server" Width="100%" ></asp:TextBox></td>
            <td style="width: 10%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 职位：</td>
            <td style="width: 15%"><asp:TextBox ID="TextBox_ChanPhonePosition" runat="server" Width="100%"></asp:TextBox></td>
            <td style="width: 10%; height: 21px;">&nbsp;&nbsp;&nbsp;&nbsp; 电话：</td>
            <td style="width: 15%; height: 21px;">
                <asp:TextBox ID="TextBox_ChanPhoneCall" runat="server" Width="100%"></asp:TextBox>
                </td>
            <td style="width: 10%; height: 21px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 手机：</td>
            <td style="width: 15%; height: 21px;">
                <asp:TextBox ID="TextBox_ChanPhoneMobile" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr style="width: 100%;">
            <td style="width: 4%;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 传真：</td>
            <td style="width: 7%;"><asp:TextBox ID="TextBox_ChanPhoneFax" runat="server" Width="100%"></asp:TextBox></td>
            <td style="width: 4%;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 邮箱：</td>
            <td style="width: 7%;"><asp:TextBox ID="TextBox_ChanPhoneE_Mail" runat="server" Width="100%"></asp:TextBox></td>
            <td style="width: 4%;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; QQ：</td>
            <td style="width: 7%;">
                <asp:TextBox ID="TextBox_ChanPhoneQQ" runat="server" Width="100%"></asp:TextBox>
                </td>
            <td style="width: 5%;">&nbsp;</td>
            <td style="width: 7%;">&nbsp;</td>
            </tr>
            </table>
            <table style="width: 100%;" >
            <tr style="width: 100%;">
            <td style="width: 4%;"></td>
            <td  colspan="4" align="center">
                <asp:Button ID="Btn_ChanPhoneOk" runat="server" CssClass="Button02" 
                    Height="24px" Text="提交" Width="80px" onclick="Btn_ChanPhoneOk_Click" /></td>
          
            <td  colspan="4" align="center"><asp:Button ID="Btn_ChanPhoneCancel" runat="server" 
             CssClass="Button02" Height="24px" Text="关闭" Width="80px" 
                    onclick="Btn_ChanPhoneCancel_Click" /></td>
            <td style="width: 4%;"></td>
            </tr>
            </table> 

            </fieldset>
           </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdatePanel_ClientLabel" runat="server" UpdateMode="Conditional" >
        <ContentTemplate>
           <asp:Panel ID="Panel_UpdatePanel_ClientLabel" runat="server" Visible="false">
                 <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label>
           <fieldset>
           <asp:Button ID="Button_NewLabel" runat="server" CssClass="Button02" 
                    Height="24px" onclick="Button_NewLabel_Click" Text="新增物料标签" Width="90px" />
           <legend>客户物料标签表</legend>
           <asp:GridView ID="GridView_ClientLabel" runat="server" AutoGenerateColumns="false" CssClass="GridViewStyle"
                        PageSize="5" CellPadding="0" UseAccessibleHeader="False" AllowPaging="True" GridLines="None"
                        Width="100%" DataKeyNames="CRMCBTD_ID" OnRowCommand="GridView_ClientLabel_RowCommand" OnPageIndexChanging="GridView_ClientLabel_PageIndexChanging" >
                         <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                        <asp:BoundField DataField="CRMCBTD_ID" HeaderText="物料标签ID" SortExpression="CRMCBTD_ID" Visible="false" ReadOnly="true" >
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCIF_Name" HeaderText="客户名称" SortExpression="CRMCIF_Name"  ReadOnly="true" >
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCBTD_CustomerProductModel" HeaderText="客户产品型号" SortExpression="CRMCBTD_CustomerProductModel" ReadOnly="true" >
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCBTD_Name" HeaderText="物料标签名称" SortExpression="CRMCBTD_Name" ReadOnly="true" >
                            </asp:BoundField>
                            <asp:BoundField DataField="CRMCBTD_Num" HeaderText="物料标签编号" SortExpression="CRMCBTD_Num" ReadOnly="true" >
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="bianji" runat="server" CommandArgument='<%# Eval("CRMCBTD_ID") %>'
                                        CommandName="bianji">编辑</asp:LinkButton>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="shanchu" runat="server" CommandArgument='<%# Eval("CRMCBTD_ID") %>'
                                        CommandName="shanchu" OnClientClick="return confirm('您确认删除该记录吗?')" >删除</asp:LinkButton>
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
                        <table style="width: 100%;" >
            <tr style="width: 100%;">
            
            <td align="center"><asp:Button ID="Btn_SeeLabelCancel" runat="server" 
             CssClass="Button02" Height="24px" Text="关闭" Width="80px" 
                    onclick="Btn_SeeLabelCancel_Click" /></td>
            </tr>
            </table>
           </fieldset>
           </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
     <asp:UpdatePanel ID="UpdatePanel_NewLabel" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false" >
        <ContentTemplate>
           <asp:Panel ID="Panel_New_Label" runat="server" Visible="false">
           <fieldset>
           <legend>新增物料标签</legend>
           <table style="width: 100%;" >
           <tr><td style="width: 4%; height: 21px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 产品型号：</td>
            <td style="width: 7%; height: 21px;"><asp:TextBox ID="TextBox_LablProduct" runat="server" Width="100%"></asp:TextBox></td>
            <td style="width: 4%; height: 21px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 物料名称：</td>
            <td style="width: 7%; height: 21px;"><asp:TextBox ID="TextBox_LabelName" runat="server" Width="100%"></asp:TextBox></td>
            <td style="width: 4%; height: 21px;">&nbsp;&nbsp;&nbsp;&nbsp; 物料编号：</td>
            <td style="width: 7%; height: 21px;">
                <asp:TextBox ID="TextBox_LabelNumber" runat="server" Width="100%"></asp:TextBox>
                </td></tr>
            </table>
            <table style="width: 100%;" >
            <tr style="width: 100%;">
            <td style="width: 4%;"></td>
            <td style="width: 5%;">
                <asp:Button ID="Btn_NewLabelOk" runat="server" CssClass="Button02" 
                    Height="24px" Text="提交" Width="80px" onclick="Btn_NewLabelOk_Click"  /></td>
            <td style="width: 1%;"></td>
            <td style="width: 4%;">
                <asp:Button ID="Button2" runat="server" 
             CssClass="Button02" Height="24px" Text="关闭" Width="80px" onclick="Button2_Click" 
                     /></td>
            <td style="width: 4%;"></td>
            </tr>
            </table> 
            
            </fieldset>
           </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_ChangeLabel" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false" >
        <ContentTemplate>
           <asp:Panel ID="Panel_ChangeLabel" runat="server" Visible="false">
           <fieldset>
           <legend>编辑物料标签</legend>
           <table style="width: 100%;" >
           <tr>
           <td style="width: 4%; height: 21px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;客户名称：</td>
            <td style="width: 7%; height: 21px;"><asp:TextBox ID="TextBox_ChanLabelName" runat="server" Width="100%" ReadOnly="true" Enabled="false"></asp:TextBox></td>
           <td style="width: 4%; height: 21px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 产品型号：</td>
            <td style="width: 7%; height: 21px;"><asp:TextBox ID="TextBox_ChanLabelPro" runat="server" Width="100%"></asp:TextBox></td>
            
            </tr>
            <tr>
            <td style="width: 4%; height: 21px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 物料名称：</td>
            <td style="width: 7%; height: 21px;"><asp:TextBox ID="TextBox_ChanLabelWu" runat="server" Width="100%"></asp:TextBox></td>
            <td style="width: 4%; height: 21px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 物料编号：</td>
            <td style="width: 7%; height: 21px;">
                <asp:TextBox ID="TextBox_ChanLabelWuName" runat="server" Width="100%"></asp:TextBox>
                </td></tr>
            </table>
            <table style="width: 100%;" >
            <tr style="width: 100%;">
            <td style="width: 4%;"></td>
            <td style="width: 5%;">
                <asp:Button ID="Btn_ChangeLabel" runat="server" CssClass="Button02" 
                    Height="24px" Text="提交" Width="80px" onclick="Btn_ChangeLabel_Click" /></td>
            <td style="width: 1%;"></td>
            <td style="width: 4%;">
                <asp:Button ID="Btn_CancelChange" runat="server" 
             CssClass="Button02" Height="24px" Text="关闭" Width="80px" 
                    onclick="Btn_CancelChange_Click" /></td>
            <td style="width: 4%;"></td>
            </tr>
            </table> 
            
            </fieldset>
           </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
