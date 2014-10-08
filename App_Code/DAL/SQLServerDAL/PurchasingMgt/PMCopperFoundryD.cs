using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
///PMCopperFoundryD 的摘要说明
/// </summary>
namespace EquipmentMangementAjax.SQLServer
{
    public class PMCopperFoundryD : IPMCopperFoundry
    {
        public PMCopperFoundryD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        //查找铜材代工表
        public DataSet SelectPMCopperFoundry(string condition)
        {
            SqlParameter parm = new SqlParameter("@Condition", condition);
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_PMCopperFoundry", parm);
        }
        //新增铜材代工表
        public void InsertPMCopperFoundry(PMCopperFoundryinfo pMCopperFoundryinfo)
        {
            SqlParameter[] parm = new SqlParameter[4];

            parm[0] = new SqlParameter("@PMSI_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMCopperFoundryinfo.PMSI_ID;
            parm[1] = new SqlParameter("@PMCF_MaterialName", SqlDbType.VarChar, 200);
            parm[1].Value = pMCopperFoundryinfo.PMCF_MaterialName;
            parm[2] = new SqlParameter("@PMCF_ReturnTotalNum", SqlDbType.Decimal);
            parm[2].Value = pMCopperFoundryinfo.PMCF_ReturnTotalNum;
            parm[3] = new SqlParameter("@PMCF_InTotalNum", SqlDbType.Decimal);
            parm[3].Value = pMCopperFoundryinfo.PMCF_InTotalNum;
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_I_PMCopperFoundry", parm);
        }
        //修改铜材代工表
        public void UpdatePMCopperFoundry(PMCopperFoundryinfo pMCopperFoundryinfo)
        {
            SqlParameter[] parm = new SqlParameter[5];

            parm[0] = new SqlParameter("@PMSI_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMCopperFoundryinfo.PMSI_ID;
            parm[1] = new SqlParameter("@PMCF_MaterialName", SqlDbType.VarChar, 200);
            parm[1].Value = pMCopperFoundryinfo.PMCF_MaterialName;
            parm[2] = new SqlParameter("@PMCF_ReturnTotalNum", SqlDbType.Decimal);
            parm[2].Value = pMCopperFoundryinfo.PMCF_ReturnTotalNum;
            parm[3] = new SqlParameter("@PMCF_InTotalNum", SqlDbType.Decimal);
            parm[3].Value = pMCopperFoundryinfo.PMCF_InTotalNum;
            parm[4] = new SqlParameter("@PMCF_ID", SqlDbType.UniqueIdentifier);
            parm[4].Value = pMCopperFoundryinfo.PMCF_ID;
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_U_PMCopperFoundry", parm);
        }
        //查找铜材正料表
        public DataSet SelectPMCopperIn(PMCopperFoundryinfo pMCopperFoundryinfo)
        {
            SqlParameter[] parm = new SqlParameter[1];

            parm[0] = new SqlParameter("@PMCF_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMCopperFoundryinfo.PMCF_ID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                       CommandType.StoredProcedure, "Proc_S_PMCopperIn", parm);
        }
        //查找铜材退料表
        public DataSet SelectPMCopperReturn(PMCopperFoundryinfo pMCopperFoundryinfo)
        {
            SqlParameter[] parm = new SqlParameter[1];

            parm[0] = new SqlParameter("@PMCF_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMCopperFoundryinfo.PMCF_ID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                        CommandType.StoredProcedure, "Proc_S_PMCopperReturn", parm);
        }
        //查找铜材加工价格表
        public DataSet SelectPMCopperProcess(PMCopperFoundryinfo pMCopperFoundryinfo)
        {
            SqlParameter[] parm = new SqlParameter[1];

            parm[0] = new SqlParameter("@PMCF_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMCopperFoundryinfo.PMCF_ID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                        CommandType.StoredProcedure, "Proc_S_PMCopperProcess", parm);
        }
        //新增铜材正料表
        public void InsertPMCopperIn(PMCopperFoundryinfo pMCopperFoundryinfo)
        {
            SqlParameter[] parm = new SqlParameter[9];

            parm[0] = new SqlParameter("@PMCF_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMCopperFoundryinfo.PMCF_ID;
            parm[1] = new SqlParameter("@PMCI_BillNum", SqlDbType.VarChar, 200);
            parm[1].Value = pMCopperFoundryinfo.PMCI_BillNum;
            parm[2] = new SqlParameter("@PMCI_ProductNum", SqlDbType.Decimal);
            parm[2].Value = pMCopperFoundryinfo.PMCI_ProductNum;
            parm[3] = new SqlParameter("@PMCI_ProPrice", SqlDbType.Decimal);
            parm[3].Value = pMCopperFoundryinfo.PMCI_ProPrice;
            parm[4] = new SqlParameter("@PMCI_BillTotalPrice", SqlDbType.Decimal);
            parm[4].Value = pMCopperFoundryinfo.PMCI_BillTotalPrice;
            parm[5] = new SqlParameter("@PMCI_AccountRate", SqlDbType.Decimal);
            parm[5].Value = pMCopperFoundryinfo.PMCI_AccountRate;
            parm[6] = new SqlParameter("@PMCI_Pay", SqlDbType.Char);
            parm[6].Value = pMCopperFoundryinfo.PMCI_Pay;
            parm[7] = new SqlParameter("@PMCI_Remark", SqlDbType.VarChar, 400);
            parm[7].Value = pMCopperFoundryinfo.PMCI_Remark;
            parm[8] = new SqlParameter("@PMCI_Model", SqlDbType.VarChar, 100);
            parm[8].Value = pMCopperFoundryinfo.PMCI_Model;
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_I_PMCopperIn", parm);
        }
        //新增铜材退料表
        public void InsertPMCopperReturn(PMCopperFoundryinfo pMCopperFoundryinfo)
        {
            SqlParameter[] parm = new SqlParameter[4];

            parm[0] = new SqlParameter("@PMCF_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMCopperFoundryinfo.PMCF_ID;
            parm[1] = new SqlParameter("@PMCR_Remark", SqlDbType.VarChar, 400);
            parm[1].Value = pMCopperFoundryinfo.PMCR_Remark;
            parm[2] = new SqlParameter("@PMCR_Num", SqlDbType.Decimal);
            parm[2].Value = pMCopperFoundryinfo.PMCR_Num;
            parm[3] = new SqlParameter("@PMCR_DeductRate", SqlDbType.Decimal);
            parm[3].Value = pMCopperFoundryinfo.PMCR_DeductRate;

            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_I_PMCopperReturn", parm);
        }
        //新增铜材加工价格表
        public void InsertPMCopperProcess(PMCopperFoundryinfo pMCopperFoundryinfo)
        {
            SqlParameter[] parm = new SqlParameter[9];

            parm[0] = new SqlParameter("@PMCF_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMCopperFoundryinfo.PMCF_ID;
            parm[1] = new SqlParameter("@PMCP_MakeMan", SqlDbType.VarChar, 20);
            parm[1].Value = pMCopperFoundryinfo.PMCP_MakeMan;
            parm[2] = new SqlParameter("@PMCP_CopperPrice", SqlDbType.Decimal);
            parm[2].Value = pMCopperFoundryinfo.PMCP_CopperPrice;
            parm[3] = new SqlParameter("@PMCP_CopperDiscountRate", SqlDbType.Decimal);
            parm[3].Value = pMCopperFoundryinfo.PMCP_CopperDiscountRate;
            parm[4] = new SqlParameter("@PMCP_ZnPrice", SqlDbType.Decimal);
            parm[4].Value = pMCopperFoundryinfo.PMCP_ZnPrice;
            parm[5] = new SqlParameter("@PMCP_ZnDiscountRate", SqlDbType.Decimal);
            parm[5].Value = pMCopperFoundryinfo.PMCP_ZnDiscountRate;
            parm[6] = new SqlParameter("@PMCP_ProcessCost", SqlDbType.Decimal);
            parm[6].Value = pMCopperFoundryinfo.PMCP_ProcessCost;
            parm[7] = new SqlParameter("@PMCP_AccountRate", SqlDbType.Decimal);
            parm[7].Value = pMCopperFoundryinfo.PMCP_AccountRate;
            parm[8] = new SqlParameter("@PMCP_NowPrice", SqlDbType.Char, 2);
            parm[8].Value = pMCopperFoundryinfo.PMCP_NowPrice;
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_I_PMCopperProcess", parm);
        }
        //修改铜材正料表
        public void UpdatePMCopperIn(PMCopperFoundryinfo pMCopperFoundryinfo)
        {
            SqlParameter[] parm = new SqlParameter[10];

            parm[0] = new SqlParameter("@PMCF_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMCopperFoundryinfo.PMCF_ID;
            parm[1] = new SqlParameter("@PMCI_BillNum", SqlDbType.VarChar, 200);
            parm[1].Value = pMCopperFoundryinfo.PMCI_BillNum;
            parm[2] = new SqlParameter("@PMCI_ProductNum", SqlDbType.Decimal);
            parm[2].Value = pMCopperFoundryinfo.PMCI_ProductNum;
            parm[3] = new SqlParameter("@PMCI_ProPrice", SqlDbType.Decimal);
            parm[3].Value = pMCopperFoundryinfo.PMCI_ProPrice;
            parm[4] = new SqlParameter("@PMCI_BillTotalPrice", SqlDbType.Decimal);
            parm[4].Value = pMCopperFoundryinfo.PMCI_BillTotalPrice;
            parm[5] = new SqlParameter("@PMCI_AccountRate", SqlDbType.Decimal);
            parm[5].Value = pMCopperFoundryinfo.PMCI_AccountRate;
            parm[6] = new SqlParameter("@PMCI_Pay", SqlDbType.Char);
            parm[6].Value = pMCopperFoundryinfo.PMCI_Pay;
            parm[7] = new SqlParameter("@PMCI_Remark", SqlDbType.VarChar, 400);
            parm[7].Value = pMCopperFoundryinfo.PMCI_Remark;
            parm[8] = new SqlParameter("@PMCI_Model", SqlDbType.VarChar, 100);
            parm[8].Value = pMCopperFoundryinfo.PMCI_Model;
            parm[9] = new SqlParameter("@PMCI_ID", SqlDbType.UniqueIdentifier);
            parm[9].Value = pMCopperFoundryinfo.PMCI_ID;
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_U_PMCopperIn", parm);
        }
        //修改铜材退料表
        public void UpdatePMCopperReturn(PMCopperFoundryinfo pMCopperFoundryinfo)
        {
            SqlParameter[] parm = new SqlParameter[5];

            parm[0] = new SqlParameter("@PMCF_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMCopperFoundryinfo.PMCF_ID;
            parm[1] = new SqlParameter("@PMCR_Remark", SqlDbType.VarChar, 400);
            parm[1].Value = pMCopperFoundryinfo.PMCR_Remark;
            parm[2] = new SqlParameter("@PMCR_Num", SqlDbType.Decimal);
            parm[2].Value = pMCopperFoundryinfo.PMCR_Num;
            parm[3] = new SqlParameter("@PMCR_DeductRate", SqlDbType.Decimal);
            parm[3].Value = pMCopperFoundryinfo.PMCR_DeductRate;
            parm[4] = new SqlParameter("@PMCR_ID", SqlDbType.UniqueIdentifier);
            parm[4].Value = pMCopperFoundryinfo.PMCR_ID;
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_U_PMCopperReturn", parm);
        }
        //修改铜材加工价格表
        public void UpdatePMCopperProcess(PMCopperFoundryinfo pMCopperFoundryinfo)
        {
            SqlParameter[] parm = new SqlParameter[9];

            parm[0] = new SqlParameter("@PMCF_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMCopperFoundryinfo.PMCF_ID;
            parm[1] = new SqlParameter("@PMCP_ID", SqlDbType.UniqueIdentifier);
            parm[1].Value = pMCopperFoundryinfo.PMCP_ID;
            parm[2] = new SqlParameter("@PMCP_CopperPrice", SqlDbType.Decimal);
            parm[2].Value = pMCopperFoundryinfo.PMCP_CopperPrice;
            parm[3] = new SqlParameter("@PMCP_CopperDiscountRate", SqlDbType.Decimal);
            parm[3].Value = pMCopperFoundryinfo.PMCP_CopperDiscountRate;
            parm[4] = new SqlParameter("@PMCP_ZnPrice", SqlDbType.Decimal);
            parm[4].Value = pMCopperFoundryinfo.PMCP_ZnPrice;
            parm[5] = new SqlParameter("@PMCP_ZnDiscountRate", SqlDbType.Decimal);
            parm[5].Value = pMCopperFoundryinfo.PMCP_ZnDiscountRate;
            parm[6] = new SqlParameter("@PMCP_ProcessCost", SqlDbType.Decimal);
            parm[6].Value = pMCopperFoundryinfo.PMCP_ProcessCost;
            parm[7] = new SqlParameter("@PMCP_AccountRate", SqlDbType.Decimal);
            parm[7].Value = pMCopperFoundryinfo.PMCP_AccountRate;
            parm[8] = new SqlParameter("@PMCP_NowPrice", SqlDbType.Char, 2);
            parm[8].Value = pMCopperFoundryinfo.PMCP_NowPrice;
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_U_PMCopperProcess", parm);
        }
        //删除铜材加工价格表
        public void DeletePMCopperProcess(PMCopperFoundryinfo pMCopperFoundryinfo)
        {
            SqlParameter[] parm = new SqlParameter[1];

            parm[0] = new SqlParameter("@PMCP_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMCopperFoundryinfo.PMCP_ID;
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_D_PMCopperProcess", parm);
        }
        //删除铜材正料表
        public void DeletePMCopperIn(PMCopperFoundryinfo pMCopperFoundryinfo)
        {
            SqlParameter[] parm = new SqlParameter[3];

            parm[0] = new SqlParameter("@PMCI_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMCopperFoundryinfo.PMCI_ID;
            parm[1] = new SqlParameter("@PMCF_ID", SqlDbType.UniqueIdentifier);
            parm[1].Value = pMCopperFoundryinfo.PMCF_ID;
            parm[2] = new SqlParameter("@PMCI_ExpendNum", SqlDbType.Decimal);
            parm[2].Value = pMCopperFoundryinfo.PMCI_ExpendNum;
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_D_PMCopperIn", parm);
        }
        //删除铜材退料表
        public void DeletePMCopperReturn(PMCopperFoundryinfo pMCopperFoundryinfo)
        {
            SqlParameter[] parm = new SqlParameter[3];

            parm[0] = new SqlParameter("@PMCR_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMCopperFoundryinfo.PMCR_ID;
            parm[1] = new SqlParameter("@PMCF_ID", SqlDbType.UniqueIdentifier);
            parm[1].Value = pMCopperFoundryinfo.PMCF_ID;
            parm[2] = new SqlParameter("@PMCR_NetNum", SqlDbType.Decimal);
            parm[2].Value = pMCopperFoundryinfo.PMCR_NetNum;
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_D_PMCopperReturn", parm);
        }
    }
}