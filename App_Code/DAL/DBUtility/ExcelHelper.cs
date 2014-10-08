using System;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
///     ExcelHelper 的摘要说明
/// </summary>
public class ExcelHelper
{
    public static void GridViewToExcel(GridView ctrl, string name)
    {
        DateTime dt = DateTime.Now;
        string str = !string.IsNullOrEmpty(name) ? name : dt.ToString("yyyyMMddhhmmss");
        str = str + ".xls";
        ctrl.AllowPaging = false;
        HttpContext.Current.Response.Charset = "GB2312";
        HttpContext.Current.Response.ContentEncoding = Encoding.UTF8; //注意编码
        HttpContext.Current.Response.AppendHeader("Content-Disposition",
            "attachment;filename=" + HttpUtility.UrlEncode(str, Encoding.UTF8));
        HttpContext.Current.Response.ContentType = "application/ms-excel";
        ctrl.Page.EnableViewState = false;
        var tw = new StringWriter();
        var hw = new HtmlTextWriter(tw);
        ctrl.RenderControl(hw);
        HttpContext.Current.Response.Write("\ufeff" + tw);
        HttpContext.Current.Response.End();
    }
}