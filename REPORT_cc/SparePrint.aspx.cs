using System;
using System.Web.UI;

public partial class REPORT_cc_SparePrint : Page
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
        string IMMBD_MaterialName = Request.QueryString["IMMBD_MaterialName"];
        string IMMBD_MaterialCode = Request.QueryString["IMMBD_MaterialCode"];
        string EI_No = Request.QueryString["EI_No"];
        string startime = Request.QueryString["startime"];
        string endtime = Request.QueryString["endtime"];

        string condition = "";
        string temp = "";
        if (IMMBD_MaterialName!= "")
        {
            temp += " and c.IMMBD_MaterialName like '%" + IMMBD_MaterialName + "%'";
        }
        if (IMMBD_MaterialCode != "")
        {
            temp += " and c.IMMBD_MaterialCode like '%" + IMMBD_MaterialCode + "%'";
        }
        if (EI_No != "")
        {
            temp += " and f.EI_No like '%" + EI_No + "%'";
        }
        if (startime != "" && endtime != "")
        {
            temp += " and ((e.EUP_UEndT >= '" + startime + "' and e.EUP_UEndT <= '" + endtime + "')  or ( d.ERDAOA_EndTime >= '" + startime + "' and d.ERDAOA_EndTime <= '" + endtime + "') or ( d.ERDAOA_OCTime >= '" + startime + "' and d.ERDAOA_OCTime <= '" + endtime + "'))";
        }
        if (startime != "" && endtime == "")
        {
            temp += " and (e.EUP_UEndT >= '" + startime + "'  or d.ERDAOA_EndTime >= '" + startime + "' or d.ERDAOA_OCTime >= '" + startime + "' )";
        }
        if (startime == "" && endtime != "")
        {
            temp += " and (e.EUP_UEndT <= '" + endtime + "' or d.ERDAOA_EndTime <= '" + endtime + "' or d.ERDAOA_OCTime <= '" + endtime + "')";
        }
        if (startime == "" && endtime == "")
        {
            temp += "";
        }
        condition = temp;
        Grid_Detail.DataSource = sd.S_EquipSpare_Statistical(condition);
        Grid_Detail.DataBind();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/REPORT_cc/Spare.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        ExcelHelper.GridViewToExcel(Grid_Detail, "备件领用统计表");
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
    }
}