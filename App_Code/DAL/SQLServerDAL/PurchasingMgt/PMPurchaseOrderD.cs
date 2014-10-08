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
///PMPurchaseOrderD 的摘要说明
/// </summary>
 namespace EquipmentMangementAjax.SQLServer
{
public class PMPurchaseOrderD:IPMPurchaseOrder
{
	public PMPurchaseOrderD()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    //查找申请单内容汇总
     public DataSet SelectPMPurchaseApplySummary (string condition)
        {
            SqlParameter parm = new SqlParameter("@Condition", condition);
            return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_PMPurchaseApplySummary", parm);
        }
    //查看对应物料的申请单
     public DataSet SelectPMPurchaseApply_Material(string condition)
        {

            SqlParameter parm = new SqlParameter("@Condition", condition);
            
            return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_S_PMPurchaseApply_Material", parm);
        }
     //查看对应供应商的物料
     public DataSet SelectPMPurchase_Material(string condition)
     {

         SqlParameter parm = new SqlParameter("@Condition", condition);

         return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
                  CommandType.StoredProcedure, "Proc_S_PMPurchase_Material", parm);
     }


    //生成采购订单
     public void InsertPMPurchaseOrder(PMPurchaseOrderinfo pMPurchaseOrderinfo)
        {
            SqlParameter[] parm = new SqlParameter[2];
           
            parm[0] = new SqlParameter("@PMPO_MakeMan", SqlDbType.VarChar,20);
            parm[0].Value = pMPurchaseOrderinfo.PMPO_MakeMan;
            
            parm[1] = new SqlParameter("@PMPO_State", SqlDbType.VarChar,20);
            parm[1].Value = pMPurchaseOrderinfo.PMPO_State;
           
            SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_I_PMPurchaseOrder", parm);
      
     }
    //根据物料绑定采购申请详细表和采购订单
     public void UpdatePMPurchaseApplyDetail(PMPurchaseOrderinfo pMPurchaseOrderinfo)
        {

            SqlParameter[] parm = new SqlParameter[3];

            parm[0] = new SqlParameter("@PMPO_PurchaseOrderID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMPurchaseOrderinfo.PMPO_PurchaseOrderID;
            parm[1] = new SqlParameter("@IMMBD_MaterialID", SqlDbType.UniqueIdentifier);
            parm[1].Value = pMPurchaseOrderinfo.IMMBD_MaterialID;
            parm[2] = new SqlParameter("@IMUC_ID", SqlDbType.UniqueIdentifier);
            parm[2].Value = pMPurchaseOrderinfo.IMUC_ID;
           
            SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_U_PMPurchaseApplyDetail", parm);
        }
    //根据物料生成采购订单详细表
     public void InsertPMPurchaseOrderDetail(PMPurchaseOrderinfo pMPurchaseOrderinfo)
        {
            SqlParameter[] parm = new SqlParameter[7];

            parm[0] = new SqlParameter("@IMMBD_MaterialID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMPurchaseOrderinfo.IMMBD_MaterialID;
            parm[1] = new SqlParameter("@PMPOD_ProductRequest", SqlDbType.VarChar,2000);
            parm[1].Value = pMPurchaseOrderinfo.PMPOD_ProductRequest;
            parm[2] = new SqlParameter("@PMPOD_TotalMoney", SqlDbType.Decimal);
            parm[2].Value = pMPurchaseOrderinfo.PMPOD_TotalMoney;
            parm[3] = new SqlParameter("@PMPOD_Num", SqlDbType.Decimal);
            parm[3].Value = pMPurchaseOrderinfo.PMPOD_Num;
            parm[4] = new SqlParameter("@IMUC_ID", SqlDbType.UniqueIdentifier);
            parm[4].Value = pMPurchaseOrderinfo.IMUC_ID;
            parm[5] = new SqlParameter("@PMPOD_Price", SqlDbType.Decimal);
            parm[5].Value = pMPurchaseOrderinfo.PMPOD_Price;
            
            parm[6] = new SqlParameter("@PMPO_PurchaseOrderID", SqlDbType.UniqueIdentifier);
            parm[6].Value = pMPurchaseOrderinfo.PMPO_PurchaseOrderID;

            SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_I_PMPurchaseOrderDetail", parm);
        }
    //根据申请单绑定采购申请详细表和采购订单
     public void UpdatePMPurchaseApplyDetail_One(PMPurchaseOrderinfo pMPurchaseOrderinfo)
        {

            SqlParameter[] parm = new SqlParameter[4];

            parm[0] = new SqlParameter("@PMPO_PurchaseOrderID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMPurchaseOrderinfo.PMPO_PurchaseOrderID;
            parm[1] = new SqlParameter("@IMMBD_MaterialID", SqlDbType.UniqueIdentifier);
            parm[1].Value = pMPurchaseOrderinfo.IMMBD_MaterialID;
            parm[2] = new SqlParameter("@IMUC_ID", SqlDbType.UniqueIdentifier);
            parm[2].Value = pMPurchaseOrderinfo.IMUC_ID;
            parm[3] = new SqlParameter("@PMPAM_ID", SqlDbType.UniqueIdentifier);
            parm[3].Value = pMPurchaseOrderinfo.PMPAM_ID;
            SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_U_PMPurchaseApplyDetail_One", parm);
        }
    //向采购申请详细单插入单价
     public void InsertPMPurchaseApplyDetailPrice(PMPurchaseOrderinfo pMPurchaseOrderinfo)
     {

         SqlParameter[] parm = new SqlParameter[3];
         parm[0] = new SqlParameter("@IMMBD_MaterialID", SqlDbType.UniqueIdentifier);
         parm[0].Value = pMPurchaseOrderinfo.IMMBD_MaterialID;
         parm[1] = new SqlParameter("@IMUC_ID", SqlDbType.UniqueIdentifier);
         parm[1].Value = pMPurchaseOrderinfo.IMUC_ID;
         parm[2] = new SqlParameter("@PMPAD_Price", SqlDbType.Decimal);
         parm[2].Value = pMPurchaseOrderinfo.PMPAD_Price;
         SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
                  CommandType.StoredProcedure, "Proc_I_PMPurchaseApplyDetailPrice", parm);
     }
     //查询采购订单
     public DataSet SelectPMPurchaseOrder()
     {
        return  SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
                  CommandType.StoredProcedure, "Proc_S_PMPurchaseOrder");
     }
    //查找采购订单详细表
     public DataSet SelectPMPurchaseOrderDetail(PMPurchaseOrderinfo pMPurchaseOrderinfo)
     {

         SqlParameter[] parm = new SqlParameter[1];
         parm[0] = new SqlParameter("@PMPO_PurchaseOrderID", SqlDbType.UniqueIdentifier);
         parm[0].Value = pMPurchaseOrderinfo.PMPO_PurchaseOrderID;

        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
                  CommandType.StoredProcedure, "Proc_S_PMPurchaseOrderDetail", parm);
     }
     //绑定采购订单和采购订单详细表
     public void UpdatePMPurchaseOrderDetail(PMPurchaseOrderinfo pMPurchaseOrderinfo)
     {

         SqlParameter[] parm = new SqlParameter[2];
         parm[0] = new SqlParameter("@PMPOD_MakeTime", SqlDbType.DateTime);
         parm[0].Value = pMPurchaseOrderinfo.PMPOD_MakeTime;
         parm[1] = new SqlParameter("@PMPO_PurchaseOrderID", SqlDbType.UniqueIdentifier);
         parm[1].Value = pMPurchaseOrderinfo.PMPO_PurchaseOrderID;
         SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
                  CommandType.StoredProcedure, "Proc_U_PMPurchaseOrderDetail", parm);
     }
    //根据物料查找采购申请详细表
     public DataSet SelectPMPurchaseApplyDetail_Material(PMPurchaseOrderinfo pMPurchaseOrderinfo)
     {

         SqlParameter[] parm = new SqlParameter[2];
         parm[0] = new SqlParameter("@IMMBD_MaterialID", SqlDbType.UniqueIdentifier);
         parm[0].Value = pMPurchaseOrderinfo.IMMBD_MaterialID;
         parm[1] = new SqlParameter("@IMUC_ID", SqlDbType.UniqueIdentifier);
         parm[1].Value = pMPurchaseOrderinfo.IMUC_ID;
        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
                  CommandType.StoredProcedure, "Proc_S_PMPurchaseApplyDetail_Material", parm);
     }
    //向采购订单插入内容
     public void UpdatePMPurchaseOrder(PMPurchaseOrderinfo pMPurchaseOrderinfo)
     {

         SqlParameter[] parm = new SqlParameter[9];
         parm[0] = new SqlParameter("@PMPO_PayWay", SqlDbType.VarChar,20);
         parm[0].Value = pMPurchaseOrderinfo.PMPO_PayWay;
         parm[1] = new SqlParameter("@PMPO_PurchaseOrderID", SqlDbType.UniqueIdentifier);
         parm[1].Value = pMPurchaseOrderinfo.PMPO_PurchaseOrderID;
         parm[2] = new SqlParameter("@PMPO_PaymentTime", SqlDbType.SmallInt);
         parm[2].Value = pMPurchaseOrderinfo.PMPO_PaymentTime;
         parm[3] = new SqlParameter("@PMPO_PlanArrTime", SqlDbType.Date);
         parm[3].Value = pMPurchaseOrderinfo.PMPO_PlanArrTime;
         parm[4] = new SqlParameter("@PMPO_TotalMoney", SqlDbType.Decimal);
         parm[4].Value = pMPurchaseOrderinfo.PMPO_TotalMoney;
         parm[5] = new SqlParameter("@PMSI_ID", SqlDbType.UniqueIdentifier);
         parm[5].Value = pMPurchaseOrderinfo.PMSI_ID;
         parm[6] = new SqlParameter("@PMPO_State", SqlDbType.VarChar, 20);
         parm[6].Value = pMPurchaseOrderinfo.PMPO_State;
         parm[7] = new SqlParameter("@PMPO_ResidueMoney", SqlDbType.Decimal);
         parm[7].Value = pMPurchaseOrderinfo.PMPO_ResidueMoney;
         parm[8] = new SqlParameter("@PMPO_AdvancePayNum", SqlDbType.Decimal);
         parm[8].Value = pMPurchaseOrderinfo.PMPO_AdvancePayNum;
         SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
                  CommandType.StoredProcedure, "Proc_U_PMPurchaseOrder", parm);
     }
     //根据物料和申请单查找采购申请详细表
     public DataSet SelectPMPurchaseApplyDetail_Apply(PMPurchaseOrderinfo pMPurchaseOrderinfo)
     {

         SqlParameter[] parm = new SqlParameter[3];
         parm[0] = new SqlParameter("@IMMBD_MaterialID", SqlDbType.UniqueIdentifier);
         parm[0].Value = pMPurchaseOrderinfo.IMMBD_MaterialID;
         parm[1] = new SqlParameter("@IMUC_ID", SqlDbType.UniqueIdentifier);
         parm[1].Value = pMPurchaseOrderinfo.IMUC_ID;
         parm[2] = new SqlParameter("@PMPAM_ID", SqlDbType.UniqueIdentifier);
         parm[2].Value = pMPurchaseOrderinfo.PMPAM_ID;
         return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
                   CommandType.StoredProcedure, "Proc_S_PMPurchaseApplyDetail_Apply", parm);
     }
     //确定采购申请详细表为已采购
     public void UpdatePMPAD_Purchase(PMPurchaseOrderinfo pMPurchaseOrderinfo)
     {

         SqlParameter[] parm = new SqlParameter[1];
         parm[0] = new SqlParameter("@PMPO_PurchaseOrderID", SqlDbType.UniqueIdentifier);
         parm[0].Value = pMPurchaseOrderinfo.PMPO_PurchaseOrderID;
         SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
                  CommandType.StoredProcedure, "Proc_U_PMPAD_Purchase", parm);
     }

     //删除采购订单
     public void DeletePMPurchaseOrder(PMPurchaseOrderinfo pMPurchaseOrderinfo)
     {
         SqlParameter[] parm = new SqlParameter[1];
         parm[0] = new SqlParameter("@PMPO_PurchaseOrderID", SqlDbType.UniqueIdentifier);
         parm[0].Value = pMPurchaseOrderinfo.PMPO_PurchaseOrderID;
         SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
                  CommandType.StoredProcedure, "Proc_D_PurchasingOrder", parm);
     }


    //查找采购订单
     public DataSet SelectPMPurchaseOrderMain(string condition)
     {
         SqlParameter parm = new SqlParameter("@Condition", condition);
         return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
             CommandType.StoredProcedure, "Proc_S_PMPurchaseOrderMain", parm);
     }
    //直接制定采购订单时查找采购订单详细表
     public DataSet SelectPMPurchaseOrderDetail_look(PMPurchaseOrderinfo pMPurchaseOrderinfo)
     {

         SqlParameter[] parm = new SqlParameter[1];
         parm[0] = new SqlParameter("@PMPO_PurchaseOrderID", SqlDbType.UniqueIdentifier);
         parm[0].Value = pMPurchaseOrderinfo.PMPO_PurchaseOrderID;
       return  SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
                  CommandType.StoredProcedure, "Proc_S_PMPurchaseOrderDetail_look", parm);
     }
    //直接制定采购订单时生成采购订单表
     public void InsertPMPurchaseOrderMain(PMPurchaseOrderinfo pMPurchaseOrderinfo)
     {

         SqlParameter[] parm = new SqlParameter[7];
         
         parm[0] = new SqlParameter("@PMPO_MakeMan", SqlDbType.VarChar,20);
         parm[0].Value = pMPurchaseOrderinfo.PMPO_MakeMan;
         parm[1] = new SqlParameter("@PMPO_PayWay", SqlDbType.VarChar, 20);
         parm[1].Value = pMPurchaseOrderinfo.PMPO_PayWay;
         parm[2] = new SqlParameter("@PMPO_PaymentTime", SqlDbType.SmallInt);
         parm[2].Value = pMPurchaseOrderinfo.PMPO_PaymentTime;
         parm[3] = new SqlParameter("@PMPO_PlanArrTime", SqlDbType.Date);
         parm[3].Value = pMPurchaseOrderinfo.PMPO_PlanArrTime;
         parm[4] = new SqlParameter("@PMSI_ID", SqlDbType.UniqueIdentifier);
         parm[4].Value = pMPurchaseOrderinfo.PMSI_ID;
         parm[5] = new SqlParameter("@PMPO_State", SqlDbType.VarChar,20);
         parm[5].Value = pMPurchaseOrderinfo.PMPO_State;
         parm[6] = new SqlParameter("@PMPO_AdvancePayNum", SqlDbType.Decimal);
         parm[6].Value = pMPurchaseOrderinfo.PMPO_AdvancePayNum;
         SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
                  CommandType.StoredProcedure, "Proc_I_PMPurchaseOrderMain", parm);
     }
    //生成采购订单详细表
     public void InsertPMPurchaseOrderDetail_Direct(PMPurchaseOrderinfo pMPurchaseOrderinfo)
     {

         SqlParameter[] parm = new SqlParameter[8];
         parm[0] = new SqlParameter("@PMPO_PurchaseOrderID", SqlDbType.UniqueIdentifier);
         parm[0].Value = pMPurchaseOrderinfo.PMPO_PurchaseOrderID;
         parm[1] = new SqlParameter("@PMPOD_Num", SqlDbType.Decimal);
         parm[1].Value = pMPurchaseOrderinfo.PMPOD_Num;
         parm[2] = new SqlParameter("@PMPOD_Price", SqlDbType.Decimal);
         parm[2].Value = pMPurchaseOrderinfo.PMPOD_Price;
         parm[3] = new SqlParameter("@PMPOD_TotalMoney", SqlDbType.Decimal);
         parm[3].Value = pMPurchaseOrderinfo.PMPOD_TotalMoney;
         parm[4] = new SqlParameter("@PMPOD_ProductRequest", SqlDbType.VarChar,2000);
         parm[4].Value = pMPurchaseOrderinfo.PMPOD_ProductRequest;
         parm[5] = new SqlParameter("@PMPOD_Remark", SqlDbType.VarChar,400);
         parm[5].Value = pMPurchaseOrderinfo.PMPOD_Remark;
         parm[6] = new SqlParameter("@IMMBD_MaterialID", SqlDbType.UniqueIdentifier);
         parm[6].Value = pMPurchaseOrderinfo.IMMBD_MaterialID;
         parm[7] = new SqlParameter("@IMUC_ID", SqlDbType.UniqueIdentifier);
         parm[7].Value = pMPurchaseOrderinfo.IMUC_ID;
        
         
         SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
                  CommandType.StoredProcedure, "Proc_I_PMPurchaseOrderDetail_Direct", parm);
     }
    //修改采购订单详细表
     public void UpdatePMPurchaseOrderDetail_Direct(PMPurchaseOrderinfo pMPurchaseOrderinfo)
     {

         SqlParameter[] parm = new SqlParameter[8];
         parm[0] = new SqlParameter("@PMPOD_PurchaseDetailID", SqlDbType.UniqueIdentifier);
         parm[0].Value = pMPurchaseOrderinfo.PMPOD_PurchaseDetailID;
         parm[1] = new SqlParameter("@PMPOD_Num", SqlDbType.Decimal);
         parm[1].Value = pMPurchaseOrderinfo.PMPOD_Num;
         parm[2] = new SqlParameter("@PMPOD_Price", SqlDbType.Decimal);
         parm[2].Value = pMPurchaseOrderinfo.PMPOD_Price;
         parm[3] = new SqlParameter("@PMPOD_TotalMoney", SqlDbType.Decimal);
         parm[3].Value = pMPurchaseOrderinfo.PMPOD_TotalMoney;
         parm[4] = new SqlParameter("@PMPOD_ProductRequest", SqlDbType.VarChar, 2000);
         parm[4].Value = pMPurchaseOrderinfo.PMPOD_ProductRequest;
         parm[5] = new SqlParameter("@PMPOD_Remark", SqlDbType.VarChar, 400);
         parm[5].Value = pMPurchaseOrderinfo.PMPOD_Remark;
         parm[6] = new SqlParameter("@IMMBD_MaterialID", SqlDbType.UniqueIdentifier);
         parm[6].Value = pMPurchaseOrderinfo.IMMBD_MaterialID;
         parm[7] = new SqlParameter("@IMUC_ID", SqlDbType.UniqueIdentifier);
         parm[7].Value = pMPurchaseOrderinfo.IMUC_ID;
         SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
                  CommandType.StoredProcedure, "Proc_U_PMPurchaseOrderDetail_Direct", parm);
     }
    //删除采购订单详细表
     public void DeletePMPurchaseOrderDetail_Direct(PMPurchaseOrderinfo pMPurchaseOrderinfo)
     {

         SqlParameter[] parm = new SqlParameter[1];
         parm[0] = new SqlParameter("@PMPOD_PurchaseDetailID", SqlDbType.UniqueIdentifier);
         parm[0].Value = pMPurchaseOrderinfo.PMPOD_PurchaseDetailID;
        
         SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
                  CommandType.StoredProcedure, "Proc_D_PMPurchaseOrderDetail_Direct", parm);
     }
    //改变采购订单状态、物料总数
     public void UpdatePMPurchaseOrder_State(PMPurchaseOrderinfo pMPurchaseOrderinfo)
     {

         SqlParameter[] parm = new SqlParameter[4];
         parm[0] = new SqlParameter("@PMPO_PurchaseOrderID", SqlDbType.UniqueIdentifier);
         parm[0].Value = pMPurchaseOrderinfo.PMPO_PurchaseOrderID;
         parm[1] = new SqlParameter("@PMPO_State", SqlDbType.VarChar,20);
         parm[1].Value = pMPurchaseOrderinfo.PMPO_State;
         parm[2] = new SqlParameter("@PMPO_TotalMoney", SqlDbType.Decimal);
         parm[2].Value = pMPurchaseOrderinfo.PMPO_TotalMoney;
         parm[3] = new SqlParameter("@PMPO_ResidueMoney", SqlDbType.Decimal);
         parm[3].Value = pMPurchaseOrderinfo.PMPO_ResidueMoney;
         SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
                  CommandType.StoredProcedure, "Proc_U_PMPurchaseOrder_State", parm);
     }

     //根据物料名称查找包含该物料的所有采购订单
     public DataSet SelectPMPurchaseOrderMain_Material(string condition)
     {
         SqlParameter[] parm = new SqlParameter[1];
         parm[0] = new SqlParameter("@Condition", SqlDbType.VarChar,2000);
         parm[0].Value = condition;

         return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
             CommandType.StoredProcedure, "Proc_S_PMPurchaseOrderMain_Material", parm);
     }
}
}
