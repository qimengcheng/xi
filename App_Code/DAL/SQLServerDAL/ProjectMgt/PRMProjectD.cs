using System;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
///PRMProjectD 的摘要说明
/// </summary>
/// 
namespace EquipmentMangementAjax.SQLServer
{
    public class PRMProjectD : IPRMProject
    {
        public PRMProjectD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        //查询项目
        public DataSet SelectPRMProject(string condition)
        {
            SqlParameter parm = new SqlParameter("@Condition", condition);
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_PRMProject", parm);
        }
        //查询某一项目
        public DataSet SelectPRMProject_One(Guid  PRMP_ID)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@PRMP_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = PRMP_ID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_PRMProject_One", parm);
        }
//查找技术副总意见
        public DataSet SelectPRMP_DesignMangCheckOpinion(Guid PRMP_ID)
        {
            SqlParameter parm = new SqlParameter("@PRMP_ID", PRMP_ID);
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_PRMP_DesignMangCheckOpinion", parm);
        }

        //新建项目
        public void InsertPRMProject(string PRMP_ProductMode, string PRMP_ProjectType, string PRMP_Sample, string PRMP_ProjectName, string PRMP_ImproveAim, string PRMP_ImproveRequest, string PRMPA_Accessory, string PRMPA_AccNum, string PRMPA_AccPath, string PRMPA_AccState, string PRMPA_AccName, string PRMP_SupplyDepartment)
        {
            SqlParameter[] parm = new SqlParameter[12];

            parm[0] = new SqlParameter("@PRMP_ProductMode", SqlDbType.VarChar, 100);
            parm[0].Value = PRMP_ProductMode;
            parm[1] = new SqlParameter("@PRMP_ProjectType", SqlDbType.VarChar, 50);
            parm[1].Value = PRMP_ProjectType;
            parm[2] = new SqlParameter("@PRMP_Sample", SqlDbType.VarChar, 10);
            parm[2].Value = PRMP_Sample;
            parm[3] = new SqlParameter("@PRMP_ProjectName", SqlDbType.VarChar, 100);
            parm[3].Value = PRMP_ProjectName;
            parm[4] = new SqlParameter("@PRMP_ImproveAim", SqlDbType.VarChar, 400);
            parm[4].Value = PRMP_ImproveAim;
            parm[5] = new SqlParameter("@PRMP_ImproveRequest", SqlDbType.VarChar, 400);
            parm[5].Value = PRMP_ImproveRequest;
            parm[6] = new SqlParameter("@PRMPA_Accessory", SqlDbType.Char,2);
            parm[6].Value = PRMPA_Accessory;
            parm[7] = new SqlParameter("@PRMPA_AccNum", SqlDbType.VarChar, 100);
            parm[7].Value = PRMPA_AccNum;
            parm[8] = new SqlParameter("@PRMPA_AccName", SqlDbType.VarChar, 100);
            parm[8].Value = PRMPA_AccName;
            parm[9] = new SqlParameter("@PRMPA_AccPath", SqlDbType.VarChar, 100);
            parm[9].Value = PRMPA_AccPath;
            parm[10] = new SqlParameter("@PRMPA_AccState", SqlDbType.VarChar,20);
            parm[10].Value = PRMPA_AccState;
            parm[11] = new SqlParameter("@PRMP_SupplyDepartment", SqlDbType.VarChar, 100);
            parm[11].Value = PRMP_SupplyDepartment;
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                            CommandType.StoredProcedure, "Proc_I_PRMProject", parm);
        }
        //总经理审核
        public void InsertPRMP_GeneralMangCheckOpinion(Guid PRMP_ID, string PRMP_GeneralMangCheckResult, string PRMP_GeneralMangCheckOpinion, string PRMP_ProjectStates, string PRMP_GeneralMangName)
        {
            SqlParameter[] parm = new SqlParameter[5];

            parm[0] = new SqlParameter("@PRMP_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = PRMP_ID;
            parm[1] = new SqlParameter("@PRMP_GeneralMangCheckResult", SqlDbType.VarChar, 20);
            parm[1].Value = PRMP_GeneralMangCheckResult;
           
            parm[2] = new SqlParameter("@PRMP_GeneralMangCheckOpinion", SqlDbType.VarChar, 400);
            parm[2].Value = PRMP_GeneralMangCheckOpinion;
            parm[3] = new SqlParameter("@PRMP_ProjectStates", SqlDbType.VarChar, 20);
            parm[3].Value = PRMP_ProjectStates;
            parm[4] = new SqlParameter("@PRMP_GeneralMangName", SqlDbType.VarChar, 50);
            parm[4].Value = PRMP_GeneralMangName;
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                            CommandType.StoredProcedure, "Proc_I_PRMP_GeneralMangCheckOpinion", parm);
        }
        //技术副总审核
        public void InsertPRMP_DesignMangCheckOpinion(Guid PRMP_ID, string PRMPD_DesignMangCheckResult, string PRMPD_DesignMangCheckOpinion, string PRMPD_DesignMangCheckSate, string PRMPD_DesignMangName)
        {
            SqlParameter[] parm = new SqlParameter[5];

            parm[0] = new SqlParameter("@PRMP_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = PRMP_ID;
            parm[1] = new SqlParameter("@PRMPD_DesignMangCheckResult", SqlDbType.VarChar, 20);
            parm[1].Value = PRMPD_DesignMangCheckResult;
           
            parm[2] = new SqlParameter("@PRMPD_DesignMangCheckOpinion", SqlDbType.VarChar, 400);
            parm[2].Value = PRMPD_DesignMangCheckOpinion;
            parm[3] = new SqlParameter("@PRMPD_DesignMangCheckSate", SqlDbType.VarChar, 20);
            parm[3].Value = PRMPD_DesignMangCheckSate;
            parm[4] = new SqlParameter("@PRMPD_DesignMangName", SqlDbType.VarChar, 50);
            parm[4].Value = PRMPD_DesignMangName;
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                            CommandType.StoredProcedure, "Proc_I_PRMP_DesignMangCheckOpinion", parm);
        }
        //插入部门
        public void InsertPRMP_ResponDepart(Guid PRMP_ID, string PRMP_ResponDepart)
        {
            SqlParameter[] parm = new SqlParameter[2];

            parm[0] = new SqlParameter("@PRMP_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = PRMP_ID;
            parm[1] = new SqlParameter("@PRMP_ResponDepart", SqlDbType.VarChar, 100);
            parm[1].Value = PRMP_ResponDepart;

            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                            CommandType.StoredProcedure, "Proc_I_PRMP_ResponDepart", parm);
        }
        //更新项目状态
        public void UpdatePRMP_ProjectStates(Guid PRMP_ID, string PRMP_ProjectStates)
        {
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@PRMP_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = PRMP_ID;
            parm[1] = new SqlParameter("@PRMP_ProjectStates", SqlDbType.VarChar, 20);
            parm[1].Value = PRMP_ProjectStates;
           SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_U_PRMP_ProjectStates", parm);
        }
        //修改项目
        public void UpdatePRMProject(Guid PRMP_ID, string PRMP_ProductMode, string PRMP_ProjectType, string PRMP_Sample, string PRMP_ProjectName, string PRMP_ImproveAim, string PRMP_ImproveRequest, string PRMPA_Accessory, string PRMPA_AccNum, string PRMPA_AccPath, string PRMPA_AccState, string PRMPA_AccName)
        {
            SqlParameter[] parm = new SqlParameter[12];

            parm[0] = new SqlParameter("@PRMP_ProductMode", SqlDbType.VarChar, 100);
            parm[0].Value = PRMP_ProductMode;
            parm[1] = new SqlParameter("@PRMP_ProjectType", SqlDbType.VarChar, 50);
            parm[1].Value = PRMP_ProjectType;
            parm[2] = new SqlParameter("@PRMP_Sample", SqlDbType.VarChar, 10);
            parm[2].Value = PRMP_Sample;
            parm[3] = new SqlParameter("@PRMP_ProjectName", SqlDbType.VarChar, 100);
            parm[3].Value = PRMP_ProjectName;
            parm[4] = new SqlParameter("@PRMP_ImproveAim", SqlDbType.VarChar, 400);
            parm[4].Value = PRMP_ImproveAim;
            parm[5] = new SqlParameter("@PRMP_ImproveRequest", SqlDbType.VarChar, 400);
            parm[5].Value = PRMP_ImproveRequest;
            parm[6] = new SqlParameter("@PRMP_ID", SqlDbType.UniqueIdentifier );
            parm[6].Value = PRMP_ID;
            parm[7] = new SqlParameter("@PRMPA_Accessory", SqlDbType.Char, 2);
            parm[7].Value = PRMPA_Accessory;
            parm[8] = new SqlParameter("@PRMPA_AccNum", SqlDbType.VarChar, 100);
            parm[8].Value = PRMPA_AccNum;
            parm[9] = new SqlParameter("@PRMPA_AccName", SqlDbType.VarChar, 100);
            parm[9].Value = PRMPA_AccName;
            parm[10] = new SqlParameter("@PRMPA_AccPath", SqlDbType.VarChar, 100);
            parm[10].Value = PRMPA_AccPath; 
            parm[11] = new SqlParameter("@PRMPA_AccState", SqlDbType.VarChar, 20);
            parm[11].Value = PRMPA_AccState;
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                            CommandType.StoredProcedure, "Proc_U_PRMProject", parm);
        }
        public DataSet SelectPRMProductMode(string condition)
        {
            SqlParameter parm = new SqlParameter("@Condition", condition);
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_PMSProductMode",parm);
        }
        //查找项目审核结果
        public DataSet SelectProjectCheck(string Condition)
        {
            SqlParameter parm = new SqlParameter("@Condition", Condition);
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_PRMProject_Check", parm);
        }
        //删除项目
        public void DeleteProject(Guid PRMP_ID)
        {
            SqlParameter[] parm = new SqlParameter[1];

            parm[0] = new SqlParameter("@PRMP_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = PRMP_ID;
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_D_PRMProject", parm);
        }
        //项目申请财务总监审核
        public void UpdatePRMProjectCFOCheck(PRMProjectinfo pRMProjectinfo)
        {
            SqlParameter[] parm = new SqlParameter[4];
            parm[0] = new SqlParameter("@PRMP_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pRMProjectinfo.PRMP_ID;
            parm[1] = new SqlParameter("@PRMP_CFOCheckOpinion", SqlDbType.VarChar, 400);
            parm[1].Value = pRMProjectinfo.PRMP_CFOCheckOpinion;
            parm[2] = new SqlParameter("@PRMP_CFOCheckName", SqlDbType.VarChar,50);
            parm[2].Value = pRMProjectinfo.PRMP_CFOCheckName;
            parm[3] = new SqlParameter("@PRMP_CFOCheckResult", SqlDbType.VarChar, 20);
            parm[3].Value = pRMProjectinfo.PRMP_CFOCheckResult;
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                 CommandType.StoredProcedure, "Proc_U_PRMProjectCFOCheck", parm);
        }
        //负责部门项目验收审核
        public void UpdatePRMProjectResponDepart(PRMProjectinfo pRMProjectinfo)
        {
            SqlParameter[] parm = new SqlParameter[4];
            parm[0] = new SqlParameter("@PRMP_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pRMProjectinfo.PRMP_ID;
            parm[1] = new SqlParameter("@PRMP_ReDepartCheckOpinion", SqlDbType.VarChar, 400);
            parm[1].Value = pRMProjectinfo.PRMP_ReDepartCheckOpinion;
            parm[2] = new SqlParameter("@PRMP_ReDepartCheckMan", SqlDbType.VarChar, 50);
            parm[2].Value = pRMProjectinfo.PRMP_ReDepartCheckMan;
            parm[3] = new SqlParameter("@PRMP_ReDepartCheckResult", SqlDbType.VarChar, 20);
            parm[3].Value = pRMProjectinfo.PRMP_ReDepartCheckResult;
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                 CommandType.StoredProcedure, "Proc_U_PRMProjectResponDepart", parm);
        }
        //项目验收会签
        public void UpdatePRMProjectCountersign(PRMProjectinfo pRMProjectinfo)
        {
            SqlParameter[] parm = new SqlParameter[4];
            parm[0] = new SqlParameter("@PRMPC_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pRMProjectinfo.PRMPC_ID;
            parm[1] = new SqlParameter("@PRMPC_SignOpinion", SqlDbType.VarChar, 400);
            parm[1].Value = pRMProjectinfo.PRMPC_SignOpinion;
            parm[2] = new SqlParameter("@PRMPC_SignResult", SqlDbType.VarChar, 20);
            parm[2].Value = pRMProjectinfo.PRMPC_SignResult;
            parm[3] = new SqlParameter("@PRMPC_SignMan", SqlDbType.VarChar, 20);
            parm[3].Value = pRMProjectinfo.PRMPC_SignMan;
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                 CommandType.StoredProcedure, "Proc_U_PRMProjectCountersign", parm);
        }
        //生成验收部门
        public void InsertPRMProjectCountersign(PRMProjectinfo pRMProjectinfo)
        {
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@PRMP_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pRMProjectinfo.PRMP_ID;
            parm[1] = new SqlParameter("@PRMPC_SignPartment", SqlDbType.VarChar, 200);
            parm[1].Value = pRMProjectinfo.PRMPC_SignPartment;
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                 CommandType.StoredProcedure, "Proc_I_PRMProjectCountersign", parm);
        }

        //查找验收会签
        public DataSet SelectPRMProjectCountersign(string condition)
        {
            SqlParameter parm = new SqlParameter("@Condition",condition);

          return  SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_PRMProjectCountersign", parm);
        }
        //项目申请时，修改附件
        public void UpdatePRMProjectAccessory(PRMProjectinfo pRMProjectinfo)
        {
            SqlParameter[] parm = new SqlParameter[6];
            parm[0] = new SqlParameter("@PRMPA_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pRMProjectinfo.PRMPA_ID;
            parm[1] = new SqlParameter("@PRMPA_Accessory", SqlDbType.Char,2);
            parm[1].Value = pRMProjectinfo.PRMPA_Accessory;
            parm[2] = new SqlParameter("@PRMPA_AccNum ", SqlDbType.VarChar,100);
            parm[2].Value = pRMProjectinfo.PRMPA_AccNum;
            parm[3] = new SqlParameter("@PRMPA_AccName", SqlDbType.VarChar, 100);
            parm[3].Value = pRMProjectinfo.PRMPA_AccName;
            parm[4] = new SqlParameter("@PRMPA_AccPath", SqlDbType.VarChar, 100);
            parm[4].Value = pRMProjectinfo.PRMPA_AccPath;
            parm[5] = new SqlParameter("@PRMPA_AccState", SqlDbType.VarChar, 20);
            parm[5].Value = pRMProjectinfo.PRMPA_AccState;
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                 CommandType.StoredProcedure, "Proc_U_PRMProjectAccessory", parm);
        }
        //上传附件
        public void InsertPRMProjectAccessory(PRMProjectinfo pRMProjectinfo)
        {
            SqlParameter[] parm = new SqlParameter[6];
            parm[0] = new SqlParameter("@PRMP_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pRMProjectinfo.PRMP_ID;
            parm[1] = new SqlParameter("@PRMPA_Accessory", SqlDbType.Char, 2);
            parm[1].Value = pRMProjectinfo.PRMPA_Accessory;
            parm[2] = new SqlParameter("@PRMPA_AccNum ", SqlDbType.VarChar, 100);
            parm[2].Value = pRMProjectinfo.PRMPA_AccNum;
            parm[3] = new SqlParameter("@PRMPA_AccName", SqlDbType.VarChar, 100);
            parm[3].Value = pRMProjectinfo.PRMPA_AccName;
            parm[4] = new SqlParameter("@PRMPA_AccPath", SqlDbType.VarChar, 100);
            parm[4].Value = pRMProjectinfo.PRMPA_AccPath;
            parm[5] = new SqlParameter("@PRMPA_AccState", SqlDbType.VarChar, 20);
            parm[5].Value = pRMProjectinfo.PRMPA_AccState;
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                 CommandType.StoredProcedure, "Proc_I_PRMProjectAccessory", parm);
        }

        //查找附件
        public DataSet SelectPRMProjectAccessory(string condition)
        {
            SqlParameter parm = new SqlParameter("@Condition", condition);
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_PRMProjectAccessory", parm);
        }

        //删除附件
        public void DeletePRMProjectAccessory(PRMProjectinfo pRMProjectinfo)
        {
            SqlParameter[] parm = new SqlParameter[1];

            parm[0] = new SqlParameter("@PRMPA_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pRMProjectinfo.PRMPA_ID;
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_D_PRMProjectAccessory", parm);
        }
        //删除会签部门
        public void DeletePRMProjectCountersign(PRMProjectinfo pRMProjectinfo)
        {
            SqlParameter[] parm = new SqlParameter[1];

            parm[0] = new SqlParameter("@PRMPC_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = pRMProjectinfo.PRMPC_ID;
            SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_D_PRMProjectCountersign", parm);
        }
    }
}