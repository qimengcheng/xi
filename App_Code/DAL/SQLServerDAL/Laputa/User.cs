using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
//using System.Collections.Generic;
using EquipmentMangementAjax.DBUtility;

/// <summary>
///User 的摘要说明
/// </summary>

namespace EquipmentMangementAjax.SQLServer
{
    public class User:IUser 
    {
        public User()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        public int Insert_UMUserInfo(UMUserInfoInfo uMUserInfoInfo)
        {
            SqlParameter[] parm = new SqlParameter[9];
            parm[0] = new SqlParameter("@BDOS_Code", SqlDbType.VarChar, 60);
            parm[0].Value = uMUserInfoInfo.BDOS_Code;
            parm[1] = new SqlParameter("@UMUI_UserID", SqlDbType.VarChar, 60);
            parm[1].Value = uMUserInfoInfo.UMUI_UserID ;
            parm[2] = new SqlParameter("@UMUI_UserName", SqlDbType.VarChar,60);
            parm[2].Value =uMUserInfoInfo.UMUI_UserName ;
            parm[3] = new SqlParameter("@UMUI_UserRole", SqlDbType.VarChar, 1000);
            parm[3].Value = uMUserInfoInfo.UMUI_UserRole == null ? "" : uMUserInfoInfo.UMUI_UserRole;
            parm[4] = new SqlParameter("@UMUI_TotalLoginCount", SqlDbType.Int, 4);
            parm[4].Value = uMUserInfoInfo.UMUI_TotalLoginCount == 0 ? 0 : uMUserInfoInfo.UMUI_TotalLoginCount;
            parm[5] = new SqlParameter("@UMUI_TodayLoginCount", SqlDbType.Int, 4);
            parm[5].Value = uMUserInfoInfo.UMUI_TodayLoginCount == 0 ? 0 : uMUserInfoInfo.UMUI_TodayLoginCount;
            parm[6] = new SqlParameter("@UMUI_Password", SqlDbType.VarChar, 200);
            parm[6].Value = uMUserInfoInfo.UMUI_Password;
            parm[7] = new SqlParameter("@UMUI_LastLoginTime", SqlDbType.DateTime);
            if (uMUserInfoInfo.UMUI_LastLoginTime == DateTime.MinValue)
            {
                parm[7].Value = DBNull.Value;
            }
            else
            {
                parm[7].Value = uMUserInfoInfo.UMUI_LastLoginTime;
            }
            parm[8] = new SqlParameter("@UMUI_Isdeleted", SqlDbType.Bit);
            parm[8].Value = 1;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_Insert_UMUserInfo", parm);
        }

        public int Update_UMUserInfo(UMUserInfoInfo uMUserInfoInfo)
        {
            SqlParameter[] parm = new SqlParameter[8];
            parm[0] = new SqlParameter("@BDOS_Code", SqlDbType.VarChar, 60);
            parm[0].Value = uMUserInfoInfo.BDOS_Code;
            parm[1] = new SqlParameter("@UMUI_UserID", SqlDbType.VarChar, 60);
            parm[1].Value = uMUserInfoInfo.UMUI_UserID;
            parm[2] = new SqlParameter("@UMUI_UserName", SqlDbType.VarChar, 60);
            parm[2].Value = uMUserInfoInfo.UMUI_UserName;
            parm[3] = new SqlParameter("@UMUI_UserRole", SqlDbType.VarChar, 1000);
            parm[3].Value = uMUserInfoInfo.UMUI_UserRole == null  ? "" : uMUserInfoInfo.UMUI_UserRole;
            parm[4] = new SqlParameter("@UMUI_TotalLoginCount", SqlDbType.Int, 4);
            parm[4].Value = uMUserInfoInfo.UMUI_TotalLoginCount == 0 ? 0 : uMUserInfoInfo.UMUI_TotalLoginCount;
            parm[5] = new SqlParameter("@UMUI_TodayLoginCount", SqlDbType.Int, 4);
            parm[5].Value = uMUserInfoInfo.UMUI_TodayLoginCount == 0 ? 0 : uMUserInfoInfo.UMUI_TodayLoginCount;
            //parm[6] = new SqlParameter("@UMUI_Password", SqlDbType.VarChar, 200);
            //parm[6].Value = uMUserInfoInfo.UMUI_Password == null ? "" : uMUserInfoInfo.UMUI_Password;
            parm[6] = new SqlParameter("@UMUI_LastLoginTime", SqlDbType.DateTime);
            if (uMUserInfoInfo.UMUI_LastLoginTime == DateTime.MinValue)
            {
                parm[6].Value = Convert.ToDateTime("1900-1-1") ;
            }
            else
            {
                parm[6].Value = uMUserInfoInfo.UMUI_LastLoginTime;
            }
            parm[7] = new SqlParameter("@UMUI_Isdeleted", SqlDbType.Bit );
            parm[7].Value = 1;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_Update_UMUserInfo", parm);
        }

        public int Delete_UMUserInfo(string uMUI_UserID)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@UMUI_UserID", SqlDbType.VarChar, 60);
            parm[0].Value = uMUI_UserID ;
         

            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_Delete_UMUserInfo", parm);
        }

        public IList<UMUserInfoInfo> Select_UMUserInfo(string condition)
        {
            SqlParameter para = new SqlParameter("@Condition", condition);
            IList<UMUserInfoInfo> IUserInfo = new List<UMUserInfoInfo>();
            SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_Select_UMUserInfo", para);
            while (sdr.Read())
            {
                IUserInfo.Add(new UMUserInfoInfo(sdr["UMUI_UserID"]==DBNull.Value?"":sdr["UMUI_UserID"].ToString(),
                   sdr["UMUI_UserName"] == DBNull.Value ? "" : sdr["UMUI_UserName"].ToString(),
                   sdr["UMUI_Password"] == DBNull.Value ? "" : sdr["UMUI_Password"].ToString(),
                   sdr["UMUI_LastLoginTime"] == DBNull.Value ? DateTime.MinValue  : Convert.ToDateTime(sdr["UMUI_LastLoginTime"]),
                   sdr["UMUI_TotalLoginCount"] == DBNull.Value ? 0 : (int)sdr["UMUI_TotalLoginCount"],
                   sdr["UMUI_TodayLoginCount"] == DBNull.Value ? 0 : (int)sdr["UMUI_TodayLoginCount"],
                   sdr["BDOS_Code"] == DBNull.Value ? "" : sdr["BDOS_Code"].ToString(),
                   sdr["UMUI_UserRole"] == DBNull.Value ? "" : sdr["UMUI_UserRole"].ToString(),
                   sdr["BDOS_Name"] == DBNull.Value ? "" : sdr["BDOS_Name"].ToString()));
            }
            return IUserInfo;
        }

    }
}
