using System;
using System.Web.UI;

public partial class Laputa_sendtest : Page
{
    Rtx se=new Rtx();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {



        if (TextBox1.Text != "")
        {
            string message = TextBox1.Text;


            Guid id = Guid.NewGuid();
            id =new Guid("f1b15e85-2542-4220-90ba-8be3661eaa38");
            string sessionId = "{" + id.ToString() + "}";
            string sErr = se.RTX_SendIM("999", "uestc", message, "azi;999");
            if (!string.IsNullOrEmpty(sErr))
            {
                Label1.Text = sErr;

            }

        }
    }  
    
}