using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TrainningMgt_TrainingTypeMaintenance : Page
{
    TrainingTypeMaintenanceL trainingTypeMaintenanceL = new TrainingTypeMaintenanceL();
    private static string Condition;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Username"] == null)
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('您长时间未操作，请重新登录！')", true);
            Response.Redirect("~/Default.aspx");
        }
        #region//权限控制
        if (!(Session["UserRole"].ToString().Contains("培训类型维护")))
        {
            Response.Redirect("~/Default.aspx");

        }
        if (Request.QueryString["status"] == "TraType")
        {
            Title = "培训类型维护";
        }
        #endregion



        if (!IsPostBack)
        {
            BindGrid_Type("");
        }
    }

    #region//绑定Gridview的方法
    private void BindGrid_Type(string Condition)
    {
        Grid_Type.DataSource = trainingTypeMaintenanceL.Search_TrainingTypeTable(Condition);
        Grid_Type.DataBind();
    }//员工类型列表Grid_Type
    #endregion

    #region//培训类型检索栏
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        LblRecordIsSearch.Text = "检索后";
        Grid_Type.SelectedIndex = -1;
        Condition = TxtSType.Text.Trim() == "" ? " " : " and TTT_Type like '%" + TxtSType.Text.Trim() + "%'";
        BindGrid_Type(Condition);
        UpdatePanel2.Update();
    }//检索
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        Grid_Type.SelectedIndex = -1;
        TxtSType.Text = "";
        LblRecordIsSearch.Text = "检索前";
        BindGrid_Type("");
        UpdatePanel2.Update();
    }//重置
    protected void BtnNew_Click(object sender, EventArgs e)
    {
        Panel3.Visible = true;
        TxtNewType.Text = "";
        Label3.Text = "新增";
        UpdatePanel3.Update();
    }//新增培训类型
    #endregion

    #region//Grid_Type的内置事件
    protected void Grid_Type_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Grid_Type.Rows.Count; i++)
        {
            for (int j = 0; j < Grid_Type.Rows[i].Cells.Count; j++)
            {
                Grid_Type.Rows[i].Cells[j].ToolTip = Grid_Type.Rows[i].Cells[j].Text;
                if (Grid_Type.Rows[i].Cells[j].Text.Length > 15)
                {
                    Grid_Type.Rows[i].Cells[j].Text = Grid_Type.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }
            }
        }
    }
    protected void Grid_Type_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit_Type")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_Type.SelectedIndex = row.RowIndex;

            Panel3.Visible = true;
            UpdatePanel3.Update();
            Label3.Text = "编辑";
            Label17.Text = e.CommandArgument.ToString();
            TrainningTypeMantenanceInfo nE = trainingTypeMaintenanceL.SearchByID_TrainingTypeTable(new Guid(Label17.Text))[0];
            TxtNewType.Text = nE.TTT_Type;

        }
        if (e.CommandName == "Delete_Type")
        {
            Grid_Type.SelectedIndex = -1;
            Guid guid = new Guid(e.CommandArgument.ToString());
            trainingTypeMaintenanceL.Delete_TrainingTypeTable(guid);
            if (LblRecordIsSearch.Text == "检索前")
                BindGrid_Type("");
            if (LblRecordIsSearch.Text == "检索后")
                BindGrid_Type(Condition);
            UpdatePanel2.Update();
        }
    }
    protected void Grid_Type_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_Type.BottomPagerRow;


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
            BindGrid_Type("");
        if (LblRecordIsSearch.Text == "检索后")
            BindGrid_Type(Condition);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_Type.PageCount ? Grid_Type.PageCount - 1 : newPageIndex;
        Grid_Type.PageIndex = newPageIndex;
        Grid_Type.DataBind();
    }
    #endregion


    #region//培训类型XX
    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        if (Label3.Text == "新增")
        {
            if (TxtNewType.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            TrainningTypeMantenanceInfo tInfo = new TrainningTypeMantenanceInfo();
            tInfo.TTT_Type = TxtNewType.Text;
            try
            {
                if (trainingTypeMaintenanceL.Insert_TrainingTypeTable(tInfo) <= 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('存在重复的培训类型，请核实！')", true);

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('新增成功！')", true);
                    Panel3.Visible = false;
                    UpdatePanel3.Update();
                    if (LblRecordIsSearch.Text == "检索前")
                        BindGrid_Type("");
                    if (LblRecordIsSearch.Text == "检索后")
                        BindGrid_Type(Condition);
                    UpdatePanel2.Update();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('新增失败！"+ex.ToString()+"')", true);
            }
            
        }
        if (Label3.Text == "编辑")
        {
            TrainningTypeMantenanceInfo tInfo = new TrainningTypeMantenanceInfo();
            tInfo.TTT_Type = TxtNewType.Text;
            tInfo.TTT_TypeID = new Guid(Label17.Text);
            try
            {
                if (trainingTypeMaintenanceL.Update_TrainingTypeTable(tInfo) <= 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this,GetType(),"alert", "alert('存在重复的培训类型，请核实！')", true);

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('编辑成功！')", true);
                    if (LblRecordIsSearch.Text == "检索前")
                        BindGrid_Type("");
                    if (LblRecordIsSearch.Text == "检索后")
                        BindGrid_Type(Condition);
                    UpdatePanel2.Update();
                    UpdatePanel3.Update();
                    Panel3.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('编辑失败！" + ex + "')", true);
            }
        }
        
    }
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        Panel3.Visible = false;
        UpdatePanel3.Update();
    }
    #endregion
}