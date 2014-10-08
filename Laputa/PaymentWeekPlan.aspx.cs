using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Laputa_PaymentWeekPlan : Page
{
    private readonly PaymentWeekPlanD pwp = new PaymentWeekPlanD();

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
            GridView1.DataSource = pwp.QueryWeekPlan(Convert.ToInt32(DropDownList1.SelectedValue),
                Convert.ToInt32(DropDownList2.SelectedValue),
                TextBox1.Text);
            GridView1.DataBind();
            UpdatePanel2.Update();
            if (Request.QueryString["type"] =="look" && Session["UserRole"].ToString().Contains("付款周计划查看"))
            {
                plantype.Text = "look";
            }
            else if (Request.QueryString["type"] == "make" &&Session["UserRole"].ToString().Contains("付款周计划制定"))
            {
                plantype.Text = "make";
            }
            else if (Request.QueryString["type"] == "pay"&&Session["UserRole"].ToString().Contains("采购付款"))
            {
                plantype.Text = "pay";
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
         
            switch (plantype.Text)
            {
                case "look":
                    Title = "付款周计划查看";
                    GridView1.Columns[12].Visible = false;
                    GridView1.Columns[14].Visible = false;
                    GridView1.Columns[15].Visible = false;
                    GridView2.Columns[9].Visible = false;
                    NewMonthPlan.Visible = false;
                    break;
                case "make":
                    Title = "付款周计划制定";
                    GridView1.Columns[15].Visible = false;
                    break;
                case "pay":
                    Title = "采购付款";
                     GridView1.Columns[12].Visible = false;
                    GridView1.Columns[14].Visible = false;
                    GridView2.Columns[9].Visible = false;
                    NewMonthPlan.Visible = false;
                    break;
            }
        }
    }

    protected void Search_Click(object sender, EventArgs e)
    {
        GridView1.DataSource = pwp.QueryWeekPlan(Convert.ToInt32(DropDownList1.SelectedValue),
            Convert.ToInt32(DropDownList2.SelectedValue),
            TextBox1.Text);
        GridView1.DataBind();
        UpdatePanel2.Update();
    }

    private void Bindgrid1()
    {
        GridView1.DataSource = pwp.QueryWeekPlan(Convert.ToInt32(DropDownList1.SelectedValue),
            Convert.ToInt32(DropDownList2.SelectedValue),
            TextBox1.Text);
        GridView1.DataBind();
        UpdatePanel2.Update();
    }

    private void Bindgrid2()
    {
        GridView2.DataSource = pwp.QueryWeekPlanDetail(new Guid(WeekPlanID.Text));
        GridView2.DataBind();
        UpdatePanel3.Update();
    }

    private void Bindgrid3()
    {
        GridView3.DataSource = pwp.QueryMonthPlanInfo(Convert.ToInt32(year.Text), Convert.ToInt32(month.Text),
            Convert.ToInt32(week.Text));
        GridView3.DataBind();
        UpdatePanel5.Update();
    }

    private void Bindgrid4()
    {
        GridView4.DataSource = pwp.QueryWeekPlanDetail(new Guid(WeekPlanID.Text));
        GridView4.DataBind();
        UpdatePanel6.Update();
    }
    private void Bindgrid5()
    {
        GridView5.DataSource = pwp.QueryPaymentInfoDetail(Convert.ToInt32(year.Text),Convert.ToInt32(month.Text),Convert.ToInt32(week.Text));
        GridView5.DataBind();
        UpdatePanel7.Update();
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Details")
        {
            WeekPlanID.Text = e.CommandArgument.ToString();

            GridView2.DataSource = pwp.QueryWeekPlanDetail(new Guid(WeekPlanID.Text));
            GridView2.DataBind();
            Panel3.Visible = true;
            UpdatePanel3.Update();
            Panel4.Visible = false;
            UpdatePanel4.Update();
            Panel5.Visible = false;
            UpdatePanel5.Update();
            Panel6.Visible = false;
            UpdatePanel6.Update();
            Panel7.Visible = false;
            UpdatePanel7.Update();

        }
        if (e.CommandName == "Del")
        {
           
            WeekPlanID.Text = e.CommandArgument.ToString();
            pwp.DeleteWeekPlan(new Guid(e.CommandArgument.ToString()));
            Bindgrid1();
            Panel3.Visible = true;
            UpdatePanel3.Update();
        }
        if (e.CommandName == "Make")
        {
            var row = ((LinkButton) e.CommandSource).Parent.Parent as GridViewRow;
            year.Text = row.Cells[1].Text;
            month.Text = row.Cells[2].Text;
            week.Text = row.Cells[3].Text;
            WeekPlanID.Text = e.CommandArgument.ToString();
            GridView3.DataSource = pwp.QueryMonthPlanInfo(Convert.ToInt32(row.Cells[1].Text),
                Convert.ToInt32(row.Cells[2].Text), Convert.ToInt32(week.Text));
            GridView3.DataBind();
            Panel5.Visible = true;
            UpdatePanel5.Update();
        }
        if (e.CommandName == "Pay")
        {
            var row = ((LinkButton) e.CommandSource).Parent.Parent as GridViewRow;

            Panel6.Visible = true;
            WeekPlanID.Text = e.CommandArgument.ToString();
            year.Text = row.Cells[1].Text;
            month.Text = row.Cells[2].Text;
            week.Text = row.Cells[3].Text;
            Bindgrid4();
        }
        if (e.CommandName == "PayDetail")
        {
            var row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;

            Panel7.Visible = true;
            WeekPlanID.Text = e.CommandArgument.ToString();
            year.Text = row.Cells[1].Text;
            month.Text = row.Cells[2].Text;
            week.Text = row.Cells[3].Text;
            Bindgrid5();
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
    }

    protected void reset_Click(object sender, EventArgs e)
    {
    }

    protected void NewMonthPlan_Click(object sender, EventArgs e)
    {
        Panel4.Visible = true;
        UpdatePanel4.Update();
        Panel5.Visible = false;
        UpdatePanel5.Update();
        Panel6.Visible = false;
        UpdatePanel6.Update();
    }

    protected void NewMainSummit_Click(object sender, EventArgs e)
    {
        if (TextBox3.Text == "" || TextBox4.Text == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('日期必须填哦!');", true);
        }
        else
        {
            int a = pwp.InsertWeekPlan(Convert.ToInt32(DropDownList4.SelectedValue),
                Convert.ToInt32(DropDownList5.SelectedValue), Convert.ToInt32(DropDownList7.SelectedValue),
                Convert.ToDateTime(TextBox3.Text), Convert.ToDateTime(TextBox4.Text), Session["UserName"].ToString(),
                TextBox2.Text);
            if (a == 1)
            {
                ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('新增付款周计划成功！')", true);
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
        int a = RememberOldValues(theGrid);
        if (a == 1)
        {
            ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('计划付款数额加当月已计划数额超过了月计划数额,该项没有保存！');",
                true);
        }
        if (a == -1)
        {
            ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('有计划金额未填哦');", true);
        }
        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = theGrid.BottomPagerRow;


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
        newPageIndex = newPageIndex >= theGrid.PageCount ? theGrid.PageCount - 1 : newPageIndex;
        theGrid.PageIndex = newPageIndex;
        theGrid.DataBind();
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
        var list = Session["PurchaseWeekPlanDetail"] as Dictionary<string, string[]>;
        if (list != null)
        {
            foreach (var item in list)
            {
                string[] ids = item.Key.Split(',');
                string id = ids[0];
                string payway = ids[1];
                pwp.InsertWeekPlanDetail(new Guid(WeekPlanID.Text), new Guid(id), payway,
                    Convert.ToDecimal(item.Value[0]), Convert.ToDecimal(item.Value[1]));
            }
        }
        pwp.UpdatePaymentWeekPlanSum(new Guid(WeekPlanID.Text), Convert.ToDecimal(TextBox5.Text));
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
            var list = (Dictionary<string, string[]>) Session["PurchaseWeekPlanDetail"];
            if (list != null)
            {
                IEnumerable<string[]> planpay =
                    list.Where(q => q.Key == e.Row.Cells[0].Text + "," + e.Row.Cells[3].Text).Select(q => q.Value);
                if (list.ContainsKey(e.Row.Cells[0].Text + "," + e.Row.Cells[3].Text))
                {
                    tb.Text = list[e.Row.Cells[0].Text + "," + e.Row.Cells[3].Text][1];
                }
            }
            tb.ToolTip = "最多填" + (Convert.ToDecimal(e.Row.Cells[7].Text) - Convert.ToDecimal(e.Row.Cells[8].Text));
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
            pwp.DeleteWeekPlanDetail(new Guid(e.CommandArgument.ToString()));
            Bindgrid2();
        }
    }

    protected void Pay_Click(object sender, EventArgs e)
    {
        decimal total=0;
       int a=RememberPayValues(GridView4);
        if (a!=0)
        {
            if (a == 1)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('计划付款数额加当月已计划数额超过了月计划数额,该项没有保存！');",
                    true);
            }
            if (a == -1)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('有计划金额未填哦!');", true);
            }
        }
        var list = Session["PurchaseWeekPlanDetailPay"] as Dictionary<string, string[]>;
        if (list != null)
        {
            foreach (var item in list)
            {
                string[] ids = item.Key.Split(',');
                string id = ids[0];
                pwp.Insert_PaymentInfo(new Guid(id), Convert.ToDecimal(item.Value[1]), Convert.ToInt32(year.Text),
                    Convert.ToInt32(month.Text), Convert.ToInt32(week.Text), Session["UserName"].ToString(), "Test");
                total += Convert.ToDecimal(item.Value[1]);
            }

            ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('付款已完成！');", true);
            pwp.UpdatePaymentWeekPlanState(new Guid(WeekPlanID.Text),total);
            Panel6.Visible = false;
            UpdatePanel6.Update();
            Bindgrid1();
        }
    }

    protected void GridView4_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        var theGrid = sender as GridView; // refer to the GridView
        int newPageIndex = 0;
       int a= RememberPayValues(theGrid);
       if (a == 1)
       {
           ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('计划付款数额超过了周计划付款数额,该项付款数额没有保存！');",
               true);
       }
       if (a == -1)
       {
           ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('有计划金额未填哦');", true);
       }
        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView4.BottomPagerRow;


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
        Bindgrid4();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView4.PageCount ? GridView4.PageCount - 1 : newPageIndex;
        GridView4.PageIndex = newPageIndex;
        GridView4.DataBind();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
    }

    protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var tb = e.Row.Cells[9].FindControl("ActualPay") as TextBox;
            var list = (Dictionary<string, string[]>) Session["PurchaseWeekPlanDetailPay"];
            if (list != null)
            {
                if (list.ContainsKey(e.Row.Cells[0].Text + "," + e.Row.Cells[7].Text))
                {
                    tb.Text = list[e.Row.Cells[0].Text + "," + e.Row.Cells[7].Text][1];
                }
            }
        }
    }

    protected void Close_DetailAdd_Click(object sender, EventArgs e)
    {
        Panel5.Visible = false;
        UpdatePanel5.Update();
    }

    protected void Close_Pay_Click(object sender, EventArgs e)
    {
        Panel6.Visible = false;
        UpdatePanel6.Update();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[10].Text == "已付款")
            {
                var del = e.Row.Cells[10].FindControl("Del") as LinkButton;
                del.Enabled = false;
                del.ForeColor = Color.LightGray;
                var det = e.Row.Cells[12].FindControl("Make") as LinkButton;
                det.Enabled = false;
                det.ForeColor = Color.LightGray;
                var pay = e.Row.Cells[13].FindControl("Pay") as LinkButton;
                pay.CommandName = "PayDetail";
                pay.Text = "付款详情";
            }
            
            if (e.Row.Cells[11].Text.Length > 10)
            {
                e.Row.Cells[11].ToolTip = e.Row.Cells[11].Text;
                e.Row.Cells[11].Text = e.Row.Cells[11].Text.Substring(0, 10);
            }
            if (e.Row.Cells[10].Text == "已建立")
            {
                var pay = e.Row.Cells[13].FindControl("Pay") as LinkButton;
                pay.ForeColor = Color.LightGray;
                pay.Enabled = false;
            }
        }
    }

    #region 存储GridView翻页数据

    /// <summary>
    ///     存储GridView翻页数据
    /// </summary>
    private int RememberOldValues(GridView gv)
    {
        var list = Session["PurchaseWeekPlanDetail"] as Dictionary<string, string[]>;
        if (list == null)
        {
            Session["PurchaseWeekPlanDetail"] = new Dictionary<string, string[]>();
            list = (Dictionary<string, string[]>) Session["PurchaseWeekPlanDetail"];
        }
        foreach (GridViewRow row in gv.Rows)
        {
            var tb = row.Cells[6].FindControl("PlanPay") as TextBox;
            Debug.Assert(tb != null, "tb != null");
            if (tb.Text == "")
                return -1;

            if (Convert.ToInt32(tb.Text) > Convert.ToDecimal(row.Cells[7].Text) - Convert.ToDecimal(row.Cells[8].Text))
            {
                row.ForeColor = Color.Firebrick;
                return 1;
            }
            string dataKey = gv.DataKeys[row.RowIndex].Values[0] +
                             "," + gv.DataKeys[row.RowIndex].Values[1];
            if (Session["PurchaseWeekPlanDetail"] != null)
                list = (Dictionary<string, string[]>) Session["PurchaseWeekPlanDetail"];

            if (tb.Text != "")
            {
                if (list != null && !list.ContainsKey(dataKey))
                {
                    var strings = new string[2];
                    strings[0] = row.Cells[5].Text;
                    strings[1] = tb.Text;

                    list.Add(dataKey, strings);
                }
                else if (list != null && list.ContainsKey(dataKey))
                {
                    list.Remove(dataKey);
                    var strings = new string[2];
                    strings[0] = row.Cells[5].Text;
                    strings[1] = tb.Text;
                    list.Add(dataKey, strings);
                }
            }
            if (list != null && list.Count > 0)
                Session["PurchaseWeekPlanDetail"] = list;
        }
        return 0;
    }

    #endregion

    #region 存储实际付款数据

    /// <summary>
    ///     存储GridView翻页数据
    /// </summary>
    private int RememberPayValues(GridView gv)
    {
       
        var list = Session["PurchaseWeekPlanDetailPay"] as Dictionary<string, string[]>;
        if (list == null)
        {
            Session["PurchaseWeekPlanDetailPay"] = new Dictionary<string, string[]>();
            list = (Dictionary<string, string[]>) Session["PurchaseWeekPlanDetailPay"];
        }
        foreach (GridViewRow row in gv.Rows)
        {
            var tb = row.Cells[9].FindControl("ActualPay") as TextBox;
            if (tb.Text == "")
                return -1;
            if (Convert.ToInt32(tb.Text) > Convert.ToDecimal(row.Cells[9].Text))
            {
               return 1;
            }
            string dataKey = gv.DataKeys[row.RowIndex].Values[0] +
                             "," + gv.DataKeys[row.RowIndex].Values[1];
            //if (Session["PurchaseWeekPlanDetailPay"] != null)
            //    list = (Dictionary<string, string[]>)Session["PurchaseWeekPlanDetailPay"];

            Debug.Assert(tb != null, "tb != null");
            if (tb.Text != "")
            {
                if (list != null && !list.ContainsKey(dataKey))
                {
                    var strings = new string[2];
                    strings[0] = row.Cells[8].Text;
                    strings[1] = tb.Text;

                    list.Add(dataKey, strings);
                }
                else if (list != null && list.ContainsKey(dataKey))
                {
                    list.Remove(dataKey);
                    var strings = new string[2];
                    strings[0] = row.Cells[8].Text;
                    strings[1] = tb.Text;
                    list.Add(dataKey, strings);
                }
            }
            if (list != null && list.Count > 0)
                Session["PurchaseWeekPlanDetailPay"] = list;
        }
        return 0;
    }

    #endregion
    protected void Close_PayDetail_Click(object sender, EventArgs e)
    {
        Panel7.Visible = false;
        UpdatePanel7.Update();
    }
    protected void GridView5_PageIndexChanging(object sender, GridViewPageEventArgs e)
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
        Bindgrid5();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= theGrid.PageCount ? theGrid.PageCount - 1 : newPageIndex;
        theGrid.PageIndex = newPageIndex;
        theGrid.DataBind();
    }
    protected void Close_PayPlanDetail_Click(object sender, EventArgs e)
    {
        Panel3.Visible = false;
        UpdatePanel3.Update();
    }
}