using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using EquipmentMangementAjax.DBUtility;

/// <summary>
///HSFBasicDataD 的摘要说明
/// </summary>
/// 
namespace EquipmentMangementAjax.SQLServer
{
    public class HSFBasicDataD : IHSFBasicData
{
	public HSFBasicDataD()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}


    //模糊检索风险等级
    public DataSet Search_HSFReskLevel(string HSFRL_RiskLeve)
    {
        SqlParameter parm = new SqlParameter("@HSFRL_RiskLeve", HSFRL_RiskLeve);
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_HSFReskLevel", parm);

    }

    //插入风险等级
    public int Insert_HSFReskLevel(string HSFRL_RiskLeve)
    {
        SqlParameter parm = new SqlParameter("@HSFRL_RiskLeve", HSFRL_RiskLeve);

        return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_I_HSFReskLevel", parm);
    }

    //删除风险等级
    public int Delete_ExpSampleType(Guid HSFRL_RiskLevelID)
    {
        SqlParameter parm = new SqlParameter("@HSFRL_RiskLevelID", HSFRL_RiskLevelID);
        return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
          CommandType.StoredProcedure, "Proc_D_HSFReskLevel", parm);
    }

    //检索风险等级下材料
    public DataSet Search_HSFReskLevel_M(Guid HSFRL_RiskLevelID)
    {
        SqlParameter parm = new SqlParameter("@HSFRL_RiskLevelID", HSFRL_RiskLevelID);
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_HSFReskLevel_M", parm);

    }
        
    //模糊检索风险等级下材料
    public DataSet Search_IMMaterialBasicData_RL(Guid HSFRL_RiskLevelID, string IMMT_MaterialType, string IMMBD_MaterialName)
    {
        SqlParameter[] parm = new SqlParameter[3];
        parm[0] = new SqlParameter("@HSFRL_RiskLevelID", SqlDbType.UniqueIdentifier);
        parm[0].Value = HSFRL_RiskLevelID;
        parm[1] = new SqlParameter("@IMMT_MaterialType", SqlDbType.VarChar,50);
        parm[1].Value = IMMT_MaterialType;
        parm[2] = new SqlParameter("@IMMBD_MaterialName", SqlDbType.VarChar, 100);
        parm[2].Value = IMMBD_MaterialName;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_IMMaterialBasicData_RL", parm);

    }

    //删除风险等级下材料
    public int Delete_HSFReskLevel_M(Guid IMMBD_MaterialID)
    {
        SqlParameter parm = new SqlParameter("@IMMBD_MaterialID", IMMBD_MaterialID);
        return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
          CommandType.StoredProcedure, "Proc_D_HSFReskLevel_M", parm);
    }

    //增加风险等级下材料
    public int Insert_HSFReskLevel_M(HSFReskLevelInfo A)
    {
        SqlParameter[] parm = new SqlParameter[2];
        parm[0] = new SqlParameter("@IMMBD_MaterialID", SqlDbType.UniqueIdentifier);
        parm[0].Value = A.IMMBD_MaterialID;

        parm[1] = new SqlParameter("@HSFRL_RiskLevelID", SqlDbType.UniqueIdentifier);
        parm[1].Value = A.HSFRL_RiskLevelID;

        return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
        CommandType.StoredProcedure, "Proc_I_HSFReskLevel_M", parm);
    }

    //检索管制项目
    public DataSet Search_HSFContrItems(string HSFCI_ItemName, string HSFCI_Boundary)
    {
        SqlParameter[] parm = new SqlParameter[2];
        parm[0] = new SqlParameter("@HSFCI_ItemName", SqlDbType.VarChar, 100);
        parm[0].Value = HSFCI_ItemName;
        parm[1] = new SqlParameter("@HSFCI_Boundary", SqlDbType.VarChar, 200);
        parm[1].Value = HSFCI_Boundary;
        return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_HSFContrItems", parm);

    }

    //检索某物料所有管制项目
    public DataSet Search_HSFContrItems_M(Guid IMMBD_MaterialID)
    {
        SqlParameter parm = new SqlParameter("@IMMBD_MaterialID", IMMBD_MaterialID);
        return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_HSFContrItems_M", parm);

    }

    //检索管制项目，参数为ID
    public IList<HSFContrItemsInfo> Search_HSFContrItems_ID(Guid hSFCI_ItemID)
    {
        SqlParameter para = new SqlParameter("@HSFCI_ItemID", hSFCI_ItemID);
        IList<HSFContrItemsInfo> hSFContrItemsInfo = new List<HSFContrItemsInfo>();
        SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_HSFContrItems_ID", para);
        while (sdr.Read())
        {
            hSFContrItemsInfo.Add(new HSFContrItemsInfo(sdr["HSFCI_ItemName"] == DBNull.Value ? "" : sdr["HSFCI_ItemName"].ToString(),
                sdr["HSFCI_Standard"] == DBNull.Value ? "" : sdr["HSFCI_Standard"].ToString(),
               sdr["HSFCI_Boundary"] == DBNull.Value ? "" : sdr["HSFCI_Boundary"].ToString(),
               sdr["HSFCI_Period"] == DBNull.Value ? 0 : Convert.ToInt16 (sdr["HSFCI_Period"].ToString()),
               sdr["HSFCI_RemindDay"] == DBNull.Value ? 0 : Convert.ToInt16(sdr["HSFCI_RemindDay"].ToString())
               ));
        }
        return hSFContrItemsInfo;
    }

    //删除管制项目
    public int Delete_HSFContrItems(Guid HSFCI_ItemID)
    {
        SqlParameter[] parm = new SqlParameter[1];
        parm[0] = new SqlParameter("@HSFCI_ItemID", SqlDbType.UniqueIdentifier);
        parm[0].Value = HSFCI_ItemID;
        return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
          CommandType.StoredProcedure, "Proc_D_HSFContrItems", parm);
    }

    //插入管制项目
    public int Insert_HSFContrItems(HSFContrItemsInfo A)
    {
        SqlParameter[] parm = new SqlParameter[5];
        parm[0] = new SqlParameter("@HSFCI_ItemName", SqlDbType.VarChar, 100);
        parm[0].Value = A.HSFCI_ItemName;

        parm[1] = new SqlParameter("@HSFCI_Standard", SqlDbType.VarChar, 1000);
        parm[1].Value = A.HSFCI_Standard;

        parm[2] = new SqlParameter("@HSFCI_Boundary", SqlDbType.VarChar, 200);
        parm[2].Value = A.HSFCI_Boundary;

        parm[3] = new SqlParameter("@HSFCI_Period", SqlDbType.Int);
        parm[3].Value = A.HSFCI_Period;

        parm[4] = new SqlParameter("@HSFCI_RemindDay", SqlDbType.Int);
        parm[4].Value = A.HSFCI_RemindDay;

        return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
        CommandType.StoredProcedure, "Proc_I_HSFContrItems", parm);
    }

    //修改管制项目
    public int Update_HSFContrItems(HSFContrItemsInfo A)
    {
        SqlParameter[] parm = new SqlParameter[6];
        parm[0] = new SqlParameter("@HSFCI_ItemID", SqlDbType.UniqueIdentifier);
        parm[0].Value = A.HSFCI_ItemID;

        parm[1] = new SqlParameter("@HSFCI_ItemName", SqlDbType.VarChar, 100);
        parm[1].Value = A.HSFCI_ItemName;

        parm[2] = new SqlParameter("@HSFCI_Standard", SqlDbType.VarChar, 1000);
        parm[2].Value = A.HSFCI_Standard;

        parm[3] = new SqlParameter("@HSFCI_Boundary", SqlDbType.VarChar, 200);
        parm[3].Value = A.HSFCI_Boundary;

        parm[4] = new SqlParameter("@HSFCI_Period", SqlDbType.Int);
        parm[4].Value = A.HSFCI_Period;

        parm[5] = new SqlParameter("@HSFCI_RemindDay", SqlDbType.Int);
        parm[5].Value = A.HSFCI_RemindDay;

        return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
        CommandType.StoredProcedure, "Proc_U_HSFContrItems", parm);
    }
    //模糊检索材料及风险等级
    public DataSet Search_IMMaterialBasicData_M(string IMMT_MaterialType, string IMMBD_MaterialName)
    {
        SqlParameter[] parm = new SqlParameter[2];

        parm[0] = new SqlParameter("@IMMT_MaterialType", SqlDbType.VarChar,50);
        parm[0].Value = IMMT_MaterialType;

        parm[1] = new SqlParameter("@IMMBD_MaterialName", SqlDbType.VarChar,100);
        parm[1].Value = IMMBD_MaterialName;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_IMMaterialBasicData_M", parm);

    }

    //模糊检索材料的管制项目
    public DataSet Search_HSFContrItems_FM(Guid IMMBD_MaterialID, string HSFCI_ItemName, string HSFCI_Standard)
    {
        SqlParameter[] parm = new SqlParameter[3];
        parm[0] = new SqlParameter("@IMMBD_MaterialID", SqlDbType.UniqueIdentifier);
        parm[0].Value = IMMBD_MaterialID;
        parm[1] = new SqlParameter("@HSFCI_ItemName", SqlDbType.VarChar, 100);
        parm[1].Value = HSFCI_ItemName;
        parm[2] = new SqlParameter("@HSFCI_Boundary", SqlDbType.VarChar, 200);
        parm[2].Value = HSFCI_Standard;
        return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_HSFContrItems_FM", parm);

    }

    //插入材料的管制项目
    public int Insert_HSFMaterialItemRelation(Guid HSFCI_ItemID, Guid IMMBD_MaterialID)
    {
        SqlParameter[] parm = new SqlParameter[2];
        parm[0] = new SqlParameter("@HSFCI_ItemID", SqlDbType.UniqueIdentifier);
        parm[0].Value = HSFCI_ItemID;

        parm[1] = new SqlParameter("@IMMBD_MaterialID", SqlDbType.UniqueIdentifier);
        parm[1].Value = IMMBD_MaterialID;

        return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
        CommandType.StoredProcedure, "Proc_I_HSFMaterialItemRelation", parm);
    }

    //删除材料的管制项目
    public int Delete_HSFMaterialItemRelation(Guid HSFCI_ItemID, Guid IMMBD_MaterialID)
    {
        SqlParameter[] parm = new SqlParameter[2];
        parm[0] = new SqlParameter("@HSFCI_ItemID", SqlDbType.UniqueIdentifier);
        parm[0].Value = HSFCI_ItemID;

        parm[1] = new SqlParameter("@IMMBD_MaterialID", SqlDbType.UniqueIdentifier);
        parm[1].Value = IMMBD_MaterialID;
        return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
          CommandType.StoredProcedure, "Proc_D_HSFMaterialItemRelation", parm);
    }

    //模糊检索材料
    public DataSet Search_IMMaterialBasicData_M1(string IMMT_MaterialType, string IMMBD_MaterialName)
    {
        SqlParameter[] parm = new SqlParameter[2];

        parm[0] = new SqlParameter("@IMMT_MaterialType", SqlDbType.VarChar, 50);
        parm[0].Value = IMMT_MaterialType;

        parm[1] = new SqlParameter("@IMMBD_MaterialName", SqlDbType.VarChar, 100);
        parm[1].Value = IMMBD_MaterialName;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_IMMaterialBasicData_M1", parm);

    }

    //模糊查询非此材料的管制项目
    public DataSet Search_HSFContrItems_Rest(Guid IMMBD_MaterialID, string HSFCI_ItemName, string HSFCI_Boundary)
    {
        SqlParameter[] parm = new SqlParameter[3];

        parm[0] = new SqlParameter("@IMMBD_MaterialID", SqlDbType.UniqueIdentifier);
        parm[0].Value = IMMBD_MaterialID;

        parm[1] = new SqlParameter("@HSFCI_ItemName", SqlDbType.VarChar, 100);
        parm[1].Value = HSFCI_ItemName;

        parm[2] = new SqlParameter("@HSFCI_Boundary", SqlDbType.VarChar, 200);
        parm[2].Value = HSFCI_Boundary;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_HSFContrItems_Rest", parm);
    }
}
}