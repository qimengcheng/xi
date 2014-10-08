using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

public partial class REPORT_cc_TimePerDayDetailPrint : System.Web.UI.Page
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
        this.Gridview_OAInfo.DataSource = Search_TimePerDayDetail(condition);
        this.Gridview_OAInfo.DataBind();
    }

    public DataSet Search_TimePerDayDetail(string Condition)
    {
        return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Pro_S_TimePerDayDetail", new SqlParameter("@Condition", Condition));
    }//
    //导出excel
    protected void Button_Excel(object sender, EventArgs e)
    {
        string title="计时信息详情表"+"("+Request.QueryString["Time1"]+"至"+Request.QueryString["Time2"]+")";
        //ExcelHelper.GridViewToExcel(Gridview_OAInfo,title);

        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=" + title + ".xls");
        Response.Charset = "utf-8";
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
        Response.ContentType = "applicationnd.ms-excel";
        string strStyle = "<style>td{mso-number-format:\"\\@\";}</style>";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        stringWrite.WriteLine(strStyle);
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

        Gridview_OAInfo.RenderControl(htmlWrite);

        Response.Write(stringWrite.ToString());
        Response.End();
    }

    //返回
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/REPORT_cc/TimePerDayDetail.aspx");
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        // Confirms that an HtmlForm control is rendered for
    }
    protected void Gridview_OAInfo_RowDataBound1(object sender, GridViewRowEventArgs e)
    {

    }
}