using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SalesMgt_ProTypePrice : Page
{
    ProTypePrice ptp = new ProTypePrice();
    protected void Page_Load(object sender, EventArgs e)
    {
        Title = "产品底价录入";
        if (!IsPostBack)
        {
            Label_Grid1_Color.Text = "";
            BindPrice();
        }
        try
        {
            if (!(Session["UserRole"].ToString().Contains("产品底价录入")))
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
       
            //if (Request.QueryString["state"] == null)
            //{
            //    this.label_pagestate.Text = "look";
            //}
            //else
            //{
            //    this.label_pagestate.Text = Request.QueryString["state"];
            //}

            //string state = this.label_pagestate.Text;
            //if (state == "look")
            //{
            //    this.Title = "产品型号查看";
            //    this.GridView2.Columns[14].Visible = false;
            //    this.GridView2.Columns[15].Visible = false;

            //    this.Button_Add.Visible = false;
            //    Txt_parameter.Enabled = false;
            //    Txt_PassRate.Enabled = false;
            //    TextBox_Note.Enabled = false;
              
            //    this.Btn_I_parameter.Visible = false;
            //    this.Btn_U_parameter.Visible = false;

            //}
           



            //    try
            //    {
            //        if (!((Session["UserRole"].ToString().Contains("产品型号查看")) || (Session["UserRole"].ToString().Contains("产品型号维护"))))
            //        {
            //            Response.Redirect("~/Default.aspx");

            //        }
            //        if (!Session["UserRole"].ToString().Contains("产品型号维护"))
            //        {

                       
            //            this.Title = "产品型号查看";
            //            this.GridView2.Columns[12].Visible = false;
            //            this.GridView2.Columns[13].Visible = false;

            //            this.Button_Add.Visible = false;
            //            Txt_parameter.Enabled = false;
            //            Txt_PassRate.Enabled = false;
            //            TextBox_Note.Enabled = false;

            //            this.Btn_I_parameter.Visible = false;
            //            this.Btn_U_parameter.Visible = false;

            //        }

            //        GridView2.DataSource = ppl.S_ProType_new("");
            //        GridView2.DataBind();

            //        DropDownList01.DataSource = ppl.S_PTCB_Detail("", "1");
            //        DropDownList01.DataTextField = "PTCB_Detail";
            //        DropDownList01.DataValueField = "PTCB_Code";
            //        DropDownList01.DataBind();              
            //        DropDownList01.Items.Insert(0, new ListItem(" ", " "));

            //        DropDownList01.ToolTip = DropDownList01.SelectedValue.ToString();
            //        DropDownList02.DataSource = ppl.S_PTCB_Detail("", "2");
            //        DropDownList02.DataTextField = "PTCB_Detail";
            //        DropDownList02.DataValueField = "PTCB_Code";
            //        DropDownList02.DataBind();
            //        DropDownList02.Items.Insert(0, new ListItem("  ", "  "));
            //        DropDownList02.ToolTip = DropDownList02.SelectedValue.ToString();

            //        DropDownList03.DataSource = ppl.S_PTCB_Detail("", "3");
            //        DropDownList03.DataTextField = "PTCB_Detail";
            //        DropDownList03.DataValueField = "PTCB_Code";
            //        DropDownList03.DataBind();                
            //        DropDownList03.Items.Insert(0, new ListItem("  ", "  "));
            //        DropDownList03.ToolTip = DropDownList03.SelectedValue.ToString();

            //        DropDownList04.DataSource = ppl.S_PTCB_Detail("", "4");
            //        DropDownList04.DataTextField = "PTCB_Detail";
            //        DropDownList04.DataValueField = "PTCB_Code";
            //        DropDownList04.DataBind();
            //        DropDownList04.Items.Insert(0, new ListItem("  ", "  "));
            //        DropDownList04.ToolTip = DropDownList04.SelectedValue.ToString();

            //        DropDownList05.DataSource = ppl.S_PTCB_Detail("", "5");
            //        DropDownList05.DataTextField = "PTCB_Detail";
            //        DropDownList05.DataValueField = "PTCB_Code";
            //        DropDownList05.DataBind();
            //        DropDownList05.Items.Insert(0, new ListItem(" ", " "));
            //        DropDownList05.ToolTip = DropDownList05.SelectedValue.ToString();

            //        DropDownList06.DataSource = ppl.S_PTCB_Detail("", "6");
            //        DropDownList06.DataTextField = "PTCB_Detail";
            //        DropDownList06.DataValueField = "PTCB_Code";
            //        DropDownList06.DataBind();
            //        DropDownList06.Items.Insert(0, new ListItem("  ", "  "));
            //        DropDownList06.ToolTip = DropDownList06.SelectedValue.ToString();

            //        DropDownList07.DataSource = ppl.S_PTCB_Detail("", "7");
            //        DropDownList07.DataTextField = "PTCB_Detail";
            //        DropDownList07.DataValueField = "PTCB_Code";
            //        DropDownList07.DataBind();
            //        DropDownList07.Items.Insert(0, new ListItem(" ", " "));
            //        DropDownList07.ToolTip = DropDownList07.SelectedValue.ToString();

            //        DropDownList08.DataSource = ppl.S_PTCB_Detail("", "8");
            //        DropDownList08.DataTextField = "PTCB_Detail";
            //        DropDownList08.DataValueField = "PTCB_Code";
            //        DropDownList08.DataBind();
            //        DropDownList08.Items.Insert(0, new ListItem(" ", " "));
            //        DropDownList08.ToolTip = DropDownList08.SelectedValue.ToString();

            //        DropDownList09.DataSource = ppl.S_PTCB_Detail("", "9");
            //        DropDownList09.DataTextField = "PTCB_Detail";
            //        DropDownList09.DataValueField = "PTCB_Code";
            //        DropDownList09.DataBind();
            //        DropDownList09.Items.Insert(0, new ListItem(" ", " "));
            //        DropDownList09.ToolTip = DropDownList09.SelectedValue.ToString();

            //        DropDownList10.DataSource = ppl.S_PTCB_Detail("", "10");
            //        DropDownList10.DataTextField = "PTCB_Detail";
            //        DropDownList10.DataValueField = "PTCB_Code";
            //        DropDownList10.DataBind();
            //        DropDownList10.Items.Insert(0, new ListItem(" ", " "));
            //        DropDownList10.ToolTip = DropDownList10.SelectedValue.ToString();

            //        DropDownList11.DataSource = ppl.S_PTCB_Detail("", "11");
            //        DropDownList11.DataTextField = "PTCB_Detail";
            //        DropDownList11.DataValueField = "PTCB_Code";
            //        DropDownList11.DataBind();
            //        DropDownList11.Items.Insert(0, new ListItem("  ", "  "));
            //        DropDownList11.ToolTip = DropDownList11.SelectedValue.ToString();
            //    }
            //    catch (Exception)
            //    {
            //        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('可能您没有权限操作和查看本页面，请退出选择其他账号登陆，或联系管理员！')", true);
            //        Response.Redirect("~/Default.aspx");

            //    }

    protected void BindPrice()
    {
        GridView2.DataSource = ptp.Select_PTPrice(Label_Grid1_Color.Text.ToString());
        GridView2.DataBind();
        UpdatePanel_PT.Update();
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
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView2.PageCount ? GridView2.PageCount - 1 : newPageIndex;
        // specify the NewPageIndex
        GridView2.PageIndex = newPageIndex;
        BindPrice();

        GridView2.SelectedIndex = -1;

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
        if (e.CommandName == "Edit123")
        {

            Panel_CheckParameter.Visible = true;
            //this.Label2.Text=
            Label2.Text = e.CommandArgument.ToString();
            Labelc.Text = GridView2.Rows[row.RowIndex].Cells[2].Text.ToString();
            Label1.Text = GridView2.Rows[row.RowIndex].Cells[2].Text.ToString();
            UpdatePanel_CheckParameter.Update();
        }
        if (e.CommandName == "LookH")
        {

            Panel_basic.Visible = true;
            UpdatePanel_basic.Update();
            Label_WOID.Text = GridView2.Rows[row.RowIndex].Cells[1].Text.ToString();
            GridView_bom.DataSource = ptp.Select_PTPriceH(new Guid(e.CommandArgument.ToString()));
            GridView_bom.DataBind();
            UpdatePanel_PT.Update();
        }
    }
    protected void Button_Cancel_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        Txt_search.Text = "";
        Txt_search0.Text = "";
        UpdatePanel_Search.Update();
    }

    protected void Btn_Search_Click(object sender, EventArgs e)
    {
        Condition();
        BindPrice();
    }
    protected void Condition()
    {
        string temp = "";
        if (Txt_search.Text != "")
        {
            temp = " and PT_Name like'%" + Txt_search.Text.ToString() + "%'";
        }
        if (TextBox1.Text != "")
        {
            temp = " and PT_Code like'%" + TextBox1.Text.ToString() + "%'";
        }
        if (Txt_search0.Text != "")
        {
            temp = " and PT_Note like'%" + Txt_search0.Text.ToString() + "%'";
        }
        Label_Grid1_Color.Text = temp;
    }
    protected void Btn_I_parameter_Click(object sender, EventArgs e)
    {
        if (Txt_parameter.Text=="")
        {
          ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('你还没有填写修改后单价！')", true);
            return;
        }
        Guid id = new Guid(Label2.Text.ToString());
        string man = Session["UserName"].ToString().Trim();
        decimal num = Convert.ToDecimal(Txt_parameter.Text.ToString());
        ptp.Insert_change(id, man, num);
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('提交成功！')", true);
        Panel_CheckParameter.Visible = false;
        Txt_parameter.Text = "";
        UpdatePanel_CheckParameter.Update();
        BindPrice();
        Panel_basic.Visible = false;
        UpdatePanel_basic.Update();
        
    }
    protected void Button_Close_CheckParameter_Click(object sender, EventArgs e)
    {
        Txt_parameter.Text = "";
        Panel_CheckParameter.Visible = false;
        UpdatePanel_CheckParameter.Update();
    }
}