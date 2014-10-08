using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
///PMSupplyCertificD 的摘要说明
/// </summary>
namespace EquipmentMangementAjax.SQLServer
{
    public class PMSupplyCertificD : IPMSupplyCertific
    {
        public PMSupplyCertificD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        //查询认证申请表
        public DataSet SelectPMSupplyCertificApply(string condition)
        {
            SqlParameter parm = new SqlParameter("@Condition", condition);
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_PMSupplyCertificApply", parm);
        }
        //新增认证申请表
        public void InsertPMSupplyCertificApply(PMSupplyCertificinfo pMSupplyCertificinfo)
        {

            SqlParameter[] parm = new SqlParameter[6];
            parm[0] = new SqlParameter("@PMSCA_ApplyDepart", SqlDbType.VarChar, 200);
            parm[0].Value = pMSupplyCertificinfo.PMSCA_ApplyDepart;
            parm[1] = new SqlParameter("@PMSCA_MaterialName", SqlDbType.VarChar, 200);
            parm[1].Value = pMSupplyCertificinfo.PMSCA_MaterialName;
            parm[2] = new SqlParameter("@PMSI_ID", SqlDbType.UniqueIdentifier);
            parm[2].Value = pMSupplyCertificinfo.PMSI_ID;
            parm[3] = new SqlParameter("@PMSCA_ApplyAim", SqlDbType.VarChar, 400);
            parm[3].Value = pMSupplyCertificinfo.PMSCA_ApplyAim;
            parm[4] = new SqlParameter("@PMSCA_ApplyMan", SqlDbType.VarChar, 20);
            parm[4].Value = pMSupplyCertificinfo.PMSCA_ApplyMan;
            parm[5] = new SqlParameter("@PMSCA_State", SqlDbType.VarChar, 20);
            parm[5].Value = pMSupplyCertificinfo.PMSCA_State;
           
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_I_PMSupplyCertificApply", parm);
        }
        //删除认证申请表
        public void DeletePMSupplyCertificApply(PMSupplyCertificinfo pMSupplyCertificinfo)
        {

            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@PMSCA_CertificApplyNum", SqlDbType.UniqueIdentifier );
            parm[0].Value = pMSupplyCertificinfo.PMSCA_CertificApplyNum;
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                    CommandType.StoredProcedure, "Proc_D_PMSupplyCertificApply", parm);
        }
        //查询某一供应商认证申请表
        public DataSet SelectPMSupplyCertificApply_One(PMSupplyCertificinfo pMSupplyCertificinfo)
        {

            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@PMSCA_CertificApplyNum", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMSupplyCertificinfo.PMSCA_CertificApplyNum;
           return  SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                    CommandType.StoredProcedure, "Proc_S_PMSupplyCertificApply_One", parm);
        }
        //修改认证申请表
        public void UpdatePMSupplyCertificApply(PMSupplyCertificinfo pMSupplyCertificinfo)
        {

            SqlParameter[] parm = new SqlParameter[6];
            parm[0] = new SqlParameter("@PMSCA_ApplyDepart", SqlDbType.VarChar, 200);
            parm[0].Value = pMSupplyCertificinfo.PMSCA_ApplyDepart;
            parm[1] = new SqlParameter("@PMSCA_MaterialName", SqlDbType.VarChar, 200);
            parm[1].Value = pMSupplyCertificinfo.PMSCA_MaterialName;
            parm[2] = new SqlParameter("@PMSI_ID", SqlDbType.UniqueIdentifier);
            parm[2].Value = pMSupplyCertificinfo.PMSI_ID;
            parm[3] = new SqlParameter("@PMSCA_ApplyAim", SqlDbType.VarChar, 400);
            parm[3].Value = pMSupplyCertificinfo.PMSCA_ApplyAim;
            parm[4] = new SqlParameter("@PMSCA_ApplyModifier", SqlDbType.VarChar, 20);
            parm[4].Value = pMSupplyCertificinfo.PMSCA_ApplyModifier;
            
            parm[5] = new SqlParameter("@PMSCA_CertificApplyNum ", SqlDbType.UniqueIdentifier );
            parm[5].Value = pMSupplyCertificinfo.PMSCA_CertificApplyNum;
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_U_PMSupplyCertificApply", parm);
        }
        //新增供应商认证信息表
        public void InsertPMSupplyCertificInfo(PMSupplyCertificinfo pMSupplyCertificinfo)
        {

            SqlParameter[] parm = new SqlParameter[10];
            parm[0] = new SqlParameter("@PMSCI_Model ", SqlDbType.VarChar, 100);
            parm[0].Value = pMSupplyCertificinfo.PMSCI_Model;
            parm[1] = new SqlParameter("@PMSCI_CheckDepertment", SqlDbType.VarChar, 100);
            parm[1].Value = pMSupplyCertificinfo.PMSCI_CheckDepertment;
            parm[2] = new SqlParameter("@PMSCA_CertificApplyNum", SqlDbType.UniqueIdentifier);
            parm[2].Value = pMSupplyCertificinfo.PMSCA_CertificApplyNum;
            parm[3] = new SqlParameter("@PMSCI_CertificSchedule", SqlDbType.VarChar, 100);
            parm[3].Value = pMSupplyCertificinfo.PMSCI_CertificSchedule;
            parm[4] = new SqlParameter("@PMSCI_CertificResult", SqlDbType.VarChar, 400);
            parm[4].Value = pMSupplyCertificinfo.PMSCI_CertificResult;
            parm[5] = new SqlParameter("@PMSCI_Remark", SqlDbType.VarChar ,400);
            parm[5].Value = pMSupplyCertificinfo.PMSCI_Remark;
            parm[6] = new SqlParameter("@PMSCI_Accessory ", SqlDbType.Char, 2);
            parm[6].Value = pMSupplyCertificinfo.PMSCI_Accessory;
            parm[7] = new SqlParameter("@PMSCI_AccNum", SqlDbType.VarChar, 100);
            parm[7].Value = pMSupplyCertificinfo.PMSCI_AccNum;
            parm[8] = new SqlParameter("@PMSCI_AccName", SqlDbType.VarChar, 100);
            parm[8].Value = pMSupplyCertificinfo.PMSCI_AccName;
            parm[9] = new SqlParameter("@PMSCI_AccPath", SqlDbType.VarChar, 100);
            parm[9].Value = pMSupplyCertificinfo.PMSCI_AccPath;
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_I_PMSupplyCertificInfo", parm);
        }
        //修改供应商认证信息表
        public void UpdatePMSupplyCertificInfo(PMSupplyCertificinfo pMSupplyCertificinfo)
        {

            SqlParameter[] parm = new SqlParameter[11];
            parm[0] = new SqlParameter("@PMSCI_Model ", SqlDbType.VarChar, 100);
            parm[0].Value = pMSupplyCertificinfo.PMSCI_Model;
            parm[1] = new SqlParameter("@PMSCI_CheckDepertment", SqlDbType.VarChar, 100);
            parm[1].Value = pMSupplyCertificinfo.PMSCI_CheckDepertment;
            parm[2] = new SqlParameter("@PMSCI_ID", SqlDbType.UniqueIdentifier);
            parm[2].Value = pMSupplyCertificinfo.PMSCI_ID;
            parm[3] = new SqlParameter("@PMSCI_CertificSchedule", SqlDbType.VarChar, 100);
            parm[3].Value = pMSupplyCertificinfo.PMSCI_CertificSchedule;
            parm[4] = new SqlParameter("@PMSCI_CertificResult", SqlDbType.VarChar, 400);
            parm[4].Value = pMSupplyCertificinfo.PMSCI_CertificResult;
            parm[5] = new SqlParameter("@PMSCI_Remark", SqlDbType.VarChar, 400);
            parm[5].Value = pMSupplyCertificinfo.PMSCI_Remark;
            parm[6] = new SqlParameter("@PMSCI_CertificModifier", SqlDbType.VarChar, 20);
            parm[6].Value = pMSupplyCertificinfo.PMSCI_CertificModifier;
            parm[7] = new SqlParameter("@PMSCI_AccNum", SqlDbType.VarChar, 100);
            parm[7].Value = pMSupplyCertificinfo.PMSCI_AccNum;
            parm[8] = new SqlParameter("@PMSCI_AccName", SqlDbType.VarChar,100);
            parm[8].Value = pMSupplyCertificinfo.PMSCI_AccName;
            parm[9] = new SqlParameter("@PMSCI_AccPath", SqlDbType.VarChar, 100);
            parm[9].Value = pMSupplyCertificinfo.PMSCI_AccPath;
            parm[10] = new SqlParameter("@PMSCI_Accessory", SqlDbType.Char, 2);
            parm[10].Value = pMSupplyCertificinfo.PMSCI_Accessory;
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_U_PMSupplyCertificInfo", parm);
        }
        //查询供应商认证信息表
        public DataSet SelectPMSupplyCertificInfo(PMSupplyCertificinfo pMSupplyCertificinfo)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@PMSCA_CertificApplyNum", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMSupplyCertificinfo.PMSCA_CertificApplyNum;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_S_PMSupplyCertificInfo",parm);
        }
        //查询某一条供应商认证信息
        public DataSet SelectPMSupplyCertificInfo_One(PMSupplyCertificinfo pMSupplyCertificinfo)
        {

            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@PMSCI_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMSupplyCertificinfo.PMSCI_ID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_S_PMSupplyCertificInfo_One", parm);
        }
        //删除某一条供应商认证信息
        public void DeletePMSupplyCertificInfo_One(PMSupplyCertificinfo pMSupplyCertificinfo)
        {

            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@PMSCI_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMSupplyCertificinfo.PMSCI_ID;
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                    CommandType.StoredProcedure, "Proc_D_PMSupplyCertificInfo_One", parm);
        }
        //修改认证申请单申请状态
        public void UpdatePMSCA_State(PMSupplyCertificinfo pMSupplyCertificinfo)
        {

            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@PMSCA_CertificApplyNum  ", SqlDbType.UniqueIdentifier );
            parm[0].Value = pMSupplyCertificinfo.PMSCA_CertificApplyNum;
            parm[1] = new SqlParameter("@PMSCA_State", SqlDbType.VarChar, 20);
            parm[1].Value = pMSupplyCertificinfo.PMSCA_State;
           
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_U_PMSCA_State", parm);
        }
        //品保部会签
        public void InsertPMSCA_QASign(PMSupplyCertificinfo pMSupplyCertificinfo)
        {

            SqlParameter[] parm = new SqlParameter[4];
            parm[0] = new SqlParameter("@PMSCA_CertificApplyNum  ", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMSupplyCertificinfo.PMSCA_CertificApplyNum;
            parm[1] = new SqlParameter("@PMSCA_QASignResult", SqlDbType.VarChar, 20);
            parm[1].Value = pMSupplyCertificinfo.PMSCA_QASignResult;
            parm[2] = new SqlParameter("@PMSCA_QASignOpinion", SqlDbType.VarChar, 400);
            parm[2].Value = pMSupplyCertificinfo.PMSCA_QASignOpinion;
            parm[3] = new SqlParameter("@PMSCA_QASignMan", SqlDbType.VarChar, 20);
            parm[3].Value = pMSupplyCertificinfo.PMSCA_QASignMan;
            
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_I_PMSCA_QASign", parm);
        }
        //生产部会签
        public void InsertPMSCA_PDSign(PMSupplyCertificinfo pMSupplyCertificinfo)
        {

            SqlParameter[] parm = new SqlParameter[4];
            parm[0] = new SqlParameter("@PMSCA_CertificApplyNum  ", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMSupplyCertificinfo.PMSCA_CertificApplyNum;
            parm[1] = new SqlParameter("@PMSCA_PDSignResult", SqlDbType.VarChar, 20);
            parm[1].Value = pMSupplyCertificinfo.PMSCA_PDSignResult;
            parm[2] = new SqlParameter("@PMSCA_PDSignOpinion", SqlDbType.VarChar, 400);
            parm[2].Value = pMSupplyCertificinfo.PMSCA_PDSignOpinion;
            parm[3] = new SqlParameter("@PMSCA_PDSignMan", SqlDbType.VarChar, 20);
            parm[3].Value = pMSupplyCertificinfo.PMSCA_PDSignMan;
            
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_I_PMSCA_PDSign", parm);
        }
        //工程部会签
        public void InsertPMSCA_EDSign(PMSupplyCertificinfo pMSupplyCertificinfo)
        {

            SqlParameter[] parm = new SqlParameter[4];
            parm[0] = new SqlParameter("@PMSCA_CertificApplyNum  ", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMSupplyCertificinfo.PMSCA_CertificApplyNum;
            parm[1] = new SqlParameter("@PMSCA_EDSignResult", SqlDbType.VarChar, 20);
            parm[1].Value = pMSupplyCertificinfo.PMSCA_EDSignResult;
            parm[2] = new SqlParameter("@PMSCA_EDSignOpinion", SqlDbType.VarChar, 400);
            parm[2].Value = pMSupplyCertificinfo.PMSCA_EDSignOpinion;
            parm[3] = new SqlParameter("@PMSCA_EDSianMan", SqlDbType.VarChar, 20);
            parm[3].Value = pMSupplyCertificinfo.PMSCA_EDSianMan;
            
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_I_PMSCA_EDSign", parm);
        }
        //技术副总审核
        public void InsertPMSCA_DMCheck(PMSupplyCertificinfo pMSupplyCertificinfo)
        {

            SqlParameter[] parm = new SqlParameter[4];
            parm[0] = new SqlParameter("@PMSCA_CertificApplyNum  ", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMSupplyCertificinfo.PMSCA_CertificApplyNum;
            parm[1] = new SqlParameter("@PMSCA_DMCheckResult", SqlDbType.VarChar, 20);
            parm[1].Value = pMSupplyCertificinfo.PMSCA_DMCheckResult;
            parm[2] = new SqlParameter("@PMSCA_DMCheckOpinion", SqlDbType.VarChar, 400);
            parm[2].Value = pMSupplyCertificinfo.PMSCA_DMCheckOpinion;
            parm[3] = new SqlParameter("@PMSCA_DMCheckMan", SqlDbType.VarChar, 20);
            parm[3].Value = pMSupplyCertificinfo.PMSCA_DMCheckMan;
           
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_I_PMSCA_DMCheck", parm);
        }
        //总经理审核
        public void InsertPMSCA_GMCheck(PMSupplyCertificinfo pMSupplyCertificinfo)
        {

            SqlParameter[] parm = new SqlParameter[4];
            parm[0] = new SqlParameter("@PMSCA_CertificApplyNum  ", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMSupplyCertificinfo.PMSCA_CertificApplyNum;
            parm[1] = new SqlParameter("@PMSCA_GMCheckResult", SqlDbType.VarChar, 20);
            parm[1].Value = pMSupplyCertificinfo.PMSCA_GMCheckResult;
            parm[2] = new SqlParameter("@PMSCA_GMCheckOpinion", SqlDbType.VarChar, 400);
            parm[2].Value = pMSupplyCertificinfo.PMSCA_GMCheckOpinion;
            parm[3] = new SqlParameter("@PMSCA_GMCheckMan", SqlDbType.VarChar, 20);
            parm[3].Value = pMSupplyCertificinfo.PMSCA_GMCheckMan;
           
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_I_PMSCA_GMCheck", parm);
        }
        //查找技术副总审核
        public DataSet  SelectPMSCA_DMCheckOpinion(PMSupplyCertificinfo pMSupplyCertificinfo)
        {

            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@PMSCA_CertificApplyNum ", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMSupplyCertificinfo.PMSCA_CertificApplyNum;
           return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                    CommandType.StoredProcedure, "Proc_S_PMSCA_DMCheckOpinion", parm);
        }
        //查找供应商
        public void SelectPMSupply(PMSupplyCertificinfo pMSupplyCertificinfo)
        {

            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_S_PMSupply");
        }

        //新增认证申请会签表
        public void InsertPMSupplyCertificApplyCountersign(PMSupplyCertificinfo pMSupplyCertificinfo)
        {

            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@PMSCA_CertificApplyNum", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMSupplyCertificinfo.PMSCA_CertificApplyNum;
            parm[1] = new SqlParameter("@PMSCAC_SignPartment", SqlDbType.VarChar, 200);
            parm[1].Value = pMSupplyCertificinfo.PMSCAC_SignPartment;

            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_I_PMSupplyCertificApplyCountersign", parm);
        }
        //修改认证申请会签表
        public void UpdatePMSupplyCertificApplyCountersign(PMSupplyCertificinfo pMSupplyCertificinfo)
        {
            SqlParameter[] parm = new SqlParameter[4];
            parm[0] = new SqlParameter("@PMSCAC_SignResult", SqlDbType.VarChar, 20);
            parm[0].Value = pMSupplyCertificinfo.PMSCAC_SignResult;
            parm[1] = new SqlParameter("@PMSCAC_SignOpinion", SqlDbType.VarChar, 400);
            parm[1].Value = pMSupplyCertificinfo.PMSCAC_SignOpinion;
            parm[2] = new SqlParameter("@PMSCAC_SignMan", SqlDbType.VarChar, 20);
            parm[2].Value = pMSupplyCertificinfo.PMSCAC_SignMan;
            parm[3] = new SqlParameter("@PMSCAC_ID", SqlDbType.UniqueIdentifier);
            parm[3].Value = pMSupplyCertificinfo.PMSCAC_ID;
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                    CommandType.StoredProcedure, "Proc_U_PMSupplyCertificApplyCountersign", parm);
        }

        //查找认证申请会签表
        public DataSet SelectPMSupplyCertificApplyCountersign(PMSupplyCertificinfo pMSupplyCertificinfo)
        {

            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@PMSCA_CertificApplyNum ", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMSupplyCertificinfo.PMSCA_CertificApplyNum;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_S_PMSupplyCertificApplyCountersign", parm);
        }
        //查找部门
        public DataSet SelectPMSCAC_Organization(string condition)
        {
            SqlParameter parm = new SqlParameter("@Condition", condition);
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_PMSCAC_Organization", parm);
        }

        //查找认证申请会签表
        public DataSet SelectPMSupplyCertificApplyCountersign_One(PMSupplyCertificinfo pMSupplyCertificinfo)
        {

            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@PMSCAC_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMSupplyCertificinfo.PMSCAC_ID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Proc_S_PMSupplyCertificApplyCountersign_One", parm);
        }

        //删除认证会签部门
        public void DeletePMSupplyCertificApplyCountersign(PMSupplyCertificinfo pMSupplyCertificinfo)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@PMSCAC_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pMSupplyCertificinfo.PMSCAC_ID;
         SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                     CommandType.StoredProcedure, "Pro_D_PMSupplyCertificApplyCountersign", parm);
        }
    }
}