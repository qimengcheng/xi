using System;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;


/// <summary>
///EquipTypeD 的摘要说明
/// </summary>
namespace EquipmentMangementAjax.SQLServer
{
    public class EquipTypeD : IEquipType
    {
        public EquipTypeD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        //添加设备类型
        public void Insert_EquipTypeTableInfo(EMEquipTypeTableInfo eMEquipTypeTableInfo)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@ETT_Type", SqlDbType.VarChar, 20);
            parm[0].Value = eMEquipTypeTableInfo.ETT_Type;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_I_EquipTypeTable", parm);
        }

        // 修改设备类型
        public void Update_EquipTypeTableInfo(EMEquipTypeTableInfo eMEquipTypeTableInfo)
        {
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@ETT_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = eMEquipTypeTableInfo.ETT_ID;
            parm[1] = new SqlParameter("@ETT_Type", SqlDbType.VarChar, 20);
            parm[1].Value = eMEquipTypeTableInfo.ETT_Type;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_U_EquipTypeTable", parm);
        }

        //假删除设备
        public int Delete_EquipTypeTableInfo(Guid ETT_ID)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@ETT_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = ETT_ID;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
               CommandType.StoredProcedure, "Proc_D_EquipTypeTable", parm);
        }

        //按设备类型名称，查找设备类型
        public DataSet Search_EquipTypeTableInfo(string condition)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            parm[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_EquipTypeTable", parm);
        }

        //显示所有设备类型
        //public DataSet Search_EquipTypeTable_DataInfo()
        //{
        //    return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
        //        "Proc_S_EquipTypeTable_Data");
        //}

        //设备类型下拉框
        //public DataSet Search_EquipTypeTable_DropdownInfo()
        //{
        //    return SqlHelper.GetDataSet(EquipmentMangementAjax.DBUtility.SqlHelper.ConnectionStringLocalTransaction,
        //        CommandType.StoredProcedure, "Proc_S_EquipTypeTable_Dropdown");
        //}
    }
}