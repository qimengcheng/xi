using System;
using System.Web.UI;

public partial class PurchasingMgt_PMPurchaseApplyMaterial_DepartmentPrint : Page
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
        string IMMBD_MaterialName=Request.QueryString["IMMBD_MaterialName"];
        string PMPAM_ApplyTime1=Request.QueryString["PMPAM_ApplyTime1"];
        string PMPAM_ApplyTime2=Request.QueryString["PMPAM_ApplyTime2"];
        string IMMBD_SpecificationModel=Request.QueryString["IMMBD_SpecificationModel"];    
        string IMMT_MaterialType=Request.QueryString["IMMT_MaterialType"];    
    
        string condition = "";
        if (IMMBD_MaterialName!= "")
        {
            condition += "and IMMaterialBasicData.IMMBD_MaterialName like'%" + IMMBD_MaterialName + "%'";
        }
        if (PMPAM_ApplyTime1 != "")
        {
            if (PMPAM_ApplyTime2!= "")
            {
                condition += "and PMPAM_ApplyTime >='" + Convert.ToDateTime(PMPAM_ApplyTime1) + "'" + "and PMPAM_ApplyTime<='" +Convert.ToDateTime(PMPAM_ApplyTime2) + "'";
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
       
       if (IMMT_MaterialType!= "")
      {
           condition += "and (" + IMMT_MaterialType+")";
         
       }
       Gridview_OAInfo.DataSource = pd.SelectPMPurchaseApplyMaterial_Num(condition);
       Gridview_OAInfo.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/REPORT_cc/PMPurchaseApplyMaterial_Department.aspx");
    }
    protected void Button_Excel(object sender, EventArgs e)
    {
        ExcelHelper.GridViewToExcel(Gridview_OAInfo, "采购申请物料数量汇总");
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        // Confirms that an HtmlForm control is rendered for
    }
}