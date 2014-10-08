using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EquipmentMangementAjax.DBUtility;
using System.Data.SqlClient;

public partial class REPORT_cc_PiecePerDayDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "计件信息详情表";
        if (!IsPostBack)
        {
            try
            {
                if (!((Session["UserRole"].ToString().Contains("计件信息详情表"))))
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

    public DataSet Search_TimePerDayDetail(string Condition)
    {
        return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Pro_S_PiecePerDayDetail", new SqlParameter("@Condition", Condition));
    }//

    private void BindGrid_Detail(string condition)
    {
        Grid_Detail.DataSource = Search_TimePerDayDetail(condition);
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
            LblRecordCondition.Text += textno.Text.Trim() == "" ? " " : " and SPI_Name like '%" + textno.Text.Trim() + "%'";
            LblRecordCondition.Text += textname.Text.Trim() == "" ? " " : " and PBC_Name like '%" + textname.Text.Trim() + "%'";
            LblRecordCondition.Text += texttype.Text.Trim() == "" ? " " : " and WO_Num like '%" + texttype.Text.Trim() + "%'";
            LblRecordCondition.Text += TxtStaffNO.Text.Trim() == "" ? " " : " and HRDD_StaffNO like '%" + TxtStaffNO.Text.Trim() + "%'";
            LblRecordCondition.Text += TxtStaffName.Text.Trim() == "" ? " " : " and HRDD_Name like '%" + TxtStaffName.Text.Trim() + "%'";
            LblRecordCondition.Text += TxtDep.Text.Trim() == "" ? " " : " and BDOS_Name like '%" + TxtDep.Text.Trim() + "%'";
            LblRecordCondition.Text += TxtPost.Text.Trim() == "" ? " " : " and HRP_Post like '%" + TxtPost.Text.Trim() + "%'";
            BindGrid_Detail(LblRecordCondition.Text);
            Panel_Grid.Visible = true;
            UpdatePanel_Grid.Update();
        }
    }
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        startime.Text = "";
        endtime.Text = "";
        textno.Text = "";
        textname.Text = "";
        texttype.Text = "";
        TxtStaffNO.Text = "";
        TxtStaffName.Text = "";
        TxtDep.Text = "";
        UpdatePanel_Search.Update();
        Panel_Grid.Visible = false;
        UpdatePanel_Grid.Update();
    }
    protected void Grid_Detail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = this.Grid_Detail.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox");   // refer to the TextBox with the NewPageIndex value
            }

            if (null != txtNewPageIndex && txtNewPageIndex.Text != "")
            {
                newPageIndex = int.Parse(txtNewPageIndex.Text) - 1; // get the NewPageIndex
            }
        }
        else
        {
            newPageIndex = e.NewPageIndex;
        }
        BindGrid_Detail(LblRecordCondition.Text);

        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= this.Grid_Detail.PageCount ? this.Grid_Detail.PageCount - 1 : newPageIndex;
        this.Grid_Detail.PageIndex = newPageIndex;
        this.Grid_Detail.DataBind();
    }
    //打印报表按钮
    protected void BtnPrint_Click(object sender, EventArgs e)
    {
        if (startime.Text.Trim() == "" || endtime.Text.Trim() == "")
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('必须填写统计的起止时间！')", true);
            return;
        }
        Response.Redirect("../REPORT_cc/PiecePerDayDetailPrint.aspx?" + "&startime=" + startime.Text.ToString() + "&endtime=" + endtime.Text.ToString() 
            + "&SPI_Name=" + textno.Text.ToString() + "&PBC_Name=" + textname.Text + "&WO_Num=" + texttype.Text + "&HRDD_StaffNO=" + TxtStaffNO.Text.ToString() 
            + "&HRDD_Name=" + TxtStaffName.Text.ToString()+ "&BDOS_Name=" + TxtDep.Text.ToString()+ "&HRP_Post=" + TxtPost.Text.ToString());
    }
}