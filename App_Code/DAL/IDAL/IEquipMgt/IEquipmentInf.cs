using System;
using System.Data;

/// <summary>
///IEquipmentInf 的摘要说明
/// </summary>
public interface IEquipmentInf
{
    DataSet Search_InsertEquipmentInfInfo(string EN_EquipName, string EMT_Type);
    void Insert_EquipmentInfInfo(Guid ETT_ID, Guid EMT_ID, string EI_No, string EI_Location,
                                 string EI_Providor, string EI_IsToCare, DateTime EI_AcceptDate);
    void Update_EquipmentInfInfo(Guid ETT_ID, Guid EI_ID, string EI_No, string EI_Location, string EI_Providor,
                                 string EI_IsToCare, DateTime EI_AcceptDate, string EI_State);
    int Delete_Proc_D_EquipmentInfInfo(Guid EI_ID);
    DataSet Search_EquipmentInfInfo(string condition);
}