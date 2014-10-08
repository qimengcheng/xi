using System;
using System.Web.UI;

public partial class REPORT_cc_ControlledDocAppPrint : Page
{
    private readonly SpareD sd = new SpareD();
    protected void Page_Load(object sender, EventArgs e)
    {
        Labelpeople.Text = Session["UserName"].ToString();
        Labeltime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        if (Request.QueryString["CDA_AppDep"] == null || Request.QueryString["CDA_AppDep"] == "")
        {
            AppDep.Text = "全部";
        }
        else
        {
            AppDep.Text = Request.QueryString["CDA_AppDep"];
        }
        //绑定
        string CDA_AppDep = Request.QueryString["CDA_AppDep"];
        string CDA_DocNO = Request.QueryString["CDA_DocNO"];
        string CDA_DocName = Request.QueryString["CDA_DocName"];
        string laststar = Request.QueryString["laststar"];
        string lastend = Request.QueryString["lastend"];
        string neweststar = Request.QueryString["neweststar"];
        string newestend = Request.QueryString["newestend"];

        string condition = "";
        string temp = "";
        if (CDA_AppDep != "")
        {
            temp += " and a.CDA_AppDep = '" + CDA_AppDep + "'";
        }
        if (CDA_DocNO != "")
        {
            temp += " and a.CDA_DocNO like '%" + CDA_DocNO + "%'";
        }
        if (CDA_DocName != "")
        {
            temp += " and a.CDA_DocName like '%" + CDA_DocName + "%'";
        }
        //上次版本生效时间
        if (laststar != "" && lastend != "")
        {
            temp += " and b.CDA_EffectDate >= '" + laststar + "' and b.CDA_EffectDate <= '" + lastend + "'";
        }
        if (laststar != "" && lastend == "")
        {
            temp += " and b.CDA_EffectDate >= '" + laststar + "'";
        }
        if (laststar == "" && lastend != "")
        {
            temp += " and b.CDA_EffectDate <= '" + lastend + "'";
        }
        if (laststar == "" && lastend == "")
        {
            temp += "";
        }
        //最新版本生效时间
        if (neweststar!= "" && newestend != "")
        {
            temp += " and a.CDA_EffectDate >= '" + neweststar + "' and a.CDA_EffectDate <= '" + newestend + "'";
        }
        if (neweststar != "" && newestend == "")
        {
            temp += " and a.CDA_EffectDate >= '" + neweststar + "'";
        }
        if (neweststar == "" && newestend!= "")
        {
            temp += " and a.CDA_EffectDate <= '" + newestend + "'";
        }
        if (neweststar == "" && newestend == "")
        {
            temp += "";
        }
        condition = temp;
        Grid_Detail.DataSource = sd.S_ControlledDocApp_Print(condition);
        Grid_Detail.DataBind();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/REPORT_cc/ControlledDocApp.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        ExcelHelper.GridViewToExcel(Grid_Detail, "各部门受控文件一览表");
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
    }

}