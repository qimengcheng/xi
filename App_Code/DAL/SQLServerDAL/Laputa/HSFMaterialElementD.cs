using System;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
/// HSFMaterialElementD 的摘要说明
/// </summary>
public class HSFMaterialElementD
{
	public HSFMaterialElementD()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}



    public int UpdateMaterial(Guid id, string name, string provider, string texture, string level, string note)
    {
        SqlParameter[] para = new SqlParameter[6];
        para[0] = new SqlParameter("@name", SqlDbType.VarChar, 20);
        para[0].Value = name;
        para[1] = new SqlParameter("@provider", SqlDbType.VarChar, 30);
        para[1].Value = provider;
        para[2] = new SqlParameter("@texture", SqlDbType.VarChar, 20);
        para[2].Value = texture;
        para[3] = new SqlParameter("@level", SqlDbType.VarChar, 10);
        para[3].Value = level;
        para[4] = new SqlParameter("@note", SqlDbType.VarChar, 400);
        para[4].Value = note;
        para[5] = new SqlParameter("@id", SqlDbType.UniqueIdentifier);
        para[5].Value = id;


        int a = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_HSF", para);
        return a;
    }
        
    public DataSet QueryMaterial(string name, string provider)
    {

        SqlParameter[] para =
        {
            new SqlParameter("@name", SqlDbType.VarChar,40) {Value = name},
            new SqlParameter("@provider", SqlDbType.VarChar,40) {Value = provider}
         
        };
        if (name == "")
        {
            para[0].Value = null;
        }
        if (provider == "")
        {
            para[1].Value = null;
        }
        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_HSF", para);
        return ds;
    }

    public int InsertMaterial(string name, string provider, string texture, string level, string note)
    {
        SqlParameter[] para = new SqlParameter[5];
        para[0] = new SqlParameter("@name", SqlDbType.VarChar, 20);
        para[0].Value = name;
        para[1] = new SqlParameter("@provider", SqlDbType.VarChar, 30);
        para[1].Value = provider;
        para[2] = new SqlParameter("@texture", SqlDbType.VarChar,20);
        para[2].Value = texture;
        para[3] = new SqlParameter("@level", SqlDbType.VarChar, 10);
        para[3].Value =level;
        para[4] = new SqlParameter("@note", SqlDbType.VarChar, 400);
        para[4].Value = note;


        int a = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_HSF", para);
        return a;
    }

    public DataSet QueryDetail(Guid id)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@id", SqlDbType.UniqueIdentifier) {Value = id}
        
        };

        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_HSFBasic", para);
        return ds;
    }

    public int InsertDetail(Guid hsfGuid, Guid elementGuid,string man)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@hsfid", SqlDbType.UniqueIdentifier) {Value = hsfGuid},
             new SqlParameter("@eid", SqlDbType.UniqueIdentifier) {Value = elementGuid},
                new SqlParameter("@man", SqlDbType.VarChar,20) {Value = man }
        
        };

        int ds = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_HSFBasic", para);
        return ds;
    }

    public int DeleteDetai(Guid bid)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@bid", SqlDbType.UniqueIdentifier) {Value = bid},
        };

        int ds = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_HSFBasic", para);
        return ds;
    }

    public int CodyDetail(Guid hsfid, Guid hsfid2,string man)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@hsfid", SqlDbType.UniqueIdentifier) {Value = hsfid},
              new SqlParameter("@hsfid2", SqlDbType.UniqueIdentifier) {Value = hsfid2},
               new SqlParameter("@man", SqlDbType.VarChar,20) {Value = man},
        };

        int ds = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_HSFBasic_Copy", para);
        return ds;
    }

    public int DeleteHSF(Guid hsfid)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@hsfid", SqlDbType.UniqueIdentifier) {Value = hsfid},
           
        };
        int re = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_D_HSF", para);
        return re;
    }
}