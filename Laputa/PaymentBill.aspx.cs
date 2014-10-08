using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Laputa_PaymentBill : Page
{
    private readonly PaymentBill pb = new PaymentBill();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Session["UserRole"].ToString().Contains("采购付款"))
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        catch 
        {
            Response.Redirect("~/Default.aspx");
        }
       
        GridView1.DataSource = pb.Query_Bill(null, 0);
        GridView1.DataBind();
        UpdatePanel2.Update();
    }

    protected void Search_Click(object sender, EventArgs e)
    {
        try
        {
            GridView1.DataSource = pb.Query_Bill(TextBox1.Text, Convert.ToInt32(TextBox2.Text));
            GridView1.DataBind();
            UpdatePanel2.Update();
        }
        catch (Exception)
        {
            GridView1.DataSource = pb.Query_Bill(TextBox1.Text,0);
            GridView1.DataBind();
            UpdatePanel2.Update();
            
        }
     
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Auto")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Panel3.Visible = true;
            UpdatePanel3.Update();
            Maxnum.Text = row.Cells[4].Text;
            PID.Text = e.CommandArgument.ToString();
        }
       
        if (e.CommandName == "Details")
        {
              PID.Text = e.CommandArgument.ToString();
            GridView2.DataSource = pb.Query_BillMain(new Guid(PID.Text));
            GridView2.DataBind();
            Panel4.Visible = true;
            UpdatePanel4.Update();
        }
         if (e.CommandName == "NotBill")
         {
             PID.Text = e.CommandArgument.ToString();
             Panel6.Visible = true;
             UpdatePanel6.Update();
             GridView4.DataSource = pb.Query_PurchaseOrderDetailNotBill(new Guid(PID.Text));
             GridView4.DataBind();
             UpdatePanel6.Update();
         }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = theGrid.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textboxp1");   // refer to the TextBox with the NewPageIndex value
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
        try
        {
          int a=  Convert.ToInt32(TextBox2.Text);
        }
        catch (Exception)
        {
            theGrid.DataSource = pb.Query_Bill(TextBox1.Text,0);
            theGrid.DataBind();
        }
     
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= theGrid.PageCount ? theGrid.PageCount - 1 : newPageIndex;
        theGrid.PageIndex = newPageIndex;
        theGrid.DataBind();
    }

    protected void CloseAuto_Click(object sender, EventArgs e)
    {
        Panel3.Visible = false;
        UpdatePanel3.Update();
    }

    protected void Auto_Bingo_Click(object sender, EventArgs e)
    {
        if (TextBox13.Text == "" || TextBox17.Text == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('标*的为必填项,请填写完整!');", true);
        }
        else if (Convert.ToDecimal(TextBox13.Text)>Convert.ToDecimal(Maxnum.Text))
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof (Page), "alert", "alert('不能大于还需开票金额哦!')", true);
        }
        else
        { 

            DateTime str=new DateTime(2000,1,1);
            DateTime end=new DateTime(3000,1,1);
            if (TextBox4.Text != "")
            {
                try
                {
                    str = Convert.ToDateTime(TextBox4.Text);
                  
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof (Page), "alert", "alert('时间输入不对！')", true);
                    return;
                }
            }
            if (TextBox9.Text != "")
            {
                try
                {
                   end = Convert.ToDateTime(TextBox9.Text);
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('时间输入不对！')", true);
                    return;
                }
            }

            decimal amount = Convert.ToDecimal(TextBox13.Text);
            string billnum = TextBox17.Text;
            string note = TextBox16.Text;
            pb.Insert_BillDetail(new Guid(PID.Text), amount, billnum, Session["UserName"].ToString(), note,str,end);
            ScriptManager.RegisterStartupScript(this.Page, typeof (Page), "alert", "alert('自动开票完成!')", true);
            GridView1.DataSource = pb.Query_Bill(null, 0);
            GridView1.DataBind();
            Panel3.Visible = false;
            UpdatePanel3.Update();
            
        }
    }

    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Details")
        {
            PMBID.Text = e.CommandArgument.ToString();
            GridView3.DataSource = pb.Query_BillDetail(new Guid(PMBID.Text));
            GridView3.DataBind();
            Panel5.Visible = true;
            UpdatePanel5.Update();
        }
    }

    protected void GridView4_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "swi")
        {
            pb.SwitchState(new Guid(e.CommandArgument.ToString()));
            GridView4.DataSource = pb.Query_PurchaseOrderDetailNotBill(new Guid(PID.Text));
            GridView4.DataBind();
            UpdatePanel6.Update();
        }
    }
    protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType==DataControlRowType.DataRow)
        {
            LinkButton lb = e.Row.Cells[12].FindControl("swi") as LinkButton;
            if (e.Row.Cells[11].Text== "暂不开票")
            {
                lb.Text = "设为可以开票";
                e.Row.ForeColor = Color.Firebrick;
            }
        }
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
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textboxp1");   // refer to the TextBox with the NewPageIndex value
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
        GridView2.DataSource = pb.Query_BillMain(new Guid(PID.Text));
        GridView2.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView2.PageCount ? GridView2.PageCount - 1 : newPageIndex;
        GridView2.PageIndex = newPageIndex;
        GridView2.DataBind();
    }
    protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView3.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textboxp1");   // refer to the TextBox with the NewPageIndex value
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
        GridView3.DataSource = pb.Query_BillDetail(new Guid(PMBID.Text));
        GridView3.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView3.PageCount ? GridView3.PageCount - 1 : newPageIndex;
        GridView3.PageIndex = newPageIndex;
        GridView3.DataBind();
    }
    protected void GridView4_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView4.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textboxp1");   // refer to the TextBox with the NewPageIndex value
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
        GridView4.DataSource = pb.Query_PurchaseOrderDetailNotBill(new Guid(PID.Text));
        GridView4.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView4.PageCount ? GridView4.PageCount - 1 : newPageIndex;
        GridView4.PageIndex = newPageIndex;
        GridView4.DataBind();
    }
}