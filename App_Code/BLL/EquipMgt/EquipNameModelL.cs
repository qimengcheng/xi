using System;
using System.Data;

/// <summary>
///EquipNameModelL 的摘要说明
/// </summary>
public class EquipNameModelL
{
    private static readonly IEquipNameModel equipm = DALFactory.CreateEquipNameModel(); 

	public EquipNameModelL()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

//名称
    public void Insert_EquipNameInfo(EMEquipName_EMEquipModelTableInfo eMEquipName_EMEquipModelTableInfo)
    {
        equipm.Insert_EquipNameInfo(eMEquipName_EMEquipModelTableInfo);
    }
    public void Update_EquipNameInfo(EMEquipName_EMEquipModelTableInfo eMEquipName_EMEquipModelTableInfo)
    {
        equipm.Update_EquipNameInfo(eMEquipName_EMEquipModelTableInfo);
    }
    public int Delete_EquipNameInfo(Guid EN_ID)
    {
        return equipm.Delete_EquipNameInfo(EN_ID);
    }
    public DataSet Search_EquipNameInfo(string condition)
    {
        return equipm.Search_EquipNameInfo(condition);
    }
    //public DataSet Search_EquipName_DataInfo()
    //{
    //    return equipm.Search_EquipName_DataInfo();
    //}


//型号
    public void Insert_EquipModelTableInfo(EMEquipName_EMEquipModelTableInfo eMEquipName_EMEquipModelTableInfo)
    {
        equipm.Insert_EquipModelTableInfo(eMEquipName_EMEquipModelTableInfo);
    }
    public void Update_EquipModelTableInfo(EMEquipName_EMEquipModelTableInfo eMEquipName_EMEquipModelTableInfo)
    {
        equipm.Update_EquipModelTableInfo(eMEquipName_EMEquipModelTableInfo);
    }
    public int Delete_EquipModelTableInfo(Guid EN_ID, Guid EMT_ID)
    {
        return equipm.Delete_EquipModelTableInfo(EN_ID, EMT_ID);
    }
    public DataSet Search_EquipModelTableInfo(string condition)
    {
        return equipm.Search_EquipModelTableInfo(condition);
    }
    public DataSet Search_EquipModelTable_IMMaterialBasicData(string condition)
    {
        return equipm.Search_EquipModelTable_IMMaterialBasicData(condition);
    }

//备件
    public void Insert_EquipFreqUsedSpareInfo(Guid EMT_ID, Guid IMMBD_MaterialID)
    {
        equipm.Insert_EquipFreqUsedSpareInfo(EMT_ID, IMMBD_MaterialID);
    }
    public int Delete_EquipFreqUsedSpareInfo(Guid EMT_ID, Guid EFUS_ID)
    {
        return equipm.Delete_EquipFreqUsedSpareInfo(EMT_ID, EFUS_ID);
    }
    public DataSet Search_EquipFreqUsedSpareInfo(string condition)
    {
        return equipm.Search_EquipFreqUsedSpareInfo(condition);
    }
    public DataSet Search_EquipFreqUsedSpare_InsertInfo(string condition)
    {
        return equipm.Search_EquipFreqUsedSpare_InsertInfo(condition);
    }
}