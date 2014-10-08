using System;
using System.Web.UI;

public partial class REPORT_cc_EquipOutputPrint : Page
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
        string EI_No = Request.QueryString["EI_No"];
        string EN_EquipName = Request.QueryString["EN_EquipName"];
        string EMT_Type = Request.QueryString["EMT_Type"];
        string startime = Request.QueryString["startime"];
        string endtime = Request.QueryString["endtime"];

        string condition1 = "";
        string temp1 = "";

        if (EI_No != "")
        {
            temp1 += " and EI_No like '%" + EI_No + "%'";
        }
        if (EN_EquipName != "")
        {
            temp1 += " and EN_EquipName like '%" + EN_EquipName + "%'";
        }
        if (EMT_Type != "")
        {
            temp1 += " and EMT_Type like '%" + EMT_Type + "%'";
        }
        condition1 = temp1;
        string time = "BETWEEN '" + startime + "' AND '" + endtime + "'";
        Grid_Detail.DataSource = sd.S_EquipOutput_Statistical(condition1, time);
        Grid_Detail.DataBind();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/REPORT_cc/EquipOutput.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        ExcelHelper.GridViewToExcel(Grid_Detail, "设备产量统计表");
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
    }
}