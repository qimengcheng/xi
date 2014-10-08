using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class REPORT_cc_InOutStoreSum : System.Web.UI.Page
{
    InOutStoreSum ioss = new InOutStoreSum();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!(Session["UserRole"].ToString().Contains("出入库发货统计表")))
            {
                Response.Redirect("~/Default.aspx");
            }

        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('可能您没有权限操作和查看本页面，请退出选择其他账号登陆，或联系管理员！')", true);
            Response.Redirect("~/Default.aspx");
        }
    }


    protected void GridInOutStoreSum_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            //获取表头所在行的所有单元格
            TableCellCollection tcHeader = e.Row.Cells;
            //清除自动生成的表头
            tcHeader.Clear();

            //第一行表头
            tcHeader.Add(new TableHeaderCell());
            tcHeader[0].RowSpan = 2;
            tcHeader[0].Text = "系列名称";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[1].RowSpan = 2;
            tcHeader[1].Text = "产品型号";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[2].ColumnSpan = 8;
            tcHeader[2].Text = "一月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[3].ColumnSpan = 8;
            tcHeader[3].Text = "二月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[4].ColumnSpan = 8;
            tcHeader[4].Text = "三月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[5].ColumnSpan = 8;
            tcHeader[5].Text = "四月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[6].ColumnSpan = 8;
            tcHeader[6].Text = "五月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[7].ColumnSpan = 8;
            tcHeader[7].Text = "六月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[8].ColumnSpan = 8;
            tcHeader[8].Text = "七月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[9].ColumnSpan = 8;
            tcHeader[9].Text = "八月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[10].ColumnSpan = 8;
            tcHeader[10].Text = "九月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[11].ColumnSpan = 8;
            tcHeader[11].Text = "十月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[12].ColumnSpan = 8;
            tcHeader[12].Text = "十一月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[13].ColumnSpan = 8;
            tcHeader[13].Text = "十二月</th></tr><tr>";

            //第二行表头 一月
            tcHeader.Add(new TableHeaderCell());
            tcHeader[14].Text = "销售计划";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[15].Text = "投产计划";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[16].Text = "实际投产";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[17].Text = "入库";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[18].Text = "发货";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[19].Text = "1月25日库存";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[20].Text = "完成率";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[21].Text = "投入产出比";

            //第二行表头 二月
            tcHeader.Add(new TableHeaderCell());
            tcHeader[22].Text = "销售计划";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[23].Text = "投产计划";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[24].Text = "实际投产";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[25].Text = "入库";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[26].Text = "发货";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[27].Text = "2月25日库存";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[28].Text = "完成率";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[29].Text = "投入产出比";


            //第二行表头 三月
            tcHeader.Add(new TableHeaderCell());
            tcHeader[30].Text = "销售计划";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[31].Text = "投产计划";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[32].Text = "实际投产";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[33].Text = "入库";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[34].Text = "发货";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[35].Text = "3月25日库存";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[36].Text = "完成率";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[37].Text = "投入产出比";


            //第二行表头 四月
            tcHeader.Add(new TableHeaderCell());
            tcHeader[38].Text = "销售计划";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[39].Text = "投产计划";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[40].Text = "实际投产";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[41].Text = "入库";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[42].Text = "发货";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[43].Text = "4月25日库存";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[44].Text = "完成率";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[45].Text = "投入产出比";


            //第二行表头 五月
            tcHeader.Add(new TableHeaderCell());
            tcHeader[46].Text = "销售计划";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[47].Text = "投产计划";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[48].Text = "实际投产";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[49].Text = "入库";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[50].Text = "发货";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[51].Text = "5月25日库存";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[52].Text = "完成率";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[53].Text = "投入产出比";


            //第二行表头 六月
            tcHeader.Add(new TableHeaderCell());
            tcHeader[54].Text = "销售计划";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[55].Text = "投产计划";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[56].Text = "实际投产";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[57].Text = "入库";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[58].Text = "发货";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[59].Text = "6月25日库存";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[60].Text = "完成率";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[61].Text = "投入产出比";


            //第二行表头 七月
            tcHeader.Add(new TableHeaderCell());
            tcHeader[62].Text = "销售计划";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[63].Text = "投产计划";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[64].Text = "实际投产";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[65].Text = "入库";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[66].Text = "发货";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[67].Text = "7月25日库存";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[68].Text = "完成率";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[69].Text = "投入产出比";


            //第二行表头 八月
            tcHeader.Add(new TableHeaderCell());
            tcHeader[70].Text = "销售计划";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[71].Text = "投产计划";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[72].Text = "实际投产";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[73].Text = "入库";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[74].Text = "发货";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[75].Text = "8月25日库存";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[76].Text = "完成率";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[77].Text = "投入产出比";


            //第二行表头 九月
            tcHeader.Add(new TableHeaderCell());
            tcHeader[78].Text = "销售计划";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[79].Text = "投产计划";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[80].Text = "实际投产";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[81].Text = "入库";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[82].Text = "发货";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[83].Text = "9月25日库存";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[84].Text = "完成率";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[85].Text = "投入产出比";


            //第二行表头 十月
            tcHeader.Add(new TableHeaderCell());
            tcHeader[86].Text = "销售计划";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[87].Text = "投产计划";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[88].Text = "实际投产";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[89].Text = "入库";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[90].Text = "发货";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[91].Text = "10月25日库存";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[92].Text = "完成率";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[93].Text = "投入产出比";


            //第二行表头 十一月
            tcHeader.Add(new TableHeaderCell());
            tcHeader[94].Text = "销售计划";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[95].Text = "投产计划";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[96].Text = "实际投产";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[97].Text = "入库";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[98].Text = "发货";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[99].Text = "11月25日库存";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[100].Text = "完成率";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[101].Text = "投入产出比";


            //第二行表头 十二月
            tcHeader.Add(new TableHeaderCell());
            tcHeader[102].Text = "销售计划";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[103].Text = "投产计划";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[104].Text = "实际投产";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[105].Text = "入库";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[106].Text = "发货";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[107].Text = "1月25日库存";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[108].Text = "完成率";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[109].Text = "投入产出比";
        }
    }
    protected void BtnExcel_Click(object sender, EventArgs e)
    {
        if (this.TxtYear.Text.ToString() == "" || this.TxtYear.Text.ToString().Length != 4)
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('请填入正确的年份！')", true);
            return;
        }
        Grid1.AllowPaging = false;
        Grid1.AllowSorting = false;
        int year = Convert.ToInt16(TxtYear.Text.Trim().ToString());
        Grid1.DataSource = ioss.SearchInOutStoreSum(year);
        Grid1.DataBind();

        ExcelHelper.GridViewToExcel(Grid1,TxtYear.Text.Trim().ToString()+"年入库发货统计表");
        Grid1.AllowSorting = true;
        Grid1.AllowPaging = true;
    }
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        TxtYear.Text = "";
        Grid1.DataSource = null;
        Grid1.DataBind();
        UpdatePanel2.Update();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
}