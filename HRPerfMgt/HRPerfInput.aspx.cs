using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using RTXHelper;

public partial class HRPerfMgt_HRPerfInput : Page
{
    private static string con1;
    private static string con2;
    private static string con3;
    private static string con4;
    private static string flag;
    private static string editFlag;
    private static Guid guidYear;
    HRDDetailL hRDDetailL = new HRDDetailL();//调用该业务逻辑的目的：绑定部门和岗位
    HRPItemScoreL hRPItemScoreL = new HRPItemScoreL();
    HRPerfL hRPerfL = new HRPerfL();
    HRPItemL hRPItemL = new HRPItemL();
    HRPerformceDetailL hRPerformceDetailL = new HRPerformceDetailL();
    
    HRPerformceYearInfo yearInfo = new HRPerformceYearInfo();
    HRPerfYearL hRPerfYearL = new HRPerfYearL();
   

    NewEmpInfoAddL neiaL = new NewEmpInfoAddL();
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!((Session["UserRole"].ToString().Contains("绩效考核信息录入"))))
        //{
        //    Response.Redirect("~/Default.aspx");

        //}
        if (Request.QueryString["status"] == "PerInfoInput")
        {
            Title = "绩效考核信息录入";
        }
        if (!IsPostBack)
        {
            try
            {
                UserIdtoName();
                BindYear(DropDownList2);
                BindDdlMonth(DropDownList3);
                BindYear(DropDownListYear);//帮顶年
                BindDdlMonth(DropDownListMonth);//帮顶月
                BindGrid1("");
                
            }
            catch
            {

            }
           
        }

    }
#region//根据用户的ID查处用户姓名 
    private void UserIdtoName()
    {
        DataSet dtAperson = neiaL.Search_ForTeacher_HRDDetail("and UMUI_UserID = '" + Session["UserId"] + "'");
        Label10.Text = Convert.ToString(dtAperson.Tables[0].Rows[0]["UMUI_UserName"]);
    }
#endregion
    #region//绑定GridView
    private void BindGrid1(string condition)
    {
        GridView1.DataSource = hRPerformceDetailL.Search_HRPerformceDetail(condition + "and HRP_A_Person = '"+ Session["UserId"]+"'");         
        GridView1.DataBind();
    }//

    private void BindGridForEmployee(GridView gv, string condition)
    {
        int Year = Int32.Parse(LabelYear.Text.ToString());
        int Month = Int32.Parse(LabelMonth.Text.ToString());
        gv.DataSource = hRPItemScoreL.Search_HRDDetail_HRPerformAssessType(condition + "and HRPerformAssessType.HRPAT_APerson = '" + Session["UserId"] + "'and HRPD_Year='" + Year + "' and HRPD_Month='" + Month + "'");
        gv.DataBind();
    }//

    private void BindGridView3(string condition)
    {
        GridView3.DataSource = hRPerfYearL.Search_HRPerformceYear_HRPerformceDetail_State(condition);
        GridView3.DataBind();
    }//
    #endregion
    #region//Panel1总相关的事件
    protected void BtnSearchPanel1_Click(object sender, EventArgs e)
    {
        //int Year = System.Int32.Parse(DropDownList2.Text.ToString());
        //int Month = System.Int32.Parse(DropDownList3.Text.ToString());
        con2 = DropDownList2.SelectedValue == "" ? "" : "and HRP_Year ='" + DropDownList2.SelectedValue + "'";
        con2 += DropDownList3.SelectedValue == "" ? "" : " and HRP_Month = '" + DropDownList3.SelectedValue + "'";
        BindGrid1(con2);
        UpdatePanel1.Update();
        Label18.Text = "检索后";
    }//panel1中gridview的检索

    protected void BtnNewPanel1_Click(object sender, EventArgs e)
    {
        Panel_SearchEmployee.Visible = false;
        UpdatePanel_SearchEmployee.Update();
        Panel2.Visible = false;
        UpdatePanel2.Update();
        Panel3.Visible = false;
        UpdatePanel3.Update();

        Panel_Time.Visible = true;
        UpdatePanel_Time.Update();
    }//panel1中gridview的新增

    protected void BtnResetPanel1_Click(object sender, EventArgs e)
    {
        DropDownList2.ClearSelection();
        DropDownList3.ClearSelection();
        Label18.Text = "检索前";
        BindGrid1("");
    }//panel1中gridview的重置

    protected void BtnCloseTime_Click(object sender, EventArgs e)
    {
        Panel_Time.Visible = false;
        UpdatePanel_Time.Update();
       
    }//新增年份和月份中的关闭按钮

    protected void BtnSearchTime_Click(object sender, EventArgs e)
    {

        if (DropDownListYear.Text == "" || DropDownListMonth.Text == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        yearInfo.HRPYear_ID = Guid.NewGuid();
        yearInfo.HRP_Year = Int32.Parse(DropDownListYear.Text.ToString());
        yearInfo.HRP_Month = Int32.Parse(DropDownListMonth.Text.ToString());
        yearInfo.HRP_A_State = "未录入";
        yearInfo.HRP_C_State = "未审核";
        yearInfo.HRP_M_State = "未审核";
        yearInfo.HRP_A_Person = Session["UserId"].ToString();
        yearInfo.HRPYear_IsDeleted = false;
        int i = hRPerfYearL.Insert_HRPerformceYear(yearInfo);
        if (i <= 0)
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('重复的年份和月份！')", true);
            return;
        }
        BindGrid1("");
        UpdatePanel1.Update();
        Panel_Time.Visible = false;
        UpdatePanel_Time.Update();

    } //新增年份和月份中的确定按钮
#endregion
    #region//初始时选择考核年份和月份模块

            private void BindYear(DropDownList ddl)
            {
                ddl.Items.Clear();
                for (int m = 2012; m <= 2035; m++)
                {
                    ddl.Items.Add(new ListItem(m.ToString(), m.ToString()));
                }
                ddl.Items.Insert(0, new ListItem("请选择", ""));
                ddl.DataBind();
            }//帮顶年份
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


    #region//绑定下拉菜单中考核类型、部门和岗位
    private void Bind_DdlHRPtype(DropDownList ddl)
    {
        //ddl.DataSource = hRDDetailL.SearchDdl_HRDDetail_BDOrganizationSheet().Tables[0].DefaultView;
        ddl.DataSource = hRPerfL.Search_HRPerformAssessType("").Tables[0].DefaultView;
        ddl.DataTextField = "HRPAT_PType";
        ddl.DataValueField = "HRPAT_ID";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("请选择", ""));
    }//绑定Dropdownlist中的DdlDep——考核类型，参数是欲绑定的Dropdownlist

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

    protected void BtnSearchEmployee_Click(object sender, EventArgs e)
    {
        //string condition = con1;
        con1 = DropDownList1.SelectedValue == "" ? "" : "and HRDDetail.HRPAT_ID ='" + DropDownList1.SelectedValue + "'";
        con1 += TxtSearchStaffNO.Text.Trim() == "" ? "" : " and HRDD_StaffNO like '%" + TxtSearchStaffNO.Text.Trim() + "%'";
        con1 += TxtSearchName.Text.Trim() == "" ? "" : " and HRDD_Name like '%" + TxtSearchName.Text.Trim() + "%'";
        con1 += DdlSearchDep.SelectedValue == "" ? "" : " and HRPost.BDOS_Code ='" + DdlSearchDep.SelectedValue + "'";
        con1 += DdlSearchPost.SelectedValue == "" ? "" : " and HRDDetail.HRP_ID ='" + DdlSearchPost.SelectedValue + "'";
        try
        {
            BindGridForEmployee(Grid_Detail, con1);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        UpdatePanel_SearchEmployee.Update();
        LblStateForGrid_Type.Text = "检索后";

    }//xxx的员工信息栏的“检索”

    //Gridview中的RowCommand事件
    protected void Grid_Detail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int num = 0;
        if (e.CommandName == "Edit1")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;           
            Grid_Detail.SelectedIndex = row.RowIndex;
            Panel2.Visible = true;
            TxtItem1.Text = row.Cells[2].Text.ToString();
            TxtItem2.Text = row.Cells[3].Text.ToString();     
            Label2.Text = e.CommandArgument.ToString();
            Label5.Text = row.Cells[6].Text.ToString();
            Label6.Text = row.Cells[1].Text.ToString().Trim();
            Guid guid = new Guid(Label2.Text);
            BindGridForItem(Label5.Text);
            num = Label6.Text.Length;
            CheckPerson.Text = Session["UserName"].ToString().Trim();
            TxtCheckTime.Text = DateTime.Now.ToString();
            UpdatePanel2.Update();
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "EditPanel1")
        {
            Panel3.Visible = false;
            UpdatePanel3.Update();
            Panel_Time.Visible = false;
            UpdatePanel_Time.Update();
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_Detail.SelectedIndex = row.RowIndex;
            LabelYear.Text = row.Cells[1].Text.ToString();
            LabelMonth.Text = row.Cells[2].Text.ToString();
            editFlag = row.Cells[4].Text.ToString();
            guidYear = new Guid(e.CommandArgument.ToString());
            if (editFlag == "未审核")
            {
                HRPerformceDetailL hRPerformceDetailL_New = new HRPerformceDetailL();
                HRPerformceDetailInfo neiaInfo1_New = new HRPerformceDetailInfo();
                DateTime dtimeNew = DateTime.Now;
                if (LabelYear.Text == "" || LabelMonth.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('年份和月份不能为空！')", true);
                    return;
                }
                DataSet dtNew = hRPItemScoreL.Search_HRDDetail_HRPerformAssessType_Year("and HRPerformAssessType.HRPAT_APerson = '" + Session["UserId"] + "'");
                DataTable dtNewTable = dtNew.Tables[0];
                int count = dtNewTable.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    Guid guid = Guid.NewGuid();
                    neiaInfo1_New.HRPD_ID = new Guid(guid.ToString());
                    neiaInfo1_New.HRDD_ID = new Guid(dtNewTable.Rows[i]["HRDD_ID"].ToString());
                    neiaInfo1_New.HRPYear_ID = new Guid(guidYear.ToString());
                    neiaInfo1_New.HRPD_Year = Int32.Parse(LabelYear.Text);
                    neiaInfo1_New.HRPD_Month = Int32.Parse(LabelMonth.Text);
                    neiaInfo1_New.HRPD_AState = false;
                    neiaInfo1_New.HRPD_Atime = dtimeNew;
                    neiaInfo1_New.HRPD_APerson = "";
                    hRPerformceDetailL_New.Insert_HRPerformceDetail(neiaInfo1_New);
                }
                Panel_SearchEmployee.Visible = true;
                BindGridForEmployee(Grid_Detail, "");
                Bind_DdlHRPtype(DropDownList1);
                Bind_DdlDep(DdlSearchDep);
                Bind_DdlPost(DdlSearchPost, "");
                UpdatePanel_SearchEmployee.Update();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('审核状态下不能进行录入！')", true);
                return;
            }      
        }

        if (e.CommandName == "EditPanel1_View")
        {
            Panel_SearchEmployee.Visible = false;
            UpdatePanel_SearchEmployee.Update();
            Panel_Time.Visible = false;
            UpdatePanel_Time.Update();
            Panel2.Visible = false;
            UpdatePanel2.Update();


            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_Detail.SelectedIndex = row.RowIndex;
            Guid guidView = new Guid(e.CommandArgument.ToString());
            con3 = " and HRPYear_ID ='" +guidView+ "'";
            Panel3.Visible = true;
            BindGridView3(con3);
            UpdatePanel3.Update();
        }
    }//
    #region//GridView中的翻页
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
        if (LblStateForGrid_Type.Text == "检索前")
        {
            BindGridForEmployee(Grid_Detail, "");
        }
        if (LblStateForGrid_Type.Text == "检索后")
        {
            BindGridForEmployee(Grid_Detail,con1);
        }
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_Detail.PageCount ? Grid_Detail.PageCount - 1 : newPageIndex;
        Grid_Detail.PageIndex = newPageIndex;
        Grid_Detail.PageIndex = newPageIndex;
        Grid_Detail.DataBind();
    }//

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
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox333");   // refer to the TextBox with the NewPageIndex value
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

    #endregion

    #region
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
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox222");   // refer to the TextBox with the NewPageIndex value
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

        BindGridForItem(Label5.Text);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView2.PageCount ? GridView2.PageCount - 1 : newPageIndex;
        GridView2.PageIndex = newPageIndex;
        GridView2.PageIndex = newPageIndex;
        GridView2.DataBind();
    }//

    protected void BtnReset_Click(object sender, EventArgs e)
    {
        
        DropDownList1.ClearSelection();
        TxtSearchStaffNO.Text = "";
        TxtSearchName.Text = "";
        DdlSearchDep.ClearSelection();
        DdlSearchPost.ClearSelection();
        BindGridForEmployee(Grid_Detail,"");
        LblStateForGrid_Type.Text = "检索前";
    } //考核录入的员工信息栏的“重置”
    #endregion
    #region//考核项目列表
    protected void BindGridForItem(string condition)
    {
        GridView2.DataSource = hRPItemL.Search_HRPerformceItem_HRPerformAssessType(condition);
        GridView2.DataBind();
    }
    protected void Btnclose_Click(object sender, EventArgs e)
    {
        Panel2.Visible = false;
        UpdatePanel2.Update();
    }
    protected void BtnOK_Click(object sender, EventArgs e)
    {
        HRPerformceDetailL hRPerformceDetailL = new HRPerformceDetailL();
        HRPerformceDetailInfo neiaInfo1 = new HRPerformceDetailInfo();
        HRPItemScoreL hRPItemScoreL = new HRPItemScoreL();
        HRPItemScoreInfo neiaInfo2 = null;
        DateTime d1;
        if (DateTime.TryParse(TxtCheckTime.Text, out d1))
        {
            neiaInfo1.HRPD_Atime = d1;
            
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入格式正确的培训开始日期！')", true);
            return;
        }
        
        int count = GridView2.Rows.Count;
        for (int i = 0; i < count; i++)
        {
            
            TextBox tb1 = GridView2.Rows[i].FindControl("TxtRemarks") as TextBox;//取得所在行的是否合格的列
            if (tb1.Text == "")
            {
                //tb1.Text = GridView2.Rows[i].Cells[]
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('考核项目得分不能为空！')", true);
                flag = "不提交";
                break;
            }
            else if(Int32.Parse(GridView2.Rows[i].Cells[3].Text) < Int32.Parse(tb1.Text))
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('项目得分不能比标准得分高！')", true);
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
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入考核人！')", true);

        }

        if (flag == "提交")
        {
            neiaInfo1.HRDD_ID = new Guid(Label2.Text);//人事档案ID
            //Guid guid = Guid.NewGuid();
            //LabelDetail.Text = guid.ToString();
            neiaInfo1.HRPD_ID = new Guid(Label6.Text.ToString().Trim());
            neiaInfo1.HRPD_APerson = CheckPerson.Text;
            neiaInfo1.HRPD_FinalScore = 0;
            neiaInfo1.HRPD_Month = Int32.Parse(LabelMonth.Text.ToString());
            neiaInfo1.HRPD_Year = Int32.Parse(LabelYear.Text.ToString());
          
            neiaInfo1.HRPD_State = false;
            neiaInfo1.HRPD_AState = true;
            //hRPerformceDetailL.Insert_HRPerformceDetail(neiaInfo1);
            //hRPerformceDetailL.Update_HRPerformceDetail(neiaInfo1);
            for (int j = 0; j < count; j++)
            {
                neiaInfo2 = new HRPItemScoreInfo();
                TextBox tb2 = GridView2.Rows[j].FindControl("TxtRemarks") as TextBox;//取得所在行的是否合格的列
                neiaInfo2.HRPI_ItemID = new Guid(GridView2.Rows[j].Cells[0].Text);
                neiaInfo2.HRPIS_ItemFScore = 0;
                neiaInfo2.HRPD_ID = neiaInfo1.HRPD_ID;
                neiaInfo2.HRPIS_ItemScore = Int32.Parse(tb2.Text);
                    neiaInfo1.HRPD_FinalScore = neiaInfo1.HRPD_FinalScore + neiaInfo2.HRPIS_ItemScore;
                    hRPItemScoreL.Insert_HRPItemScore(neiaInfo2);
                
            }
            hRPerformceDetailL.Update_HRPerformceDetail(neiaInfo1);
            Panel2.Visible = false;
            BindGridForEmployee(Grid_Detail, "");
            UpdatePanel_SearchEmployee.Update();
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('已提交！')", true);
            int updateState = getReturnState();
            if (updateState == 0)
            {
                yearInfo.HRP_A_State = "已录入";
                //RTX
                string message = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "提交了绩效考核信息，请审核。";
                string sErr = RTXhelper.Send(message,"绩效考核结果审核");
                if (!string.IsNullOrEmpty(sErr))
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('" + sErr + "')", true);
                }
            }
            else
            {
                yearInfo.HRP_A_State = "录入中";
            }
            yearInfo.HRPYear_ID = guidYear;
            yearInfo.HRP_Year = Int32.Parse(LabelYear.Text);
            yearInfo.HRP_Month = Int32.Parse(LabelMonth.Text);
            yearInfo.HRP_C_State = "未审核";
            yearInfo.HRP_C_Person = "";
            hRPerfYearL.Update_HRPerformceYear(yearInfo);

            

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

    #region//公用的函数
    protected int getReturnState()
    {
        String userID = Session["UserId"].ToString();
        DataSet state = hRPerfYearL.Search_HRPerformceYear_State(guidYear, userID);
        DataTable statetable = state.Tables[0];
        int stateInt = Int32.Parse(statetable.Rows[0][0].ToString());
        return stateInt;
    }

    #endregion
    protected void BtncloseGrid_Detail_Click(object sender, EventArgs e)
    {
        Panel_SearchEmployee.Visible = false;
        UpdatePanel_SearchEmployee.Update();
        Panel2.Visible = false;
        UpdatePanel2.Update();
       
    }

    #region//GridView3中的事件
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