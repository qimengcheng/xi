using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class REPORT_cc_SalesOrder : System.Web.UI.Page
{
    SalesD sd = new SalesD();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (!((Session["UserRole"].ToString().Contains("订单完成情况统计表"))))
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
        Grid_Detail.DataSource = sd.S_SalesOrderFinish(condition);
        Grid_Detail.DataBind();
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
        if (this.TextBox1.Text.ToString() != "")
        {
            temp += " and CRMCIF_Name like '%" + this.TextBox1.Text.Trim() + "%'";
        }
        if (this.TextBox2.Text.ToString() != "")
        {
            temp += " and SMSO_ComOrderNum like '%" + this.TextBox2.Text.Trim() + "%'";
        }
        if (this.TextBox3.Text.ToString() != "")
        {
            temp += " and SMSO_CusOrderNum like '%" + this.TextBox3.Text.Trim() + "%'";
        }
        if (this.TextBox4.Text.ToString() != "")
        {
            temp += " and PT_Name like '%" + this.TextBox4.Text.Trim() + "%'";
        }
        if (this.TextBox5.Text.ToString() != "")
        {
            temp += " and SMSOD_DelCondition like '%" + this.TextBox5.Text.Trim() + "%'";
        }
        //下单时间
        if (this.TextBox6.Text.ToString() != "" && this.TextBox7.Text.ToString() != "")
        {
            temp += " and SMSO_PlaceOrderTime >= '" + TextBox6.Text.Trim() + "' and SMSO_PlaceOrderTime <= '" + TextBox7.Text.Trim() + "'";
        }
        if (this.TextBox6.Text.ToString() != "" && this.TextBox7.Text.ToString() == "")
        {
            temp += " and SMSO_PlaceOrderTime >= '" + TextBox6.Text.Trim() + "'";
        }
        if (this.TextBox6.Text.ToString() == "" && this.TextBox7.Text.ToString() != "")
        {
            temp += " and SMSO_PlaceOrderTime <= '" + TextBox7.Text.Trim() + "'";
        }
        if (this.TextBox6.Text.ToString() == "" && this.TextBox7.Text.ToString() == "")
        {
            temp += "";
        }
        //交货时间
        if (this.TextBox8.Text.ToString() != "" && this.TextBox9.Text.ToString() != "")
        {
            temp += " and SMOD_Time >= '" + TextBox8.Text.Trim() + "' and SMOD_Time <= '" + TextBox9.Text.Trim() + "'";
        }
        if (this.TextBox8.Text.ToString() != "" && this.TextBox9.Text.ToString() == "")
        {
            temp += " and SMOD_Time >= '" + TextBox8.Text.Trim() + "'";
        }
        if (this.TextBox8.Text.ToString() == "" && this.TextBox9.Text.ToString() != "")
        {
            temp += " and SMOD_Time <= '" + TextBox9.Text.Trim() + "'";
        }
        if (this.TextBox8.Text.ToString() == "" && this.TextBox9.Text.ToString() == "")
        {
            temp += "";
        }
        condition = temp;
        return condition;
    }
    //重置按钮
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";
        TextBox7.Text = "";
        TextBox8.Text = "";
        TextBox9.Text = "";
        UpdatePanel_Grid.Update();
    }
    //打印报表按钮
    protected void BtnPrint_Click(object sender, EventArgs e)
    {
        Response.Redirect("../REPORT_cc/SalesOrderPrint.aspx?" + "&CRMCIF_Name=" + TextBox1.Text + "&SMSO_ComOrderNum=" + TextBox2.Text + "&SMSO_CusOrderNum=" + TextBox3.Text
            + "&PT_Name=" + TextBox4.Text + "&SMSOD_DelCondition=" + TextBox5.Text + "&TextBox6=" + TextBox6.Text + "&TextBox7=" + TextBox7.Text + "&TextBox8=" + TextBox8.Text + "&TextBox9=" + TextBox9.Text);
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