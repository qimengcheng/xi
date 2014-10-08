using System;

/// <summary>
///EMEquipUnusedAppInfo 的摘要说明
/// </summary>
public class EMEquipUnusedAppInfo
{
    private Guid eUA_ID;
    private short eUA_UseYear;
    private string eUA_AppPer;
    private DateTime eUA_AppTime;
    private string eUA_Reason;
    private string eUA_AppNO;
    private string eUA_AppState;
    private string eUA_Approver;
    private DateTime eUA_ApprovalT;
    private string eUA_ApprovalSugg;
    private string eUA_ApprovalRes;
    private string eUA_DealPer;
    private DateTime eUA_DealTime;

    private Guid eI_ID;
    private string eI_No;
    private string eI_State;

    private string eTT_Type;
    private string eN_EquipName;
    private string eMT_Type;

	public EMEquipUnusedAppInfo()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public EMEquipUnusedAppInfo(Guid _eUA_ID, short _eUA_UseYear, string _eUA_AppPer, DateTime _eUA_AppTime, string _eUA_Reason, string _eUA_AppNO, string _eUA_AppState,
        string _eUA_Approver, DateTime _eUA_ApprovalT, string _eUA_ApprovalSugg, string _eUA_ApprovalRes, string _eUA_DealPer, DateTime _eUA_DealTime, Guid _eI_ID,
        string _eI_No, string _eI_State, string _eTT_Type, string _eN_EquipName, string _eMT_Type)
    {
        eUA_ID = _eUA_ID;
        eUA_UseYear = _eUA_UseYear;
        eUA_AppPer = _eUA_AppPer;
        eUA_AppTime=_eUA_AppTime;
        eUA_Reason=_eUA_Reason;
        eUA_AppNO=_eUA_AppNO;
        eUA_AppState=_eUA_AppState;
        eUA_Approver=_eUA_Approver;
        eUA_ApprovalT=_eUA_ApprovalT;
        eUA_ApprovalSugg=_eUA_ApprovalSugg;
        eUA_ApprovalRes=_eUA_ApprovalRes;
        eUA_DealPer=_eUA_DealPer;
        eUA_DealTime=_eUA_DealTime;
        eI_ID=_eI_ID;
        eI_No=_eI_No;
        eI_State=_eI_State;
        eTT_Type = _eTT_Type;
        eN_EquipName = _eN_EquipName;
        eMT_Type = _eMT_Type;
    }
    public Guid EUA_ID
    {
        get { return eUA_ID; }
        set { eUA_ID = value; }
    }
    public short EUA_UseYear
    {
        get { return eUA_UseYear; }
        set { eUA_UseYear = value; }
    }
    public string EUA_AppPer
    {
        get { return eUA_AppPer; }
        set { eUA_AppPer = value; }
    }
    public DateTime EUA_AppTime
    {
        get { return eUA_AppTime; }
        set { eUA_AppTime = value; }
    }
    public string EUA_Reason
    {
        get { return eUA_Reason; }
        set { eUA_Reason = value; }
    }
    public string EUA_AppNO
    {
        get { return eUA_AppNO; }
        set { eUA_AppNO = value; }
    }
    public string EUA_AppState
    {
        get { return eUA_AppState; }
        set { eUA_AppState = value; }
    }
    public string EUA_Approver
    {
        get { return eUA_Approver; }
        set { eUA_Approver = value; }
    }
    public DateTime EUA_ApprovalT
    {
        get { return eUA_ApprovalT; }
        set { eUA_ApprovalT = value; }
    }
    public string EUA_ApprovalSugg
    {
        get { return eUA_ApprovalSugg; }
        set { eUA_ApprovalSugg = value; }
    }
    public string EUA_ApprovalRes1
    {
        get { return eUA_ApprovalRes; }
        set { eUA_ApprovalRes = value; }
    }
    public string EUA_ApprovalRes
    {
        get { return eUA_ApprovalRes; }
        set { eUA_ApprovalRes = value; }
    }
    public string EUA_DealPer
    {
        get { return eUA_DealPer; }
        set { eUA_DealPer = value; }
    }
    public DateTime EUA_DealTime
    {
        get { return eUA_DealTime; }
        set { eUA_DealTime = value; }
    }
    public Guid EI_ID
    {
        get { return eI_ID; }
        set { eI_ID = value; }
    }
    public string EI_No
    {
        get { return eI_No; }
        set { eI_No = value; }
    }
    public string EI_State
    {
        get { return eI_State; }
        set { eI_State = value; }
    }
    public string ETT_Type
    {
        get { return eTT_Type; }
        set { eTT_Type = value; }
    }
    public string EN_EquipName
    {
        get { return eN_EquipName; }
        set { eN_EquipName = value; }
    }
    public string EMT_Type
    {
        get { return eMT_Type; }
        set { eMT_Type = value; }
    }
}