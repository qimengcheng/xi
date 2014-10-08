using System;
using System.Data;
using System.Data.SqlClient;
//using System.Collections.Generic;
using EquipmentMangementAjax.DBUtility;



/// <summary>
///SalesDeliverD 的摘要说明
/// </summary>

    public class SalesReturnReasonD
    {
        public SalesReturnReasonD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        public DataSet Select_Reason(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_SMReturnReason", para);

        }
        //新增
        public void Insert_Reason(string name,string note)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@SMRR_Name", SqlDbType.VarChar,100);
            para[0].Value = name;
            para[1] = new SqlParameter("@SMRR_Note", SqlDbType.VarChar,400);
            para[1].Value = note;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_SMReturnReason", para);
        }
        //修改
        public void Update_Reason(Guid id,string name,string note)
        {
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("@SMRR_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            para[1] = new SqlParameter("@SMRR_Name", SqlDbType.VarChar, 100);
            para[1].Value = name;
            para[2] = new SqlParameter("@SMRR_Note", SqlDbType.VarChar,400);
            para[2].Value = note;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_SMReturnReason", para);
        }
        //删除
        public void Delete_Reason(Guid id)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@SMRR_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_SMReturnReason", para);
        }
    }
