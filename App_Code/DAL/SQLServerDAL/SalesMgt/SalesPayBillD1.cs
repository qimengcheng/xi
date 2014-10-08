using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections;
//using System.Collections.Generic;
using EquipmentMangementAjax.DBUtility;


/// <summary>
///SalesPayBill 的摘要说明
/// </summary>
//namespace EquipmentMangementAjax.SQLServer
//{
    public class SalesPayBillD1
    {
        public SalesPayBillD1()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        //查询总表
        public DataSet Select_Main(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_SMCustomerBillPayMain", para);

        }

        //编辑总表
        public void Update_Main(Guid id, decimal loan, decimal maturity, decimal bill, string man)
        {
            SqlParameter[] para = new SqlParameter[5];
            para[0] = new SqlParameter("@SMCBPM_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            para[1] = new SqlParameter("@SMCBPM_TotalLoan", SqlDbType.Decimal, 18);
            para[1].Value = loan;
            para[2] = new SqlParameter("@SMCBPM_MaturityLoan", SqlDbType.Decimal, 18);
            para[2].Value = maturity;
            para[3] = new SqlParameter("@SMCBPM_NoBillTotal", SqlDbType.Decimal, 18);
            para[3].Value = bill;
            para[4] = new SqlParameter("@SMCBPM_Man", SqlDbType.VarChar, 20);
            para[4].Value = man;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_SMCustomerBillPayMain", para);
        }
        //查询汇款表
        public DataSet Select_Pay(Guid id)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@SMCBPM_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_SMCustomerPayment", para);

        }
        //查询开票表
        public DataSet Select_Bill(Guid id)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@SMCBPM_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_SMCustomerBill", para);

        }
        //编辑回款表
        public void Update_Pay(Guid id, decimal money, string man, string remark)
        {
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@SMCP_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            para[1] = new SqlParameter("@SMCP_PaymentMoney", SqlDbType.Decimal, 18);
            para[1].Value = money;
            para[2] = new SqlParameter("@SMCP_MakeMan", SqlDbType.VarChar, 20);
            para[2].Value = man;
            para[3] = new SqlParameter("@SMCP_Remark", SqlDbType.VarChar, 400);
            para[3].Value = remark;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_SMCustomerPayment", para);
        }
        //删除回款表
        public void Delete_Pay(Guid id)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@SMCP_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_SMCustomerPayment", para);
        }
        //新建回款表
        public int Insert_Pay(Guid id, decimal money, string man, string remark)
        {
            SqlParameter[] para = new SqlParameter[5];
            para[1] = new SqlParameter("@CRMCIF_ID", SqlDbType.UniqueIdentifier);
            para[1].Value = id;
            para[2] = new SqlParameter("@SMCP_PaymentMoney", SqlDbType.Decimal, 18);
            para[2].Value = money;
            para[3] = new SqlParameter("@SMCP_MakeMan", SqlDbType.VarChar, 20);
            para[3].Value = man;
            para[4] = new SqlParameter("@SMCP_Remark", SqlDbType.VarChar, 400);
            para[4].Value = remark;
            para[0] = new SqlParameter("@return", SqlDbType.Int);
            para[0].Direction = ParameterDirection.Output;
            int repeat = SqlHelper.ExecuteReturnQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_SMCustomerPayment", para);
            return repeat;
        }
        //删除main表
        public void Delete_Main(Guid id)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@SMCBPM_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_SMCustomerBillPayMain", para);
        }
        //新建开票表
        public int Insert_Bill(Guid id, Guid ptID, string num, decimal money, string man, string remark,decimal price,decimal pronum )
        {
            SqlParameter[] para = new SqlParameter[9];
            para[1] = new SqlParameter("@CRMCIF_ID", SqlDbType.UniqueIdentifier);
            para[1].Value = id;
            para[2] = new SqlParameter("@PT_ID", SqlDbType.UniqueIdentifier);
            para[2].Value = ptID;
            para[3] = new SqlParameter("@SMCB_BillNum", SqlDbType.VarChar, 200);
            para[3].Value = num;
            para[4] = new SqlParameter("@SMCB_BillMoney", SqlDbType.Decimal, 18);
            para[4].Value = money;
            para[5] = new SqlParameter("@SMCB_MakeMan", SqlDbType.VarChar, 400);
            para[5].Value = man;
            para[6] = new SqlParameter("@SMCB_Remark", SqlDbType.VarChar, 20);
            para[6].Value = remark;
            para[7] = new SqlParameter("@SMCB_Price", SqlDbType.Decimal, 18);
            para[7].Value = price;
            para[8] = new SqlParameter("@SMCB_ProNum", SqlDbType.Decimal, 18);
            para[8].Value = pronum;
            para[0] = new SqlParameter("@return", SqlDbType.Int);
            para[0].Direction = ParameterDirection.Output;
            int repeat = SqlHelper.ExecuteReturnQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_SMCustomerBill", para);
            return repeat;
        }
        //编辑开票表
        public void Update_Bill(Guid id, Guid ptID, string num, decimal money, string man, string remark,decimal price,decimal pronum)
        {
            SqlParameter[] para = new SqlParameter[8];
            para[0] = new SqlParameter("@SMCB_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            para[1] = new SqlParameter("@PT_ID", SqlDbType.UniqueIdentifier);
            para[1].Value = ptID;
            para[2] = new SqlParameter("@SMCB_BillNum", SqlDbType.VarChar, 200);
            para[2].Value = num;
            para[3] = new SqlParameter("@SMCB_BillMoney", SqlDbType.Decimal, 18);
            para[3].Value = money;
            para[4] = new SqlParameter("@SMCB_MakeMan", SqlDbType.VarChar, 400);
            para[4].Value = man;
            para[5] = new SqlParameter("@SMCB_Remark", SqlDbType.VarChar, 20);
            para[5].Value = remark;
            para[6] = new SqlParameter("@SMCB_Price", SqlDbType.Decimal,18);
            para[6].Value = man;
            para[7] = new SqlParameter("@SMCB_ProNum", SqlDbType.Decimal, 18);
            para[7].Value = remark;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_SMCustomerBill", para);
        }
        //删除bill
        public void Delete_Bill(Guid id)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@SMCB_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_SMCustomerBill", para);
        }
        //新建总表
        public void Insert_Main(Guid id, decimal loan, decimal maturity, decimal bill, string man)
        {
            SqlParameter[] para = new SqlParameter[5];
            para[0] = new SqlParameter("@CRMCIF_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            para[1] = new SqlParameter("@SMCBPM_TotalLoan", SqlDbType.Decimal, 18);
            para[1].Value = loan;
            para[2] = new SqlParameter("@SMCBPM_MaturityLoan", SqlDbType.Decimal, 18);
            para[2].Value = maturity;
            para[3] = new SqlParameter("@SMCBPM_NoBillTotal", SqlDbType.Decimal, 18);
            para[3].Value = bill;
            para[4] = new SqlParameter("@SMCBPM_Man", SqlDbType.VarChar, 20);
            para[4].Value = man;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_SMCustomerBillPayMain", para);
        }
        //查询修改历史表
        public DataSet Select_History(Guid id)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@id", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_SMCustomerBillPayMainCHistory", para);

        }
    }
//}