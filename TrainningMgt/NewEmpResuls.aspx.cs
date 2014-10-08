using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TrainningMgt_NewEmpResuls : Page
{
    NewEmpResulsL newEmpResulsL = new NewEmpResulsL();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserRole"] == null)
        {
            Response.Write("<script>alert('您长时间未操作，请重新登录！');window.location.href='~/Default.aspx';</script>");
        }
        #region//权限控制

        if (!((Session["UserRole"].ToString().Contains("新员工培训结果查看"))))
        {
            Response.Redirect("~/Default.aspx");

        }
        if (Request.QueryString["status"] == "LookResult")
        {
            Title = "新员工培训结果查看";
        }
        #endregion

        if (!IsPostBack)
        {
            BindGridView_Info("");
        }
    }
    #region//绑定Gridview的方法
    private void BindGridView_Info(string Condition)
    {
        GridView_Info.DataSource = newEmpResulsL.Search_HRDDetail_NETraEachItemResultDetail(Condition);
        GridView_Info.DataBind();
    }//新员工培训结果列表GridView_Info
    private void BindGridView1()
    {
        //" and a.NETPCT_ID ='"+this.Label2.Text+"'" + 
        GridView1.DataSource = newEmpResulsL.Search_Others_NETraEachItemResultDetai(new Guid(Label2.Text));
        GridView1.DataBind();
    }//新员工培训详情列表GridView1

    #endregion


    #region//新员工培训信息检索栏
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        LblCondition1.Text = TxtSName.Text.Trim() == "" ? " " : " and NETPCT_Name like '%" + TxtSName.Text.Trim() + "%'";
        LblCondition1.Text += TextBox1.Text.Trim() == "" ? " " : " and NETPCT_Sex = '" + TextBox1.Text.Trim() + "'";
        LblCondition1.Text += TxtSStartTime.Text.Trim() == "" ? " " : " and NETPCT_Date >= '" + TxtSStartTime.Text.Trim() + "'";
        LblCondition1.Text += TxtSEndTime.Text.Trim() == "" ? " " : " and NETPCT_Date <= '" + TxtSEndTime.Text.Trim() + "'";
        LblRecordIsSearch.Text = "检索后";
        GridView_Info.SelectedIndex = -1;
        BindGridView_Info(LblCondition1.Text);
        UpdatePanel2.Update();
    }//检索

    protected void BtnReset_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TxtSName.Text = "";
        TxtSStartTime.Text = "";
        TxtSEndTime.Text = "";
        LblRecordIsSearch.Text = "检索前";
        GridView_Info.SelectedIndex = -1;
        BindGridView_Info("");
        UpdatePanel2.Update();
    }
    #endregion


    #region//GridView_Info的内置事件
    protected void GridView_Info_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView_Info.Rows.Count; i++)
        {
            for (int j = 0; j < GridView_Info.Rows[i].Cells.Count; j++)
            {
                GridView_Info.Rows[i].Cells[j].ToolTip = GridView_Info.Rows[i].Cells[j].Text;
                if (GridView_Info.Rows[i].Cells[j].Text.Length > 15)
                {
                    GridView_Info.Rows[i].Cells[j].Text = GridView_Info.Rows[i].Cells[j].Text.Substring(0, 16) + "...";
                }
            }
        }
    }
    protected void GridView_Info_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
        if (e.CommandName == "DetailInfo")
        {
            GridView_Info.SelectedIndex = row.RowIndex;
            Panel3.Visible = true;
            Label1.Text = row.Cells[1].Text;
            Label2.Text = e.CommandArgument.ToString();
            try
            {
                BindGridView1();
            }
            catch (Exception)
            {
                
                throw;
            }
            
            UpdatePanel3.Update();
            
        }
    }
    protected void GridView_Info_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView_Info.BottomPagerRow;


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
        //Grid_Post.DataBind();
        if (LblRecordIsSearch.Text == "检索前")
            BindGridView_Info("");
        if (LblRecordIsSearch.Text == "检索后")
            BindGridView_Info(LblCondition1.Text);

        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView_Info.PageCount ? GridView_Info.PageCount - 1 : newPageIndex;
        GridView_Info.PageIndex = newPageIndex;
        GridView_Info.DataBind();
    }
    #endregion


    protected void BtnClose_Click(object sender, EventArgs e)
    {
        Panel3.Visible = false;
        UpdatePanel3.Update();
    }//关闭

    #region//GridView1的内置事件
    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            for (int j = 0; j < GridView1.Rows[i].Cells.Count; j++)
            {
                GridView1.Rows[i].Cells[j].ToolTip = GridView1.Rows[i].Cells[j].Text;
                if (GridView1.Rows[i].Cells[j].Text.Length > 15)
                {
                    GridView1.Rows[i].Cells[j].Text = GridView1.Rows[i].Cells[j].Text.Substring(0, 16) + "...";
                }
            }
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView1.BottomPagerRow;


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
        BindGridView1();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView1.PageCount ? GridView1.PageCount - 1 : newPageIndex;
        GridView1.PageIndex = newPageIndex;
        GridView1.DataBind();
    }
    #endregion
}