<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PMPurchaseApplyMaterial_Department.aspx.cs" Inherits="PurchasingMgt_PMPurchaseApplyMaterial_Department"   MasterPageFile="~/Other/MasterPage.master" %>

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
        .auto-style10 {
            width: 25%;
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
     <asp:UpdatePanel ID="UpdatePanel_OASearch" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_OASearch" runat="server" Visible="true">
                <fieldset>
                    <legend> 采购申请物料数量汇总查询
                    </legend>
                                    <asp:Label ID="label_CB" runat="server" Visible="false" />
                     <asp:Label ID="label_Num" runat="server" Visible="false"/>
                     <asp:Label ID="label_Type" runat="server" Visible="false"/>
                    <asp:Label ID="label_Typee" runat="server" Visible="false"/>
    <table style="width: 100%;">
         
            <tr>

           <td style="width: 15%" align="right">
               <asp:Label ID="Label5" runat="server" Text="物料名称："></asp:Label>
            </td>
            
            
            <td style="width: 15%" align="left">
                <asp:TextBox ID="TextBox1" runat="server"  ></asp:TextBox>
            </td>
                 <td align="right" class="auto-style10">
                <asp:Label ID="Label1" runat="server" Text="日期："></asp:Label>
        
        </td>
         <td colspan="1">
           
                <asp:TextBox ID="TextBox_SPTime2" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D ',true)"  ></asp:TextBox>
       
                &nbsp;
       
                <asp:Label ID="Label" runat="server" Text="至"></asp:Label>
            
                &nbsp;
            
                <asp:TextBox ID="TextBox_SPTime3" runat="server" 
                    onfocus="new WdatePicker(this,'%Y-%M-%D ',true)"  ></asp:TextBox>
            </td>
               
                </tr>
        <tr>
          
                
           <td style="width: 15%" align="right">
               
               <asp:Label ID="Label2" runat="server" Text="规格型号："></asp:Label>
               
               </td>
                <td align="left" style="width: 15%">
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </td>
            
            <tr>
                <td colspan="5" style="height: 20px;">
                    <fieldset>
                        <legend>物料类型选择</legend>
                        <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatColumns="4" Width="100%">
                        </asp:CheckBoxList>
                    </fieldset> </td>
            </tr>
            <tr>
                <td align="right" colspan="2">
                    <asp:Button ID="Button1" runat="server" CssClass="Button02" Height="24px" OnClick="Button1_Sh" Text="检索" Width="70px" />
                </td>
              
             <td align="center" colspan="1">
                <asp:Button ID="Button5" runat="server"  CssClass ="Button02"
                  Text="打印报表" Width="58px" OnClick="Button2_Click1"  ToolTip="点击此处,跳转打印页面。"/>
                   </td>
               
                <td align="left" colspan="2">
                    <asp:Button ID="Button3" runat="server" CssClass="Button02" Height="24px" OnClick="Button3_Reset" Text="重置" Visible="true" Width="70px" />
                </td>
            </tr>
                </tr>
    </table>
     </fieldset>
            </asp:Panel>
</ContentTemplate>
    </asp:UpdatePanel>
         <!--startprint-->
    <asp:UpdatePanel ID="UpdatePanel_OAInfo" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <asp:Panel ID="Panel_OAInfo" runat="server" Visible="false">
            <fieldset>
                <legend> </legend>
                

               <table style="width: 100%;">
       
        <tr>
       
        <td colspan="6" align="center">
                <asp:Label ID="label_Title" runat="server" Visible="false" />
            </td>
           
            </tr>
           
    </table>

                 <%--onrowdatabound="Gridview_OAInfo_RowDataBound"--%>
                  <asp:GridView ID="Gridview_OAInfo"  runat="server" AutoGenerateColumns="False"
                    CssClass="GridViewStyle" CellPadding="0" UseAccessibleHeader="False" 
                     
                    AllowPaging="false" AllowSorting="True" DataKeyNames="IMMBD_MaterialName" 
                    Width="100%"  Font-Strikeout="False" GridLines="None"
                    EnableModelValidation="True" ShowFooter="false"
                   >
             <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
           
           
           
           
                    <Columns>
                       
                        <asp:BoundField DataField="IMMBD_MaterialName" HeaderText="物品名称" 
                            SortExpression="IMMBD_MaterialName" />
                        <asp:BoundField DataField="IMMBD_SpecificationModel" HeaderText="规格" SortExpression="IMMBD_SpecificationModel">
                         
                        </asp:BoundField>
                        <asp:BoundField DataField="UnitName" HeaderText="单位" SortExpression="UnitName">
                        </asp:BoundField>
                         <asp:BoundField DataField="OA_SupplyNum" HeaderText="申请数量" SortExpression="OA_SupplyNum">
                        </asp:BoundField>
                        <asp:BoundField DataField="OA_ActuallNum" HeaderText="总到货数量" SortExpression="OA_ActuallNum"/>
                        <asp:BoundField DataField="OA_NotArrNum" HeaderText="未到货数量" SortExpression="OA_NotArrNum"/>
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
       
     
           <tr>
              
   <td align="center" colspan="2">
    <asp:Button ID="Button4" runat="server" CssClass="Button02" OnClick="Button2_Click"
        Text="关闭" Width="55px" />
       </td>

           </tr>
    </table>
</fieldset>
                </asp:Panel>
</ContentTemplate>
  </asp:UpdatePanel>
        
     </asp:Content>
