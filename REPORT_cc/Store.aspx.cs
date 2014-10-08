using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class REPORT_cc_Store : Page
{
    OrderDeliverD dp = new OrderDeliverD();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Title="库存明细账";
         
            //try
            //{
            //    if (!((Session["UserRole"].ToString().Contains("发货计划统计"))))
            //    {
            //        Response.Redirect("~/Default.aspx");
            //    }
            //}
            //catch (Exception)
            //{
            //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('可能您没有权限操作和查看本页面，请退出选择其他账号登陆，或联系管理员！')", true);
            //    Response.Redirect("~/Default.aspx");
            //}

        }
     

    }

  
    #region gridview

    //检索
    protected void SelectMat(object sender, EventArgs e)
    {
        GetCondition();
        BindMat();

    }
    protected void BindMat()
    {
        Gridview_Pur.DataSource = dp.SelectKucunMain(label38.Text.ToString());
        Gridview_Pur.DataBind();
        UpdatePanel2.Update();
    }
    //condition
    protected void GetCondition()
    {
        string temp = "";
        if (TextBox3.Text != "")
        {
            temp += " and b.Name like '%" + TextBox3.Text + "%'";

        }
        if (TextBox4.Text != "")
        {
            temp += " and b.Model like '%" + TextBox4.Text + "%'";
        }
        if (DropDownList1.SelectedValue == "基础物料")
        {
            temp += " and a.PT_ID is null";
        }
        else if (DropDownList1.SelectedValue == "公司产品")
        {
            temp += " and a.IMMBD_MaterialID is null";
        }
        label38.Text = temp;
       
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedValue == "基础物料")
        {
            Label41.Text = "物料名称";
            Label42.Text="规格型号";
            UpdatePanel2.Update();
        }
        else if (DropDownList1.SelectedValue == "公司产品")
        {
            Label41.Text = "产品名称";
            Label42.Text = "产品备注";
            UpdatePanel2.Update();
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
    }
    protected void Gridview_Pur_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Look5")
        {
            GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
            Panel3.Visible = true;
            Label1.Text = " and (mid like '" + e.CommandArgument.ToString() + "'  or  pid like '" + e.CommandArgument.ToString() + "')";
            Label3.Text = Gridview_Pur.Rows[gvr.RowIndex].Cells[0].Text + Gridview_Pur.Rows[gvr.RowIndex].Cells[1].Text;
            BindDetail();
        }
    }
    protected void BindDetail()
    {
        string id = Label1.Text.ToString();
        GridView2.DataSource = dp.SelectKucunDetail(id);
        GridView2.DataBind();
        UpdatePanel_KucunD.Update();
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (TextBox20.Text == "" || TextBox1.Text == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请选择完整时间段！')", true);
        }
        else
        {
            Label1.Text=" and iotime between'"+TextBox20.Text+"' and '"+TextBox1.Text+"'";
            BindDetail();
            Panel_kucun1.Visible = false;
            Panel3.Visible = true;
            UpdatePanel_KucunD.Update();
            UpdatePanel2.Update();
        }
    }
    protected void Gridview_Pur_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview_Pur.BottomPagerRow;


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

        BindMat();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview_Pur.PageCount ? Gridview_Pur.PageCount - 1 : newPageIndex;
        Gridview_Pur.PageIndex = newPageIndex;
        Gridview_Pur.DataBind();
    }
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView2.BottomPagerRow;


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

        BindDetail();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView2.PageCount ? GridView2.PageCount - 1 : newPageIndex;
        GridView2.PageIndex = newPageIndex;
        GridView2.DataBind();
    }
   
    protected void Excel1(object sender, EventArgs e)
    {
        Gridview_Pur.AllowPaging = false;
        BindMat();
        ExcelHelper.GridViewToExcel(Gridview_Pur, "库存主表");
    }
    protected void Excel2(object sender, EventArgs e)
    {
        GridView2.AllowPaging = false;
        BindDetail();
        ExcelHelper.GridViewToExcel(GridView2, Label3.Text+"库存明细表");
    }
    protected void CloseStoreD(object sender, EventArgs e)
    {
        Panel3.Visible = false;
        UpdatePanel_KucunD.Update();
        Panel_kucun1.Visible = true;
        UpdatePanel2.Update();
    }
}
    #endregion