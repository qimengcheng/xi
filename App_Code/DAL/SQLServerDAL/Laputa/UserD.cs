using System.Data;
using System.Data.SqlClient;
using System.Web.Security;
using EquipmentMangementAjax.DBUtility;

/// <summary>
/// UserD 的摘要说明
/// </summary>
public class UserD
{
	public UserD()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    public SqlDataReader Query_Organization()
    {
        

        SqlDataReader ds = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_BDOrganizationSheetAll", null);
        return ds;
    }



    public DataSet SearchUser(string id, string name, string dep,int a,string role)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@id", SqlDbType.VarChar, 50),
            new SqlParameter("@name", SqlDbType.VarChar, 50),
            new SqlParameter("@dep", SqlDbType.VarChar,60),
            new SqlParameter("@del", SqlDbType.Bit),
            new SqlParameter("@role", SqlDbType.VarChar,50)
        };
        para[0].Value = id;
        para[1].Value = name;
        para[2].Value = dep =="null" ? null : dep;
        para[3].Value = a == 1 ? true : false;
        para[4].Value = role==""? null:role;
        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_UMUserInfo", para);
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

    public int InsertUser(string id, string name,string rtx, string code)
    {
      

        SqlParameter[] para =
        {
            new SqlParameter("@id", SqlDbType.VarChar, 50),
             new SqlParameter("@name", SqlDbType.VarChar, 50),
               new SqlParameter("@rtx", SqlDbType.VarChar, 50),
              new SqlParameter("@dep", SqlDbType.VarChar, 60)
        };
        para[0].Value = id;
        para[1].Value = name;
        para[2].Value = rtx;
        para[3].Value = code;


        int ds = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_I_UMUserInfo", para);

        return ds;


   

    }

    public int UpdateUser(string oldid, string newid, string name, string rtx, string dep)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@id", SqlDbType.VarChar, 50),
             new SqlParameter("@newid", SqlDbType.VarChar, 50),
             new SqlParameter("@name", SqlDbType.VarChar, 50),
             new SqlParameter("@rtx", SqlDbType.VarChar, 50),
              new SqlParameter("@dep", SqlDbType.VarChar, 60)
        };
        para[0].Value = oldid; 
        para[1].Value = newid;
        para[2].Value = name;
        para[3].Value = rtx;
        para[4].Value = dep;


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

    public string SelectRtxUserName(string name)
     {
         SqlParameter[] para =
        {
           
             new SqlParameter("@UserName", SqlDbType.VarChar, 64),
             new SqlParameter("@Name", SqlDbType.VarChar, 64)
        };
        para[0].Direction = ParameterDirection.Output;
         para[1].Value = name;
       



         string username= SqlHelper.ExecuteReturnQueryString(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
             "Proc_S_RTXUser", para);

         return username;
    }

    public int CopyRole(string id,string copyid)
    {
        SqlParameter[] para =
        {
           
             new SqlParameter("@id", SqlDbType.VarChar, 50),
             new SqlParameter("@copyid", SqlDbType.VarChar, 50),
        };
        para[0].Value = id;
        para[1].Value = copyid;
   

        int ds = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_U_UMUserInfo_Copy", para);

        return ds;
    }
}