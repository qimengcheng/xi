using System;

/// <summary>
///PMPurchaseOrderinfo 的摘要说明
/// </summary>
public class PMPurchaseOrderinfo
{
    private Guid pMPAD_ID;
 
    private Guid pMPO_PurchaseOrderID;
 
    private Guid iMMBD_MaterialID;
 
    private Guid pMPAM_ID;
 
    private decimal pMPAD_Num;
 
    private string pMPAD_Require;
 
    private string pMPAD_Purchase;
 
    private string pMPAD_TotalMoney;
 
    private decimal pMPAD_Price;
 
    private DateTime pMPAD_NeedTime;
 
    private Guid iMUC_ID;
 
    private string pMPAM_ApplyNum;
 
    private string pMPAM_ApplyMan;
 
    private string pMPAM_Department;
 
    private Guid iMMt_MaterialTypeID;
 
    private string iMMBD_MaterialName;
 
    private string iMMBD_SpecificationModel;
 
    private string iMMT_MaterialType;
 
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
 
    private decimal pMPO_TotalMoney;
 
    private decimal pMPO_ResidueMoney;
 
    private decimal pMPO_AlreadyPay;
 
    private string pMPO_CountInPayables;
 
    private string pMPO_State;
 
    private string totalNum;
 
    private Guid pMPOD_PurchaseDetailID;
 
    private decimal pMPOD_Num;
 
    private decimal pMPOD_Price;
 
    private decimal pMPOD_TotalMoney;
 
    private string pMPOD_ProductRequest;
 
    private string pMPOD_Remark;
 
    private Guid iMISD_ID;
 
    private bool pMPOD_AllDelieved;

    private DateTime pMPOD_MakeTime;
    private string pMPOD_MakeMan;

    private Decimal pMPO_Num;

    public Decimal PMPO_Num
    {
        get { return pMPO_Num; }
        set { pMPO_Num = value; }
    }
    private Decimal pMPO_ActuallNum;

    public Decimal PMPO_ActuallNum
    {
        get { return pMPO_ActuallNum; }
        set { pMPO_ActuallNum = value; }
    }
    private Decimal pMPO_AdvancePayNum;

    public Decimal PMPO_AdvancePayNum
    {
        get { return pMPO_AdvancePayNum; }
        set { pMPO_AdvancePayNum = value; }
    }
    private string pMPAD_Remark;

    public string PMPAD_Remark
    {
        get { return pMPAD_Remark; }
        set { pMPAD_Remark = value; }
    }

	public PMPurchaseOrderinfo()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public PMPurchaseOrderinfo(Guid _pMPAD_ID, Guid _pMPO_PurchaseOrderID, Guid _iMMBD_MaterialID, Guid _pMPAM_ID, decimal _pMPAD_Num,string _pMPAD_Require, string _pMPAD_Purchase, string _pMPAD_TotalMoney,
                              decimal _pMPAD_Price, DateTime _pMPAD_NeedTime, Guid _iMUC_ID, string _pMPAM_ApplyNum, string _pMPAM_ApplyMan, string _pMPAM_Department, Guid  _iMMt_MaterialTypeID,
                              string _iMMBD_MaterialName,string _iMMBD_SpecificationModel, string _iMMT_MaterialType, Guid _pMSI_ID, string _pMPO_PurchaseOrderNum, string _pMPO_ArriverCondition,
                              DateTime _pMPO_MakeTime, string _pMPO_MakeMan, DateTime _pMPO_PlanArrTime, string _pMPO_PayWay, int _pMPO_PaymentTime, string _pMPO_BillNum, DateTime _pMPO_BillTime,Decimal _pMPO_Num,
                              decimal _pMPO_TotalMoney, decimal _pMPO_ResidueMoney,decimal _pMPO_AlreadyPay,string _pMPO_CountInPayables, string _pMPO_State, string _totalNum, Guid  _pMPOD_PurchaseDetailID,Decimal _pMPO_ActuallNum,
                              decimal _pMPOD_Num, decimal _pMPOD_Price, decimal _pMPOD_TotalMoney, string _pMPOD_ProductRequest, string _pMPOD_Remark, Guid _iMISD_ID, bool _pMPOD_AllDelieved, DateTime _pMPOD_MakeTime, string _pMPOD_MakeMan)
    {
        pMPO_ActuallNum = _pMPO_ActuallNum;

        pMPO_Num = _pMPO_Num; 

    pMPAD_ID=_pMPAD_ID;

     pMPO_PurchaseOrderID=_pMPO_PurchaseOrderID;

     iMMBD_MaterialID=_iMMBD_MaterialID;

     pMPAM_ID=_pMPAM_ID;

     pMPAD_Num=_pMPAD_Num;

     pMPAD_Require=_pMPAD_Require;

     pMPAD_Purchase=_pMPAD_Purchase;

     pMPAD_TotalMoney=_pMPAD_TotalMoney;

      pMPAD_Price=_pMPAD_Price;

      pMPAD_NeedTime=_pMPAD_NeedTime;

     iMUC_ID=_iMUC_ID;

     pMPAM_ApplyNum=_pMPAM_ApplyNum;

     pMPAM_ApplyMan=_pMPAM_ApplyMan;

     pMPAM_Department=_pMPAM_Department;

      iMMt_MaterialTypeID=_iMMt_MaterialTypeID;

     iMMBD_MaterialName=_iMMBD_MaterialName;

     iMMBD_SpecificationModel=_iMMBD_SpecificationModel;

    iMMT_MaterialType=_iMMT_MaterialType;

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
   totalNum=_totalNum;
    pMPOD_PurchaseDetailID=_pMPOD_PurchaseDetailID;
  
    pMPOD_Num=_pMPOD_Num;
    pMPOD_Price=_pMPOD_Price;
    pMPOD_TotalMoney=_pMPOD_TotalMoney;
   pMPOD_ProductRequest=_pMPOD_ProductRequest;
    pMPOD_Remark=_pMPOD_Remark;
    iMISD_ID=_iMISD_ID;
    pMPOD_AllDelieved = _pMPOD_AllDelieved;
    pMPOD_MakeTime = _pMPOD_MakeTime;
    pMPOD_MakeMan = _pMPOD_MakeMan;
    }
    public Guid PMPAD_ID
    {
        get { return pMPAD_ID; }
        set { pMPAD_ID = value; }
    }


    public Guid PMPO_PurchaseOrderID
    {
        get { return pMPO_PurchaseOrderID; }
        set { pMPO_PurchaseOrderID = value; }
    }


    public Guid IMMBD_MaterialID
    {
        get { return iMMBD_MaterialID; }
        set { iMMBD_MaterialID = value; }
    }



    public Guid PMPAM_ID
    {
        get { return pMPAM_ID; }
        set { pMPAM_ID = value; }
    }

 

    public decimal PMPAD_Num
    {
        get { return pMPAD_Num; }
        set { pMPAD_Num = value; }
    }



    public string PMPAD_Require
    {
        get { return pMPAD_Require; }
        set { pMPAD_Require = value; }
    }

 

    public string PMPAD_Purchase
    {
        get { return pMPAD_Purchase; }
        set { pMPAD_Purchase = value; }
    }



    public string PMPAD_TotalMoney
    {
        get { return pMPAD_TotalMoney; }
        set { pMPAD_TotalMoney = value; }
    }



    public decimal PMPAD_Price
    {
        get { return pMPAD_Price; }
        set { pMPAD_Price = value; }
    }



    public DateTime PMPAD_NeedTime
    {
        get { return pMPAD_NeedTime; }
        set { pMPAD_NeedTime = value; }
    }

  

    public Guid IMUC_ID
    {
        get { return iMUC_ID; }
        set { iMUC_ID = value; }
    }



    public string PMPAM_ApplyNum
    {
        get { return pMPAM_ApplyNum; }
        set { pMPAM_ApplyNum = value; }
    }



    public string PMPAM_ApplyMan
    {
        get { return pMPAM_ApplyMan; }
        set { pMPAM_ApplyMan = value; }
    }


    public string PMPAM_Department
    {
        get { return pMPAM_Department; }
        set { pMPAM_Department = value; }
    }



    public Guid IMMt_MaterialTypeID
    {
        get { return iMMt_MaterialTypeID; }
        set { iMMt_MaterialTypeID = value; }
    }



    public string IMMBD_MaterialName
    {
        get { return iMMBD_MaterialName; }
        set { iMMBD_MaterialName = value; }
    }



    public string IMMBD_SpecificationModel
    {
        get { return iMMBD_SpecificationModel; }
        set { iMMBD_SpecificationModel = value; }
    }



    public string IMMT_MaterialType
    {
        get { return iMMT_MaterialType; }
        set { iMMT_MaterialType = value; }
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


    public decimal PMPO_TotalMoney
    {
        get { return pMPO_TotalMoney; }
        set { pMPO_TotalMoney = value; }
    }


    public decimal PMPO_ResidueMoney
    {
        get { return pMPO_ResidueMoney; }
        set { pMPO_ResidueMoney = value; }
    }


    public decimal PMPO_AlreadyPay
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


    public string TotalNum
    {
        get { return totalNum; }
        set { totalNum = value; }
    }

    public Guid PMPOD_PurchaseDetailID
    {
        get { return pMPOD_PurchaseDetailID; }
        set { pMPOD_PurchaseDetailID = value; }
    }



    public decimal PMPOD_Num
    {
        get { return pMPOD_Num; }
        set { pMPOD_Num = value; }
    }


    public decimal PMPOD_Price
    {
        get { return pMPOD_Price; }
        set { pMPOD_Price = value; }
    }


    public decimal PMPOD_TotalMoney
    {
        get { return pMPOD_TotalMoney; }
        set { pMPOD_TotalMoney = value; }
    }

    public string PMPOD_ProductRequest
    {
        get { return pMPOD_ProductRequest; }
        set { pMPOD_ProductRequest = value; }
    }


    public string PMPOD_Remark
    {
        get { return pMPOD_Remark; }
        set { pMPOD_Remark = value; }
    }


    public Guid IMISD_ID
    {
        get { return iMISD_ID; }
        set { iMISD_ID = value; }
    }


    public bool PMPOD_AllDelieved
    {
        get { return pMPOD_AllDelieved; }
        set { pMPOD_AllDelieved = value; }
    }
    public DateTime PMPOD_MakeTime
    {
        get { return pMPOD_MakeTime; }
        set { pMPOD_MakeTime = value; }
    }
    public string PMPOD_MakeMan
    {
        get { return pMPOD_MakeMan; }
        set { pMPOD_MakeMan = value; }
    }
}