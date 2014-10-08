/* ==============================================================================
 * 类名称：CraftMgt_ProcessCraftMgt 
 * 类的作用描述:这个类是页面异常选项维护的后台页面，主要实现页面的后台逻辑
 * 创建人：bush2582
 * 创建时间：1/15/2014 00:00
 * 修改人：
 * 修改时间：
 * 修改备注：
 * @version 1.0
 * ==============================================================================*/
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

public partial class CraftMgt_ProcessCraftMgt : PageCommon
    {
        /* ===================================数据成员定义区=========================================*/
        private ProcessCraftMgtL mProcessCraftMgtL = new ProcessCraftMgtL();//工序的BLL层
        private Process_BadProductTypeL mProcess_BadProductTypeL = new Process_BadProductTypeL();//不良品的BLL层

        private ProcessCraftMgtInfo mProcessCraftMgtInfo = new ProcessCraftMgtInfo(Guid.Empty, "", "0", "0", "0", "0");//工序的module
        private Process_BadProductTypeInfo mProcess_BadProductTypeInfo = new Process_BadProductTypeInfo(Guid.Empty, Guid.Empty, "", "", "0");//不良品的module

        private static bool BlInto_S_Search;//标志位，用于标志是否是在检索状态下
        private static bool BlIs_Close_ADD;//标志位，用于检测是否要使新增模块不显示
        private static Guid GuCraftTempID;//用于暂存工序ID

        private static int IntCurrentPageIndex;


        protected List<CollectWebControl> mCollectWebControlListLook;
        protected List<CollectWebControl> mCollectWebControlListMaintain;

        /* =========================================================================================*/

        public GridView DefaultGridViewShowCraftList
        {
            //定义为只读
            get { return GridViewShowCraftList; }
            set
            {
                GridViewShowCraftList = value;
            }
        }







        /* ===================================方法定义区===========================================*/


        /// <summary>
        /// 函数名：SetDropListSelect
        /// 作者：bush2582
        /// 作用：用来设定某个gridview中的DropdownList令其再被编辑时，显示数据库中已有的数据
        /// <param name="e">GridViewEditEventArgs e</param>
        /// <param name="StrTemp">需要被查找的Label</param>
        /// <param name="whichGridView">GridView whichGridView 那个gridview</param>
        /// <param name="DropDownName">DropDownList的名字</param>
        private void SetDropListSelect(GridViewEditEventArgs e, string StrTemp, GridView whichGridView, string DropDownName)
        {
            DropDownList Droptemp = ((DropDownList)whichGridView.Rows[e.NewEditIndex].FindControl(DropDownName));
            Droptemp.SelectedIndex = Droptemp.Items.IndexOf(Droptemp.Items.FindByValue(StrTemp));
        }



        /// <summary>
        /// 函数名：Is_Search
        /// 作者：bush2582
        /// 作用：用来提供在查询状态下的对GridView的绑定
        /// </summary>
        private void Is_Search()
        {
            mProcessCraftMgtInfo.ResetParameter();
            mProcessCraftMgtInfo.CraftWaringDay = Asp_DropDownList_Search.SelectedValue.ToString();
            mProcessCraftMgtInfo.CraftName = Asp_Input_Search_text.Text.ToString();
            if (BlInto_S_Search == true)
            {
                base.Bind_Updata(GridViewShowCraftList,
                                       mProcessCraftMgtL.S_Craft(mProcessCraftMgtInfo),
                                       UpdatePanel_List_Craft);
            }
            else
            {
                base.Bind_Updata(GridViewShowCraftList,
                                      mProcessCraftMgtL.SList_Craft(),
                                      UpdatePanel_List_Craft);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            

            mCollectWebControlListLook = new List<CollectWebControl>();
            mCollectWebControlListMaintain = new List<CollectWebControl>();

            //在查看权限下需要被隐藏的控件
            mCollectWebControlListLook.Add(new CollectWebControl(GridViewShowCraftList.Columns[5]));
            mCollectWebControlListLook.Add(new CollectWebControl(GridViewShowCraftList.Columns[6]));
            mCollectWebControlListLook.Add(new CollectWebControl(GridViewShowRejects.Columns[5]));
            mCollectWebControlListLook.Add(new CollectWebControl(GridViewShowRejects.Columns[4]));
            mCollectWebControlListLook.Add(new CollectWebControl(Asp_Input_AddNewCraft));

            //在查看维护下需要被隐藏的控件
            mCollectWebControlListMaintain.Add(new CollectWebControl(Panel_ADD_BadProduct));

            UserStat mCraftMgtUserStatLook = new CraftMgtUserStatLook(mCollectWebControlListLook);
            UserStat mCraftMgtUserStatMaintain = new CraftMgtUserStatMaintain(mCollectWebControlListMaintain);

            UserRole mUserRole = new UserRole(mCraftMgtUserStatMaintain,this);

            mCraftMgtUserStatMaintain.SetNextStat(mCraftMgtUserStatLook, mUserRole);
            mUserRole.CheckRole();


            if (!Page.IsPostBack)//保证页面第一次加载的时候会加载数据库信心，在更新数据的时候不会再次加载数据
            {
                base.Bind_Updata(GridViewShowCraftList, mProcessCraftMgtL.SList_Craft(), UpdatePanel_List_Craft);

                //初始化成员数据变量；
                BlInto_S_Search = false;
                BlIs_Close_ADD = false;
                IntCurrentPageIndex = 0;
            }
        }

        /// <summary>
        /// 函数名：Asp_ADD_Craft_Btn_Click
        /// 作者：bush2582
        /// 作用：新增一条工艺记录
        /// 日期：2014年1月15号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Asp_ADD_Craft_Btn_Click(object sender, EventArgs e)
        {
            mProcessCraftMgtInfo.CraftName = Asp_ADD_Craft_Name_Text.Text.ToString().Trim();//获取要被新增的工序名
            mProcessCraftMgtInfo.CraftWaringDay = Asp_ADD_DropDownList.SelectedValue.ToString();//获取预警天数
            mProcessCraftMgtInfo.CraftPassRate = ASP_ADD_Craft_QualifiedRate_Text.Text.ToString();//获取合格率参考标准
            mProcessCraftMgtInfo.CraftParameter = ASP_ADD_Craft_Parameter_Text.Text.ToString();//获取工艺参考

            if (mProcessCraftMgtL.I_Craft(mProcessCraftMgtInfo) == false)//如果插入的数据失败会弹出提示，最主要的原因可能是工序重名
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('新增失败，请检查是否因为工序重名，或则参数设定不正确。例如工艺参数参考太长')", true);
            }

            //重置新增工序模块
            Asp_ADD_Craft_Name_Text.Text = "";
            ASP_ADD_Craft_QualifiedRate_Text.Text = "";
            ASP_ADD_Craft_Parameter_Text.Text = "";
            Asp_ADD_DropDownList.SelectedIndex = -1;

            //关闭新增模块,同时使新增模块上的按钮‘新增工序’的文字变换

            Asp_Input_AddNewCraft.Text = "新增工序";
            BlIs_Close_ADD = false;
            Panel_ADD_Craft.Visible = false;


            //关闭不良品界面，如果有的话
            Panel_Rejects.Visible = false;

            //更新页面
            UpdatePanel_ADD_Craft.Update();
            UpdatePanel_Rejects.Update();
            UpdatePanel_Search_Craft.Update();
            base.Bind_Updata(GridViewShowCraftList,
                                       mProcessCraftMgtL.SList_Craft(),
                                       UpdatePanel_List_Craft);
        }

        /// <summary>
        /// 函数名：Asp_Input_Btn_Search_Click
        /// 作者:bush2582
        /// 作用：页面的"检索"的按钮的响应函数
        /// 日期：2014年1月15号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Asp_Input_Btn_Search_Click(object sender, EventArgs e)
        {
            //获取页面的查询信息
            mProcessCraftMgtInfo.CraftWaringDay = Asp_DropDownList_Search.SelectedValue.ToString();
            mProcessCraftMgtInfo.CraftName = Asp_Input_Search_text.Text.ToString();

            if (mProcessCraftMgtInfo.CraftWaringDay == "0" && mProcessCraftMgtInfo.CraftName == "")//两个查询条件不能完全为空
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('查询条件为空！')", true);
            }
            else
            {
                GridViewShowCraftList.PageIndex = 0;//在检索的模式下，要在检索之后，让列表框返回去到第一页，从头开始显示检索到的东西
                //查询信息
                base.Bind_Updata(GridViewShowCraftList,
                                 mProcessCraftMgtL.S_Craft(mProcessCraftMgtInfo),
                                 UpdatePanel_List_Craft);
                BlInto_S_Search = true;//标志现在进去检索模式
            }
            //重置信息
            mProcessCraftMgtInfo.ResetParameter();

        }

        /// <summary>
        /// 函数名：Asp_Input_Btn_Reset_Click
        /// 作者：bush2582
        /// 作用：页面的"重置"按钮的响应函数
        /// 日期：2014年1月15号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Asp_Input_Btn_Reset_Click(object sender, EventArgs e)
        {
            //重置页面的各个控件的text
            Asp_Input_Search_text.Text = "";
            Asp_ADD_Craft_Name_Text.Text = "";
            ASP_ADD_Craft_QualifiedRate_Text.Text = "";
            ASP_ADD_Craft_Parameter_Text.Text = "";
            Asp_DropDownList_Search.SelectedIndex = -1;
            Asp_ADD_DropDownList.SelectedIndex = -1;

            BlInto_S_Search = false;
            //重新绑定数据源,更新面板
            base.Bind_Updata(GridViewShowCraftList, mProcessCraftMgtL.SList_Craft(), UpdatePanel_List_Craft);
            UpdatePanel_ADD_Craft.Update();

        }

        /// <summary>
        /// 函数名：Asp_Input_AddNewCraft_Click
        /// 作用：页面的"新增工序"按钮的响应函数
        /// 作者：bush2582
        /// 日期：2014年1月15号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Asp_Input_AddNewCraft_Click(object sender, EventArgs e)
        {

            if (BlIs_Close_ADD == false)
            {
                Panel_ADD_Craft.Visible = true;
                Asp_Input_AddNewCraft.Text = "关闭新增模块";
                BlIs_Close_ADD = true;
            }
            else
            {
                Asp_Input_AddNewCraft.Text = "新增工序";
                Panel_ADD_Craft.Visible = false;
                BlIs_Close_ADD = false;
            }
            //关闭不良品界面，如果有的话
            Panel_Rejects.Visible = false;

            //置空两个text
            UpdatePanel_ADD_Craft.Update();

            //更新界面
            UpdatePanel_Rejects.Update();
            
        }

        /// <summary>
        /// 函数名：GridViewShowErrorOptionList_PageIndexChanging
        /// 作用：GridView分页响应函数
        /// 作者：bush2582
        /// </summary>
        protected void GridViewShowCraftList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            IntCurrentPageIndex = GridViewShowCraftList.PageIndex;//获取当前的页面在第几页保存下来

        }
#region 工序列表的命令响应函数

        #region RowCommand
        /// <summary>
        /// 函数名：GridViewShowCraftList_RowCommand
        /// 作者：bush2582
        /// 作用：翻页函数
        /// 日期：2014年1月15号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridViewShowCraftList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (base.Page_Turning(GridViewShowCraftList, e, GridViewShowCraftList.PageIndex, "ASP_Pager_Text") == true)//当前的命令是否是翻页命令
            {
                Is_Search();
                Panel_Rejects.Visible = false;//如果工序界面翻页了，则隐藏不良品管理界面

                //关闭新增工序界面
                Panel_ADD_Craft.Visible = false;
                BlIs_Close_ADD = false;
                Asp_Input_AddNewCraft.Text = "新增工序";

                UpdatePanel_Rejects.Update();
                UpdatePanel_ADD_Craft.Update();
                UpdatePanel_Search_Craft.Update();
                //base.Bind_Updata(this.GridViewShowCraftList, mProcessCraftMgtL.SList_Craft(), this.UpdatePanel_List_Craft);//更新界面
            }
            else if (e.CommandName == "RejectsClass")//如果是显示不良品界面的命名
            {


                GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;//获取ROW好获得被单击的行号

                //GuCraftTempID = mProcess_BadProductTypeInfo.CraftID = new Guid(GridViewShowCraftList.DataKeys[row.RowIndex].Value.ToString());//获取工序ID
                GuCraftTempID = mProcess_BadProductTypeInfo.CraftID = new Guid(GridViewShowCraftList.DataKeys[row.RowIndex].Values["PBC_ID"].ToString());//获取工序ID
                GridViewShowCraftList.SelectedIndex = row.RowIndex;//设定当前被选中的行

                //再次通过查询获取工序名称 注：这里的效率不是很满意，还待提高 这里需要将当前的行数+当前页数*页面的尺寸才能正确的获取数据
                //this.ASP_Label_Rejects_Label.Text = mProcessCraftMgtL.SList_Craft().Tables[0].Rows[row.RowIndex + this.GridViewShowCraftList.PageIndex * this.GridViewShowCraftList.PageSize][1].ToString() + "不良品工艺管理（*号为必填项目）";
                ASP_Label_Rejects_Label.Text = GridViewShowCraftList.DataKeys[row.RowIndex].Values["PBC_Name"].ToString() + "不良品工艺管理（*号为必填项目）";

                //显示不良品工艺管理界面
                Panel_Rejects.Visible = true;
                Panel_GridViewShowRejects.Visible = true;
                

                //关闭新增工序界面
                Panel_ADD_Craft.Visible = false;
                BlIs_Close_ADD = false;
                Asp_Input_AddNewCraft.Text = "新增工序";

                base.Bind_Updata(GridViewShowRejects,
                                    mProcess_BadProductTypeL.SList_BadProduct(mProcess_BadProductTypeInfo),
                                    UpdatePanel_Rejects);//更新界面
                mProcess_BadProductTypeInfo.ResetParameter();//重置参数

                UpdatePanel_ADD_Craft.Update();
                UpdatePanel_Search_Craft.Update();
            }
        }
        #endregion

        #region 在点击编辑后显示更新和取消按键
        /// <summary>
        /// 函数:GridViewShowCraftList_RowEditing
        /// 作用：在点击编辑后显示更新和取消按键
        /// 作者：bush2582
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridViewShowCraftList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //先获取当前的预警日期是多少,
            string strtemp = ((Label)GridViewShowCraftList.Rows[e.NewEditIndex].FindControl("Label2")).Text.ToString();
            //设置哪行被编辑
            GridViewShowCraftList.EditIndex = e.NewEditIndex;
            Is_Search();

            //然后设定DropDownList显示在还没有被编辑之前的数据
            SetDropListSelect(e, strtemp, GridViewShowCraftList, "ASP_PBC_Time_DropDownList");
        }
        #endregion

        #region 在页面点击编辑后，出现的取消键的响应函数
        /// <summary>
        /// 函数名：GridViewShowCraftList_RowCancelingEdit
        /// 作者：bush2582
        /// 作用：在页面点击编辑后，出现的取消键的响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridViewShowCraftList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewShowCraftList.EditIndex = -1;
            Is_Search();
        }
        #endregion

        #region 更新响应函数，用于更新页面的数据
        /// <summary>
        /// 函数名：GridViewShowCraftList_RowUpdating
        /// 作用：GridView的更新响应函数，用于更新页面的数据
        /// 作者：bush2582
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridViewShowCraftList_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {


            //获取页面上要被更新的数据
            mProcessCraftMgtInfo.CraftID = new Guid(GridViewShowCraftList.DataKeys[e.RowIndex].Value.ToString());//ID
            //名称
            mProcessCraftMgtInfo.CraftName = Convert.ToString(((TextBox)(GridViewShowCraftList.Rows[e.RowIndex].Cells[1].Controls[0])).Text.Trim().ToString());
            //预警天数
            mProcessCraftMgtInfo.CraftWaringDay = ((DropDownList)GridViewShowCraftList.Rows[e.RowIndex].FindControl("ASP_PBC_Time_DropDownList")).SelectedValue.ToString();
            //合格率
            mProcessCraftMgtInfo.CraftPassRate = Convert.ToString(((TextBox)(GridViewShowCraftList.Rows[e.RowIndex].Cells[3].Controls[0])).Text.Trim().ToString());
            //工艺参考参数
            mProcessCraftMgtInfo.CraftParameter = Convert.ToString(((TextBox)(GridViewShowCraftList.Rows[e.RowIndex].Cells[4].Controls[0])).Text.Trim().ToString());

            if (mProcessCraftMgtL.U_Craft(mProcessCraftMgtInfo) == false)
            {
                ScriptManager.RegisterStartupScript(GridViewShowCraftList, typeof(Page), "alert", "alert('更新失败，请注意查看参数，例如天数是否正确，合格率是否正确，是否已存在相同的工序名称')", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(GridViewShowRejects, typeof(Page), "alert", "alert('更新成功')", true);
            }
            GridViewShowCraftList.EditIndex = -1;
            Is_Search();
        }
        #endregion

        #region 删除按钮响应函数
        /// <summary>
        /// 函数名：GridViewShowCraftList_RowDeleting
        /// 作者：bush2582
        /// 作用：GridViewShowCraftList的删除按钮响应函数
        /// 日期：2014年1月17号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridViewShowCraftList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Guid GuTemp = new Guid(GridViewShowCraftList.DataKeys[e.RowIndex].Value.ToString());
            if (mProcessCraftMgtL.D_Craft(GuTemp) == false)
            {
                ScriptManager.RegisterStartupScript(GridViewShowCraftList, typeof(Page), "alert", "alert('删除失败，原因不明')", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(GridViewShowCraftList, typeof(Page), "alert", "alert('删除成功')", true);
            }

            Panel_Rejects.Visible = false;
            base.Bind_Updata(GridViewShowCraftList, mProcessCraftMgtL.SList_Craft(), UpdatePanel_List_Craft);
            UpdatePanel_Rejects.Update();
        }
        #endregion
#endregion
        /// <summary>
        /// 函数名：ASP_ADD_BadProduct_Click
        /// 作者：bush2582
        /// 作用：新增一条不良品类型
        /// 日期：2014年1月17号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ASP_ADD_BadProduct_Click(object sender, EventArgs e)
        {
            mProcess_BadProductTypeInfo.CraftID = GuCraftTempID;//获取工序ID
            mProcess_BadProductTypeInfo.BadProductName = ASP_ADD_BadProduct_text.Text.ToString();//获取不良品的名称
            mProcess_BadProductTypeInfo.BadProductBLevel = ASP_ADD_BadProduct_DropDownList.SelectedValue.ToString();//获取严重程度
            if (mProcess_BadProductTypeL.I_BadProduct(mProcess_BadProductTypeInfo) == false)
            {
                ScriptManager.RegisterStartupScript(GridViewShowRejects, typeof(Page), "alert", "alert('插入失败，请注意查看参数，例如名称不为空，严重程度选择没，是否已存在相同的不良品名称')", true);
            }
            else
            {
                //重置新增不良品的模块的参数
                ScriptManager.RegisterStartupScript(GridViewShowRejects, typeof(Page), "alert", "alert('插入不良品类型成功')", true);
            }
            ASP_ADD_BadProduct_text.Text = "";
            ASP_ADD_BadProduct_DropDownList.SelectedIndex = -1;
            base.Bind_Updata(GridViewShowRejects, mProcess_BadProductTypeL.SList_BadProduct(mProcess_BadProductTypeInfo), UpdatePanel_Rejects);
        }

        /// <summary>
        /// 函数名：GridViewShowRejects_PageIndexChanging
        /// 作用：GridView分页响应函数
        /// 作者：bush2582
        /// </summary>
        protected void GridViewShowRejects_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            IntCurrentPageIndex = GridViewShowRejects.PageIndex;//获取当前的页面在第几页保存下来
        }

        /// <summary>
        /// 函数名：GridViewShowRejects_RowCommand
        /// 作者：bush2582
        /// 作用：翻页函数
        /// 日期：2014年1月17号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridViewShowRejects_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (base.Page_Turning(GridViewShowRejects, e, GridViewShowRejects.PageIndex, "ASP_Pager_Text") == true) //当前的命令是否是翻页命令    
            {
                mProcess_BadProductTypeInfo.CraftID = GuCraftTempID;
                base.Bind_Updata(GridViewShowRejects, mProcess_BadProductTypeL.SList_BadProduct(mProcess_BadProductTypeInfo), UpdatePanel_Rejects);
            }
        }

        /// <summary>
        /// 函数名：GridViewShowRejects_RowCancelingEdit
        /// 作者：bush2582
        /// 作用：GridViewShowRejects上按下编辑后的取消响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridViewShowRejects_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewShowRejects.EditIndex = -1;

            //必须再更新一次，不然会出现按两次编辑才能在grid显示一个编辑框的情况
            mProcess_BadProductTypeInfo.CraftID = GuCraftTempID;
            base.Bind_Updata(GridViewShowRejects, mProcess_BadProductTypeL.SList_BadProduct(mProcess_BadProductTypeInfo), UpdatePanel_Rejects);
        }

        /// <summary>
        /// 函数:GridViewShowRejects_RowEditing
        /// 作用：在点击编辑后显示更新和取消按键
        /// 作者：bush2582
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridViewShowRejects_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //获取不良品的严重程度
            string Strtemp = ((Label)GridViewShowRejects.Rows[e.NewEditIndex].FindControl("Label1")).Text.ToString();

            GridViewShowRejects.EditIndex = e.NewEditIndex;
            //必须再更新一次，不然会出现按两次编辑才能在grid显示一个编辑框的情况
            mProcess_BadProductTypeInfo.CraftID = GuCraftTempID;
            base.Bind_Updata(GridViewShowRejects, mProcess_BadProductTypeL.SList_BadProduct(mProcess_BadProductTypeInfo), UpdatePanel_Rejects);

            //然后设定DropDownList显示在还没有被编辑之前的数据
            SetDropListSelect(e, Strtemp, GridViewShowRejects, "ASP_BPT_BLevel_DropDownList");
        }

        /// <summary>
        /// 函数名：GridViewShowRejects_RowUpdating
        /// 作者：bush2582
        /// 作用：GridViewShowRejects上按编辑后的更新响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridViewShowRejects_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //获取工序ID
            mProcess_BadProductTypeInfo.CraftID = GuCraftTempID;
            //获取不良品的ID
            mProcess_BadProductTypeInfo.BadProductID = new Guid(GridViewShowRejects.DataKeys[e.RowIndex].Value.ToString());
            //获取不良品的名字
            mProcess_BadProductTypeInfo.BadProductName = Convert.ToString(((TextBox)(GridViewShowRejects.Rows[e.RowIndex].Cells[2].Controls[0])).Text.Trim().ToString());
            //获取不良品的严重程度
            mProcess_BadProductTypeInfo.BadProductBLevel = ((DropDownList)GridViewShowRejects.Rows[e.RowIndex].FindControl("ASP_BPT_BLevel_DropDownList")).SelectedValue.ToString();

            if (mProcess_BadProductTypeL.U_BadProductTypeInfo(mProcess_BadProductTypeInfo) == false)
            {
                ScriptManager.RegisterStartupScript(GridViewShowRejects, typeof(Page), "alert", "alert('更新失败，请注意查看参数或是否已存在相同的不良品名称')", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(GridViewShowRejects, typeof(Page), "alert", "alert('更新成功')", true);
            }
            GridViewShowRejects.EditIndex = -1;

            //更新界面
            mProcess_BadProductTypeInfo.CraftID = GuCraftTempID;
            base.Bind_Updata(GridViewShowRejects, mProcess_BadProductTypeL.SList_BadProduct(mProcess_BadProductTypeInfo), UpdatePanel_Rejects);
        }

        /// <summary>
        /// 函数名：GridViewShowRejects_RowDeleting
        /// 作者：bush2582
        /// 作用：GridViewShowRejects的删除响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridViewShowRejects_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //获取不良品的ID
            Guid GuTemp = new Guid(GridViewShowRejects.DataKeys[e.RowIndex].Value.ToString());


            if (mProcess_BadProductTypeL.D_BadProductTypeInfo(GuTemp) == false)
            {
                ScriptManager.RegisterStartupScript(GridViewShowRejects, typeof(Page), "alert", "alert('删除失败，原因不明')", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(GridViewShowRejects, typeof(Page), "alert", "alert('删除成功')", true);
            }
            mProcess_BadProductTypeInfo.CraftID = GuCraftTempID;
            base.Bind_Updata(GridViewShowRejects, mProcess_BadProductTypeL.SList_BadProduct(mProcess_BadProductTypeInfo), UpdatePanel_Rejects);
        }



        /// <summary>
        /// 函数名：GridViewShowCraftList_DataBound
        /// 作用：GridView用来鼠标悬浮显示气泡的函数
        /// 作者：bush2582
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridViewShowCraftList_DataBound(object sender, EventArgs e)
        {
            base.GirdViewBubble(GridViewShowCraftList);//调用基类的函数实现
        }

        /// <summary>
        /// 函数名：GridViewShowRejects_DataBound
        /// 作用：GridView用来鼠标悬浮显示气泡的函数
        /// 作者：bush2582
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridViewShowRejects_DataBound(object sender, EventArgs e)
        {
            base.GirdViewBubble(GridViewShowRejects);//调用基类的函数实现

        }


        /// <summary>
        /// 函数名：ASP_ADD_Close_Click
        /// 作用：不良品工艺管理界面的关闭按钮
        /// 作者：bush2582
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ASP_ADD_Close_Click(object sender, EventArgs e)
        {
            Panel_Rejects.Visible = false;
            UpdatePanel_Rejects.Update();
        }
        /* =======================================================================================*/
    }
