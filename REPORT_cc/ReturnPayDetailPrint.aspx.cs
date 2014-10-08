using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class PurchasingMgt_ReturnPayDetailPrint : System.Web.UI.Page
{
    ReturnPayDetailD rd = new ReturnPayDetailD();
    protected void Page_Load(object sender, EventArgs e)
    {
        Labelpeople.Text = Session["UserName"].ToString();
        Labeltime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        if (Request.QueryString["Time1"] == null || Request.QueryString["Time1"] == "")
        {
            Labelstart.Text = "始";
        }
        else
        {
            Labelstart.Text = Request.QueryString["Time1"];
        }
        if (Request.QueryString["Time2"] == null || Request.QueryString["Time2"] == "")
        {
            Labelend.Text = "今";
        }
        else
        {
            Labelend.Text = Request.QueryString["Time2"];
        }
        string condition = Request.QueryString["Getcondition()"];
        this.Gridview_OAInfo.DataSource = rd.SelectReturnPayDetail(condition);
        this.Gridview_OAInfo.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/REPORT_cc/ReturnPayDetail.aspx");
    }
    protected void Button_Excel(object sender, EventArgs e)
    {
        ExcelHelper.GridViewToExcel(Gridview_OAInfo, "回款明细表");
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
    protected void Gridview_OAInfo_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        string condition = Request.QueryString["Getcondition()"];
        DataSet ds = rd.SelectReturnPayDetail_Total(condition);
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count > 0)
        {
            this.label_Num.Text = dt.Rows[0][0].ToString();
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[0].Text = "合计金额";
            e.Row.Cells[5].Text = this.label_Num.Text.ToString();
        }
    }
}