using System;
using System.Data;
using System.Data.SqlClient;
//using System.Collections.Generic;
using EquipmentMangementAjax.DBUtility;


/// <summary>
///SalesDeliverD 的摘要说明
/// </summary>
namespace EquipmentMangementAjax.SQLServer
{
    public class PurchasingPlanD:IPurchasingPlan
    {
        public PurchasingPlanD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        //采购计划主表
        public DataSet Select_PlanMain(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_PMPurchasePlanMain", para);

        }
        //删除主表
        public void Delete_PlanMain(Guid id)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@PMPPM_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_PMPurchasePlanMain", para);
        }
        //新建采购计划主表
        public void Insert_PlanMain(int year,int month,string man)
        {
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("@PMPPM_Year", SqlDbType.Int);
            para[0].Value = year;
            para[1] = new SqlParameter("@PMPPM_Month", SqlDbType.Int);
            para[1].Value = month;
            para[2] = new SqlParameter("@PMPPM_Man", SqlDbType.VarChar, 20);
            para[2].Value = man;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_PMPurchasePlanMain", para);
        }
        //审核采购计划
        public void Update_PlanMain_Check(Guid id,string result,string opinion)
        {
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("@PMPPM_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            para[1] = new SqlParameter("@PMPPM_CFOCheckResult", SqlDbType.VarChar,20);
            para[1].Value = result;
            para[2] = new SqlParameter("@PMPPM_CFOCheckOpinion", SqlDbType.VarChar,400);
            para[2].Value = opinion;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_PMPurchasePlanMain_Check", para);
        }
        //采购计划详细表
        public DataSet Select_PlanDetail(Guid id)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@PMPPM_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_PMPurchasePlanDetail", para);

        }
        //更新详细数量
        public void Insert_ShouhouSort(Guid id,decimal num)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@PMPPD_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            para[1] = new SqlParameter("@PMPPD_ActualNum", SqlDbType.Decimal,18);
            para[1].Value = num;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_PMPurchasePlanDetail_Num", para);
        }
        //提交采购计划
        public void Update_PlanMain_Tijiao(Guid id)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@PMPPM_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_PMPurchasePlanDetail_State", para);
        }
        //编辑采购计划
        public void Update_PlanDetail_Edit(Guid id,string remark,string request)
        {
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("@PMPPD_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            para[1] = new SqlParameter("@PMPPD_Remark", SqlDbType.VarChar,400);
            para[1].Value = remark;
            para[2] = new SqlParameter("@PMPPD_ProductRequest", SqlDbType.VarChar,400);
            para[2].Value = request;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_PMPurchasePlanDetail_Edit", para);
        }
        //初始材料月计划
        public DataSet Select_MatPlan_Original(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_PMPDetail_PM_Original", para);

        }
        //新增材料月计划
        public DataSet Select_MatPlan_Add(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_PMPDetail_PM_Addtional", para);

        }
        //新增材料周计划
        public DataSet Select_MatPlan_Week(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_PWPDetail_PM", para);

        }
        //将勾选的插入采购计划
        public void Insert_DetailPlan_Mat(Guid id,Guid Mid,decimal num,string request)
        {
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@PMPPM_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            para[1] = new SqlParameter("@IMMBD_MaterialID", SqlDbType.UniqueIdentifier);
            para[1].Value = Mid;
            para[2] = new SqlParameter("@PMPPD_Num", SqlDbType.Decimal,18);
            para[2].Value = num;
            para[3] = new SqlParameter("@PMPPD_ProductRequest", SqlDbType.VarChar,400);
            para[3].Value = request;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_PMPurchasePlanDetail_Mat", para);
        }
        //生成采购订单
        public void Insert_PurchaseOrder(Guid Pid, Guid SIid,string way,int paytime,DateTime arrtime,DateTime remindtime,string man)
        {
            SqlParameter[] para = new SqlParameter[7];
            para[0] = new SqlParameter("@PMPO_PurchaseOrderID", SqlDbType.UniqueIdentifier);
            para[0].Value = Pid;
            para[1] = new SqlParameter("@PMSI_ID", SqlDbType.UniqueIdentifier);
            para[1].Value = SIid;
            para[2] = new SqlParameter("@PMPO_PayWay", SqlDbType.VarChar,20);
            para[2].Value = way;
            para[3] = new SqlParameter("@PMPO_PaymentTime", SqlDbType.Int);
            para[3].Value = paytime;
            para[4] = new SqlParameter("@PMPO_PlanArrTime", SqlDbType.DateTime);
            para[4].Value = arrtime;
            para[5] = new SqlParameter("@PMPO_PayRemindTime", SqlDbType.DateTime);
            para[5].Value = remindtime;
            para[6] = new SqlParameter("@man", SqlDbType.VarChar,20);
            para[6].Value = man;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_PMPurchaseOrder_PMPlan", para);
        }
        //将详细的物料插入到采购订单详细表里-这里应该是材料月计划当中的
        public void Insert_Material_MonthPlan(Guid orderID,Guid pdID,Guid Mid,decimal num)
        {
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@PMPO_PurchaseOrderID", SqlDbType.UniqueIdentifier);
            para[0].Value = orderID;
            para[1] = new SqlParameter("@PMPPD_ID", SqlDbType.UniqueIdentifier);
            para[1].Value = pdID;
            para[2] = new SqlParameter("@IMMBD_MaterialID", SqlDbType.UniqueIdentifier);
            para[2].Value = Mid;
            para[3] = new SqlParameter("@PMPOD_Num", SqlDbType.Decimal,18);
            para[3].Value = num;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_PMPurchaseOrderDetail_MatMonthPlan", para);

        }
        //将详细的物料插入到采购订单详细表里-这里应该是材料周计划当中的
        public void Insert_Material_WeekPlan(Guid orderID, Guid wID, Guid Mid, decimal num)
        {
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@PMPO_PurchaseOrderID", SqlDbType.UniqueIdentifier);
            para[0].Value = orderID;
            para[1] = new SqlParameter("@MWPD_ID", SqlDbType.UniqueIdentifier);
            para[1].Value = wID;
            para[2] = new SqlParameter("@IMMBD_MaterialID", SqlDbType.UniqueIdentifier);
            para[2].Value = Mid;
            para[3] = new SqlParameter("@PMPOD_Num", SqlDbType.Decimal, 18);
            para[3].Value = num;

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_PMPurchaseOrderDetail_MatWeekPlan", para);

        }
        //将订单主表进行编辑
        public void Update_PurchaseOrder( Guid id,Guid sid,string way ,int paytime,DateTime arrtime,DateTime remindtime)
        {
            SqlParameter[] para = new SqlParameter[6];
            para[0] = new SqlParameter("@PMPO_PurchaseOrderID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            para[1] = new SqlParameter("@PMSI_ID", SqlDbType.UniqueIdentifier);
            para[1].Value = sid;
            para[2] = new SqlParameter("@PMPO_PayWay", SqlDbType.VarChar,20);
            para[2].Value = way;
            para[3] = new SqlParameter("@PMPO_PaymentTime", SqlDbType.Int);
            para[3].Value = paytime;
            para[4] = new SqlParameter("@PMPO_PlanArrTime", SqlDbType.Date);
            para[4].Value = arrtime;
            para[5] = new SqlParameter("@PMPO_PayRemindTime", SqlDbType.Date);
            para[5].Value = remindtime;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_PMPurchaseOrder_PMPlan", para);
        }
        //将订单详细表进行编辑
        public void Update_PurchaseOrder_Detail(Guid id, decimal num,decimal price,string remark,string request)
        {
            SqlParameter[] para = new SqlParameter[5];
            para[0] = new SqlParameter("@PMPOD_PurchaseDetailID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            para[1] = new SqlParameter("@PMPOD_Num", SqlDbType.Decimal,18);
            para[1].Value = num;
            para[2] = new SqlParameter("@PMPOD_Price", SqlDbType.Decimal,18);
            para[2].Value = price;
            para[3] = new SqlParameter("@PMPOD_Remark", SqlDbType.VarChar, 400);
            para[3].Value = remark;
            para[4] = new SqlParameter("@PMPOD_ProductRequest", SqlDbType.VarChar, 400);
            para[4].Value = request;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_PMPurchaseOrderDetail_PMPlan", para);
        }
        //检索供应商
        public DataSet Select_Supply(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_PMSupplyInfo_PMPLan", para);
        }
        //删除计划详细
        public void Delete_Plan_Detail(Guid id)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@PMPPD_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_PMPurchasePlanDetail", para);
        }
        //检采购订单主表
        public DataSet Select_Order_Main(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_PMPurchaseOrderMain", para);
        }
        //检索采购订单详细
        public DataSet Select_Order_Detail(Guid id)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@PMPO_PurchaseOrderID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_PurchasingOrderDetail", para);
        }
        //删除采购订单
        public void Delete_Order(Guid id)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@PMPO_PurchaseOrderID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_PurchasingOrder", para);
        }
        //删除订单详细
        public void Delete_Order_Detail(Guid id)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@PMPOD_PurchaseDetailID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_PurchasingOrderDetail", para);
        }
        //提交采购订单
        public void Update_Order_Tijiao(Guid id)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@PMPO_PurchaseOrderID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_PMPurchaseOrder_PMPlan_tijiao", para);
        }
        //检索采购月计划物料
        public DataSet SelectIMMaterial_Price_PurchasePlan(string condition)
        {
            SqlParameter parm = new SqlParameter("@Condition", condition);
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_IMMaterial_Price_PurchasePlan", parm);
            
        }
        //填写物料价格
        public void UpdatePMPMaterial_Price(PMPurchaseingApplyRuleinfo pMPurchaseingApplyRuleinfo)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@IMMBD_MaterialID", SqlDbType.UniqueIdentifier);
            para[0].Value = pMPurchaseingApplyRuleinfo.IMMBD_MaterialID;
            para[1] = new SqlParameter("@IMMBD_Price", SqlDbType.Decimal);
            para[1].Value = pMPurchaseingApplyRuleinfo.IMMBD_Price;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_PMPMaterial_Price", para);
        }
    }
}