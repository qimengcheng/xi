using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class REPORT_cc_PersonnelSalaryRecordPrint : System.Web.UI.Page
{
    private readonly SalesD sd = new SalesD();
    protected void Page_Load(object sender, EventArgs e)
    {
        Labelpeople.Text = Session["UserName"].ToString();
        Labeltime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        if (Request.QueryString["startime"] == null || Request.QueryString["startime"] == "")
        {
            Labelstart.Text = "始";
        }
        else
        {
            Labelstart.Text = Request.QueryString["startime"];
        }
        if (Request.QueryString["endtime"] == null || Request.QueryString["endtime"] == "")
        {
            Labelend.Text = "今";
        }
        else
        {
            Labelend.Text = Request.QueryString["endtime"];
        }
        //绑定
        string HRDD_StaffNO = Request.QueryString["HRDD_StaffNO"];
        string HRDD_Name = Request.QueryString["HRDD_Name"];
        string HRSR_ChargePer = Request.QueryString["HRSR_ChargePer"];
        string startime = Request.QueryString["startime"];
        string endtime = Request.QueryString["endtime"];
        string BDOS_Name = Request.QueryString["BDOS_Name"];
        string HRP_Post = Request.QueryString["HRP_Post"];

        string condition = "";
        string temp = "";
        if (HRDD_StaffNO != "")
        {
            temp += " and HRDD_StaffNO like '%" + HRDD_StaffNO + "%'";
        }
        if (HRDD_Name != "")
        {
            temp += " and HRDD_Name like '%" + HRDD_Name + "%'";
        }
        if (HRSR_ChargePer != "")
        {
            temp += " and HRSR_ChargePer like '%" + HRSR_ChargePer + "%'";
        }
        if (BDOS_Name != "")
        {
            temp += " and BDOS_Name like '%" + BDOS_Name + "%'";
        }
        if (HRP_Post != "")
        {
            temp += " and HRP_Post like '%" + HRP_Post + "%'";
        }
        //时间
        if (startime != "" && endtime != "")
        {
            temp += " and HRSR_Time >= '" + startime + "' and HRSR_Time <= '" + endtime + "'";
        }
        if (startime != "" && endtime == "")
        {
            temp += " and HRSR_Time >= '" + startime + "'";
        }
        if (startime == "" && endtime != "")
        {
            temp += " and HRSR_Time <= '" + endtime + "'";
        }
        if (startime == "" && endtime == "")
        {
            temp += "";
        }
        condition = temp;
        Grid_Detail.DataSource = sd.S_PersonnelSalaryRecord(condition);
        Grid_Detail.DataBind();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/REPORT_cc/PersonnelSalaryRecord.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        //ExcelHelper.GridViewToExcel(Grid_Detail, "人事调薪报表");
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=" + "人事调薪报表.xls");
        Response.Charset = "utf-8";
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
        Response.ContentType = "application/vnd.ms-excel";
        string strStyle = "<style>td{mso-number-format:\"\\@\";}</style>";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        stringWrite.WriteLine(strStyle);
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

        Grid_Detail.RenderControl(htmlWrite);

        Response.Write(stringWrite.ToString());
        Response.End();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
    }

    //Grid_Detail多表头合并
    protected void Grid_Detail_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //判断创建的行是否为表头行
        if (e.Row.RowType == DataControlRowType.Header)
        {
            //获取表头所在行的所有单元格
            TableCellCollection tcHeader = e.Row.Cells;
            //清除自动生成的表头
            tcHeader.Clear();

            //第一行表头
            tcHeader.Add(new TableHeaderCell());
            tcHeader[0].RowSpan = 2;
            tcHeader[0].Text = "序号";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[1].RowSpan = 2;
            tcHeader[1].Text = "调薪日期";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[2].RowSpan = 2;
            tcHeader[2].Text = "工号";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[3].RowSpan = 2;
            tcHeader[3].Text = "姓名";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[4].RowSpan = 2;
            tcHeader[4].Text = "部门";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[5].RowSpan = 2;
            tcHeader[5].Text = "岗位";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[6].ColumnSpan = 4;
            tcHeader[6].Text = "调薪情况";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[7].RowSpan = 2;
            tcHeader[7].Text = "调薪负责人";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[8].RowSpan = 2;
            tcHeader[8].Text = "调薪原因</th></tr><tr>";

            //第二行表头
            tcHeader.Add(new TableHeaderCell());
            tcHeader[9].Text = "原薪资";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[10].Text = "现薪资";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[11].Text = "调薪金额";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[12].Text = "调薪幅度(%)";
        }
    }


}