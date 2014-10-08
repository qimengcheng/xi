using System;
using System.Web.UI;
using System.Web.UI.WebControls;

using RTXHelper;
using System.Data;
using EquipmentMangementAjax.DBUtility;
using System.Data.SqlClient;

public partial class TrainningMgt_NewEmpTeacherAssign : Page
{
    NewEmpInfoAddL neiaL = new NewEmpInfoAddL();
    private static string Condition1;//检新员工培训主讲人指定，检索培训项目列表对应的检索条件
    private static string Condition2;//培训员工,对应的检索条件
    private static string Condition3;//主讲人选择栏,对应的检索条件
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Department"] == null)
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('您长时间未操作，请重新登录！')", true);
            Response.Redirect("~/Default.aspx");
        }
        #region//权限控制
        if (!(Session["UserRole"].ToString().Contains("新员工培训主讲人分配")))
        {
            Response.Redirect("~/Default.aspx");

        }
        if (Request.QueryString["status"] == "TeacherAssign")
        {
            Title = "新员工培训主讲人分配";
        }
        #endregion


        
        if (!IsPostBack)
        {
            TxtDep.Text = Session["Department"].ToString();
            BindGridView_Info("");
        }
    }


    #region//绑定Gridview
    private void BindGridView_Info(string Condition)
    {
        GridView_Info.DataSource = neiaL.Search_NETraItemChooseTable_NETrainingItem_BD(" and BDOS_Name='" + TxtDep.Text + "' " + Condition);
        GridView_Info.DataBind();
    }//培训项目列表GridView_Info,通过" and c.BDOS_Name='" + TxtDep.Text + "' "来控制登录人只能看到本部门的培训项目信息。

    private void BindGridView_PeopleIn(string Condition)
    {
        GridView_PeopleIn.DataSource = neiaL.Search_NETraItemChooseTable_NETraPeopleChooseTable_HRDDetail(" and d.NETICT_ID='" + LblRecordID.Text + "'" + Condition);
        GridView_PeopleIn.DataBind();
    }//新员工培训的人员列表GridView_PeopleIn

    private void BindGridView_Teacher(string Condition)
    {
        GridView_Teacher.DataSource = (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_HRDDetail_TrainingTeacher", new SqlParameter("@Condition", " and UMUI_UserRole like '%新员工培训结果录入%' " + Condition));
        GridView_Teacher.DataBind();
    }//主讲人列表GridView_Teacher
    #endregion



    #region//检索栏
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        GridView_Info.SelectedIndex = -1;
        //Condition1 = TxtCourse.Text.Trim() == "" ? " " : " and b.NETI_TraningCourse like '%" + TxtCourse.Text.Trim() + "%'";
        //Condition1 += TxtType.Text.Trim() == "" ? " " : " and b.NETI_TraningType like '%" + TxtType.Text.Trim() + "%'";
        //Condition1 += TxtAddPerson.Text.Trim() == "" ? " " : " and d.NETIMT_Person like '%" + TxtAddPerson.Text.Trim() + "%'";
        //Condition1 += TxtStartTime.Text.Trim() == "" ? " " : " and d.NETIMT_Time >= '" + TxtStartTime.Text.Trim() + "'";
        //Condition1 += TxtEndTime.Text.Trim() == "" ? " " : " and d.NETIMT_Time <= '" + TxtEndTime.Text.Trim() + "'";
        Condition1 = TxtCourse.Text.Trim() == "" ? " " : " and NETI_TraningCourse like '%" + TxtCourse.Text.Trim() + "%'";
        Condition1 += TxtType.Text.Trim() == "" ? " " : " and NETI_TraningType like '%" + TxtType.Text.Trim() + "%'";
        Condition1 += TxtAddPerson.Text.Trim() == "" ? " " : " and NETIMT_Person like '%" + TxtAddPerson.Text.Trim() + "%'";
        Condition1 += TxtStartTime.Text.Trim() == "" ? " " : " and NETIMT_Time >= '" + TxtStartTime.Text.Trim() + "'";
        Condition1 += TxtEndTime.Text.Trim() == "" ? " " : " and NETIMT_Time <= '" + TxtEndTime.Text.Trim() + "'";
        Condition1 += TextBox2.Text.Trim() == "" ? " " : " and UMUI_UserName like '%" + TextBox2.Text.Trim() + "%'";
       
        BindGridView_Info(Condition1);
        LblRecordIsSearch.Text = "检索后";
        UpdatePanel2.Update();
    }//检索
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        GridView_Info.SelectedIndex = -1;
        TxtCourse.Text = "";
        TxtType.Text = "";
        TxtAddPerson.Text = "";
        TxtStartTime.Text = "";
        TxtEndTime.Text = "";
        TextBox2.Text = "";
        //DropDownList1.ClearSelection();
        LblRecordIsSearch.Text = "检索前";
        BindGridView_Info("");
        UpdatePanel2.Update();
    }//重置
    #endregion



    #region//GridView_Info的内置事件
    protected void GridView_Info_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView_Info.BottomPagerRow;


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
            BindGridView_Info("");
        if (LblRecordIsSearch.Text == "检索后")
            BindGridView_Info(Condition1);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView_Info.PageCount ? GridView_Info.PageCount - 1 : newPageIndex;
        GridView_Info.PageIndex = newPageIndex;
        GridView_Info.DataBind();
    }
    protected void GridView_Info_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
        if (e.CommandName == "LookPersons")
        {
            Panel3.Visible = true;
            TxtSStaffNO.Text = "";
            TxtSName.Text = "";
            UpdatePanel3.Update();
            GridView_Info.SelectedIndex = row.RowIndex;
            LblRecordID.Text = e.CommandArgument.ToString();
            BindGridView_PeopleIn("");
            if (Panel4.Visible)
            {
                if (LblRecordID1.Text != e.CommandArgument.ToString())
                {
                    Panel4.Visible = false;
                    UpdatePanel4.Update();
                }
            }

        }
        if (e.CommandName == "AddTeacher")
        {
            string[] StrArgument = e.CommandArgument.ToString().Split(new char[] { ',' });

            if (StrArgument[1].ToString() != "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('该次培训已经指定了主讲人！')", true);
                return;
            }

            Panel4.Visible = true;
            TxtAddStaffNO.Text = "";
            TxtAddName.Text = "";
            UpdatePanel4.Update();
            GridView_Info.SelectedIndex = row.RowIndex;
            LblRecordID1.Text = StrArgument[0].ToString();
            BindGridView_Teacher("");
            if (Panel3.Visible)
            {
                if (LblRecordID.Text != StrArgument[0].ToString())
                {
                    Panel3.Visible = false;
                    UpdatePanel3.Update();
                }
            }
        }


    }
    protected void GridView_Info_DataBound(object sender, EventArgs e)
    {

    }
    #endregion


    #region//培训员工
    protected void BtnSearchPeople_Click(object sender, EventArgs e)
    {
        Condition2 = TxtSStaffNO.Text.Trim() == "" ? " " : " and HRDD_StaffNO like '%" + TxtSStaffNO.Text.Trim() + "%'";
        Condition2 += TxtSName.Text.Trim() == "" ? " " : " and HRDD_Name like '%" + TxtSName.Text.Trim() + "%'";
        LblRecordIsSearchForPeople.Text = "检索后";
        BindGridView_PeopleIn(Condition2);
        UpdatePanel3.Update();
    }//检索
    protected void BtnResetPeople_Click(object sender, EventArgs e)
    {
        TxtSStaffNO.Text = "";
        TxtSName.Text = "";
        LblRecordIsSearchForPeople.Text = "检索前";
        BindGridView_PeopleIn("");
        UpdatePanel3.Update();
    }//重置

    protected void BtnClose_Click(object sender, EventArgs e)
    {
        Panel3.Visible = false;
        UpdatePanel3.Update();
        if (Panel4.Visible)
        {
            Panel4.Visible = true;
            UpdatePanel4.Update();
        }
    }//关闭
    #endregion



    #region//GridView_PeopleIn的内置事件
    protected void GridView_PeopleIn_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView_PeopleIn.BottomPagerRow;


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
        if (LblRecordIsSearchForPeople.Text == "检索前")
            BindGridView_PeopleIn(" ");
        if (LblRecordIsSearchForPeople.Text == "检索后")
            BindGridView_PeopleIn(Condition2);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView_PeopleIn.PageCount ? GridView_PeopleIn.PageCount - 1 : newPageIndex;
        GridView_PeopleIn.PageIndex = newPageIndex;
        GridView_PeopleIn.DataBind();
    }
    #endregion


    #region//主讲人选择栏
    protected void BtnSearchPeopleOut_Click(object sender, EventArgs e)
    {
        Condition3 = TxtAddStaffNO.Text.Trim() == "" ? " " : " and UMUI_UserID like '%" + TxtAddStaffNO.Text.Trim() + "%'";
        Condition3 += TxtAddName.Text.Trim() == "" ? " " : " and UMUI_UserName like '%" + TxtAddName.Text.Trim() + "%'";
        Condition3 += TextBox1.Text.Trim() == "" ? " " : " and BDOS_Name like '%" + TextBox1.Text.Trim() + "%'";
        Label9.Text = "检索后";
        BindGridView_Teacher(Condition3);
        UpdatePanel4.Update();
    }//检索
    protected void BtnResetPeopleOut_Click(object sender, EventArgs e)
    {
        TxtAddStaffNO.Text = "";
        TxtAddName.Text = "";
        Label9.Text = "检索前";
        BindGridView_Teacher("");
        UpdatePanel4.Update();
    }//重置

    protected void Button1_Click(object sender, EventArgs e)
    {
        NewEmpInfoAddInfo neiaInfo = new NewEmpInfoAddInfo();
        GridView_Info.SelectedIndex = -1;
        string Pname;
        bool temp = false;
        int i;
        string UMUI_UserName="";

        foreach (GridViewRow item in GridView_Teacher.Rows)
        {
            RadioButton rb = item.FindControl("RadioButtonMarkup") as RadioButton;

            if (rb.Checked)
            {
                Pname = GridView_Teacher.Rows[item.RowIndex].Cells[0].Text.ToString();
                UMUI_UserName = GridView_Teacher.Rows[item.RowIndex].Cells[1].Text.ToString();
                temp = true;
                LblRecordTeacher.Text = Pname;
            }
        }
        if (!temp)
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel4, GetType(), "alert", "alert('请选择主讲人！')", true);
            return;
        }
        try
        {
            neiaInfo.NETICT_ID = new Guid(LblRecordID1.Text);
            neiaInfo.UMUI_UserID = LblRecordTeacher.Text.Trim();
            neiaInfo.NETICT_Person = Session["UserName"].ToString().Trim();
            i = neiaL.Update_ForTeacher_NETraItemChooseTable(neiaInfo);
            if (i > 0)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel4, GetType(), "alert", "alert('提交成功！')", true);

                //RTX
                //string message = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "分配了您为新员工培训主讲人，请进行培训并录入结果。";
                //RTXhelper.Send(message, "新员工培训结果录入");
                //RTX
                string message = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "分配您为此次新员工培训的主讲人，请进行培训并录入结果。";
                string sErr = RTXhelper.SendbyUserName(message, UMUI_UserName);
                if (!string.IsNullOrEmpty(sErr))
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('" + sErr + "')", true);
                }
                Panel4.Visible = false;
                UpdatePanel4.Update();
                if (LblRecordIsSearch.Text == "检索前")
                {
                    BindGridView_Info("");
                    UpdatePanel2.Update();
                }
                if (LblRecordIsSearch.Text == "检索后")
                {
                    BindGridView_Info(Condition1);
                    UpdatePanel2.Update();
                }
                if (Panel3.Visible)
                {
                    Panel3.Visible = false;
                    UpdatePanel3.Update();
                }
                if (Panel4.Visible)
                {
                    Panel4.Visible = false;
                    UpdatePanel4.Update();
                }
            }
            else
                ScriptManager.RegisterClientScriptBlock(UpdatePanel4, GetType(), "alert", "alert('提交失败，请联系管理员！')", true);
        }
        catch (Exception ex)
        {

            ScriptManager.RegisterClientScriptBlock(UpdatePanel4, GetType(), "alert", "alert('提交失败！'" + ex + ")'", true);
        }

    }//提交

    protected void BtnAddSubmit_Click(object sender, EventArgs e)
    {
        Panel4.Visible = false;
        UpdatePanel4.Update();
    }//取消
    #endregion



    #region//GridView_Teacher的 内置事件
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
        if (Label9.Text == "检索前")
        {
            BindGridView_Teacher("");
        }
        if (Label9.Text == "检索后")
        {
            BindGridView_Teacher(Condition3);
        }
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView_Teacher.PageCount ? GridView_Teacher.PageCount - 1 : newPageIndex;
        GridView_Teacher.PageIndex = newPageIndex;
        GridView_Teacher.DataBind();
    }

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
    #endregion

}