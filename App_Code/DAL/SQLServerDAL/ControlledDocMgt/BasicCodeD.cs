using System;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
///BasicCodeD 的摘要说明
/// </summary>
namespace EquipmentMangementAjax.SQLServer
{
    public class BasicCodeD : IBasicCode
    {
        public BasicCodeD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        //增加/修改部门的代码
        public void Insert_Update_BDOrganization_depcode(string BDOS_Name, string BDOS_DepCode, string BDOS_No)
        {
            SqlParameter[] parm = new SqlParameter[3];
            parm[0] = new SqlParameter("@BDOS_Name", SqlDbType.VarChar, 100);
            parm[0].Value = BDOS_Name;
            parm[1] = new SqlParameter("@BDOS_DepCode", SqlDbType.VarChar, 20);
            parm[1].Value = BDOS_DepCode;
            parm[2] = new SqlParameter("@BDOS_No", SqlDbType.VarChar, 10);
            parm[2].Value = BDOS_No;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_U_BDOrganization_depcode", parm);
        }
        //删除部门的代码
        public int Delete_BDOrganization_depcode(string BDOS_Code)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@BDOS_Code", SqlDbType.VarChar, 60);
            parm[0].Value = BDOS_Code;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_BDOrganization_depcode", parm);
        }
        //查找部门代码
        public DataSet Search_BDOrganization_depcode(string condition)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            parm[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_BDOrganization_depcode", parm);
        }
        //部门下拉框绑定
        public DataSet Search_BDOrganization_BDdepcode()
        {
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_BDOrganization_BDdepcode");
        }
        //增加岗位的代码
        public void Insert_CDDepDistributeCodeT(string CDDDCT_Dep, string CDDDCT_Code)
        {
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@CDDDCT_Dep", SqlDbType.VarChar, 20);
            parm[0].Value = CDDDCT_Dep;
            parm[1] = new SqlParameter("@CDDDCT_Code", SqlDbType.VarChar,20);
            parm[1].Value = CDDDCT_Code;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_CDDepDistributeCodeT", parm);
        }
        //修改岗位的代码
        public void Update_CDDepDistributeCodeT(Guid CDDDCT_ID, string CDDDCT_Dep, string CDDDCT_Code)
        {
            SqlParameter[] parm = new SqlParameter[3];
            parm[0] = new SqlParameter("@CDDDCT_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = CDDDCT_ID;
            parm[1] = new SqlParameter("@CDDDCT_Dep", SqlDbType.VarChar, 20);
            parm[1].Value = CDDDCT_Dep;
            parm[2] = new SqlParameter("@CDDDCT_Code", SqlDbType.VarChar, 20);
            parm[2].Value = CDDDCT_Code;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_CDDepDistributeCodeT", parm);
        }
        //删除岗位的代码
        public int Delete_CDDepDistributeCodeT(Guid CDDDCT_ID)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@CDDDCT_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = CDDDCT_ID;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_CDDepDistributeCodeT", parm);
        }
        //查找岗位代码
        public DataSet Search_CDDepDistributeCodeT(string condition)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            parm[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_CDDepDistributeCodeT", parm);
        }
        //增加第三层次文件类别的代码
        public void Insert_CDThirdLevelCode(string CDTLC_DocType, string CDTLC_Code)
        {
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@CDTLC_DocType", SqlDbType.VarChar, 40);
            parm[0].Value = CDTLC_DocType;
            parm[1] = new SqlParameter("@CDTLC_Code", SqlDbType.VarChar, 20);
            parm[1].Value = CDTLC_Code;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_CDThirdLevelCode", parm);
        }
        //修改第三层次文件类别的代码
        public void Update_CDThirdLevelCode(Guid CDTLC_ID, string CDTLC_DocType, string CDTLC_Code)
        {
            SqlParameter[] parm = new SqlParameter[3];
            parm[0] = new SqlParameter("@CDTLC_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = CDTLC_ID;
            parm[1] = new SqlParameter("@CDTLC_DocType", SqlDbType.VarChar, 40);
            parm[1].Value = CDTLC_DocType;
            parm[2] = new SqlParameter("@CDTLC_Code", SqlDbType.VarChar, 20);
            parm[2].Value = CDTLC_Code;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_CDThirdLevelCode", parm);
        }
        //删除第三层次文件类别的代码
        public int Delete_CDThirdLevelCode(Guid CDTLC_ID)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@CDTLC_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = CDTLC_ID;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_CDThirdLevelCode", parm);
        }
        //查找第三层次文件类别代码
        public DataSet Search_CDThirdLevelCode(string condition)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            parm[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_CDThirdLevelCode", parm);
        }
    }
}