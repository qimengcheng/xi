using System;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
///CSUserD 的摘要说明
/// </summary>

public class CSUserD
{
    public CSUserD()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    public DataSet S_CSUser(string condition)//检索客户端操作员
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 1000);
        para[0].Value = condition;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_CSUser", para);

    }

    public DataSet S_CSUser_PBCraftInfo(Guid HRDD_ID)//检索客户端操作员可操作的工序
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@HRDD_ID", SqlDbType.UniqueIdentifier);
        para[0].Value = HRDD_ID;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_CSUser_PBCraftInfo", para);

    }

    public void I_CSUser_PBCraftInfo(Guid HRDD_ID, Guid PBC_ID)//插入客户端操作员可操作的工序
    {
        SqlParameter[] para = new SqlParameter[2];
        para[0] = new SqlParameter("@HRDD_ID", SqlDbType.UniqueIdentifier);
        para[0].Value = HRDD_ID;
        para[1] = new SqlParameter("@PBC_ID", SqlDbType.UniqueIdentifier);
        para[1].Value = PBC_ID;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_CSUser_PBCraftInfo", para);
    }

    public void I_CSUser(Guid HRDD_ID)//插入客户端操作员
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@HRDD_ID", SqlDbType.UniqueIdentifier);
        para[0].Value = HRDD_ID;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_CSUser", para);
    }

    public void D_CSUser(Guid HRDD_ID)//删除客户端操作员
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@HRDD_ID", SqlDbType.UniqueIdentifier);
        para[0].Value = HRDD_ID;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_CSUser", para);
    }
    public void D_CSUser_PBCraftInfo(Guid CSU_ID)//删除客户端操作员的可操作工序
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@CSU_ID", SqlDbType.UniqueIdentifier);
        para[0].Value = CSU_ID;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_CSUser_PBCraftInfo", para);
    }

    public DataSet S_CSUser_HRDD_Detail(string condition)//检索待选操作员
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 1000);
        para[0].Value = condition;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_CSUser_HRDD_Detail", para);

    }

    public DataSet S_CSUser_PBCName(Guid HRDD_ID)//检索待选工序
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@HRDD_ID", SqlDbType.UniqueIdentifier);
        para[0].Value = HRDD_ID;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_CSUser_PBCName", para);

    }
}
