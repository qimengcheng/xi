using System;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
///CapacityBasicD 的摘要说明
/// </summary>
namespace EquipmentMangementAjax.SQLServer
{
    public class CapacityBasicD : ICapacityBasic
    {
        public CapacityBasicD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        public DataSet S_CSName(string condition)//检索产能核定系列名称表
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 2000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_CSName", para);

        }

        public void I_CSName(string cSN_Name)//新增产能核定系列名称
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@CSN_Name", SqlDbType.VarChar, 60);
            para[0].Value = cSN_Name;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_CSName", para);
        }

        public void D_CSName(Guid cSN_ID)//删除产能核定系列名称
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@CSN_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = cSN_ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_CSName", para);
        }

        public void U_CSName(Guid cSN_ID, string cSN_Name)//编辑产能核定系列名称
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@CSN_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = cSN_ID;
            para[1] = new SqlParameter("@CSN_Name", SqlDbType.VarChar, 60);
            para[1].Value = cSN_Name;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_CSName", para);
        }


        public DataSet S_CSName_ProType(string cSN_ID, string condition)//检索产能核定系列所属产品型号
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@CSN_ID", SqlDbType.VarChar, 100);
            para[0].Value = cSN_ID;
            para[1] = new SqlParameter("@condition", SqlDbType.VarChar, 2000);
            para[1].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_CSName_ProType", para);

        }


        public void I_CSName_ProType(Guid cSN_ID, Guid pT_ID)//添加产品型号至产能核定系列
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@CSN_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = cSN_ID;
            para[1] = new SqlParameter("@PT_ID", SqlDbType.UniqueIdentifier);
            para[1].Value = pT_ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_CSName_ProType", para);
        }

        public void D_CSName_ProType(Guid pT_ID)//删除产能核定系列所属产品型号
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@PT_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = pT_ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_CSName_ProType", para);
        }

        public DataSet S_ProTypeForCSName(string condition)//检索产能核定系列所属待选产品型号
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 2000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_ProTypeForCSName", para);

        }
        public DataSet S_CSeries(string cSN_ID, string condition)//检索产能核定系列基础信息
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@CSN_ID", SqlDbType.VarChar, 100);
            para[0].Value = cSN_ID;
            para[1] = new SqlParameter("@condition", SqlDbType.VarChar, 2000);
            para[1].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_CSeries", para);

        }

        public void I_CSeries(Guid cSN_ID, Guid pBC_ID, int cS_LaborC, int cS_MacC, string CS_Formulate)//新增产能核定系列基础信息
        {
            SqlParameter[] para = new SqlParameter[5];
            para[0] = new SqlParameter("@CSN_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = cSN_ID;
            para[1] = new SqlParameter("@PBC_ID", SqlDbType.UniqueIdentifier);
            para[1].Value = pBC_ID;
            para[2] = new SqlParameter("@CS_LaborC", SqlDbType.Int);
            para[2].Value = cS_LaborC;
            para[3] = new SqlParameter("@CS_MacC", SqlDbType.Int);
            para[3].Value = cS_MacC;
            para[4] = new SqlParameter("@CS_Formulate", SqlDbType.VarChar,400);
            para[4].Value = CS_Formulate;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_CSeries", para);
        }

        public void D_CSeries(Guid cS_ID)//删除产能核定系列基础信息
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@CS_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = cS_ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_CSeries", para);
        }

        public void U_CSeries(Guid cS_ID, int cS_LaborC, int cS_MacC, string CS_Formulate)//编辑产能核定系列基础信息
        {
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@CS_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = cS_ID;
            //para[1] = new SqlParameter("@PBC_ID", SqlDbType.UniqueIdentifier);
            //para[1].Value = pBC_ID;
            para[1] = new SqlParameter("@CS_LaborC", SqlDbType.Int);
            para[1].Value = cS_LaborC;
            para[2] = new SqlParameter("@CS_MacC", SqlDbType.Int);
            para[2].Value = cS_MacC;
            para[3] = new SqlParameter("@CS_Formulate", SqlDbType.VarChar, 400);
            para[3].Value = CS_Formulate;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_CSeries", para);
        }


        public DataSet S_PBCraft_Capacity(Guid cSN_ID)//检索产能核定系列基础信息
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@CSN_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = cSN_ID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_PBCraft_Capacity", para);

        }

        public DataSet S_CapacityInfo(string condition)//检索产能核定信息
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 2000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_CapacityInfo", para);
        }

        public void I_CapacityInfo(string cI_P, string cI_Note)//新增产能核定信息
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@CI_P", SqlDbType.VarChar, 20);
            para[0].Value = cI_P;
            para[1] = new SqlParameter("@CI_Note", SqlDbType.VarChar, 100);
            para[1].Value = cI_Note;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_CapacityInfo", para);
        }

        public void U_CapacityInfo(Guid cI_ID, string cI_P, string cI_Note)//编辑产能核定信息
        {
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("@CI_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = cI_ID;
            para[1] = new SqlParameter("@CI_P", SqlDbType.VarChar, 20);
            para[1].Value = cI_P;
            para[2] = new SqlParameter("@CI_Note", SqlDbType.VarChar, 100);
            para[2].Value = cI_Note;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_CapacityInfo", para);
        }
        public void D_CapacityInfo(Guid cI_ID)//删除产能核定信息
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@CI_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = cI_ID;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_CapacityInfo", para);
        }
        public DataSet S_CapacityDetailInfo(string condition, string pBC_ID, string cI_ID)//检索产能核定详细信息
        {
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("@condition", SqlDbType.VarChar, 2000);
            para[0].Value = condition;
            para[1] = new SqlParameter("@PBC_ID", SqlDbType.VarChar, 100);
            para[1].Value = pBC_ID;
            para[2] = new SqlParameter("@CI_ID", SqlDbType.VarChar, 100);
            para[2].Value = cI_ID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_CapacityDetailInfo", para);
        }
        public DataSet S_CSeries_PBCraftInfo()//检索产能核定主要工序
        {
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_CSeries_PBCraftInfo", null);
        }


        public void I_CapacityDetailInfo(Guid cI_ID, Guid cS_ID, int cDI_MachineNum, decimal cDI_MachineHours, int cDI_PeopleNum, decimal cDI_PeopleHours)//新增产能核定详细信息
        {
            SqlParameter[] para = new SqlParameter[6];
            para[0] = new SqlParameter("@CI_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = cI_ID;
            para[1] = new SqlParameter("@CS_ID", SqlDbType.UniqueIdentifier);
            para[1].Value = cS_ID;
            para[2] = new SqlParameter("@CDI_MachineNum", SqlDbType.Int);
            para[2].Value = cDI_MachineNum;
            para[3] = new SqlParameter("@CDI_MachineHours", SqlDbType.Decimal);
            para[3].Value = cDI_MachineHours;
            para[4] = new SqlParameter("@CDI_PeopleNum", SqlDbType.Int);
            para[4].Value = cDI_PeopleNum;
            para[5] = new SqlParameter("@CDI_PeopleHours", SqlDbType.Decimal);
            para[5].Value = cDI_PeopleHours;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_CapacityDetailInfo", para);
        }

        public void U_CapacityDetailInfo(Guid cDI_ID, int cDI_MachineNum, decimal cDI_MachineHours, int cDI_PeopleNum, decimal cDI_PeopleHours)//编辑产能核定详细信息
        {
            SqlParameter[] para = new SqlParameter[5];
            para[0] = new SqlParameter("@CDI_ID", SqlDbType.UniqueIdentifier);
            para[0].Value = cDI_ID;
            para[1] = new SqlParameter("@CDI_MachineNum", SqlDbType.Int);
            para[1].Value = cDI_MachineNum;
            para[2] = new SqlParameter("@CDI_MachineHours", SqlDbType.Decimal);
            para[2].Value = cDI_MachineHours;
            para[3] = new SqlParameter("@CDI_PeopleNum", SqlDbType.Int);
            para[3].Value = cDI_PeopleNum;
            para[4] = new SqlParameter("@CDI_PeopleHours", SqlDbType.Decimal);
            para[4].Value = cDI_PeopleHours;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_CapacityDetailInfo", para);
        }


        public DataSet S_CapacityDetailInfo_ResultCheck(string cI_ID)//检索产能核定最终结果
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@CI_ID", SqlDbType.VarChar,100);
            para[0].Value = cI_ID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_CapacityDetailInfo_ResultCheck", para);
        }
    }
}