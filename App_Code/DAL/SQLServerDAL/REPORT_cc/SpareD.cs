using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections;
using EquipmentMangementAjax.DBUtility;

/// <summary>
///SpareD 的摘要说明
/// </summary>
public class SpareD
{
	public SpareD()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    //查看备件领用统计表
    public DataSet S_EquipSpare_Statistical(string condition)
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 8000);
        para[0].Value = condition;
        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_EquipSpare_Statistical", para);
    }
    //受控文件各部门一览表
    public DataSet S_ControlledDocApp_Print(string condition)
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 8000);
        para[0].Value = condition;
        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_ControlledDocApp_Print", para);
    }
    //受控文件分发一览表
    public DataSet S_ControlledDocAppHandout_Print(string condition)
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 8000);
        para[0].Value = condition;
        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_ControlledDocAppHandout_Print", para);
    }
    //设备保养完成情况统计
    public DataSet S_EquipUpkeepPlan_Statistical(string condition1, string condition2)
    {
        SqlParameter[] para = new SqlParameter[2];
        para[0] = new SqlParameter("@condition1", SqlDbType.VarChar, 8000);
        para[0].Value = condition1;
        para[1] = new SqlParameter("@condition2", SqlDbType.VarChar, 8000);
        para[1].Value = condition2;
        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_EquipUpkeepPlan_Statistical", para);
    }
    //设备维修/停机情况统计时，选择/删除需统计的设备，并维护“待操作总时间、控制限”
    public void Update_EquipmentName_Statistics(Guid EN_ID, int EN_OperationTime, float EN_Limit)
    {
        SqlParameter[] parm = new SqlParameter[3];
        parm[0] = new SqlParameter("@EN_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = EN_ID;
        parm[1] = new SqlParameter("@EN_OperationTime", SqlDbType.Int);
        parm[1].Value = EN_OperationTime;
        parm[2] = new SqlParameter("@EN_Limit", SqlDbType.Float);
        parm[2].Value = EN_Limit;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_U_EquipmentName_Statistics", parm);
    }
    //设备台账故障停机统计
    public DataSet S_EquipMaintenance_Statistical(string condition,string time)
    {
        SqlParameter[] para = new SqlParameter[2];
        para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 8000);
        para[0].Value = condition;
        para[1] = new SqlParameter("@time", SqlDbType.VarChar, 8000);
        para[1].Value = time;
        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_EquipMaintenance_Statistical", para);
    }
    //设备故障停机统计总表
    public DataSet S_EquipMaintenance_TotalStatistical(string condition, string time)
    {
        SqlParameter[] para = new SqlParameter[2];
        para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 8000);
        para[0].Value = condition;
        para[1] = new SqlParameter("@time", SqlDbType.VarChar, 8000);
        para[1].Value = time;
        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_EquipMaintenance_TotalStatistical", para);
    }
    //设备产量统计时，选择/删除需统计的设备，并维护“小时理论产量、月工作全时间”
    public void Update_EquipmentName_Output(Guid EN_ID, float EN_Output, float EN_WorkTime)
    {
        SqlParameter[] parm = new SqlParameter[3];
        parm[0] = new SqlParameter("@EN_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = EN_ID;
        parm[1] = new SqlParameter("@EN_Output", SqlDbType.Float);
        parm[1].Value = EN_Output;
        parm[2] = new SqlParameter("@EN_WorkTime", SqlDbType.Float);
        parm[2].Value = EN_WorkTime;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_U_EquipmentName_Output", parm);
    }
    //设备产量统计
    public DataSet S_EquipOutput_Statistical(string condition, string time)
    {
        SqlParameter[] para = new SqlParameter[2];
        para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 8000);
        para[0].Value = condition;
        para[1] = new SqlParameter("@time", SqlDbType.VarChar, 8000);
        para[1].Value = time;
        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_EquipOutput_Statistical", para);
    }
    //实验数据统计表
    public DataSet S_ExpTest_Statistical(string condition)
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 8000);
        para[0].Value = condition;
        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_ExpTest_Statistical", para);
    }
    //设备维修率和停机率统计表
    public DataSet S_Equiptrend(string condition, string Year)
    {
        SqlParameter[] para = new SqlParameter[2];
        para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 8000);
        para[0].Value = condition;
        para[1] = new SqlParameter("@Year", SqlDbType.VarChar, 5000);
        para[1].Value = Year;
        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_Equiptrend", para);
    }
}