using System;
using EquipmentMangementAjax.DBUtility;
using System.Data.SqlClient;
using System.Data;

/// <summary>
///TrainingTypeMaintenanceD 的摘要说明
/// </summary>

namespace EquipmentMangementAjax.SQLServer
{
    public class TrainningYearPlanMgtD : ITrainningYearPlanMgt 
    {
        public DataSet Search_TrainingYPlanMain(string Condition)
        {
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_TrainingYPlanMain", new SqlParameter("@Condition", Condition));
        }//老员工培训，培训年度计划维护，检索培训年度计划主表


        public int Insert_TrainingYPlanMain(TrainningInfo tInfo)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_TrainingYPlanMain",
                new SqlParameter("@TYPM_Year", tInfo.TYPM_Year), new SqlParameter("@TYPM_State", tInfo.TYPM_State), new SqlParameter("@TYPM_Maker", tInfo.TYPM_Maker));
        }//老员工培训，培训年度计划维护，新增培训年度计划（主表）

        public void Delete_TrainingYPlanMain_TrainingItemDetail(Guid ID)
        {
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_TrainingYPlanMain_TrainingItemDetail",
                new SqlParameter("@TYPM_ID", ID));
        }//老员工培训，培训年度计划维护，删除培训年度计划（主表），同步删除明细表中对应的信息

        public int Insert_TrainingItemDetail(TrainningInfo tInfo)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_TrainingItemDetail",
                new SqlParameter("@TTT_TypeID", tInfo.TTT_TypeID), new SqlParameter("@TYPM_ID", tInfo.TYPM_ID),
                new SqlParameter("@TID_Month", tInfo.TID_Month), new SqlParameter("@TID_TLesson", tInfo.TID_TLesson),
                new SqlParameter("@TID_Target", tInfo.TID_Target), new SqlParameter("@BDOS_Code", tInfo.BDOS_Code));
        }//老员工培训，培训年度计划维护，新增培训项目（明细表）

        public int Update_ForSubmit_TrainingYPlanMain(TrainningInfo tInfo)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_ForSubmit_TrainingYPlanMain",
                new SqlParameter("@TYPM_ID", tInfo.TYPM_ID), new SqlParameter("@TYPM_State ", tInfo.TYPM_State));

        }//老员工培训，培训年度计划维护，提交培训年度计划（主表）

        public DataSet Search_OtherTables_TrainingItemDetail(string Condition)
        {
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_OtherTables_TrainingItemDetail", new SqlParameter("@Condition", Condition));
        }//老员工培训，培训年度计划维护，检索年度计划中的培训项目详情

        public int Update_TrainingItemDetail(TrainningInfo tInfo)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_TrainingItemDetail",
                new SqlParameter("@TID_ID", tInfo.TID_ID), new SqlParameter("@TTT_TypeID ", tInfo.TTT_TypeID), new SqlParameter("@TID_TLesson", tInfo.TID_TLesson),
                new SqlParameter("@TID_Target", tInfo.TID_Target), new SqlParameter("@BDOS_Code", tInfo.BDOS_Code), new SqlParameter("@TID_Month", tInfo.TID_Month));

        }//老员工培训，培训年度计划维护，编辑培训项目（明细表）


        public void Delete_TrainingItemDetail(Guid ID)
        {
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_TrainingItemDetail",
                new SqlParameter("@TID_ID", ID));
        }//老员工培训，培训年度计划维护，删除培训项目（明细表）

    }
}