using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections;
using EquipmentMangementAjax.DBUtility;
/// <summary>
///SalesD 的摘要说明
/// </summary>
public class SalesD
{
    public SalesD()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    //客户投诉汇总表
    public DataSet S_CustomerComplain(string condition)
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 8000);
        para[0].Value = condition;
        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_CustomerComplain", para);
    }
    //订单完成情况统计表
    public DataSet S_SalesOrderFinish(string condition)
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 8000);
        para[0].Value = condition;
        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_SalesOrderFinish", para);
    }
    //客户明细账-送货单
    public DataSet S_SMDetailReport_shd(string condition)
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 8000);
        para[0].Value = condition;
        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_SMDetailReport_shd", para);
    }
    //客户明细账-回款表
    public DataSet S_SMDetailReport_hkb(string condition)
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 8000);
        para[0].Value = condition;
        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_SMDetailReport_hkb", para);
    }
    //客户明细账-开票表
    public DataSet S_SMDetailReport_kpb(string condition)
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 8000);
        para[0].Value = condition;
        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_SMDetailReport_kpb", para);
    }
    //客户明细账-应收账款
    public DataSet S_SMDetailReport_yszk(string condition)
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 8000);
        para[0].Value = condition;
        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_SMDetailReport_yszk", para);
    }
    //销售分析表
    public DataSet S_CusSalesHistory(string condition, string Year)
    {
        SqlParameter[] para = new SqlParameter[2];
        para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 8000);
        para[0].Value = condition;
        para[1] = new SqlParameter("@Year", SqlDbType.VarChar, 4);
        para[1].Value = Year;
        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_CusSalesHistory", para);
    }
    //产品流量统计
    public DataSet S_ProductSum(DateTime start, DateTime end)
    {
        SqlParameter[] para = new SqlParameter[2];
        para[0] = new SqlParameter("@start", SqlDbType.Date);
        para[0].Value = start;
        para[1] = new SqlParameter("@end", SqlDbType.Date);
        para[1].Value = end;
        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_ProductSum", para);
    }
    //库存统计报表
    public DataSet S_TotalIM(DateTime start, DateTime end,string condition)
    {
        SqlParameter[] para = new SqlParameter[3];
        para[0] = new SqlParameter("@start", SqlDbType.Date);
        para[0].Value = start;
        para[1] = new SqlParameter("@end", SqlDbType.Date);
        para[1].Value = end;
        para[2] = new SqlParameter("@condition", SqlDbType.VarChar, 1000);
        para[2].Value = condition;
        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_TotalIM", para);
    }
    //销售业绩一览表
    public DataSet S_SalesPerformance(string no, string condition)
    {
        SqlParameter[] para = new SqlParameter[2];
        para[0] = new SqlParameter("@no", SqlDbType.VarChar, 10);
        para[0].Value = no;
        para[1] = new SqlParameter("@condition", SqlDbType.VarChar, 1000);
        para[1].Value = condition;
        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_SalesPerformance", para);
    }
    //人事异动报表
    public DataSet S_PersonnelChangeDetail(string condition)
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 8000);
        para[0].Value = condition;
        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_PersonnelChangeDetail", para);
    }
    //工人计件产量报表
    public DataSet S_Chanliang(string condition)
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 8000);
        para[0].Value = condition;
        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_Chanliang", para);
    }
    //人事调薪报表
    public DataSet S_PersonnelSalaryRecord(string condition)
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 8000);
        para[0].Value = condition;
        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_PersonnelSalaryRecord", para);
    }
    //每月薪资汇总表
    public DataSet S_SalaryDetailEachMonth(string condition)
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 8000);
        para[0].Value = condition;
        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_SalaryDetailEachMonth", para);
    }
    //年度中层管理干部绩效考核统计表
    public DataSet S_PerformceDetail(string condition)
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 8000);
        para[0].Value = condition;
        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_PerformceDetail", para);
    }
    //生产工序产量汇总表
    public DataSet S_WIP_CJCLB(string date1, string date2, string PBC_ID)
    {
        SqlParameter[] para = new SqlParameter[3];
        para[0] = new SqlParameter("@date1", SqlDbType.VarChar, 100);
        para[0].Value = date1;
        para[1] = new SqlParameter("@date2", SqlDbType.VarChar, 100);
        para[1].Value = date2;
        para[2] = new SqlParameter("@PBC_ID", SqlDbType.VarChar, 100);
        para[2].Value = PBC_ID;
        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_WIP_CJCLB", para);
    }
    //计件工价变动表
    public DataSet S_PieceChage(string condition)
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 8000);
        para[0].Value = condition;
        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_PieceChage", para);
    }
    //计时工价变动表
    public DataSet S_TimeChage(string condition)
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 8000);
        para[0].Value = condition;
        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_TimeChage", para);
    }
    //人员流失率年报表
    public DataSet S_QuitCountPercent(int year)
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@year", SqlDbType.Int);
        para[0].Value = year;
        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_QuitCountPercent", para);
    }
    //人员流失工龄年报表
    public DataSet S_QuitWorkAge(string year, string condition)
    {
        SqlParameter[] para = new SqlParameter[2];
        para[0] = new SqlParameter("@year", SqlDbType.VarChar, 20);
        para[0].Value = year;
        para[1] = new SqlParameter("@condition", SqlDbType.VarChar, 8000);
        para[1].Value = condition;
        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_QuitWorkAge", para);
    }
    //制程IPQC不良品汇总表
    public DataSet S_IPQCBad(string date1, string date2, string PBC_ID)
    {
        SqlParameter[] para = new SqlParameter[3];
        para[0] = new SqlParameter("@date1", SqlDbType.VarChar, 100);
        para[0].Value = date1;
        para[1] = new SqlParameter("@date2", SqlDbType.VarChar, 100);
        para[1].Value = date2;
        para[2] = new SqlParameter("@PBC_ID", SqlDbType.VarChar, 100);
        para[2].Value = PBC_ID;
        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Report_Proc_S_IPQCBad", para);
    }
    //不同规格不良品统计表
    public DataSet S_WIP_BadPro_BigType(string date1, string date2, string sj, string sx)
    {
        SqlParameter[] para = new SqlParameter[4];
        para[0] = new SqlParameter("@date1", SqlDbType.VarChar, 100);
        para[0].Value = date1;
        para[1] = new SqlParameter("@date2", SqlDbType.VarChar, 100);
        para[1].Value = date2;
        para[2] = new SqlParameter("@sj", SqlDbType.VarChar, 100);
        para[2].Value = sj;
        para[3] = new SqlParameter("@sx", SqlDbType.VarChar, 100);
        para[3].Value = sx;
        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Report_Proc_S_WIP_BadPro_BigType", para);
    }
    //不良品统计可统计的工序(工序下拉框)
    public DataSet S_PBCCraftInfo()
    {
        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "R_Proc_S_PBCCraftInfo");
    }
    //年度薪资分析表
    public DataSet S_SalaryCountIn12Months(string year, string condition)
    {
        SqlParameter[] para = new SqlParameter[2];
        para[0] = new SqlParameter("@year", SqlDbType.VarChar, 10);
        para[0].Value = year;
        para[1] = new SqlParameter("@condition", SqlDbType.VarChar, 100);
        para[1].Value = condition;
        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_SalaryCountIn12Months", para);
    }
    //财务部在制品统计表
    public void Insert_WIP_CWTJ(string CWPC_Man, string CWPC_Note)//新增统计记录
    {
        SqlParameter[] parm = new SqlParameter[2];
        parm[0] = new SqlParameter("@CWPC_Man", SqlDbType.VarChar, 20);
        parm[0].Value = CWPC_Man;
        parm[1] = new SqlParameter("@CWPC_Note", SqlDbType.VarChar, 1000);
        parm[1].Value = CWPC_Note;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "R_Proc_I_WIP_CWTJ", parm);
    }
    public DataSet S_WIP_CWTJ_CWPC_cc(string condition)//财务盘存表查询
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 2000);
        para[0].Value = condition;
        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "R_Proc_S_WIP_CWTJ_CWPC_cc", para);
    }
    public int Delete_WIP_CWTJ_CWPC_cc(Guid CWPC_ID)//财务盘存表删除
    {
        SqlParameter[] parm = new SqlParameter[1];
        parm[0] = new SqlParameter("@CWPC_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = CWPC_ID;
        return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "R_Proc_D_WIP_CWTJ_CWPC_cc", parm);
    }
    public void Update_WIP_CWTJ_CWPC_cc(Guid CWPC_ID, string CWPC_Note)//财务盘存表编辑
    {
        SqlParameter[] parm = new SqlParameter[2];
        parm[0] = new SqlParameter("@CWPC_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = CWPC_ID;
        parm[1] = new SqlParameter("@CWPC_Note", SqlDbType.VarChar, 1000);
        parm[1].Value = CWPC_Note;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "R_Proc_U_WIP_CWTJ_CWPC_cc", parm);
    }
    public DataSet S_WIP_CWTJ_CWPCD_cc(string condition)//财务盘存详细表查询
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 1000);
        para[0].Value = condition;
        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "R_Proc_S_WIP_CWTJ_CWPCD_cc", para);
    }
}