using System;
using System.Data;

/// <summary>
///IEquipUnusedApp 的摘要说明
/// </summary>
public interface IEquipUnusedApp
{
    DataSet Search_InsertEquipUnusedApp(string ETT_Type, string EN_EquipName, string EMT_Type, string EI_No);
    void Insert_EquipUnusedApp(Guid EI_ID, short EUA_UseYear, string EUA_AppPer, DateTime EUA_AppTime, string EUA_Reason, string EUA_AppState);
    void Update_EquipUnusedApp_SQ(Guid EUA_ID, short EUA_UseYear, string EUA_AppPer, DateTime EUA_AppTime, string EUA_Reason, string EUA_AppNO, string EUA_AppState);
    int Delete_EquipUnusedApp(Guid EUA_ID);
    DataSet Search_EquipUnusedApp(string condition);
    void Update_EquipUnusedApp_SP1(Guid EUA_ID, string EUA_Approver, DateTime EUA_ApprovalT, string EUA_ApprovalSugg, string EUA_ApprovalRes);
    void Update_EquipUnusedApp_SP2(Guid EUA_ID,string EUA_Approver2, DateTime EUA_ApprovalT2, string EUA_ApprovalSugg2, string EUA_ApprovalRes2);
    void Update_EquipUnusedApp_CL(Guid EUA_ID, string EUA_DealPer,DateTime EUA_DealTime);
    void Update_EquipUnusedApp_PZ(Guid EUA_ID, string EUA_Allower, DateTime EUA_AllowT, string EUA_AllowSugg, string EUA_AllowRes, string EUA_AppState);
}