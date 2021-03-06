﻿using System;
using EquipmentMangementAjax.DBUtility;
using System.Data.SqlClient;
using System.Data;

/// <summary>
///HRPerfYearD 的摘要说明
/// </summary>
namespace EquipmentMangementAjax.SQLServer
{
    public class HRPerfYearD:IHRerfYear
    {
        public HRPerfYearD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        public int Insert_HRPerformceYear(HRPerformceYearInfo hr)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_HRPerformceYear",
                new SqlParameter("@HRPYear_ID", hr.HRPYear_ID), new SqlParameter("@HRP_Year", hr.HRP_Year),
                new SqlParameter("@HRP_Month", hr.HRP_Month), new SqlParameter("@HRP_A_State", hr.HRP_A_State),
                new SqlParameter("@HRP_C_State", hr.HRP_C_State), new SqlParameter("@HRP_A_Person", hr.HRP_A_Person),
                new SqlParameter("@HRPYear_IsDeleted ", hr.HRPYear_IsDeleted), new SqlParameter("@HRP_M_State", hr.HRP_M_State));
        }

        public DataSet Search_HRPerformceYear_State(Guid guid, String HRPAT_APerson)
        {            
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_HRPerformceYear_State",
                    new SqlParameter("@HRPYear_ID", guid), new SqlParameter("@HRPAT_APerson", HRPAT_APerson));         
        }
        public int Update_HRPerformceYear(HRPerformceYearInfo hr)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_HRPerformceYear",
                new SqlParameter("@HRPYear_ID", hr.HRPYear_ID), new SqlParameter("@HRP_Year", hr.HRP_Year),
                new SqlParameter("@HRP_Month", hr.HRP_Month), new SqlParameter("@HRP_A_State", hr.HRP_A_State),
                new SqlParameter("@HRP_C_State", hr.HRP_C_State), new SqlParameter("@HRP_C_Person", hr.HRP_C_Person));
        }

        public DataSet Search_HRPerformceYear(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 2000);
            para[0].Value = condition;
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_HRPerformceYear_CHECK", para);
        }

        //查询考核年份和月份表中审核的状态
        public int Search_HRPerformceYear_CHECK_State(int year,int month,string person)
        {
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@state", SqlDbType.Int);
            para[0].Direction = ParameterDirection.Output;
            para[1] = new SqlParameter("@HRPD_Year", SqlDbType.SmallInt);
            para[1].Value = year;
            para[2] = new SqlParameter("@HRPD_Month", SqlDbType.TinyInt);
            para[2].Value = month;
            para[3] = new SqlParameter("@HRPAT_CPerson", SqlDbType.VarChar);
            para[3].Value = person;
            try
            {
                return (int)SqlHelper.ExecuteReturnQuery(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_HRPerformceYear_CHECK_State", para);
            }
            catch (Exception)
            {
                return -1;
            }
        }
        //查询该年该月下审核的人和未审核的人
        public DataSet Search_HRPerformceYear_HRPerformceDetail_State(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 2000);
            para[0].Value = condition;
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_HRPerformceYear_HRPerformceDetail_State", para);
        }


        #region//后来增加的总经理绩效考核中的函数
        public DataSet Search_HRPerformceYear_Manager(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 2000);
            para[0].Value = condition;
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_HRPerformceYear_Manager", para);
        }
        public DataSet Search_HRPerformceDetail_Manager(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 2000);
            para[0].Value = condition;
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_HRPerformceDetail_Manager", para);
        }

        public int Update_HRPerformceDetail_Manager(HRPerformceDetailInfo hr)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_HRPerformceDetail_Manager",
                new SqlParameter("@HRPD_ID", hr.HRPD_ID), new SqlParameter("@HRPD_M_Score", hr.HRPD_M_Score));
        }

        public DataSet Search_HRPerformceDetail_Manager_View(string condition)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Condition", SqlDbType.NVarChar, 2000);
            para[0].Value = condition;
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_HRPerformceDetail_Manager_View", para);
        }

        public int Search_HRPerformceYear_Manager_State(int year,int month)
        {
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("@state", SqlDbType.Int);
            para[0].Direction = ParameterDirection.Output;
            para[1] = new SqlParameter("@HRP_Year", SqlDbType.SmallInt);
            para[1].Value = year;
            para[2] = new SqlParameter("@HRP_Month", SqlDbType.TinyInt);
            para[2].Value = month;
            try
            {
                return (int)SqlHelper.ExecuteReturnQuery(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_S_HRPerformceYear_Manager_State", para);
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int Update_HRPerformceYear_Manager(HRPerformceYearInfo hr)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_HRPerformceYear_Manager",
                new SqlParameter("@HRPYear_ID", hr.HRPYear_ID), new SqlParameter("@HRP_M_State", hr.HRP_M_State));
        }//更新年份月份表中的经理考核的审核状态
        #endregion
    }
}                