using System;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
///SMOrderDeliverPlan 的摘要说明
/// </summary>

namespace EquipmentMangementAjax.SQLServer
{
    public class SMOrderDeliverPlanD : ISMOrderDeliverPlan
    {
        public SMOrderDeliverPlanD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
   
        //查询用于发货计划的订单
        public DataSet Select_DeliverPlan_Order(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_SMDeliverPlan_SMOrder", para);
        }
        //查询发货计划
        public DataSet Select_DeliverPlan(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_SMDeliverPlan", para);
        }
        //插入发货计划
        public void Insert_DeliverPlan(Guid ID,DateTime time)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@SMSOD_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = ID;
            para[1] = new SqlParameter("@SMDP_Time", SqlDbType.Date);
            para[1].Value = time;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_SMDeliverPlan", para);
        }
        //更新发货计划
        public void Update_DeliverPlan(Guid ID, decimal num)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@SMDP_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = ID;
            para[1] = new SqlParameter("@SMDP_Num", SqlDbType.Decimal,18);
            para[1].Value = num;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_SMDeliverPlan", para);
        }
        //删除发货计划
        public void Delete_DeliverPlan(Guid ID)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@SMDP_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_SMDeliverPlan", para);
        }
        //提交申请
        public void Insert_Apply(Guid ID,string man,string opinion)
        {
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("@SMSOD_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = ID;
            para[1] = new SqlParameter("@SMSDA_ApplyMan", SqlDbType.VarChar,20);
            para[1].Value = man;
            para[2] = new SqlParameter("@SMSDA_ApplyReason", SqlDbType.VarChar,400);
            para[2].Value = opinion;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_SMSpeDelApply", para);
        }
        //申请查询
        public DataSet Select_SepcialApply(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_SMSpecialApply", para);
        }
        //删除申请
        public void Delete_Apply(Guid ID)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@SMSDA_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_SMSpecialDelApply", para);
        }
        //审核申请
        public void Update_Apply_Check(Guid ID, string result, string opinion,string man)
        {
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@SMSDA_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = ID;
            para[1] = new SqlParameter("@SMSDA_CheckResult", SqlDbType.VarChar, 20);
            para[1].Value = result;
            para[2] = new SqlParameter("@SMSDA_CheckOpinion", SqlDbType.VarChar, 400);
            para[2].Value = opinion;
            para[3] = new SqlParameter("@SMSDA_CheckMan", SqlDbType.VarChar, 20);
            para[3].Value = man;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_SMSpecialDelApply_Check", para);
        }
      
    }
}

