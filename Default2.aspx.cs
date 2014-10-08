using System;
using System.Data;
using System.Web.UI;

public partial class Default2 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Chart1_Load(object sender, EventArgs e)
    {
        DataTable dt = default(DataTable);
        dt = CreateDataTable();

        //设置图表的数据源
        Chart1.DataSource = dt;

        //设置图表Y轴对应项
        Chart1.Series[0].YValueMembers = "Volume1";
        Chart1.Series[1].YValueMembers = "Volume2";

        //设置图表X轴对应项
        Chart1.Series[0].XValueMember = "Date";
        Chart1.Series[1].XValueMember = "Date";

        //绑定数据
        Chart1.DataBind();
    }
    private DataTable CreateDataTable()
    {
        //Create a DataTable as the data source of the Chart control
        DataTable dt = new DataTable();

        //Add three columns to the DataTable
        dt.Columns.Add("Date");
        dt.Columns.Add("Volume1");
        dt.Columns.Add("Volume2");

        DataRow dr;

        //Add rows to the table which contains some random data for demonstration
        dr = dt.NewRow();
        dr["Date"] = "一月";
        dr["Volume1"] = 3731;
        dr["Volume2"] = 4101;
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["Date"] = "二月";
        dr["Volume1"] = 6024;
        dr["Volume2"] = 4324;
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["Date"] = "三月";
        dr["Volume1"] = 4935;
        dr["Volume2"] = 2935;
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["Date"] = "四月";
        dr["Volume1"] = 4466;
        dr["Volume2"] = 5644;
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["Date"] = "五月";
        dr["Volume1"] = 5117;
        dr["Volume2"] = 5671;
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["Date"] = "六月";
        dr["Volume1"] = 3546;
        dr["Volume2"] = 4646;
        dt.Rows.Add(dr);

        return dt;
    }
}