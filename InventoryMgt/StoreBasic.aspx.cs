using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class InventoryMgt_StoreBasic : Page
{
    StoreBasicInfo imssdinfo = new StoreBasicInfo();
    ProStoreBasic PSB = new ProStoreBasic();
    static String IN="入库类别";//对全局变量修改需使用static 你们真好意思写这个注释
    static String OUT="出库类别";
    static String[] a = new String[10];//用于存放查询管理人员时的部门名称，防止重复添加
    static int i=0;//作为数组a的变量

    static  int flag_STOre = 0;//作为判断库房是新增还是编辑的判断变量
    static Guid areal_guid;
    static string Store_Name;

    static string Depart = "BDOS_Name";
    static string Manger = "UMUI_UserName";
    static int Select = 0;

    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GridView_Depart.DataSource = PSB.SList_ImstoreManger(Label1.Text);
            GridView_Depart.DataBind();
            UpdatePanel_findMan.Update();
            //GridView_Depart.DataSource = PSB.SList_User_IMstore();
            //GridView_Depart.DataBind();
            /*this.GridView_IMSSBD.DataSource = PSB.SList_IMssd_in_out(IN.ToString(), OUT.ToString());
            this.GridView_IMSSBD.DataBind();
            this.GridView_IMStore.DataSource = PSB.SList_Istore();
            this.GridView_IMStore.DataBind();
            this.GridView_Depart.DataSource = PSB.SList_User_IMstore();
            this.GridView_Depart.DataBind();
            this.DropDownList_Depart.DataSource = PSB.SList_DROP_Depart();
            this.DropDownList_Depart.DataBind();
            GridView_IMSSBD.Attributes.Add("style", "table-layout:fixed");*/

          
        }
        if (Request.QueryString["status"] == "SeeSSd")//出入库类别查看权限
        {
            Title = "出入库类别查看";
            Panel_IMStore.Visible = false;

            Button_StoreIn.Visible = false;
            Button_StoreOut.Visible = false;
            GridView_IMSSBD.Columns[4].Visible = false;
            GridView_IMSSBD.Columns[5].Visible = false;

            GridView_IMSSBD.DataSource = PSB.SList_IMssd_in_out(IN.ToString(), OUT.ToString());
            GridView_IMSSBD.DataBind();

            GridView_IMSSBD.Attributes.Add("style", "table-layout:fixed");

        }
        else
            if (Request.QueryString["status"] == "EdditSSd")//出入库类别编辑权限
            {
                Title = "出入库类别维护";
                Panel_IMStore.Visible = false;

                Button_StoreIn.Visible = true;
                Button_StoreOut.Visible = true;
                GridView_IMSSBD.Columns[4].Visible = true;
                GridView_IMSSBD.Columns[5].Visible = true;

                GridView_IMSSBD.DataSource = PSB.SList_IMssd_in_out(IN.ToString(), OUT.ToString());
                GridView_IMSSBD.DataBind();

                GridView_IMSSBD.Attributes.Add("style", "table-layout:fixed");


            }
            else
                if (Request.QueryString["status"] == "SeeStore")//库房查看权限
                {
                    Title = "库房查看";
                    Panel_StoreSearch.Visible = false;
                    Panel_IMSSBD.Visible = false;
                    Btn_NewStore.Visible = false;

                    GridView_IMStore.DataSource = PSB.SList_Istore();
                    GridView_IMStore.DataBind();
                    GridView_IMStore.Columns[4].Visible = false;
                    GridView_IMStore.Columns[5].Visible = false;
                    GridView_IMStore.Columns[6].Visible = false;
                    GridView_IMStore.Columns[7].Visible = false;


                }
                else
                    if (Request.QueryString["status"] == "SeeAreal")//区域查看权限
                    {
                        Title = "库存区域查看";
                        Panel_StoreSearch.Visible = false;
                        Panel_IMSSBD.Visible = false;
                        Btn_NewStore.Visible = false;


                        GridView_IMStore.DataSource = PSB.SList_Istore();
                        GridView_IMStore.DataBind();
                        GridView_IMStore.Columns[4].Visible = false;
                        GridView_IMStore.Columns[5].Visible = false;
                        GridView_IMStore.Columns[6].Visible = false;




                    }
                    else
                        if (Request.QueryString["status"] == "EditStore")//库房编辑权限
                        {

                            Title = "库存区域维护";
                            Panel_StoreSearch.Visible = false;
                            Panel_IMSSBD.Visible = false;
                            GridView_IMStore.Columns[7].Visible = false;

                            GridView_IMStore.DataSource = PSB.SList_Istore();
                            GridView_IMStore.DataBind();
                            //GridView_Depart.DataSource = PSB.SList_User_IMstore();
                            //GridView_Depart.DataBind();
                            DropDownList_Depart.DataSource = PSB.SList_DROP_Depart();
                            DropDownList_Depart.DataBind();


                        }

    }
    #region 出入库类别表的后台事件
    protected void GridView_IMSSBD_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate)) || (e.Row.RowState == DataControlRowState.Edit))
        {
            TextBox curText;
            curText = (TextBox)e.Row.Cells[6].Controls[0];
            curText.Attributes.Add("TextMode", "MultiLine");
   
            curText.Rows = 2;
            //curText.Width = Unit.Pixel(600);
            //curText.Height = Unit.Pixel(100);
            curText.Attributes.Add("style ", "width:97%;overflow:visible ");
        }
        else
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[6].ControlStyle.Width = Unit.Pixel(200);
            }
            
        


    }//databind ，用于调整格式
    protected void GridView_IMSSBD_PageIndexChanging(object sender, GridViewPageEventArgs e)//出入库类别表，下一页，上一页等跳转后台
    {


        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        { // when click the "GO" Button
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView_IMSSBD.BottomPagerRow;


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
        newPageIndex = newPageIndex >= GridView_IMSSBD.PageCount ? GridView_IMSSBD.PageCount - 1 : newPageIndex;

        // specify the NewPageIndex
        GridView_IMSSBD.PageIndex = newPageIndex;

        GridView_IMSSBD.PageIndex = newPageIndex;
        GridView_IMSSBD.DataSource = PSB.SList_IMssd_in_out(IN.ToString(), OUT.ToString());
        GridView_IMSSBD.DataBind();
        UpdatePanel_IMSSBD.Update();
    }  //读取go前textbox，导航到指定页面
     protected void GridView_IMSSBD_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            if (e.CommandName == "dele")
            {
                GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
                GridView_IMSSBD.SelectedIndex = row.RowIndex;
                GridView_IMSSBD.SelectedIndex = -1;

                // this.Lab_State.Text = "Delete1";
                string id = e.CommandArgument.ToString();
                Guid guid_id = new Guid(id);
                PSB.D_IMssd(guid_id);
                GridView_IMSSBD.DataSource = PSB.SList_StoreBasic();
                GridView_IMSSBD.DataBind();
                GridView_IMSSBD.DataSource = PSB.SList_IMssd_in_out(IN.ToString(), OUT.ToString());
                GridView_IMSSBD.DataBind();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除成功！')", true);
                return;
               

            }


    
        } //linkbutton链接按钮根据自身Commandname来触发不同事件

        protected void GridView_IMSSBD_RowEditing(object sender, GridViewEditEventArgs e)
        {//激活编辑按钮的事件

            GridView_IMSSBD.EditIndex = e.NewEditIndex;
            GridView_IMSSBD.Columns[6].Visible = true;
            GridView_IMSSBD.DataSource = PSB.SList_IMssd_in_out(IN.ToString(), OUT.ToString());
            GridView_IMSSBD.DataBind();
            UpdatePanel_IMSSBD.Update();
       

        }//编辑//当为commandField时使用这种，为模板列连接按钮使用rowcommand根据command那么不同来操作

        protected void GridView_IMSSBD_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {//取消编辑状态的事件

           GridView_IMSSBD.EditIndex = -1;
           GridView_IMSSBD.Columns[6].Visible = false;
           GridView_IMSSBD.DataSource = PSB.SList_IMssd_in_out(IN.ToString(), OUT.ToString());
           GridView_IMSSBD.DataBind();

        

        }//取消编辑//当为commandField时使用这种，为模板列连接按钮使用rowcommand根据command那么不同来操作

        protected void GridView_IMSSBD_RowUpdating(object sender, GridViewUpdateEventArgs e) 
        {
            GridView_IMSSBD.Columns[6].Visible = false;
            imssdinfo.IMSSBD_ID = new Guid(GridView_IMSSBD.DataKeys[e.RowIndex].Value.ToString());
            imssdinfo.IMSSBD_Detail = Convert.ToString(((TextBox)(GridView_IMSSBD.Rows[e.RowIndex].Cells[6].Controls[0])).Text.Trim().ToString());
            PSB.U_IMssd(imssdinfo);
            GridView_IMSSBD.EditIndex = -1;
            GridView_IMSSBD.DataSource = PSB.SList_IMssd_in_out(IN.ToString(), OUT.ToString());
            GridView_IMSSBD.DataBind();
            //this.UpdatePanel_IMSSBD.Update();
            
        


        }//更新//当为commandField时使用这种，为模板列连接按钮使用rowcommand根据command那么不同来操作
   #endregion
    



    #region 库房表的后台事件
        protected void GridView_IMStore_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate)) || (e.Row.RowState == DataControlRowState.Edit))
            {
                TextBox curText1,curText2;
                curText1 = (TextBox)e.Row.Cells[2].Controls[0];
                //curText.Width = Unit.Pixel(600);
                //curText.Height = Unit.Pixel(100);
                curText1.Attributes.Add("style ", "width:97%;overflow:visible ");

                curText2 = (TextBox)e.Row.Cells[3].Controls[0];
                //curText.Width = Unit.Pixel(600);
                //curText.Height = Unit.Pixel(100);
                curText2.Attributes.Add("style ", "width:97%;overflow:visible ");

            }
        }//databind ，用于调整格式
    protected void GridView_IMStore_PageIndexChanging(object sender, GridViewPageEventArgs e)//库房表，下一页，上一页等跳转后台
    {


        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        { // when click the "GO" Button
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView_IMStore.BottomPagerRow;


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
        newPageIndex = newPageIndex >= GridView_IMStore.PageCount ? GridView_IMStore.PageCount - 1 : newPageIndex;

        // specify the NewPageIndex
        GridView_IMStore.PageIndex = newPageIndex;

        GridView_IMStore.PageIndex = newPageIndex;
        GridView_IMStore.DataSource = PSB.SList_Istore();
        GridView_IMStore.DataBind();
    }
    protected void GridView_IMStore_RowCommand(object sender, GridViewCommandEventArgs e)
    {


       if (e.CommandName == "bianji")
        {
            
            flag_STOre =0;
            Session["store11_id"] = e.CommandArgument.ToString();
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_IMStore.SelectedIndex = row.RowIndex;
            GridView_IMStore.SelectedIndex = -1;

            string Store_name = row.Cells[1].Text.Trim().ToString();
            i = 0;
            TextBox_Store.Text = Store_name;
            TextBox_Store.ReadOnly =true;
            TextBox_Store.Enabled = false;
            TextBox_StoreManger.Text = "";
            TextBox_StoreManger0.Text = "";
            TextBox_StoreManger.ReadOnly = true;
            TextBox_StoreManger.Enabled = false;
            TextBox_StoreManger0.ReadOnly = true;
            TextBox_StoreManger0.Enabled = false;
            Panel_EditStore.Visible = true;
            UpdatePanel_EditStore.Update();


        }
       else
            if (e.CommandName == "dele")
            {
                
                string id = e.CommandArgument.ToString();
                Guid guid_id = new Guid(id);
                PSB.D_IMstore(guid_id);

                GridView_IMStore.DataSource = PSB.SList_Istore();
                GridView_IMStore.DataBind();
                UpdatePanel_IMStore.Update();

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除成功!')", true);
                return;
            }
            else
                if (e.CommandName == "SET")
                {
                    Panel_areal.Visible = true;
                    Panel_arealedit.Visible = true;
                    
                    GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
                    GridView_IMStore.SelectedIndex = row.RowIndex;
                    GridView_IMStore.SelectedIndex = -1;
                    Store_Name = row.Cells[1].Text.Trim().ToString();
                    string id = e.CommandArgument.ToString();
                    Guid guid_id = new Guid(id);
                    areal_guid = guid_id;
                    GridView_areal.DataSource = PSB.S_STOREareal(areal_guid);
                    GridView_areal.DataBind();
                    UpdatePanel_areal.Update();
                    UpdatePanel_arealedit.Update();
                }
                else
                    if (e.CommandName == "SEE")
                    {
                        Panel_areal.Visible = true;
                       
                        GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
                        GridView_IMStore.SelectedIndex = row.RowIndex;
                        GridView_IMStore.SelectedIndex = -1;
                        Store_Name = row.Cells[1].Text.Trim().ToString();
                        string id = e.CommandArgument.ToString();
                        Guid guid_id = new Guid(id);
                        areal_guid = guid_id;
                        GridView_areal.DataSource = PSB.S_STOREareal(areal_guid);
                        GridView_areal.DataBind();
                        GridView_areal.Columns[4].Visible = false;
                        GridView_areal.Columns[5].Visible = false;
                        UpdatePanel_areal.Update();
                        UpdatePanel_arealedit.Update();
                    }



    } //linkbutton链接按钮根据自身Commandname来触发不同事件

    protected void GridView_IMStore_RowEditing(object sender, GridViewEditEventArgs e)
    {//激活编辑按钮的事件

        GridView_IMStore.EditIndex = e.NewEditIndex;
        GridView_IMStore.DataSource = PSB.SList_Istore();
        GridView_IMStore.DataBind();



    }//编辑//当为commandField时使用这种，为模板列连接按钮使用rowcommand根据command那么不同来操作

    protected void GridView_IMStore_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {//取消编辑状态的事件

        GridView_IMStore.EditIndex = -1;
        GridView_IMStore.DataSource = PSB.SList_Istore();
        GridView_IMStore.DataBind();



    }//取消编辑//当为commandField时使用这种，为模板列连接按钮使用rowcommand根据command那么不同来操作

    protected void GridView_IMStore_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        imssdinfo.IMS_StoreID = new Guid(GridView_IMStore.DataKeys[e.RowIndex].Value.ToString());
        imssdinfo.IMS_ResponDepart = Convert.ToString(((TextBox)(GridView_IMStore.Rows[e.RowIndex].Cells[2].Controls[0])).Text.Trim().ToString());
        imssdinfo.IMS_ResponMan = Convert.ToString(((TextBox)(GridView_IMStore.Rows[e.RowIndex].Cells[3].Controls[0])).Text.Trim().ToString());
        PSB.U_IMstore(imssdinfo);
        GridView_IMStore.EditIndex = -1;
        GridView_IMStore.DataSource = PSB.SList_Istore();
        GridView_IMStore.DataBind();
        UpdatePanel_IMStore.Update();




    }//更新//当为commandField时使用这种，为模板列连接按钮使用rowcommand根据command那么不同来操作


    #endregion

    #region 库房管理人员查询表的后台事件
    protected void GridView_Depart_PageIndexChanging(object sender, GridViewPageEventArgs e)//出入库类别表，下一页，上一页等跳转后台
    {

       GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        { // when click the "GO" Button
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView_Depart.BottomPagerRow;


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
       // newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
     //   newPageIndex = newPageIndex >= GridView_Depart.PageCount ? GridView_Depart.PageCount - 1 : newPageIndex;

        // specify the NewPageIndex
      //  GridView_Depart.PageIndex = newPageIndex;

     //   GridView_Depart.PageIndex = newPageIndex;
        GridView_Depart.DataSource = PSB.SList_ImstoreManger(Label1.Text);
        GridView_Depart.DataBind();
        UpdatePanel_findMan.Update();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView_Depart.PageCount ? GridView_Depart.PageCount - 1 : newPageIndex;
        GridView_Depart.PageIndex = newPageIndex;
        GridView_Depart.DataBind();
    }  //读取go前textbox，导航到指定页面

    protected void GridView_Depart_RowCommand(object sender, GridViewCommandEventArgs e)
    {


        if (e.CommandName == "Add1")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_Depart.SelectedIndex = row.RowIndex;
            GridView_Depart.SelectedIndex = -1;

            // this.Lab_State.Text = "Delete1";
            string id = e.CommandArgument.ToString();
            CheckBox box = (CheckBox)row.FindControl("CheckBox2");
            box.Checked = true;
            string depart = row.Cells[2].Text.Trim().ToString();
            string Name = row.Cells[3].Text.Trim().ToString();
            int j=0;
            int flag = 0;
            for (j = 0; j < i; j++)
            {
                if (depart.ToString() == a[j].ToString())
                {
                    flag = 1;
                }
            }
            if (flag == 0)
            {
                TextBox_StoreManger0.Text = TextBox_StoreManger0.Text.Trim().ToString() + depart+ ",";
                a[i] = depart;
                i++;
            }
            else
            {
                flag = 0;
                TextBox_StoreManger0.Text = TextBox_StoreManger0.Text.Trim().ToString();
            }

            TextBox_StoreManger.Text = TextBox_StoreManger.Text.Trim().ToString() + Name + ",";
            UpdatePanel_findMan.Update();
            UpdatePanel_EditStore.Update();


        }
    }
    protected void GridView_Depart_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        /*LinkButton btn = (LinkButton)e.Row.FindControl("Add1");

        if (btn != null)
        {

            btn.CommandArgument = e.Row.RowIndex.ToString();

        }*/
    }//databind ，用于获取dept表行索引


    #endregion

    #region 区域表后台事件
    protected void GridView_areal_RowEditing(object sender, GridViewEditEventArgs e)
    {//激活编辑按钮的事件

        GridView_areal.EditIndex = e.NewEditIndex;
        GridView_areal.DataSource = PSB.S_STOREareal(areal_guid);
        GridView_areal.DataBind();
        UpdatePanel_areal.Update();


    }//编辑//当为commandField时使用这种，为模板列连接按钮使用rowcommand根据command那么不同来操作

    protected void GridView_areal_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {//取消编辑状态的事件

        GridView_areal.EditIndex = -1;
        GridView_areal.DataSource = PSB.S_STOREareal(areal_guid);
        GridView_areal.DataBind();
        UpdatePanel_areal.Update();



    }//取消编辑//当为commandField时使用这种，为模板列连接按钮使用rowcommand根据command那么不同来操作

    protected void GridView_areal_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
       
        GridView_areal.EditIndex = -1;
        imssdinfo.IMSA_AreaID = new Guid(GridView_areal.DataKeys[e.RowIndex].Value.ToString());
        imssdinfo.IMSA_AreaName = Convert.ToString(((TextBox)(GridView_areal.Rows[e.RowIndex].Cells[2].Controls[0])).Text.Trim().ToString());
        imssdinfo.IMSA_Remark = Convert.ToString(((TextBox)(GridView_areal.Rows[e.RowIndex].Cells[3].Controls[0])).Text.Trim().ToString());
        imssdinfo.IMSA_MakeMan = Session["UserName"].ToString();
        PSB.U_IMstore_Areal(imssdinfo);
        GridView_areal.DataSource = PSB.S_STOREareal(areal_guid);
        GridView_areal.DataBind();
        UpdatePanel_areal.Update();
        //this.UpdatePanel_IMSSBD.Update();




    }//更新//当为commandField时使用这种，为模板列连接按钮使用rowcommand根据command那么不同来操作
    protected void GridView_areal_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate)) || (e.Row.RowState == DataControlRowState.Edit))
        {
            TextBox curText1, curText2;
            curText1 = (TextBox)e.Row.Cells[2].Controls[0];
            //curText.Width = Unit.Pixel(600);
            //curText.Height = Unit.Pixel(100);
            curText1.Attributes.Add("style ", "width:97%;overflow:visible ");

            curText2 = (TextBox)e.Row.Cells[3].Controls[0];
            //curText.Width = Unit.Pixel(600);
            //curText.Height = Unit.Pixel(100);
            curText2.Attributes.Add("style ", "width:97%;overflow:visible ");

        }
    }//databind ，用于调整格式
    protected void GridView_areal_RowCommand(object sender, GridViewCommandEventArgs e)
    {


        if (e.CommandName == "Delete3")
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView_IMStore.SelectedIndex = row.RowIndex;
            GridView_IMStore.SelectedIndex = -1;

            string id = e.CommandArgument.ToString();
            Guid guid_id = new Guid(id);
            PSB.D_IMstore_Areal(guid_id);
            GridView_areal.DataSource = PSB.S_STOREareal(areal_guid);
            GridView_areal.DataBind();
            UpdatePanel_areal.Update();
            UpdatePanel_arealedit.Update();

        }
    }

    protected void GridView_areal_PageIndexChanging(object sender, GridViewPageEventArgs e)//出入库类别表，下一页，上一页等跳转后台
    {


        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        { // when click the "GO" Button
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView_areal.BottomPagerRow;


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
        newPageIndex = newPageIndex >= GridView_areal.PageCount ? GridView_areal.PageCount - 1 : newPageIndex;

        // specify the NewPageIndex
        GridView_areal.PageIndex = newPageIndex;

        GridView_areal.PageIndex = newPageIndex;
        GridView_areal.DataSource = PSB.S_STOREareal(areal_guid);
        GridView_areal.DataBind();
        UpdatePanel_areal.Update();
    }  //读取go前textbox，导航到指定页面

    #endregion

    protected void Btn_NewStore_Click(object sender, EventArgs e)//新增库房
    {
       
          flag_STOre =1;
           i = 0;
          TextBox_Store.ReadOnly =false;
            TextBox_Store.Enabled = true;
        TextBox_Store.Text = "";
        TextBox_StoreManger.Text = "";
        TextBox_StoreManger0.Text = "";
        Panel_EditStore.Visible = true;
        UpdatePanel_EditStore.Update();
    }
    protected void Button_StoreIn_Click(object sender, EventArgs e)
    {
        Panel_AddIn.Visible = true;
        UpdatePanel_AddIn.Update();
    }
    protected void Btn_NewInCancel_Click(object sender, EventArgs e)
    {
        Panel_AddIn.Visible = false;
        UpdatePanel_AddIn.Update();
    }
    protected void Button_StoreOut_Click(object sender, EventArgs e)
    {
        Panel_AddOut.Visible = true;
        UpdatePanel_AddOut.Update();
    }
    protected void Btn_NewOutCancel_Click(object sender, EventArgs e)
    {
        Panel_AddOut.Visible = false;
        UpdatePanel_AddOut.Update();
    }
    protected void Btn_EditCancel_Click(object sender, EventArgs e)
    {
        Panel_EditStore.Visible = false;
        Panel_findMan.Visible = false;
        UpdatePanel_EditStore.Update();
        UpdatePanel_findMan.Update();
    }
    protected void Btn_FindMan_Click(object sender, EventArgs e)
    {
        DropDownList_Depart.SelectedValue = "请选择";
        TextBox_DptMan.Text = "";
        Panel_findMan.Visible = true;
        UpdatePanel_findMan.Update();
    }
    protected void Btn_cancel_Click(object sender, EventArgs e)
    {
        Panel_findMan.Visible = false;
        UpdatePanel_findMan.Update();

    }
    protected void Btn_NewIn_Click(object sender, EventArgs e)//新增入库
    {

        
        imssdinfo.IMSSBD_Man = Session["UserName"].ToString();
        imssdinfo.IMSSBD_Name = TextBox_INname.Text.Trim().ToString();
        imssdinfo.IMSSBD_Detail = TextBox_INDetail.Text.Trim().ToString();
        imssdinfo.IMSSBD_Time = DateTime.Now;
        if (TextBox_INname.Text.Trim().ToString() != "")
        {
        DataSet ds = PSB.SList_IMssd_Name(TextBox_INname.Text.Trim().ToString());
        DataTable dt = ds.Tables[0];
        DataView dv = ds.Tables[0].DefaultView;
        if (dt.Rows.Count != 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('系统中已有该类型名称，不能重名！')", true);
            return;
        }
        else
        {
            PSB.I_IMssd(imssdinfo);
            GridView_IMSSBD.DataSource = PSB.SList_IMssd_in_out(IN.ToString(), OUT.ToString());
            GridView_IMSSBD.DataBind();
            UpdatePanel_IMSSBD.Update();
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('类型新增成功!')", true);
            return;
        }
        }
        else
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('类型名称不能为空！')", true);
            return;
        }


    }
    protected void Btn_NewOut_Click(object sender, EventArgs e)//新增出库
    {

        imssdinfo.IMSSBD_Man = Session["UserName"].ToString();
        imssdinfo.IMSSBD_Name = TextBox_OutName.Text.Trim().ToString();
        imssdinfo.IMSSBD_Detail = TextBox_OutDetail.Text.Trim().ToString();
        imssdinfo.IMSSBD_Time = DateTime.Now;
        if (TextBox_OutName.Text.Trim().ToString() != "")
        {
            DataSet ds = PSB.SList_IMssd_Name(TextBox_OutName.Text.Trim().ToString());
            DataTable dt = ds.Tables[0];
            DataView dv = ds.Tables[0].DefaultView;
            if (dt.Rows.Count != 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('系统中已有该类型名称，不能重名！')", true);
                return;
            }
            else
            {
                PSB.I_IMssdOut(imssdinfo);
                GridView_IMSSBD.DataSource = PSB.SList_IMssd_in_out(IN.ToString(), OUT.ToString());
                GridView_IMSSBD.DataBind();
                UpdatePanel_IMSSBD.Update();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('类型新增成功!')", true);
                return;
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('类型名称不能为空！')", true);
            return;
        }
    }
    protected void Btn_StoreSearch_Click(object sender, EventArgs e)//检索，出入库
    {
        if((DropDownList_StoreIn.Text.Trim().ToString())=="出入库类别")
        {
            IN = "入库类别";
            OUT = "出库类别";
            GridView_IMSSBD.DataSource = PSB.SList_IMssd_in_out(IN.ToString(), OUT.ToString());
            GridView_IMSSBD.DataBind();
            UpdatePanel_IMSSBD.Update();
        }
        else
            if ((DropDownList_StoreIn.Text.Trim().ToString()) == "入库类别")
            {
                IN = "入库类别";
                OUT = "空";
                GridView_IMSSBD.DataSource = PSB.SList_IMssd_in_out(IN.ToString(), OUT.ToString());
                GridView_IMSSBD.DataBind();
                UpdatePanel_IMSSBD.Update();
            }
            else
                if ((DropDownList_StoreIn.Text.Trim().ToString()) == "出库类别")
                {
                    IN = "空";
                    OUT = "出库类别";
                    GridView_IMSSBD.DataSource = PSB.SList_IMssd_in_out(IN.ToString(), OUT.ToString());
                    GridView_IMSSBD.DataBind();
                    UpdatePanel_IMSSBD.Update();
                }
    }
    protected void Button_StoreCancel_Click(object sender, EventArgs e)//重置检索
    {
        DropDownList_StoreIn.Text = "出入库";
        IN = "入库类别";
        OUT = "出库类别";
        GridView_IMSSBD.DataSource = PSB.SList_IMssd_in_out(IN.ToString(), OUT.ToString());
        GridView_IMSSBD.DataBind();
        UpdatePanel_IMSSBD.Update();
    }
    protected void Btn_renewl0_Click(object sender, EventArgs e)//重新添加管理人员与部门
    {
        i = 0;
        TextBox_StoreManger.Text = "";
        TextBox_StoreManger0.Text = "";
        UpdatePanel_EditStore.Update();
        UpdatePanel_findMan.Update();
    }
    protected void Btn_EditStore_Click(object sender, EventArgs e)
    {

       
       if(flag_STOre ==1)
{
       imssdinfo.Flag=1;
        imssdinfo.IMS_StoreName = TextBox_Store.Text.Trim().ToString();
       
        if (TextBox_Store.Text.Trim().ToString() != ""&&TextBox_StoreManger.Text.Trim().ToString()!=""&&TextBox_StoreManger0.Text.Trim().ToString()!="")
        {
            DataSet ds = PSB.SList_Imstore_Name(TextBox_Store.Text.Trim().ToString());
            DataTable dt = ds.Tables[0];
            DataView dv = ds.Tables[0].DefaultView;
            if (dt.Rows.Count != 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('系统中已有该库房名称，不能重名！')", true);
                return;
            }
            else
            {
                imssdinfo.IMS_ResponDepart = TextBox_StoreManger0.Text.Trim().ToString().Substring(0, TextBox_StoreManger0.Text.Trim().ToString().Length - 1);
                imssdinfo.IMS_ResponMan = TextBox_StoreManger.Text.Trim().ToString().Substring(0, TextBox_StoreManger.Text.Trim().ToString().Length - 1);
                PSB.I_IMstore_new(imssdinfo);
                GridView_IMStore.DataSource = PSB.SList_Istore();
                GridView_IMStore.DataBind();
                Panel_EditStore.Visible = false;
             Panel_findMan.Visible = false;
             UpdatePanel_EditStore.Update();
            UpdatePanel_findMan.Update();
                UpdatePanel_IMStore.Update();

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('库房新增成功!')", true);
                return;
            }
        }
        else
        {
            if (TextBox_Store.Text.Trim().ToString() == "")
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('库房名称不能为空！')", true);
                return;
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请选择管理人员及部门！')", true);
                return;
            }
        }
 }
      else
      if(flag_STOre ==0)
      {
        imssdinfo.Flag=0;
        Guid STORE_ID = new Guid(Session["store11_id"].ToString());
        imssdinfo.IMS_StoreID = STORE_ID;

       imssdinfo.IMS_StoreName = TextBox_Store.Text.Trim().ToString();
         imssdinfo.IMS_ResponDepart = TextBox_StoreManger0.Text.Trim().ToString().Substring(0, TextBox_StoreManger0.Text.Trim().ToString().Length - 1);
          imssdinfo.IMS_ResponMan = TextBox_StoreManger.Text.Trim().ToString().Substring(0, TextBox_StoreManger.Text.Trim().ToString().Length - 1);
          PSB.I_IMstore_new(imssdinfo);
GridView_IMStore.DataSource = PSB.SList_Istore();
                GridView_IMStore.DataBind();
                Panel_EditStore.Visible = false;
               Panel_findMan.Visible = false;
                UpdatePanel_EditStore.Update();
               UpdatePanel_findMan.Update();
                UpdatePanel_IMStore.Update();

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('库房修改成功!')", true);
                return;




       }

    }
    protected void Btn_DeprtMan_Click(object sender, EventArgs e)//检索库房管理人员
    {

        
        //Depart = DropDownList_Depart.Text.Trim().ToString();
        //Manger = TextBox_DptMan.Text.Trim().ToString();
        string temp = "";
        if (DropDownList_Depart.SelectedValue != "请选择")
        {
            temp += " and b.BDOS_Name like '%" + DropDownList_Depart.SelectedValue.ToString() + "%'";
        }
        if (TextBox_DptMan.Text != "")
        {
            temp += " and a.UMUI_UserName like '%" + TextBox_DptMan.Text.ToString() + "%'";
        }
        Label1.Text = temp;
        GridView_Depart.DataSource = PSB.SList_ImstoreManger(Label1.Text);
        GridView_Depart.DataBind();
        UpdatePanel_findMan.Update();


    }
    protected void Btn_confirm_Click(object sender, EventArgs e)
    {
        Panel_findMan.Visible = false;
        UpdatePanel_findMan.Update();
    }
    protected void Btn_cancel0_Click(object sender, EventArgs e)
    {
        Panel_areal.Visible = false;
        Panel_arealedit.Visible = false;
        Panel_newareal.Visible = false;
        UpdatePanel_areal.Update();
        UpdatePanel_arealedit.Update();
        UpdatePanel_newareal.Update();
    }
    protected void Btn_new_areal_Click(object sender, EventArgs e)
    {
        Panel_newareal.Visible = true;
        TextBox_StoreNAME.Text = Store_Name;
        UpdatePanel_newareal.Update();
    }
    protected void Btn_confirm_areal_Click(object sender, EventArgs e)
    {

        if (TextBox_ArealName.Text.Trim().ToString() == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('区域名称不能为空！')", true);
            return;
        }
        else
        {
            DataSet ds = PSB.SList_Imstore_ArealName(TextBox_ArealName.Text.Trim().ToString(),areal_guid);
            DataTable dt = ds.Tables[0];
            DataView dv = ds.Tables[0].DefaultView;
            if (dt.Rows.Count != 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('系统中已有该区域名称，不能重名！')", true);
                return;
            }
            else
            {
                imssdinfo.IMS_StoreID = areal_guid;
                imssdinfo.IMSA_AreaName = TextBox_ArealName.Text.Trim().ToString();
                imssdinfo.IMSA_Remark = TextBox_ArealDetail.Text.Trim().ToString();
                imssdinfo.IMSA_MakeMan = Session["UserName"].ToString();
                PSB.I_IMstoreAreal(imssdinfo);
                GridView_areal.DataSource = PSB.S_STOREareal(areal_guid);
                GridView_areal.DataBind();
                UpdatePanel_areal.Update();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('添加区域成功！')", true);
                return;
            }
        }
    }
    protected void Btn_cancel_areal(object sender, EventArgs e)
    {
        Panel_newareal.Visible = false;
        UpdatePanel_newareal.Update();
    }
}
