using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
///SalaryReviewD 的摘要说明
/// </summary>
namespace EquipmentMangementAjax.SQLServer
{
    public class SalaryReviewD : ISalaryReview
    {
        public SalaryReviewD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        public DataSet Search_SearchEachPersonInYearMonth(string Condition)
        {

            SqlParameter para = new SqlParameter("@Condition", Condition);

            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_SearchEachPersonInYearMonth", para);

        }//<薪资管理，薪资查看，检索某人某年某月的工资总额>

        public DataSet Search_SearchEachPersonDetail(string Condition)
        {

            SqlParameter para = new SqlParameter("@Condition", Condition);

            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_SearchEachPersonDetail", para);

        }//薪资管理，薪资查看，检索某人某年某月的各项工资的详情
    }
}