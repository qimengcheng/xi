using System;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
/// WSD 的摘要说明
/// </summary>
public class WSD
{
    public WSD()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    public DataSet S_TimeNoUnfixedTable(string condition)//显示生产无关非固定计时主表
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 6000);
        para[0].Value = condition;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_TimeNoUnfixedTable", para);

    }

    public DataSet S_TimeNoFixedTable(string condition)//显示生产无关固定计时主表
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 6000);
        para[0].Value = condition;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_TimeNoFixedTable", para);

    }

    public DataSet S_TimeNoUnfixedDetail(string TNUT_ID, string condition)//显示生产无关非固定计时详细表
    {
        SqlParameter[] para = new SqlParameter[2];
        para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 1000);
        para[0].Value = condition;
        para[1] = new SqlParameter("@TNUT_ID", SqlDbType.VarChar, 100);
        para[1].Value = TNUT_ID;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_TimeNoUnfixedDetail", para);

    }

    public DataSet S_TimeNoFixedDetail(string TNUT_ID, string condition)//显示生产无关固定计时详细表
    {
        SqlParameter[] para = new SqlParameter[2];
        para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 1000);
        para[0].Value = condition;
        para[1] = new SqlParameter("@TNUT_ID", SqlDbType.VarChar, 100);
        para[1].Value = TNUT_ID;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_TimeNoFixedDetail", para);

    }

    public void I_TimeNoUnfixedTable(Guid TI_ID, DateTime TNUT_Date, string TNUT_SubmitMan, string TNUT_Department)//插入生产无关非固定计时主表
    {
        SqlParameter[] para = new SqlParameter[4];
        para[0] = new SqlParameter("@TI_ID", SqlDbType.UniqueIdentifier);
        para[0].Value = TI_ID;
        para[1] = new SqlParameter("@TNUT_Date", SqlDbType.Date);
        para[1].Value = TNUT_Date;
        para[2] = new SqlParameter("@TNUT_SubmitMan", SqlDbType.VarChar, 20);
        para[2].Value = TNUT_SubmitMan;
        para[3] = new SqlParameter("@TNUT_Department", SqlDbType.VarChar, 60);
        para[3].Value = TNUT_Department;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_I_TimeNoUnfixedTable", para);

    }

    public void I_TimeNoFixedTable(Guid TI_ID, DateTime TNUT_Date, string TNUT_SubmitMan, string TNUT_Department)//插入生产无关固定计时主表
    {
        SqlParameter[] para = new SqlParameter[4];
        para[0] = new SqlParameter("@TI_ID", SqlDbType.UniqueIdentifier);
        para[0].Value = TI_ID;
        para[1] = new SqlParameter("@TNUT_Date", SqlDbType.Date);
        para[1].Value = TNUT_Date;
        para[2] = new SqlParameter("@TNUT_SubmitMan", SqlDbType.VarChar, 20);
        para[2].Value = TNUT_SubmitMan;
        para[3] = new SqlParameter("@TNUT_Department", SqlDbType.VarChar, 60);
        para[3].Value = TNUT_Department;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_I_TimeNoFixedTable", para);

    }

    public void U_TimeNoUnfixedTable(Guid TNUT_ID, Guid TI_ID, DateTime TNUT_Date, string TNUT_SubmitMan, string TNUT_Department)//编辑生产无关非固定计时主表
    {
        SqlParameter[] para = new SqlParameter[5];
        para[0] = new SqlParameter("@TI_ID", SqlDbType.UniqueIdentifier);
        para[0].Value = TI_ID;
        para[1] = new SqlParameter("@TNUT_Date", SqlDbType.Date);
        para[1].Value = TNUT_Date;
        para[2] = new SqlParameter("@TNUT_SubmitMan", SqlDbType.VarChar, 20);
        para[2].Value = TNUT_SubmitMan;
        para[3] = new SqlParameter("@TNUT_Department", SqlDbType.VarChar, 60);
        para[3].Value = TNUT_Department;
        para[4] = new SqlParameter("@TNUT_ID", SqlDbType.UniqueIdentifier);
        para[4].Value = TNUT_ID;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_U_TimeNoUnfixedTable", para);

    }

    public void U_TimeNoFixedTable(Guid TNUT_ID, Guid TI_ID, DateTime TNUT_Date, string TNUT_SubmitMan, string TNUT_Department)//编辑生产无关固定计时主表
    {
        SqlParameter[] para = new SqlParameter[5];
        para[0] = new SqlParameter("@TI_ID", SqlDbType.UniqueIdentifier);
        para[0].Value = TI_ID;
        para[1] = new SqlParameter("@TNUT_Date", SqlDbType.Date);
        para[1].Value = TNUT_Date;
        para[2] = new SqlParameter("@TNUT_SubmitMan", SqlDbType.VarChar, 20);
        para[2].Value = TNUT_SubmitMan;
        para[3] = new SqlParameter("@TNUT_Department", SqlDbType.VarChar, 60);
        para[3].Value = TNUT_Department;
        para[4] = new SqlParameter("@TNUT_ID", SqlDbType.UniqueIdentifier);
        para[4].Value = TNUT_ID;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_U_TimeNoFixedTable", para);

    }

    public void D_TimeNoUnfixedTable(Guid TNUT_ID)//删除生产无关非固定计时主表
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@TNUT_ID", SqlDbType.UniqueIdentifier);
        para[0].Value = TNUT_ID;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_D_TimeNoUnfixedTable", para);

    }

    public void D_TimeNoFixedTable(Guid TNUT_ID)//删除生产无关固定计时主表
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@TNUT_ID", SqlDbType.UniqueIdentifier);
        para[0].Value = TNUT_ID;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_D_TimeNoFixedTable", para);

    }

    public void D_TimeNoUnfixedDetail(Guid TNUD_ID)//删除生产无关非固定计时详细表
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@TNUD_ID", SqlDbType.UniqueIdentifier);
        para[0].Value = TNUD_ID;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_D_TimeNoUnfixedDetail", para);

    }

    public void D_TimeNoFixedDetail(Guid TNUD_ID)//删除生产无关固定计时详细表
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@TNUD_ID", SqlDbType.UniqueIdentifier);
        para[0].Value = TNUD_ID;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_D_TimeNoFixedDetail", para);

    }

    public void U_TimeNoUnfixedDetail_Review(Guid TNUT_ID, string man, string suggs, string res, int type)//审核生产无关非固定计时详细表
    {
        SqlParameter[] para = new SqlParameter[5];
        para[0] = new SqlParameter("@suggs", SqlDbType.VarChar, 400);
        para[0].Value = suggs;
        para[1] = new SqlParameter("@man", SqlDbType.VarChar, 20);
        para[1].Value = man;
        para[2] = new SqlParameter("@res", SqlDbType.VarChar, 20);
        para[2].Value = res;
        para[3] = new SqlParameter("@type", SqlDbType.Int);
        para[3].Value = type;
        para[4] = new SqlParameter("@TNUT_ID", SqlDbType.UniqueIdentifier);
        para[4].Value = TNUT_ID;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_U_TimeNoUnfixedDetail_Review", para);

    }
    public void U_TimeNoFixedTable_Review(Guid TNUT_ID, string man, string suggs, string res, int type)//审核生产无关固定计时表
    {
        SqlParameter[] para = new SqlParameter[5];
        para[0] = new SqlParameter("@suggs", SqlDbType.VarChar, 400);
        para[0].Value = suggs;
        para[1] = new SqlParameter("@man", SqlDbType.VarChar, 20);
        para[1].Value = man;
        para[2] = new SqlParameter("@res", SqlDbType.VarChar, 20);
        para[2].Value = res;
        para[3] = new SqlParameter("@type", SqlDbType.Int);
        para[3].Value = type;
        para[4] = new SqlParameter("@TNUT_ID", SqlDbType.UniqueIdentifier);
        para[4].Value = TNUT_ID;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_U_TimeNoFixedTable_Review", para);

    }

    public void I_TimeNoUnfixedDetail(Guid TNUT_ID, Guid HRDD_ID)//新增生产无关非固定计时详细表
    {
        SqlParameter[] para = new SqlParameter[2];
        para[0] = new SqlParameter("@TNUT_ID", SqlDbType.UniqueIdentifier);
        para[0].Value = TNUT_ID;
        para[1] = new SqlParameter("@HRDD_ID", SqlDbType.UniqueIdentifier);
        para[1].Value = HRDD_ID;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_I_TimeNoUnfixedDetail", para);

    }

    public void I_TimeNoFixedDetail(Guid TNUT_ID, Guid HRDD_ID)//新增生产无关固定计时详细表
    {
        SqlParameter[] para = new SqlParameter[2];
        para[0] = new SqlParameter("@TNUT_ID", SqlDbType.UniqueIdentifier);
        para[0].Value = TNUT_ID;
        para[1] = new SqlParameter("@HRDD_ID", SqlDbType.UniqueIdentifier);
        para[1].Value = HRDD_ID;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_I_TimeNoFixedDetail", para);

    }

    public void U_TimeNoUnfixedDetail(Guid TNUD_ID, decimal TNUD_TimeLength, int TNUD_Num)//编辑生产无关非固定计时详细表
    {
        SqlParameter[] para = new SqlParameter[3];
        para[0] = new SqlParameter("@TNUD_ID", SqlDbType.UniqueIdentifier);
        para[0].Value = TNUD_ID;
        para[1] = new SqlParameter("@TNUD_TimeLength", SqlDbType.Decimal);
        para[1].Value = TNUD_TimeLength;
        para[2] = new SqlParameter("@TNUD_Num", SqlDbType.Int);
        para[2].Value = TNUD_Num;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_U_TimeNoUnfixedDetail", para);

    }
    public void U_TimeNoFixedDetail(Guid TNUD_ID, decimal TNUD_TimeLength, int TNUD_Num,string note)//编辑生产无关非固定计时详细表
    {
        SqlParameter[] para = new SqlParameter[4];
        para[0] = new SqlParameter("@TNUD_ID", SqlDbType.UniqueIdentifier);
        para[0].Value = TNUD_ID;
        para[1] = new SqlParameter("@TNUD_TimeLength", SqlDbType.Decimal);
        para[1].Value = TNUD_TimeLength;
        para[2] = new SqlParameter("@TNUD_Num", SqlDbType.Int);
        para[2].Value = TNUD_Num;
        para[3] = new SqlParameter("@TNUD_Note", SqlDbType.VarChar,200);
        para[3].Value = note;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_U_TimeNoFixedDetail", para);

    }

    public void U_TimeNoUnfixedTable_tj(Guid TNUT_ID)//提交生产无关非固定计时详细表
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@TNUT_ID", SqlDbType.UniqueIdentifier);
        para[0].Value = TNUT_ID;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_U_TimeNoUnfixedTable_tj", para);

    }

    public void U_TimeNoFixedTable_tj(Guid TNUT_ID)//提交生产无关固定计时详细表
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@TNUT_ID", SqlDbType.UniqueIdentifier);
        para[0].Value = TNUT_ID;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_U_TimeNoFixedTable_tj", para);

    }

    public DataSet S_JJXMSH(string condition)//显示计件项目审核主表
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 6000);
        para[0].Value = condition;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_JJXMSH", para);

    }
    public DataSet S_JJXMSH_ZP(string condition)//显示计件项目审核主表
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 6000);
        para[0].Value = condition;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_JJXMSH_ZP", para);

    }


    public DataSet S_JJXMSH_Detail(string SPI_ID, string date, string condition)//显示计件项目审核详细表
    {
        SqlParameter[] para = new SqlParameter[3];
        para[0] = new SqlParameter("@SPI_ID", SqlDbType.VarChar, 100);
        para[0].Value = SPI_ID;
        para[1] = new SqlParameter("@date", SqlDbType.VarChar, 100);
        para[1].Value = date;
        para[2] = new SqlParameter("@condition", SqlDbType.VarChar, 6000);
        para[2].Value = condition;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_JJXMSH_Detail", para);

    }

    public DataSet S_JSXMSH_Detail(string SPI_ID, string date, string condition)//显示计时项目审核详细表
    {
        SqlParameter[] para = new SqlParameter[3];
        para[0] = new SqlParameter("@SPI_ID", SqlDbType.VarChar, 100);
        para[0].Value = SPI_ID;
        para[1] = new SqlParameter("@date", SqlDbType.VarChar, 100);
        para[1].Value = date;
        para[2] = new SqlParameter("@condition", SqlDbType.VarChar, 6000);
        para[2].Value = condition;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_JSXMSH_Detail", para);

    }

    public DataSet S_JJXMSH_Detail_ZP(string SPI_ID, string date, string condition)//显示装配计件项目审核详细表
    {
        SqlParameter[] para = new SqlParameter[3];
        para[0] = new SqlParameter("@SPI_ID", SqlDbType.VarChar, 100);
        para[0].Value = SPI_ID;
        para[1] = new SqlParameter("@date", SqlDbType.VarChar, 100);
        para[1].Value = date;
        para[2] = new SqlParameter("@condition", SqlDbType.VarChar, 6000);
        para[2].Value = condition;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_JJXMSH_Detail_ZP", para);

    }

    public void U_PieceAudit(Guid PA_ID, string PA_RMan, string PA_Suggestion, string PA_RResult)//修改计件项目审核主表
    {
        SqlParameter[] para = new SqlParameter[4];
        para[0] = new SqlParameter("@PA_ID", SqlDbType.UniqueIdentifier);
        para[0].Value = PA_ID;
        para[1] = new SqlParameter("@PA_RMan", SqlDbType.VarChar, 20);
        para[1].Value = PA_RMan;
        para[2] = new SqlParameter("@PA_Suggestion", SqlDbType.VarChar, 400);
        para[2].Value = PA_Suggestion;
        para[3] = new SqlParameter("@PA_RResult", SqlDbType.VarChar, 20);
        para[3].Value = PA_RResult;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_U_PieceAudit", para);

    }

    public void U_RelatedTimeAuditor(Guid PA_ID, string PA_RMan, string PA_Suggestion, string PA_RResult)//修改计件项目审核主表
    {
        SqlParameter[] para = new SqlParameter[4];
        para[0] = new SqlParameter("@PA_ID", SqlDbType.UniqueIdentifier);
        para[0].Value = PA_ID;
        para[1] = new SqlParameter("@PA_RMan", SqlDbType.VarChar, 20);
        para[1].Value = PA_RMan;
        para[2] = new SqlParameter("@PA_Suggestion", SqlDbType.VarChar, 400);
        para[2].Value = PA_Suggestion;
        para[3] = new SqlParameter("@PA_RResult", SqlDbType.VarChar, 20);
        para[3].Value = PA_RResult;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_U_RelatedTimeAuditor", para);

    }

    public void I_PieceAudi(Guid SPI_ID, DateTime PA_Date, string PA_RMan, string PA_Suggestion, string PA_RResult)//插入计件项目审核主表
    {
        SqlParameter[] para = new SqlParameter[5];
        para[0] = new SqlParameter("@SPI_ID", SqlDbType.UniqueIdentifier);
        para[0].Value = SPI_ID;
        para[1] = new SqlParameter("@PA_RMan", SqlDbType.VarChar, 20);
        para[1].Value = PA_RMan;
        para[2] = new SqlParameter("@PA_Suggestion", SqlDbType.VarChar, 400);
        para[2].Value = PA_Suggestion;
        para[3] = new SqlParameter("@PA_RResult", SqlDbType.VarChar, 20);
        para[3].Value = PA_RResult;
        para[4] = new SqlParameter("@PA_Date", SqlDbType.Date);
        para[4].Value = PA_Date;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_I_PieceAudit", para);

    }

    public void I_RelatedTimeAuditor(Guid SPI_ID, DateTime PA_Date, string PA_RMan, string PA_Suggestion, string PA_RResult)//插入计件项目审核主表
    {
        SqlParameter[] para = new SqlParameter[5];
        para[0] = new SqlParameter("@SPI_ID", SqlDbType.UniqueIdentifier);
        para[0].Value = SPI_ID;
        para[1] = new SqlParameter("@PA_RMan", SqlDbType.VarChar, 20);
        para[1].Value = PA_RMan;
        para[2] = new SqlParameter("@PA_Suggestion", SqlDbType.VarChar, 400);
        para[2].Value = PA_Suggestion;
        para[3] = new SqlParameter("@PA_RResult", SqlDbType.VarChar, 20);
        para[3].Value = PA_RResult;
        para[4] = new SqlParameter("@PA_Date", SqlDbType.Date);
        para[4].Value = PA_Date;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_I_RelatedTimeAuditor", para);

    }

    public void I_PieceAudit_Piliang(Guid SPI_ID, DateTime PA_Date, string PA_RMan, string PA_Suggestion, string PA_RResult)//插入计件项目审核主表
    {
        SqlParameter[] para = new SqlParameter[5];
        para[0] = new SqlParameter("@SPI_ID", SqlDbType.UniqueIdentifier);
        para[0].Value = SPI_ID;
        para[1] = new SqlParameter("@PA_RMan", SqlDbType.VarChar, 20);
        para[1].Value = PA_RMan;
        para[2] = new SqlParameter("@PA_Suggestion", SqlDbType.VarChar, 400);
        para[2].Value = PA_Suggestion;
        para[3] = new SqlParameter("@PA_RResult", SqlDbType.VarChar, 20);
        para[3].Value = PA_RResult;
        para[4] = new SqlParameter("@PA_Date", SqlDbType.Date);
        para[4].Value = PA_Date;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_I_PieceAudit_Piliang", para);

    }

    public void I_RelatedTimeAuditor_Piliang(Guid SPI_ID, DateTime PA_Date, string PA_RMan, string PA_Suggestion, string PA_RResult)//插入计件项目审核主表
    {
        SqlParameter[] para = new SqlParameter[5];
        para[0] = new SqlParameter("@SPI_ID", SqlDbType.UniqueIdentifier);
        para[0].Value = SPI_ID;
        para[1] = new SqlParameter("@PA_RMan", SqlDbType.VarChar, 20);
        para[1].Value = PA_RMan;
        para[2] = new SqlParameter("@PA_Suggestion", SqlDbType.VarChar, 400);
        para[2].Value = PA_Suggestion;
        para[3] = new SqlParameter("@PA_RResult", SqlDbType.VarChar, 20);
        para[3].Value = PA_RResult;
        para[4] = new SqlParameter("@PA_Date", SqlDbType.Date);
        para[4].Value = PA_Date;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_I_RelatedTimeAuditor_Piliang", para);

    }

    public DataSet S_JSXMSH(string condition)//显示计时项目审核主表
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 6000);
        para[0].Value = condition;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_JSXMSH", para);

    }
    public DataSet S_HeDanNum(Guid WO_ID)//获得可分单数据量
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@WO_ID", SqlDbType.UniqueIdentifier);
        para[0].Value = WO_ID;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_HeDanNum", para);

    }

    public void U_PMPDetail_YiJian(string condition, string linenum)//一键复制月参考投产计划至投产计划
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@condition", SqlDbType.VarChar,2000);
        para[0].Value = condition;
        if (linenum == "0")
        {
            para[0].Value = condition + "and  PS_Name not like '%模块%'";

        }
        else
        {
            para[0].Value = condition + "and  PS_Name like '%模块%' ";
        }
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_U_PMPDetail_YiJian", para);

    }

    public void U_PWPDetail_YiJian(string condition, string linenum)//一键复制周参考投产计划至投产计划
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 2000);
        para[0].Value = condition;
        if (linenum == "0")
        {
            para[0].Value = condition + "and  PS_Name not like '%模块%'";

        }
        else
        {
            para[0].Value = condition + "and  PS_Name like '%模块%' ";
        }
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_U_PWPDetail_YiJian", para);

    }

    public DataSet S_JJBL(string condition)//显示计时项目审核主表
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 2000);
        para[0].Value = condition;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_JJBL", para);

    }
    public DataSet S_JSBL(string condition)//显示计时项目审核主表
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 2000);
        para[0].Value = condition;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_JSBL", para);

    }
    public void I_JJBL(string man, string note)//新增计件补录主表
    {
        SqlParameter[] para = new SqlParameter[2];
        para[0] = new SqlParameter("@JJBL_Man", SqlDbType.VarChar, 20);
        para[0].Value = man;
        para[1] = new SqlParameter("@JJBL_Note", SqlDbType.VarChar, 400);
        para[1].Value = note;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_I_JJBL", para);

    }
    public void I_JSBL(string man, string note)//新增计时补录主表
    {
        SqlParameter[] para = new SqlParameter[2];
        para[0] = new SqlParameter("@JJBL_Man", SqlDbType.VarChar, 20);
        para[0].Value = man;
        para[1] = new SqlParameter("@JJBL_Note", SqlDbType.VarChar, 400);
        para[1].Value = note;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_I_JSBL", para);

    }

    public void D_JJBL(Guid JJBL_ID)//新增计件补录主表
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@JJBL_ID", SqlDbType.UniqueIdentifier);
        para[0].Value = JJBL_ID;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_D_JJBL", para);

    }

    public void D_JSBL(Guid JJBL_ID)//删除计时补录主表
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@JJBL_ID", SqlDbType.UniqueIdentifier);
        para[0].Value = JJBL_ID;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_D_JSBL", para);

    }
    public DataSet S_JJBLD(string condition)//检索计件补录详细表 yzg 0826
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 5000);
        para[0].Value = condition;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_JJBLD", para);

    }
    public DataSet S_JSBLD(string condition)//检索计时补录详细表 yzg 0826
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 5000);
        para[0].Value = condition;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_JSBLD", para);

    }
    public DataSet S_JJBL_WODetail(string condition)//检索随工单
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 5000);
        para[0].Value = condition;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_JJBL_WODetail", para);

    }

    public void I_JJBLD(Guid WOD_ID, Guid HRDD_ID, Guid JJBL_ID)//插入计件补录详细表
    {
        SqlParameter[] para = new SqlParameter[3];
        para[0] = new SqlParameter("@WOD_ID", SqlDbType.UniqueIdentifier);
        para[0].Value = WOD_ID;
        para[1] = new SqlParameter("@HRDD_ID", SqlDbType.UniqueIdentifier);
        para[1].Value = HRDD_ID;
        para[2] = new SqlParameter("@JJBL_ID", SqlDbType.UniqueIdentifier);
        para[2].Value = JJBL_ID;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_I_JJBLD", para);

    }

    public void I_JSBLD(Guid WOD_ID, Guid HRDD_ID, Guid JJBL_ID)//插入计时补录详细表
    {
        SqlParameter[] para = new SqlParameter[3];
        para[0] = new SqlParameter("@WOD_ID", SqlDbType.UniqueIdentifier);
        para[0].Value = WOD_ID;
        para[1] = new SqlParameter("@HRDD_ID", SqlDbType.UniqueIdentifier);
        para[1].Value = HRDD_ID;
        para[2] = new SqlParameter("@JJBL_ID", SqlDbType.UniqueIdentifier);
        para[2].Value = JJBL_ID;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_I_JSBLD", para);

    }

    public void D_JJBLDetail(Guid JJBLD_ID)//删除计件补录详细表
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@JJBLD_ID", SqlDbType.UniqueIdentifier);
        para[0].Value = JJBLD_ID;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_D_JJBLDetail", para);

    }
    public void D_JSBLDetail(Guid JJBLD_ID)//删除计件补录详细表
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@JJBLD_ID", SqlDbType.UniqueIdentifier);
        para[0].Value = JJBLD_ID;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_D_JSBLDetail", para);

    }
    public void U_JJBLDetail_SPI(Guid JJBLD_ID, Guid SPI_ID)//选择计件类型
    {
        SqlParameter[] para = new SqlParameter[2];
        para[0] = new SqlParameter("@JJBLD_ID", SqlDbType.UniqueIdentifier);
        para[0].Value = JJBLD_ID;
        para[1] = new SqlParameter("@SPI_ID", SqlDbType.UniqueIdentifier);
        para[1].Value = SPI_ID;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "PRoc_U_JJBLDetail_SPI", para);

    }
    public void U_JSBLDetail_SPI(Guid JJBLD_ID, Guid SPI_ID)//选择计时类型
    {
        SqlParameter[] para = new SqlParameter[2];
        para[0] = new SqlParameter("@JJBLD_ID", SqlDbType.UniqueIdentifier);
        para[0].Value = JJBLD_ID;
        para[1] = new SqlParameter("@SPI_ID", SqlDbType.UniqueIdentifier);
        para[1].Value = SPI_ID;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "PRoc_U_JSBLDetail_SPI", para);

    }

    public void U_JJBLD_Num(int Num, Guid JJBLD_ID)//选择计件类型
    {
        SqlParameter[] para = new SqlParameter[2];
        para[0] = new SqlParameter("@Num", SqlDbType.Int);
        para[0].Value = Num;
        para[1] = new SqlParameter("@JJBLD_ID", SqlDbType.UniqueIdentifier);
        para[1].Value = JJBLD_ID;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_U_JJBLD_Num", para);

    }
    public void U_JSBLD_Num(int Num, Guid JJBLD_ID, decimal TIME)//保存计时补录的数量、时间
    {
        SqlParameter[] para = new SqlParameter[3];
        para[0] = new SqlParameter("@Num", SqlDbType.Int);
        para[0].Value = Num;
        para[1] = new SqlParameter("@JJBLD_ID", SqlDbType.UniqueIdentifier);
        para[1].Value = JJBLD_ID;
        para[2] = new SqlParameter("@TIME ", SqlDbType.Decimal);
        para[2].Value = TIME;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_U_JSBLD_Num", para);

    }


    public void U_JJBL_SH(Guid JJBL_ID, string JJBL_ShMan, string JJBL_ShSugg, string JJBL_ShRes)//计件补录审核
    {
        SqlParameter[] para = new SqlParameter[4];
        para[0] = new SqlParameter("@JJBL_ID", SqlDbType.UniqueIdentifier);
        para[0].Value = JJBL_ID;
        para[1] = new SqlParameter("@JJBL_ShMan", SqlDbType.VarChar,20);
        para[1].Value = JJBL_ShMan;
        para[2] = new SqlParameter("@JJBL_ShSugg", SqlDbType.VarChar,400);
        para[2].Value = JJBL_ShSugg;
        para[3] = new SqlParameter("@JJBL_ShRes", SqlDbType.VarChar, 20);
        para[3].Value = JJBL_ShRes;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_U_JJBL_SH", para);

    }
    public void U_JSBL_SH(Guid JJBL_ID, string JJBL_ShMan, string JJBL_ShSugg, string JJBL_ShRes)//计件补录审核
    {
        SqlParameter[] para = new SqlParameter[4];
        para[0] = new SqlParameter("@JJBL_ID", SqlDbType.UniqueIdentifier);
        para[0].Value = JJBL_ID;
        para[1] = new SqlParameter("@JJBL_ShMan", SqlDbType.VarChar, 20);
        para[1].Value = JJBL_ShMan;
        para[2] = new SqlParameter("@JJBL_ShSugg", SqlDbType.VarChar, 400);
        para[2].Value = JJBL_ShSugg;
        para[3] = new SqlParameter("@JJBL_ShRes", SqlDbType.VarChar, 20);
        para[3].Value = JJBL_ShRes;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_U_JSBL_SH", para);

    }

    public void U_JJBL_TJ(Guid JJBL_ID)//计件补录提交
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@JJBL_ID", SqlDbType.UniqueIdentifier);
        para[0].Value = JJBL_ID;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_U_JJBL_TJ", para);

    }
    public void U_JSBL_TJ(Guid JJBL_ID)//计时补录提交
    {
        SqlParameter[] para = new SqlParameter[1];
        para[0] = new SqlParameter("@JJBL_ID", SqlDbType.UniqueIdentifier);
        para[0].Value = JJBL_ID;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_U_JSBL_TJ", para);

    }

    public void U_PWPDetail_Date(string PWP_ID, string type, string date)//制定日计划的日期
    {
        SqlParameter[] para = new SqlParameter[3];
        para[0] = new SqlParameter("@PWP_ID", SqlDbType.VarChar,100);
        para[0].Value = PWP_ID;
        para[1] = new SqlParameter("@type", SqlDbType.VarChar, 2);
        para[1].Value = type;
        para[2] = new SqlParameter("@date", SqlDbType.VarChar, 100);
        para[2].Value = date;
        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_U_PWPDetail_Date", para);

    }

}