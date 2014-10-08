using System;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
///TypeTestD 的摘要说明
/// </summary>
namespace EquipmentMangementAjax.SQLServer
{
    public class TypeTestD : ITypeTest
    {
        public TypeTestD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        //增加型式实验计划
        public void Insert_TypeTestMan(Int16 TTM_Year, Byte TTM_Month, string TTM_State,string TTM_Maker,DateTime TTM_Time)
        {
            SqlParameter[] parm = new SqlParameter[5];
            parm[0] = new SqlParameter("@TTM_Year", SqlDbType.Int);
            parm[0].Value = TTM_Year;
            parm[1] = new SqlParameter("@TTM_Month", SqlDbType.SmallInt);
            parm[1].Value = TTM_Month;
            parm[2] = new SqlParameter("@TTM_State", SqlDbType.VarChar, 20);
            parm[2].Value = TTM_State;
            parm[3] = new SqlParameter("@TTM_Maker", SqlDbType.VarChar, 20);
            parm[3].Value = TTM_Maker;
            parm[4] = new SqlParameter("@TTM_Time", SqlDbType.DateTime);
            parm[4].Value = TTM_Time;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_TypeTestMan", parm);
        }
        //删除型式实验计划
        public int Delete_TypeTestMan(Guid TTM_TypePlanID)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@TTM_TypePlanID", SqlDbType.UniqueIdentifier);
            parm[0].Value = TTM_TypePlanID;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_TypeTestMan", parm);
        }
        //修改型式实验计划
        public void Update_TypeTestMan(Guid TTM_TypePlanID, Int16 TTM_Year, Byte TTM_Month, string TTM_Maker, DateTime TTM_Time)
        {
            SqlParameter[] parm = new SqlParameter[5];
            parm[0] = new SqlParameter("@TTM_TypePlanID", SqlDbType.UniqueIdentifier);
            parm[0].Value = TTM_TypePlanID;
            parm[1] = new SqlParameter("@TTM_Year", SqlDbType.Int);
            parm[1].Value = TTM_Year;
            parm[2] = new SqlParameter("@TTM_Month", SqlDbType.SmallInt);
            parm[2].Value = TTM_Month;
            parm[3] = new SqlParameter("@TTM_Maker", SqlDbType.VarChar, 20);
            parm[3].Value = TTM_Maker;
            parm[4] = new SqlParameter("@TTM_Time", SqlDbType.DateTime);
            parm[4].Value = TTM_Time;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_TypeTestMan", parm);
        }
        //查询型式实验计划
        public DataSet Search_TypeTestMan(string condition)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            parm[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_TypeTestMan", parm);
        }
        //增加型式实验计划详情前,首先查询并显示产品型号
        public DataSet Search_ProType_ProSeries(string condition)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            parm[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_ProType_ProSeries", parm);
        }
        //建立型式实验计划后,增加产品型号
        public void Insert_TypeTestDetail(Guid PT_ID, Guid TTM_TypePlanID, string TTD_IsUploaded)
        {
            SqlParameter[] parm = new SqlParameter[3];
            parm[0] = new SqlParameter("@PT_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = PT_ID;
            parm[1] = new SqlParameter("@TTM_TypePlanID", SqlDbType.UniqueIdentifier);
            parm[1].Value = TTM_TypePlanID;
            parm[2] = new SqlParameter("@TTD_IsUploaded", SqlDbType.Char, 2);
            parm[2].Value = TTD_IsUploaded;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_TypeTestDetail", parm);
        }
        //删除某型式实验计划下，某产品型号
        public int Delete_TypeTestDetail(Guid TTD_DetailID)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@TTD_DetailID", SqlDbType.UniqueIdentifier);
            parm[0].Value = TTD_DetailID;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_TypeTestDetail", parm);
        }
        //某型式实验计划下，查询某产品型号
        public DataSet Search_TypeTestDetail(string condition)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            parm[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_TypeTestDetail", parm);
        }
        //上传某产品型号的实验报告
        public void Update_TypeTestDetail(Guid TTD_DetailID, string TTD_IsUploaded, string TTD_ReportNO, string TTD_UpPer, DateTime TTD_UpTime, string TTD_RepRoute, string TTD_IsPass)
        {
            SqlParameter[] parm = new SqlParameter[7];
            parm[0] = new SqlParameter("@TTD_DetailID", SqlDbType.UniqueIdentifier);
            parm[0].Value = TTD_DetailID;
            parm[1] = new SqlParameter("@TTD_IsUploaded", SqlDbType.Char, 2);
            parm[1].Value = TTD_IsUploaded;
            parm[2] = new SqlParameter("@TTD_ReportNO", SqlDbType.Char, 60);
            parm[2].Value = TTD_ReportNO;
            parm[3] = new SqlParameter("@TTD_UpPer", SqlDbType.VarChar, 20);
            parm[3].Value = TTD_UpPer;
            parm[4] = new SqlParameter("@TTD_UpTime", SqlDbType.DateTime);
            parm[4].Value = TTD_UpTime;
            parm[5] = new SqlParameter("@TTD_RepRoute", SqlDbType.VarChar, 200);
            parm[5].Value = TTD_RepRoute;
            parm[6] = new SqlParameter("@TTD_IsPass", SqlDbType.VarChar, 10);
            parm[6].Value = TTD_IsPass;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_TypeTestDetail", parm);
        }
        //上传实验报告后，提交型式实验，状态变为已完成
        public void Update_TypeTestMan_done(Guid TTM_TypePlanID,string TTM_State)
        {
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@TTM_TypePlanID", SqlDbType.UniqueIdentifier);
            parm[0].Value = TTM_TypePlanID;
            parm[1] = new SqlParameter("@TTM_State", SqlDbType.VarChar, 20);
            parm[1].Value = TTM_State;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_TypeTestMan_done", parm);
        }
        //删除型式实验计划时，首先查询该计划的详情表中是否有已上传的实验报告
        public DataSet Search_TypeTestMan_TypeTestDetail(Guid TTM_TypePlanID)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@TTM_TypePlanID", SqlDbType.UniqueIdentifier);
            parm[0].Value = TTM_TypePlanID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_TypeTestMan_TypeTestDetail", parm);
        }
        //提交型式实验计划时，首先查询该计划的详情表中是否有未上传的实验报告
        public DataSet Search_TypeTestMan_TypeTestDetail_not(Guid TTM_TypePlanID)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@TTM_TypePlanID", SqlDbType.UniqueIdentifier);
            parm[0].Value = TTM_TypePlanID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_TypeTestMan_TypeTestDetail_not", parm);
        }
        //选择产品型号后，录入对应厂家名称
        public void Update_TypeTestDetail_company(Guid TTD_DetailID, string TTD_Company)
        {
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@TTD_DetailID", SqlDbType.UniqueIdentifier);
            parm[0].Value = TTD_DetailID;
            parm[1] = new SqlParameter("@TTD_Company", SqlDbType.VarChar, 100);
            parm[1].Value = TTD_Company;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_TypeTestDetail_company", parm);
        }
    }
}