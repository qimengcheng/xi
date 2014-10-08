using System;
using System.Data;

/// <summary>
///IEquipNameModel 的摘要说明
/// </summary>
public interface IEquipNameModel
{
    //设备名称及型号
    void Insert_EquipNameInfo(EMEquipName_EMEquipModelTableInfo eMEquipName_EMEquipModelTableInfo);
    void Update_EquipNameInfo(EMEquipName_EMEquipModelTableInfo eMEquipName_EMEquipModelTableInfo);
    int Delete_EquipNameInfo(Guid EN_ID);
    DataSet Search_EquipNameInfo(string condition);
    //DataSet Search_EquipName_DataInfo();

    void Insert_EquipModelTableInfo(EMEquipName_EMEquipModelTableInfo eMEquipName_EMEquipModelTableInfo);
    void Update_EquipModelTableInfo(EMEquipName_EMEquipModelTableInfo eMEquipName_EMEquipModelTableInfo);
    int Delete_EquipModelTableInfo(Guid EN_ID, Guid EMT_ID);
    DataSet Search_EquipModelTableInfo(string condition);
    DataSet Search_EquipModelTable_IMMaterialBasicData(string condition);

    void Insert_EquipFreqUsedSpareInfo(Guid EMT_ID, Guid IMMBD_MaterialID);
    int Delete_EquipFreqUsedSpareInfo(Guid EMT_ID, Guid EFUS_ID);
    DataSet Search_EquipFreqUsedSpareInfo(string condition);
    DataSet Search_EquipFreqUsedSpare_InsertInfo(string condition);
}