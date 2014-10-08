using System;
using System.Data;

/// <summary>
///EquipTypeL 的摘要说明
/// </summary>
public class EquipTypeL
{
    private static readonly IEquipType equipm = DALFactory.CreateEquipType();

    public EquipTypeL()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    public void Insert_EquipTypeTableInfo(EMEquipTypeTableInfo eMEquipTypeTableInfo)
    {
        equipm.Insert_EquipTypeTableInfo(eMEquipTypeTableInfo);
    }
    public void Update_EquipTypeTableInfo(EMEquipTypeTableInfo eMEquipTypeTableInfo)
    {
        equipm.Update_EquipTypeTableInfo(eMEquipTypeTableInfo);
    }
    public int Delete_EquipTypeTableInfo(Guid ETT_ID)
    {
        return equipm.Delete_EquipTypeTableInfo(ETT_ID);
    }
    public DataSet Search_EquipTypeTableInfo(string condition)
    {
        return equipm.Search_EquipTypeTableInfo(condition);
    }
    //public DataSet Search_EquipTypeTable_DataInfo()
    //{
    //    return equipm.Search_EquipTypeTable_DataInfo();
    //}
    //public DataSet Search_EquipTypeTable_DropdownInfo()
    //{
    //    return equipm.Search_EquipTypeTable_DropdownInfo();
    //}
}