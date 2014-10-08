using System;
using System.Data.SqlClient;
using System.Data;
using EquipmentMangementAjax.DBUtility;

/// <summary>
///EquipNameModelD 的摘要说明
/// </summary>
namespace EquipmentMangementAjax.SQLServer
{
    public class EquipNameModelD : IEquipNameModel
    {
        public EquipNameModelD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
#region 名称
        //增加设备名称
        public void Insert_EquipNameInfo(EMEquipName_EMEquipModelTableInfo eMEquipName_EMEquipModelTableInfo)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@EN_EquipName", SqlDbType.VarChar, 40);
            parm[0].Value = eMEquipName_EMEquipModelTableInfo.EN_EquipName;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_I_EquipmentName", parm);
        }
        //修改设备名称
        public void Update_EquipNameInfo(EMEquipName_EMEquipModelTableInfo eMEquipName_EMEquipModelTableInfo)
        {
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@EN_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = eMEquipName_EMEquipModelTableInfo.EN_ID;
            parm[1] = new SqlParameter("@EN_EquipName", SqlDbType.VarChar, 40);
            parm[1].Value = eMEquipName_EMEquipModelTableInfo.EN_EquipName;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_U_EquipmentName", parm);
        }

        //假删除设备名称
        public int Delete_EquipNameInfo(Guid EN_ID)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@EN_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = EN_ID;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
               CommandType.StoredProcedure, "Proc_D_EquipmentName", parm);
        }

        //按名称，查找设备名称
        public DataSet Search_EquipNameInfo(string condition)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@condition", SqlDbType.NVarChar, 1000);
            parm[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_EquipmentName", parm);
        }

        //显示所有设备型号
        //public DataSet Search_EquipName_DataInfo()
        //{
        //    return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
        //        "Proc_S_EquipmentName_Data");
        //}
#endregion 名称
 
#region 型号
        //某设备名称下，增加设备型号
        public void Insert_EquipModelTableInfo(EMEquipName_EMEquipModelTableInfo eMEquipName_EMEquipModelTableInfo)
        {
            SqlParameter[] parm = new SqlParameter[3];
            parm[0] = new SqlParameter("@EN_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = eMEquipName_EMEquipModelTableInfo.EN_ID;
            parm[1] = new SqlParameter("@EMT_Type", SqlDbType.VarChar, 20);
            parm[1].Value = eMEquipName_EMEquipModelTableInfo.EMT_Type;
            parm[2] = new SqlParameter("@IMMBD_MaterialID", SqlDbType.UniqueIdentifier);
            parm[2].Value = eMEquipName_EMEquipModelTableInfo.IMMBD_MaterialID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_I_EquipModelTable", parm);
        }

        //某设备名称下，修改设备型号
        public void Update_EquipModelTableInfo(EMEquipName_EMEquipModelTableInfo eMEquipName_EMEquipModelTableInfo)
        {
            SqlParameter[] parm = new SqlParameter[3];
            parm[0] = new SqlParameter("@EN_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = eMEquipName_EMEquipModelTableInfo.EN_ID;
            parm[1] = new SqlParameter("@EMT_ID", SqlDbType.UniqueIdentifier);
            parm[1].Value = eMEquipName_EMEquipModelTableInfo.EMT_ID;
            parm[2] = new SqlParameter("@EMT_Type", SqlDbType.VarChar, 20);
            parm[2].Value = eMEquipName_EMEquipModelTableInfo.EMT_Type;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_U_EquipModelTable", parm);
        }

        //某设备名称下，删除设备型号
        public int Delete_EquipModelTableInfo(Guid EN_ID, Guid EMT_ID)
        {
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@EN_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = EN_ID;
            parm[1] = new SqlParameter("@EMT_ID", SqlDbType.UniqueIdentifier);
            parm[1].Value = EMT_ID;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
               CommandType.StoredProcedure, "Proc_D_EquipModelTable", parm);
        }

        //某设备名称下，查找设备型号
        public DataSet Search_EquipModelTableInfo(string condition)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@condition", SqlDbType.NVarChar, 1000);
            parm[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_EquipModelTable", parm);
        }

        //添加设备型号时，要与物料基础信息表对应，首先查找物料表中的设备
        public DataSet Search_EquipModelTable_IMMaterialBasicData(string condition)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            parm[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_EquipModelTable_IMMaterialBasicData", parm);
        }
#endregion 型号

#region 备件
        //某设备型号下，增加备件
        public void Insert_EquipFreqUsedSpareInfo(Guid EMT_ID, Guid IMMBD_MaterialID)
        {
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@EMT_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = EMT_ID;
            parm[1] = new SqlParameter("@IMMBD_MaterialID", SqlDbType.UniqueIdentifier);
            parm[1].Value = IMMBD_MaterialID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_I_EquipFreqUsedSpare", parm);
        }
        //某设备型号下，删除备件
        public int Delete_EquipFreqUsedSpareInfo(Guid EMT_ID, Guid EFUS_ID)
        {
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@EMT_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = EMT_ID;
            parm[1] = new SqlParameter("@EFUS_ID", SqlDbType.UniqueIdentifier);
            parm[1].Value = EFUS_ID;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
               CommandType.StoredProcedure, "Proc_D_EquipFreqUsedSpare", parm);
        }
        //某设备型号下，模糊查询已有备件
        public DataSet Search_EquipFreqUsedSpareInfo(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar ,1000);
            para[0].Value = condition  ;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_EquipFreqUsedSpare",para);
        }
        //增加备件时，查询某个备件
        public DataSet Search_EquipFreqUsedSpare_InsertInfo(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_EquipFreqUsedSpare_Insert", para);
        }
#endregion 备件
    }
}