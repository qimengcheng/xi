using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProjectManagement_CRMNewCustormDevelop : Page
{
    CRMNewCustormDevelopL ccl = new CRMNewCustormDevelopL();
    CRMNewCustormDevelopinfo CRMNewCustormDevelopinfo = new CRMNewCustormDevelopinfo();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!((Session["UserRole"].ToString().Contains("新客户开发"))))
        {
            Response.Redirect("~/Default.aspx");

        }
        if (!IsPostBack)
        {

            BindGridview1("");
            UpdatePanel_OutWeb.Update();
        }
    }
    private void BindGridview1(string Condition)
    {
        Gridview1.DataSource = ccl.SelectCRMNewCustormDevelop(Condition);
        Gridview1.DataBind();
    }
    //检索
    protected void Button1_Sh(object sender, EventArgs e)
    {
        string condition = GetCondition();
        BindGridview1(condition);
        UpdatePanel_OutWeb.Update();
        Panel_SampleNew.Visible = false;
        UpdatePanel_SampleNew.Update();
        Panel_Supply.Visible = false;
        UpdatePanel_Supply.Update();
        Panel_NewProgram.Visible = false;
        UpdatePanel_NewProgram.Update();
        Panel1.Visible = false;
        UpdatePanel1.Update();
    }
    private string GetCondition()
    {
        string condition;
        string item = "";
        if (TextBox_Factory.Text != "")
        {
            item += "and CRMRBI_Name like '%" + TextBox_Factory.Text + "'";
        }
        if (TextBox1.Text != "")
        {
            item += "and CRMCIF_Name like '%" + TextBox1.Text + "'";
        }
        if (DropDownList3.SelectedValue != "请选择")
        {
            item += "and CRMNCD_DevelopState='" + DropDownList3.SelectedValue.ToString() + "'";
        }
        label_QA.Text = item;
        condition = item;
        return condition;
    }
    //新增
    protected void Button3_New(object sender, EventArgs e)
    {
        label_New.Text = "新增客户信息";
        Panel_SampleNew.Visible = true;
        UpdatePanel_SampleNew.Update();
    }
    //重置
    protected void Button3_Reset(object sender, EventArgs e)
    {
        BindGridview1("");
        UpdatePanel_OutWeb.Update();
        TextBox_Factory.Text = "";
        TextBox1.Text = "";
        DropDownList3.SelectedValue = "请选择";
        UpdatePanel_OutsideSampleSearch.Update();
    }
    private void BindGridview_PMSupply()
    {
        Gridview_PMSupply.DataSource = ccl.SelectCRMCustomerInfo_New();
        Gridview_PMSupply.DataBind();
    }
    //选择客户
    protected void Button_SupplySearch(object sender, EventArgs e)
    {
        BindGridview_PMSupply();
        Panel_Supply.Visible = true;
        UpdatePanel_Supply.Update();
    }
    //提交客户信息
    protected void Button1_Com1(object sender, EventArgs e)
    {
        if (TextBox6.Text != "")
        {
            CRMNewCustormDevelopinfo.CRMCIF_ID = new Guid(label_SupplyID.Text.ToString());
            CRMNewCustormDevelopinfo.CRMNCD_Man = Session["UserName"].ToString();

            if (label_New.Text == "新增客户信息")
            {
                ccl.InsertCRMNewCustormDevelop(CRMNewCustormDevelopinfo);
            }
            if (label_New.Text == "修改客户信息")
            {
                CRMNewCustormDevelopinfo.CRMNCD_ID = new Guid(label_ManID.Text);
                ccl.UpdateCRMNewCustormDevelop_Info(CRMNewCustormDevelopinfo);
            }
            TextBox6.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            Panel_SampleNew.Visible = false;
            UpdatePanel_SampleNew.Update();
            BindGridview1("");
            UpdatePanel_OutWeb.Update();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "aa", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
    }
    //取消提交客户信息
    protected void Button_Cancel(object sender, EventArgs e)
    {
        TextBox6.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        Panel_SampleNew.Visible = false;
        UpdatePanel_SampleNew.Update();
    }
    //提交客户
    protected void Button_ComSP(object sender, EventArgs e)
    {
        string Pname;
        bool temp = false;

        foreach (GridViewRow item in Gridview_PMSupply.Rows)
        {
            RadioButton rb = item.FindControl("RadioButtonMarkup") as RadioButton;

            if (rb.Checked)
            {
                Pname = Gridview_PMSupply.DataKeys[item.RowIndex].Value.ToString();
                temp = true;

                label_SupplyID.Text = Pname;
                TextBox6.Text = Gridview_PMSupply.Rows[item.RowIndex].Cells[2].Text.ToString();
                TextBox2.Text = Gridview_PMSupply.Rows[item.RowIndex].Cells[3].Text.ToString();
                TextBox3.Text = Gridview_PMSupply.Rows[item.RowIndex].Cells[4].Text.ToString();
                UpdatePanel_SampleNew.Update();
                Panel_Supply.Visible = false;
                UpdatePanel_Supply.Update();
            }
        }
        if (!temp)
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_Supply, GetType(), "aa", "alert('请选择供应商')", true);
            return;
        }
    }
    //取消查询客户
    protected void Button_CancelSP(object sender, EventArgs e)
    {
        Panel_Supply.Visible = false;
        UpdatePanel_Supply.Update();
    }
    //编辑、删除、开发进度
    protected void Gridview1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Modify1")//编辑
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview1.SelectedIndex = row.RowIndex;
            label_ManID.Text = e.CommandArgument.ToString();
            label_New.Text = "修改客户信息";
            TextBox2.Text = Gridview1.Rows[row.RowIndex].Cells[2].Text.ToString();
            TextBox6.Text = Gridview1.Rows[row.RowIndex].Cells[1].Text.ToString();
            TextBox3.Text = Gridview1.Rows[row.RowIndex].Cells[3].Text.ToString();
            Panel_SampleNew.Visible = true;
            UpdatePanel_SampleNew.Update();
        }
        if (e.CommandName == "Delete1")//删除
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview1.SelectedIndex = row.RowIndex;
            label_ManID.Text = e.CommandArgument.ToString();
            CRMNewCustormDevelopinfo.CRMNCD_ID = new Guid(label_ManID.Text);
            ccl.DeleteCRMNewCustormDevelop(CRMNewCustormDevelopinfo);
            BindGridview1("");
            UpdatePanel_OutWeb.Update();
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_OutWeb, GetType(), "aa", "alert('删除成功！')", true);
            return;
        }
        if (e.CommandName == "Analysis")//开发进度
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview1.SelectedIndex = row.RowIndex;
            label_ManID.Text = e.CommandArgument.ToString();
            label9.Text = Gridview1.Rows[row.RowIndex].Cells[1].Text.ToString() + "   " + Gridview1.Rows[row.RowIndex].Cells[2].Text.ToString() + "   " + Gridview1.Rows[row.RowIndex].Cells[3].Text.ToString();
            string condition;
            condition = "and CRMNCD_ID='" + label_ManID.Text + "'";
            BindGridview2(condition);
            label9.Visible = true;
            if (Gridview2.Rows.Count > 0)
            {
                TextBox10.Text = Gridview2.Rows[0].Cells[2].Text.ToString();
            }
            Panel_NewProgram.Visible = true;
            UpdatePanel_NewProgram.Update();
        }
    }
    //绑定进度表
    private void BindGridview2(string condition)
    {
        Gridview2.DataSource = ccl.SelectCRMNewCustormDevelop(condition);
        Gridview2.DataBind();
    }
    //进度表的编辑、删除
    //protected void Gridview2_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    if (e.CommandName == "Modify")//编辑
    //    {
    //        GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
    //        Gridview2.SelectedIndex = row.RowIndex;
    //        this.label_ProgramID.Text = e.CommandArgument.ToString();
    //        this.label9.Visible = true;
    //        this.DropDownList1.SelectedValue = this.Gridview2.Rows[row.RowIndex].Cells[1].Text.ToString();
    //        this.TextBox10.Text = this.Gridview2.Rows[row.RowIndex].Cells[2].Text.ToString();
    //        this.Panel_NewProgram.Visible = true;
    //        this.UpdatePanel_NewProgram.Update();
    //    }
    //}
    //提交开发进度
    protected void Button_Rocky(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedValue != "请选择")
        {
            CRMNewCustormDevelopinfo.CRMNCD_DevelopState = DropDownList1.SelectedValue.ToString();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_NewProgram, GetType(), "aa", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (TextBox10.Text != "")
        {
            CRMNewCustormDevelopinfo.CRMNCD_DetailCondition = TextBox10.Text;
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_NewProgram, GetType(), "aa", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        CRMNewCustormDevelopinfo.CRMNCD_ID = new Guid(label_ManID.Text.ToString());
        ccl.UpdateCRMNewCustormDevelop_Schedule(CRMNewCustormDevelopinfo);
        TextBox10.Text = "";
        DropDownList1.SelectedValue = "请选择";
        Panel_NewProgram.Visible = false;
        UpdatePanel_NewProgram.Update();
        BindGridview1("");
        UpdatePanel_OutWeb.Update();
    }
    //取消填写进度
    protected void Button_Mel(object sender, EventArgs e)
    {
        TextBox10.Text = "";
        DropDownList1.SelectedValue = "请选择";
        Panel_NewProgram.Visible = false;
        UpdatePanel_NewProgram.Update();
    }
    #region//换页
    protected void Gridview_Project_PageIndexChanging(object sender, GridViewPageEventArgs e)
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
        string Condition = GetCondition();
        BindGridview1(Condition);
        Gridview1.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview1.PageCount ? Gridview1.PageCount - 1 : newPageIndex;
        Gridview1.PageIndex = newPageIndex;
        Gridview1.DataBind();
    }
    protected void Gridview_PMSupply_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview_PMSupply.BottomPagerRow;


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

        BindGridview_PMSupply();
        Gridview_PMSupply.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview_PMSupply.PageCount ? Gridview_PMSupply.PageCount - 1 : newPageIndex;
        Gridview_PMSupply.PageIndex = newPageIndex;
        Gridview_PMSupply.DataBind();
    }
    #endregion
}