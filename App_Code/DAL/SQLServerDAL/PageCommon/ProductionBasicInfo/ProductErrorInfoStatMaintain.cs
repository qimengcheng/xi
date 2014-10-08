using System.Collections.Generic;

/// <summary>
///ProductErrorInfoStatMaintain 的摘要说明
/// </summary>
public class ProductErrorInfoStatMaintain : UserStat
{
    public override bool CheckRoleBelong(UserRole user, string CurrentStat)
    {
        if (CurrentStat.Contains("异常原因现象选项维护") == true)
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
    public ProductErrorInfoStatMaintain(List<CollectWebControl> input)
	{
        base.mCollectWebControlList = input;
	}
}