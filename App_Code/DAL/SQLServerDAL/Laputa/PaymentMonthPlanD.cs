using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using EquipmentMangementAjax.DBUtility;

public class PaymentMonthPlanD
{
    public DataSet QueryMonthPlan(int year ,int month ,string name)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@year", SqlDbType.SmallInt) {Value = year},
             new SqlParameter("@name", SqlDbType.VarChar,20) {Value = name},
            new SqlParameter("@month", SqlDbType.TinyInt) {Value = month}

          
        };
        if (year== 999)
            para[0].Value = null;
        if (month == 999)
            para[2].Value = null;
        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_PaymentMonthPlan", para);
        return ds;
    }

    public DataSet QueryMonthPlanDetail(Guid monthplanid)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@monthplanid", SqlDbType.UniqueIdentifier) {Value = monthplanid},
           


        };
        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_PaymentMonthPlanDetail", para);
        return ds;
    }

    public int InsertMonthPlan(int year, int month, DateTime sdate, DateTime edate, string man,string note)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@year", SqlDbType.Int) {Value = year},
            new SqlParameter("@month", SqlDbType.Int) {Value = month},
            new SqlParameter("@sdate", SqlDbType.DateTime) {Value = sdate},
            new SqlParameter("@edate", SqlDbType.DateTime) {Value = edate},
            new SqlParameter("@man", SqlDbType.VarChar,20) {Value = man},
            new SqlParameter("@note", SqlDbType.VarChar,200) {Value = note},
        };
        int a = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_I_PaymentMonthPlan", para);
        return a;
    }

    public DataSet QueryPaymentInfo(string name)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@name", SqlDbType.VarChar,30) {Value = name},
           


        };
        if (
            name == "")
            para[0].Value = null;

        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_PurchasePoolInfo", para);
        return ds;
    }
    public DataSet PurchaseInfo(int year,int month)
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
    public DataSet QueryMonthPlanPool(DateTime now)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@now", SqlDbType.DateTime) {Value = now},
           


        };
        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_PaymentPlanPool", para);
        return ds;
    }

    public int InsertMonthPlanDetail(Guid monthPlanId, Guid pmsiid, string payway, decimal duepay, decimal planpay, decimal owe)
    { 
        SqlParameter[] para =
        {
            new SqlParameter("@mpid", SqlDbType.UniqueIdentifier) {Value = monthPlanId},
            new SqlParameter("@pmsiid", SqlDbType.UniqueIdentifier) {Value =pmsiid},
            new SqlParameter("@payway", SqlDbType.VarChar,20) {Value = payway},
            new SqlParameter("@duepay", SqlDbType.Decimal) {Value = duepay},
            new SqlParameter("@planpay", SqlDbType.Decimal) {Value = planpay},
              new SqlParameter("@owe", SqlDbType.Decimal) {Value = planpay},
          
        };
        int a = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_I_PaymentMonthPlanDetail", para);
        return a;
    }
    public int UpdatePaymentMonthPlanSum(Guid monthPlanId, decimal planpay)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@mpid", SqlDbType.UniqueIdentifier) {Value = monthPlanId},
            new SqlParameter("@planpay", SqlDbType.Decimal) {Value = planpay},
          
        };
        int a = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_U_PaymentMonthPlanSum", para);
        return a;
    }

    public int DeleteMonthPlanDetail(Guid mpdid)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@id", SqlDbType.UniqueIdentifier) {Value = mpdid},
          };
        int a = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_D_PaymentMonthPlanDetail", para);
        return a;
    }
}
