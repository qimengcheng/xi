using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EquipmentMangementAjax.DBUtility;
using System.Data.SqlClient;

public partial class REPORT_cc_PieceTotalPrint : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "计件信息阶段统计表打印";
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
        string startime = Request.QueryString["startime"];
        string endtime = Request.QueryString["endtime"];

        string condition = "";
        condition += startime == "" ? " " : " and thedate >= '" + startime + "'";
        condition += endtime == "" ? " " : " and thedate <= '" + endtime + "'";
        condition += SPI_Name == "" ? " " : " and SPI_Name like '%" + SPI_Name + "%'";
        condition += PBC_Name == "" ? " " : " and PBC_Name like '%" + PBC_Name + "%'";
        Grid_Detail.DataSource = Search_PieceTotal(condition);
        Grid_Detail.DataBind();
    }
    private DataSet Search_PieceTotal(string Condition)
    {
        return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Pro_S_PieceTotal", new SqlParameter("@Condition", Condition));
    }//
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/REPORT_cc/PieceTotal.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        ExcelHelper.GridViewToExcel(Grid_Detail, "计件信息阶段统计表");
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
    }
}
