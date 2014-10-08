using System;
using System.Data;

/// <summary>
///IEquipUpkeepItem 的摘要说明
/// </summary>
public interface IEquipUpkeepItem
{
    void Insert_EquipUpkeepItemInfo(Guid EN_ID,string EUI_Items,decimal EUI_Period);
    void Update_EquipUpkeepItemInfo(Guid EUI_ID, Guid EN_ID, string EUI_Items, decimal EUI_Period);
    int Delete_EquipUpkeepItemInfo(Guid EUI_ID);
    DataSet Search_EquipUpkeepItemInfo(string condition);
}