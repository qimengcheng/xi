using System;
using System.Data;

/// <summary>
///EquipMaintenanceAppL 的摘要说明
/// </summary>
public class EquipMaintenanceAppL
{
    private static readonly IEquipMaintenanceApp equipm = DALFactory.CreateEquipMaintenanceApp();
	public EquipMaintenanceAppL()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public DataSet Search_InsertEquipMaintenanceApp(string ETT_Type, string EN_EquipName, string EMT_Type, string EI_No)
    {
        return equipm.Search_InsertEquipMaintenanceApp(ETT_Type, EN_EquipName, EMT_Type, EI_No);
    }
    public void Insert_EquipMaintenanceApp(Guid EI_ID, string EMA_AppDep, DateTime EMA_BreakDownTime, string EMA_AppPer, DateTime EMA_AppTime,
                                               string EMA_BDDetail, string EMA_AppState)
    {
        equipm.Insert_EquipMaintenanceApp(EI_ID, EMA_AppDep, EMA_BreakDownTime,EMA_AppPer,EMA_AppTime,EMA_BDDetail,EMA_AppState);
    }
    public void Update_EquipMaintenanceApp_SQ(Guid EMA_ID, string EMA_AppDep, DateTime EMA_BreakDownTime, string EMA_AppPer, DateTime EMA_AppTime,
                                               string EMA_BDDetail, string EMA_AppState)
    {
        equipm.Update_EquipMaintenanceApp_SQ(EMA_ID, EMA_AppDep, EMA_BreakDownTime,EMA_AppPer,EMA_AppTime, EMA_BDDetail, EMA_AppState);
    }
    public DataSet Search_BDOrganizationSheet_EquipMaintenanceApp()
    {
        return equipm.Search_BDOrganizationSheet_EquipMaintenanceApp();
    }
    public int Delete_EquipMaintenanceApp(Guid EMA_ID)
    {
        return equipm.Delete_EquipMaintenanceApp(EMA_ID) ;
    }
    public DataSet Search_EquipMaintenanceApp(string condition)
    {
        return equipm.Search_EquipMaintenanceApp(condition);
    }
    public void Update_EquipMaintenanceApp_QR(Guid EMA_ID, string EMA_AckPer, DateTime EMA_AckTime, string EMA_AppState)
    {
        equipm.Update_EquipMaintenanceApp_QR(EMA_ID, EMA_AckPer, EMA_AckTime, EMA_AppState);
    }
    public void Update_EquipMaintenanceApp_YS(Guid EMA_ID, string EMA_CheckPer, DateTime EMA_CheckTime, string EMA_CheckRes, string EMA_CheckSugg, string EMA_AppState)
    { 
        equipm.Update_EquipMaintenanceApp_YS(EMA_ID, EMA_CheckPer, EMA_CheckTime, EMA_CheckRes, EMA_CheckSugg, EMA_AppState);
    }
    public void Insert_EquipRealDetailAOApp_CN(Guid EI_ID, Guid EMA_ID, string ERDAOA_MaintPer, DateTime ERDAOA_StartTime, DateTime ERDAOA_EndTime,
                                               string ERDAOA_ReasonMethod, string ERDAOA_Remarks)
    {
        equipm.Insert_EquipRealDetailAOApp_CN(EI_ID, EMA_ID, ERDAOA_MaintPer, ERDAOA_StartTime, ERDAOA_EndTime,ERDAOA_ReasonMethod, ERDAOA_Remarks);
    }
    public void Update_EquipRealDetailAOApp_CN(Guid ERDAOA_ID, string ERDAOA_MaintPer, DateTime ERDAOA_StartTime, DateTime ERDAOA_EndTime,
                                               string ERDAOA_ReasonMethod, string ERDAOA_Remarks)
    {
        equipm.Update_EquipRealDetailAOApp_CN(ERDAOA_ID, ERDAOA_MaintPer, ERDAOA_StartTime, ERDAOA_EndTime,ERDAOA_ReasonMethod, ERDAOA_Remarks);
    }
    public int Delete_EquipRealDetailAOApp_CN(Guid ERDAOA_ID)
    {
        return equipm.Delete_EquipRealDetailAOApp_CN(ERDAOA_ID);
    }
    public DataSet Search_EquipRealDetailAOApp_CN(string condition)
    {
        return equipm.Search_EquipRealDetailAOApp_CN(condition);
    }
    public void Insert_EquipRealDetailAOApp_Spare(Guid EFUS_ID, Guid ERDAOA_ID, int EMSAUS_UseAmount)
    {
        equipm.Insert_EquipRealDetailAOApp_Spare(EFUS_ID, ERDAOA_ID, EMSAUS_UseAmount);
    }
    public void Update_EquipMaintenanceApp_CL(Guid EMA_ID, string EMA_AppState)
    {
        equipm.Update_EquipMaintenanceApp_CL(EMA_ID, EMA_AppState);
    }
    public void Insert_EquipRealDetailAOApp_CC(Guid EI_ID, Guid EMA_ID, string ERDAOA_OAppDep, string ERDAOA_OAppPer, DateTime ERDAOA_OAppTime,
                                               string ERDAOA_OAppState, string ERDAOA_OMaintePlace, string ERDAOA_Feature, string ERDAOA_OReson)
    {
        equipm.Insert_EquipRealDetailAOApp_CC(EI_ID, EMA_ID, ERDAOA_OAppDep, ERDAOA_OAppPer, ERDAOA_OAppTime,ERDAOA_OAppState, ERDAOA_OMaintePlace,
                                              ERDAOA_Feature, ERDAOA_OReson);
    }
    public void Update_EquipRealDetailAOApp_CC(Guid ERDAOA_ID, string ERDAOA_OAppDep, string ERDAOA_OAppPer, DateTime ERDAOA_OAppTime,
                                               string ERDAOA_OAppState, string ERDAOA_OMaintePlace, string ERDAOA_Feature, string ERDAOA_OReson)
    {
        equipm.Update_EquipRealDetailAOApp_CC(ERDAOA_ID, ERDAOA_OAppDep, ERDAOA_OAppPer, ERDAOA_OAppTime,ERDAOA_OAppState, ERDAOA_OMaintePlace, 
                                              ERDAOA_Feature, ERDAOA_OReson);
    }
    public DataSet Search_EquipRealDetailAOApp_CC(string condition)
    {
        return equipm.Search_EquipRealDetailAOApp_CC(condition);
    }
    public void Update_EquipRealDetailAOApp_CCSP(Guid ERDAOA_ID, string ERDAOA_Approver, DateTime ERDAOA_ApprovalT, string ERDAOA_ApprovalSugg, string ERDAOA_ApprovalRes, string ERDAOA_OAppState)
    {
        equipm.Update_EquipRealDetailAOApp_CCSP(ERDAOA_ID, ERDAOA_Approver, ERDAOA_ApprovalT, ERDAOA_ApprovalSugg, ERDAOA_ApprovalRes,ERDAOA_OAppState);
    }
    public void Update_EquipRealDetailAOApp_CCYS(Guid ERDAOA_ID, DateTime ERDAOA_ExpectODate, DateTime ERDAOA_ExpectIDate, decimal ERDAOA_ExpectCost,
                                                        string ERDAOA_PerInCharge, DateTime ERDAOA_RecordDate, string ERDAOA_OAppState)
    {
        equipm.Update_EquipRealDetailAOApp_CCYS(ERDAOA_ID, ERDAOA_ExpectODate, ERDAOA_ExpectIDate, ERDAOA_ExpectCost, ERDAOA_PerInCharge, ERDAOA_RecordDate, ERDAOA_OAppState);
    }
    public void Update_EquipRealDetailAOApp_CCSH(Guid ERDAOA_ID, string ERDAOA_FinanPer, DateTime ERDAOA_FinanTime, string ERDAOA_FinanSugg, string ERDAOA_FinanRes, string ERDAOA_OAppState)
    {
        equipm.Update_EquipRealDetailAOApp_CCSH(ERDAOA_ID, ERDAOA_FinanPer, ERDAOA_FinanTime, ERDAOA_FinanSugg, ERDAOA_FinanRes, ERDAOA_OAppState);
    }
    public void Update_EquipRealDetailAOApp_CCQR(Guid ERDAOA_ID, string ERDAOA_OConfirmor, DateTime ERDAOA_OCTime, string ERDAOA_OAppState)
    {
        equipm.Update_EquipRealDetailAOApp_CCQR(ERDAOA_ID, ERDAOA_OConfirmor, ERDAOA_OCTime, ERDAOA_OAppState);
    }
    public void Update_EquipRealDetailAOApp_CCWS(Guid ERDAOA_ID, DateTime ERDAOA_ActODate, DateTime ERDAOA_ActIDate, decimal ERDAOA_ActCost,
                                                        string ERDAOA_PerfectPer, DateTime ERDAOA_PerfectTime, string ERDAOA_OAppState)
    {
        equipm.Update_EquipRealDetailAOApp_CCWS(ERDAOA_ID, ERDAOA_ActODate, ERDAOA_ActIDate, ERDAOA_ActCost, ERDAOA_PerfectPer, ERDAOA_PerfectTime, ERDAOA_OAppState);
    }
    public void Update_EquipRealDetailAOApp_CCCW(Guid ERDAOA_ID, string ERDAOA_FinanConfirmor, DateTime ERDAOA_FCTime, string ERDAOA_OAppState)
    {
        equipm.Update_EquipRealDetailAOApp_CCCW(ERDAOA_ID, ERDAOA_FinanConfirmor, ERDAOA_FCTime, ERDAOA_OAppState);
    }
}