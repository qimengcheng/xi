using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class REPORT_cc_SalesPerformance : System.Web.UI.Page
{
    SalesD sd = new SalesD();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (!((Session["UserRole"].ToString().Contains("销售业绩一览表"))))
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
    private void BindGrid_Detail(string no, string condition)
    {
        Grid_Detail.DataSource = sd.S_SalesPerformance( no,  condition);
        Grid_Detail.DataBind();
    }
    //检索按钮
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedValue=="")
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('请填写统计类别！')", true);
            return;
        }
        string no = "";
        string condition = "";
        if (DropDownList1.SelectedItem.Text == "区域名称")
        {
            no = DropDownList1.SelectedValue;
            condition = "and CRMRBI_Name like '%" + TextBox2.Text.ToString() + "%'";
            Grid_Detail.Columns[1].Visible = true;
            Grid_Detail.Columns[2].Visible = false;
            Grid_Detail.Columns[3].Visible = false;
        }
        if (DropDownList1.SelectedItem.Text == "客户名称")
        {
            no = DropDownList1.SelectedValue;
            condition = "and CRMCIF_Name like '%" + TextBox2.Text.ToString() + "%'";
            Grid_Detail.Columns[1].Visible = false;
            Grid_Detail.Columns[2].Visible = true;
            Grid_Detail.Columns[3].Visible = false;
        }
        if (DropDownList1.SelectedItem.Text == "业务员")
        {
            no = DropDownList1.SelectedValue;
            condition = "and CRMCIF_SalesMan like '%" + TextBox2.Text.ToString() + "%'";
            Grid_Detail.Columns[1].Visible = false;
            Grid_Detail.Columns[2].Visible = false;
            Grid_Detail.Columns[3].Visible = true;
        }
        BindGrid_Detail(no, condition);
        UpdatePanel_Grid.Update();
    }
    //重置按钮
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        DropDownList1.SelectedIndex = -1;
        TextBox2.Text = "";
        UpdatePanel_Grid.Update();
    }
    //打印报表按钮
    protected void BtnPrint_Click(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedValue == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('请填写统计类别！')", true);
            return;
        }
        Response.Redirect("../REPORT_cc/SalesPerformancePrint.aspx?" + "&no=" + DropDownList1.SelectedValue + "&condition=" + TextBox2.Text + "&liebie=" + DropDownList1.SelectedItem.Text.ToString());
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
        string no = "";
        string condition = "";
        if (DropDownList1.SelectedItem.Text == "区域名称")
        {
            no = DropDownList1.SelectedValue;
            condition = "and CRMRBI_Name like '%" + TextBox2.Text.ToString() + "%'";
        }
        if (DropDownList1.SelectedItem.Text == "客户名称")
        {
            no = DropDownList1.SelectedValue;
            condition = "and CRMCIF_Name like '%" + TextBox2.Text.ToString() + "%'";
        }
        if (DropDownList1.SelectedItem.Text == "业务员")
        {
            no = DropDownList1.SelectedValue;
            condition = "and CRMCIF_SalesMan like '%" + TextBox2.Text.ToString() + "%'";
        }
        BindGrid_Detail(no, condition);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= this.Grid_Detail.PageCount ? this.Grid_Detail.PageCount - 1 : newPageIndex;
        this.Grid_Detail.PageIndex = newPageIndex;
        this.Grid_Detail.DataBind();
    }


}