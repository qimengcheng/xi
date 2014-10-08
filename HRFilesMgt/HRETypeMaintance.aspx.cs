using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HRFilesMgt_HRETypeMaintance : Page
{
    HRETypeL hRETypeL = new HRETypeL();
    HRETypeInfo hRETypeInfo = new HRETypeInfo();
    private static string str = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!((Session["UserRole"].ToString().Contains("员工类型维护")) || (Session["UserRole"].ToString().Contains("员工类型查看"))))
        {
            Response.Redirect("~/Default.aspx");
        }

        if (Request.QueryString["status"] == "typeLook")
        {
            Grid_Type.Columns[2].Visible = false;
            Grid_Type.Columns[3].Visible = false;
            BtnNew.Visible = false;
            Title = "员工类型查看";
        }
        if (Request.QueryString["status"] == "typeMain")
        {
            Title = "员工类型维护";
        }
        if (!IsPostBack)
        {

            BindGrid("");

        }
    }

    private void BindGrid(string HRET_EmpType)
    {
        Grid_Type.DataSource = hRETypeL.Search_HREmployeeType(HRET_EmpType);
        Grid_Type.DataBind();
    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        Grid_Type.SelectedIndex = -1;//选中行的效果
        Grid_Type.EditIndex = -1;
        Grid_Type.SelectedIndex = -1;//如果Grid_Type存在行加黑，则取消加黑
        str = TxtType.Text.Trim();
        BindGrid(str);
        UpdatePanel_Grid.Update();
        LblStateForGrid_Type.Text = "检索后";
    }
    protected void BtnNew_Click(object sender, EventArgs e)
    {
        Panel_NewType.Visible = true;
        UpdatePanel_NewType.Update();
        TxtNewType.Text = "";
    }
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        Grid_Type.SelectedIndex = -1;//选中行的效果
        Grid_Type.EditIndex = -1;
        TxtType.Text = "";
        str = "";
        BindGrid("");
        LblStateForGrid_Type.Text = "检索前";
        UpdatePanel_Grid.Update();
    }
    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        hRETypeInfo.HRET_ID = Guid.NewGuid();
        if (TxtNewType.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入员工类型！')", true);
            return;
        }
        else
            hRETypeInfo.HRET_EmpType = TxtNewType.Text;
        hRETypeInfo.HRET_IsDeleted = false;
        try
        {
            int i=hRETypeL.Insert_HREmployeeType(hRETypeInfo);
            //this.UpdatePanel_NewType.Update();
            if(i<=0)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('重复的员工类型！')", true);
                return;
            }     
            BindGrid("");
            UpdatePanel_Grid.Update();
            TxtNewType.Text = "";
            Panel_NewType.Visible = false;
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('新增成功！')", true);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('新增失败！" + ex + "')", true);
        }
    }
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        Panel_NewType.Visible = false;
    }


    protected void Grid_Type_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete_Type")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_Type.SelectedIndex = row.RowIndex;
            Guid guid = new Guid(e.CommandArgument.ToString());
            hRETypeL.Delete_HREmployeeType(guid);
            BindGrid("");
        }
    }
    protected void Grid_Type_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Grid_Type.SelectedIndex = e.NewEditIndex;//选中行的效果
        Grid_Type.EditIndex = e.NewEditIndex;
        if (LblStateForGrid_Type.Text == "检索前")
        {
            BindGrid("");
        }
        if (LblStateForGrid_Type.Text == "检索后")
        {
            BindGrid(TxtType.Text.Trim());
        }

    }
    protected void Grid_Type_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        Grid_Type.EditIndex = -1;
        if (LblStateForGrid_Type.Text == "检索前")
        {
            BindGrid("");
        }
        if (LblStateForGrid_Type.Text == "检索后")
        {
            BindGrid(TxtType.Text.Trim());
        }
    }


    protected void Grid_Type_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        hRETypeInfo.HRET_ID = new Guid(Grid_Type.DataKeys[e.RowIndex].Value.ToString());
        hRETypeInfo.HRET_EmpType = ((TextBox)(Grid_Type.Rows[e.RowIndex].Cells[1].Controls[0])).Text.Trim().ToString();

        int i = hRETypeL.Update_HREmployeeType(hRETypeInfo);
        //this.UpdatePanel_NewType.Update();
        if (i <= 0)
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('重复的员工类型！')", true);
            return;
        }
        Grid_Type.EditIndex = -1;
        if (LblStateForGrid_Type.Text == "检索前")
        {
            BindGrid("");
        }
        if (LblStateForGrid_Type.Text == "检索后")
        {
            BindGrid(str);
        }
        UpdatePanel_Grid.Update();
        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('编辑成功！')", true);
    }
    protected void Grid_Type_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_Type.BottomPagerRow;


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

        if (LblStateForGrid_Type.Text == "检索前")
        {
            BindGrid("");
        }
        if (LblStateForGrid_Type.Text == "检索后")
        {
            BindGrid(TxtType.Text.Trim());
        }

        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_Type.PageCount ? Grid_Type.PageCount - 1 : newPageIndex;
        Grid_Type.PageIndex = newPageIndex;
        Grid_Type.PageIndex = newPageIndex;
        Grid_Type.DataBind();
    }
    protected void Grid_Type_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Grid_Type.Rows.Count; i++)
        {
            for (int j = 0; j < Grid_Type.Rows[i].Cells.Count; j++)
            {
                Grid_Type.Rows[i].Cells[j].ToolTip = Grid_Type.Rows[i].Cells[j].Text;
                if (Grid_Type.Rows[i].Cells[j].Text.Length > 15)
                {
                    Grid_Type.Rows[i].Cells[j].Text = Grid_Type.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }


            }
        }
    }
}