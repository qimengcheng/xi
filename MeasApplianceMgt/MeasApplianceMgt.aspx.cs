using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;
public partial class MeasApplianceMgt_MeasApplianceMgt : Page
{

    private MeasApplianceL measApplianceL = new MeasApplianceL();
    private MeasApplianceMan measApplianceMan = new MeasApplianceMan();
    private MeasApplianceDetail measApplianceDetail = new MeasApplianceDetail();
    private static string Condition;
    private static bool BlInto_S_Search;//标志位，用于标志是否是在检索状态下

    private static Guid temp;
    private static Guid ID_His;
    private static Guid ID_Edit;
    private static Guid ID_HisEdit;

    /// <summary>
    /// 函数名：IsMatchInt
    /// 作者：bush2582
    /// 作用：匹配字符串是否全为整数，且是否符合下界
    /// 返回值：是否符合条件
    /// </summary>
    /// <param name="WantToMatch">要匹配的字符串</param>
    /// <param name="Low">整数的下界</param>
    /// <returns>是否匹配</returns>
    public bool IsMatchInt(string WantToMatch, int Low)
    {
        if (Regex.IsMatch(WantToMatch, "^([0-9]{1,})$") == false)
        {
            return false;
        }
        else if ((Convert.ToInt32(WantToMatch) > Low))//匹配下界
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private int DateDiff(DateTime DateTime1, DateTime DateTime2)
    {
        string dateDiff = null;
        try
        {
            TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
            TimeSpan ts2 = new TimeSpan(DateTime2.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            dateDiff = ts.Days.ToString();// + "天";
                           // + ts.Hours.ToString() + "小时"
                            //+ ts.Minutes.ToString() + "分钟"
                           // + ts.Seconds.ToString() + "秒";
        }
        catch
        {

        }

        //dateDiff = dateDiff.Split('天')[0];
        return Convert.ToInt32(dateDiff);
        //return  dateDiff;
    }   



    protected void Page_Load(object sender, EventArgs e)
    {
        #region//权限控制
        Grid_MeasAppliance.Columns[7].Visible = false;
        ////if (!((Session["UserRole"].ToString().Contains("计量器具查看")) || (Session["UserRole"].ToString().Contains("计量器具维护"))))
        ////{
        ////    Response.Redirect("~/Default.aspx");

        ////}
        //if (Request.QueryString["state"].ToString() == "MeasAppliance" && Session["UserRole"].ToString().Contains("计量器具维护"))
        //{
        //    this.Title = "计量器具维护";
        //}
        //if (Session["UserRole"].ToString().Contains("计量器具查看"))
        //{
        //    this.Grid_MeasAppliance.Columns[11].Visible = false;
        //    this.Grid_MeasAppliance.Columns[12].Visible = false;
        //    this.Grid_MeasAppliance.Columns[14].Visible = false;
        //    this.Grid_History.Columns[6].Visible = false;
        //    this.Grid_History.Columns[7].Visible = false;
        //    this.BtnNew.Visible = false;
            
        //}
        try
        {
            //if (!((Session["UserRole"].ToString().Contains("计量器具查看")) || (Session["UserRole"].ToString().Contains("计量器具维护"))))
            //{
            //    Response.Redirect("~/Default.aspx");

            //} 
            if (Request.QueryString["state"].ToString() == "MeasAppliance" && Session["UserRole"].ToString().Contains("计量器具维护"))
            {
                Title = "计量器具维护";
            }
            if (Request.QueryString["state"].ToString() == "MeasApplianceLook" && Session["UserRole"].ToString().Contains("计量器具查看"))
            {
                Title = "计量器具查看";
                Grid_MeasAppliance.Columns[14].Visible = false;
                Grid_MeasAppliance.Columns[15].Visible = false;
                Grid_MeasAppliance.Columns[17].Visible = false;
                Grid_History.Columns[6].Visible = false;
                Grid_History.Columns[7].Visible = false;
                BtnNew.Visible = false;

            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('可能您没有权限操作和查看本页面，请退出选择其他账号登陆，或联系管理员！')", true);
            Response.Redirect("~/Default.aspx");
        }
        #endregion


        if (!IsPostBack)
        {
            BindGrid_MeasAppliance("");
        }
       
        
    }
    #region//绑定Gridview的方法
    private void BindGrid_MeasAppliance(string Condition)
    {
        Grid_MeasAppliance.DataSource = measApplianceL.Select_MeasApplianceMan(Condition);
        Grid_MeasAppliance.DataBind();
    }//计量器具检验列表Grid_MeasAppliance
    private void BindGrid_History(Guid id)
    {
        Grid_History.DataSource = measApplianceL.Select_MeasApplianceDetail(id);
        Grid_History.DataBind();
    }//计量器具检验列表Grid_MeasAppliance
    #endregion

    #region//检索条件
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        Grid_MeasAppliance.SelectedIndex = -1;
        Condition = TxtEquipName.Text.Trim() == "" ? " " : " and MAM_EquipName like '%" + TxtEquipName.Text.Trim() + "%'";
        Condition += TxtManuCode.Text.Trim() == "" ? " " : " and MAM_ManuCode like '%" + TxtManuCode.Text.Trim() + "%'";
        Condition += TxtLocation.Text.Trim() == "" ? " " : " and MAM_Location like '%" + TxtLocation.Text.Trim() + "%'";
        Condition += TextBox13.Text.Trim() == "" ? " " : " and MAM_EquipType like '%" + TextBox13.Text.Trim() + "%'";
        Condition += TextBox14.Text.Trim() == "" ? " " : " and MAM_ManuName like '%" + TextBox14.Text.Trim() + "%'";
        Condition += DropDownList2.Text.Trim() == "" ? " " : " and MAM_Isunused = '" + DropDownList2.SelectedValue.Trim() + "'";
        BindGrid_MeasAppliance(Condition);
        BlInto_S_Search = true;
        UpdatePanel_Grid.Update();
    }//检索
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        Grid_MeasAppliance.SelectedIndex = -1;
        TxtEquipName.Text = "";
        TxtManuCode.Text = "";
        TxtLocation.Text = "";
        TextBox13.Text = "";
        TextBox14.Text = "";
        DropDownList2.Text = "";
        BindGrid_MeasAppliance("");
        UpdatePanel_Grid.Update();
        BlInto_S_Search = false;
    }//重置
    protected void BtnNew_Click(object sender, EventArgs e)
    {
        Panel_New.Visible = true;
        Label4.Text = "新增";
        //TextBox1.Text = "";
        //TextBox2.Text = "";
        //TextBox3.Text = "";
        //TextBox4.Text = "";
        //TextBox5.Text = "";
        //TextBox6.Text = "";
        //TextBox7.Text = "";
        //TextBox8.Text = "";
        //TextBox9.Text = "";
        TextBox1.Text = "";
        TextBox11.Text = "";
        TextBox2.Text = "";

        TextBox12.Text = "";
        TextBox4.Text = "";
        TextBox3.Text = "";

        TextBox5.Text = "";
        TextBox6.Text = "";
        TextBox7.Text = "";

        TextBox8.Text = "";
        TextBox9.Text = "";
        DropDownList1.ClearSelection();

        UpdatePanel_New.Update();
        Panel_History.Visible = false;
        Panel_Result.Visible = false;
        UpdatePanel_Result.Update();
        BindGrid_MeasAppliance("");
        UpdatePanel_History.Update();
        
    }//新增设备
    #endregion

    #region//Grid_Type的内置事件
    protected void Grid_MeasAppliance_DataBound(object sender, EventArgs e)
    {
        DateTime DateTimeNow = DateTime.Now;
        DateTime DateTimeRow;
        for (int i = 0; i < Grid_MeasAppliance.Rows.Count; i++)
        {
            for (int j = 0; j < Grid_MeasAppliance.Rows[i].Cells.Count; j++)
            {
                Grid_MeasAppliance.Rows[i].Cells[j].ToolTip = Grid_MeasAppliance.Rows[i].Cells[j].Text;
                if (Grid_MeasAppliance.Rows[i].Cells[j].Text.Length > 15)
                {
                    if (j == 10 || j == 12)
                    {
                        string[] arr = Grid_MeasAppliance.Rows[i].Cells[j].Text.Split(' ');
                        Grid_MeasAppliance.Rows[i].Cells[j].Text = arr[0];//分割时间，只显示日期
                        Grid_MeasAppliance.Rows[i].Cells[j].ToolTip = Grid_MeasAppliance.Rows[i].Cells[j].Text;
                    }
                    else
                    {
                        Grid_MeasAppliance.Rows[i].Cells[j].Text = Grid_MeasAppliance.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                    }
                }

                if (j == 10 && Grid_MeasAppliance.Rows[i].Cells[13].Text=="否")
                {    
                    DateTimeRow=Convert.ToDateTime(Grid_MeasAppliance.Rows[i].Cells[j].Text);
                    if ( DateDiff(DateTimeNow, DateTimeRow) < Convert.ToInt32(Grid_MeasAppliance.Rows[i].Cells[11].Text)
                        || DateTime.Compare(DateTimeRow, DateTimeNow) < 0
                        )
                    {
                        Grid_MeasAppliance.Rows[i].BackColor = Color.Pink;
                    }
                }
            }
        }
    }//缩略显示
    protected void Grid_History_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < Grid_History.Rows.Count; i++)
        {
            for (int j = 0; j < Grid_History.Rows[i].Cells.Count; j++)
            {
                Grid_History.Rows[i].Cells[j].ToolTip = Grid_History.Rows[i].Cells[j].Text;
                if (Grid_History.Rows[i].Cells[j].Text.Length > 15)
                {

                    if (j == 2)
                    {
                        string[] arr = Grid_History.Rows[i].Cells[j].Text.Split(' ');
                        Grid_History.Rows[i].Cells[j].Text = arr[0];
                    }
                    else
                    { 
                        Grid_History.Rows[i].Cells[j].Text = Grid_History.Rows[i].Cells[j].Text.Substring(0, 15) + "...";
                    }
                }
                
            }
        }
    }//缩略显示
    protected void Grid_MeasAppliance_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_MeasAppliance.BottomPagerRow;


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
        if (BlInto_S_Search == true)
        {
            BindGrid_MeasAppliance(Condition);
        }
        else
        {
            BindGrid_MeasAppliance("");
        }
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_MeasAppliance.PageCount ? Grid_MeasAppliance.PageCount - 1 : newPageIndex;
        Grid_MeasAppliance.PageIndex = newPageIndex;
        Grid_MeasAppliance.DataBind();
        
    }//翻页
    protected void Grid_History_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid_History.BottomPagerRow;


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
        BindGrid_History(ID_His);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid_History.PageCount ? Grid_History.PageCount - 1 : newPageIndex;
        Grid_History.PageIndex = newPageIndex;
        Grid_History.DataBind();
    }//翻页
    #endregion

    #region//计量器具检验列表

    protected void Grid_MeasAppliance_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit_Inf")
        {
            Label4.Text = "编辑";
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_MeasAppliance.SelectedIndex = row.RowIndex;
            Panel_New.Visible = true;
            measApplianceMan.MAM_EquipID = new Guid(e.CommandArgument.ToString());
            ID_Edit = measApplianceMan.MAM_EquipID;
            DataSet ds = measApplianceL.SelectByID_MeasApplianceMan(measApplianceMan.MAM_EquipID);
            TextBox1.Text = ds.Tables[0].Rows[0][0].ToString();
            TextBox2.Text = ds.Tables[0].Rows[0][1].ToString();
            TextBox3.Text = ds.Tables[0].Rows[0][2].ToString();

            DateTime dt1 = DateTime.Parse(ds.Tables[0].Rows[0][3].ToString());
            TextBox4.Text = dt1.ToString("yyyy-MM-dd");

            TextBox5.Text = ds.Tables[0].Rows[0][4].ToString();
            TextBox6.Text = ds.Tables[0].Rows[0][5].ToString();
            TextBox7.Text = ds.Tables[0].Rows[0][6].ToString();

            DateTime dt2 = DateTime.Parse(ds.Tables[0].Rows[0][7].ToString());
            TextBox8.Text = dt2.ToString("yyyy-MM-dd");

            TextBox9.Text = ds.Tables[0].Rows[0][8].ToString();

            TextBox11.Text = ds.Tables[0].Rows[0][9].ToString();
            TextBox12.Text = ds.Tables[0].Rows[0][10].ToString();
            DropDownList1.Text = ds.Tables[0].Rows[0][11].ToString();

            Label24.Text = Grid_MeasAppliance.Rows[GetCurrentGridViewRowIndex(e).RowIndex].Cells[1].Text.ToString() + "的设备信息进行";

            Panel_History.Visible = false;
            Panel_Result.Visible = false;
            

            UpdatePanel_history_result_new();
        }//编辑
        if (e.CommandName == "Delete_Inf")
        {
            Grid_MeasAppliance.SelectedIndex = -1;
            Guid guid = new Guid(e.CommandArgument.ToString());
            try
            {
                if (measApplianceL.Delete_MeasApplianceMan(guid) <= 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('不能删除！')", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('删除成功！')", true);
                    if (BlInto_S_Search == true)
                        BindGrid_MeasAppliance(Condition);
                    if (BlInto_S_Search == false)
                        BindGrid_MeasAppliance("");
                    UpdatePanel_Grid.Update();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('删除失败！" + ex.ToString() + "')", true);
            }


        }//删除
        if (e.CommandName == "Look_TestResult")
        {
            //GridViewRow row = GetCurrentGridViewRowIndex(e);
            Grid_MeasAppliance.SelectedIndex =  GetCurrentGridViewRowIndex(e).RowIndex;
            measApplianceDetail.MAM_EquipID = new Guid(Grid_MeasAppliance.DataKeys[GetCurrentGridViewRowIndex(e).RowIndex].Value.ToString());
            ID_His = measApplianceDetail.MAM_EquipID;

            //设置是在检验哪个设备的标签
            ASP_Label_Show_History.Text = Grid_MeasAppliance.Rows[GetCurrentGridViewRowIndex(e).RowIndex].Cells[1].Text.ToString() + "的检验历史";

            BindGrid_History(measApplianceDetail.MAM_EquipID);
            measApplianceL.Select_MeasApplianceDetail(measApplianceDetail.MAM_EquipID);

            Panel_History.Visible = true;


            Panel_New.Visible = false;
            Panel_Result.Visible = false;

            UpdatePanel_history_result_new();
        }//检验历史
        if (e.CommandName == "TestResult")
        {
            

            //获取登录人，设置成检验人
            Label TextTemp = Master.FindControl("LabelUserName") as Label;
            TxtPer.Text = Session["UserName"].ToString().Trim();
            //this.TxtPer.ReadOnly = true;

            

            TextTime.Enabled = true;
            Panel_Result.Visible = true;
            Label23.Text = "录入";
            TxtNo.Text = "";
            TextTime.Text = DateTime.Now.ToString() ;
            DdlTextResult.ClearSelection();
            TextBox10.Text = "";
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Grid_MeasAppliance.SelectedIndex = row.RowIndex;
            temp = new Guid(Grid_MeasAppliance.DataKeys[row.RowIndex].Value.ToString());

            ASP_Lable_Result.Text = Grid_MeasAppliance.Rows[row.RowIndex].Cells[1].Text.ToString() + "的检验结果";



            Panel_History.Visible = false;
            Panel_New.Visible = false;

            UpdatePanel_history_result_new();
        }//检验结果录入
    }

    

    private void UpdatePanel_history_result_new()
    {
        UpdatePanel_History.Update();
        UpdatePanel_Result.Update();
        UpdatePanel_New.Update();
    }

private static GridViewRow GetCurrentGridViewRowIndex(GridViewCommandEventArgs e)
{
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
return row;
}
    #endregion


    #region//新增设备
    protected void BtnOK_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == "" || TextBox2.Text == "" || TextBox3.Text == "" || TextBox4.Text == "" || TextBox5.Text == "" || TextBox6.Text == "" || TextBox7.Text == "" || TextBox8.Text == "" || TextBox9.Text == "" || TextBox11.Text == "" || TextBox12.Text == "" || DropDownList1.SelectedValue=="")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }

        DateTime din,dready;
        DateTime.TryParse(TextBox4.Text, out din);
        DateTime.TryParse(TextBox8.Text, out dready);
        if (dready< din)
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('待验日期必须大于送达日期！')", true);
            return;
        }


        if (IsMatchInt(TextBox7.Text, 0) == false)
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('检验周期必须是大于0的整数！')", true);
            return;
        }

        if (IsMatchInt(TextBox9.Text, 0) == false)
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('检验提醒天数必须是大于0的整数！')", true);
            return;
        }
        
        if (TextBox1.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('设备名称不能为空！')", true);
            return;
        }
        else
            measApplianceMan.MAM_EquipName = TextBox1.Text;
        
        if (TextBox2.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('出厂编号不能为空！')", true);
            return;
        }
        else
            measApplianceMan.MAM_ManuCode = TextBox2.Text;
        
        if (TextBox3.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('设备位置不能为空！')", true);
            return;
        }
        else
            measApplianceMan.MAM_Location = TextBox3.Text;
        
        DateTime d1;
        if (DateTime.TryParse(TextBox4.Text, out d1))
            measApplianceMan.MAM_ToDate = d1;
        else
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的送达日期！')", true);
            return;
        }
        if (TextBox5.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('厂家精度不能为空！')", true);
            return;
        }
        else
            measApplianceMan.MAM_OAccuracy = TextBox5.Text;
        if (TextBox6.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('精度要求不能为空！')", true);
            return;
        }
        else
            measApplianceMan.MAM_IAccuracy = TextBox6.Text;
        if (TextBox7.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('检验周期不能为空！')", true);
            return;
        }
        else
            measApplianceMan.MAM_Period = Convert.ToInt32(TextBox7.Text);
        if (measApplianceMan.MAM_Period < 0)
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('检验周期不合法！')", true);
            return;
        }
       
        DateTime d2;
        if (DateTime.TryParse(TextBox8.Text, out d2))
            measApplianceMan.MAM_ToBeTestDate = d2;
        else
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的待检日期！')", true);
            return;
        }
        if (TextBox9.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('检验提醒天数不能为空！')", true);
            return;
        }
        else
            measApplianceMan.MAM_RemindDays = Convert.ToInt32(TextBox9.Text);
        if (measApplianceMan.MAM_RemindDays < 0)
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('检验提醒天数不合法！')", true);
            return;
        }
        measApplianceMan.MAM_EquipType = TextBox11.Text;
        measApplianceMan.MAM_ManuName = TextBox12.Text;
        measApplianceMan.MAM_Isunused = DropDownList1.Text;

        if (Label4.Text == "新增")
            measApplianceL.Insert_MeasApplianceMan(measApplianceMan);
        if (Label4.Text == "编辑")
        {
            measApplianceMan.MAM_EquipID = ID_Edit;
            measApplianceL.Update_MeasApplianceMan(measApplianceMan);
        }

        Panel_New.Visible = false;
        UpdatePanel_New.Update();
        if (BlInto_S_Search == true)
            BindGrid_MeasAppliance(Condition);
        if (BlInto_S_Search == false)
            BindGrid_MeasAppliance("");
        UpdatePanel_Grid.Update();
    }//提交
    protected void BtnCancel1_Click(object sender, EventArgs e)
    {
        Panel_New.Visible = false;
        UpdatePanel_New.Update();
    }//取消
    #endregion
    #region//检验结果
    protected void ButtonSubmit_Click(object sender, EventArgs e)
    {
        if (TxtNo.Text == "" || TextTime.Text=="")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }

        DateTime din,Check;
        DateTime.TryParse(TextTime.Text, out Check);
        DateTime.TryParse(Grid_MeasAppliance.Rows[Grid_MeasAppliance.SelectedIndex].Cells[12].Text.ToString(),out din);
        if (din > Check)
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('检验日期必须大于送达日期！')", true);
            return;
        }

        if (TxtNo.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('检验单号不能为空！')", true);
            return;
        }
        else
            measApplianceDetail.MAD_TestNo = TxtNo.Text;

        if (TxtPer.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('检验人不能为空！')", true);
            return;
        }
        else
            measApplianceDetail.MAD_TestPer = TxtPer.Text;
        DateTime d3;
        if (DateTime.TryParse(TextTime.Text, out d3))
            measApplianceDetail.MAD_TestTime = d3;
        else
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('请输入正确的检验时间！')", true);
            return;
        }
        if (DdlTextResult.SelectedValue == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('检验结果不能为空！')", true);
            return;
        }
        else
        {
            measApplianceDetail.MAD_Result = DdlTextResult.SelectedValue;
        }
        measApplianceDetail.MAD_Remarks = TextBox10.Text.Trim();
        measApplianceDetail.MAM_EquipID = temp;
        if (Label23.Text == "录入")
        {
            
            measApplianceL.Insert_MeasApplianceDetail(measApplianceDetail);
            BindGrid_History(temp);
            
        }
        if (Label23.Text == "编辑")
        {
            measApplianceDetail.MAD_DetailID = ID_HisEdit;
            measApplianceL.Update_MeasApplianceDetail(measApplianceDetail);
            BindGrid_History(ID_His);
        }
        
        Panel_Result.Visible = false;
        UpdatePanel_Result.Update();
        UpdatePanel_History.Update();
        UpdatePanel_Grid.Update();
        if (BlInto_S_Search == true)
            BindGrid_MeasAppliance(Condition);
        if (BlInto_S_Search == false)
            BindGrid_MeasAppliance("");
        UpdatePanel_Grid.Update();
    }//提交
    protected void ButtonCancel2_Click(object sender, EventArgs e)
    {
        Panel_Result.Visible = false;
        UpdatePanel_Result.Update();
    }//取消
    #endregion
    #region//检验历史表
    protected void Grid_History_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit_Detail")
        {
            Label23.Text = "编辑";
            Panel_Result.Visible = true;
            ID_HisEdit = new Guid(e.CommandArgument.ToString());
            DataSet ds = measApplianceL.Select_MeasApplianceDetail(ID_HisEdit);
            string m = ds.Tables[0].Rows[0][0].ToString();
            TxtNo.Text = ds.Tables[0].Rows[0][1].ToString();
            TxtPer.Text = ds.Tables[0].Rows[0][3].ToString();

            DateTime dt3 = DateTime.Parse(ds.Tables[0].Rows[0][2].ToString());
            TextTime.Enabled = false;
            TextTime.Text = dt3.ToString("yyyy-MM-dd");

            DdlTextResult.SelectedValue = ds.Tables[0].Rows[0][4].ToString();
            TextBox10.Text = ds.Tables[0].Rows[0][5].ToString();
            UpdatePanel_Result.Update();
        }//编辑
        if (e.CommandName == "Delete_Detail")
        {
            Grid_History.SelectedIndex = -1;
            Guid guid = new Guid(e.CommandArgument.ToString());
            measApplianceL.Delete_MeasApplianceDetail(guid);
            BindGrid_History(ID_His);
            UpdatePanel_History.Update();
        }//删除
    }
    protected void BtnHistoryClose_Click(object sender, EventArgs e)
    {
        Panel_History.Visible = false;
        Panel_Result.Visible = false;
        UpdatePanel_Result.Update();
        UpdatePanel_History.Update();
    }//关闭
    #endregion






}