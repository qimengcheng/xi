using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class WorkOrderSalary_TimeSalary : Page
{
    WOSSalaryL wosl = new WOSSalaryL();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["state"] == null)
            {
                label_pagestate.Text = "look";
            }
            else
            {
                label_pagestate.Text = Request.QueryString["state"];
            }
            string state = label_pagestate.Text;
            if (state.Trim() == "look")
            {
                Title = "生产计时日提报查看";
                GridView_WOmain.Columns[2].Visible = false;
                Button_AddDate.Visible = false;
                GridView_Craft.Columns[7].Visible = false;
                GridView_AddProject.Columns[0].Visible = false;
                CheckBoxAll.Visible = false;
                CheckBoxfanxuan.Visible = false;
                Button_CheckboxAddProject.Visible = false;
                Button_AddProject.Visible = false;
                Button_Addman.Visible = false;
                Button_Submit.Visible = false;
                GridView_Detail.Columns[5].Visible = false;
                GridView_Detail.Columns[6].Visible = false;
            }
            if (state.Trim() == "manage")
            {
                Title = "生产计时日提报制定";
            }
            if (!IsPostBack)
            {
                try
                {
                    if (!((Session["UserRole"].ToString().Contains("生产计时日提报制定")) || (Session["UserRole"].ToString().Contains("生产计时日提报查看"))))
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('可能您没有权限操作和查看本页面，请退出选择其他账号登陆，或联系管理员！')", true);

                        Response.Redirect("~/Default.aspx");

                    }
                    if (!Session["UserRole"].ToString().Contains("生产计时日提报制定"))
                    {
                        GridView_WOmain.Columns[2].Visible = false;
                        Button_AddDate.Visible = false;
                        GridView_Craft.Columns[7].Visible = false;
                        GridView_AddProject.Columns[0].Visible = false;
                        CheckBoxAll.Visible = false;
                        CheckBoxfanxuan.Visible = false;
                        Button_CheckboxAddProject.Visible = false;
                        Button_Addman.Visible = false;
                        Button_Submit.Visible = false;
                        GridView_Detail.Columns[5].Visible = false;
                        GridView_Detail.Columns[6].Visible = false;

                    }
                    label_GridPageState.Text = "默认数据源";
                    string condition = " and 1=1";
                    GridView_WOmain.DataSource = wosl.S_TimeSalaryDate(condition);
                    GridView_WOmain.DataBind();
                    UpdatePanel_WOmain.Update();
                    GridView_Detail.SelectedIndex = -1;
                    GridView_Detail.EditIndex = -1;
                    //各种pannel隐藏
                    Panel_Craft.Visible = false;
                    UpdatePanel_Craft.Update();
                    Panel_AddProject.Visible = false;
                    UpdatePanel_AddProject.Update();
                    Panel_Detail.Visible = false;
                    UpdatePanel_Detail.Update();
                    Panel_add.Visible = false;
                    UpdatePanel_add.Update();
                    Panel_AddPeople.Visible = false;
                    UpdatePanel_AddPeople.Update();
                }
                catch (Exception)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('可能您没有权限操作和查看本页面，请退出选择其他账号登陆，或联系管理员！')", true);
                    Response.Redirect("~/Default.aspx");
                }

            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('可能您没有权限操作和查看本页面，请退出选择其他账号登陆，或联系管理员！')", true);
            Response.Redirect("~/Default.aspx");
        }


    }


    public void databind1()
    {
        string condition;
        if ((TextBox_Date1.Text != "" && TextBox_Date2.Text == "") || (TextBox_Date1.Text == "" && TextBox_Date2.Text != ""))
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请将时间检索范围输入完整，请您再次核对！')", true);
            return;
        }
        string TSD_Date = (TextBox_Date1.Text.Trim() == "" && TextBox_Date2.Text.Trim() == "") ? " and 1=1 " : " and TSD_Date between   ' " + TextBox_Date1.Text.Trim() + "' and ' " + TextBox_Date2.Text.Trim() + "'";
        condition = TSD_Date;
        GridView_WOmain.DataSource = wosl.S_TimeSalaryDate(condition);
        GridView_WOmain.DataBind();
        UpdatePanel_WOmain.Update();
    }

    public void databind2()
    {
        string condition;
        string PBC_Name = TextBox_Tibao_Craft.Text.Trim() == "" ? " and 1=1 " : " and PBC_Name like '%" + TextBox_Tibao_Craft.Text.Trim() + "%' ";
        string STI_Name = TextBox_Tibao_Project.Text.Trim() == "" ? " and 1=1 " : " and STI_Name like '%" + TextBox_Tibao_Project.Text.Trim() + "%' ";
        string TSDD_Man = TextBox_Tibao_Man.Text.Trim() == "" ? " and 1=1 " : " and TSDD_Man like '%" + TextBox_Tibao_Man.Text.Trim() + "%' ";
        //   string TSDD_RMan = this.TextBox_Tibao_Rman.Text.Trim() == "" ? " and 1=1 " : " and TSDD_RMan like '%" + this.TextBox_Tibao_Rman.Text.Trim() + "%' ";
        condition = PBC_Name + STI_Name + TSDD_Man;
        GridView_Craft.DataSource = wosl.S_TimeSalaryDateDetail(label_TSD_ID.Text.Trim(), condition);
        GridView_Craft.DataBind();
        UpdatePanel_Craft.Update();
    }

    public void databind3()
    {
        string condition;
        string PBC_Name = TextBox_AddProject_Craft.Text.Trim() == "" ? " and 1=1 " : " and PBC_Name like '%" + TextBox_AddProject_Craft.Text.Trim() + "%' ";
        string STI_Name = TextBox_AddProject_Project.Text.Trim() == "" ? " and 1=1 " : " and STI_Name like '%" + TextBox_AddProject_Project.Text.Trim() + "%' ";
        condition = PBC_Name + STI_Name;
        GridView_AddProject.DataSource = wosl.S_TimeSalaryDateDetail_SalaryTimeItem(label_TSD_ID.Text.Trim(), condition);
        GridView_AddProject.DataBind();
        UpdatePanel_AddProject.Update();
    }
    public void databind4()
    {
        string condition;
        string HRDD_StaffNO = TextBox_NO.Text.Trim() == "" ? " and 1=1 " : " and HRDD_StaffNO like '%" + TextBox_NO.Text.Trim() + "%' ";
        string HRDD_Name = TextBox_Name.Text.Trim() == "" ? " and 1=1 " : " and HRDD_Name like '%" + TextBox_Name.Text.Trim() + "%' ";
        condition = HRDD_StaffNO + HRDD_Name;
        GridView_Detail.DataSource = wosl.S_OTime_TimeSalaryDateDetail(label_TSDD_ID.Text.Trim(), condition);
        GridView_Detail.DataBind();
        UpdatePanel_Detail.Update();
    }
    public void databind5()
    {
        string condition;
        string HRDD_StaffNO = TextBox1.Text.Trim() == "" ? " and 1=1 " : " and HRDD_StaffNO like '%" + TextBox1.Text.Trim() + "%' ";
        string HRDD_Name = TextBox2.Text.Trim() == "" ? " and 1=1 " : " and HRDD_Name like '%" + TextBox2.Text.Trim() + "%' ";
        condition = HRDD_StaffNO + HRDD_Name;
        GridView_People.DataSource = wosl.S_OTime_HRDDetail(label_TSDD_ID.Text.Trim(), condition);
        GridView_People.DataBind();
        UpdatePanel_AddPeople.Update();
    }


    protected void Btn_Search_Click(object sender, EventArgs e)
    {
        databind1();
        GridView_Detail.SelectedIndex = -1;
        GridView_Detail.EditIndex = -1;
        //各种pannel隐藏
        Panel_Craft.Visible = false;
        UpdatePanel_Craft.Update();
        Panel_AddProject.Visible = false;
        UpdatePanel_AddProject.Update();
        Panel_Detail.Visible = false;
        UpdatePanel_Detail.Update();
        Panel_add.Visible = false;
        UpdatePanel_add.Update();
        Panel_AddPeople.Visible = false;
        UpdatePanel_AddPeople.Update();
    }
    protected void Button_Cancel_Click(object sender, EventArgs e)
    {
        TextBox_Date1.Text = "";
        TextBox_Date2.Text = "";
        GridView_Detail.SelectedIndex = -1;
        GridView_Detail.EditIndex = -1;
        //各种pannel隐藏
        Panel_Craft.Visible = false;
        UpdatePanel_Craft.Update();
        Panel_AddProject.Visible = false;
        UpdatePanel_AddProject.Update();
        Panel_Detail.Visible = false;
        UpdatePanel_Detail.Update();
        Panel_add.Visible = false;
        UpdatePanel_add.Update();
        Panel_AddPeople.Visible = false;
        UpdatePanel_AddPeople.Update();
        label_GridPageState.Text = "默认数据源";
        string condition = " and 1=1";
        GridView_WOmain.DataSource = wosl.S_TimeSalaryDate(condition);
        GridView_WOmain.DataBind();
        UpdatePanel_WOmain.Update();
    }
    protected void Button_AddDate_Click(object sender, EventArgs e)
    {
        TextBox_Date_Add.Text = "";
        Panel_AddPeople.Visible = false;
        UpdatePanel_AddPeople.Update();
        Panel_Craft.Visible = false;
        UpdatePanel_Craft.Update();
        Panel_AddProject.Visible = false;
        UpdatePanel_AddProject.Update();
        Panel_Detail.Visible = false;
        UpdatePanel_Detail.Update();
        Panel_add.Visible = true;
        UpdatePanel_add.Update();
    }
    protected void Button_ADD_Click(object sender, EventArgs e)
    {
        string condition = " and TSD_Date='" + TextBox_Date_Add.Text.Trim() + "'";
        DataSet ds = wosl.S_TimeSalaryDate(condition);
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count != 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('系统中已有该日期信息，请您再次核对！')", true);
            return;
        }
        else
        {
            DateTime t;
            try
            {
                t = Convert.ToDateTime(TextBox_Date_Add.Text.Trim());
                wosl.I_TimeSalaryDate(t);
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('应输入日期格式！')", true);
                return;
            }

            Panel_add.Visible = false;
            TextBox_Date1.Text = "";
            TextBox_Date2.Text = "";
            databind1();
            TextBox_Date_Add.Text = "";
        }
    }
    protected void Button_CancelAdd_Click(object sender, EventArgs e)
    {
        Panel_add.Visible = false;
        TextBox_Date_Add.Text = "";
    }
    protected void GridView_WOmain_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;
        GridView_WOmain.SelectedIndex = -1;
        if (-1 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;

            GridViewRow pagerRow = GridView_WOmain.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox");
            }

            if (null != txtNewPageIndex && txtNewPageIndex.Text != "")
            {
                newPageIndex = int.Parse(txtNewPageIndex.Text) - 1;
            }
        }
        else
        {
            newPageIndex = e.NewPageIndex;
        }
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView_WOmain.PageCount ? GridView_WOmain.PageCount - 1 : newPageIndex;
        GridView_WOmain.PageIndex = newPageIndex;
        GridView_WOmain.PageIndex = newPageIndex;

        databind1();

        GridView_Detail.SelectedIndex = -1;
        GridView_Detail.EditIndex = -1;
        Panel_Craft.Visible = false;
        UpdatePanel_Craft.Update();
        Panel_AddProject.Visible = false;
        UpdatePanel_AddProject.Update();
        Panel_Detail.Visible = false;
        UpdatePanel_Detail.Update();
        Panel_add.Visible = false;
        UpdatePanel_add.Update();
        Panel_AddPeople.Visible = false;
        UpdatePanel_AddPeople.Update();
    }
    protected void GridView_WOmain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete123")//
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_WOmain.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });

            DataSet ds = wosl.S_TimeSalaryDateDetail_Panduan(new Guid(al[0].Trim()));
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count != 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('该计时提报日期已经制定了进一步详细信息！已经无法删除')", true);
                return;
            }

            else
            {
                wosl.D_TimeSalaryDate(new Guid(al[0].Trim()));
            }

            databind1();
            GridView_WOmain.SelectedIndex = -1;
            GridView_Detail.SelectedIndex = -1;
            GridView_Detail.EditIndex = -1;
            //panel 各种隐藏
            Panel_Craft.Visible = false;
            UpdatePanel_Craft.Update();
            Panel_AddProject.Visible = false;
            UpdatePanel_AddProject.Update();
            Panel_Detail.Visible = false;
            UpdatePanel_Detail.Update();
            Panel_add.Visible = false;
            UpdatePanel_add.Update();
            Panel_AddPeople.Visible = false;
            UpdatePanel_AddPeople.Update();
        }

        if (e.CommandName == "Craft")//
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_WOmain.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            label_TSD_ID.Text = al[0].Trim();
            label_Date.Text = al[1];
            databind2();
            GridView_WOmain.SelectedIndex = -1;
            GridView_Detail.SelectedIndex = -1;
            GridView_Detail.EditIndex = -1;
            //panel 各种隐藏
            Panel_Craft.Visible = true;
            UpdatePanel_Craft.Update();
            Panel_AddProject.Visible = false;
            UpdatePanel_AddProject.Update();
            Panel_Detail.Visible = false;
            UpdatePanel_Detail.Update();
            Panel_add.Visible = false;
            UpdatePanel_add.Update();
            Panel_AddPeople.Visible = false;
            UpdatePanel_AddPeople.Update();
        }

    }
    protected void GridView_Craft_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;
        GridView_Craft.SelectedIndex = -1;
        if (-1 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;

            GridViewRow pagerRow = GridView_Craft.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox");
            }

            if (null != txtNewPageIndex && txtNewPageIndex.Text != "")
            {
                newPageIndex = int.Parse(txtNewPageIndex.Text) - 1;
            }
        }
        else
        {
            newPageIndex = e.NewPageIndex;
        }
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView_Craft.PageCount ? GridView_Craft.PageCount - 1 : newPageIndex;
        GridView_Craft.PageIndex = newPageIndex;
        GridView_Craft.PageIndex = newPageIndex;

        databind2();
        GridView_Detail.SelectedIndex = -1;
        GridView_Detail.EditIndex = -1;
        Panel_Craft.Visible = true;
        UpdatePanel_Craft.Update();
        Panel_AddProject.Visible = false;
        UpdatePanel_AddProject.Update();
        Panel_Detail.Visible = false;
        UpdatePanel_Detail.Update();
        Panel_add.Visible = false;
        UpdatePanel_add.Update();
        Panel_AddPeople.Visible = false;
        UpdatePanel_AddPeople.Update();
    }
    protected void GridView_Craft_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete123")//
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_Craft.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            //  Label_TSDD_State.Text = al[1].Trim();
            if (al[1].Trim() == "已提交")
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('已提交的计时项目不能删除了！')", true);
                return;
            }
            else
            {
                wosl.D_TimeSalaryDateDetail(new Guid(al[0].Trim()));
            }

            databind2();
            GridView_Craft.SelectedIndex = -1;
            GridView_Detail.SelectedIndex = -1;
            GridView_Detail.EditIndex = -1;
            //panel 各种隐藏
            Panel_Craft.Visible = true;
            UpdatePanel_Craft.Update();
            Panel_AddProject.Visible = false;
            UpdatePanel_AddProject.Update();
            Panel_Detail.Visible = false;
            UpdatePanel_Detail.Update();
            Panel_add.Visible = false;
            UpdatePanel_add.Update();
            Panel_AddPeople.Visible = false;
            UpdatePanel_AddPeople.Update();
        }

        if (e.CommandName == "CheckDetail")//
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_Craft.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            label_TSDD_ID.Text = al[0].Trim();
            label_Date3.Text = label_Date.Text + al[1].Trim();
            Label_STI_ID.Text = al[2].Trim();
            Label_TSDD_State.Text = al[3].Trim();
            TextBox_NO.Text = "";
            TextBox_Name.Text = "";
            databind4();
            GridView_Craft.SelectedIndex = -1;
            GridView_Detail.SelectedIndex = -1;
            GridView_Detail.EditIndex = -1;
            //panel 各种隐藏
            Panel_Craft.Visible = true;
            UpdatePanel_Craft.Update();
            Panel_AddProject.Visible = false;
            UpdatePanel_AddProject.Update();
            Panel_Detail.Visible = true;
            UpdatePanel_Detail.Update();
            Panel_add.Visible = false;
            UpdatePanel_add.Update();
            Panel_AddPeople.Visible = false;
            UpdatePanel_AddPeople.Update();
        }


    }

    protected void GridView_Detail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;
        GridView_Detail.SelectedIndex = -1;
        if (-1 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;

            GridViewRow pagerRow = GridView_Detail.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox");
            }

            if (null != txtNewPageIndex && txtNewPageIndex.Text != "")
            {
                newPageIndex = int.Parse(txtNewPageIndex.Text) - 1;
            }
        }
        else
        {
            newPageIndex = e.NewPageIndex;
        }
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView_Detail.PageCount ? GridView_Detail.PageCount - 1 : newPageIndex;
        GridView_Detail.PageIndex = newPageIndex;
        GridView_Detail.PageIndex = newPageIndex;

        databind4();
        GridView_Detail.SelectedIndex = -1;
        GridView_Detail.EditIndex = -1;
        //panel 各种隐藏
        Panel_Craft.Visible = true;
        UpdatePanel_Craft.Update();
        Panel_AddProject.Visible = false;
        UpdatePanel_AddProject.Update();
        Panel_Detail.Visible = true;
        UpdatePanel_Detail.Update();
        Panel_add.Visible = false;
        UpdatePanel_add.Update();
        Panel_AddPeople.Visible = false;
        UpdatePanel_AddPeople.Update();
    }
    protected void GridView_Detail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteDetail")//
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;

            if (Label_TSDD_State.Text.Trim() == "已提交")
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('详细信息已经提交，无法删除！')", true);
                return;
            }
            try
            {
                wosl.D_OTime(new Guid(e.CommandArgument.ToString().Trim()));
            }
            catch
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除失败！')", true);
                return;
            }

            databind4();

            GridView_Detail.SelectedIndex = -1;
            GridView_Detail.EditIndex = -1;
            //panel 各种隐藏
            Panel_Craft.Visible = true;
            UpdatePanel_Craft.Update();
            Panel_AddProject.Visible = false;
            UpdatePanel_AddProject.Update();
            Panel_Detail.Visible = true;
            UpdatePanel_Detail.Update();
            Panel_add.Visible = false;
            UpdatePanel_add.Update();
            Panel_AddPeople.Visible = false;
            UpdatePanel_AddPeople.Update();
        }
    }
    protected void Btn_Tibao_Search_Click(object sender, EventArgs e)
    {
        databind2();
    }
    protected void Button_Tibao_Cancel_Click(object sender, EventArgs e)
    {

        TextBox_Tibao_Craft.Text = "";
        TextBox_Tibao_Man.Text = "";
        TextBox_Tibao_Project.Text = "";
        //  TextBox_Tibao_Rman.Text = "";
        databind2();
    }
    protected void Button_AddProject_Click(object sender, EventArgs e)
    {
        label_Date2.Text = label_Date.Text;
        Panel_AddProject.Visible = true;
        databind3();

    }
    protected void Button_Close_Click(object sender, EventArgs e)
    {
        TextBox_Tibao_Craft.Text = "";
        TextBox_Tibao_Man.Text = "";
        TextBox_Tibao_Project.Text = "";
        //    TextBox_Tibao_Rman.Text = "";
        GridView_Detail.SelectedIndex = -1;
        GridView_Detail.EditIndex = -1;
        Panel_Craft.Visible = false;
        UpdatePanel_Craft.Update();
        Panel_AddProject.Visible = false;
        UpdatePanel_AddProject.Update();
        Panel_Detail.Visible = false;
        UpdatePanel_Detail.Update();
        Panel_add.Visible = false;
        UpdatePanel_add.Update();
        Panel_AddPeople.Visible = false;
        UpdatePanel_AddPeople.Update();
    }
    protected void GridView_AddProject_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;
        GridView_AddProject.SelectedIndex = -1;
        if (-1 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;

            GridViewRow pagerRow = GridView_AddProject.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox");
            }

            if (null != txtNewPageIndex && txtNewPageIndex.Text != "")
            {
                newPageIndex = int.Parse(txtNewPageIndex.Text) - 1;
            }
        }
        else
        {
            newPageIndex = e.NewPageIndex;
        }
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView_AddProject.PageCount ? GridView_AddProject.PageCount - 1 : newPageIndex;
        GridView_AddProject.PageIndex = newPageIndex;
        GridView_AddProject.PageIndex = newPageIndex;

        databind3();
        GridView_Detail.SelectedIndex = -1;
        GridView_Detail.EditIndex = -1;
        Panel_Craft.Visible = true;
        UpdatePanel_Craft.Update();
        Panel_AddProject.Visible = true;
        UpdatePanel_AddProject.Update();
        Panel_Detail.Visible = false;
        UpdatePanel_Detail.Update();
        Panel_add.Visible = false;
        UpdatePanel_add.Update();
    }
    protected void Button_AddProject_Search_Click(object sender, EventArgs e)
    {
        databind3();
    }
    protected void ButtonButton_AddProject_Cancel_Click(object sender, EventArgs e)
    {
        TextBox_AddProject_Craft.Text = "";
        TextBox_AddProject_Project.Text = "";
        databind3();
    }
    protected void CheckBoxAll_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= GridView_AddProject.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView_AddProject.Rows[i].FindControl("CheckBox1");
            if (CheckBoxAll.Checked == true)
            {
                CheckBox.Checked = true;
            }
            else
            {
                CheckBox.Checked = false;
            }
        }
        CheckBoxfanxuan.Checked = false;
    }
    protected void Checkfanxuan_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= GridView_AddProject.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView_AddProject.Rows[i].FindControl("CheckBox1");
            if (CheckBox.Checked == false)
            {
                CheckBox.Checked = true;
            }
            else
            {
                CheckBox.Checked = false;
            }
        }
        CheckBoxAll.Checked = false;
    }
    protected void Button_CheckboxAddProject_Click(object sender, EventArgs e)
    {
        int sum = 0;
        if (label_TSD_ID.Text.Trim() == "00000000-0000-0000-0000-000000000000")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('添加失败！')", true);
            return;
        }
        else
        {
            for (int i = 0; i <= GridView_AddProject.Rows.Count - 1; i++)
            {
                CheckBox CheckBox = (CheckBox)GridView_AddProject.Rows[i].FindControl("CheckBox1");
                if (CheckBox.Checked == true)
                {
                    try
                    {
                        string a = label_TSD_ID.Text.Trim();
                        string b = GridView_AddProject.DataKeys[i].Values["STI_ID"].ToString().Trim();
                        wosl.I_TimeSalaryDateDetail(new Guid(a), new Guid(b), Session["UserName"].ToString().Trim());
                        sum++;
                    }
                    catch (Exception)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('添加失败！')", true);
                        return;
                    }
                }

            }
            if (sum == 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('您没选择任何要添加的计时项目！，请您再核对！')", true);
                return;
            }

            CheckBoxAll.Checked = false;
            CheckBoxfanxuan.Checked = false;
            databind2();
            Panel_AddProject.Visible = false;
            UpdatePanel_AddProject.Update();

        }
    }
    protected void Button_SearchDetail_Click(object sender, EventArgs e)
    {
        databind4();
    }
    protected void Button_ResetDetail_Click(object sender, EventArgs e)
    {
        TextBox_NO.Text = "";
        TextBox_Name.Text = "";
        databind4();
    }
    protected void Button_Addman_Click(object sender, EventArgs e)
    {
        if (Label_TSDD_State.Text.Trim() == "已提交")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('详细信息已经提交，无法修改！')", true);
            return;
        }
        Panel_AddPeople.Visible = true;
        databind5();

    }
    protected void Button_CloseDetail_Click(object sender, EventArgs e)
    {
        GridView_Detail.SelectedIndex = -1;
        GridView_Detail.EditIndex = -1;
        //panel 各种隐藏
        Panel_Craft.Visible = true;
        UpdatePanel_Craft.Update();
        Panel_AddProject.Visible = false;
        UpdatePanel_AddProject.Update();
        Panel_Detail.Visible = false;
        UpdatePanel_Detail.Update();
        Panel_add.Visible = false;
        UpdatePanel_add.Update();
        Panel_AddPeople.Visible = false;
        UpdatePanel_AddPeople.Update();
    }
    protected void GridView_Detail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        if (Label_TSDD_State.Text.Trim() == "已提交")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('详细信息已经提交，无法修改！')", true);
            return;
        }

        GridView_Detail.EditIndex = e.NewEditIndex;
        databind4();

        //panel 各种隐藏
        Panel_Craft.Visible = true;
        UpdatePanel_Craft.Update();
        Panel_AddProject.Visible = false;
        UpdatePanel_AddProject.Update();
        Panel_Detail.Visible = true;
        UpdatePanel_Detail.Update();
        Panel_add.Visible = false;
        UpdatePanel_add.Update();
        Panel_AddPeople.Visible = false;
        UpdatePanel_AddPeople.Update();
    }
    protected void GridView_Detail_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView_Detail.SelectedIndex = -1;
        GridView_Detail.EditIndex = -1;
        databind4();

        //panel 各种隐藏
        Panel_Craft.Visible = true;
        UpdatePanel_Craft.Update();
        Panel_AddProject.Visible = false;
        UpdatePanel_AddProject.Update();
        Panel_Detail.Visible = true;
        UpdatePanel_Detail.Update();
        Panel_add.Visible = false;
        UpdatePanel_add.Update();
        Panel_AddPeople.Visible = false;
        UpdatePanel_AddPeople.Update();
    }
    protected void GridView_Detail_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Guid OT_ID = new Guid(GridView_Detail.DataKeys[e.RowIndex].Values["OT_ID"].ToString());
        try
        {

            decimal t = ((TextBox)(GridView_Detail.Rows[e.RowIndex].Cells[3].Controls[0])).Text.Trim().ToString() == "" ? 0 : Convert.ToDecimal(((TextBox)(GridView_Detail.Rows[e.RowIndex].Cells[3].Controls[0])).Text.Trim().ToString());
            int n = ((TextBox)(GridView_Detail.Rows[e.RowIndex].Cells[4].Controls[0])).Text.Trim().ToString() == "" ? 0 : Convert.ToInt32(((TextBox)(GridView_Detail.Rows[e.RowIndex].Cells[4].Controls[0])).Text.Trim().ToString());
            wosl.U_OTime(OT_ID, t, n);
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请您再次核对输入格式，时间为小数、数量为整数！')", true);
            return;
        }
        GridView_Detail.SelectedIndex = -1;
        GridView_Detail.EditIndex = -1;
        databind4();

        //panel 各种隐藏
        Panel_Craft.Visible = true;
        UpdatePanel_Craft.Update();
        Panel_AddProject.Visible = false;
        UpdatePanel_AddProject.Update();
        Panel_Detail.Visible = true;
        UpdatePanel_Detail.Update();
        Panel_add.Visible = false;
        UpdatePanel_add.Update();
        Panel_AddPeople.Visible = false;
        UpdatePanel_AddPeople.Update();
    }
    protected void GridView_Detail_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if ((e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate)) || (e.Row.RowState == DataControlRowState.Edit))
        {
            TextBox curText;
            for (int i = 3; i <= 4; i++)
            {


                curText = (TextBox)e.Row.Cells[i].Controls[0];

                curText.Attributes.Add("style ", "width:60px;");
            }
            for (int i = 4; i <= 4; i++)
            {
                ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("style", "ime-mode:disabled");
                ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("onkeyup", "this.value=this.value.replace(/\\D/g,'')");
                ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("MaxLength", "9");
                ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("onafterpaste", "this.value=this.value.replace(/\\D/g,'')");



            }

            for (int i = 3; i <= 3; i++)
            {
                ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("style", "ime-mode:disabled");
                ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("onkeyup", "if(isNaN(value))execCommand('undo')");
                ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("MaxLength", "9");
                ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("onafterpaste", "if(isNaN(value))execCommand('undo')");



            }


        }
    }
    protected void GridView_People_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;
        GridView_People.SelectedIndex = -1;
        if (-1 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;

            GridViewRow pagerRow = GridView_People.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox");
            }

            if (null != txtNewPageIndex && txtNewPageIndex.Text != "")
            {
                newPageIndex = int.Parse(txtNewPageIndex.Text) - 1;
            }
        }
        else
        {
            newPageIndex = e.NewPageIndex;
        }
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView_People.PageCount ? GridView_People.PageCount - 1 : newPageIndex;
        GridView_People.PageIndex = newPageIndex;
        GridView_People.PageIndex = newPageIndex;

        databind5();


    }
    protected void Button_AddPeopleSearch_Click(object sender, EventArgs e)
    {

        databind5();
    }
    protected void Button_AddPeopleCancel_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        databind5();

    }
    protected void Button_AddPeople_close_Click(object sender, EventArgs e)
    {
        Panel_AddPeople.Visible = false;
        UpdatePanel_AddPeople.Update();
    }
    protected void CheckBoxAll2_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= GridView_People.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView_People.Rows[i].FindControl("CheckBox1");
            if (CheckBoxAll2.Checked == true)
            {
                CheckBox.Checked = true;
            }
            else
            {
                CheckBox.Checked = false;
            }
        }
        Checkfanxuan2.Checked = false;
    }
    protected void Checkfanxuan2_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= GridView_People.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView_People.Rows[i].FindControl("CheckBox1");
            if (CheckBox.Checked == false)
            {
                CheckBox.Checked = true;
            }
            else
            {
                CheckBox.Checked = false;
            }
        }
        CheckBoxAll2.Checked = false;
    }
    protected void Button_CheckboxAddProject2_Click(object sender, EventArgs e)
    {
        int sum = 0;
        if (Label_STI_ID.Text.Trim() == "00000000-0000-0000-0000-000000000000")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('添加失败！')", true);
            return;
        }
        else
        {
            for (int i = 0; i <= GridView_People.Rows.Count - 1; i++)
            {
                CheckBox CheckBox = (CheckBox)GridView_People.Rows[i].FindControl("CheckBox1");
                if (CheckBox.Checked == true)
                {
                    try
                    {
                        Guid stiid = new Guid(Label_STI_ID.Text.Trim());
                        Guid tsddid = new Guid(label_TSDD_ID.Text.Trim());
                        Guid hrddid = new Guid(GridView_People.DataKeys[i].Values["HRDD_ID"].ToString().Trim());
                        wosl.I_OTime_HRDDetail(stiid, tsddid, hrddid);
                        sum++;
                    }
                    catch (Exception)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('添加失败！')", true);
                        return;
                    }
                }

            }
            if (sum == 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('您没选择任何要添加的员工！，请您再核对！')", true);
                return;
            }

            CheckBoxAll2.Checked = false;
            Checkfanxuan2.Checked = false;
            databind4();
            databind5();
            Panel_AddPeople.Visible = false;
            UpdatePanel_AddPeople.Update();
        }
    }
    protected void Button_Submit_Click(object sender, EventArgs e)
    {
        if (Label_TSDD_State.Text.Trim() == "已提交")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('详细信息已经提交！请勿重复提交！')", true);
            return;
        }
        try
        {
            wosl.U_TimeSalaryDateDetail(new Guid(label_TSDD_ID.Text.Trim()));
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('提交成功！')", true);

        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('提交失败！，请您再核对！')", true);
            return;
        }
    }
}