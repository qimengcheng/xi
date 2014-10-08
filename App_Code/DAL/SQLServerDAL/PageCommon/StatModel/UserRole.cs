/* ==============================================================================
 * 类名称：UserRole 
 * 类的作用描述:状态模式下的Context，Context类，维护一个ConcreteState子类的实例，这个实例定义当前的状态。
 * 创建人：bush2582
 * 创建时间：3/13/2014 15:53
 * 修改人：
 * 修改时间：
 * 修改备注：
 * @version 1.0
 * ==============================================================================*/

using System.Web.UI;

/// <summary>
/// 这是状态模式下的一个Context
/// </summary>
public class UserRole: Page
{
    /* ===================================数据成员定义区=========================================*/
    private UserStat mClassUserStat;//模式状态
    private string mStrCurrentStat;//当前的用户权限名字

    /* ==========================================================================================*/


    /* ===================================方法定义区===========================================*/

    public UserStat CurrentUserStat
    {
        get { return mClassUserStat; }
        set { mClassUserStat = value; }
    }

    public void CheckRole()
    {
        mClassUserStat.CheckRoleBelong(this, mStrCurrentStat);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Stat"></param>
    public UserRole(UserStat Stat,Page input)
	{
        if (Session["UserRole"] == null)
        {
            input.Response.Redirect("~/Default.aspx");
            return;
        }
        mStrCurrentStat = input.Session["UserRole"].ToString();
        mClassUserStat = Stat;
        mClassUserStat.PageInfo = input;
	}
    /* ==========================================================================================*/
}