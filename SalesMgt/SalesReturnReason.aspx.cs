using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SalesMgt_SalesReturnReason : Page
{
    SalesReturnReasonD sr = new SalesReturnReasonD();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            label_OrderDeliverSearch.Text = "";
            BindReason();       
        }
        #region 权限
        Title = "退货原因基础数据";
        try
        {
            if (!(Session["UserRole"].ToString().Contains("退货原因基础数据")))
            {
                Response.Redirect("~/Default.aspx");

            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('可能您没有权限操作和查看本页面，请退出选择其他账号登陆，或联系管理员！')", true);
            Response.Redirect("~/Default.aspx");
        }

        #endregion
    }

    protected void BindReason()
    {
        Gridview_OrderDeliver.DataSource = sr.Select_Reason(label_OrderDeliverSearch.Text.ToString());
        Gridview_OrderDeliver.DataBind();
        UpdatePanel_OrderDeliver.Update();
    }
    #region Gridview
    //发货单
    protected void Gridview_OrderDeliver_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview_OrderDeliver.BottomPagerRow;


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

        BindReason();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview_OrderDeliver.PageCount ? Gridview_OrderDeliver.PageCount - 1 : newPageIndex;
        Gridview_OrderDeliver.PageIndex = newPageIndex;
        Gridview_OrderDeliver.DataBind();
    }
    protected void Gridview_OrderDeliver_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
        if (e.CommandName == "Edit1")//编辑
        {
            label3.Text = e.CommandArgument.ToString();
            Panel1.Visible = true;
            label12.Text = "编辑";
            label18.Text = Gridview_OrderDeliver.Rows[gvr.RowIndex].Cells[1].Text.ToString();
            TextBox6.Text = Gridview_OrderDeliver.DataKeys[gvr.RowIndex]["SMRR_Name"].ToString();
            TextBox7.Text = Gridview_OrderDeliver.DataKeys[gvr.RowIndex]["SMRR_Note"].ToString();
            UpdatePanel_Tuihuanhuo.Update();
         

        }
        if (e.CommandName == "Delete1")//退货
        {
            sr.Delete_Reason(new Guid(e.CommandArgument.ToString()));
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除成功！')", true);
            Panel1.Visible = false;
            UpdatePanel_Tuihuanhuo.Update();
            BindReason();
        }  
    }

    #endregion

    protected void Gridview_OrderDeliver_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        for (int i = 0; i < Gridview_OrderDeliver.Rows.Count; i++)
        {
            for (int j = 0; j < Gridview_OrderDeliver.Rows[i].Cells.Count; j++)
            {
                Gridview_OrderDeliver.Rows[i].Cells[j].ToolTip = Gridview_OrderDeliver.Rows[i].Cells[j].Text;
                if (Gridview_OrderDeliver.Rows[i].Cells[j].Text.Length > 20)
                {
                    Gridview_OrderDeliver.Rows[i].Cells[j].Text = Gridview_OrderDeliver.Rows[i].Cells[j].Text.Substring(0, 20) + "...";
                }
            }
        } 
    }
    protected void SearchReason(object sender, EventArgs e)
    {
        string temp = " and SMRR_Name like '%" + TextBox1.Text + "%'";
        label_OrderDeliverSearch.Text = temp;
        BindReason();
    }
    protected void NewReason(object sender, EventArgs e)
    {
        TextBox6.Text = "";
        TextBox7.Text = "";
        Panel1.Visible = true;
        label12.Text = "新增";
        label18.Text = "退货原因";
        UpdatePanel_Tuihuanhuo.Update();

    }
    protected void Tijiao(object sender, EventArgs e)
    {
        if (TextBox6.Text == "" || TextBox7.Text == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert(' 标红项必须填写！')", true);
            return;
        }
        else
        {
            string name = TextBox6.Text.ToString();
            string note = TextBox7.Text.ToString();
            if (label12.Text == "编辑")
            {
                Guid id = new Guid(label3.Text.ToString());
                sr.Update_Reason(id, name, note);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert(' 修改成功！')", true);
                Panel1.Visible = false;
                UpdatePanel_Tuihuanhuo.Update();
            }
            else if(label12.Text=="新增")
            {
                sr.Insert_Reason(name, note);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert(' 新增成功！')", true);
                Panel1.Visible = false;
                UpdatePanel_Tuihuanhuo.Update();
            }
        }
        BindReason();
    }
    protected void CloseTijiao(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        UpdatePanel_Tuihuanhuo.Update();
    }
}