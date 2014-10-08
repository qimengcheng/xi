using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using RTXHelper;

public partial class EquipMgt_EMEquipMaintenanceApp : Page
{
    EquipMaintenanceAppL equipMaintenanceAppL = new EquipMaintenanceAppL();
    EquipTypeL equipTypeL = new EquipTypeL();
    EquipNameModelL equipNameModelL = new EquipNameModelL();
    EquipUpkeepPlanL equipUpkeepPlanL = new EquipUpkeepPlanL();
    User us = new User();

    #region 页面权限控制
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DropDownList1.Items.Insert(0, new ListItem("请选择", ""));
            BindDropDownList1();
            DropDownList2.Items.Insert(0, new ListItem("请选择", ""));
            BindDropDownList2();
            Panel_MaintenanceApp.Visible = true;
            UpdatePanel_MaintenanceApp.Update();
            //BindGrid_MaintenanceApp("");//暂时
            try
            {
                if (Request.QueryString["status"].ToString() != "")
                {
                    Lab_Status.Text = Request.QueryString["status"].ToString();
                }
                if (Lab_Status.Text == "EMWxApp" && Session["UserRole"].ToString().Contains("设备故障维修申请"))
                {
                    Title = "设备故障维修申请";
                    Grid_MaintenanceApp.Columns[10].Visible = false;//故障报修时间
                    Grid_MaintenanceApp.Columns[12].Visible = false;//故障接收确认时间
                    Grid_MaintenanceApp.Columns[15].Visible = false;//验收人
                    Grid_MaintenanceApp.Columns[16].Visible = false;//验收时间
                    Grid_MaintenanceApp.Columns[17].Visible = true;//验收结果
                    Grid_MaintenanceApp.Columns[19].Visible = false;//查看详情
                    Grid_MaintenanceApp.Columns[20].Visible = true;//编辑申请单
                    Grid_MaintenanceApp.Columns[21].Visible = false;//接收确认
                    Grid_MaintenanceApp.Columns[22].Visible = false;//填写维修信息
                    Grid_MaintenanceApp.Columns[23].Visible = false;//维修验收
                    Grid_MaintenanceApp.Columns[24].Visible = true;//删除

                    Btn_New.Visible = true;
                    //this.DropDownList3.Items.FindByValue("已提交").Enabled = false;
                    //this.DropDownList3.Items.FindByValue("已确认").Enabled = false;
                    //this.DropDownList3.Items.FindByValue("已完成").Enabled = false;
                    //this.DropDownList3.Items.FindByValue("已验收").Enabled = false;
                    //this.EMA_AckPer.Enabled = false;
                    //this.EMA_AckTime.Enabled = false;
                    //this.EMA_CheckPer.Enabled = false;
                    //this.EMA_CheckTime.Enabled = false;
                    //this.DropDownList4.Enabled = false;
                    Label94.Visible = false;
                    Panel32.Visible = true;
                    EMA_AckPer.Visible = false;
                    EMA_AckTime.Visible = false;
                    Label9.Visible = false;
                    Label21.Visible = false;
                    Panel33.Visible = false;
                    //BindGrid_MaintenanceApp("and (a.EMA_AppState='待提交' or (a.EMA_AppState='已验收' and EMA_CheckRes='不通过'))");
                    BindGrid_MaintenanceApp("");
                }
                if (Lab_Status.Text == "EMWxAck" && Session["UserRole"].ToString().Contains("设备故障维修确认"))
                {
                    Title = "设备故障维修确认";
                    Grid_MaintenanceApp.Columns[10].Visible = false;//故障报修时间
                    Grid_MaintenanceApp.Columns[12].Visible = false;//故障接收确认时间
                    Grid_MaintenanceApp.Columns[15].Visible = false;//验收人
                    Grid_MaintenanceApp.Columns[16].Visible = false;//验收时间
                    Grid_MaintenanceApp.Columns[17].Visible = false;//验收结果
                    Grid_MaintenanceApp.Columns[19].Visible = false;//查看详情
                    Grid_MaintenanceApp.Columns[20].Visible = false;//编辑申请单
                    Grid_MaintenanceApp.Columns[21].Visible = true;//接收确认
                    Grid_MaintenanceApp.Columns[22].Visible = false;//填写维修信息
                    Grid_MaintenanceApp.Columns[23].Visible = false;//维修验收
                    Grid_MaintenanceApp.Columns[24].Visible = false;//删除

                    Btn_New.Visible = false;
                    DropDownList3.Items.FindByValue("待提交").Enabled = false;
                    DropDownList3.Items.FindByValue("已确认").Enabled = false;
                    DropDownList3.Items.FindByValue("已完成").Enabled = false;
                    DropDownList3.Items.FindByValue("已验收").Enabled = false;
                    //this.EMA_AckPer.Enabled = false;
                    //this.EMA_AckTime.Enabled = false;
                    //this.EMA_CheckPer.Enabled = false;
                    //this.EMA_CheckTime.Enabled = false;
                    //this.DropDownList4.Enabled = false;
                    Label94.Visible = false;
                    Panel32.Visible = true;
                    EMA_AckPer.Visible = false;
                    EMA_AckTime.Visible = false;
                    Label9.Visible = false;
                    Label21.Visible = false;
                    Panel33.Visible = false;
                    BindGrid_MaintenanceApp("and a.EMA_AppState='已提交'");
                }
                if (Lab_Status.Text == "EMCnDeal" && Session["UserRole"].ToString().Contains("设备故障维修情况记录"))
                {
                    Title = "设备故障维修情况记录";
                    Grid_MaintenanceApp.Columns[10].Visible = false;//故障报修时间
                    Grid_MaintenanceApp.Columns[12].Visible = false;//故障接收确认时间
                    Grid_MaintenanceApp.Columns[15].Visible = false;//验收人
                    Grid_MaintenanceApp.Columns[16].Visible = false;//验收时间
                    Grid_MaintenanceApp.Columns[17].Visible = false;//验收结果
                    Grid_MaintenanceApp.Columns[19].Visible = false;//查看详情
                    Grid_MaintenanceApp.Columns[20].Visible = false;//编辑申请单
                    Grid_MaintenanceApp.Columns[21].Visible = false;//接收确认
                    Grid_MaintenanceApp.Columns[22].Visible = true;//填写维修信息
                    Grid_MaintenanceApp.Columns[23].Visible = false;//维修验收
                    Grid_MaintenanceApp.Columns[24].Visible = false;//删除

                    Btn_New.Visible = false;
                    DropDownList3.Items.FindByValue("待提交").Enabled = false;
                    DropDownList3.Items.FindByValue("已提交").Enabled = false;
                    DropDownList3.Items.FindByValue("已完成").Enabled = false;
                    DropDownList3.Items.FindByValue("已验收").Enabled = false;
                    Label94.Visible = true;
                    //this.EMA_AckPer.Enabled = true;
                    //this.EMA_AckTime.Enabled = true;
                    //this.EMA_CheckPer.Enabled = false;
                    //this.EMA_CheckTime.Enabled = false;
                    //this.DropDownList4.Enabled = false;
                    Panel32.Visible = true;
                    Panel33.Visible = false;
                    BindGrid_MaintenanceApp("and a.EMA_AppState='已确认'");
                    foreach (GridViewRow gvr in Grid_MaintenanceApp.Rows)
                    {
                        LinkButton cb = Grid_MaintenanceApp.Rows[gvr.RowIndex].FindControl("Deal1") as LinkButton;
                        cb.Text = "维修情况记录";
                    }
                }
                if (Lab_Status.Text == "EMCcApp" && Session["UserRole"].ToString().Contains("出厂维修审批"))
                {
                    Title = "出厂维修审批";
                    Grid_MaintenanceApp.Columns[10].Visible = false;//故障报修时间
                    Grid_MaintenanceApp.Columns[12].Visible = false;//故障接收确认时间
                    Grid_MaintenanceApp.Columns[15].Visible = false;//验收人
                    Grid_MaintenanceApp.Columns[16].Visible = false;//验收时间
                    Grid_MaintenanceApp.Columns[17].Visible = false;//验收结果
                    Grid_MaintenanceApp.Columns[19].Visible = false;//查看详情
                    Grid_MaintenanceApp.Columns[20].Visible = false;//编辑申请单
                    Grid_MaintenanceApp.Columns[21].Visible = false;//接收确认
                    Grid_MaintenanceApp.Columns[22].Visible = true;//填写维修信息
                    Grid_MaintenanceApp.Columns[23].Visible = false;//维修验收
                    Grid_MaintenanceApp.Columns[24].Visible = false;//删除

                    Label94.Visible = false;
                    Btn_New.Visible = false;
                    DropDownList3.Items.FindByValue("待提交").Enabled = false;
                    DropDownList3.Items.FindByValue("已提交").Enabled = false;
                    DropDownList3.Items.FindByValue("已完成").Enabled = false;
                    DropDownList3.Items.FindByValue("已验收").Enabled = false;
                    Panel32.Visible = true;
                    Panel33.Visible = false;
                    BindGrid_MaintenanceApp("and a.EMA_AppState='已确认'");
                    foreach (GridViewRow gvr in Grid_MaintenanceApp.Rows)
                    {
                        LinkButton cb = Grid_MaintenanceApp.Rows[gvr.RowIndex].FindControl("Deal1") as LinkButton;
                        cb.Text = "出厂维修审批";
                    }
                }
                if (Lab_Status.Text == "EMCcExpect" && Session["UserRole"].ToString().Contains("出厂维修预算"))
                {
                    Title = "出厂维修预算";
                    Grid_MaintenanceApp.Columns[10].Visible = false;//故障报修时间
                    Grid_MaintenanceApp.Columns[12].Visible = false;//故障接收确认时间
                    Grid_MaintenanceApp.Columns[15].Visible = false;//验收人
                    Grid_MaintenanceApp.Columns[16].Visible = false;//验收时间
                    Grid_MaintenanceApp.Columns[17].Visible = false;//验收结果
                    Grid_MaintenanceApp.Columns[19].Visible = false;//查看详情
                    Grid_MaintenanceApp.Columns[20].Visible = false;//编辑申请单
                    Grid_MaintenanceApp.Columns[21].Visible = false;//接收确认
                    Grid_MaintenanceApp.Columns[22].Visible = true;//填写维修信息
                    Grid_MaintenanceApp.Columns[23].Visible = false;//维修验收
                    Grid_MaintenanceApp.Columns[24].Visible = false;//删除

                    Label94.Visible = false;
                    Btn_New.Visible = false;
                    DropDownList3.Items.FindByValue("待提交").Enabled = false;
                    DropDownList3.Items.FindByValue("已提交").Enabled = false;
                    DropDownList3.Items.FindByValue("已完成").Enabled = false;
                    DropDownList3.Items.FindByValue("已验收").Enabled = false;
                    Panel32.Visible = true;
                    Panel33.Visible = false;
                    BindGrid_MaintenanceApp("and a.EMA_AppState='已确认'");
                    foreach (GridViewRow gvr in Grid_MaintenanceApp.Rows)
                    {
                        LinkButton cb = Grid_MaintenanceApp.Rows[gvr.RowIndex].FindControl("Deal1") as LinkButton;
                        cb.Text = "出厂维修预算";
                    }
                }
                if (Lab_Status.Text == "EMCcFinan" && Session["UserRole"].ToString().Contains("出厂维修财务审核"))
                {
                    Title = "出厂维修财务审核";
                    Grid_MaintenanceApp.Columns[10].Visible = false;//故障报修时间
                    Grid_MaintenanceApp.Columns[12].Visible = false;//故障接收确认时间
                    Grid_MaintenanceApp.Columns[15].Visible = false;//验收人
                    Grid_MaintenanceApp.Columns[16].Visible = false;//验收时间
                    Grid_MaintenanceApp.Columns[17].Visible = false;//验收结果
                    Grid_MaintenanceApp.Columns[19].Visible = false;//查看详情
                    Grid_MaintenanceApp.Columns[20].Visible = false;//编辑申请单
                    Grid_MaintenanceApp.Columns[21].Visible = false;//接收确认
                    Grid_MaintenanceApp.Columns[22].Visible = true;//填写维修信息
                    Grid_MaintenanceApp.Columns[23].Visible = false;//维修验收
                    Grid_MaintenanceApp.Columns[24].Visible = false;//删除

                    Label94.Visible = false;
                    Btn_New.Visible = false;
                    DropDownList3.Items.FindByValue("待提交").Enabled = false;
                    DropDownList3.Items.FindByValue("已提交").Enabled = false;
                    DropDownList3.Items.FindByValue("已完成").Enabled = false;
                    DropDownList3.Items.FindByValue("已验收").Enabled = false;
                    Panel32.Visible = true;
                    Panel33.Visible = false;
                    BindGrid_MaintenanceApp("and a.EMA_AppState='已确认'");
                    foreach (GridViewRow gvr in Grid_MaintenanceApp.Rows)
                    {
                        LinkButton cb = Grid_MaintenanceApp.Rows[gvr.RowIndex].FindControl("Deal1") as LinkButton;
                        cb.Text = "财务审核";
                    }
                }
                if (Lab_Status.Text == "EMCcConfirmor" && Session["UserRole"].ToString().Contains("出厂维修出厂确认"))
                {
                    Title = "出厂维修出厂确认";
                    Grid_MaintenanceApp.Columns[10].Visible = false;//故障报修时间
                    Grid_MaintenanceApp.Columns[12].Visible = false;//故障接收确认时间
                    Grid_MaintenanceApp.Columns[15].Visible = false;//验收人
                    Grid_MaintenanceApp.Columns[16].Visible = false;//验收时间
                    Grid_MaintenanceApp.Columns[17].Visible = false;//验收结果
                    Grid_MaintenanceApp.Columns[19].Visible = false;//查看详情
                    Grid_MaintenanceApp.Columns[20].Visible = false;//编辑申请单
                    Grid_MaintenanceApp.Columns[21].Visible = false;//接收确认
                    Grid_MaintenanceApp.Columns[22].Visible = true;//填写维修信息
                    Grid_MaintenanceApp.Columns[23].Visible = false;//维修验收
                    Grid_MaintenanceApp.Columns[24].Visible = false;//删除

                    Label94.Visible = false;
                    Btn_New.Visible = false;
                    DropDownList3.Items.FindByValue("待提交").Enabled = false;
                    DropDownList3.Items.FindByValue("已提交").Enabled = false;
                    DropDownList3.Items.FindByValue("已完成").Enabled = false;
                    DropDownList3.Items.FindByValue("已验收").Enabled = false;
                    Panel32.Visible = true;
                    Panel33.Visible = false;
                    BindGrid_MaintenanceApp("and a.EMA_AppState='已确认'");
                    foreach (GridViewRow gvr in Grid_MaintenanceApp.Rows)
                    {
                        LinkButton cb = Grid_MaintenanceApp.Rows[gvr.RowIndex].FindControl("Deal1") as LinkButton;
                        cb.Text = "出厂确认";
                    }
                }
                if (Lab_Status.Text == "EMCcAct" && Session["UserRole"].ToString().Contains("出厂维修回厂信息完善"))
                {
                    Title = "出厂维修回厂信息完善";
                    Grid_MaintenanceApp.Columns[10].Visible = false;//故障报修时间
                    Grid_MaintenanceApp.Columns[12].Visible = false;//故障接收确认时间
                    Grid_MaintenanceApp.Columns[15].Visible = false;//验收人
                    Grid_MaintenanceApp.Columns[16].Visible = false;//验收时间
                    Grid_MaintenanceApp.Columns[17].Visible = false;//验收结果
                    Grid_MaintenanceApp.Columns[19].Visible = false;//查看详情
                    Grid_MaintenanceApp.Columns[20].Visible = false;//编辑申请单
                    Grid_MaintenanceApp.Columns[21].Visible = false;//接收确认
                    Grid_MaintenanceApp.Columns[22].Visible = true;//填写维修信息
                    Grid_MaintenanceApp.Columns[23].Visible = false;//维修验收
                    Grid_MaintenanceApp.Columns[24].Visible = false;//删除

                    Label94.Visible = false;
                    Btn_New.Visible = false;
                    DropDownList3.Items.FindByValue("待提交").Enabled = false;
                    DropDownList3.Items.FindByValue("已提交").Enabled = false;
                    DropDownList3.Items.FindByValue("已完成").Enabled = false;
                    DropDownList3.Items.FindByValue("已验收").Enabled = false;
                    Panel32.Visible = true;
                    Panel33.Visible = false;
                    BindGrid_MaintenanceApp("and a.EMA_AppState='已确认'");
                    foreach (GridViewRow gvr in Grid_MaintenanceApp.Rows)
                    {
                        LinkButton cb = Grid_MaintenanceApp.Rows[gvr.RowIndex].FindControl("Deal1") as LinkButton;
                        cb.Text = "完善回厂信息";
                    }
                }
                if (Lab_Status.Text == "EMCcFinanConfirmor" && Session["UserRole"].ToString().Contains("出厂维修财务确认"))
                {
                    Title = "出厂维修财务确认";
                    Grid_MaintenanceApp.Columns[10].Visible = false;//故障报修时间
                    Grid_MaintenanceApp.Columns[12].Visible = false;//故障接收确认时间
                    Grid_MaintenanceApp.Columns[15].Visible = false;//验收人
                    Grid_MaintenanceApp.Columns[16].Visible = false;//验收时间
                    Grid_MaintenanceApp.Columns[17].Visible = false;//验收结果
                    Grid_MaintenanceApp.Columns[19].Visible = false;//查看详情
                    Grid_MaintenanceApp.Columns[20].Visible = false;//编辑申请单
                    Grid_MaintenanceApp.Columns[21].Visible = false;//接收确认
                    Grid_MaintenanceApp.Columns[22].Visible = true;//填写维修信息
                    Grid_MaintenanceApp.Columns[23].Visible = false;//维修验收
                    Grid_MaintenanceApp.Columns[24].Visible = false;//删除

                    Label94.Visible = false;
                    Btn_New.Visible = false;
                    DropDownList3.Items.FindByValue("待提交").Enabled = false;
                    DropDownList3.Items.FindByValue("已提交").Enabled = false;
                    DropDownList3.Items.FindByValue("已完成").Enabled = false;
                    DropDownList3.Items.FindByValue("已验收").Enabled = false;
                    Panel32.Visible = true;
                    Panel33.Visible = false;
                    BindGrid_MaintenanceApp("and a.EMA_AppState='已确认'");
                    foreach (GridViewRow gvr in Grid_MaintenanceApp.Rows)
                    {
                        LinkButton cb = Grid_MaintenanceApp.Rows[gvr.RowIndex].FindControl("Deal1") as LinkButton;
                        cb.Text = "财务确认";
                    }
                }
                if (Lab_Status.Text == "EMCcLook" && Session["UserRole"].ToString().Contains("出厂维修查看"))
                {
                    Title = "出厂维修查看";
                    Grid_MaintenanceApp.Columns[10].Visible = false;//故障报修时间
                    Grid_MaintenanceApp.Columns[12].Visible = false;//故障接收确认时间
                    Grid_MaintenanceApp.Columns[15].Visible = false;//验收人
                    Grid_MaintenanceApp.Columns[16].Visible = false;//验收时间
                    Grid_MaintenanceApp.Columns[17].Visible = false;//验收结果
                    Grid_MaintenanceApp.Columns[19].Visible = false;//查看详情
                    Grid_MaintenanceApp.Columns[20].Visible = false;//编辑申请单
                    Grid_MaintenanceApp.Columns[21].Visible = false;//接收确认
                    Grid_MaintenanceApp.Columns[22].Visible = true;//填写维修信息
                    Grid_MaintenanceApp.Columns[23].Visible = false;//维修验收
                    Grid_MaintenanceApp.Columns[24].Visible = false;//删除

                    Label94.Visible = false;
                    Btn_New.Visible = false;
                    DropDownList3.Items.FindByValue("待提交").Enabled = false;
                    DropDownList3.Items.FindByValue("已提交").Enabled = false;
                    DropDownList3.Items.FindByValue("已完成").Enabled = false;
                    DropDownList3.Items.FindByValue("已验收").Enabled = false;
                    Panel32.Visible = true;
                    Panel33.Visible = false;
                    BindGrid_MaintenanceApp("and a.EMA_AppState='已确认'");
                    foreach (GridViewRow gvr in Grid_MaintenanceApp.Rows)
                    {
                        LinkButton cb = Grid_MaintenanceApp.Rows[gvr.RowIndex].FindControl("Deal1") as LinkButton;
                        cb.Text = "维修查看";
                    }
                }
                if (Lab_Status.Text == "EMWxCheck" && Session["UserRole"].ToString().Contains("设备故障维修验收"))
                {
                    Title = "设备故障维修验收";
                    Grid_MaintenanceApp.Columns[10].Visible = false;//故障报修时间
                    Grid_MaintenanceApp.Columns[12].Visible = false;//故障接收确认时间
                    Grid_MaintenanceApp.Columns[15].Visible = false;//验收人
                    Grid_MaintenanceApp.Columns[16].Visible = false;//验收时间
                    Grid_MaintenanceApp.Columns[17].Visible = false;//验收结果
                    Grid_MaintenanceApp.Columns[19].Visible = false;//查看详情
                    Grid_MaintenanceApp.Columns[20].Visible = false;//编辑申请单
                    Grid_MaintenanceApp.Columns[21].Visible = false;//接收确认
                    Grid_MaintenanceApp.Columns[22].Visible = false;//填写维修信息
                    Grid_MaintenanceApp.Columns[23].Visible = true;//维修验收
                    Grid_MaintenanceApp.Columns[24].Visible = false;//删除

                    Label94.Visible = false;
                    Btn_New.Visible = false;
                    DropDownList3.Items.FindByValue("待提交").Enabled = false;
                    DropDownList3.Items.FindByValue("已提交").Enabled = false;
                    DropDownList3.Items.FindByValue("已确认").Enabled = false;
                    DropDownList3.Items.FindByValue("已验收").Enabled = false;
                    //this.EMA_AckPer.Enabled = true;
                    //this.EMA_AckTime.Enabled = true;
                    //this.EMA_CheckPer.Enabled = false;
                    //this.EMA_CheckTime.Enabled = false;
                    //this.DropDownList4.Enabled = false;
                    Panel32.Visible = true;
                    Panel33.Visible = false;
                    BindGrid_MaintenanceApp("and a.EMA_AppState='已完成'");
                }
                if (Lab_Status.Text == "EMWxLook" && Session["UserRole"].ToString().Contains("设备故障维修查看"))
                {
                    Title = "设备故障维修查看";
                    Grid_MaintenanceApp.Columns[10].Visible = false;//故障报修时间
                    Grid_MaintenanceApp.Columns[12].Visible = false;//故障接收确认时间
                    Grid_MaintenanceApp.Columns[15].Visible = true;//验收人
                    Grid_MaintenanceApp.Columns[16].Visible = false;//验收时间
                    Grid_MaintenanceApp.Columns[17].Visible = true;//验收结果
                    Grid_MaintenanceApp.Columns[19].Visible = true;//查看详情
                    Grid_MaintenanceApp.Columns[20].Visible = false;//编辑申请单
                    Grid_MaintenanceApp.Columns[21].Visible = false;//接收确认
                    Grid_MaintenanceApp.Columns[22].Visible = false;//填写维修信息
                    Grid_MaintenanceApp.Columns[23].Visible = false;//维修验收
                    Grid_MaintenanceApp.Columns[24].Visible = false;//删除

                    Label94.Visible = false;
                    Btn_New.Visible = false;
                    DropDownList3.Items.FindByValue("待提交").Enabled = true;
                    DropDownList3.Items.FindByValue("已提交").Enabled = true;
                    DropDownList3.Items.FindByValue("已确认").Enabled = true;
                    DropDownList3.Items.FindByValue("已完成").Enabled = true;
                    DropDownList3.Items.FindByValue("已验收").Enabled = true;
                    //this.EMA_AckPer.Enabled = true;
                    //this.EMA_AckTime.Enabled = true;
                    //this.EMA_CheckPer.Enabled = true;
                    //this.EMA_CheckTime.Enabled = true;
                    //this.DropDownList4.Enabled = true;
                    BindGrid_MaintenanceApp("");
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
    //绑定设备维修信息gridview
    private void BindGrid_MaintenanceApp(string condition)
    {
        Grid_MaintenanceApp.DataSource = equipMaintenanceAppL.Search_EquipMaintenanceApp(condition);
        Grid_MaintenanceApp.DataBind();
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
        Grid_EquipInfo.DataSource = equipMaintenanceAppL.Search_InsertEquipMaintenanceApp(ETT_Type, EN_EquipName, EMT_Type, EI_No);
        Grid_EquipInfo.DataBind();
    }
    //DropDownList2下拉表绑定
    private void BindDropDownList2()
    {
        DropDownList2.DataSource = equipMaintenanceAppL.Search_BDOrganizationSheet_EquipMaintenanceApp();
        DropDownList2.DataTextField = "BDOS_Name";
        DropDownList2.DataValueField = "BDOS_Name";
        DropDownList2.DataBind();
        DropDownList2.Items.Insert(0, new ListItem("请选择", ""));
    }
    //DropDownList5下拉表绑定
    private void BindDropDownList5()
    {
        DropDownList5.DataSource = equipTypeL.Search_EquipTypeTableInfo("");
        DropDownList5.DataTextField = "ETT_Type";
        DropDownList5.DataValueField = "ETT_Type";
        DropDownList5.DataBind();
        DropDownList5.Items.Insert(0, new ListItem("请选择", ""));
    }
    //DropDownList6下拉表绑定
    private void BindDropDownList6()
    {
        DropDownList6.DataSource = equipMaintenanceAppL.Search_BDOrganizationSheet_EquipMaintenanceApp();
        DropDownList6.DataTextField = "BDOS_Name";
        DropDownList6.DataValueField = "BDOS_Name";
        DropDownList6.DataBind();
        DropDownList6.Items.Insert(0, new ListItem("请选择", ""));
    }
    //绑定厂内维修记录gridview
    private void BindGridView_CN(string condition)
    {
        GridView_CN.DataSource = equipMaintenanceAppL.Search_EquipRealDetailAOApp_CN(condition);
        GridView_CN.DataBind();
    }
    //绑定厂内已选的备件
    private void BindGrid_spare(string condition)
    {
        Grid_spare.DataSource = equipUpkeepPlanL.Search_EquipUpkeepPlan_Sparedone(condition);
        Grid_spare.DataBind();
    }
    //绑定可选的全部备件
    private void BindGrid_NewEquipSpare(string condition)
    {
        Grid_NewEquipSpare.DataSource = equipNameModelL.Search_EquipFreqUsedSpareInfo(condition);
        Grid_NewEquipSpare.DataBind();
    }
    //绑定出厂维修记录gridview
    private void BindGridView_CC(string condition)
    {
        GridView_CC.DataSource = equipMaintenanceAppL.Search_EquipRealDetailAOApp_CC(condition);
        GridView_CC.DataBind();
    }
    //DropDownList7下拉表绑定
    private void BindDropDownList7()
    {
        DropDownList7.DataSource = equipMaintenanceAppL.Search_BDOrganizationSheet_EquipMaintenanceApp();
        DropDownList7.DataTextField = "BDOS_Name";
        DropDownList7.DataValueField = "BDOS_Name";
        DropDownList7.DataBind();
        DropDownList7.Items.Insert(0, new ListItem("请选择", ""));
    }
    //绑定出厂已选的备件
    private void BindGrid_spare_cc(string condition)
    {
        Grid_spare_cc.DataSource = equipUpkeepPlanL.Search_EquipUpkeepPlan_Sparedone(condition);
        Grid_spare_cc.DataBind();
    }
    #endregion 绑定

    #region 检索设备维修信息
    //检索维修
    protected void Btn_Search_Click(object sender, EventArgs e)
    {
        string condition = GetCondition();
        BindGrid_MaintenanceApp(condition);
        Panel_MaintenanceApp.Visible = true;
        UpdatePanel_MaintenanceApp.Update();
        Panel_CN.Visible = false;
        UpdatePanel_CN.Update();
        Panel_searchInf.Visible = false;
        Panel_dealCN.Visible = false;
        UpdatePanel_dealCN.Update();
        Panel_New.Visible = false;
        UpdatePanel_New.Update();
        UpdatePanel_Search.Update();
    }
    protected string GetCondition()
    {
        string condition;
        string temp = "";
        if (DropDownList1.Text.ToString() != "")
        {
            temp += " and e.ETT_Type='" + DropDownList1.SelectedValue.ToString() + "'";
        }
        if (Textname.Text.ToString() != "")
        {
            temp += " and d.EN_EquipName like '%" + Textname.Text.ToString() + "%'";
        }
        if (Textmodel.Text.ToString() != "")
        {
            temp += " and  c.EMT_Type like '%" + Textmodel.Text.ToString() + "%'";
        }
        if (Textno.Text.ToString() != "")
        {
            temp += " and  b.EI_No like '%" + Textno.Text.ToString() + "%'";
        }
        if (EMA_AppNO.Text.ToString() != "")
        {
            temp += " and  EMA_AppNO like '%" + EMA_AppNO.Text.ToString() + "%'";
        }
        if (DropDownList2.Text.ToString() != "")
        {
            temp += " and EMA_AppDep='" + DropDownList2.SelectedValue.ToString() + "'";
        }
        if (EMA_BreakDownTime.Text.ToString() != "")
        {
            temp += "and DateDiff(dd,getdate(),EMA_BreakDownTime)=DateDiff(dd,getdate(),'" + EMA_BreakDownTime.Text.ToString() + "')";
            //temp += " and  EMA_BreakDownTime = '" + this.EMA_BreakDownTime.Text.ToString() + "'";
        }
        if (EMA_AppPer.Text.ToString() != "")
        {
            temp += " and  EMA_AppPer like '%" + EMA_AppPer.Text.ToString() + "%'";
        }
        if (EMA_AppTime.Text.ToString() != "")
        {
            //temp += " and  EMA_AppTime = '" + this.EMA_AppTime.Text.ToString() + "'";
            temp += "and DateDiff(dd,getdate(),EMA_AppTime)=DateDiff(dd,getdate(),'" + EMA_AppTime.Text.ToString() + "')";

        }
        if (EMA_AckPer.Text.ToString() != "")
        {
            temp += " and  EMA_AckPer like '%" + EMA_AckPer.Text.ToString() + "%'";
        }
        if (EMA_AckTime.Text.ToString() != "")
        {
            //temp += " and  EMA_AckTime = '" + this.EMA_AckTime.Text.ToString() + "'";
            temp += "and DateDiff(dd,getdate(),EMA_AckTime)=DateDiff(dd,getdate(),'" + EMA_AckTime.Text.ToString() + "')";

        }
        if (DropDownList3.Text.ToString() != "")
        {
            temp += " and EMA_AppState='" + DropDownList3.SelectedValue.ToString() + "'";
        }
        if (EMA_CheckPer.Text.ToString() != "")
        {
            temp += " and  EMA_CheckPer like '%" + EMA_CheckPer.Text.ToString() + "%'";
        }
        if (EMA_CheckTime.Text.ToString() != "")
        {
            //temp += " and  EMA_CheckTime like '%" + this.EMA_CheckTime.Text.ToString() + "%'";
            temp += "and DateDiff(dd,getdate(),EMA_CheckTime)=DateDiff(dd,getdate(),'" + EMA_CheckTime.Text.ToString() + "')";

        }
        if (DropDownList4.Text.ToString() != "")
        {
            temp += " and EMA_CheckRes='" + DropDownList4.SelectedValue.ToString() + "'";
        }
        if (Lab_Status.Text == "EMWxApp" && Session["UserRole"].ToString().Contains("设备故障维修申请"))
        {
            //temp += " and a.EMA_AppState='待提交'";
            temp += "";
        }
        if (Lab_Status.Text == "EMWxAck" && Session["UserRole"].ToString().Contains("设备故障维修确认"))
        {
            temp += " and a.EMA_AppState='已提交'";
        }
        if ((Lab_Status.Text == "EMCnDeal" && Session["UserRole"].ToString().Contains("设备故障维修情况记录"))
                    || (Lab_Status.Text == "EMCcApp" && Session["UserRole"].ToString().Contains("出厂维修审批"))
                    || (Lab_Status.Text == "EMCcExpect" && Session["UserRole"].ToString().Contains("出厂维修预算"))
                    || (Lab_Status.Text == "EMCcFinan" && Session["UserRole"].ToString().Contains("出厂维修财务审核"))
                    || (Lab_Status.Text == "EMCcConfirmor" && Session["UserRole"].ToString().Contains("出厂维修出厂确认"))
                    || (Lab_Status.Text == "EMCcAct" && Session["UserRole"].ToString().Contains("出厂维修回厂信息完善"))
                    || (Lab_Status.Text == "EMCcFinanConfirmor" && Session["UserRole"].ToString().Contains("出厂维修财务确认"))
                    || (Lab_Status.Text == "EMCcLook" && Session["UserRole"].ToString().Contains("出厂维修查看")))
        {
            temp += " and a.EMA_AppState='已确认'";
        }
        if (Lab_Status.Text == "EMWxCheck" && Session["UserRole"].ToString().Contains("设备故障维修验收"))
        {
            temp += " and a.EMA_AppState='已完成'";
        }
        if (Lab_Status.Text == "EMWxLook" && Session["UserRole"].ToString().Contains("设备故障维修查看"))
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
        EMA_AppNO.Text = "";
        DropDownList2.Items.Insert(0, new ListItem("请选择", ""));
        BindDropDownList2();
        EMA_BreakDownTime.Text = "";
        EMA_AppPer.Text = "";
        EMA_AppTime.Text = "";
        EMA_AckPer.Text = "";
        EMA_AckTime.Text = "";
        DropDownList3.SelectedIndex = 0;
        EMA_CheckPer.Text = "";
        EMA_CheckTime.Text = "";
        DropDownList4.SelectedIndex = 0;
        UpdatePanel_Search.Update();
        string condition = GetCondition1();
        BindGrid_MaintenanceApp(condition);
        UpdatePanel_MaintenanceApp.Update();
        Panel_CN.Visible = false;
        UpdatePanel_CN.Update();
        Panel_searchInf.Visible = false;
        Panel_dealCN.Visible = false;
        UpdatePanel_dealCN.Update();
        Panel_New.Visible = false;
        UpdatePanel_New.Update();
    }
    protected string GetCondition1()
    {
        string condition;
        string temp = "";
        if (Lab_Status.Text == "EMWxApp" && Session["UserRole"].ToString().Contains("设备故障维修申请"))
        {
            //temp += " and a.EMA_AppState='待提交'";
            temp += "";
        }
        if (Lab_Status.Text == "EMWxAck" && Session["UserRole"].ToString().Contains("设备故障维修确认"))
        {
            temp += " and a.EMA_AppState='已提交'";
        }
        if ((Lab_Status.Text == "EMCnDeal" && Session["UserRole"].ToString().Contains("设备故障维修情况记录"))
                    || (Lab_Status.Text == "EMCcApp" && Session["UserRole"].ToString().Contains("出厂维修审批"))
                    || (Lab_Status.Text == "EMCcExpect" && Session["UserRole"].ToString().Contains("出厂维修预算"))
                    || (Lab_Status.Text == "EMCcFinan" && Session["UserRole"].ToString().Contains("出厂维修财务审核"))
                    || (Lab_Status.Text == "EMCcConfirmor" && Session["UserRole"].ToString().Contains("出厂维修出厂确认"))
                    || (Lab_Status.Text == "EMCcAct" && Session["UserRole"].ToString().Contains("出厂维修回厂信息完善"))
                    || (Lab_Status.Text == "EMCcFinanConfirmor" && Session["UserRole"].ToString().Contains("出厂维修财务确认"))
                    || (Lab_Status.Text == "EMCcLook" && Session["UserRole"].ToString().Contains("出厂维修查看")))
        {
            temp += " and a.EMA_AppState='已确认'";
        }
        if (Lab_Status.Text == "EMWxCheck" && Session["UserRole"].ToString().Contains("设备故障维修验收"))
        {
            temp += " and a.EMA_AppState='已完成'";
        }
        if (Lab_Status.Text == "EMWxLook" && Session["UserRole"].ToString().Contains("设备故障维修查看"))
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
        DropDownList5.Items.Insert(0, new ListItem("请选择", ""));
        BindDropDownList5();
        string ETT_Type = "";
        string EN_EquipName = "";
        string EMT_Type = "";
        string EI_No = "";
        BindGrid_EquipInfo(ETT_Type, EN_EquipName, EMT_Type, EI_No);
        Grid_EquipInfo.Columns[9].Visible = true;
        Grid_EquipInfo.Columns[10].Visible = false;
        Grid_EquipInfo.Columns[11].Visible = false;
        Panel_CN.Visible = false;
        UpdatePanel_CN.Update();
        Panel_dealCN.Visible = false;
        UpdatePanel_dealCN.Update();
        Panel_New.Visible = false;
        UpdatePanel_New.Update();
    }
    //私有清空的方法
    private void Clear()
    {
        DropDownList5.Items.Insert(0, new ListItem("请选择", ""));
        BindDropDownList5();
        infoname.Text = "";
        infomodel.Text = "";
        infono.Text = "";
        TextBreakDownTime.Text = "";
        DropDownList6.Items.Insert(0, new ListItem("请选择", ""));
        BindDropDownList6();
        TextBDDetail.Text = "";
        cnReason.Text = "";
        cnRemarks.Text = "";
        DropDownList7.Items.Insert(0, new ListItem("请选择", ""));
        BindDropDownList7();
        ccPlace.Text = "";
        ccFeature.Text = "";
        ccOReson.Text = "";
    }
    #endregion 检索设备维修信息

    #region 设备维修信息Grid_MaintenanceApp
    protected void Grid_MaintenanceApp_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Look1")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_MaintenanceApp.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string ETT_Type = al[0];
            TextBox14.Text = ETT_Type;
            string EN_EquipName = al[1];
            TextBox3.Text = EN_EquipName;
            string EMT_Type = al[2];
            TextBox4.Text = EMT_Type;
            string EI_No = al[3];
            TextBox5.Text = EI_No;
            string EMA_AppDep = al[4];
            BindDropDownList6();
            DropDownList6.Items.FindByText(EMA_AppDep.ToString().Trim()).Selected = true;
            DateTime EMA_BreakDownTime = Convert.ToDateTime(al[5].ToString());
            TextBreakDownTime.Text = EMA_BreakDownTime.ToString("yyyy-MM-dd HH:mm:ss");
            string EMA_AppPer = al[6];
            TextAppPer.Text = EMA_AppPer;
            DateTime EMA_AppTime = Convert.ToDateTime(al[7].ToString());
            TextAppTime.Text = EMA_AppTime.ToString("yyyy-MM-dd HH:mm:ss");
            string EMA_BDDetail = al[8];
            TextBDDetail.Text = EMA_BDDetail;
            string EMA_AppState = al[9];
            TextAppState.Text = EMA_AppState;
            string EMA_AppNO = al[10];
            TextAppNO.Text = EMA_AppNO;
            string EMA_AckPer = al[11];
            TextAckPer.Text = EMA_AckPer;
            if (al[12].ToString() == "")
            {
                TextAckTime.Text = "";
            }
            else
            {
                DateTime EMA_AckTime = Convert.ToDateTime(al[12].ToString());
                TextAckTime.Text = EMA_AckTime.ToString("yyyy-MM-dd HH:mm:ss");
            }
            string EMA_CheckPer = al[13];
            TextCheckPer.Text = EMA_CheckPer;
            if (al[14].ToString() == "")
            {
                TextCheckTime.Text = "";
            }
            else
            {
                DateTime EMA_CheckTime = Convert.ToDateTime(al[14].ToString());
                TextCheckTime.Text = EMA_CheckTime.ToString("yyyy-MM-dd HH:mm:ss");
            }
            string EMA_CheckRes = al[15];
            TextCheckRes.Text = EMA_CheckRes;
            string EMA_CheckSugg = al[16];
            TextCheckSugg.Text = EMA_CheckSugg;
            string EMA_ID = al[17];
            Label_emaid.Text = EMA_ID;

            Panel_New.Visible = true;
            Panel1.Visible = true;
            Panel1.Enabled = false;
            Panel2.Visible = true;
            Panel2.Enabled = false;
            Panel3.Visible = true;
            Panel3.Enabled = false;
            Panel4.Visible = false;
            Panel5.Visible = false;
            Panel6.Visible = false;
            Panel7.Visible = false;
            Panel8.Visible = true;
            UpdatePanel_New.Update();
            //厂内
            BindGridView_CN("and a.EMA_ID='"+ Label_emaid.Text.ToString()+"'");
            choosereal.Visible = false;
            GridView_CN.Columns[13].Visible = true;
            GridView_CN.Columns[14].Visible = false;
            GridView_CN.Columns[15].Visible = false;
            //出厂
            BindGridView_CC("and a.EMA_ID='" + Label_emaid.Text.ToString() + "'");
            choosereal_cc.Visible = false;//选择出厂维修设备
            GridView_CC.Columns[11].Visible = false;//出厂申请时间
            GridView_CC.Columns[13].Visible = false;//出厂维修地点
            GridView_CC.Columns[17].Visible = false;//出厂申请审批时间
            GridView_CC.Columns[19].Visible = false;//出厂申请审批结果
            GridView_CC.Columns[20].Visible = false;//预计出厂日期
            GridView_CC.Columns[21].Visible = false;//预计回厂日期
            GridView_CC.Columns[22].Visible = false;//预计费用
            GridView_CC.Columns[24].Visible = false;//记录日期
            GridView_CC.Columns[26].Visible = false;//财务审核时间
            GridView_CC.Columns[28].Visible = false;//财务审核结果
            GridView_CC.Columns[30].Visible = false;//出厂确认时间
            GridView_CC.Columns[31].Visible = false;//实际出厂时间
            GridView_CC.Columns[32].Visible = false;//实际回厂时间
            GridView_CC.Columns[33].Visible = false;//实际维修费用
            GridView_CC.Columns[35].Visible = false;//完善时间
            GridView_CC.Columns[37].Visible = false;//财务确认时间

            GridView_CC.Columns[39].Visible = false;//选择备件
            GridView_CC.Columns[40].Visible = false;//出厂维修审批
            GridView_CC.Columns[41].Visible = false;//出厂维修预算
            GridView_CC.Columns[42].Visible = false;//财务审核
            GridView_CC.Columns[43].Visible = false;//出厂维修确认
            GridView_CC.Columns[44].Visible = false;//完善回厂信息
            GridView_CC.Columns[45].Visible = false;//财务确认
            GridView_CC.Columns[46].Visible = false;//删除

            Panel13.Visible = false;
            Panel14.Visible = true;
            Panel_CN.Visible = true;
            UpdatePanel_CN.Update();
        }
        if (e.CommandName == "Edit1")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_MaintenanceApp.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string EMA_ID = al[0];
            Label_emaid.Text = EMA_ID;
            string ETT_Type = al[1];
            TextBox14.Text = ETT_Type;
            string EN_EquipName = al[2];
            TextBox3.Text = EN_EquipName;
            string EMT_Type = al[3];
            TextBox4.Text = EMT_Type;
            string EI_No = al[4];
            TextBox5.Text = EI_No;
            string EMA_AppDep = al[5];
            BindDropDownList6();
            DropDownList6.Items.FindByText(EMA_AppDep.ToString().Trim()).Selected = true;
            DateTime EMA_BreakDownTime = Convert.ToDateTime(al[6].ToString());
            TextBreakDownTime.Text = EMA_BreakDownTime.ToString("yyyy-MM-dd HH:mm:ss");
            string EMA_AppPer = al[7];
            TextAppPer.Text = EMA_AppPer;
            DateTime EMA_AppTime = Convert.ToDateTime(al[8].ToString());
            TextAppTime.Text = EMA_AppTime.ToString("yyyy-MM-dd HH:mm:ss");
            string EMA_BDDetail = al[9];
            TextBDDetail.Text = EMA_BDDetail;
            string EMA_AppState = al[10];
            if (EMA_AppState != "待提交")
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel_MaintenanceApp, GetType(), "alert", "alert('此状态下不可编辑，请重提申请！')", true);
                return;
            }
            TextAppState.Text = EMA_AppState;
            string EMA_AppNO = al[11];
            TextAppNO.Text = EMA_AppNO;

            Panel_New.Visible = true;
            Panel1.Visible = true;
            Panel1.Enabled = true;
            Panel2.Visible = false;
            Panel2.Enabled = false;
            Panel3.Visible = false;
            Panel3.Enabled = false;
            Panel4.Visible = false;
            Panel5.Visible = true;
            Panel6.Visible = false;
            Panel7.Visible = false;
            Panel8.Visible = false;
            UpdatePanel_New.Update();
            Panel_searchInf.Visible = false;
        }
        if (e.CommandName == "Ack1")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_MaintenanceApp.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string EMA_ID = al[0];
            Label_emaid.Text = EMA_ID;
            string ETT_Type = al[1];
            TextBox14.Text = ETT_Type;
            string EN_EquipName = al[2];
            TextBox3.Text = EN_EquipName;
            string EMT_Type = al[3];
            TextBox4.Text = EMT_Type;
            string EI_No = al[4];
            TextBox5.Text = EI_No;
            string EMA_AppDep = al[5];
            BindDropDownList6();
            DropDownList6.Items.FindByText(EMA_AppDep.ToString().Trim()).Selected = true;
            DateTime EMA_BreakDownTime = Convert.ToDateTime(al[6].ToString());
            TextBreakDownTime.Text = EMA_BreakDownTime.ToString("yyyy-MM-dd HH:mm:ss");
            string EMA_AppPer = al[7];
            TextAppPer.Text = EMA_AppPer;
            DateTime EMA_AppTime = Convert.ToDateTime(al[8].ToString());
            TextAppTime.Text = EMA_AppTime.ToString("yyyy-MM-dd HH:mm:ss");
            string EMA_BDDetail = al[9];
            TextBDDetail.Text = EMA_BDDetail;
            string EMA_AppState = al[10];
            TextAppState.Text = EMA_AppState;
            string EMA_AppNO = al[11];
            TextAppNO.Text = EMA_AppNO;
            TextAckTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            TextAckPer.Text = Session["UserName"].ToString().Trim();

            Panel_New.Visible = true;
            Panel1.Visible = true;
            Panel1.Enabled = false;
            Panel2.Visible = true;
            Panel2.Enabled = true;
            Panel3.Visible = false;
            Panel3.Enabled = false;
            Panel4.Visible = false;
            Panel5.Visible = false;
            Panel6.Visible = true;
            Panel7.Visible = false;
            Panel8.Visible = false;
            UpdatePanel_New.Update();
        }
        if (e.CommandName == "Deal1")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_MaintenanceApp.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string EMA_ID = al[0];
            Label_emaid.Text = EMA_ID;
            DateTime EMA_AckTime =  Convert.ToDateTime( al[1]);
            Label_acktime.Text = EMA_AckTime.ToString();
            string EMA_AppNO = al[2];
            Label_appno.Text = EMA_AppNO;
            string EMA_AppPer = al[3];
            Label_appper.Text = EMA_AppPer;

            if (Lab_Status.Text == "EMCnDeal" && Session["UserRole"].ToString().Contains("设备故障维修情况记录"))
            {
                choosereal.Visible = true;//选择厂内维修设备
                BindGridView_CN("and a.EMA_ID='" + Label_emaid.Text.ToString() + "'");
                GridView_CN.Columns[13].Visible = false;
                GridView_CN.Columns[14].Visible = true;
                GridView_CN.Columns[15].Visible = true;
                Panel13.Visible = true;
                Panel14.Visible = false;

                choosereal_cc.Visible = true;//选择出厂维修设备
                GridView_CC.Columns[11].Visible = false;//出厂申请时间
                GridView_CC.Columns[13].Visible = false;//出厂维修地点
                GridView_CC.Columns[17].Visible = false;//出厂申请审批时间
                GridView_CC.Columns[20].Visible = false;//预计出厂日期
                GridView_CC.Columns[21].Visible = false;//预计回厂日期
                GridView_CC.Columns[22].Visible = false;//预计费用
                GridView_CC.Columns[24].Visible = false;//记录日期
                GridView_CC.Columns[26].Visible = false;//财务审核时间
                GridView_CC.Columns[30].Visible = false;//出厂确认时间
                GridView_CC.Columns[31].Visible = false;//实际出厂时间
                GridView_CC.Columns[32].Visible = false;//实际回厂时间
                GridView_CC.Columns[33].Visible = false;//实际维修费用
                GridView_CC.Columns[35].Visible = false;//完善时间
                GridView_CC.Columns[37].Visible = false;//财务确认时间

                GridView_CC.Columns[38].Visible = true;//查看详情
                GridView_CC.Columns[39].Visible = true;//选择备件
                GridView_CC.Columns[40].Visible = false;//出厂维修审批
                GridView_CC.Columns[41].Visible = false;//出厂维修预算
                GridView_CC.Columns[42].Visible = false;//财务审核
                GridView_CC.Columns[43].Visible = false;//出厂维修确认
                GridView_CC.Columns[44].Visible = false;//完善回厂信息
                GridView_CC.Columns[45].Visible = false;//财务确认
                //string condition3 = GetCondition3();//绑定出厂维修信息表GridView_CC中的各权限设置
                //BindGridView_CC(condition3);
                BindGridView_CC("and a.EMA_ID='" + Label_emaid.Text.ToString() + "'");
            }
            if (Lab_Status.Text == "EMCcApp" && Session["UserRole"].ToString().Contains("出厂维修审批"))
            {
                choosereal.Visible = false;//选择厂内维修设备
                BindGridView_CN("and a.EMA_ID='" + Label_emaid.Text.ToString() + "'");
                GridView_CN.Columns[13].Visible = true;
                GridView_CN.Columns[14].Visible = false;
                GridView_CN.Columns[15].Visible = false;

                choosereal_cc.Visible = false;//选择出厂维修设备
                GridView_CC.Columns[16].Visible = false;//出厂申请审批人
                GridView_CC.Columns[17].Visible = false;//出厂申请审批时间
                GridView_CC.Columns[19].Visible = false;//出厂申请审批结果
                GridView_CC.Columns[20].Visible = false;//预计出厂日期
                GridView_CC.Columns[21].Visible = false;//预计回厂日期
                GridView_CC.Columns[22].Visible = false;//预计费用
                GridView_CC.Columns[23].Visible = false;//负责人
                GridView_CC.Columns[24].Visible = false;//记录日期
                GridView_CC.Columns[25].Visible = false;//财务审核人
                GridView_CC.Columns[26].Visible = false;//财务审核时间
                GridView_CC.Columns[28].Visible = false;//财务审核结果
                GridView_CC.Columns[29].Visible = false;//出厂确认人
                GridView_CC.Columns[30].Visible = false;//出厂确认时间
                GridView_CC.Columns[31].Visible = false;//实际出厂时间
                GridView_CC.Columns[32].Visible = false;//实际回厂时间
                GridView_CC.Columns[33].Visible = false;//实际维修费用
                GridView_CC.Columns[34].Visible = false;//完善人
                GridView_CC.Columns[35].Visible = false;//完善时间
                GridView_CC.Columns[36].Visible = false;//财务确认人
                GridView_CC.Columns[37].Visible = false;//财务确认时间

                GridView_CC.Columns[38].Visible = false;//查看详情
                GridView_CC.Columns[39].Visible = false;//选择备件
                GridView_CC.Columns[41].Visible = false;//出厂维修预算
                GridView_CC.Columns[42].Visible = false;//财务审核
                GridView_CC.Columns[43].Visible = false;//出厂维修确认
                GridView_CC.Columns[44].Visible = false;//完善回厂信息
                GridView_CC.Columns[45].Visible = false;//财务确认
                GridView_CC.Columns[46].Visible = false;//删除
                string condition3 = GetCondition3();//绑定出厂维修信息表GridView_CC中的各权限设置
                BindGridView_CC(condition3);
                Panel13.Visible = false;
                Panel14.Visible = true;
            }
            if (Lab_Status.Text == "EMCcExpect" && Session["UserRole"].ToString().Contains("出厂维修预算"))
            {
                choosereal.Visible = false;//选择厂内维修设备
                BindGridView_CN("and a.EMA_ID='" + Label_emaid.Text.ToString() + "'");
                GridView_CN.Columns[13].Visible = true;
                GridView_CN.Columns[14].Visible = false;
                GridView_CN.Columns[15].Visible = false;

                choosereal_cc.Visible = false;//选择出厂维修设备
                GridView_CC.Columns[10].Visible = false;//出厂维修申请人
                GridView_CC.Columns[11].Visible = false;//出厂申请时间
                GridView_CC.Columns[13].Visible = false ;//出厂维修地点
                GridView_CC.Columns[16].Visible = false;//出厂申请审批人
                GridView_CC.Columns[17].Visible = false;//出厂申请审批时间
                GridView_CC.Columns[20].Visible = false;//预计出厂日期
                GridView_CC.Columns[21].Visible = false;//预计回厂日期
                GridView_CC.Columns[22].Visible = false;//预计费用
                GridView_CC.Columns[23].Visible = false;//负责人
                GridView_CC.Columns[24].Visible = false;//记录日期
                GridView_CC.Columns[26].Visible = false;//财务审核时间
                GridView_CC.Columns[29].Visible = false;//出厂确认人
                GridView_CC.Columns[30].Visible = false;//出厂确认时间
                GridView_CC.Columns[31].Visible = false;//实际出厂时间
                GridView_CC.Columns[32].Visible = false;//实际回厂时间
                GridView_CC.Columns[33].Visible = false;//实际维修费用
                GridView_CC.Columns[34].Visible = false;//完善人
                GridView_CC.Columns[35].Visible = false;//完善时间
                GridView_CC.Columns[36].Visible = false;//财务确认人
                GridView_CC.Columns[37].Visible = false;//财务确认时间

                GridView_CC.Columns[38].Visible = false;//查看详情
                GridView_CC.Columns[39].Visible = false;//选择备件
                GridView_CC.Columns[40].Visible = false;//出厂维修审批
                GridView_CC.Columns[42].Visible = false;//财务审核
                GridView_CC.Columns[43].Visible = false;//出厂维修确认
                GridView_CC.Columns[44].Visible = false;//完善回厂信息
                GridView_CC.Columns[45].Visible = false;//财务确认
                GridView_CC.Columns[46].Visible = false;//删除
                string condition3 = GetCondition3();//绑定出厂维修信息表GridView_CC中的各权限设置
                BindGridView_CC(condition3);
                Panel13.Visible = false;
                Panel14.Visible = true;
            }
            if (Lab_Status.Text == "EMCcFinan" && Session["UserRole"].ToString().Contains("出厂维修财务审核"))
            {
                choosereal.Visible = false;//选择厂内维修设备
                BindGridView_CN("and a.EMA_ID='" + Label_emaid.Text.ToString() + "'");
                GridView_CN.Columns[13].Visible = true;
                GridView_CN.Columns[14].Visible = false;
                GridView_CN.Columns[15].Visible = false;

                choosereal_cc.Visible = false;//选择出厂维修设备
                GridView_CC.Columns[9].Visible = false;//出厂维修申请部门
                GridView_CC.Columns[10].Visible = false;//出厂维修申请人
                GridView_CC.Columns[11].Visible = false;//出厂申请时间
                GridView_CC.Columns[13].Visible = false;//出厂维修地点
                GridView_CC.Columns[16].Visible = false;//出厂申请审批人
                GridView_CC.Columns[17].Visible = false;//出厂申请审批时间
                GridView_CC.Columns[19].Visible = false;//出厂申请审批结果
                GridView_CC.Columns[24].Visible = false;//记录日期
                GridView_CC.Columns[25].Visible = false;//财务审核人
                GridView_CC.Columns[26].Visible = false;//财务审核时间
                GridView_CC.Columns[28].Visible = false;//财务审核结果
                GridView_CC.Columns[29].Visible = false;//出厂确认人
                GridView_CC.Columns[30].Visible = false;//出厂确认时间
                GridView_CC.Columns[31].Visible = false;//实际出厂时间
                GridView_CC.Columns[32].Visible = false;//实际回厂时间
                GridView_CC.Columns[33].Visible = false;//实际维修费用
                GridView_CC.Columns[34].Visible = false;//完善人
                GridView_CC.Columns[35].Visible = false;//完善时间
                GridView_CC.Columns[36].Visible = false;//财务确认人
                GridView_CC.Columns[37].Visible = false;//财务确认时间

                GridView_CC.Columns[38].Visible = false;//查看详情
                GridView_CC.Columns[39].Visible = false;//选择备件
                GridView_CC.Columns[40].Visible = false;//出厂维修审批
                GridView_CC.Columns[41].Visible = false;//出厂维修预算
                GridView_CC.Columns[43].Visible = false;//出厂维修确认
                GridView_CC.Columns[44].Visible = false;//完善回厂信息
                GridView_CC.Columns[45].Visible = false;//财务确认
                GridView_CC.Columns[46].Visible = false;//删除
                string condition3 = GetCondition3();//绑定出厂维修信息表GridView_CC中的各权限设置
                BindGridView_CC(condition3);
                Panel13.Visible = false;
                Panel14.Visible = true;
            }
            if (Lab_Status.Text == "EMCcConfirmor" && Session["UserRole"].ToString().Contains("出厂维修出厂确认"))
            {
                choosereal.Visible = false;//选择厂内维修设备
                BindGridView_CN("and a.EMA_ID='" + Label_emaid.Text.ToString() + "'");
                GridView_CN.Columns[13].Visible = true;
                GridView_CN.Columns[14].Visible = false;
                GridView_CN.Columns[15].Visible = false;

                choosereal_cc.Visible = false;//选择出厂维修设备
                GridView_CC.Columns[10].Visible = false;//出厂维修申请人
                GridView_CC.Columns[11].Visible = false;//出厂申请时间
                GridView_CC.Columns[13].Visible = false;//出厂维修地点
                GridView_CC.Columns[16].Visible = false;//出厂申请审批人
                GridView_CC.Columns[17].Visible = false;//出厂申请审批时间
                GridView_CC.Columns[20].Visible = false;//预计出厂日期
                GridView_CC.Columns[21].Visible = false;//预计回厂日期
                GridView_CC.Columns[22].Visible = false;//预计费用
                GridView_CC.Columns[24].Visible = false;//记录日期
                GridView_CC.Columns[25].Visible = false;//财务审核人
                GridView_CC.Columns[26].Visible = false;//财务审核时间
                GridView_CC.Columns[29].Visible = false;//出厂确认人
                GridView_CC.Columns[30].Visible = false;//出厂确认时间
                GridView_CC.Columns[31].Visible = false;//实际出厂时间
                GridView_CC.Columns[32].Visible = false;//实际回厂时间
                GridView_CC.Columns[33].Visible = false;//实际维修费用
                GridView_CC.Columns[34].Visible = false;//完善人
                GridView_CC.Columns[35].Visible = false;//完善时间
                GridView_CC.Columns[36].Visible = false;//财务确认人
                GridView_CC.Columns[37].Visible = false;//财务确认时间

                GridView_CC.Columns[38].Visible = false;//查看详情
                GridView_CC.Columns[39].Visible = false;//选择备件
                GridView_CC.Columns[40].Visible = false;//出厂维修审批
                GridView_CC.Columns[41].Visible = false;//出厂维修预算
                GridView_CC.Columns[42].Visible = false;//财务审核
                GridView_CC.Columns[44].Visible = false;//完善回厂信息
                GridView_CC.Columns[45].Visible = false;//财务确认
                GridView_CC.Columns[46].Visible = false;//删除
                string condition3 = GetCondition3();//绑定出厂维修信息表GridView_CC中的各权限设置
                BindGridView_CC(condition3);
                Panel13.Visible = false;
                Panel14.Visible = true;
            }
            if (Lab_Status.Text == "EMCcAct" && Session["UserRole"].ToString().Contains("出厂维修回厂信息完善"))
            {
                choosereal.Visible = false;//选择厂内维修设备
                BindGridView_CN("and a.EMA_ID='" + Label_emaid.Text.ToString() + "'");
                GridView_CN.Columns[13].Visible = true;
                GridView_CN.Columns[14].Visible = false;
                GridView_CN.Columns[15].Visible = false;

                choosereal_cc.Visible = false;//选择出厂维修设备
                GridView_CC.Columns[10].Visible = false;//出厂维修申请人
                GridView_CC.Columns[11].Visible = false;//出厂申请时间
                GridView_CC.Columns[13].Visible = false;//出厂维修地点
                GridView_CC.Columns[16].Visible = false;//出厂申请审批人
                GridView_CC.Columns[17].Visible = false;//出厂申请审批时间
                GridView_CC.Columns[19].Visible = false;//出厂申请审批结果
                GridView_CC.Columns[20].Visible = false;//预计出厂日期
                GridView_CC.Columns[21].Visible = false;//预计回厂日期
                GridView_CC.Columns[22].Visible = false;//预计费用
                GridView_CC.Columns[24].Visible = false;//记录日期
                GridView_CC.Columns[26].Visible = false;//财务审核时间
                GridView_CC.Columns[28].Visible = false;//财务审核结果
                GridView_CC.Columns[30].Visible = false;//出厂确认时间
                GridView_CC.Columns[31].Visible = false;//实际出厂时间
                GridView_CC.Columns[32].Visible = false;//实际回厂时间
                GridView_CC.Columns[33].Visible = false;//实际维修费用
                GridView_CC.Columns[34].Visible = false;//完善人
                GridView_CC.Columns[35].Visible = false;//完善时间
                GridView_CC.Columns[36].Visible = false;//财务确认人
                GridView_CC.Columns[37].Visible = false;//财务确认时间

                GridView_CC.Columns[38].Visible = false;//查看详情
                GridView_CC.Columns[39].Visible = false;//选择备件
                GridView_CC.Columns[40].Visible = false;//出厂维修审批
                GridView_CC.Columns[41].Visible = false;//出厂维修预算
                GridView_CC.Columns[42].Visible = false;//财务审核
                GridView_CC.Columns[43].Visible = false;//出厂维修确认
                GridView_CC.Columns[45].Visible = false;//财务确认
                GridView_CC.Columns[46].Visible = false;//删除
                string condition3 = GetCondition3();//绑定出厂维修信息表GridView_CC中的各权限设置
                BindGridView_CC(condition3);
                Panel13.Visible = false;
                Panel14.Visible = true;
            }
            if (Lab_Status.Text == "EMCcFinanConfirmor" && Session["UserRole"].ToString().Contains("出厂维修财务确认"))
            {
                choosereal.Visible = false;//选择厂内维修设备
                BindGridView_CN("and a.EMA_ID='" + Label_emaid.Text.ToString() + "'");
                GridView_CN.Columns[13].Visible = true;
                GridView_CN.Columns[14].Visible = false;
                GridView_CN.Columns[15].Visible = false;

                choosereal_cc.Visible = false;//选择出厂维修设备
                GridView_CC.Columns[10].Visible = false;//出厂维修申请人
                GridView_CC.Columns[11].Visible = false;//出厂申请时间
                GridView_CC.Columns[13].Visible = false;//出厂维修地点
                GridView_CC.Columns[16].Visible = false;//出厂申请审批人
                GridView_CC.Columns[17].Visible = false;//出厂申请审批时间
                GridView_CC.Columns[19].Visible = false;//出厂申请审批结果
                GridView_CC.Columns[20].Visible = false;//预计出厂日期
                GridView_CC.Columns[21].Visible = false;//预计回厂日期
                GridView_CC.Columns[22].Visible = false;//预计费用
                GridView_CC.Columns[24].Visible = false;//记录日期
                GridView_CC.Columns[26].Visible = false;//财务审核时间
                GridView_CC.Columns[28].Visible = false;//财务审核结果
                GridView_CC.Columns[29].Visible = false;//出厂确认人
                GridView_CC.Columns[30].Visible = false;//出厂确认时间
                GridView_CC.Columns[31].Visible = false;//实际出厂时间
                GridView_CC.Columns[32].Visible = false;//实际回厂时间
                GridView_CC.Columns[33].Visible = false;//实际维修费用
                GridView_CC.Columns[35].Visible = false;//完善时间
                GridView_CC.Columns[36].Visible = false;//财务确认人
                GridView_CC.Columns[37].Visible = false;//财务确认时间

                GridView_CC.Columns[38].Visible = false;//查看详情
                GridView_CC.Columns[39].Visible = false;//选择备件
                GridView_CC.Columns[40].Visible = false;//出厂维修审批
                GridView_CC.Columns[41].Visible = false;//出厂维修预算
                GridView_CC.Columns[42].Visible = false;//财务审核
                GridView_CC.Columns[43].Visible = false;//出厂维修确认
                GridView_CC.Columns[44].Visible = false;//完善回厂信息
                GridView_CC.Columns[46].Visible = false;//删除
                string condition3 = GetCondition3();//绑定出厂维修信息表GridView_CC中的各权限设置
                BindGridView_CC(condition3);
                Panel13.Visible = false;
                Panel14.Visible = true;
            }
            if (Lab_Status.Text == "EMCcLook" && Session["UserRole"].ToString().Contains("出厂维修查看"))
            {
                choosereal.Visible = false;//选择厂内维修设备
                BindGridView_CN("and a.EMA_ID='" + Label_emaid.Text.ToString() + "'");
                GridView_CN.Columns[13].Visible = true;
                GridView_CN.Columns[14].Visible = false;
                GridView_CN.Columns[15].Visible = false;

                choosereal_cc.Visible = false;//选择出厂维修设备
                GridView_CC.Columns[11].Visible = false;//出厂申请时间
                GridView_CC.Columns[13].Visible = false;//出厂维修地点
                GridView_CC.Columns[17].Visible = false;//出厂申请审批时间
                GridView_CC.Columns[20].Visible = false;//预计出厂日期
                GridView_CC.Columns[21].Visible = false;//预计回厂日期
                GridView_CC.Columns[22].Visible = false;//预计费用
                GridView_CC.Columns[24].Visible = false;//记录日期
                GridView_CC.Columns[26].Visible = false;//财务审核时间
                GridView_CC.Columns[30].Visible = false;//出厂确认时间
                GridView_CC.Columns[31].Visible = false;//实际出厂时间
                GridView_CC.Columns[32].Visible = false;//实际回厂时间
                GridView_CC.Columns[33].Visible = false;//实际维修费用
                GridView_CC.Columns[35].Visible = false;//完善时间
                GridView_CC.Columns[37].Visible = false;//财务确认时间

                GridView_CC.Columns[39].Visible = false;//选择备件
                GridView_CC.Columns[40].Visible = false;//出厂维修审批
                GridView_CC.Columns[41].Visible = false;//出厂维修预算
                GridView_CC.Columns[42].Visible = false;//财务审核
                GridView_CC.Columns[43].Visible = false;//出厂维修确认
                GridView_CC.Columns[44].Visible = false;//完善回厂信息
                GridView_CC.Columns[45].Visible = false;//财务确认
                GridView_CC.Columns[46].Visible = false;//删除
                string condition3 = GetCondition3();//绑定出厂维修信息表GridView_CC中的各权限设置
                BindGridView_CC(condition3);
                Panel13.Visible = false;
                Panel14.Visible = true;
            }

            Panel_CN.Visible = true;
            UpdatePanel_CN.Update();
            Panel_New.Visible = false;
            UpdatePanel_New.Update();
        }
        if (e.CommandName == "Check1")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_MaintenanceApp.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string EMA_ID = al[0];
            Label_emaid.Text = EMA_ID;
            string ETT_Type = al[1];
            TextBox14.Text = ETT_Type;
            string EN_EquipName = al[2];
            TextBox3.Text = EN_EquipName;
            string EMT_Type = al[3];
            TextBox4.Text = EMT_Type;
            string EI_No = al[4];
            TextBox5.Text = EI_No;
            string EMA_AppDep = al[5];
            BindDropDownList6();
            DropDownList6.Items.FindByText(EMA_AppDep.ToString().Trim()).Selected = true;
            DateTime EMA_BreakDownTime = Convert.ToDateTime(al[6].ToString());
            TextBreakDownTime.Text = EMA_BreakDownTime.ToString("yyyy-MM-dd HH:mm:ss");
            string EMA_AppPer = al[7];
            TextAppPer.Text = EMA_AppPer;
            DateTime EMA_AppTime = Convert.ToDateTime(al[8].ToString());
            TextAppTime.Text = EMA_AppTime.ToString("yyyy-MM-dd HH:mm:ss");
            string EMA_BDDetail = al[9];
            TextBDDetail.Text = EMA_BDDetail;
            string EMA_AppState = al[10];
            TextAppState.Text = EMA_AppState;
            string EMA_AppNO = al[11];
            TextAppNO.Text = EMA_AppNO;
            string EMA_AckPer = al[12];
            TextAckPer.Text = EMA_AckPer;
            DateTime EMA_AckTime = Convert.ToDateTime(al[13].ToString());
            TextAckTime.Text = EMA_AckTime.ToString("yyyy-MM-dd HH:mm:ss");
            TextCheckTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            TextCheckPer.Text = Session["UserName"].ToString().Trim();

            //厂内
            BindGridView_CN("and a.EMA_ID='" + Label_emaid.Text.ToString() + "'");
            choosereal.Visible = false;
            GridView_CN.Columns[13].Visible = true;
            GridView_CN.Columns[14].Visible = false;
            GridView_CN.Columns[15].Visible = false;
            //出厂
            BindGridView_CC("and a.EMA_ID='" + Label_emaid.Text.ToString() + "' and a.ERDAOA_OAppState='已完成'");
            choosereal_cc.Visible = false;//选择出厂维修设备
            GridView_CC.Columns[11].Visible = false;//出厂申请时间
            GridView_CC.Columns[13].Visible = false;//出厂维修地点
            GridView_CC.Columns[17].Visible = false;//出厂申请审批时间
            GridView_CC.Columns[20].Visible = false;//预计出厂日期
            GridView_CC.Columns[21].Visible = false;//预计回厂日期
            GridView_CC.Columns[22].Visible = false;//预计费用
            GridView_CC.Columns[24].Visible = false;//记录日期
            GridView_CC.Columns[26].Visible = false;//财务审核时间
            GridView_CC.Columns[30].Visible = false;//出厂确认时间
            GridView_CC.Columns[31].Visible = false;//实际出厂时间
            GridView_CC.Columns[32].Visible = false;//实际回厂时间
            GridView_CC.Columns[33].Visible = false;//实际维修费用
            GridView_CC.Columns[35].Visible = false;//完善时间
            GridView_CC.Columns[37].Visible = false;//财务确认时间

            GridView_CC.Columns[39].Visible = false;//选择备件
            GridView_CC.Columns[40].Visible = false;//出厂维修审批
            GridView_CC.Columns[41].Visible = false;//出厂维修预算
            GridView_CC.Columns[42].Visible = false;//财务审核
            GridView_CC.Columns[43].Visible = false;//出厂维修确认
            GridView_CC.Columns[44].Visible = false;//完善回厂信息
            GridView_CC.Columns[45].Visible = false;//财务确认
            GridView_CC.Columns[46].Visible = false;//删除
            Panel13.Visible = false;
            Panel14.Visible = true;

            Panel_New.Visible = true;
            Panel1.Visible = true;
            Panel1.Enabled = false;
            Panel2.Visible = true;
            Panel2.Enabled = false;
            Panel3.Visible = true;
            Panel3.Enabled = true;
            Panel4.Visible = false;
            Panel5.Visible = false;
            Panel6.Visible = false;
            Panel7.Visible = true;
            Panel8.Visible = false;
            Label34.Visible = false;
            TextCheckRes.Visible = false;
            UpdatePanel_New.Update();

            Panel_CN.Visible = true;
            BindGridView_CN("and a.EMA_ID='" + Label_emaid.Text.ToString() + "'");
            Label44.Visible = false;
            choosereal.Visible = false;
            GridView_CN.Columns[13].Visible = true;
            GridView_CN.Columns[14].Visible = false;
            GridView_CN.Columns[15].Visible = false;
            Panel13.Visible = false;
            Panel14.Visible = true;
            UpdatePanel_CN.Update();
            Panel_dealCN.Visible = false;
            UpdatePanel_dealCN.Update();
        }
        if (e.CommandName == "Delete1")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_MaintenanceApp.SelectedIndex = row.RowIndex;

            //Guid EMA_ID = new Guid(Convert.ToString(e.CommandArgument));
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            Guid EMA_ID = new Guid(al[0]);
            Label_emaid.Text = EMA_ID.ToString();
            if (al[1] != "待提交")
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel_MaintenanceApp, GetType(), "alert", "alert('此状态下不可删除！')", true);
                return;
            }
            equipMaintenanceAppL.Delete_EquipMaintenanceApp(EMA_ID);
            //BindGrid_MaintenanceApp("and (a.EMA_AppState='待提交' or (a.EMA_AppState='已验收' and EMA_CheckRes='不通过'))");
            BindGrid_MaintenanceApp("");
            UpdatePanel_MaintenanceApp.Update();
        }
    }
    protected string GetCondition3()
    {
        string condition3;
        string temp = "";
        if (Lab_Status.Text == "EMCnDeal" && Session["UserRole"].ToString().Contains("设备故障维修情况记录"))
        {
            //temp += " and (a.ERDAOA_OAppState='待提交' or (a.ERDAOA_ApprovalRes='不通过' and a.ERDAOA_OAppState='已审批') or a.ERDAOA_OAppState='已完成')";
            temp += "";
        }
        if (Lab_Status.Text == "EMCcApp" && Session["UserRole"].ToString().Contains("出厂维修审批"))
        {
            temp += " and a.ERDAOA_OAppState='已提交'";
        }
        if (Lab_Status.Text == "EMCcExpect" && Session["UserRole"].ToString().Contains("出厂维修预算"))
        {
            temp += " and ((a.ERDAOA_OAppState='已审批' and a.ERDAOA_ApprovalRes='通过') or a.ERDAOA_FinanRes='不通过')";
        }
        if (Lab_Status.Text == "EMCcFinan" && Session["UserRole"].ToString().Contains("出厂维修财务审核"))
        {
            temp += " and a.ERDAOA_OAppState='已预算'";
        }
        if (Lab_Status.Text == "EMCcConfirmor" && Session["UserRole"].ToString().Contains("出厂维修出厂确认"))
        {
            temp += " and a.ERDAOA_OAppState='财务已审' and a.ERDAOA_FinanRes='通过'";
        }
        if (Lab_Status.Text == "EMCcAct" && Session["UserRole"].ToString().Contains("出厂维修回厂信息完善"))
        {
            temp += " and a.ERDAOA_OAppState='已出厂'";
        }
        if (Lab_Status.Text == "EMCcFinanConfirmor" && Session["UserRole"].ToString().Contains("出厂维修财务确认"))
        {
            temp += " and a.ERDAOA_OAppState='已回厂'";
        }
        if (Lab_Status.Text == "EMCcLook" && Session["UserRole"].ToString().Contains("出厂维修查看"))
        {
            temp += "";
        }
        condition3 = temp + "and a.EMA_ID='" + Label_emaid.Text.ToString() + "'";
        return condition3;
    }
    //Gridview翻页
    protected void Grid_MaintenanceApp_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_MaintenanceApp.BottomPagerRow;


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
        BindGrid_MaintenanceApp(condition);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_MaintenanceApp.PageCount ? Grid_MaintenanceApp.PageCount - 1 : newPageIndex;
        Grid_MaintenanceApp.PageIndex = newPageIndex;
        Grid_MaintenanceApp.DataBind();
    }
    protected void Grid_MaintenanceApp_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
    #endregion 设备维修信息Grid_MaintenanceApp

    #region 检索设备及台账Grid_EquipInfo
    protected void Search_info_Click(object sender, EventArgs e)
    {
        string ETT_Type = DropDownList5.SelectedValue.ToString();
        string EN_EquipName = infoname.Text.ToString();
        string EMT_Type = infomodel.Text.ToString();
        string EI_No = infono.Text.ToString();
        BindGrid_EquipInfo(ETT_Type, EN_EquipName, EMT_Type, EI_No);
        Panel_New.Visible = false;
        UpdatePanel_New.Update();
        Panel_dealCN.Visible = false;
        UpdatePanel_dealCN.Update();
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
        BindGrid_EquipInfo(ETT_Type, EN_EquipName, EMT_Type, EI_No);
        Panel_New.Visible = false;
        UpdatePanel_New.Update();
        Panel_dealCN.Visible = false;
        UpdatePanel_dealCN.Update();
    }
    protected void Close_info_Click(object sender, EventArgs e)
    {
        Panel_searchInf.Visible = false;
        Panel_New.Visible = false;
        UpdatePanel_New.Update();
        Panel_dealCN.Visible = false;
        UpdatePanel_dealCN.Update();
    }

    //增加申请时，台账gridview
    protected void Grid_EquipInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Add_MaintenanceApp")//点击增加申请
        {
            Clear();
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_EquipInfo.SelectedIndex = row.RowIndex;
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string EI_ID = al[0];
            string ETT_Type = al[1];
            string EN_EquipName = al[2];
            string EMT_Type = al[3];
            string EI_No = al[4];
            Label_eiid.Text = EI_ID;
            TextBox14.Text = ETT_Type;
            TextBox3.Text = EN_EquipName;
            TextBox4.Text = EMT_Type;
            TextBox5.Text = EI_No;

            Panel_New.Visible = true;
            Panel1.Visible = true;
            Panel1.Enabled = true;
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = true;
            Panel5.Visible = false;
            Panel6.Visible = false;
            Panel7.Visible = false;
            Panel8.Visible = false;
            Label20.Visible = false;
            TextAppNO.Visible = false;
            Label28.Visible = false;
            TextAppState.Visible = false;
            UpdatePanel_New.Update();
            TextAppTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            TextAppPer.Text = Session["UserName"].ToString().Trim();
        }
        if (e.CommandName == "Add_RealDetailAOApp_CN")//点击填写厂内维修
        {
            Clear();
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_EquipInfo.SelectedIndex = row.RowIndex;
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string EI_ID = al[0];
            string ETT_Type = al[1];
            string EN_EquipName = al[2];
            string EMT_Type = al[3];
            string EI_No = al[4];
            Label_eiid.Text = EI_ID;
            cntype.Text = ETT_Type;
            cnname.Text = EN_EquipName;
            cnmodel.Text = EMT_Type;
            cnno.Text = EI_No;

            Panel_dealCN.Visible = true;
            Panel9.Visible = true;
            Panel9.Enabled = true;
            Label55.Visible = false;
            cnEnd.Visible = false;
            Label43.Visible = false;
            cnReason.Visible = false;
            Label88.Visible = false;
            Label53.Visible = false;
            cnRemarks.Visible = false;
            Panel10.Visible = true;
            Panel11.Visible = false;
            Panel12.Visible = false;
            Btn_spare.Visible = false;
            Label42.Visible = false;
            Grid_spare.Visible = false;
            Grid_spare.Columns[10].Visible = false;
            UpdatePanel_dealCN.Update();
            //cnStart.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            cnStart.Text = Label_acktime.Text;//故障接收确认时间
            cnEnd.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            cnMaintPer.Text = Session["UserName"].ToString().Trim();
        }
        if (e.CommandName == "Add_RealDetailAOApp_CC")//点击填写出厂维修申请
        {
            Clear();
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_EquipInfo.SelectedIndex = row.RowIndex;
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string EI_ID = al[0];
            string ETT_Type = al[1];
            string EN_EquipName = al[2];
            string EMT_Type = al[3];
            string EI_No = al[4];
            Label_eiid.Text = EI_ID;
            cctype.Text = ETT_Type;
            ccname.Text = EN_EquipName;
            ccmodel.Text = EMT_Type;
            ccno.Text = EI_No;

            Panel_dealCC.Visible = true;
            Panel15.Visible = true;
            Panel15.Enabled = true;
            Panel16.Visible = false;
            Panel17.Visible = false;
            Panel18.Visible = false;
            Panel19.Visible = false;
            Panel20.Visible = false;
            Panel21.Visible = false;
            Panel22.Visible = false;
            Panel23.Visible = true;//按钮
            Panel24.Visible = false;
            Panel25.Visible = false;
            Panel26.Visible = false;
            Panel27.Visible = false;
            Panel28.Visible = false;
            Panel29.Visible = false;
            Panel30.Visible = false;
            Panel31.Visible = false;
            Label56.Visible = false;
            ccOMaintAppNO.Visible = false;
            Label61.Visible = false;
            ccOAppState.Visible = false;
            BindDropDownList7();
            UpdatePanel_dealCC.Update();

            ccOAppTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            ccOAppPer.Text = Session["UserName"].ToString().Trim();
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
        BindGrid_EquipInfo(ETT_Type, EN_EquipName, EMT_Type, EI_No);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_EquipInfo.PageCount ? Grid_EquipInfo.PageCount - 1 : newPageIndex;
        Grid_EquipInfo.PageIndex = newPageIndex;
        Grid_EquipInfo.DataBind();
    }
    protected void Grid_EquipInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
    #endregion 检索设备及台账Grid_EquipInfo

    #region 增加申请
    protected void Btn_Save_Click(object sender, EventArgs e)
    {
        if (TextBreakDownTime.Text.ToString() == "" || DropDownList6.SelectedValue.ToString() == ""  || TextBDDetail.Text.ToString()=="")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        Guid EI_ID = new Guid(Label_eiid.Text.ToString());
        string EMA_AppDep = DropDownList6.SelectedValue.ToString();
        DateTime EMA_BreakDownTime = Convert.ToDateTime(TextBreakDownTime.Text.ToString());
        string EMA_AppPer = TextAppPer.Text.ToString();
        DateTime EMA_AppTime = Convert.ToDateTime(TextAppTime.Text.ToString());
        string EMA_BDDetail = TextBDDetail.Text.ToString();
        string EMA_AppState = "待提交";
        if (EMA_AppTime < EMA_BreakDownTime)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('报修时间必须大于故障发生时间！')", true);
            return;
        }
        DataSet ds = equipMaintenanceAppL.Search_EquipMaintenanceApp("and b.EI_ID = '" + Label_eiid.Text.ToString() + "'and (a.EMA_AppState = '待提交' or a.EMA_AppState = '已提交' or a.EMA_AppState = '已确认' or a.EMA_AppState = '已完成')");
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count != 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('该设备已有厂内维修申请，不能重复申请！')", true);
            return;
        }
        equipMaintenanceAppL.Insert_EquipMaintenanceApp(EI_ID, EMA_AppDep, EMA_BreakDownTime, EMA_AppPer, EMA_AppTime, EMA_BDDetail, EMA_AppState);
        //string condition = "and (a.EMA_AppState='待提交' or (a.EMA_AppState='已验收' and EMA_CheckRes='不通过'))";
        //BindGrid_MaintenanceApp(condition);
        BindGrid_MaintenanceApp("");
        Panel_New.Visible = false;
        UpdatePanel_New.Update();
        Panel_searchInf.Visible = false;
        UpdatePanel_MaintenanceApp.Update();
    }
    protected void Btn_Submit_Click(object sender, EventArgs e)
    {
        if (TextBreakDownTime.Text.ToString() == "" || DropDownList6.SelectedValue.ToString() == "" || TextBDDetail.Text.ToString() == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        Guid EI_ID = new Guid(Label_eiid.Text.ToString());
        string EMA_AppDep = DropDownList6.SelectedValue.ToString();
        DateTime EMA_BreakDownTime = Convert.ToDateTime(TextBreakDownTime.Text.ToString());
        string EMA_AppPer = TextAppPer.Text.ToString();
        DateTime EMA_AppTime = Convert.ToDateTime(TextAppTime.Text.ToString());
        string EMA_BDDetail = TextBDDetail.Text.ToString();
        string EMA_AppState = "已提交";
        if (EMA_AppTime < EMA_BreakDownTime)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('报修时间必须大于故障发生时间！')", true);
            return;
        }
        DataSet ds = equipMaintenanceAppL.Search_EquipMaintenanceApp("and b.EI_ID = '" + Label_eiid.Text.ToString() + "' and (a.EMA_AppState = '待提交' or a.EMA_AppState = '已提交' or a.EMA_AppState = '已确认' or a.EMA_AppState = '已完成')");
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count != 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('该设备已有厂内维修申请，不能重复申请！')", true);
            return;
        }
        equipMaintenanceAppL.Insert_EquipMaintenanceApp(EI_ID, EMA_AppDep, EMA_BreakDownTime, EMA_AppPer, EMA_AppTime, EMA_BDDetail, EMA_AppState);
        //string condition = "and (a.EMA_AppState='待提交' or (a.EMA_AppState='已验收' and EMA_CheckRes='不通过'))";
        //BindGrid_MaintenanceApp(condition);
        BindGrid_MaintenanceApp("");
        Panel_New.Visible = false;
        UpdatePanel_New.Update();
        Panel_searchInf.Visible = false;
        UpdatePanel_MaintenanceApp.Update();
        //RTX
        string message = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "申请维修设备" + TextBox5.Text + "，请确认接收";
        string sErr = RTXhelper.Send(message, "设备故障维修确认");
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
            UpdatePanel_New.Update();
        }
    }
    #endregion 增加申请

    #region 修改申请
    protected void Btn_editSave_Click(object sender, EventArgs e)
    {
        if (TextBreakDownTime.Text.ToString() == "" || DropDownList6.SelectedValue.ToString() == "" || TextBDDetail.Text.ToString() == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        Guid eMA_ID = new Guid(Label_emaid.Text.ToString());
        string eMA_AppDep = DropDownList6.SelectedValue.ToString();
        DateTime eMA_BreakDownTime = Convert.ToDateTime(TextBreakDownTime.Text.ToString());
        string eMA_AppPer = TextAppPer.Text.ToString();
        DateTime eMA_AppTime = Convert.ToDateTime(TextAppTime.Text.ToString());
        string eMA_BDDetail = TextBDDetail.Text.ToString();
        string eMA_AppState = "待提交";
        if (eMA_AppTime < eMA_BreakDownTime)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('报修时间必须大于故障发生时间！')", true);
            return;
        }
        DataSet ds = equipMaintenanceAppL.Search_EquipMaintenanceApp("and a.EMA_ID = '" + eMA_ID + "' and (a.EMA_AppState = '待提交' or a.EMA_AppState = '已提交' or a.EMA_AppState = '已确认' or a.EMA_AppState = '已完成') and EMA_AppDep='" + eMA_AppDep + "' and EMA_BreakDownTime='" + eMA_BreakDownTime + "' and EMA_AppPer='" + eMA_AppPer + "' and EMA_AppTime='" + eMA_AppTime + "' and EMA_BDDetail='" + eMA_BDDetail + "'");
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count != 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('该设备已有厂内维修申请，不能重复申请！')", true);
            return;
        }
        equipMaintenanceAppL.Update_EquipMaintenanceApp_SQ(eMA_ID, eMA_AppDep, eMA_BreakDownTime, eMA_AppPer, eMA_AppTime, eMA_BDDetail, eMA_AppState);
        //string condition = "and (a.EMA_AppState='待提交' or (a.EMA_AppState='已验收' and EMA_CheckRes='不通过'))";
        //BindGrid_MaintenanceApp(condition);
        BindGrid_MaintenanceApp("");
        Panel_New.Visible = false;
        UpdatePanel_New.Update();
        UpdatePanel_MaintenanceApp.Update();
    }
    protected void Btn_editSubmit_Click(object sender, EventArgs e)
    {
        if (TextBreakDownTime.Text.ToString() == "" || DropDownList6.SelectedValue.ToString() == "" || TextBDDetail.Text.ToString() == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        Guid eMA_ID = new Guid(Label_emaid.Text.ToString());
        string eMA_AppDep = DropDownList6.SelectedValue.ToString();
        DateTime eMA_BreakDownTime = Convert.ToDateTime(TextBreakDownTime.Text.ToString());
        string eMA_AppPer = TextAppPer.Text.ToString();
        DateTime eMA_AppTime = Convert.ToDateTime(TextAppTime.Text.ToString());
        string eMA_BDDetail = TextBDDetail.Text.ToString();
        string eMA_AppState = "已提交";
        if (eMA_AppTime < eMA_BreakDownTime)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('报修时间必须大于故障发生时间！')", true);
            return;
        }
        DataSet ds = equipMaintenanceAppL.Search_EquipMaintenanceApp("and a.EMA_ID = '" + eMA_ID + "' and (a.EMA_AppState = '已提交' or a.EMA_AppState = '已确认' or a.EMA_AppState = '已完成') and EMA_AppDep='" + eMA_AppDep + "' and EMA_BreakDownTime='" + eMA_BreakDownTime + "' and EMA_AppPer='" + eMA_AppPer + "' and EMA_AppTime='" + eMA_AppTime + "' and EMA_BDDetail='" + eMA_BDDetail + "'");
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count != 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('该设备已有厂内维修申请，不能重复申请！')", true);
            return;
        }
        equipMaintenanceAppL.Update_EquipMaintenanceApp_SQ(eMA_ID, eMA_AppDep, eMA_BreakDownTime, eMA_AppPer, eMA_AppTime, eMA_BDDetail, eMA_AppState);
        //string condition = "and (a.EMA_AppState='待提交' or (a.EMA_AppState='已验收' and EMA_CheckRes='不通过'))";
        //BindGrid_MaintenanceApp(condition);
        BindGrid_MaintenanceApp("");
        Panel_New.Visible = false;
        UpdatePanel_New.Update();
        UpdatePanel_MaintenanceApp.Update();
        //RTX
        string message = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "申请维修设备" + TextBox5.Text + "，请确认接收";
        string sErr = RTXhelper.Send(message, "设备故障维修确认");
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('" + sErr + "')", true);
        }
    }
    protected void Btn_editCancel_Click(object sender, EventArgs e)
    {
        if (Panel_New.Visible)
        {
            Panel_New.Visible = false;
            UpdatePanel_New.Update();
        }
    }
    #endregion 修改申请

    #region 接收确认
    protected void btn_ack_Click(object sender, EventArgs e)
    {
        Guid EMA_ID = new Guid(Label_emaid.Text.ToString());
        string EMA_AckPer = TextAckPer.Text.ToString();
        DateTime EMA_AckTime = Convert.ToDateTime(TextAckTime.Text.ToString());
        string EMA_AppState = "已确认";
        DateTime EMA_AppTime = Convert.ToDateTime(TextAppTime.Text.ToString());

        if (EMA_AckTime < EMA_AppTime)
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_New, GetType(), "alert", "alert('确认时间必须大于报修时间！')", true);
            return;
        }
        equipMaintenanceAppL.Update_EquipMaintenanceApp_QR(EMA_ID, EMA_AckPer, EMA_AckTime, EMA_AppState);
        BindGrid_MaintenanceApp("and a.EMA_AppState='已提交'");
        Panel_New.Visible = false;
        UpdatePanel_New.Update();
        UpdatePanel_MaintenanceApp.Update();
    }
    protected void Cancel_ack_Click(object sender, EventArgs e)
    {
        if (Panel_New.Visible)
        {
            Panel_New.Visible = false;
            UpdatePanel_New.Update();
        }
    }
    #endregion 接收确认

    #region 验收
    protected void check_ok_Click(object sender, EventArgs e)
    {
        if (TextCheckSugg.Text.ToString()=="")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        Guid EMA_ID = new Guid(Label_emaid.Text.ToString());
        string EMA_CheckPer = TextCheckPer.Text.ToString();
        DateTime EMA_CheckTime = Convert.ToDateTime(TextCheckTime.Text.ToString());
        string EMA_CheckRes = "通过";
        string EMA_CheckSugg = TextCheckSugg.Text.ToString();
        string EMA_AppState = "已验收";
        DateTime EMA_AckTime = Convert.ToDateTime(TextAckTime.Text.ToString());

        if (EMA_CheckTime < EMA_AckTime)
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_New, GetType(), "alert", "alert('验收时间必须大于确认时间！')", true);
            return;
        }
        equipMaintenanceAppL.Update_EquipMaintenanceApp_YS(EMA_ID, EMA_CheckPer, EMA_CheckTime, EMA_CheckRes, EMA_CheckSugg, EMA_AppState);
        BindGrid_MaintenanceApp("and a.EMA_AppState='已完成'");
        Panel_New.Visible = false;
        UpdatePanel_New.Update();
        UpdatePanel_MaintenanceApp.Update();
        Panel_CN.Visible = false;
        UpdatePanel_CN.Update();
        Panel_dealCN.Visible = false;
        UpdatePanel_dealCN.Update();
    }
    protected void check_notok_Click(object sender, EventArgs e)
    {
        if (TextCheckSugg.Text.ToString() == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        Guid EMA_ID = new Guid(Label_emaid.Text.ToString());
        string EMA_CheckPer = TextCheckPer.Text.ToString();
        DateTime EMA_CheckTime = Convert.ToDateTime(TextCheckTime.Text.ToString());
        string EMA_CheckRes = "不通过";
        string EMA_CheckSugg = TextCheckSugg.Text.ToString();
        string EMA_AppState = "已验收";
        DateTime EMA_AckTime = Convert.ToDateTime(TextAckTime.Text.ToString());

        if (EMA_CheckTime < EMA_AckTime)
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_New, GetType(), "alert", "alert('验收时间必须大于确认时间！')", true);
            return;
        }
        equipMaintenanceAppL.Update_EquipMaintenanceApp_YS(EMA_ID, EMA_CheckPer, EMA_CheckTime, EMA_CheckRes, EMA_CheckSugg, EMA_AppState);
        BindGrid_MaintenanceApp("and a.EMA_AppState='已完成'");
        Panel_New.Visible = false;
        UpdatePanel_New.Update();
        UpdatePanel_MaintenanceApp.Update();
        Panel_CN.Visible = false;
        UpdatePanel_CN.Update();
        Panel_dealCN.Visible = false;
        UpdatePanel_dealCN.Update();
        //RTX
        string message = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "验收驳回了申请单编号为" + TextAppNO.Text + "的维修，请重提申请。";
        string sErr = RTXhelper.SendbyUserName(message, TextAppPer.Text);
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('" + sErr + "')", true);
        }
    }
    protected void check_cancel_Click(object sender, EventArgs e)
    {
        if (Panel_New.Visible)
        {
            Panel_New.Visible = false;
            UpdatePanel_New.Update();
            Panel_CN.Visible = false;
            UpdatePanel_CN.Update();
            Panel_dealCN.Visible = false;
            UpdatePanel_dealCN.Update();
        }
    }
    #endregion 验收

    #region 查看详情
    protected void close_look_Click(object sender, EventArgs e)
    {
        if (Panel_New.Visible)
        {
            Panel_New.Visible = false;
            UpdatePanel_New.Update();
        }
    }
    #endregion 查看详情

    #region 厂内维修及GridView_CN
    //按钮
    protected void choosereal_Click(object sender, EventArgs e)
    {
        Panel_searchInf.Visible = true;
        BindGrid_EquipInfo("", "", "", "");
        BindDropDownList5();
        Grid_EquipInfo.Columns[9].Visible = false;
        Grid_EquipInfo.Columns[10].Visible = true;
        Grid_EquipInfo.Columns[11].Visible = false;
        Panel_dealCN.Visible = false;
        UpdatePanel_dealCN.Update();
        Panel_NewSpare.Visible = false;
        UpdatePanel_NewSpare.Update();
    }
    //厂内维修信息表GridView_CN
    protected void GridView_CN_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Look_CN")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_CN.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string ETT_Type = al[0];
            cntype.Text = ETT_Type;
            string EN_EquipName = al[1];
            cnname.Text = EN_EquipName;
            string EMT_Type = al[2];
            cnmodel.Text = EMT_Type;
            string EI_No = al[3];
            cnno.Text = EI_No;
            string ERDAOA_MaintPer = al[4];
            cnMaintPer.Text = ERDAOA_MaintPer;
            DateTime ERDAOA_StartTime = Convert.ToDateTime(al[5].ToString());
            cnStart.Text = ERDAOA_StartTime.ToString("yyyy-MM-dd HH:mm:ss");
            DateTime ERDAOA_EndTime = Convert.ToDateTime(al[6].ToString());
            cnEnd.Text = ERDAOA_EndTime.ToString("yyyy-MM-dd HH:mm:ss");
            string ERDAOA_ReasonMethod = al[7];
            cnReason.Text = ERDAOA_ReasonMethod;
            string ERDAOA_Remarks = al[8];
            cnRemarks.Text = ERDAOA_Remarks;
            string EMT_ID = al[9];
            Label_emt.Text = EMT_ID;
            string ERDAOA_ID = al[10];
            Label_erdaoaid.Text = ERDAOA_ID;

            Panel_dealCN.Visible = true;
            Panel9.Visible = true;
            Panel9.Enabled = false;
            Panel10.Visible = false;
            Panel11.Visible = true;
            Panel12.Visible = false;
            Btn_spare.Visible = false;
            Label42.Visible = true;
            Grid_spare.Visible = true;
            Grid_spare.Columns[10].Visible = false;
            BindGrid_spare("and e.ERDAOA_ID = '" + Label_erdaoaid.Text + "'");
            UpdatePanel_dealCN.Update();
            Panel_searchInf.Visible = false;
        }
        if (e.CommandName == "choosespare")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_CN.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string ETT_Type = al[0];
            cntype.Text = ETT_Type;
            string EN_EquipName = al[1];
            cnname.Text = EN_EquipName;
            string EMT_Type = al[2];
            cnmodel.Text = EMT_Type;
            string EI_No = al[3];
            cnno.Text = EI_No;
            string ERDAOA_MaintPer = al[4];
            cnMaintPer.Text = ERDAOA_MaintPer;
            DateTime ERDAOA_StartTime = Convert.ToDateTime(al[5].ToString());
            cnStart.Text = ERDAOA_StartTime.ToString("yyyy-MM-dd HH:mm:ss");
            DateTime ERDAOA_EndTime = Convert.ToDateTime(al[6].ToString());
            cnEnd.Text = ERDAOA_EndTime.ToString("yyyy-MM-dd HH:mm:ss");
            string ERDAOA_ReasonMethod = al[7];
            cnReason.Text = ERDAOA_ReasonMethod;
            string ERDAOA_Remarks = al[8];
            cnRemarks.Text = ERDAOA_Remarks;
            string EMT_ID = al[9];
            Label_emt.Text = EMT_ID;
            string ERDAOA_ID = al[10];
            Label_erdaoaid.Text = ERDAOA_ID;

            cnEnd.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Panel_dealCN.Visible = true;
            Panel9.Visible = true;
            Panel9.Enabled = true;
            Label55.Visible = true;
            cnEnd.Visible = true;
            Label43.Visible = true;
            cnReason.Visible = true;
            Label88.Visible = true;
            Label53.Visible = true;
            cnRemarks.Visible = true;
            Panel10.Visible = false;
            Panel11.Visible = false;
            Panel12.Visible = true;
            Btn_spare.Visible = true;
            Label42.Visible = true;
            Grid_spare.Visible = true;
            Grid_spare.Columns[10].Visible = true;
            BindGrid_spare("and e.ERDAOA_ID = '" + Label_erdaoaid.Text + "'");
            UpdatePanel_dealCN.Update();
            Panel_searchInf.Visible = false;
        }
        if (e.CommandName == "Delete_CN")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_CN.SelectedIndex = row.RowIndex;

            Guid ERDAOA_ID = new Guid(Convert.ToString(e.CommandArgument));
            equipMaintenanceAppL.Delete_EquipRealDetailAOApp_CN(ERDAOA_ID);
            UpdatePanel_CN.Update();
            BindGridView_CN("and a.EMA_ID='" + Label_emaid.Text.ToString() + "'");
            Panel_searchInf.Visible = false;
            Panel_dealCN.Visible = false;
            UpdatePanel_dealCN.Update();
        }
    }
    //Gridview翻页
    protected void GridView_CN_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView_CN.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox3");   // refer to the TextBox with the NewPageIndex value
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
        BindGridView_CN("");
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView_CN.PageCount ? GridView_CN.PageCount - 1 : newPageIndex;
        GridView_CN.PageIndex = newPageIndex;
        GridView_CN.DataBind();
    }
    protected void GridView_CN_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
    #endregion 厂内维修及GridView_CN

    #region 填写厂内维修记录
    protected void deal_cn_Click(object sender, EventArgs e)
    {
        Guid EI_ID = new Guid(Label_eiid.Text.ToString());
        Guid EMA_ID = new Guid(Label_emaid.Text.ToString());
        string ERDAOA_MaintPer = cnMaintPer.Text.ToString();
        DateTime ERDAOA_StartTime = Convert.ToDateTime(cnStart.Text.ToString());
        DateTime ERDAOA_EndTime = Convert.ToDateTime(cnEnd.Text.ToString());
        string ERDAOA_ReasonMethod = cnReason.Text.ToString();
        string ERDAOA_Remarks = cnRemarks.Text.ToString();
        if (ERDAOA_EndTime < ERDAOA_StartTime)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('维修结束时间必须大于维修开始时间！')", true);
            return;
        }
        DataSet ds = equipMaintenanceAppL.Search_EquipRealDetailAOApp_CN("and a.EI_ID = '" + Label_eiid.Text.ToString() + "' and a.EMA_ID = '" + Label_emaid.Text.ToString() + "'");
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count != 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('该设备已填写厂内维修记录，不能重复！')", true);
            return;
        }
        equipMaintenanceAppL.Insert_EquipRealDetailAOApp_CN(EI_ID, EMA_ID, ERDAOA_MaintPer, ERDAOA_StartTime, ERDAOA_EndTime, ERDAOA_ReasonMethod, ERDAOA_Remarks);
        BindGridView_CN("and a.EMA_ID='" + Label_emaid.Text.ToString() + "'");
        Panel_dealCN.Visible = false;
        UpdatePanel_dealCN.Update();
        UpdatePanel_CN.Update();
        Panel_searchInf.Visible = false;

        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('开始厂内维修，待维修完成后，请在“记录详情”里选择备件！')", true);
    }
    protected void Cancel_dealcn_Click(object sender, EventArgs e)
    {
        Panel_dealCN.Visible = false;
        UpdatePanel_dealCN.Update();
        Panel_searchInf.Visible = false;
    }
    #endregion 填写厂内维修记录

    #region 修改厂内维修记录，选择所用备件及Grid_spare
    protected void Btn_spare_Click(object sender, EventArgs e)
    {
        BindGrid_NewEquipSpare("and x.EMT_ID = '" + Label_emt.Text.ToString() + "'");
        Panel_NewSpare.Visible = true;
        UpdatePanel_NewSpare.Update();
    }
    //提交按钮
    protected void btn_edit_Click(object sender, EventArgs e)
    {
        if (cnReason.Text=="")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        Guid ERDAOA_ID = new Guid(Label_erdaoaid.Text.ToString());
        string ERDAOA_MaintPer = cnMaintPer.Text.ToString();
        DateTime ERDAOA_StartTime = Convert.ToDateTime(cnStart.Text.ToString());
        DateTime ERDAOA_EndTime = Convert.ToDateTime(cnEnd.Text.ToString());
        string ERDAOA_ReasonMethod = cnReason.Text.ToString();
        string ERDAOA_Remarks = cnRemarks.Text.ToString();
        if (ERDAOA_EndTime < ERDAOA_StartTime)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('维修结束时间必须大于维修开始时间！')", true);
            return;
        }
        //DataSet ds = equipMaintenanceAppL.Search_EquipRealDetailAOApp_CN("and a.EI_ID = '" + this.Label_eiid.Text.ToString() + "' and a.EMA_ID = '" + this.Label_emaid.Text.ToString() + "'");
        //DataTable dt = ds.Tables[0];
        //if (dt.Rows.Count != 0)
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('该设备已填写厂内维修记录，不能重复！')", true);
        //    return;
        //}
        equipMaintenanceAppL.Update_EquipRealDetailAOApp_CN(ERDAOA_ID, ERDAOA_MaintPer, ERDAOA_StartTime, ERDAOA_EndTime, ERDAOA_ReasonMethod, ERDAOA_Remarks);
        BindGridView_CN("and a.EMA_ID='" + Label_emaid.Text.ToString() + "'");
        Panel_dealCN.Visible = false;
        UpdatePanel_dealCN.Update();
        UpdatePanel_CN.Update();
        Panel_searchInf.Visible = false;
        Panel_NewSpare.Visible = false;
        UpdatePanel_NewSpare.Update();
    }
    //取消按钮
    protected void Cancel_edit_Click(object sender, EventArgs e)
    {
        Panel_dealCN.Visible = false;
        UpdatePanel_dealCN.Update();
        Panel_NewSpare.Visible = false;
        UpdatePanel_NewSpare.Update();
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
            BindGrid_spare("and e.ERDAOA_ID = '" + Label_erdaoaid.Text + "'");
            UpdatePanel_dealCN.Update();
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
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox11");   // refer to the TextBox with the NewPageIndex value
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
        BindGrid_spare("and e.ERDAOA_ID = '" + Label_erdaoaid.Text + "'");
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_spare.PageCount ? Grid_spare.PageCount - 1 : newPageIndex;
        Grid_spare.PageIndex = newPageIndex;
        Grid_spare.DataBind();
    }
    protected void Grid_spare_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
    #endregion 修改厂内维修记录，选择所用备件及Grid_spare

    #region 查看厂内维修详情
    protected void close_lookdealcn_Click(object sender, EventArgs e)
    {
        Panel_dealCN.Visible = false;
        UpdatePanel_dealCN.Update();
    }
    #endregion 查看厂内维修详情

    #region 出厂维修及GridView_CC
    //按钮
    protected void choosereal_cc_Click(object sender, EventArgs e)
    {
        Panel_searchInf.Visible = true;
        BindGrid_EquipInfo("", "", "", "");
        BindDropDownList5();
        Grid_EquipInfo.Columns[9].Visible = false;
        Grid_EquipInfo.Columns[10].Visible = false;
        Grid_EquipInfo.Columns[11].Visible = true;
        Panel_dealCC.Visible = false;
        UpdatePanel_dealCC.Update();
        Panel_NewSpare.Visible = false;
        UpdatePanel_NewSpare.Update();
    }
    //出厂维修信息表GridView_CC
    protected void GridView_CC_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Look_CC")//查看
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_CC.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string ETT_Type = al[0];
            cctype.Text = ETT_Type;
            string EN_EquipName = al[1];
            ccname.Text = EN_EquipName;
            string EMT_Type = al[2];
            ccmodel.Text = EMT_Type;
            string EI_No = al[3];
            ccno.Text = EI_No;
            string ERDAOA_OMaintAppNO = al[4];
            ccOMaintAppNO.Text = ERDAOA_OMaintAppNO;
            string ERDAOA_OAppDep = al[5];
            BindDropDownList7();
            DropDownList7.Items.FindByText(ERDAOA_OAppDep.ToString().Trim()).Selected = true;
            string ERDAOA_OAppPer = al[6];
            ccOAppPer.Text = ERDAOA_OAppPer;
            DateTime ERDAOA_OAppTime = Convert.ToDateTime(al[7].ToString());
            ccOAppTime.Text = ERDAOA_OAppTime.ToString("yyyy-MM-dd HH:mm:ss");
            string ERDAOA_OAppState = al[8];
            ccOAppState.Text = ERDAOA_OAppState;
            string ERDAOA_OMaintePlace = al[9];
            ccPlace.Text = ERDAOA_OMaintePlace;
            string ERDAOA_Feature = al[10];
            ccFeature.Text = ERDAOA_Feature;
            string ERDAOA_OReson = al[11];
            ccOReson.Text = ERDAOA_OReson;
            string ERDAOA_ID = al[12];
            Label_erdaoaid.Text = ERDAOA_ID;
            string ERDAOA_Approver = al[13];
            ccApprover.Text = ERDAOA_Approver;
            if (al[14].ToString() == "")
            {
                ccApprovalT.Text = "";
            }
            else
            {
                DateTime ERDAOA_ApprovalT = Convert.ToDateTime(al[14].ToString());
                ccApprovalT.Text = ERDAOA_ApprovalT.ToString("yyyy-MM-dd HH:mm:ss");
            }
            string ERDAOA_ApprovalSugg = al[15];
            ccApprovalSugg.Text = ERDAOA_ApprovalSugg;
            string ERDAOA_ApprovalRes = al[16];
            ccApprovalRes.Text = ERDAOA_ApprovalRes;
            if (al[17].ToString() == "")
            {
                ccExpectODate.Text = "";
            }
            else
            {
                DateTime ERDAOA_ExpectODate = Convert.ToDateTime(al[17].ToString());
                ccExpectODate.Text = ERDAOA_ExpectODate.ToString("yyyy-MM-dd HH:mm:ss");
            }
            if (al[18].ToString() == "")
            {
                ccExpectIDate.Text = "";
            }
            else
            {
                DateTime ERDAOA_ExpectIDate = Convert.ToDateTime(al[18].ToString());
                ccExpectIDate.Text = ERDAOA_ExpectIDate.ToString("yyyy-MM-dd HH:mm:ss");
            }
            string ERDAOA_ExpectCost = al[19];
            ccExpectCost.Text = ERDAOA_ExpectCost;
            string ERDAOA_PerInCharge = al[20];
            ccPerInCharge.Text = ERDAOA_PerInCharge;
            if (al[21].ToString() == "")
            {
                ccRecordDate.Text = "";
            }
            else
            {
                DateTime ERDAOA_RecordDate = Convert.ToDateTime(al[21].ToString());
                ccRecordDate.Text = ERDAOA_RecordDate.ToString("yyyy-MM-dd HH:mm:ss");
            }
            string ERDAOA_FinanPer = al[22];
            ccFinanPer.Text = ERDAOA_FinanPer;
            if (al[23].ToString() == "")
            {
                ccFinanTime.Text = "";
            }
            else
            {
                DateTime ERDAOA_FinanTime = Convert.ToDateTime(al[23].ToString());
                ccFinanTime.Text = ERDAOA_FinanTime.ToString("yyyy-MM-dd HH:mm:ss");
            }
            string ERDAOA_FinanSugg = al[24];
            ccFinanSugg.Text = ERDAOA_FinanSugg;
            string ERDAOA_FinanRes = al[25];
            ccFinanRes.Text = ERDAOA_FinanRes;
            string ERDAOA_OConfirmor = al[26];
            ccOConfirmor.Text = ERDAOA_OConfirmor;
            if (al[27].ToString() == "")
            {
                ccOCTime.Text = "";
            }
            else
            {
                DateTime ERDAOA_OCTime = Convert.ToDateTime(al[27].ToString());
                ccOCTime.Text = ERDAOA_OCTime.ToString("yyyy-MM-dd HH:mm:ss");
            }
            if (al[28].ToString() == "")
            {
                ccActODate.Text = "";
            }
            else
            {
                DateTime ERDAOA_ActODate = Convert.ToDateTime(al[28].ToString());
                ccActODate.Text = ERDAOA_ActODate.ToString("yyyy-MM-dd HH:mm:ss");
            }
            string ERDAOA_ActCost = al[29];
            ccActCost.Text = ERDAOA_ActCost;
            if (al[30].ToString() == "")
            {
                ccActIDate.Text = "";
            }
            else
            {
                DateTime ERDAOA_ActIDate = Convert.ToDateTime(al[30].ToString());
                ccActIDate.Text = ERDAOA_ActIDate.ToString("yyyy-MM-dd HH:mm:ss");
            }
            string ERDAOA_PerfectPer = al[31];
            ccPerfectPer.Text = ERDAOA_PerfectPer;
            if (al[32].ToString() == "")
            {
                ccPerfectTime.Text = "";
            }
            else
            {
                DateTime ERDAOA_PerfectTime = Convert.ToDateTime(al[32].ToString());
                ccPerfectTime.Text = ERDAOA_PerfectTime.ToString("yyyy-MM-dd HH:mm:ss");
            }
            string ERDAOA_FinanConfirmor = al[33];
            ccFinanConfirmor.Text = ERDAOA_FinanConfirmor;
            if (al[34].ToString() == "")
            {
                ccFCTime.Text = "";
            }
            else
            {
                DateTime ERDAOA_FCTime = Convert.ToDateTime(al[34].ToString());
                ccFCTime.Text = ERDAOA_FCTime.ToString("yyyy-MM-dd HH:mm:ss");
            }

            Panel_dealCC.Visible = true;
            Panel15.Visible = true;
            Panel15.Enabled = false;
            Panel16.Visible = true;
            Panel17.Visible = true;
            Panel17.Enabled = false;
            Panel18.Visible = true;
            Panel18.Enabled = false;
            Panel19.Visible = true;
            Panel19.Enabled = false;
            Panel20.Visible = true;
            Panel20.Enabled = false;
            Panel21.Visible = true;
            Panel21.Enabled = false;
            Panel22.Visible = true;
            Panel22.Enabled = false;
            Panel23.Visible = false;//按钮
            Panel24.Visible = false;
            Panel25.Visible = false;
            Panel26.Visible = false;
            Panel27.Visible = false;
            Panel28.Visible = false;
            Panel29.Visible = false;
            Panel30.Visible = false;
            Panel31.Visible = true;
            Btn_spare_cc.Visible = false;
            Grid_spare_cc.Columns[10].Visible = false;
            BindGrid_spare("and e.ERDAOA_ID = '" + Label_erdaoaid.Text + "'");
            UpdatePanel_dealCC.Update();
            Panel_searchInf.Visible = false;
        }
        if (e.CommandName == "choosespare_cc")//选备件
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_CC.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string ETT_Type = al[0];
            cctype.Text = ETT_Type;
            string EN_EquipName = al[1];
            ccname.Text = EN_EquipName;
            string EMT_Type = al[2];
            ccmodel.Text = EMT_Type;
            string EI_No = al[3];
            ccno.Text = EI_No;
            string ERDAOA_OMaintAppNO = al[4];
            ccOMaintAppNO.Text = ERDAOA_OMaintAppNO;
            string ERDAOA_OAppDep = al[5];
            BindDropDownList7();
            DropDownList7.Items.FindByText(ERDAOA_OAppDep.ToString().Trim()).Selected = true;
            string ERDAOA_OAppPer = al[6];
            ccOAppPer.Text = ERDAOA_OAppPer;
            DateTime ERDAOA_OAppTime = Convert.ToDateTime(al[7].ToString());
            ccOAppTime.Text = ERDAOA_OAppTime.ToString("yyyy-MM-dd HH:mm:ss");
            string ERDAOA_OAppState = al[8];
            if (ERDAOA_OAppState != "待提交")
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel_CN, GetType(), "alert", "alert('此状态下不可选择备件，请重新选择出厂维修设备！')", true);
                return;
            }
            ccOAppState.Text = ERDAOA_OAppState;
            string ERDAOA_OMaintePlace = al[9];
            ccPlace.Text = ERDAOA_OMaintePlace;
            string ERDAOA_Feature = al[10];
            ccFeature.Text = ERDAOA_Feature;
            string ERDAOA_OReson = al[11];
            ccOReson.Text = ERDAOA_OReson;
            string EMT_ID = al[12];
            Label_emt.Text = EMT_ID;
            string ERDAOA_ID = al[13];
            Label_erdaoaid.Text = ERDAOA_ID;

            //if (ERDAOA_OAppState == "已完成")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('出厂维修已完成，该状态下不能选择备件！')", true);
            //    return;
            //}
            Panel_dealCC.Visible = true;
            Panel15.Visible = true;
            Panel15.Enabled = true;
            Panel16.Visible = true;
            Panel17.Visible = false;
            Panel18.Visible = false;
            Panel19.Visible = false;
            Panel20.Visible = false;
            Panel21.Visible = false;
            Panel22.Visible = false;
            Panel23.Visible = false;//按钮
            Panel24.Visible = true;
            Panel25.Visible = false;
            Panel26.Visible = false;
            Panel27.Visible = false;
            Panel28.Visible = false;
            Panel29.Visible = false;
            Panel30.Visible = false;
            Panel31.Visible = false;
            Btn_spare_cc.Visible = true;
            Grid_spare_cc.Columns[10].Visible = true;
            BindGrid_spare_cc("and e.ERDAOA_ID = '" + Label_erdaoaid.Text + "'");
            UpdatePanel_dealCC.Update();
            Panel_searchInf.Visible = false;
        }
        if (e.CommandName == "App_CC")//审批
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_CC.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string ETT_Type = al[0];
            cctype.Text = ETT_Type;
            string EN_EquipName = al[1];
            ccname.Text = EN_EquipName;
            string EMT_Type = al[2];
            ccmodel.Text = EMT_Type;
            string EI_No = al[3];
            ccno.Text = EI_No;
            string ERDAOA_OMaintAppNO = al[4];
            ccOMaintAppNO.Text = ERDAOA_OMaintAppNO;
            string ERDAOA_OAppDep = al[5];
            BindDropDownList7();
            DropDownList7.Items.FindByText(ERDAOA_OAppDep.ToString().Trim()).Selected = true;
            string ERDAOA_OAppPer = al[6];
            ccOAppPer.Text = ERDAOA_OAppPer;
            DateTime ERDAOA_OAppTime = Convert.ToDateTime(al[7].ToString());
            ccOAppTime.Text = ERDAOA_OAppTime.ToString("yyyy-MM-dd HH:mm:ss");
            string ERDAOA_OAppState = al[8];
            ccOAppState.Text = ERDAOA_OAppState;
            string ERDAOA_OMaintePlace = al[9];
            ccPlace.Text = ERDAOA_OMaintePlace;
            string ERDAOA_Feature = al[10];
            ccFeature.Text = ERDAOA_Feature;
            string ERDAOA_OReson = al[11];
            ccOReson.Text = ERDAOA_OReson;
            string ERDAOA_ID = al[12];
            Label_erdaoaid.Text = ERDAOA_ID;

            Panel_dealCC.Visible = true;
            Panel15.Visible = true;
            Panel15.Enabled = false;
            Panel16.Visible = true;
            Panel17.Visible = true;
            Panel17.Enabled = true;
            Panel18.Visible = false;
            Panel19.Visible = false;
            Panel20.Visible = false;
            Panel21.Visible = false;
            Panel22.Visible = false;
            Panel23.Visible = false;//按钮
            Panel24.Visible = false;
            Panel25.Visible = true;
            Panel26.Visible = false;
            Panel27.Visible = false;
            Panel28.Visible = false;
            Panel29.Visible = false;
            Panel30.Visible = false;
            Panel31.Visible = false;
            Btn_spare_cc.Visible = false;
            Grid_spare_cc.Columns[10].Visible = false;
            Label65.Visible = false;
            ccApprovalRes.Visible = false;
            ccApprovalT.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            ccApprover.Text = Session["UserName"].ToString().Trim();
            ccApprovalSugg.Text = "";
            BindGrid_spare_cc("and e.ERDAOA_ID = '" + Label_erdaoaid.Text + "'");
            UpdatePanel_dealCC.Update();
            Panel_searchInf.Visible = false;
        }
        if (e.CommandName == "Expect_CC")//预算
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_CC.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string ETT_Type = al[0];
            cctype.Text = ETT_Type;
            string EN_EquipName = al[1];
            ccname.Text = EN_EquipName;
            string EMT_Type = al[2];
            ccmodel.Text = EMT_Type;
            string EI_No = al[3];
            ccno.Text = EI_No;
            string ERDAOA_OMaintAppNO = al[4];
            ccOMaintAppNO.Text = ERDAOA_OMaintAppNO;
            string ERDAOA_OAppDep = al[5];
            BindDropDownList7();
            DropDownList7.Items.FindByText(ERDAOA_OAppDep.ToString().Trim()).Selected = true;
            string ERDAOA_OAppPer = al[6];
            ccOAppPer.Text = ERDAOA_OAppPer;
            DateTime ERDAOA_OAppTime = Convert.ToDateTime(al[7].ToString());
            ccOAppTime.Text = ERDAOA_OAppTime.ToString("yyyy-MM-dd HH:mm:ss");
            string ERDAOA_OAppState = al[8];
            ccOAppState.Text = ERDAOA_OAppState;
            string ERDAOA_OMaintePlace = al[9];
            ccPlace.Text = ERDAOA_OMaintePlace;
            string ERDAOA_Feature = al[10];
            ccFeature.Text = ERDAOA_Feature;
            string ERDAOA_OReson = al[11];
            ccOReson.Text = ERDAOA_OReson;
            string ERDAOA_ID = al[12];
            Label_erdaoaid.Text = ERDAOA_ID;
            string ERDAOA_Approver = al[13];
            ccApprover.Text = ERDAOA_Approver;
            DateTime ERDAOA_ApprovalT = Convert.ToDateTime(al[14].ToString());
            ccApprovalT.Text = ERDAOA_ApprovalT.ToString("yyyy-MM-dd HH:mm:ss");
            string ERDAOA_ApprovalSugg = al[15];
            ccApprovalSugg.Text = ERDAOA_ApprovalSugg;
            string ERDAOA_ApprovalRes = al[16];
            ccApprovalRes.Text = ERDAOA_ApprovalRes;
            //string ERDAOA_ExpectCost = al[17];
            //this.ccExpectCost.Text = ERDAOA_ExpectCost;
            //DateTime ERDAOA_ExpectODate = Convert.ToDateTime(al[18].ToString());
            //this.ccExpectODate.Text = ERDAOA_ExpectODate.ToString("yyyy-MM-dd HH:mm:ss");
            //DateTime ERDAOA_ExpectIDate = Convert.ToDateTime(al[19].ToString());
            //this.ccExpectIDate.Text = ERDAOA_ExpectIDate.ToString("yyyy-MM-dd HH:mm:ss");

            Panel_dealCC.Visible = true;
            Panel15.Visible = true;
            Panel15.Enabled = false;
            Panel16.Visible = true;
            Panel17.Visible = true;
            Panel17.Enabled = false;
            Panel18.Visible = true;
            Panel18.Enabled = true;
            Panel19.Visible = false;
            Panel20.Visible = false;
            Panel21.Visible = false;
            Panel22.Visible = false;
            Panel23.Visible = false;//按钮
            Panel24.Visible = false;
            Panel25.Visible = false;
            Panel26.Visible = true;
            Panel27.Visible = false;
            Panel28.Visible = false;
            Panel29.Visible = false;
            Panel30.Visible = false;
            Panel31.Visible = false;
            Btn_spare_cc.Visible = false;
            Grid_spare_cc.Columns[10].Visible = false;
            ccRecordDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            ccPerInCharge.Text = Session["UserName"].ToString().Trim();
            BindGrid_spare_cc("and e.ERDAOA_ID = '" + Label_erdaoaid.Text + "'");
            UpdatePanel_dealCC.Update();
            Panel_searchInf.Visible = false;
        }
        if (e.CommandName == "Finan_CC")//财务审核
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_CC.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string ETT_Type = al[0];
            cctype.Text = ETT_Type;
            string EN_EquipName = al[1];
            ccname.Text = EN_EquipName;
            string EMT_Type = al[2];
            ccmodel.Text = EMT_Type;
            string EI_No = al[3];
            ccno.Text = EI_No;
            string ERDAOA_OMaintAppNO = al[4];
            ccOMaintAppNO.Text = ERDAOA_OMaintAppNO;
            string ERDAOA_OAppDep = al[5];
            BindDropDownList7();
            DropDownList7.Items.FindByText(ERDAOA_OAppDep.ToString().Trim()).Selected = true;
            string ERDAOA_OAppPer = al[6];
            ccOAppPer.Text = ERDAOA_OAppPer;
            DateTime ERDAOA_OAppTime = Convert.ToDateTime(al[7].ToString());
            ccOAppTime.Text = ERDAOA_OAppTime.ToString("yyyy-MM-dd HH:mm:ss");
            string ERDAOA_OAppState = al[8];
            ccOAppState.Text = ERDAOA_OAppState;
            string ERDAOA_OMaintePlace = al[9];
            ccPlace.Text = ERDAOA_OMaintePlace;
            string ERDAOA_Feature = al[10];
            ccFeature.Text = ERDAOA_Feature;
            string ERDAOA_OReson = al[11];
            ccOReson.Text = ERDAOA_OReson;
            string ERDAOA_ID = al[12];
            Label_erdaoaid.Text = ERDAOA_ID;
            string ERDAOA_Approver = al[13];
            ccApprover.Text = ERDAOA_Approver;
            DateTime ERDAOA_ApprovalT = Convert.ToDateTime(al[14].ToString());
            ccApprovalT.Text = ERDAOA_ApprovalT.ToString("yyyy-MM-dd HH:mm:ss");
            string ERDAOA_ApprovalSugg = al[15];
            ccApprovalSugg.Text = ERDAOA_ApprovalSugg;
            string ERDAOA_ApprovalRes = al[16];
            ccApprovalRes.Text = ERDAOA_ApprovalRes;
            DateTime ERDAOA_ExpectODate = Convert.ToDateTime(al[17].ToString());
            ccExpectODate.Text = ERDAOA_ExpectODate.ToString("yyyy-MM-dd HH:mm:ss");
            DateTime ERDAOA_ExpectIDate = Convert.ToDateTime(al[18].ToString());
            ccExpectIDate.Text = ERDAOA_ExpectIDate.ToString("yyyy-MM-dd HH:mm:ss");
            string ERDAOA_ExpectCost = al[19];
            ccExpectCost.Text = ERDAOA_ExpectCost;
            string ERDAOA_PerInCharge = al[20];
            ccPerInCharge.Text = ERDAOA_PerInCharge;
            DateTime ERDAOA_RecordDate = Convert.ToDateTime(al[21].ToString());
            ccRecordDate.Text = ERDAOA_RecordDate.ToString("yyyy-MM-dd HH:mm:ss");

            Panel_dealCC.Visible = true;
            Panel15.Visible = true;
            Panel15.Enabled = false;
            Panel16.Visible = true;
            Panel17.Visible = true;
            Panel17.Enabled = false;
            Panel18.Visible = true;
            Panel18.Enabled = false;
            Panel19.Visible = true;
            Panel19.Enabled = true;
            Panel20.Visible = false;
            Panel21.Visible = false;
            Panel22.Visible = false;
            Panel23.Visible = false;//按钮
            Panel24.Visible = false;
            Panel25.Visible = false;
            Panel26.Visible = false;
            Panel27.Visible = true;
            Panel28.Visible = false;
            Panel29.Visible = false;
            Panel30.Visible = false;
            Panel31.Visible = false;
            Btn_spare_cc.Visible = false;
            Grid_spare_cc.Columns[10].Visible = false;
            Label74.Visible = false;
            ccFinanRes.Visible = false;
            ccFinanTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            ccFinanPer.Text = Session["UserName"].ToString().Trim();
            ccFinanSugg.Text = "";
            BindGrid_spare_cc("and e.ERDAOA_ID = '" + Label_erdaoaid.Text + "'");
            UpdatePanel_dealCC.Update();
            Panel_searchInf.Visible = false;
        }
        if (e.CommandName == "Confirmor_CC")//出厂确认
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_CC.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string ETT_Type = al[0];
            cctype.Text = ETT_Type;
            string EN_EquipName = al[1];
            ccname.Text = EN_EquipName;
            string EMT_Type = al[2];
            ccmodel.Text = EMT_Type;
            string EI_No = al[3];
            ccno.Text = EI_No;
            string ERDAOA_OMaintAppNO = al[4];
            ccOMaintAppNO.Text = ERDAOA_OMaintAppNO;
            string ERDAOA_OAppDep = al[5];
            BindDropDownList7();
            DropDownList7.Items.FindByText(ERDAOA_OAppDep.ToString().Trim()).Selected = true;
            string ERDAOA_OAppPer = al[6];
            ccOAppPer.Text = ERDAOA_OAppPer;
            DateTime ERDAOA_OAppTime = Convert.ToDateTime(al[7].ToString());
            ccOAppTime.Text = ERDAOA_OAppTime.ToString("yyyy-MM-dd HH:mm:ss");
            string ERDAOA_OAppState = al[8];
            ccOAppState.Text = ERDAOA_OAppState;
            string ERDAOA_OMaintePlace = al[9];
            ccPlace.Text = ERDAOA_OMaintePlace;
            string ERDAOA_Feature = al[10];
            ccFeature.Text = ERDAOA_Feature;
            string ERDAOA_OReson = al[11];
            ccOReson.Text = ERDAOA_OReson;
            string ERDAOA_ID = al[12];
            Label_erdaoaid.Text = ERDAOA_ID;
            string ERDAOA_Approver = al[13];
            ccApprover.Text = ERDAOA_Approver;
            DateTime ERDAOA_ApprovalT = Convert.ToDateTime(al[14].ToString());
            ccApprovalT.Text = ERDAOA_ApprovalT.ToString("yyyy-MM-dd HH:mm:ss");
            string ERDAOA_ApprovalSugg = al[15];
            ccApprovalSugg.Text = ERDAOA_ApprovalSugg;
            string ERDAOA_ApprovalRes = al[16];
            ccApprovalRes.Text = ERDAOA_ApprovalRes;
            DateTime ERDAOA_ExpectODate = Convert.ToDateTime(al[17].ToString());
            ccExpectODate.Text = ERDAOA_ExpectODate.ToString("yyyy-MM-dd HH:mm:ss");
            DateTime ERDAOA_ExpectIDate = Convert.ToDateTime(al[18].ToString());
            ccExpectIDate.Text = ERDAOA_ExpectIDate.ToString("yyyy-MM-dd HH:mm:ss");
            string ERDAOA_ExpectCost = al[19];
            ccExpectCost.Text = ERDAOA_ExpectCost;
            string ERDAOA_PerInCharge = al[20];
            ccPerInCharge.Text = ERDAOA_PerInCharge;
            DateTime ERDAOA_RecordDate = Convert.ToDateTime(al[21].ToString());
            ccRecordDate.Text = ERDAOA_RecordDate.ToString("yyyy-MM-dd HH:mm:ss");
            string ERDAOA_FinanPer = al[22];
            ccFinanPer.Text = ERDAOA_FinanPer;
            DateTime ERDAOA_FinanTime = Convert.ToDateTime(al[23].ToString());
            ccFinanTime.Text = ERDAOA_FinanTime.ToString("yyyy-MM-dd HH:mm:ss");
            string ERDAOA_FinanSugg = al[24];
            ccFinanSugg.Text = ERDAOA_FinanSugg;
            string ERDAOA_FinanRes = al[25];
            ccFinanRes.Text = ERDAOA_FinanRes;

            Panel_dealCC.Visible = true;
            Panel15.Visible = true;
            Panel15.Enabled = false;
            Panel16.Visible = true;
            Panel17.Visible = true;
            Panel17.Enabled = false;
            Panel18.Visible = true;
            Panel18.Enabled = false;
            Panel19.Visible = true;
            Panel19.Enabled = false;
            Panel20.Visible = true;
            Panel20.Enabled = true;
            Panel21.Visible = false;
            Panel22.Visible = false;
            Panel23.Visible = false;//按钮
            Panel24.Visible = false;
            Panel25.Visible = false;
            Panel26.Visible = false;
            Panel27.Visible = false;
            Panel28.Visible = true;
            Panel29.Visible = false;
            Panel30.Visible = false;
            Panel31.Visible = false;
            Btn_spare_cc.Visible = false;
            Grid_spare_cc.Columns[10].Visible = false;
            Label74.Visible = true;
            ccFinanRes.Visible = true;
            ccOCTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            ccOConfirmor.Text = Session["UserName"].ToString().Trim();
            BindGrid_spare_cc("and e.ERDAOA_ID = '" + Label_erdaoaid.Text + "'");
            UpdatePanel_dealCC.Update();
            Panel_searchInf.Visible = false;
        }
        if (e.CommandName == "Act_CC")//完善实际
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_CC.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string ETT_Type = al[0];
            cctype.Text = ETT_Type;
            string EN_EquipName = al[1];
            ccname.Text = EN_EquipName;
            string EMT_Type = al[2];
            ccmodel.Text = EMT_Type;
            string EI_No = al[3];
            ccno.Text = EI_No;
            string ERDAOA_OMaintAppNO = al[4];
            ccOMaintAppNO.Text = ERDAOA_OMaintAppNO;
            string ERDAOA_OAppDep = al[5];
            BindDropDownList7();
            DropDownList7.Items.FindByText(ERDAOA_OAppDep.ToString().Trim()).Selected = true;
            string ERDAOA_OAppPer = al[6];
            ccOAppPer.Text = ERDAOA_OAppPer;
            DateTime ERDAOA_OAppTime = Convert.ToDateTime(al[7].ToString());
            ccOAppTime.Text = ERDAOA_OAppTime.ToString("yyyy-MM-dd HH:mm:ss");
            string ERDAOA_OAppState = al[8];
            ccOAppState.Text = ERDAOA_OAppState;
            string ERDAOA_OMaintePlace = al[9];
            ccPlace.Text = ERDAOA_OMaintePlace;
            string ERDAOA_Feature = al[10];
            ccFeature.Text = ERDAOA_Feature;
            string ERDAOA_OReson = al[11];
            ccOReson.Text = ERDAOA_OReson;
            string ERDAOA_ID = al[12];
            Label_erdaoaid.Text = ERDAOA_ID;
            string ERDAOA_Approver = al[13];
            ccApprover.Text = ERDAOA_Approver;
            DateTime ERDAOA_ApprovalT = Convert.ToDateTime(al[14].ToString());
            ccApprovalT.Text = ERDAOA_ApprovalT.ToString("yyyy-MM-dd HH:mm:ss");
            string ERDAOA_ApprovalSugg = al[15];
            ccApprovalSugg.Text = ERDAOA_ApprovalSugg;
            string ERDAOA_ApprovalRes = al[16];
            ccApprovalRes.Text = ERDAOA_ApprovalRes;
            DateTime ERDAOA_ExpectODate = Convert.ToDateTime(al[17].ToString());
            ccExpectODate.Text = ERDAOA_ExpectODate.ToString("yyyy-MM-dd HH:mm:ss");
            DateTime ERDAOA_ExpectIDate = Convert.ToDateTime(al[18].ToString());
            ccExpectIDate.Text = ERDAOA_ExpectIDate.ToString("yyyy-MM-dd HH:mm:ss");
            string ERDAOA_ExpectCost = al[19];
            ccExpectCost.Text = ERDAOA_ExpectCost;
            string ERDAOA_PerInCharge = al[20];
            ccPerInCharge.Text = ERDAOA_PerInCharge;
            DateTime ERDAOA_RecordDate = Convert.ToDateTime(al[21].ToString());
            ccRecordDate.Text = ERDAOA_RecordDate.ToString("yyyy-MM-dd HH:mm:ss");
            string ERDAOA_FinanPer = al[22];
            ccFinanPer.Text = ERDAOA_FinanPer;
            DateTime ERDAOA_FinanTime = Convert.ToDateTime(al[23].ToString());
            ccFinanTime.Text = ERDAOA_FinanTime.ToString("yyyy-MM-dd HH:mm:ss");
            string ERDAOA_FinanSugg = al[24];
            ccFinanSugg.Text = ERDAOA_FinanSugg;
            string ERDAOA_FinanRes = al[25];
            ccFinanRes.Text = ERDAOA_FinanRes;
            string ERDAOA_OConfirmor = al[26];
            ccOConfirmor.Text = ERDAOA_OConfirmor;
            DateTime ERDAOA_OCTime = Convert.ToDateTime(al[27].ToString());
            ccOCTime.Text = ERDAOA_OCTime.ToString("yyyy-MM-dd HH:mm:ss");

            Panel_dealCC.Visible = true;
            Panel15.Visible = true;
            Panel15.Enabled = false;
            Panel16.Visible = true;
            Panel17.Visible = true;
            Panel17.Enabled = false;
            Panel18.Visible = true;
            Panel18.Enabled = false;
            Panel19.Visible = true;
            Panel19.Enabled = false;
            Panel20.Visible = true;
            Panel20.Enabled = false;
            Panel21.Visible = true;
            Panel21.Enabled = true;
            Panel22.Visible = false;
            Panel23.Visible = false;//按钮
            Panel24.Visible = false;
            Panel25.Visible = false;
            Panel26.Visible = false;
            Panel27.Visible = false;
            Panel28.Visible = false;
            Panel29.Visible = true;
            Panel30.Visible = false;
            Panel31.Visible = false;
            Btn_spare_cc.Visible = false;
            Grid_spare_cc.Columns[10].Visible = false;
            ccPerfectTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            ccPerfectPer.Text = Session["UserName"].ToString().Trim();
            ccActODate.Text = "";
            ccActIDate.Text = "";
            ccActCost.Text = "";
            BindGrid_spare_cc("and e.ERDAOA_ID = '" + Label_erdaoaid.Text + "'");
            UpdatePanel_dealCC.Update();
            Panel_searchInf.Visible = false;
        }
        if (e.CommandName == "FinanConfirmor_CC")//财务确认
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_CC.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string ETT_Type = al[0];
            cctype.Text = ETT_Type;
            string EN_EquipName = al[1];
            ccname.Text = EN_EquipName;
            string EMT_Type = al[2];
            ccmodel.Text = EMT_Type;
            string EI_No = al[3];
            ccno.Text = EI_No;
            string ERDAOA_OMaintAppNO = al[4];
            ccOMaintAppNO.Text = ERDAOA_OMaintAppNO;
            string ERDAOA_OAppDep = al[5];
            BindDropDownList7();
            DropDownList7.Items.FindByText(ERDAOA_OAppDep.ToString().Trim()).Selected = true;
            string ERDAOA_OAppPer = al[6];
            ccOAppPer.Text = ERDAOA_OAppPer;
            DateTime ERDAOA_OAppTime = Convert.ToDateTime(al[7].ToString());
            ccOAppTime.Text = ERDAOA_OAppTime.ToString("yyyy-MM-dd HH:mm:ss");
            string ERDAOA_OAppState = al[8];
            ccOAppState.Text = ERDAOA_OAppState;
            string ERDAOA_OMaintePlace = al[9];
            ccPlace.Text = ERDAOA_OMaintePlace;
            string ERDAOA_Feature = al[10];
            ccFeature.Text = ERDAOA_Feature;
            string ERDAOA_OReson = al[11];
            ccOReson.Text = ERDAOA_OReson;
            string ERDAOA_ID = al[12];
            Label_erdaoaid.Text = ERDAOA_ID;
            string ERDAOA_Approver = al[13];
            ccApprover.Text = ERDAOA_Approver;
            DateTime ERDAOA_ApprovalT = Convert.ToDateTime(al[14].ToString());
            ccApprovalT.Text = ERDAOA_ApprovalT.ToString("yyyy-MM-dd HH:mm:ss");
            string ERDAOA_ApprovalSugg = al[15];
            ccApprovalSugg.Text = ERDAOA_ApprovalSugg;
            string ERDAOA_ApprovalRes = al[16];
            ccApprovalRes.Text = ERDAOA_ApprovalRes;
            DateTime ERDAOA_ExpectODate = Convert.ToDateTime(al[17].ToString());
            ccExpectODate.Text = ERDAOA_ExpectODate.ToString("yyyy-MM-dd HH:mm:ss");
            DateTime ERDAOA_ExpectIDate = Convert.ToDateTime(al[18].ToString());
            ccExpectIDate.Text = ERDAOA_ExpectIDate.ToString("yyyy-MM-dd HH:mm:ss");
            string ERDAOA_ExpectCost = al[19];
            ccExpectCost.Text = ERDAOA_ExpectCost;
            string ERDAOA_PerInCharge = al[20];
            ccPerInCharge.Text = ERDAOA_PerInCharge;
            DateTime ERDAOA_RecordDate = Convert.ToDateTime(al[21].ToString());
            ccRecordDate.Text = ERDAOA_RecordDate.ToString("yyyy-MM-dd HH:mm:ss");
            string ERDAOA_FinanPer = al[22];
            ccFinanPer.Text = ERDAOA_FinanPer;
            DateTime ERDAOA_FinanTime = Convert.ToDateTime(al[23].ToString());
            ccFinanTime.Text = ERDAOA_FinanTime.ToString("yyyy-MM-dd HH:mm:ss");
            string ERDAOA_FinanSugg = al[24];
            ccFinanSugg.Text = ERDAOA_FinanSugg;
            string ERDAOA_FinanRes = al[25];
            ccFinanRes.Text = ERDAOA_FinanRes;
            string ERDAOA_OConfirmor = al[26];
            ccOConfirmor.Text = ERDAOA_OConfirmor;
            DateTime ERDAOA_OCTime = Convert.ToDateTime(al[27].ToString());
            ccOCTime.Text = ERDAOA_OCTime.ToString("yyyy-MM-dd HH:mm:ss");
            DateTime ERDAOA_ActODate = Convert.ToDateTime(al[28].ToString());
            ccActODate.Text = ERDAOA_ActODate.ToString("yyyy-MM-dd HH:mm:ss");
            string ERDAOA_ActCost = al[29];
            ccActCost.Text = ERDAOA_ActCost;
            DateTime ERDAOA_ActIDate = Convert.ToDateTime(al[30].ToString());
            ccActIDate.Text = ERDAOA_ActIDate.ToString("yyyy-MM-dd HH:mm:ss");
            string ERDAOA_PerfectPer = al[31];
            ccPerfectPer.Text = ERDAOA_PerfectPer;
            DateTime ERDAOA_PerfectTime = Convert.ToDateTime(al[32].ToString());
            ccPerfectTime.Text = ERDAOA_PerfectTime.ToString("yyyy-MM-dd HH:mm:ss");

            Panel_dealCC.Visible = true;
            Panel15.Visible = true;
            Panel15.Enabled = false;
            Panel16.Visible = true;
            Panel17.Visible = true;
            Panel17.Enabled = false;
            Panel18.Visible = true;
            Panel18.Enabled = false;
            Panel19.Visible = true;
            Panel19.Enabled = false;
            Panel20.Visible = true;
            Panel20.Enabled = false;
            Panel21.Visible = true;
            Panel21.Enabled = false;
            Panel22.Visible = true;
            Panel22.Enabled = true;
            Panel23.Visible = false;//按钮
            Panel24.Visible = false;
            Panel25.Visible = false;
            Panel26.Visible = false;
            Panel27.Visible = false;
            Panel28.Visible = false;
            Panel29.Visible = false;
            Panel30.Visible = true;
            Panel31.Visible = false;
            Btn_spare_cc.Visible = false;
            Grid_spare_cc.Columns[10].Visible = false;
            ccFCTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            ccFinanConfirmor.Text = Session["UserName"].ToString().Trim();
            BindGrid_spare_cc("and e.ERDAOA_ID = '" + Label_erdaoaid.Text + "'");
            UpdatePanel_dealCC.Update();
            Panel_searchInf.Visible = false;
        }
        if (e.CommandName == "Delete_CC")//删除
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_CC.SelectedIndex = row.RowIndex;

            //Guid ERDAOA_ID = new Guid(Convert.ToString(e.CommandArgument));
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            Guid ERDAOA_ID = new Guid (al[0]);
            string ERDAOA_OAppState = al[1];
            if (ERDAOA_OAppState != "待提交")
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('该状态下不能删除！')", true);
                return;
            }
            equipMaintenanceAppL.Delete_EquipRealDetailAOApp_CN(ERDAOA_ID);
            UpdatePanel_CN.Update();
            //BindGridView_CC("and a.EMA_ID='" + this.Label_emaid.Text.ToString() + "' and (a.ERDAOA_OAppState='待提交' or a.ERDAOA_OAppState='不通过')");
            BindGridView_CC("and a.EMA_ID='" + Label_emaid.Text.ToString() + "'");
            Panel_searchInf.Visible = false;
            Panel_dealCC.Visible = false;
            UpdatePanel_dealCC.Update();
        }
    }
    //Gridview翻页
    protected void GridView_CC_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView_CC.BottomPagerRow;


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
        string condition3 = GetCondition3();
        BindGridView_CC(condition3);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView_CC.PageCount ? GridView_CC.PageCount - 1 : newPageIndex;
        GridView_CC.PageIndex = newPageIndex;
        GridView_CC.DataBind();
    }
    protected void GridView_CC_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }

    #endregion 出厂维修及GridView_CC

    #region 申请出厂维修
    protected void deal_cc_Click(object sender, EventArgs e)
    {
        if (DropDownList7.SelectedValue.ToString() == "" || ccPlace.Text.ToString() == "" || ccFeature.Text.ToString() == "" || ccOReson.Text.ToString()=="")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        Guid EI_ID = new Guid(Label_eiid.Text.ToString());
        Guid EMA_ID = new Guid(Label_emaid.Text.ToString());
        string ERDAOA_OAppDep = DropDownList7.SelectedValue.ToString();
        string ERDAOA_OAppPer=ccOAppPer.Text.ToString();
        DateTime ERDAOA_OAppTime = Convert.ToDateTime(ccOAppTime.Text.ToString());
        string ERDAOA_OAppState = "待提交";
        string ERDAOA_OMaintePlace = ccPlace.Text.ToString();
        string ERDAOA_Feature=ccFeature.Text.ToString();
        string ERDAOA_OReson = ccOReson.Text.ToString();
        DataSet ds = equipMaintenanceAppL.Search_EquipRealDetailAOApp_CC("and a.EI_ID = '" + Label_eiid.Text.ToString() + "' and a.EMA_ID = '" + Label_emaid.Text.ToString() + "' and ERDAOA_OAppState='待提交'");
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count != 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('该设备已有出厂维修申请，不能重复！')", true);
            return;
        }
        equipMaintenanceAppL.Insert_EquipRealDetailAOApp_CC(EI_ID, EMA_ID, ERDAOA_OAppDep, ERDAOA_OAppPer, ERDAOA_OAppTime, ERDAOA_OAppState, ERDAOA_OMaintePlace,
                                              ERDAOA_Feature, ERDAOA_OReson);
        //BindGridView_CC("and a.EMA_ID='" + this.Label_emaid.Text.ToString() + "' and (a.ERDAOA_OAppState='待提交' or a.ERDAOA_ApprovalRes='不通过')");
        BindGridView_CC("and a.EMA_ID='" + Label_emaid.Text.ToString() + "'");
        Panel_dealCC.Visible = false;
        UpdatePanel_dealCC.Update();
        UpdatePanel_CN.Update();
        Panel_searchInf.Visible = false;

        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('出厂维修申请已保存，请选择所用备件！')", true);
    }
    protected void Cancel_dealcc_Click(object sender, EventArgs e)
    {
        Panel_dealCC.Visible = false;
        UpdatePanel_dealCC.Update();
        Panel_searchInf.Visible = false;
    }
    #endregion 申请出厂维修

    #region 修改出厂维修申请，选择所用备件及Grid_spare_cc
    protected void Btn_spare_cc_Click(object sender, EventArgs e)
    {
        BindGrid_NewEquipSpare("and x.EMT_ID = '" + Label_emt.Text.ToString() + "'");
        Panel_NewSpare.Visible = true;
        UpdatePanel_NewSpare.Update();
    }
    //提交按钮
    protected void btn_editcc_Click(object sender, EventArgs e)
    {
        if (DropDownList7.SelectedValue.ToString() == "" || ccPlace.Text.ToString() == "" || ccFeature.Text.ToString() == "" || ccOReson.Text.ToString() == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        Guid ERDAOA_ID = new Guid(Label_erdaoaid.Text.ToString());
        string ERDAOA_OAppDep = DropDownList7.SelectedValue.ToString();
        string ERDAOA_OAppPer = ccOAppPer.Text.ToString();
        DateTime ERDAOA_OAppTime = Convert.ToDateTime(ccOAppTime.Text.ToString());
        string ERDAOA_OAppState = "已提交";
        string ERDAOA_OMaintePlace = ccPlace.Text.ToString();
        string ERDAOA_Feature = ccFeature.Text.ToString();
        string ERDAOA_OReson = ccOReson.Text.ToString(); 
        equipMaintenanceAppL.Update_EquipRealDetailAOApp_CC(ERDAOA_ID, ERDAOA_OAppDep, ERDAOA_OAppPer, ERDAOA_OAppTime, ERDAOA_OAppState, ERDAOA_OMaintePlace,
                                              ERDAOA_Feature, ERDAOA_OReson);
        //BindGridView_CC("and a.EMA_ID='" + this.Label_emaid.Text.ToString() + "' and (a.ERDAOA_OAppState='待提交' or (a.ERDAOA_ApprovalRes='不通过' and a.ERDAOA_OAppState='已审批'))");
        BindGridView_CC("and a.EMA_ID='" + Label_emaid.Text.ToString() + "'");
        Panel_dealCC.Visible = false;
        UpdatePanel_dealCC.Update();
        UpdatePanel_CN.Update();
        Panel_searchInf.Visible = false;
        Panel_NewSpare.Visible = false;
        UpdatePanel_NewSpare.Update();
        //RTX
        string message = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "提交了申请单为"+Label_appno.Text+"、设备编号为" + ccmodel.Text + "的出厂维修申请，请审批";
        string sErr = RTXhelper.Send(message, "出厂维修审批");
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('" + sErr + "')", true);
        }

    }
    //取消按钮
    protected void Cancel_editcc_Click(object sender, EventArgs e)
    {
        Panel_dealCC.Visible = false;
        UpdatePanel_dealCC.Update();
        Panel_NewSpare.Visible = false;
        UpdatePanel_NewSpare.Update();
    }
    //所用设备Grid_spare
    protected void Grid_spare_cc_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete_spare_cc")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_spare_cc.SelectedIndex = row.RowIndex;

            Guid EMSAUS_ID = new Guid(Convert.ToString(e.CommandArgument));
            equipUpkeepPlanL.Delete_EquipUpkeepPlan_Spare(EMSAUS_ID);
            BindGrid_spare_cc("and e.ERDAOA_ID = '" + Label_erdaoaid.Text + "'");
            UpdatePanel_dealCC.Update();
        }
    }
    protected void Grid_spare_cc_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_spare_cc.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox55");   // refer to the TextBox with the NewPageIndex value
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
        BindGrid_spare("and e.ERDAOA_ID = '" + Label_erdaoaid.Text + "'");
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_spare_cc.PageCount ? Grid_spare_cc.PageCount - 1 : newPageIndex;
        Grid_spare_cc.PageIndex = newPageIndex;
        Grid_spare_cc.DataBind();
    }
    protected void Grid_spare_cc_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
    #endregion 修改出厂维修申请，选择所用备件及Grid_spare_cc

    #region 出厂审批
    protected void Approver_ok_Click(object sender, EventArgs e)
    {
        Guid ERDAOA_ID = new Guid(Label_erdaoaid.Text.ToString());
        string ERDAOA_Approver = ccApprover.Text.ToString();
        DateTime ERDAOA_ApprovalT = Convert.ToDateTime(ccApprovalT.Text.ToString());
        string ERDAOA_ApprovalSugg = ccApprovalSugg.Text.ToString();
        string ERDAOA_ApprovalRes = "通过";
        string ERDAOA_OAppState = "已审批";
        DateTime ERDAOA_OAppTime = Convert.ToDateTime(ccOAppTime.Text.ToString());

        if (ERDAOA_ApprovalT < ERDAOA_OAppTime)
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_dealCC, GetType(), "alert", "alert('审批时间必须大于申请时间！')", true);
            return;
        }
        equipMaintenanceAppL.Update_EquipRealDetailAOApp_CCSP(ERDAOA_ID, ERDAOA_Approver, ERDAOA_ApprovalT, ERDAOA_ApprovalSugg, ERDAOA_ApprovalRes, ERDAOA_OAppState);
        BindGridView_CC("and a.EMA_ID='" + Label_emaid.Text.ToString() + "' and a.ERDAOA_OAppState='已提交'");
        Panel_dealCC.Visible = false;
        UpdatePanel_dealCC.Update();
        UpdatePanel_CN.Update();
        //RTX
        string message = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "审批通过了申请单为" + Label_appno.Text + "、设备编号为" + ccmodel.Text + "的出厂维修申请，请给出预算";
        string sErr = RTXhelper.Send(message, "出厂维修预算");
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('" + sErr + "')", true);
        }
    }
    protected void Approver_notok_Click(object sender, EventArgs e)
    {
        Guid ERDAOA_ID = new Guid(Label_erdaoaid.Text.ToString());
        string ERDAOA_Approver = ccApprover.Text.ToString();
        DateTime ERDAOA_ApprovalT = Convert.ToDateTime(ccApprovalT.Text.ToString());
        string ERDAOA_ApprovalSugg = ccApprovalSugg.Text.ToString();
        string ERDAOA_ApprovalRes = "不通过";
        string ERDAOA_OAppState = "已审批";
        DateTime ERDAOA_OAppTime = Convert.ToDateTime(ccOAppTime.Text.ToString());

        if (ERDAOA_ApprovalT < ERDAOA_OAppTime)
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_dealCC, GetType(), "alert", "alert('审批时间必须大于申请时间！')", true);
            return;
        }
        equipMaintenanceAppL.Update_EquipRealDetailAOApp_CCSP(ERDAOA_ID, ERDAOA_Approver, ERDAOA_ApprovalT, ERDAOA_ApprovalSugg, ERDAOA_ApprovalRes, ERDAOA_OAppState);
        BindGridView_CC("and a.EMA_ID='" + Label_emaid.Text.ToString() + "' and a.ERDAOA_OAppState='已提交'");
        Panel_dealCC.Visible = false;
        UpdatePanel_dealCC.Update();
        UpdatePanel_CN.Update();
        //RTX
        string message = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "审批驳回了申请单为" + Label_appno.Text + "、设备编号为" + ccmodel.Text + "的出厂维修申请，请重提申请";
        string sErr = RTXhelper.SendbyUserName(message, ccOAppPer.Text);
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('" + sErr + "')", true);
        }
    }
    protected void Approver_cancel_Click(object sender, EventArgs e)
    {
        Panel_dealCC.Visible = false;
        UpdatePanel_dealCC.Update();
    }
    #endregion 出厂审批

    #region 出厂维修预算
    protected void btn_Expect_Click(object sender, EventArgs e)
    {
        if (ccExpectODate.Text.ToString() == "" || ccExpectIDate.Text.ToString() == "" || ccExpectCost.Text.ToString()=="")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        Guid ERDAOA_ID = new Guid(Label_erdaoaid.Text.ToString());
        DateTime ERDAOA_ExpectODate = Convert.ToDateTime(ccExpectODate.Text.ToString());
        DateTime ERDAOA_ExpectIDate = Convert.ToDateTime(ccExpectIDate.Text.ToString());
        decimal m1;
        if (!(decimal.TryParse(ccExpectCost.Text, out m1)))
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_dealCC, GetType(), "alert", "alert('费用必须为数字！')", true);
            return;
        }
        decimal ERDAOA_ExpectCost = m1;
        string ERDAOA_PerInCharge = ccPerInCharge.Text.ToString();
        DateTime ERDAOA_RecordDate = Convert.ToDateTime(ccRecordDate.Text.ToString());
        string ERDAOA_OAppState = "已预算";
        DateTime ERDAOA_ApprovalT = Convert.ToDateTime(ccApprovalT.Text.ToString());

        if (ERDAOA_RecordDate < ERDAOA_ApprovalT)
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_dealCC, GetType(), "alert", "alert('记录日期必须大于审批时间！')", true);
            return;
        }
        if (ERDAOA_ExpectIDate < ERDAOA_ExpectODate)
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_dealCC, GetType(), "alert", "alert('回厂日期必须大于出厂日期！')", true);
            return;
        }
        if (ERDAOA_ExpectODate < ERDAOA_RecordDate)
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_dealCC, GetType(), "alert", "alert('预计出厂日期必须大于记录日期！')", true);
            return;
        }
        equipMaintenanceAppL.Update_EquipRealDetailAOApp_CCYS(ERDAOA_ID, ERDAOA_ExpectODate, ERDAOA_ExpectIDate, ERDAOA_ExpectCost, ERDAOA_PerInCharge, ERDAOA_RecordDate, ERDAOA_OAppState);
        BindGridView_CC("and a.EMA_ID='" + Label_emaid.Text.ToString() + "' and ((a.ERDAOA_OAppState='已审批' and a.ERDAOA_ApprovalRes='通过') or a.ERDAOA_FinanRes='不通过')");
        Panel_dealCC.Visible = false;
        UpdatePanel_dealCC.Update();
        UpdatePanel_CN.Update();
        //RTX
        string message = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "预算完成了申请单为" + Label_appno.Text + "、设备编号为" + ccmodel.Text + "的出厂维修申请单，请审核。";
        string sErr = RTXhelper.Send(message, "出厂维修财务审核");
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('" + sErr + "')", true);
        }

    }
    protected void Cancel_Expect_Click(object sender, EventArgs e)
    {
        Panel_dealCC.Visible = false;
        UpdatePanel_dealCC.Update();
    }
    #endregion 出厂维修预算

    #region 财务审核
    protected void Finan_ok_Click(object sender, EventArgs e)
    {
        Guid ERDAOA_ID = new Guid(Label_erdaoaid.Text.ToString());
        string ERDAOA_FinanPer = ccFinanPer.Text.ToString();
        DateTime ERDAOA_FinanTime = Convert.ToDateTime(ccFinanTime.Text.ToString());
        string ERDAOA_FinanSugg = ccFinanSugg.Text.ToString();
        string ERDAOA_FinanRes = "通过";
        string ERDAOA_OAppState = "财务已审";
        DateTime ERDAOA_RecordDate = Convert.ToDateTime(ccRecordDate.Text.ToString());

        if (ERDAOA_FinanTime < ERDAOA_RecordDate)
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_dealCC, GetType(), "alert", "alert('财务审核时间必须大于记录时间！')", true);
            return;
        }
        equipMaintenanceAppL.Update_EquipRealDetailAOApp_CCSH(ERDAOA_ID, ERDAOA_FinanPer, ERDAOA_FinanTime, ERDAOA_FinanSugg, ERDAOA_FinanRes, ERDAOA_OAppState);
        BindGridView_CC("and a.EMA_ID='" + Label_emaid.Text.ToString() + "' and a.ERDAOA_OAppState='已预算'");
        Panel_dealCC.Visible = false;
        UpdatePanel_dealCC.Update();
        UpdatePanel_CN.Update();
        //RTX
        string message = "ERP系统消息：财务部" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "审核通过了申请单为" + Label_appno.Text + "、设备编号为" + ccmodel.Text + "的出厂维修，请确认出厂。";
        string sErr = RTXhelper.Send(message, "出厂维修出厂确认");
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('" + sErr + "')", true);
        }
    }
    protected void Finan_notok_Click(object sender, EventArgs e)
    {
        Guid ERDAOA_ID = new Guid(Label_erdaoaid.Text.ToString());
        string ERDAOA_FinanPer = ccFinanPer.Text.ToString();
        DateTime ERDAOA_FinanTime = Convert.ToDateTime(ccFinanTime.Text.ToString());
        string ERDAOA_FinanSugg = ccFinanSugg.Text.ToString();
        string ERDAOA_FinanRes = "不通过";
        string ERDAOA_OAppState = "财务已审";
        DateTime ERDAOA_RecordDate = Convert.ToDateTime(ccRecordDate.Text.ToString());

        if (ERDAOA_FinanTime < ERDAOA_RecordDate)
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_dealCC, GetType(), "alert", "alert('财务审核时间必须大于记录时间！')", true);
            return;
        }
        equipMaintenanceAppL.Update_EquipRealDetailAOApp_CCSH(ERDAOA_ID, ERDAOA_FinanPer, ERDAOA_FinanTime, ERDAOA_FinanSugg, ERDAOA_FinanRes, ERDAOA_OAppState);
        BindGridView_CC("and a.EMA_ID='" + Label_emaid.Text.ToString() + "' and a.ERDAOA_OAppState='已预算'");
        Panel_dealCC.Visible = false;
        UpdatePanel_dealCC.Update();
        UpdatePanel_CN.Update();
        //RTX
        string message = "ERP系统消息：财务部" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "审核驳回了申请单为" + Label_appno.Text + "、设备编号为" + ccmodel.Text + "的出厂维修，请修改预算。";
        string sErr = RTXhelper.Send(message, "出厂维修预算");
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('" + sErr + "')", true);
        }
    }
    protected void Finan_cancel_Click(object sender, EventArgs e)
    {
        Panel_dealCC.Visible = false;
        UpdatePanel_dealCC.Update();
    }
    #endregion 财务审核

    #region 出厂维修确认
    protected void btn_Confirmor_Click(object sender, EventArgs e)
    {
        Guid ERDAOA_ID = new Guid(Label_erdaoaid.Text.ToString());
        string ERDAOA_OConfirmor = ccOConfirmor.Text.ToString();
        DateTime ERDAOA_OCTime = Convert.ToDateTime(ccOCTime.Text.ToString());
        string ERDAOA_OAppState = "已出厂";
        DateTime ERDAOA_FinanTime = Convert.ToDateTime(ccFinanTime.Text.ToString());

        if (ERDAOA_OCTime < ERDAOA_FinanTime)
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_dealCC, GetType(), "alert", "alert('出厂确认时间必须大于财务审核时间！')", true);
            return;
        }
        equipMaintenanceAppL.Update_EquipRealDetailAOApp_CCQR(ERDAOA_ID, ERDAOA_OConfirmor, ERDAOA_OCTime, ERDAOA_OAppState);
        BindGridView_CC("and a.EMA_ID='" + Label_emaid.Text.ToString() + "' and a.ERDAOA_OAppState='财务已审' and a.ERDAOA_FinanRes='通过'");
        Panel_dealCC.Visible = false;
        UpdatePanel_dealCC.Update();
        UpdatePanel_CN.Update();
        //RTX
        string message = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "确认了申请单为" + Label_appno.Text + "、设备编号为" + ccmodel.Text + "的出厂维修，请关注设备回厂时间。";
        string sErr = RTXhelper.Send(message, "出厂维修回厂信息完善");
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('" + sErr + "')", true);
        }
    }
    protected void Cancel_Confirmor_Click(object sender, EventArgs e)
    {
        Panel_dealCC.Visible = false;
        UpdatePanel_dealCC.Update();
    }
    #endregion 出厂维修确认

    #region 完善回厂信息
    protected void btn_Act_Click(object sender, EventArgs e)
    {
        if (ccActODate.Text.ToString() == "" || ccActIDate.Text.ToString() == "" || ccActCost.Text.ToString() == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        Guid ERDAOA_ID = new Guid(Label_erdaoaid.Text.ToString());
        DateTime ERDAOA_ActODate = Convert.ToDateTime(ccActODate.Text.ToString());
        DateTime ERDAOA_ActIDate = Convert.ToDateTime(ccActIDate.Text.ToString());
        decimal m2;
        if (!(decimal.TryParse(ccActCost.Text, out m2)))
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_dealCC, GetType(), "alert", "alert('费用必须为数字！')", true);
            return;
        }
        decimal ERDAOA_ActCost = m2;
        string ERDAOA_PerfectPer = ccPerfectPer.Text.ToString();
        DateTime ERDAOA_PerfectTime = Convert.ToDateTime(ccPerfectTime.Text.ToString());
        string ERDAOA_OAppState = "已回厂";
        DateTime ERDAOA_OCTime = Convert.ToDateTime(ccOCTime.Text.ToString());

        if (ERDAOA_PerfectTime < ERDAOA_OCTime)
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_dealCC, GetType(), "alert", "alert('完善时间必须大于出厂确认时间！')", true);
            return;
        }
        if (ERDAOA_ActIDate < ERDAOA_ActODate)
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_dealCC, GetType(), "alert", "alert('回厂日期必须大于出厂日期！')", true);
            return;
        }
        if (ERDAOA_PerfectTime < ERDAOA_ActODate)
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_dealCC, GetType(), "alert", "alert('完善时间必须大于回厂日期！')", true);
            return;
        }
        equipMaintenanceAppL.Update_EquipRealDetailAOApp_CCWS(ERDAOA_ID, ERDAOA_ActODate, ERDAOA_ActIDate, ERDAOA_ActCost, ERDAOA_PerfectPer, ERDAOA_PerfectTime, ERDAOA_OAppState);
        BindGridView_CC("and a.EMA_ID='" + Label_emaid.Text.ToString() + "' and a.ERDAOA_OAppState='已出厂' ");
        Panel_dealCC.Visible = false;
        UpdatePanel_dealCC.Update();
        UpdatePanel_CN.Update();
        //RTX
        string message = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "完善了申请单为" + Label_appno.Text + "、设备编号为" + ccmodel.Text + "的维修回厂信息，请确认。";
        string sErr = RTXhelper.Send(message, "出厂维修财务确认");
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('" + sErr + "')", true);
        }
    }
    protected void Cancel_Act_Click(object sender, EventArgs e)
    {
        Panel_dealCC.Visible = false;
        UpdatePanel_dealCC.Update();
    }
    #endregion 完善回厂信息

    #region 财务确认
    protected void btn_FinanConfirmor_Click(object sender, EventArgs e)
    {
        Guid ERDAOA_ID = new Guid(Label_erdaoaid.Text.ToString());
        string ERDAOA_FinanConfirmor = ccOConfirmor.Text.ToString();
        DateTime ERDAOA_FCTime = Convert.ToDateTime(ccFCTime.Text.ToString());
        string ERDAOA_OAppState = "已完成";
        DateTime ERDAOA_PerfectTime = Convert.ToDateTime(ccPerfectTime.Text.ToString());

        if (ERDAOA_FCTime < ERDAOA_PerfectTime)
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_dealCC, GetType(), "alert", "alert('财务确认时间必须大于完善时间！')", true);
            return;
        }
        equipMaintenanceAppL.Update_EquipRealDetailAOApp_CCCW(ERDAOA_ID, ERDAOA_FinanConfirmor, ERDAOA_FCTime, ERDAOA_OAppState);
        BindGridView_CC("and a.EMA_ID='" + Label_emaid.Text.ToString() + "' and a.ERDAOA_OAppState='已回厂'");
        Panel_dealCC.Visible = false;
        UpdatePanel_dealCC.Update();
        UpdatePanel_CN.Update();
        //RTX
        string message = "ERP系统消息：财务部" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "确认了申请单为" + Label_appno.Text + "、设备编号为" + ccmodel.Text + "的出厂维修，若维修完毕，请提交。";
        string sErr = RTXhelper.Send(message, "设备故障维修情况记录");
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('" + sErr + "')", true);
        }
    }
    protected void Cancel_FinanConfirmor_Click(object sender, EventArgs e)
    {
        Panel_dealCC.Visible = false;
        UpdatePanel_dealCC.Update();
    }
    #endregion 财务确认

    #region 查看出厂维修详情
    protected void close_lookdealcc_Click(object sender, EventArgs e)
    {
        Panel_dealCC.Visible = false;
        UpdatePanel_dealCC.Update();
    }
    #endregion 查看出厂维修详情

    #region 真实维修情况
    protected void deal_ok_Click(object sender, EventArgs e)
    {
        Guid EMA_ID=new Guid(Label_emaid.Text.ToString());
        DataSet ds = equipMaintenanceAppL.Search_EquipRealDetailAOApp_CC(" and a.EMA_ID = '" + Label_emaid.Text.ToString() + "' and (a.ERDAOA_OAppState='待提交' or a.ERDAOA_OAppState='已提交' or (a.ERDAOA_OAppState='已审批' and a.ERDAOA_ApprovalRes='通过') or a.ERDAOA_OAppState='已预算' or (a.ERDAOA_OAppState='财务已审' and a.ERDAOA_FinanRes='通过') or a.ERDAOA_OAppState='已出厂' or a.ERDAOA_OAppState='已回厂')"); 
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count != 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('还有未回厂的设备，暂不能提交！')", true);
            return;
        }
        string EMA_AppState="已完成";
        equipMaintenanceAppL.Update_EquipMaintenanceApp_CL(EMA_ID, EMA_AppState);
        BindGrid_MaintenanceApp("and a.EMA_AppState='已确认'");
        Panel_CN.Visible = false;
        UpdatePanel_CN.Update();
        Panel_dealCN.Visible = false;
        UpdatePanel_dealCN.Update();
        Panel_searchInf.Visible = false;
        UpdatePanel_MaintenanceApp.Update();
        //RTX
        string message = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "完成了申请单号为" + Label_appno.Text + "的维修，请验收。";
        string sErr = RTXhelper.SendbyUserName(message, Label_appper.Text);
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('" + sErr + "')", true);
        }

    }
    protected void close_real_Click(object sender, EventArgs e)
    {
        Panel_CN.Visible = false;
        UpdatePanel_CN.Update();
        Panel_dealCN.Visible = false;
        UpdatePanel_dealCN.Update();
        Panel_searchInf.Visible = false;
    }
    protected void deal_close_Click(object sender, EventArgs e)
    {
        Panel_CN.Visible = false;
        UpdatePanel_CN.Update();
        Panel_dealCC.Visible = false;
        UpdatePanel_dealCC.Update();
        Panel_dealCN.Visible = false;
        UpdatePanel_dealCN.Update();
        Panel_searchInf.Visible = false;
    }
    #endregion 真实维修情况

    #region 选择备件及Grid_NewEquipSpare
    //备件精确搜索
    protected void Search_newspare_Click(object sender, EventArgs e)
    {
        string condition2 = GetCondition2();
        BindGrid_NewEquipSpare(condition2);
    }
    protected string GetCondition2()
    {
        string condition2;
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
        temp += "and a.EMT_ID='" + Label_emt.Text + "'";
        condition2 = temp;
        return condition2;
    }
    protected void Clear_newspare_Click(object sender, EventArgs e)
    {
        Textnewspname.Text = "";
        Textnewspno.Text = "";
        Textnewspmodel.Text = "";
        BindGrid_NewEquipSpare("and x.EMT_ID = '" + Label_emt.Text + "'");
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
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox22");   // refer to the TextBox with the NewPageIndex value
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
        BindGrid_NewEquipSpare("and a.EMT_ID='" + Label_emt.Text + "'");
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
                Guid eRDAOA_ID = new Guid(Label_erdaoaid.Text.ToString());
                if (((TextBox)(Grid_NewEquipSpare.Rows[item.RowIndex].Cells[8].FindControl("useno"))).Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                    return;
                }
                int eMSAUS_UseAmount = Convert.ToInt16(((TextBox)(Grid_NewEquipSpare.Rows[item.RowIndex].Cells[8].FindControl("useno"))).Text.Trim());
                string IMIM_TotalNum = (Grid_NewEquipSpare.Rows[item.RowIndex].Cells[7].Text.Trim().ToString());
                if (eMSAUS_UseAmount - float.Parse(IMIM_TotalNum) > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel_NewSpare, GetType(), "aa", "alert('使用数量不能超过总数量!')", true);
                    return;
                }
                if (eMSAUS_UseAmount <= 0 )
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel_NewSpare, GetType(), "aa", "alert('请填写使用数量!')", true);
                    return;
                }
                DataSet ds = equipUpkeepPlanL.Search_EquipUpkeepPlan_Sparedone("and e.ERDAOA_ID = '" + eRDAOA_ID + "' and e.EFUS_ID='" + eFUS_ID + "'");
                //if (!(ds.Tables.Count == 1 && ds.Tables[0].Rows.Count == 0))// have a check 若有一条相同的，就提示，其余不同的则添加。
                if (!(ds.Tables[0].Rows.Count == 0))// have a check 若有一条相同的，就提示，其余不同的也不添加。
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel_NewSpare, GetType(), "aa", "alert('该备件已选，不能重复选择!')", true);
                    return;
                }
                else
                {
                    equipMaintenanceAppL.Insert_EquipRealDetailAOApp_Spare(eFUS_ID, eRDAOA_ID, eMSAUS_UseAmount);
                    BindGrid_spare("and e.ERDAOA_ID = '" + eRDAOA_ID + "'");
                    UpdatePanel_dealCN.Update();
                    BindGrid_spare_cc("and e.ERDAOA_ID = '" + eRDAOA_ID + "'");
                    UpdatePanel_dealCC.Update();
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
            UpdatePanel_NewSpare.Update();
        }
    }
    #endregion 选择备件及Grid_NewEquipSpare
    
}