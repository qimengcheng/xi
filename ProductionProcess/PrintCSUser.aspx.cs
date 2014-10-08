using System;
using System.Web.UI;

public partial class ProductionProcess_PrintCSUser : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


            if (Request.QueryString["name1"] == null)
            {
                Name1.Text = "";
            }
            else
            {
                Name1.Text =  Request.QueryString["name1"] ; 
            }

            if (Request.QueryString["no1"] == null)
            {
                num1.Text = "";
            }
            else
            {
                num1.Text = "*" + Request.QueryString["no1"] + "*";
            }
            //

            if (Request.QueryString["name2"] == null)
            {
                Name2.Text = "";
            }
            else
            {
                Name2.Text =  Request.QueryString["name2"];
            }
           
            if (Request.QueryString["no2"] == null)
            {
                num2.Text = "";
            }
            else
            {
                num2.Text = "*" + Request.QueryString["no2"] + "*";
            }
            //

            if (Request.QueryString["name3"] == null)
            {
                Name3.Text = "";
            }
            else
            {
                Name3.Text = Request.QueryString["name3"];
            }

            if (Request.QueryString["no3"] == null)
            {
                num3.Text = "";
            }
            else
            {
                num3.Text = "*" + Request.QueryString["no3"] + "*";
            }
            //

            if (Request.QueryString["name4"] == null)
            {
                Name4.Text = "";
            }
            else
            {
                Name4.Text = Request.QueryString["name4"];
            }

            if (Request.QueryString["no4"] == null)
            {
                num4.Text = "";
            }
            else
            {
                num4.Text = "*" + Request.QueryString["no4"] + "*";
            }

            //
            if (Request.QueryString["name5"] == null)
            {
                Name5.Text = "";
            }
            else
            {
                Name5.Text = Request.QueryString["name5"] ;
            }

            if (Request.QueryString["no5"] == null)
            {
                num5.Text = "";
            }
            else
            {
                num5.Text = "*" + Request.QueryString["no5"] + "*";
            }
            //
            if (Request.QueryString["name6"] == null)
            {
                Name6.Text = "";
            }
            else
            {
                Name6.Text = Request.QueryString["name6"];
            }

            if (Request.QueryString["no6"] == null)
            {
                num6.Text = "";
            }
            else
            {
                num6.Text = "*" + Request.QueryString["no6"] + "*";
            }
            //
            if (Request.QueryString["name7"] == null)
            {
                Name7.Text = "";
            }
            else
            {
                Name7.Text = Request.QueryString["name7"];
            }

            if (Request.QueryString["no7"] == null)
            {
                num7.Text = "";
            }
            else
            {
                num7.Text = "*" + Request.QueryString["no7"] + "*";
            }
            //
            if (Request.QueryString["name8"] == null)
            {
                Name8.Text = "";
            }
            else
            {
                Name8.Text = Request.QueryString["name8"];
            }

            if (Request.QueryString["no8"] == null)
            {
                num8.Text = "";
            }
            else
            {
                num8.Text = "*" + Request.QueryString["no8"] + "*";
            }
            //
            if (Request.QueryString["name9"] == null)
            {
                Name9.Text = "";
            }
            else
            {
                Name9.Text = Request.QueryString["name9"];
            }

            if (Request.QueryString["no9"] == null)
            {
                num9.Text = "";
            }
            else
            {
                num9.Text = "*" + Request.QueryString["no9"] + "*";
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
       
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ProductionProcess/CSUser.aspx?state=manage");
    }
}