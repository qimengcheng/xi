using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PurchasingMgt_OfficeAppliancePrint : Page
{
    OfficeAppianceD od = new OfficeAppianceD();
    protected void Page_Load(object sender, EventArgs e)
    {
        Labelpeople.Text = Session["UserName"].ToString();
        Labeltime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        if (Request.QueryString["PMPAM_ApplyTime1"] == null || Request.QueryString["PMPAM_ApplyTime1"] == "")
        {
            Labelstart.Text = "始";
        }
        else
        {
            Labelstart.Text = Request.QueryString["PMPAM_ApplyTime1"];
        }
        if (Request.QueryString["PMPAM_ApplyTime2"] == null || Request.QueryString["PMPAM_ApplyTime2"] == "")
        {
            Labelend.Text = "今";
        }
        else
        {
            Labelend.Text = Request.QueryString["PMPAM_ApplyTime2"];
        }
        string PMPAM_ApplyTime1 = Request.QueryString["PMPAM_ApplyTime1"];
        string PMPAM_ApplyTime2 = Request.QueryString["PMPAM_ApplyTime2"];
        string condition = "";
        if (PMPAM_ApplyTime1 != "" && PMPAM_ApplyTime2 == "")
        {
            condition += "and PMPAM_ApplyTime >='" + PMPAM_ApplyTime1 + "'";
        }
        if (PMPAM_ApplyTime1 == "" && PMPAM_ApplyTime2 != "")
        {
            condition += "and PMPAM_ApplyTime <='" + PMPAM_ApplyTime2 + "'";
        }
        if (PMPAM_ApplyTime1 != "" && PMPAM_ApplyTime2 != "")
        {
            condition += "and PMPAM_ApplyTime >='" + PMPAM_ApplyTime1 + "'" + "and PMPAM_ApplyTime <='" + PMPAM_ApplyTime2 + "'";
        }
        Gridview_OAInfo.DataSource = od.SelectOfficeAppliance(condition);
        Gridview_OAInfo.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/REPORT_cc/OfficeAppliance.aspx");
    }
    protected void Button_Excel(object sender, EventArgs e)
    {
        ExcelHelper.GridViewToExcel(Gridview_OAInfo, "办公用品申请汇总");
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        // Confirms that an HtmlForm control is rendered for
    }
  
    protected void Gridview_OAInfo_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        string PMPAM_ApplyTime1 = Request.QueryString["PMPAM_ApplyTime1"];
        string PMPAM_ApplyTime2 = Request.QueryString["PMPAM_ApplyTime2"];
        string condition = "";
        if (PMPAM_ApplyTime1 != "" && PMPAM_ApplyTime2 == "")
        {
            condition += "and PMPAM_ApplyTime >='" + PMPAM_ApplyTime1 + "'";
        }
        if (PMPAM_ApplyTime1 == "" && PMPAM_ApplyTime2 != "")
        {
            condition += "and PMPAM_ApplyTime <='" + PMPAM_ApplyTime2 + "'";
        }
        if (PMPAM_ApplyTime1 != "" && PMPAM_ApplyTime2!= "")
        {
            condition += "and PMPAM_ApplyTime >='" + PMPAM_ApplyTime1 + "'" + "and PMPAM_ApplyTime <='" + PMPAM_ApplyTime2+ "'";
        }
        DataSet ds = od.SelectOfficeAppliance_Sum(condition);
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count > 0)
        {
            label_Num.Text = dt.Rows[0][0].ToString();
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[0].Text = "合计数量";
            e.Row.Cells[5].Text = label_Num.Text.ToString();
        }
    }
}