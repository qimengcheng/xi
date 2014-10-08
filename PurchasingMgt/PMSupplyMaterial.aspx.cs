using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using RTXHelper;


public partial class ProjectManagement_PMSupplyMaterial : Page
{
    PMSupplyMaterialL pl = new PMSupplyMaterialL();
    PRMProjectScheduleL prl = new PRMProjectScheduleL();
    PMPurchaseOrderL ppl = new PMPurchaseOrderL();
    PMPurchaseingApplyRuleinfo PMPurchaseingApplyRuleinfo = new PMPurchaseingApplyRuleinfo();
    ProTypePrice ptp = new ProTypePrice();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            BindGridView2("");
            Panel_SupplyRule.Visible = true;
            Panel_SupplySearch.Visible = true;
            Panel_PMPurchaseApplyMain.Visible = true;
            DataSet ds = pl.SelectPMPurchaseingApplyRule();
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                TextBox1.Text = dt.Rows[0][3].ToString();
            }
            UpdatePanel_SupplyRule.Update();
            //if (!((Session["UserRole"].ToString().Contains("紧急采购申请")) || (Session["UserRole"].ToString().Contains("采购申请制定")) || (Session["UserRole"].ToString().Contains("采购申请审核"))))
            //{
            //    Response.Redirect("~/Default.aspx");
            //}
            label_pagestate.Text = Request.QueryString["state"];
            string state = label_pagestate.Text;
            if (state == "Make")
            {
                Title = "采购申请制定";
                Gridview2.Columns[8].Visible = false;
                Gridview2.Columns[11].Visible = false;
               
                //this.DropDownList2.Enabled = false;
                //this.DropDownList2.SelectedValue = "未制定";
                //string condition = GetCondition();

                UpdatePanel_PMPurchaseApplyMain.Update();

            }
            if (state == "Check")
            {
                Title = "采购申请审核";
                Gridview2.Columns[9].Visible = false;
                Gridview2.Columns[10].Visible = false;
                Gridview2.Columns[11].Visible = false;
                Button3.Visible = false;
                Gridview3.Columns[16].Visible = true;
                UpdatePanel_ApplyDetail.Update();
                //this.DropDownList2.Enabled = false;
                //this.DropDownList2.SelectedValue = "已提交";
                //string condition = GetCondition();

                UpdatePanel_PMPurchaseApplyMain.Update();
            }
            if (state == "Emergency")
            {
                Title = "紧急采购";
                if ((Session["UserRole"].ToString().Contains("紧急采购申请")))
                {
                    //this.label_Setting.Text = "Emergency";
                    //this.DropDownList2.SelectedValue = "财务总监审核通过";
                    //string condition = GetCondition();

                    //this.DropDownList2.SelectedValue = "财务主管审核通过";
                    //this.DropDownList2.Enabled = false;
                    Button3.Visible = false;
                    UpdatePanel_PMPurchaseApplyMain.Update();
                    Gridview2.Columns[8].Visible = false;
                    Gridview2.Columns[9].Visible = false;
                    Gridview2.Columns[10].Visible = false;
                }

            }
        }
    }
    //绑定采购申请制定单
    private void BindGridView2(string Condition)
    {
        //try
        //{
            Gridview2.DataSource = pl.SelectPMPurchaseingApply(Condition);
            Gridview2.DataBind();
        //}
        //catch (Exception)
        //{
        //    throw;
        //}
    }
    //选择部门
    protected void Button_Select1(object sender, EventArgs e)
    {
        try
        {
            Panel_Organization.Visible = true;
            BindGridView_Organization();
            UpdatePanel_Organization.Update();
        }
        catch (Exception)
        {
            throw;
        }
    }
    //查找部门
    private void BindGridView_Organization()
    {
        try
        {
            Gridview_Organization.DataSource = prl.SelectPRMP_Organization("");
            Gridview_Organization.DataBind();
        }
        catch (Exception)
        {
            throw;
        }
    }
    //提交部门
    protected void Button_Com1(object sender, EventArgs e)
    {
        try
        {
            string Pname;
            bool temp = false;

            foreach (GridViewRow item in Gridview_Organization.Rows)
            {
                RadioButton rb = item.FindControl("RadioButtonMarkup") as RadioButton;

                if (rb.Checked)
                {
                    Pname = Gridview_Organization.DataKeys[item.RowIndex].Value.ToString();
                    temp = true;

                    TextBox2.Text = Pname;


                }
            }
            if (!temp)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel_Organization, GetType(), "aa", "alert('请选择部门')", true);
            }
            else
            {
                Panel_Organization.Visible = false;
                UpdatePanel_Organization.Update();
                UpdatePanel_SupplySearch.Update();
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    //取消选择部门
    protected void Button_Cancel1(object sender, EventArgs e)
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
    #region//检索
    protected void Button_Sh1(object sender, EventArgs e)
    {
        string Condition = GetCondition();
        BindGridView2(Condition);
        Panel_PMPurchaseApplyMain.Visible = true;
        UpdatePanel_PMPurchaseApplyMain.Update();
        Panel_Organization.Visible = false;
        UpdatePanel_Organization.Update();
        Panel_PurchaseApply.Visible = false;
        UpdatePanel_PurchaseApply.Update();
        Panel_Material.Visible = false;
        UpdatePanel_Material.Update();
        Panel_ApplyDetail.Visible = false;
        UpdatePanel_ApplyDetail.Update();
        Panel1_Check.Visible = false;
        UpdatePanel1_Check.Update();

    }
    protected string GetCondition()
    {
        try
        {
            string Condition;
            string item = "";
            if (DropDownList2.SelectedValue.ToString() != "请选择")
            {
                item += " and PMPAM_State='" + DropDownList2.SelectedValue.ToString() + "'";
            }
            if (TextBox2.Text.ToString() != "")
            {
                item += " and PMPAM_Department  like '%" + TextBox2.Text.ToString() + "%'";
            }
            if (SupplyID.Text.ToString() != "")
            {
                item += " and PMPAM_ApplyNum like '%" + SupplyID.Text.ToString() + "%'";
            }
            if (TextBox10.Text.ToString() != "")
            {
                item += " and PMPAM_ApplyMan like '%" + TextBox10.Text.ToString() + "%'";
            }
            if (TextBox_SPTime2.Text.ToString() != "" && TextBox_SPTime3.Text.ToString() != "")
            {
                item += "and PMPAM_ApplyTime>='" + TextBox_SPTime2.Text.ToString() + "' and PMPAM_ApplyTime<='" + TextBox_SPTime3.Text.ToString() + "'";
            }
            if (TextBox_SPTime2.Text.ToString() != "")
            {
                item += "and PMPAM_ApplyTime>='" + TextBox_SPTime2.Text.ToString() + "'";
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
    #endregion
    //新增采购申请
    protected void Button_New(object sender, EventArgs e)
    {
        try
        {
            PMPurchaseingApplyRuleinfo.PMPAM_ApplyMan = Session["UserName"].ToString();
            PMPurchaseingApplyRuleinfo.PMPAM_Department = Session["Department"].ToString();
            PMPurchaseingApplyRuleinfo.PMPAM_State = "未制定";
            pl.InsertPMPurchaseingApplyMain(PMPurchaseingApplyRuleinfo);
            BindGridView2(" and PMPAM_Department='" + PMPurchaseingApplyRuleinfo.PMPAM_Department + "' and PMPAM_State ='未制定'");
            UpdatePanel_PMPurchaseApplyMain.Update();
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_PMPurchaseApplyMain, GetType(), "aa", "alert('新增成功！')", true);
            return;

        }
        catch (Exception)
        {
            throw;
        }

    }
    //选择物料
    protected void Button_Select3(object sender, EventArgs e)
    {
        try
        {
            //if (Session["Department"].ToString() == "人事部")
            //{
                BindGridview1("");
            //}
            //else
            //{
            //    string condition = " and IMMT_MaterialType not like'%" + "办公" + "%'" + " and IMMT_MaterialType not like'%" + "劳保" + "%'";
            //BindGridview1(condition);
            //}
            Panel_Material.Visible = true;
            UpdatePanel_Material.Update();
        }
        catch (Exception)
        {
            throw;
        }
    }
    //绑定物料表
    private void BindGridview1(string condition)
    {
        try
        {
            Gridview1.DataSource = pl.SelectPMPurchaseSMaterial(condition);
            Gridview1.DataBind();
        }
        catch (Exception)
        {
            throw;
        }

    }
    //提交物料
    protected void Button_Com3(object sender, EventArgs e)
    {
        try
        {
            string Pname;
            bool temp = false;

            foreach (GridViewRow item in Gridview1.Rows)
            {
                RadioButton rb = item.FindControl("RadioButtonMarkup") as RadioButton;

                if (rb.Checked)
                {
                    Pname = Gridview1.Rows[item.RowIndex].Cells[1].Text.Trim();
                    temp = true;
                    TextBox5.Text = Pname;
                    Unit.Text = Gridview1.Rows[item.RowIndex].Cells[5].Text.Trim();
                    label_MaterialID.Text = Gridview1.DataKeys[item.RowIndex]["IMMBD_MaterialID"].ToString();
                    label_IMUC_ID.Text = Gridview1.DataKeys[item.RowIndex]["IMUC_ID"].ToString();
                }
            }
            if (!temp)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel_Material, GetType(), "aa", "alert('请选择物料')", true);
                return;
            }
            else
            {
                TextBox16.Text = "";
                TextBox17.Text = "";
                Panel_Material.Visible = false;
                UpdatePanel_Material.Update();
                UpdatePanel_PurchaseApply.Update();
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    //取消选择物料
    protected void Button_Cancel3(object sender, EventArgs e)
    {
        try
        {
            TextBox16.Text = "";
            TextBox17.Text = "";
            Panel_Material.Visible = false;
            UpdatePanel_Material.Update();
        }
        catch (Exception)
        {
            throw;
        }
    }

    //提交采购申请制定
    protected void Button_Com2(object sender, EventArgs e)
    {
        try
        {
            string TB4;
            string TB5;
            string TB6;
            string TB11;
            string TB12;
            if (TextBox5.Text != "")
            {
                TB5 = label_MaterialID.Text.ToString();//物料ID
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel_PurchaseApply, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            if (TextBox4.Text != "")
            {
                TB4 = TextBox4.Text.ToString();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel_PurchaseApply, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            if (TextBox11.Text != "")
            {
                TB11 = TextBox11.Text.ToString();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel_PurchaseApply, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            if (TextBox6.Text != "")
            {
                TB6 = TextBox6.Text.ToString();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel_PurchaseApply, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            if (TextBox12.Text != "")
            {
                TB12 = TextBox12.Text.ToString();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel_PurchaseApply, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            PMPurchaseingApplyRuleinfo.PMPAD_Remark = TextBox18.Text.ToString();
            PMPurchaseingApplyRuleinfo.PMPAM_ID = new Guid(label_PMPAM_ID.Text);
            PMPurchaseingApplyRuleinfo.PMPAD_Require = TB6;
            PMPurchaseingApplyRuleinfo.IMMBD_MaterialID = new Guid(TB5);
            PMPurchaseingApplyRuleinfo.PMPAD_Num = Convert.ToInt32(TB4);
            PMPurchaseingApplyRuleinfo.PMPAD_NeedTime = Convert.ToDateTime(TB11);
            PMPurchaseingApplyRuleinfo.IMUC_ID = new Guid(label_IMUC_ID.Text);
            PMPurchaseingApplyRuleinfo.PMPAD_PriceIndication = Convert.ToDecimal(TB12);
            pl.InsertPMPurchaseingApply(PMPurchaseingApplyRuleinfo);
            UpdatePanel_PurchaseApply.Update();

            PMPurchaseingApplyRuleinfo.PMPAM_State = "制定中";
            pl.UpdatePMPurchaseApplySate(PMPurchaseingApplyRuleinfo);
            PMPurchaseingApplyRuleinfo.PMPAM_ApplyMan = Session["UserName"].ToString().Trim();
            string Condition = GetCondition();
            BindGridView2(Condition);
            UpdatePanel_PMPurchaseApplyMain.Update();
            PMPurchaseingApplyRuleinfo.PMPAM_ID = new Guid(label_PMPAM_ID.Text);
            BindGridview3(PMPurchaseingApplyRuleinfo);
            UpdatePanel_ApplyDetail.Update();
            TextBox5.Text = "";
            Unit.Text = "";
            TextBox4.Text = "";
            TextBox6.Text = "";
            TextBox11.Text = "";
            TextBox12.Text = "";
            TextBox18.Text = "";
        }
        catch (Exception)
        {
            throw;
        }
    }
    //标记
    private void Number(PMPurchaseingApplyRuleinfo PMPurchaseingApplyRuleinfo)
    {
        try
        {
            DataSet ds = pl.SelectPMPurchaseApplyOne(PMPurchaseingApplyRuleinfo);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                label_PMPAM_ID.Text = dt.Rows[0][0].ToString();
                TextBox3.Text = dt.Rows[0][3].ToString();
                label_Department.Text = dt.Rows[0][1].ToString() + "  " + dt.Rows[0][3].ToString() + "  " + dt.Rows[0][4].ToString();
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    //绑定采购申请单详细表
    private void BindGridview3(PMPurchaseingApplyRuleinfo PMPurchaseingApplyRuleinfo)
    {
        try
        {
            Gridview3.DataSource = pl.SelectPMPurchaseApplyDetail(PMPurchaseingApplyRuleinfo);
            Gridview3.DataBind();
        }
        catch (Exception)
        {
            throw;
        }
    }
    //制定、查看、审核、删除
    protected void Gridview_Project_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Check3")//制定
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview2.SelectedIndex = row.RowIndex;
            Button13.Visible = true;
            Button14.Visible = true;
            Button9.Visible = false;
            Gridview3.Columns[10].Visible = true;
            string gd = e.CommandArgument.ToString();
            PMPurchaseingApplyRuleinfo.PMPAM_ID = new Guid(gd);
            label_PMPAM_ID.Text = gd;
            Number(PMPurchaseingApplyRuleinfo);
            if ((Session["Department"].ToString() == Gridview2.Rows[Gridview2.SelectedIndex].Cells[3].Text.ToString()) && (Session["UserName"].ToString() == Gridview2.Rows[Gridview2.SelectedIndex].Cells[4].Text.ToString()))
            {
                label1.Text = label_Department.Text;
                label12.Text = label_Department.Text;
                BindGridview3(PMPurchaseingApplyRuleinfo);
                Panel_PurchaseApply.Visible = true;
                UpdatePanel_PurchaseApply.Update();
                Panel_ApplyDetail.Visible = true;
                UpdatePanel_ApplyDetail.Update();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "aa", "alert('抱歉，你没有此权限！')", true);
                return;
            }
        }
        if (e.CommandName == "Check1")//查看
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview2.SelectedIndex = row.RowIndex;
            string gd = e.CommandArgument.ToString();
            PMPurchaseingApplyRuleinfo.PMPAM_ID = new Guid(gd);
            label_PMPAM_ID.Text = gd;
            Number(PMPurchaseingApplyRuleinfo);
            //if ((Session["Department"].ToString() == this.TextBox3.Text) || (Session["UserRole"].ToString().Contains("紧急采购申请")) || (Session["UserRole"].ToString().Contains("采购申请财务主管审核")) || (Session["UserRole"].ToString().Contains("采购申请财务总监审核")))
            //{
                 Gridview3.Columns[11].Visible = true;
                label12.Text = label_Department.Text;
                PMPurchaseingApplyRuleinfo.PMPAM_ID = new Guid(gd);
                BindGridview3(PMPurchaseingApplyRuleinfo);
                Button13.Visible = false;
                Button14.Visible = false;
                Button9.Visible = true;
                Gridview3.Columns[10].Visible = false;
                Panel_ApplyDetail.Visible = true;
                UpdatePanel_ApplyDetail.Update();
            //}
        }
        if (e.CommandName == "Check2")//审核
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview2.SelectedIndex = row.RowIndex;
            string gd = e.CommandArgument.ToString();
            PMPurchaseingApplyRuleinfo.PMPAM_ID = new Guid(gd);
            label_PMPAM_ID.Text = e.CommandArgument.ToString();
            Number(PMPurchaseingApplyRuleinfo);
            label12.Text = label_Department.Text;
            label_DPCheck.Text = label_Department.Text;
            PMPurchaseingApplyRuleinfo.PMPAM_ID = new Guid(gd);
            BindGridview3(PMPurchaseingApplyRuleinfo);
            Gridview3.Columns[10].Visible = false;
            Button13.Visible = false;
            Button14.Visible = false;
            Button9.Visible = false;
            Button19.Visible = true;
            Button20.Visible = true;
            Button21.Visible = true;
            Button15.Visible = false;
            if (Session["UserRole"].ToString().Contains("采购申请审核") && Gridview2.Rows[row.RowIndex].Cells[2].Text=="已提交")
            {
                if (Session["Department"].ToString() == Gridview2.Rows[row.RowIndex].Cells[3].Text.ToString())
                {
                    Panel_ApplyDetail.Visible = true;
                    UpdatePanel_ApplyDetail.Update();
                    label_Role.Text = "部门主管";
                    label_DPCheckResult.Visible = false;
                    label_DPCheckName.Visible = false;
                    label1_DPCheckTime.Visible = false;

                    Label13.Visible = true;
                    Label14.Visible = false;
                    Label16.Visible = true;
                    TextBox8.Enabled = true;
                    TextBox8.Visible = true;
                    TextBox9.Visible = true;
                    label19.Visible = false;
                    label31.Visible = false;
                    label30.Visible = false;
                    Label23.Visible = false;
                    TextBox7.Visible = false;
                    Label22.Visible = false;
                    Label21.Visible = false;
                    label24.Visible = false;
                    label26.Visible = false;
                    label27.Visible = false;
                    Label25.Visible = false;
                    TextBox9.Visible = false;
                    Label17.Visible = false;
                    Label18.Visible = false;

                    Label36.Visible = false;
                    label37.Visible = false;
                    Label38.Visible = false;
                    label40.Visible = false;
                    label41.Visible = false;
                    Label42.Visible = false;
                    TextBox13.Visible = false;
                    TextBox13.Enabled = true;

                    Label44.Visible = false;
                    label45.Visible = false;
                    Label46.Visible = false;
                    label47.Visible = false;
                    label48.Visible = false;
                    Label49.Visible = false;
                    TextBox14.Visible = false;

                    Label20.Visible = false;
                    label51.Visible = false;
                    Label52.Visible = false;
                    label53.Visible = false;
                    label54.Visible = false;
                    Label55.Visible = false;
                    TextBox15.Visible = false;
                    Panel1_Check.Visible = true;
                    UpdatePanel1_Check.Update();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "aa", "alert('抱歉，你没有此权限！')", true);
                    return;
                }
            }
            else if (Session["UserRole"].ToString().Contains("采购申请人事部审核") && Gridview2.Rows[row.RowIndex].Cells[2].Text == "部门主管审核通过")//采购申请财务主管审核
            {
            string condition = " and  PMPurchaseApplyMain.PMPAM_ID='" + label_PMPAM_ID.Text + "'" + " and ( IMMT_MaterialType like'%" + "办公" + "%'" + " or IMMT_MaterialType like'%" + "劳保" + "%')";
            DataSet ds = pl.SelectPMPurchaseApplyDetail_LB(condition);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                Panel_ApplyDetail.Visible = true;
                UpdatePanel_ApplyDetail.Update();
                label_Role.Text = "人事部";
                Label36.Visible = false;
                label37.Visible = false;
                Label38.Visible = false;
                label40.Visible = false;
                label41.Visible = false;
                Label42.Visible = false;
                TextBox13.Visible = false;
                TextBox13.Enabled = false;

                Label13.Visible = true;
                Label16.Visible = true;
                Label14.Visible = true;
                TextBox8.Visible = true;
                TextBox8.Enabled = false;
                label_DPCheckResult.Visible = true;
                label_DPCheckName.Visible = true;
                label1_DPCheckTime.Visible = true;
                Label17.Visible = false;
                Label18.Visible = false;
                //this.Label19.Visible = true;
                TextBox9.Visible = false;
                label19.Visible = false;
                label31.Visible = false;
                label30.Visible = false;
                Label23.Visible = false;
                TextBox7.Visible = false;
                Label22.Visible = false;
                Label21.Visible = false;

                label24.Visible = false;
                label26.Visible = false;
                label27.Visible = false;
                Label25.Visible = false;

                Label44.Visible = false;
                label45.Visible = false;
                Label46.Visible = false;
                label47.Visible = false;
                label48.Visible = false;
                Label49.Visible = false;
                TextBox14.Visible = false;

                Label20.Visible = true;
                label51.Visible = false;
                Label52.Visible = false;
                label53.Visible = false;
                label54.Visible = false;
                Label55.Visible = true;
                TextBox15.Visible = true;
                TextBox15.Enabled = true;

                PMPurchaseingApplyRuleinfo.PMPAM_ID = new Guid(gd);
                DataSet dss = pl.SelectPMPAM_CheckOpinion(PMPurchaseingApplyRuleinfo);
                DataTable dtt = dss.Tables[0];
                if (dtt.Rows.Count > 0)
                {
                    label_DPCheckResult.Text = dtt.Rows[0][0].ToString();
                    label_DPCheckName.Text = dtt.Rows[0][3].ToString();
                    label1_DPCheckTime.Text = dtt.Rows[0][2].ToString();
                    TextBox8.Text = dtt.Rows[0][1].ToString();
                }
                Panel1_Check.Visible = true;
                UpdatePanel1_Check.Update();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "aa", "alert('抱歉，你没有此权限！')", true);
                return;
            }
            }
            else if (Session["UserRole"].ToString().Contains("采购申请部门副总审核") && (Gridview2.Rows[row.RowIndex].Cells[2].Text == "部门主管审核通过" || Gridview2.Rows[row.RowIndex].Cells[2].Text == "人事部审核通过"))//采购申请财务主管审核
            {
                string conditionn = "  and PMPurchaseApplyMain.PMPAM_ID='" + label_PMPAM_ID.Text + "'" + " and (IMMT_MaterialType  like'%" + "办公" + "%'" + " or IMMT_MaterialType like'%" + "劳保" + "%')";
                DataSet dsst = pl.SelectPMPurchaseApplyDetail_LB(conditionn);
                DataTable dtts = dsst.Tables[0];
                if (dtts.Rows.Count > 0 && Gridview2.Rows[row.RowIndex].Cells[2].Text != "人事部审核通过")
                {
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "aa", "alert('抱歉，此申请单还没有进入你负责的环节！')", true);
                    return;
                }
                else
                {
                    Panel_ApplyDetail.Visible = true;
                    UpdatePanel_ApplyDetail.Update();
                    label_Role.Text = "部门副总";
                    Label36.Visible = true;
                    label37.Visible = false;
                    Label38.Visible = false;
                    label40.Visible = false;
                    label41.Visible = false;
                    Label42.Visible = true;
                    TextBox13.Visible = true;
                    TextBox13.Enabled = true;

                    Label13.Visible = true;
                    Label16.Visible = true;
                    Label14.Visible = true;
                    TextBox8.Visible = true;
                    TextBox8.Enabled = false;
                    label_DPCheckResult.Visible = true;
                    label_DPCheckName.Visible = true;
                    label1_DPCheckTime.Visible = true;
                    Label17.Visible = false;
                    Label18.Visible = false;
                    //this.Label19.Visible = true;
                    TextBox9.Visible = false;
                    label19.Visible = false;
                    label31.Visible = false;
                    label30.Visible = false;
                    Label23.Visible = false;
                    TextBox7.Visible = false;
                    Label22.Visible = false;
                    Label21.Visible = false;

                    label24.Visible = false;
                    label26.Visible = false;
                    label27.Visible = false;
                    Label25.Visible = false;

                    Label44.Visible = false;
                    label45.Visible = false;
                    Label46.Visible = false;
                    label47.Visible = false;
                    label48.Visible = false;
                    Label49.Visible = false;
                    TextBox14.Visible = false;


                    PMPurchaseingApplyRuleinfo.PMPAM_ID = new Guid(gd);
                    DataSet ds = pl.SelectPMPAM_CheckOpinion(PMPurchaseingApplyRuleinfo);
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        label_DPCheckResult.Text = dt.Rows[0][0].ToString();
                        label_DPCheckName.Text = dt.Rows[0][3].ToString();
                        label1_DPCheckTime.Text = dt.Rows[0][2].ToString();
                        TextBox8.Text = dt.Rows[0][1].ToString();
                        string condition = " and PMPurchaseApplyMain.PMPAM_ID='" + label_PMPAM_ID.Text + "'" + " and ( IMMT_MaterialType  like'%" + "办公" + "%'" + " or IMMT_MaterialType  like'%" + "劳保" + "%')";
                        DataSet dss = pl.SelectPMPurchaseApplyDetail_LB(condition);
                        DataTable dtt = dss.Tables[0];
                        if (dtt.Rows.Count > 0)
                        {
                            label51.Text = dt.Rows[0][20].ToString();
                            label53.Text = dt.Rows[0][23].ToString();
                            label54.Text = dt.Rows[0][22].ToString();
                            TextBox15.Text = dt.Rows[0][21].ToString();

                            Label20.Visible = true;
                            label51.Visible = true;
                            Label52.Visible = true;
                            label53.Visible = true;
                            label54.Visible = true;
                            Label55.Visible = true;
                            TextBox15.Visible = true;
                            TextBox15.Enabled = false;
                        }
                        else
                        {
                            Label20.Visible = false;
                            label51.Visible = false;
                            Label52.Visible = false;
                            label53.Visible = false;
                            label54.Visible = false;
                            Label55.Visible = false;
                            TextBox15.Visible = false;

                        }
                    }
                    Panel1_Check.Visible = true;
                    UpdatePanel1_Check.Update();
                }
            }
            else if (Session["UserRole"].ToString().Contains("采购申请财务主管审核") && Gridview2.Rows[row.RowIndex].Cells[2].Text == "部门副总审核通过")
            {
                Panel_ApplyDetail.Visible = true;
                UpdatePanel_ApplyDetail.Update();
                label_Role.Text = "财务主管";
                Label36.Visible = true;
                label37.Visible =true;
                Label38.Visible = true;
                label40.Visible = true;
                label41.Visible = true;
                Label42.Visible = true;
                TextBox13.Visible = true;
                TextBox13.Enabled = false;

                Label13.Visible = true;
                Label16.Visible = true;
                Label14.Visible = true;
                TextBox8.Visible = true;
                TextBox8.Enabled = false;
                label_DPCheckResult.Visible = true;
                label_DPCheckName.Visible = true;
                label1_DPCheckTime.Visible = true;
                Label17.Visible = true ;
                Label18.Visible = true ;
                //this.Label19.Visible = true;
                TextBox9.Visible = true ;
                TextBox9.Enabled = true;
                label19.Visible = false;
                label31.Visible = false;
                label30.Visible = false;
                Label23.Visible = false;
                TextBox7.Visible = false;
                Label22.Visible = false;
                Label21.Visible = false;

                label24.Visible = false;
                label26.Visible = false;
                label27.Visible = false;
                Label25.Visible = false;

                Label44.Visible = false;
                label45.Visible = false;
                Label46.Visible = false;
                label47.Visible = false;
                label48.Visible = false;
                Label49.Visible = false;
                TextBox14.Visible = false;

                PMPurchaseingApplyRuleinfo.PMPAM_ID = new Guid(gd);
                DataSet ds = pl.SelectPMPAM_CheckOpinion(PMPurchaseingApplyRuleinfo);
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    label_DPCheckResult.Text = dt.Rows[0][0].ToString();
                    label_DPCheckName.Text = dt.Rows[0][3].ToString();
                    label1_DPCheckTime.Text = dt.Rows[0][2].ToString();
                    TextBox8.Text = dt.Rows[0][1].ToString();
                    label37.Text = dt.Rows[0][12].ToString();
                    label40.Text = dt.Rows[0][15].ToString();
                    label41.Text = dt.Rows[0][14].ToString();
                    TextBox13.Text = dt.Rows[0][13].ToString();
                    string condition = " and PMPurchaseApplyMain.PMPAM_ID='" + label_PMPAM_ID.Text + "'" + " and ( IMMT_MaterialType  like'%" + "办公" + "%'" + "or IMMT_MaterialType like'%" + "劳保" + "%')";
                    DataSet dss = pl.SelectPMPurchaseApplyDetail_LB(condition);
                    DataTable dtt = dss.Tables[0];
                    if (dtt.Rows.Count > 0)
                    {
                        label51.Text = dt.Rows[0][20].ToString();
                        label53.Text = dt.Rows[0][23].ToString();
                        label54.Text = dt.Rows[0][22].ToString();
                        TextBox15.Text = dt.Rows[0][21].ToString();

                        Label20.Visible = true;
                        label51.Visible = true;
                        Label52.Visible = true;
                        label53.Visible = true;
                        label54.Visible = true;
                        Label55.Visible = true;
                        TextBox15.Visible = true;
                        TextBox15.Enabled = false;
                    }
                    else
                    {
                        Label20.Visible = false;
                        label51.Visible = false;
                        Label52.Visible = false;
                        label53.Visible = false;
                        label54.Visible = false;
                        Label55.Visible = false;
                        TextBox15.Visible = false;

                    }
                }
                Panel1_Check.Visible = true;
                UpdatePanel1_Check.Update();
            }
            else if (Session["UserRole"].ToString().Contains("采购申请技术副总审核") && Gridview2.Rows[row.RowIndex].Cells[2].Text == "财务主管审核通过")
            {
                Panel_ApplyDetail.Visible = true;
                UpdatePanel_ApplyDetail.Update();
                label_Role.Text = "技术副总";
                Label36.Visible = true;
                label37.Visible = true;
                Label38.Visible = true;
                label40.Visible = true;
                label41.Visible = true;
                Label42.Visible = true;
                TextBox13.Visible = true;
                TextBox13.Enabled = false;

                Label13.Visible = true;
                Label16.Visible = true;
                Label14.Visible = true;
                TextBox8.Visible = true;
                TextBox8.Enabled = false;
                label_DPCheckResult.Visible = true;
                label_DPCheckName.Visible = true;
                label1_DPCheckTime.Visible = true;
               
                label19.Visible = false;
                label31.Visible = false;
                label30.Visible = false;
                Label23.Visible = false;
                TextBox7.Visible = false;
                Label22.Visible = false;
                Label21.Visible = false;

                Label17.Visible = true;
                Label18.Visible = true ;
                //this.Label19.Visible = true;
                TextBox9.Visible = true ;
                TextBox9.Enabled = false;
                label24.Visible = true ;
                label26.Visible = true ;
                label27.Visible = true ;
                Label25.Visible = true ;

                Label44.Visible = true ;
                label45.Visible = false;
                Label46.Visible = false;
                label47.Visible = false;
                label48.Visible = false;
                Label49.Visible = true ;
                TextBox14.Visible = true ;
                TextBox14.Enabled = true;

        
                PMPurchaseingApplyRuleinfo.PMPAM_ID = new Guid(gd);
                DataSet ds = pl.SelectPMPAM_CheckOpinion(PMPurchaseingApplyRuleinfo);
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    label_DPCheckResult.Text = dt.Rows[0][0].ToString();
                    label_DPCheckName.Text = dt.Rows[0][3].ToString();
                    label1_DPCheckTime.Text = dt.Rows[0][2].ToString();
                    TextBox8.Text = dt.Rows[0][1].ToString();
                    label37.Text = dt.Rows[0][12].ToString();
                    label40.Text = dt.Rows[0][15].ToString();
                    label41.Text = dt.Rows[0][14].ToString();
                    TextBox13.Text = dt.Rows[0][13].ToString();
                    label24.Text = dt.Rows[0][4].ToString();
                    label26.Text = dt.Rows[0][7].ToString();
                    label27.Text = dt.Rows[0][6].ToString();
                    TextBox9.Text = dt.Rows[0][5].ToString();
                    string condition = " and PMPurchaseApplyMain.PMPAM_ID='" + label_PMPAM_ID.Text + "'" + " and ( IMMT_MaterialType  like'%" + "办公" + "%'" + " or IMMT_MaterialType like'%" + "劳保" + "%')";
                    DataSet dss = pl.SelectPMPurchaseApplyDetail_LB(condition);
                    DataTable dtt = dss.Tables[0];
                    if (dtt.Rows.Count > 0)
                    {
                        label51.Text = dt.Rows[0][20].ToString();
                        label53.Text = dt.Rows[0][23].ToString();
                        label54.Text = dt.Rows[0][22].ToString();
                        TextBox15.Text = dt.Rows[0][21].ToString();

                        Label20.Visible = true;
                        label51.Visible = true;
                        Label52.Visible = true;
                        label53.Visible = true;
                        label54.Visible = true;
                        Label55.Visible = true;
                        TextBox15.Visible = true;
                        TextBox15.Enabled = false;
                    }
                    else
                    {
                        Label20.Visible = false;
                        label51.Visible = false;
                        Label52.Visible = false;
                        label53.Visible = false;
                        label54.Visible = false;
                        Label55.Visible = false;
                        TextBox15.Visible = false;

                    }
                }
                Panel1_Check.Visible = true;
                UpdatePanel1_Check.Update();
            }
            else if (Session["UserRole"].ToString().Contains("采购申请财务总监审核") && Gridview2.Rows[row.RowIndex].Cells[2].Text == "技术副总审核通过")
            {
                Panel_ApplyDetail.Visible = true;
                UpdatePanel_ApplyDetail.Update();
                label_Role.Text = "财务总监";
                Label36.Visible = true;
                label37.Visible = true;
                Label38.Visible = true;
                label40.Visible = true;
                label41.Visible = true;
                Label42.Visible = true;
                TextBox13.Visible = true;
                TextBox13.Enabled = false;

                Label13.Visible = true;
                Label16.Visible = true;
                Label14.Visible = true;
                TextBox8.Visible = true;
                TextBox8.Enabled = false;
                label_DPCheckResult.Visible = true;
                label_DPCheckName.Visible = true;
                label1_DPCheckTime.Visible = true;

                label19.Visible = false;
                label31.Visible = false;
                label30.Visible = false;
                Label23.Visible = false;
                TextBox7.Visible = true;
                TextBox7.Enabled =true;
                Label22.Visible = true ;
                Label21.Visible = true ;

                Label17.Visible = true;
                Label18.Visible = true;
                //this.Label19.Visible = true;
                TextBox9.Visible = true;
                TextBox9.Enabled = false;
                label24.Visible = true;
                label26.Visible = true;
                label27.Visible = true;
                Label25.Visible = true;

                Label44.Visible = true ;
                label45.Visible = true ;
                Label46.Visible =true ;
                label47.Visible = true ;
                label48.Visible = true ;
                Label49.Visible = true ;
                TextBox14.Visible = true ;
                TextBox14.Enabled = false;


                PMPurchaseingApplyRuleinfo.PMPAM_ID = new Guid(gd);
                DataSet ds = pl.SelectPMPAM_CheckOpinion(PMPurchaseingApplyRuleinfo);
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    label_DPCheckResult.Text = dt.Rows[0][0].ToString();
                    label_DPCheckName.Text = dt.Rows[0][3].ToString();
                    label1_DPCheckTime.Text = dt.Rows[0][2].ToString();
                    TextBox8.Text = dt.Rows[0][1].ToString();
                    label37.Text = dt.Rows[0][12].ToString();
                    label40.Text = dt.Rows[0][15].ToString();
                    label41.Text = dt.Rows[0][14].ToString();
                    TextBox13.Text = dt.Rows[0][13].ToString();
                    label24.Text = dt.Rows[0][4].ToString();
                    label26.Text = dt.Rows[0][7].ToString();
                    label27.Text = dt.Rows[0][6].ToString();
                    TextBox9.Text = dt.Rows[0][5].ToString();
                    label45.Text = dt.Rows[0][16].ToString();
                    label47.Text = dt.Rows[0][19].ToString();
                    label48.Text = dt.Rows[0][18].ToString();
                    TextBox14.Text = dt.Rows[0][17].ToString();
                    string condition = " and PMPurchaseApplyMain.PMPAM_ID='" + label_PMPAM_ID.Text + "'" + " and ( IMMT_MaterialType  like'%" + "办公" + "%'" + " or IMMT_MaterialType   like'%" + "劳保" + "%')";
                    DataSet dss = pl.SelectPMPurchaseApplyDetail_LB(condition);
                    DataTable dtt = dss.Tables[0];
                    if (dtt.Rows.Count > 0)
                    {
                        label51.Text = dt.Rows[0][20].ToString();
                        label53.Text = dt.Rows[0][23].ToString();
                        label54.Text = dt.Rows[0][22].ToString();
                        TextBox15.Text = dt.Rows[0][21].ToString();

                        Label20.Visible = true;
                        label51.Visible = true;
                        Label52.Visible = true;
                        label53.Visible = true;
                        label54.Visible = true;
                        Label55.Visible = true;
                        TextBox15.Visible = true;
                        TextBox15.Enabled = false;
                    }
                    else
                    {
                        Label20.Visible = false;
                        label51.Visible = false;
                        Label52.Visible = false;
                        label53.Visible = false;
                        label54.Visible = false;
                        Label55.Visible = false;
                        TextBox15.Visible = false;

                    }

                }
                Panel1_Check.Visible = true;
                UpdatePanel1_Check.Update();
            }
            else {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "aa", "alert('此条采购申请单尚未进入你负责审核的环节！')", true);
                return;

            }

        }
        if (e.CommandName == "Delete1")//删除
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview2.SelectedIndex = row.RowIndex;
            //if (Session["Department"].ToString() == this.Gridview2.Rows[row.RowIndex].Cells[3].Text.ToString())
            //{
                
                PMPurchaseingApplyRuleinfo.PMPAM_ID = new Guid(e.CommandArgument.ToString());
                pl.DeletePMPurchaseApplyMain(PMPurchaseingApplyRuleinfo);
                string Condition = GetCondition();
                BindGridView2(Condition);
                UpdatePanel_PMPurchaseApplyMain.Update();
                ScriptManager.RegisterClientScriptBlock(UpdatePanel_PMPurchaseApplyMain, GetType(), "aa", "alert('删除成功！')", true);
                return;
            //}
        }
        if (e.CommandName == "Confirm")//确认为紧急订单
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview2.SelectedIndex = row.RowIndex;
            PMPurchaseingApplyRuleinfo.PMPAM_ID = new Guid(e.CommandArgument.ToString());
            pl.UpdatePMPAM_EmergencyPur(PMPurchaseingApplyRuleinfo);
            string Condition = GetCondition();
            BindGridView2(Condition);
            UpdatePanel_PMPurchaseApplyMain.Update();
        }
        if (e.CommandName == "LConfirm")//查看审核意见
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview2.SelectedIndex = row.RowIndex;
            string gd = e.CommandArgument.ToString();
            PMPurchaseingApplyRuleinfo.PMPAM_ID = new Guid(gd);
            label_PMPAM_ID.Text = e.CommandArgument.ToString();
            Number(PMPurchaseingApplyRuleinfo);
            label12.Text = label_Department.Text;
            label_DPCheck.Text = label_Department.Text;
            PMPurchaseingApplyRuleinfo.PMPAM_ID = new Guid(gd);
            BindGridview3(PMPurchaseingApplyRuleinfo);
            Gridview3.Columns[10].Visible = false;
            Gridview3.Columns[11].Visible = false;
            Button13.Visible = false;
            Button14.Visible = false;
            Button9.Visible = false;
            Panel_ApplyDetail.Visible = true;
            UpdatePanel_ApplyDetail.Update();
            Label36.Visible = true;
            label37.Visible = true;
            Label38.Visible = true;
            label40.Visible = true;
            label41.Visible = true;
            Label42.Visible = true;
            TextBox13.Visible = true;
            TextBox13.Enabled = false;

            Label13.Visible = true;
            Label16.Visible = true;
            Label14.Visible = true;
            TextBox8.Visible = true;
            TextBox8.Enabled = false;
            label_DPCheckResult.Visible = true;
            label_DPCheckName.Visible = true;
            label1_DPCheckTime.Visible = true;

            label19.Visible = true ;
            label31.Visible = true ;
            label30.Visible = true ;
            Label23.Visible = true ;
            TextBox7.Visible = true;
            TextBox7.Enabled = false ;
            Label22.Visible = true;
            Label21.Visible = true;

            Label17.Visible = true;
            Label18.Visible = true;
            
            TextBox9.Visible = true;
            TextBox9.Enabled = false;
            label24.Visible = true;
            label26.Visible = true;
            label27.Visible = true;
            Label25.Visible = true;

            Label44.Visible = true;
            label45.Visible = true;
            Label46.Visible = true;
            label47.Visible = true;
            label48.Visible = true;
            Label49.Visible = true;
            TextBox14.Visible = true;
            TextBox14.Enabled = false;
            Button15.Visible = true;
            Button19.Visible = false ;
            Button20.Visible = false;
            Button21.Visible = false;
            UpdatePanel_ApplyDetail.Update();
            PMPurchaseingApplyRuleinfo.PMPAM_ID = new Guid(gd);
            DataSet ds = pl.SelectPMPAM_CheckOpinion(PMPurchaseingApplyRuleinfo);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                label_DPCheckResult.Text = dt.Rows[0][0].ToString();
                label_DPCheckName.Text = dt.Rows[0][3].ToString();
                label1_DPCheckTime.Text = dt.Rows[0][2].ToString();
                TextBox8.Text = dt.Rows[0][1].ToString();
                label37.Text = dt.Rows[0][12].ToString();
                label40.Text = dt.Rows[0][15].ToString();
                label41.Text = dt.Rows[0][14].ToString();
                TextBox13.Text = dt.Rows[0][13].ToString();
                label24.Text = dt.Rows[0][4].ToString();
                label26.Text = dt.Rows[0][7].ToString();
                label27.Text = dt.Rows[0][6].ToString();
                TextBox9.Text = dt.Rows[0][5].ToString();
                label45.Text = dt.Rows[0][16].ToString();
                label47.Text = dt.Rows[0][19].ToString();
                label48.Text = dt.Rows[0][18].ToString();
                TextBox14.Text = dt.Rows[0][17].ToString();
                label30.Text = dt.Rows[0][11].ToString();
                label31.Text = dt.Rows[0][10].ToString();
                label19.Text = dt.Rows[0][8].ToString();
                TextBox7.Text = dt.Rows[0][9].ToString();
                string condition = "  and PMPurchaseApplyMain.PMPAM_ID='" + label_PMPAM_ID.Text + "'" + " and (IMMT_MaterialType  like'%" + "办公" + "%'" + " or IMMT_MaterialType like'%" + "劳保" + "%')";
                DataSet dss = pl.SelectPMPurchaseApplyDetail_LB(condition);
                DataTable dtt = dss.Tables[0];
                if (dtt.Rows.Count > 0)
                {
                    label51.Text = dt.Rows[0][20].ToString();
                    label53.Text = dt.Rows[0][23].ToString();
                    label54.Text = dt.Rows[0][22].ToString();
                    TextBox15.Text = dt.Rows[0][21].ToString();

                    Label20.Visible = true;
                    label51.Visible = true;
                    Label52.Visible = true;
                    label53.Visible = true;
                    label54.Visible = true;
                    Label55.Visible = true;
                    TextBox15.Visible = true;
                    TextBox15.Enabled = false;
                }
                else
                {
                    Label20.Visible = false ;
                    label51.Visible = false ;
                    Label52.Visible = false ;
                    label53.Visible = false ;
                    label54.Visible = false ;
                    Label55.Visible =false ;
                    TextBox15.Visible = false ;
                
                }
            }
            Panel1_Check.Visible = true;
            UpdatePanel1_Check.Update();
        }

    }
    #region//取消
    protected void Button_Cancel2(object sender, EventArgs e)
    {
        TextBox5.Text = "";
        Unit.Text = "";
        TextBox4.Text = "";
        TextBox6.Text = "";
        TextBox11.Text = "";
        TextBox12.Text = "";
        TextBox18.Text = "";
        Panel_PurchaseApply.Visible = false;
        UpdatePanel_PurchaseApply.Update();
        Panel_ApplyDetail.Visible = false;
        UpdatePanel_ApplyDetail.Update();
    }
    protected void Button_Cancel4(object sender, EventArgs e)
    {
        Panel_PurchaseApply.Visible = false;
        UpdatePanel_PurchaseApply.Update();
        Panel_ApplyDetail.Visible = false;
        UpdatePanel_ApplyDetail.Update();
    }
    #endregion
    //提交申请单制定
    protected void Button_Com4(object sender, EventArgs e)
    {
        if (Gridview3.Rows.Count < 1)
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_ApplyDetail, GetType(), "alert", "alert('请制定申请单！')", true);
            return;
        }
        else
        {
            PMPurchaseingApplyRuleinfo.PMPAM_ID = new Guid(label_PMPAM_ID.Text);
            PMPurchaseingApplyRuleinfo.PMPAM_State = "已提交";
            pl.UpdatePMPurchaseApplySate(PMPurchaseingApplyRuleinfo);
            string Condition = GetCondition();
            BindGridView2(Condition);
            UpdatePanel_PMPurchaseApplyMain.Update();
            Panel_PurchaseApply.Visible = false;
            UpdatePanel_PurchaseApply.Update();
            Panel_ApplyDetail.Visible = false;
            UpdatePanel_ApplyDetail.Update();
            string Morl = Gridview2.Rows[Gridview2.SelectedIndex].Cells[1].Text.ToString();
            label_RTX.Text = "ERP系统信息：" + Session["UserName"].ToString() + "于" + DateTime.Now + "提交了" +Morl + "的采购申请单，请查看。";
            string dep = Gridview2.Rows[Gridview2.SelectedIndex].Cells[3].Text.ToString();
            string message = label_RTX.Text;
            string sErr = RTXhelper.SendbyDepAndRole(message, dep, "采购申请审核");
            if (!string.IsNullOrEmpty(sErr))
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
            }
        }
    }
    //通过
    protected void Pass(object sender, EventArgs e)  
    {
        if (label_Role.Text == "部门主管")
        {
            PMPurchaseingApplyRuleinfo.PMPAM_ID = new Guid(label_PMPAM_ID.Text);
            PMPurchaseingApplyRuleinfo.PMPAM_AppDepartMangResult = "通过";
            PMPurchaseingApplyRuleinfo.PMPAM_AppDepartMangOpinion = TextBox8.Text;

            PMPurchaseingApplyRuleinfo.PMPAM_State = "部门主管审核通过";
            PMPurchaseingApplyRuleinfo.PMPAM_AppDepartMangName = Session["UserName"].ToString();
            pl.UpdatePMPAM_AppDepartMang(PMPurchaseingApplyRuleinfo);
            string Condition = GetCondition();
            BindGridView2(Condition);
            UpdatePanel_PMPurchaseApplyMain.Update();
           
            string Morl = Gridview2.Rows[Gridview2.SelectedIndex].Cells[1].Text.ToString();
            label_RTX1.Text = "ERP系统信息：" + Session["UserName"].ToString() + "于" + DateTime.Now + "审核通过了" +Morl+ "的采购申请单，请查看。";
              string message = label_RTX1.Text;
              string sErr = "";

              string condition = " and PMPurchaseApplyMain.PMPAM_ID='" + label_PMPAM_ID.Text + "'" + " and ( IMMT_MaterialType like'%" + "办公" + "%'" + " or IMMT_MaterialType  like'%" + "劳保" + "%')";
            DataSet ds = pl.SelectPMPurchaseApplyDetail_LB(condition);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                sErr = RTXhelper.Send(message, "采购申请人事部审核");
            }
            else
            {
                if (Gridview2.Rows[Gridview2.SelectedIndex].Cells[3].Text.ToString() == "配套加工事业部" ||Gridview2.Rows[Gridview2.SelectedIndex].Cells[3].Text.ToString() == "模块事业部" || Gridview2.Rows[Gridview2.SelectedIndex].Cells[3].Text.ToString() == "采购部" || Gridview2.Rows[Gridview2.SelectedIndex].Cells[3].Text.ToString().Contains("生产") || Gridview2.Rows[Gridview2.SelectedIndex].Cells[3].Text.ToString() == "销售部")
                {
                    sErr = RTXhelper.Send(message, "采购申请部门副总审核(供产销)");
                }
                else
                {
                    sErr = RTXhelper.Send(message, "采购申请部门副总审核(其它)");
                }
            }
            if (!string.IsNullOrEmpty(sErr))
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);  
            }
        }

        if (label_Role.Text == "人事部")
        {

            PMPurchaseingApplyRuleinfo.PMPAM_ID = new Guid(label_PMPAM_ID.Text);
            PMPurchaseingApplyRuleinfo.PMPAM_PersonnalCheckResult = "通过";
            PMPurchaseingApplyRuleinfo.PMPAM_PersonnalCheckOpinion = TextBox15.Text;

            PMPurchaseingApplyRuleinfo.PMPAM_State = "人事部审核通过";
            PMPurchaseingApplyRuleinfo.PMPAM_PersonnalCheckMan = Session["UserName"].ToString();
            pl.UpdatePMPAM_PersonalCheck(PMPurchaseingApplyRuleinfo);
            string Condition = GetCondition();
            BindGridView2(Condition);
            UpdatePanel_PMPurchaseApplyMain.Update();
            string Morl = Gridview2.Rows[Gridview2.SelectedIndex].Cells[1].Text.ToString();
            label_RTX1.Text = "ERP系统信息：" + Session["UserName"].ToString() + "于" + DateTime.Now + "审核通过了" + Morl + "的采购申请单，请查看。";
            string message = label_RTX1.Text;
            string sErr = "";
            if (Gridview2.Rows[Gridview2.SelectedIndex].Cells[3].Text.ToString() == "采购部" || Gridview2.Rows[Gridview2.SelectedIndex].Cells[3].Text.ToString() == "生产部" || Gridview2.Rows[Gridview2.SelectedIndex].Cells[3].Text.ToString() == "销售部")
            {
                sErr = RTXhelper.Send(message, "采购申请部门副总审核(供产销)");
            }
            else
            {
                sErr = RTXhelper.Send(message, "采购申请部门副总审核(其它)");
            }
            if (!string.IsNullOrEmpty(sErr))
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
            }
        }
        if (label_Role.Text == "部门副总")
        {

            PMPurchaseingApplyRuleinfo.PMPAM_ID = new Guid(label_PMPAM_ID.Text);
            PMPurchaseingApplyRuleinfo.PMPAM_DeptMangCheckResult = "通过";
            PMPurchaseingApplyRuleinfo.PMPAM_DeptMangCheckOpinion = TextBox13.Text;

            PMPurchaseingApplyRuleinfo.PMPAM_State = "部门副总审核通过";
            PMPurchaseingApplyRuleinfo.PMPAM_DeptMangName = Session["UserName"].ToString();
            pl.UpdatePMPAM_DeptMangCheck(PMPurchaseingApplyRuleinfo);
            string Condition = GetCondition();
            BindGridView2(Condition);
            UpdatePanel_PMPurchaseApplyMain.Update();
            string Morl = Gridview2.Rows[Gridview2.SelectedIndex].Cells[1].Text.ToString();
            label_RTX1.Text = "ERP系统信息：" + Session["UserName"].ToString() + "于" + DateTime.Now + "审核通过了" + Morl+ "的采购申请单，请查看。";
             string message = label_RTX1.Text;
             string sErr = "";

            sErr=RTXhelper.Send(message, "采购申请财务主管审核");
                
            if (!string.IsNullOrEmpty(sErr))
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);  
            }
        }
        if (label_Role.Text == "财务主管")
        {
            PMPurchaseingApplyRuleinfo.PMPAM_ID = new Guid(label_PMPAM_ID.Text);
            PMPurchaseingApplyRuleinfo.PMPAM_CFECheckResult = "通过";
            PMPurchaseingApplyRuleinfo.PMPAM_CFECheckOpinion = TextBox9.Text;

            PMPurchaseingApplyRuleinfo.PMPAM_State = "财务主管审核通过";
            PMPurchaseingApplyRuleinfo.PMPAM_CFECheckMan = Session["UserName"].ToString();
            pl.UpdatePMPAM_CFECheck(PMPurchaseingApplyRuleinfo);
            string Condition = GetCondition();
            BindGridView2(Condition);
            UpdatePanel_PMPurchaseApplyMain.Update();
            string Morl = Gridview2.Rows[Gridview2.SelectedIndex].Cells[1].Text.ToString();
            label_RTX1.Text = "ERP系统信息：" + Session["UserName"].ToString() + "于" + DateTime.Now + "审核通过了" + Morl + "的采购申请单，请查看。";
             string message = label_RTX1.Text;
             string sErr=RTXhelper.Send(message, "采购申请技术副总审核");
            if (!string.IsNullOrEmpty(sErr))
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);  
            }
        }
        if (label_Role.Text == "技术副总")
        {
            PMPurchaseingApplyRuleinfo.PMPAM_ID = new Guid(label_PMPAM_ID.Text);
            PMPurchaseingApplyRuleinfo.PMPAM_DesignMangCheckResult = "通过";
            PMPurchaseingApplyRuleinfo.PMPAM_DesignMangCheckOpinion = TextBox14.Text;

            PMPurchaseingApplyRuleinfo.PMPAM_State = "技术副总审核通过";
            PMPurchaseingApplyRuleinfo.PMPAM_DesignMangName = Session["UserName"].ToString();
            pl.UpdatePMPAM_DesignMangCheck(PMPurchaseingApplyRuleinfo);
            string Condition = GetCondition();
            BindGridView2(Condition);
            UpdatePanel_PMPurchaseApplyMain.Update();
            string Morl = Gridview2.Rows[Gridview2.SelectedIndex].Cells[1].Text.ToString();
            label_RTX1.Text = "ERP系统信息：" + Session["UserName"].ToString() + "于" + DateTime.Now + "审核通过了" +Morl+ "的采购申请单，请查看。";
            string message = label_RTX1.Text;
            string sErr=RTXhelper.Send(message, "采购申请财务总监审核");
            if (!string.IsNullOrEmpty(sErr))
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);  
            }
        }
        if (label_Role.Text == "财务总监")
        {
            PMPurchaseingApplyRuleinfo.PMPAM_ID = new Guid(label_PMPAM_ID.Text);
            PMPurchaseingApplyRuleinfo.PMPAM_CFOCheckResult = "通过";
            PMPurchaseingApplyRuleinfo.PMPAM_CFOCheckOpinion = TextBox7.Text;

            PMPurchaseingApplyRuleinfo.PMPAM_State = "财务总监审核通过";
            PMPurchaseingApplyRuleinfo.PMPAM_CFOCheckMan = Session["UserName"].ToString();
            pl.UpdatePMPAM_CFOCheck(PMPurchaseingApplyRuleinfo);
            string Condition = GetCondition();
            BindGridView2(Condition);
            UpdatePanel_PMPurchaseApplyMain.Update();
            string Morl = Gridview2.Rows[Gridview2.SelectedIndex].Cells[1].Text.ToString();
            label_RTX1.Text = "ERP系统信息：" + Session["UserName"].ToString() + "于" + DateTime.Now + "审核通过了" +Morl+ "的采购申请单，请查看。";
            string message = label_RTX1.Text;
             string sErr=RTXhelper.Send(message, "采购申请执行维护");
            if (!string.IsNullOrEmpty(sErr))
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);  
            } 
        }
        TextBox7.Text = "";
        TextBox8.Text = "";
        TextBox9.Text = "";
        Panel_ApplyDetail.Visible = false;
        UpdatePanel_ApplyDetail.Update();
        Panel1_Check.Visible = false;
        UpdatePanel1_Check.Update();
    }
    //驳回
    protected void Reject(object sender, EventArgs e)
    {
        if (label_Role.Text == "部门主管")
        {
            PMPurchaseingApplyRuleinfo.PMPAM_ID = new Guid(label_PMPAM_ID.Text);
            PMPurchaseingApplyRuleinfo.PMPAM_AppDepartMangResult = "驳回";
            PMPurchaseingApplyRuleinfo.PMPAM_AppDepartMangOpinion = TextBox8.Text;

            PMPurchaseingApplyRuleinfo.PMPAM_State = "部门主管审核驳回";
            PMPurchaseingApplyRuleinfo.PMPAM_AppDepartMangName = Session["UserName"].ToString();
            pl.UpdatePMPAM_AppDepartMang(PMPurchaseingApplyRuleinfo);
            string Condition = GetCondition();
            BindGridView2(Condition);
            UpdatePanel_PMPurchaseApplyMain.Update();
            string Morl = Gridview2.Rows[Gridview2.SelectedIndex].Cells[1].Text.ToString();
            label_RTX_P.Text = "ERP系统信息：" + Session["UserName"].ToString() + "于" + DateTime.Now + "驳回了" +Morl+ "的采购申请单，请查看。";
            string message = label_RTX_P.Text;
            string dep = Gridview2.Rows[Gridview2.SelectedIndex].Cells[3].Text.ToString();
            string sErr = RTXhelper.SendbyDepAndRole(message, dep, "采购申请制定");

            if (!string.IsNullOrEmpty(sErr))
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);  
            }
            
        }
        if (label_Role.Text == "人事部")
        {

            PMPurchaseingApplyRuleinfo.PMPAM_ID = new Guid(label_PMPAM_ID.Text);
            PMPurchaseingApplyRuleinfo.PMPAM_PersonnalCheckResult = "驳回";
            PMPurchaseingApplyRuleinfo.PMPAM_PersonnalCheckOpinion = TextBox15.Text;

            PMPurchaseingApplyRuleinfo.PMPAM_State = "人事部审核驳回";
            PMPurchaseingApplyRuleinfo.PMPAM_PersonnalCheckMan = Session["UserName"].ToString();
            pl.UpdatePMPAM_PersonalCheck(PMPurchaseingApplyRuleinfo);
            string Condition = GetCondition();
            BindGridView2(Condition);
            UpdatePanel_PMPurchaseApplyMain.Update();
            string Morl = Gridview2.Rows[Gridview2.SelectedIndex].Cells[1].Text.ToString();
            label_RTX1.Text = "ERP系统信息：" + Session["UserName"].ToString() + "于" + DateTime.Now + "审核驳回了" + Morl + "的采购申请单，请查看。";
            string message = label_RTX1.Text;
            string dep = Gridview2.Rows[Gridview2.SelectedIndex].Cells[3].Text.ToString();
            string sErr = RTXhelper.SendbyDepAndRole(message, dep, "采购申请制定");
            if (!string.IsNullOrEmpty(sErr))
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
            }
        }
        if (label_Role.Text == "部门副总")
        {

            PMPurchaseingApplyRuleinfo.PMPAM_ID = new Guid(label_PMPAM_ID.Text);
            PMPurchaseingApplyRuleinfo.PMPAM_DeptMangCheckResult = "驳回";
            PMPurchaseingApplyRuleinfo.PMPAM_DeptMangCheckOpinion = TextBox13.Text;

            PMPurchaseingApplyRuleinfo.PMPAM_State = "部门副总审核驳回";
            PMPurchaseingApplyRuleinfo.PMPAM_DeptMangName = Session["UserName"].ToString();
            pl.UpdatePMPAM_DeptMangCheck(PMPurchaseingApplyRuleinfo);
            string Condition = GetCondition();
            BindGridView2(Condition);
            UpdatePanel_PMPurchaseApplyMain.Update();
            string Morl = Gridview2.Rows[Gridview2.SelectedIndex].Cells[1].Text.ToString();
            label_RTX_P.Text = "ERP系统信息：" + Session["UserName"].ToString() + "于" + DateTime.Now + "驳回了" + Morl+ "的采购申请单，请查看。";
            string message = label_RTX_P.Text;
            string dep = Gridview2.Rows[Gridview2.SelectedIndex].Cells[3].Text.ToString();
            string sErr = RTXhelper.SendbyDepAndRole(message, dep, "采购申请制定");
            if (!string.IsNullOrEmpty(sErr))
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);  
            }
        }
        if (label_Role.Text == "技术副总")
        {
            PMPurchaseingApplyRuleinfo.PMPAM_ID = new Guid(label_PMPAM_ID.Text);
            PMPurchaseingApplyRuleinfo.PMPAM_DesignMangCheckResult = "通过";
            PMPurchaseingApplyRuleinfo.PMPAM_DesignMangCheckOpinion = TextBox9.Text;

            PMPurchaseingApplyRuleinfo.PMPAM_State = "技术副总审核通过";
            PMPurchaseingApplyRuleinfo.PMPAM_DesignMangName = Session["UserName"].ToString();
            pl.UpdatePMPAM_DesignMangCheck(PMPurchaseingApplyRuleinfo);
            string Condition = GetCondition();
            BindGridView2(Condition);
            UpdatePanel_PMPurchaseApplyMain.Update();
            string Morl = Gridview2.Rows[Gridview2.SelectedIndex].Cells[1].Text.ToString();
            label_RTX_P.Text = "ERP系统信息：" + Session["UserName"].ToString() + "于" + DateTime.Now + "驳回了" +Morl + "的采购申请单，请查看。";
           string message = label_RTX_P.Text;
           string dep = Gridview2.Rows[Gridview2.SelectedIndex].Cells[3].Text.ToString();
           string sErr = RTXhelper.SendbyDepAndRole(message, dep, "采购申请制定");
            if (!string.IsNullOrEmpty(sErr))
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);  
            }
        }
        if (label_Role.Text == "财务主管")
        {
            PMPurchaseingApplyRuleinfo.PMPAM_ID = new Guid(label_PMPAM_ID.Text);
            PMPurchaseingApplyRuleinfo.PMPAM_CFECheckResult = "驳回";
            PMPurchaseingApplyRuleinfo.PMPAM_CFECheckOpinion = TextBox9.Text;

            PMPurchaseingApplyRuleinfo.PMPAM_State = "财务主管审核驳回";
            PMPurchaseingApplyRuleinfo.PMPAM_CFECheckMan = Session["UserName"].ToString();
            pl.UpdatePMPAM_CFECheck(PMPurchaseingApplyRuleinfo);
            string Condition = GetCondition();
            BindGridView2(Condition);
            UpdatePanel_PMPurchaseApplyMain.Update();
            string Morl = Gridview2.Rows[Gridview2.SelectedIndex].Cells[1].Text.ToString();
            label_RTX_P.Text = "ERP系统信息：" + Session["UserName"].ToString() + "于" + DateTime.Now + "驳回了" + Morl + "的采购申请单，请查看。";
             string message = label_RTX_P.Text;
             string dep = Gridview2.Rows[Gridview2.SelectedIndex].Cells[3].Text.ToString();
             string sErr = RTXhelper.SendbyDepAndRole(message, dep, "采购申请制定");
            if (!string.IsNullOrEmpty(sErr))
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);  
            }
        }
        if (label_Role.Text == "财务总监")
        {
            PMPurchaseingApplyRuleinfo.PMPAM_ID = new Guid(label_PMPAM_ID.Text);
            PMPurchaseingApplyRuleinfo.PMPAM_CFOCheckResult = "驳回";
            PMPurchaseingApplyRuleinfo.PMPAM_CFOCheckOpinion = TextBox7.Text;

            PMPurchaseingApplyRuleinfo.PMPAM_State = "财务总监审核驳回";
            PMPurchaseingApplyRuleinfo.PMPAM_CFOCheckMan = Session["UserName"].ToString();
            pl.UpdatePMPAM_CFOCheck(PMPurchaseingApplyRuleinfo);
            string Condition = GetCondition();
            BindGridView2(Condition);
            UpdatePanel_PMPurchaseApplyMain.Update();
            string Morl = Gridview2.Rows[Gridview2.SelectedIndex].Cells[1].Text.ToString();
            label_RTX_P.Text = "ERP系统信息：" + Session["UserName"].ToString() + "于" + DateTime.Now + "驳回了" + Morl+ "的采购申请单，请查看。";
            string message = label_RTX_P.Text;
            string dep = Gridview2.Rows[Gridview2.SelectedIndex].Cells[3].Text.ToString();
            string sErr = RTXhelper.SendbyDepAndRole(message, dep, "采购申请制定");
            if (!string.IsNullOrEmpty(sErr))
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);  
            }
        }
        TextBox7.Text = "";
        TextBox8.Text = "";
        TextBox9.Text = "";
        Panel1_Check.Visible = false;
        UpdatePanel1_Check.Update();
        Panel_ApplyDetail.Visible = false;
        UpdatePanel_ApplyDetail.Update();
    }
    //关闭审核
    protected void Canel(object sender, EventArgs e)
    {
        TextBox7.Text = "";
        TextBox8.Text = "";
        TextBox9.Text = "";
        Panel1_Check.Visible = false;
        UpdatePanel1_Check.Update();
        Panel_ApplyDetail.Visible = false;
        UpdatePanel_ApplyDetail.Update();
    }
    //部门
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
    //物料
    protected void Gridview1_RowDataBound(object sender, GridViewRowEventArgs e)
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
    #region //换页
    protected void Gridview_Organization_PageIndexChanging(object sender, GridViewPageEventArgs e)
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
        BindGridView_Organization();
        Gridview_Organization.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview_Organization.PageCount ? Gridview_Organization.PageCount - 1 : newPageIndex;
        Gridview_Organization.PageIndex = newPageIndex;
        Gridview_Organization.DataBind();
    }
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
        string condition = GetCondition();
        BindGridView2(condition);
        
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview2.PageCount ? Gridview2.PageCount - 1 : newPageIndex;
        Gridview2.PageIndex = newPageIndex;
        Gridview2.DataBind();
    }

    protected void Gridview1_PageIndexChanging(object sender, GridViewPageEventArgs e)
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

        string condition = GetCondition_Material();
        BindGridview1(condition);
        Gridview1.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview1.PageCount ? Gridview1.PageCount - 1 : newPageIndex;
        Gridview1.PageIndex = newPageIndex;
        Gridview1.DataBind();
    }

    protected void Gridview3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview3.BottomPagerRow;


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
        PMPurchaseingApplyRuleinfo.PMPAM_ID = new Guid(label_PMPAM_ID.Text);
        BindGridview3(PMPurchaseingApplyRuleinfo);
        Gridview3.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview3.PageCount ? Gridview3.PageCount - 1 : newPageIndex;
        Gridview3.PageIndex = newPageIndex;
        Gridview3.DataBind();
    }
    #endregion
    #region//悬浮框
    protected void Gridview3_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Gridview3.Rows.Count; i++)
        {
            for (int j = 0; j < Gridview3.Rows[i].Cells.Count; j++)
            {
                Gridview3.Rows[i].Cells[j].ToolTip = Gridview3.Rows[i].Cells[j].Text;
                if (Gridview3.Rows[i].Cells[j].Text.Length > 15)
                {
                    Gridview3.Rows[i].Cells[j].Text = Gridview3.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }
            }
        }
    }
    #endregion
    //重置
    protected void Button_Reset(object sender, EventArgs e)
    {
        TextBox2.Text = "";
        //if (this.label_Setting.Text == "Emergency")
        //{
        //    this.DropDownList2.SelectedValue = "财务总监审核通过";
        //}
        DropDownList2.SelectedValue = "请选择";
        SupplyID.Text = "";
        TextBox10.Text = "";
        TextBox_SPTime2.Text = "";
        TextBox_SPTime3.Text = "";
        //string Condition = GetCondition();
        BindGridView2("");
        UpdatePanel_PMPurchaseApplyMain.Update();
    }
    //删除采购订单详细表
    protected void Gridview3_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Look1")//删除
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview3.SelectedIndex = row.RowIndex;
            PMPurchaseingApplyRuleinfo.PMPAD_ID = new Guid(e.CommandArgument.ToString());
            pl.DeletePMPurchaseApplyDetail(PMPurchaseingApplyRuleinfo);
            PMPurchaseingApplyRuleinfo.PMPAM_ID = new Guid(label_PMPAM_ID.Text);
            BindGridview3(PMPurchaseingApplyRuleinfo);
            UpdatePanel_ApplyDetail.Update();
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_ApplyDetail, GetType(), "aa", "alert('删除成功！')", true);
            return;
        }
        if (e.CommandName == "Look2")//查看采购进度
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview3.SelectedIndex = row.RowIndex;
            if (e.CommandArgument.ToString() == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "aa", "alert('还没有生成采购订单！')", true);
                return;
            }
            else
            {
                string condition = "and PMPO_PurchaseOrderID='"+e.CommandArgument.ToString()+"'";
                BindGridview4(condition);
                label59.Text = Gridview3.Rows[Gridview3.SelectedIndex].Cells[2].Text.ToString()+"   " + Gridview3.Rows[Gridview3.SelectedIndex].Cells[1].Text.ToString()+"  "+"采购进度";
                Panel1.Visible = true;
                UpdatePanel1.Update();
            }
        }
            if (e.CommandName == "Qu2")
            {
                Guid id = new Guid(e.CommandArgument.ToString());
                string man = Session["UserName"].ToString();
                ptp.Update_PMPurchasingApply_Qu(id, man);
                PMPurchaseingApplyRuleinfo.PMPAM_ID = new Guid(label_PMPAM_ID.Text);
                BindGridview3(PMPurchaseingApplyRuleinfo);
                UpdatePanel_ApplyDetail.Update();
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "aa", "alert('已去除！')", true);
                
            }
        
    }
    private void BindGridview4(string condition)
    {
        Gridview4.DataSource = ppl.SelectPMPurchaseOrderMain(condition);
        Gridview4.DataBind();
    }
    protected void Gridview2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //string man = "";
        //string department = "";
       
            //man = Session["UserRole"].ToString();
            //department = Session["Department"].ToString();
     
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;
            if (drv["PMPAM_State"].ToString().Trim() == "未制定" || drv["PMPAM_State"].ToString().Trim() == "部门主管审核驳回" || drv["PMPAM_State"].ToString().Trim() == "财务主管审核驳回" || drv["PMPAM_State"].ToString().Trim() == "财务总监审核驳回" || drv["PMPAM_State"].ToString().Trim() == "部门副总审核驳回" || drv["PMPAM_State"].ToString().Trim() == "技术副总审核驳回")
            {
                e.Row.Cells[8].Enabled = false;//审核
                e.Row.Cells[11].Enabled = false;
              
            }
            
            if (drv["PMPAM_State"].ToString().Trim() != "未制定")
            {
                e.Row.Cells[10].Enabled = false;
            }
            if (drv["PMPAM_State"].ToString().Trim() == "制定中")
            {
                e.Row.Cells[10].Enabled = false;
                e.Row.Cells[11].Enabled = false;
                e.Row.Cells[8].Enabled = false;
            }
           
            if (drv["PMPAM_State"].ToString().Trim() == "已提交" || drv["PMPAM_State"].ToString().Trim() == "部门主管审核通过" || drv["PMPAM_State"].ToString().Trim() == "部门副总审核通过" || drv["PMPAM_State"].ToString().Trim() == "财务主管审核通过" || drv["PMPAM_State"].ToString().Trim() == "技术副总审核通过")
            {
                e.Row.Cells[10].Enabled = false;
                e.Row.Cells[9].Enabled = false;
                e.Row.Cells[8].Enabled = true;
                e.Row.Cells[11].Enabled = false;
            }
            if (drv["PMPAM_State"].ToString().Trim() == "财务主管审核通过")
            {
                e.Row.Cells[10].Enabled = false;
                e.Row.Cells[9].Enabled = false;
                e.Row.Cells[8].Enabled = true;
                if (drv["PMPAM_EmergencyPur"].ToString().Trim() == "否")
                {
                    e.Row.Cells[11].Enabled = true;
                }
                else
                {
                    e.Row.Cells[11].Enabled = false;
                }
            }
            if (drv["PMPAM_State"].ToString().Trim() == "财务总监审核通过")
            {
                e.Row.Cells[10].Enabled = false;
                e.Row.Cells[11].Enabled = false;
                e.Row.Cells[9].Enabled = false;
                e.Row.Cells[8].Enabled = false;
            }
           
        }
    }
    //关闭
    protected void Button_Close(object sender, EventArgs e)
    {
        Panel_ApplyDetail.Visible = false;
        UpdatePanel_ApplyDetail.Update();
    }

    //关闭查看审核意见
    protected void Button_CL(object sender, EventArgs e)
    {
        TextBox7.Text = "";
        TextBox8.Text = "";
        TextBox9.Text = "";
        Panel1_Check.Visible = false;
        UpdatePanel1_Check.Update();
        Panel_ApplyDetail.Visible = false;
        UpdatePanel_ApplyDetail.Update();
    }


    protected void Button1_KiM(object sender, EventArgs e)
    {
        string condition = GetCondition_Material();
        BindGridview1(condition);
        UpdatePanel_Material.Update();
    }
    protected string GetCondition_Material()
    {
        string item = "";
        string condition;
        if (TextBox16.Text != "")
        {
            item += "and IMMBD_MaterialName  like '%" + TextBox16.Text.ToString() + "%'";
        }
        if(TextBox17.Text != "")
        {
            item += "and IMMBD_SpecificationModel like'%" + TextBox17.Text.ToString().Trim()+ "%'";
        }
        condition = item;
        return condition;
    }
    protected void Button_CoM(object sender, EventArgs e)
    {
        TextBox16.Text = "";
        TextBox17.Text = "";
        BindGridview1("");
    }
    //关闭查看项目进度
    protected void Button_JD(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        UpdatePanel1.Update();
    }



    protected void Gridview3_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;
            if (drv["PMPAD_QuMan"].ToString().Trim() != "" && drv["PMPAD_QuMan"].ToString().Trim() != "&nbsp;")
            {
                e.Row.BackColor = System.Drawing.Color.Pink;

            }
        }
    }
}