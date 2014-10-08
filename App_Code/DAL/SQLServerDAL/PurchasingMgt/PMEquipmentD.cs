using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
///PMEquipmentD 的摘要说明
/// </summary>
namespace EquipmentMangementAjax.SQLServer
{
    public class PMEquipmentD : IPMEquipment
{
	public PMEquipmentD()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    //查找设备采购申请单
    public DataSet SelectPMEquipmentApply(string condition)
    {
        SqlParameter parm = new SqlParameter("@Condition", condition);
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_PMEquipmentApply", parm);
    }
    //新增设备采购申请单
    public void InsertPMEquipmentApply(PMEquipmentinfo pMEquipmentinfo)
    {
        SqlParameter[] parm = new SqlParameter[10];

        parm[0] = new SqlParameter("@IMMBD_MaterialID", SqlDbType.UniqueIdentifier);
        parm[0].Value = pMEquipmentinfo.IMMBD_MaterialID;
        parm[1] = new SqlParameter("@PMEA_ApplyDepert", SqlDbType.VarChar,200);
        parm[1].Value = pMEquipmentinfo.PMEA_ApplyDepert;
        parm[2] = new SqlParameter("@PMEA_Model", SqlDbType.VarChar,100);
        parm[2].Value = pMEquipmentinfo.PMEA_Model;
        parm[3] = new SqlParameter("@PMEA_Num", SqlDbType.Decimal);
        parm[3].Value = pMEquipmentinfo.PMEA_Num;
        parm[4] = new SqlParameter("@PMEA_InstallLocation", SqlDbType.VarChar,200);
        parm[4].Value = pMEquipmentinfo.PMEA_InstallLocation;
        parm[5] = new SqlParameter("@PMEA_NeedTime", SqlDbType.DateTime);
        parm[5].Value = pMEquipmentinfo.PMEA_NeedTime;
        parm[6] = new SqlParameter("@PMEA_BuyReason", SqlDbType.VarChar,400);
        parm[6].Value = pMEquipmentinfo.PMEA_BuyReason;
        parm[7] = new SqlParameter("@PMEA_TechRequire", SqlDbType.VarChar, 4000);
        parm[7].Value = pMEquipmentinfo.PMEA_TechRequire;
        parm[8] = new SqlParameter("@PMEAC_SignPartment", SqlDbType.VarChar, 200);
        parm[8].Value = pMEquipmentinfo.PMEAC_SignPartment;
        parm[9] = new SqlParameter("@PMEAC_State", SqlDbType.VarChar, 20);
        parm[9].Value = pMEquipmentinfo.PMEAC_State;
        SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                 CommandType.StoredProcedure, "Proc_I_PMEquipmentApply", parm);
    }
    //修改设备采购申请单
    public void UpdatePMEquipmentApply(PMEquipmentinfo pMEquipmentinfo)
    {
        SqlParameter[] parm = new SqlParameter[9];

        parm[0] = new SqlParameter("@PMEA_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = pMEquipmentinfo.PMEA_ID;
        parm[1] = new SqlParameter("@IMMBD_MaterialID ", SqlDbType.UniqueIdentifier);
        parm[1].Value = pMEquipmentinfo.IMMBD_MaterialID;
        parm[2] = new SqlParameter("@PMEA_ApplyDepert", SqlDbType.VarChar,200);
        parm[2].Value = pMEquipmentinfo.PMEA_ApplyDepert;
        parm[3] = new SqlParameter("@PMEA_Model", SqlDbType.VarChar, 100);
        parm[3].Value = pMEquipmentinfo.PMEA_Model;
        parm[4] = new SqlParameter("@PMEA_Num", SqlDbType.Decimal);
        parm[4].Value = pMEquipmentinfo.PMEA_Num;
        parm[5] = new SqlParameter("@PMEA_InstallLocation", SqlDbType.VarChar,200);
        parm[5].Value = pMEquipmentinfo.PMEA_InstallLocation;
        parm[6] = new SqlParameter("@PMEA_NeedTime", SqlDbType.DateTime);
        parm[6].Value = pMEquipmentinfo.PMEA_NeedTime;
        parm[7] = new SqlParameter("@PMEA_BuyReason", SqlDbType.VarChar,400);
        parm[7].Value = pMEquipmentinfo.PMEA_BuyReason;
        parm[8] = new SqlParameter("@PMEA_TechRequire", SqlDbType.VarChar, 4000);
        parm[8].Value = pMEquipmentinfo.PMEA_TechRequire;
        SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                 CommandType.StoredProcedure, "Proc_U_PMEquipmentApply", parm);
    }
    //申请部门部长审核
    public void UpdatePMEA_ApplyDepartCheck(PMEquipmentinfo pMEquipmentinfo)
    {
        SqlParameter[] parm = new SqlParameter[5];

        parm[0] = new SqlParameter("@PMEA_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = pMEquipmentinfo.PMEA_ID;
        parm[1] = new SqlParameter("@PMEA_ApplyDepartCheckResult", SqlDbType.VarChar, 20);
        parm[1].Value = pMEquipmentinfo.PMEA_ApplyDepartCheckResult;
        parm[2] = new SqlParameter("@PMEA_ApplyDepartCheckOpinion", SqlDbType.VarChar,400);
        parm[2].Value = pMEquipmentinfo.PMEA_ApplyDepartCheckOpinion;
        parm[3] = new SqlParameter("@PMEA_ApplyState", SqlDbType.VarChar,20);
        parm[3].Value = pMEquipmentinfo.PMEA_ApplyState;
        parm[4] = new SqlParameter("@PMEA_ApplyDepartCheckMan", SqlDbType.VarChar, 20);
        parm[4].Value = pMEquipmentinfo.PMEA_ApplyDepartCheckMan;
        SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                 CommandType.StoredProcedure, "Proc_U_PMEA_ApplyDepartCheck", parm);
    }
    //生产部部长审核
    public void UpdatePMEA_PDCheck(PMEquipmentinfo pMEquipmentinfo)
    {
        SqlParameter[] parm = new SqlParameter[5];

        parm[0] = new SqlParameter("@PMEA_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = pMEquipmentinfo.PMEA_ID;
        parm[1] = new SqlParameter("@PMEA_PDCheckResult", SqlDbType.VarChar, 20);
        parm[1].Value = pMEquipmentinfo.PMEA_PDCheckResult;
        parm[2] = new SqlParameter("@PMEA_PDCheckOpinion", SqlDbType.VarChar, 400);
        parm[2].Value = pMEquipmentinfo.PMEA_PDCheckOpinion;
        parm[3] = new SqlParameter("@PMEA_ApplyState", SqlDbType.VarChar, 20);
        parm[3].Value = pMEquipmentinfo.PMEA_ApplyState;
        parm[4] = new SqlParameter("@PMEA_PDCheckMan", SqlDbType.VarChar, 20);
        parm[4].Value = pMEquipmentinfo.PMEA_PDCheckMan;
        SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                 CommandType.StoredProcedure, "Proc_U_PMEA_PDCheck", parm);
    }
    //设备部部长审核
    public void UpdatePMEA_EDDCheck(PMEquipmentinfo pMEquipmentinfo)
    {
        SqlParameter[] parm = new SqlParameter[5];

        parm[0] = new SqlParameter("@PMEA_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = pMEquipmentinfo.PMEA_ID;
        parm[1] = new SqlParameter("@PMEA_EDDCheckResult", SqlDbType.VarChar, 20);
        parm[1].Value = pMEquipmentinfo.PMEA_EDDCheckResult;
        parm[2] = new SqlParameter("@PMEA_EDDCheckOpinion", SqlDbType.VarChar, 400);
        parm[2].Value = pMEquipmentinfo.PMEA_EDDCheckOpinion;
        parm[3] = new SqlParameter("@PMEA_ApplyState", SqlDbType.VarChar, 20);
        parm[3].Value = pMEquipmentinfo.PMEA_ApplyState;
        parm[4] = new SqlParameter("@PMEA_EDDCheckMan", SqlDbType.VarChar, 20);
        parm[4].Value = pMEquipmentinfo.PMEA_EDDCheckMan;
        SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                 CommandType.StoredProcedure, "Proc_U_PMEA_EDDCheck", parm);
    }
    //工程部部长审核
    public void UpdatePMEA_EDCheck(PMEquipmentinfo pMEquipmentinfo)
    {
        SqlParameter[] parm = new SqlParameter[5];

        parm[0] = new SqlParameter("@PMEA_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = pMEquipmentinfo.PMEA_ID;
        parm[1] = new SqlParameter("@PMEA_EDCheckResult", SqlDbType.VarChar, 20);
        parm[1].Value = pMEquipmentinfo.PMEA_EDCheckResult;
        parm[2] = new SqlParameter("@PMEA_EDCheckOpinion", SqlDbType.VarChar, 400);
        parm[2].Value = pMEquipmentinfo.PMEA_EDCheckOpinion;
        parm[3] = new SqlParameter("@PMEA_ApplyState", SqlDbType.VarChar, 20);
        parm[3].Value = pMEquipmentinfo.PMEA_ApplyState;
        parm[4] = new SqlParameter("@PMEA_EDCheckMan", SqlDbType.VarChar, 20);
        parm[4].Value = pMEquipmentinfo.PMEA_EDCheckMan;
        SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                 CommandType.StoredProcedure, "Proc_U_PMEA_EDCheck", parm);
    }
    //品保部部长审核
    public void UpdatePMEA_QACheck(PMEquipmentinfo pMEquipmentinfo)
    {
        SqlParameter[] parm = new SqlParameter[5];

        parm[0] = new SqlParameter("@PMEA_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = pMEquipmentinfo.PMEA_ID;
        parm[1] = new SqlParameter("@PMEA_QACheckResult", SqlDbType.VarChar, 20);
        parm[1].Value = pMEquipmentinfo.PMEA_QACheckResult;
        parm[2] = new SqlParameter("@PMEA_QACheckOpinion", SqlDbType.VarChar, 400);
        parm[2].Value = pMEquipmentinfo.PMEA_QACheckOpinion;
        parm[3] = new SqlParameter("@PMEA_ApplyState", SqlDbType.VarChar, 20);
        parm[3].Value = pMEquipmentinfo.PMEA_ApplyState;
        parm[4] = new SqlParameter("@PMEA_QACheckMan", SqlDbType.VarChar, 20);
        parm[4].Value = pMEquipmentinfo.PMEA_QACheckMan;
        SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                 CommandType.StoredProcedure, "Proc_U_PMEA_QACheck", parm);
    }
    //技术副总审核
    public void UpdatePMEA_DMCheck(PMEquipmentinfo pMEquipmentinfo)
    {
        SqlParameter[] parm = new SqlParameter[5];

        parm[0] = new SqlParameter("@PMEA_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = pMEquipmentinfo.PMEA_ID;
        parm[1] = new SqlParameter("@PMEA_DMCheckResult", SqlDbType.VarChar, 20);
        parm[1].Value = pMEquipmentinfo.PMEA_DMCheckResult;
        parm[2] = new SqlParameter("@PMEA_DMCheckOpinion", SqlDbType.VarChar, 400);
        parm[2].Value = pMEquipmentinfo.PMEA_DMCheckOpinion;
        parm[3] = new SqlParameter("@PMEA_ApplyState", SqlDbType.VarChar, 20);
        parm[3].Value = pMEquipmentinfo.PMEA_ApplyState;
        parm[4] = new SqlParameter("@PMEA_DMCheckMan", SqlDbType.VarChar, 20);
        parm[4].Value = pMEquipmentinfo.PMEA_DMCheckMan;
        SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                 CommandType.StoredProcedure, "Proc_U_PMEA_DMCheck", parm);
    }
    //总经理审核
    public void UpdatePMEA_GMCheck(PMEquipmentinfo pMEquipmentinfo)
    {
        SqlParameter[] parm = new SqlParameter[5];

        parm[0] = new SqlParameter("@PMEA_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = pMEquipmentinfo.PMEA_ID;
        parm[1] = new SqlParameter("@PMEA_GMCheckResult", SqlDbType.VarChar, 20);
        parm[1].Value = pMEquipmentinfo.PMEA_GMCheckResult;
        parm[2] = new SqlParameter("@PMEA_GMCheckOpinion", SqlDbType.VarChar, 400);
        parm[2].Value = pMEquipmentinfo.PMEA_GMCheckOpinion;
        parm[3] = new SqlParameter("@PMEA_ApplyState", SqlDbType.VarChar, 20);
        parm[3].Value = pMEquipmentinfo.PMEA_ApplyState;
        parm[4] = new SqlParameter("@PMEA_GMCheckMan", SqlDbType.VarChar, 20);
        parm[4].Value = pMEquipmentinfo.PMEA_GMCheckMan;
        SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                 CommandType.StoredProcedure, "Proc_U_PMEA_GMCheck", parm);
    }
       //新增采购订单
    public void InsertPMPurchaseOrder_Equipment(PMEquipmentinfo pMEquipmentinfo)
    {
        SqlParameter[] parm = new SqlParameter[17];

        parm[0] = new SqlParameter("@PMSI_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = pMEquipmentinfo.PMSI_ID;
        parm[1] = new SqlParameter("@PMPO_MakeMan", SqlDbType.VarChar, 20);
        parm[1].Value = pMEquipmentinfo.PMPO_MakeMan;
        parm[2] = new SqlParameter("@PMPO_PlanArrTime", SqlDbType.Date);
        parm[2].Value = pMEquipmentinfo.PMPO_PlanArrTime;
        parm[3] = new SqlParameter("@PMPO_PayRemindTime", SqlDbType.Date);
        parm[3].Value = pMEquipmentinfo.PMPO_PayRemindTime;
        parm[4] = new SqlParameter("@PMPO_PayWay", SqlDbType.VarChar, 20);
        parm[4].Value = pMEquipmentinfo.PMPO_PayWay;
        parm[5] = new SqlParameter("@PMPO_PaymentTime", SqlDbType.SmallInt);
        parm[5].Value = pMEquipmentinfo.PMPO_PaymentTime;
        parm[6] = new SqlParameter("@PMPO_TotalMoney", SqlDbType.Decimal);
        parm[6].Value = pMEquipmentinfo.PMPO_TotalMoney;
        parm[7] = new SqlParameter("@PMPO_State", SqlDbType.VarChar,20);
        parm[7].Value = pMEquipmentinfo.PMPO_State;
        parm[8] = new SqlParameter("@PMPO_Num", SqlDbType.Decimal);
        parm[8].Value = pMEquipmentinfo.PMPO_Num;
        parm[9] = new SqlParameter("@PMPOD_Num", SqlDbType.Decimal);
        parm[9].Value = pMEquipmentinfo.PMPOD_Num;
        parm[10] = new SqlParameter("@PMPOD_Price", SqlDbType.Decimal);
        parm[10].Value = pMEquipmentinfo.PMPOD_Price;
        parm[11] = new SqlParameter("@PMPOD_TotalMoney", SqlDbType.Decimal);
        parm[11].Value = pMEquipmentinfo.PMPOD_TotalMoney;
        parm[12] = new SqlParameter("@PMPOD_Remark", SqlDbType.VarChar, 400);
        parm[12].Value = pMEquipmentinfo.PMPOD_Remark;
        parm[13] = new SqlParameter("@IMMBD_MaterialID", SqlDbType.UniqueIdentifier);
        parm[13].Value = pMEquipmentinfo.IMMBD_MaterialID;
        parm[14] = new SqlParameter("@PMEA_ID", SqlDbType.UniqueIdentifier);
        parm[14].Value = pMEquipmentinfo.PMEA_ID;
        parm[15] = new SqlParameter("@PMEA_ApplyState", SqlDbType.VarChar,20);
        parm[15].Value = pMEquipmentinfo.PMEA_ApplyState;
        parm[16] = new SqlParameter("@IMUC_ID", SqlDbType.UniqueIdentifier);
        parm[16].Value = pMEquipmentinfo.IMUC_ID;
        SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                 CommandType.StoredProcedure, "Proc_I_PMPurchaseOrder_Equipment", parm);
    }
        //新增采购订单详细表
    public void InsertPMPurchaseOrderDetail_Equipment(PMEquipmentinfo pMEquipmentinfo)
    {
        SqlParameter[] parm = new SqlParameter[6];

        parm[0] = new SqlParameter("@PMPO_PurchaseOrderID", SqlDbType.UniqueIdentifier);
        parm[0].Value = pMEquipmentinfo.PMPO_PurchaseOrderID;
        parm[1] = new SqlParameter("@PMPOD_Num", SqlDbType.Decimal);
        parm[1].Value = pMEquipmentinfo.PMPOD_Num;
        parm[2] = new SqlParameter("@PMPOD_Price", SqlDbType.Decimal);
        parm[2].Value = pMEquipmentinfo.PMPOD_Price;
        parm[3] = new SqlParameter("@PMPOD_TotalMoney", SqlDbType.Decimal);
        parm[3].Value = pMEquipmentinfo.PMPOD_TotalMoney;
        parm[4] = new SqlParameter("@PMPOD_Remark", SqlDbType.VarChar, 400);
        parm[4].Value = pMEquipmentinfo.PMPOD_Remark;
        parm[5] = new SqlParameter("@IMMBD_MaterialID", SqlDbType.UniqueIdentifier);
        parm[5].Value = pMEquipmentinfo.IMMBD_MaterialID;
       
        SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                 CommandType.StoredProcedure, "Proc_I_PMPurchaseOrderDetail_Equipment", parm);
    }
    //查找设备对应供应商和设备采购申请部门
    public DataSet SelectPMSI_SDepart_Equipment(PMEquipmentinfo pMEquipmentinfo)
    {
        SqlParameter[] parm = new SqlParameter[1];

        parm[0] = new SqlParameter("@PMEA_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = pMEquipmentinfo.PMEA_ID;
      return  SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                 CommandType.StoredProcedure, "Proc_S_PMSI_SDepart_Equipment", parm);
    }
    //新增设备验收表
    public void InsertPMEquipmentCheckAccept(PMEquipmentinfo pMEquipmentinfo)
    {
        SqlParameter[] parm = new SqlParameter[9];

        parm[0] = new SqlParameter("@PMEA_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = pMEquipmentinfo.PMEA_ID;
        parm[1] = new SqlParameter("@PMECA_MainTechnologyPara", SqlDbType.VarChar,400);
        parm[1].Value = pMEquipmentinfo.PMECA_MainTechnologyPara;
        parm[2] = new SqlParameter("@PMECA_AddOn", SqlDbType.VarChar,400);
        parm[2].Value = pMEquipmentinfo.PMECA_AddOn;
        parm[3] = new SqlParameter("@PMECA_MECheck", SqlDbType.VarChar,400);
        parm[3].Value = pMEquipmentinfo.PMECA_MECheck;
        parm[4] = new SqlParameter("@PMECA_NullDebugInfo", SqlDbType.VarChar, 400);
        parm[4].Value = pMEquipmentinfo.PMECA_NullDebugInfo;
        parm[5] = new SqlParameter("@PMECA_DebugConclusion", SqlDbType.VarChar,400);
        parm[5].Value = pMEquipmentinfo.PMECA_DebugConclusion;
        parm[6] = new SqlParameter("@PMECA_OnDebugTime", SqlDbType.VarChar, 400);
        parm[6].Value = pMEquipmentinfo.PMECA_OnDebugTime;
        parm[7] = new SqlParameter("@PMECA_OnDebugInfo", SqlDbType.VarChar, 400);
        parm[7].Value = pMEquipmentinfo.PMECA_OnDebugInfo;
        parm[8] = new SqlParameter("@PMEA_ApplyState", SqlDbType.VarChar, 20);
        parm[8].Value = pMEquipmentinfo.PMEA_ApplyState;
        SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                 CommandType.StoredProcedure, "Proc_I_PMEquipmentCheckAccept", parm);
    }
       //修改设备验收表
    public void UpdatePMEquipmentCheckAccept(PMEquipmentinfo pMEquipmentinfo)
    {
        SqlParameter[] parm = new SqlParameter[8];

        parm[0] = new SqlParameter("@PMEA_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = pMEquipmentinfo.PMEA_ID;
        parm[1] = new SqlParameter("@PMECA_MainTechnologyPara", SqlDbType.VarChar, 400);
        parm[1].Value = pMEquipmentinfo.PMECA_MainTechnologyPara;
        parm[2] = new SqlParameter("@PMECA_AddOn", SqlDbType.VarChar, 400);
        parm[2].Value = pMEquipmentinfo.PMECA_AddOn;
        parm[3] = new SqlParameter("@PMECA_MECheck", SqlDbType.VarChar, 400);
        parm[3].Value = pMEquipmentinfo.PMECA_MECheck;
        parm[4] = new SqlParameter("@PMECA_NullDebugInfo", SqlDbType.VarChar, 400);
        parm[4].Value = pMEquipmentinfo.PMECA_NullDebugInfo;
        parm[5] = new SqlParameter("@PMECA_DebugConclusion", SqlDbType.VarChar, 400);
        parm[5].Value = pMEquipmentinfo.PMECA_DebugConclusion;
        parm[6] = new SqlParameter("@PMECA_OnDebugTime", SqlDbType.VarChar, 400);
        parm[6].Value = pMEquipmentinfo.PMECA_OnDebugTime;
        parm[7] = new SqlParameter("@PMECA_OnDebugInfo", SqlDbType.VarChar, 400);
        parm[7].Value = pMEquipmentinfo.PMECA_OnDebugInfo;
        SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                 CommandType.StoredProcedure, "Proc_U_PMEquipmentCheckAccept", parm);
    }
    //设备部验收审核
    public void UpdatePMECA_EDDCheck(PMEquipmentinfo pMEquipmentinfo)
    {
        SqlParameter[] parm = new SqlParameter[6];

        parm[0] = new SqlParameter("@PMECA_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = pMEquipmentinfo.PMECA_ID;
        parm[1] = new SqlParameter("@PMECA_EDDCheckResult", SqlDbType.VarChar, 20);
        parm[1].Value = pMEquipmentinfo.PMECA_EDDCheckResult;
        parm[2] = new SqlParameter("@PMECA_EDDCheckOpinion", SqlDbType.VarChar, 400);
        parm[2].Value = pMEquipmentinfo.PMECA_EDDCheckOpinion;
        parm[3] = new SqlParameter("@PMECA_EDDCheckMan", SqlDbType.VarChar, 20);
        parm[3].Value = pMEquipmentinfo.PMECA_EDDCheckMan;
        parm[4] = new SqlParameter("@PMEA_ApplyState", SqlDbType.VarChar, 20);
        parm[4].Value = pMEquipmentinfo.PMEA_ApplyState;
        parm[5] = new SqlParameter("@PMEA_ID", SqlDbType.UniqueIdentifier);
        parm[5].Value = pMEquipmentinfo.PMEA_ID;
        SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                 CommandType.StoredProcedure, "Proc_U_PMECA_EDDCheck", parm);
    }
    //生产部验收审核
    public void UpdatePMECA_PDCheck(PMEquipmentinfo pMEquipmentinfo)
    {
        SqlParameter[] parm = new SqlParameter[6];

        parm[0] = new SqlParameter("@PMECA_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = pMEquipmentinfo.PMECA_ID;
        parm[1] = new SqlParameter("@PMECA_PDCheckResult", SqlDbType.VarChar, 20);
        parm[1].Value = pMEquipmentinfo.PMECA_PDCheckResult;
        parm[2] = new SqlParameter("@PMECA_PDCheckOpinion", SqlDbType.VarChar, 400);
        parm[2].Value = pMEquipmentinfo.PMECA_PDCheckOpinion;
        parm[3] = new SqlParameter("@PMECA_PDCheckMan", SqlDbType.VarChar, 20);
        parm[3].Value = pMEquipmentinfo.PMECA_PDCheckMan;
        parm[4] = new SqlParameter("@PMEA_ApplyState", SqlDbType.VarChar, 20);
        parm[4].Value = pMEquipmentinfo.PMEA_ApplyState;
        parm[5] = new SqlParameter("@PMEA_ID", SqlDbType.UniqueIdentifier);
        parm[5].Value = pMEquipmentinfo.PMEA_ID;
        SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                 CommandType.StoredProcedure, "Proc_U_PMECA_PDCheck", parm);
    }
    //工程部验收审核
    public void UpdatePMECA_EDCheck(PMEquipmentinfo pMEquipmentinfo)
    {
        SqlParameter[] parm = new SqlParameter[6];

        parm[0] = new SqlParameter("@PMECA_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = pMEquipmentinfo.PMECA_ID;
        parm[1] = new SqlParameter("@PMECA_EDCheckResult", SqlDbType.VarChar, 20);
        parm[1].Value = pMEquipmentinfo.PMECA_EDCheckResult;
        parm[2] = new SqlParameter("@PMECA_EDCheckOpinion", SqlDbType.VarChar, 400);
        parm[2].Value = pMEquipmentinfo.PMECA_EDCheckOpinion;
        parm[3] = new SqlParameter("@PMECA_EDCheckMan", SqlDbType.VarChar, 20);
        parm[3].Value = pMEquipmentinfo.PMECA_EDCheckMan;
        parm[4] = new SqlParameter("@PMEA_ApplyState", SqlDbType.VarChar, 20);
        parm[4].Value = pMEquipmentinfo.PMEA_ApplyState;
        parm[5] = new SqlParameter("@PMEA_ID", SqlDbType.UniqueIdentifier);
        parm[5].Value = pMEquipmentinfo.PMEA_ID;
        SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                 CommandType.StoredProcedure, "Proc_U_PMECA_EDCheck", parm);
    }
    //品保部验收审核
    public void UpdatePMECA_QACheck(PMEquipmentinfo pMEquipmentinfo)
    {
        SqlParameter[] parm = new SqlParameter[6];

        parm[0] = new SqlParameter("@PMECA_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = pMEquipmentinfo.PMECA_ID;
        parm[1] = new SqlParameter("@PMECA_QACheckResult", SqlDbType.VarChar, 20);
        parm[1].Value = pMEquipmentinfo.PMECA_QACheckResult;
        parm[2] = new SqlParameter("@PMECA_QACheckOpinion", SqlDbType.VarChar, 400);
        parm[2].Value = pMEquipmentinfo.PMECA_QACheckOpinion;
        parm[3] = new SqlParameter("@PMECA_QACheckMan", SqlDbType.VarChar, 20);
        parm[3].Value = pMEquipmentinfo.PMECA_QACheckMan;
        parm[4] = new SqlParameter("@PMEA_ApplyState", SqlDbType.VarChar, 20);
        parm[4].Value = pMEquipmentinfo.PMEA_ApplyState;
        parm[5] = new SqlParameter("@PMEA_ID", SqlDbType.UniqueIdentifier);
        parm[5].Value = pMEquipmentinfo.PMEA_ID;
        SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                 CommandType.StoredProcedure, "Proc_U_PMECA_QACheck", parm);
    }
    //查找设备生产厂家
    public DataSet SelectPMESupply(PMEquipmentinfo pMEquipmentinfo)
    {
        SqlParameter[] parm = new SqlParameter[1];

        parm[0] = new SqlParameter("@PMPO_PurchaseOrderID", SqlDbType.UniqueIdentifier);
        parm[0].Value = pMEquipmentinfo.PMPO_PurchaseOrderID;
        
      return  SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                 CommandType.StoredProcedure, "Proc_S_PMESupply", parm);
    }
    //查找设备
    public DataSet SelectPMEMaterial(string condition)
    {
        SqlParameter parm = new SqlParameter("@Condition", condition);
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                   CommandType.StoredProcedure, "Proc_S_PMEMaterial",parm);
    }
    //查找设备验收表
    public DataSet SelectPMEquipmentCheckAccept(PMEquipmentinfo pMEquipmentinfo)
    {
        SqlParameter[] parm = new SqlParameter[1];

        parm[0] = new SqlParameter("@PMEA_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = pMEquipmentinfo.PMEA_ID;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                   CommandType.StoredProcedure, "Proc_S_PMEquipmentCheckAccept",parm);
    }
    //查找某一设备验收表
    public DataSet SelectPMEquipmentCheckAccept_One(PMEquipmentinfo pMEquipmentinfo)
    {
        SqlParameter[] parm = new SqlParameter[1];

        parm[0] = new SqlParameter("@PMECA_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = pMEquipmentinfo.PMECA_ID;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                   CommandType.StoredProcedure, "Proc_S_PMEquipmentCheckAccept_One",parm);
    }

    //查找某一设备费用历史
    public DataSet SelectEquipment_Cost(PMEquipmentinfo pMEquipmentinfo)
    {
        SqlParameter[] parm = new SqlParameter[1];

        parm[0] = new SqlParameter("@IMMBD_MaterialID", SqlDbType.UniqueIdentifier);
        parm[0].Value = pMEquipmentinfo.IMMBD_MaterialID;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                   CommandType.StoredProcedure, "Proc_S_PMEquipment_Cost", parm);
    }


    //新增设备采购申请审核部门
    public void InsertPMEquipmentApplyCountersign(PMEquipmentinfo pMEquipmentinfo)
    {

        SqlParameter[] parm = new SqlParameter[3];
        parm[0] = new SqlParameter("@PMEA_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = pMEquipmentinfo.PMEA_ID;
        parm[1] = new SqlParameter("@PMEAC_SignPartment", SqlDbType.VarChar, 200);
        parm[1].Value = pMEquipmentinfo.PMEAC_SignPartment;
        parm[2] = new SqlParameter("@PMEAC_State", SqlDbType.VarChar, 20);
        parm[2].Value = pMEquipmentinfo.PMEAC_State;
        SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                 CommandType.StoredProcedure, "Proc_I_PMEquipmentApplyCountersign", parm);
    }
    //修改设备采购申请审核表
    public void UpdatePMEquipmentApplyCountersign(PMEquipmentinfo pMEquipmentinfo)
    {
        SqlParameter[] parm = new SqlParameter[4];
        parm[0] = new SqlParameter("@PMEAC_SignResult", SqlDbType.VarChar, 20);
        parm[0].Value = pMEquipmentinfo.PMEAC_SignResult;
        parm[1] = new SqlParameter("@PMEAC_SignOpinion", SqlDbType.VarChar, 400);
        parm[1].Value = pMEquipmentinfo.PMEAC_SignOpinion;
        parm[2] = new SqlParameter("@PMEAC_SignMan", SqlDbType.VarChar, 20);
        parm[2].Value = pMEquipmentinfo.PMEAC_SignMan;
        parm[3] = new SqlParameter("@PMEAC_ID", SqlDbType.UniqueIdentifier);
        parm[3].Value = pMEquipmentinfo.PMEAC_ID;
        
        SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_U_PMEquipmentApplyCountersign", parm);
    }

    //查找设备采购申请审核表
    public DataSet SelectPMEquipmentApplyCountersign(PMEquipmentinfo pMEquipmentinfo)
    {

        SqlParameter[] parm = new SqlParameter[2];
        parm[0] = new SqlParameter("@PMEA_ID ", SqlDbType.UniqueIdentifier);
        parm[0].Value = pMEquipmentinfo.PMEA_ID;
        parm[1] = new SqlParameter("@PMEAC_State", SqlDbType.VarChar, 20);
        parm[1].Value = pMEquipmentinfo.PMEAC_State;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                 CommandType.StoredProcedure, "Proc_S_PMEquipmentApplyCountersign", parm);
    }
    ////查找部门
    //public DataSet SelectPMSCAC_Organization(string condition)
    //{
    //    SqlParameter parm = new SqlParameter("@Condition", condition);
    //    return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
    //        CommandType.StoredProcedure, "Proc_S_PMSCAC_Organization", parm);
    //}

    //查找设备采购申请审核表
    public DataSet SelectPMEquipmentApplyCountersign_One(PMEquipmentinfo pMEquipmentinfo)
    {

        SqlParameter[] parm = new SqlParameter[2];
        parm[0] = new SqlParameter("@PMEAC_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = pMEquipmentinfo.PMEAC_ID;
        parm[1] = new SqlParameter("@PMEAC_State", SqlDbType.VarChar,20);
        parm[1].Value = pMEquipmentinfo.PMEAC_State;
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                 CommandType.StoredProcedure, "Proc_S_PMEquipmentApplyCountersign_One", parm);
    }



    ////新增设备采购申请验收审核部门
    //public void InsertPMEquipmentCheckAcceptCountersign(PMEquipmentinfo pMEquipmentinfo)
    //{

    //    SqlParameter[] parm = new SqlParameter[2];
    //    parm[0] = new SqlParameter("@PMECA_ID", SqlDbType.UniqueIdentifier);
    //    parm[0].Value = pMEquipmentinfo.PMECA_ID;
    //    parm[1] = new SqlParameter("@PMECAC_SignPartment", SqlDbType.VarChar, 200);
    //    parm[1].Value = pMEquipmentinfo.PMECAC_SignPartment;

    //    SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
    //             CommandType.StoredProcedure, "Proc_I_PMEquipmentCheckAcceptCountersign", parm);
    //}
    //修改设备采购申请表状态
    public void UpdatePMEquipmentApply_State(PMEquipmentinfo pMEquipmentinfo)
    {
        SqlParameter[] parm = new SqlParameter[2];

        parm[0] = new SqlParameter("@PMEA_ApplyState", SqlDbType.VarChar, 20);
        parm[0].Value = pMEquipmentinfo.PMEA_ApplyState;
        parm[1] = new SqlParameter("@PMEA_ID", SqlDbType.UniqueIdentifier);
        parm[1].Value = pMEquipmentinfo.PMEA_ID;
        SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_U_PMEquipmentApply_State", parm);
    }

    //填写设备单价
    public void UpdatePMEquipmentPrice(PMEquipmentinfo pMEquipmentinfo)
    {
        SqlParameter[] parm = new SqlParameter[2];

        parm[0] = new SqlParameter("@PMEA_EquipmentPrice", SqlDbType.Decimal);
        parm[0].Value = pMEquipmentinfo.PMEA_EquipmentPrice;
        parm[1] = new SqlParameter("@PMEA_ID", SqlDbType.UniqueIdentifier);
        parm[1].Value = pMEquipmentinfo.PMEA_ID;
        SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_U_PMEquipmentPrice", parm);
    }

    //删除审核部门
    public void DeletePMEquipmentApplyCountersign(PMEquipmentinfo pMEquipmentinfo)
    {
        SqlParameter[] parm = new SqlParameter[1];
        parm[0] = new SqlParameter("@PMEAC_ID", SqlDbType.UniqueIdentifier);
        parm[0].Value = pMEquipmentinfo.PMEAC_ID;
        SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_D_PMEquipmentApplyCountersign", parm);
    }

    //查找审核（验收）部门
    public DataSet SelectPMEquipmentApplyCountersign_Same(string condition)
    {
        SqlParameter parm = new SqlParameter("@Condition", condition);
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
            CommandType.StoredProcedure, "Proc_S_PMEquipmentApplyCountersign_Same", parm);
    }
}
}