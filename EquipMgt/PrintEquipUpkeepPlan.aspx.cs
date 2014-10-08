using System;
using System.Web.UI;

public partial class EquipMgt_PrintEquipUpkeepPlan : Page
{
    EquipUpkeepPlanL equipUpkeepPlanL = new EquipUpkeepPlanL();
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
        string EI_No = Request.QueryString["EI_No"];
        string EUP_UpkeepPer = Request.QueryString["EUP_UpkeepPer"];
        //DateTime startime = Convert.ToDateTime( Request.QueryString["startime"]);
        //DateTime endtime = Convert.ToDateTime( Request.QueryString["endtime"]);

        string startime = Request.QueryString["startime"];
        string endtime = Request.QueryString["endtime"];

        string condition = "";
        string temp = "";
        if (EN_EquipName != "")
        {
            temp += " and EN_EquipName like '%" + EN_EquipName + "%'";
        }
        if (EI_No != "")
        {
            temp += " and EI_No like '%" + EI_No + "%'";
        }
        if (EUP_UpkeepPer != "")
        {
            temp += " and EUP_UpkeepPer like '%" + EUP_UpkeepPer + "%'";
        }
        if (startime != "" && endtime != "")
        {
            temp += " and EUP_PDate >= '" + startime + "' and EUP_PDate <= '" + endtime + "'";
        }
        if (startime != "" && endtime == "")
        {
            temp += " and EUP_PDate >= '" + startime + "' ";
        }
        if (startime == "" && endtime != "")
        {
            temp += " and EUP_PDate <= '" + endtime + "'";
        }
        if (startime == "" && endtime == "")
        {
            temp += "";
        }
        temp += " and d.EUP_State ='已生成'";
        condition = temp;
        Grid_EquipUpkeepPlan.DataSource = equipUpkeepPlanL.Search_EquipUpkeepPlan(condition);
        Grid_EquipUpkeepPlan.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/EquipMgt/EMEquipUpkeepPlan.aspx?status=EMGen");
    }
}