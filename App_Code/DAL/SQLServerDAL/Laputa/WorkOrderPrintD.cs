using System;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
/// WorkOrderPrint 的摘要说明
/// </summary>
public class WorkOrderPrintD
{
	public WorkOrderPrintD()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    public SqlDataReader Query_BatchNum(string name)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@wonum", SqlDbType.VarChar, 30)
        };
        para[0].Value = name;
        SqlDataReader ds = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_Print_WOMBatchNum", para);
        return ds;
    }

    public DataSet Query_PBCraftInfo(string name, int isrenzheng)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@wonum", SqlDbType.VarChar, 30),
            new SqlParameter("@isrenzheng", SqlDbType.Int)
        };
        para[0].Value = name;
        para[1].Value = isrenzheng;
        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_Print_PBCraftInfo", para);
        return ds;
    }

    public DataSet Query_PrintInfo(string name)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@wonum", SqlDbType.VarChar, 30)
        };
        para[0].Value = name;
        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_Print_WorkOrderInfo", para);
        return ds;
    }

    public DataSet Query_Image(string name)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@ProType_Name", SqlDbType.VarChar, 50)
        };
        para[0].Value = name;
        DataSet ds = SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_TemplateUpload_ShowImage", para);
        return ds;
    }

    public SqlDataReader Query_BBT(Guid pbcid)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@pbcid", SqlDbType.UniqueIdentifier)
        };
        para[0].Value = pbcid;
        SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_BPT", para);
        return dr;
    }

    public SqlDataReader Query_BBT2(Guid pbcid,string wonum)
    {
        SqlParameter[] para =
        {
            new SqlParameter("@pbcid", SqlDbType.UniqueIdentifier),
            new SqlParameter("@WO_Num", SqlDbType.VarChar,30)
        };
        para[0].Value = pbcid;
        para[1].Value = wonum;
        SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
            "Proc_S_BPT2", para);
        return dr;
    }
}