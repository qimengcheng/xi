using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class REPORT_cc_Spare : Page
{
    SpareD sd = new SpareD();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //BindGrid_Detail("");

            try
            {
                if (!((Session["UserRole"].ToString().Contains("备件领用统计表"))))
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
    //绑定
    private void BindGrid_Detail(string condition)
    {
        Grid_Detail.DataSource = sd.S_EquipSpare_Statistical(condition);
        Grid_Detail.DataBind();
    }
    //检索按钮
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        string condition = GetCondition();
        BindGrid_Detail(condition);
        UpdatePanel_Grid.Update();
    }
    protected string GetCondition()
    {
        string condition;
        string temp = "";
        if (sparename.Text.ToString() != "")
        {
            temp += " and c.IMMBD_MaterialName like '%" + sparename.Text.Trim() + "%'";
        }
        if (sparemodel.Text.ToString() != "")
        {
            temp += " and c.IMMBD_MaterialCode like '%" + sparemodel.Text.Trim() + "%'";
        }
        if (equipno.Text.ToString() != "")
        {
            temp += " and f.EI_No like '%" + equipno.Text.Trim() + "%'";
        }
        if (startime.Text.ToString() != "" && endtime.Text.ToString() != "")
        {
            temp += " and ((e.EUP_UEndT >= '" + startime.Text.Trim() + "' and e.EUP_UEndT <= '" + endtime.Text.Trim() + "')  or ( d.ERDAOA_EndTime >= '" + startime.Text.Trim() + "' and d.ERDAOA_EndTime <= '" + endtime.Text.Trim() + "') or ( d.ERDAOA_OCTime >= '" + startime.Text.Trim() + "' and d.ERDAOA_OCTime <= '" + endtime.Text.Trim() + "'))";
        }
        if (startime.Text.ToString() != "" && endtime.Text.ToString() == "")
        {
            temp += " and (e.EUP_UEndT >= '" + startime.Text.Trim() + "'  or d.ERDAOA_EndTime >= '" + startime.Text.Trim() + "' or d.ERDAOA_OCTime >= '" + startime.Text.Trim() + "' )";
        }
        if (startime.Text.ToString() == "" && endtime.Text.ToString() != "")
        {
            temp += " and (e.EUP_UEndT <= '" + endtime.Text.Trim() + "' or d.ERDAOA_EndTime <= '" + endtime.Text.Trim() + "' or d.ERDAOA_OCTime <= '" + endtime.Text.Trim() + "')";
        }
        if (startime.Text.ToString() == "" && endtime.Text.ToString() == "")
        {
            temp += "";
        }
        condition = temp;
        return condition;
    }
    //重置按钮
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        sparename.Text = "";
        sparemodel.Text = "";
        equipno.Text = "";
        startime.Text = "";
        endtime.Text = "";
        //BindGrid_Detail("");
        UpdatePanel_Grid.Update();
    }
    //打印报表按钮
    protected void BtnPrint_Click(object sender, EventArgs e)
    {
        Response.Redirect("../REPORT_cc/SparePrint.aspx?" + "&IMMBD_MaterialName=" + sparename.Text + "&IMMBD_MaterialCode=" + sparemodel.Text + "&EI_No=" + equipno.Text + "&startime=" + startime.Text + "&endtime=" + endtime.Text);
    }
    //Grid_Detail翻页
    protected void Grid_Detail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_Detail.BottomPagerRow;


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
        {
            newPageIndex = e.NewPageIndex;
        }
        string condition = GetCondition();
        BindGrid_Detail(condition);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_Detail.PageCount ? Grid_Detail.PageCount - 1 : newPageIndex;
        Grid_Detail.PageIndex = newPageIndex;
        Grid_Detail.DataBind();
    }
}