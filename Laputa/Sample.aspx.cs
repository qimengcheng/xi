using System;
using System.Drawing;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using RTXHelper;

public partial class Laputa_Sample : Page
{
    private readonly Sample sam = new Sample();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Session["UserRole"].ToString().Contains("公司样品管理"))
            {
                
                GridView1.Columns[16].Visible = false;
                GridView1.Columns[17].Visible = false;
                GridView1.Columns[18].Visible = false;
                GridView1.Columns[19].Visible = false;
                GridView1.Columns[20].Visible = false;
                GridView1.Columns[21].Visible = false;
            }
            else if (!Session["UserRole"].ToString().Contains("公司样品查看") &&
                     !Session["UserRole"].ToString().Contains("公司样品管理"))
            {
                Response.Redirect("~/Default.aspx");
            }
            if (!Session["UserRole"].ToString().Contains("公司样品客户名称查看"))
            {
                GridView1.Columns[4].Visible = false;
            }
        }
        catch
        {
            Response.Redirect("~/Default.aspx");
        }


        if (!Page.IsPostBack)
        {
            Panel3.Visible = false;
            Panel31.Visible = false;

            Panel42.Visible = false;
            Panel5.Visible = false;
            Panel51.Visible = false;
            Panel6.Visible = false;
            Panel7.Visible = false;
            Panel8.Visible = false;
            Panel9.Visible = false;
            Panel10.Visible = false;


            GridView1.DataSource = sam.Query_Sample();
            GridView1.DataBind();

            UpdatePanel1.Update();
            UpdatePanel2.Update();
            UpdatePanel3.Update();
            UpdatePanel4.Update();
            UpdatePanel5.Update();
            UpdatePanel6.Update();
            UpdatePanel7.Update();
            UpdatePanel8.Update();
            UpdatePanel9.Update();
            UpdatePanel10.Update();
        }
        if (Request.QueryString["state"] == null)
        {
            Labelstate.Text = "look";
        }
        else
        {
            Labelstate.Text = Request.QueryString["state"];
        }
        string pstate = Labelstate.Text;
        if (pstate == "look")
        {
            Title = "公司样品查看";
            GridView1.Columns[16].Visible = false;
            GridView1.Columns[17].Visible = false;
            GridView1.Columns[18].Visible = false;
            GridView1.Columns[19].Visible = false;
            GridView1.Columns[20].Visible = false;
            GridView1.Columns[21].Visible = false;
            Button11.Visible = false;
        }
        if (pstate == "manage")
        {
            Title = "公司样品管理";
        }
    }

    protected void TextBox14_TextChanged(object sender, EventArgs e)
    {
    }


    protected void Button38_Click(object sender, EventArgs e)
    {
        Panel51.Visible = true;
        Panel5.Visible = true;
        Panel52.Visible = false;
        Panel53.Visible = false;
        Panel54.Visible = false;
        GridView4.DataSource = sam.Query_BDOS("");
        GridView4.DataBind();
        UpdatePanel5.Update();
    }


    protected void Button39_Click(object sender, EventArgs e)
    {
        Panel51.Visible = false;
        Panel5.Visible = true;
        Panel52.Visible = false;
        Panel53.Visible = true;
        Panel54.Visible = false;
        GridView6.DataSource = sam.Query_Client("%");
        GridView6.DataBind();
        UpdatePanel5.Update();
    }


    protected void Button37_Click(object sender, EventArgs e)
    {
        GridView5.DataSource = sam.Query_ProType(TextBox21.Text);
        GridView5.DataBind();
        UpdatePanel5.Update();
    }

    protected void Button11_Click(object sender, EventArgs e)
    {
        Panel3.Visible = false;
        Panel31.Visible = true;
        Label31.Text = "新增";
        Panel3.Visible = false;

        Panel5.Visible = false;
        Panel51.Visible = false;
        Panel6.Visible = false;
        Panel7.Visible = false;
        Panel8.Visible = false;

        TextBox23.Enabled = false;
        TextBox23.Text = "";
        TextBox17.Enabled = false;
        Button34.Visible = false;
        Label35.Text = "未选择生产部门";
        clientname.Text = "";
        Label36.Text = "未选择产品型号";
        UpdatePanel3.Update();
        UpdatePanel4.Update();
        UpdatePanel5.Update();
        UpdatePanel6.Update();
        UpdatePanel7.Update();
        UpdatePanel8.Update();
    }

    protected void Button40_Click(object sender, EventArgs e)
    {
        GridView6.DataSource = sam.Query_Client(TextBox24.Text);
        GridView6.DataBind();
        UpdatePanel5.Update();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        GridView3.DataSource = sam.Query_Workorder(TextBox4.Text);
        GridView3.DataBind();
    }

    protected void Button41_Click(object sender, EventArgs e)
    {
        Panel42.Visible = true;
        GridView3.DataSource = sam.Query_Workorder("%");
        GridView3.DataBind();
    }

    protected void Button42_Click(object sender, EventArgs e)
    {
        Panel42.Visible = false;
    }

    protected void Button48_Click(object sender, EventArgs e)
    {
        Panel51.Visible = false;
    }

    protected void Button49_Click(object sender, EventArgs e)
    {
        Panel52.Visible = false;
    }

    protected void Button50_Click(object sender, EventArgs e)
    {
        Panel53.Visible = false;
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        GridView7.DataSource = sam.Query_InStoreNum(TextBox11.Text);
        GridView7.DataBind();
        UpdatePanel5.Update();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (Session["Department"] == null)
        {
            Response.Redirect("~/Other/WelcomePage.aspx");
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var link15 = e.Row.Cells[16].FindControl("ed") as LinkButton;
            var link16 = e.Row.Cells[17].FindControl("de") as LinkButton;
            var link17 = e.Row.Cells[18].FindControl("see") as LinkButton;
            var link18 = e.Row.Cells[19].FindControl("upd") as LinkButton;
            var link19 = e.Row.Cells[20].FindControl("audit") as LinkButton;
            var link20 = e.Row.Cells[21].FindControl("superaudit") as LinkButton;
            if (e.Row.Cells[9].Text != "已建立")
            {
                link19.Enabled = false;
                link19.ToolTip = "已审核";
                link19.ForeColor = Color.LightGray;
                link15.Enabled = false;
                link15.ToolTip = "已建立状态下才可以编辑";
                link15.ForeColor = Color.LightGray;
                link16.Enabled = false;
                link16.ToolTip = "已建立状态下才可以删除";
                link16.ForeColor = Color.LightGray;
            }
            if (e.Row.Cells[9].Text != "审核通过")
            {
                link20.Enabled = false;
                link20.ForeColor = Color.LightGray;
            }
            if (e.Row.Cells[9].Text == "已建立")
            {
                link17.Enabled = false;
                link18.Enabled = false;
                link17.ForeColor = Color.LightGray;
                link18.ForeColor = Color.LightGray;
                if (Session["UserRole"].ToString().Contains("公司样品审核") &&
                    Session["Department"].ToString() == e.Row.Cells[15].Text)
                {
                    link19.Enabled = true;
                }
                else
                {
                    link19.Enabled = false;
                    link19.ToolTip = "需要满足1.用户为生产部门;2权限：公司样品审核";
                    link19.ForeColor = Color.LightGray;
                }

                link20.Enabled = false;
                link20.ForeColor = Color.LightGray;
                link17.ToolTip = "还未审核";
                link18.ToolTip = "还未审核";
                link20.ToolTip = "还未审核";
            }
            if (e.Row.Cells[9].Text == "审核通过")
            {
                link17.Enabled = false;
                link18.Enabled = false;
                link18.Enabled = false;
                link17.ToolTip = "还未审批";
                link18.ToolTip = "还未审批";
                link19.ToolTip = "审核过了";
                link17.ForeColor = Color.LightGray;
                link18.ForeColor = Color.LightGray;
                link19.ForeColor = Color.LightGray;
                if (Session["UserRole"].ToString().Contains("公司样品审批"))
                {
                    link20.Enabled = true;
                }
                else
                {
                    link20.Enabled = false;
                    link20.ToolTip = "需要权限：公司样品审批";
                    link20.ForeColor = Color.LightGray;
                }
            }
            if (e.Row.Cells[9].Text == "审批通过")
            {
                link19.Enabled = false;
                link20.Enabled = false;

                link19.ToolTip = "已审核过";
                link20.ToolTip = "已审批过";
                if (e.Row.Cells[7].Text != Session["Department"].ToString())
                {
                    link18.Enabled = false;
                    link18.ForeColor = Color.LightGray;
                    link18.ToolTip = "生产部门才可以新增生产状态";
                }
                else
                {
                    link18.Enabled = true;
                    link18.ForeColor = Color.Black;
                }
            }
            if (e.Row.Cells[9].Text == "未生产")
            {
                link19.Enabled = false;
                link20.Enabled = false;

                link19.ToolTip = "已审核过";
                link20.ToolTip = "已审批过";
            }
            if (e.Row.Cells[9].Text == "已生产")
            {
                link19.Enabled = false;
                link20.Enabled = false;

                link19.ToolTip = "已审核过";
                link20.ToolTip = "已审批过";
            }
            if (e.Row.Cells[9].Text == "已接收")
            {
                link19.Enabled = false;
                link20.Enabled = false;

                link19.ToolTip = "已审核过";
                link20.ToolTip = "已审批过";
            }

            if (e.Row.Cells[9].Text.Contains("已检验"))
            {
                link19.Enabled = false;
                link20.Enabled = false;

                link19.ToolTip = "已审核过";
                link20.ToolTip = "已审批过";
            }
            if (e.Row.Cells[9].Text.Contains("已发货"))
            {
                link19.Enabled = false;
                link20.Enabled = false;
                link18.Enabled = false;
                link18.ForeColor = Color.LightGray;
                link18.ToolTip = "公司样品已经送出,没有新的进度可以添加啦!";
                link19.ToolTip = "已审核过";
                link20.ToolTip = "已审批过";
            }


            if (e.Row.Cells[9].Text == "审核驳回" || e.Row.Cells[8].Text == "审批驳回")
            {
                link15.Enabled = true;
                link15.ForeColor = Color.FromArgb(225, 225, 225);
                link16.Enabled = true;
            }
            if (e.Row.Cells[10].Text.Length > 10)
            {
                e.Row.Cells[10].ToolTip = e.Row.Cells[10].Text;
                e.Row.Cells[10].Text = e.Row.Cells[10].Text.Substring(0, 10);
            }
            if (e.Row.Cells[11].Text.Length > 10)
            {
                e.Row.Cells[11].ToolTip = e.Row.Cells[11].Text;
                e.Row.Cells[11].Text = e.Row.Cells[11].Text.Substring(0, 10);
            }
            var hyperLink = e.Row.Cells[22].FindControl("DownLoad") as HyperLink;
            if (hyperLink.NavigateUrl == "~/")
            {
                hyperLink.Enabled = false;
                hyperLink.ForeColor = Color.Snow;
            }
        }
    }

    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[6].Text == "未生产" && !Session["UserRole"].ToString().Contains("样品进度未生产"))
            {
                e.Row.Cells[11].ToolTip = "需要权限:样品进度未生产";
                e.Row.Cells[11].Enabled = false;
            }
            else if (e.Row.Cells[6].Text == "已生产" && !Session["UserRole"].ToString().Contains("样品进度已生产"))
            {
                e.Row.Cells[11].ToolTip = "需要权限:样品进度已生产";
                e.Row.Cells[11].Enabled = false;
            }
            else if (e.Row.Cells[6].Text == "已接收" && !Session["UserRole"].ToString().Contains("样品进度已接收"))
            {
                e.Row.Cells[11].ToolTip = "需要权限:样品进度已接收";
                e.Row.Cells[11].Enabled = false;
            }
            else if (e.Row.Cells[6].Text == "已检验" && !Session["UserRole"].ToString().Contains("样品进度已检验"))
            {
                e.Row.Cells[11].ToolTip = "需要权限:样品进度已检验";
                e.Row.Cells[11].Enabled = false;
            }
        }
    }

    protected void ChooseInStoreNum_Click(object sender, EventArgs e)
    {
        Panel51.Visible = false;
        Panel5.Visible = true;
        Panel52.Visible = false;
        Panel53.Visible = false;
        Panel54.Visible = true;
        GridView7.DataSource = sam.Query_InStoreNum("%");
        GridView7.DataBind();
        UpdatePanel5.Update();
    }

    protected void GridView7_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        var theGrid = sender as GridView; // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView7.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox) pagerRow.FindControl("textbox");
                // refer to the TextBox with the NewPageIndex value
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
        //GridView7.DataSource = sam.Query_InStoreNum(TextBox29.Text);
        //GridView7.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView7.PageCount ? GridView7.PageCount - 1 : newPageIndex;
        GridView7.PageIndex = newPageIndex;
        GridView7.DataBind();
    }

    protected void GridView7_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Choose")
        {
            Panel54.Visible = false;
            UpdatePanel3.Update();
            UpdatePanel4.Update();
            UpdatePanel5.Update();
        }
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        Panel54.Visible = false;
        UpdatePanel5.Update();
    }

    protected void TextBox23_TextChanged(object sender, EventArgs e)
    {
        try
        {
            decimal textDeciamal = decimal.Parse(TextBox23.Text);
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('数量输入包含非法字符！')", true);
            TextBox23.Text = "";
        }
    }

    protected void Reset1_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";
        TextBox7.Text = "";
        DropDownList1.SelectedIndex = DropDownList1.Items.IndexOf(DropDownList1.Items.FindByText("所有状态"));
    }

    protected void Summit_Get_Click(object sender, EventArgs e)
    {
        string filePath = "";
        if (DropDownList6.SelectedValue == "是")
        {
            string extension = Path.GetExtension(FileUpload1.FileName);
            if (extension == "")
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel8, GetType(), "alert", "alert('！')", true);
            }
            if (extension != null)
            {
                string fileExrensio = extension.ToLower(); //ToLower转化为小写,获得扩展名
                string uploadUrl = Server.MapPath("~/file/"); //上传的目录
                string fullname = FileUpload1.FileName; //上传文件的原名
                string newname = DateTime.Now.ToString("yyyyMMddhhmmss"); //上传文件重命名

                if (fileExrensio == ".doc" || fileExrensio == ".docx" || fileExrensio == ".pdf" ||
                    fileExrensio == ".xls" ||
                    fileExrensio == ".xlsx" || fileExrensio == ".txt" || fileExrensio == ".ppt" ||
                    fileExrensio == ".pptx")
                    //判断文件扩展名
                {
                    try
                    {
                        if (!Directory.Exists(uploadUrl)) //判断文件夹是否已经存在
                        {
                            Directory.CreateDirectory(uploadUrl); //创建文件夹
                        }
                        FileUpload1.PostedFile.SaveAs(uploadUrl + newname + fullname); //保存上传的文件
                    }
                    catch
                    {
                        ScriptManager.RegisterClientScriptBlock(UpdatePanel8, GetType(), "aa", "alert('上传失败！')", true);
                        return;
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel8, GetType(), "alert", "alert('不支持此文件格式!')", true);
                    return;
                }

                filePath = "file/" + newname + fullname; //存储上传的路径
            }
        }

        var sidGuid = new Guid(Label13.Text);
        string name = DropDownList4.SelectedValue;
        string man = Session["UserName"].ToString();
        string note = TextBox25.Text;

        int a = sam.Insert_CRMCompanySampleSchedule(sidGuid, name, note, man, "", filePath);
        if (a == 1)
        {
            ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('提交成功！')", true);
        }
        RTXhelper.Send(
            "ERP系统消息：" + Session["UserName"] + "于" + DateTime.Now.ToString("F") + "录入公司样品进度:已接收,待您检验样品,检验后请更新样品进度.",
            "样品进度已检验");
        Panel7.Visible = false;
        GridView1.DataSource = sam.Query_Sample();
        GridView1.DataBind();
        UpdatePanel2.Update();
    }

    protected void Summit_Product_Click(object sender, EventArgs e)
    {
        var sid = new Guid(Label13.Text);
        string name = DropDownList3.SelectedValue;
        string man = Session["UserName"].ToString();
        string result = DueDate.Text;
        string note = TextBox27.Text;

        if (DropDownList3.SelectedValue == "未生产")
        {
            try
            {
               

                DateTime reDateTime = Convert.ToDateTime(result);
                int a = sam.Insert_CRMCompanySampleSchedule(sid, name, note, man, result, null);
                if (a > 0)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('提交成功！')", true);
                }
                Panel6.Visible = false;
                GridView1.DataSource = sam.Query_Sample();
                GridView1.DataBind();
                UpdatePanel2.Update();
            }
            catch
            {
                ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('日期格式不正确！')", true);
            }
        }
        if (DropDownList3.SelectedValue == "已生产")
        {
            int a = sam.Insert_CRMCompanySampleSchedule(sid, name, note, man, null, null);
            if (a == 1)
            {
                ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('提交成功！')", true);
            }
            RTXhelper.Send(
                "ERP系统消息：" + Session["UserName"] + "于" + DateTime.Now.ToString("F") + "录入公司样品进度:已生产,待您接收样品,接收后请更新样品进度.",
                "样品进度已接收");
            Panel6.Visible = false;
            GridView1.DataSource = sam.Query_Sample();
            GridView1.DataBind();
            UpdatePanel2.Update();
        }
    }

    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList3.SelectedValue == "未生产")
        {
            duedatelabel.Visible = true;
            DueDate.Visible = true;
            Label32.Visible = true;
        }
        if (DropDownList3.SelectedValue == "已生产")
        {
            duedatelabel.Visible = false;
            DueDate.Visible = false;
            Label32.Visible = false;
        }
    }

    protected void Summit_Check_Click(object sender, EventArgs e)
    {
        var sid = new Guid(Label13.Text);
        string name = "已检验:" + DropDownList5.SelectedValue;
        string man = Session["UserName"].ToString();
        string note = TextBox26.Text;
        int a = sam.Insert_CRMCompanySampleSchedule(sid, name, note, man, DropDownList5.SelectedValue, null);
        if (a > 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('提交成功！')", true);
        }
        if (DropDownList5.SelectedValue == "合格")
        {
            RTXhelper.Send(
                "ERP系统消息：" + Session["UserName"] + "于" + DateTime.Now.ToString("F") + "录入公司样品进度:已检验:合格,样品发货后后请更新样品进度.",
                "样品进度已发货");
        }
        else
        {
            RTXhelper.Send(
                "ERP系统消息：" + Session["UserName"] + "于" + DateTime.Now.ToString("F") +
                "录入公司样品进度:已检验:不合格,请生产部门重新生产并更新样品进度.",
                "样品进度已发货");
        }
        Panel8.Visible = false;
        GridView1.DataSource = sam.Query_Sample();
        GridView1.DataBind();
        UpdatePanel2.Update();
    }

    protected void AuditPass_Click(object sender, EventArgs e)
    {
        var sid = new Guid(Label13.Text);
        string result = "审核通过";
        string man = Session["UserName"].ToString();
        string note = "意见：" + TextBox10.Text + "审核人：" + man + "审核时间:" + DateTime.Now;

        int a = sam.Update_CRMCompanySampleAudit(sid, note, result);
        if (a > 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('提交成功！')", true);
        }
        RTXhelper.Send("ERP系统消息：" + Session["UserName"] + "于" + DateTime.Now.ToString("F") + "审核通过了公司样品,待您审批.", "公司样品审批");
        Panel9.Visible = false;
        GridView1.DataSource = sam.Query_Sample();
        GridView1.DataBind();
        UpdatePanel2.Update();
    }

    protected void AuditReject_Click(object sender, EventArgs e)
    {
        var sid = new Guid(Label13.Text);
        string result = "审核驳回";
        string man = Session["UserName"].ToString();
        string note = "意见：" + TextBox10.Text + "审核人：" + man + "审核时间:" + DateTime.Now;

        int a = sam.Update_CRMCompanySampleAudit(sid, note, result);


        if (a > 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('提交成功！')", true);
        }
        Panel9.Visible = false;
        GridView1.DataSource = sam.Query_Sample();
        GridView1.DataBind();
        UpdatePanel2.Update();
    }

    protected void SuperAuditPass_Click(object sender, EventArgs e)
    {
        var sid = new Guid(Label13.Text);
        string result = "审批通过";
        string man = Session["UserName"].ToString();
        string note = "意见：" + TextBox10.Text + "审批人：" + man + "审批时间:" + DateTime.Now;

        int a = sam.Update_CRMCompanySampleSuperAudit(sid, note, result);
        if (a > 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('提交成功！')", true);
        }
        RTXhelper.SendbyDepAndRole(
            "ERP系统消息：" + Session["UserName"] + "于" + DateTime.Now.ToString("F") + "审批通过了公司样品,待您录入样品进度。", ProDep.Text,
            "样品进度已生产");
        Panel10.Visible = false;
        GridView1.DataSource = sam.Query_Sample();
        GridView1.DataBind();
        UpdatePanel2.Update();
    }

    protected void SuperAuditReject_Click(object sender, EventArgs e)
    {
        var sid = new Guid(Label13.Text);
        string result = "审批驳回";
        string man = Session["UserName"].ToString();
        string note = "意见：" + TextBox10.Text + " +审批人：" + man + "审批时间:" + DateTime.Now;

        int a = sam.Update_CRMCompanySampleSuperAudit(sid, note, result);
        if (a > 0)
        {
            ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('提交成功！')", true);
        }
        Panel10.Visible = false;
        GridView1.DataSource = sam.Query_Sample();
        GridView1.DataBind();
        UpdatePanel2.Update();
    }

    protected void SuperAuditClose_Click(object sender, EventArgs e)
    {
        Panel10.Visible = false;
        GridView1.DataSource = sam.Query_Sample();
        GridView1.DataBind();
        UpdatePanel2.Update();
    }

    protected void AuditClose_Click(object sender, EventArgs e)
    {
        Panel9.Visible = false;
        GridView1.DataSource = sam.Query_Sample();
        GridView1.DataBind();
        UpdatePanel2.Update();
    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        Panel6.Visible = false;
        UpdatePanel6.Update();
    }

    protected void Button8_Click(object sender, EventArgs e)
    {
        Panel7.Visible = false;
        UpdatePanel7.Update();
    }

    protected void Button10_Click(object sender, EventArgs e)
    {
        Panel8.Visible = false;
        UpdatePanel8.Update();
    }

    protected void DropDownList6_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList6.SelectedValue == "否")
        {
            FileUpload1.Enabled = false;
        }
        else
        {
            FileUpload1.Enabled = true;
        }
    }

    protected void CloseMail_Click(object sender, EventArgs e)
    {
        Panel12.Visible = false;
        UpdatePanel12.Update();
    }

    protected void SummitMail_Click(object sender, EventArgs e)
    {
        int count = 0;
        foreach (GridViewRow rows in GridView8.Rows)
        {
            if (((CheckBox) rows.Cells[0].FindControl("CheckBox1")).Checked)
            {
                if (GridView8.DataKeys.Count > rows.RowIndex)
                {
                    var sid = new Guid(GridView8.DataKeys[rows.RowIndex].Value.ToString());
                    const string name = "已发货";
                    string note = TextBox14.Text;
                    string man = Session["UserName"].ToString();
                    int a = sam.Insert_CRMCompanySampleSchedule(sid, name, note, man, null, null);
                }
                count++;
            }
        }
        ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('已发货状态更新成功！');", true);
        RTXhelper.SendbyUserName(
            "ERP系统消息：" + Session["UserName"] + "于" + DateTime.Now.ToString("F") + "更新了" + count + "条公司样品的进度:已发货",
            Session["UserName"].ToString());
        Panel11.Visible = false;
        Panel12.Visible = false;
        GridView1.DataSource = sam.Query_Sample();
        GridView1.DataBind();
        UpdatePanel2.Update();
        UpdatePanel11.Update();
        UpdatePanel12.Update();
    }

    #region 分页代码

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        var theGrid = sender as GridView; // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView1.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox) pagerRow.FindControl("textbox");
                // refer to the TextBox with the NewPageIndex value
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
        string a1 = TextBox1.Text;
        string a2 = TextBox2.Text;
        string a3 = TextBox3.Text;

        var a5 = new DateTime();
        var a6 = new DateTime();
        if (TextBox5.Text == "")
        {
            a5 = Convert.ToDateTime("1/1/1753 12:00:00 AM");
        }
        else
        {
            a5 = Convert.ToDateTime(TextBox5.Text);
        }
        if (TextBox6.Text == "")
        {
            a6 = Convert.ToDateTime("12/31/9999 11:59:59 PM");
        }
        else
        {
            a6 = Convert.ToDateTime(TextBox6.Text);
        }

        string a7 = TextBox7.Text;
        string a8 = DropDownList1.SelectedValue;


        GridView1.DataSource = sam.Query_Sample(a1, a2, a3, a5, a6, a7, a8);
        GridView1.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView1.PageCount ? GridView1.PageCount - 1 : newPageIndex;
        GridView1.PageIndex = newPageIndex;
        GridView1.DataBind();
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        var theGrid = sender as GridView; // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView2.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox) pagerRow.FindControl("textbox");
                // refer to the TextBox with the NewPageIndex value
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
        GridView2.DataSource = sam.Query_Track(new Guid(Label1.Text));
        GridView2.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView2.PageCount ? GridView2.PageCount - 1 : newPageIndex;
        GridView2.PageIndex = newPageIndex;
        GridView2.DataBind();
    }

    protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        var theGrid = sender as GridView; // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView3.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox) pagerRow.FindControl("textbox");
                // refer to the TextBox with the NewPageIndex value
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
        GridView3.DataSource = sam.Query_BDOS(TextBox16.Text);
        GridView3.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView3.PageCount ? GridView3.PageCount - 1 : newPageIndex;
        GridView3.PageIndex = newPageIndex;
        GridView3.DataBind();
    }

    protected void GridView4_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        var theGrid = sender as GridView; // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView4.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox) pagerRow.FindControl("textbox");
                // refer to the TextBox with the NewPageIndex value
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
        GridView4.DataSource = sam.Query_BDOS(TextBox16.Text);
        GridView4.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView4.PageCount ? GridView4.PageCount - 1 : newPageIndex;
        GridView4.PageIndex = newPageIndex;
        GridView4.DataBind();
    }

    protected void GridView5_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        var theGrid = sender as GridView; // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView5.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox) pagerRow.FindControl("textbox");
                // refer to the TextBox with the NewPageIndex value
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
        GridView5.DataSource = sam.Query_ProType(TextBox21.Text);
        GridView5.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView5.PageCount ? GridView5.PageCount - 1 : newPageIndex;
        GridView5.PageIndex = newPageIndex;
        GridView5.DataBind();
    }

    protected void GridView6_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        var theGrid = sender as GridView; // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView6.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox) pagerRow.FindControl("textbox");
                // refer to the TextBox with the NewPageIndex value
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
        GridView6.DataSource = sam.Query_Client(TextBox24.Text);
        GridView6.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView6.PageCount ? GridView6.PageCount - 1 : newPageIndex;
        GridView6.PageIndex = newPageIndex;
        GridView6.DataBind();
    }

    #endregion

    #region 表命令

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ed")
        {
            var row = ((LinkButton) e.CommandSource).Parent.Parent as GridViewRow;
            GridView1.SelectedIndex = row.RowIndex;
            var id = new Guid(e.CommandArgument.ToString());
            Panel31.Visible = true;
            Label33.Text = id.ToString();
            Label31.Text = "修改";
            Button34.Visible = true;
            Panel5.Visible = false;
            Panel51.Visible = false;
            Label35.Text = row.Cells[7].Text;
            Label36.Text = row.Cells[2].Text;
            clientname.Text = row.Cells[4].Text;
            Label34.Text = row.Cells[13].Text;
            Label37.Text = row.Cells[14].Text;
            TextBox23.Text = row.Cells[3].Text;

            UpdatePanel3.Update();
            UpdatePanel4.Update();
        }
        if (e.CommandName == "see")
        {
            var row = ((LinkButton) e.CommandSource).Parent.Parent as GridViewRow;
            GridView1.SelectedIndex = row.RowIndex;
            var id = new Guid(e.CommandArgument.ToString());
            GridView2.DataSource = sam.Query_Track(id);
            GridView2.DataBind();
            Panel3.Visible = true;
            Panel31.Visible = false;

            Panel5.Visible = false;
            Panel51.Visible = false;
            Label1.Text = e.CommandArgument.ToString();
            Label2.Text = row.Cells[1].Text;
            GridView2.SelectedIndex = -1;
            UpdatePanel3.Update();
            UpdatePanel4.Update();
            UpdatePanel5.Update();
        }
        if (e.CommandName == "upd")
        {
            var row = ((LinkButton) e.CommandSource).Parent.Parent as GridViewRow;
            GridView1.SelectedIndex = row.RowIndex;

            var id = new Guid(e.CommandArgument.ToString());
            Label13.Text = id.ToString();

            if (row.Cells[9].Text == "审批通过")
            {
                Panel6.Visible = true;
                DropDownList3.SelectedIndex = DropDownList3.Items.IndexOf(DropDownList1.Items.FindByText("未生产"));
                duedatelabel.Visible = true;
                Label535.Visible = true;
                UpdatePanel6.Update();
            }
            else if (row.Cells[9].Text == "未生产")
            {
                Panel6.Visible = true;
                DropDownList3.SelectedIndex = DropDownList3.Items.IndexOf(DropDownList1.Items.FindByText("已生产"));
                duedatelabel.Visible = false;
                DueDate.Visible = false;
                Label32.Visible = false;
                DropDownList3.Enabled = false;
                UpdatePanel6.Update();
            }
            else if (row.Cells[9].Text == "已生产")
            {
                Panel7.Visible = true;
                UpdatePanel7.Update();
                Response.Write("");
            }
            else if (row.Cells[9].Text == "已接收")
            {
                Panel8.Visible = true;
                UpdatePanel8.Update();
            }
            else if (row.Cells[9].Text == "已检验:不合格")

            {
                Panel6.Visible = true;
                DropDownList3.SelectedIndex = DropDownList3.Items.IndexOf(DropDownList1.Items.FindByText("未生产"));
                duedatelabel.Visible = true;
                Label535.Visible = true;
                UpdatePanel6.Update();
            }
            else if (row.Cells[9].Text == "已检验:合格")
            {
                ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('发货页面建设中...');", true);
                //return;
                DateTime a5 = Convert.ToDateTime("1/1/1753 12:00:00 AM");

                DateTime a6 = Convert.ToDateTime("12/31/9999 11:59:59 PM");
                GridView8.DataSource = sam.Query_Sample(null, null, null, a5, a6, null, "已检验:合格");
                GridView8.DataBind();
                Panel11.Visible = true;
                Panel12.Visible = true;
                UpdatePanel11.Update();
                UpdatePanel12.Update();
            }
            Panel3.Visible = false;
            Panel31.Visible = false;

            Panel5.Visible = false;
            Panel51.Visible = false;
            UpdatePanel3.Update();
            UpdatePanel4.Update();
            UpdatePanel5.Update();
        }
        if (e.CommandName == "de")
        {
            var row = ((LinkButton) e.CommandSource).Parent.Parent as GridViewRow;
            var id = new Guid(e.CommandArgument.ToString());
            sam.Delete_Sample(id);
            GridView1.DataSource = sam.Query_Sample();
            GridView1.DataBind();
        }
        if (e.CommandName == "audit")
        {
            var row = ((LinkButton) e.CommandSource).Parent.Parent as GridViewRow;
            var id = new Guid(e.CommandArgument.ToString());
            Label13.Text = id.ToString();

            GridView1.DataSource = sam.Query_Sample();
            GridView1.DataBind();
            UpdatePanel1.Update();
            Panel9.Visible = true;
            UpdatePanel9.Update();
        }
        if (e.CommandName == "superaudit")
        {
            var row = ((LinkButton) e.CommandSource).Parent.Parent as GridViewRow;
            var id = new Guid(e.CommandArgument.ToString());
            Label13.Text = id.ToString();
            ProDep.Text = row.Cells[7].Text;

            GridView1.DataSource = sam.Query_Sample();
            GridView1.DataBind();
            UpdatePanel1.Update();
            Panel10.Visible = true;
            UpdatePanel10.Update();
        }
        if (e.CommandName == "shiyong")
        {

            var row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            var id = new Guid(e.CommandArgument.ToString());
            if(row.Cells[9].Text!="已发货" && row.Cells[9].Text!="已使用")
            {
             ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('状态为已发货或者已使用的才可以填写使用情况.')", true);
             return;
            }
            Label28.Text = id.ToString();  
            Panel4.Visible = true;
            UpdatePanel13.Update();
        }
    }

    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Modify")
        {
            var row = ((LinkButton) e.CommandSource).Parent.Parent as GridViewRow;
            GridView2.SelectedIndex = row.RowIndex;

            DueDate.Text = row.Cells[7].Text;

            TextBox26.Text = row.Cells[4].Text.Replace("&nbsp;", "");


            Panel31.Visible = false;
            Panel5.Visible = false;
            Panel51.Visible = false;
            UpdatePanel3.Update();
            UpdatePanel4.Update();
            UpdatePanel5.Update();
        }
    }

    protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Choose")
        {
            var row = ((LinkButton) e.CommandSource).Parent.Parent as GridViewRow;
            GridView2.SelectedIndex = row.RowIndex;

            TextBox4.Text = "";
            Panel42.Visible = false;
            UpdatePanel4.Update();
        }
    }

    protected void GridView4_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Choose")
        {
            var row = ((LinkButton) e.CommandSource).Parent.Parent as GridViewRow;

            string id = e.CommandArgument.ToString();
            Label34.Text = id;
            Label35.Text = row.Cells[1].Text;

            Panel51.Visible = false;
            UpdatePanel3.Update();
            UpdatePanel4.Update();
            UpdatePanel5.Update();
        }
    }

    protected void GridView5_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Choose")
        {
            var row = ((LinkButton) e.CommandSource).Parent.Parent as GridViewRow;

            //TextBox29.Text = e.CommandArgument.ToString();
            if (Label31.Text == "新增")
            {
                try
                {
                    string bdid = Label34.Text;
                    var typeid = new Guid(e.CommandArgument.ToString());
                    var cbox1 = (TextBox) GridView5.Rows[row.RowIndex].FindControl("TBNum");
                    if (cbox1.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('必须填写数量.')", true);
                        return;
                    }
                    decimal num = decimal.Parse(cbox1.Text);
                    var cbox2 = (TextBox) GridView5.Rows[row.RowIndex].FindControl("TBMark");
                    string note = cbox2.Text;
                    int a = sam.Insert_CRMCompanySample(clientname.Text,clientcode.Text, bdid, typeid, num, note,
                        Session["UserName"].ToString(), Session["Department"].ToString());
                    if (a == 1)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('增加成功.')", true);
                        RTXhelper.SendbyDepAndRole(
                            "ERP系统消息：" + Session["UserName"] + "于" + DateTime.Now.ToString("F") + "提交了公司样品,待您审核。",
                            Session["Department"].ToString(), "公司样品审核");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('新增失败.')", true);
                    }

                    GridView1.DataSource = sam.Query_Sample();
                    GridView1.DataBind();
                    //Panel31.Visible = false;

                    UpdatePanel3.Update();
                    UpdatePanel1.Update();
                    UpdatePanel2.Update();
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('增加失败')", true);
                }
            }


            //var id = new Guid(e.CommandArgument.ToString());
            //Label37.Text = id.ToString();
            //Label36.Text = row.Cells[1].Text;
            //Panel52.Visible = false;
            UpdatePanel3.Update();
            UpdatePanel4.Update();
            UpdatePanel5.Update();
        }
    }

    protected void GridView6_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Choose")
        {
            var row = ((LinkButton) e.CommandSource).Parent.Parent as GridViewRow;

            var id = new Guid(e.CommandArgument.ToString());

            Panel53.Visible = false;
            UpdatePanel3.Update();
            UpdatePanel4.Update();
            UpdatePanel5.Update();
        }
    }

    #endregion

    #region 按钮事件

    #region 检索BOM文件

    protected void Button1_Click(object sender, EventArgs e) //点击检索按钮
    {
        string a1 = TextBox1.Text;
        string a2 = TextBox2.Text;
        string a3 = TextBox3.Text;
        var a5 = new DateTime();
        var a6 = new DateTime();
        if (TextBox5.Text == "")
        {
            a5 = Convert.ToDateTime("1/1/1753 12:00:00 AM");
        }
        else
        {
            a5 = Convert.ToDateTime(TextBox5.Text);
        }
        if (TextBox6.Text == "")
        {
            a6 = Convert.ToDateTime("12/31/9999 11:59:59 PM");
        }
        else
        {
            a6 = Convert.ToDateTime(TextBox6.Text);
        }

        string a7 = TextBox7.Text;
        string a8 = DropDownList1.SelectedValue;

        GridView1.DataSource = sam.Query_Sample(a1, a2, a3, a5, a6, a7, a8);
        GridView1.DataBind();
        Panel3.Visible = false;
        Panel31.Visible = false;
        Panel5.Visible = false;
        Panel51.Visible = false;
        GridView1.SelectedIndex = -1;
        UpdatePanel2.Update();
        UpdatePanel3.Update();
        UpdatePanel4.Update();
        UpdatePanel5.Update();
    }

    #endregion

    #region 表1按钮

    protected void Button21_Click(object sender, EventArgs e)
    {
        Panel31.Visible = true;
        Panel5.Visible = false;
        Panel51.Visible = false;
    }

    protected void Butto22_Click(object sender, EventArgs e)
    {
        Panel3.Visible = false;
        Panel31.Visible = false;
    }

    protected void Button23_Click(object sender, EventArgs e)
    {
        if (DueDate.Text == "" || DueDate.Text == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }

        #region //新增

        if (true)
        {
            //Guid sid = new Guid(Label13.Text);


            try
            {
                decimal innum = decimal.Parse(DueDate.Text);
                decimal outnum = decimal.Parse(DueDate.Text);
                //int a = sam.Insert_CRMCompanySampleSchedule(sid, DropDownList2.SelectedItem.Text, "没有随工单号",
                //TextBox26.Text, TextBox27.Text, innum, outnum, Session["UserName"].ToString(), null);
                DueDate.Text = "";
                DueDate.Text = "";
                TextBox26.Text = "";
                GridView1.DataSource = sam.Query_Sample();
                GridView1.DataBind();
                UpdatePanel2.Update();
                UpdatePanel4.Update();
                GridView1.SelectedIndex = -1;
                //if (a >1)
                //{

                //        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('新增成功.')", true);


                //}
                //else
                //{
                //     ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('新增失败.')", true);
                //}
            }
            catch
            {
                ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('新增失败！')", true);
            }
        }

        #endregion

        //#region //修改

        //if (Label11.Text == "修改")
        //{


        //    {
        //        Guid cssid = new Guid(Label42.Text);


        //            try
        //            {
        //                decimal innum = decimal.Parse(DueDate.Text);
        //                decimal outnum = decimal.Parse(DueDate.Text);
        //                int a = sam.Update_CRMCompanySampleSchedule(cssid, "没有随工单号", TextBox26.Text, TextBox27.Text, innum,
        //                    outnum, Session["UserName"].ToString(), null);
        //                DueDate.Text = "";
        //                DueDate.Text = "";

        //               
        //                GridView2.DataSource = sam.Query_Track(new Guid(Label1.Text));
        //                GridView2.DataBind();
        //                UpdatePanel3.Update();
        //                UpdatePanel4.Update();
        //                GridView2.SelectedIndex = -1;
        //                if (a >0)
        //                {
        //                    ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('修改成功.')", true);
        //                }
        //                else
        //                {

        //                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('修改失败.')", true);
        //                }

        //            }
        //            catch
        //            {
        //                ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('修改失败！')", true);
        //            }


        //    }


        //}

        //#endregion 
    }

    #endregion

    #region 表2按钮

    protected void Button31_Click(object sender, EventArgs e)
    {
    }

    protected void Button32_Click(object sender, EventArgs e)
    {
        UpdatePanel4.Update();
    }

    protected void Button33_Click(object sender, EventArgs e)
    {
        if (Label31.Text == "新增")
        {
            if (Label35.Text == "未选择生产部门")
            {
                ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('必须选择生产部门！')", true);
                return;
            }
            if (clientname.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('必须填写客户名称！')", true);
                return;
            }
            if (clientcode.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('必须填写客户代码！')", true);
                return;
            }
            Panel51.Visible = false;
            Panel5.Visible = true;
            Panel52.Visible = true;
            Panel53.Visible = false;
            Panel54.Visible = false;
            GridView5.DataSource = sam.Query_ProType("%");
            GridView5.DataBind();
            UpdatePanel5.Update();
        }
        else if (Label31.Text == "修改")
        {
            ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert",
                "alert('此状态下不可以修改产品型号，如果要修改产品型号请删除本条记录重新添加！')", true);
        }
    }

    protected void Button34_Click(object sender, EventArgs e)
    {
        if (TextBox23.Text == "" || clientname.Text == "" || clientcode.Text == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('标记*的为必填项，请填写完整！')", true);
            return;
        }
        if (Label36.Text != "未选择产品型号" && Label35.Text != "未选择生产部门")
        {
            string bdid = Label34.Text;
            var typeid = new Guid(Label37.Text);
            decimal num = decimal.Parse(TextBox23.Text);
            string note = TextBox17.Text;


            if (Label31.Text == "修改")
            {
                try
                {
                    var Sampleid = new Guid(Label33.Text);

                    int a = sam.Update_CRMCompanySample(Sampleid, clientname.Text, clientcode.Text, bdid, typeid, num,
                        note,
                        Session["UserName"].ToString(), Session["Department"].ToString());
                    if (a == 1)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('修改成功.')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('修改失败.')", true);
                    }
                    Panel31.Visible = false;
                    GridView1.DataSource = sam.Query_Sample();
                    GridView1.DataBind();
                    UpdatePanel3.Update();
                    UpdatePanel1.Update();
                    UpdatePanel2.Update();
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('修改失败!')", true);
                }
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('生产部门、产品型号或客户还未选择。')", true);
        }
    }

    protected void Button35_Click(object sender, EventArgs e)
    {
        Panel31.Visible = false;
    }

    #endregion

    #region 检索工序

    protected void Button36_Click(object sender, EventArgs e)
    {
        GridView4.DataSource = sam.Query_BDOS(TextBox16.Text);
        GridView4.DataBind();
    }

    #endregion

    #endregion

    #region 删除

    protected void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
    }

    #endregion
    protected void CloseMail_Click_shiyongguanbi(object sender, EventArgs e)
    {
        Panel4.Visible = false;
        UpdatePanel13.Update();
    }
    protected void SummitMail_Click_shiyong(object sender, EventArgs e)
    {
        Guid id = new Guid(Label28.Text);
        string man = Session["UserName"].ToString();
        string op = TextBox15.Text.ToString();
        sam.Update_CRMCompanySampleShiyong(id, op, man);
        GridView1.DataSource = sam.Query_Sample();
        GridView1.DataBind();
        UpdatePanel2.Update();
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('已使用进度已增加')", true);
        Panel4.Visible = false;
        UpdatePanel13.Update();
    }
}