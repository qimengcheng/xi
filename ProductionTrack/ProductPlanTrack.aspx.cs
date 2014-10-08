using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Laputa_ProductPlanTrack : System.Web.UI.Page
{
    private ProductPlanTrack pt = new ProductPlanTrack();
 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Title = "生产计划跟踪";
            if (!Session["UserRole"].ToString().Contains("生产计划跟踪"))
            {
             Response.Redirect("~/Default.aspx");
            }
            GridView1.DataSource = pt.SearchProductWeek(Convert.ToDateTime("1/1/1753 12:00:00 AM"), Convert.ToDateTime("12/31/9999 11:59:59 PM"));
            GridView1.DataBind();
            UpdatePanel2.Update();
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel5.Visible = false;
            UpdatePanel3.Update();
            UpdatePanel4.Update();
            UpdatePanel5.Update();

        }
    }
    
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Details")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Panel3.Visible = true;
            Panel4.Visible = true;

            Panel5.Visible = true;
            GridView2.DataSource = pt.SearchProductMain(new Guid(e.CommandArgument.ToString()));
            GridView2.DataBind();
            UpdatePanel3.Update();
            GridView3.DataSource = pt.SearchProduct(new Guid(e.CommandArgument.ToString()));
            GridView3.DataBind();
            UpdatePanel4.Update();
            GridView4.DataSource = pt.SearchProductSeries(new Guid(e.CommandArgument.ToString()));
            GridView4.DataBind();
            UpdatePanel5.Update();
           


        }
    }
 
    protected void MainSearch_Click(object sender, EventArgs e)
    {
        DateTime sTime = TextBox1.Text == ""
            ? Convert.ToDateTime("1/1/1753 12:00:00 AM")
            : Convert.ToDateTime(TextBox1.Text);
        DateTime eTime = TextBox1.Text == ""
            ? Convert.ToDateTime("12/31/9999 11:59:59 PM")
            : Convert.ToDateTime(TextBox1.Text);
        GridView1.DataSource = pt.SearchProductWeek(sTime, eTime);
        GridView1.DataBind();
        Panel3.Visible = false;
        Panel4.Visible = false;
        Panel5.Visible = false;
        UpdatePanel2.Update();
        UpdatePanel3.Update();
        UpdatePanel4.Update();
        UpdatePanel5.Update();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView1.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox");   // refer to the TextBox with the NewPageIndex value
            }

            if (null != txtNewPageIndex && txtNewPageIndex.Text != "")
            {
                newPageIndex = int.Parse(txtNewPageIndex.Text) - 1; // get the NewPageIndex
            }
        }
        else
        {
            newPageIndex = e.NewPageIndex;
        }
        GridView1.DataSource = pt.SearchProductWeek(Convert.ToDateTime(TextBox1.Text), Convert.ToDateTime(TextBox2.Text));
        GridView1.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView1.PageCount ? GridView1.PageCount - 1 : newPageIndex;
        GridView1.PageIndex = newPageIndex;
        GridView1.DataBind();
    }
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView2.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox");   // refer to the TextBox with the NewPageIndex value
            }

            if (null != txtNewPageIndex && txtNewPageIndex.Text != "")
            {
                newPageIndex = int.Parse(txtNewPageIndex.Text) - 1; // get the NewPageIndex
            }
        }
        else
        {
            newPageIndex = e.NewPageIndex;
        }
        GridView2.DataSource = pt.SearchProductWeek(Convert.ToDateTime(TextBox1.Text), Convert.ToDateTime(TextBox2.Text));
        GridView2.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView2.PageCount ? GridView2.PageCount - 1 : newPageIndex;
        GridView2.PageIndex = newPageIndex;
        GridView2.DataBind();
    }
    protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView3.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox");   // refer to the TextBox with the NewPageIndex value
            }

            if (null != txtNewPageIndex && txtNewPageIndex.Text != "")
            {
                newPageIndex = int.Parse(txtNewPageIndex.Text) - 1; // get the NewPageIndex
            }
        }
        else
        {
            newPageIndex = e.NewPageIndex;
        }
        GridView3.DataSource = pt.SearchProductWeek(Convert.ToDateTime(TextBox1.Text), Convert.ToDateTime(TextBox2.Text));
        GridView3.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView3.PageCount ? GridView3.PageCount - 1 : newPageIndex;
        GridView3.PageIndex = newPageIndex;
        GridView3.DataBind();
    }
    protected void GridView4_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView4.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox");   // refer to the TextBox with the NewPageIndex value
            }

            if (null != txtNewPageIndex && txtNewPageIndex.Text != "")
            {
                newPageIndex = int.Parse(txtNewPageIndex.Text) - 1; // get the NewPageIndex
            }
        }
        else
        {
            newPageIndex = e.NewPageIndex;
        }
        GridView4.DataSource = pt.SearchProductWeek(Convert.ToDateTime(TextBox1.Text), Convert.ToDateTime(TextBox2.Text));
        GridView4.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView4.PageCount ? GridView4.PageCount - 1 : newPageIndex;
        GridView4.PageIndex = newPageIndex;
        GridView4.DataBind();
    }
}