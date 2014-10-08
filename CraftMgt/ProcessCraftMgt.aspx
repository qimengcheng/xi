<%@ Page Title="工序维护/查看" Language="C#" 
    MasterPageFile="~/Other/MasterPage.master" 
    AutoEventWireup="true" 
    CodeFile="ProcessCraftMgt.aspx.cs" 
    Inherits="CraftMgt_ProcessCraftMgt" %>

<%--
页面名：工序维护/查看
作者：bush2582
--%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<%--工序检索界面--%>
    <asp:UpdatePanel ID="UpdatePanel_Search_Craft" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel_Search_Craft" runat="server" Visible="true">
                <fieldset>
                    <legend>工序检索</legend>
                        <div style="width:100%;height:10%">
                            <div id="DIV_Input_Search_text" style="float:left;width:30%;height:100%">
                                <div id="DIV_ShowInfo" style="float:left;width:30%;height:90%; ">
                                    工序名称:
                                </div>
                                <div id="DIV_Asp_Input_Search_text" style="float:right;width:70%;height:100%">
                                    <asp:TextBox ID="Asp_Input_Search_text" runat="server" style="width:100%"></asp:TextBox>
                                </div>
                            </div>

                            <div id="DIV_WarningDay_ShowInfo" style="float:left;width:10%;height:100%;margin-left:2%">
                                    工序报警时限:
                            </div>
                            <div id="DIV_WarningDay" style="float:left;width:6%;height:100%;margin-left:1%">
                                <asp:DropDownList ID="Asp_DropDownList_Search" runat="server" Width="100%">
                                    <asp:ListItem> </asp:ListItem>
                                    <asp:ListItem>1</asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>3</asp:ListItem>
                                    <asp:ListItem>4</asp:ListItem>
                                    <asp:ListItem>5</asp:ListItem>
                                    <asp:ListItem>6</asp:ListItem>
                                    <asp:ListItem>7</asp:ListItem>
                                    <asp:ListItem>8</asp:ListItem>
                                    <asp:ListItem>9</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                </asp:DropDownList>                            
                            </div>


                             <div id="DIV_Input_Btn_Search" style="float:left;width:10%; margin-left:2%">
                                <asp:Button ID="Asp_Input_Btn_Search" runat="server" Text="检索" 
                                     CssClass="Button02" style="width:100%; height:90%" onclick="Asp_Input_Btn_Search_Click" 
                                     />
                            </div>
                            <div id="DIV_Input_Btn_Reset" style="float:left;width:10%; margin-left:2%">
                                <asp:Button ID="Asp_Input_Btn_Reset" runat="server" Text="重置" 
                                    CssClass="Button02" style="width:100%; height:90%" onclick="Asp_Input_Btn_Reset_Click" 
                                     />
                            </div>
                            <div id="DIV_Input_Btn_AddNewCraft" style="float:right;width:15%; ">
                                <asp:Button ID="Asp_Input_AddNewCraft" runat="server" Text="工序新增" 
                                    CssClass="Button02" style="width:100%; height:90%" onclick="Asp_Input_AddNewCraft_Click" 
                                    />
                            </div>
                        </div>
                </fieldset>
            </asp:Panel>
        </ContentTemplate> 
    </asp:UpdatePanel>
<%--工序新增界面--%>
    <asp:UpdatePanel ID="UpdatePanel_ADD_Craft" runat="server" UpdateMode="Conditional" >
        <ContentTemplate>
            <asp:Panel id="Panel_ADD_Craft" runat="server" Visible=false>
                <fieldset>
                    <legend>
                        工序新增（*号为必填项目）
                    </legend>
                    <div id="DIV_ADD_Craft"  style="width:100%; height:10%">
                        <div id="DIV_ADD_Craft_Name_ShowInfo" style="float:left; width:9%; height:100%;">
                            工序名称：
                        </div>
                        <div id="DIV_ADD_Craft_Name_Text" style= "float:left; width:10%; height:100%; margin-left:0%">
                            <asp:TextBox ID="Asp_ADD_Craft_Name_Text" runat="server" Width="100%" Height="100%"></asp:TextBox>
                        </div>
                        <div id="ShowMust1" style= "float:left; width:2%; height:100%; margin-left:1%">
                            <font color="red">*</font>
                        </div>
                        <div id="DIV_ADD_Craft_WDay_ShowInfo" style="float:left; width:10%; height:100%; margin-left:2%;">
                            预警天数：
                        </div>
                        <div id="DIV_ADD_Craft_WDay_Text" style= "float:left; width:6%; height:100%;">
                            <asp:DropDownList ID="Asp_ADD_DropDownList" runat="server" Width="100%">
                                    <asp:ListItem> </asp:ListItem>
                                    <asp:ListItem>1</asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>3</asp:ListItem>
                                    <asp:ListItem>4</asp:ListItem>
                                    <asp:ListItem>5</asp:ListItem>
                                    <asp:ListItem>6</asp:ListItem>
                                    <asp:ListItem>7</asp:ListItem>
                                    <asp:ListItem>8</asp:ListItem>
                                    <asp:ListItem>9</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                </asp:DropDownList>
                        </div>
                        <div id="Div3" style= "float:left; width:2%; height:100%; margin-left:1%">
                            <font color="red">*</font>
                        </div>

                        <div id="DIV_ADD_Craft_QualifiedRate_ShowInfo" style=" float:left;width:13%; height:100%; margin-left:2%">
                            合格率参考标准：
                        </div>
                        <div id="DIV_ADD_Craft_QualifiedRate" style=" float:left;width:7%; height:100%;">
                            <asp:TextBox ID="ASP_ADD_Craft_QualifiedRate_Text" runat="server" Width="100%" Height="100%"
                            onkeyup="if(isNaN(value)){alert('只能输入小数和数字');this.value='';}" 
                            onafterpaste="if(isNaN(value)){alert('只能输入小数和数字');this.value='';"
                            ></asp:TextBox>
                        </div>
                        <div id="Div4" style= "float:left; width:2%; height:100%; margin-left:1%">
                            <font color="red">*</font>
                        </div>


                        <div id="DIV_ADD_Craft_Parameter_ShowInfo" style=" float:left;width:10%; height:100%; margin-left:2%">
                            工艺参数参考:
                        </div>
                        <div id="DIV_ADD_Craft_Parameter" style=" float:left;width:6%; height:100%;">
                            <asp:TextBox ID="ASP_ADD_Craft_Parameter_Text" runat="server" Width="100%" Height="100%"></asp:TextBox>
                        </div>
                        <div id="Div5" style= "float:left; width:2%; height:100%; margin-left:1%">
                            <font color="red">*</font>
                        </div>


                        <div id="DIV_ADD_Craft_Btn" style= "float:left; width:8%; height:100%;margin-left:2%;">
                            <asp:Button ID="Asp_ADD_Craft_Btn" Width="100%" Height="90%" Text="确定" 
                                CssClass="Button02" runat="server" onclick="Asp_ADD_Craft_Btn_Click"  />
                        </div>
                    </div>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
<%--工序列表界面--%>
    <asp:UpdatePanel ID="UpdatePanel_List_Craft" runat="server" UpdateMode="Conditional">
        <ContentTemplate> 
            <asp:Panel id="Panel_List_Craft" runat="server" Visible=true>
            <fieldset>
                    <legend>工序列表</legend>
                    <div id="GridView" style="width:100%;">
                        <asp:GridView ID="GridViewShowCraftList" runat="server" Width="100%"
                            EnableModelValidation="True" CssClass="GridViewStyle" 
                            AutoGenerateColumns="False" 
                            AllowPaging="True"  GridLines="None"
                            DataKeyNames="PBC_ID,PBC_Name" 
                            EmptyDataText="无相关记录!"
                            onpageindexchanging="GridViewShowCraftList_PageIndexChanging" 
                            onrowcommand="GridViewShowCraftList_RowCommand" 
                            onrowcancelingedit="GridViewShowCraftList_RowCancelingEdit" 
                            onrowediting="GridViewShowCraftList_RowEditing" PageSize="10" 
                            onrowupdating="GridViewShowCraftList_RowUpdating" 
                            onrowdeleting="GridViewShowCraftList_RowDeleting" ondatabound="GridViewShowCraftList_DataBound" >

                            <%--gridview的样式文件--%>
                            <RowStyle CssClass="GridViewRowStyle" />
                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                            <HeaderStyle CssClass="GridViewHead" />



                            <Columns>
                                <asp:BoundField DataField="PBC_ID" HeaderText="工序ID" SortExpression="PBC_ID" Visible="false"/>
                                <asp:BoundField DataField="PBC_Name" HeaderText="工序名称"/>
                                <%--<asp:BoundField DataField="PBC_Time" HeaderText="预警天数"/>--%>

                                <asp:TemplateField HeaderText ="预警天数">
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("PBC_Time") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ASP_PBC_Time_DropDownList" runat="server" Width="60%" DataTextField="PBC_Time">
                                                <asp:ListItem> </asp:ListItem>
                                                <asp:ListItem>1</asp:ListItem>
                                                <asp:ListItem>2</asp:ListItem>
                                                <asp:ListItem>3</asp:ListItem>
                                                <asp:ListItem>4</asp:ListItem>
                                                <asp:ListItem>5</asp:ListItem>
                                                <asp:ListItem>6</asp:ListItem>
                                                <asp:ListItem>7</asp:ListItem>
                                                <asp:ListItem>8</asp:ListItem>
                                                <asp:ListItem>9</asp:ListItem>
                                                <asp:ListItem>10</asp:ListItem>
                                            </asp:DropDownList>
                                        </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField DataField="PBC_PassRate" HeaderText="合格率参考" />
                                <asp:BoundField DataField="PBC_Parameter" HeaderText="工艺参数参考" />
                                <asp:CommandField ShowEditButton="True"  EditText="编辑" CancelText="取消" 
                                    InsertText="插入" UpdateText="更新"/>
                                
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                            CommandName="Delete" Text="删除" OnClientClick="return confirm('您确认删除该记录吗?')"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="ASP_Label_RejectsClass" runat="server" CausesValidation="False" CommandArgument="First"
                                            CommandName="RejectsClass" Text="不良品类型查看/管理" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                           
                            <PagerTemplate>
                                <div id="DIV_Pager" style="width:100%; ">
                                    <div id="DIV_PagerIndex" style="width:5%; margin-left:60%;float:left">
                                        第<asp:Label ID="ASP_Label_PageIndex" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>"/>页
                                    </div>
                                    <div id="DIV_PagerCount" style="width:5%; float:left">
                                        共<asp:Label ID="ASP_Label_PageCount" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageCount  %>" />页
                                    </div>
                                    <div id="DIV_Pager_Frist" style="width:5%; float:left">
                                        <asp:LinkButton ID="ASP_Label_PageFirst" runat="server" CausesValidation="False" CommandArgument="Craft"
                                            CommandName="PageFirst" Text="首页" />
                                    </div>
                                    <div id="DIV_Pager_Prev" style="width:5%; float:left">
                                        <asp:LinkButton ID="ASP_Label_PagePrev" runat="server" CausesValidation="False" CommandArgument="Craft"
                                            CommandName="PagePrev" Text="上一页" />
                                    </div>
                                    <div id="DIV_Pager_Next" style="width:5%; float:left">
                                        <asp:LinkButton ID="ASP_Label_PageNext" runat="server" CausesValidation="False" CommandArgument="Craft"
                                            CommandName="PageNext" Text="下一页" />
                                    </div>
                                    <div id="DIV_Pager_Last" style="width:5%; float:left">
                                        <asp:LinkButton ID="ASP_Label_PageLast" runat="server" CausesValidation="False" CommandArgument="Craft"
                                            CommandName="PageLast" Text="尾页" />
                                    </div>
                                    <div id="DIV_Goto_Apage" style="width:2%; float:left;">
                                        <asp:TextBox runat="server" Width="100%" ID="ASP_Pager_Text"></asp:TextBox>
                                    </div>
                                    <div id="DIV_JumpToPage" style="width:2%; float:left; margin-left:1%">
                                        <asp:LinkButton ID="ASP_Jump_blt" runat="server" CausesValidation="False" CommandArgument="Craft"
                                            CommandName="PageJump" Text="GO" />
                                    </div>
                                </div>
                            </PagerTemplate>
                            <PagerStyle  BorderWidth="1px"  HorizontalAlign="Center"
                            CssClass="GridViewPagerStyle" />
                        </asp:GridView>
                    </div>
            </fieldset> 
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

<%--不良品类型管理界面--%>
    <asp:UpdatePanel ID="UpdatePanel_Rejects" runat="server" UpdateMode="Conditional">
        <ContentTemplate> 
            <asp:Panel id="Panel_Rejects" runat="server" Visible=false>
                <fieldset>
                    <legend>
                        <asp:Label runat="server" ID="ASP_Label_Rejects_Label"  Text="工序不良品类型管理"></asp:Label>
                    </legend>
                    <div id ="div2582" style="float:left; width:100%">
                        <div id= "div2586"  style="float:left; width:90%">
                            <asp:Panel ID="Panel_ADD_BadProduct" runat="server" Visible=false >
                                <div id="DIV_ADD_BadProduct" style=" width:100%" >
                                    <div id="DIV_BadProduct_ShowInfo" style=" float:left; width:10%; height:100%">
                                        不良品名称：
                                    </div>
                                    <div id="DIV_ADD_BadProduct_ShowInfo" style="float:left; width:20%; height:100%">
                                        <asp:TextBox ID="ASP_ADD_BadProduct_text" Width=100% runat=server></asp:TextBox>
                                    </div>
                                    <div id="Div6" style= "float:left; width:2%; height:100%; margin-left:1%">
                                        <font color="red">*</font>
                                    </div>

                                    <div id="DIV_BadProduct_LevelShowInfo" style=" float:left; width:10%; height:100%; margin-left:2%">
                                        严重程度：
                                    </div>
                                    

                                    <div id="DIV_BadProduct_LevelDropDownList" style= "float:left; width:10%; height:100%;">
                                        <asp:DropDownList ID="ASP_ADD_BadProduct_DropDownList" runat="server" Width="100%">
                                                <asp:ListItem> </asp:ListItem>
                                                <asp:ListItem>一般问题</asp:ListItem>
                                                <asp:ListItem>严重问题</asp:ListItem>
                                                <asp:ListItem>致命问题</asp:ListItem>
                                         </asp:DropDownList>
                                    </div>
                                    <div id="Div7" style= "float:left; width:2%; height:100%; margin-left:1%">
                                        <font color="red">*</font>
                                    </div>

                                    <div id="DIV_ADD_BadProduct" style= "float:left; width:12%; height:100%;margin-left:2%;">
                                        <asp:Button ID="ASP_ADD_BadProduct" Width="100%" Height="90%" Text="新增不良品类型" 
                                            CssClass="Button02" runat="server" onclick="ASP_ADD_BadProduct_Click"  />
                                    </div>

                                    
                                </div>
                            </asp:Panel>
                        </div>
                        <div id="div2587" style="float:right;width:10%">
                            <div id="DIV2" style= "float:left; width:100%; height:100%;margin-left:2%;">
                                 <asp:Button ID="ASP_ADD_Close" Width="100%" Height="90%" Text="关闭" 
                                  CssClass="Button02" runat="server" onclick="ASP_ADD_Close_Click"  />
                            </div>
                        </div>
                    </div>

                    <asp:Panel ID="Panel_GridViewShowRejects" runat="server" Visible=false>
                        <div id="Div1" style="width:100%; margin-top:5%" >
                            <asp:GridView ID="GridViewShowRejects" runat="server" Width="100%"
                                EnableModelValidation="True" CssClass="GridViewStyle" 
                                AutoGenerateColumns="False" 
                                AllowPaging="True"  GridLines="None"
                                DataKeyNames="BPT_ID" 
                                PageSize="10" 
                                EmptyDataText="无相关记录!"
                                onpageindexchanging="GridViewShowRejects_PageIndexChanging" 
                                onrowcancelingedit="GridViewShowRejects_RowCancelingEdit" 
                                onrowcommand="GridViewShowRejects_RowCommand" 
                                onrowediting="GridViewShowRejects_RowEditing" 
                                onrowupdating="GridViewShowRejects_RowUpdating" 
                                onrowdeleting="GridViewShowRejects_RowDeleting" ondatabound="GridViewShowRejects_DataBound" 
                          
                            
                            
                                >

                                <%--gridview的样式文件--%>
                                <RowStyle CssClass="GridViewRowStyle" />
                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                <HeaderStyle CssClass="GridViewHead" />

                                <Columns>
                                    <asp:BoundField DataField="BPT_ID" HeaderText="不良品类型ID" SortExpression="BPT_ID" Visible="false"/>
                                    <asp:BoundField DataField="PBC_ID" HeaderText="工序ID" Visible="false" />
                                    <asp:BoundField DataField="BPT_Name" HeaderText="不良品类型" />
                                    <%--<asp:BoundField DataField="BPT_BLevel" HeaderText="严重程度" />--%>
                                    <asp:TemplateField HeaderText ="严重程度">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("BPT_BLevel") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ASP_BPT_BLevel_DropDownList" runat="server" Width="60%" DataTextField="BPT_BLevel">
                                                <asp:ListItem> </asp:ListItem>
                                                <asp:ListItem>一般问题</asp:ListItem>
                                                <asp:ListItem>严重问题</asp:ListItem>
                                                <asp:ListItem>致命问题</asp:ListItem>
                                            </asp:DropDownList>
                                            
                                        </EditItemTemplate>

                                    </asp:TemplateField>
                                    <asp:CommandField ShowEditButton="True"  EditText="编辑" CancelText="取消" 
                                        InsertText="插入" UpdateText="更新"/>
                                
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                                CommandName="Delete" Text="删除" OnClientClick="return confirm('您确认删除该记录吗?')"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                           
                                <PagerTemplate><%--翻页和显示页码的部分--%>
                                    <div id="DIV_Pager" style="width:100%; ">
                                        <div id="DIV_PagerIndex" style="width:5%; margin-left:60%;float:left">
                                            第<asp:Label ID="ASP_Label_PageIndex" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>"/>页
                                        </div>
                                        <div id="DIV_PagerCount" style="width:5%; float:left">
                                            共<asp:Label ID="ASP_Label_PageCount" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageCount  %>" />页
                                        </div>
                                        <div id="DIV_Pager_Frist" style="width:5%; float:left">
                                            <asp:LinkButton ID="ASP_Label_PageFirst" runat="server" CausesValidation="False" CommandArgument="Rejects"
                                                CommandName="PageFirst" Text="首页" />
                                        </div>
                                        <div id="DIV_Pager_Prev" style="width:5%; float:left">
                                            <asp:LinkButton ID="ASP_Label_PagePrev" runat="server" CausesValidation="False" CommandArgument="Rejects"
                                                CommandName="PagePrev" Text="上一页" />
                                        </div>
                                        <div id="DIV_Pager_Next" style="width:5%; float:left">
                                            <asp:LinkButton ID="ASP_Label_PageNext" runat="server" CausesValidation="False" CommandArgument="Rejects"
                                                CommandName="PageNext" Text="下一页" />
                                        </div>
                                        <div id="DIV_Pager_Last" style="width:5%; float:left">
                                            <asp:LinkButton ID="ASP_Label_PageLast" runat="server" CausesValidation="False" CommandArgument="Rejects"
                                                CommandName="PageLast" Text="尾页" />
                                        </div>
                                        <div id="DIV_Goto_Apage" style="width:2%; float:left;">
                                            <asp:TextBox runat="server" Width="100%" ID="ASP_Pager_Text"></asp:TextBox>
                                        </div>
                                        <div id="DIV_JumpToPage" style="width:2%; float:left; margin-left:1%">
                                            <asp:LinkButton ID="ASP_Jump_blt" runat="server" CausesValidation="False" CommandArgument="Rejects"
                                                CommandName="PageJump" Text="GO" />
                                        </div>
                                    </div>
                                </PagerTemplate>
                                <PagerStyle  BorderWidth="1px"  HorizontalAlign="Center"
                                CssClass="GridViewPagerStyle" />
                            </asp:GridView>
                        </div>
                    </asp:Panel>
            </fieldset> 
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>

