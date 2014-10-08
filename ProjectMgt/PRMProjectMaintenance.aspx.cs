using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

public partial class ProjectManagement_PRMProjectMaintenance : Page
{
    PRMProjectinfo PRMProjectinfo = new PRMProjectinfo();
    PRMProjectMaintenanceL ppm = new PRMProjectMaintenanceL();
    PRMProjectL prp = new PRMProjectL();
    PRMProjectScheduleL pl = new PRMProjectScheduleL();
    protected void Page_Load(object sender, EventArgs e)
    { if (!((Session["UserRole"].ToString().Contains("项目进度维护"))))
                {
                    Response.Redirect("~/Default.aspx");
                }
                ClosePanel();
                UpdatePanel_Pschedule.Update();
        if (!IsPostBack)
        {
           
            Title = "项目进度维护";
            Gridview_ProjectInfo.Columns[9].Visible = false;
            //this.Panel_ProjectSearch.Visible = true;
            string condition = " and PRMP_ProjectStates='" + "进度设置完成" + "'" + " or PRMP_ProjectStates='" + "进行中" + "'" + " or PRMP_ProjectStates='" + "进度延期" + "'" ;
            BindGridView_Projectinfo(condition);
            Panel_ProjectInfo.Visible = true;
            //this.UpdatePanel_ProjectInfo.Update();
            //try 
            //{ 
               
            //}
            //catch (Exception)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('可能您没有权限操作和查看本页面，请退出选择其他账号登陆，或联系管理员！')", true);
            //    Response.Redirect("~/Default.aspx");
            //}
            label_pagestate.Text = Request.QueryString["state"];
            string state = label_pagestate.Text;
            if (state == "Look")
            {
                Title = "项目进度查看";
                Gridview_ProjectInfo.Columns[10].Visible = false;//进度维护
                Gridview_ProjectInfo.Columns[9].Visible = true;
            }
        }
    }
    //项目列表绑定
    private void BindGridView_Projectinfo(string Condition)
    {
        Gridview_ProjectInfo.DataSource = ppm.SelectPRMProject_Maintenance(Condition);
        Gridview_ProjectInfo.DataBind();

    }
    //进度明细表绑定
    private void BindGridview2(PRMProjectinfo PRMProjectinfo)
    {
        Gridview2.DataSource = ppm.SelectPRMProject_Schedule(PRMProjectinfo);
        Gridview2.DataBind();
    }
    //检索项目
    protected void Button1_Sh(object sender, EventArgs e)
    {
        string Condition = GetCondition();
        BindGridView_Projectinfo(Condition);
        Panel_ProjectInfo.Visible = true;
        UpdatePanel_ProjectInfo.Update();
        Panel2.Visible = false;
        UpdatePanel2.Update();
        Panel_Postpone.Visible = false;
        UpdatePanel_Postpone.Update();
        Panel_Pschedule.Visible = false;
        UpdatePanel_Pschedule.Update();
        Panel3.Visible = false;
        UpdatePanel3.Update();
        Panel_WorkOrder.Visible = false;
        UpdatePanel_WorkOrder.Update();
        Panel1.Visible = false;
        UpdatePanel1.Update();

    }
    protected string GetCondition()
    {
        string Condition;
        string item = "";
        if (DropDownList1.Text.ToString() != "请选择")
        {
            item += " and PRMP_ProjectType='" + DropDownList1.SelectedValue.ToString() + "'";
        }
        if (DropDownList4.Text.ToString() != "请选择")
        {
            item += " and PRMP_Sample='" + DropDownList4.SelectedValue.ToString() + "'";
        }
        if (ProjectName.Text.ToString() != "")
        {
            item += " and PRMP_ProjectName  like '%" + ProjectName.Text.ToString() + "%'";
        }
        if (TextBox1.Text.ToString() != "")
        {
            item += "and PRMP_ProductMode like '%" + TextBox1.Text.ToString() + "%'";
        }
        if (PRMP_ID.Text.ToString() != "")
        {
            item += "and PRMP_ProjectNum='" + PRMP_ID.Text.ToString() + "'";
        }
        Condition = item;
        labelcodition.Text = Condition;
        return Condition;
    }
    protected void Button1_Reset(object sender, EventArgs e)
    {
        string condition = " and PRMP_ProjectStates='" + "进度设置完成" + "'" + " or PRMP_ProjectStates='" + "进行中" + "'" + " or PRMP_ProjectStates='" + "进度延期" + "'" + " or PRMP_ProjectStates='" + "已完成" + "'";
        BindGridView_Projectinfo(condition);
        Panel_ProjectInfo.Visible = true;
        UpdatePanel_ProjectInfo.Update();
        TextBox1.Text = "";
        PRMP_ID.Text = "";
        DropDownList1.SelectedValue = "请选择";
        DropDownList4.SelectedValue = "请选择";
        ProjectName.Text = "";
    }
    //填写进度和延期设置
    protected void Gridview_ProjectInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Check1")//进度维护
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview_ProjectInfo.SelectedIndex = row.RowIndex;
             string sg="";
            label_projectid.Text = Convert.ToString(e.CommandArgument);
            Guid pps = new Guid(label_projectid.Text);
            DataSet ds = prp.SelectPRMProject_One(pps);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
               
                sg=dt.Rows[0][9].ToString();
            }
            if(Session["Department"].ToString()==sg)
            {
            TextBox2.Text = Gridview_ProjectInfo.Rows[row.RowIndex].Cells[1].Text.ToString().Trim().Replace("&nbsp;", "");
            if (Gridview_ProjectInfo.Rows[row.RowIndex].Cells[7].Text == "已完成")
            {
                Gridview2.Columns[15].Visible = false;
                Gridview2.Columns[16].Visible = false;
            }
            else
            {
                Gridview2.Columns[15].Visible = true;
                Gridview2.Columns[16].Visible = true;
            }
            label_projectid.Text = Convert.ToString(e.CommandArgument);
            PRMProjectinfo.PRMP_ID = new Guid(label_projectid.Text);
            BindGridview2(PRMProjectinfo);
            Panel2.Visible = true;
            UpdatePanel2.Update();
            }
            else 
            {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "aa", "alert('抱歉，你没有此权限！')", true);
            return;
            }
        }
        if (e.CommandName == "LookP")//查看进度
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview_ProjectInfo.SelectedIndex = row.RowIndex;
            
            Gridview2.Columns[15].Visible = false;//延期
            Gridview2.Columns[16].Visible = false;//维护

            label_projectid.Text = Convert.ToString(e.CommandArgument);
            PRMProjectinfo.PRMP_ID = new Guid(label_projectid.Text);
            BindGridview2(PRMProjectinfo);
            Panel2.Visible = true;
            UpdatePanel2.Update();
        }
    }
    //延期设置提交
    protected void Button2_Sh(object sender, EventArgs e)
    {
        if (TextBox5.Text.ToString() == "")
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_Postpone, GetType(), "aa", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        else
        {
            PRMProjectinfo.PRMPS_RelayDay = Convert.ToInt32(TextBox5.Text.ToString());
        }
        if (TextBox6.Text.ToString() == "")
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_Postpone, GetType(), "aa", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        else
        {
            PRMProjectinfo.PRMPS_RelayReason = TextBox6.Text.ToString();
        }
        // this.label_projectstate.Text = "延期";
        Guid gd = new Guid(label_projectid.Text.ToString());
        PRMProjectinfo.PRMP_ID = gd;
        Guid prm = new Guid(Label_SchduleID.Text.ToString());
        PRMProjectinfo.PRMPS_ID = prm;
        PRMProjectinfo.PRMPS_RelayMan = Session["UserName"].ToString().Trim();
        ppm.InsertPRMProject_Postpone(PRMProjectinfo);
        //string hl=this.TextBox3.Text.ToString()+"延期";
        string hl = "进度延期";
        prp.UpdatePRMP_ProjectStates(gd, hl);
        Panel_Postpone.Visible = false;
        UpdatePanel_Postpone.Update();
        TextBox5.Text = "";
        TextBox6.Text = "";
       
        UpdatePanel_ProjectInfo.Update();
        PRMProjectinfo.PRMP_ID = new Guid(label_projectid.Text);
        BindGridview2(PRMProjectinfo);
        UpdatePanel2.Update();
        string condition = " and PRMP_ProjectStates='" + "进度设置完成" + "'" + " or PRMP_ProjectStates='" + "进行中" + "'" + " or PRMP_ProjectStates='" + "进度延期" + "'" + " or PRMP_ProjectStates='" + "已完成" + "'";
        BindGridView_Projectinfo(condition);
        UpdatePanel_ProjectInfo.Update();
    }
    protected void Button2_Cancel(object sender, EventArgs e)
    {
        Panel_Postpone.Visible = false;
        UpdatePanel_Postpone.Update();
    }
    protected void Gridview_ProjectInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;
            if (drv["PRMP_ProjectStates"].ToString().Trim() == "进度延期")
            {
                e.Row.BackColor = Color.SkyBlue;

            }
            if (drv["PRMP_ProjectStates"].ToString().Trim() == "进行中" || drv["PRMP_ProjectStates"].ToString().Trim() == "进度延期" || drv["PRMP_ProjectStates"].ToString().Trim() == "进度设置完成" || drv["PRMP_ProjectStates"].ToString().Trim() == "责任部门验收审核驳回" || drv["PRMP_ProjectStates"].ToString().Trim() == "验收会签驳回" || drv["PRMP_ProjectStates"].ToString().Trim() == "技术副总驳回批准")
            {
                e.Row.Cells[10].Enabled = true;
            }
            else
            {
                e.Row.Cells[10].Enabled = false;
            }
            //if (drv["PRMP_ResponDepart"].ToString().Trim() != Session["Department"].ToString())
            //{
            //    e.Row.Cells[10].Enabled = false;
            //}
            
            
        }
    }
    //随工单表绑定
    private void BindGridview_WorkOrder(string Condition)
    {
        Gridview_WorkOrder.DataSource = ppm.SelectPRMProject_WOrder_One(Condition);
        Gridview_WorkOrder.DataBind();
    }
    //检索所有随工单
    protected void Button1_FD(object sender, EventArgs e)
    {
        Panel3.Visible = true;
        UpdatePanel3.Update();
        BindGridview_WorkOrder("");
        Panel_WorkOrder.Visible = true;
        UpdatePanel_WorkOrder.Update();

    }
    //根据条件检索具体随工单
    protected void Button1_Fd(object sender, EventArgs e)
    {
        string Condition = GetCondition_One();
        BindGridview_WorkOrder(Condition);
        UpdatePanel_WorkOrder.Update();

    }
    protected string GetCondition_One()
    {
        string Condition;
        string item = "";

        if (TextBox_SPTime2.Text.ToString() != "" && TextBox13.Text.ToString() != "")
        {
            item += "and WO_Time>='" + TextBox_SPTime2.Text.ToString() + "' and WO_Time<='" + TextBox13.Text.ToString() + "'";
        }
        if (TextBox_SPTime2.Text.ToString() != "")
        {
            item += "and WO_Time>='" + TextBox_SPTime2.Text.ToString() + "'";
        }

        if (TextBox12.Text.ToString() != "")
        {
            item += " and WO_ProType  like '%" + TextBox12.Text.ToString() + "%'";
        }
        Condition = item;
        label16.Text = Condition;
        return Condition;
    }
    protected void Button3_CC(object sender, EventArgs e)
    {
        TextBox12.Text = "";
        TextBox_SPTime2.Text = "";
        TextBox13.Text = "";
        Panel3.Visible = false;
        UpdatePanel3.Update();
        Panel_WorkOrder.Visible = false;
        UpdatePanel_WorkOrder.Update();
    }
    //选择随工单
    protected void Button1_Com(object sender, EventArgs e)
    {

        bool temp = false;
        string Pname = "";
        bool bl = false;
        Guid gd = new Guid(Label_SchduleID.Text.ToString());
        DataSet ds = pl.SelectPRMProjectSchedule_One(gd);
        DataTable dt = ds.Tables[0];
        string str = "";
        if (dt.Rows.Count > 0)
        {
            str = dt.Rows[0][4].ToString();
        }
        string[] sArray = Regex.Split(str, ";", RegexOptions.IgnoreCase);

        foreach (GridViewRow item in Gridview_WorkOrder.Rows)
        {
            CheckBox cb = item.FindControl("CheckBox1") as CheckBox;
            if (cb.Checked)
            {
                foreach (string i in sArray)
                {
                    if (Gridview_WorkOrder.DataKeys[item.RowIndex].Value.ToString() == i)
                    {
                        bl = true;
                        ScriptManager.RegisterClientScriptBlock(UpdatePanel_WorkOrder, GetType(), "aa", "alert('已重复选择随工单！')", true);
                        return;

                    }

                }
                if (!bl)
                {

                    Pname += Gridview_WorkOrder.DataKeys[item.RowIndex].Value.ToString() + ";";
                    temp = true;
                    Label_Pname.Text = Pname;
                }

            }
        }


        TextBox10.Text = TextBox10.Text + Label_Pname.Text.ToString();
        UpdatePanel_Pschedule.Update();
        if (!temp)
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_WorkOrder, GetType(), "aa", "alert('请选择随工单')", true);
            return;
        }
        else
        {
            TextBox12.Text = "";
            TextBox_SPTime2.Text = "";
            TextBox13.Text = "";
            Panel3.Visible = false;
            UpdatePanel3.Update();
            Panel_WorkOrder.Visible = false;
            UpdatePanel_WorkOrder.Update();
        }
    }
    protected void Button1_Cancel(object sender, EventArgs e)
    {
        TextBox12.Text = "";
        TextBox_SPTime2.Text = "";
        TextBox13.Text = "";
        Panel3.Visible = false;
        UpdatePanel3.Update();
        Panel_WorkOrder.Visible = false;
        UpdatePanel_WorkOrder.Update();
    }

    //protected void ok_upload_Click()
    //{
    //    string fileExrensio = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();//ToLower转化为小写,获得扩展名
    //    string UploadURL = Server.MapPath("~/file/");//上传的目录
    //    string fullname = FileUpload1.FileName;//上传文件的原名
    //    string newname = System.DateTime.Now.ToString("yyyyMMddhhmmss");//上传文件重命名
    //    if (this.FileUpload1.PostedFile.FileName != null)
    //    {
    //        if (fileExrensio == ".doc" || fileExrensio == ".docx" || fileExrensio == ".pdf" || fileExrensio == ".xls" || fileExrensio == ".xlsx" || fileExrensio == ".txt")//判断文件扩展名
    //        {
    //            try
    //            {
    //                if (!System.IO.Directory.Exists(UploadURL))//判断文件夹是否已经存在
    //                {
    //                    System.IO.Directory.CreateDirectory(UploadURL);//创建文件夹
    //                }
    //                FileUpload1.PostedFile.SaveAs(UploadURL + newname + fullname);//保存上传的文件
    //            }
    //            catch
    //            {
    //                ScriptManager.RegisterClientScriptBlock(UpdatePanel_Pschedule, this.GetType(), "aa", "alert('上传失败!')", true);
    //                return;
    //            }
    //        }
    //        else
    //        {
    //            ScriptManager.RegisterClientScriptBlock(UpdatePanel_Pschedule, this.GetType(), "aa", "alert('不支持此文件格式!')", true);
    //            return;
    //        }
    //    }
    //    else
    //    {
    //        ScriptManager.RegisterClientScriptBlock(UpdatePanel_Pschedule, this.GetType(), "aa", "alert('请选择文件!')", true);
    //        return;
    //    }

    //    string filePath = "file/" + newname + fullname;
    //    this.Label_FilePath.Text = filePath;//相对路径
    //    this.LabelQ_SaveDirectory.Text = "上传";
    //    //ClosePanel();
    //    this.UpdatePanel_Pschedule.Update();
    //}

    private void ShowPanel()//显示上传实验报告框
    {
        string script = "document.getElementById('Panel4').style.display='';";
        ScriptManager.RegisterStartupScript(Page, GetType(), "ShowPanel", script, true);
        TextBox14.Text = label_AccNum.Text;
        TextBox15.Text =label_AccName.Text;
        UpdatePanel4.Update();
    }

    private void ClosePanel()//关闭上传实验报告框
    {
        string script = "document.getElementById('Panel4').style.display='none';";
        ScriptManager.RegisterStartupScript(Page, GetType(), "ClosePanel", script, true);
    }

    //protected void Button1_TJ(object sender, EventArgs e)
    //{
    //    ClosePanel();
    //   // ShowPanel();
    //}

    //进度填写提交
    protected void Button1_TJWH(object sender, EventArgs e)
    {
        if (DropDownList3.Text.ToString() != "请选择")
        {
            PRMProjectinfo.PRMPS_ScheduleFinish = DropDownList3.SelectedValue.ToString();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_Pschedule, GetType(), "aa", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (TextBox10.Text.ToString() != "")
        {
            PRMProjectinfo.PRMPS_WorkOrderNum = TextBox10.Text.ToString();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_Pschedule, typeof(Page), "aa", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (TextBox11.Text.ToString() != "")
        {
            PRMProjectinfo.PRMPS_ProcessCondition = TextBox11.Text.ToString();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_Pschedule, GetType(), "aa", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
         //    //ok_upload_Click();


        Guid gd = new Guid(Label_SchduleID.Text);
        PRMProjectinfo.PRMPS_ID = gd;

        if (LabelQ_SaveDirectory.Text != "上传")
        {
            PRMProjectinfo.PRMPS_Accessory = "否";
            PRMProjectinfo.PRMPS_AccNum = "";
            PRMProjectinfo.PRMPS_AccName = "";
        }
        else
            if (LabelQ_SaveDirectory.Text == "上传")
        {
                PRMProjectinfo.PRMPS_Accessory = "是";
                PRMProjectinfo.PRMPS_AccNum = label_AccNum.Text.ToString();
                PRMProjectinfo.PRMPS_AccName = label_AccName.Text.ToString();
        }

        PRMProjectinfo.PRMPS_AccessoryPath = Label_FilePath.Text;
        PRMProjectinfo.PRMPS_ProcessMan = Session["UserName"].ToString().Trim();
        ppm.InsertPRMProject_Schedule(PRMProjectinfo);
        Guid lp = new Guid(label_projectid.Text.ToString());
        PRMProjectinfo.PRMP_ID = lp;
        BindGridview2(PRMProjectinfo);
        int i = 0;
        bool lio=false ;
        foreach (GridViewRow item in Gridview2.Rows)
        {
            if (item.Cells[5].Text == "是")
            {
                i++;
            }
            if(item.Cells[9].Text == "是")
            {
            lio=true;
            }
        }
        
        if (i == Gridview2.Rows.Count)
        {
            prp.UpdatePRMP_ProjectStates(lp, "已完成");
        }
        else
            if(lio)
        {
            prp.UpdatePRMP_ProjectStates(lp, "进度延期");
        }
        else 
                if(!lio)
                {
                    prp.UpdatePRMP_ProjectStates(lp, "进行中");
                }
        BindGridview2(PRMProjectinfo);
        UpdatePanel2.Update();
        string condition = " and PRMP_ProjectStates='" + "进度设置完成" + "'" + " or PRMP_ProjectStates='" + "进行中" + "'" + " or PRMP_ProjectStates='" + "进度延期" + "'" + " or PRMP_ProjectStates='" + "已完成" + "'";
        BindGridView_Projectinfo(condition);
        UpdatePanel_ProjectInfo.Update();
        TextBox7.Text = "";
        TextBox8.Text = "";
        TextBox9.Text = "";
        TextBox14.Text = "";
        TextBox15.Text = "";
        TextBox10.Text = "";
        TextBox11.Text = "";
        DropDownList3.SelectedValue = "请选择";
        Panel_Pschedule.Visible = false;
        UpdatePanel_Pschedule.Update();
        PRMProjectinfo.PRMP_ID = new Guid(label_projectid.Text);
        BindGridview2(PRMProjectinfo);
        UpdatePanel2.Update();
        string condition1 = " and PRMP_ProjectStates='" + "进度设置完成" + "'" + " or PRMP_ProjectStates='" + "进行中" + "'" + " or PRMP_ProjectStates='" + "进度延期" + "'" + " or PRMP_ProjectStates='" + "已完成" + "'";
        BindGridView_Projectinfo(condition1);
        UpdatePanel_ProjectInfo.Update();

        Panel3.Visible = false;
        UpdatePanel3.Update();
        Panel_WorkOrder.Visible = false;
        UpdatePanel_WorkOrder.Update();
        //this.LabelQ_SaveDirectory.Text = "";
        //this.Label_FilePath.Text = "";

    }

    #region//换页
    //项目列表
    protected void Gridview_ProjectInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview_ProjectInfo.BottomPagerRow;


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
        string condition = GetCondition();
        BindGridView_Projectinfo(condition);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview_ProjectInfo.PageCount ? Gridview_ProjectInfo.PageCount - 1 : newPageIndex;
        Gridview_ProjectInfo.PageIndex = newPageIndex;
        Gridview_ProjectInfo.DataBind();


    }
    //项目进度明细
    protected void Gridview_PS_PageIndexChanging(object sender, GridViewPageEventArgs e)
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
        PRMProjectinfo.PRMP_ID = new Guid(label_projectid.Text.ToString());
        BindGridview2(PRMProjectinfo);
        Gridview2.DataSource = ppm.SelectPRMProject_Schedule(PRMProjectinfo);
        Gridview2.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview2.PageCount ? Gridview2.PageCount - 1 : newPageIndex;
        Gridview2.PageIndex = newPageIndex;
        Gridview2.DataBind();
    }
    //随工单
    protected void Gridview_WorkOrder_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview_WorkOrder.BottomPagerRow;


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
        BindGridview_WorkOrder("");
        Gridview_WorkOrder.DataSource = ppm.SelectPRMProject_WOrder_One("");
        Gridview_WorkOrder.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview_WorkOrder.PageCount ? Gridview_WorkOrder.PageCount - 1 : newPageIndex;
        Gridview_WorkOrder.PageIndex = newPageIndex;
        Gridview_WorkOrder.DataBind();
    }
    protected void Gridview1_PageIndexChanging(object sender, GridViewPageEventArgs e)
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
        BindGridview1(labelcondition.Text);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview1.PageCount ? Gridview1.PageCount - 1 : newPageIndex;
        Gridview1.PageIndex = newPageIndex;
        Gridview1.DataBind();
    }
    #endregion
    protected void Button_Cancel(object sender, EventArgs e)
    {
        Panel_Pschedule.Visible = false;
        UpdatePanel_Pschedule.Update();
        Panel3.Visible = false;
        UpdatePanel3.Update();
        Panel_WorkOrder.Visible = false;
        UpdatePanel_WorkOrder.Update();
    }

    protected void Gridview_ProjectInfo_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Gridview_ProjectInfo.Rows.Count; i++)
        {
            for (int j = 0; j < Gridview_ProjectInfo.Rows[i].Cells.Count; j++)
            {
                Gridview_ProjectInfo.Rows[i].Cells[j].ToolTip = Gridview_ProjectInfo.Rows[i].Cells[j].Text;
                if (Gridview_ProjectInfo.Rows[i].Cells[j].Text.Length > 15)
                {
                    Gridview_ProjectInfo.Rows[i].Cells[j].Text = Gridview_ProjectInfo.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }
            }
        }
    }
    //项目进度表
    protected void Gridview2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Lay")//延期
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview2.SelectedIndex = row.RowIndex;
            Label_SchduleID.Text = e.CommandArgument.ToString();
            Guid gd = new Guid(Label_SchduleID.Text.ToString());
            DataSet ds = pl.SelectPRMProjectSchedule_One(gd);
            DataTable dt = ds.Tables[0];

            if (dt.Rows.Count > 0)
            {
                TextBox6.Text = dt.Rows[0][5].ToString();
            }
            TextBox4.Text = Gridview2.Rows[row.RowIndex].Cells[2].Text.ToString().Trim().Replace("&nbsp;", "");
            //this.TextBox2.Text = this.Gridview_ProjectInfo.Rows[row.RowIndex].Cells[1].Text.ToString().Trim().Replace("&nbsp;", "");
            TextBox3.Text = Gridview2.Rows[row.RowIndex].Cells[1].Text.ToString().Trim().Replace("&nbsp;", "");
            TextBox5.Text = Gridview2.Rows[row.RowIndex].Cells[10].Text.ToString().Trim().Replace("&nbsp;", "");
            //this.TextBox6.Text = this.Gridview2.Rows[row.RowIndex].Cells[10].Text.ToString().Trim().Replace("&nbsp;", "");
            Panel_Postpone.Visible = true;
            UpdatePanel_Postpone.Update();
            Panel_Pschedule.Visible = false;
            UpdatePanel_Pschedule.Update();
            Panel1.Visible = false;
            UpdatePanel1.Update();
            Panel3.Visible = false;
            UpdatePanel3.Update();
            Panel_WorkOrder.Visible = false;
            UpdatePanel_WorkOrder.Update();
        }
        if (e.CommandName == "Protect")//维护
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview2.SelectedIndex = row.RowIndex;
            Label_SchduleID.Text = e.CommandArgument.ToString();
            Guid gd = new Guid(Label_SchduleID.Text.ToString());
            DataSet ds = pl.SelectPRMProjectSchedule_One(gd);
            DataTable dt = ds.Tables[0];
            Panel_Pschedule.Visible = true;
            if (dt.Rows.Count > 0)
            {
                TextBox10.Text = dt.Rows[0][4].ToString();
                TextBox11.Text = dt.Rows[0][6].ToString();
                label_AccNum.Text= dt.Rows[0][7].ToString();
                label_AccName.Text = dt.Rows[0][8].ToString();
                Label_FilePath.Text = dt.Rows[0][9].ToString();
                if (Label_FilePath.Text.ToString()!="")
                {
                LabelQ_SaveDirectory.Text = "上传";
                }
            }
            TextBox7.Text = Gridview2.Rows[row.RowIndex].Cells[2].Text.ToString().Replace("&nbsp;", "");
            TextBox8.Text = Gridview_ProjectInfo.Rows[Gridview_ProjectInfo.SelectedIndex].Cells[1].Text.ToString().Replace("&nbsp;", "");
            TextBox9.Text = Gridview2.Rows[row.RowIndex].Cells[1].Text.ToString().Replace("&nbsp;", "");
            DropDownList3.SelectedValue = Gridview2.Rows[row.RowIndex].Cells[5].Text.ToString().Replace("&nbsp;", "");
            //this.TextBox14.Text = this.Gridview2.Rows[row.RowIndex].Cells[11].Text.ToString().Replace("&nbsp;", "");
            //this.TextBox15.Text = this.Gridview2.Rows[row.RowIndex].Cells[12].Text.ToString().Replace("&nbsp;", "");
            //this.TextBox10.Text = this.Gridview2.Rows[row.RowIndex].Cells[6].Text.ToString().Replace("&nbsp;", "");
            //this.TextBox11.Text = this.Gridview2.Rows[row.RowIndex].Cells[5].Text.ToString().Replace("&nbsp;", "");
            //ShowPanel();
            UpdatePanel_Pschedule.Update();
           
            Panel_Postpone.Visible = false;
            UpdatePanel_Postpone.Update();

            Panel1.Visible = false;
            UpdatePanel1.Update();

        }
        if (e.CommandName == "Look")//附件证明查看
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview2.SelectedIndex = row.RowIndex;
            Label_SchduleID.Text = e.CommandArgument.ToString();
        }
        if (e.CommandName == "Follow")//随工单跟踪
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview2.SelectedIndex = row.RowIndex;
            Label_SchduleID.Text = e.CommandArgument.ToString();
            string item = "";
            Guid gd = new Guid(Label_SchduleID.Text.ToString());
            DataSet ds = pl.SelectPRMProjectSchedule_One(gd);
            DataTable dt = ds.Tables[0];
            string str = "";
            if (dt.Rows.Count > 0)
            {
                str = dt.Rows[0][4].ToString();
            }

            string[] sArray = Regex.Split(str, ";", RegexOptions.IgnoreCase);
            for (int i = 0; i < sArray.Length; i++)
            {
                if (i == 0)
                {
                    item = "and WO_Num='" + sArray[0] + "'";
                }
                else
                {
                    item += " or WO_Num='" + sArray[i] + "'";
                }
            }
            labelcondition.Text = item;
            BindGridview1(labelcondition.Text);
            Panel1.Visible = true;
            UpdatePanel1.Update();
            Panel_Postpone.Visible = false;
            UpdatePanel_Postpone.Update();
            Panel_Pschedule.Visible = false;
            UpdatePanel_Pschedule.Update();

            Panel3.Visible = false;
            UpdatePanel3.Update();
            Panel_WorkOrder.Visible = false;
            UpdatePanel_WorkOrder.Update();
        }
    }
    private void BindGridview1(string condition)
    {
        Gridview1.DataSource = ppm.SelectPRMProject_WOrder_Protect(condition);
        Gridview1.DataBind();
    }
    //关闭进度表
    protected void ButtonPClose(object sender, EventArgs e)
    {
        Panel2.Visible = false;
        UpdatePanel2.Update();
        Panel_Postpone.Visible = false;
        UpdatePanel_Postpone.Update();
        Panel_Pschedule.Visible = false;
        UpdatePanel_Pschedule.Update();
        Panel3.Visible = false;
        UpdatePanel3.Update();
        Panel_WorkOrder.Visible = false;
        UpdatePanel_WorkOrder.Update();
        Panel1.Visible = false;
        UpdatePanel1.Update();
    }
    //关闭随工单列表
    protected void ButtonCClose(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        UpdatePanel1.Update();
    }

    protected void Gridview2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            DataRowView drv = (DataRowView)e.Row.DataItem;
            if (drv["PRMPS_Accessory"].ToString().Trim() == "是")
            {
                e.Row.Cells[16].Enabled = true;
            }
            else
            {
                e.Row.Cells[16].Enabled = false;
            }

        }

    }
    protected void Gridview2_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Gridview2.Rows.Count; i++)
        {
            for (int j = 0; j < Gridview2.Rows[i].Cells.Count; j++)
            {
                Gridview2.Rows[i].Cells[j].ToolTip = Gridview2.Rows[i].Cells[j].Text;
                if (Gridview2.Rows[i].Cells[j].Text.Length > 30)
                {
                    Gridview2.Rows[i].Cells[j].Text = Gridview2.Rows[i].Cells[j].Text.Substring(0, 30) + "...";
                }
            }
        }
    }
    protected void Gridview_WorkOrder_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Gridview_WorkOrder.Rows.Count; i++)
        {
            for (int j = 0; j < Gridview_WorkOrder.Rows[i].Cells.Count; j++)
            {
                Gridview_WorkOrder.Rows[i].Cells[j].ToolTip = Gridview_WorkOrder.Rows[i].Cells[j].Text;
                if (Gridview_WorkOrder.Rows[i].Cells[j].Text.Length > 15)
                {
                    Gridview_WorkOrder.Rows[i].Cells[j].Text = Gridview_WorkOrder.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }
            }
        }
    }
    protected void Gridview1_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Gridview1.Rows.Count; i++)
        {
            for (int j = 0; j < Gridview1.Rows[i].Cells.Count; j++)
            {
                Gridview1.Rows[i].Cells[j].ToolTip = Gridview1.Rows[i].Cells[j].Text;
                if (Gridview1.Rows[i].Cells[j].Text.Length > 15)
                {
                    Gridview1.Rows[i].Cells[j].Text = Gridview1.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                }
            }
        }
    }
    protected void Button_Aline(object sender, EventArgs e)
    {
        ShowPanel();
        UpdatePanel4.Update(); 
    }
    protected void Button1_Fox(object sender, EventArgs e)
    {
        
        string fileExrensio = Path.GetExtension(FileUpload1.FileName).ToLower();//ToLower转化为小写,获得扩展名
        string UploadURL = Server.MapPath("~/file/");//上传的目录
        string fullname = FileUpload1.FileName;//上传文件的原名
        string newname = DateTime.Now.ToString("yyyyMMddhhmmss");//上传文件重命名

        if (FileUpload1.PostedFile.FileName != "" || FileUpload1.PostedFile.FileName != null)
        {
            if (fileExrensio == ".doc" || fileExrensio == ".docx" || fileExrensio == ".pdf" || fileExrensio == ".xls" || fileExrensio == ".xlsx" || fileExrensio == ".txt" || fileExrensio == ".ppt" || fileExrensio == ".pptx" || fileExrensio == ".rar" || fileExrensio == ".zip" || fileExrensio == ".bmp" || fileExrensio == ".jpg" || fileExrensio == ".gif")//判断文件扩展名
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
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel_Pschedule, GetType(), "aa", "alert('上传失败!')", true);
                    return;
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel_Pschedule, GetType(), "aa", "alert('不支持此文件格式!')", true);
                return;
            }
            string filePath = "file/" + newname + fullname;
 
            if (TextBox14.Text == "" || TextBox15.Text == "" || FileUpload1.PostedFile.FileName == "" || FileUpload1.PostedFile.FileName== null)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel4, GetType(), "aa", "alert('标记*的为必填项，请填写完整！')", true);
                return;
            }
            else
            {
                label_AccNum.Text= TextBox14.Text.ToString();
                label_AccName.Text = TextBox15.Text.ToString();
                Label_FilePath.Text = filePath;//相对路径
                LabelQ_SaveDirectory.Text = "上传";
               
                PRMProjectinfo.PRMP_ID = new Guid(label_projectid.Text);
                BindGridview2(PRMProjectinfo);
            ClosePanel();
            UpdatePanel4.Update();
            Panel_Pschedule.Visible = true;
            UpdatePanel_Pschedule.Update();

            }
        }
    }
    protected void Button1_Emi(object sender, EventArgs e)
    {
        TextBox14.Text = "";
        TextBox15.Text = "";

        ClosePanel();
        UpdatePanel4.Update();
    }
}



