using System;

/// <summary>
///UMUserInfoInfo 的摘要说明
/// </summary>
public class UMUserInfoInfo
{
	
    private string uMUI_UserID;
    private string uMUI_UserName;
    private string uMUI_Password;
    private DateTime uMUI_LastLoginTime;
    private int uMUI_TotalLoginCount;
    private int uMUI_TodayLoginCount;
    private string bDOS_Code;
    private string uMUI_UserRole;
    private string bDOS_Name;
    
    
    public UMUserInfoInfo()
	{
		
	}
    public UMUserInfoInfo(string _uMUI_UserID, string _uMUI_UserName, string _uMUI_Password, DateTime _uMUI_LastLoginTime, int _uMUI_TotalLoginCount, int _uMUI_TodayLoginCount, string _bDOS_Code, string _uMUI_UserRole,string _bDOS_Name)
    {
        uMUI_UserID = _uMUI_UserID;
        uMUI_UserName = _uMUI_UserName;
        uMUI_Password = _uMUI_Password;
        uMUI_LastLoginTime = _uMUI_LastLoginTime;
        uMUI_TotalLoginCount = _uMUI_TotalLoginCount;
        uMUI_TodayLoginCount = _uMUI_TodayLoginCount;
        bDOS_Code = _bDOS_Code;
        uMUI_UserRole = _uMUI_UserRole;
        bDOS_Name = _bDOS_Name;
    }

    public string UMUI_UserID
    {
        get { return uMUI_UserID; }
        set { uMUI_UserID = value; }
    }
    public string UMUI_UserName
    {
        get { return uMUI_UserName; }
        set { uMUI_UserName = value; }
    }
    public string UMUI_Password
    {
        get { return uMUI_Password; }
        set { uMUI_Password = value; }
    }
    public DateTime UMUI_LastLoginTime
    {
        get { return uMUI_LastLoginTime; }
        set { uMUI_LastLoginTime = value; }
    }
    public int UMUI_TotalLoginCount
    {
        get { return uMUI_TotalLoginCount; }
        set { uMUI_TotalLoginCount = value; }
    }
    public int UMUI_TodayLoginCount
    {
        get { return uMUI_TodayLoginCount; }
        set { uMUI_TodayLoginCount = value; }
    }
    public string BDOS_Code
    {
        get { return bDOS_Code; }
        set { bDOS_Code = value; }
    }
    public string UMUI_UserRole
    {
        get { return uMUI_UserRole; }
        set { uMUI_UserRole = value; }
    }
    public string BDOS_Name
    {
        get { return bDOS_Name; }
        set { bDOS_Name = value; }
    }
   
}
