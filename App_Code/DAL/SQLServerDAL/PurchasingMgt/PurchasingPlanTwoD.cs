using System;
using System.Data;
using System.Data.SqlClient;
//using System.Collections.Generic;
using EquipmentMangementAjax.DBUtility;


/// <summary>
///SalesDeliverD 的摘要说明
/// </summary>

    public class PurchasingPlanTwoD
    {
        public PurchasingPlanTwoD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        //查询对应的材料计划
        public DataSet Select_PlanMain(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_PMPurchasePlanMain", para);

        }
        //查询审核详情
        public DataSet Select_CheckDetail(Guid id)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@PMPPM_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_PurchasePlan_Check", para);

        }
        //判断是否有对应的材料月计划
        public DataSet Select_MMP_Count(int year,int month)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@year", SqlDbType.Int);
            para[0].Value = year;
            para[1] = new SqlParameter("@month", SqlDbType.Int);
            para[1].Value = month;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_MMP_Count", para);

        }
        //判断是否有对应的caigou月计划
        public DataSet Select_PurchasePlan_Count(int year, int month)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@year", SqlDbType.Int);
            para[0].Value = year;
            para[1] = new SqlParameter("@month", SqlDbType.Int);
            para[1].Value = month;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_PurchasePlan_Count", para);

        }
        //将对应的物料插入到新建的采购计划中
        public void InsertMaterialPlan(int year,int month)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@PMPPM_Year", SqlDbType.Int);
            para[0].Value = year;
            para[1] = new SqlParameter("@PMPPM_Month", SqlDbType.Int);
            para[1].Value = month;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_PMPurchasingPlanMain_PMP", para);
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
        public void Update_PlanMain_Check_Role(Guid id,string result,string opinion,string role)
        {
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@PMPPM_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            para[1] = new SqlParameter("@PMPPM_CFOCheckResult", SqlDbType.VarChar,20);
            para[1].Value = result;
            para[2] = new SqlParameter("@PMPPM_CFOCheckOpinion", SqlDbType.VarChar,400);
            para[2].Value = opinion;
            para[3] = new SqlParameter("@role", SqlDbType.VarChar, 40);
            para[3].Value = role;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_PMPurchasePlanMain_Check_D", para);
        }
        //采购计划详细表
        public DataSet Select_PlanDetail(string  id,string condition)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@PMPPM_ID", SqlDbType.VarChar,100);
            para[0].Value = id;
            para[1] = new SqlParameter("@condition", SqlDbType.NVarChar,1000);
            para[1].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_PMPurchasePlanDetail", para);

        }
        //采购计划详细表
        public DataSet Select_PlanTotalMoney(Guid id)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@id", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_TotalMoneyPurchasePlan", para);

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////


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
        //显示采购计划临时表
        public DataSet Select_Temp()
        {
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_PMPPT");
        }
        //向采购计划临时表插入数据
        public void Insert_Temp(Guid MaterialID,Guid PDID)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@IMMBD_ID", SqlDbType.UniqueIdentifier);
            para[0].Value =MaterialID;
            para[1] = new SqlParameter("@PMPPD_ID", SqlDbType.UniqueIdentifier);
            para[1].Value = PDID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_PMPPT", para);
        }
        //向临时表中更新数量价格
        public void Update_Temp(Guid id,decimal num,decimal price)
        {
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("@PMPMT_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            para[1] = new SqlParameter("@num", SqlDbType.Decimal);
            para[1].Value = num;
            para[2] = new SqlParameter("@PMPPD_ID", SqlDbType.Decimal);
            para[2].Value = price;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_PMPPT", para);
        }
        //删除临时表
        public void Delete_Temp(Guid id)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@id", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_PMPPT", para);
        }
        //清空临时表
        public void DeleteAll_Temp()
        {
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_All_PMPPT");
        }
        
       //讲采购计划临时表内的内容插入到采购订单里
        public void Insert_Order_PlanTemp(Guid id)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@PMPurchaseOrderID", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_PMPurchaseOrder_PMPMT", para);
        }
        //检索采购周材料计划
        public DataSet Select_WeekMatPlan(Guid id,string condition)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@id", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            para[1] = new SqlParameter("@condition", SqlDbType.NVarChar, 1000);
            para[1].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_WeekMatPlanSUm", para);
        }
        //检索采购周材料计划周次
        public DataSet Select_WeekMatSN(Guid id)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@id", SqlDbType.UniqueIdentifier);
            para[0].Value = id;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_PurchasePlanSN", para);
        }
    }
