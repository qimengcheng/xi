using System;
using System.Collections.Generic;
using EquipmentMangementAjax.DBUtility;
using System.Data.SqlClient;
using System.Data;

/// <summary>
///TrainningMonthPlanD 的摘要说明
/// </summary>

namespace EquipmentMangementAjax.SQLServer
{
    public class TrainningMonthPlanD : ITrainningMonthPlanD
    {
        public DataSet Search_ForArrange_TrainingItemDetail(string Condition)
        {
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_ForArrange_TrainingItemDetail", new SqlParameter("@Condition", Condition));
        }//老员工培训，安排培训计划，检索培训项目详情列表


        public int Update_ForArrange_TrainingItemDetail(TrainningMonthPlanInfo ttmInfo)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_ForArrange_TrainingItemDetail",
                new SqlParameter("@TID_ID", ttmInfo.TID_ID), new SqlParameter("@TID_State", ttmInfo.TID_State));

        }//老员工培训，安排培训计划，更新培训项目详情（提交linkbutton）

        public int Update_ForSave_TrainingItemDetail(TrainningMonthPlanInfo ttmInfo)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_ForSave_TrainingItemDetail",
                new SqlParameter("@TID_ID", ttmInfo.TID_ID), new SqlParameter("@TID_Teacher", ttmInfo.TID_Teacher),
                new SqlParameter("@TID_PTime", ttmInfo.TID_PTime), new SqlParameter("@TID_Place", ttmInfo.TID_Place),
                new SqlParameter("@TID_ActTime", ttmInfo.TID_ActTime), new SqlParameter("@TID_CreditHours", ttmInfo.TID_CreditHours));

        }//老员工培训，安排培训计划，保存培训项目详情（保存按钮）

        public int Insert_OutOfYearPlan_TrainingItemDetail(TrainningMonthPlanInfo ttmInfo)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_OutOfYearPlan_TrainingItemDetail",
                new SqlParameter("@TTT_TypeID", ttmInfo.TTT_TypeID), new SqlParameter("@TYPM_ID", ttmInfo.TYPM_ID), new SqlParameter("@TID_Month", ttmInfo.TID_Month),
                new SqlParameter("@TID_TLesson", ttmInfo.TID_TLesson), new SqlParameter("@TID_Target", ttmInfo.TID_Target), new SqlParameter("@TID_Place", ttmInfo.TID_Place),
                new SqlParameter("@TID_CreditHours", ttmInfo.TID_CreditHours), new SqlParameter("@TID_Teacher", ttmInfo.TID_Teacher), new SqlParameter("@TID_PTime", ttmInfo.TID_PTime),
                new SqlParameter("@BDOS_Code", ttmInfo.BDOS_Code), new SqlParameter("@TID_ActTime", ttmInfo.TID_ActTime), new SqlParameter("@TID_Maker", ttmInfo.TID_Maker));
        }//老员工培训，安排培训计划，新增年度计划外的培训(提交按钮)

        public DataSet Search_ForBindDdlInsertYear()
        {
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_ForBindDdlInsertYear");
        }//老员工培训，安排培训计划，新增年度计划外的培训前，需要绑定Dropdownlist的年份


        public int Insert_TrainingEachEmRecord(TrainningMonthPlanInfo ttmInfo)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_TrainingEachEmRecord",
                new SqlParameter("@TID_ID", ttmInfo.TID_ID), new SqlParameter("@HRDD_ID", ttmInfo.HRDD_ID));
        }//老员工培训，安排培训计划，新增参与某次培训项目的培训员工(提交按钮)

        public void Delete_PeopleIn_TrainingEachEmRecord(Guid ID)
        {
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_PeopleIn_TrainingEachEmRecord",
                new SqlParameter("@TEER_ID", ID));
        }//老员工培训，安排培训计划，删除参与某次培训项目的培训员工(linkbutton)

        public void Delete_OutOfYearPlan_TrainingItemDetail(Guid ID)
        {
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_OutOfYearPlan_TrainingItemDetail",
                new SqlParameter("@TID_ID", ID));
        }//老员工培训，安排培训计划，删除年度计划外的培训(删除linkbutton)

        public DataSet Search_ForEmpChoose_HRDDetail(string Condition)
        {
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_ForEmpChoose_HRDDetail", new SqlParameter("@Condition", Condition));
        }//老员工培训，安排培训计划，检索没有参与某次培训项目的培训员工

        public DataSet Search_HasInEmpChoose_HRDDetail(string Condition)
        {
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_HasInEmpChoose_HRDDetail", new SqlParameter("@Condition", Condition));
        }//老员工培训，安排培训计划，检索参与某次培训项目的培训员工

        public IList<TrainningMonthPlanInfo> SearchByID_ForArrange_TrainingItemDetail(Guid TID_ID)
        {
            SqlParameter para = new SqlParameter("@TID_ID", TID_ID);
            IList<TrainningMonthPlanInfo> hRFilesMgtInfo = new List<TrainningMonthPlanInfo>();
            SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_ByID_ForArrange_TrainingItemDetail", para);
            while (sdr.Read())
            {
                try
                {
                    hRFilesMgtInfo.Add(new TrainningMonthPlanInfo(sdr["TYPM_Year"].ToString(),sdr["TID_Month"].ToString(),
                    sdr["TTT_Type"] == DBNull.Value ? "" : sdr["TTT_Type"].ToString(), sdr["TID_TLesson"] == DBNull.Value ? "" : sdr["TID_TLesson"].ToString(),
                    sdr["TID_Target"] == DBNull.Value ? "" : sdr["TID_Target"].ToString(), sdr["TID_Place"] == DBNull.Value ? "" : sdr["TID_Place"].ToString(),
                    sdr["TID_CreditHours"] == DBNull.Value ? "" : sdr["TID_CreditHours"].ToString(), sdr["TID_Teacher"] == DBNull.Value ? "" : sdr["TID_Teacher"].ToString(),
                    sdr["TID_PTime"] == DBNull.Value ? "" : sdr["TID_PTime"].ToString(), sdr["BDOS_Name"] == DBNull.Value ? "" : sdr["BDOS_Name"].ToString(),
                    sdr["UMUI_UserName"] == DBNull.Value ? "" : sdr["UMUI_UserName"].ToString(),sdr["UMUI_UserID"] == DBNull.Value ? "" : sdr["UMUI_UserID"].ToString()));
                }
                catch (Exception)
                {
                    
                    throw;
                }
                
            }
            return hRFilesMgtInfo;
        }//老员工培训，安排培训计划，根据ID检索培训项目详情列表


        ///
        ///培训记录录入
        ///

        public DataSet Search_HRDDetail_TrainingEachEmRecord(string Condition)
        {
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_HRDDetail_TrainingEachEmRecord", new SqlParameter("@Condition", Condition));
        }//老员工培训，培训记录录入，检索参与某次培训项目的培训员工

        public int Update_ForScore_TrainingItemDetail(TrainningMonthPlanInfo ttmInfo)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_ForScore_TrainingItemDetail",
                new SqlParameter("@TID_ActTime", ttmInfo.TID_ActTime), new SqlParameter("@TID_ID", ttmInfo.TID_ID));

        }//老员工培训，培训记录录入，提交(更新：培训项目明细表)

        public int Update_ForScore_TrainingEachEmRecord(TrainningMonthPlanInfo ttmInfo)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_ForScore_TrainingEachEmRecord",
                new SqlParameter("@TEER_ID", ttmInfo.TEER_ID), new SqlParameter("@TEER_Result", ttmInfo.TEER_Result),
                new SqlParameter("@TEER_Remark", ttmInfo.TEER_Remark), new SqlParameter("@TID_ID", ttmInfo.TID_ID));

        }//老员工培训，培训记录录入，提交(更新：各员工培训结果记录表)

        public void Update_ForUP_TrainingItemDetail(Guid TID_ID, string TID_ResourceName, string TID_ResourceRoute)
        {
            SqlParameter[] parm = new SqlParameter[3];
            parm[0] = new SqlParameter("@TID_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = TID_ID;
            parm[1] = new SqlParameter("@TID_ResourceName", SqlDbType.VarChar, 40);
            parm[1].Value = TID_ResourceName;
            parm[2] = new SqlParameter("@TID_ResourceRoute", SqlDbType.VarChar, 200);
            parm[2].Value = TID_ResourceRoute;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_ForUP_TrainingItemDetail", parm);
        }//老员工培训，培训记录录入，上传培训课件


        public void Delete_ForDeleteFile_TrainingItemDetail(Guid TID_ID)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@TID_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = TID_ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_ForDeleteFile_TrainingItemDetail", parm);
        }//老员工培训，培训记录录入，删除培训课件


        public DataSet Search__TrainingEachEmRecord(Guid TID_ID)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@TID_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = TID_ID;
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_TrainingEachEmRecord", new SqlParameter("@TID_ID", TID_ID));
        }//老员工培训，培训记录查看
    }
}