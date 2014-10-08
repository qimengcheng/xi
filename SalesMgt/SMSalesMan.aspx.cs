using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class SalesMgt_SalesMan : Page
{
    ProTypePrice ptp = new ProTypePrice();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        Title = "销售业务员管理";
        if (!IsPostBack)
        {
            BindMan();
            BindSort();
            BindDropDownList1();
            Button6.Visible = false;
        }
        try
        {
            if (!(Session["UserRole"].ToString().Contains("销售业务员管理")))
            {
                Response.Redirect("~/Default.aspx");

            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('可能您没有权限操作和查看本页面，请退出选择其他账号登陆，或联系管理员！')", true);
            Response.Redirect("~/Default.aspx");
     

        }   
        #region 权限
            if (Request.QueryString["status"] == "Man")//投诉类别查看
            {
                Title = "销售业务员管理";
                Panel_Search.Visible = true;
                UpdatePanel_Search.Update();
                Panel_PT.Visible = true;
                UpdatePanel_PT.Update();

            }

            if (Request.QueryString["status"] == "Sort")//投诉类别维护
            {
                Title = "业务员类别管理";
                Panel1.Visible = true;
                UpdatePanel1.Update();
                Panel2.Visible = true;
                UpdatePanel2.Update();

            }
            #endregion
    }




    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        { // when click the "GO" Button
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
        {  // when click the first, last, previous and next Button
            newPageIndex = e.NewPageIndex;
        }

        // check to prevent form the NewPageIndex out of the range


        //绑定数据源
        //bindgridview1();
        BindMan();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView2.PageCount ? GridView2.PageCount - 1 : newPageIndex;
        // specify the NewPageIndex
        GridView2.PageIndex = newPageIndex;
        GridView2.DataBind();

     

        //panel 隐藏

    }
    protected void GridView2_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView2.Rows.Count; i++)
        {
            for (int j = 0; j < GridView2.Rows[i].Cells.Count; j++)
            {
                GridView2.Rows[i].Cells[j].ToolTip = GridView2.Rows[i].Cells[j].Text;
                if (GridView2.Rows[i].Cells[j].Text.Length > 20)
                {
                    GridView2.Rows[i].Cells[j].Text = GridView2.Rows[i].Cells[j].Text.Substring(0, 20) + "...";
                }


            }
        }
    }
    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
        if (e.CommandName == "Edit2")
        {

            Panel_CheckParameter.Visible = true;
            Label1.Text = "编辑";
            Label19.Text = e.CommandArgument.ToString();
            Txt_parameter.Text = GridView2.Rows[row.RowIndex].Cells[1].Text.ToString();
            UpdatePanel_CheckParameter.Update();
        }
        if (e.CommandName == "Delete2")
        {
            ptp.Delete_SalesMan(new Guid(e.CommandArgument.ToString()));
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除成功！')", true);
            BindMan();
        }
    }
    protected void Btn_SearchSort_Click(object sender, EventArgs e)
    {
        string temp = "";
        if (TextBox1.Text != "")
        {
             temp = " and SMSMS_Name like '%" + TextBox1.Text + "%'";
            
        }
        Label17.Text = temp;
        BindSort();
    }
    protected void BindSort()
    {
        GridView1.DataSource = ptp.Select_SalesManSort(Label17.Text);
        GridView1.DataBind();
        UpdatePanel2.Update();
    }
    protected void Btn_NewSort_Click(object sender, EventArgs e)
    {
        Label2.Text = "新建";
        Panel3.Visible = true;
        TextBox2.Text = "";
        UpdatePanel3.Update();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        { // when click the "GO" Button
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
        {  // when click the first, last, previous and next Button
            newPageIndex = e.NewPageIndex;
        }

        // check to prevent form the NewPageIndex out of the range


        //绑定数据源
        //bindgridview1();
        BindSort();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView1.PageCount ? GridView1.PageCount - 1 : newPageIndex;
        // specify the NewPageIndex
        GridView1.PageIndex = newPageIndex;
        GridView1.DataBind();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
        if (e.CommandName == "Edit1")
        {

            Panel3.Visible = true;
            Label2.Text = "编辑";
            TextBox2.Text = GridView1.Rows[row.RowIndex].Cells[1].Text.ToString();
            TextBox3.Text=GridView1.DataKeys[row.RowIndex]["SMSMS_Note"].ToString();
            Label3.Text = e.CommandArgument.ToString();
            UpdatePanel3.Update();
        }
        if (e.CommandName == "Delete1")
        {
            ptp.Delete_SalesManSort(new Guid(e.CommandArgument.ToString()));
            BindSort();
        }
        if (e.CommandName == "Look1")
        {
            Label4.Text = GridView1.Rows[row.RowIndex].Cells[1].Text + "类别的";
            Panel_PT.Visible = true;
            Label18.Text = " and a.SMSMS_ID like '%" + e.CommandArgument.ToString() + "%'";
            Button6.Visible = true;
            BindMan();
        }
    }
    protected void ConfirmSort(object sender, EventArgs e)
    {
        string name = Label2.Text;
        if (name == "新建")
        {
            string name1 = TextBox2.Text;
            string note = TextBox3.Text;
            ptp.Insert_SalesManSort(name1, note);
            Panel3.Visible = false;
            TextBox3.Text = "";
            TextBox2.Text = "";
            UpdatePanel3.Update();
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('新建成功！')", true);
            BindSort();
            BindDropDownList1();
            
        }
        else if (name == "编辑")
        {
            string name1 = TextBox2.Text;
            string note = TextBox3.Text;
            Guid id = new Guid(Label3.Text.ToString());
            int count = ptp.Update_SalesManSort(id, name1, note);
            if (count == 0)
            {
                Panel3.Visible = false;
                TextBox3.Text = "";
                TextBox2.Text = "";
                UpdatePanel3.Update();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('编辑成功！')", true);
                BindSort();
                BindDropDownList1();
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('系统中已有相同名称的业务员类别，编辑失败，请重新更改类别名称！')", true);
                return;
            }
        }
    }
    protected void SearchMan(object sender, EventArgs e)
    {
        string temp = "";
        Button6.Visible = false;
        Label4.Text = "";
        if (Txt_search.Text != "")
        {
            temp = " and SMSM_Name like '%" + Txt_search.Text + "%'";

        }
        Label18.Text = temp;
        BindMan();
    }
    protected void BindMan()
    {
        GridView2.DataSource = ptp.Select_SalesMan(Label18.Text);
        GridView2.DataBind();
        UpdatePanel_PT.Update();
    }

    protected void NewMan(object sender, EventArgs e)
    {
        Label1.Text = "新建";
        Panel_CheckParameter.Visible = true;
        UpdatePanel_CheckParameter.Update();
    }
    protected void CloseSort(object sender, EventArgs e)
    {
        Panel3.Visible = false;
        TextBox2.Text = "";
        TextBox3.Text = "";
        UpdatePanel3.Update();
    }
    protected void Button_Close_CheckParameter_Click(object sender, EventArgs e)
    {
        Txt_parameter.Text = "";
        Panel_CheckParameter.Visible = false;
        UpdatePanel_CheckParameter.Update();
    }
    protected void  ClosePT(object sender, EventArgs e)
    {
        Panel_PT.Visible=false;
        UpdatePanel_PT.Update();
    }
    protected void Btn_I_parameter_Click(object sender, EventArgs e)
    {
        string name = Label1.Text;
        if (name == "新建")
        {
            string name1 = Txt_parameter.Text;
          
            Guid sid =new Guid( DropDownList1.SelectedValue.ToString());
            DataSet ds = ptp.Select_SalesManSame(name1);
            DataTable dt = ds.Tables[0];
            int count = Convert.ToInt32(dt.Rows[0][0].ToString());
            if (count == 0)
            {
                ptp.Insert_SalesMan(name1, sid);
                Panel_CheckParameter.Visible = false;
                Txt_parameter.Text = "";
             
             
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('新建成功！')", true);
                  BindMan();
                  Panel_CheckParameter.Visible = false;
   UpdatePanel_CheckParameter.Update();
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('系统中已有相同姓名的业务员，无法建立相同姓名的业务员，请选用新的业务员姓名！')", true);
                return;
            }

        }
        else if (name == "编辑")
        {
            string name1 = Txt_parameter.Text;
            Guid sid = new Guid(DropDownList1.SelectedValue.ToString());
          Guid id=new Guid(Label19.Text);
          int count = ptp.Update_SalesMan(id, name1, sid);
          if (count == 0)
          {
              ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('编辑成功！')", true);
              BindMan();
              Panel_CheckParameter.Visible = false;
              UpdatePanel_CheckParameter.Update();
          }
          else
          {
              ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('系统中已有相同姓名的业务员，无法建立相同姓名的业务员，请选用新的业务员姓名！')", true);
              return;
          }
        }
    }
    protected void BindDropDownList1()
    {
        DropDownList1.DataSource = ptp.Select_SalesManSort("");
        DropDownList1.DataTextField = "SMSMS_Name";
        DropDownList1.DataValueField = "SMSMS_ID";
        DropDownList1.DataBind();
        UpdatePanel_CheckParameter.Update();
    }
}