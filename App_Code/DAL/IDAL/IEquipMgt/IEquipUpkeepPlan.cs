using System;
using System.Data;

/// <summary>
///IEquipUpkeepPlan 的摘要说明
/// </summary>
public interface IEquipUpkeepPlan
{
    DataSet Search_EquipUpkeepPlan(string condition);
    int Delete_EquipUpkeepPlan(Guid EUP_ID);
    DataSet Search_InsertEquipUpkeepPlan_Inf(string ETT_Type, string EN_EquipName, string EMT_Type, string EI_No);
    DataSet Search_InsertEquipUpkeepPlan_Last(Guid EN_ID, Guid EI_ID);
    void Insert_EquipUpkeepPlan_plan(Guid EI_ID, string EUP_UpkeepPer, decimal EUP_ExpectTime, string EUP_Class, DateTime EUP_PDate, string EUP_PPerson,
                                DateTime EUP_MakingTime, string EUP_State);
    void Insert_EquipUpkeepPlan_item(Guid EUI_ID, Guid EUP_ID);
    int Delete_EquipUpkeepPlan_item(Guid EUD_ID);
    DataSet Search_EquipUpkeepPlan_Item(string condition);
    void Update_EquipUpkeepPlan_ZD(Guid EUP_ID, string EUP_UpkeepPer, decimal EUP_ExpectTime, string EUP_Class, DateTime EUP_PDate, string EUP_PPerson,
                                DateTime EUP_MakingTime, string EUP_State);
    void Update_EquipUpkeepPlan_SC(Guid EUP_ID, string EUP_UpkeepPer, decimal EUP_ExpectTime, string EUP_Class, DateTime EUP_PDate, string EUP_PPerson,
                                DateTime EUP_MakingTime, string EUP_State, string EUP_GeneratePer, DateTime EUP_GenerateTime);
    DataSet Search_EquipUpkeepPlan_Sparedone(string condition);
    DataSet Search_EquipUpkeepPlan_Spare(string condition);
    void Insert_EquipUpkeepPlan_Spare(Guid EFUS_ID, Guid EUP_ID, int EMSAUS_UseAmount);
    int Delete_EquipUpkeepPlan_Spare(Guid EMSAUS_ID);
    void Update_EquipUpkeepPlan_JL(Guid EUP_ID, string EUP_ActPer, string EUP_OutPContents, DateTime EUP_UStartT, DateTime EUP_UEndT, string EUP_Remarks, string EUP_State);
}