/* ==============================================================================
 * 类名称：UserStat 
 * 类的作用描述:状态模式下的stat类，抽象状态类
 * 创建人：bush2582
 * 创建时间：3/13/2014 15:53
 * 修改人：
 * 修改时间：
 * 修改备注：
 * @version 1.0
 * ==============================================================================*/

using System.Web.UI;
using System.Collections.Generic;
/// <summary>
///抽象状态类，定义一个接口以封装与Context的一个特定状态相关的行为
/// </summary>
public abstract  class UserStat : Page
{
    protected List<CollectWebControl> mCollectWebControlList;
    protected UserStat mNextStat;
    protected Page mPageInfo;

    public Page PageInfo
    {
        set
        {
            mPageInfo = value;
        }
        get
        {
            return mPageInfo;
        }
    }


    public List<CollectWebControl> CollectWebControlList
    {
        get { return mCollectWebControlList; }
        set
        {
            mCollectWebControlList = value;
        }
    }

    public abstract bool CheckRoleBelong(UserRole user, string CurrentStat);

    public void SetNextStat(UserStat NextStat,UserRole user)
    {
        mNextStat = NextStat;
        mNextStat.PageInfo = mPageInfo;
    }

    protected void RedirectDefault()
    {
        mPageInfo.Response.Redirect("~/Default.aspx");
    }

    public UserStat()
	{
        mCollectWebControlList=new List<CollectWebControl>();
        
	}
}