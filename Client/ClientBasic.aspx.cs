using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Client_ClientBasic : Page
{
    Pro_ClientBasic PCB = new Pro_ClientBasic();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {



                }

        if (Request.QueryString["status"] == "GegionSee")//区域查看权限
        {
            Title = "销售区域查看";
            Panel_ClientSort.Visible = false;
            GridView_Region.Columns[3].Visible = false;
            GridView_Region.Columns[4].Visible = false;
            Btn_NewStore.Visible = false;

            GridView_Region.DataSource = PCB.SList_CRMRegionBasicInfo();
            GridView_Region.DataBind();
            //this.GridView_ClientSort.DataSource = PCB.SList_CRMCustomerSortBasicData();
            //this.GridView_ClientSort.DataBind();
        }
        else
            if (Request.QueryString["status"] == "GegionMange")//区域维护权限
            {
                Title = "销售区域维护";
                Panel_ClientSort.Visible = false;
                GridView_Region.DataSource = PCB.SList_CRMRegionBasicInfo();
                GridView_Region.DataBind();
            }
            else if (Request.QueryString["status"] == "SortSee")//区域维护权限
            {
                Title = "销售区域维护";
                Panel_RegionBasicInfo1.Visible = false;
                UpdatePanel_RegionBasicInfo.Visible = false;
                GridView_ClientSort.Columns[3].Visible = false;
                GridView_ClientSort.Columns[4].Visible = false;
                Btn_newSort.Visible = false;

                GridView_ClientSort.DataSource = PCB.SList_CRMCustomerSortBasicData();
                GridView_ClientSort.DataBind();
            }

            else if (Request.QueryString["status"] == "SortMange")//类别维护权限
            {
                Title = "客户类别维护";
                Panel_RegionBasicInfo1.Visible = false;
                UpdatePanel_RegionBasicInfo.Visible = false;
                GridView_ClientSort.DataSource = PCB.SList_CRMCustomerSortBasicData();
                GridView_ClientSort.DataBind();
            }

    }

    #region 区域信息表后台
    protected void GridView_Region_RowCommand(object sender, GridViewCommandEventArgs e)
    {


        if (e.CommandName == "dele")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_Region.SelectedIndex = row.RowIndex;
            GridView_Region.SelectedIndex = -1;
            string Region_id = e.CommandArgument.ToString();
            Guid region_id = new Guid(Region_id);
            PCB.D_CRMRegionBasicInfo(region_id);
            GridView_Region.DataSource = PCB.SList_CRMRegionBasicInfo();
            GridView_Region.DataBind();
            UpdatePanel_RegionBasicInfo.Update();
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除成功!')", true);
            return;



        }
        else if (e.CommandName == "Change")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_Region.SelectedIndex = row.RowIndex;
            GridView_Region.SelectedIndex = -1;
            string Region_id = e.CommandArgument.ToString();
           Guid region_id = new Guid(Region_id);
           Session["region_id"] = e.CommandArgument.ToString();
            Panel_ChangeRegion.Visible = true;
            UpdatePanel_ChangeRegion.Update();
            TextBox_Changregion.Text = row.Cells[1].Text.Trim().ToString();
            TextBox_ChangeDetail.Text = row.Cells[2].Text.Trim().ToString().Replace("&nbsp;","" );
            return;
         

           
        }
        else if (e.CommandName == "Detail")
        {
            Panel_RegionPeople.Visible = true;
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_Region.SelectedIndex = row.RowIndex;
            GridView_Region.SelectedIndex = -1;
            string Region_id = e.CommandArgument.ToString();
           Guid region_id = new Guid(Region_id);
           Session["REgion_id"] = e.CommandArgument.ToString();
           GridView1_RegionPeople.DataSource = PCB.S_CRMRBI_CRMCIF(region_id);
           GridView1_RegionPeople.DataBind();
            UpdatePanel_RegionPeople.Update();
            
            return;

        }



    } //linkbutton链接按钮根据自身Commandname来触发不同事件
    protected void GridView_Region_PageIndexChanging(object sender, GridViewPageEventArgs e)//区域信息表，下一页，上一页等跳转后台
    {


        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        { // when click the "GO" Button
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView_Region.BottomPagerRow;


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
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView_Region.PageCount ? GridView_Region.PageCount - 1 : newPageIndex;

        // specify the NewPageIndex
        GridView_Region.PageIndex = newPageIndex;

        GridView_Region.PageIndex = newPageIndex;
        GridView_Region.DataSource = PCB.SList_CRMRegionBasicInfo();
        GridView_Region.DataBind();
        UpdatePanel_RegionBasicInfo.Update();
    }  //读取go前textbox，导航到指定页面
    #endregion

    #region 客户类别表后台
    protected void GridView_ClientSort_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName=="Change1")
        {
             GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_Region.SelectedIndex = row.RowIndex;
            GridView_Region.SelectedIndex = -1;
            string Sort_id = e.CommandArgument.ToString();
           Guid sort_id = new Guid(Sort_id);
           Session["sort_id"] = e.CommandArgument.ToString();
            Panel_ChangeSort.Visible = true;
            TextBox_ChanSort.Text = row.Cells[1].Text.Trim().ToString();
            TextBox_ChanSortDetail.Text = row.Cells[2].Text.Trim().ToString().Replace("&nbsp;","");
            UpdatePanel_ChangeSort.Update();
           
            return;
        }
        else
            if (e.CommandName == "dele")
            {
                GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
                GridView_Region.SelectedIndex = row.RowIndex;
                GridView_Region.SelectedIndex = -1;
                string Sort_id = e.CommandArgument.ToString();
                Guid sort_id = new Guid(Sort_id);
                PCB.D_CRMCustomerSortBasicData(sort_id);
                GridView_ClientSort.DataSource = PCB.SList_CRMCustomerSortBasicData();
                GridView_ClientSort.DataBind();
                UpdatePanel_ClientSort.Update();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除成功!')", true);
                return;
            }
        
        
        
        }

    protected void GridView_ClientSort_PageIndexChanging(object sender, GridViewPageEventArgs e)//区域信息表，下一页，上一页等跳转后台
    {


        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        { // when click the "GO" Button
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView_ClientSort.BottomPagerRow;


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
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView_ClientSort.PageCount ? GridView_ClientSort.PageCount - 1 : newPageIndex;

        // specify the NewPageIndex
        GridView_ClientSort.PageIndex = newPageIndex;

        GridView_ClientSort.PageIndex = newPageIndex;
        GridView_ClientSort.DataSource = PCB.SList_CRMCustomerSortBasicData();
        GridView_ClientSort.DataBind();
        UpdatePanel_ClientSort.Update();
    }  //读取go前textbox，导航到指定页面

    #endregion

    #region
    protected void GridView_RegionPeople_PageIndexChanging(object sender, GridViewPageEventArgs e)//区域信息表，下一页，上一页等跳转后台
    {


        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        { // when click the "GO" Button
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView1_RegionPeople.BottomPagerRow;


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
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView1_RegionPeople.PageCount ? GridView1_RegionPeople.PageCount - 1 : newPageIndex;

        // specify the NewPageIndex
        GridView1_RegionPeople.PageIndex = newPageIndex;

        GridView1_RegionPeople.PageIndex = newPageIndex;
        Guid id = new Guid(Session["REgion_id"].ToString());
        GridView1_RegionPeople.DataSource = PCB.S_CRMRBI_CRMCIF(id);
        GridView1_RegionPeople.DataBind();
        UpdatePanel_RegionPeople.Update();
    }  //读取go前textbox，导航到指定页面


    #endregion


    protected void Btn_NewStore_Click(object sender, EventArgs e)//新增区域
    {

        TextBox_Regionname.Text = "";
        TextBox_RegionDetail.Text = "";
        Panel_NewRegion.Visible =true;
        UpdatePanel_NewRegion.Update();

    }
    protected void Btn_newSort_Click(object sender, EventArgs e)//新增客户类别
    {
        TextBox_Sortname.Text = "";
        TextBox_SortDetail.Text = "";
        Panel_NewSort.Visible = true;
        UpdatePanel_NewSort.Update();
    }
    protected void Btn_RegionCancel_Click(object sender, EventArgs e)//取消新增区域
    {
        Panel_NewRegion.Visible = false;
        UpdatePanel_NewRegion.Update();
    }
    protected void Btn_CancelSort_Click(object sender, EventArgs e)//取消新增客户类别
    {
        Panel_NewSort.Visible = false;
        UpdatePanel_NewSort.Update();
    }
    protected void Btn_NewRegion_Click(object sender, EventArgs e)//确认新增区域
    {
        string name=TextBox_Regionname.Text.Trim().ToString();
        string detail=TextBox_RegionDetail.Text.Trim().ToString();
        PCB.I_CRMRegionBasicInfo(name, detail);
        GridView_Region.DataSource = PCB.SList_CRMRegionBasicInfo();
        GridView_Region.DataBind();
        UpdatePanel_RegionBasicInfo.Update();
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('新增成功!')", true);
        Panel_NewRegion.Visible = false;
        UpdatePanel_NewRegion.Update();
        return;
    }

    protected void Btn_cancelChangeRE_Click(object sender, EventArgs e)//取消修改区域，
    {
        Panel_ChangeRegion.Visible = false;
        UpdatePanel_ChangeRegion.Update();
    }
    protected void Button1_Click(object sender, EventArgs e)//确认修改区域
    {
        Guid id = new Guid(Session["region_id"].ToString());
        string name = TextBox_Changregion.Text.Trim().ToString();
        string detail = TextBox_ChangeDetail.Text.Trim().ToString();
        PCB.U_CRMRegionBasicInfo(id, name, detail);
        GridView_Region.DataSource = PCB.SList_CRMRegionBasicInfo();
        GridView_Region.DataBind();
        UpdatePanel_RegionBasicInfo.Update();
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('修改成功!')", true);
        Panel_ChangeRegion.Visible = false;
        UpdatePanel_ChangeRegion.Update();
        return;
    }
    protected void Btn_NewSortOk_Click(object sender, EventArgs e)//新增客户类别
    {
        string name = TextBox_Sortname.Text.Trim().ToString();
        string detail = TextBox_SortDetail.Text.Trim().ToString();
        PCB.I_CRMCustomerSortBasicData(name, detail);
        GridView_ClientSort.DataSource = PCB.SList_CRMCustomerSortBasicData();
        GridView_ClientSort.DataBind();
        UpdatePanel_ClientSort.Update();


        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('新增成功!')", true);
        Panel_NewSort.Visible = false;
        UpdatePanel_NewSort.Update();
        return;
    }
    protected void Btn_ChanSortDeta_Click(object sender, EventArgs e)//取消新增客户类别
    {
        Panel_ChangeSort.Visible = false;
        UpdatePanel_ChangeSort.Update();
        
    }
    protected void Btn_ChanSortName_Click(object sender, EventArgs e)//确认修改客户类别
    {
        Guid id=new Guid(Session["sort_id"].ToString());
        string name=TextBox_ChanSort.Text.Trim().ToString();
        string detail=TextBox_ChanSortDetail.Text.Trim().ToString();
        PCB.U_CRMCustomerSortBasicData(id,name,detail);
        GridView_ClientSort.DataSource = PCB.SList_CRMCustomerSortBasicData();
        GridView_ClientSort.DataBind();
        UpdatePanel_ClientSort.Update();
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('修改成功!')", true);
        Panel_ChangeSort.Visible = false;
        UpdatePanel_ChangeSort.Update();
        return;

    }
    protected void Btn_return_Click(object sender, EventArgs e)
    {
        Panel_RegionPeople.Visible = false;
        UpdatePanel_RegionPeople.Update();
    }
    protected void Btn_ReginCancel_Click(object sender, EventArgs e)//重置区域
    {
        TextBox_Regionname1.Text = "";
        GridView_Region.DataSource = PCB.SList_CRMRegionBasicInfo();
        GridView_Region.DataBind();
        UpdatePanel_RegionBasicInfo1.Update();
        UpdatePanel_RegionBasicInfo.Update();

    }
    protected void Btn_RegionSearch_Click(object sender, EventArgs e)//检索区域
    {
        string name = TextBox_Regionname1.Text.Trim().ToString();
        if (name != "")
        {
            GridView_Region.DataSource = PCB.S_CRMRBISraech(name);
            GridView_Region.DataBind();
            UpdatePanel_RegionBasicInfo.Update();
        }
        else
            GridView_Region.DataSource = PCB.SList_CRMRegionBasicInfo();
            GridView_Region.DataBind();
            UpdatePanel_RegionBasicInfo1.Update();
            UpdatePanel_RegionBasicInfo.Update();


    }
    protected void GridView_Region_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView_Region.Rows.Count; i++)
        {
            for (int j = 0; j < GridView_Region.Rows[i].Cells.Count; j++)
            {
                GridView_Region.Rows[i].Cells[j].ToolTip = GridView_Region.Rows[i].Cells[j].Text;
                if (GridView_Region.Rows[i].Cells[j].Text.Length > 15)
                {
                    GridView_Region.Rows[i].Cells[j].Text = GridView_Region.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }
            }
        }
    }
    protected void GridView_ClientSort_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView_ClientSort.Rows.Count; i++)
        {
            for (int j = 0; j < GridView_ClientSort.Rows[i].Cells.Count; j++)
            {
                GridView_ClientSort.Rows[i].Cells[j].ToolTip = GridView_ClientSort.Rows[i].Cells[j].Text;
                if (GridView_ClientSort.Rows[i].Cells[j].Text.Length > 15)
                {
                    GridView_ClientSort.Rows[i].Cells[j].Text = GridView_ClientSort.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }
            }
        }
    }
}