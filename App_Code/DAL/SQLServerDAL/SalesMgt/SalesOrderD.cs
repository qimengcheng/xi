using System;
using System.Data;
using System.Data.SqlClient;
//using System.Collections.Generic;
using EquipmentMangementAjax.DBUtility;

/// <summary>
///SalesOrderD 的摘要说明
/// </summary>
namespace EquipmentMangementAjax.SQLServer
{
    public class SalesOrderD : ISalesOrder
    {
        public SalesOrderD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        //模糊查询销售订单主表
        public DataSet Select_SalesOrder(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_SMSalesOrder", para);
        }
        //模糊查询销售订单详细表
        public DataSet Select_SalesOrderDetail(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_SMSalesOrderDetail", para);

        }
        //点击查看对应的订单详细表
        public DataSet Select_SalesOrderDetail_Gridview(Guid ordernum)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@SMSO_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = ordernum;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_SMSalesOrderDetail_Gridview", para);

        }
        //删除订单主表
        public void Delete_SalseOrder(Guid ordernum)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@SMSO_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = ordernum;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_SMSalesOrder", para);

        }
        //删除订单详细表
        public void Delete_SalseOrderDetail(Guid orderDetailnum)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@SMSOD_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = orderDetailnum;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_SMSalesOrderDetail", para);
        }
        //编辑订单表
        public void Update_SalesOrder(Guid ordernum,string cusordernum,string detail,string ordertype)
        {
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@SMSO_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = ordernum;
            para[1] = new SqlParameter("@SMSO_CusOrderNum", SqlDbType.VarChar,100);
            para[1].Value = cusordernum;
            para[2] = new SqlParameter("@SMSO_DetailCir", SqlDbType.VarChar,100);
            para[2].Value = detail;
            para[3] = new SqlParameter("@SMSO_OrderType", SqlDbType.VarChar ,20);
            para[3].Value = ordertype;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_SMSalesOrder", para);
        }
        //编辑订单详细表
        public void Update_SalesOrderDetail(Guid orderdetailnum, DateTime addetime,int alerttime,string batchnum,string model,string special,string pay,DateTime deltime,int mount)
        {
            SqlParameter[] para = new SqlParameter[9];
            para[0] = new SqlParameter("@SMSOD_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = orderdetailnum;
            para[1] = new SqlParameter("@SMSOD_OrderAdvanceDelTime", SqlDbType.DateTime);
            para[1].Value = addetime;
            para[2] = new SqlParameter("@SMSOD_DelAlertTime", SqlDbType.Int);
            para[2].Value = alerttime;
            para[3] = new SqlParameter("@SMSOD_ChipBatchNum", SqlDbType.VarChar, 100);
            para[3].Value = batchnum;
            para[4] = new SqlParameter("@SMSOD_CustomerProModel", SqlDbType.VarChar, 100);
            para[4].Value = model;
            para[5] = new SqlParameter("@SMSOD_Special", SqlDbType.Char, 2);
            para[5].Value = special;
            para[6] = new SqlParameter("@SMSOD_PayMethon", SqlDbType.VarChar, 20);
            para[6].Value = pay;
            para[7] = new SqlParameter("@SMSOD_OrderDelTime", SqlDbType.DateTime);
            para[7].Value = deltime;
            para[8] = new SqlParameter("@SMSOD_Mount", SqlDbType.Int);
            para[8].Value = mount;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_SMSalesOrderDetail", para);
        }
        //新建订单
        public void Insert_SalesOrder(string cusordernum,string salesman,Guid crmcifID,string ordertype,string detailcir,string inputpep)
        {
            SqlParameter[] para = new SqlParameter[6];
            para[0] = new SqlParameter("@SMSO_CusOrderNum", SqlDbType.VarChar,100);
            para[0].Value = cusordernum;
            para[1] = new SqlParameter("@SMSO_SalesMan", SqlDbType.VarChar ,20);
            para[1].Value = salesman;
            para[2] = new SqlParameter("@CRMCIF_ID", SqlDbType.UniqueIdentifier);
            para[2].Value = crmcifID;
            para[3] = new SqlParameter("@SMSO_OrderType", SqlDbType.VarChar, 20);
            para[3].Value = ordertype;
            para[4] = new SqlParameter("@SMSO_DetailCir", SqlDbType.VarChar, 100);
            para[4].Value = detailcir;
            para[5] = new SqlParameter("@SMSO_InputPep", SqlDbType.VarChar, 20);
            para[5].Value = inputpep;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_SMSalesOrder", para);
        }
        //模糊查询客户表
        public DataSet Select_Custom(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_SMCustomer", para);
        }
        //根据产品型号新建订单详细
        public void Insert_SalesOrder(Guid pt,Guid sm)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@PT_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = pt;
            para[1] = new SqlParameter("@SMSO_ID", SqlDbType.UniqueIdentifier);
            para[1].Value = sm;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_SMSalesOrderDetail", para);
        }
         //提交订单详细
        public int Update_SalesOrderState_ConfirmNew(Guid orderID)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[1] = new SqlParameter("@SMSO_ID", SqlDbType.UniqueIdentifier);
            para[1].Value = orderID;
            para[0] = new SqlParameter("@count", SqlDbType.Int);
            para[0].Direction = ParameterDirection.Output;
            int repeat = SqlHelper.ExecuteReturnQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_SMOrderSales_ConfirmnewOrderDetail", para);
            return repeat;
            
        }
        //查看修改历史
        public DataSet Select_DelChangeHistory(Guid detailID)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@SMSOD_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = detailID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_SMDelTimeChangeHistory", para);
        }
        //插入修改历史
        public void Insert_SMDelTimeChangeHistory(Guid DetailID,DateTime AfterChangeDelTime,string man ,DateTime ChangeTime)
        {
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@SMSOD_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = DetailID;
            para[1] = new SqlParameter("@SMDTCH_AfterChangeDelTime", SqlDbType.Date);
            para[1].Value = AfterChangeDelTime;
            para[2] = new SqlParameter("@SMDTCH_ChangePep", SqlDbType.VarChar, 20);
            para[2].Value = man;
            para[3] = new SqlParameter("@SMDTCH_ChangeTime", SqlDbType.Date);
            para[3].Value = ChangeTime;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_SMDelTimeChangeHistory", para);
        }
    }
}


