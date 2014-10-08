using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class REPORT_cc_ProductSumPrint : System.Web.UI.Page
{
    private readonly SalesD sd = new SalesD();
    protected void Page_Load(object sender, EventArgs e)
    {
        Labelpeople.Text = Session["UserName"].ToString();
        Labeltime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        //下单时间
        if (Request.QueryString["start"] == null || Request.QueryString["start"] == "")
        {
            Labelstart.Text = "始";
        }
        else
        {
            Labelstart.Text = Request.QueryString["start"];
        }
        if (Request.QueryString["end"] == null || Request.QueryString["end"] == "")
        {
            Labelend.Text = "今";
        }
        else
        {
            Labelend.Text = Request.QueryString["end"];
        }
        
        //绑定
        DateTime start = Convert.ToDateTime(Request.QueryString["start"]);
        DateTime end = Convert.ToDateTime(Request.QueryString["end"]);

        Grid_Detail.DataSource = sd.S_ProductSum(start,end);
        Grid_Detail.DataBind();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/REPORT_cc/ProductSum.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        ExcelHelper.GridViewToExcel(Grid_Detail, "产品流量统计");
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
    }
}