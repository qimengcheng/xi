using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

public interface ISalaryMonthCalculate
{
    void Insert_SalaryMonCalculate(SalaryMonthCalculateInfo salaryMonthCalculateInfo);
    void Insert_SalaryMonthCalculateForAll(SalaryMonthCalculateInfo salaryMonthCalculateInfo);
    void Insert_SalaryRelationshipsTable(SalaryMonthCalculateInfo salaryMonthCalculateInfo);
    DataSet Search_SalaryEmpWageDetail_NotShenHe_EachPersonTotal(string condition);
    DataSet Search_SalaryEmpWageDetail_NotShenHe_EachPersonTotalDetail(string condition);
    DataSet Search_SalaryEmpWageDetail_SalaryMonCalculate_NotShenHe(string condition);
    int Update_SalaryEmpWageDetail_EachPersonDetail(SalaryMonthCalculateInfo salaryMonthCalculateInfo);
    DataSet Search_SearchForShenHe();
    DataSet Search_SearchShenHeDetail(SalaryMonthCalculateInfo salaryMonthCalculateInfo);
    int SearchCanBeCalulated(DateTime SEWD_StartDate, DateTime SEWD_EndDate, string YearAndMonth);
    int Delete_SalaryItemTable(SalaryMonthCalculateInfo salaryMonthCalculateInfo);
    DataSet Search_SearchPersonNotInSet(string condition);
    DataSet Search_SearchPersonNotHavePerform(string condition);

    DataSet Search_SalaryPeopleIn(string condition);
    DataSet Search_SalaryPeopleOut(string condition);
    int Delete_SalaryPeopleIn(SalaryMonthCalculateInfo salaryMonthCalculateInfo);
   //资管理，薪资月度结算，删除默认的待结算的员工列表中的员工
    int Insert_SalaryDetailBivariateTableForOne(SalaryMonthCalculateInfo salaryMonthCalculateInfo);

    int Insert_SalaryMonthCalculate(SalaryMonthCalculateInfo salaryMonthCalculateInfo);
}
