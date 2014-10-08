using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class WorkOrderSalary_ZhuangPeiJiJian : Page
{
    WOSSalaryL wosl = new WOSSalaryL();
    CSD cs = new CSD();
    ProductionProcessD ppd = new ProductionProcessD();
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
                Title = "装配计件查看";
                GridView1.Columns[4].Visible = false;
                Button_Add.Visible = false;
                Button_Submit.Visible = false;
                GridView_Detail.Columns[4].Visible = true;//类型
                GridView_Detail.Columns[5].Visible = false;//类型

                GridView_Detail.Columns[6].Visible = true;//计时
                GridView_Detail.Columns[7].Visible = false;//计时

               // GridView_Detail.Columns[9].Visible = false;
                Button_Addman.Visible = false;
                Button_Sava.Visible = false;
                pl.Visible = false;
                pl2.Visible = false;
            }
            if (state.Trim() == "manage")
            {
                Title = "装配计件维护";
                GridView_Detail.Columns[4].Visible = false;
                GridView_Detail.Columns[5].Visible = true;
                GridView_Detail.Columns[6].Visible = false;//类型
                GridView_Detail.Columns[7].Visible = true;//类型
            }
            if (!IsPostBack)
            {
                try
                {
                    if (!((Session["UserRole"].ToString().Contains("装配计件维护")) || (Session["UserRole"].ToString().Contains("装配计件查看"))))
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('可能您没有权限操作和查看本页面，请退出选择其他账号登陆，或联系管理员！')", true);

                        Response.Redirect("~/Default.aspx");

                    }
                    if (!Session["UserRole"].ToString().Contains("装配计件维护"))
                    {
                        GridView1.Columns[4].Visible = false;
                        Button_Add.Visible = false;
                        Button_Submit.Visible = false;
                        GridView_Detail.Columns[5].Visible = false;
                        GridView_Detail.Columns[6].Visible = false;
                        Button_Addman.Visible = false;

                    }


                    databind();
                    GridView1.SelectedIndex = -1;
                    GridView1.EditIndex = -1;
                    GridView_Xilie.SelectedIndex = -1;
                    GridView_Xilie.EditIndex = -1;
                    //pannel 各种隐藏
                    Panel_Add.Visible = false;
                    UpdatePanel_Add.Update();
                    Panel_Search.Visible = false;
                    UpdatePanel_Search.Update();
                    TextBox_calculate_Time_Add.Text = "";
                    TextBox_Seriesname.Text = "";
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

    public DataTable GetDs2()
    {


        DataSet ds_jjlx = ppd.Proc_S_SalaryPieceworkItem_All(" and PBC_ID=(select PBC_ID from PBCraftInfo where PBC_Name='装配' )");
        DataTable dt = ds_jjlx.Tables[0];
        DataRow dr = dt.NewRow();
        dr["SPI_ID"] = "00000000-0000-0000-0000-000000000000";
        dr["计件类型"] = "不计计件工资";
        dt.Rows.InsertAt(dr, 0);
        return dt;
    }
    public void databind()
    {
        string condition;
        if ((TextBox_calculate_Time1.Text != "" && TextBox_calculate_Time2.Text == "") || (TextBox_calculate_Time1.Text == "" && TextBox_calculate_Time2.Text != ""))
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请将时间检索范围输入完整，请您再次核对！')", true);
            return;
        }
        string APD_Date = (TextBox_calculate_Time1.Text.Trim() == "" && TextBox_calculate_Time2.Text.Trim() == "") ? " and 1=1 " : " and APD_Date between   ' " + TextBox_calculate_Time1.Text.Trim() + "' and ' " + TextBox_calculate_Time2.Text.Trim() + "'";
        condition = APD_Date;
        GridView1.DataSource = wosl.S_AssemblyPieceDate(condition);
        GridView1.DataBind();
        UpdatePanel_WOmain.Update();
        GridView1.SelectedIndex = -1;
        GridView1.EditIndex = -1;

    }

    public void databind2()
    {
        string condition;
        string LCS_Name = TextBox_Seriesname.Text.Trim() == "" ? " and 1=1 " : " and LCS_Name like '%" + TextBox_Seriesname.Text.Trim() + "%' ";
        condition = LCS_Name;
        GridView_Xilie.DataSource = wosl.S_LaborCostSeries(condition);
        GridView_Xilie.DataBind();
        UpdatePanel_Search.Update();
        GridView_Xilie.SelectedIndex = -1;
        GridView_Xilie.EditIndex = -1;
    }
    public void databind3()
    {
        string condition;
        string HRDD_StaffNO = TextBox_NO.Text.Trim() == "" ? " and 1=1 " : " and HRDD_StaffNO like '%" + TextBox_NO.Text.Trim() + "%' ";
        string HRDD_Name = TextBox_Name.Text.Trim() == "" ? " and 1=1 " : " and HRDD_Name like '%" + TextBox_Name.Text.Trim() + "%' ";
        condition = HRDD_StaffNO + HRDD_Name;
        GridView_Detail.DataSource = wosl.S_AssemblyTeamMember_Detai(condition, label_XilieID.Text.Trim(), label_APD_ID.Text.Trim());
        GridView_Detail.DataBind();
     
        //GridView_Detail.SelectedIndex = -1;
        //GridView_Detail.EditIndex = -1;
        DataSet ds = wosl.S_AssemblyTeamMember_Detai(condition, label_XilieID.Text.Trim(), label_APD_ID.Text.Trim());
        DataView dv = ds.Tables[0].DefaultView;
        foreach (DataRowView dr in dv)
        {

            TextBox_TotalNum.Text = dr["totaltime"].ToString();

        }
       UpdatePanel_Detail.Update();
    }

    public void databind4()
    {

        string condition;
        string HRDD_StaffNO = TextBox1.Text.Trim() == "" ? " and 1=1 " : " and HRDD_StaffNO like '%" + TextBox1.Text.Trim() + "%' ";
        string HRDD_Name = TextBox2.Text.Trim() == "" ? " and 1=1 " : " and HRDD_Name like '%" + TextBox2.Text.Trim() + "%' ";
        condition = HRDD_StaffNO + HRDD_Name;
        if (DropDownList1.SelectedIndex == 0)
        {
            DataSet ds2 = cs.CS_S_HRDDetail_people(" and a.HRDD_ID not in (select HRDD_ID from AssemblyTeamMember where APD_ID ='" + label_APD_ID.Text.Trim() + "' and LCS_ID='" + label_XilieID.Text.Trim() + "')" + condition);
            GridView_People.DataSource = ds2;
            GridView_People.DataBind();
            UpdatePanel_AddPeople.Update();

        }
        else
        {

            DataSet ds3 = cs.Cs_S_WorkTeamDetailList(" and WT_ID='" + this.DropDownList1.SelectedValue.ToString().Trim() + "'" + " and a.HRDD_ID not in (select HRDD_ID from AssemblyTeamMember where APD_ID ='" + label_APD_ID.Text.Trim() + "' and LCS_ID='" + label_XilieID.Text.Trim() + "')" + condition);
            GridView_People.DataSource = ds3;
            GridView_People.DataBind();
            UpdatePanel_AddPeople.Update();

        }
    }
    protected void Btn_Search_Click(object sender, EventArgs e)//日期检索
    {
        databind();
        //pannel 各种隐藏
        Panel_Add.Visible = false;
        UpdatePanel_Add.Update();
        Panel_Search.Visible = false;
        UpdatePanel_Search.Update();
        TextBox_calculate_Time_Add.Text = "";
        TextBox_Seriesname.Text = "";
    }
    protected void Button_Add_Click(object sender, EventArgs e)//新增日期
    {
        GridView1.SelectedIndex = -1;
        GridView1.EditIndex = -1;
        GridView_Xilie.SelectedIndex = -1;
        GridView_Xilie.EditIndex = -1;
        Panel_Add.Visible = true;
        UpdatePanel_Add.Update();

        Panel_Search.Visible = false;
        UpdatePanel_Search.Update();

        TextBox_Seriesname.Text = "";
        Panel_Detail.Visible = false;
        UpdatePanel_Detail.Update();
        TextBox_NO.Text = "";
        TextBox_Name.Text = "";
        GridView_Detail.SelectedIndex = -1;
        GridView_Detail.EditIndex = -1;
        GridView_Xilie.SelectedIndex = -1;
        GridView_Xilie.EditIndex = -1;

    }
    protected void Button_Cancel_Click(object sender, EventArgs e)//日期重置
    {
        //pannel 各种隐藏
        Panel_Add.Visible = false;
        UpdatePanel_Add.Update();
        Panel_Search.Visible = false;
        UpdatePanel_Search.Update();
        TextBox_calculate_Time_Add.Text = "";
        TextBox_Seriesname.Text = "";
        TextBox_calculate_Time1.Text = "";
        TextBox_calculate_Time2.Text = "";
        databind();
        Panel_Detail.Visible = false;
        UpdatePanel_Detail.Update();
        TextBox_NO.Text = "";
        TextBox_Name.Text = "";
        GridView_Detail.SelectedIndex = -1;
        GridView_Detail.EditIndex = -1;
        GridView_Xilie.SelectedIndex = -1;
        GridView_Xilie.EditIndex = -1;


    }
    protected void Button_Add_Submit_Click(object sender, EventArgs e)//新增日期确定
    {
        if (TextBox_calculate_Time_Add.Text == "")
        {

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('日期不能为空！')", true);
            return;
        }



        string condition = " and APD_Date='" + TextBox_calculate_Time_Add.Text.Trim() + "'";
        DataSet ds = wosl.S_AssemblyPieceDate(condition);
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count != 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('系统中已有该日期信息，请您再次核对！')", true);
            return;
        }
        else
        {
            try
            {
                wosl.I_AssemblyPieceDate(Convert.ToDateTime(TextBox_calculate_Time_Add.Text.Trim()), Session["UserName"].ToString().Trim());
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('新增成功！')", true);
                Panel_Add.Visible = false;
                UpdatePanel_Add.Update();
                TextBox_calculate_Time_Add.Text = "";
                databind();

            }
            catch (Exception)
            {

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('新增失败，请再次核对，例如日期格式！')", true);
                return;
            }
            //pannel 各种隐藏
            Panel_Add.Visible = false;
            UpdatePanel_Add.Update();
            Panel_Search.Visible = false;
            UpdatePanel_Search.Update();
            TextBox_calculate_Time_Add.Text = "";
            TextBox_Seriesname.Text = "";
            TextBox_calculate_Time1.Text = "";
            TextBox_calculate_Time2.Text = "";
            databind();

        }
    }
    protected void Button_Add_Cancel_Click(object sender, EventArgs e)//新增日期取消
    {
        Panel_Add.Visible = false;
        UpdatePanel_Add.Update();

        TextBox_calculate_Time_Add.Text = "";

    }
    protected void GridView_WOmain_PageIndexChanging(object sender, GridViewPageEventArgs e)
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
        GridView1.PageIndex = newPageIndex;

        databind();
        //pannel 各种隐藏

        Panel_Add.Visible = false;
        UpdatePanel_Add.Update();
        Panel_Search.Visible = false;
        UpdatePanel_Search.Update();
        TextBox_calculate_Time_Add.Text = "";
        TextBox_Seriesname.Text = "";
    }
    protected void GridView_WOmain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteWTP")//
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            try
            {
                string al = e.CommandArgument.ToString();

                DataSet ds = wosl.S_AssemblyPieceDate_Shanchupanduan(new Guid(al.Trim()));
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count != 0)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('该日期已经制定了进一步详细信息！已经无法删除！')", true);
                    return;
                }

                else
                {
                    wosl.D_AssemblyPieceDate(new Guid(al.Trim()));
                }

            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除失败！')", true);
                return;

            }
            databind();
            GridView1.SelectedIndex = -1;
            GridView1.EditIndex = -1;
            //pannel 各种隐藏
            Panel_Add.Visible = false;
            UpdatePanel_Add.Update();
            Panel_Search.Visible = false;
            UpdatePanel_Search.Update();
            TextBox_calculate_Time_Add.Text = "";
            TextBox_Seriesname.Text = "";
            Panel_Detail.Visible = false;
            UpdatePanel_Detail.Update();
            TextBox_NO.Text = "";
            TextBox_Name.Text = "";
            GridView_Detail.SelectedIndex = -1;
            GridView_Detail.EditIndex = -1;
            GridView_Xilie.SelectedIndex = -1;
            GridView_Xilie.EditIndex = -1;
        }

        if (e.CommandName == "CheckPiece")//
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView1.SelectedIndex = row.RowIndex;
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            label_APD_ID.Text = al[0];
            //    this.label_SID.Text = al[0];


            //pannel 各种隐藏
            Panel_Add.Visible = false;
            UpdatePanel_Add.Update();
            Panel_Search.Visible = true;
            databind2();
            TextBox_calculate_Time_Add.Text = "";
            TextBox_Seriesname.Text = "";
            Panel_Detail.Visible = false;
            UpdatePanel_Detail.Update();
            TextBox_NO.Text = "";
            TextBox_Name.Text = "";
            GridView_Detail.SelectedIndex = -1;
            GridView_Detail.EditIndex = -1;
            GridView_Xilie.SelectedIndex = -1;
            GridView_Xilie.EditIndex = -1;




        }
    }
    protected void Btn_SearchGongjia_Click(object sender, EventArgs e)//工价系列检索
    {
        databind2();
    }
    protected void Button_CancelGongjia_Click(object sender, EventArgs e)//工价系列检索重置
    {
        //Panel_Search.Visible = false;
        // UpdatePanel_Search.Update();
        //TextBox_calculate_Time_Add.Text = "";
        TextBox_Seriesname.Text = "";
        databind2();
        Panel_AddPeople.Visible = false;
        UpdatePanel_AddPeople.Update();
        Panel_Detail.Visible = false;
        UpdatePanel_Detail.Update();
    }
    protected void GridView_Xilie_PageIndexChanging(object sender, GridViewPageEventArgs e)//工价系列翻页
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;
        GridView_Xilie.SelectedIndex = -1;
        if (-1 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;

            GridViewRow pagerRow = GridView_Xilie.BottomPagerRow;


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
        newPageIndex = newPageIndex >= GridView_Xilie.PageCount ? GridView_Xilie.PageCount - 1 : newPageIndex;
        GridView_Xilie.PageIndex = newPageIndex;



        //pannel 各种隐藏

        Panel_Add.Visible = false;
        UpdatePanel_Add.Update();
        Panel_Search.Visible = true;
        databind2();
        TextBox_calculate_Time_Add.Text = "";

    }
    protected void GridView_Xilie_RowCommand(object sender, GridViewCommandEventArgs e)//工价系列行命令
    {
        if (e.CommandName == "ptmgt")//
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_Xilie.SelectedIndex = row.RowIndex;
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            label_XilieID.Text = al[0];
            label_Xilie2.Text = al[1];

            //装配计件工价系列总数
            DataSet ds = ppd.S_Zhuangpeijijian_xiliesum(new Guid(label_APD_ID.Text.Trim()), new Guid(label_XilieID.Text.Trim()));
            TextBox_TotalNum0.Text = ds.Tables[0].Rows[0]["num"].ToString();

            DataSet ds_jjlx = ppd.Proc_S_SalaryPieceworkItem_All(" and PBC_ID=(select PBC_ID from PBCraftInfo where PBC_Name='装配' )");
            DataTable dt = ds_jjlx.Tables[0];
            DataRow dr = dt.NewRow();
            dr["SPI_ID"] = "00000000-0000-0000-0000-000000000000";
            dr["计件类型"] = "不计计件工资";
            dt.Rows.InsertAt(dr, 0);
            DropDownList12.DataSource = dt;
            DropDownList12.DataTextField = "计件类型";
            DropDownList12.DataValueField = "SPI_ID";
            DropDownList12.DataBind();


            //pannel 各种隐藏
            Panel_Detail.Visible = true;
            Panel_Add.Visible = false;
            UpdatePanel_Add.Update();
            Panel_Search.Visible = true;
            TextBox_calculate_Time_Add.Text = "";
            TextBox_TotalNum.Text = "0.00";
            databind3();





        }
    }
    protected void Button_GuanBiGongjia_Click(object sender, EventArgs e)
    {
        TextBox_Seriesname.Text = "";
        Panel_Search.Visible = false;
        Panel_AddPeople.Visible = false;
        UpdatePanel_AddPeople.Update();
        Panel_Detail.Visible = false;
        UpdatePanel_Detail.Update();

    }
    protected void Button_SearchDetail_Click(object sender, EventArgs e)
    {
        databind3();
    }
    protected void Button_ResetDetail_Click(object sender, EventArgs e)
    {
        TextBox_Name.Text = "";
        TextBox_NO.Text = "";

        GridView_Detail.SelectedIndex = -1;
        GridView_Detail.EditIndex = -1;

        GridView_Detail.PageIndex = 1;

        databind3();
        UpdatePanel_Detail.Update();
        Panel_AddPeople.Visible = false;
        UpdatePanel_AddPeople.Update();
    }
    protected void Button_Submit_Click(object sender, EventArgs e)//提交
    {

    }
    protected void Button_Addman_Click(object sender, EventArgs e)//添加员工
    {
        Panel_AddPeople.Visible = true;
        DataSet ds = cs.CS_S_WorkingTeam_Name_zhuangpei();
        DataTable dt = ds.Tables[0];
        DataRow dr = dt.NewRow();
        dr["WT_Name"] = "--选择所有--";
        dt.Rows.InsertAt(dr, 0);
        this.DropDownList1.DataSource = dt;
        this.DropDownList1.DataValueField = "WT_ID";
        this.DropDownList1.DataTextField = "WT_Name";
        DropDownList1.DataBind();
        if (DropDownList1.Items.Count != 0)
        {
            try
            {
                for (int i = 0; i < DropDownList1.Items.Count; i++)
                {


                    if (DropDownList1.Items[i].Text.Contains("装配A"))
                    {
                        DropDownList1.SelectedIndex = i;
                        break;
                    }
                }
            }

            catch (Exception)
            {
                this.DropDownList1.SelectedIndex = 1;
            }
        }
        else
        {
            this.DropDownList1.SelectedIndex = 0;
        }
        if (DropDownList1.SelectedIndex == 0)
        {
            DataSet ds2 = cs.CS_S_HRDDetail_people(" and a.HRDD_ID not in (select HRDD_ID from AssemblyTeamMember where APD_ID ='" + label_APD_ID.Text.Trim() + "' and LCS_ID='" + label_XilieID.Text.Trim() + "')");
            GridView_People.DataSource = ds2;
            GridView_People.DataBind();
            UpdatePanel_AddPeople.Update();

        }
        else
        {

            DataSet ds3 = cs.Cs_S_WorkTeamDetailList(" and WT_ID='" + this.DropDownList1.SelectedValue.ToString().Trim() + "'" + " and a.HRDD_ID not in (select HRDD_ID from AssemblyTeamMember where APD_ID ='" + label_APD_ID.Text.Trim() + "' and LCS_ID='" + label_XilieID.Text.Trim() + "')");
            GridView_People.DataSource = ds3;
            GridView_People.DataBind();
            UpdatePanel_AddPeople.Update();

        }
        // databind4();
    }
    protected void Button_CloseDetail_Click(object sender, EventArgs e)
    {
        Panel_Detail.Visible = false;
        UpdatePanel_Detail.Update();
        TextBox_NO.Text = "";
        TextBox_Name.Text = "";
        TextBox_TotalNum.Text = "0.00";
    }
    protected void GridView_Detail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;
        GridView_Detail.SelectedIndex = -1;
        if (-1 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;

            GridViewRow pagerRow = GridView_Detail.BottomPagerRow;


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
        newPageIndex = newPageIndex >= GridView_Detail.PageCount ? GridView_Detail.PageCount - 1 : newPageIndex;
        GridView_Detail.PageIndex = newPageIndex;



        //pannel 各种隐藏

        Panel_Add.Visible = false;
        UpdatePanel_Add.Update();
        Panel_Search.Visible = true;
        databind3();
        TextBox_calculate_Time_Add.Text = "";
        GridView_Detail.SelectedIndex = -1;
        GridView_Detail.EditIndex = -1;
    }
    protected void GridView_Detail_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView_Detail.SelectedIndex = -1;
        GridView_Detail.EditIndex = -1;
        databind3();

        //panel 各种隐藏
    }
    protected void GridView_Detail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteDetail12345")//
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            try
            {
                wosl.D_AssemblyTeamMember_Detail(new Guid(e.CommandArgument.ToString().Trim()));
            }
            catch
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除失败！')", true);
                return;
            }
            GridView_Detail.SelectedIndex = -1;
            GridView_Detail.EditIndex = -1;
            //panel 各种隐藏
            databind3();
        }
    }
    protected void GridView_Detail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate)) || (e.Row.RowState == DataControlRowState.Edit))
        {
            TextBox curText;
            curText = (TextBox)e.Row.Cells[6].Controls[0];
            curText.Attributes.Add("style ", "width:60px;");
            for (int i = 6; i <= 6; i++)
            {

                ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("style", "ime-mode:disabled");
                ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("onkeyup", "if(isNaN(value))execCommand('undo')");
                ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("MaxLength", "9");
                ((TextBox)e.Row.Cells[i].Controls[0]).Attributes.Add("onafterpaste", "if(isNaN(value))execCommand('undo')");
                


            }
           

        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList d1 = ((DropDownList)(e.Row.FindControl("Dltype1111111111")));
            d1.DataSource = GetDs2();
            d1.DataTextField = "计件类型";
            d1.DataValueField = "SPI_ID";
            d1.DataBind();
            Label lb = ((Label)e.Row.FindControl("Ll6"));
            for (int i = 0; i < d1.Items.Count; i++)
            {
                if (d1.Items[i].Text == lb.Text.Trim())
                {
                    
                    d1.SelectedIndex = i;
                    break;

                }

            }
        }
    }
    protected void GridView_Detail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView_Detail.EditIndex = e.NewEditIndex;
        databind3();

        //panel 各种隐藏

    }


    protected void GridView_Detail_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            Guid ATM_ID = new Guid(GridView_Detail.DataKeys[e.RowIndex].Values["ATM_ID"].ToString());
            decimal t = ((TextBox)(GridView_Detail.Rows[e.RowIndex].Cells[3].Controls[0])).Text.Trim().ToString() == "" ? 0 : Convert.ToDecimal(((TextBox)(GridView_Detail.Rows[e.RowIndex].Cells[3].Controls[0])).Text.Trim().ToString());
            wosl.U_AssemblyTeamMember_Detail(ATM_ID, t);
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请您再次核对输入格式，时间为小数、数量为整数！')", true);
            return;
        }
        GridView_Detail.SelectedIndex = -1;
        GridView_Detail.EditIndex = -1;
        databind3();
    }
    protected void Button_AddPeopleSearch_Click(object sender, EventArgs e)
    {
        databind4();
    }
    protected void Button_AddPeopleCancel_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        databind4();
    }
    protected void Button_AddPeople_close_Click(object sender, EventArgs e)
    {
        Panel_AddPeople.Visible = false;
        UpdatePanel_AddPeople.Update();
    }
    protected void CheckBoxAll2_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= GridView_Detail.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView_Detail.Rows[i].FindControl("CheckBox2");
            if (CheckBox2.Checked == true)
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
    protected void Checkfanxuan2_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= GridView_Detail.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView_Detail.Rows[i].FindControl("CheckBox2");
            if (CheckBox.Checked == false)
            {
                CheckBox.Checked = true;
            }
            else
            {
                CheckBox.Checked = false;
            }
        }
        CheckBox2.Checked = false;
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
                    Guid lCS_ID = new Guid(label_XilieID.Text.Trim());
                    Guid aPD_ID = new Guid(label_APD_ID.Text.Trim());
                    Guid hrddid = new Guid(GridView_People.DataKeys[i].Values["HRDD_ID"].ToString().Trim());
                    wosl.I_AssemblyTeamMember_HRDDetail(hrddid, aPD_ID, lCS_ID);
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
        Checkfanxuan2.Checked = false;
        databind3();
        databind4();
        Panel_AddPeople.Visible = false;
        UpdatePanel_AddPeople.Update();

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
        GridView_People.PageIndex = newPageIndex;

        databind4();
    }
    protected void Button_save_Click(object sender, EventArgs e)//保存
    {
        Guid ATM_ID;
        Guid id;
        decimal t;
        for (int i = 0; i <= this.GridView_Detail.Rows.Count - 1; i++)
        {
            ATM_ID = new Guid(GridView_Detail.DataKeys[i].Values["ATM_ID"].ToString());

            try
            {
                t = ((TextBox)(GridView_Detail.Rows[i].FindControl("txtPlan"))).Text.Trim() == "" ? 0 : Convert.ToDecimal(((TextBox)(GridView_Detail.Rows[i].FindControl("txtPlan"))).Text.Trim());
                id = new Guid(((DropDownList)(GridView_Detail.Rows[i].FindControl("Dltype1111111111"))).SelectedValue.ToString().Trim());  
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请您再次核对输入格式，时间为小数、数量为整数！')", true);
                return;
            }
            ppd.U_AssemblyTeamMember_Detail_New(ATM_ID, t,id);
        }
        databind3();
        int n=0;  //extBox_TotalNum.Text
        n = Convert.ToInt32(TextBox_TotalNum0.Text.Trim());
       // databind3();
        ppd.U_Zhuangpeijijian_NEW(new Guid(label_APD_ID.Text.Trim()),new Guid(label_XilieID.Text.Trim()),n);
        GridView_Detail.SelectedIndex = -1;
        GridView_Detail.EditIndex = -1;
        databind3();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedIndex == 0)
        {
            DataSet ds2 = cs.CS_S_HRDDetail_people(" and a.HRDD_ID not in (select HRDD_ID from AssemblyTeamMember where APD_ID ='" + label_APD_ID.Text.Trim() + "' and LCS_ID='" + label_XilieID.Text.Trim() + "')");
            GridView_People.DataSource = ds2;
            GridView_People.DataBind();
            UpdatePanel_AddPeople.Update();

        }
        else
        {

            DataSet ds3 = cs.Cs_S_WorkTeamDetailList(" and WT_ID='" + this.DropDownList1.SelectedValue.ToString().Trim() + "'" + " and a.HRDD_ID not in (select HRDD_ID from AssemblyTeamMember where APD_ID ='" + label_APD_ID.Text.Trim() + "' and LCS_ID='" + label_XilieID.Text.Trim() + "')");
            GridView_People.DataSource = ds3;
            GridView_People.DataBind();
            UpdatePanel_AddPeople.Update();

        }
    }

    protected void DropDownList12_SelectedIndexChanged(object sender, EventArgs e)
    {
        
            if (DropDownList12.SelectedIndex == 0)
            {
                ppd.U_AssemblyTeamMember_Detail_LeiXing(new Guid(this.label_APD_ID.Text.Trim()),new Guid(label_XilieID.Text.Trim()), new Guid("00000000-0000-0000-0000-000000000000"));
                databind3();
            }
            else
            {

                ppd.U_AssemblyTeamMember_Detail_LeiXing(new Guid(this.label_APD_ID.Text.Trim()), new Guid(label_XilieID.Text.Trim()), new Guid(DropDownList12.SelectedValue.ToString().Trim()));
                databind3();
            }
        
    }
    protected void Button_Addman0_Click(object sender, EventArgs e)
    {
        Guid ATM_ID;
        decimal t;
        for (int i = 0; i <= this.GridView_Detail.Rows.Count - 1; i++)
        {
            ATM_ID = new Guid(GridView_Detail.DataKeys[i].Values["ATM_ID"].ToString());

            try
            {
                t = TextBox_Name0.Text.Trim() == "" ? 0 : Convert.ToDecimal(TextBox_Name0.Text.Trim());
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请您再次核对输入格式，时间为小数、数量为整数！')", true);
                return;
            }
            wosl.U_AssemblyTeamMember_Detail(ATM_ID, t);
        }
        databind3();
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
        Checkfanxuan2.Checked = false;
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
    protected void Button_AddPTToSeries_Click(object sender, EventArgs e)//删除员工
    {
        int sum = 0;


        for (int i = 0; i <= GridView_Detail.Rows.Count - 1; i++)
        {
            CheckBox CheckBox = (CheckBox)GridView_Detail.Rows[i].FindControl("CheckBox2");
            if (CheckBox.Checked == true)
            {
                try
                {
                    
                    wosl.D_AssemblyTeamMember_Detail(new Guid(GridView_Detail.DataKeys[i].Values["ATM_ID"].ToString().Trim()));
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
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('您没选择任何要删除的员工！，请您再核对！')", true);
            return;
        }

        CheckBox2.Checked = false;
        CheckBox3.Checked = false;
        databind3();
        databind4();
        Panel_AddPeople.Visible = false;
        UpdatePanel_AddPeople.Update();
    }
}