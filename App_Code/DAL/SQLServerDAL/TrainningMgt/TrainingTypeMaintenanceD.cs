using System;
using System.Collections.Generic;
using EquipmentMangementAjax.DBUtility;
using System.Data.SqlClient;
using System.Data;

/// <summary>
///TrainingTypeMaintenanceD 的摘要说明
/// </summary>

namespace EquipmentMangementAjax.SQLServer
{
    public class TrainingTypeMaintenanceD : ITrainingTypeMaintenance
    {
        public int Insert_TrainingTypeTable(TrainningTypeMantenanceInfo ttmInfo)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_TrainingTypeTable",
                new SqlParameter("@TTT_Type", ttmInfo.TTT_Type));
        }//老员工培训，培训类型维护，新增培训类型

        public int Update_TrainingTypeTable(TrainningTypeMantenanceInfo ttmInfo)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_TrainingTypeTable",
                new SqlParameter("@TTT_TypeID", ttmInfo.TTT_TypeID), new SqlParameter("@TTT_Type", ttmInfo.TTT_Type));

        }//老员工培训，培训类型维护，编辑培训类型

        public void Delete_TrainingTypeTable(Guid ID)
        {
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_TrainingTypeTable",
                new SqlParameter("@TTT_TypeID", ID));
        }//老员工培训，培训类型维护，删除培训类型
        public DataSet Search_TrainingTypeTable(string Condition)
        {
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_TrainingTypeTable", new SqlParameter("@Condition", Condition));
        }//老员工培训，培训类型维护，检索培训类型

        public IList<TrainningTypeMantenanceInfo> SearchByID_TrainingTypeTable(Guid TTT_TypeID)
        {
            SqlParameter para = new SqlParameter("@TTT_TypeID", TTT_TypeID);
            IList<TrainningTypeMantenanceInfo> hRFilesMgtInfo = new List<TrainningTypeMantenanceInfo>();
            SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_ByID_TrainingTypeTable", para);
            while (sdr.Read())
            {
                hRFilesMgtInfo.Add(new TrainningTypeMantenanceInfo(sdr["TTT_Type"] == DBNull.Value ? "" : sdr["TTT_Type"].ToString()));
            }
            return hRFilesMgtInfo;
        }//老员工培训，培训类型维护，根据ID进行检索
    }
}