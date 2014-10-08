using System;
using System.Collections.Generic;
using System.Data;

/// <summary>
///HSFBasicDataL 的摘要说明
/// </summary>
public class HSFBasicDataL
{
    private static readonly IHSFBasicData BD = DALFactory.CreateHSFBasicData();
    public HSFBasicDataL()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    //模糊检索风险等级
    public DataSet Search_HSFReskLevel(string HSFRL_RiskLeve)
    {
        return BD.Search_HSFReskLevel(HSFRL_RiskLeve);

    }

    //插入风险等级
    public int Insert_HSFReskLevel(string HSFRL_RiskLeve)
    {
        return BD.Insert_HSFReskLevel(HSFRL_RiskLeve);
    }

    //删除风险等级
    public int Delete_ExpSampleType(Guid HSFRL_RiskLevelID)
    {
        return BD.Delete_ExpSampleType(HSFRL_RiskLevelID);
    }

    //检索风险等级下材料
    public DataSet Search_HSFReskLevel_M(Guid HSFRL_RiskLevelID)
    {
        return BD.Search_HSFReskLevel_M(HSFRL_RiskLevelID);

    }

    //模糊检索风险等级下材料
    public DataSet Search_IMMaterialBasicData_RL(Guid HSFRL_RiskLevelID, string IMMT_MaterialType, string IMMBD_MaterialName)
    {
        return BD.Search_IMMaterialBasicData_RL(HSFRL_RiskLevelID, IMMT_MaterialType, IMMBD_MaterialName);
    }

    //删除风险等级下材料
    public int Delete_HSFReskLevel_M(Guid IMMBD_MaterialID)
    {
        return BD.Delete_HSFReskLevel_M(IMMBD_MaterialID);
    }

    //增加风险等级下材料
    public int Insert_HSFReskLevel_M(HSFReskLevelInfo A)
    {
        return BD.Insert_HSFReskLevel_M(A);
    }

    //检索管制项目
    public DataSet Search_HSFContrItems(string HSFCI_ItemName, string HSFCI_Boundary)
    {
        return BD.Search_HSFContrItems(HSFCI_ItemName, HSFCI_Boundary);

    }

    //检索某物料所有管制项目
    public DataSet Search_HSFContrItems_M(Guid IMMBD_MaterialID)
    {
        return BD.Search_HSFContrItems_M(IMMBD_MaterialID);
    }

    //检索管制项目，参数为ID
    public IList<HSFContrItemsInfo> Search_HSFContrItems_ID(Guid hSFCI_ItemID)
    {
        return BD.Search_HSFContrItems_ID(hSFCI_ItemID);

    }

    //删除管制项目
    public int Delete_HSFContrItems(Guid HSFCI_ItemID)
    {
        return BD.Delete_HSFContrItems(HSFCI_ItemID);
    }

    //插入管制项目
    public int Insert_HSFContrItems(HSFContrItemsInfo A)
    {
        return BD.Insert_HSFContrItems(A);
    }

    //修改管制项目
    public int Update_HSFContrItems(HSFContrItemsInfo A)
    {
        return BD.Update_HSFContrItems(A);
    }

    //模糊检索材料
    public DataSet Search_IMMaterialBasicData_M(string IMMT_MaterialType, string IMMBD_MaterialName)
    {
        return BD.Search_IMMaterialBasicData_M(IMMT_MaterialType, IMMBD_MaterialName);

    }

    //检索材料的管制项目
    public DataSet Search_HSFContrItems_FM(Guid IMMBD_MaterialID, string HSFCI_ItemName, string HSFCI_Standard)
    {
        return BD.Search_HSFContrItems_FM(IMMBD_MaterialID, HSFCI_ItemName, HSFCI_Standard);
    }

    //插入材料的管制项目
    public int Insert_HSFMaterialItemRelation(Guid HSFCI_ItemID, Guid IMMBD_MaterialID)
    {
        return BD.Insert_HSFMaterialItemRelation(HSFCI_ItemID, IMMBD_MaterialID);
    }

    //删除材料的管制项目
    public int Delete_HSFMaterialItemRelation(Guid HSFCI_ItemID, Guid IMMBD_MaterialID)
    {
        return BD.Delete_HSFMaterialItemRelation(HSFCI_ItemID, IMMBD_MaterialID);
    }

    //模糊检索材料
    public DataSet Search_IMMaterialBasicData_M1(string IMMT_MaterialType, string IMMBD_MaterialName)
    {
        return BD.Search_IMMaterialBasicData_M1(IMMT_MaterialType, IMMBD_MaterialName);

    }

    //模糊查询非此材料的管制项目
    public DataSet Search_HSFContrItems_Rest(Guid IMMBD_MaterialID, string HSFCI_ItemName, string HSFCI_Boundary)
    {
        return BD.Search_HSFContrItems_Rest(IMMBD_MaterialID, HSFCI_ItemName, HSFCI_Boundary);
    }
}