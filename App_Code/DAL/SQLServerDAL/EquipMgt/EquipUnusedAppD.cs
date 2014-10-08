using System;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
///EquipUnusedAppD 的摘要说明
/// </summary>
namespace EquipmentMangementAjax.SQLServer
{
    public class EquipUnusedAppD : IEquipUnusedApp
    {
        public EquipUnusedAppD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        //增加报废申请时，首先查询并选择已有的设备
        public DataSet Search_InsertEquipUnusedApp(string ETT_Type, string EN_EquipName, string EMT_Type, string EI_No)
        {
            SqlParameter[] parm = new SqlParameter[4];
            parm[0] = new SqlParameter("@ETT_Type", SqlDbType.VarChar, 20);
            parm[0].Value = ETT_Type;
            parm[1] = new SqlParameter("@EN_EquipName", SqlDbType.VarChar, 40);
            parm[1].Value = EN_EquipName;
            parm[2] = new SqlParameter("@EMT_Type", SqlDbType.VarChar, 20);
            parm[2].Value = EMT_Type;
            parm[3] = new SqlParameter("@EI_No", SqlDbType.VarChar, 20);
            parm[3].Value = EI_No;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_InsertEquipUnusedApp", parm);
        }
        //在已选择的设备台账下,增加报废申请
        public void Insert_EquipUnusedApp(Guid EI_ID, short EUA_UseYear, string EUA_AppPer, DateTime EUA_AppTime, string EUA_Reason, string EUA_AppState)
        {
            SqlParameter[] parm = new SqlParameter[6];
            parm[0] = new SqlParameter("@EI_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = EI_ID;
            parm[1] = new SqlParameter("@EUA_UseYear", SqlDbType.SmallInt);
            parm[1].Value = EUA_UseYear;
            parm[2] = new SqlParameter("@EUA_AppPer", SqlDbType.VarChar, 20);
            parm[2].Value = EUA_AppPer;
            parm[3] = new SqlParameter("@EUA_AppTime", SqlDbType.DateTime);
            parm[3].Value = EUA_AppTime;
            parm[4] = new SqlParameter("@EUA_Reason", SqlDbType.VarChar, 500);
            parm[4].Value = EUA_Reason;
            parm[5] = new SqlParameter("@EUA_AppState", SqlDbType.VarChar, 20);
            parm[5].Value = EUA_AppState;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,CommandType.StoredProcedure, "Proc_I_EquipUnusedApp", parm);
        }
        
        //修改报废申请表
        public void Update_EquipUnusedApp_SQ(Guid EUA_ID, short EUA_UseYear, string EUA_AppPer, DateTime EUA_AppTime, string EUA_Reason, string EUA_AppNO, string EUA_AppState)
        {
            SqlParameter[] parm = new SqlParameter[7];
            parm[0] = new SqlParameter("@EUA_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = EUA_ID;
            parm[1] = new SqlParameter("@EUA_UseYear", SqlDbType.SmallInt);
            parm[1].Value = EUA_UseYear;
            parm[2] = new SqlParameter("@EUA_AppPer", SqlDbType.VarChar, 20);
            parm[2].Value = EUA_AppPer;
            parm[3] = new SqlParameter("@EUA_AppTime", SqlDbType.DateTime);
            parm[3].Value = EUA_AppTime;
            parm[4] = new SqlParameter("@EUA_Reason", SqlDbType.VarChar, 500);
            parm[4].Value = EUA_Reason;
            parm[5] = new SqlParameter("@EUA_AppNO", SqlDbType.Char, 50);
            parm[5].Value = EUA_AppNO;
            parm[6] = new SqlParameter("@EUA_AppState", SqlDbType.VarChar, 20);
            parm[6].Value = EUA_AppState;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_EquipUnusedApp_SQ", parm);
        }
        
        //删除报废申请
        public int Delete_EquipUnusedApp(Guid EUA_ID)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@EUA_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = EUA_ID;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,CommandType.StoredProcedure, "Proc_D_EquipUnusedApp", parm);
        }
        //报废情况查询
        public DataSet Search_EquipUnusedApp(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_EquipUnusedApp", para);
        }
        //审批报废申请--技术副总
        public void Update_EquipUnusedApp_SP1(Guid EUA_ID, string EUA_Approver, DateTime EUA_ApprovalT, string EUA_ApprovalSugg, string EUA_ApprovalRes)
        {
            SqlParameter[] parm = new SqlParameter[5];
            parm[0] = new SqlParameter("@EUA_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = EUA_ID;
            parm[1] = new SqlParameter("@EUA_Approver", SqlDbType.VarChar, 20);
            parm[1].Value = EUA_Approver;
            parm[2] = new SqlParameter("@EUA_ApprovalT", SqlDbType.DateTime);
            parm[2].Value = EUA_ApprovalT;
            parm[3] = new SqlParameter("@EUA_ApprovalSugg", SqlDbType.VarChar, 400);
            parm[3].Value = EUA_ApprovalSugg;
            parm[4] = new SqlParameter("@EUA_ApprovalRes", SqlDbType.VarChar, 20);
            parm[4].Value = EUA_ApprovalRes;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_EquipUnusedApp_SP1", parm);
        }
        //审批报废申请--财务
        public void Update_EquipUnusedApp_SP2(Guid EUA_ID,string EUA_Approver2, DateTime EUA_ApprovalT2, string EUA_ApprovalSugg2, string EUA_ApprovalRes2)
        {
            SqlParameter[] parm = new SqlParameter[5];
            parm[0] = new SqlParameter("@EUA_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = EUA_ID;
            parm[1] = new SqlParameter("@EUA_Approver2", SqlDbType.VarChar, 20);
            parm[1].Value = EUA_Approver2;
            parm[2] = new SqlParameter("@EUA_ApprovalT2", SqlDbType.DateTime);
            parm[2].Value = EUA_ApprovalT2;
            parm[3] = new SqlParameter("@EUA_ApprovalSugg2", SqlDbType.VarChar, 400);
            parm[3].Value = EUA_ApprovalSugg2;
            parm[4] = new SqlParameter("@EUA_ApprovalRes2", SqlDbType.VarChar, 20);
            parm[4].Value = EUA_ApprovalRes2;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_EquipUnusedApp_SP2", parm);
        }
        //报废处理
        public void Update_EquipUnusedApp_CL(Guid EUA_ID, string EUA_DealPer, DateTime EUA_DealTime)
        {
            SqlParameter[] parm = new SqlParameter[3];
            parm[0] = new SqlParameter("@EUA_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = EUA_ID;
            parm[1] = new SqlParameter("@EUA_DealPer", SqlDbType.VarChar, 20);
            parm[1].Value = EUA_DealPer;
            parm[2] = new SqlParameter("@EUA_DealTime", SqlDbType.DateTime);
            parm[2].Value = EUA_DealTime;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_EquipUnusedApp_CL", parm);
        }
        //总经理批准报废申请
        public void Update_EquipUnusedApp_PZ(Guid EUA_ID, string EUA_Allower, DateTime EUA_AllowT, string EUA_AllowSugg, string EUA_AllowRes, string EUA_AppState)
        {
            SqlParameter[] parm = new SqlParameter[6];
            parm[0] = new SqlParameter("@EUA_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = EUA_ID;
            parm[1] = new SqlParameter("@EUA_Allower", SqlDbType.VarChar, 20);
            parm[1].Value = EUA_Allower;
            parm[2] = new SqlParameter("@EUA_AllowT", SqlDbType.DateTime);
            parm[2].Value = EUA_AllowT;
            parm[3] = new SqlParameter("@EUA_AllowSugg", SqlDbType.VarChar, 400);
            parm[3].Value = EUA_AllowSugg;
            parm[4] = new SqlParameter("@EUA_AllowRes", SqlDbType.VarChar, 20);
            parm[4].Value = EUA_AllowRes;
            parm[5] = new SqlParameter("@EUA_AppState", SqlDbType.VarChar, 20);
            parm[5].Value = EUA_AppState;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_EquipUnusedApp_PZ", parm);
        }
    }
}