using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class REPORT_cc_ExpTestPrint : System.Web.UI.Page
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
        string ETA_ProIdentify = Request.QueryString["ETA_ProIdentify"];
        string EST_SampleType = Request.QueryString["EST_SampleType"];
        string ETA_AppDep = Request.QueryString["ETA_AppDep"];
        string ETA_EmergDegree = Request.QueryString["ETA_EmergDegree"];
        string EI_ExpItem = Request.QueryString["EI_ExpItem"];
        string EIR_ItemRes = Request.QueryString["EIR_ItemRes"];
        string startime = Request.QueryString["startime"];
        string endtime = Request.QueryString["endtime"];

        string condition;
        string temp = "";
        if (ETA_ProIdentify != "")
        {
            temp += " and a.ETA_ProIdentify like '%" + ETA_ProIdentify + "%'";
        }
        if (EST_SampleType != "")
        {
            temp += " and c.EST_SampleType = '" + EST_SampleType + "'";
        }
        if (ETA_AppDep != "")
        {
            temp += " and a.ETA_AppDep = '" + ETA_AppDep + "'";
        }
        if (ETA_EmergDegree != "")
        {
            temp += " and a.ETA_EmergDegree = '" + ETA_EmergDegree + "'";
        }
        if (EI_ExpItem != "")
        {
            temp += " and d.EI_ExpItem like '%" + EI_ExpItem + "%'";
        }
        if (EIR_ItemRes != "")
        {
            temp += " and b.EIR_ItemRes = '" + EIR_ItemRes + "'";
        }
        //上次版本生效时间
        if (startime != "" && endtime != "")
        {
            temp += " and a.ETA_AppTime >= '" + startime + "' and a.ETA_AppTime <= '" + endtime + "'";
        }
        if (startime!= "" && endtime == "")
        {
            temp += " and a.ETA_AppTime >= '" + startime+ "'";
        }
        if (startime == "" && endtime != "")
        {
            temp += " and a.ETA_AppTime <= '" + endtime + "'";
        }
        if (startime == "" && endtime == "")
        {
            temp += "";
        }
        condition = temp;
        Grid_Detail.DataSource = sd.S_ExpTest_Statistical(condition);
        Grid_Detail.DataBind();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/REPORT_cc/ExpTest.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        ExcelHelper.GridViewToExcel(Grid_Detail, "实验数据统计表");
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
    }
}