using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using EquipmentMangementAjax.DBUtility;

public class PaymentWeekPlanD
{
    public DataSet QueryWeekPlan(int year, int month, string name)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@year", SqlDbType.SmallInt) {Value = year},
             new SqlParameter("@name", SqlDbType.VarChar,20) {Value = name},
            new SqlParameter("@month", SqlDbType.TinyInt) {Value = month}

          
        };
        if (year == 999)
            para[0].Value = null;
        if (month == 999)
            para[2].Value = null;
        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_PaymentWeekPlan", para);
        return ds;
    }

    public DataSet QueryWeekPlanDetail(Guid weekplanid)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@weekplanid", SqlDbType.UniqueIdentifier) {Value = weekplanid},
           


        };
        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_PaymentWeekPlanDetail", para);
        return ds;
    }

    public int InsertWeekPlan(int year, int month,int week, DateTime sdate, DateTime edate, string man, string note)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@year", SqlDbType.Int) {Value = year},
            new SqlParameter("@month", SqlDbType.Int) {Value = month},            
            new SqlParameter("@week", SqlDbType.Int) {Value = week},
            new SqlParameter("@sdate", SqlDbType.DateTime) {Value = sdate},
            new SqlParameter("@edate", SqlDbType.DateTime) {Value = edate},
            new SqlParameter("@man", SqlDbType.VarChar,20) {Value = man},
            new SqlParameter("@note", SqlDbType.VarChar,200) {Value = note},
        };
        int a = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_I_PaymentWeekPlan", para);
        return a;
    }

    public DataSet QueryMonthPlanInfo(int year,int month,int week)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@year", SqlDbType.Int) {Value = year},
            new SqlParameter("@month", SqlDbType.Int) {Value = month},
              new SqlParameter("@week", SqlDbType.Int) {Value = week},
           


        };
        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_PaymentMonthPlanDetailForWeekPlan", para);
        return ds;
    }

    public int InsertWeekPlanDetail(Guid monthPlanId, Guid pmsiid, string payway, decimal duepay, decimal planpay)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@mpid", SqlDbType.UniqueIdentifier) {Value = monthPlanId},
            new SqlParameter("@pmsiid", SqlDbType.UniqueIdentifier) {Value =pmsiid},
            new SqlParameter("@payway", SqlDbType.VarChar,20) {Value = payway},
            new SqlParameter("@duepay", SqlDbType.Decimal) {Value = duepay},
            new SqlParameter("@planpay", SqlDbType.Decimal) {Value = planpay},
          
        };
        int a = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_I_PaymentWeekPlanDetail", para);
        return a;
    }
    public int Insert_PaymentInfo(Guid id, decimal amount, int year,int month,int week, string man, string note)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@id", SqlDbType.UniqueIdentifier) {Value = id},
            new SqlParameter("@amount", SqlDbType.Decimal) {Value = amount},
            new SqlParameter("@year", SqlDbType.Int) {Value = year},
              new SqlParameter("@month", SqlDbType.Int) {Value = month},
                new SqlParameter("@week", SqlDbType.Int) {Value = week},
            new SqlParameter("@man", SqlDbType.VarChar,20) {Value = man},
            new SqlParameter("@note", SqlDbType.VarChar, 400) {Value = note},
        };


        int a = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_I_PMPaymentInfo", para);
        return a;
    }
    public int UpdatePaymentWeekPlanSum(Guid weekPlanId, decimal planpay)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@wpid", SqlDbType.UniqueIdentifier) {Value = weekPlanId},
            new SqlParameter("@planpay", SqlDbType.Decimal) {Value = planpay},
          
        };
        int a = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_U_PaymentWeekPlanSum", para);
        return a;
    }
    public int UpdatePaymentWeekPlanState(Guid weekPlanId,decimal total)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@wpid", SqlDbType.UniqueIdentifier) {Value = weekPlanId},
            new SqlParameter("@apay", SqlDbType.Decimal) {Value = total},
       
          
        };
        int a = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_U_PaymentWeekPlanState", para);
        return a;
    }

    public int DeleteWeekPlanDetail(Guid mpdid)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@id", SqlDbType.UniqueIdentifier) {Value = mpdid},
          };
        int a = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_D_PaymentWeekPlanDetail", para);
        return a;
    }

    public int DeleteWeekPlan(Guid mpid)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@id", SqlDbType.UniqueIdentifier) {Value = mpid},
         };
        int a = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_D_PaymentWeekPlan", para);
        return a;
    }

    public DataSet QueryPaymentInfoDetail(int year, int month, int week)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@year", SqlDbType.Int) {Value = year},
            new SqlParameter("@month", SqlDbType.Int) {Value = month},
              new SqlParameter("@week", SqlDbType.Int) {Value = week},
           


        };
        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_PaymentInfoDetail", para);
        return ds;
    }
}
