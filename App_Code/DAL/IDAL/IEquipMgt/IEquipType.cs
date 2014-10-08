using System;
using System.Data;

/// <summary>
///IEquipType 的摘要说明
/// </summary>
public interface IEquipType
{
    // 设备类型
    void Insert_EquipTypeTableInfo(EMEquipTypeTableInfo eMEquipTypeTableInfo);
    void Update_EquipTypeTableInfo(EMEquipTypeTableInfo eMEquipTypeTableInfo);
    int Delete_EquipTypeTableInfo(Guid ETT_ID);
    DataSet Search_EquipTypeTableInfo(string condition);
    //DataSet Search_EquipTypeTable_DropdownInfo();
    //DataSet Search_EquipTypeTable_DataInfo();
}