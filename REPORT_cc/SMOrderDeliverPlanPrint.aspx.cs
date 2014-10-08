using System;
using System.Web.UI;

public partial class REPORT_cc_SparePrint : Page
{
    SMOrderDeliverPlanL dp = new SMOrderDeliverPlanL();
    protected void Page_Load(object sender, EventArgs e)
    {
        Labelpeople.Text = Session["UserName"].ToString();
        Labeltime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        if (Request.QueryString["startime"] == null || Request.QueryString["startime"] == "")
        {
            Labelstart.Text = "始";
        }
        else
        {
            Labelstart.Text = Request.QueryString["startime"];
        }
        if (Request.QueryString["endtime"] == null || Request.QueryString["endtime"] == "")
        {
            Labelend.Text = "今";
        }
        else
        {
            Labelend.Text = Request.QueryString["endtime"];
        }
        //绑定

        string startime = Request.QueryString["startime"];
        string endtime = Request.QueryString["endtime"];
        string print = Request.QueryString["print"];
        if (print == "printY")
        {
            GridView_OrderDeliverPlan.Columns[11].Visible = true;

        }
        else
        {
            GridView_OrderDeliverPlan.Columns[11].Visible = false;
        }
        Labelstart.Text = startime;
        Labelend.Text = endtime;
        GridView_OrderDeliverPlan.DataSource = dp.Select_DeliverPlan("and a.SMDP_Time between '"+startime+"' and '"+endtime+"'");
        GridView_OrderDeliverPlan.DataBind();
    }

 
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/REPORT_cc/SMOrderDeliverPlan.aspx");
    }
    protected void ExcelOutput(object sender, EventArgs e)
    {
        GridView_OrderDeliverPlan.AllowPaging=false;
       GridView_OrderDeliverPlan.DataBind();
       ExcelHelper.GridViewToExcel(GridView_OrderDeliverPlan, "1");
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
}