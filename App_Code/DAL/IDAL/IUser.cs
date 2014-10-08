using System.Collections.Generic;

/// <summary>
///IUser 的摘要说明
/// </summary>
public interface IUser
{
	
	    int Insert_UMUserInfo(UMUserInfoInfo uMUserInfoInfo);
        int Update_UMUserInfo(UMUserInfoInfo uMUserInfoInfo);
        int Delete_UMUserInfo(string uMUI_UserID);
        IList<UMUserInfoInfo> Select_UMUserInfo(string condition);
       
	
}
