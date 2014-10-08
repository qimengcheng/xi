using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using RTXHelper;

public partial class EquipMgt_EMEquipUnusedApp : Page
{
    EquipUnusedAppL equipUnusedAppL = new EquipUnusedAppL();
    //EquipmentInfL equipmentInfL = new EquipmentInfL();
    EquipTypeL equipTypeL = new EquipTypeL();
    User us = new User();

    #region 页面权限控制
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DropDownList1.Items.Insert(0, new ListItem("请选择", ""));
            BindDropDownList1();
            Panel_Search.Visible = true;
            UpdatePanel_Search.Update();
            //string condition = "";
            //BindGrid_UnusedApp(condition);
            try
            {
                if (Request.QueryString["status"].ToString() != "")
                {
                    Lab_Status.Text = Request.QueryString["status"].ToString();
                }
                if (Lab_Status.Text == "EMApp" && Session["UserRole"].ToString().Contains("设备报废申请"))
                {
                    Title = "设备报废申请";
                    Grid_UnusedApp.Columns[12].Visible = false;//审批人
                    Grid_UnusedApp.Columns[13].Visible = false;//审批时间
                    Grid_UnusedApp.Columns[15].Visible = false;//审批结果
                    Grid_UnusedApp.Columns[16].Visible = false;//报废处理人
                    Grid_UnusedApp.Columns[17].Visible = false;//报废处理时间
                    Grid_UnusedApp.Columns[18].Visible = true;//查看详情
                    Grid_UnusedApp.Columns[19].Visible = true;//编辑
                    Grid_UnusedApp.Columns[20].Visible = false;//审批
                    Grid_UnusedApp.Columns[21].Visible = false;//报废处理
                    Grid_UnusedApp.Columns[22].Visible = true;//删除
                    Grid_UnusedApp.Columns[23].Visible = false;//批准
                    Btn_New.Visible = true;
                    DropDownList2.Enabled = true;
                    DropDownList2.Items.FindByValue("已提交").Enabled = false;
                    DropDownList2.Items.FindByValue("审批通过").Enabled = false;
                    DropDownList2.Items.FindByValue("已完成").Enabled = false;
                    DropDownList2.Items.FindByValue("总经理批准").Enabled = false;
                    //this.TextApprover.Enabled = true;
                    //this.TextApprovalT.Enabled = true;
                    //this.DropDownList3.Enabled = true;
                    //this.DropDownList3.Items.FindByValue("通过").Enabled = false;
                    //this.TextDealPer.Enabled = false;
                    //this.TextDealTime.Enabled = false;
                    Panel7.Visible = true;
                    DropDownList3.Items.FindByValue("通过").Enabled = false;
                    Panel11.Visible = false;
                    //string condition = "and (a.EUA_AppState='待提交' or a.EUA_AppState='审批驳回')";
                    //BindGrid_UnusedApp(condition);
                    BindGrid_UnusedApp("");
                }
                if (Lab_Status.Text == "EMApproval" && Session["UserRole"].ToString().Contains("设备报废审批"))
                {
                    Title = "设备报废审批";
                    Grid_UnusedApp.Columns[12].Visible = false;
                    Grid_UnusedApp.Columns[13].Visible = false;
                    Grid_UnusedApp.Columns[15].Visible = false;
                    Grid_UnusedApp.Columns[16].Visible = false;
                    Grid_UnusedApp.Columns[17].Visible = false;
                    Grid_UnusedApp.Columns[18].Visible = false;
                    Grid_UnusedApp.Columns[19].Visible = false;
                    Grid_UnusedApp.Columns[20].Visible = true;
                    Grid_UnusedApp.Columns[21].Visible = false;
                    Grid_UnusedApp.Columns[22].Visible = false;
                    Grid_UnusedApp.Columns[23].Visible = false;//批准
                    Btn_New.Visible = false;
                    DropDownList2.Enabled = true;
                    DropDownList2.Items.FindByValue("待提交").Enabled = false;
                    DropDownList2.Items.FindByValue("审批通过").Enabled = false;
                    DropDownList2.Items.FindByValue("审批驳回").Enabled = false;
                    DropDownList2.Items.FindByValue("已完成").Enabled = false;
                    DropDownList2.Items.FindByValue("总经理批准").Enabled = false;
                    DropDownList2.Items.FindByValue("总经理驳回").Enabled = false;
                    DropDownList2.Items.FindByValue("总经理批准").Enabled = false;
                    //this.TextApprover.Enabled = false;
                    //this.TextApprovalT.Enabled = false;
                    //this.DropDownList3.Enabled = false;
                    //this.TextDealPer.Enabled = false;
                    //this.TextDealTime.Enabled = false;
                    Panel7.Visible = false;
                    Panel11.Visible = false;
                    string condition = "and a.EUA_AppState='已提交'";
                    BindGrid_UnusedApp(condition);
                }
                if (Lab_Status.Text == "EMDeal" && Session["UserRole"].ToString().Contains("设备报废处理"))
                {
                    Title = "设备报废处理";
                    Grid_UnusedApp.Columns[12].Visible = true;
                    Grid_UnusedApp.Columns[13].Visible = true;
                    Grid_UnusedApp.Columns[15].Visible = true;
                    Grid_UnusedApp.Columns[16].Visible = false;
                    Grid_UnusedApp.Columns[17].Visible = false;
                    Grid_UnusedApp.Columns[18].Visible = false;
                    Grid_UnusedApp.Columns[19].Visible = false;
                    Grid_UnusedApp.Columns[20].Visible = false;
                    Grid_UnusedApp.Columns[21].Visible = true;
                    Grid_UnusedApp.Columns[22].Visible = false;
                    Grid_UnusedApp.Columns[23].Visible = false;//批准
                    Btn_New.Visible = false;
                    DropDownList2.Enabled = true;
                    DropDownList2.Items.FindByValue("已提交").Enabled = false;
                    DropDownList2.Items.FindByValue("待提交").Enabled = false;
                    DropDownList2.Items.FindByValue("审批驳回").Enabled = false;
                    DropDownList2.Items.FindByValue("已完成").Enabled = false;
                    DropDownList2.Items.FindByValue("总经理驳回").Enabled = false;
                    //this.TextApprover.Enabled = true;
                    //this.TextApprovalT.Enabled = true;
                    //this.DropDownList3.Enabled = true;
                    //this.DropDownList3.Items.FindByValue("不通过").Enabled = false;
                    //this.TextDealPer.Enabled = false;
                    //this.TextDealTime.Enabled = false;
                    Panel7.Visible = true;
                    DropDownList3.Items.FindByValue("不通过").Enabled = false;
                    Panel11.Visible = false;
                    string condition = "and a.EUA_AppState='总经理批准'";
                    BindGrid_UnusedApp(condition);
                }
                if (Lab_Status.Text == "EMLook" && Session["UserRole"].ToString().Contains("设备报废情况查看"))
                {
                    Title = "设备报废情况查看";
                    Grid_UnusedApp.Columns[12].Visible = true;
                    Grid_UnusedApp.Columns[13].Visible = true;
                    Grid_UnusedApp.Columns[15].Visible = true;
                    Grid_UnusedApp.Columns[16].Visible = true;
                    Grid_UnusedApp.Columns[17].Visible = true;
                    Grid_UnusedApp.Columns[18].Visible = true;
                    Grid_UnusedApp.Columns[19].Visible = false;
                    Grid_UnusedApp.Columns[20].Visible = false;
                    Grid_UnusedApp.Columns[21].Visible = false;
                    Grid_UnusedApp.Columns[22].Visible = false;
                    Grid_UnusedApp.Columns[23].Visible = false;//批准
                    Btn_New.Visible = false;
                    //this.DropDownList2.Enabled = true;
                    //this.TextApprover.Enabled = true;
                    //this.TextApprovalT.Enabled = true;
                    //this.DropDownList3.Enabled = true;
                    //this.TextDealPer.Enabled = true;
                    //this.TextDealTime.Enabled = true;
                    string condition = "";
                    BindGrid_UnusedApp(condition);
                }
                if (Lab_Status.Text == "EMAllow" && Session["UserRole"].ToString().Contains("设备报废批准"))
                {
                    Title = "设备报废批准";
                    Grid_UnusedApp.Columns[12].Visible = false;
                    Grid_UnusedApp.Columns[13].Visible = false;
                    Grid_UnusedApp.Columns[15].Visible = false;
                    Grid_UnusedApp.Columns[16].Visible = false;
                    Grid_UnusedApp.Columns[17].Visible = false;
                    Grid_UnusedApp.Columns[18].Visible = false;
                    Grid_UnusedApp.Columns[19].Visible = false;
                    Grid_UnusedApp.Columns[20].Visible = false;
                    Grid_UnusedApp.Columns[21].Visible = false;
                    Grid_UnusedApp.Columns[22].Visible = false;
                    Grid_UnusedApp.Columns[23].Visible = true;//批准
                    Btn_New.Visible = false;
                    DropDownList2.Enabled = true;
                    DropDownList2.Items.FindByValue("待提交").Enabled = false;
                    DropDownList2.Items.FindByValue("审批通过").Enabled = false;
                    DropDownList2.Items.FindByValue("审批驳回").Enabled = false;
                    DropDownList2.Items.FindByValue("已完成").Enabled = false;
                    DropDownList2.Items.FindByValue("总经理驳回").Enabled = false;
                    DropDownList2.Items.FindByValue("总经理批准").Enabled = false;
                    Panel7.Visible = true;
                    Panel11.Visible = false;
                    string condition = "and a.EUA_AppState='审批通过'";
                    BindGrid_UnusedApp(condition);
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
    //绑定设备报废信息gridview
    private void BindGrid_UnusedApp(string condition)
    {
        Grid_UnusedApp.DataSource = equipUnusedAppL.Search_EquipUnusedApp(condition);
        Grid_UnusedApp.DataBind();
    }
    //DropDownList1下拉表绑定
    private void BindDropDownList1()
    {
        DropDownList1.DataSource = equipTypeL.Search_EquipTypeTableInfo("");
        DropDownList1.DataTextField = "ETT_Type";
        DropDownList1.DataValueField = "ETT_Type";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, new ListItem("请选择", ""));
    }
    //绑定设备台账gridview
    private void BindGrid_EquipInfo(string ETT_Type, string EN_EquipName, string EMT_Type, string EI_No)
    {
        Grid_EquipInfo.DataSource = equipUnusedAppL.Search_InsertEquipUnusedApp(ETT_Type, EN_EquipName, EMT_Type, EI_No);
        Grid_EquipInfo.DataBind();
    }
    //DropDownList4下拉表绑定
    private void BindDropDownList4()
    {
        DropDownList4.DataSource = equipTypeL.Search_EquipTypeTableInfo("");
        DropDownList4.DataTextField = "ETT_Type";
        DropDownList4.DataValueField = "ETT_Type";
        DropDownList4.DataBind();
        DropDownList4.Items.Insert(0, new ListItem("请选择", ""));
    }
    //DropDownList5下拉表绑定
    //private void BindDropDownList5()
    //{
    //    this.DropDownList5.DataSource = equipTypeL.Search_EquipTypeTableInfo("");
    //    this.DropDownList5.DataTextField = "ETT_Type";
    //    this.DropDownList5.DataValueField = "ETT_Type";
    //    this.DropDownList5.DataBind();
    //    this.DropDownList5.Items.Insert(0, new ListItem("请选择", ""));
    //}
    #endregion 绑定

    #region 检索设备报废信息
    //检索设备台账
    protected void Btn_Search_Click(object sender, EventArgs e)
    {
        string condition = GetCondition();
        BindGrid_UnusedApp(condition);
        Panel_UnusedApp.Visible = true;
        UpdatePanel_UnusedApp.Update();
        UpdatePanel_Search.Update();
        Panel_searchInf.Visible = false;
        //this.UpdatePanel_searchInf.Update();
        Panel_New.Visible = false;
        UpdatePanel_New.Update();
        Panel_Look.Visible = false;
        UpdatePanel_Look.Update();
    }
    protected string GetCondition()
    {
        string condition;
        string temp = "";
        if (DropDownList1.Text.ToString() != "")
        {
            temp += " and ETT_Type='" + DropDownList1.SelectedValue.ToString() + "'";
        }
        if (Textname.Text.ToString() != "")
        {
            temp += " and EN_EquipName like '%" + Textname.Text.ToString() + "%'";
        }
        if (Textmodel.Text.ToString() != "")
        {
            temp += " and  EMT_Type like '%" + Textmodel.Text.ToString() + "%'";
        }
        if (Textno.Text.ToString() != "")
        {
            temp += " and  EI_No like '%" + Textno.Text.ToString() + "%'";
        }
        if (TextUseYear.Text.ToString() != "")
        {
            temp += " and  EUA_UseYear='" + TextUseYear.Text.ToString() + "'";
        }
        if (TextAppNO.Text.ToString() != "")
        {
            temp += " and  EUA_AppNO like '%" + TextAppNO.Text.ToString() + "%'";
        }
        if (TextAppPer.Text.ToString() != "")
        {
            temp += " and  EUA_AppPer like '%" + TextAppPer.Text.ToString() + "%'";
        }
        if (TextAppTime.Text.ToString() != "")
        {
            //temp += " and  EUA_AppTime = '" + this.TextAppTime.Text.ToString() + "'";
            temp += "and DateDiff(dd,getdate(),EUA_AppTime)=DateDiff(dd,getdate(),'" + TextAppTime.Text.ToString() + "')";
        }
        if (DropDownList2.Text.ToString() != "")
        {
            temp += " and EUA_AppState='" + DropDownList2.SelectedValue.ToString() + "'";
        }
        if (TextApprover.Text.ToString() != "")
        {
            temp += " and  (EUA_Approver like '%" + TextApprover.Text.ToString() + "%' or EUA_Approver2 like '%" + TextApprover.Text.ToString() + "%')";
        }
        if (TextApprovalT.Text.ToString() != "")
        {
            //temp += " and  EUA_ApprovalT like '%" + this.TextApprovalT.Text.ToString() + "%'";
            temp += "and (DateDiff(dd,getdate(),EUA_ApprovalT)=DateDiff(dd,getdate(),'" + TextApprovalT.Text.ToString() + "') or DateDiff(dd,getdate(),EUA_ApprovalT2)=DateDiff(dd,getdate(),'" + TextApprovalT.Text.ToString() + "'))";
        }
        if (DropDownList3.Text.ToString() != "")
        {
            temp += " and (EUA_ApprovalRes='" + DropDownList3.SelectedValue.ToString() + "' or EUA_ApprovalRes2='" + DropDownList3.SelectedValue.ToString() + "')";
        }
        if (TextDealPer.Text.ToString() != "")
        {
            temp += " and  EUA_DealPer like '%" + TextDealPer.Text.ToString() + "%'";
        }
        if (TextDealTime.Text.ToString() != "")
        {
            //temp += " and  EUA_DealTime = '" + this.TextDealTime.Text.ToString() + "'";
            temp += "and DateDiff(dd,getdate(),EUA_DealTime)=DateDiff(dd,getdate(),'" + TextDealTime.Text.ToString() + "')";
        }
        if (TextAllowT.Text.ToString() != "")
        {
            temp += "and DateDiff(dd,getdate(),EUA_AllowT)=DateDiff(dd,getdate(),'" + TextAllowT.Text.ToString() + "')";
        }
        if (Lab_Status.Text == "EMApp" && Session["UserRole"].ToString().Contains("设备报废申请"))
        {
            //temp += " and (a.EUA_AppState='待提交' or a.EUA_AppState='审批驳回')";
            temp += "";
        }
        if (Lab_Status.Text == "EMApproval" && Session["UserRole"].ToString().Contains("设备报废审批"))
        {
            temp += " and a.EUA_AppState ='已提交'";
        }
        if (Lab_Status.Text == "EMAllow" && Session["UserRole"].ToString().Contains("设备报废批准"))
        {
            temp += " and a.EUA_AppState ='审批通过'";
        }
        if (Lab_Status.Text == "EMDeal" && Session["UserRole"].ToString().Contains("设备报废处理"))
        {
            temp += " and a.EUA_AppState ='总经理批准'";
        }
        if (Lab_Status.Text == "EMLook" && Session["UserRole"].ToString().Contains("设备报废情况查看"))
        {
            temp += "";
        }
        condition = temp;
        return condition;
    }
    protected void Btn_Clear_Click(object sender, EventArgs e)
    {
        DropDownList1.Items.Insert(0, new ListItem("请选择", ""));
        BindDropDownList1();
        Textname.Text = "";
        Textmodel.Text = "";
        Textno.Text = "";
        TextUseYear.Text = "";
        TextAppNO.Text = "";
        TextAppPer.Text = "";
        TextAppTime.Text = "";
        DropDownList2.SelectedIndex = 0;
        TextApprover.Text = "";
        TextApprovalT.Text = "";
        DropDownList3.SelectedIndex = 0;
        TextDealPer.Text = "";
        TextDealTime.Text = "";
        UpdatePanel_Search.Update();
        string condition = GetCondition1();
        BindGrid_UnusedApp(condition);
        UpdatePanel_UnusedApp.Update();
        Panel_searchInf.Visible = false;
        Panel_New.Visible = false;
        UpdatePanel_New.Update();
        Panel_Look.Visible = false;
        UpdatePanel_Look.Update();
    }
    protected string GetCondition1()
    {
        string condition;
        string temp = "";
        if (Lab_Status.Text == "EMApp" && Session["UserRole"].ToString().Contains("设备报废申请"))
        {
            //temp += " and (a.EUA_AppState='待提交' or a.EUA_AppState='审批驳回')";
            temp += "";
        }
        if (Lab_Status.Text == "EMApproval" && Session["UserRole"].ToString().Contains("设备报废审批"))
        {
            temp += " and a.EUA_AppState ='已提交'";
        }
        if (Lab_Status.Text == "EMAllow" && Session["UserRole"].ToString().Contains("设备报废批准"))
        {
            temp += " and a.EUA_AppState ='审批通过'";
        }
        if (Lab_Status.Text == "EMDeal" && Session["UserRole"].ToString().Contains("设备报废处理"))
        {
            temp += " and a.EUA_AppState ='审批通过'";
        }
        if (Lab_Status.Text == "EMLook" && Session["UserRole"].ToString().Contains("设备报废情况查看"))
        {
            temp += "";
        }
        condition = temp;
        return condition;
    }
    protected void Btn_New_Click(object sender, EventArgs e)
    {
        Clear();
        Panel_searchInf.Visible = true;
        //this.UpdatePanel_searchInf.Update();
        DropDownList4.Items.Insert(0, new ListItem("请选择", ""));
        BindDropDownList4();
        string ETT_Type = "";
        string EN_EquipName = "";
        string EMT_Type = "";
        string EI_No = "";
        BindGrid_EquipInfo(ETT_Type, EN_EquipName, EMT_Type, EI_No);
        Panel_New.Visible = false;
        UpdatePanel_New.Update();
        Panel_Look.Visible = false;
        UpdatePanel_Look.Update();
    }
    //私有清空的方法
    private void Clear()
    {
        DropDownList4.Items.Insert(0, new ListItem("请选择", ""));
        BindDropDownList4();
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        Textaddyear.Text = "";
        Textaddappno.Text = "";
        Textaddperson.Text = "";
        Textaddres.Text = "";
    }
    #endregion 检索设备报废信息

    #region 设备报废信息gridview
    protected void Grid_UnusedApp_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Look1")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_UnusedApp.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string ETT_Type = al[0];
            Textlooktype.Text = ETT_Type;
            string EN_EquipName = al[1];
            Textlookname.Text = EN_EquipName;
            string EMT_Type = al[2];
            Textlookmodel.Text = EMT_Type;
            string EI_No = al[3];
            Textlookno.Text = EI_No;
            short EUA_UseYear = Convert.ToInt16(al[4].ToString());
            Textlookyear.Text = EUA_UseYear.ToString();
            string EUA_AppPer = al[5];
            Textlookper.Text = EUA_AppPer;
            DateTime EUA_AppTime = Convert.ToDateTime(al[6].ToString());
            Textlooktime.Text = EUA_AppTime.ToString("yyyy-MM-dd HH:mm:ss");
            string EUA_Reason = al[7];
            Textlookres.Text = EUA_Reason;
            string EUA_AppNO = al[8];
            Textlookappno.Text = EUA_AppNO;
            string EUA_AppState = al[9];
            Textlooksta.Text = EUA_AppState;
            string EUA_Approver = al[10];
            Textlookapper.Text = EUA_Approver;
            if (al[11].ToString() == "")
            {
                Textlookapptime.Text = "";
            }
            else
            {
                DateTime EUA_ApprovalT = Convert.ToDateTime(al[11].ToString());
                Textlookapptime.Text = EUA_ApprovalT.ToString("yyyy-MM-dd HH:mm:ss");
            }
            string EUA_ApprovalSugg = al[12];
            Textlookappsug.Text = EUA_ApprovalSugg;
            string EUA_ApprovalRes = al[13];
            Textlookappre.Text = EUA_ApprovalRes;
            string EUA_DealPer = al[14];
            Textlookdealper.Text = EUA_DealPer;
            if (al[15].ToString() == "")
            {
                Textlookdealtime.Text = "";
            }
            else
            {
                DateTime EUA_DealTime = Convert.ToDateTime(al[15].ToString());
                Textlookdealtime.Text = EUA_DealTime.ToString("yyyy-MM-dd HH:mm:ss");
            }
            string EUA_Approver2 = al[16];
            TextBox1.Text = EUA_Approver2;
            if (al[17].ToString() == "")
            {
                TextBox5.Text = "";
            }
            else
            {
                DateTime EUA_ApprovalT2 = Convert.ToDateTime(al[17].ToString());
                TextBox5.Text = EUA_ApprovalT2.ToString("yyyy-MM-dd HH:mm:ss");
            }
            string EUA_ApprovalSugg2 = al[18];
            TextBox7.Text = EUA_ApprovalSugg2;
            string EUA_ApprovalRes2 = al[19];
            TextBox6.Text = EUA_ApprovalRes2;
            string EUA_Allower = al[20];
            TextBox8.Text = EUA_Allower;

            if (al[21].ToString() == "")
            {
                TextBox9.Text = "";
            }
            else
            {
                DateTime EUA_AllowT = Convert.ToDateTime(al[21].ToString());
                TextBox9.Text = EUA_AllowT.ToString("yyyy-MM-dd HH:mm:ss");
            }
            string EUA_AllowSugg = al[22];
            TextBox11.Text = EUA_AllowSugg;
            string EUA_AllowRes = al[23];
            TextBox10.Text = EUA_AllowRes;

            Panel_Look.Visible = true;
            Panel1.Visible = true;
            Panel1.Enabled = false;
            Panel2.Visible = true;
            Panel2.Enabled = false;
            Panel3.Visible = true;
            Panel3.Enabled = false;
            Panel4.Visible = true;
            Panel5.Visible = false;
            Panel6.Visible = false;
            Panel13.Visible = true;
            TextBox11.Enabled = false;
            UpdatePanel_Look.Update();

            Panel_searchInf.Visible = false;
            Panel_New.Visible = false;
            UpdatePanel_New.Update();
            UpdatePanel_UnusedApp.Update();

        }
        if (e.CommandName == "Edit1")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_UnusedApp.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string EUA_ID = al[0];
            Label_euaid.Text = EUA_ID;
            string ETT_Type = al[1];
            //BindDropDownList5();
            //this.DropDownList5.Items.FindByText(ETT_Type.ToString().Trim()).Selected = true;
            Textaddtype.Text = ETT_Type;
            string EN_EquipName = al[2];
            Textaddname.Text = EN_EquipName;
            string EMT_Type = al[3];
            Textaddmodel.Text = EMT_Type;
            string EI_No = al[4];
            Textaddno.Text = EI_No;
            short EUA_UseYear = Convert.ToInt16(al[5].ToString());
            Textaddyear.Text = EUA_UseYear.ToString();
            string EUA_AppPer = al[6];
            Textaddperson.Text = EUA_AppPer;
            DateTime EUA_AppTime = Convert.ToDateTime(al[7].ToString());
            Textaddtime.Text = EUA_AppTime.ToString("yyyy-MM-dd HH:mm:ss");
            string EUA_Reason = al[8];
            Textaddres.Text = EUA_Reason;
            string EUA_AppNO = al[9];
            Textaddappno.Text = EUA_AppNO;
            string EUA_AppState = al[10];
            if (EUA_AppState != "待提交")
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel_UnusedApp, GetType(), "alert", "alert('此状态下不可编辑，请重提申请！')", true);
                return;
            }

            Panel_New.Visible = true;
            Label20.Visible = true;
            Textaddappno.Visible = true;
            Panel8.Visible = true;
            Panel9.Visible = false;
            Panel10.Visible = true;
            UpdatePanel_New.Update();
            Panel_searchInf.Visible = false;
            Panel_Look.Visible = false;
            UpdatePanel_Look.Update();
            UpdatePanel_UnusedApp.Update();
            UpdatePanel_New.Update();
        }
        if (e.CommandName == "Approval1")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_UnusedApp.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string EUA_ID = al[0];
            Label_euaid.Text = EUA_ID;
            string ETT_Type = al[1];
            Textlooktype.Text = ETT_Type;
            string EN_EquipName = al[2];
            Textlookname.Text = EN_EquipName;
            string EMT_Type = al[3];
            Textlookmodel.Text = EMT_Type;
            string EI_No = al[4];
            Textlookno.Text = EI_No;
            short EUA_UseYear = Convert.ToInt16(al[5].ToString());
            Textlookyear.Text = EUA_UseYear.ToString();
            string EUA_AppPer = al[6];
            Textlookper.Text = EUA_AppPer;
            DateTime EUA_AppTime = Convert.ToDateTime(al[7].ToString());
            Textlooktime.Text = EUA_AppTime.ToString("yyyy-MM-dd HH:mm:ss");
            string EUA_Reason = al[8];
            Textlookres.Text = EUA_Reason;
            string EUA_AppNO = al[9];
            Textlookappno.Text = EUA_AppNO;
            string EUA_AppState = al[10];
            Textlooksta.Text = EUA_AppState;

            string EUA_Approver = al[11];
            Textlookapper.Text = "技术副总";
            if (al[12] == "")
            {
                Textlookapptime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
            else
            { 
                DateTime EUA_ApprovalT = Convert.ToDateTime(al[12].ToString());
                Textlookapptime.Text = EUA_ApprovalT.ToString("yyyy-MM-dd HH:mm:ss");
            }
            string EUA_ApprovalSugg = al[13];
            Textlookappsug.Text = EUA_ApprovalSugg;
            string EUA_ApprovalRes = al[14];
            Textlookappre.Text = EUA_ApprovalRes;
            string EUA_Approver2 = al[15];
            TextBox1.Text = "财务部";
            if (al[16] == "")
            {
                TextBox5.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
            else
            {
                DateTime EUA_ApprovalT2 = Convert.ToDateTime(al[16].ToString());
                TextBox5.Text = EUA_ApprovalT2.ToString("yyyy-MM-dd HH:mm:ss");
            }
            string EUA_ApprovalSugg2 = al[17];
            TextBox7.Text = EUA_ApprovalSugg2;
            string EUA_ApprovalRes2 = al[18];
            TextBox6.Text = EUA_ApprovalRes2;
            //Textlookapptime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //Textlookapper.Text = Session["UserName"].ToString().Trim();
            Label57.Text = "";
            Label58.Text = "";

            Label777.Text = "审批";
            Panel_Look.Visible = true;
            Panel1.Visible = true;
            Panel1.Enabled = false;
            Panel2.Visible = true;
            Panel2.Enabled = true;
            Panel3.Visible = false;
            Panel3.Enabled = false;
            Panel4.Visible = false;
            Panel5.Visible = true;
            Panel6.Visible = false;
            UpdatePanel_Look.Update();
            //Label40.Visible = false;
            //Textlookappre.Visible = false;

            Panel_searchInf.Visible = false;
            Panel_New.Visible = false;
            UpdatePanel_New.Update();
            UpdatePanel_UnusedApp.Update();
        }
        if (e.CommandName == "Allow1")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_UnusedApp.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string EUA_ID = al[0];
            Label_euaid.Text = EUA_ID;
            string ETT_Type = al[1];
            Textlooktype.Text = ETT_Type;
            string EN_EquipName = al[2];
            Textlookname.Text = EN_EquipName;
            string EMT_Type = al[3];
            Textlookmodel.Text = EMT_Type;
            string EI_No = al[4];
            Textlookno.Text = EI_No;
            short EUA_UseYear = Convert.ToInt16(al[5].ToString());
            Textlookyear.Text = EUA_UseYear.ToString();
            string EUA_AppPer = al[6];
            Textlookper.Text = EUA_AppPer;
            DateTime EUA_AppTime = Convert.ToDateTime(al[7].ToString());
            Textlooktime.Text = EUA_AppTime.ToString("yyyy-MM-dd HH:mm:ss");
            string EUA_Reason = al[8];
            Textlookres.Text = EUA_Reason;
            string EUA_AppNO = al[9];
            Textlookappno.Text = EUA_AppNO;
            string EUA_AppState = al[10];
            Textlooksta.Text = EUA_AppState;

            string EUA_Approver = al[11];
            Textlookapper.Text = EUA_Approver;
            DateTime EUA_ApprovalT = Convert.ToDateTime(al[12].ToString());
            Textlookapptime.Text = EUA_ApprovalT.ToString("yyyy-MM-dd HH:mm:ss");
            string EUA_ApprovalSugg = al[13];
            Textlookappsug.Text = EUA_ApprovalSugg;
            string EUA_ApprovalRes = al[14];
            Textlookappre.Text = EUA_ApprovalRes;
            string EUA_Approver2 = al[15];
            TextBox1.Text = EUA_Approver2;
            DateTime EUA_ApprovalT2 = Convert.ToDateTime(al[16].ToString());
            TextBox5.Text = EUA_ApprovalT2.ToString("yyyy-MM-dd HH:mm:ss");
            string EUA_ApprovalSugg2 = al[17];
            TextBox7.Text = EUA_ApprovalSugg2;
            string EUA_ApprovalRes2 = al[18];
            TextBox6.Text = EUA_ApprovalRes2;
            TextBox8.Text = "总经理";

            Label777.Text = "批准";
            Panel_Look.Visible = true;
            Panel1.Visible = true;
            Panel1.Enabled = false;
            Panel2.Visible = true;
            Panel2.Enabled = true;
            Panel3.Visible = false;
            Panel3.Enabled = false;
            Panel4.Visible = false;
            Panel5.Visible = true;
            Panel6.Visible = false;
            Panel13.Visible = true;
            Textlookappsug.Enabled = false;
            TextBox7.Enabled = false;
            Label54.Visible = false;
            TextBox10.Visible = false;
            TextBox9.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            UpdatePanel_Look.Update();

            Panel_searchInf.Visible = false;
            Panel_New.Visible = false;
            UpdatePanel_New.Update();
            UpdatePanel_UnusedApp.Update();
        }
        if (e.CommandName == "Deal1")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_UnusedApp.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string EUA_ID = al[0];
            Label_euaid.Text = EUA_ID;
            string ETT_Type = al[1];
            Textlooktype.Text = ETT_Type;
            string EN_EquipName = al[2];
            Textlookname.Text = EN_EquipName;
            string EMT_Type = al[3];
            Textlookmodel.Text = EMT_Type;
            string EI_No = al[4];
            Textlookno.Text = EI_No;
            short EUA_UseYear = Convert.ToInt16(al[5].ToString());
            Textlookyear.Text = EUA_UseYear.ToString();
            string EUA_AppPer = al[6];
            Textlookper.Text = EUA_AppPer;
            DateTime EUA_AppTime = Convert.ToDateTime(al[7].ToString());
            Textlooktime.Text = EUA_AppTime.ToString("yyyy-MM-dd HH:mm:ss");
            string EUA_Reason = al[8];
            Textlookres.Text = EUA_Reason;
            string EUA_AppNO = al[9];
            Textlookappno.Text = EUA_AppNO;
            string EUA_AppState = al[10];
            Textlooksta.Text = EUA_AppState;
            string EUA_Approver = al[11];
            Textlookapper.Text = EUA_Approver;
            DateTime EUA_ApprovalT = Convert.ToDateTime(al[12].ToString());
            Textlookapptime.Text = EUA_ApprovalT.ToString("yyyy-MM-dd HH:mm:ss");
            string EUA_ApprovalSugg = al[13];
            Textlookappsug.Text = EUA_ApprovalSugg;
            string EUA_ApprovalRes = al[14];
            Textlookappre.Text = EUA_ApprovalRes;
            string EUA_Approver2 = al[15];
            TextBox1.Text = EUA_Approver;
            DateTime EUA_ApprovalT2 = Convert.ToDateTime(al[16].ToString());
            TextBox5.Text = EUA_ApprovalT2.ToString("yyyy-MM-dd HH:mm:ss");
            string EUA_ApprovalSugg2 = al[17];
            TextBox7.Text = EUA_ApprovalSugg2;
            string EUA_ApprovalRes2 = al[18];
            TextBox6.Text = EUA_ApprovalRes2;
            string EUA_Allower = al[19];
            TextBox8.Text = EUA_Allower;
            DateTime EUA_AllowT = Convert.ToDateTime(al[20].ToString());
            TextBox9.Text = EUA_AllowT.ToString("yyyy-MM-dd HH:mm:ss");
            string EUA_AllowSugg = al[21];
            TextBox11.Text = EUA_AllowSugg;
            string EUA_AllowRes = al[22];
            TextBox10.Text = EUA_AllowRes;

            Textlookdealtime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Textlookdealper.Text = Session["UserName"].ToString().Trim();

            Panel_Look.Visible = true;
            Panel1.Visible = true;
            Panel1.Enabled = false;
            Panel2.Visible = true;
            Panel2.Enabled = false;
            Panel3.Visible = true;
            Panel3.Enabled = true;
            Panel4.Visible = false;
            Panel5.Visible = false;
            Panel6.Visible = true;
            Panel13.Visible = true;
            TextBox11.Enabled = false;
            UpdatePanel_Look.Update();

            Panel_searchInf.Visible = false;
            Panel_New.Visible = false;
            UpdatePanel_New.Update();
            UpdatePanel_UnusedApp.Update();
        }
        if (e.CommandName == "Delete1")
        {
            Panel_searchInf.Visible = false;
            Panel_New.Visible = false;
            UpdatePanel_New.Update();
            Panel_Look.Visible = false;
            UpdatePanel_Look.Update();
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_UnusedApp.SelectedIndex = row.RowIndex;

            //Guid EUA_ID = new Guid(Convert.ToString(e.CommandArgument));
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            Guid EUA_ID = new Guid(al[0]);
            if (al[1] != "待提交")
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel_UnusedApp, GetType(), "alert", "alert('此状态下不可删除！')", true);
                return;
            }
            equipUnusedAppL.Delete_EquipUnusedApp(EUA_ID);
            //string condition = "and (a.EUA_AppState='待提交' or a.EUA_AppState='审批驳回')";
            //BindGrid_UnusedApp(condition);
            BindGrid_UnusedApp("");
            UpdatePanel_UnusedApp.Update();
        }
    }

    //Gridview翻页
    protected void Grid_UnusedApp_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_UnusedApp.BottomPagerRow;


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
        BindGrid_UnusedApp(condition);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_UnusedApp.PageCount ? Grid_UnusedApp.PageCount - 1 : newPageIndex;
        Grid_UnusedApp.PageIndex = newPageIndex;
        Grid_UnusedApp.DataBind();
    }
    protected void Grid_UnusedApp_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
    #endregion 设备报废信息gridview

    #region 增加报废申请时，检索已有的设备
    protected void Search_info_Click(object sender, EventArgs e)
    {
        string ETT_Type = DropDownList4.SelectedValue.ToString();
        string EN_EquipName = TextBox2.Text.ToString();
        string EMT_Type = TextBox3.Text.ToString();
        string EI_No = TextBox4.Text.ToString();
        BindGrid_EquipInfo(ETT_Type, EN_EquipName, EMT_Type, EI_No);
        Panel_New.Visible = false;
        UpdatePanel_New.Update();
        Panel_Look.Visible = false;
        UpdatePanel_Look.Update();
    }
    protected void Clear_info_Click(object sender, EventArgs e)
    {
        DropDownList4.Items.Insert(0, new ListItem("", ""));
        BindDropDownList4();
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        string ETT_Type = "";
        string EN_EquipName = "";
        string EMT_Type = "";
        string EI_No = "";
        BindGrid_EquipInfo(ETT_Type, EN_EquipName, EMT_Type, EI_No);
        Panel_New.Visible = false;
        UpdatePanel_New.Update();
        Panel_Look.Visible = false;
        UpdatePanel_Look.Update();
    }
    protected void Close_info_Click(object sender, EventArgs e)
    {
        Panel_searchInf.Visible = false;
        Panel_New.Visible = false;
        UpdatePanel_New.Update();
        Panel_Look.Visible = false;
        UpdatePanel_Look.Update();
    }
    #endregion 增加报废申请时，检索已有的设备

    #region 增加报废申请时，台账gridview
    protected void Grid_EquipInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Panel_Look.Visible = false;
        UpdatePanel_Look.Update();
        if (e.CommandName == "Add_UnusedApp")//点击增加设备台账报废
        {
            Clear();
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_EquipInfo.SelectedIndex = row.RowIndex;
            //this.Label_enid.Text = Convert.ToString(e.CommandArgument);
            //string eN_ID = e.CommandArgument.ToString(); 
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string EI_ID = al[0];
            string ETT_Type = al[1];
            string EN_EquipName = al[2];
            string EMT_Type = al[3];
            string EI_No = al[4];
            if (al[5] == "")
            {
                Textaddtime.Text = "";
                Textaddyear.Text = "";
            }
            else
            { 
                DateTime EI_AcceptDate = Convert.ToDateTime(al[5]);
                //自动计算使用年限
                DateTime dt1 = EI_AcceptDate;
                DateTime dt2 = DateTime.Today;
                Textaddyear.Text = Convert.ToString(dt2.Year - dt1.Year);
            }
            

            Label_eiid.Text = EI_ID;
            Label_type.Text = ETT_Type;
            Label_name.Text = EN_EquipName;
            Label_no.Text = EI_No;
            Label_model.Text = EMT_Type;

            //BindDropDownList5();
            //this.DropDownList5.Items.FindByText(ETT_Type.ToString().Trim()).Selected = true;
            Textaddtime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Textaddtype.Text = Label_type.Text;
            Textaddname.Text = Label_name.Text;
            Textaddmodel.Text = Label_model.Text;
            Textaddno.Text = Label_no.Text;
            
            Textaddperson.Text = Session["UserName"].ToString().Trim();
            

            Panel_New.Visible = true;
            Label20.Visible = false;
            Textaddappno.Visible = false;
            Panel8.Visible = true;
            Panel9.Visible = true;
            Panel10.Visible = false;
            UpdatePanel_New.Update();
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
        string ETT_Type = DropDownList4.SelectedValue.ToString();
        string EN_EquipName = TextBox2.Text.ToString();
        string EMT_Type = TextBox3.Text.ToString();
        string EI_No = TextBox4.Text.ToString();
        BindGrid_EquipInfo(ETT_Type, EN_EquipName, EMT_Type, EI_No);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_EquipInfo.PageCount ? Grid_EquipInfo.PageCount - 1 : newPageIndex;
        Grid_EquipInfo.PageIndex = newPageIndex;
        Grid_EquipInfo.DataBind();
    }
    protected void Grid_EquipInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
    #endregion 增加报废申请时，台账gridview

    #region 增加报废申请
    protected void Btn_Save_Click(object sender, EventArgs e)
    {
        if (Textaddres.Text.ToString() == "" || Textaddyear.Text=="")
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_New, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        Guid eI_ID = new Guid(Label_eiid.Text.ToString());
        //if (this.Textaddyear.Text.ToString() == "")
        //{
        //    this.Textaddyear.Text = "0";
        //}
        short m3;
        if (!(Int16.TryParse(Textaddyear.Text, out m3)))
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_New, GetType(), "alert", "alert('使用年限必须为整数！')", true);
            return;
        }
        short eUA_UseYear = m3;
        //short eUA_UseYear = Convert.ToInt16(this.Textaddyear.Text.ToString());
        string eUA_AppPer = Textaddperson.Text.ToString();
        DateTime eUA_AppTime = Convert.ToDateTime(Textaddtime.Text.ToString());
        string eUA_Reason = Textaddres.Text.ToString();
        //string eUA_AppNO = this.Textaddappno.Text.ToString();
        string eUA_AppState = "待提交";
        //DataSet ds = equipUnusedAppL.Search_EquipUnusedApp("and b.EI_No = '" + this.Textaddno.Text.ToString() + "'");
        //DataTable dt = ds.Tables[0];
        //if (dt.Rows.Count != 0)
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('该设备已有申请报废，不能重复申请！')", true);
        //    return;
        //}
        equipUnusedAppL.Insert_EquipUnusedApp(eI_ID, eUA_UseYear, eUA_AppPer, eUA_AppTime, eUA_Reason, eUA_AppState);
        //string condition = "and (a.EUA_AppState='待提交' or a.EUA_AppState='审批驳回')";
        //BindGrid_UnusedApp(condition);
        BindGrid_UnusedApp("");
        Panel_New.Visible = false;
        Panel_searchInf.Visible = false;
        UpdatePanel_UnusedApp.Update();
    }
    protected void Btn_Submit_Click(object sender, EventArgs e)
    {
        if (Textaddres.Text.ToString() == "" || Textaddyear.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_New, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        Guid eI_ID = new Guid(Label_eiid.Text.ToString());
        //if (this.Textaddyear.Text.ToString() == "")
        //{
        //    this.Textaddyear.Text = "0";
        //} 
        short m4;
        if (!(Int16.TryParse(Textaddyear.Text, out m4)))
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_New, GetType(), "alert", "alert('使用年限必须为整数！')", true);
            return;

        }
        short eUA_UseYear = m4;
        //short eUA_UseYear = Convert.ToInt16(this.Textaddyear.Text.ToString());
        string eUA_AppPer = Textaddperson.Text.ToString();
        DateTime eUA_AppTime = Convert.ToDateTime(Textaddtime.Text.ToString());
        string eUA_Reason = Textaddres.Text.ToString();
        //string eUA_AppNO = this.Textaddappno.Text.ToString();
        string eUA_AppState = "已提交";
        //if (this.Textaddappno.Text.ToString() == "")
        //{
        //    ScriptManager.RegisterClientScriptBlock(this.UpdatePanel_New, this.GetType(), "alert", "alert('请填写申请单编号！')", true);
        //    return;
        //}
        equipUnusedAppL.Insert_EquipUnusedApp(eI_ID, eUA_UseYear, eUA_AppPer, eUA_AppTime, eUA_Reason, eUA_AppState);
        //string condition = "and (a.EUA_AppState='待提交' or a.EUA_AppState='审批驳回')";
        //BindGrid_UnusedApp(condition);
        BindGrid_UnusedApp("");
        Panel_New.Visible = false;
        Panel_searchInf.Visible = false;
        UpdatePanel_UnusedApp.Update();
        //RTX
        string message = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "提交了设备编号为" + Textaddno.Text + "的报废申请，请审批。";
        string sErr = RTXhelper.Send(message, "设备报废审批");
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('" + sErr + "')", true);
        }

    }
    protected void Btn_Cancel_Click(object sender, EventArgs e)
    {
        if (Panel_New.Visible)
        {
            Panel_New.Visible = false;
        }
    }
    #endregion 增加报废申请

    #region 修改报废申请
    protected void Btn_Save_Click1(object sender, EventArgs e)
    {
        if (Textaddres.Text.ToString() == "" || Textaddyear.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_New, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        Guid eUA_ID = new Guid(Label_euaid.Text.ToString());
        //if (this.Textaddyear.Text.ToString() == "")
        //{
        //    this.Textaddyear.Text = "0";
        //}
        short m1;
        if (!(Int16.TryParse(Textaddyear.Text, out m1)))
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_New, GetType(), "alert", "alert('使用年限必须为整数！')", true);
            return;
        }
        short eUA_UseYear = m1;
        //short eUA_UseYear = Convert.ToInt16(this.Textaddyear.Text.ToString());
        string eUA_AppPer = Textaddperson.Text.ToString();
        DateTime eUA_AppTime = Convert.ToDateTime(Textaddtime.Text.ToString());
        string eUA_Reason = Textaddres.Text.ToString();
        string eUA_AppNO = Textaddappno.Text.ToString();
        string eUA_AppState = "待提交";

        //if (this.Textaddappno.Text.ToString() == "")
        //{
        //    ScriptManager.RegisterClientScriptBlock(this.UpdatePanel_New, this.GetType(), "alert", "alert('请填写申请单编号！')", true);
        //    return;
        //}
        equipUnusedAppL.Update_EquipUnusedApp_SQ(eUA_ID, eUA_UseYear, eUA_AppPer, eUA_AppTime, eUA_Reason, eUA_AppNO, eUA_AppState);
        //string condition = "and (a.EUA_AppState='待提交' or a.EUA_AppState='审批驳回')";
        //BindGrid_UnusedApp(condition);
        BindGrid_UnusedApp("");
        Panel_New.Visible = false;
        Panel_searchInf.Visible = false;
        UpdatePanel_UnusedApp.Update();
    }
    protected void Btn_Submit_Click1(object sender, EventArgs e)
    {
        if (Textaddres.Text.ToString() == "" || Textaddyear.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_New, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        Guid eUA_ID = new Guid(Label_euaid.Text.ToString());
        //if (this.Textaddyear.Text.ToString() == "")
        //{
        //    this.Textaddyear.Text = "0";
        //}
        short m2;
        if (!(Int16.TryParse(Textaddyear.Text, out m2)))
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_New, GetType(), "alert", "alert('使用年限必须为整数！')", true);
            return;

        }
        short eUA_UseYear = m2;
        //short eUA_UseYear = Convert.ToInt16(this.Textaddyear.Text.ToString());
        string eUA_AppPer = Textaddperson.Text.ToString();
        DateTime eUA_AppTime = Convert.ToDateTime(Textaddtime.Text.ToString());
        string eUA_Reason = Textaddres.Text.ToString();
        string eUA_AppNO = Textaddappno.Text.ToString();
        string eUA_AppState = "已提交";
        //if (this.Textaddappno.Text.ToString() == "")
        //{
        //    ScriptManager.RegisterClientScriptBlock(this.UpdatePanel_New, this.GetType(), "alert", "alert('请填写申请单编号！')", true);
        //    return;
        //}
        equipUnusedAppL.Update_EquipUnusedApp_SQ(eUA_ID, eUA_UseYear, eUA_AppPer, eUA_AppTime, eUA_Reason, eUA_AppNO, eUA_AppState);
        //string condition = "and (a.EUA_AppState='待提交' or a.EUA_AppState='审批驳回')";
        //BindGrid_UnusedApp(condition);
        BindGrid_UnusedApp("");
        Panel_New.Visible = false;
        Panel_searchInf.Visible = false;
        UpdatePanel_UnusedApp.Update();
        //RTX
        string message = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "提交了设备编号为" + Textaddno.Text + "的报废申请，请审批。";
        string sErr = RTXhelper.Send(message, "设备报废审批");
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('" + sErr + "')", true);
        }
    }
    protected void Btn_Cancel_Click1(object sender, EventArgs e)
    {
        if (Panel_New.Visible)
        {
            Panel_New.Visible = false;
        }
    }
    #endregion 修改报废申请

    #region 查看详情
    protected void look_close_Click(object sender, EventArgs e)
    {
        if (Panel_Look.Visible)
        {
            Panel_Look.Visible = false;
        }
    }
    #endregion 查看详情

    #region 审批/批准
    protected void Approval_ok_Click(object sender, EventArgs e)
    {
        if(Label777.Text=="审批")
        {
            if (Session["Department"].ToString().Contains("财务"))
            {
                Guid EUA_ID = new Guid(Label_euaid.Text.ToString());
                string EUA_Approver2 = TextBox1.Text.ToString();
                DateTime EUA_ApprovalT2 = Convert.ToDateTime(TextBox5.Text.ToString());
                string EUA_ApprovalSugg2 = TextBox7.Text.ToString();
                string EUA_ApprovalRes2 = "通过";
                if (EUA_ApprovalT2 < Convert.ToDateTime(Textlooktime.Text.ToString()))
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel_Look, GetType(), "aa", "alert('审批时间应大于申请时间！')", true);
                    return;
                }
                Label58.Text = "通过";
                equipUnusedAppL.Update_EquipUnusedApp_SP2(EUA_ID, EUA_Approver2, EUA_ApprovalT2, EUA_ApprovalSugg2, EUA_ApprovalRes2);
            }
            //if (Session["Department"].ToString().Contains("总经"))
            else
            {
                Guid EUA_ID = new Guid(Label_euaid.Text.ToString());
                string EUA_Approver = Textlookapper.Text.ToString();
                DateTime EUA_ApprovalT = Convert.ToDateTime(Textlookapptime.Text.ToString());
                string EUA_ApprovalSugg = Textlookappsug.Text.ToString();
                string EUA_ApprovalRes = "通过";
                if (EUA_ApprovalT < Convert.ToDateTime(Textlooktime.Text.ToString()))
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel_Look, GetType(), "aa", "alert('审批时间应大于申请时间！')", true);
                    return;
                }
                Label57.Text = "通过";
                equipUnusedAppL.Update_EquipUnusedApp_SP1(EUA_ID, EUA_Approver, EUA_ApprovalT, EUA_ApprovalSugg, EUA_ApprovalRes);
            }
            string condition = "and a.EUA_AppState='已提交'";
            BindGrid_UnusedApp(condition);
            Panel_Look.Visible = false;
            UpdatePanel_UnusedApp.Update();
            //RTX
            if ((Label57.Text == "通过" && TextBox6.Text=="通过")||(Label58.Text == "通过"&& Textlookappre.Text=="通过"))
            {
                string message = "ERP系统消息：财务部和技术副总审批通过了设备编号为" + Textlookno.Text + "的报废申请，请批准。";
                string sErr = RTXhelper.Send(message, "设备报废批准");
                if (!string.IsNullOrEmpty(sErr))
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('" + sErr + "')", true);
                }
            }
        }
        if(Label777.Text=="批准")
        {
            Guid EUA_ID = new Guid(Label_euaid.Text.ToString());
            string EUA_Allower = TextBox8.Text.ToString();
            DateTime EUA_AllowT = Convert.ToDateTime(TextBox9.Text.ToString());
            string EUA_AllowSugg = TextBox11.Text.ToString();
            string EUA_AllowRes = "批准";
            string EUA_AppState = "总经理批准";
            equipUnusedAppL.Update_EquipUnusedApp_PZ(EUA_ID, EUA_Allower, EUA_AllowT, EUA_AllowSugg, EUA_AllowRes, EUA_AppState);
            string condition = "and a.EUA_AppState='审批通过'";
            BindGrid_UnusedApp(condition);
            Panel_Look.Visible = false;
            UpdatePanel_UnusedApp.Update();
            //RTX
            string message = "ERP系统消息：总经理批准了设备编号为" + Textlookno.Text + "的报废申请，请进行报废处理。";
            string sErr = RTXhelper.Send(message, "设备报废处理");
            if (!string.IsNullOrEmpty(sErr))
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('" + sErr + "')", true);
            }
        }
    }
    protected void Approval_nok_Click(object sender, EventArgs e)
    {
        if (Label777.Text == "审批")
        {
            if (Session["Department"].ToString().Contains("财务"))
            {
                if (TextBox7.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel_Look, GetType(), "aa", "alert('请填写审批意见！')", true);
                    return;
                }
                Guid EUA_ID = new Guid(Label_euaid.Text.ToString());
                string EUA_Approver2 = TextBox1.Text.ToString();
                DateTime EUA_ApprovalT2 = Convert.ToDateTime(TextBox5.Text.ToString());
                string EUA_ApprovalSugg2 = TextBox7.Text.ToString();
                string EUA_ApprovalRes2 = "不通过";
                if (EUA_ApprovalT2 < Convert.ToDateTime(Textlooktime.Text.ToString()))
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel_Look, GetType(), "aa", "alert('审批时间应大于申请时间！')", true);
                    return;
                }
                Label58.Text = "不通过";
                equipUnusedAppL.Update_EquipUnusedApp_SP2(EUA_ID, EUA_Approver2, EUA_ApprovalT2, EUA_ApprovalSugg2, EUA_ApprovalRes2);
            }
            //if (Session["Department"].ToString().Contains("总经"))
            else
            {
                if (Textlookappsug.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel_Look, GetType(), "aa", "alert('请填写审批意见！')", true);
                    return;
                }
                Guid EUA_ID = new Guid(Label_euaid.Text.ToString());
                string EUA_Approver = Textlookapper.Text.ToString();
                DateTime EUA_ApprovalT = Convert.ToDateTime(Textlookapptime.Text.ToString());
                string EUA_ApprovalSugg = Textlookappsug.Text.ToString();
                string EUA_ApprovalRes = "不通过";
                if (EUA_ApprovalT < Convert.ToDateTime(Textlooktime.Text.ToString()))
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel_Look, GetType(), "aa", "alert('审批时间应大于申请时间！')", true);
                    return;
                }
                Label57.Text = "不通过";
                equipUnusedAppL.Update_EquipUnusedApp_SP1(EUA_ID, EUA_Approver, EUA_ApprovalT, EUA_ApprovalSugg, EUA_ApprovalRes);
            }
            string condition = "and a.EUA_AppState='已提交'";
            BindGrid_UnusedApp(condition);
            Panel_Look.Visible = false;
            UpdatePanel_UnusedApp.Update();
            //RTX
            if (Label57.Text == "不通过" || Label58.Text == "不通过")
            {
                string message = "ERP系统消息：审批驳回了设备编号为" + Textlookno.Text + "的报废申请，请重提申请。";
                string sErr = RTXhelper.SendbyUserName(message, Textlookper.Text);
                if (!string.IsNullOrEmpty(sErr))
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('" + sErr + "')", true);
                }
            }
        }
        if(Label777.Text=="批准")
        {
            if (TextBox11.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel_Look, GetType(), "aa", "alert('请填写批准意见！')", true);
                return;
            }
            Guid EUA_ID = new Guid(Label_euaid.Text.ToString());
            string EUA_Allower = TextBox8.Text.ToString();
            DateTime EUA_AllowT = Convert.ToDateTime(TextBox9.Text.ToString());
            string EUA_AllowSugg = TextBox11.Text.ToString();
            string EUA_AllowRes = "不批准";
            string EUA_AppState = "总经理驳回";
            equipUnusedAppL.Update_EquipUnusedApp_PZ(EUA_ID, EUA_Allower, EUA_AllowT, EUA_AllowSugg, EUA_AllowRes, EUA_AppState);
            string condition = "and a.EUA_AppState='审批通过'";
            BindGrid_UnusedApp(condition);
            Panel_Look.Visible = false;
            UpdatePanel_UnusedApp.Update();
            //RTX
            string message = "ERP系统消息：总经理驳回了设备编号为" + Textlookno.Text + "的报废申请，请重提申请。";
            string sErr = RTXhelper.SendbyUserName(message, Textlookper.Text);
            if (!string.IsNullOrEmpty(sErr))
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('" + sErr + "')", true);
            }
        }
    }
    protected void Approval_cancel_Click(object sender, EventArgs e)
    {
        if (Panel_Look.Visible)
        {
            Panel_Look.Visible = false;
        }
    }
    #endregion 审批

    #region 报废处理
    protected void deal_ok_Click(object sender, EventArgs e)
    {
        Guid EUA_ID = new Guid(Label_euaid.Text.ToString());
        string EUA_DealPer = Textlookdealper.Text.ToString();
        DateTime EUA_DealTime = Convert.ToDateTime(Textlookdealtime.Text.ToString());
        //if (this.Textlookdealper.Text.ToString() == "")
        //{
        //    ScriptManager.RegisterClientScriptBlock(this.UpdatePanel_Look, this.GetType(), "alert", "alert('请填写处理人！')", true);
        //    return;
        //}
        if (EUA_DealTime < Convert.ToDateTime(Textlookapptime.Text.ToString()))
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_Look, GetType(), "aa", "alert('报废处理时间时间应大于审批时间！')", true);
            return;
        }
        equipUnusedAppL.Update_EquipUnusedApp_CL(EUA_ID, EUA_DealPer, EUA_DealTime);
        string condition = "and a.EUA_AppState='审批通过'";
        BindGrid_UnusedApp(condition);
        Panel_Look.Visible = false;
        UpdatePanel_UnusedApp.Update();
        //RTX
        string message = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "处理了设备编号为" + Textaddno.Text + "的设备。";
        string sErr = RTXhelper.SendbyUserName(message, Textlookper.Text);
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('" + sErr + "')", true);
        }
    }
    protected void deal_cancel_Click(object sender, EventArgs e)
    {
        if (Panel_Look.Visible)
        {
            Panel_Look.Visible = false;
        }
    }
    #endregion 报废处理

}