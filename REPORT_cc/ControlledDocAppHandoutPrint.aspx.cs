using System;
using System.Web.UI;

public partial class REPORT_cc_ControlledDocAppHandoutPrint : Page
{
    private readonly SpareD sd = new SpareD();
    protected void Page_Load(object sender, EventArgs e)
    {
        Labelpeople.Text = Session["UserName"].ToString();
        Labeltime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        
        //绑定
        string CDA_EditionNO = Request.QueryString["CDA_EditionNO"];
        string CDA_DocNO = Request.QueryString["CDA_DocNO"];
        string CDA_DocName = Request.QueryString["CDA_DocName"];
        string AllDep = Request.QueryString["CDA_AppDep"];
        string laststar = Request.QueryString["laststar"];
        string lastend = Request.QueryString["lastend"];

        string condition = "";
        string temp = "";
        if (AllDep != "")
        {
            temp += " and AllDep like '%" + AllDep + "%'";
        }
        if (CDA_DocNO != "")
        {
            temp += " and CDA_DocNO like '%" + CDA_DocNO + "%'";
        }
        if (CDA_DocName != "")
        {
            temp += " and CDA_DocName like '%" + CDA_DocName + "%'";
        }
        if (CDA_EditionNO != "")
        {
            temp += " and CDA_EditionNO = '" + CDA_EditionNO + "'";
        }
        //生效时间
        if (laststar != "" && lastend != "")
        {
            temp += " and CDA_EffectDate >= '" + laststar + "' and CDA_EffectDate <= '" + lastend + "'";
        }
        if (laststar != "" && lastend == "")
        {
            temp += " and CDA_EffectDate >= '" + laststar + "'";
        }
        if (laststar == "" && lastend != "")
        {
            temp += " and CDA_EffectDate <= '" + lastend + "'";
        }
        if (laststar == "" && lastend == "")
        {
            temp += "";
        }
        condition = temp;
        Grid_Detail.DataSource = sd.S_ControlledDocAppHandout_Print(condition);
        Grid_Detail.DataBind();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/REPORT_cc/ControlledDocAppHandout.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        ExcelHelper.GridViewToExcel(Grid_Detail, "受控文件分发一览表");
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
    }
}