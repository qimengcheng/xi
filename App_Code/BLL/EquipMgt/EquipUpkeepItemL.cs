using System;
using System.Data;

/// <summary>
///EquipUpkeepItemL 的摘要说明
/// </summary>
public class EquipUpkeepItemL
{
    private static readonly IEquipUpkeepItem equipm = DALFactory.CreateEquipUpkeepItem();
	public EquipUpkeepItemL()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public void Insert_EquipUpkeepItemInfo(Guid EN_ID, string EUI_Items, decimal EUI_Period)
    {
        equipm.Insert_EquipUpkeepItemInfo(EN_ID, EUI_Items, EUI_Period);
    }
    public void Update_EquipUpkeepItemInfo(Guid EUI_ID, Guid EN_ID, string EUI_Items, decimal EUI_Period)
    {
        equipm.Update_EquipUpkeepItemInfo(EUI_ID, EN_ID,EUI_Items, EUI_Period);
    }
    public int Delete_EquipUpkeepItemInfo(Guid EUI_ID)
    {
        return equipm.Delete_EquipUpkeepItemInfo(EUI_ID);
    }
    public DataSet Search_EquipUpkeepItemInfo(string condition)
    {
        return equipm.Search_EquipUpkeepItemInfo(condition);
    }
}