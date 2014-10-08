using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TrainningMgt_NewEmpScoreInput : Page
{
    NewEmpInfoAddL neiaL = new NewEmpInfoAddL();
    NewEmpInfoAddInfo neiaInfo = new NewEmpInfoAddInfo();
    private static string Condition1;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Username"] == null)
        {
            Response.Write("<script>alert('您长时间未操作，请重新登录！');window.location.href='~/Default.aspx';</script>");
        }
        #region//权限控制

        if (!((Session["UserRole"].ToString().Contains("新员工培训结果录入"))))
        {
            Response.Redirect("~/Default.aspx");

        }
        if (Request.QueryString["status"] == "ScoreInput")
        {
            Title = "新员工培训结果录入";
        }
        #endregion

        if (!IsPostBack)
        {
            BindGridView_Info("");
        }
    }

    #region//绑定Gridview的方法
    private void BindGridView_Info(string Condition)
    {
        GridView_Info.DataSource = neiaL.Search_NETraItemChooseTable_NETraEachItemResultDetail(Condition);
        GridView_Info.DataBind();
    }//新员工培训信息列表GridView_Info
    private void BindGridView_People(string Condition)
    {
        GridView_People.DataSource = neiaL.Search_ForPeopleChoose_NETraItemChooseTable(" and c.NETICT_ID= '" + LblRecordNETICT_ID.Text + "'" + Condition);
        GridView_People.DataBind();
    }//新员工培训信息列表GridView_People
    #endregion


    #region//新员工培训信息检索栏
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        Condition1 = TxtSCourse.Text.Trim() == "" ? " " : " and NETI_TraningCourse like '%" + TxtSCourse.Text.Trim() + "%'";
        Condition1 += TxtSType.Text.Trim() == "" ? " " : " and NETI_TraningType like '%" + TxtSType.Text.Trim() + "%'";
        Condition1 += TxtSDep.Text.Trim() == "" ? " " : " and BDOS_Name like '%" + TxtSDep.Text.Trim() + "%'";
        Condition1 += TxtSPerson.Text.Trim() == "" ? " " : " and NETIMT_Person like '%" + TxtSPerson.Text.Trim() + "%'";
        Condition1 += TxtSStartTime.Text.Trim() == "" ? " " : " and NETIMT_Time >='" + TxtSStartTime.Text.Trim() + "'";
        Condition1 += TxtSEndTime.Text.Trim() == "" ? " " : " and NETIMT_Time <='" + TxtSEndTime.Text.Trim() + "'";
        Condition1 += DropDownList2.Text == "请选择" ? " " : " and NETICT_State ='" + DropDownList2.Text + "'";
        LblRecordIsSearch.Text = "检索后";
        GridView_Info.SelectedIndex = -1;
        BindGridView_Info(Condition1);
        UpdatePanel2.Update();
    }//检索
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        TxtSCourse.Text = "";
        TxtSType.Text = "";
        TxtSDep.Text = "";
        TxtSPerson.Text = "";
        TxtSStartTime.Text = "";
        TxtSEndTime.Text = "";
        DropDownList2.ClearSelection();
        LblRecordIsSearch.Text = "检索前";
        GridView_Info.SelectedIndex = -1;
        BindGridView_Info("");
        UpdatePanel2.Update();
    }//重置
    #endregion


    #region//GridView_Info的内置事件
    protected void GridView_Info_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView_Info.Rows.Count; i++)
        {
            for (int j = 0; j < GridView_Info.Rows[i].Cells.Count; j++)
            {
                GridView_Info.Rows[i].Cells[j].ToolTip = GridView_Info.Rows[i].Cells[j].Text;
                if (GridView_Info.Rows[i].Cells[j].Text.Length > 15)
                {
                    GridView_Info.Rows[i].Cells[j].Text = GridView_Info.Rows[i].Cells[j].Text.Substring(0, 16) + "...";
                }
            }
        }
    }
    protected void GridView_Info_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
        if (e.CommandName == "EditInputScore")
        {
            GridView_Info.SelectedIndex = row.RowIndex;
            string st = row.Cells[7].Text.ToString();
            if (row.Cells[7].Text.ToString() != "待录入")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('您只能对待录入状态的信息进行录入！')", true);
                return;
            }
            Panel3.Visible = true;
            TxtSTime.Text = "";
            TxtETime.Text = "";
            TextBox1.Text = "";
            LblRecordNETICT_ID.Text = e.CommandArgument.ToString();
            BindGridView_People("");
            UpdatePane3.Update();
        }
    }
    protected void GridView_Info_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView_Info.BottomPagerRow;


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
            BindGridView_Info("");
        if (LblRecordIsSearch.Text == "检索后")
            BindGridView_Info(Condition1);

        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView_Info.PageCount ? GridView_Info.PageCount - 1 : newPageIndex;
        GridView_Info.PageIndex = newPageIndex;
        GridView_Info.DataBind();
    }
    #endregion


    #region//新员工培训的人员列表
    protected void BtnOK_Click(object sender, EventArgs e)
    {
        if (TxtSTime.Text == "" || TxtETime.Text == "" || TextBox1.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        NewEmpInfoAddInfo neiaInfo1 = null;//提交"按钮，插入新员工培训结果详情表
        NewEmpInfoAddInfo neiaInfo2 = new NewEmpInfoAddInfo();//"提交"按钮，更新新员工培训信息主表的状态
        NewEmpInfoAddInfo neiaInfo3 = new NewEmpInfoAddInfo();//"提交"按钮，更新该培训项目的信息
        DateTime d1;

        if (DateTime.TryParse(TxtSTime.Text, out d1))
            neiaInfo3.NETICT_STime = d1;
        else
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入格式正确的培训开始时间！')", true);
            return;
        }
        DateTime d2;

        if (DateTime.TryParse(TxtETime.Text, out d2))
            neiaInfo3.NETICT_ETime = d2;
        else
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入格式正确的培训结束时间！')", true);
            return;
        }
        if (neiaInfo3.NETICT_STime >= neiaInfo3.NETICT_ETime)
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('培训开始时间必须小于培训结束时间！')", true);
            return;
        }
        int count = GridView_People.Rows.Count;
        for (int i = 0; i < count; i++)
        {
            neiaInfo1 = new NewEmpInfoAddInfo();
            DropDownList ddl = GridView_People.Rows[i].FindControl("DropDownList1") as DropDownList;//取得所在行的是否合格的列
            TextBox tb = GridView_People.Rows[i].FindControl("TxtRemarks") as TextBox;//取得所在行的是否合格的列
            neiaInfo1.NETPCT_ID = new Guid(GridView_People.Rows[i].Cells[0].Text);
            neiaInfo1.NETICT_ID = new Guid(LblRecordNETICT_ID.Text);
            neiaInfo1.NETEIRD_IsQualified = ddl.SelectedValue;
            neiaInfo1.NETEIRD_Remark = tb.Text;
            neiaL.Insert_NETraEachItemResultDetail(neiaInfo1);
        }
        neiaInfo2.NETICT_ID = new Guid(LblRecordNETICT_ID.Text);
        neiaInfo2.NETIMT_State = "已完成";
        neiaL.Update_ForStateChange_NNETraInfoMainTable(neiaInfo2);

        neiaInfo3.NETICT_ID = new Guid(LblRecordNETICT_ID.Text);
        neiaInfo3.NETICT_Place = TextBox1.Text;
        neiaL.Update_ForTime_NETraItemChooseTable(neiaInfo3);

        BindGridView_Info("");
        UpdatePanel2.Update();
        Panel3.Visible = false;
        GridView_Info.SelectedIndex = -1;
        UpdatePane3.Update();
        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('已提交！')", true);


    }//提交
    protected void Btnclose_Click(object sender, EventArgs e)
    {
        Panel3.Visible = false;
        if (LblRecordIsSearch.Text == "检索前")
            BindGridView_Info("");
        if (LblRecordIsSearch.Text == "检索后")
            BindGridView_Info(Condition1);
        UpdatePane3.Update();
    }//取消
    #endregion
}