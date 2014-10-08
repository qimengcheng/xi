using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using RTXHelper;

public partial class SalaryMgt_SalaryTimeCalculate : System.Web.UI.Page
{
    SalaryTimeDayCalculateL stdcL = new SalaryTimeDayCalculateL();
    private static string Condition1;
    private static string Condition2;
    private static string conditionForAu1;//控制权限，以此更改数据库中存储过程中的@condition
    private static string conditionForAu2;//控制权限，以此更改数据库中存储过程中的@condition

    private string state;//权限控制
    protected void Page_Load(object sender, EventArgs e)
    {
        #region//权限控制
        //注意：1、如果是计时工资计算权限的人进去，则@condition中必须包括：and WTP_TimeTotal is null(表示还没进行过计算)
        //       2、如果是计时工资审核权限的人进去，则@condition中必须包括：and STSA_AuRes is null(表示还没进行过审核)
        if (!((Session["UserRole"].ToString().Contains("计时工资日计算")) || (Session["UserRole"].ToString().Contains("计时工资日审核"))))
        {
            Response.Redirect("../Default.aspx");
        }
        state = Request.QueryString["status"].ToString();

        if (state.ToString() == "TimeDayCalculate")
        {
            GridView1.Columns[7].Visible = false;
            //GridView1.Columns[2].Visible = true;
            //conditionForAu1 = " and WTP_TimeTotal is null ";
            this.Title = "计时工资日计算";
        }
        if (state.ToString() == "TimeDayCheck")
        {
            GridView1.Columns[5].Visible = false;
            //GridView1.Columns[3].Visible = true;
            //conditionForAu2 = " and WTP_TimeTotal is not null  and STSA_AuRes is null ";
            this.Title = "计时工资日审核";
        }

        #endregion
        if (!IsPostBack)
        {
            BindGridView1("");
        }
    }

    /// <summary>
    /// 计算当前选择日期的计时工资，并将当前日期和计算结果存储进入
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>

    #region//绑定Gridview的方法
    private void BindGridView1(string Condition)
    {
        if (state.ToString() == "TimeDayCalculate")
        {
            GridView1.DataSource = stdcL.SearchWaitingForCalculate_WorkTimePiece(conditionForAu1 + Condition);
        }
        if (state.ToString() == "TimeDayCheck")
        {
            GridView1.DataSource = stdcL.SearchWaitingForCalculate_WorkTimePiece(conditionForAu2 + Condition);
        }
        GridView1.DataBind();
    }//待进行计时工资计算的日期列表GridView1
    private void BindGridView2(DateTime ForShenHe_Date)
    {
        GridView2.DataSource = stdcL.SearchForShenHe_WithOtherTables_WODetail(ForShenHe_Date);
        GridView2.DataBind();
    }//XXX的明细GridView1

    private void BindGrid_Detail(string Condition)
    {
        Grid_Detail.DataSource = stdcL.SearchForShenHeLookDetail_WithOtherTables_WODetail(" and CONVERT(VARCHAR(100), WOD_OutTime, 23)='" +
            Label1.Text + "'  and PBC_ID ='" + DropDownList4.SelectedValue + "'" + Condition);
        Grid_Detail.DataBind();
    }//xxx计时工资详情Grid_Detail
    #endregion


    #region//检索栏
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        GridView1.SelectedIndex = -1;
        Condition1 = TxtSDate.Text.Trim() == "" ? " " : " and WTP_Date = '" + TxtSDate.Text.Trim() + "' ";
        Condition1 += DropDownList3.Text.Trim() == "请选择" ? " " : " and PT_AuRes = '" + DropDownList3.SelectedValue.ToString() + "'";
        Condition1 += DropDownList5.Text.Trim() == "请选择" ? " " : " and STSA_AuRes = '" + DropDownList5.SelectedValue.ToString() + "'";
        LblRecordIsSearch.Text = "检索后";
        BindGridView1(Condition1);
        UpdatePanel2.Update();
    }//检索
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        GridView1.SelectedIndex = -1;
        TxtSDate.Text = "";
        DropDownList3.ClearSelection();
        DropDownList5.ClearSelection();
        LblRecordIsSearch.Text = "检索前";
        BindGridView1("");
        UpdatePanel2.Update();
    }//重置
    #endregion


    #region//GridView1的内置事件
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
        string[] str = e.CommandArgument.ToString().Split(new char[] { ',' });
        if (e.CommandName == "Calculate")
        {
            
            if (!(str[4].ToString() == "待审核" ))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('您只能审核人事审核状态为待审核的信息！')", true);
                return;
            }
            
            GridView1.SelectedIndex = -1;
            Panel6.Visible = true;
            UpdatePanel6.Update();
            TextBox2.Text = Session["Username"].ToString().Trim();
            TextBox3.Text = DateTime.Now.ToString();
            TextBox4.Text = "";
            Label15.Text = str[5].ToString();
            Label29.Text = str[0].ToString();

        }
        if (e.CommandName == "DetailForShenHe")
        {
            GridView1.SelectedIndex = -1;
            Panel6.Visible = true;
            UpdatePanel6.Update();
            TextBox2.Text = Session["Username"].ToString().Trim();
            TextBox3.Text = DateTime.Now.ToString();
            TextBox4.Text = "";
            Label15.Text = str[5].ToString();
            Label29.Text = str[0].ToString();

        }

        if (e.CommandName == "ShenHe1ABC")
        {
            GridView1.SelectedIndex = row.RowIndex;
            if (str[3].ToString() != "待审核")
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('您只能财务审核状态为待审核的信息！')", true);
                return;
            }
           

            Panel5.Visible = true;
            Label8.Text = str[0].ToString();
            TextBox1.Text = Session["Username"].ToString().Trim();
            TxtETime.Text = DateTime.Now.ToString();
            DropDownList2.ClearSelection();
            TxtRemarks.Text = "";
            Label6.Text = row.Cells[1].Text;
            UpdatePanel5.Update();
            if (Label47.Text != str[0].ToString())
            {
                if (Panel3.Visible)
                {
                    Panel3.Visible = false;
                    UpdatePanel3.Update();
                }
                if (Panel4.Visible)
                {
                    Panel4.Visible = false;
                    UpdatePanel4.Update();
                }
            }
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = this.GridView1.BottomPagerRow;


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
            BindGridView1("");
        if (LblRecordIsSearch.Text == "检索后")
            BindGridView1(Condition1);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= this.GridView1.PageCount ? this.GridView1.PageCount - 1 : newPageIndex;
        this.GridView1.PageIndex = newPageIndex;
        this.GridView1.DataBind();
    }
    #endregion


    #region//GridView2的内置事件
    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
        if (e.CommandName == "Look_Detail")
        {
            try
            {
                GridView2.SelectedIndex = row.RowIndex;
                BindDropDownList();
                Panel4.Visible = true;
                Label1.Text = row.Cells[0].Text;
                TxtAddStaffNO.Text = "";
                TxtAddName.Text = "";
                DropDownList1.ClearSelection();
                TxtSTarget.Text = "";
                Label5.Text = row.Cells[0].Text;
                Label10.Text = row.Cells[1].Text;
                DropDownList4.Items.FindByText(Label10.Text).Selected = true;
                BindGrid_Detail("");
                Label24.Text = "检索前";
                UpdatePanel4.Update();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = this.GridView2.BottomPagerRow;


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

        BindGridView2(DateTime.Parse(Label4.Text));

        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= this.GridView2.PageCount ? this.GridView2.PageCount - 1 : newPageIndex;
        this.GridView2.PageIndex = newPageIndex;
        this.GridView2.DataBind();
    }
    #endregion


    #region//Grid_Detail的内置事件
    protected void Grid_Detail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = this.Grid_Detail.BottomPagerRow;


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
        if (Label24.Text == "检索前")
            BindGrid_Detail("");
        if (Label24.Text == "检索后")
            BindGrid_Detail(Condition2);

        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= this.Grid_Detail.PageCount ? this.Grid_Detail.PageCount - 1 : newPageIndex;
        this.Grid_Detail.PageIndex = newPageIndex;
        this.Grid_Detail.DataBind();
    }
    #endregion


    #region//绑定工序DropDownList4
    private void BindDropDownList()
    {
        DropDownList4.DataSource = stdcL.SearchWOError_Rework_PBCraft();
        this.DropDownList4.DataTextField = "PBC_Name";
        this.DropDownList4.DataValueField = "PBC_ID";
        this.DropDownList4.DataBind();
        this.DropDownList4.Items.Insert(0, new ListItem("请选择", ""));
    }
    #endregion


    protected void Button2_Click(object sender, EventArgs e)
    {
        Panel3.Visible = false;
        UpdatePanel3.Update();
        if (Panel4.Visible)
        {
            Panel4.Visible = false;
            UpdatePanel4.Update();
        }
    }//关闭


    #region//Label1
    protected void BtnSearchPeopleOut_Click(object sender, EventArgs e)
    {
        Condition2 = TxtAddStaffNO.Text.Trim() == "" ? "" : " and HRDD_StaffNO like '%" + TxtAddStaffNO.Text.Trim() + "%'";
        Condition2 += TxtAddName.Text.Trim() == "" ? "" : " and HRDD_Name like '%" + TxtAddName.Text.Trim() + "%'";
        //Condition2 += DropDownList4.SelectedValue == "" ? "" : " and b.PBC_ID ='" + DropDownList4.SelectedValue + "'";
        Condition2 += TxtSTarget.Text.Trim() == "" ? "" : " and STI_Name like '%" + TxtSTarget.Text.Trim() + "%'";
        Condition2 += DropDownList1.SelectedValue == "请选择" ? "" : " and OT_IsRelated ='" + DropDownList1.SelectedValue + "'";
        BindGrid_Detail(Condition2);
        Label24.Text = "检索后";
        UpdatePanel4.Update();
    }//检索

    protected void BtnResetPeopleOut_Click1(object sender, EventArgs e)
    {
        TxtAddStaffNO.Text = "";
        TxtAddName.Text = "";
        DropDownList1.ClearSelection();
        TxtSTarget.Text = "";
        BindGrid_Detail("");
        Label24.Text = "检索前";
        UpdatePanel4.Update();

    }//重置
    protected void Button1_Click(object sender, EventArgs e)
    {
        Panel4.Visible = false;
        UpdatePanel4.Update();
    }//关闭
    #endregion



    #region//XXX计时工资审核
    protected void BtnSubmitChange_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == "" || TxtETime.Text == "" || DropDownList2.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        SalaryTimeDayCalculateInfo stdcInfo = new SalaryTimeDayCalculateInfo();
        stdcInfo.WTP_ID = new Guid(Label8.Text);
        stdcInfo.STSA_Auditor = TextBox1.Text.Trim();
        stdcInfo.STSA_AuSugg = TxtRemarks.Text;
        stdcInfo.STSA_AuRes = DropDownList2.SelectedValue;
        int i = 0;
        try
        {
            i = stdcL.Update_ForShenHe_WorkTimePiece(stdcInfo);
        }
        catch (Exception ex)
        {

            throw ex;
        }
        if (i > 0)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('已审核，提交成功！')", true);
            if (stdcInfo.STSA_AuRes == "不通过")
            {
                //RTX
                string message = "ERP系统消息：" + Session["UserName"].ToString() + "(提交人)于" + DateTime.Now.ToString("F") + "（日期）完成了" + Label6.Text + " 的计时工资日审核，审核结果为不通过，请查看！";
                string sErr = RTXhelper.Send(message, "计时计件日审核制定");
                if (!string.IsNullOrEmpty(sErr))
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('" + sErr + "')", true);
                }
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('提交失败，请联系管理员！')", true);
            return;
        }
        if (LblRecordIsSearch.Text == "检索前")
            BindGridView1("");
        if (LblRecordIsSearch.Text == "检索后")
            BindGridView1(Condition1);
        UpdatePanel2.Update();
        Panel5.Visible = false;
        UpdatePanel5.Update();
        if (Panel3.Visible)
        {
            Panel3.Visible = false;
            UpdatePanel3.Update();
        }
        if (Panel4.Visible)
        {
            Panel4.Visible = false;
            UpdatePanel4.Update();
        }

    }//提交
    protected void BtnCancelChange_Click(object sender, EventArgs e)
    {
        Panel5.Visible = false;
        UpdatePanel5.Update();
    }//取消
    #endregion

    #region//人事审核
    protected void BtnOK_Click(object sender, EventArgs e)
    {
            int i = 0;
            SalaryTimeDayCalculateInfo stdcInfo = new SalaryTimeDayCalculateInfo();
            try
            {
                stdcInfo.WTP_ID = new Guid(Label29.Text);
                stdcInfo.PT_Auditor=Session["UserName"].ToString();
                stdcInfo.PT_AuSugg=TextBox4.Text;
                stdcInfo.PT_AuSugg="通过";
                i = stdcL.Insert_SalaryTimePerDayWage(stdcInfo);
                stdcL.Update_WorkTimePieceRenShiShenHe(stdcInfo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('日期为：" + Label15.Text + " 的计时工资已完成计算！')", true);

            //RTX
            string message = "ERP系统消息：" + Session["UserName"].ToString() + "(提交人)于" + DateTime.Now.ToString("F") + "（日期）完成了" + Label15.Text + " 的计时工资的计算，请审核！";
            string sErr = RTXhelper.Send(message, "计时工资日审核");
            if (!string.IsNullOrEmpty(sErr))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('" + sErr + "')", true);
            }

            if (LblRecordIsSearch.Text == "检索前")
                BindGridView1("");
            if (LblRecordIsSearch.Text == "检索后")
                BindGridView1(Condition1);
            UpdatePanel2.Update();
            if (Panel6.Visible)
            {
                Panel6.Visible = false;
                UpdatePanel6.Update();
            }
    }
    protected void BtnNO_Click(object sender, EventArgs e)
    {
        if (TextBox4.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('驳回请录入审核意见！')", true);
        }
        SalaryTimeDayCalculateInfo stdcInfo2 = new SalaryTimeDayCalculateInfo();
        try
        {
            stdcInfo2.WTP_ID = new Guid(Label29.Text);
            stdcInfo2.PT_Auditor = Session["UserName"].ToString();
            stdcInfo2.PT_AuSugg = TextBox4.Text;
            stdcInfo2.PT_AuSugg = "不通过";
            stdcL.Update_WorkTimePieceRenShiShenHe(stdcInfo2);
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    protected void BtnShutdown_Click(object sender, EventArgs e)
    {
        Panel6.Visible = false;
        UpdatePanel6.Update();
    }
    #endregion
}