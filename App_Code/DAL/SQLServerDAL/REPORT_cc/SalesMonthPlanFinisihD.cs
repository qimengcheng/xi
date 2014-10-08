using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;
/// <summary>
/// SalesMonthPlanFinisihD 的摘要说明
/// </summary>
public class SalesMonthPlanFinisihD
{
    public DataSet SelectSalesMonthPlanFinisih(string year,string month)
    {
        SqlParameter[] parm = new SqlParameter[2];

        parm[0] = new SqlParameter("@year", SqlDbType.VarChar, 10);
        parm[0].Value = year;
        parm[1] = new SqlParameter("@month", SqlDbType.VarChar,10);
        parm[1].Value = month;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_SalesMonthPlanFinisih", parm);
    }
    public DataSet Select_SXJ_BLPLX(string date1,string date2)
    {
        SqlParameter[] parm = new SqlParameter[2];

        parm[0] = new SqlParameter("@date1", SqlDbType.VarChar, 100);
        parm[0].Value = date1;
        parm[1] = new SqlParameter("@date2", SqlDbType.VarChar, 100);
        parm[1].Value = date2;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_SXJ_BLPLX", parm);
    }
    public DataSet Select_HRMan(string condition, int sort)
    {
        SqlParameter[] parm = new SqlParameter[2];

        parm[0] = new SqlParameter("@Condition", SqlDbType.VarChar, 1000);
        parm[0].Value = condition;
        parm[1] = new SqlParameter("@sort", SqlDbType.Int);
        parm[1].Value = sort;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_PeopleCountEachSex", parm);
    }
}