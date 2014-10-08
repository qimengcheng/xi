<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PRMProject_IsFinish.aspx.cs" Inherits="PurchasingMgt_PRMProject_IsFinish"  MasterPageFile="~/Other/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script> 
    <style type="text/css">
        .hidden
        {
            display: none;
        }
        .auto-style7 {
            width: 268435456px;
        }
        .auto-style11 {
            width: 15%;
        }
        </style>
    <script language="Javascript">
        function preview() {
            bdhtml = window.document.body.innerHTML;
            sprnstr = "<!--startprint-->";
            eprnstr = "<!--endprint-->";
            prnhtml = bdhtml.substr(bdhtml.indexOf(sprnstr) + 17);
            prnhtml = prnhtml.substring(0, prnhtml.indexOf(eprnstr));
            window.document.body.innerHTML = prnhtml;
            window.print();
        }
</script>
  
            <asp:Panel ID="Panel_OASearch" runat="server" Visible="true">
                <fieldset>
                    <legend> 项目完成情况汇总查询
                    </legend>
                     <asp:Label ID="label_Num" runat="server" Visible="false"/>
    <table style="width: 100%;">
         
            <tr>
           <td style="width: 15%;"align="right">
                <asp:Label ID="Label2" runat="server" Text="项目编号："></asp:Label>
               </td>
                <td style="width: 15%;">
                <asp:TextBox ID="TextBox1" runat="server"  ></asp:TextBox>
               </td>
                 <td align="right" class="auto-style11">
                <asp:Label ID="Label1" runat="server" Text="项目名称："></asp:Label>
        
        </td>
         <td style="width: 15%;">
           
                <asp:TextBox ID="TextBox_SPTime2" runat="server"  ></asp:TextBox>     
            </td>
                </td>
                 <td align="right" style="width: 15%;">
                <asp:Label ID="Label3" runat="server" Text="项目类型："></asp:Label>
        
        </td>
         <td style="width: 15%;">
           
                <asp:TextBox ID="TextBox2" runat="server" ></asp:TextBox>     
            </td>
        </tr>
     
         <tr>
          
                 <td align="right" class="auto-style13">
                <asp:Label ID="Label4" runat="server" Text="日期："></asp:Label>
        
        </td>
         <td colspan="3">
           
                <asp:TextBox ID="TextBox3" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D ',true)"  ></asp:TextBox>
       
                &nbsp;
       
                <asp:Label ID="Label" runat="server" Text="至"></asp:Label>
            
                &nbsp;
            
                <asp:TextBox ID="TextBox_SPTime3" runat="server" 
                    onfocus="new WdatePicker(this,'%Y-%M-%D ',true)"  ></asp:TextBox>
            </td>
                 <td align="right" class="auto-style11">
                <asp:Label ID="Label5" runat="server" Text="是否按期完成："></asp:Label>
        
        </td>
         <td style="width: 15%;">
           
                <asp:DropDownList ID="DropDownList4" runat="server" Height="16px" Width="125px" >
                    <asp:ListItem>是</asp:ListItem>
                    <asp:ListItem>否</asp:ListItem>
                    </asp:DropDownList>
            </td>
                </td>
                 <td align="right" style="width: 15%;">
                     &nbsp;</td>
         <td style="width: 15%;">
           
                &nbsp;</td>
        </tr>

        <tr>
            <td colspan="2" align="right">
                <asp:Button ID="Button1" runat="server" Text="检索" CssClass="Button02" Height="24px" OnClick="Button1_Sh"
                    Width="70px" />
               
            </td>
            <td align="center" colspan="2">
                <asp:Button ID="Button2" runat="server"  CssClass ="Button02"
        Text="打印报表" Width="58px" OnClick="Button2_Click1"  ToolTip="点击此处,跳转打印页面。" />
                   </td>
           

            <td colspan="2" align="left">
               
                <asp:Button ID="Button3" runat="server" Text="重置" CssClass="Button02" Height="24px" OnClick="Button3_Reset" Visible="true"
                    Width="70px" />
            </td>
           
        </tr>

    </table>
     </fieldset>
            </asp:Panel>


         <!--startprint-->
        <asp:Panel ID="Panel_OAInfo" runat="server" Visible="false">
            <fieldset>
                <legend> </legend>
                

               <table style="width: 100%;">
       
        <tr>
       
        <td colspan="6" align="left">
                <asp:Label ID="label_Title" runat="server" Visible="true" ForeColor="Red"/>
            </td>
           
            </tr>
           
    </table>

                 
                  <asp:GridView ID="Gridview_OAInfo"  runat="server" AutoGenerateColumns="False"
                    CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False" 
                     
                    AllowPaging="false" AllowSorting="True" DataKeyNames="PRMP_ID" 
                    Width="100%"  Font-Strikeout="False" GridLines="None"
                    EnableModelValidation="True" ShowFooter="false"
                   >
             <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
         
                    <Columns>
                        <asp:BoundField DataField="PRMP_ProjectNum" HeaderText="项目编号" SortExpression="PRMP_ProjectNum">
                         
                        </asp:BoundField>
                        <asp:BoundField DataField="PRMP_ProjectName" HeaderText="项目名称" SortExpression="PRMP_ProjectName">
                        </asp:BoundField>
                         <asp:BoundField DataField="PRMP_ProductMode" HeaderText="产品型号" SortExpression="PRMP_ProductMode">
                        </asp:BoundField>
                        <asp:BoundField DataField="PRMP_ProjectType" HeaderText="项目类型" SortExpression="PRMP_ProjectType"/>
                        <asp:BoundField DataField="PRMP_ProjectStates" HeaderText="项目状态" SortExpression="PRMP_ProjectStates"/>
                    </Columns>
               <EmptyDataTemplate>
              <asp:Label ID="Label50" runat="server" Text="无相关记录！"></asp:Label>
             </EmptyDataTemplate>
                    <FooterStyle CssClass="GridViewFooterStyle" />
                    <HeaderStyle CssClass="GridViewHead"
                        HorizontalAlign="Center" />
           
           
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
                
                <table style="width: 100%;">
       
       <%-- <tr>
       <td colspan="6" align="right" class="auto-style8">
                <asp:Label ID="Label47" runat="server" Text="合计数量："></asp:Label>
            </td>
        <td  align="left" style="width: 10%;">
                <asp:Label ID="label_Num" runat="server" Visible="TRUE" />
            </td>
           
            </tr>--%>
           <tr>
               
   <td align="center" colspan="2">
    <asp:Button ID="Button4" runat="server" CssClass="Button02" OnClick="Button2_Click"
        Text="关闭" Width="55px" />
       </td>

           </tr>
    </table>
</fieldset>
                </asp:Panel>
    <!--endprint-->
     </asp:Content>

