using System;
using System.Web.UI;

public partial class REPORT_cc_EquipUpkeepPlanPrint : Page
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
        string EMT_Type = Request.QueryString["EMT_Type"];
        string EN_EquipName = Request.QueryString["EN_EquipName"];
        string EUP_UpkeepPer = Request.QueryString["EUP_UpkeepPer"];
        string startime = Request.QueryString["startime"];
        string endtime = Request.QueryString["endtime"];

        //condition1
        string condition1 = "";
        string temp1 = "";
        
        if (startime != "" && endtime != "")
        {
            temp1 += " and EUP_PDate >= '" + startime + "' and EUP_PDate <= '" + endtime + "' and (EUP_UEndT>='" + endtime + "' or EUP_UEndT is null)";
        }
        //if (startime != "" && endtime == "")
        //{
        //    temp1 += " and EUP_PDate >= '" + startime + "' and EUP_PDate <= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' and (EUP_UEndT>='" + DateTime.Now.ToString("yyyy-MM-dd") + "' or EUP_UEndT is null)";
        //}
        //if (startime == "" && endtime != "")
        //{
        //    temp1 += " and EUP_PDate <= '" + endtime + "' and (EUP_UEndT>='" + endtime + "' or EUP_UEndT is null)";
        //}
        //if (startime == "" && endtime == "")
        //{
        //    temp1 += " and EUP_PDate <= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' and (EUP_UEndT>='" + DateTime.Now.ToString("yyyy-MM-dd") + "' or EUP_UEndT is null)";
        //}
        condition1 = temp1;
        //condition2
        string condition2 = "";
        string temp2 = "";
        if (EI_No != "")
        {
            temp2 += " and a.EI_No like '%" + EI_No + "%'";
        }
        if (EMT_Type != "")
        {
            temp2 += " and a.EMT_Type like '%" + EMT_Type + "%'";
        }
        if (EN_EquipName != "")
        {
            temp2 += " and a.EN_EquipName like '%" + EN_EquipName + "%'";
        }
        if (EUP_UpkeepPer != "")
        {
            temp2 += " and a.EUP_UpkeepPer like '%" + EUP_UpkeepPer + "%'";
        }
        condition2 = temp2;

        Grid_Detail.DataSource = sd.S_EquipUpkeepPlan_Statistical(condition1, condition2);
        Grid_Detail.DataBind();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/REPORT_cc/EquipUpkeepPlan.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        ExcelHelper.GridViewToExcel(Grid_Detail, "设备保养完成情况统计表");
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
    }
}