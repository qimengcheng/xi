using System;
using System.Data;
using System.Data.SqlClient;
//using System.Collections.Generic;
using EquipmentMangementAjax.DBUtility;


/// <summary>
///SalesDeliverD 的摘要说明
/// </summary>

    public class SalesPriceD
    {
        public SalesPriceD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        //查询价格账期
        public DataSet Select_JiageZhangqi(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_CRMCustormerPaymentMain", para);

        }
        //删除价格账期
        public void Delete_JiageZhangqi(Guid id)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@CRMCPM_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_CRMCustormerPaymentMain", para);
        }
        //新建价格账期
        public void Update_TousuSort(Guid cID,Guid pID,Decimal price,int day,string man)
        {
            SqlParameter[] para = new SqlParameter[5];
            para[0] = new SqlParameter("@CRMCIF_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = cID;
            para[1] = new SqlParameter("@PT_ID", SqlDbType.UniqueIdentifier);
            para[1].Value = pID;
            para[2] = new SqlParameter("@CRMCPM_P", SqlDbType.Decimal,18);
            para[2].Value = price;
            para[3] = new SqlParameter("@CRMCPM_PaymentDay", SqlDbType.Int);
            para[3].Value = day;
            para[4] = new SqlParameter("@CRMCPM_MakeMan", SqlDbType.VarChar,20);
            para[4].Value = man;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_CRMCustormerPaymentMain", para);
        }
        //新建申请
        public void Insert_Apply(Guid id,decimal price ,int day,string name,string reason)
        {
            SqlParameter[] para = new SqlParameter[5];
            para[0] = new SqlParameter("@CRMCPM_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            para[1] = new SqlParameter("@CRMCPCA_ChangePrice", SqlDbType.Decimal,18);
            para[1].Value = price;
            para[2] = new SqlParameter("@CRMCPCA_ChangePaymentTime", SqlDbType.Int);
            para[2].Value = day;
            para[3] = new SqlParameter("@CRMCPCA_ApplyManName", SqlDbType.VarChar,20);
            para[3].Value = name;
            para[4] = new SqlParameter("@CRMCPCA_ApplyChangeReson", SqlDbType.VarChar, 400);
            para[4].Value = reason;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_CRMCustomerPaymentChangeApply", para);
        }
        //编辑申请
        public void Update_Apply(Guid id,decimal price, int day, string reason)
        {
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@CRMCPCA_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            para[1] = new SqlParameter("@CRMCPCA_ChangePrice", SqlDbType.Decimal);
            para[1].Value = price;
            para[2] = new SqlParameter("@CRMCPCA_ChangePaymentTime", SqlDbType.Int);
            para[2].Value = day;
            para[3] = new SqlParameter("@CRMCPCA_ApplyChangeReson", SqlDbType.VarChar, 400);
            para[3].Value = reason;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_CRMCustomerPaymentChangeApply_Edit", para);
        }
        //查询价格账期修改申请
        public DataSet Select_Apply(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_CRMCustomerPaymentChangeApply", para);

        }
        //查询价格账期修改申请
        public DataSet Select_PTPrice100(Guid id1,Guid id2)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@id1", SqlDbType.UniqueIdentifier);
            para[0].Value = id1;
            para[1] = new SqlParameter("@id2", SqlDbType.UniqueIdentifier);
            para[1].Value = id2;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_CRMCustomerPaymentChangeApply", para);

        }
        //删除申请
        public void Delete_Apply(Guid id)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@CRMCPCA_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_CRMCustomerPaymentChangeApply", para);
        }
        //查询产品主表
        public DataSet Select_PT(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_PT_CRMCustomerPaymentChangeApply", para);

        }
         //查询修改历史
        public DataSet Select_Histor(Guid id)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@id", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_SMPriceChangeHistory", para);

        }
        //审核
        public int Update_Apply_Check(Guid id, string result,string op,string man)
        {
            SqlParameter[] para = new SqlParameter[5];
            para[0] = new SqlParameter("@count", SqlDbType.Int);
            para[0].Direction = ParameterDirection.Output;
            para[1] = new SqlParameter("@CRMCPCA_ID", SqlDbType.UniqueIdentifier);
            para[1].Value = id;
            para[2] = new SqlParameter("@CRMCPCA_CheckResult", SqlDbType.VarChar,20);
            para[2].Value = result;
            para[3] = new SqlParameter("@CRMCPCA_CheckOpinion", SqlDbType.VarChar,400);
            para[3].Value = op;
            para[4] = new SqlParameter("@CRMCPCA_CheckMan", SqlDbType.VarChar, 20);
            para[4].Value = man;
          return   SqlHelper.ExecuteReturnQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_CRMCustomerPaymentChangeApply_Check", para);
        }
        //审pi
        public void Update_Apply_C(Guid id, string result, string op, string man)
        {
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@id", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            para[1] = new SqlParameter("@result", SqlDbType.VarChar, 20);
            para[1].Value = result;
            para[2] = new SqlParameter("@op", SqlDbType.VarChar, 400);
            para[2].Value = op;
            para[3] = new SqlParameter("@man", SqlDbType.VarChar, 20);
            para[3].Value = man;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_CRMCustomerPaymentChangeApply_Shenpi", para);
        }
    //价格账期修改
        public int Update_CRMCustormerPaymentMain(Guid id,decimal price ,int day,string man,string reason)
        {
            SqlParameter[] para = new SqlParameter[6];
            para[0] = new SqlParameter("@count", SqlDbType.Int);
            para[0].Direction= ParameterDirection.Output;
            para[1] = new SqlParameter("@id", SqlDbType.UniqueIdentifier);
            para[1].Value = id;
            para[2] = new SqlParameter("@price", SqlDbType.Decimal,18);
            para[2].Value = price;
            para[3] = new SqlParameter("@day", SqlDbType.Int);
            para[3].Value = day;
            para[4] = new SqlParameter("@man", SqlDbType.VarChar,20);
            para[4].Value = man;
            para[5] = new SqlParameter("@reason", SqlDbType.VarChar,400);
            para[5].Value = reason;
           int ds = SqlHelper.ExecuteReturnQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_CRMCustormerPaymentMain", para);
            return ds;
        }
    }
