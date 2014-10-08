using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Laputa_PaymentReport : Page
{
    private readonly PaymentMonthPlanD pmp = new PaymentMonthPlanD();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
             int year = 2014;
        int maxyear = DateTime.Now.Year;
    
        }
        if (!IsPostBack)
        {
            TextBox1.Text = Request.QueryString["name"];
         


            try
            {
                Label4.Text = Session["UserName"].ToString();
            }
            catch
            {
                Response.Redirect("~/Default.aspx");
            }
            Label5.Text = DateTime.Now.ToString(CultureInfo.InvariantCulture);

            GridView3.DataSource = pmp.QueryPaymentInfo(TextBox1.Text);
            GridView3.DataBind();
            Panel3.Visible = true;
        }
    }

    //#region 存储GridView翻页数据主键

    ///// <summary>
    ///// 存储GridView翻页数据主键
    ///// </summary>
    //private void RememberOldValues(GridView gv)
    //{

    //    Dictionary<string, string[]> list = Session["PurchaseMonthPlanDetail"] as Dictionary<string, string[]>;
    //    if (list == null)
    //    {
    //        Session["PurchaseMonthPlanDetail"] =new Dictionary<string, string[]>();
    //        list = (Dictionary<string, string[]>)Session["PurchaseMonthPlanDetail"];
    //    }
    //    foreach (GridViewRow row in gv.Rows)
    //    {
    //        var dataKey = gv.DataKeys[row.RowIndex].Values[0] +
    //                      "," + gv.DataKeys[row.RowIndex].Values[1];
    //        if (Session["PurchaseMonthPlanDetail"] != null)
    //                list = (Dictionary<string, string[]>)Session["PurchaseMonthPlanDetail"]; //很重要
    //            TextBox tb = row.Cells[6].FindControl("PlanPay") as TextBox;
    //            Debug.Assert(tb != null, "tb != null");
    //            if (tb.Text != "")
    //            {
    //                if (list != null && !list.ContainsKey(dataKey))
    //                {
    //                    var strings = new string[2];
    //                    strings[0] = row.Cells[5].Text;
    //                    strings[1] = tb.Text;
                        
    //                    list.Add(dataKey, strings);
    //                }
    //                else if (list != null && list.ContainsKey(dataKey))
    //                {
    //                    list.Remove(dataKey);
    //                    var strings = new string[2];
    //                    strings[0] = row.Cells[5].Text;
    //                    strings[1] = tb.Text;
    //                    list.Add(dataKey, strings);
    //                }
                   
    //            }
    //        if (list != null && list.Count > 0)
    //            Session["PurchaseMonthPlanDetail"] = list;
    //    }
    //}

    //#endregion

    protected void Search_Click(object sender, EventArgs e)
    {
        GridView3.DataSource = pmp.QueryPaymentInfo(TextBox1.Text);
        GridView3.DataBind();
        Panel3.Visible = true;
       
    }

  
    private void Bindgrid3()
    {
        GridView3.DataSource = pmp.QueryPaymentInfo(TextBox1.Text);
        GridView3.DataBind();
        
    }

  

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
    }

    protected void reset_Click(object sender, EventArgs e)
    {
    }


    protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView; // refer to the GridView
        int newPageIndex = 0;
  
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


    protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       
    }

    protected void print(object sender, EventArgs e)
    {
        Response.Redirect("~/report_cc/PaymentReport.aspx?provider=" + TextBox1.Text );
    }

    protected void ToExcel_Click(object sender, EventArgs e)
    {
        Search_Click(sender, e);
        GridView3.AllowPaging = false;
        Bindgrid3();
        ExcelHelper.GridViewToExcel(GridView3, "有毒物质统计报表");
    }

    protected void back_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/report_cc/PaymentReport.aspx");
    }
}