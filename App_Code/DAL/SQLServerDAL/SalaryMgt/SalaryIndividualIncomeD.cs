using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EquipmentMangementAjax.DBUtility;
using System.Data.SqlClient;
using System.Data;

/// <summary>
///SalaryIndividualIncomeD 的摘要说明
/// </summary>
namespace EquipmentMangementAjax.SQLServer
{
    public class SalaryIndividualIncomeD : ISalaryIndividualIncome
    {
        public SalaryIndividualIncomeD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        public int Insert_SalaryIndividualIncomeTax(SalaryIndividualIncomeInfo ssm)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_I_SalaryIndividualIncomeTax",
                new SqlParameter("@SIIT_Min", ssm.SIIT_Min), new SqlParameter("@SIIT_Max", ssm.SIIT_Max),
                new SqlParameter("@SIIT_Rate", ssm.SIIT_Rate), new SqlParameter("@SIIT_Deduction", ssm.SIIT_Deduction));
        }//个人所得税基础信息维护，新增个人所得税标准

        public int Update_SalaryIndividualIncomeTax(SalaryIndividualIncomeInfo ssm)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_U_SalaryIndividualIncomeTax",
                new SqlParameter("@SIIT_ID", ssm.SIIT_ID), new SqlParameter("@SIIT_Min", ssm.SIIT_Min),
                new SqlParameter("@SIIT_Max", ssm.SIIT_Max),new SqlParameter("@SIIT_Rate", ssm.SIIT_Rate),
                new SqlParameter("@SIIT_Deduction", ssm.SIIT_Deduction));

        }//个人所得税基础信息维护，编辑个人所得税标准

        public int Delete_SalaryIndividualIncomeTax(Guid ID)
        {
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_SalaryIndividualIncomeTax",
                new SqlParameter("@SIIT_ID", ID));
        }//个人所得税基础信息维护，删除个人所得税标准

        public DataSet Search_SalaryIndividualIncomeTax(string Condition)
        {
            return (DataSet)SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure,
                "Proc_S_SalaryIndividualIncomeTax", new SqlParameter("@condition", Condition));
        }//个人所得税基础信息维护，检索个人所得税标准
    }
}