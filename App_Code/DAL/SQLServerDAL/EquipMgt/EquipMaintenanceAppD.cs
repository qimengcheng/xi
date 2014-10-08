using System;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
///EquipMaintenanceAppD 的摘要说明
/// </summary>
namespace EquipmentMangementAjax.SQLServer
{
    public class EquipMaintenanceAppD : IEquipMaintenanceApp
    {
        public EquipMaintenanceAppD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        //增加维修申请时，首先查询并选择设备台账
        public DataSet Search_InsertEquipMaintenanceApp(string ETT_Type, string EN_EquipName, string EMT_Type, string EI_No)
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
                CommandType.StoredProcedure, "Proc_S_InsertEquipMaintenanceApp", parm);
        }
        //在已选择的设备台账下,增加维修申请
        public void Insert_EquipMaintenanceApp(Guid EI_ID, string EMA_AppDep, DateTime EMA_BreakDownTime, string EMA_AppPer, DateTime EMA_AppTime,
                                               string EMA_BDDetail, string EMA_AppState)
        {
            SqlParameter[] parm = new SqlParameter[7];
            parm[0] = new SqlParameter("@EI_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = EI_ID;
            parm[1] = new SqlParameter("@EMA_AppDep", SqlDbType.VarChar, 20);
            parm[1].Value = EMA_AppDep;
            parm[2] = new SqlParameter("@EMA_BreakDownTime", SqlDbType.DateTime);
            parm[2].Value = EMA_BreakDownTime;
            parm[3] = new SqlParameter("@EMA_AppPer", SqlDbType.VarChar, 20);
            parm[3].Value = EMA_AppPer;
            parm[4] = new SqlParameter("@EMA_AppTime", SqlDbType.DateTime);
            parm[4].Value = EMA_AppTime;
            parm[5] = new SqlParameter("@EMA_BDDetail", SqlDbType.VarChar, 400);
            parm[5].Value = EMA_BDDetail;
            parm[6] = new SqlParameter("@EMA_AppState", SqlDbType.VarChar, 20);
            parm[6].Value = EMA_AppState;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_EquipMaintenanceApp", parm);
        }
        //修改维修申请表
        public void Update_EquipMaintenanceApp_SQ(Guid EMA_ID, string EMA_AppDep, DateTime EMA_BreakDownTime, string EMA_AppPer, DateTime EMA_AppTime,
                                               string EMA_BDDetail, string EMA_AppState)
        {
            SqlParameter[] parm = new SqlParameter[7];
            parm[0] = new SqlParameter("@EMA_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = EMA_ID;
            parm[1] = new SqlParameter("@EMA_AppDep", SqlDbType.VarChar, 20);
            parm[1].Value = EMA_AppDep;
            parm[2] = new SqlParameter("@EMA_BreakDownTime", SqlDbType.DateTime);
            parm[2].Value = EMA_BreakDownTime;
            parm[3] = new SqlParameter("@EMA_AppPer", SqlDbType.VarChar, 20);
            parm[3].Value = EMA_AppPer;
            parm[4] = new SqlParameter("@EMA_AppTime", SqlDbType.DateTime);
            parm[4].Value = EMA_AppTime;
            parm[5] = new SqlParameter("@EMA_BDDetail", SqlDbType.VarChar, 400);
            parm[5].Value = EMA_BDDetail;
            parm[6] = new SqlParameter("@EMA_AppState", SqlDbType.VarChar, 20);
            parm[6].Value = EMA_AppState;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_EquipMaintenanceApp_SQ", parm);
        }
        //请修部门下拉框绑定
        public DataSet Search_BDOrganizationSheet_EquipMaintenanceApp()
        {
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_BDOrganizationSheet_EquipMaintenanceApp");
        }
        //删除维修申请
        public int Delete_EquipMaintenanceApp(Guid EMA_ID)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@EMA_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = EMA_ID;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_EquipMaintenanceApp", parm);
        }
        //查询维修情况
        public DataSet Search_EquipMaintenanceApp(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_EquipMaintenanceApp", para);
        }
        //接收确认维修申请
        public void Update_EquipMaintenanceApp_QR(Guid EMA_ID, string EMA_AckPer, DateTime EMA_AckTime, string EMA_AppState)
        {
            SqlParameter[] parm = new SqlParameter[4];
            parm[0] = new SqlParameter("@EMA_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = EMA_ID;
            parm[1] = new SqlParameter("@EMA_AckPer", SqlDbType.VarChar, 20);
            parm[1].Value = EMA_AckPer;
            parm[2] = new SqlParameter("@EMA_AckTime", SqlDbType.DateTime);
            parm[2].Value = EMA_AckTime;
            parm[3] = new SqlParameter("@EMA_AppState", SqlDbType.VarChar, 20);
            parm[3].Value = EMA_AppState;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_EquipMaintenanceApp_QR", parm);
        }
        //验收维修
        public void Update_EquipMaintenanceApp_YS(Guid EMA_ID, string EMA_CheckPer, DateTime EMA_CheckTime,string EMA_CheckRes,string EMA_CheckSugg,string EMA_AppState)
        {
            SqlParameter[] parm = new SqlParameter[6];
            parm[0] = new SqlParameter("@EMA_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = EMA_ID;
            parm[1] = new SqlParameter("@EMA_CheckPer", SqlDbType.VarChar, 20);
            parm[1].Value = EMA_CheckPer;
            parm[2] = new SqlParameter("@EMA_CheckTime", SqlDbType.DateTime);
            parm[2].Value = EMA_CheckTime;
            parm[3] = new SqlParameter("@EMA_CheckRes", SqlDbType.VarChar, 20);
            parm[3].Value = EMA_CheckRes;
            parm[4] = new SqlParameter("@EMA_CheckSugg", SqlDbType.VarChar, 400);
            parm[4].Value = EMA_CheckSugg;
            parm[5] = new SqlParameter("@EMA_AppState", SqlDbType.VarChar, 20);
            parm[5].Value = EMA_AppState;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_EquipMaintenanceApp_YS", parm);
        }
        //填写厂内维修记录
        public void Insert_EquipRealDetailAOApp_CN(Guid EI_ID, Guid EMA_ID, string ERDAOA_MaintPer, DateTime ERDAOA_StartTime, DateTime ERDAOA_EndTime,
                                               string ERDAOA_ReasonMethod, string ERDAOA_Remarks)
        {
            SqlParameter[] parm = new SqlParameter[7];
            parm[0] = new SqlParameter("@EI_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = EI_ID;
            parm[1] = new SqlParameter("@EMA_ID", SqlDbType.UniqueIdentifier);
            parm[1].Value = EMA_ID;
            parm[2] = new SqlParameter("@ERDAOA_MaintPer", SqlDbType.VarChar, 20);
            parm[2].Value = ERDAOA_MaintPer;
            parm[3] = new SqlParameter("@ERDAOA_StartTime", SqlDbType.DateTime);
            parm[3].Value = ERDAOA_StartTime;
            parm[4] = new SqlParameter("@ERDAOA_EndTime", SqlDbType.DateTime);
            parm[4].Value = ERDAOA_EndTime;
            parm[5] = new SqlParameter("@ERDAOA_ReasonMethod", SqlDbType.VarChar, 400);
            parm[5].Value = ERDAOA_ReasonMethod;
            parm[6] = new SqlParameter("@ERDAOA_Remarks", SqlDbType.VarChar, 400);
            parm[6].Value = ERDAOA_Remarks;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_EquipRealDetailAOApp_CN", parm);
        }
        //修改已填写的厂内维修记录
        public void Update_EquipRealDetailAOApp_CN(Guid ERDAOA_ID, string ERDAOA_MaintPer, DateTime ERDAOA_StartTime, DateTime ERDAOA_EndTime,
                                               string ERDAOA_ReasonMethod, string ERDAOA_Remarks)
        {
            SqlParameter[] parm = new SqlParameter[6];
            parm[0] = new SqlParameter("@ERDAOA_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = ERDAOA_ID;
            parm[1] = new SqlParameter("@ERDAOA_MaintPer", SqlDbType.VarChar, 20);
            parm[1].Value = ERDAOA_MaintPer;
            parm[2] = new SqlParameter("@ERDAOA_StartTime", SqlDbType.DateTime);
            parm[2].Value = ERDAOA_StartTime;
            parm[3] = new SqlParameter("@ERDAOA_EndTime", SqlDbType.DateTime);
            parm[3].Value = ERDAOA_EndTime;
            parm[4] = new SqlParameter("@ERDAOA_ReasonMethod", SqlDbType.VarChar, 400);
            parm[4].Value = ERDAOA_ReasonMethod;
            parm[5] = new SqlParameter("@ERDAOA_Remarks", SqlDbType.VarChar, 400);
            parm[5].Value = ERDAOA_Remarks;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_EquipRealDetailAOApp_CN", parm);
        }
        //删除厂内维修记录
        public int Delete_EquipRealDetailAOApp_CN(Guid ERDAOA_ID)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@ERDAOA_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = ERDAOA_ID;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_EquipRealDetailAOApp_CN", parm);
        }
        //查询厂内维修情况
        public DataSet Search_EquipRealDetailAOApp_CN(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_EquipRealDetailAOApp_CN", para);
        }
        //填写厂内维修记录的时候，增加备件
        public void Insert_EquipRealDetailAOApp_Spare(Guid EFUS_ID, Guid ERDAOA_ID, int EMSAUS_UseAmount)
        {
            SqlParameter[] parm = new SqlParameter[3];
            parm[0] = new SqlParameter("@EFUS_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = EFUS_ID;
            parm[1] = new SqlParameter("@ERDAOA_ID", SqlDbType.UniqueIdentifier);
            parm[1].Value = ERDAOA_ID;
            parm[2] = new SqlParameter("@EMSAUS_UseAmount", SqlDbType.Int);
            parm[2].Value = EMSAUS_UseAmount;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_EquipRealDetailAOApp_Spare", parm);
        }
        //填写完维修记录后，维修申请单状态变为“已完成”（填写的维修记录包括厂内和出厂的记录）
        public void Update_EquipMaintenanceApp_CL(Guid EMA_ID, string EMA_AppState)
        {
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@EMA_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = EMA_ID;
            parm[1] = new SqlParameter("@EMA_AppState", SqlDbType.VarChar, 20);
            parm[1].Value = EMA_AppState;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_EquipMaintenanceApp_CL", parm);
        }
        //填写出厂维修申请
        public void Insert_EquipRealDetailAOApp_CC(Guid EI_ID, Guid EMA_ID, string ERDAOA_OAppDep, string ERDAOA_OAppPer, DateTime ERDAOA_OAppTime,
                                               string ERDAOA_OAppState, string ERDAOA_OMaintePlace, string ERDAOA_Feature, string ERDAOA_OReson)
        {
            SqlParameter[] parm = new SqlParameter[9];
            parm[0] = new SqlParameter("@EI_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = EI_ID;
            parm[1] = new SqlParameter("@EMA_ID", SqlDbType.UniqueIdentifier);
            parm[1].Value = EMA_ID;
            parm[2] = new SqlParameter("@ERDAOA_OAppDep", SqlDbType.VarChar, 50);
            parm[2].Value = ERDAOA_OAppDep;
            parm[3] = new SqlParameter("@ERDAOA_OAppPer", SqlDbType.VarChar, 20);
            parm[3].Value = ERDAOA_OAppPer;
            parm[4] = new SqlParameter("@ERDAOA_OAppTime", SqlDbType.DateTime);
            parm[4].Value = ERDAOA_OAppTime;
            parm[5] = new SqlParameter("@ERDAOA_OAppState", SqlDbType.VarChar, 20);
            parm[5].Value = ERDAOA_OAppState;
            parm[6] = new SqlParameter("@ERDAOA_OMaintePlace", SqlDbType.VarChar, 50);
            parm[6].Value = ERDAOA_OMaintePlace;
            parm[7] = new SqlParameter("@ERDAOA_Feature", SqlDbType.VarChar, 400);
            parm[7].Value = ERDAOA_Feature;
            parm[8] = new SqlParameter("@ERDAOA_OReson", SqlDbType.VarChar, 400);
            parm[8].Value = ERDAOA_OReson;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_EquipRealDetailAOApp_CC", parm);
        }
        //修改已填写的出厂维修申请
        public void Update_EquipRealDetailAOApp_CC(Guid ERDAOA_ID, string ERDAOA_OAppDep, string ERDAOA_OAppPer, DateTime ERDAOA_OAppTime,
                                               string ERDAOA_OAppState, string ERDAOA_OMaintePlace, string ERDAOA_Feature, string ERDAOA_OReson)
        {
            SqlParameter[] parm = new SqlParameter[8];
            parm[0] = new SqlParameter("@ERDAOA_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = ERDAOA_ID;
            parm[1] = new SqlParameter("@ERDAOA_OAppDep", SqlDbType.VarChar, 50);
            parm[1].Value = ERDAOA_OAppDep;
            parm[2] = new SqlParameter("@ERDAOA_OAppPer", SqlDbType.VarChar, 20);
            parm[2].Value = ERDAOA_OAppPer;
            parm[3] = new SqlParameter("@ERDAOA_OAppTime", SqlDbType.DateTime);
            parm[3].Value = ERDAOA_OAppTime;
            parm[4] = new SqlParameter("@ERDAOA_OAppState", SqlDbType.VarChar, 20);
            parm[4].Value = ERDAOA_OAppState;
            parm[5] = new SqlParameter("@ERDAOA_OMaintePlace", SqlDbType.VarChar, 50);
            parm[5].Value = ERDAOA_OMaintePlace;
            parm[6] = new SqlParameter("@ERDAOA_Feature", SqlDbType.VarChar, 400);
            parm[6].Value = ERDAOA_Feature;
            parm[7] = new SqlParameter("@ERDAOA_OReson", SqlDbType.VarChar, 400);
            parm[7].Value = ERDAOA_OReson;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_EquipRealDetailAOApp_CC", parm);
        }
        //查询出厂维修情况
        public DataSet Search_EquipRealDetailAOApp_CC(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 2000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_EquipRealDetailAOApp_CC", para);
        }
        //出厂维修审批
        public void Update_EquipRealDetailAOApp_CCSP(Guid ERDAOA_ID, string ERDAOA_Approver, DateTime ERDAOA_ApprovalT,string ERDAOA_ApprovalSugg,
                                                        string ERDAOA_ApprovalRes, string ERDAOA_OAppState)
        {
            SqlParameter[] parm = new SqlParameter[6];
            parm[0] = new SqlParameter("@ERDAOA_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = ERDAOA_ID;
            parm[1] = new SqlParameter("@ERDAOA_Approver", SqlDbType.VarChar, 20);
            parm[1].Value = ERDAOA_Approver;
            parm[2] = new SqlParameter("@ERDAOA_ApprovalT", SqlDbType.DateTime);
            parm[2].Value = ERDAOA_ApprovalT;
            parm[3] = new SqlParameter("@ERDAOA_ApprovalSugg", SqlDbType.VarChar, 400);
            parm[3].Value = ERDAOA_ApprovalSugg;
            parm[4] = new SqlParameter("@ERDAOA_ApprovalRes", SqlDbType.VarChar, 20);
            parm[4].Value = ERDAOA_ApprovalRes;
            parm[5] = new SqlParameter("@ERDAOA_OAppState", SqlDbType.VarChar, 20);
            parm[5].Value = ERDAOA_OAppState;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_EquipRealDetailAOApp_CCSP", parm);
        }
        //出厂维修预算
        public void Update_EquipRealDetailAOApp_CCYS(Guid ERDAOA_ID, DateTime ERDAOA_ExpectODate, DateTime ERDAOA_ExpectIDate, decimal ERDAOA_ExpectCost,
                                                        string ERDAOA_PerInCharge, DateTime ERDAOA_RecordDate, string ERDAOA_OAppState)
        {
            SqlParameter[] parm = new SqlParameter[7];
            parm[0] = new SqlParameter("@ERDAOA_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = ERDAOA_ID;
            parm[1] = new SqlParameter("@ERDAOA_ExpectODate", SqlDbType.DateTime);
            parm[1].Value = ERDAOA_ExpectODate;
            parm[2] = new SqlParameter("@ERDAOA_ExpectIDate", SqlDbType.DateTime);
            parm[2].Value = ERDAOA_ExpectIDate;
            parm[3] = new SqlParameter("@ERDAOA_ExpectCost", SqlDbType.Decimal);
            parm[3].Value = ERDAOA_ExpectCost;
            parm[4] = new SqlParameter("@ERDAOA_PerInCharge", SqlDbType.VarChar, 20);
            parm[4].Value = ERDAOA_PerInCharge;
            parm[5] = new SqlParameter("@ERDAOA_RecordDate", SqlDbType.DateTime);
            parm[5].Value = ERDAOA_RecordDate;
            parm[6] = new SqlParameter("@ERDAOA_OAppState", SqlDbType.VarChar, 20);
            parm[6].Value = ERDAOA_OAppState;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_EquipRealDetailAOApp_CCYS", parm);
        }
        //财务审核
        public void Update_EquipRealDetailAOApp_CCSH(Guid ERDAOA_ID, string ERDAOA_FinanPer, DateTime ERDAOA_FinanTime, string ERDAOA_FinanSugg, string ERDAOA_FinanRes, string ERDAOA_OAppState)
        {
            SqlParameter[] parm = new SqlParameter[6];
            parm[0] = new SqlParameter("@ERDAOA_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = ERDAOA_ID;
            parm[1] = new SqlParameter("@ERDAOA_FinanPer", SqlDbType.VarChar, 20);
            parm[1].Value = ERDAOA_FinanPer;
            parm[2] = new SqlParameter("@ERDAOA_FinanTime", SqlDbType.DateTime);
            parm[2].Value = ERDAOA_FinanTime;
            parm[3] = new SqlParameter("@ERDAOA_FinanSugg", SqlDbType.VarChar, 400);
            parm[3].Value = ERDAOA_FinanSugg;
            parm[4] = new SqlParameter("@ERDAOA_FinanRes", SqlDbType.VarChar, 20);
            parm[4].Value = ERDAOA_FinanRes;
            parm[5] = new SqlParameter("@ERDAOA_OAppState", SqlDbType.VarChar, 20);
            parm[5].Value = ERDAOA_OAppState;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_EquipRealDetailAOApp_CCSH", parm);
        }
        //出厂维修确认
        public void Update_EquipRealDetailAOApp_CCQR(Guid ERDAOA_ID, string ERDAOA_OConfirmor, DateTime ERDAOA_OCTime, string ERDAOA_OAppState)
        {
            SqlParameter[] parm = new SqlParameter[4];
            parm[0] = new SqlParameter("@ERDAOA_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = ERDAOA_ID;
            parm[1] = new SqlParameter("@ERDAOA_OConfirmor", SqlDbType.VarChar, 20);
            parm[1].Value = ERDAOA_OConfirmor;
            parm[2] = new SqlParameter("@ERDAOA_OCTime", SqlDbType.DateTime);
            parm[2].Value = ERDAOA_OCTime;
            parm[3] = new SqlParameter("@ERDAOA_OAppState", SqlDbType.VarChar, 20);
            parm[3].Value = ERDAOA_OAppState;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_EquipRealDetailAOApp_CCQR", parm);
        }
        //完善回厂信息
        public void Update_EquipRealDetailAOApp_CCWS(Guid ERDAOA_ID, DateTime ERDAOA_ActODate, DateTime ERDAOA_ActIDate, decimal ERDAOA_ActCost,
                                                        string ERDAOA_PerfectPer, DateTime ERDAOA_PerfectTime, string ERDAOA_OAppState)
        {
            SqlParameter[] parm = new SqlParameter[7];
            parm[0] = new SqlParameter("@ERDAOA_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = ERDAOA_ID;
            parm[1] = new SqlParameter("@ERDAOA_ActODate", SqlDbType.DateTime);
            parm[1].Value = ERDAOA_ActODate;
            parm[2] = new SqlParameter("@ERDAOA_ActIDate", SqlDbType.DateTime);
            parm[2].Value = ERDAOA_ActIDate;
            parm[3] = new SqlParameter("@ERDAOA_ActCost", SqlDbType.Decimal);
            parm[3].Value = ERDAOA_ActCost;
            parm[4] = new SqlParameter("@ERDAOA_PerfectPer", SqlDbType.VarChar, 20);
            parm[4].Value = ERDAOA_PerfectPer;
            parm[5] = new SqlParameter("@ERDAOA_PerfectTime", SqlDbType.DateTime);
            parm[5].Value = ERDAOA_PerfectTime;
            parm[6] = new SqlParameter("@ERDAOA_OAppState", SqlDbType.VarChar, 20);
            parm[6].Value = ERDAOA_OAppState;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_EquipRealDetailAOApp_CCWS", parm);
        }
        //财务确认
        public void Update_EquipRealDetailAOApp_CCCW(Guid ERDAOA_ID, string ERDAOA_FinanConfirmor, DateTime ERDAOA_FCTime, string ERDAOA_OAppState)
        {
            SqlParameter[] parm = new SqlParameter[4];
            parm[0] = new SqlParameter("@ERDAOA_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = ERDAOA_ID;
            parm[1] = new SqlParameter("@ERDAOA_FinanConfirmor", SqlDbType.VarChar, 20);
            parm[1].Value = ERDAOA_FinanConfirmor;
            parm[2] = new SqlParameter("@ERDAOA_FCTime", SqlDbType.DateTime);
            parm[2].Value = ERDAOA_FCTime;
            parm[3] = new SqlParameter("@ERDAOA_OAppState", SqlDbType.VarChar, 20);
            parm[3].Value = ERDAOA_OAppState;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_EquipRealDetailAOApp_CCCW", parm);
        }
    }
}