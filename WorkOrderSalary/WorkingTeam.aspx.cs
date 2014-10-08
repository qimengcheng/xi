using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.Collections.Generic;
public partial class WorkOrderSalary_WorkingTeam : Page
{
    WOSSalaryL ws = new WOSSalaryL();
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
                Title = "班组信息查看";
                GridView_WOmain.Columns[4].Visible = false;
                GridView_WOmain.Columns[5].Visible = false;

                Button_AddTeam.Visible = false;

                Button_ChosePT.Visible = false;
                GridView_member.Columns[0].Visible = false;
                CheckBoxAll.Visible = false;
                CheckBoxfanxuan.Visible = false;
                Btn_deleting.Visible = false;

            }
            if (state.Trim() == "manage")
            {
                Title = "班组信息维护";
            }

            if (!IsPostBack)
            {
                try
                {
                    if (!((Session["UserRole"].ToString().Contains("班组信息维护")) || (Session["UserRole"].ToString().Contains("班组信息查看"))))
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('可能您没有权限操作和查看本页面，请退出选择其他账号登陆，或联系管理员！')", true);

                        Response.Redirect("~/Default.aspx");

                    }
                    if (!Session["UserRole"].ToString().Contains("班组信息维护"))
                    {
                        GridView_WOmain.Columns[4].Visible = false;
                        GridView_WOmain.Columns[5].Visible = false;

                        Button_AddTeam.Visible = false;

                        Button_ChosePT.Visible = false;
                        GridView_member.Columns[0].Visible = false;
                        CheckBoxAll.Visible = false;
                        CheckBoxfanxuan.Visible = false;
                        Btn_deleting.Visible = false;

                    }
                    label_GridPageState.Text = "默认数据源";
                    string condition = " and 1=1";
                    GridView_WOmain.DataSource = ws.S_WorkingTeam(condition);
                    GridView_WOmain.DataBind();
                    UpdatePanel_WOmain.Update();
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

    public void databind()
    {
        string condition;
        string WT_Name = TextBox_Teamname.Text.Trim() == "" ? " and 1=1 " : " and WT_Name like '%" + TextBox_Teamname.Text.Trim() + "%' ";
        string WT_People = TextBox_makepeople.Text.Trim() == "" ? " and 1=1 " : " and WT_People like '%" + TextBox_makepeople.Text.Trim() + "%' ";
        if ((TextBox_WO_Time1.Text != "" && TextBox_WO_Time2.Text == "") || (TextBox_WO_Time1.Text == "" && TextBox_WO_Time2.Text != ""))
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请将时间检索范围输入完整，请您再次核对！')", true);
            return;
        }
        string WT_Date = (TextBox_WO_Time1.Text.Trim() == "" && TextBox_WO_Time2.Text.Trim() == "") ? " and 1=1 " : " and WT_Date between   ' " + TextBox_WO_Time1.Text.Trim() + "' and ' " + TextBox_WO_Time2.Text.Trim() + "'";



        condition = WT_Name + WT_People + WT_Date;
        GridView_WOmain.DataSource = ws.S_WorkingTeam(condition);
        GridView_WOmain.DataBind();
        UpdatePanel_WOmain.Update();

    }

    protected void Btn_Search_Click(object sender, EventArgs e)
    {
        Panel_add.Visible = false;
        UpdatePanel_add.Update();
        Panel_Member.Visible = false;
        UpdatePanel_Member.Update();
        Panel_People.Visible = false;
        UpdatePanel_People.Update();
        databind();
        label_GridPageState.Text = "检索数据源";
    }
    protected void Button_Cancel_Click(object sender, EventArgs e)
    {
        GridView_WOmain.SelectedIndex = -1;
        TextBox_makepeople.Text = "";
        TextBox_Teamname.Text = "";
        TextBox_WO_Time1.Text = "";
        TextBox_WO_Time2.Text = "";
        TextBox_NO.Text = "";
        TextBox_Name.Text = "";
        Panel_Member.Visible = false;
        UpdatePanel_Member.Update();
        Panel_People.Visible = false;
        UpdatePanel_People.Update();
        databind();
    }
    protected void Button_AddTeam_Click(object sender, EventArgs e)
    {
        Panel_add.Visible = true;
        UpdatePanel_add.Update();
        TextBox_NO.Text = "";
        TextBox_Name.Text = "";
        Panel_Member.Visible = false;
        UpdatePanel_Member.Update();
        Panel_People.Visible = false;
        UpdatePanel_People.Update();
    }
    protected void GridView_WOmain_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;
        GridView_WOmain.SelectedIndex = -1;
        if (-2 == e.NewPageIndex)
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

        databind();
        TextBox_NO.Text = "";
        TextBox_Name.Text = "";
        Panel_add.Visible = false;
        UpdatePanel_add.Update();
        Panel_Member.Visible = false;
        UpdatePanel_Member.Update();
        Panel_People.Visible = false;
        UpdatePanel_People.Update();
    }
    protected void GridView_WOmain_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView_WOmain.EditIndex = -1;
        GridView_WOmain.SelectedIndex = -1;
        Panel_add.Visible = false;
        UpdatePanel_add.Update();
        Panel_Member.Visible = false;
        UpdatePanel_Member.Update();
        Panel_People.Visible = false;
        UpdatePanel_People.Update();
        databind();

    }
    protected void GridView_WOmain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete12")//
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_WOmain.SelectedIndex = row.RowIndex;

            string id = e.CommandArgument.ToString().Trim();
            try
            {
                Guid guid = new Guid(id);
                ws.D_WorkingTeam(guid);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除成功！')", true);

            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除失败！，请您再核对！')", true);

                return;
            }

            //panel 各种隐藏
            Panel_add.Visible = false;
            UpdatePanel_add.Update();
            Panel_Member.Visible = false;
            UpdatePanel_Member.Update();
            Panel_People.Visible = false;
            UpdatePanel_People.Update();
            GridView_WOmain.SelectedIndex = -1;

            databind();


        }

        if (e.CommandName == "membermgt")//
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_WOmain.SelectedIndex = row.RowIndex;
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            label_S.Text = al[1];
            label_SID.Text = al[0];

            CheckBox2.Checked = false;
            Checkfanxuan2.Checked = false;
            //panel 各种隐藏
            Panel_add.Visible = false;
            UpdatePanel_add.Update();
            Panel_Member.Visible = true;
            GridView_member.DataSource = ws.S_WorkTeamDetailList(new Guid(label_SID.Text.Trim()));
            GridView_member.DataBind();


            UpdatePanel_Member.Update();
            Panel_People.Visible = false;
            UpdatePanel_People.Update();





        }

    }
    protected void GridView_WOmain_RowEditing(object sender, GridViewEditEventArgs e)
    {
        label_Sname.Text = GridView_WOmain.Rows[e.NewEditIndex].Cells[1].Text.Trim();
        GridView_WOmain.EditIndex = e.NewEditIndex;
        GridView_WOmain.SelectedIndex = e.NewEditIndex;
        Panel_add.Visible = false;
        UpdatePanel_add.Update();
        Panel_Member.Visible = false;
        UpdatePanel_Member.Update();
        Panel_People.Visible = false;
        UpdatePanel_People.Update();
        databind();
    }
    protected void GridView_WOmain_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string name = ((TextBox)(GridView_WOmain.Rows[e.RowIndex].Cells[1].Controls[0])).Text.Trim().ToString();
        if (name != label_Sname.Text.Trim())
        {

            DataSet ds = ws.S_WorkingTeam(" and WT_Name='" + name + "'");
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count != 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('已存在该班组名称！，请您再核对！')", true);
                return;
            }
            else
            {
                try
                {
                    string people = Session["UserName"].ToString().Trim();
                    Guid guid = new Guid(GridView_WOmain.DataKeys[e.RowIndex].Value.ToString());
                    ws.u_WorkingTeam(guid, people, name);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('编辑成功！')", true);

                }
                catch (Exception)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('编辑失败！，请您再核对！')", true);
                    return;
                }
            }
        }
        GridView_WOmain.EditIndex = -1;
        GridView_WOmain.SelectedIndex = -1;
        databind();

    }
    protected void Button_ADD_Click(object sender, EventArgs e)
    {

        if (TextBox_wtname_Add.Text.Trim() == "")
        {

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('班组名称不能为空！，请您再核对！')", true);
            return;
        }
        DataSet ds = ws.S_WorkingTeam(" and WT_Name='" + TextBox_wtname_Add.Text.Trim() + "'");
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count != 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('已存在该班组名称！，请您再核对！')", true);
            return;
        }
        else
        {
            try
            {
                string wtname = TextBox_wtname_Add.Text.Trim();
                string people = Session["UserName"].ToString().Trim();
                ws.I_WorkingTeam(people, wtname);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('新增成功！')", true);
                Panel_add.Visible = false;
                TextBox_wtname_Add.Text = "";
            }
            catch (Exception)
            {

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('新增失败！，请您再核对！')", true);
                return;
            }
            databind();
        }


    }
    protected void Button_CancelAdd_Click(object sender, EventArgs e)
    {
        Panel_add.Visible = false;
        UpdatePanel_add.Update();
        Panel_Member.Visible = false;
        UpdatePanel_Member.Update();
        Panel_People.Visible = false;
        UpdatePanel_People.Update();
        TextBox_wtname_Add.Text = "";
        databind();
    }
    protected void CheckBoxAll_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= GridView_member.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView_member.Rows[i].FindControl("CheckBox1");
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
        for (int i = 0; i <= GridView_member.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView_member.Rows[i].FindControl("CheckBox1");
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
    protected void Button_ChosePT_Click(object sender, EventArgs e)
    {
        CheckBox2.Checked = false;
        Checkfanxuan2.Checked = false;
        Panel_add.Visible = false;
        UpdatePanel_add.Update();
        Panel_Member.Visible = true;
        UpdatePanel_Member.Update();
        Panel_People.Visible = true;
        string condition = " and HRDD_ID not in( select HRDD_ID from WorkTeamDetailList  where WT_ID='" + label_SID.Text.Trim() + "') ";
        GridView_people.DataSource = ws.S_WorkTeamDetailList_HRDDetail(condition);
        GridView_people.DataBind();
        this.SelectedItems = null;
        UpdatePanel_People.Update();
    }
    protected void Button_CloseTeam_Click(object sender, EventArgs e)
    {
        CheckBox2.Checked = false;
        Checkfanxuan2.Checked = false;
        CheckBoxAll.Checked = false;
        CheckBoxfanxuan.Checked = false;
        Panel_add.Visible = false;
        UpdatePanel_add.Update();
        Panel_Member.Visible = false;
        UpdatePanel_Member.Update();
        Panel_People.Visible = false;
        UpdatePanel_People.Update();

    }
    protected void Button_SearchPeople_click(object sender, EventArgs e)
    {
        databind2();
    }
    protected void Button_ClosePeople_Click(object sender, EventArgs e)
    {
        CheckBox2.Checked = false;
        Checkfanxuan2.Checked = false;
        TextBox_Name.Text = "";
        TextBox_NO.Text = "";
        Panel_People.Visible = false;
        UpdatePanel_People.Update();
    }
    private bool changed = false;

    protected List<string> SelectedItems
    {
        get { return ViewState["selecteditems"] != null ? (List<string>)ViewState["selecteditems"] : null; }
        set { ViewState["selecteditems"] = value; }
    }

    private void GetSelectedItem()
    {
        List<string> selecteditems = null;
        if (this.SelectedItems == null)
        {
            selecteditems = new List<string>();
        }
        else
        {
            selecteditems = this.SelectedItems;
        }

        //获取选择的记录
        for (int i = 0; i < this.GridView_people.Rows.Count; i++)
        {
            CheckBox cbx = (CheckBox)this.GridView_people.Rows[i].FindControl("CheckBox2");

            string id = this.GridView_people.DataKeys[i].Values["HRDD_ID"].ToString();

            if (selecteditems.Contains(id) && !cbx.Checked)
                selecteditems.Remove(id);
            if (!selecteditems.Contains(id) && cbx.Checked)
                selecteditems.Add(id);
        }
        this.SelectedItems = selecteditems;
    }







    protected void CheckBoxAll2_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= GridView_people.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView_people.Rows[i].FindControl("CheckBox2");
            if (CheckBox2.Checked == true)
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
        for (int i = 0; i <= GridView_people.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView_people.Rows[i].FindControl("CheckBox2");
            if (CheckBox.Checked == false)
            {
                CheckBox.Checked = true;
            }
            else
            {
                CheckBox.Checked = false;
            }
        }
        CheckBox2.Checked = false;

    }
    protected void Button_AddPTToSeries_Click(object sender, EventArgs e)
    {
        int sum = 0;
        try
        {
            

              
                //CheckBox CheckBox = (CheckBox)GridView_people.Rows[i].FindControl("CheckBox2");
                //if (CheckBox.Checked == true)
                //{
                //    ws.I_WorkTeamDetailList_HRDDetail(new Guid(label_SID.Text.Trim()), new Guid(GridView_people.DataKeys[i].Values["HRDD_ID"].ToString().Trim()));
                //    sum++;
                //}
                GetSelectedItem();
                foreach (string id in (List<string>)this.SelectedItems)
                 {
                    ws.I_WorkTeamDetailList_HRDDetail(new Guid(label_SID.Text.Trim()), new Guid(id.ToString()));
                    sum++;


                }
                

            
            if (sum == 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('您没选择任何要添加的员工！请您再核对！')", true);
                return;
            }
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('添加成功！')", true);
            this.SelectedItems = null;
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('添加失败！，请您再核对！')", true);


        }
        Panel_add.Visible = false;
        UpdatePanel_add.Update();
        Panel_Member.Visible = true;
        GridView_member.DataSource = ws.S_WorkTeamDetailList(new Guid(label_SID.Text.Trim()));
        GridView_member.DataBind();

        CheckBox2.Checked = false;
        Checkfanxuan2.Checked = false;
        CheckBoxAll.Checked = false;
        CheckBoxfanxuan.Checked = false;
        UpdatePanel_Member.Update();
        Panel_People.Visible = false;
        UpdatePanel_People.Update();
    }
    protected void GridView_member_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;
        GridView_member.SelectedIndex = -1;
        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;

            GridViewRow pagerRow = GridView_member.BottomPagerRow;


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
        newPageIndex = newPageIndex >= GridView_member.PageCount ? GridView_member.PageCount - 1 : newPageIndex;
        GridView_member.PageIndex = newPageIndex;
        GridView_member.PageIndex = newPageIndex;


        CheckBox2.Checked = false;
        Checkfanxuan2.Checked = false;
        CheckBoxAll.Checked = false;
        CheckBoxfanxuan.Checked = false;

        //panel 各种隐藏
        Panel_add.Visible = false;
        UpdatePanel_add.Update();
        Panel_Member.Visible = true;
        GridView_member.DataSource = ws.S_WorkTeamDetailList(new Guid(label_SID.Text.Trim()));
        GridView_member.DataBind();


        UpdatePanel_Member.Update();
        Panel_People.Visible = false;
        UpdatePanel_People.Update();

    }
    public void databind2()
    {
        string condition;
        string number = TextBox_NO.Text.Trim() == "" ? " and 1=1 " : " and HRDD_StaffNO like '%" + TextBox_NO.Text.Trim() + "%' ";
        string name = TextBox_Name.Text.Trim() == "" ? " and 1=1 " : " and HRDD_Name like '%" + TextBox_Name.Text.Trim() + "%' ";
        condition = number + name + " and HRDD_ID not in( select HRDD_ID from WorkTeamDetailList  where WT_ID='" + label_SID.Text.Trim() + "') ";
        GridView_people.DataSource = ws.S_WorkTeamDetailList_HRDDetail(condition);
        GridView_people.DataBind();
        UpdatePanel_People.Update();

    }

    protected void GridView_people_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;
        GridView_people.SelectedIndex = -1;
        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;

            GridViewRow pagerRow = GridView_people.BottomPagerRow;


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
        newPageIndex = newPageIndex >= GridView_people.PageCount ? GridView_people.PageCount - 1 : newPageIndex;
        GridView_people.PageIndex = newPageIndex;
        GridView_people.PageIndex = newPageIndex;


        databind2();
    }
    protected void Btn_deleting_Click(object sender, EventArgs e)
    {
        int sum = 0;
        try
        {
            for (int i = 0; i <= GridView_member.Rows.Count - 1; i++)
            {
                CheckBox CheckBox = (CheckBox)GridView_member.Rows[i].FindControl("CheckBox1");
                if (CheckBox.Checked == true)
                {
                    ws.D_WorkTeamDetailList(new Guid(GridView_member.DataKeys[i].Values["WTDL_ID"].ToString().Trim()));
                    sum++;
                }

            }
            if (sum == 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('您没选择任何要删除的成员！请您再核对！')", true);
                return;
            }
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除成功！')", true);
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除失败！，请您再核对！')", true);


        }
        //panel 各种隐藏
        Panel_add.Visible = false;
        UpdatePanel_add.Update();
        Panel_Member.Visible = true;
        GridView_member.DataSource = ws.S_WorkTeamDetailList(new Guid(label_SID.Text.Trim()));
        GridView_member.DataBind();


        UpdatePanel_Member.Update();
        Panel_People.Visible = false;
        UpdatePanel_People.Update();
    }
    protected void GridView_people_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowIndex > -1 && SelectedItems != null)
        //{
        //    CheckBox cb = (CheckBox)e.Row.Cells[0].FindControl("CheckBox2");

        //    DataRowView drv = (DataRowView)e.Row.DataItem;

        //    if (SelectedItems.Contains(drv["HRDD_ID"].ToString()))
        //        cb.Checked = true;
        //    else
        //        cb.Checked = false;
        //}
        if (e.Row.RowIndex > -1 && this.SelectedItems != null)
        {
            CheckBox cbx = (CheckBox)e.Row.FindControl("CheckBox2");
            string id = this.GridView_people.DataKeys[e.Row.RowIndex].Values["HRDD_ID"].ToString();
            if (SelectedItems.Contains(id))
                cbx.Checked = true;
            else
                cbx.Checked = false;
        }
    }


    protected void GridView_people_DataBinding(object sender, EventArgs e)
    {
        GetSelectedItem();
        changed = true;
    }
}