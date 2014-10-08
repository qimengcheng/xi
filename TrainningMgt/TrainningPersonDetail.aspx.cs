using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EquipmentMangementAjax.DBUtility;
using System.Data.SqlClient;

public partial class TrainningMgt_TrainningPersonDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        #region//权限控制
        if (!((Session["UserRole"].ToString().Contains("培训详情查询"))))
        {
            Response.Redirect("~/Default.aspx");

        }
        Title = "培训详情查询";
        #endregion
        if (!IsPostBack)
        {
            BindGridView_People("");
        }
    }
    public DataSet Search_TrainingPersonDetail(string Condition)
    {
        return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_TrainingPersonDetail", new SqlParameter("@Condition", Condition));
    }//
    private void BindGridView_People(string str)
    {
        GridView_People.DataSource = Search_TrainingPersonDetail(str);
        GridView_People.DataBind();
    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        LblCondition.Text = TxtSYear.Text.Trim() == "" ? " " : " and TYPM_Year = '" + TxtSYear.Text.Trim() + "'";
        LblCondition.Text += TxtSMonth.Text.Trim() == "" ? " " : " and TID_Month = '" + TxtSMonth.Text.Trim() + "'";
        LblCondition.Text += TxtSType.Text.Trim() == "" ? " " : " and TTT_Type like '%" + TxtSType.Text.Trim() + "%'";
        LblCondition.Text += TxtSItem.Text.Trim() == "" ? " " : " and TID_TLesson like '%" + TxtSItem.Text.Trim() + "%'";
        LblCondition.Text += TxtSTeacher.Text.Trim() == "" ? " " : " and TID_Teacher like '%" + TxtSTeacher.Text.Trim() + "%'";
        LblCondition.Text += TxtSPlace.Text.Trim() == "" ? " " : " and TID_Place like '%" + TxtSPlace.Text.Trim() + "%'";
        LblCondition.Text += TxtSHours.Text.Trim() == "" ? " " : " and TID_CreditHours = '" + TxtSHours.Text.Trim() + "'";
        LblCondition.Text += TxtNO.Text.Trim() == "" ? " " : " and HRDD_StaffNO = '" + TxtNO.Text.Trim() + "'";
        LblCondition.Text += TxtName.Text.Trim() == "" ? " " : " and HRDD_Name like '%" + TxtName.Text.Trim() + "%'";
        LblCondition.Text += TextBox11.Text.Trim() == "" ? " " : " and TID_PTime >= '" + TextBox11.Text.Trim() + "'";

        LblCondition.Text += TextBox12.Text.Trim() == "" ? " " : " and TID_PTime <= '" + TextBox12.Text.Trim() + "'";

        LblRecordIsSearch.Text = "检索后";
        GridView_People.SelectedIndex = -1;
        BindGridView_People(LblCondition.Text);
        UpdatePanel2.Update();
    }
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        GridView_People.SelectedIndex = -1;
        LblRecordIsSearch.Text = "检索前";
        TxtSYear.Text = "";
        TxtSMonth.Text = "";
        TxtSType.Text = "";
        TxtSItem.Text = "";
        TxtSTeacher.Text = "";
        TxtSPlace.Text = "";
        TxtSHours.Text = "";
        TxtNO.Text = "";
        TxtName.Text = "";
        TextBox11.Text = "";
        TextBox12.Text = "";
        BindGridView_People("");
        UpdatePanel2.Update();
    }
    protected void GridView_People_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView_People.BottomPagerRow;


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
        //Grid_Post.DataBind();
        if (LblRecordIsSearch.Text == "检索前")
            BindGridView_People("");
        if (LblRecordIsSearch.Text == "检索后")
            BindGridView_People(LblCondition.Text);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView_People.PageCount ? GridView_People.PageCount - 1 : newPageIndex;
        GridView_People.PageIndex = newPageIndex;
        GridView_People.DataBind();
    }


    protected void GridView_People_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView_People.Rows.Count; i++)
        {
            for (int j = 0; j < GridView_People.Rows[i].Cells.Count; j++)
            {
                GridView_People.Rows[i].Cells[j].ToolTip = GridView_People.Rows[i].Cells[j].Text;
                if (GridView_People.Rows[i].Cells[j].Text.Length > 10)
                {
                    GridView_People.Rows[i].Cells[j].Text = GridView_People.Rows[i].Cells[j].Text.Substring(0, 10) + "...";
                }
            }
        }
    }
}