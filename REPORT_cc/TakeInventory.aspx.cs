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

public partial class REPORT_cc_TakeInventory : System.Web.UI.Page
{
    BillApplyD bd = new BillApplyD();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.Title = "财务部在制品盘存统计表";
            this.TakeInventory.Text = "";
            this.TextBox_SPTime2.Text = "";
            this.TextBox_SPTime3.Text = "";
            this.UpdatePanel_TISearch.Update();
            BindGridview1("");
            this.UpdatePanel_TakeInventory.Update();
        }
    }
    private void BindGridview1(string condition)
    {
        this.Gridview1.DataSource = bd.SelectTakeInventory(condition);
        this.Gridview1.DataBind();
    }
    private void BindGridview2(string condition)
    {
        this.Gridview2.DataSource = bd.SelectTakeInventoryDetail(condition);
        this.Gridview2.DataBind();
    }

    //检索
    protected void Button1_Sh(object sender, EventArgs e)
    {
        string condition = Getcondition();
        BindGridview1(condition);
        this.UpdatePanel_TakeInventory.Update();
    }
    private string Getcondition()
    {
        string condition = "";
        if (this.TakeInventory.Text != "")
        {
            condition += "and TI_Man like'%" + this.TakeInventory.Text + "%'";
        }
        if (this.TextBox_SPTime2.Text != "" && this.TextBox_SPTime3.Text != "")
        {
            condition += "and TI_Time>='" + Convert.ToDateTime(this.TextBox_SPTime2.Text) + "'" + "and TI_Time<='" + Convert.ToDateTime(this.TextBox_SPTime3.Text) + "'";
        }
        if (this.TextBox_SPTime2.Text == "" && this.TextBox_SPTime3.Text != "")
        {
            condition += "and TI_Time<='" + Convert.ToDateTime(this.TextBox_SPTime3.Text) + "'";
        }
        if (this.TextBox_SPTime2.Text != "" && this.TextBox_SPTime3.Text == "")
        {
            condition += "and TI_Time>='" + Convert.ToDateTime(this.TextBox_SPTime2.Text) + "'";
        }
        return condition;
    }
    //重置
    protected void Button2_Reset(object sender, EventArgs e)
    {
        this.TakeInventory.Text = "";
        this.TextBox_SPTime2.Text = "";
        this.TextBox_SPTime3.Text = "";
        this.UpdatePanel_TISearch.Update();
        BindGridview1("");
        this.UpdatePanel_TakeInventory.Update();
    }
    //新增盘存记录
    protected void Button3_New(object sender, EventArgs e)
    {
        this.label12.Text = "新增盘存记录";
        this.TextBox3.Text = "";
        this.Panel3.Visible = true;
        this.UpdatePanel3.Update();



        //this.label9.Text = this.Gridview1.Rows[Gridview1.SelectedIndex].Cells[1].Text + "  " + this.Gridview1.Rows[Gridview1.SelectedIndex].Cells[2].Text + "   " + this.Gridview1.Rows[Gridview1.SelectedIndex].Cells[3].Text;
        //this.Panel1.Visible = true;
        //this.TextBox1.Text = "";
        //this.TextBox2.Text = "";
        //this.UpdatePanel1.Update();
        //this.Panel2.Visible = true;
        //BindGridview2("");
        //this.UpdatePanel2.Update();
    }
    //详情检索
    protected void Button_Sh(object sender, EventArgs e)
    {
        string condition = Getconditionn();
        BindGridview2(condition);
        this.UpdatePanel2.Update();
    }
    private string Getconditionn()
    {
        string condition = "and TI_ID='" + this.label_TI_ID.Text + "'";

        if (this.TextBox1.Text != "")
        {
            condition += "and TID_StyleName like '%" + this.TextBox1.Text + "%'";
        }
        if (this.TextBox2.Text != "")
        {
            condition += "and TID_ProName like '%" + this.TextBox2.Text + "%'";
        }
        return condition;
    }
    //重置
    protected void Button_Reset(object sender, EventArgs e)
    {
        this.TextBox1.Text = "";
        this.TextBox2.Text = "";
        string condition = "and TI_ID='" + this.label_TI_ID.Text + "'";
        BindGridview2(condition);
        this.UpdatePanel2.Update();
    }
    //提交
    protected void Button_TJ(object sender, EventArgs e)
    {
        string remark = this.TextBox3.Text;
        string man = Session["UserName"].ToString();
        if (this.label12.Text == "新增盘存记录")
        {
            bd.InsertTakeInventory(man, remark);
            BindGridview1("");
            //string condition = "and TI_ID='" + this.Gridview1.DataKeys[0].Value.ToString()+ "'";
            DataSet ds = bd.SelectZZPPC_CWB("");
            DataTable dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Guid TI_ID = new Guid(this.Gridview1.DataKeys[0].Value.ToString());
                string TID_StyleName = dt.Rows[i][0].ToString();
                string TID_ProName = dt.Rows[i][1].ToString();
                int TID_Num = Convert.ToInt32(dt.Rows[i][2].ToString());
                string TID_WO_Num = dt.Rows[i][3].ToString();
                bd.InsertTakeInventoryDetail(TI_ID, TID_StyleName, TID_ProName, TID_Num, TID_WO_Num);
            }
        }
        else
        {
            Guid TI_ID = new Guid(this.Gridview1.DataKeys[Gridview1.SelectedIndex].Value.ToString());
            bd.UpdateTakeInventory(TI_ID, remark);
        }
        BindGridview1("");
        this.Panel3.Visible = false;
        this.UpdatePanel3.Update();
        this.UpdatePanel_TakeInventory.Update();
        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "aa", "alert('提交成功！')", true);
        return;
    }
    //取消
    protected void Button_JL(object sender, EventArgs e)
    {
        this.TextBox3.Text = "";
        this.Panel3.Visible = false;
        this.UpdatePanel3.Update();
    }
    protected void Gridview1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Niguo")//编辑
        {

            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview1.SelectedIndex = row.RowIndex;
            this.label_TI_ID.Text = e.CommandArgument.ToString();
            this.label12.Text = "修改盘存记录  " + this.Gridview1.Rows[Gridview1.SelectedIndex].Cells[1].Text + "  " + this.Gridview1.Rows[Gridview1.SelectedIndex].Cells[2].Text + "   " + this.Gridview1.Rows[Gridview1.SelectedIndex].Cells[3].Text;
            string condition = "and TI_ID='" + this.label_TI_ID.Text + "'";
            DataSet ds = bd.SelectTakeInventory(condition);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                this.TextBox3.Text = dt.Rows[0][3].ToString();
            }
            this.Panel3.Visible = true;
            this.UpdatePanel3.Update();
        }
        if (e.CommandName == "Delete1")//删除
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview1.SelectedIndex = row.RowIndex;
            this.label_TI_ID.Text = e.CommandArgument.ToString();
            Guid TI_ID = new Guid(e.CommandArgument.ToString());
            bd.DeleteTakeInventory(TI_ID);
            BindGridview1("");
            this.UpdatePanel_TakeInventory.Update();
            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "aa", "alert('删除成功！')", true);
            return;

        }
        if (e.CommandName == "Approve")//详情
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview1.SelectedIndex = row.RowIndex;
            this.label_TI_ID.Text = e.CommandArgument.ToString();
            this.label9.Text = this.Gridview1.Rows[Gridview1.SelectedIndex].Cells[1].Text + "  " + this.Gridview1.Rows[Gridview1.SelectedIndex].Cells[2].Text + "   " + this.Gridview1.Rows[Gridview1.SelectedIndex].Cells[3].Text;
            this.Panel1.Visible = true;
            this.TextBox1.Text = "";
            this.TextBox2.Text = "";
            this.UpdatePanel1.Update();
            this.Panel2.Visible = true;
            string condition = "and TI_ID='" + this.label_TI_ID.Text + "'";
            BindGridview2(condition);
            this.UpdatePanel2.Update();
        }
    }
    //关闭
    protected void Button_Ccl(object sender, EventArgs e)
    {
        this.TextBox2.Text = "";
        this.TextBox1.Text = "";
        this.Panel1.Visible = false;
        this.UpdatePanel1.Update();
        this.Panel2.Visible = false;
        this.UpdatePanel2.Update();
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
        string condition = Getcondition();
        BindGridview1(condition);

        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= this.Gridview1.PageCount ? this.Gridview1.PageCount - 1 : newPageIndex;
        this.Gridview1.PageIndex = newPageIndex;
        this.Gridview1.DataBind();
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
        string condition = Getconditionn();
        BindGridview2(condition);

        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= this.Gridview2.PageCount ? this.Gridview2.PageCount - 1 : newPageIndex;
        this.Gridview2.PageIndex = newPageIndex;
        this.Gridview2.DataBind();
    }
    protected void Gridview1_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Gridview1.Rows.Count; i++)
        {
            for (int j = 0; j < Gridview1.Rows[i].Cells.Count; j++)
            {
                Gridview1.Rows[i].Cells[j].ToolTip = Gridview1.Rows[i].Cells[j].Text;
                if (Gridview1.Rows[i].Cells[j].Text.Length > 20)
                {
                    Gridview1.Rows[i].Cells[j].Text = Gridview1.Rows[i].Cells[j].Text.Substring(0, 20) + "...";
                }
            }
        }
    }
    protected void Gridview2_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Gridview1.Rows.Count; i++)
        {
            for (int j = 0; j < Gridview1.Rows[i].Cells.Count; j++)
            {
                Gridview1.Rows[i].Cells[j].ToolTip = Gridview1.Rows[i].Cells[j].Text;
                if (Gridview1.Rows[i].Cells[j].Text.Length > 20)
                {
                    Gridview1.Rows[i].Cells[j].Text = Gridview1.Rows[i].Cells[j].Text.Substring(0, 20) + "...";
                }
            }
        }
    }
    protected void Button_ClickDY(object sender, EventArgs e)
    {
        Response.Redirect("../REPORT_cc/TakeInventoryPrint.aspx?" + "&Getcondition()=" + Getconditionn());
    }
}