using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class REPORT_cc_SalaryDetailEachMonthPrint : System.Web.UI.Page
{
    private readonly SalesD sd = new SalesD();
    protected void Page_Load(object sender, EventArgs e)
    {
        Labelpeople.Text = Session["UserName"].ToString();
        Labeltime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

        //绑定
        string SDBT_NO = Request.QueryString["SDBT_NO"];
        string SDBT_Name = Request.QueryString["SDBT_Name"];
        string SDBT_Dep = Request.QueryString["SDBT_Dep"];
        string SDBT_Post = Request.QueryString["SDBT_Post"];
        string SDBT_Year = Request.QueryString["SDBT_Year"];
        string SDBT_Month = Request.QueryString["SDBT_Month"];
        
        Labelyear.Text = SDBT_Year;
        Labelmonth.Text = SDBT_Month;
        if (SDBT_Dep == "")
        {
            Label13.Text = "所有部门";
        }
        else
        {
            Label13.Text = SDBT_Dep;
        }
        if (SDBT_Post == "")
        {
            Label14.Text = "所有岗位";
        }
        else
        {
            Label14.Text = SDBT_Post;
        }

        string condition = "";
        string temp = "";
        if (SDBT_NO != "")
        {
            temp += " and SDBT_NO like '%" + SDBT_NO + "%'";
        }
        if (SDBT_Name != "")
        {
            temp += " and SDBT_Name like '%" + SDBT_Name + "%'";
        }
        if (SDBT_Dep != "")
        {
            temp += " and SDBT_Dep like '%" + SDBT_Dep + "%'";
        }
        if (SDBT_Post != "")
        {
            temp += " and SDBT_Post like '%" + SDBT_Post + "%'";
        }
        if (SDBT_Year != "")
        {
            temp += " and SDBT_Year = '" + SDBT_Year + "'";
        }
        if (SDBT_Month != "")
        {
            temp += " and SDBT_Month = '" + SDBT_Month + "'";
        }
        condition = temp;
        Grid_Detail.DataSource = sd.S_SalaryDetailEachMonth(condition);
        Grid_Detail.DataBind();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/REPORT_cc/SalaryDetailEachMonth.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        //string name = Labelyear.Text + "年" + Labelmonth.Text +"月" + Label13.Text + "(" + Label14.Text + ")薪资汇总表";
        //ExcelHelper.GridViewToExcel(Grid_Detail, name);
        Response.Clear();
        //Response.AddHeader("content-disposition", "attachment;filename=" + System.Web.HttpUtility.UrlEncode(DateTime.Now.ToString("yyyy-MM-dd") + ".xls"));
        Response.AddHeader("content-disposition", "attachment;filename="+ Labelyear.Text + "年" + Labelmonth.Text +"月" + Label13.Text + "(" + Label14.Text + ")薪资汇总表.xls");
        Response.Charset = "utf-8";
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
        Response.ContentType = "application/vnd.ms-excel";
        string strStyle = "<style>td{mso-number-format:\"\\@\";}</style>";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        stringWrite.WriteLine(strStyle);
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

        Grid_Detail.RenderControl(htmlWrite);

        Response.Write(stringWrite.ToString());
        Response.End();
        
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
    }


}