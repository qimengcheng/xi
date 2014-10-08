using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using RTXHelper;

public partial class SalesMgt_SalesAfter : Page
{

    SalesAfterD st = new SalesAfterD();
    protected void Page_Load(object sender, EventArgs e)
    {
       
    
        if (!IsPostBack)
        {
            ClosePanel();
            BindTousuSort();
            BindShouhouSort();
            BindKesuMain();
            BindDrop_Tousu2();
            BindDrop_Tousu4();
            Gridview_Detail.DataSource = st.Select_ShouhouDetail(new Guid());
            Gridview_Detail.DataBind();
            UpdatePanel_Detail.Update();
            BindOrder();
            BindDrop_ShouhouSort3();
            BindDrop_ShouhouSort5();
            BindNode();
           
        }
        #region 权限
        if (Request.QueryString["status"] == "SalesTousuSortLook")//投诉类别查看
        {
            Title = "投诉类别查看";
            Panel5.Visible = true;
            Button8.Visible = false;
            UpdatePanel4.Update();
            Panel_TousuSort.Visible = true;
            Gridview_TousuSort.Columns[5].Visible = false;
            Gridview_TousuSort.Columns[6].Visible = false;
            UpdatePanel_TousuSort.Update();
            Panel4.Visible = false;
            UpdatePanel3.Update();
            Panel12.Visible = false;
            UpdatePanel11.Update();

        }

        if (Request.QueryString["status"] == "SalesTousuSortEdit")//投诉类别维护
        {
            Title = "投诉类别维护";
            Panel5.Visible = true;
            Button8.Visible = true;
            UpdatePanel4.Update();
            Panel_TousuSort.Visible = true;
            Gridview_TousuSort.Columns[5].Visible = true;
            Gridview_TousuSort.Columns[6].Visible = true;
            UpdatePanel_TousuSort.Update();
            Panel4.Visible = false;
            UpdatePanel3.Update();
            Panel12.Visible = false;
            UpdatePanel11.Update();


        }
        if (Request.QueryString["status"] == "SalesAfterSortLook")//售后类别查看
        {
            Title = "售后类别查看";
            Panel7.Visible = true;
            Button11.Visible = false;
            UpdatePanel6.Update();
            Panel8.Visible = true;
            Gridview1.Columns[5].Visible = false;
            Gridview1.Columns[6].Visible = false;
            UpdatePanel7.Update();
            Panel4.Visible = false;
            UpdatePanel3.Update();
            Panel12.Visible = false;
            UpdatePanel11.Update();

        }
        if (Request.QueryString["status"] == "SalesAfterSortEdit")//售后类别维护
        {
            Title = "售后类别维护";
            Panel7.Visible = true;
            Button11.Visible = true;
            UpdatePanel6.Update();
            Panel8.Visible = true;
            Gridview1.Columns[5].Visible = true;
            Gridview1.Columns[6].Visible = true;
            UpdatePanel7.Update();
            Panel4.Visible = false;
            UpdatePanel3.Update();
            Panel12.Visible = false;
            UpdatePanel11.Update();


        }
        if (Request.QueryString["status"] == "SalesAfterMainLook")//客诉主表查看
        {
            Title = "客诉主表查看";
            Panel10.Visible = true;
            Button15.Visible = false;
            UpdatePanel9.Update();
            Panel_Main.Visible = true;
            Gridview_OrderDeliver.Columns[13].Visible = true;
            UpdatePanel_Main.Update();
            Gridview_Detail.Columns[11].Visible = false;
            Gridview_Detail.Columns[12].Visible = false;
            UpdatePanel_Detail.Update();
            Panel4.Visible = false;
            UpdatePanel3.Update();
            Panel12.Visible = false;
            UpdatePanel11.Update();





        }
        if (Request.QueryString["status"] == "SalesAfterMainEdit")//客诉主表维护
        {
            Title = "客诉主表维护";
            Panel10.Visible = true;
            Button15.Visible = true;
            UpdatePanel9.Update();
            Panel_Main.Visible = true;
            Gridview_OrderDeliver.Columns[13].Visible = true;
            Gridview_OrderDeliver.Columns[14].Visible = true;
            Gridview_OrderDeliver.Columns[15].Visible = true;
            UpdatePanel_Main.Update();
            Gridview_Detail.Columns[11].Visible = true;
            Gridview_Detail.Columns[12].Visible = false;
            UpdatePanel_Detail.Update();
            Panel4.Visible = false;
            UpdatePanel3.Update();
            Panel12.Visible = false;
            UpdatePanel11.Update();


        }
        if (Request.QueryString["status"] == "SalesAfterAnalysis")//客诉分析结果录入
        {
            Title = "客诉分析结果录入";
            Panel10.Visible = true;
            Button15.Visible = false;
            UpdatePanel9.Update();
            Panel_Main.Visible = true;
            Gridview_OrderDeliver.Columns[13].Visible = true;
            Gridview_OrderDeliver.Columns[16].Visible = false;
            Gridview_OrderDeliver.Columns[17].Visible = false;
            UpdatePanel_Main.Update();
            UpdatePanel_Main.Update();
            Gridview_Detail.Columns[11].Visible = false;
            Gridview_Detail.Columns[12].Visible = true;
            UpdatePanel_Detail.Update();
            Panel4.Visible = false;
            UpdatePanel3.Update();
            Panel12.Visible = false;
            UpdatePanel11.Update();


        }
        if (Request.QueryString["status"] == "SalesAfterCheck")//客诉分析结果审核
        {
            Title = "客诉分析结果审核";
            Panel10.Visible = true;
            Button15.Visible = false;
            UpdatePanel9.Update();
            Panel_Main.Visible = true;
            Gridview_OrderDeliver.Columns[13].Visible = true;
            Gridview_OrderDeliver.Columns[18].Visible = true;
            UpdatePanel_Main.Update();
            Gridview_Detail.Columns[11].Visible = false;
            Gridview_Detail.Columns[12].Visible = false;
            UpdatePanel_Detail.Update();
            Panel4.Visible = false;
            UpdatePanel3.Update();
            Panel12.Visible = false;
            UpdatePanel11.Update();


        }
        if (Request.QueryString["status"] == "SalesAfterNodeEdit")//客诉追踪环节设置
        {
            Title = "客诉追踪环节设置";
            //this.Panel10.Visible = true;
            //this.Button15.Visible = false;
            //this.UpdatePanel9.Update();
            //this.Panel_Main.Visible = true;
            //this.Gridview_OrderDeliver.Columns[13].Visible = true;
            //this.Gridview_OrderDeliver.Columns[18].Visible = true;
            //this.UpdatePanel_Main.Update();
            //this.Gridview_Detail.Columns[11].Visible = false;
            //this.Gridview_Detail.Columns[12].Visible = false;
            //this.UpdatePanel_Detail.Update();
            Panel4.Visible = true;
            UpdatePanel3.Update();
            Panel12.Visible = true;
            UpdatePanel11.Update();


        }
        if (Request.QueryString["status"] == "SalesAfterTrackEdit")//客诉追踪信息录入
        {
            Title = "客诉追踪信息录入";
            Panel10.Visible = true;
            Button15.Visible = false;
            UpdatePanel9.Update();
            Panel_Main.Visible = true;
            Gridview_OrderDeliver.Columns[13].Visible = true;
            Gridview_OrderDeliver.Columns[18].Visible = false;
            UpdatePanel_Main.Update();
            Gridview_Detail.Columns[11].Visible = false;
            Gridview_Detail.Columns[12].Visible = false;
            Gridview_Detail.Columns[13].Visible = false;
            UpdatePanel_Detail.Update();
            Panel4.Visible = false;
            UpdatePanel3.Update();
            Panel12.Visible = false;
            UpdatePanel11.Update();

        }
        if (Request.QueryString["status"] == "SalesAfterTrackLook")//客诉追踪信息查看
        {
            Title = "客诉追踪信息查看";
            Panel10.Visible = true;
            Button15.Visible = false;
            UpdatePanel9.Update();
            Panel_Main.Visible = true;
            Gridview_OrderDeliver.Columns[13].Visible = true;
            Gridview_OrderDeliver.Columns[18].Visible = true;
            UpdatePanel_Main.Update();
            Gridview_Detail.Columns[11].Visible = false;
            Gridview_Detail.Columns[12].Visible = false;
            Gridview_Detail.Columns[13].Visible = false;
            Gridview_Detail.Columns[16].Visible = false;
            UpdatePanel_Detail.Update();
            Gridview4.Columns[8].Visible = false;
            UpdatePanel13.Update();

        }
        #endregion
        ClosePanel1();
        UpdatePanel14.Update();
    }
    #region 投诉类别
    //检索投诉类别
    protected void SearchTousuSort(object sender, EventArgs e)
    {
        GetCondition_TousuSort();
        BindTousuSort();
    }
    //
    public string GetCondition_TousuSort()
    {
        string conditon;
        string temp = "";
        if (TextBox13.Text != "")
        {
            temp += " and CRMCS_Name like'%" + TextBox13.Text.ToString().Trim() + "%'";
        }
        conditon = temp;
        label19.Text = conditon;
        return conditon;
    }
    //新建投诉类别
    protected void NewTousuSort(object sender, EventArgs e)
    {
        Panel6.Visible = true;
        label17.Text = "新建";
        UpdatePanel5.Update();
    }
    //绑定投诉类别表
    protected void BindTousuSort()
    {
        Gridview_TousuSort.DataSource = st.Select_TousuSort(label19.Text.ToString().Trim());
        Gridview_TousuSort.DataBind();
        UpdatePanel_TousuSort.Update();

    }
    protected void Gridview_TousuSort_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview_TousuSort.BottomPagerRow;


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

        BindTousuSort();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview_TousuSort.PageCount ? Gridview_TousuSort.PageCount - 1 : newPageIndex;
        Gridview_TousuSort.PageIndex = newPageIndex;
        Gridview_TousuSort.DataBind();
    }
    protected void Gridview_TousuSort_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
        if (e.CommandName == "Edit1")
        {
            Panel6.Visible = true;
            label17.Text = "编辑";
            label1.Text = e.CommandArgument.ToString();
            TextBox1.Text = Gridview_TousuSort.Rows[gvr.RowIndex].Cells[1].Text.ToString();
            TextBox2.Text = Gridview_TousuSort.Rows[gvr.RowIndex].Cells[2].Text.ToString();
            UpdatePanel5.Update();
        }
        if (e.CommandName == "Delete1")
        {
            st.Delete_TousuSort(new Guid(e.CommandArgument.ToString()));
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('删除成功！')", true);
            BindTousuSort();
        }
    }
    //提交
    protected void ConfirmNewTousuSort(object sender, EventArgs e)
    {
        if (TextBox1.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('类别名称不可以为空！')", true);
            return;
        }
        string name = TextBox1.Text.ToString().Trim();
        string re = TextBox2.Text.ToString().Trim();
        string man = Session["UserName"].ToString().Trim();
        Guid id = new Guid();
        if (label1.Text != "")
        {
            id = new Guid(label1.Text.ToString().Trim());
        }
        if (label17.Text == "新建")
        {
            st.Insert_TousuSort(name, re, man);
            BindTousuSort();
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('新建成功！')", true);
            Panel6.Visible = false;
            UpdatePanel5.Update();

        }
        else if (label17.Text == "编辑")
        {
            st.Update_TousuSort(id, name, re, man);
            BindTousuSort();
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('编辑成功！')", true);
            Panel6.Visible = false;
            UpdatePanel5.Update();

        }
        TextBox1.Text = "";
        TextBox2.Text = "";

    }
    //关闭
    protected void CloseTousuSort(object sender, EventArgs e)
    {
        Panel6.Visible = false;
        TextBox1.Text = "";
        TextBox2.Text = "";
        UpdatePanel5.Update();
    }
    #endregion
    #region 售后类别
    //新建售后类别
    protected void NewShouhouSort(object sender, EventArgs e)
    {
        Panel9.Visible = true;
        label20.Text = "新建";
        UpdatePanel8.Update();
    }
    //检索售后类别
    protected void SearchShouhouSort(object sender, EventArgs e)
    {
        GetCondition_ShouhouSort();
        BindShouhouSort();
    }
    protected void Gridview_ShouhouSort_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview1.BottomPagerRow;


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

        BindShouhouSort();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview1.PageCount ? Gridview1.PageCount - 1 : newPageIndex;
        Gridview1.PageIndex = newPageIndex;
        Gridview1.DataBind();
    }
    protected void Gridview_ShouhouSort_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
        if (e.CommandName == "Edit2")
        {
            Panel9.Visible = true;
            label20.Text = "编辑";
            label25.Text = e.CommandArgument.ToString();
            TextBox4.Text = Gridview1.Rows[gvr.RowIndex].Cells[1].Text.ToString();
            TextBox5.Text = Gridview1.Rows[gvr.RowIndex].Cells[2].Text.ToString();
            UpdatePanel8.Update();
        }
        if (e.CommandName == "Delete2")
        {
            st.Delete_ShouhouSort(new Guid(e.CommandArgument.ToString()));
            BindShouhouSort();
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('删除成功！')", true);


        }
    }
    //绑定售后类别表
    protected void BindShouhouSort()
    {
        Gridview1.DataSource = st.Select_ShouhouSort(label24.Text.ToString().Trim());
        Gridview1.DataBind();
        UpdatePanel7.Update();
    }
    //
    public string GetCondition_ShouhouSort()
    {
        string conditon;
        string temp = "";
        if (TextBox3.Text != "")
        {
            temp += " and CRMASS_Name like'%" + TextBox3.Text.ToString().Trim() + "%'";
        }
        conditon = temp;
        label24.Text = conditon;
        return conditon;
    }
    //提交
    protected void ConfirmNewShouhouSort(object sender, EventArgs e)
    {
        if (TextBox4.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('类别名称不可以为空！')", true);
            return;
        }
        string name = TextBox4.Text.ToString().Trim();
        string cot = TextBox5.Text.ToString().Trim();
        string man = Session["UserName"].ToString().Trim();
        Guid id = new Guid();
        if (label25.Text != "")
        {
            id = new Guid(label25.Text.ToString().Trim());
        }
        if (label20.Text == "新建")
        {
            st.Insert_ShouhouSort(name, cot, man);
            BindShouhouSort();
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('新建成功！')", true);
            Panel9.Visible = false;
            UpdatePanel8.Update();
        }
        else if (label20.Text == "编辑")
        {
            st.Update_ShouhouSort(id, name, cot, man);
            BindShouhouSort();
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('编辑成功！')", true);
            Panel9.Visible = false;
            UpdatePanel8.Update();
        }
        TextBox4.Text = "";
        TextBox5.Text = "";
    }
    //取消
    protected void CloseShouhouSort(object sender, EventArgs e)
    {
        TextBox4.Text = "";
        TextBox5.Text = "";
        Panel9.Visible = false;
        UpdatePanel8.Update();
    }
    #endregion
    #region 客诉主表
    //检索客诉主表
    protected void SearchReturn(object sender, EventArgs e)
    {
        GetCondition_Kesu();
        BindKesuMain();
    }
    //新建客诉主表
    protected void NewKesu(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        UpdatePanel_NewKesu.Update();
    }
    //绑定客诉主表
    protected void BindKesuMain()
    {
        Gridview_OrderDeliver.DataSource = st.Select_ShouhouMain(label11.Text.ToString().Trim());
        Gridview_OrderDeliver.DataBind();
        UpdatePanel_Main.Update();
    }
    //条件获取
    public string GetCondition_Kesu()
    {
        string conditon;
        string temp = "";
        if (TextBox15.Text != "")
        {
            temp += " and d.CRMCIF_Name like'%" + TextBox15.Text.ToString().Trim() + "%'";
        }
        if (DropDownList3.SelectedValue != "")
        {
            temp += " and c.CRMASS_ID like'%" + DropDownList3.SelectedValue.ToString().Trim() + "%'";
        }
        if (DropDownList2.SelectedValue != "")
        {
            temp += " and b.CRMCS_ID like'%" + DropDownList2.SelectedValue.ToString().Trim() + "%'";
        }
        if (TextBox18.Text != "" && TextBox19.Text != "")
        {
            temp += " and a.CRMCCM_InputTime between'" + TextBox18.Text.ToString().Trim() + "' and '" + TextBox19.Text.ToString().Trim() + "'";
        }
        if (DropDownList7.SelectedValue != "请选择")
        {
            temp += " and a.CRMCCM_State='" + DropDownList7.SelectedValue.ToString() + "'";
        }
        conditon = temp;
        label11.Text = conditon;
        return conditon;
    }
    //选择客户
    protected void SearchCustom(object sender, EventArgs e)
    {
        Panel1_SearchCus.Visible = true;
        UpdatePanel_SearchCus.Update();
        Panel1_Custom.Visible = true;
        Gridview2.DataSource = st.Select_Kehu(label41.Text.ToString());
        Gridview2.DataBind();
        UpdatePanel_Custom.Update();
    }
    //确认新建客诉主表
    protected void ConfirmNewKesuMain(object sender, EventArgs e)
    {
        Guid id = new Guid(label44.Text.ToString());
        Guid tousuID = new Guid(DropDownList4.SelectedValue.ToString());
        //Guid shouhouID=new Guid(this.DropDownList5.SelectedValue.ToString());
        int day = Convert.ToInt32(TextBox20.Text.ToString());
        string re = TextBox21.Text.ToString().Trim();
        string man = Session["UserName"].ToString();
        st.Insert_KesuMain(id, tousuID, day, re, man);
        BindKesuMain();
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('新建成功！')", true);
        string remind = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "提交了客户-" + TextBox16.Text.ToString() + "的客户投诉，请进行分析并及时填写分析结果！";
        string sErr = RTXhelper.Send(remind, "客诉分析结果录入");
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", "alert('" + sErr + "')", true);
        }
        Panel1.Visible = false;
        UpdatePanel_NewKesu.Update();

    }
    //取消新建客诉主表
    protected void CloseNewKesuMain(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        UpdatePanel_NewKesu.Update();
    }
    //检索客户
    protected void SearchCustomer(object sender, EventArgs e)
    {
        if (TextBox6.Text != "")
        {
            label41.Text = " and CRMCIF_Name like'%" + TextBox6.Text.ToString().Trim() + "%'";
        }
        Gridview2.DataSource = st.Select_Kehu(label41.Text.ToString());
        Gridview2.DataBind();
        UpdatePanel_Custom.Update();
    }
    //取消检索客户
    protected void CloseSearchCustomer(object sender, EventArgs e)
    {
        Panel1_SearchCus.Visible = false;
        UpdatePanel_SearchCus.Update();
        Panel1_Custom.Visible = false;
        UpdatePanel_Custom.Update();
    }
    //绑定售后类别
    protected void BindDrop_ShouhouSort3()
    {

        DropDownList3.DataSource = st.Select_ShouhouSort("");
        DropDownList3.DataTextField = "CRMASS_Name";
        DropDownList3.DataValueField = "CRMASS_ID";

        DropDownList3.DataBind();
        DropDownList3.Items.Insert(0, new ListItem("选择类别", ""));


    }
    protected void BindDrop_ShouhouSort5()
    {

        DropDownList5.DataSource = st.Select_ShouhouSort("");
        DropDownList5.DataTextField = "CRMASS_Name";
        DropDownList5.DataValueField = "CRMASS_ID";
        DropDownList5.DataBind();
        DropDownList5.Items.Insert(0, new ListItem("选择类别", ""));


    }
    //绑定投诉类别
    protected void BindDrop_Tousu2()
    {

        DropDownList2.DataSource = st.Select_TousuSort("");
        DropDownList2.DataTextField = "CRMCS_Name";
        DropDownList2.DataValueField = "CRMCS_ID";
        DropDownList2.DataBind();
        DropDownList2.Items.Insert(0, new ListItem("选择类别", ""));


    }
    protected void BindDrop_Tousu4()
    {

        DropDownList4.DataSource = st.Select_TousuSort("");
        DropDownList4.DataTextField = "CRMCS_Name";
        DropDownList4.DataValueField = "CRMCS_ID";
        DropDownList4.DataBind();
        DropDownList4.Items.Insert(0, new ListItem("选择类别", ""));


    }
    protected void Gridview_OrderDeliver_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview_OrderDeliver.BottomPagerRow;


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

        BindKesuMain();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview_OrderDeliver.PageCount ? Gridview_OrderDeliver.PageCount - 1 : newPageIndex;
        Gridview_OrderDeliver.PageIndex = newPageIndex;
        Gridview_OrderDeliver.DataBind();
    }
    protected void Gridview_OrderDeliver_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
        if (e.CommandName == "Detail1")
        {
            label34.Text = e.CommandArgument.ToString();
            label70.Text = Gridview_OrderDeliver.Rows[gvr.RowIndex].Cells[4].Text.ToString();
            Panel1_Detail.Visible = true;
            UpdatePanel_Detail.Update();
            Gridview_Detail.DataSource = st.Select_ShouhouDetail(new Guid(e.CommandArgument.ToString()));
            Gridview_Detail.DataBind();
            UpdatePanel_Detail.Update();
        }
        if (e.CommandName == "Delete3")
        {
            st.Delete_KesuMain(new Guid(e.CommandArgument.ToString()));
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('删除成功！')", true);
            BindKesuMain();
        }
        if (e.CommandName == "Check1")
        {
            Panel_ADDCheck.Visible = true;
            Label33.Text = e.CommandArgument.ToString();
            TextBox_AddMan.Text = Session["UserName"].ToString().Trim();
            TextBox_Addtime.Text = DateTime.Now.ToShortDateString();
            UpdatePanel_ADDCheck.Update();
        }
        if (e.CommandName == "NewD")
        {
            label8.Text = e.CommandArgument.ToString();
            Panel2.Visible = true;
            UpdatePanel1.Update();
        }
    }
    protected void Gridview_OrderDeliver_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;
            if ((DateTime.Parse(e.Row.Cells[6].Text.ToString().Trim()).AddDays(Convert.ToInt32(e.Row.Cells[7].Text.ToString().Trim()))) <= DateTime.Now && drv["CRMCCM_State"].ToString().Trim() != "审核通过")
            {
                e.Row.BackColor = Color.SkyBlue;
            }

            if (drv["CRMCCM_State"].ToString().Trim() != "已分析")
            {
                e.Row.Cells[18].Enabled = false;
            }
            if (drv["CRMCCM_State"].ToString().Trim() != "已提交")
            {
                e.Row.Cells[14].Enabled = false;
                e.Row.Cells[15].Enabled = false;
            }
        }
    }
    protected void Gridview_OrderDeliver_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Gridview_OrderDeliver.Rows.Count; i++)
        {
            for (int j = 0; j < Gridview_OrderDeliver.Rows[i].Cells.Count; j++)
            {
                Gridview_OrderDeliver.Rows[i].Cells[j].ToolTip = Gridview_OrderDeliver.Rows[i].Cells[j].Text;
                if (Gridview_OrderDeliver.Rows[i].Cells[j].Text.Length > 20)
                {
                    Gridview_OrderDeliver.Rows[i].Cells[j].Text = Gridview_OrderDeliver.Rows[i].Cells[j].Text.Substring(0, 20) + "...";
                }
            }
        }
    }
    protected void Gridview2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
        if (e.CommandName == "Check2")
        {
            string id = e.CommandArgument.ToString();
            label44.Text = id;
            TextBox16.Text = Gridview2.Rows[gvr.RowIndex].Cells[1].Text.ToString().Trim().Replace("&nbsp;", "");
            UpdatePanel_NewKesu.Update();
            Panel1_Custom.Visible = false;
            Panel1_SearchCus.Visible = false;
            UpdatePanel_SearchCus.Update();
            UpdatePanel_Custom.Update();
        }

    }
    protected void Gridview2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview2.BottomPagerRow;


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


        Gridview2.DataSource = st.Select_Kehu(label41.Text.ToString());
        Gridview2.DataBind();
        UpdatePanel_Custom.Update();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview2.PageCount ? Gridview2.PageCount - 1 : newPageIndex;
        Gridview2.PageIndex = newPageIndex;
        Gridview2.DataBind();
    }
    #endregion
    #region 客诉详细表

    protected void Gridview_Detail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview_Detail.BottomPagerRow;


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


        Gridview_Detail.DataSource = st.Select_ShouhouDetail(new Guid(label34.Text));
        Gridview_Detail.DataBind();
        UpdatePanel_Detail.Update();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview_Detail.PageCount ? Gridview_Detail.PageCount - 1 : newPageIndex;
        Gridview_Detail.PageIndex = newPageIndex;
        Gridview_Detail.DataBind();
    }
    protected void Gridview_Detail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete4")
        {
            st.Delete_Kesu_Detail(new Guid(e.CommandArgument.ToString()));
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('删除成功！')", true);
            Gridview_Detail.DataSource = st.Select_ShouhouDetail(new Guid(label34.Text));
            Gridview_Detail.DataBind();
            UpdatePanel_Detail.Update();
        }
        if (e.CommandName == "Fenxi")
        {
            label3.Text = e.CommandArgument.ToString();
            Label46.Text = e.CommandArgument.ToString();
            UpdatePanel_upload.Update();
            Panel111.Visible = true;
            UpdatePanel_Tuihuanhuo.Update();
        }
        if (e.CommandName == "UP1")
        {
            
            ShowPanel();
            Label46.Text = e.CommandArgument.ToString();
            UpdatePanel_upload.Update();
            

        }
        if (e.CommandName == "TrackLook")
        {
            label57.Text = " and CRMCCD_ID ='"+ e.CommandArgument.ToString()+"'";
            Panel14.Visible = true;
            BindTrack();

            UpdatePanel13.Update();

        }
        if (e.CommandName == "TrackEdit")
        {
            label53.Text = e.CommandArgument.ToString();
            label57.Text = " and CRMCCT_ID ='" + e.CommandArgument.ToString() + "'";
            label59.Text = "新建";
            Panel14.Visible = true;
            BindTrack();
            UpdatePanel13.Update();
            Panel13.Visible = true;
            UpdatePanel12.Update();
            BindDropdownlist1();

        }

    }

    //录入分析结果
    protected void ComfirmTuihuanhuo(object sender, EventArgs e)
    {
        Guid id = new Guid(label3.Text.ToString());
        string re = TextBox7.Text.ToString().Trim();
        Guid rid = new Guid(DropDownList5.SelectedValue.ToString());
        st.Update_ShouhouDetail(id, re, rid);
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('录入成功！')", true);
        Gridview_Detail.DataSource = st.Select_ShouhouDetail(new Guid(label34.Text));
        Gridview_Detail.DataBind();
        UpdatePanel_Detail.Update();
        Panel111.Visible = false;
        TextBox7.Text = "";
        UpdatePanel_Tuihuanhuo.Update();
        string remind = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "提交了新的客诉分析结果，请对状态为已分析的客诉单进行审核！";
        string sErr = RTXhelper.Send(remind, "客诉分析结果审核");
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
        }
        BindKesuMain();
    }
    //取消录入
    protected void CloseTuihuanhuo(object sender, EventArgs e)
    {
        Panel111.Visible = false;
        TextBox7.Text = "";
        UpdatePanel_Tuihuanhuo.Update();
    }
    //审核通过
    protected void Check_OK(object sender, EventArgs e)
    {
        string result = "审核通过";
        string man = Session["UserName"].ToString().Trim();
        string op = TextBox_AddOpinion.Text.ToString();
        Guid id = new Guid(Label33.Text.ToString());
        st.Update_ShouhouMain_Check(id, result, man, op);
        Gridview_Detail.DataSource = st.Select_ShouhouDetail(new Guid(Label33.Text.ToString()));
        Gridview_Detail.DataBind();
        UpdatePanel_Detail.Update();
        Panel_ADDCheck.Visible = false;
        UpdatePanel_ADDCheck.Update();
        TextBox_AddOpinion.Text = "";
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('审核通过！')", true);
        BindKesuMain();

    }
    //审核驳回
    protected void Check_NotOK(object sender, EventArgs e)
    {
        string result = "审核驳回";
        string man = Session["UserName"].ToString().Trim();
        string op = TextBox_AddOpinion.Text.ToString();
        Guid id = new Guid(Label33.Text.ToString());
        if (op == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('驳回时必须填写驳回意见！')", true);
            return;
        }
        st.Update_ShouhouMain_Check(id, result, man, op);
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('审核驳回成功！')", true);
        Panel_ADDCheck.Visible = false;
        UpdatePanel_ADDCheck.Update();
        Gridview_Detail.DataSource = st.Select_ShouhouDetail(new Guid(Label33.Text.ToString()));
        Gridview_Detail.DataBind();
        UpdatePanel_Detail.Update();
        TextBox_AddOpinion.Text = "";
        BindKesuMain();
        string remind = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "驳回了你的客诉分析结果，请对状态为审核驳回的客诉单重新提交分析结果！";
        string sErr = RTXhelper.Send(remind, "客诉分析结果录入");
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
        }
    }
    //关闭审核
    protected void Check_Canel(object sender, EventArgs e)
    {
        Panel_ADDCheck.Visible = false;
        UpdatePanel_ADDCheck.Update();
        TextBox_AddOpinion.Text = "";
    }
    //选择订单
    protected void SearchOrder(object sender, EventArgs e)
    {
        Panel11.Visible = true;
        Panel3.Visible = true;
        UpdatePanel2.Update();
        UpdatePanel10.Update();
    }
    //绑定订单
    protected void BindOrder()
    {
        Gridview_Order.DataSource = st.Select_Dingdan(label16.Text.ToString());
        Gridview_Order.DataBind();
        UpdatePanel2.Update();
    }
    //确认提交详细
    protected void ConfirmNewKesuDetail(object sender, EventArgs e)
    {
        if (label43.Text == "" || label8.Text == "" || TextBox9.Text == "" || TextBox10.Text == "" || TextBox11.Text == "" || TextBox22.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('所有项都必须填写！')", true);
            return;
        }
        Guid id = new Guid(label43.Text.ToString());
        Guid id1 = new Guid(label8.Text.ToString());//Mid
        string batch = TextBox9.Text.ToString();
        int num = Convert.ToInt32(TextBox10.Text.ToString());
        int losenum = Convert.ToInt32(TextBox11.Text.ToString());
        string re = DropDownList6.SelectedValue.ToString();
        string condition = TextBox22.Text.ToString();
        st.Insert_KesuDetail(id, id1, batch, num, losenum, re, condition);
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('添加成功！')", true);
        Gridview_Detail.DataSource = st.Select_ShouhouDetail(new Guid(label8.Text.ToString()));
        Gridview_Detail.DataBind();
        UpdatePanel_Detail.Update();
        Panel2.Visible = false;
        UpdatePanel1.Update();
    }
    //取消详细
    protected void CloseNewKesuDetail(object sender, EventArgs e)
    {
        Panel2.Visible = false;
        UpdatePanel1.Update();
    }
    //检索订单
    protected void SearchSMOrder(object sender, EventArgs e)
    {
        GetCondition_Order();
        BindOrder();
    }
    public string GetCondition_Order()
    {
        string conditon;
        string temp = "";
        if (TextBox12.Text != "")
        {
            temp += " and CRMCIF_Name like'%" + TextBox12.Text.ToString().Trim() + "%'";
        }
        if (TextBox23.Text != "")
        {
            temp += " and SMSO_ComOrderNum like'%" + TextBox23.Text.ToString().Trim() + "%'";
        }
        conditon = temp;
        label16.Text = conditon;
        return conditon;
    }
    //选择客户
    protected void SearchCustom1(object sender, EventArgs e)
    {
        Panel1_SearchCus.Visible = true;
        UpdatePanel_SearchCus.Update();
        Panel1_Custom.Visible = true;
        Gridview2.DataSource = st.Select_Kehu("");
        Gridview2.DataBind();
        UpdatePanel_Custom.Update();
    }
    //关闭检索订单
    protected void CloseSMorder(object sender, EventArgs e)
    {
        Panel11.Visible = false;
        UpdatePanel10.Update();
        Panel3.Visible = false;
        UpdatePanel2.Update();
    }
    //Order
    protected void Gridview_Order_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview_Order.BottomPagerRow;


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


        BindOrder();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview_Order.PageCount ? Gridview_Order.PageCount - 1 : newPageIndex;
        Gridview_Order.PageIndex = newPageIndex;
        Gridview_Order.DataBind();
    }
    protected void Gridview_Order_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow gvr = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
        if (e.CommandName == "Check2")
        {
            label43.Text = e.CommandArgument.ToString();
            TextBox8.Text = Gridview_Order.Rows[gvr.RowIndex].Cells[1].Text.ToString();
            UpdatePanel1.Update();
            Panel3.Visible = false;
            UpdatePanel2.Update();
            Panel11.Visible = false;
            UpdatePanel10.Update();
        }
    }
    protected void Gridview_Detail_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Gridview_Detail.Rows.Count; i++)
        {
            for (int j = 0; j < Gridview_Detail.Rows[i].Cells.Count; j++)
            {
                Gridview_Detail.Rows[i].Cells[j].ToolTip = Gridview_Detail.Rows[i].Cells[j].Text;
                if (Gridview_Detail.Rows[i].Cells[j].Text.Length > 20)
                {
                    Gridview_Detail.Rows[i].Cells[j].Text = Gridview_Detail.Rows[i].Cells[j].Text.Substring(0, 20) + "...";
                }
            }
        }
    }
    #endregion
    private void ShowPanel()//显示上传实验报告框
    {
        string script = "document.getElementById('Panel99').style.display='';";
        ScriptManager.RegisterStartupScript(Page, GetType(), "ShowPanel", script, true);
    }

    private void ClosePanel()//关闭上传实验报告框
    {
        string script = "document.getElementById('Panel99').style.display='none';";
        ScriptManager.RegisterStartupScript(Page, GetType(), "ClosePanel", script, true);
    }

    protected void cancel_upload_Click(object sender, EventArgs e)
    {
        ClosePanel();
        UpdatePanel_upload.Update();
    }

    protected void ok_upload_Click(object sender, EventArgs e)
    {
        string fileExrensio = Path.GetExtension(FileUpload1.FileName).ToLower();//ToLower转化为小写,获得扩展名
        string UploadURL = Server.MapPath("~/file/");//上传的目录
        string fullname = FileUpload1.FileName;//上传文件的原名
        string newname = DateTime.Now.ToString("yyyyMMddhhmmss");//上传文件重命名
        if (FileUpload1.PostedFile.FileName != null)
        {
            if (fileExrensio == ".doc" || fileExrensio == ".docx" || fileExrensio == ".pdf" || fileExrensio == ".xls" || fileExrensio == ".xlsx" || fileExrensio == ".txt")//判断文件扩展名
            {
                try
                {
                    if (!Directory.Exists(UploadURL))//判断文件夹是否已经存在
                    {
                        Directory.CreateDirectory(UploadURL);//创建文件夹
                    }
                    FileUpload1.PostedFile.SaveAs(UploadURL + newname + fullname);//保存上传的文件
                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel_upload, GetType(), "aa", "alert('上传失败!')", true);
                    return;
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel_upload, GetType(), "aa", "alert('不支持此文件格式!')", true);
                return;
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_upload, GetType(), "aa", "alert('请选择文件!')", true);
            return;
        }

        string filePath = "file/" + newname + fullname;
        Guid TTD_DetailID = new Guid(Label46.Text.ToString());
        string TTD_IsUploaded = "是";
        string TTD_RepRoute = filePath;
        st.Update_KesuDetail(TTD_DetailID, filePath);
        ClosePanel();
        UpdatePanel_upload.Update();
        Label73.Text = filePath;
        UpdatePanel_Tuihuanhuo.Update();
        //Gridview_Detail.DataSource = st.Select_ShouhouDetail(new Guid(label8.Text.ToString()));
        //Gridview_Detail.DataBind();
        //UpdatePanel_Detail.Update();

    }




    //检索追踪环节基础
    protected void SearchNode(object sender, EventArgs e)
    {
        string temp = "and CRMCTN_Name like '%" + TextBox14.Text.ToString() + "%'";
        label52.Text = temp;
        BindNode();
    }
    protected void BindNode()
    {
        Gridview3.DataSource = st.Select_Node(label52.Text.ToString());
        Gridview3.DataBind();
        UpdatePanel11.Update();
    }
    protected void NewNode(object sender, EventArgs e)
    {
        Panel15.Visible = true;
        label65.Text = "新建";
        TextBox24.Text = "";
        TextBox25.Text = "";
        UpdatePanel15.Update();

    }
    //提交新node
    protected void ConfirmNode(object sender, EventArgs e)
    {
        
    }
    protected void CloseNewNode(object sender, EventArgs e)
    {
        Panel13.Visible = false;
        TextBox24.Text = "";
        TextBox17.Text = "";
        UpdatePanel12.Update();
        BindNode();
    }
    protected void BindTrack()
    {
        Gridview4.DataSource = st.Select_Track(label57.Text.ToString());
        Gridview4.DataBind();
        UpdatePanel13.Update();

    }
    protected void ok_upload_Click1(object sender, EventArgs e)
    {
        string fileExrensio = Path.GetExtension(FileUpload2.FileName).ToLower();//ToLower转化为小写,获得扩展名
        string UploadURL = Server.MapPath("~/file/");//上传的目录
        string fullname = FileUpload2.FileName;//上传文件的原名
        string newname = DateTime.Now.ToString("yyyyMMddhhmmss");//上传文件重命名
        if (FileUpload2.PostedFile.FileName != null)
        {
            if (fileExrensio == ".doc" || fileExrensio == ".docx" || fileExrensio == ".pdf" || fileExrensio == ".xls" || fileExrensio == ".xlsx" || fileExrensio == ".txt")//判断文件扩展名
            {
                try
                {
                    if (!Directory.Exists(UploadURL))//判断文件夹是否已经存在
                    {
                        Directory.CreateDirectory(UploadURL);//创建文件夹
                    }
                    FileUpload2.PostedFile.SaveAs(UploadURL + newname + fullname);//保存上传的文件
                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel_upload, GetType(), "aa", "alert('上传失败!')", true);
                    return;
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel_upload, GetType(), "aa", "alert('不支持此文件格式!')", true);
                return;
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_upload, GetType(), "aa", "alert('请选择文件!')", true);
            return;
        }
        string filePath = "file/" + newname + fullname;
        Label68.Text = filePath;
        UpdatePanel12.Update();
        ClosePanel();
        UpdatePanel14.Update();

    }
    
    protected void ComfirmNode(object sender, EventArgs e)
    {
        string name = TextBox25.Text.ToString();
        string note = TextBox24.Text;
        if (label65.Text == "新建")
        {
            st.Insert_Node(name, note);
        }
        else if (label65.Text == "修改")
        {
            Guid id = new Guid(label62.Text.ToString());
            st.Update_Node(id, name, note);
        }

        Panel15.Visible = false;
        TextBox24.Text = "";
        TextBox25.Text = "";
        UpdatePanel15.Update();
        BindNode();
        ScriptManager.RegisterClientScriptBlock(UpdatePanel_upload, GetType(), "aa", "alert('提交成功!')", true);

    }
    protected void CloseNode(object sender, EventArgs e)
    {
        Panel15.Visible = false;
        TextBox25.Text = "";
        TextBox24.Text = "";
        UpdatePanel15.Update();

    }
    private void ShowPane1l()//显示上传实验报告框
    {
        string script = "document.getElementById('panel98').style.display='';";
        ScriptManager.RegisterStartupScript(Page, GetType(), "ShowPanel1", script, true);
    }

    private void ClosePanel1()//关闭上传实验报告框
    {
        string script = "document.getElementById('panel98').style.display='none';";
        ScriptManager.RegisterStartupScript(Page, GetType(), "ClosePanel1", script, true);
    }
    protected void OpenUploadTrack(object sender, EventArgs e)
    {
        Label56.Text = label53.Text;
        ShowPane1l();
        UpdatePanel14.Update();
    }
    protected void cancel_upload_Click1(object sender, EventArgs e)
    {
        ClosePanel1();
        UpdatePanel14.Update();

    }
    protected void BindDropdownlist1()
    {
        DropDownList1.DataSource = st.Select_Node("");
        DropDownList1.DataTextField = "CRMCTN_Name";
        DropDownList1.DataValueField = "CRMCTN_ID";
        DropDownList1.DataBind();
        UpdatePanel12.Update();
        for (int i = 0; i < DropDownList1.Items.Count; i++)
        {
            //当然你可以在这里为每个item写上其它的显示的内容。  
            DropDownList1.Items[i].Attributes.Add("title", DropDownList1.Items[i].Text);
            if (DropDownList1.Items[i].Text.Length > 20)
             {
                 DropDownList1.Items[i].Text = DropDownList1.Items[i].Text.Substring(0, 20).ToString() + "…";
             }
        }  
        //foreach (ListItem item in DropDownList1.Items)
        //{
        //    DropDownList1.ToolTip = item.Text.ToString();
        //    //item.Attributes.Add("Title", item.Text);   // Add the tooltip for every item in the contact persons  
        //    if (item.Text.Length > 20)
        //    {
        //        item.Text = item.Text.Substring(0, 20).ToString() + "…";
        //    }
            
        //}
        

    }
    protected void ConfirmTrack(object sender, EventArgs e)
    {
        Guid CTNID = new Guid(DropDownList1.SelectedValue.ToString());
        Guid ccdid = new Guid(label53.Text);
        string reason = TextBox26.Text.ToString();
        string remark = TextBox17.Text.ToString();


        #region shangchuan
        string path = Label68.Text.ToString();
        string uploadis;
        string UploadURL = Server.MapPath("~/file/");//上传的目录
        string man = Session["UserName"].ToString();
        if (label59.Text == "新建")
        {
            
            if (Label68.Text != "")
            {
                //try
                //{
                //    if (!System.IO.Directory.Exists(UploadURL))//判断文件夹是否已经存在
                //    {
                //        System.IO.Directory.CreateDirectory(UploadURL);//创建文件夹
                //    }
                //    FileUpload2.PostedFile.SaveAs(Label68.Text.ToString().Trim());//保存上传的文件
                    uploadis = "是";
                //}
                //catch
                //{
                //    ScriptManager.RegisterClientScriptBlock(UpdatePanel_upload, this.GetType(), "aa", "alert('上传失败!')", true);
                //    return;
                //}
            }
            else
            {
                uploadis = "否";
            }
            st.Insert_Track(ccdid, CTNID, reason, remark, path, uploadis, man);
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_upload, GetType(), "aa", "alert('提交成功!')", true);

        }
        if (label59.Text == "修改")
        {
            Guid id = new Guid(label53.Text.ToString());
            if (Label68.Text != "")
            {
               
                    uploadis = "是";
                }
             
            else
            {
                uploadis = "否";
            }
            st.Update_Track(ccdid, CTNID, reason, remark, path, uploadis, man,id);
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_upload, GetType(), "aa", "alert('提交成功!')", true);
        }
        //st.Update_KesuDetail(TTD_DetailID, filePath);
        Label68.Text = "";
        TextBox26.Text = "";
        TextBox17.Text = "";
        ClosePanel1();
        UpdatePanel14.Update();
        BindTrack();
        Panel13.Visible = false;
        UpdatePanel12.Update();

        #endregion
    }
    protected void Gridview3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview3.BottomPagerRow;


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

        BindNode();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview3.PageCount ? Gridview3.PageCount - 1 : newPageIndex;
        Gridview3.PageIndex = newPageIndex;
        Gridview3.DataBind();
    }
    protected void Gridview3_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       
        if (e.CommandName == "Edit1")
        { 
            string temp= " and CRMCTN_ID ='"+e.CommandArgument.ToString()+"'";
            DataSet ds = st.Select_Node(temp);
            DataTable dt = ds.Tables[0];
            TextBox25.Text = dt.Rows[0][1].ToString();
            TextBox24.Text = dt.Rows[0][2].ToString();
            label62.Text = e.CommandArgument.ToString();
            Panel15.Visible = true;
            label65.Text = "修改";
            UpdatePanel15.Update();
        }
        if (e.CommandName == "Delete1")
        {
            st.Delete_Node(new Guid(e.CommandArgument.ToString()));
            BindNode();
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_upload, GetType(), "aa", "alert('删除成功!')", true);

        }

    }
    protected void Gridview4_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview4.BottomPagerRow;


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

        BindTrack();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview4.PageCount ? Gridview4.PageCount - 1 : newPageIndex;
        Gridview4.PageIndex = newPageIndex;
        Gridview4.DataBind();
    }
    protected void Gridview4_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      
        if (e.CommandName == "Edit1")
        {
            string temp = " and CRMCCT_ID ='" + e.CommandArgument.ToString() + "'";
            DataSet ds = st.Select_Track(temp);
            DataTable dt = ds.Tables[0];
            BindDropdownlist1();
            DropDownList1.SelectedValue = dt.Rows[0][2].ToString();
            Label68.Text = dt.Rows[0][5].ToString();
            TextBox26.Text = dt.Rows[0][3].ToString();
            TextBox17.Text = dt.Rows[0][4].ToString();
            label53.Text = e.CommandArgument.ToString();
            Panel13.Visible = true;
            label59.Text = "修改";
            UpdatePanel12.Update();
        }
    }
    protected void Gridview4_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Gridview4.Rows.Count; i++)
        {
            for (int j = 0; j < Gridview4.Rows[i].Cells.Count; j++)
            {
                Gridview4.Rows[i].Cells[j].ToolTip = Gridview4.Rows[i].Cells[j].Text;
                if (Gridview4.Rows[i].Cells[j].Text.Length > 20)
                {
                    Gridview4.Rows[i].Cells[j].Text = Gridview4.Rows[i].Cells[j].Text.Substring(0, 20) + "...";
                }
            }
        }
    }
    protected void Gridview3_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Gridview3.Rows.Count; i++)
        {
            for (int j = 0; j < Gridview3.Rows[i].Cells.Count; j++)
            {
                Gridview3.Rows[i].Cells[j].ToolTip = Gridview3.Rows[i].Cells[j].Text;
                if (Gridview3.Rows[i].Cells[j].Text.Length > 20)
                {
                    Gridview3.Rows[i].Cells[j].Text = Gridview3.Rows[i].Cells[j].Text.Substring(0, 20) + "...";
                }
            }
        }
    }

    protected void CloseTrack(object sender, EventArgs e)
    {
        Panel13.Visible = false;
        Label68.Text = "";
        TextBox26.Text = "";
        TextBox17.Text = "";
        UpdatePanel12.Update();
        ClosePanel1();
        UpdatePanel14.Update();
    }
    protected void Gridview_Detail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;
            if (label70.Text=="审核通过")
            {
                e.Row.Cells[14].Enabled = true;
            }
            else if (label70.Text == "审核驳回")
            {
                e.Row.Cells[14].Enabled = false;
            }

        }
    }
    protected void LinkButton1_Click1(object sender, EventArgs e)
    {
        ShowPanel();
        UpdatePanel_upload.Update();
    }
}
