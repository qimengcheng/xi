using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Laputa_PurchaseReport : Page
{
    private readonly PaymentMonthPlanD pmp = new PaymentMonthPlanD();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int maxyear = DateTime.Now.Year;
            for (int i = 2013; i <= maxyear; i++)
            {
                DropDownList1.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }

        }
        //GridView3.DataSource = pmp.QueryPaymentInfoDetail(DateTime.Now);
        //GridView3.DataBind();
        //UpdatePanel5.Update();
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
        GridView3.DataSource = pmp.PurchaseInfo(Convert.ToInt32(DropDownList1.SelectedValue),Convert.ToInt32(DropDownList2.SelectedValue));
        GridView3.DataBind();
        Panel5.Visible = true;
        UpdatePanel5.Update();
    }

  
    private void Bindgrid3()
    {
        GridView3.DataSource = pmp.PurchaseInfo(Convert.ToInt32(DropDownList1.SelectedValue), Convert.ToInt32(DropDownList2.SelectedValue));
        GridView3.DataBind();
        UpdatePanel5.Update();
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
        Response.Redirect("~/report_cc/PurchaseReportPrint.aspx?year=" + DropDownList1.SelectedValue+"&month="+ DropDownList2.SelectedValue );
    }

    protected void Chart1_Load(object sender, EventArgs e)
    {
        DataSet ds = pmp.PurchaseInfo(Convert.ToInt32(DropDownList1.SelectedValue), Convert.ToInt32(DropDownList2.SelectedValue));
        //Chart1.DataSource= ds.Tables[0].Select("年份="+DateTime.Now.Year);
        //ChartArea ca=new ChartArea();
        //Series mySeries= new Series();
        //Chart1.ChartAreas.Add(ca);
        //Chart1.Series.Add(mySeries)

        ; //设置图表Y轴对应项

        //Chart1.Series[0].YValueMembers ="出站数";
        //Chart1.Series[2].YValueMembers = "合格率";

        ////设置图表X轴对应项
        //Chart1.Series[0].XValueMember = "月份";
        //Chart1.Series[2].XValueMember = "月份";
        //Chart1.DataSource = ds.Tables[0].Select("年份=" + (DateTime.Now.Year-1));
        //ChartArea ca=new ChartArea();
        //Series mySeries= new Series();
        //Chart1.ChartAreas.Add(ca);
        //Chart1.Series.Add(mySeries)

        ; //设置图表Y轴对应项
        DataTable dt = new DataTable();
        if (ds.Tables[0].Select("年份=" + (DropDownList1.SelectedValue =="999" ? DateTime.Now.Year.ToString(CultureInfo.InvariantCulture) : DropDownList1.SelectedValue)).Any())
        {
            dt = ds.Tables[0].Select("年份=" + (DropDownList1.SelectedValue == "999" ? DateTime.Now.Year.ToString(CultureInfo.InvariantCulture) : DropDownList1.SelectedValue)).CopyToDataTable();
            foreach (DataRow dr in dt.AsEnumerable())
            {
                Chart1.Series[0].Points.AddXY(dr["月份"], dr["采购金额"]);
             }
        }
        //if (ds.Tables[0].Select("类型='浇灌桥' and 年份=" + (DropDownList1.SelectedValue)).Any())
        //{
        //    dt = ds.Tables[0].Select("类型='浇灌桥' and 年份=" + (DropDownList1.SelectedValue)).CopyToDataTable();
        //    foreach (DataRow dr in dt.AsEnumerable())
        //    {
        //        Chart1.Series[1].Points.AddXY(dr["月份"], dr["出站数"]);
        //        Chart1.Series[4].Points.AddXY(dr["月份"], dr["合格率"]);
        //    }
        //}
        //if (ds.Tables[0].Select("类型='模块事业部产品' and 年份=" + (DropDownList1.SelectedValue)).Any())
        //{

        //    dt = ds.Tables[0].Select("类型='模块事业部产品' and 年份=" + (DropDownList1.SelectedValue)).CopyToDataTable();
        //    foreach (DataRow dr in dt.AsEnumerable())
        //    {
        //        Chart1.Series[2].Points.AddXY(dr["月份"], dr["出站数"]);
        //        Chart1.Series[5].Points.AddXY(dr["月份"], dr["合格率"]);
        //    }
        //}

        Chart1.Titles[0].Text = (DropDownList1.SelectedValue == "999" ? DateTime.Now.Year.ToString(CultureInfo.InvariantCulture) : DropDownList1.SelectedValue)+ "年采购金额趋势图";


        //设置图表X轴对应项
        //绑定数据
        Chart1.DataBind();
    }
}