using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;
public partial class PurchasingMgt_WIP_PBC : System.Web.UI.Page
{
    WIP_PBCD wd = new WIP_PBCD();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //重置
    protected void Button3_Reset(object sender, EventArgs e)
    {
        this.TextBox2.Text = "";
    }
    //关闭
    protected void Button2_Click(object sender, EventArgs e)
    {

    }
 
    //public override void VerifyRenderingInServerForm(Control control)
    //{
    //    // Confirms that an HtmlForm control is rendered for
    //}
    protected void Button1_Sh(object sender, EventArgs e)
    {
        DataSet ds= wd.SelectWIP_PBC(this.TextBox2.Text.ToString());
        DataTable dt = ds.Tables[0].Copy(); 
        CreateExcel(dt, "工序产量统计表");
    }


    private void CreateExcel(DataTable dt, string fileName)
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