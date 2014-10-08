using System;
using EquipmentMangementAjax.DBUtility;
using System.Data.SqlClient;
using System.Data;

/// <summary>
///NewEmpInfoAddD 的摘要说明
/// </summary>

namespace EquipmentMangementAjax.SQLServer
{
    public class NewEmpResulsD : INewEmpResulsD 
    {


        public DataSet Search_HRDDetail_NETraEachItemResultDetail(string Condition)
        {
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_HRDDetail_NETraEachItemResultDetail", new SqlParameter("@Condition", Condition));
        }//新员工培训结果查看，检索新员工培训结果列表(检索按钮)

        public DataSet Search_Others_NETraEachItemResultDetai(Guid NETPCT_ID)
        {
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_Others_NETraEachItemResultDetail", new SqlParameter("@NETPCT_ID", NETPCT_ID));
        }//新员工培训结果查看，检索新员工培训详情列表（linkbutton）
    }
}