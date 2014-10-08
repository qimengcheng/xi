using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RTXHelper;

public partial class WorkOrderSalary_jjbl : System.Web.UI.Page
{
    WSD ws = new WSD();
    CSD cs = new CSD();
    ProductionProcessD ppd = new ProductionProcessD();
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
                Button_Cancel0.Visible = false;//新增记录
                GridView_WOmain.Columns[0].Visible = false;
                GridView_WOmain.Columns[11].Visible = false;//删除按钮

                t123.Visible = false;
                Button7.Visible = false; //新增详情
                DropDownList12.Visible = false; //下啦选择类型
                Label5.Visible = false;//类型文字
                GridView1.Columns[0].Visible = false;
                GridView1.Columns[9].Visible = false;
                Table1.Visible = false;//
                pbtg.Visible = false;
                pbbh.Visible = false;
                TextBox7.Enabled = false;

                this.Title = "计件补录查看";
            }
            if (state.Trim() == "sh")
            {
                this.Title = "计件补录审核";
                Button_Cancel0.Visible = false;//新增记录
                GridView_WOmain.Columns[0].Visible = true;
                GridView_WOmain.Columns[11].Visible = false;//删除按钮
                t123.Visible = true;
                Button7.Visible = false; //新增详情
                DropDownList12.Visible = false; //下啦选择类型
                Label5.Visible = false;//类型文字
                GridView1.Columns[0].Visible = false;
                GridView1.Columns[9].Visible = false;
                Table1.Visible = false;//
            }
            if (state.Trim() == "make")
            {
                this.Title = "计件补录提报";
                GridView_WOmain.Columns[0].Visible = false;
                t123.Visible = false;
                GridView1.Columns[8].Visible = false;
                pbtg.Visible = false;
                pbbh.Visible = false;
                TextBox7.Enabled = false;
            }

            databind();
        }
    }

    public void databind()
    {
        string condition;
        string JJBL_NO = TextBox_xiangmu.Text.Trim() == "" ? " and 1=1 " : " and JJBL_NO like '%" + TextBox_xiangmu.Text.Trim() + "%' ";
        string JJBL_Man = TextBox_tibaoren.Text.Trim() == "" ? " and 1=1 " : " and JJBL_Man like '%" + TextBox_tibaoren.Text.Trim() + "%' ";
        string JJBL_ShMan = TextBox_chushengren.Text.Trim() == "" ? " and 1=1 " : " and JJBL_ShMan like '%" + TextBox_chushengren.Text.Trim() + "%' ";
        string JJBL_State = DropDownList1.SelectedItem.Text.Trim() == "请选择" ? " and 1=1 " : " and isnull(JJBL_State,'财务待审') like '%" + DropDownList1.SelectedItem.Text.Trim() + "%' ";

        if ((TextBox_WO_Time1.Text != "" && TextBox_WO_Time2.Text == "") || (TextBox_WO_Time1.Text == "" && TextBox_WO_Time2.Text != ""))
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请将所属日期检索范围输入完整，请您再次核对！')", true);
            return;
        }
        string JJBL_Time = (TextBox_WO_Time1.Text.Trim() == "" && TextBox_WO_Time2.Text.Trim() == "") ? " and 1=1 " : " and JJBL_Time between   '" + TextBox_WO_Time1.Text.Trim() + "' and '" + TextBox_WO_Time2.Text.Trim() + "'";

        if ((TextBox_tibaoshijian1.Text != "" && TextBox_tibaoshijian2.Text == "") || (TextBox_tibaoshijian1.Text == "" && TextBox_tibaoshijian2.Text != ""))
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请将所属日期检索范围输入完整，请您再次核对！')", true);
            return;
        }
        string JJBL_ShTime = (TextBox_tibaoshijian1.Text.Trim() == "" && TextBox_tibaoshijian2.Text.Trim() == "") ? " and 1=1 " : " and JJBL_ShTime between   '" + TextBox_tibaoshijian1.Text.Trim() + "' and '" + TextBox_tibaoshijian2.Text.Trim() + "'";
        condition = JJBL_Man + JJBL_NO + JJBL_ShMan + JJBL_ShTime + JJBL_State + JJBL_Time;
        GridView_WOmain.DataSource = ws.S_JJBL(condition);
        GridView_WOmain.DataBind();
        UpdatePanel_WOmain.Update();

    }

    public void clear()
    {

        TextBox_xiangmu.Text = "";
        TextBox_tibaoren.Text = "";
        TextBox_WO_Time1.Text = "";
        TextBox_WO_Time2.Text = "";
        DropDownList1.SelectedIndex = 0;
        TextBox_chushengren.Text = "";
        TextBox_tibaoshijian1.Text = "";
        TextBox_tibaoshijian2.Text = "";
    }

    protected void Btn_Search_Click(object sender, EventArgs e)
    {
        databind();
        Panel1.Visible = false;
        UpdatePanel1.Update();
    }
    protected void Button_Cancel_Click(object sender, EventArgs e)
    {
        clear();
        GridView_WOmain.PageIndex = 0;
        databind();
        Panel1.Visible = false;
        UpdatePanel1.Update();

        Label14.Text = "";
        Label_PLID.Text = "";
        CheckBox2.Checked = false;
        Checkfanxuan2.Checked = false;

        Panel2.Visible = false;
        Panel3.Visible = false;
        UpdatePanel2.Update();
        Panel4.Visible = false;
        UpdatePanel3.Update();
        Panel5.Visible = false;
        UpdatePanel4.Update();
        Panel_AddPeople.Visible = false;
        UpdatePanel_AddPeople.Update();

    }
    protected void Button_Cancel0_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        Panel1.Visible = true;
        UpdatePanel1.Update();

        Panel2.Visible = false;
        Panel3.Visible = false;
        UpdatePanel2.Update();
        Panel4.Visible = false;
        UpdatePanel3.Update();
        Panel5.Visible = false;
        UpdatePanel4.Update();
        Panel_AddPeople.Visible = false;
        UpdatePanel_AddPeople.Update();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {

        Panel1.Visible = false;
        UpdatePanel1.Update();

    }
    protected void Btn1_Click(object sender, EventArgs e)
    {
        try
        {
            ws.I_JJBL(Session["UserName"].ToString().Trim(), TextBox1.Text.Trim());
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('提交成功')", true);

        }
        catch (Exception)
        {

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('提交失败')", true);
            return;
        }
        Panel1.Visible = false;
        UpdatePanel1.Update();
        databind();
    }
    protected void CheckBoxAll2_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= GridView_WOmain.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView_WOmain.Rows[i].FindControl("CheckBox2");
            if (GridView_WOmain.DataKeys[i].Values["JJBL_State"].ToString().Trim() == "财务待审")
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
        Checkfanxuan2.Checked = false;
    }
    protected void Checkfanxuan2_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= GridView_WOmain.Rows.Count - 1; i++)
        {

            CheckBox CheckBox = (CheckBox)GridView_WOmain.Rows[i].FindControl("CheckBox2");
            if (GridView_WOmain.DataKeys[i].Values["PA_State"].ToString().Trim() == "财务待审")
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
        CheckBox2.Checked = false;
    }
    protected void Button_AddPTToSeries_Click(object sender, EventArgs e)//批量审核
    {
        int sum = 0;
        Label13.Visible = true;
        Label14.Visible = true;
        //   Panel1.Visible = false;
        //   Panel3.Visible = true;
        //   UpdatePanel1.Update();
        TextBox7.Text = "";
        pl0.Visible = false;
        Label_type.Text = "1";
        for (int i = 0; i <= GridView_WOmain.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView_WOmain.Rows[i].FindControl("CheckBox2");
            if (CheckBox.Checked == true)
            {
                if (Label14.Text.Trim() == "")
                {
                    Label14.Text = GridView_WOmain.DataKeys[i].Values["JJBL_NO"].ToString().Trim();
                    this.Label_PLID.Text = GridView_WOmain.DataKeys[i].Values["JJBL_ID"].ToString().Trim();
                }
                else
                {
                    string[] a;
                    if (Label14.Text.Contains(","))
                    {
                        a = Label14.Text.Trim().Split(new char[] { ',' });
                        int id = Array.IndexOf(a, GridView_WOmain.DataKeys[i].Values["JJBL_NO"].ToString().Trim()); // 这里的1就是你要查找的值
                        if (id == -1)
                        {
                            Label14.Text = Label14.Text + "," + GridView_WOmain.DataKeys[i].Values["JJBL_NO"].ToString().Trim();
                            Label_PLID.Text = Label_PLID.Text + "," + GridView_WOmain.DataKeys[i].Values["JJBL_ID"].ToString().Trim();
                        }
                    }
                    else
                    {
                        if (Label14.Text != GridView_WOmain.DataKeys[i].Values["JJBL_NO"].ToString().Trim())
                        {
                            Label14.Text = Label14.Text + "," + GridView_WOmain.DataKeys[i].Values["JJBL_NO"].ToString().Trim();
                            Label_PLID.Text = Label_PLID.Text + "," + GridView_WOmain.DataKeys[i].Values["JJBL_ID"].ToString().Trim();
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
        Panel2.Visible = false;
        TextBox7.Enabled = true;
        pbbh.Visible = true;
        pbtg.Visible = true;
        Panel3.Visible = true;
        UpdatePanel2.Update();

        Panel4.Visible = false;
        UpdatePanel3.Update();

        Panel_AddPeople.Visible = false;
        UpdatePanel_AddPeople.Update();

        Panel5.Visible = false;
        UpdatePanel4.Update();

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
        databind();

        Panel2.Visible = false;
        Panel3.Visible = false;
        UpdatePanel2.Update();
        Panel4.Visible = false;
        UpdatePanel3.Update();
        Panel5.Visible = false;
        UpdatePanel4.Update();
        Panel_AddPeople.Visible = false;
        UpdatePanel_AddPeople.Update();
    }
    protected void GridView_WOmain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "dele")//
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            try
            {
                ws.D_JJBL(new Guid(GridView_WOmain.DataKeys[row.RowIndex].Values["JJBL_ID"].ToString()));
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除成功')", true);

            }
            catch (Exception)
            {

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除失败')", true);
                return;
            }
            databind();
            Panel1.Visible = false;
            UpdatePanel1.Update();
        }
        if (e.CommandName == "Detail12")//
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Label14.Text = "";
            Label_PLID.Text = "";
            Label_type.Text = "";
            CheckBox2.Checked = false;
            Checkfanxuan2.Checked = false;
            pl0.Visible = true;

            DataSet ds_jjlx = ppd.Proc_S_SalaryPieceworkItem_All("");
            DataTable dt = ds_jjlx.Tables[0];
            DataRow dr = dt.NewRow();
            dr["SPI_ID"] = "00000000-0000-0000-0000-000000000000";
            dr["计件类型"] = "不计计件工资";
            dt.Rows.InsertAt(dr, 0);
            DropDownList12.DataSource = dt;
            DropDownList12.DataTextField = "计件类型";
            DropDownList12.DataValueField = "SPI_ID";
            DropDownList12.DataBind();
            if (this.label_pagestate.Text.Contains("sh"))
            {
                if (GridView_WOmain.DataKeys[row.RowIndex].Values["JJBL_State"].ToString().Trim() != "财务待审")
                {
                    TextBox7.Enabled = false;
                    pbtg.Visible = false;
                    pbbh.Visible = false;
                }
                else
                {
                    TextBox7.Enabled = true;
                    pbtg.Visible = true;
                    pbbh.Visible = true;
                }
            }

            if (this.label_pagestate.Text.Contains("make"))
            {
                if (GridView_WOmain.DataKeys[row.RowIndex].Values["JJBL_State"].ToString().Trim() != "财务驳回" && GridView_WOmain.DataKeys[row.RowIndex].Values["JJBL_State"].ToString().Trim() != "已建立")
                {
                    GridView1.Columns[8].Visible = true;
                    GridView1.Columns[9].Visible = false;
     

                    Table1.Visible = false;//.Visible = false;
                    Button7.Visible = false; //新增详情
                    DropDownList12.Visible = false; //下啦选择类型
                    Label5.Visible = false;//类型文字
                    GridView1.Columns[0].Visible = false;

                }
                else
                {
                    GridView1.Columns[8].Visible = false;
                    GridView1.Columns[9].Visible = true;
           

                    Table1.Visible = true;//.Visible = true;
                    Button7.Visible = true; //新增详情
                    DropDownList12.Visible = true; //下啦选择类型
                    Label5.Visible = true;//类型文字
                    GridView1.Columns[0].Visible = true;
                }
            }



            for (int i = 0; i <= GridView_WOmain.Rows.Count - 1; i++)
            {
                CheckBox CheckBox = (CheckBox)GridView_WOmain.Rows[i].FindControl("CheckBox2");
                if (GridView_WOmain.DataKeys[i].Values["JJBL_State"].ToString().Trim() == "财务待审")
                {

                    CheckBox.Checked = false;

                }
            }

            Label_JJBL_ID.Text = GridView_WOmain.DataKeys[row.RowIndex].Values["JJBL_ID"].ToString();
            TextBox8.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";
            TextBox15.Text = "";
            label_Date.Text = GridView_WOmain.DataKeys[row.RowIndex].Values["JJBL_NO"].ToString();
            Label41.Text = GridView_WOmain.DataKeys[row.RowIndex].Values["JJBL_ShMan"].ToString();
            Label42.Text = (GridView_WOmain.DataKeys[row.RowIndex].Values["JJBL_ShTime"].ToString() == "&nbsp;" || GridView_WOmain.DataKeys[row.RowIndex].Values["JJBL_ShTime"].ToString().Trim() == "") ? "" : Convert.ToDateTime(GridView_WOmain.DataKeys[row.RowIndex].Values["JJBL_ShTime"].ToString().Trim()).ToString("yy-MM-dd HH:mm");//人事审核时间;
            label52.Text = GridView_WOmain.DataKeys[row.RowIndex].Values["JJBL_ShRes"].ToString();
            TextBox7.Text = GridView_WOmain.DataKeys[row.RowIndex].Values["JJBL_ShSugg"].ToString();
            //Label21.Text = GridView_WOmain.DataKeys[row.RowIndex].Values["PA_ID"].ToString();


            Label_type.Text = "0";

            databind_detail();
            Panel2.Visible = true;
            Panel3.Visible = true;
            UpdatePanel2.Update();


            Panel4.Visible = false;
            UpdatePanel3.Update();
            Panel5.Visible = false;
            UpdatePanel4.Update();
            Panel_AddPeople.Visible = false;
            UpdatePanel_AddPeople.Update();

        }
    }
    protected void GridView_WOmain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;

            if (drv["JJBL_State"].ToString().Trim() == "财务待审")
            {
                e.Row.Cells[0].Enabled = true;


            }
            else
            {
                e.Row.Cells[0].Enabled = false;
            }
            if (drv["JJBL_State"].ToString().Trim() == "财务驳回" || drv["JJBL_State"].ToString().Trim() == "已建立")
            {
                e.Row.Cells[11].Enabled = true;
                LinkButton l = (LinkButton)e.Row.FindControl("dele");
                l.ForeColor = System.Drawing.Color.Black;

            }
            else
            {
                LinkButton l = (LinkButton)e.Row.FindControl("dele");
                l.ForeColor = System.Drawing.Color.Gray;
                e.Row.Cells[11].Enabled = false;
            }
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
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
    protected void Button6_Click(object sender, EventArgs e)
    {

        TextBox8.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox9.Text = "";
        TextBox10.Text = "";
        TextBox15.Text = "";
        databind_detail();



        Panel4.Visible = false;
        UpdatePanel3.Update();
        Panel5.Visible = false;
        UpdatePanel4.Update();
        Panel_AddPeople.Visible = false;
        UpdatePanel_AddPeople.Update();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        CheckBox2.Checked = false;
        Checkfanxuan2.Checked = false;
        for (int i = 0; i <= GridView_WOmain.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView_WOmain.Rows[i].FindControl("CheckBox2");
            if (GridView_WOmain.DataKeys[i].Values["JJBL_State"].ToString().Trim() == "财务待审")
            {

                CheckBox.Checked = false;

            }
        }
        Label14.Text = "";
        this.Label_JJBL_ID.Text = "";
        Panel2.Visible = false;
        Panel3.Visible = false;
        UpdatePanel2.Update();

        Panel4.Visible = false;
        UpdatePanel3.Update();
        Panel5.Visible = false;
        UpdatePanel4.Update();
        Panel_AddPeople.Visible = false;
        UpdatePanel_AddPeople.Update();
    }

    public void databind_detail()
    {
        string condition;
        string WO_Num = TextBox8.Text.Trim() == "" ? " and 1=1 " : " and WO_Num like '%" + TextBox8.Text.Trim() + "%' ";
        string HRDD_StaffNO = TextBox1.Text.Trim() == "" ? " and 1=1 " : " and HRDD_StaffNO like '%" + TextBox1.Text.Trim() + "%' ";
        string HRDD_Name = TextBox2.Text.Trim() == "" ? " and 1=1 " : " and HRDD_Name like '%" + TextBox2.Text.Trim() + "%' ";
        string WO_ProType = TextBox9.Text.Trim() == "" ? " and 1=1 " : " and WO_ProType like '%" + TextBox9.Text.Trim() + "%' ";
        string PBC_Name = TextBox10.Text.Trim() == "" ? " and 1=1 " : " and PBC_Name like '%" + TextBox10.Text.Trim() + "%' ";
        string SPI_Name = TextBox15.Text.Trim() == "" ? " and 1=1 " : " and isnull(g.SPS_Name+SPI_Name,'不计计件工资') like '%" + TextBox15.Text.Trim() + "%' ";

        condition = WO_Num + HRDD_StaffNO + HRDD_Name + WO_ProType + PBC_Name + " and JJBL_ID='" + this.Label_JJBL_ID.Text.Trim() + "'" + SPI_Name;
        GridView1.DataSource = ws.S_JJBLD(condition);
        GridView1.DataBind();
        UpdatePanel2.Update();

    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        databind_detail();
    }
    protected void Button_AddPeople_close0_Click(object sender, EventArgs e)
    {
        CheckBox2.Checked = false;
        Checkfanxuan2.Checked = false;
        for (int i = 0; i <= GridView_WOmain.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView_WOmain.Rows[i].FindControl("CheckBox2");
            if (GridView_WOmain.DataKeys[i].Values["JJBL_State"].ToString().Trim() == "财务待审")
            {

                CheckBox.Checked = false;

            }
        }
        Label14.Text = "";
        Label_PLID.Text = "";
        Panel3.Visible = false;
        UpdatePanel1.Update();
    }
    protected void GridView_AddProject_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;
        GridView1.SelectedIndex = -1;
        if (-1 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;

            GridViewRow pagerRow = GridView1.BottomPagerRow;


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
        newPageIndex = newPageIndex >= GridView1.PageCount ? GridView1.PageCount - 1 : newPageIndex;
        GridView1.PageIndex = newPageIndex;

        databind_detail();


        Panel4.Visible = false;
        UpdatePanel3.Update();
        Panel5.Visible = false;
        UpdatePanel4.Update();
        Panel_AddPeople.Visible = false;
        UpdatePanel_AddPeople.Update();
    }
    protected void GridView_AddProject_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void pbtg_Click(object sender, EventArgs e)
    {
        if (Label_type.Text.Trim() == "0")
        {
            try
            {



                ws.U_JJBL_SH(new Guid(this.Label_JJBL_ID.Text.Trim()), Session["UserName"].ToString(), TextBox7.Text.Trim(), "通过");
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核成功！')", true);
                string message = "ERP系统信息：" + Session["Department"].ToString() + "的" + Session["UserName"].ToString() + "于" + DateTime.Now + "审核通过了计件补录单： " + label_Date.Text + " ！";

                string ms = "";
                try
                {
                    ms = RTXhelper.Send(message, "计件补录提报");
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
        else
        {
            string[] a = Label_PLID.Text.Trim().Split(new char[] { ',' });
            try
            {
                for (int i = 0; i < a.Length; i++)
                {
                    ws.U_JJBL_SH(new Guid(a[i].Trim()), Session["UserName"].ToString(), TextBox7.Text.Trim(), "通过");

                }
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核成功！')", true);
                string message = "ERP系统信息：" + Session["Department"].ToString() + "的" + Session["UserName"].ToString() + "于" + DateTime.Now + "审核通过了计件补录单： " + Label14.Text + " ！";

                string ms = "";
                try
                {
                    ms = RTXhelper.Send(message, "计件补录提报");
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
        for (int i = 0; i <= GridView_WOmain.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView_WOmain.Rows[i].FindControl("CheckBox2");
            if (GridView_WOmain.DataKeys[i].Values["JJBL_State"].ToString().Trim() == "财务待审")
            {

                CheckBox.Checked = false;

            }
        }
        clear();
        GridView_WOmain.PageIndex = 0;
        databind();
        Panel1.Visible = false;
        UpdatePanel1.Update();



        Panel2.Visible = false;
        Panel3.Visible = false;
        UpdatePanel2.Update();
        Panel4.Visible = false;
        UpdatePanel3.Update();
        Panel5.Visible = false;
        UpdatePanel4.Update();
        Panel_AddPeople.Visible = false;
        UpdatePanel_AddPeople.Update();
    }
    protected void pbbh_Click(object sender, EventArgs e)
    {
        if (Label_type.Text.Trim() == "0")
        {
            try
            {



                ws.U_JJBL_SH(new Guid(this.Label_JJBL_ID.Text.Trim()), Session["UserName"].ToString(), TextBox7.Text.Trim(), "不通过");
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核成功！')", true);
                string message = "ERP系统信息：" + Session["Department"].ToString() + "的" + Session["UserName"].ToString() + "于" + DateTime.Now + "审核驳回了计件补录单： " + label_Date.Text + " ！";

                string ms = "";
                try
                {
                    ms = RTXhelper.Send(message, "计件补录提报");
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
        else
        {
            string[] a = Label_PLID.Text.Trim().Split(new char[] { ',' });
            try
            {
                for (int i = 0; i < a.Length; i++)
                {
                    ws.U_JJBL_SH(new Guid(a[i].Trim()), Session["UserName"].ToString(), TextBox7.Text.Trim(), "不通过");

                }
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('审核成功！')", true);
                string message = "ERP系统信息：" + Session["Department"].ToString() + "的" + Session["UserName"].ToString() + "于" + DateTime.Now + "审核驳回了计件补录单： " + Label14.Text + " ！";

                string ms = "";
                try
                {
                    ms = RTXhelper.Send(message, "计件补录提报");
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
        for (int i = 0; i <= GridView_WOmain.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView_WOmain.Rows[i].FindControl("CheckBox2");
            if (GridView_WOmain.DataKeys[i].Values["JJBL_State"].ToString().Trim() == "财务待审")
            {

                CheckBox.Checked = false;

            }
        }
        clear();
        GridView_WOmain.PageIndex = 0;
        databind();
        Panel1.Visible = false;
        UpdatePanel1.Update();



        Panel2.Visible = false;
        Panel3.Visible = false;
        UpdatePanel2.Update();
        Panel4.Visible = false;
        UpdatePanel3.Update();
        Panel5.Visible = false;
        UpdatePanel4.Update();
        Panel_AddPeople.Visible = false;
        UpdatePanel_AddPeople.Update();
    }
    protected void Btn11_Click(object sender, EventArgs e)
    {
        Panel_AddPeople.Visible = true;
        TextBox4.Text = "";
        TextBox5.Text = "";
        Panel5.Visible = false;
        UpdatePanel4.Update();

        DataSet ds = cs.CS_S_WorkingTeam_Name();
        DataTable dt = ds.Tables[0];
        DataRow dr = dt.NewRow();
        dr["WT_Name"] = "--选择所有--";
        dt.Rows.InsertAt(dr, 0);
        this.DropDownList2.DataSource = dt;
        this.DropDownList2.DataValueField = "WT_ID";
        this.DropDownList2.DataTextField = "WT_Name";
        DropDownList2.DataBind();
        DropDownList2.SelectedIndex = 0;
        if (DropDownList2.SelectedIndex == 0)
        {
            DataSet ds2 = cs.CS_S_HRDDetail_people(" and a.HRDD_ID not in (" + Label_HRDD_ID.Text.Trim() + ")");
            GridView_People.DataSource = ds2;
            GridView_People.DataBind();
            UpdatePanel_AddPeople.Update();

        }
        else
        {

            DataSet ds3 = cs.Cs_S_WorkTeamDetailList(" and WT_ID='" + this.DropDownList2.SelectedValue.ToString().Trim() + "'" + " and a.HRDD_ID not in (" + Label_HRDD_ID.Text.Trim() + ")");
            GridView_People.DataSource = ds3;
            GridView_People.DataBind();
            UpdatePanel_AddPeople.Update();

        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList2.SelectedIndex == 0)
        {
            DataSet ds2 = cs.CS_S_HRDDetail_people(" and a.HRDD_ID not in (" + Label_HRDD_ID.Text.Trim() + ")");
            GridView_People.DataSource = ds2;
            GridView_People.DataBind();
            UpdatePanel_AddPeople.Update();

        }
        else
        {

            DataSet ds3 = cs.Cs_S_WorkTeamDetailList(" and WT_ID='" + this.DropDownList2.SelectedValue.ToString().Trim() + "'" + " and a.HRDD_ID not in (" + Label_HRDD_ID.Text.Trim() + ")");
            GridView_People.DataSource = ds3;
            GridView_People.DataBind();
            UpdatePanel_AddPeople.Update();

        }
    }
    public void databind4()
    {

        string condition;
        string HRDD_StaffNO = TextBox4.Text.Trim() == "" ? " and 1=1 " : " and HRDD_StaffNO like '%" + TextBox4.Text.Trim() + "%' ";
        string HRDD_Name = TextBox5.Text.Trim() == "" ? " and 1=1 " : " and HRDD_Name like '%" + TextBox5.Text.Trim() + "%' ";
        condition = HRDD_StaffNO + HRDD_Name;
        if (DropDownList2.SelectedIndex == 0)
        {
            DataSet ds2 = cs.CS_S_HRDDetail_people(" and a.HRDD_ID not in (" + Label_HRDD_ID.Text.Trim() + ")");
            GridView_People.DataSource = ds2;
            GridView_People.DataBind();
            UpdatePanel_AddPeople.Update();

        }
        else
        {

            DataSet ds3 = cs.Cs_S_WorkTeamDetailList(" and WT_ID='" + this.DropDownList2.SelectedValue.ToString().Trim() + "'" + " and a.HRDD_ID not in (" + Label_HRDD_ID.Text.Trim() + ")");
            GridView_People.DataSource = ds3;
            GridView_People.DataBind();
            UpdatePanel_AddPeople.Update();

        }
    }
    protected void Button_AddPeopleSearch_Click(object sender, EventArgs e)
    {
        databind4();
    }
    protected void Button_AddPeopleCancel_Click(object sender, EventArgs e)
    {
        TextBox4.Text = "";
        TextBox5.Text = "";
        databind4();
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
    protected void Button_AddPeople_close_Click(object sender, EventArgs e)
    {
        Panel_AddPeople.Visible = false;
        UpdatePanel_AddPeople.Update();
    }
    protected void CheckBoxAll12_CheckedChanged(object sender, EventArgs e)
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
        CheckBox1.Checked = false;
    }
    protected void Checkfanxuan12_CheckedChanged(object sender, EventArgs e)
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
                    if (Label_HRDD_ID.Text == "'00000000-0000-0000-0000-000000000000'")
                    {
                        Label_HRDD_ID.Text = "'" + GridView_People.DataKeys[i].Values["HRDD_ID"].ToString().Trim() + "'";
                        Label53.Text = GridView_People.DataKeys[i].Values["工号"].ToString().Trim() + GridView_People.DataKeys[i].Values["姓名"].ToString().Trim();
                    }
                    else
                    {
                        Label_HRDD_ID.Text = Label_HRDD_ID.Text + ",'" + GridView_People.DataKeys[i].Values["HRDD_ID"].ToString().Trim() + "'";
                        Label53.Text = Label53.Text + "," + GridView_People.DataKeys[i].Values["工号"].ToString().Trim() + GridView_People.DataKeys[i].Values["姓名"].ToString().Trim();
                    }

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
        CheckBox1.Checked = false;
        databind4();
        Panel_AddPeople.Visible = false;
        UpdatePanel_AddPeople.Update();
        UpdatePanel3.Update();
    }


    protected void GridView2_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView2.Rows.Count; i++) //鼠标悬停样式
        {
            for (int j = 0; j < GridView2.Rows[i].Cells.Count; j++)
            {
                GridView2.Rows[i].Cells[j].ToolTip = GridView2.Rows[i].Cells[j].Text;
                if (GridView2.Rows[i].Cells[j].Text.Length > 15)
                {
                    GridView2.Rows[i].Cells[j].Text = GridView2.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }


            }
        }
    }
    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "xz")//
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            this.Label_WOD_ID.Text = GridView2.DataKeys[row.RowIndex].Values["WOD_ID"].ToString();
            this.Label54.Text = GridView2.DataKeys[row.RowIndex].Values["随工单号"].ToString() + GridView2.DataKeys[row.RowIndex].Values["工序"].ToString();
            Panel5.Visible = false;
            UpdatePanel4.Update();
            UpdatePanel3.Update();
        }
    }
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;
        GridView2.SelectedIndex = -1;
        if (-1 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;

            GridViewRow pagerRow = GridView2.BottomPagerRow;


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
        newPageIndex = newPageIndex >= GridView2.PageCount ? GridView2.PageCount - 1 : newPageIndex;
        GridView2.PageIndex = newPageIndex;
        databind_WODetail();
    }
    public void databind_WODetail()
    {
        string condition;
        string WO_Num = TextBox6.Text.Trim() == "" ? " and 1=1 " : " and WO_Num like '%" + TextBox6.Text.Trim() + "%' ";
        string WO_ProType = TextBox13.Text.Trim() == "" ? " and 1=1 " : " and WO_ProType like '%" + TextBox13.Text.Trim() + "%' ";
        string PBC_Name = TextBox14.Text.Trim() == "" ? " and 1=1 " : " and PBC_Name like '%" + TextBox14.Text.Trim() + "%' ";
        if ((TextBox_tibaoshijian3.Text != "" && TextBox_tibaoshijian4.Text == "") || (TextBox_tibaoshijian3.Text == "" && TextBox_tibaoshijian4.Text != ""))
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请将所属日期检索范围输入完整，请您再次核对！')", true);
            return;
        }
        string JJBL_ShTime = (TextBox_tibaoshijian3.Text.Trim() == "" && TextBox_tibaoshijian4.Text.Trim() == "") ? " and 1=1 " : " and WOD_OutTime between   '" + TextBox_tibaoshijian3.Text.Trim() + "' and '" + TextBox_tibaoshijian4.Text.Trim() + "'";

        condition = WO_Num + WO_ProType + PBC_Name + JJBL_ShTime;
        GridView2.DataSource = ws.S_JJBL_WODetail(condition);
        GridView2.DataBind();
        UpdatePanel4.Update();
    }

    protected void Button13_Click(object sender, EventArgs e)
    {
        databind_WODetail();
    }
    protected void Button14_Click(object sender, EventArgs e)
    {
        TextBox_tibaoshijian3.Text = "";
        TextBox_tibaoshijian4.Text = "";
        TextBox6.Text = "";
        TextBox13.Text = "";
        TextBox14.Text = "";
        databind_WODetail();
    }
    protected void Button10_Click(object sender, EventArgs e)
    {
        Panel5.Visible = false;
        UpdatePanel4.Update();
    }
    protected void Btn12_Click(object sender, EventArgs e)
    {
        Panel_AddPeople.Visible = false;
        UpdatePanel_AddPeople.Update();
        Panel5.Visible = true;
        TextBox_tibaoshijian3.Text = "";
        TextBox_tibaoshijian4.Text = "";
        TextBox6.Text = "";
        TextBox13.Text = "";
        TextBox14.Text = "";
        databind_WODetail();
    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        Label53.Text = "请选择（可多选）";
        Label54.Text = "请选择（单选）";
        Label_HRDD_ID.Text = "'00000000-0000-0000-0000-000000000000'";
        Panel4.Visible = true;
        UpdatePanel3.Update();

        Panel5.Visible = false;
        UpdatePanel4.Update();
        Panel_AddPeople.Visible = false;
        UpdatePanel_AddPeople.Update();

    }
    protected void Button9_Click(object sender, EventArgs e)
    {
        Panel4.Visible = false;
        UpdatePanel3.Update();
        Panel_AddPeople.Visible = false;
        UpdatePanel_AddPeople.Update();
        Panel5.Visible = false;
        UpdatePanel4.Update();
    }
    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView1.Rows.Count; i++) //鼠标悬停样式
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
    protected void Btn8_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.Label_HRDD_ID.Text.Trim().Contains(","))
            {
                string[] a = Label_HRDD_ID.Text.Trim().Split(new char[] { ',' });

                for (int i = 0; i < a.Length; i++)
                {
                    ws.I_JJBLD(new Guid(this.Label_WOD_ID.Text.Trim()), new Guid(a[i].Substring(1).Substring(0, a[i].Length - 2)), new Guid(this.Label_JJBL_ID.Text.Trim()));

                }


            }
            else
            {
                if (this.Label_HRDD_ID.Text != "'00000000-0000-0000-0000-000000000000'")
                {
                    ws.I_JJBLD(new Guid(this.Label_WOD_ID.Text.Trim()), new Guid(Label_HRDD_ID.Text.Substring(1).Substring(0, Label_HRDD_ID.Text.Length - 2)), new Guid(this.Label_JJBL_ID.Text.Trim()));

                }
            }
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('提交成功')", true);

        }
        catch (Exception)
        {

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('提交失败')", true);
            return;
        }
        Panel4.Visible = false;
        UpdatePanel3.Update();
        Panel_AddPeople.Visible = false;
        UpdatePanel_AddPeople.Update();
        Panel5.Visible = false;
        UpdatePanel4.Update();

        TextBox8.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox9.Text = "";
        TextBox10.Text = "";

        databind_detail();
    }
    protected void CheckBoxAll3_CheckedChanged(object sender, EventArgs e)
    {

        for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView1.Rows[i].FindControl("CheckBox2");

            if (CheckBox3.Checked == true)
            {
                CheckBox.Checked = true;
            }
            else
            {
                CheckBox.Checked = false;
            }

        }
        CheckBox4.Checked = false;

    }
    protected void Checkfanxuan4_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
        {

            CheckBox CheckBox = (CheckBox)GridView1.Rows[i].FindControl("CheckBox2");

            if (CheckBox.Checked == false)
            {
                CheckBox.Checked = true;
            }
            else
            {
                CheckBox.Checked = false;
            }


        }
        CheckBox3.Checked = false;
    }
    protected void Btn3_Click(object sender, EventArgs e)
    {
        int sum = 0;


        for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView1.Rows[i].FindControl("CheckBox2");
            if (CheckBox.Checked == true)
            {
                try
                {
                    ws.D_JJBLDetail(new Guid(GridView1.DataKeys[i].Values["补录ID"].ToString()));

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
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('您没选择任何要删除的记录！请您再核对！')", true);
            return;
        }
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除成功！')", true);

        CheckBox3.Checked = false;
        CheckBox4.Checked = false;
        TextBox8.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox9.Text = "";
        TextBox10.Text = "";

        databind_detail();



        Panel4.Visible = false;
        UpdatePanel3.Update();
        Panel5.Visible = false;
        UpdatePanel4.Update();
        Panel_AddPeople.Visible = false;
        UpdatePanel_AddPeople.Update();
    }
    protected void DropDownList12_SelectedIndexChanged(object sender, EventArgs e)
    {

        int sum = 0;


        for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView1.Rows[i].FindControl("CheckBox2");
            if (CheckBox.Checked == true)
            {
                try
                {
                    ws.U_JJBLDetail_SPI(new Guid(GridView1.DataKeys[i].Values["补录ID"].ToString()), new Guid(DropDownList12.SelectedValue.ToString().Trim()));

                    sum++;
                }
                catch (Exception)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('制定成功！')", true);
                    return;
                }
            }

        }
        if (sum == 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('您没选择任何项！请您再核对！')", true);
            return;
        }
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('制定成功！')", true);

        databind_detail();
    }
    protected void Btn15_Click(object sender, EventArgs e)
    {
        Guid id; int t;
        for (int i = 0; i <= this.GridView1.Rows.Count - 1; i++)
        {
            id = new Guid(GridView1.DataKeys[i].Values["补录ID"].ToString());

            try
            {
                t = ((TextBox)(GridView1.Rows[i].FindControl("txtPlan"))).Text.Trim() == "" ? 0 : Convert.ToInt32(((TextBox)(GridView1.Rows[i].FindControl("txtPlan"))).Text.Trim());
                ws.U_JJBLD_Num(t, id);
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('保存失败，请您再次核对输入格式，数量为整数！')", true);
                return;
            }

        }
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('保存成功！')", true);

        databind_detail();
    }
    protected void Btn16_Click(object sender, EventArgs e)
    {
        try
        {
            ws.U_JJBL_TJ(new Guid(Label_JJBL_ID.Text));
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('提交成功！')", true);

            string message = "ERP系统信息：" + Session["Department"].ToString() + "的" + Session["UserName"].ToString() + "于" + DateTime.Now + "提交了计件补录单： " + this.label_Date.Text + " ,请审核！";

            string ms = "";
            try
            {
                ms = RTXhelper.Send(message, "计件补录审核");
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('" + ms + "')", true);
                return;
            }
        }
        catch (Exception)
        {

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('提交失败！')", true);
            return;
        }
        clear();
        GridView_WOmain.PageIndex = 0;
        databind();
        Panel1.Visible = false;
        UpdatePanel1.Update();

        Label14.Text = "";
        Label_PLID.Text = "";
        CheckBox2.Checked = false;
        Checkfanxuan2.Checked = false;

        Panel2.Visible = false;
        Panel3.Visible = false;
        UpdatePanel2.Update();
        Panel4.Visible = false;
        UpdatePanel3.Update();
        Panel5.Visible = false;
        UpdatePanel4.Update();
        Panel_AddPeople.Visible = false;
        UpdatePanel_AddPeople.Update();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;
            int a = Convert.ToInt32(drv["未分配数"].ToString().Trim());
            if (a < 0)
            {
                e.Row.BackColor = System.Drawing.Color.Pink;


            }
        }
    }
}