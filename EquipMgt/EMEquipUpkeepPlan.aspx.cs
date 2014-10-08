using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using RTXHelper;

public partial class EquipMgt_EMEquipUpkeepPlan : Page
{
    EquipUpkeepPlanL equipUpkeepPlanL = new EquipUpkeepPlanL();
    EquipUpkeepItemL equipUpkeepItemL = new EquipUpkeepItemL();
    EquipNameModelL equipNameModelL = new EquipNameModelL();
    EquipTypeL equipTypeL = new EquipTypeL();

    #region 页面权限控制
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { 
            Panel_Search.Visible = true;
            UpdatePanel_Search.Update();

            try
            {
                if (Request.QueryString["status"].ToString() != "")
                {
                    Lab_Status.Text = Request.QueryString["status"].ToString();
                }
                if (Lab_Status.Text == "EMMake" && Session["UserRole"].ToString().Contains("设备保养计划制定"))
                {
                    Title = "设备保养计划制定";
                    Grid_EquipUpkeepPlan.Columns[10].Visible = true;//计划制定人
                    Grid_EquipUpkeepPlan.Columns[11].Visible = true;//计划制定时间
                    Grid_EquipUpkeepPlan.Columns[12].Visible = true;//保养计划状态
                    Grid_EquipUpkeepPlan.Columns[13].Visible = false;//计划生成人
                    Grid_EquipUpkeepPlan.Columns[14].Visible = false;//计划生成时间
                    Grid_EquipUpkeepPlan.Columns[15].Visible = false;//实际保养人
                    Grid_EquipUpkeepPlan.Columns[17].Visible = false;//保养开始时间
                    Grid_EquipUpkeepPlan.Columns[18].Visible = false;//保养结束时间
                    Grid_EquipUpkeepPlan.Columns[20].Visible = false;//查看详情
                    Grid_EquipUpkeepPlan.Columns[21].Visible = true;//选择保养项目
                    Grid_EquipUpkeepPlan.Columns[22].Visible = false;//生成保养计划
                    Grid_EquipUpkeepPlan.Columns[23].Visible = false;//记录保养情况
                    Grid_EquipUpkeepPlan.Columns[24].Visible = true;//删除
                    Grid_EquipUpkeepPlan.Columns[25].Visible = false;//保养开始确认
                    Btn_New.Visible = true;
                    //this.DropDownList1.Items.FindByValue("已提交").Enabled = false;
                    //this.DropDownList1.Items.FindByValue("已生成").Enabled = false;
                    //this.DropDownList1.Items.FindByValue("已完成").Enabled = false;
                    //this.DropDownList1.Items.FindByValue("保养开始").Enabled = false;
                    //this.searchGeneratePer.Enabled = false;
                    //this.searchGenerateTime.Enabled = false;
                    //this.searchActPer.Enabled = false;
                    //this.searchUStartT.Enabled = false;
                    //this.searchUEndT.Enabled = false;
                    Panel9.Visible = false;
                    Panel10.Visible = false;
                    //string condition = "and d.EUP_State='待提交'";
                    string condition = "";
                    BindGrid_EquipUpkeepPlan(condition);
                }
                if (Lab_Status.Text == "EMGen" && Session["UserRole"].ToString().Contains("设备保养计划生成"))
                {
                    Title = "设备保养计划生成";
                    Grid_EquipUpkeepPlan.Columns[10].Visible = true;//计划制定人
                    Grid_EquipUpkeepPlan.Columns[11].Visible = true;//计划制定时间
                    Grid_EquipUpkeepPlan.Columns[12].Visible = true;//保养计划状态
                    Grid_EquipUpkeepPlan.Columns[13].Visible = false;//计划生成人
                    Grid_EquipUpkeepPlan.Columns[14].Visible = false;//计划生成时间
                    Grid_EquipUpkeepPlan.Columns[15].Visible = false;//实际保养人
                    Grid_EquipUpkeepPlan.Columns[17].Visible = false;//保养开始时间
                    Grid_EquipUpkeepPlan.Columns[18].Visible = false;//保养结束时间
                    Grid_EquipUpkeepPlan.Columns[20].Visible = false;//查看详情
                    Grid_EquipUpkeepPlan.Columns[21].Visible = false;//选择保养项目
                    Grid_EquipUpkeepPlan.Columns[22].Visible = true;//生成保养计划
                    Grid_EquipUpkeepPlan.Columns[23].Visible = false;//记录保养情况
                    Grid_EquipUpkeepPlan.Columns[24].Visible = false;//删除
                    Grid_EquipUpkeepPlan.Columns[25].Visible = false;//保养开始确认
                    Btn_New.Visible = false;
                    DropDownList1.Items.FindByValue("待提交").Enabled = false;
                    //this.DropDownList1.Items.FindByValue("已生成").Enabled = false;
                    //this.DropDownList1.Items.FindByValue("已完成").Enabled = false;
                    //this.DropDownList1.Items.FindByValue("保养开始").Enabled = false;
                    //this.searchGeneratePer.Enabled = false;
                    //this.searchGenerateTime.Enabled = false;
                    //this.searchActPer.Enabled = false;
                    //this.searchUStartT.Enabled = false;
                    //this.searchUEndT.Enabled = false;
                    Panel9.Visible = false;
                    Panel10.Visible = false;
                    string condition = "and d.EUP_State='已提交'";
                    BindGrid_EquipUpkeepPlan(condition);
                    Panel12.Visible = true;
                    UpdatePanel12.Update();
                }
                if (Lab_Status.Text == "EMDealP" && Session["UserRole"].ToString().Contains("设备保养情况记录"))
                {
                    Title = "设备保养情况记录";
                    Grid_EquipUpkeepPlan.Columns[10].Visible = true;//计划制定人
                    Grid_EquipUpkeepPlan.Columns[11].Visible = true;//计划制定时间
                    Grid_EquipUpkeepPlan.Columns[12].Visible = true;//保养计划状态
                    Grid_EquipUpkeepPlan.Columns[13].Visible = true;//计划生成人
                    Grid_EquipUpkeepPlan.Columns[14].Visible = true;//计划生成时间
                    Grid_EquipUpkeepPlan.Columns[15].Visible = false;//实际保养人
                    Grid_EquipUpkeepPlan.Columns[17].Visible = false;//保养开始时间
                    Grid_EquipUpkeepPlan.Columns[18].Visible = false;//保养结束时间
                    Grid_EquipUpkeepPlan.Columns[20].Visible = false;//查看详情
                    Grid_EquipUpkeepPlan.Columns[21].Visible = false;//选择保养项目
                    Grid_EquipUpkeepPlan.Columns[22].Visible = false;//生成保养计划
                    Grid_EquipUpkeepPlan.Columns[23].Visible = true;//记录保养情况
                    Grid_EquipUpkeepPlan.Columns[24].Visible = false;//删除
                    Grid_EquipUpkeepPlan.Columns[25].Visible = false;//保养开始确认
                    Btn_New.Visible = false;
                    DropDownList1.Items.FindByValue("待提交").Enabled = false;
                    DropDownList1.Items.FindByValue("已提交").Enabled = false;
                    DropDownList1.Items.FindByValue("已生成").Enabled = false;
                    DropDownList1.Items.FindByValue("已完成").Enabled = false;
                    //this.searchGeneratePer.Enabled = true;
                    //this.searchGenerateTime.Enabled = true;
                    //this.searchActPer.Enabled = false;
                    //this.searchUStartT.Enabled = false;
                    //this.searchUEndT.Enabled = false;
                    Panel9.Visible = true;
                    Label31.Visible = false;
                    searchActPer.Visible = false;
                    Panel10.Visible = false;
                    string condition = "and d.EUP_State='保养开始'";
                    BindGrid_EquipUpkeepPlan(condition);
                }
                if (Lab_Status.Text == "EMLookP" && Session["UserRole"].ToString().Contains("设备保养计划查看"))
                {
                    Title = "设备保养计划查看";
                    Grid_EquipUpkeepPlan.Columns[10].Visible = false;//计划制定人
                    Grid_EquipUpkeepPlan.Columns[11].Visible = false;//计划制定时间
                    Grid_EquipUpkeepPlan.Columns[12].Visible = true;//保养计划状态
                    Grid_EquipUpkeepPlan.Columns[13].Visible = false;//计划生成人
                    Grid_EquipUpkeepPlan.Columns[14].Visible = false;//计划生成时间
                    Grid_EquipUpkeepPlan.Columns[15].Visible = false;//实际保养人
                    Grid_EquipUpkeepPlan.Columns[17].Visible = false;//保养开始时间
                    Grid_EquipUpkeepPlan.Columns[18].Visible = false;//保养结束时间
                    Grid_EquipUpkeepPlan.Columns[20].Visible = false;//查看详情
                    Grid_EquipUpkeepPlan.Columns[21].Visible = false;//选择保养项目
                    Grid_EquipUpkeepPlan.Columns[22].Visible = false;//生成保养计划
                    Grid_EquipUpkeepPlan.Columns[23].Visible = false;//记录保养情况
                    Grid_EquipUpkeepPlan.Columns[24].Visible = false;//删除
                    Grid_EquipUpkeepPlan.Columns[25].Visible = false;//保养开始确认
                    Btn_New.Visible = false;
                    DropDownList1.Items.FindByValue("待提交").Enabled = false;
                    //this.searchGeneratePer.Enabled = true;
                    //this.searchGenerateTime.Enabled = true;
                    //this.searchActPer.Enabled = true;
                    //this.searchUStartT.Enabled = true;
                    //this.searchUEndT.Enabled = true;
                    string condition = "and d.EUP_State!='待提交'";
                    BindGrid_EquipUpkeepPlan(condition);
                }
                if (Lab_Status.Text == "EMHis" && Session["UserRole"].ToString().Contains("设备保养历史记录查看"))
                {
                    Title = "设备保养历史记录查看";
                    Grid_EquipUpkeepPlan.Columns[10].Visible = true;//计划制定人
                    Grid_EquipUpkeepPlan.Columns[11].Visible = true;//计划制定时间
                    Grid_EquipUpkeepPlan.Columns[12].Visible = true;//保养计划状态
                    Grid_EquipUpkeepPlan.Columns[13].Visible = true;//计划生成人
                    Grid_EquipUpkeepPlan.Columns[14].Visible = true;//计划生成时间
                    Grid_EquipUpkeepPlan.Columns[15].Visible = true;//实际保养人
                    Grid_EquipUpkeepPlan.Columns[17].Visible = true;//保养开始时间
                    Grid_EquipUpkeepPlan.Columns[18].Visible = true;//保养结束时间
                    Grid_EquipUpkeepPlan.Columns[20].Visible = true;//查看详情
                    Grid_EquipUpkeepPlan.Columns[21].Visible = false;//选择保养项目
                    Grid_EquipUpkeepPlan.Columns[22].Visible = false;//生成保养计划
                    Grid_EquipUpkeepPlan.Columns[23].Visible = false;//记录保养情况
                    Grid_EquipUpkeepPlan.Columns[24].Visible = false;//删除
                    Grid_EquipUpkeepPlan.Columns[25].Visible = false;//保养开始确认
                    Btn_New.Visible = false;
                    DropDownList1.Items.FindByValue("待提交").Enabled = false;
                    //this.searchGeneratePer.Enabled = true;
                    //this.searchGenerateTime.Enabled = true;
                    //this.searchActPer.Enabled = true;
                    //this.searchUStartT.Enabled = true;
                    //this.searchUEndT.Enabled = true;
                    string condition = "and d.EUP_State!='待提交'";
                    BindGrid_EquipUpkeepPlan(condition);
                }
                if (Lab_Status.Text == "EMStar" && Session["UserRole"].ToString().Contains("设备保养开始确认"))
                {
                    Title = "设备保养开始确认";
                    Grid_EquipUpkeepPlan.Columns[10].Visible = true;//计划制定人
                    Grid_EquipUpkeepPlan.Columns[11].Visible = true;//计划制定时间
                    Grid_EquipUpkeepPlan.Columns[12].Visible = true;//保养计划状态
                    Grid_EquipUpkeepPlan.Columns[13].Visible = true;//计划生成人
                    Grid_EquipUpkeepPlan.Columns[14].Visible = true;//计划生成时间
                    Grid_EquipUpkeepPlan.Columns[15].Visible = false;//实际保养人
                    Grid_EquipUpkeepPlan.Columns[17].Visible = false;//保养开始时间
                    Grid_EquipUpkeepPlan.Columns[18].Visible = false;//保养结束时间
                    Grid_EquipUpkeepPlan.Columns[20].Visible = false;//查看详情
                    Grid_EquipUpkeepPlan.Columns[21].Visible = false;//选择保养项目
                    Grid_EquipUpkeepPlan.Columns[22].Visible = false;//生成保养计划
                    Grid_EquipUpkeepPlan.Columns[23].Visible = false;//记录保养情况
                    Grid_EquipUpkeepPlan.Columns[24].Visible = false;//删除
                    Grid_EquipUpkeepPlan.Columns[25].Visible = true;//保养开始确认
                    Btn_New.Visible = false;
                    DropDownList1.Items.FindByValue("待提交").Enabled = false;
                    DropDownList1.Items.FindByValue("已提交").Enabled = false;
                    DropDownList1.Items.FindByValue("已完成").Enabled = false;
                    DropDownList1.Items.FindByValue("保养开始").Enabled = false;
                    //this.searchGeneratePer.Enabled = true;
                    //this.searchGenerateTime.Enabled = true;
                    //this.searchActPer.Enabled = false;
                    //this.searchUStartT.Enabled = false;
                    //this.searchUEndT.Enabled = false;
                    Panel9.Visible = true;
                    Label31.Visible = false;
                    searchActPer.Visible = false;
                    Panel10.Visible = false;
                    string condition = "and d.EUP_State='已生成'";
                    BindGrid_EquipUpkeepPlan(condition);
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('可能您没有权限操作和查看本页面，请退出选择其他账号登陆，或联系管理员！')", true);
                Response.Redirect("~/Default.aspx");

            }
        }
    }
    #endregion 页面权限控制

    #region 绑定
    //绑定设备保养计划列表gridview
    private void BindGrid_EquipUpkeepPlan(string condition)
    {
        Grid_EquipUpkeepPlan.DataSource = equipUpkeepPlanL.Search_EquipUpkeepPlan(condition);
        Grid_EquipUpkeepPlan.DataBind();
    }
    private void BindDropDownList5()
    {
        DropDownList5.DataSource = equipTypeL.Search_EquipTypeTableInfo("");
        DropDownList5.DataTextField = "ETT_Type";
        DropDownList5.DataValueField = "ETT_Type";
        DropDownList5.DataBind();
        DropDownList5.Items.Insert(0, new ListItem("请选择", ""));
    }
    #endregion 绑定

    #region 检索设备保养计划
    //检索设备台账
    protected void Btn_Search_Click(object sender, EventArgs e)
    {
        Panel_searchInf.Visible = false;
        Panel_New.Visible = false;
        UpdatePanel_New.Update();
        Panel_last.Visible = false;
        UpdatePanel_last.Update();
        Panel_newitem.Visible = false;
        UpdatePanel_newitem.Update();
        Panel_Look.Visible = false;
        UpdatePanel_Look.Update();
        Panel_NewSpare.Visible = false;
        UpdatePanel_NewSpare.Update();

        string condition = GetCondition();
        BindGrid_EquipUpkeepPlan(condition);
        UpdatePanel_EquipUpkeepPlan.Visible = true;
        UpdatePanel_EquipUpkeepPlan.Update();
        UpdatePanel_Search.Update();
    }
    protected string GetCondition()
    {
        string condition;
        string temp = "";
        if (searchname.Text.ToString() != "")
        {
            temp += " and EN_EquipName like '%" + searchname.Text.ToString() + "%'";
        }
        if (searchno.Text.ToString() != "")
        {
            temp += " and  EI_No like '%" + searchno.Text.ToString() + "%'";
        }
        if (searchUpkeepPer.Text.ToString() != "")
        {
            temp += " and  EUP_UpkeepPer like '%" + searchUpkeepPer.Text.ToString() + "%'";
        }
        if (searchExpectTime.Text.ToString() != "")
        {
            temp += " and  EUP_ExpectTime = '" + searchExpectTime.Text.ToString() + "'";
        }
        if (DropDownList2.Text.ToString() != "")
        {
            temp += " and  EUP_Class = '" + DropDownList2.SelectedValue.ToString() + "'";
        }
        if (searchPDate.Text.ToString() != "")
        {
            temp += " and  EUP_PDate = '" + searchPDate.Text.ToString() + "'";
        }
        if (searchPPerson.Text.ToString() != "")
        {
            temp += " and EUP_PPerson like '%" + searchPPerson.Text.ToString() + "%'";
        }
        if (searchMakingTime.Text.ToString() != "")
        {
            //temp += " and  EUP_MakingTime= '" + this.searchMakingTime.Text.ToString() + "'";
            //temp += " and  EUP_MakingTime>= '" + this.searchMakingTime.Text.ToString() + "'";
            temp += "and DateDiff(dd,getdate(),EUP_MakingTime)=DateDiff(dd,getdate(),'" + searchMakingTime.Text.ToString() + "')";
        }
        if (DropDownList1.Text.ToString() != "")
        {
            temp += " and EUP_State='" + DropDownList1.SelectedValue.ToString() + "'";
        }
        if (searchGeneratePer.Text.ToString() != "")
        {
            temp += " and  EUP_GeneratePer like '%" + searchGeneratePer.Text.ToString() + "%'";
        }
        if (searchGenerateTime.Text.ToString() != "")
        {
            //temp += " and  EUP_GenerateTime = '" + this.searchGenerateTime.Text.ToString() + "'";
            temp += "and DateDiff(dd,getdate(),EUP_GenerateTime)=DateDiff(dd,getdate(),'" + searchGenerateTime.Text.ToString() + "')";
        }
        if (searchActPer.Text.ToString() != "")
        {
            temp += " and  EUP_ActPer like '%" + searchActPer.Text.ToString() + "%'";
        }
        if (searchUStartT.Text.ToString() != "")
        {
            //temp += " and  EUP_UStartT = '" + this.searchUStartT.Text.ToString() + "'";
            temp += "and DateDiff(dd,getdate(),EUP_UStartT)=DateDiff(dd,getdate(),'" + searchUStartT.Text.ToString() + "')";
        }
        if (searchUEndT.Text.ToString() != "")
        {
            //temp += " and  EUP_UEndT = '" + this.searchUEndT.Text.ToString() + "'";
            temp += "and DateDiff(dd,getdate(),EUP_UEndT)=DateDiff(dd,getdate(),'" + searchUEndT.Text.ToString() + "')";
        }
        if (Lab_Status.Text == "EMMake" && Session["UserRole"].ToString().Contains("设备保养计划制定"))
        {
            //temp += " and d.EUP_State='待提交'";
            temp += "";
        }
        if (Lab_Status.Text == "EMGen" && Session["UserRole"].ToString().Contains("设备保养计划生成"))
        {
            temp += "and d.EUP_State!='待提交'";
        }
        if (Lab_Status.Text == "EMStar" && Session["UserRole"].ToString().Contains("设备保养开始确认"))
        {
            temp += " and d.EUP_State ='已生成'";
        }
        if (Lab_Status.Text == "EMDealP" && Session["UserRole"].ToString().Contains("设备保养情况记录"))
        {
            temp += " and d.EUP_State ='保养开始'";
        }
        if (Lab_Status.Text == "EMLookP" && Session["UserRole"].ToString().Contains("设备保养计划查看"))
        {
            temp += " and d.EUP_State !='待提交'";
        }
        if (Lab_Status.Text == "EMHis" && Session["UserRole"].ToString().Contains("设备保养历史记录查看"))
        {
            temp += "and d.EUP_State !='待提交'";
        }
        condition = temp;
        return condition;
    }
    protected void Btn_Clear_Click(object sender, EventArgs e)
    {
        searchname.Text = "";
        searchno.Text = "";
        searchUpkeepPer.Text = "";
        searchExpectTime.Text = "";
        DropDownList2.SelectedIndex = 0;
        searchPDate.Text = "";
        searchPPerson.Text = "";
        searchMakingTime.Text = "";
        DropDownList1.SelectedIndex = 0;
        searchGeneratePer.Text = "";
        searchGenerateTime.Text = "";
        searchActPer.Text = "";
        searchUStartT.Text = "";
        searchUEndT.Text = "";

        Panel_searchInf.Visible = false;
        Panel_New.Visible = false;
        UpdatePanel_New.Update();
        Panel_last.Visible = false;
        UpdatePanel_last.Update();
        Panel_newitem.Visible = false;
        UpdatePanel_newitem.Update();
        Panel_Look.Visible = false;
        UpdatePanel_Look.Update();
        Panel_NewSpare.Visible = false;
        UpdatePanel_NewSpare.Update();

        string condition = GetCondition2();
        BindGrid_EquipUpkeepPlan(condition);
        UpdatePanel_EquipUpkeepPlan.Update();
    }
    protected string GetCondition2()
    {
        string condition;
        string temp = "";
        if (Lab_Status.Text == "EMMake" && Session["UserRole"].ToString().Contains("设备保养计划制定"))
        {
            //temp += " and d.EUP_State='待提交'";
            temp += "";
        }
        if (Lab_Status.Text == "EMGen" && Session["UserRole"].ToString().Contains("设备保养计划生成"))
        {
            temp += "and d.EUP_State!='待提交'";
        }
        if (Lab_Status.Text == "EMStar" && Session["UserRole"].ToString().Contains("设备保养开始确认"))
        {
            temp += " and d.EUP_State ='已生成'";
        }
        if (Lab_Status.Text == "EMDealP" && Session["UserRole"].ToString().Contains("设备保养情况记录"))
        {
            temp += " and d.EUP_State ='保养开始'";
        }
        if (Lab_Status.Text == "EMLookP" && Session["UserRole"].ToString().Contains("设备保养计划查看"))
        {
            temp += " and d.EUP_State !='待提交'";
        }
        if (Lab_Status.Text == "EMHis" && Session["UserRole"].ToString().Contains("设备保养历史记录查看"))
        {
            temp += "and d.EUP_State !='待提交'";
        }
        condition = temp;
        return condition;
    }
    protected void Btn_New_Click(object sender, EventArgs e)
    {
        Clear();
        Panel_searchInf.Visible = true;
        Panel_New.Visible = false;
        UpdatePanel_New.Update();
        Panel_last.Visible = false;
        UpdatePanel_last.Update();
        Panel_newitem.Visible = false;
        UpdatePanel_newitem.Update();
        DropDownList5.Items.Insert(0, new ListItem("请选择", ""));
        BindDropDownList5();
        string ETT_Type = "";
        string EN_EquipName = "";
        string EMT_Type = "";
        string EI_No = "";
        Grid_EquipInfo.DataSource = equipUpkeepPlanL.Search_InsertEquipUpkeepPlan_Inf(ETT_Type, EN_EquipName, EMT_Type, EI_No);
        Grid_EquipInfo.DataBind();
    }
    //私有清空的方法
    private void Clear()
    {
        DropDownList5.Items.Insert(0, new ListItem("请选择", ""));
        BindDropDownList5();
        infoname.Text = "";
        infomodel.Text = "";
        infono.Text = "";
        searchUpkeepPer.Text = "";
        searchExpectTime.Text = "";
        DropDownList2.SelectedIndex = 0;
        searchPDate.Text = "";
        searchPPerson.Text = "";
        searchMakingTime.Text = "";
        newUpkeepPer.Text = "";
        newExpectTime.Text = "";
        DropDownList3.SelectedIndex = 0;
        newPDate.Text = "";
    }
    #endregion 检索设备保养计划

    #region 设备保养信息gridview
    protected void Grid_EquipUpkeepPlan_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Look1")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_EquipUpkeepPlan.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string EUP_ID = al[0];
            Label_eupid.Text = EUP_ID;
            string EN_EquipName = al[1];
            lookname.Text = EN_EquipName;
            string EI_No = al[2];
            lookno.Text = EI_No;
            string EUP_UpkeepPer = al[3];
            lookper.Text = EUP_UpkeepPer;
            decimal EUP_ExpectTime = Convert.ToDecimal(al[4].ToString());
            looktime.Text = EUP_ExpectTime.ToString();
            string EUP_Class = al[5];
            DropDownList4.SelectedValue = EUP_Class;
            DateTime EUP_PDate = Convert.ToDateTime(al[6].ToString());
            lookdate.Text = EUP_PDate.ToString("yyyy-MM-dd HH:mm:ss");
            string EUP_PPerson = al[7];
            lookmakeper.Text = EUP_PPerson;
            DateTime EUP_MakingTime = Convert.ToDateTime(al[8].ToString());
            lookmaketime.Text = EUP_MakingTime.ToString("yyyy-MM-dd HH:mm:ss");
            string EUP_GeneratePer = al[9];
            lookgenper.Text = EUP_GeneratePer;
            if (al[10].ToString() == "")
            {
                lookgentime.Text = "";
            }
            else
            {
                DateTime EUP_GenerateTime = Convert.ToDateTime(al[10].ToString());
                lookgentime.Text = EUP_GenerateTime.ToString("yyyy-MM-dd HH:mm:ss");
            }
            string EUP_ActPer = al[11];
            lookdealper.Text = EUP_ActPer;
            string EUP_OutPContents=al[12];
            lookunplanned.Text=EUP_OutPContents;
            if (al[13].ToString() == "")
            {
                lookbegtime.Text = "";
            }
            else
            {
                DateTime EUP_UStartT = Convert.ToDateTime(al[13].ToString());
                lookbegtime.Text = EUP_UStartT.ToString("yyyy-MM-dd HH:mm:ss");
            }
            if (al[14].ToString() == "")
            {
                lookendtime.Text = "";
            }
            else
            {
                DateTime EUP_UEndT = Convert.ToDateTime(al[14].ToString());
                lookendtime.Text = EUP_UEndT.ToString("yyyy-MM-dd HH:mm:ss");
            }
            string EUP_Remarks=al[15];
            looknote.Text=EUP_Remarks;

            GridView1.DataSource = equipUpkeepPlanL.Search_EquipUpkeepPlan_Item("and a.EUP_ID = '" + Label_eupid.Text + "'");
            GridView1.DataBind();
            Grid_spare.DataSource = equipUpkeepPlanL.Search_EquipUpkeepPlan_Sparedone("and e.EUP_ID = '" + Label_eupid.Text + "'");
            Grid_spare.DataBind();

            Panel_Look.Visible = true;
            Panel1.Visible = true;
            Panel1.Enabled = false;
            Buttonlast.Visible = false;
            Buttonchoose.Visible = false;
            GridView1.Columns[6].Visible = false;
            Panel2.Visible = true;
            Panel2.Enabled = false;
            Panel3.Visible = true;
            Panel3.Enabled = false;
            Btn_spare.Visible = false;
            Grid_spare.Columns[10].Visible = false;
            Panel4.Visible = true;
            Panel5.Visible = false;
            Panel6.Visible = false;
            Panel7.Visible = false;
            Panel8.Visible = false;
            UpdatePanel_Look.Update();
        }
        if (e.CommandName == "Item1")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_EquipUpkeepPlan.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string EUP_ID = al[0];
            Label_eupid.Text = EUP_ID;
            string EN_EquipName = al[1];
            lookname.Text = EN_EquipName;
            string EI_No = al[2];
            lookno.Text = EI_No;
            string EUP_UpkeepPer = al[3];
            lookper.Text = EUP_UpkeepPer;
            decimal EUP_ExpectTime = Convert.ToDecimal(al[4].ToString());
            looktime.Text = EUP_ExpectTime.ToString();
            string EUP_Class = al[5];
            DropDownList4.SelectedValue = EUP_Class;
            DateTime EUP_PDate = Convert.ToDateTime(al[6].ToString());
            lookdate.Text = EUP_PDate.ToString("yyyy-MM-dd HH:mm:ss");
            string EUP_PPerson = al[7];
            lookmakeper.Text = EUP_PPerson;
            DateTime EUP_MakingTime = Convert.ToDateTime(al[8].ToString());
            lookmaketime.Text = EUP_MakingTime.ToString("yyyy-MM-dd HH:mm:ss");
            string EI_ID = al[9];
            Label_eiid1.Text = EI_ID;
            string EN_ID = al[10];
            Label_nid1.Text = EN_ID;
            if (al[11] != "待提交")
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel_EquipUpkeepPlan, GetType(), "alert", "alert('该状态下不可编辑，请重提申请！')", true);
                return;
            }

            GridView1.DataSource = equipUpkeepPlanL.Search_EquipUpkeepPlan_Item("and a.EUP_ID = '" + Label_eupid.Text + "'");
            GridView1.DataBind();

            Panel_Look.Visible = true;
            Panel1.Visible = true;
            Panel1.Enabled = true;
            Buttonlast.Visible = true;
            Buttonchoose.Visible = true;
            GridView1.Columns[6].Visible = true;
            Panel2.Visible = false;
            Panel2.Enabled = false;
            Panel3.Visible = false;
            Panel3.Enabled = false;
            Btn_spare.Visible = false;
            Grid_spare.Columns[10].Visible = false;
            Panel4.Visible = false;
            Panel5.Visible = true;
            Panel6.Visible = false;
            Panel7.Visible = false;
            Panel8.Visible = false;
            UpdatePanel_Look.Update();
        }
        if (e.CommandName == "Generate1")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_EquipUpkeepPlan.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string EUP_ID = al[0];
            Label_eupid.Text = EUP_ID;
            string EN_EquipName = al[1];
            lookname.Text = EN_EquipName;
            string EI_No = al[2];
            lookno.Text = EI_No;
            string EUP_UpkeepPer = al[3];
            lookper.Text = EUP_UpkeepPer;
            decimal EUP_ExpectTime = Convert.ToDecimal(al[4].ToString());
            looktime.Text = EUP_ExpectTime.ToString();
            string EUP_Class = al[5];
            DropDownList4.SelectedValue = EUP_Class;
            DateTime EUP_PDate = Convert.ToDateTime(al[6].ToString());
            lookdate.Text = EUP_PDate.ToString("yyyy-MM-dd HH:mm:ss");
            string EUP_PPerson = al[7];
            lookmakeper.Text = EUP_PPerson;
            DateTime EUP_MakingTime = Convert.ToDateTime(al[8].ToString());
            lookmaketime.Text = EUP_MakingTime.ToString("yyyy-MM-dd HH:mm:ss");
            string EI_ID = al[9];
            Label_eiid1.Text = EI_ID;
            string EN_ID = al[10];
            Label_nid1.Text = EN_ID;
            if (al[11] != "已提交")
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel_EquipUpkeepPlan, GetType(), "alert", "alert('该状态下不可生成！')", true);
                return;
            }
            lookgenper.Text = Session["UserName"].ToString().Trim();
            lookgentime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            GridView1.DataSource = equipUpkeepPlanL.Search_EquipUpkeepPlan_Item("and a.EUP_ID = '" + Label_eupid.Text + "'");
            GridView1.DataBind();

            Panel_Look.Visible = true;
            Panel1.Visible = true;
            Panel1.Enabled = true;
            Buttonlast.Visible = true;
            Buttonchoose.Visible = true;
            GridView1.Columns[6].Visible = true;
            Panel2.Visible = true;
            Panel2.Enabled = true;
            Panel3.Visible = false;
            Panel3.Enabled = false;
            Btn_spare.Visible = false;
            Grid_spare.Columns[10].Visible = false;
            Panel4.Visible = false;
            Panel5.Visible = false;
            Panel6.Visible = true;
            Panel7.Visible = false;
            Panel8.Visible = false;
            UpdatePanel_Look.Update();
        }
        if (e.CommandName == "Deal1")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_EquipUpkeepPlan.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string EUP_ID = al[0];
            Label_eupid.Text = EUP_ID;
            string EN_EquipName = al[1];
            lookname.Text = EN_EquipName;
            string EI_No = al[2];
            lookno.Text = EI_No;
            string EUP_UpkeepPer = al[3];
            lookper.Text = EUP_UpkeepPer;
            decimal EUP_ExpectTime = Convert.ToDecimal(al[4].ToString());
            looktime.Text = EUP_ExpectTime.ToString();
            string EUP_Class = al[5];
            DropDownList4.SelectedValue = EUP_Class;
            DateTime EUP_PDate = Convert.ToDateTime(al[6].ToString());
            lookdate.Text = EUP_PDate.ToString("yyyy-MM-dd HH:mm:ss");
            string EUP_PPerson = al[7];
            lookmakeper.Text = EUP_PPerson;
            DateTime EUP_MakingTime = Convert.ToDateTime(al[8].ToString());
            lookmaketime.Text = EUP_MakingTime.ToString("yyyy-MM-dd HH:mm:ss");
            string EUP_GeneratePer = al[9];
            lookgenper.Text = EUP_GeneratePer;
            DateTime EUP_GenerateTime = Convert.ToDateTime(al[10].ToString());
            lookgentime.Text = EUP_GenerateTime.ToString("yyyy-MM-dd HH:mm:ss");
            string EMT_ID = al[11];
            Label_emtid.Text = EMT_ID;
            DateTime EUP_UStartT = Convert.ToDateTime(al[12].ToString());
            lookbegtime.Text = EUP_UStartT.ToString("yyyy-MM-dd HH:mm:ss");

            lookdealper.Text = Session["UserName"].ToString().Trim();
            lookendtime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            GridView1.DataSource = equipUpkeepPlanL.Search_EquipUpkeepPlan_Item("and a.EUP_ID = '" + Label_eupid.Text + "'");
            GridView1.DataBind();
            Grid_spare.DataSource = equipUpkeepPlanL.Search_EquipUpkeepPlan_Sparedone("and e.EUP_ID = '" + Label_eupid.Text + "'");
            Grid_spare.DataBind();

            Panel_Look.Visible = true;
            Panel1.Visible = true;
            Panel1.Enabled = false;
            Buttonlast.Visible = false;
            Buttonchoose.Visible = false;
            GridView1.Columns[6].Visible = false;
            Panel2.Visible = true;
            Panel2.Enabled = false;
            Panel3.Visible = true;
            Panel3.Enabled = true;
            Btn_spare.Visible = true;
            Grid_spare.Columns[10].Visible = true;
            Panel4.Visible = false;
            Panel5.Visible = false;
            Panel6.Visible = false;
            Panel7.Visible = true;
            Panel8.Visible = false;
            UpdatePanel_Look.Update();
        }
        if (e.CommandName == "Delete1")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_EquipUpkeepPlan.SelectedIndex = row.RowIndex;

            //Guid EUP_ID = new Guid(Convert.ToString(e.CommandArgument));
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            Guid EUP_ID = new Guid(al[0]);
            Label_eupid.Text = EUP_ID.ToString();
            if (al[1] != "待提交")
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel_EquipUpkeepPlan, GetType(), "alert", "alert('该状态下不可删除！')", true);
                return;
            }
            equipUpkeepPlanL.Delete_EquipUpkeepPlan(EUP_ID);
            //BindGrid_EquipUpkeepPlan("and d.EUP_State='待提交'");
            BindGrid_EquipUpkeepPlan("");
            UpdatePanel_EquipUpkeepPlan.Update();
        }
        if (e.CommandName == "Start1")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_EquipUpkeepPlan.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string EUP_ID = al[0];
            Label_eupid.Text = EUP_ID;
            string EN_EquipName = al[1];
            lookname.Text = EN_EquipName;
            string EI_No = al[2];
            lookno.Text = EI_No;
            string EUP_UpkeepPer = al[3];
            lookper.Text = EUP_UpkeepPer;
            decimal EUP_ExpectTime = Convert.ToDecimal(al[4].ToString());
            looktime.Text = EUP_ExpectTime.ToString();
            string EUP_Class = al[5];
            DropDownList4.SelectedValue = EUP_Class;
            DateTime EUP_PDate = Convert.ToDateTime(al[6].ToString());
            lookdate.Text = EUP_PDate.ToString("yyyy-MM-dd HH:mm:ss");
            string EUP_PPerson = al[7];
            lookmakeper.Text = EUP_PPerson;
            DateTime EUP_MakingTime = Convert.ToDateTime(al[8].ToString());
            lookmaketime.Text = EUP_MakingTime.ToString("yyyy-MM-dd HH:mm:ss");
            string EUP_GeneratePer = al[9];
            lookgenper.Text = EUP_GeneratePer;
            DateTime EUP_GenerateTime = Convert.ToDateTime(al[10].ToString());
            lookgentime.Text = EUP_GenerateTime.ToString("yyyy-MM-dd HH:mm:ss");
            string EMT_ID = al[11];
            Label_emtid.Text = EMT_ID;

            lookbegtime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            GridView1.DataSource = equipUpkeepPlanL.Search_EquipUpkeepPlan_Item("and a.EUP_ID = '" + Label_eupid.Text + "'");
            GridView1.DataBind();

            Panel_Look.Visible = true;
            Panel1.Visible = true;
            Panel1.Enabled = false;
            Buttonlast.Visible = false;
            Buttonchoose.Visible = false;
            GridView1.Columns[6].Visible = false;
            Panel2.Visible = true;
            Panel2.Enabled = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel5.Visible = false;
            Panel6.Visible = false;
            Panel7.Visible = false;
            Panel8.Visible = true;
            UpdatePanel_Look.Update();
        }
    }
    //Gridview翻页
    protected void Grid_EquipUpkeepPlan_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_EquipUpkeepPlan.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox1");   // refer to the TextBox with the NewPageIndex value
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
        BindGrid_EquipUpkeepPlan(condition);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_EquipUpkeepPlan.PageCount ? Grid_EquipUpkeepPlan.PageCount - 1 : newPageIndex;
        Grid_EquipUpkeepPlan.PageIndex = newPageIndex;
        Grid_EquipUpkeepPlan.DataBind();
    }
    protected void Grid_EquipUpkeepPlan_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
    #endregion 设备保养信息gridview

    #region 增加保养计划时，首先查询并选择设备台账
    protected void Search_info_Click(object sender, EventArgs e)
    {
        string ETT_Type=DropDownList5.SelectedValue.ToString();
        string EN_EquipName = infoname.Text.ToString();
        string EMT_Type = infomodel.Text.ToString();
        string EI_No = infono.Text.ToString();
        Grid_EquipInfo.DataSource = equipUpkeepPlanL.Search_InsertEquipUpkeepPlan_Inf(ETT_Type, EN_EquipName, EMT_Type, EI_No);
        Grid_EquipInfo.DataBind();
        Panel_last.Visible = false;
        UpdatePanel_last.Update();
        Panel_New.Visible = false;
        UpdatePanel_New.Update();
    }
    protected void Clear_info_Click(object sender, EventArgs e)
    {
        DropDownList5.Items.Insert(0, new ListItem("", ""));
        BindDropDownList5();
        infoname.Text = "";
        infomodel.Text = "";
        infono.Text = "";
        string ETT_Type = "";
        string EN_EquipName = "";
        string EMT_Type = "";
        string EI_No = "";
        Grid_EquipInfo.DataSource = equipUpkeepPlanL.Search_InsertEquipUpkeepPlan_Inf(ETT_Type, EN_EquipName, EMT_Type, EI_No);
        Grid_EquipInfo.DataBind();
        Panel_last.Visible = false;
        UpdatePanel_last.Update();
        Panel_New.Visible = false;
        UpdatePanel_New.Update();
    }
    protected void Close_info_Click(object sender, EventArgs e)
    {
        Panel_searchInf.Visible = false;
        Panel_New.Visible = false;
        UpdatePanel_New.Update();
        Panel_last.Visible = false;
        UpdatePanel_last.Update();
    }
    #endregion 增加保养计划时，首先查询并选择设备台账

    #region 增加保养计划时，台账gridview
    protected void Grid_EquipInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Add_plan")//点击建立保养计划
        {
            Clear();
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_EquipInfo.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            Guid EI_ID = new Guid(Convert.ToString(al[0]));
            Guid EN_ID = new Guid(Convert.ToString(al[1]));
            string EN_EquipName = al[2];
            string EI_No = al[3];
            Label_eiid.Text =Convert.ToString( EI_ID);
            Label_nid.Text =Convert.ToString( EN_ID);
            newname.Text = EN_EquipName;
            newno.Text = EI_No;
            newPPerson.Text = Session["UserName"].ToString().Trim();
            newMakingTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            save_plan.Visible = true;
            cancel_plan.Visible = true;
            Panel_New.Visible = true;
            UpdatePanel_New.Update();
        }
        if (e.CommandName == "Add_last")//点击查看上次保养项目
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_EquipInfo.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            Guid EI_ID = new Guid( Convert.ToString(al[0]));
            Label_eiid.Text = Convert.ToString(EI_ID);
            Guid EN_ID = new Guid( Convert.ToString(al[1]));
            Label_nid.Text = Convert.ToString(EN_ID);
            string EN_EquipName = al[2];
            string EI_No = al[3];
            Label60.Text = Convert.ToString(EN_EquipName);
            Label61.Text = Convert.ToString(EI_No);
            Grid_last.DataSource = equipUpkeepPlanL.Search_InsertEquipUpkeepPlan_Last(EN_ID, EI_ID);
            Grid_last.DataBind();
            Panel_last.Visible = true;
            UpdatePanel_last.Update();
        }
    }
    protected void Grid_EquipInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_EquipInfo.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox2");   // refer to the TextBox with the NewPageIndex value
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
        string ETT_Type = DropDownList5.SelectedValue.ToString();
        string EN_EquipName = infoname.Text.ToString();
        string EMT_Type = infomodel.Text.ToString();
        string EI_No = infono.Text.ToString();
        Grid_EquipInfo.DataSource = equipUpkeepPlanL.Search_InsertEquipUpkeepPlan_Inf(ETT_Type, EN_EquipName, EMT_Type, EI_No);
        Grid_EquipInfo.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_EquipInfo.PageCount ? Grid_EquipInfo.PageCount - 1 : newPageIndex;
        Grid_EquipInfo.PageIndex = newPageIndex;
        Grid_EquipInfo.DataBind();
    }
    protected void Grid_EquipInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
    #endregion 增加保养计划时，台账gridview

    #region 上次保养记录gridview
    protected void last_close_Click(object sender, EventArgs e)
    {
        Panel_last.Visible = false;
        UpdatePanel_last.Update();
    }
    protected void Grid_last_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    }
    protected void Grid_last_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_last.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox6");   // refer to the TextBox with the NewPageIndex value
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
        Guid EI_ID = new Guid(Label_eiid.Text.ToString());
        Guid EN_ID = new Guid(Label_nid.Text.ToString());
        Grid_last.DataSource = equipUpkeepPlanL.Search_InsertEquipUpkeepPlan_Last(EN_ID, EI_ID);
        Grid_last.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_last.PageCount ? Grid_last.PageCount - 1 : newPageIndex;
        Grid_last.PageIndex = newPageIndex;
        Grid_last.DataBind();
    }
    protected void Grid_last_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
    #endregion 上次保养记录gridview

    #region 增加保养计划
    protected void save_plan_Click(object sender, EventArgs e)
    {
        if (newUpkeepPer.Text.ToString() == "" || newExpectTime.Text.ToString() == "" || DropDownList3.SelectedValue.ToString() == "" || newPDate.Text.ToString() == "" || newPPerson.Text.ToString() == "" || newMakingTime.Text.ToString()=="")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        Guid EI_ID = new Guid(Label_eiid.Text.ToString());
        string EUP_UpkeepPer = newUpkeepPer.Text.ToString();
        decimal m1;
        if (!(decimal.TryParse(newExpectTime.Text, out m1)))
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_New, GetType(), "alert", "alert('保养预计时间必须为数字！')", true);
            return;
        }
        decimal EUP_ExpectTime = m1;
        //decimal EUP_ExpectTime = Convert.ToDecimal(this.newExpectTime.Text.ToString());
        string EUP_Class = DropDownList3.SelectedValue.ToString();
        DateTime EUP_PDate = Convert.ToDateTime(newPDate.Text.ToString());
        string EUP_PPerson = newPPerson.Text.ToString();
        DateTime EUP_MakingTime = Convert.ToDateTime(newMakingTime.Text.ToString());
        string EUP_State = "待提交";

        if(EUP_PDate<EUP_MakingTime)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('计划保养的日期应大于计划制定的日期！')", true);
            return;
        }

        DataSet ds = equipUpkeepPlanL.Search_EquipUpkeepPlan("and d.EI_ID = '" + Label_eiid.Text + "' and EUP_Class = '" + DropDownList3.SelectedValue.ToString() + "' and EUP_PDate = '" + newPDate.Text + "'and (d.EUP_State='待提交' or d.EUP_State='已提交' or d.EUP_State='已生成' or d.EUP_State='保养开始')");
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count != 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('该设备当天已有保养计划，不能重复！')", true);
            return;
        }

        equipUpkeepPlanL.Insert_EquipUpkeepPlan_plan(EI_ID, EUP_UpkeepPer, EUP_ExpectTime, EUP_Class, EUP_PDate, EUP_PPerson, EUP_MakingTime, EUP_State);
        //BindGrid_EquipUpkeepPlan("and d.EUP_State='待提交'");
        BindGrid_EquipUpkeepPlan("");
        UpdatePanel_EquipUpkeepPlan.Update();
        Panel_New.Visible = false;
        UpdatePanel_New.Update();
        Panel_searchInf.Visible = false;
        Panel_last.Visible = false;
        UpdatePanel_last.Update();

        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('保养计划已保存，请在“编辑”中选择保养项目！')", true);
    }
    
    protected void cancel_plan_Click(object sender, EventArgs e)
    {
        if (Panel_New.Visible)
        {
            Panel_New.Visible = false;
        }
    }
    #endregion 增加保养计划

    #region 可选的保养项目
    //选中的行，翻页不消失
    protected ArrayList SelectedItems
    {
        get
        {
            return (ViewState["mySelectedItems"] != null) ? (ArrayList)ViewState["mySelectedItems"] : null;
        }
        set
        {
            ViewState["mySelectedItems"] = value;
        }
    }
    protected void CollectSelected()
    {
        ArrayList selectedItems = null;
        if (SelectedItems == null)
            selectedItems = new ArrayList();
        else
            selectedItems = SelectedItems;
        //获取选择的记录
        for (int i = 0; i < Grid_newitem.Rows.Count; i++)
        {
            //string id = this.GridView_ProType.Rows[i].Cells[1].Text;
            CheckBox cb = Grid_newitem.Rows[i].FindControl("ckb") as CheckBox;
            string id = Grid_newitem.DataKeys[i].Values[0].ToString();
            if (selectedItems.Contains(id) && !cb.Checked)
                selectedItems.Remove(id);
            if (!selectedItems.Contains(id) && cb.Checked)
                selectedItems.Add(id);
        }
        SelectedItems = selectedItems;
    }
    //该设备可选的保养计划GridView
    protected void Grid_newitem_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    }
    //Gridview翻页
    protected void Grid_newitem_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_newitem.BottomPagerRow;

            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox7"); // refer to the TextBox with the NewPageIndex value
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
        CollectSelected();
        Grid_newitem.DataSource = equipUpkeepItemL.Search_EquipUpkeepItemInfo("and b.EN_ID = '" + Label_nid1.Text + "'");
        Grid_newitem.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_newitem.PageCount ? Grid_newitem.PageCount - 1 : newPageIndex;
        Grid_newitem.PageIndex = newPageIndex;
        Grid_newitem.DataBind();
    }
    protected void Grid_newitem_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //这里的处理是为了回显之前选中的情况
        if (e.Row.RowIndex > -1 && SelectedItems != null)
        {
            //DataRowView row = e.Row.DataItem as DataRowView;
            CheckBox cb = e.Row.FindControl("ckb") as CheckBox;
            string id = Grid_newitem.DataKeys[e.Row.RowIndex].Values[0].ToString();
            if (SelectedItems.Contains(id))
                cb.Checked = true;
            else
                cb.Checked = false;
        }
    }
    //按钮
    protected void Btn_Save_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow item in Grid_newitem.Rows)
        {
            CheckBox cb = item.FindControl("ckb") as CheckBox;
            if (cb.Checked)
            {
                Guid eUP_ID = new Guid(Label_eupid.Text.ToString());
                Guid eI_ID = new Guid(Label_eiid1.Text.ToString());
                Guid eUI_ID = new Guid(Grid_newitem.DataKeys[item.RowIndex].Value.ToString());
                string condition = "and a.EUP_ID='" + eUP_ID + "' and a.EI_ID='" + eI_ID + "' and c.EUI_ID='" + eUI_ID + "'";
                DataSet ds = equipUpkeepPlanL.Search_EquipUpkeepPlan_Item(condition);
                //if (!(ds.Tables.Count == 1 && ds.Tables[0].Rows.Count == 0)) //若有一条相同的，就提示，其余不同的则添加。
                if (!(ds.Tables[0].Rows.Count == 0))// have a check 若有一条相同的，就提示，其余不同的也不添加。
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel_newitem, GetType(), "aa", "alert('系统中已有该设备的保养项目，不能重复选择!')", true);
                    return;
                }
                else
                {
                    equipUpkeepPlanL.Insert_EquipUpkeepPlan_item(eUI_ID, eUP_ID);
                    GridView1.DataSource = equipUpkeepPlanL.Search_EquipUpkeepPlan_Item("and a.EUP_ID = '" + Label_eupid.Text + "'");
                    GridView1.DataBind();
                    BindGrid_EquipUpkeepPlan("and d.EUP_State='待提交'");
                    UpdatePanel_Look.Update();
                    UpdatePanel_newitem.Update();
                }
            }
        }
    }
    protected void Btn_Cancel_Click(object sender, EventArgs e)
    {
        Panel_newitem.Visible = false;
        UpdatePanel_newitem.Update();
    }
    #endregion 可选的保养项目

    #region 制定保养项目，同时可以编辑/修改保养计划
    protected void Buttonlast_Click(object sender, EventArgs e)
    {
        Guid EI_ID = new Guid(Convert.ToString(Label_eiid1.Text));
        Guid EN_ID = new Guid(Convert.ToString(Label_nid1.Text));
        Label60.Text = lookname.Text;
        Label61.Text = lookno.Text;
        Grid_last.DataSource = equipUpkeepPlanL.Search_InsertEquipUpkeepPlan_Last(EN_ID, EI_ID);
        Grid_last.DataBind();
        Panel_last.Visible = true;
        UpdatePanel_last.Update();
    }
    protected void Buttonchoose_Click(object sender, EventArgs e)
    {
        Panel_newitem.Visible = true;
        Grid_newitem.DataSource = equipUpkeepItemL.Search_EquipUpkeepItemInfo("and b.EN_ID = '" + Label_nid1.Text + "'");
        Grid_newitem.DataBind();
        UpdatePanel_newitem.Update();
    }
    protected void save_planedit_Click(object sender, EventArgs e)
    {
        if (lookper.Text.ToString() == "" || looktime.Text.ToString() == "" || DropDownList4.SelectedValue.ToString() == "" || lookdate.Text.ToString() == "" || lookmakeper.Text.ToString() == "" || lookmaketime.Text.ToString() == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        Guid EUP_ID = new Guid(Label_eupid.Text.ToString());
        string EUP_UpkeepPer = lookper.Text.ToString();
        decimal m3;
        if (!(decimal.TryParse(looktime.Text, out m3)))
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_Look, GetType(), "alert", "alert('保养预计时间必须为数字！')", true);
            return;
        }
        decimal EUP_ExpectTime = m3;
        //decimal EUP_ExpectTime = Convert.ToDecimal(this.newExpectTime.Text.ToString());
        string EUP_Class = DropDownList4.SelectedValue.ToString();
        DateTime EUP_PDate = Convert.ToDateTime(lookdate.Text.ToString());
        string EUP_PPerson = lookmakeper.Text.ToString();
        DateTime EUP_MakingTime = Convert.ToDateTime(lookmaketime.Text.ToString());
        string EUP_State = "待提交";

        if (EUP_PDate < EUP_MakingTime)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('计划保养的日期应大于计划制定的日期！')", true);
            return;
        }

        DataSet ds = equipUpkeepPlanL.Search_EquipUpkeepPlan("and d.EI_ID = '" + Label_eiid1.Text + "' and EUP_Class = '" + DropDownList4.SelectedValue.ToString() + "' and EUP_PDate = '" + lookdate.Text + "' and (d.EUP_State='待提交' or d.EUP_State='已提交' or d.EUP_State='已生成')");
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count != 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('该设备当天已有保养计划，不能重复！')", true);
            return;
        }
        equipUpkeepPlanL.Update_EquipUpkeepPlan_ZD(EUP_ID, EUP_UpkeepPer, EUP_ExpectTime, EUP_Class, EUP_PDate, EUP_PPerson, EUP_MakingTime, EUP_State);
        //BindGrid_EquipUpkeepPlan("and d.EUP_State='待提交'");
        BindGrid_EquipUpkeepPlan("");
        UpdatePanel_EquipUpkeepPlan.Update();
        Panel_Look.Visible = false;
        UpdatePanel_Look.Update();
        Panel_searchInf.Visible = false;
        Panel_last.Visible = false;
        UpdatePanel_last.Update();
    }
    protected void sub_planedit_Click(object sender, EventArgs e)
    {
        if (lookper.Text.ToString() == "" || looktime.Text.ToString() == "" || DropDownList4.SelectedValue.ToString() == "" || lookdate.Text.ToString() == "" || lookmakeper.Text.ToString() == "" || lookmaketime.Text.ToString() == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        Guid EUP_ID = new Guid(Label_eupid.Text.ToString());
        string EUP_UpkeepPer = lookper.Text.ToString();
        decimal m4;
        if (!(decimal.TryParse(looktime.Text, out m4)))
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_Look, GetType(), "alert", "alert('保养预计时间必须为数字！')", true);
            return;
        }
        decimal EUP_ExpectTime = m4;
        //decimal EUP_ExpectTime = Convert.ToDecimal(this.newExpectTime.Text.ToString());
        string EUP_Class = DropDownList4.SelectedValue.ToString();
        DateTime EUP_PDate = Convert.ToDateTime(lookdate.Text.ToString());
        string EUP_PPerson = lookmakeper.Text.ToString();
        DateTime EUP_MakingTime = Convert.ToDateTime(lookmaketime.Text.ToString());
        string EUP_State = "已提交";

        if (EUP_PDate < EUP_MakingTime)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('计划保养的日期应大于计划制定的日期！')", true);
            return;
        }

        DataSet ds = equipUpkeepPlanL.Search_EquipUpkeepPlan("and d.EI_ID = '" + Label_eiid1.Text + "' and EUP_Class = '" + DropDownList4.SelectedValue.ToString() + "' and EUP_PDate = '" + lookdate.Text + "' and (d.EUP_State='已提交' or d.EUP_State='已生成')");
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count != 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('该设备当天已有保养计划，不能重复！')", true);
            return;
        }
        equipUpkeepPlanL.Update_EquipUpkeepPlan_ZD(EUP_ID, EUP_UpkeepPer, EUP_ExpectTime, EUP_Class, EUP_PDate, EUP_PPerson, EUP_MakingTime, EUP_State);
        //BindGrid_EquipUpkeepPlan("and d.EUP_State='待提交'");
        BindGrid_EquipUpkeepPlan("");
        UpdatePanel_EquipUpkeepPlan.Update();
        Panel_Look.Visible = false;
        UpdatePanel_Look.Update();
        Panel_searchInf.Visible = false;
        Panel_last.Visible = false;
        UpdatePanel_last.Update();
        //RTX
        string message = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "提交了设备编号为"+ lookno.Text +"的保养计划，请确认。";
        string sErr = RTXhelper.Send(message, "设备保养计划查看");
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('" + sErr + "')", true);
        }
    }
    protected void cancel_planedit_Click(object sender, EventArgs e)
    {
        if (Panel_Look.Visible)
        {
            Panel_Look.Visible = false;
            UpdatePanel_Look.Update();
        }
    }
    #endregion 制定保养项目，同时可以编辑/修改保养计划

    #region 生成保养计划
    protected void btn_Generate_Click(object sender, EventArgs e)
    {
        Guid EUP_ID = new Guid(Label_eupid.Text.ToString());
        string EUP_UpkeepPer = lookper.Text.ToString();
        decimal m5;
        if (!(decimal.TryParse(looktime.Text, out m5)))
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_Look, GetType(), "alert", "alert('保养预计时间必须为数字！')", true);
            return;
        }
        decimal EUP_ExpectTime = m5;
        //decimal EUP_ExpectTime = Convert.ToDecimal(this.looktime.Text.ToString());
        string EUP_Class = DropDownList4.SelectedValue.ToString();
        DateTime EUP_PDate = Convert.ToDateTime(lookdate.Text.ToString());
        string EUP_PPerson = lookmakeper.Text.ToString();
        DateTime EUP_MakingTime = Convert.ToDateTime(lookmaketime.Text.ToString());
        string EUP_State = "已生成";
        string EUP_GeneratePer=lookgenper.Text.ToString();
        DateTime EUP_GenerateTime = Convert.ToDateTime(lookgentime.Text.ToString());

        if (EUP_PDate < EUP_MakingTime)
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_Look, GetType(), "alert", "alert('计划保养的日期应大于计划制定的日期！')", true);
            return;
        }
        if (EUP_GenerateTime < EUP_MakingTime)
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_Look, GetType(), "alert", "alert('计划生成的日期应大于计划制定的日期！')", true);
            return;
        }
        if (EUP_PDate < EUP_GenerateTime)
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_Look, GetType(), "alert", "alert('计划保养的日期应大于计划生成的日期！')", true);
            return;
        }

        equipUpkeepPlanL.Update_EquipUpkeepPlan_SC(EUP_ID, EUP_UpkeepPer, EUP_ExpectTime, EUP_Class, EUP_PDate, EUP_PPerson, EUP_MakingTime, EUP_State, EUP_GeneratePer, EUP_GenerateTime);
        BindGrid_EquipUpkeepPlan("and d.EUP_State!='待提交'");
        Panel_Look.Visible = false;
        UpdatePanel_Look.Update();
        Panel_last.Visible = false;
        UpdatePanel_last.Update();
        Panel_newitem.Visible = false;
        UpdatePanel_newitem.Update();
        UpdatePanel_EquipUpkeepPlan.Update();
        //RTX
        string message = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "生成了设备编号为" + lookno.Text + "的保养计划，请开始保养。";
        string sErr = RTXhelper.Send(message, "设备保养开始确认");
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('" + sErr + "')", true);
        }
    }
    protected void Cancel_Generate_Click(object sender, EventArgs e)
    {
        if (Panel_Look.Visible)
        {
            Panel_Look.Visible = false;
            UpdatePanel_Look.Update();
            Panel_last.Visible = false;
            UpdatePanel_last.Update();
            Panel_newitem.Visible = false;
            UpdatePanel_newitem.Update();
        }
    }
    //保养项目GridView1
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete_choose")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView1.SelectedIndex = row.RowIndex;

            Guid EUD_ID = new Guid(Convert.ToString(e.CommandArgument));
            equipUpkeepPlanL.Delete_EquipUpkeepPlan_item(EUD_ID);
            GridView1.DataSource = equipUpkeepPlanL.Search_EquipUpkeepPlan_Item("and a.EUP_ID = '" + Label_eupid.Text + "'");
            GridView1.DataBind();
        }
    }
    //翻页
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView1.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox4");   // refer to the TextBox with the NewPageIndex value
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
        GridView1.DataSource = equipUpkeepPlanL.Search_EquipUpkeepPlan_Item("and a.EUP_ID = '" + Label_eupid.Text + "'");
        GridView1.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView1.PageCount ? GridView1.PageCount - 1 : newPageIndex;
        GridView1.PageIndex = newPageIndex;
        GridView1.DataBind();
    }
    //行变色
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
    #endregion 生成保养计划

    #region 记录保养情况
    //“选择备件”按钮
    protected void Btn_spare_Click(object sender, EventArgs e)
    {
        Grid_NewEquipSpare.DataSource = equipNameModelL.Search_EquipFreqUsedSpareInfo("and X.EMT_ID = '" + Label_emtid.Text + "'");
        Grid_NewEquipSpare.DataBind();
        Panel_NewSpare.Visible = true;
        UpdatePanel_NewSpare.Update();
    }
    //提交按钮
    protected void btn_Deal_Click(object sender, EventArgs e)
    {
        Guid EUP_ID = new Guid(Label_eupid.Text.ToString());
        string EUP_ActPer = lookdealper.Text.ToString();
        string EUP_OutPContents = lookunplanned.Text.ToString();
        DateTime EUP_UStartT = Convert.ToDateTime(lookbegtime.Text.ToString());
        DateTime EUP_UEndT = Convert.ToDateTime(lookendtime.Text.ToString());
        string EUP_Remarks = looknote.Text.ToString();
        string EUP_State = "已完成";

        if (EUP_UEndT < EUP_UStartT)
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_Look, GetType(), "aa", "alert('保养结束的日期应大于保养开始的日期！')", true);
            return;
        }
        if (EUP_UStartT < Convert.ToDateTime(lookgentime.Text.ToString()))
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_Look, GetType(), "aa", "alert('保养开始的日期应大于计划生成的日期！')", true);
            return;
        }

        equipUpkeepPlanL.Update_EquipUpkeepPlan_JL(EUP_ID, EUP_ActPer, EUP_OutPContents, EUP_UStartT, EUP_UEndT, EUP_Remarks,EUP_State);
        BindGrid_EquipUpkeepPlan("and d.EUP_State='保养开始'");
        Panel_Look.Visible = false;
        UpdatePanel_Look.Update();
        Panel_NewSpare.Visible = false;
        UpdatePanel_NewSpare.Update();
        UpdatePanel_EquipUpkeepPlan.Update();
    }
    //取消按钮
    protected void Cancel_Deal_Click(object sender, EventArgs e)
    {
        if (Panel_Look.Visible)
        {
            Panel_Look.Visible = false;
            UpdatePanel_Look.Update();
            Panel_NewSpare.Visible = false;
            UpdatePanel_NewSpare.Update();
        }
    }
    //所用设备Grid_spare
    protected void Grid_spare_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete_spare")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_spare.SelectedIndex = row.RowIndex;

            Guid EMSAUS_ID = new Guid(Convert.ToString(e.CommandArgument));
            equipUpkeepPlanL.Delete_EquipUpkeepPlan_Spare(EMSAUS_ID);
            //string condition = "and EUP_State='已建立'";
            Grid_spare.DataSource = equipUpkeepPlanL.Search_EquipUpkeepPlan_Sparedone("and e.EUP_ID = '" + Label_eupid.Text + "'");
            Grid_spare.DataBind();
            UpdatePanel_Look.Update();
        }
    }
    protected void Grid_spare_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_spare.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox5");   // refer to the TextBox with the NewPageIndex value
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
        Grid_spare.DataSource = equipUpkeepPlanL.Search_EquipUpkeepPlan_Sparedone("and a.EUP_ID = '" + Label_eupid.Text + "'");
        Grid_spare.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_spare.PageCount ? Grid_spare.PageCount - 1 : newPageIndex;
        Grid_spare.PageIndex = newPageIndex;
        Grid_spare.DataBind();
    }
    protected void Grid_spare_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
    #endregion 记录保养情况

    #region 选择备件
    //备件精确搜索
    protected void Search_newspare_Click(object sender, EventArgs e)
    {
        string condition1 = GetCondition1();
        Grid_NewEquipSpare.DataSource = equipNameModelL.Search_EquipFreqUsedSpareInfo(condition1);
        Grid_NewEquipSpare.DataBind();
    }
    protected string GetCondition1()
    {
        string condition1;
        string temp = "";
        if (Textnewspname.Text.ToString() != "")
        {
            temp += " and IMMBD_MaterialName like '%" + Textnewspname.Text.ToString() + "%'";
        }
        if (Textnewspno.Text.ToString() != "")
        {
            temp += " and  IMMBD_MaterialCode like '%" + Textnewspno.Text.ToString() + "%'";
        }
        if (Textnewspmodel.Text.ToString() != "")
        {
            temp += " and  IMMBD_SpecificationModel like '%" + Textnewspmodel.Text.ToString() + "%'";
        }
        temp += "and a.EMT_ID='" + Label_emtid.Text + "'";
        condition1 = temp;
        return condition1;
    }
    protected void Clear_newspare_Click(object sender, EventArgs e)
    {
        Textnewspname.Text = "";
        Textnewspno.Text = "";
        Textnewspmodel.Text = "";
        Grid_NewEquipSpare.DataSource = equipNameModelL.Search_EquipFreqUsedSpareInfo("and X.EMT_ID = '" + Label_emtid.Text + "'");
        Grid_NewEquipSpare.DataBind();
    }

    //选中的行，翻页不消失
    protected ArrayList SelectedItems1
    {
        get
        {
            return (ViewState["mySelectedItems1"] != null) ? (ArrayList)ViewState["mySelectedItems1"] : null;
        }
        set
        {
            ViewState["mySelectedItems1"] = value;
        }
    }
    protected void CollectSelected1()
    {
        ArrayList selectedItems1 = null;
        if (SelectedItems1 == null)
            selectedItems1 = new ArrayList();
        else
            selectedItems1 = SelectedItems1;
        //获取选择的记录
        for (int i = 0; i < Grid_NewEquipSpare.Rows.Count; i++)
        {
            CheckBox cb = Grid_NewEquipSpare.Rows[i].FindControl("ckb1") as CheckBox;
            string id = Grid_NewEquipSpare.DataKeys[i].Values[0].ToString();
            if (selectedItems1.Contains(id) && !cb.Checked)
                selectedItems1.Remove(id);
            if (!selectedItems1.Contains(id) && cb.Checked)
                selectedItems1.Add(id);
        }
        SelectedItems1 = selectedItems1;
    }
    //备选备件GridView
    protected void Grid_NewEquipSpare_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    }
    protected void Grid_NewEquipSpare_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_NewEquipSpare.BottomPagerRow;

            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox8");   // refer to the TextBox with the NewPageIndex value
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
        CollectSelected1();
        Grid_NewEquipSpare.DataSource = equipUpkeepPlanL.Search_EquipUpkeepPlan_Spare("and a.EMT_ID='" + Label_emtid.Text + "'");
        Grid_NewEquipSpare.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_NewEquipSpare.PageCount ? Grid_NewEquipSpare.PageCount - 1 : newPageIndex;
        Grid_NewEquipSpare.PageIndex = newPageIndex;
        Grid_NewEquipSpare.DataBind();
    }
    protected void Grid_NewEquipSpare_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //这里的处理是为了回显之前选中的情况
        if (e.Row.RowIndex > -1 && SelectedItems1 != null)
        {
            //DataRowView row = e.Row.DataItem as DataRowView;
            CheckBox cb = e.Row.FindControl("ckb1") as CheckBox;
            string id = Grid_NewEquipSpare.DataKeys[e.Row.RowIndex].Values[0].ToString();
            if (SelectedItems1.Contains(id))
                cb.Checked = true;
            else
                cb.Checked = false;
        }
    }

    //选择备件以及提交
    protected void BtnOK_NewSpare_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow item in Grid_NewEquipSpare.Rows)
        {
            CheckBox cb = item.FindControl("ckb1") as CheckBox;
            if (cb.Checked)
            {
                Guid eFUS_ID = new Guid(Grid_NewEquipSpare.DataKeys[item.RowIndex].Value.ToString());
                Guid eUP_ID = new Guid(Label_eupid.Text.ToString());
                int eMSAUS_UseAmount = Convert.ToInt16(((TextBox)(Grid_NewEquipSpare.Rows[item.RowIndex].Cells[8].FindControl("useno"))).Text.Trim());
                string IMIM_TotalNum = (Grid_NewEquipSpare.Rows[item.RowIndex].Cells[7].Text.Trim().ToString());
                if (eMSAUS_UseAmount - float.Parse(IMIM_TotalNum)>0)
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel_NewSpare, GetType(), "aa", "alert('使用数量不能超过总数量!')", true);
                    return;
                }
                if (eMSAUS_UseAmount <= 0)
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel_NewSpare, GetType(), "aa", "alert('请填写使用数量!')", true);
                    return;
                }
                DataSet ds = equipUpkeepPlanL.Search_EquipUpkeepPlan_Sparedone("and e.EUP_ID = '" + Label_eupid.Text + "' and e.EFUS_ID='" + eFUS_ID + "'");
                //if (!(ds.Tables.Count == 1 && ds.Tables[0].Rows.Count == 0))// have a check 若有一条相同的，就提示，其余不同的则添加。
                if (!(ds.Tables[0].Rows.Count == 0))// have a check 若有一条相同的，就提示，其余不同的也不添加。
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel_NewSpare, GetType(), "aa", "alert('该备件已选，不能重复选择!')", true);
                    return;
                }
                else
                {
                    equipUpkeepPlanL.Insert_EquipUpkeepPlan_Spare(eFUS_ID,eUP_ID,eMSAUS_UseAmount);
                    Grid_spare.DataSource = equipUpkeepPlanL.Search_EquipUpkeepPlan_Sparedone("and e.EUP_ID = '" + Label_eupid.Text + "'");
                    Grid_spare.DataBind();
                    UpdatePanel_Look.Update();
                    UpdatePanel_NewSpare.Update();
                }
            }
        }
    }
    protected void BtnCancel_NewSpare_Click(object sender, EventArgs e)
    {
        if (Panel_NewSpare.Visible)
        {
            Panel_NewSpare.Visible = false;
        }
    }
    #endregion 选择备件

    #region 查看保养详情
    protected void look_close_Click(object sender, EventArgs e)
    {
        if (Panel_Look.Visible)
        {
            Panel_Look.Visible = false;
            UpdatePanel_Look.Update();
        }
    }
    #endregion 查看保养详情

    #region 保养开始确认
    protected void Button1_Click(object sender, EventArgs e)
    {
        Guid EUP_ID = new Guid(Label_eupid.Text.ToString());
        string EUP_ActPer = lookdealper.Text.ToString();
        string EUP_OutPContents = lookunplanned.Text.ToString();
        DateTime EUP_UStartT = Convert.ToDateTime(lookbegtime.Text.ToString());
        DateTime EUP_UEndT = EUP_UStartT;
        string EUP_Remarks = looknote.Text.ToString();
        string EUP_State = "保养开始";

        equipUpkeepPlanL.Update_EquipUpkeepPlan_JL(EUP_ID, EUP_ActPer, EUP_OutPContents, EUP_UStartT, EUP_UEndT, EUP_Remarks, EUP_State);
        BindGrid_EquipUpkeepPlan("and d.EUP_State='已生成'");
        Panel_Look.Visible = false;
        UpdatePanel_Look.Update();
        UpdatePanel_EquipUpkeepPlan.Update();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Panel_Look.Visible = false;
        UpdatePanel_Look.Update();
    }
    #endregion 保养开始确认

    //打印报表按钮
    protected void BtnPrint_Click(object sender, EventArgs e)
    {
        Response.Redirect("../EquipMgt/PrintEquipUpkeepPlan.aspx?" + "&EN_EquipName=" + TextBox3.Text + "&EI_No=" + TextBox9.Text + "&EUP_UpkeepPer=" + TextBox10.Text + "&startime=" + TextBox11.Text + "&endtime=" + TextBox20.Text);
    }
}