using System;
using System.Web.UI;

public partial class REPORT_cc_EquipMaintenanceTotalPrint : Page
{
    private readonly SpareD sd = new SpareD();
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
        string EN_EquipName = Request.QueryString["EN_EquipName"];
        string startime = Request.QueryString["startime"];
        string endtime = Request.QueryString["endtime"];

        string condition1 = "";
        string temp1 = "";

        if (EN_EquipName != "")
        {
            temp1 += " and EN_EquipName like '%" + EN_EquipName + "%'";
        }
        condition1 = temp1;
        string time = "BETWEEN '" + startime + "' AND '" + endtime + "'";
        Grid_Detail.DataSource = sd.S_EquipMaintenance_TotalStatistical(condition1, time);
        Grid_Detail.DataBind();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/REPORT_cc/EquipMaintenanceTotal.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        ExcelHelper.GridViewToExcel(Grid_Detail, "设备故障停机统计总表");
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
    }
}