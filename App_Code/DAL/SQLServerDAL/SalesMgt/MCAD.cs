using System;
using System.Data;
using System.Data.SqlClient;
//using System.Collections.Generic;
using EquipmentMangementAjax.DBUtility;


/// <summary>
///SalesDeliverD 的摘要说明
/// </summary>

    public class MCAD
    {
        public MCAD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        //查询投诉类别
        public DataSet Select_MCA(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@condition", SqlDbType.NVarChar, 1000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_MCA", para);

        }
      
        //create mca
        public void Insert_MCA(string man,string department,string name,string note,int mount,string load,string path)
        {
            SqlParameter[] para = new SqlParameter[7];
            para[0] = new SqlParameter("@man", SqlDbType.VarChar,20);
            para[0].Value = man;
            para[1] = new SqlParameter("@department", SqlDbType.VarChar, 50);
            para[1].Value = department;
            para[2] = new SqlParameter("@name", SqlDbType.VarChar, 200);
            para[2].Value = name;
            para[3] = new SqlParameter("@note", SqlDbType.VarChar, 400);
            para[3].Value = note;
            para[4] = new SqlParameter("@mount", SqlDbType.Int);
            para[4].Value = mount;
            para[5] = new SqlParameter("@load", SqlDbType.Char,2);
            para[5].Value = load;
            para[6] = new SqlParameter("@path", SqlDbType.VarChar, 200);
            para[6].Value = path;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_MCA", para);
        }
        //部门审核
        public void Update_MCA_DCheck(Guid id ,string man, string state, string note)
        {
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@id", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            para[1] = new SqlParameter("@man", SqlDbType.VarChar, 20);
            para[1].Value = man;
            para[2] = new SqlParameter("@state", SqlDbType.VarChar, 20);
            para[2].Value = state;
            para[3] = new SqlParameter("@note", SqlDbType.VarChar, 400);
            para[3].Value = note;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_MCA_DCheck", para);
        }
        //报价
        public void Update_MCA_Price(Guid id,decimal price)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@id", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            para[1] = new SqlParameter("@price", SqlDbType.Decimal,18);
            para[1].Value = price;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_MCA_Price", para);
        }
        //副总审核
        public void Update_MCA_MCheck(Guid id,string man,string state,string note)
        {
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@id", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            para[1] = new SqlParameter("@man", SqlDbType.VarChar, 20);
            para[1].Value = man;
            para[2] = new SqlParameter("@state", SqlDbType.VarChar, 50);
            para[2].Value = state;
            para[3] = new SqlParameter("@note", SqlDbType.VarChar, 400);
            para[3].Value = note;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_MCA_MCheck", para);
        }
        //确认收货
        public void Proc_U_MCA_Over(Guid id,  string man)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@id", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            para[1] = new SqlParameter("@man", SqlDbType.VarChar, 20);
            para[1].Value = man;
     
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_MCA_Over", para);
        }
       
    }
