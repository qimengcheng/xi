using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
///PMPaymentBillD 的摘要说明
/// </summary>
namespace EquipmentMangementAjax.SQLServer
{
    public class PMPaymentBillD : IPMPaymentBill
    {
        public PMPaymentBillD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        //查找供应商付款开票情况
        public DataSet SelectPMPaymentBill(string condition)
        {
            SqlParameter parm = new SqlParameter("@Condition", condition);
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_PMPaymentBill", parm);
        }
        //新增供应商付款开票情况
        public void InsertPMPaymentBill(PMPaymentBillinfo pMPaymentBillinfo)
        {
            SqlParameter[] parm = new SqlParameter[5];

            parm[0] = new SqlParameter("@PMSI_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMPaymentBillinfo.PMSI_ID;
            parm[1] = new SqlParameter("@PMPB_TotalDebt", SqlDbType.Decimal);
            parm[1].Value = pMPaymentBillinfo.PMPB_TotalDebt;
            parm[2] = new SqlParameter("@PMPB_Due", SqlDbType.Decimal);
            parm[2].Value = pMPaymentBillinfo.PMPB_Due;
            parm[3] = new SqlParameter("@PMPB_TotalBill", SqlDbType.Decimal);
            parm[3].Value = pMPaymentBillinfo.PMPB_TotalBill;
            parm[4] = new SqlParameter("@PMPB_TotalPaided", SqlDbType.Decimal);
            parm[4].Value = pMPaymentBillinfo.PMPB_TotalPaided;
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_I_PMPaymentBill", parm);
        }
        //新增供应商付款情况
        public void InsertPMPaymentIDetail(PMPaymentBillinfo pMPaymentBillinfo)
        {
            SqlParameter[] parm = new SqlParameter[5];

            parm[0] = new SqlParameter("@PMPB_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMPaymentBillinfo.PMPB_ID;
            parm[1] = new SqlParameter("@PMPD_Pay", SqlDbType.Decimal);
            parm[1].Value = pMPaymentBillinfo.PMPD_Pay;
            parm[2] = new SqlParameter("@PMPD_PayWay", SqlDbType.VarChar,20);
            parm[2].Value = pMPaymentBillinfo.PMPD_PayWay;
            parm[3] = new SqlParameter("@PMPD_Man", SqlDbType.VarChar,20);
            parm[3].Value = pMPaymentBillinfo.PMPD_Man;
            parm[4] = new SqlParameter("@PMPD_PayTime", SqlDbType.Date);
            parm[4].Value = pMPaymentBillinfo.PMPD_PayTime;
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_I_PMPaymentIDetail", parm);
        }
        //新增供应商开票情况
        public void InsertPMBillDetial(PMPaymentBillinfo pMPaymentBillinfo)
        {
            SqlParameter[] parm = new SqlParameter[8];

            parm[0] = new SqlParameter("@PMPB_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMPaymentBillinfo.PMPB_ID;
            parm[1] = new SqlParameter("@PMBD_TotalBill", SqlDbType.Decimal);
            parm[1].Value = pMPaymentBillinfo.PMBD_TotalBill;
            parm[2] = new SqlParameter("@PMBD_BillNum", SqlDbType.VarChar, 200);
            parm[2].Value = pMPaymentBillinfo.PMBD_BillNum;
            parm[3] = new SqlParameter("@PMBD_ManName", SqlDbType.VarChar,20);
            parm[3].Value = pMPaymentBillinfo.PMBD_ManName;
            parm[4] = new SqlParameter("@PMBD_PayOff", SqlDbType.Char,2);
            parm[4].Value = pMPaymentBillinfo.PMBD_PayOff;
            parm[5] = new SqlParameter("@PMBD_BillDate", SqlDbType.Date);
            parm[5].Value = pMPaymentBillinfo.PMBD_BillDate;
            parm[6] = new SqlParameter("@PMBD_OrderNum", SqlDbType.VarChar,1000);
            parm[6].Value = pMPaymentBillinfo.PMBD_OrderNum;
            parm[7] = new SqlParameter("@PMBD_Remark", SqlDbType.VarChar,400);
            parm[7].Value = pMPaymentBillinfo.PMBD_Remark;
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_I_PMBillDetial", parm);
        }
        ////向采购订单插入开票情况
        //public void UpdatePMPurchaseOrder_Bill(PMPaymentBillinfo pMPaymentBillinfo)
        //{
        //    SqlParameter[] parm = new SqlParameter[3];

        //    parm[0] = new SqlParameter("@PMPO_PurchaseOrderID", SqlDbType.UniqueIdentifier);
        //    parm[0].Value = pMPaymentBillinfo.PMPO_PurchaseOrderID;
        //    parm[1] = new SqlParameter("@PMPO_BillNum", SqlDbType.VarChar, 100);
        //    parm[1].Value = pMPaymentBillinfo.PMPO_BillNum;
        //    parm[2] = new SqlParameter("@PMPO_BillTime", SqlDbType.Date);
        //    parm[2].Value = pMPaymentBillinfo.PMPO_BillTime;

        //    SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
        //             CommandType.StoredProcedure, "Proc_U_PMPurchaseOrder_Bill", parm);
        //}
        //修改采购付款开票表的付款情况
        public void UpdatePMPaymentBill_Payment(PMPaymentBillinfo pMPaymentBillinfo)
        {
            SqlParameter[] parm = new SqlParameter[2];

            parm[0] = new SqlParameter("@PMPB_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMPaymentBillinfo.PMPB_ID;
            parm[1] = new SqlParameter("@PMPD_Pay", SqlDbType.Decimal);
            parm[1].Value = pMPaymentBillinfo.PMPD_Pay;
            
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_U_PMPaymentBill_Payment", parm);
        }
        //修改采购付款开票表的开票情况
        public void UpdatePMPaymentBill_Bill(PMPaymentBillinfo pMPaymentBillinfo)
        {
            SqlParameter[] parm = new SqlParameter[2];

            parm[0] = new SqlParameter("@PMPB_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMPaymentBillinfo.PMPB_ID;
            parm[1] = new SqlParameter("@PMBD_TotalBill", SqlDbType.Decimal);
            parm[1].Value = pMPaymentBillinfo.PMBD_TotalBill;
            
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_U_PMPaymentBill_Bill", parm);
        }
        //查找没有开票采购订单
        public DataSet SelectPMPurchaseOrder_Supply(PMPaymentBillinfo pMPaymentBillinfo)
        {
            SqlParameter[] parm = new SqlParameter[1];

            parm[0] = new SqlParameter("@PMSI_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMPaymentBillinfo.PMSI_ID;
    
          return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_S_PMPurchaseOrder_Pay", parm);
        }
        //查找某一采购开票详细表
        public DataSet SelectPMBillDetial_One(string condition)
        {
            SqlParameter parm = new SqlParameter("@Condition", condition);
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_PMBillDetial_One", parm);
        }
        //查找相应供应商的采购付款详细表
        public DataSet SelectPMPaymentIDetail(PMPaymentBillinfo pMPaymentBillinfo)
        {
            SqlParameter[] parm = new SqlParameter[1];

            parm[0] = new SqlParameter("@PMPB_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMPaymentBillinfo.PMPB_ID;

            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                       CommandType.StoredProcedure, "Proc_S_PMPaymentIDetail", parm);
        }
        //查找采购开票详细表
        public DataSet SelectPMBillDetial(string condition)
        {
            SqlParameter parm = new SqlParameter("@Condition", condition);
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_PMBillDetial", parm);
        }
        //修改采购开票详细表
        public void UpdatePMBillDetial(PMPaymentBillinfo pMPaymentBillinfo)
        {
            SqlParameter[] parm = new SqlParameter[7];

            parm[0] = new SqlParameter("@PMBD_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMPaymentBillinfo.PMBD_ID;
            parm[1] = new SqlParameter("@PMBD_TotalBill", SqlDbType.Decimal);
            parm[1].Value = pMPaymentBillinfo.PMBD_TotalBill;
            parm[2] = new SqlParameter("@PMBD_BillNum", SqlDbType.VarChar,200);
            parm[2].Value = pMPaymentBillinfo.PMBD_BillNum;
            parm[3] = new SqlParameter("@PMBD_BillDate", SqlDbType.Date);
            parm[3].Value = pMPaymentBillinfo.PMBD_BillDate;
            parm[4] = new SqlParameter("@PMBD_PayOff", SqlDbType.Char,2);
            parm[4].Value = pMPaymentBillinfo.PMBD_PayOff;
            parm[5] = new SqlParameter("@PMBD_OrderNum", SqlDbType.VarChar, 1000);
            parm[5].Value = pMPaymentBillinfo.PMBD_OrderNum;
            parm[6] = new SqlParameter("@PMBD_Remark", SqlDbType.VarChar, 400);
            parm[6].Value = pMPaymentBillinfo.PMBD_Remark;
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_U_PMBillDetial", parm);
        }
        //删除采购开票详细表
        public void DeletePMBillDetial(PMPaymentBillinfo pMPaymentBillinfo)
        {
            SqlParameter[] parm = new SqlParameter[1];

            parm[0] = new SqlParameter("@PMBD_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMPaymentBillinfo.PMBD_ID;
            
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_D_PMBillDetial", parm);
        }
        //修改采购付款详细表
        public void UpdatePMPaymentIDetail(PMPaymentBillinfo pMPaymentBillinfo)
        {
            SqlParameter[] parm = new SqlParameter[4];

            parm[0] = new SqlParameter("@PMPD_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMPaymentBillinfo.PMPD_ID;
            parm[1] = new SqlParameter("@PMPD_PayTime", SqlDbType.Date);
            parm[1].Value = pMPaymentBillinfo.PMPD_PayTime;
            parm[2] = new SqlParameter("@PMPD_PayWay", SqlDbType.VarChar, 20);
            parm[2].Value = pMPaymentBillinfo.PMPD_PayWay;
            parm[3] = new SqlParameter("@PMPD_Pay", SqlDbType.Decimal);
            parm[3].Value = pMPaymentBillinfo.PMPD_Pay;
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_U_PMPaymentIDetail", parm);
        }
        //删除采购付款详细表
        public void DeletePMPaymentIDetail(PMPaymentBillinfo pMPaymentBillinfo)
        {
            SqlParameter[] parm = new SqlParameter[1];

            parm[0] = new SqlParameter("@PMPD_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMPaymentBillinfo.PMPD_ID;

            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_D_PMPaymentIDetail", parm);
        }
        //修改采购订单的开票状况
        public void UpdatePMPO_AlreadyBill(PMPaymentBillinfo pMPaymentBillinfo)
        {
            SqlParameter[] parm = new SqlParameter[2];

            parm[0] = new SqlParameter("@PMPO_PurchaseOrderNum", SqlDbType.VarChar, 100);
            parm[0].Value = pMPaymentBillinfo.PMPO_PurchaseOrderNum;
            parm[1] = new SqlParameter("@PMPO_AlreadyBill", SqlDbType.Char, 2);
            parm[1].Value = pMPaymentBillinfo.PMPO_AlreadyBill;
            
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_U_PMPO_AlreadyBill", parm);
        }
        //修改采购订单的结款状况
        public void UpdatePMPO_AlreadyPay(PMPaymentBillinfo pMPaymentBillinfo)
        {
            SqlParameter[] parm = new SqlParameter[3];

            parm[0] = new SqlParameter("@PMPO_PurchaseOrderID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMPaymentBillinfo.PMPO_PurchaseOrderID;
            parm[1] = new SqlParameter("@PMPO_AlreadyPay", SqlDbType.Char,2);
            parm[1].Value = pMPaymentBillinfo.PMPO_AlreadyPay;
            parm[2] = new SqlParameter("@PMPO_ResidueMoney", SqlDbType.Decimal);
            parm[2].Value = pMPaymentBillinfo.PMPO_ResidueMoney;
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_U_PMPO_AlreadyPay", parm);
        }
        //查找没有付款的采购订单
        public DataSet SelectPMPurchaseOrder_NBill(PMPaymentBillinfo pMPaymentBillinfo)
        {
            SqlParameter[] parm = new SqlParameter[1];

            parm[0] = new SqlParameter("@PMSI_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMPaymentBillinfo.PMSI_ID;

            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                       CommandType.StoredProcedure, "Proc_S_PMPurchaseOrder_NBill", parm);
        }
        ////修改采购开票详细表的剩余配额
        //public void UpdatePMBD_Remaining(string condition)
        //{
        //    SqlParameter parm = new SqlParameter("@Condition", condition);
            
        //    SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
        //             CommandType.StoredProcedure, "Proc_U_PMBD_Remaining", parm);
        //}
        //查找没有开票的采购订单
        public DataSet SelectPMPurchaseOrder_Pay(PMPaymentBillinfo pMPaymentBillinfo)
        {
            SqlParameter[] parm = new SqlParameter[1];

            parm[0] = new SqlParameter("@PMSI_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMPaymentBillinfo.PMSI_ID;

            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                       CommandType.StoredProcedure, "Proc_S_PMPurchaseOrder_Pay", parm);
        }
        //修改采购付款开票表的欠款和应付款
        public void UpdatePMPB_TDBill(PMPaymentBillinfo pMPaymentBillinfo)
        {
            SqlParameter[] parm = new SqlParameter[3];

            parm[0] = new SqlParameter("@PMPB_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMPaymentBillinfo.PMPB_ID;
            parm[1] = new SqlParameter("@PMPB_TotalDebt", SqlDbType.Decimal);
            parm[1].Value = pMPaymentBillinfo.PMPB_TotalDebt;
            parm[2] = new SqlParameter("@PMPB_Due", SqlDbType.Decimal);
            parm[2].Value = pMPaymentBillinfo.PMPB_Due;
          SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                       CommandType.StoredProcedure, "Proc_U_PMPB_TDBill", parm);
        }
        //计算对应供应商的欠款总额和应付款
        public void UpdatePMPaymentBill(PMPaymentBillinfo pMPaymentBillinfo)
        {
            SqlParameter[] parm = new SqlParameter[1];

            parm[0] = new SqlParameter("@PMSI_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMPaymentBillinfo.PMSI_ID;
            
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                         CommandType.StoredProcedure, "Proc_U_PMPaymentBill", parm);
        }

        //查找没有付款的采购订单
        public DataSet SelectPMPurchaseOrder(string condition)
        {
            SqlParameter parm = new SqlParameter("@Condition", condition);
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_PMPurchaseOrder_One", parm);
        }
    }
}