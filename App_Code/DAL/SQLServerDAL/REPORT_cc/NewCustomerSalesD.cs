using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
/// NewCustomerSales 的摘要说明
/// </summary>
public class NewCustomerSalesD
{
    public DataSet SelectNewCustomerSales(string Condition, string year)
    {
        SqlParameter[] parm = new SqlParameter[2];

        parm[0] = new SqlParameter("@Condition", SqlDbType.NVarChar,4000);
        parm[0].Value =Condition;
        parm[1] = new SqlParameter("@year", SqlDbType.VarChar,4);
        parm[1].Value = year;
       
    return  SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
                 CommandType.StoredProcedure, "Proc_S_NewCustomerSales", parm);
    }
}