using System;
using System.Data;

/// <summary>
///EquipUpkeepPlanL 的摘要说明
/// </summary>
public class EquipUpkeepPlanL
{
    private static readonly IEquipUpkeepPlan equipm = DALFactory.CreateEquipUpkeepPlan();
	public EquipUpkeepPlanL()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public DataSet Search_EquipUpkeepPlan(string condition)
    {
        return equipm.Search_EquipUpkeepPlan(condition);
    }
    public int Delete_EquipUpkeepPlan(Guid EUP_ID)
    {
        return equipm.Delete_EquipUpkeepPlan(EUP_ID);
    }
    public DataSet Search_InsertEquipUpkeepPlan_Inf(string ETT_Type, string EN_EquipName, string EMT_Type, string EI_No)
    {
        return equipm.Search_InsertEquipUpkeepPlan_Inf(ETT_Type, EN_EquipName, EMT_Type, EI_No);
    }
    public DataSet Search_InsertEquipUpkeepPlan_Last(Guid EN_ID, Guid EI_ID)
    {
        return equipm.Search_InsertEquipUpkeepPlan_Last(EN_ID,EI_ID);
    }
    public void Insert_EquipUpkeepPlan_plan(Guid EI_ID, string EUP_UpkeepPer, decimal EUP_ExpectTime, string EUP_Class, DateTime EUP_PDate, string EUP_PPerson,
        DateTime EUP_MakingTime, string EUP_State)
    {
        equipm.Insert_EquipUpkeepPlan_plan(EI_ID, EUP_UpkeepPer, EUP_ExpectTime, EUP_Class, EUP_PDate, EUP_PPerson, EUP_MakingTime, EUP_State);
    }
    public void Insert_EquipUpkeepPlan_item(Guid EUI_ID, Guid EUP_ID)
    {
        equipm.Insert_EquipUpkeepPlan_item(EUI_ID,EUP_ID);
    }
    public int Delete_EquipUpkeepPlan_item(Guid EUD_ID)
    {
        return equipm.Delete_EquipUpkeepPlan_item(EUD_ID);
    }
    public DataSet Search_EquipUpkeepPlan_Item(string condition)
    {
        return equipm.Search_EquipUpkeepPlan_Item(condition);
    }    
    public void Update_EquipUpkeepPlan_ZD(Guid EUP_ID, string EUP_UpkeepPer, decimal EUP_ExpectTime, string EUP_Class, DateTime EUP_PDate, string EUP_PPerson,
        DateTime EUP_MakingTime, string EUP_State)
    {
        equipm.Update_EquipUpkeepPlan_ZD(EUP_ID, EUP_UpkeepPer, EUP_ExpectTime, EUP_Class, EUP_PDate, EUP_PPerson, EUP_MakingTime, EUP_State);
    }
    public void Update_EquipUpkeepPlan_SC(Guid EUP_ID, string EUP_UpkeepPer, decimal EUP_ExpectTime, string EUP_Class, DateTime EUP_PDate, string EUP_PPerson,
        DateTime EUP_MakingTime, string EUP_State, string EUP_GeneratePer, DateTime EUP_GenerateTime)
    {
        equipm.Update_EquipUpkeepPlan_SC(EUP_ID, EUP_UpkeepPer, EUP_ExpectTime, EUP_Class, EUP_PDate, EUP_PPerson, EUP_MakingTime, EUP_State,EUP_GeneratePer,EUP_GenerateTime);
    }
    public DataSet Search_EquipUpkeepPlan_Sparedone(string condition)
    {
        return equipm.Search_EquipUpkeepPlan_Sparedone(condition);
    }
    public DataSet Search_EquipUpkeepPlan_Spare(string condition)
    {
        return equipm.Search_EquipUpkeepPlan_Spare(condition);
    }
    public void Insert_EquipUpkeepPlan_Spare(Guid EFUS_ID, Guid EUP_ID, int EMSAUS_UseAmount)
    {
        equipm.Insert_EquipUpkeepPlan_Spare(EFUS_ID, EUP_ID, EMSAUS_UseAmount);
    }
    public int Delete_EquipUpkeepPlan_Spare(Guid EMSAUS_ID)
    {
        return equipm.Delete_EquipUpkeepPlan_Spare(EMSAUS_ID);
    }
    public void Update_EquipUpkeepPlan_JL(Guid EUP_ID, string EUP_ActPer, string EUP_OutPContents, DateTime EUP_UStartT, DateTime EUP_UEndT, string EUP_Remarks,string EUP_State)
    {
        equipm.Update_EquipUpkeepPlan_JL(EUP_ID, EUP_ActPer, EUP_OutPContents, EUP_UStartT, EUP_UEndT, EUP_Remarks,EUP_State);
    }
}