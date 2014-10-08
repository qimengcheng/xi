using System;
using System.Web.UI;

public partial class REPORT_cc_MCAPrint : Page
{
    MCAD mc = new MCAD();
    protected void Page_Load(object sender, EventArgs e)
    {
        Labelpeople.Text = Session["UserName"].ToString();
        Labeltime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
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

        string condition = Request.QueryString["condition"];
        GridView_OrderDeliverPlan.DataSource = mc.Select_MCA(condition);
        GridView_OrderDeliverPlan.DataBind();
       
    }

 
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/SalesMgt/MCA.aspx");
    }
    protected void ExcelOutput(object sender, EventArgs e)
    {
        GridView_OrderDeliverPlan.AllowPaging=false;
       GridView_OrderDeliverPlan.DataBind();
       ExcelHelper.GridViewToExcel(GridView_OrderDeliverPlan, "机械维护加工申请统计表");
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
}