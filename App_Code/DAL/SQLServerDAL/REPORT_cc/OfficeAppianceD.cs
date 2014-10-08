using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using EquipmentMangementAjax.DBUtility;

/// <summary>
/// OfficeAppiance 的摘要说明
/// </summary>
public class OfficeAppianceD
{
	public DataSet SelectOfficeAppliance(string condition)
	{
        SqlParameter para = new SqlParameter("@Condition", condition);
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_PMPurchaseOrder_Peraonal", para);
	}
    public DataSet SelectOfficeAppliance_Sum(string condition)
    {
        SqlParameter para = new SqlParameter("@Condition", condition);
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_PMPurchaseOrder_Peraonal_Sum", para);
    }
    public DataSet SelectIMMaterialType()
    {
        //SqlParameter para = new SqlParameter();
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_IMMaterialType");
    }
    public void DeletePMPurchaseApplyMain_Caigou(Guid PMPAD_ID)
    {
        SqlParameter para = new SqlParameter("@PMPAD_ID",SqlDbType.UniqueIdentifier);
        para.Value = PMPAD_ID;
        SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_PMPurchaseApplyMain_Caigou", para);
    }

}