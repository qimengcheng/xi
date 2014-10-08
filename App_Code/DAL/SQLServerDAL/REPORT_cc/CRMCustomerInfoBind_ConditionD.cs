using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
/// CRMCustomerInfoBind_ConditionD 的摘要说明
/// </summary>
public class CRMCustomerInfoBind_ConditionD
{
    public DataSet SelectCRMCustomerInfoBind_Condition(string condition)
    {
        SqlParameter para = new SqlParameter("@Condition", condition);
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_CRMCustomerInfoBind_Condition", para);
    }
    public SqlDataReader SelectCRMCustomerContact(Guid CRMCIF_ID)
    {
        SqlParameter para = new SqlParameter("@CRMCIF_ID", CRMCIF_ID);
       
       SqlDataReader dr=SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_CRMCustomerContact", para);
       return dr;
    }
}