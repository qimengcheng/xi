using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections;
using EquipmentMangementAjax.DBUtility;

/// <summary>
///PMSupplyMaterial 的摘要说明
/// </summary>
namespace EquipmentMangementAjax.SQLServer
{
    public class PMSupplyMaterialD : IPMSupplyMaterial
    {
        public PMSupplyMaterialD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
//查询现用采购规则
        public DataSet SelectPMPurchaseingApplyRule()
        {
            
            return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_PMPurchaseingApplyRule_New");
        }
        //查找采购申请单
        public DataSet SelectPMPurchaseingApply(string condition)
        {
            SqlParameter parm = new SqlParameter("@Condition", condition);
            return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_PMPurchaseingApply", parm);
        }
        //新增采购申请单详细表
        public void InsertPMPurchaseingApply(PMPurchaseingApplyRuleinfo pMPurchaseingApplyRuleinfo)
        {

            SqlParameter[] parm = new SqlParameter[8];
       
            parm[0] = new SqlParameter("@PMPAD_Require", SqlDbType.VarChar, 400);
            parm[0].Value = pMPurchaseingApplyRuleinfo.PMPAD_Require;
            parm[1] = new SqlParameter("@IMMBD_MaterialID", SqlDbType.UniqueIdentifier);
            parm[1].Value = pMPurchaseingApplyRuleinfo.IMMBD_MaterialID;
            parm[2] = new SqlParameter("@PMPAD_Num", SqlDbType.Decimal);
            parm[2].Value = pMPurchaseingApplyRuleinfo.PMPAD_Num;
            parm[3] = new SqlParameter("@PMPAM_ID", SqlDbType.UniqueIdentifier);
            parm[3].Value = pMPurchaseingApplyRuleinfo.PMPAM_ID;
            parm[4] = new SqlParameter("@PMPAD_NeedTime", SqlDbType.DateTime);
            parm[4].Value = pMPurchaseingApplyRuleinfo.PMPAD_NeedTime;
            parm[5] = new SqlParameter("@IMUC_ID", SqlDbType.UniqueIdentifier);
            parm[5].Value = pMPurchaseingApplyRuleinfo.IMUC_ID;
            parm[6] = new SqlParameter("@PMPAD_Remark", SqlDbType.VarChar,400);
            parm[6].Value = pMPurchaseingApplyRuleinfo.PMPAD_Remark;
            parm[7] = new SqlParameter("@PMPAD_PriceIndication", SqlDbType.Decimal);
            parm[7].Value = pMPurchaseingApplyRuleinfo.PMPAD_PriceIndication;
            SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_I_PMPurchaseingApply", parm);
        }
        //新增采购申请单
        public void InsertPMPurchaseingApplyMain(PMPurchaseingApplyRuleinfo pMPurchaseingApplyRuleinfo)
        {

            SqlParameter[] parm = new SqlParameter[3];

            parm[0] = new SqlParameter("@PMPAM_Department", SqlDbType.VarChar, 20);
            parm[0].Value = pMPurchaseingApplyRuleinfo.PMPAM_Department;
            parm[1] = new SqlParameter("@PMPAM_ApplyMan", SqlDbType.VarChar,20);
            parm[1].Value = pMPurchaseingApplyRuleinfo.PMPAM_ApplyMan;
           
            parm[2] = new SqlParameter("@PMPAM_State", SqlDbType.VarChar,20);
            parm[2].Value = pMPurchaseingApplyRuleinfo.PMPAM_State;
            SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_I_PMPurchaseingApplyMain", parm);
        }
        //查询物料
        public DataSet SelectPMPurchaseSMaterial(string condition)
        {
            SqlParameter parm = new SqlParameter("@Condition", condition);
            return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_S_PMPurchaseSMaterial",parm);
        }
        //查询申请单详细内容
        public DataSet SelectPMPurchaseApplyDetail(PMPurchaseingApplyRuleinfo pMPurchaseingApplyRuleinfo)
        {

            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@PMPAM_ID ", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMPurchaseingApplyRuleinfo.PMPAM_ID;
            return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_S_PMPurchaseApplyDetail", parm);
        }
        //删除申请单详细内容
        public void DeletePMPurchaseApplyDetail(PMPurchaseingApplyRuleinfo pMPurchaseingApplyRuleinfo)
        {

            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@PMPAD_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMPurchaseingApplyRuleinfo.PMPAD_ID;
            SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
                    CommandType.StoredProcedure, "Proc_D_PMPurchaseApplyDetail", parm);
        }
        //删除申请单
        public void DeletePMPurchaseApplyMain(PMPurchaseingApplyRuleinfo pMPurchaseingApplyRuleinfo)
        {

            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@PMPAM_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMPurchaseingApplyRuleinfo.PMPAM_ID;
            SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
                    CommandType.StoredProcedure, "Proc_D_PMPurchaseApplyMain", parm);
        }
        //更改申请单状态
        public void UpdatePMPurchaseApplySate(PMPurchaseingApplyRuleinfo pMPurchaseingApplyRuleinfo)
        {

            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@PMPAM_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMPurchaseingApplyRuleinfo.PMPAM_ID;
            parm[1] = new SqlParameter("@PMPAM_State", SqlDbType.VarChar, 20);
            parm[1].Value = pMPurchaseingApplyRuleinfo.PMPAM_State;

            SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_U_PMPurchaseApplySate", parm);
        }
        //部门主管审核
        public void UpdatePMPAM_AppDepartMang(PMPurchaseingApplyRuleinfo pMPurchaseingApplyRuleinfo)
        {

            SqlParameter[] parm = new SqlParameter[5];
            parm[0] = new SqlParameter("@PMPAM_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMPurchaseingApplyRuleinfo.PMPAM_ID;
            parm[1] = new SqlParameter("@PMPAM_AppDepartMangResult", SqlDbType.VarChar, 20);
            parm[1].Value = pMPurchaseingApplyRuleinfo.PMPAM_AppDepartMangResult;
            parm[2] = new SqlParameter("@PMPAM_AppDepartMangOpinion", SqlDbType.VarChar, 400);
            parm[2].Value = pMPurchaseingApplyRuleinfo.PMPAM_AppDepartMangOpinion;
            
            parm[3] = new SqlParameter("@PMPAM_State", SqlDbType.VarChar, 20);
            parm[3].Value = pMPurchaseingApplyRuleinfo.PMPAM_State;
            parm[4] = new SqlParameter("@PMPAM_AppDepartMangName", SqlDbType.VarChar, 20);
            parm[4].Value = pMPurchaseingApplyRuleinfo.PMPAM_AppDepartMangName;
            SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_U_PMPAM_AppDepartMang", parm);
        }

        //财务主管审核
        public void UpdatePMPAM_CFECheck(PMPurchaseingApplyRuleinfo pMPurchaseingApplyRuleinfo)
        {

            SqlParameter[] parm = new SqlParameter[5];
            parm[0] = new SqlParameter("@PMPAM_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMPurchaseingApplyRuleinfo.PMPAM_ID;
            parm[1] = new SqlParameter("@PMPAM_CFECheckResult", SqlDbType.VarChar, 20);
            parm[1].Value = pMPurchaseingApplyRuleinfo.PMPAM_CFECheckResult;
            parm[2] = new SqlParameter("@PMPAM_CFECheckOpinion", SqlDbType.VarChar, 400);
            parm[2].Value = pMPurchaseingApplyRuleinfo.PMPAM_CFECheckOpinion;
            
            parm[3] = new SqlParameter("@PMPAM_State", SqlDbType.VarChar, 20);
            parm[3].Value = pMPurchaseingApplyRuleinfo.PMPAM_State;
            parm[4] = new SqlParameter("@PMPAM_CFECheckMan", SqlDbType.VarChar, 20);
            parm[4].Value = pMPurchaseingApplyRuleinfo.PMPAM_CFECheckMan;
            SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_U_PMPAM_CFECheck", parm);
        }
        //财务总监审核
        public void UpdatePMPAM_CFOCheck(PMPurchaseingApplyRuleinfo pMPurchaseingApplyRuleinfo)
        {

            SqlParameter[] parm = new SqlParameter[5];
            parm[0] = new SqlParameter("@PMPAM_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMPurchaseingApplyRuleinfo.PMPAM_ID;
            parm[1] = new SqlParameter("@PMPAM_CFOCheckResult", SqlDbType.VarChar, 20);
            parm[1].Value = pMPurchaseingApplyRuleinfo.PMPAM_CFOCheckResult;
            parm[2] = new SqlParameter("@PMPAM_CFOCheckOpinion", SqlDbType.VarChar, 400);
            parm[2].Value = pMPurchaseingApplyRuleinfo.PMPAM_CFOCheckOpinion;
           
            parm[3] = new SqlParameter("@PMPAM_State", SqlDbType.VarChar, 20);
            parm[3].Value = pMPurchaseingApplyRuleinfo.PMPAM_State;
            parm[4] = new SqlParameter("@PMPAM_CFOCheckMan", SqlDbType.VarChar, 20);
            parm[4].Value = pMPurchaseingApplyRuleinfo.PMPAM_CFOCheckMan;
            SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_U_PMPAM_CFOCheck", parm);
        }
        //查看申请审核意见
        public DataSet SelectPMPAM_CheckOpinion(PMPurchaseingApplyRuleinfo pMPurchaseingApplyRuleinfo)
        {

            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@PMPAM_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMPurchaseingApplyRuleinfo.PMPAM_ID;
           
          return  SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_S_PMPAM_CheckOpinion", parm);
        }
        //查询某一采购申请单
        public DataSet SelectPMPurchaseApplyOne(PMPurchaseingApplyRuleinfo pMPurchaseingApplyRuleinfo)
        {

            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@PMPAM_ID ", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMPurchaseingApplyRuleinfo.PMPAM_ID;
            return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_S_PMPurchaseingApply_One", parm);
        }
        //确认紧急采购订单
        public void UpdatePMPAM_EmergencyPur(PMPurchaseingApplyRuleinfo pMPurchaseingApplyRuleinfo)
        {

            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@PMPAM_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMPurchaseingApplyRuleinfo.PMPAM_ID;
           
            SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_U_PMPAM_EmergencyPur", parm);
        }
        //部门副总审核
        public void UpdatePMPAM_DeptMangCheck(PMPurchaseingApplyRuleinfo pMPurchaseingApplyRuleinfo)
        {

            SqlParameter[] parm = new SqlParameter[5];
            parm[0] = new SqlParameter("@PMPAM_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMPurchaseingApplyRuleinfo.PMPAM_ID;
            parm[1] = new SqlParameter("@PMPAM_DeptMangCheckResult", SqlDbType.VarChar, 20);
            parm[1].Value = pMPurchaseingApplyRuleinfo.PMPAM_DeptMangCheckResult;
            parm[2] = new SqlParameter("@PMPAM_DeptMangCheckOpinion", SqlDbType.VarChar, 400);
            parm[2].Value = pMPurchaseingApplyRuleinfo.PMPAM_DeptMangCheckOpinion;

            parm[3] = new SqlParameter("@PMPAM_State", SqlDbType.VarChar, 20);
            parm[3].Value = pMPurchaseingApplyRuleinfo.PMPAM_State;
            parm[4] = new SqlParameter("@PMPAM_DeptMangName", SqlDbType.VarChar, 20);
            parm[4].Value = pMPurchaseingApplyRuleinfo.PMPAM_DeptMangName;
            SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_U_PMPAM_DeptMangCheck", parm);
        }
        //技术副总审核
        public void UpdatePMPAM_DesignMangCheck(PMPurchaseingApplyRuleinfo pMPurchaseingApplyRuleinfo)
        {

            SqlParameter[] parm = new SqlParameter[5];
            parm[0] = new SqlParameter("@PMPAM_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMPurchaseingApplyRuleinfo.PMPAM_ID;
            parm[1] = new SqlParameter("@PMPAM_DesignMangCheckResult", SqlDbType.VarChar, 20);
            parm[1].Value = pMPurchaseingApplyRuleinfo.PMPAM_DesignMangCheckResult;
            parm[2] = new SqlParameter("@PMPAM_DesignMangCheckOpinion", SqlDbType.VarChar, 400);
            parm[2].Value = pMPurchaseingApplyRuleinfo.PMPAM_DesignMangCheckOpinion;

            parm[3] = new SqlParameter("@PMPAM_State", SqlDbType.VarChar, 20);
            parm[3].Value = pMPurchaseingApplyRuleinfo.PMPAM_State;
            parm[4] = new SqlParameter("@PMPAM_DesignMangName", SqlDbType.VarChar, 20);
            parm[4].Value = pMPurchaseingApplyRuleinfo.PMPAM_DesignMangName;
            SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_U_PMPAM_DesignMangCheck", parm);
        }
        //技术副总审核
        public void UpdatePMPAM_PersonalCheck(PMPurchaseingApplyRuleinfo pMPurchaseingApplyRuleinfo)
        {

            SqlParameter[] parm = new SqlParameter[5];
            parm[0] = new SqlParameter("@PMPAM_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMPurchaseingApplyRuleinfo.PMPAM_ID;
            parm[1] = new SqlParameter("@PMPAM_PersonnalCheckResult", SqlDbType.VarChar, 20);
            parm[1].Value = pMPurchaseingApplyRuleinfo.PMPAM_PersonnalCheckResult;
            parm[2] = new SqlParameter("@PMPAM_PersonnalCheckOpinion", SqlDbType.VarChar, 400);
            parm[2].Value = pMPurchaseingApplyRuleinfo.PMPAM_PersonnalCheckOpinion;

            parm[3] = new SqlParameter("@PMPAM_State", SqlDbType.VarChar, 20);
            parm[3].Value = pMPurchaseingApplyRuleinfo.PMPAM_State;
            parm[4] = new SqlParameter("@PMPAM_PersonnalCheckMan", SqlDbType.VarChar, 20);
            parm[4].Value = pMPurchaseingApplyRuleinfo.PMPAM_PersonnalCheckMan;
            SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_U_PMPAM_PersonnalCheck ", parm);
        }
        //查找是否含有办公用品和劳保用品
        public DataSet SelectPMPurchaseApplyDetail_LB(string condition)
        {
            SqlParameter parm = new SqlParameter("@Condition", condition);
            return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_PMPurchaseApplyDetail_LB", parm);
        }
        //修改采购申请单号
        public void UpdatePMPurchaseingApplyMain_ID(PMPurchaseingApplyRuleinfo pMPurchaseingApplyRuleinfo)
        {

            SqlParameter[] parm = new SqlParameter[1];

            parm[0] = new SqlParameter("@PMPAM_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMPurchaseingApplyRuleinfo.PMPAM_ID;
          
            SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_U_PMPurchaseingApplyMain_ID", parm);
        }
    }
}
