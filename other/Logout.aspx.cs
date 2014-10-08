using System;
using System.Web;
using System.Web.UI;

public partial class Other_Logout : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie c = Request.Cookies[".ASPXAUTH"];
        //HttpCookie userName = Request.Cookies["UserName"];
        //HttpCookie userId = Request.Cookies["UserId"];
        //HttpCookie userRole = Request.Cookies["UserRole"];
        //HttpCookie userOrganization = Request.Cookies["UserOrganization"];
        Session.Remove("UserName");
        Session.Remove("UserId");
        Session.Remove("UserRole");
        Session.Remove("UserOrganization");
        Session.Remove("UA_Security");
        Session.Remove("UA_Upload");
        Session.Remove("UA_Approve");
        Session.Remove("UA_UploadArch");
        Session.Remove("UA_ApproveArch");
        Session.Remove("UA_SparePartsPermission");

        Session["UserName"] = "";
        Session["UserId"] = "";
        Session["UserRole"] = "";

        Session.Abandon();


        Session["UserName"] = null;
        Session["UserId"] = null;
        Session["UserRole"] = null;
        Session["UserOrganization"] = null;

        if (c != null)
        {
            c.Expires = DateTime.Now.AddDays(-1);
            //Response.Cookies.Add(c);
        }
        //if (userName != null)
        //{
        //    userName.Expires = DateTime.Now.AddDays(-1);
        //    Response.Cookies.Add(userName);
        //}
        //if (userId != null)
        //{
        //    userId.Expires = DateTime.Now.AddDays(-1);
        //    Response.Cookies.Add(userId);
        //}
        //if (userRole != null)
        //{
        //    userRole.Expires = DateTime.Now.AddDays(-1);
        //    Response.Cookies.Add(userRole);
        //}
        //if (userOrganization != null)
        //{
        //    userOrganization.Expires = DateTime.Now.AddDays(-1);
        //    Response.Cookies.Add(userOrganization);
        //}

        Response.Redirect("~/Default.aspx");

    }
}
