using System;
using System.Data;

/// <summary>
///EquipmentInfL 的摘要说明
/// </summary>
public class EquipmentInfL
{
    private static readonly IEquipmentInf equipm = DALFactory.CreateEquipmentInf();
	public EquipmentInfL()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public DataSet Search_InsertEquipmentInfInfo(string EN_EquipName, string EMT_Type)
    {
        return equipm.Search_InsertEquipmentInfInfo(EN_EquipName, EMT_Type);
    }
    public void Insert_EquipmentInfInfo(Guid ETT_ID, Guid EMT_ID, string EI_No, string EI_Location,
                                        string EI_Providor, string EI_IsToCare, DateTime EI_AcceptDate)
    {
        equipm.Insert_EquipmentInfInfo(ETT_ID, EMT_ID, EI_No, EI_Location, EI_Providor, EI_IsToCare, EI_AcceptDate);
    }
    public void Update_EquipmentInfInfo(Guid ETT_ID, Guid EI_ID, string EI_No, string EI_Location, string EI_Providor,
                                        string EI_IsToCare, DateTime EI_AcceptDate, string EI_State)
    {
        equipm.Update_EquipmentInfInfo(ETT_ID,EI_ID, EI_No, EI_Location, EI_Providor, EI_IsToCare, EI_AcceptDate, EI_State);
    }
    public int Delete_Proc_D_EquipmentInfInfo(Guid EI_ID)
    {
        return equipm.Delete_Proc_D_EquipmentInfInfo(EI_ID);
    }
    public DataSet Search_EquipmentInfInfo(string condition)
    {
        return equipm.Search_EquipmentInfInfo(condition);
    }
}