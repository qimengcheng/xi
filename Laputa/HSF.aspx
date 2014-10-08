<%@ Page Title="" Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true" CodeFile="HSF.aspx.cs" Inherits="Laputa_HSF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <fieldset>
                    <legend>有毒物质检索
                    </legend>
                    <table style="width: 100%" >
                        <tr>
                            <td style="width: 67px" >材料名称：</td>
                            <td style="width: 158px" >
                                <asp:TextBox ID="TextBox1" runat="server" Width="90%"></asp:TextBox>
                            </td>
                            <td style="width: 59px" >供应商：</td>
                            <td style="width: 171px" >
                                <asp:TextBox ID="TextBox2" runat="server" Width="90%"></asp:TextBox>
                            </td>
                            <td style="width: 49px" >&nbsp;</td>
                            <td style="width: 167px" >
                                &nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 67px" >&nbsp;</td>
                            <td style="width: 158px">
                                <asp:Button ID="Search" runat="server" CssClass="Button02" Text="检索" Width="66px" OnClick="Search_Click" />
                            </td>
                            <td style="width: 59px" >&nbsp;</td>
                            <td style="width: 171px">
                                <asp:Button  class="Button02"  value="重置"  runat="server" Text="重置" OnClick="Unnamed1_Click" Width="60px"/>
                            </td>
                            <td style="width: 49px" >
                                <asp:Label ID="HSFID" runat="server" Text="HSFID" Visible="False"></asp:Label>
                            </td>
                            <td style="width: 167px">
                                <asp:Label ID="ReportID" runat="server" Text="ReportID" Visible="False"></asp:Label>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>

                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel2" runat="server">
                <fieldset>
                    <legend>有毒物质表 </legend>
                    <asp:GridView ID="GridView1" runat="server" CssClass="GridViewStyle"  AllowPaging="True" PageSize="10" AutoGenerateColumns="False" 
                                  GridLines="None" EmptyDataText="没有相关记录" OnRowCommand="GridView1_RowCommand"
                                  DataKeyNames="HSF_ID"  OnPageIndexChanging="GridView1_PageIndexChanging" EnableModelValidation="True" OnRowDataBound="GridView1_RowDataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="HSF_ID" HeaderText="HSFID" Visible="false" SortExpression="SMSMPM_ID" />
                            <asp:BoundField DataField="HSF_MaterialName" HeaderText="材料名称" Visible="true" SortExpression="PMP_ID" />
                            <asp:BoundField DataField="HSF_Provider" HeaderText="供应商" Visible="true" SortExpression="SMSMPM_Year" />
                            <asp:BoundField DataField="HSF_Texture" HeaderText="材质" Visible="true" SortExpression="SMSMPM_Year" />
                            <asp:BoundField DataField="HSF_Level" HeaderText="风险等级" Visible="true" SortExpression="SMSMPM_Month" />
                            <asp:BoundField DataField="HSF_Note" HeaderText="备注" Visible="true" SortExpression="SMSMPM_MakeMan" />
                     

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="History" runat="server" CommandArgument='<%# Eval("HSF_ID") %>' CommandName="History">查看所有版本</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Details" runat="server" CommandArgument='<%# Eval("HSF_ID") %>' CommandName="Details">查看最新版本的数据汇总</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第<asp:Label ID="lblPageIndex" runat="server" Text='<%# ((GridView) Container.Parent.Parent).PageIndex + 1 %>' />
                                        页 共<asp:Label ID="lblPageCount" runat="server" Text='<%# ((GridView) Container.Parent.Parent).PageCount %>' />
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
                    <table style="text-align: left; width: 100%;">
           
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
        <ContentTemplate> 
            <asp:Panel ID="Panel3" runat="server" Visible="False">
                
                <fieldset>
                    <legend>
                      
                        版本列表 </legend>
                    <asp:Button ID="AddVersion" runat="server" CssClass="Button02" OnClick="AddVersion_Click" Text="新增版本" Width="66px" /> 
                    <asp:Button ID="CloseVersion" runat="server" CssClass="Button02" OnClick="CloseVersion_Click" Text="关闭" Width="73px" />
                    <asp:GridView ID="GridView2" runat="server" CssClass="GridViewStyle"  AllowPaging="True" AutoGenerateColumns="False" 
                                  GridLines="None" EmptyDataText="没有相关记录" OnRowCommand="GridView2_RowCommand"  OnPageIndexChanging="GridView2_PageIndexChanging" EnableModelValidation="True">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField=HSFVersion_ID HeaderText=HSFVersionID Visible="false"  />
                            <asp:BoundField DataField="HSFVersion_Name" HeaderText="版本名" Visible="true"  />
                             <asp:BoundField DataField=HSFVersion_Num HeaderText=已上传报告数 Visible="true"  />
                            <asp:BoundField DataField="HSFVersion_Note" HeaderText="备注" Visible="true"  />
                            <asp:BoundField DataField="HSFVersion_Time" HeaderText="建立时间"  DataFormatString="{0:yyyy-MM-dd HH:mm}" Visible="true"  />
                            <asp:BoundField DataField="HSFVersion_Man" HeaderText="建立人" Visible="true"  />
                            
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="ED" runat="server" CommandArgument='<%# Eval("HSFVersion_ID") %>' CommandName="ED">编辑</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                               
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="De" runat="server" CommandArgument='<%# Eval("HSFVersion_ID") %>' CommandName="De" OnClientClick="return confirm('您确认删除该记录吗?')">删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="up" runat="server" CommandArgument='<%# Eval("HSFVersion_ID") %>' CommandName="up">上传报告</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                              <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Copy" runat="server" CommandArgument='<%# Eval("HSFVersion_ID") %>' CommandName="Copy">添加已有报告</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            

                            <asp:TemplateField>
                                

                                <ItemTemplate>
                                    <asp:LinkButton ID="report" runat="server" CommandArgument='<%# Eval("HSFVersion_ID") %>' CommandName="report">查看报告</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="detail" runat="server" CommandArgument='<%# Eval("HSFVersion_ID") %>' CommandName="detail">查看汇总数据</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第<asp:Label ID="lblPageIndex" runat="server" Text='<%# ((GridView) Container.Parent.Parent).PageIndex + 1 %>' />
                                        页 共<asp:Label ID="lblPageCount" runat="server" Text='<%# ((GridView) Container.Parent.Parent).PageCount %>' />
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
                    
                </fieldset>
            </asp:Panel>
          
        </ContentTemplate>
            <Triggers>
            <asp:PostBackTrigger ControlID="GridView2" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel4" runat="server" Visible="False">
                
                <fieldset>
                    <legend>
                        
                        有毒物质报告表 </legend><asp:Button ID="CloseReport" runat="server" CssClass="Button02" OnClick="CloseReport_Click" Text="关闭" Width="73px" />
                    <asp:GridView ID="GridView3" runat="server" CssClass="GridViewStyle" AutoGenerateColumns="False" 
                                  GridLines="None" EmptyDataText="没有相关记录" OnRowCommand="GridView3_RowCommand"  EnableModelValidation="True">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="HSFReport_ID" HeaderText="HSFReportID" Visible="false"  />
                            <asp:BoundField DataField="HSFReport_Num" HeaderText="测试报告号" Visible="true"  />
                            <asp:BoundField DataField="HSFReport_Organization" HeaderText="测试机构" Visible="true"  />
                            <asp:BoundField DataField="HSFReport_Date" HeaderText="测试日期" Visible="true" DataFormatString="{0:yyyy-MM-dd } " />
                            <asp:BoundField DataField="HSFReport_Man" HeaderText="录入人" Visible="true"  />
                            <asp:BoundField DataField="HSFReport_Time" HeaderText="录入日期" Visible="true"  />
                            <asp:BoundField DataField="HSFReport_Note" HeaderText="备注" Visible="true"  />

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="ED" runat="server" CommandArgument='<%# Eval("HSFReport_ID") %>' CommandName="ED">编辑</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    
                                    <asp:LinkButton ID="De" runat="server" CommandArgument='<%# Eval("HSFReport_ID") %>' CommandName="De" OnClientClick="return confirm('您确认删除该记录吗?')" >删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                                    
                                   <asp:TemplateField>
                                <ItemTemplate>

                                    <asp:LinkButton ID="Details" runat="server" CommandArgument='<%# Eval("HSFReport_ID ") %>' CommandName="Details">查看报告详细</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                             <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Modify" runat="server" CommandArgument='<%# Eval("HSFReport_ID") %>' CommandName="Modify">录入报告数据</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HyperLink ID="Down" runat="server" NavigateUrl='<%#"~/"+Eval("HSFReport_Url")%>' >下载报告</asp:HyperLink >
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="HSFReport_Type" HeaderText="类型" />
                        </Columns>
                    
                    </asp:GridView>
                    <table style="text-align: left; width: 100%;">
           
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel5" runat="server" Visible="False">
             <fieldset>
                    <legend>
                        
                        有毒物质报告详细表</legend>   <asp:Button ID="CloseDetail" runat="server" CssClass="Button02" OnClick="CloseDetail_Click" Text="关闭" Width="73px" />
                    <asp:GridView ID="GridView4" runat="server" CssClass="GridViewStyle"  AllowPaging="True" AutoGenerateColumns="False"
                                  GridLines="None" EmptyDataText=" 没有相关记录 " OnRowCommand="GridView1_RowCommand"  OnPageIndexChanging="GridView1_PageIndexChanging" EnableModelValidation="True">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="HSFReport_ID" HeaderText="HSFReport_ID" Visible="false"  />
                            <asp:BoundField DataField="HSFElement_Name" HeaderText="物质名称" Visible="true"  />
                            <asp:BoundField DataField="HSFElement_Standard" HeaderText="管控标准" Visible="true"  />
                            <asp:BoundField DataField="HSFDetail_Net" HeaderText="含量" Visible="true"  />
                           <asp:BoundField DataField="HSFDetail_Man" HeaderText="录入人" Visible="true"  />
                            <asp:BoundField DataField="HSFDetail_Time" HeaderText="录入时间" DataFormatString="{0:yyyy-MM-dd HH:mm}" Visible="true"  />
                            <asp:BoundField DataField="HSFDetail_Note" HeaderText="备注" Visible="true"  />


                           
                           
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第 <asp:Label ID="lblPageIndex" runat="server" Text='<%# ((GridView) Container.Parent.Parent).PageIndex + 1 %>' />
                                        页 共 <asp:Label ID="lblPageCount" runat="server" Text='<%# ((GridView) Container.Parent.Parent).PageCount %>' />
                                        页
                                        <asp:LinkButton ID="btnFirst" runat="server" CausesValidation="False" CommandArgument="First"
                                                        CommandName="Page" Text="首页 " />
                                        <asp:LinkButton ID="btnPrev" runat="server" CausesValidation="False" CommandArgument="Prev"
                                                        CommandName="Page" Text="上一页 " />
                                        <asp:LinkButton ID="btnNext" runat="server" CausesValidation="False" CommandArgument="Next"
                                                        CommandName="Page" Text="下一页 " />
                                        <asp:LinkButton ID="btnLast" runat="server" CausesValidation="False" CommandArgument="Last"
                                                        CommandName="Page" Text="尾页 " />
                                        <asp:TextBox ID="textbox" runat="server" Width="20px"></asp:TextBox>
                                        <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                                        CommandName="Page" Text="GO" /><!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
                                    </td>
                                </tr>
                            </table>
                        </PagerTemplate>
                    </asp:GridView>
                    <table style="text-align: left; width: 100%;">
          
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel6" runat="server" Visible="False">
              <fieldset>
                    <legend>
                        
                        有毒物质汇总数据</legend>  <asp:Button ID="CloseDetailCollection" runat="server" CssClass="Button02" OnClick="CloseDetailCollection_Click" Text="关闭" Width="73px" />
                    <asp:GridView ID="GridView5" runat="server" CssClass="GridViewStyle" AutoGenerateColumns="False"
                                  GridLines="None" EmptyDataText=" 没有相关记录 " OnRowCommand="GridView1_RowCommand"
                                  DataKeyNames=""  OnPageIndexChanging="GridView4_PageIndexChanging" EnableModelValidation="True">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                          <asp:BoundField DataField="HSFReport_ID" HeaderText="HSFReport_ID" Visible="false"  />
                            <asp:BoundField DataField="HSFElement_Name" HeaderText="物质名称" Visible="true"  />
                            <asp:BoundField DataField="HSFElement_Standard" HeaderText="管控标准" Visible="true"  />
                            <asp:BoundField DataField="HSFDetail_Net" HeaderText="含量" Visible="true"  />
                            <asp:BoundField DataField="HSFReport_Num" HeaderText="报告编号" Visible="true"  />
                            <asp:BoundField DataField="HSFReport_Organization" HeaderText="检测机构" Visible="true"  />
                           <asp:BoundField DataField="HSFDetail_Man" HeaderText="录入人" Visible="true"  />
                            <asp:BoundField DataField="HSFDetail_Time" HeaderText="录入时间" DataFormatString="{0:yyyy-MM-dd HH:mm}" Visible="true"  />
                            <asp:BoundField DataField="HSFDetail_Note" HeaderText="备注" Visible="true"  />

                       
                           
                           
                        </Columns>
                        
                    </asp:GridView>
                    <table style="text-align: left; width: 100%;">
          
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
 
    <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            
            <asp:Panel ID="Panel7" runat="server" Visible="False">
                <fieldset>
                    <legend>
            
                        <asp:Label ID="addedit" runat="server" Text="新增"></asp:Label>
                        版本
                    </legend>
                    <table style="width: 100%" >
                        <tr>
                            <td style="width: 69px" >版本名称：</td>
                            <td style="width: 112px" >
                                <asp:TextBox ID="TextBox4" runat="server" Width="100%"></asp:TextBox>
                            </td>
                            <td style="width: 215px">
                                &nbsp;</td>
                            <td style="width: 156px" >
                                &nbsp;</td>
                            <td style="width: 140px" >
                                &nbsp;</td>
                            <td >&nbsp;</td>
             
                        </tr>
                        <tr>
                            <td style="width: 69px">备注：</td>
                            <td colspan="4">
                                <asp:TextBox ID="TextBox10" runat="server" Height="100px" MaxLength="200" TextMode="MultiLine" Width="100%"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 69px">&nbsp;</td>
                            <td style="width: 112px">&nbsp;</td>
                            <td style="width: 215px">
                                <asp:Button ID="Add" runat="server" CssClass="Button02" OnClick="SummitVersion_Click" Text="提交" Width="73px" />
                                </td>
                            <td style="width: 156px">
                                <asp:Button ID="CloseAddVersion" runat="server" CssClass="Button02" OnClick="CloseAddVersion_Click" Text="关闭" Width="73px" />
                            </td>
                            <td style="width: 140px">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>

                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
 
    <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            

        
    
            <asp:Panel ID="Panel8" runat="server"  Visible="False" >
                <fieldset><legend>
                              <asp:Label ID="Label1" runat="server" Text="新增"></asp:Label>
                              报告<asp:Label ID="VersionID" runat="server" Text="VersionID" Visible="False"></asp:Label>
                          </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="height: 21px; width: 81px;">测试报告号:</td>
                            <td style="height: 21px; width: 75px;">
                                <asp:TextBox ID="TextBox21" runat="server"></asp:TextBox>
                            </td>
                            <td style="height: 21px; width: 54px;">
                                测试机构:</td>
                            <td style="height: 21px; width: 113px;">
                                <asp:TextBox ID="TextBox22" runat="server"></asp:TextBox>
                            </td>
                            <td style="height: 21px; width: 63px;">
                                测试日期:</td>
                            <td style="height: 21px; width: 183px;">
                                <asp:TextBox ID="TextBox23" runat="server" onfocus="new WdatePicker(this,'%Y-%M-%D' ,true)" DataFormatString="{0:yyyy-MM-dd}"></asp:TextBox>
                            </td>
                            <td style="height: 21px">&nbsp;</td>
                            <td style="height: 21px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="height: 21px; width: 81px;">上传报告:</td>
                            <td colspan="3" style="height: 21px; ">
                                <asp:FileUpload ID="FileUpload1" runat="server" />
                            </td>
                            <td style="height: 21px; width: 63px;">类别:</td>
                            <td style="height: 21px; width: 183px;">
                                <asp:TextBox ID="TextBox25" runat="server" ></asp:TextBox>
                            </td>
                            <td style="height: 21px">&nbsp;</td>
                            <td style="height: 21px">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="height: 21px; width: 81px;">备注:</td>
                            <td colspan="6" style="height: 21px;">
                                <asp:TextBox ID="TextBox24" runat="server" Width="542px" Height="70px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                            <td style="height: 21px">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 81px;">&nbsp;</td>
                            <td style="width: 75px;"></td>
                            <td style="width: 54px;">
                                &nbsp;</td>
                            <td style="width: 113px;">
                                <asp:Button ID="Summit_Report" runat="server" CssClass="Button02" OnClick="Summit_Report_Click" Text="提交" ValidationGroup="E" Width="66px" />
                            </td>
                            <td style="width: 63px;">
                                &nbsp;</td>
                            <td style="width: 183px;">
                                <asp:Button ID="CloseUpload" runat="server" CausesValidation="False" CssClass="Button02" OnClick="CloseUpload_Click" Text="关闭" Width="66px" />
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>    
       <Triggers>
            <asp:PostBackTrigger ControlID="Summit_Report" />
        </Triggers>
    </asp:UpdatePanel>
    
    <asp:UpdatePanel ID="UpdatePanel9" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel9" runat="server" Visible="False">
                <fieldset>
                    <legend>录入有毒物质报告数据</legend>
                    <asp:GridView ID="GridView9" runat="server" CssClass="GridViewStyle"  AutoGenerateColumns="False"
                                  GridLines="None" EmptyDataText=" 没有相关记录 " EnableModelValidation="True" OnRowDataBound="GridView9_RowDataBound" OnRowCommand="GridView9_RowCommand">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                               <asp:BoundField DataField="HSFDetail_ID" HeaderText="HSFDetail_ID" >
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                            </asp:BoundField>
                          <asp:BoundField DataField="HSFReport_ID" HeaderText="HSFReport_ID" >
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="HSFElement_Name" HeaderText="物质名称" Visible="true"  />
                            <asp:BoundField DataField="HSFElement_Standard" HeaderText="管控标准" Visible="true"  />
                            
                           <asp:BoundField DataField="HSFDetail_Man" HeaderText="录入人" Visible="true"  />
                            <asp:BoundField DataField="HSFDetail_Time" HeaderText="录入时间" DataFormatString="{0:yyyy-MM-dd HH:mm}" Visible="true"  />
                             <asp:TemplateField HeaderText="备注">
                               <ItemTemplate>
                                      <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("HSFDetail_Note") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="含量">
                               <ItemTemplate>
                                      <asp:TextBox ID="TextBox2"  onkeyup="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{2,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{2})[0-9]*/, '$1');" 
                              onafterpaste="this.value = this.value.replace(/[^\d.]/g, '');this.value = this.value.replace(/^\./g, '');
                             this.value = this.value.replace(/\.{2,}/g, '.');
                             this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
                             this.value = this.value.replace(/([0-9]+\.[0-9]{2})[0-9]*/, '$1');"
 runat="server" Text='<%# Bind("HSFDetail_Net") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                             <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="modi" runat="server" CommandArgument='<%# Eval("HSFReport_ID") %>' CommandName="modi"> 编辑</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                       
                           
                           
                        </Columns>
                    
                    </asp:GridView>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 81px;">&nbsp;</td>
                            <td style="width: 75px;"></td>
                            <td style="width: 54px;">
                                &nbsp;</td>
                            <td style="width: 113px;">
                                <asp:Button ID="SummitReportData" runat="server" CssClass="Button02" OnClick="SummitReportData_Click" Text="提交" ValidationGroup="E" Width="66px" />
                            </td>
                            <td style="width: 63px;">
                                &nbsp;</td>
                            <td style="width: 183px;">
                                <asp:Button ID="Button2" runat="server" CausesValidation="False" CssClass="Button02" OnClick="Button2_Click" Text="关闭" Width="66px" />
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel10" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            
            <asp:Panel ID="Panel10" runat="server" Visible="False">
                
                <fieldset>
                    <legend>
                        
                        有毒物质报告表 </legend>
                    <table style="width: 100%" >
                        <tr>
                            <td style="width: 67px" >材料名称：</td>
                            <td style="width: 158px" >
                                <asp:TextBox ID="TextBox60" runat="server" Width="90%"></asp:TextBox>
                            </td>
                            <td style="width: 59px" >供应商：</td>
                            <td style="width: 171px" >
                                <asp:TextBox ID="TextBox61" runat="server" Width="90%"></asp:TextBox>
                            </td>
                            <td style="width: 70px" >测试报告号:</td>
                            <td style="width: 167px" >
                                <asp:TextBox ID="TextBox62" runat="server" Width="90%"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 67px" >&nbsp;</td>
                            <td style="width: 158px">
                                <asp:Button ID="SearchCopy" runat="server" CssClass="Button02" Text="检索" Width="66px" OnClick="SearchCopy_Click" />
                            </td>
                            <td style="width: 59px" >&nbsp;</td>
                            <td style="width: 171px">
                                <asp:Button  class="Button02"  value="重置"  runat="server" Text="重置" OnClick="Unnamed1_Click" Width="60px"/>
                            </td>
                            <td style="width: 70px" >
                                <asp:Button ID="CloseCopy" runat="server" CssClass="Button02" OnClick="CloseCopy_Click" Text="关闭" Width="73px" />
                            </td>
                            <td style="width: 167px">
                                &nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    
                    
                    <asp:GridView ID="GridView6" runat="server" CssClass="GridViewStyle" AutoGenerateColumns="False" 
                                  GridLines="None" EmptyDataText="没有相关记录" OnRowCommand="GridView6_RowCommand"  EnableModelValidation="True">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="HSFReport_ID" HeaderText="HSFReportID" Visible="false"  />
                            <asp:BoundField DataField="HSFReport_Num" HeaderText="测试报告号" Visible="true"  />
                            <asp:BoundField DataField="HSFReport_Organization" HeaderText="测试机构" Visible="true"  />
                            <asp:BoundField DataField="HSFReport_Date" HeaderText="测试日期" Visible="true" DataFormatString="{0:yyyy-MM-dd } " />
                            <asp:BoundField DataField="HSFReport_Man" HeaderText="录入人" Visible="true"  />
                            <asp:BoundField DataField="HSFReport_Time" HeaderText="录入日期" Visible="true"  />
                            <asp:BoundField DataField="HSFReport_Note" HeaderText="备注" Visible="true"  />

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Choose" runat="server" CommandArgument='<%# Eval("HSFReport_ID") %>' CommandName="Choose">选择</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                          
                   

                           

                        </Columns>
                    
                    </asp:GridView>
                    <table style="text-align: left; width: 100%;">
           
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>