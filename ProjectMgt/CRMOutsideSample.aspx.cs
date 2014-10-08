using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using RTXHelper;


public partial class ProjectManagement_CRMOutsideSample : Page
{
    PMSupplyInfo_PMSupplyContactL pl = new PMSupplyInfo_PMSupplyContactL();
    CRMOutsideSampleD cs= new CRMOutsideSampleD();
    CRMOutsideSampleinfo CRMOutsideSampleinfo = new CRMOutsideSampleinfo();
    protected void Page_Load(object sender, EventArgs e)
    {
       
        Title = "外来样品管理";
        if (!((Session["UserRole"].ToString().Contains("外来样品"))))
        {
            Response.Redirect("~/Default.aspx");

        }
        if (!IsPostBack)
        {
            BindBos();
            BindGridview1("");
            UpdatePanel_OutWeb.Update();
            ClosePanel();
            UpdatePanel_upload.Update();
        }
         #region 权限
        if (Request.QueryString["status"] == "Look")//外来样品查看
        {
            Button3.Visible = false;

            Gridview1.Columns[22].Visible = true;
            //Gridview1.Columns[18].Visible = true;
            UpdatePanel_OutWeb.Update();
        }
        if (Request.QueryString["status"] == "Edit")//外来样品维护
        {
            Button3.Visible = true;
            Gridview1.Columns[22].Visible = true;
            Gridview1.Columns[17].Visible = true;
            Gridview1.Columns[18].Visible = true;
            UpdatePanel_OutWeb.Update();
        }
        if (Request.QueryString["status"] == "Check")//外来样品审核
        {
            Button3.Visible = false;
            Gridview1.Columns[22].Visible = true;
            Gridview1.Columns[19].Visible = true;
            UpdatePanel_OutWeb.Update();
        }
        if (Request.QueryString["status"] == "Analysis")//外来样品分析
        {
            Button3.Visible = false;
            Gridview1.Columns[20].Visible = true;
            Gridview1.Columns[21].Visible = true;
            Gridview1.Columns[22].Visible = true;
            UpdatePanel_OutWeb.Update();
        }
#endregion
    }
    private void BindGridview1(string condition)
    {
        Gridview1.DataSource = cs.SelectCRMOutsideSample(condition);
        Gridview1.DataBind();
    }
    //检索
    protected void Button1_Sh(object sender, EventArgs e)
    {
        string condition = GetCondition();
        BindGridview1(condition);
        UpdatePanel_OutWeb.Update();
        Panel_SampleNew.Visible = false;
        UpdatePanel_SampleNew.Update();
        Panel_Supply.Visible = false;
        UpdatePanel_Supply.Update();
        Panel_Check.Visible = false;
        UpdatePanel_Check.Update();
    }
    protected string GetCondition()
    {
        string Condition;
        string item = "";
        if (TextBox_Factory.Text != "")
        {
            item += "and CRMOS_Factory like '%" + TextBox_Factory.Text + "'";
        }
        if (TextBox1.Text != "")
        {
            item += "and CRMOS_SampleNum='" + TextBox1.Text + "'";
        }
        if (DropDownList3.SelectedValue != "请选择")
        {
            item += "and CRMOS_State='" + DropDownList3.SelectedValue.ToString() + "'";
        }
        if (DropDownList1.SelectedValue != "请选择")
        {
            item += "and CRMOS_AnalysisReport='" + DropDownList1.SelectedValue.ToString() + "'";
        }
        if (TextBox_Time1.Text != "")
        {
            item += "and CRMOS_Time>='" + TextBox_Time1.Text + "'";
            if (TextBox_Time1.Text != "" && TextBox_Time2.Text != "")
            {
                item += "and CRMOS_Time>='" + TextBox_Time1.Text + "'" + "and CRMOS_Time<='" + TextBox_Time2.Text + "'";
            }
        }
        Condition = item;
        label_QA.Text = item;
        return Condition;
    }
    //新增
    protected void Button3_New(object sender, EventArgs e)
    {
        label_New.Text = "新增外送样品";
        Panel_SampleNew.Visible = true;
        UpdatePanel_SampleNew.Update();
    }
    //重置
    protected void Button3_Reset(object sender, EventArgs e)
    {
        BindGridview1("");
        UpdatePanel_OutWeb.Update();
        TextBox_Factory.Text = "";
        TextBox1.Text = "";
        DropDownList3.SelectedValue = "请选择";
        DropDownList1.SelectedValue = "请选择";
        TextBox_Time1.Text = "";
        TextBox_Time2.Text = "";
        UpdatePanel_OutsideSampleSearch.Update();
    }
    //修改、删除、分析
    protected void Gridview1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Modify1")//修改
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview1.SelectedIndex = row.RowIndex;
            label_SampleID.Text = e.CommandArgument.ToString();
            label_New.Text = Gridview1.Rows[row.RowIndex].Cells[1].Text.ToString();
            TextBox4.Text = Gridview1.Rows[row.RowIndex].Cells[7].Text.ToString();

            TextBox6.Text = Gridview1.Rows[row.RowIndex].Cells[2].Text.ToString();
            TextBox2.Text = Gridview1.Rows[row.RowIndex].Cells[5].Text.ToString();
            DropDownList4.SelectedValue = Gridview1.Rows[row.RowIndex].Cells[6].Text.ToString();
            TextBox7.Text = Gridview1.DataKeys[row.RowIndex]["CRMOS_Remark"].ToString();
            Panel_SampleNew.Visible = true;
            UpdatePanel_SampleNew.Update();
        }
        if (e.CommandName == "Delete1")//删除
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview1.SelectedIndex = row.RowIndex;
            label_SampleID.Text = e.CommandArgument.ToString();
            CRMOutsideSampleinfo.CRMOS_ID = new Guid(label_SampleID.Text.ToString());
            cs.DeleteCRMOutsideSample(CRMOutsideSampleinfo);
            BindGridview1("");
            UpdatePanel_OutWeb.Update();
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_OutWeb, GetType(), "alert", "alert('删除成功！')", true);
            return;

        }
        if (e.CommandName == "Analysis")//分析
        {
            GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            Gridview1.SelectedIndex = row.RowIndex;
            label_SampleID.Text = e.CommandArgument.ToString();
            label_Result.Text = Gridview1.Rows[row.RowIndex].Cells[1].Text.ToString() + "   " + Gridview1.Rows[row.RowIndex].Cells[2].Text.ToString();
            TextBox14.Text = Gridview1.DataKeys[row.RowIndex]["CRMOS_AnalysisResult"].ToString();
            Panel_Check.Visible = true;
            UpdatePanel_Check.Update();
        }
        if (e.CommandName == "Check1")
        {
              GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
              label18.Text = Gridview1.Rows[row.RowIndex].Cells[4].Text.ToString();
            label19.Text = e.CommandArgument.ToString();
            Panel1.Visible = true;
            BindBos();
            UpdatePanel1.Update();
        }
        if (e.CommandName == "UP1")
        {
            Label46.Text = e.CommandArgument.ToString();
            ShowPanel();
            UpdatePanel_upload.Update();
        }

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
       cs.UpdateCRMOutsideSample_up(TTD_DetailID, filePath);
        ClosePanel();
        UpdatePanel_upload.Update();
        BindGridview1("");
        UpdatePanel_OutWeb.Update();

    }

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
    //绑定供应商列表
    private void BindGridview_PMSupply(string Condition)
    {
        try
        {
            Gridview_PMSupply.DataSource = pl.SelectPMSupplyInfo(Condition);
            Gridview_PMSupply.DataBind();
        }
        catch (Exception)
        {
            throw;

        }
    }
    //选择供应商
    protected void Button_SupplySearch(object sender, EventArgs e)
    {
        BindGridview_PMSupply("");
        Panel_Supply.Visible = true;
        UpdatePanel_Supply.Update();
    }
    //提交外送样品
    protected void Button1_Com1(object sender, EventArgs e)
    {

        if (TextBox4.Text != "")
        {
            CRMOutsideSampleinfo.CRMOS_Num = Convert.ToDecimal(TextBox4.Text.ToString());
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_SampleNew, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (TextBox2.Text != "")
        {
            CRMOutsideSampleinfo.CRMOS_AlertDay = Convert.ToInt16(TextBox2.Text.ToString());
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_SampleNew, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (TextBox6.Text != "")
        {
            CRMOutsideSampleinfo.CRMOS_Factory = TextBox6.Text.ToString();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_SampleNew, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (DropDownList4.SelectedValue != "请选择")
        {
            CRMOutsideSampleinfo.CRMOS_AnalysisReport = DropDownList4.SelectedValue.ToString();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_SampleNew, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (TextBox7.Text != "")
        {
            CRMOutsideSampleinfo.CRMOS_Remark = TextBox7.Text.ToString();
        }
       
        CRMOutsideSampleinfo.CRMOS_State = "已提交";
        if (label_New.Text == "新增外送样品")
        {
            CRMOutsideSampleinfo.CRMOS_State = "已提交";
            string man = Session["UserName"].ToString();
            cs.InsertCRMOutsideSample(CRMOutsideSampleinfo,man);
        }
        else
        {
            CRMOutsideSampleinfo.CRMOS_ID = new Guid(label_SampleID.Text.ToString());
            cs.UpdateCRMOutsideSample(CRMOutsideSampleinfo);
        }
        TextBox4.Text = "";
        TextBox2.Text = "";
        TextBox6.Text = "";
        DropDownList4.SelectedValue = "请选择";
        TextBox7.Text = "";
        Panel_SampleNew.Visible = false;
        UpdatePanel_SampleNew.Update();
        BindGridview1("");
        UpdatePanel_OutWeb.Update();
        string remind = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "提交了外来样品申请，请审核！";
        string sErr = RTXhelper.Send(remind, "外来样品审核");
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
        }
    }
    //取消提交外送样品
    protected void Button_Cancel(object sender, EventArgs e)
    {
        TextBox4.Text = "";
        TextBox2.Text = "";
        TextBox6.Text = "";
        DropDownList4.SelectedValue = "请选择";
        TextBox7.Text = "";
        Panel_SampleNew.Visible = false;
        UpdatePanel_SampleNew.Update();
    }
    protected void Button_ComSP(object sender, EventArgs e)
    {
        string Pname;
        bool temp = false;

        foreach (GridViewRow item in Gridview_PMSupply.Rows)
        {
            RadioButton rb = item.FindControl("RadioButtonMarkup") as RadioButton;

            if (rb.Checked)
            {
                Pname = Gridview_PMSupply.DataKeys[item.RowIndex].Value.ToString();
                temp = true;

                TextBox6.Text = Pname;
                UpdatePanel_SampleNew.Update();
            }
        }
        if (!temp)
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_Supply, GetType(), "aa", "alert('请选择供应商')", true);
            return;
        }
        else
        {
            Panel_Supply.Visible = false;
            UpdatePanel_Supply.Update();
        }
    }
    //互斥
    protected void Gridview_PMSupply_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            RadioButton rb = (RadioButton)e.Row.FindControl("RadioButtonMarkup");
            if (rb != null)
            {
                rb.Attributes.Add("onclick", "judge(this)");
            }

        }
    }
    //取消选择供应商
    protected void Button_CancelSP(object sender, EventArgs e)
    {
        Panel_Supply.Visible = false;
        UpdatePanel_Supply.Update();
    }
    //提交分析结论
    protected void Button1_ComF(object sender, EventArgs e)
    {
        CRMOutsideSampleinfo.CRMOS_ID = new Guid(label_SampleID.Text.ToString());
        if (TextBox14.Text != "")
        {
            CRMOutsideSampleinfo.CRMOS_State = "已分析";
            CRMOutsideSampleinfo.CRMOS_AnalysisResult = TextBox14.Text.ToString();
            string man = Session["UserName"].ToString();
            cs.UpdateCRMOutsideSample_Analysis(CRMOutsideSampleinfo, man);
            TextBox14.Text = "";
            Panel_Check.Visible = false;
            UpdatePanel_Check.Update();
            BindGridview1("");
            UpdatePanel_OutWeb.Update();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel_Check, GetType(), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
    }
    //取消填写分析结论
    protected void Button_CancelF(object sender, EventArgs e)
    {
        TextBox14.Text = "";
        Panel_Check.Visible = false;
        UpdatePanel_Check.Update();
    }
    protected void Gridview1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;
            DateTime dt1 = DateTime.Parse(drv["CRMOS_Time"].ToString().Trim());
            int It = Convert.ToInt16(drv["CRMOS_AlertDay"].ToString().Trim());
            DateTime dt2 = dt1.AddYears(It);
            DateTime Tm = DateTime.Parse(drv["Time"].ToString().Trim());
            if (Tm > dt2)
            {
                e.Row.BackColor = Color.SkyBlue;

            }
        }
    }
    #region//换页
    protected void Gridview_Project_PageIndexChanging(object sender, GridViewPageEventArgs e)
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
        string Condition = GetCondition();
        BindGridview1(Condition);
        Gridview1.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview1.PageCount ? Gridview1.PageCount - 1 : newPageIndex;
        Gridview1.PageIndex = newPageIndex;
        Gridview1.DataBind();
    }
    protected void Gridview_PMSupply_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Gridview_PMSupply.BottomPagerRow;


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
        BindGridview_PMSupply("");
        Gridview_PMSupply.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Gridview_PMSupply.PageCount ? Gridview_PMSupply.PageCount - 1 : newPageIndex;
        Gridview_PMSupply.PageIndex = newPageIndex;
        Gridview_PMSupply.DataBind();
    }
    #endregion
    //检索供应商
    protected void Button1_KiMi(object sender, EventArgs e)
    {
        string condition = GetCondition_Supply();
        BindGridview_PMSupply(condition);
        UpdatePanel_Supply.Update();
    }
    protected string GetCondition_Supply()
    {
        string condition;
        string item = "";
        if (TextBox23.Text != "")
        {
            item += " and PMSI_SupplyNum='" + TextBox23.Text + "'";
        }
        if (TextBox24.Text != "")
        {
            item += " and PMSI_SupplyName like'%" + TextBox24.Text + "%'";
        }
        condition = item;
        return condition;
    }
    //重置检索供应商
    protected void Button_CoMi(object sender, EventArgs e)
    {
        TextBox23.Text = "";
        TextBox24.Text = "";
        BindGridview_PMSupply("");
        UpdatePanel_Supply.Update();
    }
    protected void Check_OK(object sender, EventArgs e)
    {
        string man = Session["UserName"].ToString();
        string state = "审核通过";
        string bos = DropDownList2.SelectedValue.ToString();
        Guid id = new Guid(label19.Text.ToString());
        string note = TextBox9.Text.ToString();
        cs.UpdateCRMOutsideSample_Check(id, man, state, bos,note);
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('审核通过')", true);
        Panel1.Visible = false;
        UpdatePanel1.Update();
        TextBox9.Text = "";
        BindGridview1("");
        UpdatePanel_OutWeb.Update();
        string remind = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "审核通过了新的外来样品申请，请完成后续分析工作！";
        string sErr = RTXhelper.Send(remind, "外来样品分析");
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
        }
        
    }
    protected void Check_NOK(object sender, EventArgs e)
    {
        if (TextBox9.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('驳回时必须填写审核意见')", true);
            return;
        }
        string note = TextBox9.Text.ToString();
        string man = Session["UserName"].ToString();
        string state = "审核驳回";
        string bos = DropDownList2.SelectedValue.ToString();
        Guid id = new Guid(label19.Text.ToString());
        cs.UpdateCRMOutsideSample_Check(id, man, state, bos,note);
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('审核驳回')", true);
        Panel1.Visible = false;
        UpdatePanel1.Update();
        TextBox9.Text = "";
        BindGridview1("");
        UpdatePanel_OutWeb.Update();
        string remind = "ERP系统消息：" + Session["UserName"].ToString() + "于" + DateTime.Now.ToString("F") + "驳回了你提交的外来样品申请！";
        string sendman = label18.Text;
          string sErr = RTXhelper.SendbyUserName(remind, sendman);
        if (!string.IsNullOrEmpty(sErr))
        {
            ScriptManager.RegisterClientScriptBlock(Page, GetType(), "alert", "alert('" + sErr + "')", true);
        }
    }
    protected void Check_Canel(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        UpdatePanel1.Update();
        TextBox9.Text = "";
    }
    protected void BindBos()
    {
        DropDownList2.DataSource = cs.SelectBOS();
        DropDownList2.DataTextField = "BDOS_Name";
        DropDownList2.DataValueField = "BDOS_Code";
        DropDownList2.DataBind();

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
    protected void cancel_upload_Click(object sender, EventArgs e)
    {
        ClosePanel();
        UpdatePanel_upload.Update();
    }
    protected void Gridview1_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        ////{     
        //    DataRowView drv = (DataRowView)e.Row.DataItem;
        //    DateTime dt1 = Convert.ToDateTime(drv["CRMOS_CheckTime"].ToString());
        //    int It = Convert.ToInt16(drv["CRMOS_AlertDay"].ToString().Trim());
        //    DateTime dt2 = dt1.AddDays(It);
        //    DateTime Tm = DateTime.Now;
        //    if (Tm > dt2)
        //    {
        //        e.Row.BackColor = System.Drawing.Color.SkyBlue;

        //    }
        //    if(drv["CRMOS_State"]=="已提交")
        //    {
        //            e.Row.Cells[17].Enabled=true;
        //            e.Row.Cells[19].Enabled = true;
        //    }
        //    else
        //    {
        //    e.Row.Cells[17].Enabled=false;
        //    e.Row.Cells[19].Enabled = true;
        //    }
        //       if(drv["CRMOS_State"]=="审核通过")
        //    {
        //            e.Row.Cells[20].Enabled=true;
        //            e.Row.Cells[21].Enabled = true;
        //    }
        //    else
        //    {
        //        e.Row.Cells[20].Enabled = false;
        //        e.Row.Cells[21].Enabled = false;
        //    }
        //}
       
    }
}
