using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Laputa_PaymentMonthPlan : Page
{
    private readonly PaymentMonthPlanD pmp = new PaymentMonthPlanD();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int year = 2014;
            int maxyear = DateTime.Now.Year;
            while (year <= maxyear + 1)
            {
                DropDownList1.Items.Add(year.ToString());

                DropDownList4.Items.Add(year.ToString());
                year++;
            }
            GridView1.DataSource = pmp.QueryMonthPlan(Convert.ToInt32(DropDownList1.SelectedValue),
                Convert.ToInt32(DropDownList2.SelectedValue),
                TextBox1.Text);
            GridView1.DataBind();
            UpdatePanel2.Update();
            if (Request.QueryString["type"] == "look" && Session["UserRole"].ToString().Contains("付款月计划查看"))
            {
                plantype.Text = "look";
                }
            else if (Request.QueryString["type"] == "make" && Session["UserRole"].ToString().Contains("付款月计划制定"))
            {
                plantype.Text = "make";
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }

            switch (plantype.Text)
            {
                case "look":
                    Title = "付款月计划查看";
                    NewMonthPlan.Visible = false;
                    GridView1.Columns[10].Visible = false;
                    GridView2.Columns[8].Visible = false;
                    break;
                case "make":
                    Title = "付款月计划制定";
                    GridView1.Columns[10].Visible = true;
                    GridView2.Columns[8].Visible = true;
                    break;
            }
        }
    }

    protected void Search_Click(object sender, EventArgs e)
    {
        GridView1.DataSource = pmp.QueryMonthPlan(Convert.ToInt32(DropDownList1.SelectedValue),
            Convert.ToInt32(DropDownList2.SelectedValue),
            TextBox1.Text);
        GridView1.DataBind();
        UpdatePanel2.Update();
        Panel3.Visible = false;
        UpdatePanel3.Update();
    }

    private void Bindgrid1()
    {
        GridView1.DataSource = pmp.QueryMonthPlan(Convert.ToInt32(DropDownList1.SelectedValue),
            Convert.ToInt32(DropDownList2.SelectedValue),
            TextBox1.Text);
        GridView1.DataBind();
        UpdatePanel2.Update();
    }

    private void Bindgrid2()
    {
        GridView2.DataSource = pmp.QueryMonthPlanDetail(new Guid(MonthPlanID.Text));
        GridView2.DataBind();
        UpdatePanel3.Update();
    }

    private void Bindgrid3()
    {
        GridView3.DataSource = pmp.QueryMonthPlanPool(DateTime.Now);
        GridView3.DataBind();
        UpdatePanel5.Update();
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Details")
        {
            MonthPlanID.Text = e.CommandArgument.ToString();

            GridView2.DataSource = pmp.QueryMonthPlanDetail(new Guid(MonthPlanID.Text));
            GridView2.DataBind();
            Panel3.Visible = true;
            UpdatePanel3.Update();
        }
        if (e.CommandName == "Make")
        {
            MonthPlanID.Text = e.CommandArgument.ToString();
            GridView3.DataSource = pmp.QueryMonthPlanPool(DateTime.Now);
            GridView3.DataBind();
            Panel5.Visible = true;
            UpdatePanel5.Update();
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        var theGrid = sender as GridView; // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = theGrid.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox");
                // refer to the TextBox with the NewPageIndex value
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
        Bindgrid1();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= theGrid.PageCount ? theGrid.PageCount - 1 : newPageIndex;
        theGrid.PageIndex = newPageIndex;
        theGrid.DataBind();
    }

    protected void reset_Click(object sender, EventArgs e)
    {
    }

    protected void NewMonthPlan_Click(object sender, EventArgs e)
    {
        Panel4.Visible = true;
        UpdatePanel4.Update();
    }

    protected void NewMainSummit_Click(object sender, EventArgs e)
    {
        if (TextBox3.Text == "" || TextBox4.Text == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('日期必须填哦!');", true);
        }
        else
        {
            int a = pmp.InsertMonthPlan(Convert.ToInt32(DropDownList4.SelectedValue),
                Convert.ToInt32(DropDownList5.SelectedValue),
                Convert.ToDateTime(TextBox3.Text), Convert.ToDateTime(TextBox4.Text), Session["UserName"].ToString(),
                TextBox2.Text);
            if (a == 1)
            {
                ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('新增付款月计划成功！')", true);
                Panel4.Visible = false;
                UpdatePanel4.Update();
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('失败了诶...')", true);
                Panel4.Visible = false;
                UpdatePanel4.Update();
            }
            Bindgrid1();
        }
    }

    protected void Close_Add_Click(object sender, EventArgs e)
    {
        Panel4.Visible = false;
        UpdatePanel4.Update();
    }

    protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        var theGrid = sender as GridView; // refer to the GridView
        int newPageIndex = 0;
        RememberOldValues(theGrid);
        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView3.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox) pagerRow.FindControl("textbox");
                // refer to the TextBox with the NewPageIndex value
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
        Bindgrid3();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView3.PageCount ? GridView3.PageCount - 1 : newPageIndex;
        GridView3.PageIndex = newPageIndex;
        GridView3.DataBind();
    }

    protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    }

    protected void NewDetailSummit_Click(object sender, EventArgs e)
    {
        if (TextBox5.Text == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('预计预付款项还没填！');", true);
            return;
        }
        RememberOldValues(GridView3);
        var list = Session["PurchaseMonthPlanDetail"] as Dictionary<string, string[]>;
        if (list != null)
        {
            foreach (var item in list)
            {
                string[] ids = item.Key.Split(',');
                string id = ids[0];
                string payway = ids[1];
                pmp.InsertMonthPlanDetail(new Guid(MonthPlanID.Text), new Guid(id), payway,
                    Convert.ToDecimal(item.Value[0]), Convert.ToDecimal(item.Value[1]), Convert.ToDecimal(item.Value[1]));
            }
        }
        pmp.UpdatePaymentMonthPlanSum(new Guid(MonthPlanID.Text), Convert.ToDecimal(TextBox5.Text));
        ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('全都增加好了哦！');", true);
        Panel5.Visible = false;
        UpdatePanel5.Update();
        Bindgrid1();
    }

    protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var tb = e.Row.Cells[6].FindControl("PlanPay") as TextBox;
            var list = (Dictionary<string, string[]>) Session["PurchaseMonthPlanDetail"];
            if (list != null)
            {
                IEnumerable<string[]> planpay =
                    list.Where(q => q.Key == e.Row.Cells[0].Text + "," + e.Row.Cells[3].Text).Select(q => q.Value);
                if (list.ContainsKey(e.Row.Cells[0].Text + "," + e.Row.Cells[3].Text))
                {
                    tb.Text = list[e.Row.Cells[0].Text + "," + e.Row.Cells[3].Text][1];
                }
            }
        }
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        var theGrid = sender as GridView; // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = theGrid.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox");
                // refer to the TextBox with the NewPageIndex value
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
        Bindgrid2();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= theGrid.PageCount ? theGrid.PageCount - 1 : newPageIndex;
        theGrid.PageIndex = newPageIndex;
        theGrid.DataBind();
    }

    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Del")
        {
            pmp.DeleteMonthPlanDetail(new Guid(e.CommandArgument.ToString()));
            Bindgrid2();
        }
    }

    protected void Close_Pay_Click(object sender, EventArgs e)
    {
        Panel5.Visible = false;
        UpdatePanel5.Update();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[8].Text.Length > 10)
            {
                e.Row.Cells[8].ToolTip = e.Row.Cells[8].Text;
                e.Row.Cells[8].Text = e.Row.Cells[8].Text.Substring(0, 10);
            }
        }
    }

    #region 存储GridView翻页数据主键

    /// <summary>
    ///     存储GridView翻页数据主键
    /// </summary>
    private void RememberOldValues(GridView gv)
    {
        var list = Session["PurchaseMonthPlanDetail"] as Dictionary<string, string[]>;
        if (list == null)
        {
            Session["PurchaseMonthPlanDetail"] = new Dictionary<string, string[]>();
            list = (Dictionary<string, string[]>) Session["PurchaseMonthPlanDetail"];
        }
        foreach (GridViewRow row in gv.Rows)
        {
            string dataKey = gv.DataKeys[row.RowIndex].Values[0] +
                             "," + gv.DataKeys[row.RowIndex].Values[1];
            if (Session["PurchaseMonthPlanDetail"] != null)
                list = (Dictionary<string, string[]>) Session["PurchaseMonthPlanDetail"]; //很重要
            var tb = row.Cells[6].FindControl("PlanPay") as TextBox;
            Debug.Assert(tb != null, "tb != null");
            if (tb.Text != "")
            {
                if (list != null && !list.ContainsKey(dataKey))
                {
                    var strings = new string[2];
                    strings[0] = row.Cells[5].Text;
                    strings[1] = tb.Text;
                    strings[2] = row.Cells[4].Text;

                    list.Add(dataKey, strings);
                }
                else if (list != null && list.ContainsKey(dataKey))
                {
                    list.Remove(dataKey);
                    var strings = new string[2];
                    strings[0] = row.Cells[5].Text;
                    strings[1] = tb.Text;
                    strings[2] = row.Cells[4].Text;
                    list.Add(dataKey, strings);
                }
            }
            if (list != null && list.Count > 0)
                Session["PurchaseMonthPlanDetail"] = list;
        }
    }

    #endregion
}