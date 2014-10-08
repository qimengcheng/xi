using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HRPerfMgt_HRPerfCheck : Page
{
    private static string con1;
    private static string con2;
    private static string con3;
    private static string con4;
    private static string editFlag;
    private static Guid guidPanel1;
    private static string flag;
    HRDDetailL hRDDetailL = new HRDDetailL();//调用该业务逻辑的目的：绑定部门和岗位
    HRPItemScoreL hRPItemScoreL = new HRPItemScoreL();
    HRPerfL hRPerfL = new HRPerfL();
    HRPItemL hRPItemL = new HRPItemL();
    HRPerformceDetailL hRPerformceDetailL = new HRPerformceDetailL();

    HRPerformceYearInfo yearInfo = new HRPerformceYearInfo();
    HRPerfYearL hRPerfYearL = new HRPerfYearL();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString["status"] == "PerAudit")
        {
            Title = "绩效考核结果审核";
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
        GridView1.DataSource = hRPerfYearL.Search_HRPerformceYear(condition + " and HRPAT_CPerson = '" + Session["UserId"] + "'");
        GridView1.DataBind();
    }//

    protected void BtnSearchPanel1_Click(object sender, EventArgs e)
    {
        con2 = " and HRPAT_CPerson = '" + Session["UserId"] + "' ";
        con2 += DropDownList2.SelectedValue == "" ? "" : "and HRP_Year ='" + DropDownList2.SelectedValue + "'";
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
        Bind_DdlHRPtype(DropDownList1);
        Bind_DdlDep(DdlSearchDep);
        Bind_DdlPost(DdlSearchPost, "");
        UpdatePanel_SearchEmployee.Update();
    }
    private void BindGridForEmployee(GridView gv, string condition)
    {
       
        
        try
        {
            gv.DataSource = hRPerformceDetailL.Search_HRPerformAssessType_HRDDetail_HRPerformceDetail(condition + " and HRPAT_CPerson = '" + Session["UserId"] + "'");
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
        Bind_DdlPost(DdlSearchPost, DdlSearchDep.SelectedValue.ToString());
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
        con1 = " and HRPD_Year='" + LabelYear.Text.Trim() + "' and HRPD_Month ='" + LabelMonth.Text.Trim() + "' ";
        con1 += TxtSearchStaffNO.Text.Trim() == "" ? "" : " and HRDD_StaffNO like '%" + TxtSearchStaffNO.Text.Trim() + "%'";
        con1 += TxtSearchName.Text.Trim() == "" ? "" : " and HRDD_Name like '%" + TxtSearchName.Text.Trim() + "%'";
        con1 += DdlSearchDep.SelectedValue == "" ? "" : " and c.BDOS_Code ='" + DdlSearchDep.SelectedValue + "'";
        con1 += DdlSearchPost.SelectedValue == "" ? "" : " and b.HRP_ID ='" + DdlSearchPost.SelectedValue + "'";
        con1 += DropDownList1.SelectedValue == "" ? "" : " and b.HRPAT_ID ='" + DropDownList1.SelectedValue + "'";
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
            //this.LabelA_Person.Text = row.Cells[5].Text.ToString();
            LabelA_State.Text = row.Cells[2].Text.ToString();
            editFlag = row.Cells[2].Text.ToString();
            if (editFlag == "已录入")
            {
                Panel_SearchEmployee.Visible = true;
                guidPanel1 = new Guid();
                Label6.Text = guidPanel1.ToString();
                //BindGridForEmployee(Grid_Detail, " and HRPYear_ID='" + guidPanel1 + "' ");
                BindGridForEmployee(Grid_Detail, " and HRPD_Year='" + LabelYear.Text.Trim() + "' and HRPD_Month ='" + LabelMonth.Text.Trim() + "'  ");
                Bind_DdlHRPtype(DropDownList1);
                Bind_DdlDep(DdlSearchDep);
                Bind_DdlPost(DdlSearchPost, "");
                UpdatePanel_SearchEmployee.Update();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('在已录入状态下才能进行审核！')", true);
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
           // Guid guidView = new Guid(e.CommandArgument.ToString());
            LabelYear.Text = row.Cells[0].Text.ToString();
            LabelMonth.Text = row.Cells[1].Text.ToString();

            con3 = " and HRPD_Year='" + LabelYear.Text.Trim() + "' and HRPD_Month ='" + LabelMonth.Text.Trim() + "'";
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
            TxtItem1.Text = row.Cells[2].Text.ToString();
            TxtItem2.Text = row.Cells[3].Text.ToString();
            Label2.Text = e.CommandArgument.ToString();
            Label5.Text = row.Cells[6].Text.ToString();
            Guid guid = new Guid(Label2.Text);
            BindGridForItem(Label5.Text, new Guid(Label2.Text));
            CheckPerson.Text = Session["UserName"].ToString().Trim();
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
            BindGridForEmployee(Grid_Detail, " and HRPD_Year='" + LabelYear.Text.Trim() + "' and HRPD_Month ='" + LabelMonth.Text.Trim() + "' ");
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
        BindGridForItem(Label5.Text, new Guid(Label2.Text));
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_Detail.PageCount ? GridView2.PageCount - 1 : newPageIndex;
        GridView2.PageIndex = newPageIndex;
        GridView2.PageIndex = newPageIndex;
        GridView2.DataBind();
    }//考核项目列表的翻页

    protected void GridView2_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView2.Rows.Count; i++)
        {
            for (int j = 1; j < GridView2.Rows[i].Cells.Count; j++)
            {
                GridView2.Rows[i].Cells[j].ToolTip = GridView2.Rows[i].Cells[j].Text;
                if (GridView2.Rows[i].Cells[j].Text.Length > 15)
                {
                    GridView2.Rows[i].Cells[j].Text = GridView2.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }


            }
        }
    }//员工列表的databound

    protected void BtnReset_Click(object sender, EventArgs e)
    {
        DropDownList1.ClearSelection();
        //DropDownList3.ClearSelection();
        //DropDownList4.ClearSelection();
        TxtSearchStaffNO.Text = "";
        TxtSearchName.Text = "";
        DdlSearchDep.ClearSelection();
        DdlSearchPost.ClearSelection();
        BindGridForEmployee(Grid_Detail, " and HRPD_Year='" + LabelYear.Text.Trim() + "' and HRPD_Month ='" + LabelMonth.Text.Trim() + "' ");
        LblStateForGrid_Type.Text = "检索前";

    } //考核录入的员工信息栏的“重置”
    #endregion
    #region//考核项目列表
    protected void BindGridForItem(string condition,Guid ID)
    {
        GridView2.DataSource = hRPItemScoreL.Search_HRPerformceItem_HRPerformAssessType_HRPerformceDetail(condition,ID);
        GridView2.DataBind();
    }
    protected void Btnclose_Click(object sender, EventArgs e)
    {
        Panel2.Visible = false;
        UpdatePanel2.Update();
    }
    protected void BtnOK_Click(object sender, EventArgs e)
    {
        HRPerformceDetailInfo neiaInfo1 = new HRPerformceDetailInfo();//提交"按钮，插入新员工培训结果详情表
        HRPItemScoreInfo neiaInfo2 = null;//"提交"按钮，更新新员工培训信息主表的状态
        DateTime d1;
        if (DateTime.TryParse(TxtCheckTime.Text, out d1))
        {
            neiaInfo1.HRPD_AuTime = d1;
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入格式正确的培训开始日期！')", true);
            return;
        }
        int count = GridView2.Rows.Count;
        for (int j=0; j<count;j++ )
        {
            TextBox tb1 = GridView2.Rows[j].FindControl("TxtRemarks") as TextBox;//取得所在行的是否合格的列
            if (tb1.Text == "")
            {
                tb1.Text = GridView2.Rows[j].Cells[7].Text;
                //ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('请输入最终得分！')", true);
                flag = "提交";
                //break;
            }
            else if (Int32.Parse(GridView2.Rows[j].Cells[4].Text) < Int32.Parse(tb1.Text))
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('项目最终得分不能比标准得分高！')", true);
                flag = "不提交";
                break;
            }
            else
            {
                flag = "提交";
            }
        }
        if(CheckPerson.Text==""){
            flag = "不提交";
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入审核人！')", true);
        }
        if (flag == "提交")
        {
            neiaInfo1.HRPD_ID = new Guid(Label2.Text);//人事档案ID
            neiaInfo1.HRPD_Auditor = CheckPerson.Text;
            neiaInfo1.HRPD_C_FinalScore = 0;
            neiaInfo1.HRPD_State = true;

            for (int i = 0; i < count; i++)
            {

                neiaInfo2 = new HRPItemScoreInfo();
                TextBox tb = GridView2.Rows[i].FindControl("TxtRemarks") as TextBox;//取得所在行的是否合格的列
                string id = GridView2.Rows[i].Cells[0].Text;
                neiaInfo2.HRPIS_ItemID = new Guid(GridView2.Rows[i].Cells[0].Text);
                neiaInfo2.HRPIS_ItemFScore = Int32.Parse(tb.Text);
                neiaInfo1.HRPD_C_FinalScore = neiaInfo1.HRPD_C_FinalScore + neiaInfo2.HRPIS_ItemFScore;
                hRPItemScoreL.Update_HRPItemScore_CHECK(neiaInfo2);

            }
            hRPerformceDetailL.Update_HRPerformceDetail_CHECK(neiaInfo1);
            Panel2.Visible = false;
            BindGridForEmployee(Grid_Detail, " and HRPD_Year='" + LabelYear.Text.Trim() + "' and HRPD_Month ='" + LabelMonth.Text.Trim() + "' ");
            UpdatePanel_SearchEmployee.Update();
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('已提交！')", true);
            int year = Int32.Parse(LabelYear.Text);
            int month = Int32.Parse(LabelMonth.Text);
            string Person = Session["UserId"].ToString();
            int state = hRPerfYearL.Search_HRPerformceYear_CHECK_State(year,month,Person);
            if (state == 0)
            {
                yearInfo.HRP_C_State = "已审核";
            }
            else
            {
                yearInfo.HRP_C_State = "审核中";
            }
            //yearInfo.HRPYear_ID = guidPanel1;
            //yearInfo.HRP_Year =System.Int32.Parse(this.LabelYear.Text);
            //yearInfo.HRP_Month = System.Int32.Parse(this.LabelMonth.Text);
            //yearInfo.HRP_A_State = this.LabelA_State.Text;
            //yearInfo.HRP_C_Person = Session["UserId"].ToString();
            //hRPerfYearL.Update_HRPerformceYear(yearInfo);
            
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
        GridView3.DataSource = hRPerfYearL.Search_HRPerformceYear_HRPerformceDetail_State(condition + " and HRPAT_CPerson = '" + Session["UserId"] + "'");
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
            BindGridView3(con3);
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
}