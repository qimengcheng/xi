using System;
using System.Data;

/// <summary>
///HRETypeL 的摘要说明
/// </summary>
public class HRETypeL
{
    private static readonly IHREType iHR = DALFactory.CreateIHREType();
    public HRETypeL()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    public int Insert_HREmployeeType(HRETypeInfo hr)
    {
        return iHR.Insert_HREmployeeType(hr);
    }
    public int Update_HREmployeeType(HRETypeInfo hr)
    {
        return iHR.Update_HREmployeeType(hr);
    }
    public void Delete_HREmployeeType(Guid ID)
    {
        iHR.Delete_HREmployeeType(ID);
    }
    public DataSet Search_HREmployeeType(string HRET_EmpType)
    {
        return iHR.Search_HREmployeeType(HRET_EmpType);
    }
}