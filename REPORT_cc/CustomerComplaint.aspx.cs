using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class REPORT_cc_CustomerComplaint : System.Web.UI.Page
{
    SalesAfterD st = new SalesAfterD();
    SalesD sd = new SalesD();
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
                if (!((Session["UserRole"].ToString().Contains("客户投诉汇总表"))))
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
        Grid_Detail.DataSource = sd.S_CustomerComplain(condition);
        Grid_Detail.DataBind();
    }
    private void BindDropDownList1()
    {
        this.DropDownList1.DataSource = st.Select_ShouhouSort("");
        this.DropDownList1.DataTextField = "CRMASS_Name";
        this.DropDownList1.DataValueField = "CRMASS_Name";
        this.DropDownList1.DataBind();
        this.DropDownList1.Items.Insert(0, new ListItem("请选择", ""));
    }
    protected void BindDropDownList2()
    {
        this.DropDownList2.DataSource = st.Select_TousuSort("");
        this.DropDownList2.DataTextField = "CRMCS_Name";
        this.DropDownList2.DataValueField = "CRMCS_Name";
        this.DropDownList2.DataBind();
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
            temp += " and CRMASS_Name = '" + this.DropDownList1.SelectedValue.ToString() + "'";
        }
        if (this.DropDownList2.SelectedValue.ToString() != "")
        {
            temp += " and CRMCS_Name = '" + this.DropDownList2.SelectedValue.ToString() + "'";
        }
        if (this.TextBox1.Text.ToString() != "")
        {
            temp += " and CRMCIF_Name like '%" + this.TextBox1.Text.Trim() + "%'";
        }
        //投诉时间
        if (this.laststar.Text.ToString() != "" && this.lastend.Text.ToString() != "")
        {
            temp += " and CRMCCM_InputTime >= '" + laststar.Text.Trim() + "' and CRMCCM_InputTime <= '" + lastend.Text.Trim() + "'";
        }
        if (this.laststar.Text.ToString() != "" && this.lastend.Text.ToString() == "")
        {
            temp += " and CRMCCM_InputTime >= '" + laststar.Text.Trim() + "'";
        }
        if (this.laststar.Text.ToString() == "" && this.lastend.Text.ToString() != "")
        {
            temp += " and CRMCCM_InputTime <= '" + lastend.Text.Trim() + "'";
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
        laststar.Text = "";
        lastend.Text = "";
        UpdatePanel_Grid.Update();
    }
    //打印报表按钮
    protected void BtnPrint_Click(object sender, EventArgs e)
    {
        Response.Redirect("../REPORT_cc/CustomerComplaintPrint.aspx?" + "&CRMASS_Name=" + this.DropDownList1.SelectedValue.ToString() + "&CRMCS_Name=" + this.DropDownList2.SelectedValue.ToString() + "&CRMCIF_Name=" + TextBox1.Text + "&startime=" + laststar.Text + "&endtime=" + lastend.Text);
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