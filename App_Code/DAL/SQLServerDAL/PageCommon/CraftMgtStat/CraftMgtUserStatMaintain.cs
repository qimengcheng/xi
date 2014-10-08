/* ==============================================================================
 * 类名称：CraftMgtUserStatMaintain 
 * 类的作用描述:状态模式下的子状态，维护了有关于工序维护的权限状态
 * 创建人：bush2582
 * 创建时间：3/13/2014 15:53
 * 修改人：
 * 修改时间：
 * 修改备注：
 * @version 1.0
 * ==============================================================================*/

using System.Collections.Generic;
/// <summary>
///CraftMgtUserStatMaintain 的摘要说明
/// </summary>
public class CraftMgtUserStatMaintain:UserStat
{

    public override bool CheckRoleBelong(UserRole user, string CurrentStat)
    {
        if (CurrentStat.Contains ("工序维护")==true)
        {
            foreach (CollectWebControl m in base.CollectWebControlList)
            {
                m.SetVisible(true);
            }
            return true;
        }
        else
        {
            user.CurrentUserStat = base.mNextStat;
            user.CheckRole();
            return false;
        }
    }

    public CraftMgtUserStatMaintain(List<CollectWebControl> input)
	{
        base.mCollectWebControlList = input;
        
	}
    
}