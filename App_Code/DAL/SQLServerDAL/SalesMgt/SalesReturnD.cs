using System;
using System.Data;
using System.Data.SqlClient;
//using System.Collections.Generic;
using EquipmentMangementAjax.DBUtility;


/// <summary>
///SalesDeliverD 的摘要说明
/// </summary>

    public class SalesReturnD
    {
        public SalesReturnD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        public DataSet Select_Fahuodan(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_V_SMOrderDeliver", para);

        }
        //确认收货
        public void Update_Fahuodan_Queren(Guid id)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@SMOD_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_SMOrderDeliver", para);
        }
        //确认退货
        public void Update_Fahuodan_Tuihuo(Guid id,string man,int num,string reason,Guid ResonID)
        {
            SqlParameter[] para = new SqlParameter[5];
            para[0] = new SqlParameter("@SMOD_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            para[1] = new SqlParameter("@SMRC_MakeMan", SqlDbType.VarChar,20);
            para[1].Value = man;
            para[2] = new SqlParameter("@SMRC_ReturnNum", SqlDbType.Int);
            para[2].Value = num;
            para[3] = new SqlParameter("@SMRC_ReturnReason", SqlDbType.VarChar, 400);
            para[3].Value = reason;
            para[4] = new SqlParameter("@SMRR_ID", SqlDbType.UniqueIdentifier );
            para[4].Value = ResonID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_SMOrderDeliver_Tui", para);
        }
        //确认换货
        public void Update_Fahuodan_Huanhuo(Guid id, string man, int num, string reason)
        {
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@SMOD_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            para[1] = new SqlParameter("@SMRC_MakeMan", SqlDbType.VarChar, 20);
            para[1].Value = man;
            para[2] = new SqlParameter("@SMRC_ReturnNum", SqlDbType.Int);
            para[2].Value = num;
            para[3] = new SqlParameter("@SMRC_ReturnReason", SqlDbType.VarChar, 400);
            para[3].Value = reason;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_SMOrderDeliver_Huan", para);
        }
        //检索退货单
        public DataSet Select_Tuihuodan(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_SMReturnChange_Return", para);

        }
        //编辑退货单处理结果
        public void Update_Tuihuodan_Chuli(string result,string man ,Guid id)
        {
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("@SMRC_ProcessResult", SqlDbType.VarChar, 400);
            para[0].Value = result;
            para[1] = new SqlParameter("@SMRC_ProcessResultMan", SqlDbType.VarChar, 20);
            para[1].Value = man;
            para[2] = new SqlParameter("@SMRC_ID", SqlDbType.UniqueIdentifier);
            para[2].Value = id;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_SMReturnChange_Process", para);
        }
        //删除退货单
        public void Delete_Tuihuodan( Guid id)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@SMRC_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_SMReturnChange", para);
        }
    }
