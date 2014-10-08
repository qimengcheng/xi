using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using RTXHelper;
using System.Data;
using EquipmentMangementAjax.DBUtility;
using System.Data.SqlClient;

public partial class TrainningMgt_TrainningMonthPlan : Page
{
    TrainningMonthPlanL tmpL = new TrainningMonthPlanL();
    TrainingTypeMaintenanceL trainingTypeMaintenanceL = new TrainingTypeMaintenanceL();//用于绑定培训类型
    NETtainningL nETtainningL = new NETtainningL();//用于绑定负责的部门
    HRDDetailL hRDDetailL = new HRDDetailL();//调用该业务逻辑的目的：绑定部门和岗位
    NewEmpInfoAddL neiaL = new NewEmpInfoAddL();//绑定成绩录入人的Gridview

    private static string Condition1;
    private static string Condition2;
    private static string Condition3;//主讲人选择栏,对应的检索条件
    private static string Condition4;
    private static string Condition5;
    private static string Condition6;//
    private static string Condition7;//
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Username"] == null)
        {
            Response.Write("<script type=text/javascript>alert('您长时间未操作，请重新登录！');window.location.href='../Default.aspx';</script>");
        }
        #region//权限控制

        if (!((Session["UserRole"].ToString().Contains("培训计划安排")) || (Session["UserRole"].ToString().Contains("培训计划详情查看")) || Session["UserRole"].ToString().Contains("培训结果录入") || Session["UserRole"].ToString().Contains("培训记录查看")))
        {
            Response.Redirect("../Default.aspx");
        }
        string state = Request.QueryString["status"].ToString();
        if (state.ToString() == "ItemMgt")
        {
            GridTrainingItemDetail.Columns[9].Visible = false;
            GridTrainingItemDetail.Columns[10].Visible = false;
            GridTrainingItemDetail.Columns[11].Visible = false;
            GridTrainingItemDetail.Columns[14].Visible = false;
            GridTrainingItemDetail.Columns[15].Visible = false;
            GridTrainingItemDetail.Columns[23].Visible = false;
            GridTrainingItemDetail.Columns[24].Visible = false;
            GridTrainingItemDetail.Columns[25].Visible = false;
            GridTrainingItemDetail.Columns[26].Visible = false;
            GridTrainingItemDetail.Columns[27].Visible = false;
            GridTrainingItemDetail.Columns[28].Visible = false;
            Condition6 = " ORDER BY TID_State asc,TYPM_Year asc,TID_Month asc";
            Title = "培训计划安排";
        }
        if (state.ToString() == "MonthDetail")
        {
            GridTrainingItemDetail.Columns[9].Visible = false;

            GridTrainingItemDetail.Columns[10].Visible = false;
            GridTrainingItemDetail.Columns[11].Visible = false;
            GridTrainingItemDetail.Columns[14].Visible = false;
            GridTrainingItemDetail.Columns[15].Visible = false;
            GridTrainingItemDetail.Columns[18].Visible = false;
            GridTrainingItemDetail.Columns[20].Visible = false;
            GridTrainingItemDetail.Columns[21].Visible = false;
            GridTrainingItemDetail.Columns[22].Visible = false;
            GridTrainingItemDetail.Columns[23].Visible = false;
            GridTrainingItemDetail.Columns[24].Visible = false;
            GridTrainingItemDetail.Columns[25].Visible = false;
            GridTrainingItemDetail.Columns[27].Visible = false;
            GridTrainingItemDetail.Columns[26].Visible = false;
            GridTrainingItemDetail.Columns[28].Visible = false;
            BtnNew.Visible = false;
            Condition6 = "  order by right(TID_State,2),TYPM_Year,TID_Month";//查看权限的人，首先看到的信息是已提交的
            Title = "培训计划详情查看";
        }
        if (state.ToString() == "ResultInput")
        {
            Title = "培训成绩录入";
            GridTrainingItemDetail.Columns[9].Visible = false;

            GridTrainingItemDetail.Columns[10].Visible = false;
            GridTrainingItemDetail.Columns[11].Visible = false;
            GridTrainingItemDetail.Columns[14].Visible = false;
            GridTrainingItemDetail.Columns[15].Visible = false;
            GridTrainingItemDetail.Columns[18].Visible = false;
            GridTrainingItemDetail.Columns[20].Visible = false;
            GridTrainingItemDetail.Columns[21].Visible = false;
            GridTrainingItemDetail.Columns[22].Visible = false;
            GridTrainingItemDetail.Columns[24].Visible = false;
            GridTrainingItemDetail.Columns[25].Visible = false;
            GridTrainingItemDetail.Columns[27].Visible = false;
            GridTrainingItemDetail.Columns[26].Visible = false;
            GridTrainingItemDetail.Columns[28].Visible = false;
            BtnNew.Visible = false;
            Condition6 = "  order by right(TID_State,2),TYPM_Year,TID_Month ";//培训结果录入权限的人，看到的信息是已提交的,而且只能看到自己能打分的项目
        }

        if (state.ToString() == "ResultReview")
        {
            GridTrainingItemDetail.Columns[9].Visible = false;

            GridTrainingItemDetail.Columns[10].Visible = false;
            GridTrainingItemDetail.Columns[11].Visible = false;
            GridTrainingItemDetail.Columns[14].Visible = false;
            GridTrainingItemDetail.Columns[15].Visible = false;
            GridTrainingItemDetail.Columns[18].Visible = false;
            GridTrainingItemDetail.Columns[20].Visible = false;
            GridTrainingItemDetail.Columns[21].Visible = false;
            GridTrainingItemDetail.Columns[22].Visible = false;
            GridTrainingItemDetail.Columns[23].Visible = false;
            GridTrainingItemDetail.Columns[24].Visible = false;
            GridTrainingItemDetail.Columns[25].Visible = false;
            GridTrainingItemDetail.Columns[27].Visible = false;
            GridTrainingItemDetail.Columns[26].Visible = false;
            GridTrainingItemDetail.Columns[28].Visible = false;
            Condition6 = "  order by right(TID_State,1),TYPM_Year,TID_Month"; ;//查看权限的人
            BtnNew.Visible = false;
            Title = "培训记录查看";
        }

        #endregion
        if (!IsPostBack)
        {
            BindYear(DdlSYears);
            BindDdlMonth(DdlSMonth);
            BindDdlType(DdlSMonthPlanType);

            BindGridTrainingItemDetail("");

            ClosePanel();//关闭上传文件的框

            //try
            //{

            //}
            //catch (Exception)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('可能您没有权限操作和查看本页面，请退出选择其他账号登陆，或联系管理员！')", true);
            //    Response.Redirect("~/Default.aspx");
            //}
        }

    }


    #region//绑定Gridview的方法
    private void BindGridTrainingItemDetail(string Condition)
    {

        GridTrainingItemDetail.DataSource = tmpL.Search_ForArrange_TrainingItemDetail(Condition + Condition6);
        GridTrainingItemDetail.DataBind();
    }//培训项目详情列表GridTrainingItemDetail

    private void BindGrid_Detail(string condition)
    {
        Grid_Detail.DataSource = tmpL.Search_HasInEmpChoose_HRDDetail(" and d.TID_ID= '" + LblBindTID_ID.Text + "'" + condition);
        Grid_Detail.DataBind();
    }//属于该次培训的员工列表Grid_Detail

    private void BindGridViewAdd(string condition)
    {
        GridViewAdd.DataSource = tmpL.Search_ForEmpChoose_HRDDetail(" and a.HRDD_ID not in (select HRDD_ID from TrainingEachEmRecord where TID_ID= '" + LblBindTID_ID.Text + "')" + condition);
        GridViewAdd.DataBind();
    }//员工列表GridViewAdd

    private void BindGridView_Teacher(string Condition)
    {
        GridView_Teacher.DataSource = (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_HRDDetail_TrainingTeacher", new SqlParameter("@Condition", " and UMUI_UserRole like '%培训成绩录入%' " + Condition));
        GridView_Teacher.DataBind();
    }//主讲人列表GridView_Teacher

    private void BindGridView_People(string Condition)
    {
        GridView_People.DataSource = tmpL.Search_HRDDetail_TrainingEachEmRecord(" and d.TID_ID= '" + LblRecordTID_ID.Text + "'" + Condition);
        GridView_People.DataBind();
    }//参与培训的员工列表GridView_People

    private void BindGridViewResult(Guid TID_ID)
    {
        GridViewResult.DataSource = tmpL.Search__TrainingEachEmRecord(TID_ID);
        GridViewResult.DataBind();
    }//老员工培训，培训记录查看

    #endregion


    #region//动态绑定Dropdownlist
    private void BindYear(DropDownList ddl)//绑定年
    {
        ddl.Items.Clear();
        for (int m = 2012; m <= 2035; m++)
        {
            ddl.Items.Add(new ListItem(m.ToString(), m.ToString()));
        }
        ddl.Items.Insert(0, new ListItem("请选择", ""));
        ddl.DataBind();
    }

    private void BindDdlMonth(DropDownList ddl)//绑定月份
    {
        ddl.Items.Clear();
        for (int m = 1; m <= 12; m++)
        {
            ddl.Items.Add(new ListItem(m.ToString(), m.ToString()));
        }
        ddl.Items.Insert(0, new ListItem("请选择", ""));
        ddl.DataBind();
    }

    private void BindDdlType(DropDownList Ddl)//绑定培训类型
    {
        Ddl.DataSource = trainingTypeMaintenanceL.Search_TrainingTypeTable("").Tables[0].DefaultView;
        Ddl.DataTextField = "TTT_Type";
        Ddl.DataValueField = "TTT_TypeID";
        Ddl.DataBind();
        Ddl.Items.Insert(0, new ListItem("请选择", ""));
    }


    private void BindDdlInsertYear(DropDownList Ddl)//插入年计划外的项目中的 年份（其只能是当前状态为已提价的年份）
    {
        Ddl.DataSource = tmpL.Search_ForBindDdlInsertYear().Tables[0].DefaultView;
        Ddl.DataTextField = "TYPM_Year";
        Ddl.DataValueField = "TYPM_ID";
        Ddl.DataBind();
        Ddl.Items.Insert(0, new ListItem("请选择", ""));
    }


    private void BindDdlDep(DropDownList Ddl)//绑定部门
    {
        Ddl.DataSource = nETtainningL.Search_NETrainingItem_BDOrganizationSheet().Tables[0].DefaultView;
        Ddl.DataTextField = "BDOS_Name";
        Ddl.DataValueField = "BDOS_Code";
        Ddl.DataBind();
        Ddl.Items.Insert(0, new ListItem("请选择", ""));
    }

    private void Bind_DdlPost(DropDownList ddl, string BDOS_Code)
    {
        ddl.DataSource = hRDDetailL.SearchDdl_HRDDetail(BDOS_Code).Tables[0].DefaultView;
        ddl.DataTextField = "HRP_Post";
        ddl.DataValueField = "HRP_ID";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("请选择", ""));
    }//绑定Dropdownlist中的DdlDep——岗位,参数是欲绑定岗位的DropDownList和部门代码
    #endregion


    #region//新员工培训信息检索栏
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        GridTrainingItemDetail.SelectedIndex = -1;
        Condition1 = DdlSYears.Text.Trim() == "" ? " " : " and b.TYPM_Year = '" + DdlSYears.Text.Trim() + "'";
        Condition1 += DdlSMonth.Text.Trim() == "" ? " " : " and a.TID_Month = '" + DdlSMonth.Text.Trim() + "'";
        Condition1 += DdlSMonthPlanType.Text.Trim() == "" ? " " : " and c.TTT_TypeID = '" + DdlSMonthPlanType.Text.Trim() + "'";
        Condition1 += TxtSItem.Text.Trim() == "" ? " " : " and TID_TLesson like '%" + TxtSItem.Text.Trim() + "%'";
        Condition1 += TxtSTarget.Text.Trim() == "" ? " " : " and TID_Target like '%" + TxtSTarget.Text.Trim() + "%'";
        Condition1 += TxtSPlace.Text.Trim() == "" ? " " : " and TID_Place like '%" + TxtSPlace.Text.Trim() + "%'";
        Condition1 += TxtSHours.Text.Trim() == "" ? " " : " and TID_CreditHours like '%" + TxtSHours.Text.Trim() + "%'";
        Condition1 += TxtSTeacher.Text.Trim() == "" ? " " : " and TID_Teacher like '%" + TxtSTeacher.Text.Trim() + "%'";
        Condition1 += DropDownList3.Text == "请选择" ? " " : " and  TID_State = '" + DropDownList3.Text + "'";
        Condition1 += TextBox8.Text.Trim() == "" ? " " : " and UMUI_UserName like '%" + TextBox8.Text.Trim() + "%'";
        Condition1 += TextBox11.Text.Trim() == "" ? " " : " and TID_PTime >= '" + TextBox11.Text.Trim() + "'";
        Condition1 += TextBox12.Text.Trim() == "" ? " " : " and TID_PTime <= '" + TextBox12.Text.Trim() + "'";
        Condition1 += DropDownList6.Text == "请选择" ? " " : " and TID_IsCha = '" + DropDownList6.Text + "'";
        LblRecordIsSearch.Text = "检索后";
        BindGridTrainingItemDetail(Condition1);
        UpdatePanel2.Update();
    }//检索
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        GridTrainingItemDetail.SelectedIndex = -1;
        DdlSYears.ClearSelection();
        DdlSMonth.ClearSelection();
        DdlSMonthPlanType.ClearSelection();
        DropDownList3.ClearSelection();
        TxtSItem.Text = "";
        TxtSTarget.Text = "";
        TxtSPlace.Text = "";
        TxtSHours.Text = "";
        TxtSTeacher.Text = "";
        TextBox8.Text = "";
        TextBox11.Text = "";
        TextBox12.Text = "";
        DropDownList6.ClearSelection();
        LblRecordIsSearch.Text = "检索前";
        BindGridTrainingItemDetail("");
        UpdatePanel2.Update();
    }//重置

    protected void BtnNew_Click1(object sender, EventArgs e)
    {
        //LblAddOrEdit.Text = "新增";
        Label18.Text = "年计划外的项目插入";

        Panel3.Visible = true;
        TextBoxYear.Visible = false;
        DdlInsertYear.Visible = true;
        Button3.Visible = true;
        //Button1.Visible = true;
        UpdatePanel3.Update();
        BindDdlInsertYear(DdlInsertYear);//绑定年份
        BindDdlMonth(DropDownList2);//绑定月份
        BindDdlType(DropDownListType);//绑定培训类型
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";
        BindDdlDep(DdlDep);
        TextBox7.Text = "";
        //控制显示
        Button1.Visible = false;
        DdlInsertYear.Enabled = true;
        DropDownList2.Enabled = true;
        DropDownListType.Enabled = true;
        TextBox1.Enabled = true;
        TextBox2.Enabled = true;
        DdlDep.Enabled = true;
    }//插入年计划外的项目
    #endregion


    #region//GridTrainingItemDetail的内置事件
    protected void GridTrainingItemDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (GridTrainingItemDetail.DataKeys[e.Row.RowIndex]["TID_ResourceRoute"].ToString() == "&nbsp;" || GridTrainingItemDetail.DataKeys[e.Row.RowIndex]["TID_ResourceRoute"].ToString() == "")
            {
                e.Row.Cells[24].Enabled = false;
            }
        }
    }
    protected void GridTrainingItemDetail_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < GridTrainingItemDetail.Rows.Count; i++)
        {
            for (int j = 0; j < GridTrainingItemDetail.Rows[i].Cells.Count; j++)
            {
                GridTrainingItemDetail.Rows[i].Cells[j].ToolTip = GridTrainingItemDetail.Rows[i].Cells[j].Text;
                if (GridTrainingItemDetail.Rows[i].Cells[j].Text.Length > 15)
                {
                    GridTrainingItemDetail.Rows[i].Cells[j].Text = GridTrainingItemDetail.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }
            }
        }
    }
    protected void GridTrainingItemDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
        string strState = row.Cells[8].Text.ToString();
        if (e.CommandName == "LookDetail")
        {
            string[] StrArgument = e.CommandArgument.ToString().Split(new char[] { '^' });
            Panel3.Visible = true;
            BindDdlInsertYear(DdlInsertYear);//绑定年份
            DdlInsertYear.Visible = false;
            TextBoxYear.Visible = true;
            BindDdlMonth(DropDownList2);//初始化
            BindDdlType(DropDownListType);//初始化
            BindDdlDep(DdlDep);//初始化
            try
            {
                Label17.Text = StrArgument[0];//记录编辑的主键，必须zai绑定Gridview之前
                UpdatePanel3.Update();
                GridTrainingItemDetail.SelectedIndex = row.RowIndex;
                TextBoxYear.Text = StrArgument[2];
                //DdlInsertYear.Items.FindByValue(tmpInfo.RecordTYPM_Year.ToString()).Selected = true;
                DropDownList2.Text = StrArgument[3];
                DropDownListType.Items.FindByText(StrArgument[5]).Selected = true;
                //DropDownListType.Items.FindByValue(tmpInfo.TTT_Type.ToString()).Selected = true;
                //DropDownListType.Text = tmpInfo.TTT_Type.ToString();
                TextBox1.Text = StrArgument[6];
                TextBox2.Text = StrArgument[7];
                TextBox3.Text = StrArgument[12];
                TextBox4.Text = StrArgument[13];
                TextBox5.Text = StrArgument[8];
                TextBox6.Text = StrArgument[10];
                DdlDep.Items.FindByText(StrArgument[16]).Selected = true;
                //DdlDep.Items.FindByValue(tmpInfo.BDOS_Name.ToString()).Selected = true;
                //DdlDep.Text = tmpInfo.BDOS_Name.ToString();
                TextBox7.Text = StrArgument[11];
                Label18.Text = StrArgument[2] + "年" + StrArgument[3] + "月 " + StrArgument[6] + " 详情信息";//显示标题头
                //控制显示
                DdlInsertYear.Enabled = false;
                DropDownList2.Enabled = false;
                DropDownListType.Enabled = false;
                TextBox1.Enabled = false;
                TextBox2.Enabled = false;
                DdlDep.Enabled = false;
                if (!Button3.Visible)
                    Button3.Visible = true;
                if (Label17.Text != LblBindTID_ID.Text)
                {
                    if (Panel_SearchEmployee.Visible)
                    {
                        Panel_SearchEmployee.Visible = false;
                        UpdatePanel_SearchEmployee.Update();
                    }
                }
                if (Label36.Text != Label17.Text)
                {
                    if (Panel6.Visible)
                    {
                        Panel6.Visible = false;
                        UpdatePanel6.Update();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        if (e.CommandName == "EditDetail")
        {
            string[] StrArgument = e.CommandArgument.ToString().Split(new char[] { '^' });
            if (row.Cells[8].Text == "待完善")
            {
                Panel3.Visible = true;
                BindDdlInsertYear(DdlInsertYear);//绑定年份
                DdlInsertYear.Visible = false;
                TextBoxYear.Visible = true;
                BindDdlMonth(DropDownList2);//初始化
                BindDdlType(DropDownListType);//初始化
                BindDdlDep(DdlDep);//初始化
                try
                {
                    Label17.Text = StrArgument[0];//记录编辑的主键，必须zai绑定Gridview之前
                    UpdatePanel3.Update();
                    GridTrainingItemDetail.SelectedIndex = row.RowIndex;
                    TextBoxYear.Text = StrArgument[2];
                    //DdlInsertYear.Items.FindByValue(tmpInfo.RecordTYPM_Year.ToString()).Selected = true;
                    DropDownList2.Text = StrArgument[3];
                    DropDownListType.Items.FindByText(StrArgument[5]).Selected = true;
                    //DropDownListType.Items.FindByValue(tmpInfo.TTT_Type.ToString()).Selected = true;
                    //DropDownListType.Text = tmpInfo.TTT_Type.ToString();
                    TextBox1.Text = StrArgument[6];
                    TextBox2.Text = StrArgument[7];
                    TextBox3.Text = StrArgument[12];
                    TextBox4.Text = StrArgument[13];
                    TextBox5.Text = StrArgument[8];
                    TextBox6.Text = StrArgument[10];
                    DdlDep.Items.FindByText(StrArgument[16]).Selected = true;
                    //DdlDep.Items.FindByValue(tmpInfo.BDOS_Name.ToString()).Selected = true;
                    //DdlDep.Text = tmpInfo.BDOS_Name.ToString();
                    TextBox7.Text = StrArgument[11];
                    Label18.Text = StrArgument[2] + "年" + StrArgument[3] + "月 " + StrArgument[6] + " 详情信息";//显示标题头
                    //控制显示
                    DdlInsertYear.Enabled = false;
                    DropDownList2.Enabled = false;
                    DropDownListType.Enabled = false;
                    TextBox1.Enabled = false;
                    TextBox2.Enabled = false;
                    DdlDep.Enabled = false;
                    if (!Button3.Visible)
                        Button3.Visible = true;
                    if (Label17.Text != LblBindTID_ID.Text)
                    {
                        if (Panel_SearchEmployee.Visible)
                        {
                            Panel_SearchEmployee.Visible = false;
                            UpdatePanel_SearchEmployee.Update();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script type=text/javascript>alert('出现异常，请联系管理员！！" + ex.ToString() + "');</script>");//不起作用！WHT=Y？
                }
            }
            else
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('只能对待完善状态的信息进行编辑！')", true);

        }
        if (e.CommandName == "LookPerson")
        {
            GridTrainingItemDetail.SelectedIndex = row.RowIndex;
            Panel_SearchEmployee.Visible = true;
            UpdatePanel_SearchEmployee.Update();
            LblBindTID_ID.Text = e.CommandArgument.ToString();
            BindDdlDep(DdlSearchDep);//绑定部门
            Bind_DdlPost(DdlSearchPost, "");//绑定岗位
            BindGrid_Detail("");
            //控制显示
            BtnAddEmployee.Visible = false;
            Grid_Detail.Columns[5].Visible = false;

            if (Label17.Text != LblBindTID_ID.Text)
            {
                if (Panel3.Visible)
                {
                    Panel3.Visible = false;
                    UpdatePanel3.Update();
                }
            }
            if (Label36.Text != LblBindTID_ID.Text)
            {
                if (Panel6.Visible)
                {
                    Panel6.Visible = false;
                    UpdatePanel6.Update();
                }
            }
        }
        if (e.CommandName == "EditPerson")
        {
            if (row.Cells[8].Text == "待完善")
            {
                GridTrainingItemDetail.SelectedIndex = row.RowIndex;
                Panel_SearchEmployee.Visible = true;
                UpdatePanel_SearchEmployee.Update();
                LblBindTID_ID.Text = e.CommandArgument.ToString();
                BindDdlDep(DdlSearchDep);//绑定部门
                Bind_DdlPost(DdlSearchPost, "");//绑定岗位
                BindGrid_Detail("");//绑定Gridview
                //控制显示
                if (!BtnAddEmployee.Visible)
                    BtnAddEmployee.Visible = true;
                if (!Grid_Detail.Columns[5].Visible)
                    Grid_Detail.Columns[5].Visible = true;
                if (Label17.Text != LblBindTID_ID.Text)
                {
                    if (Panel3.Visible)
                    {
                        Panel3.Visible = false;
                        UpdatePanel3.Update();
                    }
                }
            }
            else
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('只能对待完善状态的培训员工进行编辑！')", true);

        }
        if (e.CommandName == "lbtnSubimt")
        {
            string[] StrArgument = e.CommandArgument.ToString().Split(new char[] { '^' });
            if (StrArgument[9] == "待完善")
            {
                int i = 0;
                GridTrainingItemDetail.SelectedIndex = -1;
                if (StrArgument[7] != "" && StrArgument[8] != "&nbsp;" && StrArgument[10] != "" && StrArgument[11] != "")
                {
                    TrainningMonthPlanInfo neiaInfoForSubmit = new TrainningMonthPlanInfo();
                    neiaInfoForSubmit.TID_ID = new Guid(StrArgument[0]);
                    neiaInfoForSubmit.TID_State = "已提交";
                    i = tmpL.Update_ForArrange_TrainingItemDetail(neiaInfoForSubmit);
                    if (LblRecordIsSearch.Text == "检索前")
                        BindGridTrainingItemDetail("");
                    if (LblRecordIsSearch.Text == "检索后")
                        BindGridTrainingItemDetail(Condition1);
                    UpdatePanel2.Update();
                    if (i > 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('已提交！')", true);
                        //控制面板的消失逻辑

                        //RTX
                        string message = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "提交了培训安排，请查看。";
                        string sErr = RTXhelper.Send(message, "培训计划详情查看");
                        if (!string.IsNullOrEmpty(sErr))
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('" + sErr + "')", true);
                        }

                        if (Panel3.Visible | Panel4.Visible | Panel_SearchEmployee.Visible | Panel_AddEmployee.Visible)
                        {

                            Panel4.Visible = false;
                            UpdatePanel4.Update();

                            Panel_SearchEmployee.Visible = false;
                            UpdatePanel_SearchEmployee.Update();

                            Panel_AddEmployee.Visible = false;
                            UpdatePanel_AddEmployee.Update();
                        }
                    }
                    else
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('提交失败，必须具有参与培训的具体员工！')", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请先完善信息才能提交！')", true);
                    return;
                }
            }
            else
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('只能对待完善状态的信息进行提交！')", true);

        }

        if (e.CommandName == "DeleteDetail")
        {

            if (row.Cells[16].Text == "是" && strState == "待完善")
            {
                GridTrainingItemDetail.SelectedIndex = -1;
                tmpL.Delete_OutOfYearPlan_TrainingItemDetail(new Guid(e.CommandArgument.ToString()));
                if (LblRecordIsSearch.Text == "检索前")
                    BindGridTrainingItemDetail("");
                if (LblRecordIsSearch.Text == "检索后")
                    BindGridTrainingItemDetail(Condition1);
                UpdatePanel2.Update();
                //控制面板的消失逻辑
                if (Panel3.Visible || Panel4.Visible || Panel_SearchEmployee.Visible || Panel_AddEmployee.Visible)
                {

                    Panel4.Visible = false;
                    UpdatePanel4.Update();

                    Panel_SearchEmployee.Visible = false;
                    UpdatePanel_SearchEmployee.Update();

                    Panel_AddEmployee.Visible = false;
                    UpdatePanel_AddEmployee.Update();
                }
            }
            else
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('只能删除未提交的年度计划外的信息！')", true);


        }
        if (e.CommandName == "lbtnScore")
        {
            string[] StrArgument = e.CommandArgument.ToString().Split(new char[] { '^' });

            if (strState == "已提交")
            {
                Panel5.Visible = true;
                LblRecordTID_ID.Text = StrArgument[0];
                Label58.Text = StrArgument[2] + "年" + StrArgument[3] + "月 " + StrArgument[6] + " 详情信息";//显示标题头
                BindGridView_People("");
                UpdatePanel5.Update();
            }
            else
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('只能录入已提交状态的信息！')", true);

        }
        if (e.CommandName == "Up2")
        {
            if (strState == "已完成")
            {
                GridTrainingItemDetail.SelectedIndex = row.RowIndex;

                string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
                Guid TTD_DetailID = new Guid(al[0]);
                Label_ttdid.Text = Convert.ToString(TTD_DetailID);
                string TTD_RepRoute = al[1];
                //判重
                if (TTD_RepRoute != "")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('课件已上传,不能重复上传！')", true);
                    return;
                }
                ShowPanel();
                UpdatePanel_upload.Update();
                reportno.Text = "";
            }
            else
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('只能对已完成状态的信息录入培训课件！')", true);


        }
        if (e.CommandName == "Delete2")
        {
            GridTrainingItemDetail.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            Guid TTD_DetailID = new Guid(al[0]);
            string TTD_RepRoute = al[1];
            if (TTD_RepRoute != "")
            {
                string delfile = Server.MapPath("~/") + TTD_RepRoute;
                try
                {
                    File.Delete(delfile);
                    tmpL.Delete_ForDeleteFile_TrainingItemDetail(TTD_DetailID);
                }
                catch (Exception)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除失败，请联系管理员！')", true);
                    return;
                }

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('已删除！')", true);
            }
            BindGridTrainingItemDetail("");
            ClosePanel();
            UpdatePanel_upload.Update();
            UpdatePanel2.Update();
        }
        //if (e.CommandName == "Down2")
        //{
        //    GridTrainingItemDetail.SelectedIndex = row.RowIndex;

        //    string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
        //    string TTD_RepRoute = al[0];
        //    if (TTD_RepRoute == "")
        //    {
        //        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('实验报告未上传,不能下载！')", true);
        //        return;
        //    }
        //    else
        //    {
        //        try
        //        {
        //            HyperLink hp = ((HyperLink)e.CommandSource);
        //            hp.NavigateUrl = "~/" + "TTD_RepRoute" + "?path={0}";
        //        }
        //        catch (Exception)
        //        {

        //            throw;
        //        }


        //    }
        //}

        if (e.CommandName == "LookResult")
        {
            try
            {
                GridTrainingItemDetail.SelectedIndex = row.RowIndex;
                Panel6.Visible = true;
                Label36.Text = e.CommandArgument.ToString();
                BindGridViewResult(new Guid(e.CommandArgument.ToString()));
                UpdatePanel6.Update();

            }
            catch (Exception)
            {

                throw;
            }

            if (LblBindTID_ID.Text != Label36.Text)
            {
                if (Panel_SearchEmployee.Visible)
                {
                    Panel_SearchEmployee.Visible = false;
                    UpdatePanel_SearchEmployee.Update();
                }
            }

            if (Label36.Text != Label17.Text)
            {
                if (Panel3.Visible)
                {
                    Panel3.Visible = false;
                    UpdatePanel3.Update();
                }
            }

        }


    }
    protected void GridTrainingItemDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridTrainingItemDetail.BottomPagerRow;


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
            BindGridTrainingItemDetail("");
        if (LblRecordIsSearch.Text == "检索后")
            BindGridTrainingItemDetail(Condition1);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridTrainingItemDetail.PageCount ? GridTrainingItemDetail.PageCount - 1 : newPageIndex;
        GridTrainingItemDetail.PageIndex = newPageIndex;
        GridTrainingItemDetail.DataBind();
    }
    #endregion


    #region//Label18
    protected void Button3_Click(object sender, EventArgs e)
    {
        if (Label18.Text == "年计划外的项目插入")
        {
            if (DdlInsertYear.Text == "" || DropDownList2.Text == "" || DropDownListType.Text == "" ||
                TextBox1.Text == "" || TextBox2.Text == "" || DdlDep.Text == "" || TextBox4.Text == "" || TextBox7.Text == "" ||
                TextBox5.Text == "" || TextBox6.Text == "" || TextBox3.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            TrainningMonthPlanInfo trainningMonthPlanInfo = new TrainningMonthPlanInfo();
            int i = 0;
            try
            {
                trainningMonthPlanInfo.TTT_TypeID = new Guid(DropDownListType.SelectedValue);
                trainningMonthPlanInfo.TYPM_ID = new Guid(DdlInsertYear.SelectedValue);
                trainningMonthPlanInfo.TID_Month = int.Parse(DropDownList2.Text.ToString());

                int thedate = int.Parse(DdlInsertYear.SelectedItem.ToString() + DropDownList2.Text);
                int nowdate = int.Parse(DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString());
                if (thedate < nowdate)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('培训的年月不能在当前年月之前！')", true);
                    return;
                }

                trainningMonthPlanInfo.TID_TLesson = TextBox1.Text;
                trainningMonthPlanInfo.TID_Target = TextBox2.Text;
                trainningMonthPlanInfo.TID_Place = TextBox3.Text;
                decimal m1;
                if (Decimal.TryParse(TextBox4.Text, out m1))
                    trainningMonthPlanInfo.TID_CreditHours = m1;
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的培训学时！')", true);
                    return;
                }
                trainningMonthPlanInfo.TID_Teacher = TextBox5.Text;
                DateTime d1;

                if (DateTime.TryParse(TextBox6.Text, out d1))
                    trainningMonthPlanInfo.TID_PTime = d1;
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的培训开始时间！')", true);
                    return;
                }
                trainningMonthPlanInfo.BDOS_Code = DdlDep.SelectedValue.ToString();

                DateTime d2;

                if (DateTime.TryParse(TextBox7.Text, out d2))
                    trainningMonthPlanInfo.TID_ActTime = d2;
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的培训结束时间！')", true);
                    return;
                }

                trainningMonthPlanInfo.TID_Maker = Session["Username"].ToString();
                i = tmpL.Insert_OutOfYearPlan_TrainingItemDetail(trainningMonthPlanInfo);
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('新增失败！" + ex.ToString() + "');</script>");
                return;
            }

            if (i > 0)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('新增成功！')", true);
            }
            Panel3.Visible = false;

            UpdatePanel3.Update();
            BindGridTrainingItemDetail("");
            UpdatePanel2.Update();
        }//插入
        if (Label18.Text.ToString().Contains("月"))
        {
            if (TextBoxYear.Text == "" || DropDownList2.Text == "" || DropDownListType.Text == "" ||
                TextBox1.Text == "" || TextBox2.Text == "" || DdlDep.Text == "" || TextBox4.Text == "" || TextBox7.Text == "" ||
                TextBox5.Text == "" || TextBox6.Text == "" || TextBox3.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            TrainningMonthPlanInfo trainningMonthPlanInfo2 = new TrainningMonthPlanInfo();
            int i = 0;
            try
            {
                trainningMonthPlanInfo2.TID_ID = new Guid(Label17.Text);
                //trainningMonthPlanInfo.TYPM_ID = new Guid(DdlInsertYear.SelectedValue);
                //trainningMonthPlanInfo.TID_Month = int.Parse(DropDownList2.Text.ToString());
                //trainningMonthPlanInfo.TID_TLesson = TextBox1.Text;
                //trainningMonthPlanInfo.TID_Target = TextBox2.Text;
                trainningMonthPlanInfo2.TID_Place = TextBox3.Text;
                decimal m1;
                if (Decimal.TryParse(TextBox4.Text, out m1))
                    trainningMonthPlanInfo2.TID_CreditHours = m1;
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的培训学时！')", true);
                    return;
                }
                trainningMonthPlanInfo2.TID_Teacher = TextBox5.Text;
                DateTime d1;

                if (DateTime.TryParse(TextBox6.Text, out d1))
                    trainningMonthPlanInfo2.TID_PTime = d1;
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的培训开始时间！')", true);
                    return;
                }
                DateTime d2;

                if (DateTime.TryParse(TextBox7.Text, out d2))
                    trainningMonthPlanInfo2.TID_ActTime = d2;
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的培训结束时间！')", true);
                    return;
                }
                i = tmpL.Update_ForSave_TrainingItemDetail(trainningMonthPlanInfo2);
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('保存失败！" + ex.ToString() + "');</script>");
                return;
            }

            if (i > 0)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('保存成功！')", true);
            }
            Panel3.Visible = false;

            UpdatePanel3.Update();
            BindGridTrainingItemDetail("");
            UpdatePanel2.Update();
        }//编辑
    }//保存
    protected void Button4_Click(object sender, EventArgs e)
    {
        Panel3.Visible = false;
        UpdatePanel3.Update();
        if (Panel4.Visible)
        {
            Panel4.Visible = false;
            UpdatePanel4.Update();
        }

    }//取消
    protected void Button1_Click(object sender, EventArgs e)
    {
        Panel4.Visible = true;

        BindDdlDep(DropDownList4);//初始化
        TxtAddStaffNO.Text = "";//初始化
        TxtAddName.Text = "";//初始化
        UpdatePanel4.Update();
        BindGridView_Teacher(" ");
        //if (Panel3.Visible)
        //{
        //    if (LblRecordID.Text != e.CommandArgument.ToString())
        //    {
        //        Panel3.Visible = false;
        //        UpdatePanel3.Update();
        //    }
        //}

    }//选择...
    #endregion


    #region//指定培训结果的录入人
    protected void BtnSearchPeopleOut_Click(object sender, EventArgs e)
    {
        Condition3 = TxtAddStaffNO.Text.Trim() == "" ? " " : " and UMUI_UserID like '%" + TxtAddStaffNO.Text.Trim() + "%'";
        Condition3 += TxtAddName.Text.Trim() == "" ? " " : " and UMUI_UserName like '%" + TxtAddName.Text.Trim() + "%'";
        Condition3 += DropDownList4.SelectedItem.ToString() == "请选择" ? " " : " and BDOS_Name ='" + DropDownList4.SelectedItem.ToString() + "'";
        Label24.Text = "检索后";
        BindGridView_Teacher(Condition3);
        UpdatePanel4.Update();
    }//检索
    protected void BtnResetPeopleOut_Click(object sender, EventArgs e)
    {
        TxtAddStaffNO.Text = "";
        TxtAddName.Text = "";
        DropDownList4.ClearSelection();
        Label24.Text = "检索前";
        BindGridView_Teacher("");
        UpdatePanel4.Update();
    }//重置
    protected void Button2_Click(object sender, EventArgs e)
    {

        string Pname;
        bool temp = false;
        try
        {
            foreach (GridViewRow item in GridView_Teacher.Rows)
            {
                RadioButton rb = item.FindControl("RadioButtonMarkup") as RadioButton;

                if (rb.Checked)
                {
                    Pname = GridView_Teacher.Rows[item.RowIndex].Cells[1].Text.ToString();
                    LblRecordPeopleID.Text = GridView_Teacher.Rows[item.RowIndex].Cells[0].Text.ToString();
                    temp = true;
                    TextBox7.Text = Pname;
                }
            }
            if (!temp)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel4, GetType(), "alert", "alert('请选择成绩录入人！')", true);
                return;
            }
            Panel4.Visible = false;
            UpdatePanel4.Update();
            UpdatePanel3.Update();
        }
        catch (Exception)
        {

            throw;
        }


    }//提交
    protected void BtnAddSubmit_Click(object sender, EventArgs e)
    {
        Panel4.Visible = false;
        UpdatePanel4.Update();
    }//取消
    #endregion


    #region//GridView_Teacher的内置事件
    protected void GridView_Teacher_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            RadioButton rb = (RadioButton)e.Row.FindControl("RadioButtonMarkup");
            if (rb != null)
            {
                rb.Attributes.Add("onclick", "judge1(this)");
            }
        }
    }

    protected void GridView_Teacher_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView_Teacher.BottomPagerRow;


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
        if (Label24.Text == "检索前")
        {
            BindGridView_Teacher("");
        }
        if (Label24.Text == "检索后")
        {
            BindGridView_Teacher(Condition3);
        }
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView_Teacher.PageCount ? GridView_Teacher.PageCount - 1 : newPageIndex;
        GridView_Teacher.PageIndex = newPageIndex;
        GridView_Teacher.DataBind();
    }
    #endregion


    #region//培训中已有的员工
    protected void BtnSearchEmployee_Click(object sender, EventArgs e)
    {
        Condition4 = TxtSearchStaffNO.Text.Trim() == "" ? "" : " and HRDD_StaffNO like '%" + TxtSearchStaffNO.Text.Trim() + "%'";
        Condition4 += TxtSearchName.Text.Trim() == "" ? "" : " and HRDD_Name like '%" + TxtSearchName.Text.Trim() + "%'";
        Condition4 += DdlSearchDep.SelectedValue == "" ? "" : " and b.BDOS_Code ='" + DdlSearchDep.SelectedValue + "'";
        Condition4 += DdlSearchPost.SelectedValue == "" ? "" : " and a.HRP_ID ='" + DdlSearchPost.SelectedValue + "'";
        try
        {
            BindGrid_Detail(Condition4);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        UpdatePanel_SearchEmployee.Update();
    }//检索
    protected void BtnAddEmployee_Click(object sender, EventArgs e)
    {
        Panel_AddEmployee.Visible = true;
        BindDdlDep(DdlAddDep);//初始化
        Bind_DdlPost(DdlAddPost, "");//初始化
        UpdatePanel_AddEmployee.Update();
        BindGridViewAdd("");
    }//新增员工
    protected void BtnResetEmployee_Click(object sender, EventArgs e)
    {
        TxtSearchStaffNO.Text = "";
        TxtSearchName.Text = "";
        DdlSearchDep.ClearSelection();
        DdlSearchPost.ClearSelection();
        BindGrid_Detail("");
    }//重置
    protected void BtnCancel2_Click(object sender, EventArgs e)
    {
        Panel_SearchEmployee.Visible = false;
        TxtSearchStaffNO.Text = "";
        TxtSearchName.Text = "";
        DdlSearchDep.ClearSelection();
        DdlSearchPost.ClearSelection();
        UpdatePanel_SearchEmployee.Update();
        if (Panel_AddEmployee.Visible)
        {
            Panel_AddEmployee.Visible = false;
            UpdatePanel_AddEmployee.Update();
        }
    }//关闭
    #endregion


    #region//二级联动
    protected void DdlSearchDep_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind_DdlPost(DdlSearchPost, DdlSearchDep.SelectedValue.ToString());
    }//DdropdownList二级联动:根据部门中的选项，实现下级自动绑定（要实现此方法，前台必须设定触发器,以及该事件源的控件的属性AuotoPostback为true）

    protected void DdlAddDep_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind_DdlPost(DdlAddPost, DdlAddDep.SelectedValue.ToString());
    }
    #endregion


    #region//Grid_Detail属于该次培训的员工列表
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
        BindGrid_Detail("");

        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_Detail.PageCount ? Grid_Detail.PageCount - 1 : newPageIndex;
        Grid_Detail.PageIndex = newPageIndex;
        Grid_Detail.PageIndex = newPageIndex;
        Grid_Detail.DataBind();
    }
    protected void Grid_Detail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete_Detail")
        {

            Guid guid = new Guid(e.CommandArgument.ToString());
            tmpL.Delete_PeopleIn_TrainingEachEmRecord(guid);
            BindGrid_Detail("");
            UpdatePanel_SearchEmployee.Update();
            //if (Panel_AddEmployee.Visible == true)
            //{
            //    BindGridForEmployee(GridViewAdd, con2);
            //    UpdatePanel_AddEmployee.Update();
            //}
        }
    }
    #endregion


    #region//员工新增栏
    protected void BtnAddSearch_Click(object sender, EventArgs e)
    {
        Label34.Text = "检索后";
        Condition5 = TextBox9.Text.Trim() == "" ? "" : " and HRDD_StaffNO like '%" + TextBox9.Text.Trim() + "%'";
        Condition5 += TextBox10.Text.Trim() == "" ? "" : " and HRDD_Name like '%" + TextBox10.Text.Trim() + "%'";
        Condition5 += DdlAddDep.SelectedValue == "" ? "" : " and b.BDOS_Code ='" + DdlAddDep.SelectedValue + "'";
        Condition5 += DdlAddPost.SelectedValue == "" ? "" : " and a.HRP_ID ='" + DdlAddPost.SelectedValue + "'";

        try
        {
            BindGridViewAdd(Condition5);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('检索失败！" + ex + "')", true);
            return;
        }

        UpdatePanel_AddEmployee.Update();
    }//检索
    protected void BtnAddReset_Click(object sender, EventArgs e)
    {
        TextBox9.Text = "";
        TextBox10.Text = "";
        Label34.Text = "检索前";
        DdlAddDep.ClearSelection();
        DdlAddPost.ClearSelection();
        BindGridViewAdd("");
    }//重置
    protected void Button5_Click(object sender, EventArgs e)
    {
        TrainningMonthPlanInfo tmpInfo = new TrainningMonthPlanInfo();
        int count = 0;
        try
        {
            tmpInfo.TID_ID = new Guid(LblBindTID_ID.Text);

            for (int i = 0; i < GridViewAdd.Rows.Count; i++)
            {
                CheckBox cbox = (CheckBox)GridViewAdd.Rows[i].FindControl("CheckBox1");
                if (cbox.Checked)
                {
                    count += 1;
                    tmpInfo.HRDD_ID = new Guid(GridViewAdd.Rows[i].Cells[0].Text.ToString());
                    tmpL.Insert_TrainingEachEmRecord(tmpInfo);
                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('提交失败！" + ex.ToString() + "')", true);
        }
        if (count == 0)
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请选择需要添加进该次培训的员工！')", true);
            return;
        }
        BindGrid_Detail("");
        UpdatePanel_SearchEmployee.Update();
        BindGridViewAdd("");
        UpdatePanel_AddEmployee.Update();
        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('提交成功！')", true);
    }//提交
    protected void BtnAddCancel_Click(object sender, EventArgs e)
    {
        TextBox9.Text = "";
        TextBox10.Text = "";
        DdlAddDep.ClearSelection();
        DdlAddPost.ClearSelection();
        Cbx_SelectAll.Checked = false;
        Cbx_SelectAllCancel.Checked = false;
        Cbx_SelectOpposite.Checked = false;
        Panel_AddEmployee.Visible = false;
        UpdatePanel_AddEmployee.Update();
    }//取消
    #endregion


    #region//复选框的选择
    protected void Cbx_SelectAll_CheckedChanged(object sender, EventArgs e)
    {
        Cbx_SelectAllCancel.Checked = false;
        Cbx_SelectOpposite.Checked = false;
        for (int i = 0; i <= GridViewAdd.Rows.Count - 1; i++)
        {
            CheckBox cbox = (CheckBox)GridViewAdd.Rows[i].FindControl("CheckBox1");

            if (Cbx_SelectAll.Checked)
            {
                cbox.Checked = true;
            }
        }
    }//全选

    protected void Cbx_SelectAllCancel_CheckedChanged(object sender, EventArgs e)
    {
        Cbx_SelectAll.Checked = false;
        Cbx_SelectOpposite.Checked = false;

        for (int i = 0; i <= GridViewAdd.Rows.Count - 1; i++)
        {
            if (Cbx_SelectAllCancel.Checked)
            {
                CheckBox cbox = (CheckBox)GridViewAdd.Rows[i].FindControl("CheckBox1");
                cbox.Checked = false;
            }
        }
    }//全不选

    protected void Cbx_SelectOpposite_CheckedChanged(object sender, EventArgs e)
    {
        Cbx_SelectAll.Checked = false;
        Cbx_SelectAllCancel.Checked = false;
        for (int i = 0; i <= GridViewAdd.Rows.Count - 1; i++)
        {
            CheckBox cbox = (CheckBox)GridViewAdd.Rows[i].FindControl("CheckBox1");
            if (Cbx_SelectOpposite.Checked)
            {
                if (!cbox.Checked)
                {
                    cbox.Checked = true;
                }
                else
                    cbox.Checked = false;
            }
        }
    }//反选
    #endregion


    #region//GridViewAdd的内置事件
    protected void GridViewAdd_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridViewAdd.BottomPagerRow;


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
        if (Label34.Text == "检索前")
            BindGridViewAdd("");
        if (Label34.Text == "检索后")
            BindGridViewAdd(Condition5);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridViewAdd.PageCount ? GridViewAdd.PageCount - 1 : newPageIndex;
        GridViewAdd.PageIndex = newPageIndex;
        GridViewAdd.PageIndex = newPageIndex;
        GridViewAdd.DataBind();
    }
    #endregion


    #region//培训结果录入栏
    protected void BtnOK_Click(object sender, EventArgs e)
    {
        try
        {
            TrainningMonthPlanInfo neiaInfo1 = null;//提交"按钮，插入员工培训结果详情表
            //TrainningMonthPlanInfo neiaInfo2 = new TrainningMonthPlanInfo();
            int count = GridView_People.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                neiaInfo1 = new TrainningMonthPlanInfo();
                DropDownList ddl = GridView_People.Rows[i].FindControl("DropDownList1") as DropDownList;//取得所在行的是否合格的列
                TextBox tb = GridView_People.Rows[i].FindControl("TxtRemarks") as TextBox;//取得所在行的是否合格的列
                neiaInfo1.TEER_ID = new Guid(GridView_People.Rows[i].Cells[0].Text);
                neiaInfo1.TID_ID = new Guid(LblRecordTID_ID.Text);
                neiaInfo1.TEER_Result = ddl.SelectedValue;
                neiaInfo1.TEER_Remark = tb.Text;
                tmpL.Update_ForScore_TrainingEachEmRecord(neiaInfo1);
            }
            //neiaInfo2.TID_ID = new Guid(LblRecordTID_ID.Text);
            //tmpL.Update_ForScore_TrainingItemDetail(neiaInfo2);

            BindGridTrainingItemDetail("");
            UpdatePanel2.Update();
            Panel5.Visible = false;
            GridTrainingItemDetail.SelectedIndex = -1;
            UpdatePanel5.Update();
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('已提交！')", true);
        }
        catch (Exception)
        {

            throw;
        }

    }//提交
    protected void Btnclose_Click(object sender, EventArgs e)
    {
        Panel5.Visible = false;
        UpdatePanel5.Update();
    }//取消
    #endregion


    #region //上传课件
    protected void ok_upload_Click(object sender, EventArgs e)
    {
        if (reportno.Text == "" || FileUpload1.FileName == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        string fileExrensio = Path.GetExtension(FileUpload1.FileName).ToLower();//ToLower转化为小写,获得扩展名
        string UploadURL = Server.MapPath("~/file/");//上传的目录
        string fullname = FileUpload1.FileName;//上传文件的原名
        string newname = DateTime.Now.ToString("yyyyMMddhhmmss");//上传文件重命名
        if (FileUpload1.PostedFile.FileName != null)
        {
            if (fileExrensio == ".doc" || fileExrensio == ".docx" || fileExrensio == ".pdf" || fileExrensio == ".xls" || fileExrensio == ".xlsx"
                || fileExrensio == ".txt" || fileExrensio == ".ppt" || fileExrensio == ".zip")//判断文件扩展名
            {
                try
                {
                    if (!Directory.Exists(UploadURL))//判断文件夹是否已经存在
                    {
                        Directory.CreateDirectory(UploadURL);//创建文件夹
                    }
                    FileUpload1.PostedFile.SaveAs(UploadURL + newname + fullname);//保存上传的文件
                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel_upload, GetType(), "aa", "alert('上传失败!')", true);
                    return;
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "aa", "alert('不支持此文件格式!')", true);
                return;
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_upload, GetType(), "aa", "alert('请选择文件!')", true);
            return;
        }

        //string filePath = UploadURL + newname + fullname;//存储上传的路径
        string filePath = "file/" + newname + fullname;
        Guid TTD_DetailID = new Guid(Label_ttdid.Text.ToString()); ;
        string TTD_ReportNO = reportno.Text;
        string TTD_RepRoute = filePath;

        //判断重复
        //DataSet ds = typeTestL.Search_TypeTestDetail("and TTD_IsUploaded = '是' and TTD_DetailID = '" + this.Label_ttdid.Text + " '");
        //DataTable dt = ds.Tables[0];
        //if (dt.Rows.Count != 0)
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('实验报告已上传,不能重复！')", true);
        //    return;
        //}
        //Grid_TypeTestMan.EditIndex = -1;
        tmpL.Update_ForUP_TrainingItemDetail(TTD_DetailID, TTD_ReportNO, TTD_RepRoute);
        BindGridTrainingItemDetail("");

        ClosePanel();
        UpdatePanel_upload.Update();
    }
    private void ShowPanel()//显示“上传课件”框
    {
        string script = "document.getElementById('Panel99').style.display='';";
        ScriptManager.RegisterStartupScript(Page, GetType(), "ShowPanel", script, true);
    }
    private void ClosePanel()//关闭“上传课件”框
    {
        string script = "document.getElementById('Panel99').style.display='none';";
        ScriptManager.RegisterStartupScript(Page, GetType(), "ClosePanel", script, true);
    }
    protected void cancel_upload_Click(object sender, EventArgs e)
    {
        ClosePanel();
        UpdatePanel_upload.Update();
    }
    #endregion


    #region//培训结果查看
    protected void Button7_Click(object sender, EventArgs e)
    {
        Panel6.Visible = false;
        UpdatePanel6.Update();
    }//关闭
    #endregion
}