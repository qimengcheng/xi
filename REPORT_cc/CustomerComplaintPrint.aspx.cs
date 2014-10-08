using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class REPORT_cc_CustomerComplaintPrint : System.Web.UI.Page
{
    private readonly SalesD sd = new SalesD();
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
        string CRMCIF_Name = Request.QueryString["CRMCIF_Name"];
        string CRMCS_Name = Request.QueryString["CRMCS_Name"];
        string CRMASS_Name = Request.QueryString["CRMASS_Name"];
        string startime = Request.QueryString["startime"];
        string endtime = Request.QueryString["endtime"];

        string condition = "";
        string temp = "";
        if (CRMCIF_Name != "")
        {
            temp += " and CRMCIF_Name like '%" + CRMCIF_Name + "%'";
        }
        if (CRMCS_Name != "")
        {
            temp += " and CRMCS_Name = '" + CRMCS_Name + "'";
        }
        if (CRMASS_Name != "")
        {
            temp += " and CRMASS_Name = '" + CRMASS_Name + "'";
        }
        //投诉时间
        if (startime!= "" && endtime!= "")
        {
            temp += " and CRMCCM_InputTime >= '" + startime + "' and CRMCCM_InputTime <= '" + endtime + "'";
        }
        if (startime != "" && endtime == "")
        {
            temp += " and CRMCCM_InputTime >= '" + startime + "'";
        }
        if (startime == "" && endtime != "")
        {
            temp += " and CRMCCM_InputTime <= '" + endtime + "'";
        }
        if (startime == "" && endtime == "")
        {
            temp += "";
        }
        condition = temp;
        Grid_Detail.DataSource = sd.S_CustomerComplain(condition);
        Grid_Detail.DataBind();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/REPORT_cc/CustomerComplaint.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        ExcelHelper.GridViewToExcel(Grid_Detail, "客户投诉汇总表");
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
    }
}