using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProductionProcess_ErrorRelevant : Page
{
    ErrorRelevantL erl = new ErrorRelevantL();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
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
                Title = "异常查看";
                Btn_M_Confirm.Visible = false;
                Btn_ErrorDealer_Confirm.Visible = false;
                Btn_ErrorTrack_Confirm.Visible = false;
                GridView2.Columns[7].Visible = false;
                Btn_ErrorRecover_Confirm.Visible = false;
                Button1.Visible = false;
                Button3.Visible = false;
            }

            if (state.Trim() == "clycjy")
            {
                Title = "材料异常检验";
                Btn_ErrorDealer_Confirm.Visible = false;
                Btn_ErrorTrack_Confirm.Visible = false;
                GridView2.Columns[7].Visible = false;
                Btn_ErrorRecover_Confirm.Visible = false;
                Button1.Visible = false;
                Button3.Visible = false;
            }
            if (state.Trim() == "yccl")
            {
                Title = "异常处理";
                Btn_M_Confirm.Visible = false;
                // Btn_ErrorDealer_Confirm.Visible = false;
                Btn_ErrorTrack_Confirm.Visible = false;
                GridView2.Columns[7].Visible = false;
                Btn_ErrorRecover_Confirm.Visible = false;
                Button1.Visible = false;
                Button3.Visible = false;
            }
            if (state.Trim() == "ycgz")
            {
                Title = "异常跟踪";
                Btn_M_Confirm.Visible = false;
                Btn_ErrorDealer_Confirm.Visible = false;
                //   Btn_ErrorTrack_Confirm.Visible = false;
                GridView2.Columns[7].Visible = false;
                Btn_ErrorRecover_Confirm.Visible = false;
                Button1.Visible = false;
                Button3.Visible = false;
            }
            if (state.Trim() == "ycja")
            {
                Title = "异常结案";
                Btn_M_Confirm.Visible = false;
                Btn_ErrorDealer_Confirm.Visible = false;
                Btn_ErrorTrack_Confirm.Visible = false;
                GridView2.Columns[7].Visible = false;
                //   Btn_ErrorRecover_Confirm.Visible = false;
                Button1.Visible = false;
                Button3.Visible = false;
            }
            if (state.Trim() == "ycsh")
            {
                Title = "异常审核";
                Btn_M_Confirm.Visible = false;
                Btn_ErrorDealer_Confirm.Visible = false;
                Btn_ErrorTrack_Confirm.Visible = false;
                GridView2.Columns[7].Visible = false;
                Btn_ErrorRecover_Confirm.Visible = false;
                // Button1.Visible = false;
                Button3.Visible = false;
            }
            if (state.Trim() == "ychq")
            {
                Title = "异常会签";
                Btn_M_Confirm.Visible = false;
                Btn_ErrorDealer_Confirm.Visible = false;
                Btn_ErrorTrack_Confirm.Visible = false;
               // GridView2.Columns[7].Visible = false;
                Btn_ErrorRecover_Confirm.Visible = false;
                Button1.Visible = false;
                Button3.Visible = false;
            }
            if (state.Trim() == "ycfg")
            {
                Title = "异常返工";
                Btn_M_Confirm.Visible = false;
                Btn_ErrorDealer_Confirm.Visible = false;
                Btn_ErrorTrack_Confirm.Visible = false;
                GridView2.Columns[7].Visible = false;
                Btn_ErrorRecover_Confirm.Visible = false;
                Button1.Visible = false;
                // Button3.Visible = false;
            }
            if (!IsPostBack)
            {
                try
                {
                    if (!((Session["UserRole"].ToString().Contains("异常查看")) || (Session["UserRole"].ToString().Contains("材料异常检验")) || (Session["UserRole"].ToString().Contains("异常处理")) || (Session["UserRole"].ToString().Contains("异常跟踪")) || (Session["UserRole"].ToString().Contains("异常结案")) || (Session["UserRole"].ToString().Contains("异常审核")) || (Session["UserRole"].ToString().Contains("异常会签")) || (Session["UserRole"].ToString().Contains("异常返工"))))
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('可能您没有权限操作和查看本页面，请退出选择其他账号登陆，或联系管理员！')", true);

                        Response.Redirect("~/Default.aspx");

                    }
                    if (!(Session["UserRole"].ToString().Contains("材料异常检验")))
                    {
                        Btn_M_Confirm.Visible = false;

                    }
                    if (!(Session["UserRole"].ToString().Contains("异常处理")))
                    {
                        Btn_ErrorDealer_Confirm.Visible = false;

                    }
                    if (!(Session["UserRole"].ToString().Contains("异常跟踪")))
                    {
                        Btn_ErrorTrack_Confirm.Visible = false;

                    }
                    if (!(Session["UserRole"].ToString().Contains("异常结案")))
                    {
                        Btn_ErrorRecover_Confirm.Visible = false;

                    }
                    if (!(Session["UserRole"].ToString().Contains("异常审核")))
                    {
                        Button1.Visible = false;

                    }
                    if (!(Session["UserRole"].ToString().Contains("异常会签")))
                    {
                        GridView2.Columns[7].Visible = false;


                    }
                    if (!(Session["UserRole"].ToString().Contains("异常返工")))
                    {
                        Button3.Visible = false;

                    }
                    label_GridPageState.Text = "默认数据源";
                    string condition = " and 1=1";
                    GridView_WOmain.DataSource = erl.S_WorkOrder_Check(condition);
                    GridView_WOmain.DataBind();
                    UpdatePanel_WOmain.Update();
                    DropDownList_PBC.DataSource = erl.S_WOError_Rework_PBCraft();
                    DropDownList_PBC.DataTextField = "PBC_Name";
                    DropDownList_PBC.DataValueField = "PBC_ID";
                    DropDownList_PBC.DataBind();
                    DropDownList_PBC.Items.Insert(0, new ListItem("请选择", ""));

                    DropDownList_ReworkOption.DataSource = erl.S_WOError_Rework_ReWorkOption();
                    DropDownList_ReworkOption.DataTextField = "RWO_Name";
                    DropDownList_ReworkOption.DataValueField = "RWO_ID";
                    DropDownList_ReworkOption.DataBind();
                    DropDownList_ReworkOption.Items.Insert(0, new ListItem("请选择", ""));
                }
                catch (Exception)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('可能您没有权限操作和查看本页面，请退出选择其他账号登陆，或联系管理员！')", true);
                    Response.Redirect("~/Default.aspx");
                }
            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('可能您没有权限操作和查看本页面，请退出选择其他账号登陆，或联系管理员！')", true);
            Response.Redirect("~/Default.aspx");

        }
    }



    public void databind()
    {
        string condition;
        string WO_Type = DropDownList_WO_Type.SelectedItem.Text.Trim() == "请选择" ? " and 1=1 " : " and WO_Type like '%" + DropDownList_WO_Type.SelectedItem.Text.Trim() + "%' ";
        //string WO_People = this.TextBox_WO_People.Text.Trim() == "请选择" ? " and 1=1 " : " and WO_People like '%" + this.TextBox_WO_People.Text.Trim() + "%' ";
        if ((TextBox_WO_Time1.Text != "" && TextBox_WO_Time2.Text == "") || (TextBox_WO_Time1.Text == "" && TextBox_WO_Time2.Text != ""))
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请将时间检索范围输入完整，请您再次核对！')", true);
            return;
        }

        string WO_Time = (TextBox_WO_Time1.Text.Trim() == "" && TextBox_WO_Time2.Text.Trim() == "") ? " and 1=1 " : " and WOD_StaTime between   ' " + TextBox_WO_Time1.Text.Trim() + "' and ' " + TextBox_WO_Time2.Text.Trim() + "'";
        string WO_Num = TextBox_wonum.Text.Trim() == "" ? " and 1=1 " : " and WO_Num like '%" + TextBox_wonum.Text.Trim() + "%' ";
        string pbcname = TextBox_PBC.Text.Trim() == "" ? " and 1=1 " : " and PBC_Name like '%" + TextBox_PBC.Text.Trim() + "%' ";
        string SMSO_ComOrderNum = TextBox_OrderNum.Text.Trim() == "" ? " and 1=1 " : " and SMSO_ComOrderNum like '%" + TextBox_OrderNum.Text.Trim() + "%' ";
        string WO_ProType = TextBox_pt.Text.Trim() == "" ? " and 1=1 " : " and WO_ProType like '%" + TextBox_pt.Text.Trim() + "%' ";
        string WO_ChipNum = TextBox_chipnum.Text.Trim() == "" ? " and 1=1 " : " and WO_ChipNum like '%" + TextBox_chipnum.Text.Trim() + "%' ";
        string WO_Level = DropDownList_level.SelectedItem.Text.Trim() == "请选择" ? " and 1=1 " : " and WO_Level like '%" + DropDownList_level.SelectedItem.Text.Trim() + "%' ";
        string WO_State = DropDownList_WoState.SelectedItem.Text.Trim() == "请选择" ? " and 1=1 " : " and WO_State like '%" + DropDownList_WoState.SelectedItem.Text.Trim() + "%' ";
        string WO_SN = TextBox_WOSN.Text.Trim() == "" ? " and 1=1 " : " and WO_SN like '%" + TextBox_WOSN.Text.Trim() + "%' ";
        condition = WO_Type + WO_Time + WO_Num + pbcname + SMSO_ComOrderNum + WO_ProType + WO_ChipNum + WO_Level + WO_State + WO_SN;
        GridView_WOmain.DataSource = erl.S_WorkOrder_Check(condition);
        GridView_WOmain.DataBind();
        UpdatePanel_WOmain.Update();

    }


    protected void Btn_Search_Click(object sender, EventArgs e)//检索
    {
        databind();
        label_GridPageState.Text = "检索数据源";
    }
    protected void Button_Cancel_Click(object sender, EventArgs e)//重置
    {
        DropDownList_level.SelectedIndex = 0;
        DropDownList_WO_Type.SelectedIndex = 0;
        DropDownList_WoState.SelectedIndex = 0;
        TextBox_chipnum.Text = "";
        TextBox_OrderNum.Text = "";
        TextBox_wonum.Text = "";
        TextBox_PBC.Text = "";
        TextBox_pt.Text = "";
        TextBox_WO_Time1.Text = "";
        TextBox_WO_Time2.Text = "";
        TextBox_WOSN.Text = "";
        string condition = " and 1=1";
        GridView_WOmain.DataSource = erl.S_WorkOrder_Check(condition);
        GridView_WOmain.DataBind();
        UpdatePanel_WOmain.Update();

        GridView_WOmain.SelectedIndex = -1;
        GridView_Error.SelectedIndex = -1;
        //以下pannel隐藏

        Panel_ErrorList.Visible = false;
        UpdatePanel_ErrorList.Update();
        Panel_M.Visible = false;
        UpdatePanel_M.Update();
        Panel_Error.Visible = false;
        UpdatePanel_Error.Update();
        Panel_Track.Visible = false;
        UpdatePanel_Track.Update();
        Panel_C.Visible = false;
        UpdatePanel_C.Update();
        Panel_Recover.Visible = false;
        UpdatePanel_Recover.Update();
        Panel_Review.Visible = false;
        UpdatePanel_Review.Update();
        Panel_ReWork.Visible = false;
        UpdatePanel_ReWork.Update();


    }
    protected void Btn_ErrorRecover_Confirm_Click(object sender, EventArgs e)//异常结案
    {
        try
        {
            Guid woeid = new Guid(label_Recover_WOEID.Text.Trim());
            string people = Session["UserName"].ToString().Trim();
            string state = "异常中";
            if (DropDownList_Recovery.SelectedItem.Text.Trim() == "是")
            {
                state = "异常恢复";

            }
            if (DropDownList_Recovery.SelectedItem.Text.Trim() == "否")
            {
                state = "异常中";
            }
            if (DropDownList_Recovery.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "confirm", "alert('请选择异常是否恢复！')", true);
                return;
            }
            erl.U_WOError_Done(woeid, people, TextBox_WOE_QCResult.Text.Trim(), TextBox_WOE_DoneResult.Text.Trim(), state);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "confirm", "alert('制定成功！')", true);
            Panel_Recover.Visible = false;
            string id;

            if (label_wodid.Text.Trim() == "")
            {

                id = "00000000-0000-0000-0000-000000000000";
            }
            else
            {
                id = label_wodid.Text;
            }
            GridView_Error.DataSource = erl.S_WorkOrderDetail_ErrorCheck(new Guid(id));
            GridView_Error.DataBind();
            UpdatePanel_ErrorList.Update();
            DropDownList_Recovery.SelectedIndex = 0;

        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('制定失败！')", true);
            return;

        }
    }
    protected void Btn_ErrorRecover_Cancel_Click(object sender, EventArgs e)//异常结案取消
    {
        Panel_Recover.Visible = false;
        TextBox_WOE_DoneMan.Text = "";
        TextBox_WOE_DoneTime.Text = "";
        TextBox_WOE_QCResult.Text = "";
        TextBox_WOE_DoneResult.Text = "";
        DropDownList_Recovery.SelectedIndex = 0;
        UpdatePanel_Recover.Update();

    }
    protected void Btn_ErrorTrack_Confirm_Click(object sender, EventArgs e)//异常跟踪
    {
        try
        {
            Guid woeid = new Guid(label_Track_WOEID.Text.Trim());
            string people = Session["UserName"].ToString().Trim();

            erl.U_WOError_Track(woeid, people, TextBox_TrackResult.Text.Trim());
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "confirm", "alert('制定成功！')", true);
            Panel_Track.Visible = false;
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('制定失败！')", true);
            return;

        }
    }
    protected void Btn_ErrorTrack_Cancel_Click(object sender, EventArgs e)//异常跟踪取消
    {
        Panel_Track.Visible = false;
        TextBox_TrackMan.Text = "";
        TextBox_TrackTime.Text = "";
        TextBox_TrackResult.Text = "";

        UpdatePanel_Track.Update();
    }
    protected void Btn_ErrorDealer_Confirm_Click(object sender, EventArgs e)//异常处理
    {
        try
        {
            Guid woeid = new Guid(label_ED_WOEID.Text.Trim());
            string people = Session["UserName"].ToString().Trim();

            erl.U_WOError_Deal(woeid, people, TextBox_ReaAnalysis.Text.Trim(), TextBox_ProDeal.Text.Trim(), TextBox_LongTimeMeasure.Text.Trim());
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "confirm", "alert('制定成功！')", true);
            Panel_Error.Visible = false;
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('制定失败！')", true);
            return;

        }



    }
    protected void Btn_ErrorDealer_Cancel_Click(object sender, EventArgs e)//异常处理取消
    {
        Panel_Error.Visible = false;

        TextBox_DealMan.Text = "";
        TextBox_DealTime.Text = "";
        TextBox_ReaAnalysis.Text = "";
        TextBox_ProDeal.Text = "";
        TextBox_LongTimeMeasure.Text = "";

        UpdatePanel_Error.Update();

    }
    protected void Btn_M_Confirm_Click(object sender, EventArgs e)//材料检验
    {
        try
        {
            Guid woeid = new Guid(label_M_WOEID.Text.Trim());
            string people = Session["UserName"].ToString().Trim();
            erl.U__WOError_MQC(woeid, people, TextBox_MR.Text.Trim());
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "confirm", "alert('制定成功！')", true);
            Panel_M.Visible = false;
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('制定失败！')", true);
            return;

        }
    }
    protected void Btn_M_Cancel_click(object sender, EventArgs e)//材料检验取消
    {
        Panel_M.Visible = false;
        TextBox_MM.Text = "";
        TextBox_MT.Text = "";
        TextBox_MR.Text = "";
        UpdatePanel_M.Update();

    }
    protected void GridView_WOmain_PageIndexChanging(object sender, GridViewPageEventArgs e)//随工单表翻页
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;
        GridView_WOmain.SelectedIndex = -1;
        if (-2 == e.NewPageIndex)
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
        GridView_WOmain.PageIndex = newPageIndex;

        databind();
        //以下pannel隐藏

        Panel_ErrorList.Visible = false;
        UpdatePanel_ErrorList.Update();
        Panel_M.Visible = false;
        UpdatePanel_M.Update();
        Panel_Error.Visible = false;
        UpdatePanel_Error.Update();
        Panel_Track.Visible = false;
        UpdatePanel_Track.Update();
        Panel_C.Visible = false;
        UpdatePanel_C.Update();
        Panel_Recover.Visible = false;
        UpdatePanel_Recover.Update();
        Panel_Review.Visible = false;
        UpdatePanel_Review.Update();
        Panel_ReWork.Visible = false;
        UpdatePanel_ReWork.Update();
    }
    protected void GridView_WOmain_RowCommand(object sender, GridViewCommandEventArgs e)//随工单表行按钮
    {
        if (e.CommandName == "ErrorInfo")//
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_WOmain.SelectedIndex = row.RowIndex;
            //  GridView_WOmain.SelectedIndex = -1;
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            label_wodid.Text = al[1];
            Panel_ErrorList.Visible = true;
            string id;
            if (al[1].Trim() == "")
            {

                id = "00000000-0000-0000-0000-000000000000";
            }
            else
            {
                id = al[1];
            }
            GridView_Error.DataSource = erl.S_WorkOrderDetail_ErrorCheck(new Guid(id));
            GridView_Error.DataBind();
            UpdatePanel_ErrorList.Update();



            //以下pannel隐藏

            //  Panel_ErrorList.Visible = false;
            //  UpdatePanel_ErrorList.Update();
            Panel_M.Visible = false;
            UpdatePanel_M.Update();
            Panel_Error.Visible = false;
            UpdatePanel_Error.Update();
            Panel_Track.Visible = false;
            UpdatePanel_Track.Update();
            Panel_C.Visible = false;
            UpdatePanel_C.Update();
            Panel_Recover.Visible = false;
            UpdatePanel_Recover.Update();
            Panel_Review.Visible = false;
            UpdatePanel_Review.Update();
        }
    }
    protected void GridView_WOmain_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void GridView_WOmain_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
    protected void GridView_WOmain_Load(object sender, EventArgs e)
    {

    }
    protected void GridView_WOmain_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView_WOmain.Rows.Count; i++)
        {
            for (int j = 0; j < GridView_WOmain.Rows[i].Cells.Count; j++)
            {
                GridView_WOmain.Rows[i].Cells[j].ToolTip = GridView_WOmain.Rows[i].Cells[j].Text;
                if (GridView_WOmain.Rows[i].Cells[j].Text.Length > 20)
                {
                    GridView_WOmain.Rows[i].Cells[j].Text = GridView_WOmain.Rows[i].Cells[j].Text.Substring(0, 20) + "...";
                }


            }
        }
    }

    protected void GridView_Error_DataBound(object sender, EventArgs e)
    {

    }

    protected void GridView_Error_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "cailiao")//材料检验
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_Error.SelectedIndex = row.RowIndex;
            label_M_WOEID.Text = e.CommandArgument.ToString();
            Panel_M.Visible = true;

            DataSet ds1 = erl.S_WOError(new Guid(label_M_WOEID.Text.Trim()));
            DataView dv1 = ds1.Tables[0].DefaultView;
            foreach (DataRowView datav in dv1)
            {
                TextBox_MM.Text = datav["WOE_MQCPeople"].ToString().Trim();
                TextBox_MT.Text = datav["WOE_MQCTime"].ToString().Trim() == "" ? "" : Convert.ToDateTime(datav["WOE_MQCTime"].ToString().Trim()).ToString("yyyy-MM-dd HH:mm");


                TextBox_MR.Text = datav["WOE_MQCResult"].ToString().Trim();
            }
            UpdatePanel_M.Update();



            //以下pannel隐藏

            //  Panel_ErrorList.Visible = false;
            //   UpdatePanel_ErrorList.Update();
            // Panel_M.Visible = false;
            // UpdatePanel_M.Update();
            Panel_Error.Visible = false;
            UpdatePanel_Error.Update();
            Panel_Track.Visible = false;
            UpdatePanel_Track.Update();
            Panel_C.Visible = false;
            UpdatePanel_C.Update();
            Panel_Recover.Visible = false;
            UpdatePanel_Recover.Update();
            Panel_Review.Visible = false;
            UpdatePanel_Review.Update();
            Panel_ReWork.Visible = false;
            UpdatePanel_ReWork.Update();
        }
        if (e.CommandName == "chuli")//处理
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_Error.SelectedIndex = row.RowIndex;
            label_ED_WOEID.Text = e.CommandArgument.ToString();
            Panel_Error.Visible = true;

            DataSet ds2 = erl.S_WOError(new Guid(label_ED_WOEID.Text.Trim()));
            DataView dv2 = ds2.Tables[0].DefaultView;
            foreach (DataRowView datav in dv2)
            {
                TextBox_DealMan.Text = datav["WOE_DealMan"].ToString().Trim();
                TextBox_DealTime.Text = datav["WOE_DealTime"].ToString().Trim() == "" ? "" : Convert.ToDateTime(datav["WOE_DealTime"].ToString().Trim()).ToString("yyyy-MM-dd HH:mm");
                TextBox_ReaAnalysis.Text = datav["WOE_ReaAnalysis"].ToString().Trim();
                TextBox_ProDeal.Text = datav["WOE_ProDeal"].ToString().Trim();
                TextBox_LongTimeMeasure.Text = datav["WOE_LongTimeMeasure"].ToString().Trim();
            }


            UpdatePanel_Error.Update();



            //以下pannel隐藏

            //   Panel_ErrorList.Visible = false;
            //   UpdatePanel_ErrorList.Update();
            Panel_M.Visible = false;
            UpdatePanel_M.Update();
            // Panel_Error.Visible = false;
            //  UpdatePanel_Error.Update();
            Panel_Track.Visible = false;
            UpdatePanel_Track.Update();
            Panel_C.Visible = false;
            UpdatePanel_C.Update();
            Panel_Recover.Visible = false;
            UpdatePanel_Recover.Update();
            Panel_Review.Visible = false;
            UpdatePanel_Review.Update();
            Panel_ReWork.Visible = false;
            UpdatePanel_ReWork.Update();

        }

        if (e.CommandName == "genzhong")//跟踪
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_Error.SelectedIndex = row.RowIndex;
            label_Track_WOEID.Text = e.CommandArgument.ToString();
            Panel_Track.Visible = true;

            DataSet ds3 = erl.S_WOError(new Guid(label_Track_WOEID.Text.Trim()));
            DataView dv3 = ds3.Tables[0].DefaultView;
            foreach (DataRowView datav in dv3)
            {
                TextBox_TrackMan.Text = datav["WOE_TrackMan"].ToString().Trim();
                TextBox_TrackTime.Text = datav["WOE_TrackTime"].ToString().Trim() == "" ? "" : Convert.ToDateTime(datav["WOE_TrackTime"].ToString().Trim()).ToString("yyyy-MM-dd HH:mm");
                TextBox_TrackResult.Text = datav["WOE_TrackResult"].ToString().Trim();

            }

            UpdatePanel_Track.Update();


            //以下pannel隐藏

            //  Panel_ErrorList.Visible = false;
            //  UpdatePanel_ErrorList.Update();
            Panel_M.Visible = false;
            UpdatePanel_M.Update();
            Panel_Error.Visible = false;
            UpdatePanel_Error.Update();
            // Panel_Track.Visible = false;
            // UpdatePanel_Track.Update();
            Panel_C.Visible = false;
            UpdatePanel_C.Update();
            Panel_Recover.Visible = false;
            UpdatePanel_Recover.Update();
            Panel_Review.Visible = false;
            UpdatePanel_Review.Update();
            Panel_ReWork.Visible = false;
            UpdatePanel_ReWork.Update();

        }

        if (e.CommandName == "sh")//审核
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_Error.SelectedIndex = row.RowIndex;
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string zl = al[1];
            if (zl.Trim() == "一级质量问题")
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('一级质量问题不需要审核！')", true);

                //以下pannel隐藏

                // Panel_ErrorList.Visible = false;
                // UpdatePanel_ErrorList.Update();
                Panel_M.Visible = false;
                UpdatePanel_M.Update();
                Panel_Error.Visible = false;
                UpdatePanel_Error.Update();
                Panel_Track.Visible = false;
                UpdatePanel_Track.Update();
                Panel_C.Visible = false;
                UpdatePanel_C.Update();
                Panel_Recover.Visible = false;
                UpdatePanel_Recover.Update();
                // Panel_Review.Visible = false;
                //  UpdatePanel_Review.Update();
                return;
            }
            label_SH_WOEID.Text = al[0];
            Panel_Review.Visible = true;


            DataSet ds4 = erl.S_WOError(new Guid(al[0].Trim()));
            DataView dv4 = ds4.Tables[0].DefaultView;
            foreach (DataRowView datav in dv4)
            {
                TextBox_ReviewMan.Text = datav["WOE_ReviewMan"].ToString().Trim();
                TextBox_ReviewTime.Text = datav["WOE_ReviewTime"].ToString().Trim() == "" ? "" : Convert.ToDateTime(datav["WOE_ReviewTime"].ToString().Trim()).ToString("yyyy-MM-dd HH:mm");
                TextBox_ReviewSuggestion.Text = datav["WOE_ReviewSuggestion"].ToString().Trim();
                if (datav["WOE_RResult"].ToString().Trim() == "")
                {
                    DropDownList_RResult.SelectedIndex = 0;
                }
                else
                {
                    DropDownList_RResult.SelectedValue = datav["WOE_RResult"].ToString().Trim();
                }
            }



            UpdatePanel_Review.Update();



            //以下pannel隐藏

            // Panel_ErrorList.Visible = false;
            // UpdatePanel_ErrorList.Update();
            Panel_M.Visible = false;
            UpdatePanel_M.Update();
            Panel_Error.Visible = false;
            UpdatePanel_Error.Update();
            Panel_Track.Visible = false;
            UpdatePanel_Track.Update();
            Panel_C.Visible = false;
            UpdatePanel_C.Update();
            Panel_Recover.Visible = false;
            UpdatePanel_Recover.Update();
            // Panel_Review.Visible = false;
            //  UpdatePanel_Review.Update();
            Panel_ReWork.Visible = false;
            UpdatePanel_ReWork.Update();

        }
        if (e.CommandName == "cs")//会签
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_Error.SelectedIndex = row.RowIndex;
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string zl = al[1];
            if (zl.Trim() != "三级质量问题")
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('一二级质量问题不需要会签！')", true);
                //以下pannel隐藏

                // Panel_ErrorList.Visible = false;
                //  UpdatePanel_ErrorList.Update();
                Panel_M.Visible = false;
                UpdatePanel_M.Update();
                Panel_Error.Visible = false;
                UpdatePanel_Error.Update();
                Panel_Track.Visible = false;
                UpdatePanel_Track.Update();
                // Panel_C.Visible = false;
                // UpdatePanel_C.Update();
                Panel_Recover.Visible = false;
                UpdatePanel_Recover.Update();
                Panel_Review.Visible = false;
                UpdatePanel_Review.Update();
                return;
            }

            label_CS_WOEID.Text = al[0];
            Panel_C.Visible = true;
            UpdatePanel_C.Update();



            //以下pannel隐藏

            // Panel_ErrorList.Visible = false;
            //  UpdatePanel_ErrorList.Update();
            Panel_M.Visible = false;
            UpdatePanel_M.Update();
            Panel_Error.Visible = false;
            UpdatePanel_Error.Update();
            Panel_Track.Visible = false;
            UpdatePanel_Track.Update();
            // Panel_C.Visible = false;
            // UpdatePanel_C.Update();
            Panel_Recover.Visible = false;
            UpdatePanel_Recover.Update();
            Panel_Review.Visible = false;
            UpdatePanel_Review.Update();
            Panel_ReWork.Visible = false;
            UpdatePanel_ReWork.Update();

        }
        if (e.CommandName == "recover")//结案
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_Error.SelectedIndex = row.RowIndex;
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            label_Recover_WOEID.Text = al[0];
            Panel_Recover.Visible = true;

            DataSet ds5 = erl.S_WOError(new Guid(al[0].Trim()));
            DataView dv5 = ds5.Tables[0].DefaultView;
            foreach (DataRowView datav in dv5)
            {
                TextBox_WOE_DoneMan.Text = datav["WOE_DoneMan"].ToString().Trim();
                TextBox_WOE_DoneTime.Text = datav["WOE_DoneTime"].ToString().Trim() == "" ? "" : Convert.ToDateTime(datav["WOE_DoneTime"].ToString().Trim()).ToString("yyyy-MM-dd HH:mm");
                TextBox_WOE_QCResult.Text = datav["WOE_QCResult"].ToString().Trim();
                TextBox_WOE_DoneResult.Text = datav["WOE_DoneResult"].ToString().Trim();

            }


            UpdatePanel_Recover.Update();



            //以下pannel隐藏

            // Panel_ErrorList.Visible = false;
            // UpdatePanel_ErrorList.Update();
            Panel_M.Visible = false;
            UpdatePanel_M.Update();
            Panel_Error.Visible = false;
            UpdatePanel_Error.Update();
            Panel_Track.Visible = false;
            UpdatePanel_Track.Update();
            Panel_C.Visible = false;
            UpdatePanel_C.Update();
            // Panel_Recover.Visible = false;
            //  UpdatePanel_Recover.Update();
            Panel_Review.Visible = false;
            UpdatePanel_Review.Update();
            Panel_ReWork.Visible = false;
            UpdatePanel_ReWork.Update();
        }


        if (e.CommandName == "Rework")//返工
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_Error.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            label_ReWork_WOEID.Text = al[0];
            Panel_ReWork.Visible = true;

            DataSet ds6 = erl.S_WOError(new Guid(al[0].Trim()));
            DataView dv6 = ds6.Tables[0].DefaultView;
            foreach (DataRowView datav in dv6)
            {
                TextBox_ReworkAppMan.Text = datav["WOE_ReworkAppMan"].ToString().Trim();
                TextBox_ReWorkTime.Text = datav["WOE_ReWorkTime"].ToString().Trim() == "" ? "" : Convert.ToDateTime(datav["WOE_ReWorkTime"].ToString().Trim()).ToString("yyyy-MM-dd HH:mm");
                DropDownList_ReworkOption.SelectedValue = datav["RWO_ID"].ToString().Trim();
                DropDownList_PBC.SelectedValue = datav["PBC_ID"].ToString().Trim();
                TextBox_ReWorkDate.Text = datav["WOE_ReWorkDate"].ToString().Trim() == "" ? "" : Convert.ToDateTime(datav["WOE_ReWorkDate"].ToString().Trim()).ToString("yyyy-MM-dd");
                TextBox_ReworkNum.Text = datav["WOE_ReworkNum"].ToString().Trim();
                TextBox_ReworkDetail.Text = datav["WOE_ReworkDetail"].ToString().Trim();

            }



            UpdatePanel_ReWork.Update();



            //以下pannel隐藏

            // Panel_ErrorList.Visible = false;
            // UpdatePanel_ErrorList.Update();
            Panel_M.Visible = false;
            UpdatePanel_M.Update();
            Panel_Error.Visible = false;
            UpdatePanel_Error.Update();
            Panel_Track.Visible = false;
            UpdatePanel_Track.Update();
            Panel_C.Visible = false;
            UpdatePanel_C.Update();
            Panel_Recover.Visible = false;
            UpdatePanel_Recover.Update();
            Panel_Review.Visible = false;
            UpdatePanel_Review.Update();
        }
    }

    protected void Btn_Review_Cancel_Click(object sender, EventArgs e)//异常审核取消
    {
        Panel_Review.Visible = false;
        TextBox_ReviewMan.Text = "";
        TextBox_ReviewTime.Text = "";
        DropDownList_RResult.SelectedIndex = 0;
        TextBox_ReviewSuggestion.Text = "";
        UpdatePanel_Review.Update();
    }
    protected void Btn_Review_Confirm_Click(object sender, EventArgs e)//异常审核确定
    {
        try
        {
            Guid woeid = new Guid(label_SH_WOEID.Text.Trim());
            string people = Session["UserName"].ToString().Trim();
            if (DropDownList_RResult.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请选择审核结果！')", true);
                return;
            }
            erl.U_WOError_Review(woeid, people, TextBox_ReviewSuggestion.Text.Trim(), DropDownList_RResult.SelectedItem.Text);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "confirm", "alert('制定成功！')", true);
            Panel_Review.Visible = false;

        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('制定失败！')", true);
            return;

        }
    }
    protected void Btn_Rework_Confirm_Click(object sender, EventArgs e)//返工确定
    {
        DateTime reworkdate;
        int num;
        //try
        //{
        Guid woeid = new Guid(label_ReWork_WOEID.Text.Trim());
        string people = Session["UserName"].ToString().Trim();
        if (DropDownList_PBC.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请选择返工工序！')", true);
            return;
        }
        if (DropDownList_ReworkOption.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请选择返工原因选项！')", true);
            return;
        }

        Guid pbcid = new Guid(DropDownList_PBC.SelectedValue.ToString().Trim());
        Guid rwoid = new Guid(DropDownList_ReworkOption.SelectedValue.ToString().Trim());
        if (TextBox_ReWorkDate.Text.Trim() == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请选择返工日期！')", true);
            return;
        }
        else
        {
            reworkdate = Convert.ToDateTime(TextBox_ReWorkDate.Text.Trim());
        }
        try
        {
            num = Convert.ToInt32(TextBox_ReworkNum.Text.Trim());
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('返工数量不能为空且必须为整数形式！')", true);
            return;
        }

        erl.U_WOError_Rework(woeid, pbcid, people, rwoid, reworkdate, num, TextBox_ReworkDetail.Text.Trim());
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "confirm", "alert('制定成功！')", true);
        Panel_Review.Visible = false;

        //}
        //catch (Exception)
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('制定失败！')", true);
        //    return;

        //}

    }
    protected void Btn_Rework_Cancel_Click(object sender, EventArgs e)//返工取消
    {
        Panel_ReWork.Visible = false;
        TextBox_ReworkAppMan.Text = "";
        TextBox_ReWorkTime.Text = "";
        DropDownList_ReworkOption.SelectedIndex = 0;
        DropDownList_PBC.SelectedIndex = 0;
        TextBox_ReWorkDate.Text = "";
        TextBox_ReworkNum.Text = "";
        TextBox_ReworkDetail.Text = "";

    }
}