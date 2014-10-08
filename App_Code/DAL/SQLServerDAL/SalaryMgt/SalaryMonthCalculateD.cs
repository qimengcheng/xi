using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;
using System.Data;

/// <summary>
///SalaryMonthCalculate 的摘要说明
/// </summary>
namespace EquipmentMangementAjax.SQLServer
{
    public class SalaryMonthCalculateD : ISalaryMonthCalculate
    {
        public SalaryMonthCalculateD()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        public int Insert_SalaryMonthCalculate(SalaryMonthCalculateInfo salaryMonthCalculateInfo)
        {
            SqlParameter[] parm = new SqlParameter[5];

            parm[0] = new SqlParameter("@SEWD_StartDate", SqlDbType.Date);
            parm[0].Value = salaryMonthCalculateInfo.SEWD_StartDate;

            parm[1] = new SqlParameter("@SEWD_EndDate", SqlDbType.Date);
            parm[1].Value = salaryMonthCalculateInfo.SEWD_EndDate;
            parm[2] = new SqlParameter("@SEWD_Year", SqlDbType.SmallInt);
            parm[2].Value = salaryMonthCalculateInfo.SEWD_Year;
            parm[3] = new SqlParameter("@SEWD_Month", SqlDbType.TinyInt);
            parm[3].Value = salaryMonthCalculateInfo.SEWD_Month;
            parm[4] = new SqlParameter("@SMC_Person", SqlDbType.VarChar,20);
            parm[4].Value = salaryMonthCalculateInfo.SMC_Person;
            int i = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                  CommandType.StoredProcedure, "Proc_I_SalaryMonthCalculate", parm);
            return i;
        }//薪资管理，薪资月度结算，新增月度结算信息(点击“提交”按钮进行的操作)

        public void Insert_SalaryMonthCalculateForAll(SalaryMonthCalculateInfo salaryMonthCalculateInfo)
        {
            SqlParameter[] parm = new SqlParameter[5];

            parm[0] = new SqlParameter("@SEWD_StartDate", SqlDbType.Date);
            parm[0].Value = salaryMonthCalculateInfo.SEWD_StartDate;

            parm[1] = new SqlParameter("@SEWD_EndDate", SqlDbType.Date);
            parm[1].Value = salaryMonthCalculateInfo.SEWD_EndDate;
            parm[2] = new SqlParameter("@SEWD_Year", SqlDbType.SmallInt);
            parm[2].Value = salaryMonthCalculateInfo.SEWD_Year;
            parm[3] = new SqlParameter("@SEWD_Month", SqlDbType.TinyInt);
            parm[3].Value = salaryMonthCalculateInfo.SEWD_Month;
            parm[4] = new SqlParameter("@月度结算ID", SqlDbType.UniqueIdentifier);
            parm[4].Value = salaryMonthCalculateInfo.SMC_ID;
            int i = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                  CommandType.StoredProcedure, "Proc_I_SalaryMonthCalculateForAll", parm);
        }//薪资管理，薪资月度结算，初步结算

        public DataSet Search_SalaryEmpWageDetail_SalaryMonCalculate_NotShenHe(string condition)
        {
            SqlParameter para = new SqlParameter("@condition", condition);
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_SalaryEmpWageDetail_SalaryMonCalculate_NotShenHe", para);

        }//薪资管理，薪资月度结算，查询某年某月的总工资

        public DataSet Search_SalaryPeopleIn(string condition)
        {
            SqlParameter para = new SqlParameter("@Condition", condition);
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_SalaryPeopleIn", para);

        }//薪资管理，薪资月度结算，查询某年某月默认的员工列表

        public DataSet Search_SalaryPeopleOut(string condition)
        {
            SqlParameter para = new SqlParameter("@Condition", condition);
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_SalaryPeopleOut", para);

        }//薪资管理，薪资月度结算，检索除去默认的待结算之外的员工列表


        public void Insert_SalaryRelationshipsTable(SalaryMonthCalculateInfo salaryMonthCalculateInfo)
        {
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@SMC_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = salaryMonthCalculateInfo.SMC_ID;
            
            int i = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                  CommandType.StoredProcedure, "Proc_I_SalaryMonCalculate_WaitingForCalculate", parm);
        }//薪资管理，薪资月度结算，"提交审核"按钮

        public DataSet Search_SalaryEmpWageDetail_NotShenHe_EachPersonTotal(string condition)
        {

            SqlParameter para = new SqlParameter("@condition", condition);

            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_SalaryEmpWageDetail_NotShenHe_EachPersonTotal", para);

        }//薪资管理，薪资月度结算，查询某年某月的各员工的总工资

        public DataSet Search_SalaryEmpWageDetail_NotShenHe_EachPersonTotalDetail(string condition)
        {

            SqlParameter para = new SqlParameter("@condition", condition);

            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_SalaryEmpWageDetail_NotShenHe_EachPersonTotalDetail", para);

        }//薪资管理，薪资月度结算，查询某年某月的各员工的各项目工资

        public int Update_SalaryEmpWageDetail_EachPersonDetail(SalaryMonthCalculateInfo salaryMonthCalculateInfo)
        {
            SqlParameter[] parm = new SqlParameter[4];
            parm[0] = new SqlParameter("@outpara", SqlDbType.Int);
            parm[0].Direction = ParameterDirection.Output;
            parm[1] = new SqlParameter("@SEWD_ID", SqlDbType.UniqueIdentifier);
            parm[1].Value = salaryMonthCalculateInfo.SEWD_ID;
            parm[2] = new SqlParameter("@SEWD_ItemWage", SqlDbType.Decimal);
            parm[2].Value = salaryMonthCalculateInfo.SEWD_ItemWage;
            parm[3] = new SqlParameter("@SMC_ID", SqlDbType.UniqueIdentifier);
            parm[3].Value = salaryMonthCalculateInfo.SMC_ID;
            
            try
            {
                return SqlHelper.ExecuteReturnQuery(SqlHelper.ConnectionStringLocalTransaction,
                CommandType.StoredProcedure, "Proc_U_SalaryEmpWageDetail_EachPersonDetail", parm);
            }
            catch (Exception)
            {
                return -1;
            }
            
        }//薪资管理，薪资月度结算，编辑某年某月的各员工的各项目工资

        public void Insert_SalaryMonCalculate(SalaryMonthCalculateInfo salaryMonthCalculateInfo)
        {
            SqlParameter[] parm = new SqlParameter[4];
            parm[0] = new SqlParameter("@SMC_Auditor", SqlDbType.VarChar, 20);
            parm[0].Value = salaryMonthCalculateInfo.SMC_Auditor;
            parm[1] = new SqlParameter("@SMC_AuSugg", SqlDbType.VarChar, 400);
            parm[1].Value = salaryMonthCalculateInfo.SMC_AuSugg;
            parm[2] = new SqlParameter("@SMC_AuRes", SqlDbType.VarChar, 20);
            parm[2].Value = salaryMonthCalculateInfo.SMC_AuRes;
            parm[3] = new SqlParameter("@SMC_ID", SqlDbType.UniqueIdentifier);
            parm[3].Value = salaryMonthCalculateInfo.SMC_ID;
            

            int i = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                  CommandType.StoredProcedure, "Proc_I_SalaryMonCalculate", parm);
        }//薪资管理，薪资月度结算，审核

        public DataSet Search_SearchForShenHe()
        {

            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_SearchForShenHe");

        }//薪资管理，薪资月度结算，检索待审核的信息

        public DataSet Search_SearchShenHeDetail(SalaryMonthCalculateInfo salaryMonthCalculateInfo)
        {
            SqlParameter[] parm = new SqlParameter[1];

            parm[0] = new SqlParameter("@SMC_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = salaryMonthCalculateInfo.SMC_ID;
            
            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_SearchShenHeDetail", parm);

        }//薪资管理，薪资月度结算，检索审核的详情信息

        public int SearchCanBeCalulated(DateTime SEWD_StartDate, DateTime SEWD_EndDate, string YearAndMonth)
        {
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@state", SqlDbType.Int);
            para[0].Direction = ParameterDirection.Output;
            para[1] = new SqlParameter("@SEWD_StartDate", SqlDbType.Date);
            para[1].Value = SEWD_StartDate;
            para[2] = new SqlParameter("@SEWD_EndDate", SqlDbType.Date);
            para[2].Value = SEWD_EndDate;
            para[3] = new SqlParameter("@YearAndMonth", SqlDbType.VarChar, 20);
            para[3].Value = YearAndMonth;

            try
            {
                return SqlHelper.ExecuteReturnQuery(SqlHelper.ConnectionStringLocalTransaction,
                   CommandType.StoredProcedure, "Proc_S_SearchCanBeCalulated", para);
            }
            catch
            {
                int error = -1;
                return error;
            }
        }//薪资管理，薪资月度结算，检索能够进行审核的日期段以及能够作为结算的年月


        public int Delete_SalaryItemTable(SalaryMonthCalculateInfo salaryMonthCalculateInfo)
        {
            SqlParameter[] parm = new SqlParameter[1];

            parm[0] = new SqlParameter("@SMC_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = salaryMonthCalculateInfo.SMC_ID;
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_SalaryMonCalculate_SalaryEmpWageDetail",parm);
        }//资管理，薪资月度结算，删除某年某月的总工资及其明细

        public DataSet Search_SearchPersonNotInSet(string condition)
        {

            SqlParameter para = new SqlParameter("@condition", condition);

            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_SearchPersonNotInSet", para);

        }//薪资管理，薪资月度结算，检索不在账套中的员工

        public DataSet Search_SearchPersonNotHavePerform(string condition)
        {

            SqlParameter para = new SqlParameter("@condition", condition);

            return SqlHelper.GetDataSet(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_S_SearchPersonNotHavePerform", para);
        }//薪资管理，薪资月度结算，检索在账套中的当月没有给出绩效成绩的员工

        public int Delete_SalaryPeopleIn(SalaryMonthCalculateInfo salaryMonthCalculateInfo)
        {
            SqlParameter[] parm = new SqlParameter[1];

            parm[0] = new SqlParameter("@SDBT_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = salaryMonthCalculateInfo.SDBT_ID;
            return (int)SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "Proc_D_SalaryPeopleIn", parm);
        }//资管理，薪资月度结算，删除默认的待结算的员工列表中的员工

        public int Insert_SalaryDetailBivariateTableForOne(SalaryMonthCalculateInfo salaryMonthCalculateInfo)
        {
            SqlParameter[] parm = new SqlParameter[4];
            parm[0] = new SqlParameter("@HRDD_ID", SqlDbType.UniqueIdentifier);
            parm[0].Value = salaryMonthCalculateInfo.HRDD_ID;
            parm[1] = new SqlParameter("@SMC_ID", SqlDbType.UniqueIdentifier);
            parm[1].Value = salaryMonthCalculateInfo.SMC_ID;
            parm[2] = new SqlParameter("@SDBT_Dep", SqlDbType.VarChar, 20);
            parm[2].Value = salaryMonthCalculateInfo.SDBT_Dep;
            parm[3] = new SqlParameter("@SDBT_Post", SqlDbType.VarChar, 20);
            parm[3].Value = salaryMonthCalculateInfo.SDBT_Post;


             int i = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction,
                  CommandType.StoredProcedure, "Proc_I_SalaryDetailBivariateTableForOne", parm);
             return i;
        }//薪资管理，薪资月度结算，新增默认员工之外的员工
    }
}