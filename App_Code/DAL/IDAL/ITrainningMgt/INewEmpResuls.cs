using System;
using System.Data;

public interface INewEmpResulsD
{
    DataSet Search_HRDDetail_NETraEachItemResultDetail(string Condition);
    DataSet Search_Others_NETraEachItemResultDetai(Guid NETPCT_ID);
}
