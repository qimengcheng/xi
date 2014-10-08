using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using EquipmentMangementAjax.DBUtility;

/// <summary>
/// UserD 的摘要说明
/// </summary>
public class ProductPlanTrack
{
    public SqlDataReader Query_Organization()
    {
        

        SqlDataReader ds = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_BDOrganizationSheetAll", null);
        return ds;
    }



    public DataSet SearchProductWeek(DateTime stime, DateTime etime)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@stime", SqlDbType.Date),
            new SqlParameter("@etime", SqlDbType.Date), 
            //new SqlParameter("@dep", SqlDbType.UniqueIdentifier),
            //new SqlParameter("@dep", SqlDbType.UniqueIdentifier),
            //new SqlParameter("@del", SqlDbType.UniqueIdentifier)
        };
        para[0].Value = stime; 
        para[1].Value = etime;
        //para[2].Value = psGuid == Guid.Empty ? Guid.Empty : psGuid;
        //para[3].Value = pmsGuid == Guid.Empty ? Guid.Empty : pmsGuid;
        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_ProductTrackWeek", para);
        return ds;

    }
    public DataSet SearchProductSeries(Guid pwpGuid)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@pwp", SqlDbType.UniqueIdentifier),
            //new SqlParameter("@dep", SqlDbType.UniqueIdentifier),
            //new SqlParameter("@dep", SqlDbType.UniqueIdentifier),
            //new SqlParameter("@del", SqlDbType.UniqueIdentifier)
        };
        para[0].Value =  pwpGuid;
        //para[3].Value = pmsGuid == Guid.Empty ? Guid.Empty : pmsGuid;
        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_ProductTrackSeries", para);
        return ds;

    }
    public DataSet SearchProductMain( Guid pwpGuid)
    {
        SqlParameter[] para =   
        {
           
            new SqlParameter("@pwp", SqlDbType.UniqueIdentifier),
            //new SqlParameter("@dep", SqlDbType.UniqueIdentifier),
            //new SqlParameter("@del", SqlDbType.UniqueIdentifier)
        };
        para[0].Value =  pwpGuid;
        //para[3].Value = pmsGuid == Guid.Empty ? Guid.Empty : pmsGuid;
        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_ProductTrackMain", para);
        return ds;

    }
    public DataSet SearchProduct( Guid pwpGuid)
    {
        SqlParameter[] para =
        {
         
            new SqlParameter("@pwp", SqlDbType.UniqueIdentifier),
            //new SqlParameter("@dep", SqlDbType.UniqueIdentifier),
            //new SqlParameter("@del", SqlDbType.UniqueIdentifier)
        };
        para[0].Value = pwpGuid;
        //para[3].Value = pmsGuid == Guid.Empty ? Guid.Empty : pmsGuid;
        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_ProductTrack", para);
        return ds;

    }

    public DataSet SearchUser()
    {
        SqlParameter[] para =
        {
            new SqlParameter("@id", SqlDbType.VarChar, 50),
            new SqlParameter("@name", SqlDbType.VarChar, 50),
            new SqlParameter("@dep", SqlDbType.VarChar,60),
            new SqlParameter("@del", SqlDbType.Bit)
        };
        para[0].Value = null;
        para[1].Value = null;
        para[2].Value = null;
        para[3].Value = true;
        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_UMUserInfo", para);
        return ds;

    }

    public int InsertUser(string id, string name, string code)
    {
      

        SqlParameter[] para =
        {
            new SqlParameter("@id", SqlDbType.VarChar, 50),
             new SqlParameter("@name", SqlDbType.VarChar, 50),
              new SqlParameter("@dep", SqlDbType.VarChar, 60)
        };
        para[0].Value = id;
        para[1].Value = name;
        para[2].Value = code;


        int ds = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_I_UMUserInfo", para);

        return ds;


   

    }

    public int UpdateUser(string oldid, string newid, string name, string dep)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@id", SqlDbType.VarChar, 50),
             new SqlParameter("@newid", SqlDbType.VarChar, 50),
             new SqlParameter("@name", SqlDbType.VarChar, 50),
              new SqlParameter("@dep", SqlDbType.VarChar, 60)
        };
        para[0].Value = oldid; 
        para[1].Value = newid;
        para[2].Value = name;
        para[3].Value = dep;


        int ds = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_U_UMUserInfo", para);

        return ds;
    }

    public int ResetUser(string id)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@id", SqlDbType.VarChar, 50)
        };
        para[0].Value = id;


        int ds = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_U_UMUserInfo_Reset", para);

        return ds;
    }

    public DataSet GetRole(int num)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@id", SqlDbType.VarChar, 50)
        };
        para[0].Value = "Root"+num.ToString();
       
        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_UMUserInfo_Role", para);
        return ds;

       
    }

    public int UpdateRole(string id, string newrole)
    {
        SqlParameter[] para =
        {
           
             new SqlParameter("@id", SqlDbType.VarChar, 50),
             new SqlParameter("@newrole", SqlDbType.VarChar, 8000)
        };
        para[0].Value = id;
        para[1].Value = newrole;


        int ds = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_U_UMUserInfo_Role", para);

        return ds;
    }

    public int DeleteUser(string id)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@id", SqlDbType.VarChar, 50)
        };
        para[0].Value = id;


        int ds = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_D_UMUserInfo", para);

        return ds;
    }

     public int UpdatePassword(string id, string old, string newpassword)
     {
        SqlParameter[] para =
        {
           
             new SqlParameter("@id", SqlDbType.VarChar, 50),
             new SqlParameter("@old", SqlDbType.VarChar, 50),
             new SqlParameter("@new", SqlDbType.VarChar, 50),
        };
        para[0].Value = id;
        para[1].Value = old;
        para[2].Value = newpassword;



        int ds = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_U_UserPassword", para);

        return ds;
    }
     public string EncodingPassword(string password)
     {
         return FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");//"MD5"  
     }
}