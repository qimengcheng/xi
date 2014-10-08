using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ExperimentTest_ETExpTestBasicInfoMgt : Page
{
    ExpTestL expTestL = new ExpTestL();
    ExpSampleType_ExpItems expSampleType_ExpItems = new ExpSampleType_ExpItems();
    static Guid id = new Guid();
    static string Bindc1 = "", Bindc2 = "", Bindc3 = "";//记录检索栏检索条件用于绑定gridview数据

    #region 页面加载
    //页面加载
    protected void Page_Load(object sender, EventArgs e)
    {
        BindGridview(Bindc1, Bindc2, Bindc3);
        string Role = Request.QueryString["state"].ToString();
        if (!Page.IsPostBack)
        {
            if (!((Session["UserRole"].ToString().Contains("实验项目维护")) || (Session["UserRole"].ToString().Contains("实验项目查看"))))
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        if (Role == "Item" && Session["UserRole"].ToString().Contains("实验项目维护"))
        {
            Title = "实验项目维护";
        }
        else if (Role == "Item" && Session["UserRole"].ToString().Contains("实验项目查看"))
        {
            Title = "实验项目查看";
            Btn_NEW_ETExpItem.Visible = false;
            Grid_ETTestItem.Columns[5].Visible = false;
            Grid_ETTestItem.Columns[6].Visible = false;
        }
    }
    #endregion

    #region 检索栏
    //检索栏检索按钮
    protected void Btn_Search_ETExpItem_Click(object sender, EventArgs e)
    {
        Bindc1 = TxtTestItem.Text;
        Bindc2 = TxtTestCondition.Text;
        Bindc3 = TxtTestMethold.Text;
        BindGridview(Bindc1, Bindc2, Bindc3);
        UpdatePanel_GridViewItem.Update();
    }

    //检索栏新增按钮
    protected void Btn_NEW_ETExpItem_Click(object sender, EventArgs e)
    {
        Clear();
        LblNewExpItem.Text = "新建实验项目";
        Panel_NewExpItem.Visible = true;
        UpdatePanel_NewExpItem.Update();
        LblState.Text = "New";
    }

    //重置
    protected void Btn_Clear_Click(object sender, EventArgs e)
    {
        TxtTestItem.Text = "";
        TxtTestCondition.Text = "";
        TxtTestMethold.Text = "";
        UpdatePanel_SearchExpItem.Update();
        Bindc3 = Bindc2 = Bindc1 = "";
        BindGridview(Bindc1, Bindc2, Bindc3);
        UpdatePanel_GridViewItem.Update();
    }
    #endregion

    #region 维护窗口
    //维护窗口提交按钮
    protected void BtnOK_ETItem_Click(object sender, EventArgs e)
    {
        if (LblState.Text == "New")
        {

            if (TxtAddTestItem.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            else
                expSampleType_ExpItems.EI_ExpItem = TxtAddTestItem.Text;
            if (TxtAddTestCondition.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            else
                expSampleType_ExpItems.EI_ExpCondtition = TxtAddTestCondition.Text;
            if (TxtAddTestMethold.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            else
                expSampleType_ExpItems.EI_ExpMethold = TxtAddTestMethold.Text;
            try
            {
                if (expTestL.Insert_ExpItems(expSampleType_ExpItems) <= 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('该实验项目已经存在！')", true);
                    return;
                }
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('编辑失败！" + ex + "')", true);
                return;
            }
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('提交成功！')", true);
            Clear();
            Bindc1 = Bindc2 = Bindc3 = "";
            BindGridview(Bindc1, Bindc2, Bindc3);
            Panel_NewExpItem.Visible = false;
            UpdatePanel_NewExpItem.Update();
            UpdatePanel_GridViewItem.Update();

        }
        else if (LblState.Text == "Edit")
        {
            ExpSampleType_ExpItems Exp1 = new ExpSampleType_ExpItems();
            Exp1.EI_ExpItemID = id;
            Exp1.EI_IsDeleted = false;
            if (TxtAddTestItem.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            else
                Exp1.EI_ExpItem = TxtAddTestItem.Text;
            if (TxtAddTestCondition.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            else
                Exp1.EI_ExpCondtition = TxtAddTestCondition.Text;
            if (TxtAddTestMethold.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            else
                Exp1.EI_ExpMethold = TxtAddTestMethold.Text;
            try
            {
                if (expTestL.Update_ExpItems(Exp1) <= 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('该实验项目已经存在！')", true);
                    return;
                }
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('编辑失败！" + ex + "')", true);
                return;
            }
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('提交成功！')", true);
            Clear();
            BindGridview(Bindc1, Bindc2, Bindc3);
            UpdatePanel_NewExpItem.Update();
            UpdatePanel_GridViewItem.Update();
            Panel_NewExpItem.Visible = false;
        }

    }

    //维护窗口取消按钮
    protected void BtnCancel_Info_FailureMode_Click(object sender, EventArgs e)
    {
        if (Panel_NewExpItem.Visible)
        {
            Panel_NewExpItem.Visible = false;
        }
    }
    #endregion

    #region GridView
    //操作Gridview的命令行
    protected void Grid_ETTestItem_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Edt_ExpItem")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_ETTestItem.SelectedIndex = row.RowIndex;
            Panel_NewExpItem.Visible = true;
            UpdatePanel_NewExpItem.Update();
            LblState.Text = "Edit";
            GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            //this.Grid_BDOrgSheet_1.Rows[gvr.RowIndex].BackColor = System.Drawing.Color.SkyBlue;
            //Session["index"] = gvr.RowIndex;
            id = new Guid(e.CommandArgument.ToString());
            ExpSampleType_ExpItems exp = expTestL.Search_ExpItems_ID(id)[0];
            LblNewExpItem.Text = exp.EI_ExpItem + " 编辑";
            TxtAddTestItem.Text = exp.EI_ExpItem;
            TxtAddTestCondition.Text = exp.EI_ExpCondtition;
            TxtAddTestMethold.Text = exp.EI_ExpMethold;
            UpdatePanel_NewExpItem.Update();

        }
        if (e.CommandName == "Delete_ExpItem")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_ETTestItem.SelectedIndex = row.RowIndex;
            Guid guid = new Guid(e.CommandArgument.ToString());
            expTestL.Delete_ExpItems(guid);
            BindGridview(Bindc1, Bindc2, Bindc3);
            UpdatePanel_GridViewItem.Update();
        }

    }
    //悬浮框显示
    protected void Grid_ETTestItem_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Grid_ETTestItem.Rows.Count; i++)
        {
            //for (int j = 0; j < Grid_ETTestItem.Rows[i].Cells.Count; j++)
            //{
            //    Grid_ETTestItem.Rows[i].Cells[j].ToolTip = Grid_ETTestItem.Rows[i].Cells[j].Text;
            //    if (Grid_ETTestItem.Rows[i].Cells[j].Text.Length > 25)
            //    {
            //        Grid_ETTestItem.Rows[i].Cells[j].Text = Grid_ETTestItem.Rows[i].Cells[j].Text.Substring(0, 25) + "...";
            //    }
            //}
            Grid_ETTestItem.Rows[i].Cells[4].ToolTip = Grid_ETTestItem.Rows[i].Cells[4].Text;
            if (Grid_ETTestItem.Rows[i].Cells[4].Text.Length > 15)
            {
                Grid_ETTestItem.Rows[i].Cells[4].Text = Grid_ETTestItem.Rows[i].Cells[4].Text.Substring(0, 15) + "...";
            }
            Grid_ETTestItem.Rows[i].Cells[3].ToolTip = Grid_ETTestItem.Rows[i].Cells[3].Text;
            if (Grid_ETTestItem.Rows[i].Cells[3].Text.Length > 60)
            {
                Grid_ETTestItem.Rows[i].Cells[3].Text = Grid_ETTestItem.Rows[i].Cells[3].Text.Substring(0, 60) + "...";
            }
        }

    }

    //翻页
    protected void Grid_ETTestItem_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_ETTestItem.BottomPagerRow;


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
        BindGridview(Bindc1, Bindc2, Bindc3);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_ETTestItem.PageCount ? Grid_ETTestItem.PageCount - 1 : newPageIndex;
        Grid_ETTestItem.PageIndex = newPageIndex;
        Grid_ETTestItem.PageIndex = newPageIndex;
        Grid_ETTestItem.DataBind();
    }
    #endregion

    #region 私有调用函数
    //绑定实验申请Gridview，用于刷新GridView
    private void BindGridview(string condition1, string condition2, string condition3)
    {
        Grid_ETTestItem.DataSource = expTestL.Search_ExpItems_Gridview(condition1, condition2, condition3);
        Grid_ETTestItem.DataBind();
    }

    //私有清空的方法
    private void Clear()
    {
        TxtAddTestItem.Text = "";
        TxtAddTestCondition.Text = "";
        TxtAddTestMethold.Text = "";
    }
    #endregion

}