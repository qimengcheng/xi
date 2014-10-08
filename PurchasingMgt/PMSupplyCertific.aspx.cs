using System;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using RTXHelper;

public partial class ProjectManagement_PMSupplyCertific : Page
{
    PRMProjectScheduleL prl = new PRMProjectScheduleL();
    PMSupplyInfo_PMSupplyContactL pl = new PMSupplyInfo_PMSupplyContactL();
    PMSupplyCertificL pc = new PMSupplyCertificL();
    PMSupplyCertificinfo PMSupplyCertificinfo = new PMSupplyCertificinfo();
    PMEquipmentL pll = new PMEquipmentL();
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!((Session["UserRole"].ToString().Contains("供应商认证申请")) || (Session["UserRole"].ToString().Contains("供应商认证制定"))
            || (Session["UserRole"].ToString().Contains("供应商认证会签")) || (Session["UserRole"].ToString().Contains("技术副总供应商认证审核"))
            || (Session["UserRole"].ToString().Contains("总经理供应商认证审核"))))
        {
            Response.Redirect("~/Default.aspx");
        }

        
        if (!IsPostBack)
        {
            ClosePanel();
            string state = Request.QueryString["state"];
            if (state == "CertificApply")
            {
                Title = "供应商认证申请";
                Button3.Visible = true;
                Gridview1.Columns[8].Visible = false;
                Gridview1.Columns[9].Visible = false;
                Gridview1.Columns[10].Visible = false;
                Gridview1.Columns[11].Visible = false;
                Gridview4.Columns[8].Visible = true;
            }
            if (state == "CertificApplyLook")
            {
                Title = "供应商认证申请查看";
                Button3.Visible = false;
                Gridview1.Columns[7].Visible = false;
                Gridview1.Columns[6].Visible = false;
                Gridview1.Columns[8].Visible = false;
                Gridview1.Columns[9].Visible = false;
                Gridview1.Columns[10].Visible = false;
                Gridview1.Columns[11].Visible = false;
                Gridview1.Columns[12].Visible = false;
                Gridview4.Columns[8].Visible = false ;
            }
            if (state == "CertificEdit")
            {
                Title = "供应商认证制定";
                Button3.Visible = false;
                Gridview1.Columns[6].Visible = false;
                Gridview1.Columns[7].Visible = false;
                Gridview1.Columns[9].Visible = false;
                Gridview1.Columns[10].Visible = false;
                Gridview1.Columns[11].Visible = false;
                Gridview1.Columns[12].Visible = false;
                Gridview4.Columns[8].Visible = false;
            }
            if (state == "CertificSign")
            {
                Title = "供应商认证会签";
                Button3.Visible = false;
                Gridview1.Columns[6].Visible = false;
                Gridview1.Columns[7].Visible = false;
                Gridview1.Columns[8].Visible = false;
                Gridview1.Columns[10].Visible = false;
                Gridview1.Columns[11].Visible = false;
                Gridview1.Columns[12].Visible = false;
                Gridview4.Columns[8].Visible = false;
            }
            if (state == "CertificPreCheck")
            {
                Title = "供应商认证技术副总审核";
                Button3.Visible = false;
                Gridview1.Columns[6].Visible = false;
                Gridview1.Columns[7].Visible = false;
                Gridview1.Columns[9].Visible = false;
                Gridview1.Columns[8].Visible = false;
                Gridview1.Columns[11].Visible = false;
                Gridview1.Columns[12].Visible = false;
                Gridview4.Columns[8].Visible = false;
            }
            if (state == "CertificCheck")
            {
                Title = "供应商认证总经理审核";
                Button3.Visible = false;
                Gridview1.Columns[6].Visible = false;
                Gridview1.Columns[7].Visible = false;
                Gridview1.Columns[9].Visible = false;
                Gridview1.Columns[8].Visible = false;
                Gridview1.Columns[10].Visible = false;
                Gridview1.Columns[12].Visible = false;
                Gridview4.Columns[8].Visible = false;
            }
            Panel_SupplyCertificSearch.Visible = true;
            BindGridView1("");
            Panel2_Approve.Visible = true;
            UpdatePanel2_Approve.Update();
        }
    }
    //绑定物料表
    private void BindGridview5(string condition)
    {
        Gridview5.DataSource = pll.SelectPMEMaterial(condition);
        Gridview5.DataBind();
    }
    //绑定申请部门
    private void Bind_DDLMark(DropDownList DDLMark)
    {
        this.DDLMark.DataSource = prl.SelectPRMP_Organization("").Tables[0].DefaultView;
        DDLMark.DataTextField = "BDOS_Name";
        DDLMark.DataValueField = "BDOS_Name";
        DDLMark.DataBind();
        DDLMark.Items.Insert(0, new ListItem("请选择", ""));
        this.DDLMark.SelectedValue = Session["Department"].ToString().Trim();
        this.DDLMark.Enabled = false;
    }
    //绑定认证申请表
    private void BindGridView1(string Condition)
    {
        try
        {
            Gridview1.DataSource = pc.SelectPMSupplyCertificApply(Condition);
            Gridview1.DataBind();
        }
        catch (Exception)
        {
            throw;
        }
    }
    #region//检索
    protected void Button1_Sh(object sender, EventArgs e)
    {
        try
        {
            string Condition = GetCondition();
            BindGridView1(Condition);

            UpdatePanel2_Approve.Update();
            Panel__Spl_New.Visible = false;
            UpdatePanel_Spl_New.Update();
            Panel_Supply.Visible = false;
            UpdatePanel_Supply.Update();
            Panel1.Visible = false;
            UpdatePanel1.Update();
            Panel_Preserve.Visible = false;
            UpdatePanel_Preserve.Update();
            Panel_Check.Visible = false;
            UpdatePanel_Check.Update();
           
            Panel4.Visible = false;
            //this.Panel5.Visible = false;
            UpdatePanel2.Update();
            Panel_Material.Visible = false;
            UpdatePanel_Material.Update();
        }
        catch (Exception)
        {
            throw;
        }
    }
    //获取检索条件
    protected string GetCondition()
    {
        try
        {
            string Condition;
            string item = "";
            if (PMSCA_ApplyDepart.Text.ToString() != "")
            {
                item += " and PMSCA_ApplyDepart  like '%" + PMSCA_ApplyDepart.Text.ToString() + "%'";
            }
            if (TextBox1.Text.ToString() != "")
            {
                item += "and PMSupplyCertificApply.PMSI_ID like '%" + label_SupplyID.Text.ToString() + "'";
            }
            if (DropDownList3.SelectedValue.ToString() != "请选择")
            {
                item += "and PMSCA_State='" + DropDownList3.SelectedValue.ToString() + "'";
            }
            if (PMSCA_MaterialName.Text.ToString() != "")
            {
                item += "and PMSCA_MaterialName like '%" + PMSCA_MaterialName.Text.ToString() + "'";
            }
            if (TextBox3.Text.ToString() != "")
            {
                item += "and PMSCA_ApplyAim like'%" + TextBox3.Text.ToString() + "%'";
            }
            Condition = item;
            label1_Condition.Text = Condition;
            return Condition;
        }
        catch (Exception)
        {
            throw;
        }
    }
    //选择供应商
    protected void Button_Supply(object sender, EventArgs e)
    {
        try
        {
            label_Supply.Text = "检索";
            BindGridview_PMSupply("");
            Panel_Supply.Visible = true;
            UpdatePanel_Supply.Update();
        }
        catch (Exception)
        {
            throw;
        }
    }
    #endregion
    //新增申请单
    protected void Button3_New(object sender, EventArgs e)
    {
        try
        {
            Bind_DDLMark(DDLMark);
            label_New.Text = "新增申请单";
            Panel__Spl_New.Visible = true;
            UpdatePanel_Spl_New.Update();
        }
        catch (Exception)
        {
            throw;
        }
    }
    //重置检索
    protected void Button3_Reset(object sender, EventArgs e)
    {
        try
        {
            BindGridView1("");
            Panel2_Approve.Visible = true;
            UpdatePanel2_Approve.Update();
            PMSCA_ApplyDepart.Text = "";
            TextBox1.Text = "";
            DropDownList3.SelectedValue = "请选择";
            PMSCA_MaterialName.Text = "";
            TextBox3.Text = "";
        }
        catch (Exception)
        {
            throw;
        }
    }
    //认证会签表
    private void BindGridview4(PMSupplyCertificinfo pMSupplyCertificinfo)
    {
        Gridview4.DataSource = pc.SelectPMSupplyCertificApplyCountersign(pMSupplyCertificinfo);
        Gridview4.DataBind();
    }
    //认证申请表的修改、删除、认证、会签、审核链接
    protected void Gridview1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Modify1")//修改
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview1.SelectedIndex = row.RowIndex;
            label_CertificApplyNum.Text = e.CommandArgument.ToString();
            Bind_DDLMark(DDLMark);
            PMSupplyCertificinfo.PMSCA_CertificApplyNum = new Guid(e.CommandArgument.ToString());
            DataSet ds = pc.SelectPMSupplyCertificApply_One(PMSupplyCertificinfo);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                TextBox4.Text = dt.Rows[0][3].ToString();
                DDLMark.SelectedValue = dt.Rows[0][2].ToString();
                label_SupplyID.Text = dt.Rows[0][1].ToString();//供应商ID
                TextBox7.Text = dt.Rows[0][4].ToString();
                Guid sid = new Guid(label_SupplyID.Text);
                DataSet dds = pl.SelectPMSupply_One(sid);
                DataTable ddt = dds.Tables[0];
                if (ddt.Rows.Count > 0)
                {
                    TextBox6.Text = ddt.Rows[0][0].ToString();
                }
            }
            Guid tt = new Guid(e.CommandArgument.ToString());
            Supply(tt);
            label_New.Text = label_PM.Text + "   " + label_SN.Text + "  " + label_WN.Text + "   " + "修改申请单";
            Panel__Spl_New.Visible = true;
            UpdatePanel_Spl_New.Update();
        }
        if (e.CommandName == "Delete1")//删除
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview1.SelectedIndex = row.RowIndex;
            PMSupplyCertificinfo.PMSCA_CertificApplyNum = new Guid(e.CommandArgument.ToString());
            pc.DeletePMSupplyCertificApply(PMSupplyCertificinfo);
            BindGridView1("");
            UpdatePanel2_Approve.Update();
            ScriptManager.RegisterClientScriptBlock(UpdatePanel2_Approve, GetType(), "alert", "alert('删除成功！')", true);
            return;
        }
        if (e.CommandName == "Approve")//认证
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview1.SelectedIndex = row.RowIndex;
            label_XinOXiu.Text = "认证";
            label_CertificApplyNum.Text = e.CommandArgument.ToString();
            Guid tt = new Guid(e.CommandArgument.ToString());
            Supply(tt);
            label_WH.Text = label_PM.Text + "   " + label_SN.Text + "  " + label_WN.Text;
            label_WHB.Text = label_PM.Text + "   " + label_SN.Text + "  " + label_WN.Text + "   " + "认证维护表";

            Panel1.Visible = true;
            TextBox8.Text = Session["Department"].ToString().Trim();
            UpdatePanel1.Update();
            Panel_Preserve.Visible = true;
            PMSupplyCertificinfo.PMSCA_CertificApplyNum = new Guid(e.CommandArgument.ToString());

            BindGridView2(PMSupplyCertificinfo);
            UpdatePanel_Preserve.Update();
        }
        if (e.CommandName == "Coutersign")//会签
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview1.SelectedIndex = row.RowIndex;
            Gridview4.Columns[7].Visible = true;
            label_CertificApplyNum.Text = e.CommandArgument.ToString();
            PMSupplyCertificinfo.PMSCA_CertificApplyNum = new Guid(label_CertificApplyNum.Text);
            //this.Panel4.Visible = true;
            //this.Panel5.Visible = true;
            //this.Panel4.Enabled = true;
            //this.Button22.Enabled = true;
            //this.Button23.Enabled = true;
            //this.UpdatePanel2.Update();
            label_Result.Text = "会签";
            //PMSupplyCertificinfo.PMSCA_CertificApplyNum = new Guid(this.label_CertificApplyNum.Text);
            Guid tt = new Guid(e.CommandArgument.ToString());
            Supply(tt);
            label30.Text = label_PM.Text + "   " + label_SN.Text + "  " + label_WN.Text + "   " + "会签";
            //DataSet ds = pc.SelectPMSupplyCertificApply_One(PMSupplyCertificinfo);
            //DataTable dt = ds.Tables[0];
            BindGridview4(PMSupplyCertificinfo);
            //for (int i = 0; i < this.Gridview4.Rows.Count;i++ )
            //{
            //    if(this.Gridview4.Rows[i].Cells[2].Text=="驳回")
            //    {
            //        this.Gridview4.Columns[7].Visible = false;
            //    }
            //}
            Gridview4.Columns[8].Visible = false;
            Gridview4.Columns[7].Visible = true;
            Panel_Sign.Visible = true;
            UpdatePanel_Sign.Update();
            //if (Session["UserRole"].ToString().Contains("供应商认证会签"))
            //{

            //if (this.label_EDHQ.Text == "驳回" || this.label_PDHQ.Text == "驳回" || this.label_QAHQ.Text == "驳回")
            //{
            //    this.Panel4.Enabled = false;
            //    this.Button22.Enabled = false;
            //    this.Button23.Enabled = false;
            //}
        }
        if (e.CommandName == "Check1")//技术副总审核
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview1.SelectedIndex = row.RowIndex;
            label_Result.Text = "技术副总审核";
            label_CertificApplyNum.Text = e.CommandArgument.ToString();
            Guid tt = new Guid(e.CommandArgument.ToString());
            Supply(tt);
            label_Check.Text = label_PM.Text + "   " + label_SN.Text + "  " + label_WN.Text + "   " + "审核";
            PMSupplyCertificinfo.PMSCA_CertificApplyNum = new Guid(label_CertificApplyNum.Text);
           
       
            label30.Text = label_PM.Text + "   " + label_SN.Text + "  " + label_WN.Text + "   " + "会签";
            BindGridview4(PMSupplyCertificinfo);
            Gridview4.Columns[7].Visible = false;
            UpdatePanel_Sign.Update();

            label_Check.Visible = true;
            Label16.Visible = true;
            Button35.Visible = false;
            Button13.Visible = true;
            Button15.Visible = true;
            Button14.Visible = true;
            label15.Visible = true;
            label_XZ.Visible = true;
            TextBox10.Visible = true;
            TextBox14.Visible = false;
            label_Opinion.Visible = false;
            label_XZ1.Visible = false;
           
            Panel_Check.Visible = true;
            label_PRMP_DesignMangCheckResult.Visible = false;
            label_PRMP_DesignMangName.Visible = false;
            label_Time.Visible = false;
            TextBox10.Enabled = true;
            Label17.Visible = false;
            UpdatePanel_Check.Update();
        }
        if (e.CommandName == "Check2")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview1.SelectedIndex = row.RowIndex;
            label_Result.Text = "总经理审核";
            label_PRMP_DesignMangCheckResult.Visible = true;
            label_PRMP_DesignMangName.Visible = true;
            label_Time.Visible = true;
            TextBox10.Visible = true;
            Button35.Visible = false;
            Button13.Visible = true;
            Button15.Visible = true;
            Button14.Visible = true;
            label15.Visible = true;
            Label17.Visible = true;
            Label16.Visible = true;
            TextBox10.Enabled = false;
            label_Opinion.Visible = true;
            label_XZ1.Visible = true;
            TextBox14.Visible = true;
            label_CertificApplyNum.Text = e.CommandArgument.ToString();
            Guid tt = new Guid(e.CommandArgument.ToString());
            Supply(tt);
            label_Check.Visible = true;
            label_Check.Text = label_PM.Text + "   " + label_SN.Text + "  " + label_WN.Text + "   " + "审核";
            PMSupplyCertificinfo.PMSCA_CertificApplyNum = tt;
            DataSet ds = pc.SelectPMSCA_DMCheckOpinion(PMSupplyCertificinfo);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                label_PRMP_DesignMangCheckResult.Text = dt.Rows[0][0].ToString();
                label_PRMP_DesignMangName.Text = dt.Rows[0][2].ToString();
                label_Time.Text = dt.Rows[0][3].ToString();
                TextBox10.Text = dt.Rows[0][1].ToString();
            }
            //PMSupplyCertificinfo.PMSCA_CertificApplyNum = new Guid(this.label_CertificApplyNum.Text);
        

            label30.Text = label_PM.Text + "   " + label_SN.Text + "  " + label_WN.Text + "   " + "会签";

            BindGridview4(PMSupplyCertificinfo);
            Gridview4.Columns[7].Visible = false;
            UpdatePanel_Sign.Update();



            Panel_Check.Visible = true;
            UpdatePanel_Check.Update();
        }
        if (e.CommandName == "Checkk")//选择会签部门
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview1.SelectedIndex = row.RowIndex;
            label_CertificApplyNum.Text = e.CommandArgument.ToString();
            BindGridview3("");
            Panel_Org.Visible = true;
            UpdatePanel_Org.Update();
            Gridview4.Columns[7].Visible = false;
            Gridview4.Columns[6].Visible = false;
            Gridview4.Columns[8].Visible = true;
            PMSupplyCertificinfo.PMSCA_CertificApplyNum = new Guid(label_CertificApplyNum.Text);
            BindGridview4(PMSupplyCertificinfo);
            Panel_Sign.Visible = true;
            UpdatePanel_Sign.Update();
        }

        if (e.CommandName == "Mkk")//查看审核意见
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview1.SelectedIndex = row.RowIndex;
            label_CertificApplyNum.Text = e.CommandArgument.ToString();
            Guid tt = new Guid(e.CommandArgument.ToString());
            Supply(tt);
            label_Check.Visible = true;
            label_Check.Text = label_PM.Text + "   " + label_SN.Text + "  " + label_WN.Text + "   " + "审核";
            PMSupplyCertificinfo.PMSCA_CertificApplyNum = tt;
            DataSet ds = pc.SelectPMSCA_DMCheckOpinion(PMSupplyCertificinfo);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                label_PRMP_DesignMangCheckResult.Text = dt.Rows[0][0].ToString();
                label_PRMP_DesignMangName.Text = dt.Rows[0][2].ToString();
                label_Time.Text = dt.Rows[0][3].ToString();
                TextBox10.Text = dt.Rows[0][1].ToString();
                label19.Text = dt.Rows[0][4].ToString();
                label21.Text = dt.Rows[0][6].ToString();
                label22.Text = dt.Rows[0][7].ToString();
                TextBox14.Text = dt.Rows[0][5].ToString();
            }
            //PMSupplyCertificinfo.PMSCA_CertificApplyNum = new Guid(this.label_CertificApplyNum.Text);
            label30.Text = label_PM.Text + "   " + label_SN.Text + "  " + label_WN.Text + "   " + "会签";

            BindGridview4(PMSupplyCertificinfo);
            Gridview4.Columns[6].Visible = true ;
            Gridview4.Columns[7].Visible = false;
            Gridview4.Columns[8].Visible = false;
            Panel_Sign.Visible = true;
            UpdatePanel_Sign.Update();
            label_PRMP_DesignMangCheckResult.Visible = true;
            Label17.Visible = true;
            label_PRMP_DesignMangName.Visible = true;
            label_Time.Visible = true;
            label19.Visible =true;
            Label20.Visible = true;
            label21.Visible = true;
            label22.Visible = true;
            label_Opinion.Visible = true;
            label_XZ1.Visible = true;
            TextBox14.Visible = true;
            Button35.Visible = true;
            Button13.Visible = false;
            Button15.Visible = false;
            Button14.Visible = false;
            Label16.Visible = true;
            TextBox10.Visible = true;
            UpdatePanel_Sign.Update();
            Panel_Check.Visible = true;
            UpdatePanel_Check.Update();
        }
    }
    //标记认证申请表
    private void Supply(Guid condition)
    {
        try
        {
            PMSupplyCertificinfo.PMSCA_CertificApplyNum = condition;
            DataSet ds = pc.SelectPMSupplyCertificApply_One(PMSupplyCertificinfo);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                label_PM.Text = dt.Rows[0][2].ToString();
                label_SupplyID.Text = dt.Rows[0][1].ToString();//供应商ID
                label_WN.Text = dt.Rows[0][3].ToString();
                Guid sid = new Guid(label_SupplyID.Text);
                DataSet dds = pl.SelectPMSupply_One(sid);
                DataTable ddt = dds.Tables[0];
                if (ddt.Rows.Count > 0)
                {
                    label_SN.Text = ddt.Rows[0][0].ToString();
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    //绑定认证信息维护表
    private void BindGridView2(PMSupplyCertificinfo PMSupplyCertificinfo)
    {
        try
        {
            Gridview2.DataSource = pc.SelectPMSupplyCertificInfo(PMSupplyCertificinfo);
            Gridview2.DataBind();
        }
        catch (Exception)
        {
            throw;
        }
    }

    //提交新增、修改申请单
    protected void Button1_Com1(object sender, EventArgs e)
    {
        try
        {
            if (TextBox4.Text.ToString() != "")
            {
                PMSupplyCertificinfo.PMSCA_MaterialName = TextBox4.Text.ToString();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel_Spl_New, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            if (DDLMark.SelectedValue.ToString() != "请选择")
            {
                PMSupplyCertificinfo.PMSCA_ApplyDepart = DDLMark.SelectedValue.ToString();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel_Spl_New, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            if (TextBox6.Text.ToString() != "")
            {
                PMSupplyCertificinfo.PMSI_ID = new Guid(label_SupplyID.Text);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel_Spl_New, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            if (TextBox7.Text.ToString() != "")
            {
                PMSupplyCertificinfo.PMSCA_ApplyAim = TextBox7.Text.ToString();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel_Spl_New, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            if (TextBox10.Text != "")
            {
                string[] sg = TextBox10.Text.ToString().Split(new char[] { ';' });
                for (int i = 0; i < sg.Length;i++ )
                {
                    PMSupplyCertificinfo.PMSCAC_SignPartment = sg[i];
                    
                }

            }
            if (label_New.Text == "新增申请单")
            {
                PMSupplyCertificinfo.PMSCA_State = "已提交";

                PMSupplyCertificinfo.PMSCA_ApplyMan = Session["UserName"].ToString().Trim();
                pc.InsertPMSupplyCertificApply(PMSupplyCertificinfo);
                BindGridView1("");
                Panel2_Approve.Visible = true;
                UpdatePanel2_Approve.Update();
                Panel__Spl_New.Visible = false;
                UpdatePanel_Spl_New.Update();
                ScriptManager.RegisterClientScriptBlock(UpdatePanel_Spl_New, GetType(), "alert", "alert('提交成功,请选择会签部门！')", true);
                label_RTX.Text="ERP系统信息："+Session["UserName"].ToString()+"于"+DateTime.Now+"提交了"+TextBox6.Text.ToString() +"和"+ TextBox4.Text.ToString()+"的认证申请单，请认证。";
                string message = label_RTX.Text;
                 string sErr=RTXhelper.Send(message, "供应商认证制定");
                if (!string.IsNullOrEmpty(sErr))
                {
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
                }
            }
            if (label_New.Text.Contains("修改申请单"))
            {
                PMSupplyCertificinfo.PMSCA_CertificApplyNum = new Guid(label_CertificApplyNum.Text);


                PMSupplyCertificinfo.PMSCA_ApplyModifier = Session["UserId"].ToString().Trim();
                pc.UpdatePMSupplyCertificApply(PMSupplyCertificinfo);
                PMSupplyCertificinfo.PMSCA_State = "已提交";
                pc.UpdatePMSCA_State(PMSupplyCertificinfo);
                BindGridView1("");
                Panel2_Approve.Visible = true;
                UpdatePanel2_Approve.Update();
                Panel__Spl_New.Visible = false;
                UpdatePanel_Spl_New.Update();
            }
            TextBox4.Text = "";
            DDLMark.DataTextField = "请选择";
            TextBox6.Text = "";
            TextBox7.Text = "";
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_Spl_New, GetType(), "alert", "alert('提交成功！')", true);
            return;
        }
        catch (Exception)
        {
            throw;
        }

    }

    //查找供应商
    protected void Button_SupplySearch(object sender, EventArgs e)
    {
        try
        {
            label_Supply.Text = "认证";
            BindGridview_PMSupply("");
            Panel_Supply.Visible = true;
            UpdatePanel_Supply.Update();
        }
        catch (Exception)
        {
            throw;
        }

    }
    //绑定供应商列表
    private void BindGridview_PMSupply(string Condition)
    {
        try
        {
            Gridview_PMSupply.DataSource = pl.SelectPMSupplyInfo(Condition);
            Gridview_PMSupply.DataBind();
        }
        catch (Exception)
        {
            throw;

        }
    }
    //供应商查询确认
    protected void Button_ComSP(object sender, EventArgs e)
    {
        try
        {
            string Pname;
            bool temp = false;

            foreach (GridViewRow item in Gridview_PMSupply.Rows)
            {
                RadioButton rb = item.FindControl("RadioButtonMarkup") as RadioButton;

                if (rb.Checked)
                {
                    Pname = Gridview_PMSupply.Rows[item.RowIndex].Cells[3].Text.ToString();
                    temp = true;
                    if (label_Supply.Text == "认证")
                    {
                        TextBox6.Text = Pname;
                        UpdatePanel_Spl_New.Update();
                    }
                    if (label_Supply.Text == "检索")
                    {
                        TextBox1.Text = Pname;
                        UpdatePanel_SupplyCertificSearch.Update();
                    }
                    label_SupplyID.Text = Gridview_PMSupply.DataKeys[item.RowIndex].Value.ToString();
                }
            }
            if (!temp)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel_Supply, GetType(), "aa", "alert('请选择供应商')", true);
            }
            else
            {
                Panel_Supply.Visible = false;
                UpdatePanel_Supply.Update();
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    //RadioButton 互斥
    protected void Gridview_PMSupply_RowDataBound(object sender, GridViewRowEventArgs e)
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
    //供应商查询取消
    protected void Button_CancelSP(object sender, EventArgs e)
    {
        try
        {
            Panel_Supply.Visible = false;
            UpdatePanel_Supply.Update();
        }
        catch (Exception)
        {
            throw;
        }
    }
    //取消新增、修改申请单
    protected void Button_Cancel(object sender, EventArgs e)
    {
        try
        {
            TextBox4.Text = "";
            DDLMark.DataTextField = "请选择";
            TextBox6.Text = "";
            TextBox7.Text = "";
            Panel__Spl_New.Visible = false;
            UpdatePanel_Spl_New.Update();
            Panel_Supply.Visible = false;
            UpdatePanel_Supply.Update();
        }
        catch (Exception)
        {
            throw;
        }
    }
    //认证维护提交
    protected void Button1_ComWH(object sender, EventArgs e)
    {
        try
        {
            if (DropDownList1.SelectedValue == "请选择")
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            else
            {
                PMSupplyCertificinfo.PMSCI_CertificSchedule = DropDownList1.SelectedValue;
            }

            if (DropDownList2.SelectedValue == "请选择")
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            else
            {
                PMSupplyCertificinfo.PMSCI_CertificResult = DropDownList2.SelectedValue;
            }
            if (TextBox9.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            else
            {
                PMSupplyCertificinfo.PMSCI_Model = TextBox9.Text;
            }
            //if (this.TextBox11.Text == "")
            //{
            //    ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.GetType(), "alert", "alert('请填写备注！')", true);
            //    return;
            //}
            //else
            //{
                PMSupplyCertificinfo.PMSCI_Remark = TextBox11.Text;
            //}
            PMSupplyCertificinfo.PMSCI_CheckDepertment = TextBox8.Text;
            if (label_XinOXiu.Text == "认证")
            {
                Guid pp = new Guid(label_CertificApplyNum.Text);
                PMSupplyCertificinfo.PMSCA_CertificApplyNum = pp;
                if (LabelQ_SaveDirectory.Text == "上传")
                {
                    PMSupplyCertificinfo.PMSCI_Accessory = "是";
                    PMSupplyCertificinfo.PMSCI_AccName = label_AccName.Text.ToString();
                    PMSupplyCertificinfo.PMSCI_AccNum = label_AccNum.Text.ToString();
                    PMSupplyCertificinfo.PMSCI_AccPath = Label_FilePath.Text.ToString();
                }
                else
                {
                    PMSupplyCertificinfo.PMSCI_Accessory = "否";
                    PMSupplyCertificinfo.PMSCI_AccName = "";
                    PMSupplyCertificinfo.PMSCI_AccNum = "";
                    PMSupplyCertificinfo.PMSCI_AccPath ="";
                
                }
                pc.InsertPMSupplyCertificInfo(PMSupplyCertificinfo);
                PMSupplyCertificinfo.PMSCA_State = "认证中";
                pc.UpdatePMSCA_State(PMSupplyCertificinfo);
            }
            if (label_XinOXiu.Text == "修改")
            {
                Guid gd = new Guid(label_PMSCI_ID.Text.ToString());
                PMSupplyCertificinfo.PMSCI_ID = gd;
                PMSupplyCertificinfo.PMSCI_CertificModifier = Session["UserName"].ToString().Trim();
                PMSupplyCertificinfo.PMSCI_Accessory = Gridview2.Rows[Gridview2.SelectedIndex].Cells[6].Text.ToString();
                PMSupplyCertificinfo.PMSCI_AccName = label_AccName.Text.ToString();
                PMSupplyCertificinfo.PMSCI_AccNum = label_AccNum.Text.ToString();
                PMSupplyCertificinfo.PMSCI_AccPath = Label_FilePath.Text.ToString();
                pc.UpdatePMSupplyCertificInfo(PMSupplyCertificinfo);
                
            }
            Guid ppt = new Guid(label_CertificApplyNum.Text);
            PMSupplyCertificinfo.PMSCA_CertificApplyNum = ppt;
            TextBox9.Text = "";
            TextBox11.Text = "";
            DropDownList1.SelectedValue = "请选择";
            DropDownList2.SelectedValue = "请选择";
            BindGridView2(PMSupplyCertificinfo);
            Panel_Preserve.Visible = true;
            UpdatePanel_Preserve.Update();
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_Spl_New, GetType(), "alert", "alert('提交成功！')", true);
            return;
        }
        catch (Exception)
        {
            throw;
        }
    }
    //取消认证信息维护
    protected void Button_CancelWH(object sender, EventArgs e)
    {
        try
        {
            TextBox9.Text = "";
            TextBox11.Text = "";
            DropDownList1.SelectedValue = "请选择";
            DropDownList2.SelectedValue = "请选择";
            Panel1.Visible = false;
            UpdatePanel1.Update();
            Panel_Preserve.Visible = false;
            UpdatePanel_Preserve.Update();
        }
        catch (Exception)
        {
            throw;
        }
    }
    //认证信息维护表的修改、删除
    protected void Gridview_Preserve_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit1")//修改认证信息表
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview2.SelectedIndex = row.RowIndex;
            label_XinOXiu.Text = "修改";
            Panel1.Visible = true;
            label_PMSCI_ID.Text = e.CommandArgument.ToString();
            Guid sc = new Guid(e.CommandArgument.ToString());
            PMSupplyCertificinfo.PMSCI_ID = sc;
            DataSet ds = pc.SelectPMSupplyCertificInfo_One(PMSupplyCertificinfo);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                TextBox9.Text = dt.Rows[0][0].ToString();
                TextBox8.Text = dt.Rows[0][1].ToString();
                DropDownList1.SelectedValue = dt.Rows[0][2].ToString();
                DropDownList2.SelectedValue = dt.Rows[0][3].ToString();
                TextBox11.Text = dt.Rows[0][4].ToString();
                label_AccName.Text = dt.Rows[0][5].ToString();
                label_AccNum.Text = dt.Rows[0][6].ToString();
                label_AccPath.Text = dt.Rows[0][7].ToString();
            }
            UpdatePanel1.Update();
        }
        if (e.CommandName == "Cancel1")//删除认证信息表
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview2.SelectedIndex = row.RowIndex;
            label_PMSCI_ID.Text = e.CommandArgument.ToString();
            string[] sg = e.CommandArgument.ToString().Split(new char[] { ',' });

            Guid sc = new Guid(sg[0]);
            PMSupplyCertificinfo.PMSCI_ID = sc;
            pc.DeletePMSupplyCertificInfo_One(PMSupplyCertificinfo);
            if (sg[1] != "")
            {
                string delfile = Server.MapPath("~/") + sg[1];
                File.Delete(delfile);
            }


            PMSupplyCertificinfo.PMSCA_CertificApplyNum = new Guid(label_CertificApplyNum.Text);
            BindGridView2(PMSupplyCertificinfo);
            UpdatePanel_Preserve.Update();
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_Preserve, GetType(), "alert", "alert('删除成功！')", true);
            return;
        }
    }
    //认证信息维护提交
    protected void Button_CF(object sender, EventArgs e)
    {
        try
        {
            if (Gridview2.Rows.Count <= 0)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel_Preserve, GetType(), "alert", "alert('请认证信息！')", true);
                return;
            }
            Panel_Preserve.Visible = true;
            UpdatePanel_Preserve.Update();
            Panel1.Visible = true;
            UpdatePanel1.Update();
            Guid lt = new Guid(label_CertificApplyNum.Text);
            PMSupplyCertificinfo.PMSCA_CertificApplyNum = lt;
            PMSupplyCertificinfo.PMSCA_State = "认证完成";
            pc.UpdatePMSCA_State(PMSupplyCertificinfo);
            BindGridView1("");
            BindGridview4(PMSupplyCertificinfo);
            Panel2_Approve.Visible = true;
            UpdatePanel2_Approve.Update();
            Panel1.Visible = false;
            UpdatePanel1.Update();
            Panel_Preserve.Visible = false;
            UpdatePanel_Preserve.Update();
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_Spl_New, GetType(), "alert", "alert('认证完成！')", true);
            return;
 
            string dep = "";
            foreach (GridViewRow q in Gridview4.Rows)
            {
                dep += q.Cells[1].Text.ToString() + ",";
            }
            dep = dep.Substring(0, dep.Length - 1);
            label_RTX3.Text = "ERP系统信息：" + Session["UserName"].ToString() + "于" + DateTime.Now + "提交了" + Gridview1.Rows[Gridview1.SelectedIndex].Cells[2].Text.ToString() + "和" + Gridview1.Rows[Gridview1.SelectedIndex].Cells[3].Text.ToString() + "的认证申请单的认证，请会签。"; 
            string message = label_RTX.Text;
            string sErr = RTXhelper.SendbyDepAndRole(message, dep, "供应商认证会签");
            if (!string.IsNullOrEmpty(sErr))
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    //取消认证信息维护
    protected void Button2_Cancel1(object sender, EventArgs e)
    {
        try
        {
            TextBox9.Text = "";
            TextBox11.Text = "";
            DropDownList1.SelectedValue = "请选择";
            DropDownList2.SelectedValue = "请选择";
            Panel1.Visible = false;
            UpdatePanel1.Update();
            Panel_Preserve.Visible = false;
            UpdatePanel_Preserve.Update();
            ClosePanel();
            UpdatePanel4.Update();
        }
        catch (Exception)
        {
            throw;
        }
    }
    //审核通过
    protected void Button1_ComF(object sender, EventArgs e)
    {
        try
        {
            if (label_Result.Text == "技术副总审核")
            {
                PMSupplyCertificinfo.PMSCA_CertificApplyNum = new Guid(label_CertificApplyNum.Text.ToString());
                PMSupplyCertificinfo.PMSCA_DMCheckOpinion = TextBox10.Text.ToString();
                PMSupplyCertificinfo.PMSCA_DMCheckResult = "通过";
                PMSupplyCertificinfo.PMSCA_DMCheckMan = Session["UserName"].ToString().Trim();

                PMSupplyCertificinfo.PMSCA_State = "技术副总审核通过";
                pc.InsertPMSCA_DMCheck(PMSupplyCertificinfo);
                pc.UpdatePMSCA_State(PMSupplyCertificinfo);
                label_RTX2.Text = "ERP系统信息：" + Gridview1.Rows[Gridview1.SelectedIndex].Cells[2].Text.ToString() + "和" + Gridview1.Rows[Gridview1.SelectedIndex].Cells[3].Text.ToString() + "的认证申请单" + "于" + DateTime.Now + "完成技术副总审核，请审核。";
                string message = label_RTX2.Text;
                string sErr=RTXhelper.Send(message, "总经理供应商认证审核");
                if (!string.IsNullOrEmpty(sErr))
                {
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
                }
            }
            if (label_Result.Text == "总经理审核")
            {
                PMSupplyCertificinfo.PMSCA_CertificApplyNum = new Guid(label_CertificApplyNum.Text.ToString());
                PMSupplyCertificinfo.PMSCA_GMCheckOpinion = TextBox14.Text;
                PMSupplyCertificinfo.PMSCA_GMCheckResult = "通过";
                PMSupplyCertificinfo.PMSCA_GMCheckMan = Session["UserName"].ToString();

                PMSupplyCertificinfo.PMSCA_State = "总经理审核通过";
                pc.UpdatePMSCA_State(PMSupplyCertificinfo);
                pc.InsertPMSCA_GMCheck(PMSupplyCertificinfo);
               
            }
            BindGridView1("");
            Panel2_Approve.Visible = true;
            UpdatePanel2_Approve.Update();
            label_PRMP_DesignMangCheckResult.Visible = false;
            Label17.Visible = false;
            label_PRMP_DesignMangName.Visible = false;
            label_Time.Visible = false;
            label19.Visible = false;
            Label20.Visible = false;
            label21.Visible = false;
            label22.Visible = false;
            label_Opinion.Visible = false;
            label_XZ1.Visible = false;
            TextBox14.Visible = false;
            Button35.Visible = false;
            Panel_Check.Visible = false;
            UpdatePanel_Check.Update();
        }
        catch (Exception)
        {
            throw;
        }
    }
    //审核驳回
    protected void Button1_BH(object sender, EventArgs e)
    {
        try
        {
            if (label_Result.Text == "技术副总审核")
            {
                PMSupplyCertificinfo.PMSCA_CertificApplyNum = new Guid(label_CertificApplyNum.Text.ToString());
                PMSupplyCertificinfo.PMSCA_DMCheckOpinion = TextBox10.Text.ToString();
                PMSupplyCertificinfo.PMSCA_DMCheckResult = "驳回";
                PMSupplyCertificinfo.PMSCA_DMCheckMan = Session["UserName"].ToString().Trim();

                PMSupplyCertificinfo.PMSCA_State = "技术副总审核驳回";
                pc.InsertPMSCA_DMCheck(PMSupplyCertificinfo);
                pc.UpdatePMSCA_State(PMSupplyCertificinfo);
                
                label_RTX_P.Text = "ERP系统信息：" + Session["UserName"].ToString() + "于" + DateTime.Now + "驳回" + Gridview1.Rows[Gridview1.SelectedIndex].Cells[2].Text.ToString() + "和" + Gridview1.Rows[Gridview1.SelectedIndex].Cells[3].Text.ToString() + "的认证申请单，请查看";
                 string message = label_RTX_P.Text;
                 string dep = Gridview1.Rows[Gridview1.SelectedIndex].Cells[1].Text.ToString();
                 string sErr = RTXhelper.SendbyDepAndRole(message, dep, "供应商认证申请");
                if (!string.IsNullOrEmpty(sErr))
                {
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
                }

            }
            if (label_Result.Text == "总经理审核")
            {
                PMSupplyCertificinfo.PMSCA_CertificApplyNum = new Guid(label_CertificApplyNum.Text.ToString());
                PMSupplyCertificinfo.PMSCA_GMCheckOpinion = TextBox14.Text;
                PMSupplyCertificinfo.PMSCA_GMCheckResult = "驳回";
                PMSupplyCertificinfo.PMSCA_GMCheckMan = Session["UserName"].ToString();

                PMSupplyCertificinfo.PMSCA_State = "总经理审核驳回";
                pc.UpdatePMSCA_State(PMSupplyCertificinfo);
                pc.InsertPMSCA_GMCheck(PMSupplyCertificinfo);
                label_RTX_P.Text = "ERP系统信息：" + Session["UserName"].ToString() + "于" + DateTime.Now + "驳回" + Gridview1.Rows[Gridview1.SelectedIndex].Cells[2].Text.ToString() + "和" + Gridview1.Rows[Gridview1.SelectedIndex].Cells[3].Text.ToString() + "的认证申请单，请查看";
                    string message = label_RTX_P.Text;
                    string dep = Gridview1.Rows[Gridview1.SelectedIndex].Cells[1].Text.ToString();
                    string sErr = RTXhelper.SendbyDepAndRole(message, dep, "供应商认证申请");
                if (!string.IsNullOrEmpty(sErr))
                {
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
                }
            }

            BindGridView1("");
            Panel2_Approve.Visible = true;
            UpdatePanel2_Approve.Update();
            label_PRMP_DesignMangCheckResult.Visible = false;
            Label17.Visible = false;
            label_PRMP_DesignMangName.Visible = false;
            label_Time.Visible = false;
            label19.Visible = false;
            Label20.Visible = false;
            label21.Visible = false;
            label22.Visible = false;
            label_Opinion.Visible = false;
            label_XZ1.Visible = false;
            TextBox14.Visible = false;
            Button35.Visible = false;
            Panel_Check.Visible = false;
            UpdatePanel_Check.Update();
        }
        catch (Exception)
        {
            throw;
        }
    }
    //取消审核
    protected void Button_CancelF(object sender, EventArgs e)
    {
        try
        {
            label_PRMP_DesignMangCheckResult.Visible = false;
            Label17.Visible = false;
            label_PRMP_DesignMangName.Visible = false;
            label_Time.Visible = false;
            label19.Visible = false;
            Label20.Visible = false;
            label21.Visible = false;
            label22.Visible = false;
            label_Opinion.Visible = false;
            label_XZ1.Visible = false;
            TextBox14.Visible = false;
            Button35.Visible = false;
            Panel_Check.Visible = false;
            UpdatePanel_Check.Update();
        }
        catch (Exception)
        {
            throw;
        }
    }
    //认证申请表
    protected void Gridview1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            DataRowView drv = (DataRowView)e.Row.DataItem;
            if (drv["PMSCA_State"].ToString().Trim() == "已提交" || drv["PMSCA_State"].ToString().Trim() == "技术副总审核驳回" || drv["PMSCA_State"].ToString().Trim() == "总经理审核驳回" || drv["PMSCA_State"].ToString().Trim() == "会签驳回")
            {
                e.Row.Cells[7].Enabled = true;
                e.Row.Cells[6].Enabled = true;
                e.Row.Cells[8].Enabled = true;
                e.Row.Cells[9].Enabled = false;
                e.Row.Cells[10].Enabled = false;
                e.Row.Cells[11].Enabled = false;
                e.Row.Cells[12].Enabled = true;//选择审核部门
            }
            //if (drv["PMSCA_State"].ToString().Trim() != "已提交")
            //{
            //    e.Row.Cells[7].Enabled = false;
            //    e.Row.Cells[6].Enabled = false;
            //    e.Row.Cells[8].Enabled = false;
            //    e.Row.Cells[9].Enabled = false;
            //    e.Row.Cells[10].Enabled = false;
            //    e.Row.Cells[11].Enabled = false;
            //}
            if (drv["PMSCA_State"].ToString().Trim() == "认证中")
            {
                e.Row.Cells[8].Enabled =true;
                e.Row.Cells[6].Enabled = false;
                e.Row.Cells[7].Enabled = false;
                e.Row.Cells[9].Enabled = false;
                e.Row.Cells[10].Enabled = false;
                e.Row.Cells[11].Enabled = false;
                e.Row.Cells[12].Enabled = false;//选择审核部门
            }
            if (drv["PMSCA_State"].ToString().Trim() == "会签通过")
            {
                e.Row.Cells[6].Enabled = false;
                e.Row.Cells[7].Enabled = false;
                e.Row.Cells[8].Enabled = false;
                e.Row.Cells[9].Enabled = false;
                e.Row.Cells[11].Enabled = false;
                e.Row.Cells[10].Enabled = true;
                e.Row.Cells[12].Enabled = false;//选择审核部门
            }
            if (drv["PMSCA_State"].ToString().Trim() == "技术副总审核通过")
            {
                e.Row.Cells[6].Enabled = false;//编辑
                e.Row.Cells[7].Enabled = false;//删除
                e.Row.Cells[8].Enabled = false;//认证
                e.Row.Cells[9].Enabled = false;//会签
                e.Row.Cells[10].Enabled = false;//技术副总审核
                e.Row.Cells[11].Enabled = true;//总经理审核
                e.Row.Cells[12].Enabled = false;//选择审核部门
            }
            if (drv["PMSCA_State"].ToString().Trim() == "总经理审核通过" || drv["PMSCA_State"].ToString().Trim() == "总经理审核驳回")
            {
                e.Row.Cells[10].Enabled = false;
                e.Row.Cells[7].Enabled = false;
                e.Row.Cells[12].Enabled = false;//选择审核部门
            }

            if (drv["PMSCA_State"].ToString().Trim() == "认证完成" || drv["PMSCA_State"].ToString().Trim() == "会签中")
            {
                e.Row.Cells[8].Enabled = false;
                e.Row.Cells[6].Enabled = false;
                e.Row.Cells[7].Enabled = false;
                e.Row.Cells[9].Enabled = true;
                e.Row.Cells[10].Enabled = false;
                e.Row.Cells[11].Enabled = false;
                e.Row.Cells[12].Enabled = false;//选择审核部门
            }


        }
    }

    //会签通过
    protected void Button1_ComFED(object sender, EventArgs e)
    {
        try
        {
            //if (Session["UserRole"].ToString().Contains("工程部供应商认证会签"))
            //{
            PMSupplyCertificinfo.PMSCAC_SignOpinion = TextBox15.Text;
            PMSupplyCertificinfo.PMSCAC_SignResult = "通过";
            PMSupplyCertificinfo.PMSCAC_SignMan = Session["UserName"].ToString();
            PMSupplyCertificinfo.PMSCAC_ID = new Guid(Label_PMSCAC_ID.Text.ToString());
            PMSupplyCertificinfo.PMSCA_CertificApplyNum = new Guid(label_CertificApplyNum.Text);
            pc.UpdatePMSupplyCertificApplyCountersign(PMSupplyCertificinfo);
            //}
            Button22.Visible = true;
            Button23.Visible = true;
            Button24.Visible = true;
            Button30.Visible = false;
            label31.Visible = false;
            Label32.Visible = false;
            label33.Visible = false;
            label34.Visible = false;
            TextBox15.Text = "";
            Panel4.Visible = false;
            UpdatePanel2.Update();
            int itt = 0;
            PMSupplyCertificinfo.PMSCA_CertificApplyNum = new Guid(label_CertificApplyNum.Text);
            BindGridview4(PMSupplyCertificinfo);
            UpdatePanel_Sign.Update();

            //}
            //if (Session["UserRole"].ToString().Contains("生产部供应商认证会签"))
            //{
            //    PMSupplyCertificinfo.PMSCA_PDSignOpinion = this.TextBox15.Text;
            //    PMSupplyCertificinfo.PMSCA_PDSignResult = "通过";
            //    PMSupplyCertificinfo.PMSCA_PDSignMan = Session["UserName"].ToString();

            //    PMSupplyCertificinfo.PMSCA_CertificApplyNum = new Guid(this.label_CertificApplyNum.Text);
            //    pc.InsertPMSCA_PDSign(PMSupplyCertificinfo);

            //}
            //if (Session["UserRole"].ToString().Contains("品保部供应商认证会签"))
            //{
            //    PMSupplyCertificinfo.PMSCA_QASignOpinion = this.TextBox15.Text;
            //    PMSupplyCertificinfo.PMSCA_QASignResult = "通过";
            //    PMSupplyCertificinfo.PMSCA_QASignMan = Session["UserName"].ToString();

            //    PMSupplyCertificinfo.PMSCA_CertificApplyNum = new Guid(this.label_CertificApplyNum.Text);
            //    pc.InsertPMSCA_QASign(PMSupplyCertificinfo);

            //}
            //PMSupplyCertificinfo.PMSCA_CertificApplyNum = new Guid(this.label_CertificApplyNum.Text);
            //DataSet dss = pc.SelectPMSupplyCertificApply_One(PMSupplyCertificinfo);
            //DataTable dtt = dss.Tables[0];
            //if (dtt.Rows.Count > 0)
            //{
            //    this.label_QAHQ.Text = dtt.Rows[0][6].ToString();
            //    this.label_PDHQ.Text = dtt.Rows[0][10].ToString();
            //    this.label_EDHQ.Text = dtt.Rows[0][14].ToString();
            //}
           
            for (int i = 0; i < Gridview4.Rows.Count;i++ )
            {
               
               if(Gridview4.Rows[i].Cells[2].Text=="通过")
               {
                   itt = itt + 1;
               }
               if (Gridview4.Rows[i].Cells[2].Text == "驳回")
                {
                    itt = -1;
                }
            }
            if (itt==Gridview4.Rows.Count)
            { 
                PMSupplyCertificinfo.PMSCA_CertificApplyNum = new Guid(label_CertificApplyNum.Text);
                PMSupplyCertificinfo.PMSCA_State = "会签通过";
                pc.UpdatePMSCA_State(PMSupplyCertificinfo);
                BindGridView1("");
                Panel2_Approve.Visible = true;
                UpdatePanel2_Approve.Update();

                label_RTX1.Text = "ERP系统信息：" + Gridview1.Rows[Gridview1.SelectedIndex].Cells[2].Text.ToString() + "和" + Gridview1.Rows[Gridview1.SelectedIndex].Cells[3].Text.ToString() + "的认证申请单" + "于" + DateTime.Now + "完成会签，请审核。";
               string message = label_RTX1.Text;
                  string sErr=RTXhelper.Send(message, "技术副总供应商认证审核");
                if (!string.IsNullOrEmpty(sErr))
                {
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
                }
            }
            if (itt != -1 && itt != Gridview4.Rows.Count)
            {
                PMSupplyCertificinfo.PMSCA_CertificApplyNum = new Guid(label_CertificApplyNum.Text);
                PMSupplyCertificinfo.PMSCA_State = "会签中";
                pc.UpdatePMSCA_State(PMSupplyCertificinfo);
                BindGridView1("");
                Panel2_Approve.Visible = true;
                UpdatePanel2_Approve.Update();
            }
           
            Panel4.Visible = false;
            //this.Panel5.Visible = false;

            UpdatePanel2.Update();
        }
        catch (Exception)
        {
            throw;
        }
    }
    //会签取消
    protected void Button_CancelFED(object sender, EventArgs e)
    {
        try
        {
            Button22.Visible = true;
            Button23.Visible = true;
            Button24.Visible = true;
            Button30.Visible = false;
            label31.Visible = false;
            Label32.Visible = false;
            label33.Visible = false;
            label34.Visible = false;
            TextBox15.Text = "";
            Panel4.Visible = false;
            UpdatePanel2.Update();
        }
        catch (Exception)
        {
            throw;
        }
    }
    //会签驳回
    protected void Button1_BHED(object sender, EventArgs e)
    {
        try
        {
            //if (Session["UserRole"].ToString().Contains("工程部供应商认证会签"))
            //{
                PMSupplyCertificinfo.PMSCAC_SignOpinion = TextBox15.Text;
                PMSupplyCertificinfo.PMSCAC_SignResult = "驳回";
                PMSupplyCertificinfo.PMSCAC_SignMan = Session["UserName"].ToString();
                PMSupplyCertificinfo.PMSCAC_ID = new Guid(Label_PMSCAC_ID.Text.ToString());
                PMSupplyCertificinfo.PMSCA_CertificApplyNum = new Guid(label_CertificApplyNum.Text);
                pc.UpdatePMSupplyCertificApplyCountersign(PMSupplyCertificinfo);
            //}
                Button22.Visible = true;
                Button23.Visible = true;
                Button24.Visible = true;
                Button30.Visible = false;
                label31.Visible = false;
                Label32.Visible = false;
                label33.Visible = false;
                label34.Visible = false;
                TextBox15.Text = "";
                Panel4.Visible = false;
                UpdatePanel2.Update();
                PMSupplyCertificinfo.PMSCA_CertificApplyNum = new Guid(label_CertificApplyNum.Text);
                BindGridview4(PMSupplyCertificinfo);
                UpdatePanel_Sign.Update();
            //if (Session["UserRole"].ToString().Contains("品保部供应商认证会签"))
            //{
            //    PMSupplyCertificinfo.PMSCA_QASignOpinion = this.TextBox15.Text;
            //    PMSupplyCertificinfo.PMSCA_QASignResult = "驳回";
            //    PMSupplyCertificinfo.PMSCA_QASignMan = Session["UserName"].ToString();

            //    PMSupplyCertificinfo.PMSCA_CertificApplyNum = new Guid(this.label_CertificApplyNum.Text);
            //    pc.InsertPMSCA_QASign(PMSupplyCertificinfo);

            //}
            //if (Session["UserRole"].ToString().Contains("生产部供应商认证会签"))
            //{
            //    PMSupplyCertificinfo.PMSCA_PDSignOpinion = this.TextBox15.Text;
            //    PMSupplyCertificinfo.PMSCA_PDSignResult = "驳回";
            //    PMSupplyCertificinfo.PMSCA_PDSignMan = Session["UserName"].ToString();

            //    PMSupplyCertificinfo.PMSCA_CertificApplyNum = new Guid(this.label_CertificApplyNum.Text);
            //    pc.InsertPMSCA_PDSign(PMSupplyCertificinfo);
            //}
            //PMSupplyCertificinfo.PMSCA_CertificApplyNum = new Guid(this.label_CertificApplyNum.Text);
            //DataSet dss = pc.SelectPMSupplyCertificApply_One(PMSupplyCertificinfo);
            //DataTable dtt = dss.Tables[0];
            //if (dtt.Rows.Count > 0)
            //{
            //    this.label_QAHQ.Text = dtt.Rows[0][6].ToString();
            //    this.label_PDHQ.Text = dtt.Rows[0][10].ToString();
            //    this.label_EDHQ.Text = dtt.Rows[0][14].ToString();
            //}
            //if (this.label_EDHQ.Text == "驳回" || this.label_PDHQ.Text == "驳回" || this.label_QAHQ.Text == "驳回")
            //{
            PMSupplyCertificinfo.PMSCA_CertificApplyNum = new Guid(label_CertificApplyNum.Text);
            PMSupplyCertificinfo.PMSCA_State = "会签驳回";
            pc.UpdatePMSCA_State(PMSupplyCertificinfo);
            BindGridView1("");
            Panel2_Approve.Visible = true;
            UpdatePanel2_Approve.Update();
            //}
            Panel4.Visible = false;
            //this.Panel5.Visible = false;
            UpdatePanel2.Update();
            label_RTX_P.Text = "ERP系统信息：" +Session["UserName"].ToString()+"于"+DateTime.Now+"驳回"+ Gridview1.Rows[Gridview1.SelectedIndex].Cells[2].Text.ToString() + "和" + Gridview1.Rows[Gridview1.SelectedIndex].Cells[3].Text.ToString() + "的认证申请单，请查看";
            string message = label_RTX_P.Text;
            string dep = Gridview1.Rows[Gridview1.SelectedIndex].Cells[1].Text.ToString();
            string sErr = RTXhelper.SendbyDepAndRole(message, dep, "供应商认证申请");
            if (!string.IsNullOrEmpty(sErr))
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    #region// 换页

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
        string condition = GetCondition_Org();
        BindGridview3(condition);

        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview3.PageCount ? Gridview3.PageCount - 1 : newPageIndex;
        Gridview3.PageIndex = newPageIndex;
        Gridview3.DataBind();
    }
    protected void Gridview5_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview5.BottomPagerRow;


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
        BindGridview5(condition);

        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview5.PageCount ? Gridview5.PageCount - 1 : newPageIndex;
        Gridview5.PageIndex = newPageIndex;
        Gridview5.DataBind();

    }
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
        BindGridView1(Condition);
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
        BindGridview_PMSupply("");
        Gridview_PMSupply.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview_PMSupply.PageCount ? Gridview_PMSupply.PageCount - 1 : newPageIndex;
        Gridview_PMSupply.PageIndex = newPageIndex;
        Gridview_PMSupply.DataBind();

    }

    protected void Gridview_Preserve_PageIndexChanging(object sender, GridViewPageEventArgs e)
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
        PMSupplyCertificinfo.PMSCA_CertificApplyNum = new Guid(label_CertificApplyNum.Text);
        BindGridView2(PMSupplyCertificinfo);
        Gridview2.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview2.PageCount ? Gridview2.PageCount - 1 : newPageIndex;
        Gridview2.PageIndex = newPageIndex;
        Gridview2.DataBind();

    }

    protected void Gridview_4_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview4.BottomPagerRow;


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
        PMSupplyCertificinfo.PMSCA_CertificApplyNum = new Guid(label_CertificApplyNum.Text);
        BindGridview4(PMSupplyCertificinfo);
        Gridview4.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview4.PageCount ? Gridview4.PageCount - 1 : newPageIndex;
        Gridview4.PageIndex = newPageIndex;
        Gridview4.DataBind();
    }
    #endregion
    //隐藏供应商ID
    protected void Gridview_PMSupply_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[1].Visible = false;
        }
    }
    #region//悬浮框
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
    protected void Gridview4_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Gridview4.Rows.Count; i++)
        {
            for (int j = 0; j < Gridview4.Rows[i].Cells.Count; j++)
            {
                Gridview4.Rows[i].Cells[j].ToolTip = Gridview4.Rows[i].Cells[j].Text;
                if (Gridview4.Rows[i].Cells[j].Text.Length > 15)
                {
                    Gridview4.Rows[i].Cells[j].Text = Gridview4.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }
            }
        }
    }
    protected void Gridview2_DataBound(object sender, EventArgs e)
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
    #endregion

    //检索供应商
    protected void Button1_KiMi(object sender, EventArgs e)
    {
        string condition = GetCondition_Supply();
        BindGridview_PMSupply(condition);
        UpdatePanel_Supply.Update();
    }
    protected string GetCondition_Supply()
    {
        string condition;
        string item = "";
        if (TextBox2.Text != "")
        {
            item += " and PMSI_SupplyNum='" + TextBox2.Text + "'";
        }
        if (TextBox5.Text != "")
        {
            item += " and PMSI_SupplyName  like'%" + TextBox5.Text + "%'";
        }
        condition = item;
        return condition;
    }
    //重置检索供应商
    protected void Button_CoMi(object sender, EventArgs e)
    {
        TextBox2.Text = "";
        TextBox5.Text = "";
        BindGridview_PMSupply("");
        UpdatePanel_Supply.Update();
    }
    //物料检索
    protected void Button1_KiM(object sender, EventArgs e)
    {
        string condition = GetCondition_Material();
        BindGridview5(condition);
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
        if (TextBox17.Text != "")
        {
            item += "and IMMBD_SpecificationModel like '%" + TextBox17.Text.ToString() + "%'";
        }
        condition = item;
        return condition;
    }
    //重置物料检索
    protected void Button_CoM(object sender, EventArgs e)
    {
        TextBox16.Text = "";
        TextBox17.Text = "";
        BindGridview5("");
        UpdatePanel_Material.Update();
    }
    //选择物料
    protected void Button_SelectM(object sender, EventArgs e)
    {
        BindGridview5("");
        Panel_Material.Visible = true;
        UpdatePanel_Material.Update();
    }
    protected void Button_Com1(object sender, EventArgs e)
    {
        bool temp = false;
        foreach (GridViewRow item in Gridview5.Rows)
        {
            RadioButton rb = item.FindControl("RadioButtonMarkup") as RadioButton;
            if (rb.Checked)
            {
                TextBox4.Text = Gridview5.Rows[item.RowIndex].Cells[1].Text.ToString();
                temp = true;
            } 
        }
        if (!temp)
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_Material, GetType(), "aa", "alert('请选择物料')", true);
            return;
        }
        else
        {
            UpdatePanel_Spl_New.Update();
            Panel_Material.Visible = false;
            UpdatePanel_Material.Update();
        }
    }
    //关闭物料查询框
    protected void Button_Cancel1(object sender, EventArgs e)
    {
        Panel_Material.Visible = false;
        UpdatePanel_Material.Update();
    }
    protected void Gridview5_RowDataBound(object sender, GridViewRowEventArgs e)
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
    private void ShowPanel()//显示上传实验报告框
    {
        string script = "document.getElementById('Div1').style.display='';";
        ScriptManager.RegisterStartupScript(Page, GetType(), "ShowPanel", script, true);
        TextBox18.Text = label_AccNum.Text;
        TextBox19.Text = label_AccName.Text;
        UpdatePanel4.Update();
    }

    private void ClosePanel()//关闭上传实验报告框
    {
        string script = "document.getElementById('Div1').style.display='none';";
        ScriptManager.RegisterStartupScript(Page, GetType(), "ClosePanel", script, true);
    }
    protected void Button_Aline(object sender, EventArgs e)
    {
        ShowPanel();
        UpdatePanel4.Update(); 
      
    }
    //提交上传附件
    protected void Button1_Fox(object sender, EventArgs e)
    {
        string fileExrensio = Path.GetExtension(FileUpload1.FileName).ToLower();//ToLower转化为小写,获得扩展名
        string UploadURL = Server.MapPath("~/file/");//上传的目录
        string fullname = FileUpload1.FileName;//上传文件的原名
        string newname = DateTime.Now.ToString("yyyyMMddhhmmss");//上传文件重命名

        if (FileUpload1.PostedFile.FileName != "" || FileUpload1.PostedFile.FileName != null)
        {
            if (fileExrensio == ".doc" || fileExrensio == ".docx" || fileExrensio == ".pdf" || fileExrensio == ".xls" || fileExrensio == ".xlsx" || fileExrensio == ".txt" || fileExrensio == ".ppt" || fileExrensio == ".pptx" || fileExrensio == ".rar" || fileExrensio == ".zip" || fileExrensio == ".bmp" || fileExrensio == ".jpg" || fileExrensio == ".gif")//判断文件扩展名
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
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel4, GetType(), "aa", "alert('上传失败!')", true);
                    return;
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel4, GetType(), "aa", "alert('不支持此文件格式!')", true);
                return;
            }
            string filePath = "file/" + newname + fullname;

            if (TextBox18.Text == "" || TextBox18.Text == "" || FileUpload1.PostedFile.FileName == "" || FileUpload1.PostedFile.FileName == null)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel4, GetType(), "aa", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            else
            {
                label_AccNum.Text = TextBox18.Text.ToString();
                label_AccName.Text = TextBox19.Text.ToString();
                Label_FilePath.Text = filePath;//相对路径
                LabelQ_SaveDirectory.Text = "上传";
                ClosePanel();
                UpdatePanel4.Update();
               

            }
        }
    }
    protected void Button1_Emi(object sender, EventArgs e)
    {
        TextBox18.Text = "";
        TextBox19.Text = "";
        ClosePanel();
        UpdatePanel4.Update();
    }
    protected void Gridview2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;
            if (drv["PMSCI_Accessory"].ToString().Trim() == "是")
            {
                e.Row.Cells[11].Enabled = true;
            }
            else
            {
                e.Row.Cells[11].Enabled = false;
            }

        }
    }
    //protected void Button_OrgSearch(object sender, EventArgs e)
    //{
    //    BindGridview3("");
    //    this.Panel_Org.Visible = true;
    //    this.UpdatePanel_Org.Update();
    //}

    //部门
    private void BindGridview3(string condition)
    {
        Gridview3.DataSource = pc.SelectPMSCAC_Organization(condition);
        Gridview3.DataBind();
    }
    //检索部门
    protected void Button1_Kil(object sender, EventArgs e)
    {
        string condition = GetCondition_Org();
        BindGridview3(condition);
        UpdatePanel_Org.Update();
    }
    protected string GetCondition_Org()
    {
        string item = "";
        string condition;
        if(TextBox22.Text!="")
        {
        item+="and BDOS_Name like'%"+TextBox22.Text+"%'";
        }
        condition = item;
        return condition;
    }
    //重置检索部门
    protected void Button_CoMl(object sender, EventArgs e)
    {
        TextBox22.Text = "";
        BindGridview3("");
        UpdatePanel_Org.Update();
    }
    //提交勾选的部门
    protected void Button_ComSPP(object sender, EventArgs e)
    {
        bool temp = false;
        bool tempp = false;
        foreach (GridViewRow item in Gridview3.Rows)
        {
             CheckBox rb = item.FindControl("CheckMarkup") as CheckBox;
            if (rb.Checked)
            {
                foreach (GridViewRow itemm in Gridview4.Rows)
                {
                if(Gridview3.Rows[item.RowIndex].Cells[2].Text.ToString()==itemm.Cells[1].Text.ToString())
                {
                    tempp = true;
                }
                }
                if (tempp)
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel_Org, GetType(), "aa", "alert('审核部门不能重复！')", true);
                    return;
                }
                else
                {
                    PMSupplyCertificinfo.PMSCA_CertificApplyNum = new Guid(label_CertificApplyNum.Text);
                    PMSupplyCertificinfo.PMSCAC_SignPartment = Gridview3.Rows[item.RowIndex].Cells[2].Text.ToString();
                    pc.InsertPMSupplyCertificApplyCountersign(PMSupplyCertificinfo);
                    temp = true;
                }
            }
        }
        if (!temp)
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_Org, GetType(), "aa", "alert('请选择部门')", true);
            return;
        }
        else
        {
            PMSupplyCertificinfo.PMSCA_CertificApplyNum = new Guid(label_CertificApplyNum.Text);
            BindGridview4(PMSupplyCertificinfo);
            //this.TextBox22.Text = this.Label_Org.Text.ToString();
            //this.UpdatePanel_Spl_New.Update();
            UpdatePanel_Sign.Update();
        }
    }
    //关闭部门查询
    protected void Button_CancelSPP(object sender, EventArgs e)
    {

        Panel_Org.Visible = false;
        UpdatePanel_Org.Update();
    }

    protected void Gridview4_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Myloo")//查看
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview4.SelectedIndex = row.RowIndex;
            Label_PMSCAC_ID.Text = e.CommandArgument.ToString();
            PMSupplyCertificinfo.PMSCAC_ID = new Guid(Label_PMSCAC_ID.Text);
           DataSet ds=pc.SelectPMSupplyCertificApplyCountersign_One(PMSupplyCertificinfo);
           DataTable dt = ds.Tables[0];
           label31.Visible = true;
           Label32.Visible = true;
           label33.Visible = true;
           label34.Visible = true;
           
            if(dt.Rows.Count>0)
            {
                label35.Text = dt.Rows[0][2].ToString()+"会签意见：";
                label31.Text = dt.Rows[0][3].ToString();
                label33.Text = dt.Rows[0][5].ToString();
                label34.Text = dt.Rows[0][6].ToString();
                TextBox15.Text = dt.Rows[0][4].ToString();
            }
            Button22.Visible = false;
            Button23.Visible = false;
            Button24.Visible = false;
            Button30.Visible = true;
            Panel4.Visible = true;
            UpdatePanel2.Update();
        }
        if (e.CommandName == "Mylloo")//会签
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview4.SelectedIndex = row.RowIndex;
            Button30.Visible = false;
            Label_PMSCAC_ID.Text = e.CommandArgument.ToString();
            if (Session["Department"].ToString() == Gridview4.Rows[Gridview4.SelectedIndex].Cells[1].Text.ToString())
            {
                label35.Text = Session["Department"].ToString()+"会签意见：";
                Panel4.Visible = true;
                UpdatePanel2.Update();

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "aa", "alert('你没有此权限！')", true);
                return;
            }
        }
        if(e.CommandName=="Reco")//删除
        {
          GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview4.SelectedIndex = row.RowIndex;
            Label_PMSCAC_ID.Text = e.CommandArgument.ToString();
            PMSupplyCertificinfo.PMSCAC_ID = new Guid(Label_PMSCAC_ID.Text.ToString());
            pc.DeletePMSupplyCertificApplyCountersign(PMSupplyCertificinfo);
            PMSupplyCertificinfo.PMSCA_CertificApplyNum = new Guid(label_CertificApplyNum.Text);
            BindGridview4(PMSupplyCertificinfo);
            UpdatePanel_Sign.Update();
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "aa", "alert('删除成功！')", true);
        }
    }
    //关闭查看会签
    protected void Button_CancelFEDD(object sender, EventArgs e)
    {
        Button22.Visible = true;
        Button23.Visible = true;
        Button24.Visible = true;
        Button30.Visible = false;
        label31.Visible = false;
        Label32.Visible = false;
        label33.Visible = false;
        label34.Visible = false;
        TextBox15.Text = "";
        Panel4.Visible = false;
        UpdatePanel2.Update();
    }
    protected void Button_Closes(object sender, EventArgs e)
    {
        label_PRMP_DesignMangCheckResult.Visible = false;
        Label17.Visible = false;
        label_PRMP_DesignMangName.Visible = false;
        label_Time.Visible = false;
        label19.Visible = false;
        Label20.Visible = false;
        label21.Visible = false;
        label22.Visible = false;
        label_Opinion.Visible = false;
        label_XZ1.Visible = false;
        TextBox14.Visible = false;
        Button35.Visible = false;
        Panel_Check.Visible = false;
        UpdatePanel_Check.Update();
        Panel4.Visible = false;
        UpdatePanel2.Update();
        Panel_Sign.Visible = false;
        UpdatePanel_Sign.Update();
    }


    protected void Button_Ccl(object sender, EventArgs e)
    {
        Panel_Org.Visible = false;
        UpdatePanel_Org.Update();
        Panel_Sign.Visible = false;
        UpdatePanel_Sign.Update();
    }
    protected void Gridview4_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;
            if (drv["PMSCAC_SignResult"].ToString().Trim() != "")
            {
                e.Row.Cells[8].Enabled = false;
            }
        }
    }
}

