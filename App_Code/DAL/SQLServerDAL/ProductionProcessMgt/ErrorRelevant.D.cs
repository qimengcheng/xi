using System;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
///ErrorRelevant 的摘要说明
/// </summary>
namespace EquipmentMangementAjax.SQLServer
{
    public class ErrorRelevant : IErrorRelevant
    {
        public ErrorRelevant()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        public DataSet S_WorkOrder_Check(string condition)//随工单查看
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@condition", SqlDbType.NVarChar, 2000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_WorkOrder_Check", para);

        }

        public DataSet S_WorkOrderDetail_ErrorCheck(Guid wOD_ID)//查看随工单详细的异常信息
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@WOD_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = wOD_ID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_WorkOrderDetail_ErrorCheck", para);

        }

        public DataSet S_WOError(Guid wOE_ID)//查看详细的异常信息
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@WOE_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = wOE_ID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_WOError", para);

        }

        public void U__WOError_MQC(Guid woeid, string wOE_MQCPeople, string wOE_QCResult)//编辑异常材料检验信息
        {
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("@WOE_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = woeid;
            para[1] = new SqlParameter("@WOE_MQCPeople", SqlDbType.VarChar, 20);
            para[1].Value = wOE_MQCPeople;
            para[2] = new SqlParameter("@WOE_MQCResult", SqlDbType.VarChar, 400);
            para[2].Value = wOE_QCResult;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_WOError_MQC", para);
        }

        public void U_WOError_Deal(Guid woeid, string wOE_DealMan, string wOE_ReaAnalysis, string wOE_ProDeal, string wOE_LongTimeMeasure)//编辑异常材料处理信息
        {
            SqlParameter[] para = new SqlParameter[5];
            para[0] = new SqlParameter("@WOE_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = woeid;
            para[1] = new SqlParameter("@WOE_DealMan", SqlDbType.VarChar, 20);
            para[1].Value = wOE_DealMan;
            para[2] = new SqlParameter("@WOE_ReaAnalysis", SqlDbType.VarChar, 400);
            para[2].Value = wOE_ReaAnalysis;
            para[3] = new SqlParameter("@WOE_ProDeal", SqlDbType.VarChar, 200);
            para[3].Value = wOE_ProDeal;
            para[4] = new SqlParameter("@WOE_LongTimeMeasure", SqlDbType.VarChar, 500);
            para[4].Value = wOE_LongTimeMeasure;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_WOError_Deal", para);
        }

        public void U_WOError_Track(Guid woeid, string wOE_TrackMan, string wOE_TrackResult)//编辑异常跟踪信息
        {
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("@WOE_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = woeid;
            para[1] = new SqlParameter("@WOE_TrackMan", SqlDbType.VarChar, 20);
            para[1].Value = wOE_TrackMan;
            para[2] = new SqlParameter("@WOE_TrackResult", SqlDbType.VarChar, 200);
            para[2].Value = wOE_TrackResult;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_WOError_Track", para);
        }


        public void U_WOError_Review(Guid woeid, string wOE_ReviewMan, string wOE_ReviewSuggestion, string wOE_RResult)//编辑异常审核信息
        {
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@WOE_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = woeid;
            para[1] = new SqlParameter("@WOE_ReviewMan", SqlDbType.VarChar, 20);
            para[1].Value = wOE_ReviewMan;
            para[2] = new SqlParameter("@WOE_ReviewSuggestion", SqlDbType.VarChar, 400);
            para[2].Value = wOE_ReviewSuggestion;
            para[3] = new SqlParameter("@WOE_RResult", SqlDbType.VarChar, 20);
            para[3].Value = wOE_RResult;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_WOError_Review", para);
        }


        public void U_WOError_Done(Guid woeid, string wOE_DoneMan, string wOE_QCResult, string wOE_DoneResult, string wOE_State)//编辑异常结案信息
        {
            SqlParameter[] para = new SqlParameter[5];
            para[0] = new SqlParameter("@WOE_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = woeid;
            para[1] = new SqlParameter("@WOE_DoneMan", SqlDbType.VarChar, 20);
            para[1].Value = wOE_DoneMan;
            para[2] = new SqlParameter("@WOE_QCResult", SqlDbType.VarChar, 200);
            para[2].Value = wOE_QCResult;
            para[3] = new SqlParameter("@WOE_DoneResult", SqlDbType.VarChar, 20);
            para[3].Value = wOE_DoneResult;
            para[4] = new SqlParameter("@WOE_State", SqlDbType.VarChar, 20);
            para[4].Value = wOE_State;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_WOError_Done", para);
        }


        public void U_WOError_Rework(Guid woeid, Guid pBC_ID, string wOE_ReworkAppMan, Guid rWO_ID, DateTime wOE_ReWorkDate, int wOE_ReworkNum, string wOE_ReworkDetail)//编辑异常返工信息
        {
            SqlParameter[] para = new SqlParameter[7];
            para[0] = new SqlParameter("@WOE_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = woeid;
            para[1] = new SqlParameter("@PBC_ID", SqlDbType.UniqueIdentifier);
            para[1].Value = pBC_ID;
            para[2] = new SqlParameter("@WOE_ReworkAppMan", SqlDbType.VarChar, 20);
            para[2].Value = wOE_ReworkAppMan;
            para[3] = new SqlParameter("@RWO_ID", SqlDbType.UniqueIdentifier);
            para[3].Value = rWO_ID;
            para[4] = new SqlParameter("@WOE_ReWorkDate", SqlDbType.Date);
            para[4].Value = wOE_ReWorkDate;
            para[5] = new SqlParameter("@WOE_ReworkNum", SqlDbType.Int);
            para[5].Value = wOE_ReworkNum;
            para[6] = new SqlParameter("@WOE_ReworkDetail", SqlDbType.VarChar, 400);
            para[6].Value = wOE_ReworkDetail;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_WOError_Rework", para);
        }

        public DataSet S_WOError_Rework_ReWorkOption()//返工信息待选返工选项
        {

            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_WOError_Rework_ReWorkOption", null);

        }
        public DataSet S_WOError_Rework_PBCraft()//返工信息待选工序
        {

            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_WOError_Rework_PBCraft", null);

        }
    }
}