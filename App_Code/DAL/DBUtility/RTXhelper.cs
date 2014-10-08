using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using EquipmentMangementAjax.DBUtility;
using RTXSAPILib;

/// <summary>
/// RTXhelper 的摘要说明
/// </summary>

namespace RTXHelper
{



    public class RTXhelper
    {
        private static Rtx rtx = new Rtx();
       

        public RTXhelper()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        public static string Send(string message, string powerString)
        {
            string[] powerStrings = powerString.Split(',');
           
            string rtxusername =",";
            foreach (string s in powerStrings)
            {
                SqlDataReader myReader = Query_PeopleByRole(s);
                while (myReader.Read())
                {
                    if (myReader["UMUI_RTXUserName"].ToString() != "")
                    {
                        if (!rtxusername.Contains("," + myReader["UMUI_RTXUserName"] + ","))
                        {
                            rtxusername += myReader["UMUI_RTXUserName"].ToString() + ";"; //增加Item
                        }
                    }
                }

            }
            if (rtxusername==",")
            {
                return "没有相关权限的人员哦";
            }
            rtxusername=rtxusername.Substring(1, rtxusername.Length - 2);
            string sErr = "";
         
            try
            {
                rtx.RTX_SendIM("999", "uestc", message, rtxusername);
            }

            catch (Exception ex)
            {
                sErr = ex.Message;
            }
            return sErr;

        }

        public static string SendbyDepAndRole(string message, string dep,string role)   
        {
            string[] powerStrings = role.Split(',');

            string rtxusername = ",";
            foreach (string s in powerStrings)
            {
                SqlDataReader myReader = Query_PeoplebyDepandRold(dep,role);
                while (myReader.Read())
                {
                    if (myReader["UMUI_RTXUserName"].ToString() != "")
                    {
                        if (!rtxusername.Contains("," + myReader["UMUI_RTXUserName"] + ","))
                        {
                            rtxusername += myReader["UMUI_RTXUserName"].ToString() + ";"; //增加Item
                        }
                    }
                }

            }
            if (rtxusername!=",")
            {
                rtxusername = rtxusername.Substring(1, rtxusername.Length - 2);
            }
           
            string sErr = "";
            if (rtxusername == ",")
            {
                return "没有相关权限的人员哦";
            }
            try
            {
                rtx.RTX_SendIM("999", "uestc", message, rtxusername);
            }

            catch (Exception ex)
            {
                sErr = ex.Message;
            }
            return sErr;
        }
        public static string SendbyRtxName(string message, string rtxName) //rtxName为多用户时,用英文分号分隔.
        {
            if (rtxName == "")
            {
                return "用户为空";
            }
            Rtx rtx = new Rtx();
          
            string sErr = "";


            try
            {
                rtx.RTX_SendIM("999", "uestc", message,rtxName);
            }

            catch (Exception ex)
            {
                sErr = ex.Message;
            }
            return sErr;

        }

       
        public static string SendbyUserName(string message, string name)
        {
            string[] names = name.Split(',');
            string rtxusername = null;
            foreach (string s in names)
            {
                string username = Query_PeoplebyName(s);

                if (username != "")
                {
                    rtxusername += username + ";"; //增加Item
                }


            }
            string sErr = "";
            if (rtxusername == "")
            {
                return "没有相关权限的人员哦";
            }
            try
            {
                rtx.RTX_SendIM("999", "uestc", message, rtxusername);
            }

            catch (Exception ex)
            {
                sErr = ex.Message;
            }
            return sErr;

        }

        public static SqlDataReader Query_PeopleByRole(string s)
        {
            SqlParameter[] para =
            {
                new SqlParameter("@power", SqlDbType.VarChar, 60),
            };
            para[0].Value = s;
            SqlDataReader ds = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_People", para);
            return ds;
        }
        public static SqlDataReader Query_PeoplebyDepandRold(string dep,string power)
        {
            SqlParameter[] para =
            {
                 new SqlParameter("@dep", SqlDbType.VarChar, 60),
                new SqlParameter("@power", SqlDbType.VarChar, 60),
            };
            para[0].Value = dep;
            para[1].Value = power;
            SqlDataReader ds = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_PeoplebyDepandRole", para);
            return ds;
        }
        public static string Query_PeoplebyName(string s)    
        {
            SqlParameter[] para =
            {
                new SqlParameter("@UserName", SqlDbType.VarChar, 64),
                new SqlParameter("@Name", SqlDbType.VarChar, 64),
            };
            para[0].Direction = ParameterDirection.Output;
            para[1].Value = s;
           string ds = SqlHelper.ExecuteReturnQueryString(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_RTXUser", para);
            return ds;
        }

       
    }
}