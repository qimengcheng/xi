﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class REPORT_cc_IPQCBad : System.Web.UI.Page
{
    SalesD sd = new SalesD();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DropDownList1.Items.Insert(0, new ListItem("请选择", ""));
            BindDropDownList1();
            try
            {
                if (!((Session["UserRole"].ToString().Contains("制程IPQC不良品汇总表"))))
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
    private void BindDropDownList1()
    {
        DropDownList1.DataSource = sd.S_PBCCraftInfo();
        DropDownList1.DataTextField = "PBC_Name";
        DropDownList1.DataValueField = "PBC_ID";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, new ListItem("请选择", ""));
    }
    //重置按钮
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        DropDownList1.Items.Insert(0, new ListItem("请选择", ""));
        BindDropDownList1();
        DropDownList1.SelectedValue = "";
        startime.Text = "";
        endtime.Text = "";
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedValue == "" || startime.Text == "" || endtime.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('请选择工序和统计起止时间！')", true);
            return;
        }
        string date1 = startime.Text;
        string date2 = endtime.Text;
        string PBC_ID = DropDownList1.SelectedValue.ToString();
        DataSet ds = sd.S_IPQCBad(date1, date2, PBC_ID);
        DataTable dt = ds.Tables[0];
        //ExcelHelper.ExportResult(ds, "生产工序产量汇总表(" + DropDownList1.SelectedItem.Text + startime.Text + "至" + endtime.Text + ")");
        ExportResult(dt, "制程IPQC不良品汇总表(" + DropDownList1.SelectedItem.Text + startime.Text + "至" + endtime.Text + ")");
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
    }

    private void ExportResult(DataTable dt, string fileName)
    {
        fileName = fileName + ".xls";
        HttpResponse resp;
        resp = Page.Response;
        resp.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
        resp.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(fileName, Encoding.UTF8));
        HttpContext.Current.Response.ContentType = "application/ms-excel";
        string colHeaders = "", ls_item = "";

        ////定义表对象与行对象，同时用DataSet对其值进行初始化 
        //DataTable dt = ds.Tables[0]; 
        DataRow[] myRow = dt.Select();//可以类似dt.Select("id>10")之形式达到数据筛选目的 
        int i = 0;
        int cl = dt.Columns.Count;

        //取得数据表各列标题，各标题之间以t分割，最后一个列标题后加回车符 
        for (i = 0; i < cl; i++)
        {
            if (i == (cl - 1))//最后一列，加n 
            {
                colHeaders += dt.Columns[i].Caption.ToString() + "\n";
            }
            else
            {
                colHeaders += dt.Columns[i].Caption.ToString() + "\t";
            }

        }
        resp.Write(colHeaders);
        //向HTTP输出流中写入取得的数据信息 

        //逐行处理数据 
        foreach (DataRow row in myRow)
        {
            //当前行数据写入HTTP输出流，并且置空ls_item以便下行数据 
            for (i = 0; i < cl; i++)
            {
                if (i == (cl - 1))//最后一列，加n 
                {
                    ls_item += row[i].ToString() + "\n";
                }
                else
                {
                    ls_item += row[i].ToString() + "\t";
                }

            }
            resp.Write(ls_item);
            ls_item = "";

        }
        resp.End();
    }

}