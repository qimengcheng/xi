using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLLCraftBasicInfo;
using EntityOfCraftBasicInfoMgt;

public partial class CraftMgt_CraftBasicInfoMgt : Page
{
    CraftBasicInfoMgt info = new CraftBasicInfoMgt();//新建工艺基础信息管理对象
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
          if (!((Session["UserRole"].ToString().Contains("工艺基础信息查看")) || (Session["UserRole"].ToString().Contains("工艺基础信息维护"))))
            {
                Response.Redirect("~/Default.aspx");

            }
          if (!Session["UserRole"].ToString().Contains("工艺基础信息维护"))
            {

                ButtonNew.Visible = false;
                GridViewUnit.Columns[2].Visible = false;
                GridViewUnit.Columns[3].Visible = false;
            }
            DataSet set = new DataSet();
            set = BLLCraftBasicInfoMgt.BindUnit();
            Session["BindTable"] = set;
            BindData();
        }
    }
    /// <summary>
    /// 函数名:BindData
    /// 作用：绑定GridViewUnit的数据
    /// 作者:开济
    /// </summary>
    private void BindData()
    {
        GridViewUnit.DataSource = Session["BindTable"];
        GridViewUnit.DataBind();
    }
    protected void ButtonSearch_Click(object sender, EventArgs e)
    {
        Label_Grid1_State.Text = "模糊搜索数据源";
        string name = TextBoxUnit.Text;
        if (name != "")
        {
            Session["BindTable"] = BLLCraftBasicInfoMgt.SearchUnit(name);
            BindData();
            UpdatePanelList.Update();
        }
        else
        {
            Label_Grid1_State.Text = "默认数据源";
            Session["BindTable"] = BLLCraftBasicInfoMgt.BindUnit();
            BindData();
            UpdatePanelList.Update();
        }

    }
    protected void ButtonReset_Click(object sender, EventArgs e)
    {
        TextBoxUnit.Text = "";
        Label_Grid1_State.Text = "默认数据源";
        Session["BindTable"] = BLLCraftBasicInfoMgt.BindUnit();
        BindData();
        UpdatePanelList.Update();
    }
    protected void ButtonNew_Click(object sender, EventArgs e)
    {
        PanelUnitNew.Visible = true;//Panel可见
        UpdatePanelUnitNew.Update();
    }
    protected void ButtonSubmit_Click(object sender, EventArgs e)
    {
        string UnitName = TextBoxNew.Text;
        if (UnitName == "")
        {
            Message.Text = "请输入要添加的用量单位！";
            UpdatePanelList.Update();
        }
        else if (BLLCraftBasicInfoMgt.SearchSameUnit(UnitName))
        {
            if (BLLCraftBasicInfoMgt.AddUnit(UnitName))
            {
                Message.Text = "数据已成功添加！";
                TextBoxNew.Text = "";
                PanelUnitNew.Visible = false;//Panel不可见
            }
            else
            {
                Message.Text = "数据未成功添加！";
            }
            Session["BindTable"] = BLLCraftBasicInfoMgt.BindUnit();
            BindData();
            UpdatePanelList.Update();
        }
        else
        {
            Message.Text = "用量单位重复！";
            UpdatePanelList.Update();
        }
    }
    protected void ButtonCancel_Click(object sender, EventArgs e)
    {
        TextBoxNew.Text = "";
    }
    protected void ButtonClose_Click(object sender, EventArgs e)
    {
        PanelUnitNew.Visible = false;//Panel不可见
        UpdatePanelUnitNew.Update();
    }
    protected void GridViewUnit_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        { // when click the "GO" Button
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridViewUnit.BottomPagerRow;


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
            Session["BindTable"] = BLLCraftBasicInfoMgt.BindUnit();
            BindData();
            UpdatePanelList.Update();
        }
        if (Label_Grid1_State.Text == "模糊搜索数据源")
        {
            Session["BindTable"] = BLLCraftBasicInfoMgt.SearchUnit(TextBoxUnit.Text.Trim());
            BindData();
            UpdatePanelList.Update();
        } //绑定数据源

        //bindgridview();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridViewUnit.PageCount ? GridViewUnit.PageCount - 1 : newPageIndex;

        // specify the NewPageIndex
        GridViewUnit.PageIndex = newPageIndex;

        GridViewUnit.PageIndex = newPageIndex;
        GridViewUnit.DataBind();
    }
    protected void GridViewUnit_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridViewUnit.EditIndex = e.NewEditIndex;
        BindData();
    }
    protected void GridViewUnit_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        info.UnitID = new Guid(GridViewUnit.DataKeys[e.RowIndex].Value.ToString());
        info.UnitName = Convert.ToString(((TextBox)(GridViewUnit.Rows[e.RowIndex].Cells[1].Controls[0])).Text.Trim().ToString());
        if (BLLCraftBasicInfoMgt.SearchSameUnit(info.UnitName))
        {
            if (BLLCraftBasicInfoMgt.UpdateUnit(info))
            {
                Message.Text = "数据已成功更新！";
                GridViewUnit.EditIndex = -1;
                Session["BindTable"] = BLLCraftBasicInfoMgt.BindUnit();
                BindData();
            }
            else
            {
                Message.Text = "";
            }
        }
        else
            Message.Text = "存在同名的用量单位！";
    }
    protected void GridViewUnit_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridViewUnit.EditIndex = -1;
        BindData();
    }
    protected void GridViewUnit_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteUnit")//删除某行数据
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridViewUnit.SelectedIndex = row.RowIndex;
            string id = e.CommandArgument.ToString();
            Guid guid_id = new Guid(id);
            if (BLLCraftBasicInfoMgt.DeleteUnit(guid_id))
            {
                Message.Text = "数据已成功删除！";
            }
            else
            {
                Message.Text = "";
            }
            Session["BindTable"] = BLLCraftBasicInfoMgt.BindUnit();
            BindData();
        }
    }
}