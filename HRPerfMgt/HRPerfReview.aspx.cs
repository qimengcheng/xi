using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HRPerfMgt_HRPerfReview : Page
{
    private static string con1;
    private static string condition;
    HRPerformceDetailL hRPerformceDetailL = new HRPerformceDetailL();
    HRPItemScoreL hRPItemScoreL = new HRPItemScoreL();
    HRDDetailL hRDDetailL = new HRDDetailL();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!((Session["UserRole"].ToString().Contains("绩效考核结果查看"))))
        {
            Response.Redirect("~/Default.aspx");

        }
        if (Request.QueryString["status"] == "PerReview")
        {
            Title = "绩效考核结果查看";
        }
        if (!IsPostBack)
        {
            BindYear(DropDownList3);
            BindDdlMonth(DropDownList4);
            //BindGridForEmployee(GridView2, "");
            BindGrid_Detail("");
            Bind_DdlDep(DdlSearchDep);
            Bind_DdlPost(DdlSearchPost,"");
        }

    }

    #region//帮顶下拉菜单
    private void BindYear(DropDownList ddl)
    {
        ddl.Items.Clear();
        for (int m = 2012; m <= 2035; m++)
        {
            ddl.Items.Add(new ListItem(m.ToString(), m.ToString()));
        }
        ddl.Items.Insert(0, new ListItem("请选择", ""));
        ddl.DataBind();
    }//绑定年

    private void BindDdlMonth(DropDownList ddl)
    {
        ddl.Items.Clear();
        for (int m = 1; m <= 12; m++)
        {
            ddl.Items.Add(new ListItem(m.ToString(), m.ToString()));
        }
        ddl.Items.Insert(0, new ListItem("请选择", ""));
        ddl.DataBind();
    }//绑定月份

    private void Bind_DdlDep(DropDownList ddl)
    {
        ddl.DataSource = hRDDetailL.SearchDdl_HRDDetail_BDOrganizationSheet().Tables[0].DefaultView;
        ddl.DataTextField = "BDOS_Name";
        ddl.DataValueField = "BDOS_Code";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("请选择", ""));
    }//绑定Dropdownlist中的DdlDep——部门，参数是欲绑定的Dropdownlist

    private void Bind_DdlPost(DropDownList ddl, string BDOS_Code)
    {
        ddl.DataSource = hRDDetailL.SearchDdl_HRDDetail(BDOS_Code).Tables[0].DefaultView;
        ddl.DataTextField = "HRP_Post";
        ddl.DataValueField = "HRP_ID";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("请选择", ""));
    }//绑定Dropdownlist中的DdlDep——岗位,参数是欲绑定岗位的DropDownList和部门代码

    protected void DdlSearchDep_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind_DdlPost(DdlSearchPost, DdlSearchDep.SelectedValue.ToString());
    }//DdropdownList二级联动:根据部门中的选项，实现下级自动绑定（要实现此方法，前台必须设定触发器,以及该事件源的控件的属性AuotoPostback为true）
    #endregion
    #region//GridView_Detail的帮顶
    private void BindGrid_Detail(string condition)
    {
        Grid_Detail.DataSource = hRPerformceDetailL.Search_HRDDetail_HRPerformceDetail(condition);
       Grid_Detail.DataBind();
    }
    #endregion
    #region//检索、重置、提交和取消事件
    protected void BtnSearchEmployee_Click(object sender, EventArgs e)
    {
        con1 = TxtSearchStaffNO.Text.Trim() == "" ? "" : " and HRDD_StaffNO like '%" + TxtSearchStaffNO.Text.Trim() + "%'";
        con1 += TxtSearchName.Text.Trim() == "" ? "" : " and HRDD_Name like '%" + TxtSearchName.Text.Trim() + "%'";
        con1 += DdlSearchDep.SelectedValue == "" ? "" : " and HRPost.BDOS_Code ='" + DdlSearchDep.SelectedValue + "'";
        con1 += DdlSearchPost.SelectedValue == "" ? "" : " and HRDDetail.HRP_ID ='" + DdlSearchPost.SelectedValue + "'";
        con1 += DropDownList3.SelectedValue == "" ? "" : " and HRPerformceDetail.HRPD_Year ='" + DropDownList3.SelectedValue + "'";
        con1 += DropDownList4.SelectedValue == "" ? "" : " and HRPerformceDetail.HRPD_Month ='" + DropDownList4.SelectedValue + "'";
        try
        {
            BindGrid_Detail(con1);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        LblStateForGrid_Type.Text = "检索后";
        UpdatePanel_SearchEmployee.Update();
      

    }
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        DdlSearchDep.ClearSelection();
        DdlSearchPost.ClearSelection();
        DropDownList3.ClearSelection();
        DropDownList4.ClearSelection();
        TxtSearchStaffNO.Text = "";
        TxtSearchName.Text = "";
        BindGrid_Detail("");
        LblStateForGrid_Type.Text = "检索前";
        UpdatePanel_SearchEmployee.Update();
    }
    protected void Btnclose_Click(object sender, EventArgs e)
    {
        Panel2.Visible = false;
    }
    #endregion
    #region//Grid_Detail中的RowCommand
    protected void Grid_Detail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit1")
        {
            Panel2.Visible = true;
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_Detail.SelectedIndex = row.RowIndex;
            Label2.Text = e.CommandArgument.ToString();
            Guid guid = new Guid(Label2.Text);
            BindGridForEmployee(GridView2,guid);
            UpdatePanel2.Update();
        }
    }//
    #endregion

    #region//GridView中的DataBound
    protected void GridView2_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView2.Rows.Count; i++)
        {
            for (int j = 0; j < GridView2.Rows[i].Cells.Count; j++)
            {
                GridView2.Rows[i].Cells[j].ToolTip = GridView2.Rows[i].Cells[j].Text;
                if (GridView2.Rows[i].Cells[j].Text.Length > 15)
                {
                    GridView2.Rows[i].Cells[j].Text = GridView2.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }

            }
        }
    }

    protected void Grid_Detail_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Grid_Detail.Rows.Count; i++)
        {
            for (int j = 0; j < Grid_Detail.Rows[i].Cells.Count; j++)
            {
                Grid_Detail.Rows[i].Cells[j].ToolTip = Grid_Detail.Rows[i].Cells[j].Text;
                if (Grid_Detail.Rows[i].Cells[j].Text.Length > 15)
                {
                    Grid_Detail.Rows[i].Cells[j].Text = Grid_Detail.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }


            }
        }
    }//员工列表的databound
    #endregion
    #region//翻页
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView2.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox2");   // refer to the TextBox with the NewPageIndex value
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
        ////Grid_Post.DataBind();
        //if (LblStateForGrid_Type.Text == "检索前")
        //{
        //    BindGridForEmployee(GridView2, "");
        //}
        //if (LblStateForGrid_Type.Text == "检索后")
        //{
        //    BindGridForEmployee(GridView2, con1);
        //}
        BindGridForEmployee(GridView2,new Guid(Label2.Text));

        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView2.PageCount ? GridView2.PageCount - 1 : newPageIndex;
        GridView2.PageIndex = newPageIndex;
        GridView2.PageIndex = newPageIndex;
        GridView2.DataBind();
    }//员工考核项目得分列表的翻页

    protected void Grid_Detail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_Detail.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox1");   // refer to the TextBox with the NewPageIndex value
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
        if (LblStateForGrid_Type.Text == "检索前")
        {
            //BindGridForEmployee(Grid_Detail, "");
            BindGrid_Detail("");
        }
        if (LblStateForGrid_Type.Text == "检索后")
        {
            //BindGridForEmployee(Grid_Detail,"");
            BindGrid_Detail(con1);
        }

        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_Detail.PageCount ? Grid_Detail.PageCount - 1 : newPageIndex;
        Grid_Detail.PageIndex = newPageIndex;
        Grid_Detail.PageIndex = newPageIndex;
        Grid_Detail.DataBind();
    }//员工考核总分列表的翻页
    #endregion

    #region//GridView2的绑定
    private void BindGridForEmployee(GridView gv,Guid guid)
    {
        gv.DataSource = hRPItemScoreL.Search_HRPItemScore_HRPerformceDetail(guid);
        gv.DataBind();
    }
    #endregion
}