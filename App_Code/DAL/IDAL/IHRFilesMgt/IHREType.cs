using System;
using System.Data;

/// <summary>
///IHREType 的摘要说明
/// </summary>
public interface IHREType
{
    int Insert_HREmployeeType(HRETypeInfo hre);
    int Update_HREmployeeType(HRETypeInfo hre);
    void Delete_HREmployeeType(Guid ID);
    DataSet Search_HREmployeeType(string HRET_EmpType);
}