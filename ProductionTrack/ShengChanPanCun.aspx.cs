using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ProductionTrack_ShengChanPanCun : Page
{
    OEMTrackL ot = new OEMTrackL();
    ErrorRelevantL erl = new ErrorRelevantL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            string condition = " and 1=1";
            GridView_WOmain.DataSource = ot.S_PMMInventory(condition);
            GridView_WOmain.DataBind();
            UpdatePanel_WOmain.Update();
            DropDownList1.DataSource = erl.S_WOError_Rework_PBCraft();
            DropDownList1.DataTextField = "PBC_Name";
            DropDownList1.DataValueField = "PBC_ID";
            DropDownList1.DataBind();

        }
    }

    public void databind()
    {
        string condition;
        string PMMI_RState = DropDownList_TimeState.SelectedItem.Text.Trim() == "请选择" ? " and 1=1 " : " and PMMI_RState = '" + DropDownList_TimeState.SelectedItem.Text.Trim() + "' ";
        string PMMI_FCState = DropDownList_PieceState.SelectedItem.Text.Trim() == "请选择" ? " and 1=1 " : " and PMMI_FCState = '" + DropDownList_PieceState.SelectedItem.Text.Trim() + "' ";
        string PBC_Name = TextBox1.Text.Trim() == "" ? " and 1=1 " : " and PBC_Name = '" + TextBox1.Text.Trim() + "' ";

        if ((TextBox_calculate_Time1.Text != "" && TextBox_calculate_Time2.Text == "") || (TextBox_calculate_Time1.Text == "" && TextBox_calculate_Time2.Text != ""))
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请将时间检索范围输入完整，请您再次核对！')", true);
            return;
        }
        string PMMI_Date = (TextBox_calculate_Time1.Text.Trim() == "" && TextBox_calculate_Time2.Text.Trim() == "") ? " and 1=1 " : " and PMMI_Date between   ' " + TextBox_calculate_Time1.Text.Trim() + "' and ' " + TextBox_calculate_Time2.Text.Trim() + "'";



        condition = PMMI_RState + PMMI_FCState + PMMI_Date + PBC_Name;
        GridView_WOmain.DataSource = ot.S_PMMInventory(condition);
        GridView_WOmain.DataBind();
        UpdatePanel_WOmain.Update();

    }
    protected void Btn_Search_Click(object sender, EventArgs e)
    {
        databind();
    }
    protected void Button_Add_Click(object sender, EventArgs e)
    {
        Panel_Add.Visible = true;
        TextBox_calculate_Time_Add.Text = "";

        DropDownList1.SelectedIndex = 0;
        UpdatePanel_Add.Update();

    }
    protected void Button_Cancel_Click(object sender, EventArgs e)
    {
        DropDownList_TimeState.SelectedIndex = 0;
        DropDownList_PieceState.SelectedIndex = 0;
        TextBox1.Text = "";
        TextBox_calculate_Time1.Text = "";
        TextBox_calculate_Time2.Text = "";
        databind();
        Panel_Add.Visible = false;
        UpdatePanel_Add.Update();
    }
    protected void Button_Add_Submit_Click(object sender, EventArgs e)
    {
        if (TextBox_calculate_Time_Add.Text.Trim() == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请输入盘存日期！')", true);
            return;
        }
        try
        {

            DateTime t = Convert.ToDateTime(TextBox_calculate_Time_Add.Text.Trim());
        }
        catch
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请保证盘存日期为时间格式！')", true);
            return;
        }
        string condition = " and PBC_Name='" + DropDownList1.SelectedItem.Text.Trim() + "'" + " and PMMI_Date='" + TextBox_calculate_Time_Add.Text.Trim() + "'";
        DataSet ds = ot.S_PMMInventory(condition);
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count != 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('系统中已有该日期该工序的盘存信息，请您再次核对！')", true);
            return;
        }

      try
      {
            ot.I_PMMInventory(new Guid(DropDownList1.SelectedValue.ToString().Trim()), Convert.ToDateTime(TextBox_calculate_Time_Add.Text.Trim()), Session["UserName"].ToString().Trim());
            databind();
            DropDownList1.SelectedIndex = 0;
            TextBox_calculate_Time_Add.Text = "";
            Panel_Add.Visible = false;
            UpdatePanel_Add.Update();
      }

        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('新增失败！')", true);
            return;
        }
    }
    protected void Button_Add_Cancel_Click(object sender, EventArgs e)
    {
        DropDownList1.SelectedIndex = 0;
        TextBox_calculate_Time_Add.Text = "";
        Panel_Add.Visible = false;
        UpdatePanel_Add.Update();


    }
    protected void GridView_WOmain_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;
        GridView_WOmain.SelectedIndex = -1;
        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;

            GridViewRow pagerRow = GridView_WOmain.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox");
            }

            if (null != txtNewPageIndex && txtNewPageIndex.Text != "")
            {
                newPageIndex = int.Parse(txtNewPageIndex.Text) - 1;
            }
        }
        else
        {
            newPageIndex = e.NewPageIndex;
        }
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView_WOmain.PageCount ? GridView_WOmain.PageCount - 1 : newPageIndex;
        GridView_WOmain.PageIndex = newPageIndex;
        GridView_WOmain.PageIndex = newPageIndex;
        databind();
        //pannel 各种隐藏
        DropDownList1.SelectedIndex = 0;
        TextBox_calculate_Time_Add.Text = "";
        Panel_Add.Visible = false;
        UpdatePanel_Add.Update();
    }
    protected void GridView_WOmain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete1")//
        {
            //GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            //GridView_WOmain.SelectedIndex = row.RowIndex;
            try
            {
                string PMMI_ID = e.CommandArgument.ToString().Trim();
                ot.D_PMMInventory(new Guid(PMMI_ID));

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除成功！')", true);
           
                //panel 各种隐藏
                DropDownList1.SelectedIndex = 0;
                TextBox_calculate_Time_Add.Text = "";
                Panel_Add.Visible = false;
                UpdatePanel_Add.Update();
                databind();
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除失败！')", true);
                return;
            }
        }
    }
}