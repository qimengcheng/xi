<%@ Page Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true" CodeFile="ControlldeDoc.aspx.cs" Inherits="ControlledDocMgt_ControlldeDoc"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
<%--受控文件申请检索--%>
 <asp:UpdatePanel ID="UpdatePanel_SearchApp" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:Label ID="Lab_Status" runat="server"  Visible="False"></asp:Label>
    <fieldset>
    <legend>受控文件申请检索</legend>
       <table style="width: 100%;">
            <tr style="height: 16px;">
                <td style="width: 15%" align="right">
                    <asp:Label ID="Label2" runat="server" Text="受控文件编号：" ></asp:Label>
                </td>
                <td style="width: 18%" align="left">
                    <asp:TextBox ID="TextDocNO" runat="server" Width="150px" Height="20px"  MaxLength="20"></asp:TextBox>
                </td>
                <td style="width: 14%" align="right">
                    <asp:Label ID="Label3" runat="server" Text="文件名称：" ></asp:Label>
                </td>
                <td style="width: 18%" align="left">
                    <asp:TextBox ID="TextDocName" runat="server" Width="150px" Height="20px"  MaxLength="20"></asp:TextBox>
                </td>
                <td style="width: 12%" align="right">
                    <asp:Label ID="Label4" runat="server" Text="版本号：" ></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="TextEditionNO" runat="server" Width="150px" Height="20px"  MaxLength="20"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label5" runat="server" Text="申请单号：" ></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="TextAppNO" runat="server" Width="150px" Height="20px"  MaxLength="20"></asp:TextBox>
                </td>
                <td align="right">
                    <asp:Label ID="Lbltype" runat="server" Text="受控文件类型：" ></asp:Label>
                </td>
                <td align="left">
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="20px" Width="150px" >
                        <asp:ListItem Text="请选择" Value=""></asp:ListItem>
                        <asp:ListItem Text="第三层次文件" Value="第三层次文件"></asp:ListItem>
                        <asp:ListItem Text="质量文件" Value="质量文件"></asp:ListItem>
                        <asp:ListItem Text="程序文件" Value="程序文件"></asp:ListItem>
                        <asp:ListItem Text="图纸文件" Value="图纸文件"></asp:ListItem>
                        <asp:ListItem Text="外来文件" Value="外来文件"></asp:ListItem>
                        <asp:ListItem Text="其他文件" Value="其他文件"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="right">
                    <asp:Label ID="Label6" runat="server" Text="更改类型：" ></asp:Label>
                </td>
                <td align="left">
                    <%--<asp:DropDownList ID="DropDownList2" runat="server" Height="20px" Width="150px"></asp:DropDownList>--%>
                    <asp:DropDownList ID="DropDownList2" runat="server" Height="20px" Width="150px" >
                        <asp:ListItem Text="请选择" Value=""></asp:ListItem>
                        <asp:ListItem Text="新增文件" Value="新增文件"></asp:ListItem>
                        <asp:ListItem Text="修改文件" Value="修改文件"></asp:ListItem>
                        <asp:ListItem Text="临时文件" Value="临时文件"></asp:ListItem>
                        <asp:ListItem Text="增发文件" Value="增发文件"></asp:ListItem>
                        <asp:ListItem Text="补发文件" Value="补发文件"></asp:ListItem>
                        <asp:ListItem Text="其他文件" Value="其他文件"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label1" runat="server" Text="申请人：" ></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="TextAppPer" runat="server" Width="150px" Height="20px"  MaxLength="20"></asp:TextBox>
                </td>
                <td align="right">
                    <asp:Label ID="Label8" runat="server" Text="申请时间：" ></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="TextAppTime" runat="server" Width="150px" Height="20px" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"
                                Text='<%# Eval("CDA_AppTime","{0:yyyy-MM-dd}") %>' DataFormatString="{0:yyyy-MM-dd}"></asp:TextBox>
                </td>
                <td align="right">
                    <asp:Label ID="Label7" runat="server" Text="申请部门：" ></asp:Label>
                </td>
                <td align="left">
                    <asp:DropDownList ID="DropDownList3" runat="server" Height="20px" Width="150px"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label9" runat="server" Text="申请单状态：" ></asp:Label>
                </td>
                <td align="left">
                    <asp:DropDownList ID="DropDownList4" runat="server" Height="20px" Width="150px">
                        <asp:ListItem Text="请选择" Value=""></asp:ListItem>
                        <asp:ListItem Text="待提交" Value="待提交"></asp:ListItem>
                        <asp:ListItem Text="已提交" Value="已提交"></asp:ListItem>
                        <asp:ListItem Text="审核通过" Value="审核通过"></asp:ListItem>
                        <asp:ListItem Text="审核驳回" Value="审核驳回"></asp:ListItem>
                        <asp:ListItem Text="会签中" Value="会签中"></asp:ListItem>
                        <asp:ListItem Text="会签通过" Value="会签通过"></asp:ListItem>
                        <asp:ListItem Text="会签驳回" Value="会签驳回"></asp:ListItem>
                        <asp:ListItem Text="审批通过" Value="审批通过"></asp:ListItem>
                        <asp:ListItem Text="审批驳回" Value="审批驳回"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="right">
                    <asp:Label ID="Label41" runat="server" Text="生效时间：" ></asp:Label>
                </td>
                <td align="left" colspan="3">
                    <asp:TextBox ID="startime" runat="server" Width="150px" Height="20px" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"
                    DataFormatString="{0:yyyy-MM-dd}"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;到&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="endtime" runat="server" Width="150px" Height="20px" onfocus="new WdatePicker(this,'%Y-%M-%D',true)"
                    DataFormatString="{0:yyyy-MM-dd}"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="right">
                    <asp:Button ID="Btn_SearchApp" runat="server" Text="检索" Width="70px"  
                        CssClass="Button02" onclick="Btn_SearchApp_Click" Height="24px" />
                </td>
                <td colspan="2" align="center">
                    <asp:Button ID="Btn_NewApp" runat="server" Text="新增受控文件申请" Width="110px" 
                        CssClass="Button02" onclick="Btn_NewApp_Click" Height="24px" ToolTip="此处只能增加新文件，文件换版请在下表中选择。"/>
                    <asp:Button ID="Btn_Specil" runat="server" CssClass="Button02" Height="24px" 
                        OnClick="Btn_Specil_Click" Text="特殊录入通道" Width="110px" />
                </td>
                <td colspan="2" align="left">
                    <asp:Button ID="Btn_ClearApp" runat="server" CssClass="Button02" Text="重置" 
                        Width="70px"  OnClick="Btn_ClearApp_Click" Height="24px" />
                </td> 
            </tr>
        </table>
     </fieldset>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="Btn_NewApp" />
        <asp:PostBackTrigger  ControlID="Btn_Specil" />
    </Triggers>
</asp:UpdatePanel>

<%--受控文件申请列表--%>
<asp:UpdatePanel ID="UpdatePanel_App" runat="server" UpdateMode="Conditional">
     <ContentTemplate>
        <asp:Panel ID="Panel_App" runat="server">
            <fieldset>
                <asp:Label ID="Label_appid" runat="server"  Visible="False"></asp:Label>
                <asp:Label ID="Label39" runat="server" Visible="False" Text="文件下载仅供参阅，最终以人事部盖章发放的受控文件为准！" ForeColor="Red"></asp:Label>
                <legend>受控文件申请列表</legend>
                <asp:GridView ID="Grid_App" runat="server" DataKeyNames="CDA_ID" AllowSorting="True"
                AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                AllowPaging="True" PageSize="10" Font-Strikeout="False" UseAccessibleHeader="False"
                OnPageIndexChanging="Grid_App_PageIndexChanging" OnRowCommand="Grid_App_RowCommand"
                OnRowDataBound="Grid_App_RowDataBound" GridLines="None" OnRowCancelingEdit="Grid_App_RowCancelingEdit"
                OnRowEditing="Grid_App_RowEditing" OnRowUpdating="Grid_App_RowUpdating">
                <RowStyle CssClass="GridViewRowStyle" />  
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle  cssclass="GridViewHead"/>
                <FooterStyle CssClass="GridViewFooterStyle" />
                <Columns>
                    <asp:BoundField DataField="CDA_ID" HeaderText="受控文件ID" ReadOnly="True" SortExpression="CDA_ID" Visible="False">
                        <ItemStyle />
                    </asp:BoundField>
                    <asp:BoundField DataField="CDTLC_ID" HeaderText="第三层次受控文件代码ID" SortExpression="CDTLC_ID" Visible="false" ReadOnly="True">
                        <ItemStyle/>
                    </asp:BoundField>
                    <asp:BoundField DataField="CDA_DocNO" HeaderText="受控文件编号" SortExpression="CDA_DocNO">
                        <ItemStyle/>
                    </asp:BoundField>
                    <asp:BoundField DataField="CDA_AppNO" HeaderText="申请单号" SortExpression="CDA_AppNO">
                        <ItemStyle/>
                    </asp:BoundField>
                    <asp:BoundField DataField="CDA_DocName" HeaderText="文件名称" SortExpression="CDA_DocName" ReadOnly="True">
                        <ItemStyle/>
                    </asp:BoundField>
                    <asp:BoundField DataField="CDA_EditionNO" HeaderText="版本号" SortExpression="CDA_EditionNO" ReadOnly="True">
                        <ItemStyle/>
                    </asp:BoundField>
                    <asp:BoundField DataField="CDA_DocType" HeaderText="受控文件类型" SortExpression="CDA_DocType" ReadOnly="True">
                        <ItemStyle/>
                    </asp:BoundField>
                    <asp:BoundField DataField="CDA_ChangedType" HeaderText="更改类型" SortExpression="CDA_ChangedType"  ReadOnly="True">
                        <ItemStyle/>
                    </asp:BoundField>
                    <asp:BoundField DataField="CDA_AppPer" HeaderText="申请人" SortExpression="CDA_AppPer" ReadOnly="True">
                        <ItemStyle/>
                    </asp:BoundField>
                    <asp:TemplateField SortExpression="CDA_AppTime" HeaderText="申请时间" >
                        <ItemTemplate>
                            <asp:Label ID="CDA_AppTime" runat="server" Text='<%# Eval("CDA_AppTime","{0:yyyy-MM-dd HH:mm:ss}") %>'
                                DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle/>
                    </asp:TemplateField>
                    <asp:BoundField DataField="CDA_AppDep" HeaderText="申请部门" SortExpression="CDA_AppDep" ReadOnly="True">
                        <ItemStyle/>
                    </asp:BoundField>  
                    <asp:BoundField DataField="CDA_AppReason" HeaderText="申请原因" SortExpression="CDA_AppReason" Visible="false" ReadOnly="True">
                        <ItemStyle/>
                    </asp:BoundField>
                    <asp:BoundField DataField="CDA_AppState" HeaderText="申请单状态" SortExpression="CDA_AppState" ReadOnly="True">
                        <ItemStyle/>
                    </asp:BoundField>
                    <asp:BoundField DataField="CDA_Remarks" HeaderText="备注" SortExpression="CDA_Remarks" Visible="false" ReadOnly="True">
                        <ItemStyle/>
                    </asp:BoundField>
                    <asp:BoundField DataField="CDA_DocRoute" HeaderText="文件路径" SortExpression="CDA_DocRoute" Visible="false" ReadOnly="True">
                        <ItemStyle/>
                    </asp:BoundField>
                    <asp:TemplateField SortExpression="CDA_EffectDate" HeaderText="生效时间" >
                        <ItemTemplate>
                            <asp:Label ID="CDA_EffectDate" runat="server" Text='<%# Eval("CDA_EffectDate","{0:yyyy-MM-dd HH:mm:ss}") %>'
                                DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle/>
                    </asp:TemplateField>
                    <asp:BoundField DataField="CDA_Auditor" HeaderText="审核人" SortExpression="CDA_Auditor" ReadOnly="True">
                        <ItemStyle/>
                    </asp:BoundField>
                    <asp:TemplateField SortExpression="CDA_AuTime" HeaderText="审核时间" >
                        <ItemTemplate>
                            <asp:Label ID="CDA_AuTime" runat="server" Text='<%# Eval("CDA_AuTime","{0:yyyy-MM-dd HH:mm:ss}") %>'
                                DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle/>
                    </asp:TemplateField>
                    <asp:BoundField DataField="CDA_AuSugg" HeaderText="审核意见" SortExpression="CDA_AuSugg" Visible="false" ReadOnly="True">
                        <ItemStyle/>
                    </asp:BoundField>
                    <asp:BoundField DataField="ETA_AuRes" HeaderText="审核结果" SortExpression="ETA_AuRes" ReadOnly="True">
                        <ItemStyle/>
                    </asp:BoundField>
                    <asp:BoundField DataField="CDA_Approver" HeaderText="审批人" SortExpression="CDA_Approver" ReadOnly="True">
                        <ItemStyle/>
                    </asp:BoundField>
                    <asp:TemplateField SortExpression="CDA_ApprovalT" HeaderText="审批时间" >
                        <ItemTemplate>
                            <asp:Label ID="CDA_ApprovalT" runat="server" Text='<%# Eval("CDA_ApprovalT","{0:yyyy-MM-dd HH:mm:ss}") %>'
                                DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle/>
                    </asp:TemplateField>
                    <asp:BoundField DataField="CDA_ApprovalSugg" HeaderText="审批意见" SortExpression="CDA_ApprovalSugg" Visible="false" ReadOnly="True">
                        <ItemStyle/>
                    </asp:BoundField>
                    <asp:BoundField DataField="CDA_ApprovalRes" HeaderText="审批结果" SortExpression="CDA_ApprovalRes" ReadOnly="True">
                        <ItemStyle/>
                    </asp:BoundField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="Look_App" runat="server" CommandArgument='<%#Eval("CDA_ID")+","+Eval("CDA_DocNO")+","+Eval("CDA_AppNO")
                            +","+Eval("CDA_DocName")+","+Eval("CDA_EditionNO")+","+Eval("CDA_DocType")+","+Eval("CDA_ChangedType")+","+Eval("CDA_AppPer")
                            +","+Eval("CDA_AppTime")+","+Eval("CDA_AppDep")+","+Eval("CDA_AppReason")+","+Eval("CDA_AppState")+","+Eval("CDA_Remarks")
                            +","+Eval("CDA_DocRoute")+","+Eval("CDA_Auditor")+","+Eval("CDA_AuTime")+","+Eval("CDA_AuSugg")+","+Eval("ETA_AuRes")
                            +","+Eval("CDA_Approver")+","+Eval("CDA_ApprovalT")+","+Eval("CDA_ApprovalSugg")+","+Eval("CDA_ApprovalRes")+","+Eval("CDA_EffectDate")%>' 
                            CommandName="Look_App" OnClientClick="false">查看详情</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle/>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="Edit_App" runat="server" CommandArgument='<%#Eval("CDA_ID")+","+Eval("CDA_DocNO")+","+Eval("CDA_AppNO")
                            +","+Eval("CDA_DocName")+","+Eval("CDA_EditionNO")+","+Eval("CDA_DocType")+","+Eval("CDA_ChangedType")+","+Eval("CDA_AppPer")
                            +","+Eval("CDA_AppTime")+","+Eval("CDA_AppDep")+","+Eval("CDA_AppReason")+","+Eval("CDA_AppState")+","+Eval("CDA_Remarks")
                            +","+Eval("CDA_DocRoute")+","+Eval("CDA_EffectDate")%>' CommandName="Edit_App" OnClientClick="false">编辑</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle/>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="Specil_Code" runat="server" CommandArgument='<%#Eval("CDA_ID")+","+Eval("CDA_DocNO")+","+Eval("CDA_AppNO")
                            +","+Eval("CDA_DocName")+","+Eval("CDA_EditionNO")+","+Eval("CDA_DocType")+","+Eval("CDA_ChangedType")+","+Eval("CDA_AppPer")
                            +","+Eval("CDA_AppTime")+","+Eval("CDA_AppDep")+","+Eval("CDA_AppReason")+","+Eval("CDA_AppState")+","+Eval("CDA_Remarks")
                            +","+Eval("CDA_DocRoute")+","+Eval("CDA_EffectDate")%>' CommandName="Specil_Code" OnClientClick="false">特殊文件编号</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle/>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="Auditor" runat="server" CommandArgument='<%#Eval("CDA_ID")+","+Eval("CDA_DocNO")+","+Eval("CDA_AppNO")
                            +","+Eval("CDA_DocName")+","+Eval("CDA_EditionNO")+","+Eval("CDA_DocType")+","+Eval("CDA_ChangedType")+","+Eval("CDA_AppPer")
                            +","+Eval("CDA_AppTime")+","+Eval("CDA_AppDep")+","+Eval("CDA_AppReason")+","+Eval("CDA_AppState")+","+Eval("CDA_Remarks")
                            +","+Eval("CDA_DocRoute")+","+Eval("CDA_EffectDate")%>' CommandName="Auditor" OnClientClick="false">主管审核</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle/>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="SignPer" runat="server" CommandArgument='<%#Eval("CDA_ID")+","+Eval("CDA_DocNO")+","+Eval("CDA_AppNO")
                            +","+Eval("CDA_DocName")+","+Eval("CDA_EditionNO")+","+Eval("CDA_DocType")+","+Eval("CDA_ChangedType")+","+Eval("CDA_AppPer")
                            +","+Eval("CDA_AppTime")+","+Eval("CDA_AppDep")+","+Eval("CDA_AppReason")+","+Eval("CDA_AppState")+","+Eval("CDA_Remarks")
                            +","+Eval("CDA_DocRoute")+","+Eval("CDA_Auditor")+","+Eval("CDA_AuTime")+","+Eval("CDA_AuSugg")+","+Eval("ETA_AuRes")+","+Eval("CDA_EffectDate")%>' 
                            CommandName="SignPer" OnClientClick="false">会签</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle/>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="Approver" runat="server" CommandArgument='<%#Eval("CDA_ID")+","+Eval("CDA_DocNO")+","+Eval("CDA_AppNO")
                            +","+Eval("CDA_DocName")+","+Eval("CDA_EditionNO")+","+Eval("CDA_DocType")+","+Eval("CDA_ChangedType")+","+Eval("CDA_AppPer")
                            +","+Eval("CDA_AppTime")+","+Eval("CDA_AppDep")+","+Eval("CDA_AppReason")+","+Eval("CDA_AppState")+","+Eval("CDA_Remarks")
                            +","+Eval("CDA_DocRoute")+","+Eval("CDA_Auditor")+","+Eval("CDA_AuTime")+","+Eval("CDA_AuSugg")+","+Eval("ETA_AuRes")+","+Eval("CDA_EffectDate")%>' 
                            CommandName="Approver" OnClientClick="false">审批</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle/>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:HyperLink ID="Down2" runat="server" NavigateUrl='<%#"~/"+Eval("CDA_DocRoute")+"?path={0}"%>' >下载文件</asp:HyperLink >
                        </ItemTemplate>
                        <ItemStyle/>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="Change_App1" runat="server" CommandName="Change_App1" OnClientClick="false"
                                CommandArgument='<%#Eval("CDA_DocName")+","+Eval("CDA_EditionNO")+","+Eval("CDA_DocType")+","+Eval("CDA_AppDep")+","+Eval("CDTLC_ID")+","+Eval("CDA_DocNO")+","+Eval("CDA_ID")+","+Eval("CDA_AppState")%>'>换版申请</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="Delete_App" runat="server" CommandName="Delete_App" OnClientClick="return confirm('您确认删除该记录吗?')"
                                CommandArgument='<%#Eval("CDA_ID")+","+Eval("CDA_DocRoute")+","+Eval("CDA_AppState")%>'>删除</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle />
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="True" EditText="更改编号" UpdateText="更新" CancelText="取消">
                        <ItemStyle />
                    </asp:CommandField>
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
                                <asp:TextBox ID="textbox1" runat="server" Width="20px"></asp:TextBox>
                                <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                    CommandName="Page" Text="GO" /><!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
                            </td>
                        </tr>
                    </table>
                </PagerTemplate>
                <EmptyDataTemplate>
                    <asp:Label ID="Label16" runat="server" Text="没有找到相关记录"></asp:Label>
                </EmptyDataTemplate>
               </asp:GridView>
          </fieldset>
          </asp:Panel>
      </ContentTemplate>
      <Triggers>
        <asp:PostBackTrigger ControlID="Grid_App" />
    </Triggers>
 </asp:UpdatePanel>

 <%--受控文件申请单--%>
 <asp:UpdatePanel ID="UpdatePanel_New" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:Panel ID="Panel_New" runat="server" Visible="False">
    <fieldset>
    <legend>受控文件申请单</legend>
    <asp:Label ID="Label555" runat="server"  Visible="False"></asp:Label>
    <asp:Label ID="Label_CDTLC_ID" runat="server"  Visible="False"></asp:Label>
    <asp:Label ID="Label_CDA_DocNO" runat="server"  Visible="False"></asp:Label>
     <asp:Panel ID="Panel1" runat="server" Visible="False">
       <table style="width: 100%;">
            <tr style="height: 16px;">
                <td style="width: 15%" align="right">
                    <asp:Label ID="Label10" runat="server" Text="受控文件编号：" ></asp:Label>
                </td>
                <td style="width: 18%" align="left">
                    <asp:TextBox ID="newCDA_DocNO" runat="server" Width="130px" Height="20px" ></asp:TextBox>
                    <asp:Label ID="Label43" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*"
                         ControlToValidate="newCDA_DocNO" ValidationGroup="specil_validation"></asp:RequiredFieldValidator>--%>
                </td>
                <td style="width: 14%" align="right">
                    <asp:Label ID="Label13" runat="server" Text="申请单号：" ></asp:Label>
                </td>
                <td style="width: 18%" align="left">
                    <asp:TextBox ID="newCDA_AppNO" runat="server" Width="130px" Height="20px" Enable="false"></asp:TextBox>
                    <asp:Label ID="Label40" runat="server" Text="*" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 12%" align="right">
                    <asp:Label ID="Label21" runat="server" Text="申请单状态：" ></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="newCDA_AppState" runat="server" Width="130px" Height="20px" Enabled="false"></asp:TextBox>
                </td>
            </tr>
        </table>
      </asp:Panel>
      <asp:Panel ID="Panel2" runat="server">
       <table style="width: 100%;">
            <tr>
                <td style="width: 15%" align="right">
                    <asp:Label ID="Label11" runat="server" Text="文件名称：" ></asp:Label>
                </td>
                <td style="width: 18%" align="left">
                    <asp:TextBox ID="newCDA_DocName" runat="server" Width="130px" Height="20px"  MaxLength="50"></asp:TextBox>
                    <asp:Label ID="Label44" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                         ControlToValidate="newCDA_DocName" ValidationGroup="new_validation"></asp:RequiredFieldValidator>--%>
                </td>
                <td style="width: 14%"align="right">
                    <asp:Label ID="Label12" runat="server" Text="版本号：" ></asp:Label>
                </td>
                <td style="width: 18%" align="left">
                    <asp:TextBox ID="newCDA_EditionNO" runat="server" Width="130px" Height="20px"  MaxLength="8"></asp:TextBox>
                    <asp:Label ID="Label47" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                         ControlToValidate="newCDA_EditionNO" ValidationGroup="new_validation"></asp:RequiredFieldValidator>--%>
                </td>
                <td style="width: 12%" align="right">
                    <asp:Label ID="Label22" runat="server" Text="申请部门：" ></asp:Label>
                </td>
                <td align="left">
                   <asp:DropDownList ID="DropDownList5" runat="server" Height="20px" Width="130px" Enabled="false"></asp:DropDownList>
                   <asp:Label ID="Label48" runat="server" Text="*" ForeColor="Red"></asp:Label>
                   <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                         ControlToValidate="DropDownList5" ValidationGroup="new_validation"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label23" runat="server" Text="申请人：" ></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="newCDA_AppPer" runat="server" Width="130px" Height="20px"  MaxLength="10" Enabled="false"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                         ControlToValidate="newCDA_AppPer" ValidationGroup="new_validation"></asp:RequiredFieldValidator>--%>
                </td>
                <td align="right">
                    <asp:Label ID="Label14" runat="server" Text="受控文件类型：" ></asp:Label>
                </td>
                <td align="left">
                    <asp:DropDownList ID="DropDownList6" runat="server" Height="20px" Width="130px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList6_SelectedIndexChanged">
                        <asp:ListItem Text="请选择" Value=""></asp:ListItem>
                        <asp:ListItem Text="第三层次文件" Value="第三层次文件"></asp:ListItem>
                        <asp:ListItem Text="质量文件" Value="质量文件"></asp:ListItem>
                        <asp:ListItem Text="程序文件" Value="程序文件"></asp:ListItem>
                        <asp:ListItem Text="图纸文件" Value="图纸文件"></asp:ListItem>
                        <asp:ListItem Text="外来文件" Value="外来文件"></asp:ListItem>
                        <asp:ListItem Text="其他文件" Value="其他文件"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label ID="Label500" runat="server" Text="*" ForeColor="Red"></asp:Label>
                   <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*"
                         ControlToValidate="DropDownList6" ValidationGroup="new_validation"></asp:RequiredFieldValidator>--%>
                </td>
                <td align="right">
                    <asp:Label ID="Label15" runat="server" Text="文件类别：" ></asp:Label>
                </td>
                <td align="left">
                    <asp:DropDownList ID="DropDownList7" runat="server" Height="20px" Width="130px"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label31" runat="server" Text="更改类型：" ></asp:Label>
                </td>
               <td align="left">
                    <asp:DropDownList ID="DropDownList9" runat="server" Height="20px" Width="130px" AutoPostBack="True" >
                        <asp:ListItem Text="请选择" Value=""></asp:ListItem>
                        <asp:ListItem Text="新增文件" Value="新增文件"></asp:ListItem>
                        <asp:ListItem Text="修改文件" Value="修改文件"></asp:ListItem>
                        <asp:ListItem Text="临时文件" Value="临时文件"></asp:ListItem>
                        <asp:ListItem Text="增发文件" Value="增发文件"></asp:ListItem>
                        <asp:ListItem Text="补发文件" Value="补发文件"></asp:ListItem>
                        <asp:ListItem Text="其他文件" Value="其他文件"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label ID="Label50" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                         ControlToValidate="DropDownList9" ValidationGroup="new_validation"></asp:RequiredFieldValidator>--%>
                </td>
                <td align="right">
                    <asp:Label ID="Label18" runat="server" Text="申请时间：" ></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="newCDA_AppTime" runat="server" Width="130px" Height="20px" onfocus="new WdatePicker(this,'%Y-%M-%D %H:%m:%s ',true)"
                         Text='<%# Eval("CDA_AppTime","{0:yyyy-MM-dd HH:mm:ss}") %>' DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" Enabled="false"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*"
                         ControlToValidate="newCDA_AppTime" ValidationGroup="new_validation"></asp:RequiredFieldValidator>--%>
                </td>
                <td align="right">
                    <asp:Label ID="Label42" runat="server" Text="生效时间：" ></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="newCDA_EffectDate" runat="server" Width="130px" Height="20px" onfocus="new WdatePicker(this,'%Y-%M-%D %H:%m:%s ',true)"
                         Text='<%# Eval("CDA_EffectDate","{0:yyyy-MM-dd HH:mm:ss}") %>' DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" ></asp:TextBox>
                    <asp:Label ID="Label45" runat="server" ForeColor="Red" Text="*"></asp:Label>
                </td>
                </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label17" runat="server" Text="文件路径：" Visible="false"></asp:Label>
                </td>
                <td colspan="5" align="left" >
                    <asp:TextBox ID="newCDA_DocRoute" runat="server" Width="270px" Height="20px"
                        MaxLength="20" Enabled="false" Visible="false"></asp:TextBox>
                    <asp:FileUpload ID="FileUpload1" runat="server" Height="20px" Visible="false"/>
                    <asp:Label ID="Label52" runat="server" ForeColor="Red" Text="*" Visible="false"></asp:Label>
                    <%--<asp:Label ID="Label53" runat="server" Text="*" ForeColor="Red"></asp:Label>--%>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*"
                         ControlToValidate="newCDA_AppReason" ValidationGroup="new_validation"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label62" runat="server" Text="申请原因：<br/>(200字内)"></asp:Label>
                </td>
                <td colspan="5" >
                    <asp:TextBox ID="newCDA_AppReason" runat="server" Width="90%" Height="80px" TextMode="MultiLine"
                        MaxLength="200" onfocus="annotation('Label52');" 
                        onblur="javascript:leave('Label52');"></asp:TextBox>
                    <%--<asp:Label ID="Label53" runat="server" Text="*" ForeColor="Red"></asp:Label>--%>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*"
                         ControlToValidate="newCDA_AppReason" ValidationGroup="new_validation"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label19" runat="server" Text="备注：<br/>(200字内)"></asp:Label>
                </td>
                <td colspan="5" >
                    <asp:TextBox ID="newCDA_Remarks" runat="server" Width="90%" Height="80px" TextMode="MultiLine"
                        MaxLength="200" onfocus="annotation('Label52');" 
                        onblur="javascript:leave('Label52');"></asp:TextBox>
                </td>
            </tr>
         </table>
        </asp:Panel>
        <asp:Panel ID="Panel3" runat="server" Visible="False">
         <table style="width: 100%;">
         <tr>
             <td align="right" style="width: 15%"></td>
             <td align="left" colspan="5">
                <asp:Button ID="Btn_CDDep" runat="server" Text="选择分发岗位" Width="90px" 
                     CssClass="Button02" OnClick="Btn_CDDep_Click" Height="24px"/>
             </td>
         </tr>
         <tr>
            <td align="right">
                <asp:Label ID="Label57" runat="server" Text="分发岗位列表："></asp:Label>
            </td>
            <td align="left" colspan="5">
                <asp:GridView ID="Grid_CDDep" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="0" 
                CssClass="GridViewStyle" DataKeyNames="CDDDD_ID" Font-Strikeout="False" GridLines="None" OnPageIndexChanging="Grid_CDDep_PageIndexChanging" 
                onrowcommand="Grid_CDDep_RowCommand" OnRowDataBound="Grid_CDDep_RowDataBound" PageSize="5" UseAccessibleHeader="False"  Width="90%">
                <RowStyle CssClass="GridViewRowStyle" />  
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle  cssclass="GridViewHead"/>
                <FooterStyle CssClass="GridViewFooterStyle" />
                <Columns>
                    <asp:BoundField DataField="CDDDD_ID" HeaderText="分发岗位详情ID" ReadOnly="True" SortExpression="CDDDD_ID" Visible="False">
                    <ItemStyle/>
                    </asp:BoundField>
                    <asp:BoundField DataField="CDDDCT_ID" HeaderText="岗位分发号代码ID" ReadOnly="True" SortExpression="CDDDCT_ID" Visible="False">
                    <ItemStyle/>
                    </asp:BoundField>
                    <asp:BoundField DataField="CDA_ID" HeaderText="受控文件ID" ReadOnly="True" SortExpression="CDA_ID" Visible="False">
                    <ItemStyle/>
                    </asp:BoundField>
                    <asp:BoundField DataField="CDDDCT_Dep" HeaderText="岗位" SortExpression="CDDDCT_Dep">
                    <ItemStyle/>
                    </asp:BoundField>
                    <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="Delete_CDDep" runat="server"  CommandName="Delete_CDDep" OnClientClick="return confirm('您确认删除该记录吗?')"
                            CommandArgument='<%#Eval("CDDDD_ID")%>'>删除</asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle  />
                    </asp:TemplateField>
                </Columns>
                <PagerTemplate>
                    <table width="100%">
                        <tr>
                            <td style="text-align: right">
                                第<asp:Label ID="lblPageIndex0" runat="server" 
                                    Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                页 共<asp:Label ID="lblPageCount0" runat="server" 
                                    Text="<%# ((GridView)Container.Parent.Parent).PageCount  %>" />
                                页 
                                <asp:LinkButton ID="btnFirst0" runat="server" CausesValidation="False" 
                                    CommandArgument="First" CommandName="Page" Text="首页" />
                                <asp:LinkButton ID="btnPrev0" runat="server" CausesValidation="False" 
                                    CommandArgument="Prev" CommandName="Page" Text="上一页" />
                                <asp:LinkButton ID="btnNext0" runat="server" CausesValidation="False" 
                                    CommandArgument="Next" CommandName="Page" Text="下一页" />
                                <asp:LinkButton ID="btnLast0" runat="server" CausesValidation="False" 
                                    CommandArgument="Last" CommandName="Page" Text="尾页" />
                                <asp:TextBox ID="textbox2" runat="server" Width="20px"></asp:TextBox>
                                <asp:LinkButton ID="btnGo0" runat="server" CausesValidation="False" 
                                    CommandArgument="-1" CommandName="Page" Text="GO" />
                                <!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
                            </td>
                        </tr>
                    </table>
                </PagerTemplate>
                <EmptyDataTemplate>
                    <asp:Label ID="Label33" runat="server" Text="没有找到相关记录"></asp:Label>
                </EmptyDataTemplate>
                </asp:GridView>
                </td>
             </tr>
             <tr>
                 <td align="right" style="width: 15%"></td>
                 <td align="left" colspan="5">
                    <asp:Button ID="Btn_CDAppCon" runat="server" Text="选择会签部门" Width="90px" 
                         CssClass="Button02" OnClick="Btn_CDAppCon_Click" Height="24px"/>
                 </td>
             </tr>
             <tr>
                <td align="right">
                    <asp:Label ID="Label20" runat="server" Text="会签部门列表："></asp:Label>
                    <asp:Label ID="Label_CDASTid" runat="server" Visible="False"></asp:Label>
                </td>
                <td align="left" colspan="5">
                    <asp:GridView ID="Grid_CDAppCon" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="0" 
                    CssClass="GridViewStyle" DataKeyNames="CDAST_ID" Font-Strikeout="False" GridLines="None" OnPageIndexChanging="Grid_CDAppCon_PageIndexChanging" 
                    onrowcommand="Grid_CDAppCon_RowCommand" OnRowDataBound="Grid_CDAppCon_RowDataBound" PageSize="5" UseAccessibleHeader="False"  Width="90%">
                    <RowStyle CssClass="GridViewRowStyle" />  
                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                    <HeaderStyle  cssclass="GridViewHead"/>
                    <FooterStyle CssClass="GridViewFooterStyle" />
                    <Columns>
                        <asp:BoundField DataField="CDAST_ID" HeaderText="受控文件会签ID" ReadOnly="True" SortExpression="CDAST_ID" Visible="False">
                        <ItemStyle/>
                        </asp:BoundField>
                        <asp:BoundField DataField="BDOS_Code" HeaderText="BDOS_Code" ReadOnly="True" SortExpression="BDOS_Code" Visible="False">
                        <ItemStyle/>
                        </asp:BoundField>
                        <asp:BoundField DataField="CDA_ID" HeaderText="受控文件ID" ReadOnly="True" SortExpression="CDA_ID" Visible="False">
                        <ItemStyle/>
                        </asp:BoundField>
                        <asp:BoundField DataField="CDAST_SignPer" HeaderText="会签人" SortExpression="CDAST_SignPer" Visible="False">
                        <ItemStyle/>
                        </asp:BoundField>
                        <asp:BoundField DataField="CDAST_SignTime" HeaderText="会签时间" SortExpression="CDAST_SignTime" Visible="False">
                        <ItemStyle/>
                        </asp:BoundField>
                        <asp:BoundField DataField="CDAST_SignSugg" HeaderText="会签意见" SortExpression="CDAST_SignSugg" Visible="False">
                        <ItemStyle/>
                        </asp:BoundField>
                        <asp:BoundField DataField="CDAST_SignRes" HeaderText="会签结果" SortExpression="CDAST_SignRes">
                        <ItemStyle/>
                        </asp:BoundField>
                        <asp:BoundField DataField="BDOS_Name" HeaderText="部门" SortExpression="BDOS_Name">
                        <ItemStyle/>
                        </asp:BoundField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="look_CDAppCon" runat="server" CommandArgument='<%#Eval("BDOS_Name")+","+Eval("CDAST_SignPer")+","+Eval("CDAST_SignTime")
                                +","+Eval("CDAST_SignSugg")+","+Eval("CDAST_SignRes")%>'  CommandName="look_CDAppCon" OnClientClick="false">查看会签详情</asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle />
                        </asp:TemplateField>
                        <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="Delete_CDAppCon" runat="server"  CommandName="Delete_CDAppCon" OnClientClick="return confirm('您确认删除该记录吗?')"
                                CommandArgument='<%#Eval("CDAST_ID")%>'>删除</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle  />
                        </asp:TemplateField>
                        <asp:TemplateField  Visible="false">
                        <ItemTemplate>
                            <asp:LinkButton ID="Sign_CDAppCon" runat="server"  CommandName="Sign_CDAppCon" OnClientClick="false"
                                CommandArgument='<%#Eval("BDOS_Name")+","+Eval("CDAST_ID")+","+Eval("BDOS_Code")%>'>会签</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle  />
                        </asp:TemplateField>
                    </Columns>
                    <PagerTemplate>
                        <table width="100%">
                            <tr>
                                <td style="text-align: right">
                                    第<asp:Label ID="lblPageIndex0" runat="server" 
                                        Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>" />
                                    页 共<asp:Label ID="lblPageCount0" runat="server" 
                                        Text="<%# ((GridView)Container.Parent.Parent).PageCount  %>" />
                                    页 
                                    <asp:LinkButton ID="btnFirst0" runat="server" CausesValidation="False" 
                                        CommandArgument="First" CommandName="Page" Text="首页" />
                                    <asp:LinkButton ID="btnPrev0" runat="server" CausesValidation="False" 
                                        CommandArgument="Prev" CommandName="Page" Text="上一页" />
                                    <asp:LinkButton ID="btnNext0" runat="server" CausesValidation="False" 
                                        CommandArgument="Next" CommandName="Page" Text="下一页" />
                                    <asp:LinkButton ID="btnLast0" runat="server" CausesValidation="False" 
                                        CommandArgument="Last" CommandName="Page" Text="尾页" />
                                    <asp:TextBox ID="textbox3" runat="server" Width="20px"></asp:TextBox>
                                    <asp:LinkButton ID="btnGo0" runat="server" CausesValidation="False" 
                                        CommandArgument="-1" CommandName="Page" Text="GO" />
                                    <!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
                                </td>
                            </tr>
                        </table>
                    </PagerTemplate>
                    <EmptyDataTemplate>
                        <asp:Label ID="Label33" runat="server" Text="没有找到相关记录"></asp:Label>
                    </EmptyDataTemplate>
                    </asp:GridView>
                   </td>
                </tr>
              </table>
            </asp:Panel>
            <asp:Panel ID="Panel5" runat="server" Visible="False">
               <table style="width: 100%;">
                    <tr>
                        <td style="width: 15%" align="right">
                            <asp:Label ID="Label24" runat="server" Text="审核人：" ></asp:Label>
                        </td>
                        <td style="width: 18%" align="left">
                            <asp:TextBox ID="newCDA_Auditor" runat="server" Width="130px" Height="20px"  MaxLength="10" Enabled="false"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*"
                                 ControlToValidate="newCDA_Auditor" ValidationGroup="au_validation"></asp:RequiredFieldValidator>--%>
                        </td>
                        <td style="width: 14%"align="right">
                            <asp:Label ID="Label25" runat="server" Text="审核时间：" ></asp:Label>
                        </td>
                        <td style="width: 18%" align="left">
                            <asp:TextBox ID="newCDA_AuTime" runat="server" Width="130px" Height="20px" onfocus="new WdatePicker(this,'%Y-%M-%D %H:%m:%s ',true)"
                                 Text='<%# Eval("CDA_AuTime","{0:yyyy-MM-dd HH:mm:ss}") %>' DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" Enabled="false"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*"
                                 ControlToValidate="newCDA_AuTime" ValidationGroup="au_validation"></asp:RequiredFieldValidator>--%>
                        </td>
                        <td style="width: 12%" align="right">
                            <asp:Label ID="Label26" runat="server" Text="审核结果：" ></asp:Label>
                        </td>
                        <td align="left">
                           <asp:TextBox ID="newETA_AuRes" runat="server" Width="130px" Height="20px"  MaxLength="10"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label32" runat="server" Text="审核意见：<br/>(200字内)"></asp:Label>
                        </td>
                        <td colspan="5" >
                            <asp:TextBox ID="newCDA_AuSugg" runat="server" Width="90%" Height="80px" TextMode="MultiLine"
                                MaxLength="200" onfocus="annotation('Label52');" 
                                onblur="javascript:leave('Label52');"></asp:TextBox>
                            <%--<asp:Label ID="Label56" runat="server" Text="*" ForeColor="Red"></asp:Label>--%>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ErrorMessage="*"
                                 ControlToValidate="newCDA_AuSugg" ValidationGroup="au_validation"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                 </table>
                </asp:Panel>
                <asp:Panel ID="Panel6" runat="server" Visible="False">
                   <table style="width: 100%;">
                        <tr>
                            <td style="width: 15%" align="right">
                                <asp:Label ID="Label27" runat="server" Text="审批人：" ></asp:Label>
                            </td>
                            <td style="width: 18%" align="left">
                                <asp:TextBox ID="newCDA_Approver" runat="server" Width="130px" Height="20px"  MaxLength="10" Enabled="false"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*"
                                     ControlToValidate="newCDA_Approver" ValidationGroup="approval_validation"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td style="width: 14%"align="right">
                                <asp:Label ID="Label28" runat="server" Text="审批时间：" ></asp:Label>
                            </td>
                            <td style="width: 18%" align="left">
                                <asp:TextBox ID="newCDA_ApprovalT" runat="server" Width="130px" Height="20px" onfocus="new WdatePicker(this,'%Y-%M-%D %H:%m:%s ',true)"
                                     Text='<%# Eval("CDA_AuTime","{0:yyyy-MM-dd HH:mm:ss}") %>' DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" Enabled="false"></asp:TextBox>
                                <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="*"
                                     ControlToValidate="newCDA_ApprovalT" ValidationGroup="approval_validation"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td style="width: 12%" align="right">
                                <asp:Label ID="Label29" runat="server" Text="审批结果：" ></asp:Label>
                            </td>
                            <td align="left">
                               <asp:TextBox ID="newCDA_ApprovalRes" runat="server" Width="130px" Height="20px"  MaxLength="10"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label30" runat="server" Text="审批意见：<br/>(200字内)"></asp:Label>
                            </td>
                            <td colspan="5" >
                                <asp:TextBox ID="newCDA_ApprovalSugg" runat="server" Width="90%" Height="80px" TextMode="MultiLine"
                                    MaxLength="200" onfocus="annotation('Label52');" 
                                    onblur="javascript:leave('Label52');"></asp:TextBox>
                                <%--<asp:Label ID="Label60" runat="server" Text="*" ForeColor="Red"></asp:Label>--%>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="*"
                                     ControlToValidate="newCDA_ApprovalSugg" ValidationGroup="approval_validation"></asp:RequiredFieldValidator>--%>
                            </td>
                        </tr>
                     </table>
                </asp:Panel>
                <%--新建的按钮--%>
                <asp:Panel ID="Panel7" runat="server" Visible="False">
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td  style="width: 33%" align="right">
                                <asp:Button ID="Btn_Savenew" runat="server" Text="保存" Width="70px" 
                                    CssClass="Button02" OnClick="Btn_Savenew_Click"  Height="24px"/>
                            </td>
                            <td style="width: 33%" align="center"></td>
                            <td align="left">
                                <asp:Button ID="Btn_Cancelnew" runat="server" CssClass="Button02" Text="关闭" 
                                    Width="70px" OnClick="Btn_Cancelnew_Click" Height="24px" />
                            </td>
                        </tr>
                    </table>
                 </asp:Panel>
                <%--选择岗位和会签部门后的按钮--%>
                <asp:Panel ID="Panel8" runat="server" Visible="False">
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td  style="width: 33%" align="right">
                                <asp:Button ID="Btn_Save" runat="server" Text="保存" Width="70px" 
                                    CssClass="Button02" OnClick="Btn_Save_Click"  ValidationGroup="new_validation" 
                                    Height="24px"/>
                            </td>
                            <td style="width: 33%" align="center">
                                <asp:Button ID="Btn_Submit" runat="server" CssClass="Button02" Text="提交" 
                                    Width="70px" OnClick="Btn_Submit_Click"  ValidationGroup="new_validation" 
                                    Height="24px"/>
                            </td>
                            <td align="left">
                                <asp:Button ID="Btn_Cancel" runat="server" CssClass="Button02" Text="关闭" 
                                    Width="70px" OnClick="Btn_Cancel_Click" Height="24px" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <%--审核的按钮--%>
                <asp:Panel ID="Panel9" runat="server" Visible="False">
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td style="width: 33%" align="right">
                                <asp:Button ID="Au_ok" runat="server" Text="通过" Width="70px" 
                                    CssClass="Button02" OnClick="Au_ok_Click" ValidationGroup="au_validation" 
                                    Height="24px"/>
                            </td>
                            <td style="width: 33%" align="center">
                                <asp:Button ID="Au_notok" runat="server" CssClass="Button02" Text="驳回" 
                                    Width="70px" OnClick="Au_notok_Click" ValidationGroup="au_validation" 
                                    Height="24px"/>
                            </td>
                            <td align="left">
                                <asp:Button ID="Au_Cancel" runat="server" CssClass="Button02" Text="关闭" 
                                    Width="70px" OnClick="Au_Cancel_Click" Height="24px" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <%--审批的按钮--%>
                <asp:Panel ID="Panel10" runat="server" Visible="False">
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td  style="width: 33%" align="right">
                                <asp:Button ID="Approval_ok" runat="server" Text="通过" Width="70px" 
                                    CssClass="Button02" OnClick="Approval_ok_Click" 
                                    ValidationGroup="approval_validation" Height="24px"/>
                            </td>
                            <td style="width: 33%" align="center">
                                <asp:Button ID="Approval_notok" runat="server" CssClass="Button02" Text="驳回" 
                                    Width="70px" OnClick="Approval_notok_Click" 
                                    ValidationGroup="approval_validation" Height="24px"/>
                            </td>
                            <td align="left">
                                <asp:Button ID="Approval_Cancel" runat="server" CssClass="Button02" Text="关闭" 
                                    Width="70px" OnClick="Approval_Cancel_Click" Height="24px" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <%--查看的按钮--%>
                <asp:Panel ID="Panel11" runat="server" Visible="False">
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td  style="width: 33%" align="right"></td>
                            <td style="width: 33%" align="center">
                                <asp:Button ID="Look_close" runat="server" CssClass="Button02" Text="关闭" 
                                    Width="70px" OnClick="Look_close_Click" Height="24px"/>
                            </td>
                            <td align="left"></td>
                        </tr>
                    </table>
                </asp:Panel>
                <%--特殊文件编号的按钮--%>
                <asp:Panel ID="Panel12" runat="server" Visible="False">
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td  style="width: 33%" align="right">
                                <asp:Button ID="Btn_Okspecil" runat="server" Text="提交" Width="70px" 
                                    CssClass="Button02" OnClick="Btn_Okspecil_Click" 
                                    ValidationGroup="specil_validation" Height="24px"/>
                            </td>
                            <td style="width: 33%" align="center"></td>
                            <td align="left">
                                <asp:Button ID="Btn_Cancelspecil" runat="server" CssClass="Button02" Text="关闭" 
                                    Width="70px" OnClick="Btn_Cancelspecil_Click" Height="24px" />
                            </td>
                        </tr>
                    </table>
                 </asp:Panel>
        <%--特殊录入通道的按钮--%>
                <asp:Panel ID="Panel15" runat="server" Visible="False">
                    <table style="width: 100%;">
                        <tr style="height: 16px;">
                            <td  style="width: 33%" align="right">
                                <asp:Button ID="Btn_SpecilOK" runat="server" Text="提交" Width="70px" 
                                    CssClass="Button02" OnClick="Btn_SpecilOK_Click"  Height="24px"/>
                            </td>
                            <td style="width: 33%" align="center"></td>
                            <td align="left">
                                <asp:Button ID="Btn_SpecilCancel" runat="server" CssClass="Button02" Text="关闭" 
                                    Width="70px" OnClick="Btn_SpecilCancel_Click" Height="24px" />
                            </td>
                        </tr>
                    </table>
                 </asp:Panel>
        </fieldset>
     </asp:Panel>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="Btn_Savenew" />
        <asp:PostBackTrigger ControlID="Btn_SpecilOK" />
    </Triggers>
</asp:UpdatePanel>

<%--上传受控文件--%>
 <%--<div id="Panel99">
    <asp:UpdatePanel ID="UpdatePanel_upload" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <fieldset>
                <legend>上传受控文件</legend>
                <table style="width: 100%;">
                    <tr style="height: 16px;">
                        <td align="right" style="width: 18%;">
                            <asp:Label ID="Label42" runat="server" Text="上传文件："></asp:Label>
                        </td>
                        <td style="width: 45%;">
                            <asp:FileUpload ID="FileUpload1" runat="server"  Width="330px" Height="20px"/>
                            <asp:Label ID="Label333" runat="server" Text="*" ForeColor="Red"></asp:Label>
                        </td>
                        <td align="center" style="width: 20%;">
                            <asp:Button ID="ok_upload" runat="server" Text="提交" Width="70px" 
                                CssClass="Button02" OnClick="ok_upload_Click" ValidationGroup="loadvalidation" 
                                Height="24px"/>
                        </td>
                        <td align="left">
                            <asp:Button ID="cancel_upload" runat="server" Text="关闭" Width="70px" 
                                CssClass="Button02" OnClick="cancel_upload_Click" Height="24px" />
                        </td>
                    </tr>
                </table>
            </fieldset>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="ok_upload" />
        </Triggers>
    </asp:UpdatePanel>
 </div>--%>

<%--选择分发岗位--%>
<asp:UpdatePanel ID="UpdatePanel_chooseCDDep" runat="server" UpdateMode="Conditional">
     <ContentTemplate>
        <asp:Panel ID="Panel_chooseCDDep" runat="server" Visible="false">
            <fieldset >
                <legend>选择分发岗位</legend>
                <table style="width: 100%;">
                    <tr>
                        <%--<td align="right" style="width: 15%;">
                            <asp:Label ID="Label45" runat="server" Text="部门：" ></asp:Label>
                        </td>
                        <td style="width: 18%;">
                            <asp:DropDownList ID="DropDownList8" runat="server" Height="20px" Width="150px"></asp:DropDownList>
                        </td>--%>
                        <td align="right" style="width: 25%;">
                            <asp:Label ID="Label46" runat="server" Text="岗位：" ></asp:Label>
                        </td>
                        <td style="width: 18%;">
                            <asp:TextBox ID="TextchooseDep" runat="server" Width="150px" Height="20px"  MaxLength="10"></asp:TextBox>
                        </td>
                        <td align="right" style="width: 25%;">
                            <asp:Button ID="Search_chooseDep" runat="server" Text="检索" Width="70px" 
                                CssClass="Button02" onclick="Search_chooseDep_Click" Height="24px" />  
                        </td>
                        <td align="center"> 
                            <asp:Button ID="Clear_chooseDep" runat="server" Text="重置" CssClass="Button02"  
                                OnClick="Clear_chooseDep_Click" Width="70px" Height="24px" /> 
                        </td>
                    </tr>
                    <tr>
                       <td colspan="6">
                        <asp:GridView ID="Grid_chooseCDDep" runat="server" DataKeyNames="CDDDCT_ID" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                        AllowPaging="True" PageSize="10" Font-Strikeout="False" UseAccessibleHeader="False"
                        OnPageIndexChanging="Grid_chooseCDDep_PageIndexChanging" OnRowCommand="Grid_chooseCDDep_RowCommand"
                        OnRowDataBound="Grid_chooseCDDep_RowDataBound" GridLines="None">
                        <RowStyle CssClass="GridViewRowStyle" />  
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle  cssclass="GridViewHead"/>
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:TemplateField HeaderText="选择">
                                <ItemTemplate>
                                    <asp:CheckBox ID="ckb1" runat="server" />
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:BoundField DataField="CDDDCT_ID" HeaderText="岗位分发号代码ID" ReadOnly="True" SortExpression="CDDDCT_ID" Visible="False">
                                <ItemStyle />
                            </asp:BoundField>
                            <asp:BoundField DataField="CDDDCT_Dep" HeaderText="岗位" SortExpression="CDDDCT_Dep">
                                <ItemStyle/>
                            </asp:BoundField>
                            <asp:BoundField DataField="CDDDCT_Code" HeaderText="岗位代码" SortExpression="CDDDCT_Code" Visible="false">
                                <ItemStyle/>
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
                                        <asp:TextBox ID="textbox5" runat="server" Width="20px"></asp:TextBox>
                                        <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                            CommandName="Page" Text="GO" /><!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
                                    </td>
                                </tr>
                            </table>
                        </PagerTemplate>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label16" runat="server" Text="没有找到相关记录"></asp:Label>
                        </EmptyDataTemplate>
                   </asp:GridView>
                   </td>
                </tr>
                <tr>
                    <td style="height: 30px;" align="right">
                        
                    </td>
                    <td style="height: 30px" align="left">
                    <asp:Button ID="BtnOK_chooseDep" runat="server" Text="提交" Width="70px" 
                            CssClass="Button02" OnClick="BtnOK_chooseDep_Click" Height="24px"/></td>
                    <td></td>
                    <td style="height: 30px" align="left">
                        <asp:Button ID="BtnCancel_chooseDep" runat="server" Text="关闭" 
                            CssClass="Button02" Width="70px" OnClick="BtnCancel_chooseDep_Click" 
                            Height="24px" />
                    </td>
                </tr>                              
                </table>
          </fieldset>
          </asp:Panel>
      </ContentTemplate>
 </asp:UpdatePanel>

 <%--选择会签部门--%>
<asp:UpdatePanel ID="UpdatePanel_chooseBDO" runat="server" UpdateMode="Conditional">
     <ContentTemplate>
        <asp:Panel ID="Panel_chooseBDO" runat="server" Visible="false">
            <fieldset >
                <legend>选择会签部门</legend>
                <table style="width: 100%;">
                    <tr>
                        <td align="right" style="width: 17%;">
                            <asp:Label ID="Label34" runat="server" Text="部门：" ></asp:Label>
                        </td>
                        <td style="width: 18%;">
                            <asp:TextBox ID="TextchooseBDO" runat="server" Width="150px" Height="20px"  MaxLength="10"></asp:TextBox>
                        </td>
                        <td align="right" style="width: 8%;"></td>
                        <td style="width: 18%;" align="right">
                            <asp:Button ID="Search_chooseBDO" runat="server" Text="检索" Width="70px" 
                                CssClass="Button02" onclick="Search_chooseBDO_Click" Height="24px" />  
                        </td>
                        <td align="right" style="width: 10%;"></td>
                        <td align="left"> 
                            <asp:Button ID="Clear_chooseBDO" runat="server" Text="重置" CssClass="Button02"  
                                OnClick="Clear_chooseBDO_Click" Width="70px" Height="24px" /> 
                        </td>
                    </tr>
                    <tr>
                       <td colspan="6">
                        <asp:GridView ID="Grid_chooseBDO" runat="server" DataKeyNames="BDOS_Code" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="GridViewStyle" CellPadding="0" Width="100%"
                        AllowPaging="True" PageSize="10" Font-Strikeout="False" UseAccessibleHeader="False"
                        OnPageIndexChanging="Grid_chooseBDO_PageIndexChanging" OnRowCommand="Grid_chooseBDO_RowCommand"
                        OnRowDataBound="Grid_chooseBDO_RowDataBound" GridLines="None">
                        <RowStyle CssClass="GridViewRowStyle" />  
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle  cssclass="GridViewHead"/>
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:TemplateField HeaderText="选择">
                                <ItemTemplate>
                                    <asp:CheckBox ID="ckb2" runat="server" />
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:BoundField DataField="BDOS_Code" HeaderText="组织机构ID" ReadOnly="True" SortExpression="BDOS_Code" Visible="False">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="BDOS_Name" HeaderText="部门"  ReadOnly="True" SortExpression="BDOS_Name">
                            <ItemStyle />
                        </asp:BoundField>
                        <asp:BoundField DataField="BDOS_DepCode" HeaderText="部门代码" SortExpression="BDOS_DepCode" Visible="False">
                            <ItemStyle/>
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
                                        <asp:TextBox ID="textbox6" runat="server" Width="20px"></asp:TextBox>
                                        <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1"
                                            CommandName="Page" Text="GO" /><!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
                                    </td>
                                </tr>
                            </table>
                        </PagerTemplate>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label16" runat="server" Text="没有找到相关记录"></asp:Label>
                        </EmptyDataTemplate>
                   </asp:GridView>
                   </td>
                </tr>
                <tr>
                    <td></td>
                    <td style="height: 30px;" align="right">
                        <asp:Button ID="BtnOK_chooseBDO" runat="server" Text="提交" Width="70px" 
                            CssClass="Button02" OnClick="BtnOK_chooseBDO_Click" Height="24px"/>
                    </td>
                    <td style="height: 30px"></td>
                    <td></td>
                    <td style="height: 30px"align="left">
                        <asp:Button ID="BtnCancel_chooseBDO" runat="server" Text="关闭" 
                            CssClass="Button02" Width="70px" OnClick="BtnCancel_chooseBDO_Click" 
                            Height="24px" />
                    </td>
                    <td></td>
                </tr>                              
                </table>
          </fieldset>
          </asp:Panel>
      </ContentTemplate>
 </asp:UpdatePanel>

 <%--会签--%>
 <asp:UpdatePanel ID="UpdatePanel_Sign" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:Panel ID="Panel_Sign" runat="server" Visible="false">
    <fieldset>
    <legend><asp:Label ID="Label999" runat="server"></asp:Label>会签</legend>
      <asp:Panel ID="Panel4" runat="server">
       <table style="width: 100%;">
            <tr style="height: 16px;">
                <td style="width: 11%" align="right">
                    <asp:Label ID="Label35" runat="server" Text="会签人：" ></asp:Label>
                </td>
                <td style="width: 21%" align="left">
                    <asp:TextBox ID="newCDAST_SignPer" runat="server" Width="150px" Height="20px"  
                        MaxLength="20"  Enabled="false"></asp:TextBox>
                    <%--<asp:Label ID="Label39" runat="server" Text="*" ForeColor="Red"></asp:Label>--%>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="*"
                            ControlToValidate="newCDAST_SignPer" ValidationGroup="sign_validation"></asp:RequiredFieldValidator>--%>
                </td>
                <td style="width: 10%" align="right">
                    <asp:Label ID="Label36" runat="server" Text="会签时间：" ></asp:Label>
                </td>
                <td style="width: 21%" align="left">
                    <asp:TextBox ID="newCDAST_SignTime" runat="server" Width="150px" Height="20px"  MaxLength="20" Enabled="false"></asp:TextBox>
                    <%--<asp:Label ID="Label40" runat="server" Text="*" ForeColor="Red"></asp:Label>--%>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="*"
                            ControlToValidate="newCDAST_SignTime" ValidationGroup="sign_validation"></asp:RequiredFieldValidator>--%>
                </td>
                <td style="width: 10%" align="right">
                    <asp:Label ID="Label37" runat="server" Text="会签结果："></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="newCDAST_SignRes" runat="server" Width="150px" Height="20px"  MaxLength="20" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label38" runat="server" Text="会签意见：<br/>(200字内)" ></asp:Label>
                </td>
                <td align="left"  colspan="5">
                    <asp:TextBox ID="newCDAST_SignSugg" runat="server" Width="90%" Height="80px" TextMode="MultiLine"
                        MaxLength="200" onfocus="annotation('Label52');" onblur="javascript:leave('Label52');"></asp:TextBox>
                    <%--<asp:Label ID="Label41" runat="server" Text="*" ForeColor="Red"></asp:Label>--%>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*"
                            ControlToValidate="newCDAST_SignSugg" ValidationGroup="sign_validation"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>
          </table>
        </asp:Panel>
        <asp:Panel ID="Panel13" runat="server">
          <table style="width: 100%;">
            <tr style="height: 16px;">
                <td align="right" style="width: 33%">
                    <asp:Button ID="Sign_ok" runat="server" Text="通过" Width="70px" 
                        CssClass="Button02" OnClick="Sign_ok_Click"  ValidationGroup="sign_validation" 
                        Height="24px"/>
                </td>
                <td align="center" style="width: 33%">
                    <asp:Button ID="Sign_notok" runat="server" CssClass="Button02" Text="驳回" 
                        Width="70px" OnClick="Sign_notok_Click"  ValidationGroup="sign_validation" 
                        Height="24px"/>
                </td>
                <td align="left">
                    <asp:Button ID="Sign_Cancel" runat="server" CssClass="Button02" Text="关闭" 
                        Width="70px" OnClick="Sign_Cancel_Click" Height="24px" />
                </td>
            </tr>
         </table>
        </asp:Panel>
        <asp:Panel ID="Panel14" runat="server">
          <table style="width: 100%;">
            <tr style="height: 16px;">
                <td align="center" style="width: 100%;">
                    <asp:Button ID="Sign_close" runat="server" CssClass="Button02" Text="关闭" 
                        Width="70px" OnClick="Sign_close_Click" ValidationGroup="sign_validation" 
                        Height="24px"/>
                </td>
            </tr>
        </table>
        </asp:Panel>
     </fieldset>
     </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>





</asp:Content>