using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TrainningMgt_NETItemMaintenance : Page
{
    NETtainningL nETtainningL = new NETtainningL();
    NETtainningInfo nETtainningInfo = new NETtainningInfo();
    static Guid id = new Guid();
    private static string str1;
    private static string str2;
    private static string str3; 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!((Session["UserRole"].ToString().Contains("新员工培训项目维护")) || (Session["UserRole"].ToString().Contains("新员工培训项目查看"))))
        {
            Response.Redirect("~/Default.aspx");

        }
        if (Request.QueryString["status"] == "itemsLook")
        {
            Grid_NETrainingItem.Columns[6].Visible = false;
            Grid_NETrainingItem.Columns[7].Visible = false;
            Btn_NEW_NETItem.Visible = false;
            Title = "新员工培训项目查看";
        }
        if (Request.QueryString["status"] == "itemsMain")
        {
            Title = "新员工培训项目维护";
        }
        if (!IsPostBack)
        {
            BindGridview();
        }


    }
    protected void Btn_Search_NETItem_Click(object sender, EventArgs e)
    {
        Grid_NETrainingItem.SelectedIndex = -1;
        LblIsSearch.Text = "检索后";
        str1 = TxtDep.Text;
        str2 = TxtCourse.Text;
        str3 = TxtType.Text;
        Grid_NETrainingItem.DataSource = nETtainningL.Search_NETrainingItem(str1, str2, str3);
        Grid_NETrainingItem.DataBind();
        UpdatePanel1.Update();
    }
    protected void Btn_NEW_NETItem_Click(object sender, EventArgs e)
    {
        Clear();
        Info_EMFM_Code.Text = Guid.NewGuid().ToString();
        Panel_NewItem.Visible = true;
        UpdatePanel_NewItem.Update();
        ////SetValueForDdlstAddType();
        //SetValueForDdlstAddDep();
        Bind_DdlstAddDep();
        LblState.Text = "New";
    }

    protected void BtnCancel_Info_FailureMode_Click(object sender, EventArgs e)
    {
        if (Panel_NewItem.Visible)
        {
            Panel_NewItem.Visible = false;
        }
    }
    protected void BtnOK_NETItem_Click(object sender, EventArgs e)
    {
        if (LblState.Text == "New")
        {
            if (TxtAddCourse.Text == "" || DdlstAddType.Text == "" || DdlstAddDep.Text == "" || TxtAddHours.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            nETtainningInfo.NETI_ID = Guid.NewGuid();
            if (TxtAddCourse.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入培训课程名称！')", true);
                return;
            }
            else
                nETtainningInfo.NETI_TraningCourse = TxtAddCourse.Text;
            nETtainningInfo.NETI_TraningType = DdlstAddType.SelectedValue;
            nETtainningInfo.BDOS_Code = DdlstAddDep.SelectedValue.ToString();
            decimal d;
            if (Decimal.TryParse(TxtAddHours.Text, out d))
                nETtainningInfo.NETI_CreditHours = d;
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的培训学时！')", true);
                return;
            }
            if (nETtainningInfo.NETI_CreditHours <= 0)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的培训学时！')", true);
                return;
            }

            nETtainningInfo.NETI_IsDeleted = false;
            if (nETtainningInfo.BDOS_Code == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请选择授课部门！')", true);
                return;
            }
            else if (nETtainningL.Insert_NETrainingItem(nETtainningInfo) > 0)
            {
                Clear();
                BindGridview();
                Panel_NewItem.Visible = false;
                UpdatePanel1.Update();
                UpdatePanel_NewItem.Update();
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('新增成功！')", true);
            }
            else
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('新增失败！')", true);
        }
        else if (LblState.Text == "Edit")
        {
            if (TxtAddCourse.Text == "" || DdlstAddType.Text == "" || DdlstAddDep.Text == "" || TxtAddHours.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            NETtainningInfo nET = new NETtainningInfo();
            nET.NETI_ID = id;
            nET.BDOS_Code = DdlstAddDep.SelectedValue.ToString();
            if (TxtAddCourse.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入培训课程名称！')", true);
                return;
            }
            else
                nET.NETI_TraningCourse = TxtAddCourse.Text;
            nET.NETI_TraningType = DdlstAddType.SelectedValue;
            decimal m;
            if (Decimal.TryParse(TxtAddHours.Text, out m))
                nET.NETI_CreditHours = m;
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的培训学时！')", true);
                return;
            }
            if (nET.NETI_CreditHours <= 0)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的培训学时！')", true);
                return;
            }
            try
            {
                nETtainningL.Update_NETrainingItem(nET);
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('编辑成功！')", true);
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('编辑失败！')", true);
                return;
            }

            Clear();
            BindGridview();
            Panel_NewItem.Visible = false;
            UpdatePanel_NewItem.Update();
            UpdatePanel1.Update();
        }

    }
    //私有清空的方法
    private void Clear()
    {
        TxtAddCourse.Text = "";
        DdlstAddType.ClearSelection();
        DdlstAddDep.ClearSelection();
        TxtAddHours.Text = "";

    }
    //Gridview翻页
    protected void Grid_NETrainingItem_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_NETrainingItem.BottomPagerRow;


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
        if (LblIsSearch.Text == "检索前")
        {
            BindGridview();
        }
        if (LblIsSearch.Text == "检索后")
        {
            Grid_NETrainingItem.DataSource = nETtainningL.Search_NETrainingItem(str1, str2, str3);
            Grid_NETrainingItem.DataBind();
        }
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_NETrainingItem.PageCount ? Grid_NETrainingItem.PageCount - 1 : newPageIndex;
        Grid_NETrainingItem.PageIndex = newPageIndex;
        Grid_NETrainingItem.DataBind();


    }
    //重置
    protected void Btn_Clear_Click(object sender, EventArgs e)
    {
        Grid_NETrainingItem.SelectedIndex = -1;
        LblIsSearch.Text = "检索前";
        TxtCourse.Text = "";
        TxtDep.Text = "";
        TxtType.Text = "";
        BindGridview();
        UpdatePanel1.Update();
    }
    //操作Gridview的命令行
    protected void Grid_NETrainingItem_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Edt_TraningCourse")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_NETrainingItem.SelectedIndex = row.RowIndex;

            Clear();
            Panel_NewItem.Visible = true;
            UpdatePanel_NewItem.Update();
            LblState.Text = "Edit";
            //为Dropdownlist绑定值，否则会出错
            Bind_DdlstAddDep();
            GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            //this.Grid_BDOrgSheet_1.Rows[gvr.RowIndex].BackColor = System.Drawing.Color.SkyBlue;
            //Session["index"] = gvr.RowIndex;
            id = new Guid(e.CommandArgument.ToString());
            NETtainningInfo nE = nETtainningL.SearchByID_NETrainingItem_BDOrganizationSheet(id)[0];
            TxtAddCourse.Text = nE.NETI_TraningCourse;
            DdlstAddType.SelectedValue = nE.NETI_TraningType;
            DdlstAddDep.SelectedValue = nE.BDOS_Code;
            TxtAddHours.Text = nE.NETI_CreditHours.ToString();
            UpdatePanel_NewItem.Update();

        }
        if (e.CommandName == "Delete_TraningCourse")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_NETrainingItem.SelectedIndex = -1;

            Guid guid = new Guid(e.CommandArgument.ToString());
            nETtainningL.Delete_NETrainingItem(guid);
            BindGridview();
        }

    }
    //绑定Dropdownlist中的DdlstAddDep——动态
    private void Bind_DdlstAddDep()
    {
        DdlstAddDep.DataSource = nETtainningL.Search_NETrainingItem_BDOrganizationSheet().Tables[0].DefaultView;
        DdlstAddDep.DataTextField = "BDOS_Name";
        DdlstAddDep.DataValueField = "BDOS_Code";
        DdlstAddDep.DataBind();
        DdlstAddDep.Items.Insert(0, new ListItem("请选择", ""));
    }


    //排序
    protected void Grid_NETrainingItem_Sorting(object sender, GridViewSortEventArgs e)
    {
        // 从事件参数获取排序数据列

        string sortExpression = e.SortExpression.ToString();

        // 假定为排序方向为“顺序”

        string sortDirection = "ASC";

        // “ASC”与事件参数获取到的排序方向进行比较，进行GridView排序方向参数的修改

        if (sortExpression == Grid_NETrainingItem.Attributes["SortExpression"])
        {

            //获得下一次的排序状态

            sortDirection = (Grid_NETrainingItem.Attributes["SortDirection"].ToString() == sortDirection ? "DESC" : "ASC");

        }

        // 重新设定GridView排序数据列及排序方向

        Grid_NETrainingItem.Attributes["SortExpression"] = sortExpression;

        Grid_NETrainingItem.Attributes["SortDirection"] = sortDirection;

        //重新绑定数据

        Grid_NETrainingItem.DataBind();
    }

    //绑定Gridview
    private void BindGridview()
    {
        string sortExpression = Grid_NETrainingItem.Attributes["SortExpression"];
        string sortDirection = Grid_NETrainingItem.Attributes["SortDirection"];
        Grid_NETrainingItem.DataSource = nETtainningL.Search_NETrainingItem();
        Grid_NETrainingItem.DataBind();
    }
    protected void Grid_NETrainingItem_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header) //如果是表头

            foreach (TableCell MyHeader in e.Row.Cells) //对每一单元格      

                if (MyHeader.HasControls())

                    if (((LinkButton)MyHeader.Controls[0]).CommandArgument == Grid_NETrainingItem.SortExpression)
                        //是否为排序列

                        if (Grid_NETrainingItem.SortDirection == SortDirection.Ascending) //依排序方向加入方向箭头

                            MyHeader.Controls.Add(new LiteralControl("▲"));

                        else

                            MyHeader.Controls.Add(new LiteralControl("▼"));
    }

    //行变色以及每个单元格的Tooltip
    protected void Grid_NETrainingItem_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Grid_NETrainingItem.Rows.Count; i++)
        {
            for (int j = 0; j < Grid_NETrainingItem.Rows[i].Cells.Count; j++)
            {
                Grid_NETrainingItem.Rows[i].Cells[j].ToolTip = Grid_NETrainingItem.Rows[i].Cells[j].Text;
                if (Grid_NETrainingItem.Rows[i].Cells[j].Text.Length > 15)
                {
                    Grid_NETrainingItem.Rows[i].Cells[j].Text = Grid_NETrainingItem.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }


            }
        }
    }
}