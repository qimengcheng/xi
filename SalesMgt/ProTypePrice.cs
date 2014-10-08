using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections;
//using System.Collections.Generic;
using EquipmentMangementAjax.DBUtility;
/// <summary>
///SalesDeliverD 的摘要说明
/// </summary>

    public class ProTypePrice
    {
        public ProTypePrice()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        //查询产品表
        public DataSet Select_PTPrice(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_ProTypePrice", para);

        }
        //查询产品修改历史
        public DataSet Select_PTPriceH(Guid id)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@id", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_ProTypePriceH", para);

        }
        //修改产品类型
        public void Insert_change(Guid  id,string man,decimal num)
        {
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("@PT_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            para[1] = new SqlParameter("@man", SqlDbType.VarChar,20);
            para[1].Value = man;
            para[2] = new SqlParameter("@num", SqlDbType.Decimal,18);
            para[2].Value = num;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_ProTypePrice", para);
        }
        //查询业务员表
        public DataSet Select_SalesMan(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@condition", SqlDbType.NVarChar, 1000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_SMSalesMan", para);

        }
        //查询业务员表是否重复
        public DataSet Select_SalesManSame(string name)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@name", SqlDbType.VarChar, 20);
            para[0].Value = name;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_SMSalesMan_Same", para);

        }
        //删除业务员
        public void Delete_SalesMan(Guid id)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@SMSM_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_SMSalesMan", para);
        }
        //删除业务员类别
        public void Delete_SalesManSort(Guid id)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@id", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_SMSalesManSort", para);
        }
        //新增业务员
        public void Insert_SalesMan(string id,Guid mid)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@name", SqlDbType.VarChar,20);
            para[0].Value = id;
            para[1] = new SqlParameter("@mid", SqlDbType.UniqueIdentifier);
            para[1].Value = mid;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_SMSalseMan", para);
        }
        //新增业务员leibie
        public void Insert_SalesManSort(string name,string note)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@name", SqlDbType.VarChar,40);
            para[0].Value = name;
            para[1] = new SqlParameter("@note", SqlDbType.VarChar, 400);
            para[1].Value = note;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_SMSalseManSort", para);
        }
        //修改业务员
        public int Update_SalesMan(Guid id,string name,Guid sid)
        {
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@count", SqlDbType.Int);
            para[0].Direction = ParameterDirection.Output;
            para[1] = new SqlParameter("@SMSM_ID", SqlDbType.UniqueIdentifier);
            para[1].Value = id;
            para[2] = new SqlParameter("@name", SqlDbType.VarChar, 20);
            para[2].Value = name;
            para[3] = new SqlParameter("@mid", SqlDbType.UniqueIdentifier);
            para[3].Value = sid;
            return (int)SqlHelper.ExecuteReturnQuery(SqlHelper.ConnectionStringLocalTransaction,
             CommandType.StoredProcedure, "Proc_U_SMSalesMan", para);
            
        }
        //修改业务员类别
        public int Update_SalesManSort(Guid id, string name,string note)
        {
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@count", SqlDbType.Int);
            para[0].Direction = ParameterDirection.Output;
            para[1] = new SqlParameter("@id", SqlDbType.UniqueIdentifier);
            para[1].Value = id;
            para[2] = new SqlParameter("@name", SqlDbType.VarChar, 40);
            para[2].Value = name;
            para[3] = new SqlParameter("@note", SqlDbType.VarChar, 400);
            para[3].Value = note;
            return (int)SqlHelper.ExecuteReturnQuery(SqlHelper.ConnectionStringLocalTransaction,
             CommandType.StoredProcedure, "Proc_U_SMSalesManSort", para);

        }
        //查询业务员类别
        public DataSet Select_SalesManSort(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@condition", SqlDbType.NVarChar, 1000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_SMSalesManSort", para);

        }
        //查询相同的价格账期
        public DataSet Select_SameCustomPTPrice(Guid id,Guid id2)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@id", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            para[1] = new SqlParameter("@id1", SqlDbType.UniqueIdentifier);
            para[1].Value = id2;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_SMSameCustomPTPrice", para);

        }
        //查询产品系列
        public DataSet Select_PS()
        {
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_PS");
        }
        //更新订单详细的发货状态为发货完成
        public void Update_Order_ADel(Guid id,string man)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@id", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            para[1] = new SqlParameter("@man", SqlDbType.VarChar,20);
            para[1].Value = man;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_SMSalesOrderDetail_Over", para);

        }
    }

