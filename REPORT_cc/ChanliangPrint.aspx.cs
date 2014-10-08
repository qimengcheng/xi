using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class REPORT_cc_ChanliangPrint : System.Web.UI.Page
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
        string PBC_Name = Request.QueryString["PBC_Name"];
        string PMS_Name = Request.QueryString["PMS_Name"];
        string HRDD_StaffNO = Request.QueryString["HRDD_StaffNO"];
        string HRDD_Name = Request.QueryString["HRDD_Name"];
        string startime = Request.QueryString["startime"];
        string endtime = Request.QueryString["endtime"];

        string condition = "";
        string temp = "";
        if (PBC_Name != "")
        {
            temp += " and 工序 = '" + PBC_Name + "'";
        }
        if (PMS_Name != "")
        {
            temp += " and 大类型号 = '" + PMS_Name + "'";
        }
        if (HRDD_StaffNO != "")
        {
            temp += " and 工号 like '%" + HRDD_StaffNO + "%'";
        }
        if (HRDD_Name != "")
        {
            temp += " and 姓名 like '%" + HRDD_Name + "%'";
        }
        //时间
        if (startime != "" && endtime != "")
        {
            temp += " and 日期 >= '" + startime + "' and 日期 <= '" + endtime + "'";
        }
        if (startime != "" && endtime == "")
        {
            temp += " and 日期 >= '" + startime + "'";
        }
        if (startime == "" && endtime != "")
        {
            temp += " and 日期 <= '" + endtime + "'";
        }
        if (startime == "" && endtime == "")
        {
            temp += "";
        }
        condition = temp;
        Grid_Detail.DataSource = sd.S_Chanliang(condition);
        Grid_Detail.DataBind();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/REPORT_cc/Chanliang.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        ExcelHelper.GridViewToExcel(Grid_Detail, "工人计件产量报表");
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
    }
}