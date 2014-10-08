using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using RTXHelper;

public partial class SalaryMgt_SalaryPieceDayCalculate : System.Web.UI.Page
{
    SalaryTimeDayCalculateL stdcL = new SalaryTimeDayCalculateL();
    private static string Condition1;
    private static string Condition2;
    private static string conditionForAu1;//控制权限，以此更改数据库中存储过程中的@condition
    private static string conditionForAu2;//控制权限，以此更改数据库中存储过程中的@condition

    private string state;//权限控制
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserRole"] == null)
        {
            Response.Write("<script type=text/javascript>alert('您长时间未操作，请重新登录！');window.location.href='../Default.aspx';</script>");
        }
        #region//权限控制
        if (!((Session["UserRole"].ToString().Contains("计件工资日计算")) || (Session["UserRole"].ToString().Contains("计件工资日审核"))))
        {
            Response.Redirect("../Default.aspx");
        }
        state = Request.QueryString["status"].ToString();

        if (state.ToString() == "PieceDayCalculate")
        {
            GridView1.Columns[9].Visible = false;
            //GridView1.Columns[2].Visible = true;
            //GridView1.Columns[4].Visible = true;
            //conditionForAu1 = " and WTP_PieceTotal is null ";
            this.Title = "计件工资日计算";
        }

        if (state.ToString() == "PieceDayCheck")
        {
            GridView1.Columns[6].Visible = false;
            //conditionForAu2 = " and WTP_PieceTotal is not null  and SPSA_AuRes is null ";
            this.Title = "计件工资日审核";
        }

        #endregion
        if (!IsPostBack)
        {
            BindGridView1("");
        }
    }


    #region//绑定Gridview的方法
    private void BindGridView1(string Condition)
    {
        //if (state.ToString() == "PieceDayCalculate")
        //{
        GridView1.DataSource = stdcL.SearchPieceWaitingForCalculate_WorkTimePiece(Condition);
        //GridView1.DataSource = stdcL.SearchPieceWaitingForCalculate_WorkTimePiece(Condition);
        //}
        //if (state.ToString() == "PieceDayCheck")
        //{
        //    GridView1.DataSource = stdcL.SearchWaitingForCalculate_WorkTimePiece(conditionForAu2 + Condition);
        //}

        GridView1.DataBind();
    }//待进行计时工资计算的日期列表GridView1
    private void BindGridView2(DateTime ForShenHe_Date)
    {
        GridView2.DataSource = stdcL.SearchForShenHePiece_WithOtherTables_WODetail(ForShenHe_Date);
        GridView2.DataBind();
    }//XXX的明细GridView2
    private void BindGridView3(Guid id1)
    {
        GridView3.DataSource = stdcL.SearchPieceNotIn(id1);
        GridView3.DataBind();
    }//XXX的明细GridView2
    private void BindGrid_Detail(string Condition)
    {
        Grid_Detail.DataSource = stdcL.SearchForShenHeLookDetailPiece_WithOtherTables_WODetail(" and CONVERT(VARCHAR(100), WOD_OutTime, 23)='" +
            Label1.Text + "'  and PBC_Name ='" + Label10.Text + "'" + Condition);
        Grid_Detail.DataBind();
    }//xxx计时工资详情Grid_Detail
    #endregion


    #region//检索栏
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        GridView1.SelectedIndex = -1;
        Condition1 = TxtSDate.Text.Trim() == "" ? " " : " and WTP_Date = '" + TxtSDate.Text.Trim() + "'";
        Condition1 += DropDownList1.Text.Trim() == "请选择" ? " " : " and PP_AuRes = '" + DropDownList1.SelectedValue.ToString() + "'";
        Condition1 += DropDownList5.Text.Trim() == "请选择" ? " " : " and SPSA_AuRes = '" + DropDownList5.SelectedValue.ToString() + "'";
        LblRecordIsSearch.Text = "检索后";
        BindGridView1(Condition1);
        UpdatePanel2.Update();
    }//检索
    protected void BtnReset_Click1(object sender, EventArgs e)
    {
        GridView1.SelectedIndex = -1;
        TxtSDate.Text = "";
        DropDownList1.ClearSelection();
        DropDownList5.ClearSelection();
        LblRecordIsSearch.Text = "检索前";
        BindGridView1("");
        UpdatePanel2.Update();
    }//重置
    #endregion


    #region//GridView1的内置事件
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
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
        if (e.CommandName == "Calculate")
        {
            GridView1.SelectedIndex = row.RowIndex;
            string[] str = e.CommandArgument.ToString().Split(new char[] { ',' });
            if (!(str[4].ToString() == "待审核"))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('您只能审核人事审核状态为待审核的信息！')", true);
                return;
            }
            GridView1.SelectedIndex = -1;
            Panel7.Visible = true;
            UpdatePanel7.Update();
            TextBox3.Text = Session["Username"].ToString().Trim();
            TextBox4.Text = DateTime.Now.ToString();
            TextBox5.Text = "";
            Label15.Text = str[5].ToString();
            Label29.Text = str[0].ToString();
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

        if (e.CommandName == "PieceNotIn")
        {
            GridView1.SelectedIndex = row.RowIndex;
            Panel6.Visible = true;
            string[] str = e.CommandArgument.ToString().Split(new char[] { ',' });
            Label11.Text = str[0].ToString();
            BindGridView3(new Guid(str[0].ToString()));
            UpdatePanel6.Update();
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

        if (e.CommandName == "DetailForShenHe")
        {
            GridView1.SelectedIndex = row.RowIndex;
            Panel3.Visible = true;
            string[] str = e.CommandArgument.ToString().Split(new char[] { ',' });
            Label4.Text = str[1].ToString();
            Label47.Text = str[0].ToString();
            BindGridView2(DateTime.Parse(Label4.Text));
            UpdatePanel3.Update();
            if (Label11.Text != str[0].ToString())
            {
                if (Panel6.Visible)
                {
                    Panel6.Visible = false;
                    UpdatePanel6.Update();
                }
            }
            if (Panel4.Visible)
            {
                Panel4.Visible = false;
                UpdatePanel4.Update();
            }
            if (Label8.Text != str[0].ToString())
            {
                if (Panel5.Visible)
                {
                    Panel5.Visible = false;
                    UpdatePanel5.Update();
                }
            }
            if (Label29.Text != str[0].ToString())
            {
                if (Panel7.Visible)
                {
                    Panel7.Visible = false;
                    UpdatePanel5.Update();
                }
            }

        }
        if (e.CommandName == "ShenHe1ABC")
        {
            GridView1.SelectedIndex = row.RowIndex;
            Panel5.Visible = true;
            string[] str = e.CommandArgument.ToString().Split(new char[] { ',' });
            if (str[3].ToString() != "待审核")
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('您只能财务审核状态为待审核的信息！')", true);
                return;
            }
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
    #endregion


    protected void Button3_Click(object sender, EventArgs e)
    {
        Panel6.Visible = false;
        UpdatePanel6.Update();
    }//关闭
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


    #region//GridView3的内置事件
    protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = this.GridView3.BottomPagerRow;


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

        BindGridView3(new Guid(Label11.Text));

        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= this.GridView3.PageCount ? this.GridView3.PageCount - 1 : newPageIndex;
        this.GridView3.PageIndex = newPageIndex;
        this.GridView3.DataBind();
    }
    #endregion


    #region//GridView2的内置事件
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
    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
        string[] StrArgument = e.CommandArgument.ToString().Split(new char[] { ',' });
        if (e.CommandName == "Look_Detail")
        {
            GridView2.SelectedIndex = row.RowIndex;
            Panel4.Visible = true;
            Label10.Text = StrArgument[1];
            TextBox2.Text = StrArgument[1];
            Label1.Text = Label4.Text;
            TxtAddStaffNO.Text = "";
            TxtAddName.Text = "";
            TxtSTarget.Text = "";
            TextBox6.Text = "";
            Label5.Text = Label4.Text;
            BindGrid_Detail("");
            Label24.Text = "检索前";
            UpdatePanel4.Update();
        }
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


    #region//Label1
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Panel4.Visible)
        {
            Panel4.Visible = false;
            UpdatePanel4.Update();
        }
    }//关闭


    protected void BtnSearchPeopleOut_Click(object sender, EventArgs e)
    {
        Condition2 = TxtAddStaffNO.Text.Trim() == "" ? "" : " and HRDD_StaffNO like '%" + TxtAddStaffNO.Text.Trim() + "%'";
        Condition2 += TxtAddName.Text.Trim() == "" ? "" : " and HRDD_Name like '%" + TxtAddName.Text.Trim() + "%'";
        //Condition2 += DropDownList4.SelectedValue == "" ? "" : " and b.PBC_ID ='" + DropDownList4.SelectedValue + "'";
        Condition2 += TxtSTarget.Text.Trim() == "" ? "" : " and WO_ProType like '%" + TxtSTarget.Text.Trim() + "%'";
        Condition2 += TextBox6.Text.Trim() == "" ? "" : " and SPI_Name like '%" + TextBox6.Text.Trim() + "%'";

        BindGrid_Detail(Condition2);
        Label24.Text = "检索后";
        UpdatePanel4.Update();
    }//检索
    protected void BtnResetPeopleOut_Click(object sender, EventArgs e)
    {
        TxtAddStaffNO.Text = "";
        TxtAddName.Text = "";
        TxtSTarget.Text = "";
        TextBox6.Text = "";

        BindGrid_Detail("");
        Label24.Text = "检索前";
        UpdatePanel4.Update();

    }//重置
    #endregion


    #region//XXX计时工资审核
    protected void BtnSubmitChange_Click(object sender, EventArgs e)
    {
        SalaryTimeDayCalculateInfo stdcInfo = new SalaryTimeDayCalculateInfo();
        stdcInfo.WTP_ID = new Guid(Label8.Text);
        stdcInfo.SPSA_Auditor = TextBox1.Text.Trim();
        stdcInfo.SPSA_AuSugg = TxtRemarks.Text;
        stdcInfo.SPSA_AuRes = DropDownList2.SelectedValue;
        int i = 0;
        try
        {
            i = stdcL.Update_ForShenHePiece_WorkTimePiece(stdcInfo);
        }
        catch (Exception ex)
        {

            throw ex;
        }
        if (i > 0)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('已审核，提交成功！')", true);

            if (stdcInfo.SPSA_AuRes == "不通过")
            {
                //RTX
                string message = "ERP系统消息：" + Session["UserName"].ToString() + "(提交人)于" + DateTime.Now.ToString("F") + "（日期）完成了" + Label6.Text + " 的计件工资日审核，审核结果为不通过，请查看！";
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

    #region//计件人事审核
    protected void BtnOK_Click(object sender, EventArgs e)
    {
        int i = 0;
        SalaryTimeDayCalculateInfo stdcInfo = new SalaryTimeDayCalculateInfo();
        try
        {
            stdcInfo.WTP_ID = new Guid(Label29.Text);
            stdcInfo.PP_Auditor = Session["UserName"].ToString();
            stdcInfo.PP_AuSugg = TextBox5.Text;
            stdcInfo.PP_AuRes = "通过";
            i = stdcL.Insert_SalaryPieceworkPerDayWage(stdcInfo);
            stdcL.Update_PieceRenShiShenHe(stdcInfo);
        }
        catch (Exception ex)
        {

            throw ex;
        }
        ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('日期为：" + Label15.Text + " 的计件工资已完成计算！')", true);

        //RTX
        string message = "ERP系统消息：" + Session["UserName"].ToString() + "(提交人)于" + DateTime.Now.ToString("F") + "（日期）完成了" + Label15.Text + " 的计件工资的计算，请审核！";
        string sErr = RTXhelper.Send(message, "计件工资日审核");
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('" + sErr + "')", true);
        }
        if (LblRecordIsSearch.Text == "检索前")
            BindGridView1("");
        if (LblRecordIsSearch.Text == "检索后")
            BindGridView1(Condition1);
        UpdatePanel2.Update();
        if (Panel7.Visible)
        {
            Panel7.Visible = false;
            UpdatePanel7.Update();
        }
    }
    protected void BtnNO_Click(object sender, EventArgs e)
    {
        if (TextBox5.Text.Trim() == "")
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('驳回请录入审核意见！')", true);
            return;
        }
        SalaryTimeDayCalculateInfo stdcInfo2 = new SalaryTimeDayCalculateInfo();
        try
        {
            stdcInfo2.WTP_ID = new Guid(Label29.Text);
            stdcInfo2.PP_Auditor = Session["UserName"].ToString();
            stdcInfo2.PP_AuSugg = TextBox5.Text;
            stdcInfo2.PP_AuRes = "不通过";
            stdcL.Update_PieceRenShiShenHe(stdcInfo2);
            if (LblRecordIsSearch.Text == "检索前")
                BindGridView1("");
            if (LblRecordIsSearch.Text == "检索后")
                BindGridView1(Condition1);
            UpdatePanel2.Update();
            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('成功驳回！')", true);
            Panel7.Visible = false;
            UpdatePanel7.Update();
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    protected void BtnShutdown_Click(object sender, EventArgs e)
    {
        Panel7.Visible = false;
        UpdatePanel7.Update();
    }
    #endregion

}