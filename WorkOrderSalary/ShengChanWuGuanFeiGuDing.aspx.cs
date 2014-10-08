using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RTXHelper;
public partial class WorkOrderSalary_ShengChanWuGuanFeiGuDing : System.Web.UI.Page
{
    WOSSalaryL wosl = new WOSSalaryL();
    WSD ws = new WSD();
    UserD Us = new UserD();
    CSD cs = new CSD();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
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
                this.Title = "生产无关非固定计时查看";
                Button_AddTeam.Visible = false;
                GridView_WOmain.Columns[0].Visible = false;
                GridView_WOmain.Columns[22].Visible = false;//编辑
                GridView_WOmain.Columns[23].Visible = false;//删除
                GridView1.Columns[0].Visible = false;

                GridView1.Columns[5].Visible = false;
                GridView1.Columns[7].Visible = false;

                Button10.Visible = false;
                Label13.Visible = false;
                Label14.Visible = false;
                Button_AddPTToSeries.Visible = false;

                CheckBox2.Visible = false;
                Checkfanxuan2.Visible = false;


                CheckBoxAll.Visible = false;
                CheckBoxfanxuan.Visible = false;
                Btn_deleting.Visible = false;
                Btn_deleting0.Visible = false;
                Btn_deleting1.Visible = false;
                TextBox4.Enabled = false;
                Button5.Visible = false;
                Button9.Visible = false;
                TextBox3.Enabled = false;
                sctg.Visible = false;
                scbh.Visible = false;
                TextBox3.Enabled = false;
                sctg.Visible = false;
                scbh.Visible = false;
                TextBox7.Enabled = false;
                pbtg.Visible = false;
                pbbh.Visible = false;
            }
            if (state.Trim() == "make")
            {
                this.Title = "生产无关非固定计时提报";
                
                //    GridView1.Columns[0].Visible = false;//详细表check
                GridView1.Columns[4].Visible = false; //时间Label
                GridView1.Columns[6].Visible = false;//数量Label

                GridView_WOmain.Columns[0].Visible = false;//主表check
                Button_AddPTToSeries.Visible = false;//批量审核

                Label13.Visible = false;
                Label14.Visible = false;
                // CheckBoxAll.Visible = false;//详细表全选
                //CheckBoxfanxuan.Visible = false;//详细表全不选
                // Btn_deleting.Visible = false; 删除
                //Btn_deleting0.Visible = false; 提交
                //Btn_deleting1.Visible = false; 保存
                CheckBox2.Visible = false;//主表全选 
                Checkfanxuan2.Visible = false;//主表反选
                //审核的权限
                TextBox4.Enabled = false;
                Button5.Visible = false;
                Button9.Visible = false;
                TextBox3.Enabled = false;
                sctg.Visible = false;
                scbh.Visible = false;
                TextBox3.Enabled = false;
                sctg.Visible = false;
                scbh.Visible = false;
                TextBox7.Enabled = false;
                pbtg.Visible = false;
                pbbh.Visible = false;
            }

            if (state.Trim() == "cs")
            {
                this.Title = "生产无关非固定计时初审";
                Button_AddTeam.Visible = false;
                GridView_WOmain.Columns[22].Visible = false;//编辑
                GridView_WOmain.Columns[23].Visible = false;//删除
                GridView1.Columns[0].Visible = false;//详细表check
                GridView1.Columns[4].Visible = true; //时间Label
                GridView1.Columns[6].Visible = true;//数量Label
                GridView1.Columns[5].Visible = true; //时
                GridView1.Columns[7].Visible = true;//数量
                Label13.Visible = false;
                Label14.Visible = false;
                // GridView_WOmain.Columns[0].Visible = false;//主表check
                // Button_AddPTToSeries.Visible = false;//批量审核


                // CheckBoxAll.Visible = false;//详细表全选
                //CheckBoxfanxuan.Visible = false;//详细表全不选
                // Btn_deleting.Visible = false; 删除
                //Btn_deleting0.Visible = false; 提交
                //Btn_deleting1.Visible = false; 保存
                // CheckBox2.Visible = false;//主表全选 
                // Checkfanxuan2.Visible = false;//主表反选
                //审核的权限
                TextBox4.Enabled = false;
                Button5.Visible = false;
                Button9.Visible = false;
                TextBox3.Enabled = false;
                sctg.Visible = false;
                scbh.Visible = false;
                TextBox3.Enabled = false;
                sctg.Visible = false;
                scbh.Visible = false;
                TextBox7.Enabled = false;
                pbtg.Visible = false;
                pbbh.Visible = false;
            }

            if (state.Trim() == "rs")
            {
                this.Title = "生产无关非固定计时人事审核";
                Button_AddTeam.Visible = false;
                GridView_WOmain.Columns[22].Visible = false;//编辑
                GridView_WOmain.Columns[23].Visible = false;//删除
                GridView1.Columns[0].Visible = false;//详细表check
                GridView1.Columns[4].Visible = true; //时间Label
                GridView1.Columns[6].Visible = true;//数量Label
                GridView1.Columns[5].Visible = true; //时
                GridView1.Columns[7].Visible = true;//数量
                Button_AddPTToSeries.Text = "人事审核";
                // GridView_WOmain.Columns[0].Visible = false;//主表check
                // Button_AddPTToSeries.Visible = false;//批量审核

                Label13.Visible = false;
                Label14.Visible = false;
                // CheckBoxAll.Visible = false;//详细表全选
                //CheckBoxfanxuan.Visible = false;//详细表全不选
                // Btn_deleting.Visible = false; 删除
                //Btn_deleting0.Visible = false; 提交
                //Btn_deleting1.Visible = false; 保存
                // CheckBox2.Visible = false;//主表全选 
                // Checkfanxuan2.Visible = false;//主表反选
                //审核的权限
                TextBox4.Enabled = false;
                Button5.Visible = false;
                Button9.Visible = false;
                TextBox3.Enabled = false;
                sctg.Visible = false;
                scbh.Visible = false;
                TextBox3.Enabled = false;
                sctg.Visible = false;
                scbh.Visible = false;
                TextBox7.Enabled = false;
                pbtg.Visible = false;
                pbbh.Visible = false;
            }
            if (state.Trim() == "cw")
            {
                this.Title = "生产无关非固定计时人事审核";
                Button_AddTeam.Visible = false;
                GridView_WOmain.Columns[22].Visible = false;//编辑
                GridView_WOmain.Columns[23].Visible = false;//删除
                GridView1.Columns[0].Visible = false;//详细表check
                GridView1.Columns[4].Visible = true; //时间Label
                GridView1.Columns[6].Visible = true;//数量Label
                GridView1.Columns[5].Visible = true; //时
                GridView1.Columns[7].Visible = true;//数量
                Button_AddPTToSeries.Text = "财务审核";
                // GridView_WOmain.Columns[0].Visible = false;//主表check
                // Button_AddPTToSeries.Visible = false;//批量审核
                Label13.Visible = false;
                Label14.Visible = false;

                // CheckBoxAll.Visible = false;//详细表全选
                //CheckBoxfanxuan.Visible = false;//详细表全不选
                // Btn_deleting.Visible = false; 删除
                //Btn_deleting0.Visible = false; 提交
                //Btn_deleting1.Visible = false; 保存
                // CheckBox2.Visible = false;//主表全选 
                // Checkfanxuan2.Visible = false;//主表反选
                //审核的权限
                TextBox4.Enabled = false;
                Button5.Visible = false;
                Button9.Visible = false;
                TextBox3.Enabled = false;
                sctg.Visible = false;
                scbh.Visible = false;
                TextBox3.Enabled = false;
                sctg.Visible = false;
                scbh.Visible = false;
                TextBox7.Enabled = false;
                pbtg.Visible = false;
                pbbh.Visible = false;
            }
            databind_zhubiao();
        }
    }

    public void databind_zhubiao()
    {
        //string bm;
        string condition;
        // if(label_pagestate.Text.Trim()=="cs")
        // {

        //  }

        string STI_Name = TextBox_xiangmu.Text.Trim() == "" ? " and 1=1 " : " and STI_Name like '%" + TextBox_xiangmu.Text.Trim() + "%' ";
        string BDOS_Name = TextBox_chusheng.Text.Trim() == "" ? " and 1=1 " : " and BDOS_Name like '%" + TextBox_chusheng.Text.Trim() + "%' ";
        string TNUT_NO = TextBox_NO.Text.Trim() == "" ? " and 1=1 " : " and TNUT_NO like '%" + TextBox_NO.Text.Trim() + "%' ";
        string TNUT_State = DropDownList1.SelectedItem.Text.Trim() == "请选择" ? " and 1=1 " : " and TNUT_State like '%" + DropDownList1.SelectedItem.Text.Trim() + "%' ";
        string TNUT_SubmitMan = TextBox_tibaoren.Text.Trim() == "" ? " and 1=1 " : " and TNUT_SubmitMan like '%" + TextBox_tibaoren.Text.Trim() + "%' ";
        string TNUT_Auditor = TextBox_chushengren.Text.Trim() == "" ? " and 1=1 " : " and TNUT_Auditor like '%" + TextBox_chushengren.Text.Trim() + "%' ";
        string TNUT_RSAuditor = TextBox_renshishenghe.Text.Trim() == "" ? " and 1=1 " : " and TNUT_RSAuditor like '%" + TextBox_renshishenghe.Text.Trim() + "%' ";
        string TNUT_CWAuditor = TextBox_caiwuren.Text.Trim() == "" ? " and 1=1 " : " and TNUT_CWAuditor like '%" + TextBox_caiwuren.Text.Trim() + "%' ";
        if ((TextBox_WO_Time1.Text != "" && TextBox_WO_Time2.Text == "") || (TextBox_WO_Time1.Text == "" && TextBox_WO_Time2.Text != ""))
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请将提报单日期检索范围输入完整，请您再次核对！')", true);
            return;
        }
        string TNUT_Date = (TextBox_WO_Time1.Text.Trim() == "" && TextBox_WO_Time2.Text.Trim() == "") ? " and 1=1 " : " and TNUT_Date between   ' " + TextBox_WO_Time1.Text.Trim() + "' and ' " + TextBox_WO_Time2.Text.Trim() + "'";
        if ((TextBox_tibaoshijian1.Text != "" && TextBox_tibaoshijian2.Text == "") || (TextBox_tibaoshijian1.Text == "" && TextBox_tibaoshijian2.Text != ""))
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请将提报时间检索范围输入完整，请您再次核对！')", true);
            return;
        }
        string TNUT_SubmitTime = (TextBox_tibaoshijian1.Text.Trim() == "" && TextBox_tibaoshijian2.Text.Trim() == "") ? " and 1=1 " : " and TNUT_SubmitTime between   ' " + TextBox_tibaoshijian1.Text.Trim() + "' and ' " + TextBox_tibaoshijian2.Text.Trim() + "'";

        if ((TextBox_chushengshijian1.Text != "" && TextBox_chushengshijian2.Text == "") || (TextBox_chushengshijian1.Text == "" && TextBox_chushengshijian2.Text != ""))
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请将初审时间检索范围输入完整，请您再次核对！')", true);
            return;
        }
        string TNUT_AuTime = (TextBox_chushengshijian1.Text.Trim() == "" && TextBox_chushengshijian2.Text.Trim() == "") ? " and 1=1 " : " and TNUT_AuTime between   ' " + TextBox_chushengshijian1.Text.Trim() + "' and ' " + TextBox_chushengshijian2.Text.Trim() + "'";

        if ((TextBox_renshishijian1.Text != "" && TextBox_renshishijian2.Text == "") || (TextBox_renshishijian1.Text == "" && TextBox_renshishijian2.Text != ""))
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请将人事审核时间检索范围输入完整，请您再次核对！')", true);
            return;
        }
        string TNUT_RSTime = (TextBox_renshishijian1.Text.Trim() == "" && TextBox_renshishijian2.Text.Trim() == "") ? " and 1=1 " : " and TNUT_RSTime between   ' " + TextBox_renshishijian1.Text.Trim() + "' and ' " + TextBox_renshishijian2.Text.Trim() + "'";


        if ((TextBox_caiwushijian1.Text != "" && TextBox_caiwushijian2.Text == "") || (TextBox_caiwushijian1.Text == "" && TextBox_caiwushijian2.Text != ""))
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请将财务审核时间检索范围输入完整，请您再次核对！')", true);
            return;
        }
        string TNUT_CWTime = (TextBox_caiwushijian1.Text.Trim() == "" && TextBox_caiwushijian2.Text.Trim() == "") ? " and 1=1 " : " and TNUT_CWTime between   ' " + TextBox_caiwushijian1.Text.Trim() + "' and ' " + TextBox_caiwushijian2.Text.Trim() + "'";

        condition = STI_Name + BDOS_Name + TNUT_NO + TNUT_State + TNUT_SubmitMan + TNUT_Auditor + TNUT_RSAuditor + TNUT_CWAuditor
            + TNUT_Date + TNUT_SubmitTime + TNUT_AuTime + TNUT_RSTime + TNUT_CWTime;

        GridView_WOmain.DataSource = ws.S_TimeNoUnfixedTable(condition);
        GridView_WOmain.DataBind();
        UpdatePanel_WOmain.Update();
    }
    public void databind3()
    {
        string condition;
        string PBC_Name = TextBox_AddProject_Craft.Text.Trim() == "" ? " and 1=1 " : " and PBC_Name like '%" + TextBox_AddProject_Craft.Text.Trim() + "%' ";
        string STI_Name = TextBox_AddProject_Project.Text.Trim() == "" ? " and 1=1 " : " and STI_Name like '%" + TextBox_AddProject_Project.Text.Trim() + "%' ";
        condition = PBC_Name + STI_Name;
        GridView_AddProject.DataSource = wosl.S_TimeSalaryDateDetail_SalaryTimeItem("00000000-0000-0000-0000-000000000000", condition);
        GridView_AddProject.DataBind();
        UpdatePanel_AddProject.Update();
    }
    public void databind_detail()
    {
        string condition;
        string HRDD_StaffNO = TextBox1.Text.Trim() == "" ? " and 1=1 " : " and HRDD_StaffNO like '%" + TextBox1.Text.Trim() + "%' ";
        string HRDD_Name = TextBox2.Text.Trim() == "" ? " and 1=1 " : " and HRDD_Name like '%" + TextBox2.Text.Trim() + "%' ";
        condition = HRDD_StaffNO + HRDD_Name;
        GridView1.DataSource = ws.S_TimeNoUnfixedDetail(Label_TNUT_ID.Text.Trim(), condition);
        GridView1.DataBind();
        UpdatePanel1.Update();
    }
    public void databind4()
    {

        string condition;
        string HRDD_StaffNO = TextBox5.Text.Trim() == "" ? " and 1=1 " : " and HRDD_StaffNO like '%" + TextBox5.Text.Trim() + "%' ";
        string HRDD_Name = TextBox6.Text.Trim() == "" ? " and 1=1 " : " and HRDD_Name like '%" + TextBox6.Text.Trim() + "%' ";
        condition = HRDD_StaffNO + HRDD_Name;
        if (DropDownList3.SelectedIndex == 0)
        {
            DataSet ds2 = cs.CS_S_HRDDetail_people(" and a.HRDD_ID not in (select HRDD_ID from TimeNoUnfixedDetail where TNUT_ID ='" + this.Label_TNUT_ID.Text.Trim() + "') " + condition);
            GridView_People.DataSource = ds2;
            GridView_People.DataBind();
            UpdatePanel_AddPeople.Update();

        }
        else
        {

            DataSet ds3 = cs.Cs_S_WorkTeamDetailList(" and WT_ID='" + this.DropDownList3.SelectedValue.ToString().Trim() + "'" + " and a.HRDD_ID not in (select HRDD_ID from TimeNoUnfixedDetail where TNUT_ID ='" + Label_TNUT_ID.Text.Trim() + "') " + condition);
            GridView_People.DataSource = ds3;
            GridView_People.DataBind();
            UpdatePanel_AddPeople.Update();

        }
    }
    protected void Btn_Search_Click(object sender, EventArgs e)//检索主表
    {
        databind_zhubiao();
        Panel_NewProjectInfo.Visible = false;
        Panel_AddProject.Visible = false;
        UpdatePanel_NewProjectInfo.Update();
        UpdatePanel_AddProject.Update();
    }
    protected void CanelProject(object sender, EventArgs e)
    {

    }
    protected void Button8_Click(object sender, EventArgs e)//选择计时项目
    {
        Panel_AddProject.Visible = true;
        UpdatePanel_AddProject.Update();
        databind3();
    }
    protected void Button_AddTeam_Click(object sender, EventArgs e)//新增提报单
    {
        TextBox_WO_Time12.Text = "";
        TextBox_makepeople7.Text = "";
        Label17.Text = "";
        Label1.Text = "新增提报信息";
        SqlDataReader myReader = Us.Query_Organization();
        DropDownList2.Items.Clear();
        DropDownList2.Items.Add(new ListItem("所有部门", "null"));//增加I
        while (myReader.Read())
        {
            DropDownList2.Items.Add(new ListItem(myReader["BDOS_Name"].ToString(), myReader["BDOS_Code"].ToString()));//增加Item
        }
        Panel_NewProjectInfo.Visible = true;
        UpdatePanel_NewProjectInfo.Update();
        Panel_AddProject.Visible = false;
        UpdatePanel_AddProject.Update();
        Panel_AddPeople.Visible = false;
        UpdatePanel_AddPeople.Update();
        Panel1.Visible = false;
        Panel3.Visible = false;
        UpdatePanel1.Update();
    }
    public void clear()
    {
        TextBox_xiangmu.Text = "";
        TextBox_chusheng.Text = "";
        TextBox_NO.Text = "";
        DropDownList1.SelectedIndex = 0;
        TextBox_tibaoren.Text = "";
        TextBox_chushengren.Text = "";
        TextBox_renshishenghe.Text = "";
        TextBox_caiwuren.Text = "";
        TextBox_WO_Time1.Text = "";
        TextBox_WO_Time2.Text = "";
        TextBox_tibaoshijian1.Text = "";
        TextBox_tibaoshijian1.Text = "";
        TextBox_chushengshijian1.Text = "";
        TextBox_chushengshijian2.Text = "";
        TextBox_renshishijian1.Text = "";
        TextBox_renshishijian2.Text = "";
        TextBox_caiwushijian1.Text = "";
        TextBox_caiwushijian2.Text = "";
    }

    protected void Button_Cancel_Click(object sender, EventArgs e)//主表重置
    {
        clear();
        Panel_NewProjectInfo.Visible = false;
        UpdatePanel_NewProjectInfo.Update();
        Panel_AddProject.Visible = false;
        UpdatePanel_AddProject.Update();
        Panel_AddPeople.Visible = false;
        UpdatePanel_AddPeople.Update();
        Panel1.Visible = false;
        Panel3.Visible = false;
        UpdatePanel1.Update();
        databind_zhubiao();
    }
    protected void ConfirmProject(object sender, EventArgs e)
    {

    }

    protected void Button6_Click(object sender, EventArgs e)//提交新增计时项目信息
    {
        if (Label1.Text.Contains("新增"))
        {
            if (TextBox_WO_Time12.Text == "" || TextBox_makepeople7.Text == "" || DropDownList2.SelectedIndex == 0)
            {

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('*为必填项！请您再核对！')", true);
                return;
            }
            try
            {
                ws.I_TimeNoUnfixedTable(new Guid(Label17.Text.Trim()), Convert.ToDateTime(TextBox_WO_Time12.Text.Trim()), Session["UserName"].ToString().Trim(), DropDownList2.SelectedValue.ToString().Trim());
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('新增成功！')", true);

            }
            catch (Exception)
            {

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('新增失败，请核对提报日期的输入为日期格式！')", true);
                return;
            }
            Panel_NewProjectInfo.Visible = false;
            UpdatePanel_NewProjectInfo.Update();
            Panel_AddProject.Visible = false;
            UpdatePanel_AddProject.Update();
            databind_zhubiao();
        }
        if (Label1.Text.Contains("编辑"))
        {
            if (TextBox_WO_Time12.Text == "" || TextBox_makepeople7.Text == "" || DropDownList2.SelectedIndex == 0)
            {

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('*为必填项！请您再核对！')", true);
                return;
            }
            try
            {
                ws.U_TimeNoUnfixedTable(new Guid(Label_TNUTID_EDIT.Text.Trim()), new Guid(Label17.Text.Trim()), Convert.ToDateTime(TextBox_WO_Time12.Text.Trim()), Session["UserName"].ToString().Trim(), DropDownList2.SelectedValue.ToString().Trim());
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('编辑成功！')", true);

            }
            catch (Exception)
            {

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('编辑失败，请核对提报日期的输入为日期格式！')", true);
                return;
            }
            Panel_NewProjectInfo.Visible = false;
            UpdatePanel_NewProjectInfo.Update();
            Panel_AddProject.Visible = false;
            UpdatePanel_AddProject.Update();
            databind_zhubiao();
        }


    }
    protected void Button7_Click(object sender, EventArgs e)//关闭提报项目
    {
        Panel_NewProjectInfo.Visible = false;
        UpdatePanel_NewProjectInfo.Update();
        Panel_AddProject.Visible = false;
        UpdatePanel_AddProject.Update();
    }
    protected void Button_AddProject_Search_Click(object sender, EventArgs e)//检索计时项目
    {
        GridView_AddProject.PageIndex = 0;
        databind3();

    }
    protected void ButtonButton_AddProject_Cancel_Click(object sender, EventArgs e)//重置检索计时项目
    {
        TextBox_AddProject_Craft.Text = "";
        TextBox_AddProject_Project.Text = "";
        GridView_AddProject.PageIndex = 0;
        databind3();
    }
    protected void Button_Close_Click(object sender, EventArgs e)//关闭计时项目待选
    {
        Panel_AddProject.Visible = false;
        UpdatePanel_AddProject.Update();
    }
    protected void GridView_AddProject_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "xz")//
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            //    string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            Label17.Text = GridView_AddProject.DataKeys[row.RowIndex].Values["STI_ID"].ToString();
            TextBox_makepeople7.Text = GridView_AddProject.DataKeys[row.RowIndex].Values["STI_Name"].ToString(); ;
            Panel_AddProject.Visible = false;
            UpdatePanel_AddProject.Update();
            UpdatePanel_NewProjectInfo.Update();
        }
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
        databind3();

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
        databind_zhubiao();
        Panel_NewProjectInfo.Visible = false;
        UpdatePanel_NewProjectInfo.Update();
        Panel_AddProject.Visible = false;
        UpdatePanel_AddProject.Update();
    }
    protected void GridView_WOmain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteWTP")//
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            //    string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            try
            {
                ws.D_TimeNoUnfixedTable(new Guid(GridView_WOmain.DataKeys[row.RowIndex].Values["TNUT_ID"].ToString()));
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除成功！')", true);

            }
            catch (Exception)
            {

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除失败！')", true);
                return;
            }
            databind_zhubiao();
            Panel_NewProjectInfo.Visible = false;
            UpdatePanel_NewProjectInfo.Update();
            Panel_AddProject.Visible = false;
            UpdatePanel_AddProject.Update();

            Panel_AddPeople.Visible = false;
            UpdatePanel_AddPeople.Update();
            Panel1.Visible = false;
            UpdatePanel1.Update();
        }
        if (e.CommandName == "EDIT123")//
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Label_TNUTID_EDIT.Text = GridView_WOmain.DataKeys[row.RowIndex].Values["TNUT_ID"].ToString();
            TextBox_WO_Time12.Text = Convert.ToDateTime(GridView_WOmain.DataKeys[row.RowIndex].Values["TNUT_Date"].ToString()).ToString("yyyy-MM-dd");
            TextBox_makepeople7.Text = GridView_WOmain.DataKeys[row.RowIndex].Values["STI_Name"].ToString();
            Label17.Text = GridView_WOmain.DataKeys[row.RowIndex].Values["TI_ID"].ToString();
            Label1.Text = "编辑提报单 " + GridView_WOmain.DataKeys[row.RowIndex].Values["TNUT_NO"].ToString().Trim() + " 的提报信息";
            SqlDataReader myReader = Us.Query_Organization();
            DropDownList2.Items.Clear();
            DropDownList2.Items.Add(new ListItem("所有部门", "null"));//增加I
            while (myReader.Read())
            {
                DropDownList2.Items.Add(new ListItem(myReader["BDOS_Name"].ToString(), myReader["BDOS_Code"].ToString()));//增加Item
            }
            try
            {
                DropDownList2.Items.FindByText(GridView_WOmain.DataKeys[row.RowIndex].Values["BDOS_Name"].ToString().Trim()).Selected = true;
            }
            catch
            {
                DropDownList2.SelectedIndex = 0;
            }


            Panel_NewProjectInfo.Visible = true;
            UpdatePanel_NewProjectInfo.Update();
            Panel_AddProject.Visible = false;
            UpdatePanel_AddProject.Update();
            Panel_AddPeople.Visible = false;
            UpdatePanel_AddPeople.Update();
            Panel1.Visible = false;
            UpdatePanel1.Update();
        }
        if (e.CommandName == "Detail123")//
        {
            Label21.Text = "";
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Label22.Text = GridView_WOmain.DataKeys[row.RowIndex].Values["TNUT_NO"].ToString().Trim();
            TextBox4.Enabled = false;
            Button5.Visible = false;
            Button9.Visible = false;
            TextBox3.Enabled = false;
            sctg.Visible = false;
            scbh.Visible = false;
            TextBox3.Enabled = false;
            sctg.Visible = false;
            scbh.Visible = false;
            TextBox7.Enabled = false;
            pbtg.Visible = false;
            pbbh.Visible = false;

            GridView1.Columns[0].Visible = false;//详细表check
            CheckBoxAll.Visible = false;//详细表全选
            CheckBoxfanxuan.Visible = false;//详细表全不选
            Btn_deleting.Visible = false; //删除
            Btn_deleting0.Visible = false; //提交
            Btn_deleting1.Visible = false; //保存
            Button10.Visible = false;
            GridView1.Columns[5].Visible = false;
            GridView1.Columns[7].Visible = false;
            GridView1.Columns[4].Visible = true;
            GridView1.Columns[6].Visible = true;

            if (label_pagestate.Text.Trim() == "make")
            {
                if (GridView_WOmain.DataKeys[row.RowIndex].Values["TNUT_State"].ToString().Trim() != "待提交")
                {
                    GridView1.Columns[0].Visible = false;//详细表check
                    CheckBoxAll.Visible = false;//详细表全选
                    CheckBoxfanxuan.Visible = false;//详细表全不选
                    Btn_deleting.Visible = false; //删除
                    Btn_deleting0.Visible = false; //提交
                    Btn_deleting1.Visible = false; //保存
                    Button10.Visible = false;
                    GridView1.Columns[5].Visible = false;
                    GridView1.Columns[7].Visible = false;
                    GridView1.Columns[4].Visible = true;
                    GridView1.Columns[6].Visible = true;
                }
                else
                {
                    GridView1.Columns[0].Visible = true;//详细表check
                    CheckBoxAll.Visible = true;//详细表全选
                    CheckBoxfanxuan.Visible = true;//详细表全不选
                    Btn_deleting.Visible = true; //删除
                    Btn_deleting0.Visible = true; //提交
                    Btn_deleting1.Visible = true; //保存
                    Button10.Visible = true;
                    GridView1.Columns[5].Visible = true;
                    GridView1.Columns[7].Visible = true;
                    GridView1.Columns[4].Visible = false;
                    GridView1.Columns[6].Visible = false;
                }
            }
            if (GridView_WOmain.DataKeys[row.RowIndex].Values["TNUT_State"].ToString().Trim() == "初审待审")
            {
                if (label_pagestate.Text.Trim() == "cs")
                {
                    TextBox4.Enabled = true;
                    Button5.Visible = true;
                    Button9.Visible = true;
                }
                else
                {
                    TextBox4.Enabled = false;
                    Button5.Visible = false;
                    Button9.Visible = false;
                }
            }

            if (GridView_WOmain.DataKeys[row.RowIndex].Values["TNUT_State"].ToString().Trim() == "人事待审")
            {
                if (label_pagestate.Text.Trim() == "rs")
                {
                    TextBox3.Enabled = true;
                    sctg.Visible = true;
                    scbh.Visible = true;
                }
                else
                {
                    TextBox3.Enabled = false;
                    sctg.Visible = false;
                    scbh.Visible = false;
                }
            }

            if (GridView_WOmain.DataKeys[row.RowIndex].Values["TNUT_State"].ToString().Trim() == "财务待审")
            {
                if (label_pagestate.Text.Trim() == "cw")
                {
                    TextBox7.Enabled = true;
                    pbtg.Visible = true;
                    pbbh.Visible = true;
                }
                else
                {
                    TextBox7.Enabled = false;
                    pbtg.Visible = false;
                    pbbh.Visible = false;
                }
            }

            Label13.Visible = false;
            Label14.Visible = false;
            Label_TNUT_ID.Text = GridView_WOmain.DataKeys[row.RowIndex].Values["TNUT_ID"].ToString().Trim();
            Label4.Text = GridView_WOmain.DataKeys[row.RowIndex].Values["TNUT_Auditor"].ToString().Trim();//初审审核人
            Label6.Text = (GridView_WOmain.DataKeys[row.RowIndex].Values["TNUT_AuTime"].ToString().Trim() == "&nbsp;" || GridView_WOmain.DataKeys[row.RowIndex].Values["TNUT_AuTime"].ToString().Trim() == "") ? "" : Convert.ToDateTime(GridView_WOmain.DataKeys[row.RowIndex].Values["TNUT_AuTime"].ToString().Trim()).ToString("yy-MM-dd HH:mm");//初审审核时间
            Label53.Text = GridView_WOmain.DataKeys[row.RowIndex].Values["BDOS_Name"].ToString().Trim();//初审审核部门
            label7.Text = GridView_WOmain.DataKeys[row.RowIndex].Values["TNUT_AuRes"].ToString().Trim();//初审审核结果
            TextBox4.Text = GridView_WOmain.DataKeys[row.RowIndex].Values["TNUT_AuSuggs"].ToString().Trim();//初审意见

            Label15.Text = GridView_WOmain.DataKeys[row.RowIndex].Values["TNUT_RSAuditor"].ToString().Trim();//人事审核人
            Label5.Text = (GridView_WOmain.DataKeys[row.RowIndex].Values["TNUT_RSTime"].ToString().Trim() == "&nbsp;" || GridView_WOmain.DataKeys[row.RowIndex].Values["TNUT_RSTime"].ToString().Trim() == "") ? "" : Convert.ToDateTime(GridView_WOmain.DataKeys[row.RowIndex].Values["TNUT_RSTime"].ToString().Trim()).ToString("yy-MM-dd HH:mm");//人事审核时间
            label51.Text = GridView_WOmain.DataKeys[row.RowIndex].Values["TNUT_RSResult"].ToString().Trim();//人事审核结果
            TextBox3.Text = GridView_WOmain.DataKeys[row.RowIndex].Values["TNUT_RSSuggs"].ToString().Trim();//人事意见

            Label41.Text = GridView_WOmain.DataKeys[row.RowIndex].Values["TNUT_CWAuditor"].ToString().Trim();//财务审核人
            Label42.Text = (GridView_WOmain.DataKeys[row.RowIndex].Values["TNUT_CWTime"].ToString().Trim() == "&nbsp;" || GridView_WOmain.DataKeys[row.RowIndex].Values["TNUT_CWTime"].ToString().Trim() == "") ? "" : Convert.ToDateTime(GridView_WOmain.DataKeys[row.RowIndex].Values["TNUT_CWTime"].ToString().Trim()).ToString("yy-MM-dd HH:mm");//财务审核时间
            label52.Text = GridView_WOmain.DataKeys[row.RowIndex].Values["TNUT_CWReult"].ToString().Trim();//财务审核结果
            TextBox7.Text = GridView_WOmain.DataKeys[row.RowIndex].Values["TNUT_CWSuggs"].ToString().Trim();//财务意见
            Panel1.Visible = true;
            Panel3.Visible = true;
            databind_detail();

        }
    }
    protected void GridView_WOmain_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView_WOmain.Rows.Count; i++) //鼠标悬停样式
        {
            for (int j = 0; j < GridView_WOmain.Rows[i].Cells.Count; j++)
            {
                GridView_WOmain.Rows[i].Cells[j].ToolTip = GridView_WOmain.Rows[i].Cells[j].Text;
                if (GridView_WOmain.Rows[i].Cells[j].Text.Length > 15)
                {
                    GridView_WOmain.Rows[i].Cells[j].Text = GridView_WOmain.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }


            }
        }
    }
    protected void CheckBoxAll2_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= GridView_WOmain.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView_WOmain.Rows[i].FindControl("CheckBox2");
            if (label_pagestate.Text.Trim() == "cs")
            {
                if (GridView_WOmain.DataKeys[i].Values["TNUT_State"].ToString().Trim() == "初审待审")
                {
                    if (CheckBox2.Checked == true)
                    {
                        CheckBox.Checked = true;
                    }
                    else
                    {
                        CheckBox.Checked = false;
                    }
                }
            }
            if (label_pagestate.Text.Trim() == "rs")
            {
                if (GridView_WOmain.DataKeys[i].Values["TNUT_State"].ToString().Trim() == "人事待审")
                {
                    if (CheckBox2.Checked == true)
                    {
                        CheckBox.Checked = true;
                    }
                    else
                    {
                        CheckBox.Checked = false;
                    }
                }
            }
            if (label_pagestate.Text.Trim() == "cw")
            {
                if (GridView_WOmain.DataKeys[i].Values["TNUT_State"].ToString().Trim() == "财务待审")
                {
                    if (CheckBox2.Checked == true)
                    {
                        CheckBox.Checked = true;
                    }
                    else
                    {
                        CheckBox.Checked = false;
                    }
                }
            }
        }
        Checkfanxuan2.Checked = false;
    }
    protected void Checkfanxuan2_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= GridView_WOmain.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView_WOmain.Rows[i].FindControl("CheckBox2");
            //if (CheckBox.Checked == false)
            //{
            //    CheckBox.Checked = true;
            //}
            //else
            //{
            //    CheckBox.Checked = false;
            //}

            if (label_pagestate.Text.Trim() == "cs")
            {
                if (GridView_WOmain.DataKeys[i].Values["TNUT_State"].ToString().Trim() == "初审待审")
                {
                    if (CheckBox.Checked == false)
                    {
                        CheckBox.Checked = true;
                    }
                    else
                    {
                        CheckBox.Checked = false;
                    }
                }
            }
            if (label_pagestate.Text.Trim() == "rs")
            {
                if (GridView_WOmain.DataKeys[i].Values["TNUT_State"].ToString().Trim() == "人事待审")
                {
                    if (CheckBox.Checked == false)
                    {
                        CheckBox.Checked = true;
                    }
                    else
                    {
                        CheckBox.Checked = false;
                    }
                }
            }
            if (label_pagestate.Text.Trim() == "cw")
            {
                if (GridView_WOmain.DataKeys[i].Values["TNUT_State"].ToString().Trim() == "财务待审")
                {
                    if (CheckBox.Checked == false)
                    {
                        CheckBox.Checked = true;
                    }
                    else
                    {
                        CheckBox.Checked = false;
                    }
                }
            }
        }
        CheckBox2.Checked = false;
    }
    protected void Button_AddPTToSeries_Click(object sender, EventArgs e)//审核
    {
        Panel3.Visible = true;
        Label22.Text = "";
        int sum = 0;
        Label13.Visible = true;
        Label14.Visible = true;
        if (label_pagestate.Text.Trim() == "cs")
        {
            Button5.Visible = true;
            Button9.Visible = true;
            TextBox4.Enabled = true;

        }
        if (label_pagestate.Text.Trim() == "rs")
        {
            sctg.Visible = true;
            scbh.Visible = true;
            TextBox3.Enabled = true;
        }
        if (label_pagestate.Text.Trim() == "cw")
        {
            pbtg.Visible = true;
            pbbh.Visible = true;
            TextBox7.Enabled = true;
        }

        for (int i = 0; i <= GridView_WOmain.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView_WOmain.Rows[i].FindControl("CheckBox2");
            if (CheckBox.Checked == true)
            {
                if (Label14.Text.Trim() == "")
                {
                    Label14.Text = GridView_WOmain.DataKeys[i].Values["TNUT_NO"].ToString().Trim();
                }
                else
                {
                    string[] a;
                    if (Label14.Text.Contains(","))
                    {
                        a = Label14.Text.Trim().Split(new char[] { ',' });
                        int id = Array.IndexOf(a, GridView_WOmain.DataKeys[i].Values["TNUT_NO"].ToString().Trim()); // 这里的1就是你要查找的值
                        if (id == -1)
                        {
                            Label14.Text = Label14.Text + "," + GridView_WOmain.DataKeys[i].Values["TNUT_NO"].ToString().Trim();
                        }
                    }
                    else
                    {
                        if (Label14.Text != GridView_WOmain.DataKeys[i].Values["TNUT_NO"].ToString().Trim())
                        {
                            Label14.Text = Label14.Text + "," + GridView_WOmain.DataKeys[i].Values["TNUT_NO"].ToString().Trim();
                        }
                    }

                }
                if (Label21.Text.Trim() == "")
                {
                    Label21.Text = GridView_WOmain.DataKeys[i].Values["TNUT_ID"].ToString().Trim();
                }
                else
                {
                    string[] a;
                    if (Label21.Text.Contains(","))
                    {
                        a = Label21.Text.Trim().Split(new char[] { ',' });
                        int id = Array.IndexOf(a, GridView_WOmain.DataKeys[i].Values["TNUT_ID"].ToString().Trim()); // 这里的1就是你要查找的值
                        if (id == -1)
                        {
                            Label21.Text = Label21.Text + "," + GridView_WOmain.DataKeys[i].Values["TNUT_ID"].ToString().Trim();
                        }
                    }
                    else
                    {
                        if (Label21.Text != GridView_WOmain.DataKeys[i].Values["TNUT_ID"].ToString().Trim())
                        {
                            Label21.Text = Label21.Text + "," + GridView_WOmain.DataKeys[i].Values["TNUT_ID"].ToString().Trim();
                        }
                    }

                }

                sum++;
            }
        }
        if (sum == 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('您没选择任何要合单的随工单！请您再核对！')", true);
            return;
        }
        UpdatePanel1.Update();
    }
    protected void GridView_WOmain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;

            if (drv["TNUT_State"].ToString().Trim() == "待提交")
            {
                e.Row.Cells[22].Enabled = true;//编辑
                e.Row.Cells[23].Enabled = true;//删除

            }
            else
            {
                e.Row.Cells[22].Enabled = false;//编辑
                e.Row.Cells[23].Enabled = false;//删除
            }
        }
        if (label_pagestate.Text.Trim() == "cs")
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView drv = (DataRowView)e.Row.DataItem;

                if (drv["TNUT_State"].ToString().Trim() == "初审待审")
                {
                    e.Row.Cells[0].Enabled = true;


                }
                else
                {
                    e.Row.Cells[0].Enabled = false;
                }
            }
        }
        if (label_pagestate.Text.Trim() == "rs")
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView drv = (DataRowView)e.Row.DataItem;

                if (drv["TNUT_State"].ToString().Trim() == "人事待审")
                {
                    e.Row.Cells[0].Enabled = true;


                }
                else
                {
                    e.Row.Cells[0].Enabled = false;
                }
            }
        }
        if (label_pagestate.Text.Trim() == "cw")
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView drv = (DataRowView)e.Row.DataItem;

                if (drv["TNUT_State"].ToString().Trim() == "财务待审")
                {
                    e.Row.Cells[0].Enabled = true;


                }
                else
                {
                    e.Row.Cells[0].Enabled = false;
                }
            }
        }
    }
    protected void CheckBoxAll_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
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
        for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
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
    protected void Btn_deleting_Click(object sender, EventArgs e)
    {
        int sum = 0;


        for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
            if (CheckBox.Checked == true)
            {
                try
                {

                    Guid TNUD_ID = new Guid(GridView1.DataKeys[i].Values["TNUD_ID"].ToString().Trim());
                    ws.D_TimeNoUnfixedDetail(TNUD_ID);
                    sum++;
                }
                catch (Exception)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除失败！')", true);
                    return;
                }
            }

        }
        if (sum == 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('您没选择任何要删除的记录！，请您再核对！')", true);
            return;
        }

        CheckBoxAll2.Checked = false;
        Checkfanxuan2.Checked = false;
        databind_detail();
        databind4();
        Panel_AddPeople.Visible = false;
        UpdatePanel_AddPeople.Update();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel3.Visible = false;
        UpdatePanel1.Update();
        Panel_AddPeople.Visible = false;
        UpdatePanel_AddPeople.Update();

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        databind_detail();

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        GridView1.PageIndex = 0;
        databind_detail();
    }
    protected void CheckBoxAll2_NEW_CheckedChanged(object sender, EventArgs e)
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
    protected void Checkfanxuan2_NEW_CheckedChanged(object sender, EventArgs e)
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
    protected void Button10_Click(object sender, EventArgs e)
    {
        Panel_AddPeople.Visible = true;
        DataSet ds = cs.CS_S_WorkingTeam_Name();
        DataTable dt = ds.Tables[0];
        DataRow dr = dt.NewRow();
        dr["WT_Name"] = "--选择所有--";
        dt.Rows.InsertAt(dr, 0);
        this.DropDownList3.DataSource = dt;
        this.DropDownList3.DataValueField = "WT_ID";
        this.DropDownList3.DataTextField = "WT_Name";
        DropDownList3.DataBind();

        if (DropDownList3.SelectedIndex == 0)
        {
            DataSet ds2 = cs.CS_S_HRDDetail_people(" and a.HRDD_ID not in (select HRDD_ID from TimeNoUnfixedDetail where TNUT_ID ='" + this.Label_TNUT_ID.Text.Trim() + "')");
            GridView_People.DataSource = ds2;
            GridView_People.DataBind();
            UpdatePanel_AddPeople.Update();

        }
        else
        {

            DataSet ds3 = cs.Cs_S_WorkTeamDetailList(" and WT_ID='" + this.DropDownList3.SelectedValue.ToString().Trim() + "'" + " and a.HRDD_ID not in (select HRDD_ID from TimeNoUnfixedDetail where TNUT_ID ='" + Label_TNUT_ID.Text.Trim() + "')");
            GridView_People.DataSource = ds3;
            GridView_People.DataBind();
            UpdatePanel_AddPeople.Update();

        }
    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList3.SelectedIndex == 0)
        {
            DataSet ds2 = cs.CS_S_HRDDetail_people(" and a.HRDD_ID not in (select HRDD_ID from TimeNoUnfixedDetail where TNUT_ID ='" + this.Label_TNUT_ID.Text.Trim() + "')");
            GridView_People.DataSource = ds2;
            GridView_People.DataBind();
            UpdatePanel_AddPeople.Update();

        }
        else
        {

            DataSet ds3 = cs.Cs_S_WorkTeamDetailList(" and WT_ID='" + this.DropDownList3.SelectedValue.ToString().Trim() + "'" + " and a.HRDD_ID not in (select HRDD_ID from TimeNoUnfixedDetail where TNUT_ID ='" + Label_TNUT_ID.Text.Trim() + "')");
            GridView_People.DataSource = ds3;
            GridView_People.DataBind();
            UpdatePanel_AddPeople.Update();

        }
    }
    protected void Button_CheckboxAddProject2_Click(object sender, EventArgs e)
    {
        int sum = 0;


        for (int i = 0; i <= GridView_People.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView_People.Rows[i].FindControl("CheckBox1");
            if (CheckBox.Checked == true)
            {
                try
                {
                    Guid TNUT_ID = new Guid(this.Label_TNUT_ID.Text.Trim());
                    Guid hrddid = new Guid(GridView_People.DataKeys[i].Values["HRDD_ID"].ToString().Trim());
                    ws.I_TimeNoUnfixedDetail(TNUT_ID, hrddid);
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
        databind_detail();
        databind4();
        Panel_AddPeople.Visible = false;
        UpdatePanel_AddPeople.Update();
    }
    protected void Button_AddPeopleSearch_Click(object sender, EventArgs e)
    {
        //TextBox5.Text = "";
        //TextBox6.Text = "";
        databind4();
    }
    protected void Button_AddPeopleCancel_Click(object sender, EventArgs e)
    {
        TextBox5.Text = "";
        TextBox6.Text = "";
        databind4();
    }
    protected void Button_AddPeople_close_Click(object sender, EventArgs e)
    {
        Panel_AddPeople.Visible = false;
        UpdatePanel_AddPeople.Update();
    }
    protected void Btn_save_Click(object sender, EventArgs e)//保存
    {
        Guid TNUD_ID;
        decimal t;
        int num;
        for (int i = 0; i <= this.GridView1.Rows.Count - 1; i++)
        {
            TNUD_ID = new Guid(GridView1.DataKeys[i].Values["TNUD_ID"].ToString());

            try
            {
                t = ((TextBox)(GridView1.Rows[i].FindControl("txttime"))).Text.Trim() == "" ? 0 : Convert.ToDecimal(((TextBox)(GridView1.Rows[i].FindControl("txttime"))).Text.Trim());
                num = ((TextBox)(GridView1.Rows[i].FindControl("txtnum"))).Text.Trim() == "" ? 0 : Convert.ToInt32(((TextBox)(GridView1.Rows[i].FindControl("txtnum"))).Text.Trim());
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请您再次核对输入格式，时间为小数、数量为整数！')", true);
                return;
            }
            ws.U_TimeNoUnfixedDetail(TNUD_ID, t, num);
        }

        GridView1.SelectedIndex = -1;
        GridView1.EditIndex = -1;
        databind_detail();
    }
    protected void Btn_tj_Click(object sender, EventArgs e)
    {
        try
        {
            ws.U_TimeNoUnfixedTable_tj(new Guid(Label_TNUT_ID.Text.Trim()));

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('提交成功！')", true);
            string message = "ERP系统信息：" + Session["Department"].ToString() + "的" + Session["UserName"].ToString() + "于" + DateTime.Now + "提交了生产无关非固定计时单： " + Label14.Text + " ！";

            string ms = "";
            try
            {
                ms = RTXhelper.SendbyDepAndRole(message, Label53.Text.Trim(), "生产无关非固定计时人事审核");
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('" + ms + "')", true);
              //  return;
            }
        }
        catch (Exception)
        {

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('提交失败！')", true);
            return;
        }
        databind_zhubiao();
        Panel1.Visible = false;
        Panel3.Visible = false;
        UpdatePanel1.Update();
        Panel_AddPeople.Visible = false;
        UpdatePanel_AddPeople.Update();
    }
    protected void cstg_Click(object sender, EventArgs e)
    {
        if (Label21.Text.Trim() != "")
        {
            if (Label21.Text.Contains(","))
            {
                string[] a;
                if (Label21.Text.Contains(","))
                {
                    a = Label21.Text.Trim().Split(new char[] { ',' });
                    try
                    {
                        for (int i = 0; i < a.Length; i++)
                        {
                            ws.U_TimeNoUnfixedDetail_Review(new Guid(a[i].Trim()), Session["UserName"].ToString(), TextBox4.Text.Trim(), "通过", 1);
                        }
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核成功！')", true);
                        string message = "ERP系统信息：" + Session["Department"].ToString() + "的" + Session["UserName"].ToString() + "于" + DateTime.Now + "初审通过了生产无关非固定计时单： " + Label14.Text + " ，请您进行人事审核！";
                        string ms="";
                        try
                        {
                             ms = RTXhelper.Send(message, "生产无关非固定计时人事审核");
                        }
                        catch (Exception)
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('"+ms+"')", true);
                            return;
                        }
                    }
                    catch (Exception)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核失败！')", true);
                        return;
                    }
                }
            }
            else
            {
                try
                {
                    
                    ws.U_TimeNoUnfixedDetail_Review(new Guid(Label21.Text.Trim()), Session["UserName"].ToString(), TextBox4.Text.Trim(), "通过", 1);
                   
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核成功！')", true);
                    string message = "ERP系统信息：" + Session["Department"].ToString() + "的" + Session["UserName"].ToString() + "于" + DateTime.Now + "初审通过了生产无关非固定计时单： " + Label14.Text + " ，请您进行人事审核！";

                    string ms = "";
                    try
                    {
                        ms = RTXhelper.Send(message, "生产无关非固定计时人事审核");
                    }
                    catch (Exception)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('" + ms + "')", true);
                        return;
                    }
                }
                catch (Exception)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核失败！')", true);
                    return;
                }
            }
        }
        else
        {
            try
            {
                ws.U_TimeNoUnfixedDetail_Review(new Guid(Label_TNUT_ID.Text.Trim()), Session["UserName"].ToString(), TextBox4.Text.Trim(), "通过", 1);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核成功！')", true);
                string message = "ERP系统信息：" + Session["Department"].ToString() + "的" + Session["UserName"].ToString() + "于" + DateTime.Now + "初审通过了生产无关非固定计时单： " + Label22.Text + " ，请您进行人事审核！";

                string ms = "";
                try
                {
                    ms = RTXhelper.Send(message, "生产无关非固定计时人事审核");
                }
                catch (Exception)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('" + ms + "')", true);
                    return;
                }
            }
            catch (Exception)
            {

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核失败！')", true);
                return;

            }
        }

     
        
        CheckBox2.Checked = false;
        Checkfanxuan2.Checked = false;
        Panel1.Visible = false;
        Panel3.Visible = false;
        UpdatePanel1.Update();
        Panel_AddPeople.Visible = false;
        UpdatePanel_AddPeople.Update();
        Panel_AddProject.Visible = false;
        UpdatePanel_AddProject.Update();
        Panel_NewProjectInfo.Visible = false;
        UpdatePanel_NewProjectInfo.Update();
        databind_zhubiao();
    }
    protected void csbh_Click(object sender, EventArgs e)
    {
        if (Label21.Text.Trim() != "")
        {
            if (Label21.Text.Contains(","))
            {
                string[] a;
                if (Label21.Text.Contains(","))
                {
                    a = Label21.Text.Trim().Split(new char[] { ',' });
                    try
                    {
                        for (int i = 0; i < a.Length; i++)
                        {
                            ws.U_TimeNoUnfixedDetail_Review(new Guid(a[i].Trim()), Session["UserName"].ToString(), TextBox4.Text.Trim(), "不通过", 1);
                        }
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核成功！')", true);
                        string message = "ERP系统信息：" + Session["Department"].ToString() + "的" + Session["UserName"].ToString() + "于" + DateTime.Now + "初审驳回了生产无关非固定计时单： " + Label14.Text + " ！";

                        string ms = "";
                        try
                        {
                            ms = RTXhelper.Send(message, "生产无关非固定计时提报");
                        }
                        catch (Exception)
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('" + ms + "')", true);
                            return;
                        }
                    }
                    catch (Exception)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核失败！')", true);
                        return;
                    }
                }
            }
            else
            {
                try
                {

                    ws.U_TimeNoUnfixedDetail_Review(new Guid(Label21.Text.Trim()), Session["UserName"].ToString(), TextBox4.Text.Trim(), "不通过", 1);

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核成功！')", true);
                    string message = "ERP系统信息：" + Session["Department"].ToString() + "的" + Session["UserName"].ToString() + "于" + DateTime.Now + "初审驳回了生产无关非固定计时单： " + Label14.Text + " ！";

                    string ms = "";
                    try
                    {
                        ms = RTXhelper.Send(message, "生产无关非固定计时提报");
                    }
                    catch (Exception)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('" + ms + "')", true);
                        return;
                    }
                }
                catch (Exception)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核失败！')", true);
                    return;
                }
            }
        }
        else
        {
            try
            {
                ws.U_TimeNoUnfixedDetail_Review(new Guid(Label_TNUT_ID.Text.Trim()), Session["UserName"].ToString(), TextBox4.Text.Trim(), "不通过", 1);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核成功！')", true);
                string message = "ERP系统信息：" + Session["Department"].ToString() + "的" + Session["UserName"].ToString() + "于" + DateTime.Now + "初审驳回了生产无关非固定计时单： " + Label22.Text + " ！";

                string ms = "";
                try
                {
                    ms = RTXhelper.Send(message, "生产无关非固定计时提报");
                }
                catch (Exception)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('" + ms + "')", true);
                    return;
                }
            }
            catch (Exception)
            {

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核失败！')", true);
                return;

            }
        }
        CheckBox2.Checked = false;
        Checkfanxuan2.Checked = false;
        Panel1.Visible = false;
        Panel3.Visible = false;
        UpdatePanel1.Update();
        Panel_AddPeople.Visible = false;
        UpdatePanel_AddPeople.Update();
        Panel_AddProject.Visible = false;
        UpdatePanel_AddProject.Update();
        Panel_NewProjectInfo.Visible = false;
        UpdatePanel_NewProjectInfo.Update();
        databind_zhubiao();

    }
    protected void sctg_Click(object sender, EventArgs e)//人事审核通过
    {
        if (Label21.Text.Trim() != "")
        {
            if (Label21.Text.Contains(","))
            {
                string[] a;
                if (Label21.Text.Contains(","))
                {
                    a = Label21.Text.Trim().Split(new char[] { ',' });
                    try
                    {
                        for (int i = 0; i < a.Length; i++)
                        {
                            ws.U_TimeNoUnfixedDetail_Review(new Guid(a[i].Trim()), Session["UserName"].ToString(), TextBox3.Text.Trim(), "通过", 2);
                        }
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核成功！')", true);
                        string message = "ERP系统信息：" + Session["Department"].ToString() + "的" + Session["UserName"].ToString() + "于" + DateTime.Now + "人事审核通过了生产无关非固定计时单： " + Label14.Text + " ！";

                        string ms = "";
                        try
                        {
                            ms = RTXhelper.Send(message, "生产无关非固定计时财务审核");
                        }
                        catch (Exception)
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('" + ms + "')", true);
                            return;
                        }

                    }
                    catch (Exception)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核失败！')", true);
                        return;
                    }
                }
            }
            else
            {
                try
                {

                    ws.U_TimeNoUnfixedDetail_Review(new Guid(Label21.Text.Trim()), Session["UserName"].ToString(), TextBox3.Text.Trim(), "通过", 2);

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核成功！')", true);
                    string message = "ERP系统信息：" + Session["Department"].ToString() + "的" + Session["UserName"].ToString() + "于" + DateTime.Now + "人事审核通过了生产无关非固定计时单： " + Label14.Text + " ！";

                    string ms = "";
                    try
                    {
                        ms = RTXhelper.Send(message, "生产无关非固定计时财务审核");
                    }
                    catch (Exception)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('" + ms + "')", true);
                        return;
                    }

                }
                catch (Exception)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核失败！')", true);
                    return;
                }
            }
        }
        else
        {
            try
            {
                ws.U_TimeNoUnfixedDetail_Review(new Guid(Label_TNUT_ID.Text.Trim()), Session["UserName"].ToString(), TextBox3.Text.Trim(), "通过", 2);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核成功！')", true);
                string message = "ERP系统信息：" + Session["Department"].ToString() + "的" + Session["UserName"].ToString() + "于" + DateTime.Now + "人事审核通过了生产无关非固定计时单： " + Label22.Text + " ！";

                string ms = "";
                try
                {
                    ms = RTXhelper.Send(message, "生产无关非固定计时财务审核");
                }
                catch (Exception)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('" + ms + "')", true);
                    return;
                }
            }
            catch (Exception)
            {

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核失败！')", true);
                return;

            }
        }
        Panel1.Visible = false;
        Panel3.Visible = false;
        UpdatePanel1.Update();
        Panel_AddPeople.Visible = false;
        UpdatePanel_AddPeople.Update();
        Panel_AddProject.Visible = false;
        UpdatePanel_AddProject.Update();
        Panel_NewProjectInfo.Visible = false;
        UpdatePanel_NewProjectInfo.Update();
        CheckBox2.Checked = false;
        Checkfanxuan2.Checked = false;
        databind_zhubiao();
    }
    protected void scbh_Click(object sender, EventArgs e)//人事审核不通过
    {
        if (Label21.Text.Trim() != "")
        {
            if (Label21.Text.Contains(","))
            {
                string[] a;
                if (Label21.Text.Contains(","))
                {
                    a = Label21.Text.Trim().Split(new char[] { ',' });
                    try
                    {
                        for (int i = 0; i < a.Length; i++)
                        {
                            ws.U_TimeNoUnfixedDetail_Review(new Guid(a[i].Trim()), Session["UserName"].ToString(), TextBox3.Text.Trim(), "不通过", 2);
                        }
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核成功！')", true);
                        string message = "ERP系统信息：" + Session["Department"].ToString() + "的" + Session["UserName"].ToString() + "于" + DateTime.Now + "人事审核驳回了生产无关非固定计时单： " + Label14.Text + " ！";

                        string ms = "";
                        try
                        {
                            ms = RTXhelper.Send(message, "生产无关非固定计时提报");
                        }
                        catch (Exception)
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('" + ms + "')", true);
                            return;
                        }
                    }
                    catch (Exception)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核失败！')", true);
                        return;
                    }
                }
            }
            else
            {
                try
                {

                    ws.U_TimeNoUnfixedDetail_Review(new Guid(Label21.Text.Trim()), Session["UserName"].ToString(), TextBox3.Text.Trim(), "不通过", 2);

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核成功！')", true);
                    string message = "ERP系统信息：" + Session["Department"].ToString() + "的" + Session["UserName"].ToString() + "于" + DateTime.Now + "人事审核驳回了生产无关非固定计时单： " + Label14.Text + " ！";

                    string ms = "";
                    try
                    {
                        ms = RTXhelper.Send(message, "生产无关非固定计时提报");
                    }
                    catch (Exception)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('" + ms + "')", true);
                        return;
                    }
                }
                catch (Exception)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核失败！')", true);
                    return;
                }
            }
        }
        else
        {
            try
            {
                ws.U_TimeNoUnfixedDetail_Review(new Guid(Label_TNUT_ID.Text.Trim()), Session["UserName"].ToString(), TextBox3.Text.Trim(), "不通过", 2);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核成功！')", true);
                string message = "ERP系统信息：" + Session["Department"].ToString() + "的" + Session["UserName"].ToString() + "于" + DateTime.Now + "人事审核驳回了生产无关非固定计时单： " + Label22.Text + " ！";

                string ms = "";
                try
                {
                    ms = RTXhelper.Send(message, "生产无关非固定计时提报");
                }
                catch (Exception)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('" + ms + "')", true);
                    return;
                }
            }
            catch (Exception)
            {

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核失败！')", true);
                return;

            }
        }
        CheckBox2.Checked = false;
        Checkfanxuan2.Checked = false;
        Panel1.Visible = false;
        Panel3.Visible = false;
        UpdatePanel1.Update();
        Panel_AddPeople.Visible = false;
        UpdatePanel_AddPeople.Update();
        Panel_AddProject.Visible = false;
        UpdatePanel_AddProject.Update();
        Panel_NewProjectInfo.Visible = false;
        UpdatePanel_NewProjectInfo.Update();
        databind_zhubiao();
    }
    protected void pbtg_Click(object sender, EventArgs e)//财务审核通过
    {
        if (Label21.Text.Trim() != "")
        {
            if (Label21.Text.Contains(","))
            {
                string[] a;
                if (Label21.Text.Contains(","))
                {
                    a = Label21.Text.Trim().Split(new char[] { ',' });
                    try
                    {
                        for (int i = 0; i < a.Length; i++)
                        {
                            ws.U_TimeNoUnfixedDetail_Review(new Guid(a[i].Trim()), Session["UserName"].ToString(), TextBox7.Text.Trim(), "通过", 3);
                        }
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核成功！')", true);
                        string message = "ERP系统信息：" + Session["Department"].ToString() + "的" + Session["UserName"].ToString() + "于" + DateTime.Now + "财务审核通过了生产无关非固定计时单： " + Label14.Text + " ！";

                        string ms = "";
                        try
                        {
                            ms = RTXhelper.Send(message, "生产无关非固定计时提报");
                        }
                        catch (Exception)
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('" + ms + "')", true);
                            return;
                        }
                    }
                    catch (Exception)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核失败！')", true);
                        return;
                    }
                }
            }
            else
            {
                try
                {

                    ws.U_TimeNoUnfixedDetail_Review(new Guid(Label21.Text.Trim()), Session["UserName"].ToString(), TextBox7.Text.Trim(), "通过", 3);

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核成功！')", true);
                    string message = "ERP系统信息：" + Session["Department"].ToString() + "的" + Session["UserName"].ToString() + "于" + DateTime.Now + "财务审核通过了生产无关非固定计时单： " + Label14.Text + " ！";

                    string ms = "";
                    try
                    {
                        ms = RTXhelper.Send(message, "生产无关非固定计时提报");
                    }
                    catch (Exception)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('" + ms + "')", true);
                        return;
                    }
                }
                catch (Exception)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核失败！')", true);
                    return;
                }
            }
        }
        else
        {
            try
            {
                ws.U_TimeNoUnfixedDetail_Review(new Guid(Label_TNUT_ID.Text.Trim()), Session["UserName"].ToString(), TextBox7.Text.Trim(), "通过", 3);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核成功！')", true);
                string message = "ERP系统信息：" + Session["Department"].ToString() + "的" + Session["UserName"].ToString() + "于" + DateTime.Now + "财务审核通过了生产无关非固定计时单： " + Label22.Text + " ！";

                string ms = "";
                try
                {
                    ms = RTXhelper.Send(message, "生产无关非固定计时提报");
                }
                catch (Exception)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('" + ms + "')", true);
                    return;
                }
            }
            catch (Exception)
            {

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核失败！')", true);
                return;

            }
        }
        CheckBox2.Checked = false;
        Checkfanxuan2.Checked = false;
        Panel1.Visible = false;
        Panel3.Visible = false;
        UpdatePanel1.Update();
        Panel_AddPeople.Visible = false;
        UpdatePanel_AddPeople.Update();
        Panel_AddProject.Visible = false;
        UpdatePanel_AddProject.Update();
        Panel_NewProjectInfo.Visible = false;
        UpdatePanel_NewProjectInfo.Update();
        databind_zhubiao();
    }
    protected void pbbh_Click(object sender, EventArgs e)//财务审核不通过
    {
        if (Label21.Text.Trim() != "")
        {
            if (Label21.Text.Contains(","))
            {
                string[] a;
                if (Label21.Text.Contains(","))
                {
                    a = Label21.Text.Trim().Split(new char[] { ',' });
                    try
                    {
                        for (int i = 0; i < a.Length; i++)
                        {
                            ws.U_TimeNoUnfixedDetail_Review(new Guid(a[i].Trim()), Session["UserName"].ToString(), TextBox4.Text.Trim(), "不通过", 3);
                        }
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核成功！')", true);
                        string message = "ERP系统信息：" + Session["Department"].ToString() + "的" + Session["UserName"].ToString() + "于" + DateTime.Now + "财务审核驳回了生产无关非固定计时单： " + Label14.Text + " ！";

                        string ms = "";
                        try
                        {
                            ms = RTXhelper.Send(message, "生产无关非固定计时提报");
                        }
                        catch (Exception)
                        {
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('" + ms + "')", true);
                            return;
                        }
                    }
                    catch (Exception)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核失败！')", true);
                        return;
                    }
                }
            }
            else
            {
                try
                {

                    ws.U_TimeNoUnfixedDetail_Review(new Guid(Label21.Text.Trim()), Session["UserName"].ToString(), TextBox4.Text.Trim(), "不通过", 3);

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核成功！')", true);
                    string message = "ERP系统信息：" + Session["Department"].ToString() + "的" + Session["UserName"].ToString() + "于" + DateTime.Now + "财务审核驳回了生产无关非固定计时单： " + Label14.Text + " ！";

                    string ms = "";
                    try
                    {
                        ms = RTXhelper.Send(message, "生产无关非固定计时提报");
                    }
                    catch (Exception)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('" + ms + "')", true);
                        return;
                    }

                }
                catch (Exception)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核失败！')", true);
                    return;
                }
            }
        }
        else
        {
            try
            {
                ws.U_TimeNoUnfixedDetail_Review(new Guid(Label_TNUT_ID.Text.Trim()), Session["UserName"].ToString(), TextBox4.Text.Trim(), "不通过", 3);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核成功！')", true);
                string message = "ERP系统信息：" + Session["Department"].ToString() + "的" + Session["UserName"].ToString() + "于" + DateTime.Now + "财务审核驳回了生产无关非固定计时单： " + Label22.Text + " ！";

                string ms = "";
                try
                {
                    ms = RTXhelper.Send(message, "生产无关非固定计时提报");
                }
                catch (Exception)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('" + ms + "')", true);
                    return;
                }
            }
            catch (Exception)
            {

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核失败！')", true);
                return;

            }
        }
        CheckBox2.Checked = false;
        Checkfanxuan2.Checked = false;
        Panel1.Visible = false;
        Panel3.Visible = false;
        UpdatePanel1.Update();
        Panel_AddPeople.Visible = false;
        UpdatePanel_AddPeople.Update();
        Panel_AddProject.Visible = false;
        UpdatePanel_AddProject.Update();
        Panel_NewProjectInfo.Visible = false;
        UpdatePanel_NewProjectInfo.Update();

        databind_zhubiao();
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
        databind4();
    }
    protected void Button_AddPeople_close0_Click(object sender, EventArgs e)//查看
    {
        Panel3.Visible = false;
        UpdatePanel1.Update();
    }

}