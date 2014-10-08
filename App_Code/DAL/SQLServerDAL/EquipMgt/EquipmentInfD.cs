using System;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
///EquipmentInfD 的摘要说明
/// </summary>
namespace EquipmentMangementAjax.SQLServer
{
    public class EquipmentInfD : IEquipmentInf
    {
	    public EquipmentInfD()
	    {
		    //
		    //TODO: 在此处添加构造函数逻辑
		    //
	    }

        //增加设备台账时，首先查询并选择已有的设备名称和型号
        public DataSet Search_InsertEquipmentInfInfo(string EN_EquipName, string EMT_Type)
        {
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@EN_EquipName", SqlDbType.VarChar, 40);
            parm[0].Value = EN_EquipName;
            parm[1] = new SqlParameter("@EMT_Type", SqlDbType.VarChar, 20);
            parm[1].Value = EMT_Type;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_InsertEquipmentInf", parm);
        }

        //在已选择的设备名称和型号下,增加设备台账
        public void Insert_EquipmentInfInfo(Guid ETT_ID,Guid EMT_ID,string EI_No,string EI_Location,
                                            string EI_Providor,string EI_IsToCare,DateTime EI_AcceptDate)
        {
            SqlParameter[] parm = new SqlParameter[7];
            parm[0] = new SqlParameter("@ETT_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = ETT_ID;
            parm[1] = new SqlParameter("@EMT_ID", SqlDbType.UniqueIdentifier);
            parm[1].Value = EMT_ID;
            parm[2] = new SqlParameter("@EI_No", SqlDbType.VarChar, 20);
            parm[2].Value = EI_No;
            parm[3] = new SqlParameter("@EI_Location", SqlDbType.VarChar, 40);
            parm[3].Value = EI_Location;
            parm[4] = new SqlParameter("@EI_Providor", SqlDbType.VarChar, 40);
            parm[4].Value = EI_Providor;
            parm[5] = new SqlParameter("@EI_IsToCare", SqlDbType.Char, 2);
            parm[5].Value = EI_IsToCare;
            parm[6] = new SqlParameter("@EI_AcceptDate", SqlDbType.Date);
            parm[6].Value = EI_AcceptDate;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_I_EquipmentInf", parm);
        }

        // 修改设备类型
        public void Update_EquipmentInfInfo(Guid ETT_ID,Guid EI_ID, string EI_No, string EI_Location, string EI_Providor, 
                                            string EI_IsToCare, DateTime EI_AcceptDate, string EI_State)
        {
            SqlParameter[] parm = new SqlParameter[8];
            parm[0] = new SqlParameter("@ETT_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = ETT_ID;
            parm[1] = new SqlParameter("@EI_ID", SqlDbType.UniqueIdentifier);
            parm[1].Value = EI_ID;
            parm[2] = new SqlParameter("@EI_No", SqlDbType.VarChar, 20);
            parm[2].Value = EI_No;
            parm[3] = new SqlParameter("@EI_Location", SqlDbType.VarChar, 40);
            parm[3].Value = EI_Location;
            parm[4] = new SqlParameter("@EI_Providor", SqlDbType.VarChar, 40);
            parm[4].Value = EI_Providor;
            parm[5] = new SqlParameter("@EI_IsToCare", SqlDbType.Char, 2);
            parm[5].Value = EI_IsToCare;
            parm[6] = new SqlParameter("@EI_AcceptDate", SqlDbType.Date);
            parm[6].Value = EI_AcceptDate;
            parm[7] = new SqlParameter("@EI_State", SqlDbType.VarChar, 20);
            parm[7].Value = EI_State;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_U_EquipmentInf", parm);
        }

        //假删除设备
        public int Delete_Proc_D_EquipmentInfInfo(Guid EI_ID)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@EI_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = EI_ID;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
               CommandType.StoredProcedure, "Proc_D_EquipmentInf", parm);
        }

        //按设备类型名称，查找设备类型
        public DataSet Search_EquipmentInfInfo(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 1000);
            para[0].Value = condition;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_EquipmentInf", para);
        }
    }
}