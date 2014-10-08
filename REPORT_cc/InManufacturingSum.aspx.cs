using EquipmentMangementAjax.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class REPORT_cc_InManufacturingSum : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!(Session["UserRole"].ToString().Contains("在制品数量统计表")))
            {
                Response.Redirect("~/Default.aspx");
            }

        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('可能您没有权限操作和查看本页面，请退出选择其他账号登陆，或联系管理员！')", true);
            Response.Redirect("~/Default.aspx");
        }
    }
    protected void BtnToExcel_Click(object sender, EventArgs e)
    {
        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_InManufacturingSum",null);
        Grid1.AllowPaging = false;
        Grid1.AllowSorting = false;
        Grid1.DataSource = ds;
        Grid1.DataBind();

        ExcelHelper.GridViewToExcel(Grid1,"在制品数量统计表-正常产品");
        Grid1.AllowSorting = true;
        Grid1.AllowPaging = true;

    }

    protected void BtnToExcelOver_Click(object sender, EventArgs e)
    {
        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_InManufacturingSumOver", null);
        Grid1.AllowPaging = false;
        Grid1.AllowSorting = false;
        Grid1.DataSource = ds;
        Grid1.DataBind();

        ExcelHelper.GridViewToExcel(Grid1, "在制品数量统计表-超期产品");
        Grid1.AllowSorting = true;
        Grid1.AllowPaging = true;
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }

}