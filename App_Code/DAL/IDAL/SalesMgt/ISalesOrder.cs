using System;
using System.Data;


/// <summary>
///ISalesOrder 的摘要说明
/// </summary>
public interface ISalesOrder
{
         DataSet Select_SalesOrder(string condition);
         DataSet Select_SalesOrderDetail(string condition);
         DataSet Select_SalesOrderDetail_Gridview(Guid ordernum);
         void Delete_SalseOrder(Guid ordernum);
         void Delete_SalseOrderDetail(Guid orderDetailnum);
         void Update_SalesOrder(Guid ordernum,string cusordernum,string detail,string ordertype);
         void Update_SalesOrderDetail(Guid orderdetailnum, DateTime addetime,int alerttime,string batchnum,string model,string special,string pay,DateTime deltime,int mount);
         void Insert_SalesOrder(string cusordernum, string salesman, Guid crmcifID, string ordertype, string detailcir, string inputpep);
         DataSet Select_Custom(string condition);
         void Insert_SalesOrder(Guid pt, Guid sm);
         int Update_SalesOrderState_ConfirmNew(Guid orderID);
         DataSet Select_DelChangeHistory(Guid detailID);
         void Insert_SMDelTimeChangeHistory(Guid DetailID, DateTime AfterChangeDelTime, string man, DateTime ChangeTime);

}
