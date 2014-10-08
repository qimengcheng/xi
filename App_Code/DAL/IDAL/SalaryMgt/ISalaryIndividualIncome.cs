using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

public interface ISalaryIndividualIncome
{
    int Delete_SalaryIndividualIncomeTax(Guid ID);
    int Insert_SalaryIndividualIncomeTax(SalaryIndividualIncomeInfo ssm);
    DataSet Search_SalaryIndividualIncomeTax(string Condition);
    int Update_SalaryIndividualIncomeTax(SalaryIndividualIncomeInfo ssm);
}
