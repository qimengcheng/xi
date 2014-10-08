using System;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
///     LaputaPrintPool 的摘要说明
/// </summary>
public class LaputaPrintPoolD
{
    public DataSet Query_Material(string name, string model)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@name", SqlDbType.VarChar, 100),
            new SqlParameter("@model", SqlDbType.VarChar, 100)
        };
        para[0].Value = name;
        para[1].Value = model;


        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_PMPDetail_Mo", para);

        return ds;
    }

    public DataSet Query_ProType(string name, string code)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@name", SqlDbType.VarChar, 60),
            new SqlParameter("@code", SqlDbType.VarChar, 20)
        };
        para[0].Value = name;
        para[1].Value = code;


        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_LaputaReportPool_ProType", para);

        return ds;
    }

    public DataSet Query_StoreInfo(Guid mid, DateTime stime, DateTime etime)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@mid", SqlDbType.UniqueIdentifier) {Value = mid},
            new SqlParameter("@stime", SqlDbType.DateTime) {Value = stime},
            new SqlParameter("@etime", SqlDbType.DateTime) {Value = etime}
        };


        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_StoreInfo", para);

        return ds;
    }

    public DataSet Query_ProjectInfoProType(DateTime stime
        , DateTime etime)
    {
        SqlParameter[] para =
        {
        
            new SqlParameter("@stime", SqlDbType.DateTime) {Value = stime},
            new SqlParameter("@etime", SqlDbType.DateTime) {Value = etime}
        };


        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_ProjectReportProType", para);

        return ds;
    }
    public DataSet Query_ProjectInfoProSeries(DateTime stime
        , DateTime etime)
    {
        SqlParameter[] para =
        {
        
            new SqlParameter("@stime", SqlDbType.DateTime) {Value = stime},
            new SqlParameter("@etime", SqlDbType.DateTime) {Value = etime}
        };


        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_ProjectReportProSeries", para);

        return ds;
    }
    public DataSet Query_ProjectInfoProMainSeries(DateTime stime
        , DateTime etime)
    {
        SqlParameter[] para =
        {
        
            new SqlParameter("@stime", SqlDbType.DateTime) {Value = stime},
            new SqlParameter("@etime", SqlDbType.DateTime) {Value = etime}
        };


        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_ProjectReportProMainSeries", para);

        return ds;
    }

    public DataSet Query_ProjectInfoMaterial(DateTime stime, DateTime etime)
    {
        SqlParameter[] para =
        {
        
            new SqlParameter("@stime", SqlDbType.DateTime) {Value = stime},
            new SqlParameter("@etime", SqlDbType.DateTime) {Value = etime}
        };


        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_ProjectReportMaterial", para);

        return ds;
    }

    public SqlDataReader Query_ProjectReportMaterialBad(string bn,string mname,DateTime stime,DateTime etime)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@BN", SqlDbType.VarChar,30){Value = bn},
            new SqlParameter("@Mname", SqlDbType.VarChar,30){Value = mname},
             new SqlParameter("@stime", SqlDbType.DateTime) {Value = stime},
            new SqlParameter("@etime", SqlDbType.DateTime) {Value = etime}
        };
     
        SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_ProjectReportMaterialBad", para);
        return dr;
    }
    public SqlDataReader Query_QAReportSeriesBad(int year, int month, int day,string pbcname,string series,DateTime stime ,DateTime etime)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@year", SqlDbType.VarChar,30){Value = year},
            new SqlParameter("@month", SqlDbType.VarChar,30){Value = month},
             new SqlParameter("@day", SqlDbType.VarChar,30){Value = day},
            new SqlParameter("@Series", SqlDbType.VarChar,30){Value = series},
            new SqlParameter("@PBCName", SqlDbType.VarChar,30){Value = pbcname},
             new SqlParameter("@stime", SqlDbType.DateTime) {Value = stime},
            new SqlParameter("@etime", SqlDbType.DateTime) {Value = etime}
        };

        SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_QAReportBad", para);
        return dr;
    }
    public SqlDataReader Query_QAReportMainSeriesBad(int year, int month, int day, string pbcname,string mainseries, DateTime stime, DateTime etime)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@year", SqlDbType.VarChar,30){Value = year},
            new SqlParameter("@month", SqlDbType.VarChar,30){Value = month},
             new SqlParameter("@day", SqlDbType.VarChar,30){Value = day},
            new SqlParameter("@MainSeries", SqlDbType.VarChar,30){Value = mainseries},
           new SqlParameter("@PBCName", SqlDbType.VarChar,30){Value = pbcname},
             new SqlParameter("@stime", SqlDbType.DateTime) {Value = stime},
            new SqlParameter("@etime", SqlDbType.DateTime) {Value = etime}
        };

        SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_QAReportBad", para);
        return dr;
    }
    public DataSet Query_ProjectInfoEquipment(DateTime stime, DateTime etime)
    {
        SqlParameter[] para =
        {
        
            new SqlParameter("@stime", SqlDbType.DateTime) {Value = stime},
            new SqlParameter("@etime", SqlDbType.DateTime) {Value = etime}
        };


        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_ProjectReportEquipment", para);

        return ds;
    }

    public SqlDataReader Query_ProjectReportEquipmentBad(Guid eid, string mno,string pbcname,DateTime stime,DateTime etime)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@E_ID", SqlDbType.UniqueIdentifier){Value = eid},
            new SqlParameter("@mno", SqlDbType.VarChar,30){Value = mno},
                 new SqlParameter("@pbcname", SqlDbType.VarChar,30){Value = pbcname},
             new SqlParameter("@stime", SqlDbType.DateTime) {Value = stime},
            new SqlParameter("@etime", SqlDbType.DateTime) {Value = etime}
        };
        if (mno == "&nbsp;")
        {
            para[1].Value = null;
        }
        SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_ProjectReportEquipmentBad", para);
        return dr;
    }
    public DataSet Query_HSF(string name , string provider)
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
    public DataSet Query_HSFInfoReport(Guid hsfid, string type)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@hsfid", SqlDbType.UniqueIdentifier){Value = hsfid},
            new SqlParameter("@type", SqlDbType.VarChar,30){Value = type},
    
        };
    
       DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_HSFInfoReport", para);
        return ds;
    }

    public SqlDataReader Query_HSFInfoNet(Guid hsfid, string type)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@hsfid", SqlDbType.UniqueIdentifier){Value = hsfid},
            new SqlParameter("@type", SqlDbType.VarChar,30){Value = type},
    
        };

        SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_HSFInfoNet", para);
        return dr;
    }

    public object Query_SunMasterType(DateTime stime, DateTime etime)
    {
        SqlParameter[] para =
        {
        
            new SqlParameter("@stime", SqlDbType.DateTime) {Value = stime},
            new SqlParameter("@etime", SqlDbType.DateTime) {Value = etime}
        };


        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_SunMasterType", para);

        return ds;
    }
    public DataSet Query_SunMasterTypeMonthTrends()
    {
      
        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_SunMasterTypeAll", null);

        return ds;
    }
    public SqlDataReader Query_PS_Name()
    {

        SqlDataReader ds = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_PS_Name", null);

        return ds;
    }
    public SqlDataReader Query_PMS_Name(string psname)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@psname", SqlDbType.VarChar, 30) {Value = psname}
        };
        SqlDataReader ds = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_PMS_Name", para);

        return ds;
    }

    public DataSet Query_QASeries(DateTime stime, DateTime etime,string PS)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@stime", SqlDbType.DateTime) {Value = stime},
            new SqlParameter("@etime", SqlDbType.DateTime) {Value = etime},
            new SqlParameter("@Series", SqlDbType.VarChar,30) {Value = PS}
        };


        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_QASeries", para);

        return ds;
    }
    public DataSet Query_QAMainSeries(DateTime stime, DateTime etime, string PS,string PMS)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@stime", SqlDbType.DateTime) {Value = stime},
            new SqlParameter("@etime", SqlDbType.DateTime) {Value = etime},
            new SqlParameter("@Series", SqlDbType.VarChar,30) {Value = PS},
            new SqlParameter("@MainSeries", SqlDbType.VarChar,30) {Value = PMS}
        };


        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_QAMainSeries", para);

        return ds;
    }

    public DataSet Query_SunMasterAllYearSeries(string month)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@month", SqlDbType.Int) {Value =month}, 
        };


        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_SunMasterSeries", para);

        return ds;
    }
    public DataSet Query_SunMasterYearSeries(string year)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@year", SqlDbType.Int) {Value =year}, 
        };


        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_SunMasterSeries", para);

        return ds;
    }
    public DataSet Query_SunMasterMonthSeries(string month)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@month", SqlDbType.Int) {Value =month}, 
        };


        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_SunMasterSeries", para);

        return ds;
    }

    public DataSet Query_SunMasterYearMainSeries(string year)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@year", SqlDbType.Int) {Value =year}, 
        };


        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_SunMasterMainSeries", para);

        return ds;
    }
    public DataSet Query_SunMasterMonthMainSeries(string month)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@month", SqlDbType.Int) {Value =month}, 
        };


        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_SunMasterMainSeries", para);

        return ds;
    }
    public DataSet Query_SunMasterYear(string year)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@year", SqlDbType.Int) {Value =year}, 
        };


        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_SunMaster", para);

        return ds;
    }
    public DataSet Query_SunMasterMonth(string month)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@month", SqlDbType.Int) {Value =month}, 
        };


        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_SunMaster", para);

        return ds;
    }
    public DataSet PurchaseInfo(int year, int month)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@year", SqlDbType.VarChar,30) {Value = year},
           new SqlParameter("@month", SqlDbType.VarChar,30) {Value = month},


        };

        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_PurchaseInfo", para);
        return ds;
    }
}