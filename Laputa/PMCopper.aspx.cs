using System;
using System.Diagnostics;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Laputa_PMCopper : Page
{
    private PMCopperD pmc = new PMCopperD();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Panel4.Visible = false;
            Panel3.Visible = false;
            Panel5.Visible = false;
            Panel6.Visible = false;
            Panel7.Visible = false;
            Panel8.Visible = false;
            Panel9.Visible = false;
            Panel10.Visible = false;
            GridView1.DataSource = pmc.Query_Copper();
            GridView1.DataBind();
            UpdatePanel2.Update();
            UpdatePanel3.Update();
            UpdatePanel4.Update();
            UpdatePanel5.Update();
            UpdatePanel6.Update();
            UpdatePanel7.Update(); 
            UpdatePanel8.Update();
            UpdatePanel9.Update();
            UpdatePanel10.Update();
        }
    }
    protected void Button3_New(object sender, EventArgs e)
    {
        Label4.Text = "新增";
        LabelUsage.Visible = false;
        TextBox47.Visible = false;
        Panel3.Visible = true;
        UpdatePanel3.Update();
    }
    protected void MainSearch_Click(object sender, EventArgs e)
    {
        DateTime sTime = TextBox_Time1.Text == ""
            ? Convert.ToDateTime("1/1/1753 12:00:00 AM")
            : Convert.ToDateTime(TextBox_Time1.Text);
        DateTime eTime = TextBox_Time2.Text == ""
           ? Convert.ToDateTime("12/31/9999 11:59:59 PM")
           : Convert.ToDateTime(TextBox_Time2.Text);
            GridView1.DataSource = pmc.Query_Copper(TextBox2.Text, TextBox1.Text, TextBox_Factory.Text, sTime,
                eTime);
        GridView1.DataBind();
        UpdatePanel2.Update();
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
        if (e.CommandName == "Return")
        {
            Panel5.Visible = true;
            CopperID.Text = e.CommandArgument.ToString();
            GridView3.DataSource = pmc.Query_CopperReturn(new Guid(CopperID.Text));
            GridView3.DataBind();

            Debug.Assert(row != null, "Oh My LadyGaga!");
            Label16.Text = row.Cells[2].Text;
            
            Label20.Text = row.Cells[10].Text;
            
            UpdatePanel5.Update();
        }
        if (e.CommandName == "NG")
        {
            Panel7.Visible = true;
         
            CopperID.Text = e.CommandArgument.ToString();
            GridView4.DataSource = pmc.Query_CopperNG(new Guid(CopperID.Text));
            GridView4.DataBind();
            Label15.Text = row.Cells[2].Text;
            Label17.Text = row.Cells[10].Text;
            UpdatePanel7.Update();
        }
        if (e.CommandName == "Modi")
        {
            CopperID.Text = e.CommandArgument.ToString();

            Label4.Text = "修改";
            LabelUsage.Visible = true;
            TextBox47.Visible = true;
            TextBox47.Text = row.Cells[12].Text;
            Panel3.Visible = true;
            UpdatePanel3.Update();
            Type.Text = row.Cells[3].Text;
            Mid.Text = row.Cells[11].Text;
            TextBox3.Text = row.Cells[5].Text;
            TextBox6.Text= row.Cells[4].Text;
            TextBox46.Text = row.Cells[9].Text;
            ProviderName.Text = row.Cells[2].Text;
            ProviderID.Text = row.Cells[10].Text;
            CopperRate.Text = row.Cells[12].Text;
        }
        if (e.CommandName == "OEM")
        {
            Panel10.Visible = true;

            CopperID.Text = e.CommandArgument.ToString();
            GridView6.DataSource = pmc.Query_CopperOEM(new Guid(CopperID.Text));
            GridView6.DataBind();
            UpdatePanel10.Update();
        }
    }
    
    protected void ProviderSearch(object sender, EventArgs e)
    {
        Panel4.Visible = true;
        TextBox41.Text = "";
        TextBox42.Text = "";

        GridView2.DataSource = pmc.Query_Provider(TextBox41.Text, TextBox42.Text);
        GridView2.DataBind();
        UpdatePanel4.Update();

    }
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Choose")
        {
             GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            
            ProviderID.Text = e.CommandArgument.ToString();
            Debug.Assert(row != null, "这是个意外!");
            ProviderName.Text = row.Cells[2].Text;
            Label16.Text = row.Cells[2].Text;
            Label15.Text = row.Cells[2].Text;
            Label20.Text = e.CommandArgument.ToString();
            Label17.Text = e.CommandArgument.ToString();
            Panel4.Visible = false;
            UpdatePanel4.Update();
            UpdatePanel3.Update();



        }
    }
    protected void SearchProvider_Click(object sender, EventArgs e)
    {
     
        GridView2.DataSource = pmc.Query_Provider(TextBox41.Text, TextBox42.Text);
        GridView2.DataBind();
        UpdatePanel4.Update();
    }
    protected void Reset(object sender, EventArgs e)
    {
        foreach (Control ct in Panel1.Controls)
        {
            if (ct.GetType().ToString().Equals("System.Web.UI.WebControls.TextBox"))
            {
                TextBox cb = (TextBox)ct;
                cb.Text = "";



            }
        } 

    }
    protected void Button_Cancel(object sender, EventArgs e)
    {
        Panel3.Visible = false;
        Panel4.Visible = false;
        UpdatePanel3.Update();
        UpdatePanel4.Update();
    }

    protected void Bind1()
    {
        DateTime sTime = TextBox_Time1.Text == ""
           ? Convert.ToDateTime("1/1/1753 12:00:00 AM")
           : Convert.ToDateTime(TextBox_Time1);
        DateTime eTime = TextBox_Time1.Text == ""
           ? Convert.ToDateTime("12/31/9999 11:59:59 PM")
           : Convert.ToDateTime(TextBox_Time1);
        GridView1.DataSource = pmc.Query_Copper(TextBox2.Text, TextBox1.Text, TextBox_Factory.Text, sTime,
            eTime);
        GridView1.DataBind();
        UpdatePanel2.Update();
    }
    protected void Bind(int a)
    {
        switch (a)
        {
            case 3:
                GridView3.DataSource = pmc.Query_CopperReturn(new Guid(CopperID.Text));
                   GridView3.DataBind();
                UpdatePanel5.Update();
                break;
            case 4:
                 GridView4.DataSource = pmc.Query_CopperNG(new Guid(CopperID.Text));
                   GridView4.DataBind();
                UpdatePanel7.Update();
                break;
        }
       
    }

    protected void CloseProviderSearch_Click(object sender, EventArgs e)
    {
        Panel4.Visible = false;
        UpdatePanel4.Update();
    }

    protected void SummitOri_Click(object sender, EventArgs e)
    {
        if (CopperRate.Text == "CopperRate" || Type.Text == "请选择规格" || TextBox3.Text == "" || TextBox46.Text == "" ||
            TextBox6.Text == "" || ProviderName.Text == "请选择供应商")
        {
            ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
        }
        else if (Label4.Text=="新增")
        {
            int a = pmc.Insert_PMCopper(new Guid(Mid.Text), Convert.ToDecimal((TextBox3.Text)), new Guid(ProviderID.Text), TextBox6.Text,
                Convert.ToDateTime(TextBox46.Text), Convert.ToDecimal(CopperRate.Text));
            if (a > 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('提交成功！')", true);
                Panel3.Visible = false;
                UpdatePanel3.Update();
                Bind1();

            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('提交失败！')", true);
                Panel3.Visible = false;
                UpdatePanel3.Update();
            }
        }
        else if (Label4.Text == "修改")
        {
            try
            {
                int a = pmc.Update_PMCopper(new Guid(CopperID.Text), new Guid(Mid.Text), decimal.Parse(TextBox3.Text),
                    new Guid(ProviderID.Text), TextBox6.Text,
                    Convert.ToDateTime(TextBox46.Text), Convert.ToDecimal(TextBox47.Text));
                if (a > 0)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('提交成功！')", true);
                    Panel3.Visible = false;
                    UpdatePanel3.Update();
                    Bind1();

                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('提交失败！')", true);
                    Panel3.Visible = false;
                    UpdatePanel3.Update();
                }
            }
            catch
            {

                ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('数据填写有误！')", true);
            }
            
        }

    }

    protected void SummitReturn_Click(object sender, EventArgs e)
    {
        if (TextBox9.Text == "" || Label16.Text == "请选择供应商"||TextBox44.Text=="")
        {
            ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('数量、日期未填写或退货去向未选择！')", true);
        }
        else
        {
            decimal renum = Decimal.Parse(TextBox9.Text);
            Guid copperid = new Guid(CopperID.Text);
            Guid pid = new Guid(Label20.Text);
            Debug.Assert(TextBox44.Text != null, "时间没填哦~亲");
            DateTime backDateTime = Convert.ToDateTime(TextBox44.Text);
            string note = TextBox43.Text;
            int a = pmc.Insert_CopperReturn(renum, copperid,pid, note,Session["UserName"].ToString(),backDateTime);
            if (a>0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('提交成功！')", true);
                Panel6.Visible = false;
                UpdatePanel6.Update();
                Bind1();
                Bind(3);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('提交失败！')", true);
                Panel6.Visible = false;
                UpdatePanel6.Update();
            }
            
        }

    }
    protected void NewReturn_Click(object sender, EventArgs e)
    {
        Panel6.Visible = true;
        UpdatePanel6.Update();
    }
    protected void SummitReturnNG_Click(object sender, EventArgs e)
    {
        if (TextBox8.Text == "" || Label15.Text == "请选择供应商" || TextBox45.Text=="")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('数量未填写或退货去向未选择！')", true);
        }
        else
        {
            decimal renum = Decimal.Parse(TextBox8.Text);
            Guid copperid = new Guid(CopperID.Text);
            Guid pid = new Guid(Label17.Text);
            string note = TextBox10.Text;
            DateTime backDateTime = Convert.ToDateTime(TextBox45.Text);
            int a = pmc.Insert_CopperNG(renum, copperid, pid, note, Session["UserName"].ToString(),backDateTime);
            if (a > 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('提交成功！')", true);
                Panel8.Visible = false;
                UpdatePanel8.Update();
                Bind1();
                Bind(4);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('提交失败！')", true);
                Panel8.Visible = false;
                UpdatePanel8.Update();
            }

        }
    }
    protected void NewCopperNG_Click(object sender, EventArgs e)
    {
          Panel8.Visible = true;
        UpdatePanel8.Update();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType==DataControlRowType.DataRow)
        {


            if (e.Row.Cells[2].Text.Length > 8)
            {
                e.Row.Cells[2].ToolTip = e.Row.Cells[2].Text;
                e.Row.Cells[2].Text = e.Row.Cells[2].Text.Substring(0, 8);
            }
        }
    }
    protected void SearhType_Click(object sender, EventArgs e)
    {
        GridView5.DataSource = pmc.Query_Type(TextBox5.Text);
    }
    
    protected void Materialpiker_Click(object sender, EventArgs e)
    {
        Panel9.Visible = true;
        UpdatePanel9.Update();
        GridView5.DataSource = pmc.Query_Type("");
        GridView5.DataBind();
    }
    protected void GridView5_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void GridView5_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Choose")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;

            Mid.Text = e.CommandArgument.ToString();
            Debug.Assert(row != null, "这是个意外!");
            Type.Text = row.Cells[1].Text;
            CopperRate.Text = row.Cells[3].Text;
            Panel9.Visible = false;
            UpdatePanel9.Update();
            UpdatePanel3.Update();



        }
    }
    protected void CloseReturn_Click(object sender, EventArgs e)
    {
        Panel5.Visible = false;
        UpdatePanel5.Update();
        Panel6.Visible = false;
        UpdatePanel6.Update();
    }
    protected void CloseReturnNG_Click(object sender, EventArgs e)
    {
        Panel7.Visible = false;
        Panel8.Visible = false;
        UpdatePanel7.Update();
        UpdatePanel8.Update();
    }
    protected void CloseType_Click(object sender, EventArgs e)
    {
        Panel9.Visible = false;
        UpdatePanel9.Update();
    }
    protected void CloseOEM_Click(object sender, EventArgs e)
    {
        Panel10.Visible = false;
        UpdatePanel10.Update();
    }
}