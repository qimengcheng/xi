<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PMPSupply.aspx.cs" Inherits="PMP_PMPSupply" MasterPageFile="~/Other/MasterPage.master" %>

<script runat="server">

</script>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script> 
    <asp:UpdatePanel ID="UpdatePanel_SupplySearch" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_SupplySearch" runat="server" Visible="true">
                <fieldset>
                    <legend> 供应商查询
                    <asp:Label ID="label_pagestate" runat="server" Visible="False"/>
                    
                    </legend>
    <table style="width: 100%;">
         <asp:Label ID="label_supplytype" runat="server" Visible="False"></asp:Label>
         <asp:Label ID="label_supplytypeid" runat="server" Visible="False"></asp:Label>
             <asp:Label ID="labelcodition" runat="server" Visible="False"></asp:Label>
             <asp:Label ID="label1_PanelSupply" runat="server" Visible="False"></asp:Label>
             <asp:Label ID="label1_BasicID" runat="server" Visible="False"></asp:Label>
             <asp:Label ID="label_SName" runat="server" Visible="False"></asp:Label>
             <asp:Label ID="label_SNum" runat="server" Visible="False"></asp:Label>
        <tr>
            <td style="width: 15%" align="center">
                <asp:Label ID="Label" runat="server" Text="供应商类别："></asp:Label>
            </td>
            <td style="width: 20%" align="left">
                <asp:DropDownList ID="DropDownList1" runat="server" Width="121px">
                    <asp:ListItem>生产物资A类</asp:ListItem>
                    <asp:ListItem>生产物资B类</asp:ListItem>
                    <asp:ListItem>生产物资C类</asp:ListItem>
                    <asp:ListItem>工程项目业务类</asp:ListItem>
                    <asp:ListItem>生产工模具类</asp:ListItem>
                    <asp:ListItem>运输类</asp:ListItem>
                    <asp:ListItem>其他</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="width: 15%" align="center">
                <asp:Label ID="Label15" runat="server" Text="供应商名称："></asp:Label>
            </td>
            <td style="width: 20%" align="left">
                <asp:TextBox runat="server" ID="SupplyName"> </asp:TextBox>
            </td>
            <td style="width: 15%" align="center">
                <asp:Label ID="Label5" runat="server" Text="供应商编号："></asp:Label>
            </td>
            <td style="width: 20%" align="left">
                <asp:TextBox runat="server" ID="PMSI_SupplyNum" 
                onkeyup="this.value=this.value.replace(/[^0-9-]/g,'')"
                                    onafterpaste="this.value=this.value.replace(/[^0-9-]/g,'')"> 
                                    </asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="right">
                <asp:Button ID="Button1" runat="server" Text="检索" CssClass="Button02" Height="24px" OnClick="Button1_Sh"
                    Width="70px" />
            </td>
            <td colspan="2" align="center">
                <asp:Button ID="Button2" runat="server" Text="新增" CssClass="Button02" Height="24px" OnClick="Button2_Nw"
                    Width="70px" />
            </td>
            <td colspan="2" align="left">
                <asp:Button ID="Button3" runat="server" Text="重置" CssClass="Button02" Height="24px" OnClick="Button3_Reset" Visible="true"
                    Width="70px" />
            </td>
        </tr>
    </table>
     </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
  
<asp:UpdatePanel ID="UpdatePanel_SupplyInfo" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <asp:Panel ID="Panel_SupplyInfo" runat="server" Visible="true">
            <fieldset>
                <legend>
                供应商列表
                </legend>
                <asp:GridView ID="Gridview_SupplyInfo"  runat="server" AutoGenerateColumns="False"
                    CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False"  
                     PageSize="20" 
                    OnRowCommand="Gridview_SupplyInfo_RowCommand"  
                    AllowPaging="True" AllowSorting="True" DataKeyNames="PMSI_ID"   OnPageIndexChanging="Gridview_SupplyInfo_PageIndexChanging" 
                    Width="100%"  Font-Strikeout="False" GridLines="None" 
                    ondatabound="Gridview_SupplyInfo_DataBound">
                    <%--    //隔行变色--%>
           
           
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                    <PagerStyle CssClass="GridViewPagerStyle" />
              <AlternatingRowStyle />
                    <Columns>
                        <asp:BoundField DataField="PMSI_ID" HeaderText="供应商ID" ReadOnly="True"
                            SortExpression="PMSI_ID" Visible="False">
                            <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PMSI_SupplyNum" HeaderText="供应商编号" ReadOnly="True"
                            SortExpression="PMSI_SupplyNum" />
                        <asp:BoundField DataField="PMSI_SupplyName" HeaderText="供应商名称" SortExpression="PMSI_SupplyName">
                            <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PMSI_SupplySort" HeaderText="供应商类别" SortExpression="PMSI_SupplySort">
                            <ItemStyle  />
                        </asp:BoundField>
                         <asp:BoundField DataField="PMSI_PaymentTime" HeaderText="账期" 
                            SortExpression="PMSI_PaymentTime" />
                         <asp:BoundField DataField="PMSI_Remark" HeaderText="备注" SortExpression="PMSI_Remark">
                            <ItemStyle  />
                        </asp:BoundField>
                        <asp:TemplateField >
                            <ItemTemplate >
                                <asp:LinkButton ID="btnLook1" runat="server" CommandName="Look1" OnClientClick="false" 
                                    CommandArgument='<%#Eval("PMSI_ID")%>'>联系方式</asp:LinkButton>
                                   
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnEdit1" runat="server" CommandName="Edit1" OnClientClick="false"
                                    CommandArgument='<%#Eval("PMSI_ID")%>'>编辑</asp:LinkButton>
                            </ItemTemplate>
                          
                        </asp:TemplateField>
                       <%-- <asp:CommandField ShowEditButton="True" EditText="编辑" UpdateText="更新" CancelText="取消">
                                <ItemStyle Width="10%" />
                            </asp:CommandField>--%>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnDelete1" runat="server" CommandName="Delete1"  OnClientClick="return confirm('您确认删除该记录吗?')"
                                    CommandArgument='<%#Eval("PMSI_ID")%>'>删除</asp:LinkButton>
                            </ItemTemplate>
                           
                        </asp:TemplateField>
                    </Columns>
               <EmptyDataTemplate>
              <asp:Label ID="Label50" runat="server" Text="无相关记录！"></asp:Label>
             </EmptyDataTemplate>
                    <FooterStyle CssClass="GridViewFooterStyle" />
                    <HeaderStyle CssClass="GridViewHead"
                        HorizontalAlign="Center" />
           
           
            <PagerStyle  ForeColor="Black" 
                 HorizontalAlign="Center" CssClass="GridViewPagerStyle" />
                            <PagerTemplate>
                   <table width="100%">
                    <tr>
                   <td style="text-align:right">
                       第<asp:Label id="lblPageIndex" runat="server" text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>' />
                       页 共<asp:Label id="lblPageCount" runat="server" text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />
                       页 
                    <asp:linkbutton id="btnFirst" runat="server" causesvalidation="False" commandargument="First" commandname="Page" text="首页" />
                  <asp:linkbutton id="btnPrev" runat="server" causesvalidation="False" commandargument="Prev" commandname="Page" text="上一页" />
                     <asp:linkbutton id="btnNext" runat="server" causesvalidation="False" commandargument="Next" commandname="Page" text="下一页" />                          
                      <asp:linkbutton id="btnLast" runat="server" causesvalidation="False" commandargument="Last" commandname="Page" text="尾页" />  
                       <asp:TextBox ID="textbox" runat="server" width="20px"></asp:TextBox>                                          
                       <asp:linkbutton id="btnGo" runat="server" causesvalidation="False" commandargument="-1" commandname="Page" text="GO" /><!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
                         </td>
                        </tr>
                     </table>
            </PagerTemplate>
           
           
                    <RowStyle CssClass="GridViewRowStyle" />
                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                </asp:GridView>
                </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

<asp:UpdatePanel ID="UpdatePanel_PMSupplyContact" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_PMSupplyContact" runat="server" Visible="false">
                <fieldset>
                    <legend>
                    <asp:Label ID="Label_SupplyContact_Source" runat="server" Visible="true"></asp:Label>
                    </legend>
                <asp:Button ID="Button8" runat="server" Text="新增联系方式" CssClass="Button02" Height="24px" OnClick="CreateSupplyContact "
                    Width="110px" />
                    <asp:GridView ID="GridView_PMSupplyContact" runat="server" 
                        AutoGenerateColumns="false" CssClass="GridViewStyle"
                        PageSize="2" CellPadding="0" UseAccessibleHeader="False" 
                        OnRowCreated="GridView_SupplyInfo_RowCreated" OnRowCommand="GridView_PMSupplyContact_RowCommand"
                        Width="100%" DataKeyNames="PMSC_ID"   OnPageIndexChanging="GridView_PMSupplyContact_PageIndexChanging"
                        Font-Strikeout="False" GridLines="None"
                        >
                        <%--<AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" /> OnRowEditing="Gridview_PS_Editing"
                        OnRowCancelingEdit="Gridview_PS_CancelingEdit"OnSorting="GridView__Sorting" OnRowUpdating="Gridview_PS_Updating"--%>
                        <%--控制 GridView 控件中交替数据行的外观--AllowPaging="True" OnRowCommand="GridView_MatBasicData_RowCommand"
                        OnPageIndexChanging="GridView_MatBasicData_PageIndexChanging" 
                        AllowSorting="True" OnRowCreated="GridView_MatType_RowCreated"
                         OnRowDataBound="GridView_MatBasicData_RowDataBound"%>
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <%--控制 GridView 控件中脚注行的外观--%>
                        <RowStyle CssClass="GridViewRowStyle" />
                        <%--行外观--%>
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" 
                            HorizontalAlign="Center" />
                        <Columns>
                            <asp:BoundField DataField="PMSC_ID" HeaderText="供应商联系人ID" SortExpression="PMSC_ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="PMSI_ID" HeaderText="供应商编号" SortExpression="PMSI_ID" Visible="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="PMSC_Name" HeaderText="姓名" SortExpression="PMSC_Name">
                            <ItemStyle />
                            </asp:BoundField>

                            <asp:BoundField DataField="PMSC_Position" SortExpression="PMSC_Position" HeaderText="职位"></asp:BoundField>
                             <asp:BoundField DataField="PMSC_TelephoneNum" SortExpression="PMSC_TelephoneNum" HeaderText="电话"></asp:BoundField>
                              <asp:BoundField DataField="PMSC_PhoneNum" SortExpression="PMSC_PhoneNum" HeaderText="手机"></asp:BoundField>
                               <asp:BoundField DataField="PMSC_FaxNum" SortExpression="PMSC_FaxNum" HeaderText="传真"></asp:BoundField>
                                <asp:BoundField DataField="PMSC_Email" SortExpression="PMSC_Email" HeaderText="邮箱"></asp:BoundField>
                                   <asp:BoundField DataField="PMSC_QQ" SortExpression="PMSC_QQ" HeaderText="QQ"></asp:BoundField>                                  
                           <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Edit2" runat="server" CommandArgument='<%# Eval("PMSC_ID") %>'
                                        CommandName="Edit2" >编辑</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>  
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Delete2" runat="server" CommandArgument='<%# Eval("PMSC_ID") %>'
                                        CommandName="Delete2" OnClientClick="return confirm('您确认删除该记录吗?')">删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>    
                        </Columns>
                        <PagerTemplate >
                            <table width="100%" >
                                <tr>
                              
                                    <td style="text-align: right" colspan="2">
                                        第<asp:Label ID="lblPageIndex" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                        页 共<asp:Label ID="lblPageCount" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageCount  %>" />
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
                                
            </tr>
                            </table>
                        </PagerTemplate>

                        <PagerStyle  ForeColor="Black" HorizontalAlign="Center"
                            CssClass="GridViewPagerStyle" />
                        <EmptyDataTemplate>
                            <asp:Label ID="Label16" runat="server" Text="无相关记录！"></asp:Label>
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <table width="100%">
                                <tr>
            
            <td align="center">
                <asp:Button ID="Button9" runat="server" Text="关闭" CssClass="Button02" Height="24px" OnClick="CanelSupplyContact1"
                    Width="70px" />
            </td>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
   
      <asp:UpdatePanel ID="UpdatePanel_PMSupplyInfo" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_PMSupplyInfo" runat="server" Visible="False">
                <fieldset>
                    <legend> <asp:Label ID="Label_Supply" runat="server" Visible="true"></asp:Label></legend>
    <table style="width: 100%;">
    <tr>
         <td style="width: 10%" align="right">
                <asp:Label ID="Label3" runat="server" Text="供应商名称："></asp:Label>
            </td>
            
               <td style="width: 20%" align="left">
                <asp:TextBox runat="server" ID="TextBox2"  Enabled="True"></asp:TextBox>
           <asp:Label ID="Label14" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
             <td style="width: 10%" align="right" >
                 <asp:Label ID="Label11" runat="server" Text="供应商类别："></asp:Label>
         </td>
            

            <td style="width: 20%" align="left">
        <asp:DropDownList ID="DropDownList3" runat="server" Width="123px" >
                     <asp:ListItem>请选择</asp:ListItem>
                     <asp:ListItem>生产物资A类</asp:ListItem>
                    <asp:ListItem>生产物资B类</asp:ListItem>
                    <asp:ListItem>生产物资C类</asp:ListItem>
                    <asp:ListItem>工程项目业务类</asp:ListItem>
                    <asp:ListItem>生产工模具类</asp:ListItem>
                    <asp:ListItem>运输类</asp:ListItem>
                    <asp:ListItem>其他</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="Label10" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </td>
                  <td style="width: 10%" align="right">
                <asp:Label ID="Label13" runat="server" Text="账期："></asp:Label>
            </td>
            
               <td style="width: 20%" align="left">
                <asp:TextBox runat="server" ID="TextBox3"  Enabled="True" onkeyup="this.value=this.value.replace(/[^0-9]/g,'')"
                                    onafterpaste="this.value=this.value.replace(/[^0-9]/g,'')"></asp:TextBox>
           
            </td>
                </tr>
                <tr>
                <td style="width: 10%; height: 81px;" align="right">
                <asp:Label ID="Label9" runat="server" Text="备注："></asp:Label>
                <br/>
                <asp:Label ID="Label_XZ2" runat="server" Text="(200字以内)"></asp:Label>
            </td>
            
               <td style="width: 20%; height: 81px;" align="left" colspan="6">
                <asp:TextBox runat="server" ID="TextBox1"  Enabled="True" Height="75px" 
                       Width="638px"   MaxLength="200" TextMode="MultiLine"
                 onkeyup="this.value = this.value.substring(0, 200)" 
                       onafterpaste="this.value = this.value.substring(0, 200)"></asp:TextBox>
            </td>
                </tr>

    <tr>
    <td style="width: 20%"  >
                 
                 </td>
            <td colspan="2" align="center">
                <asp:Button ID="Button6" runat="server" Text="提交" CssClass="Button02" Height="24px" OnClick="ConfirmSupply "
                    Width="70px" />
            </td>
            <td colspan="2" align="right">
                <asp:Button ID="Button7" runat="server" Text="关闭" CssClass="Button02" 
                    Height="24px" OnClick="CanelSupply"
                    Width="70px" />
            </td>
            <td style="width: 20%"  >
                 
                 </td>
            </tr>
    </table>
     </fieldset>
     </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
  
    <asp:UpdatePanel ID="UpdatePanel_SupplyContactNew" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_SupplyContactNew" runat="server" Visible="False">
                <fieldset>
                    <legend> 
                    <asp:Label ID="Label_Change" runat="server" Visible="true"></asp:Label>
                    </legend>
    <table style="width: 100%;">
    <tr>
     <td style="width: 15%" align="right">
                <asp:Label ID="Label12" runat="server" Text="姓名："></asp:Label>
            </td>
            <td style="width: 20%" align="left">
                <asp:TextBox runat="server" ID="TextBox_PMSC_Name"> </asp:TextBox>
            </td>
            <td style="width: 10%" align="right">
                <asp:Label ID="Label4" runat="server" Text="职位："></asp:Label>
            </td>
            <td style="width: 20%" align="left">
                <asp:TextBox runat="server" ID="TextBox_PMSC_Position"> </asp:TextBox>
            </td>
   <td style="width: 10%" align="right">
                <asp:Label ID="Label1" runat="server" Text="电话："></asp:Label>
            </td>
            <td style="width: 20%" align="left">
                <asp:TextBox runat="server" ID="TextBox_PMSC_TelephoneNum"
                onkeyup="this.value=this.value.replace(/[^0-9-]/g,'')"
                                    onafterpaste="this.value=this.value.replace(/[^0-9-]/g,'')"> </asp:TextBox>
            </td>
            <tr>
          <td style="width: 10%" align="right">
                <asp:Label ID="Label2" runat="server" Text="手机："></asp:Label>
            </td>
            <td style="width: 20%" align="left">
                <asp:TextBox runat="server" ID="TextBox_PMSC_PhoneNum"
                onkeyup="this.value=this.value.replace(/[^0-9]/g,'')"
                                    onafterpaste="this.value=this.value.replace(/[^0-9]/g,'')"> 
                </asp:TextBox>
            </td>  
             <td style="width: 10%" align="right">
                <asp:Label ID="Label6" runat="server" Text="传真："></asp:Label>
            </td>
            <td style="width: 20%" align="left">
                <asp:TextBox runat="server" ID="TextBox_PMSC_FaxNum"
                onkeyup="this.value=this.value.replace(/[^0-9-]/g,'')"
                                    onafterpaste="this.value=this.value.replace(/[^0-9-]/g,'')"> </asp:TextBox>
            </td> 

            <td style="width: 10%" align="right">
                <asp:Label ID="Label7" runat="server" Text="邮箱："
                onkeyup="this.value=this.value.replace(/^[0-9a-zA-Z]+@(([0-9a-zA-Z]+)[.])+[a-z]{2,4}$/i,'')"
                                    onafterpaste="this.value=this.value.replace(/^[0-9a-zA-Z]+@(([0-9a-zA-Z]+)[.])+[a-z]{2,4}$/i,'')"
                ></asp:Label>
            </td>
            <td style="width: 20%" align="left">
                <asp:TextBox runat="server" ID="TextBox_PMSC_Email"
                > </asp:TextBox>
            </td>  
            </tr>
            <tr>
                <td align="right" style="width: 10%">
                    <asp:Label ID="Label8" runat="server" Text="QQ："></asp:Label>
                </td>
                <td align="left" style="width: 20%">
                    <asp:TextBox ID="TextBox_PMSC_QQ" runat="server"
                    onkeyup="this.value=this.value.replace(/[^0-9]/g,'')"
                                    onafterpaste="this.value=this.value.replace(/[^0-9]/g,'')"> </asp:TextBox>
                </td>
        </tr>
        <tr>
        <td style="width: 20%"  >
                 
                 </td>
            <td align="center" colspan="2">
                <asp:Button ID="Button4" runat="server" CssClass="Button02" Height="24px" 
                    OnClick="ConfirmPMSupplyContact " Text="提交" Width="70px" />
            </td>
            <td align="center" colspan="2">
                <asp:Button ID="Button5" runat="server" CssClass="Button02" Height="24px" 
                    OnClick="CanelPMSupplyContact" Text="关闭" Width="70px" />
            </td>
            <td style="width: 20%"  >
                 
                 </td>
        </tr>
    </tr>

    </table>
                    
     </fieldset>
     </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
