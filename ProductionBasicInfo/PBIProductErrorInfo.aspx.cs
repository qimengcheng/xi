/* ==============================================================================
 * 类名称：ProductionBasicInfo_PBIProductErrorInfo 
 * 类的作用描述:这个类是页面异常选项维护的后台页面，主要实现页面的后台逻辑
 * 创建人：bush2582
 * 创建时间：1/9/2014 15:53
 * 修改人：
 * 修改时间：
 * 修改备注：
 * @version 1.0
 * ==============================================================================*/
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
/// <summary>
///这个页面主要的功能是实现各种页面事件响应函数，并将所有的数据请求和业务逻辑转发给BLL层的类
/// </summary>
public partial class ProductionBasicInfo_PBIProductErrorInfo : PageCommon//System.Web.UI.Page
{
    ProSeriesInfo_ProTypeL ppl = new ProSeriesInfo_ProTypeL();
    ErrorRelevantL erl = new ErrorRelevantL();
    public DataTable GetDs()
    {
        string condition;
        condition = this.DropDownList1.SelectedItem.Text.Trim() == "所有工序" ? " and 1=1 " : " and PBC_Name like '%" + this.DropDownList1.SelectedItem.Text.Trim() + "%'";
        DataSet ds012 = ppl.S_ErrorPhenomenonOptionDetail(this.Label1.Text.Trim(), condition);
        return ds012.Tables[0];
    }
    public DataTable GetDs2()
    {

        DataSet ds012 = erl.S_WOError_Rework_PBCraft();
        return ds012.Tables[0];
    }
    /* ===================================数据成员定义区=========================================*/
    private ProSeriesInfo_ProErrorTypeL mProSeriesInfo_ProErrorTypeL = new ProSeriesInfo_ProErrorTypeL();
    private ProSeriesInfo_ProErrorSeriesInfo mProSeriesInfo_ProErrorSeriesInfo = new ProSeriesInfo_ProErrorSeriesInfo(System.Guid.Empty, "", "", "");
    private static bool BlInto_S_Search;//标志位，用于标志是否是在检索状态下
    private static bool BlIs_Close_ADD;//标志位，用于检测是否要使新增模块不显示
    private static int IntCurrentPageIndex;
    protected List<CollectWebControl> mCollectWebControlListLook;
    protected List<CollectWebControl> mCollectWebControlListMaintain;

    /* =======================================================================================*/


    /* ===================================方法定义区===========================================*/


    /// <summary>
    /// 函数名：Is_Search
    /// 作者：bush2582
    /// 作用：用来提供在查询状态下的对GridView的绑定
    /// </summary>
    private void Is_Search()
    {
        if (BlInto_S_Search == true)
        {
            base.Bind_Updata(this.GridViewShowErrorOptionList,
                       mProSeriesInfo_ProErrorTypeL.S_SearchErrorOption(this.Asp_Input_Search_text.Text.ToString().Trim()),
                       UpdatePanel_List_ErrorOption);
        }
        else
        {
            base.Bind_Updata(this.GridViewShowErrorOptionList, mProSeriesInfo_ProErrorTypeL.SList_ProErrorSeries(), UpdatePanel_List_ErrorOption);
        }
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        //检查权限
        //if (base.CheckRoleCanMaintain("异常原因现象选项维护") == false)
        //{
        //    if (base.CheckRoleCanLook("异常原因现象选项查看") == true)
        //    {
        //        //令几个控件不能显示
        //        GridViewShowErrorOptionList.Columns[3].Visible = false;
        //        GridViewShowErrorOptionList.Columns[4].Visible = false;
        //        Asp_Input_AddNewErrorOption.Visible = false;
        //    }
        //    else
        //    {
        //        Response.Redirect("~/Default.aspx");
        //    }
        //}

        mCollectWebControlListLook = new List<CollectWebControl>();
        mCollectWebControlListMaintain = new List<CollectWebControl>();

        mCollectWebControlListLook.Add(new CollectWebControl(GridViewShowErrorOptionList.Columns[3]));
        mCollectWebControlListLook.Add(new CollectWebControl(GridViewShowErrorOptionList.Columns[4]));
        mCollectWebControlListLook.Add(new CollectWebControl(Asp_Input_AddNewErrorOption));

        UserStat mProductErrorInfoStatLook = new ProductErrorInfoLook(mCollectWebControlListLook);
        UserStat mProductErrorInfoStatMaintain = new ProductErrorInfoStatMaintain(mCollectWebControlListMaintain);
        UserRole mUserRole = new UserRole(mProductErrorInfoStatMaintain, this);

        mProductErrorInfoStatMaintain.SetNextStat(mProductErrorInfoStatLook, mUserRole);
        mUserRole.CheckRole();


        if (!Page.IsPostBack)//保证页面第一次加载的时候会加载数据库信心，在更新数据的时候不会再次加载数据
        {
            //Bind_Updata(GridViewShowErrorOptionList, mProSeriesInfo_ProErrorTypeL.SList_ProErrorSeries(), UpdatePanel_List_ErrorOption);
            base.Bind_Updata(GridViewShowErrorOptionList, mProSeriesInfo_ProErrorTypeL.SList_ProErrorSeries(), UpdatePanel_List_ErrorOption);
            //初始化成员数据变量；
            BlInto_S_Search = false;
            BlIs_Close_ADD = false;
            IntCurrentPageIndex = 0;
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


    public void databind_detail()
    {
        string condition;
        condition = this.DropDownList1.SelectedItem.Text.Trim() == "所有工序" ? " and 1=1 " : " and PBC_Name like '%" + this.DropDownList1.SelectedItem.Text.Trim() + "%'";
        GridView_Parameter.DataSource = ppl.S_ErrorPhenomenonOptionDetail(this.Label1.Text.Trim(), condition);
        GridView_Parameter.DataBind();
        UpdatePanel_Parameter.Update();

    }

    //页面事件响应函数


    /// <summary>
    /// 函数名：GridViewShowErrorOptionList_RowUpdating
    /// 作用：GridView的更新响应函数，用于更新页面的数据
    /// 作者：bush2582
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewShowErrorOptionList_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //获取要被更新的行的数据
        mProSeriesInfo_ProErrorSeriesInfo.ProErrorID = new Guid(GridViewShowErrorOptionList.DataKeys[e.RowIndex].Value.ToString());
        mProSeriesInfo_ProErrorSeriesInfo.ProErrorName = Convert.ToString(((TextBox)(GridViewShowErrorOptionList.Rows[e.RowIndex].Cells[1].Controls[0])).Text.Trim().ToString());
        mProSeriesInfo_ProErrorSeriesInfo.ProErrorWaringDay = Convert.ToString(((TextBox)(GridViewShowErrorOptionList.Rows[e.RowIndex].Cells[2].Controls[0])).Text.Trim().ToString());
        mProSeriesInfo_ProErrorSeriesInfo.ProErrorDeleted = "0";

        //如果更新的预警天数不是数字或则为负会更新失败
        if (mProSeriesInfo_ProErrorTypeL.UpData_ProErrorSeriesInfo(mProSeriesInfo_ProErrorSeriesInfo) == false)
        {
            ScriptManager.RegisterStartupScript(this.GridViewShowErrorOptionList, typeof(Page), "alert", "alert('更新失败，请注意查看更新天数，或者数据库中存在重名的异常')", true);

        }

        GridViewShowErrorOptionList.EditIndex = -1;

        Is_Search();

    }

    /// <summary>
    /// 函数:GridViewShowErrorOptionList_RowEditing
    /// 作用：在点击编辑后显示更新和取消按键
    /// 作者：bush2582
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewShowErrorOptionList_RowEditing(object sender, GridViewEditEventArgs e)
    {

        this.GridViewShowErrorOptionList.EditIndex = e.NewEditIndex;
        Is_Search();
        Panel_ADD_ErrorOption.Visible = false;
        UpdatePanel_ADD_ErrorOption.Update();
        Panel_Parameter.Visible = false;
        UpdatePanel_Parameter.Update();
        Panel_AddPS.Visible = false;
        UpdatePanel_AddPS.Update();

    }


    /// <summary>
    /// 函数名：GridViewShowErrorOptionList_RowCancelingEdit
    /// 作用：更新异常选项的记录
    /// 作者：bush2582
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewShowErrorOptionList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

        this.GridViewShowErrorOptionList.EditIndex = -1;
        Is_Search();

    }



    /// <summary>
    /// 函数名：Asp_Input_Btn_Reset_Click
    /// 作用：重置页面的参数
    /// 作者：bush2582
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Asp_Input_Btn_Reset_Click(object sender, EventArgs e)
    {
        base.Bind_Updata(this.GridViewShowErrorOptionList, mProSeriesInfo_ProErrorTypeL.SList_ProErrorSeries(), UpdatePanel_List_ErrorOption);
        this.Asp_Input_Search_text.Text = "";
        Panel_ADD_ErrorOption.Visible = false;
        UpdatePanel_ADD_ErrorOption.Update();
        Panel_Parameter.Visible = false;
        UpdatePanel_Parameter.Update();
        Panel_AddPS.Visible = false;
        UpdatePanel_AddPS.Update();
    }


    /// <summary>
    /// 函数名：GridViewShowErrorOptionList_RowDeleting
    /// 作用：删除一条记录，并在调用删除之后重新刷新页面
    /// 作者：bush2582
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewShowErrorOptionList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        mProSeriesInfo_ProErrorSeriesInfo.ProErrorID = new Guid(GridViewShowErrorOptionList.DataKeys[e.RowIndex].Value.ToString());//获取记录的ID号
        if (mProSeriesInfo_ProErrorTypeL.DeleteErrorOption(mProSeriesInfo_ProErrorSeriesInfo) == false)//调用BLL删除记录
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('删除失败，原因不明！')", true);
        }

        //如果当前是在模糊查询某些记录之后才删除的记录，则在删除记录之后，再次查询，并将记录显示在界面上。
        Is_Search();
    }

    /// <summary>
    /// 函数名：Asp_Input_Btn_Search_Click
    /// 作用：模糊查询按键的响应函数
    /// 作者：bush2582
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Asp_Input_Btn_Search_Click(object sender, EventArgs e)
    {
        if (this.Asp_Input_Search_text.Text.ToString() != "")//保证模糊查询的字段不为空
        {
            this.GridViewShowErrorOptionList.PageIndex = 0;//在检索的模式下，要在检索之后，让列表框返回去到第一页，从头开始显示检索到的东西
            base.Bind_Updata(this.GridViewShowErrorOptionList,
                       mProSeriesInfo_ProErrorTypeL.S_SearchErrorOption(this.Asp_Input_Search_text.Text.ToString().Trim()), //调用BLL层进行模糊查询
                       UpdatePanel_List_ErrorOption);
            BlInto_S_Search = true;
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('请填写查询的条件！')", true);
        }
        Panel_ADD_ErrorOption.Visible = false;
        UpdatePanel_ADD_ErrorOption.Update();
        Panel_Parameter.Visible = false;
        UpdatePanel_Parameter.Update();
        Panel_AddPS.Visible = false;
        UpdatePanel_AddPS.Update();
    }

    /// <summary>
    /// 函数名：Asp_Input_AddNewErrorOption_Click
    /// 作用：响应页面的新增异常选项按钮，使新增模块的页面可见或不可见
    /// 作者：bush2582
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Asp_Input_AddNewErrorOption_Click(object sender, EventArgs e)
    {
        //如果再次点击按钮则转换按钮上的文字
        //if (BlIs_Close_ADD == false)
        //{
        //    this.Panel_ADD_ErrorOption.Visible = true;
        //    this.Asp_Input_AddNewErrorOption.Text = "关闭新增模块";
        //    BlIs_Close_ADD = true;
        //    GridViewShowErrorOptionList.SelectedIndex = -1;
        //}
        //else
        //{
        //    this.Asp_Input_AddNewErrorOption.Text = "新增异常原因";
        //    this.Panel_ADD_ErrorOption.Visible = false;
        //    BlIs_Close_ADD = false;
        //    GridViewShowErrorOptionList.SelectedIndex = -1;
        //}
        this.Panel_ADD_ErrorOption.Visible = true;
        BlIs_Close_ADD = true;
        GridViewShowErrorOptionList.SelectedIndex = -1;
        //置空两个text
        Panel_Parameter.Visible = false;
        UpdatePanel_Parameter.Update();
        this.Asp_ADD_ErrorOption_Name_Text.Text = "";
        this.Asp_ADD_ErrorOption_WDay_Text.Text = "";
        this.UpdatePanel_ADD_ErrorOption.Update();
        base.Bind_Updata(this.GridViewShowErrorOptionList, mProSeriesInfo_ProErrorTypeL.SList_ProErrorSeries(), UpdatePanel_List_ErrorOption);
        Panel_Parameter.Visible = false;
        UpdatePanel_Parameter.Update();
        Panel_AddPS.Visible = false;
        UpdatePanel_AddPS.Update();

    }

    /// <summary>
    /// 函数名：Asp_ADD_ErrorOption_Btn_Click
    /// 作用：新增异常选项中的“确定”按钮的响应函数
    /// 作者：bush2582
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Asp_ADD_ErrorOption_Btn_Click(object sender, EventArgs e)
    {
        if (this.Asp_ADD_ErrorOption_Name_Text.Text.ToString() == "" || this.Asp_ADD_ErrorOption_WDay_Text.Text.ToString() == "")
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        mProSeriesInfo_ProErrorSeriesInfo.ProErrorName = this.Asp_ADD_ErrorOption_Name_Text.Text.ToString();
        mProSeriesInfo_ProErrorSeriesInfo.ProErrorWaringDay = this.Asp_ADD_ErrorOption_WDay_Text.Text.ToString();
        if (mProSeriesInfo_ProErrorTypeL.I_ErrorOption(mProSeriesInfo_ProErrorSeriesInfo) == false)//调用BLL插入新的记录
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('异常选项为空者则预警天数不对或者有存在重名的异常！')", true);

        }
        else
        {
            //使得新增异常原因的按钮上的文字变换
            this.Asp_Input_AddNewErrorOption.Text = "新增异常原因";
            BlIs_Close_ADD = false;

            //更新页面
            this.Panel_ADD_ErrorOption.Visible = false;
            this.UpdatePanel_ADD_ErrorOption.Update();
            this.UpdatePanel_Search_ErrorInfo.Update();
            base.Bind_Updata(this.GridViewShowErrorOptionList, mProSeriesInfo_ProErrorTypeL.SList_ProErrorSeries(), this.UpdatePanel_List_ErrorOption);

        }

    }

    /// <summary>
    /// 函数名：GridViewShowErrorOptionList_PageIndexChanging
    /// 作用：GridView分页响应函数
    /// 作者：bush2582
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewShowErrorOptionList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        IntCurrentPageIndex = GridViewShowErrorOptionList.PageIndex;//获取当前的页面在第几页保存下来
        Panel_ADD_ErrorOption.Visible = false;
        UpdatePanel_ADD_ErrorOption.Update();
        Panel_Parameter.Visible = false;
        UpdatePanel_Parameter.Update();
        Panel_AddPS.Visible = false;
        UpdatePanel_AddPS.Update();
    }

    /// <summary>
    /// 函数名：GridViewShowErrorOptionList_RowCommand
    /// 作用：GridView命令自定义响应函数
    /// 作者：bush2582
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewShowErrorOptionList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //翻页响应
        if (base.Page_Turning(GridViewShowErrorOptionList, e, this.GridViewShowErrorOptionList.PageIndex, "ASP_Pager_Text") == true)
        {
            Is_Search();
        }

        if (e.CommandName == "Check_Detail")//
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridViewShowErrorOptionList.SelectedIndex = row.RowIndex;
            GridViewShowErrorOptionList.EditIndex = -1;
            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            this.Label_PTP.Text = al[1];
            this.Label1.Text = al[0];
            Panel_Parameter.Visible = true;
            databind_detail();
            GridView_Parameter.SelectedIndex = -1;
            GridView_Parameter.EditIndex = -1;
            GridView_Parameter.PageIndex = 0;
            Panel_ADD_ErrorOption.Visible = false;
            UpdatePanel_ADD_ErrorOption.Update();

            UpdatePanel_Parameter.Update();
            Panel_AddPS.Visible = false;
            UpdatePanel_AddPS.Update();
        }
    }

    /// <summary>
    /// 函数名：GridViewShowErrorOptionList_DataBound
    /// 作用：GridView用来鼠标悬浮显示气泡的函数
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewShowErrorOptionList_DataBound(object sender, EventArgs e)
    {
        base.GirdViewBubble(GridViewShowErrorOptionList);//调用基类的函数实现

    }
    /* =======================================================================================*/
    protected void GridView_Parameter_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "delete1")//
        {



            string[] al = e.CommandArgument.ToString().Split(new char[] { ',' });
            try
            {
                ppl.D_ErrorPhenomenonOptionDetail(new Guid(al[0].Trim()));
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('删除成功！')", true);
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('删除失败！')", true);
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

            if (Label17.Text.Trim() != name || PBC_Name!=Label2.Text.Trim())
            {
                string condition = " and PBC_Name = '" + ((DropDownList)GridView_Parameter.Rows[e.RowIndex].FindControl("ddl1")).SelectedItem.Text.Trim() + "'";
                DataSet ds = ppl.S_ErrorPhenomenonOptionDetail(this.Label1.Text.Trim(), condition);
                DataRow[] rows = ds.Tables[0].Select(" EPOD_Name='" + name + "'");
                if (rows.Length > 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('"+PBC_Name+" 工序下已存在名为 "+name+" 的详细项目名称！请重新填写')", true);
                    return;
                }

                Guid guid = new Guid(GridView_Parameter.DataKeys[e.RowIndex].Value.ToString());
                Guid PBC_ID = new Guid(((DropDownList)GridView_Parameter.Rows[e.RowIndex].FindControl("ddl1")).SelectedValue.ToString().Trim());
                ppl.U_ErrorPhenomenonOptionDetail(guid, name, PBC_ID);
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('编辑成功！')", true);
            
            }
           
        
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('编辑失败！')", true);
        }
        GridView_Parameter.EditIndex = -1;
        databind_detail();

    }
    protected void GridView_Parameter_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView_Parameter.EditIndex = -1;
        databind_detail();
    }
    protected void Btn_Close_Parameter_Click(object sender, EventArgs e)
    {
        GridViewShowErrorOptionList.SelectedIndex = -1;
        Panel_Parameter.Visible = false;
        UpdatePanel_Parameter.Update();
        Panel_AddPS.Visible = false;
        UpdatePanel_AddPS.Update();
        UpdatePanel_List_ErrorOption.Update();
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
    protected void Btn_Submit_Click(object sender, EventArgs e)
    {
        //if (this.DropDownList2.SelectedIndex == 0)
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('请为异常现象选项详细项目选址工序！')", true);
        //    return;
        //}
        if (this.txt_PS.Text.ToString() == "" || this.DropDownList2.SelectedIndex == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        string condition = " and a.PBC_ID = '" + this.DropDownList2.SelectedValue.ToString().Trim() + "'";

        DataSet ds = ppl.S_ErrorPhenomenonOptionDetail(this.Label1.Text.Trim(), condition);
        DataRow[] rows = ds.Tables[0].Select(" EPOD_Name='" + txt_PS.Text + "'");
        if (rows.Length > 0)
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('" + DropDownList2.SelectedItem.Text.Trim() + " 工序下已存在名为 " + txt_PS.Text.Trim() + " 的详细项目名称！请重新填写')", true);
            return;
        }
        try
        {
            ppl.I_ErrorPhenomenonOptionDetail(new Guid(Label1.Text.Trim()), txt_PS.Text.Trim(), new Guid(DropDownList2.SelectedValue.ToString().Trim()));
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('新增成功！')", true);
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('新增失败！')", true);
            return;
        }
        Panel_AddPS.Visible = false;
        UpdatePanel_AddPS.Update();
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
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        databind_detail();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        this.Panel_ADD_ErrorOption.Visible = false;
        BlIs_Close_ADD = false;
        GridViewShowErrorOptionList.SelectedIndex = -1;
    }
}