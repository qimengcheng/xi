using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class REPORT_cc_PBProTypeInfo : System.Web.UI.Page
{
    PBProTypeInfoD pbInfo = new PBProTypeInfoD();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (!(Session["UserRole"].ToString().Contains("产品型号说明表")))
                {
                    Response.Redirect("~/Default.aspx");
                }

            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('可能您没有权限操作和查看本页面，请退出选择其他账号登陆，或联系管理员！')", true);
                Response.Redirect("~/Default.aspx");
            }

        }
    }
    protected void BtnSearchProType_Click(object sender, EventArgs e)
    {
        Grid_ProType.PageIndex = 0;
        DataBindAll();
    }
    protected void BtnPrintReport_Click(object sender, EventArgs e)
    {
        Response.Redirect("../REPORT_cc/PBProTypeInfoPrint.aspx?" + "&ProSeries=" + TxtProSeries.Text.Trim() + "&PTName=" + TxtProType.Text.Trim() + "&PTCode=" + TxtProCode.Text.Trim());
    }
    protected void BtnResetProType_Click(object sender, EventArgs e)
    {
        Grid_ProType.PageIndex = 0;
        Clear();
        DataBindAll();
    }
    private void DataBindAll()
    {
        string condition;

        string ProSeries = TxtProSeries.Text.Trim() == "" ? " and 1=1 " : " and PS_Name like '%" + TxtProSeries.Text.Trim() + "%' ";
        string PTName = TxtProType.Text.Trim() == "" ? " and 1=1 " : " and PT_Name like '%" + TxtProType.Text.Trim() + "%' ";
        string PTCode = TxtProCode.Text.Trim() == "" ? " and 1=1 " : " and PT_Code like '%" + TxtProCode.Text.Trim() + "%' "; ;

        condition = ProSeries + PTName + PTCode;
        try
        {
            Grid_ProType.DataSource = pbInfo.SearchPBTypeInfo(condition);
        }
        catch (Exception)
        {
            
            throw;
        }
        
        Grid_ProType.DataBind();
        UpdatePanel_ProType.Update();
    }
    protected void Grid_ProType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        { // when click the "GO" Button
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_ProType.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox");   // refer to the TextBox with the NewPageIndex value
            }

            if (null != txtNewPageIndex && txtNewPageIndex.Text != "")
            {
                newPageIndex = int.Parse(txtNewPageIndex.Text) - 1; // get the NewPageIndex
            }
        }
        else
        {  // when click the first, last, previous and next Button
            newPageIndex = e.NewPageIndex;
        }

        // check to prevent form the NewPageIndex out of the range


        //绑定数据源
        //bindgridview1();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_ProType.PageCount ? Grid_ProType.PageCount - 1 : newPageIndex;
        // specify the NewPageIndex
        Grid_ProType.PageIndex = newPageIndex;
        DataBindAll();

        Grid_ProType.SelectedIndex = -1;
        UpdatePanel_ProType.Update();
    }

    private void Clear()
    {
        TxtProSeries.Text = "";
        TxtProType.Text = "";
        TxtProCode.Text = "";
    }
}