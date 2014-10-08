using System;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
/// PaymentBill 的摘要说明
/// </summary>
public class PaymentBill
{
	public PaymentBill()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}


    public DataSet Query_Bill(string name, int billnum)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@name", SqlDbType.VarChar, 100),
            new SqlParameter("@billnum", SqlDbType.Int)
        };
        para[0].Value = name;
        para[1].Value = billnum;
    
        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_Bill", para);
        return ds;
    }
    public DataSet Insert_BillDetail(Guid id, decimal amount, string billnum, string man, string note,DateTime str,DateTime end)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@id", SqlDbType.UniqueIdentifier) {Value = id},
            new SqlParameter("@amount", SqlDbType.Decimal) {Value = amount},
            new SqlParameter("@billnum", SqlDbType.VarChar, 200) {Value = billnum},
            new SqlParameter("@man", SqlDbType.VarChar,20) {Value = man},
            new SqlParameter("@note", SqlDbType.VarChar, 400) {Value = note},
              new SqlParameter("@str", SqlDbType.DateTime) {Value = str},
            new SqlParameter("@end", SqlDbType.DateTime) {Value = end}
        };


        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_I_BillDetail", para);
        return ds;
    }

    public DataSet Query_BillMain(Guid pid)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@pid", SqlDbType.UniqueIdentifier) {Value = pid},

        };
        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_BillMain", para);
        return ds;
    }

    public DataSet Query_BillDetail(Guid pmbid)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@pmbid", SqlDbType.UniqueIdentifier) {Value = pmbid},

        };
        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_BillDetail", para);
        return ds;
    }

    public DataSet Query_PurchaseOrderDetailNotBill(Guid pid)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@pid", SqlDbType.UniqueIdentifier) {Value = pid},

        };
        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_PurchaseOrderDetailNotBill", para);
        return ds;
    }

    public int SwitchState(Guid pdid)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@pdid", SqlDbType.UniqueIdentifier) {Value = pdid},

        };
    int   ds = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_U_PurchaseOrderDetail", para);
        return ds;
    }
}