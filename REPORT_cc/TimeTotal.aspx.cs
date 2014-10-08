using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EquipmentMangementAjax.DBUtility;
using System.Data.SqlClient;

public partial class REPORT_cc_TimeTotal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "计时信息阶段统计表";
        GetCondition();
        if (!IsPostBack)
        {
            try
            {
                //if (!((Session["UserRole"].ToString().Contains("计时信息阶段统计表"))))
                //{
                //    Response.Redirect("~/Default.aspx");
                //}
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('可能您没有权限操作和查看本页面，请退出选择其他账号登陆，或联系管理员！')", true);
                Response.Redirect("~/Default.aspx");
            }
        }
    }

    public DataSet Search_TimeTotal(string Condition)
    {
        return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Pro_S_TimeTotal", new SqlParameter("@Condition", Condition));
    }//

    private void BindGrid_Detail(string condition)
    {
        Grid_Detail.DataSource = Search_TimeTotal(condition);
        Grid_Detail.DataBind();
    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        if (startime.Text.Trim() == "" || endtime.Text.Trim() == "")
            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('必须填写统计的起止时间！')", true);
        else
        {
            LblRecordCondition.Text = startime.Text.Trim() == "" ? " " : " and thedate >= '" + startime.Text + "'";
            LblRecordCondition.Text += endtime.Text.Trim() == "" ? " " : " and thedate <= '" + endtime.Text + "'";
            LblRecordCondition.Text += textno.Text.Trim() == "" ? " " : " and STI_Name like '%" + textno.Text.Trim() + "%'";
            LblRecordCondition.Text += textname.Text.Trim() == "" ? " " : " and PBC_Name like '%" + textname.Text.Trim() + "%'";
            BindGrid_Detail(LblRecordCondition.Text);
            Panel_Grid.Visible = true;
            UpdatePanel_Grid.Update();
        }
    }
    private string GetCondition()
    {

        LblRecordCondition.Text = startime.Text.Trim() == "" ? " " : " and thedate >= '" + startime.Text + "'";
        LblRecordCondition.Text += endtime.Text.Trim() == "" ? " " : " and thedate <= '" + endtime.Text + "'";
        LblRecordCondition.Text += textno.Text.Trim() == "" ? " " : " and STI_Name like '%" + textno.Text.Trim() + "%'";
        LblRecordCondition.Text += textname.Text.Trim() == "" ? " " : " and PBC_Name like '%" + textname.Text.Trim() + "%'";

        return (LblRecordCondition.Text);
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
    protected void Button2_Click1(object sender, EventArgs e)
    {
        if (startime.Text.Trim() == "" || endtime.Text.Trim() == "")
            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('必须填写统计的起止时间！')", true);
        else
        {
            Response.Redirect("../REPORT_cc/TimeTotalPrint.aspx?" + "&Time1=" + this.startime.Text + "&Time2=" + this.endtime.Text + "&Getcondition()=" + GetCondition());
        }
    }
}