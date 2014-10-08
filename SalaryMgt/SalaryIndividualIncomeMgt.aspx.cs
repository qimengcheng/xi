using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SalaryMgt_SalaryIndividualIncomeMgt : System.Web.UI.Page
{
    SalaryIndividualIncomeL SIIL = new SalaryIndividualIncomeL();
    SalaryIndividualIncomeInfo SIIIfo = new SalaryIndividualIncomeInfo();
    private static string condition;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserRole"] == null)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('您长时间未操作，请重新登录！')", true);
            Response.Redirect("~/Default.aspx");
        }
        #region//权限控制
        if (!((Session["UserRole"].ToString().Contains("个人所得税基础信息维护"))))
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Request.QueryString["status"] == "IndividualIncome")   
        {
            this.Title = "个人所得税基础信息维护";
        }
        #endregion
        if (!IsPostBack)
        {
            BindGrid_Tax("");
        }
    }
    private void BindGrid_Tax(string constr)
    {
        Grid_Tax.DataSource = SIIL.Search_SalaryIndividualIncomeTax(constr);
        Grid_Tax.DataBind();
    }//绑定列表中的Gridview,允许多次调用

    #region//个税检索栏
    protected void Btn_Search_Click(object sender, EventArgs e)
    {
        condition = TxtASNameSearch.Text == "" ? "" : " and SIIT_Min >=" + TxtASNameSearch.Text.Trim();
        condition += TextBox1.Text == "" ? "" : " and SIIT_Max <=" + TextBox1.Text.Trim();
        condition += TextBox2.Text == "" ? "" : " and SIIT_Rate ='" + TextBox2.Text.Trim() + "' ";
        condition += TextBox3.Text == "" ? "" : " and SIIT_Deduction ='" + TextBox3.Text.Trim() + "' ";
        BindGrid_Tax(condition);
        LblRecordIsSearch.Text = "检索后";
        this.Grid_Tax.SelectedIndex = -1;
        UpdatePanel_Grid.Update();
        UpdatePanel_Secrch.Update();
    }//个税检索栏 “检索”

    protected void Btn_Reset_Click(object sender, EventArgs e)
    {
        TxtASNameSearch.Text = "";
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        BindGrid_Tax("");
        LblRecordIsSearch.Text = "检索前";
        this.Grid_Tax.SelectedIndex = -1;
        UpdatePanel_Grid.Update();
    }//个税检索栏 “重置”
    protected void Btn_New_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        UpdatePanel1.Update();
        Label4.Text = "新增";
    }//个税检索栏 “新增个税标准”
    #endregion

    #region//Grid_Tax
    protected void Grid_Tax_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = this.Grid_Tax.BottomPagerRow;


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
            BindGrid_Tax("");
        if (LblRecordIsSearch.Text == "检索后")
            BindGrid_Tax(condition);

        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= this.Grid_Tax.PageCount ? this.Grid_Tax.PageCount - 1 : newPageIndex;
        this.Grid_Tax.PageIndex = newPageIndex;
        this.Grid_Tax.DataBind();
    }
    protected void Grid_Tax_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string[] StrArgument = e.CommandArgument.ToString().Split(new char[] { ',' });
        if (e.CommandName == "TheEdit")
        {
            try
            {
                GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
                this.Grid_Tax.SelectedIndex = row.RowIndex;
                Panel1.Visible = true;
                Label4.Text = "编辑";
                LblRecordID.Text = StrArgument[0].ToString();
                TextBox4.Text = StrArgument[1];
                TextBox5.Text = StrArgument[2];
                TextBox6.Text = StrArgument[3];
                TextBox7.Text = StrArgument[4];
                this.UpdatePanel1.Update();
            }
            catch (Exception)
            {

                throw;
            }
        }
        if (e.CommandName == "Delete_Tax")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            this.Grid_Tax.SelectedIndex = -1;

            Guid guid = new Guid(e.CommandArgument.ToString());
            SIIL.Delete_SalaryIndividualIncomeTax(guid);
            if (LblRecordIsSearch.Text == "检索前")
                BindGrid_Tax("");
            if (LblRecordIsSearch.Text == "检索后")
                BindGrid_Tax(condition);
            UpdatePanel_Grid.Update();
        }
    }
    #endregion

    #region//个税标准XX
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Label4.Text == "新增")
        {
            if (TextBox4.Text == "" || TextBox5.Text == "" || TextBox6.Text == "" || TextBox7.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            try
            {
                int d1;
                if (int.TryParse(TextBox4.Text, out d1))
                    SIIIfo.SIIT_Min = d1;
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('下限值必须为整数！')", true);
                    return;
                }
                int d2;
                if (int.TryParse(TextBox5.Text, out d2))
                    SIIIfo.SIIT_Max = d2;
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('上限值必须为整数！')", true);
                    return;
                }
                int d3;
                if (int.TryParse(TextBox6.Text, out d3))
                    SIIIfo.SIIT_Rate = d3;
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('税率必须为0到100的整数！')", true);
                    return;
                }
                int d4;
                if (int.TryParse(TextBox7.Text, out d4))
                    SIIIfo.SIIT_Deduction = d4;
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('速算扣除数必须为整数！')", true);
                    return;
                }
                int i = SIIL.Insert_SalaryIndividualIncomeTax(SIIIfo);
                if (i <= 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('新增失败！')", true);
                }
                else
                    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('新增成功！')", true);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('新增失败！" + ex.ToString() + "')", true);
            }
            Panel1.Visible = false;
            if (LblRecordIsSearch.Text == "检索前")
                BindGrid_Tax("");
            if (LblRecordIsSearch.Text == "检索后")
                BindGrid_Tax(condition);
            ClearItem();
            UpdatePanel_Grid.Update();
            UpdatePanel1.Update();
        }

        if (Label4.Text == "编辑")
        {
            SalaryIndividualIncomeInfo SIIIfo2 = new SalaryIndividualIncomeInfo();
            if (TextBox4.Text == "" || TextBox5.Text == "" || TextBox6.Text == "" || TextBox7.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            try
            {
                SIIIfo2.SIIT_ID = new Guid(LblRecordID.Text);
                int d1;
                if (int.TryParse(TextBox4.Text, out d1))
                    SIIIfo2.SIIT_Min = d1;
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('下限值必须为整数！')", true);
                    return;
                }
                int d2;
                if (int.TryParse(TextBox5.Text, out d2))
                    SIIIfo2.SIIT_Max = d2;
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('上限值必须为整数！')", true);
                    return;
                }
                int d3;
                if (int.TryParse(TextBox6.Text, out d3))
                    SIIIfo2.SIIT_Rate = d3;
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('税率必须为0到100的整数！')", true);
                    return;
                }
                int d4;
                if (int.TryParse(TextBox7.Text, out d4))
                    SIIIfo2.SIIT_Deduction = d4;
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('速算扣除数必须为整数！')", true);
                    return;
                }
                int i = SIIL.Update_SalaryIndividualIncomeTax(SIIIfo2);
                if (i <= 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('编辑失败！')", true);
                }
                else
                    ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('编辑成功！')", true);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('编辑失败！" + ex.ToString() + "')", true);
            }
            Panel1.Visible = false;
            if (LblRecordIsSearch.Text == "检索前")
                BindGrid_Tax("");
            if (LblRecordIsSearch.Text == "检索后")
                BindGrid_Tax(condition);
            ClearItem();
            UpdatePanel_Grid.Update();
            UpdatePanel1.Update();
        }
    }//提交

    protected void Button3_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        UpdatePanel1.Update();
        ClearItem();
    }//关闭

    private void ClearItem()
    {
        TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";
        TextBox7.Text = "";
    }
    #endregion
}