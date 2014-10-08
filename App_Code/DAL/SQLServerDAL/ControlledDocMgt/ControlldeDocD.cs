using System;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
///ControlldeDoc 的摘要说明
/// </summary>
namespace EquipmentMangementAjax.SQLServer
{
    public class ControlldeDocD : IControlldeDoc
    {
        public ControlldeDocD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        //增加受控文件申请
        public Guid Insert_ControlledDocApp(string CDA_DocName, string CDA_EditionNO, string CDA_DocType, string CDA_ChangedType, string CDA_AppPer, DateTime CDA_AppTime,
                                   string CDA_AppDep, string CDA_AppReason, string CDA_AppState, string CDA_Remarks, string CDA_DocRoute, string CDTLC_DocType, DateTime CDA_EffectDate)
        {
            SqlParameter[] parm = new SqlParameter[14];
            parm[0] = new SqlParameter("@CDA_ID", SqlDbType.UniqueIdentifier);
            parm[0].Direction = ParameterDirection.Output;
            parm[1] = new SqlParameter("@CDA_DocName", SqlDbType.VarChar, 100);
            parm[1].Value = CDA_DocName;
            parm[2] = new SqlParameter("@CDA_EditionNO", SqlDbType.VarChar, 8);
            parm[2].Value = CDA_EditionNO;
            parm[3] = new SqlParameter("@CDA_DocType", SqlDbType.VarChar, 20);
            parm[3].Value = CDA_DocType;
            parm[4] = new SqlParameter("@CDA_ChangedType", SqlDbType.VarChar, 20);
            parm[4].Value = CDA_ChangedType;
            parm[5] = new SqlParameter("@CDA_AppPer", SqlDbType.VarChar, 20);
            parm[5].Value = CDA_AppPer;
            parm[6] = new SqlParameter("@CDA_AppTime", SqlDbType.DateTime);
            parm[6].Value = CDA_AppTime;
            parm[7] = new SqlParameter("@CDA_AppDep", SqlDbType.VarChar, 50);
            parm[7].Value = CDA_AppDep;
            parm[8] = new SqlParameter("@CDA_AppReason", SqlDbType.VarChar, 400);
            parm[8].Value = CDA_AppReason;
            parm[9] = new SqlParameter("@CDA_AppState", SqlDbType.VarChar, 20);
            parm[9].Value = CDA_AppState;
            parm[10] = new SqlParameter("@CDA_Remarks", SqlDbType.VarChar, 400);
            parm[10].Value = CDA_Remarks;
            parm[11] = new SqlParameter("@CDA_DocRoute", SqlDbType.VarChar, 100);
            parm[11].Value = CDA_DocRoute;
            parm[12] = new SqlParameter("@CDTLC_DocType", SqlDbType.VarChar, 40);
            parm[12].Value = CDTLC_DocType;
            parm[13] = new SqlParameter("@CDA_EffectDate", SqlDbType.DateTime);
            parm[13].Value = CDA_EffectDate;
            Guid aa=SqlHelper.ExecuteReturnGuidQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_ControlledDocApp", parm);
            return aa;
        }
        //修改受控文件申请表
        public void Update_ControlledDocApp(Guid CDA_ID, string CDA_DocName, string CDA_EditionNO, string CDA_AppPer, DateTime CDA_AppTime,string CDA_AppReason,
                                            string CDA_AppState, string CDA_Remarks, string CDA_ChangedType, DateTime CDA_EffectDate)
        {
            SqlParameter[] parm = new SqlParameter[10];
            parm[0] = new SqlParameter("@CDA_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = CDA_ID;
            parm[1] = new SqlParameter("@CDA_DocName", SqlDbType.VarChar, 100);
            parm[1].Value = CDA_DocName;
            parm[2] = new SqlParameter("@CDA_EditionNO", SqlDbType.VarChar, 8);
            parm[2].Value = CDA_EditionNO;
            parm[3] = new SqlParameter("@CDA_AppPer", SqlDbType.VarChar, 20);
            parm[3].Value = CDA_AppPer;
            parm[4] = new SqlParameter("@CDA_AppTime", SqlDbType.DateTime);
            parm[4].Value = CDA_AppTime;
            parm[5] = new SqlParameter("@CDA_AppReason", SqlDbType.VarChar, 400);
            parm[5].Value = CDA_AppReason;
            parm[6] = new SqlParameter("@CDA_AppState", SqlDbType.VarChar, 20);
            parm[6].Value = CDA_AppState;
            parm[7] = new SqlParameter("@CDA_Remarks", SqlDbType.VarChar, 400);
            parm[7].Value = CDA_Remarks;
            parm[8] = new SqlParameter("@CDA_ChangedType", SqlDbType.VarChar, 20);
            parm[8].Value = CDA_ChangedType;
            parm[9] = new SqlParameter("@CDA_EffectDate", SqlDbType.DateTime);
            parm[9].Value = CDA_EffectDate;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_ControlledDocApp", parm);
        }
        //删除受控文件申请表
        public int Delete_ControlledDocApp(Guid CDA_ID)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@CDA_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = CDA_ID;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_ControlledDocApp", parm);
        }
        //查询受控文件申请
        public DataSet Search_ControlledDocApp_APP(string condition)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@Condition", SqlDbType.VarChar, 8000);
            parm[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_ControlledDocApp_APP", parm);
        }
        //文件类别(第三层次文件类别)下拉框绑定
        public DataSet Search_CDThirdLevelCode_DocType()
        {
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_CDThirdLevelCode_DocType");
        }
        //选择分发的岗位
        public void Insert_CDDepDistributeDetail(Guid CDDDCT_ID, Guid CDA_ID)
        {
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@CDDDCT_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = CDDDCT_ID;
            parm[1] = new SqlParameter("@CDA_ID", SqlDbType.UniqueIdentifier);
            parm[1].Value = CDA_ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_I_CDDepDistributeDetail", parm);
        }
        //查找已选的岗位
        public DataSet Search_CDDepDistributeDetail(string condition)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            parm[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_CDDepDistributeDetail", parm);
        }
        //删除已选的岗位
        public int Delete_CDDepDistributeDetail(Guid CDDDD_ID)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@CDDDD_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = CDDDD_ID;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_CDDepDistributeDetail", parm);
        }
        //选择会签部门时,先查找部门
        public DataSet Search_BDOrganization_CDAppConSignT(string condition)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            parm[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_BDOrganization_CDAppConSignT", parm);
        }
        //选择会签部门
        public void Insert_CDAppConSignT(string  BDOS_Code, Guid CDA_ID)
        {
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@BDOS_Code", SqlDbType.VarChar,60);
            parm[0].Value = BDOS_Code;
            parm[1] = new SqlParameter("@CDA_ID", SqlDbType.UniqueIdentifier);
            parm[1].Value = CDA_ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_I_CDAppConSignT", parm);
        }
        //查找已选的会签部门
        public DataSet Search_CDAppConSignT(string condition)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            parm[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_CDAppConSignT", parm);
        }
        //删除已选的会签部门
        public int Delete_CDAppConSignT(Guid CDAST_ID)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@CDAST_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = CDAST_ID;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_CDAppConSignT", parm);
        }
        //特殊文件编号
        public void Update_ControlledDocApp_specil(Guid CDA_ID, string CDA_DocNO)
        {
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@CDA_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = CDA_ID;
            parm[1] = new SqlParameter("@CDA_DocNO", SqlDbType.VarChar, 50);
            parm[1].Value = CDA_DocNO;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_ControlledDocApp_specil", parm);
        }
        //受控文件审核
        public void Update_ControlledDocApp_Au(Guid CDA_ID, string CDA_Auditor, DateTime CDA_AuTime, string CDA_AuSugg, string ETA_AuRes, string CDA_AppState)
        {
            SqlParameter[] parm = new SqlParameter[6];
            parm[0] = new SqlParameter("@CDA_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = CDA_ID;
            parm[1] = new SqlParameter("@CDA_Auditor", SqlDbType.VarChar, 20);
            parm[1].Value = CDA_Auditor;
            parm[2] = new SqlParameter("@CDA_AuTime", SqlDbType.DateTime);
            parm[2].Value = CDA_AuTime;
            parm[3] = new SqlParameter("@CDA_AuSugg", SqlDbType.VarChar, 400);
            parm[3].Value = CDA_AuSugg;
            parm[4] = new SqlParameter("@ETA_AuRes", SqlDbType.VarChar, 20);
            parm[4].Value = ETA_AuRes;
            parm[5] = new SqlParameter("@CDA_AppState", SqlDbType.VarChar, 20);
            parm[5].Value = CDA_AppState;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_ControlledDocApp_Au", parm);
        }
        //受控文件审批
        public void Update_ControlledDocApp_Approval(Guid CDA_ID, string CDA_Approver, DateTime CDA_ApprovalT, string CDA_ApprovalSugg, string CDA_ApprovalRes, string CDA_AppState)
        {
            SqlParameter[] parm = new SqlParameter[6];
            parm[0] = new SqlParameter("@CDA_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = CDA_ID;
            parm[1] = new SqlParameter("@CDA_Approver", SqlDbType.VarChar, 20);
            parm[1].Value = CDA_Approver;
            parm[2] = new SqlParameter("@CDA_ApprovalT", SqlDbType.DateTime);
            parm[2].Value = CDA_ApprovalT;
            parm[3] = new SqlParameter("@CDA_ApprovalSugg", SqlDbType.VarChar, 400);
            parm[3].Value = CDA_ApprovalSugg;
            parm[4] = new SqlParameter("@CDA_ApprovalRes", SqlDbType.VarChar, 20);
            parm[4].Value = CDA_ApprovalRes;
            parm[5] = new SqlParameter("@CDA_AppState", SqlDbType.VarChar, 20);
            parm[5].Value = CDA_AppState;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_ControlledDocApp_Approval", parm);
        }
        //部门会签
        public void Update_CDAppConSignT(Guid CDAST_ID, string CDAST_SignPer, DateTime CDAST_SignTime, string CDAST_SignSugg, string CDAST_SignRes)
        {
            SqlParameter[] parm = new SqlParameter[5];
            parm[0] = new SqlParameter("@CDAST_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = CDAST_ID;
            parm[1] = new SqlParameter("@CDAST_SignPer", SqlDbType.VarChar, 20);
            parm[1].Value = CDAST_SignPer;
            parm[2] = new SqlParameter("@CDAST_SignTime", SqlDbType.DateTime);
            parm[2].Value = CDAST_SignTime;
            parm[3] = new SqlParameter("@CDAST_SignSugg", SqlDbType.VarChar, 400);
            parm[3].Value = CDAST_SignSugg;
            parm[4] = new SqlParameter("@CDAST_SignRes", SqlDbType.VarChar, 20);
            parm[4].Value = CDAST_SignRes;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_CDAppConSignT", parm);
        }
        //会签后，受控文件申请状态
        public void Update_ControlledDocApp_State(Guid CDA_ID)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@CDA_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = CDA_ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_ControlledDocApp_State", parm);
        }
        //增加受控文件申请--换版的情况，受控文件编号不变
        public Guid Insert_ControlledDocApp_change(string CDA_DocNO,string CDA_DocName, string CDA_EditionNO, string CDA_DocType, string CDA_ChangedType, string CDA_AppPer, DateTime CDA_AppTime,
                                            string CDA_AppDep, string CDA_AppReason, string CDA_AppState, string CDA_Remarks, string CDA_DocRoute, DateTime CDA_EffectDate)
        {
            SqlParameter[] parm = new SqlParameter[14];
            parm[0] = new SqlParameter("@CDA_ID", SqlDbType.UniqueIdentifier);
            parm[0].Direction = ParameterDirection.Output;
            parm[1] = new SqlParameter("@CDA_DocNO", SqlDbType.VarChar, 50);
            parm[1].Value = CDA_DocNO;
            parm[2] = new SqlParameter("@CDA_DocName", SqlDbType.VarChar, 100);
            parm[2].Value = CDA_DocName;
            parm[3] = new SqlParameter("@CDA_EditionNO", SqlDbType.VarChar, 8);
            parm[3].Value = CDA_EditionNO;
            parm[4] = new SqlParameter("@CDA_DocType", SqlDbType.VarChar, 20);
            parm[4].Value = CDA_DocType;
            parm[5] = new SqlParameter("@CDA_ChangedType", SqlDbType.VarChar, 20);
            parm[5].Value = CDA_ChangedType;
            parm[6] = new SqlParameter("@CDA_AppPer", SqlDbType.VarChar, 20);
            parm[6].Value = CDA_AppPer;
            parm[7] = new SqlParameter("@CDA_AppTime", SqlDbType.DateTime);
            parm[7].Value = CDA_AppTime;
            parm[8] = new SqlParameter("@CDA_AppDep", SqlDbType.VarChar, 50);
            parm[8].Value = CDA_AppDep;
            parm[9] = new SqlParameter("@CDA_AppReason", SqlDbType.VarChar, 400);
            parm[9].Value = CDA_AppReason;
            parm[10] = new SqlParameter("@CDA_AppState", SqlDbType.VarChar, 20);
            parm[10].Value = CDA_AppState;
            parm[11] = new SqlParameter("@CDA_Remarks", SqlDbType.VarChar, 400);
            parm[11].Value = CDA_Remarks;
            parm[12] = new SqlParameter("@CDA_DocRoute", SqlDbType.VarChar, 100);
            parm[12].Value = CDA_DocRoute;
            parm[13] = new SqlParameter("@CDA_EffectDate", SqlDbType.DateTime);
            parm[13].Value = CDA_EffectDate;
            Guid bb = SqlHelper.ExecuteReturnGuidQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_ControlledDocApp_change", parm);
            return bb;
        }
        //换版的时候，判断是不是在最新版的基础上换版的
        public DataSet Search_ControlledDocApp_change_newest(string CDA_DocNO)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@CDA_DocNO", SqlDbType.VarChar, 50);
            parm[0].Value = CDA_DocNO;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_ControlledDocApp_change_newest", parm);
        }
        //增加受控文件申请--特殊通道
        public void Insert_ControlledDocApp_Specil(string CDA_DocNO, string CDA_DocName, string CDA_EditionNO, string CDA_DocType, string CDA_ChangedType, string CDA_AppPer, DateTime CDA_AppTime,
                                            string CDA_AppDep, string CDA_AppReason, string CDA_AppState, string CDA_Remarks, string CDA_DocRoute, string CDTLC_DocType, string CDA_AppNO, DateTime CDA_EffectDate)
        {
            SqlParameter[] parm = new SqlParameter[15];
            parm[0] = new SqlParameter("@CDA_DocNO", SqlDbType.VarChar, 50);
            parm[0].Value = CDA_DocNO;
            parm[1] = new SqlParameter("@CDA_DocName", SqlDbType.VarChar, 100);
            parm[1].Value = CDA_DocName;
            parm[2] = new SqlParameter("@CDA_EditionNO", SqlDbType.VarChar, 8);
            parm[2].Value = CDA_EditionNO;
            parm[3] = new SqlParameter("@CDA_DocType", SqlDbType.VarChar, 20);
            parm[3].Value = CDA_DocType;
            parm[4] = new SqlParameter("@CDA_ChangedType", SqlDbType.VarChar, 20);
            parm[4].Value = CDA_ChangedType;
            parm[5] = new SqlParameter("@CDA_AppPer", SqlDbType.VarChar, 20);
            parm[5].Value = CDA_AppPer;
            parm[6] = new SqlParameter("@CDA_AppTime", SqlDbType.DateTime);
            parm[6].Value = CDA_AppTime;
            parm[7] = new SqlParameter("@CDA_AppDep", SqlDbType.VarChar, 50);
            parm[7].Value = CDA_AppDep;
            parm[8] = new SqlParameter("@CDA_AppReason", SqlDbType.VarChar, 400);
            parm[8].Value = CDA_AppReason;
            parm[9] = new SqlParameter("@CDA_AppState", SqlDbType.VarChar, 20);
            parm[9].Value = CDA_AppState;
            parm[10] = new SqlParameter("@CDA_Remarks", SqlDbType.VarChar, 400);
            parm[10].Value = CDA_Remarks;
            parm[11] = new SqlParameter("@CDA_DocRoute", SqlDbType.VarChar, 100);
            parm[11].Value = CDA_DocRoute;
            parm[12] = new SqlParameter("@CDTLC_DocType", SqlDbType.VarChar, 40);
            parm[12].Value = CDTLC_DocType;
            parm[13] = new SqlParameter("@CDA_AppNO", SqlDbType.VarChar, 20);
            parm[13].Value = CDA_AppNO;
            parm[14] = new SqlParameter("@CDA_EffectDate", SqlDbType.DateTime);
            parm[14].Value = CDA_EffectDate;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_I_ControlledDocApp_Specil", parm);
        }
        //特殊通道--修改受控文件编号
        public void Update_ControlledDocApp_Specil_No(Guid CDA_ID, string CDA_DocNO, string CDA_AppNO)
        {
            SqlParameter[] parm = new SqlParameter[3];
            parm[0] = new SqlParameter("@CDA_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = CDA_ID;
            parm[1] = new SqlParameter("@CDA_DocNO", SqlDbType.VarChar, 50);
            parm[1].Value = CDA_DocNO;
            parm[2] = new SqlParameter("@CDA_AppNO", SqlDbType.VarChar, 20);
            parm[2].Value = CDA_AppNO;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_ControlledDocApp_Specil_No", parm);
        }
    }
}