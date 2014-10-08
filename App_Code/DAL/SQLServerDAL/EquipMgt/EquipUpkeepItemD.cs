using System;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
///EquipUpkeepItemD 的摘要说明
/// </summary>
namespace EquipmentMangementAjax.SQLServer
{
    public class EquipUpkeepItemD : IEquipUpkeepItem
    {
        public EquipUpkeepItemD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        public void Insert_EquipUpkeepItemInfo(Guid EN_ID, string EUI_Items, decimal EUI_Period)
        {
            SqlParameter[] parm = new SqlParameter[3];
            parm[0] = new SqlParameter("@EN_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = EN_ID;
            parm[1] = new SqlParameter("@EUI_Items", SqlDbType.VarChar, 100);
            parm[1].Value = EUI_Items;
            parm[2] = new SqlParameter("@EUI_Period", SqlDbType.Decimal);
            parm[2].Value = EUI_Period;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_EquipUpkeepItem", parm);
        }
        public void Update_EquipUpkeepItemInfo(Guid EUI_ID, Guid EN_ID, string EUI_Items, decimal EUI_Period)
        {
           SqlParameter[] parm = new SqlParameter[4];
            parm[0] = new SqlParameter("@EUI_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = EUI_ID;
            parm[1] = new SqlParameter("@EN_ID", SqlDbType.UniqueIdentifier);
            parm[1].Value = EN_ID;
            parm[2] = new SqlParameter("@EUI_Items", SqlDbType.VarChar, 100);
            parm[2].Value = EUI_Items;
            parm[3] = new SqlParameter("@EUI_Period", SqlDbType.Decimal);
            parm[3].Value = EUI_Period;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_EquipUpkeepItem", parm); 
        }
        public int Delete_EquipUpkeepItemInfo(Guid EUI_ID)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@EUI_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = EUI_ID;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,CommandType.StoredProcedure, "Proc_D_EquipUpkeepItem", parm);
        }
        public DataSet Search_EquipUpkeepItemInfo(string condition)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            parm[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_EquipUpkeepItem", parm);
        }
    }
}