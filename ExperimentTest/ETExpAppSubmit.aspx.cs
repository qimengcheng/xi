using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using RTXHelper;


public partial class ExperimentTest_ETExpAppSubmit : Page
{
    ExpAppSubmitL expAppSubmitL = new ExpAppSubmitL();
    ExpTestL expTestL = new ExpTestL();
    ExpTestAppInfo expTestAppInfo = new ExpTestAppInfo();
    ExpSampleType_ExpItems expSampleType_ExpItems = new ExpSampleType_ExpItems();
    static Guid id = new Guid();//存储行命令主键
    static Guid idnew = new Guid();//存储新增的空表主键
    static string Save = "0";//存储新建窗口保存状态
    static string condition = ""; //检索条件
    static string Bindc = "";//记录检索栏检索条件用于绑定gridview1数据
    static Guid ResDetailID = new Guid();//存储实验项目明细表ID
    static Guid ExpItemID = new Guid();//存储实验项目ID
    static string BtnSearchItem1="", BtnSearchItem2="", BtnSearchItem3="";//用于存储检索条件，判定绑定数据方式是空还是检索条件

    #region 页面加载
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DropDownList1.Items.Insert(0, new ListItem("请选择", ""));
            DropDownList2.Items.Insert(0, new ListItem("请选择", ""));
            Bind_DdlAppDep(DropDownList2);
            Bind_DdlSampleType(DropDownList1);
            Labeldep.Text = "";
            //expAppSubmitL.Delete_ExpTestApp_View();//页面加载时删除不要的主表，避免不点击关闭就刷新页面
            string Role = Request.QueryString["state"].ToString();
            if (Role == "Submit" && Session["UserRole"].ToString().Contains("实验申请提交"))
            {
                DdlAppStatus.Items.Insert(0, new ListItem("请选择", "0"));
                DdlAppStatus.Items.Insert(1, new ListItem("待提交", "1"));
                DdlAppStatus.Items.Insert(2, new ListItem("已提交", "2"));
                DdlAppStatus.Items.Insert(3, new ListItem("审核通过", "3"));
                DdlAppStatus.Items.Insert(4, new ListItem("审核驳回", "4"));
                DdlAppStatus.Items.Insert(5, new ListItem("实验中", "5"));
                DdlAppStatus.Items.Insert(6, new ListItem("已完成", "6"));
                DdlAppStatus.Items.Insert(7, new ListItem("审批通过", "7"));
                Title = "实验申请提交";
                Bindc = "";
            }
            //else if (Role == "Submit" && Session["UserRole"].ToString().Contains("实验申请查看"))
            //{
            //    DdlAppStatus.Items.Insert(0, new ListItem("请选择", "0"));
            //    DdlAppStatus.Items.Insert(1, new ListItem("待提交", "1"));
            //    DdlAppStatus.Items.Insert(2, new ListItem("已提交", "2"));
            //    DdlAppStatus.Items.Insert(3, new ListItem("审核通过", "3"));
            //    DdlAppStatus.Items.Insert(4, new ListItem("审核驳回", "4"));
            //    DdlAppStatus.Items.Insert(5, new ListItem("实验中", "5"));
            //    DdlAppStatus.Items.Insert(6, new ListItem("已完成", "6"));
            //    DdlAppStatus.Items.Insert(7, new ListItem("已审批", "7"));
            //    this.Title = "实验申请查看";
            //    Bindc = "";
            //}
            else if (Role == "AppAu" && Session["UserRole"].ToString().Contains("实验申请审核"))
            {
                DdlAppStatus.Items.Insert(0, new ListItem("请选择", "0"));
                DdlAppStatus.Items.Insert(1, new ListItem("已提交", "2"));
                //DdlAppStatus.Items.Insert(2, new ListItem("审核通过", "3"));
                //DdlAppStatus.Items.Insert(3, new ListItem("审核驳回", "4"));
                Title = "实验申请审核";
                Bindc = "AND ETA_AppStatus='已提交'";
            }
            else if (Role == "AppAck" && Session["UserRole"].ToString().Contains("实验申请接收"))
            {
                DdlAppStatus.Items.Insert(0, new ListItem("请选择", "0"));
                DdlAppStatus.Items.Insert(1, new ListItem("审核通过", "3"));
                //DdlAppStatus.Items.Insert(2, new ListItem("实验中", "5"));
                Title = "实验申请接收";
                Bindc = "AND ETA_AppStatus='审核通过'";
            }
            else if (Role == "AppRes" && Session["UserRole"].ToString().Contains("实验结果录入"))
            {
                DdlAppStatus.Items.Insert(0, new ListItem("请选择", "0"));
                DdlAppStatus.Items.Insert(1, new ListItem("实验中", "5"));
                DdlAppStatus.Items.Insert(2, new ListItem("审批驳回", "8"));
                Title = "实验结果录入";
                Bindc = "AND (ETA_AppStatus='实验中' or ETA_AppStatus='审批驳回')";
            }
            else if (Role == "AppArl" && Session["UserRole"].ToString().Contains("实验结果审批"))
            {
                DdlAppStatus.Items.Insert(0, new ListItem("请选择", "0"));
                DdlAppStatus.Items.Insert(1, new ListItem("已完成", "6"));
                //DdlAppStatus.Items.Insert(2, new ListItem("已审批", "7"));
                Title = "实验结果审批";
                Bindc = "AND ETA_AppStatus='已完成'";
            }
            else if (Role == "AppView" && Session["UserRole"].ToString().Contains("实验进度追踪"))
            {
                DdlAppStatus.Items.Insert(0, new ListItem("请选择", "0"));
                DdlAppStatus.Items.Insert(1, new ListItem("待提交", "1"));
                DdlAppStatus.Items.Insert(2, new ListItem("已提交", "2"));
                DdlAppStatus.Items.Insert(3, new ListItem("审核通过", "3"));
                DdlAppStatus.Items.Insert(4, new ListItem("审核驳回", "4"));
                DdlAppStatus.Items.Insert(5, new ListItem("实验中", "5"));
                DdlAppStatus.Items.Insert(6, new ListItem("已完成", "6"));
                DdlAppStatus.Items.Insert(7, new ListItem("审批通过", "7"));
                DdlAppStatus.Items.Insert(8, new ListItem("审批驳回", "8"));
                Title = "实验进度追踪";
                Bindc = "";
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        try
        {
            string Role = Request.QueryString["state"].ToString();
            if (Role == "Submit" && Session["UserRole"].ToString().Contains("实验申请提交"))
            {
                LblItemRes.Text = "Amount";
                Grid_ExpApp.Columns[10].Visible = false;
                Grid_ExpApp.Columns[12].Visible = true;
                Grid_ExpApp.Columns[13].Visible = true;
                Grid_ExpApp.Columns[14].Visible = true;
                Grid_ExpApp.Columns[15].Visible = true;
                Grid_ExpApp.Columns[16].Visible = false;
                Grid_ExpApp.Columns[17].Visible = false;
                Grid_ExpApp.Columns[18].Visible = false;
                Grid_ExpApp.Columns[19].Visible = false;
                Grid_ETTestItem.Columns[7].Visible = false;
                Grid_ETTestItem.Columns[8].Visible = false;
                Grid_ETTestItem.Columns[9].Visible = false;
            }
            //else if (Role == "Submit" && Session["UserRole"].ToString().Contains("实验申请查看"))
            //{
            //    this.BtnNewExpApp.Visible = false;
            //    this.Grid_ExpApp.Columns[10].Visible = false;
            //    this.Grid_ExpApp.Columns[13].Visible = false;
            //    this.Grid_ExpApp.Columns[14].Visible = false;
            //    this.Grid_ExpApp.Columns[15].Visible = false;
            //    this.Grid_ExpApp.Columns[16].Visible = false;
            //    this.Grid_ExpApp.Columns[17].Visible = false;
            //    this.Grid_ExpApp.Columns[12].Visible = false;
            //    this.Grid_ETTestItem.Columns[7].Visible = false;
            //    this.Grid_ETTestItem.Columns[8].Visible = false;
            //    this.Grid_ETTestItem.Columns[9].Visible = false;
            //    this.Grid_ETTestItem.Columns[10].Visible = false;
            //    this.Grid_ETTestItem.Columns[11].Visible = false;
            //    this.Label26.Visible = false;
            //    this.TxtExpPer.Visible = false;
            //    this.Label27.Visible = false;
            //    this.TxtExpRes.Visible = false;
            //    this.Label28.Visible = false;
            //    this.TxtResInstruction.Visible = false;
            //}
            if (Role == "AppAu" && Session["UserRole"].ToString().Contains("实验申请审核"))
            {
                BtnNewExpApp.Visible = false;
                Grid_ExpApp.Columns[10].Visible = false;
                Grid_ExpApp.Columns[12].Visible = true;
                Grid_ExpApp.Columns[13].Visible = false;
                Grid_ExpApp.Columns[14].Visible = false;
                Grid_ExpApp.Columns[15].Visible = false;
                Grid_ExpApp.Columns[16].Visible = true;
                Grid_ExpApp.Columns[17].Visible = false;
                Grid_ExpApp.Columns[18].Visible = false;
                Grid_ExpApp.Columns[19].Visible = false;
                Grid_ETTestItem.Columns[7].Visible = false;
                Grid_ETTestItem.Columns[8].Visible = false;
                Grid_ETTestItem.Columns[9].Visible = false;
                Grid_ETTestItem.Columns[10].Visible = false;
                Grid_ETTestItem.Columns[11].Visible = false;
            }
            if (Role == "AppAck" && Session["UserRole"].ToString().Contains("实验申请接收"))
            {
                BtnNewExpApp.Visible = false;
                Grid_ExpApp.Columns[10].Visible = false;
                Grid_ExpApp.Columns[12].Visible = true;
                Grid_ExpApp.Columns[13].Visible = false;
                Grid_ExpApp.Columns[14].Visible = false;
                Grid_ExpApp.Columns[15].Visible = false;
                Grid_ExpApp.Columns[16].Visible = false;
                Grid_ExpApp.Columns[17].Visible = true;
                Grid_ExpApp.Columns[18].Visible = false;
                Grid_ExpApp.Columns[19].Visible = false;
                Grid_ETTestItem.Columns[7].Visible = false;
                Grid_ETTestItem.Columns[8].Visible = false;
                Grid_ETTestItem.Columns[9].Visible = false;
                Grid_ETTestItem.Columns[10].Visible = false;
                Grid_ETTestItem.Columns[11].Visible = false;
            }
            if (Role == "AppRes" && Session["UserRole"].ToString().Contains("实验结果录入"))
            {
                LblItemRes.Text = "Res";
                BtnNewExpApp.Visible = false;
                BtnSave.Visible = false;
                Grid_ExpApp.Columns[9].Visible = false;
                Grid_ExpApp.Columns[12].Visible = true;
                Grid_ExpApp.Columns[13].Visible = false;
                Grid_ExpApp.Columns[14].Visible = false;
                Grid_ExpApp.Columns[15].Visible = false;
                Grid_ExpApp.Columns[16].Visible = false;
                Grid_ExpApp.Columns[17].Visible = false;
                Grid_ExpApp.Columns[18].Visible = true;
                Grid_ExpApp.Columns[19].Visible = false;
                Grid_ETTestItem.Columns[11].Visible = false;
            }
            if (Role == "AppArl" && Session["UserRole"].ToString().Contains("实验结果审批"))
            {
                BtnNewExpApp.Visible = false;
                Grid_ExpApp.Columns[9].Visible = false;
                Grid_ExpApp.Columns[12].Visible = true;
                Grid_ExpApp.Columns[13].Visible = false;
                Grid_ExpApp.Columns[14].Visible = false;
                Grid_ExpApp.Columns[15].Visible = false;
                Grid_ExpApp.Columns[16].Visible = false;
                Grid_ExpApp.Columns[17].Visible = false;
                Grid_ExpApp.Columns[18].Visible = false;
                Grid_ExpApp.Columns[19].Visible = true;
                Grid_ETTestItem.Columns[10].Visible = false;
                Grid_ETTestItem.Columns[11].Visible = false;
            }
            if (Role == "AppView" && Session["UserRole"].ToString().Contains("实验进度追踪"))
            {
                BtnNewExpApp.Visible = false;
                Grid_ExpApp.Columns[13].Visible = false;
                Grid_ExpApp.Columns[14].Visible = false;
                Grid_ExpApp.Columns[15].Visible = false;
                Grid_ExpApp.Columns[16].Visible = false;
                Grid_ExpApp.Columns[17].Visible = false;
                Grid_ExpApp.Columns[18].Visible = false;
                Grid_ExpApp.Columns[19].Visible = false;
                Grid_ETTestItem.Columns[10].Visible = false;
                Grid_ETTestItem.Columns[11].Visible = false;
                Label29.Visible = true;
                TxtAuditor.Visible = true;
                Label30.Visible = true;
                TxtAuTime.Visible = true;
                Label31.Visible = true;
                TxtAuRes.Visible = true;
                Label32.Visible = true;
                TxtAuSugg1.Visible = true;
                Label33.Visible = true;
                TxtAckPer.Visible = true;
                Label34.Visible = true;
                TxtAckTime.Visible = true;
                Label35.Visible = true;
                TxtEstimateT1.Visible = true;
                Label36.Visible = true;
                TxtActFinishT.Visible = true;
                Label37.Visible = true;
                TxtApprover.Visible = true;
                Label38.Visible = true;
                TxtApprovalT1.Visible = true;
                Label40.Visible = true;
                TxtApprovalSugg1.Visible = true;
            }
            BindGridview1(Bindc);//数据绑定放在postback之外，否则gridview操作出错
            UpdatePanel_ExpApp.Update();
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('可能您没有权限操作和查看本页面，请退出选择其他账号登陆，或联系管理员！')", true);
            Response.Redirect("~/Default.aspx");
        }
    }
    #endregion

    #region 检索栏按钮
    //检索栏检索按钮
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        string Role = Request.QueryString["state"].ToString();
        string ETA_AppStatus = "";
        condition = "";
        if (Role == "Submit" && Session["UserRole"].ToString().Contains("实验申请提交"))
        {
            ETA_AppStatus = DdlAppStatus.SelectedItem.ToString() == "请选择" ? "" : DdlAppStatus.SelectedItem.ToString();
            if (ETA_AppStatus != "")
            {
                condition = condition + " AND ETA_AppStatus='" + ETA_AppStatus + "' ";
            }
        }
        if (Role == "AppAu" && Session["UserRole"].ToString().Contains("实验申请审核"))
        {
            if (DdlAppStatus.SelectedItem.ToString() == "请选择")
            {
                condition = condition + " AND ETA_AppStatus IN ('已提交') ";
            }
            else
                condition = condition + " AND ETA_AppStatus='" + DdlAppStatus.SelectedItem.ToString() + "' ";
        }
        if (Role == "AppAck" && Session["UserRole"].ToString().Contains("实验申请接收"))
        {
            if (DdlAppStatus.SelectedItem.ToString() == "请选择")
            {
                condition = condition + " AND ETA_AppStatus IN ('审核通过') ";
            }
            else
                condition = condition + " AND ETA_AppStatus='" + DdlAppStatus.SelectedItem.ToString() + "' ";
        }
        if (Role == "AppRes" && Session["UserRole"].ToString().Contains("实验结果录入"))
        {
            if (DdlAppStatus.SelectedItem.ToString() == "请选择")
            {
                condition = condition + " AND ETA_AppStatus IN ('实验中') ";
            }
            else
                condition = condition + " AND ETA_AppStatus='" + DdlAppStatus.SelectedItem.ToString() + "' ";
        }
        if (Role == "AppArl" && Session["UserRole"].ToString().Contains("实验结果审批"))
        {
            if (DdlAppStatus.SelectedItem.ToString() == "请选择")
            {
                condition = condition + " AND ETA_AppStatus IN ('已完成') ";
            }
            else
                condition = condition + " AND ETA_AppStatus='" + DdlAppStatus.SelectedItem.ToString() + "' ";
        }
        if (Role == "AppView" && Session["UserRole"].ToString().Contains("实验进度追踪"))
        {
            ETA_AppStatus = DdlAppStatus.SelectedItem.ToString() == "请选择" ? "" : DdlAppStatus.SelectedItem.ToString();
            if (ETA_AppStatus != "")
            {
                condition = condition + " AND ETA_AppStatus='" + ETA_AppStatus + "' ";
            }
        }
        string ETA_EmergDegree = DdlEmergDegree.SelectedItem.ToString() == "请选择" ? "" : DdlEmergDegree.SelectedItem.ToString();
        string ETA_ProIdentify = TxtProIdentify.Text;
        if (TxtAppTime1.Text == "" && TxtAppTime2.Text != "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请选择时间范围！')", true);
            return;
        }
        if (TxtAppTime1.Text != "" && TxtAppTime2.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请选择时间范围！')", true);
            return;
        }
        if (ETA_EmergDegree != "")
        {
            condition = condition + " AND ETA_EmergDegree='" + ETA_EmergDegree + "' ";
        }
        if (ETA_ProIdentify != "")
        {
            condition = condition + " AND ETA_ProIdentify LIKE '%'+ Ltrim(Rtrim('"+ ETA_ProIdentify + "'))+'%' ";
        }
        if (TxtAppTime1.Text != "" && TxtAppTime2.Text != "")
        {
            condition = condition + " AND ETA_AppTime BETWEEN '" + TxtAppTime1.Text + "' AND '" + TxtAppTime2.Text + "' ";
        }
        if (textExpAppNO.Text.ToString() != "")
        {
            condition = condition + " AND ETA_ExpAppNO LIKE '%'+ Ltrim(Rtrim('" + textExpAppNO.Text.ToString() + "'))+'%' ";
        }
        if (DropDownList1.SelectedValue.ToString()!="")
        {
            condition = condition + " AND EST_SampleType LIKE '%'+ Ltrim(Rtrim('" + DropDownList1.SelectedItem.ToString() + "'))+'%' ";
        }
        if (DropDownList2.SelectedValue.ToString() != "")
        {
            condition = condition + " AND ETA_AppDep LIKE '%'+ Ltrim(Rtrim('" + DropDownList2.SelectedItem.ToString() + "'))+'%' ";
        }
        Bindc = condition;
        BindGridview1(Bindc);
        UpdatePanel_ExpApp.Update();

        Panel_ItemResEdit.Visible = false;
        UpdatePanel_ItemResEdit.Update();
        Panel_ViewExp.Visible = false;
        UpdatePanel_ViewExp.Update();
        Panel_NewExpApp.Visible = false;
        UpdatePanel_NewExpApp.Update();
    }

    //检索栏新建申请按钮
    protected void BtnNew_Click(object sender, EventArgs e)
    {
        //expAppSubmitL.Delete_ExpTestApp_View();//先删除不要的主表；
        //BindGridview1(Bindc);//数据绑定放在postback之外，否则gridview操作出错
        //this.UpdatePanel_ExpApp.Update();
        //expAppSubmitL.Insert_ExpTestApp_View();//生成一个空主表；
        //ExpTestAppInfo ET = expAppSubmitL.Search_ExpItemsRes_ResID()[0];
        //idnew = ET.ETA_ExpID;//新增时取出空主表ID用于修改；
        //id = idnew;
        Panel_ViewExp.Visible = false;
        UpdatePanel_ViewExp.Update();
        Save = "0";//打开新建窗口，置保存为0
        ClearNew();
        LblExpApp.Text = "新建实验申请单";
        Lbl_ETA_ExpID.Text =Convert.ToString( Guid.NewGuid());
        //Guid.NewGuid();
        BtnClose.Visible = true;
        Panel_NewExpApp.Visible = true;
        TxtNewProIdentify.Enabled = true;
        TxtNewSamNum.Enabled = true;
        TxtNewUnits.Enabled = true;
        DdlAppDep.Enabled = true;
        DdlNewEmergDegree.Enabled = true;
        DdlSampleType.Enabled = true;
        Grid_ETTestItem.Enabled = true;
        TxtRemaks.Enabled = true;
        BtnSave.Visible = true;
        //this.BtnSubmit.Visible = true;//新增时提交按钮置为不可见，必须保存之后生成主表主键才允许提交
        Label10.Visible = false;
        TxtExpAppNO.Visible = false;
        DdlNewEmergDegree.SelectedValue = "0";
        Bind_DdlAppDep(DdlAppDep);
        Bind_DdlSampleType(DdlSampleType);
        BindGridview2(new Guid());
        TxtNewAppPer.Text = Session["UserName"].ToString().Trim(); //读取用户名
        LblState.Text = "New";
        UpdatePanel_NewExpApp.Update();
        Panel_ItemResEdit.Visible = false;
        Panel_SearchItem.Visible = false;
        UpdatePanel_ItemResEdit.Update();
        UpdatePanel_SearchItem.Update();
    }

    //检索栏重置按钮
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        TxtProIdentify.Text = "";
        TxtAppTime1.Text = "";
        TxtAppTime2.Text = "";
        textExpAppNO.Text = "";
        DropDownList1.Items.Insert(0, new ListItem("请选择", ""));
        DropDownList2.Items.Insert(0, new ListItem("请选择", ""));
        Bind_DdlAppDep(DropDownList2);
        Bind_DdlSampleType(DropDownList1);
        if (Request.QueryString["state"].ToString() == "AppAu")
        {
            DdlAppStatus.SelectedValue = "0";
            //condition = "AND ETA_AppStatus IN ('已提交', '审核通过', '审核驳回') ";
            condition = "AND ETA_AppStatus IN ('已提交') ";
        }
        else if (Request.QueryString["state"].ToString() == "Submit" || Request.QueryString["state"].ToString() == "AppView")
        {
            DdlAppStatus.SelectedValue = "0";
            condition = "";
        }
        else if (Request.QueryString["state"].ToString() == "AppAck")
        {
            DdlAppStatus.SelectedValue = "0";
            //condition = "AND ETA_AppStatus IN ('实验中', '审核通过') ";
            condition = "AND ETA_AppStatus IN ('审核通过') ";
        }
        else if (Request.QueryString["state"].ToString() == "AppRes")
        {
            DdlAppStatus.SelectedValue = "0";
            //condition = "AND ETA_AppStatus IN ('实验中', '已完成') ";
            condition = "AND ETA_AppStatus IN ('实验中', '审批驳回') ";
        }
        else if (Request.QueryString["state"].ToString() == "AppArl")
        {
            DdlAppStatus.SelectedValue = "0";
            //condition = "AND ETA_AppStatus IN ('已审批', '已完成') ";
            condition = "AND ETA_AppStatus IN ('已完成') ";
        }
        DdlEmergDegree.ClearSelection();
        Bindc = condition;
        BindGridview1(Bindc);
        UpdatePanel_ExpApp.Update();
        Panel_ItemResEdit.Visible = false;
        Panel_SearchItem.Visible = false;
        UpdatePanel_ItemResEdit.Update();
        UpdatePanel_SearchItem.Update();
        Panel_NewExpApp.Visible = false;
        UpdatePanel_NewExpApp.Update();
        Panel_ViewExp.Visible = false;
        UpdatePanel_ViewExp.Update();
        Panel_LastRes.Visible = false;
        UpdatePanel_LastRes.Update();
        Panel_AppAu.Visible = false;
        UpdatePanel_AppAu.Update();
        Panel_AppAck.Visible = false;
        UpdatePanel_AppAck.Update();
        Panel_AppArl.Visible = false;
        UpdatePanel_AppArl.Update();
    }

    #endregion

    #region GridView1操作
    //Gridview1翻页
    protected void Grid_ExpApp_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_ExpApp.BottomPagerRow;


            if (null != pagerRow)//判断底页不为空，不止一页
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox");   // refer to the TextBox with the NewPageIndex value
            }

            if (null != txtNewPageIndex && txtNewPageIndex.Text != "")//判断输入页数不为空
            {
                newPageIndex = int.Parse(txtNewPageIndex.Text) - 1; // get the NewPageIndex
            }
        }
        else
        {
            newPageIndex = e.NewPageIndex;
        }
        BindGridview1(Bindc);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_ExpApp.PageCount ? Grid_ExpApp.PageCount - 1 : newPageIndex;
        Grid_ExpApp.PageIndex = newPageIndex;
        Grid_ExpApp.DataBind();
    }

    //GridView1行命令
    protected void Grid_ExpApp_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //Guid idck = new Guid(e.CommandArgument.ToString());
        //ExpTestAppInfo ETck = expAppSubmitL.Search_ExpTestApp_ID(idck)[0];
        //if (ETck.ETA_AppStatus=="待提交")  //只有在“待提交”状态下的申请单才允许修改、删除
        //{
        Save = "1";
        if (e.CommandName == "Edit_ExpApp")
        {
            BtnClose.Visible = true;
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_ExpApp.SelectedIndex = row.RowIndex;
            //如果点击编辑，弹窗的子窗口：实验项目选择栏和实验项目表可见，则置为不可见
            if (Panel_SearchItem.Visible)
            {
                Panel_SearchItem.Visible = false;
                UpdatePanel_SearchItem.Update();
            }
            id = new Guid(e.CommandArgument.ToString());
            ExpTestAppInfo ET = expAppSubmitL.Search_ExpTestApp_ID(id)[0];
            LblExpApp.Text = "实验申请单" + ET.ETA_ExpAppNO + "维护";
            LblItemResEdit.Text = "实验申请单" + ET.ETA_ExpAppNO + "明细维护";
            //if (ET.ETA_AppStatus != "待提交" && ET.ETA_AppStatus != "审核驳回")
            if (ET.ETA_AppStatus != "待提交")//驳回的申请都需要重新提交
            {
                //goto Edit_ExpApp;
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('该状态下不能编辑！')", true);
                return;
            }
            ClearNew();
            Panel_NewExpApp.Visible = true;
            UpdatePanel_NewExpApp.Update();
            LblState.Text = "Edit";
            TxtNewProIdentify.Enabled = true;
            TxtNewSamNum.Enabled = true;
            TxtNewUnits.Enabled = true;
            DdlAppDep.Enabled = true;
            DdlNewEmergDegree.Enabled = true;
            DdlSampleType.Enabled = true;
            Grid_ETTestItem.Enabled = true;
            TxtRemaks.Enabled = true;
            BtnSave.Visible = true;
            //this.BtnSubmit.Visible = true;
            BtnClose.Visible = true;
            Panel_ViewExp.Visible = false;
            UpdatePanel_ViewExp.Update();
            Grid_ETTestItem.Columns[11].Visible = true;
            Grid_ETTestItem.Columns[10].Visible = true;
            Label10.Visible = false;
            TxtExpAppNO.Visible = false;
            //GridViewRow gvr = (GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent);
            //gvr.Cells[0].Text.ToString();
            TxtNewProIdentify.Text = ET.ETA_ProIdentify;
            TxtNewSamNum.Text = Convert.ToString(ET.ETA_SamNum);
            TxtNewUnits.Text = ET.ETA_Units;
            TxtNewAppPer.Text = ET.ETA_AppPer;
            Bind_DdlAppDep(DdlAppDep);
            if (ET.BDOS_Code == "")
                DdlAppDep.SelectedValue = "";
            else
                DdlAppDep.SelectedValue = ET.BDOS_Code;
            //判断紧急程度
            int a;
            if (ET.ETA_EmergDegree == "一般")
            {
                a = 1;
                DdlNewEmergDegree.SelectedValue = Convert.ToString(a);
            }
            else if (ET.ETA_EmergDegree == "紧急")
            {
                a = 2;
                DdlNewEmergDegree.SelectedValue = Convert.ToString(a);
            }
            //this.DdlSampleType.SelectedValue = ET.EST_SampleTypeID;
            Bind_DdlSampleType(DdlSampleType);
            if (ET.EST_SampleType == "")
                DdlSampleType.SelectedValue = "";
            else
                DdlSampleType.Items.FindByValue(ET.EST_SampleTypeID.ToString()).Selected = true;//绑定Value值为主键的赋值方法
            TxtExpAppNO.Text = ET.ETA_ExpAppNO;
            BindGridview2(id);
            TxtRemaks.Text = ET.ETA_Remaks;
            UpdatePanel_NewExpApp.Update();
            Panel_ItemResEdit.Visible = false;
            Panel_SearchItem.Visible = false;
            UpdatePanel_ItemResEdit.Update();
            UpdatePanel_SearchItem.Update();
        }
    //Edit_ExpApp: ;

    if (e.CommandName == "Select_Item")
    {
        ((BoundField)Grid_ETTestItem.Columns[6]).ReadOnly = false;//注意类型转换，你所操作的列的类型是BoundField
        ((BoundField)Grid_ETTestItem.Columns[7]).ReadOnly = true;
        //((BoundField)Grid_ETTestItem.Columns[8]).ReadOnly = true;
        ((BoundField)Grid_ETTestItem.Columns[9]).ReadOnly = true;
        BtnItemResSubmit.Visible =true ;
        Btn_ItemResSubmit1.Visible = false;
        BtnItemResCancel.Visible = true;
        GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
        Grid_ExpApp.SelectedIndex = row.RowIndex;
        id = new Guid(e.CommandArgument.ToString());
        LblSelect_ID.Text = Convert.ToString(id);
        ExpTestAppInfo ET = expAppSubmitL.Search_ExpTestApp_ID(id)[0];
        //if (ET.ETA_AppStatus != "待提交" && ET.ETA_AppStatus != "审核驳回")
        if (ET.ETA_AppStatus != "待提交")
        {
            //goto Select_Item;
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('该状态下不能选择项目！')", true);
            return;
        }
        LblItemResEdit.Text = "实验申请单" + ET.ETA_ExpAppNO + "测试项目选择";
        //this.Labeldep.Text = this.Grid_ExpApp.Rows[row.RowIndex].Cells[19].ToString().Trim();
        Labeldep.Text = Grid_ExpApp.Rows[row.RowIndex].Cells[7].Text.ToString().Trim();
        BindGridview2(id);
        ClearSearch();
        BindGridview3("", "", "");
        Panel_SearchItem.Visible = true;
        UpdatePanel_SearchItem.Update();
        Panel_ItemResEdit.Visible = true;
        UpdatePanel_ItemResEdit.Update();
        Panel_NewExpApp.Visible = false;
        UpdatePanel_NewExpApp.Update();
    }
//Select_Item: ;
        if (e.CommandName == "Delete_ExpApp")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_ExpApp.SelectedIndex = row.RowIndex;
            Guid guid = new Guid(e.CommandArgument.ToString());
            //int b=0;
            //string a=Convert.ToInt32(b.ToString();
            ExpTestAppInfo ET1 = expAppSubmitL.Search_ExpTestApp_ID(guid)[0];
            if (ET1.ETA_AppStatus != "待提交" && ET1.ETA_AppStatus != "审核驳回" )
            {
                //goto Delete_ExpApp;
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('该状态下不能删除！')", true);
                return;
            }
            expAppSubmitL.Delete_ExpTestApp(guid);
            //condition = "AND ETA_AppStatus='待提交'";
            //Bindc = condition;
            BindGridview1("");
            UpdatePanel_ExpApp.Update();
            Panel_ItemResEdit.Visible = false;
            Panel_SearchItem.Visible = false;
            UpdatePanel_ItemResEdit.Update();
            UpdatePanel_SearchItem.Update();
            Panel_NewExpApp.Visible = false;
            UpdatePanel_NewExpApp.Update();
        }
    //Delete_ExpApp: ;
        if (e.CommandName == "View_ExpApp")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_ExpApp.SelectedIndex = row.RowIndex;
            //if (Request.QueryString["state"].ToString() == "AppView")
            //{
                ClearNew();
                BtnItemResSubmit.Visible = false;
                Btn_ItemResSubmit1.Visible = false;
                BtnItemResCancel.Visible = false;
                LblState.Text = "View";//此处设定LblState的第三个值：View，仅用于查看而不可修改
                Label10.Visible = true;
                TxtNewProIdentify.Enabled = false;
                TxtNewSamNum.Enabled = false;
                TxtNewUnits.Enabled = false;
                DdlAppDep.Enabled = false;
                DdlNewEmergDegree.Enabled = false;
                DdlSampleType.Enabled = false;
                Grid_ETTestItem.Columns[7].Visible = true;
                Grid_ETTestItem.Columns[8].Visible = true;
                Grid_ETTestItem.Columns[9].Visible = true;
                Grid_ETTestItem.Columns[11].Visible = false;
                Grid_ETTestItem.Columns[10].Visible = false;
                TxtRemaks.Enabled = false;
                TxtExpPer.Enabled = false;
                TxtExpRes.Enabled = false;
                TxtActFinishT.Enabled = false;
                TxtResInstruction.Enabled = false;
                TxtExpPer.Enabled = false;
                TxtExpRes.Enabled = false;
                TxtResInstruction.Enabled = false;
                BtnSave.Visible = false;
                //this.BtnSubmit.Visible = false;
                TxtExpAppNO.Visible = true;
                TxtExpAppNO.Enabled = false;
                //获取所点击的行,gvr.Cells[0].Text.ToString();
                GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
                id = new Guid(e.CommandArgument.ToString());
                BindGridview2(id);
                ExpTestAppInfo ET = expAppSubmitL.Search_ExpTestApp_ID(id)[0];
                LblExpApp.Text = "实验申请单" + ET.ETA_ExpAppNO + "结果信息";
                LblItemResEdit.Text = "实验申请单" + ET.ETA_ExpAppNO + "检验明细";
                Lbl_ViewExp.Text = "实验申请单" + ET.ETA_ExpAppNO + "流程信息";
                TxtNewProIdentify.Text = ET.ETA_ProIdentify;
                TxtNewSamNum.Text = Convert.ToString(ET.ETA_SamNum);
                TxtNewUnits.Text = ET.ETA_Units;
                TxtNewAppPer.Text = ET.ETA_AppPer;
                Bind_DdlAppDep(DdlAppDep);
                if (ET.BDOS_Code == "")
                    DdlAppDep.SelectedValue = "";
                else
                DdlAppDep.SelectedValue = ET.BDOS_Code;
                //判断紧急程度
                int a;
                if (ET.ETA_EmergDegree == "一般")
                {
                    a = 1;
                    DdlNewEmergDegree.SelectedValue = Convert.ToString(a);
                }
                else if (ET.ETA_EmergDegree == "紧急")
                {
                    a = 2;
                    DdlNewEmergDegree.SelectedValue = Convert.ToString(a);
                }
                //this.DdlSampleType.SelectedValue = ET.EST_SampleTypeID;
                Bind_DdlSampleType(DdlSampleType);
                if (ET.EST_SampleType == "")
                    DdlSampleType.SelectedValue = "";
                else
                DdlSampleType.Items.FindByValue(ET.EST_SampleTypeID.ToString()).Selected = true;//绑定Value值为主键的赋值方法
                TxtExpAppNO.Text = ET.ETA_ExpAppNO;
                BindGridview2(id);
                TxtRemaks.Text = ET.ETA_Remaks;
                TxtAuditor.Text = ET.ETA_Auditor;
                if (ET.ETA_Auditor == "")
                {
                    TxtAuTime.Text = "";
                }
                else
                {
                    TxtAuTime.Text = Convert.ToString(ET.ETA_AuTime);
                }
                TxtAuRes.Text = ET.ETA_AuRes;
                TxtAuSugg1.Text = ET.ETA_AuSugg;
                TxtAckPer.Text = ET.ETA_AckPer;
                if (ET.ETA_AckPer == "")
                {
                    TxtAckTime.Text = "";
                    TxtEstimateT1.Text = "";
                }
                else
                {
                    TxtAckTime.Text = Convert.ToString(ET.ETA_AckTime);
                    TxtEstimateT1.Text = Convert.ToString(ET.ETA_EstimateT);
                }
                TxtExpPer.Text = ET.ETA_ExpPer;
                TxtExpRes.Text = ET.ETA_ExpRes;
                if (ET.ETA_ExpPer == "")
                {
                    TxtActFinishT.Text = "";
                }
                else
                {
                    TxtActFinishT.Text = Convert.ToString(ET.ETA_ActFinishT);
                }
                TxtResInstruction.Text = ET.ETA_ResInstruction;
                TxtApprover.Text = ET.ETA_Approver;
                if (ET.ETA_Approver == "")
                {
                    TxtApprovalT1.Text = "";
                }
                else
                {
                    TxtApprovalT1.Text = Convert.ToString(ET.ETA_ApprovalT);
                }
                TxtApprovalSugg1.Text=ET.ETA_ApprovalSugg;
                TxtApprovalRes1.Text = ET.ETA_ApprovalRes;
                BtnSave.Visible = false;
                //BtnSubmit.Visible = false;
                BtnClose.Visible = false;
                Panel_NewExpApp.Visible = true;
                UpdatePanel_NewExpApp.Update();
                Panel_ViewExp.Visible = true;
                UpdatePanel_ViewExp.Update();
                Panel_ItemResEdit.Visible = true;
                UpdatePanel_ItemResEdit.Update();
                UpdatePanel_NewExpApp.Update();
                //Panel_ItemResEdit.Visible = false;
                Panel_SearchItem.Visible = false;
                //this.UpdatePanel_ItemResEdit.Update();
                UpdatePanel_SearchItem.Update();
                Panel_AppAu.Visible = false;
                UpdatePanel_AppAu.Update();
                Panel_AppAck.Visible = false;
                UpdatePanel_AppAck.Update();
                Panel_LastRes.Visible = false;
                UpdatePanel_LastRes.Update();
                Panel_AppArl.Visible = false;
                UpdatePanel_AppArl.Update();
            //}
            //else
            //{
            //    try
            //    {
            //        ClearNew();
            //        this.Panel_NewExpApp.Visible = true;
            //        this.UpdatePanel_NewExpApp.Update();
            //        LblState.Text = "View";//此处设定LblState的第三个值：View，仅用于查看而不可修改
            //        this.TxtNewProIdentify.Enabled = false;
            //        this.TxtNewSamNum.Enabled = false;
            //        this.TxtNewUnits.Enabled = false;
            //        this.DdlAppDep.Enabled = false;
            //        this.DdlNewEmergDegree.Enabled = false;
            //        this.DdlSampleType.Enabled = false;
            //        this.BtnSelectItem.Visible = false;
            //        this.Grid_ETTestItem.Columns[11].Visible = false;
            //        this.Grid_ETTestItem.Columns[10].Visible = false;
            //        this.TxtRemaks.Enabled = false;
            //        TxtExpPer.Enabled = false;
            //        TxtExpRes.Enabled = false;
            //        TxtActFinishT.Enabled = false;
            //        TxtResInstruction.Enabled = false;
            //        this.BtnSave.Visible = false;
            //        this.BtnSubmit.Visible = false;
            //        this.Label10.Visible = true;
            //        this.TxtExpAppNO.Visible = true;
            //        this.TxtExpAppNO.Enabled = false;
            //        this.LblLuruRes_ID.Visible = true;
            //        this.BtnSelectItem.Visible = false;
            //        //获取所点击的行,gvr.Cells[0].Text.ToString();
            //        GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            //        id = new Guid(e.CommandArgument.ToString());
            //        ExpTestAppInfo ET = expAppSubmitL.Search_ExpTestApp_ID(id)[0];
            //        this.LblExpApp.Text = "实验申请单" + ET.ETA_ExpAppNO + "明细";
            //        this.TxtNewProIdentify.Text = ET.ETA_ProIdentify;
            //        this.TxtNewSamNum.Text = Convert.ToString(ET.ETA_SamNum);
            //        this.TxtNewUnits.Text = ET.ETA_Units;
            //        this.TxtNewAppPer.Text = ET.ETA_AppPer;
            //        Bind_DdlAppDep(DdlAppDep);
            //        this.DdlAppDep.SelectedValue = ET.BDOS_Code;
            //        //判断紧急程度
            //        int a;
            //        if (ET.ETA_EmergDegree == "一般")
            //        {
            //            a = 1;
            //            this.DdlNewEmergDegree.SelectedValue = Convert.ToString(a);
            //        }
            //        else if (ET.ETA_EmergDegree == "紧急")
            //        {
            //            a = 2;
            //            this.DdlNewEmergDegree.SelectedValue = Convert.ToString(a);
            //        }
            //        //this.DdlSampleType.SelectedValue = ET.EST_SampleTypeID;
            //        Bind_DdlSampleType(DdlSampleType);
            //        DdlSampleType.Items.FindByValue(ET.EST_SampleTypeID.ToString()).Selected = true; ;//绑定Value值为主键的赋值方法
            //        this.TxtExpAppNO.Text = ET.ETA_ExpAppNO;
            //        BindGridview2(id);
            //        this.TxtRemaks.Text = ET.ETA_Remaks;
            //        if (Request.QueryString["state"].ToString() == "AppRes" || Request.QueryString["state"].ToString() == "AppArl")
            //        {
            //            TxtExpPer.Text = ET.ETA_ExpPer;
            //            TxtExpRes.Text = ET.ETA_ExpRes;
            //            TxtActFinishT.Text = Convert.ToString(ET.ETA_ActFinishT);
            //            TxtResInstruction.Text = ET.ETA_ResInstruction;
            //        }
            //        this.UpdatePanel_NewExpApp.Update();
            //    }
            //    catch (Exception ex)
            //    {

            //        throw ex;
            //    }
            //}

        }
        //申请单审核
        if (e.CommandName == "AppAu")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_ExpApp.SelectedIndex = row.RowIndex;
            Guid guid = new Guid(e.CommandArgument.ToString());
            ExpTestAppInfo ET = expAppSubmitL.Search_ExpTestApp_ID(guid)[0];
            LblAppAu.Text = "实验申请单" + ET.ETA_ExpAppNO + "审核";
            if (ET.ETA_AppStatus != "已提交")
            {
                //goto AppAu;
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('该状态下不能审核！')", true);
                return;
            }
            //string tt= Grid_ExpApp.Rows[row.RowIndex].Cells[7].Text.ToString().Trim();
            //if (Session["Organization"] != null && Session["Organization"] .ToString()!= "" && Session["Department"].ToString() != tt)
            //{
            //    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('您没有该部门的审核权限！')", true);
            //    return;
            //}
            Labelp1.Text = ET.ETA_AppPer;
            id = new Guid(e.CommandArgument.ToString());
            TxtAuSugg.Text = "";
            Panel_AppAu.Visible = true;
            UpdatePanel_AppAu.Update();

            Panel_ItemResEdit.Visible = false;
            UpdatePanel_ItemResEdit.Update();
            Panel_ViewExp.Visible = false;
            UpdatePanel_ViewExp.Update();
            Panel_NewExpApp.Visible = false;
            UpdatePanel_NewExpApp.Update();
        }
    //AppAu: ;
        //申请单接收
        if (e.CommandName == "AppAck")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_ExpApp.SelectedIndex = row.RowIndex;
            Guid guid = new Guid(e.CommandArgument.ToString());
            ExpTestAppInfo ET = expAppSubmitL.Search_ExpTestApp_ID(guid)[0];
            LblAppAck.Text = "实验申请单" + ET.ETA_ExpAppNO + "接收";
            if (ET.ETA_AppStatus != "审核通过")
            {
                //goto AppAck;
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('该状态下不能接收！')", true);
                return;
            }
            id = new Guid(e.CommandArgument.ToString());
            TxtEstimateT.Text = "";
            Panel_AppAck.Visible = true;
            UpdatePanel_AppAck.Update();

            Panel_ItemResEdit.Visible = false;
            UpdatePanel_ItemResEdit.Update();
            Panel_ViewExp.Visible = false;
            UpdatePanel_ViewExp.Update();
            Panel_NewExpApp.Visible = false;
            UpdatePanel_NewExpApp.Update();
        }
    //AppAck: ;
        //申请单结果录入
        if (e.CommandName == "AppRes")
        {
            ((BoundField)Grid_ETTestItem.Columns[6]).ReadOnly =true ;//注意类型转换，你所操作的列的类型是BoundField
            ((BoundField)Grid_ETTestItem.Columns[7]).ReadOnly = false;
            //((BoundField)Grid_ETTestItem.Columns[8]).ReadOnly = false;
            ((BoundField)Grid_ETTestItem.Columns[9]).ReadOnly = false;
            BtnItemResSubmit.Visible = false;
            Btn_ItemResSubmit1.Visible = true;
            BtnItemResCancel.Visible = true;
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_ExpApp.SelectedIndex = row.RowIndex;
            Guid id = new Guid(e.CommandArgument.ToString());
            LblLuruRes_ID.Text = Convert.ToString(id);
            ExpTestAppInfo ET1 = expAppSubmitL.Search_ExpTestApp_ID(id)[0];
            LblItemResEdit.Text = "实验申请单" + ET1.ETA_ExpAppNO + "结果录入";
            if (ET1.ETA_AppStatus != "实验中" && ET1.ETA_AppStatus != "审批驳回")
            {
                //goto AppRes;
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('该状态下不能录入！')", true);
                return;
            }
            BindGridview2(id);
            //Label19.Visible = false;
            //TxtItemAmount.Visible = false;
            //Label21.Visible = false;
            //TxtItemAccept.Visible = false;
            //Label22.Visible = false;
            //TxtItemRes.Visible = false;
            //Label23.Visible = false;
            //Label44.Visible = false;
            //TxtItemRemaks1.Visible = false;
            Grid_ETTestItem.Columns[10].Visible = true;
            Panel_ItemResEdit.Visible = true;
            BtnItemResCancel.Visible = true;
            UpdatePanel_ItemResEdit.Update();

            Panel_ViewExp.Visible = false;
            UpdatePanel_ViewExp.Update();
            Panel_NewExpApp.Visible = false;
            UpdatePanel_NewExpApp.Update();
        }
    //AppRes:  ;
        //申请结果审批
        if (e.CommandName == "AppArl")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_ExpApp.SelectedIndex = row.RowIndex;
            Guid guid = new Guid(e.CommandArgument.ToString());
            ExpTestAppInfo ET1 = expAppSubmitL.Search_ExpTestApp_ID(guid)[0];
            LblAppArl.Text = "实验申请单" + ET1.ETA_ExpAppNO + "结果审批";
            if (ET1.ETA_AppStatus != "已完成")
            {
                //goto AppArl;
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('该状态下不能审批！')", true);
                return;
            }
            Labelp2.Text = ET1.ETA_AppPer;
            id = new Guid(e.CommandArgument.ToString());
            TxtApprovalSugg.Text = "";
            Panel_AppArl.Visible = true;
            UpdatePanel_AppArl.Update();

            Panel_ItemResEdit.Visible = false;
            UpdatePanel_ItemResEdit.Update();
            Panel_ViewExp.Visible = false;
            UpdatePanel_ViewExp.Update();
            Panel_NewExpApp.Visible = false;
            UpdatePanel_NewExpApp.Update();
        }
    //AppArl: ;
    }

    //GridView1悬浮框显示
    protected void Grid_ExpApp_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Grid_ExpApp.Rows.Count; i++)
        {
            for (int j = 0; j < Grid_ExpApp.Rows[i].Cells.Count; j++)
            {
                Grid_ExpApp.Rows[i].Cells[j].ToolTip = Grid_ExpApp.Rows[i].Cells[j].Text;
                if (Grid_ExpApp.Rows[i].Cells[j].Text.Length > 15)
                {
                    Grid_ExpApp.Rows[i].Cells[j].Text = Grid_ExpApp.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }
            }
        }
    }
    #endregion

    #region 实验申请维护窗口操作
    //实验申请维护窗口提交按钮
    //protected void BtnSubmit_Click(object sender, EventArgs e)
    //{
    //    if (this.LblItemRes.Text == "Amount")
    //    {
    //        ExpTestAppInfo ET = new ExpTestAppInfo();
            
            
    //        if (this.DdlSampleType.SelectedValue == "")
    //        {
    //            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
    //            return;
    //        }
    //        else
    //            ET.EST_SampleType = DdlSampleType.SelectedItem.ToString();

    //        //DateTime Date=System.DateTime.Now; //获取系统时间并将日期部分提取出来存入字符串变量
    //        //string c= Date.ToShortDateString();//如何生成申请单编号？
    //        //if (this.TxtExpAppNO.Text == "")
    //        //{
    //        //    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('请输入申请单编号！')", true);
    //        //    return;
    //        //}
    //        //else if (TextLength(this.TxtExpAppNO.Text) != 11)
    //        //{
    //        //    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('申请单编号格式为11位！')", true);
    //        //    return;
    //        //}
    //        //else
    //            ET.ETA_ExpAppNO = "";

    //        if (this.TxtNewProIdentify.Text == "")
    //        {
    //            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
    //            return;
    //        }
    //        else if (TextLength(this.TxtNewProIdentify.Text) > 40)
    //        {
    //            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('产品标识不要超过20汉字或40字符！')", true);
    //            return;
    //        }
    //        else
    //            ET.ETA_ProIdentify = this.TxtNewProIdentify.Text;
    //        int check = 1;//定义一个int类型变量用来判断this.TxtNewSamNum.Text格式是否正确
    //        if (this.TxtNewSamNum.Text == "")
    //        {
    //            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
    //            return;
    //        }
    //        else if (!int.TryParse(this.TxtNewSamNum.Text, out check))
    //        {
    //            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('样品总数请输入数字格式！')", true);
    //            return;
    //        }
    //        else
    //            ET.ETA_SamNum = Convert.ToInt32(this.TxtNewSamNum.Text);
    //        if (this.TxtNewUnits.Text == "")
    //        {
    //            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
    //            return;
    //        }
    //        else
    //            ET.ETA_Units = this.TxtNewUnits.Text;
    //        ET.ETA_AppPer = this.TxtNewAppPer.Text;
    //        if (this.DdlAppDep.SelectedValue == "")
    //        {
    //            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
    //            return;
    //        }
    //        else
    //            ET.ETA_AppDep = DdlAppDep.SelectedItem.ToString();
    //        ET.ETA_AppStatus = "待提交";
    //        if (this.DdlNewEmergDegree.SelectedValue == "0")
    //        {
    //            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
    //            return;
    //        }
    //        else
    //            ET.ETA_EmergDegree = DdlNewEmergDegree.SelectedItem.ToString();
    //        if (TextLength(this.TxtRemaks.Text) > 400)
    //        {
    //            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('备注不要超过200汉字或400字符！')", true);
    //            return;
    //        }
    //        else
    //            ET.ETA_Remaks = this.TxtRemaks.Text;
    //        try
    //        {
    //            if (LblState.Text == "New")
    //            {
    //                ET.ETA_ExpID = new Guid(Lbl_ETA_ExpID.Text.ToString());
    //                expAppSubmitL.Insert_ExpTestApp(ET);
    //            }
    //            else
    //            {
    //                ET.ETA_ExpID = id;
    //                expAppSubmitL.Update_ExpTestAppApp(ET);
    //            }
    //        }
    //        catch (Exception exc)
    //        {
    //            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('提交失败！" + exc + "')", true);
    //            return;
    //        }
    //        ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('提交成功，请选择测试项目以完成申请单！')", true);
    //        ClearNew();
    //        condition = "AND ETA_AppStatus='待提交'";
    //        Bindc = condition;
    //        BindGridview1(Bindc);
    //        this.Panel_NewExpApp.Visible = false;
    //        this.UpdatePanel_ExpApp.Update();
    //        this.UpdatePanel_NewExpApp.Update();
    //        if (this.Panel_SearchItem.Visible)
    //        {
    //            this.Panel_SearchItem.Visible = false;
    //            this.UpdatePanel_SearchItem.Update();
    //        }
    //    }
    //    if (this.LblItemRes.Text == "Res")
    //    {
    //        ExpTestAppInfo ET = new ExpTestAppInfo();
    //        ET.ETA_ExpID = id;
    //        if (this.TxtExpPer.Text == "")
    //        {
    //            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
    //            return;
    //        }
    //        else
    //            ET.ETA_ExpPer = this.TxtExpPer.Text;
    //        if (this.TxtExpRes.Text == "")
    //        {
    //            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
    //            return;
    //        }
    //        else
    //            ET.ETA_ExpRes = this.TxtExpRes.Text;
    //        if (this.TxtResInstruction.Text != "")
    //        {
    //            ET.ETA_ResInstruction = this.TxtResInstruction.Text;
    //        }
    //        else
    //            ET.ETA_ResInstruction = "";
    //        ET.ETA_AppStatus = "已完成";
    //        try
    //        {
    //            expAppSubmitL.Update_ExpTestAppRes(ET);
    //        }
    //        catch (Exception exc)
    //        {
    //            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('提交失败！" + exc + "')", true);
    //            return;
    //        }
    //        ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('提交成功！')", true);
    //        ClearNew();
    //        condition = "AND ETA_AppStatus='已完成'";
    //        Bindc = condition;
    //        BindGridview1(Bindc);
    //        this.Panel_NewExpApp.Visible = false;
    //        this.UpdatePanel_ExpApp.Update();
    //        this.UpdatePanel_NewExpApp.Update();
    //        if (this.Panel_SearchItem.Visible)
    //        {
    //            this.Panel_SearchItem.Visible = false;
    //            this.UpdatePanel_SearchItem.Update();
    //        }
    //    }

    //    Panel_ItemResEdit.Visible = false;
    //    UpdatePanel_ItemResEdit.Update();
    //}

    //实验申请维护窗口保存按钮
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        if (TxtNewProIdentify.Text == "" || TxtNewSamNum.Text == "" || TxtNewUnits.Text == "" || DdlAppDep.Text == "" || DdlNewEmergDegree.SelectedValue.ToString() == "0"  || DdlSampleType.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (LblState.Text == "New")
        {
            expTestAppInfo.ETA_ExpID =new Guid( Lbl_ETA_ExpID.Text.ToString());
            if (DdlSampleType.SelectedValue == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('申请部门与样品类型为必填项！')", true);
                //return;
                expTestAppInfo.EST_SampleType = "";
            }
            else
                expTestAppInfo.EST_SampleType = DdlSampleType.SelectedItem.ToString();
            expTestAppInfo.ETA_ExpAppNO = "";

            if (TextLength(TxtNewProIdentify.Text) > 40)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('产品标识不要超过20汉字或40字符！')", true);
                return;
            }
            else if (TxtNewProIdentify.Text != "")
            {
                expTestAppInfo.ETA_ProIdentify = TxtNewProIdentify.Text;
            }
            else
            {
                expTestAppInfo.ETA_ProIdentify = "";
            }
            if (TxtNewSamNum.Text != "")
            {
                int check = 1;
                if (!int.TryParse(TxtNewSamNum.Text, out check))
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('样品总数请输入数字格式！')", true);
                    return;
                }
                expTestAppInfo.ETA_SamNum = Convert.ToInt32(TxtNewSamNum.Text);
            }
            else
            {
                expTestAppInfo.ETA_SamNum = 0;
            }

            if (TxtNewUnits.Text != "")
            {
                expTestAppInfo.ETA_Units = TxtNewUnits.Text;
            }
            else
            {
                expTestAppInfo.ETA_Units = "";
            }
            expTestAppInfo.ETA_AppPer = TxtNewAppPer.Text;
            if (DdlAppDep.SelectedValue == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('申请部门与样品类型为必填项！')", true);
                //return;
                expTestAppInfo.ETA_AppDep = "";
            }
            else
                expTestAppInfo.ETA_AppDep = DdlAppDep.SelectedItem.ToString();
            expTestAppInfo.ETA_AppStatus = "待提交";
            if (DdlNewEmergDegree.SelectedValue != "0")
            {
                expTestAppInfo.ETA_EmergDegree = DdlNewEmergDegree.SelectedItem.ToString();
            }
            else
            {
                expTestAppInfo.ETA_EmergDegree = "";
            }
            if (TextLength(TxtRemaks.Text) > 400)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('备注不要超过200汉字或400字符！')", true);
                return;
            }
            else
                expTestAppInfo.ETA_Remaks = TxtRemaks.Text;
            try
            {
                expAppSubmitL.Insert_ExpTestApp(expTestAppInfo);
            }
            catch (Exception exc)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('新增失败！" + exc + "')", true);
            }
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('新增成功，请选择实验项目！')", true);
            ClearNew();
            //condition = "AND ETA_AppStatus='待提交'";
            //Bindc = condition;
            BindGridview1("");
            UpdatePanel_ExpApp.Update();
            Save = "1";
            Panel_NewExpApp.Visible = false;
            UpdatePanel_NewExpApp.Update();
            if (Panel_SearchItem.Visible)
            {
                Panel_SearchItem.Visible = false;
                UpdatePanel_SearchItem.Update();
            }
        }
        if (LblState.Text == "Edit")
        {
            ExpTestAppInfo ET = new ExpTestAppInfo();
            ET.ETA_ExpID = id;
            if (DdlSampleType.SelectedValue == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('请至少指定样品类型！')", true);
                //return;
                ET.EST_SampleType = "";
            }
            else
                ET.EST_SampleType = DdlSampleType.SelectedItem.ToString();

            //保存时不生成申请单编号，按申请单实际提交顺序来决定编号顺序，即先提交申请的编号靠前
            ET.ETA_ExpAppNO = "";

            if (TextLength(TxtNewProIdentify.Text) > 40)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('产品标识不要超过20汉字或40字符！')", true);
                return;
            }
            else if (TxtNewProIdentify.Text != "")
            {
                ET.ETA_ProIdentify = TxtNewProIdentify.Text;
            }
            else
            {
                ET.ETA_ProIdentify = "";
            }
            if (TxtNewSamNum.Text != "")
            {
                int check = 1;
                if (!int.TryParse(TxtNewSamNum.Text, out check))
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('样品总数请输入数字格式！')", true);
                    return;
                }
                ET.ETA_SamNum = Convert.ToInt32(TxtNewSamNum.Text);
            }
            else
            {
                ET.ETA_SamNum = 0;
            }

            if (TxtNewUnits.Text != "")
            {
                ET.ETA_Units = TxtNewUnits.Text;
            }
            else
            {
                ET.ETA_Units = "";
            }

            ET.ETA_AppPer = TxtNewAppPer.Text;
            ET.ETA_AppTime = DateTime.Now;
            if (DdlAppDep.SelectedValue == "")
            {
                //ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('请至少指定申请部门！')", true);
                //return;
                ET.ETA_AppDep = "";
            }
            else
                ET.ETA_AppDep = DdlAppDep.SelectedItem.ToString();

            ET.ETA_AppStatus = "待提交";
            if (DdlNewEmergDegree.SelectedValue != "0")
            {
                ET.ETA_EmergDegree = DdlNewEmergDegree.SelectedItem.ToString();
            }
            else
            {
                ET.ETA_EmergDegree = "";
            }
            if (TextLength(TxtRemaks.Text) > 400)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('备注不要超过200汉字或400字符！')", true);
                return;
            }
            else
                ET.ETA_Remaks = TxtRemaks.Text;
            ET.ETA_Auditor = "";
            ET.ETA_AuTime = DateTime.Now;
            ET.ETA_AuSugg = "";
            ET.ETA_AuRes = "";
            ET.ETA_AckPer = "";
            ET.ETA_AckTime = DateTime.Now;
            ET.ETA_EstimateT = DateTime.Now;
            ET.ETA_ExpPer = "";
            ET.ETA_ActFinishT = DateTime.Now;
            ET.ETA_ExpRes = "";
            ET.ETA_ResInstruction = "";
            ET.ETA_Approver = "";
            ET.ETA_ApprovalT = DateTime.Now;
            ET.ETA_ApprovalSugg = "";
            ET.ETA_ApprovalRes = "";
            try
            {
                expAppSubmitL.Update_ExpTestApp(ET);
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('编辑失败！" + ex + "')", true);
                return;
            }
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('编辑成功！')", true);
            BindGridview1("");
            Panel_NewExpApp.Visible = false;
            UpdatePanel_NewExpApp.Update();
            UpdatePanel_ExpApp.Update();
            if (Panel_SearchItem.Visible)
            {
                Panel_SearchItem.Visible = false;
                UpdatePanel_SearchItem.Update();
            }
        }
        Panel_ItemResEdit.Visible = false;
        UpdatePanel_ItemResEdit.Update();
    }

    //实验申请维护窗口关闭按钮
    protected void BtnClose_Click(object sender, EventArgs e)
    {
        if (Panel_NewExpApp.Visible)
        {
            Panel_NewExpApp.Visible = false;
            UpdatePanel_NewExpApp.Update();
        }
        if (Panel_SearchItem.Visible)
        {
            Panel_SearchItem.Visible = false;
            UpdatePanel_SearchItem.Update();
        }
        if (Request.QueryString["state"].ToString() == "Submit")
        {
            Bindc = "";
            BindGridview1(Bindc);
            UpdatePanel_ExpApp.Update();
        }
        else if(Request.QueryString["state"].ToString() == "AppAu")
        {
            Bindc = "AND ETA_AppStatus='已提交'";
            BindGridview1(Bindc);
            UpdatePanel_ExpApp.Update();
        }
    }

    //实验申请查看窗口关闭按钮
    protected void Btn_CloseView_Click(object sender, EventArgs e)
    {
        Panel_ItemResEdit.Visible = false;
        UpdatePanel_ItemResEdit.Update();
        BtnSave.Visible = true;
        //BtnSubmit.Visible = true;
        BtnClose.Visible = true;
        Panel_ViewExp.Visible = false;
        UpdatePanel_ViewExp.Update();
        if (Panel_NewExpApp.Visible)
        {
            Panel_NewExpApp.Visible = false;
            UpdatePanel_NewExpApp.Update();
        }
        if (Panel_SearchItem.Visible)
        {
            Panel_SearchItem.Visible = false;
            UpdatePanel_SearchItem.Update();
        }
        if (Request.QueryString["state"].ToString() == "Submit")
        {
            Bindc = "";
            BindGridview1(Bindc);
            UpdatePanel_ExpApp.Update();
        }
        else if (Request.QueryString["state"].ToString() == "AppAu")
        {
            Bindc = "AND ETA_AppStatus='已提交'";
            BindGridview1(Bindc);
            UpdatePanel_ExpApp.Update();
        }
    }

    
    #endregion

    #region GridView2操作

    //编辑
    protected void Grid_ETTestItem_Editing(object sender, GridViewEditEventArgs e)
    {
        if (LblItemRes.Text == "Amount")
            id =new Guid( LblSelect_ID.Text);
        else if (LblItemRes.Text == "Res")
            id = new Guid(LblLuruRes_ID.Text);
        Grid_ETTestItem.EditIndex = e.NewEditIndex;
        //string a = Grid_ETTestItem.Rows[e.NewEditIndex].FindControl("DropDownList5").ToString();
        //string a = Grid_ETTestItem.Rows[e.NewEditIndex].Cells[8].Text.ToString();
        //DropDownList5.Text = Grid_ETTestItem.Rows[e.NewEditIndex].Cells[8].Text.Trim().ToString();
        //DropDownList dp = Grid_ETTestItem.Rows[e.NewEditIndex].FindControl("DropDownList5") as DropDownList;
        //DropDownList5.SelectedValue = dp.Text;
        BindGridview2(id);
        UpdatePanel_ItemResEdit.Update();
    }

    //更新
    protected void Grid_ETTestItem_Updating(object sender, GridViewUpdateEventArgs e)
    {
        if (LblItemRes.Text == "Amount")
        {
            ExpTestAppInfo ET = expAppSubmitL.Search_ExpTestApp_ID(id)[0];
            if (((TextBox)(Grid_ETTestItem.Rows[e.RowIndex].Cells[6].Controls[0])).Text.Trim().ToString() == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入该项实验数目！')", true);
                return;
            }
            int m1, a;
            if (int.TryParse(((TextBox)(Grid_ETTestItem.Rows[e.RowIndex].Cells[6].Controls[0])).Text.Trim().ToString(), out m1))
                a = m1;
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('实验数目请输入整数！')", true);
                return;
            }
            int v = 0;
            for (int i = 0; i < Grid_ETTestItem.Rows.Count ; i++)
            {
                if (Grid_ETTestItem.Rows[i] == Grid_ETTestItem.Rows[e.RowIndex])
                {
                    i=i+0;
                }
                else 
                { 
                    v += Convert.ToInt32(Grid_ETTestItem.Rows[i].Cells[6].Text.Trim().ToString());
                }
            }
            v += Convert.ToInt32(((TextBox)(Grid_ETTestItem.Rows[e.RowIndex].Cells[6].Controls[0])).Text.Trim().ToString());
            if (v > ET.ETA_SamNum)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('测试数应该小于总样品数！')", true);
                return;
            }
            if (Convert.ToInt32(((TextBox)(Grid_ETTestItem.Rows[e.RowIndex].Cells[6].Controls[0])).Text.Trim().ToString()) <=0)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请填写正确的测试数量！')", true);
                return;
            }
            else
            {
                expTestAppInfo.EIR_ItemAmount = Convert.ToInt32(((TextBox)(Grid_ETTestItem.Rows[e.RowIndex].Cells[6].Controls[0])).Text.Trim().ToString());
            }
            expTestAppInfo.EIR_ItemAcceptance = 0;
            expTestAppInfo.EIR_ItemRes = "";
            expTestAppInfo.EIR_Remaks = "";
        }
        else if (LblItemRes.Text == "Res")
        {
            id = new Guid(LblLuruRes_ID.Text);
            if (((TextBox)(Grid_ETTestItem.Rows[e.RowIndex].Cells[7].Controls[0])).Text.Trim().ToString() == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入合格数！')", true);
                return;
            }
            int m1, a;
            if (int.TryParse(((TextBox)(Grid_ETTestItem.Rows[e.RowIndex].Cells[7].Controls[0])).Text.Trim().ToString(), out m1))
                a = m1;
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('合格数请输入整数！')", true);
                return;
            }
            string c = ((TextBox)(Grid_ETTestItem.Rows[e.RowIndex].Cells[7].Controls[0])).Text.ToString().Trim();
            int b = Convert.ToInt32(((TextBox)(Grid_ETTestItem.Rows[e.RowIndex].Cells[7].Controls[0])).Text.ToString().Trim());
            if (b >Convert.ToInt32( Grid_ETTestItem.Rows[e.RowIndex].Cells[6].Text.Trim()))
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('合格数应小于测试数！')", true);
                return;
            }
            else
                expTestAppInfo.EIR_ItemAcceptance = Convert.ToInt32(((TextBox)(Grid_ETTestItem.Rows[e.RowIndex].Cells[7].Controls[0])).Text.Trim().ToString());

            expTestAppInfo.EIR_ItemAmount = Convert.ToInt32(Grid_ETTestItem.Rows[e.RowIndex].Cells[6].Text.Trim());
            expTestAppInfo.EIR_ItemRes = ((DropDownList)(Grid_ETTestItem.Rows[e.RowIndex].FindControl("DropDownList5"))).Text.Trim().ToString();
            if (expTestAppInfo.EIR_ItemRes == "合格" &&  expTestAppInfo.EIR_ItemAcceptance.ToString ()=="0")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('合格数量不能为0！')", true);
                return;
            }
            expTestAppInfo.EIR_Remaks = ((TextBox)(Grid_ETTestItem.Rows[e.RowIndex].Cells[9].Controls[0])).Text.Trim().ToString();
        }

        expTestAppInfo.EIR_ResDetailID = new Guid(Grid_ETTestItem.DataKeys[e.RowIndex].Value.ToString());
        try
        {
            expAppSubmitL.Update_ExpItemsRes(expTestAppInfo.EIR_ResDetailID, expTestAppInfo.EIR_ItemAmount,
                expTestAppInfo.EIR_ItemAcceptance, expTestAppInfo.EIR_ItemRes, expTestAppInfo.EIR_Remaks);
        }
        catch (Exception exc)
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('录入失败！" + exc + "')", true);
        }
        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('录入成功！')", true);
        Grid_ETTestItem.SelectedIndex = -1;
        Grid_ETTestItem.EditIndex = -1;
        BindGridview2(id);
        UpdatePanel_ItemResEdit.Update();
    }

    //取消
    protected void Grid_ETTestItem_CancelingEdit(object sender, GridViewCancelEditEventArgs e)//取消编辑
    {
        Grid_ETTestItem.SelectedIndex = -1;
        Grid_ETTestItem.EditIndex = -1;
        if (LblItemRes.Text == "Amount")
            id = new Guid(LblSelect_ID.Text);
        else if (LblItemRes.Text == "Res")
            id = new Guid(LblLuruRes_ID.Text);
        BindGridview2(id);
        UpdatePanel_ItemResEdit.Update();
    }

    //控制输入格式
    protected void Grid_ETTestItem_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate)) || (e.Row.RowState == DataControlRowState.Edit))
        {
            if (LblItemRes.Text == "Amount")
            {
                for (int i = 6; i <= 6; i++)
                {
                    ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("style", "ime-mode:disabled");
                    ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("MaxLength", "8");
                    ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("onkeyup", "this.value=this.value.replace(/\\D/g,'')");
                    ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("onafterpaste", "this.value=this.value.replace(/\\D/g,'')");
                }
            }
            else if (LblItemRes.Text == "Res")
            {
                    ((TextBox)e.Row.Cells[7].Controls[0]).Attributes.Add("style", "ime-mode:disabled");
                    ((TextBox)e.Row.Cells[7].Controls[0]).Attributes.Add("MaxLength", "8");
                    ((TextBox)e.Row.Cells[7].Controls[0]).Attributes.Add("onkeyup", "this.value=this.value.replace(/\\D/g,'')");
                    ((TextBox)e.Row.Cells[7].Controls[0]).Attributes.Add("onafterpaste", "this.value=this.value.replace(/\\D/g,'')");
                    //((TextBox)e.Row.Cells[8].Controls[0]).Attributes.Add("MaxLength", "5");
                    ((TextBox)e.Row.Cells[9].Controls[0]).Attributes.Add("MaxLength", "50");

                    DropDownList dp1 = (DropDownList)e.Row.FindControl("DropDownList5");
                    dp1.SelectedValue = ((HiddenField)e.Row.FindControl("HF1")).Value;
            }
        }
    }

    //Gridview2翻页
    protected void Grid_ETTestItem_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_ETTestItem.BottomPagerRow;


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
        BindGridview2(id);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_ETTestItem.PageCount ? Grid_ETTestItem.PageCount - 1 : newPageIndex;
        Grid_ETTestItem.PageIndex = newPageIndex;
        Grid_ETTestItem.DataBind();
    }

    //GridView2行命令
    protected void Grid_ETTestItem_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //if (e.CommandName == "Edit_ItemAmount")
        //{
        //    GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
        //    Grid_ETTestItem.SelectedIndex = row.RowIndex;
        //    Guid ItemResID = new Guid(e.CommandArgument.ToString());
        //    expTestAppInfo = expAppSubmitL.Search_ExpItemsRes_ResID(ItemResID)[0];
        //    ResDetailID = ItemResID;
        //    ExpItemID = expTestAppInfo.EI_ExpItemID;
        //    ClearItem();
        //    this.Panel_ItemResEdit.Visible = true;
        //    this.UpdatePanel_ItemResEdit.Update();
        //    //GridViewRow gvr = (GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent);
        //    //gvr.Cells[0].Text.ToString();
        //    this.TxtItemAmount.Text = Convert.ToString(expTestAppInfo.EIR_ItemAmount);
        //    this.TxtItemAccept.Text = Convert.ToString(expTestAppInfo.EIR_ItemAcceptance);
        //    this.TxtItemRes.Text = expTestAppInfo.EIR_ItemRes;
        //    this.TxtItemRemaks1.Text = expTestAppInfo.EIR_Remaks;
        //    if (LblItemRes.Text == "Amount")
        //    {
        //        Label19.Visible = true;
        //        Label19.Attributes.Add("style ", "display:block ");
        //        TxtItemAmount.Visible = true;
        //        TxtItemAmount.Attributes.Add("style ", "display:block ");
        //        Label21.Visible = false;
        //        TxtItemAccept.Visible = false;
        //        Label22.Visible = false;
        //        TxtItemRes.Visible = false;
        //        Label23.Visible = false;
        //        Label44.Visible = false;
        //        TxtItemRemaks1.Visible = false;
        //    }
        //    else if (LblItemRes.Text == "Res")
        //    {
        //        Label19.Visible = false;
        //        Label19.Attributes.Add("style ", "display:none ");
        //        TxtItemAmount.Visible = false;
        //        TxtItemAmount.Attributes.Add("style ", "display:none ");
        //        Label21.Visible = true;
        //        TxtItemAccept.Visible = true;
        //        Label22.Visible = true;
        //        TxtItemRes.Visible = true;
        //        Label23.Visible = true;
        //        Label44.Visible = true;
        //        TxtItemRemaks1.Visible = true;
        //    }
        //    this.UpdatePanel_ItemResEdit.Update();
        //}
        if (e.CommandName == "Delete_ExpItem")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_ETTestItem.SelectedIndex = row.RowIndex;
            Guid guid = new Guid(e.CommandArgument.ToString());
            expAppSubmitL.Delete_ExpItemsRes(guid);
            //主键为id中存储的值
            //if (LblState.Text == "Edit")
            //{
            //    BindGridview2(id);
            //}
            //else if (LblState.Text == "New")
            //{
            //    BindGridview2(id);
            //}
            BindGridview2(id);
            UpdatePanel_ItemResEdit.Update();
            UpdatePanel_NewExpApp.Update();
        }
    }

    //GridView2悬浮框显示
    protected void Grid_ETTestItem_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Grid_ETTestItem.Rows.Count; i++)
        {
            for (int j = 0; j < Grid_ETTestItem.Rows[i].Cells.Count; j++)
            {
                if (j == 4)
                {
                    Grid_ETTestItem.Rows[i].Cells[j].ToolTip = Grid_ETTestItem.Rows[i].Cells[j].Text;
                    if (Grid_ETTestItem.Rows[i].Cells[j].Text.Length > 80)
                    {
                        Grid_ETTestItem.Rows[i].Cells[j].Text = Grid_ETTestItem.Rows[i].Cells[j].Text.Substring(0, 80) + "...";
                    }
                }
                else
                {
                    Grid_ETTestItem.Rows[i].Cells[j].ToolTip = Grid_ETTestItem.Rows[i].Cells[j].Text;
                    if (Grid_ETTestItem.Rows[i].Cells[j].Text.Length > 10)
                    {
                        Grid_ETTestItem.Rows[i].Cells[j].Text = Grid_ETTestItem.Rows[i].Cells[j].Text.Substring(0, 10) + "...";
                    }
                }
            }
        }
    }
    #endregion

    #region 实验项目明细维护弹窗
    
    //实验项目明细维护弹窗，提交按钮
    protected void Btn_ItemResSubmit1_Click(object sender, EventArgs e)
    {
        id = new Guid(LblLuruRes_ID.Text);

        int j = expAppSubmitL.Search_ExpItemsRes_ID(id).Tables.Count;//j用于存储当前gridview页数
        int k = expAppSubmitL.Search_ExpItemsRes_ID(id).Tables[j - 1].Rows.Count;//k用于存储当前gridview最后一页行数
        //前j-1个表遍历验证
        for (int a = 0; a < j - 1; a++)
        {
            for (int b = 0; b < 2; b++)
            {
                DataRow dr = expAppSubmitL.Search_ExpItemsRes_ID(id).Tables[a].Rows[b];
                //if (Convert.ToString(dr[7]) == "0" || Convert.ToInt32(dr[7]) > Convert.ToInt32(dr[6]))
                if (Convert.ToInt32(dr[7]) < 0 || Convert.ToInt32(dr[7]) > Convert.ToInt32(dr[6]))
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('“合格数量”填写错误！')", true);
                    return;
                }
            }
        }
        //最后一个表遍历验证
        for (int b = 0; b < k; b++)
        {
            DataRow dr = expAppSubmitL.Search_ExpItemsRes_ID(id).Tables[j - 1].Rows[b];
            //if (Convert.ToString(dr[7]) == "0" || Convert.ToInt32(dr[7]) > Convert.ToInt32(dr[6]))
            if (Convert.ToInt32(dr[7]) < 0 || Convert.ToInt32(dr[7]) > Convert.ToInt32(dr[6]))
            {
                int a1, b1;
                a1 = (j / 2) + 1;
                b1 = b - (b / 2) * 2 + 1;
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('“合格数量”填写错误！')", true);
                return;
            }
        }
        ExpTestAppInfo ET = expAppSubmitL.Search_ExpTestApp_ID(id)[0];
        Lbl_LastRes.Text = "实验申请单" + ET.ETA_ExpAppNO + "结果录入";
        Txt_ExpRes.Text = "";
        Txt_ResInstruction.Text = "";
        Panel_LastRes.Visible = true;
        UpdatePanel_LastRes.Update();
    }

    //实验项目明细维护，取消按钮
    protected void BtnItemResCancel_Click(object sender, EventArgs e)
    {
        Txt_ExpRes.Text = "";
        Txt_ResInstruction.Text = "";
        Panel_LastRes.Visible = false;
        UpdatePanel_LastRes.Update();
        Panel_ItemResEdit.Visible = false;
        UpdatePanel_ItemResEdit.Update();
        Panel_SearchItem.Visible = false;
        UpdatePanel_SearchItem.Update();
    }
    #endregion

    #region 审核栏
    //审核栏，审核通过按钮
    protected void BtnAuPass_Click(object sender, EventArgs e)
    {
        ExpTestAppInfo ET = new ExpTestAppInfo();
        ET.ETA_ExpID = id;
        ET.ETA_AppStatus = "审核通过";
        if (TxtAuSugg.Text != "")
        {
            ET.ETA_AuSugg = TxtAuSugg.Text;
        }
        else
        {
            ET.ETA_AuSugg = "";
        }
        ET.ETA_AuRes = "审核通过";
        ET.ETA_Auditor = Session["UserName"].ToString().Trim();
        try
        {
            expAppSubmitL.Update_ExpTestAppAu(ET);
        }
        catch (Exception exc)
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('审核失败，请重新审核或联系管理员！" + exc + "')", true);
        }
        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('审核成功！')", true);
        
        //RTX
        string message = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "审核通过了一个实验申请。";
        string sErr = RTXhelper.Send(message, "实验申请接收");
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('" + sErr + "')", true);
        }

        Panel_AppAu.Visible = false;
        UpdatePanel_AppAu.Update();
        Bindc ="AND ETA_AppStatus='已提交'";
        BindGridview1(Bindc);
        UpdatePanel_ExpApp.Update();
        if (Panel_NewExpApp.Visible)
        {
            Panel_NewExpApp.Visible = false;
            UpdatePanel_NewExpApp.Update();
        }
    }

    //审核栏，审核不通过按钮
    protected void BtnAuReject_Click(object sender, EventArgs e)
    {
        if (TxtAuSugg.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请填写审核意见！')", true);
            return;
        }
        ExpTestAppInfo ET = new ExpTestAppInfo();
        ET.ETA_ExpID = id;
        ET.ETA_AppStatus = "审核驳回";
        if (TxtAuSugg.Text != "")
        {
            ET.ETA_AuSugg = TxtAuSugg.Text;
        }
        else
        {
            ET.ETA_AuSugg = "";
        }
        ET.ETA_AuRes = "审核驳回";
        ET.ETA_Auditor = Session["UserName"].ToString().Trim();
        try
        {
            expAppSubmitL.Update_ExpTestAppAu(ET);
        }
        catch (Exception exc)
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('审核失败，请重新审核或联系管理员！" + exc + "')", true);
        }
        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('审核成功！')", true);

        //RTX
        string message = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "审核驳回了一个实验申请。";
        //string sErr = RTXhelper.Send(message, "实验申请提交");
        string p1 = Labelp1.Text;
        string sErr = RTXhelper.SendbyUserName(message, p1);
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('" + sErr + "')", true);
        }

        Panel_AppAu.Visible = false;
        UpdatePanel_AppAu.Update();
        Bindc = "AND ETA_AppStatus='已提交'";
        BindGridview1(Bindc);
        UpdatePanel_ExpApp.Update();
        if (Panel_NewExpApp.Visible)
        {
            Panel_NewExpApp.Visible = false;
            UpdatePanel_NewExpApp.Update();
        }
    }

    //审核栏，取消按钮
    protected void BtnAuCancle_Click(object sender, EventArgs e)
    {
        Panel_AppAu.Visible = false;
        UpdatePanel_AppAu.Update();
        if (Panel_NewExpApp.Visible)
        {
            Panel_NewExpApp.Visible = false;
            UpdatePanel_NewExpApp.Update();
        }
    }
    #endregion

    #region 接收栏
    //接收栏，接收按钮
    protected void BtnAppAck_Click(object sender, EventArgs e)
    {
        ExpTestAppInfo ET = new ExpTestAppInfo();
        ET.ETA_ExpID = id;
        ET.ETA_AppStatus = "实验中";
        ET.ETA_AckPer = Session["UserName"].ToString().Trim();
        if (TxtEstimateT.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        else
            ET.ETA_EstimateT =Convert.ToDateTime( TxtEstimateT.Text);
        try
        {
            expAppSubmitL.Update_ExpTestAppAck(ET);
        }
        catch (Exception exc)
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('接收失败，请重新接收或联系管理员！" + exc + "')", true);
        }
        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('接收成功！')", true);

        //RTX
        string message = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "接收了一个实验申请。";
        string sErr = RTXhelper.Send(message, "实验结果录入");
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('" + sErr + "')", true);
        }
        Panel_AppAck.Visible = false;
        UpdatePanel_AppAck.Update();
        Bindc = "AND ETA_AppStatus='审核通过'";
        BindGridview1(Bindc);
        UpdatePanel_ExpApp.Update();
    }

    //接收栏，取消按钮
    protected void BtnAckCancel_Click(object sender, EventArgs e)
    {
        Panel_AppAck.Visible = false;
        UpdatePanel_AppAck.Update();
    }
    #endregion

    #region 审批栏
    //审批栏，通过
    protected void BtnArlSubmit_Click(object sender, EventArgs e)
    {
        ExpTestAppInfo ET = new ExpTestAppInfo();
        ET.ETA_ExpID = id;
        ET.ETA_AppStatus = "审批通过";
        ET.ETA_ApprovalRes = "审批通过";
        if (TxtApprovalSugg.Text != "")
        {
            ET.ETA_ApprovalSugg = TxtApprovalSugg.Text;
        }
        else
        {
            ET.ETA_ApprovalSugg = "";
        }
        ET.ETA_Approver = Session["UserName"].ToString().Trim();
        try
        {
            expAppSubmitL.Update_ExpTestAppArl(ET);
        }
        catch (Exception exc)
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('审批失败，请重新审批或联系管理员！" + exc + "')", true);
        }
        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('审批成功！')", true);

        //RTX
        string message = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "审批通过了一个实验。";
        string p2 = Labelp2.Text;
        string sErr = RTXhelper.SendbyUserName(message, p2);
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('" + sErr + "')", true);
        }
        Panel_AppArl.Visible = false;
        UpdatePanel_AppArl.Update();
        Bindc = "AND ETA_AppStatus='已完成'";
        BindGridview1(Bindc);
        UpdatePanel_ExpApp.Update();
    }
    //审批栏，驳回
    protected void BtnArReject_Click(object sender, EventArgs e)
    {
        if (TxtApprovalSugg.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请填写审批意见！')", true);
            return;
        }
        ExpTestAppInfo ET = new ExpTestAppInfo();
        ET.ETA_ExpID = id;
        ET.ETA_AppStatus = "审批驳回";
        ET.ETA_ApprovalRes = "审批驳回";
        if (TxtApprovalSugg.Text != "")
        {
            ET.ETA_ApprovalSugg = TxtApprovalSugg.Text;
        }
        else
        {
            ET.ETA_ApprovalSugg = "";
        }
        ET.ETA_Approver = Session["UserName"].ToString().Trim();
        try
        {
            expAppSubmitL.Update_ExpTestAppArl(ET);
        }
        catch (Exception exc)
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('审批失败，请重新审批或联系管理员！" + exc + "')", true);
        }
        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('已驳回！')", true);

        //RTX
        string message = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "审批驳回了一个实验，请核实。";
        string sErr = RTXhelper.Send(message, "实验结果录入");
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('" + sErr + "')", true);
        }
        
        Panel_AppArl.Visible = false;
        UpdatePanel_AppArl.Update();
        Bindc = "AND ETA_AppStatus='已完成'";
        BindGridview1(Bindc);
        UpdatePanel_ExpApp.Update();
    }

    //审批栏，取消按钮
    protected void BtnArlCancel_Click(object sender, EventArgs e)
    {
        Panel_AppArl.Visible = false;
        UpdatePanel_AppArl.Update();
    }
    #endregion

    #region 检索实验项目栏
    //选择实验项目弹窗，检索按钮
    protected void BtnSearchItem_Click(object sender, EventArgs e)
    {
        BindGridview3(TxtSearchItem.Text, TxtSearchCondition.Text, TxtSearchMethod.Text);
        BtnSearchItem1 = TxtSearchItem.Text;
        BtnSearchItem2 = TxtSearchCondition.Text;
        BtnSearchItem3 = TxtSearchMethod.Text;
        UpdatePanel_SearchItem.Update();
    }

    //选择实验项目弹窗，取消按钮
    protected void BtnCloseItem_Click(object sender, EventArgs e)
    {
        if (Panel_SearchItem.Visible)
        {
            Panel_SearchItem.Visible = false;
        }
        UpdatePanel_SearchItem.Update();
    }
    #endregion

    #region GridView3操作
    //Gridview3翻页
    protected void Grid_SelectItem_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView_SelectItem.BottomPagerRow;


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
        //  GridView_SelectItem.DataBind();
        BindGridview3(BtnSearchItem1, BtnSearchItem2, BtnSearchItem3);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView_SelectItem.PageCount ? GridView_SelectItem.PageCount - 1 : newPageIndex;
        GridView_SelectItem.PageIndex = newPageIndex;
        GridView_SelectItem.DataBind();
    }

    //GridView3行命令
    protected void Grid_SelectItem_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Choose_Item")
        {
            id = new Guid(LblSelect_ID.Text);
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_SelectItem.SelectedIndex = row.RowIndex;
            Guid EI_ExpItemID = new Guid(e.CommandArgument.ToString());
            Guid EIR_ResDetailID = Guid.NewGuid();
            //if (LblState.Text == "New")
            //{
            //    expAppSubmitL.Insert_ExpItemsRes(EIR_ResDetailID, idnew, EI_ExpItemID, 0);
            //}
            //else
                expAppSubmitL.Insert_ExpItemsRes(EIR_ResDetailID, id, EI_ExpItemID, 0);
            BindGridview2(id);
            UpdatePanel_ItemResEdit.Update();
        }

    }

    //GridView3悬浮框显示
    protected void GridView_SelectItem_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView_SelectItem.Rows.Count; i++)
        {
            //for (int j = 0; j < GridView_SelectItem.Rows[i].Cells.Count; j++)
            //{
            //    GridView_SelectItem.Rows[i].Cells[j].ToolTip = GridView_SelectItem.Rows[i].Cells[j].Text;
            //    if (GridView_SelectItem.Rows[i].Cells[j].Text.Length > 25)
            //    {
            //        GridView_SelectItem.Rows[i].Cells[j].Text = GridView_SelectItem.Rows[i].Cells[j].Text.Substring(0, 25) + "...";
            //    }
            //}
            GridView_SelectItem.Rows[i].Cells[3].ToolTip = GridView_SelectItem.Rows[i].Cells[3].Text;
            if (GridView_SelectItem.Rows[i].Cells[3].Text.Length > 15)
            {
                GridView_SelectItem.Rows[i].Cells[3].Text = GridView_SelectItem.Rows[i].Cells[3].Text.Substring(0, 15) + "...";
            }
            GridView_SelectItem.Rows[i].Cells[2].ToolTip = GridView_SelectItem.Rows[i].Cells[2].Text;
            if (GridView_SelectItem.Rows[i].Cells[2].Text.Length > 60)
            {
                GridView_SelectItem.Rows[i].Cells[2].Text = GridView_SelectItem.Rows[i].Cells[2].Text.Substring(0, 60) + "...";
            }
        }
    }
    #endregion

    #region 私有函数
    //绑定新建窗口申请部门Ddl
    private void Bind_DdlAppDep(DropDownList Ddl)
    {
        Ddl.DataSource = expAppSubmitL.Search_NETrainingItem_BDOrganizationSheet().Tables[0].DefaultView;
        Ddl.DataTextField = "BDOS_Name";
        Ddl.DataValueField = "BDOS_Code";
        Ddl.DataBind();
        Ddl.Items.Insert(0, new ListItem("请选择", ""));
    }

    //绑定新建窗口样品类型Ddl，数据Value绑定主键可能出错
    private void Bind_DdlSampleType(DropDownList Ddl)
    {
        Ddl.DataSource = expTestL.Search_ExpSampleType_GridView("").Tables[0].DefaultView;
        Ddl.DataTextField = "EST_SampleType";
        Ddl.DataValueField = "EST_SampleTypeID";
        Ddl.DataBind();
        Ddl.Items.Insert(0, new ListItem("请选择", ""));
    }

    //计算文本长度
    public static int TextLength(string strText)
    {
        int intLen = 0;
        if (!String.IsNullOrEmpty(strText))
        {
            for (int i = 0; i < strText.Length; i++)
            {
                byte[] bytelen = Encoding.Default.GetBytes(strText.Substring(i, 1));
                if (bytelen.Length > 1)
                    intLen += 2;  //如果长度大于1，是中文，占两个字节，+2   
                else
                    intLen += 1;  //如果长度等于1，是英文，占一个字节，+1   
            }
        }
        return intLen;
    }

    //私有，新建窗口，清空方法
    private void ClearNew()
    {
        TxtNewProIdentify.Text = "";
        TxtNewSamNum.Text = "";
        TxtNewUnits.Text = "";
        DdlAppDep.ClearSelection();
        DdlSampleType.ClearSelection();
        TxtRemaks.Text = "";
    }

    ////私有，维护实验项目明细弹窗，清空方法
    //private void ClearItem()
    //{
    //    TxtItemAmount.Text = "";
    //    TxtItemAccept.Text = "";
    //    TxtItemRes.Text = "";
    //    TxtItemRemaks1.Text = "";
    //}

    //私有，选择实验项目窗口，清空方法
    private void ClearSearch()
    {
        TxtSearchItem.Text = "";
        TxtSearchCondition.Text = "";
        TxtSearchMethod.Text = "";
    }

    //绑定实验申请Gridview1，用于刷新GridView
    private void BindGridview1(string Condition)
    {
        Grid_ExpApp.DataSource = expAppSubmitL.Search_ExpTestApp_GridView1(Condition);
        Grid_ExpApp.DataBind();
    }

    //绑定实验项目Gridview2，用于刷新GridView
    private void BindGridview2(Guid id)
    {
        Grid_ETTestItem.DataSource = expAppSubmitL.Search_ExpItemsRes_ID(id);
        Grid_ETTestItem.DataBind();
    }

    //绑定检索实验项目Gridview3，用于刷新GridView
    private void BindGridview3(string Item, string Cond, string Meth)
    {
        GridView_SelectItem.DataSource = expTestL.Search_ExpItems_Gridview(Item, Cond, Meth);
        GridView_SelectItem.DataBind();
    }
    #endregion


    protected void BtnItemResSubmit_Click(object sender, EventArgs e)
    {
        id = new Guid(LblSelect_ID.Text);
        ExpTestAppInfo ET = expAppSubmitL.Search_ExpTestApp_ID(id)[0];
        if (ET.ETA_ProIdentify == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请先完成实验申请单：产品标识')", true);
            return;
        }
        if (ET.EST_SampleType == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请先完成实验申请单：样品类型')", true);
            return;
        }
        if (ET.BDOS_Code == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请先完成实验申请单：申请部门')", true);
            return;
        }
        if (ET.ETA_SamNum == 0)
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请先完成实验申请单：样品总数')", true);
            return;
        }
        if (ET.ETA_Units == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请先完成实验申请单：单位')", true);
            return;
        }
        if (ET.ETA_EmergDegree == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请先完成实验申请单：紧急程度')", true);
            return;
        }
        int j = expAppSubmitL.Search_ExpItemsRes_ID(id).Tables.Count;//j用于存储当前gridview页数
        int k = expAppSubmitL.Search_ExpItemsRes_ID(id).Tables[j - 1].Rows.Count;//k用于存储当前gridview最后一页行数
        //前j-1个表遍历验证
        for (int a = 0; a < j - 1; a++)
        {
            for (int b = 0; b < 2; b++)
            {
                DataRow dr = expAppSubmitL.Search_ExpItemsRes_ID(id).Tables[a].Rows[b];
                if (Convert.ToString(dr[6]) == "0" || Convert.ToInt32(dr[6]) > ET.ETA_SamNum || Convert.ToInt32(dr[6])<0)
                {
                    //ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('第" + Convert.ToString(a + 1) + "页第" + Convert.ToString(b + 1) + "行测试数填写错误！')", true);
                    //return;
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('“测试数量”填写错误！')", true);
                    return;
                }
            }
        }
        //最后一个表遍历验证
        for (int b = 0; b < k; b++)
        {
            DataRow dr = expAppSubmitL.Search_ExpItemsRes_ID(id).Tables[j - 1].Rows[b];
            if (Convert.ToString(dr[6]) == "0" || Convert.ToInt32(dr[6]) > ET.ETA_SamNum || Convert.ToInt32(dr[6]) < 0)
            {
                int a1, b1;
                a1 = (j / 2)+1;
                b1 = b - (b/2)*2+1;
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('“测试数量”填写错误！')", true);
                return;
            }
        }
        expAppSubmitL.Update_ExpTestApp_Status(id);
        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('提交成功！')", true);
        //RTX
        //string message = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "提交了一个实验申请单。";
        //string sErr = RTXhelper.SendbyDepAndRole(message,this.Labeldep.Text, "实验申请审核");
        //if (!string.IsNullOrEmpty(sErr))
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('" + sErr + "')", true);
        //}
        string message = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "提交了一个实验申请单，请审核。";
        string sErr = RTXhelper.Send(message,"实验申请审核");
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('" + sErr + "')", true);
        }

        Panel_ItemResEdit.Visible = false;
        UpdatePanel_ItemResEdit.Update();
        Panel_SearchItem.Visible = false;
        UpdatePanel_SearchItem.Update();
        BindGridview1(Bindc);
        UpdatePanel_ExpApp.Update();

    }
    protected void Btn_LastResSubmit_Click(object sender, EventArgs e)
    {
        id = new Guid(LblLuruRes_ID.Text);
        ExpTestAppInfo exp = new ExpTestAppInfo();
        exp.ETA_ExpID = id;
        exp.ETA_AppStatus = "已完成";
        exp.ETA_ExpPer = Session["UserName"].ToString().Trim();
        if (Txt_ExpRes.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        else
            exp.ETA_ExpRes = Txt_ExpRes.Text.ToString().Trim();
        exp.ETA_ResInstruction = Txt_ResInstruction.Text.ToString().Trim();
        expAppSubmitL.Update_ExpTestAppRes(exp);
        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('录入成功！')", true);

        //RTX
        string message = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "完成了一个实验申请。";
        string sErr = RTXhelper.Send(message, "实验结果审批");
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('" + sErr + "')", true);
        }

        Panel_LastRes.Visible = false;
        UpdatePanel_LastRes.Update();
        Panel_ItemResEdit.Visible = false;
        UpdatePanel_ItemResEdit.Update();
        Bindc = "AND ETA_AppStatus='实验中'";
        BindGridview1(Bindc);
        UpdatePanel_ExpApp.Update();
    }
    protected void Btn_LastResClose_Click(object sender, EventArgs e)
    {
        Txt_ExpRes.Text = "";
        Txt_ResInstruction.Text = "";
        Panel_LastRes.Visible = false;
        UpdatePanel_LastRes.Update();
    }
}