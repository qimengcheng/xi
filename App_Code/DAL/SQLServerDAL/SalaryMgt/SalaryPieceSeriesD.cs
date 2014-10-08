using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections;
using EquipmentMangementAjax.DBUtility;

/// <summary>
///SalaryPieceSeriesD 的摘要说明
/// </summary>
public class SalaryPieceSeriesD
{
	public SalaryPieceSeriesD()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public void I_SalaryPieceworkSeries(string SPS_Name)
    {
        SqlParameter[] parm = new SqlParameter[1];
        parm[0] = new SqlParameter("@SPS_Name", SqlDbType.VarChar, 60);
        parm[0].Value = SPS_Name;
        EquipmentMangementAjax.DBUtility.SqlHelper.ExecuteNonQuery(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_SalaryPieceworkSeries", parm);
    }

    public DataSet S_SalaryPieceworkSeries(string SPS_Name)
    {
        SqlParameter[] parm = new SqlParameter[1];
        parm[0] = new SqlParameter("@SPS_Name", SqlDbType.VarChar, 60);
        parm[0].Value = SPS_Name;
        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_SalaryPieceworkSeries", parm);

    }
    public void U_SalaryPieceworkSeries(Guid SPS_ID, string SPS_Name)
    {
        SqlParameter[] parm = new SqlParameter[2];
        parm[0] = new SqlParameter("@SPS_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = SPS_ID;
        parm[1] = new SqlParameter("@SPS_Name", SqlDbType.VarChar, 60);
        parm[1].Value = SPS_Name;
        SqlHelper.ExecuteNonQuery(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
        CommandType.StoredProcedure, "Proc_U_SalaryPieceworkSeries", parm);
    }
    public int D_SalaryPieceworkSeries(Guid SPS_ID)
    {
        SqlParameter[] parm = new SqlParameter[1];
        parm[0] = new SqlParameter("@SPS_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = SPS_ID;
        return SqlHelper.ExecuteNonQuery(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
          CommandType.StoredProcedure, "Proc_D_SalaryPieceworkSeries", parm);
    }
    public DataSet SList_SalaryPieceworkSeries()
    {
        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_SList_SalaryPieceworkSeries", null);
    }

    public DataSet S_SalaryPieceworkSeries_Name(string SPS_Name)//检索特定产品系列名称的产品系列
    {
        SqlParameter[] parm = new SqlParameter[1];
        parm[0] = new SqlParameter("@SPS_Name", SqlDbType.VarChar, 60);
        parm[0].Value = SPS_Name;
        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_SalaryPieceworkSeries_Name", parm);
    }
    public void U_Protype_SalaryPieceworkSeries(Guid SPS_ID, Guid PT_ID)//为产品型号添加产品系列
    {
        SqlParameter[] parm = new SqlParameter[2];
        parm[0] = new SqlParameter("@SPS_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = SPS_ID;
        parm[1] = new SqlParameter("@PT_ID", SqlDbType.UniqueIdentifier);
        parm[1].Value = PT_ID;
        SqlHelper.ExecuteNonQuery(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
        CommandType.StoredProcedure, "Proc_U_Protype_SalaryPieceworkSeries", parm);
    }

    public void D_Protype_SalaryPieceworkSeries(Guid PT_ID)//删除产品型号的产品系列
    {
        SqlParameter[] parm = new SqlParameter[1];
        parm[0] = new SqlParameter("@PT_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = PT_ID;
        SqlHelper.ExecuteNonQuery(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
        CommandType.StoredProcedure, "Proc_D_Protype_SalaryPieceworkSeries", parm);
    }

    public DataSet S_SalaryPieceworkSeries_ProType(string condition)//查看一种产品系列所属产品型号
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@condition", SqlDbType.NVarChar, 2000);
        para[0].Value = condition;
        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_SalaryPieceworkSeries_ProType", para);
    }
    public DataSet S_Protype_SalaryPieceworkSeries_ForChose(string condition)//检索待选产品型号
    {
        SqlParameter[] parm = new SqlParameter[1];
        parm[0] = new SqlParameter("@condition", SqlDbType.VarChar, 1000);
        parm[0].Value = condition;
        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
          CommandType.StoredProcedure, "Proc_S_Protype_SalaryPieceworkSeries_ForChose", parm);
    }
}