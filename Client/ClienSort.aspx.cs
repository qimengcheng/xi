using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Client_ClienSort : Page
{
    Pro_ClientBasic cb = new Pro_ClientBasic();

    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            labelsource.Text = "";
            Bindlingyu();

         }

        if (Request.QueryString["status"] == "SortSee")//区域查看权限
        {
            Title = "客户领域基础数据查看";
            //this.Panel_ClientSort.Visible = false;
            GridView_Region.Columns[3].Visible = false;
            GridView_Region.Columns[4].Visible = false;
            Btn_NewStore.Visible = false;
            UpdatePanel_RegionBasicInfo1.Update();
            UpdatePanel_RegionBasicInfo.Update();
            //this.GridView_Region.DataSource = PCB.SList_CRMRegionBasicInfo();
            //this.GridView_Region.DataBind();
            //this.GridView_ClientSort.DataSource = PCB.SList_CRMCustomerSortBasicData();
            //this.GridView_ClientSort.DataBind();
        }
            else if (Request.QueryString["status"] == "SortMange")//类别维护权限
            {
                Title = "客户领域基础数据维护";
               
            }

    }

    #region 区域信息表后台
    protected void GridView_Region_RowCommand(object sender, GridViewCommandEventArgs e)
    {


        if (e.CommandName == "Change")
        {
            label1.Text = e.CommandArgument.ToString();
            string temp = " and CRMCustomSortID ='" + label1.Text.ToString() + "'";
            DataSet ds = cb.S_CRMCusSort(temp);
            DataTable dt = ds.Tables[0];
            TextBox_Changregion.Text = dt.Rows[0][1].ToString();
            TextBox_ChangeDetail.Text=dt.Rows[0][2].ToString();
            Panel_ChangeRegion.Visible = true;
            UpdatePanel_ChangeRegion.Update();
        }
        else
            if (e.CommandName == "dele")
            {
                GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
                cb.D_CRMCusSort(new Guid(e.CommandArgument.ToString()));
                Bindlingyu();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除成功!')", true);
            }
        else if (e.CommandName == "Detail")
        {
            Panel_RegionPeople.Visible = true;
            Label16.Text = e.CommandArgument.ToString();
            GridView1_RegionPeople.DataSource = cb.S_CRMCusSort_Custome(new Guid(e.CommandArgument.ToString()));
            GridView1_RegionPeople.DataBind();
            UpdatePanel_RegionPeople.Update();

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
        Bindlingyu();
        UpdatePanel_RegionBasicInfo.Update();
    }  //读取go前textbox，导航到指定页面
    #endregion
    protected void Bindlingyu()
    {
        GridView_Region.DataSource = cb.S_CRMCusSort(labelsource.Text);
        GridView_Region.DataBind();
        UpdatePanel_RegionBasicInfo.Update();
    }




    protected void Btn_NewStore_Click(object sender, EventArgs e)//新增区域
    {

        TextBox_Regionname.Text = "";
        TextBox_RegionDetail.Text = "";
        Panel_NewRegion.Visible =true;
        UpdatePanel_NewRegion.Update();

    }
   
    protected void Btn_RegionCancel_Click(object sender, EventArgs e)//取消新增区域
    {
        Panel_NewRegion.Visible = false;
        UpdatePanel_NewRegion.Update();
    }
    
    protected void Btn_NewRegion_Click(object sender, EventArgs e)//确认新增区域
    {
        string name=TextBox_Regionname.Text.Trim().ToString();
        string detail=TextBox_RegionDetail.Text.Trim().ToString();
        cb.I_CRMCusSort(name, detail);
        Bindlingyu();
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('新增成功!')", true);
        Panel_NewRegion.Visible = false;
        UpdatePanel_NewRegion.Update();
        TextBox_Regionname.Text = "";
        TextBox_RegionDetail.Text = "";
    }

    protected void Btn_cancelChangeRE_Click(object sender, EventArgs e)//取消修改区域，
    {
        Panel_ChangeRegion.Visible = false;
        UpdatePanel_ChangeRegion.Update();
    }
    protected void Button1_Click(object sender, EventArgs e)//确认修改区域
    {
        Guid id = new Guid(label1.Text.ToString());
        string name = TextBox_Changregion.Text.Trim().ToString();
        string detail = TextBox_ChangeDetail.Text.Trim().ToString();
        cb.U_CRMCusSort(id, name, detail);
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('修改成功!')", true);
        Bindlingyu();
        Panel_ChangeRegion.Visible = false;
        UpdatePanel_ChangeRegion.Update();
        TextBox_Changregion.Text = "";
        TextBox_ChangeDetail.Text = "";
    }

    protected void Btn_return_Click(object sender, EventArgs e)
    {
        Panel_RegionPeople.Visible = false;
        UpdatePanel_RegionPeople.Update();
    }
  
    protected void Btn_RegionSearch_Click(object sender, EventArgs e)//检索区域
    {
      string   temp = " and CRMCustomSortName like'%" + TextBox_Regionname1.Text.ToString() + "%'";
      labelsource.Text = temp;
      Bindlingyu();

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
        GridView_Region.PageIndex = newPageIndex;

        GridView1_RegionPeople.PageIndex = newPageIndex;
         GridView1_RegionPeople.DataSource = cb.S_CRMCusSort_Custome(new Guid(Label16.Text.ToString()));
            GridView1_RegionPeople.DataBind();
            UpdatePanel_RegionPeople.Update();
    }  //读取go前textbox，导航到指定页面

}