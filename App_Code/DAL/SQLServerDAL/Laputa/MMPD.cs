using System;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
///     Class1 的摘要说明
/// </summary>
public class MMPD
{
    #region 增加

    public int Insert_PMPDetail(Guid id, Guid mid, decimal num)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@id", SqlDbType.UniqueIdentifier),
            new SqlParameter("@mid", SqlDbType.UniqueIdentifier),
            new SqlParameter("@num", SqlDbType.Decimal)
        };
        para[0].Value = id;
        para[1].Value = mid;
        para[2].Value = num;


        return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_I_PMPDetail_M", para);
    }


    public Guid Insert_PMP(Guid id, int year, int month, string man, string makedate, DateTime? startdate,
        DateTime? enddate, string type, int linenum)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@pmpid", SqlDbType.UniqueIdentifier),
            new SqlParameter("@id", SqlDbType.UniqueIdentifier),
            new SqlParameter("@year", SqlDbType.SmallInt),
            new SqlParameter("@month", SqlDbType.TinyInt),
            new SqlParameter("@man", SqlDbType.VarChar, 20),
            new SqlParameter("@makedate", SqlDbType.Date),
            new SqlParameter("@startdate", SqlDbType.Date),
            new SqlParameter("@enddate", SqlDbType.Date),
            new SqlParameter("@type", SqlDbType.Char, 2),
            new SqlParameter("@linenum", SqlDbType.Int)
        };
        para[0].Direction = ParameterDirection.Output;
        para[1].Value = id;
        para[2].Value = year;
        para[3].Value = month;
        para[4].Value = man;
        para[5].Value = makedate;
        para[6].Value = DBNull.Value;
        para[7].Value = DBNull.Value;
        para[8].Value = type;
        para[9].Value = linenum;
        Guid returnid = SqlHelper.ExecuteReturnGuidQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_I_PMP_M", para);
        return returnid;
    }

    public Guid Insert_PMP_add(Guid id, int year, int month, string man, string makedate, DateTime? startdate,
        DateTime? enddate, string type, int linenum)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@pmpid", SqlDbType.UniqueIdentifier),
            new SqlParameter("@id", SqlDbType.UniqueIdentifier),
            new SqlParameter("@year", SqlDbType.SmallInt),
            new SqlParameter("@month", SqlDbType.TinyInt),
            new SqlParameter("@man", SqlDbType.VarChar, 20),
            new SqlParameter("@makedate", SqlDbType.Date),
            new SqlParameter("@startdate", SqlDbType.Date),
            new SqlParameter("@enddate", SqlDbType.Date),
            new SqlParameter("@type", SqlDbType.Char, 2),
            new SqlParameter("@linenum", SqlDbType.Int)
        };
        para[0].Direction = ParameterDirection.Output;
        para[1].Value = id;
        para[2].Value = year;
        para[3].Value = month;
        para[4].Value = man;
        para[5].Value = makedate;
        para[6].Value = DBNull.Value;
        para[7].Value = DBNull.Value;
        para[8].Value = type;
        para[9].Value = linenum;
        Guid returnid = SqlHelper.ExecuteReturnGuidQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_I_PMP_M_ADD", para);
        return returnid;
    }

    #endregion

    #region  查询

    public PMPAudit Query_Audit(Guid id)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@PMP_ID", SqlDbType.UniqueIdentifier),
            new SqlParameter("@PMP_MFDepSignSuggestion", SqlDbType.VarChar, 400),
            new SqlParameter("@PMP_MFDepSignMan", SqlDbType.VarChar, 20),
            new SqlParameter("@PMP_MFDepSignTime", SqlDbType.DateTime),
            new SqlParameter("@PMP_MFDepSignResult", SqlDbType.VarChar, 20),
            new SqlParameter("@PMP_MBossSignSuggestion", SqlDbType.VarChar, 400),
            new SqlParameter("@PMP_MBossSignMan", SqlDbType.VarChar, 20),
            new SqlParameter("@PMP_MBossSignTime", SqlDbType.DateTime),
            new SqlParameter("@PMP_MBossSignResult", SqlDbType.VarChar, 20),
            new SqlParameter("@PMP_MPDepSignSuggestion", SqlDbType.VarChar, 400),
            new SqlParameter("@PMP_MPDepSignMan", SqlDbType.VarChar, 20),
            new SqlParameter("@PMP_MPDepSignTime", SqlDbType.DateTime),
            new SqlParameter("@PMP_MPDepSignResult", SqlDbType.VarChar, 20)
        };
        para[0].Value = id;
        para[1].Direction = ParameterDirection.Output;
        para[2].Direction = ParameterDirection.Output;
        para[3].Direction = ParameterDirection.Output;
        para[4].Direction = ParameterDirection.Output;
        para[5].Direction = ParameterDirection.Output;
        para[6].Direction = ParameterDirection.Output;
        para[7].Direction = ParameterDirection.Output;
        para[8].Direction = ParameterDirection.Output;
        para[9].Direction = ParameterDirection.Output;
        para[10].Direction = ParameterDirection.Output;
        para[11].Direction = ParameterDirection.Output;
        para[12].Direction = ParameterDirection.Output;
        PMPAudit au = SqlHelper.ExecuteReturnAuditQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_PMPAudit", para);
        return au;
    }


    public DataSet Query_MPlan(int year, int month, string state, int linenum)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@year", SqlDbType.Int),
            new SqlParameter("@month", SqlDbType.Int),
            new SqlParameter("@state", SqlDbType.VarChar, 30),
            new SqlParameter("@linenum", SqlDbType.Int)
        };
        if (year == 999)
        {
            para[0].Value = null;
        }
        else
        {
            para[0].Value = year;
        }
        if (month == 999)
        {
            para[1].Value = null;
        }
        else
        {
            para[1].Value = month;
        }
        if (state == "null")
        {
            para[2].Value = null;
        }
        else
        {
            para[2].Value = state;
        }
        para[3].Value = linenum;


        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_PMP_M", para);

        return ds;
    }

    public DataSet  Query_MPlan(int linenum)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@year", SqlDbType.SmallInt),
            new SqlParameter("@month", SqlDbType.TinyInt),
            new SqlParameter("@state", SqlDbType.VarChar, 30),
            new SqlParameter("@linenum", SqlDbType.Int)
        };
        para[0].Value = null;
        para[1].Value = null;
        para[2].Value = null;
        para[3].Value = linenum;


        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_PMP_M", para);

        return ds;
    }

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


    public DataSet Query_MPlanDetail(Guid id)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@id", SqlDbType.UniqueIdentifier)
        };
        para[0].Value = id;


        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_PMPDetail_M", para);

        return ds;
    }
    public DataSet Query_MPlanDetailFlash(Guid pmpid)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@id", SqlDbType.UniqueIdentifier)
        };
        para[0].Value = pmpid;


        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_PMPDetail_M_Flash", para);

        return ds;
    }

    public int CheckAddAvailable(int year, int month)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@count", SqlDbType.Int),
            new SqlParameter("@year", SqlDbType.SmallInt),
            new SqlParameter("@month", SqlDbType.TinyInt)
        };
        para[0].Direction = ParameterDirection.Output;
        para[1].Value = year;
        para[2].Value = month;


        int check = SqlHelper.ExecuteReturnQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_PMP_M_Pre", para);

        return check;
    }

    public DataSet Query_MPlanDetail_Type(int year, int month, Guid mid, Guid mmpid)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@year", SqlDbType.SmallInt),
            new SqlParameter("@month", SqlDbType.TinyInt),
            new SqlParameter("@mid", SqlDbType.UniqueIdentifier),
            new SqlParameter("@mmpid", SqlDbType.UniqueIdentifier)
        };
        para[0].Value = year;
        para[1].Value = month;
        para[2].Value = mid;
        para[3].Value = mmpid;


        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_PMP_M_Type", para);

        return ds;
    }

    #endregion

    #region 更新

    public int Update_PMP(Guid pmpid, DateTime startdate, DateTime enddate)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@PMP_ID", SqlDbType.UniqueIdentifier),
            new SqlParameter("@startdate", SqlDbType.Date),
            new SqlParameter("@enddate", SqlDbType.Date)
        };

        para[0].Value = pmpid;
        para[1].Value = startdate;
        para[2].Value = enddate;
        int flag = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_U_PMP_State_M", para);
        return flag;
    }

    public int UpdatePMPDetail(Guid pmpid, Guid mid, decimal num, string note)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@id", SqlDbType.UniqueIdentifier),
            new SqlParameter("@mid", SqlDbType.UniqueIdentifier),
            new SqlParameter("@num", SqlDbType.Decimal),
            new SqlParameter("@note", SqlDbType.VarChar, 400)
        };
        para[0].Value = pmpid;
        para[1].Value = mid;
        para[2].Value = num;
        para[3].Value = note;


        return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_U_PMPDetail_M", para);
    }

    public int Update_PMPAudit(Guid id, string man, DateTime time, string su, string res, string role)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@id", SqlDbType.UniqueIdentifier),
            new SqlParameter("@man", SqlDbType.VarChar, 20),
            new SqlParameter("@time", SqlDbType.DateTime),
            new SqlParameter("@su", SqlDbType.VarChar, 400),
            new SqlParameter("@res", SqlDbType.VarChar, 20),
            new SqlParameter("@role", SqlDbType.VarChar, 20)
        };
        para[0].Value = id;
        para[1].Value = man;
        para[2].Value = time;
        para[3].Value = su;
        para[4].Value = res;
        para[5].Value = role;


        return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_U_PMPAudit", para);
    }

    public int UpdatePlanState(Guid pmpid)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@id", SqlDbType.UniqueIdentifier)
        };

        para[0].Value = pmpid;

        int flag = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_U_SMSalesMonthPlanDetail_PlanState", para);
        return flag;
    }

    public int UpdatePlanState_New(Guid pmpid)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@id", SqlDbType.UniqueIdentifier)
        };

        para[0].Value = pmpid;

        int flag = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_U_SMSalesMonthPlanDetail_PlanState_New", para);
        return flag;
    }

    #endregion

    public int GetYear()
    {
        SqlParameter[] para =
        {
            new SqlParameter("@year", SqlDbType.Int)
        };

        para[0].Direction = ParameterDirection.Output;
        int flag = SqlHelper.ExecuteReturnQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_GetMYear", para);
        return flag;
    }

    
}