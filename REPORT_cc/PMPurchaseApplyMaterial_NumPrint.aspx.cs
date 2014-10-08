using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PurchasingMgt_PMPurchaseApplyMaterial_NumPrint : Page
{
    private PMPurchaseApplyMaterial_DepartmentD pd = new PMPurchaseApplyMaterial_DepartmentD();
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
        string IMMBD_MaterialName = Request.QueryString["IMMBD_MaterialName"];
        string PMPAM_ApplyTime1 = Request.QueryString["PMPAM_ApplyTime1"];
        string PMPAM_ApplyTime2 = Request.QueryString["PMPAM_ApplyTime2"];
        string IMMBD_SpecificationModel = Request.QueryString["IMMBD_SpecificationModel"];
        string IMMT_MaterialType = Request.QueryString["IMMT_MaterialType"];
        string PMPAM_Department = Request.QueryString["PMPAM_Department"];
        string condition = "";
        if (IMMBD_MaterialName != "")
        {
            condition += "and IMMaterialBasicData.IMMBD_MaterialName like'%" + IMMBD_MaterialName + "%'";
        }
        if (PMPAM_ApplyTime1 != "")
        {
            if (PMPAM_ApplyTime2 != "")
            {
                condition += "and PMPAM_ApplyTime >='" + Convert.ToDateTime(PMPAM_ApplyTime1) + "'" + "and PMPAM_ApplyTime<='" + Convert.ToDateTime(PMPAM_ApplyTime2) + "'";
            }
            else
            {
                condition += "and PMPAM_ApplyTime >='" + Convert.ToDateTime(PMPAM_ApplyTime1) + "'";
            }
        }

        if (IMMBD_SpecificationModel != "")
        {
            condition += "and IMMaterialBasicData.IMMBD_SpecificationModel='" + IMMBD_SpecificationModel + "'";
        }
        if (PMPAM_Department != "" && PMPAM_Department != null)
        {
            condition += "and PMPAM_Department='" + PMPAM_Department + "'";
        }
        if (IMMT_MaterialType != "")
        {
            condition += "and (" + IMMT_MaterialType + ")";
        }
        Gridview_OAInfo.DataSource = pd.SelectPMPurchaseApplyMaterial_Department(condition);
        Gridview_OAInfo.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/REPORT_cc/PMPurchaseApplyMaterial_Num.aspx");
    }
    protected void Button_Excel(object sender, EventArgs e)
    {
        ExcelHelper.GridViewToExcel(Gridview_OAInfo, "采购申请物料数量汇总");
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        // Confirms that an HtmlForm control is rendered for
    }

    protected void Gridview_OAInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string IMMBD_MaterialName = Request.QueryString["IMMBD_MaterialName"];
        string PMPAM_ApplyTime1 = Request.QueryString["PMPAM_ApplyTime1"];
        string PMPAM_ApplyTime2 = Request.QueryString["PMPAM_ApplyTime2"];
        string IMMBD_SpecificationModel = Request.QueryString["IMMBD_SpecificationModel"];
        string IMMT_MaterialType = Request.QueryString["IMMT_MaterialTypee"];
        string PMPAM_Department = Request.QueryString["PMPAM_Department"];
        string condition = "";
        if (IMMBD_MaterialName != "")
        {
            condition += "and IMMBD_MaterialName like'%" + IMMBD_MaterialName + "%'";
        }
        if (PMPAM_ApplyTime1 != "")
        {
            if (PMPAM_ApplyTime2 != "")
            {
                condition += "and PMPAM_ApplyTime >='" + Convert.ToDateTime(PMPAM_ApplyTime1) + "'" + "and PMPAM_ApplyTime<='" + Convert.ToDateTime(PMPAM_ApplyTime2) + "'";
            }
            else
            {
                condition += "and PMPAM_ApplyTime >='" + Convert.ToDateTime(PMPAM_ApplyTime1) + "'";
            }
        }

        if (IMMBD_SpecificationModel != "")
        {
            condition += "and IMMBD_SpecificationModel='" + IMMBD_SpecificationModel + "'";
        }
        if (PMPAM_Department != "" && PMPAM_Department != null)
        {
            condition += "and PMPAM_Department='" + PMPAM_Department + "'";
        }
        if (IMMT_MaterialType != "")
        {
            condition += "and (" + IMMT_MaterialType + ")";
        }
        DataSet ds = pd.SelectPMPurchaseApplyMaterial_Department_Sum(condition);
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count > 0)
        { 
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[0].Text = "合计数量";
            
                e.Row.Cells[6].Text = dt.Rows[0][0].ToString();
                e.Row.Cells[7].Text = dt.Rows[0][1].ToString();
         
        }
    }
    }
}