using System;
using System.Web.UI;
using System.Data;

public partial class REPORT_cc_ProSpecialPrint : Page
{
    private WorkOrderL wol = new WorkOrderL();
    private ProSpecialD psd = new ProSpecialD();
    protected void Page_Load(object sender, EventArgs e)
    {
        GridView_bom.DataSource = wol.S_ProType_BOM(LabelPT_Name.Text);
        GridView_bom.DataBind();

        GridView_Pr.DataSource = wol.S_WO_ProType_ProcessRoute(LabelPT_Name.Text, 0);
        GridView_Pr.DataBind();

        string condition = "and PT_ID='" + new Guid(Request.QueryString["PT_ID"]) + "'";
        Gridview4.DataSource = psd.SelectPTCountersign(condition);
        Gridview4.DataBind();
        DataSet ds = psd.SelectProType_Special(condition);

        LabelPT_SpecialCode.Text = ds.Tables[0].Rows[0]["PT_SpecialCode"].ToString();
        LabelPT_Name.Text = ds.Tables[0].Rows[0]["PT_Name"].ToString();
        LabelPT_SpecialNeed.Text = ds.Tables[0].Rows[0]["PT_SpecialNeed"].ToString();
        LabelPT_SpecialTypeMan.Text = ds.Tables[0].Rows[0]["PT_SpecialTypeMan"].ToString();
        LabelPT_SpecialTypeTime.Text = ds.Tables[0].Rows[0]["PT_SpecialTypeTime"].ToString();
        LabelPT_CSate.Text = ds.Tables[0].Rows[0]["PT_CSate"].ToString();
        TextBoxLabelPT_Note.Text = ds.Tables[0].Rows[0]["PT_Note"].ToString();

        try
        {
            LabelPrint.Text = Session["UserName"].ToString();
        }
        catch
        {
            Response.Redirect("~/Default.aspx");
        }
        LabelTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("../CraftMgt/ProSpecial.aspx");
    }
}