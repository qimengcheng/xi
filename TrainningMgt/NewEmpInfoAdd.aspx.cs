using System;
using System.Web.UI;
using System.Web.UI.WebControls;

using RTXHelper;

public partial class TrainningMgt_NewEmpInfoAdd : Page
{
    NewEmpInfoAddL neiaL = new NewEmpInfoAddL();
    NewEmpInfoAddInfo neiaInfo = new NewEmpInfoAddInfo();

    private static string Condition;
    private static string Condition1;
    private static string Condition2;
    private static string Condition3;//对应新员工培训项目新增栏的检索条件
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserRole"] == null)
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('您长时间未操作，请重新登录！')", true);
            Response.Redirect("~/Default.aspx");
        }
        //#region//权限控制

        if (!((Session["UserRole"].ToString().Contains("新员工培训信息新建"))))
        {
            Response.Redirect("~/Default.aspx");

        }
        if (Request.QueryString["status"] == "newEAddAdd")
        {
            Title = "新员工培训信息新建";
        }
        //#endregion

        if (!IsPostBack)
        {
            BindGrid_InfoList("");
        }

    }

    #region//绑定Gridview的方法
    private void BindGrid_InfoList(string Condition)
    {
        Grid_InfoList.DataSource = neiaL.Search_NETraInfoMainTable(Condition);
        Grid_InfoList.DataBind();
    }//新员工培训信息列表Grid_InfoList

    private void BindGridView_PeopleIn(string Condition)
    {
        GridView_PeopleIn.DataSource = neiaL.Search_ByCondition_NETraPeopleChooseTable(Condition);
        GridView_PeopleIn.DataBind();
    }//新员工培训的人员列表GridView_PeopleIn


    private void BindGridGridView_ItemIn(string Condition)
    {
        GridView_ItemIn.DataSource = neiaL.Search_NETraItemChooseTable(" and a.NETIMT_ID='" + LblRecordID2.Text + "'" + Condition);
        GridView_ItemIn.DataBind();
    }//已有的培训项目列表GridView_ItemIn

    private void BindGridGridView_ItemAll(string Condition)
    {
        GridView_ItemAll.DataSource = neiaL.Search_ForChoose_NETraItemChooseTable(" and a.NETI_ID NOT IN (SELECT NETraItemChooseTable.NETI_ID FROM NETraItemChooseTable WHERE NETraItemChooseTable.NETIMT_ID='" + LblRecordID2.Text + "')" + Condition);
        GridView_ItemAll.DataBind();
    }//新员工培训项目列表GridView_ItemAll
    #endregion


    #region//检索栏
    protected void Btn_Search_Click(object sender, EventArgs e)
    {
        Condition = TxtSPerson.Text.Trim() == "" ? " " : " and NETIMT_Person like '%" + TxtSPerson.Text.Trim() + "%' ";
        Condition += TxtSEndTime.Text.Trim() == "" ? "" : " and NETIMT_Time <= '" + TxtSEndTime.Text.Trim() + "'";
        Condition += TxtSStartTime.Text.Trim() == "" ? "" : " and NETIMT_Time >= '" + TxtSStartTime.Text.Trim() + "'";
        Condition += DropDownList1.Text.Trim() == "请选择" ? "" : " and NETIMT_State = '" + DropDownList1.Text.Trim() + "'";
        BindGrid_InfoList(Condition);
        LblRecordIsSearch.Text = "检索后";
        Grid_InfoList.SelectedIndex = -1;
        UpdatePanel2.Update();
    }//检索
    protected void Btn_Reset_Click(object sender, EventArgs e)
    {
        TxtSPerson.Text = "";
        TxtSStartTime.Text = "";
        TxtSEndTime.Text = "";
        DropDownList1.ClearSelection();
        LblRecordIsSearch.Text = "检索前";
        Grid_InfoList.SelectedIndex = -1;
        BindGrid_InfoList("");
        UpdatePanel1.Update();
        UpdatePanel2.Update();
    }//重置
    protected void Btn_New_Click(object sender, EventArgs e)
    {
        Panel3.Visible = true;
        UpdatePanel3.Update();
        Label4.Text = "新增";
        TxtAddPerson.Text = Session["UserName"].ToString().Trim();
        TxtAddTime.Text = DateTime.Now.ToString();
        TxtAddRemarks.Text = "";

    }//新增培训信息
    #endregion



    #region//新增新员工培训信息
    protected void BtnOK_Click(object sender, EventArgs e)
    {
        if (Label4.Text == "新增")
        {
            int i = 0;
            neiaInfo.NETIMT_ID = new Guid();
            neiaInfo.NETIMT_Person = TxtAddPerson.Text.Trim();
            neiaInfo.NETIMT_Time = DateTime.Now;
            neiaInfo.NETIMT_Remarks = TxtAddRemarks.Text;
            neiaInfo.NETIMT_State = "待提交";
            try
            {
                i = neiaL.Insert_NETraInfoMainTable(neiaInfo);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('新增失败！'" + ex + ")", true);
            }
            Panel3.Visible = false;
            UpdatePanel3.Update();
            BindGrid_InfoList(" ");
            UpdatePanel2.Update();
            if (i > 0)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('新增成功！')", true);
            }
        }
        if (Label4.Text == "编辑")
        {
            int i = 0;
            NewEmpInfoAddInfo neiaInfoOK = new NewEmpInfoAddInfo();
            neiaInfoOK.NETIMT_ID = new Guid(Label66.Text);
            neiaInfoOK.NETIMT_Person = TxtAddPerson.Text;
            neiaInfoOK.NETIMT_Time = DateTime.Now;
            neiaInfoOK.NETIMT_Remarks = TxtAddRemarks.Text;
            try
            {
                i = neiaL.Update_ForEdit_NETraInfoMainTable(neiaInfoOK);
            }
            catch (Exception ex)
            {
                throw ex;
                //ScriptManager.RegisterClientScriptBlock(this.Page, typeof(Page), "alert", "alert('编辑失败！'" + ex + ")", true);
            }
            Panel3.Visible = false;
            UpdatePanel3.Update();
            if (LblRecordIsSearch.Text == "检索前")
                BindGrid_InfoList(" ");
            if (LblRecordIsSearch.Text == "检索后")
                BindGrid_InfoList(Condition);
            Grid_InfoList.SelectedIndex = 0;//根据前面两个if判断，使得编辑的项目永远在第一行，所以加粗显示的也在第一行
            UpdatePanel2.Update();
            if (i > 0)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('编辑成功！')", true);
            }
        }
    }//确定
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        Panel3.Visible = false;
        TxtAddPerson.Text = "";
        TxtAddTime.Text = "";
        TxtAddRemarks.Text = "";
    }//取消
    #endregion




    #region//Grid_InfoList的内置事件
    protected void Grid_InfoList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
        string[] StrArgument = e.CommandArgument.ToString().Split(new char[] { ',' });
        if (e.CommandName == "Edit1")//commandName最好不要用edit、delete、update、cancel ，我把你原来的edit改成了edit1，前台同
        {
            Grid_InfoList.SelectedIndex = row.RowIndex;

            if (StrArgument[1].ToString() != "待提交")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('此状态下的信息不允许编辑！')", true);
                return;
            }

            Panel3.Visible = true;
            Label4.Text = "编辑";
            TxtAddPerson.Text = Session["UserName"].ToString().Trim();
            TxtAddTime.Text = DateTime.Now.ToString();
            Label66.Text = StrArgument[0].ToString();
            Guid id = new Guid(Label66.Text);
            NewEmpInfoAddInfo neiaInfoForEdit = neiaL.SearchByID_NETraInfoMainTable(id)[0];
            TxtAddPerson.Text = neiaInfoForEdit.NETIMT_Person;
            TxtAddTime.Text = neiaInfoForEdit.NETIMT_Time.ToString();
            TxtAddRemarks.Text = neiaInfoForEdit.NETIMT_Remarks;
            UpdatePanel3.Update();

            //控制 面板弹出和关闭的逻辑
            if (Panel4.Visible)
            {
                if (LblRecordID.Text != StrArgument[0].ToString())
                {
                    Panel4.Visible = false;
                    UpdatePanel4.Update();
                    if (Panel5.Visible)
                    {
                        Panel5.Visible = false;
                        UpdatePanel5.Update();

                    }
                }
            }
            if (Panel6.Visible)
            {
                if (LblRecordID2.Text != StrArgument[0].ToString())
                {
                    Panel6.Visible = false;
                    UpdatePanel6.Update();
                    if (Panel7.Visible)
                    {
                        Panel7.Visible = false;
                        UpdatePanel7.Update();

                    }
                }
            }
        }
        if (e.CommandName == "Delete1")
        {
            if (StrArgument[1].ToString() != "待提交")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('此状态下的信息不允许删除！')", true);
                return;
            }
            Grid_InfoList.SelectedIndex = -1;
            try
            {
                neiaL.Delete_NETraInfoMainTable(new Guid(StrArgument[0].ToString()));
            }
            catch (Exception)
            {

                throw;
            }

            if (LblRecordIsSearch.Text == "检索前")
                BindGrid_InfoList("");
            if (LblRecordIsSearch.Text == "检索后")
                BindGrid_InfoList(Condition);
            UpdatePanel2.Update();

            //控制 面板弹出和关闭的逻辑
            if (Panel3.Visible | Panel4.Visible | Panel5.Visible | Panel6.Visible | Panel7.Visible)
            {
                Panel3.Visible = false;
                UpdatePanel3.Update();

                Panel4.Visible = false;
                UpdatePanel4.Update();

                Panel5.Visible = false;
                UpdatePanel5.Update();

                Panel6.Visible = false;
                UpdatePanel6.Update();

                Panel7.Visible = false;
                UpdatePanel7.Update();

            }
        }
        if (e.CommandName == "Submit1")
        {
            if (StrArgument[1].ToString() != "待提交")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('此状态下的信息不允许提交！')", true);
                return;
            }
            int i = 0;
            Grid_InfoList.SelectedIndex = -1;
            try
            {
                NewEmpInfoAddInfo neiaInfoForSubmit = new NewEmpInfoAddInfo();
                neiaInfoForSubmit.NETIMT_ID = new Guid(StrArgument[0].ToString());
                neiaInfoForSubmit.NETIMT_State = "已提交";

                i = neiaL.Update_ForSubmit_NETraInfoMainTable(neiaInfoForSubmit);
                if (LblRecordIsSearch.Text == "检索前")
                    BindGrid_InfoList("");
                if (LblRecordIsSearch.Text == "检索后")
                    BindGrid_InfoList(Condition);
                UpdatePanel2.Update();
            }
            catch (Exception)
            {
                
                throw;
            }
            
            if (i > 0)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('已提交！')", true);

                //RTX
                string message = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "提交了一次新员工培训，请录入结果。";
                string sErr = RTXhelper.Send(message, "新员工培训结果录入");
                if (!string.IsNullOrEmpty(sErr))
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('" + sErr + "')", true);
                }


                //控制面板的消失逻辑
                if (Panel3.Visible | Panel4.Visible | Panel5.Visible | Panel6.Visible | Panel7.Visible)
                {
                    Panel3.Visible = false;
                    UpdatePanel3.Update();

                    Panel4.Visible = false;
                    UpdatePanel4.Update();

                    Panel5.Visible = false;
                    UpdatePanel5.Update();

                    Panel6.Visible = false;
                    UpdatePanel6.Update();

                    Panel7.Visible = false;
                    UpdatePanel7.Update();

                }
            }
            else
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('提交失败，必须同时具有培训人员和培训项目！')", true);

        }
        if (e.CommandName == "LookPerson")
        {
            Grid_InfoList.SelectedIndex = row.RowIndex;
            try
            {
                Panel4.Visible = true;
                UpdatePanel4.Update();
                LblRecordID.Text = StrArgument[0].ToString();
                BindGridView_PeopleIn(" and NETIMT_ID='" + new Guid(LblRecordID.Text) + "'");
            }
            catch (Exception)
            {

                throw;
            }
            BtnAddPeople.Visible = false;
            GridView_PeopleIn.Columns[4].Visible = false;
            //控制 面板弹出和关闭的逻辑
            if (Panel3.Visible)
            {
                if (Label66.Text != StrArgument[0].ToString())
                {
                    Panel3.Visible = false;
                    UpdatePanel3.Update();
                }
            }

            if (Panel6.Visible)
            {
                if (LblRecordID2.Text != StrArgument[0].ToString())
                {
                    Panel6.Visible = false;
                    UpdatePanel6.Update();
                    if (Panel7.Visible)
                    {
                        Panel7.Visible = false;
                        UpdatePanel7.Update();

                    }
                }
            }

        }
        if (e.CommandName == "EditPerson")
        {
            Grid_InfoList.SelectedIndex = row.RowIndex;
            if (StrArgument[1].ToString() != "待提交")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('此状态下的信息不允许编辑培训的新员工！')", true);
                return;
            }
            try
            {
                Panel4.Visible = true;
                UpdatePanel4.Update();
                LblRecordID.Text = StrArgument[0].ToString();
                BindGridView_PeopleIn(" and NETIMT_ID='" + new Guid(LblRecordID.Text) + "'");
            }
            catch (Exception)
            {
                
                throw;
            }

            BtnAddPeople.Visible = true; ;
            GridView_PeopleIn.Columns[4].Visible = true;
            //控制 面板弹出和关闭的逻辑
            if (Panel3.Visible)
            {
                if (Label66.Text != StrArgument[0].ToString())
                {
                    Panel3.Visible = false;
                    UpdatePanel3.Update();
                }
            }

            if (Panel6.Visible)
            {
                if (LblRecordID2.Text != StrArgument[0].ToString())
                {
                    Panel6.Visible = false;
                    UpdatePanel6.Update();
                    if (Panel7.Visible)
                    {
                        Panel7.Visible = false;
                        UpdatePanel7.Update();

                    }
                }
            }

        }
        if (e.CommandName == "LookCourse")
        {
            Grid_InfoList.SelectedIndex = row.RowIndex;

            try
            {
                Panel6.Visible = true;
                UpdatePanel6.Update();
                LblRecordID2.Text = StrArgument[0].ToString();
                BindGridGridView_ItemIn(" ");
            }
            catch (Exception)
            {

                throw;
            }

            Btn_NEW_NETItem.Visible = false;
            GridView_ItemIn.Columns[5].Visible=false;
            //控制 面板弹出和关闭的逻辑
            if (Panel3.Visible)
            {
                if (Label66.Text != StrArgument[0].ToString())
                {
                    Panel3.Visible = false;
                    UpdatePanel3.Update();
                }
            }
            if (Panel4.Visible)
            {
                if (LblRecordID.Text != StrArgument[0].ToString())
                {
                    Panel4.Visible = false;
                    UpdatePanel4.Update();
                    if (Panel5.Visible)
                    {
                        Panel5.Visible = false;
                        UpdatePanel5.Update();

                    }
                }
            }
        }

        if (e.CommandName == "EditCourse")
        {
            Grid_InfoList.SelectedIndex = row.RowIndex;

            if (StrArgument[1].ToString() != "待提交")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('此状态下的信息不允许编辑培训项目！')", true);
                return;
            }
            try
            {
                Panel6.Visible = true;
                UpdatePanel6.Update();
                LblRecordID2.Text = StrArgument[0].ToString();
                BindGridGridView_ItemIn(" ");
            }
            catch (Exception)
            {

                throw;
            }

            Btn_NEW_NETItem.Visible = true;
            GridView_ItemIn.Columns[5].Visible = true;
            //控制 面板弹出和关闭的逻辑
            if (Panel3.Visible)
            {
                if (Label66.Text != StrArgument[0].ToString())
                {
                    Panel3.Visible = false;
                    UpdatePanel3.Update();
                }
            }
            if (Panel4.Visible)
            {
                if (LblRecordID.Text != StrArgument[0].ToString())
                {
                    Panel4.Visible = false;
                    UpdatePanel4.Update();
                    if (Panel5.Visible)
                    {
                        Panel5.Visible = false;
                        UpdatePanel5.Update();

                    }
                }
            }
        }
    }
    protected void Grid_InfoList_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Grid_InfoList.Rows.Count; i++)
        {
            for (int j = 0; j < Grid_InfoList.Rows[i].Cells.Count; j++)
            {
                Grid_InfoList.Rows[i].Cells[j].ToolTip = Grid_InfoList.Rows[i].Cells[j].Text;
                if (Grid_InfoList.Rows[i].Cells[j].Text.Length > 15)
                {
                    Grid_InfoList.Rows[i].Cells[j].Text = Grid_InfoList.Rows[i].Cells[j].Text.Substring(0, 16) + "...";
                }
            }
        }
    }
    protected void Grid_InfoList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_InfoList.BottomPagerRow;


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
        //Grid_Post.DataBind();
        if (LblRecordIsSearch.Text == "检索前")
            BindGrid_InfoList("");
        if (LblRecordIsSearch.Text == "检索后")
            BindGrid_InfoList(Condition);

        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_InfoList.PageCount ? Grid_InfoList.PageCount - 1 : newPageIndex;
        Grid_InfoList.PageIndex = newPageIndex;
        Grid_InfoList.DataBind();
    }
    #endregion




    #region//新员工编辑栏
    protected void BtnAddPeople_Click1(object sender, EventArgs e)
    {
        Panel5.Visible = true;
        UpdatePanel5.Update();
        TxtAddName.Text = "";
        TxtAddSex.Text = "";
        TxtDate.Text = "";
    }//新增新员工

    protected void BtnSalaryRecordClose_Click(object sender, EventArgs e)
    {
        Panel4.Visible = false;
        if (Panel5.Visible)
        {
            Panel5.Visible = false;
            UpdatePanel5.Update();
        }
    }//关闭
    #endregion




    #region//GridView_PeopleIn的内置事件
    protected void GridView_PeopleIn_DataBound(object sender, EventArgs e)
    {

    }
    protected void GridView_PeopleIn_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete2")
        {
            Grid_InfoList.SelectedIndex = -1;
            neiaL.Delete_NETraPeopleChooseTable(new Guid(e.CommandArgument.ToString()));
            BindGridView_PeopleIn(" and NETIMT_ID='" + new Guid(LblRecordID.Text) + "'");
            UpdatePanel4.Update();
        }
    }
    protected void GridView_PeopleIn_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView_PeopleIn.BottomPagerRow;


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

        BindGridView_PeopleIn(" and NETIMT_ID='" + new Guid(LblRecordID.Text) + "'");


        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView_PeopleIn.PageCount ? GridView_PeopleIn.PageCount - 1 : newPageIndex;
        GridView_PeopleIn.PageIndex = newPageIndex;
        GridView_PeopleIn.DataBind();
    }
    #endregion



    #region//新员工新增栏

    protected void BtnAddSubmit_Click(object sender, EventArgs e)
    {
        if (TxtAddName.Text.Trim() == "" || TxtAddSex.Text.Trim() == "" || TxtDate.Text.Trim() == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('带*的为必填项，请填写完整！')", true);
            return; 
        }
        NewEmpInfoAddInfo neiai = new NewEmpInfoAddInfo();
        try
        {
            neiai.NETPCT_ID = new Guid();
            neiai.NETIMT_ID = new Guid(LblRecordID.Text);
            neiai.NETPCT_Name = TxtAddName.Text;
            neiai.NETPCT_Sex = TxtAddSex.Text;
            DateTime d1;
            if (DateTime.TryParse(TxtDate.Text, out d1))
                neiai.NETPCT_Date = d1;
            else
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('报到日期格式不正确')", true);
            neiaL.Insert_NETraPeopleChooseTable(neiai);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        BindGridView_PeopleIn(" and NETIMT_ID='" + new Guid(LblRecordID.Text) + "'");
        GridView_PeopleIn.SelectedIndex = -1;
        TxtAddName.Text = "";
        TxtAddSex.Text = "";
        TxtDate.Text = "";
        UpdatePanel4.Update();
        UpdatePanel5.Update();
        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('提交成功！')", true);
    }//提交
    protected void BtnAddCancel_Click(object sender, EventArgs e)
    {
        Panel5.Visible = false;
        UpdatePanel5.Update();
    }//取消

    #endregion



    #region//已有的培训项目列表
    protected void Btn_NEW_NETItem_Click(object sender, EventArgs e)
    {
        try
        {
            Panel7.Visible = true;
            TxtAddCourse.Text = "";
            TxtAddType.Text = "";
            TxtAddDep.Text = "";
            BindGridGridView_ItemAll("");
            UpdatePanel7.Update();
        }
        catch (Exception)
        {

            throw;
        }

    }//新增培训项目
    protected void BtnClose_Click(object sender, EventArgs e)
    {
        Panel6.Visible = false;
        if (Panel7.Visible)
        {
            Panel7.Visible = false;
            UpdatePanel7.Update();
        }
    }//关闭
    #endregion



    #region//GridView_ItemIn的内置事件
    protected void GridView_ItemIn_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView_ItemIn.Rows.Count; i++)
        {
            for (int j = 0; j < GridView_ItemIn.Rows[i].Cells.Count; j++)
            {
                GridView_ItemIn.Rows[i].Cells[j].ToolTip = GridView_ItemIn.Rows[i].Cells[j].Text;
                if (GridView_ItemIn.Rows[i].Cells[j].Text.Length > 15)
                {
                    GridView_ItemIn.Rows[i].Cells[j].Text = GridView_ItemIn.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }


            }
        }
    }
    protected void GridView_ItemIn_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView_ItemIn.BottomPagerRow;


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
        BindGridGridView_ItemIn("");
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView_ItemIn.PageCount ? GridView_ItemIn.PageCount - 1 : newPageIndex;
        GridView_ItemIn.PageIndex = newPageIndex;
        GridView_ItemIn.DataBind();
    }
    protected void GridView_ItemIn_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete_TraningCourse")
        {
            GridView_ItemIn.SelectedIndex = -1;
            Guid guid = new Guid(e.CommandArgument.ToString());
            neiaL.Delete_NETraItemChooseTable(guid);
            BindGridGridView_ItemIn("");
            UpdatePanel6.Update();
            if (Panel7.Visible)
            {
                BindGridGridView_ItemAll("");
                UpdatePanel7.Update();
            }

        }
    }
    #endregion




    #region//新员工培训项目新增栏
    protected void Button6_Click(object sender, EventArgs e)
    {
        Condition3 = TxtAddCourse.Text.Trim() == "" ? " " : " and NETI_TraningCourse like '%" + TxtAddCourse.Text.Trim() + "%'";
        Condition3 += TxtAddType.Text.Trim() == "" ? " " : " and NETI_TraningType like '%" + TxtAddType.Text.Trim() + "%'";
        Condition3 += TxtAddDep.Text.Trim() == "" ? " " : " and a.BDOS_Code=b.BDOS_Code and BDOS_Name like '%" + TxtAddDep.Text.Trim() + "%'";

        Label67.Text = "检索后";
        UpdatePanel7.Update();
        BindGridGridView_ItemAll(Condition3);
    }//检索
    protected void Button7_Click(object sender, EventArgs e)
    {
        TxtAddCourse.Text = "";
        TxtAddType.Text = "";
        TxtAddDep.Text = "";
        Label67.Text = "检索前";
        BindGridGridView_ItemAll("");
        UpdatePanel7.Update();
    }//重置

    protected void CbxAll_CheckedChanged(object sender, EventArgs e)
    {
        CbxAllNO.Checked = false;
        CbxReverse.Checked = false;
        for (int i = 0; i <= GridView_ItemAll.Rows.Count - 1; i++)
        {
            CheckBox cbox = (CheckBox)GridView_ItemAll.Rows[i].FindControl("CheckBox1");

            if (CbxAll.Checked)
            {
                cbox.Checked = true;
            }
        }
    }//全选
    protected void CbxAllNO_CheckedChanged(object sender, EventArgs e)
    {
        CbxAll.Checked = false;
        CbxReverse.Checked = false;

        for (int i = 0; i <= GridView_ItemAll.Rows.Count - 1; i++)
        {
            if (CbxAllNO.Checked)
            {
                CheckBox cbox = (CheckBox)GridView_ItemAll.Rows[i].FindControl("CheckBox1");
                cbox.Checked = false;
            }
        }
    }//全不选
    protected void CbxReverse_CheckedChanged(object sender, EventArgs e)
    {
        CbxAll.Checked = false;
        CbxAllNO.Checked = false;
        for (int i = 0; i <= GridView_ItemAll.Rows.Count - 1; i++)
        {
            CheckBox cbox = (CheckBox)GridView_ItemAll.Rows[i].FindControl("CheckBox1");
            if (CbxReverse.Checked)
            {
                if (!cbox.Checked)
                {
                    cbox.Checked = true;
                }
                else
                    cbox.Checked = false;
            }
        }
    }//反选
    protected void BtnSubmitItem_Click(object sender, EventArgs e)
    {
        NewEmpInfoAddInfo neiai = new NewEmpInfoAddInfo();
        int count = 0;
        try
        {
            neiai.NETICT_ID = new Guid();
            neiai.NETIMT_ID = new Guid(LblRecordID2.Text);
            for (int i = 0; i < GridView_ItemAll.Rows.Count; i++)
            {
                CheckBox cbox = (CheckBox)GridView_ItemAll.Rows[i].FindControl("CheckBox1");
                if (cbox.Checked)
                {
                    count += 1;
                    neiai.NETI_ID = new Guid(GridView_ItemAll.Rows[i].Cells[0].Text.ToString());
                    neiaL.Insert_NETraItemChooseTable(neiai);
                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('提交失败！" + ex.ToString() + "')", true);
        }
        if (count == 0)
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请选择需要添加的培训项目！')", true);
            return;
        }
        BindGridGridView_ItemIn("");
        BindGridGridView_ItemAll("");
        GridView_ItemAll.SelectedIndex = -1;
        UpdatePanel7.Update();
        UpdatePanel6.Update();
        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('提交成功！')", true);
    }//提交
    protected void BtnCancelItem_Click(object sender, EventArgs e)
    {
        Panel7.Visible = false;
        UpdatePanel7.Update();
    }//关闭
    #endregion




    #region//GridView_ItemAll的内置事件
    protected void GridView_ItemAll_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView_ItemAll_DataBound(object sender, EventArgs e)
    {

    }
    protected void GridView_ItemAll_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView_ItemAll.BottomPagerRow;


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
        if (Label67.Text == "检索前")
        {
            BindGridGridView_ItemAll("");

        }
        if (Label67.Text == "检索后")
        {
            BindGridGridView_ItemAll(Condition3);
        }
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView_ItemAll.PageCount ? GridView_ItemAll.PageCount - 1 : newPageIndex;
        GridView_ItemAll.PageIndex = newPageIndex;
        GridView_ItemAll.DataBind();
    }
    protected void GridView_ItemAll_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    #endregion
}