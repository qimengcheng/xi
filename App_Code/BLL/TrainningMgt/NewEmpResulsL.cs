using System;
using System.Data;

/// <summary>
///NewEmpResulsL 的摘要说明
/// </summary>
public class NewEmpResulsL
{
    private static readonly INewEmpResulsD iNewEmpResulsD = DALFactory.CreateNewEmpResulsD();
    public DataSet Search_HRDDetail_NETraEachItemResultDetail(string Condition)
    {
        return iNewEmpResulsD.Search_HRDDetail_NETraEachItemResultDetail(Condition);
    }//新员工培训结果查看，检索新员工培训结果列表(检索按钮)

    public DataSet Search_Others_NETraEachItemResultDetai(Guid NETPCT_ID)
    {
        return iNewEmpResulsD.Search_Others_NETraEachItemResultDetai(NETPCT_ID);
    }//新员工培训结果查看，检索新员工培训详情列表（linkbutton）
}