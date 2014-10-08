using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PMP_PMPApplyRule : Page
{
    PMPurchaseingApplyRuleL pmp = new PMPurchaseingApplyRuleL();
    PMSupplyMaterialL pl = new PMSupplyMaterialL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!((Session["UserRole"].ToString().Contains("采购申请规则制定"))))
        {
            Response.Redirect("~/Default.aspx");

        }
     
        if (!IsPostBack) 
        {
            Title = "采购规则制定";
            UpdatePanel_PMPApplyRuleSearch.Visible = true;
            BindGridView_PMPApplyRuleinfo_One("");
            UpdatePanel_PMPApplyRuleInfo.Update();

        }
    }
    //查找制定历史
    private void BindGridView_PMPApplyRuleinfo(string Condition)
    {
        try
        {
            Gridview_PMPApplyRuleInfo.DataSource = pmp.SelectPMPurchaseingApplyRule(Condition);
            Gridview_PMPApplyRuleInfo.DataBind();
            Gridview_PMPApplyRuleInfo.Columns[4].Visible = false;
            Gridview_PMPApplyRuleInfo.Columns[5].Visible = false;
        }
        catch (Exception )
        {
            throw;
        }
    }
    private void BindGridView_PMPApplyRuleinfo_One(string Condition)
    {
        try
        {
            Gridview_PMPApplyRuleInfo.DataSource = pmp.SelectPMPurchaseingApplyRule_One(Condition);
            Gridview_PMPApplyRuleInfo.DataBind();
            Gridview_PMPApplyRuleInfo.Columns[4].Visible = true;
            Gridview_PMPApplyRuleInfo.Columns[5].Visible = true;
        }
        catch (Exception )
        {
        throw ;
        }
    }
    //检索
    protected void Button1_Sh(object sender, EventArgs e)
    {
        try
        {
            string Condition = GetCondition();
            if (DDList1.SelectedValue == "是")
            {
                BindGridView_PMPApplyRuleinfo_One(Condition);
            }
            else
            {
                if (DDList1.SelectedValue == "否")
                {
                    BindGridView_PMPApplyRuleinfo(Condition);
                }
            }

            Panel_PMPApplyRuleInfo.Visible = true;
            UpdatePanel_PMPApplyRuleInfo.Update();
        }
        catch (Exception)
        {
            throw;
        }
    }
    protected string GetCondition()
    {
        try
        {
            string Condition;
            string item = "";

            if (TextBox_SPTime2.Text.ToString() != "" && TextBox_SPTime3.Text.ToString() != "")
            {
                item += "and PMPAR_Time>='" + TextBox_SPTime2.Text.ToString() + "' and PMPAR_Time<='" + TextBox_SPTime3.Text.ToString() + "'";
            }
            if (TextBox_SPTime2.Text.ToString() != "")
            {
                item += "and PMPAR_Time>='" + TextBox_SPTime2.Text.ToString() + "'";
            }

            if (ChangeMan.Text.ToString() != "")
            {
                item += " and PMPAR_Man  like '%" + ChangeMan.Text.ToString() + "%'";
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
    //删除采购规则
    protected void Gridview_PMPApplyRule_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Delete1")
            {
                GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
                Gridview_PMPApplyRuleInfo.SelectedIndex = row.RowIndex;
                Guid supplyid = new Guid(Convert.ToString(e.CommandArgument));
                pmp.DeletePMPurchaseingApplyRule(supplyid);
                BindGridView_PMPApplyRuleinfo_One("");
                UpdatePanel_PMPApplyRuleInfo.Update();
                ScriptManager.RegisterClientScriptBlock(UpdatePanel_PMPApplyRuleInfo, GetType(), "alert", "alert('删除成功！')", true);
                return;
            }
            if (e.CommandName == "Edit1")//编辑
            {
                GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
                Gridview_PMPApplyRuleInfo.SelectedIndex = row.RowIndex;
                label_Rule.Text = "编辑";
                Button4.Visible = false;
                Button6.Visible = true;
                Button7.Visible = true;
                TextBox2.Enabled = true;
                label_RuleID.Text = e.CommandArgument.ToString();
                string condition = " and PMPAR_ID='" + label_RuleID.Text + "'";
                Guid supplyid = new Guid(Convert.ToString(e.CommandArgument));
                DataSet ds = pmp.SelectPMPurchaseingApplyRule_One(condition);
                DataTable dt = ds.Tables[0];
                if(dt.Rows.Count>0)
                {
                    TextBox2.Text = dt.Rows[0][3].ToString();
                }
                Panel_PMPAR_RuleInfo.Visible = true;
                UpdatePanel_PMPAR_RuleInfo.Update();
            }
            if (e.CommandName == "Look1")//查看
            {
                GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
                Gridview_PMPApplyRuleInfo.SelectedIndex = row.RowIndex;
                Button4.Visible = true;
                Button6.Visible = false;
                Button7.Visible = false;
                TextBox2.Enabled = false;
                Guid supplyid = new Guid(Convert.ToString(e.CommandArgument));
                if(DDList1.SelectedValue=="否")
                {
                    string condition = " and PMPAR_ID='" + supplyid + "'";
                    DataSet ds = pmp.SelectPMPurchaseingApplyRule(condition);
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        TextBox2.Text = dt.Rows[0][3].ToString();
                    }
                }
                if (DDList1.SelectedValue == "是")
                {
                    string condition = " and PMPAR_ID='" + supplyid + "'";
                    DataSet ds = pmp.SelectPMPurchaseingApplyRule_One(condition);
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        TextBox2.Text = dt.Rows[0][3].ToString();
                    }
                }
                Panel_PMPAR_RuleInfo.Visible = true;
                UpdatePanel_PMPAR_RuleInfo.Update();
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    //新增
    protected void Button2_Nw(object sender, EventArgs e)
    {
        try
        {
            TextBox2.Enabled = true;
            label_Rule.Text = "新增";
            Button4.Visible = false;
            Button6.Visible = true;
            Button7.Visible = true;
            Panel_PMPAR_RuleInfo.Visible = true;
            UpdatePanel_PMPAR_RuleInfo.Visible = true;
            UpdatePanel_PMPAR_RuleInfo.Update();
        }
        catch (Exception)
        {
            throw;
        }
    }
    //提交采购规则
    protected void ConfirmRuleInfo(object sender, EventArgs e)
    {
        try
        {
            if (label_Rule.Text == "编辑")
            {
                Guid RuleID = new Guid(label_RuleID.Text.ToString());
                pmp.UpdatePMPurchaseingApplyRule(RuleID, TextBox2.Text.ToString());
                Panel_PMPApplyRuleInfo.Visible = true;
                UpdatePanel_PMPApplyRuleInfo.Update();
                Panel_PMPAR_RuleInfo.Visible = false;
            }
            else
            {
                DataSet ds = pl.SelectPMPurchaseingApplyRule();
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel_PMPAR_RuleInfo, GetType(), "alert", "alert('请先删除正在使用的采购规则！')", true);
                    return;
                }
                else
                {
                    //DateTime.Now;
                    if (TextBox2.Text.ToString() == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(UpdatePanel_PMPAR_RuleInfo, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                        return;
                    }
                    else
                    {
                        if (label_Rule.Text == "新增")
                        {
                            string name = Session["UserName"].ToString().Trim();
                            pmp.InsertPMPurchaseingApplyRule(name, TextBox2.Text.ToString());//获取用户名

                            BindGridView_PMPApplyRuleinfo_One("");
                        }

                        Panel_PMPApplyRuleInfo.Visible = true;
                        UpdatePanel_PMPApplyRuleInfo.Update();
                        Panel_PMPAR_RuleInfo.Visible = false;
                    }
                }
            }
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
            TextBox_SPTime2.Text = "";
            TextBox_SPTime3.Text = "";
            ChangeMan.Text = "";
            DDList1.SelectedValue = "是";
        }
        catch (Exception)
        {
            throw;
        }
    }
    //取消规则制定
    protected void CanelRuleInfo(object sender, EventArgs e)
    {
        try
        {
            UpdatePanel_PMPAR_RuleInfo.Update();
            Panel_PMPAR_RuleInfo.Visible = false;
        }
        catch (Exception)
        {
            throw;
        }
    }
    //换页
    protected void Gridview_PMPApplyRule_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview_PMPApplyRuleInfo.BottomPagerRow;


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
        BindGridView_PMPApplyRuleinfo("");
        Gridview_PMPApplyRuleInfo.DataSource = pmp.SelectPMPurchaseingApplyRule("");
        Gridview_PMPApplyRuleInfo.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview_PMPApplyRuleInfo.PageCount ? Gridview_PMPApplyRuleInfo.PageCount - 1 : newPageIndex;
        Gridview_PMPApplyRuleInfo.PageIndex = newPageIndex;
        Gridview_PMPApplyRuleInfo.DataBind();

    }

    protected void Gridview_PMPApplyRuleInfo_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Gridview_PMPApplyRuleInfo.Rows.Count; i++)
        {
            for (int j = 0; j < Gridview_PMPApplyRuleInfo.Rows[i].Cells.Count; j++)
            {
                Gridview_PMPApplyRuleInfo.Rows[i].Cells[j].ToolTip = Gridview_PMPApplyRuleInfo.Rows[i].Cells[j].Text;
                if (Gridview_PMPApplyRuleInfo.Rows[i].Cells[j].Text.Length > 15)
                {
                    Gridview_PMPApplyRuleInfo.Rows[i].Cells[j].Text = Gridview_PMPApplyRuleInfo.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }
            }
        }  
    }
    protected void CanelRule(object sender, EventArgs e)
    {
        UpdatePanel_PMPAR_RuleInfo.Update();
        Panel_PMPAR_RuleInfo.Visible = false;
    }


}