/* ==============================================================================
 * 类名称：PageCommon 
 * 类的作用描述:这个类bush2582所做的模块的公共类，将每个页面会用到的一些公共函数集成在这个类中，页面会集成这个类
 * 创建人：bush2582
 * 创建时间：1/15/2014 15:53
 * 修改人：
 * 修改时间：
 * 修改备注：
 * @version 1.0
 * ==============================================================================*/
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// 这个类实现了对代码的重构，将每个页面都需要用到的函数在这个类中做了集成
/// </summary>
public class PageCommon : Page
{

    

    

    BLLMatchNumber mBLLMatchNumber = new BLLMatchNumber();
    /// <summary>
    /// 函数名：Bind_Updata
    /// 作用：GridView和UpdatePanel和绑定更新函数
    /// </summary>
    /// <param name="PageGridView">要求传入的GridView</param>
    /// <param name="DataSource">DataSet源</param>
    /// <param name="PageUpdatePanel">要求传入的PageUpdatePanel</param>
    protected void Bind_Updata(GridView PageGridView, DataSet DataSource, UpdatePanel PageUpdatePanel)
    {
        PageGridView.DataSource = DataSource;
        PageGridView.DataBind();
        PageUpdatePanel.Update();
    }

    /// <summary>
    /// 函数名：Page_Turning
    /// 作用：GridView的翻页函数
    /// 作者：bush2582
    /// </summary>
    /// <param name="PageGridView">要翻页的GridView控件</param>
    /// <param name="e">事件命令集</param>
    /// <param name="CurrentPageIndex">当前GridView的页数</param>
    /// <param name="PageJumpNumber">跳转页面的数字</param>
    /// <returns>返回bool型，表示当前的命令是否属于翻页命令</returns>
    protected bool Page_Turning(GridView PageGridView, GridViewCommandEventArgs e, int CurrentPageIndex, string PageJumpNumber)
    {
        GridViewRow PageRow = PageGridView.BottomPagerRow;
        bool blIsPageTuingCommand = false;
        switch (e.CommandName)
        {
            case "PageFirst"://跳转到首页
                {
                    PageGridView.PageIndex = 0;
                    blIsPageTuingCommand = true;
                } break;
            case "PagePrev"://跳转前一页
                {
                    if (CurrentPageIndex - 1 > 0)
                    {
                        PageGridView.PageIndex = CurrentPageIndex - 1;
                    }
                    else
                    {
                        PageGridView.PageIndex = 0;
                    }
                    blIsPageTuingCommand = true;
                } break;
            case "PageNext"://跳转到下一页
                {
                    if (CurrentPageIndex + 1 >= PageGridView.PageCount)
                    {
                        PageGridView.PageIndex = PageGridView.PageCount-1;
                    }
                    else
                    {
                        PageGridView.PageIndex = CurrentPageIndex + 1;
                    }
                    blIsPageTuingCommand = true;
                } break;
            case "PageLast"://跳转末页
                {
                    PageGridView.PageIndex = PageGridView.PageCount-1;
                    blIsPageTuingCommand = true;
                } break;
            case "PageJump"://跳转任意的一页
                {
                    int IntTemp = 0;
                    IntTemp = Convert.ToInt32((((TextBox)PageRow.FindControl(PageJumpNumber)).Text.ToString()));
                    if (IntTemp >= 0 && IntTemp <= PageGridView.PageCount)
                    {
                        PageGridView.PageIndex = IntTemp - 1;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('请填写正确的页面')", true);
                    }
                    blIsPageTuingCommand = true;
                } break;

        }
        return blIsPageTuingCommand;
    }

    /// <summary>
    /// 函数名：GirdViewBubble
    /// 作用：实现当鼠标移动过某行时出现悬停的气泡
    /// 作者：bush2582
    /// 返回值：无
    /// </summary>
    /// <param name="PageGridView">要实现的GridView</param>
    protected void GirdViewBubble(GridView PageGridView)
    {
        for (int i = 0; i < PageGridView.Rows.Count; i++)
        {
            for (int j = 0; j < PageGridView.Rows[i].Cells.Count; j++)
            {
                PageGridView.Rows[i].Cells[j].ToolTip = PageGridView.Rows[i].Cells[j].Text;
                if (PageGridView.Rows[i].Cells[j].Text.Length > 20)
                {
                    PageGridView.Rows[i].Cells[j].Text = PageGridView.Rows[i].Cells[j].Text.Substring(0, 20) + "...";
                }


            }
        }
    }





	public PageCommon()
	{
        
	}
}