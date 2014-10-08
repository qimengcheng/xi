using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HRFilesMgt_HRPostMaintance : Page
{
    HRFilesMgtL hRFilesMgtL = new HRFilesMgtL();
    HRFilesMgtInfo hRFilesMgtInfo = new HRFilesMgtInfo();
    private static Guid id;
    private static string s="";
    protected void Page_Load(object sender, EventArgs e)
    {
        #region//权限控制
        if (!((Session["UserRole"].ToString().Contains("人事岗位维护")) || (Session["UserRole"].ToString().Contains("人事岗位查看"))))
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Request.QueryString["status"] == "postLook")
        {
            Grid_Post.Columns[4].Visible = false;
            Grid_Post.Columns[5].Visible = false;
            BtnNew.Visible = false;
            Title = "人事岗位查看";

        }
        if (Request.QueryString["status"] == "postMain")
        {
            Title = "人事岗位维护";

        }
        #endregion


        if (!IsPostBack)
        {
            
            Bind_Ddlst(DdlDep);
            BindGridview("", "");
        }

    }
    protected void BtnNew_Click(object sender, EventArgs e)
    {
        Clear();
        //this.Info_EMFM_Code.Text = Guid.NewGuid().ToString();
        Panel_NewPost.Visible = true;
        UpdatePanel_NewPost.Update();
        Bind_Ddlst(DdlNewDep);
        LblState.Text = "New";

    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        s = DdlDep.SelectedItem.ToString() == "请选择" ? "" : DdlDep.SelectedItem.ToString();

        Grid_Post.DataSource = hRFilesMgtL.Search_HRPost(s, TxtPost.Text);
        Grid_Post.DataBind();
        LblRecordIsSearch.Text = "检索后";
        Grid_Post.SelectedIndex = -1;//如果Grid_Post存在行加黑，则取消加黑
        UpdatePanel_Post.Update();
    }
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        Grid_Post.SelectedIndex = -1;//如果Grid_Post存在行加黑，则取消加黑
        TxtPost.Text = "";
        DdlDep.ClearSelection();
        BindGridview("", "");
        LblRecordIsSearch.Text = "检索前";
        s = "";
        UpdatePanel_Post.Update();
    }
    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        if (LblState.Text == "New")
        {
            if (DdlNewDep.SelectedValue == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请选择部门！')", true);
                return;
            }
            else
                hRFilesMgtInfo.BDOS_Code = DdlNewDep.SelectedValue;
            hRFilesMgtInfo.HRP_ID = Guid.NewGuid();
            if (TxtNewPost.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入岗位！')", true);
                return;
            }
            else
                hRFilesMgtInfo.HRP_Post = TxtNewPost.Text;

            hRFilesMgtInfo.HRP_IsDeleted = false;
            int i;
            try
            {
                i = hRFilesMgtL.Insert_HRPost(hRFilesMgtInfo);
                if (i <= 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('该部门下已存在的岗位，请核实！')", true);
                    return;
                }
                else
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('新增成功！')", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('新增失败！" + ex + "')", true);
            }
            Clear();
            if (LblRecordIsSearch.Text == "检索前")
                BindGridview("", "");
            if (LblRecordIsSearch.Text == "检索后")
                BindGridview(s, TxtPost.Text);
            Panel_NewPost.Visible = false;
            UpdatePanel_Post.Update();
            UpdatePanel_NewPost.Update();


        }
        if (LblState.Text == "Edit")
        {
            HRFilesMgtInfo hr = new HRFilesMgtInfo();
            if (DdlNewDep.SelectedValue == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请选择部门！')", true);
                return;
            }
            else
                hr.BDOS_Code = DdlNewDep.SelectedValue.ToString();

            if (TxtNewPost.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入岗位！')", true);
                return;
            }
            else
                hr.HRP_Post = TxtNewPost.Text;
            hr.HRP_ID = id;
            int u;
            try
            {
                u = hRFilesMgtL.Update_HRPost(hr);
                if (u <= 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('该部门下已存在的岗位，请核实！')", true);
                    return;
                }
                else
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('编辑成功')", true);
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('编辑失败！" + ex + "')", true);
            }
            Clear();
            if (LblRecordIsSearch.Text == "检索前")
                BindGridview("", "");
            if (LblRecordIsSearch.Text == "检索后")
                BindGridview(s, TxtPost.Text);
            Panel_NewPost.Visible = false;
            UpdatePanel_Post.Update();

        }
    }
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        if (Panel_NewPost.Visible)
        {
            Panel_NewPost.Visible = false;
        }
    }

    //绑定Gridview
    private void BindGridview(string BDOS_Name, string HRP_Post)
    {
        string sortExpression = Grid_Post.Attributes["SortExpression"];
        string sortDirection = Grid_Post.Attributes["SortDirection"];
        Grid_Post.DataSource = hRFilesMgtL.Search_HRPost(BDOS_Name, HRP_Post);
        Grid_Post.DataBind();
    }
    //绑定Dropdownlist中的DdlstAddDep——动态
    private void Bind_Ddlst(DropDownList Ddl)
    {
        Ddl.DataSource = hRFilesMgtL.Search_HRPost_BDOrganizationSheet().Tables[0].DefaultView;
        Ddl.DataTextField = "BDOS_Name";
        Ddl.DataValueField = "BDOS_Code";
        Ddl.DataBind();
        Ddl.Items.Insert(0, new ListItem("请选择", ""));
    }
    //私有清空的方法
    private void Clear()
    {
        TxtNewPost.Text = "";
        DdlNewDep.ClearSelection();

    }

    //Gridview翻页
    protected void Grid_Post_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_Post.BottomPagerRow;


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
            BindGridview("", "");
        if (LblRecordIsSearch.Text == "检索后")
            BindGridview(s, TxtPost.Text);

        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_Post.PageCount ? Grid_Post.PageCount - 1 : newPageIndex;
        Grid_Post.PageIndex = newPageIndex;
        Grid_Post.PageIndex = newPageIndex;
        Grid_Post.DataBind();
    }

    protected void Grid_Post_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit_Post")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_Post.SelectedIndex = row.RowIndex;

            Clear();

            Panel_NewPost.Visible = true;

            UpdatePanel_NewPost.Update();
            LblState.Text = "Edit";
            ////为Dropdownlist绑定值，否则会出错
            Bind_Ddlst(DdlNewDep);
            id = new Guid(e.CommandArgument.ToString());

            HRFilesMgtInfo hR = hRFilesMgtL.SearchByID_HRPost_BDOrganizationSheet(id)[0];
            TxtNewPost.Text = hR.HRP_Post;
            DdlNewDep.SelectedValue = hR.BDOS_Code;
            UpdatePanel_NewPost.Update();

        }
        if (e.CommandName == "Delete_Post")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_Post.SelectedIndex = -1;

            Guid guid = new Guid(e.CommandArgument.ToString());
            hRFilesMgtL.Delete_HRPost(guid);
            BindGridview("", "");
        }
    }

    protected void Grid_Post_RowCreated(object sender, GridViewRowEventArgs e)
    {


    }
    protected void Grid_Post_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
    protected void Grid_Post_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Grid_Post.Rows.Count; i++)
        {
            for (int j = 0; j < Grid_Post.Rows[i].Cells.Count; j++)
            {
                Grid_Post.Rows[i].Cells[j].ToolTip = Grid_Post.Rows[i].Cells[j].Text;
                if (Grid_Post.Rows[i].Cells[j].Text.Length > 15)
                {
                    Grid_Post.Rows[i].Cells[j].Text = Grid_Post.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }


            }
        }
    }
}