using System.Collections.Generic;
/// <summary>
///CraftMgtUserStatLook 的摘要说明
/// </summary>
public class CraftMgtUserStatLook : UserStat
{
    public override bool CheckRoleBelong(UserRole user, string CurrentStat)
    {

        if (CurrentStat.Contains("工序查看") == true)
        {
            foreach (CollectWebControl m in base.CollectWebControlList)
            {
                m.SetVisible(false);
            }
            return true;
        }
        else
        {
            //base.PageInfo.Response.Redirect("~/Default.aspx");
            base.RedirectDefault();
            return false;
        }
    }

    public CraftMgtUserStatLook(List<CollectWebControl> input)
	{
        base.mCollectWebControlList = input;
        
	}
}
    