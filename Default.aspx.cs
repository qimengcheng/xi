using System;
using System.Web.Security;
using System.Web.UI;
using System.Collections.Generic;

public partial class Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {



        //if (Request.QueryString["load"] == "reload")
        //{
        //    Response.Write("<script>alert('Session已过期,请重新登陆！')</script>");
        //}
        Title = "希尔电子ERP系统";
        //  Response.Write("<script>alert('工号或密码错误！')</script>");

        TxtUserID.Attributes.Add("OnFocus", "javascript:onFocusFun(this,'用户名')");
        TxtUserID.Attributes.Add("OnBlur", "javascript:onblurFun(this,'用户名')");
        TxtUserPassword.Attributes.Add("OnFocus", "javascript:passwordOnFocus(this,'密码')");
        TxtUserPassword.Attributes.Add("OnBlur", "javascript:onFocusFun(this,'密码')");

    }



    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        User us = new User();
        string password = FormsAuthentication.HashPasswordForStoringInConfigFile(TxtUserPassword.Text, "SHA1");
        IList<UMUserInfoInfo> IUmuiInfo = us.Select_UMUserInfo("and UMUI_UserID='" + TxtUserID.Text + "' and UMUI_Password='" + password + "'");
        if (IUmuiInfo.Count > 0)
        {
            Session["UserId"] = IUmuiInfo[0].UMUI_UserID;
            Session["UserName"] = IUmuiInfo[0].UMUI_UserName;
            Session["UserRole"] = IUmuiInfo[0].UMUI_UserRole;
            Session["Organization"] = IUmuiInfo[0].BDOS_Code;
            Session["Department"] = IUmuiInfo[0].BDOS_Name;     
            FormsAuthentication.SetAuthCookie(Session["UserId"].ToString(), false);
            Response.Redirect("~/Other/WelcomePage.aspx");
            Session.Timeout = 30;
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(TxtUserID, GetType(), "1", "alert('in');alert('123');", false);
            Response.Write("用户名或密码错误！");
            Response.Redirect("~/Default.aspx");
        }



    }



}
    
