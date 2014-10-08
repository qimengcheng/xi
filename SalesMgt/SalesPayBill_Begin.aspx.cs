using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using RTXHelper;

public partial class SalesMgt_SalesPayBillBegin : System.Web.UI.Page
{
    
    SalesAfterD st = new SalesAfterD();
    SalesPayBillD1 sp = new SalesPayBillD1();
    SalesPriceD sprice = new SalesPriceD();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindMain();
            BindCustom();
          
            
        }
        #region 权限
      
     
            this.Title = "客户初始金额维护";
            
            this.Gridview_Main.Columns[8].Visible = true;
            this.UpdatePanel_Main.Update();
            this.UpdatePanel_SearchMain.Update();
            this.Gridview_Main.Columns[9].Visible = true;
            this.UpdatePanel_Main.Update();
       

        #endregion
    }

    
    #region Main
    //绑定价格账期表
    protected void BindMain()
    {
        this.Gridview_Main.DataSource = sp.Select_Main(this.label19.Text.ToString());
        this.Gridview_Main.DataBind();
        this.UpdatePanel_Main.Update();
    }
    //
    public string GetCondition_Main()
    {
        string conditon;
        string temp = "";
        if (this.TextBox13.Text != "")
        {
            temp += " and CRMCIF_Name like'%" + this.TextBox13.Text.ToString().Trim() + "%'";
        }
    
        conditon = temp;
        this.label19.Text = conditon;
        return conditon;
    }
    //检索main
    protected void SearchMain(object sender, EventArgs e)
    {
        GetCondition_Main();
        BindMain();
    }
    //新建主表
    protected void NewPayBill(object sender, EventArgs e)
    {
        this.Panel1.Visible = true;
        this.Label7.Text = "新建";
        this.UpdatePanel1.Update();
    }
   
    //选择客户
    protected void SearchCustom_Main(object sender, EventArgs e)
    {
        this.label41.Text = "Main";
        this.Panel1_Custom.Visible = true;
        this.UpdatePanel_Custom.Update();
        this.Panel1_SearchCus.Visible = true;
        this.UpdatePanel_SearchCus.Update();
    }
    //query新建主表
    protected void NewMain(object sender, EventArgs e)
    {
        try
        {
            if (this.Label7.Text == "新建")
            {
                Guid id = new Guid(this.Label29.Text.ToString());
                decimal totalloan = Convert.ToDecimal(this.TextBox3.Text.ToString());
                decimal rateloan = Convert.ToDecimal(this.TextBox4.Text.ToString());
                decimal bill = Convert.ToDecimal(this.TextBox18.Text.ToString());
                string man = Session["UserName"].ToString().Trim();
                sp.Insert_Main(id, totalloan, rateloan, bill, man);
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", "alert('新建成功！')", true);
                BindMain();
                this.Panel1.Visible = false;
                this.UpdatePanel1.Update();


            }
            else if (this.Label7.Text == "编辑")
            {
                Guid mainID = new Guid(this.Label29.Text.ToString());
                decimal totalloan = Convert.ToDecimal(this.TextBox3.Text.ToString());
                decimal rateloan = Convert.ToDecimal(this.TextBox4.Text.ToString());
                decimal bill = Convert.ToDecimal(this.TextBox18.Text.ToString());
                string man = Session["UserName"].ToString().Trim();
                sp.Update_Main(mainID, totalloan, rateloan, bill, man);
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", "alert('编辑成功！')", true);
                this.Panel1.Visible = false;
                this.UpdatePanel1.Update();
                BindMain();

            }
        }
        catch (Exception)
        {

            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", "alert('你可能选择了相同的客户！')", true);

        }
        
    }
    //取消新建主表
    protected void NewMainClose(object sender, EventArgs e)
    {
        this.Panel1.Visible = false;
        this.UpdatePanel1.Update();
    }
    protected void Gridview_Main_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = this.Gridview_Main.BottomPagerRow;


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
        BindMain();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= this.Gridview_Main.PageCount ? this.Gridview_Main.PageCount - 1 : newPageIndex;
        this.Gridview_Main.PageIndex = newPageIndex;
        this.Gridview_Main.DataBind();
    }
    protected void Gridview_Main_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
        if (e.CommandName == "Edit1")
        {
            this.Label7.Text = "编辑";
            this.Label29.Text = e.CommandArgument.ToString();
            this.Label26.Text = this.Gridview_Main.Rows[gvr.RowIndex].Cells[2].Text.ToString();
            this.Label3.Text = this.Gridview_Main.DataKeys[gvr.RowIndex]["CRMCIF_ID"].ToString();
            this.TextBox15.Text = this.Gridview_Main.Rows[gvr.RowIndex].Cells[2].Text.ToString();
            this.TextBox3.Text = this.Gridview_Main.Rows[gvr.RowIndex].Cells[3].Text.ToString();
            this.TextBox4.Text = this.Gridview_Main.Rows[gvr.RowIndex].Cells[4].Text.ToString();
            this.TextBox18.Text = this.Gridview_Main.Rows[gvr.RowIndex].Cells[5].Text.ToString();
            this.Panel1.Visible = true;
            this.UpdatePanel1.Update();
        }
        if (e.CommandName == "Delete1")
        {
            Guid id = new Guid(e.CommandArgument.ToString());
            sp.Delete_Main(id);
            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", "alert('删除成功！')", true);
            BindMain();

        }
       
        if (e.CommandName == "AllSee")
        {
            label34.Text = e.CommandArgument.ToString();
            Panel2.Visible = true;
            BindHistory();

        }
    }
    protected void BindHistory()
    {
        Gridview1.DataSource = sp.Select_History(new Guid(label34.Text.ToString()));
        Gridview1.DataBind();
        UpdatePanel2.Update();
    }
   

    #endregion
  

    #region 客户
    //open选择客户
    protected void SearchCustom1(object sender, EventArgs e)
    {
        this.Panel1_SearchCus.Visible = true;
        this.UpdatePanel_SearchCus.Update();
        this.Panel1_Custom.Visible = true;
        BindCustom();
    }
    //绑定客户
    protected void BindCustom()
    {
        this.Gridview2.DataSource = st.Select_Kehu(this.label6.Text.ToString());
        this.Gridview2.DataBind();
        this.UpdatePanel_Custom.Update();
    }
    //检索客户
    protected void SearchCustomer(object sender, EventArgs e)
    {
       
            this.label6.Text = " and CRMCIF_Name like'%" + this.TextBox6.Text.ToString().Trim() + "%'";
       
        BindCustom();
    }
    //取消检索客户
    protected void CloseSearchCustomer(object sender, EventArgs e)
    {
        this.Panel1_SearchCus.Visible = false;
        this.UpdatePanel_SearchCus.Update();
        this.Panel1_Custom.Visible = false;
        this.UpdatePanel_Custom.Update();
    }
    protected void Gridview2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
        if (e.CommandName == "Check2")
        {
            string id = e.CommandArgument.ToString();
            if (this.label41.Text == "Main")
            {
                this.Label29.Text = id;
                this.TextBox15.Text = this.Gridview2.Rows[gvr.RowIndex].Cells[1].Text.ToString().Trim().Replace("&nbsp;", "");
                this.UpdatePanel1.Update();

            }
          
            
            this.Panel1_Custom.Visible = false;
            this.Panel1_SearchCus.Visible = false;
            this.UpdatePanel_SearchCus.Update();
            this.UpdatePanel_Custom.Update();
        }

    }
    protected void Gridview2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = this.Gridview2.BottomPagerRow;


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


        BindCustom();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= this.Gridview2.PageCount ? this.Gridview2.PageCount - 1 : newPageIndex;
        this.Gridview2.PageIndex = newPageIndex;
        this.Gridview2.DataBind();
    }
    #endregion
 
    
    protected void CloseHistory(object sender, EventArgs e)
    {
        Panel2.Visible = false;
        UpdatePanel2.Update();
    }
    protected void Gridview1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = this.Gridview1.BottomPagerRow;


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
        BindHistory();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= this.Gridview1.PageCount ? this.Gridview1.PageCount - 1 : newPageIndex;
        this.Gridview1.PageIndex = newPageIndex;
        this.Gridview1.DataBind();
    }
    protected void NewMainOpen(object sender, EventArgs e)
    {
        Label7.Text = "新建";
        Panel1.Visible = true;
        UpdatePanel1.Update();
    }
}