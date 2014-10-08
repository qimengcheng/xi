using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class HRFilesMgt_HRDDetailMgt : Page
{
    HRDDetailInfo hRDDetailInfo = new HRDDetailInfo();
    HRDDetailL hRDDetailL = new HRDDetailL();
    private static Guid g;
    private static string condition;
    private static string cond;
    private int DateDiff(DateTime DateTime1, DateTime DateTime2)
    {
        string dateDiff = null;
        try
        {
            TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
            TimeSpan ts2 = new TimeSpan(DateTime2.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            dateDiff = ts.Days.ToString();// + "天";
            // + ts.Hours.ToString() + "小时"
            //+ ts.Minutes.ToString() + "分钟"
            // + ts.Seconds.ToString() + "秒";
        }
        catch
        {

        }

        //dateDiff = dateDiff.Split('天')[0];
        return Convert.ToInt32(dateDiff);
        //return  dateDiff;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind_DdlDep(DdlSDep);
            Bind_DdlSPost("");
            Bind_DdlType(DdlSType);
            Label_OpenOrClose.Text = "检索";

            try
            {
                if (Session["Department"] == null)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('您长时间未操作，请重新登录！')", true);
                    Response.Redirect("~/Default.aspx");
                }

                #region//权限控制
                string Role = Request.QueryString["status"].ToString();
                if (Role == "rewardLook")
                {
                    Panel2.Visible = false;
                    Grid_Detail.Columns[8].Visible = false;
                    Grid_Detail.Columns[9].Visible = false;
                    Grid_Detail.Columns[10].Visible = false;
                    Grid_Detail.Columns[11].Visible = false;
                    Grid_Detail.Columns[12].Visible = false;
                    Grid_Detail.Columns[13].Visible = false;
                    Grid_Detail.Columns[14].Visible = false;
                    Grid_Detail.Columns[15].Visible = false;
                    Grid_Detail.Columns[16].Visible = false;
                    Grid_Detail.Columns[17].Visible = false;
                    Grid_Detail.Columns[18].Visible = false;

                    Grid_Detail.Columns[19].Visible = true;
                    BtnNew.Visible = false;
                    BtnRewardNew.Visible = false;
                    BtnRewardnewClose.Visible = false;
                    BtnRewardnewClose11.Visible = true;
                    GridView_Reward.Columns[9].Visible = false;
                    GridView_Reward.Columns[10].Visible = false;
                    Senior_DetailOPEN.Visible = true;
                    Title = "人员奖惩查看";
                    BindGrid("");
                }
                if (Role == "rewardMain")
                {
                    Panel2.Visible = false;
                    Grid_Detail.Columns[18].Visible = false;
                    Grid_Detail.Columns[8].Visible = false;
                    Grid_Detail.Columns[9].Visible = false;
                    Grid_Detail.Columns[10].Visible = false;
                    Grid_Detail.Columns[11].Visible = false;
                    Grid_Detail.Columns[12].Visible = false;
                    Grid_Detail.Columns[13].Visible = false;
                    Grid_Detail.Columns[14].Visible = false;
                    Grid_Detail.Columns[15].Visible = false;
                    Grid_Detail.Columns[16].Visible = false;
                    Grid_Detail.Columns[17].Visible = false;
                    Grid_Detail.Columns[19].Visible = true;
                    BtnNew.Visible = false;
                    BtnRewardNew.Visible = true;
                    BtnRewardnewClose.Visible = true;
                    BtnRewardnewClose11.Visible = false;
                    GridView_Reward.Columns[9].Visible = true;
                    GridView_Reward.Columns[10].Visible = true;
                    Senior_DetailOPEN.Visible = true;
                    Title = "人员奖惩管理";
                    BindGrid("");
                }
                if (Role == "documentMain_Quit")
                {
                    Panel1.Visible = false;
                    Grid_Detail.Columns[8].Visible = false;
                    Grid_Detail.Columns[12].Visible = false;
                    Grid_Detail.Columns[11].Visible = false;
                    Grid_Detail.Columns[14].Visible = false;
                    Grid_Detail.Columns[16].Visible = false;
                    Grid_Detail.Columns[19].Visible = true;
                    Grid_Detail.Columns[17].Visible = true;
                    Grid_Detail.Columns[18].Visible = true;
                    BtnRewardNew.Visible = false;
                    BtnRewardnewClose.Visible = false;
                    BtnRewardnewClose11.Visible = true;
                    BtnRewardSubmit.Visible = true;
                    BtnRewardCancel.Visible = true;
                    BtnRewardCancel11.Visible = false;
                    GridView_Reward.Columns[9].Visible = true;
                    GridView_Reward.Columns[10].Visible = true;
                    Title = "离职员工档案维护";
                    BindGrid_Quit("");
                }
                if (Role == "documentMain")
                {
                    Panel2.Visible = false;
                    Grid_Detail.Columns[19].Visible = false;
                    Grid_Detail.Columns[12].Visible = false;
                    Grid_Detail.Columns[13].Visible = false;
                    Grid_Detail.Columns[14].Visible = false;
                    Grid_Detail.Columns[15].Visible = false;
                    Grid_Detail.Columns[16].Visible = true;
                    Grid_Detail.Columns[17].Visible = false;
                    Grid_Detail.Columns[18].Visible = false;
                    Title = "人事档案维护";
                    BtnWorklength.Visible = true;
                    BindGrid("");
                }
                if (Role == "documentLook")
                {
                    Panel2.Visible = false;
                    Grid_Detail.Columns[7].Visible = true;
                    Grid_Detail.Columns[8].Visible = false;
                    Grid_Detail.Columns[11].Visible = false;
                    Grid_Detail.Columns[12].Visible = false;
                    Grid_Detail.Columns[13].Visible = false;
                    Grid_Detail.Columns[14].Visible = false;
                    Grid_Detail.Columns[19].Visible = false;
                    Grid_Detail.Columns[10].Visible = false;
                    Grid_Detail.Columns[15].Visible = false;
                    Grid_Detail.Columns[16].Visible = false;
                    Grid_Detail.Columns[17].Visible = false;
                    Grid_Detail.Columns[18].Visible = false;
                    BtnNew.Visible = false;
                    Title = "人事档案查看";
                    BindGrid("");
                }

                if (Role == "salaryMain")
                {
                    Panel2.Visible = false;
                    Grid_Detail.Columns[13].Visible = false;
                    Grid_Detail.Columns[8].Visible = false;
                    Grid_Detail.Columns[9].Visible = false;
                    Grid_Detail.Columns[10].Visible = false;
                    Grid_Detail.Columns[11].Visible = false;
                    Grid_Detail.Columns[12].Visible = false;
                    Grid_Detail.Columns[19].Visible = false;
                    Grid_Detail.Columns[16].Visible = false;
                    Grid_Detail.Columns[17].Visible = false;
                    Grid_Detail.Columns[18].Visible = false;
                    BtnNew.Visible = false;
                    Title = "人员调薪管理";
                    BindGrid("");
                }
                if (Role == "salaryLook")
                {
                    Panel2.Visible = false;
                    Grid_Detail.Columns[14].Visible = false;
                    Grid_Detail.Columns[8].Visible = false;
                    Grid_Detail.Columns[9].Visible = false;
                    Grid_Detail.Columns[10].Visible = false;
                    Grid_Detail.Columns[11].Visible = false;
                    Grid_Detail.Columns[12].Visible = false;
                    Grid_Detail.Columns[13].Visible = false;
                    Grid_Detail.Columns[19].Visible = false;
                    Grid_Detail.Columns[16].Visible = false;
                    Grid_Detail.Columns[17].Visible = false;
                    Grid_Detail.Columns[18].Visible = false;
                    BtnNew.Visible = false;
                    Title = "人员调薪记录查看";
                    BindGrid("");
                }

                if (Role == "changeMain")
                {
                    Panel2.Visible = false;
                    Grid_Detail.Columns[11].Visible = false;
                    Grid_Detail.Columns[8].Visible = false;
                    Grid_Detail.Columns[9].Visible = false;
                    Grid_Detail.Columns[10].Visible = false;
                    Grid_Detail.Columns[19].Visible = false;
                    Grid_Detail.Columns[14].Visible = false;
                    Grid_Detail.Columns[15].Visible = false;
                    Grid_Detail.Columns[16].Visible = false;
                    Grid_Detail.Columns[17].Visible = false;
                    Grid_Detail.Columns[18].Visible = false;
                    BtnNew.Visible = false;
                    Title = "人事异动管理";
                    BindGrid("");
                }
                if (Role == "changeLook")
                {
                    Panel2.Visible = false;
                    Grid_Detail.Columns[12].Visible = false;
                    Grid_Detail.Columns[8].Visible = false;
                    Grid_Detail.Columns[9].Visible = false;
                    Grid_Detail.Columns[10].Visible = false;
                    Grid_Detail.Columns[11].Visible = false;
                    Grid_Detail.Columns[19].Visible = false;
                    Grid_Detail.Columns[14].Visible = false;
                    Grid_Detail.Columns[15].Visible = false;
                    Grid_Detail.Columns[16].Visible = false;
                    Grid_Detail.Columns[17].Visible = false;
                    Grid_Detail.Columns[18].Visible = false;
                    BtnNew.Visible = false;
                    Title = "人事异动查看";
                    BindGrid("");
                }
                if (Role == "Reward")
                {
                    Panel5.Visible = false;
                    Senior_DetailOPEN.Visible = false;
                    Senior_DetailCLOSE.Visible = false;
                    Panel6.Visible = true;
                    Panel2.Visible = false;
                    Panel1.Visible = true;
                    Panel_Grid.Visible = false;
                    UpdatePanel_Grid.Update();
                    Panel7.Visible = true;
                    UpdatePanel7.Update();
                    Label_OpenOrClose.Text = "高级检索";
                    Label100.Visible = false;
                    DropDownList1.Visible = false;
                    BtnNew.Visible = false;
                    BtnPrint.Visible = true;
                    Title = "人员奖惩表";
                }
                #endregion
            }
            catch (Exception)
            {
                throw;
                //Response.Redirect("~/Default.aspx");

            }
        }//页面首次加载时，默认的数据绑定


    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        Grid_Detail.SelectedIndex = -1;//如果Grid_Detail存在行加黑，则取消加黑
        condition = TxtSStaffNO.Text.Trim() == "" ? "" : " and HRDD_StaffNO like '%" + TxtSStaffNO.Text.Trim() + "%'";
        condition += TxtSName.Text.Trim() == "" ? "" : " and HRDD_Name like '%" + TxtSName.Text.Trim() + "%'";
        condition += DdlSDep.SelectedValue == "" ? "" : " and b.BDOS_Code ='" + DdlSDep.SelectedValue + "'";
        condition += DdlSPost.SelectedValue == "" ? "" : " and a.HRP_ID ='" + DdlSPost.SelectedValue + "'";
        condition += DdlSType.SelectedValue == "" ? "" : " and a.HRET_ID ='" + DdlSType.SelectedValue + "'";
        condition += DropDownList1.SelectedValue == "" ? "" : " and a.HRDD_Registration ='" + DropDownList1.SelectedValue + "'";

        condition += DropDownList6.SelectedValue == "" ? "" : " and HRDD_EduBackg ='" + DropDownList6.SelectedValue + "'";
        condition += TextBox20.Text.Trim() == "" ? "" : " and HRDD_GSchool like '%" + TextBox20.Text.Trim() + "%'";
        condition += TextBox21.Text.Trim() == "" ? "" : " and HRDD_Major like '%" + TextBox21.Text.Trim() + "%'";
        condition += DropDownList3.SelectedValue == "" ? "" : " and HRDD_Sex ='" + DropDownList3.SelectedValue + "'";
        condition += DropDownList4.SelectedValue == "" ? "" : " and HRDD_HasSocial ='" + DropDownList4.SelectedValue + "'";
        condition += DropDownList5.SelectedValue == "" ? "" : " and HRDD_HasAccumulation ='" + DropDownList5.SelectedValue + "'";

        condition += TextBox13.Text.Trim() == "" ? "" : " and HRDD_ContactEDate >= '" + TextBox13.Text.Trim() + "'";
        condition += TextBox14.Text.Trim() == "" ? "" : " and HRDD_ContactEDate <= '" + TextBox14.Text.Trim() + "'";
        condition += TextBox15.Text.Trim() == "" ? "" : " and HRDD_EntryDate >= '" + TextBox15.Text.Trim() + "'";
        condition += TextBox16.Text.Trim() == "" ? "" : " and HRDD_EntryDate <= '" + TextBox16.Text.Trim() + "'";
        condition += TextBox17.Text.Trim() == "" ? "" : " and HRDD_ConverseDate >= '" + TextBox17.Text.Trim() + "'";
        condition += TextBox19.Text.Trim() == "" ? "" : " and HRDD_ConverseDate <= '" + TextBox19.Text.Trim() + "'";


        if (Label_OpenOrClose.Text == "检索")
        {
            LblRecordIsSearch.Text = "检索后";
            try
            {
                BindGrid(condition);
                UpdatePanel_Grid.Update();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        if (Label_OpenOrClose.Text == "高级检索")
        {
            LblRecordIsSearch.Text = "高级检索后";

            condition += DropDownList7.SelectedValue == "" ? "" : " and HRRewards_Type ='" + DropDownList7.SelectedValue + "'";
            condition += TextBox24.Text.Trim() == "" ? "" : " and HRRewards_Money = '" + TextBox24.Text.Trim() + "'";
            condition += TextBox25.Text.Trim() == "" ? "" : " and HRRewards_Agree like '%" + TextBox25.Text.Trim() + "%'";
            condition += TextBox28.Text.Trim() == "" ? "" : " and HRRewards_Content like '%" + TextBox28.Text.Trim() + "%'";
            condition += TextBox26.Text.Trim() == "" ? "" : " and HRRewards_Time >= '" + TextBox26.Text.Trim() + "'";
            condition += TextBox22.Text.Trim() == "" ? "" : " and HRRewards_Time <= '" + TextBox22.Text.Trim() + "'";
            condition += TextBox27.Text.Trim() == "" ? "" : " and HRRewards_OkTime >= '" + TextBox27.Text.Trim() + "'";
            condition += TextBox23.Text.Trim() == "" ? "" : " and HRRewards_OkTime <= '" + TextBox23.Text.Trim() + "'";
            try
            {
                Panel7.Visible = true;
                GridView7.DataSource = hRDDetailL.Search_HRDDetail_Type_Post_Senior(condition);
                GridView7.DataBind();
                Panel_Grid.Visible = false;
                UpdatePanel_Grid.Update();
                UpdatePanel7.Update();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        Panel4.Visible = false;
        UpdatePanel4.Update();
        Panel_Detail.Visible = false;
        UpdatePanel_Detail.Update();
    }
    //绑定Gridview在职
    private void BindGrid(string cond)
    {
        Grid_Detail.DataSource = hRDDetailL.Search_HRDDetail(cond);
        Grid_Detail.DataBind();
    }
    //绑定Gridview离职
    private void BindGrid_Quit(string cond)
    {
        Grid_Detail.DataSource = hRDDetailL.Search_HRDDetail_Quit(cond);
        Grid_Detail.DataBind();
    }
    //绑定Dropdownlist中的DdlDep——部门
    private void Bind_DdlDep(DropDownList ddl)
    {
        ddl.DataSource = hRDDetailL.SearchDdl_HRDDetail_BDOrganizationSheet().Tables[0].DefaultView;
        ddl.DataTextField = "BDOS_Name";
        ddl.DataValueField = "BDOS_Code";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("请选择", ""));
    }
    //绑定Dropdownlist中的DdlDep——检索栏的岗位
    private void Bind_DdlSPost(string BDOS_Code)
    {
        DdlSPost.DataSource = hRDDetailL.SearchDdl_HRDDetail(BDOS_Code).Tables[0].DefaultView;
        DdlSPost.DataTextField = "HRP_Post";
        DdlSPost.DataValueField = "HRP_ID";
        DdlSPost.DataBind();
        DdlSPost.Items.Insert(0, new ListItem("请选择", ""));
    }
    //绑定Dropdownlist中的DdlDep——非检索栏岗位
    private void Bind_DdlPost(string BDOS_Code)
    {
        DdlPost.DataSource = hRDDetailL.SearchDdl_HRDDetail(BDOS_Code).Tables[0].DefaultView;
        DdlPost.DataTextField = "HRP_Post";
        DdlPost.DataValueField = "HRP_ID";
        DdlPost.DataBind();
        DdlPost.Items.Insert(0, new ListItem("请选择", ""));
    }
    //绑定Dropdownlist中的DdlDepChangeBefore——人事异动栏岗位
    private void Bind_DdlPostChangeBefore(string BDOS_Code)
    {
        DdlPostChangeBefore.DataSource = hRDDetailL.SearchDdl_HRDDetail(BDOS_Code).Tables[0].DefaultView;
        DdlPostChangeBefore.DataTextField = "HRP_Post";
        DdlPostChangeBefore.DataValueField = "HRP_ID";
        DdlPostChangeBefore.DataBind();
        DdlPostChangeBefore.Items.Insert(0, new ListItem("请选择", ""));
    }
    //绑定Dropdownlist中的DdlDepChangeAfter——人事异动栏岗位
    private void Bind_DdlPostChangeAfter(string BDOS_Code)
    {
        DdlPostChangeAfter.DataSource = hRDDetailL.SearchDdl_HRDDetail(BDOS_Code).Tables[0].DefaultView;
        DdlPostChangeAfter.DataTextField = "HRP_Post";
        DdlPostChangeAfter.DataValueField = "HRP_ID";
        DdlPostChangeAfter.DataBind();
        DdlPostChangeAfter.Items.Insert(0, new ListItem("请选择", ""));
    }
    //绑定Dropdownlist中的DdlType——员工类型
    private void Bind_DdlType(DropDownList ddl)
    {
        ddl.DataSource = hRDDetailL.SearchDdl_HRDDetail_HREmployeeType().Tables[0].DefaultView;
        ddl.DataTextField = "HRET_EmpType";
        ddl.DataValueField = "HRET_ID";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("请选择", ""));
    }
    //绑定GridView_Reward奖惩
    private void BindGridView_Reward(string cond)
    {
        GridView_Reward.DataSource = hRDDetailL.Search_HRRewardsPublishment(cond);
        GridView_Reward.DataBind();
    }


    protected void BtnNew_Click(object sender, EventArgs e)
    {
        Panel_Detail.Visible = true;
        if (BtnSubmit.Visible == false)
            BtnSubmit.Visible = true;
        ClearDetail();
        SetValueForAllDdl();
        ListItem ee = DdlType.Items.FindByText("离职员工");
        DdlType.Items.Remove(ee);
        UpdatePanel_Detail.Update();
        LblState.Text = "New";
        TxtStaffNO.Enabled = false;
    }

    private void ClearDetail()
    {
        TxtStaffNO.Text = "";
        TxtName.Text = "";
        DdlRegistration.ClearSelection();
        DdlDep.ClearSelection();
        DdlPost.ClearSelection();
        DdlType.ClearSelection();
        TxtBasicWage.Text = "0";
        TxtFullTimeWage.Text = "0";
        TxtPerformWage.Text = "0";
        TxtOverTimeWage.Text = "0";
        TxtConverseDate.Text = "";
        TxtContactSDate.Text = "";
        TxtContactEDate.Text = "";
        TxtWorklength.Text = "";
        TxtEntryDate.Text = "";
        //TxtWorkAge.Text = "";
        DdlSex.ClearSelection();
        TxtDateOfBirth.Text = "";
        TxtIDCard.Text = "";
        DdlIsMarried.ClearSelection();
        TxtNationality.Text = "";
        DdlEduBackg.ClearSelection();
        TxtMajor.Text = "";
        TxtGSchool.Text = "";
        TxtHAddress.Text = "";
        TxtTel.Text = "";
        DdlHasSocial.ClearSelection();
        DdlHasAccumulation.ClearSelection();
        DdlCertificateComplete.ClearSelection();
        TxtEmergencyPer.Text = "";
        TxtEmergencyNo.Text = "";
    }

    protected void DdlSDep_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind_DdlSPost(DdlSDep.SelectedValue.ToString());
    }

    protected void DdlDep_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind_DdlPost(DdlDep.SelectedValue.ToString());
    }
    //人事档案详情面板中的 动态DropdownList的绑定方法
    private void SetValueForAllDdl()
    {
        Bind_DdlDep(DdlDep);
        Bind_DdlPost("");
        Bind_DdlType(DdlType);
    }
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        if (Panel_Detail.Visible)
        {
            Panel_Detail.Visible = false;
        }
    }
    protected void BtnReset_Click1(object sender, EventArgs e)
    {
        Grid_Detail.SelectedIndex = -1;//如果Grid_Detail存在行加黑，则取消加黑
        TxtSStaffNO.Text = "";
        TxtSName.Text = "";
        DdlSDep.ClearSelection();
        DdlSPost.ClearSelection();
        DdlSType.ClearSelection();
        DropDownList1.SelectedValue = "";
        DropDownList3.SelectedValue = "";
        DropDownList4.SelectedValue = "";
        DropDownList5.SelectedValue = "";
        DropDownList6.SelectedValue = "";
        TextBox20.Text = "";
        TextBox21.Text = "";
        TextBox13.Text = "";
        TextBox14.Text = "";
        TextBox15.Text = "";
        TextBox16.Text = "";
        TextBox17.Text = "";
        TextBox19.Text = "";
        DropDownList7.SelectedValue = "";
        TextBox24.Text = "";
        TextBox25.Text = "";
        TextBox26.Text = "";
        TextBox27.Text = "";
        TextBox28.Text = "";
        TextBox22.Text = "";
        TextBox23.Text = "";
        BindGrid("");
        GridView7.DataSource = hRDDetailL.Search_HRDDetail_Type_Post_Senior("");
        GridView7.DataBind();
        UpdatePanel7.Update();
        LblRecordIsSearch.Text = "检索前";
        UpdatePanel_Grid.Update();
        UpdatePanel_Search.Update();
        Panel4.Visible = false;
        UpdatePanel4.Update();
        Panel_reward.Visible = false;
        UpdatePane_reward.Update();
        Panel_Detail.Visible = false;
        UpdatePanel_Detail.Update();
    }
    protected void Grid_Detail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Look_Detail")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_Detail.SelectedIndex = row.RowIndex;

            ClearDetail();
            Panel_Detail.Visible = true;
            if (Request.QueryString["status"].ToString() == "documentMain_Quit" && Session["UserRole"].ToString().Contains("离职员工档案维护"))
            {
                Panel3.Visible = true;
            }
            else
            {
                Panel3.Visible = false;
            }
            if (BtnSubmit.Visible)
            {
                BtnSubmit.Visible = false;
            }
            UpdatePanel_Detail.Update();
            LblState.Text = "Look_Detail";

            ////为Dropdownlist绑定值，否则会出错
            SetValueForAllDdl();
            GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            g = new Guid(e.CommandArgument.ToString());
            try
            {
                DataSet hR = hRDDetailL.SearchByID_HRDDetail_Type_Post_Quit(g);
                DataRow col = hR.Tables[0].Rows[0];
                TxtStaffNO.Text = col[3].ToString();
                TxtName.Text = col[4].ToString();
                DdlRegistration.SelectedValue = col[5].ToString();
                DdlDep.SelectedValue = col[0].ToString();
                if (DdlDep.SelectedValue != "")
                {
                    Bind_DdlPost(DdlDep.SelectedValue.ToString());
                    DdlPost.Items.FindByValue(col[2].ToString()).Selected = true;
                }
                Bind_DdlType(DdlType);
                DdlType.Items.FindByValue(col[1].ToString()).Selected = true;
                TxtBasicWage.Text = col[6].ToString();
                TxtFullTimeWage.Text = col[7].ToString();
                TxtPerformWage.Text = col[8].ToString();
                TxtOverTimeWage.Text = col[9].ToString();
                if (col[10].ToString() == Convert.ToDateTime("1/1/1753 12:00:00 AM").ToString())
                    TxtConverseDate.Text = "";
                else
                    TxtConverseDate.Text = col[10].ToString();
                if (col[11].ToString() == Convert.ToDateTime("1/1/1753 12:00:00 AM").ToString())
                    TxtContactSDate.Text = "";
                else
                    TxtContactSDate.Text = col[11].ToString();
                if (col[12].ToString() == Convert.ToDateTime("1/1/1753 12:00:00 AM").ToString())
                    TxtContactEDate.Text = "";
                else
                    TxtContactEDate.Text = col[12].ToString();
                TxtWorklength.Text = col[13].ToString();
                if (col[14].ToString() == Convert.ToDateTime("1/1/1753 12:00:00 AM").ToString())
                    TxtEntryDate.Text = "";
                else
                    TxtEntryDate.Text = col[14].ToString();
                //TxtWorkAge.Text = hR.WorkAge.ToString();
                DdlSex.SelectedValue = col[16].ToString();
                if (col[15].ToString() == Convert.ToDateTime("1/1/1753 12:00:00 AM").ToString())
                    TxtDateOfBirth.Text = "";
                else
                    TxtDateOfBirth.Text = col[15].ToString();
                TxtIDCard.Text = col[17].ToString(); ;
                DdlIsMarried.SelectedValue = col[19].ToString();
                TxtNationality.Text = col[18].ToString();
                DdlEduBackg.SelectedValue = col[20].ToString();
                TxtMajor.Text = col[21].ToString();
                TxtGSchool.Text = col[22].ToString();
                TxtHAddress.Text = col[23].ToString();
                TxtTel.Text = col[24].ToString();
                DdlHasSocial.SelectedValue = col[25].ToString().Trim();
                DdlHasAccumulation.SelectedValue = col[26].ToString().Trim();
                DdlCertificateComplete.SelectedValue = col[27].ToString().Trim();
                TxtEmergencyPer.Text = col[28].ToString();
                TxtEmergencyNo.Text = col[29].ToString();
                if (col[30].ToString() == Convert.ToDateTime("1/1/1753 12:00:00 AM").ToString())
                    TextBox1.Text = "";
                else
                    TextBox1.Text = col[30].ToString();
                TextBox2.Text = col[32].ToString();
                TextBox3.Text = col[31].ToString();
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('查看详情失败，请联系管理员！" + ex + "')", true);
                return;
            }

            UpdatePanel_Detail.Update();

        }
        if (e.CommandName == "Edit_Detail")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_Detail.SelectedIndex = row.RowIndex;

            ClearDetail();
            Panel_Detail.Visible = true;
            if (!BtnSubmit.Visible)
            {
                BtnSubmit.Visible = true;
            }
            UpdatePanel_Detail.Update();
            //LblState.Text = "Edit_Detail";
            //为Dropdownlist绑定值，否则会出错
            SetValueForAllDdl();
            TxtStaffNO.Enabled = true;

            GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            g = new Guid(e.CommandArgument.ToString());
            if (Request.QueryString["status"].ToString() == "documentMain_Quit" && Session["UserRole"].ToString().Contains("离职员工档案维护"))
            {
                LblState.Text = "Edit_Detail_Quit";
                Panel3.Visible = true;
                TxtStaffNO.Enabled = true;
                try
                {
                    DataSet hR = hRDDetailL.SearchByID_HRDDetail_Type_Post_Quit(g);
                    DataRow col = hR.Tables[0].Rows[0];
                    TxtStaffNO.Text = col[3].ToString();
                    TxtName.Text = col[4].ToString();
                    DdlRegistration.SelectedValue = col[5].ToString();
                    DdlDep.SelectedValue = col[0].ToString();
                    if (DdlDep.SelectedValue != "")
                    {
                        Bind_DdlPost(DdlDep.SelectedValue.ToString());
                        DdlPost.Items.FindByValue(col[2].ToString()).Selected = true;
                    }
                    Bind_DdlType(DdlType);
                    DdlType.Items.FindByValue(col[1].ToString()).Selected = true;
                    TxtBasicWage.Text = col[6].ToString();
                    TxtFullTimeWage.Text = col[7].ToString();
                    TxtPerformWage.Text = col[8].ToString();
                    TxtOverTimeWage.Text = col[9].ToString();
                    if (col[10].ToString() == Convert.ToDateTime("1/1/1753 12:00:00 AM").ToString())
                        TxtConverseDate.Text = "";
                    else
                        TxtConverseDate.Text = col[10].ToString();
                    if (col[11].ToString() == Convert.ToDateTime("1/1/1753 12:00:00 AM").ToString())
                        TxtContactSDate.Text = "";
                    else
                        TxtContactSDate.Text = col[11].ToString();
                    if (col[12].ToString() == Convert.ToDateTime("1/1/1753 12:00:00 AM").ToString())
                        TxtContactEDate.Text = "";
                    else
                        TxtContactEDate.Text = col[12].ToString();
                    TxtWorklength.Text = col[13].ToString();
                    if (col[14].ToString() == Convert.ToDateTime("1/1/1753 12:00:00 AM").ToString())
                        TxtEntryDate.Text = "";
                    else
                        TxtEntryDate.Text = col[14].ToString();
                    //TxtWorkAge.Text = hR.WorkAge.ToString();
                    DdlSex.SelectedValue = col[16].ToString();
                    if (col[15].ToString() == Convert.ToDateTime("1/1/1753 12:00:00 AM").ToString())
                        TxtDateOfBirth.Text = "";
                    else
                        TxtDateOfBirth.Text = col[15].ToString();
                    TxtIDCard.Text = col[17].ToString(); ;
                    DdlIsMarried.SelectedValue = col[19].ToString();
                    TxtNationality.Text = col[18].ToString();
                    DdlEduBackg.SelectedValue = col[20].ToString();
                    TxtMajor.Text = col[21].ToString();
                    TxtGSchool.Text = col[22].ToString();
                    TxtHAddress.Text = col[23].ToString();
                    TxtTel.Text = col[24].ToString();
                    DdlHasSocial.SelectedValue = col[25].ToString().Trim();
                    DdlHasAccumulation.SelectedValue = col[26].ToString().Trim();
                    DdlCertificateComplete.SelectedValue = col[27].ToString();
                    TxtEmergencyPer.Text = col[28].ToString();
                    TxtEmergencyNo.Text = col[29].ToString();
                    if (col[30].ToString() == Convert.ToDateTime("1/1/1753 12:00:00 AM").ToString())
                        TextBox1.Text = "";
                    else
                        TextBox1.Text = col[30].ToString();
                    TextBox2.Text = col[32].ToString();
                    TextBox3.Text = col[31].ToString();
                }
                catch (Exception ex)
                {

                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('编辑失败！" + ex + "')", true);
                    return;
                }
            }
            else
            {
                LblState.Text = "Edit_Detail";
                Panel3.Visible = false;
                TxtStaffNO.Enabled = true;
                try
                {
                    DataSet hR = hRDDetailL.SearchByID_HRDDetail_Type_Post(g);
                    DataRow col = hR.Tables[0].Rows[0];
                    TxtStaffNO.Text = col[3].ToString();
                    TxtName.Text = col[4].ToString();
                    DdlRegistration.SelectedValue = col[5].ToString();
                    DdlDep.SelectedValue = col[0].ToString();
                    if (DdlDep.SelectedValue != "")
                    {
                        Bind_DdlPost(DdlDep.SelectedValue.ToString());
                        DdlPost.Items.FindByValue(col[2].ToString()).Selected = true;
                    }
                    Bind_DdlType(DdlType);
                    DdlType.Items.FindByValue(col[1].ToString()).Selected = true;
                    TxtBasicWage.Text = col[6].ToString();
                    TxtFullTimeWage.Text = col[7].ToString();
                    TxtPerformWage.Text = col[8].ToString();
                    TxtOverTimeWage.Text = col[9].ToString();
                    if (col[10].ToString() == Convert.ToDateTime("1/1/1753 12:00:00 AM").ToString())
                        TxtConverseDate.Text = "";
                    else
                        TxtConverseDate.Text = col[10].ToString();
                    if (col[11].ToString() == Convert.ToDateTime("1/1/1753 12:00:00 AM").ToString())
                        TxtContactSDate.Text = "";
                    else
                        TxtContactSDate.Text = col[11].ToString();
                    if (col[12].ToString() == Convert.ToDateTime("1/1/1753 12:00:00 AM").ToString())
                        TxtContactEDate.Text = "";
                    else
                        TxtContactEDate.Text = col[12].ToString();
                    TxtWorklength.Text = col[13].ToString();
                    if (col[14].ToString() == Convert.ToDateTime("1/1/1753 12:00:00 AM").ToString())
                        TxtEntryDate.Text = "";
                    else
                        TxtEntryDate.Text = col[14].ToString();
                    //TxtWorkAge.Text = hR.WorkAge.ToString();
                    DdlSex.SelectedValue = col[16].ToString();
                    if (col[15].ToString() == Convert.ToDateTime("1/1/1753 12:00:00 AM").ToString())
                        TxtDateOfBirth.Text = "";
                    else
                        TxtDateOfBirth.Text = col[15].ToString();
                    TxtIDCard.Text = col[17].ToString(); ;
                    DdlIsMarried.SelectedValue = col[19].ToString();
                    TxtNationality.Text = col[18].ToString();
                    DdlEduBackg.SelectedValue = col[20].ToString();
                    TxtMajor.Text = col[21].ToString();
                    TxtGSchool.Text = col[22].ToString();
                    TxtHAddress.Text = col[23].ToString();
                    TxtTel.Text = col[24].ToString();
                    DdlHasSocial.SelectedValue = col[25].ToString().Trim();
                    DdlHasAccumulation.SelectedValue = col[26].ToString().Trim();
                    DdlCertificateComplete.SelectedValue = col[27].ToString();
                    TxtEmergencyPer.Text = col[28].ToString();
                    TxtEmergencyNo.Text = col[29].ToString();
                }
                catch (Exception ex)
                {

                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('编辑失败！" + ex + "')", true);
                    return;
                }
            }
            Grid_Detail.SelectedIndex = -1;
            UpdatePanel_Detail.Update();


        }
        if (e.CommandName == "Delete_Detail")//删除在职员工
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_Detail.SelectedIndex = -1;

            Guid guid = new Guid(e.CommandArgument.ToString());
            hRDDetailL.Delete_HRDDetail(guid);
            BindGrid("");
        }
        if (e.CommandName == "PersonnelChanges")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_Detail.SelectedIndex = row.RowIndex;
            Panel_Changes.Visible = true;
            LblRecordID.Text = e.CommandArgument.ToString();
            UpdatePanel_Changes.Update();
            Guid guid = new Guid(e.CommandArgument.ToString());
            try
            {
                HRDDetailInfo hR = hRDDetailL.SearchByIDPart_HRDDetail(guid)[0];
                TxtStaffNOChange.Text = hR.HRDD_StaffNO;
                TxtNameChange.Text = hR.HRDD_Name;
                Bind_DdlDep(DdlDepChangeBefore);
                DdlDepChangeBefore.SelectedValue = hR.BDOS_Code;
                if (DdlDepChangeBefore.SelectedValue != "")
                {
                    Bind_DdlPostChangeBefore(DdlDepChangeBefore.SelectedValue.ToString());
                    DdlPostChangeBefore.Items.FindByValue(hR.HRP_ID.ToString()).Selected = true;
                }
                Bind_DdlDep(DdlDepChangeAfter);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            TxtManager.Text = Session["UserName"].ToString().Trim();
            TxtTime.Text = DateTime.Now.ToString();
            if (Panel_Record.Visible == true && TxtStaffNOChange.Text != TxtStaffNORecord.Text)
            {
                Panel_Record.Visible = false;
                UpdatePanel_Record.Update();
            }

        }
        if (e.CommandName == "Look_PersonnelChangesRecord")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_Detail.SelectedIndex = row.RowIndex;
            Panel_Record.Visible = true;
            TxtStaffNORecord.Text = row.Cells[2].Text.ToString();
            TxtNameRecord.Text = row.Cells[3].Text.ToString();
            try
            {
                Grid_ChangeRecord.DataSource = hRDDetailL.Search_HRPersonnelChangesRecord(new Guid(e.CommandArgument.ToString()));
                Grid_ChangeRecord.DataBind();

            }
            catch (Exception ex)
            {

                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('查看失败，请联系管理员！" + ex + "')", true);
                return;
            }
            UpdatePanel_Record.Update();
            if (Panel_Changes.Visible == true && TxtStaffNOChange.Text != TxtStaffNORecord.Text)
            {
                Panel_Changes.Visible = false;
                UpdatePanel_Changes.Update();
            }

        }
        if (e.CommandName == "SalaryChange")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_Detail.SelectedIndex = row.RowIndex;
            Panel_SalaryChange.Visible = true;
            LblRecordID.Text = e.CommandArgument.ToString();
            UpdatePanel_SalaryChange.Update();
            Guid guid = new Guid(e.CommandArgument.ToString());
            try
            {
                HRDDetailInfo hR = hRDDetailL.SearchByIDPartForSalary_HRDDetail(guid)[0];
                TxtStaffNOSalaryChange.Text = hR.HRDD_StaffNO;
                TxtNameSalaryChange.Text = hR.HRDD_Name;
                TxtFormerBasicSalary.Text = hR.HRDD_BasicWage.ToString();
                TxtFormerFullTimeWage.Text = hR.HRDD_FullTimeWage.ToString();
                TxtFormerPerformWage.Text = hR.HRDD_PerformWage.ToString();
                TxtFormerOverTimeWage.Text = hR.HRDD_OverTimeWage.ToString();
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('调薪失败，请联系管理员！" + ex + "')", true);
                return;
            }
            TxtChargePer.Text = Session["UserName"].ToString().Trim();
            TxtSalryTime.Text = DateTime.Now.ToString();

            if (Panel_SalaryRecord.Visible == true && TxtSRecordStaffNO.Text != TxtStaffNOSalaryChange.Text)
            {
                Panel_SalaryRecord.Visible = false;
                UpdatePanel_SalaryRecord.Update();
            }
        }
        if (e.CommandName == "Look_SalaryRecord")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_Detail.SelectedIndex = row.RowIndex;
            Panel_SalaryRecord.Visible = true;
            Label22.Text = e.CommandArgument.ToString();
            TxtSRecordStaffNO.Text = row.Cells[2].Text.ToString();
            TxtSRecordName.Text = row.Cells[3].Text.ToString();
            try
            {
                GridView_SalaryRecord.DataSource = hRDDetailL.Search_HRSalaryRecord(new Guid(e.CommandArgument.ToString()));
                GridView_SalaryRecord.DataBind();

            }
            catch (Exception ex)
            {

                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('查看失败，请联系管理员！" + ex + "')", true);
                return;
            }
            UpdatePanel_SalaryRecord.Update();
            if (Panel_SalaryChange.Visible == true && TxtSRecordStaffNO.Text != TxtStaffNOSalaryChange.Text)
            {
                Panel_SalaryChange.Visible = false;
                UpdatePanel_SalaryChange.Update();
            }
        }
        if (e.CommandName == "Edit_Quit")//离职
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_Detail.SelectedIndex = row.RowIndex;

            ClearDetail();
            Panel_Detail.Visible = true;
            UpdatePanel_Detail.Update();
            if (!BtnSubmit.Visible)
            {
                BtnSubmit.Visible = true;
            }
            LblState.Text = "Edit_Quit";
            //为Dropdownlist绑定值，否则会出错
            SetValueForAllDdl();
            Panel3.Visible = true;
            //DdlType.Enabled = false;
            //TxtName.Enabled = false;
            //DdlDep.Enabled = false;
            //DdlPost.Enabled = false;
            //DdlSex.Enabled = false;
            TxtStaffNO.Enabled = true;

            GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            g = new Guid(e.CommandArgument.ToString());
            try
            {
                DataSet hR = hRDDetailL.SearchByID_HRDDetail_Type_Post_Quit(g);
                DataRow col = hR.Tables[0].Rows[0];
                TxtStaffNO.Text = col[3].ToString();
                TxtName.Text = col[4].ToString();
                DdlRegistration.SelectedValue = col[5].ToString();
                DdlDep.SelectedValue = col[0].ToString();
                if (DdlDep.SelectedValue != "")
                {
                    Bind_DdlPost(DdlDep.SelectedValue.ToString());
                    DdlPost.Items.FindByValue(col[2].ToString()).Selected = true;
                }
                Bind_DdlType(DdlType);
                //DdlType.Items.FindByValue(col[1].ToString()).Selected = true;
                DdlType.Items.FindByText("离职员工").Selected = true;
                TxtBasicWage.Text = col[6].ToString();
                TxtFullTimeWage.Text = col[7].ToString();
                TxtPerformWage.Text = col[8].ToString();
                TxtOverTimeWage.Text = col[9].ToString();
                if (col[10].ToString() == Convert.ToDateTime("1/1/1753 12:00:00 AM").ToString())
                    TxtConverseDate.Text = "";
                else
                    TxtConverseDate.Text = col[10].ToString();
                if (col[11].ToString() == Convert.ToDateTime("1/1/1753 12:00:00 AM").ToString())
                    TxtContactSDate.Text = "";
                else
                    TxtContactSDate.Text = col[11].ToString();
                if (col[12].ToString() == Convert.ToDateTime("1/1/1753 12:00:00 AM").ToString())
                    TxtContactEDate.Text = "";
                else
                    TxtContactEDate.Text = col[12].ToString();
                TxtWorklength.Text = col[13].ToString();
                if (col[14].ToString() == Convert.ToDateTime("1/1/1753 12:00:00 AM").ToString())
                    TxtEntryDate.Text = "";
                else
                    TxtEntryDate.Text = col[14].ToString();
                //TxtWorkAge.Text = hR.WorkAge.ToString();
                DdlSex.SelectedValue = col[16].ToString();
                if (col[15].ToString() == Convert.ToDateTime("1/1/1753 12:00:00 AM").ToString())
                    TxtDateOfBirth.Text = "";
                else
                    TxtDateOfBirth.Text = col[15].ToString();
                TxtIDCard.Text = col[17].ToString(); ;
                DdlIsMarried.SelectedValue = col[19].ToString();
                TxtNationality.Text = col[18].ToString();
                DdlEduBackg.SelectedValue = col[20].ToString();
                TxtMajor.Text = col[21].ToString();
                TxtGSchool.Text = col[22].ToString();
                TxtHAddress.Text = col[23].ToString();
                TxtTel.Text = col[24].ToString();
                DdlHasSocial.SelectedValue = col[25].ToString();
                DdlHasAccumulation.SelectedValue = col[26].ToString();
                DdlCertificateComplete.SelectedValue = col[27].ToString();
                TxtEmergencyPer.Text = col[28].ToString();
                TxtEmergencyNo.Text = col[29].ToString();
                if (col[30].ToString() == Convert.ToDateTime("1/1/1753 12:00:00 AM").ToString())
                    TextBox1.Text = "";
                else
                    TextBox1.Text = col[30].ToString();
                TextBox2.Text = col[32].ToString();
                TextBox3.Text = col[31].ToString();
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('编辑失败！" + ex + "')", true);
                return;
            }
            Grid_Detail.SelectedIndex = -1;
            UpdatePanel_Detail.Update();
        }
        if (e.CommandName == "Edit_Re")//复职
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_Detail.SelectedIndex = row.RowIndex;

            ClearDetail();
            Panel_Detail.Visible = true;
            UpdatePanel_Detail.Update();
            if (!BtnSubmit.Visible)
            {
                BtnSubmit.Visible = true;
            }
            LblState.Text = "Edit_Re";
            //为Dropdownlist绑定值，否则会出错
            SetValueForAllDdl();
            //ListItem ff = DdlType.Items.FindByText("离职员工");
            //DdlType.Items.Remove(ff);
            Panel3.Visible = true;
            TxtStaffNO.Enabled = false;
            TxtStaffNO.Text = "";

            GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            g = new Guid(e.CommandArgument.ToString());
            try
            {
                DataSet hR = hRDDetailL.SearchByID_HRDDetail_Type_Post_Quit(g);
                DataRow col = hR.Tables[0].Rows[0];
                //TxtStaffNO.Text = col[3].ToString();
                TxtName.Text = col[4].ToString();
                DdlRegistration.SelectedValue = col[5].ToString();
                DdlDep.SelectedValue = col[0].ToString();
                if (DdlDep.SelectedValue != "")
                {
                    Bind_DdlPost(DdlDep.SelectedValue.ToString());
                    DdlPost.Items.FindByValue(col[2].ToString()).Selected = true;
                }
                Bind_DdlType(DdlType);
                DdlType.Items.FindByValue(col[1].ToString()).Selected = true;
                TxtBasicWage.Text = col[6].ToString();
                TxtFullTimeWage.Text = col[7].ToString();
                TxtPerformWage.Text = col[8].ToString();
                TxtOverTimeWage.Text = col[9].ToString();
                if (col[10].ToString() == Convert.ToDateTime("1/1/1753 12:00:00 AM").ToString())
                    TxtConverseDate.Text = "";
                else
                    TxtConverseDate.Text = col[10].ToString();
                if (col[11].ToString() == Convert.ToDateTime("1/1/1753 12:00:00 AM").ToString())
                    TxtContactSDate.Text = "";
                else
                    TxtContactSDate.Text = col[11].ToString();
                if (col[12].ToString() == Convert.ToDateTime("1/1/1753 12:00:00 AM").ToString())
                    TxtContactEDate.Text = "";
                else
                    TxtContactEDate.Text = col[12].ToString();
                TxtWorklength.Text = col[13].ToString();
                //if (col[14].ToString() == Convert.ToDateTime("1/1/1753 12:00:00 AM").ToString())
                //    TxtEntryDate.Text = "";
                //else
                //    TxtEntryDate.Text = col[14].ToString();
                TxtWorklength.Text = "";
                DdlSex.SelectedValue = col[16].ToString();
                if (col[15].ToString() == Convert.ToDateTime("1/1/1753 12:00:00 AM").ToString())
                    TxtDateOfBirth.Text = "";
                else
                    TxtDateOfBirth.Text = col[15].ToString();
                TxtIDCard.Text = col[17].ToString(); ;
                DdlIsMarried.SelectedValue = col[19].ToString();
                TxtNationality.Text = col[18].ToString();
                DdlEduBackg.SelectedValue = col[20].ToString();
                TxtMajor.Text = col[21].ToString();
                TxtGSchool.Text = col[22].ToString();
                TxtHAddress.Text = col[23].ToString();
                TxtTel.Text = col[24].ToString();
                DdlHasSocial.SelectedValue = col[25].ToString();
                DdlHasAccumulation.SelectedValue = col[26].ToString();
                DdlCertificateComplete.SelectedValue = col[27].ToString();
                TxtEmergencyPer.Text = col[28].ToString();
                TxtEmergencyNo.Text = col[29].ToString();
                if (col[30].ToString() == Convert.ToDateTime("1/1/1753 12:00:00 AM").ToString())
                    TextBox1.Text = "";
                else
                    TextBox1.Text = col[30].ToString();
                TextBox2.Text = col[32].ToString();
                TextBox3.Text = col[31].ToString();
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('编辑失败！" + ex + "')", true);
                return;
            }
            Grid_Detail.SelectedIndex = -1;
            UpdatePanel_Detail.Update();
        }
        if (e.CommandName == "Delete_DetailQuit")//删除离职员工
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_Detail.SelectedIndex = -1;

            Guid guid = new Guid(e.CommandArgument.ToString());
            hRDDetailL.Delete_HRDDetail_Quit(guid);
            BindGrid_Quit("");
        }
        if (e.CommandName == "RewardsPublishment")//奖惩
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_Detail.SelectedIndex = row.RowIndex;

            Panel_reward.Visible = true;
            Label97.Text = e.CommandArgument.ToString();
            TextBox4.Text = row.Cells[2].Text.ToString();
            TextBox5.Text = row.Cells[3].Text.ToString();
            Label88.Visible = true;
            TextBox4.Visible = true;
            Label89.Visible = true;
            TextBox5.Visible = true;
            UpdatePane_reward.Update();
            Panel4.Visible = false;
            UpdatePanel4.Update();
            try
            {
                BindGridView_Reward(" and HRDD_ID='" + Label97.Text + "'");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('数据有误，请联系管理员！" + ex + "')", true);
                return;
            }
            condition = TxtSStaffNO.Text.Trim() == "" ? "" : " and HRDD_StaffNO like '%" + TxtSStaffNO.Text.Trim() + "%'";
            condition += TxtSName.Text.Trim() == "" ? "" : " and HRDD_Name like '%" + TxtSName.Text.Trim() + "%'";
            condition += DdlSDep.SelectedValue == "" ? "" : " and b.BDOS_Code ='" + DdlSDep.SelectedValue + "'";
            condition += DdlSPost.SelectedValue == "" ? "" : " and a.HRP_ID ='" + DdlSPost.SelectedValue + "'";
            condition += DdlSType.SelectedValue == "" ? "" : " and a.HRET_ID ='" + DdlSType.SelectedValue + "'";
            try
            {
                if (Request.QueryString["status"].ToString() == "documentMain_Quit" && Session["UserRole"].ToString().Contains("离职员工档案维护"))
                {
                    BindGrid_Quit(condition);
                }
                else
                {
                    BindGrid(condition);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    protected void BtnSubmit_Click(object sender, EventArgs e)
    {

        if (LblState.Text == "New")
        {
            if (TxtName.Text == "" || DdlDep.Text == ""
                || DdlPost.Text == "" || DdlType.Text == ""
                || TxtBasicWage.Text == "" || TxtFullTimeWage.Text == "" || TxtPerformWage.Text == ""
                || TxtOverTimeWage.Text == "" || TxtEntryDate.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            hRDDetailInfo.HRDD_ID = Guid.NewGuid();
            //if (this.TxtStaffNO.Text == "")
            //{
            //    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('工号不能为空！')", true);
            //    return;
            //}
            //else
            //    hRDDetailInfo.HRDD_StaffNO = this.TxtStaffNO.Text;
            if (TxtName.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('姓名不能为空！')", true);
                return;
            }
            else
                hRDDetailInfo.HRDD_Name = TxtName.Text;

            if (DdlPost.SelectedValue == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请先选择部门，然后选择岗位！')", true);
                return;
            }
            else
                hRDDetailInfo.HRP_ID = new Guid(DdlPost.SelectedValue);
            if (DdlType.SelectedValue == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请选择员工类型！')", true);
                return;
            }
            if (DdlType.SelectedItem.Text == "离职员工")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请选择正确的员工类型！')", true);
                return;
            }
            else
                hRDDetailInfo.HRET_ID = new Guid(DdlType.SelectedValue);

            hRDDetailInfo.HRDD_Registration = DdlRegistration.SelectedValue;
            decimal m1;
            if (Decimal.TryParse(TxtBasicWage.Text, out m1))
                hRDDetailInfo.HRDD_BasicWage = m1;
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的基本工资！')", true);
                return;
            }
            if (hRDDetailInfo.HRDD_BasicWage < 0)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('基本工资不合法！')", true);
                return;
            }
            decimal m2;
            if (Decimal.TryParse(TxtFullTimeWage.Text, out m2))
                hRDDetailInfo.HRDD_FullTimeWage = m2;
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的全勤工资！')", true);
                return;
            }
            if (hRDDetailInfo.HRDD_FullTimeWage < 0)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('全勤工资不合法！')", true);
                return;
            }
            decimal m3;
            if (Decimal.TryParse(TxtPerformWage.Text, out m3))
                hRDDetailInfo.HRDD_PerformWage = m3;
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的绩效工资！')", true);
                return;
            }
            if (hRDDetailInfo.HRDD_PerformWage < 0)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('绩效工资不合法！')", true);
                return;
            }
            decimal m4;
            if (Decimal.TryParse(TxtOverTimeWage.Text, out m4))
                hRDDetailInfo.HRDD_OverTimeWage = m4;
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的加班工资！')", true);
                return;
            }
            if (hRDDetailInfo.HRDD_OverTimeWage < 0)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('加班工资不合法！')", true);
                return;
            }

            //日期的控制 开始
            if (TxtConverseDate.Text == "")
                hRDDetailInfo.HRDD_ConverseDate = Convert.ToDateTime("1/1/1753 12:00:00 AM");
            else
            {
                DateTime d1;

                if (DateTime.TryParse(TxtConverseDate.Text, out d1))
                    hRDDetailInfo.HRDD_ConverseDate = d1;
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的转正日期！')", true);
                    return;
                }
            }


            if (TxtContactSDate.Text == "")
                hRDDetailInfo.HRDD_ContactSDate = Convert.ToDateTime("1/1/1753 12:00:00 AM");
            else
            {
                DateTime d2;
                if (DateTime.TryParse(TxtContactSDate.Text, out d2))
                    hRDDetailInfo.HRDD_ContactSDate = d2;
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的合同签订日期！')", true);
                    return;
                }
            }
            if (TxtContactEDate.Text == "")
                hRDDetailInfo.HRDD_ContactEDate = Convert.ToDateTime("1/1/1753 12:00:00 AM");
            else
            {
                DateTime d3;

                if (DateTime.TryParse(TxtContactEDate.Text, out d3))
                    hRDDetailInfo.HRDD_ContactEDate = d3;
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的合同到期日期！')", true);
                    return;
                }
            }

            if (TxtEntryDate.Text == "")
                hRDDetailInfo.HRDD_EntryDate = Convert.ToDateTime("1/1/1753 12:00:00 AM");
            else
            {
                DateTime d5;
                if (DateTime.TryParse(TxtEntryDate.Text, out d5))
                    hRDDetailInfo.HRDD_EntryDate = d5;
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的入职日期！')", true);
                    return;
                }
            }
            //自动计算工龄
            DateTime q1 = Convert.ToDateTime(TxtEntryDate.Text);
            DateTime q2 = DateTime.Now;
            hRDDetailInfo.HRDD_Worklength = Convert.ToInt32((q2.Subtract(q1)).Days / 365);

            //日期的控制 结束
            if (TxtIDCard.Text.Length != 18 && TxtIDCard.Text != "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的身份证号！')", true);
                return;
            }
            else
            {
                hRDDetailInfo.HRDD_IDCard = TxtIDCard.Text;
            }
            hRDDetailInfo.HRDD_IsMarried = DdlIsMarried.SelectedValue;
            hRDDetailInfo.HRDD_Nationality = TxtNationality.Text;
            hRDDetailInfo.HRDD_EduBackg = DdlEduBackg.SelectedValue;
            hRDDetailInfo.HRDD_Major = TxtMajor.Text;
            hRDDetailInfo.HRDD_GSchool = TxtGSchool.Text;
            hRDDetailInfo.HRDD_HAddress = TxtHAddress.Text;
            hRDDetailInfo.HRDD_Tel = TxtTel.Text;
            hRDDetailInfo.HRDD_HasSocial = DdlHasSocial.SelectedValue;
            hRDDetailInfo.HRDD_HasAccumulation = DdlHasAccumulation.SelectedValue;
            hRDDetailInfo.HRDD_CertificateComplete = DdlCertificateComplete.SelectedValue;
            hRDDetailInfo.HRDD_EmergencyPer = TxtEmergencyPer.Text;
            hRDDetailInfo.HRDD_EmergencyNo = TxtEmergencyNo.Text;

            hRDDetailInfo.HRDD_IsDeleted = false;
            try
            {
                int i = hRDDetailL.Insert_HRDDetail(hRDDetailInfo);
                if (i <= 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('重复的工号！')", true);
                    return;
                }
            }
            catch (Exception exc)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('新增失败！" + exc + "')", true);
            }
            ClearDetail();
            if (LblRecordIsSearch.Text == "检索前")
                BindGrid("");
            if (LblRecordIsSearch.Text == "检索后")
                BindGrid(condition);
            Panel_Detail.Visible = false;
            UpdatePanel_Grid.Update();
            UpdatePanel_Detail.Update();
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('新增成功！')", true);


        }
        if (LblState.Text == "Edit_Detail")
        {
            if (TxtName.Text == "" || DdlDep.Text == ""
                || DdlPost.Text == "" || DdlType.Text == ""
                || TxtBasicWage.Text == "" || TxtFullTimeWage.Text == "" || TxtPerformWage.Text == ""
                || TxtOverTimeWage.Text == "" || TxtEntryDate.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            try
            {
                HRDDetailInfo hr = new HRDDetailInfo();
                hr.HRDD_ID = g;

                DataSet ds = hRDDetailL.Search_HRDDetail(" and HRDD_StaffNO='" + TxtStaffNO.Text.ToString() + "' and HRDD_ID!='" + g + "'");
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count != 0)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('已有工号，不能重复！')", true);
                    return;
                }
                if (TxtStaffNO.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('工号不能为空！')", true);
                    return;
                }
                else
                    hr.HRDD_StaffNO = TxtStaffNO.Text;
                if (TxtName.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('姓名不能为空！')", true);
                    return;
                }
                else
                    hr.HRDD_Name = TxtName.Text;

                if (DdlPost.SelectedValue == "")
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请先选择部门，然后选择岗位！')", true);
                    return;
                }
                else
                    hr.HRP_ID = new Guid(DdlPost.SelectedValue);
                if (DdlType.SelectedValue == "")
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请选择员工类型！')", true);
                    return;
                }
                if (DdlType.SelectedItem.Text == "离职员工")
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请选择正确的员工类型！')", true);
                    return;
                }
                else
                    hr.HRET_ID = new Guid(DdlType.SelectedValue);

                hr.HRDD_Registration = DdlRegistration.SelectedValue;
                decimal mm1;
                if (Decimal.TryParse(TxtBasicWage.Text, out mm1))
                    hr.HRDD_BasicWage = mm1;
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的基本工资！')", true);
                    return;
                }
                if (hr.HRDD_BasicWage < 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('基本工资不合法！')", true);
                    return;
                }
                decimal mm2;
                if (Decimal.TryParse(TxtFullTimeWage.Text, out mm2))
                    hr.HRDD_FullTimeWage = mm2;
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的全勤工资！')", true);
                    return;
                }
                if (hr.HRDD_FullTimeWage < 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('全勤工资不合法！')", true);
                    return;
                }
                decimal mm3;
                if (Decimal.TryParse(TxtPerformWage.Text, out mm3))
                    hr.HRDD_PerformWage = mm3;
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的绩效工资！')", true);
                    return;
                }
                if (hr.HRDD_PerformWage < 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('绩效工资不合法！')", true);
                    return;
                }
                decimal mm4;
                if (Decimal.TryParse(TxtOverTimeWage.Text, out mm4))
                    hr.HRDD_OverTimeWage = mm4;
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的加班工资！')", true);
                    return;
                }
                if (hr.HRDD_OverTimeWage < 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('加班工资不合法！')", true);
                    return;
                }

                if (TxtConverseDate.Text == "")
                    hr.HRDD_ConverseDate = Convert.ToDateTime("1/1/1753 12:00:00 AM");
                else
                {
                    DateTime d1;
                    if (DateTime.TryParse(TxtConverseDate.Text, out d1))
                        hr.HRDD_ConverseDate = d1;
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的转正日期！')", true);
                        return;
                    }
                }
                if (TxtContactSDate.Text == "")
                    hr.HRDD_ContactSDate = Convert.ToDateTime("1/1/1753 12:00:00 AM");
                else
                {
                    DateTime d2;
                    if (DateTime.TryParse(TxtContactSDate.Text, out d2))
                        hr.HRDD_ContactSDate = d2;
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的合同签订日期！')", true);
                        return;
                    }
                }
                if (TxtContactEDate.Text == "")
                    hr.HRDD_ContactEDate = Convert.ToDateTime("1/1/1753 12:00:00 AM");
                else
                {
                    DateTime d3;
                    if (DateTime.TryParse(TxtContactEDate.Text, out d3))
                        hr.HRDD_ContactEDate = d3;
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的合同到期日期！')", true);
                        return;
                    }
                }

                if (TxtEntryDate.Text == "")
                    hr.HRDD_EntryDate = Convert.ToDateTime("1/1/1753 12:00:00 AM");
                else
                {
                    DateTime d5;
                    if (DateTime.TryParse(TxtEntryDate.Text, out d5))
                        hr.HRDD_EntryDate = d5;
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的入职日期！')", true);
                        return;
                    }
                }

                //自动计算工龄
                DateTime q1 = Convert.ToDateTime(TxtEntryDate.Text);
                DateTime q2 = DateTime.Now;
                hr.HRDD_Worklength = Convert.ToInt32((q2.Subtract(q1)).Days / 365);

                if (TxtIDCard.Text.Length != 18 && TxtIDCard.Text != "")
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的身份证号！')", true);
                    return;
                }
                else
                {
                    hr.HRDD_IDCard = TxtIDCard.Text;
                }
                hr.HRDD_IsMarried = DdlIsMarried.SelectedValue;
                hr.HRDD_Nationality = TxtNationality.Text;
                hr.HRDD_EduBackg = DdlEduBackg.SelectedValue;
                hr.HRDD_Major = TxtMajor.Text;
                hr.HRDD_GSchool = TxtGSchool.Text;
                hr.HRDD_HAddress = TxtHAddress.Text;
                hr.HRDD_Tel = TxtTel.Text;
                hr.HRDD_HasSocial = DdlHasSocial.SelectedValue;
                hr.HRDD_HasAccumulation = DdlHasAccumulation.SelectedValue;
                hr.HRDD_CertificateComplete = DdlCertificateComplete.SelectedValue;
                hr.HRDD_EmergencyPer = TxtEmergencyPer.Text;
                hr.HRDD_EmergencyNo = TxtEmergencyNo.Text;


                int u = hRDDetailL.Update_HRDDetail(hr);
                if (u <= 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('重复的工号！')", true);
                    return;
                }
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('编辑失败！" + ex + "')", true);
            }
            ClearDetail();
            Panel_Detail.Visible = false;
            if (LblRecordIsSearch.Text == "检索前")
                BindGrid("");
            if (LblRecordIsSearch.Text == "检索后")
                BindGrid(condition);
            UpdatePanel_Grid.Update();
            UpdatePanel_Detail.Update();
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('编辑成功！')", true);
        }
        if (LblState.Text == "Edit_Detail_Quit")
        {
            if (TxtName.Text == "" || DdlDep.Text == ""
                || DdlPost.Text == "" || DdlType.Text == ""
                || TxtBasicWage.Text == "" || TxtFullTimeWage.Text == "" || TxtPerformWage.Text == ""
                || TxtOverTimeWage.Text == "" || TxtEntryDate.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            try
            {
                HRDDetailInfo hr = new HRDDetailInfo();
                hr.HRDD_ID = g;
                DataSet ds = hRDDetailL.Search_HRDDetail(" and HRDD_StaffNO='" + TxtStaffNO.Text.ToString() + "' and HRDD_ID!='" + g + "'");
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count != 0)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('已有工号，不能重复！')", true);
                    return;
                }
                hr.HRDD_StaffNO = TxtStaffNO.Text;
                if (TxtName.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('姓名不能为空！')", true);
                    return;
                }
                else
                    hr.HRDD_Name = TxtName.Text;

                if (DdlPost.SelectedValue == "")
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请先选择部门，然后选择岗位！')", true);
                    return;
                }
                else
                    hr.HRP_ID = new Guid(DdlPost.SelectedValue);
                if (DdlType.SelectedValue == "")
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请选择员工类型！')", true);
                    return;
                }
                if (DdlType.SelectedItem.Text == "在职员工")
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请选择正确的员工类型！')", true);
                    return;
                }
                else
                    hr.HRET_ID = new Guid(DdlType.SelectedValue);

                hr.HRDD_Registration = DdlRegistration.SelectedValue;
                decimal mm1;
                if (Decimal.TryParse(TxtBasicWage.Text, out mm1))
                    hr.HRDD_BasicWage = mm1;
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的基本工资！')", true);
                    return;
                }
                if (hr.HRDD_BasicWage < 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('基本工资不合法！')", true);
                    return;
                }
                decimal mm2;
                if (Decimal.TryParse(TxtFullTimeWage.Text, out mm2))
                    hr.HRDD_FullTimeWage = mm2;
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的全勤工资！')", true);
                    return;
                }
                if (hr.HRDD_FullTimeWage < 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('全勤工资不合法！')", true);
                    return;
                }
                decimal mm3;
                if (Decimal.TryParse(TxtPerformWage.Text, out mm3))
                    hr.HRDD_PerformWage = mm3;
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的绩效工资！')", true);
                    return;
                }
                if (hr.HRDD_PerformWage < 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('绩效工资不合法！')", true);
                    return;
                }
                decimal mm4;
                if (Decimal.TryParse(TxtOverTimeWage.Text, out mm4))
                    hr.HRDD_OverTimeWage = mm4;
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的加班工资！')", true);
                    return;
                }
                if (hr.HRDD_OverTimeWage < 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('加班工资不合法！')", true);
                    return;
                }

                if (TxtConverseDate.Text == "")
                    hr.HRDD_ConverseDate = Convert.ToDateTime("1/1/1753 12:00:00 AM");
                else
                {
                    DateTime d1;
                    if (DateTime.TryParse(TxtConverseDate.Text, out d1))
                        hr.HRDD_ConverseDate = d1;
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的转正日期！')", true);
                        return;
                    }
                }
                if (TxtContactSDate.Text == "")
                    hr.HRDD_ContactSDate = Convert.ToDateTime("1/1/1753 12:00:00 AM");
                else
                {
                    DateTime d2;
                    if (DateTime.TryParse(TxtContactSDate.Text, out d2))
                        hr.HRDD_ContactSDate = d2;
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的合同签订日期！')", true);
                        return;
                    }
                }
                if (TxtContactEDate.Text == "")
                    hr.HRDD_ContactEDate = Convert.ToDateTime("1/1/1753 12:00:00 AM");
                else
                {
                    DateTime d3;
                    if (DateTime.TryParse(TxtContactEDate.Text, out d3))
                        hr.HRDD_ContactEDate = d3;
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的合同到期日期！')", true);
                        return;
                    }
                }

                if (TxtEntryDate.Text == "")
                    hr.HRDD_EntryDate = Convert.ToDateTime("1/1/1753 12:00:00 AM");
                else
                {
                    DateTime d5;
                    if (DateTime.TryParse(TxtEntryDate.Text, out d5))
                        hr.HRDD_EntryDate = d5;
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的入职日期！')", true);
                        return;
                    }
                }
                //自动计算工龄
                //DateTime q1 = Convert.ToDateTime(TxtEntryDate.Text);
                //DateTime q2 = DateTime.Now;
                //hr.HRDD_Worklength = Convert.ToInt32((q2.Subtract(q1)).Days / 365);
                hr.HRDD_Worklength = Convert.ToInt32(TxtWorklength.Text);

                if (TextBox1.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入离职时间！')", true);
                    return;
                }
                else
                {
                    DateTime d7;
                    if (DateTime.TryParse(TextBox1.Text, out d7))
                        hr.HRDD_QuitTime = d7;
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的离职时间！')", true);
                        return;
                    }
                }

                //hr.HRDD_Sex = DdlSex.SelectedValue;
                if (TxtIDCard.Text.Length != 18 && TxtIDCard.Text != "")
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的身份证号！')", true);
                    return;
                }
                else
                {
                    hr.HRDD_IDCard = TxtIDCard.Text;
                }
                hr.HRDD_IsMarried = DdlIsMarried.SelectedValue;
                hr.HRDD_Nationality = TxtNationality.Text;
                hr.HRDD_EduBackg = DdlEduBackg.SelectedValue;
                hr.HRDD_Major = TxtMajor.Text;
                hr.HRDD_GSchool = TxtGSchool.Text;
                hr.HRDD_HAddress = TxtHAddress.Text;
                hr.HRDD_Tel = TxtTel.Text;
                hr.HRDD_HasSocial = DdlHasSocial.SelectedValue;
                hr.HRDD_HasAccumulation = DdlHasAccumulation.SelectedValue;
                hr.HRDD_CertificateComplete = DdlCertificateComplete.SelectedValue;
                hr.HRDD_EmergencyPer = TxtEmergencyPer.Text;
                hr.HRDD_EmergencyNo = TxtEmergencyNo.Text;
                hr.HRDD_IsDeleted = true;
                hr.HRDD_EState = "离职";
                hr.HRDD_QuitRes = TextBox3.Text;
                hr.HRDD_QuitMan = TextBox2.Text;

                int u = hRDDetailL.Update_HRDDetail_Quit(hr);
                if (u <= 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('重复的工号！')", true);
                    return;
                }
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('编辑失败！" + ex + "')", true);
            }
            ClearDetail();
            Panel_Detail.Visible = false;
            if (LblRecordIsSearch.Text == "检索前")
                BindGrid_Quit("");
            if (LblRecordIsSearch.Text == "检索后")
                BindGrid_Quit(condition);
            UpdatePanel_Grid.Update();
            UpdatePanel_Detail.Update();
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('编辑成功！')", true);
        }
        if (LblState.Text == "Edit_Quit")
        {
            if (TxtStaffNO.Text == "" || TxtName.Text == "" || DdlDep.Text == ""
                   || DdlPost.Text == "" || DdlType.Text == ""
                   || TxtBasicWage.Text == "" || TxtFullTimeWage.Text == "" || TxtPerformWage.Text == ""
                   || TxtOverTimeWage.Text == "" || TxtEntryDate.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            try
            {
                HRDDetailInfo hr = new HRDDetailInfo();
                hr.HRDD_ID = g;
                DataSet ds = hRDDetailL.Search_HRDDetail(" and HRDD_StaffNO='" + TxtStaffNO.Text.ToString() + "' and HRDD_ID!='" + g + "'");
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count != 0)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('已有工号，不能重复！')", true);
                    return;
                }
                hr.HRDD_StaffNO = TxtStaffNO.Text;
                if (TxtName.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('姓名不能为空！')", true);
                    return;
                }
                else
                    hr.HRDD_Name = TxtName.Text;

                if (DdlPost.SelectedValue == "")
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请先选择部门，然后选择岗位！')", true);
                    return;
                }
                else
                    hr.HRP_ID = new Guid(DdlPost.SelectedValue);
                if (DdlType.SelectedValue == "")
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请选择员工类型！')", true);
                    return;
                }
                if (DdlType.SelectedItem.Text == "在职员工")
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请选择正确的员工类型！')", true);
                    return;
                }
                else
                    hr.HRET_ID = new Guid(DdlType.SelectedValue);

                hr.HRDD_Registration = DdlRegistration.SelectedValue;
                decimal mm1;
                if (Decimal.TryParse(TxtBasicWage.Text, out mm1))
                    hr.HRDD_BasicWage = mm1;
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的基本工资！')", true);
                    return;
                }
                if (hr.HRDD_BasicWage < 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('基本工资不合法！')", true);
                    return;
                }
                decimal mm2;
                if (Decimal.TryParse(TxtFullTimeWage.Text, out mm2))
                    hr.HRDD_FullTimeWage = mm2;
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的全勤工资！')", true);
                    return;
                }
                if (hr.HRDD_FullTimeWage < 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('全勤工资不合法！')", true);
                    return;
                }
                decimal mm3;
                if (Decimal.TryParse(TxtPerformWage.Text, out mm3))
                    hr.HRDD_PerformWage = mm3;
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的绩效工资！')", true);
                    return;
                }
                if (hr.HRDD_PerformWage < 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('绩效工资不合法！')", true);
                    return;
                }
                decimal mm4;
                if (Decimal.TryParse(TxtOverTimeWage.Text, out mm4))
                    hr.HRDD_OverTimeWage = mm4;
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的加班工资！')", true);
                    return;
                }
                if (hr.HRDD_OverTimeWage < 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('加班工资不合法！')", true);
                    return;
                }

                if (TxtConverseDate.Text == "")
                    hr.HRDD_ConverseDate = Convert.ToDateTime("1/1/1753 12:00:00 AM");
                else
                {
                    DateTime d1;
                    if (DateTime.TryParse(TxtConverseDate.Text, out d1))
                        hr.HRDD_ConverseDate = d1;
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的转正日期！')", true);
                        return;
                    }
                }
                if (TxtContactSDate.Text == "")
                    hr.HRDD_ContactSDate = Convert.ToDateTime("1/1/1753 12:00:00 AM");
                else
                {
                    DateTime d2;
                    if (DateTime.TryParse(TxtContactSDate.Text, out d2))
                        hr.HRDD_ContactSDate = d2;
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的合同签订日期！')", true);
                        return;
                    }
                }
                if (TxtContactEDate.Text == "")
                    hr.HRDD_ContactEDate = Convert.ToDateTime("1/1/1753 12:00:00 AM");
                else
                {
                    DateTime d3;
                    if (DateTime.TryParse(TxtContactEDate.Text, out d3))
                        hr.HRDD_ContactEDate = d3;
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的合同到期日期！')", true);
                        return;
                    }
                }

                if (TxtEntryDate.Text == "")
                    hr.HRDD_EntryDate = Convert.ToDateTime("1/1/1753 12:00:00 AM");
                else
                {
                    DateTime d5;
                    if (DateTime.TryParse(TxtEntryDate.Text, out d5))
                        hr.HRDD_EntryDate = d5;
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的入职日期！')", true);
                        return;
                    }
                }


                //自动计算工龄
                DateTime q1 = Convert.ToDateTime(TxtEntryDate.Text);
                DateTime q2 = DateTime.Now;
                hr.HRDD_Worklength = Convert.ToInt32((q2.Subtract(q1)).Days / 365);

                if (TextBox1.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入离职时间！')", true);
                    return;
                }
                else
                {
                    DateTime d7;
                    if (DateTime.TryParse(TextBox1.Text, out d7))
                        hr.HRDD_QuitTime = d7;
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的离职时间！')", true);
                        return;
                    }
                }

                //hr.HRDD_Sex = DdlSex.SelectedValue;
                if (TxtIDCard.Text.Length != 18 && TxtIDCard.Text != "")
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的身份证号！')", true);
                    return;
                }
                else
                {
                    hr.HRDD_IDCard = TxtIDCard.Text;
                }
                hr.HRDD_IsMarried = DdlIsMarried.SelectedValue;
                hr.HRDD_Nationality = TxtNationality.Text;
                hr.HRDD_EduBackg = DdlEduBackg.SelectedValue;
                hr.HRDD_Major = TxtMajor.Text;
                hr.HRDD_GSchool = TxtGSchool.Text;
                hr.HRDD_HAddress = TxtHAddress.Text;
                hr.HRDD_Tel = TxtTel.Text;
                hr.HRDD_HasSocial = DdlHasSocial.SelectedValue;
                hr.HRDD_HasAccumulation = DdlHasAccumulation.SelectedValue;
                hr.HRDD_CertificateComplete = DdlCertificateComplete.SelectedValue;
                hr.HRDD_EmergencyPer = TxtEmergencyPer.Text;
                hr.HRDD_EmergencyNo = TxtEmergencyNo.Text;
                hr.HRDD_IsDeleted = true;
                hr.HRDD_EState = "离职";
                hr.HRDD_QuitRes = TextBox3.Text;
                hr.HRDD_QuitMan = TextBox2.Text;

                int u = hRDDetailL.Update_HRDDetail_Quit(hr);
                if (u <= 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('重复的工号！')", true);
                    return;
                }
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('编辑失败！" + ex + "')", true);
            }
            ClearDetail();
            Panel_Detail.Visible = false;
            if (LblRecordIsSearch.Text == "检索前")
                BindGrid("");
            if (LblRecordIsSearch.Text == "检索后")
                BindGrid(condition);
            UpdatePanel_Grid.Update();
            UpdatePanel_Detail.Update();
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('编辑成功！')", true);
        }
        if (LblState.Text == "Edit_Re")
        {
            if (TxtName.Text == "" || DdlDep.Text == ""
                   || DdlPost.Text == "" || DdlType.Text == ""
                   || TxtBasicWage.Text == "" || TxtFullTimeWage.Text == "" || TxtPerformWage.Text == ""
                   || TxtOverTimeWage.Text == "" || TxtEntryDate.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            try
            {
                HRDDetailInfo hr = new HRDDetailInfo();
                hr.HRDD_ID = g;

                if (TxtName.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('姓名不能为空！')", true);
                    return;
                }
                else
                    hr.HRDD_Name = TxtName.Text;

                if (DdlPost.SelectedValue == "")
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请先选择部门，然后选择岗位！')", true);
                    return;
                }
                else
                    hr.HRP_ID = new Guid(DdlPost.SelectedValue);
                if (DdlType.SelectedValue == "")
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请选择员工类型！')", true);
                    return;
                }
                if (DdlType.SelectedItem.Text == "离职员工")
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请选择正确的员工类型！')", true);
                    return;
                }
                else
                    hr.HRET_ID = new Guid(DdlType.SelectedValue);

                hr.HRDD_Registration = DdlRegistration.SelectedValue;
                decimal mm1;
                if (Decimal.TryParse(TxtBasicWage.Text, out mm1))
                    hr.HRDD_BasicWage = mm1;
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的基本工资！')", true);
                    return;
                }
                if (hr.HRDD_BasicWage < 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('基本工资不合法！')", true);
                    return;
                }
                decimal mm2;
                if (Decimal.TryParse(TxtFullTimeWage.Text, out mm2))
                    hr.HRDD_FullTimeWage = mm2;
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的全勤工资！')", true);
                    return;
                }
                if (hr.HRDD_FullTimeWage < 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('全勤工资不合法！')", true);
                    return;
                }
                decimal mm3;
                if (Decimal.TryParse(TxtPerformWage.Text, out mm3))
                    hr.HRDD_PerformWage = mm3;
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的绩效工资！')", true);
                    return;
                }
                if (hr.HRDD_PerformWage < 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('绩效工资不合法！')", true);
                    return;
                }
                decimal mm4;
                if (Decimal.TryParse(TxtOverTimeWage.Text, out mm4))
                    hr.HRDD_OverTimeWage = mm4;
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的加班工资！')", true);
                    return;
                }
                if (hr.HRDD_OverTimeWage < 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('加班工资不合法！')", true);
                    return;
                }

                if (TxtConverseDate.Text == "")
                    hr.HRDD_ConverseDate = Convert.ToDateTime("1/1/1753 12:00:00 AM");
                else
                {
                    DateTime d1;
                    if (DateTime.TryParse(TxtConverseDate.Text, out d1))
                        hr.HRDD_ConverseDate = d1;
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的转正日期！')", true);
                        return;
                    }
                }
                if (TxtContactSDate.Text == "")
                    hr.HRDD_ContactSDate = Convert.ToDateTime("1/1/1753 12:00:00 AM");
                else
                {
                    DateTime d2;
                    if (DateTime.TryParse(TxtContactSDate.Text, out d2))
                        hr.HRDD_ContactSDate = d2;
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的合同签订日期！')", true);
                        return;
                    }
                }
                if (TxtContactEDate.Text == "")
                    hr.HRDD_ContactEDate = Convert.ToDateTime("1/1/1753 12:00:00 AM");
                else
                {
                    DateTime d3;
                    if (DateTime.TryParse(TxtContactEDate.Text, out d3))
                        hr.HRDD_ContactEDate = d3;
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的合同到期日期！')", true);
                        return;
                    }
                }

                if (TxtEntryDate.Text == "")
                    hr.HRDD_EntryDate = Convert.ToDateTime("1/1/1753 12:00:00 AM");
                else
                {
                    DateTime d5;
                    if (DateTime.TryParse(TxtEntryDate.Text, out d5))
                        hr.HRDD_EntryDate = d5;
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的入职日期！')", true);
                        return;
                    }
                }

                //自动计算工龄
                DateTime q1 = Convert.ToDateTime(TxtEntryDate.Text);
                DateTime q2 = DateTime.Now;
                hr.HRDD_Worklength = Convert.ToInt32((q2.Subtract(q1)).Days / 365);

                if (TxtIDCard.Text.Length != 18 && TxtIDCard.Text != "")
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的身份证号！')", true);
                    return;
                }
                else
                {
                    hr.HRDD_IDCard = TxtIDCard.Text;
                }
                hr.HRDD_IsMarried = DdlIsMarried.SelectedValue;
                hr.HRDD_Nationality = TxtNationality.Text;
                hr.HRDD_EduBackg = DdlEduBackg.SelectedValue;
                hr.HRDD_Major = TxtMajor.Text;
                hr.HRDD_GSchool = TxtGSchool.Text;
                hr.HRDD_HAddress = TxtHAddress.Text;
                hr.HRDD_Tel = TxtTel.Text;
                hr.HRDD_HasSocial = DdlHasSocial.SelectedValue;
                hr.HRDD_HasAccumulation = DdlHasAccumulation.SelectedValue;
                hr.HRDD_CertificateComplete = DdlCertificateComplete.SelectedValue;
                hr.HRDD_EmergencyPer = TxtEmergencyPer.Text;
                hr.HRDD_EmergencyNo = TxtEmergencyNo.Text;
                hr.HRDD_IsDeleted = false;
                hr.HRDD_EState = string.Empty;
                hr.HRDD_QuitTime = Convert.ToDateTime("1/1/1753 12:00:00 AM");
                hr.HRDD_QuitRes = string.Empty;
                hr.HRDD_QuitMan = string.Empty;

                int u = hRDDetailL.Insert_HRDDetail(hr);
                if (u <= 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('重复的工号！')", true);
                    return;
                }
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('编辑失败！" + ex + "')", true);
            }
            ClearDetail();
            Panel_Detail.Visible = false;
            if (LblRecordIsSearch.Text == "检索前")
                BindGrid_Quit("");
            if (LblRecordIsSearch.Text == "检索后")
                BindGrid_Quit(condition);
            UpdatePanel_Grid.Update();
            UpdatePanel_Detail.Update();
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('编辑成功！')", true);
        }
    }

    protected void Grid_Detail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_Detail.BottomPagerRow;


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
        {
            if (Request.QueryString["status"].ToString() == "documentMain_Quit" && Session["UserRole"].ToString().Contains("离职员工档案维护"))
            {
                if (Label_sort.Text != "")
                {
                    SortGridView(Label_sort.Text, Labeldereciton.Text);
                }
                else
                    BindGrid_Quit("");

            }
            else
            {
                if (Label_sort.Text != "")
                {
                    SortGridView(Label_sort.Text, Labeldereciton.Text);
                }
                else
                    BindGrid("");
            }
        }
        if (LblRecordIsSearch.Text == "检索后")
        {
            if (Request.QueryString["status"].ToString() == "documentMain_Quit" && Session["UserRole"].ToString().Contains("离职员工档案维护"))
            {
                if (Label_sort.Text != "")
                {
                    SortGridView(Label_sort.Text, Labeldereciton.Text);
                }
                else
                    BindGrid_Quit(condition);
            }
            else
            {
                if (Label_sort.Text != "")
                {
                    SortGridView(Label_sort.Text, Labeldereciton.Text);
                }
                else
                    BindGrid(condition);
            }
        }
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_Detail.PageCount ? Grid_Detail.PageCount - 1 : newPageIndex;
        Grid_Detail.PageIndex = newPageIndex;
        Grid_Detail.DataBind();
    }

    protected void BtnCancelChange_Click(object sender, EventArgs e)
    {
        Panel_Changes.Visible = false;
        if (Panel_Record.Visible == true)
        {
            Panel_Record.Visible = false;
            UpdatePanel_Record.Update();
        }
        ClearChangeControl();
    }
    protected void BtnClose_Click(object sender, EventArgs e)
    {
        Panel_Record.Visible = false;
    }
    protected void DdlDepChangeAfter_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind_DdlPostChangeAfter(DdlDepChangeAfter.SelectedValue.ToString());
    }
    private void ClearChangeControl()
    {
        DdlDepChangeAfter.ClearSelection();
        DdlPostChangeAfter.ClearSelection();
        TxtManager.Text = "";
        TxtTime.Text = "";
        TxtRemarks.Text = "";
    }
    protected void BtnSubmitChange_Click(object sender, EventArgs e)
    {
        if (DdlDepChangeAfter.Text == "" || DdlPostChangeAfter.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        HRDDetailInfo h = new HRDDetailInfo();
        try
        {
            h.HRPCR_ID = Guid.NewGuid();
            h.HRDD_ID = new Guid(LblRecordID.Text);
            h.HRPCR_FormerDep = DdlDepChangeBefore.SelectedItem.ToString();
            h.HRPCR_FormerPost = DdlPostChangeBefore.SelectedItem.ToString();
            if (DdlDepChangeAfter.SelectedValue == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请选择异动部门！')", true);
                return;
            }
            else
                h.HRPCR_Dep = DdlDepChangeAfter.SelectedItem.ToString();
            if (DdlPostChangeAfter.SelectedValue == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请选择异动岗位！')", true);
                return;
            }
            else
                h.HRPCR_Post = DdlPostChangeAfter.SelectedItem.ToString();
            h.HRPCR_Administrator = TxtManager.Text;

            h.HRPCR_Remarks = TxtRemarks.Text;
            h.HRP_ID = new Guid(DdlPostChangeAfter.SelectedValue.ToString());
            if (DdlDepChangeBefore.SelectedItem.ToString() == DdlDepChangeAfter.SelectedItem.ToString() && DdlPostChangeBefore.SelectedItem.ToString() == DdlPostChangeAfter.SelectedItem.ToString())
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('异动前后的部门/岗位相同，请核实！')", true);
                return;
            }
            else
                hRDDetailL.Insert_HRPersonnelChangesRecord(h);
        }
        catch (Exception ex)
        {

            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('提交失败！" + ex + "')", true);
            return;
        }
        Panel_Changes.Visible = false;
        ClearChangeControl();
        UpdatePanel_Changes.Update();
        UpdatePanel_Record.Update();
        TxtSStaffNO.Text = "";
        TxtSName.Text = "";
        DdlSDep.ClearSelection();
        DdlSPost.ClearSelection();
        DdlSType.ClearSelection();
        BindGrid("");
        UpdatePanel_Grid.Update();
        UpdatePanel_Search.Update();
        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('提交成功！')", true);
    }
    protected void BtnSalaryChangeCancel_Click(object sender, EventArgs e)
    {
        Panel_SalaryChange.Visible = false;
        if (Panel_SalaryRecord.Visible == true)
        {
            Panel_SalaryRecord.Visible = false;
            UpdatePanel_SalaryRecord.Update();
        }
        ClearSalaryChangeControl();
    }
    private void ClearSalaryChangeControl()
    {
        TxtNowBasicSalary.Text = "";
        TxtNowFullTimeWage.Text = "";
        TxtNowPerformWage.Text = "";
        TxtNowOverTimeWage.Text = "";
        TxtChargePer.Text = "";
        TxtSalryTime.Text = "";
        TxtReason.Text = "";
    }
    protected void BtnSalaryRecordClose_Click(object sender, EventArgs e)
    {
        Panel_SalaryRecord.Visible = false;
    }

    protected void BtnSalaryChangeSubmit_Click1(object sender, EventArgs e)
    {
        if (TxtNowBasicSalary.Text == "" || TxtNowFullTimeWage.Text == "" || TxtNowPerformWage.Text == "" ||
            TxtNowOverTimeWage.Text == "" || TxtReason.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        HRDDetailInfo hRDDetailInfo = new HRDDetailInfo();
        try
        {
            hRDDetailInfo.HRSR_ID = Guid.NewGuid();
            hRDDetailInfo.HRDD_ID = new Guid(LblRecordID.Text);
            hRDDetailInfo.HRSR_BasicWage = Convert.ToDecimal(TxtFormerBasicSalary.Text);
            hRDDetailInfo.HRSR_PWage = Convert.ToDecimal(TxtFormerPerformWage.Text);
            hRDDetailInfo.HRSR_FTWage = Convert.ToDecimal(TxtFormerFullTimeWage.Text);
            hRDDetailInfo.HRSR_OTWage = Convert.ToDecimal(TxtFormerOverTimeWage.Text);
            decimal m1;
            if (Decimal.TryParse(TxtNowBasicSalary.Text, out m1))
                hRDDetailInfo.HRSR_AdjBasicWage = m1;
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的基本工资！')", true);
                return;
            }
            if (hRDDetailInfo.HRSR_AdjBasicWage < 0)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('基本工资不合法！')", true);
                return;
            }
            decimal m2;
            if (Decimal.TryParse(TxtNowFullTimeWage.Text, out m2))
                hRDDetailInfo.HRSR_AdjFTWage = m2;
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的全勤工资！')", true);
                return;
            }
            if (hRDDetailInfo.HRSR_AdjFTWage < 0)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('全勤工资不合法！')", true);
                return;
            }
            decimal m3;
            if (Decimal.TryParse(TxtNowPerformWage.Text, out m3))
                hRDDetailInfo.HRSR_AdjPWage = m3;
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的绩效工资！')", true);
                return;
            }
            if (hRDDetailInfo.HRSR_AdjPWage < 0)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('绩效工资不合法！')", true);
                return;
            }
            decimal m4;
            if (Decimal.TryParse(TxtNowOverTimeWage.Text, out m4))
                hRDDetailInfo.HRSR_AdjOTWage = m4;
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的加班工资！')", true);
                return;
            }
            if (hRDDetailInfo.HRSR_AdjOTWage < 0)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('加班工资不合法！')", true);
                return;
            }
            hRDDetailInfo.HRSR_ChargePer = TxtChargePer.Text;

            hRDDetailInfo.HRSR_Reason = TxtReason.Text;
            if (decimal.Parse(TxtFormerBasicSalary.Text) == decimal.Parse(TxtNowBasicSalary.Text) && decimal.Parse(TxtFormerFullTimeWage.Text) == decimal.Parse(TxtNowFullTimeWage.Text)
                && decimal.Parse(TxtFormerPerformWage.Text) == decimal.Parse(TxtNowPerformWage.Text) && decimal.Parse(TxtFormerOverTimeWage.Text) == decimal.Parse(TxtNowOverTimeWage.Text))
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('调薪前后的薪资相同，请核实！')", true);
                return;
            }
            else
                hRDDetailL.Insert_HRSalaryRecord(hRDDetailInfo);
        }
        catch (Exception ex)
        {

            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('提交失败！" + ex + "')", true);
            return;
        }
        Panel_SalaryChange.Visible = false;
        ClearSalaryChangeControl();
        UpdatePanel_SalaryRecord.Update();
        UpdatePanel_SalaryChange.Update();
        if (Panel_SalaryRecord.Visible)
        {
            GridView_SalaryRecord.DataSource = hRDDetailL.Search_HRSalaryRecord(new Guid(Label22.Text));
            GridView_SalaryRecord.DataBind();
        }
        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('提交成功！')", true);
    }


    protected void Grid_ChangeRecord_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_ChangeRecord.BottomPagerRow;


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
        Grid_ChangeRecord.DataSource = hRDDetailL.Search_HRPersonnelChangesRecord(new Guid(LblRecordID.Text));
        Grid_ChangeRecord.DataBind();

        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_ChangeRecord.PageCount ? Grid_ChangeRecord.PageCount - 1 : newPageIndex;
        Grid_ChangeRecord.PageIndex = newPageIndex;
        Grid_ChangeRecord.PageIndex = newPageIndex;
        Grid_ChangeRecord.DataBind();
    }
    protected void GridView_SalaryRecord_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView_SalaryRecord.BottomPagerRow;


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
        GridView_SalaryRecord.DataSource = hRDDetailL.Search_HRSalaryRecord(new Guid(LblRecordID.Text));
        GridView_SalaryRecord.DataBind();

        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView_SalaryRecord.PageCount ? GridView_SalaryRecord.PageCount - 1 : newPageIndex;
        GridView_SalaryRecord.PageIndex = newPageIndex;
        GridView_SalaryRecord.DataBind();
    }
    protected void Grid_ChangeRecord_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Grid_ChangeRecord.Rows.Count; i++)
        {
            for (int j = 0; j < Grid_ChangeRecord.Rows[i].Cells.Count; j++)
            {
                Grid_ChangeRecord.Rows[i].Cells[j].ToolTip = Grid_ChangeRecord.Rows[i].Cells[j].Text;
                if (Grid_ChangeRecord.Rows[i].Cells[j].Text.Length > 15)
                {
                    Grid_ChangeRecord.Rows[i].Cells[j].Text = Grid_ChangeRecord.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }


            }
        }
    }
    protected void Grid_Detail_DataBound(object sender, EventArgs e)
    {
        string Role = Request.QueryString["status"].ToString();
        if (Role == "documentMain")
        {
            for (int i = 0; i < Grid_Detail.Rows.Count; i++)
            {
                for (int j = 0; j < Grid_Detail.Rows[i].Cells.Count; j++)
                {
                    //Grid_Detail.Rows[i].Cells[j].ToolTip = Grid_Detail.Rows[i].Cells[j].Text;
                    //if (Grid_Detail.Rows[i].Cells[j].Text.Length > 15)
                    //{
                    //    Grid_Detail.Rows[i].Cells[j].Text = Grid_Detail.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                    //}
                    //合同到期提醒
                    if (j == 7)
                    {
                        DateTime DateTimeNow = DateTime.Now;
                        DateTime DateTimeRow = DateTimeRow = Convert.ToDateTime(Grid_Detail.Rows[i].Cells[j].Text);
                        if (DateDiff(DateTimeNow, DateTimeRow) < 15 || DateTimeRow < DateTimeNow)
                        {
                            Grid_Detail.Rows[i].BackColor = Color.Pink;
                        }
                        if (Grid_Detail.Rows[i].Cells[j].Text == "1753/1/1 0:00:00")
                        {
                            Grid_Detail.Rows[i].Cells[j].Text = "";
                        }
                        //分割时间，只显示日期
                        string[] arr = Grid_Detail.Rows[i].Cells[j].Text.Split(' ');
                        Grid_Detail.Rows[i].Cells[j].Text = arr[0];
                        Grid_Detail.Rows[i].Cells[j].ToolTip = Grid_Detail.Rows[i].Cells[j].Text;
                    }

                }
            }
        }
    }
    protected void GridView_SalaryRecord_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView_SalaryRecord.Rows.Count; i++)
        {
            for (int j = 0; j < GridView_SalaryRecord.Rows[i].Cells.Count; j++)
            {
                GridView_SalaryRecord.Rows[i].Cells[j].ToolTip = GridView_SalaryRecord.Rows[i].Cells[j].Text;
                if (GridView_SalaryRecord.Rows[i].Cells[j].Text.Length > 15)
                {
                    GridView_SalaryRecord.Rows[i].Cells[j].Text = GridView_SalaryRecord.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }


            }
        }
    }
    //检索离职员工
    protected void BtnSearchQuit_Click(object sender, EventArgs e)
    {
        Grid_Detail.SelectedIndex = -1;//如果Grid_Detail存在行加黑，则取消加黑
        condition = TxtSStaffNO.Text.Trim() == "" ? "" : " and HRDD_StaffNO like '%" + TxtSStaffNO.Text.Trim() + "%'";
        condition += TxtSName.Text.Trim() == "" ? "" : " and HRDD_Name like '%" + TxtSName.Text.Trim() + "%'";
        condition += DdlSDep.SelectedValue == "" ? "" : " and HRPost.BDOS_Code ='" + DdlSDep.SelectedValue + "'";
        condition += DdlSPost.SelectedValue == "" ? "" : " and HRDDetail.HRP_ID ='" + DdlSPost.SelectedValue + "'";
        condition += DdlSType.SelectedValue == "" ? "" : " and HRDDetail.HRET_ID ='" + DdlSType.SelectedValue + "'";
        condition += DropDownList1.SelectedValue == "" ? "" : " and HRDDetail.HRDD_Registration ='" + DropDownList1.SelectedValue + "'";

        condition += DropDownList6.SelectedValue == "" ? "" : " and HRDD_EduBackg ='" + DropDownList6.SelectedValue + "'";
        condition += TextBox20.Text.Trim() == "" ? "" : " and HRDD_GSchool like '%" + TextBox20.Text.Trim() + "%'";
        condition += TextBox21.Text.Trim() == "" ? "" : " and HRDD_Major like '%" + TextBox21.Text.Trim() + "%'";
        condition += DropDownList3.SelectedValue == "" ? "" : " and HRDD_Sex ='" + DropDownList3.SelectedValue + "'";
        condition += DropDownList4.SelectedValue == "" ? "" : " and HRDD_HasSocial ='" + DropDownList4.SelectedValue + "'";
        condition += DropDownList5.SelectedValue == "" ? "" : " and HRDD_HasAccumulation ='" + DropDownList5.SelectedValue + "'";

        condition += TextBox13.Text.Trim() == "" ? "" : " and HRDD_ContactEDate >= '" + TextBox13.Text.Trim() + "'";
        condition += TextBox14.Text.Trim() == "" ? "" : " and HRDD_ContactEDate <= '" + TextBox14.Text.Trim() + "'";
        condition += TextBox15.Text.Trim() == "" ? "" : " and HRDD_EntryDate >= '" + TextBox15.Text.Trim() + "'";
        condition += TextBox16.Text.Trim() == "" ? "" : " and HRDD_EntryDate <= '" + TextBox16.Text.Trim() + "'";
        condition += TextBox17.Text.Trim() == "" ? "" : " and HRDD_ConverseDate >= '" + TextBox17.Text.Trim() + "'";
        condition += TextBox19.Text.Trim() == "" ? "" : " and HRDD_ConverseDate <= '" + TextBox19.Text.Trim() + "'";

        try
        {
            BindGrid_Quit(condition);
        }
        catch (Exception ex)
        {

            throw ex;
        }
        LblRecordIsSearch.Text = "检索后";
        UpdatePanel_Grid.Update();
        Panel_Detail.Visible = false;
        UpdatePanel_Detail.Update();
    }
    protected void BtnResetQuit_Click1(object sender, EventArgs e)
    {
        Grid_Detail.SelectedIndex = -1;//如果Grid_Detail存在行加黑，则取消加黑
        TxtSStaffNO.Text = "";
        TxtSName.Text = "";
        DdlSDep.ClearSelection();
        DdlSPost.ClearSelection();
        DdlSType.ClearSelection();
        DropDownList1.SelectedValue = "";
        DropDownList3.SelectedValue = "";
        DropDownList4.SelectedValue = "";
        DropDownList5.SelectedValue = "";
        DropDownList6.SelectedValue = "";
        TextBox20.Text = "";
        TextBox21.Text = "";
        TextBox13.Text = "";
        TextBox14.Text = "";
        TextBox15.Text = "";
        TextBox16.Text = "";
        TextBox17.Text = "";
        TextBox19.Text = "";
        BindGrid_Quit("");
        LblRecordIsSearch.Text = "检索前";
        UpdatePanel_Grid.Update();
        UpdatePanel_Search.Update();
        Panel_Detail.Visible = false;
        UpdatePanel_Detail.Update();
    }

    #region 人事档案列表Grid_Detail排序
    protected void Grid_Detail_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header) //如果是表头
            foreach (TableCell Tc in e.Row.Cells) //对每一单元格      
                if (Tc.HasControls())
                    if (((LinkButton)Tc.Controls[0]).CommandArgument == Label_sort.Text)
                        //if (((LinkButton)Tc.Controls[0]).CommandArgument == Convert.ToString(Session["sort"]))
                        //是否为排序列
                        if (GridViewSortDirection == SortDirection.Ascending) //依排序方向加入方向箭头
                            Tc.Controls.Add(new LiteralControl("↓"));
                        else
                            Tc.Controls.Add(new LiteralControl("↑"));

    }  //Grid 行初始化
    protected void Grid_Detail_Sorting(object sender, GridViewSortEventArgs e)//排序
    {
        string sortExpression = e.SortExpression;
        Label_sort.Text = e.SortExpression;

        if (GridViewSortDirection == SortDirection.Ascending)  //设置排序方向
        {
            GridViewSortDirection = SortDirection.Descending;
            SortGridView(sortExpression, " ASC");
            Labeldereciton.Text = " ASC";
        }
        else
        {
            GridViewSortDirection = SortDirection.Ascending;
            SortGridView(sortExpression, " DESC");
            Labeldereciton.Text = " DESC";

        }

    }
    public SortDirection GridViewSortDirection
    {//属性设置
        get
        {
            if (ViewState["sortDirection"] == null)
            {
                ViewState["sortDirection"] = SortDirection.Ascending;
            }
            return (SortDirection)ViewState["sortDirection"];
        }
        set
        {
            ViewState["sortDirection"] = value;
        }
    }
    private void SortGridView(string sortExpression, string direction)
    {
        if (LblRecordIsSearch.Text == "检索前")
        {
            if (Request.QueryString["status"].ToString() == "documentMain_Quit" && Session["UserRole"].ToString().Contains("离职员工档案维护"))
            {
                DataSet ds = hRDDetailL.Search_HRDDetail_Quit("");
                DataTable dt = ds.Tables[0];
                DataView dv = new DataView(dt);
                dv.Sort = sortExpression + direction;
                Grid_Detail.DataSource = dv;
                Grid_Detail.DataBind();
            }
            else
            {
                DataSet ds = hRDDetailL.Search_HRDDetail("");
                DataTable dt = ds.Tables[0];
                DataView dv = new DataView(dt);
                dv.Sort = sortExpression + direction;
                Grid_Detail.DataSource = dv;
                Grid_Detail.DataBind();
            }
        }
        if (LblRecordIsSearch.Text == "检索后")
        {
            if (Request.QueryString["status"].ToString() == "documentMain_Quit" && Session["UserRole"].ToString().Contains("离职员工档案维护"))
            {
                DataSet ds = hRDDetailL.Search_HRDDetail_Quit(condition);
                DataTable dt = ds.Tables[0];
                DataView dv = new DataView(dt);
                dv.Sort = sortExpression + direction;
                Grid_Detail.DataSource = dv;
                Grid_Detail.DataBind();
            }
            else
            {
                DataSet ds = hRDDetailL.Search_HRDDetail(condition);
                DataTable dt = ds.Tables[0];
                DataView dv = new DataView(dt);
                dv.Sort = sortExpression + direction;
                Grid_Detail.DataSource = dv;
                Grid_Detail.DataBind();
            }
        }
    }
    #endregion 人事档案列表Grid_Detail排序

    #region 奖惩
    protected void BtnRewardNew_Click(object sender, EventArgs e)
    {
        Panel4.Visible = true;
        TextBox6.Text = TextBox4.Text;
        TextBox7.Text = TextBox5.Text;
        editornew.Text = "新增";
        DropDownList2.SelectedValue = "";
        TextBox10.Text = "";
        TextBox8.Text = "";
        TextBox18.Text = "";
        Label99.Text = "新增";
        TextBox9.Text = "";
        TextBox12.Text = "";
        TextBox11.Text = "";
        UpdatePanel4.Update();

        BtnRewardSubmit.Visible = true;
        BtnRewardCancel.Visible = true;
        BtnRewardCancel11.Visible = false;
    }
    protected void BtnRewardnewClose_Click(object sender, EventArgs e)
    {
        Panel4.Visible = false;
        UpdatePanel4.Update();
        Panel_reward.Visible = false;
        UpdatePane_reward.Update();
    }
    protected void BtnRewardnewClose_Click11(object sender, EventArgs e)
    {
        Panel4.Visible = false;
        UpdatePanel4.Update();
        Panel_reward.Visible = false;
        UpdatePane_reward.Update();
    }
    protected void GridView_Reward_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView_Reward.Rows.Count; i++)
        {
            for (int j = 0; j < GridView_Reward.Rows[i].Cells.Count; j++)
            {
                GridView_Reward.Rows[i].Cells[j].ToolTip = GridView_Reward.Rows[i].Cells[j].Text;
                if (GridView_Reward.Rows[i].Cells[j].Text.Length > 15)
                {
                    GridView_Reward.Rows[i].Cells[j].Text = GridView_Reward.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }
            }
        }
    }
    protected void GridView_Reward_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView_Reward.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox44");   // refer to the TextBox with the NewPageIndex value
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
        BindGridView_Reward(" and HRDD_ID='" + Label97.Text + "'");

        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView_Reward.PageCount ? GridView_Reward.PageCount - 1 : newPageIndex;
        GridView_Reward.PageIndex = newPageIndex;
        GridView_Reward.PageIndex = newPageIndex;
        GridView_Reward.DataBind();
    }
    protected void GridView_Reward_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "look_Rewards")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_Reward.SelectedIndex = row.RowIndex;

            TextBox6.Text = TextBox4.Text;
            TextBox7.Text = TextBox5.Text;
            Label99.Text = "查看";

            Panel4.Visible = true;

            BtnRewardSubmit.Visible = false;
            BtnRewardCancel.Visible = false;
            BtnRewardCancel11.Visible = true;

            GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            g = new Guid(e.CommandArgument.ToString());
            try
            {
                DataSet hR = hRDDetailL.Search_HRRewardsPublishment(" and HRRewards_ID='" + g + "'");
                DataRow col = hR.Tables[0].Rows[0];
                DropDownList2.SelectedValue = col[2].ToString();
                TextBox9.Text = col[3].ToString();
                TextBox12.Text = col[4].ToString();
                TextBox10.Text = col[5].ToString();
                TextBox11.Text = col[6].ToString();
                TextBox8.Text = col[7].ToString();
                TextBox18.Text = col[8].ToString();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('数据有误，请联系管理员！" + ex + "')", true);
                return;
            }
            UpdatePanel4.Update();
        }
        if (e.CommandName == "edit_Rewards")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_Reward.SelectedIndex = row.RowIndex;

            TextBox6.Text = TextBox4.Text;
            TextBox7.Text = TextBox5.Text;
            editornew.Text = "编辑";
            Label99.Text = "编辑";
            Panel4.Visible = true;
            BtnRewardSubmit.Visible = true;
            BtnRewardCancel.Visible = true;
            BtnRewardCancel11.Visible = false;

            GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            g = new Guid(e.CommandArgument.ToString());
            Label98.Text = e.CommandArgument.ToString();
            try
            {
                DataSet hR = hRDDetailL.Search_HRRewardsPublishment(" and HRRewards_ID='" + g + "'");
                DataRow col = hR.Tables[0].Rows[0];
                DropDownList2.SelectedValue = col[2].ToString();
                TextBox9.Text = col[3].ToString();
                TextBox12.Text = col[4].ToString();
                TextBox10.Text = col[5].ToString();
                TextBox11.Text = col[6].ToString();
                TextBox8.Text = col[7].ToString();
                TextBox18.Text = col[8].ToString();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('数据有误，请联系管理员！" + ex + "')", true);
                return;
            }
            UpdatePanel4.Update();
        }
        if (e.CommandName == "Delete_Rewards")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_Reward.SelectedIndex = -1;

            Guid guid = new Guid(e.CommandArgument.ToString());
            hRDDetailL.Delete_HRRewardsPublishment(guid);
            BindGridView_Reward(" and HRDD_ID='" + Label97.Text + "'");
        }
    }
    protected void BtnRewardSubmit_Click(object sender, EventArgs e)
    {
        if (editornew.Text == "新增")
        {
            if (DropDownList2.SelectedValue == "" || TextBox10.Text == "" || TextBox8.Text == "" || TextBox9.Text == "" || TextBox12.Text == "" || TextBox11.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            HRDDetailInfo hRDDetailInfo = new HRDDetailInfo();
            try
            {
                hRDDetailInfo.HRDD_ID = new Guid(Label97.Text.ToString());
                hRDDetailInfo.HRRewards_Type = DropDownList2.SelectedValue;
                hRDDetailInfo.HRRewards_Time = Convert.ToDateTime(TextBox10.Text.ToString());
                hRDDetailInfo.HRRewards_Content = TextBox8.Text;
                hRDDetailInfo.HRRewards_Note = TextBox18.Text;
                decimal mk;
                if (Decimal.TryParse(TextBox9.Text, out mk))
                    hRDDetailInfo.HRRewards_Money = mk;
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的奖惩金额！')", true);
                    return;
                }
                hRDDetailInfo.HRRewards_Agree = TextBox12.Text;
                hRDDetailInfo.HRRewards_OkTime = Convert.ToDateTime(TextBox11.Text.ToString());
                if (DropDownList2.SelectedValue == "奖励" && Convert.ToDecimal(TextBox9.Text) < 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('奖励金额不能为负数！')", true);
                    return;
                }
                if (DropDownList2.SelectedValue == "处罚" && Convert.ToDecimal(TextBox9.Text) > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('处罚金额不能为正数！')", true);
                    return;
                }
                hRDDetailL.Insert_HRRewardsPublishment(hRDDetailInfo);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('提交失败！" + ex + "')", true);
                return;
            }
            Panel4.Visible = false;
            UpdatePanel4.Update();
            BindGridView_Reward(" and HRDD_ID='" + Label97.Text + "'");
            UpdatePane_reward.Update();
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('提交成功！')", true);
        }
        if (editornew.Text == "编辑")
        {
            if (DropDownList2.SelectedValue == "" || TextBox10.Text == "" || TextBox8.Text == "" || TextBox9.Text == "" || TextBox12.Text == "" || TextBox11.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            HRDDetailInfo hRDDetailInfo = new HRDDetailInfo();
            try
            {
                hRDDetailInfo.HRRewards_ID = new Guid(Label98.Text.ToString());
                hRDDetailInfo.HRRewards_Type = DropDownList2.SelectedValue;
                hRDDetailInfo.HRRewards_Time = Convert.ToDateTime(TextBox10.Text.ToString());
                hRDDetailInfo.HRRewards_Content = TextBox8.Text;
                hRDDetailInfo.HRRewards_Note = TextBox18.Text;
                decimal mk;
                if (Decimal.TryParse(TextBox9.Text, out mk))
                    hRDDetailInfo.HRRewards_Money = mk;
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的奖惩金额！')", true);
                    return;
                }
                hRDDetailInfo.HRRewards_Agree = TextBox12.Text;
                hRDDetailInfo.HRRewards_OkTime = Convert.ToDateTime(TextBox11.Text.ToString());
                if (DropDownList2.SelectedValue == "奖励" && Convert.ToDecimal(TextBox9.Text) < 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('奖励金额不能为负数！')", true);
                    return;
                }
                if (DropDownList2.SelectedValue == "处罚" && Convert.ToDecimal(TextBox9.Text) > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('处罚金额不能为正数！')", true);
                    return;
                }
                hRDDetailL.Update_HRRewardsPublishment(hRDDetailInfo);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('提交失败！" + ex + "')", true);
                return;
            }
            Panel4.Visible = false;
            UpdatePanel4.Update();
            BindGridView_Reward(" and HRDD_ID='" + Label97.Text + "'");
            UpdatePane_reward.Update();
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('提交成功！')", true);
        }
    }
    protected void BtnRewardCancel_Click(object sender, EventArgs e)
    {
        Panel4.Visible = false;
        UpdatePanel4.Update();
    }
    protected void BtnRewardCancel_Click11(object sender, EventArgs e)
    {
        Panel4.Visible = false;
        UpdatePanel4.Update();
    }

    #endregion 奖惩

    #region 一键更新
    protected void BtnWorklength_Click(object sender, EventArgs e)
    {
        try
        {
            int i = hRDDetailL.Update_HRDDetail_Worklength();
            if (i > 0)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('还有未填写“入职日期”的员工！')", true);
                return;
            }
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('更新成功！')", true);
            BindGrid("");
            UpdatePanel_Grid.Update();
        }
        catch (Exception exc)
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('更新失败！" + exc + "')", true);
        }
    }
    #endregion 一键更新

    #region 奖惩高级检索
    protected void Senior_DetailOPEN_Click(object sender, EventArgs e)
    {
        Panel6.Visible = true;
        Senior_DetailOPEN.Visible = false;
        Senior_DetailCLOSE.Visible = true;
        Label_OpenOrClose.Text = "高级检索";
        BtnSearch.Text = "高级检索";
        Panel7.Visible = true;
        UpdatePanel7.Update();
        Panel_Grid.Visible = false;
        UpdatePanel_Grid.Update();
        GridView7.DataSource = hRDDetailL.Search_HRDDetail_Type_Post_Senior("");
        GridView7.DataBind();
        UpdatePanel_Search.Update();
        Panel4.Visible = false;
        UpdatePanel4.Update();
        Panel_reward.Visible = false;
        UpdatePane_reward.Update();
    }
    protected void Senior_DetailCLOSE_Click(object sender, EventArgs e)
    {
        Panel6.Visible = false;
        Senior_DetailOPEN.Visible = true;
        Senior_DetailCLOSE.Visible = false;
        Label_OpenOrClose.Text = "检索";
        BtnSearch.Text = "检索";
        Panel7.Visible = false;
        UpdatePanel7.Update();
        Panel_Grid.Visible = true;
        UpdatePanel_Grid.Update();
        BindGrid("");
        UpdatePanel_Search.Update();
        Panel4.Visible = false;
        UpdatePanel4.Update();
        Panel_reward.Visible = false;
        UpdatePane_reward.Update();
    }
    #endregion 奖惩高级检索

    #region 高级检索gridview7
    protected void GridView7_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView7.Rows.Count; i++)
        {
            for (int j = 0; j < GridView7.Rows[i].Cells.Count; j++)
            {
                GridView7.Rows[i].Cells[j].ToolTip = GridView7.Rows[i].Cells[j].Text;
                if (GridView7.Rows[i].Cells[j].Text.Length > 10)
                {
                    GridView7.Rows[i].Cells[j].Text = GridView7.Rows[i].Cells[j].Text.Substring(0, 10) + "...";
                }
            }
        }
    }
    protected void GridView7_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView7.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox34");   // refer to the TextBox with the NewPageIndex value
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
        if (LblRecordIsSearch.Text == "高级检索后")
        {
            GridView7.DataSource = hRDDetailL.Search_HRDDetail_Type_Post_Senior(condition);
            GridView7.DataBind();
        }
        else
        {
            GridView7.DataSource = hRDDetailL.Search_HRDDetail_Type_Post_Senior("");
            GridView7.DataBind();
        }

        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView7.PageCount ? GridView7.PageCount - 1 : newPageIndex;
        GridView7.PageIndex = newPageIndex;
        GridView7.PageIndex = newPageIndex;
        GridView7.DataBind();
    }
    protected void GridView7_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    #endregion 高级检索gridview7



    protected void BtnPrint_Click(object sender, EventArgs e)
    {
        Response.Redirect("../REPORT_cc/RewardPrint.aspx?" + "&HRDD_StaffNO=" + TxtSStaffNO.Text.ToString() + "&HRDD_Name=" + TxtSName.Text
            + "&HRET_EmpType=" + DdlSType.SelectedValue + "&BDOS_Name=" + DdlSDep.SelectedValue + "&HRP_Post=" + DdlSPost.SelectedValue
            + "&HRRewards_Type=" + DropDownList7.SelectedValue + "&HRRewards_Time1=" + TextBox26.Text.ToString() + "&HRRewards_Time2=" + TextBox22.Text.ToString()
            + "&HRRewards_Money=" + TextBox24.Text.ToString() + "&HRRewards_OkTime1=" + TextBox27.Text.ToString() + "&HRRewards_OkTime2=" + TextBox23.Text.ToString()
            + "&HRRewards_Agree=" + TextBox25.Text.ToString() + "&HRRewards_Content=" + TextBox28.Text.ToString());
    }
}