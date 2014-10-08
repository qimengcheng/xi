using System;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
/// OrganizationD 的摘要说明
/// </summary>
public class OrganizationD
{
    public DataSet Query_Organization(string name,int level)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@name", SqlDbType.VarChar, 100),
            new SqlParameter("@level", SqlDbType.TinyInt)
        };
        para[0].Value = name;
        if (level!=0)
        {
            para[1].Value = level;
        }
        else
        {
            para[1].Value = null;
        }
        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_BDOrganizationSheetMain", para);
        return ds;
    }

    public DataSet Query_Organization(string p)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@code", SqlDbType.VarChar,60)
        };
        para[0].Value = p;
   
        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_BDOrganizationSheetByCode", para);
        return ds;
    }

    public SqlDataReader Query_Organization(int level)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@level", SqlDbType.TinyInt)
        };
        para[0].Value = level;

        SqlDataReader ds = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_BDOrganizationSheetFather", para);
        return ds;
    }
    public int Insert_BD(string name,int level,string code)
    {

        SqlParameter[] para =
        {
            new SqlParameter("@name", SqlDbType.VarChar, 100),
             new SqlParameter("@level", SqlDbType.TinyInt),
              new SqlParameter("@code", SqlDbType.VarChar, 60),
        };
        para[0].Value = name;
        para[1].Value = level;
        para[2].Value = code;


        int ds = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_I_BDOrganizationSheetMain", para);

        return ds;


    }


    public int Update_BD(string code, string name, Int16 level, string father)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@name", SqlDbType.VarChar, 100),
             new SqlParameter("@level", SqlDbType.TinyInt),
              new SqlParameter("@father", SqlDbType.VarChar, 60),
              new SqlParameter("@code", SqlDbType.VarChar, 60),
        };
        para[0].Value = name;
        para[1].Value = level;
        para[2].Value = father;
        para[3].Value = code;



        int ds = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_U_BDOrganizationSheetMain", para);

        return ds;
    }

    public int DeleteOr(string code)
    {
        SqlParameter[] para =
        {
          
            new SqlParameter("@BDOS_Code", SqlDbType.VarChar, 60)
        };
     
        para[0].Value = code;



        int ds = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_D_BDOrganizationSheet", para);

        return ds;
    }
}