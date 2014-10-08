using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EquipmentMangementAjax.DBUtility;
using System.Data.SqlClient;

public partial class REPORT_cc_PiecePerDayDetailPrint : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "计件信息详情表打印";
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
        string SPI_Name = Request.QueryString["SPI_Name"];
        string PBC_Name = Request.QueryString["PBC_Name"];
        string WO_Num = Request.QueryString["WO_Num"];
        string startime = Request.QueryString["startime"];
        string endtime = Request.QueryString["endtime"];
        string HRDD_StaffNO = Request.QueryString["HRDD_StaffNO"];
        string HRDD_Name = Request.QueryString["HRDD_Name"];
        string BDOS_Name = Request.QueryString["BDOS_Name"];
        string HRP_Post = Request.QueryString["HRP_Post"];
        
        string condition = "";
        condition += startime== "" ? " " : " and thedate >= '" + startime + "'";
        condition += endtime == "" ? " " : " and thedate <= '" + endtime + "'";
        condition += SPI_Name == "" ? " " : " and SPI_Name like '%" + SPI_Name + "%'";
        condition += PBC_Name == "" ? " " : " and PBC_Name like '%" + PBC_Name + "%'";
        condition += WO_Num == "" ? " " : " and WO_Num like '%" + WO_Num + "%'";
        condition += HRDD_StaffNO == "" ? " " : " and HRDD_StaffNO like '%" + HRDD_StaffNO + "%'";
        condition += HRDD_Name == "" ? " " : " and HRDD_Name like '%" + HRDD_Name + "%'";
        condition += BDOS_Name == "" ? " " : " and BDOS_Name like '%" + BDOS_Name + "%'";
        condition += HRP_Post == "" ? " " : " and HRP_Post like '%" + HRP_Post + "%'";
        Grid_Detail.DataSource = Search_TimePerDayDetail(condition);
        Grid_Detail.DataBind();
    }
    public DataSet Search_TimePerDayDetail(string Condition)
    {
        return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Pro_S_PiecePerDayDetail", new SqlParameter("@Condition", Condition));
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/REPORT_cc/PiecePerDayDetail.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        //ExcelHelper.GridViewToExcel(Grid_Detail, "计件信息详情表");
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=" + "计件信息详情表.xls");
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
    