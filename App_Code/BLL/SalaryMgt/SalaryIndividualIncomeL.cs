using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using EquipmentMangementAjax.DBUtility;
using System.Data.SqlClient;

/// <summary>
///SalaryIndividualIncomeL 的摘要说明
/// </summary>
public class SalaryIndividualIncomeL
{

    private static readonly ISalaryIndividualIncome iSSM = DALFactory.CreateISalaryIndividualIncome();
	public SalaryIndividualIncomeL()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public int Insert_SalaryIndividualIncomeTax(SalaryIndividualIncomeInfo ssm)
        {
            return iSSM.Insert_SalaryIndividualIncomeTax(ssm);
        }//个人所得税基础信息维护，新增个人所得税标准

        public int Update_SalaryIndividualIncomeTax(SalaryIndividualIncomeInfo ssm)
        {
            return iSSM.Update_SalaryIndividualIncomeTax(ssm);

        }//个人所得税基础信息维护，编辑个人所得税标准

        public int Delete_SalaryIndividualIncomeTax(Guid ID)
        {
            return iSSM.Delete_SalaryIndividualIncomeTax(ID);
        }//个人所得税基础信息维护，删除个人所得税标准

        public DataSet Search_SalaryIndividualIncomeTax(string Condition)
        {
            return iSSM.Search_SalaryIndividualIncomeTax(Condition);
        }//个人所得税基础信息维护，检索个人所得税标准
}