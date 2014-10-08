using System;

/// <summary>
///PMPaymentBillinfo 的摘要说明
/// </summary>
public class PMPaymentBillinfo
{
    private Guid pMPO_PurchaseOrderID;


    private Guid pMSI_ID;

    private string pMPO_PurchaseOrderNum;


    private string pMPO_ArriverCondition;

    private DateTime pMPO_MakeTime;


    private string pMPO_MakeMan;


    private DateTime pMPO_PlanArrTime;


    private string pMPO_PayWay;


    private int pMPO_PaymentTime;


    private string pMPO_BillNum;


    private DateTime pMPO_BillTime;


    private Decimal pMPO_TotalMoney;


    private Decimal pMPO_ResidueMoney;


    private string pMPO_AlreadyPay;

    private string pMPO_CountInPayables;


    private string pMPO_State;


    private Guid pMPB_ID;


    private Decimal pMPB_TotalDebt;

    private Decimal pMPB_Due;

    private Decimal pMPB_TotalBill;

    private Decimal pMPB_TotalPaided;

    private Guid pMPD_ID;

    private Decimal pMPD_Pay;

    private string pMPD_PayWay;


    private DateTime pMPD_PayTime;


    private string pMPD_Man;


    private DateTime pMPD_Time;


    private Guid pMBD_ID;

    private Decimal pMBD_TotalBill;

    private string pMBD_BillNum;


    private DateTime pMBD_BillDate;

    private string pMBD_ManName;


    private string pMPO_AlreadyBill;

    public string PMPO_AlreadyBill
    {
        get { return pMPO_AlreadyBill; }
        set { pMPO_AlreadyBill = value; }
    }
    private string pMBD_Remark;

    public string PMBD_Remark
    {
        get { return pMBD_Remark; }
        set { pMBD_Remark = value; }
    }
    private string pMBD_OrderNum;

    public string PMBD_OrderNum
    {
        get { return pMBD_OrderNum; }
        set { pMBD_OrderNum = value; }
    }
    private string pMBD_PayOff;

    public string PMBD_PayOff
    {
        get { return pMBD_PayOff; }
        set { pMBD_PayOff = value; }
    }




	public PMPaymentBillinfo()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public PMPaymentBillinfo(Guid _pMPO_PurchaseOrderID, Guid _pMSI_ID, string _pMPO_PurchaseOrderNum,string _pMPO_ArriverCondition, DateTime _pMPO_MakeTime,

    string _pMPO_MakeMan, DateTime _pMPO_PlanArrTime, string _pMPO_PayWay, int _pMPO_PaymentTime, string _pMPO_BillNum,DateTime _pMPO_BillTime,Decimal _pMPO_TotalMoney,

    Decimal _pMPO_ResidueMoney,string _pMPO_AlreadyPay,string _pMPO_CountInPayables,string _pMPO_State, Guid _pMPB_ID, Decimal _pMPB_TotalDebt, Decimal _pMPB_Due, Decimal _pMPB_TotalBill, Decimal _pMPB_TotalPaided,

    Guid _pMPD_ID, Decimal _pMPD_Pay, string _pMPD_PayWay, DateTime _pMPD_PayTime, string _pMPD_Man, DateTime _pMPD_Time, string _pMPO_AlreadyBill,

    Guid _pMBD_ID, Decimal _pMBD_TotalBill, string _pMBD_BillNum, DateTime _pMBD_BillDate, string _pMBD_ManName, string _pMBD_Remark, string _pMBD_OrderNum, string _pMBD_PayOff)
    {
        pMPO_AlreadyBill = _pMPO_AlreadyBill;
        pMBD_Remark = _pMBD_Remark;
        pMBD_OrderNum = _pMBD_OrderNum;
        pMBD_PayOff = _pMBD_PayOff;
    pMPO_PurchaseOrderID=_pMPO_PurchaseOrderID; 
        pMSI_ID=_pMSI_ID;
        pMPO_PurchaseOrderNum=_pMPO_PurchaseOrderNum;
       pMPO_ArriverCondition=_pMPO_ArriverCondition;
       pMPO_MakeTime=_pMPO_MakeTime;

    pMPO_MakeMan=_pMPO_MakeMan;
        pMPO_PlanArrTime=_pMPO_PlanArrTime;
        pMPO_PayWay=_pMPO_PayWay;
        pMPO_PaymentTime=_pMPO_PaymentTime;
        pMPO_BillNum=_pMPO_BillNum;
        pMPO_BillTime=_pMPO_BillTime;
        pMPO_TotalMoney=_pMPO_TotalMoney;

   pMPO_ResidueMoney=_pMPO_ResidueMoney;
        pMPO_AlreadyPay=_pMPO_AlreadyPay;
        pMPO_CountInPayables=_pMPO_CountInPayables;
        pMPO_State=_pMPO_State;
       pMPB_ID=_pMPB_ID;
        pMPB_TotalDebt=_pMPB_TotalDebt;
       pMPB_Due=_pMPB_Due; 
        pMPB_TotalBill=_pMPB_TotalBill;
        pMPB_TotalPaided=_pMPB_TotalPaided;

       pMPD_ID=_pMPD_ID;
       pMPD_Pay=_pMPD_Pay;
       pMPD_PayWay=_pMPD_PayWay;
       pMPD_PayTime=_pMPD_PayTime;
       pMPD_Man=_pMPD_Man;
        pMPD_Time=_pMPD_Time;

        pMBD_ID=_pMBD_ID;
        pMBD_TotalBill=_pMBD_TotalBill;
        pMBD_BillNum=_pMBD_BillNum;
        pMBD_BillDate=_pMBD_BillDate;
        pMBD_ManName = _pMBD_ManName;
    }



    public Guid PMPO_PurchaseOrderID
    {
        get { return pMPO_PurchaseOrderID; }
        set { pMPO_PurchaseOrderID = value; }
    }



    public Guid PMSI_ID
    {
        get { return pMSI_ID; }
        set { pMSI_ID = value; }
    }



    public string PMPO_PurchaseOrderNum
    {
        get { return pMPO_PurchaseOrderNum; }
        set { pMPO_PurchaseOrderNum = value; }
    }



    public string PMPO_ArriverCondition
    {
        get { return pMPO_ArriverCondition; }
        set { pMPO_ArriverCondition = value; }
    }



    public DateTime PMPO_MakeTime
    {
        get { return pMPO_MakeTime; }
        set { pMPO_MakeTime = value; }
    }



    public string PMPO_MakeMan
    {
        get { return pMPO_MakeMan; }
        set { pMPO_MakeMan = value; }
    }



    public DateTime PMPO_PlanArrTime
    {
        get { return pMPO_PlanArrTime; }
        set { pMPO_PlanArrTime = value; }
    }



    public string PMPO_PayWay
    {
        get { return pMPO_PayWay; }
        set { pMPO_PayWay = value; }
    }



    public int PMPO_PaymentTime
    {
        get { return pMPO_PaymentTime; }
        set { pMPO_PaymentTime = value; }
    }



    public string PMPO_BillNum
    {
        get { return pMPO_BillNum; }
        set { pMPO_BillNum = value; }
    }

   

    public DateTime PMPO_BillTime
    {
        get { return pMPO_BillTime; }
        set { pMPO_BillTime = value; }
    }

    

    public Decimal PMPO_TotalMoney
    {
        get { return pMPO_TotalMoney; }
        set { pMPO_TotalMoney = value; }
    }

  

    public Decimal PMPO_ResidueMoney
    {
        get { return pMPO_ResidueMoney; }
        set { pMPO_ResidueMoney = value; }
    }

   
    public string PMPO_AlreadyPay
    {
        get { return pMPO_AlreadyPay; }
        set { pMPO_AlreadyPay = value; }
    }

   

    public string PMPO_CountInPayables
    {
        get { return pMPO_CountInPayables; }
        set { pMPO_CountInPayables = value; }
    }

    

    public string PMPO_State
    {
        get { return pMPO_State; }
        set { pMPO_State = value; }
    }

 

    public Guid PMPB_ID
    {
        get { return pMPB_ID; }
        set { pMPB_ID = value; }
    }
   

    public Decimal PMPB_TotalDebt
    {
        get { return pMPB_TotalDebt; }
        set { pMPB_TotalDebt = value; }
    }
   

    public Decimal PMPB_Due
    {
        get { return pMPB_Due; }
        set { pMPB_Due = value; }
    }
  

    public Decimal PMPB_TotalBill
    {
        get { return pMPB_TotalBill; }
        set { pMPB_TotalBill = value; }
    }
   

    public Decimal PMPB_TotalPaided
    {
        get { return pMPB_TotalPaided; }
        set { pMPB_TotalPaided = value; }
    }

  

    public Guid PMPD_ID
    {
        get { return pMPD_ID; }
        set { pMPD_ID = value; }
    }
   

    public Decimal PMPD_Pay
    {
        get { return pMPD_Pay; }
        set { pMPD_Pay = value; }
    }
    

    public string PMPD_PayWay
    {
        get { return pMPD_PayWay; }
        set { pMPD_PayWay = value; }
    }
   

    public DateTime PMPD_PayTime
    {
        get { return pMPD_PayTime; }
        set { pMPD_PayTime = value; }
    }
   

    public string PMPD_Man
    {
        get { return pMPD_Man; }
        set { pMPD_Man = value; }
    }
   

    public DateTime PMPD_Time
    {
        get { return pMPD_Time; }
        set { pMPD_Time = value; }
    }

   

    public Guid PMBD_ID
    {
        get { return pMBD_ID; }
        set { pMBD_ID = value; }
    }
  

    public Decimal PMBD_TotalBill
    {
        get { return pMBD_TotalBill; }
        set { pMBD_TotalBill = value; }
    }
   

    public string PMBD_BillNum
    {
        get { return pMBD_BillNum; }
        set { pMBD_BillNum = value; }
    }
    

    public DateTime PMBD_BillDate
    {
        get { return pMBD_BillDate; }
        set { pMBD_BillDate = value; }
    }
   

    public string PMBD_ManName
    {
        get { return pMBD_ManName; }
        set { pMBD_ManName = value; }
    }

}