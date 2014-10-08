using System;
using System.Data;
public interface ISalaryReview
{
    DataSet Search_SearchEachPersonDetail(string Condition);
    DataSet Search_SearchEachPersonInYearMonth(string Condition);
}
