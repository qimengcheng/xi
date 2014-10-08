using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class REPORT_cc_Chanliang : System.Web.UI.Page
{
    SalesD sd = new SalesD();
    ProSeriesInfo_ProTypeL ppl = new ProSeriesInfo_ProTypeL();
    SalaryTimeItemMaintananceL sTIML = new SalaryTimeItemMaintananceL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DropDownList1.Items.Insert(0, new ListItem("请选择", ""));
            BindDropDownList1();
            DropDownList2.Items.Insert(0, new ListItem("请选择", ""));
            BindDropDownList2();
            try
            {
                if (!((Session["UserRole"].ToString().Contains("工人计件产量报表"))))
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('可能您没有权限操作和查看本页面，请退出选择其他账号登陆，或联系管理员！')", true);
                Response.Redirect("~/Default.aspx");
            }
        }
    }
    //绑定
    private void BindGrid_Detail(string condition)
    {
        Grid_Detail.DataSource = sd.S_Chanliang(condition);
        Grid_Detail.DataBind();
    }
    private void BindDropDownList1()
    {
        DropDownList1.DataSource = sTIML.SearchCraftForDdl_SalaryTimeItem();
        DropDownList1.DataTextField = "PBC_Name";
        DropDownList1.DataValueField = "PBC_Name";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, new ListItem("请选择", ""));
    }
    protected void BindDropDownList2()
    {
        DropDownList2.DataSource = ppl.S_ProMainSeries("");
        DropDownList2.DataTextField = "PMS_Name";
        DropDownList2.DataValueField = "PMS_Name";
        DropDownList2.DataBind();
        DropDownList2.Items.Insert(0, new ListItem("请选择", ""));
    }
    //检索按钮
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        string condition = GetCondition();
        BindGrid_Detail(condition);
        UpdatePanel_Grid.Update();
    }
    protected string GetCondition()
    {
        string condition;
        string temp = "";
        if (this.DropDownList1.SelectedValue.ToString() != "")
        {
            temp += " and 工序 = '" + this.DropDownList1.SelectedValue.ToString() + "'";
        }
        if (this.DropDownList2.SelectedValue.ToString() != "")
        {
            temp += " and 大类型号 = '" + this.DropDownList2.SelectedValue.ToString() + "'";
        }
        if (this.TextBox1.Text.ToString() != "")
        {
            temp += " and 工号 like '%" + this.TextBox1.Text.Trim() + "%'";
        }
        if (this.TextBox2.Text.ToString() != "")
        {
            temp += " and 姓名 like '%" + this.TextBox2.Text.Trim() + "%'";
        }
        //时间
        if (this.laststar.Text.ToString() != "" && this.lastend.Text.ToString() != "")
        {
            temp += " and 日期 >= '" + laststar.Text.Trim() + "' and 日期 <= '" + lastend.Text.Trim() + "'";
        }
        if (this.laststar.Text.ToString() != "" && this.lastend.Text.ToString() == "")
        {
            temp += " and 日期 >= '" + laststar.Text.Trim() + "'";
        }
        if (this.laststar.Text.ToString() == "" && this.lastend.Text.ToString() != "")
        {
            temp += " and 日期 <= '" + lastend.Text.Trim() + "'";
        }
        if (this.laststar.Text.ToString() == "" && this.lastend.Text.ToString() == "")
        {
            temp += "";
        }
        condition = temp;
        return condition;
    }
    //重置按钮
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        DropDownList1.Items.Insert(0, new ListItem("请选择", ""));
        BindDropDownList1();
        DropDownList1.SelectedValue = "";
        DropDownList2.Items.Insert(0, new ListItem("请选择", ""));
        BindDropDownList2();
        DropDownList2.SelectedValue = "";
        TextBox1.Text = "";
        TextBox2.Text = "";
        laststar.Text = "";
        lastend.Text = "";
        UpdatePanel_Grid.Update();
    }
    //打印报表按钮
    protected void BtnPrint_Click(object sender, EventArgs e)
    {
        Response.Redirect("../REPORT_cc/ChanliangPrint.aspx?" + "&PBC_Name=" + this.DropDownList1.SelectedValue.ToString() + "&PMS_Name=" + this.DropDownList2.SelectedValue.ToString() + "&HRDD_StaffNO=" + TextBox1.Text + "&HRDD_Name=" + TextBox2.Text + "&startime=" + laststar.Text + "&endtime=" + lastend.Text);
    }
    //Grid_Detail翻页
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
        string condition = GetCondition();
        BindGrid_Detail(condition);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= this.Grid_Detail.PageCount ? this.Grid_Detail.PageCount - 1 : newPageIndex;
        this.Grid_Detail.PageIndex = newPageIndex;
        this.Grid_Detail.DataBind();
    }


}