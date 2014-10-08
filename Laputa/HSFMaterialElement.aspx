<%@ Page Title="" Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true" CodeFile="HSFMaterialElement.aspx.cs" Inherits="Laputa_HSFMaterialElement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript" language="javascript">
        //Author:Daviv
        //Blog:http://blog.163.com/jxdawei
        //Date:2006-10-28
        //Email:jxdawei@gmail.com
        function sAlert(str) {
            var msgw, msgh, bordercolor;
            msgw = 400;//提示窗口的宽度
            msgh = 100;//提示窗口的高度
            bordercolor = "#336699";//提示窗口的边框颜色
            titlecolor = "#99CCFF";//提示窗口的标题颜色

            var sWidth, sHeight;
            sWidth = document.body.offsetWidth;
            sHeight = document.body.offsetHeight;


            var bgObj = document.createElement("div");
            bgObj.setAttribute('id', 'bgDiv');
            bgObj.style.position = "absolute";
            bgObj.style.top = "0";
            bgObj.style.background = "#777";
            bgObj.style.filter = "progid:DXImageTransform.Microsoft.Alpha(style=3,opacity=25,finishOpacity=75";
            bgObj.style.opacity = "0.6";
            bgObj.style.left = "0";
            bgObj.style.width = sWidth + "px";
            bgObj.style.height = sHeight + "px";
            document.body.appendChild(bgObj);
            var msgObj = document.createElement("div");
            msgObj.setAttribute("id", "msgDiv");
            msgObj.setAttribute("align", "center");
            msgObj.style.position = "absolute";
            msgObj.style.background = "white";
            msgObj.style.font = "12px/1.6em Verdana, Geneva, Arial, Helvetica, sans-serif";
            msgObj.style.border = "1px solid " + bordercolor;
            msgObj.style.width = msgw + "px";
            msgObj.style.height = msgh + "px";
            msgObj.style.top = (document.documentElement.scrollTop + (sHeight - msgh) / 2) + "px";
            msgObj.style.left = (sWidth - msgw) / 2 + "px";
            var title = document.createElement("h4");
            title.setAttribute("id", "msgTitle");
            title.setAttribute("align", "right");
            title.style.margin = "0";
            title.style.padding = "3px";
            title.style.background = bordercolor;
            title.style.filter = "progid:DXImageTransform.Microsoft.Alpha(startX=20, startY=20, finishX=100, finishY=100,style=1,opacity=75,finishOpacity=100);";
            title.style.opacity = "0.75";
            title.style.border = "1px solid " + bordercolor;
            title.style.height = "18px";
            title.style.font = "12px Verdana, Geneva, Arial, Helvetica, sans-serif";
            title.style.color = "white";
            title.style.cursor = "pointer";
            title.innerHTML = "关闭";
            title.onclick = function () {
                document.body.removeChild(bgObj);
                document.getElementById("msgDiv").removeChild(title);
                document.body.removeChild(msgObj);
            }
            document.body.appendChild(msgObj);
            document.getElementById("msgDiv").appendChild(title);
            var txt = document.createElement("p");
            txt.style.margin = "1em 0";
            txt.setAttribute("id", "msgTxt");
            txt.innerHTML = str;
            document.getElementById("msgDiv").appendChild(txt);
        }
        </script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <fieldset>
                    <legend>有毒物质检索
                    </legend>
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 62px" >材料名称:</td>
                            <td style="width: 148px" >
                                <asp:TextBox ID="TextBox1" runat="server" Width="90%"></asp:TextBox>
                            </td>
                            <td style="text-align: right; width: 49px;" >供应商:</td>
                            <td style="width: 150px" >
                                <asp:TextBox ID="TextBox2" runat="server" Width="90%"></asp:TextBox>
                            </td>
                            <td style="width: 155px" >&nbsp;</td>
                            <td style="width: 204px" >
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 62px" >&nbsp;</td>
                            <td style="width: 148px">
                                <asp:Button ID="Search" runat="server" CssClass="Button02" Text="检索" Width="66px" OnClick="Search_Click" />
                            </td>
                            <td style="width: 49px" >
                                &nbsp;</td>
                            <td style="width: 150px">
                                <asp:Button ID="reset" runat="server" CssClass="Button02" OnClick="reset_Click" Text="重置" Width="66px" />
                            </td>
                            <td style="width: 155px" >
                                <asp:Button ID="AddMaterial" runat="server" CssClass="Button02" OnClick="AddMaterial_Click" Text="新增物料/成品" Width="95px" />
                            </td>
                            <td style="width: 204px">
                                <asp:Label ID="HSFID" runat="server" Text="HSFID" Visible="False"></asp:Label>
                            </td>
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
                    <legend>有毒物料表 </legend>
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
                            <asp:BoundField DataField="HSF_MaterialName" HeaderText="物料/成品名称" Visible="true" SortExpression="PMP_ID" />
                            <asp:BoundField DataField="HSF_Provider" HeaderText="供应商" Visible="true"  />
                            <asp:BoundField DataField="HSF_Texture" HeaderText="材质" Visible="true" />
                            <asp:BoundField DataField="HSF_Level" HeaderText="风险等级" Visible="true"  />
                            <asp:BoundField DataField="HSF_Note" HeaderText="备注" Visible="true"  />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Modify" runat="server" CommandArgument='<%# Eval("HSF_ID") %>' CommandName="Modify">编辑</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField>
                                <ItemTemplate>
                                    
                                    <asp:LinkButton ID="De" runat="server" CommandArgument='<%# Eval("HSF_ID") %>' CommandName="De" OnClientClick="var c='▁▂▃▄▅▆▇█▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉警告▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉▉█▇▆▅▄▃▂▁■■■■■■■该物料下的所有版本和报告也将一同删除!!!!!!!!!!!!!!!!■■■■■■■您确认删除该记录吗?';c.fontcolor='red';
                                        return confirm(c);" >删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Detail" runat="server" CommandArgument='<%# Eval("HSF_ID") %>' CommandName="Details">查看相关有毒物质</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="SetDetail" runat="server" CommandArgument='<%# Eval("HSF_ID") %>' CommandName="SetDetail">选择相关有毒物质</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="copy" runat="server" CommandArgument='<%# Eval("HSF_ID") %>' CommandName="copy">从其他物料复制项目</asp:LinkButton>
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
                    <legend>相关有毒
                        物质信息</legend><asp:Button ID="closedetail" runat="server" class="Button02" OnClick="closedetail_Click" Text="关闭" Width="66px" />
                    <asp:GridView ID="GridView2" runat="server" CssClass="GridViewStyle"  AllowPaging="True" AutoGenerateColumns="False"
                                  GridLines="None" EmptyDataText=" 没有相关记录 "  OnPageIndexChanging="GridView2_PageIndexChanging" EnableModelValidation="True" Height="16px" OnRowCommand="GridView2_RowCommand" OnRowDataBound="GridView2_RowDataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="HSFBasic_ID" HeaderText="HSFElementID" Visible="false"  />
                            <asp:BoundField DataField="HSFElement_Name" HeaderText="物质名称" Visible="true"  />
                            <asp:BoundField DataField="HSFElement_Standard" HeaderText="管控标准" Visible="true"  />
                            <asp:BoundField DataField="HSFElement_Object" HeaderText="管控范围" Visible="true"  />
                            <asp:BoundField DataField="HSFBasic_Man" HeaderText="录入人" Visible="true"  />
                            <asp:BoundField DataField="HSFBasic_Time" 
                               DataFormatString="{0:yyyy-MM-dd HH:mm}" HeaderText="录入时间" Visible="true"  />
                            <asp:BoundField DataField="HSFElement_Note" HeaderText="备注" Visible="true"  />


                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="del" runat="server" CommandArgument='<%# Eval("HSFBasic_ID") %>' CommandName="del">删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                           
                           
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第<asp:Label ID="lblPageIndex" runat="server" Text='<%# ((GridView) Container.Parent.Parent).PageIndex + 1 %>' />
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
        
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel4" runat="server" Visible="False">
                <fieldset>
                    <legend>
            
                        有毒物质检索
                    </legend>
                    <table style="width: 100%" >
                        <tr>
                            <td style="width: 69px" >物质名称：</td>
                            <td style="width: 112px" >
                                <asp:TextBox ID="TextBox3" runat="server" Width="100%"></asp:TextBox>
                            </td>
                            <td style="width: 112px">&nbsp;</td>
                            <td style="width: 156px" >
                                <asp:Button ID="SearchE" runat="server" CssClass="Button02" OnClick="SearchE_Click" Text="检索" Width="66px" />
                            </td>
                            <td style="width: 140px" >
                                &nbsp;</td>
                            <td >&nbsp;</td>
             
                        </tr>
                    </table>

                </fieldset>
                <fieldset>
                    <legend>选择相关有毒物质信息</legend>
                    <asp:GridView ID="GridView3" runat="server" CssClass="GridViewStyle"  AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="HSFElement_ID"
                                  GridLines="None" EmptyDataText=" 没有相关记录 "  OnPageIndexChanging="GridView3_PageIndexChanging" EnableModelValidation="True" Height="16px" OnRowDataBound="GridView3_RowDataBound">
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemStyle Width="5%" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="HSFElement_ID" HeaderText="HSFDetail_ID" Visible="false"  />
                            <asp:BoundField DataField="HSFElement_Name" HeaderText="物质名称" Visible="true"  />
                            <asp:BoundField DataField="HSFElement_Standard" HeaderText="管控标准" Visible="true"  />
                            <asp:BoundField DataField="HSFElement_Object" HeaderText="管控范围" Visible="true"  />
                            <asp:BoundField DataField="HSFElement_Man" HeaderText="录入人" Visible="true"  />
                            <asp:BoundField DataField="HSFElement_Time" DataFormatString="{0:yyyy-MM-dd HH:mm}" HeaderText="录入时间" Visible="true"  />
                            <asp:BoundField DataField="HSFElement_Note" HeaderText="备注" Visible="true"  />


                           
                        </Columns>
                        <PagerTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="text-align: right">
                                        第<asp:Label ID="lblPageIndex" runat="server" Text='<%# ((GridView) Container.Parent.Parent).PageIndex + 1 %>' />
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
        
                </fieldset>
                <table style="width: 100%">
                    <tr>
                        <td style="width: 254px">&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Button ID="SummitDetail" runat="server" class="Button02" OnClick="SummitDetail_Click" Text="提交" Width="59px" />
                        </td>
                        <td>
                            <asp:Button ID="closecopydetail" runat="server" class="Button02" OnClick="closecopydetail_Click" Text="关闭" Width="66px" />
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel5" runat="server" Visible="False">
                <fieldset>
                    <legend>
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                        物料</legend>
                    <table style="text-align: left; width: 100%;">
                        <tr>
                            <td style="width: 95px" >物料名称:</td>
                            <td style="width: 15%">
                                <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
                            </td>
                            <td style="width: 11px" >
                                <asp:Label ID="Label535" runat="server" ForeColor="red" Text="*"></asp:Label>
                            </td>
                            <td style="width: 67px">供应商：</td>
                            <td style="width: 128px">
                                <asp:TextBox ID="TextBox12" runat="server" Width="100%"></asp:TextBox>
                            </td>
                            <td style="width: 2%">
                                <asp:Label ID="Label536" runat="server" ForeColor="red" Text="*"></asp:Label>
                            </td>
                            <td style="width: 7%">材质：</td>
                            <td style="width: 149px" >
                                <asp:TextBox ID="TextBox13" runat="server" Width="90%"></asp:TextBox>
                            </td>
                            <td style="width: 3%">
                                <asp:Label ID="Label537" runat="server" ForeColor="red" Text="*"></asp:Label>
                            </td>
                            <td style="width: 15%">
                                <asp:Label ID="ElementID" runat="server" Text="ElelementID" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 95px">风险等级:</td>
                            <td colspan="7">
                                <asp:DropDownList ID="DropDownList1" runat="server">
                                    <asp:ListItem>未选择</asp:ListItem>
                                    <asp:ListItem>A</asp:ListItem>
                                    <asp:ListItem>B</asp:ListItem>
                                    <asp:ListItem>C</asp:ListItem>
                                    <asp:ListItem>D</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="width: 3%">
                                &nbsp;</td>
                            <td style="width: 15%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 95px" >备注:<br /> (不大于200个字)</td>
                            <td colspan="7">
                                <asp:TextBox ID="TextBox14" runat="server" Height="83px" Width="90%" TextMode="MultiLine"></asp:TextBox>
                            </td>
                            <td style="width: 3%">
                                &nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 95px" >&nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td style="width: 11px" >
                                &nbsp;</td>
                            <td style="width: 67px">
                                <asp:Button ID="Summit" runat="server" class="Button02" OnClick="Summit_Click" Text="提交" Width="59px" />
                            </td>
                            <td style="width: 128px">&nbsp;</td>
                            <td style="width: 2%">
                                &nbsp;</td>
                            <td style="width: 7%">&nbsp;</td>
                            <td style="width: 149px" >
                                <asp:Button ID="close" runat="server" class="Button02" OnClick="CloseAdd_Click" Text="关闭" Width="66px" />
                            </td>
                            <td style="width: 3%">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel6" runat="server"  Visible="False">
                <fieldset>
                    <legend>有毒物质检索
                    </legend>
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 62px" >材料名称:</td>
                            <td style="width: 148px" >
                                <asp:TextBox ID="TextBox4" runat="server" Width="90%"></asp:TextBox>
                            </td>
                            <td style="text-align: right; width: 49px;" >供应商:</td>
                            <td style="width: 150px" >
                                <asp:TextBox ID="TextBox5" runat="server" Width="90%"></asp:TextBox>
                            </td>
                            <td style="width: 155px" >&nbsp;</td>
                            <td style="width: 204px" >
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 62px" >&nbsp;</td>
                            <td style="width: 148px">
                                <asp:Button ID="Button1" runat="server" CssClass="Button02" Text="检索" Width="66px" OnClick="Search2_Click" />
                            </td>
                            <td style="width: 49px" >
                                &nbsp;</td>
                            <td style="width: 150px">
                                <asp:Button ID="reset2" runat="server" CssClass="Button02" OnClick="reset2_Click" Text="重置" Width="66px" />
                            </td>
                            <td style="width: 155px" >
                                <asp:Button ID="closecopy" runat="server" class="Button02" OnClick="CloseCopy_Click" Text="关闭" Width="66px" />
                            </td>
                            <td style="width: 204px">
                                &nbsp;</td>
                        </tr>
                    </table>

                </fieldset>
            </asp:Panel>

            <asp:Panel ID="Panel7" runat="server" Visible="False">
                <fieldset>
                    <legend>有毒物料表 </legend>
                    <asp:GridView ID="GridView4" runat="server" CssClass="GridViewStyle"  AllowPaging="True" PageSize="10" AutoGenerateColumns="False" 
                                  GridLines="None" EmptyDataText="没有相关记录" OnRowCommand="GridView4_RowCommand"
                                  DataKeyNames="HSF_ID"  OnPageIndexChanging="GridView4_PageIndexChanging" EnableModelValidation="True" >
                        <RowStyle CssClass="GridViewRowStyle" />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                        <HeaderStyle CssClass="GridViewHead" />
                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <Columns>
                            <asp:BoundField DataField="HSF_ID" HeaderText="HSFID" Visible="false" SortExpression="SMSMPM_ID" />
                            <asp:BoundField DataField="HSF_MaterialName" HeaderText="材料/成品名称" Visible="true" SortExpression="PMP_ID" />
                            <asp:BoundField DataField="HSF_Provider" HeaderText="供应商" Visible="true"  />
                            <asp:BoundField DataField="HSF_Texture" HeaderText="材质" Visible="true" />
                            <asp:BoundField DataField="HSF_Level" HeaderText="风险等级" Visible="true"  />
                            <asp:BoundField DataField="HSF_Note" HeaderText="备注" Visible="true"  />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="Choose" runat="server" CommandArgument='<%# Eval("HSF_ID") %>' CommandName="Choose">选择</asp:LinkButton>
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
</asp:Content>