using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;
/// <summary>
/// WIP_PBCD 的摘要说明
/// </summary>
public class WIP_PBCD
{
    public DataSet SelectWIP_PBC(string WO_ProType)
    {
        SqlParameter[] parm = new SqlParameter[1];

        parm[0] = new SqlParameter("@WO_ProType", SqlDbType.VarChar, 60);
        parm[0].Value = WO_ProType;
       
        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
                   CommandType.StoredProcedure, "Proc_S_WIP_PBC", parm);
    }
}