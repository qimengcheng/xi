using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class REPORT_cc_SalesPerformancePrint : System.Web.UI.Page
{
    private readonly SalesD sd = new SalesD();
    protected void Page_Load(object sender, EventArgs e)
    {
        Labelpeople.Text = Session["UserName"].ToString();
        Labeltime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        Labelstart.Text = Request.QueryString["liebie"];
       
        //绑定
        string no = Convert.ToString(Request.QueryString["no"]);
        string condition = Convert.ToString(Request.QueryString["condition"]);

        if (no == "1")
        {
            Grid_Detail.Columns[1].Visible = true;
            Grid_Detail.Columns[2].Visible = false;
            Grid_Detail.Columns[3].Visible = false;
            Grid_Detail.DataSource = sd.S_SalesPerformance(no, "and CRMRBI_Name like '%" + condition.ToString() + "%'");
            Grid_Detail.DataBind();
        }
        if (no == "2")
        {
            Grid_Detail.Columns[1].Visible = false;
            Grid_Detail.Columns[2].Visible = true;
            Grid_Detail.Columns[3].Visible = false;
            Grid_Detail.DataSource = sd.S_SalesPerformance(no, "and CRMCIF_Name like '%" + condition.ToString() + "%'");
            Grid_Detail.DataBind();
        }
        if (no == "3")
        {
            Grid_Detail.Columns[1].Visible = false;
            Grid_Detail.Columns[2].Visible = false;
            Grid_Detail.Columns[3].Visible = true;
            Grid_Detail.DataSource = sd.S_SalesPerformance(no, "and CRMCIF_SalesMan like '%" + condition.ToString() + "%'");
            Grid_Detail.DataBind();
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/REPORT_cc/SalesPerformance.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        ExcelHelper.GridViewToExcel(Grid_Detail, "销售业绩一览表");
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
    }
}