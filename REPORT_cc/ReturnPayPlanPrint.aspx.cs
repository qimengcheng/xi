using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class PurchasingMgt_ReturnPayPlanPrint : System.Web.UI.Page
{
    ReturnPayPlanD rd = new ReturnPayPlanD();
    protected void Page_Load(object sender, EventArgs e)
    {
        Labelpeople.Text = Session["UserName"].ToString();
        Labeltime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        string condition = Request.QueryString["Getcondition()"];
        this.Gridview_OAInfo.DataSource = rd.SelectCusTotal(condition);
        this.Gridview_OAInfo.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/REPORT_cc/ReturnPayPlan.aspx");
    }
    protected void Button_Excel(object sender, EventArgs e)
    {
        ExcelHelper.GridViewToExcel(Gridview_OAInfo, "回款计划");
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
    protected void Gridview_OAInfo_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        string condition = Request.QueryString["Getcondition()"];
        DataSet ds = rd.SelectTotalReturnRate(condition);
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count > 0)
        {
            this.label_Num.Text = dt.Rows[0][0].ToString();
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[0].Text = "合计回款率";
            e.Row.Cells[12].Text = this.label_Num.Text.ToString();
        }
    }
}