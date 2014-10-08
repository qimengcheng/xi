using System;
using System.Data;
using System.Data.SqlClient;
//using System.Collections.Generic;
using EquipmentMangementAjax.DBUtility;

/// <summary>
///IMOverD 的摘要说明
/// </summary>
/// 
 namespace EquipmentMangementAjax.SQLServer
{
     public class IMOverD : IIMOver
     {

         public IMOverD()
         {
             //
             //TODO: 在此处添加构造函数逻辑
             //
         }
         //查询入库单详细表
         public DataSet Select_Kucun(string condition)
         {
             SqlParameter[] para = new SqlParameter[1];
             para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
             para[0].Value = condition;
             return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_IMInventoryDetail_baofei_Mat", para);
         }
         //提交报废申请
         public void Insert_Apply(Guid ID, string man, string reason)
         {
             SqlParameter[] para = new SqlParameter[3];
             para[0] = new SqlParameter("@IMID_ID", SqlDbType.UniqueIdentifier);
             para[0].Value = ID;
             para[1] = new SqlParameter("@IMMS_ApplyMan", SqlDbType.VarChar, 20);
             para[1].Value = man;
             para[2] = new SqlParameter("@IMMS_AnalysisReason", SqlDbType.VarChar, 400);
             para[2].Value = reason;
             SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_IMMaterialScrap", para);
         }
         //库房下拉
         public DataSet  Select_Kufang_DropdownList(string department, string man)
         {
             SqlParameter[] para = new SqlParameter[2];
             para[0] = new SqlParameter("@IMS_ResponDepart", SqlDbType.VarChar, 100);
             para[0].Value = department;
             para[1] = new SqlParameter("@IMS_ResponMan", SqlDbType.VarChar, 100);
             para[1].Value = man;
             return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_IMStore_Dropdownlist", para);
         }
         //查询报废申请
         public DataSet Select_Apply(string condition)
         {
             SqlParameter[] para = new SqlParameter[1];
             para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
             para[0].Value = condition;
             return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_IMMaterialScrap", para);
         }
         //分析报告提交
         public void Update_Apply(Guid ID, string result, string man)
         {
             SqlParameter[] para = new SqlParameter[3];
             para[0] = new SqlParameter("@IMMS_ID", SqlDbType.UniqueIdentifier);
             para[0].Value = ID;
             para[1] = new SqlParameter("@IMMS_AnalysisResult", SqlDbType.VarChar, 400);
             para[1].Value = result;
             para[2] = new SqlParameter("@IMMS_AnalysisMakeMan", SqlDbType.VarChar, 20);
             para[2].Value = man;
             SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_IMMaterialScrap", para);
         }
         //审核报告提交
         public void Update_Apply_Check(Guid ID, string result, string man,string  opinion)
         {
             SqlParameter[] para = new SqlParameter[4];
             para[0] = new SqlParameter("@IMMS_ID", SqlDbType.UniqueIdentifier);
             para[0].Value = ID;
             para[1] = new SqlParameter("@IMMS_ScrapCheckResult", SqlDbType.VarChar, 20);
             para[1].Value = result;
             para[2] = new SqlParameter("@IMMS_ScrapCheckMan", SqlDbType.VarChar, 20);
             para[2].Value = man;
             para[3] = new SqlParameter("@IMMS_ScrapCheckOpinion", SqlDbType.VarChar, 400);
             para[3].Value = opinion;
             SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_IMMaterialScrap_Check", para);
         }
         //执行报废
         public void Update_Apply_Zhixing(Guid ID)
         {
             SqlParameter[] para = new SqlParameter[1];
             para[0] = new SqlParameter("@IMMS_ID", SqlDbType.UniqueIdentifier);
             para[0].Value = ID;
             SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_Baofeizhixing", para);
         }
     }
}