using System;
using System.Data;

/// <summary>
///ISalsePayBill 的摘要说明
/// </summary>
public interface ISalsePayBill
{
    void Insert_Main(Guid id, decimal loan, decimal maturity, decimal bill, string man);
    void Update_Bill(Guid id, Guid ptID, string num, decimal money, string man, string remark,decimal price,decimal pronum);
    int Insert_Bill(Guid id, Guid ptID, string num, decimal money, string man, string remark,decimal price,decimal pronum);
    void Delete_Main(Guid id);
    int Insert_Pay(Guid id, decimal money, string man, string remark);
    void Delete_Pay(Guid id);
    void Update_Pay(Guid id, decimal money, string man, string remark);
    DataSet Select_Bill(Guid id);
    DataSet Select_Pay(Guid id);
    void Update_Main(Guid id, decimal loan, decimal maturity, decimal bill, string man);
    DataSet Select_Main(string condition);
    void Delete_Bill(Guid id);
}