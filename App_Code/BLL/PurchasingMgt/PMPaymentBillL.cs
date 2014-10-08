using System.Data;

/// <summary>
///PMPaymentBillL 的摘要说明
/// </summary>
public class PMPaymentBillL
{
    private static readonly IPMPaymentBill PMP = DALFactory.CreatePMPaymentBill();
	public PMPaymentBillL()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public DataSet SelectPMPaymentBill(string condition)
    {
        return PMP.SelectPMPaymentBill(condition);
    }
    public void InsertPMPaymentBill(PMPaymentBillinfo pMPaymentBillinfo)
    {
        PMP.InsertPMPaymentBill(pMPaymentBillinfo);
    }
    public void InsertPMPaymentIDetail(PMPaymentBillinfo pMPaymentBillinfo)
    {
        PMP.InsertPMPaymentIDetail(pMPaymentBillinfo);
    }
    public void InsertPMBillDetial(PMPaymentBillinfo pMPaymentBillinfo)
    {
        PMP.InsertPMBillDetial(pMPaymentBillinfo);
    }

    public void UpdatePMPaymentBill_Payment(PMPaymentBillinfo pMPaymentBillinfo)
    {
        PMP.UpdatePMPaymentBill_Payment(pMPaymentBillinfo);
    }
    public void UpdatePMPaymentBill_Bill(PMPaymentBillinfo pMPaymentBillinfo)
    {
        PMP.UpdatePMPaymentBill_Bill(pMPaymentBillinfo);
    }
    public DataSet SelectPMPurchaseOrder_Supply(PMPaymentBillinfo pMPaymentBillinfo)
    {
        return PMP.SelectPMPurchaseOrder_Supply(pMPaymentBillinfo);
    }
    public DataSet SelectPMPaymentIDetail(PMPaymentBillinfo pMPaymentBillinfo)
    {
        return PMP.SelectPMPaymentIDetail(pMPaymentBillinfo);    
    }
    public DataSet SelectPMBillDetial(string condition)
    {
        return PMP.SelectPMBillDetial(condition);
    }
    public void UpdatePMBillDetial(PMPaymentBillinfo pMPaymentBillinfo)
    {
        PMP.UpdatePMBillDetial(pMPaymentBillinfo);
    }
    public void DeletePMBillDetial(PMPaymentBillinfo pMPaymentBillinfo)
    {
        PMP.DeletePMBillDetial(pMPaymentBillinfo);
    }
    public void UpdatePMPaymentIDetail(PMPaymentBillinfo pMPaymentBillinfo)
    {
        PMP.UpdatePMPaymentIDetail(pMPaymentBillinfo);
    }
    public void DeletePMPaymentIDetail(PMPaymentBillinfo pMPaymentBillinfo)
    {
        PMP.DeletePMPaymentIDetail(pMPaymentBillinfo);
    }
    public void UpdatePMPO_AlreadyPay(PMPaymentBillinfo pMPaymentBillinfo)
    {
        PMP.UpdatePMPO_AlreadyPay(pMPaymentBillinfo);
    }
    public DataSet SelectPMPurchaseOrder_NBill(PMPaymentBillinfo pMPaymentBillinfo)
    {
        return PMP.SelectPMPurchaseOrder_NBill(pMPaymentBillinfo);
    }

    public DataSet SelectPMPurchaseOrder_Pay(PMPaymentBillinfo pMPaymentBillinfo)
    {
        return PMP.SelectPMPurchaseOrder_Pay(pMPaymentBillinfo);
    }
    public void UpdatePMPB_TDBill(PMPaymentBillinfo pMPaymentBillinfo)
    { 
    PMP.UpdatePMPB_TDBill(pMPaymentBillinfo);
    }
    public void UpdatePMPaymentBill(PMPaymentBillinfo pMPaymentBillinfo)
    {
        PMP.UpdatePMPaymentBill(pMPaymentBillinfo);
    }
    public void UpdatePMPO_AlreadyBill(PMPaymentBillinfo pMPaymentBillinfo)
    {
        PMP.UpdatePMPO_AlreadyBill(pMPaymentBillinfo);
    }
    public DataSet SelectPMBillDetial_One(string condition)
    {
        return PMP.SelectPMBillDetial_One(condition);
    }
    public DataSet SelectPMPurchaseOrder(string condition)
    {
        return PMP.SelectPMPurchaseOrder(condition);
    }
  }