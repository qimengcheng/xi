using System;
using System.Data;
using System.Data.SqlClient;
//using System.Collections.Generic;
using EquipmentMangementAjax.DBUtility;


/// <summary>
///SalesPayBill 的摘要说明
/// </summary>
//namespace EquipmentMangementAjax.SQLServer
//{
    public class SalesPayBillD
    {
        public SalesPayBillD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        //查询发货单
        public DataSet Select_Main(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_V_OrderDeliver", para);

        }

        //进行开票
        public void Insert_Bill(Guid id, decimal price, decimal mount, string num,string remark, string man,string over)
        {
            SqlParameter[] para = new SqlParameter[7];
            para[0] = new SqlParameter("@id", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            para[1] = new SqlParameter("@price", SqlDbType.Decimal, 18);
            para[1].Value = price;
            para[2] = new SqlParameter("@mount", SqlDbType.Decimal, 18);
            para[2].Value = mount;
            para[3] = new SqlParameter("@num", SqlDbType.VarChar,200);
            para[3].Value = num;
            para[4] = new SqlParameter("@remark", SqlDbType.VarChar, 400);
            para[4].Value = remark;
            para[5] = new SqlParameter("@man", SqlDbType.VarChar, 20);
            para[5].Value = man;
            para[6] = new SqlParameter("@over", SqlDbType.Char,2);
            para[6].Value = over;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_OrderBill", para);
        }
        //进行付款
        public decimal Insert_Pay(Guid id, decimal money,  string remark, string man)
        {
            SqlParameter[] para = new SqlParameter[5];
            para[0] = new SqlParameter("@count", SqlDbType.Decimal, 18);
            para[0].Direction = ParameterDirection.Output;
            para[1] = new SqlParameter("@money", SqlDbType.Decimal, 18);
            para[1].Value = money;
            para[2] = new SqlParameter("@remark", SqlDbType.VarChar,400);
            para[2].Value = remark;
            para[3] = new SqlParameter("@man", SqlDbType.VarChar, 20);
            para[3].Value = man;
            para[4] = new SqlParameter("@id", SqlDbType.UniqueIdentifier);
            para[4].Value = id;
            return SqlHelper.ExecuteReturnDecimalQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_OrderPay", para);
        }
        //检索发货单的开票记录
         public DataSet Select_Bill(Guid id )
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@id", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_OrderBill", para);

        }
         //检索发货单的付款记录
         public DataSet Select_Pay(Guid id)
         {
             SqlParameter[] para = new SqlParameter[1];
             para[0] = new SqlParameter("@id", SqlDbType.UniqueIdentifier);
             para[0].Value = id;
             return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_OrderPay", para);

         }
       
    }
//}