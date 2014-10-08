using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class WorkOrderSalary_SalaryDayCalculate : Page
{
    WOSSalaryL wosl = new WOSSalaryL();
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
                Title = "计时计件日核算查看";
                GridView_WOmain.Columns[6].Visible = false;
                GridView_WOmain.Columns[10].Visible = false;
                GridView_WOmain.Columns[11].Visible = false;
                Button_Add.Visible = false;
                GridView2.Columns[7].Visible = false;
                GridView3.Columns[9].Visible = false;
                GridView_NoRelated.Columns[7].Visible = false;
             

            }
            if (state.Trim() == "review")
            {
                Title = "计时计件日核算审核";
                GridView_WOmain.Columns[6].Visible = false;
               // this.GridView_WOmain.Columns[10].Visible = false;
               // this.GridView_WOmain.Columns[11].Visible = false;
                Button_Add.Visible = false;
                GridView2.Columns[7].Visible = false;
                GridView3.Columns[9].Visible = false;
                GridView_NoRelated.Columns[7].Visible = false;

            }

            if (state.Trim() == "manage")
            {
                Title = "计时计件日核算制定";
               // this.GridView_WOmain.Columns[6].Visible = false;
                GridView_WOmain.Columns[10].Visible = false;
                GridView_WOmain.Columns[11].Visible = false;
               // this.Button_Add.Visible = false;
                //GridView2.Columns[7].Visible = false;
                //GridView3.Columns[9].Visible = false;
               // GridView_NoRelated.Columns[7].Visible = false;
            }
            if (!IsPostBack)
            {
                try
                {
                    //this.DropDownList_PBC.DataSource = erl.S_WOError_Rework_PBCraft();
                    //this.DropDownList_PBC.DataTextField = "PBC_Name";
                    //this.DropDownList_PBC.DataValueField = "PBC_ID";
                    //this.DropDownList_PBC.DataBind();
                    if (!((Session["UserRole"].ToString().Contains("计时计件日核算制定")) || (Session["UserRole"].ToString().Contains("计时计件日核算审核")) || (Session["UserRole"].ToString().Contains("计时计件日核算查看"))))
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('可能您没有权限操作和查看本页面，请退出选择其他账号登陆，或联系管理员！')", true);

                        Response.Redirect("~/Default.aspx");

                    }
                    if (!((Session["UserRole"].ToString().Contains("计时计件日核算制定")) || (Session["UserRole"].ToString().Contains("计时计件日核算审核"))))
                    {
                       
                        GridView_WOmain.Columns[6].Visible = false;
                        GridView_WOmain.Columns[10].Visible = false;
                        GridView_WOmain.Columns[11].Visible = false;
                        Button_Add.Visible = false;
                        GridView2.Columns[7].Visible = false;
                        GridView3.Columns[9].Visible = false;
                        GridView_NoRelated.Columns[7].Visible = false;
                    }
                    if (!(Session["UserRole"].ToString().Contains("计时计件日核算制定")))
                    {

                        GridView_WOmain.Columns[6].Visible = false;
                        // this.GridView_WOmain.Columns[10].Visible = false;
                        // this.GridView_WOmain.Columns[11].Visible = false;
                        Button_Add.Visible = false;
                        GridView2.Columns[7].Visible = false;
                        GridView3.Columns[9].Visible = false;
                        GridView_NoRelated.Columns[7].Visible = false;

                    }
                    

                    label_GridPageState.Text = "默认数据源";
                    label_GridPageState_Piece.Text = "默认数据源";
                    label_GridPageState_Piece2.Text = "默认数据源";
                    label_GridPageState3.Text = "默认数据源";
                    string condition = " and 1=1";
                    GridView_WOmain.DataSource = wosl.S_WorkTimePiece_ByProDept(condition);
                    GridView_WOmain.DataBind();
                    UpdatePanel_WOmain.Update();
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
        string WTP_TimeRState = DropDownList_TimeState.SelectedItem.Text.Trim() == "请选择" ? " and 1=1 " : " and WTP_TimeRState = '" + DropDownList_TimeState.SelectedItem.Text.Trim() + "' ";
        string WTP_PieceRState = DropDownList_PieceState.SelectedItem.Text.Trim() == "请选择" ? " and 1=1 " : " and WTP_PieceRState = '" + DropDownList_PieceState.SelectedItem.Text.Trim() + "' ";
        if ((TextBox_calculate_Time1.Text != "" && TextBox_calculate_Time2.Text == "") || (TextBox_calculate_Time1.Text == "" && TextBox_calculate_Time2.Text != ""))
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请将时间检索范围输入完整，请您再次核对！')", true);
            return;
        }
        string WTP_Date = (TextBox_calculate_Time1.Text.Trim() == "" && TextBox_calculate_Time2.Text.Trim() == "") ? " and 1=1 " : " and WTP_Date between   ' " + TextBox_calculate_Time1.Text.Trim() + "' and ' " + TextBox_calculate_Time2.Text.Trim() + "'";



        condition = WTP_TimeRState + WTP_PieceRState + WTP_Date;
        GridView_WOmain.DataSource = wosl.S_WorkTimePiece_ByProDept(condition);
        GridView_WOmain.DataBind();
        UpdatePanel_WOmain.Update();

    }

    protected void Btn_Search_Click(object sender, EventArgs e)
    {
        label_GridPageState.Text = "检索数据源";
        databind();
    }
    protected void Button_Cancel_Click(object sender, EventArgs e)
    {
        label_GridPageState.Text = "默认数据源";
        //初值化
        //  DropDownList_PBC.SelectedIndex = 0;
        DropDownList_TimeState.SelectedIndex = 0;
        DropDownList_PieceState.SelectedIndex = 0;
        //  TextBox_Reviewpeople.Text = "";
        //  TextBox_Review_Time1.Text = "";
        //  TextBox_Review_Time2.Text = "";
        TextBox_calculate_Time1.Text = "";
        TextBox_calculate_Time2.Text = "";
        databind();
    }
    public void DataBind1()
    {
        label_GridPageState_Piece.Text = "检索数据源";
        string condition;
        string WO_ProType = TextBox_PT1.Text.Trim() == "" ? " and 1=1 " : " and WO_ProType like '%" + TextBox_PT1.Text.Trim() + "%' ";
        string LCS_Name = TextBox_PS1.Text.Trim() == "" ? " and 1=1 " : " and LCS_Name like '%" + TextBox_PS1.Text.Trim() + "%' ";
        string PBC_Name = TextBox_PBC1.Text.Trim() == "" ? " and 1=1 " : " and PBC_Name like '%" + TextBox_PBC1.Text.Trim() + "%' ";
        string HRDD_Name = TextBox_Name1.Text.Trim() == "" ? " and 1=1 " : " and HRDD_Name like '%" + TextBox_Name1.Text.Trim() + "%' ";
        string HRDD_StaffNO = TextBox_gonghao1.Text.Trim() == "" ? " and 1=1 " : " and HRDD_StaffNO like '%" + TextBox_gonghao1.Text.Trim() + "%' ";
        condition = WO_ProType + LCS_Name + PBC_Name + HRDD_Name + HRDD_StaffNO;

        GridView_Piece.DataSource = wosl.S_OperatorInfo(condition, Label_Date.Text.Trim());
        GridView_Piece.DataBind();
        UpdatePanel_Piece.Update();

       // this.GridView_WOmain.DataSource = wosl.S_WorkTimePiece_ByProDept(condition);
      //  this.GridView_WOmain.DataBind();
       // this.UpdatePanel_WOmain.Update();
    
    }
    public void DataBind2()
    {
        label_GridPageState_Piece2.Text = "检索数据源";
        string condition;
        string WO_ProType = TextBox_PT2.Text.Trim() == "" ? " and 1=1 " : " and WO_ProType like '%" + TextBox_PT2.Text.Trim() + "%' ";
        string STI_Name = TextBox_Project.Text.Trim() == "" ? " and 1=1 " : " and STI_Name like '%" + TextBox_Project.Text.Trim() + "%' ";
        string PBC_Name = TextBox_PBC2.Text.Trim() == "" ? " and 1=1 " : " and PBC_Name like '%" + TextBox_PBC2.Text.Trim() + "%' ";
        string HRDD_Name = TextBox_Name2.Text.Trim() == "" ? " and 1=1 " : " and HRDD_Name like '%" + TextBox_Name2.Text.Trim() + "%' ";
        string HRDD_StaffNO = TextBox_gonghao2.Text.Trim() == "" ? " and 1=1 " : " and HRDD_StaffNO like '%" + TextBox_gonghao2.Text.Trim() + "%' ";
        condition = WO_ProType + STI_Name + PBC_Name + HRDD_Name + HRDD_StaffNO;

        GridView_Time.DataSource = wosl.S_OTime(condition, Label_Date2.Text.Trim());
        GridView_Time.DataBind();
        UpdatePanel_Time.Update();

        // this.GridView_WOmain.DataSource = wosl.S_WorkTimePiece_ByProDept(condition);
        //  this.GridView_WOmain.DataBind();
        // this.UpdatePanel_WOmain.Update();

    }

    public void DataBind3()
    {
        label_GridPageState3.Text = "检索数据源";
        string condition;
        //string WO_ProType = this.TextBox_PT3.Text.Trim() == "" ? " and 1=1 " : " and WO_ProType like '%" + this.TextBox_PT3.Text.Trim() + "%' ";
        string STI_Name = TextBox_Project3.Text.Trim() == "" ? " and 1=1 " : " and STI_Name like '%" + TextBox_Project3.Text.Trim() + "%' ";
        string PBC_Name = TextBox_PBC3.Text.Trim() == "" ? " and 1=1 " : " and PBC_Name like '%" + TextBox_PBC3.Text.Trim() + "%' ";
        string HRDD_Name = TextBox_Name3.Text.Trim() == "" ? " and 1=1 " : " and HRDD_Name like '%" + TextBox_Name3.Text.Trim() + "%' ";
        string HRDD_StaffNO = TextBox_gonghao3.Text.Trim() == "" ? " and 1=1 " : " and HRDD_StaffNO like '%" + TextBox_gonghao3.Text.Trim() + "%' ";
        condition =  STI_Name + PBC_Name + HRDD_Name + HRDD_StaffNO;

    //    GridView_Time.DataSource = wosl.S_OTime(condition, this.Label_Date2.Text.Trim());
        GridView_NoRelated.DataSource = wosl.S_OTime_OT_NORelated(condition, Label_Date3.Text.Trim());
        GridView_NoRelated.DataBind();
        UpdatePanel_NoRelated.Update();

        // this.GridView_WOmain.DataSource = wosl.S_WorkTimePiece_ByProDept(condition);
        //  this.GridView_WOmain.DataBind();
        // this.UpdatePanel_WOmain.Update();

    }

    protected void Btn_Search1_Click(object sender, EventArgs e)
    {
       
        DataBind1();
    }
    protected void Button_Cancel1_Click(object sender, EventArgs e)
    {
        TextBox_PT1.Text = "";
        TextBox_PS1.Text = "";
        TextBox_PBC1.Text = "";
        TextBox_Name1.Text = "";
        TextBox_gonghao1.Text = "";
        DataBind1();
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
        GridView_WOmain.PageIndex = newPageIndex;


        if (label_GridPageState.Text == "默认数据源")
        {
            string condition = " and 1=1";
            GridView_WOmain.DataSource = wosl.S_WorkTimePiece_ByProDept(condition);
            GridView_WOmain.DataBind();
            UpdatePanel_WOmain.Update();
        }
        if (label_GridPageState.Text == "检索数据源")
        {
            databind();
        }
        Panel_Piece.Visible = false;
        UpdatePanel_Piece.Update();
        Panel_Time.Visible = false;
        UpdatePanel_Time.Update();
        Panel_Sign.Visible = false;
        UpdatePanel_Sign.Update();
        Panel1.Visible = false;
        UpdatePanel1.Update();
        Panel2.Visible = false;
        UpdatePanel2.Update();
        Panel3.Visible = false;
        UpdatePanel3.Update();
    }
    protected void GridView_WOmain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "CheckPiece")//
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_WOmain.SelectedIndex = row.RowIndex;
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            Label_Date.Text = al[1];
            Label_WTP_ID.Text = al[0];
            Label_scjj.Text = al[2];
            Label_rsjj.Text = al[3];



            //panel 各种隐藏
            Panel_Piece.Visible = true;
            UpdatePanel_Piece.Update();
            Panel_Time.Visible = false;
            Panel_Sign.Visible = false;
            UpdatePanel_Sign.Update();
            GridView_Piece.DataSource = wosl.S_OperatorInfo("", al[1].Trim());
            GridView_Piece.DataBind();
            UpdatePanel_Time.Update();
            Panel_NoRelated.Visible = false;
            UpdatePanel_NoRelated.Update();
            Panel1.Visible = false;
            UpdatePanel1.Update();
            Panel2.Visible = false;
            UpdatePanel2.Update();
            Panel3.Visible = false;
            UpdatePanel3.Update();
        }

        if (e.CommandName == "HRReview")//
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_WOmain.SelectedIndex = row.RowIndex;
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            label1.Text = al[1];
            label_WTPID_ForHR.Text = al[0];
            //panel 各种隐藏
            Panel_Piece.Visible = false;
            UpdatePanel_Piece.Update();
            Panel_Time.Visible = false;
            Panel_Sign.Visible = false;
            UpdatePanel_Sign.Update();
            UpdatePanel_Time.Update();
            Panel_NoRelated.Visible = false;
            UpdatePanel_NoRelated.Update();
            Panel1.Visible = true;
            string condition = " and WTP_ID='"+al[0].Trim()+"'";
            GridView1.DataSource = wosl.S_WorkTimePiece_ByProDept(condition);
            GridView1.DataBind();
            UpdatePanel1.Update();
            Panel2.Visible = false;
            UpdatePanel2.Update();
            Panel3.Visible = false;
            UpdatePanel3.Update();
        }



        if (e.CommandName == "CheckNoRelevantTime")//
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_WOmain.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            Label_Date3.Text = al[1];
            Label_WTP_ID3.Text = al[0];
            Label_scjs.Text = al[2];
            Label_rsjs.Text = al[3];
            //panel 各种隐藏
            Panel_Piece.Visible = false;
            UpdatePanel_Piece.Update();
            Panel_Time.Visible = false;
            Panel_NoRelated.Visible = true;
            UpdatePanel_Time.Update();
            Panel_Sign.Visible = false;
            UpdatePanel_Sign.Update();
            GridView_NoRelated.DataSource = wosl.S_OTime_OT_NORelated("", al[1].Trim());
            GridView_NoRelated.DataBind();
            UpdatePanel_NoRelated.Update();
            Panel1.Visible = false;
            UpdatePanel1.Update();
            Panel2.Visible = false;
            UpdatePanel2.Update();
            Panel3.Visible = false;
            UpdatePanel3.Update();
        }

        if (e.CommandName == "CheckTime")//
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_WOmain.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            Label_Date2.Text = al[1];
            Label_WTP_ID2.Text = al[0];
            Label_scjs.Text = al[2];
            Label_rsjs.Text = al[3];
            //panel 各种隐藏
            Panel_Piece.Visible = false;
            UpdatePanel_Piece.Update();
            Panel_Time.Visible = true;
            Panel_NoRelated.Visible = false;
            UpdatePanel_NoRelated.Update();
            Panel_Sign.Visible = false;
            UpdatePanel_Sign.Update();
            GridView_Time.DataSource = wosl.S_OTime("", al[1].Trim());
            GridView_Time.DataBind();
            UpdatePanel_Time.Update();
            Panel1.Visible = false;
            UpdatePanel1.Update();
            Panel2.Visible = false;
            UpdatePanel2.Update();
            Panel3.Visible = false;
            UpdatePanel3.Update();
        }

        if (e.CommandName == "ReviewPiece")//
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_WOmain.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            Label_Date4.Text = al[1];
            Label_TimeOrPiece.Text = "计件信息";
            Label_WTP_ID4.Text = al[0];
            //panel 各种隐藏
            Panel1.Visible = false;
            UpdatePanel1.Update();
            Panel2.Visible = false;
            UpdatePanel2.Update();
            Panel3.Visible = false;
            UpdatePanel3.Update();
            Panel_Piece.Visible = false;
            UpdatePanel_Piece.Update();
            Panel_Time.Visible = false;
            Panel_NoRelated.Visible = false;
            UpdatePanel_NoRelated.Update();
            UpdatePanel_Time.Update();
            Panel_Sign.Visible = true;
            UpdatePanel_Sign.Update();
            DataSet ds =wosl.S_WorkTimePiece_ByID(new Guid(al[0].Trim()));
            DataView dv = ds.Tables[0].DefaultView;
            foreach (DataRowView datav in dv)
            {
                TB_Reviewman.Text = datav["WTP_PRMan"].ToString();
                TB_RevieTime.Text = datav["WTP_PRTime"].ToString();
                TB_yijian.Text = datav["WTP_PSuggestion"].ToString();
            
            }
           
        }

        if (e.CommandName == "ReviewTime")//
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_WOmain.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            Label_Date4.Text = al[1];
            Label_TimeOrPiece.Text = "计时信息";
            Label_WTP_ID4.Text = al[0];
            //panel 各种隐藏
            Panel_Piece.Visible = false;
            UpdatePanel_Piece.Update();
            Panel_Time.Visible = false;
            Panel_NoRelated.Visible = false;
            UpdatePanel_NoRelated.Update();
            UpdatePanel_Time.Update();
            Panel_Sign.Visible = true;
            UpdatePanel_Sign.Update();
            Panel1.Visible = false;
            UpdatePanel1.Update();
            Panel2.Visible = false;
            UpdatePanel2.Update();
            Panel3.Visible = false;
            UpdatePanel3.Update();
            DataSet ds = wosl.S_WorkTimePiece_ByID(new Guid(al[0].Trim()));
            DataView dv = ds.Tables[0].DefaultView;
            foreach (DataRowView datav in dv)
            {
                TB_Reviewman.Text = datav["WTP_TRMan"].ToString();
                TB_RevieTime.Text = datav["WTP_TRTime"].ToString();
                TB_yijian.Text = datav["WTP_TSuggestion"].ToString();

            }

        }

        if (e.CommandName == "DeleteWTP")//
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_WOmain.SelectedIndex = row.RowIndex;
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            string WTP_ID = al[0].Trim();
            if (al[1].Trim() == "通过" && al[2].Trim() == "通过")
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('计件、计时信息均已审核通过，无法删除！')", true);
                return;
            }
            if (al[1].Trim() == "通过")
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('计件信息已审核通过，无法删除！')", true);
                return;
            }
            if (al[2].Trim() == "通过")
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('计时信息已审核通过，无法删除！')", true);
                return;
            }
            wosl.D_WorkTimePiece_ByProDept(new Guid(WTP_ID));
            //panel 各种隐藏
            Panel_NoRelated.Visible = false;
            UpdatePanel_NoRelated.Update();
            Panel_Piece.Visible = false;
            UpdatePanel_Piece.Update();
            Panel_Time.Visible = false;
            Panel_Sign.Visible = false;
            Panel1.Visible = false;
            UpdatePanel1.Update();
            Panel2.Visible = false;
            UpdatePanel2.Update();
            UpdatePanel_Sign.Update();
            databind();
        }

    }

    protected void GridView_Time_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;
        GridView_Time.SelectedIndex = -1;
        if (-1 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;

            GridViewRow pagerRow = GridView_Time.BottomPagerRow;


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
        newPageIndex = newPageIndex >= GridView_Time.PageCount ? GridView_Time.PageCount - 1 : newPageIndex;
        GridView_Time.PageIndex = newPageIndex;
        GridView_Time.PageIndex = newPageIndex;

        if (label_GridPageState_Piece2.Text == "默认数据源")
        {
            GridView_Time.DataSource = wosl.S_OTime("", Label_Date2.Text.Trim());
            GridView_Time.DataBind();
            UpdatePanel_Time.Update();
        }
        if (label_GridPageState_Piece2.Text == "检索数据源")
        {
            DataBind2();
        }
        Panel_Piece.Visible = false;
        UpdatePanel_Piece.Update();
        Panel_NoRelated.Visible = false;
        UpdatePanel_NoRelated.Update();
     //   Panel_Time.Visible = false;
       // UpdatePanel_Time.Update();
        Panel_Sign.Visible = false;
        UpdatePanel_Sign.Update();
        Panel1.Visible = false;
        UpdatePanel1.Update();
        Panel2.Visible = false;
        UpdatePanel2.Update();
        Panel3.Visible = false;
        UpdatePanel3.Update();
    }
    protected void Btn_Search2_Click(object sender, EventArgs e)
    {
        DataBind2();
    }
    protected void Button_Cancel2_Click(object sender, EventArgs e)
    {
        TextBox_PT2.Text = "";
        TextBox_Project.Text = "";
        TextBox_PBC2.Text = "";
        TextBox_Name2.Text = "";
        TextBox_gonghao2.Text = "";
        DataBind2();
    }
    protected void GridView_Piece_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;
        GridView_Piece.SelectedIndex = -1;
        if (-1 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;

            GridViewRow pagerRow = GridView_Piece.BottomPagerRow;


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
        newPageIndex = newPageIndex >= GridView_Piece.PageCount ? GridView_Piece.PageCount - 1 : newPageIndex;
        GridView_Piece.PageIndex = newPageIndex;
        GridView_Piece.PageIndex = newPageIndex;

        if (label_GridPageState_Piece.Text == "默认数据源")
        {
            GridView_Piece.DataSource = wosl.S_OperatorInfo("", Label_Date.Text.Trim());
            GridView_Piece.DataBind();
            UpdatePanel_Piece.Update();
        }
        if (label_GridPageState_Piece.Text == "检索数据源")
        {
            DataBind1();
        }
       // Panel_Piece.Visible = true;
      //  UpdatePanel_Piece.Update();
        Panel_Time.Visible = false;
        UpdatePanel_Time.Update();
        Panel_NoRelated.Visible = false;
        UpdatePanel_NoRelated.Update();
        Panel_Sign.Visible = false;
        UpdatePanel_Sign.Update();
        Panel1.Visible = false;
        UpdatePanel1.Update();
        Panel2.Visible = false;
        UpdatePanel2.Update();
        Panel3.Visible = false;
        UpdatePanel3.Update();
    }
    protected void Button_Add_Submit_Click(object sender, EventArgs e)
    {

        string condition = " and WTP_Date='" + TextBox_calculate_Time_Add.Text.Trim() + "'";
        DataSet ds = wosl.S_WorkTimePiece_ByProDept(condition);
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count != 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('系统中已有该日期信息，请您再次核对！')", true);
            return;
        }
        else
        {

            DateTime t = Convert.ToDateTime(TextBox_calculate_Time_Add.Text.Trim());
            wosl.I_WorkTimePiece_ByProDept(t);
            Panel_Add.Visible = false;
            databind();
            TextBox_calculate_Time_Add.Text = "";
        }
    }
    protected void Button_Add_Click(object sender, EventArgs e)
    {
        TextBox_calculate_Time_Add.Text = "";
        Panel_Add.Visible = true;
        UpdatePanel_Add.Update();
        Panel_Piece.Visible = false;
        UpdatePanel_Piece.Update();
        Panel_Time.Visible = false;
        UpdatePanel_Time.Update();
        Panel_NoRelated.Visible = false;
        Panel_Sign.Visible = false;
        UpdatePanel_Sign.Update();
        UpdatePanel_NoRelated.Update();
        Panel1.Visible = false;
        UpdatePanel1.Update();
        Panel2.Visible = false;
        UpdatePanel2.Update();
        Panel3.Visible = false;
        UpdatePanel3.Update();
    }
    protected void Button_Add_Cancel_Click(object sender, EventArgs e)
    {
        Panel_Add.Visible = false;
        TextBox_calculate_Time_Add.Text = "";
        UpdatePanel_Add.Update();
    }

    protected void GridView_NoRelated_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void Button_search3_Click(object sender, EventArgs e)
    {
        DataBind3();
    }
    protected void Button_Cancel3_Click(object sender, EventArgs e)
    {
        //TextBox_PT3.Text = "";
        TextBox_Project3.Text = "";
        TextBox_PBC3.Text = "";
        TextBox_Name3.Text = "";
        TextBox_gonghao3.Text = "";
        DataBind3();
    }

    protected void BT_TKOK_Click(object sender, EventArgs e)
    {
        if (Label_TimeOrPiece.Text.Trim() == "计件信息")
        {

            try
            {
                wosl.U_WorkTimePiece_PReview(new Guid(Label_WTP_ID4.Text.Trim()), Session["UserName"].ToString(), TB_yijian.Text.Trim(), "通过");
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核失败！')", true);
                return;
            }
            Panel_Sign.Visible = false;
            UpdatePanel_Sign.Update();
            databind();
        }
        if (Label_TimeOrPiece.Text.Trim() == "计时信息")
        {
            try
            {
                wosl.U_WorkTimePiece_TReview(new Guid(Label_WTP_ID4.Text.Trim()), Session["UserName"].ToString(), TB_yijian.Text.Trim(), "通过");
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核失败！')", true);
                return;
            }
            Panel_Sign.Visible = false;
            UpdatePanel_Sign.Update();
            databind();
        }


    }
    protected void BT_TKNotOK_Click(object sender, EventArgs e)
    {
        if (Label_TimeOrPiece.Text.Trim() == "计件信息")
        {
            try
            {
                wosl.U_WorkTimePiece_PReview(new Guid(Label_WTP_ID4.Text.Trim()), Session["UserName"].ToString(), TB_yijian.Text.Trim(), "不通过");
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核失败！')", true);
                return;
            }
            Panel_Sign.Visible = false;
            UpdatePanel_Sign.Update();
            databind();
        }

        if (Label_TimeOrPiece.Text.Trim() == "计时信息")
        {
            try
            {
                wosl.U_WorkTimePiece_TReview(new Guid(Label_WTP_ID4.Text.Trim()), Session["UserName"].ToString(), TB_yijian.Text.Trim(), "不通过");
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核失败！')", true);
                return;
            }
            Panel_Sign.Visible = false;
            UpdatePanel_Sign.Update();
            databind();
        }
    }
    protected void BT_TKCanel_Click(object sender, EventArgs e)
    {
        Panel_Sign.Visible = false;
        TB_RevieTime.Text = "";
        TB_Reviewman.Text = "";
        TB_yijian.Text = "";
        UpdatePanel_Sign.Update();
    }

    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            for (int j = 0; j < GridView1.Rows[i].Cells.Count; j++)
            {
                GridView1.Rows[i].Cells[j].ToolTip = GridView1.Rows[i].Cells[j].Text;
                if (GridView1.Rows[i].Cells[j].Text.Length > 15)
                {
                    GridView1.Rows[i].Cells[j].Text = GridView1.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }


            }
        }
    }
    protected void GridView_Piece_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView_Piece.EditIndex = e.NewEditIndex;
        //panel 各种隐藏
        Panel_Piece.Visible = true;
        UpdatePanel_Piece.Update();
        Panel_Time.Visible = false;
        Panel_Sign.Visible = false;
        UpdatePanel_Sign.Update();
        //绑定
        GridView_Piece.DataSource = wosl.S_OperatorInfo("", Label_Date.Text.Trim());
        GridView_Piece.DataBind();
        UpdatePanel_Time.Update();
        Panel_NoRelated.Visible = false;
        UpdatePanel_NoRelated.Update();
        Panel1.Visible = false;
        UpdatePanel1.Update();
        Panel2.Visible = false;
        UpdatePanel2.Update();
        Panel3.Visible = false;
        UpdatePanel3.Update();

    }
    protected void GridView_Piece_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }
    protected void GridView_Piece_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView_Piece.SelectedIndex = -1;
        GridView_Piece.EditIndex = -1;
        //panel 各种隐藏
        Panel_Piece.Visible = true;
        UpdatePanel_Piece.Update();
        Panel_Time.Visible = false;
        Panel_Sign.Visible = false;
        UpdatePanel_Sign.Update();
        //绑定
        GridView_Piece.DataSource = wosl.S_OperatorInfo("", Label_Date.Text.Trim());
        GridView_Piece.DataBind();
        UpdatePanel_Time.Update();
        Panel_NoRelated.Visible = false;
        UpdatePanel_NoRelated.Update();
        Panel1.Visible = false;
        UpdatePanel1.Update();
        Panel2.Visible = false;
        UpdatePanel2.Update();
        Panel3.Visible = false;
        UpdatePanel3.Update();
    }
    protected void GridView_Time_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView_Time.EditIndex = e.NewEditIndex;
        //panel 各种隐藏
        Panel_Piece.Visible = false;
        UpdatePanel_Piece.Update();
        Panel_Time.Visible = true;
        Panel_NoRelated.Visible = false;
        UpdatePanel_NoRelated.Update();
        Panel_Sign.Visible = false;
        UpdatePanel_Sign.Update();
        GridView_Time.DataSource = wosl.S_OTime("", Label_Date2.Text.Trim());
        GridView_Time.DataBind();
        UpdatePanel_Time.Update();
        Panel1.Visible = false;
        UpdatePanel1.Update();
        Panel2.Visible = false;
        UpdatePanel2.Update();
        Panel3.Visible = false;
        UpdatePanel3.Update();
    }
    protected void GridView_Time_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView_Time.SelectedIndex = -1;
        GridView_Time.EditIndex = -1;
        //panel 各种隐藏
        Panel_Piece.Visible = false;
        UpdatePanel_Piece.Update();
        Panel_Time.Visible = true;
        Panel_NoRelated.Visible = false;
        UpdatePanel_NoRelated.Update();
        Panel_Sign.Visible = false;
        UpdatePanel_Sign.Update();
        GridView_Time.DataSource = wosl.S_OTime("", Label_Date2.Text.Trim());
        GridView_Time.DataBind();
        UpdatePanel_Time.Update();
        Panel1.Visible = false;
        UpdatePanel1.Update();
        Panel2.Visible = false;
        UpdatePanel2.Update();
        Panel3.Visible = false;
        UpdatePanel3.Update();
    }
    protected void GridView_Time_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }
    protected void GridView_NoRelated_RowEditing(object sender, GridViewEditEventArgs e)
    {

        if (Label_scjs.Text.Trim() == "通过" && Label_rsjs.Text.Trim() == "通过")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('生产部或人事部计时信息均已审核通过，无法修改！')", true);
            return;

        }
        GridView_NoRelated.EditIndex = e.NewEditIndex;
        //panel 各种隐藏
        Panel_Piece.Visible = false;
        UpdatePanel_Piece.Update();
        Panel_Time.Visible = false;
        Panel_NoRelated.Visible = true;
        UpdatePanel_Time.Update();
        Panel_Sign.Visible = false;
        UpdatePanel_Sign.Update();
        GridView_NoRelated.DataSource = wosl.S_OTime_OT_NORelated("",Label_Date3.Text.Trim());
        GridView_NoRelated.DataBind();
        UpdatePanel_NoRelated.Update();
        Panel1.Visible = false;
        UpdatePanel1.Update();
        Panel2.Visible = false;
        UpdatePanel2.Update();
        Panel3.Visible = false;
        UpdatePanel3.Update();
    }
    protected void GridView_NoRelated_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView_NoRelated.SelectedIndex = -1;
        GridView_NoRelated.EditIndex = -1;
        //panel 各种隐藏
        Panel_Piece.Visible = false;
        UpdatePanel_Piece.Update();
        Panel_Time.Visible = false;
        Panel_NoRelated.Visible = true;
        UpdatePanel_Time.Update();
        Panel_Sign.Visible = false;
        UpdatePanel_Sign.Update();
        GridView_NoRelated.DataSource = wosl.S_OTime_OT_NORelated("", Label_Date3.Text.Trim());
        GridView_NoRelated.DataBind();
        UpdatePanel_NoRelated.Update();
        Panel1.Visible = false;
        UpdatePanel1.Update();
        Panel2.Visible = false;
        UpdatePanel2.Update();
        Panel3.Visible = false;
        UpdatePanel3.Update();
    }
    protected void GridView_Piece_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditPiece")//
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_Piece.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            label2.Text = al[1].Trim() + " " + al[2].Trim() + "工序 ";
            label_PBCID.Text = al[0];
            label_WOPT.Text=al[3];
            label_HRDDID1.Text = al[4];
            //panel 各种隐藏
            Panel_Piece.Visible = true;
            UpdatePanel_Piece.Update();
            Panel_Time.Visible = false;
            Panel_Sign.Visible = false;
            UpdatePanel_Sign.Update();
            //绑定
            UpdatePanel_Time.Update();
            Panel_NoRelated.Visible = false;
            UpdatePanel_NoRelated.Update();
            Panel1.Visible = false;
            UpdatePanel1.Update();
            GridView2.DataSource = wosl.S_OperatorInfo_WorkOrder_ForOne(new Guid(label_PBCID.Text.Trim()), Label_Date.Text.Trim(), al[3].Trim(), new Guid(al[4].Trim()));
            GridView2.DataBind();
            Panel2.Visible = true;
            UpdatePanel2.Update();
            Panel3.Visible = false;
            UpdatePanel3.Update();
        }
    }
    protected void GridView_Time_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditTime")//
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_Piece.SelectedIndex = row.RowIndex;

            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            label4.Text = al[1].Trim() + " " + al[2].Trim() + " 计时项目 ";
           // this.label_PBCID.Text = al[0];
            label_al0.Text = al[0];
            label_al3.Text = al[3];
            label_al4.Text = al[4];

            //panel 各种隐藏
            Panel_Piece.Visible = false;
            UpdatePanel_Piece.Update();
            Panel_Time.Visible = true;
            Panel_Sign.Visible = false;
            UpdatePanel_Sign.Update();
            //绑定
            UpdatePanel_Time.Update();
            Panel_NoRelated.Visible = false;
            UpdatePanel_NoRelated.Update();
            Panel1.Visible = false;
            UpdatePanel1.Update();
            GridView3.DataSource = wosl.S_OTime_WorkOrder_ForOne(new Guid(al[0].Trim()), Label_Date2.Text.Trim(), al[3].Trim(), new Guid(al[4].Trim()));
            GridView3.DataBind();
            Panel2.Visible = false;
            UpdatePanel2.Update();
            Panel3.Visible = true;
            UpdatePanel3.Update();
        }
    }
    protected void GridView3_DataBound(object sender, EventArgs e)
    {

    }
    protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
    {
        if (Label_scjj.Text.Trim() == "通过" && Label_rsjj.Text.Trim() == "通过")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('生产部或人事部计件信息均已审核通过，无法修改！')", true);
            return;
        
        }
        GridView2.EditIndex = e.NewEditIndex;
        //panel 各种隐藏
        Panel_Piece.Visible = true;
        UpdatePanel_Piece.Update();
        Panel_Time.Visible = false;
        Panel_Sign.Visible = false;
        UpdatePanel_Sign.Update();
        //绑定
        UpdatePanel_Time.Update();
        Panel_NoRelated.Visible = false;
        UpdatePanel_NoRelated.Update();
        Panel1.Visible = false;
        UpdatePanel1.Update();
        GridView2.DataSource = wosl.S_OperatorInfo_WorkOrder_ForOne(new Guid(label_PBCID.Text.Trim()), Label_Date.Text.Trim(), label_WOPT.Text.Trim(), new Guid(label_HRDDID1.Text.Trim()));
        GridView2.DataBind();
        Panel2.Visible = true;
        UpdatePanel2.Update();
        Panel3.Visible = false;
        UpdatePanel3.Update();
    }
    protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView2.SelectedIndex = -1;
        GridView2.EditIndex = -1;
        //panel 各种隐藏
        Panel_Piece.Visible = true;
        UpdatePanel_Piece.Update();
        Panel_Time.Visible = false;
        Panel_Sign.Visible = false;
        UpdatePanel_Sign.Update();
        //绑定
        UpdatePanel_Time.Update();
        Panel_NoRelated.Visible = false;
        UpdatePanel_NoRelated.Update();
        Panel1.Visible = false;
        UpdatePanel1.Update();
        GridView2.DataSource = wosl.S_OperatorInfo_WorkOrder_ForOne(new Guid(label_PBCID.Text.Trim()), Label_Date.Text.Trim(), label_WOPT.Text.Trim(), new Guid(label_HRDDID1.Text.Trim()));
        GridView2.DataBind();
        Panel2.Visible = true;
        UpdatePanel2.Update();
        Panel3.Visible = false;
        UpdatePanel3.Update();
    }
    protected void GridView3_RowEditing(object sender, GridViewEditEventArgs e)
    {

        if (Label_scjs.Text.Trim() == "通过" && Label_rsjs.Text.Trim() == "通过")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('生产部或人事部计时信息均已审核通过，无法修改！')", true);
            return;

        }
        GridView3.EditIndex = e.NewEditIndex;
        //panel 各种隐藏
        Panel_Piece.Visible = false;
        UpdatePanel_Piece.Update();
        Panel_Time.Visible = true;
        Panel_Sign.Visible = false;
        UpdatePanel_Sign.Update();
        //绑定
        UpdatePanel_Time.Update();
        Panel_NoRelated.Visible = false;
        UpdatePanel_NoRelated.Update();
        Panel1.Visible = false;
        UpdatePanel1.Update();
        GridView3.DataSource = wosl.S_OTime_WorkOrder_ForOne(new Guid(label_al0.Text.Trim()), Label_Date2.Text.Trim(), label_al3.Text.Trim(), new Guid(label_al4.Text.Trim()));
        GridView3.DataBind();
        Panel2.Visible = false;
        UpdatePanel2.Update();
        Panel3.Visible = true;
        UpdatePanel3.Update();
    }
    protected void GridView3_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView3.SelectedIndex = -1;
        GridView3.EditIndex = -1;
        //panel 各种隐藏
        Panel_Piece.Visible = false;
        UpdatePanel_Piece.Update();
        Panel_Time.Visible = true;
        Panel_Sign.Visible = false;
        UpdatePanel_Sign.Update();
        //绑定
        UpdatePanel_Time.Update();
        Panel_NoRelated.Visible = false;
        UpdatePanel_NoRelated.Update();
        Panel1.Visible = false;
        UpdatePanel1.Update();
        GridView3.DataSource = wosl.S_OTime_WorkOrder_ForOne(new Guid(label_al0.Text.Trim()), Label_Date2.Text.Trim(), label_al3.Text.Trim(), new Guid(label_al4.Text.Trim()));
        GridView3.DataBind();
        Panel2.Visible = false;
        UpdatePanel2.Update();
        Panel3.Visible = true;
        UpdatePanel3.Update();
    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate)) || (e.Row.RowState == DataControlRowState.Edit))
        {
            TextBox curText;
            for (int i = 6; i <= 6; i++)
            {


                curText = (TextBox)e.Row.Cells[i].Controls[0];

                curText.Attributes.Add("style ", "width:60px;");
            }
            for (int i = 6; i <= 6; i++)
            {
                ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("style", "ime-mode:disabled");
                ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("onkeyup", "this.value=this.value.replace(/\\D/g,'')");
                ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("MaxLength", "9");
                ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("onafterpaste", "this.value=this.value.replace(/\\D/g,'')");



            }

            //for (int i = 3; i <= 3; i++)
            //{
            //    ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("style", "ime-mode:disabled");
            //    ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("onkeyup", "if(isNaN(value))execCommand('undo')");
            //    ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("MaxLength", "9");
            //    ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("onafterpaste", "if(isNaN(value))execCommand('undo')");



            //}


        }
    }
    protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate)) || (e.Row.RowState == DataControlRowState.Edit))
        {
            TextBox curText;
            for (int i = 7; i <= 8; i++)
            {


                curText = (TextBox)e.Row.Cells[i].Controls[0];

                curText.Attributes.Add("style ", "width:60px;");
            }
            for (int i = 8; i <= 8; i++)
            {
                ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("style", "ime-mode:disabled");
                ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("onkeyup", "this.value=this.value.replace(/\\D/g,'')");
                ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("MaxLength", "9");
                ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("onafterpaste", "this.value=this.value.replace(/\\D/g,'')");



            }

            for (int i = 7; i <= 7; i++)
            {
                ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("style", "ime-mode:disabled");
                ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("onkeyup", "if(isNaN(value))execCommand('undo')");
                ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("MaxLength", "9");
                ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("onafterpaste", "if(isNaN(value))execCommand('undo')");



            }
        }
    }
    protected void GridView_NoRelated_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if ((e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate)) || (e.Row.RowState == DataControlRowState.Edit))
        {
            TextBox curText;
            for (int i = 5; i <= 6; i++)
            {


                curText = (TextBox)e.Row.Cells[i].Controls[0];

                curText.Attributes.Add("style ", "width:60px;");
            }
            for (int i = 6; i <= 6; i++)
            {
                ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("style", "ime-mode:disabled");
                ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("onkeyup", "this.value=this.value.replace(/\\D/g,'')");
                ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("MaxLength", "9");
                ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("onafterpaste", "this.value=this.value.replace(/\\D/g,'')");



            }

            for (int i = 5; i <= 5; i++)
            {
                ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("style", "ime-mode:disabled");
                ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("onkeyup", "if(isNaN(value))execCommand('undo')");
                ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("MaxLength", "9");
                ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("onafterpaste", "if(isNaN(value))execCommand('undo')");



            }
        }
    }
    protected void GridView3_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Guid OT_ID = new Guid(GridView3.DataKeys[e.RowIndex].Values["OT_ID"].ToString());
        try
        {

            decimal t = ((TextBox)(GridView3.Rows[e.RowIndex].Cells[7].Controls[0])).Text.Trim().ToString() == "" ? 0 : Convert.ToDecimal(((TextBox)(GridView3.Rows[e.RowIndex].Cells[7].Controls[0])).Text.Trim().ToString());
            int n = ((TextBox)(GridView3.Rows[e.RowIndex].Cells[8].Controls[0])).Text.Trim().ToString() == "" ? 0 : Convert.ToInt32(((TextBox)(GridView3.Rows[e.RowIndex].Cells[8].Controls[0])).Text.Trim().ToString());
            wosl.U_OTime_OT_NORelated(OT_ID, t, n);
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请您再次核对输入格式，时间为小数、数量为整数！')", true);
            return;
        }
        GridView3.SelectedIndex = -1;
        GridView3.EditIndex = -1;

        //绑定
        UpdatePanel_Time.Update();
        Panel_NoRelated.Visible = false;
        UpdatePanel_NoRelated.Update();
        Panel1.Visible = false;
        UpdatePanel1.Update();
        GridView3.DataSource = wosl.S_OTime_WorkOrder_ForOne(new Guid(label_al0.Text.Trim()), Label_Date2.Text.Trim(), label_al3.Text.Trim(), new Guid(label_al4.Text.Trim()));
        GridView3.DataBind();
        Panel2.Visible = false;
        UpdatePanel2.Update();
        Panel3.Visible = true;
        UpdatePanel3.Update();

    }
    protected void GridView_NoRelated_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Guid OT_ID = new Guid(GridView_NoRelated.DataKeys[e.RowIndex].Values["OT_ID"].ToString());
        try
        {

            decimal t = ((TextBox)(GridView_NoRelated.Rows[e.RowIndex].Cells[5].Controls[0])).Text.Trim().ToString() == "" ? 0 : Convert.ToDecimal(((TextBox)(GridView_NoRelated.Rows[e.RowIndex].Cells[5].Controls[0])).Text.Trim().ToString());
            int n = ((TextBox)(GridView_NoRelated.Rows[e.RowIndex].Cells[6].Controls[0])).Text.Trim().ToString() == "" ? 0 : Convert.ToInt32(((TextBox)(GridView_NoRelated.Rows[e.RowIndex].Cells[6].Controls[0])).Text.Trim().ToString());
            wosl.U_OTime_OT_NORelated(OT_ID, t, n);
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请您再次核对输入格式，时间为小数、数量为整数！')", true);
            return;
        }
        GridView_NoRelated.SelectedIndex = -1;
        GridView_NoRelated.EditIndex = -1;

        //panel 各种隐藏
        Panel_Piece.Visible = false;
        UpdatePanel_Piece.Update();
        Panel_Time.Visible = false;
        Panel_NoRelated.Visible = true;
        UpdatePanel_Time.Update();
        Panel_Sign.Visible = false;
        UpdatePanel_Sign.Update();
        GridView_NoRelated.DataSource = wosl.S_OTime_OT_NORelated("", Label_Date3.Text.Trim());
        GridView_NoRelated.DataBind();
        UpdatePanel_NoRelated.Update();
        Panel1.Visible = false;
        UpdatePanel1.Update();
        Panel2.Visible = false;
        UpdatePanel2.Update();
        Panel3.Visible = false;
        UpdatePanel3.Update();
    }
    protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Guid OI_ID = new Guid(GridView2.DataKeys[e.RowIndex].Values["OI_ID"].ToString());
        try
        {

            int n = ((TextBox)(GridView2.Rows[e.RowIndex].Cells[6].Controls[0])).Text.Trim().ToString() == "" ? 0 : Convert.ToInt32(((TextBox)(GridView2.Rows[e.RowIndex].Cells[6].Controls[0])).Text.Trim().ToString());
            wosl.U_OperatorInfo_shenhexiugai(OI_ID,  n);
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请您再次核对输入格式，时间为小数、数量为整数！')", true);
            return;
        }
        GridView2.SelectedIndex = -1;
        GridView2.EditIndex = -1;

        //panel 各种隐藏
        Panel_Piece.Visible = true;
        UpdatePanel_Piece.Update();
        Panel_Time.Visible = false;
        Panel_Sign.Visible = false;
        UpdatePanel_Sign.Update();
        //绑定
        UpdatePanel_Time.Update();
        Panel_NoRelated.Visible = false;
        UpdatePanel_NoRelated.Update();
        Panel1.Visible = false;
        UpdatePanel1.Update();
        GridView2.DataSource = wosl.S_OperatorInfo_WorkOrder_ForOne(new Guid(label_PBCID.Text.Trim()), Label_Date.Text.Trim(), label_WOPT.Text.Trim(), new Guid(label_HRDDID1.Text.Trim()));
        GridView2.DataBind();
        Panel2.Visible = true;
        UpdatePanel2.Update();
        Panel3.Visible = false;
        UpdatePanel3.Update();
    }
}