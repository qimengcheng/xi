using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections;
using EquipmentMangementAjax.DBUtility;

/// <summary>
/// RightTimeSMD 的摘要说明
/// </summary>
public class RightTimeSMD
{
    public DataSet SelectRightTimeSM(string condition)
    {
        SqlParameter para = new SqlParameter("@Condition", condition);
        return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_RightTimeSM", para);
    }

    public DataSet SelectRightTimeMaterial(string PT_Name, int touchan)
    {
        SqlParameter[] parm = new SqlParameter[2];

        parm[0] = new SqlParameter("@name", SqlDbType.VarChar,60);
        parm[0].Value = PT_Name;
        parm[1] = new SqlParameter("@mount", SqlDbType.Int);
        parm[1].Value = touchan;
        return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
                   CommandType.StoredProcedure, "Proc_S_RightTimeMaterial", parm);
    }
}