using System;
using System.Data;

/// <summary>
///IEquipMaintenanceApp 的摘要说明
/// </summary>
public interface IEquipMaintenanceApp
{
    DataSet Search_InsertEquipMaintenanceApp(string ETT_Type, string EN_EquipName, string EMT_Type, string EI_No);
    void Insert_EquipMaintenanceApp(Guid EI_ID, string EMA_AppDep, DateTime EMA_BreakDownTime, string EMA_AppPer, DateTime EMA_AppTime,
                                               string EMA_BDDetail, string EMA_AppState);
    void Update_EquipMaintenanceApp_SQ(Guid EMA_ID, string EMA_AppDep, DateTime EMA_BreakDownTime, string EMA_AppPer, DateTime EMA_AppTime,
                                               string EMA_BDDetail, string EMA_AppState);
    DataSet Search_BDOrganizationSheet_EquipMaintenanceApp();
    int Delete_EquipMaintenanceApp(Guid EMA_ID);
    DataSet Search_EquipMaintenanceApp(string condition);
    void Update_EquipMaintenanceApp_QR(Guid EMA_ID, string EMA_AckPer, DateTime EMA_AckTime, string EMA_AppState);
    void Update_EquipMaintenanceApp_YS(Guid EMA_ID, string EMA_CheckPer, DateTime EMA_CheckTime, string EMA_CheckRes, string EMA_CheckSugg, string EMA_AppState);
    void Insert_EquipRealDetailAOApp_CN(Guid EI_ID, Guid EMA_ID, string ERDAOA_MaintPer, DateTime ERDAOA_StartTime, DateTime ERDAOA_EndTime,
                                               string ERDAOA_ReasonMethod, string ERDAOA_Remarks);
    void Update_EquipRealDetailAOApp_CN(Guid ERDAOA_ID, string ERDAOA_MaintPer, DateTime ERDAOA_StartTime, DateTime ERDAOA_EndTime,
                                               string ERDAOA_ReasonMethod, string ERDAOA_Remarks);
    int Delete_EquipRealDetailAOApp_CN(Guid ERDAOA_ID);
    DataSet Search_EquipRealDetailAOApp_CN(string condition);
    void Insert_EquipRealDetailAOApp_Spare(Guid EFUS_ID, Guid ERDAOA_ID, int EMSAUS_UseAmount);
    void Update_EquipMaintenanceApp_CL(Guid EMA_ID, string EMA_AppState);
    void Insert_EquipRealDetailAOApp_CC(Guid EI_ID, Guid EMA_ID, string ERDAOA_OAppDep, string ERDAOA_OAppPer, DateTime ERDAOA_OAppTime,
                                               string ERDAOA_OAppState, string ERDAOA_OMaintePlace, string ERDAOA_Feature, string ERDAOA_OReson);
    void Update_EquipRealDetailAOApp_CC(Guid ERDAOA_ID, string ERDAOA_OAppDep, string ERDAOA_OAppPer, DateTime ERDAOA_OAppTime,
                                               string ERDAOA_OAppState, string ERDAOA_OMaintePlace, string ERDAOA_Feature, string ERDAOA_OReson);
    DataSet Search_EquipRealDetailAOApp_CC(string condition);
    void Update_EquipRealDetailAOApp_CCSP(Guid ERDAOA_ID, string ERDAOA_Approver, DateTime ERDAOA_ApprovalT, string ERDAOA_ApprovalSugg, string ERDAOA_ApprovalRes, string ERDAOA_OAppState);
    void Update_EquipRealDetailAOApp_CCYS(Guid ERDAOA_ID, DateTime ERDAOA_ExpectODate, DateTime ERDAOA_ExpectIDate, decimal ERDAOA_ExpectCost,
                                                        string ERDAOA_PerInCharge, DateTime ERDAOA_RecordDate, string ERDAOA_OAppState);
    void Update_EquipRealDetailAOApp_CCSH(Guid ERDAOA_ID, string ERDAOA_FinanPer, DateTime ERDAOA_FinanTime, string ERDAOA_FinanSugg, string ERDAOA_FinanRes, string ERDAOA_OAppState);
    void Update_EquipRealDetailAOApp_CCQR(Guid ERDAOA_ID, string ERDAOA_OConfirmor, DateTime ERDAOA_OCTime, string ERDAOA_OAppState);
    void Update_EquipRealDetailAOApp_CCWS(Guid ERDAOA_ID, DateTime ERDAOA_ActODate, DateTime ERDAOA_ActIDate, decimal ERDAOA_ActCost,
                                                        string ERDAOA_PerfectPer, DateTime ERDAOA_PerfectTime, string ERDAOA_OAppState);
    void Update_EquipRealDetailAOApp_CCCW(Guid ERDAOA_ID, string ERDAOA_FinanConfirmor, DateTime ERDAOA_FCTime, string ERDAOA_OAppState);
}