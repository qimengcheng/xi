using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using EquipmentMangementAjax.DBUtility;

/// <summary>
///SalaryMonthCalculateL 的摘要说明
/// </summary>
public class SalaryMonthCalculateL
{
    private static readonly ISalaryMonthCalculate iSTIM = DALFactory.CreateISalaryMonthCalculate();
    public SalaryMonthCalculateL()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    public void Insert_SalaryMonthCalculateForAll(SalaryMonthCalculateInfo salaryMonthCalculateInfo)
    {
        iSTIM.Insert_SalaryMonthCalculateForAll(salaryMonthCalculateInfo);
    }//薪资管理，薪资月度结算，月度结算(点击“月度结算”按钮进行的操作)

    public DataSet Search_SalaryEmpWageDetail_SalaryMonCalculate_NotShenHe(string condition)
    {
        return iSTIM.Search_SalaryEmpWageDetail_SalaryMonCalculate_NotShenHe(condition);

    }//薪资管理，薪资月度结算，查询某年某月的总工资

    public void Insert_SalaryRelationshipsTable(SalaryMonthCalculateInfo salaryMonthCalculateInfo)
    {
        iSTIM.Insert_SalaryRelationshipsTable(salaryMonthCalculateInfo);
    }//薪资管理，薪资月度结算，"提交审核"按钮

    public DataSet Search_SalaryEmpWageDetail_NotShenHe_EachPersonTotal(string condition)
    {

        return iSTIM.Search_SalaryEmpWageDetail_NotShenHe_EachPersonTotal(condition);
    }//薪资管理，薪资月度结算，查询某年某月的各员工的总工资

    public DataSet Search_SalaryEmpWageDetail_NotShenHe_EachPersonTotalDetail(string condition)
    {

        return iSTIM.Search_SalaryEmpWageDetail_NotShenHe_EachPersonTotalDetail(condition);

    }//薪资管理，薪资月度结算，查询某年某月的各员工的各项目工资

    public int Update_SalaryEmpWageDetail_EachPersonDetail(SalaryMonthCalculateInfo salaryMonthCalculateInfo)
    {
        return iSTIM.Update_SalaryEmpWageDetail_EachPersonDetail(salaryMonthCalculateInfo);
    }//薪资管理，薪资月度结算，编辑某年某月的各员工的各项目工资

    public void Insert_SalaryMonCalculate(SalaryMonthCalculateInfo salaryMonthCalculateInfo)
    {
        iSTIM.Insert_SalaryMonCalculate(salaryMonthCalculateInfo);
    }//薪资管理，薪资月度结算，审核
    public DataSet Search_SearchForShenHe()
    {

        return iSTIM.Search_SearchForShenHe();

    }//薪资管理，薪资月度结算，检索待审核的信息

    public DataSet Search_SearchShenHeDetail(SalaryMonthCalculateInfo salaryMonthCalculateInfo)
    {
        return iSTIM.Search_SearchShenHeDetail(salaryMonthCalculateInfo);

    }//薪资管理，薪资月度结算，检索审核的详情信息

    public int SearchCanBeCalulated(DateTime SEWD_StartDate, DateTime SEWD_EndDate, string YearAndMonth)
    {
        return iSTIM.SearchCanBeCalulated(SEWD_StartDate,SEWD_EndDate,YearAndMonth);
    }//薪资管理，薪资月度结算，检索能够进行审核的日期段以及能够作为结算的年月

    public int Delete_SalaryItemTable(SalaryMonthCalculateInfo salaryMonthCalculateInfo)
    {
        return iSTIM.Delete_SalaryItemTable(salaryMonthCalculateInfo);
    }//资管理，薪资月度结算，删除某年某月的总工资及其明细


    public DataSet Search_SearchPersonNotInSet(string condition)
    {
        return iSTIM.Search_SearchPersonNotInSet(condition);

    }//薪资管理，薪资月度结算，检索不在账套中的员工

    public DataSet Search_SearchPersonNotHavePerform(string condition)
    {
        return iSTIM.Search_SearchPersonNotHavePerform(condition);
    }//薪资管理，薪资月度结算，检索在账套中的当月没有给出绩效成绩的员工

    public DataSet Search_SalaryPeopleIn(string condition)
    {
        return iSTIM.Search_SalaryPeopleIn(condition);
    }//薪资管理，薪资月度结算，查询某年某月默认的员工列表
    public DataSet Search_SalaryPeopleOut(string condition)
    {
        return iSTIM.Search_SalaryPeopleOut(condition);
    }//薪资管理，薪资月度结算，检索除去默认的待结算之外的员工列表

    public int Delete_SalaryPeopleIn(SalaryMonthCalculateInfo salaryMonthCalculateInfo)
    {
        return iSTIM.Delete_SalaryPeopleIn(salaryMonthCalculateInfo);
    }//资管理，薪资月度结算，删除默认的待结算的员工列表中的员工

    public int Insert_SalaryDetailBivariateTableForOne(SalaryMonthCalculateInfo salaryMonthCalculateInfo)
    {
        return iSTIM.Insert_SalaryDetailBivariateTableForOne(salaryMonthCalculateInfo);
    }//薪资管理，薪资月度结算，新增默认员工之外的员工

    public int Insert_SalaryMonthCalculate(SalaryMonthCalculateInfo salaryMonthCalculateInfo)
    {
        return iSTIM.Insert_SalaryMonthCalculate(salaryMonthCalculateInfo);
    }//薪资管理，薪资月度结算，新增月度结算信息(点击“提交”按钮进行的操作)
}