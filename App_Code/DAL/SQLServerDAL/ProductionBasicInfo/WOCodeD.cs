using System;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;
/// <summary>
///WOCodeD 的摘要说明
/// </summary>
public class WOCodeD
{
	public WOCodeD()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public void I_WorkOrderCode(string WOC_Name)
    {
        SqlParameter[] parm = new SqlParameter[1];
        parm[0] = new SqlParameter("@WOC_Name", SqlDbType.VarChar, 10);
        parm[0].Value = WOC_Name;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_WorkOrderCode", parm);
    }

    public DataSet S_WorkOrderCode(string WOC_Name)
    {
        SqlParameter[] parm = new SqlParameter[1];
        parm[0] = new SqlParameter("@WOC_Name", SqlDbType.VarChar, 10);
        parm[0].Value = WOC_Name;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_WorkOrderCode", parm);

    }
    public void U_WorkOrderCode(Guid WOC_ID, string WOC_Name)
    {
        SqlParameter[] parm = new SqlParameter[2];
        parm[0] = new SqlParameter("@WOC_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = WOC_ID;
        parm[1] = new SqlParameter("@WOC_Name", SqlDbType.VarChar, 10);
        parm[1].Value = WOC_Name;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
        CommandType.StoredProcedure, "Proc_U_WorkOrderCode", parm);
    }
    public int D_WorkOrderCode(Guid WOC_ID)
    {
        SqlParameter[] parm = new SqlParameter[1];
        parm[0] = new SqlParameter("@WOC_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = WOC_ID;
        return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
          CommandType.StoredProcedure, "Proc_D_WorkOrderCode", parm);
    }
    public DataSet SList_WorkOrderCode()
    {
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_SList_WorkOrderCode", null);
    }

    public DataSet S_WorkOrderCode_Name(string WOC_Name)
    {
        SqlParameter[] parm = new SqlParameter[1];
        parm[0] = new SqlParameter("@WOC_Name", SqlDbType.VarChar, 10);
        parm[0].Value = WOC_Name;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_WorkOrderCode_Name", parm);
    }
    public void U_Protype_WorkOrderCode(Guid WOC_ID, Guid PT_ID)
    {
        SqlParameter[] parm = new SqlParameter[2];
        parm[0] = new SqlParameter("@WOC_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = WOC_ID;
        parm[1] = new SqlParameter("@PT_ID", SqlDbType.UniqueIdentifier);
        parm[1].Value = PT_ID;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
        CommandType.StoredProcedure, "Proc_U_Protype_WorkOrderCode", parm);
    }

    public void D_Protype_WorkOrderCode(Guid PT_ID)
    {
        SqlParameter[] parm = new SqlParameter[1];
        parm[0] = new SqlParameter("@PT_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = PT_ID;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
        CommandType.StoredProcedure, "Proc_D_Protype_WorkOrderCode", parm);
    }

    public DataSet S_WorkOrderCode_ProType(string condition)
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@condition", SqlDbType.NVarChar, 2000);
        para[0].Value = condition;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_WorkOrderCode_ProType", para);
    }
    public DataSet S_Protype_WorkOrderCode_ForChose(string condition)
    {
        SqlParameter[] parm = new SqlParameter[1];
        parm[0] = new SqlParameter("@condition", SqlDbType.VarChar, 1000);
        parm[0].Value = condition;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
          CommandType.StoredProcedure, "Proc_S_Protype_WorkOrderCode_ForChose", parm);
    }
}