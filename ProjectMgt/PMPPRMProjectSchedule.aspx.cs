using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using RTXHelper;


public partial class ProjectManagement_PMPPRMProjectSchedule : Page
{
    PRMProjectL prmp = new PRMProjectL();
    PRMProjectScheduleL prmps = new PRMProjectScheduleL();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!(Session["UserRole"].ToString().Contains("项目进度查看") || Session["UserRole"].ToString().Contains("项目部门设置") || Session["UserRole"].ToString().Contains("项目进度设置")))
        {
            Response.Redirect("~/Default.aspx");
        }

        if (!IsPostBack)
        {
            if (Request.QueryString["state"] == null)
            {
                label_pagestate.Text = "Look";
            }
            else
            {
                label_pagestate.Text = Request.QueryString["state"];
            }
            string state = label_pagestate.Text;
            if (state == "Setting")
            {
                Title = "项目进度设置";
                //this.DropDownList4.Enabled = false;
                //this.DropDownList4.SelectedValue = "总经理审核通过";
                //string Condition = GetCondition();
                BindGridView_Projectinfo("");
                Gridview2.Columns[10].Visible = false;
                Gridview2.Columns[12].Visible = false;
            }
            if (state == "Look")
            {
                Title = "项目进度查看";
                BindGridView_Projectinfo("");
                Button6.Visible = false;
                Button7.Visible = false;
                Button9.Visible = true;
                Gridview2.Columns[10].Visible = false;
                Gridview2.Columns[11].Visible = false;
            }
            if (state == "arrange")
            {
                Title = "项目部门安排";
                //this.DropDownList4.Enabled = false;
                //this.DropDownList4.SelectedValue = "总经理审核通过";
                //string Condition = GetCondition();
                BindGridView_Projectinfo("");
                Gridview2.Columns[11].Visible = false;
                Gridview2.Columns[12].Visible = false;
            }

            UpdatePanel_ProjectSearch.Visible = true;
            Panel_ProjectSearch.Visible = true;
            
            UpdatePanel2_Project.Visible = true;
            UpdatePanel2_Project.Update();
        }
    }
    //项目查询
    private void BindGridView_Projectinfo(string Condition)
    {
        try
        {
            Gridview2.DataSource = prmp.SelectPRMProject(Condition);
            Gridview2.DataBind();
        }
        catch (Exception)
        {
            throw;
        }
    }
    //检索
    protected void Button1_Sh(object sender, EventArgs e)
    {
        try
        {
            string Condition = GetCondition();
            BindGridView_Projectinfo(Condition);
            UpdatePanel2_Project.Visible = true;
            UpdatePanel2_Project.Update();
            Panel_Organization.Visible = false;
            UpdatePanel_Organization.Update();
            Panel_ProjectSchedule.Visible = false;
            UpdatePanel_ProjectSchedule.Update();
            Panel_PSchedule.Visible = false;
            UpdatePanel_PSchedule.Update();
        }
        catch (Exception)
        {
            throw;
        }
    }
    //获取条件
    protected string GetCondition()
    {
        try
        {
            string Condition;
            string item = "";
            if (DropDownList1.Text.ToString() != "请选择")
            {
                item += " and PRMP_ProjectType='" + DropDownList1.SelectedValue.ToString() + "'";
            }
            if (DropDownList4.Text.ToString() != "请选择")
            {
                item += " and PRMP_ProjectStates='" + DropDownList4.SelectedValue.ToString() + "'";
            }
            if (ProjectName.Text.ToString() != "")
            {
                item += " and PRMP_ProjectName  like '%" + ProjectName.Text.ToString() + "%'";
            }
            if (ProjectNum.Text.ToString() != "")
            {
                item += "and PRMP_ProjectNum='" + ProjectNum.Text.ToString() + "'";
            }

            Condition = item;
            labelcodition.Text = Condition;
            return Condition;
        }
        catch (Exception)
        {
            throw;
        }
    }
    //重置
    protected void Button3_Reset(object sender, EventArgs e)
    {
        try
        {
            BindGridView_Projectinfo("");
            UpdatePanel2_Project.Visible = true;
            UpdatePanel2_Project.Update();
            ProjectName.Text = "";
            DropDownList1.SelectedValue = "请选择";
            DropDownList4.SelectedValue = "请选择";
            ProjectNum.Text = "";
        }
        catch (Exception)
        {
            throw;
        }
    }
    //显示所有部门
    private void BindGridView_Organizationinfo(string condition)
    {
        try
        {
            //this.Gridview_Organization.Columns.Clear();
            Gridview_Organization.DataSource = prmps.SelectPRMP_Organization(condition);
            Gridview_Organization.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    //安排部门、设置进度、查看进度的链接
    protected void Gridview_Project_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Check1")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview2.SelectedIndex = row.RowIndex;
            label_supplytypeid.Text = Convert.ToString(e.CommandArgument);
            Guid pps = new Guid(label_supplytypeid.Text);
            DataSet ds = prmp.SelectPRMProject_One(pps);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                label_PNum.Text = dt.Rows[0][1].ToString();
                label_PName.Text = dt.Rows[0][2].ToString();
            }
            label_arrange.Text = label_PNum.Text + "  " + label_PName.Text + "  " + "安排部门";
            BindGridView_Organizationinfo("");
            Panel_Organization.Visible = true;
            UpdatePanel_Organization.Update();

        }
        if (e.CommandName == "Check2")
        {
            // int index = Convert.ToInt32(e.CommandArgument);

            //GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview2.SelectedIndex = row.RowIndex;
            label1_PanelSupply.Text = e.CommandArgument.ToString();
           string sg="";
            label_supplytypeid.Text = Convert.ToString(e.CommandArgument);
            Guid pps = new Guid(label_supplytypeid.Text);
            DataSet ds = prmp.SelectPRMProject_One(pps);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                label_PNum.Text = dt.Rows[0][1].ToString();
                label_PName.Text = dt.Rows[0][2].ToString();
                sg=dt.Rows[0][9].ToString();
            }
        if(Session["Department"].ToString()==sg)
            {
            TextBox1.Text = "";
            TextBox3.Text = "";
            TextBox2.Text = "";
            TextBox4.Text = "";
            labelcodition.Text = "设置";
            Button6.Visible = true;
            Button7.Visible = true;
            Button9.Visible = false;
            Gridview1.Columns[5].Visible = true;
            Gridview1.Columns[6].Visible = true;
            Panel_ProjectSchedule.Visible = true;
            Panel_PSchedule.Visible = true;
            TextBox4.Enabled = true;
            UpdatePanel_ProjectSchedule.Update();
            UpdatePanel_PSchedule.Update();
            label_Setting.Text = label_PNum.Text + "  " + label_PName.Text + "  " + "进度设置";
            label_JDB.Text = label_PNum.Text + "  " + label_PName.Text + "  " + "进度表";
            BindGridView_ProjectSchedule(pps);
            }
            else 
            {
             ScriptManager.RegisterClientScriptBlock(Page, GetType(), "aa", "alert('抱歉，你没有此权限！')", true);
                return;
            }
        }
        if (e.CommandName == "Look1")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview2.SelectedIndex = row.RowIndex;
            label_supplytypeid.Text = Convert.ToString(e.CommandArgument);
            Guid pps = new Guid(label_supplytypeid.Text);
            DataSet ds = prmp.SelectPRMProject_One(pps);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                label_PNum.Text = dt.Rows[0][1].ToString();
                label_PName.Text = dt.Rows[0][2].ToString();
            }
            label_JDB.Text = label_PNum.Text + "  " + label_PName.Text + "  " + "进度表";
            BindGridView_ProjectSchedule(pps);
            Panel_PSchedule.Visible = true;

            Gridview1.Columns[5].Visible = false;
            Gridview1.Columns[6].Visible = false;
            Button6.Visible = false;
            Button7.Visible = false;
            Button9.Visible = true;
            UpdatePanel_PSchedule.Update();
        }
    }
    //部门安排
    protected void Button1_Com(object sender, EventArgs e)
    {
        try
        {
            string Pname;
            bool temp = false;
            Guid rd = new Guid(label_supplytypeid.Text);
            foreach (GridViewRow item in Gridview_Organization.Rows)
            {
                RadioButton rb = item.FindControl("RadioButtonMarkup") as RadioButton;

                if (rb.Checked)
                {
                    Pname = Gridview_Organization.DataKeys[item.RowIndex].Value.ToString();
                    temp = true;
                    prmp.InsertPRMP_ResponDepart(rd, Pname);

                }
            }
            if (!temp)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel_Organization, GetType(), "aa", "alert('请选择部门')", true);
                return;
            }
            else
            {
                TextBox22.Text = "";
                Panel_Organization.Visible = false;
                BindGridView_Projectinfo("");
                UpdatePanel2_Project.Update();
                label_RTX.Text = "ERP系统信息：" + Session["UserName"].ToString() + "于" + DateTime.Now + "完成了" + Gridview2.Rows[Gridview2.SelectedIndex].Cells[2].Text.ToString() + "的项目部门设置，请提交材料。";
                string message = label_RTX.Text;
                string dep = Gridview2.Rows[Gridview2.SelectedIndex].Cells[9].Text.ToString();
               
                string sErr=RTXhelper.SendbyDepAndRole(message,dep, "项目材料维护");
                if (!string.IsNullOrEmpty(sErr))
                {
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
                }

            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    //取消安排部门
    protected void Button1_Cancel(object sender, EventArgs e)
    {
        try
        {
            Panel_Organization.Visible = false;
            UpdatePanel_Organization.Update();
        }
        catch (Exception)
        {
            throw;
        }
    }
    //设置进度
    protected void Button1_Com1(object sender, EventArgs e)
    {
        try
        {
            if (labelcodition.Text == "设置")//新增进度
            {
                string TB1;
                int TB3;
                string TB2;
                int TB4;
                if (TextBox1.Text.ToString() == "")
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel_ProjectSchedule, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                    return;
                }
                else
                {
                    TB1 = TextBox1.Text.ToString();

                }
                if (TextBox3.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel_ProjectSchedule, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                    return;
                }
                else
                {
                    TB3 = Int32.Parse(TextBox3.Text.ToString());
                }
                if (TextBox2.Text.ToString() == "")
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel_ProjectSchedule, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                    return;
                }
                else
                {
                    TB2 = TextBox2.Text.ToString();
                }
                if (TextBox4.Text.ToString() == "")
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel_ProjectSchedule, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                    return;
                }
                else
                {
                    TB4 = Int32.Parse(TextBox4.Text.ToString());
                }

                string condition = "and PRMP_ID='" + label_supplytypeid.Text.ToString() + "'" + "and PRMPS_Num='" + TextBox4.Text.ToString() + "'";
                DataSet ds = prmps.SelectPRMProject_Schedule_One(condition);
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel_ProjectSchedule, GetType(), "alert", "alert('该进度序号已存在！')", true);
                    return;
                }
                else
                {
                    Guid ips = new Guid(label_supplytypeid.Text);
                    string name = Session["UserName"].ToString().Trim();
                    prmps.InsertPRMProjectSchedule(ips, TB1, TB3, TB2, name, TB4);
                    BindGridView_ProjectSchedule(ips);
                }
            }
            if (labelcodition.Text == "修改")//修改进度
            {
                string TB1;
                int TB3;
                string TB2;
                if (TextBox1.Text.ToString() == "")
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel_ProjectSchedule, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                    return;
                }
                else
                {
                    TB1 = TextBox1.Text.ToString();

                }
                if (TextBox3.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel_ProjectSchedule, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                    return;
                }
                else
                {
                    TB3 = Int32.Parse(TextBox3.Text.ToString());
                }
                if (TextBox2.Text.ToString() == "")
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel_ProjectSchedule, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                    return;
                }
                else
                {
                    TB2 = TextBox2.Text.ToString();
                }

                Guid ips = new Guid(label1_BasicID.Text.ToString());
                string name = Session["UserName"].ToString().Trim();
                prmps.UpdatePRMProjectSchedule(ips, TB1, TB3, TB2, name);
                Guid iips = new Guid(label_supplytypeid.Text.ToString());
                BindGridView_ProjectSchedule(iips);


            }
            labelcodition.Text = "设置";
            TextBox4.Enabled = true;
            label_Setting.Text = label_PNum.Text + "  " + label_PName.Text + "  " + "进度设置";
            TextBox1.Text = "";
            TextBox3.Text = "";
            TextBox2.Text = "";
            TextBox4.Text = "";
            Panel_PSchedule.Visible = true;
            UpdatePanel_PSchedule.Update();
        }
        catch (Exception)
        {

            throw;
        }
    }


    //取消设置进度
    protected void Button_Cancel(object sender, EventArgs e)
    {
        try
        {
            TextBox1.Text = "";
            TextBox3.Text = "";
            TextBox2.Text = "";
            TextBox4.Text = "";
            //this.Panel_ProjectSchedule.Visible = false;
            //this.Panel_PSchedule.Visible = false;
            UpdatePanel_PSchedule.Update();
            UpdatePanel_ProjectSchedule.Update();
        }
        catch (Exception)
        {
            throw;
        }
    }
    //获取项目的所有进度
    private void BindGridView_ProjectSchedule(Guid Condition)
    {
        try
        {
            Gridview1.DataSource = prmps.SelectPRMProjectSchedule(Condition);
            Gridview1.DataBind();
        }
        catch (Exception)
        {
            throw;
        }
    }
    //项目进度修改链接

    protected void Gridview_ProjectSchedule_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Edit1")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview1.SelectedIndex = row.RowIndex;
            labelcodition.Text = "修改";
            TextBox4.Enabled = false;
            Panel_ProjectSchedule.Visible = true;
            label1_BasicID.Text = e.CommandArgument.ToString();
            Guid psid = new Guid(label1_BasicID.Text.ToString());
            DataSet ds = prmps.SelectPRMProjectSchedule_One(psid);
            DataTable dt = ds.Tables[0];
            if (ds.Tables[0].Rows.Count > 0)
            {
                TextBox1.Text = dt.Rows[0][0].ToString();
                TextBox3.Text = dt.Rows[0][2].ToString();
                TextBox4.Text = dt.Rows[0][1].ToString();

                TextBox2.Text = dt.Rows[0][3].ToString();

                UpdatePanel_ProjectSchedule.Update();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel_ProjectSchedule, GetType(), "alert", "alert('没有数据')", true);
            }
            Guid pps = new Guid(label_supplytypeid.Text);
            DataSet dss = prmp.SelectPRMProject_One(pps);
            DataTable dtt = dss.Tables[0];
            if (dtt.Rows.Count > 0)
            {
                label_PNum.Text = dtt.Rows[0][1].ToString();
                label_PName.Text = dtt.Rows[0][2].ToString();
            }
            label_Setting.Text = label_PNum.Text + "  " + label_PName.Text + "  " + "进度修改";

        }
        if (e.CommandName == "Cancel1")//删除进度
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview1.SelectedIndex = row.RowIndex;
            string sid = e.CommandArgument.ToString();
            Guid psid = new Guid(sid);
            prmps.DelectPRMProjectSchedule(psid);
            Guid pid = new Guid(label_supplytypeid.Text.ToString());
            BindGridView_ProjectSchedule(pid);
            UpdatePanel_ProjectSchedule.Update();
            label_Setting.Text = label_PNum.Text + "  " + label_PName.Text + "  " + "进度设置";
            labelcodition.Text = "设置";
            TextBox1.Text = "";
            TextBox3.Text = "";
            TextBox2.Text = "";
            TextBox4.Text = "";
            TextBox4.Enabled = true;
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_ProjectSchedule, GetType(), "aa", "alert('删除成功！')", true);
            return;
        }
    }
    //关闭进度表
    protected void Button2_Cancel1(object sender, EventArgs e)
    {
        try
        {
            Panel_ProjectSchedule.Visible = false;
            Panel_PSchedule.Visible = false;
            UpdatePanel_PSchedule.Update();
            UpdatePanel_ProjectSchedule.Update();
        }
        catch (Exception)
        {
            throw;
        }
    }

    #region  //换页
    protected void Gridview_Project_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview2.BottomPagerRow;


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
        string Condition = GetCondition();
        BindGridView_Projectinfo(Condition);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview2.PageCount ? Gridview2.PageCount - 1 : newPageIndex;
        Gridview2.PageIndex = newPageIndex;
        Gridview2.DataBind();

    }
    protected void Gridview_Partment_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview_Organization.BottomPagerRow;


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
        string condition = GetDepartment();
        Gridview_Organization.DataSource = prmps.SelectPRMP_Organization(condition);
        Gridview_Organization.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview_Organization.PageCount ? Gridview_Organization.PageCount - 1 : newPageIndex;
        Gridview_Organization.PageIndex = newPageIndex;
        Gridview_Organization.DataBind();

    }
    protected void Gridview_ProjectSchedule_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview1.BottomPagerRow;


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
        Guid pd = new Guid(label_supplytypeid.Text.ToString());
        BindGridView_ProjectSchedule(pd);

        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview1.PageCount ? Gridview1.PageCount - 1 : newPageIndex;
        Gridview1.PageIndex = newPageIndex;
        Gridview1.DataBind();


    }
    #endregion
    //进度设置完成提交
    protected void Button_CF(object sender, EventArgs e)
    {
        if (Gridview1.Rows.Count == 0)
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_PSchedule, GetType(), "alert", "alert('请设置进度')", true);
        }
        else
        {
            Guid lst = new Guid(label_supplytypeid.Text);
            prmp.UpdatePRMP_ProjectStates(lst, "进度设置完成");
            BindGridView_Projectinfo("");
            UpdatePanel2_Project.Visible = true;
            UpdatePanel2_Project.Update();
            Panel_ProjectSchedule.Visible = false;
            UpdatePanel_ProjectSchedule.Update();
            Panel_PSchedule.Visible = false;
            UpdatePanel_PSchedule.Update();
        }
    }
    //进度设置完成后‘设置进度’链接不可使用
    protected void Gridview2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            DataRowView drv = (DataRowView)e.Row.DataItem;
            if (drv["PRMP_ProjectStates"].ToString().Trim() == "技术副总审核通过")
            {
                e.Row.Cells[11].Enabled = true;
                //e.Row.Cells[10].Enabled = true;
            }
            else
            {
                e.Row.Cells[11].Enabled = false;
                //e.Row.Cells[10].Enabled = false;
            }
            
            //if (drv["PRMP_ProjectStates"].ToString().Trim() == "总经理审核通过" || drv["PRMP_ProjectStates"].ToString().Trim() == "已提交" || drv["PRMP_ProjectStates"].ToString().Trim() == "技术副总审核通过")
            //{
            //    e.Row.Cells[10].Enabled = true;
            //}
            //else
            //{
            //    e.Row.Cells[10].Enabled = false;
            //}
        }

    }




    protected void Gridview_Organization_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            RadioButton rb = (RadioButton)e.Row.FindControl("RadioButtonMarkup");
            if (rb != null)
            {
                rb.Attributes.Add("onclick", "judge(this)");
            }

        }
    }
    protected void Gridview2_DataBound1(object sender, EventArgs e)
    {
        for (int i = 0; i < Gridview2.Rows.Count; i++)
        {
            for (int j = 0; j < Gridview2.Rows[i].Cells.Count; j++)
            {
                Gridview2.Rows[i].Cells[j].ToolTip = Gridview2.Rows[i].Cells[j].Text;
                if (Gridview2.Rows[i].Cells[j].Text.Length > 15)
                {
                    Gridview2.Rows[i].Cells[j].Text = Gridview2.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }
            }
        }
    }


    protected void Gridview1_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Gridview1.Rows.Count; i++)
        {
            for (int j = 0; j < Gridview1.Rows[i].Cells.Count; j++)
            {
                Gridview1.Rows[i].Cells[j].ToolTip = Gridview1.Rows[i].Cells[j].Text;
                if (Gridview1.Rows[i].Cells[j].Text.Length > 15)
                {
                    Gridview1.Rows[i].Cells[j].Text = Gridview1.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }
            }
        }
    }
    protected void Button_Leon(object sender, EventArgs e)
    {
        Panel_PSchedule.Visible = false;
        UpdatePanel_PSchedule.Update();
    }
    //检索部门
    protected void Button1_Kil(object sender, EventArgs e)
    {
        string condition = GetDepartment();
        BindGridView_Organizationinfo(condition);
        UpdatePanel_Organization.Update();
    }
    private string GetDepartment()
    {
        string condition = "";
        if(TextBox22.Text!="")
        {
            condition += "and BDOS_Name like'%" + TextBox22.Text + "%'";
        }
        return condition;
    }
    //重置
    protected void Button_CoMl(object sender, EventArgs e)
    {
        TextBox22.Text = "";
        BindGridView_Organizationinfo("");
        UpdatePanel_Organization.Update();
    }
}
