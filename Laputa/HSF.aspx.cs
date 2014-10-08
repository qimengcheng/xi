using System;
using System.Drawing;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using TextBox = System.Web.UI.WebControls.TextBox;

public partial class Laputa_HSF : Page
{
    private HSFMaterialElementD me = new HSFMaterialElementD();
    HSFD hd=new HSFD();
    protected void Page_Load(object sender, EventArgs e)
    {
        GridView1.DataSource = me.QueryMaterial("", "");
        GridView1.DataBind();
        UpdatePanel2.Update();
    }

    private void Bindgrid2()
    {
           GridView2.DataSource = hd.QueryVersion(new Guid(HSFID.Text));
            GridView2.DataBind();
        UpdatePanel3.Update();
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "History")
        {
            var row = ((LinkButton) e.CommandSource).Parent.Parent as GridViewRow;
            GridView1.SelectedIndex = row.RowIndex;
            HSFID.Text = e.CommandArgument.ToString();
            GridView2.DataSource = hd.QueryVersion(new Guid(e.CommandArgument.ToString()));
            GridView2.DataBind();
            Panel3.Visible = true;

            Panel4.Visible = false;
            Panel5.Visible = false;

            Panel6.Visible = false;

            Panel7.Visible = false;

            Panel8.Visible = false;

            Panel9.Visible = false;
            UpdatePanel2.Update();
            UpdatePanel3.Update();
            UpdatePanel4.Update();
            UpdatePanel5.Update();
            UpdatePanel6.Update();
            UpdatePanel7.Update();
            UpdatePanel8.Update();
            UpdatePanel9.Update();

        }
        if (e.CommandName == "Details")
        {
            var row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView1.SelectedIndex = row.RowIndex;
            HSFID.Text = e.CommandArgument.ToString();
            GridView5.DataSource = hd.QueryDetailAI(new Guid(HSFID.Text));
            GridView5.DataBind();
            Panel6.Visible = true;
            UpdatePanel2.Update();
            UpdatePanel6.Update();
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView1.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textboxp1");   // refer to the TextBox with the NewPageIndex value
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
        GridView1.DataSource = me.QueryMaterial(TextBox1.Text,TextBox2.Text);
        GridView1.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView1.PageCount ? GridView1.PageCount - 1 : newPageIndex;
        GridView1.PageIndex = newPageIndex;
        GridView1.DataBind();
    }

    protected void Search_Click(object sender, EventArgs e)
    {
        GridView1.DataSource = me.QueryMaterial(TextBox1.Text, TextBox2.Text);
        GridView1.DataBind();
        UpdatePanel2.Update();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[5].Text.Length > 10)
            {
                e.Row.Cells[5].ToolTip = e
                    .Row.Cells[5].Text;
                e.Row.Cells[5].Text = e
                    .Row.Cells[5].Text.Substring(0, 10);
            }
        }
    }

    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ED")
        {
            var row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView2.SelectedIndex = row.RowIndex;
            VersionID.Text = e.CommandArgument.ToString();
            addedit.Text = "修改";
            TextBox4.Text = row.Cells[1].Text;
            TextBox10.Text = row.Cells[3].Text;
            Panel7.Visible = true;
            UpdatePanel7.Update();
            UpdatePanel2.Update();
            UpdatePanel3.Update();
        }
        if (e.CommandName == "Copy")
        {
            var row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView2.SelectedIndex = row.RowIndex;
            VersionID.Text = e.CommandArgument.ToString();
            GridView6.DataSource = hd.QueryReportDue(TextBox60.Text, TextBox61.Text, TextBox62.Text);
            GridView6.DataBind();
            Panel10.Visible = true;
            UpdatePanel10.Update();
        }
        if (e.CommandName == "De")
        {
            int a=hd.DeleteVersion(new Guid(e.CommandArgument.ToString()));
            if (a >0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('删除成功！');", true);
           
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('失败了诶...');", true);
             
            }
            GridView2.DataSource = hd.QueryVersion(new Guid(e.CommandArgument.ToString()));
            GridView2.DataBind();
            UpdatePanel3.Update();
        }
        if (e.CommandName == "up")
        {
            var row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView2.SelectedIndex = row.RowIndex;
            Console.Write("");
            Label1.Text = "新增";
            VersionID.Text = e.CommandArgument.ToString();
            Panel8.Visible = true;
            UpdatePanel8.Update();
            UpdatePanel2.Update();
            UpdatePanel3.Update();
        }
        if (e.CommandName == "report")
        {
            var row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView2.SelectedIndex = row.RowIndex;
            VersionID.Text = e.CommandArgument.ToString();
            GridView3.DataSource = hd.QueryReport(new Guid(VersionID.Text));
            GridView3.DataBind();
            Panel4.Visible = true;
            UpdatePanel4.Update();

        }
        if (e.CommandName == "detail")
        {
            var row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView2.SelectedIndex = row.RowIndex;
            VersionID.Text = e.CommandArgument.ToString();
            GridView5.DataSource = hd.QueryDetail(new Guid(VersionID.Text),Guid.Empty);
            GridView5.DataBind();
            Panel6.Visible = true;
            UpdatePanel6.Update();

        }
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView2.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textboxp1");   // refer to the TextBox with the NewPageIndex value
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
        GridView2.DataSource = hd.QueryReport(new Guid(VersionID.Text));
        GridView2.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView2.PageCount ? GridView2.PageCount - 1 : newPageIndex;
        GridView2.PageIndex = newPageIndex;
        GridView2.DataBind();
        
    }
    protected void AddVersion_Click(object sender, EventArgs e)
    {
        addedit.Text = "新增";
        Panel7.Visible = true;
        UpdatePanel7.Update();
    }

    void g2bind()
    {
         GridView2.DataSource = hd.QueryVersion(new Guid(HSFID.Text));
                GridView2.DataBind();
        UpdatePanel3.Update();
    }
    protected void SummitVersion_Click(object sender, EventArgs e)
    {
        if(addedit.Text=="新增")
        {
            string name = TextBox4.Text;
            string note = TextBox10.Text;
            int a=hd.InsertVersion(new Guid(HSFID.Text),name,Session["UserName"].ToString(),note);
            if (a >0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('新增成功！');", true);
              g2bind();
                Panel7.Visible = false;
                UpdatePanel7.Update();
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('已经有名字一样的版本或者该物料/产品系列的项目基础数据为空！');", true);
                Panel7.Visible = false;
                UpdatePanel7.Update();
            }
        }
        else
        {
            string name = TextBox4.Text;
            string note = TextBox10.Text;
            int a = hd.UpdateVersion(new Guid(VersionID.Text), name, Session["UserName"].ToString(), note);
            if (a == 1)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('更新成功！');", true);
                g2bind();
                Panel7.Visible = false;
                UpdatePanel7.Update();
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('已经有名字一样的版本了诶...');", true);
                Panel7.Visible = false;
                UpdatePanel7.Update();
            }
        }
    
    


    }
    protected void CloseAddVersion_Click(object sender, EventArgs e)
    {
        Panel7.Visible = false;
        UpdatePanel7.Update();
    }

    protected void Summit_Report_Click(object sender, EventArgs e)
    {
        if (TextBox21.Text==""||TextBox22.Text==""||TextBox23.Text==""||TextBox25.Text=="")
        {
            ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('除备注之外其他都是必填的哦！');", true);
            Console.Write("");
        }
        else
        {
            if(Label1.Text=="新增")
            {
                string filePath = "";
                string extension = Path.GetExtension(FileUpload1.FileName);
                if (extension == "")
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel8, GetType(), "alert", "alert('未选择上传的报告！');", true);
                }
                if (extension != null)
                {
                    string fileExrensio = extension.ToLower(); //ToLower转化为小写,获得扩展名
                    string uploadUrl = Server.MapPath("~/file/"); //上传的目录
                    string fullname = FileUpload1.FileName; //上传文件的原名
                    string newname = DateTime.Now.ToString("yyyyMMddhhmmss"); //上传文件重命名

                    if (fileExrensio == ".doc" || fileExrensio == ".docx" || fileExrensio == ".pdf" ||
                        fileExrensio == ".xls" || fileExrensio == ".jpg" || fileExrensio == ".png" ||
                        fileExrensio == ".bmp" ||
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
                            ScriptManager.RegisterClientScriptBlock(UpdatePanel8, GetType(), "aa", "alert('上传失败！');", true);
                            return;
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(UpdatePanel8, GetType(), "alert", "alert('不支持此文件格式!');", true);
                        return;
                    }

                    filePath = "file/" + newname + fullname; //存储上传的路径
                }
        

                string num = TextBox21.Text;
                string ins  = TextBox22.Text;
                DateTime dateTime= Convert.ToDateTime(TextBox23.Text);
                string note= TextBox24.Text;
                string type = TextBox25.Text;
                int a=hd.InsertReport(new Guid(VersionID.Text),num, ins, dateTime,filePath, type,note, Session["UserName"].ToString());
                if (a == 2)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('新增成功！');", true);
                    Panel8.Visible = false;
                    UpdatePanel8.Update();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('有相同报告编号的啦!');", true);
                    Panel8.Visible = false;
                    UpdatePanel8.Update();
                }
                GridView2.DataSource = hd.QueryVersion(new Guid(HSFID.Text));
                GridView2.DataBind();
                UpdatePanel3.Update();
            
            }
            else
            {
                string filePath = "";
                string extension = Path.GetExtension(FileUpload1.FileName);
                if (extension == "")
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel8, GetType(), "alert", "alert('！');", true);
                }
                if (extension != null)
                {
                    string fileExrensio = extension.ToLower(); //ToLower转化为小写,获得扩展名
                    string uploadUrl = Server.MapPath("~/file/"); //上传的目录
                    string fullname = FileUpload1.FileName; //上传文件的原名
                    string newname = DateTime.Now.ToString("yyyyMMddhhmmss"); //上传文件重命名

                    if (fileExrensio == ".doc" || fileExrensio == ".docx" || fileExrensio == ".pdf" ||
                        fileExrensio == ".xls" ||
                        fileExrensio == ".xlsx" || fileExrensio == ".txt" || fileExrensio == ".ppt" || fileExrensio == ".png" || fileExrensio == ".jpg" || fileExrensio == ".bmp" ||
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
                            ScriptManager.RegisterClientScriptBlock(UpdatePanel8, GetType(), "aa", "alert('上传失败！');", true);
                            return;
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(UpdatePanel8, GetType(), "alert", "alert('不支持此文件格式!');", true);
                        return;
                    }

                    filePath = "file/" + newname + fullname; //存储上传的路径
                }


                string num = TextBox21.Text;
                string ins = TextBox22.Text;
                DateTime dateTime = Convert.ToDateTime(TextBox23.Text);
                string note = TextBox24.Text;
                string type = TextBox25.Text;
                int a = hd.UpdateReport(new Guid(ReportID.Text), num, ins, dateTime, filePath,type, note, Session["UserName"].ToString());
                if (a ==1)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('修改成功！');", true);
                    Panel8.Visible = false;
                    UpdatePanel8.Update();
                    GridView3.DataSource = hd.QueryReport(new Guid(VersionID.Text));
                    GridView3.DataBind();
                    UpdatePanel4.Update();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('修改失败了诶...');", true);
                    Panel8.Visible = false;
                    UpdatePanel8.Update();
                }
                GridView2.DataSource = hd.QueryVersion(new Guid(HSFID.Text));
                GridView2.DataBind();
                UpdatePanel3.Update();
            }
        }
    }
    protected void CloseUpload_Click(object sender, EventArgs e)
    {
        Panel8.Visible = false;
        UpdatePanel8.Update();
    }
    protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Details")
        {
            var row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView3.SelectedIndex = row.RowIndex;
            ReportID.Text = e.CommandArgument.ToString();
            GridView4.DataSource = hd.QueryDetail(Guid.Empty,new Guid(ReportID.Text));
            GridView4.DataBind();
            Panel5.Visible = true;
            UpdatePanel5.Update();

        }
        if (e.CommandName == "De")
        {
            int a = hd.DeleteReport(new Guid(e.CommandArgument.ToString()));
            if (a >0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除成功！');", true);

            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('失败了诶...');", true);

            }
            GridView3.DataSource = hd.QueryReport(new Guid(VersionID.Text));
            GridView3.DataBind();
            GridView2.DataSource = hd.QueryVersion(new Guid(HSFID.Text));
            GridView2.DataBind();
            UpdatePanel3.Update();
        }
        if (e.CommandName == "Modify")
        {
            var row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView3.SelectedIndex = row.RowIndex;
            ReportID.Text = e.CommandArgument.ToString();
            GridView9.DataSource = hd.QueryDetail(new Guid(VersionID.Text),Guid.Empty);
            GridView9.DataBind();
            Panel9.Visible = true;
            UpdatePanel9.Update();

        }
        if (e.CommandName == "ED")
        {
            var row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView3.SelectedIndex = row.RowIndex;
            ReportID.Text = e.CommandArgument.ToString();
            Label1.Text = "编辑";

            Panel8.Visible = true;
            UpdatePanel8.Update();

        }
    }
    protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void GridView9_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType==DataControlRowType.DataRow)
        {
            if (e.Row.Cells[1].Text.Length>8)
            {
                TextBox note=e.Row.Cells[6].FindControl("TextBox1") as TextBox;
                TextBox net = e.Row.Cells[7].FindControl("TextBox2") as TextBox;
                note.Enabled = false;
                net.Enabled = false;
                LinkButton lb = e.Row.Cells[8].FindControl("modi") as LinkButton;
                lb.Enabled = true;
            }
            else
            {
                LinkButton lb= e.Row.Cells[8].FindControl("modi") as LinkButton;
                lb.Enabled = false;
                lb.ForeColor = Color.Snow;
            }
        }
    }
    protected void SummitReportData_Click(object sender, EventArgs e)
    {
        string man = Session["UserName"].ToString();


        foreach (GridViewRow rows in GridView9.Rows)
        {
            TextBox note = rows.Cells[6].FindControl("TextBox1") as TextBox;
            TextBox net = rows.Cells[7].FindControl("TextBox2") as TextBox;

            if (net.Text!=""&&net.Enabled)
            {
                string notestring = note.Text;
                string netstring = net.Text;
                Guid detailid=new Guid(rows.Cells[0].Text);
                hd.InsertDetail(detailid, new Guid(ReportID.Text),netstring,man,notestring);

            }
        }
        Panel9.Visible = false;
        GridView9.DataSource = hd.QueryDetail(new Guid(VersionID.Text), Guid.Empty);
        GridView9.DataBind();
        UpdatePanel9.Update();
    }
    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        foreach (Control ct in Panel1.Controls)
        {
            if (ct.GetType().ToString().Equals("System.Web.UI.WebControls.Panel1"))
            {
                TextBox cb = (TextBox)ct;
                cb.Text = "";
            }
        } 

    }
    protected void CloseVersion_Click(object sender, EventArgs e)
    {
        Panel3.Visible = false;
        UpdatePanel3.Update();
    }
    protected void CloseReport_Click(object sender, EventArgs e)
    {
        Panel4.Visible = false;
        UpdatePanel4.Update();
    }
    protected void CloseDetail_Click(object sender, EventArgs e)
    {
        Panel5.Visible = false;
        UpdatePanel5.Update();
    }
    protected void CloseDetailCollection_Click(object sender, EventArgs e)
    {
        Panel6.Visible = false;
        UpdatePanel6.Update();
    }

    protected void GridView9_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "modi")
        {
            var row = ((LinkButton) e.CommandSource).Parent.Parent as GridViewRow;
            TextBox note = row.Cells[6].FindControl("TextBox1") as TextBox;
            TextBox net = row.Cells[7].FindControl("TextBox2") as TextBox;
            note.Enabled = true;
            net.Enabled = true;
        }
    }
    protected void GridView4_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView4.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textboxp1");   // refer to the TextBox with the NewPageIndex value
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
        GridView4.DataSource = hd.QueryDetail(Guid.Empty, new Guid(ReportID.Text));
        GridView4.DataBind();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView4.PageCount ? GridView4.PageCount - 1 : newPageIndex;
        GridView4.PageIndex = newPageIndex;
        GridView4.DataBind();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Panel9.Visible = false;
        UpdatePanel9.Update();
    }

    protected void CloseCopy_Click(object sender, EventArgs e)
    {
        Panel10.Visible = false;
        UpdatePanel10.Update();
    }
    protected void SearchCopy_Click(object sender, EventArgs e)
    {
        GridView6.DataSource = hd.QueryReportDue(TextBox60.Text, TextBox61.Text, TextBox62.Text);
        GridView6.DataBind();
        UpdatePanel10.Update();
    }
    protected void GridView6_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Choose")
        {
              var row = ((LinkButton) e.CommandSource).Parent.Parent as GridViewRow;
            GridView6.SelectedIndex = row.RowIndex;
           int a= hd.CopyReport(new Guid(VersionID.Text),new Guid(e.CommandArgument.ToString()),Session["UserName"].ToString());
            if (a >0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('报告添加成功！')", true);
                Panel10.Visible = false;
                UpdatePanel10.Update();
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('失败了诶...')", true);
                Panel10.Visible = false;
                UpdatePanel10.Update();
            }
        Bindgrid2();
        }
    }
}