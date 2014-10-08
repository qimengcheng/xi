using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

public partial class REPORT_cc_TimeTotalPrint : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Labelpeople.Text = Session["UserName"].ToString();
        Labeltime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        if (Request.QueryString["Time1"] == null || Request.QueryString["Time1"] == "")
        {
            Labelstart.Text = "始";
        }
        else
        {
            Labelstart.Text = Request.QueryString["Time1"];
        }
        if (Request.QueryString["Time2"] == null || Request.QueryString["Time2"] == "")
        {
            Labelend.Text = "今";
        }
        else
        {
            Labelend.Text = Request.QueryString["Time2"];
        }
        string condition = Request.QueryString["Getcondition()"];
        this.Gridview_OAInfo.DataSource = Search_TimeTotal(condition);
        this.Gridview_OAInfo.DataBind();
    }

    public DataSet Search_TimeTotal(string Condition)
    {
        return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Pro_S_TimeTotal", new SqlParameter("@Condition", Condition));
    }//

    //导出excel
    protected void Button_Excel(object sender, EventArgs e)
    {
        string title = "计时信息阶段统计表" + "(" + Request.QueryString["Time1"] + "至" + Request.QueryString["Time2"] + ")";
        ExcelHelper.GridViewToExcel(Gridview_OAInfo, title);
    }
    //返回
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/REPORT_cc/TimeTotal.aspx");
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        // Confirms that an HtmlForm control is rendered for
    }
    protected void Gridview_OAInfo_RowDataBound1(object sender, GridViewRowEventArgs e)
    {

    }
}