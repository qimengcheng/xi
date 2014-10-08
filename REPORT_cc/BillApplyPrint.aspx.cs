﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PurchasingMgt_BillApplyPrint : System.Web.UI.Page
{
    BillApplyD bd = new BillApplyD();
     protected void Page_Load(object sender, EventArgs e)
    {
        Labelpeople.Text = Session["UserName"].ToString();
        Labeltime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        //string condition = Request.QueryString["Getcondition()"];
        this.Gridview_OAInfo.DataSource = bd.SelectBillApply_Biaoji("");
        this.Gridview_OAInfo.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/PurchasingMgt/BillApply.aspx");
    }
    protected void Button_Excel(object sender, EventArgs e)
    {
        ExcelHelper.GridViewToExcel(Gridview_OAInfo, "开票申请汇总表");
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
    protected void Gridview_OAInfo_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
    }
}