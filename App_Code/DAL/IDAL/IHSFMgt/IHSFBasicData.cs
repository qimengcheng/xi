using System;
using System.Collections.Generic;
using System.Data;

/// <summary>
///IHSFBasicData 的摘要说明
/// </summary>


public interface IHSFBasicData
{
    //模糊检索风险等级
    DataSet Search_HSFReskLevel(string HSFRL_RiskLeve);
    //插入风险等级
    int Insert_HSFReskLevel(string HSFRL_RiskLeve);
    //删除风险等级
    int Delete_ExpSampleType(Guid HSFRL_RiskLevelID);
    //检索风险等级下材料
    DataSet Search_HSFReskLevel_M(Guid HSFRL_RiskLevelID);
    //模糊检索风险等级下材料
    DataSet Search_IMMaterialBasicData_RL(Guid HSFRL_RiskLevelID, string IMMT_MaterialType, string IMMBD_MaterialName);
    //删除风险等级下材料
    int Delete_HSFReskLevel_M(Guid IMMBD_MaterialID);
    //增加风险等级下材料
    int Insert_HSFReskLevel_M(HSFReskLevelInfo A);
    //检索管制项目
    DataSet Search_HSFContrItems(string HSFCI_ItemName, string HSFCI_Boundary);
    //检索某物料所有管制项目
    DataSet Search_HSFContrItems_M(Guid IMMBD_MaterialID);
    //检索管制项目，参数为ID
    IList<HSFContrItemsInfo> Search_HSFContrItems_ID(Guid hSFCI_ItemID);
    //删除管制项目
    int Delete_HSFContrItems(Guid HSFCI_ItemID);
    //插入管制项目
    int Insert_HSFContrItems(HSFContrItemsInfo A);
    //修改管制项目
    int Update_HSFContrItems(HSFContrItemsInfo A);
    //模糊检索材料
    DataSet Search_IMMaterialBasicData_M(string IMMT_MaterialType, string IMMBD_MaterialName);
    //检索材料的管制项目
    DataSet Search_HSFContrItems_FM(Guid IMMBD_MaterialID, string HSFCI_ItemName, string HSFCI_Standard);
    //插入材料的管制项目
    int Insert_HSFMaterialItemRelation(Guid HSFCI_ItemID, Guid IMMBD_MaterialID);
    //删除材料的管制项目
    int Delete_HSFMaterialItemRelation(Guid HSFCI_ItemID, Guid IMMBD_MaterialID);
    //模糊检索材料
    DataSet Search_IMMaterialBasicData_M1(string IMMT_MaterialType, string IMMBD_MaterialName);
    //模糊查询非此材料的管制项目
    DataSet Search_HSFContrItems_Rest(Guid IMMBD_MaterialID, string HSFCI_ItemName, string HSFCI_Boundary);
}