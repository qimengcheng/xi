using System;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
///记录计量器具管理的底层函数
/// </summary>
namespace EquipmentMangementAjax.SQLServer
{
    public class MeasApplianceD:IMeasAppliance
    {
        public MeasApplianceD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        public DataSet Select_MeasApplianceMan(string Condition)
        {//查询计量器具信息
            
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
               CommandType.StoredProcedure, "Proc_S_MeasApplianceMan", new SqlParameter("@Condition", Condition));
        }
        public int Insert_MeasApplianceMan(MeasApplianceMan MAM_Equipinfo)
        {//添加计量器具信息
            SqlParameter[] parm = new SqlParameter[12];
            parm[0] = new SqlParameter("@MAM_EquipName", SqlDbType.VarChar,50);
            parm[0].Value = MAM_Equipinfo.MAM_EquipName;
            parm[1] = new SqlParameter("@MAM_ManuCode", SqlDbType.VarChar, 50);
            parm[1].Value = MAM_Equipinfo.MAM_ManuCode;
            parm[2] = new SqlParameter("@MAM_Location", SqlDbType.VarChar, 40);
            parm[2].Value = MAM_Equipinfo.MAM_Location;

            parm[3] = new SqlParameter("@MAM_ToDate", SqlDbType.Date);
            parm[3].Value = MAM_Equipinfo.MAM_ToDate;
            parm[4] = new SqlParameter("@MAM_OAccuracy", SqlDbType.VarChar, 100);
            parm[4].Value = MAM_Equipinfo.MAM_OAccuracy;

            parm[5] = new SqlParameter("@MAM_IAccuracy", SqlDbType.VarChar,100);
            parm[5].Value = MAM_Equipinfo.MAM_IAccuracy;
            parm[6] = new SqlParameter("@MAM_Period", SqlDbType.SmallInt);
            parm[6].Value = MAM_Equipinfo.MAM_Period;
            parm[7] = new SqlParameter("@MAM_ToBeTestDate", SqlDbType.Date);
            parm[7].Value = MAM_Equipinfo.MAM_ToBeTestDate;
            parm[8] = new SqlParameter("@MAM_RemindDays", SqlDbType.SmallInt);
            parm[8].Value = MAM_Equipinfo.MAM_RemindDays;

            parm[9] = new SqlParameter("@MAM_EquipType", SqlDbType.VarChar, 50);
            parm[9].Value = MAM_Equipinfo.MAM_EquipType;
            parm[10] = new SqlParameter("@MAM_ManuName", SqlDbType.VarChar, 100);
            parm[10].Value = MAM_Equipinfo.MAM_ManuName;
            parm[11] = new SqlParameter("@MAM_Isunused", SqlDbType.Char, 2);
            parm[11].Value = MAM_Equipinfo.MAM_Isunused;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_I_MeasApplianceMan", parm);
        }
        public int Update_MeasApplianceMan(MeasApplianceMan MAM_Equipinfo)
        {//编辑计量器具信息
            SqlParameter[] parm = new SqlParameter[13];
            parm[0] = new SqlParameter("@MAM_EquipID", SqlDbType.UniqueIdentifier);
            parm[0].Value = MAM_Equipinfo.MAM_EquipID;
            parm[1] = new SqlParameter("@MAM_EquipName", SqlDbType.VarChar, 50);
            parm[1].Value = MAM_Equipinfo.MAM_EquipName;
            parm[2] = new SqlParameter("@MAM_ManuCode", SqlDbType.VarChar, 50);
            parm[2].Value = MAM_Equipinfo.MAM_ManuCode;
            parm[3] = new SqlParameter("@MAM_Location", SqlDbType.VarChar, 40);
            parm[3].Value = MAM_Equipinfo.MAM_Location;

            parm[4] = new SqlParameter("@MAM_ToDate", SqlDbType.Date);
            parm[4].Value = MAM_Equipinfo.MAM_ToDate;
            parm[5] = new SqlParameter("@MAM_OAccuracy", SqlDbType.VarChar, 100);
            parm[5].Value = MAM_Equipinfo.MAM_OAccuracy;

            parm[6] = new SqlParameter("@MAM_IAccuracy", SqlDbType.VarChar, 100);
            parm[6].Value = MAM_Equipinfo.MAM_IAccuracy;
            parm[7] = new SqlParameter("@MAM_Period", SqlDbType.SmallInt);
            parm[7].Value = MAM_Equipinfo.MAM_Period;
            parm[8] = new SqlParameter("@MAM_ToBeTestDate", SqlDbType.Date);
            parm[8].Value = MAM_Equipinfo.MAM_ToBeTestDate;
            parm[9] = new SqlParameter("@MAM_RemindDays", SqlDbType.SmallInt);
            parm[9].Value = MAM_Equipinfo.MAM_RemindDays;

            parm[10] = new SqlParameter("@MAM_EquipType", SqlDbType.VarChar, 50);
            parm[10].Value = MAM_Equipinfo.MAM_EquipType;
            parm[11] = new SqlParameter("@MAM_ManuName", SqlDbType.VarChar, 100);
            parm[11].Value = MAM_Equipinfo.MAM_ManuName;
            parm[12] = new SqlParameter("@MAM_Isunused", SqlDbType.Char, 2);
            parm[12].Value = MAM_Equipinfo.MAM_Isunused;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_U_MeasApplianceMan", parm);
        }
        public int Delete_MeasApplianceMan(Guid MAM_EquipID)
        {//删除计量器具信息
            

            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_D_MeasApplianceMan", new SqlParameter("@MAM_EquipID", MAM_EquipID));
        }
        public DataSet SelectByID_MeasApplianceMan(Guid MAM_EquipID)
        {//根据ID查找计量器具信息
            SqlParameter para = new SqlParameter("@MAM_EquipID", MAM_EquipID);


            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_SByID_MeasApplianceMan", para);
        }
        public DataSet Select_MeasApplianceDetail(Guid MAM_EquipID)
        {//查找检验结果
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@MAM_EquipID", SqlDbType.UniqueIdentifier);
            para[0].Value = MAM_EquipID;
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_MeasApplianceDetail", para);
        }
        public int Insert_MeasApplianceDetail(MeasApplianceDetail MAD_Detailinfo)
        {//添加检验结果 
            SqlParameter[] parm = new SqlParameter[6];
            parm[0] = new SqlParameter("@MAM_EquipID", SqlDbType.UniqueIdentifier);
            parm[0].Value = MAD_Detailinfo.MAM_EquipID;
            parm[1] = new SqlParameter("@MAD_TestNo", SqlDbType.VarChar, 50);
            parm[1].Value = MAD_Detailinfo.MAD_TestNo;
            parm[2] = new SqlParameter("@MAD_TestPer", SqlDbType.VarChar, 20);
            parm[2].Value = MAD_Detailinfo.MAD_TestPer;
            parm[3] = new SqlParameter("@MAD_TestTime", SqlDbType.DateTime);
            parm[3].Value = MAD_Detailinfo.MAD_TestTime;

            parm[4] = new SqlParameter("@MAD_Result", SqlDbType.VarChar,20);
            parm[4].Value = MAD_Detailinfo.MAD_Result;
            parm[5] = new SqlParameter("@MAD_Remarks", SqlDbType.VarChar, 400);
            parm[5].Value = MAD_Detailinfo.MAD_Remarks;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_I_MeasApplianceDetail", parm);
        }
        public int Update_MeasApplianceDetail(MeasApplianceDetail MAD_Detailinfo)
        {//编辑检验结果 
            SqlParameter[] parm = new SqlParameter[6];
            parm[0] = new SqlParameter("@MAD_DetailID", SqlDbType.UniqueIdentifier);
            parm[0].Value = MAD_Detailinfo.MAD_DetailID;
            parm[1] = new SqlParameter("@MAD_TestNo", SqlDbType.VarChar, 50);
            parm[1].Value = MAD_Detailinfo.MAD_TestNo;
            parm[2] = new SqlParameter("@MAD_TestPer", SqlDbType.VarChar, 20);
            parm[2].Value = MAD_Detailinfo.MAD_TestPer;
            parm[3] = new SqlParameter("@MAD_TestTime", SqlDbType.DateTime);
            parm[3].Value = MAD_Detailinfo.MAD_TestTime;

            parm[4] = new SqlParameter("@MAD_Result", SqlDbType.VarChar, 20);
            parm[4].Value = MAD_Detailinfo.MAD_Result;
            parm[5] = new SqlParameter("@MAD_Remarks", SqlDbType.VarChar, 400);
            parm[5].Value = MAD_Detailinfo.MAD_Remarks;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_U_MeasApplianceDetail", parm);
        }
        public int Delete_MeasApplianceDetail(Guid MAD_DetailID)
        {//删除检验结果 
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@MAD_DetailID", SqlDbType.UniqueIdentifier);
            parm[0].Value = MAD_DetailID;

            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_D_MeasApplianceDetail", parm);
        }
    }
}