using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using EquipmentMangementAjax.DBUtility;

/// <summary>
///SalaryReviewL 的摘要说明
/// </summary>
public class SalaryReviewL
{
    private static readonly ISalaryReview iSTIM = DALFactory.CreateISalaryReview();
	public SalaryReviewL()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public DataSet Search_SearchEachPersonInYearMonth(string Condition)
    {

        return iSTIM.Search_SearchEachPersonInYearMonth(Condition);

    }//<薪资管理，薪资查看，检索某人某年某月的工资总额>

    public DataSet Search_SearchEachPersonDetail(string Condition)
    {
        return iSTIM.Search_SearchEachPersonDetail(Condition);

    }//薪资管理，薪资查看，检索某人某年某月的各项工资的详情
}