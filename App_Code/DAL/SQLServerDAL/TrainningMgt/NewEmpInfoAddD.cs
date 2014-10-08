using System;
using System.Collections.Generic;
using EquipmentMangementAjax.DBUtility;
using System.Data.SqlClient;
using System.Data;

/// <summary>
///NewEmpInfoAddD 的摘要说明
/// </summary>

namespace EquipmentMangementAjax.SQLServer
{
    public class NewEmpInfoAddD : INewEmpInfoAdd
    {

        public int Insert_NETraInfoMainTable(NewEmpInfoAddInfo neiai)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_NETraInfoMainTable",
                     new SqlParameter("@NETIMT_ID", neiai.NETIMT_ID), new SqlParameter("@NETIMT_Person", neiai.NETIMT_Person),
                     new SqlParameter("@NETIMT_Time", neiai.NETIMT_Time), new SqlParameter("@NETIMT_Remarks", neiai.NETIMT_Remarks),
                     new SqlParameter("@NETIMT_State", neiai.NETIMT_State));

        }//新增培训信息

        public int Update_ForEdit_NETraInfoMainTable(NewEmpInfoAddInfo neiai)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_ForEdit_NETraInfoMainTable",
                new SqlParameter("@NETIMT_ID", neiai.NETIMT_ID), new SqlParameter("@NETIMT_Person", neiai.NETIMT_Person),
                     new SqlParameter("@NETIMT_Time", neiai.NETIMT_Time), new SqlParameter("@NETIMT_Remarks", neiai.NETIMT_Remarks));

        }//编辑培训信息

        public bool Delete_NETraInfoMainTable(Guid NETIMT_ID)
        {
            if (SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_NETraInfoMainTable",
                new SqlParameter("@NETIMT_ID", NETIMT_ID)) > 0)
                return true;
            else
                return false;
        }//删除培训信息

        public int Update_ForSubmit_NETraInfoMainTable(NewEmpInfoAddInfo neiai)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_ForSubmit_NETraInfoMainTable",
                new SqlParameter("@NETIMT_ID", neiai.NETIMT_ID), new SqlParameter("@NETIMT_State", neiai.NETIMT_State));

        }//提交<编辑>培训信息

        public DataSet Search_NETraInfoMainTable(string Condition)
        {
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_NETraInfoMainTable", new SqlParameter("@Condition", Condition));
        }//根据condition检索NETIMT_State(培训状态)为'已建立'的培训信息

        public IList<NewEmpInfoAddInfo> SearchByID_NETraInfoMainTable(Guid NETIMT_ID)
        {
            SqlParameter para = new SqlParameter("@NETIMT_ID", NETIMT_ID);
            IList<NewEmpInfoAddInfo> sSPIMI = new List<NewEmpInfoAddInfo>();
            SqlDataReader sdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_ByID_NETraInfoMainTable", para);
            while (sdr.Read())
            {
                sSPIMI.Add(new NewEmpInfoAddInfo(sdr["NETIMT_Person"] == DBNull.Value ? "" : sdr["NETIMT_Person"].ToString(),
                      (DateTime)sdr["NETIMT_Time"], sdr["NETIMT_Remarks"] == DBNull.Value ? "" : sdr["NETIMT_Remarks"].ToString()));
            }
            return sSPIMI;
        }//根据ID检索培训信息,用于取出数据进行编辑

        public int Insert_NETraPeopleChooseTable(NewEmpInfoAddInfo neiai)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_NETraPeopleChooseTable",
                new SqlParameter("@NETPCT_ID", neiai.NETPCT_ID), new SqlParameter("@NETPCT_Name", neiai.NETPCT_Name),
                new SqlParameter("@NETIMT_ID", neiai.NETIMT_ID), new SqlParameter("@NETPCT_Sex", neiai.NETPCT_Sex),
                new SqlParameter("@NETPCT_Date", neiai.NETPCT_Date));
        }//新增培训的新员工

        public DataSet Search_ByCondition_ForNETraPeopleChooseTable(string Condition)
        {
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_ByCondition_ForNETraPeopleChooseTable", new SqlParameter("@Condition", Condition));
        }//检索人事档案中的员工（以供选择）

        public DataSet Search_ByCondition_NETraPeopleChooseTable(string Condition)
        {
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_ByCondition_NETraPeopleChooseTable", new SqlParameter("@Condition", Condition));
        }//检索该次培训中的员工

        public bool Delete_NETraPeopleChooseTable(Guid NETPCT_ID)
        {
            if (SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_NETraPeopleChooseTable",
                new SqlParameter("@NETPCT_ID", NETPCT_ID)) > 0)
                return true;
            else
                return false;
        }//删除培训的新员工

        public int Insert_NETraItemChooseTable(NewEmpInfoAddInfo neiai)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_NETraItemChooseTable",
                new SqlParameter("@NETICT_ID", neiai.NETICT_ID), new SqlParameter("@NETIMT_ID", neiai.NETIMT_ID),
                new SqlParameter("@NETI_ID", neiai.NETI_ID));
        }//新增该次培训的项目

        public DataSet Search_NETraItemChooseTable(string Condition)
        {
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_NETraItemChooseTable", new SqlParameter("@Condition", Condition));
        }//检索该次培训的项目

        public DataSet Search_ForChoose_NETraItemChooseTable(string Condition)
        {
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_ForChoose_NETraItemChooseTable", new SqlParameter("@Condition", Condition));
        }//检索培训的项目

        public bool Delete_NETraItemChooseTable(Guid NETICT_ID)
        {
            if (SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_NETraItemChooseTable",
                new SqlParameter("@NETICT_ID", NETICT_ID)) > 0)
                return true;
            else
                return false;
        }//删除该次培训的某个项目



        /// <summary>
        /// 检新员工培训主讲人指定
        /// </summary>
        /// <param name="Condition"></param>
        /// <returns></returns>
        public DataSet Search_NETraItemChooseTable_NETrainingItem_BD(string Condition)
        {
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_NETraItemChooseTable_NETrainingItem_BDO", new SqlParameter("@Condition", Condition));
        }//检新员工培训主讲人指定，检索培训项目列表

        public DataSet Search_NETraItemChooseTable_NETraPeopleChooseTable_HRDDetail(string Condition)
        {
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_NETraItemChooseTable_NETraPeopleChooseTable_HRDDetail", new SqlParameter("@Condition", Condition));
        }//新员工培训主讲人指定，检索该次培训的某个项目的培训人员

        public DataSet Search_ForTeacher_HRDDetail(string Condition)
        {
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_ForTeacher_HRDDetail", new SqlParameter("@Condition", Condition));
        }//新员工培训主讲人指定，检索所有的主讲人

        public int Update_ForTeacher_NETraItemChooseTable(NewEmpInfoAddInfo neiai)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_ForTeacher_NETraItemChooseTable",
                new SqlParameter("@NETICT_ID", neiai.NETICT_ID), new SqlParameter("@UMUI_UserID", neiai.UMUI_UserID),
                new SqlParameter("@NETICT_Person", neiai.NETICT_Person));

        }//新员工培训主讲人指定，安排(更新表中字段)主讲人


        /// <summary>
        /// 新员工培训结果录入
        /// </summary>
        /// <param name="Condition"></param>
        /// <returns></returns>
        public DataSet Search_NETraItemChooseTable_NETraEachItemResultDetail(string Condition)
        {
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_NETraItemChooseTable_NETraEachItemResultDetail", new SqlParameter("@Condition", Condition));
        }//新员工培训结果录入，检索新员工培训项目列表

        public DataSet Search_ForPeopleChoose_NETraItemChooseTable(string Condition)
        {
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_ForPeopleChoose_NETraItemChooseTable", new SqlParameter("@Condition", Condition));
        }//新员工培训结果录入，新员工培训项目列表中点击“录入培训结果”，检索没有录入成绩的员工

        public int Insert_NETraEachItemResultDetail(NewEmpInfoAddInfo neiai)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_NETraEachItemResultDetail",
                new SqlParameter("@NETPCT_ID", neiai.NETPCT_ID), new SqlParameter("@NETICT_ID", neiai.NETICT_ID),
                new SqlParameter("@NETEIRD_IsQualified", neiai.NETEIRD_IsQualified), new SqlParameter("@NETEIRD_Remark", neiai.NETEIRD_Remark));
        }//新员工培训结果录入，"提交"按钮，插入新员工培训结果详情表

        public int Update_ForStateChange_NNETraInfoMainTable(NewEmpInfoAddInfo neiai)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_ForStateChange_NNETraInfoMainTable",
                new SqlParameter("@NETICT_ID", neiai.NETICT_ID), new SqlParameter("@NETIMT_State", neiai.NETIMT_State));
        }//新员工培训结果录入，"提交"按钮，更新新员工培训信息主表的状态

        public int Update_ForTime_NETraItemChooseTable(NewEmpInfoAddInfo neiai)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_ForTime_NETraItemChooseTable",
                new SqlParameter("@NETICT_ID", neiai.NETICT_ID), new SqlParameter("@NETICT_STime", neiai.NETICT_STime),
                new SqlParameter("@NETICT_ETime", neiai.NETICT_ETime), new SqlParameter("@NETICT_Place", neiai.NETICT_Place));
        }//新员工培训结果录入，"提交"按钮，更新该培训项目的信息
    }
}