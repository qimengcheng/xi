using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class REPORT_cc_TotalIMPrint : System.Web.UI.Page
{
    private readonly SalesD sd = new SalesD();
    protected void Page_Load(object sender, EventArgs e)
    {
        Labelpeople.Text = Session["UserName"].ToString();
        Labeltime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        if (Request.QueryString["start"] == null || Request.QueryString["start"] == "")
        {
            Labelstart.Text = "始";
        }
        else
        {
            Labelstart.Text = Request.QueryString["start"];
        }
        if (Request.QueryString["end"] == null || Request.QueryString["end"] == "")
        {
            Labelend.Text = "今";
        }
        else
        {
            Labelend.Text = Request.QueryString["end"];
        }

        //绑定
        DateTime start = Convert.ToDateTime(Request.QueryString["start"]);
        DateTime end = Convert.ToDateTime(Request.QueryString["end"]);
        string Name = Convert.ToString(Request.QueryString["Name"]);
        string Model = Convert.ToString(Request.QueryString["Model"]);
        string Unit = Convert.ToString(Request.QueryString["Unit"]);

        string condition;
        string temp = "";
        if (Name!= "")
        {
            temp += " and mat.Name like '%" + Name+ "%'";
        }
        if (Model!= "")
        {
            temp += " and mat.Model like '%" + Model + "%'";
        }
        if (Unit!= "")
        {
            temp += " and mat.Unit like '%" + Unit + "%'";
        }
        condition = temp;
        Grid_Detail.DataSource = sd.S_TotalIM(start, end, condition);
        Grid_Detail.DataBind();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/REPORT_cc/TotalIM.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        ExcelHelper.GridViewToExcel(Grid_Detail, "库存统计报表");
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
    }
}