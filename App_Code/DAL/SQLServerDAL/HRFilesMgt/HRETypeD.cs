using System;
using EquipmentMangementAjax.DBUtility;
using System.Data.SqlClient;
using System.Data;

/// <summary>
///HRETypeD 的摘要说明
/// </summary>
namespace EquipmentMangementAjax.SQLServer
{
    public class HRETypeD:IHREType
    {
        public HRETypeD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        public int Insert_HREmployeeType(HRETypeInfo hr)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_HREmployeeType",
                new SqlParameter("@HRET_ID", hr.HRET_ID), new SqlParameter("@HRET_EmpType", hr.HRET_EmpType),
                new SqlParameter("@HRET_IsDeleted", hr.HRET_IsDeleted));
        }

        public int Update_HREmployeeType(HRETypeInfo hr)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_HREmployeeType",
                new SqlParameter("@HRET_ID", hr.HRET_ID), new SqlParameter("@HRET_EmpType", hr.HRET_EmpType));

        }
        public void Delete_HREmployeeType(Guid ID)
        {
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_HREmployeeType",
                new SqlParameter("@HRET_ID", ID));
        }
        public DataSet Search_HREmployeeType(string HRET_EmpType)
        {
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_HREmployeeType", new SqlParameter("@HRET_EmpType", HRET_EmpType));
        }
    }
}