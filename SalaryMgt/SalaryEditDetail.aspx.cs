using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EquipmentMangementAjax.DBUtility;
using System.Data.SqlClient;

public partial class SalaryMgt_SalaryEditDetail : System.Web.UI.Page
{
    HRDDetailL hRDDetailL = new HRDDetailL();//共用部门和岗位的检索
    private static string Condition;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "修改详情并进行最终结算";
        string Role = Request.QueryString["status"].ToString();
        if (!((Session["UserRole"].ToString().Contains("薪资月度结算")) && Role=="Detail"))
        {
            Response.Redirect("~/Default.aspx");

        }
        if (!IsPostBack)
        {
            if (Request.QueryString["SMC_ID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            LblRecordID.Text = Request.QueryString["SMC_ID"];//记录前台传入的月度结算ID
            Bind_DdlDep();
            Bind_DdlSPost("");
            BindGridView1("");
           
        }
    }

    //绑定Dropdownlist中的DropDownList1——部门
    private void Bind_DdlDep()
    {
        DropDownList1.DataSource = hRDDetailL.SearchDdl_HRDDetail_BDOrganizationSheet().Tables[0].DefaultView;
        DropDownList1.DataTextField = "BDOS_Name";
        DropDownList1.DataValueField = "BDOS_Code";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, new ListItem("请选择", ""));
    }
    //绑定Dropdownlist中的DropDownList2——检索栏的岗位
    private void Bind_DdlSPost(string BDOS_Code)
    {
        DropDownList2.DataSource = hRDDetailL.SearchDdl_HRDDetail(BDOS_Code).Tables[0].DefaultView;
        DropDownList2.DataTextField = "HRP_Post";
        DropDownList2.DataValueField = "HRP_ID";
        DropDownList2.DataBind();
        DropDownList2.Items.Insert(0, new ListItem("请选择", ""));
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind_DdlSPost(DropDownList1.SelectedValue.ToString());
    }
    private void BindGridView1(string Condition)
    {
        GridView1.DataSource = Search_SalaryDetailBivariateTable(" and SMC_ID= '" + LblRecordID.Text + "'" + Condition);
        GridView1.DataBind();
    }

    #region//检索栏

    public DataSet Search_SalaryDetailBivariateTable(string Condition)
    {
        return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_SalaryDetailBivariateTable", new SqlParameter("@Condition", Condition));
    }//检索员工工资详情二维表的DAL

    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        Condition = TextBox1.Text.Trim() == "" ? "" : " and HRDD_StaffNO = '" + TextBox1.Text.Trim() + "'";
        Condition += TextBox2.Text.Trim() == "" ? "" : " and HRDD_Name like '%" + TextBox2.Text.Trim() + "%'";
        Condition += TextBox3.Text.Trim() == "" ? "" : " and SAS_ASName like '%" + TextBox3.Text.Trim() + "%'";
        Condition += DropDownList3.SelectedItem.ToString() == "请选择" ? "" : " and SAS_Type = '" + DropDownList3.SelectedItem.ToString() + "'";
        Condition += DropDownList1.SelectedItem.ToString() == "请选择" ? "" : " and SDBT_Dep ='" + DropDownList1.SelectedItem.ToString() + "'";
        Condition += DropDownList2.SelectedItem.ToString() == "请选择" ? "" : " and SDBT_Post ='" + DropDownList2.SelectedItem.ToString() + "'";
        BindGridView1(Condition);
        if (DropDownList3.SelectedItem.ToString() == "产线员工")
        {
            GridView1.Columns[11].HeaderStyle.CssClass = "hidden";
            GridView1.Columns[11].ItemStyle.CssClass = "hidden";
            GridView1.Columns[11].FooterStyle.CssClass = "hidden";

            GridView1.Columns[8].HeaderStyle.CssClass = "visible";
            GridView1.Columns[8].ItemStyle.CssClass = "visible";
            GridView1.Columns[8].FooterStyle.CssClass = "visible";
            GridView1.Columns[9].HeaderStyle.CssClass = "visible";
            GridView1.Columns[9].ItemStyle.CssClass = "visible";
            GridView1.Columns[9].FooterStyle.CssClass = "visible";
            GridView1.Columns[10].HeaderStyle.CssClass = "visible";
            GridView1.Columns[10].ItemStyle.CssClass = "visible";
            GridView1.Columns[10].FooterStyle.CssClass = "visible";
            GridView1.Columns[16].HeaderStyle.CssClass = "visible";
            GridView1.Columns[16].ItemStyle.CssClass = "visible";
            GridView1.Columns[16].FooterStyle.CssClass = "visible";
            GridView1.Columns[17].HeaderStyle.CssClass = "visible";
            GridView1.Columns[17].ItemStyle.CssClass = "visible";
            GridView1.Columns[17].FooterStyle.CssClass = "visible";
            GridView1.Columns[18].HeaderStyle.CssClass = "visible";
            GridView1.Columns[18].ItemStyle.CssClass = "visible";
            GridView1.Columns[18].FooterStyle.CssClass = "visible";
            GridView1.Columns[20].HeaderStyle.CssClass = "visible";
            GridView1.Columns[20].ItemStyle.CssClass = "visible";
            GridView1.Columns[20].FooterStyle.CssClass = "visible";
            GridView1.Columns[21].HeaderStyle.CssClass = "visible";
            GridView1.Columns[21].ItemStyle.CssClass = "visible";
            GridView1.Columns[21].FooterStyle.CssClass = "visible";
            GridView1.Columns[28].HeaderStyle.CssClass = "visible";
            GridView1.Columns[28].ItemStyle.CssClass = "visible";
            GridView1.Columns[28].FooterStyle.CssClass = "visible";
            GridView1.Columns[29].HeaderStyle.CssClass = "visible";
            GridView1.Columns[29].ItemStyle.CssClass = "visible";
            GridView1.Columns[29].FooterStyle.CssClass = "visible"; 
        }
        if (DropDownList3.SelectedItem.ToString() == "行政人员")
        {
            GridView1.Columns[11].HeaderStyle.CssClass = "visible";
            GridView1.Columns[11].ItemStyle.CssClass = "visible";
            GridView1.Columns[11].FooterStyle.CssClass = "visible";

            GridView1.Columns[8].HeaderStyle.CssClass = "hidden";
            GridView1.Columns[8].ItemStyle.CssClass = "hidden";
            GridView1.Columns[8].FooterStyle.CssClass = "hidden";
            GridView1.Columns[9].HeaderStyle.CssClass = "hidden";
            GridView1.Columns[9].ItemStyle.CssClass = "hidden";
            GridView1.Columns[9].FooterStyle.CssClass = "hidden";
            GridView1.Columns[10].HeaderStyle.CssClass = "hidden";
            GridView1.Columns[10].ItemStyle.CssClass = "hidden";
            GridView1.Columns[10].FooterStyle.CssClass = "hidden";
            GridView1.Columns[16].HeaderStyle.CssClass = "hidden";
            GridView1.Columns[16].ItemStyle.CssClass = "hidden";
            GridView1.Columns[16].FooterStyle.CssClass = "hidden";
            GridView1.Columns[17].HeaderStyle.CssClass = "hidden";
            GridView1.Columns[17].ItemStyle.CssClass = "hidden";
            GridView1.Columns[17].FooterStyle.CssClass = "hidden";
            GridView1.Columns[18].HeaderStyle.CssClass = "hidden";
            GridView1.Columns[18].ItemStyle.CssClass = "hidden";
            GridView1.Columns[18].FooterStyle.CssClass = "hidden";
            GridView1.Columns[20].HeaderStyle.CssClass = "hidden";
            GridView1.Columns[20].ItemStyle.CssClass = "hidden";
            GridView1.Columns[20].FooterStyle.CssClass = "hidden";
            GridView1.Columns[21].HeaderStyle.CssClass = "hidden";
            GridView1.Columns[21].ItemStyle.CssClass = "hidden";
            GridView1.Columns[21].FooterStyle.CssClass = "hidden";
            GridView1.Columns[28].HeaderStyle.CssClass = "hidden";
            GridView1.Columns[28].ItemStyle.CssClass = "hidden";
            GridView1.Columns[28].FooterStyle.CssClass = "hidden";
            GridView1.Columns[29].HeaderStyle.CssClass = "hidden";
            GridView1.Columns[29].ItemStyle.CssClass = "hidden";
            GridView1.Columns[29].FooterStyle.CssClass = "hidden"; 
        }
        UpdatePanel1.Update();
    }//检索 


    protected void BtnReset_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        DropDownList1.ClearSelection();
        DropDownList2.ClearSelection();
        DropDownList3.ClearSelection();
        BindGridView1("");
        UpdatePanel1.Update();
        GridView1.Columns[11].HeaderStyle.CssClass = "visible";
        GridView1.Columns[11].ItemStyle.CssClass = "visible";
        GridView1.Columns[11].FooterStyle.CssClass = "visible";

        GridView1.Columns[8].HeaderStyle.CssClass = "visible";
        GridView1.Columns[8].ItemStyle.CssClass = "visible";
        GridView1.Columns[8].FooterStyle.CssClass = "visible";
        GridView1.Columns[9].HeaderStyle.CssClass = "visible";
        GridView1.Columns[9].ItemStyle.CssClass = "visible";
        GridView1.Columns[9].FooterStyle.CssClass = "visible";
        GridView1.Columns[10].HeaderStyle.CssClass = "visible";
        GridView1.Columns[10].ItemStyle.CssClass = "visible";
        GridView1.Columns[10].FooterStyle.CssClass = "visible";
        GridView1.Columns[16].HeaderStyle.CssClass = "visible";
        GridView1.Columns[16].ItemStyle.CssClass = "visible";
        GridView1.Columns[16].FooterStyle.CssClass = "visible";
        GridView1.Columns[17].HeaderStyle.CssClass = "visible";
        GridView1.Columns[17].ItemStyle.CssClass = "visible";
        GridView1.Columns[17].FooterStyle.CssClass = "visible";
        GridView1.Columns[18].HeaderStyle.CssClass = "visible";
        GridView1.Columns[18].ItemStyle.CssClass = "visible";
        GridView1.Columns[18].FooterStyle.CssClass = "visible";
        GridView1.Columns[20].HeaderStyle.CssClass = "visible";
        GridView1.Columns[20].ItemStyle.CssClass = "visible";
        GridView1.Columns[20].FooterStyle.CssClass = "visible";
        GridView1.Columns[21].HeaderStyle.CssClass = "visible";
        GridView1.Columns[21].ItemStyle.CssClass = "visible";
        GridView1.Columns[21].FooterStyle.CssClass = "visible";
        GridView1.Columns[28].HeaderStyle.CssClass = "visible";
        GridView1.Columns[28].ItemStyle.CssClass = "visible";
        GridView1.Columns[28].FooterStyle.CssClass = "visible";
        GridView1.Columns[29].HeaderStyle.CssClass = "visible";
        GridView1.Columns[29].ItemStyle.CssClass = "visible";
        GridView1.Columns[29].FooterStyle.CssClass = "visible"; 
    }//重置
    #endregion

    public int SalaryDetailBivariateTable(GridViewRow Gr)
    {
        return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_SalaryDetailBivariateTable",
                 new SqlParameter("@SDBT_ID", new Guid(Gr.Cells[0].Text)), new SqlParameter("@SDBT_TimeCount", Convert.ToDecimal((Gr.Cells[8].FindControl("TextBox38") as TextBox).Text)), new SqlParameter("@SDBT_TWage", Convert.ToDecimal((Gr.Cells[9].FindControl("TextBox4") as TextBox).Text)),
                new SqlParameter("@SDBT_PWage", Convert.ToDecimal((Gr.Cells[10].FindControl("TextBox5") as TextBox).Text)), new SqlParameter("@SDBT_Basic", Convert.ToDecimal((Gr.Cells[11].FindControl("TextBox6") as TextBox).Text)),
                new SqlParameter("@SDBT_FullTime", Convert.ToDecimal((Gr.Cells[12].FindControl("TextBox7") as TextBox).Text)), new SqlParameter("@SDBT_Perform", Convert.ToDecimal((Gr.Cells[13].FindControl("TextBox8") as TextBox).Text)),
                new SqlParameter("@SDBT_OverTime", Convert.ToDecimal((Gr.Cells[14].FindControl("TextBox9") as TextBox).Text)), new SqlParameter("@SDBT_WorkAge", Convert.ToDecimal((Gr.Cells[15].FindControl("TextBox10") as TextBox).Text)),
                new SqlParameter("@SDBT_MidSchedule", Convert.ToDecimal((Gr.Cells[16].FindControl("TextBox11") as TextBox).Text)), new SqlParameter("@SDBT_NightSchedule", Convert.ToDecimal((Gr.Cells[17].FindControl("TextBox12") as TextBox).Text)),
                new SqlParameter("@SDBT_TeamLeader", Convert.ToDecimal((Gr.Cells[18].FindControl("TextBox13") as TextBox).Text)), new SqlParameter("@SDBT_LastMonth", Convert.ToDecimal((Gr.Cells[19].FindControl("TextBox14") as TextBox).Text)),
                new SqlParameter("@SDBT_KouMo", Convert.ToDecimal((Gr.Cells[20].FindControl("TextBox15") as TextBox).Text)), new SqlParameter("@SDBT_HighTep", Convert.ToDecimal((Gr.Cells[21].FindControl("TextBox16") as TextBox).Text)),
                new SqlParameter("@SDBT_Insurance", Convert.ToDecimal((Gr.Cells[22].FindControl("TextBox17") as TextBox).Text)), new SqlParameter("@SDBT_OtherSubsidies", Convert.ToDecimal((Gr.Cells[23].FindControl("TextBox18") as TextBox).Text)),
                new SqlParameter("@SDBT_PaidVacation", Convert.ToDecimal((Gr.Cells[24].FindControl("TextBox19") as TextBox).Text)), new SqlParameter("@SDBT_OtherPaid", Convert.ToDecimal((Gr.Cells[25].FindControl("TextBox20") as TextBox).Text)),
                new SqlParameter("@SDBT_AttendancePaidCut", Convert.ToDecimal((Gr.Cells[26].FindControl("TextBox21") as TextBox).Text)), new SqlParameter("@SDBT_PerfromPaidCut", Convert.ToDecimal((Gr.Cells[27].FindControl("TextBox22") as TextBox).Text)),
                new SqlParameter("@SDBT_PassPercentPaidCut", Convert.ToDecimal((Gr.Cells[28].FindControl("TextBox23") as TextBox).Text)), new SqlParameter("@SDBT_BadPaidCut", Convert.ToDecimal((Gr.Cells[29].FindControl("TextBox24") as TextBox).Text)),
                new SqlParameter("@SDBT_OtherPaidCut", Convert.ToDecimal((Gr.Cells[30].FindControl("TextBox25") as TextBox).Text)), new SqlParameter("@SDBT_EndowmentInsurance", Convert.ToDecimal((Gr.Cells[31].FindControl("TextBox26") as TextBox).Text)),
                new SqlParameter("@SDBT_MedicalInsurance", Convert.ToDecimal((Gr.Cells[32].FindControl("TextBox27") as TextBox).Text)), new SqlParameter("@SDBT_UnemployedInsurance", Convert.ToDecimal((Gr.Cells[33].FindControl("TextBox28") as TextBox).Text)),
                new SqlParameter("@SDBT_InjuryInsurance", Convert.ToDecimal((Gr.Cells[34].FindControl("TextBox29") as TextBox).Text)), new SqlParameter("@SDBT_MaternityInsurance", Convert.ToDecimal((Gr.Cells[35].FindControl("TextBox30") as TextBox).Text)),
                new SqlParameter("@SDBT_InsuranceTotal", Convert.ToDecimal((Gr.Cells[36].FindControl("TextBox31") as TextBox).Text)), new SqlParameter("@SDBT_HousingFund", Convert.ToDecimal((Gr.Cells[37].FindControl("TextBox32") as TextBox).Text)),
                new SqlParameter("@SDBT_InsuranceAndFund", Convert.ToDecimal((Gr.Cells[38].FindControl("TextBox33") as TextBox).Text)), new SqlParameter("@SDBT_OtherCut", Convert.ToDecimal((Gr.Cells[39].FindControl("TextBox34") as TextBox).Text)),
                new SqlParameter("@SDBT_IndividualTax", Convert.ToDecimal((Gr.Cells[40].FindControl("TextBox35") as TextBox).Text)), new SqlParameter("@SDBT_AccruedWages", Convert.ToDecimal((Gr.Cells[41].FindControl("TextBox36") as TextBox).Text)),
                new SqlParameter("@SDBT_RealWages", Convert.ToDecimal((Gr.Cells[42].FindControl("TextBox37") as TextBox).Text)));
    }

    public int UpdateSalaryMonCalculate(Guid id)
    {
        return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_SalaryMonCalculate",
                        new SqlParameter("@SMC_ID", id));
    }//更新主表
    protected void Button1_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow rows in GridView1.Rows)
        {
            try
            {
                Decimal d = Convert.ToDecimal((rows.Cells[8].FindControl("TextBox38") as TextBox).Text);
                SalaryDetailBivariateTable(rows);
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('工号为：'" + rows.Cells[1].Text + "的员工信息有误导致计算失败，请核实！);", true);
                break;
            }
        }
        BindGridView1(Condition);
        int i=UpdateSalaryMonCalculate(new Guid(LblRecordID.Text));
        if (i > 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('修改成功，并完成对应员工的项目计算！);", true);
        }
        UpdatePanel1.Update();
        

    }//确认修改
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("../SalaryMgt/SalaryMonthCalculate.aspx?status=MonthCalculate");
    }//返回
}