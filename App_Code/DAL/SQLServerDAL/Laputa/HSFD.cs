using System;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
///     HSFD 的摘要说明
/// </summary>
public class HSFD
{
    public DataSet QueryVersion(Guid hsfid)
    {
        SqlParameter[] para = {new SqlParameter("@hsfid", SqlDbType.UniqueIdentifier) {Value = hsfid}};
        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_HSFVersion", para);
        return ds;
    }

    public int InsertVersion(Guid hsfid, string name, string man, string note)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@hsfid", SqlDbType.UniqueIdentifier) {Value = hsfid},
            new SqlParameter("@name", SqlDbType.VarChar, 30) {Value = name},
            new SqlParameter("@man", SqlDbType.VarChar, 20) {Value = man},
            new SqlParameter("@note", SqlDbType.VarChar, 400) {Value = note}
        };
        int re = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_I_HSFVersion", para);
        return re;
    }

    public int InsertReport(Guid vid, string num, string ins, DateTime dateTime, String url, string type , string note, string man)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@vid", SqlDbType.UniqueIdentifier) {Value = vid},
            new SqlParameter("@num", SqlDbType.VarChar, 20) {Value = num},
            new SqlParameter("@date", SqlDbType.Date) {Value = dateTime},
            new SqlParameter("@organization", SqlDbType.VarChar, 30) {Value = ins},
            new SqlParameter("@url", SqlDbType.VarChar, 100) {Value = url},
            new SqlParameter("@type", SqlDbType.VarChar, 20) {Value = type},
             new SqlParameter("@note", SqlDbType.VarChar, 200) {Value = note},
            new SqlParameter("@man", SqlDbType.VarChar, 20) {Value = man}
        };
        int re = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_I_HSFReport", para);
        return re;
    }

    public DataSet QueryReport(Guid vid)
    {
        SqlParameter[] para = {new SqlParameter("@vid", SqlDbType.UniqueIdentifier) {Value = vid}};
        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_HSFReport", para);
        return ds;
    }

    public DataSet QueryDetail(Guid versionGuid, Guid reportGuid)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@reportid", SqlDbType.UniqueIdentifier) {Value = reportGuid},
            new SqlParameter("@vid", SqlDbType.UniqueIdentifier) {Value = versionGuid}

          
        };
        if (reportGuid == Guid.Empty)
            para[0].Value = null;
        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_HSFDetail", para);
        return ds;
    }

    public int InsertDetail(Guid detailid,Guid reportGuid, string amount, string man, string note)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@detailid", SqlDbType.UniqueIdentifier) {Value = detailid},
            new SqlParameter("@reportid", SqlDbType.UniqueIdentifier) {Value = reportGuid},
        
       
            new SqlParameter("@net", SqlDbType.Decimal) {Value = amount},
            new SqlParameter("@note", SqlDbType.VarChar, 200) {Value = note},
            new SqlParameter("@man", SqlDbType.VarChar, 20) {Value = man}
        };
        int re = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_U_HSFDetail", para);
        return re;
    }

    public DataSet QueryDetailAI(Guid hsfid)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@hsfid", SqlDbType.UniqueIdentifier) {Value = hsfid},
        
        };
      
        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_HSFDetail_AI", para);
        return ds;
    }

    public int UpdateReport(Guid reportid, string num, string ins, DateTime dateTime, string url, string type, string note, string man)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@reportid", SqlDbType.UniqueIdentifier) {Value = reportid},
            new SqlParameter("@num", SqlDbType.VarChar, 20) {Value = num},
            new SqlParameter("@date", SqlDbType.Date) {Value = dateTime},
            new SqlParameter("@organization", SqlDbType.VarChar, 30) {Value = ins},
            new SqlParameter("@url", SqlDbType.VarChar, 100) {Value = url},
         
               new SqlParameter("@type", SqlDbType.VarChar, 20) {Value = type},
                  new SqlParameter("@note", SqlDbType.VarChar, 200) {Value = note},
            new SqlParameter("@man", SqlDbType.VarChar, 20) {Value = man}
        };
        int re = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_U_HSFReport", para);
        return re;
    }

    public int UpdateVersion(Guid vid, string name, string man, string note)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@vid", SqlDbType.UniqueIdentifier) {Value = vid},
            new SqlParameter("@name", SqlDbType.VarChar, 30) {Value = name},
            new SqlParameter("@man", SqlDbType.VarChar, 20) {Value = man},
            new SqlParameter("@note", SqlDbType.VarChar, 400) {Value = note}
        };
        int re = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_U_HSFVersion", para);
        return re;
    }

    public DataSet QueryReportDue(string name, string provider, string reportnum)
    {
        SqlParameter[] para =
        {
          
            new SqlParameter("@name", SqlDbType.VarChar, 30) {Value = name},
            new SqlParameter("@provider", SqlDbType.VarChar, 20) {Value = provider},
            new SqlParameter("@reportnum", SqlDbType.VarChar, 400) {Value = reportnum}
        };
        DataSet ds
 = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_HSFReportDue", para);
        return ds;
    }

    public int DeleteVersion(Guid vid)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@vid", SqlDbType.UniqueIdentifier) {Value = vid},
           
        };
        int re = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_D_HSFVersion", para);
        return re;
    }
    public int DeleteReport(Guid rid)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@rid", SqlDbType.UniqueIdentifier) {Value = rid},
           
        };
        int re = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_D_HSFReport", para);
        return re;
    }

    public int CopyReport(Guid versionGuid,Guid reportidGuid,string man)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@vid", SqlDbType.UniqueIdentifier) {Value = versionGuid},
             new SqlParameter("@rid", SqlDbType.UniqueIdentifier) {Value = reportidGuid},
              new SqlParameter("@man", SqlDbType.VarChar,20) {Value = man},
           
        };
        int re = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_I_HSFReport_Copy", para);
        return re;
    }
}