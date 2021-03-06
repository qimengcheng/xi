﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class REPORT_cc_TimeChagePrint : System.Web.UI.Page
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
        string PBC_Name = Request.QueryString["PBC_Name"];
        string STI_Name = Request.QueryString["STI_Name"];
        string startime = Request.QueryString["startime"];
        string endtime = Request.QueryString["endtime"];

        string condition = "";
        string temp = "";
        if (PBC_Name != "")
        {
            temp += " and PBC_Name like '%" + PBC_Name + "%'";
        }
        if (STI_Name != "")
        {
            temp += " and STI_Name like '%" + STI_Name + "%'";
        }
        //时间
        if (startime != "" && endtime != "")
        {
            temp += " and STICR_ExecDate >= '" + startime + "' and STICR_ExecDate <= '" + endtime + "'";
        }
        if (startime != "" && endtime == "")
        {
            temp += " and STICR_ExecDate >= '" + startime + "'";
        }
        if (startime == "" && endtime != "")
        {
            temp += " and STICR_ExecDate <= '" + endtime + "'";
        }
        if (startime == "" && endtime == "")
        {
            temp += "";
        }
        condition = temp;
        Grid_Detail.DataSource = sd.S_TimeChage(condition);
        Grid_Detail.DataBind();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/REPORT_cc/TimeChage.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        ExcelHelper.GridViewToExcel(Grid_Detail, "计时工价变动表");
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
            tcHeader[1].Text = "工序";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[2].RowSpan = 2;
            tcHeader[2].Text = "计时项目";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[3].RowSpan = 2;
            tcHeader[3].Text = "单价";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[4].ColumnSpan = 4;
            tcHeader[4].Text = "调整情况</th></tr><tr>";

            //第二行表头
            tcHeader.Add(new TableHeaderCell());
            tcHeader[5].Text = "原单价";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[6].Text = "现单价";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[7].Text = "调整金额";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[8].Text = "调整比率(%)";
        }
    }
}