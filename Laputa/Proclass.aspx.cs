using System;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class ProductionProcess_MaterialApply : Page
{
    ProClassifiedInfoD pc = new ProClassifiedInfoD();

    static DataSet ds = new DataSet();
    static string type;
    static Guid id;
    static string flag;
    static int index;
    static string[] history = new string[4];


    protected void Page_Load(object sender, EventArgs e)
    {
        LinkButton2.Text = history[0];
        LinkButton3.Text = history[1];
        LinkButton4.Text = history[2];
        LinkButton5.Text = history[3];
        GridView_Proclass.Attributes.Add("SortExpression", "型号");
        GridView_Proclass.Attributes.Add("SortDirection", "ASC");
        if (history[0] != "")
        {
            Label1.Visible = false;
            Button3.Visible = false;

        }
        else { Label1.Visible = true; Button3.Visible = true; }
        if (!Page.IsPostBack)
        {
            BindGrid();
        }

        try
        {
            if (!Session["UserRole"].ToString().Contains("产品分档数据维护"))
            {
                if (!Session["UserRole"].ToString().Contains("产品分档数据查看"))
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('用户未登录或无权限！');</script>");

                    Response.Redirect("~/Default.aspx");
                }
                GridView_Proclass.Columns[2].Visible = false;
                GridView_Proclass.Columns[6].Visible = false;
                GridView_Proclass.Columns[7].Visible = false;

            }
           
        }



        catch (Exception)
        {

            Response.Write("<script language=javascript>alert('登陆失效，请重新登陆');</script>");
            Response.Redirect("~/Default.aspx");
        }
    }

    public void SetHistory(string type)
    {
        if (!history.Contains(type))
        {
            history[index] = type;
            index++;
            LinkButton2.Text = history[0];
            LinkButton3.Text = history[1];
            LinkButton4.Text = history[2];
            LinkButton5.Text = history[3];
            Label1.Visible = true;
            Button3.Visible = true;
        }
        if (index > 3)
        {
            index = 0;
        }
    }
    public void GetHistory()
    {
    }
    public void BindGrid()
    {
        type = "%";
        try
        {
            
            ds.Clear();
            ds = pc.Query_ProClassifiedInfo(type);
            GridView_Proclass.DataSource = ds;
            DataBind();
        }
        catch (Exception)
        {

            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('查询失败');</script>");
        }

    }
   

   
    protected void Btn_Search_Click(object sender, EventArgs e)
    {
        type = TextBox1.Text.ToString();
        try
        {
            if (type != "")
            {
                SetHistory(type);
               
            }
                ds = pc.Query_ProClassifiedInfo(type);
                GridView_Proclass.DataSource = ds;
                DataBind();


        }
        catch (Exception)
        {

            throw;
        }

    }
    protected void Search()
    {
        try
        {
            ds = pc.Query_ProClassifiedInfo(type);
            GridView_Proclass.DataSource = ds;
            DataBind();
        }
        catch (Exception)
        {

            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('查询失败');</script>");
        }


    }
    protected void GridView_Proclass_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView_Proclass.EditIndex = -1;
        GridView_Proclass.DataSource = ds;
        DataBind();
    }//编辑按键下的取消代码。将EditIndex=-1,然后在绑定数据库。




    protected void GridView_Proclass_RowEditing(object sender, GridViewEditEventArgs e)
    {

        flag = GridView_Proclass.DataKeys[e.NewEditIndex][0].ToString();
        GridView_Proclass.EditIndex = e.NewEditIndex;
        ds = pc.Query_ProClassifiedInfo(type);
        GridView_Proclass.DataSource = ds;
        DataBind();



    }//获取当前编辑状态

    protected void GridView_Proclass_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        string Name = ((LinkButton)GridView_Proclass.Rows[e.RowIndex].Cells[0].FindControl("PT_Name")).CommandArgument;
        //((TextBox)GridView_Proclass.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
        string Class = ((TextBox)GridView_Proclass.Rows[e.RowIndex].Cells[3].Controls[0]).Text;
        string Type = ((TextBox)GridView_Proclass.Rows[e.RowIndex].Cells[4].Controls[0]).Text;
        string Need = ((TextBox)GridView_Proclass.Rows[e.RowIndex].Cells[5].Controls[0]).Text;

        if (Name == "" || Class == "" || Type == "" || Need == "")
        {
            //Response.Write("<script>alert('不能为空');</script>");
            e.Cancel = true;
            return;
        }
        else
        {


            if (flag == "" || flag == null)
            {
                try
                {
                    pc.Insert_ProClassifiedInfo(Name, Class, Type, Need);
                }
                catch (Exception)
                {

                    throw;
                }


            }
            else
            {
                try
                {
                    Guid Id = new Guid(GridView_Proclass.DataKeys[e.RowIndex][0].ToString());
                    pc.Update_ProClassifiedInfo(Id, Class, Type, Need);
                }
                catch (Exception)
                {

                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('更新失败');</script>");
                }

            }
            try
            {
                GridView_Proclass.EditIndex = -1;
                ds = pc.Query_ProClassifiedInfo(type);
                GridView_Proclass.DataSource = ds;
                DataBind();
            }
            catch (Exception)
            {

                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('查询失败');</script>");
            }



        }//获得GridView中选中行的各列数据，用UpdataGridView()更新数据
    }


    protected void GridView_Proclass_SelectedIndexChanged(object sender, EventArgs e)
    {


    }

    protected void GridView_Proclass_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            Guid Id = new Guid(GridView_Proclass.DataKeys[e.RowIndex][0].ToString());
            pc.Delete_ProClassifiedInfo(Id);

        }
        catch (Exception)
        {

            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('删除失败');</script>");
        }
        try
        {
           
            ds = pc.Query_ProClassifiedInfo(type);
            GridView_Proclass.DataSource = ds;
            DataBind();
        }
        catch (Exception)
        {

            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('查询失败');</script>");

        }

    }


    protected void GridView_Proclass_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {


    }

    protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void GridView_Proclass_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }
    protected void GridView_Proclass_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "New")
        {

            Panel1.Visible = true;
            UpdatePanel2.Update();
            TextBox5.Text = e.CommandArgument.ToString();


            //(int)e.CommandArgument

            //id = new Guid((GridView_Proclass.Rows[(int)e.CommandArgument].Cells[0].Controls[0]).ToString());
        }
        if (e.CommandName == "Search")
        {
            try
            {
                type = e.CommandArgument.ToString();
                ds = pc.Query_ProClassifiedInfo(type);
                GridView_Proclass.DataSource = ds;
                DataBind();
                UpdatePanel1.Update();
            }
            catch (Exception)
            {

                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('查询失败');</script>");
            }




        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string a = TextBox5.Text.ToString();
        string b = TextBox2.Text.ToString();
        string c = TextBox3.Text.ToString();
        string d = TextBox4.Text.ToString();
        try
        {
            pc.Insert_ProClassifiedInfo(a, b, c, d);
            BindGrid();
            UpdatePanel1.Update();
        }
        catch (Exception)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('插入失败');</script>");
        }



    }


    public void Alert(string str_Message)
    {





        //第一种
        Response.Write("<script language=javascript>alert('" + str_Message + "');</script>");
        //第二种      

        ClientScriptManager scriptManager = ((Page)HttpContext.Current.Handler).ClientScript;
        scriptManager.RegisterStartupScript(typeof(string), "", "alert('" + str_Message + "');", true);
        //第三种
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('" + str_Message + "');</script>");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        UpdatePanel2.Update();

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        //Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('小薛薛');</script>");
        history = null;
        history = new string[4];
        LinkButton2.Text = history[0];
        LinkButton3.Text = history[1];
        LinkButton4.Text = history[2];
        LinkButton5.Text = history[3];
        Label1.Visible = false;
        Button3.Visible = false;
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        type = LinkButton2.Text;
        Search();
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        type = LinkButton3.Text;
        Search();

    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        type = LinkButton4.Text;
        Search();
    }
    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        type = LinkButton5.Text;
        Search();
    }
    protected void GridView_Proclass_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
    protected void GridView_Proclass_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if ((e.Row.RowState & DataControlRowState.Edit) == DataControlRowState.Edit)
        //{
        //    RequiredFieldValidator re = new RequiredFieldValidator();   // 创建一个非空验证控件
        //    re.ControlToValidate = "GridView_Proclass";
        //    re.ErrorMessage = "不能为空";
        //    re.Display = ValidatorDisplay.Dynamic;
        //    re.Text = "*";
        //    e.Row.Cells[5].Controls.Add(re);              //           将该空间添加到GridView控件中
        //    //RangeValidator ra = new RangeValidator();
        //    //ra.ControlToValidate = "t1";
        //    //ra.Type = ValidationDataType.Integer;
        //    //ra.Display = ValidatorDisplay.Dynamic;
        //    //ra.MaximumValue = "200";
        //    //ra.MinimumValue = "10";
        //    //ra.Text = "*";
        //    //ra.ErrorMessage = "销售量的范围为10-200";
        //    //e.Row.Cells[1].Controls.Add(ra);
        //    //ValidationSummary va = new ValidationSummary();        //    创建一个范围验证控件
        //    //va.ShowSummary = false;
        //    //va.ShowMessageBox = true;
        //    //e.Row.Cells[1].Controls.Add(va);               //    添加到GridView中
        //}
    }

   
}

