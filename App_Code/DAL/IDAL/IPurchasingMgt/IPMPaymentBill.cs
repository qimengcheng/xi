using System.Data;

/// <summary>
///IPMPaymentBill 的摘要说明
/// </summary>

	public interface IPMPaymentBill
	{
        DataSet SelectPMPaymentBill(string condition);
        void InsertPMPaymentBill(PMPaymentBillinfo pMPaymentBillinfo);
        void InsertPMPaymentIDetail(PMPaymentBillinfo pMPaymentBillinfo);
        void InsertPMBillDetial(PMPaymentBillinfo pMPaymentBillinfo);
       
        void UpdatePMPaymentBill_Payment(PMPaymentBillinfo pMPaymentBillinfo);
        void UpdatePMPaymentBill_Bill(PMPaymentBillinfo pMPaymentBillinfo);
        DataSet SelectPMPurchaseOrder_Supply(PMPaymentBillinfo pMPaymentBillinfo);
        DataSet SelectPMPaymentIDetail(PMPaymentBillinfo pMPaymentBillinfo);
        DataSet SelectPMBillDetial(string condition);
        void UpdatePMBillDetial(PMPaymentBillinfo pMPaymentBillinfo);
        void DeletePMBillDetial(PMPaymentBillinfo pMPaymentBillinfo);
        void UpdatePMPaymentIDetail(PMPaymentBillinfo pMPaymentBillinfo);
        void DeletePMPaymentIDetail(PMPaymentBillinfo pMPaymentBillinfo);
        void UpdatePMPO_AlreadyPay(PMPaymentBillinfo pMPaymentBillinfo);
        DataSet SelectPMPurchaseOrder_NBill(PMPaymentBillinfo pMPaymentBillinfo);
        DataSet SelectPMBillDetial_One(string condition);
        DataSet SelectPMPurchaseOrder_Pay(PMPaymentBillinfo pMPaymentBillinfo);
        void UpdatePMPB_TDBill(PMPaymentBillinfo pMPaymentBillinfo);
        void UpdatePMPaymentBill(PMPaymentBillinfo pMPaymentBillinfo);
       void UpdatePMPO_AlreadyBill(PMPaymentBillinfo pMPaymentBillinfo);

       DataSet SelectPMPurchaseOrder(string condition);

	}
