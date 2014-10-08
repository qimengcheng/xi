using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HRPerfMgt_HRPerfManagerCheck : Page
{
    private static string con1;
    private static string con2;
    private static string con3;
    private static string con4;
    private static string editFlag;
    private static Guid guidPanel1;
    private static Guid guidView;
    private static string flag;
    private static int yearView;
    private static int monthView;
    private static int yearView2;
    private static int monthView2;
    HRDDetailL hRDDetailL = new HRDDetailL();//调用该业务逻辑的目的：绑定部门和岗位
    HRPItemScoreL hRPItemScoreL = new HRPItemScoreL();
    HRPerfL hRPerfL = new HRPerfL();
    HRPItemL hRPItemL = new HRPItemL();
    HRPerformceDetailL hRPerformceDetailL = new HRPerformceDetailL();
    HRPerformceDetailInfo detailInfo = new HRPerformceDetailInfo();

    HRPerformceYearInfo yearInfo = new HRPerformceYearInfo();
    HRPerfYearL hRPerfYearL = new HRPerfYearL();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString["status"] == "PerMAudit")
        {
            Title = "绩效考核经理考核";
        }
        if (!IsPostBack)
        {
            BindYear(DropDownList2);
            BindDdlMonth(DropDownList3);
            BindGrid1("");
        }

    }
    #region//查看已经考核后的年份和月份
    private void BindGrid1(string condition)
    {
        GridView1.DataSource = hRPerfYearL.Search_HRPerformceYear_Manager(condition);
        GridView1.DataBind();
    }//

    protected void BtnSearchPanel1_Click(object sender, EventArgs e)
    {
        con2 = DropDownList2.SelectedValue == "" ? "" : "and HRP_Year ='" + DropDownList2.SelectedValue + "'";
        con2 += DropDownList3.SelectedValue == "" ? "" : " and HRP_Month = '" + DropDownList3.SelectedValue + "'";
        BindGrid1(con2);
        UpdatePanel1.Update();
        Label18.Text = "检索后";
    }//panel1中gridview的检索


    protected void BtnResetPanel1_Click(object sender, EventArgs e)
    {
        DropDownList2.ClearSelection();
        DropDownList3.ClearSelection();
        Label18.Text = "检索前";
        BindGrid1("");
    }//panel1中gridview的重置


    //Gridview1中的翻页
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView1.BottomPagerRow;
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
        if (Label18.Text == "检索前")
        {
            BindGrid1("");
        }
        if (Label18.Text == "检索后")
        {
            BindGrid1(con2);
        }
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView1.PageCount ? GridView1.PageCount - 1 : newPageIndex;
        GridView1.PageIndex = newPageIndex;
        GridView1.PageIndex = newPageIndex;
        GridView1.DataBind();
    }//已经录入年份和月份中的翻页
    #endregion

    //点击确认按钮
    protected void BtnSearchTime_Click(object sender, EventArgs e)
    {
        Panel_SearchEmployee.Visible = true;
        BindGridForEmployee(Grid_Detail, "");
        UpdatePanel_SearchEmployee.Update();
    }
    private void BindGridForEmployee(GridView gv, string condition)
    {
       
        
        try
        {
            gv.DataSource = hRPerfYearL.Search_HRPerformceDetail_Manager(condition);
            gv.DataBind();
            
        }
        catch
        {

        }
       
    }//绑定Gridview(属于该账套的员工列表)

    #region//绑定下拉菜单
    private void Bind_DdlHRPtype(DropDownList ddl)
    {
        ddl.DataSource = hRPerfL.Search_HRPerformAssessType("").Tables[0].DefaultView;
        ddl.DataTextField = "HRPAT_PType";
        ddl.DataValueField = "HRPAT_ID";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("请选择", ""));
    }//绑定Dropdownlist中的DdlDep——部门，参数是欲绑定的Dropdownlist

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
       
    }//DdropdownList二级联动:根据部门中的选项，实现下级自动绑定（要实现此方法，前台必须设定触发器,以及该事件源的控件的属性AuotoPostback为true）

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
    #endregion

    protected void BtnSearchEmployee_Click(object sender, EventArgs e)
    {
        //con1 = " and b.HRPYear_ID='" + guidPanel1 + "' ";
        con1 = " and b.HRP_Year='" + yearView + "' and b.HRP_Month='" + monthView + "'";
        con1 += TxtSearchStaffNO.Text.Trim() == "" ? "" : " and HRDD_StaffNO like '%" + TxtSearchStaffNO.Text.Trim() + "%'";
        con1 += TxtSearchName.Text.Trim() == "" ? "" : " and HRDD_Name like '%" + TxtSearchName.Text.Trim() + "%'";
        try
        {
            BindGridForEmployee(Grid_Detail, con1);
            
        }
        catch (Exception ex)
        {
            throw ex;
        }
        LblStateForGrid_Type.Text = "检索后";
        UpdatePanel_SearchEmployee.Update();

    }//xxx的员工信息栏的“检索”

    #region//gridview中的事件
    
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditPanel1")
        {
            Panel3.Visible = false;
            UpdatePanel3.Update();

            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView1.SelectedIndex = row.RowIndex;
            LabelYear.Text = row.Cells[0].Text.ToString();
            LabelMonth.Text = row.Cells[1].Text.ToString();
            
            LabelA_State.Text = row.Cells[2].Text.ToString();
            editFlag = row.Cells[2].Text.ToString();

            if (editFlag != "已审核")
            {
                Panel_SearchEmployee.Visible = true;
                //guidPanel1 = new Guid(e.CommandArgument.ToString());
                Label6.Text = guidPanel1.ToString();
                yearView = Convert.ToInt32(LabelYear.Text);
                monthView = Convert.ToInt32(LabelMonth.Text);
                BindGridForEmployee(Grid_Detail, " and b.HRP_Year='" + yearView + "' and b.HRP_Month='" + monthView + "'");
                UpdatePanel_SearchEmployee.Update();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('已经审核过了！')", true);
                return;
            }
            
        }

        if (e.CommandName == "EditPanel1_View")
        {
            Panel_SearchEmployee.Visible = false;
            UpdatePanel_SearchEmployee.Update();
            Panel2.Visible = false;
            UpdatePanel2.Update();

            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_Detail.SelectedIndex = row.RowIndex;
            //guidView = new Guid(e.CommandArgument.ToString());
            LabelYear.Text = row.Cells[0].Text.ToString();
            LabelMonth.Text = row.Cells[1].Text.ToString();
            yearView2 = Convert.ToInt32(LabelYear.Text);
            monthView2 = Convert.ToInt32(LabelMonth.Text);
            con3 = " and b.HRP_Year ='" + yearView2 + "' and b.HRP_Month ='" + monthView2 + "'";
            Panel3.Visible = true;
            BindGridView3(con3);
            UpdatePanel3.Update();
        }

    }

    protected void Grid_Detail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit1")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_Detail.SelectedIndex = row.RowIndex;
            Panel2.Visible = true;
            TxtItem1.Text = row.Cells[1].Text.ToString();
            TxtItem2.Text = row.Cells[2].Text.ToString();
            Label2.Text = e.CommandArgument.ToString();
            Label5.Text = row.Cells[6].Text.ToString();
            CheckPerson.Text = "";
            //BindGridForItem(Label5.Text, new Guid(Label2.Text));
            //CheckPerson.Text = Session["UserName"].ToString().Trim();
            TxtCheckTime.Text = DateTime.Now.ToString();
            UpdatePanel2.Update();
        }
    }
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
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox999");   // refer to the TextBox with the NewPageIndex value
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
        if(LblStateForGrid_Type.Text=="检索前")
        {
            //BindGridForEmployee(Grid_Detail, "");
            BindGridForEmployee(Grid_Detail, " and b.HRP_Year='" + yearView + "' and b.HRP_Month='" + monthView + "'");
        }
        if (LblStateForGrid_Type.Text == "检索后")
        {
            BindGridForEmployee(Grid_Detail, con1);
        }

        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_Detail.PageCount ? Grid_Detail.PageCount - 1 : newPageIndex;
        Grid_Detail.PageIndex = newPageIndex;
        Grid_Detail.PageIndex = newPageIndex;
        Grid_Detail.DataBind();
    }//员工考核信息列表的翻页

    

    protected void BtnReset_Click(object sender, EventArgs e)
    {
        TxtSearchStaffNO.Text = "";
        TxtSearchName.Text = "";
        BindGridForEmployee(Grid_Detail, " and b.HRP_Year='" + yearView + "' and b.HRP_Month='" + monthView + "'");
        LblStateForGrid_Type.Text = "检索前";

    } //考核录入的员工信息栏的“重置”
    #endregion
    #region//考核项目列表
    
    protected void Btnclose_Click(object sender, EventArgs e)
    {
        Panel2.Visible = false;
        UpdatePanel2.Update();
    }
    

    #endregion

  
    protected void BtncloseSearchEmployee_Click(object sender, EventArgs e)
    {
        Panel_SearchEmployee.Visible = false;
        Btnclose_Click(sender,e);
        UpdatePanel_SearchEmployee.Update();
        UpdatePanel2.Update();
    }

    #region//新增的GridView3中所有的函数
    private void BindGridView3(string condition)
    {
        GridView3.DataSource = hRPerfYearL.Search_HRPerformceDetail_Manager_View(condition);
        GridView3.DataBind();
    }//

    //翻页
    protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView3.BottomPagerRow;
            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox33");   // refer to the TextBox with the NewPageIndex value
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
        if (Label22.Text == "检索前")
        {
            BindGridView3(con3);
        }
        if (Label22.Text == "检索后")
        {
            BindGridView3(con4);
        }
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView3.PageCount ? GridView3.PageCount - 1 : newPageIndex;
        GridView3.PageIndex = newPageIndex;
        GridView3.PageIndex = newPageIndex;
        GridView3.DataBind();
    }

    protected void BtnSearchGridView3_Click(object sender, EventArgs e)
    {
        con4 = con3;
        con4 += TextBox1.Text.Trim() == "" ? "" : " and HRDD_StaffNO like '%" + TextBox1.Text.Trim() + "%'";
        con4 += TextBox2.Text.Trim() == "" ? "" : " and HRDD_Name like '%" + TextBox2.Text.Trim() + "%'";
        BindGridView3(con4);
        UpdatePanel3.Update();
    }
    protected void BtnResetGridView3_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        BindGridView3(con3);
        UpdatePanel3.Update();
    }
    protected void BtncloseGridView3_Click(object sender, EventArgs e)
    {
        Panel3.Visible = false;
        UpdatePanel3.Update();
    }

    #endregion
    protected void BtnOK_Click(object sender, EventArgs e)
    {
        if (CheckPerson.Text == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (Int32.Parse(CheckPerson.Text) > 10 || Int32.Parse(CheckPerson.Text) < 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请以10分为满分进行打分！')", true);
            return;
        }
        Guid guid = new Guid(Label2.Text);
        detailInfo.HRPD_ID = guid;
        detailInfo.HRPD_M_Score = Convert.ToInt32(CheckPerson.Text);
        try
        {
            hRPerfYearL.Update_HRPerformceDetail_Manager(detailInfo);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        BindGridForEmployee(Grid_Detail, "and b.HRP_Year='" + yearView + "' and b.HRP_Month='" + monthView + "'");
        UpdatePanel_SearchEmployee.Update();

        Panel2.Visible = false;

        UpdatePanel2.Update();

        int state = hRPerfYearL.Search_HRPerformceYear_Manager_State(yearView,monthView);

        if (Label18.Text == "检索前")
        {
            BindGrid1("");
        }
        if (Label18.Text == "检索后")
        {
            BindGrid1(con2);
        }

        UpdatePanel1.Update();
        
    }
}