using System;
using System.Data;

/// <summary>
///EquipUnusedAppL 的摘要说明
/// </summary>
public class EquipUnusedAppL
{
    private static readonly IEquipUnusedApp equipm = DALFactory.CreateEquipUnusedApp();
	public EquipUnusedAppL()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public DataSet Search_InsertEquipUnusedApp(string ETT_Type, string EN_EquipName, string EMT_Type, string EI_No)
    {
        return equipm.Search_InsertEquipUnusedApp(ETT_Type,EN_EquipName,EMT_Type,EI_No);
    }
    public void Insert_EquipUnusedApp(Guid EI_ID, short EUA_UseYear, string EUA_AppPer, DateTime EUA_AppTime, string EUA_Reason, string EUA_AppState)
    {
        equipm.Insert_EquipUnusedApp(EI_ID, EUA_UseYear, EUA_AppPer, EUA_AppTime, EUA_Reason, EUA_AppState);
    }
    public void Update_EquipUnusedApp_SQ(Guid EUA_ID, short EUA_UseYear, string EUA_AppPer, DateTime EUA_AppTime, string EUA_Reason, string EUA_AppNO, string EUA_AppState)
    {
        equipm.Update_EquipUnusedApp_SQ(EUA_ID, EUA_UseYear, EUA_AppPer, EUA_AppTime, EUA_Reason, EUA_AppNO, EUA_AppState);
    }
    public int Delete_EquipUnusedApp(Guid EUA_ID)
    {
        return equipm.Delete_EquipUnusedApp(EUA_ID);
    }
    public DataSet Search_EquipUnusedApp(string condition)
    {
        return equipm.Search_EquipUnusedApp(condition);
    }
    public void Update_EquipUnusedApp_SP1(Guid EUA_ID, string EUA_Approver, DateTime EUA_ApprovalT, string EUA_ApprovalSugg, string EUA_ApprovalRes)
    {
        equipm.Update_EquipUnusedApp_SP1(EUA_ID,EUA_Approver,EUA_ApprovalT,EUA_ApprovalSugg, EUA_ApprovalRes);
    }
    public void Update_EquipUnusedApp_SP2(Guid EUA_ID,string EUA_Approver2, DateTime EUA_ApprovalT2, string EUA_ApprovalSugg2, string EUA_ApprovalRes2)
    {
        equipm.Update_EquipUnusedApp_SP2(EUA_ID, EUA_Approver2, EUA_ApprovalT2, EUA_ApprovalSugg2, EUA_ApprovalRes2);
    }
    public void Update_EquipUnusedApp_CL(Guid EUA_ID, string EUA_DealPer, DateTime EUA_DealTime)
    {
        equipm.Update_EquipUnusedApp_CL(EUA_ID, EUA_DealPer, EUA_DealTime);
    }
    public void Update_EquipUnusedApp_PZ(Guid EUA_ID, string EUA_Allower, DateTime EUA_AllowT, string EUA_AllowSugg, string EUA_AllowRes, string EUA_AppState)
    {
        equipm.Update_EquipUnusedApp_PZ(EUA_ID, EUA_Allower, EUA_AllowT, EUA_AllowSugg, EUA_AllowRes, EUA_AppState);
    }
}