using System;
using System.Web.UI;

public partial class PurchasingMgt_PRMProject_IsFinishPrint : Page
{
    PRMProject_IsFinishD pd = new PRMProject_IsFinishD();
    protected void Page_Load(object sender, EventArgs e)
    {
        Labelpeople.Text = Session["UserName"].ToString();
        Labeltime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        if (Request.QueryString["ProjectPlTime1"] == null || Request.QueryString["ProjectPlTime1"] == "")
        {
            Labelstart.Text = "始";
        }
        else
        {
            Labelstart.Text = Request.QueryString["ProjectPlTime1"];
        }
        if (Request.QueryString["ProjectPlTime2"] == null || Request.QueryString["ProjectPlTime2"] == "")
        {
            Labelend.Text = "今";
        }
        else
        {
            Labelend.Text = Request.QueryString["ProjectPlTime2"];
        }
        string condition = Request.QueryString["Getcondition()"];
        Gridview_OAInfo.DataSource = pd.SelectPRMProject_IsFinish(condition);
        Gridview_OAInfo.DataBind();
        label_Title.Text = "共" + Gridview_OAInfo.Rows.Count + "个项目";
    }
    //导出excel
    protected void Button_Excel(object sender, EventArgs e)
    {
        ExcelHelper.GridViewToExcel(Gridview_OAInfo, "项目完成情况汇总统计表");
    }
    //返回
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/REPORT_cc/PRMProject_IsFinish.aspx");
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        // Confirms that an HtmlForm control is rendered for
    }
    //打印
    protected void Button_Click(object sender, EventArgs e)
    {

    }
}