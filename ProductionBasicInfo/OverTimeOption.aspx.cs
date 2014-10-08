using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLLOverTime;
using EntityOfOverTime;

public partial class ProductionBasicInfo_OverTimeOption : Page
{
    ModuleOfOverTime overTimeInfo = new ModuleOfOverTime();//定义超时原因选项对象
    ProSeriesInfo_ProTypeL ppl = new ProSeriesInfo_ProTypeL();
    ErrorRelevantL erl = new ErrorRelevantL();

    public DataTable GetDs2()
    {

        DataSet ds012 = erl.S_WOError_Rework_PBCraft();
        return ds012.Tables[0];
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!((Session["UserRole"].ToString().Contains("超时原因选项查看")) || (Session["UserRole"].ToString().Contains("超时原因选项维护"))))
            {
                Response.Redirect("~/Default.aspx");

            }
            if (!Session["UserRole"].ToString().Contains("超时原因选项维护"))
            {

                ButtonNew.Visible = false;
                GridViewOverTime.Columns[2].Visible = false;
                GridViewOverTime.Columns[3].Visible = false;
            }
            DataSet set = new DataSet();
            set = OverTimeOption.BindOverTime();
            Session["BindTable"] = set;
            BindData();

            DropDownList1.DataSource = erl.S_WOError_Rework_PBCraft();
            DropDownList1.DataTextField = "PBC_Name";
            DropDownList1.DataValueField = "PBC_ID";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("所有工序", ""));

            DropDownList2.DataSource = erl.S_WOError_Rework_PBCraft();
            DropDownList2.DataTextField = "PBC_Name";
            DropDownList2.DataValueField = "PBC_ID";
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, new ListItem("请选择", ""));
        }
    }
/// <summary>
/// 函数名:BindData
/// 作用：绑定GridViewOverTime的数据
/// 作者:开济
/// </summary>
    private void BindData()
    {
        GridViewOverTime.DataSource = Session["BindTable"];
        GridViewOverTime.DataBind();
    }
    protected void GridViewOverTime_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        { // when click the "GO" Button
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridViewOverTime.BottomPagerRow;


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


        if (Label_Grid1_State.Text == "默认数据源")
        {
            Session["BindTable"] = OverTimeOption.BindOverTime();
            BindData();
            UpdatePanelList.Update();
        }
        if (Label_Grid1_State.Text == "模糊搜索数据源")
        {
            Session["BindTable"] = OverTimeOption.SearchOverTime(TextBoxOverTime.Text.Trim());
            BindData();
            UpdatePanelList.Update();
        } //绑定数据源

        //bindgridview();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridViewOverTime.PageCount ? GridViewOverTime.PageCount - 1 : newPageIndex;

        // specify the NewPageIndex
        GridViewOverTime.PageIndex = newPageIndex;

        GridViewOverTime.PageIndex = newPageIndex;
        GridViewOverTime.DataBind();
    }
    protected void ButtonSearch_Click(object sender, EventArgs e)
    {
        PanelOverTimeNew.Visible = false;
        UpdatePanelOverTimeNew.Update();
        Panel_Parameter.Visible = false;
        UpdatePanel_Parameter.Update();
        Panel_AddPS.Visible = false;
        UpdatePanel_AddPS.Update();
        Label_Grid1_State.Text = "模糊搜索数据源";
        string name = TextBoxOverTime.Text;
        if (name != "")
        {
            Session["BindTable"] = OverTimeOption.SearchOverTime(name);
            BindData();
            UpdatePanelList.Update();
        }
        else
        {
            Label_Grid1_State.Text = "默认数据源";
            Session["BindTable"] = OverTimeOption.BindOverTime();
            BindData();
            UpdatePanelList.Update();
        }
    }
    protected void GridViewOverTime_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridViewOverTime.EditIndex = e.NewEditIndex;
        BindData();
    }
/// <summary>
/// 函数名:GridViewOverTime_RowUpdating
/// 作用：更新GridView相应行的数据并进行文字提示
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
    protected void GridViewOverTime_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        overTimeInfo.OtoID = new Guid(GridViewOverTime.DataKeys[e.RowIndex].Value.ToString());
        overTimeInfo.OtoName = Convert.ToString(((TextBox)(GridViewOverTime.Rows[e.RowIndex].Cells[1].Controls[0])).Text.Trim().ToString());
        if (OverTimeOption.SearchSameOverTime(overTimeInfo.OtoName))
        {
            if (OverTimeOption.UpdateOverTime(overTimeInfo))
            {
                //Message.Text = "数据已成功更新！";
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('数据已成功更新！')", true);
                GridViewOverTime.EditIndex = -1;
                Session["BindTable"] = OverTimeOption.BindOverTime();
                BindData();
            }
            else
            {
                Message.Text = "";
            }
        }
        else
        {
            //Message.Text = "存在同名的超时原因选项！";
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('存在同名的超时原因选项！')", true);
            return;
        }

    }
    protected void GridViewOverTime_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridViewOverTime.EditIndex = -1;
        BindData();
    }
    protected void GridViewOverTime_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName=="DeleteOTO")//删除某行数据
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridViewOverTime.SelectedIndex = row.RowIndex;
            string id = e.CommandArgument.ToString();
            Guid guid_id = new Guid(id);
            if (OverTimeOption.DeleteOverTime(guid_id))
            {
                //Message.Text = "数据已成功删除！";
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('数据已成功删除！')", true);
            }
            else
            {
                Message.Text = "";
            }
            Session["BindTable"] = OverTimeOption.BindOverTime();
            BindData();
        }
        if (e.CommandName == "Check_Detail")//
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridViewOverTime.SelectedIndex = row.RowIndex;
            GridViewOverTime.EditIndex = -1;
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            Label_PTP.Text = al[1];
            Label1.Text = al[0];
            Panel_Parameter.Visible = true;
            databind_detail();
            GridView_Parameter.SelectedIndex = -1;
            GridView_Parameter.EditIndex = -1;
            GridView_Parameter.PageIndex = 0;
            PanelOverTimeNew.Visible = false;
            UpdatePanelOverTimeNew.Update();

            UpdatePanel_Parameter.Update();
            Panel_AddPS.Visible = false;
            UpdatePanel_AddPS.Update();
        }
    }
    protected void ButtonNew_Click(object sender, EventArgs e)
    {
        PanelOverTimeNew.Visible = true;//Panel可见
        UpdatePanelOverTimeNew.Update();
        Panel_Parameter.Visible = false;
        UpdatePanel_Parameter.Update();
        Panel_AddPS.Visible = false;
        UpdatePanel_AddPS.Update();
        GridViewOverTime.EditIndex = -1;
        Session["BindTable"] = OverTimeOption.BindOverTime();
        BindData();
        UpdatePanelList.Update();
    }
    protected void ButtonClose_Click(object sender, EventArgs e)
    {
        PanelOverTimeNew.Visible = false;//Panel不可见
        UpdatePanelOverTimeNew.Update();
    }
    protected void ButtonSubmit_Click(object sender, EventArgs e)
    {
        string OtoName = TextBoxNew.Text;
        //if (OtoName == "")
        //{
        //    Message.Text = "请输入要添加的超时原因！";
        //    UpdatePanelList.Update();
        //}
        if (TextBoxNew.Text.ToString() == "" )
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        else if (OverTimeOption.SearchSameOverTime(OtoName))
        {
            if (OverTimeOption.AddOverTime(OtoName))
            {
                //Message.Text = "数据已成功添加！";
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('数据已成功添加！')", true);
                TextBoxNew.Text="";
                PanelOverTimeNew.Visible = false;//Panel不可见
            }
            else
            {
                //Message.Text = "数据未成功添加！";
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('数据未成功添加！')", true);
                return;
            }
            Session["BindTable"] = OverTimeOption.BindOverTime();
            BindData();
        }
        else
        {
            //Message.Text = "超时原因重复！";
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('超时原因重复！')", true);
            return;
        }
        UpdatePanelList.Update();
    }
    protected void ButtonCancel_Click(object sender, EventArgs e)
    {
        TextBoxNew.Text = "";
    }
    protected void ButtonReset_Click(object sender, EventArgs e)
    {
        TextBoxOverTime.Text = "";
        PanelOverTimeNew.Visible = false;
        UpdatePanelOverTimeNew.Update();
        Panel_Parameter.Visible = false;
        UpdatePanel_Parameter.Update();
        Panel_AddPS.Visible = false;
        UpdatePanel_AddPS.Update();
        GridViewOverTime.EditIndex = -1;
        Session["BindTable"] = OverTimeOption.BindOverTime();
        BindData();
        UpdatePanelList.Update();
    }


    public void databind_detail()
    {
        string condition;
        condition = DropDownList1.SelectedItem.Text.Trim() == "所有工序" ? " and 1=1 " : " and PBC_Name like '%" + DropDownList1.SelectedItem.Text.Trim() + "%'";
        GridView_Parameter.DataSource = OverTimeOption.S_OverTimeOptionDetail(Label1.Text.Trim(), condition);
        GridView_Parameter.DataBind();
        UpdatePanel_Parameter.Update();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        databind_detail();
    }

    protected void Btn_Close_Parameter0_Click(object sender, EventArgs e)
    {
        Panel_AddPS.Visible = true;
        txt_PS.Text = "";
        GridView_Parameter.SelectedIndex = -1;
        GridView_Parameter.EditIndex = -1;
        DropDownList2.SelectedIndex = 0;
        UpdatePanel_AddPS.Update();
        databind_detail();
    }
    protected void Btn_Close_Parameter_Click(object sender, EventArgs e)
    {
        GridViewOverTime.SelectedIndex = -1;
        Panel_Parameter.Visible = false;
        UpdatePanel_Parameter.Update();
        Panel_AddPS.Visible = false;
        UpdatePanel_AddPS.Update();
        UpdatePanelList.Update();
    }

    protected void GridView_Parameter_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "delete1")//
        {
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            try
            {
                OverTimeOption.D_OverTimeOptionDetail(new Guid(al[0].Trim()));
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除成功！')", true);
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除失败！')", true);
            }

            databind_detail();
            GridView_Parameter.SelectedIndex = -1;
            GridView_Parameter.EditIndex = -1;
            //   GridView_Parameter.PageIndex = 0;
            Panel_Parameter.Visible = true;
            UpdatePanel_Parameter.Update();
            Panel_AddPS.Visible = false;
            UpdatePanel_AddPS.Update();
        }

    }
    protected void GridView_Parameter_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;
        GridView_Parameter.SelectedIndex = -1;
        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;

            GridViewRow pagerRow = GridView_Parameter.BottomPagerRow;


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
        newPageIndex = newPageIndex >= GridView_Parameter.PageCount ? GridView_Parameter.PageCount - 1 : newPageIndex;
        GridView_Parameter.PageIndex = newPageIndex;
        databind_detail();

        Panel_AddPS.Visible = false;
        UpdatePanel_AddPS.Update();
    }
    protected void GridView_Parameter_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView_Parameter.Rows.Count; i++)
        {
            for (int j = 0; j < GridView_Parameter.Rows[i].Cells.Count; j++)
            {
                GridView_Parameter.Rows[i].Cells[j].ToolTip = GridView_Parameter.Rows[i].Cells[j].Text;
                if (GridView_Parameter.Rows[i].Cells[j].Text.Length > 20)
                {
                    GridView_Parameter.Rows[i].Cells[j].Text = GridView_Parameter.Rows[i].Cells[j].Text.Substring(0, 20) + "...";
                }


            }
        }
    }
    protected void GridView_Parameter_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView_Parameter.EditIndex = e.NewEditIndex;
        string value1 = ((Label)GridView_Parameter.Rows[e.NewEditIndex].FindControl("lbl1")).Text;
        Label17.Text = GridView_Parameter.Rows[e.NewEditIndex].Cells[1].Text.Trim();
        Label2.Text = value1;
        databind_detail();
        ((DropDownList)GridView_Parameter.Rows[e.NewEditIndex].FindControl("ddl1")).SelectedIndex = ((DropDownList)GridView_Parameter.Rows[e.NewEditIndex].FindControl("ddl1")).Items.IndexOf(((DropDownList)GridView_Parameter.Rows[e.NewEditIndex].FindControl("ddl1")).Items.FindByText(value1)); ;

        Panel_AddPS.Visible = false;
        UpdatePanel_AddPS.Update();
    }
    protected void GridView_Parameter_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //获取要被更新的行的数据
        try
        {
            string name = Convert.ToString(((TextBox)(GridView_Parameter.Rows[e.RowIndex].Cells[1].Controls[0])).Text.Trim().ToString());
            string PBC_Name = ((DropDownList)GridView_Parameter.Rows[e.RowIndex].FindControl("ddl1")).SelectedItem.ToString().Trim();

            if (Label17.Text.Trim() != name || PBC_Name != Label2.Text.Trim())
            {
                string condition = " and PBC_Name = '" + ((DropDownList)GridView_Parameter.Rows[e.RowIndex].FindControl("ddl1")).SelectedItem.Text.Trim() + "'";
                DataSet ds = OverTimeOption.S_OverTimeOptionDetail(Label1.Text.Trim(), condition);
                DataRow[] rows = ds.Tables[0].Select(" OTOD_Name='" + name + "'");
                if (rows.Length > 0)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('" + PBC_Name + " 工序下已存在名为 " + name + " 的详细项目名称！请重新填写')", true);
                    return;
                }

                Guid guid = new Guid(GridView_Parameter.DataKeys[e.RowIndex].Value.ToString());
                Guid PBC_ID = new Guid(((DropDownList)GridView_Parameter.Rows[e.RowIndex].FindControl("ddl1")).SelectedValue.ToString().Trim());
                OverTimeOption.U_OverTimeOptionDetail(guid, name, PBC_ID);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('编辑成功！')", true);

            }


        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('编辑失败！')", true);
        }
        GridView_Parameter.EditIndex = -1;
        databind_detail();

    }
    protected void GridView_Parameter_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView_Parameter.EditIndex = -1;
        databind_detail();
    }
    protected void Btn_Submit_Click(object sender, EventArgs e)
    {
        if (txt_PS.Text.ToString() == "" || DropDownList2.SelectedIndex == 0)
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        string condition = " and a.PBC_ID = '" + DropDownList2.SelectedValue.ToString().Trim() + "'";

        DataSet ds = OverTimeOption.S_OverTimeOptionDetail(Label1.Text.Trim(), condition);
        DataRow[] rows = ds.Tables[0].Select(" OTOD_Name='" + txt_PS.Text + "'");
        if (rows.Length > 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('" + DropDownList2.SelectedItem.Text.Trim() + " 工序下已存在名为 " + txt_PS.Text.Trim() + " 的详细项目名称！请重新填写')", true);
            return;
        }
        try
        {
            OverTimeOption.I_OverTimeOptionDetail(new Guid(Label1.Text.Trim()), txt_PS.Text.Trim(), new Guid(DropDownList2.SelectedValue.ToString().Trim()));
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('新增成功！')", true);
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('新增失败！')", true);
            return;
        }
        Panel_AddPS.Visible = false;
        UpdatePanel_AddPS.Update();
        databind_detail();
    }
    protected void Btn_Cancel_Click(object sender, EventArgs e)
    {
        txt_PS.Text = "";
        DropDownList2.SelectedIndex = 0;
    }
    protected void Button_Close_PSSearch_Click(object sender, EventArgs e)
    {
        Panel_AddPS.Visible = false;
        UpdatePanel_AddPS.Update();
    }
}