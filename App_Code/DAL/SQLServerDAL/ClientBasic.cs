using System;
using System.Data;
using System.Data.SqlClient;
//using System.Collections.Generic;
using EquipmentMangementAjax.DBUtility;

namespace EquipmentMangementAjax.SQLServer
{

    /// <summary>
    ///ClientBasic 的摘要说明
    /// </summary>
    public class ClientBasic:IClientBasic
    {
        public ClientBasic()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        public DataSet SList_CRMRegionBasicInfo()//检索所有区域信息
        {
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_CRMRegionBasicInfo", null);
        }

        public DataSet SList_CRMCustomerSortBasicData()//检索所有客户类别
        {
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_CRMCustomerSortBasicData", null);
        }
        public void I_CRMRegionBasicInfo(string name, string detail)//新增区域信息
        {
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@CRMRBI_Name", SqlDbType.VarChar, 100);
            parm[0].Value = name;
            parm[1] = new SqlParameter("@CRMRBI_Explain", SqlDbType.VarChar, 400);
            parm[1].Value = detail;

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_CRMRegionBasicInfo", parm);
        }
        public void U_CRMRegionBasicInfo(Guid id, string name, string detail)//修改区域信息
        {
            SqlParameter[] parm = new SqlParameter[3];
            parm[0] = new SqlParameter("@CRMRBI_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = id;
            parm[1] = new SqlParameter("@CRMRBI_Name", SqlDbType.VarChar, 100);
            parm[1].Value = name;
            parm[2] = new SqlParameter("@CRMRBI_Explain", SqlDbType.VarChar, 400);
            parm[2].Value = detail;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_CRMRegionBasicInfo", parm);
        }
        public void D_CRMRegionBasicInfo(Guid id)//删除区域信息
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@CRMRBI_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = id;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_CRMRegionBasicInfo", parm);

        }
        public void I_CRMCustomerSortBasicData(string name,string detail)//新增客户类别
        {
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@CRMCSBD_Name", SqlDbType.VarChar, 100);
            parm[0].Value=name;
            parm[1]=new SqlParameter("@CRMCSBD_Explain",SqlDbType.VarChar,400);
            parm[1].Value = detail;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_CRMCustomerSortBasicData", parm);
        }
        public void U_CRMCustomerSortBasicData(Guid id, string name, string detail)//修改客户类别
        {
            SqlParameter[] parm = new SqlParameter[3];
            parm[0] = new SqlParameter("@CRMCSBD_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = id;
            parm[1] = new SqlParameter("@CRMCSBD_Name", SqlDbType.VarChar, 100);
            parm[1].Value = name;
            parm[2] = new SqlParameter("@CRMCSBD_Explain", SqlDbType.VarChar, 400);
            parm[2].Value = detail;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_CRMCustomerSortBasicData", parm);

        }
        public void D_CRMCustomerSortBasicData(Guid id)//删除客户类别
        {

            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@CRMCSBD_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = id;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_CRMCustomerSortBasicData", parm);
        }

        public DataSet S_CRMRBI_CRMCIF(Guid id)//查询区域对应人员
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@CRMRBI_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = id;
            
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_CRMRBI_CRMCIF", parm);
        }
        public DataSet S_CRMRBISraech(string name)//查询特定区域
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@CRMRBI_Name", SqlDbType.VarChar, 100);
            parm[0].Value = name;

            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_CRMRBI_CRMRBISraech", parm);
        }
        public DataSet S_CRMCusSort(string condition)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            parm[0].Value = condition;

            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_CRMCustomSort", parm);
        }
        public void I_CRMCusSort(string name,string note)//xinjian客户领域
        {

            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@CRMCustomSortName", SqlDbType.VarChar,40);
            parm[0].Value = name;
            parm[1] = new SqlParameter("@CRMCustomSortNote", SqlDbType.VarChar,400);
            parm[1].Value = note;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_CRMCustomSort", parm);
        }
        public void U_CRMCusSort(Guid id,string name,string note)//bianji客户领域
        {

            SqlParameter[] parm = new SqlParameter[3];
            parm[0] = new SqlParameter("@CRMCustomSortID", SqlDbType.UniqueIdentifier);
            parm[0].Value = id;
            parm[1] = new SqlParameter("@CRMCustomSortName", SqlDbType.VarChar, 40);
            parm[1].Value = name;
            parm[2] = new SqlParameter("@CRMCustomSortNote", SqlDbType.VarChar, 400);
            parm[2].Value = note;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_CRMCustomSort", parm);
        }
        public void D_CRMCusSort(Guid id)//shanchu客户领域
        {

            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@CRMCustomSortID", SqlDbType.UniqueIdentifier);
            parm[0].Value = id;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_CRMCustomSort", parm);
        }
        public DataSet S_CRMCusSort_Custome(Guid id)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@CRMCustomSortID", SqlDbType.UniqueIdentifier);
            parm[0].Value = id;

            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_CRMCustomSort_CustomInfo", parm);
        }
    }
}