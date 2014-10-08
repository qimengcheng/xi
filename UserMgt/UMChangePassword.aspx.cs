using System;
using System.Web.UI;

public partial class UserMgt_UMChangePassword : Page
{
   
        UserD userD=new UserD();
    protected void Page_Load(object sender, EventArgs e)
    {
        Title = "变更密码";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string id = Session["UserId"].ToString();
        string oldpassword = userD.EncodingPassword(TextBox1.Text);
        string newpassword = userD.EncodingPassword(TextBox2.Text);
        string repassword = userD.EncodingPassword(TextBox2.Text);
        if (oldpassword==""||newpassword==""||repassword=="")
        {
            ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('信息填写不全！')", true);
        }
        else
        {
            if (newpassword!=repassword)
            {
                ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('两次新密码不匹配！')", true);
            }
            else
            {
                int i=userD.UpdatePassword(id, oldpassword, newpassword);
                if (i != 0)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('修改成功！')", true);
                }
            else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('原密码错误,修改失败！')", true);
                }
            }
        }
            
        }
       
    
    protected void Button2_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        Label4.Visible = false;
    }
    }


