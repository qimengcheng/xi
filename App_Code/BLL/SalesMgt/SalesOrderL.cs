using System;
using System.Data;

/// <summary>
///SalesOrderL 的摘要说明
/// </summary>
public class SalesOrderL
{
    private static readonly ISalesOrder so=DALFactory.SalseOrder();
	public SalesOrderL()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
        public DataSet Select_SalesOrder(string condition)
        {
        return so.Select_SalesOrder(condition);
        }
        public DataSet Select_SalesOrderDetail(string condition)
        {
        return so.Select_SalesOrderDetail(condition);
        }
        public DataSet Select_SalesOrderDetail_Gridview(Guid ordernum)
        {
        return so.Select_SalesOrderDetail_Gridview(ordernum);
        }
        public void Delete_SalseOrder(Guid ordernum)
        {
            so.Delete_SalseOrder(ordernum);
        }
        public void Delete_SalseOrderDetail(Guid orderDetailnum)
        {
            so.Delete_SalseOrderDetail(orderDetailnum);
        }
        public void Update_SalesOrder(Guid ordernum,string cusordernum,string detail,string ordertype)
        {
            so.Update_SalesOrder(ordernum,cusordernum,detail,ordertype);
        }
        public void Update_SalesOrderDetail(Guid orderdetailnum, DateTime addetime,int alerttime,string batchnum,string model,string special,string pay,DateTime deltime,int mount)
        {
            so.Update_SalesOrderDetail(orderdetailnum,addetime,alerttime,batchnum,model,special,pay,deltime,mount);
        }
        public void Insert_SalesOrder(string cusordernum, string salesman, Guid crmcifID, string ordertype, string detailcir, string inputpep)
        {
            so.Insert_SalesOrder(cusordernum, salesman, crmcifID, ordertype, detailcir, inputpep);
        }
        public DataSet Select_Custom(string condition)
        {
            return so.Select_Custom(condition);
        }
        public void Insert_SalesOrder(Guid pt, Guid sm)
        {
            so.Insert_SalesOrder(pt, sm);
        }
        public int Update_SalesOrderState_ConfirmNew(Guid orderID)
        {
           return so.Update_SalesOrderState_ConfirmNew(orderID);
        }
        public DataSet Select_DelChangeHistory(Guid detailID)
        {
            return so.Select_DelChangeHistory(detailID);
        }
        public void Insert_SMDelTimeChangeHistory(Guid DetailID, DateTime AfterChangeDelTime, string man, DateTime ChangeTime)
        {
            so.Insert_SMDelTimeChangeHistory(DetailID, AfterChangeDelTime, man, ChangeTime);
        }
}



