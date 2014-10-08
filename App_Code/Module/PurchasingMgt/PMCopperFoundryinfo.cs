using System;

/// <summary>
///PMCopperFoundryinfo 的摘要说明
/// </summary>
public class PMCopperFoundryinfo
{
    private Guid pMCF_ID;

    public Guid PMCF_ID
    {
        get { return pMCF_ID; }
        set { pMCF_ID = value; }
    }
    private Guid pMSI_ID;

    public Guid PMSI_ID
    {
        get { return pMSI_ID; }
        set { pMSI_ID = value; }
    }
    private string pMCF_MaterialName;

    public string PMCF_MaterialName
    {
        get { return pMCF_MaterialName; }
        set { pMCF_MaterialName = value; }
    }
    private Decimal pMCF_ReturnTotalNum;

    public Decimal PMCF_ReturnTotalNum
    {
        get { return pMCF_ReturnTotalNum; }
        set { pMCF_ReturnTotalNum = value; }
    }
    private Decimal pMCF_InTotalNum;

    public Decimal PMCF_InTotalNum
    {
        get { return pMCF_InTotalNum; }
        set { pMCF_InTotalNum = value; }
    }
    private Decimal pMCF_NetMargin;

    public Decimal PMCF_NetMargin
    {
        get { return pMCF_NetMargin; }
        set { pMCF_NetMargin = value; }
    }
    private Guid pMCI_ID;

    public Guid PMCI_ID
    {
        get { return pMCI_ID; }
        set { pMCI_ID = value; }
    }
    private DateTime pMCI_Time;

    public DateTime PMCI_Time
    {
        get { return pMCI_Time; }
        set { pMCI_Time = value; }
    }
    private Decimal pMCI_ProductNum;

    public Decimal PMCI_ProductNum
    {
        get { return pMCI_ProductNum; }
        set { pMCI_ProductNum = value; }
    }
    private Decimal pMCI_ProPrice;

    public Decimal PMCI_ProPrice
    {
        get { return pMCI_ProPrice; }
        set { pMCI_ProPrice = value; }
    }
    private Decimal pMCI_BillTotalPrice;

    public Decimal PMCI_BillTotalPrice
    {
        get { return pMCI_BillTotalPrice; }
        set { pMCI_BillTotalPrice = value; }
    }
    private Decimal pMCI_AccountRate;

    public Decimal PMCI_AccountRate
    {
        get { return pMCI_AccountRate; }
        set { pMCI_AccountRate = value; }
    }
    private Decimal pMCI_ExpendNum;

    public Decimal PMCI_ExpendNum
    {
        get { return pMCI_ExpendNum; }
        set { pMCI_ExpendNum = value; }
    }
    private string pMCI_BillNum;

    public string PMCI_BillNum
    {
        get { return pMCI_BillNum; }
        set { pMCI_BillNum = value; }
    }
    private string pMCI_Pay;

    public string PMCI_Pay
    {
        get { return pMCI_Pay; }
        set { pMCI_Pay = value; }
    }
    private string pMCI_Remark;

    public string PMCI_Remark
    {
        get { return pMCI_Remark; }
        set { pMCI_Remark = value; }
    }
    private string pMCI_Model;

    public string PMCI_Model
    {
        get { return pMCI_Model; }
        set { pMCI_Model = value; }
    }
    private Guid pMCP_ID;

    public Guid PMCP_ID
    {
        get { return pMCP_ID; }
        set { pMCP_ID = value; }
    }
    private Decimal pMCP_CopperPrice;

    public Decimal PMCP_CopperPrice
    {
        get { return pMCP_CopperPrice; }
        set { pMCP_CopperPrice = value; }
    }
    private Decimal pMCP_CopperDiscountRate;

    public Decimal PMCP_CopperDiscountRate
    {
        get { return pMCP_CopperDiscountRate; }
        set { pMCP_CopperDiscountRate = value; }
    }
    private Decimal pMCP_ZnPrice;

    public Decimal PMCP_ZnPrice
    {
        get { return pMCP_ZnPrice; }
        set { pMCP_ZnPrice = value; }
    }
    private Decimal pMCP_ZnDiscountRate;

    public Decimal PMCP_ZnDiscountRate
    {
        get { return pMCP_ZnDiscountRate; }
        set { pMCP_ZnDiscountRate = value; }
    }
    private Decimal pMCP_ProcessCost;

    public Decimal PMCP_ProcessCost
    {
        get { return pMCP_ProcessCost; }
        set { pMCP_ProcessCost = value; }
    }
    private Decimal pMCP_UnitPrice;

    public Decimal PMCP_UnitPrice
    {
        get { return pMCP_UnitPrice; }
        set { pMCP_UnitPrice = value; }
    }
    private string pMCP_NowPrice;

    public string PMCP_NowPrice
    {
        get { return pMCP_NowPrice; }
        set { pMCP_NowPrice = value; }
    }
    private DateTime pMCP_MakeTime;

    public DateTime PMCP_MakeTime
    {
        get { return pMCP_MakeTime; }
        set { pMCP_MakeTime = value; }
    }
    private string pMCP_MakeMan;

    public string PMCP_MakeMan
    {
        get { return pMCP_MakeMan; }
        set { pMCP_MakeMan = value; }
    }
    private Decimal pMCP_AccountRate;

    public Decimal PMCP_AccountRate
    {
        get { return pMCP_AccountRate; }
        set { pMCP_AccountRate = value; }
    }
    private Guid pMCR_ID;

    public Guid PMCR_ID
    {
        get { return pMCR_ID; }
        set { pMCR_ID = value; }
    }
    private DateTime pMCR_Time;

    public DateTime PMCR_Time
    {
        get { return pMCR_Time; }
        set { pMCR_Time = value; }
    }
    private Decimal pMCR_Num;

    public Decimal PMCR_Num
    {
        get { return pMCR_Num; }
        set { pMCR_Num = value; }
    }
    private Decimal pMCR_DeductRate;

    public Decimal PMCR_DeductRate
    {
        get { return pMCR_DeductRate; }
        set { pMCR_DeductRate = value; }
    }
    private Decimal pMCR_DeductNum;

    public Decimal PMCR_DeductNum
    {
        get { return pMCR_DeductNum; }
        set { pMCR_DeductNum = value; }
    }
    private Decimal pMCR_NetNum;

    public Decimal PMCR_NetNum
    {
        get { return pMCR_NetNum; }
        set { pMCR_NetNum = value; }
    }
    private string pMCR_Remark;

    public string PMCR_Remark
    {
        get { return pMCR_Remark; }
        set { pMCR_Remark = value; }
    }
	public PMCopperFoundryinfo()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public PMCopperFoundryinfo(Guid _pMCF_ID, Guid _pMSI_ID, string _pMCF_MaterialName, Decimal _pMCF_ReturnTotalNum, Decimal _pMCF_InTotalNum, Decimal _pMCF_NetMargin, Guid _pMCI_ID, DateTime _pMCI_Time,
            Decimal _pMCI_ProductNum, Decimal _pMCI_ProPrice, Decimal _pMCI_BillTotalPrice, Decimal _pMCI_AccountRate, Decimal _pMCI_ExpendNum, string _pMCI_BillNum, string _pMCI_Pay, string _pMCI_Remark,
            string _pMCI_Model, Guid _pMCP_ID, Decimal _pMCP_CopperPrice, Decimal _pMCP_CopperDiscountRate, Decimal _pMCP_ZnPrice, Decimal _pMCP_ZnDiscountRate, Decimal _pMCP_ProcessCost, Decimal _pMCP_UnitPrice,
            string _pMCP_NowPrice, DateTime _pMCP_MakeTime, string _pMCP_MakeMan, Decimal _pMCP_AccountRate, Guid _pMCR_ID, DateTime _pMCR_Time, Decimal _pMCR_Num, Decimal _pMCR_DeductRate, Decimal _pMCR_DeductNum,
            Decimal _pMCR_NetNum, string _pMCR_Remark)
    {
        pMCF_ID=_pMCF_ID;
        pMSI_ID=_pMSI_ID;
        pMCF_MaterialName=_pMCF_MaterialName;
        pMCF_ReturnTotalNum=_pMCF_ReturnTotalNum;
        pMCF_InTotalNum=_pMCF_InTotalNum;
        pMCF_NetMargin=_pMCF_NetMargin;
        pMCI_ID=_pMCI_ID;
        pMCI_Time=_pMCI_Time;
        pMCI_ProductNum=_pMCI_ProductNum;
        pMCI_ProPrice=_pMCI_ProPrice;
        pMCI_BillTotalPrice=_pMCI_BillTotalPrice;
        pMCI_AccountRate=_pMCI_AccountRate;
        pMCI_ExpendNum=_pMCI_ExpendNum;
        pMCI_BillNum=_pMCI_BillNum;
        pMCI_Pay=_pMCI_Pay;
        pMCI_Remark=_pMCI_Remark;
        pMCI_Model=_pMCI_Model;
        pMCP_ID=_pMCP_ID;
        pMCP_CopperPrice=_pMCP_CopperPrice;
        pMCP_CopperDiscountRate=_pMCP_CopperDiscountRate;
        pMCP_ZnPrice=_pMCP_ZnPrice;
        pMCP_ZnDiscountRate=_pMCP_ZnDiscountRate;
        pMCP_ProcessCost=_pMCP_ProcessCost;
        pMCP_UnitPrice=_pMCP_UnitPrice;
        pMCP_NowPrice=_pMCP_NowPrice;
        pMCP_MakeTime=_pMCP_MakeTime;
        pMCP_MakeMan=_pMCP_MakeMan;
        pMCP_AccountRate=_pMCP_AccountRate;
        pMCR_ID=_pMCR_ID;
        pMCR_Time=_pMCR_Time;
        pMCR_Num=_pMCR_Num;
        pMCR_DeductRate=_pMCR_DeductRate;
        pMCR_DeductNum=_pMCR_DeductNum;
        pMCR_NetNum=_pMCR_NetNum;
        pMCR_Remark = _pMCR_Remark;
    }
}