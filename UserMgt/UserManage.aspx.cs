using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Deployment.Internal;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RTXHelper;

public partial class Laputa_UserManage : Page
{
    private static readonly UserD Us = new UserD();

    static DataSet usercache = Us.SearchUser();
    static List<string> _strList = (from DataRow dr in usercache.Tables[0].Rows select dr[0].ToString().Trim()).ToList();
    static List<string> _strList2 = (from DataRow dr in usercache.Tables[0].Rows select dr[1].ToString().Trim()).ToList();
    static List<string> _strList3 = (from DataRow dr in usercache.Tables[0].Rows select dr[2].ToString().Trim()).ToList();
    private void RefeshCache()
    {
        usercache = Us.SearchUser();    
        _strList = (from DataRow dr in usercache.Tables[0].Rows select dr[0].ToString().Trim()).ToList();
        _strList2 = (from DataRow dr in usercache.Tables[0].Rows select dr[1].ToString().Trim()).ToList();
        _strList3 = (from DataRow dr in usercache.Tables[0].Rows select dr[2].ToString().Trim()).ToList();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Title = "用户管理";
            SqlDataReader myReader = Us.Query_Organization();
            DropDownList1.Items.Clear();
            DropDownList1.Items.Add(new ListItem("所有部门", "null"));//增加I
            DropDownList3.Items.Clear();
            DropDownList3.Items.Add(new ListItem("所有部门", "null"));//增加I
            while (myReader.Read())
            {
                DropDownList1.Items.Add(new ListItem(myReader["BDOS_Name"].ToString(), myReader["BDOS_Code"].ToString()));//增加Item
                DropDownList3.Items.Add(new ListItem(myReader["BDOS_Name"].ToString(), myReader["BDOS_Code"].ToString()));//增加Item
            }
   
            string name = TextBox1.Text;
            string id = TextBox2.Text;
            string dep = DropDownList1.SelectedValue;
            int a = CheckBox1.Checked ? 1 : 0;
            string role = TextBox6.Text;
            GridView1.DataSource = Us.SearchUser(id, name, dep, a,role);
            GridView1.DataBind();
            UpdatePanel2.Update();
            Panel3.Visible = false;
            Panel4.Visible = false;
            UpdatePanel4.Update();
            UpdatePanel3.Update();
        }

    }
    protected void Search_Click(object sender, EventArgs e)
    {
        string name = TextBox1.Text;
        string id = TextBox2.Text;
        string dep = DropDownList1.SelectedValue;
        string role = TextBox6.Text;
        int a = CheckBox1.Checked ? 1 : 0;
        Panel3.Visible = false;
        Panel4.Visible = false;
        GridView1.DataSource = Us.SearchUser(id, name, dep, a,role);
        GridView1.DataBind();
        UpdatePanel2.Update();
        UpdatePanel3.Update();
        UpdatePanel4.Update();




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
        string name = TextBox1.Text;
        string id = TextBox2.Text;
        string dep = DropDownList1.SelectedValue;
        int a = CheckBox1.Checked ? 1 : 0;
        string role = TextBox6.Text;
        GridView1.DataSource = Us.SearchUser(id, name, dep, a,role);
        GridView1.DataBind();
        
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView1.PageCount ? GridView1.PageCount - 1 : newPageIndex;
        GridView1.PageIndex = newPageIndex;
        GridView1.DataBind();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "mod")
        {
            RTXstate.Text = "normal";
            var row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            if (row != null) GridView1.SelectedIndex = row.RowIndex;
            SqlDataReader myReader = Us.Query_Organization();
            DropDownList2.Items.Clear();
            code.Text = e.CommandArgument.ToString();

            while (myReader.Read())
            {
                DropDownList2.Items.Add(new ListItem(myReader["BDOS_Name"].ToString(), myReader["BDOS_Code"].ToString()));//增加Item
            }


            TextBox3.Text = row.Cells[1].Text;
            TextBox4.Text = row.Cells[0].Text;
            TextBox5.Text = row.Cells[2].Text;
            DropDownList2.SelectedIndex = DropDownList2.Items.IndexOf(DropDownList1.Items.FindByText(row.Cells[3].Text));
            Label3.Text = "修改";
            Label4.Text = row.Cells[0].Text;
            Label5.Text = row.Cells[1].Text;
            Label6.Text = row.Cells[2].Text;
            Image2.Visible = false;
            Image3.Visible = false;
            Image4.Visible = false;
            Panel3.Visible = true;
            Panel4.Visible = false;
            UpdatePanel3.Update();
            UpdatePanel4.Update();
        }
        if (e.CommandName == "def")
        {
            var row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            if (row != null)
            {
                string id = row.Cells[0].Text;
               
                int a = Us.ResetUser(id);
                if (a == 1)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('密码已重置为123456!')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('重置失败！')", true);
                }
            }
            Label3.Text = "修改";
            Image2.Visible = false;
            UpdatePanel3.Update();
        }
        if (e.CommandName == "del")
        {
            var row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            if (row != null)
            {
                string id = row.Cells[0].Text;

                int a = Us.DeleteUser(id);
                if (a == 1)
                {
                    string name = TextBox1.Text;
                    string id1 = TextBox2.Text;
                    string dep = DropDownList1.SelectedValue;
                    int a1 = CheckBox1.Checked ? 1 : 0;
                    string role = TextBox6.Text;
                    GridView1.DataSource = Us.SearchUser(id1, name, dep, a1,role);
                    GridView1.DataBind();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('用户已删除!')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('删除失败！')", true);
                }
            }
          
        }
        if (e.CommandName == "role")
        {
            var row = ((LinkButton) e.CommandSource).Parent.Parent as GridViewRow;
            int a = 1;
            GridView1.SelectedIndex = row.RowIndex;
            foreach (Control ct in Panel4.Controls)
            {
                if (ct.GetType().ToString().Equals("System.Web.UI.WebControls.CheckBoxList"))
                {
                    CheckBoxList cb = (CheckBoxList)ct;
                    cb.DataSource = Us.GetRole(a).Tables[0];
                    cb.DataTextField = "imei";//绑定的字段名
                    cb.DataValueField = "imei";//绑定的值
                    cb.DataBind();
                    if (row != null)
                    {
                        string role = row.Cells[4].Text.Length >= row.Cells[4].ToolTip.Length ? row.Cells[4].Text : row.Cells[4].ToolTip;
                        foreach (ListItem items in cb.Items)
                        {
                            if (role.Contains(items.Value))
                            {
                                items.Selected = true;
                            }
                        }
                    }
                    a++;
                }
            } 

       
            userid.Text = e.CommandArgument.ToString();

            Panel4.Visible = true;
            Panel3.Visible = false;
            UpdatePanel3.Update();
            UpdatePanel4.Update();
        }
        if (e.CommandName == "copyrole")
        {
            var row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
            GridView1.SelectedIndex = row.RowIndex;
            if (row != null)
            {
                code.Text = e.CommandArgument.ToString();
                Panel5.Visible = true;
                Panel6.Visible = true;
                UpdatePanel5.Update();
            }
          
        }
    }
    protected void New_Click(object sender, EventArgs e)
    {
        RefeshCache();
        RTXstate.Text = "normal";
        Panel3.Visible = true;
        SqlDataReader myReader = Us.Query_Organization();
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        Image2.Visible = false;
        Image3.Visible = false;
        Image4.Visible = false;


        DropDownList2.Items.Clear();

        while (myReader.Read())
        {
            DropDownList2.Items.Add(new ListItem(myReader["BDOS_Name"].ToString(), myReader["BDOS_Code"].ToString()));//增加Item
        }
        Image2.Visible = false;
        Image3.Visible = false;
        Label4.Text = "Label";
        Label5.Text = "Label";
        Label6.Text = "Label";
        Label3.Text = "新增";
        Panel4.Visible = false;
        UpdatePanel4.Update();

        UpdatePanel3.Update();
    }
    protected void CloseM_Click(object sender, EventArgs e)
    {
        Panel3.Visible = false;
        UpdatePanel3.Update();
    }
    protected void TextBox4_TextChanged(object sender, EventArgs e)
    {
        if (Label4.Text=="Label")
        {

            if (TextBox4.Text == "")
            {
                Image2.ImageUrl = "~/images/button/delete.gif";
                Image2.Visible = true;
                flag.Text = "no";
            }
            else if (_strList.Contains(TextBox4.Text))
            {
                Image2.ImageUrl = "~/images/button/delete.gif";
                Image2.Visible = true;
                flag.Text = "no";

            }
            else
            {
                Image2.ImageUrl = "~/images/button/ok.gif";
                Image2.Visible = true;
                flag.Text = "yes";
            }
        }
        else
            {
            if (TextBox4.Text=="")
            {
                Image2.ImageUrl = "~/images/button/delete.gif";
                Image2.Visible = true;
                flag.Text = "no";
            }
            else if (_strList.Contains(TextBox4.Text) && TextBox4.Text!=Label4.Text)
            {
                Image2.ImageUrl = "~/images/button/delete.gif";
                Image2.Visible = true;
                flag.Text = "no";

            }
            else
            {
                Image2.ImageUrl = "~/images/button/ok.gif";
                Image2.Visible = true;
                flag.Text = "yes";
            }
        }
    }
    protected void SummitUser_Click(object sender, EventArgs e)
    {
        RefeshCache();

        #region 工号判断
        if (Label4.Text == "Label")
        {

            if (TextBox4.Text == "")
            {
                Image2.ImageUrl = "~/images/button/delete.gif";
                Image2.Visible = true;
                flag.Text = "no";
            }
            else if (_strList.Contains(TextBox4.Text))
            {
                Image2.ImageUrl = "~/images/button/delete.gif";
                Image2.Visible = true;
                flag.Text = "no";

            }
            else
            {
                Image2.ImageUrl = "~/images/button/ok.gif";
                Image2.Visible = true;
                flag.Text = "yes";
            }
        }
        else
        {
            if (TextBox4.Text == "")
            {
                Image2.ImageUrl = "~/images/button/delete.gif";
                Image2.Visible = true;
                flag.Text = "no";
            }
            else if (_strList.Contains(TextBox4.Text) && TextBox4.Text != Label4.Text)
            {
                Image2.ImageUrl = "~/images/button/delete.gif";
                Image2.Visible = true;
                flag.Text = "no";

            }
            else
            {
                Image2.ImageUrl = "~/images/button/ok.gif";
                Image2.Visible = true;
                flag.Text = "yes";
            }
        }

        #endregion

        #region 用户名称判断

        if (Label5.Text == "Label")
        {
            if (TextBox3.Text == "")
            {
                Image3.ImageUrl = "~/images/button/delete.gif";
                Image3.Visible = true;
                flag2.Text = "no";
            }
            else if (_strList2.Contains(TextBox3.Text))
            {
                Image3.ImageUrl = "~/images/button/delete.gif";
                Image3.Visible = true;
                flag2.Text = "no";

            }
            else
            {
                Image3.ImageUrl = "~/images/button/ok.gif";
                Image3.Visible = true;
                flag2.Text = "yes";
            }
        }
        else
        {
            if (TextBox3.Text == "")
            {
                Image3.ImageUrl = "~/images/button/delete.gif";
                Image3.Visible = true;
                flag2.Text = "no";
            }
            else if (_strList2.Contains(TextBox3.Text) && TextBox3.Text != Label5.Text)
            {
                Image3.ImageUrl = "~/images/button/delete.gif";
                Image3.Visible = true;
                flag2.Text = "no";

            }
            else
            {
                Image3.ImageUrl = "~/images/button/ok.gif";
                Image3.Visible = true;
                flag2.Text = "yes";
            }
        }

        #endregion

        #region RTX号码判断
        if (Label6.Text == "Label")
        {
            if (TextBox5.Text == "")
            {
                Image4.ImageUrl = "~/images/button/delete.gif";
                Image4.Visible = true;
                flag3.Text = "no";
            }
            else if (_strList3.Contains(TextBox3.Text))
            {
                Image4.ImageUrl = "~/images/button/delete.gif";
                Image4.Visible = true;
                flag3.Text = "no";

            }
            else
            {
                Image4.ImageUrl = "~/images/button/ok.gif";
                Image4.Visible = true;
                flag3.Text = "yes";
            }
        }
        else
        {
            if (TextBox5.Text == "")
            {
                Image4.ImageUrl = "~/images/button/delete.gif";
                Image4.Visible = true;
                flag3.Text = "no";
            }
            else if (_strList3.Contains(TextBox5.Text) && TextBox5.Text != Label6.Text)
            {
                Image4.ImageUrl = "~/images/button/delete.gif";
                Image4.Visible = true;
                flag3.Text = "no";

            }
            else
            {
                Image4.ImageUrl = "~/images/button/ok.gif";
                Image4.Visible = true;
                flag3.Text = "yes";
            }
        }
        #endregion
        UpdatePanel3.Update();



        if (flag.Text == "yes" && flag2.Text == "yes" && flag3.Text == "yes")
        {
            if (Label3.Text == "新增")
            {
                {
                    string name = TextBox3.Text;
                    string codeString = DropDownList2.SelectedValue;
                    string id = TextBox4.Text;
                    string rtx = TextBox5.Text;
                    int a = Us.InsertUser(id, name,rtx, codeString);
                    GridView1.DataSource = Us.SearchUser();
                    GridView1.DataBind();
                    UpdatePanel2.Update();
                    if (a == 1)
                    {
                        Panel3.Visible = false;
                        flag.Text = "Label";
                        flag2.Text = "Label";
                      
                        UpdatePanel3.Update();
                        //if (RTXstate.Text=="add")
                        //{
                        //    string aa=RTXhelper.AddRtxUser(rtx, name);

                        //}
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('新增成功！')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('新增失败！')", true);
                    }
                }
            }
            else
            {
                string oldid = code.Text;
                string name = TextBox3.Text;
                string dep = DropDownList2.SelectedValue;
                string newid = TextBox4.Text;
                string rtx = TextBox5.Text;
                int a = Us.UpdateUser(oldid, newid, name,rtx,dep); 
                GridView1.DataSource = Us.SearchUser();
                GridView1.DataBind();
                UpdatePanel2.Update();
                if (a == 1)
                {
                    Panel3.Visible = false;
                    flag.Text = "Label";
                    flag2.Text = "Label";
                    //if (RTXstate.Text == "add")
                    //{
                    //    RTXhelper.AddRtxUser(rtx, name);

                    //}
                    UpdatePanel3.Update();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('更新成功！')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('更新失败！')", true);
                }
            }
          
        }
        else if (flag.Text == "no" || flag2.Text == "no" || flag3.Text == "no")
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('工号或用户名称重复或未填写！')", true);
            }

    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.DataRow) return;
        if (e.Row.Cells[4].Text.Length <= 20) return;
        e.Row.Cells[4].ToolTip = e.Row.Cells[4].Text;
        e.Row.Cells[4].Text = e.Row.Cells[4].Text.Substring(0, 20);
    }
    protected void SummitRole_Click(object sender, EventArgs e)
    {
        string newrole = "";
        foreach (Control ct in Panel4.Controls)
        {
            if (ct.GetType().ToString().Equals("System.Web.UI.WebControls.CheckBoxList"))
            {
                CheckBoxList cb = (CheckBoxList)ct;
               newrole += cb.Items.Cast<ListItem>().Where(listItem => listItem.Selected == true).Aggregate<ListItem, string>(null, (current, listItem) => current + (listItem.Value + ","));
        
                
            }
        } 
        var id = userid.Text;
        int a=Us.UpdateRole(id, newrole);
        if (a==1)
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof (Page), "alert", "alert('权限设置成功！')", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof (Page), "alert", "alert('权限设置失败！')", true);
        }
        string name = TextBox1.Text;
        string sid = TextBox2.Text;
        string dep = DropDownList1.SelectedValue;
        int sa = CheckBox1.Checked ? 1 : 0;
        string role = TextBox6.Text;
        GridView1.DataSource = Us.SearchUser(sid, name, dep, sa,role);
        GridView1.DataBind();
        UpdatePanel2.Update();
        Panel4.Visible = false;
        UpdatePanel4.Update();
    }
    protected void CloseRole_Click(object sender, EventArgs e)
    {
        Panel4.Visible = false;
        UpdatePanel4.Update();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this.Page, typeof (Page), "alert", "alert('提示内容！')", true);
    }

    protected void reset_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox6.Text = "";
        DropDownList1.SelectedIndex = DropDownList1.Items.IndexOf(DropDownList1.Items.FindByValue("null"));
        Panel3.Visible = false;
        Panel4.Visible = false;
        
        GridView1.DataSource = Us.SearchUser();
        GridView1.DataBind();
        UpdatePanel3.Update();
        UpdatePanel4.Update();
        UpdatePanel2.Update();
    }
    protected void TextBox3_TextChanged(object sender, EventArgs e)
    {
        if (Label5.Text=="Label")
        {
            if (TextBox3.Text == "")
            {
                Image3.ImageUrl = "~/images/button/delete.gif";
                Image3.Visible = true;
                flag2.Text = "no";
            }
            else if (_strList2.Contains(TextBox3.Text))
            {
                Image3.ImageUrl = "~/images/button/delete.gif";
                Image3.Visible = true;
                flag2.Text = "no";

            }
            else
            {
                Image3.ImageUrl = "~/images/button/ok.gif";
                Image3.Visible = true;
                flag2.Text = "yes";
            }
        }
        else
        {
            if (TextBox3.Text == "")
            {
                Image3.ImageUrl = "~/images/button/delete.gif";
                Image3.Visible = true;
                flag2.Text = "no";
            }
            else if (_strList2.Contains(TextBox3.Text)&&TextBox3.Text!=Label5.Text)
            {
                Image3.ImageUrl = "~/images/button/delete.gif";
                Image3.Visible = true;
                flag2.Text = "no";

            }
            else
            {
                Image3.ImageUrl = "~/images/button/ok.gif";
                Image3.Visible = true;
                flag2.Text = "yes";
            }
        }
    }
    protected void TextBox5_TextChanged(object sender, EventArgs e)
    {
        if (Label6.Text == "Label")
        {
            if (TextBox5.Text == "")
            {
                Image4.ImageUrl = "~/images/button/delete.gif";
                Image4.Visible = true;
                flag3.Text = "no";
            }
            else if (_strList3.Contains(TextBox5.Text))
            {
                Image4.ImageUrl = "~/images/button/delete.gif";
                Image4.Visible = true;
                flag3.Text = "no";

            }
            else
            {
                Image4.ImageUrl = "~/images/button/ok.gif";
                Image4.Visible = true;
                flag3.Text = "yes";
            }
        }
        else
        {
            if (TextBox5.Text == "")
            {
                Image4.ImageUrl = "~/images/button/delete.gif";
                Image4.Visible = true;
                flag3.Text = "no";
            }
            else if (_strList3.Contains(TextBox3.Text) && TextBox5.Text != Label6.Text)
            {
                Image4.ImageUrl = "~/images/button/delete.gif";
                Image4.Visible = true;
                flag3.Text = "no";

            }
            else
            {
                Image4.ImageUrl = "~/images/button/ok.gif";
                Image4.Visible = true;
                flag3.Text = "yes";
            }
        }
    }
    protected void RTXSync_Click(object sender, EventArgs e)
    {
        string username = Us.SelectRtxUserName(TextBox3.Text);
        if (username == "用户重名")
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof (Page), "alert", "alert('RTX匹配到多个用户,请修改RTX姓名!')", true);
            
        }

        else if (username != "")
        {
            TextBox5.Text = username;
            
            if (Label6.Text == "Label")
            {
                if (TextBox5.Text == "")
                {
                    Image4.ImageUrl = "~/images/button/delete.gif";
                    Image4.Visible = true;
                    flag3.Text = "no";
                }
                else if (_strList3.Contains(TextBox5.Text))
                {
                    Image4.ImageUrl = "~/images/button/delete.gif";
                    Image4.Visible = true;
                    flag3.Text = "no";

                }
                else
                {
                    Image4.ImageUrl = "~/images/button/ok.gif";
                    Image4.Visible = true;
                    flag3.Text = "yes";
                }
            }
            else
            {
                if (TextBox5.Text == "")
                {
                    Image4.ImageUrl = "~/images/button/delete.gif";
                    Image4.Visible = true;
                    flag3.Text = "no";
                }
                else if (_strList3.Contains(TextBox3.Text) && TextBox5.Text != Label6.Text)
                {
                    Image4.ImageUrl = "~/images/button/delete.gif";
                    Image4.Visible = true;
                    flag3.Text = "no";

                }
                else
                {
                    Image4.ImageUrl = "~/images/button/ok.gif";
                    Image4.Visible = true;
                    flag3.Text = "yes";
                }
            }
            ScriptManager.RegisterStartupScript(this.Page, typeof (Page), "alert", "alert('同步成功!')", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof (Page), "alert", "alert('RTX中没有相关用户,请先在RTX中添加用户!')", true);
            RTXstate.Text = "add";
        }
        
    }
    protected void GridView２_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName=="Choose")
        {
          int a=  Us.CopyRole(code.Text,e.CommandArgument.ToString());
          if (a == 1)
          {
              string name = TextBox1.Text;
              string id1 = TextBox2.Text;
              string dep = DropDownList1.SelectedValue;
              int a1 = CheckBox1.Checked ? 1 : 0;
              string role = TextBox6.Text;
              GridView1.DataSource = Us.SearchUser(id1, name, dep, a1, role);
              GridView1.DataBind();
              Panel5.Visible = false;
              Panel6.Visible = false;
              UpdatePanel2.Update();
              UpdatePanel5.Update();
              ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('复制成功啦!')", true);
          }
          else
          {
              ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('复制失败了...')", true);
          }
        }
    }
    protected void Search２_Click(object sender, EventArgs e)
    {
        string name = TextBox7.Text;
        string id = TextBox8.Text;
        string dep = DropDownList3.SelectedValue;
        string role = TextBox9.Text;
        int a = CheckBox2.Checked ? 1 : 0;
        
        Panel3.Visible = false;
        Panel4.Visible = false;
        GridView2.DataSource = Us.SearchUser(id, name, dep, a, role);
        GridView2.DataBind();
        UpdatePanel2.Update();
        UpdatePanel3.Update();
        UpdatePanel4.Update();
        UpdatePanel5.Update();
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView1.BottomPagerRow;


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
        string name = TextBox7.Text;
        string id = TextBox8.Text;
        string dep = DropDownList3.SelectedValue;
        int a = CheckBox2.Checked ? 1 : 0;
        string role = TextBox9.Text;
        GridView2.DataSource = Us.SearchUser(id, name, dep, a, role);
        GridView2.DataBind();

        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView1.PageCount ? GridView2.PageCount - 1 : newPageIndex;
        GridView2.PageIndex = newPageIndex;
        GridView2.DataBind();
    }

    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.DataRow) return;
        if (e.Row.Cells[4].Text.Length <= 20) return;
        e.Row.Cells[4].ToolTip = e.Row.Cells[4].Text;
        e.Row.Cells[4].Text = e.Row.Cells[4].Text.Substring(0, 20);
    }
    protected void Close2_Click(object sender, EventArgs e)
    {
        Panel5.Visible = false;
        Panel6.Visible = false;
        UpdatePanel5.Update();
    }
}