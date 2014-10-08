using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class ExperimentTest_ETExpSampleMgt : Page
{
    ExpTestL expTestL = new ExpTestL();
    ExpSampleType_ExpItems expSampleType_ExpItems = new ExpSampleType_ExpItems();
    static Guid id = new Guid();
    static string Bindc = "";//记录检索栏检索条件用于绑定gridview1数据
    #region 页面加载
    protected void Page_Load(object sender, EventArgs e)
    {
        string Role = Request.QueryString["state"].ToString();
        if (!IsPostBack)
        {
            Title = "样品类型维护页面";
            if (!((Session["UserRole"].ToString().Contains("样品类型维护")) || (Session["UserRole"].ToString().Contains("样品类型查看"))))
            {
                Response.Redirect("~/Default.aspx");
            }
        }        
        if (Role == "Sample" && Session["UserRole"].ToString().Contains("样品类型维护"))
        {
            Button2.Visible = true;
            Grid_SampleType.Columns[3].Visible = true;
            Grid_SampleType.Columns[4].Visible = true;
        }
        else if (Role == "Sample" && Session["UserRole"].ToString().Contains("样品类型查看"))
        {
            Button2.Visible = false;
            Grid_SampleType.Columns[3].Visible = false;
            Grid_SampleType.Columns[4].Visible = false;
        }
        BindGridview(Bindc);
        UpdatePanel_SampleType.Update();
    }
    #endregion

    #region 检索栏
    //检索栏，新增样品类型按钮
    protected void BtnNew_Click(object sender, EventArgs e)
    {
        Clear();
        //this.Info_EMFM_Code.Text = Guid.NewGuid().ToString();
        LblNewSampletype.Text = "新建样品类型";
        Panel_NewSampletype.Visible = true;
        UpdatePanel_NewSampletype.Update();
        LblState.Text = "New";
    }

    //检索栏，检索按钮
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        Bindc = TxtSampleType.Text;
        BindGridview(Bindc);
        UpdatePanel_SampleType.Update();
    }

    //检索栏，重置按钮
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        TxtSampleType.Text = "";
        Bindc = "";
        BindGridview(Bindc);
        UpdatePanel_SampleType.Update();
    }
    #endregion

    #region 维护窗口
    //维护窗口，提交按钮
    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        if (LblState.Text == "New")
        {
            expSampleType_ExpItems.EST_SampleTypeID= Guid.NewGuid();
            if (TxtNewSampletype.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            else if (TextLength(TxtNewSampletype.Text) > 50)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入字数不要超过25个！')", true);
                return;
            }
            else
                expSampleType_ExpItems.EST_SampleType = TxtNewSampletype.Text;

            expSampleType_ExpItems.EST_IsDeleted = false;
            try
            {
                if (expTestL.Insert_ExpSampleType(expSampleType_ExpItems) <= 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('该样品类型已经存在！')", true);
                    return;
                }
                //expTestL.Insert_ExpSampleType(expSampleType_ExpItems);
            }
            catch (Exception exc)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('新增失败！" + exc + "')", true);
            }
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('提交成功！')", true);
            Clear();
            Bindc = "";
            BindGridview(Bindc);
            Panel_NewSampletype.Visible = false;
            UpdatePanel_SampleType.Update();
            UpdatePanel_NewSampletype.Update();


        }
        if (LblState.Text == "Edit")
        {
            ExpSampleType_ExpItems ST = new ExpSampleType_ExpItems();
            if (TxtNewSampletype.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            else if(TextLength(TxtNewSampletype.Text)>50)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入字数不要超过25个！')", true);
                return;
            }
            else
                ST.EST_SampleType = TxtNewSampletype.Text;
            ST.EST_SampleTypeID = id;
            try
            {
                if (expTestL.Update_ExpSampleType(ST) <= 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('该样品类型已经存在！')", true);
                    return;
                }
                //expTestL.Update_ExpSampleType(ST);
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('编辑失败！" + ex + "')", true);
                return;
            }
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('提交成功！')", true);
            Clear();
            BindGridview(Bindc);
            Panel_NewSampletype.Visible = false;
            UpdatePanel_SampleType.Update();
            UpdatePanel_NewSampletype.Update();
        }
    }

    //维护窗口取消按钮
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        if (Panel_NewSampletype.Visible)
        {
            Panel_NewSampletype.Visible = false;
        }
    }
    #endregion

    #region GridView
    //Gridview翻页
    protected void Grid_SampleType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_SampleType.BottomPagerRow;


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
        BindGridview(Bindc);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_SampleType.PageCount ? Grid_SampleType.PageCount - 1 : newPageIndex;
        Grid_SampleType.PageIndex = newPageIndex;
        Grid_SampleType.PageIndex = newPageIndex;
        Grid_SampleType.DataBind();
    }

    //GridView中编辑、删除
    protected void Grid_SampleType_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit_Sampletype")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_SampleType.SelectedIndex = row.RowIndex;
            Clear();
            Panel_NewSampletype.Visible = true;
            UpdatePanel_NewSampletype.Update();
            LblState.Text = "Edit";
            id = new Guid(e.CommandArgument.ToString());
            ExpSampleType_ExpItems ST = expTestL.Search_ExpSampleType_ID(id)[0];
            LblNewSampletype.Text = ST.EST_SampleType + " 编辑";
            TxtNewSampletype.Text = ST.EST_SampleType;
            UpdatePanel_NewSampletype.Update();
        }
        if (e.CommandName == "Delete_Sampletype")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_SampleType.SelectedIndex = row.RowIndex;
            Guid guid = new Guid(e.CommandArgument.ToString());
            expTestL.Delete_ExpSampleType(guid);
            BindGridview(Bindc);
            UpdatePanel_SampleType.Update();
        }
    }

    //悬浮框显示
    protected void Grid_SampleType_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Grid_SampleType.Rows.Count; i++)
        {
            for (int j = 0; j < Grid_SampleType.Rows[i].Cells.Count; j++)
            {
                Grid_SampleType.Rows[i].Cells[j].ToolTip = Grid_SampleType.Rows[i].Cells[j].Text;
                if (Grid_SampleType.Rows[i].Cells[j].Text.Length > 15)
                {
                    Grid_SampleType.Rows[i].Cells[j].Text = Grid_SampleType.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }
            }
        }
    }
    #endregion

    #region 私有调用函数
    //计算文本长度
    public static int TextLength(string strText)
    {
        int intLen = 0;
        if (!String.IsNullOrEmpty(strText))
        {
            for (int i = 0; i < strText.Length; i++)
            {
                byte[] bytelen = Encoding.Default.GetBytes(strText.Substring(i, 1));
                if (bytelen.Length > 1)
                    intLen += 2;  //如果长度大于1，是中文，占两个字节，+2   
                else
                    intLen += 1;  //如果长度等于1，是英文，占一个字节，+1   
            }
        }
        return intLen;
    }

    //绑定Gridview，用于刷新GridView
    private void BindGridview(string EST_SampleType)
    {
        Grid_SampleType.DataSource = expTestL.Search_ExpSampleType_GridView(EST_SampleType);
        Grid_SampleType.DataBind();
    }

    //清空维护窗口
    private void Clear()
    {
        TxtNewSampletype.Text = "";
    }
    #endregion
}