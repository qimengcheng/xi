using System;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
/// HSFElementD 的摘要说明
/// </summary>
public class HSFElementD
{
	public HSFElementD()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    public DataSet Query(string name)
    {
        SqlParameter[] para =
        {
           
            new SqlParameter("@name", SqlDbType.VarChar,40) {Value = name}
        
        };
        if (name == "")
        {
            para[0].Value = null;
        }
        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_HSFElement", para);
        return ds;
    }
    public DataSet Query(string name,Guid id)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@id", SqlDbType.UniqueIdentifier) {Value = id},
            new SqlParameter("@name", SqlDbType.VarChar,40) {Value = name}
        
        };
        if (name=="")
        {
            para[1].Value = null;
        }
        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_HSFElement_AI", para);
        return ds;
    }

    public int InsertElement(string name, string standard, string obj, string man,string note )
    {
        SqlParameter[] para = new SqlParameter[5];
        para[0] = new SqlParameter("@name", SqlDbType.VarChar,40);
        para[0].Value = name;
        para[1] = new SqlParameter("@standard", SqlDbType.VarChar,20);
        para[1].Value = standard;
        para[2] = new SqlParameter("@object", SqlDbType.VarChar,8000);
        para[2].Value = obj;
        para[3] = new SqlParameter("@man", SqlDbType.VarChar,20);
        para[3].Value = man;
        para[4] = new SqlParameter("@note", SqlDbType.VarChar,400);
        para[4].Value = note;

    int a=SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_HSFElement", para);
        return a;
    }

    public int UpdateElement(Guid id, string name, string standard, string obj, string man, string note)
    {
        SqlParameter[] para = new SqlParameter[6];

        para[0] = new SqlParameter("@name", SqlDbType.VarChar, 40);
        para[0].Value = name;
        para[1] = new SqlParameter("@standard", SqlDbType.VarChar, 20);
        para[1].Value = standard;
        para[2] = new SqlParameter("@object", SqlDbType.VarChar, 8000);
        para[2].Value = obj;
        para[3] = new SqlParameter("@man", SqlDbType.VarChar, 20);
        para[3].Value = man;
        para[4] = new SqlParameter("@note", SqlDbType.VarChar, 400);
        para[4].Value = note;
        para[5] = new SqlParameter("@id", SqlDbType.UniqueIdentifier);
        para[5].Value = id;

        int a = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_HSFElement", para);
        return a;
    }

    public int  DeleteElement(Guid id)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@id", SqlDbType.UniqueIdentifier) {Value = id}
        
        };
    
        int ds = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_HSFElement", para);
        return ds;
    }
}