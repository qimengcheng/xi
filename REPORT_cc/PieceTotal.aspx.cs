using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EquipmentMangementAjax.DBUtility;
using System.Data.SqlClient;

public partial class REPORT_cc_PieceTotal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "计件信息阶段统计表";
        if (!IsPostBack)
        {
            try
            {
                if (!((Session["UserRole"].ToString().Contains("计件信息阶段统计表"))))
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
    }

    private DataSet Search_PieceTotal(string Condition)
    {
        return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Pro_S_PieceTotal", new SqlParameter("@Condition", Condition));
    }//

    private void BindGrid_Detail(string condition)
    {
        Grid_Detail.DataSource = Search_PieceTotal(condition);
        Grid_Detail.DataBind();
    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (startime.Text.Trim() == "" || endtime.Text.Trim() == "")
                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('必须填写统计的起止时间！')", true);
            else
            {
                LblRecordCondition.Text = startime.Text.Trim() == "" ? " " : " and thedate >= '" + startime.Text + "'";
                LblRecordCondition.Text += endtime.Text.Trim() == "" ? " " : " and thedate <= '" + endtime.Text + "'";
                LblRecordCondition.Text += textno.Text.Trim() == "" ? " " : " and SPI_Name like '%" + textno.Text.Trim() + "%'";
                LblRecordCondition.Text += textname.Text.Trim() == "" ? " " : " and PBC_Name like '%" + textname.Text.Trim() + "%'";
                BindGrid_Detail(LblRecordCondition.Text);
                Panel_Grid.Visible = true;
                UpdatePanel_Grid.Update();
            }
        }
        catch (Exception)
        {
            
            throw;
        }
        
    }
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        startime.Text = "";
        endtime.Text = "";
        textno.Text = "";
        textname.Text = "";
        UpdatePanel_Search.Update();
        Panel_Grid.Visible = false;
        UpdatePanel_Grid.Update();
    }
    //打印报表按钮
    protected void BtnPrint_Click(object sender, EventArgs e)
    {
        if (startime.Text.Trim() == "" || endtime.Text.Trim() == "")
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('必须填写统计的起止时间！')", true);
            return;
        }
        Response.Redirect("../REPORT_cc/PieceTotalPrint.aspx?" + "&startime=" + startime.Text.ToString() + "&endtime=" + endtime.Text.ToString()
            + "&SPI_Name=" + textno.Text.ToString() + "&PBC_Name=" + textname.Text );
    }
}