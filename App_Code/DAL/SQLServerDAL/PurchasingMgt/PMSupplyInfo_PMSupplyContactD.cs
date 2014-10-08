using System;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
///PMSupplyInfo_PMSupplyContactD 的摘要说明
/// </summary>
namespace EquipmentMangementAjax.SQLServer
{
    public class PMSupplyInfo_PMSupplyContactD : IPMSupplyInfo_PMSupplyContact
    {
        public PMSupplyInfo_PMSupplyContactD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        public void InsertPMSupplyInfo(string PMSI_SupplyName, string PMSI_SupplySort, string PMSI_SupplyRemark,int PMSI_PaymentTime)
        {
            SqlParameter[] parm = new SqlParameter[4];

            parm[0] = new SqlParameter("@PMSI_SupplyName", SqlDbType.VarChar, 100);
            parm[0].Value = PMSI_SupplyName;
            parm[1] = new SqlParameter("@PMSI_SupplySort", SqlDbType.VarChar, 20);
            parm[1].Value = PMSI_SupplySort;
            parm[2] = new SqlParameter("@PMSI_Remark", SqlDbType.VarChar, 400);
            parm[2].Value = PMSI_SupplyRemark;
            parm[3] = new SqlParameter("@PMSI_PaymentTime", SqlDbType.SmallInt);
            parm[3].Value = PMSI_PaymentTime;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
               CommandType.StoredProcedure, "Proc_I_PMSupplyInfo", parm);
        }
        //
        public void InsertPMSupplyContact(Guid PMSI_ID, string PMSC_Name, string PMSC_Position, string PMSC_TelephoneNum, string PMSC_PhoneNum, string PMSC_FaxNum, string PMSC_Email, string PMSC_QQ)
        {
            SqlParameter[] parm = new SqlParameter[8];
            parm[0] = new SqlParameter("@PMSI_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = PMSI_ID;
            parm[1] = new SqlParameter("@PMSC_Name", SqlDbType.VarChar, 50);
            parm[1].Value = PMSC_Name;
            parm[2] = new SqlParameter("@PMSC_Position", SqlDbType.VarChar, 50);
            parm[2].Value = PMSC_Position;
            parm[3] = new SqlParameter("@PMSC_TelephoneNum", SqlDbType.VarChar, 50);
            parm[3].Value = PMSC_TelephoneNum;
            parm[4] = new SqlParameter("@PMSC_PhoneNum", SqlDbType.VarChar, 20);
            parm[4].Value = PMSC_PhoneNum;
            parm[5] = new SqlParameter("@PMSC_FaxNum", SqlDbType.VarChar, 50);
            parm[5].Value = PMSC_FaxNum;
            parm[6] = new SqlParameter("@PMSC_Email", SqlDbType.VarChar, 100);
            parm[6].Value = PMSC_Email;
            parm[7] = new SqlParameter("@PMSC_QQ", SqlDbType.VarChar, 20);
            parm[7].Value = PMSC_QQ;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
               CommandType.StoredProcedure, "Proc_I_PMSupplyContact", parm);
        }
        public void UpdatePMSupplyInfo(Guid PMSI_ID, string PMSI_SupplyName, string PMSI_SupplySort, string PMSI_SupplyRemark, int PMSI_PaymentTime)
        {
            SqlParameter[] parm = new SqlParameter[5];
            parm[0] = new SqlParameter("@PMSI_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = PMSI_ID;
            parm[1] = new SqlParameter("@PMSI_SupplyName", SqlDbType.VarChar, 100);
            parm[1].Value = PMSI_SupplyName;
            parm[2] = new SqlParameter("@PMSI_SupplySort", SqlDbType.VarChar, 20);
            parm[2].Value = PMSI_SupplySort;
            parm[3] = new SqlParameter("@PMSI_Remark", SqlDbType.VarChar, 400);
            parm[3].Value = PMSI_SupplyRemark;
            parm[4] = new SqlParameter("@PMSI_PaymentTime", SqlDbType.SmallInt);
            parm[4].Value = PMSI_PaymentTime;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
               CommandType.StoredProcedure, "Proc_U_PMSupplyInfo", parm);
        }
        public void UpdatePMSupplyContact(Guid PMSC_ID, string PMSC_Name, string PMSC_Position, string PMSC_TelephoneNum, string PMSC_PhoneNum, string PMSC_FaxNum, string PMSC_Email, string PMSC_QQ)
        {
            SqlParameter[] parm = new SqlParameter[8];
            parm[0] = new SqlParameter("@PMSC_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = PMSC_ID;
            parm[1] = new SqlParameter("@PMSC_Name", SqlDbType.VarChar, 50);
            parm[1].Value = PMSC_Name;
            parm[2] = new SqlParameter("@PMSC_Position", SqlDbType.VarChar, 50);
            parm[2].Value = PMSC_Position;
            parm[3] = new SqlParameter("@PMSC_TelephoneNum", SqlDbType.VarChar, 50);
            parm[3].Value = PMSC_TelephoneNum;
            parm[4] = new SqlParameter("@PMSC_PhoneNum", SqlDbType.VarChar, 20);
            parm[4].Value = PMSC_PhoneNum;
            parm[5] = new SqlParameter("@PMSC_FaxNum", SqlDbType.VarChar, 50);
            parm[5].Value = PMSC_FaxNum;
            parm[6] = new SqlParameter("@PMSC_Email", SqlDbType.VarChar, 100);
            parm[6].Value = PMSC_Email;
            parm[7] = new SqlParameter("@PMSC_QQ", SqlDbType.VarChar, 20);
            parm[7].Value = PMSC_QQ;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
               CommandType.StoredProcedure, "Proc_U_PMSupplyContact", parm);
        }
        public DataSet SelectPMSupplyInfo(string condition)
        {
            SqlParameter parm = new SqlParameter("@Condition", condition);
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_PMSupplyInfo", parm);
        }
        public DataSet SelectPMSupply_One(Guid PMSI_ID)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@PMSI_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = PMSI_ID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_PMSupply_One", parm);
        }
        public DataSet SelectPMSupplyContact(Guid PMSI_ID)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@PMSI_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = PMSI_ID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_PMSupplyContact", parm);
        }
        public DataSet SelectPMSupply_Same(string PMSI_SupplyName)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@PMSI_SupplyName", SqlDbType.VarChar, 100);
            parm[0].Value = PMSI_SupplyName;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_PMSupply_Same", parm);
        }
        public DataSet SelectPMSupplyContact_Same(string PMSC_Name)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@PMSC_Name", SqlDbType.VarChar, 50);
            parm[0].Value = PMSC_Name;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_PMSupplyContact_Same", parm);
        }
        public DataSet SelectPMSupplyContact_One(Guid PMSC_ID)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@PMSC_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = PMSC_ID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_PMSupplyContact_One", parm);
        }
        public int DeletePMSupplyInfo(Guid _PMSI_ID)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@PMSI_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = _PMSI_ID;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                  CommandType.StoredProcedure, "Proc_D_PMSupplyInfo", parm);
        }
        public int DeletePMSupplyContact(Guid _PMSC_ID)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@PMSC_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = _PMSC_ID;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
      CommandType.StoredProcedure, "Proc_D_PMSupplyContact", parm);
        }

    }
}