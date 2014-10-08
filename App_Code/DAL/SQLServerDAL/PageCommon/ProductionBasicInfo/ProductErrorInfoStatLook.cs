using System.Collections.Generic;
/// <summary>
///ProductErrorInfo 的摘要说明
/// </summary>
public class ProductErrorInfoLook: UserStat
{
    public override bool CheckRoleBelong(UserRole user, string CurrentStat)
    {

        if (CurrentStat.Contains("异常原因现象选项查看") == true)
        {
            foreach (CollectWebControl m in base.CollectWebControlList)
            {
                m.SetVisible(false);
            }
            return true;
        }
        else
        {
            //base.PageInfo.Response.Write("删除成功");
            //base.PageInfo.Response.Redirect("~/Default.aspx");
            //string alertStr = "对不起，您的权限不足!";
            //string navigateUrl = "~/Default.aspx";
            //string jsStr = string.Format("<script>alert('{0}');window.location.href='{1}';</script>", alertStr, navigateUrl);
            //base.PageInfo.Response.Write(jsStr);
            base.RedirectDefault();
            return false;
        }
    }
    public ProductErrorInfoLook(List<CollectWebControl> input)
	{
        base.mCollectWebControlList = input;
	}
}