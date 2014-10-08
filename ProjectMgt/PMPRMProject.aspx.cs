using System;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using RTXHelper;

public partial class ProjectManagement_PMPRMProject : Page
{
    PMSupplyCertificL pc = new PMSupplyCertificL();
    PRMProjectL prmp = new PRMProjectL();
    PRMProjectinfo PRMProjectinfo = new PRMProjectinfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            ClosePanel();
            label_pagestate.Text = Request.QueryString["state"];
            string state = label_pagestate.Text;
            if (state == "Supply")
            {
                Title = "项目申请";
                Gridview_ProjectInfo.Columns[10].Visible = false;
                Gridview_ProjectInfo.Columns[11].Visible = false;
                Gridview_ProjectInfo.Columns[12].Visible = false;
                Gridview_ProjectInfo.Columns[16].Visible = false;//上传计划书
                Gridview_ProjectInfo.Columns[17].Visible = false;
                Gridview_ProjectInfo.Columns[18].Visible = false;
                Gridview_ProjectInfo.Columns[19].Visible = false;
                Gridview_ProjectInfo.Columns[20].Visible = false;
                Gridview_ProjectInfo.Columns[21].Visible = false;
                Gridview_ProjectInfo.Columns[22].Visible = false;//上传材料
                Gridview_ProjectInfo.Columns[23].Visible = false;//查看验收意见
                //this.Gridview_ProjectInfo.Columns[24].Visible = false;//查看计划书审核意见
            }
            if (state == "Material")
            { 
                Title = "项目材料维护";
                Gridview_ProjectInfo.Columns[9].Visible = false;
                Gridview_ProjectInfo.Columns[10].Visible = false;
                Gridview_ProjectInfo.Columns[11].Visible = false;
                Gridview_ProjectInfo.Columns[12].Visible = false;
                Gridview_ProjectInfo.Columns[14].Visible = false;
                //this.Gridview_ProjectInfo.Columns[16].Visible = false;//上传计划书
                Gridview_ProjectInfo.Columns[17].Visible = false;
                Gridview_ProjectInfo.Columns[18].Visible = false;
                Gridview_ProjectInfo.Columns[19].Visible = false;
                Gridview_ProjectInfo.Columns[20].Visible = false;
                Gridview_ProjectInfo.Columns[21].Visible = false;//项目批准
               
                Gridview_ProjectInfo.Columns[23].Visible = false;//查看验收意见
                //this.Gridview_ProjectInfo.Columns[24].Visible = false;//查看计划书审核意见
            }
            if (state == "Check")
            {
                Title = "项目审核";
                Gridview_ProjectInfo.Columns[9].Visible = false;
                Gridview_ProjectInfo.Columns[14].Visible = false;//删除
                Gridview_ProjectInfo.Columns[16].Visible = false;//上传计划书
                Gridview_ProjectInfo.Columns[17].Visible = false;//上传验收报告
                Gridview_ProjectInfo.Columns[18].Visible = false;//验收审核
                Gridview_ProjectInfo.Columns[19].Visible = false;//验收会签
                Gridview_ProjectInfo.Columns[20].Visible = false;//选择验收部门
                Gridview_ProjectInfo.Columns[21].Visible = false;//项目批准
                Gridview_ProjectInfo.Columns[22].Visible = false;//上传材料
                Gridview_ProjectInfo.Columns[23].Visible = false;//查看验收意见
                Gridview_ProjectInfo.Columns[24].Visible = false;//查看计划书审核意见
                Button2.Visible = false;
                //this.Gridview_ProjectInfo.Columns[13].Visible = false;
                if (Session["UserRole"].ToString().Contains("技术副总项目审核"))
                {
                    Gridview_ProjectInfo.Columns[11].Visible = false;
                    Gridview_ProjectInfo.Columns[12].Visible = false;
                }
                if (Session["UserRole"].ToString().Contains("总经理项目审核"))
                {
                    Gridview_ProjectInfo.Columns[10].Visible = false;
                    Gridview_ProjectInfo.Columns[11].Visible = false;
                }
                if (Session["UserRole"].ToString().Contains("财务部项目审核"))
                {
                    Gridview_ProjectInfo.Columns[10].Visible = false;
                    Gridview_ProjectInfo.Columns[12].Visible = false;
                }
                Gridview2.Columns[5].Visible = false;//编辑
                Gridview2.Columns[6].Visible = false;//删除
            }
            if (state == "Accept")
            {
                Title = "项目验收报告提交";
                Gridview_ProjectInfo.Columns[9].Visible = false;
                Gridview_ProjectInfo.Columns[10].Visible = false;
                Gridview_ProjectInfo.Columns[11].Visible = false;
                Gridview_ProjectInfo.Columns[12].Visible = false;
                //this.Gridview_ProjectInfo.Columns[13].Visible = false;
                Gridview_ProjectInfo.Columns[14].Visible = false;//删除
                //this.Gridview_ProjectInfo.Columns[15].Visible = false;
                Gridview_ProjectInfo.Columns[16].Visible = false;//上传计划书
                //this.Gridview_ProjectInfo.Columns[17].Visible = false;//上传验收报告
                Gridview_ProjectInfo.Columns[18].Visible = false;//验收审核
                Gridview_ProjectInfo.Columns[19].Visible = false;//验收会签
                //this.Gridview_ProjectInfo.Columns[20].Visible = false;//选择验收部门
                Gridview_ProjectInfo.Columns[21].Visible = false;//项目批准
                Gridview_ProjectInfo.Columns[22].Visible = false;//上传材料
                Gridview_ProjectInfo.Columns[23].Visible = false;//查看验收意见
                Gridview_ProjectInfo.Columns[24].Visible = false;//查看计划书审核意见
                Gridview2.Columns[5].Visible = false;//编辑
                Gridview2.Columns[6].Visible = false;//删除
                Gridview4.Columns[8].Visible = true;
            }
            if (state == "AcceptCheck")
            {
                Title = "项目验收审核";
                Gridview_ProjectInfo.Columns[9].Visible = false;
                Gridview_ProjectInfo.Columns[10].Visible = false;
                Gridview_ProjectInfo.Columns[11].Visible = false;
                Gridview_ProjectInfo.Columns[12].Visible = false;
                Gridview_ProjectInfo.Columns[13].Visible = false;
                Gridview_ProjectInfo.Columns[14].Visible = false;//删除
                Gridview_ProjectInfo.Columns[15].Visible = false;
                Gridview_ProjectInfo.Columns[16].Visible = false;//上传计划书
                Gridview_ProjectInfo.Columns[17].Visible = false;//上传验收报告
                //this.Gridview_ProjectInfo.Columns[18].Visible = false;//验收审核
                //this.Gridview_ProjectInfo.Columns[19].Visible = false;//验收会签
                Gridview_ProjectInfo.Columns[20].Visible = false;//选择验收部门
                Gridview_ProjectInfo.Columns[21].Visible = false;//项目批准
                Gridview_ProjectInfo.Columns[22].Visible = false;//上传材料
                Gridview_ProjectInfo.Columns[24].Visible = false;//查看计划书审核意见
                Gridview2.Columns[5].Visible = false;//编辑
                Gridview2.Columns[6].Visible = false;//删除
                Gridview4.Columns[8].Visible = false;
            }
            if (state == "Approval")
            {
                Title = "项目批准";
                Gridview_ProjectInfo.Columns[9].Visible = false;
                Gridview_ProjectInfo.Columns[10].Visible = false;
                Gridview_ProjectInfo.Columns[11].Visible = false;
                Gridview_ProjectInfo.Columns[12].Visible = false;
                Gridview_ProjectInfo.Columns[13].Visible = false;
                Gridview_ProjectInfo.Columns[14].Visible = false;//删除
                Gridview_ProjectInfo.Columns[15].Visible = false;
                Gridview_ProjectInfo.Columns[16].Visible = false;//上传计划书
                Gridview_ProjectInfo.Columns[17].Visible = false;//上传验收报告
                Gridview_ProjectInfo.Columns[18].Visible = false;//验收审核
                Gridview_ProjectInfo.Columns[19].Visible = false;//验收会签
                Gridview_ProjectInfo.Columns[20].Visible = false;//选择验收部门
                //this.Gridview_ProjectInfo.Columns[21].Visible = false;//项目批准
                Gridview_ProjectInfo.Columns[22].Visible = false;//上传材料
                Gridview_ProjectInfo.Columns[24].Visible = false;//查看计划书审核意见
                Gridview2.Columns[5].Visible = false;//编辑
                Gridview2.Columns[6].Visible = false;//删除
                Gridview4.Columns[8].Visible = false;
            }
            if (!(Session["UserRole"].ToString().Contains("项目申请管理") || Session["UserRole"].ToString().Contains("项目审核")||Session["UserRole"].ToString().Contains("项目批准")||Session["UserRole"].ToString().Contains("项目验收审核")||Session["UserRole"].ToString().Contains("项目验收会签")))
            {
                Response.Redirect("~/Default.aspx");
            }
            UpdatePanel_ProjectSearch.Visible = true;
            BindGridView_Projectinfo("");
            UpdatePanel_ProjectInfo.Visible = true;
            UpdatePanel_ProjectInfo.Update();
        }
    }
    private void BindGridView_Projectinfo(string Condition)
    {
        try
        {
            Gridview_ProjectInfo.DataSource = prmp.SelectPRMProject(Condition);
            Gridview_ProjectInfo.DataBind();
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
            UpdatePanel_ProjectInfo.Visible = true;
            UpdatePanel_ProjectInfo.Update();
            Panel_NewProjectInfo.Visible = false;
            UpdatePanel_NewProjectInfo.Update();
            Panel_ProductMode.Visible = false;
            UpdatePanel_ProductMode.Update();
            Panel1_Check.Visible = false;
            UpdatePanel1_Check.Update();
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
            if (TextBox1.Text.ToString() != "")
            {
                item += "and PRMP_ProductMode ='" + TextBox1.Text.ToString() + "'";
            }
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
    //新增项目
    protected void Button2_Nw(object sender, EventArgs e)
    {
        try
        {
        
            Panel_ProductMode.Visible = false;
            UpdatePanel_ProductMode.Update();
            label_Change.Text = "新增项目";
            label_XG.Text = "新增项目";
            TextBox3.Text = "";
            TextBox2.Enabled = true;
            DropDownList3.SelectedValue = "请选择";
            DropDownList2.SelectedValue = "请选择";
            TextBox2.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            Panel_NewProjectInfo.Visible = true;
            UpdatePanel_NewProjectInfo.Update();
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
            UpdatePanel_ProjectInfo.Visible = true;
            UpdatePanel_ProjectInfo.Update();
            TextBox1.Text = "";
            DropDownList1.SelectedValue = "请选择";
            ProjectName.Text = "";
            ProjectNum.Text = "";
        }
        catch (Exception)
        {
            throw;
        }
    }
    //审核
    protected void Gridview_ProjectInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Change")//修改项目
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview_ProjectInfo.SelectedIndex = row.RowIndex;
            //this.label_AccState.Text = "申请材料";
            Panel_ProductMode.Visible = false;
            UpdatePanel_ProductMode.Update();
            label_supplytypeid.Text = Convert.ToString(e.CommandArgument);
            label_XG.Text = "修改项目";
            TextBox2.Enabled = false;
            Guid ls = new Guid(label_supplytypeid.Text);
            DataSet ds = prmp.SelectPRMProject_One(ls);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                label_PNum.Text = dt.Rows[0][1].ToString();
                TextBox3.Text = dt.Rows[0][3].ToString();
                DropDownList3.SelectedValue = dt.Rows[0][4].ToString();
                DropDownList2.SelectedValue = dt.Rows[0][5].ToString();
                TextBox2.Text = dt.Rows[0][2].ToString();
                TextBox4.Text = dt.Rows[0][6].ToString();
                TextBox5.Text = dt.Rows[0][7].ToString();
            }
            
            label_Change.Text = label_PNum.Text + "  " + TextBox2.Text + "  " + "修改";
            Panel_NewProjectInfo.Visible = true;
            UpdatePanel_NewProjectInfo.Update();
        }

        if (e.CommandName == "Check1")//技术副总审核
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview_ProjectInfo.SelectedIndex = row.RowIndex;
            if (Gridview_ProjectInfo.Rows[row.RowIndex].Cells[8].Text == "已提交")
            {
                label_Coutersign.Text = "技术副总初审";
            }
            else
            {
                label_Coutersign.Text = "技术副总审核";
            }
            Label8.Visible = false;
            Label14.Visible = false;
            Label19.Visible = false;
            Label39.Visible = false;
            Panel1_Check.Visible = true;
            UpdatePanel1_Check.Update();
            TextBox9.Visible = false;
            TextBox6.Visible = false;
            Button4.Visible = false;
            Button5.Visible = false;
            Button11.Visible = false;
            TextBox8.Enabled = true;
            Button8.Visible = true;
            Button10.Visible = true;
            Button9.Visible = true;
            label20.Visible = false;
            Label21.Visible = false;
            label22.Visible = false;
            label23.Visible = false;
            Button16.Visible = false;
            Label31.Visible = false;
            Label30.Visible = true;
            Label32.Visible = false;
            label33.Visible = false;
            Label34.Visible = false;
            label35.Visible = false;
            label36.Visible = false;
            Label37.Visible = false;
            Label38.Visible = false;
            Button17.Visible = false;
            Button19.Visible = false;
            Button20.Visible = false;
            label_supplytypeid.Text = Convert.ToString(e.CommandArgument);
            Guid ls = new Guid(label_supplytypeid.Text);
            DataSet ds = prmp.SelectPRMProject_One(ls);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                label_PNum.Text = dt.Rows[0][1].ToString();
                label_PName.Text = dt.Rows[0][2].ToString();
            }

            label_DMCheck.Text = label_PNum.Text + "  " + label_PName.Text + "  " + "审核";

            UpdatePanel1_Check.Update();
        }
        
        if (e.CommandName == "CFOCheck")//财务总监审核
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview_ProjectInfo.SelectedIndex = row.RowIndex;
            Button16.Visible = false;
            Label8.Visible = false;
            Label14.Visible =false ;
            Label19.Visible = false ;
            Panel1_Check.Visible = true;
            UpdatePanel1_Check.Update();
            label_PRMP_DesignMangCheckResult.Visible = true;
            TextBox8.Enabled = false;
            Button8.Visible = false;
            Button10.Visible = false;
            Button9.Visible = false;
            TextBox9.Visible = false;
            TextBox9.Enabled = true;
            Button4.Visible =false ;
            Button5.Visible =false ;
            Button11.Visible =false ;
            label20.Visible = false;
            Label21.Visible = false;
            label22.Visible = false;
            label23.Visible = false;
            Label31.Visible = true;
            Label30.Visible =false;
            Label32.Visible = true;
            Label37.Visible = true;
            Label38.Visible = true;
            label33.Visible = false;
            Label34.Visible = false;
            label35.Visible = false;
            label36.Visible = false;
            TextBox6.Visible = true;
            TextBox6.Enabled = true;
            Button17.Visible = true;
            Button19.Visible = true;
            Button20.Visible = true;
            label1_PanelSupply.Visible = true;
            label_PRMP_DesignMangName.Visible = true;
            Label10.Visible = true;
            label_supplytypeid.Text = Convert.ToString(e.CommandArgument);
            Guid dmco = new Guid(label_supplytypeid.Text);
            String condition = "and PRMP_ID='" + dmco + "'" + "and PRMPD_DesignMangCheckSate='"+"申请审核"+"'";
            DataSet Ds = prmp.SelectProjectCheck(condition);
            DataTable Dt = Ds.Tables[0];
            if (Ds.Tables[0].Rows.Count > 0)
            {
                TextBox8.Text = Dt.Rows[0][3].ToString();
                label1_PanelSupply.Text = Dt.Rows[0][4].ToString();
                label_PRMP_DesignMangCheckResult.Text = Dt.Rows[0][2].ToString();
                label_PRMP_DesignMangName.Text = Dt.Rows[0][6].ToString();
            }
            DataSet ds = prmp.SelectPRMProject_One(dmco);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                label_PNum.Text = dt.Rows[0][1].ToString();
                label_PName.Text = dt.Rows[0][2].ToString();
            }

            label_DMCheck.Text = label_PNum.Text + "  " + label_PName.Text + "  " + "审核";
            UpdatePanel1_Check.Update();

        }
        if (e.CommandName == "Check2")//总经理审核
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview_ProjectInfo.SelectedIndex = row.RowIndex;
            Button16.Visible = false;
            Label8.Visible = true;
            Label14.Visible = true;
            Label19.Visible = true;
            Panel1_Check.Visible = true;
            UpdatePanel1_Check.Update();
            label_PRMP_DesignMangCheckResult.Visible = true;
            TextBox8.Enabled = false;
            Button8.Visible = false;
            Button10.Visible = false;
            Button9.Visible = false;
            TextBox9.Visible = true;
            TextBox9.Enabled = true;
            Button4.Visible = true;
            Button5.Visible = true;
            Button11.Visible = true;
            label20.Visible = false;
            Label21.Visible = false;
            label22.Visible = false;
            label23.Visible = false;
            Label31.Visible = true;
            Label30.Visible = false;
            Label39.Visible = false;
            Label32.Visible = true;
            Label37.Visible = true;
            Label38.Visible = true;
            label33.Visible = true;
            Label34.Visible = true;
            label35.Visible = true;
            label36.Visible = true;
            TextBox6.Visible = true;
            TextBox6.Enabled = false;
            Button17.Visible = false;
            Button19.Visible =false;
            Button20.Visible = false;

            label1_PanelSupply.Visible = true;
            label_PRMP_DesignMangName.Visible = true;
            Label10.Visible = true;
            label_supplytypeid.Text = Convert.ToString(e.CommandArgument);
            Guid dmco = new Guid(label_supplytypeid.Text);
            String condition = "and PRMP_ID='" + dmco + "'" + "and PRMPD_DesignMangCheckSate='" + "申请审核" + "'";
            DataSet Ds = prmp.SelectProjectCheck(condition);
            DataTable Dt = Ds.Tables[0];
            if (Ds.Tables[0].Rows.Count > 0)
            {
                TextBox8.Text = Dt.Rows[0][3].ToString();
                label1_PanelSupply.Text = Dt.Rows[0][4].ToString();
                label_PRMP_DesignMangCheckResult.Text = Dt.Rows[0][2].ToString();
                label_PRMP_DesignMangName.Text = Dt.Rows[0][6].ToString();
            }
            DataSet ds = prmp.SelectPRMProject_One(dmco);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                label_PNum.Text = dt.Rows[0][1].ToString();
                label_PName.Text = dt.Rows[0][2].ToString();
                label33.Text=dt.Rows[0][14].ToString();
                label35.Text = dt.Rows[0][17].ToString();
                label36.Text = dt.Rows[0][16].ToString();
                TextBox6.Text = dt.Rows[0][15].ToString();
            }
            
            label_DMCheck.Text = label_PNum.Text + "  " + label_PName.Text + "  " + "审核";
            UpdatePanel1_Check.Update();

        }
        if (e.CommandName == "CLook")//查看审核
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview_ProjectInfo.SelectedIndex = row.RowIndex;
            label_supplytypeid.Text = Convert.ToString(e.CommandArgument);
            Guid dmco = new Guid(label_supplytypeid.Text);
            String condition = "and PRMP_ID='" + dmco + "'" + "and PRMPD_DesignMangCheckSate='" + "申请审核" + "'";
            DataSet Dss = prmp.SelectProjectCheck(condition);
            DataTable Dtt = Dss.Tables[0];
            if (Dss.Tables[0].Rows.Count > 0)
            {
                TextBox8.Text = Dtt.Rows[0][3].ToString();
                label1_PanelSupply.Text = Dtt.Rows[0][4].ToString();
                label_PRMP_DesignMangCheckResult.Text = Dtt.Rows[0][2].ToString();
                label_PRMP_DesignMangName.Text = Dtt.Rows[0][6].ToString();
            }

            DataSet Ds = prmp.SelectPRMProject_One(dmco);
            DataTable Dt = Ds.Tables[0];
            if (Ds.Tables[0].Rows.Count > 0)
            {
                label_PNum.Text = Dt.Rows[0][1].ToString();
                label_PName.Text =Dt.Rows[0][2].ToString();
                label33.Text = Dt.Rows[0][14].ToString();
                label35.Text = Dt.Rows[0][17].ToString();
                label36.Text = Dt.Rows[0][16].ToString();
                TextBox6.Text = Dt.Rows[0][15].ToString();

                TextBox9.Text = Dt.Rows[0][19].ToString();
                label20.Text = Dt.Rows[0][18].ToString();
                label22.Text = Dt.Rows[0][21].ToString();
                label23.Text = Dt.Rows[0][20].ToString();
            }
 
            label_DMCheck.Text = label_PNum.Text + "  " + label_PName.Text + "  " + "审核";
            label_PRMP_DesignMangCheckResult.Visible = true;
            Label10.Visible = true;
            label_PRMP_DesignMangName.Visible = true;
            label1_PanelSupply.Visible = true;
            Button8.Visible = false;
            Button10.Visible = false;
            Button9.Visible = false;
            label20.Visible = true;
            Label21.Visible = true;
            label22.Visible = true;
            label23.Visible = true;
            Button4.Visible = false;
            Button5.Visible = false;
            Button11.Visible = false;
            Button16.Visible = true;
            Label8.Visible = true;
            Label14.Visible = true;
            Label19.Visible = true;
            TextBox9.Visible = true;
            TextBox8.Enabled = false;
            TextBox9.Enabled = false;
            Panel1_Check.Visible = true;
            Label31.Visible = false;
            Label30.Visible = false;

            Label32.Visible = true;
            Label37.Visible = true;
            Label38.Visible = true;
            label33.Visible = true;
            Label34.Visible = true;
            label35.Visible = true;
            label36.Visible = true;
            TextBox6.Visible = true;
            TextBox6.Enabled = false;
            Button17.Visible = false;
            Button19.Visible = false;
            Button20.Visible = false;
            UpdatePanel1_Check.Update();
        }
        if (e.CommandName == "Delete2")//删除
        {
            
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview_ProjectInfo.SelectedIndex = row.RowIndex;
            label_supplytypeid.Text = Convert.ToString(e.CommandArgument);
            
            string condition = " and PRMP_ID='" + new Guid(label_supplytypeid.Text.ToString()) + "'"+" and PRMPA_AccState='"+"申请材料"+"'";
            DataSet dds = prmp.SelectPRMProjectAccessory(condition);
            DataTable ddt = dds.Tables[0];
            string sg="";
            if(ddt.Rows.Count>0)
            { 
            sg=ddt.Rows[0][0].ToString();
            }
            Guid sc = new Guid(sg);
            PRMProjectinfo.PRMPA_ID = sc;
            prmp.DeletePRMProjectAccessory(PRMProjectinfo);
            Guid de = new Guid(e.CommandArgument.ToString());
            prmp.DeleteProject(de);
            BindGridView_Projectinfo("");
            UpdatePanel_ProjectInfo.Update();
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_ProjectInfo, GetType(), "alert", "alert('删除成功！')", true);
            return;
        }
        if (e.CommandName == "DownLL")//查看附件
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview_ProjectInfo.SelectedIndex = row.RowIndex;
            label_supplytypeid.Text = Convert.ToString(e.CommandArgument);
            label_WHB.Text = Gridview_ProjectInfo.Rows[row.RowIndex].Cells[2].Text.ToString();
            string condition = " and PRMP_ID='" + new Guid(label_supplytypeid.Text.ToString()) + "'";
            BindGridview2(condition);
            Panel_Preserve.Visible = true;
            UpdatePanel_Preserve.Update();
        }
        if (e.CommandName == "DNL")//上传计划书
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview_ProjectInfo.SelectedIndex = row.RowIndex;
            label_supplytypeid.Text = Convert.ToString(e.CommandArgument);
            LabelQ_SaveDirectory.Text = "计划书";
            ShowPanel();
            UpdatePanel4.Update();
        }
        if (e.CommandName == "Report")//上传项目验收报告
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview_ProjectInfo.SelectedIndex = row.RowIndex;
            label_supplytypeid.Text = Convert.ToString(e.CommandArgument);
            LabelQ_SaveDirectory.Text = "验收报告";
            ShowPanel();
            UpdatePanel4.Update();
        }
        if(e.CommandName=="YSelect")//选择验收部门
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview_ProjectInfo.SelectedIndex = row.RowIndex;
            label_supplytypeid.Text = Convert.ToString(e.CommandArgument);
            BindGridview3("");
            Panel_Org.Visible = true;
            UpdatePanel_Org.Update();

        }
        if (e.CommandName == "YCountersign")//验收会签
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview_ProjectInfo.SelectedIndex = row.RowIndex;
            Gridview4.Columns[8].Visible = false;
            label_supplytypeid.Text = Convert.ToString(e.CommandArgument);
            string condition = "and  PRMP_ID='" + new Guid(label_supplytypeid.Text.ToString()) + "'";
            BindGridview4(condition);
            Panel_Sign.Visible = true;
            UpdatePanel_Sign.Update();
        }
        if (e.CommandName == "YCheck")//验收审核
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview_ProjectInfo.SelectedIndex = row.RowIndex;
            labelCheckState.Text = "审核";
            label_supplytypeid.Text = Convert.ToString(e.CommandArgument);
          Guid ls = new Guid(label_supplytypeid.Text);
            DataSet ds = prmp.SelectPRMProject_One(ls);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                label46.Text = dt.Rows[0][2].ToString()+"  "+Session["Department"].ToString()+"验收审核";
                 if (Session["Department"].ToString() == dt.Rows[0][9].ToString())
                       {
                       label49.Visible = false;
                        Label57.Visible = false;
                        label58.Visible = false;
                        label59.Visible = false;
                        TextBox7.Enabled = true;
                        Button22.Visible = true;
                        Button23.Visible = true;
                        Button24.Visible = true;
                        Button30.Visible = false;
                        Panel1.Visible = true;
                        Panel2.Visible = true;
                        UpdatePanel2.Update();
                       }
            }
            
        }
        if (e.CommandName == "Design")//项目批准
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview_ProjectInfo.SelectedIndex = row.RowIndex;
            label_supplytypeid.Text = e.CommandArgument.ToString();
            string condition = "and  PRMP_ID='" + new Guid(label_supplytypeid.Text.ToString()) + "'";
            BindGridview4(condition);
            Panel_Sign.Visible = true;
            UpdatePanel_Sign.Update();
            label_Coutersign.Text = "项目批准";
            Label8.Visible = false;
            Label14.Visible = false;
            Label19.Visible = false;
            Panel1_Check.Visible = true;
            UpdatePanel1_Check.Update();
            TextBox9.Visible = false;
            Button4.Visible = false;
            Button5.Visible = false;
            Button11.Visible = false;
            TextBox8.Enabled = true;
            Button8.Visible = true;
            Button10.Visible = true ;
            Button9.Visible = true ;
            Button16.Visible = true;
            label20.Visible = false;
            Label21.Visible = false;
            label22.Visible = false;
            label23.Visible = false;
            Button16.Visible = false;
            Label31.Visible = false;
            Label39.Visible = false;
            Label30.Visible = true;
            Label32.Visible = false;
            label33.Visible = false;
            Label34.Visible = false;
            label35.Visible = false;
            label36.Visible = false;
            Label37.Visible = false;
            Label38.Visible = false;
            Button17.Visible = false;
            Button19.Visible = false;
            Button20.Visible = false;
            TextBox6.Visible = false;
            label_supplytypeid.Text = Convert.ToString(e.CommandArgument);
            Guid ls = new Guid(label_supplytypeid.Text);
            DataSet ds = prmp.SelectPRMProject_One(ls);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                label_PNum.Text = dt.Rows[0][1].ToString();
                label_PName.Text = dt.Rows[0][2].ToString();
            }

            String conditionn = "and PRMP_ID='" + ls + "'" + "and PRMPD_DesignMangCheckSate='" + "项目批准" + "'";
            DataSet Dss = prmp.SelectProjectCheck(conditionn);
            DataTable Dtt = Dss.Tables[0];
            if (Dss.Tables[0].Rows.Count > 0)
            {
                TextBox8.Text = Dtt.Rows[0][3].ToString();
                label1_PanelSupply.Text = Dtt.Rows[0][4].ToString();
                label_PRMP_DesignMangCheckResult.Text = Dtt.Rows[0][2].ToString();
                label_PRMP_DesignMangName.Text = Dtt.Rows[0][6].ToString();
            }

            label_DMCheck.Text = label_PNum.Text + "  " + label_PName.Text + "  " + "审核";
          
            Panel1_Check.Visible = true;
            UpdatePanel1_Check.Update();
        }
        if (e.CommandName == "Mater")//上传材料
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview_ProjectInfo.SelectedIndex = row.RowIndex;
            label_supplytypeid.Text = Convert.ToString(e.CommandArgument);
            LabelQ_SaveDirectory.Text = "材料";
            ShowPanel();
            UpdatePanel4.Update();
        }
        if (e.CommandName == "CheckAccept")//查看验收意见
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview_ProjectInfo.SelectedIndex = row.RowIndex;
            label_supplytypeid.Text = e.CommandArgument.ToString();
            string condition = "and  PRMP_ID='" + new Guid(label_supplytypeid.Text.ToString()) + "'";
            BindGridview4(condition);
            Panel_Sign.Visible = true;
            UpdatePanel_Sign.Update();
            label_Coutersign.Text = "项目批准";
            Label8.Visible = false;
            Label14.Visible = false;
            Label19.Visible = false;
            Button16.Visible = false;
            Gridview4.Columns[7].Visible = false;
            Panel1_Check.Visible = true;
            UpdatePanel1_Check.Update();
            TextBox9.Visible = false;
            Button4.Visible = false;
            Button5.Visible = false;
            Button11.Visible = false;
            TextBox8.Enabled = true;
            Button8.Visible = false ;
            Button10.Visible =false ;
            Button9.Visible = false ;
            label20.Visible = false;
            Label21.Visible = false;
            label22.Visible = false;
            label23.Visible = false;
            Button16.Visible =true ;
            Label31.Visible = false;
            Label30.Visible = true;
            Label32.Visible = false;
            label33.Visible = false;
            Label34.Visible = false;
            label35.Visible = false;
            label36.Visible = false;
            Label37.Visible = false;
            Label38.Visible = false;
            Label39.Visible = false;
            Button17.Visible = false;
            Button19.Visible = false;
            Button20.Visible = false;
            TextBox6.Visible = false;
            label_supplytypeid.Text = Convert.ToString(e.CommandArgument);
            Guid ls = new Guid(label_supplytypeid.Text);
            DataSet ds = prmp.SelectPRMProject_One(ls);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                label_PNum.Text = dt.Rows[0][1].ToString();
                label_PName.Text = dt.Rows[0][2].ToString();
            }
            label_DMCheck.Text = label_PNum.Text + "  " + label_PName.Text + "  " + "审核";
            Guid dmco = new Guid(label_supplytypeid.Text);
            String conditionn = "and PRMP_ID='" + dmco + "'" + "and PRMPD_DesignMangCheckSate='" + "项目批准" + "'";
            DataSet Dss = prmp.SelectProjectCheck(conditionn);
            DataTable Dtt = Dss.Tables[0];
            if (Dss.Tables[0].Rows.Count > 0)
            {
                TextBox8.Text = Dtt.Rows[0][3].ToString();
                label1_PanelSupply.Text = Dtt.Rows[0][4].ToString();
                label_PRMP_DesignMangCheckResult.Text = Dtt.Rows[0][2].ToString();
                label_PRMP_DesignMangName.Text = Dtt.Rows[0][6].ToString();
            }
            Panel1_Check.Visible = true;
            UpdatePanel1_Check.Update();
        }
        if (e.CommandName == "CheckPlan")//查看计划书审核意见
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview_ProjectInfo.SelectedIndex = row.RowIndex;
            Button16.Visible = true;
            Label8.Visible = false;
            Label14.Visible = false;
            Label19.Visible = false;
            Panel1_Check.Visible = true;
            UpdatePanel1_Check.Update(); 
            label_PRMP_DesignMangCheckResult.Visible = true;
            label_PRMP_DesignMangName.Visible = true;
            Label10.Visible = true;
            label1_PanelSupply.Visible = true;

            TextBox8.Enabled = false;
            Button8.Visible = false;
            Button10.Visible = false;
            Button9.Visible = false;
            TextBox9.Visible = false;
            TextBox9.Enabled = true;
            Button4.Visible = false;
            Button5.Visible = false;
            Button11.Visible = false;
            label20.Visible = false;
            Label21.Visible = false;
            label22.Visible = false;
            label23.Visible = false;
            Label31.Visible = false;
            Label30.Visible = true;
            Label32.Visible = false;
            Label37.Visible = false;
            Label38.Visible = false;
            Label39.Visible = false;
            label33.Visible = false;
            Label34.Visible = false;
            label35.Visible = false;
            label36.Visible = false;
            TextBox6.Visible =false;
            Button17.Visible = false;
            Button19.Visible = false;
            Button20.Visible = false;
            label_supplytypeid.Text = e.CommandArgument.ToString();

            Guid ls = new Guid(label_supplytypeid.Text);
            DataSet ds = prmp.SelectPRMProject_One(ls);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                label_PNum.Text = dt.Rows[0][1].ToString();
                label_PName.Text = dt.Rows[0][2].ToString();
            }

            label_DMCheck.Text = label_PNum.Text + "  " + label_PName.Text + "  " + "计划书审核";

            string condition = " and PRMP_ID='" + new Guid(label_supplytypeid.Text) + "'" + "and PRMPD_DesignMangCheckSate='"+"计划审核"+"'";
            DataSet dds = prmp.SelectProjectCheck(condition);
            DataTable ddt = dds.Tables[0];
            if(ddt.Rows.Count>0)
            {
                TextBox8.Text = ddt.Rows[0][3].ToString();
                label1_PanelSupply.Text = ddt.Rows[0][4].ToString();
                label_PRMP_DesignMangCheckResult.Text = ddt.Rows[0][2].ToString();
                label_PRMP_DesignMangName.Text = ddt.Rows[0][6].ToString();
            }
        }
    }
    //部门查询
    private void BindGridview3(string condition)
    {
        Gridview3.DataSource = pc.SelectPMSCAC_Organization(condition);
        Gridview3.DataBind();
    }
    //会签表
    private void BindGridview4(string condition)
    {
        Gridview4.DataSource = prmp.SelectPRMProjectCountersign(condition);
        Gridview4.DataBind();
    }
    //附件
    private void BindGridview2(string condition)
    {
        Gridview2.DataSource = prmp.SelectPRMProjectAccessory(condition);
        Gridview2.DataBind();
    }

    //提交新增项目
    protected void ConfirmProject(object sender, EventArgs e)
    {
        try
        {
                string TB3;
                string TB2;
                string TB4;
                string TB5;
                string DL3;
                string DL2;
                string Acc;
                string AccNum;
                string AccPath;
                string AccState;
                string AccName;
                string Dep;
            if (label_XG.Text == "新增项目")
            {
               
                if (TextBox3.Text.ToString() == "")
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel_NewProjectInfo, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                    return;
                }
                else
                {
                    TB3 = TextBox3.Text.ToString();
                }
                if (DropDownList3.SelectedValue == "请选择")
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel_NewProjectInfo, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                    return;
                }
                else
                {
                    DL3 = DropDownList3.Text.ToString();
                }
                if (DropDownList2.SelectedValue == "请选择")
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel_NewProjectInfo, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                    return;
                }
                else
                {
                    DL2 = DropDownList2.Text.ToString();
                }
                if (TextBox2.Text.ToString() == "")
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel_NewProjectInfo, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                    return;
                }
                else
                {
                    TB2 = TextBox2.Text.ToString();
                }
                if (TextBox4.Text.ToString() == "")
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel_NewProjectInfo, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                    return;
                }
                else
                {
                    TB4 = TextBox4.Text.ToString();
                }
                if (TextBox5.Text.ToString() == "")
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel_NewProjectInfo, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                    return;
                }
                else
                {
                    TB5 = TextBox5.Text.ToString();
                }
                Dep = Session["Department"].ToString();
                string condition = "and PRMP_ProductMode='" + TextBox3.Text.ToString() + "'" + "and PRMP_ProjectName='" + TextBox2.Text.ToString() + "'" + "and PRMP_Sample='" + DropDownList2.SelectedValue.ToString() + "'" + "and PRMP_ProjectType='" + DropDownList3.SelectedValue.ToString() + "'";
                DataSet dds = prmp.SelectPRMProject(condition);
                DataTable ddt = dds.Tables[0];
                if (ddt.Rows.Count > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel_NewProjectInfo, GetType(), "alert", "alert('请项目已存在！')", true);
                    return;
                }
                else
                {
                    if (Label_FilePath.Text == "")
                    {
                    AccNum="";
                    AccPath="";
                    AccState="";
                    AccName="";
                     Acc="否";
                    }
                    else 
                    {
                    AccNum=label_AccNum.Text.ToString();
                    AccPath = Label_FilePath.Text.ToString();
                    AccState="申请材料";
                    AccName=label_AccName.Text.ToString();
                    Acc="是";
                    }
                    prmp.InsertPRMProject(TB3, DL3, DL2, TB2, TB4, TB5,Acc,AccNum,AccPath,AccState,AccName,Dep);
                    BindGridView_Projectinfo("");
                    UpdatePanel_ProjectInfo.Visible = true;
                    UpdatePanel_ProjectInfo.Update();
                    Panel_NewProjectInfo.Visible = false;
                 
                    string Morl = TextBox2.Text.ToString();
                    label_RTX.Text = "ERP系统信息：" + Session["UserName"].ToString() + "于" + DateTime.Now + "提交了" + Morl + "的项目申请单，请审核。";
                    string message = label_RTX.Text;
                       string sErr=RTXhelper.Send(message, "技术副总项目审核");
                    if (!string.IsNullOrEmpty(sErr))
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
                    }
                }
            }
            if (label_XG.Text == "修改项目")
            {
          
                if (TextBox3.Text.ToString() == "")
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel_NewProjectInfo, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                    return;
                }
                else
                {
                    TB3 = TextBox3.Text.ToString();
                }
                if (DropDownList3.SelectedValue == "请选择")
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel_NewProjectInfo, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                    return;
                }
                else
                {
                    DL3 = DropDownList3.Text.ToString();
                }
                if (DropDownList2.SelectedValue == "请选择")
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel_NewProjectInfo, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                    return;
                }
                else
                {
                    DL2 = DropDownList2.Text.ToString();
                }
                if (TextBox2.Text.ToString() == "")
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel_NewProjectInfo, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                    return;
                }
                else
                {
                    TB2 = TextBox2.Text.ToString();
                }
                if (TextBox4.Text.ToString() == "")
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel_NewProjectInfo, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                    return;
                }
                else
                {
                    TB4 = TextBox4.Text.ToString();
                }
                if (TextBox5.Text.ToString() == "")
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel_NewProjectInfo, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                    return;
                }
                else
                {
                    TB5 = TextBox5.Text.ToString();
                }

                if (Label_FilePath.Text=="")
                {
                    AccNum = "";
                    AccPath = "";
                    AccState = "";
                    AccName = "";
                    Acc = "否";
                }
                else
                {
                    AccNum = label_AccNum.Text.ToString();
                    AccPath = Label_FilePath.Text.ToString();
                    AccState = "申请材料";
                    AccName = label_AccName.Text.ToString();
                    Acc = "是";
                }
                Guid ls = new Guid(label_supplytypeid.Text);
                    prmp.UpdatePRMProject(ls, TB3, DL3, DL2, TB2, TB4, TB5,Acc,AccNum,AccPath,AccState,AccName);
                    BindGridView_Projectinfo("");
                    
                    UpdatePanel_ProjectInfo.Visible = true;
                    UpdatePanel_ProjectInfo.Update();
                    Panel_NewProjectInfo.Visible = false;
                    UpdatePanel_NewProjectInfo.Update();
                    //this.label_RTX.Text = "ERP系统信息：" + Session["UserName"].ToString() + "于" + DateTime.Now + "提交了" + this.TextBox2.Text.ToString() + "的项目申请单，请审核。";
                    //if (label_RTX.Text != "")
                    //{
                    //    string message = label_RTX.Text;
                    //    RTXhelper.Send(message, "技术副总项目审核");
                    //}
            }
        }

        catch (Exception)
        {
            throw;
        }
    }
    //取消新建项目
    protected void CanelProject(object sender, EventArgs e)
    {
        try
        {
            UpdatePanel_NewProjectInfo.Update();
            Panel_NewProjectInfo.Visible = false;
        }
        catch (Exception)
        {
            throw;
        }
    }
    //技术副总审核通过
    protected void DesignMangPass(object sender, EventArgs e)
    {
        try
        {
            Guid projectid = new Guid(label_supplytypeid.Text);
            if( label_Coutersign.Text == "技术副总初审")
            {
            string PRMPD_DesignMangCheckOpinion = TextBox8.Text.ToString();

            string Name = Session["UserName"].ToString().Trim();
            if (TextBox8.Text.ToString() == "")
            {
                 ScriptManager.RegisterClientScriptBlock(UpdatePanel1_Check, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            else
            {
                prmp.InsertPRMP_DesignMangCheckOpinion(projectid, "通过", PRMPD_DesignMangCheckOpinion, "申请审核", Name);
                prmp.UpdatePRMP_ProjectStates(projectid,"技术副总初审通过");
                BindGridView_Projectinfo("");
                UpdatePanel_ProjectInfo.Update();
                TextBox8.Text = "";
                Panel1_Check.Visible = false;
                UpdatePanel1_Check.Update();
                string Morl = Gridview_ProjectInfo.Rows[Gridview_ProjectInfo.SelectedIndex].Cells[2].Text.ToString();
                label_RTX.Text = "ERP系统信息：" + Session["UserName"].ToString() + "于" + DateTime.Now + "审核通过了" + Morl+ "的项目申请单，请安排责任部门。";
               string message = label_RTX.Text;
               //string dep=this.Gridview_ProjectInfo.Rows[Gridview_ProjectInfo.SelectedIndex].Cells[25].Text.ToString();
               string sErr= RTXhelper.Send(message,"技术副总项目审核");
                if (!string.IsNullOrEmpty(sErr))
                {
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true); 
                }
            }
            }
            if (label_Coutersign.Text == "技术副总审核")
            {
                string PRMPD_DesignMangCheckOpinion = TextBox8.Text.ToString();

                string Name = Session["UserName"].ToString().Trim();
                if (TextBox8.Text.ToString() == "")
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel1_Check, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                    return;
                }
                else
                {
                    prmp.InsertPRMP_DesignMangCheckOpinion(projectid, "通过", PRMPD_DesignMangCheckOpinion, "计划审核", Name);
                    prmp.UpdatePRMP_ProjectStates(projectid, "技术副总审核通过");
                    BindGridView_Projectinfo("");
                    UpdatePanel_ProjectInfo.Update();
                    TextBox8.Text = "";
                    Panel1_Check.Visible = false;
                    UpdatePanel1_Check.Update();

                    //string dep = "";
                    //foreach (GridViewRow q in Gridview6.Rows)
                    //{
                    //    dep += q.Cells[1].Text.ToString() + ",";
                    //}
                    //dep = dep.Substring(0, dep.Length - 1);
                    //this.label_RTX.Text = "ERP系统信息：" + Session["UserName"].ToString() + "于" + DateTime.Now + "调试了" + this.Gridview6.Rows[Gridview6.SelectedIndex].Cells[2].Text.ToString() + "请审核。";
                    //if (label_RTX.Text != "")
                    //{
                    //    string message = label_RTX.Text;
                    //    RTXhelper.SendbyDepAndRole(message, dep, "设备采购验收审核");
                    //}

                    string Morl = Gridview_ProjectInfo.Rows[Gridview_ProjectInfo.SelectedIndex].Cells[2].Text.ToString();
                    label_RTX.Text = "ERP系统信息：" + Session["UserName"].ToString() + "于" + DateTime.Now + "审核通过了" + Morl + "的项目申请单，请查看。";
                    string message = label_RTX.Text;
                    string dep = Gridview_ProjectInfo.Rows[Gridview_ProjectInfo.SelectedIndex].Cells[26].Text.ToString();
                    string sErr = RTXhelper.SendbyDepAndRole(message,dep,"项目进度设置");
                    if (!string.IsNullOrEmpty(sErr))
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
                    }
                }
            }
            if (label_Coutersign.Text == "项目批准")
            {
                string PRMPD_DesignMangCheckOpinion = TextBox8.Text.ToString();

                string Name = Session["UserName"].ToString().Trim();
                if (TextBox8.Text.ToString() == "")
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel1_Check, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                    return;
                }
                else
                {
                    prmp.InsertPRMP_DesignMangCheckOpinion(projectid, "通过", PRMPD_DesignMangCheckOpinion, "项目批准", Name);
                    prmp.UpdatePRMP_ProjectStates(projectid, "技术副总批准通过");
                    BindGridView_Projectinfo("");
                    UpdatePanel_ProjectInfo.Update();
                    TextBox8.Text = "";
                    Panel1_Check.Visible = false;
                    UpdatePanel1_Check.Update();
                    //this.label_RTX.Text = "ERP系统信息：" + Session["UserName"].ToString() + "于" + DateTime.Now + "审核通过了" + this.Gridview_ProjectInfo.Rows[Gridview_ProjectInfo.SelectedIndex].Cells[2].Text.ToString() + "的项目申请单，请审核。";
                    //if (label_RTX.Text != "")
                    //{
                    //    string message = label_RTX.Text;
                    //    RTXhelper.Send(message, "工程部");设置BOM之类的
                    //}
                }
                
            }
   
                Panel_Sign.Visible = false;
                UpdatePanel_Sign.Update();
        }
        catch (Exception)
        {
            throw;
        }
    }
    //技术副总审核驳回
    protected void DesignMangReject(object sender, EventArgs e)
    {
        try
        {
            Guid projectid = new Guid(label_supplytypeid.Text);
            if(label_Coutersign.Text == "技术副总初审")
            {
            string PRMPD_DesignMangCheckOpinion = TextBox8.Text.ToString();

            string Name = Session["UserName"].ToString().Trim();
            if (TextBox8.Text.ToString() == "")
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1_Check, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            else
            {
                prmp.InsertPRMP_DesignMangCheckOpinion(projectid, "驳回", PRMPD_DesignMangCheckOpinion, "申请审核", Name);
                BindGridView_Projectinfo("");
                UpdatePanel_ProjectInfo.Update();
                Panel1_Check.Visible = false;
                UpdatePanel1_Check.Update();
                string Morl = Gridview_ProjectInfo.Rows[Gridview_ProjectInfo.SelectedIndex].Cells[2].Text.ToString();
                label_RTX.Text = "ERP系统信息：" + Session["UserName"].ToString() + "于" + DateTime.Now + "审核驳回了" + Morl + "的项目申请单，请查看。";
                string message = label_RTX.Text;
                string dep = Gridview_ProjectInfo.Rows[Gridview_ProjectInfo.SelectedIndex].Cells[25].Text.ToString();
                string sErr = RTXhelper.SendbyDepAndRole(message, dep, "项目申请管理");
                if (!string.IsNullOrEmpty(sErr))
                {
                      ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
                }

            }
            }
            if (label_Coutersign.Text == "技术副总审核")
            {
                string PRMPD_DesignMangCheckOpinion = TextBox8.Text.ToString();

                string Name = Session["UserName"].ToString().Trim();
                if (TextBox8.Text.ToString() == "")
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel1_Check, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                    return;
                }
                else
                {
                    prmp.InsertPRMP_DesignMangCheckOpinion(projectid, "驳回", PRMPD_DesignMangCheckOpinion, "计划审核", Name);
                    prmp.UpdatePRMP_ProjectStates(projectid, "技术副总审核驳回");
                    BindGridView_Projectinfo("");
                    UpdatePanel_ProjectInfo.Update();
                    TextBox8.Text = "";
                    Panel1_Check.Visible = false;
                    UpdatePanel1_Check.Update();
                    string Morl = Gridview_ProjectInfo.Rows[Gridview_ProjectInfo.SelectedIndex].Cells[2].Text.ToString();
                    label_RTX.Text = "ERP系统信息：" + Session["UserName"].ToString() + "于" + DateTime.Now + "审核驳回了" + Morl+ "的项目申请单，请查看。";
                    string message = label_RTX.Text;
                    string dep = Gridview_ProjectInfo.Rows[Gridview_ProjectInfo.SelectedIndex].Cells[26].Text.ToString();

                    string sErr = RTXhelper.SendbyDepAndRole(message, dep, "项目材料维护");
                    if (!string.IsNullOrEmpty(sErr))
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
                    }
                }
            }

            if (label_Coutersign.Text == "项目批准")
            {
                string PRMPD_DesignMangCheckOpinion = TextBox8.Text.ToString();

                string Name = Session["UserName"].ToString().Trim();
                if (TextBox8.Text.ToString() == "")
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel1_Check, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                    return;
                }
                else
                {
                    prmp.InsertPRMP_DesignMangCheckOpinion(projectid, "驳回", PRMPD_DesignMangCheckOpinion, "项目批准", Name);
                    prmp.UpdatePRMP_ProjectStates(projectid, "技术副总驳回批准");
                    BindGridView_Projectinfo("");
                    UpdatePanel_ProjectInfo.Update();
                    TextBox8.Text = "";
                    Panel1_Check.Visible = false;
                    UpdatePanel1_Check.Update();
                    //this.label_RTX.Text = "ERP系统信息：" + Session["UserName"].ToString() + "于" + DateTime.Now + "审核通过了" + this.Gridview_ProjectInfo.Rows[Gridview_ProjectInfo.SelectedIndex].Cells[2].Text.ToString() + "的项目申请单，请审核。";
                    //if (label_RTX.Text != "")
                    //{
                    //    string message = label_RTX.Text;
                    //    RTXhelper.Send(message, "工程部");
                    //}
                }
            }
            Panel_Sign.Visible = false;
            UpdatePanel_Sign.Update();
        }
        catch (Exception)
        {
            throw;
        }
    }
    //总经理审核通过
    protected void GeneralMangPass(object sender, EventArgs e)
    {
        try
        {
            Guid projectid = new Guid(label_supplytypeid.Text);
            string GMCR = TextBox9.Text.ToString();

            string Name = Session["UserName"].ToString().Trim();
            if (TextBox9.Text.ToString() == "")
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1_Check, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            else
            {
                prmp.InsertPRMP_GeneralMangCheckOpinion(projectid, "通过", GMCR, "总经理审核通过", Name);
                BindGridView_Projectinfo("");
                UpdatePanel_ProjectInfo.Update();
                Panel1_Check.Visible = false;
                UpdatePanel1_Check.Update();
                string Morl = Gridview_ProjectInfo.Rows[Gridview_ProjectInfo.SelectedIndex].Cells[2].Text.ToString();
                label_RTX.Text = "ERP系统信息：" + Session["UserName"].ToString() + "于" + DateTime.Now + "审核通过了" +Morl+ "的项目申请单，请提交计划书。";
                string message = label_RTX.Text;
                string dep = Gridview_ProjectInfo.Rows[Gridview_ProjectInfo.SelectedIndex].Cells[26].Text.ToString();

                string sErr = RTXhelper.SendbyDepAndRole(message, dep, "项目材料维护");
                if (!string.IsNullOrEmpty(sErr))
                {
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
                }
            }
            TextBox9.Text = "";
            Panel_Sign.Visible = false;
            UpdatePanel_Sign.Update();
        }
        catch (Exception)
        {
            throw;
        }
    }
    //技术副总审核取消
    protected void DesignMangCanel(object sender, EventArgs e)
    {
        try
        {
            TextBox8.Text = "";
           
            Panel1_Check.Visible = false;
            UpdatePanel1_Check.Update();
            Panel_Sign.Visible = false;
            UpdatePanel_Sign.Update();
        }
        catch (Exception)
        {
            throw;
        }
    }
    //总经理审核驳回
    protected void GeneralMangReject(object sender, EventArgs e)
    {
        try
        {
            Guid projectid = new Guid(label_supplytypeid.Text);
            string GMCR = TextBox9.Text.ToString();

            string Name = Session["UserName"].ToString().Trim();
            if (TextBox9.Text.ToString() == "")
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1_Check, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            else
            {
                prmp.InsertPRMP_GeneralMangCheckOpinion(projectid, "驳回", GMCR, "总经理审核驳回", Name);
                BindGridView_Projectinfo("");
                UpdatePanel_ProjectInfo.Update();

                Panel1_Check.Visible = false;
                UpdatePanel1_Check.Update();
                string Morl = Gridview_ProjectInfo.Rows[Gridview_ProjectInfo.SelectedIndex].Cells[2].Text.ToString();
                label_RTX.Text = "ERP系统信息：" + Session["UserName"].ToString() + "于" + DateTime.Now + "审核驳回了" + Morl+ "的项目申请单，请查看。";
                string message = label_RTX.Text;
                string dep = Gridview_ProjectInfo.Rows[Gridview_ProjectInfo.SelectedIndex].Cells[26].Text.ToString();

                string sErr = RTXhelper.SendbyDepAndRole(message, dep, "项目材料维护");
                if (!string.IsNullOrEmpty(sErr))
                {
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
                }
            }
            TextBox9.Text = "";
            Panel_Sign.Visible = false;
            UpdatePanel_Sign.Update();
        }                
        catch (Exception)
        {
            throw;
        }
    }           
    //总经理审核取消
    protected void GeneralMangCanel(object sender, EventArgs e)
    {
        try
        {
            TextBox9.Text = "";
            
            Panel1_Check.Visible = false;
            UpdatePanel1_Check.Update();
            Panel_Sign.Visible = false;
            UpdatePanel_Sign.Update();
        }
        catch (Exception)
        {
            throw;
        }
    }
    #region //换页
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
         string condition ="and  PRMP_ID='"+new Guid(label_supplytypeid.Text.ToString())+"'";
        BindGridview4(condition);

        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview4.PageCount ? Gridview4.PageCount - 1 : newPageIndex;
        Gridview4.PageIndex = newPageIndex;
        Gridview4.DataBind();
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
        string condition = GetCondition_Org();
        BindGridview3(condition);

        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview3.PageCount ? Gridview3.PageCount - 1 : newPageIndex;
        Gridview3.PageIndex = newPageIndex;
        Gridview3.DataBind();
    }
    protected void Gridview2_PageIndexChanging(object sender, GridViewPageEventArgs e)
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
        string condition = " and PRMP_ID='" + new Guid(label_supplytypeid.Text.ToString()) + "'";
        BindGridview2(condition);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview2.PageCount ? Gridview2.PageCount - 1 : newPageIndex;
        Gridview2.PageIndex = newPageIndex;
        Gridview2.DataBind();
    }
    protected void Gridview_ProjectInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview_ProjectInfo.BottomPagerRow;


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
        Gridview_ProjectInfo.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview_ProjectInfo.PageCount ? Gridview_ProjectInfo.PageCount - 1 : newPageIndex;
        Gridview_ProjectInfo.PageIndex = newPageIndex;
        Gridview_ProjectInfo.DataBind();

    }
    //产品型号
    protected void Gridview_ProductMode_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview_ProductMode.BottomPagerRow;


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
        string condition = GetProduct();
        BindGridView_ProductMode(condition);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview_ProductMode.PageCount ? Gridview_ProductMode.PageCount - 1 : newPageIndex;
        Gridview_ProductMode.PageIndex = newPageIndex;
        Gridview_ProductMode.DataBind();

    }
    #endregion
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
    protected void Gridview_ProjectInfo_DataBound1(object sender, EventArgs e)
    {
        for (int i = 0; i < Gridview_ProjectInfo.Rows.Count; i++)
        {
            for (int j = 0; j < Gridview_ProjectInfo.Rows[i].Cells.Count; j++)
            {
                Gridview_ProjectInfo.Rows[i].Cells[j].ToolTip = Gridview_ProjectInfo.Rows[i].Cells[j].Text;
                if (Gridview_ProjectInfo.Rows[i].Cells[j].Text.Length > 15)
                {
                    Gridview_ProjectInfo.Rows[i].Cells[j].Text = Gridview_ProjectInfo.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }
            }
        }
    }



    //查找产品型号
    protected void Button1_Find(object sender, EventArgs e)
    {
        try
        {
            label_XF.Text = "新增";
            Panel_ProductMode.Visible = true;
            BindGridView_ProductMode("");
            UpdatePanel_ProductMode.Update();
        }
        catch (Exception)
        {
            throw;
        }
    }
    private void BindGridView_ProductMode(string condition)
    {
        try
        {
            Gridview_ProductMode.DataSource = prmp.SelectPRMProductMode(condition);
            Gridview_ProductMode.DataBind();
        }
        catch (Exception)
        {
            throw;
        }
    }
    protected void Button_Product(object sender, EventArgs e)
    {
        try
        {
            string Pname = "";
            bool temp = false;

            foreach (GridViewRow item in Gridview_ProductMode.Rows)
            {
                CheckBox rb = item.FindControl("RadioButtonMarkup") as CheckBox;

                if (rb.Checked)
                {
                    Pname += Gridview_ProductMode.DataKeys[item.RowIndex].Value.ToString() + ";  ";
                    temp = true;


                }
            }
            if (label_XF.Text == "新增")
            {
                if (!temp)
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel_ProductMode, GetType(), "aa", "alert('请选择产品类型')", true);
                    return;
                }
                else
                {
                    TextBox3.Text = TextBox3.Text + Pname;
                    TextBox16.Text = "";
                    Panel_ProductMode.Visible = false;

                    UpdatePanel_NewProjectInfo.Update();
                }
            }
            if (label_XF.Text == "检索")
            {
                if (!temp)
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel_ProductMode, GetType(), "aa", "alert('请选择产品类型')", true);
                    return;
                }
                else
                {
                    TextBox1.Text = TextBox1.Text + Pname;
                    TextBox16.Text = "";
                    Panel_ProductMode.Visible = false;
                    UpdatePanel_ProjectSearch.Update();
                }
            }
             
        }
        catch (Exception)
        {
            throw;
        }
    }
    //取消选择产品型号
    protected void Button_CancelProduct(object sender, EventArgs e)
    {
        try
        {
            Panel_ProductMode.Visible = false;
            UpdatePanel_ProductMode.Update();
        }
        catch (Exception)
        {
            throw;
        }
    }

    protected void Gridview_ProjectInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            DataRowView drv = (DataRowView)e.Row.DataItem;
            if (drv["PRMP_ProjectStates"].ToString().Trim() == "已提交")
            {
                //e.Row.Cells[9].Enabled = true;//修改
                //e.Row.Cells[10].Enabled = false;//技术副总审核
                e.Row.Cells[11].Enabled = false;//财务部审核
                e.Row.Cells[12].Enabled = false;//总经理审核
                //e.Row.Cells[13].Enabled = false;//查看审核意见
                e.Row.Cells[16].Enabled = false;//上传计划书
                e.Row.Cells[17].Enabled = false;//上传实验报告
                e.Row.Cells[18].Enabled = false;//验收审核
                e.Row.Cells[19].Enabled = false;//验收会签
                e.Row.Cells[20].Enabled = false ;//选择验收部门
                e.Row.Cells[21].Enabled = false;//项目批准
                e.Row.Cells[22].Enabled = false;//上传材料
                e.Row.Cells[23].Enabled = false  ;//查看验收意见
                e.Row.Cells[24].Enabled = false;//查看计划书审核意见
            }
            if (drv["PRMP_ProjectStates"].ToString().Trim() == "技术副总初审通过")
            {
                e.Row.Cells[9].Enabled = false ;//修改
                e.Row.Cells[10].Enabled = false;//技术副总审核
                e.Row.Cells[11].Enabled = false;//财务部审核
                e.Row.Cells[12].Enabled = false;//总经理审核
                //e.Row.Cells[13].Enabled = false;//查看审核意见
                e.Row.Cells[14].Enabled = false;//删除
                e.Row.Cells[16].Enabled = false;//上传计划书
                e.Row.Cells[17].Enabled = false;//上传实验报告
                e.Row.Cells[18].Enabled = false;//验收审核
                e.Row.Cells[19].Enabled = false;//验收会签
                e.Row.Cells[20].Enabled = false;//选择验收部门
                e.Row.Cells[21].Enabled = false;//项目批准
                //e.Row.Cells[22].Enabled = false ;//上传材料
                e.Row.Cells[23].Enabled = false;//查看验收意见
                e.Row.Cells[24].Enabled = false;//查看计划书审核意见
            }

            if (drv["PRMP_ProjectStates"].ToString().Trim() == "材料已提交")
            {
                e.Row.Cells[9].Enabled = false;//修改
                e.Row.Cells[10].Enabled = false;//技术副总审核
                //e.Row.Cells[11].Enabled = false;//财务部审核
                e.Row.Cells[12].Enabled = false;//总经理审核
                //e.Row.Cells[13].Enabled = false;//查看审核意见
                e.Row.Cells[14].Enabled = false;//删除
                e.Row.Cells[16].Enabled = false;//上传计划书
                e.Row.Cells[17].Enabled = false;//上传实验报告
                e.Row.Cells[18].Enabled = false;//验收审核
                e.Row.Cells[19].Enabled = false;//验收会签
                e.Row.Cells[20].Enabled = false;//选择验收部门
                e.Row.Cells[21].Enabled = false;//项目批准
                //e.Row.Cells[22].Enabled = false;//上传材料
                e.Row.Cells[23].Enabled = false;//查看验收意见
                e.Row.Cells[24].Enabled = false;//查看计划书审核意见
            }
            if (drv["PRMP_ProjectStates"].ToString().Trim() == "财务部审核通过")
            {
                e.Row.Cells[9].Enabled = false;//修改
                e.Row.Cells[10].Enabled = false;//技术副总审核
                e.Row.Cells[11].Enabled = false;//财务部审核
                //e.Row.Cells[12].Enabled = false;//总经理审核
                //e.Row.Cells[13].Enabled = false;//查看审核意见
                e.Row.Cells[14].Enabled = false;//删除
                e.Row.Cells[16].Enabled = false;//上传计划书
                e.Row.Cells[17].Enabled = false;//上传实验报告
                e.Row.Cells[18].Enabled = false;//验收审核
                e.Row.Cells[19].Enabled = false;//验收会签
                e.Row.Cells[20].Enabled = false;//选择验收部门
                e.Row.Cells[21].Enabled = false;//项目批准
                e.Row.Cells[22].Enabled = false;//上传材料
                e.Row.Cells[23].Enabled = false;//查看验收意见
                e.Row.Cells[24].Enabled = false;//查看计划书审核意见
            }
            if (drv["PRMP_ProjectStates"].ToString().Trim() == "总经理审核通过")
            {
                e.Row.Cells[9].Enabled = false;//修改
                e.Row.Cells[10].Enabled = false;//技术副总审核
                e.Row.Cells[11].Enabled = false;//财务部审核
                e.Row.Cells[12].Enabled = false;//总经理审核
                //e.Row.Cells[13].Enabled = false;//查看审核意见
                e.Row.Cells[14].Enabled = false;//删除
                //e.Row.Cells[16].Enabled = false;//上传计划书
                e.Row.Cells[17].Enabled = false;//上传实验报告
                e.Row.Cells[18].Enabled = false;//验收审核
                e.Row.Cells[19].Enabled = false;//验收会签
                e.Row.Cells[20].Enabled = false;//选择验收部门
                e.Row.Cells[21].Enabled = false;//项目批准
                e.Row.Cells[22].Enabled = false;//上传材料
                e.Row.Cells[23].Enabled = false;//查看验收意见
                e.Row.Cells[24].Enabled = false;//查看计划书审核意见
            }
            if (drv["PRMP_ProjectStates"].ToString().Trim() == "计划书已提交")
            {
                e.Row.Cells[9].Enabled = false;//修改
                //e.Row.Cells[10].Enabled = false;//技术副总审核
                e.Row.Cells[11].Enabled = false;//财务部审核
                e.Row.Cells[12].Enabled = false;//总经理审核
                //e.Row.Cells[13].Enabled = false;//查看审核意见
                e.Row.Cells[14].Enabled = false;//删除
                //e.Row.Cells[16].Enabled = false;//上传计划书
                e.Row.Cells[17].Enabled = false;//上传实验报告
                e.Row.Cells[18].Enabled = false;//验收审核
                e.Row.Cells[19].Enabled = false;//验收会签
                e.Row.Cells[20].Enabled = false;//选择验收部门
                e.Row.Cells[21].Enabled = false;//项目批准
                e.Row.Cells[22].Enabled = false;//上传材料
                e.Row.Cells[23].Enabled = false;//查看验收意见
                
            }
            if (drv["PRMP_ProjectStates"].ToString().Trim() == "进度设置完成" || drv["PRMP_ProjectStates"].ToString().Trim() == "进行中" || drv["PRMP_ProjectStates"].ToString().Trim() == "进度延期" )
            {
                e.Row.Cells[9].Enabled = false;//修改
                e.Row.Cells[10].Enabled = false;//技术副总审核
                e.Row.Cells[11].Enabled = false;//财务部审核
                e.Row.Cells[12].Enabled = false;//总经理审核
                //e.Row.Cells[13].Enabled = false;//查看审核意见
                e.Row.Cells[14].Enabled = false;//删除
                e.Row.Cells[16].Enabled = false;//上传计划书
                e.Row.Cells[17].Enabled = false;//上传实验报告
                e.Row.Cells[18].Enabled = false;//验收审核
                e.Row.Cells[19].Enabled = false;//验收会签
                e.Row.Cells[20].Enabled = false;//选择验收部门
                e.Row.Cells[21].Enabled = false;//项目批准
                e.Row.Cells[22].Enabled = false;//上传材料
                e.Row.Cells[23].Enabled = false;//查看验收意见
            }
            if (drv["PRMP_ProjectStates"].ToString().Trim() == "已完成")
            {
                e.Row.Cells[9].Enabled = false;//修改
                e.Row.Cells[10].Enabled = false;//技术副总审核
                e.Row.Cells[11].Enabled = false;//财务部审核
                e.Row.Cells[12].Enabled = false;//总经理审核
                //e.Row.Cells[13].Enabled = false;//查看审核意见
                e.Row.Cells[14].Enabled = false;//删除
                e.Row.Cells[16].Enabled = false;//上传计划书
                //e.Row.Cells[17].Enabled = false;//上传实验报告
                e.Row.Cells[18].Enabled = false;//验收审核
                e.Row.Cells[19].Enabled = false;//验收会签
                //e.Row.Cells[20].Enabled = false;//选择验收部门
                e.Row.Cells[21].Enabled = false;//项目批准
                e.Row.Cells[22].Enabled = false;//上传材料
                e.Row.Cells[23].Enabled = false;//查看验收意见
            }
            if (drv["PRMP_ProjectStates"].ToString().Trim() == "验收报告已提交")
            {
                e.Row.Cells[9].Enabled = false;//修改
                e.Row.Cells[10].Enabled = false;//技术副总审核
                e.Row.Cells[11].Enabled = false;//财务部审核
                e.Row.Cells[12].Enabled = false;//总经理审核
                //e.Row.Cells[13].Enabled = false;//查看审核意见
                e.Row.Cells[14].Enabled = false;//删除
                e.Row.Cells[16].Enabled = false;//上传计划书
                //e.Row.Cells[17].Enabled = false;//上传实验报告
                //e.Row.Cells[18].Enabled = false;//验收审核
                e.Row.Cells[19].Enabled = false;//验收会签
                //e.Row.Cells[20].Enabled = false;//选择验收部门
                e.Row.Cells[21].Enabled = false;//项目批准
                e.Row.Cells[22].Enabled = false;//上传材料
                e.Row.Cells[23].Enabled = false;//查看验收意见
            }
            if (drv["PRMP_ProjectStates"].ToString().Trim() == "责任部门验收审核通过")
            {
                e.Row.Cells[9].Enabled = false;//修改
                e.Row.Cells[10].Enabled = false;//技术副总审核
                e.Row.Cells[11].Enabled = false;//财务部审核
                e.Row.Cells[12].Enabled = false;//总经理审核
                //e.Row.Cells[13].Enabled = false;//查看审核意见
                e.Row.Cells[14].Enabled = false;//删除
                e.Row.Cells[16].Enabled = false;//上传计划书
                e.Row.Cells[17].Enabled = false;//上传实验报告
                //e.Row.Cells[18].Enabled = false;//验收审核
                //e.Row.Cells[19].Enabled = false;//验收会签
                e.Row.Cells[20].Enabled = false;//选择验收部门
                e.Row.Cells[21].Enabled = false;//项目批准
                e.Row.Cells[22].Enabled = false;//上传材料
                //e.Row.Cells[23].Enabled = false;//查看验收意见
            }
            if (drv["PRMP_ProjectStates"].ToString().Trim() == "责任部门验收审核驳回")
            {
                e.Row.Cells[9].Enabled = false;//修改
                e.Row.Cells[10].Enabled = false;//技术副总审核
                e.Row.Cells[11].Enabled = false;//财务部审核
                e.Row.Cells[12].Enabled = false;//总经理审核
                //e.Row.Cells[13].Enabled = false;//查看审核意见
                e.Row.Cells[14].Enabled = false;//删除
                e.Row.Cells[16].Enabled = false;//上传计划书
                e.Row.Cells[17].Enabled = false;//上传实验报告
                //e.Row.Cells[18].Enabled = false;//验收审核
                e.Row.Cells[19].Enabled = false;//验收会签
                e.Row.Cells[20].Enabled = false;//选择验收部门
                e.Row.Cells[21].Enabled = false;//项目批准
                e.Row.Cells[22].Enabled = false;//上传材料
                //e.Row.Cells[23].Enabled = false;//查看验收意见
            }
            if (drv["PRMP_ProjectStates"].ToString().Trim() == "验收会签中")
            {
                e.Row.Cells[9].Enabled = false;//修改
                e.Row.Cells[10].Enabled = false;//技术副总审核
                e.Row.Cells[11].Enabled = false;//财务部审核
                e.Row.Cells[12].Enabled = false;//总经理审核
                //e.Row.Cells[13].Enabled = false;//查看审核意见
                e.Row.Cells[14].Enabled = false;//删除
                e.Row.Cells[16].Enabled = false;//上传计划书
                e.Row.Cells[17].Enabled = false;//上传实验报告
                e.Row.Cells[18].Enabled = false;//验收审核
                //e.Row.Cells[19].Enabled = false;//验收会签
                e.Row.Cells[20].Enabled = false;//选择验收部门
                e.Row.Cells[21].Enabled = false;//项目批准
                e.Row.Cells[22].Enabled = false;//上传材料
                //e.Row.Cells[23].Enabled = false;//查看验收意见
            }
            if (drv["PRMP_ProjectStates"].ToString().Trim() == "验收会签通过")
            {
                e.Row.Cells[9].Enabled = false;//修改
                e.Row.Cells[10].Enabled = false;//技术副总审核
                e.Row.Cells[11].Enabled = false;//财务部审核
                e.Row.Cells[12].Enabled = false;//总经理审核
                //e.Row.Cells[13].Enabled = false;//查看审核意见
                e.Row.Cells[14].Enabled = false;//删除
                e.Row.Cells[16].Enabled = false;//上传计划书
                e.Row.Cells[17].Enabled = false;//上传实验报告
                e.Row.Cells[18].Enabled = false;//验收审核
                //e.Row.Cells[19].Enabled = false;//验收会签
                e.Row.Cells[20].Enabled = false;//选择验收部门
                //e.Row.Cells[21].Enabled = false;//项目批准
                e.Row.Cells[22].Enabled = false;//上传材料
                //e.Row.Cells[23].Enabled = false;//查看验收意见
            }
            if (drv["PRMP_ProjectStates"].ToString().Trim() == "验收会签驳回")
            {
                e.Row.Cells[9].Enabled = false;//修改
                e.Row.Cells[10].Enabled = false;//技术副总审核
                e.Row.Cells[11].Enabled = false;//财务部审核
                e.Row.Cells[12].Enabled = false;//总经理审核
                //e.Row.Cells[13].Enabled = false;//查看审核意见
                e.Row.Cells[14].Enabled = false;//删除
                e.Row.Cells[16].Enabled = false;//上传计划书
                e.Row.Cells[17].Enabled = false;//上传实验报告
                e.Row.Cells[18].Enabled = false;//验收审核
                //e.Row.Cells[19].Enabled = false;//验收会签
                e.Row.Cells[20].Enabled = false;//选择验收部门
                e.Row.Cells[21].Enabled = false;//项目批准
                e.Row.Cells[22].Enabled = false;//上传材料
                //e.Row.Cells[23].Enabled = false;//查看验收意见
            }
            if (drv["PRMP_ProjectStates"].ToString().Trim() == "技术副总批准通过")
            {
                e.Row.Cells[9].Enabled = false;//修改
                e.Row.Cells[10].Enabled = false;//技术副总审核
                e.Row.Cells[11].Enabled = false;//财务部审核
                e.Row.Cells[12].Enabled = false;//总经理审核
                //e.Row.Cells[13].Enabled = false;//查看审核意见
                e.Row.Cells[14].Enabled = false;//删除
                e.Row.Cells[16].Enabled = false;//上传计划书
                e.Row.Cells[17].Enabled = false;//上传实验报告
                e.Row.Cells[18].Enabled = false;//验收审核
                e.Row.Cells[19].Enabled = false;//验收会签
                e.Row.Cells[20].Enabled = false;//选择验收部门
                //e.Row.Cells[21].Enabled = false;//项目批准
                e.Row.Cells[22].Enabled = false;//上传材料
                //e.Row.Cells[23].Enabled = false;//查看验收意见
            }
            if (drv["PRMP_ProjectStates"].ToString().Trim() == "技术副总初审驳回" || drv["PRMP_ProjectStates"].ToString().Trim() == "总经理审核驳回" || drv["PRMP_ProjectStates"].ToString().Trim() == "财务部审核驳回")
            {
                //e.Row.Cells[9].Enabled = false;//修改
                e.Row.Cells[10].Enabled = false;//技术副总审核
                e.Row.Cells[11].Enabled = false;//财务部审核
                e.Row.Cells[12].Enabled = false;//总经理审核
                //e.Row.Cells[13].Enabled = false;//查看审核意见
                e.Row.Cells[14].Enabled = false;//删除
                e.Row.Cells[16].Enabled = false;//上传计划书
                e.Row.Cells[17].Enabled = false;//上传实验报告
                e.Row.Cells[18].Enabled = false;//验收审核
                e.Row.Cells[19].Enabled = false;//验收会签
                e.Row.Cells[20].Enabled = false;//选择验收部门
                e.Row.Cells[21].Enabled = false;//项目批准
                //e.Row.Cells[22].Enabled = false;//上传材料
                e.Row.Cells[23].Enabled = false;//查看验收意见
            }
            if (drv["PRMP_ProjectStates"].ToString().Trim() == "技术副总审核驳回")
            {
                //e.Row.Cells[9].Enabled = false;//修改
                e.Row.Cells[10].Enabled = false;//技术副总审核
                e.Row.Cells[11].Enabled = false;//财务部审核
                e.Row.Cells[12].Enabled = false;//总经理审核
                //e.Row.Cells[13].Enabled = false;//查看审核意见
                e.Row.Cells[14].Enabled = false;//删除
                e.Row.Cells[16].Enabled = false;//上传计划书
                e.Row.Cells[17].Enabled = false;//上传实验报告
                e.Row.Cells[18].Enabled = false;//验收审核
                e.Row.Cells[19].Enabled = false;//验收会签
                e.Row.Cells[20].Enabled = false;//选择验收部门
                e.Row.Cells[21].Enabled = false;//项目批准
                e.Row.Cells[22].Enabled = false;//上传材料
                e.Row.Cells[23].Enabled = false;//查看验收意见
            }
            if (drv["PRMP_ProjectStates"].ToString().Trim() == "技术副总驳回批准")
            {
                e.Row.Cells[9].Enabled = false;//修改
                e.Row.Cells[10].Enabled = false;//技术副总审核
                e.Row.Cells[11].Enabled = false;//财务部审核
                e.Row.Cells[12].Enabled = false;//总经理审核
                //e.Row.Cells[13].Enabled = false;//查看审核意见
                e.Row.Cells[14].Enabled = false;//删除
                e.Row.Cells[16].Enabled = false;//上传计划书
                //e.Row.Cells[17].Enabled = false;//上传验收报告
                e.Row.Cells[18].Enabled = false;//验收审核
                e.Row.Cells[19].Enabled = false;//验收会签
                e.Row.Cells[20].Enabled = false;//选择验收部门
                //e.Row.Cells[21].Enabled = false;//项目批准
                e.Row.Cells[22].Enabled = false;//上传材料
                //e.Row.Cells[23].Enabled = false;//查看验收意见
            }
        }
    }
    protected void Button1_Fid(object sender, EventArgs e)
    {
        try
        {
            Panel_NewProjectInfo.Visible = false;
            UpdatePanel_NewProjectInfo.Update();
            label_XF.Text = "检索";
            Panel_ProductMode.Visible = true;
            BindGridView_ProductMode("");
            UpdatePanel_ProductMode.Update();
        }
        catch (Exception)
        {
            throw;
        }
    }



    //protected void Gridview_ProductMode_DataBound(object sender, EventArgs e)
    //{
    //    ArrayList aList = new ArrayList();
    //    foreach (GridViewRow item in Gridview_ProductMode.Rows)
    //    {
    //        RadioButton rb = item.FindControl("RadioButtonMarkup") as RadioButton;

    //        if (rb.Checked)
    //        {
    //            string index = rb.ID.ToString();
    //            aList.Add(index);
    //        }

    //    }
    //    foreach (GridViewRow item in Gridview_ProductMode.Rows)
    //    {
    //        int i = 0;
    //        for (i = 0; i < aList.Count; i++)
    //        {
    //            if (aList[i] == item.Cells[0].ID)
    //            {
    //                RadioButton rb = item.FindControl("RadioButtonMarkup") as RadioButton;
    //                rb.Checked = true;
    //            }
    //        }
    //    }



    //关闭审核意见查看 
    protected void Close(object sender, EventArgs e)
    {
        Panel1_Check.Visible = false;
        UpdatePanel1_Check.Update();
    }

    private void ShowPanel()//显示上传实验报告框
    {
        string script = "document.getElementById('Div1').style.display='';";
        ScriptManager.RegisterStartupScript(Page, GetType(), "ShowPanel", script, true);
        //this.TextBox18.Text = this.label_AccNum.Text;
        //this.TextBox19.Text = this.label_AccName.Text;
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
    protected void Button1_Fox(object sender, EventArgs e)
    {
        string fileExrensio = Path.GetExtension(FileUpload1.FileName).ToLower();//ToLower转化为小写,获得扩展名
        string UploadURL = Server.MapPath("~/file/");//上传的目录
        string fullname = FileUpload1.FileName;//上传文件的原名
        string newname = DateTime.Now.ToString("yyyyMMddhhmmss");//上传文件重命名

        if (FileUpload1.PostedFile.FileName != "" || FileUpload1.PostedFile.FileName != null)
        {
            if (fileExrensio == ".doc" || fileExrensio == ".docx" || fileExrensio == ".pdf" || fileExrensio == ".xls" || fileExrensio == ".xlsx" || fileExrensio == ".txt" || fileExrensio == ".ppt" || fileExrensio == ".pptx" || fileExrensio == ".zip" || fileExrensio == ".rar" || fileExrensio == ".bmp" || fileExrensio == ".jpg" || fileExrensio == ".gif")//判断文件扩展名
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
              
                if(LabelQ_SaveDirectory.Text == "修改附件")
                {
                    PRMProjectinfo.PRMPA_ID = new Guid(label_AccID.Text.ToString());
                    PRMProjectinfo.PRMPA_Accessory = "是";
                    PRMProjectinfo.PRMPA_AccNum = TextBox18.Text.ToString();
                    PRMProjectinfo.PRMPA_AccName = TextBox19.Text.ToString();
                    PRMProjectinfo.PRMPA_AccPath = filePath;
                    PRMProjectinfo.PRMPA_AccState = "申请材料";
                    prmp.UpdatePRMProjectAccessory(PRMProjectinfo);
                    string condition = " and PRMP_ID='" + new Guid(label_supplytypeid.Text.ToString()) + "'";
                    BindGridview2(condition);
                }
                if(LabelQ_SaveDirectory.Text=="计划书")
                {
                    PRMProjectinfo.PRMP_ID = new Guid(label_supplytypeid.Text.ToString());
                    PRMProjectinfo.PRMPA_Accessory = "是";
                    PRMProjectinfo.PRMPA_AccNum = TextBox18.Text.ToString();
                    PRMProjectinfo.PRMPA_AccName = TextBox19.Text.ToString();
                    PRMProjectinfo.PRMPA_AccPath = filePath;
                    PRMProjectinfo.PRMPA_AccState = "项目计划书";
                    prmp.InsertPRMProjectAccessory(PRMProjectinfo);
                    prmp.UpdatePRMP_ProjectStates(new Guid(label_supplytypeid.Text.ToString()), "计划书已提交");
                    string condition = " and PRMP_ID='" + new Guid(label_supplytypeid.Text.ToString()) + "'";
                    BindGridview2(condition);
                    TextBox18.Text = "";
                    TextBox19.Text = "";
                    ClosePanel();
                    UpdatePanel4.Update();
                    UpdatePanel_Preserve.Update();
                    BindGridView_Projectinfo("");
                    UpdatePanel_ProjectInfo.Update();
                    string Morl = Gridview_ProjectInfo.Rows[Gridview_ProjectInfo.SelectedIndex].Cells[2].Text.ToString();
                    label_RTX.Text = "ERP系统信息：" + Session["UserName"].ToString() + "于" + DateTime.Now + "提交了" +Morl+ "的计划书，请审核。";
                    string message = label_RTX.Text;
                     string sErr=RTXhelper.Send(message, "技术副总项目审核");
                    if (!string.IsNullOrEmpty(sErr))
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
                    }
                }
                if (LabelQ_SaveDirectory.Text == "材料")
                {
                    PRMProjectinfo.PRMP_ID = new Guid(label_supplytypeid.Text.ToString());
                    PRMProjectinfo.PRMPA_Accessory = "是";
                    PRMProjectinfo.PRMPA_AccNum = TextBox18.Text.ToString();
                    PRMProjectinfo.PRMPA_AccName = TextBox19.Text.ToString();
                    PRMProjectinfo.PRMPA_AccPath = filePath;
                    PRMProjectinfo.PRMPA_AccState = "项目材料";
                    prmp.InsertPRMProjectAccessory(PRMProjectinfo);
                    prmp.UpdatePRMP_ProjectStates(new Guid(label_supplytypeid.Text.ToString()), "材料已提交");
                    string condition = " and PRMP_ID='" + new Guid(label_supplytypeid.Text.ToString()) + "'";
                    BindGridview2(condition);
                    TextBox18.Text = "";
                    TextBox19.Text = "";
                    ClosePanel();
                    UpdatePanel4.Update();
                    UpdatePanel_Preserve.Update();
                    BindGridView_Projectinfo("");
                    UpdatePanel_ProjectInfo.Update();
                    string Morl = Gridview_ProjectInfo.Rows[Gridview_ProjectInfo.SelectedIndex].Cells[2].Text.ToString();
                    label_RTX.Text = "ERP系统信息：" + Session["UserName"].ToString() + "于" + DateTime.Now + "提交了" + Morl + "的材料，请审核。";
                    string message = label_RTX.Text;
                    string sErr=RTXhelper.Send(message, "财务部项目审核");
                    if (!string.IsNullOrEmpty(sErr))
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
                    }
                }
                if(LabelQ_SaveDirectory.Text == "验收报告")
                {
                    PRMProjectinfo.PRMP_ID = new Guid(label_supplytypeid.Text.ToString());
                    PRMProjectinfo.PRMPA_Accessory = "是";
                    PRMProjectinfo.PRMPA_AccNum = TextBox18.Text.ToString();
                    PRMProjectinfo.PRMPA_AccName = TextBox19.Text.ToString();
                    PRMProjectinfo.PRMPA_AccPath = filePath;
                    PRMProjectinfo.PRMPA_AccState = "验收报告";
                    prmp.InsertPRMProjectAccessory(PRMProjectinfo);
                    prmp.UpdatePRMP_ProjectStates(new Guid(label_supplytypeid.Text.ToString()), "验收报告已提交");
                string condition = " and PRMP_ID='" + new Guid(label_supplytypeid.Text.ToString()) + "'";
                BindGridview2(condition);
                TextBox18.Text = "";
                TextBox19.Text = "";
                ClosePanel();
                UpdatePanel4.Update();
                UpdatePanel_Preserve.Update();
                BindGridView_Projectinfo("");
                UpdatePanel_ProjectInfo.Update();
                //string conditionn = "and  PRMP_ID='" + new Guid(this.label_supplytypeid.Text.ToString()) + "'";
                //BindGridview4(conditionn);
                //string dep = "";
                //foreach (GridViewRow q in Gridview4.Rows)
                //{
                //    dep += q.Cells[1].Text.ToString() + ",";
                //}
                //dep = dep.Substring(0, dep.Length - 1);
                label_RTX.Text = "ERP系统信息：" + Session["UserName"].ToString() + "于" + DateTime.Now + "提交了" + Gridview_ProjectInfo.Rows[Gridview_ProjectInfo.SelectedIndex].Cells[2].Text.ToString() + "的项目验收报告，请审核。";
               string message = label_RTX.Text;
               string dep = Gridview_ProjectInfo.Rows[Gridview_ProjectInfo.SelectedIndex].Cells[26].Text.ToString();
               string sErr= RTXhelper.SendbyDepAndRole(message, dep, "项目材料维护");
                    
               if (!string.IsNullOrEmpty(sErr))
                {
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
                }
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('请选择验收审核部门！')", true);
                return;
                }
            }
        }
    }
    //关闭附件
    protected void Button1_Emi(object sender, EventArgs e)
    {
        TextBox18.Text = "";
        TextBox19.Text = "";
        ClosePanel();
        UpdatePanel4.Update();
    }

    protected void Gridview2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit1")//编辑附件
        {
        GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
        Gridview2.SelectedIndex = row.RowIndex;
        LabelQ_SaveDirectory.Text = "修改附件";
        label_AccID.Text = e.CommandArgument.ToString();
        string condition = "and PRMPA_ID='" + new Guid(label_AccID.Text) + "'";
        DataSet ds = prmp.SelectPRMProjectAccessory(condition);
        DataTable dt = ds.Tables[0];
            if(dt.Rows.Count>0)
            {
                TextBox18.Text = dt.Rows[0][3].ToString();
                TextBox19.Text = dt.Rows[0][4].ToString();
            }
            ShowPanel();
            UpdatePanel4.Update();
        }
        if (e.CommandName == "Cancel1")//删除
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview2.SelectedIndex = row.RowIndex;
            label_AccID.Text = e.CommandArgument.ToString();
            string[] sg = e.CommandArgument.ToString().Split(new char[] { ',' });

            Guid sc = new Guid(sg[0]);
            PRMProjectinfo.PRMPA_ID = sc;
            prmp.DeletePRMProjectAccessory(PRMProjectinfo);
            if (sg[1] != "")
            {
                string delfile = Server.MapPath("~/") + sg[1];
                File.Delete(delfile);
            }
            string condition = " and PRMP_ID='" + new Guid(label_supplytypeid.Text.ToString()) + "'";
            BindGridview2(condition);
            UpdatePanel_Preserve.Update();
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('删除成功！')", true);
            return;
        }
    }

    protected void Button2_Cancel1(object sender, EventArgs e)
    {
        ClosePanel();
        UpdatePanel4.Update();
        Panel_Preserve.Visible =false;
        UpdatePanel_Preserve.Update();
    }

    protected void CFOPass(object sender, EventArgs e)
    {
        if (TextBox6.Text != "")
        {
            PRMProjectinfo.PRMP_ID = new Guid(label_supplytypeid.Text.ToString());
            PRMProjectinfo.PRMP_CFOCheckOpinion = TextBox6.Text.ToString();
            PRMProjectinfo.PRMP_CFOCheckName = Session["UserName"].ToString();
            PRMProjectinfo.PRMP_CFOCheckResult = "通过";
            prmp.UpdatePRMProjectCFOCheck(PRMProjectinfo);
            prmp.UpdatePRMP_ProjectStates(new Guid(label_supplytypeid.Text.ToString()), "财务部审核通过");
            BindGridView_Projectinfo("");
            UpdatePanel_ProjectInfo.Update();
            TextBox8.Text = "";
            Panel1_Check.Visible = false;
            UpdatePanel1_Check.Update();
            Panel_Sign.Visible = false;
            UpdatePanel_Sign.Update();
            string Morl = Gridview_ProjectInfo.Rows[Gridview_ProjectInfo.SelectedIndex].Cells[2].Text.ToString();
            label_RTX.Text = "ERP系统信息：" + Session["UserName"].ToString() + "于" + DateTime.Now + "审核通过了" + Morl+ "的项目申请单，请审核。";
            string message = label_RTX.Text;
             string sErr=RTXhelper.Send(message, "总经理项目审核");
            if (!string.IsNullOrEmpty(sErr))
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
            }
            
        }
        else
        { 
           ScriptManager.RegisterClientScriptBlock(UpdatePanel1_Check, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                return;
           
        }
    }
    //财务部审核驳回
    protected void CFOReject(object sender, EventArgs e)
    {
        if (TextBox6.Text != "")
        {
            PRMProjectinfo.PRMP_ID = new Guid(label_supplytypeid.Text.ToString());
            PRMProjectinfo.PRMP_CFOCheckOpinion = TextBox6.Text.ToString();
            PRMProjectinfo.PRMP_CFOCheckName = Session["UserName"].ToString();
            PRMProjectinfo.PRMP_CFOCheckResult = "驳回";
            prmp.UpdatePRMProjectCFOCheck(PRMProjectinfo);
            prmp.UpdatePRMP_ProjectStates(new Guid(label_supplytypeid.Text.ToString()), "财务部审核驳回");
            BindGridView_Projectinfo("");
            UpdatePanel_ProjectInfo.Update();
            TextBox8.Text = "";
            Panel1_Check.Visible = false;
            UpdatePanel1_Check.Update();
            Panel_Sign.Visible = false;
            UpdatePanel_Sign.Update();
            string Morl = Gridview_ProjectInfo.Rows[Gridview_ProjectInfo.SelectedIndex].Cells[2].Text.ToString();
            label_RTX.Text = "ERP系统信息：" + Session["UserName"].ToString() + "于" + DateTime.Now + "审核驳回了" + Morl + "的项目申请单，请审核。";
          string message = label_RTX.Text;
          string dep = Gridview_ProjectInfo.Rows[Gridview_ProjectInfo.SelectedIndex].Cells[26].Text.ToString();
          string sErr = RTXhelper.SendbyDepAndRole(message, dep, "项目材料维护");
            if (!string.IsNullOrEmpty(sErr))
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1_Check, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;

        }
    }

    protected void CFOCanel(object sender, EventArgs e)
    {
        TextBox6.Text = "";
        Panel1_Check.Visible = false;
        UpdatePanel1_Check.Update();
        Panel_Sign.Visible = false;
        UpdatePanel_Sign.Update();
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
        if (TextBox22.Text != "")
        {
            item += "and BDOS_Name like'%" + TextBox22.Text + "%'";
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
    //提交勾选部门
    protected void Button_ComSPP(object sender, EventArgs e)
    {
        bool temp = false;
        foreach (GridViewRow item in Gridview3.Rows)
        {
            CheckBox rb = item.FindControl("CheckMarkup") as CheckBox;
            if (rb.Checked)
            {
                string condition = "and PRMP_ID='" + label_supplytypeid.Text.ToString() + "'" + "and PRMPC_SignPartment='" + Gridview3.Rows[item.RowIndex].Cells[2].Text.ToString()+"'";
               DataSet  ds=prmp.SelectPRMProjectCountersign(condition);
               DataTable dt = ds.Tables[0];
               if (dt.Rows.Count > 0)
               {
                   ScriptManager.RegisterClientScriptBlock(Page, GetType(), "aa", "alert('会签部门不能重复！')", true);
                   return;
               }
               else
               {
                   PRMProjectinfo.PRMP_ID = new Guid(label_supplytypeid.Text.ToString());
                   PRMProjectinfo.PRMPC_SignPartment = Gridview3.Rows[item.RowIndex].Cells[2].Text.ToString();
                   prmp.InsertPRMProjectCountersign(PRMProjectinfo);
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
            //this.TextBox22.Text = this.Label_Org.Text.ToString();
            //this.UpdatePanel_Spl_New.Update();
            Panel_Org.Visible = false;
            UpdatePanel_Org.Update();
        }
    }
   //关闭部门查询
    protected void Button_CancelSPP(object sender, EventArgs e)
    {
        Panel_Org.Visible = false;
        UpdatePanel_Org.Update();
    }
    //验收会签表
    protected void Gridview4_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName=="Myloo")//查看会签
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview4.SelectedIndex = row.RowIndex;
            label41.Visible = true;
            Label42.Visible = true;
            label43.Visible = true;
            label44.Visible = true;
            TextBox15.Enabled = false;
            label49.Visible = true;
            Label57.Visible = true;
            label58.Visible = true;
            label59.Visible = true;
            TextBox7.Enabled = false;
            label_Coutersign.Text = e.CommandArgument.ToString();
            string condition="and PRMPC_ID='"+new Guid(label_Coutersign.Text)+"'";
            DataSet ds = prmp.SelectPRMProjectCountersign(condition);
            DataTable dt = ds.Tables[0];
            if(dt.Rows.Count>0)
            {
                label40.Text = dt.Rows[0][2].ToString()+"会签";
                label41.Text = dt.Rows[0][3].ToString();
                label43.Text = dt.Rows[0][5].ToString();
                label44.Text = dt.Rows[0][6].ToString();
                TextBox15.Text = dt.Rows[0][4].ToString();
            }
            Guid  PRMP_ID=new Guid(label_supplytypeid.Text.ToString());
            DataSet dss = prmp.SelectPRMProject_One(PRMP_ID);
            DataTable dtt = dss.Tables[0];
            if(dtt.Rows.Count>0)
            {
                label46.Text = dtt.Rows[0][2].ToString() + "  " + Session["Department"].ToString() + "验收审核";
                label49.Text = dtt.Rows[0][13].ToString();
                label58.Text = dtt.Rows[0][12].ToString();
                label59.Text = dtt.Rows[0][11].ToString();
                TextBox7.Text=dtt.Rows[0][10].ToString();
            }
            Panel1.Visible = true;
            Panel4.Visible = true;
            Panel2.Visible = true;
            Button22.Visible = false ;
            Button23.Visible =false ;
            Button24.Visible = false ;
            Button30.Visible = true;
            UpdatePanel2.Update();
        }
        if (e.CommandName == "Mylloo")//会签
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview4.SelectedIndex = row.RowIndex;
            if (Session["Department"].ToString() == Gridview4.Rows[Gridview4.SelectedIndex].Cells[1].Text.ToString())
            {
                labelCheckState.Text = "会签";
                label41.Visible = false;
                Label42.Visible = false;
                label43.Visible = false;
                label44.Visible = false;
                TextBox15.Enabled = true;
                label49.Visible = true;
                Label57.Visible = true;
                label58.Visible = true;
                label59.Visible = true;
                TextBox7.Enabled = false;
                TextBox15.Text = "";
                label_Coutersign.Text = e.CommandArgument.ToString();
                Guid PRMP_ID = new Guid(label_supplytypeid.Text.ToString());
                DataSet dss = prmp.SelectPRMProject_One(PRMP_ID);
                DataTable dtt = dss.Tables[0];
                if (dtt.Rows.Count > 0)
                {
                    label46.Text = dtt.Rows[0][2].ToString() + "  " + Session["Department"].ToString() + "验收审核";
                    label49.Text = dtt.Rows[0][13].ToString();
                    label58.Text = dtt.Rows[0][12].ToString();
                    label59.Text = dtt.Rows[0][11].ToString();
                    TextBox7.Text = dtt.Rows[0][10].ToString();
                }
                label40.Text = Session["Department"].ToString() + "会签";
                Panel1.Visible = true;
                Panel4.Visible = true;
                Panel2.Visible = true;
                Button22.Visible = true;
                Button23.Visible = true;
                Button24.Visible = true;
                Button30.Visible = false;
                UpdatePanel2.Update();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "aa", "alert('你没有此权限！')", true);
                return;
            }
           
        }
        if (e.CommandName == "Miko")//删除
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview4.SelectedIndex = row.RowIndex;
            label_Coutersign.Text = e.CommandArgument.ToString();
            PRMProjectinfo.PRMPC_ID = new Guid(label_Coutersign.Text.ToString());
            prmp.DeletePRMProjectCountersign(PRMProjectinfo);
            string condition = "and  PRMP_ID='" + new Guid(label_supplytypeid.Text.ToString()) + "'";
            BindGridview4(condition);
            Panel_Sign.Visible = true;
            UpdatePanel_Sign.Update();
        }
    }
    //会签、审核通过
    protected void ButtonPass(object sender, EventArgs e)
    {
        if(labelCheckState.Text=="审核")
        {
            PRMProjectinfo.PRMP_ID = new Guid(label_supplytypeid.Text.ToString());
            PRMProjectinfo.PRMP_ReDepartCheckMan = Session["UserName"].ToString();
            PRMProjectinfo.PRMP_ReDepartCheckOpinion = TextBox7.Text.ToString();
            PRMProjectinfo.PRMP_ReDepartCheckResult = "通过";
            prmp.UpdatePRMProjectResponDepart(PRMProjectinfo);
            prmp.UpdatePRMP_ProjectStates(PRMProjectinfo.PRMP_ID,"责任部门审核通过");
            string conditionn = "and  PRMP_ID='" + new Guid(label_supplytypeid.Text.ToString()) + "'";
            BindGridview4(conditionn);
            string dep = "";
            foreach (GridViewRow q in Gridview4.Rows)
            {
                dep += q.Cells[1].Text.ToString() + ",";
            }
            dep = dep.Substring(0, dep.Length - 1);
            label_RTX.Text = "ERP系统信息：" + Session["UserName"].ToString() + "于" + DateTime.Now + "提交了" + Gridview_ProjectInfo.Rows[Gridview_ProjectInfo.SelectedIndex].Cells[2].Text.ToString() + "的项目验收报告，请审核。";
             string message = label_RTX.Text;
              string sErr=RTXhelper.SendbyDepAndRole(message, dep, "项目验收审核");
            if (!string.IsNullOrEmpty(sErr))
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
            }
        }
        if (labelCheckState.Text == "会签")
        {
            PRMProjectinfo.PRMPC_ID = new Guid(label_Coutersign.Text.ToString());
            PRMProjectinfo.PRMPC_SignMan = Session["UserName"].ToString();
            PRMProjectinfo.PRMPC_SignOpinion = TextBox15.Text.ToString();
            PRMProjectinfo.PRMPC_SignResult = "通过";
            prmp.UpdatePRMProjectCountersign(PRMProjectinfo);
            int i = 0;
            string conditionn = "and  PRMP_ID='" + new Guid(label_supplytypeid.Text.ToString()) + "'";
            BindGridview4(conditionn);
            foreach(GridViewRow item in Gridview4.Rows)
            {
            if(item.Cells[2].Text=="通过")
            {
                i = i + 1;
            }
            if (item.Cells[2].Text == "驳回")
                {
                    i = -1;
                }
            }
            if (i == Gridview4.Rows.Count)
            {
                prmp.UpdatePRMP_ProjectStates(new Guid(label_supplytypeid.Text.ToString()), "验收会签通过");
                string Morl = Gridview_ProjectInfo.Rows[Gridview_ProjectInfo.SelectedIndex].Cells[2].Text.ToString();
                label_RTX.Text = "ERP系统信息：" + Morl + "于" + DateTime.Now + "会签通过，请查看。";
                string message = label_RTX.Text;
                 string sErr=RTXhelper.Send(message, "项目批准");
                if (!string.IsNullOrEmpty(sErr))
                {
                    ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
                }
            }
            if (i < Gridview4.Rows.Count&&i!=-1)
            {
                prmp.UpdatePRMP_ProjectStates(new Guid(label_supplytypeid.Text.ToString()), "验收会签中");
            }

        }
        string condition = "and  PRMP_ID='" + new Guid(label_supplytypeid.Text.ToString()) + "'";
        BindGridview4(condition);
        UpdatePanel_Sign.Update();
        BindGridView_Projectinfo("");
        UpdatePanel_ProjectInfo.Update();
        TextBox15.Text = "";
        TextBox7.Text = "";
        Panel1.Visible = false;
        Panel2.Visible = false;
        Panel4.Visible = false;
        UpdatePanel2.Update();
    }
    //会签、审核驳回
    protected void ButtonUnpass(object sender, EventArgs e)
    {
        if (labelCheckState.Text == "审核")
        {
            PRMProjectinfo.PRMP_ID = new Guid(label_supplytypeid.Text.ToString());
            PRMProjectinfo.PRMP_ReDepartCheckMan = Session["UserName"].ToString();
            PRMProjectinfo.PRMP_ReDepartCheckOpinion = TextBox7.Text.ToString();
            PRMProjectinfo.PRMP_ReDepartCheckResult = "驳回";
            prmp.UpdatePRMProjectResponDepart(PRMProjectinfo);
            prmp.UpdatePRMP_ProjectStates(new Guid(label_supplytypeid.Text.ToString()), "责任部门审核驳回");
        }
        if (labelCheckState.Text == "会签")
        {
            PRMProjectinfo.PRMPC_ID = new Guid(label_Coutersign.Text.ToString());
            PRMProjectinfo.PRMPC_SignMan = Session["UserName"].ToString();
            PRMProjectinfo.PRMPC_SignOpinion = TextBox15.Text.ToString();
            PRMProjectinfo.PRMPC_SignResult = "驳回";
            prmp.UpdatePRMProjectCountersign(PRMProjectinfo);
            prmp.UpdatePRMP_ProjectStates(new Guid(label_supplytypeid.Text.ToString()), "验收会签驳回");
        }
       
        BindGridView_Projectinfo("");
        UpdatePanel_ProjectInfo.Update();
        TextBox15.Text = "";
        TextBox7.Text = "";
        Panel1.Visible = false;
        Panel2.Visible = false;
        UpdatePanel2.Update();
        string Morl = Gridview_ProjectInfo.Rows[Gridview_ProjectInfo.SelectedIndex].Cells[2].Text.ToString();
        label_RTX.Text = "ERP系统信息：" + Session["UserName"].ToString() + "于" + DateTime.Now + "审核驳回了" +Morl+ "的项目申请单，请查看。";
         string message = label_RTX.Text;
         string dep = Gridview_ProjectInfo.Rows[Gridview_ProjectInfo.SelectedIndex].Cells[26].Text.ToString();
         string sErr = RTXhelper.SendbyDepAndRole(message, dep, "项目材料维护");
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
        }
    }
    //会签、审核关闭
    protected void ButtonClose(object sender, EventArgs e)
    {
        TextBox15.Text = "";
        TextBox7.Text = "";
        Panel1.Visible = false;
        Panel2.Visible = false;
        Panel4.Visible = false;
        UpdatePanel2.Update();
    }
    protected void Button_CClose(object sender, EventArgs e)
    {
        TextBox15.Text = "";
        TextBox7.Text = "";
        Panel1.Visible = false;
        Panel2.Visible = false;
        Panel4.Visible = false;
        UpdatePanel2.Update();
    }

    protected void Button_Ccl(object sender, EventArgs e)
    {
        TextBox15.Text = "";
        TextBox7.Text = "";
        Panel1.Visible = false;
        Panel2.Visible = false;
        Panel4.Visible = false;
        UpdatePanel2.Update();
        Panel_Sign.Visible = false;
        UpdatePanel_Sign.Update();
        Panel1_Check.Visible = false;
        UpdatePanel1_Check.Update();
    }


    protected void Gridview4_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            DataRowView drv = (DataRowView)e.Row.DataItem;
            if (drv["PRMPC_SignResult"].ToString().Trim() != "")
            {
                e.Row.Cells[8].Enabled = false;
            }
        }
    }
    //检索产品型号
    protected void Button1_KiM(object sender, EventArgs e)
    {
        string condition = GetProduct();
        BindGridView_ProductMode(condition);
        UpdatePanel_ProductMode.Update();
    }
    private string GetProduct()
    {
        string condition = "";
        if(TextBox16.Text!="")
        {
        condition+=" and PT_Name='"+TextBox16.Text+"'";
        }
        return condition;
    }
    //重置检索产品信号
    protected void Button_CoM(object sender, EventArgs e)
    {
        TextBox16.Text = "";
        BindGridView_ProductMode("");
        UpdatePanel_ProductMode.Update();
    }

}


