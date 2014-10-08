<%@ Page Language="C#" MasterPageFile="~/Other/MasterPage.master" AutoEventWireup="true" CodeFile="UMChangePassword.aspx.cs" Inherits="UserMgt_UMChangePassword" Title="修改密码" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style  type="text/css">
        .textcss
        {
        	color:#F9F900;
        	background-image: url("../images/bar.jpg");
        	padding-left:5px;
        	padding-top:5px;
        	width:120px;
        	height:20px;
        	text-align:center;
        	table-layout:fixed;    	
        	} 
        
    </style>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <fieldset><legend>修改密码</legend><table style="width:100%;" class="STYLE2">
         <tr>
            <td style=" width:25%; text-align: right">
                <asp:Label ID="Label1" runat="server" Text="输入旧密码" ></asp:Label>
            </td>
            <td colspan="2">
                <asp:TextBox ID="TextBox1" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="必须填写旧密码" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                <asp:Label ID="Label2" runat="server" Text="输入新密码" ForeColor="Black"></asp:Label>
            </td>
            <td style=" width:30%;">
                <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ErrorMessage="必须填写新密码" ControlToValidate="TextBox2"></asp:RequiredFieldValidator>
                
            </td>
            <td >
           
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                <asp:Label ID="Label3" runat="server" Text="确认新密码" ForeColor="Black"></asp:Label>
            </td>
            <td colspan="2">
                <asp:TextBox ID="TextBox3" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ErrorMessage="必须确认新密码"  ControlToValidate="TextBox3"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ErrorMessage="确认新密码与新密码项必须匹配" ControlToCompare="TextBox2" 
                    ControlToValidate="TextBox3"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; height: 28px;">
                </td>
            <td style="height: 28px" colspan="2">
                <asp:Label ID="Label4" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style=" width:20%; text-align: right; height: 28px;">
                <asp:Button ID="Button1" runat="server" Text="修改密码" onclick="Button1_Click" CssClass="Button02" Width="70px"/>
            </td>
            <td style="height: 28px" colspan="2">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button2" runat="server" Text="取消" onclick="Button2_Click" 
                    Width="70px" CausesValidation="False" CssClass="Button02" />
            </td>
        </tr></fieldset>
    </table>
</fieldset></ContentTemplate></asp:UpdatePanel>
</asp:Content>

