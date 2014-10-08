<%@ Page Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true" CodeFile="Proclass.aspx.cs" Inherits="ProductionProcess_MaterialApply" Title="产品分档信息管理" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
       

        <asp:Panel ID="Panel_Search" runat="server" Visible="true">
            <fieldset><legend>检索</legend><table style="width: 100%">
        <tr>
            <td style=" width:18%; height: 25px;">
                产品型号</td>
            <td style="width: 384px">
                <asp:TextBox ID="TextBox1" runat="server" Width="214px" AutoCompleteType="Search"></asp:TextBox>
                <asp:Button ID="Btn_Search" runat="server"  class="Button02" onclick="Btn_Search_Click" Text="搜索" Width="60px" BorderStyle="None" />
                &nbsp;&nbsp;</td>
            <td style=" width:8%; height: 25px;">
                <asp:Label ID="Label1" runat="server" Text="最近搜索："></asp:Label>
            </td> 
            <td style=" width:24%; height: 25px;">
                <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">LinkButton</asp:LinkButton>
                <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">LinkButton</asp:LinkButton>
                <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click">LinkButton</asp:LinkButton>
                <asp:LinkButton ID="LinkButton5" runat="server" OnClick="LinkButton5_Click">LinkButton</asp:LinkButton>
            </td>    
            <td>
                <asp:Button ID="Button3" runat="server" cssclass="Button02" OnClick ="Button3_Click" Text="X" />
            </td>                   
        </tr>
            
        
            
            
           
                <asp:Label ID="Lab_State_Search" runat="server" Visible="true"></asp:Label>
               
           
       
    </table></fieldset>

        </asp:Panel>
    
  
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <table>
    </table>
      <div style="height:5px"></div>
    <fieldset><legend>产品分档管理</legend>
        <asp:GridView ID="GridView_Proclass" runat="server" 
            AutoGenerateColumns="False" CssClass="GridViewStyle" Width="100%" 
            DataKeyNames="PCI_ID"  EnableModelValidation="True" OnRowEditing="GridView_Proclass_RowEditing" OnSelectedIndexChanged="GridView_Proclass_SelectedIndexChanged" OnRowDeleting="GridView_Proclass_RowDeleting" OnRowUpdating="GridView_Proclass_RowUpdating" OnSelectedIndexChanging="GridView_Proclass_SelectedIndexChanging" OnRowCancelingEdit="GridView_Proclass_RowCancelingEdit" OnRowCommand="GridView_Proclass_RowCommand" OnRowCreated="GridView_Proclass_RowCreated" AllowSorting="True" EnableSortingAndPagingCallbacks="True" OnSorting="GridView_Proclass_Sorting" OnRowDataBound="GridView_Proclass_RowDataBound" GridLines="None">
             <FooterStyle CssClass="GridViewFooterStyle" />
    <RowStyle CssClass="GridViewRowStyle" />   
    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
    <HeaderStyle CssClass="GridviewHead"  BorderStyle="Double" BorderWidth="1px"  Height="26px" HorizontalAlign="Center"/>
            <SelectedRowStyle  CssClass="GridViewSelectedRowStyle"  />
            <%--<PagerStyle CssClass="GridViewPagerStyle" />--%>
            <Columns >
                <asp:BoundField DataField="PCI_ID" HeaderText="产品分档信息ID" Visible="false"
                    SortExpression="PCI_ID" />
                <asp:TemplateField HeaderText="产品型号" SortExpression="产品型号">
                    <ItemTemplate>
                        <asp:LinkButton ID="PT_Name"  SortExpression="型号"  CommandName="Search" runat="server" CommandArgument='<%# Eval("PT_Name") %>' Text='<%# Bind("PT_Name") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                   
                 <asp:TemplateField>
                     <ItemStyle CssClass="test" />                      
                 <ItemTemplate>

                                    <asp:LinkButton ID="NewPC" runat="server" CommandArgument='<%# Eval("PT_Name") %>'
                                        CommandName="New"  >新增</asp:LinkButton>
                                </ItemTemplate>
                                </asp:TemplateField>       
                <asp:BoundField DataField="PCI_Class" HeaderText="档次" 
                    SortExpression="档次" ></asp:BoundField>
                <asp:BoundField DataField="PCI_Type" HeaderText="类型" 
                    SortExpression="类型" ></asp:BoundField >
                <asp:BoundField DataField="PCI_Need" HeaderText="要求" 
                    SortExpression="要求" ></asp:BoundField >
                
                
                <asp:CommandField EditText="编辑" UpdateText="更新" CancelText="取消" NewText="" ShowEditButton="True" />
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" OnClientClick="return confirm('您确认删除该记录吗?')" CommandArgument='<%# Eval("PCI_ID") %>' Text="删除"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>

                
                <asp:CommandField ShowSelectButton="True"/>

                
            </Columns>
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
                             <%--<asp:textbox id="txtNewPageIndex" runat="server" width="20px" text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />--%>
                             <asp:linkbutton id="btnGo" runat="server" causesvalidation="False" commandargument="-1" commandname="Page" text="GO" /><!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
                             </td>
                          </tr>
                        </table>

                    </PagerTemplate>
        <EmptyDataTemplate><span>没有找到符合条件的记录！</span></EmptyDataTemplate></asp:GridView>
    </fieldset>
    </ContentTemplate>
    
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        
       
        
        <asp:Panel ID="Panel1" runat="server" Visible="false">
        产品型号：<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="TextBox5"></asp:RequiredFieldValidator>
        档次：<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="TextBox2"></asp:RequiredFieldValidator>
        类型：<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="TextBox3"></asp:RequiredFieldValidator>
        要求：<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="TextBox4"></asp:RequiredFieldValidator>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="Button1" runat="server" Text="增加分档信息" cssclass="Button02" OnClick="Button1_Click" Width="80px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" Text="取消" cssclass="Button02" OnClick="Button2_Click" />
        </asp:Panel>
        
    </ContentTemplate>
    </asp:UpdatePanel>

 
                      
              
          
    
          
   
              
          
</asp:Content>

