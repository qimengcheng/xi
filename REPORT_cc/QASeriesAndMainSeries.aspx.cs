using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Laputa_QASeriesAndMainSeries : System.Web.UI.Page
{
    private readonly LaputaPrintPoolD lpp = new LaputaPrintPoolD();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SqlDataReader myReader = lpp.Query_PS_Name();
      
            while (myReader.Read())
            {
                DropDownList1.Items.Add(new ListItem(myReader["PS_Name"].ToString(), myReader["PS_Name"].ToString()));//增加Item
            }
            DropDownList1.SelectedIndex = 0;
            SqlDataReader myReader2 = lpp.Query_PMS_Name(DropDownList1.SelectedValue);
            DropDownList2.Items.Clear();
            DropDownList2.Items.Add(new ListItem("请选择", "请选择"));
            while (myReader2.Read())
            {
                DropDownList2.Items.Add(new ListItem(myReader2["PMS_Name"].ToString(), myReader2["PMS_Name"].ToString()));//增加Item
            }
        }
    }

    protected void Button37_Click(object sender, EventArgs e)
    {
        GridView1.DataSource = lpp.Query_Material(TextBox21.Text, TextBox22.Text);
        GridView1.DataBind();
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Choose")
        {
            var row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;

            var id = new Guid(e.CommandArgument.ToString());
            mid.Text = e.CommandArgument.ToString();
            Panel2.Visible = false;
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        var theGrid = sender as GridView; // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView1.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox");
                // refer to the TextBox with the NewPageIndex value
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
        Bindgrid1();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView1.PageCount ? GridView1.PageCount - 1 : newPageIndex;
        GridView1.PageIndex = newPageIndex;
        GridView1.DataBind();
    }

    protected void SearchInStoreMain(object sender, EventArgs e)
    {
        if (TextBox5.Text == "" || TextBox6.Text == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请选择时间段！');", true);
            return;
        }
        if (DropDownList2.SelectedValue=="请选择")
        {
            GridView2.DataSource = lpp.Query_QASeries(Convert.ToDateTime(TextBox5.Text),
            Convert.ToDateTime(TextBox6.Text),DropDownList1.SelectedValue);
            GridView2.DataBind();
        }
        else
        {
            GridView2.DataSource = lpp.Query_QAMainSeries(Convert.ToDateTime(TextBox5.Text),
                Convert.ToDateTime(TextBox6.Text),DropDownList1.SelectedValue,DropDownList2.SelectedValue);
            GridView2.DataBind();
        }
        Panel3.Visible = true;
        UpdatePanel3.Update();
    }

    private void Bindgrid2()
    {
        if (DropDownList2.SelectedValue == "请选择")
        {
            GridView2.DataSource = lpp.Query_QASeries(Convert.ToDateTime(TextBox5.Text),
            Convert.ToDateTime(TextBox6.Text), DropDownList1.SelectedValue);
            GridView2.DataBind();
        }
        else
        {
            GridView2.DataSource = lpp.Query_QAMainSeries(Convert.ToDateTime(TextBox5.Text),
                Convert.ToDateTime(TextBox6.Text), DropDownList1.SelectedValue,DropDownList2.SelectedValue);
            GridView2.DataBind();
        }
    }

    private void Bindgrid1()
    {
        GridView1.DataSource = lpp.Query_Material(TextBox21.Text, TextBox22.Text);
        GridView1.DataBind();
        GridView1.DataBind();
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        var theGrid = sender as GridView; // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView2.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox");
                // refer to the TextBox with the NewPageIndex value
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
        Bindgrid2();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView2.PageCount ? GridView2.PageCount - 1 : newPageIndex;
        GridView2.PageIndex = newPageIndex;
        GridView2.DataBind();
    }



    protected void Reset_Click(object sender, EventArgs e)
    {
        mid.Text = "mid";
        TextBox5.Text = "";
        TextBox6.Text = "";
  
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
    }


    protected void ChooseMaterial_Click(object sender, EventArgs e)
    {
        Panel2.Visible = true;
        GridView1.DataSource = lpp.Query_Material(TextBox21.Text, TextBox22.Text);
        GridView1.DataBind();
    }

    protected void print(object sender, EventArgs e)
    {
        if (TextBox5.Text == "" || TextBox6.Text == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请填写时间段！');", true);
            return;
        }
        if (DropDownList2.SelectedValue=="请选择")
        {
            Response.Redirect("~/report_cc/QASeriesAndMainSeriesPrint.aspx?stime=" + TextBox5.Text + "&etime=" +TextBox6.Text+"&Series="+DropDownList1.SelectedValue);
        }
        else
        {
            Response.Redirect("~/report_cc/QASeriesAndMainSeriesPrint.aspx?stime=" + TextBox5.Text + "&etime=" + TextBox6.Text + "&series=" + DropDownList1.SelectedValue+"&mainseries="+DropDownList2.SelectedValue);
        }
        
    }
    protected void searchprotype_Click(object sender, EventArgs e)
    {
        GridView3.DataSource = lpp.Query_ProType(TextBox1.Text, TextBox2.Text);
        GridView3.DataBind();
    }
    protected void ChooseProType_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        GridView3.DataSource = lpp.Query_ProType(TextBox1.Text, TextBox2.Text);
        GridView3.DataBind();
    }
    protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        var theGrid = sender as GridView; // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = theGrid.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox");
                // refer to the TextBox with the NewPageIndex value
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
        Bindgrid3();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= theGrid.PageCount ? theGrid.PageCount - 1 : newPageIndex;
        theGrid.PageIndex = newPageIndex;
        theGrid.DataBind();
    }

    private void Bindgrid3()
    {
        GridView3.DataSource = lpp.Query_ProType(TextBox1.Text, TextBox2.Text);
        GridView3.DataBind();
    }

    protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Choose")
        {
            var row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;

            var id = new Guid(e.CommandArgument.ToString());
            mid.Text = e.CommandArgument.ToString();
            Panel1.Visible = false;
        }
    }

    protected void GIG_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        
    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (DropDownList2.SelectedValue=="请选择")
            {
                SqlDataReader reader = lpp.Query_QAReportSeriesBad(Convert.ToInt32(e.Row.Cells[1].Text), Convert.ToInt32(e.Row.Cells[2].Text), Convert.ToInt32(e.Row.Cells[3].Text), e.Row.Cells[5].Text.Replace("amp;",""), DropDownList1.SelectedValue, Convert.ToDateTime(TextBox5.Text),
             Convert.ToDateTime(TextBox6.Text));
                var dt = new DataTable();
                int i = 0; DataRow dr = dt.NewRow();
                while (reader.Read())
                {
                    var dc = new DataColumn();
                    dc.ColumnName = reader["WOBP_Type"].ToString();
                    dt.Columns.Add(dc);
                    dr[i] = reader["WOBP_Num"].ToString();
                    i++;
                }
                dt.Rows.Add(dr);
                var ds = new DataSet();
                ds.Tables.Add(dt);
                var gv = e.Row.Cells[7].FindControl("GIG") as GridView;
                gv.DataSource = ds;
                gv.DataBind();
            }
            else
            {
                SqlDataReader reader = lpp.Query_QAReportMainSeriesBad(Convert.ToInt32(e.Row.Cells[1].Text), Convert.ToInt32(e.Row.Cells[2].Text), Convert.ToInt32(e.Row.Cells[3].Text), e.Row.Cells[6].Text.Replace("amp;", ""), DropDownList2.SelectedValue, Convert.ToDateTime(TextBox5.Text),
             Convert.ToDateTime(TextBox6.Text));
                var dt = new DataTable();
                int i = 0; DataRow dr = dt.NewRow();
                while (reader.Read())
                {
                    var dc = new DataColumn();
                    dc.ColumnName = reader["WOBP_Type"].ToString();
                    dt.Columns.Add(dc);
                    dr[i] = reader["WOBP_Num"].ToString();
                    i++;
                }
                dt.Rows.Add(dr);
                var ds = new DataSet();
                ds.Tables.Add(dt);
                var gv = e.Row.Cells[7].FindControl("GIG") as GridView;
                gv.DataSource = ds;
                gv.DataBind();
            }
           
           
        }
        TableCell myCell = e.Row.Cells[0];
        e.Row.Cells.RemoveAt(0);
        e.Row.Cells.Add(myCell);
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlDataReader myReader = lpp.Query_PMS_Name(DropDownList1.SelectedValue);
        DropDownList2.Items.Clear();
        DropDownList2.Items.Add(new ListItem("请选择", "请选择"));
        while (myReader.Read())
        {
            DropDownList2.Items.Add(new ListItem(myReader["PMS_Name"].ToString(), myReader["PMS_Name"].ToString()));//增加Item
        }
    }
 
}