using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using NPOI;
using NPOI.HPSF;
using NPOI.HSSF;
using NPOI.HSSF.UserModel;
using NPOI.POIFS;
using NPOI.Util;
using System.Text;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;
using RTXHelper;

public partial class SalaryMgt_SalaryMonthCalculate : System.Web.UI.Page
{
    SalaryMonthCalculateL salaryMonthCalculateL = new SalaryMonthCalculateL();
    private static string Condition1;
    private static string Condition2;
    private static string Condition3;
    private static string Condition4;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserRole"] == null)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('您长时间未操作，请重新登录！')", true);
            Response.Redirect("~/Default.aspx");
        }
        #region//权限控制
        string Role = Request.QueryString["status"].ToString();
        if (!((Session["UserRole"].ToString().Contains("薪资月度结算")) || (Session["UserRole"].ToString().Contains("薪资月度审核"))))
        {
            Response.Redirect("~/Default.aspx");

        }
        if (Role == "MonthCalculate")
        {
            //this.GridView1.Columns[4].Visible = false;
            this.GridView1.Columns[22].Visible = false;
            this.Title = "薪资月度结算";

        }
        if (Role == "MonthAudit")
        {
            Button1.Visible = false;
            this.GridView1.Columns[13].Visible = false;
            this.GridView1.Columns[14].Visible = false;
            this.GridView1.Columns[15].Visible = false;
            this.GridView1.Columns[16].Visible = false;
            this.GridView1.Columns[20].Visible = false;
            this.GridView1.Columns[23].Visible = false;
            this.Title = "薪资月度审核";
        }
        if (Role == "MonthSearch")
        {
            Button1.Visible = false;
            this.GridView1.Columns[13].Visible = false;
            this.GridView1.Columns[14].Visible = false;
            this.GridView1.Columns[15].Visible = false;
            this.GridView1.Columns[16].Visible = false;
            //this.GridView1.Columns[19].Visible = false;
            this.GridView1.Columns[20].Visible = false;
            this.GridView1.Columns[22].Visible = false;
            this.GridView1.Columns[23].Visible = false;
            this.Title = "薪资月度查看";
        }

        #endregion
        if (!IsPostBack)
        {
            BindYear(DropDownList1);
            BindDdlMonth(DropDownList2);
            BindYear(DropDownList4);
            BindDdlMonth(DropDownList5);
            BindGrid(" ");
            //if (Role == "MonthCalculate" && Session["UserRole"].ToString().Contains("薪资月度结算"))
            //{
            //    BindGrid();//默认检索待办事项,待提交
            //    this.Title = "薪资月度结算";
            //    Panel1.Visible = true;
            //}
            //if (Role == "MonthAudit" && Session["UserRole"].ToString().Contains("薪资月度审核"))
            //{
            //    BindGrid1();//默认检索待办事项,待审核
            //    this.Title = "薪资月度审核";
            //    Panel1.Visible = false;
            //}
        }
    }


    #region//绑定Gridview
    private void BindGrid(string condition)
    {
        GridView1.DataSource = salaryMonthCalculateL.Search_SalaryEmpWageDetail_SalaryMonCalculate_NotShenHe(condition);
        GridView1.DataBind();
    }//绑定Gridview1的方法，允许多次调用
    private void BindGrid1()
    {
        GridView1.DataSource = salaryMonthCalculateL.Search_SearchForShenHe();
        GridView1.DataBind();
    }//绑定Gridview1的方法，允许多次调用
    private void BindGrid2(string condition)
    {
        GridView2.DataSource = salaryMonthCalculateL.Search_SalaryEmpWageDetail_NotShenHe_EachPersonTotal(" where SMC_ID= '" + Label30.Text + "'" + condition);
        GridView2.DataBind();
    }//绑定Gridview2的方法，允许多次调用

    private void BindGrid3()
    {
        string condition = " where SMC_Year= '" + Label4.Text + "' and SMC_Month='" + Label5.Text + "' and HRDD_ID='" + Label10.Text + "'";
        GridView3.DataSource = salaryMonthCalculateL.Search_SalaryEmpWageDetail_NotShenHe_EachPersonTotalDetail(condition);
        GridView3.DataBind();
    }//绑定GridView3的方法，允许多次调用Grid_Detail

    private void BindGrid_Detail(string cond)
    {
        Grid_Detail.DataSource = salaryMonthCalculateL.Search_SearchPersonNotInSet(cond);
        Grid_Detail.DataBind();
    }//绑定Grid_Detail的方法，允许多次调用

    private void BindGridView4(string cond)
    {
        GridView4.DataSource = salaryMonthCalculateL.Search_SearchPersonNotHavePerform(" and HRPD_Year= '" + DropDownList1.Text + "' and HRPD_Month='" + DropDownList2.Text + "') " + cond);
        GridView4.DataBind();
    }//绑定GridView4的方法，允许多次调用

    private void BindGridView5(string cond)
    {
        GridView5.DataSource = salaryMonthCalculateL.Search_SalaryPeopleIn(cond);
        GridView5.DataBind();
    }//绑定GridView5的方法，允许多次调用
    private void BindGridView6(string cond)
    {
        GridView6.DataSource = salaryMonthCalculateL.Search_SalaryPeopleOut("  and a.HRDD_ID NOT IN (SELECT HRDD_ID from SalaryDetailBivariateTable f,SalaryMonCalculate g where f.SMC_ID=g.SMC_ID and SMC_Year=" + Label54.Text + " and SMC_Month=" + Label64.Text + ")" + cond);
        GridView6.DataBind();
    }//绑定GridView6的方法，允许多次调用

    private void BindGridView8(string cond)
    {
        GridView8.DataSource = Search_FinalDetail("  and SDBT_Year= " + Label75.Text + " and SDBT_Month=" + Label76.Text + cond);
        GridView8.DataBind();
    }//绑定GridView8的方法，允许多次调用

    private DataSet Search_FinalDetail(string condition)
    {

        SqlParameter para = new SqlParameter("@Condition", condition);

        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_FinalDetail", para);

    }
    #endregion


    #region//动态绑定Dropdownlist
    private void BindYear(DropDownList ddl)//绑定年
    {
        ddl.Items.Clear();
        for (int m = 2012; m <= 2035; m++)
        {
            ddl.Items.Add(new ListItem(m.ToString(), m.ToString()));
        }
        ddl.Items.Insert(0, new ListItem("请选择", ""));
        ddl.DataBind();
    }

    private void BindDdlMonth(DropDownList ddl)//绑定月份
    {
        ddl.Items.Clear();
        for (int m = 1; m <= 12; m++)
        {
            ddl.Items.Add(new ListItem(m.ToString(), m.ToString()));
        }
        ddl.Items.Insert(0, new ListItem("请选择", ""));
        ddl.DataBind();
    }
    #endregion

    #region//月度工资结算选择栏
    protected void BtnMonthCalculate_Click(object sender, EventArgs e)
    {
        Label31.Visible = true;
        Label32.Visible = true;
        Label33.Visible = true;
        Label34.Visible = true;
        UpdatePanel1.Update();
        if (TxtStartDate.Text == "" || TextBox1.Text == "" || DropDownList1.Text == "" || DropDownList2.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        try
        {
            SalaryMonthCalculateInfo salaryMonthCalculateInfo = new SalaryMonthCalculateInfo();
            if (TxtStartDate.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('必须选择：开始日期！')", true);
                return;
            }
            else
            {
                DateTime d1;
                if (DateTime.TryParse(TxtStartDate.Text, out d1))
                    salaryMonthCalculateInfo.SEWD_StartDate = d1;
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('开始日期格式不正确！')", true);
                    return;
                }
            }

            if (TextBox1.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('必须选择：截止日期！')", true);
                return;
            }
            else
            {
                DateTime d2;
                if (DateTime.TryParse(TextBox1.Text, out d2))
                    salaryMonthCalculateInfo.SEWD_EndDate = d2;
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('截止日期格式不正确！')", true);
                    return;
                }
            }
            if (DropDownList1.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('请选择计算的月度工资所属的年份！')", true);
                return;
            }
            else
            {
                int i1;
                if (int.TryParse(DropDownList1.Text, out i1))
                    salaryMonthCalculateInfo.SEWD_Year = i1;
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('年份格式不正确！')", true);
                    return;
                }
            }

            if (DropDownList2.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('请选择计算的月度工资所属的月份！')", true);
                return;
            }
            else
            {
                int i2;
                if (int.TryParse(DropDownList2.Text, out i2))
                    salaryMonthCalculateInfo.SEWD_Month = i2;
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('月份格式不正确！')", true);
                    return;
                }
            }
            salaryMonthCalculateInfo.SMC_Person = Session["UserName"].ToString().Trim();
            DateTime dt1 = DateTime.Parse(TxtStartDate.Text.ToString());
            DateTime dt2 = DateTime.Parse(TextBox1.Text.ToString());
            string Validdate1 = dt1.Year.ToString() + dt1.Month.ToString();
            string Validdate2 = dt2.Year.ToString() + dt2.Month.ToString();
            string thedate = DropDownList1.Text + DropDownList2.Text;
            if (thedate != Validdate1 && thedate != Validdate2)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('请选择合理的年份、月份！')", true);
                return;
            }

            #region//验证是否有绩效成绩
            //DataSet ds = salaryMonthCalculateL.Search_SearchPersonNotHavePerform(" and HRPD_Year= '" + DropDownList1.Text + "' and HRPD_Month='" + DropDownList2.Text + "') ");
            //if (ds.Tables[0].Rows.Count > 0)//当月存在还没有录入绩效最终成绩的员工
            //{
            //    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('当月有员工没有绩效，请先录入绩效分数！')", true);
            //    return;
            //}
            #endregion

            DataSet dset = salaryMonthCalculateL.Search_SearchPersonNotInSet("");
            int count = dset.Tables[0].Rows.Count;
            salaryMonthCalculateL.Insert_SalaryMonthCalculate(salaryMonthCalculateInfo);//插入主表的信息
            BindGrid("");
            UpdatePanel2.Update();
            if (count > 0)//存在没有在账套中的员工
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert(\"有" + count + "名在职员工不在账套中!您可以加入账套并筛选员工！\")", true);

            }
            else
            {
                Panel1.Visible = false;
                UpdatePanel1.Update();
            }
        }
        catch (Exception)
        {

            throw;
        }

    }

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
        if (LblRecordIsSearch.Text == "检索后")
            BindGrid(Condition1);
        if (LblRecordIsSearch.Text == "检索前")
            BindGrid("");
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= this.GridView1.PageCount ? this.GridView1.PageCount - 1 : newPageIndex;
        this.GridView1.PageIndex = newPageIndex;
        this.GridView1.DataBind();
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
        string[] StrArgument = e.CommandArgument.ToString().Split(new char[] { ',' });
        if (e.CommandName == "ChoosePeople")
        {
            GridView1.SelectedIndex = gvr.RowIndex;

            if (!(StrArgument[7].ToString() == "待提交"))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('此状态下的信息不允许筛选员工！')", true);
                return;
            }
            BindGridView5("");
            TextBox15.Text = "";
            TextBox16.Text = "";
            TextBox17.Text = "";
            TextBox18.Text = "";
            LblYear.Text = StrArgument[1];
            LblMonth.Text = StrArgument[2];
            LblTime.Text = StrArgument[12];
            Label53.Text = StrArgument[0];
            LblIsSearch.Text = "检索前";
            Panel8.Visible = true;
            UpdatePanel8.Update();
            if (Panel10.Visible && Label53.Text != Label73.Text)
            {
                Panel10.Visible = false;
                UpdatePanel10.Update();//EXCEL结算
            }
            if (Panel3.Visible)
            {
                Panel3.Visible = false;
                UpdatePanel3.Update();//查看初步结算结果
            }
            if (Panel1tongji.Visible && Label53.Text != Label74.Text)
            {
                Panel1tongji.Visible = false;
                this.UpdatePaneltongji.Update();//d多维统计
            }
            if (Panel4.Visible)
            {
                Panel4.Visible = false;
                UpdatePanel4.Update();
            }
            if (PanelShenHe.Visible && Label53.Text != Label8.Text)
            {
                PanelShenHe.Visible = false;
                UpdatePanelShenHe.Update();//查看审核
            }
            if (Panel5.Visible)
            {
                Panel5.Visible = false;
                UpdatePanel5.Update();
            }
            if (Panel_SearchEmployee.Visible)
            {
                Panel_SearchEmployee.Visible = false;
                UpdatePanel_SearchEmployee.Update();
            }
            if (Panel7.Visible)
            {
                Panel7.Visible = false;
                UpdatePanel7.Update();
            }

        }

        if (e.CommandName == "AutoCal")
        {

            if (!(StrArgument[7].ToString() == "待提交"))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('此状态下的信息不允许进行初步结算！')", true);
                return;
            }
            GridView1.SelectedIndex = gvr.RowIndex;
            try
            {
                SalaryMonthCalculateInfo salaryMonthCalculateInfo = new SalaryMonthCalculateInfo();
                salaryMonthCalculateInfo.SEWD_StartDate = Convert.ToDateTime(StrArgument[4]);
                DateTime d1 = Convert.ToDateTime(StrArgument[4]);
                salaryMonthCalculateInfo.SEWD_EndDate = Convert.ToDateTime(StrArgument[5]);
                salaryMonthCalculateInfo.SEWD_Year = Convert.ToInt16(StrArgument[1]);
                salaryMonthCalculateInfo.SEWD_Month = Convert.ToInt16(StrArgument[2]);
                salaryMonthCalculateInfo.SMC_ID = new Guid(StrArgument[0]);
                salaryMonthCalculateL.Insert_SalaryMonthCalculateForAll(salaryMonthCalculateInfo);
            }
            catch (Exception)
            {

                throw;
            }
            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('已完成初步结算！')", true);
            if (LblRecordIsSearch.Text == "检索后")
                BindGrid(Condition1);
            if (LblRecordIsSearch.Text == "检索前")
                BindGrid("");
            if (Panel8.Visible)
            {
                Panel8.Visible = false;
                UpdatePanel8.Update();//筛选员工
            }
            if (Panel9.Visible)
            {
                Panel9.Visible = false;
                UpdatePanel9.Update();//员工新增
            }
            if (Panel10.Visible)
            {
                Panel10.Visible = false;
                UpdatePanel10.Update();//EXCEL结算
            }
            if (Panel3.Visible)
            {
                Panel3.Visible = false;
                UpdatePanel3.Update();//查看初步结算结果
            }
            if (Panel1tongji.Visible)
            {
                Panel1tongji.Visible = false;
                this.UpdatePaneltongji.Update();//d多维统计
            }
            if (PanelShenHe.Visible)
            {
                PanelShenHe.Visible = false;
                UpdatePanelShenHe.Update();//查看审核
            }
        }

        #region
        if (e.CommandName == "EditDetail1")
        {
            GridView1.SelectedIndex = gvr.RowIndex;

            if (!(StrArgument[7].ToString() == "待提交"))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('此状态下的信息不允进行最终结算！')", true);
                return;
            }
            Response.Redirect("../SalaryMgt/SalaryEditDetail.aspx?status=Detail" + "&SMC_ID=" + StrArgument[0].ToString());
            if (Panel_SearchEmployee.Visible)
            {
                Panel_SearchEmployee.Visible = false;
                UpdatePanel_SearchEmployee.Update();
            }
            if (Panel7.Visible)
            {
                Panel7.Visible = false;
                UpdatePanel7.Update();
            }

        }
        #endregion

        if (e.CommandName == "submitForShenhe")
        {
            string S = StrArgument[6].ToString() + StrArgument[7].ToString();
            if (!(StrArgument[7].ToString() == "待提交"))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('提交失败，此状态下的信息不允许提交审核！')", true);
                return;
            }
            GridView1.SelectedIndex = gvr.RowIndex;
            SalaryMonthCalculateInfo salaryMonthCalculateInfo = new SalaryMonthCalculateInfo();
            salaryMonthCalculateInfo.SMC_ID = new Guid(StrArgument[0].ToString());
            salaryMonthCalculateL.Insert_SalaryRelationshipsTable(salaryMonthCalculateInfo);
            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('已提交！')", true);

            //RTX
            string message = "ERP系统消息：" + Session["UserName"].ToString() + "(提交人)于" + DateTime.Now.ToString("F") + "（日期）完成了" + StrArgument[1] + "年" + StrArgument[2] + "月的月度工资计算，请审核！";
            string sErr = RTXhelper.Send(message, "薪资月度审核");
            if (!string.IsNullOrEmpty(sErr))
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('" + sErr + "')", true);
            }
            if (LblRecordIsSearch.Text == "检索后")
                BindGrid(Condition1);
            if (LblRecordIsSearch.Text == "检索前")
                BindGrid("");


            UpdatePanel2.Update();

            if (Panel4.Visible)
            {
                Panel4.Visible = false;
                UpdatePanel4.Update();
            }

            if (Panel5.Visible)
            {
                Panel5.Visible = false;
                UpdatePanel5.Update();
            }
            if (Panel_SearchEmployee.Visible)
            {
                Panel_SearchEmployee.Visible = false;
                UpdatePanel_SearchEmployee.Update();
            }
            if (Panel7.Visible)
            {
                Panel7.Visible = false;
                UpdatePanel7.Update();
            }
            if (Panel8.Visible)
            {
                Panel8.Visible = false;
                UpdatePanel8.Update();//筛选员工
            }
            if (Panel9.Visible)
            {
                Panel9.Visible = false;
                UpdatePanel9.Update();//员工新增
            }
            if (Panel10.Visible)
            {
                Panel10.Visible = false;
                UpdatePanel10.Update();//EXCEL结算
            }
            if (Panel3.Visible)
            {
                Panel3.Visible = false;
                UpdatePanel3.Update();//查看初步结算结果
            }
            if (Panel1tongji.Visible)
            {
                Panel1tongji.Visible = false;
                this.UpdatePaneltongji.Update();//d多维统计
            }
            if (PanelShenHe.Visible)
            {
                PanelShenHe.Visible = false;
                UpdatePanelShenHe.Update();//查看审核
            }
        }
        if (e.CommandName == "Excel")
        {
            if (!(StrArgument[7].ToString() == "待提交"))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('提交失败，此状态下的信息不允许进行EXCEL结算！')", true);
                return;
            }
            GridView1.SelectedIndex = gvr.RowIndex;
            Panel10.Visible = true;
            Label66.Text = StrArgument[1].ToString();
            Label67.Text = StrArgument[2].ToString();
            Label68.Text = StrArgument[0].ToString();
            ButtonDeleteSalary.Text = "删除" + StrArgument[1].ToString() + "年" + StrArgument[2].ToString() + "月工资";
            UpdatePanel10.Update();
			if(LblMessage.Visible)
				LblMessage.Visible=false;
            if (Panel8.Visible && Label68.Text != Label60.Text)
            {
                Panel8.Visible = false;
                UpdatePanel8.Update();//筛选员工
            }
            if (Panel9.Visible)
            {
                Panel9.Visible = false;
                UpdatePanel9.Update();//员工新增
            }

            if (Panel3.Visible)
            {
                Panel3.Visible = false;
                UpdatePanel3.Update();//查看初步结算结果
            }
            if (Panel1tongji.Visible)
            {
                Panel1tongji.Visible = false;
                this.UpdatePaneltongji.Update();//d多维统计
            }
            if (PanelShenHe.Visible && Label68.Text != Label8.Text)
            {
                PanelShenHe.Visible = false;
                UpdatePanelShenHe.Update();//查看审核
            }
        }
        if (e.CommandName == "LookWageDetail")
        {
            GridView1.SelectedIndex = gvr.RowIndex;
            Panel3.Visible = true;
            UpdatePanel3.Update();
            Label4.Text = StrArgument[1].ToString();
            Label5.Text = StrArgument[2].ToString();
            Label30.Text = StrArgument[0].ToString();
            try
            {

                BindGrid2("");
                //GridView2.Columns[4].Visible = false;
                //GridView2.Columns[5].Visible = true;
            }
            catch (Exception)
            {

                throw;
            }
            if (Panel_SearchEmployee.Visible)
            {
                Panel_SearchEmployee.Visible = false;
                UpdatePanel_SearchEmployee.Update();
            }
            if (Panel7.Visible)
            {
                Panel7.Visible = false;
                UpdatePanel7.Update();
            }
            if (Panel8.Visible)
            {
                Panel8.Visible = false;
                UpdatePanel8.Update();//筛选员工
            }
            if (Panel9.Visible)
            {
                Panel9.Visible = false;
                UpdatePanel9.Update();//员工新增
            }
            if (Panel10.Visible)
            {
                Panel10.Visible = false;
                UpdatePanel10.Update();//EXCEL结算
            }
            if (Panel1tongji.Visible)
            {
                Panel1tongji.Visible = false;
                this.UpdatePaneltongji.Update();//d多维统计
            }
            if (PanelShenHe.Visible && Label30.Text != Label8.Text)
            {
                PanelShenHe.Visible = false;
                UpdatePanelShenHe.Update();//查看审核
            }
        }
        if (e.CommandName == "LookDetail")
        {
            GridView1.SelectedIndex = gvr.RowIndex;
            //绑定已有的审核信息
            try
            {
                //SalaryMonthCalculateInfo salaryMonthCalculateInfo = new SalaryMonthCalculateInfo();
                //salaryMonthCalculateInfo.SMC_ID = new Guid(StrArgument[0].ToString());
                //string a = StrArgument[0].ToString();
                //DataSet ds = salaryMonthCalculateL.Search_SearchShenHeDetail(salaryMonthCalculateInfo);
                PanelShenHe.Visible = true;
                DropDownList3.Visible = false;
                TextBox5.Visible = true;
                //if (StrArgument[7].ToString() == "待提交" || StrArgument[7].ToString() == "待提交")
                //{
                //    TextBox2.Text = "";
                //    TxtETime.Text = "";
                //    //DropDownList3.Items.FindByText(col[3].ToString()).Selected = true;
                //    TextBox5.Text = "";
                //    TxtRemarks.Text = "";
                //}
                //else
                //    foreach (DataRow col in ds.Tables[0].Rows)
                //    {
                TextBox2.Text = StrArgument[8].ToString();
                TxtETime.Text = StrArgument[9].ToString();
                //DropDownList3.Items.FindByText(col[3].ToString()).Selected = true;
                TextBox5.Text = StrArgument[6].ToString();
                TxtRemarks.Text = StrArgument[10].ToString();
                //}
                Label8.Text = StrArgument[0].ToString();
                Label6.Text = StrArgument[1].ToString();
                Label11.Text = StrArgument[2].ToString();
                BtnSubmitChange.Visible = false;
                BtnCancelChange.Visible = false;
                BtnClose.Visible = true;
                UpdatePanelShenHe.Update();
            }
            catch (Exception)
            {

                throw;
            }

        }
        if (e.CommandName == "FinalWageDetail")
        {
            GridView1.SelectedIndex = gvr.RowIndex;
            PanelDetail.Visible = true;
            try
            {

                Label81.Text = StrArgument[0].ToString();
                Label75.Text = StrArgument[1].ToString();
                Label76.Text = StrArgument[2].ToString();
                int i = 39;
                foreach (Control chk in this.PanelDetail.Controls)
                {

                    string checkname = chk.ID;
                    if (checkname == "CheckBox" + i)
                    {
                        ((CheckBox)chk).Checked = true;
                        i++;
                    }

                }
                LblRecordCondition.Text = "";
                TextBox25.Text = "";
                TextBox26.Text = "";
                TextBox27.Text = "";
                TextBox28.Text = "";

                BindGridView8("");
                UpdatePanelDetail.Update();
            }
            catch (Exception)
            {

                throw;
            }
            if (Panel4.Visible)
            {
                Panel4.Visible = false;
                UpdatePanel4.Update();
            }

            if (Panel5.Visible)
            {
                Panel5.Visible = false;
                UpdatePanel5.Update();
            }
            if (Panel_SearchEmployee.Visible)
            {
                Panel_SearchEmployee.Visible = false;
                UpdatePanel_SearchEmployee.Update();
            }
            if (Panel7.Visible)
            {
                Panel7.Visible = false;
                UpdatePanel7.Update();
            }
            if (Panel8.Visible)
            {
                Panel8.Visible = false;
                UpdatePanel8.Update();//筛选员工
            }
            if (Panel9.Visible)
            {
                Panel9.Visible = false;
                UpdatePanel9.Update();//员工新增
            }
            if (Panel10.Visible)
            {
                Panel10.Visible = false;
                UpdatePanel10.Update();//EXCEL结算
            }
            if (Panel3.Visible)
            {
                Panel3.Visible = false;
                UpdatePanel3.Update();//查看初步结算结果
            }
            if (Panel1tongji.Visible)
            {
                Panel1tongji.Visible = false;
                this.UpdatePaneltongji.Update();//d多维统计
            }
            if (PanelShenHe.Visible)
            {
                PanelShenHe.Visible = false;
                UpdatePanelShenHe.Update();//查看审核
            }
        }
        if (e.CommandName == "TongJi")
        {
            Panel1tongji.Visible = true;
            UpdatePaneltongji.Update();
            GridView1.SelectedIndex = gvr.RowIndex;
            Label69.Text = StrArgument[1];
            Label70.Text = StrArgument[2];
            Label74.Text = StrArgument[0];
            TextBox29.Text = "";
            int i = 1;
            foreach (Control chk in this.Panel1tongji.Controls)
            {

                string checkname = chk.ID;
                if (checkname == "CheckBox" + i)
                {
                    ((CheckBox)chk).Checked = false;
                    GridView7.Columns[i].Visible = true;
                    i++;
                }

            }
            GridView7.DataSource = null;
            GridView7.DataBind();
            if (Panel8.Visible)
            {
                Panel8.Visible = false;
                UpdatePanel8.Update();//筛选员工
            }
            if (Panel9.Visible)
            {
                Panel9.Visible = false;
                UpdatePanel9.Update();//员工新增
            }
            if (Panel10.Visible)
            {
                Panel10.Visible = false;
                UpdatePanel10.Update();//EXCEL结算
            }
            if (Panel3.Visible)
            {
                Panel3.Visible = false;
                UpdatePanel3.Update();//查看初步结算结果
            }
            if (PanelShenHe.Visible && Label74.Text != Label8.Text)
            {
                PanelShenHe.Visible = false;
                UpdatePanelShenHe.Update();//查看审核
            }
        }

        if (e.CommandName == "ShenHe")
        {
            GridView1.SelectedIndex = gvr.RowIndex;
            if (StrArgument[7].ToString() != "待审核")
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('审核失败，只能审核待审核状态的信息！')", true);
                return;
            }
            PanelShenHe.Visible = true;
            TextBox5.Visible = false;
            DropDownList3.Visible = true;
            Label8.Text = StrArgument[0].ToString();
            BtnClose.Visible = false;
            UpdatePanelShenHe.Update();
            TextBox2.Text = Session["Username"].ToString();
            TxtETime.Text = DateTime.Now.ToString();
            BtnClose.Visible = false;
            BtnSubmitChange.Visible = true;
            BtnCancelChange.Visible = true;
            Label6.Text = StrArgument[1].ToString();
            Label11.Text = StrArgument[2].ToString();

            if (Panel8.Visible)
            {
                Panel8.Visible = false;
                UpdatePanel8.Update();//筛选员工
            }
            if (Panel9.Visible)
            {
                Panel9.Visible = false;
                UpdatePanel9.Update();//员工新增
            }
            if (Panel10.Visible)
            {
                Panel10.Visible = false;
                UpdatePanel10.Update();//EXCEL结算
            }
            if (Panel3.Visible)
            {
                Panel3.Visible = false;
                UpdatePanel3.Update();//查看初步结算结果
            }
            if (Panel1tongji.Visible && Label8.Text != Label74.Text)
            {
                Panel1tongji.Visible = false;
                this.UpdatePaneltongji.Update();//d多维统计
            }
        }
        if (e.CommandName == "Delete_Set")
        {
            if (!(StrArgument[7].ToString() == "待提交" || StrArgument[7].ToString() == "不通过"))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('此状态下的信息不允许删除！')", true);
                return;
            }
            GridView1.SelectedIndex = -1;
            try
            {
                SalaryMonthCalculateInfo salaryMonthCalculateInfo = new SalaryMonthCalculateInfo();
                string[] str = e.CommandArgument.ToString().Split(new char[] { ',' });
                salaryMonthCalculateInfo.SMC_ID = new Guid(StrArgument[0]);

                int i = salaryMonthCalculateL.Delete_SalaryItemTable(salaryMonthCalculateInfo);
                if (i > 0)
                    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('删除成功！')", true);
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('删除失败，请联系管理员！')", true);
                    return;
                }
            }
            catch (Exception)
            {

                throw;
            }

            if (LblRecordIsSearch.Text == "检索后")
                BindGrid(Condition1);
            if (LblRecordIsSearch.Text == "检索前")
                BindGrid("");
            UpdatePanel2.Update();
            if (Panel_SearchEmployee.Visible)
            {
                Panel_SearchEmployee.Visible = false;
                UpdatePanel_SearchEmployee.Update();
            }
            if (Panel7.Visible)
            {
                Panel7.Visible = false;
                UpdatePanel7.Update();
            }
            if (Panel1.Visible)
            {
                Panel1.Visible = false;
                UpdatePanel1.Update();
            }
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
            if (Panel5.Visible)
            {
                Panel5.Visible = false;
                UpdatePanel5.Update();
            }
            if (PanelShenHe.Visible)
            {
                PanelShenHe.Visible = false;
                UpdatePanelShenHe.Update();
            }
            if (Panel8.Visible)
            {
                Panel8.Visible = false;
                UpdatePanel8.Update();//筛选员工
            }
            if (Panel9.Visible)
            {
                Panel9.Visible = false;
                UpdatePanel9.Update();//员工新增
            }
            if (Panel10.Visible)
            {
                Panel10.Visible = false;
                UpdatePanel10.Update();//EXCEL结算
            }
            if (Panel3.Visible)
            {
                Panel3.Visible = false;
                UpdatePanel3.Update();//查看初步结算结果
            }
            if (Panel1tongji.Visible)
            {
                Panel1tongji.Visible = false;
                this.UpdatePaneltongji.Update();//d多维统计
            }
            if (PanelShenHe.Visible)
            {
                PanelShenHe.Visible = false;
                UpdatePanelShenHe.Update();//查看审核
            }
        }
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
        if (Label48.Text == "检索前")
            BindGrid2("");
        if (Label48.Text == "检索后")
            BindGrid2(Condition4);

        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= this.GridView2.PageCount ? this.GridView2.PageCount - 1 : newPageIndex;
        this.GridView2.PageIndex = newPageIndex;
        this.GridView2.DataBind();
    }
    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
        if (e.CommandName == "EditDetail2")
        {
            GridView2.SelectedIndex = gvr.RowIndex;
            Panel4.Visible = true;
            UpdatePanel4.Update();
            Label9.Text = GridView2.Rows[gvr.RowIndex].Cells[2].Text.ToString();
            Label10.Text = e.CommandArgument.ToString();
            try
            {
                BindGrid3();
                //BindGrid2();
                //UpdatePanel3.Update();
            }
            catch (Exception)
            {

                throw;
            }
            GridView3.Columns[3].Visible = true;
        }
        if (e.CommandName == "SearchDetail")
        {
            GridView2.SelectedIndex = gvr.RowIndex;
            Panel4.Visible = true;
            UpdatePanel4.Update();
            Label9.Text = GridView2.Rows[gvr.RowIndex].Cells[2].Text.ToString();
            Label10.Text = e.CommandArgument.ToString();
            try
            {
                BindGrid3();
                //BindGrid2();
                //UpdatePanel3.Update();
            }
            catch (Exception)
            {

                throw;
            }
            GridView3.Columns[3].Visible = false;
        }
    }
    #endregion

    #region//GridView3的内置事件
    protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
        if (e.CommandName == "Edit_Item")
        {
            GridView3.SelectedIndex = gvr.RowIndex;
            //弹出编辑框
            //
            Panel5.Visible = true;
            TextBox3.Text = GridView3.Rows[gvr.RowIndex].Cells[1].Text.ToString();
            TextBox4.Text = GridView3.Rows[gvr.RowIndex].Cells[2].Text.ToString();
            UpdatePanel5.Update();
            Label21.Text = e.CommandArgument.ToString();
        }
    }
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

        BindGrid3();

        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= this.GridView3.PageCount ? this.GridView3.PageCount - 1 : newPageIndex;
        this.GridView3.PageIndex = newPageIndex;
        this.GridView3.DataBind();
    }
    #endregion

    #region//月度工资审核栏
    protected void BtnSubmitChange_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text == "" || TxtETime.Text == "" || DropDownList3.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        try
        {
            SalaryMonthCalculateInfo salaryMonthCalculateInfo = new SalaryMonthCalculateInfo();
            salaryMonthCalculateInfo.SMC_Auditor = TextBox2.Text;
            salaryMonthCalculateInfo.SMC_AuRes = DropDownList3.SelectedValue;
            salaryMonthCalculateInfo.SMC_AuSugg = TxtRemarks.Text;
            salaryMonthCalculateInfo.SMC_ID = new Guid(Label8.Text);

            salaryMonthCalculateL.Insert_SalaryMonCalculate(salaryMonthCalculateInfo);
            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('已提交！')", true);

            if (salaryMonthCalculateInfo.SMC_AuRes == "不通过")
            {
                //RTX
                string message = "ERP系统消息：" + Session["UserName"].ToString() + "(提交人)于" + DateTime.Now.ToString("F") + "（日期）完成了" + Label6.Text + "年" + Label11.Text + "月的月度工资审核，审核结果为不通过，请查看！";
                string sErr = RTXhelper.Send(message, "薪资月度结算");
                if (!string.IsNullOrEmpty(sErr))
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('" + sErr + "')", true);
                }
            }

            if (LblRecordIsSearch.Text == "检索后")
                BindGrid(Condition1);
            if (LblRecordIsSearch.Text == "检索前")
                BindGrid("");
            PanelShenHe.Visible = false;
            TextBox2.Text = "";
            TxtETime.Text = "";
            DropDownList3.ClearSelection();
            TxtRemarks.Text = "";
            UpdatePanel2.Update();
            UpdatePanelShenHe.Update();
        }
        catch (Exception)
        {

            throw;
        }

    }//提交
    protected void BtnClose_Click(object sender, EventArgs e)
    {
        PanelShenHe.Visible = false;
        UpdatePanelShenHe.Update();
    }//关闭
    protected void BtnCancelChange_Click(object sender, EventArgs e)
    {
        PanelShenHe.Visible = false;
        UpdatePanelShenHe.Update();
        TextBox2.Text = "";
        TxtETime.Text = "";
        DropDownList3.ClearSelection();
        TxtRemarks.Text = "";
    }//取消
    #endregion

    #region//工资项目月度值编辑
    protected void ButtonSubmitForEdit_Click(object sender, EventArgs e)
    {
        if (TextBox4.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        SalaryMonthCalculateInfo salaryMonthCalculateInfo = new SalaryMonthCalculateInfo();
        salaryMonthCalculateInfo.SEWD_ID = new Guid(Label21.Text);
        salaryMonthCalculateInfo.SMC_ID = new Guid(Label30.Text);

        decimal m1;
        if (decimal.TryParse(TextBox4.Text, out m1))
            salaryMonthCalculateInfo.SEWD_ItemWage = m1;
        else
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('请输入正确的月度值！')", true);
            return;
        }
        int i = salaryMonthCalculateL.Update_SalaryEmpWageDetail_EachPersonDetail(salaryMonthCalculateInfo);
        if (i == -1)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('编辑失败！')", true);
            return;
        }
        if (i == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('该项目不允许进行编辑，其值由计算公式而来！')", true);
            return;
        }
        if (i == 2)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('计时工资不允许进行编辑！')", true);
            return;
        }
        if (i == 3)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('计件工资不允许进行编辑！')", true);
            return;
        }
        if (i == 1)
        {
            Panel5.Visible = false;
            UpdatePanel5.Update();
            BindGrid3();
            BindGrid("");
            if (Label48.Text == "检索前")
                BindGrid2("");
            if (Label48.Text == "检索后")
                BindGrid2(Condition4);
            UpdatePanel2.Update();
            UpdatePanel3.Update();
            UpdatePanel4.Update();
        }
    }//提交

    protected void ButtonCancelForEdit_Click(object sender, EventArgs e)
    {
        Panel5.Visible = false;
        TextBox3.Text = "";
        TextBox4.Text = "";
        UpdatePanel5.Update();
    }//取消
    #endregion

    #region//XXXX年XX月
    protected void Button8_Click(object sender, EventArgs e)
    {
        GridView2.SelectedIndex = -1;
        Condition4 = TextBox13.Text.Trim() == "" ? " " : " and HRDD_StaffNO = '" + TextBox13.Text.Trim() + "' ";
        Condition4 += TextBox14.Text.Trim() == "" ? " " : " and HRDD_Name like '%" + TextBox14.Text.Trim() + "%' ";
        Label48.Text = "检索后";
        BindGrid2(Condition4);
        UpdatePanel3.Update();
    }//检索
    protected void Button9_Click(object sender, EventArgs e)
    {
        TextBox13.Text = "";
        TextBox14.Text = "";
        Label48.Text = "检索前";
        GridView2.SelectedIndex = -1;
        BindGrid2("");
    }//重置


    protected void BtnClosePanel3_Click(object sender, EventArgs e)
    {
        Panel3.Visible = false;
        UpdatePanel3.Update();
        if (Panel4.Visible)
        {
            Panel4.Visible = false;
            UpdatePanel4.Update();
        }
        if (Panel5.Visible)
        {
            Panel5.Visible = false;
            UpdatePanel5.Update();
        }
    }//关闭
    #endregion

    #region//XXXX工资项目列表xx
    protected void BtnClosePanel4_Click(object sender, EventArgs e)
    {
        Panel4.Visible = false;
        UpdatePanel4.Update();
        if (Panel5.Visible)
        {
            Panel5.Visible = false;
            UpdatePanel5.Update();
        }
    }//关闭
    #endregion


    #region//检索栏
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        GridView1.SelectedIndex = -1;
        Condition1 = TextBox6.Text.Trim() == "" ? " " : " and SMC_StartDate >= '" + TextBox6.Text.Trim() + "' ";
        Condition1 += TextBox7.Text.Trim() == "" ? " " : " and SMC_EndDate <= '" + TextBox7.Text.Trim() + "' ";
        Condition1 += DropDownList4.Text.Trim() == "" ? " " : " and SMC_Year= '" + DropDownList4.Text.Trim() + "' ";
        Condition1 += DropDownList5.Text.Trim() == "" ? " " : " and SMC_Month = '" + DropDownList5.Text.Trim() + "' ";

        Condition1 += DropDownList7.Text.Trim() == "请选择" ? " " : " and SMC_State = '" + DropDownList7.SelectedValue.ToString() + "'";
        LblRecordIsSearch.Text = "检索后";
        BindGrid(Condition1);
        UpdatePanel2.Update();
    }//检索
    protected void Button1_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        UpdatePanel1.Update();
        TxtStartDate.Text = "";
        TextBox1.Text = "";
        DropDownList1.ClearSelection();
        DropDownList2.ClearSelection();
    }//新增月度结算
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        TextBox6.Text = "";
        TextBox7.Text = "";
        DropDownList4.ClearSelection();
        DropDownList5.ClearSelection();
        DropDownList7.ClearSelection();
        LblRecordIsSearch.Text = "检索前";
        GridView1.SelectedIndex = -1;
        BindGrid("");
        UpdatePanel2.Update();
    }//重置
    #endregion

    #region//月度工资结算选择栏
    protected void Button2_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        UpdatePanel1.Update();
        if (Panel_SearchEmployee.Visible)
        {
            Panel_SearchEmployee.Visible = false;
            UpdatePanel_SearchEmployee.Update();
        }
        if (Panel7.Visible)
        {
            Panel7.Visible = false;
            UpdatePanel7.Update();
        }
    }//关闭
    protected void Button3_Click(object sender, EventArgs e)
    {
        TxtSearchStaffNO.Text = "";
        TxtSearchName.Text = "";
        Panel_SearchEmployee.Visible = true;
        UpdatePanel_SearchEmployee.Update();
        BindGrid_Detail("");
    }//检索账套外员工
    protected void Button4_Click(object sender, EventArgs e)
    {
        Label31.Visible = false;
        Label32.Visible = false;
        Label33.Visible = true;
        Label34.Visible = true;
        UpdatePanel1.Update();
        if (DropDownList1.Text == "" || DropDownList2.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        Label40.Text = DropDownList1.Text + "年";
        Label41.Text = DropDownList2.Text + "月-";
        TextBox8.Text = "";
        TextBox9.Text = "";
        TextBox10.Text = "";
        TextBox11.Text = "";
        TextBox12.Text = "";
        Panel7.Visible = true;
        UpdatePanel7.Update();
        BindGridView4("");
    }//检索未打绩效成绩员工
    #endregion

    #region//账套外的员工信息栏
    protected void BtnSearchEmployee_Click(object sender, EventArgs e)
    {
        Grid_Detail.SelectedIndex = -1;
        Condition2 = TxtSearchStaffNO.Text.Trim() == "" ? " " : " and HRDD_StaffNO = '" + TxtSearchStaffNO.Text.Trim() + "' ";
        Condition2 += TxtSearchName.Text.Trim() == "" ? " " : " and HRDD_Name like '%" + TxtSearchName.Text.Trim() + "%' ";
        LblBindSAS_ASID.Text = "检索后";
        BindGrid_Detail(Condition2);
        UpdatePanel_SearchEmployee.Update();
    }//检索
    protected void BtnResetEmployee_Click(object sender, EventArgs e)
    {
        TxtSearchStaffNO.Text = "";
        TxtSearchName.Text = "";
        LblBindSAS_ASID.Text = "检索前";
        Grid_Detail.SelectedIndex = -1;
        BindGrid_Detail("");
    }//重置
    protected void BtnClosePanel_SearchEmployee_Click(object sender, EventArgs e)
    {
        Panel_SearchEmployee.Visible = false;
        UpdatePanel_SearchEmployee.Update();
    }//关闭
    #endregion

    #region//Grid_Detail翻页
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
        if (LblBindSAS_ASID.Text == "检索前")
            BindGrid_Detail("");
        if (LblBindSAS_ASID.Text == "检索后")
            BindGrid_Detail(Condition2);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= this.Grid_Detail.PageCount ? this.Grid_Detail.PageCount - 1 : newPageIndex;
        this.Grid_Detail.PageIndex = newPageIndex;
        this.Grid_Detail.DataBind();
    }
    #endregion

    #region//账套中的未出绩效成绩的员工信息栏
    protected void Button5_Click(object sender, EventArgs e)
    {
        GridView4.SelectedIndex = -1;
        Condition3 = TextBox8.Text.Trim() == "" ? " " : " and HRDD_StaffNO = '" + TextBox8.Text.Trim() + "' ";
        Condition3 += TextBox9.Text.Trim() == "" ? " " : " and HRDD_Name like '%" + TextBox9.Text.Trim() + "%' ";
        Condition3 += TextBox10.Text.Trim() == "" ? " " : " and HRPAT_PType like '%" + TextBox10.Text.Trim() + "%' ";
        Condition3 += TextBox11.Text.Trim() == "" ? " " : " and HRPAT_AAPerson like '%" + TextBox11.Text.Trim() + "%' ";
        Condition3 += TextBox12.Text.Trim() == "" ? " " : " and HRPAT_CCPerson like '%" + TextBox12.Text.Trim() + "%' ";
        Label39.Text = "检索后";
        BindGridView4(Condition3);
        UpdatePanel7.Update();
    }//检索
    protected void Button6_Click(object sender, EventArgs e)
    {
        TextBox8.Text = "";
        TextBox9.Text = "";
        TextBox10.Text = "";
        TextBox11.Text = "";
        TextBox12.Text = "";
        Label39.Text = "检索前";
        GridView4.SelectedIndex = -1;
        BindGridView4("");
    }//重置
    protected void Button7_Click(object sender, EventArgs e)
    {
        Panel7.Visible = false;
        UpdatePanel7.Update();
    }//关闭
    #endregion

    #region//GridView4翻页
    protected void GridView4_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = this.GridView4.BottomPagerRow;


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
        if (Label39.Text == "检索前")
            BindGridView4("");
        if (Label39.Text == "检索后")
            BindGridView4(Condition3);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= this.GridView4.PageCount ? this.GridView4.PageCount - 1 : newPageIndex;
        this.GridView4.PageIndex = newPageIndex;
        this.GridView4.DataBind();
    }
    #endregion

    #region//LblTheSet2员工信息栏
    protected void Button10_Click(object sender, EventArgs e)
    {
        conditionpeople.Text = TextBox15.Text.Trim() == "" ? " " : " and HRDD_StaffNO like '%" + TextBox6.Text.Trim() + "%' ";
        conditionpeople.Text += TextBox16.Text.Trim() == "" ? " " : " and HRDD_Name like '%" + TextBox16.Text.Trim() + "%' ";
        conditionpeople.Text += TextBox17.Text.Trim() == "" ? " " : " and SDBT_Dep like '%" + TextBox17.Text.Trim() + "%' ";
        conditionpeople.Text += TextBox18.Text.Trim() == "" ? " " : " and SDBT_Post like '%" + TextBox18.Text.Trim() + "%' ";
        LblIsSearch.Text = "检索后";
        BindGridView5(conditionpeople.Text);
        UpdatePanel8.Update();
    }//检索
    protected void Button13_Click(object sender, EventArgs e)
    {
        Label54.Text = LblYear.Text;
        Label64.Text = LblMonth.Text;
        Label65.Text = LblTime.Text;
        Label60.Text = Label53.Text;

        //初始化
        TextBox19.Text = "";
        TextBox20.Text = "";
        TextBox21.Text = "";
        TextBox22.Text = "";
        DropDownList6.ClearSelection();
        TextBox23.Text = "";
        TextBox24.Text = "";
        try
        {
            BindGridView6("");
        }
        catch (Exception)
        {

            throw;
        }

        Panel9.Visible = true;
        UpdatePanel9.Update();
    }//新增员工
    protected void Button11_Click(object sender, EventArgs e)
    {
        TextBox15.Text = "";
        TextBox16.Text = "";
        TextBox17.Text = "";
        TextBox18.Text = "";
        LblIsSearch.Text = "检索前";
        BindGridView5("");
        UpdatePanel8.Update();
    }//重置
    protected void Button12_Click(object sender, EventArgs e)
    {
        Panel8.Visible = false;
        UpdatePanel8.Update();
        if (Panel9.Visible)
        {
            Panel9.Visible = false;
            UpdatePanel9.Update();
        }
    }//关闭
    #endregion

    #region
    protected void GridView5_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = this.GridView5.BottomPagerRow;


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
        if (LblIsSearch.Text == "检索前")
            BindGridView5("");
        if (LblIsSearch.Text == "检索后")
            BindGridView5(conditionpeople.Text);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= this.GridView5.PageCount ? this.GridView5.PageCount - 1 : newPageIndex;
        this.GridView5.PageIndex = newPageIndex;
        this.GridView5.DataBind();
    }
    protected void GridView5_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete_Detail")
        {
            GridView1.SelectedIndex = -1;
            try
            {
                SalaryMonthCalculateInfo salaryMonthCalculateInfo = new SalaryMonthCalculateInfo();
                salaryMonthCalculateInfo.SDBT_ID = new Guid(e.CommandArgument.ToString());

                int i = salaryMonthCalculateL.Delete_SalaryPeopleIn(salaryMonthCalculateInfo);
                if (i > 0)
                    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('删除成功！')", true);
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('删除失败，请联系管理员！')", true);
                    return;
                }
            }
            catch (Exception)
            {

                throw;
            }

            if (LblIsSearch.Text == "检索前")
                BindGridView5("");
            if (LblIsSearch.Text == "检索后")
                BindGridView5(conditionpeople.Text);
            UpdatePanel8.Update();
            if (Label59.Text == "检索前")
                BindGridView6("");
            if (Label59.Text == "检索后")
                BindGridView6(LblCondition.Text);
            UpdatePanel9.Update();
        }
    }
    #endregion


    protected void Button14_Click(object sender, EventArgs e)
    {
        LblCondition.Text = TextBox19.Text.Trim() == "" ? " " : " and HRDD_StaffNO like '%" + TextBox19.Text.Trim() + "%' ";
        LblCondition.Text += TextBox20.Text.Trim() == "" ? " " : " and HRDD_Name like '%" + TextBox20.Text.Trim() + "%' ";
        LblCondition.Text += TextBox21.Text.Trim() == "" ? " " : " and BDOS_Name like '%" + TextBox21.Text.Trim() + "%' ";
        LblCondition.Text += TextBox22.Text.Trim() == "" ? " " : " and HRP_Post like '%" + TextBox22.Text.Trim() + "%' ";
        if (DropDownList6.Text.Trim() == "是") //? " " : " and HRP_Post like '%" + DropDownList6.Text.Trim() + "%' ";
        {
            LblCondition.Text += " and HRDD_IsDeleted=1 and HRDD_EState='离职' ";
        }
        if (DropDownList6.Text.Trim() == "否") //? " " : " and HRP_Post like '%" + DropDownList6.Text.Trim() + "%' ";
        {
            LblCondition.Text += " HRDD_IsDeleted=0 and  HRDD_EState is null ";
        }
        LblCondition.Text += TextBox23.Text.Trim() == "" ? " " : " and HRDD_QuitTime >='" + TextBox23.Text.Trim() + "' ";
        LblCondition.Text += TextBox24.Text.Trim() == "" ? " " : " and HRDD_QuitTime <='" + TextBox24.Text.Trim() + "' ";
        Label59.Text = "检索后";
        BindGridView6(LblCondition.Text);
        UpdatePanel9.Update();
    }

    protected void Button16_Click(object sender, EventArgs e)
    {
        TextBox19.Text = "";
        TextBox20.Text = "";
        TextBox21.Text = "";
        TextBox22.Text = "";
        DropDownList6.ClearSelection();
        TextBox23.Text = "";
        TextBox24.Text = "";
        Label59.Text = "检索前";
        BindGridView6("");
        UpdatePanel9.Update();

    }
    protected void Button17_Click(object sender, EventArgs e)
    {
        Panel9.Visible = false;
        UpdatePanel9.Update();
    }
    protected void GridView6_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = this.GridView6.BottomPagerRow;


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
        if (Label59.Text == "检索前")
            BindGridView6("");
        if (Label59.Text == "检索后")
            BindGridView6(LblCondition.Text);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= this.GridView6.PageCount ? this.GridView6.PageCount - 1 : newPageIndex;
        this.GridView6.PageIndex = newPageIndex;
        this.GridView6.DataBind();
    }
    protected void GridView6_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "AddPerson")
        {
            GridView6.SelectedIndex = -1;
            try
            {
                SalaryMonthCalculateInfo salaryMonthCalculateInfo = new SalaryMonthCalculateInfo();
                string[] str = e.CommandArgument.ToString().Split(new char[] { ',' });
                salaryMonthCalculateInfo.HRDD_ID = new Guid(str[0]);
                salaryMonthCalculateInfo.SMC_ID = new Guid(Label60.Text);
                salaryMonthCalculateInfo.SDBT_Dep = str[1];
                salaryMonthCalculateInfo.SDBT_Post = str[2];

                int i = salaryMonthCalculateL.Insert_SalaryDetailBivariateTableForOne(salaryMonthCalculateInfo);
                if (i > 0)
                    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('新增成功！')", true);
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('新增失败，请联系管理员！')", true);
                    return;
                }
            }
            catch (Exception)
            {

                throw;
            }

            if (Label59.Text == "检索前")
                BindGridView6("");
            if (Label59.Text == "检索后")
                BindGridView6(LblCondition.Text);
            UpdatePanel9.Update();
            if (LblIsSearch.Text == "检索前")
                BindGridView5("");
            if (LblIsSearch.Text == "检索后")
                BindGridView5(conditionpeople.Text);
            UpdatePanel8.Update();

        }
    }

    /// <summary>
    /// 由DataTable导出Excel
    /// </summary>
    /// <param name="sourceTable">要导出数据的DataTable</param>
    /// <returns>Excel工作表</returns>
    private Stream ExportDataTableToExcel(DataTable sourceTable, string sheetName)
    {
        HSSFWorkbook workbook = new HSSFWorkbook();
        MemoryStream ms = new MemoryStream();
        HSSFSheet sheet = workbook.CreateSheet(sheetName) as HSSFSheet;
        HSSFRow headerRow = sheet.CreateRow(0) as HSSFRow;
        // handling header.
        foreach (DataColumn column in sourceTable.Columns)
            headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);

        // handling value.
        int rowIndex = 1;

        foreach (DataRow row in sourceTable.Rows)
        {
            HSSFRow dataRow = sheet.CreateRow(rowIndex) as HSSFRow;

            foreach (DataColumn column in sourceTable.Columns)
            {
                dataRow.CreateCell(column.Ordinal).SetCellValue(row[column].ToString());
            }

            rowIndex++;
        }

        workbook.Write(ms);
        ms.Flush();
        ms.Position = 0;

        sheet = null;
        headerRow = null;
        workbook = null;

        return ms;
    }
    /// <summary>
    /// 由DataTable导出Excel
    /// </summary>
    /// <param name="sourceTable">要导出数据的DataTable</param>
    /// <param name="fileName">指定Excel工作表名称</param>
    /// <returns>Excel工作表</returns>
    private void ExportDataTableToExcel(DataTable sourceTable, string fileName, string sheetName)
    {
        MemoryStream ms = ExportDataTableToExcel(sourceTable, sheetName) as MemoryStream;
        HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + fileName);
        HttpContext.Current.Response.BinaryWrite(ms.ToArray());
        HttpContext.Current.Response.End();
        ms.Close();
        ms = null;
    }
    protected void ButtonToExcel_Click(object sender, EventArgs e)
    {
        DataSet dataset;

        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@SMC_ID", SqlDbType.UniqueIdentifier);
        para[0].Value = new Guid(Label68.Text.ToString());
        dataset = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_ForDaoChu_SalaryDetailBivariateTable", para);

        string fileName = Label66.Text + "年" + Label67.Text + "月" + "工资表.xls";
        DataTable table = dataset.Tables[0];

        ExportDataTableToExcel(table, fileName, "abc");
    }
    protected void ButtonFromExcel_Click(object sender, EventArgs e)
    {
        LblMessage.Visible = false;
        if (this.FileUpload.HasFile)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@SDBT_Year", SqlDbType.SmallInt);
            para[0].Value = Convert.ToInt16(Label66.Text.ToString());
            para[1] = new SqlParameter("@SDBT_Month", SqlDbType.TinyInt);
            para[1].Value = Convert.ToInt16(Label67.Text.ToString());
            DataSet set = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_SalaryDetailBivariateTable2", para);
            int count = set.Tables[0].Rows.Count;
            if (count > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('系统工资表中已存在" + Label66.Text.ToString() + "年" + Label67.Text.ToString() + "月的数据，请删除后再导入！')", true);
                return;
            }
            else
            {

                DataSet ds;
                ds = ImportDataSetFromExcel(this.FileUpload.FileContent, 0);

                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringLocalTransaction))
                {
                    conn.Open();
                    using (SqlBulkCopy sqlbulkcopy = new SqlBulkCopy(conn))
                    {
                        try
                        {
                            sqlbulkcopy.DestinationTableName = "dbo.SalaryDetailBivariateTable2";
                            sqlbulkcopy.WriteToServer(ds.Tables[0]);
                            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('导入成功！')", true);

                        }
                        catch (Exception ex)
                        {
                            // Response.Write(ex.ToString());
                            LblMessage.Visible = true;
                            LblMessage.Text = "对不起，出错了！可能原因是: 1)文档格式不正确；2)文档中某项工资值不是数值。 具体错误是：" + ex.ToString();
                            return;
                        }
                    }
                }
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('请先选择待导入的EXCEL文件！')", true);
            return;
        }
    }

    private DataSet ImportDataSetFromExcel(Stream excelFileStream, int headerRowIndex)
    {
        DataSet ds = new DataSet();
        HSSFWorkbook workbook = new HSSFWorkbook(excelFileStream);
        for (int a = 0, b = workbook.NumberOfSheets; a < b; a++)
        {
            HSSFSheet sheet = workbook.GetSheetAt(a) as HSSFSheet;
            DataTable table = new DataTable();

            HSSFRow headerRow = sheet.GetRow(headerRowIndex) as HSSFRow;
            int cellCount = headerRow.LastCellNum;
            for (int i = headerRow.FirstCellNum; i < cellCount; i++)
            {
                if (headerRow.GetCell(i) == null || headerRow.GetCell(i).StringCellValue.Trim() == "")
                {
                    // 如果遇到第一个空列，则不再继续向后读取
                    cellCount = i + 1;
                    break;
                }

                DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                table.Columns.Add(column);
            }

            for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
            {
                HSSFRow row = sheet.GetRow(i) as HSSFRow;
                if (row == null || row.GetCell(0) == null || row.GetCell(0).ToString().Trim() == "")
                {
                    // 如果遇到第一个空行，则不再继续向后读取
                    break;
                }

                DataRow dataRow = table.NewRow();
                for (int j = row.FirstCellNum; j < cellCount; j++)
                {
                    if (row.GetCell(j) != null)
                    {
                        dataRow[j] = row.GetCell(j).ToString();
                    }
                }

                table.Rows.Add(dataRow);
            }
            ds.Tables.Add(table);
        }

        excelFileStream.Close();
        workbook = null;

        return ds;
    }

    protected void ButtonDeleteSalary_Click(object sender, EventArgs e)
    {
        SqlParameter[] para = new SqlParameter[2];
        para[0] = new SqlParameter("@SDBT_Year", SqlDbType.SmallInt);
        para[0].Value = Convert.ToInt16(Label66.Text.ToString());
        para[1] = new SqlParameter("@SDBT_Month", SqlDbType.TinyInt);
        para[1].Value = Convert.ToInt16(Label67.Text.ToString());
        int i = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_D_SalaryDetailBivariateTable2", para);
        if (i > 0)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('" + Label66.Text + "年" + Label67.Text + "月工资表中记录已成功删除！')", true);
            return;
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('系统中不存在当月工资数据！')", true);
            return;
        }
    }
    protected void Button20_Click(object sender, EventArgs e)
    {
        Panel10.Visible = false;
        UpdatePanel10.Update();
    }
    protected void BtnType_Click(object sender, EventArgs e)
    {
        try
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@SDBT_Year", SqlDbType.SmallInt);
            para[0].Value = Convert.ToInt16(Label69.Text.ToString());
            para[1] = new SqlParameter("@SDBT_Month", SqlDbType.TinyInt);
            para[1].Value = Convert.ToInt16(Label70.Text.ToString());
            DataSet set = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_BySAS_Type", para);


            int i = 1;
            int j = 1;
            foreach (Control chk in this.Panel1tongji.Controls)
            {

                string checkname = chk.ID;
                if (checkname == "CheckBox" + i)
                {
                    if (((CheckBox)chk).Checked)
                    {
                        GridView7.Columns[i].Visible = true;
                        j++;
                    }
                    else
                        GridView7.Columns[i].Visible = false;
                    i++;
                }

            }
            if (j == 1)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('请至少选择一种统计对象！')", true);
                return;
            }
            else
            {
                GridView7.DataSource = set;
                GridView7.DataBind();
            }
            UpdatePaneltongji.Update();
        }
        catch (Exception)
        {
            
            throw;
        }
        
    }//员工类型检索
    protected void BtnDep_Click(object sender, EventArgs e)
    {
        SqlParameter[] para = new SqlParameter[2];
        para[0] = new SqlParameter("@SDBT_Year", SqlDbType.SmallInt);
        para[0].Value = Convert.ToInt16(Label69.Text.ToString());
        para[1] = new SqlParameter("@SDBT_Month", SqlDbType.TinyInt);
        para[1].Value = Convert.ToInt16(Label70.Text.ToString());
        DataSet set = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_BySDBT_Dep", para);


        int i = 1;
        int j = 1;
        foreach (Control chk in this.Panel1tongji.Controls)
        {

            string checkname = chk.ID;
            if (checkname == "CheckBox" + i)
            {
                if (((CheckBox)chk).Checked)
                {
                    GridView7.Columns[i].Visible = true;
                    j++;
                }
                else
                    GridView7.Columns[i].Visible = false;
                i++;
            }

        }
        if (j == 1)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('请至少选择一种统计对象！')", true);
            return;
        }
        else
        {
            GridView7.DataSource = set;

            GridView7.DataBind();
        }
        UpdatePaneltongji.Update();

    }//部门检索
    protected void BtnPost_Click(object sender, EventArgs e)
    {
        try
        {
            string str = " and SDBT_Year='" + Convert.ToInt16(Label69.Text.ToString()) + "' and SDBT_Month='" + Convert.ToInt16(Label70.Text.ToString()) + "' ";

            str += TextBox29.Text.Trim() == "" ? " " : " and theType like '%" + TextBox29.Text.Trim() + "%'";
            //SqlParameter[] para = new SqlParameter[1];
            //para[0] = new SqlParameter("@Condition", SqlDbType.VarChar, 1000);
            //para[0].Value = str;
            DataSet set = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_BySDBT_Post", new SqlParameter("@Condition", str));



            int i = 1;
            int j = 1;
            foreach (Control chk in this.Panel1tongji.Controls)
            {

                string checkname = chk.ID;
                if (checkname == "CheckBox" + i)
                {
                    if (((CheckBox)chk).Checked)
                    {
                        GridView7.Columns[i].Visible = true;
                        j++;
                    }
                    else
                        GridView7.Columns[i].Visible = false;
                    i++;
                }

            }
            if (j == 1)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('请至少选择一种统计对象！')", true);
                return;
            }
            else
            {
                GridView7.DataSource = set;

                GridView7.DataBind();
            }
            UpdatePaneltongji.Update();
        }
        catch (Exception)
        {

            throw;
        }

    }//岗位检索

    protected void Button15_Click(object sender, EventArgs e)
    {
        Panel1tongji.Visible = false;
        UpdatePaneltongji.Update();
    }//关闭
    protected void Button18_Click(object sender, EventArgs e)
    {
        LblRecordCondition.Text = TextBox25.Text.Trim() == "" ? " " : " and SDBT_NO like '%" + TextBox25.Text.Trim() + "%' ";
        LblRecordCondition.Text += TextBox26.Text.Trim() == "" ? " " : " and SDBT_Name like '%" + TextBox26.Text.Trim() + "%' ";
        LblRecordCondition.Text += TextBox27.Text.Trim() == "" ? " " : " and SDBT_Dep like '%" + TextBox27.Text.Trim() + "%' ";
        LblRecordCondition.Text += TextBox28.Text.Trim() == "" ? " " : " and SDBT_Post like '%" + TextBox28.Text.Trim() + "%' ";
        LabelIsSearch.Text = "检索后";
        int i = 39;
        foreach (Control chk in this.PanelDetail.Controls)
        {

            string checkname = chk.ID;
            if (checkname == "CheckBox" + i)
            {
                if (((CheckBox)chk).Checked)
                {
                    GridView8.Columns[i - 35].Visible = true;

                }
                else
                {
                    GridView8.Columns[i - 35].Visible = false;
                }
                i++;
            }

        }
        BindGridView8(LblRecordCondition.Text);
        UpdatePanelDetail.Update();
    }
    protected void Button19_Click(object sender, EventArgs e)
    {
        LabelIsSearch.Text = "检索前";
        LblRecordCondition.Text = "";
        TextBox25.Text = "";
        TextBox26.Text = "";
        TextBox27.Text = "";
        TextBox28.Text = "";

        int i = 39;
        foreach (Control chk in this.PanelDetail.Controls)
        {

            string checkname = chk.ID;
            if (checkname == "CheckBox" + i)
            {
                if (((CheckBox)chk).Checked)
                {
                    GridView8.Columns[i - 36].Visible = true;

                }
                else
                {
                    GridView8.Columns[i - 36].Visible = false;
                }
                i++;
            }

        }

        BindGridView8("");
        UpdatePanelDetail.Update();
    }
    protected void Button22_Click(object sender, EventArgs e)
    {
        PanelDetail.Visible = false;
        UpdatePanelDetail.Update();
    }
    protected void GridView8_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = this.GridView8.BottomPagerRow;


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
        if (LabelIsSearch.Text == "检索前")
            BindGridView8("");
        if (LabelIsSearch.Text == "检索后")
        {
            int i = 39;
            foreach (Control chk in this.PanelDetail.Controls)
            {

                string checkname = chk.ID;
                if (checkname == "CheckBox" + i)
                {
                    if (((CheckBox)chk).Checked)
                    {
                        GridView8.Columns[i - 35].Visible = true;

                    }
                    else
                    {
                        GridView8.Columns[i - 35].Visible = false;
                    }
                    i++;
                }

            }
            BindGridView8(LblRecordCondition.Text);
        }
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= this.GridView8.PageCount ? this.GridView8.PageCount - 1 : newPageIndex;
        this.GridView8.PageIndex = newPageIndex;
        this.GridView8.DataBind();
    }
}