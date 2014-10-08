using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Laputa_PurchaseReportPrint : System.Web.UI.Page
{
    private readonly LaputaPrintPoolD lpp = new LaputaPrintPoolD();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int maxyear = DateTime.Now.Year;
            for (int i = 2013; i <= maxyear; i++)
            {
                DropDownList1.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            if (Request.QueryString["year"] == null || Request.QueryString["month"] == null )
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof (Page), "alert", "alert('数据获取异常');", true);
            }
            else
            {


                Label6.Text = Request.QueryString["year"]=="999"?"所有":Request.QueryString["year"];
                Label7.Text = Request.QueryString["month"]=="999"?"所有":Request.QueryString["month"];
                DropDownList1.SelectedValue = Request.QueryString["year"];
                DropDownList2.SelectedValue = Request.QueryString["month"];
                SearchInStoreMain(sender, e);
                try
                {
                    Label4.Text = Session["UserName"].ToString();
                }
                catch
                {
                    Response.Redirect("~/Default.aspx");
                }
                Label5.Text = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            }

        }
    }

    protected void Button37_Click(object sender, EventArgs e)
    {
        GridView1.DataSource = lpp.Query_Material(TextBox21.Text, TextBox22.Text);
        GridView1.DataBind();
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Choose")
        {
            var row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;

            var id = new Guid(e.CommandArgument.ToString());
          
            Panel2.Visible = false;
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        var theGrid = sender as GridView; // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView1.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox");
                // refer to the TextBox with the NewPageIndex value
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
        Bindgrid1();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView1.PageCount ? GridView1.PageCount - 1 : newPageIndex;
        GridView1.PageIndex = newPageIndex;
        GridView1.DataBind();
    }

    protected void SearchInStoreMain(object sender, EventArgs e)
    {
   
        GridView2.DataSource = lpp.PurchaseInfo(Convert.ToInt32(DropDownList1.SelectedValue), Convert.ToInt32(DropDownList2.SelectedValue));
        GridView2.DataBind();
        Panel3.Visible = true;
    }

    private void Bindgrid2()
    {
        GridView2.DataSource = lpp.PurchaseInfo(Convert.ToInt32(DropDownList1.SelectedValue), Convert.ToInt32(DropDownList2.SelectedValue));
        GridView2.DataBind();

    }

    private void Bindgrid1()
    {
        GridView1.DataSource = lpp.Query_Material(TextBox21.Text, TextBox22.Text);
        GridView1.DataBind();
        GridView1.DataBind();
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        var theGrid = sender as GridView; // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView2.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox");
                // refer to the TextBox with the NewPageIndex value
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
        Bindgrid2();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView2.PageCount ? GridView2.PageCount - 1 : newPageIndex;
        GridView2.PageIndex = newPageIndex;
        GridView2.DataBind();
    }

    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void Reset_Click(object sender, EventArgs e)
    {
      

    }

    public override void VerifyRenderingInServerForm(Control control)
    {
    }


    protected void ChooseMaterial_Click(object sender, EventArgs e)
    {
        Panel2.Visible = true;
        GridView1.DataSource = lpp.Query_Material(TextBox21.Text, TextBox22.Text);
        GridView1.DataBind();
    }

    protected void print(object sender, EventArgs e)
    {
     
     
    }

    protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        var theGrid = sender as GridView; // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = theGrid.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox");
                // refer to the TextBox with the NewPageIndex value
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
      
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= theGrid.PageCount ? theGrid.PageCount - 1 : newPageIndex;
        theGrid.PageIndex = newPageIndex;
        theGrid.DataBind();
    }

   

    protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        
    }

    protected void back_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/report_cc/PurchaseReport.aspx");
    }

    protected void ToExcel_Click(object sender, EventArgs e)
    {
        SearchInStoreMain(sender, e);
        GridView2.AllowPaging = false;
        Bindgrid2();
        ExcelHelper.GridViewToExcel(GridView2,  (Request.QueryString["year"]=="999"?"所有":Request.QueryString["year"]) + "年" +  (Request.QueryString["month"]=="999"?"所有":Request.QueryString["month"]) + "月采购金额统计报表");
    }
}